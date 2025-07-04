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
   public class gamwwuserpermissions : GXDataArea
   {
      public gamwwuserpermissions( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gamwwuserpermissions( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UserId ,
                           long aP1_pApplicationId )
      {
         this.AV31UserId = aP0_UserId;
         this.AV24pApplicationId = aP1_pApplicationId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavApplicationid = new GXCombobox();
         cmbavPermissionaccesstype = new GXCombobox();
         cmbavBoolenfilter = new GXCombobox();
         cmbavAccesstype = new GXCombobox();
         chkavInherited = new GXCheckbox();
         cmbavOld_accesstype = new GXCombobox();
         chkavOld_inherited = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "UserId");
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
               gxfirstwebparm = GetFirstPar( "UserId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "UserId");
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
         nRC_GXsfl_57 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_57"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_57_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_57_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_57_idx = GetPar( "sGXsfl_57_idx");
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
         AV47ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV58Pgmname = GetPar( "Pgmname");
         cmbavApplicationid.FromJSonString( GetNextPar( ));
         AV10ApplicationId = (long)(Math.Round(NumberUtil.Val( GetPar( "ApplicationId"), "."), 18, MidpointRounding.ToEven));
         AV16FilName = GetPar( "FilName");
         cmbavPermissionaccesstype.FromJSonString( GetNextPar( ));
         AV26PermissionAccessType = GetPar( "PermissionAccessType");
         cmbavBoolenfilter.FromJSonString( GetNextPar( ));
         AV11BoolenFilter = GetPar( "BoolenFilter");
         AV31UserId = GetPar( "UserId");
         AV30SearchFilter = GetPar( "SearchFilter");
         AV52IsAuthorized_Back = StringUtil.StrToBool( GetPar( "IsAuthorized_Back"));
         AV53IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         AV24pApplicationId = (long)(Math.Round(NumberUtil.Val( GetPar( "pApplicationId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV47ManageFiltersExecutionStep, AV58Pgmname, AV10ApplicationId, AV16FilName, AV26PermissionAccessType, AV11BoolenFilter, AV31UserId, AV30SearchFilter, AV52IsAuthorized_Back, AV53IsAuthorized_Insert, AV24pApplicationId) ;
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
            return "gamwwuserpermissions_Execute" ;
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
         PA8A2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START8A2( ) ;
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "gamwwuserpermissions.aspx"+UrlEncode(StringUtil.RTrim(AV31UserId)) + "," + UrlEncode(StringUtil.LTrimStr(AV24pApplicationId,12,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamwwuserpermissions.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vUSERID", StringUtil.RTrim( AV31UserId));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV31UserId, "")), context));
         GxWebStd.gx_hidden_field( context, "vSEARCHFILTER", StringUtil.RTrim( AV30SearchFilter));
         GxWebStd.gx_hidden_field( context, "gxhash_vSEARCHFILTER", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV30SearchFilter, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_BACK", AV52IsAuthorized_Back);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BACK", GetSecureSignedToken( "", AV52IsAuthorized_Back, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV53IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV53IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "vPAPPLICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24pApplicationId), 12, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPAPPLICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV24pApplicationId), "ZZZZZZZZZZZ9"), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_57", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_57), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV45ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV45ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV49GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV55GridAppliedFilters);
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV58Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV58Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERID", StringUtil.RTrim( AV31UserId));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV31UserId, "")), context));
         GxWebStd.gx_hidden_field( context, "vSEARCHFILTER", StringUtil.RTrim( AV30SearchFilter));
         GxWebStd.gx_hidden_field( context, "gxhash_vSEARCHFILTER", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV30SearchFilter, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV42GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV42GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_BACK", AV52IsAuthorized_Back);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BACK", GetSecureSignedToken( "", AV52IsAuthorized_Back, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV53IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV53IsAuthorized_Insert, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISOK", AV20isOK);
         GxWebStd.gx_hidden_field( context, "vPAPPLICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24pApplicationId), 12, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPAPPLICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV24pApplicationId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "subGrid_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Recordcount), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
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
            WE8A2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT8A2( ) ;
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
         GXEncryptionTmp = "gamwwuserpermissions.aspx"+UrlEncode(StringUtil.RTrim(AV31UserId)) + "," + UrlEncode(StringUtil.LTrimStr(AV24pApplicationId,12,0));
         return formatLink("gamwwuserpermissions.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "GAMWWUserPermissions" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WWP_GAM_UserPermissions", "") ;
      }

      protected void WB8A0( )
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
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidthAuto", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "TableCellsWidthAuto", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColoredActions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            ClassString = "ButtonColorFilled";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnback_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(57), 2, 0)+","+"null"+");", context.GetMessage( "WWP_GAM_Back", ""), bttBtnback_Jsonclick, 5, context.GetMessage( "WWP_GAM_Back", ""), "", StyleString, ClassString, bttBtnback_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBACK\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMWWUserPermissions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "Button ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(57), 2, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMWWUserPermissions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ButtonColorFilled";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsave_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(57), 2, 0)+","+"null"+");", context.GetMessage( "WWP_GAM_SaveChanges", ""), bttBtnsave_Jsonclick, 5, context.GetMessage( "WWP_GAM_SaveChanges", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOSAVE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMWWUserPermissions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs col-sm-6 CellFloatRight CellWidthAuto", "start", "top", "", "", "div");
            wb_table1_23_8A2( true) ;
         }
         else
         {
            wb_table1_23_8A2( false) ;
         }
         return  ;
      }

      protected void wb_table1_23_8A2e( bool wbgen )
      {
         if ( wbgen )
         {
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl57( ) ;
         }
         if ( wbEnd == 57 )
         {
            wbEnd = 0;
            nRC_GXsfl_57 = (int)(nGXsfl_57_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV49GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV50GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV55GridAppliedFilters);
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
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 57 )
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

      protected void START8A2( )
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
         Form.Meta.addItem("description", context.GetMessage( "WWP_GAM_UserPermissions", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP8A0( ) ;
      }

      protected void WS8A2( )
      {
         START8A2( ) ;
         EVT8A2( ) ;
      }

      protected void EVT8A2( )
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
                              E118A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E128A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E138A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBACK'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBack' */
                              E148A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E158A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOSAVE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoSave' */
                              E168A2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VDELETE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VDELETE.CLICK") == 0 ) )
                           {
                              nGXsfl_57_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
                              SubsflControlProps_572( ) ;
                              AV51Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV51Delete);
                              AV21Name = cgiGet( edtavName_Internalname);
                              AssignAttri("", false, edtavName_Internalname, AV21Name);
                              AV13Dsc = cgiGet( edtavDsc_Internalname);
                              AssignAttri("", false, edtavDsc_Internalname, AV13Dsc);
                              cmbavAccesstype.Name = cmbavAccesstype_Internalname;
                              cmbavAccesstype.CurrentValue = cgiGet( cmbavAccesstype_Internalname);
                              AV7AccessType = cgiGet( cmbavAccesstype_Internalname);
                              AssignAttri("", false, cmbavAccesstype_Internalname, AV7AccessType);
                              GxWebStd.gx_hidden_field( context, "gxhash_vACCESSTYPE"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, StringUtil.RTrim( context.localUtil.Format( AV7AccessType, "")), context));
                              AV19Inherited = StringUtil.StrToBool( cgiGet( chkavInherited_Internalname));
                              AssignAttri("", false, chkavInherited_Internalname, AV19Inherited);
                              GxWebStd.gx_hidden_field( context, "gxhash_vINHERITED"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, AV19Inherited, context));
                              AV12BtnDlt = cgiGet( edtavBtndlt_Internalname);
                              AssignAttri("", false, edtavBtndlt_Internalname, AV12BtnDlt);
                              cmbavOld_accesstype.Name = cmbavOld_accesstype_Internalname;
                              cmbavOld_accesstype.CurrentValue = cgiGet( cmbavOld_accesstype_Internalname);
                              AV22old_AccessType = cgiGet( cmbavOld_accesstype_Internalname);
                              AssignAttri("", false, cmbavOld_accesstype_Internalname, AV22old_AccessType);
                              GxWebStd.gx_hidden_field( context, "gxhash_vOLD_ACCESSTYPE"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, StringUtil.RTrim( context.localUtil.Format( AV22old_AccessType, "")), context));
                              AV23old_Inherited = StringUtil.StrToBool( cgiGet( chkavOld_inherited_Internalname));
                              AssignAttri("", false, chkavOld_inherited_Internalname, AV23old_Inherited);
                              GxWebStd.gx_hidden_field( context, "gxhash_vOLD_INHERITED"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, AV23old_Inherited, context));
                              AV18Id = cgiGet( edtavId_Internalname);
                              AssignAttri("", false, edtavId_Internalname, AV18Id);
                              GxWebStd.gx_hidden_field( context, "gxhash_vID"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, StringUtil.RTrim( context.localUtil.Format( AV18Id, "")), context));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E178A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E188A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E198A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VDELETE.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E208A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
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

      protected void WE8A2( )
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

      protected void PA8A2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "gamwwuserpermissions.aspx")), "gamwwuserpermissions.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "gamwwuserpermissions.aspx")))) ;
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
                  gxfirstwebparm = GetFirstPar( "UserId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV31UserId = gxfirstwebparm;
                     AssignAttri("", false, "AV31UserId", AV31UserId);
                     GxWebStd.gx_hidden_field( context, "gxhash_vUSERID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV31UserId, "")), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV24pApplicationId = (long)(Math.Round(NumberUtil.Val( GetPar( "pApplicationId"), "."), 18, MidpointRounding.ToEven));
                        AssignAttri("", false, "AV24pApplicationId", StringUtil.LTrimStr( (decimal)(AV24pApplicationId), 12, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vPAPPLICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV24pApplicationId), "ZZZZZZZZZZZ9"), context));
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
               GX_FocusControl = cmbavApplicationid_Internalname;
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
         SubsflControlProps_572( ) ;
         while ( nGXsfl_57_idx <= nRC_GXsfl_57 )
         {
            sendrow_572( ) ;
            nGXsfl_57_idx = ((subGrid_Islastpage==1)&&(nGXsfl_57_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_57_idx+1);
            sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
            SubsflControlProps_572( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV47ManageFiltersExecutionStep ,
                                       string AV58Pgmname ,
                                       long AV10ApplicationId ,
                                       string AV16FilName ,
                                       string AV26PermissionAccessType ,
                                       string AV11BoolenFilter ,
                                       string AV31UserId ,
                                       string AV30SearchFilter ,
                                       bool AV52IsAuthorized_Back ,
                                       bool AV53IsAuthorized_Insert ,
                                       long AV24pApplicationId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF8A2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vACCESSTYPE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7AccessType, "")), context));
         GxWebStd.gx_hidden_field( context, "vACCESSTYPE", StringUtil.RTrim( AV7AccessType));
         GxWebStd.gx_hidden_field( context, "gxhash_vOLD_ACCESSTYPE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV22old_AccessType, "")), context));
         GxWebStd.gx_hidden_field( context, "vOLD_ACCESSTYPE", StringUtil.RTrim( AV22old_AccessType));
         GxWebStd.gx_hidden_field( context, "gxhash_vINHERITED", GetSecureSignedToken( "", AV19Inherited, context));
         GxWebStd.gx_hidden_field( context, "vINHERITED", StringUtil.BoolToStr( AV19Inherited));
         GxWebStd.gx_hidden_field( context, "gxhash_vOLD_INHERITED", GetSecureSignedToken( "", AV23old_Inherited, context));
         GxWebStd.gx_hidden_field( context, "vOLD_INHERITED", StringUtil.BoolToStr( AV23old_Inherited));
         GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18Id, "")), context));
         GxWebStd.gx_hidden_field( context, "vID", StringUtil.RTrim( AV18Id));
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
         if ( cmbavApplicationid.ItemCount > 0 )
         {
            AV10ApplicationId = (long)(Math.Round(NumberUtil.Val( cmbavApplicationid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV10ApplicationId), 12, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV10ApplicationId", StringUtil.LTrimStr( (decimal)(AV10ApplicationId), 12, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavApplicationid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV10ApplicationId), 12, 0));
            AssignProp("", false, cmbavApplicationid_Internalname, "Values", cmbavApplicationid.ToJavascriptSource(), true);
         }
         if ( cmbavPermissionaccesstype.ItemCount > 0 )
         {
            AV26PermissionAccessType = cmbavPermissionaccesstype.getValidValue(AV26PermissionAccessType);
            AssignAttri("", false, "AV26PermissionAccessType", AV26PermissionAccessType);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavPermissionaccesstype.CurrentValue = StringUtil.RTrim( AV26PermissionAccessType);
            AssignProp("", false, cmbavPermissionaccesstype_Internalname, "Values", cmbavPermissionaccesstype.ToJavascriptSource(), true);
         }
         if ( cmbavBoolenfilter.ItemCount > 0 )
         {
            AV11BoolenFilter = cmbavBoolenfilter.getValidValue(AV11BoolenFilter);
            AssignAttri("", false, "AV11BoolenFilter", AV11BoolenFilter);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavBoolenfilter.CurrentValue = StringUtil.RTrim( AV11BoolenFilter);
            AssignProp("", false, cmbavBoolenfilter_Internalname, "Values", cmbavBoolenfilter.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF8A2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV58Pgmname = "GAMWWUserPermissions";
         edtavDelete_Enabled = 0;
         edtavName_Enabled = 0;
         edtavDsc_Enabled = 0;
         cmbavAccesstype.Enabled = 0;
         chkavInherited.Enabled = 0;
         edtavBtndlt_Enabled = 0;
         cmbavOld_accesstype.Enabled = 0;
         chkavOld_inherited.Enabled = 0;
         edtavId_Enabled = 0;
      }

      protected void RF8A2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 57;
         /* Execute user event: Refresh */
         E188A2 ();
         nGXsfl_57_idx = 1;
         sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
         SubsflControlProps_572( ) ;
         bGXsfl_57_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( subGrid_Islastpage != 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordcount( )-subGrid_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
            GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_572( ) ;
            /* Execute user event: Grid.Load */
            E198A2 ();
            if ( ( subGrid_Islastpage == 0 ) && ( GRID_nCurrentRecord > 0 ) && ( GRID_nGridOutOfScope == 0 ) && ( nGXsfl_57_idx == 1 ) )
            {
               GRID_nCurrentRecord = 0;
               GRID_nGridOutOfScope = 1;
               subgrid_firstpage( ) ;
               /* Execute user event: Grid.Load */
               E198A2 ();
            }
            wbEnd = 57;
            WB8A0( ) ;
         }
         bGXsfl_57_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes8A2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV58Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV58Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vSEARCHFILTER", StringUtil.RTrim( AV30SearchFilter));
         GxWebStd.gx_hidden_field( context, "gxhash_vSEARCHFILTER", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV30SearchFilter, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_BACK", AV52IsAuthorized_Back);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BACK", GetSecureSignedToken( "", AV52IsAuthorized_Back, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV53IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV53IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vACCESSTYPE"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, StringUtil.RTrim( context.localUtil.Format( AV7AccessType, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vOLD_ACCESSTYPE"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, StringUtil.RTrim( context.localUtil.Format( AV22old_AccessType, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vINHERITED"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, AV19Inherited, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vOLD_INHERITED"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, AV23old_Inherited, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vID"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, StringUtil.RTrim( context.localUtil.Format( AV18Id, "")), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return (int)(((subGrid_Recordcount==0) ? GRID_nFirstRecordOnPage+1 : subGrid_Recordcount)) ;
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
         return (int)(((subGrid_Islastpage==1) ? NumberUtil.Int( (long)(Math.Round(subGrid_fnc_Recordcount( )/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+((((int)((subGrid_fnc_Recordcount( )) % (subGrid_fnc_Recordsperpage( ))))==0) ? 0 : 1) : NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1)) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV47ManageFiltersExecutionStep, AV58Pgmname, AV10ApplicationId, AV16FilName, AV26PermissionAccessType, AV11BoolenFilter, AV31UserId, AV30SearchFilter, AV52IsAuthorized_Back, AV53IsAuthorized_Insert, AV24pApplicationId) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV47ManageFiltersExecutionStep, AV58Pgmname, AV10ApplicationId, AV16FilName, AV26PermissionAccessType, AV11BoolenFilter, AV31UserId, AV30SearchFilter, AV52IsAuthorized_Back, AV53IsAuthorized_Insert, AV24pApplicationId) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV47ManageFiltersExecutionStep, AV58Pgmname, AV10ApplicationId, AV16FilName, AV26PermissionAccessType, AV11BoolenFilter, AV31UserId, AV30SearchFilter, AV52IsAuthorized_Back, AV53IsAuthorized_Insert, AV24pApplicationId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         subGrid_Islastpage = 1;
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV47ManageFiltersExecutionStep, AV58Pgmname, AV10ApplicationId, AV16FilName, AV26PermissionAccessType, AV11BoolenFilter, AV31UserId, AV30SearchFilter, AV52IsAuthorized_Back, AV53IsAuthorized_Insert, AV24pApplicationId) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV47ManageFiltersExecutionStep, AV58Pgmname, AV10ApplicationId, AV16FilName, AV26PermissionAccessType, AV11BoolenFilter, AV31UserId, AV30SearchFilter, AV52IsAuthorized_Back, AV53IsAuthorized_Insert, AV24pApplicationId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV58Pgmname = "GAMWWUserPermissions";
         edtavDelete_Enabled = 0;
         edtavName_Enabled = 0;
         edtavDsc_Enabled = 0;
         cmbavAccesstype.Enabled = 0;
         chkavInherited.Enabled = 0;
         edtavBtndlt_Enabled = 0;
         cmbavOld_accesstype.Enabled = 0;
         chkavOld_inherited.Enabled = 0;
         edtavId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP8A0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E178A2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV45ManageFiltersData);
            /* Read saved values. */
            nRC_GXsfl_57 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_57"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV49GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV50GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV55GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "subGrid_Recordcount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            cmbavApplicationid.Name = cmbavApplicationid_Internalname;
            cmbavApplicationid.CurrentValue = cgiGet( cmbavApplicationid_Internalname);
            AV10ApplicationId = (long)(Math.Round(NumberUtil.Val( cgiGet( cmbavApplicationid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV10ApplicationId", StringUtil.LTrimStr( (decimal)(AV10ApplicationId), 12, 0));
            AV16FilName = cgiGet( edtavFilname_Internalname);
            AssignAttri("", false, "AV16FilName", AV16FilName);
            cmbavPermissionaccesstype.Name = cmbavPermissionaccesstype_Internalname;
            cmbavPermissionaccesstype.CurrentValue = cgiGet( cmbavPermissionaccesstype_Internalname);
            AV26PermissionAccessType = cgiGet( cmbavPermissionaccesstype_Internalname);
            AssignAttri("", false, "AV26PermissionAccessType", AV26PermissionAccessType);
            cmbavBoolenfilter.Name = cmbavBoolenfilter_Internalname;
            cmbavBoolenfilter.CurrentValue = cgiGet( cmbavBoolenfilter_Internalname);
            AV11BoolenFilter = cgiGet( cmbavBoolenfilter_Internalname);
            AssignAttri("", false, "AV11BoolenFilter", AV11BoolenFilter);
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
         E178A2 ();
         if (returnInSub) return;
      }

      protected void E178A2( )
      {
         /* Start Routine */
         returnInSub = false;
         cmbavApplicationid.removeAllItems();
         cmbavApplicationid.addItem("0", context.GetMessage( "(Select)", ""), 0);
         AV57GXV2 = 1;
         AV56GXV1 = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getapplications(AV9ApplicationFilter, out  AV15Errors);
         while ( AV57GXV2 <= AV56GXV1.Count )
         {
            AV8Application = ((GeneXus.Programs.genexussecurity.SdtGAMApplication)AV56GXV1.Item(AV57GXV2));
            cmbavApplicationid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV8Application.gxTpr_Id), 12, 0)), AV8Application.gxTpr_Name, 0);
            AV57GXV2 = (int)(AV57GXV2+1);
         }
         if ( cmbavApplicationid.ItemCount == 2 )
         {
            AV10ApplicationId = AV8Application.gxTpr_Id;
            AssignAttri("", false, "AV10ApplicationId", StringUtil.LTrimStr( (decimal)(AV10ApplicationId), 12, 0));
         }
         else
         {
            AV10ApplicationId = AV24pApplicationId;
            AssignAttri("", false, "AV10ApplicationId", StringUtil.LTrimStr( (decimal)(AV10ApplicationId), 12, 0));
         }
         AV32GAMUser.load( AV31UserId);
         AV35UserName = StringUtil.Trim( AV32GAMUser.gxTpr_Firstname) + " " + StringUtil.Trim( AV32GAMUser.gxTpr_Lastname);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV35UserName)) )
         {
            AV35UserName = StringUtil.Trim( AV32GAMUser.gxTpr_Login);
         }
         Form.Caption = StringUtil.Format( context.GetMessage( "WWP_GAM_PermissionsOfUser", ""), AV35UserName, "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         if ( StringUtil.StrCmp(AV39HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if (returnInSub) return;
         }
         Form.Caption = context.GetMessage( "WWP_GAM_UserPermissions", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if (returnInSub) return;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E188A2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV37WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S132 ();
         if (returnInSub) return;
         if ( AV47ManageFiltersExecutionStep == 1 )
         {
            AV47ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV47ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV47ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV47ManageFiltersExecutionStep == 2 )
         {
            AV47ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV47ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV47ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S142 ();
         if (returnInSub) return;
         AV49GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV49GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV49GridCurrentPage), 10, 0));
         GXt_char1 = AV55GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV58Pgmname, out  GXt_char1) ;
         AV55GridAppliedFilters = GXt_char1;
         AssignAttri("", false, "AV55GridAppliedFilters", AV55GridAppliedFilters);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV45ManageFiltersData", AV45ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42GridState", AV42GridState);
      }

      protected void E128A2( )
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
            AV48PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV48PageToGo) ;
         }
      }

      protected void E138A2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      private void E198A2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV6GridPageSize = subGrid_Rows;
         AV32GAMUser.load( AV31UserId);
         AV33GAMUserName = AV32GAMUser.gxTpr_Name;
         AV34UserPermissionFilter.gxTpr_Applicationid = AV10ApplicationId;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16FilName)) )
         {
            AV34UserPermissionFilter.gxTpr_Name = "%"+AV16FilName;
         }
         else
         {
            AV34UserPermissionFilter.gxTpr_Name = "%"+AV30SearchFilter;
         }
         AV34UserPermissionFilter.gxTpr_Accesstype = AV26PermissionAccessType;
         AV34UserPermissionFilter.gxTpr_Inherited = AV11BoolenFilter;
         if ( ! (0==AV10ApplicationId) )
         {
            AV54Permissions = AV32GAMUser.getpermissions(AV34UserPermissionFilter, out  AV15Errors);
            if ( AV54Permissions.Count == 0 )
            {
               AV50GridPageCount = 0;
               AssignAttri("", false, "AV50GridPageCount", StringUtil.LTrimStr( (decimal)(AV50GridPageCount), 10, 0));
            }
            else
            {
               AV50GridPageCount = (long)((AV54Permissions.Count/ (decimal)(AV6GridPageSize))+((((int)((AV54Permissions.Count) % (AV6GridPageSize)))>0) ? 1 : 0));
               AssignAttri("", false, "AV50GridPageCount", StringUtil.LTrimStr( (decimal)(AV50GridPageCount), 10, 0));
            }
            AV5GridRecordCount = AV54Permissions.Count;
            AV59GXV3 = 1;
            while ( AV59GXV3 <= AV54Permissions.Count )
            {
               AV25Permission = ((GeneXus.Programs.genexussecurity.SdtGAMPermission)AV54Permissions.Item(AV59GXV3));
               AV12BtnDlt = "Delete";
               AssignAttri("", false, edtavBtndlt_Internalname, AV12BtnDlt);
               AV18Id = AV25Permission.gxTpr_Guid;
               AssignAttri("", false, edtavId_Internalname, AV18Id);
               GxWebStd.gx_hidden_field( context, "gxhash_vID"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, StringUtil.RTrim( context.localUtil.Format( AV18Id, "")), context));
               AV21Name = AV25Permission.gxTpr_Name;
               AssignAttri("", false, edtavName_Internalname, AV21Name);
               AV13Dsc = AV25Permission.gxTpr_Description;
               AssignAttri("", false, edtavDsc_Internalname, AV13Dsc);
               AV7AccessType = AV25Permission.gxTpr_Type;
               AssignAttri("", false, cmbavAccesstype_Internalname, AV7AccessType);
               GxWebStd.gx_hidden_field( context, "gxhash_vACCESSTYPE"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, StringUtil.RTrim( context.localUtil.Format( AV7AccessType, "")), context));
               AV19Inherited = AV25Permission.gxTpr_Inherited;
               AssignAttri("", false, chkavInherited_Internalname, AV19Inherited);
               GxWebStd.gx_hidden_field( context, "gxhash_vINHERITED"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, AV19Inherited, context));
               AV22old_AccessType = AV25Permission.gxTpr_Type;
               AssignAttri("", false, cmbavOld_accesstype_Internalname, AV22old_AccessType);
               GxWebStd.gx_hidden_field( context, "gxhash_vOLD_ACCESSTYPE"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, StringUtil.RTrim( context.localUtil.Format( AV22old_AccessType, "")), context));
               AV23old_Inherited = AV25Permission.gxTpr_Inherited;
               AssignAttri("", false, chkavOld_inherited_Internalname, AV23old_Inherited);
               GxWebStd.gx_hidden_field( context, "gxhash_vOLD_INHERITED"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, AV23old_Inherited, context));
               AV51Delete = "<i class=\"fa fa-times\"></i>";
               AssignAttri("", false, edtavDelete_Internalname, AV51Delete);
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 57;
               }
               if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
               {
                  sendrow_572( ) ;
               }
               GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
               GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
               GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
               subGrid_Recordcount = (int)(GRID_nCurrentRecord);
               if ( isFullAjaxMode( ) && ! bGXsfl_57_Refreshing )
               {
                  DoAjaxLoad(57, GridRow);
               }
               AV59GXV3 = (int)(AV59GXV3+1);
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV34UserPermissionFilter", AV34UserPermissionFilter);
         cmbavAccesstype.CurrentValue = StringUtil.RTrim( AV7AccessType);
         cmbavOld_accesstype.CurrentValue = StringUtil.RTrim( AV22old_AccessType);
      }

      protected void E118A2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S152 ();
            if (returnInSub) return;
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S142 ();
            if (returnInSub) return;
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("GAMWWUserPermissionsFilters")) + "," + UrlEncode(StringUtil.RTrim(AV58Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV47ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV47ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV47ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("GAMWWUserPermissionsFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV47ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV47ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV47ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char1 = AV46ManageFiltersXml;
            new WorkWithPlus.workwithplus_web.getfilterbyname(context ).execute(  "GAMWWUserPermissionsFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char1) ;
            AV46ManageFiltersXml = GXt_char1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S152 ();
               if (returnInSub) return;
               new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV58Pgmname+"GridState",  AV46ManageFiltersXml) ;
               AV42GridState.FromXml(AV46ManageFiltersXml, null, "", "");
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S162 ();
               if (returnInSub) return;
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42GridState", AV42GridState);
         cmbavApplicationid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV10ApplicationId), 12, 0));
         AssignProp("", false, cmbavApplicationid_Internalname, "Values", cmbavApplicationid.ToJavascriptSource(), true);
         cmbavPermissionaccesstype.CurrentValue = StringUtil.RTrim( AV26PermissionAccessType);
         AssignProp("", false, cmbavPermissionaccesstype_Internalname, "Values", cmbavPermissionaccesstype.ToJavascriptSource(), true);
         cmbavBoolenfilter.CurrentValue = StringUtil.RTrim( AV11BoolenFilter);
         AssignProp("", false, cmbavBoolenfilter_Internalname, "Values", cmbavBoolenfilter.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV45ManageFiltersData", AV45ManageFiltersData);
      }

      protected void E148A2( )
      {
         /* 'DoBack' Routine */
         returnInSub = false;
         if ( AV52IsAuthorized_Back )
         {
            CallWebObject(formatLink("gamwwusers.aspx") );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV45ManageFiltersData", AV45ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42GridState", AV42GridState);
      }

      protected void E158A2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( ! (0==AV10ApplicationId) )
         {
            if ( AV53IsAuthorized_Insert )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "gamuserpermissionselect.aspx"+UrlEncode(StringUtil.RTrim(AV31UserId)) + "," + UrlEncode(StringUtil.LTrimStr(AV10ApplicationId,12,0));
               CallWebObject(formatLink("gamuserpermissionselect.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
               context.wjLocDisableFrm = 1;
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
               context.DoAjaxRefresh();
            }
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_GAM_SelectApplication", ""));
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV45ManageFiltersData", AV45ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42GridState", AV42GridState);
      }

      protected void E168A2( )
      {
         /* 'DoSave' Routine */
         returnInSub = false;
         AV32GAMUser.load( AV31UserId);
         /* Start For Each Line */
         nRC_GXsfl_57 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_57"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         nGXsfl_57_fel_idx = 0;
         while ( nGXsfl_57_fel_idx < nRC_GXsfl_57 )
         {
            nGXsfl_57_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_57_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_57_fel_idx+1);
            sGXsfl_57_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_572( ) ;
            AV51Delete = cgiGet( edtavDelete_Internalname);
            AV21Name = cgiGet( edtavName_Internalname);
            AV13Dsc = cgiGet( edtavDsc_Internalname);
            cmbavAccesstype.Name = cmbavAccesstype_Internalname;
            cmbavAccesstype.CurrentValue = cgiGet( cmbavAccesstype_Internalname);
            AV7AccessType = cgiGet( cmbavAccesstype_Internalname);
            AV19Inherited = StringUtil.StrToBool( cgiGet( chkavInherited_Internalname));
            AV12BtnDlt = cgiGet( edtavBtndlt_Internalname);
            cmbavOld_accesstype.Name = cmbavOld_accesstype_Internalname;
            cmbavOld_accesstype.CurrentValue = cgiGet( cmbavOld_accesstype_Internalname);
            AV22old_AccessType = cgiGet( cmbavOld_accesstype_Internalname);
            AV23old_Inherited = StringUtil.StrToBool( cgiGet( chkavOld_inherited_Internalname));
            AV18Id = cgiGet( edtavId_Internalname);
            if ( ( StringUtil.StrCmp(AV7AccessType, AV22old_AccessType) != 0 ) || ( AV19Inherited != AV23old_Inherited ) )
            {
               AV27PermissionUpd.gxTpr_Applicationid = AV10ApplicationId;
               AV27PermissionUpd.gxTpr_Guid = AV18Id;
               AV27PermissionUpd.gxTpr_Type = AV7AccessType;
               AV27PermissionUpd.gxTpr_Inherited = AV19Inherited;
               AV20isOK = AV32GAMUser.updatepermission(AV27PermissionUpd, out  AV15Errors);
               AssignAttri("", false, "AV20isOK", AV20isOK);
               if ( ! AV20isOK )
               {
                  AV61GXV4 = 1;
                  while ( AV61GXV4 <= AV15Errors.Count )
                  {
                     AV14Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV15Errors.Item(AV61GXV4));
                     GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV14Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV14Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
                     AV61GXV4 = (int)(AV61GXV4+1);
                  }
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            /* End For Each Line */
         }
         if ( nGXsfl_57_fel_idx == 0 )
         {
            nGXsfl_57_idx = 1;
            sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
            SubsflControlProps_572( ) ;
         }
         nGXsfl_57_fel_idx = 1;
         if ( AV20isOK )
         {
            context.CommitDataStores("gamwwuserpermissions",pr_default);
            GX_msglist.addItem(context.GetMessage( "Changes saved successfully.", ""));
         }
         else
         {
            AV62GXV5 = 1;
            while ( AV62GXV5 <= AV15Errors.Count )
            {
               AV14Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV15Errors.Item(AV62GXV5));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV14Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV14Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV62GXV5 = (int)(AV62GXV5+1);
            }
         }
         gxgrGrid_refresh( subGrid_Rows, AV47ManageFiltersExecutionStep, AV58Pgmname, AV10ApplicationId, AV16FilName, AV26PermissionAccessType, AV11BoolenFilter, AV31UserId, AV30SearchFilter, AV52IsAuthorized_Back, AV53IsAuthorized_Insert, AV24pApplicationId) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27PermissionUpd", AV27PermissionUpd);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV45ManageFiltersData", AV45ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42GridState", AV42GridState);
      }

      protected void S132( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean2 = AV52IsAuthorized_Back;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "gamwwusers_Execute", out  GXt_boolean2) ;
         AV52IsAuthorized_Back = GXt_boolean2;
         AssignAttri("", false, "AV52IsAuthorized_Back", AV52IsAuthorized_Back);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BACK", GetSecureSignedToken( "", AV52IsAuthorized_Back, context));
         if ( ! ( AV52IsAuthorized_Back ) )
         {
            bttBtnback_Visible = 0;
            AssignProp("", false, bttBtnback_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnback_Visible), 5, 0), true);
         }
         GXt_boolean2 = AV53IsAuthorized_Insert;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "gamuserpermissionselect_Execute", out  GXt_boolean2) ;
         AV53IsAuthorized_Insert = GXt_boolean2;
         AssignAttri("", false, "AV53IsAuthorized_Insert", AV53IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV53IsAuthorized_Insert, context));
         if ( ! ( AV53IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV45ManageFiltersData;
         new WorkWithPlus.workwithplus_web.wwp_managefiltersloadsavedfilters(context ).execute(  "GAMWWUserPermissionsFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV45ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S152( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV10ApplicationId = 0;
         AssignAttri("", false, "AV10ApplicationId", StringUtil.LTrimStr( (decimal)(AV10ApplicationId), 12, 0));
         AV16FilName = "";
         AssignAttri("", false, "AV16FilName", AV16FilName);
         AV26PermissionAccessType = "";
         AssignAttri("", false, "AV26PermissionAccessType", AV26PermissionAccessType);
         AV11BoolenFilter = "";
         AssignAttri("", false, "AV11BoolenFilter", AV11BoolenFilter);
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV44Session.Get(AV58Pgmname+"GridState"), "") == 0 )
         {
            AV42GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV58Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV42GridState.FromXml(AV44Session.Get(AV58Pgmname+"GridState"), null, "", "");
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S162 ();
         if (returnInSub) return;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV42GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV42GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV42GridState.gxTpr_Currentpage) ;
      }

      protected void S162( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV63GXV6 = 1;
         while ( AV63GXV6 <= AV42GridState.gxTpr_Filtervalues.Count )
         {
            AV43GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV42GridState.gxTpr_Filtervalues.Item(AV63GXV6));
            if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "APPLICATIONID") == 0 )
            {
               AV10ApplicationId = (long)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV10ApplicationId", StringUtil.LTrimStr( (decimal)(AV10ApplicationId), 12, 0));
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "FILNAME") == 0 )
            {
               AV16FilName = AV43GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV16FilName", AV16FilName);
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "PERMISSIONACCESSTYPE") == 0 )
            {
               AV26PermissionAccessType = AV43GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV26PermissionAccessType", AV26PermissionAccessType);
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "BOOLENFILTER") == 0 )
            {
               AV11BoolenFilter = AV43GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV11BoolenFilter", AV11BoolenFilter);
            }
            AV63GXV6 = (int)(AV63GXV6+1);
         }
      }

      protected void S142( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV42GridState.FromXml(AV44Session.Get(AV58Pgmname+"GridState"), null, "", "");
         AV42GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV42GridState,  "APPLICATIONID",  context.GetMessage( "WWP_GAM_Application", ""),  !(0==AV10ApplicationId),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV10ApplicationId), 12, 0)),  StringUtil.Trim( context.localUtil.Format( (decimal)(AV10ApplicationId), "ZZZZZZZZZZZ9")),  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV42GridState,  "FILNAME",  context.GetMessage( "WWP_GAM_Search", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV16FilName)),  0,  AV16FilName,  AV16FilName,  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV42GridState,  "PERMISSIONACCESSTYPE",  context.GetMessage( "WWP_GAM_AccessType", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV26PermissionAccessType)),  0,  AV26PermissionAccessType,  AV26PermissionAccessType,  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV42GridState,  "BOOLENFILTER",  context.GetMessage( "WWP_GAM_Inherited", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV11BoolenFilter)),  0,  AV11BoolenFilter,  AV11BoolenFilter,  false,  "",  "") ;
         AV42GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV42GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV58Pgmname+"GridState",  AV42GridState.ToXml(false, true, "", "")) ;
      }

      protected void E208A2( )
      {
         /* Delete_Click Routine */
         returnInSub = false;
         AV32GAMUser.load( AV31UserId);
         AV20isOK = AV32GAMUser.deletepermissionbyid(AV10ApplicationId, AV18Id, out  AV15Errors);
         AssignAttri("", false, "AV20isOK", AV20isOK);
         if ( AV20isOK )
         {
            context.CommitDataStores("gamwwuserpermissions",pr_default);
         }
         else
         {
            AV64GXV7 = 1;
            while ( AV64GXV7 <= AV15Errors.Count )
            {
               AV14Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV15Errors.Item(AV64GXV7));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV14Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV14Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV64GXV7 = (int)(AV64GXV7+1);
            }
         }
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV45ManageFiltersData", AV45ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42GridState", AV42GridState);
      }

      protected void wb_table1_23_8A2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablerightheader_Internalname, tblTablerightheader_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucDdo_managefilters.SetProperty("IconType", Ddo_managefilters_Icontype);
            ucDdo_managefilters.SetProperty("Icon", Ddo_managefilters_Icon);
            ucDdo_managefilters.SetProperty("Caption", Ddo_managefilters_Caption);
            ucDdo_managefilters.SetProperty("Tooltip", Ddo_managefilters_Tooltip);
            ucDdo_managefilters.SetProperty("Cls", Ddo_managefilters_Cls);
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV45ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablefilters_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellFormGroupMarginBottom5", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavApplicationid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavApplicationid_Internalname, context.GetMessage( "WWP_GAM_Application", ""), "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'" + sGXsfl_57_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavApplicationid, cmbavApplicationid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV10ApplicationId), 12, 0)), 1, cmbavApplicationid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavApplicationid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "", true, 0, "HLP_GAMWWUserPermissions.htm");
            cmbavApplicationid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV10ApplicationId), 12, 0));
            AssignProp("", false, cmbavApplicationid_Internalname, "Values", (string)(cmbavApplicationid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellFormGroupMarginBottom5", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFilname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilname_Internalname, context.GetMessage( "WWP_GAM_Search", ""), "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'" + sGXsfl_57_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilname_Internalname, AV16FilName, StringUtil.RTrim( context.localUtil.Format( AV16FilName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFilname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_GAMWWUserPermissions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellFormGroupMarginBottom5", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavPermissionaccesstype_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavPermissionaccesstype_Internalname, context.GetMessage( "WWP_GAM_AccessType", ""), "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_57_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavPermissionaccesstype, cmbavPermissionaccesstype_Internalname, StringUtil.RTrim( AV26PermissionAccessType), 1, cmbavPermissionaccesstype_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavPermissionaccesstype.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 0, "HLP_GAMWWUserPermissions.htm");
            cmbavPermissionaccesstype.CurrentValue = StringUtil.RTrim( AV26PermissionAccessType);
            AssignProp("", false, cmbavPermissionaccesstype_Internalname, "Values", (string)(cmbavPermissionaccesstype.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellFormGroupMarginBottom5", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavBoolenfilter_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavBoolenfilter_Internalname, context.GetMessage( "WWP_GAM_Inherited", ""), "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'" + sGXsfl_57_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavBoolenfilter, cmbavBoolenfilter_Internalname, StringUtil.RTrim( AV11BoolenFilter), 1, cmbavBoolenfilter_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavBoolenfilter.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "", true, 0, "HLP_GAMWWUserPermissions.htm");
            cmbavBoolenfilter.CurrentValue = StringUtil.RTrim( AV11BoolenFilter);
            AssignProp("", false, cmbavBoolenfilter_Internalname, "Values", (string)(cmbavBoolenfilter.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_23_8A2e( true) ;
         }
         else
         {
            wb_table1_23_8A2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV31UserId = (string)getParm(obj,0);
         AssignAttri("", false, "AV31UserId", AV31UserId);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV31UserId, "")), context));
         AV24pApplicationId = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV24pApplicationId", StringUtil.LTrimStr( (decimal)(AV24pApplicationId), 12, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vPAPPLICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV24pApplicationId), "ZZZZZZZZZZZ9"), context));
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
         PA8A2( ) ;
         WS8A2( ) ;
         WE8A2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202562017105570", true, true);
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
         context.AddJavascriptSource("gamwwuserpermissions.js", "?202562017105574", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_572( )
      {
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_57_idx;
         edtavName_Internalname = "vNAME_"+sGXsfl_57_idx;
         edtavDsc_Internalname = "vDSC_"+sGXsfl_57_idx;
         cmbavAccesstype_Internalname = "vACCESSTYPE_"+sGXsfl_57_idx;
         chkavInherited_Internalname = "vINHERITED_"+sGXsfl_57_idx;
         edtavBtndlt_Internalname = "vBTNDLT_"+sGXsfl_57_idx;
         cmbavOld_accesstype_Internalname = "vOLD_ACCESSTYPE_"+sGXsfl_57_idx;
         chkavOld_inherited_Internalname = "vOLD_INHERITED_"+sGXsfl_57_idx;
         edtavId_Internalname = "vID_"+sGXsfl_57_idx;
      }

      protected void SubsflControlProps_fel_572( )
      {
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_57_fel_idx;
         edtavName_Internalname = "vNAME_"+sGXsfl_57_fel_idx;
         edtavDsc_Internalname = "vDSC_"+sGXsfl_57_fel_idx;
         cmbavAccesstype_Internalname = "vACCESSTYPE_"+sGXsfl_57_fel_idx;
         chkavInherited_Internalname = "vINHERITED_"+sGXsfl_57_fel_idx;
         edtavBtndlt_Internalname = "vBTNDLT_"+sGXsfl_57_fel_idx;
         cmbavOld_accesstype_Internalname = "vOLD_ACCESSTYPE_"+sGXsfl_57_fel_idx;
         chkavOld_inherited_Internalname = "vOLD_INHERITED_"+sGXsfl_57_fel_idx;
         edtavId_Internalname = "vID_"+sGXsfl_57_fel_idx;
      }

      protected void sendrow_572( )
      {
         sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
         SubsflControlProps_572( ) ;
         WB8A0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_57_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_57_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_57_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'" + sGXsfl_57_idx + "',57)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV51Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"","'"+""+"'"+",false,"+"'"+"EVDELETE.CLICK."+sGXsfl_57_idx+"'",(string)"",(string)"",context.GetMessage( "GX_BtnDelete", ""),(string)"",(string)edtavDelete_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)57,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_57_idx + "',57)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavName_Internalname,StringUtil.RTrim( AV21Name),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)57,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionMedium",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'" + sGXsfl_57_idx + "',57)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDsc_Internalname,StringUtil.RTrim( AV13Dsc),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavDsc_Enabled,(short)0,(string)"text",(string)"",(short)570,(string)"px",(short)17,(string)"px",(short)254,(short)0,(short)0,(short)57,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionLong",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'" + sGXsfl_57_idx + "',57)\"";
            if ( ( cmbavAccesstype.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vACCESSTYPE_" + sGXsfl_57_idx;
               cmbavAccesstype.Name = GXCCtl;
               cmbavAccesstype.WebTags = "";
               cmbavAccesstype.addItem("A", context.GetMessage( "WWP_GAM_Allow", ""), 0);
               cmbavAccesstype.addItem("R", context.GetMessage( "WWP_GAM_Restricted", ""), 0);
               if ( cmbavAccesstype.ItemCount > 0 )
               {
                  AV7AccessType = cmbavAccesstype.getValidValue(AV7AccessType);
                  AssignAttri("", false, cmbavAccesstype_Internalname, AV7AccessType);
                  GxWebStd.gx_hidden_field( context, "gxhash_vACCESSTYPE"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, StringUtil.RTrim( context.localUtil.Format( AV7AccessType, "")), context));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavAccesstype,(string)cmbavAccesstype_Internalname,StringUtil.RTrim( AV7AccessType),(short)1,(string)cmbavAccesstype_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbavAccesstype.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"",(string)"",(bool)true,(short)0});
            cmbavAccesstype.CurrentValue = StringUtil.RTrim( AV7AccessType);
            AssignProp("", false, cmbavAccesstype_Internalname, "Values", (string)(cmbavAccesstype.ToJavascriptSource()), !bGXsfl_57_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'" + sGXsfl_57_idx + "',57)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "vINHERITED_" + sGXsfl_57_idx;
            chkavInherited.Name = GXCCtl;
            chkavInherited.WebTags = "";
            chkavInherited.Caption = "";
            AssignProp("", false, chkavInherited_Internalname, "TitleCaption", chkavInherited.Caption, !bGXsfl_57_Refreshing);
            chkavInherited.CheckedValue = "false";
            AV19Inherited = StringUtil.StrToBool( StringUtil.BoolToStr( AV19Inherited));
            AssignAttri("", false, chkavInherited_Internalname, AV19Inherited);
            GxWebStd.gx_hidden_field( context, "gxhash_vINHERITED"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, AV19Inherited, context));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavInherited_Internalname,StringUtil.BoolToStr( AV19Inherited),(string)"",(string)"",(short)-1,chkavInherited.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(62, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,62);\""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'" + sGXsfl_57_idx + "',57)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavBtndlt_Internalname,StringUtil.RTrim( AV12BtnDlt),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavBtndlt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavBtndlt_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)57,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbavOld_accesstype.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vOLD_ACCESSTYPE_" + sGXsfl_57_idx;
               cmbavOld_accesstype.Name = GXCCtl;
               cmbavOld_accesstype.WebTags = "";
               cmbavOld_accesstype.addItem("A", context.GetMessage( "GAM_Allow", ""), 0);
               cmbavOld_accesstype.addItem("D", context.GetMessage( "GAM_Deny", ""), 0);
               cmbavOld_accesstype.addItem("R", context.GetMessage( "GAM_Restricted", ""), 0);
               if ( cmbavOld_accesstype.ItemCount > 0 )
               {
                  AV22old_AccessType = cmbavOld_accesstype.getValidValue(AV22old_AccessType);
                  AssignAttri("", false, cmbavOld_accesstype_Internalname, AV22old_AccessType);
                  GxWebStd.gx_hidden_field( context, "gxhash_vOLD_ACCESSTYPE"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, StringUtil.RTrim( context.localUtil.Format( AV22old_AccessType, "")), context));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavOld_accesstype,(string)cmbavOld_accesstype_Internalname,StringUtil.RTrim( AV22old_AccessType),(short)1,(string)cmbavOld_accesstype_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)0,cmbavOld_accesstype.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"",(bool)true,(short)0});
            cmbavOld_accesstype.CurrentValue = StringUtil.RTrim( AV22old_AccessType);
            AssignProp("", false, cmbavOld_accesstype_Internalname, "Values", (string)(cmbavOld_accesstype.ToJavascriptSource()), !bGXsfl_57_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "vOLD_INHERITED_" + sGXsfl_57_idx;
            chkavOld_inherited.Name = GXCCtl;
            chkavOld_inherited.WebTags = "";
            chkavOld_inherited.Caption = "";
            AssignProp("", false, chkavOld_inherited_Internalname, "TitleCaption", chkavOld_inherited.Caption, !bGXsfl_57_Refreshing);
            chkavOld_inherited.CheckedValue = "false";
            AV23old_Inherited = StringUtil.StrToBool( StringUtil.BoolToStr( AV23old_Inherited));
            AssignAttri("", false, chkavOld_inherited_Internalname, AV23old_Inherited);
            GxWebStd.gx_hidden_field( context, "gxhash_vOLD_INHERITED"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, AV23old_Inherited, context));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavOld_inherited_Internalname,StringUtil.BoolToStr( AV23old_Inherited),(string)"",(string)"",(short)0,chkavOld_inherited.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavId_Internalname,StringUtil.RTrim( AV18Id),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavId_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)57,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMGUID",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes8A2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_57_idx = ((subGrid_Islastpage==1)&&(nGXsfl_57_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_57_idx+1);
            sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
            SubsflControlProps_572( ) ;
         }
         /* End function sendrow_572 */
      }

      protected void init_web_controls( )
      {
         cmbavApplicationid.Name = "vAPPLICATIONID";
         cmbavApplicationid.WebTags = "";
         if ( cmbavApplicationid.ItemCount > 0 )
         {
            AV10ApplicationId = (long)(Math.Round(NumberUtil.Val( cmbavApplicationid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV10ApplicationId), 12, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV10ApplicationId", StringUtil.LTrimStr( (decimal)(AV10ApplicationId), 12, 0));
         }
         cmbavPermissionaccesstype.Name = "vPERMISSIONACCESSTYPE";
         cmbavPermissionaccesstype.WebTags = "";
         cmbavPermissionaccesstype.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbavPermissionaccesstype.addItem("A", context.GetMessage( "GAM_Allow", ""), 0);
         cmbavPermissionaccesstype.addItem("D", context.GetMessage( "GAM_Deny", ""), 0);
         cmbavPermissionaccesstype.addItem("R", context.GetMessage( "GAM_Restricted", ""), 0);
         if ( cmbavPermissionaccesstype.ItemCount > 0 )
         {
            AV26PermissionAccessType = cmbavPermissionaccesstype.getValidValue(AV26PermissionAccessType);
            AssignAttri("", false, "AV26PermissionAccessType", AV26PermissionAccessType);
         }
         cmbavBoolenfilter.Name = "vBOOLENFILTER";
         cmbavBoolenfilter.WebTags = "";
         cmbavBoolenfilter.addItem("A", context.GetMessage( "GAM_All", ""), 0);
         cmbavBoolenfilter.addItem("T", context.GetMessage( "GAM_Yes", ""), 0);
         cmbavBoolenfilter.addItem("F", context.GetMessage( "GAM_No", ""), 0);
         if ( cmbavBoolenfilter.ItemCount > 0 )
         {
            AV11BoolenFilter = cmbavBoolenfilter.getValidValue(AV11BoolenFilter);
            AssignAttri("", false, "AV11BoolenFilter", AV11BoolenFilter);
         }
         GXCCtl = "vACCESSTYPE_" + sGXsfl_57_idx;
         cmbavAccesstype.Name = GXCCtl;
         cmbavAccesstype.WebTags = "";
         cmbavAccesstype.addItem("A", context.GetMessage( "WWP_GAM_Allow", ""), 0);
         cmbavAccesstype.addItem("R", context.GetMessage( "WWP_GAM_Restricted", ""), 0);
         if ( cmbavAccesstype.ItemCount > 0 )
         {
            AV7AccessType = cmbavAccesstype.getValidValue(AV7AccessType);
            AssignAttri("", false, cmbavAccesstype_Internalname, AV7AccessType);
            GxWebStd.gx_hidden_field( context, "gxhash_vACCESSTYPE"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, StringUtil.RTrim( context.localUtil.Format( AV7AccessType, "")), context));
         }
         GXCCtl = "vINHERITED_" + sGXsfl_57_idx;
         chkavInherited.Name = GXCCtl;
         chkavInherited.WebTags = "";
         chkavInherited.Caption = "";
         AssignProp("", false, chkavInherited_Internalname, "TitleCaption", chkavInherited.Caption, !bGXsfl_57_Refreshing);
         chkavInherited.CheckedValue = "false";
         AV19Inherited = StringUtil.StrToBool( StringUtil.BoolToStr( AV19Inherited));
         AssignAttri("", false, chkavInherited_Internalname, AV19Inherited);
         GxWebStd.gx_hidden_field( context, "gxhash_vINHERITED"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, AV19Inherited, context));
         GXCCtl = "vOLD_ACCESSTYPE_" + sGXsfl_57_idx;
         cmbavOld_accesstype.Name = GXCCtl;
         cmbavOld_accesstype.WebTags = "";
         cmbavOld_accesstype.addItem("A", context.GetMessage( "GAM_Allow", ""), 0);
         cmbavOld_accesstype.addItem("D", context.GetMessage( "GAM_Deny", ""), 0);
         cmbavOld_accesstype.addItem("R", context.GetMessage( "GAM_Restricted", ""), 0);
         if ( cmbavOld_accesstype.ItemCount > 0 )
         {
            AV22old_AccessType = cmbavOld_accesstype.getValidValue(AV22old_AccessType);
            AssignAttri("", false, cmbavOld_accesstype_Internalname, AV22old_AccessType);
            GxWebStd.gx_hidden_field( context, "gxhash_vOLD_ACCESSTYPE"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, StringUtil.RTrim( context.localUtil.Format( AV22old_AccessType, "")), context));
         }
         GXCCtl = "vOLD_INHERITED_" + sGXsfl_57_idx;
         chkavOld_inherited.Name = GXCCtl;
         chkavOld_inherited.WebTags = "";
         chkavOld_inherited.Caption = "";
         AssignProp("", false, chkavOld_inherited_Internalname, "TitleCaption", chkavOld_inherited.Caption, !bGXsfl_57_Refreshing);
         chkavOld_inherited.CheckedValue = "false";
         AV23old_Inherited = StringUtil.StrToBool( StringUtil.BoolToStr( AV23old_Inherited));
         AssignAttri("", false, chkavOld_inherited_Internalname, AV23old_Inherited);
         GxWebStd.gx_hidden_field( context, "gxhash_vOLD_INHERITED"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, AV23old_Inherited, context));
         /* End function init_web_controls */
      }

      protected void StartGridControl57( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"57\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "WWP_GAM_PermissionName", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(570), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "WWP_GAM_Description", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "WWP_GAM_AccessType", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "WWP_GAM_Inherited", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "WWP_GAM_Revoke", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "old_Access Type", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "old_Inherited", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV51Delete)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV21Name)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavName_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV13Dsc)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDsc_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV7AccessType)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavAccesstype.Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV19Inherited)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavInherited.Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV12BtnDlt)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBtndlt_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV22old_AccessType)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavOld_accesstype.Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV23old_Inherited)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavOld_inherited.Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV18Id)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavId_Enabled), 5, 0, ".", "")));
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
         bttBtnback_Internalname = "BTNBACK";
         bttBtninsert_Internalname = "BTNINSERT";
         bttBtnsave_Internalname = "BTNSAVE";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         cmbavApplicationid_Internalname = "vAPPLICATIONID";
         edtavFilname_Internalname = "vFILNAME";
         cmbavPermissionaccesstype_Internalname = "vPERMISSIONACCESSTYPE";
         cmbavBoolenfilter_Internalname = "vBOOLENFILTER";
         divTablefilters_Internalname = "TABLEFILTERS";
         tblTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheader_Internalname = "TABLEHEADER";
         edtavDelete_Internalname = "vDELETE";
         edtavName_Internalname = "vNAME";
         edtavDsc_Internalname = "vDSC";
         cmbavAccesstype_Internalname = "vACCESSTYPE";
         chkavInherited_Internalname = "vINHERITED";
         edtavBtndlt_Internalname = "vBTNDLT";
         cmbavOld_accesstype_Internalname = "vOLD_ACCESSTYPE";
         chkavOld_inherited_Internalname = "vOLD_INHERITED";
         edtavId_Internalname = "vID";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
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
         edtavId_Jsonclick = "";
         edtavId_Enabled = 1;
         chkavOld_inherited.Caption = "";
         chkavOld_inherited.Enabled = 1;
         cmbavOld_accesstype_Jsonclick = "";
         cmbavOld_accesstype.Enabled = 1;
         edtavBtndlt_Jsonclick = "";
         edtavBtndlt_Enabled = 1;
         chkavInherited.Caption = "";
         chkavInherited.Enabled = 1;
         cmbavAccesstype_Jsonclick = "";
         cmbavAccesstype.Enabled = 1;
         edtavDsc_Jsonclick = "";
         edtavDsc_Enabled = 1;
         edtavName_Jsonclick = "";
         edtavName_Enabled = 1;
         edtavDelete_Jsonclick = "";
         edtavDelete_Enabled = 1;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         cmbavBoolenfilter_Jsonclick = "";
         cmbavBoolenfilter.Enabled = 1;
         cmbavPermissionaccesstype_Jsonclick = "";
         cmbavPermissionaccesstype.Enabled = 1;
         edtavFilname_Jsonclick = "";
         edtavFilname_Enabled = 1;
         cmbavApplicationid_Jsonclick = "";
         cmbavApplicationid.Enabled = 1;
         bttBtninsert_Visible = 1;
         bttBtnback_Visible = 1;
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
         Form.Caption = context.GetMessage( "WWP_GAM_UserPermissions", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV47ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV58Pgmname","fld":"vPGMNAME","hsh":true},{"av":"cmbavApplicationid"},{"av":"AV10ApplicationId","fld":"vAPPLICATIONID","pic":"ZZZZZZZZZZZ9"},{"av":"AV16FilName","fld":"vFILNAME"},{"av":"cmbavPermissionaccesstype"},{"av":"AV26PermissionAccessType","fld":"vPERMISSIONACCESSTYPE"},{"av":"cmbavBoolenfilter"},{"av":"AV11BoolenFilter","fld":"vBOOLENFILTER"},{"av":"AV31UserId","fld":"vUSERID","hsh":true},{"av":"AV30SearchFilter","fld":"vSEARCHFILTER","hsh":true},{"av":"AV52IsAuthorized_Back","fld":"vISAUTHORIZED_BACK","hsh":true},{"av":"AV53IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV24pApplicationId","fld":"vPAPPLICATIONID","pic":"ZZZZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV47ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV49GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV55GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV52IsAuthorized_Back","fld":"vISAUTHORIZED_BACK","hsh":true},{"ctrl":"BTNBACK","prop":"Visible"},{"av":"AV53IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV45ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV42GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E128A2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV47ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV58Pgmname","fld":"vPGMNAME","hsh":true},{"av":"cmbavApplicationid"},{"av":"AV10ApplicationId","fld":"vAPPLICATIONID","pic":"ZZZZZZZZZZZ9"},{"av":"AV16FilName","fld":"vFILNAME"},{"av":"cmbavPermissionaccesstype"},{"av":"AV26PermissionAccessType","fld":"vPERMISSIONACCESSTYPE"},{"av":"cmbavBoolenfilter"},{"av":"AV11BoolenFilter","fld":"vBOOLENFILTER"},{"av":"AV31UserId","fld":"vUSERID","hsh":true},{"av":"AV30SearchFilter","fld":"vSEARCHFILTER","hsh":true},{"av":"AV52IsAuthorized_Back","fld":"vISAUTHORIZED_BACK","hsh":true},{"av":"AV53IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV24pApplicationId","fld":"vPAPPLICATIONID","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E138A2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV47ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV58Pgmname","fld":"vPGMNAME","hsh":true},{"av":"cmbavApplicationid"},{"av":"AV10ApplicationId","fld":"vAPPLICATIONID","pic":"ZZZZZZZZZZZ9"},{"av":"AV16FilName","fld":"vFILNAME"},{"av":"cmbavPermissionaccesstype"},{"av":"AV26PermissionAccessType","fld":"vPERMISSIONACCESSTYPE"},{"av":"cmbavBoolenfilter"},{"av":"AV11BoolenFilter","fld":"vBOOLENFILTER"},{"av":"AV31UserId","fld":"vUSERID","hsh":true},{"av":"AV30SearchFilter","fld":"vSEARCHFILTER","hsh":true},{"av":"AV52IsAuthorized_Back","fld":"vISAUTHORIZED_BACK","hsh":true},{"av":"AV53IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV24pApplicationId","fld":"vPAPPLICATIONID","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E198A2","iparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV31UserId","fld":"vUSERID","hsh":true},{"av":"cmbavApplicationid"},{"av":"AV10ApplicationId","fld":"vAPPLICATIONID","pic":"ZZZZZZZZZZZ9"},{"av":"AV16FilName","fld":"vFILNAME"},{"av":"AV30SearchFilter","fld":"vSEARCHFILTER","hsh":true},{"av":"cmbavPermissionaccesstype"},{"av":"AV26PermissionAccessType","fld":"vPERMISSIONACCESSTYPE"},{"av":"cmbavBoolenfilter"},{"av":"AV11BoolenFilter","fld":"vBOOLENFILTER"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV50GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV12BtnDlt","fld":"vBTNDLT"},{"av":"AV18Id","fld":"vID","hsh":true},{"av":"AV21Name","fld":"vNAME"},{"av":"AV13Dsc","fld":"vDSC"},{"av":"cmbavAccesstype"},{"av":"AV7AccessType","fld":"vACCESSTYPE","hsh":true},{"av":"AV19Inherited","fld":"vINHERITED","hsh":true},{"av":"cmbavOld_accesstype"},{"av":"AV22old_AccessType","fld":"vOLD_ACCESSTYPE","hsh":true},{"av":"AV23old_Inherited","fld":"vOLD_INHERITED","hsh":true},{"av":"AV51Delete","fld":"vDELETE"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E118A2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV47ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV58Pgmname","fld":"vPGMNAME","hsh":true},{"av":"cmbavApplicationid"},{"av":"AV10ApplicationId","fld":"vAPPLICATIONID","pic":"ZZZZZZZZZZZ9"},{"av":"AV16FilName","fld":"vFILNAME"},{"av":"cmbavPermissionaccesstype"},{"av":"AV26PermissionAccessType","fld":"vPERMISSIONACCESSTYPE"},{"av":"cmbavBoolenfilter"},{"av":"AV11BoolenFilter","fld":"vBOOLENFILTER"},{"av":"AV31UserId","fld":"vUSERID","hsh":true},{"av":"AV30SearchFilter","fld":"vSEARCHFILTER","hsh":true},{"av":"AV52IsAuthorized_Back","fld":"vISAUTHORIZED_BACK","hsh":true},{"av":"AV53IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV24pApplicationId","fld":"vPAPPLICATIONID","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV42GridState","fld":"vGRIDSTATE"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV47ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV42GridState","fld":"vGRIDSTATE"},{"av":"cmbavApplicationid"},{"av":"AV10ApplicationId","fld":"vAPPLICATIONID","pic":"ZZZZZZZZZZZ9"},{"av":"AV16FilName","fld":"vFILNAME"},{"av":"cmbavPermissionaccesstype"},{"av":"AV26PermissionAccessType","fld":"vPERMISSIONACCESSTYPE"},{"av":"cmbavBoolenfilter"},{"av":"AV11BoolenFilter","fld":"vBOOLENFILTER"},{"av":"AV49GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV55GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV52IsAuthorized_Back","fld":"vISAUTHORIZED_BACK","hsh":true},{"ctrl":"BTNBACK","prop":"Visible"},{"av":"AV53IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV45ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("'DOBACK'","""{"handler":"E148A2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV47ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV58Pgmname","fld":"vPGMNAME","hsh":true},{"av":"cmbavApplicationid"},{"av":"AV10ApplicationId","fld":"vAPPLICATIONID","pic":"ZZZZZZZZZZZ9"},{"av":"AV16FilName","fld":"vFILNAME"},{"av":"cmbavPermissionaccesstype"},{"av":"AV26PermissionAccessType","fld":"vPERMISSIONACCESSTYPE"},{"av":"cmbavBoolenfilter"},{"av":"AV11BoolenFilter","fld":"vBOOLENFILTER"},{"av":"AV31UserId","fld":"vUSERID","hsh":true},{"av":"AV30SearchFilter","fld":"vSEARCHFILTER","hsh":true},{"av":"AV52IsAuthorized_Back","fld":"vISAUTHORIZED_BACK","hsh":true},{"av":"AV53IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV24pApplicationId","fld":"vPAPPLICATIONID","pic":"ZZZZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("'DOBACK'",""","oparms":[{"av":"AV47ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV49GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV55GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV52IsAuthorized_Back","fld":"vISAUTHORIZED_BACK","hsh":true},{"ctrl":"BTNBACK","prop":"Visible"},{"av":"AV53IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV45ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV42GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E158A2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV47ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV58Pgmname","fld":"vPGMNAME","hsh":true},{"av":"cmbavApplicationid"},{"av":"AV10ApplicationId","fld":"vAPPLICATIONID","pic":"ZZZZZZZZZZZ9"},{"av":"AV16FilName","fld":"vFILNAME"},{"av":"cmbavPermissionaccesstype"},{"av":"AV26PermissionAccessType","fld":"vPERMISSIONACCESSTYPE"},{"av":"cmbavBoolenfilter"},{"av":"AV11BoolenFilter","fld":"vBOOLENFILTER"},{"av":"AV31UserId","fld":"vUSERID","hsh":true},{"av":"AV30SearchFilter","fld":"vSEARCHFILTER","hsh":true},{"av":"AV52IsAuthorized_Back","fld":"vISAUTHORIZED_BACK","hsh":true},{"av":"AV53IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV24pApplicationId","fld":"vPAPPLICATIONID","pic":"ZZZZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("'DOINSERT'",""","oparms":[{"av":"AV47ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV49GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV55GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV52IsAuthorized_Back","fld":"vISAUTHORIZED_BACK","hsh":true},{"ctrl":"BTNBACK","prop":"Visible"},{"av":"AV53IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV45ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV42GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("'DOSAVE'","""{"handler":"E168A2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV47ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV58Pgmname","fld":"vPGMNAME","hsh":true},{"av":"cmbavApplicationid"},{"av":"AV10ApplicationId","fld":"vAPPLICATIONID","pic":"ZZZZZZZZZZZ9"},{"av":"AV16FilName","fld":"vFILNAME"},{"av":"cmbavPermissionaccesstype"},{"av":"AV26PermissionAccessType","fld":"vPERMISSIONACCESSTYPE"},{"av":"cmbavBoolenfilter"},{"av":"AV11BoolenFilter","fld":"vBOOLENFILTER"},{"av":"AV31UserId","fld":"vUSERID","hsh":true},{"av":"AV30SearchFilter","fld":"vSEARCHFILTER","hsh":true},{"av":"AV52IsAuthorized_Back","fld":"vISAUTHORIZED_BACK","hsh":true},{"av":"AV53IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV24pApplicationId","fld":"vPAPPLICATIONID","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"AV7AccessType","fld":"vACCESSTYPE","grid":57,"hsh":true},{"av":"nRC_GXsfl_57","ctrl":"GRID","grid":57,"prop":"GridRC","grid":57},{"av":"AV22old_AccessType","fld":"vOLD_ACCESSTYPE","grid":57,"hsh":true},{"av":"AV19Inherited","fld":"vINHERITED","grid":57,"hsh":true},{"av":"AV23old_Inherited","fld":"vOLD_INHERITED","grid":57,"hsh":true},{"av":"AV18Id","fld":"vID","grid":57,"hsh":true},{"av":"AV20isOK","fld":"vISOK"}]""");
         setEventMetadata("'DOSAVE'",""","oparms":[{"av":"AV20isOK","fld":"vISOK"},{"av":"AV47ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV49GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV55GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV52IsAuthorized_Back","fld":"vISAUTHORIZED_BACK","hsh":true},{"ctrl":"BTNBACK","prop":"Visible"},{"av":"AV53IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV45ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV42GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("VDELETE.CLICK","""{"handler":"E208A2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV47ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV58Pgmname","fld":"vPGMNAME","hsh":true},{"av":"cmbavApplicationid"},{"av":"AV10ApplicationId","fld":"vAPPLICATIONID","pic":"ZZZZZZZZZZZ9"},{"av":"AV16FilName","fld":"vFILNAME"},{"av":"cmbavPermissionaccesstype"},{"av":"AV26PermissionAccessType","fld":"vPERMISSIONACCESSTYPE"},{"av":"cmbavBoolenfilter"},{"av":"AV11BoolenFilter","fld":"vBOOLENFILTER"},{"av":"AV31UserId","fld":"vUSERID","hsh":true},{"av":"AV30SearchFilter","fld":"vSEARCHFILTER","hsh":true},{"av":"AV52IsAuthorized_Back","fld":"vISAUTHORIZED_BACK","hsh":true},{"av":"AV53IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV24pApplicationId","fld":"vPAPPLICATIONID","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"AV18Id","fld":"vID","hsh":true}]""");
         setEventMetadata("VDELETE.CLICK",""","oparms":[{"av":"AV20isOK","fld":"vISOK"},{"av":"AV47ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV49GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV55GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV52IsAuthorized_Back","fld":"vISAUTHORIZED_BACK","hsh":true},{"ctrl":"BTNBACK","prop":"Visible"},{"av":"AV53IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV45ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV42GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("VALIDV_PERMISSIONACCESSTYPE","""{"handler":"Validv_Permissionaccesstype","iparms":[]}""");
         setEventMetadata("VALIDV_BOOLENFILTER","""{"handler":"Validv_Boolenfilter","iparms":[]}""");
         setEventMetadata("VALIDV_ACCESSTYPE","""{"handler":"Validv_Accesstype","iparms":[]}""");
         setEventMetadata("VALIDV_OLD_ACCESSTYPE","""{"handler":"Validv_Old_accesstype","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Id","iparms":[]}""");
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
         wcpOAV31UserId = "";
         Gridpaginationbar_Selectedpage = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV58Pgmname = "";
         AV16FilName = "";
         AV26PermissionAccessType = "";
         AV11BoolenFilter = "";
         AV30SearchFilter = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV45ManageFiltersData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV55GridAppliedFilters = "";
         AV42GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnback_Jsonclick = "";
         bttBtninsert_Jsonclick = "";
         bttBtnsave_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV51Delete = "";
         AV21Name = "";
         AV13Dsc = "";
         AV7AccessType = "";
         AV12BtnDlt = "";
         AV22old_AccessType = "";
         AV18Id = "";
         GXDecQS = "";
         AV56GXV1 = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplication>( context, "GeneXus.Programs.genexussecurity.SdtGAMApplication", "GeneXus.Programs");
         AV9ApplicationFilter = new GeneXus.Programs.genexussecurity.SdtGAMApplicationFilter(context);
         AV15Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV8Application = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV32GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV35UserName = "";
         AV39HTTPRequest = new GxHttpRequest( context);
         AV37WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV33GAMUserName = "";
         AV34UserPermissionFilter = new GeneXus.Programs.genexussecurity.SdtGAMPermissionFilter(context);
         AV54Permissions = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMPermission>( context, "GeneXus.Programs.genexussecurity.SdtGAMPermission", "GeneXus.Programs");
         AV25Permission = new GeneXus.Programs.genexussecurity.SdtGAMPermission(context);
         GridRow = new GXWebRow();
         AV46ManageFiltersXml = "";
         GXt_char1 = "";
         AV27PermissionUpd = new GeneXus.Programs.genexussecurity.SdtGAMPermission(context);
         AV14Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV44Session = context.GetSession();
         AV43GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.gamwwuserpermissions__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.gamwwuserpermissions__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gamwwuserpermissions__default(),
            new Object[][] {
            }
         );
         AV58Pgmname = "GAMWWUserPermissions";
         /* GeneXus formulas. */
         AV58Pgmname = "GAMWWUserPermissions";
         edtavDelete_Enabled = 0;
         edtavName_Enabled = 0;
         edtavDsc_Enabled = 0;
         cmbavAccesstype.Enabled = 0;
         chkavInherited.Enabled = 0;
         edtavBtndlt_Enabled = 0;
         cmbavOld_accesstype.Enabled = 0;
         chkavOld_inherited.Enabled = 0;
         edtavId_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV47ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_57 ;
      private int subGrid_Recordcount ;
      private int nGXsfl_57_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtnback_Visible ;
      private int bttBtninsert_Visible ;
      private int subGrid_Islastpage ;
      private int edtavDelete_Enabled ;
      private int edtavName_Enabled ;
      private int edtavDsc_Enabled ;
      private int edtavBtndlt_Enabled ;
      private int edtavId_Enabled ;
      private int GRID_nGridOutOfScope ;
      private int AV57GXV2 ;
      private int AV48PageToGo ;
      private int AV59GXV3 ;
      private int nGXsfl_57_fel_idx=1 ;
      private int AV61GXV4 ;
      private int AV62GXV5 ;
      private int AV63GXV6 ;
      private int AV64GXV7 ;
      private int edtavFilname_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long AV24pApplicationId ;
      private long wcpOAV24pApplicationId ;
      private long GRID_nFirstRecordOnPage ;
      private long AV10ApplicationId ;
      private long AV49GridCurrentPage ;
      private long AV50GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long AV6GridPageSize ;
      private long AV5GridRecordCount ;
      private string AV31UserId ;
      private string wcpOAV31UserId ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_57_idx="0001" ;
      private string AV58Pgmname ;
      private string AV26PermissionAccessType ;
      private string AV11BoolenFilter ;
      private string AV30SearchFilter ;
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
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnback_Internalname ;
      private string bttBtnback_Jsonclick ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string bttBtnsave_Internalname ;
      private string bttBtnsave_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV51Delete ;
      private string edtavDelete_Internalname ;
      private string AV21Name ;
      private string edtavName_Internalname ;
      private string AV13Dsc ;
      private string edtavDsc_Internalname ;
      private string cmbavAccesstype_Internalname ;
      private string AV7AccessType ;
      private string chkavInherited_Internalname ;
      private string AV12BtnDlt ;
      private string edtavBtndlt_Internalname ;
      private string cmbavOld_accesstype_Internalname ;
      private string AV22old_AccessType ;
      private string chkavOld_inherited_Internalname ;
      private string AV18Id ;
      private string edtavId_Internalname ;
      private string GXDecQS ;
      private string cmbavApplicationid_Internalname ;
      private string cmbavPermissionaccesstype_Internalname ;
      private string cmbavBoolenfilter_Internalname ;
      private string edtavFilname_Internalname ;
      private string GXt_char1 ;
      private string sGXsfl_57_fel_idx="0001" ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string divTablefilters_Internalname ;
      private string cmbavApplicationid_Jsonclick ;
      private string edtavFilname_Jsonclick ;
      private string cmbavPermissionaccesstype_Jsonclick ;
      private string cmbavBoolenfilter_Jsonclick ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavDelete_Jsonclick ;
      private string edtavName_Jsonclick ;
      private string edtavDsc_Jsonclick ;
      private string GXCCtl ;
      private string cmbavAccesstype_Jsonclick ;
      private string edtavBtndlt_Jsonclick ;
      private string cmbavOld_accesstype_Jsonclick ;
      private string edtavId_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV52IsAuthorized_Back ;
      private bool AV53IsAuthorized_Insert ;
      private bool AV20isOK ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV19Inherited ;
      private bool AV23old_Inherited ;
      private bool bGXsfl_57_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool GXt_boolean2 ;
      private string AV46ManageFiltersXml ;
      private string AV16FilName ;
      private string AV55GridAppliedFilters ;
      private string AV35UserName ;
      private string AV33GAMUserName ;
      private IGxSession AV44Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucDdo_managefilters ;
      private GxHttpRequest AV39HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavApplicationid ;
      private GXCombobox cmbavPermissionaccesstype ;
      private GXCombobox cmbavBoolenfilter ;
      private GXCombobox cmbavAccesstype ;
      private GXCheckbox chkavInherited ;
      private GXCombobox cmbavOld_accesstype ;
      private GXCheckbox chkavOld_inherited ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV45ManageFiltersData ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV42GridState ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplication> AV56GXV1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationFilter AV9ApplicationFilter ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV15Errors ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV8Application ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV32GAMUser ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV37WWPContext ;
      private GeneXus.Programs.genexussecurity.SdtGAMPermissionFilter AV34UserPermissionFilter ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMPermission> AV54Permissions ;
      private GeneXus.Programs.genexussecurity.SdtGAMPermission AV25Permission ;
      private GeneXus.Programs.genexussecurity.SdtGAMPermission AV27PermissionUpd ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV14Error ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV43GridStateFilterValue ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class gamwwuserpermissions__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class gamwwuserpermissions__gam : DataStoreHelperBase, IDataStoreHelper
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

public class gamwwuserpermissions__default : DataStoreHelperBase, IDataStoreHelper
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
