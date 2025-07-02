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
   public class trn_pageww : GXDataArea
   {
      public trn_pageww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_pageww( IGxContext context )
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
         chkPageIsPublished = new GXCheckbox();
         cmbPageIsContentPage = new GXCombobox();
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
         AV40OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV13OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV18ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV52ColumnsSelector);
         AV58Pgmname = GetPar( "Pgmname");
         AV14FilterFullText = GetPar( "FilterFullText");
         AV19TFTrn_PageName = GetPar( "TFTrn_PageName");
         AV20TFTrn_PageName_Sel = GetPar( "TFTrn_PageName_Sel");
         AV41TFPageJsonContent = GetPar( "TFPageJsonContent");
         AV42TFPageJsonContent_Sel = GetPar( "TFPageJsonContent_Sel");
         AV43TFPageGJSHtml = GetPar( "TFPageGJSHtml");
         AV44TFPageGJSHtml_Sel = GetPar( "TFPageGJSHtml_Sel");
         AV45TFPageGJSJson = GetPar( "TFPageGJSJson");
         AV46TFPageGJSJson_Sel = GetPar( "TFPageGJSJson_Sel");
         AV54TFPageIsPublished_Sel = (short)(Math.Round(NumberUtil.Val( GetPar( "TFPageIsPublished_Sel"), "."), 18, MidpointRounding.ToEven));
         AV48TFPageIsContentPage_Sel = (short)(Math.Round(NumberUtil.Val( GetPar( "TFPageIsContentPage_Sel"), "."), 18, MidpointRounding.ToEven));
         AV55TFPageChildren = GetPar( "TFPageChildren");
         AV56TFPageChildren_Sel = GetPar( "TFPageChildren_Sel");
         AV30IsAuthorized_Display = StringUtil.StrToBool( GetPar( "IsAuthorized_Display"));
         AV32IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV34IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV28IsAuthorized_Trn_PageName = StringUtil.StrToBool( GetPar( "IsAuthorized_Trn_PageName"));
         AV35IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV40OrderedBy, AV13OrderedDsc, AV18ManageFiltersExecutionStep, AV52ColumnsSelector, AV58Pgmname, AV14FilterFullText, AV19TFTrn_PageName, AV20TFTrn_PageName_Sel, AV41TFPageJsonContent, AV42TFPageJsonContent_Sel, AV43TFPageGJSHtml, AV44TFPageGJSHtml_Sel, AV45TFPageGJSJson, AV46TFPageGJSJson_Sel, AV54TFPageIsPublished_Sel, AV48TFPageIsContentPage_Sel, AV55TFPageChildren, AV56TFPageChildren_Sel, AV30IsAuthorized_Display, AV32IsAuthorized_Update, AV34IsAuthorized_Delete, AV28IsAuthorized_Trn_PageName, AV35IsAuthorized_Insert) ;
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
            return "trn_pageww_Execute" ;
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
         PA722( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START722( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_pageww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV58Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV58Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV30IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV30IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV32IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV32IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV34IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV34IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_TRN_PAGENAME", AV28IsAuthorized_Trn_PageName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_TRN_PAGENAME", GetSecureSignedToken( "", AV28IsAuthorized_Trn_PageName, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV35IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV35IsAuthorized_Insert, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV13OrderedDsc));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_39", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_39), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV16ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV16ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV27GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV21DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV21DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV52ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV52ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV58Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV58Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFTRN_PAGENAME", AV19TFTrn_PageName);
         GxWebStd.gx_hidden_field( context, "vTFTRN_PAGENAME_SEL", AV20TFTrn_PageName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFPAGEJSONCONTENT", AV41TFPageJsonContent);
         GxWebStd.gx_hidden_field( context, "vTFPAGEJSONCONTENT_SEL", AV42TFPageJsonContent_Sel);
         GxWebStd.gx_hidden_field( context, "vTFPAGEGJSHTML", AV43TFPageGJSHtml);
         GxWebStd.gx_hidden_field( context, "vTFPAGEGJSHTML_SEL", AV44TFPageGJSHtml_Sel);
         GxWebStd.gx_hidden_field( context, "vTFPAGEGJSJSON", AV45TFPageGJSJson);
         GxWebStd.gx_hidden_field( context, "vTFPAGEGJSJSON_SEL", AV46TFPageGJSJson_Sel);
         GxWebStd.gx_hidden_field( context, "vTFPAGEISPUBLISHED_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV54TFPageIsPublished_Sel), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFPAGEISCONTENTPAGE_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48TFPageIsContentPage_Sel), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFPAGECHILDREN", AV55TFPageChildren);
         GxWebStd.gx_hidden_field( context, "vTFPAGECHILDREN_SEL", AV56TFPageChildren_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV13OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV30IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV30IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV32IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV32IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV34IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV34IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_TRN_PAGENAME", AV28IsAuthorized_Trn_PageName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_TRN_PAGENAME", GetSecureSignedToken( "", AV28IsAuthorized_Trn_PageName, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV35IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV35IsAuthorized_Insert, context));
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
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
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
            WE722( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT722( ) ;
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
         return formatLink("trn_pageww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_PageWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " App builder pages", "") ;
      }

      protected void WB720( )
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
            ClassString = "Button ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_PageWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_PageWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, context.GetMessage( "WWP_Subscriptions_Tooltip", ""), "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_PageWW.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV16ManageFiltersData);
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV14FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV14FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWPFullTextFilter", "start", true, "", "HLP_Trn_PageWW.htm");
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV25GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV26GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV27GridAppliedFilters);
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
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV21DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV21DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV52ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0063"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0063"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_39_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0063"+"");
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

      protected void START722( )
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
         Form.Meta.addItem("description", context.GetMessage( " App builder pages", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP720( ) ;
      }

      protected void WS722( )
      {
         START722( ) ;
         EVT722( ) ;
      }

      protected void EVT722( )
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
                              E11722 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E12722 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E13722 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                              E14722 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E15722 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E16722 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E17722 ();
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
                              A392Trn_PageId = StringUtil.StrToGuid( cgiGet( edtTrn_PageId_Internalname));
                              A397Trn_PageName = cgiGet( edtTrn_PageName_Internalname);
                              A29LocationId = StringUtil.StrToGuid( cgiGet( edtLocationId_Internalname));
                              A420PageJsonContent = cgiGet( edtPageJsonContent_Internalname);
                              n420PageJsonContent = false;
                              A421PageGJSHtml = cgiGet( edtPageGJSHtml_Internalname);
                              n421PageGJSHtml = false;
                              A422PageGJSJson = cgiGet( edtPageGJSJson_Internalname);
                              n422PageGJSJson = false;
                              A423PageIsPublished = StringUtil.StrToBool( cgiGet( chkPageIsPublished_Internalname));
                              n423PageIsPublished = false;
                              cmbPageIsContentPage.Name = cmbPageIsContentPage_Internalname;
                              cmbPageIsContentPage.CurrentValue = cgiGet( cmbPageIsContentPage_Internalname);
                              A429PageIsContentPage = StringUtil.StrToBool( cgiGet( cmbPageIsContentPage_Internalname));
                              n429PageIsContentPage = false;
                              A424PageChildren = cgiGet( edtPageChildren_Internalname);
                              n424PageChildren = false;
                              A58ProductServiceId = StringUtil.StrToGuid( cgiGet( edtProductServiceId_Internalname));
                              n58ProductServiceId = false;
                              A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
                              cmbavActiongroup.Name = cmbavActiongroup_Internalname;
                              cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
                              AV47ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV47ActionGroup), 4, 0));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E18722 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E19722 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E20722 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VACTIONGROUP.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E21722 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV40OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV13OrderedDsc )
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
                        if ( nCmpId == 63 )
                        {
                           OldWwpaux_wc = cgiGet( "W0063");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0063", "", sEvt);
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

      protected void WE722( )
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

      protected void PA722( )
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
                                       short AV40OrderedBy ,
                                       bool AV13OrderedDsc ,
                                       short AV18ManageFiltersExecutionStep ,
                                       WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV52ColumnsSelector ,
                                       string AV58Pgmname ,
                                       string AV14FilterFullText ,
                                       string AV19TFTrn_PageName ,
                                       string AV20TFTrn_PageName_Sel ,
                                       string AV41TFPageJsonContent ,
                                       string AV42TFPageJsonContent_Sel ,
                                       string AV43TFPageGJSHtml ,
                                       string AV44TFPageGJSHtml_Sel ,
                                       string AV45TFPageGJSJson ,
                                       string AV46TFPageGJSJson_Sel ,
                                       short AV54TFPageIsPublished_Sel ,
                                       short AV48TFPageIsContentPage_Sel ,
                                       string AV55TFPageChildren ,
                                       string AV56TFPageChildren_Sel ,
                                       bool AV30IsAuthorized_Display ,
                                       bool AV32IsAuthorized_Update ,
                                       bool AV34IsAuthorized_Delete ,
                                       bool AV28IsAuthorized_Trn_PageName ,
                                       bool AV35IsAuthorized_Insert )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF722( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TRN_PAGEID", GetSecureSignedToken( "", A392Trn_PageId, context));
         GxWebStd.gx_hidden_field( context, "TRN_PAGEID", A392Trn_PageId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_LOCATIONID", GetSecureSignedToken( "", A29LocationId, context));
         GxWebStd.gx_hidden_field( context, "LOCATIONID", A29LocationId.ToString());
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
         RF722( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV58Pgmname = "Trn_PageWW";
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV59Trn_pagewwds_1_filterfulltext = AV14FilterFullText;
         AV60Trn_pagewwds_2_tftrn_pagename = AV19TFTrn_PageName;
         AV61Trn_pagewwds_3_tftrn_pagename_sel = AV20TFTrn_PageName_Sel;
         AV62Trn_pagewwds_4_tfpagejsoncontent = AV41TFPageJsonContent;
         AV63Trn_pagewwds_5_tfpagejsoncontent_sel = AV42TFPageJsonContent_Sel;
         AV64Trn_pagewwds_6_tfpagegjshtml = AV43TFPageGJSHtml;
         AV65Trn_pagewwds_7_tfpagegjshtml_sel = AV44TFPageGJSHtml_Sel;
         AV66Trn_pagewwds_8_tfpagegjsjson = AV45TFPageGJSJson;
         AV67Trn_pagewwds_9_tfpagegjsjson_sel = AV46TFPageGJSJson_Sel;
         AV68Trn_pagewwds_10_tfpageispublished_sel = AV54TFPageIsPublished_Sel;
         AV69Trn_pagewwds_11_tfpageiscontentpage_sel = AV48TFPageIsContentPage_Sel;
         AV70Trn_pagewwds_12_tfpagechildren = AV55TFPageChildren;
         AV71Trn_pagewwds_13_tfpagechildren_sel = AV56TFPageChildren_Sel;
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV61Trn_pagewwds_3_tftrn_pagename_sel ,
                                              AV60Trn_pagewwds_2_tftrn_pagename ,
                                              AV63Trn_pagewwds_5_tfpagejsoncontent_sel ,
                                              AV62Trn_pagewwds_4_tfpagejsoncontent ,
                                              AV65Trn_pagewwds_7_tfpagegjshtml_sel ,
                                              AV64Trn_pagewwds_6_tfpagegjshtml ,
                                              AV67Trn_pagewwds_9_tfpagegjsjson_sel ,
                                              AV66Trn_pagewwds_8_tfpagegjsjson ,
                                              AV68Trn_pagewwds_10_tfpageispublished_sel ,
                                              AV69Trn_pagewwds_11_tfpageiscontentpage_sel ,
                                              AV71Trn_pagewwds_13_tfpagechildren_sel ,
                                              AV70Trn_pagewwds_12_tfpagechildren ,
                                              A397Trn_PageName ,
                                              A420PageJsonContent ,
                                              A421PageGJSHtml ,
                                              A422PageGJSJson ,
                                              A423PageIsPublished ,
                                              A429PageIsContentPage ,
                                              A424PageChildren ,
                                              AV40OrderedBy ,
                                              AV13OrderedDsc ,
                                              AV59Trn_pagewwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV60Trn_pagewwds_2_tftrn_pagename = StringUtil.Concat( StringUtil.RTrim( AV60Trn_pagewwds_2_tftrn_pagename), "%", "");
         lV62Trn_pagewwds_4_tfpagejsoncontent = StringUtil.Concat( StringUtil.RTrim( AV62Trn_pagewwds_4_tfpagejsoncontent), "%", "");
         lV64Trn_pagewwds_6_tfpagegjshtml = StringUtil.Concat( StringUtil.RTrim( AV64Trn_pagewwds_6_tfpagegjshtml), "%", "");
         lV66Trn_pagewwds_8_tfpagegjsjson = StringUtil.Concat( StringUtil.RTrim( AV66Trn_pagewwds_8_tfpagegjsjson), "%", "");
         lV70Trn_pagewwds_12_tfpagechildren = StringUtil.Concat( StringUtil.RTrim( AV70Trn_pagewwds_12_tfpagechildren), "%", "");
         /* Using cursor H00722 */
         pr_default.execute(0, new Object[] {lV60Trn_pagewwds_2_tftrn_pagename, AV61Trn_pagewwds_3_tftrn_pagename_sel, lV62Trn_pagewwds_4_tfpagejsoncontent, AV63Trn_pagewwds_5_tfpagejsoncontent_sel, lV64Trn_pagewwds_6_tfpagegjshtml, AV65Trn_pagewwds_7_tfpagegjshtml_sel, lV66Trn_pagewwds_8_tfpagegjsjson, AV67Trn_pagewwds_9_tfpagegjsjson_sel, lV70Trn_pagewwds_12_tfpagechildren, AV71Trn_pagewwds_13_tfpagechildren_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = H00722_A11OrganisationId[0];
            A58ProductServiceId = H00722_A58ProductServiceId[0];
            n58ProductServiceId = H00722_n58ProductServiceId[0];
            A424PageChildren = H00722_A424PageChildren[0];
            n424PageChildren = H00722_n424PageChildren[0];
            A429PageIsContentPage = H00722_A429PageIsContentPage[0];
            n429PageIsContentPage = H00722_n429PageIsContentPage[0];
            A423PageIsPublished = H00722_A423PageIsPublished[0];
            n423PageIsPublished = H00722_n423PageIsPublished[0];
            A422PageGJSJson = H00722_A422PageGJSJson[0];
            n422PageGJSJson = H00722_n422PageGJSJson[0];
            A421PageGJSHtml = H00722_A421PageGJSHtml[0];
            n421PageGJSHtml = H00722_n421PageGJSHtml[0];
            A420PageJsonContent = H00722_A420PageJsonContent[0];
            n420PageJsonContent = H00722_n420PageJsonContent[0];
            A29LocationId = H00722_A29LocationId[0];
            A397Trn_PageName = H00722_A397Trn_PageName[0];
            A392Trn_PageId = H00722_A392Trn_PageId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_pagewwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A397Trn_PageName) , StringUtil.PadR( "%" + StringUtil.Lower( AV59Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A420PageJsonContent) , StringUtil.PadR( "%" + StringUtil.Lower( AV59Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A421PageGJSHtml) , StringUtil.PadR( "%" + StringUtil.Lower( AV59Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A422PageGJSJson) , StringUtil.PadR( "%" + StringUtil.Lower( AV59Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "true", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A429PageIsContentPage ) ) || ( StringUtil.Like( context.GetMessage( "false", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ! A429PageIsContentPage ) || ( StringUtil.Like( StringUtil.Lower( A424PageChildren) , StringUtil.PadR( "%" + StringUtil.Lower( AV59Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
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

      protected void RF722( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 39;
         /* Execute user event: Refresh */
         E19722 ();
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
                                                 AV61Trn_pagewwds_3_tftrn_pagename_sel ,
                                                 AV60Trn_pagewwds_2_tftrn_pagename ,
                                                 AV63Trn_pagewwds_5_tfpagejsoncontent_sel ,
                                                 AV62Trn_pagewwds_4_tfpagejsoncontent ,
                                                 AV65Trn_pagewwds_7_tfpagegjshtml_sel ,
                                                 AV64Trn_pagewwds_6_tfpagegjshtml ,
                                                 AV67Trn_pagewwds_9_tfpagegjsjson_sel ,
                                                 AV66Trn_pagewwds_8_tfpagegjsjson ,
                                                 AV68Trn_pagewwds_10_tfpageispublished_sel ,
                                                 AV69Trn_pagewwds_11_tfpageiscontentpage_sel ,
                                                 AV71Trn_pagewwds_13_tfpagechildren_sel ,
                                                 AV70Trn_pagewwds_12_tfpagechildren ,
                                                 A397Trn_PageName ,
                                                 A420PageJsonContent ,
                                                 A421PageGJSHtml ,
                                                 A422PageGJSJson ,
                                                 A423PageIsPublished ,
                                                 A429PageIsContentPage ,
                                                 A424PageChildren ,
                                                 AV40OrderedBy ,
                                                 AV13OrderedDsc ,
                                                 AV59Trn_pagewwds_1_filterfulltext } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV60Trn_pagewwds_2_tftrn_pagename = StringUtil.Concat( StringUtil.RTrim( AV60Trn_pagewwds_2_tftrn_pagename), "%", "");
            lV62Trn_pagewwds_4_tfpagejsoncontent = StringUtil.Concat( StringUtil.RTrim( AV62Trn_pagewwds_4_tfpagejsoncontent), "%", "");
            lV64Trn_pagewwds_6_tfpagegjshtml = StringUtil.Concat( StringUtil.RTrim( AV64Trn_pagewwds_6_tfpagegjshtml), "%", "");
            lV66Trn_pagewwds_8_tfpagegjsjson = StringUtil.Concat( StringUtil.RTrim( AV66Trn_pagewwds_8_tfpagegjsjson), "%", "");
            lV70Trn_pagewwds_12_tfpagechildren = StringUtil.Concat( StringUtil.RTrim( AV70Trn_pagewwds_12_tfpagechildren), "%", "");
            /* Using cursor H00723 */
            pr_default.execute(1, new Object[] {lV60Trn_pagewwds_2_tftrn_pagename, AV61Trn_pagewwds_3_tftrn_pagename_sel, lV62Trn_pagewwds_4_tfpagejsoncontent, AV63Trn_pagewwds_5_tfpagejsoncontent_sel, lV64Trn_pagewwds_6_tfpagegjshtml, AV65Trn_pagewwds_7_tfpagegjshtml_sel, lV66Trn_pagewwds_8_tfpagegjsjson, AV67Trn_pagewwds_9_tfpagegjsjson_sel, lV70Trn_pagewwds_12_tfpagechildren, AV71Trn_pagewwds_13_tfpagechildren_sel});
            nGXsfl_39_idx = 1;
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A11OrganisationId = H00723_A11OrganisationId[0];
               A58ProductServiceId = H00723_A58ProductServiceId[0];
               n58ProductServiceId = H00723_n58ProductServiceId[0];
               A424PageChildren = H00723_A424PageChildren[0];
               n424PageChildren = H00723_n424PageChildren[0];
               A429PageIsContentPage = H00723_A429PageIsContentPage[0];
               n429PageIsContentPage = H00723_n429PageIsContentPage[0];
               A423PageIsPublished = H00723_A423PageIsPublished[0];
               n423PageIsPublished = H00723_n423PageIsPublished[0];
               A422PageGJSJson = H00723_A422PageGJSJson[0];
               n422PageGJSJson = H00723_n422PageGJSJson[0];
               A421PageGJSHtml = H00723_A421PageGJSHtml[0];
               n421PageGJSHtml = H00723_n421PageGJSHtml[0];
               A420PageJsonContent = H00723_A420PageJsonContent[0];
               n420PageJsonContent = H00723_n420PageJsonContent[0];
               A29LocationId = H00723_A29LocationId[0];
               A397Trn_PageName = H00723_A397Trn_PageName[0];
               A392Trn_PageId = H00723_A392Trn_PageId[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_pagewwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A397Trn_PageName) , StringUtil.PadR( "%" + StringUtil.Lower( AV59Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A420PageJsonContent) , StringUtil.PadR( "%" + StringUtil.Lower( AV59Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A421PageGJSHtml) , StringUtil.PadR( "%" + StringUtil.Lower( AV59Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A422PageGJSJson) , StringUtil.PadR( "%" + StringUtil.Lower( AV59Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "true", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A429PageIsContentPage ) ) || ( StringUtil.Like( context.GetMessage( "false", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ! A429PageIsContentPage ) || ( StringUtil.Like( StringUtil.Lower( A424PageChildren) , StringUtil.PadR( "%" + StringUtil.Lower( AV59Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
               {
                  /* Execute user event: Grid.Load */
                  E20722 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 39;
            WB720( ) ;
         }
         bGXsfl_39_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes722( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV58Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV58Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV30IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV30IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV32IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV32IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV34IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV34IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_TRN_PAGENAME", AV28IsAuthorized_Trn_PageName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_TRN_PAGENAME", GetSecureSignedToken( "", AV28IsAuthorized_Trn_PageName, context));
         GxWebStd.gx_hidden_field( context, "gxhash_TRN_PAGEID"+"_"+sGXsfl_39_idx, GetSecureSignedToken( sGXsfl_39_idx, A392Trn_PageId, context));
         GxWebStd.gx_hidden_field( context, "gxhash_LOCATIONID"+"_"+sGXsfl_39_idx, GetSecureSignedToken( sGXsfl_39_idx, A29LocationId, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV35IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV35IsAuthorized_Insert, context));
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
         AV59Trn_pagewwds_1_filterfulltext = AV14FilterFullText;
         AV60Trn_pagewwds_2_tftrn_pagename = AV19TFTrn_PageName;
         AV61Trn_pagewwds_3_tftrn_pagename_sel = AV20TFTrn_PageName_Sel;
         AV62Trn_pagewwds_4_tfpagejsoncontent = AV41TFPageJsonContent;
         AV63Trn_pagewwds_5_tfpagejsoncontent_sel = AV42TFPageJsonContent_Sel;
         AV64Trn_pagewwds_6_tfpagegjshtml = AV43TFPageGJSHtml;
         AV65Trn_pagewwds_7_tfpagegjshtml_sel = AV44TFPageGJSHtml_Sel;
         AV66Trn_pagewwds_8_tfpagegjsjson = AV45TFPageGJSJson;
         AV67Trn_pagewwds_9_tfpagegjsjson_sel = AV46TFPageGJSJson_Sel;
         AV68Trn_pagewwds_10_tfpageispublished_sel = AV54TFPageIsPublished_Sel;
         AV69Trn_pagewwds_11_tfpageiscontentpage_sel = AV48TFPageIsContentPage_Sel;
         AV70Trn_pagewwds_12_tfpagechildren = AV55TFPageChildren;
         AV71Trn_pagewwds_13_tfpagechildren_sel = AV56TFPageChildren_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV40OrderedBy, AV13OrderedDsc, AV18ManageFiltersExecutionStep, AV52ColumnsSelector, AV58Pgmname, AV14FilterFullText, AV19TFTrn_PageName, AV20TFTrn_PageName_Sel, AV41TFPageJsonContent, AV42TFPageJsonContent_Sel, AV43TFPageGJSHtml, AV44TFPageGJSHtml_Sel, AV45TFPageGJSJson, AV46TFPageGJSJson_Sel, AV54TFPageIsPublished_Sel, AV48TFPageIsContentPage_Sel, AV55TFPageChildren, AV56TFPageChildren_Sel, AV30IsAuthorized_Display, AV32IsAuthorized_Update, AV34IsAuthorized_Delete, AV28IsAuthorized_Trn_PageName, AV35IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV59Trn_pagewwds_1_filterfulltext = AV14FilterFullText;
         AV60Trn_pagewwds_2_tftrn_pagename = AV19TFTrn_PageName;
         AV61Trn_pagewwds_3_tftrn_pagename_sel = AV20TFTrn_PageName_Sel;
         AV62Trn_pagewwds_4_tfpagejsoncontent = AV41TFPageJsonContent;
         AV63Trn_pagewwds_5_tfpagejsoncontent_sel = AV42TFPageJsonContent_Sel;
         AV64Trn_pagewwds_6_tfpagegjshtml = AV43TFPageGJSHtml;
         AV65Trn_pagewwds_7_tfpagegjshtml_sel = AV44TFPageGJSHtml_Sel;
         AV66Trn_pagewwds_8_tfpagegjsjson = AV45TFPageGJSJson;
         AV67Trn_pagewwds_9_tfpagegjsjson_sel = AV46TFPageGJSJson_Sel;
         AV68Trn_pagewwds_10_tfpageispublished_sel = AV54TFPageIsPublished_Sel;
         AV69Trn_pagewwds_11_tfpageiscontentpage_sel = AV48TFPageIsContentPage_Sel;
         AV70Trn_pagewwds_12_tfpagechildren = AV55TFPageChildren;
         AV71Trn_pagewwds_13_tfpagechildren_sel = AV56TFPageChildren_Sel;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV40OrderedBy, AV13OrderedDsc, AV18ManageFiltersExecutionStep, AV52ColumnsSelector, AV58Pgmname, AV14FilterFullText, AV19TFTrn_PageName, AV20TFTrn_PageName_Sel, AV41TFPageJsonContent, AV42TFPageJsonContent_Sel, AV43TFPageGJSHtml, AV44TFPageGJSHtml_Sel, AV45TFPageGJSJson, AV46TFPageGJSJson_Sel, AV54TFPageIsPublished_Sel, AV48TFPageIsContentPage_Sel, AV55TFPageChildren, AV56TFPageChildren_Sel, AV30IsAuthorized_Display, AV32IsAuthorized_Update, AV34IsAuthorized_Delete, AV28IsAuthorized_Trn_PageName, AV35IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV59Trn_pagewwds_1_filterfulltext = AV14FilterFullText;
         AV60Trn_pagewwds_2_tftrn_pagename = AV19TFTrn_PageName;
         AV61Trn_pagewwds_3_tftrn_pagename_sel = AV20TFTrn_PageName_Sel;
         AV62Trn_pagewwds_4_tfpagejsoncontent = AV41TFPageJsonContent;
         AV63Trn_pagewwds_5_tfpagejsoncontent_sel = AV42TFPageJsonContent_Sel;
         AV64Trn_pagewwds_6_tfpagegjshtml = AV43TFPageGJSHtml;
         AV65Trn_pagewwds_7_tfpagegjshtml_sel = AV44TFPageGJSHtml_Sel;
         AV66Trn_pagewwds_8_tfpagegjsjson = AV45TFPageGJSJson;
         AV67Trn_pagewwds_9_tfpagegjsjson_sel = AV46TFPageGJSJson_Sel;
         AV68Trn_pagewwds_10_tfpageispublished_sel = AV54TFPageIsPublished_Sel;
         AV69Trn_pagewwds_11_tfpageiscontentpage_sel = AV48TFPageIsContentPage_Sel;
         AV70Trn_pagewwds_12_tfpagechildren = AV55TFPageChildren;
         AV71Trn_pagewwds_13_tfpagechildren_sel = AV56TFPageChildren_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV40OrderedBy, AV13OrderedDsc, AV18ManageFiltersExecutionStep, AV52ColumnsSelector, AV58Pgmname, AV14FilterFullText, AV19TFTrn_PageName, AV20TFTrn_PageName_Sel, AV41TFPageJsonContent, AV42TFPageJsonContent_Sel, AV43TFPageGJSHtml, AV44TFPageGJSHtml_Sel, AV45TFPageGJSJson, AV46TFPageGJSJson_Sel, AV54TFPageIsPublished_Sel, AV48TFPageIsContentPage_Sel, AV55TFPageChildren, AV56TFPageChildren_Sel, AV30IsAuthorized_Display, AV32IsAuthorized_Update, AV34IsAuthorized_Delete, AV28IsAuthorized_Trn_PageName, AV35IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV59Trn_pagewwds_1_filterfulltext = AV14FilterFullText;
         AV60Trn_pagewwds_2_tftrn_pagename = AV19TFTrn_PageName;
         AV61Trn_pagewwds_3_tftrn_pagename_sel = AV20TFTrn_PageName_Sel;
         AV62Trn_pagewwds_4_tfpagejsoncontent = AV41TFPageJsonContent;
         AV63Trn_pagewwds_5_tfpagejsoncontent_sel = AV42TFPageJsonContent_Sel;
         AV64Trn_pagewwds_6_tfpagegjshtml = AV43TFPageGJSHtml;
         AV65Trn_pagewwds_7_tfpagegjshtml_sel = AV44TFPageGJSHtml_Sel;
         AV66Trn_pagewwds_8_tfpagegjsjson = AV45TFPageGJSJson;
         AV67Trn_pagewwds_9_tfpagegjsjson_sel = AV46TFPageGJSJson_Sel;
         AV68Trn_pagewwds_10_tfpageispublished_sel = AV54TFPageIsPublished_Sel;
         AV69Trn_pagewwds_11_tfpageiscontentpage_sel = AV48TFPageIsContentPage_Sel;
         AV70Trn_pagewwds_12_tfpagechildren = AV55TFPageChildren;
         AV71Trn_pagewwds_13_tfpagechildren_sel = AV56TFPageChildren_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV40OrderedBy, AV13OrderedDsc, AV18ManageFiltersExecutionStep, AV52ColumnsSelector, AV58Pgmname, AV14FilterFullText, AV19TFTrn_PageName, AV20TFTrn_PageName_Sel, AV41TFPageJsonContent, AV42TFPageJsonContent_Sel, AV43TFPageGJSHtml, AV44TFPageGJSHtml_Sel, AV45TFPageGJSJson, AV46TFPageGJSJson_Sel, AV54TFPageIsPublished_Sel, AV48TFPageIsContentPage_Sel, AV55TFPageChildren, AV56TFPageChildren_Sel, AV30IsAuthorized_Display, AV32IsAuthorized_Update, AV34IsAuthorized_Delete, AV28IsAuthorized_Trn_PageName, AV35IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV59Trn_pagewwds_1_filterfulltext = AV14FilterFullText;
         AV60Trn_pagewwds_2_tftrn_pagename = AV19TFTrn_PageName;
         AV61Trn_pagewwds_3_tftrn_pagename_sel = AV20TFTrn_PageName_Sel;
         AV62Trn_pagewwds_4_tfpagejsoncontent = AV41TFPageJsonContent;
         AV63Trn_pagewwds_5_tfpagejsoncontent_sel = AV42TFPageJsonContent_Sel;
         AV64Trn_pagewwds_6_tfpagegjshtml = AV43TFPageGJSHtml;
         AV65Trn_pagewwds_7_tfpagegjshtml_sel = AV44TFPageGJSHtml_Sel;
         AV66Trn_pagewwds_8_tfpagegjsjson = AV45TFPageGJSJson;
         AV67Trn_pagewwds_9_tfpagegjsjson_sel = AV46TFPageGJSJson_Sel;
         AV68Trn_pagewwds_10_tfpageispublished_sel = AV54TFPageIsPublished_Sel;
         AV69Trn_pagewwds_11_tfpageiscontentpage_sel = AV48TFPageIsContentPage_Sel;
         AV70Trn_pagewwds_12_tfpagechildren = AV55TFPageChildren;
         AV71Trn_pagewwds_13_tfpagechildren_sel = AV56TFPageChildren_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV40OrderedBy, AV13OrderedDsc, AV18ManageFiltersExecutionStep, AV52ColumnsSelector, AV58Pgmname, AV14FilterFullText, AV19TFTrn_PageName, AV20TFTrn_PageName_Sel, AV41TFPageJsonContent, AV42TFPageJsonContent_Sel, AV43TFPageGJSHtml, AV44TFPageGJSHtml_Sel, AV45TFPageGJSJson, AV46TFPageGJSJson_Sel, AV54TFPageIsPublished_Sel, AV48TFPageIsContentPage_Sel, AV55TFPageChildren, AV56TFPageChildren_Sel, AV30IsAuthorized_Display, AV32IsAuthorized_Update, AV34IsAuthorized_Delete, AV28IsAuthorized_Trn_PageName, AV35IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV58Pgmname = "Trn_PageWW";
         edtTrn_PageId_Enabled = 0;
         edtTrn_PageName_Enabled = 0;
         edtLocationId_Enabled = 0;
         edtPageJsonContent_Enabled = 0;
         edtPageGJSHtml_Enabled = 0;
         edtPageGJSJson_Enabled = 0;
         chkPageIsPublished.Enabled = 0;
         cmbPageIsContentPage.Enabled = 0;
         edtPageChildren_Enabled = 0;
         edtProductServiceId_Enabled = 0;
         edtOrganisationId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP720( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E18722 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV16ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV21DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV52ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_39 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_39"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV25GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV26GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV27GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Hascolumnsselector = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hascolumnsselector"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV14FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV14FilterFullText", AV14FilterFullText);
            /* Read subfile selected row values. */
            nGXsfl_39_idx = (int)(Math.Round(context.localUtil.CToN( cgiGet( subGrid_Internalname+"_ROW"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
            if ( nGXsfl_39_idx > 0 )
            {
               A392Trn_PageId = StringUtil.StrToGuid( cgiGet( edtTrn_PageId_Internalname));
               A397Trn_PageName = cgiGet( edtTrn_PageName_Internalname);
               A29LocationId = StringUtil.StrToGuid( cgiGet( edtLocationId_Internalname));
               A420PageJsonContent = cgiGet( edtPageJsonContent_Internalname);
               n420PageJsonContent = false;
               A421PageGJSHtml = cgiGet( edtPageGJSHtml_Internalname);
               n421PageGJSHtml = false;
               A422PageGJSJson = cgiGet( edtPageGJSJson_Internalname);
               n422PageGJSJson = false;
               A423PageIsPublished = StringUtil.StrToBool( cgiGet( chkPageIsPublished_Internalname));
               n423PageIsPublished = false;
               cmbPageIsContentPage.Name = cmbPageIsContentPage_Internalname;
               cmbPageIsContentPage.CurrentValue = cgiGet( cmbPageIsContentPage_Internalname);
               A429PageIsContentPage = StringUtil.StrToBool( cgiGet( cmbPageIsContentPage_Internalname));
               n429PageIsContentPage = false;
               A424PageChildren = cgiGet( edtPageChildren_Internalname);
               n424PageChildren = false;
               A58ProductServiceId = StringUtil.StrToGuid( cgiGet( edtProductServiceId_Internalname));
               n58ProductServiceId = false;
               A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
               cmbavActiongroup.Name = cmbavActiongroup_Internalname;
               cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
               AV47ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV47ActionGroup), 4, 0));
            }
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV40OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV13OrderedDsc )
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
         E18722 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E18722( )
      {
         /* Start Routine */
         returnInSub = false;
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
         GXt_boolean1 = AV28IsAuthorized_Trn_PageName;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_pageview_Execute", out  GXt_boolean1) ;
         AV28IsAuthorized_Trn_PageName = GXt_boolean1;
         AssignAttri("", false, "AV28IsAuthorized_Trn_PageName", AV28IsAuthorized_Trn_PageName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_TRN_PAGENAME", GetSecureSignedToken( "", AV28IsAuthorized_Trn_PageName, context));
         AV22GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV23GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV22GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = context.GetMessage( " App builder pages", "");
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
         if ( AV40OrderedBy < 1 )
         {
            AV40OrderedBy = 1;
            AssignAttri("", false, "AV40OrderedBy", StringUtil.LTrimStr( (decimal)(AV40OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV21DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV21DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E19722( )
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
         if ( AV18ManageFiltersExecutionStep == 1 )
         {
            AV18ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV18ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV18ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV18ManageFiltersExecutionStep == 2 )
         {
            AV18ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV18ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV18ManageFiltersExecutionStep), 1, 0));
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
         if ( StringUtil.StrCmp(AV15Session.Get("Trn_PageWWColumnsSelector"), "") != 0 )
         {
            AV50ColumnsSelectorXML = AV15Session.Get("Trn_PageWWColumnsSelector");
            AV52ColumnsSelector.FromXml(AV50ColumnsSelectorXML, null, "", "");
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
         edtTrn_PageId_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV52ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtTrn_PageId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrn_PageId_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtTrn_PageName_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV52ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtTrn_PageName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrn_PageName_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtLocationId_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV52ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtLocationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLocationId_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtPageJsonContent_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV52ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtPageJsonContent_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPageJsonContent_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtPageGJSHtml_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV52ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtPageGJSHtml_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPageGJSHtml_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtPageGJSJson_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV52ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtPageGJSJson_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPageGJSJson_Visible), 5, 0), !bGXsfl_39_Refreshing);
         chkPageIsPublished.Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV52ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, chkPageIsPublished_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkPageIsPublished.Visible), 5, 0), !bGXsfl_39_Refreshing);
         cmbPageIsContentPage.Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV52ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbPageIsContentPage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbPageIsContentPage.Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtPageChildren_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV52ColumnsSelector.gxTpr_Columns.Item(9)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtPageChildren_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPageChildren_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtProductServiceId_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV52ColumnsSelector.gxTpr_Columns.Item(10)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProductServiceId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtOrganisationId_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV52ColumnsSelector.gxTpr_Columns.Item(11)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtOrganisationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Visible), 5, 0), !bGXsfl_39_Refreshing);
         AV25GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV25GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV25GridCurrentPage), 10, 0));
         AV26GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV26GridPageCount", StringUtil.LTrimStr( (decimal)(AV26GridPageCount), 10, 0));
         GXt_char3 = AV27GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV58Pgmname, out  GXt_char3) ;
         AV27GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV27GridAppliedFilters", AV27GridAppliedFilters);
         AV59Trn_pagewwds_1_filterfulltext = AV14FilterFullText;
         AV60Trn_pagewwds_2_tftrn_pagename = AV19TFTrn_PageName;
         AV61Trn_pagewwds_3_tftrn_pagename_sel = AV20TFTrn_PageName_Sel;
         AV62Trn_pagewwds_4_tfpagejsoncontent = AV41TFPageJsonContent;
         AV63Trn_pagewwds_5_tfpagejsoncontent_sel = AV42TFPageJsonContent_Sel;
         AV64Trn_pagewwds_6_tfpagegjshtml = AV43TFPageGJSHtml;
         AV65Trn_pagewwds_7_tfpagegjshtml_sel = AV44TFPageGJSHtml_Sel;
         AV66Trn_pagewwds_8_tfpagegjsjson = AV45TFPageGJSJson;
         AV67Trn_pagewwds_9_tfpagegjsjson_sel = AV46TFPageGJSJson_Sel;
         AV68Trn_pagewwds_10_tfpageispublished_sel = AV54TFPageIsPublished_Sel;
         AV69Trn_pagewwds_11_tfpageiscontentpage_sel = AV48TFPageIsContentPage_Sel;
         AV70Trn_pagewwds_12_tfpagechildren = AV55TFPageChildren;
         AV71Trn_pagewwds_13_tfpagechildren_sel = AV56TFPageChildren_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV52ColumnsSelector", AV52ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV16ManageFiltersData", AV16ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E12722( )
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
            AV24PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV24PageToGo) ;
         }
      }

      protected void E13722( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E15722( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV40OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV40OrderedBy", StringUtil.LTrimStr( (decimal)(AV40OrderedBy), 4, 0));
            AV13OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV13OrderedDsc", AV13OrderedDsc);
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "Trn_PageName") == 0 )
            {
               AV19TFTrn_PageName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV19TFTrn_PageName", AV19TFTrn_PageName);
               AV20TFTrn_PageName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV20TFTrn_PageName_Sel", AV20TFTrn_PageName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PageJsonContent") == 0 )
            {
               AV41TFPageJsonContent = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV41TFPageJsonContent", AV41TFPageJsonContent);
               AV42TFPageJsonContent_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV42TFPageJsonContent_Sel", AV42TFPageJsonContent_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PageGJSHtml") == 0 )
            {
               AV43TFPageGJSHtml = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV43TFPageGJSHtml", AV43TFPageGJSHtml);
               AV44TFPageGJSHtml_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV44TFPageGJSHtml_Sel", AV44TFPageGJSHtml_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PageGJSJson") == 0 )
            {
               AV45TFPageGJSJson = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV45TFPageGJSJson", AV45TFPageGJSJson);
               AV46TFPageGJSJson_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV46TFPageGJSJson_Sel", AV46TFPageGJSJson_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PageIsPublished") == 0 )
            {
               AV54TFPageIsPublished_Sel = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV54TFPageIsPublished_Sel", StringUtil.Str( (decimal)(AV54TFPageIsPublished_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PageIsContentPage") == 0 )
            {
               AV48TFPageIsContentPage_Sel = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV48TFPageIsContentPage_Sel", StringUtil.Str( (decimal)(AV48TFPageIsContentPage_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PageChildren") == 0 )
            {
               AV55TFPageChildren = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV55TFPageChildren", AV55TFPageChildren);
               AV56TFPageChildren_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV56TFPageChildren_Sel", AV56TFPageChildren_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E20722( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            cmbavActiongroup.removeAllItems();
            cmbavActiongroup.addItem("0", ";fas fa-bars", 0);
            if ( AV30IsAuthorized_Display )
            {
               cmbavActiongroup.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
            }
            if ( AV32IsAuthorized_Update )
            {
               cmbavActiongroup.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "Edit", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
            }
            if ( AV34IsAuthorized_Delete )
            {
               cmbavActiongroup.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "fa fa-times", "", "", "", "", "", "", ""), 0);
            }
            if ( cmbavActiongroup.ItemCount == 1 )
            {
               cmbavActiongroup_Class = "Invisible";
            }
            else
            {
               cmbavActiongroup_Class = "ConvertToDDO";
            }
            if ( AV28IsAuthorized_Trn_PageName )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "trn_pageview.aspx"+UrlEncode(A392Trn_PageId.ToString()) + "," + UrlEncode(A29LocationId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
               edtTrn_PageName_Link = formatLink("trn_pageview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV47ActionGroup), 4, 0));
      }

      protected void E16722( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV50ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV52ColumnsSelector.FromJSonString(AV50ColumnsSelectorXML, null);
         new WorkWithPlus.workwithplus_web.savecolumnsselectorstate(context ).execute(  "Trn_PageWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV50ColumnsSelectorXML)) ? "" : AV52ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV52ColumnsSelector", AV52ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV16ManageFiltersData", AV16ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E11722( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("Trn_PageWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV58Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV18ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV18ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV18ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("Trn_PageWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV18ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV18ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV18ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV17ManageFiltersXml;
            new WorkWithPlus.workwithplus_web.getfilterbyname(context ).execute(  "Trn_PageWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV17ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17ManageFiltersXml)) )
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
               new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV58Pgmname+"GridState",  AV17ManageFiltersXml) ;
               AV11GridState.FromXml(AV17ManageFiltersXml, null, "", "");
               AV40OrderedBy = AV11GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV40OrderedBy", StringUtil.LTrimStr( (decimal)(AV40OrderedBy), 4, 0));
               AV13OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV13OrderedDsc", AV13OrderedDsc);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV52ColumnsSelector", AV52ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV16ManageFiltersData", AV16ManageFiltersData);
      }

      protected void E21722( )
      {
         /* Actiongroup_Click Routine */
         returnInSub = false;
         if ( AV47ActionGroup == 1 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV47ActionGroup == 2 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV47ActionGroup == 3 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV47ActionGroup = 0;
         AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV47ActionGroup), 4, 0));
         /*  Sending Event outputs  */
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV47ActionGroup), 4, 0));
         AssignProp("", false, cmbavActiongroup_Internalname, "Values", cmbavActiongroup.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV52ColumnsSelector", AV52ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV16ManageFiltersData", AV16ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E17722( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV35IsAuthorized_Insert )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_page.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(Guid.Empty.ToString()) + "," + UrlEncode(Guid.Empty.ToString());
            CallWebObject(formatLink("trn_page.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV52ColumnsSelector", AV52ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV16ManageFiltersData", AV16ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E14722( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0063",(string)"",(string)"Trn_Page",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0063"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV40OrderedBy), 4, 0))+":"+(AV13OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S172( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV52ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV52ColumnsSelector,  "Trn_PageId",  "",  "Id",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV52ColumnsSelector,  "Trn_PageName",  "",  "Name",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV52ColumnsSelector,  "LocationId",  "",  "Location Id",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV52ColumnsSelector,  "PageJsonContent",  "",  "Json Content",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV52ColumnsSelector,  "PageGJSHtml",  "",  "GJSHtml",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV52ColumnsSelector,  "PageGJSJson",  "",  "GJSJson",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV52ColumnsSelector,  "PageIsPublished",  "",  "Is Published",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV52ColumnsSelector,  "PageIsContentPage",  "",  "Content Page",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV52ColumnsSelector,  "PageChildren",  "",  "Children",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV52ColumnsSelector,  "ProductServiceId",  "",  "Product Service Id",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV52ColumnsSelector,  "OrganisationId",  "",  "Organisation Id",  true,  "") ;
         GXt_char3 = AV51UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "Trn_PageWWColumnsSelector", out  GXt_char3) ;
         AV51UserCustomValue = GXt_char3;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV51UserCustomValue)) ) )
         {
            AV53ColumnsSelectorAux.FromXml(AV51UserCustomValue, null, "", "");
            new WorkWithPlus.workwithplus_web.wwp_columnselector_updatecolumns(context ).execute( ref  AV53ColumnsSelectorAux, ref  AV52ColumnsSelector) ;
         }
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV30IsAuthorized_Display;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_pageview_Execute", out  GXt_boolean1) ;
         AV30IsAuthorized_Display = GXt_boolean1;
         AssignAttri("", false, "AV30IsAuthorized_Display", AV30IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV30IsAuthorized_Display, context));
         GXt_boolean1 = AV32IsAuthorized_Update;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_page_Update", out  GXt_boolean1) ;
         AV32IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV32IsAuthorized_Update", AV32IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV32IsAuthorized_Update, context));
         GXt_boolean1 = AV34IsAuthorized_Delete;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_page_Delete", out  GXt_boolean1) ;
         AV34IsAuthorized_Delete = GXt_boolean1;
         AssignAttri("", false, "AV34IsAuthorized_Delete", AV34IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV34IsAuthorized_Delete, context));
         GXt_boolean1 = AV35IsAuthorized_Insert;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_page_Insert", out  GXt_boolean1) ;
         AV35IsAuthorized_Insert = GXt_boolean1;
         AssignAttri("", false, "AV35IsAuthorized_Insert", AV35IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV35IsAuthorized_Insert, context));
         if ( ! ( AV35IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
         if ( ! ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "Trn_Page",  1) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV16ManageFiltersData;
         new WorkWithPlus.workwithplus_web.wwp_managefiltersloadsavedfilters(context ).execute(  "Trn_PageWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV16ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S182( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV14FilterFullText = "";
         AssignAttri("", false, "AV14FilterFullText", AV14FilterFullText);
         AV19TFTrn_PageName = "";
         AssignAttri("", false, "AV19TFTrn_PageName", AV19TFTrn_PageName);
         AV20TFTrn_PageName_Sel = "";
         AssignAttri("", false, "AV20TFTrn_PageName_Sel", AV20TFTrn_PageName_Sel);
         AV41TFPageJsonContent = "";
         AssignAttri("", false, "AV41TFPageJsonContent", AV41TFPageJsonContent);
         AV42TFPageJsonContent_Sel = "";
         AssignAttri("", false, "AV42TFPageJsonContent_Sel", AV42TFPageJsonContent_Sel);
         AV43TFPageGJSHtml = "";
         AssignAttri("", false, "AV43TFPageGJSHtml", AV43TFPageGJSHtml);
         AV44TFPageGJSHtml_Sel = "";
         AssignAttri("", false, "AV44TFPageGJSHtml_Sel", AV44TFPageGJSHtml_Sel);
         AV45TFPageGJSJson = "";
         AssignAttri("", false, "AV45TFPageGJSJson", AV45TFPageGJSJson);
         AV46TFPageGJSJson_Sel = "";
         AssignAttri("", false, "AV46TFPageGJSJson_Sel", AV46TFPageGJSJson_Sel);
         AV54TFPageIsPublished_Sel = 0;
         AssignAttri("", false, "AV54TFPageIsPublished_Sel", StringUtil.Str( (decimal)(AV54TFPageIsPublished_Sel), 1, 0));
         AV48TFPageIsContentPage_Sel = 0;
         AssignAttri("", false, "AV48TFPageIsContentPage_Sel", StringUtil.Str( (decimal)(AV48TFPageIsContentPage_Sel), 1, 0));
         AV55TFPageChildren = "";
         AssignAttri("", false, "AV55TFPageChildren", AV55TFPageChildren);
         AV56TFPageChildren_Sel = "";
         AssignAttri("", false, "AV56TFPageChildren_Sel", AV56TFPageChildren_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S202( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         if ( AV30IsAuthorized_Display )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_pageview.aspx"+UrlEncode(A392Trn_PageId.ToString()) + "," + UrlEncode(A29LocationId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            CallWebObject(formatLink("trn_pageview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
         if ( AV32IsAuthorized_Update )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_page.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(A392Trn_PageId.ToString()) + "," + UrlEncode(A29LocationId.ToString());
            CallWebObject(formatLink("trn_page.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
         if ( AV34IsAuthorized_Delete )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_page.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(A392Trn_PageId.ToString()) + "," + UrlEncode(A29LocationId.ToString());
            CallWebObject(formatLink("trn_page.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
         if ( StringUtil.StrCmp(AV15Session.Get(AV58Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV58Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV15Session.Get(AV58Pgmname+"GridState"), null, "", "");
         }
         AV40OrderedBy = AV11GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV40OrderedBy", StringUtil.LTrimStr( (decimal)(AV40OrderedBy), 4, 0));
         AV13OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV13OrderedDsc", AV13OrderedDsc);
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
         AV72GXV1 = 1;
         while ( AV72GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV72GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV14FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV14FilterFullText", AV14FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTRN_PAGENAME") == 0 )
            {
               AV19TFTrn_PageName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV19TFTrn_PageName", AV19TFTrn_PageName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTRN_PAGENAME_SEL") == 0 )
            {
               AV20TFTrn_PageName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV20TFTrn_PageName_Sel", AV20TFTrn_PageName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPAGEJSONCONTENT") == 0 )
            {
               AV41TFPageJsonContent = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV41TFPageJsonContent", AV41TFPageJsonContent);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPAGEJSONCONTENT_SEL") == 0 )
            {
               AV42TFPageJsonContent_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42TFPageJsonContent_Sel", AV42TFPageJsonContent_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPAGEGJSHTML") == 0 )
            {
               AV43TFPageGJSHtml = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV43TFPageGJSHtml", AV43TFPageGJSHtml);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPAGEGJSHTML_SEL") == 0 )
            {
               AV44TFPageGJSHtml_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV44TFPageGJSHtml_Sel", AV44TFPageGJSHtml_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPAGEGJSJSON") == 0 )
            {
               AV45TFPageGJSJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV45TFPageGJSJson", AV45TFPageGJSJson);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPAGEGJSJSON_SEL") == 0 )
            {
               AV46TFPageGJSJson_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV46TFPageGJSJson_Sel", AV46TFPageGJSJson_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPAGEISPUBLISHED_SEL") == 0 )
            {
               AV54TFPageIsPublished_Sel = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV54TFPageIsPublished_Sel", StringUtil.Str( (decimal)(AV54TFPageIsPublished_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPAGEISCONTENTPAGE_SEL") == 0 )
            {
               AV48TFPageIsContentPage_Sel = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV48TFPageIsContentPage_Sel", StringUtil.Str( (decimal)(AV48TFPageIsContentPage_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPAGECHILDREN") == 0 )
            {
               AV55TFPageChildren = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV55TFPageChildren", AV55TFPageChildren);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPAGECHILDREN_SEL") == 0 )
            {
               AV56TFPageChildren_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV56TFPageChildren_Sel", AV56TFPageChildren_Sel);
            }
            AV72GXV1 = (int)(AV72GXV1+1);
         }
         GXt_char3 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV20TFTrn_PageName_Sel)),  AV20TFTrn_PageName_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFPageJsonContent_Sel)),  AV42TFPageJsonContent_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV44TFPageGJSHtml_Sel)),  AV44TFPageGJSHtml_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV46TFPageGJSJson_Sel)),  AV46TFPageGJSJson_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV56TFPageChildren_Sel)),  AV56TFPageChildren_Sel, out  GXt_char8) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char3+"||"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|"+((0==AV54TFPageIsPublished_Sel) ? "" : StringUtil.Str( (decimal)(AV54TFPageIsPublished_Sel), 1, 0))+"|"+((0==AV48TFPageIsContentPage_Sel) ? "" : StringUtil.Str( (decimal)(AV48TFPageIsContentPage_Sel), 1, 0))+"|"+GXt_char8+"||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char8 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV19TFTrn_PageName)),  AV19TFTrn_PageName, out  GXt_char8) ;
         GXt_char7 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV41TFPageJsonContent)),  AV41TFPageJsonContent, out  GXt_char7) ;
         GXt_char6 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV43TFPageGJSHtml)),  AV43TFPageGJSHtml, out  GXt_char6) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV45TFPageGJSJson)),  AV45TFPageGJSJson, out  GXt_char5) ;
         GXt_char3 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV55TFPageChildren)),  AV55TFPageChildren, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = "|"+GXt_char8+"||"+GXt_char7+"|"+GXt_char6+"|"+GXt_char5+"|||"+GXt_char3+"||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV15Session.Get(AV58Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV40OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV13OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV14FilterFullText)),  0,  AV14FilterFullText,  AV14FilterFullText,  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFTRN_PAGENAME",  context.GetMessage( "Name", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV19TFTrn_PageName)),  0,  AV19TFTrn_PageName,  AV19TFTrn_PageName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV20TFTrn_PageName_Sel)),  AV20TFTrn_PageName_Sel,  AV20TFTrn_PageName_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPAGEJSONCONTENT",  context.GetMessage( "Json Content", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV41TFPageJsonContent)),  0,  AV41TFPageJsonContent,  AV41TFPageJsonContent,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFPageJsonContent_Sel)),  AV42TFPageJsonContent_Sel,  AV42TFPageJsonContent_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPAGEGJSHTML",  context.GetMessage( "GJSHtml", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV43TFPageGJSHtml)),  0,  AV43TFPageGJSHtml,  AV43TFPageGJSHtml,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV44TFPageGJSHtml_Sel)),  AV44TFPageGJSHtml_Sel,  AV44TFPageGJSHtml_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPAGEGJSJSON",  context.GetMessage( "GJSJson", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV45TFPageGJSJson)),  0,  AV45TFPageGJSJson,  AV45TFPageGJSJson,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV46TFPageGJSJson_Sel)),  AV46TFPageGJSJson_Sel,  AV46TFPageGJSJson_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFPAGEISPUBLISHED_SEL",  context.GetMessage( "Is Published", ""),  !(0==AV54TFPageIsPublished_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV54TFPageIsPublished_Sel), 1, 0)),  ((AV54TFPageIsPublished_Sel==1) ? context.GetMessage( "WWP_TSChecked", "") : context.GetMessage( "WWP_TSUnChecked", "")),  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFPAGEISCONTENTPAGE_SEL",  context.GetMessage( "Content Page", ""),  !(0==AV48TFPageIsContentPage_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV48TFPageIsContentPage_Sel), 1, 0)),  ((AV48TFPageIsContentPage_Sel==1) ? context.GetMessage( "WWP_TSChecked", "") : context.GetMessage( "WWP_TSUnChecked", "")),  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPAGECHILDREN",  context.GetMessage( "Children", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV55TFPageChildren)),  0,  AV55TFPageChildren,  AV55TFPageChildren,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV56TFPageChildren_Sel)),  AV56TFPageChildren_Sel,  AV56TFPageChildren_Sel) ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV58Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV58Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Trn_Page";
         AV15Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
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
         PA722( ) ;
         WS722( ) ;
         WE722( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20257212571247", true, true);
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
         context.AddJavascriptSource("trn_pageww.js", "?20257212571250", false, true);
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
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_392( )
      {
         edtTrn_PageId_Internalname = "TRN_PAGEID_"+sGXsfl_39_idx;
         edtTrn_PageName_Internalname = "TRN_PAGENAME_"+sGXsfl_39_idx;
         edtLocationId_Internalname = "LOCATIONID_"+sGXsfl_39_idx;
         edtPageJsonContent_Internalname = "PAGEJSONCONTENT_"+sGXsfl_39_idx;
         edtPageGJSHtml_Internalname = "PAGEGJSHTML_"+sGXsfl_39_idx;
         edtPageGJSJson_Internalname = "PAGEGJSJSON_"+sGXsfl_39_idx;
         chkPageIsPublished_Internalname = "PAGEISPUBLISHED_"+sGXsfl_39_idx;
         cmbPageIsContentPage_Internalname = "PAGEISCONTENTPAGE_"+sGXsfl_39_idx;
         edtPageChildren_Internalname = "PAGECHILDREN_"+sGXsfl_39_idx;
         edtProductServiceId_Internalname = "PRODUCTSERVICEID_"+sGXsfl_39_idx;
         edtOrganisationId_Internalname = "ORGANISATIONID_"+sGXsfl_39_idx;
         cmbavActiongroup_Internalname = "vACTIONGROUP_"+sGXsfl_39_idx;
      }

      protected void SubsflControlProps_fel_392( )
      {
         edtTrn_PageId_Internalname = "TRN_PAGEID_"+sGXsfl_39_fel_idx;
         edtTrn_PageName_Internalname = "TRN_PAGENAME_"+sGXsfl_39_fel_idx;
         edtLocationId_Internalname = "LOCATIONID_"+sGXsfl_39_fel_idx;
         edtPageJsonContent_Internalname = "PAGEJSONCONTENT_"+sGXsfl_39_fel_idx;
         edtPageGJSHtml_Internalname = "PAGEGJSHTML_"+sGXsfl_39_fel_idx;
         edtPageGJSJson_Internalname = "PAGEGJSJSON_"+sGXsfl_39_fel_idx;
         chkPageIsPublished_Internalname = "PAGEISPUBLISHED_"+sGXsfl_39_fel_idx;
         cmbPageIsContentPage_Internalname = "PAGEISCONTENTPAGE_"+sGXsfl_39_fel_idx;
         edtPageChildren_Internalname = "PAGECHILDREN_"+sGXsfl_39_fel_idx;
         edtProductServiceId_Internalname = "PRODUCTSERVICEID_"+sGXsfl_39_fel_idx;
         edtOrganisationId_Internalname = "ORGANISATIONID_"+sGXsfl_39_fel_idx;
         cmbavActiongroup_Internalname = "vACTIONGROUP_"+sGXsfl_39_fel_idx;
      }

      protected void sendrow_392( )
      {
         sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
         SubsflControlProps_392( ) ;
         WB720( ) ;
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtTrn_PageId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTrn_PageId_Internalname,A392Trn_PageId.ToString(),A392Trn_PageId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTrn_PageId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtTrn_PageId_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)39,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtTrn_PageName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTrn_PageName_Internalname,(string)A397Trn_PageName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtTrn_PageName_Link,(string)"",(string)"",(string)"",(string)edtTrn_PageName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtTrn_PageName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtLocationId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLocationId_Internalname,A29LocationId.ToString(),A29LocationId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLocationId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtLocationId_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)39,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtPageJsonContent_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPageJsonContent_Internalname,(string)A420PageJsonContent,(string)A420PageJsonContent,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPageJsonContent_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtPageJsonContent_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)39,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtPageGJSHtml_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPageGJSHtml_Internalname,(string)A421PageGJSHtml,(string)A421PageGJSHtml,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPageGJSHtml_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtPageGJSHtml_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)1,(short)39,(short)0,(short)0,(short)-1,(bool)true,(string)"GeneXus\\Html",(string)"start",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtPageGJSJson_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPageGJSJson_Internalname,(string)A422PageGJSJson,(string)A422PageGJSJson,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPageGJSJson_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtPageGJSJson_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)39,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkPageIsPublished.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "PAGEISPUBLISHED_" + sGXsfl_39_idx;
            chkPageIsPublished.Name = GXCCtl;
            chkPageIsPublished.WebTags = "";
            chkPageIsPublished.Caption = "";
            AssignProp("", false, chkPageIsPublished_Internalname, "TitleCaption", chkPageIsPublished.Caption, !bGXsfl_39_Refreshing);
            chkPageIsPublished.CheckedValue = "false";
            A423PageIsPublished = StringUtil.StrToBool( StringUtil.BoolToStr( A423PageIsPublished));
            n423PageIsPublished = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkPageIsPublished_Internalname,StringUtil.BoolToStr( A423PageIsPublished),(string)"",(string)"",chkPageIsPublished.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn hidden-xs",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((cmbPageIsContentPage.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( cmbPageIsContentPage.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "PAGEISCONTENTPAGE_" + sGXsfl_39_idx;
               cmbPageIsContentPage.Name = GXCCtl;
               cmbPageIsContentPage.WebTags = "";
               cmbPageIsContentPage.addItem(StringUtil.BoolToStr( true), context.GetMessage( "true", ""), 0);
               cmbPageIsContentPage.addItem(StringUtil.BoolToStr( false), context.GetMessage( "false", ""), 0);
               if ( cmbPageIsContentPage.ItemCount > 0 )
               {
                  A429PageIsContentPage = StringUtil.StrToBool( cmbPageIsContentPage.getValidValue(StringUtil.BoolToStr( A429PageIsContentPage)));
                  n429PageIsContentPage = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbPageIsContentPage,(string)cmbPageIsContentPage_Internalname,StringUtil.BoolToStr( A429PageIsContentPage),(short)1,(string)cmbPageIsContentPage_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"boolean",(string)"",cmbPageIsContentPage.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbPageIsContentPage.CurrentValue = StringUtil.BoolToStr( A429PageIsContentPage);
            AssignProp("", false, cmbPageIsContentPage_Internalname, "Values", (string)(cmbPageIsContentPage.ToJavascriptSource()), !bGXsfl_39_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtPageChildren_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPageChildren_Internalname,(string)A424PageChildren,(string)A424PageChildren,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPageChildren_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtPageChildren_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)39,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtProductServiceId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductServiceId_Internalname,A58ProductServiceId.ToString(),A58ProductServiceId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductServiceId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtProductServiceId_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)39,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtOrganisationId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrganisationId_Internalname,A11OrganisationId.ToString(),A11OrganisationId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOrganisationId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtOrganisationId_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)39,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_39_idx + "',39)\"";
            if ( ( cmbavActiongroup.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vACTIONGROUP_" + sGXsfl_39_idx;
               cmbavActiongroup.Name = GXCCtl;
               cmbavActiongroup.WebTags = "";
               if ( cmbavActiongroup.ItemCount > 0 )
               {
                  AV47ActionGroup = (short)(Math.Round(NumberUtil.Val( cmbavActiongroup.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV47ActionGroup), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV47ActionGroup), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavActiongroup,(string)cmbavActiongroup_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV47ActionGroup), 4, 0)),(short)1,(string)cmbavActiongroup_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVACTIONGROUP.CLICK."+sGXsfl_39_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)cmbavActiongroup_Class,(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"",(string)"",(bool)true,(short)0});
            cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV47ActionGroup), 4, 0));
            AssignProp("", false, cmbavActiongroup_Internalname, "Values", (string)(cmbavActiongroup.ToJavascriptSource()), !bGXsfl_39_Refreshing);
            send_integrity_lvl_hashes722( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_39_idx = ((subGrid_Islastpage==1)&&(nGXsfl_39_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_39_idx+1);
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
         }
         /* End function sendrow_392 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "PAGEISPUBLISHED_" + sGXsfl_39_idx;
         chkPageIsPublished.Name = GXCCtl;
         chkPageIsPublished.WebTags = "";
         chkPageIsPublished.Caption = "";
         AssignProp("", false, chkPageIsPublished_Internalname, "TitleCaption", chkPageIsPublished.Caption, !bGXsfl_39_Refreshing);
         chkPageIsPublished.CheckedValue = "false";
         A423PageIsPublished = StringUtil.StrToBool( StringUtil.BoolToStr( A423PageIsPublished));
         n423PageIsPublished = false;
         GXCCtl = "PAGEISCONTENTPAGE_" + sGXsfl_39_idx;
         cmbPageIsContentPage.Name = GXCCtl;
         cmbPageIsContentPage.WebTags = "";
         cmbPageIsContentPage.addItem(StringUtil.BoolToStr( true), context.GetMessage( "true", ""), 0);
         cmbPageIsContentPage.addItem(StringUtil.BoolToStr( false), context.GetMessage( "false", ""), 0);
         if ( cmbPageIsContentPage.ItemCount > 0 )
         {
            A429PageIsContentPage = StringUtil.StrToBool( cmbPageIsContentPage.getValidValue(StringUtil.BoolToStr( A429PageIsContentPage)));
            n429PageIsContentPage = false;
         }
         GXCCtl = "vACTIONGROUP_" + sGXsfl_39_idx;
         cmbavActiongroup.Name = GXCCtl;
         cmbavActiongroup.WebTags = "";
         if ( cmbavActiongroup.ItemCount > 0 )
         {
            AV47ActionGroup = (short)(Math.Round(NumberUtil.Val( cmbavActiongroup.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV47ActionGroup), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV47ActionGroup), 4, 0));
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
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtTrn_PageId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtTrn_PageName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtLocationId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Location Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtPageJsonContent_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Json Content", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtPageGJSHtml_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "GJSHtml", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtPageGJSJson_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "GJSJson", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+((chkPageIsPublished.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Is Published", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbPageIsContentPage.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Content Page", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtPageChildren_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Children", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtProductServiceId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Product Service Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtOrganisationId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Organisation Id", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A392Trn_PageId.ToString()));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrn_PageId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A397Trn_PageName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtTrn_PageName_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTrn_PageName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A29LocationId.ToString()));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLocationId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A420PageJsonContent));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageJsonContent_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A421PageGJSHtml));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageGJSHtml_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A422PageGJSJson));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageGJSJson_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A423PageIsPublished)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkPageIsPublished.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A429PageIsContentPage)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbPageIsContentPage.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A424PageChildren));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageChildren_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A58ProductServiceId.ToString()));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A11OrganisationId.ToString()));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOrganisationId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47ActionGroup), 4, 0, ".", ""))));
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
         bttBtninsert_Internalname = "BTNINSERT";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         bttBtnsubscriptions_Internalname = "BTNSUBSCRIPTIONS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtTrn_PageId_Internalname = "TRN_PAGEID";
         edtTrn_PageName_Internalname = "TRN_PAGENAME";
         edtLocationId_Internalname = "LOCATIONID";
         edtPageJsonContent_Internalname = "PAGEJSONCONTENT";
         edtPageGJSHtml_Internalname = "PAGEGJSHTML";
         edtPageGJSJson_Internalname = "PAGEGJSJSON";
         chkPageIsPublished_Internalname = "PAGEISPUBLISHED";
         cmbPageIsContentPage_Internalname = "PAGEISCONTENTPAGE";
         edtPageChildren_Internalname = "PAGECHILDREN";
         edtProductServiceId_Internalname = "PRODUCTSERVICEID";
         edtOrganisationId_Internalname = "ORGANISATIONID";
         cmbavActiongroup_Internalname = "vACTIONGROUP";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddc_subscriptions_Internalname = "DDC_SUBSCRIPTIONS";
         Ddo_grid_Internalname = "DDO_GRID";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
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
         edtOrganisationId_Jsonclick = "";
         edtProductServiceId_Jsonclick = "";
         edtPageChildren_Jsonclick = "";
         cmbPageIsContentPage_Jsonclick = "";
         chkPageIsPublished.Caption = "";
         edtPageGJSJson_Jsonclick = "";
         edtPageGJSHtml_Jsonclick = "";
         edtPageJsonContent_Jsonclick = "";
         edtLocationId_Jsonclick = "";
         edtTrn_PageName_Jsonclick = "";
         edtTrn_PageName_Link = "";
         edtTrn_PageId_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWithSelection WorkWith";
         subGrid_Backcolorstyle = 0;
         edtOrganisationId_Visible = -1;
         edtProductServiceId_Visible = -1;
         edtPageChildren_Visible = -1;
         cmbPageIsContentPage.Visible = -1;
         chkPageIsPublished.Visible = -1;
         edtPageGJSJson_Visible = -1;
         edtPageGJSHtml_Visible = -1;
         edtPageJsonContent_Visible = -1;
         edtLocationId_Visible = -1;
         edtTrn_PageName_Visible = -1;
         edtTrn_PageId_Visible = -1;
         edtOrganisationId_Enabled = 0;
         edtProductServiceId_Enabled = 0;
         edtPageChildren_Enabled = 0;
         cmbPageIsContentPage.Enabled = 0;
         chkPageIsPublished.Enabled = 0;
         edtPageGJSJson_Enabled = 0;
         edtPageGJSHtml_Enabled = 0;
         edtPageJsonContent_Enabled = 0;
         edtLocationId_Enabled = 0;
         edtTrn_PageName_Enabled = 0;
         edtTrn_PageId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         bttBtnsubscriptions_Visible = 1;
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
         Ddo_grid_Datalistproc = "Trn_PageWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||||||1:WWP_TSChecked,2:WWP_TSUnChecked|1:WWP_TSChecked,2:WWP_TSUnChecked|||";
         Ddo_grid_Datalisttype = "|Dynamic||Dynamic|Dynamic|Dynamic|FixedValues|FixedValues|Dynamic||";
         Ddo_grid_Includedatalist = "|T||T|T|T|T|T|T||";
         Ddo_grid_Filtertype = "|Character||Character|Character|Character|||Character||";
         Ddo_grid_Includefilter = "|T||T|T|T|||T||";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|1|3|4|5|6|7|8|9|10|11";
         Ddo_grid_Columnids = "0:Trn_PageId|1:Trn_PageName|2:LocationId|3:PageJsonContent|4:PageGJSHtml|5:PageGJSJson|6:PageIsPublished|7:PageIsContentPage|8:PageChildren|9:ProductServiceId|10:OrganisationId";
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
         Form.Caption = context.GetMessage( " App builder pages", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV52ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV40OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV58Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19TFTrn_PageName","fld":"vTFTRN_PAGENAME"},{"av":"AV20TFTrn_PageName_Sel","fld":"vTFTRN_PAGENAME_SEL"},{"av":"AV41TFPageJsonContent","fld":"vTFPAGEJSONCONTENT"},{"av":"AV42TFPageJsonContent_Sel","fld":"vTFPAGEJSONCONTENT_SEL"},{"av":"AV43TFPageGJSHtml","fld":"vTFPAGEGJSHTML"},{"av":"AV44TFPageGJSHtml_Sel","fld":"vTFPAGEGJSHTML_SEL"},{"av":"AV45TFPageGJSJson","fld":"vTFPAGEGJSJSON"},{"av":"AV46TFPageGJSJson_Sel","fld":"vTFPAGEGJSJSON_SEL"},{"av":"AV54TFPageIsPublished_Sel","fld":"vTFPAGEISPUBLISHED_SEL","pic":"9"},{"av":"AV48TFPageIsContentPage_Sel","fld":"vTFPAGEISCONTENTPAGE_SEL","pic":"9"},{"av":"AV55TFPageChildren","fld":"vTFPAGECHILDREN"},{"av":"AV56TFPageChildren_Sel","fld":"vTFPAGECHILDREN_SEL"},{"av":"AV30IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV32IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV34IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV28IsAuthorized_Trn_PageName","fld":"vISAUTHORIZED_TRN_PAGENAME","hsh":true},{"av":"AV35IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV52ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtTrn_PageId_Visible","ctrl":"TRN_PAGEID","prop":"Visible"},{"av":"edtTrn_PageName_Visible","ctrl":"TRN_PAGENAME","prop":"Visible"},{"av":"edtLocationId_Visible","ctrl":"LOCATIONID","prop":"Visible"},{"av":"edtPageJsonContent_Visible","ctrl":"PAGEJSONCONTENT","prop":"Visible"},{"av":"edtPageGJSHtml_Visible","ctrl":"PAGEGJSHTML","prop":"Visible"},{"av":"edtPageGJSJson_Visible","ctrl":"PAGEGJSJSON","prop":"Visible"},{"av":"chkPageIsPublished.Visible","ctrl":"PAGEISPUBLISHED","prop":"Visible"},{"av":"cmbPageIsContentPage"},{"av":"edtPageChildren_Visible","ctrl":"PAGECHILDREN","prop":"Visible"},{"av":"edtProductServiceId_Visible","ctrl":"PRODUCTSERVICEID","prop":"Visible"},{"av":"edtOrganisationId_Visible","ctrl":"ORGANISATIONID","prop":"Visible"},{"av":"AV25GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV26GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV27GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV30IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV32IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV34IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV35IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV16ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E12722","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV40OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV52ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV58Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19TFTrn_PageName","fld":"vTFTRN_PAGENAME"},{"av":"AV20TFTrn_PageName_Sel","fld":"vTFTRN_PAGENAME_SEL"},{"av":"AV41TFPageJsonContent","fld":"vTFPAGEJSONCONTENT"},{"av":"AV42TFPageJsonContent_Sel","fld":"vTFPAGEJSONCONTENT_SEL"},{"av":"AV43TFPageGJSHtml","fld":"vTFPAGEGJSHTML"},{"av":"AV44TFPageGJSHtml_Sel","fld":"vTFPAGEGJSHTML_SEL"},{"av":"AV45TFPageGJSJson","fld":"vTFPAGEGJSJSON"},{"av":"AV46TFPageGJSJson_Sel","fld":"vTFPAGEGJSJSON_SEL"},{"av":"AV54TFPageIsPublished_Sel","fld":"vTFPAGEISPUBLISHED_SEL","pic":"9"},{"av":"AV48TFPageIsContentPage_Sel","fld":"vTFPAGEISCONTENTPAGE_SEL","pic":"9"},{"av":"AV55TFPageChildren","fld":"vTFPAGECHILDREN"},{"av":"AV56TFPageChildren_Sel","fld":"vTFPAGECHILDREN_SEL"},{"av":"AV30IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV32IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV34IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV28IsAuthorized_Trn_PageName","fld":"vISAUTHORIZED_TRN_PAGENAME","hsh":true},{"av":"AV35IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E13722","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV40OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV52ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV58Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19TFTrn_PageName","fld":"vTFTRN_PAGENAME"},{"av":"AV20TFTrn_PageName_Sel","fld":"vTFTRN_PAGENAME_SEL"},{"av":"AV41TFPageJsonContent","fld":"vTFPAGEJSONCONTENT"},{"av":"AV42TFPageJsonContent_Sel","fld":"vTFPAGEJSONCONTENT_SEL"},{"av":"AV43TFPageGJSHtml","fld":"vTFPAGEGJSHTML"},{"av":"AV44TFPageGJSHtml_Sel","fld":"vTFPAGEGJSHTML_SEL"},{"av":"AV45TFPageGJSJson","fld":"vTFPAGEGJSJSON"},{"av":"AV46TFPageGJSJson_Sel","fld":"vTFPAGEGJSJSON_SEL"},{"av":"AV54TFPageIsPublished_Sel","fld":"vTFPAGEISPUBLISHED_SEL","pic":"9"},{"av":"AV48TFPageIsContentPage_Sel","fld":"vTFPAGEISCONTENTPAGE_SEL","pic":"9"},{"av":"AV55TFPageChildren","fld":"vTFPAGECHILDREN"},{"av":"AV56TFPageChildren_Sel","fld":"vTFPAGECHILDREN_SEL"},{"av":"AV30IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV32IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV34IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV28IsAuthorized_Trn_PageName","fld":"vISAUTHORIZED_TRN_PAGENAME","hsh":true},{"av":"AV35IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E15722","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV40OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV52ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV58Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19TFTrn_PageName","fld":"vTFTRN_PAGENAME"},{"av":"AV20TFTrn_PageName_Sel","fld":"vTFTRN_PAGENAME_SEL"},{"av":"AV41TFPageJsonContent","fld":"vTFPAGEJSONCONTENT"},{"av":"AV42TFPageJsonContent_Sel","fld":"vTFPAGEJSONCONTENT_SEL"},{"av":"AV43TFPageGJSHtml","fld":"vTFPAGEGJSHTML"},{"av":"AV44TFPageGJSHtml_Sel","fld":"vTFPAGEGJSHTML_SEL"},{"av":"AV45TFPageGJSJson","fld":"vTFPAGEGJSJSON"},{"av":"AV46TFPageGJSJson_Sel","fld":"vTFPAGEGJSJSON_SEL"},{"av":"AV54TFPageIsPublished_Sel","fld":"vTFPAGEISPUBLISHED_SEL","pic":"9"},{"av":"AV48TFPageIsContentPage_Sel","fld":"vTFPAGEISCONTENTPAGE_SEL","pic":"9"},{"av":"AV55TFPageChildren","fld":"vTFPAGECHILDREN"},{"av":"AV56TFPageChildren_Sel","fld":"vTFPAGECHILDREN_SEL"},{"av":"AV30IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV32IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV34IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV28IsAuthorized_Trn_PageName","fld":"vISAUTHORIZED_TRN_PAGENAME","hsh":true},{"av":"AV35IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV40OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV55TFPageChildren","fld":"vTFPAGECHILDREN"},{"av":"AV56TFPageChildren_Sel","fld":"vTFPAGECHILDREN_SEL"},{"av":"AV48TFPageIsContentPage_Sel","fld":"vTFPAGEISCONTENTPAGE_SEL","pic":"9"},{"av":"AV54TFPageIsPublished_Sel","fld":"vTFPAGEISPUBLISHED_SEL","pic":"9"},{"av":"AV45TFPageGJSJson","fld":"vTFPAGEGJSJSON"},{"av":"AV46TFPageGJSJson_Sel","fld":"vTFPAGEGJSJSON_SEL"},{"av":"AV43TFPageGJSHtml","fld":"vTFPAGEGJSHTML"},{"av":"AV44TFPageGJSHtml_Sel","fld":"vTFPAGEGJSHTML_SEL"},{"av":"AV41TFPageJsonContent","fld":"vTFPAGEJSONCONTENT"},{"av":"AV42TFPageJsonContent_Sel","fld":"vTFPAGEJSONCONTENT_SEL"},{"av":"AV19TFTrn_PageName","fld":"vTFTRN_PAGENAME"},{"av":"AV20TFTrn_PageName_Sel","fld":"vTFTRN_PAGENAME_SEL"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E20722","iparms":[{"av":"AV30IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV32IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV34IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV28IsAuthorized_Trn_PageName","fld":"vISAUTHORIZED_TRN_PAGENAME","hsh":true},{"av":"A392Trn_PageId","fld":"TRN_PAGEID","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID","hsh":true}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"cmbavActiongroup"},{"av":"AV47ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"edtTrn_PageName_Link","ctrl":"TRN_PAGENAME","prop":"Link"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E16722","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV40OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV52ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV58Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19TFTrn_PageName","fld":"vTFTRN_PAGENAME"},{"av":"AV20TFTrn_PageName_Sel","fld":"vTFTRN_PAGENAME_SEL"},{"av":"AV41TFPageJsonContent","fld":"vTFPAGEJSONCONTENT"},{"av":"AV42TFPageJsonContent_Sel","fld":"vTFPAGEJSONCONTENT_SEL"},{"av":"AV43TFPageGJSHtml","fld":"vTFPAGEGJSHTML"},{"av":"AV44TFPageGJSHtml_Sel","fld":"vTFPAGEGJSHTML_SEL"},{"av":"AV45TFPageGJSJson","fld":"vTFPAGEGJSJSON"},{"av":"AV46TFPageGJSJson_Sel","fld":"vTFPAGEGJSJSON_SEL"},{"av":"AV54TFPageIsPublished_Sel","fld":"vTFPAGEISPUBLISHED_SEL","pic":"9"},{"av":"AV48TFPageIsContentPage_Sel","fld":"vTFPAGEISCONTENTPAGE_SEL","pic":"9"},{"av":"AV55TFPageChildren","fld":"vTFPAGECHILDREN"},{"av":"AV56TFPageChildren_Sel","fld":"vTFPAGECHILDREN_SEL"},{"av":"AV30IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV32IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV34IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV28IsAuthorized_Trn_PageName","fld":"vISAUTHORIZED_TRN_PAGENAME","hsh":true},{"av":"AV35IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV52ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"edtTrn_PageId_Visible","ctrl":"TRN_PAGEID","prop":"Visible"},{"av":"edtTrn_PageName_Visible","ctrl":"TRN_PAGENAME","prop":"Visible"},{"av":"edtLocationId_Visible","ctrl":"LOCATIONID","prop":"Visible"},{"av":"edtPageJsonContent_Visible","ctrl":"PAGEJSONCONTENT","prop":"Visible"},{"av":"edtPageGJSHtml_Visible","ctrl":"PAGEGJSHTML","prop":"Visible"},{"av":"edtPageGJSJson_Visible","ctrl":"PAGEGJSJSON","prop":"Visible"},{"av":"chkPageIsPublished.Visible","ctrl":"PAGEISPUBLISHED","prop":"Visible"},{"av":"cmbPageIsContentPage"},{"av":"edtPageChildren_Visible","ctrl":"PAGECHILDREN","prop":"Visible"},{"av":"edtProductServiceId_Visible","ctrl":"PRODUCTSERVICEID","prop":"Visible"},{"av":"edtOrganisationId_Visible","ctrl":"ORGANISATIONID","prop":"Visible"},{"av":"AV25GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV26GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV27GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV30IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV32IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV34IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV35IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV16ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E11722","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV40OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV52ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV58Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19TFTrn_PageName","fld":"vTFTRN_PAGENAME"},{"av":"AV20TFTrn_PageName_Sel","fld":"vTFTRN_PAGENAME_SEL"},{"av":"AV41TFPageJsonContent","fld":"vTFPAGEJSONCONTENT"},{"av":"AV42TFPageJsonContent_Sel","fld":"vTFPAGEJSONCONTENT_SEL"},{"av":"AV43TFPageGJSHtml","fld":"vTFPAGEGJSHTML"},{"av":"AV44TFPageGJSHtml_Sel","fld":"vTFPAGEGJSHTML_SEL"},{"av":"AV45TFPageGJSJson","fld":"vTFPAGEGJSJSON"},{"av":"AV46TFPageGJSJson_Sel","fld":"vTFPAGEGJSJSON_SEL"},{"av":"AV54TFPageIsPublished_Sel","fld":"vTFPAGEISPUBLISHED_SEL","pic":"9"},{"av":"AV48TFPageIsContentPage_Sel","fld":"vTFPAGEISCONTENTPAGE_SEL","pic":"9"},{"av":"AV55TFPageChildren","fld":"vTFPAGECHILDREN"},{"av":"AV56TFPageChildren_Sel","fld":"vTFPAGECHILDREN_SEL"},{"av":"AV30IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV32IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV34IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV28IsAuthorized_Trn_PageName","fld":"vISAUTHORIZED_TRN_PAGENAME","hsh":true},{"av":"AV35IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV40OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19TFTrn_PageName","fld":"vTFTRN_PAGENAME"},{"av":"AV20TFTrn_PageName_Sel","fld":"vTFTRN_PAGENAME_SEL"},{"av":"AV41TFPageJsonContent","fld":"vTFPAGEJSONCONTENT"},{"av":"AV42TFPageJsonContent_Sel","fld":"vTFPAGEJSONCONTENT_SEL"},{"av":"AV43TFPageGJSHtml","fld":"vTFPAGEGJSHTML"},{"av":"AV44TFPageGJSHtml_Sel","fld":"vTFPAGEGJSHTML_SEL"},{"av":"AV45TFPageGJSJson","fld":"vTFPAGEGJSJSON"},{"av":"AV46TFPageGJSJson_Sel","fld":"vTFPAGEGJSJSON_SEL"},{"av":"AV54TFPageIsPublished_Sel","fld":"vTFPAGEISPUBLISHED_SEL","pic":"9"},{"av":"AV48TFPageIsContentPage_Sel","fld":"vTFPAGEISCONTENTPAGE_SEL","pic":"9"},{"av":"AV55TFPageChildren","fld":"vTFPAGECHILDREN"},{"av":"AV56TFPageChildren_Sel","fld":"vTFPAGECHILDREN_SEL"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV52ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtTrn_PageId_Visible","ctrl":"TRN_PAGEID","prop":"Visible"},{"av":"edtTrn_PageName_Visible","ctrl":"TRN_PAGENAME","prop":"Visible"},{"av":"edtLocationId_Visible","ctrl":"LOCATIONID","prop":"Visible"},{"av":"edtPageJsonContent_Visible","ctrl":"PAGEJSONCONTENT","prop":"Visible"},{"av":"edtPageGJSHtml_Visible","ctrl":"PAGEGJSHTML","prop":"Visible"},{"av":"edtPageGJSJson_Visible","ctrl":"PAGEGJSJSON","prop":"Visible"},{"av":"chkPageIsPublished.Visible","ctrl":"PAGEISPUBLISHED","prop":"Visible"},{"av":"cmbPageIsContentPage"},{"av":"edtPageChildren_Visible","ctrl":"PAGECHILDREN","prop":"Visible"},{"av":"edtProductServiceId_Visible","ctrl":"PRODUCTSERVICEID","prop":"Visible"},{"av":"edtOrganisationId_Visible","ctrl":"ORGANISATIONID","prop":"Visible"},{"av":"AV25GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV26GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV27GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV30IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV32IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV34IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV35IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV16ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("VACTIONGROUP.CLICK","""{"handler":"E21722","iparms":[{"av":"cmbavActiongroup"},{"av":"AV47ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV40OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV52ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV58Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19TFTrn_PageName","fld":"vTFTRN_PAGENAME"},{"av":"AV20TFTrn_PageName_Sel","fld":"vTFTRN_PAGENAME_SEL"},{"av":"AV41TFPageJsonContent","fld":"vTFPAGEJSONCONTENT"},{"av":"AV42TFPageJsonContent_Sel","fld":"vTFPAGEJSONCONTENT_SEL"},{"av":"AV43TFPageGJSHtml","fld":"vTFPAGEGJSHTML"},{"av":"AV44TFPageGJSHtml_Sel","fld":"vTFPAGEGJSHTML_SEL"},{"av":"AV45TFPageGJSJson","fld":"vTFPAGEGJSJSON"},{"av":"AV46TFPageGJSJson_Sel","fld":"vTFPAGEGJSJSON_SEL"},{"av":"AV54TFPageIsPublished_Sel","fld":"vTFPAGEISPUBLISHED_SEL","pic":"9"},{"av":"AV48TFPageIsContentPage_Sel","fld":"vTFPAGEISCONTENTPAGE_SEL","pic":"9"},{"av":"AV55TFPageChildren","fld":"vTFPAGECHILDREN"},{"av":"AV56TFPageChildren_Sel","fld":"vTFPAGECHILDREN_SEL"},{"av":"AV30IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV32IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV34IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV28IsAuthorized_Trn_PageName","fld":"vISAUTHORIZED_TRN_PAGENAME","hsh":true},{"av":"AV35IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"A392Trn_PageId","fld":"TRN_PAGEID","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID","hsh":true}]""");
         setEventMetadata("VACTIONGROUP.CLICK",""","oparms":[{"av":"cmbavActiongroup"},{"av":"AV47ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV52ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtTrn_PageId_Visible","ctrl":"TRN_PAGEID","prop":"Visible"},{"av":"edtTrn_PageName_Visible","ctrl":"TRN_PAGENAME","prop":"Visible"},{"av":"edtLocationId_Visible","ctrl":"LOCATIONID","prop":"Visible"},{"av":"edtPageJsonContent_Visible","ctrl":"PAGEJSONCONTENT","prop":"Visible"},{"av":"edtPageGJSHtml_Visible","ctrl":"PAGEGJSHTML","prop":"Visible"},{"av":"edtPageGJSJson_Visible","ctrl":"PAGEGJSJSON","prop":"Visible"},{"av":"chkPageIsPublished.Visible","ctrl":"PAGEISPUBLISHED","prop":"Visible"},{"av":"cmbPageIsContentPage"},{"av":"edtPageChildren_Visible","ctrl":"PAGECHILDREN","prop":"Visible"},{"av":"edtProductServiceId_Visible","ctrl":"PRODUCTSERVICEID","prop":"Visible"},{"av":"edtOrganisationId_Visible","ctrl":"ORGANISATIONID","prop":"Visible"},{"av":"AV25GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV26GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV27GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV30IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV32IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV34IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV35IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV16ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E17722","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV40OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV52ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV58Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19TFTrn_PageName","fld":"vTFTRN_PAGENAME"},{"av":"AV20TFTrn_PageName_Sel","fld":"vTFTRN_PAGENAME_SEL"},{"av":"AV41TFPageJsonContent","fld":"vTFPAGEJSONCONTENT"},{"av":"AV42TFPageJsonContent_Sel","fld":"vTFPAGEJSONCONTENT_SEL"},{"av":"AV43TFPageGJSHtml","fld":"vTFPAGEGJSHTML"},{"av":"AV44TFPageGJSHtml_Sel","fld":"vTFPAGEGJSHTML_SEL"},{"av":"AV45TFPageGJSJson","fld":"vTFPAGEGJSJSON"},{"av":"AV46TFPageGJSJson_Sel","fld":"vTFPAGEGJSJSON_SEL"},{"av":"AV54TFPageIsPublished_Sel","fld":"vTFPAGEISPUBLISHED_SEL","pic":"9"},{"av":"AV48TFPageIsContentPage_Sel","fld":"vTFPAGEISCONTENTPAGE_SEL","pic":"9"},{"av":"AV55TFPageChildren","fld":"vTFPAGECHILDREN"},{"av":"AV56TFPageChildren_Sel","fld":"vTFPAGECHILDREN_SEL"},{"av":"AV30IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV32IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV34IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV28IsAuthorized_Trn_PageName","fld":"vISAUTHORIZED_TRN_PAGENAME","hsh":true},{"av":"AV35IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"A392Trn_PageId","fld":"TRN_PAGEID","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID","hsh":true}]""");
         setEventMetadata("'DOINSERT'",""","oparms":[{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV52ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtTrn_PageId_Visible","ctrl":"TRN_PAGEID","prop":"Visible"},{"av":"edtTrn_PageName_Visible","ctrl":"TRN_PAGENAME","prop":"Visible"},{"av":"edtLocationId_Visible","ctrl":"LOCATIONID","prop":"Visible"},{"av":"edtPageJsonContent_Visible","ctrl":"PAGEJSONCONTENT","prop":"Visible"},{"av":"edtPageGJSHtml_Visible","ctrl":"PAGEGJSHTML","prop":"Visible"},{"av":"edtPageGJSJson_Visible","ctrl":"PAGEGJSJSON","prop":"Visible"},{"av":"chkPageIsPublished.Visible","ctrl":"PAGEISPUBLISHED","prop":"Visible"},{"av":"cmbPageIsContentPage"},{"av":"edtPageChildren_Visible","ctrl":"PAGECHILDREN","prop":"Visible"},{"av":"edtProductServiceId_Visible","ctrl":"PRODUCTSERVICEID","prop":"Visible"},{"av":"edtOrganisationId_Visible","ctrl":"ORGANISATIONID","prop":"Visible"},{"av":"AV25GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV26GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV27GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV30IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV32IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV34IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV35IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV16ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","""{"handler":"E14722","iparms":[]""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("VALID_TRN_PAGENAME","""{"handler":"Valid_Trn_pagename","iparms":[]}""");
         setEventMetadata("VALID_PAGEJSONCONTENT","""{"handler":"Valid_Pagejsoncontent","iparms":[]}""");
         setEventMetadata("VALID_PAGEGJSHTML","""{"handler":"Valid_Pagegjshtml","iparms":[]}""");
         setEventMetadata("VALID_PAGEGJSJSON","""{"handler":"Valid_Pagegjsjson","iparms":[]}""");
         setEventMetadata("VALID_PAGEISCONTENTPAGE","""{"handler":"Valid_Pageiscontentpage","iparms":[]}""");
         setEventMetadata("VALID_PAGECHILDREN","""{"handler":"Valid_Pagechildren","iparms":[]}""");
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
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV52ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV58Pgmname = "";
         AV14FilterFullText = "";
         AV19TFTrn_PageName = "";
         AV20TFTrn_PageName_Sel = "";
         AV41TFPageJsonContent = "";
         AV42TFPageJsonContent_Sel = "";
         AV43TFPageGJSHtml = "";
         AV44TFPageGJSHtml_Sel = "";
         AV45TFPageGJSJson = "";
         AV46TFPageGJSJson_Sel = "";
         AV55TFPageChildren = "";
         AV56TFPageChildren_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV16ManageFiltersData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV27GridAppliedFilters = "";
         AV21DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
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
         A392Trn_PageId = Guid.Empty;
         A397Trn_PageName = "";
         A29LocationId = Guid.Empty;
         A420PageJsonContent = "";
         A421PageGJSHtml = "";
         A422PageGJSJson = "";
         A424PageChildren = "";
         A58ProductServiceId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV59Trn_pagewwds_1_filterfulltext = "";
         AV60Trn_pagewwds_2_tftrn_pagename = "";
         AV61Trn_pagewwds_3_tftrn_pagename_sel = "";
         AV62Trn_pagewwds_4_tfpagejsoncontent = "";
         AV63Trn_pagewwds_5_tfpagejsoncontent_sel = "";
         AV64Trn_pagewwds_6_tfpagegjshtml = "";
         AV65Trn_pagewwds_7_tfpagegjshtml_sel = "";
         AV66Trn_pagewwds_8_tfpagegjsjson = "";
         AV67Trn_pagewwds_9_tfpagegjsjson_sel = "";
         AV70Trn_pagewwds_12_tfpagechildren = "";
         AV71Trn_pagewwds_13_tfpagechildren_sel = "";
         lV59Trn_pagewwds_1_filterfulltext = "";
         lV60Trn_pagewwds_2_tftrn_pagename = "";
         lV62Trn_pagewwds_4_tfpagejsoncontent = "";
         lV64Trn_pagewwds_6_tfpagegjshtml = "";
         lV66Trn_pagewwds_8_tfpagegjsjson = "";
         lV70Trn_pagewwds_12_tfpagechildren = "";
         H00722_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00722_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         H00722_n58ProductServiceId = new bool[] {false} ;
         H00722_A424PageChildren = new string[] {""} ;
         H00722_n424PageChildren = new bool[] {false} ;
         H00722_A429PageIsContentPage = new bool[] {false} ;
         H00722_n429PageIsContentPage = new bool[] {false} ;
         H00722_A423PageIsPublished = new bool[] {false} ;
         H00722_n423PageIsPublished = new bool[] {false} ;
         H00722_A422PageGJSJson = new string[] {""} ;
         H00722_n422PageGJSJson = new bool[] {false} ;
         H00722_A421PageGJSHtml = new string[] {""} ;
         H00722_n421PageGJSHtml = new bool[] {false} ;
         H00722_A420PageJsonContent = new string[] {""} ;
         H00722_n420PageJsonContent = new bool[] {false} ;
         H00722_A29LocationId = new Guid[] {Guid.Empty} ;
         H00722_A397Trn_PageName = new string[] {""} ;
         H00722_A392Trn_PageId = new Guid[] {Guid.Empty} ;
         H00723_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00723_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         H00723_n58ProductServiceId = new bool[] {false} ;
         H00723_A424PageChildren = new string[] {""} ;
         H00723_n424PageChildren = new bool[] {false} ;
         H00723_A429PageIsContentPage = new bool[] {false} ;
         H00723_n429PageIsContentPage = new bool[] {false} ;
         H00723_A423PageIsPublished = new bool[] {false} ;
         H00723_n423PageIsPublished = new bool[] {false} ;
         H00723_A422PageGJSJson = new string[] {""} ;
         H00723_n422PageGJSJson = new bool[] {false} ;
         H00723_A421PageGJSHtml = new string[] {""} ;
         H00723_n421PageGJSHtml = new bool[] {false} ;
         H00723_A420PageJsonContent = new string[] {""} ;
         H00723_n420PageJsonContent = new bool[] {false} ;
         H00723_A29LocationId = new Guid[] {Guid.Empty} ;
         H00723_A397Trn_PageName = new string[] {""} ;
         H00723_A392Trn_PageId = new Guid[] {Guid.Empty} ;
         AV8HTTPRequest = new GxHttpRequest( context);
         AV22GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV23GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV15Session = context.GetSession();
         AV50ColumnsSelectorXML = "";
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV17ManageFiltersXml = "";
         AV51UserCustomValue = "";
         AV53ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV12GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char3 = "";
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_pageww__default(),
            new Object[][] {
                new Object[] {
               H00722_A11OrganisationId, H00722_A58ProductServiceId, H00722_n58ProductServiceId, H00722_A424PageChildren, H00722_n424PageChildren, H00722_A429PageIsContentPage, H00722_n429PageIsContentPage, H00722_A423PageIsPublished, H00722_n423PageIsPublished, H00722_A422PageGJSJson,
               H00722_n422PageGJSJson, H00722_A421PageGJSHtml, H00722_n421PageGJSHtml, H00722_A420PageJsonContent, H00722_n420PageJsonContent, H00722_A29LocationId, H00722_A397Trn_PageName, H00722_A392Trn_PageId
               }
               , new Object[] {
               H00723_A11OrganisationId, H00723_A58ProductServiceId, H00723_n58ProductServiceId, H00723_A424PageChildren, H00723_n424PageChildren, H00723_A429PageIsContentPage, H00723_n429PageIsContentPage, H00723_A423PageIsPublished, H00723_n423PageIsPublished, H00723_A422PageGJSJson,
               H00723_n422PageGJSJson, H00723_A421PageGJSHtml, H00723_n421PageGJSHtml, H00723_A420PageJsonContent, H00723_n420PageJsonContent, H00723_A29LocationId, H00723_A397Trn_PageName, H00723_A392Trn_PageId
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV58Pgmname = "Trn_PageWW";
         /* GeneXus formulas. */
         AV58Pgmname = "Trn_PageWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV40OrderedBy ;
      private short AV18ManageFiltersExecutionStep ;
      private short AV54TFPageIsPublished_Sel ;
      private short AV48TFPageIsContentPage_Sel ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV47ActionGroup ;
      private short nCmpId ;
      private short nDonePA ;
      private short AV68Trn_pagewwds_10_tfpageispublished_sel ;
      private short AV69Trn_pagewwds_11_tfpageiscontentpage_sel ;
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
      private int bttBtninsert_Visible ;
      private int bttBtnsubscriptions_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int edtTrn_PageId_Enabled ;
      private int edtTrn_PageName_Enabled ;
      private int edtLocationId_Enabled ;
      private int edtPageJsonContent_Enabled ;
      private int edtPageGJSHtml_Enabled ;
      private int edtPageGJSJson_Enabled ;
      private int edtPageChildren_Enabled ;
      private int edtProductServiceId_Enabled ;
      private int edtOrganisationId_Enabled ;
      private int edtTrn_PageId_Visible ;
      private int edtTrn_PageName_Visible ;
      private int edtLocationId_Visible ;
      private int edtPageJsonContent_Visible ;
      private int edtPageGJSHtml_Visible ;
      private int edtPageGJSJson_Visible ;
      private int edtPageChildren_Visible ;
      private int edtProductServiceId_Visible ;
      private int edtOrganisationId_Visible ;
      private int AV24PageToGo ;
      private int AV72GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV25GridCurrentPage ;
      private long AV26GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_39_idx="0001" ;
      private string AV58Pgmname ;
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
      private string edtTrn_PageId_Internalname ;
      private string edtTrn_PageName_Internalname ;
      private string edtLocationId_Internalname ;
      private string edtPageJsonContent_Internalname ;
      private string edtPageGJSHtml_Internalname ;
      private string edtPageGJSJson_Internalname ;
      private string chkPageIsPublished_Internalname ;
      private string cmbPageIsContentPage_Internalname ;
      private string edtPageChildren_Internalname ;
      private string edtProductServiceId_Internalname ;
      private string edtOrganisationId_Internalname ;
      private string cmbavActiongroup_Internalname ;
      private string cmbavActiongroup_Class ;
      private string edtTrn_PageName_Link ;
      private string GXEncryptionTmp ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char3 ;
      private string sGXsfl_39_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtTrn_PageId_Jsonclick ;
      private string edtTrn_PageName_Jsonclick ;
      private string edtLocationId_Jsonclick ;
      private string edtPageJsonContent_Jsonclick ;
      private string edtPageGJSHtml_Jsonclick ;
      private string edtPageGJSJson_Jsonclick ;
      private string GXCCtl ;
      private string cmbPageIsContentPage_Jsonclick ;
      private string edtPageChildren_Jsonclick ;
      private string edtProductServiceId_Jsonclick ;
      private string edtOrganisationId_Jsonclick ;
      private string cmbavActiongroup_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13OrderedDsc ;
      private bool AV30IsAuthorized_Display ;
      private bool AV32IsAuthorized_Update ;
      private bool AV34IsAuthorized_Delete ;
      private bool AV28IsAuthorized_Trn_PageName ;
      private bool AV35IsAuthorized_Insert ;
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
      private bool n420PageJsonContent ;
      private bool n421PageGJSHtml ;
      private bool n422PageGJSJson ;
      private bool A423PageIsPublished ;
      private bool n423PageIsPublished ;
      private bool A429PageIsContentPage ;
      private bool n429PageIsContentPage ;
      private bool n424PageChildren ;
      private bool n58ProductServiceId ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool GXt_boolean1 ;
      private string A420PageJsonContent ;
      private string A421PageGJSHtml ;
      private string A422PageGJSJson ;
      private string A424PageChildren ;
      private string AV50ColumnsSelectorXML ;
      private string AV17ManageFiltersXml ;
      private string AV51UserCustomValue ;
      private string AV14FilterFullText ;
      private string AV19TFTrn_PageName ;
      private string AV20TFTrn_PageName_Sel ;
      private string AV41TFPageJsonContent ;
      private string AV42TFPageJsonContent_Sel ;
      private string AV43TFPageGJSHtml ;
      private string AV44TFPageGJSHtml_Sel ;
      private string AV45TFPageGJSJson ;
      private string AV46TFPageGJSJson_Sel ;
      private string AV55TFPageChildren ;
      private string AV56TFPageChildren_Sel ;
      private string AV27GridAppliedFilters ;
      private string A397Trn_PageName ;
      private string AV59Trn_pagewwds_1_filterfulltext ;
      private string AV60Trn_pagewwds_2_tftrn_pagename ;
      private string AV61Trn_pagewwds_3_tftrn_pagename_sel ;
      private string AV62Trn_pagewwds_4_tfpagejsoncontent ;
      private string AV63Trn_pagewwds_5_tfpagejsoncontent_sel ;
      private string AV64Trn_pagewwds_6_tfpagegjshtml ;
      private string AV65Trn_pagewwds_7_tfpagegjshtml_sel ;
      private string AV66Trn_pagewwds_8_tfpagegjsjson ;
      private string AV67Trn_pagewwds_9_tfpagegjsjson_sel ;
      private string AV70Trn_pagewwds_12_tfpagechildren ;
      private string AV71Trn_pagewwds_13_tfpagechildren_sel ;
      private string lV59Trn_pagewwds_1_filterfulltext ;
      private string lV60Trn_pagewwds_2_tftrn_pagename ;
      private string lV62Trn_pagewwds_4_tfpagejsoncontent ;
      private string lV64Trn_pagewwds_6_tfpagegjshtml ;
      private string lV66Trn_pagewwds_8_tfpagegjsjson ;
      private string lV70Trn_pagewwds_12_tfpagechildren ;
      private Guid A392Trn_PageId ;
      private Guid A29LocationId ;
      private Guid A58ProductServiceId ;
      private Guid A11OrganisationId ;
      private IGxSession AV15Session ;
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
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkPageIsPublished ;
      private GXCombobox cmbPageIsContentPage ;
      private GXCombobox cmbavActiongroup ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV52ColumnsSelector ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV16ManageFiltersData ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV21DDO_TitleSettingsIcons ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV11GridState ;
      private IDataStoreProvider pr_default ;
      private Guid[] H00722_A11OrganisationId ;
      private Guid[] H00722_A58ProductServiceId ;
      private bool[] H00722_n58ProductServiceId ;
      private string[] H00722_A424PageChildren ;
      private bool[] H00722_n424PageChildren ;
      private bool[] H00722_A429PageIsContentPage ;
      private bool[] H00722_n429PageIsContentPage ;
      private bool[] H00722_A423PageIsPublished ;
      private bool[] H00722_n423PageIsPublished ;
      private string[] H00722_A422PageGJSJson ;
      private bool[] H00722_n422PageGJSJson ;
      private string[] H00722_A421PageGJSHtml ;
      private bool[] H00722_n421PageGJSHtml ;
      private string[] H00722_A420PageJsonContent ;
      private bool[] H00722_n420PageJsonContent ;
      private Guid[] H00722_A29LocationId ;
      private string[] H00722_A397Trn_PageName ;
      private Guid[] H00722_A392Trn_PageId ;
      private Guid[] H00723_A11OrganisationId ;
      private Guid[] H00723_A58ProductServiceId ;
      private bool[] H00723_n58ProductServiceId ;
      private string[] H00723_A424PageChildren ;
      private bool[] H00723_n424PageChildren ;
      private bool[] H00723_A429PageIsContentPage ;
      private bool[] H00723_n429PageIsContentPage ;
      private bool[] H00723_A423PageIsPublished ;
      private bool[] H00723_n423PageIsPublished ;
      private string[] H00723_A422PageGJSJson ;
      private bool[] H00723_n422PageGJSJson ;
      private string[] H00723_A421PageGJSHtml ;
      private bool[] H00723_n421PageGJSHtml ;
      private string[] H00723_A420PageJsonContent ;
      private bool[] H00723_n420PageJsonContent ;
      private Guid[] H00723_A29LocationId ;
      private string[] H00723_A397Trn_PageName ;
      private Guid[] H00723_A392Trn_PageId ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV22GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV23GAMErrors ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV53ColumnsSelectorAux ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class trn_pageww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00722( IGxContext context ,
                                             string AV61Trn_pagewwds_3_tftrn_pagename_sel ,
                                             string AV60Trn_pagewwds_2_tftrn_pagename ,
                                             string AV63Trn_pagewwds_5_tfpagejsoncontent_sel ,
                                             string AV62Trn_pagewwds_4_tfpagejsoncontent ,
                                             string AV65Trn_pagewwds_7_tfpagegjshtml_sel ,
                                             string AV64Trn_pagewwds_6_tfpagegjshtml ,
                                             string AV67Trn_pagewwds_9_tfpagegjsjson_sel ,
                                             string AV66Trn_pagewwds_8_tfpagegjsjson ,
                                             short AV68Trn_pagewwds_10_tfpageispublished_sel ,
                                             short AV69Trn_pagewwds_11_tfpageiscontentpage_sel ,
                                             string AV71Trn_pagewwds_13_tfpagechildren_sel ,
                                             string AV70Trn_pagewwds_12_tfpagechildren ,
                                             string A397Trn_PageName ,
                                             string A420PageJsonContent ,
                                             string A421PageGJSHtml ,
                                             string A422PageGJSJson ,
                                             bool A423PageIsPublished ,
                                             bool A429PageIsContentPage ,
                                             string A424PageChildren ,
                                             short AV40OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             string AV59Trn_pagewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[10];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT OrganisationId, ProductServiceId, PageChildren, PageIsContentPage, PageIsPublished, PageGJSJson, PageGJSHtml, PageJsonContent, LocationId, Trn_PageName, Trn_PageId FROM Trn_Page";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_pagewwds_3_tftrn_pagename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_pagewwds_2_tftrn_pagename)) ) )
         {
            AddWhere(sWhereString, "(Trn_PageName like :lV60Trn_pagewwds_2_tftrn_pagename)");
         }
         else
         {
            GXv_int9[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_pagewwds_3_tftrn_pagename_sel)) && ! ( StringUtil.StrCmp(AV61Trn_pagewwds_3_tftrn_pagename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_PageName = ( :AV61Trn_pagewwds_3_tftrn_pagename_sel))");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( StringUtil.StrCmp(AV61Trn_pagewwds_3_tftrn_pagename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_PageName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_pagewwds_5_tfpagejsoncontent_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_pagewwds_4_tfpagejsoncontent)) ) )
         {
            AddWhere(sWhereString, "(PageJsonContent like :lV62Trn_pagewwds_4_tfpagejsoncontent)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_pagewwds_5_tfpagejsoncontent_sel)) && ! ( StringUtil.StrCmp(AV63Trn_pagewwds_5_tfpagejsoncontent_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(PageJsonContent = ( :AV63Trn_pagewwds_5_tfpagejsoncontent_sel))");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( StringUtil.StrCmp(AV63Trn_pagewwds_5_tfpagejsoncontent_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(PageJsonContent IS NULL or (char_length(trim(trailing ' ' from PageJsonContent))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_pagewwds_7_tfpagegjshtml_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_pagewwds_6_tfpagegjshtml)) ) )
         {
            AddWhere(sWhereString, "(PageGJSHtml like :lV64Trn_pagewwds_6_tfpagegjshtml)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_pagewwds_7_tfpagegjshtml_sel)) && ! ( StringUtil.StrCmp(AV65Trn_pagewwds_7_tfpagegjshtml_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(PageGJSHtml = ( :AV65Trn_pagewwds_7_tfpagegjshtml_sel))");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_pagewwds_7_tfpagegjshtml_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(PageGJSHtml IS NULL or (char_length(trim(trailing ' ' from PageGJSHtml))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_pagewwds_9_tfpagegjsjson_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_pagewwds_8_tfpagegjsjson)) ) )
         {
            AddWhere(sWhereString, "(PageGJSJson like :lV66Trn_pagewwds_8_tfpagegjsjson)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_pagewwds_9_tfpagegjsjson_sel)) && ! ( StringUtil.StrCmp(AV67Trn_pagewwds_9_tfpagegjsjson_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(PageGJSJson = ( :AV67Trn_pagewwds_9_tfpagegjsjson_sel))");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( StringUtil.StrCmp(AV67Trn_pagewwds_9_tfpagegjsjson_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(PageGJSJson IS NULL or (char_length(trim(trailing ' ' from PageGJSJson))=0))");
         }
         if ( AV68Trn_pagewwds_10_tfpageispublished_sel == 1 )
         {
            AddWhere(sWhereString, "(PageIsPublished = TRUE)");
         }
         if ( AV68Trn_pagewwds_10_tfpageispublished_sel == 2 )
         {
            AddWhere(sWhereString, "(PageIsPublished = FALSE)");
         }
         if ( AV69Trn_pagewwds_11_tfpageiscontentpage_sel == 1 )
         {
            AddWhere(sWhereString, "(PageIsContentPage = TRUE)");
         }
         if ( AV69Trn_pagewwds_11_tfpageiscontentpage_sel == 2 )
         {
            AddWhere(sWhereString, "(PageIsContentPage = FALSE)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_pagewwds_13_tfpagechildren_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_pagewwds_12_tfpagechildren)) ) )
         {
            AddWhere(sWhereString, "(PageChildren like :lV70Trn_pagewwds_12_tfpagechildren)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_pagewwds_13_tfpagechildren_sel)) && ! ( StringUtil.StrCmp(AV71Trn_pagewwds_13_tfpagechildren_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(PageChildren = ( :AV71Trn_pagewwds_13_tfpagechildren_sel))");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( StringUtil.StrCmp(AV71Trn_pagewwds_13_tfpagechildren_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(PageChildren IS NULL or (char_length(trim(trailing ' ' from PageChildren))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV40OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY Trn_PageName, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY Trn_PageName DESC, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY Trn_PageId DESC, LocationId";
         }
         else if ( ( AV40OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY LocationId, Trn_PageId";
         }
         else if ( ( AV40OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY LocationId DESC, Trn_PageId";
         }
         else if ( ( AV40OrderedBy == 4 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY PageJsonContent, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 4 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY PageJsonContent DESC, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 5 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY PageGJSHtml, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 5 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY PageGJSHtml DESC, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 6 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY PageGJSJson, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 6 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY PageGJSJson DESC, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 7 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY PageIsPublished, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 7 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY PageIsPublished DESC, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 8 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY PageIsContentPage, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 8 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY PageIsContentPage DESC, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 9 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY PageChildren, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 9 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY PageChildren DESC, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 10 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY ProductServiceId, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 10 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ProductServiceId DESC, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 11 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY OrganisationId, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 11 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY OrganisationId DESC, Trn_PageId, LocationId";
         }
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_H00723( IGxContext context ,
                                             string AV61Trn_pagewwds_3_tftrn_pagename_sel ,
                                             string AV60Trn_pagewwds_2_tftrn_pagename ,
                                             string AV63Trn_pagewwds_5_tfpagejsoncontent_sel ,
                                             string AV62Trn_pagewwds_4_tfpagejsoncontent ,
                                             string AV65Trn_pagewwds_7_tfpagegjshtml_sel ,
                                             string AV64Trn_pagewwds_6_tfpagegjshtml ,
                                             string AV67Trn_pagewwds_9_tfpagegjsjson_sel ,
                                             string AV66Trn_pagewwds_8_tfpagegjsjson ,
                                             short AV68Trn_pagewwds_10_tfpageispublished_sel ,
                                             short AV69Trn_pagewwds_11_tfpageiscontentpage_sel ,
                                             string AV71Trn_pagewwds_13_tfpagechildren_sel ,
                                             string AV70Trn_pagewwds_12_tfpagechildren ,
                                             string A397Trn_PageName ,
                                             string A420PageJsonContent ,
                                             string A421PageGJSHtml ,
                                             string A422PageGJSJson ,
                                             bool A423PageIsPublished ,
                                             bool A429PageIsContentPage ,
                                             string A424PageChildren ,
                                             short AV40OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             string AV59Trn_pagewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[10];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT OrganisationId, ProductServiceId, PageChildren, PageIsContentPage, PageIsPublished, PageGJSJson, PageGJSHtml, PageJsonContent, LocationId, Trn_PageName, Trn_PageId FROM Trn_Page";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_pagewwds_3_tftrn_pagename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_pagewwds_2_tftrn_pagename)) ) )
         {
            AddWhere(sWhereString, "(Trn_PageName like :lV60Trn_pagewwds_2_tftrn_pagename)");
         }
         else
         {
            GXv_int11[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_pagewwds_3_tftrn_pagename_sel)) && ! ( StringUtil.StrCmp(AV61Trn_pagewwds_3_tftrn_pagename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_PageName = ( :AV61Trn_pagewwds_3_tftrn_pagename_sel))");
         }
         else
         {
            GXv_int11[1] = 1;
         }
         if ( StringUtil.StrCmp(AV61Trn_pagewwds_3_tftrn_pagename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_PageName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_pagewwds_5_tfpagejsoncontent_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_pagewwds_4_tfpagejsoncontent)) ) )
         {
            AddWhere(sWhereString, "(PageJsonContent like :lV62Trn_pagewwds_4_tfpagejsoncontent)");
         }
         else
         {
            GXv_int11[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_pagewwds_5_tfpagejsoncontent_sel)) && ! ( StringUtil.StrCmp(AV63Trn_pagewwds_5_tfpagejsoncontent_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(PageJsonContent = ( :AV63Trn_pagewwds_5_tfpagejsoncontent_sel))");
         }
         else
         {
            GXv_int11[3] = 1;
         }
         if ( StringUtil.StrCmp(AV63Trn_pagewwds_5_tfpagejsoncontent_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(PageJsonContent IS NULL or (char_length(trim(trailing ' ' from PageJsonContent))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_pagewwds_7_tfpagegjshtml_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_pagewwds_6_tfpagegjshtml)) ) )
         {
            AddWhere(sWhereString, "(PageGJSHtml like :lV64Trn_pagewwds_6_tfpagegjshtml)");
         }
         else
         {
            GXv_int11[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_pagewwds_7_tfpagegjshtml_sel)) && ! ( StringUtil.StrCmp(AV65Trn_pagewwds_7_tfpagegjshtml_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(PageGJSHtml = ( :AV65Trn_pagewwds_7_tfpagegjshtml_sel))");
         }
         else
         {
            GXv_int11[5] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_pagewwds_7_tfpagegjshtml_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(PageGJSHtml IS NULL or (char_length(trim(trailing ' ' from PageGJSHtml))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_pagewwds_9_tfpagegjsjson_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_pagewwds_8_tfpagegjsjson)) ) )
         {
            AddWhere(sWhereString, "(PageGJSJson like :lV66Trn_pagewwds_8_tfpagegjsjson)");
         }
         else
         {
            GXv_int11[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_pagewwds_9_tfpagegjsjson_sel)) && ! ( StringUtil.StrCmp(AV67Trn_pagewwds_9_tfpagegjsjson_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(PageGJSJson = ( :AV67Trn_pagewwds_9_tfpagegjsjson_sel))");
         }
         else
         {
            GXv_int11[7] = 1;
         }
         if ( StringUtil.StrCmp(AV67Trn_pagewwds_9_tfpagegjsjson_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(PageGJSJson IS NULL or (char_length(trim(trailing ' ' from PageGJSJson))=0))");
         }
         if ( AV68Trn_pagewwds_10_tfpageispublished_sel == 1 )
         {
            AddWhere(sWhereString, "(PageIsPublished = TRUE)");
         }
         if ( AV68Trn_pagewwds_10_tfpageispublished_sel == 2 )
         {
            AddWhere(sWhereString, "(PageIsPublished = FALSE)");
         }
         if ( AV69Trn_pagewwds_11_tfpageiscontentpage_sel == 1 )
         {
            AddWhere(sWhereString, "(PageIsContentPage = TRUE)");
         }
         if ( AV69Trn_pagewwds_11_tfpageiscontentpage_sel == 2 )
         {
            AddWhere(sWhereString, "(PageIsContentPage = FALSE)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_pagewwds_13_tfpagechildren_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_pagewwds_12_tfpagechildren)) ) )
         {
            AddWhere(sWhereString, "(PageChildren like :lV70Trn_pagewwds_12_tfpagechildren)");
         }
         else
         {
            GXv_int11[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_pagewwds_13_tfpagechildren_sel)) && ! ( StringUtil.StrCmp(AV71Trn_pagewwds_13_tfpagechildren_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(PageChildren = ( :AV71Trn_pagewwds_13_tfpagechildren_sel))");
         }
         else
         {
            GXv_int11[9] = 1;
         }
         if ( StringUtil.StrCmp(AV71Trn_pagewwds_13_tfpagechildren_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(PageChildren IS NULL or (char_length(trim(trailing ' ' from PageChildren))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV40OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY Trn_PageName, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY Trn_PageName DESC, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY Trn_PageId DESC, LocationId";
         }
         else if ( ( AV40OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY LocationId, Trn_PageId";
         }
         else if ( ( AV40OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY LocationId DESC, Trn_PageId";
         }
         else if ( ( AV40OrderedBy == 4 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY PageJsonContent, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 4 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY PageJsonContent DESC, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 5 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY PageGJSHtml, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 5 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY PageGJSHtml DESC, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 6 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY PageGJSJson, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 6 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY PageGJSJson DESC, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 7 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY PageIsPublished, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 7 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY PageIsPublished DESC, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 8 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY PageIsContentPage, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 8 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY PageIsContentPage DESC, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 9 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY PageChildren, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 9 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY PageChildren DESC, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 10 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY ProductServiceId, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 10 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ProductServiceId DESC, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 11 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY OrganisationId, Trn_PageId, LocationId";
         }
         else if ( ( AV40OrderedBy == 11 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY OrganisationId DESC, Trn_PageId, LocationId";
         }
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00722(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (bool)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (bool)dynConstraints[20] , (string)dynConstraints[21] );
               case 1 :
                     return conditional_H00723(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (bool)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (bool)dynConstraints[20] , (string)dynConstraints[21] );
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
          Object[] prmH00722;
          prmH00722 = new Object[] {
          new ParDef("lV60Trn_pagewwds_2_tftrn_pagename",GXType.VarChar,100,0) ,
          new ParDef("AV61Trn_pagewwds_3_tftrn_pagename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_pagewwds_4_tfpagejsoncontent",GXType.VarChar,200,0) ,
          new ParDef("AV63Trn_pagewwds_5_tfpagejsoncontent_sel",GXType.VarChar,200,0) ,
          new ParDef("lV64Trn_pagewwds_6_tfpagegjshtml",GXType.VarChar,200,0) ,
          new ParDef("AV65Trn_pagewwds_7_tfpagegjshtml_sel",GXType.VarChar,200,0) ,
          new ParDef("lV66Trn_pagewwds_8_tfpagegjsjson",GXType.VarChar,200,0) ,
          new ParDef("AV67Trn_pagewwds_9_tfpagegjsjson_sel",GXType.VarChar,200,0) ,
          new ParDef("lV70Trn_pagewwds_12_tfpagechildren",GXType.VarChar,200,0) ,
          new ParDef("AV71Trn_pagewwds_13_tfpagechildren_sel",GXType.VarChar,200,0)
          };
          Object[] prmH00723;
          prmH00723 = new Object[] {
          new ParDef("lV60Trn_pagewwds_2_tftrn_pagename",GXType.VarChar,100,0) ,
          new ParDef("AV61Trn_pagewwds_3_tftrn_pagename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_pagewwds_4_tfpagejsoncontent",GXType.VarChar,200,0) ,
          new ParDef("AV63Trn_pagewwds_5_tfpagejsoncontent_sel",GXType.VarChar,200,0) ,
          new ParDef("lV64Trn_pagewwds_6_tfpagegjshtml",GXType.VarChar,200,0) ,
          new ParDef("AV65Trn_pagewwds_7_tfpagegjshtml_sel",GXType.VarChar,200,0) ,
          new ParDef("lV66Trn_pagewwds_8_tfpagegjsjson",GXType.VarChar,200,0) ,
          new ParDef("AV67Trn_pagewwds_9_tfpagegjsjson_sel",GXType.VarChar,200,0) ,
          new ParDef("lV70Trn_pagewwds_12_tfpagechildren",GXType.VarChar,200,0) ,
          new ParDef("AV71Trn_pagewwds_13_tfpagechildren_sel",GXType.VarChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00722", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00722,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00723", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00723,11, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getLongVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getLongVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((Guid[]) buf[15])[0] = rslt.getGuid(9);
                ((string[]) buf[16])[0] = rslt.getVarchar(10);
                ((Guid[]) buf[17])[0] = rslt.getGuid(11);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getLongVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getLongVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((Guid[]) buf[15])[0] = rslt.getGuid(9);
                ((string[]) buf[16])[0] = rslt.getVarchar(10);
                ((Guid[]) buf[17])[0] = rslt.getGuid(11);
                return;
       }
    }

 }

}
