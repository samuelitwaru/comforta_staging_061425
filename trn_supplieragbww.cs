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
   public class trn_supplieragbww : GXDataArea
   {
      public trn_supplieragbww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_supplieragbww( IGxContext context )
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
         ajax_req_read_hidden_sdt(GetNextPar( ), AV76ColumnsSelector);
         AV78Pgmname = GetPar( "Pgmname");
         AV24TFSupplierAgbName = GetPar( "TFSupplierAgbName");
         AV25TFSupplierAgbName_Sel = GetPar( "TFSupplierAgbName_Sel");
         AV22TFSupplierAgbTypeName = GetPar( "TFSupplierAgbTypeName");
         AV23TFSupplierAgbTypeName_Sel = GetPar( "TFSupplierAgbTypeName_Sel");
         AV28TFSupplierAgbContactName = GetPar( "TFSupplierAgbContactName");
         AV29TFSupplierAgbContactName_Sel = GetPar( "TFSupplierAgbContactName_Sel");
         AV30TFSupplierAgbPhone = GetPar( "TFSupplierAgbPhone");
         AV31TFSupplierAgbPhone_Sel = GetPar( "TFSupplierAgbPhone_Sel");
         AV32TFSupplierAgbEmail = GetPar( "TFSupplierAgbEmail");
         AV33TFSupplierAgbEmail_Sel = GetPar( "TFSupplierAgbEmail_Sel");
         AV45IsAuthorized_Display = StringUtil.StrToBool( GetPar( "IsAuthorized_Display"));
         AV47IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV49IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV60IsAuthorized_SupplierAgbName = StringUtil.StrToBool( GetPar( "IsAuthorized_SupplierAgbName"));
         AV50IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV76ColumnsSelector, AV78Pgmname, AV24TFSupplierAgbName, AV25TFSupplierAgbName_Sel, AV22TFSupplierAgbTypeName, AV23TFSupplierAgbTypeName_Sel, AV28TFSupplierAgbContactName, AV29TFSupplierAgbContactName_Sel, AV30TFSupplierAgbPhone, AV31TFSupplierAgbPhone_Sel, AV32TFSupplierAgbEmail, AV33TFSupplierAgbEmail_Sel, AV45IsAuthorized_Display, AV47IsAuthorized_Update, AV49IsAuthorized_Delete, AV60IsAuthorized_SupplierAgbName, AV50IsAuthorized_Insert) ;
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
            return "trn_supplieragbww_Execute" ;
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
         PA4A2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4A2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_supplieragbww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV78Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV78Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV45IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV45IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV47IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV47IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV49IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV49IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_SUPPLIERAGBNAME", AV60IsAuthorized_SupplierAgbName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SUPPLIERAGBNAME", GetSecureSignedToken( "", AV60IsAuthorized_SupplierAgbName, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV50IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV50IsAuthorized_Insert, context));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV76ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV76ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV78Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV78Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERAGBNAME", AV24TFSupplierAgbName);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERAGBNAME_SEL", AV25TFSupplierAgbName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERAGBTYPENAME", AV22TFSupplierAgbTypeName);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERAGBTYPENAME_SEL", AV23TFSupplierAgbTypeName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERAGBCONTACTNAME", AV28TFSupplierAgbContactName);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERAGBCONTACTNAME_SEL", AV29TFSupplierAgbContactName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERAGBPHONE", StringUtil.RTrim( AV30TFSupplierAgbPhone));
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERAGBPHONE_SEL", StringUtil.RTrim( AV31TFSupplierAgbPhone_Sel));
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERAGBEMAIL", AV32TFSupplierAgbEmail);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERAGBEMAIL_SEL", AV33TFSupplierAgbEmail_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV45IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV45IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV47IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV47IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV49IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV49IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_SUPPLIERAGBNAME", AV60IsAuthorized_SupplierAgbName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SUPPLIERAGBNAME", GetSecureSignedToken( "", AV60IsAuthorized_SupplierAgbName, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV50IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV50IsAuthorized_Insert, context));
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
            WE4A2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4A2( ) ;
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
         return formatLink("trn_supplieragbww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_SupplierAgbWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Agb Suppliers", "") ;
      }

      protected void WB4A0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_SupplierAgbWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_SupplierAgbWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, context.GetMessage( "WWP_Subscriptions_Tooltip", ""), "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_SupplierAgbWW.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWPFullTextFilter", "start", true, "", "HLP_Trn_SupplierAgbWW.htm");
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
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV76ColumnsSelector);
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
               GxWebStd.gx_hidden_field( context, "W0069"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0069"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_39_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0069"+"");
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

      protected void START4A2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Agb Suppliers", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4A0( ) ;
      }

      protected void WS4A2( )
      {
         START4A2( ) ;
         EVT4A2( ) ;
      }

      protected void EVT4A2( )
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
                              E114A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E124A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E134A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                              E144A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E154A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E164A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E174A2 ();
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
                              A49SupplierAgbId = StringUtil.StrToGuid( cgiGet( edtSupplierAgbId_Internalname));
                              A50SupplierAgbNumber = cgiGet( edtSupplierAgbNumber_Internalname);
                              A255SupplierAgbTypeId = StringUtil.StrToGuid( cgiGet( edtSupplierAgbTypeId_Internalname));
                              A51SupplierAgbName = cgiGet( edtSupplierAgbName_Internalname);
                              A256SupplierAgbTypeName = cgiGet( edtSupplierAgbTypeName_Internalname);
                              A52SupplierAgbKvkNumber = cgiGet( edtSupplierAgbKvkNumber_Internalname);
                              A306SupplierAGBAddressCountry = cgiGet( edtSupplierAGBAddressCountry_Internalname);
                              A264SupplierAgbAddressCity = cgiGet( edtSupplierAgbAddressCity_Internalname);
                              A263SupplierAgbAddressZipCode = cgiGet( edtSupplierAgbAddressZipCode_Internalname);
                              A307SupplierAgbAddressLine1 = cgiGet( edtSupplierAgbAddressLine1_Internalname);
                              A308SupplierAgbAddressLine2 = cgiGet( edtSupplierAgbAddressLine2_Internalname);
                              A55SupplierAgbContactName = cgiGet( edtSupplierAgbContactName_Internalname);
                              A56SupplierAgbPhone = cgiGet( edtSupplierAgbPhone_Internalname);
                              A349SupplierAgbPhoneCode = cgiGet( edtSupplierAgbPhoneCode_Internalname);
                              A350SupplierAgbPhoneNumber = cgiGet( edtSupplierAgbPhoneNumber_Internalname);
                              A57SupplierAgbEmail = cgiGet( edtSupplierAgbEmail_Internalname);
                              AV61SupplierAgbAddress = cgiGet( edtavSupplieragbaddress_Internalname);
                              AssignAttri("", false, edtavSupplieragbaddress_Internalname, AV61SupplierAgbAddress);
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
                                    E184A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E194A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E204A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VACTIONGROUP.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E214A2 ();
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
                        if ( nCmpId == 69 )
                        {
                           OldWwpaux_wc = cgiGet( "W0069");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0069", "", sEvt);
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

      protected void WE4A2( )
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

      protected void PA4A2( )
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
                                       WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV76ColumnsSelector ,
                                       string AV78Pgmname ,
                                       string AV24TFSupplierAgbName ,
                                       string AV25TFSupplierAgbName_Sel ,
                                       string AV22TFSupplierAgbTypeName ,
                                       string AV23TFSupplierAgbTypeName_Sel ,
                                       string AV28TFSupplierAgbContactName ,
                                       string AV29TFSupplierAgbContactName_Sel ,
                                       string AV30TFSupplierAgbPhone ,
                                       string AV31TFSupplierAgbPhone_Sel ,
                                       string AV32TFSupplierAgbEmail ,
                                       string AV33TFSupplierAgbEmail_Sel ,
                                       bool AV45IsAuthorized_Display ,
                                       bool AV47IsAuthorized_Update ,
                                       bool AV49IsAuthorized_Delete ,
                                       bool AV60IsAuthorized_SupplierAgbName ,
                                       bool AV50IsAuthorized_Insert )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF4A2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SUPPLIERAGBID", GetSecureSignedToken( "", A49SupplierAgbId, context));
         GxWebStd.gx_hidden_field( context, "SUPPLIERAGBID", A49SupplierAgbId.ToString());
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
         RF4A2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV78Pgmname = "Trn_SupplierAgbWW";
         edtavSupplieragbaddress_Enabled = 0;
      }

      protected void RF4A2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 39;
         /* Execute user event: Refresh */
         E194A2 ();
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
                                                 AV79Trn_supplieragbwwds_1_filterfulltext ,
                                                 AV81Trn_supplieragbwwds_3_tfsupplieragbname_sel ,
                                                 AV80Trn_supplieragbwwds_2_tfsupplieragbname ,
                                                 AV83Trn_supplieragbwwds_5_tfsupplieragbtypename_sel ,
                                                 AV82Trn_supplieragbwwds_4_tfsupplieragbtypename ,
                                                 AV85Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel ,
                                                 AV84Trn_supplieragbwwds_6_tfsupplieragbcontactname ,
                                                 AV87Trn_supplieragbwwds_9_tfsupplieragbphone_sel ,
                                                 AV86Trn_supplieragbwwds_8_tfsupplieragbphone ,
                                                 AV89Trn_supplieragbwwds_11_tfsupplieragbemail_sel ,
                                                 AV88Trn_supplieragbwwds_10_tfsupplieragbemail ,
                                                 A51SupplierAgbName ,
                                                 A256SupplierAgbTypeName ,
                                                 A55SupplierAgbContactName ,
                                                 A56SupplierAgbPhone ,
                                                 A57SupplierAgbEmail ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV79Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Trn_supplieragbwwds_1_filterfulltext), "%", "");
            lV79Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Trn_supplieragbwwds_1_filterfulltext), "%", "");
            lV79Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Trn_supplieragbwwds_1_filterfulltext), "%", "");
            lV79Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Trn_supplieragbwwds_1_filterfulltext), "%", "");
            lV79Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Trn_supplieragbwwds_1_filterfulltext), "%", "");
            lV80Trn_supplieragbwwds_2_tfsupplieragbname = StringUtil.Concat( StringUtil.RTrim( AV80Trn_supplieragbwwds_2_tfsupplieragbname), "%", "");
            lV82Trn_supplieragbwwds_4_tfsupplieragbtypename = StringUtil.Concat( StringUtil.RTrim( AV82Trn_supplieragbwwds_4_tfsupplieragbtypename), "%", "");
            lV84Trn_supplieragbwwds_6_tfsupplieragbcontactname = StringUtil.Concat( StringUtil.RTrim( AV84Trn_supplieragbwwds_6_tfsupplieragbcontactname), "%", "");
            lV86Trn_supplieragbwwds_8_tfsupplieragbphone = StringUtil.PadR( StringUtil.RTrim( AV86Trn_supplieragbwwds_8_tfsupplieragbphone), 20, "%");
            lV88Trn_supplieragbwwds_10_tfsupplieragbemail = StringUtil.Concat( StringUtil.RTrim( AV88Trn_supplieragbwwds_10_tfsupplieragbemail), "%", "");
            /* Using cursor H004A2 */
            pr_default.execute(0, new Object[] {lV79Trn_supplieragbwwds_1_filterfulltext, lV79Trn_supplieragbwwds_1_filterfulltext, lV79Trn_supplieragbwwds_1_filterfulltext, lV79Trn_supplieragbwwds_1_filterfulltext, lV79Trn_supplieragbwwds_1_filterfulltext, lV80Trn_supplieragbwwds_2_tfsupplieragbname, AV81Trn_supplieragbwwds_3_tfsupplieragbname_sel, lV82Trn_supplieragbwwds_4_tfsupplieragbtypename, AV83Trn_supplieragbwwds_5_tfsupplieragbtypename_sel, lV84Trn_supplieragbwwds_6_tfsupplieragbcontactname, AV85Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel, lV86Trn_supplieragbwwds_8_tfsupplieragbphone, AV87Trn_supplieragbwwds_9_tfsupplieragbphone_sel, lV88Trn_supplieragbwwds_10_tfsupplieragbemail, AV89Trn_supplieragbwwds_11_tfsupplieragbemail_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_39_idx = 1;
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A57SupplierAgbEmail = H004A2_A57SupplierAgbEmail[0];
               A350SupplierAgbPhoneNumber = H004A2_A350SupplierAgbPhoneNumber[0];
               A349SupplierAgbPhoneCode = H004A2_A349SupplierAgbPhoneCode[0];
               A56SupplierAgbPhone = H004A2_A56SupplierAgbPhone[0];
               A55SupplierAgbContactName = H004A2_A55SupplierAgbContactName[0];
               A308SupplierAgbAddressLine2 = H004A2_A308SupplierAgbAddressLine2[0];
               A307SupplierAgbAddressLine1 = H004A2_A307SupplierAgbAddressLine1[0];
               A263SupplierAgbAddressZipCode = H004A2_A263SupplierAgbAddressZipCode[0];
               A264SupplierAgbAddressCity = H004A2_A264SupplierAgbAddressCity[0];
               A306SupplierAGBAddressCountry = H004A2_A306SupplierAGBAddressCountry[0];
               A52SupplierAgbKvkNumber = H004A2_A52SupplierAgbKvkNumber[0];
               A256SupplierAgbTypeName = H004A2_A256SupplierAgbTypeName[0];
               A51SupplierAgbName = H004A2_A51SupplierAgbName[0];
               A255SupplierAgbTypeId = H004A2_A255SupplierAgbTypeId[0];
               A50SupplierAgbNumber = H004A2_A50SupplierAgbNumber[0];
               A49SupplierAgbId = H004A2_A49SupplierAgbId[0];
               A256SupplierAgbTypeName = H004A2_A256SupplierAgbTypeName[0];
               /* Execute user event: Grid.Load */
               E204A2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 39;
            WB4A0( ) ;
         }
         bGXsfl_39_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4A2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV78Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV78Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV45IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV45IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV47IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV47IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV49IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV49IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_SUPPLIERAGBNAME", AV60IsAuthorized_SupplierAgbName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SUPPLIERAGBNAME", GetSecureSignedToken( "", AV60IsAuthorized_SupplierAgbName, context));
         GxWebStd.gx_hidden_field( context, "gxhash_SUPPLIERAGBID"+"_"+sGXsfl_39_idx, GetSecureSignedToken( sGXsfl_39_idx, A49SupplierAgbId, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV50IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV50IsAuthorized_Insert, context));
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
         AV79Trn_supplieragbwwds_1_filterfulltext = AV15FilterFullText;
         AV80Trn_supplieragbwwds_2_tfsupplieragbname = AV24TFSupplierAgbName;
         AV81Trn_supplieragbwwds_3_tfsupplieragbname_sel = AV25TFSupplierAgbName_Sel;
         AV82Trn_supplieragbwwds_4_tfsupplieragbtypename = AV22TFSupplierAgbTypeName;
         AV83Trn_supplieragbwwds_5_tfsupplieragbtypename_sel = AV23TFSupplierAgbTypeName_Sel;
         AV84Trn_supplieragbwwds_6_tfsupplieragbcontactname = AV28TFSupplierAgbContactName;
         AV85Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel = AV29TFSupplierAgbContactName_Sel;
         AV86Trn_supplieragbwwds_8_tfsupplieragbphone = AV30TFSupplierAgbPhone;
         AV87Trn_supplieragbwwds_9_tfsupplieragbphone_sel = AV31TFSupplierAgbPhone_Sel;
         AV88Trn_supplieragbwwds_10_tfsupplieragbemail = AV32TFSupplierAgbEmail;
         AV89Trn_supplieragbwwds_11_tfsupplieragbemail_sel = AV33TFSupplierAgbEmail_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV79Trn_supplieragbwwds_1_filterfulltext ,
                                              AV81Trn_supplieragbwwds_3_tfsupplieragbname_sel ,
                                              AV80Trn_supplieragbwwds_2_tfsupplieragbname ,
                                              AV83Trn_supplieragbwwds_5_tfsupplieragbtypename_sel ,
                                              AV82Trn_supplieragbwwds_4_tfsupplieragbtypename ,
                                              AV85Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel ,
                                              AV84Trn_supplieragbwwds_6_tfsupplieragbcontactname ,
                                              AV87Trn_supplieragbwwds_9_tfsupplieragbphone_sel ,
                                              AV86Trn_supplieragbwwds_8_tfsupplieragbphone ,
                                              AV89Trn_supplieragbwwds_11_tfsupplieragbemail_sel ,
                                              AV88Trn_supplieragbwwds_10_tfsupplieragbemail ,
                                              A51SupplierAgbName ,
                                              A256SupplierAgbTypeName ,
                                              A55SupplierAgbContactName ,
                                              A56SupplierAgbPhone ,
                                              A57SupplierAgbEmail ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV79Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Trn_supplieragbwwds_1_filterfulltext), "%", "");
         lV79Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Trn_supplieragbwwds_1_filterfulltext), "%", "");
         lV79Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Trn_supplieragbwwds_1_filterfulltext), "%", "");
         lV79Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Trn_supplieragbwwds_1_filterfulltext), "%", "");
         lV79Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Trn_supplieragbwwds_1_filterfulltext), "%", "");
         lV80Trn_supplieragbwwds_2_tfsupplieragbname = StringUtil.Concat( StringUtil.RTrim( AV80Trn_supplieragbwwds_2_tfsupplieragbname), "%", "");
         lV82Trn_supplieragbwwds_4_tfsupplieragbtypename = StringUtil.Concat( StringUtil.RTrim( AV82Trn_supplieragbwwds_4_tfsupplieragbtypename), "%", "");
         lV84Trn_supplieragbwwds_6_tfsupplieragbcontactname = StringUtil.Concat( StringUtil.RTrim( AV84Trn_supplieragbwwds_6_tfsupplieragbcontactname), "%", "");
         lV86Trn_supplieragbwwds_8_tfsupplieragbphone = StringUtil.PadR( StringUtil.RTrim( AV86Trn_supplieragbwwds_8_tfsupplieragbphone), 20, "%");
         lV88Trn_supplieragbwwds_10_tfsupplieragbemail = StringUtil.Concat( StringUtil.RTrim( AV88Trn_supplieragbwwds_10_tfsupplieragbemail), "%", "");
         /* Using cursor H004A3 */
         pr_default.execute(1, new Object[] {lV79Trn_supplieragbwwds_1_filterfulltext, lV79Trn_supplieragbwwds_1_filterfulltext, lV79Trn_supplieragbwwds_1_filterfulltext, lV79Trn_supplieragbwwds_1_filterfulltext, lV79Trn_supplieragbwwds_1_filterfulltext, lV80Trn_supplieragbwwds_2_tfsupplieragbname, AV81Trn_supplieragbwwds_3_tfsupplieragbname_sel, lV82Trn_supplieragbwwds_4_tfsupplieragbtypename, AV83Trn_supplieragbwwds_5_tfsupplieragbtypename_sel, lV84Trn_supplieragbwwds_6_tfsupplieragbcontactname, AV85Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel, lV86Trn_supplieragbwwds_8_tfsupplieragbphone, AV87Trn_supplieragbwwds_9_tfsupplieragbphone_sel, lV88Trn_supplieragbwwds_10_tfsupplieragbemail, AV89Trn_supplieragbwwds_11_tfsupplieragbemail_sel});
         GRID_nRecordCount = H004A3_AGRID_nRecordCount[0];
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
         AV79Trn_supplieragbwwds_1_filterfulltext = AV15FilterFullText;
         AV80Trn_supplieragbwwds_2_tfsupplieragbname = AV24TFSupplierAgbName;
         AV81Trn_supplieragbwwds_3_tfsupplieragbname_sel = AV25TFSupplierAgbName_Sel;
         AV82Trn_supplieragbwwds_4_tfsupplieragbtypename = AV22TFSupplierAgbTypeName;
         AV83Trn_supplieragbwwds_5_tfsupplieragbtypename_sel = AV23TFSupplierAgbTypeName_Sel;
         AV84Trn_supplieragbwwds_6_tfsupplieragbcontactname = AV28TFSupplierAgbContactName;
         AV85Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel = AV29TFSupplierAgbContactName_Sel;
         AV86Trn_supplieragbwwds_8_tfsupplieragbphone = AV30TFSupplierAgbPhone;
         AV87Trn_supplieragbwwds_9_tfsupplieragbphone_sel = AV31TFSupplierAgbPhone_Sel;
         AV88Trn_supplieragbwwds_10_tfsupplieragbemail = AV32TFSupplierAgbEmail;
         AV89Trn_supplieragbwwds_11_tfsupplieragbemail_sel = AV33TFSupplierAgbEmail_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV76ColumnsSelector, AV78Pgmname, AV24TFSupplierAgbName, AV25TFSupplierAgbName_Sel, AV22TFSupplierAgbTypeName, AV23TFSupplierAgbTypeName_Sel, AV28TFSupplierAgbContactName, AV29TFSupplierAgbContactName_Sel, AV30TFSupplierAgbPhone, AV31TFSupplierAgbPhone_Sel, AV32TFSupplierAgbEmail, AV33TFSupplierAgbEmail_Sel, AV45IsAuthorized_Display, AV47IsAuthorized_Update, AV49IsAuthorized_Delete, AV60IsAuthorized_SupplierAgbName, AV50IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV79Trn_supplieragbwwds_1_filterfulltext = AV15FilterFullText;
         AV80Trn_supplieragbwwds_2_tfsupplieragbname = AV24TFSupplierAgbName;
         AV81Trn_supplieragbwwds_3_tfsupplieragbname_sel = AV25TFSupplierAgbName_Sel;
         AV82Trn_supplieragbwwds_4_tfsupplieragbtypename = AV22TFSupplierAgbTypeName;
         AV83Trn_supplieragbwwds_5_tfsupplieragbtypename_sel = AV23TFSupplierAgbTypeName_Sel;
         AV84Trn_supplieragbwwds_6_tfsupplieragbcontactname = AV28TFSupplierAgbContactName;
         AV85Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel = AV29TFSupplierAgbContactName_Sel;
         AV86Trn_supplieragbwwds_8_tfsupplieragbphone = AV30TFSupplierAgbPhone;
         AV87Trn_supplieragbwwds_9_tfsupplieragbphone_sel = AV31TFSupplierAgbPhone_Sel;
         AV88Trn_supplieragbwwds_10_tfsupplieragbemail = AV32TFSupplierAgbEmail;
         AV89Trn_supplieragbwwds_11_tfsupplieragbemail_sel = AV33TFSupplierAgbEmail_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV76ColumnsSelector, AV78Pgmname, AV24TFSupplierAgbName, AV25TFSupplierAgbName_Sel, AV22TFSupplierAgbTypeName, AV23TFSupplierAgbTypeName_Sel, AV28TFSupplierAgbContactName, AV29TFSupplierAgbContactName_Sel, AV30TFSupplierAgbPhone, AV31TFSupplierAgbPhone_Sel, AV32TFSupplierAgbEmail, AV33TFSupplierAgbEmail_Sel, AV45IsAuthorized_Display, AV47IsAuthorized_Update, AV49IsAuthorized_Delete, AV60IsAuthorized_SupplierAgbName, AV50IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV79Trn_supplieragbwwds_1_filterfulltext = AV15FilterFullText;
         AV80Trn_supplieragbwwds_2_tfsupplieragbname = AV24TFSupplierAgbName;
         AV81Trn_supplieragbwwds_3_tfsupplieragbname_sel = AV25TFSupplierAgbName_Sel;
         AV82Trn_supplieragbwwds_4_tfsupplieragbtypename = AV22TFSupplierAgbTypeName;
         AV83Trn_supplieragbwwds_5_tfsupplieragbtypename_sel = AV23TFSupplierAgbTypeName_Sel;
         AV84Trn_supplieragbwwds_6_tfsupplieragbcontactname = AV28TFSupplierAgbContactName;
         AV85Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel = AV29TFSupplierAgbContactName_Sel;
         AV86Trn_supplieragbwwds_8_tfsupplieragbphone = AV30TFSupplierAgbPhone;
         AV87Trn_supplieragbwwds_9_tfsupplieragbphone_sel = AV31TFSupplierAgbPhone_Sel;
         AV88Trn_supplieragbwwds_10_tfsupplieragbemail = AV32TFSupplierAgbEmail;
         AV89Trn_supplieragbwwds_11_tfsupplieragbemail_sel = AV33TFSupplierAgbEmail_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV76ColumnsSelector, AV78Pgmname, AV24TFSupplierAgbName, AV25TFSupplierAgbName_Sel, AV22TFSupplierAgbTypeName, AV23TFSupplierAgbTypeName_Sel, AV28TFSupplierAgbContactName, AV29TFSupplierAgbContactName_Sel, AV30TFSupplierAgbPhone, AV31TFSupplierAgbPhone_Sel, AV32TFSupplierAgbEmail, AV33TFSupplierAgbEmail_Sel, AV45IsAuthorized_Display, AV47IsAuthorized_Update, AV49IsAuthorized_Delete, AV60IsAuthorized_SupplierAgbName, AV50IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV79Trn_supplieragbwwds_1_filterfulltext = AV15FilterFullText;
         AV80Trn_supplieragbwwds_2_tfsupplieragbname = AV24TFSupplierAgbName;
         AV81Trn_supplieragbwwds_3_tfsupplieragbname_sel = AV25TFSupplierAgbName_Sel;
         AV82Trn_supplieragbwwds_4_tfsupplieragbtypename = AV22TFSupplierAgbTypeName;
         AV83Trn_supplieragbwwds_5_tfsupplieragbtypename_sel = AV23TFSupplierAgbTypeName_Sel;
         AV84Trn_supplieragbwwds_6_tfsupplieragbcontactname = AV28TFSupplierAgbContactName;
         AV85Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel = AV29TFSupplierAgbContactName_Sel;
         AV86Trn_supplieragbwwds_8_tfsupplieragbphone = AV30TFSupplierAgbPhone;
         AV87Trn_supplieragbwwds_9_tfsupplieragbphone_sel = AV31TFSupplierAgbPhone_Sel;
         AV88Trn_supplieragbwwds_10_tfsupplieragbemail = AV32TFSupplierAgbEmail;
         AV89Trn_supplieragbwwds_11_tfsupplieragbemail_sel = AV33TFSupplierAgbEmail_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV76ColumnsSelector, AV78Pgmname, AV24TFSupplierAgbName, AV25TFSupplierAgbName_Sel, AV22TFSupplierAgbTypeName, AV23TFSupplierAgbTypeName_Sel, AV28TFSupplierAgbContactName, AV29TFSupplierAgbContactName_Sel, AV30TFSupplierAgbPhone, AV31TFSupplierAgbPhone_Sel, AV32TFSupplierAgbEmail, AV33TFSupplierAgbEmail_Sel, AV45IsAuthorized_Display, AV47IsAuthorized_Update, AV49IsAuthorized_Delete, AV60IsAuthorized_SupplierAgbName, AV50IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV79Trn_supplieragbwwds_1_filterfulltext = AV15FilterFullText;
         AV80Trn_supplieragbwwds_2_tfsupplieragbname = AV24TFSupplierAgbName;
         AV81Trn_supplieragbwwds_3_tfsupplieragbname_sel = AV25TFSupplierAgbName_Sel;
         AV82Trn_supplieragbwwds_4_tfsupplieragbtypename = AV22TFSupplierAgbTypeName;
         AV83Trn_supplieragbwwds_5_tfsupplieragbtypename_sel = AV23TFSupplierAgbTypeName_Sel;
         AV84Trn_supplieragbwwds_6_tfsupplieragbcontactname = AV28TFSupplierAgbContactName;
         AV85Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel = AV29TFSupplierAgbContactName_Sel;
         AV86Trn_supplieragbwwds_8_tfsupplieragbphone = AV30TFSupplierAgbPhone;
         AV87Trn_supplieragbwwds_9_tfsupplieragbphone_sel = AV31TFSupplierAgbPhone_Sel;
         AV88Trn_supplieragbwwds_10_tfsupplieragbemail = AV32TFSupplierAgbEmail;
         AV89Trn_supplieragbwwds_11_tfsupplieragbemail_sel = AV33TFSupplierAgbEmail_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV76ColumnsSelector, AV78Pgmname, AV24TFSupplierAgbName, AV25TFSupplierAgbName_Sel, AV22TFSupplierAgbTypeName, AV23TFSupplierAgbTypeName_Sel, AV28TFSupplierAgbContactName, AV29TFSupplierAgbContactName_Sel, AV30TFSupplierAgbPhone, AV31TFSupplierAgbPhone_Sel, AV32TFSupplierAgbEmail, AV33TFSupplierAgbEmail_Sel, AV45IsAuthorized_Display, AV47IsAuthorized_Update, AV49IsAuthorized_Delete, AV60IsAuthorized_SupplierAgbName, AV50IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV78Pgmname = "Trn_SupplierAgbWW";
         edtavSupplieragbaddress_Enabled = 0;
         edtSupplierAgbId_Enabled = 0;
         edtSupplierAgbNumber_Enabled = 0;
         edtSupplierAgbTypeId_Enabled = 0;
         edtSupplierAgbName_Enabled = 0;
         edtSupplierAgbTypeName_Enabled = 0;
         edtSupplierAgbKvkNumber_Enabled = 0;
         edtSupplierAGBAddressCountry_Enabled = 0;
         edtSupplierAgbAddressCity_Enabled = 0;
         edtSupplierAgbAddressZipCode_Enabled = 0;
         edtSupplierAgbAddressLine1_Enabled = 0;
         edtSupplierAgbAddressLine2_Enabled = 0;
         edtSupplierAgbContactName_Enabled = 0;
         edtSupplierAgbPhone_Enabled = 0;
         edtSupplierAgbPhoneCode_Enabled = 0;
         edtSupplierAgbPhoneNumber_Enabled = 0;
         edtSupplierAgbEmail_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4A0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E184A2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV17ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV34DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV76ColumnsSelector);
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
            AV15FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            /* Read subfile selected row values. */
            nGXsfl_39_idx = (int)(Math.Round(context.localUtil.CToN( cgiGet( subGrid_Internalname+"_ROW"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
            if ( nGXsfl_39_idx > 0 )
            {
               A49SupplierAgbId = StringUtil.StrToGuid( cgiGet( edtSupplierAgbId_Internalname));
               A50SupplierAgbNumber = cgiGet( edtSupplierAgbNumber_Internalname);
               A255SupplierAgbTypeId = StringUtil.StrToGuid( cgiGet( edtSupplierAgbTypeId_Internalname));
               A51SupplierAgbName = cgiGet( edtSupplierAgbName_Internalname);
               A256SupplierAgbTypeName = cgiGet( edtSupplierAgbTypeName_Internalname);
               A52SupplierAgbKvkNumber = cgiGet( edtSupplierAgbKvkNumber_Internalname);
               A306SupplierAGBAddressCountry = cgiGet( edtSupplierAGBAddressCountry_Internalname);
               A264SupplierAgbAddressCity = cgiGet( edtSupplierAgbAddressCity_Internalname);
               A263SupplierAgbAddressZipCode = cgiGet( edtSupplierAgbAddressZipCode_Internalname);
               A307SupplierAgbAddressLine1 = cgiGet( edtSupplierAgbAddressLine1_Internalname);
               A308SupplierAgbAddressLine2 = cgiGet( edtSupplierAgbAddressLine2_Internalname);
               A55SupplierAgbContactName = cgiGet( edtSupplierAgbContactName_Internalname);
               A56SupplierAgbPhone = cgiGet( edtSupplierAgbPhone_Internalname);
               A349SupplierAgbPhoneCode = cgiGet( edtSupplierAgbPhoneCode_Internalname);
               A350SupplierAgbPhoneNumber = cgiGet( edtSupplierAgbPhoneNumber_Internalname);
               A57SupplierAgbEmail = cgiGet( edtSupplierAgbEmail_Internalname);
               AV61SupplierAgbAddress = cgiGet( edtavSupplieragbaddress_Internalname);
               AssignAttri("", false, edtavSupplieragbaddress_Internalname, AV61SupplierAgbAddress);
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
         E184A2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E184A2( )
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
         GXt_boolean1 = AV60IsAuthorized_SupplierAgbName;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_supplieragbview_Execute", out  GXt_boolean1) ;
         AV60IsAuthorized_SupplierAgbName = GXt_boolean1;
         AssignAttri("", false, "AV60IsAuthorized_SupplierAgbName", AV60IsAuthorized_SupplierAgbName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SUPPLIERAGBNAME", GetSecureSignedToken( "", AV60IsAuthorized_SupplierAgbName, context));
         AV35GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV36GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV35GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = context.GetMessage( "Agb Suppliers", "");
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV34DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV34DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E194A2( )
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
         if ( StringUtil.StrCmp(AV16Session.Get("Trn_SupplierAgbWWColumnsSelector"), "") != 0 )
         {
            AV74ColumnsSelectorXML = AV16Session.Get("Trn_SupplierAgbWWColumnsSelector");
            AV76ColumnsSelector.FromXml(AV74ColumnsSelectorXML, null, "", "");
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
         edtSupplierAgbName_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV76ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSupplierAgbName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierAgbName_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSupplierAgbTypeName_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV76ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSupplierAgbTypeName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierAgbTypeName_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSupplierAgbContactName_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV76ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSupplierAgbContactName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierAgbContactName_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSupplierAgbPhone_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV76ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSupplierAgbPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierAgbPhone_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSupplierAgbEmail_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV76ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSupplierAgbEmail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierAgbEmail_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtavSupplieragbaddress_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV76ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavSupplieragbaddress_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSupplieragbaddress_Visible), 5, 0), !bGXsfl_39_Refreshing);
         AV38GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV38GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV38GridCurrentPage), 10, 0));
         AV39GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV39GridPageCount", StringUtil.LTrimStr( (decimal)(AV39GridPageCount), 10, 0));
         GXt_char3 = AV40GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV78Pgmname, out  GXt_char3) ;
         AV40GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV40GridAppliedFilters", AV40GridAppliedFilters);
         AV79Trn_supplieragbwwds_1_filterfulltext = AV15FilterFullText;
         AV80Trn_supplieragbwwds_2_tfsupplieragbname = AV24TFSupplierAgbName;
         AV81Trn_supplieragbwwds_3_tfsupplieragbname_sel = AV25TFSupplierAgbName_Sel;
         AV82Trn_supplieragbwwds_4_tfsupplieragbtypename = AV22TFSupplierAgbTypeName;
         AV83Trn_supplieragbwwds_5_tfsupplieragbtypename_sel = AV23TFSupplierAgbTypeName_Sel;
         AV84Trn_supplieragbwwds_6_tfsupplieragbcontactname = AV28TFSupplierAgbContactName;
         AV85Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel = AV29TFSupplierAgbContactName_Sel;
         AV86Trn_supplieragbwwds_8_tfsupplieragbphone = AV30TFSupplierAgbPhone;
         AV87Trn_supplieragbwwds_9_tfsupplieragbphone_sel = AV31TFSupplierAgbPhone_Sel;
         AV88Trn_supplieragbwwds_10_tfsupplieragbemail = AV32TFSupplierAgbEmail;
         AV89Trn_supplieragbwwds_11_tfsupplieragbemail_sel = AV33TFSupplierAgbEmail_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV76ColumnsSelector", AV76ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E124A2( )
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

      protected void E134A2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E154A2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SupplierAgbName") == 0 )
            {
               AV24TFSupplierAgbName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV24TFSupplierAgbName", AV24TFSupplierAgbName);
               AV25TFSupplierAgbName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV25TFSupplierAgbName_Sel", AV25TFSupplierAgbName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SupplierAgbTypeName") == 0 )
            {
               AV22TFSupplierAgbTypeName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV22TFSupplierAgbTypeName", AV22TFSupplierAgbTypeName);
               AV23TFSupplierAgbTypeName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV23TFSupplierAgbTypeName_Sel", AV23TFSupplierAgbTypeName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SupplierAgbContactName") == 0 )
            {
               AV28TFSupplierAgbContactName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV28TFSupplierAgbContactName", AV28TFSupplierAgbContactName);
               AV29TFSupplierAgbContactName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV29TFSupplierAgbContactName_Sel", AV29TFSupplierAgbContactName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SupplierAgbPhone") == 0 )
            {
               AV30TFSupplierAgbPhone = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV30TFSupplierAgbPhone", AV30TFSupplierAgbPhone);
               AV31TFSupplierAgbPhone_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV31TFSupplierAgbPhone_Sel", AV31TFSupplierAgbPhone_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SupplierAgbEmail") == 0 )
            {
               AV32TFSupplierAgbEmail = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV32TFSupplierAgbEmail", AV32TFSupplierAgbEmail);
               AV33TFSupplierAgbEmail_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV33TFSupplierAgbEmail_Sel", AV33TFSupplierAgbEmail_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E204A2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         GXt_char3 = AV61SupplierAgbAddress;
         new prc_concatenateaddress(context ).execute(  A306SupplierAGBAddressCountry,  A264SupplierAgbAddressCity,  A263SupplierAgbAddressZipCode,  A307SupplierAgbAddressLine1,  A308SupplierAgbAddressLine2, out  GXt_char3) ;
         AV61SupplierAgbAddress = GXt_char3;
         AssignAttri("", false, edtavSupplieragbaddress_Internalname, AV61SupplierAgbAddress);
         cmbavActiongroup.removeAllItems();
         cmbavActiongroup.addItem("0", ";fas fa-bars", 0);
         if ( AV45IsAuthorized_Display )
         {
            cmbavActiongroup.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
         }
         if ( AV47IsAuthorized_Update )
         {
            cmbavActiongroup.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "Edit", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
         }
         if ( AV49IsAuthorized_Delete )
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
         if ( AV60IsAuthorized_SupplierAgbName )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_supplieragbview.aspx"+UrlEncode(A49SupplierAgbId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            edtSupplierAgbName_Link = formatLink("trn_supplieragbview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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

      protected void E164A2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV74ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV76ColumnsSelector.FromJSonString(AV74ColumnsSelectorXML, null);
         new WorkWithPlus.workwithplus_web.savecolumnsselectorstate(context ).execute(  "Trn_SupplierAgbWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV74ColumnsSelectorXML)) ? "" : AV76ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV76ColumnsSelector", AV76ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E114A2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("Trn_SupplierAgbWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV78Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV19ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("Trn_SupplierAgbWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV19ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV18ManageFiltersXml;
            new WorkWithPlus.workwithplus_web.getfilterbyname(context ).execute(  "Trn_SupplierAgbWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
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
               new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV78Pgmname+"GridState",  AV18ManageFiltersXml) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV76ColumnsSelector", AV76ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
      }

      protected void E214A2( )
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
         AV72ActionGroup = 0;
         AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV72ActionGroup), 4, 0));
         /*  Sending Event outputs  */
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV72ActionGroup), 4, 0));
         AssignProp("", false, cmbavActiongroup_Internalname, "Values", cmbavActiongroup.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV76ColumnsSelector", AV76ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E174A2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV50IsAuthorized_Insert )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_supplieragb.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(Guid.Empty.ToString());
            CallWebObject(formatLink("trn_supplieragb.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV76ColumnsSelector", AV76ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E144A2( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0069",(string)"",(string)"Trn_SupplierAgb",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0069"+"");
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
         AV76ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV76ColumnsSelector,  "SupplierAgbName",  "",  "Name",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV76ColumnsSelector,  "SupplierAgbTypeName",  "",  "Category",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV76ColumnsSelector,  "SupplierAgbContactName",  "",  "Contact Person",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV76ColumnsSelector,  "SupplierAgbPhone",  "",  "Phone",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV76ColumnsSelector,  "SupplierAgbEmail",  "",  "Email",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV76ColumnsSelector,  "&SupplierAgbAddress",  "",  "Address",  true,  "") ;
         GXt_char3 = AV75UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "Trn_SupplierAgbWWColumnsSelector", out  GXt_char3) ;
         AV75UserCustomValue = GXt_char3;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV75UserCustomValue)) ) )
         {
            AV77ColumnsSelectorAux.FromXml(AV75UserCustomValue, null, "", "");
            new WorkWithPlus.workwithplus_web.wwp_columnselector_updatecolumns(context ).execute( ref  AV77ColumnsSelectorAux, ref  AV76ColumnsSelector) ;
         }
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV45IsAuthorized_Display;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_supplieragbview_Execute", out  GXt_boolean1) ;
         AV45IsAuthorized_Display = GXt_boolean1;
         AssignAttri("", false, "AV45IsAuthorized_Display", AV45IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV45IsAuthorized_Display, context));
         GXt_boolean1 = AV47IsAuthorized_Update;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_supplieragb_Update", out  GXt_boolean1) ;
         AV47IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV47IsAuthorized_Update", AV47IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV47IsAuthorized_Update, context));
         GXt_boolean1 = AV49IsAuthorized_Delete;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_supplieragb_Delete", out  GXt_boolean1) ;
         AV49IsAuthorized_Delete = GXt_boolean1;
         AssignAttri("", false, "AV49IsAuthorized_Delete", AV49IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV49IsAuthorized_Delete, context));
         GXt_boolean1 = AV50IsAuthorized_Insert;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_supplieragb_Insert", out  GXt_boolean1) ;
         AV50IsAuthorized_Insert = GXt_boolean1;
         AssignAttri("", false, "AV50IsAuthorized_Insert", AV50IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV50IsAuthorized_Insert, context));
         if ( ! ( AV50IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
         if ( ! ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "Trn_SupplierAgb",  1) ) )
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
         new WorkWithPlus.workwithplus_web.wwp_managefiltersloadsavedfilters(context ).execute(  "Trn_SupplierAgbWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV17ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S182( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV24TFSupplierAgbName = "";
         AssignAttri("", false, "AV24TFSupplierAgbName", AV24TFSupplierAgbName);
         AV25TFSupplierAgbName_Sel = "";
         AssignAttri("", false, "AV25TFSupplierAgbName_Sel", AV25TFSupplierAgbName_Sel);
         AV22TFSupplierAgbTypeName = "";
         AssignAttri("", false, "AV22TFSupplierAgbTypeName", AV22TFSupplierAgbTypeName);
         AV23TFSupplierAgbTypeName_Sel = "";
         AssignAttri("", false, "AV23TFSupplierAgbTypeName_Sel", AV23TFSupplierAgbTypeName_Sel);
         AV28TFSupplierAgbContactName = "";
         AssignAttri("", false, "AV28TFSupplierAgbContactName", AV28TFSupplierAgbContactName);
         AV29TFSupplierAgbContactName_Sel = "";
         AssignAttri("", false, "AV29TFSupplierAgbContactName_Sel", AV29TFSupplierAgbContactName_Sel);
         AV30TFSupplierAgbPhone = "";
         AssignAttri("", false, "AV30TFSupplierAgbPhone", AV30TFSupplierAgbPhone);
         AV31TFSupplierAgbPhone_Sel = "";
         AssignAttri("", false, "AV31TFSupplierAgbPhone_Sel", AV31TFSupplierAgbPhone_Sel);
         AV32TFSupplierAgbEmail = "";
         AssignAttri("", false, "AV32TFSupplierAgbEmail", AV32TFSupplierAgbEmail);
         AV33TFSupplierAgbEmail_Sel = "";
         AssignAttri("", false, "AV33TFSupplierAgbEmail_Sel", AV33TFSupplierAgbEmail_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S202( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         if ( AV45IsAuthorized_Display )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_supplieragbview.aspx"+UrlEncode(A49SupplierAgbId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            CallWebObject(formatLink("trn_supplieragbview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
         if ( AV47IsAuthorized_Update )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_supplieragb.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(A49SupplierAgbId.ToString());
            CallWebObject(formatLink("trn_supplieragb.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
         if ( AV49IsAuthorized_Delete )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_supplieragb.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(A49SupplierAgbId.ToString());
            CallWebObject(formatLink("trn_supplieragb.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
         if ( StringUtil.StrCmp(AV16Session.Get(AV78Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV78Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV16Session.Get(AV78Pgmname+"GridState"), null, "", "");
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
         AV90GXV1 = 1;
         while ( AV90GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV90GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBNAME") == 0 )
            {
               AV24TFSupplierAgbName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV24TFSupplierAgbName", AV24TFSupplierAgbName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBNAME_SEL") == 0 )
            {
               AV25TFSupplierAgbName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV25TFSupplierAgbName_Sel", AV25TFSupplierAgbName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBTYPENAME") == 0 )
            {
               AV22TFSupplierAgbTypeName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV22TFSupplierAgbTypeName", AV22TFSupplierAgbTypeName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBTYPENAME_SEL") == 0 )
            {
               AV23TFSupplierAgbTypeName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV23TFSupplierAgbTypeName_Sel", AV23TFSupplierAgbTypeName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBCONTACTNAME") == 0 )
            {
               AV28TFSupplierAgbContactName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV28TFSupplierAgbContactName", AV28TFSupplierAgbContactName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBCONTACTNAME_SEL") == 0 )
            {
               AV29TFSupplierAgbContactName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV29TFSupplierAgbContactName_Sel", AV29TFSupplierAgbContactName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBPHONE") == 0 )
            {
               AV30TFSupplierAgbPhone = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV30TFSupplierAgbPhone", AV30TFSupplierAgbPhone);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBPHONE_SEL") == 0 )
            {
               AV31TFSupplierAgbPhone_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV31TFSupplierAgbPhone_Sel", AV31TFSupplierAgbPhone_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBEMAIL") == 0 )
            {
               AV32TFSupplierAgbEmail = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV32TFSupplierAgbEmail", AV32TFSupplierAgbEmail);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBEMAIL_SEL") == 0 )
            {
               AV33TFSupplierAgbEmail_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV33TFSupplierAgbEmail_Sel", AV33TFSupplierAgbEmail_Sel);
            }
            AV90GXV1 = (int)(AV90GXV1+1);
         }
         GXt_char3 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV25TFSupplierAgbName_Sel)),  AV25TFSupplierAgbName_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV23TFSupplierAgbTypeName_Sel)),  AV23TFSupplierAgbTypeName_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV29TFSupplierAgbContactName_Sel)),  AV29TFSupplierAgbContactName_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV31TFSupplierAgbPhone_Sel)),  AV31TFSupplierAgbPhone_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV33TFSupplierAgbEmail_Sel)),  AV33TFSupplierAgbEmail_Sel, out  GXt_char8) ;
         Ddo_grid_Selectedvalue_set = GXt_char3+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char8 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV24TFSupplierAgbName)),  AV24TFSupplierAgbName, out  GXt_char8) ;
         GXt_char7 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV22TFSupplierAgbTypeName)),  AV22TFSupplierAgbTypeName, out  GXt_char7) ;
         GXt_char6 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFSupplierAgbContactName)),  AV28TFSupplierAgbContactName, out  GXt_char6) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV30TFSupplierAgbPhone)),  AV30TFSupplierAgbPhone, out  GXt_char5) ;
         GXt_char3 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV32TFSupplierAgbEmail)),  AV32TFSupplierAgbEmail, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = GXt_char8+"|"+GXt_char7+"|"+GXt_char6+"|"+GXt_char5+"|"+GXt_char3;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV16Session.Get(AV78Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFSUPPLIERAGBNAME",  context.GetMessage( "Name", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV24TFSupplierAgbName)),  0,  AV24TFSupplierAgbName,  AV24TFSupplierAgbName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV25TFSupplierAgbName_Sel)),  AV25TFSupplierAgbName_Sel,  AV25TFSupplierAgbName_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFSUPPLIERAGBTYPENAME",  context.GetMessage( "Category", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV22TFSupplierAgbTypeName)),  0,  AV22TFSupplierAgbTypeName,  AV22TFSupplierAgbTypeName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV23TFSupplierAgbTypeName_Sel)),  AV23TFSupplierAgbTypeName_Sel,  AV23TFSupplierAgbTypeName_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFSUPPLIERAGBCONTACTNAME",  context.GetMessage( "Contact Person", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFSupplierAgbContactName)),  0,  AV28TFSupplierAgbContactName,  AV28TFSupplierAgbContactName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV29TFSupplierAgbContactName_Sel)),  AV29TFSupplierAgbContactName_Sel,  AV29TFSupplierAgbContactName_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFSUPPLIERAGBPHONE",  context.GetMessage( "Phone", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV30TFSupplierAgbPhone)),  0,  AV30TFSupplierAgbPhone,  AV30TFSupplierAgbPhone,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV31TFSupplierAgbPhone_Sel)),  AV31TFSupplierAgbPhone_Sel,  AV31TFSupplierAgbPhone_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFSUPPLIERAGBEMAIL",  context.GetMessage( "Email", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV32TFSupplierAgbEmail)),  0,  AV32TFSupplierAgbEmail,  AV32TFSupplierAgbEmail,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV33TFSupplierAgbEmail_Sel)),  AV33TFSupplierAgbEmail_Sel,  AV33TFSupplierAgbEmail_Sel) ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV78Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV78Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Trn_SupplierAgb";
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
         PA4A2( ) ;
         WS4A2( ) ;
         WE4A2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256145421258", true, true);
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
         context.AddJavascriptSource("trn_supplieragbww.js", "?20256145421263", false, true);
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
         edtSupplierAgbId_Internalname = "SUPPLIERAGBID_"+sGXsfl_39_idx;
         edtSupplierAgbNumber_Internalname = "SUPPLIERAGBNUMBER_"+sGXsfl_39_idx;
         edtSupplierAgbTypeId_Internalname = "SUPPLIERAGBTYPEID_"+sGXsfl_39_idx;
         edtSupplierAgbName_Internalname = "SUPPLIERAGBNAME_"+sGXsfl_39_idx;
         edtSupplierAgbTypeName_Internalname = "SUPPLIERAGBTYPENAME_"+sGXsfl_39_idx;
         edtSupplierAgbKvkNumber_Internalname = "SUPPLIERAGBKVKNUMBER_"+sGXsfl_39_idx;
         edtSupplierAGBAddressCountry_Internalname = "SUPPLIERAGBADDRESSCOUNTRY_"+sGXsfl_39_idx;
         edtSupplierAgbAddressCity_Internalname = "SUPPLIERAGBADDRESSCITY_"+sGXsfl_39_idx;
         edtSupplierAgbAddressZipCode_Internalname = "SUPPLIERAGBADDRESSZIPCODE_"+sGXsfl_39_idx;
         edtSupplierAgbAddressLine1_Internalname = "SUPPLIERAGBADDRESSLINE1_"+sGXsfl_39_idx;
         edtSupplierAgbAddressLine2_Internalname = "SUPPLIERAGBADDRESSLINE2_"+sGXsfl_39_idx;
         edtSupplierAgbContactName_Internalname = "SUPPLIERAGBCONTACTNAME_"+sGXsfl_39_idx;
         edtSupplierAgbPhone_Internalname = "SUPPLIERAGBPHONE_"+sGXsfl_39_idx;
         edtSupplierAgbPhoneCode_Internalname = "SUPPLIERAGBPHONECODE_"+sGXsfl_39_idx;
         edtSupplierAgbPhoneNumber_Internalname = "SUPPLIERAGBPHONENUMBER_"+sGXsfl_39_idx;
         edtSupplierAgbEmail_Internalname = "SUPPLIERAGBEMAIL_"+sGXsfl_39_idx;
         edtavSupplieragbaddress_Internalname = "vSUPPLIERAGBADDRESS_"+sGXsfl_39_idx;
         cmbavActiongroup_Internalname = "vACTIONGROUP_"+sGXsfl_39_idx;
      }

      protected void SubsflControlProps_fel_392( )
      {
         edtSupplierAgbId_Internalname = "SUPPLIERAGBID_"+sGXsfl_39_fel_idx;
         edtSupplierAgbNumber_Internalname = "SUPPLIERAGBNUMBER_"+sGXsfl_39_fel_idx;
         edtSupplierAgbTypeId_Internalname = "SUPPLIERAGBTYPEID_"+sGXsfl_39_fel_idx;
         edtSupplierAgbName_Internalname = "SUPPLIERAGBNAME_"+sGXsfl_39_fel_idx;
         edtSupplierAgbTypeName_Internalname = "SUPPLIERAGBTYPENAME_"+sGXsfl_39_fel_idx;
         edtSupplierAgbKvkNumber_Internalname = "SUPPLIERAGBKVKNUMBER_"+sGXsfl_39_fel_idx;
         edtSupplierAGBAddressCountry_Internalname = "SUPPLIERAGBADDRESSCOUNTRY_"+sGXsfl_39_fel_idx;
         edtSupplierAgbAddressCity_Internalname = "SUPPLIERAGBADDRESSCITY_"+sGXsfl_39_fel_idx;
         edtSupplierAgbAddressZipCode_Internalname = "SUPPLIERAGBADDRESSZIPCODE_"+sGXsfl_39_fel_idx;
         edtSupplierAgbAddressLine1_Internalname = "SUPPLIERAGBADDRESSLINE1_"+sGXsfl_39_fel_idx;
         edtSupplierAgbAddressLine2_Internalname = "SUPPLIERAGBADDRESSLINE2_"+sGXsfl_39_fel_idx;
         edtSupplierAgbContactName_Internalname = "SUPPLIERAGBCONTACTNAME_"+sGXsfl_39_fel_idx;
         edtSupplierAgbPhone_Internalname = "SUPPLIERAGBPHONE_"+sGXsfl_39_fel_idx;
         edtSupplierAgbPhoneCode_Internalname = "SUPPLIERAGBPHONECODE_"+sGXsfl_39_fel_idx;
         edtSupplierAgbPhoneNumber_Internalname = "SUPPLIERAGBPHONENUMBER_"+sGXsfl_39_fel_idx;
         edtSupplierAgbEmail_Internalname = "SUPPLIERAGBEMAIL_"+sGXsfl_39_fel_idx;
         edtavSupplieragbaddress_Internalname = "vSUPPLIERAGBADDRESS_"+sGXsfl_39_fel_idx;
         cmbavActiongroup_Internalname = "vACTIONGROUP_"+sGXsfl_39_fel_idx;
      }

      protected void sendrow_392( )
      {
         sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
         SubsflControlProps_392( ) ;
         WB4A0( ) ;
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbId_Internalname,A49SupplierAgbId.ToString(),A49SupplierAgbId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierAgbId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)39,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbNumber_Internalname,(string)A50SupplierAgbNumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierAgbNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"AgbNumber",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbTypeId_Internalname,A255SupplierAgbTypeId.ToString(),A255SupplierAgbTypeId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierAgbTypeId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)39,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSupplierAgbName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbName_Internalname,(string)A51SupplierAgbName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtSupplierAgbName_Link,(string)"",(string)"",(string)"",(string)edtSupplierAgbName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSupplierAgbName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSupplierAgbTypeName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbTypeName_Internalname,(string)A256SupplierAgbTypeName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierAgbTypeName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtSupplierAgbTypeName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbKvkNumber_Internalname,(string)A52SupplierAgbKvkNumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierAgbKvkNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"KvkNumber",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAGBAddressCountry_Internalname,(string)A306SupplierAGBAddressCountry,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierAGBAddressCountry_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbAddressCity_Internalname,(string)A264SupplierAgbAddressCity,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierAgbAddressCity_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbAddressZipCode_Internalname,(string)A263SupplierAgbAddressZipCode,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierAgbAddressZipCode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbAddressLine1_Internalname,(string)A307SupplierAgbAddressLine1,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierAgbAddressLine1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbAddressLine2_Internalname,(string)A308SupplierAgbAddressLine2,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierAgbAddressLine2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSupplierAgbContactName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbContactName_Internalname,(string)A55SupplierAgbContactName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierAgbContactName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSupplierAgbContactName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSupplierAgbPhone_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A56SupplierAgbPhone);
            }
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbPhone_Internalname,StringUtil.RTrim( A56SupplierAgbPhone),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtSupplierAgbPhone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSupplierAgbPhone_Visible,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbPhoneCode_Internalname,(string)A349SupplierAgbPhoneCode,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierAgbPhoneCode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbPhoneNumber_Internalname,(string)A350SupplierAgbPhoneNumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierAgbPhoneNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSupplierAgbEmail_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbEmail_Internalname,(string)A57SupplierAgbEmail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A57SupplierAgbEmail,(string)"",(string)"",(string)"",(string)edtSupplierAgbEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSupplierAgbEmail_Visible,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavSupplieragbaddress_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_39_idx + "',39)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSupplieragbaddress_Internalname,(string)AV61SupplierAgbAddress,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'","http://maps.google.com/maps?q="+GXUtil.UrlEncode( AV61SupplierAgbAddress),(string)"_blank",(string)"",(string)"",(string)edtavSupplieragbaddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavSupplieragbaddress_Visible,(int)edtavSupplieragbaddress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Address",(string)"start",(bool)true,(string)""});
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
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavActiongroup,(string)cmbavActiongroup_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV72ActionGroup), 4, 0)),(short)1,(string)cmbavActiongroup_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVACTIONGROUP.CLICK."+sGXsfl_39_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)cmbavActiongroup_Class,(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"",(string)"",(bool)true,(short)0});
            cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV72ActionGroup), 4, 0));
            AssignProp("", false, cmbavActiongroup_Internalname, "Values", (string)(cmbavActiongroup.ToJavascriptSource()), !bGXsfl_39_Refreshing);
            send_integrity_lvl_hashes4A2( ) ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSupplierAgbName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSupplierAgbTypeName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Category", "")) ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSupplierAgbContactName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Contact Person", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSupplierAgbPhone_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Phone", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSupplierAgbEmail_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Email", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavSupplieragbaddress_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Address", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A49SupplierAgbId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A50SupplierAgbNumber));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A255SupplierAgbTypeId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A51SupplierAgbName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSupplierAgbName_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplierAgbName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A256SupplierAgbTypeName));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplierAgbTypeName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A52SupplierAgbKvkNumber));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A306SupplierAGBAddressCountry));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A264SupplierAgbAddressCity));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A263SupplierAgbAddressZipCode));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A307SupplierAgbAddressLine1));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A308SupplierAgbAddressLine2));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A55SupplierAgbContactName));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplierAgbContactName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A56SupplierAgbPhone)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplierAgbPhone_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A349SupplierAgbPhoneCode));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A350SupplierAgbPhoneNumber));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A57SupplierAgbEmail));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplierAgbEmail_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV61SupplierAgbAddress));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSupplieragbaddress_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSupplieragbaddress_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV72ActionGroup), 4, 0, ".", ""))));
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
         edtSupplierAgbId_Internalname = "SUPPLIERAGBID";
         edtSupplierAgbNumber_Internalname = "SUPPLIERAGBNUMBER";
         edtSupplierAgbTypeId_Internalname = "SUPPLIERAGBTYPEID";
         edtSupplierAgbName_Internalname = "SUPPLIERAGBNAME";
         edtSupplierAgbTypeName_Internalname = "SUPPLIERAGBTYPENAME";
         edtSupplierAgbKvkNumber_Internalname = "SUPPLIERAGBKVKNUMBER";
         edtSupplierAGBAddressCountry_Internalname = "SUPPLIERAGBADDRESSCOUNTRY";
         edtSupplierAgbAddressCity_Internalname = "SUPPLIERAGBADDRESSCITY";
         edtSupplierAgbAddressZipCode_Internalname = "SUPPLIERAGBADDRESSZIPCODE";
         edtSupplierAgbAddressLine1_Internalname = "SUPPLIERAGBADDRESSLINE1";
         edtSupplierAgbAddressLine2_Internalname = "SUPPLIERAGBADDRESSLINE2";
         edtSupplierAgbContactName_Internalname = "SUPPLIERAGBCONTACTNAME";
         edtSupplierAgbPhone_Internalname = "SUPPLIERAGBPHONE";
         edtSupplierAgbPhoneCode_Internalname = "SUPPLIERAGBPHONECODE";
         edtSupplierAgbPhoneNumber_Internalname = "SUPPLIERAGBPHONENUMBER";
         edtSupplierAgbEmail_Internalname = "SUPPLIERAGBEMAIL";
         edtavSupplieragbaddress_Internalname = "vSUPPLIERAGBADDRESS";
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
         edtavSupplieragbaddress_Jsonclick = "";
         edtavSupplieragbaddress_Enabled = 1;
         edtSupplierAgbEmail_Jsonclick = "";
         edtSupplierAgbPhoneNumber_Jsonclick = "";
         edtSupplierAgbPhoneCode_Jsonclick = "";
         edtSupplierAgbPhone_Jsonclick = "";
         edtSupplierAgbContactName_Jsonclick = "";
         edtSupplierAgbAddressLine2_Jsonclick = "";
         edtSupplierAgbAddressLine1_Jsonclick = "";
         edtSupplierAgbAddressZipCode_Jsonclick = "";
         edtSupplierAgbAddressCity_Jsonclick = "";
         edtSupplierAGBAddressCountry_Jsonclick = "";
         edtSupplierAgbKvkNumber_Jsonclick = "";
         edtSupplierAgbTypeName_Jsonclick = "";
         edtSupplierAgbName_Jsonclick = "";
         edtSupplierAgbName_Link = "";
         edtSupplierAgbTypeId_Jsonclick = "";
         edtSupplierAgbNumber_Jsonclick = "";
         edtSupplierAgbId_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWithSelection WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavSupplieragbaddress_Visible = -1;
         edtSupplierAgbEmail_Visible = -1;
         edtSupplierAgbPhone_Visible = -1;
         edtSupplierAgbContactName_Visible = -1;
         edtSupplierAgbTypeName_Visible = -1;
         edtSupplierAgbName_Visible = -1;
         edtSupplierAgbEmail_Enabled = 0;
         edtSupplierAgbPhoneNumber_Enabled = 0;
         edtSupplierAgbPhoneCode_Enabled = 0;
         edtSupplierAgbPhone_Enabled = 0;
         edtSupplierAgbContactName_Enabled = 0;
         edtSupplierAgbAddressLine2_Enabled = 0;
         edtSupplierAgbAddressLine1_Enabled = 0;
         edtSupplierAgbAddressZipCode_Enabled = 0;
         edtSupplierAgbAddressCity_Enabled = 0;
         edtSupplierAGBAddressCountry_Enabled = 0;
         edtSupplierAgbKvkNumber_Enabled = 0;
         edtSupplierAgbTypeName_Enabled = 0;
         edtSupplierAgbName_Enabled = 0;
         edtSupplierAgbTypeId_Enabled = 0;
         edtSupplierAgbNumber_Enabled = 0;
         edtSupplierAgbId_Enabled = 0;
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
         Ddo_grid_Datalistproc = "Trn_SupplierAgbWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character|Character|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5";
         Ddo_grid_Columnids = "3:SupplierAgbName|4:SupplierAgbTypeName|11:SupplierAgbContactName|12:SupplierAgbPhone|15:SupplierAgbEmail";
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
         Form.Caption = context.GetMessage( "Agb Suppliers", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV76ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV78Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV24TFSupplierAgbName","fld":"vTFSUPPLIERAGBNAME"},{"av":"AV25TFSupplierAgbName_Sel","fld":"vTFSUPPLIERAGBNAME_SEL"},{"av":"AV22TFSupplierAgbTypeName","fld":"vTFSUPPLIERAGBTYPENAME"},{"av":"AV23TFSupplierAgbTypeName_Sel","fld":"vTFSUPPLIERAGBTYPENAME_SEL"},{"av":"AV28TFSupplierAgbContactName","fld":"vTFSUPPLIERAGBCONTACTNAME"},{"av":"AV29TFSupplierAgbContactName_Sel","fld":"vTFSUPPLIERAGBCONTACTNAME_SEL"},{"av":"AV30TFSupplierAgbPhone","fld":"vTFSUPPLIERAGBPHONE"},{"av":"AV31TFSupplierAgbPhone_Sel","fld":"vTFSUPPLIERAGBPHONE_SEL"},{"av":"AV32TFSupplierAgbEmail","fld":"vTFSUPPLIERAGBEMAIL"},{"av":"AV33TFSupplierAgbEmail_Sel","fld":"vTFSUPPLIERAGBEMAIL_SEL"},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV60IsAuthorized_SupplierAgbName","fld":"vISAUTHORIZED_SUPPLIERAGBNAME","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV76ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtSupplierAgbName_Visible","ctrl":"SUPPLIERAGBNAME","prop":"Visible"},{"av":"edtSupplierAgbTypeName_Visible","ctrl":"SUPPLIERAGBTYPENAME","prop":"Visible"},{"av":"edtSupplierAgbContactName_Visible","ctrl":"SUPPLIERAGBCONTACTNAME","prop":"Visible"},{"av":"edtSupplierAgbPhone_Visible","ctrl":"SUPPLIERAGBPHONE","prop":"Visible"},{"av":"edtSupplierAgbEmail_Visible","ctrl":"SUPPLIERAGBEMAIL","prop":"Visible"},{"av":"edtavSupplieragbaddress_Visible","ctrl":"vSUPPLIERAGBADDRESS","prop":"Visible"},{"av":"AV38GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV39GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV40GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E124A2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV76ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV78Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV24TFSupplierAgbName","fld":"vTFSUPPLIERAGBNAME"},{"av":"AV25TFSupplierAgbName_Sel","fld":"vTFSUPPLIERAGBNAME_SEL"},{"av":"AV22TFSupplierAgbTypeName","fld":"vTFSUPPLIERAGBTYPENAME"},{"av":"AV23TFSupplierAgbTypeName_Sel","fld":"vTFSUPPLIERAGBTYPENAME_SEL"},{"av":"AV28TFSupplierAgbContactName","fld":"vTFSUPPLIERAGBCONTACTNAME"},{"av":"AV29TFSupplierAgbContactName_Sel","fld":"vTFSUPPLIERAGBCONTACTNAME_SEL"},{"av":"AV30TFSupplierAgbPhone","fld":"vTFSUPPLIERAGBPHONE"},{"av":"AV31TFSupplierAgbPhone_Sel","fld":"vTFSUPPLIERAGBPHONE_SEL"},{"av":"AV32TFSupplierAgbEmail","fld":"vTFSUPPLIERAGBEMAIL"},{"av":"AV33TFSupplierAgbEmail_Sel","fld":"vTFSUPPLIERAGBEMAIL_SEL"},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV60IsAuthorized_SupplierAgbName","fld":"vISAUTHORIZED_SUPPLIERAGBNAME","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E134A2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV76ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV78Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV24TFSupplierAgbName","fld":"vTFSUPPLIERAGBNAME"},{"av":"AV25TFSupplierAgbName_Sel","fld":"vTFSUPPLIERAGBNAME_SEL"},{"av":"AV22TFSupplierAgbTypeName","fld":"vTFSUPPLIERAGBTYPENAME"},{"av":"AV23TFSupplierAgbTypeName_Sel","fld":"vTFSUPPLIERAGBTYPENAME_SEL"},{"av":"AV28TFSupplierAgbContactName","fld":"vTFSUPPLIERAGBCONTACTNAME"},{"av":"AV29TFSupplierAgbContactName_Sel","fld":"vTFSUPPLIERAGBCONTACTNAME_SEL"},{"av":"AV30TFSupplierAgbPhone","fld":"vTFSUPPLIERAGBPHONE"},{"av":"AV31TFSupplierAgbPhone_Sel","fld":"vTFSUPPLIERAGBPHONE_SEL"},{"av":"AV32TFSupplierAgbEmail","fld":"vTFSUPPLIERAGBEMAIL"},{"av":"AV33TFSupplierAgbEmail_Sel","fld":"vTFSUPPLIERAGBEMAIL_SEL"},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV60IsAuthorized_SupplierAgbName","fld":"vISAUTHORIZED_SUPPLIERAGBNAME","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E154A2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV76ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV78Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV24TFSupplierAgbName","fld":"vTFSUPPLIERAGBNAME"},{"av":"AV25TFSupplierAgbName_Sel","fld":"vTFSUPPLIERAGBNAME_SEL"},{"av":"AV22TFSupplierAgbTypeName","fld":"vTFSUPPLIERAGBTYPENAME"},{"av":"AV23TFSupplierAgbTypeName_Sel","fld":"vTFSUPPLIERAGBTYPENAME_SEL"},{"av":"AV28TFSupplierAgbContactName","fld":"vTFSUPPLIERAGBCONTACTNAME"},{"av":"AV29TFSupplierAgbContactName_Sel","fld":"vTFSUPPLIERAGBCONTACTNAME_SEL"},{"av":"AV30TFSupplierAgbPhone","fld":"vTFSUPPLIERAGBPHONE"},{"av":"AV31TFSupplierAgbPhone_Sel","fld":"vTFSUPPLIERAGBPHONE_SEL"},{"av":"AV32TFSupplierAgbEmail","fld":"vTFSUPPLIERAGBEMAIL"},{"av":"AV33TFSupplierAgbEmail_Sel","fld":"vTFSUPPLIERAGBEMAIL_SEL"},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV60IsAuthorized_SupplierAgbName","fld":"vISAUTHORIZED_SUPPLIERAGBNAME","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV24TFSupplierAgbName","fld":"vTFSUPPLIERAGBNAME"},{"av":"AV25TFSupplierAgbName_Sel","fld":"vTFSUPPLIERAGBNAME_SEL"},{"av":"AV22TFSupplierAgbTypeName","fld":"vTFSUPPLIERAGBTYPENAME"},{"av":"AV23TFSupplierAgbTypeName_Sel","fld":"vTFSUPPLIERAGBTYPENAME_SEL"},{"av":"AV28TFSupplierAgbContactName","fld":"vTFSUPPLIERAGBCONTACTNAME"},{"av":"AV29TFSupplierAgbContactName_Sel","fld":"vTFSUPPLIERAGBCONTACTNAME_SEL"},{"av":"AV30TFSupplierAgbPhone","fld":"vTFSUPPLIERAGBPHONE"},{"av":"AV31TFSupplierAgbPhone_Sel","fld":"vTFSUPPLIERAGBPHONE_SEL"},{"av":"AV32TFSupplierAgbEmail","fld":"vTFSUPPLIERAGBEMAIL"},{"av":"AV33TFSupplierAgbEmail_Sel","fld":"vTFSUPPLIERAGBEMAIL_SEL"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E204A2","iparms":[{"av":"A306SupplierAGBAddressCountry","fld":"SUPPLIERAGBADDRESSCOUNTRY"},{"av":"A264SupplierAgbAddressCity","fld":"SUPPLIERAGBADDRESSCITY"},{"av":"A263SupplierAgbAddressZipCode","fld":"SUPPLIERAGBADDRESSZIPCODE"},{"av":"A307SupplierAgbAddressLine1","fld":"SUPPLIERAGBADDRESSLINE1"},{"av":"A308SupplierAgbAddressLine2","fld":"SUPPLIERAGBADDRESSLINE2"},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV60IsAuthorized_SupplierAgbName","fld":"vISAUTHORIZED_SUPPLIERAGBNAME","hsh":true},{"av":"A49SupplierAgbId","fld":"SUPPLIERAGBID","hsh":true}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV61SupplierAgbAddress","fld":"vSUPPLIERAGBADDRESS"},{"av":"cmbavActiongroup"},{"av":"AV72ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"edtSupplierAgbName_Link","ctrl":"SUPPLIERAGBNAME","prop":"Link"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E164A2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV76ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV78Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV24TFSupplierAgbName","fld":"vTFSUPPLIERAGBNAME"},{"av":"AV25TFSupplierAgbName_Sel","fld":"vTFSUPPLIERAGBNAME_SEL"},{"av":"AV22TFSupplierAgbTypeName","fld":"vTFSUPPLIERAGBTYPENAME"},{"av":"AV23TFSupplierAgbTypeName_Sel","fld":"vTFSUPPLIERAGBTYPENAME_SEL"},{"av":"AV28TFSupplierAgbContactName","fld":"vTFSUPPLIERAGBCONTACTNAME"},{"av":"AV29TFSupplierAgbContactName_Sel","fld":"vTFSUPPLIERAGBCONTACTNAME_SEL"},{"av":"AV30TFSupplierAgbPhone","fld":"vTFSUPPLIERAGBPHONE"},{"av":"AV31TFSupplierAgbPhone_Sel","fld":"vTFSUPPLIERAGBPHONE_SEL"},{"av":"AV32TFSupplierAgbEmail","fld":"vTFSUPPLIERAGBEMAIL"},{"av":"AV33TFSupplierAgbEmail_Sel","fld":"vTFSUPPLIERAGBEMAIL_SEL"},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV60IsAuthorized_SupplierAgbName","fld":"vISAUTHORIZED_SUPPLIERAGBNAME","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV76ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"edtSupplierAgbName_Visible","ctrl":"SUPPLIERAGBNAME","prop":"Visible"},{"av":"edtSupplierAgbTypeName_Visible","ctrl":"SUPPLIERAGBTYPENAME","prop":"Visible"},{"av":"edtSupplierAgbContactName_Visible","ctrl":"SUPPLIERAGBCONTACTNAME","prop":"Visible"},{"av":"edtSupplierAgbPhone_Visible","ctrl":"SUPPLIERAGBPHONE","prop":"Visible"},{"av":"edtSupplierAgbEmail_Visible","ctrl":"SUPPLIERAGBEMAIL","prop":"Visible"},{"av":"edtavSupplieragbaddress_Visible","ctrl":"vSUPPLIERAGBADDRESS","prop":"Visible"},{"av":"AV38GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV39GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV40GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E114A2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV76ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV78Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV24TFSupplierAgbName","fld":"vTFSUPPLIERAGBNAME"},{"av":"AV25TFSupplierAgbName_Sel","fld":"vTFSUPPLIERAGBNAME_SEL"},{"av":"AV22TFSupplierAgbTypeName","fld":"vTFSUPPLIERAGBTYPENAME"},{"av":"AV23TFSupplierAgbTypeName_Sel","fld":"vTFSUPPLIERAGBTYPENAME_SEL"},{"av":"AV28TFSupplierAgbContactName","fld":"vTFSUPPLIERAGBCONTACTNAME"},{"av":"AV29TFSupplierAgbContactName_Sel","fld":"vTFSUPPLIERAGBCONTACTNAME_SEL"},{"av":"AV30TFSupplierAgbPhone","fld":"vTFSUPPLIERAGBPHONE"},{"av":"AV31TFSupplierAgbPhone_Sel","fld":"vTFSUPPLIERAGBPHONE_SEL"},{"av":"AV32TFSupplierAgbEmail","fld":"vTFSUPPLIERAGBEMAIL"},{"av":"AV33TFSupplierAgbEmail_Sel","fld":"vTFSUPPLIERAGBEMAIL_SEL"},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV60IsAuthorized_SupplierAgbName","fld":"vISAUTHORIZED_SUPPLIERAGBNAME","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24TFSupplierAgbName","fld":"vTFSUPPLIERAGBNAME"},{"av":"AV25TFSupplierAgbName_Sel","fld":"vTFSUPPLIERAGBNAME_SEL"},{"av":"AV22TFSupplierAgbTypeName","fld":"vTFSUPPLIERAGBTYPENAME"},{"av":"AV23TFSupplierAgbTypeName_Sel","fld":"vTFSUPPLIERAGBTYPENAME_SEL"},{"av":"AV28TFSupplierAgbContactName","fld":"vTFSUPPLIERAGBCONTACTNAME"},{"av":"AV29TFSupplierAgbContactName_Sel","fld":"vTFSUPPLIERAGBCONTACTNAME_SEL"},{"av":"AV30TFSupplierAgbPhone","fld":"vTFSUPPLIERAGBPHONE"},{"av":"AV31TFSupplierAgbPhone_Sel","fld":"vTFSUPPLIERAGBPHONE_SEL"},{"av":"AV32TFSupplierAgbEmail","fld":"vTFSUPPLIERAGBEMAIL"},{"av":"AV33TFSupplierAgbEmail_Sel","fld":"vTFSUPPLIERAGBEMAIL_SEL"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV76ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtSupplierAgbName_Visible","ctrl":"SUPPLIERAGBNAME","prop":"Visible"},{"av":"edtSupplierAgbTypeName_Visible","ctrl":"SUPPLIERAGBTYPENAME","prop":"Visible"},{"av":"edtSupplierAgbContactName_Visible","ctrl":"SUPPLIERAGBCONTACTNAME","prop":"Visible"},{"av":"edtSupplierAgbPhone_Visible","ctrl":"SUPPLIERAGBPHONE","prop":"Visible"},{"av":"edtSupplierAgbEmail_Visible","ctrl":"SUPPLIERAGBEMAIL","prop":"Visible"},{"av":"edtavSupplieragbaddress_Visible","ctrl":"vSUPPLIERAGBADDRESS","prop":"Visible"},{"av":"AV38GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV39GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV40GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("VACTIONGROUP.CLICK","""{"handler":"E214A2","iparms":[{"av":"cmbavActiongroup"},{"av":"AV72ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV76ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV78Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV24TFSupplierAgbName","fld":"vTFSUPPLIERAGBNAME"},{"av":"AV25TFSupplierAgbName_Sel","fld":"vTFSUPPLIERAGBNAME_SEL"},{"av":"AV22TFSupplierAgbTypeName","fld":"vTFSUPPLIERAGBTYPENAME"},{"av":"AV23TFSupplierAgbTypeName_Sel","fld":"vTFSUPPLIERAGBTYPENAME_SEL"},{"av":"AV28TFSupplierAgbContactName","fld":"vTFSUPPLIERAGBCONTACTNAME"},{"av":"AV29TFSupplierAgbContactName_Sel","fld":"vTFSUPPLIERAGBCONTACTNAME_SEL"},{"av":"AV30TFSupplierAgbPhone","fld":"vTFSUPPLIERAGBPHONE"},{"av":"AV31TFSupplierAgbPhone_Sel","fld":"vTFSUPPLIERAGBPHONE_SEL"},{"av":"AV32TFSupplierAgbEmail","fld":"vTFSUPPLIERAGBEMAIL"},{"av":"AV33TFSupplierAgbEmail_Sel","fld":"vTFSUPPLIERAGBEMAIL_SEL"},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV60IsAuthorized_SupplierAgbName","fld":"vISAUTHORIZED_SUPPLIERAGBNAME","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"A49SupplierAgbId","fld":"SUPPLIERAGBID","hsh":true}]""");
         setEventMetadata("VACTIONGROUP.CLICK",""","oparms":[{"av":"cmbavActiongroup"},{"av":"AV72ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV76ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtSupplierAgbName_Visible","ctrl":"SUPPLIERAGBNAME","prop":"Visible"},{"av":"edtSupplierAgbTypeName_Visible","ctrl":"SUPPLIERAGBTYPENAME","prop":"Visible"},{"av":"edtSupplierAgbContactName_Visible","ctrl":"SUPPLIERAGBCONTACTNAME","prop":"Visible"},{"av":"edtSupplierAgbPhone_Visible","ctrl":"SUPPLIERAGBPHONE","prop":"Visible"},{"av":"edtSupplierAgbEmail_Visible","ctrl":"SUPPLIERAGBEMAIL","prop":"Visible"},{"av":"edtavSupplieragbaddress_Visible","ctrl":"vSUPPLIERAGBADDRESS","prop":"Visible"},{"av":"AV38GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV39GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV40GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E174A2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV76ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV78Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV24TFSupplierAgbName","fld":"vTFSUPPLIERAGBNAME"},{"av":"AV25TFSupplierAgbName_Sel","fld":"vTFSUPPLIERAGBNAME_SEL"},{"av":"AV22TFSupplierAgbTypeName","fld":"vTFSUPPLIERAGBTYPENAME"},{"av":"AV23TFSupplierAgbTypeName_Sel","fld":"vTFSUPPLIERAGBTYPENAME_SEL"},{"av":"AV28TFSupplierAgbContactName","fld":"vTFSUPPLIERAGBCONTACTNAME"},{"av":"AV29TFSupplierAgbContactName_Sel","fld":"vTFSUPPLIERAGBCONTACTNAME_SEL"},{"av":"AV30TFSupplierAgbPhone","fld":"vTFSUPPLIERAGBPHONE"},{"av":"AV31TFSupplierAgbPhone_Sel","fld":"vTFSUPPLIERAGBPHONE_SEL"},{"av":"AV32TFSupplierAgbEmail","fld":"vTFSUPPLIERAGBEMAIL"},{"av":"AV33TFSupplierAgbEmail_Sel","fld":"vTFSUPPLIERAGBEMAIL_SEL"},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV60IsAuthorized_SupplierAgbName","fld":"vISAUTHORIZED_SUPPLIERAGBNAME","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"A49SupplierAgbId","fld":"SUPPLIERAGBID","hsh":true}]""");
         setEventMetadata("'DOINSERT'",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV76ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtSupplierAgbName_Visible","ctrl":"SUPPLIERAGBNAME","prop":"Visible"},{"av":"edtSupplierAgbTypeName_Visible","ctrl":"SUPPLIERAGBTYPENAME","prop":"Visible"},{"av":"edtSupplierAgbContactName_Visible","ctrl":"SUPPLIERAGBCONTACTNAME","prop":"Visible"},{"av":"edtSupplierAgbPhone_Visible","ctrl":"SUPPLIERAGBPHONE","prop":"Visible"},{"av":"edtSupplierAgbEmail_Visible","ctrl":"SUPPLIERAGBEMAIL","prop":"Visible"},{"av":"edtavSupplieragbaddress_Visible","ctrl":"vSUPPLIERAGBADDRESS","prop":"Visible"},{"av":"AV38GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV39GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV40GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","""{"handler":"E144A2","iparms":[]""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("VALID_SUPPLIERAGBTYPEID","""{"handler":"Valid_Supplieragbtypeid","iparms":[]}""");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV15FilterFullText = "";
         AV76ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV78Pgmname = "";
         AV24TFSupplierAgbName = "";
         AV25TFSupplierAgbName_Sel = "";
         AV22TFSupplierAgbTypeName = "";
         AV23TFSupplierAgbTypeName_Sel = "";
         AV28TFSupplierAgbContactName = "";
         AV29TFSupplierAgbContactName_Sel = "";
         AV30TFSupplierAgbPhone = "";
         AV31TFSupplierAgbPhone_Sel = "";
         AV32TFSupplierAgbEmail = "";
         AV33TFSupplierAgbEmail_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV17ManageFiltersData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV40GridAppliedFilters = "";
         AV34DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
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
         A49SupplierAgbId = Guid.Empty;
         A50SupplierAgbNumber = "";
         A255SupplierAgbTypeId = Guid.Empty;
         A51SupplierAgbName = "";
         A256SupplierAgbTypeName = "";
         A52SupplierAgbKvkNumber = "";
         A306SupplierAGBAddressCountry = "";
         A264SupplierAgbAddressCity = "";
         A263SupplierAgbAddressZipCode = "";
         A307SupplierAgbAddressLine1 = "";
         A308SupplierAgbAddressLine2 = "";
         A55SupplierAgbContactName = "";
         A56SupplierAgbPhone = "";
         A349SupplierAgbPhoneCode = "";
         A350SupplierAgbPhoneNumber = "";
         A57SupplierAgbEmail = "";
         AV61SupplierAgbAddress = "";
         lV79Trn_supplieragbwwds_1_filterfulltext = "";
         lV80Trn_supplieragbwwds_2_tfsupplieragbname = "";
         lV82Trn_supplieragbwwds_4_tfsupplieragbtypename = "";
         lV84Trn_supplieragbwwds_6_tfsupplieragbcontactname = "";
         lV86Trn_supplieragbwwds_8_tfsupplieragbphone = "";
         lV88Trn_supplieragbwwds_10_tfsupplieragbemail = "";
         AV79Trn_supplieragbwwds_1_filterfulltext = "";
         AV81Trn_supplieragbwwds_3_tfsupplieragbname_sel = "";
         AV80Trn_supplieragbwwds_2_tfsupplieragbname = "";
         AV83Trn_supplieragbwwds_5_tfsupplieragbtypename_sel = "";
         AV82Trn_supplieragbwwds_4_tfsupplieragbtypename = "";
         AV85Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel = "";
         AV84Trn_supplieragbwwds_6_tfsupplieragbcontactname = "";
         AV87Trn_supplieragbwwds_9_tfsupplieragbphone_sel = "";
         AV86Trn_supplieragbwwds_8_tfsupplieragbphone = "";
         AV89Trn_supplieragbwwds_11_tfsupplieragbemail_sel = "";
         AV88Trn_supplieragbwwds_10_tfsupplieragbemail = "";
         H004A2_A57SupplierAgbEmail = new string[] {""} ;
         H004A2_A350SupplierAgbPhoneNumber = new string[] {""} ;
         H004A2_A349SupplierAgbPhoneCode = new string[] {""} ;
         H004A2_A56SupplierAgbPhone = new string[] {""} ;
         H004A2_A55SupplierAgbContactName = new string[] {""} ;
         H004A2_A308SupplierAgbAddressLine2 = new string[] {""} ;
         H004A2_A307SupplierAgbAddressLine1 = new string[] {""} ;
         H004A2_A263SupplierAgbAddressZipCode = new string[] {""} ;
         H004A2_A264SupplierAgbAddressCity = new string[] {""} ;
         H004A2_A306SupplierAGBAddressCountry = new string[] {""} ;
         H004A2_A52SupplierAgbKvkNumber = new string[] {""} ;
         H004A2_A256SupplierAgbTypeName = new string[] {""} ;
         H004A2_A51SupplierAgbName = new string[] {""} ;
         H004A2_A255SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         H004A2_A50SupplierAgbNumber = new string[] {""} ;
         H004A2_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         H004A3_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         AV35GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV36GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV16Session = context.GetSession();
         AV74ColumnsSelectorXML = "";
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV18ManageFiltersXml = "";
         AV75UserCustomValue = "";
         AV77ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
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
         gxphoneLink = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_supplieragbww__default(),
            new Object[][] {
                new Object[] {
               H004A2_A57SupplierAgbEmail, H004A2_A350SupplierAgbPhoneNumber, H004A2_A349SupplierAgbPhoneCode, H004A2_A56SupplierAgbPhone, H004A2_A55SupplierAgbContactName, H004A2_A308SupplierAgbAddressLine2, H004A2_A307SupplierAgbAddressLine1, H004A2_A263SupplierAgbAddressZipCode, H004A2_A264SupplierAgbAddressCity, H004A2_A306SupplierAGBAddressCountry,
               H004A2_A52SupplierAgbKvkNumber, H004A2_A256SupplierAgbTypeName, H004A2_A51SupplierAgbName, H004A2_A255SupplierAgbTypeId, H004A2_A50SupplierAgbNumber, H004A2_A49SupplierAgbId
               }
               , new Object[] {
               H004A3_AGRID_nRecordCount
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV78Pgmname = "Trn_SupplierAgbWW";
         /* GeneXus formulas. */
         AV78Pgmname = "Trn_SupplierAgbWW";
         edtavSupplieragbaddress_Enabled = 0;
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
      private int bttBtninsert_Visible ;
      private int bttBtnsubscriptions_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavSupplieragbaddress_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtSupplierAgbId_Enabled ;
      private int edtSupplierAgbNumber_Enabled ;
      private int edtSupplierAgbTypeId_Enabled ;
      private int edtSupplierAgbName_Enabled ;
      private int edtSupplierAgbTypeName_Enabled ;
      private int edtSupplierAgbKvkNumber_Enabled ;
      private int edtSupplierAGBAddressCountry_Enabled ;
      private int edtSupplierAgbAddressCity_Enabled ;
      private int edtSupplierAgbAddressZipCode_Enabled ;
      private int edtSupplierAgbAddressLine1_Enabled ;
      private int edtSupplierAgbAddressLine2_Enabled ;
      private int edtSupplierAgbContactName_Enabled ;
      private int edtSupplierAgbPhone_Enabled ;
      private int edtSupplierAgbPhoneCode_Enabled ;
      private int edtSupplierAgbPhoneNumber_Enabled ;
      private int edtSupplierAgbEmail_Enabled ;
      private int edtSupplierAgbName_Visible ;
      private int edtSupplierAgbTypeName_Visible ;
      private int edtSupplierAgbContactName_Visible ;
      private int edtSupplierAgbPhone_Visible ;
      private int edtSupplierAgbEmail_Visible ;
      private int edtavSupplieragbaddress_Visible ;
      private int AV37PageToGo ;
      private int AV90GXV1 ;
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
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_39_idx="0001" ;
      private string AV78Pgmname ;
      private string AV30TFSupplierAgbPhone ;
      private string AV31TFSupplierAgbPhone_Sel ;
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
      private string edtSupplierAgbId_Internalname ;
      private string edtSupplierAgbNumber_Internalname ;
      private string edtSupplierAgbTypeId_Internalname ;
      private string edtSupplierAgbName_Internalname ;
      private string edtSupplierAgbTypeName_Internalname ;
      private string edtSupplierAgbKvkNumber_Internalname ;
      private string edtSupplierAGBAddressCountry_Internalname ;
      private string edtSupplierAgbAddressCity_Internalname ;
      private string edtSupplierAgbAddressZipCode_Internalname ;
      private string edtSupplierAgbAddressLine1_Internalname ;
      private string edtSupplierAgbAddressLine2_Internalname ;
      private string edtSupplierAgbContactName_Internalname ;
      private string A56SupplierAgbPhone ;
      private string edtSupplierAgbPhone_Internalname ;
      private string edtSupplierAgbPhoneCode_Internalname ;
      private string edtSupplierAgbPhoneNumber_Internalname ;
      private string edtSupplierAgbEmail_Internalname ;
      private string edtavSupplieragbaddress_Internalname ;
      private string cmbavActiongroup_Internalname ;
      private string lV86Trn_supplieragbwwds_8_tfsupplieragbphone ;
      private string AV87Trn_supplieragbwwds_9_tfsupplieragbphone_sel ;
      private string AV86Trn_supplieragbwwds_8_tfsupplieragbphone ;
      private string cmbavActiongroup_Class ;
      private string edtSupplierAgbName_Link ;
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
      private string edtSupplierAgbId_Jsonclick ;
      private string edtSupplierAgbNumber_Jsonclick ;
      private string edtSupplierAgbTypeId_Jsonclick ;
      private string edtSupplierAgbName_Jsonclick ;
      private string edtSupplierAgbTypeName_Jsonclick ;
      private string edtSupplierAgbKvkNumber_Jsonclick ;
      private string edtSupplierAGBAddressCountry_Jsonclick ;
      private string edtSupplierAgbAddressCity_Jsonclick ;
      private string edtSupplierAgbAddressZipCode_Jsonclick ;
      private string edtSupplierAgbAddressLine1_Jsonclick ;
      private string edtSupplierAgbAddressLine2_Jsonclick ;
      private string edtSupplierAgbContactName_Jsonclick ;
      private string gxphoneLink ;
      private string edtSupplierAgbPhone_Jsonclick ;
      private string edtSupplierAgbPhoneCode_Jsonclick ;
      private string edtSupplierAgbPhoneNumber_Jsonclick ;
      private string edtSupplierAgbEmail_Jsonclick ;
      private string edtavSupplieragbaddress_Jsonclick ;
      private string GXCCtl ;
      private string cmbavActiongroup_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV45IsAuthorized_Display ;
      private bool AV47IsAuthorized_Update ;
      private bool AV49IsAuthorized_Delete ;
      private bool AV60IsAuthorized_SupplierAgbName ;
      private bool AV50IsAuthorized_Insert ;
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
      private bool GXt_boolean1 ;
      private string AV74ColumnsSelectorXML ;
      private string AV18ManageFiltersXml ;
      private string AV75UserCustomValue ;
      private string AV15FilterFullText ;
      private string AV24TFSupplierAgbName ;
      private string AV25TFSupplierAgbName_Sel ;
      private string AV22TFSupplierAgbTypeName ;
      private string AV23TFSupplierAgbTypeName_Sel ;
      private string AV28TFSupplierAgbContactName ;
      private string AV29TFSupplierAgbContactName_Sel ;
      private string AV32TFSupplierAgbEmail ;
      private string AV33TFSupplierAgbEmail_Sel ;
      private string AV40GridAppliedFilters ;
      private string A50SupplierAgbNumber ;
      private string A51SupplierAgbName ;
      private string A256SupplierAgbTypeName ;
      private string A52SupplierAgbKvkNumber ;
      private string A306SupplierAGBAddressCountry ;
      private string A264SupplierAgbAddressCity ;
      private string A263SupplierAgbAddressZipCode ;
      private string A307SupplierAgbAddressLine1 ;
      private string A308SupplierAgbAddressLine2 ;
      private string A55SupplierAgbContactName ;
      private string A349SupplierAgbPhoneCode ;
      private string A350SupplierAgbPhoneNumber ;
      private string A57SupplierAgbEmail ;
      private string AV61SupplierAgbAddress ;
      private string lV79Trn_supplieragbwwds_1_filterfulltext ;
      private string lV80Trn_supplieragbwwds_2_tfsupplieragbname ;
      private string lV82Trn_supplieragbwwds_4_tfsupplieragbtypename ;
      private string lV84Trn_supplieragbwwds_6_tfsupplieragbcontactname ;
      private string lV88Trn_supplieragbwwds_10_tfsupplieragbemail ;
      private string AV79Trn_supplieragbwwds_1_filterfulltext ;
      private string AV81Trn_supplieragbwwds_3_tfsupplieragbname_sel ;
      private string AV80Trn_supplieragbwwds_2_tfsupplieragbname ;
      private string AV83Trn_supplieragbwwds_5_tfsupplieragbtypename_sel ;
      private string AV82Trn_supplieragbwwds_4_tfsupplieragbtypename ;
      private string AV85Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel ;
      private string AV84Trn_supplieragbwwds_6_tfsupplieragbcontactname ;
      private string AV89Trn_supplieragbwwds_11_tfsupplieragbemail_sel ;
      private string AV88Trn_supplieragbwwds_10_tfsupplieragbemail ;
      private Guid A49SupplierAgbId ;
      private Guid A255SupplierAgbTypeId ;
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
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavActiongroup ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV76ColumnsSelector ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV17ManageFiltersData ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV34DDO_TitleSettingsIcons ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV11GridState ;
      private IDataStoreProvider pr_default ;
      private string[] H004A2_A57SupplierAgbEmail ;
      private string[] H004A2_A350SupplierAgbPhoneNumber ;
      private string[] H004A2_A349SupplierAgbPhoneCode ;
      private string[] H004A2_A56SupplierAgbPhone ;
      private string[] H004A2_A55SupplierAgbContactName ;
      private string[] H004A2_A308SupplierAgbAddressLine2 ;
      private string[] H004A2_A307SupplierAgbAddressLine1 ;
      private string[] H004A2_A263SupplierAgbAddressZipCode ;
      private string[] H004A2_A264SupplierAgbAddressCity ;
      private string[] H004A2_A306SupplierAGBAddressCountry ;
      private string[] H004A2_A52SupplierAgbKvkNumber ;
      private string[] H004A2_A256SupplierAgbTypeName ;
      private string[] H004A2_A51SupplierAgbName ;
      private Guid[] H004A2_A255SupplierAgbTypeId ;
      private string[] H004A2_A50SupplierAgbNumber ;
      private Guid[] H004A2_A49SupplierAgbId ;
      private long[] H004A3_AGRID_nRecordCount ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV35GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV36GAMErrors ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV77ColumnsSelectorAux ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class trn_supplieragbww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H004A2( IGxContext context ,
                                             string AV79Trn_supplieragbwwds_1_filterfulltext ,
                                             string AV81Trn_supplieragbwwds_3_tfsupplieragbname_sel ,
                                             string AV80Trn_supplieragbwwds_2_tfsupplieragbname ,
                                             string AV83Trn_supplieragbwwds_5_tfsupplieragbtypename_sel ,
                                             string AV82Trn_supplieragbwwds_4_tfsupplieragbtypename ,
                                             string AV85Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel ,
                                             string AV84Trn_supplieragbwwds_6_tfsupplieragbcontactname ,
                                             string AV87Trn_supplieragbwwds_9_tfsupplieragbphone_sel ,
                                             string AV86Trn_supplieragbwwds_8_tfsupplieragbphone ,
                                             string AV89Trn_supplieragbwwds_11_tfsupplieragbemail_sel ,
                                             string AV88Trn_supplieragbwwds_10_tfsupplieragbemail ,
                                             string A51SupplierAgbName ,
                                             string A256SupplierAgbTypeName ,
                                             string A55SupplierAgbContactName ,
                                             string A56SupplierAgbPhone ,
                                             string A57SupplierAgbEmail ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[18];
         Object[] GXv_Object10 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.SupplierAgbEmail, T1.SupplierAgbPhoneNumber, T1.SupplierAgbPhoneCode, T1.SupplierAgbPhone, T1.SupplierAgbContactName, T1.SupplierAgbAddressLine2, T1.SupplierAgbAddressLine1, T1.SupplierAgbAddressZipCode, T1.SupplierAgbAddressCity, T1.SupplierAGBAddressCountry, T1.SupplierAgbKvkNumber, T2.SupplierAgbTypeName, T1.SupplierAgbName, T1.SupplierAgbTypeId, T1.SupplierAgbNumber, T1.SupplierAgbId";
         sFromString = " FROM (Trn_SupplierAGB T1 INNER JOIN Trn_SupplierAgbType T2 ON T2.SupplierAgbTypeId = T1.SupplierAgbTypeId)";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Trn_supplieragbwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T1.SupplierAgbName) like '%' || LOWER(:lV79Trn_supplieragbwwds_1_filterfulltext)) or ( LOWER(T2.SupplierAgbTypeName) like '%' || LOWER(:lV79Trn_supplieragbwwds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbContactName) like '%' || LOWER(:lV79Trn_supplieragbwwds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbPhone) like '%' || LOWER(:lV79Trn_supplieragbwwds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbEmail) like '%' || LOWER(:lV79Trn_supplieragbwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int9[0] = 1;
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
            GXv_int9[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Trn_supplieragbwwds_3_tfsupplieragbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Trn_supplieragbwwds_2_tfsupplieragbname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName like :lV80Trn_supplieragbwwds_2_tfsupplieragbname)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Trn_supplieragbwwds_3_tfsupplieragbname_sel)) && ! ( StringUtil.StrCmp(AV81Trn_supplieragbwwds_3_tfsupplieragbname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName = ( :AV81Trn_supplieragbwwds_3_tfsupplieragbname_sel))");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( StringUtil.StrCmp(AV81Trn_supplieragbwwds_3_tfsupplieragbname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Trn_supplieragbwwds_5_tfsupplieragbtypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Trn_supplieragbwwds_4_tfsupplieragbtypename)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName like :lV82Trn_supplieragbwwds_4_tfsupplieragbtypename)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Trn_supplieragbwwds_5_tfsupplieragbtypename_sel)) && ! ( StringUtil.StrCmp(AV83Trn_supplieragbwwds_5_tfsupplieragbtypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName = ( :AV83Trn_supplieragbwwds_5_tfsupplieragbtypename_sel))");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( StringUtil.StrCmp(AV83Trn_supplieragbwwds_5_tfsupplieragbtypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierAgbTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Trn_supplieragbwwds_6_tfsupplieragbcontactname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName like :lV84Trn_supplieragbwwds_6_tfsupplieragbcontactname)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel)) && ! ( StringUtil.StrCmp(AV85Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName = ( :AV85Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel))");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( StringUtil.StrCmp(AV85Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Trn_supplieragbwwds_9_tfsupplieragbphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Trn_supplieragbwwds_8_tfsupplieragbphone)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone like :lV86Trn_supplieragbwwds_8_tfsupplieragbphone)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Trn_supplieragbwwds_9_tfsupplieragbphone_sel)) && ! ( StringUtil.StrCmp(AV87Trn_supplieragbwwds_9_tfsupplieragbphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone = ( :AV87Trn_supplieragbwwds_9_tfsupplieragbphone_sel))");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( StringUtil.StrCmp(AV87Trn_supplieragbwwds_9_tfsupplieragbphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Trn_supplieragbwwds_11_tfsupplieragbemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Trn_supplieragbwwds_10_tfsupplieragbemail)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail like :lV88Trn_supplieragbwwds_10_tfsupplieragbemail)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Trn_supplieragbwwds_11_tfsupplieragbemail_sel)) && ! ( StringUtil.StrCmp(AV89Trn_supplieragbwwds_11_tfsupplieragbemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail = ( :AV89Trn_supplieragbwwds_11_tfsupplieragbemail_sel))");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( StringUtil.StrCmp(AV89Trn_supplieragbwwds_11_tfsupplieragbemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbEmail))=0))");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SupplierAgbName, T1.SupplierAgbId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SupplierAgbName DESC, T1.SupplierAgbId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.SupplierAgbTypeName, T1.SupplierAgbId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.SupplierAgbTypeName DESC, T1.SupplierAgbId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SupplierAgbContactName, T1.SupplierAgbId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SupplierAgbContactName DESC, T1.SupplierAgbId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SupplierAgbPhone, T1.SupplierAgbId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SupplierAgbPhone DESC, T1.SupplierAgbId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SupplierAgbEmail, T1.SupplierAgbId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SupplierAgbEmail DESC, T1.SupplierAgbId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.SupplierAgbId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_H004A3( IGxContext context ,
                                             string AV79Trn_supplieragbwwds_1_filterfulltext ,
                                             string AV81Trn_supplieragbwwds_3_tfsupplieragbname_sel ,
                                             string AV80Trn_supplieragbwwds_2_tfsupplieragbname ,
                                             string AV83Trn_supplieragbwwds_5_tfsupplieragbtypename_sel ,
                                             string AV82Trn_supplieragbwwds_4_tfsupplieragbtypename ,
                                             string AV85Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel ,
                                             string AV84Trn_supplieragbwwds_6_tfsupplieragbcontactname ,
                                             string AV87Trn_supplieragbwwds_9_tfsupplieragbphone_sel ,
                                             string AV86Trn_supplieragbwwds_8_tfsupplieragbphone ,
                                             string AV89Trn_supplieragbwwds_11_tfsupplieragbemail_sel ,
                                             string AV88Trn_supplieragbwwds_10_tfsupplieragbemail ,
                                             string A51SupplierAgbName ,
                                             string A256SupplierAgbTypeName ,
                                             string A55SupplierAgbContactName ,
                                             string A56SupplierAgbPhone ,
                                             string A57SupplierAgbEmail ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[15];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (Trn_SupplierAGB T1 INNER JOIN Trn_SupplierAgbType T2 ON T2.SupplierAgbTypeId = T1.SupplierAgbTypeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Trn_supplieragbwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T1.SupplierAgbName) like '%' || LOWER(:lV79Trn_supplieragbwwds_1_filterfulltext)) or ( LOWER(T2.SupplierAgbTypeName) like '%' || LOWER(:lV79Trn_supplieragbwwds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbContactName) like '%' || LOWER(:lV79Trn_supplieragbwwds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbPhone) like '%' || LOWER(:lV79Trn_supplieragbwwds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbEmail) like '%' || LOWER(:lV79Trn_supplieragbwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int11[0] = 1;
            GXv_int11[1] = 1;
            GXv_int11[2] = 1;
            GXv_int11[3] = 1;
            GXv_int11[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Trn_supplieragbwwds_3_tfsupplieragbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Trn_supplieragbwwds_2_tfsupplieragbname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName like :lV80Trn_supplieragbwwds_2_tfsupplieragbname)");
         }
         else
         {
            GXv_int11[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Trn_supplieragbwwds_3_tfsupplieragbname_sel)) && ! ( StringUtil.StrCmp(AV81Trn_supplieragbwwds_3_tfsupplieragbname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName = ( :AV81Trn_supplieragbwwds_3_tfsupplieragbname_sel))");
         }
         else
         {
            GXv_int11[6] = 1;
         }
         if ( StringUtil.StrCmp(AV81Trn_supplieragbwwds_3_tfsupplieragbname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Trn_supplieragbwwds_5_tfsupplieragbtypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Trn_supplieragbwwds_4_tfsupplieragbtypename)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName like :lV82Trn_supplieragbwwds_4_tfsupplieragbtypename)");
         }
         else
         {
            GXv_int11[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Trn_supplieragbwwds_5_tfsupplieragbtypename_sel)) && ! ( StringUtil.StrCmp(AV83Trn_supplieragbwwds_5_tfsupplieragbtypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName = ( :AV83Trn_supplieragbwwds_5_tfsupplieragbtypename_sel))");
         }
         else
         {
            GXv_int11[8] = 1;
         }
         if ( StringUtil.StrCmp(AV83Trn_supplieragbwwds_5_tfsupplieragbtypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierAgbTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Trn_supplieragbwwds_6_tfsupplieragbcontactname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName like :lV84Trn_supplieragbwwds_6_tfsupplieragbcontactname)");
         }
         else
         {
            GXv_int11[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel)) && ! ( StringUtil.StrCmp(AV85Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName = ( :AV85Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel))");
         }
         else
         {
            GXv_int11[10] = 1;
         }
         if ( StringUtil.StrCmp(AV85Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Trn_supplieragbwwds_9_tfsupplieragbphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Trn_supplieragbwwds_8_tfsupplieragbphone)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone like :lV86Trn_supplieragbwwds_8_tfsupplieragbphone)");
         }
         else
         {
            GXv_int11[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Trn_supplieragbwwds_9_tfsupplieragbphone_sel)) && ! ( StringUtil.StrCmp(AV87Trn_supplieragbwwds_9_tfsupplieragbphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone = ( :AV87Trn_supplieragbwwds_9_tfsupplieragbphone_sel))");
         }
         else
         {
            GXv_int11[12] = 1;
         }
         if ( StringUtil.StrCmp(AV87Trn_supplieragbwwds_9_tfsupplieragbphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Trn_supplieragbwwds_11_tfsupplieragbemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Trn_supplieragbwwds_10_tfsupplieragbemail)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail like :lV88Trn_supplieragbwwds_10_tfsupplieragbemail)");
         }
         else
         {
            GXv_int11[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Trn_supplieragbwwds_11_tfsupplieragbemail_sel)) && ! ( StringUtil.StrCmp(AV89Trn_supplieragbwwds_11_tfsupplieragbemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail = ( :AV89Trn_supplieragbwwds_11_tfsupplieragbemail_sel))");
         }
         else
         {
            GXv_int11[14] = 1;
         }
         if ( StringUtil.StrCmp(AV89Trn_supplieragbwwds_11_tfsupplieragbemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbEmail))=0))");
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
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
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
                     return conditional_H004A2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (bool)dynConstraints[17] );
               case 1 :
                     return conditional_H004A3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (bool)dynConstraints[17] );
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
          Object[] prmH004A2;
          prmH004A2 = new Object[] {
          new ParDef("lV79Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV80Trn_supplieragbwwds_2_tfsupplieragbname",GXType.VarChar,100,0) ,
          new ParDef("AV81Trn_supplieragbwwds_3_tfsupplieragbname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV82Trn_supplieragbwwds_4_tfsupplieragbtypename",GXType.VarChar,100,0) ,
          new ParDef("AV83Trn_supplieragbwwds_5_tfsupplieragbtypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV84Trn_supplieragbwwds_6_tfsupplieragbcontactname",GXType.VarChar,100,0) ,
          new ParDef("AV85Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV86Trn_supplieragbwwds_8_tfsupplieragbphone",GXType.Char,20,0) ,
          new ParDef("AV87Trn_supplieragbwwds_9_tfsupplieragbphone_sel",GXType.Char,20,0) ,
          new ParDef("lV88Trn_supplieragbwwds_10_tfsupplieragbemail",GXType.VarChar,100,0) ,
          new ParDef("AV89Trn_supplieragbwwds_11_tfsupplieragbemail_sel",GXType.VarChar,100,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH004A3;
          prmH004A3 = new Object[] {
          new ParDef("lV79Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV79Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV80Trn_supplieragbwwds_2_tfsupplieragbname",GXType.VarChar,100,0) ,
          new ParDef("AV81Trn_supplieragbwwds_3_tfsupplieragbname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV82Trn_supplieragbwwds_4_tfsupplieragbtypename",GXType.VarChar,100,0) ,
          new ParDef("AV83Trn_supplieragbwwds_5_tfsupplieragbtypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV84Trn_supplieragbwwds_6_tfsupplieragbcontactname",GXType.VarChar,100,0) ,
          new ParDef("AV85Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV86Trn_supplieragbwwds_8_tfsupplieragbphone",GXType.Char,20,0) ,
          new ParDef("AV87Trn_supplieragbwwds_9_tfsupplieragbphone_sel",GXType.Char,20,0) ,
          new ParDef("lV88Trn_supplieragbwwds_10_tfsupplieragbemail",GXType.VarChar,100,0) ,
          new ParDef("AV89Trn_supplieragbwwds_11_tfsupplieragbemail_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004A2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004A2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004A3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004A3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((string[]) buf[12])[0] = rslt.getVarchar(13);
                ((Guid[]) buf[13])[0] = rslt.getGuid(14);
                ((string[]) buf[14])[0] = rslt.getVarchar(15);
                ((Guid[]) buf[15])[0] = rslt.getGuid(16);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
