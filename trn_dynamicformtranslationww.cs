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
   public class trn_dynamicformtranslationww : GXDataArea
   {
      public trn_dynamicformtranslationww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_dynamicformtranslationww( IGxContext context )
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
         AV16FilterFullText = GetPar( "FilterFullText");
         AV24ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV19ColumnsSelector);
         AV52Pgmname = GetPar( "Pgmname");
         AV25TFDynamicFormTranslationWWpFormId = (int)(Math.Round(NumberUtil.Val( GetPar( "TFDynamicFormTranslationWWpFormId"), "."), 18, MidpointRounding.ToEven));
         AV26TFDynamicFormTranslationWWpFormId_To = (int)(Math.Round(NumberUtil.Val( GetPar( "TFDynamicFormTranslationWWpFormId_To"), "."), 18, MidpointRounding.ToEven));
         AV27TFDynamicFormTranslationWWPFormVersionNumber = (int)(Math.Round(NumberUtil.Val( GetPar( "TFDynamicFormTranslationWWPFormVersionNumber"), "."), 18, MidpointRounding.ToEven));
         AV28TFDynamicFormTranslationWWPFormVersionNumber_To = (int)(Math.Round(NumberUtil.Val( GetPar( "TFDynamicFormTranslationWWPFormVersionNumber_To"), "."), 18, MidpointRounding.ToEven));
         AV29TFDynamicFormTranslationWWPFormElementId = (int)(Math.Round(NumberUtil.Val( GetPar( "TFDynamicFormTranslationWWPFormElementId"), "."), 18, MidpointRounding.ToEven));
         AV30TFDynamicFormTranslationWWPFormElementId_To = (int)(Math.Round(NumberUtil.Val( GetPar( "TFDynamicFormTranslationWWPFormElementId_To"), "."), 18, MidpointRounding.ToEven));
         AV31TFDynamicFormTranslationTrnName = GetPar( "TFDynamicFormTranslationTrnName");
         AV32TFDynamicFormTranslationTrnName_Sel = GetPar( "TFDynamicFormTranslationTrnName_Sel");
         AV33TFDynamicFormTranslationAttributeName = GetPar( "TFDynamicFormTranslationAttributeName");
         AV34TFDynamicFormTranslationAttributeName_Sel = GetPar( "TFDynamicFormTranslationAttributeName_Sel");
         AV35TFDynamicFormTranslationEnglish = GetPar( "TFDynamicFormTranslationEnglish");
         AV36TFDynamicFormTranslationEnglish_Sel = GetPar( "TFDynamicFormTranslationEnglish_Sel");
         AV37TFDynamicFormTranslationDutch = GetPar( "TFDynamicFormTranslationDutch");
         AV38TFDynamicFormTranslationDutch_Sel = GetPar( "TFDynamicFormTranslationDutch_Sel");
         AV48IsAuthorized_Display = StringUtil.StrToBool( GetPar( "IsAuthorized_Display"));
         AV49IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV50IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV46IsAuthorized_DynamicFormTranslationWWpFormId = StringUtil.StrToBool( GetPar( "IsAuthorized_DynamicFormTranslationWWpFormId"));
         AV51IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV52Pgmname, AV25TFDynamicFormTranslationWWpFormId, AV26TFDynamicFormTranslationWWpFormId_To, AV27TFDynamicFormTranslationWWPFormVersionNumber, AV28TFDynamicFormTranslationWWPFormVersionNumber_To, AV29TFDynamicFormTranslationWWPFormElementId, AV30TFDynamicFormTranslationWWPFormElementId_To, AV31TFDynamicFormTranslationTrnName, AV32TFDynamicFormTranslationTrnName_Sel, AV33TFDynamicFormTranslationAttributeName, AV34TFDynamicFormTranslationAttributeName_Sel, AV35TFDynamicFormTranslationEnglish, AV36TFDynamicFormTranslationEnglish_Sel, AV37TFDynamicFormTranslationDutch, AV38TFDynamicFormTranslationDutch_Sel, AV48IsAuthorized_Display, AV49IsAuthorized_Update, AV50IsAuthorized_Delete, AV46IsAuthorized_DynamicFormTranslationWWpFormId, AV51IsAuthorized_Insert) ;
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
            return "trn_dynamicformtranslationww_Execute" ;
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
         PABD2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTBD2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_dynamicformtranslationww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV52Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV52Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV48IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV48IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV49IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV49IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV50IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV50IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DYNAMICFORMTRANSLATIONWWPFORMID", AV46IsAuthorized_DynamicFormTranslationWWpFormId);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DYNAMICFORMTRANSLATIONWWPFORMID", GetSecureSignedToken( "", AV46IsAuthorized_DynamicFormTranslationWWpFormId, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV51IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV51IsAuthorized_Insert, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV14OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV16FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_39", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_39), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV22ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV22ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV45GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV39DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV39DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV19ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV19ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV52Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV52Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFDYNAMICFORMTRANSLATIONWWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25TFDynamicFormTranslationWWpFormId), 6, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFDYNAMICFORMTRANSLATIONWWPFORMID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26TFDynamicFormTranslationWWpFormId_To), 6, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFDYNAMICFORMTRANSLATIONWWPFORMVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27TFDynamicFormTranslationWWPFormVersionNumber), 6, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFDYNAMICFORMTRANSLATIONWWPFORMVERSIONNUMBER_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28TFDynamicFormTranslationWWPFormVersionNumber_To), 6, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFDYNAMICFORMTRANSLATIONWWPFORMELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29TFDynamicFormTranslationWWPFormElementId), 6, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFDYNAMICFORMTRANSLATIONWWPFORMELEMENTID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30TFDynamicFormTranslationWWPFormElementId_To), 6, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFDYNAMICFORMTRANSLATIONTRNNAME", AV31TFDynamicFormTranslationTrnName);
         GxWebStd.gx_hidden_field( context, "vTFDYNAMICFORMTRANSLATIONTRNNAME_SEL", AV32TFDynamicFormTranslationTrnName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFDYNAMICFORMTRANSLATIONATTRIBUTENAME", AV33TFDynamicFormTranslationAttributeName);
         GxWebStd.gx_hidden_field( context, "vTFDYNAMICFORMTRANSLATIONATTRIBUTENAME_SEL", AV34TFDynamicFormTranslationAttributeName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFDYNAMICFORMTRANSLATIONENGLISH", AV35TFDynamicFormTranslationEnglish);
         GxWebStd.gx_hidden_field( context, "vTFDYNAMICFORMTRANSLATIONENGLISH_SEL", AV36TFDynamicFormTranslationEnglish_Sel);
         GxWebStd.gx_hidden_field( context, "vTFDYNAMICFORMTRANSLATIONDUTCH", AV37TFDynamicFormTranslationDutch);
         GxWebStd.gx_hidden_field( context, "vTFDYNAMICFORMTRANSLATIONDUTCH_SEL", AV38TFDynamicFormTranslationDutch_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV48IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV48IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV49IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV49IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV50IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV50IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DYNAMICFORMTRANSLATIONWWPFORMID", AV46IsAuthorized_DynamicFormTranslationWWpFormId);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DYNAMICFORMTRANSLATIONWWPFORMID", GetSecureSignedToken( "", AV46IsAuthorized_DynamicFormTranslationWWpFormId, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV51IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV51IsAuthorized_Insert, context));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
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
            WEBD2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTBD2( ) ;
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
         return formatLink("trn_dynamicformtranslationww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_DynamicFormTranslationWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Trn_Dynamic Form Translation", "") ;
      }

      protected void WBBD0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_DynamicFormTranslationWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_DynamicFormTranslationWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, context.GetMessage( "WWP_Subscriptions_Tooltip", ""), "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_DynamicFormTranslationWW.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV22ManageFiltersData);
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV16FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV16FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWPFullTextFilter", "start", true, "", "HLP_Trn_DynamicFormTranslationWW.htm");
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV43GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV44GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV45GridAppliedFilters);
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
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV39DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV39DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV19ColumnsSelector);
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
               GxWebStd.gx_hidden_field( context, "W0060"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0060"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_39_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0060"+"");
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

      protected void STARTBD2( )
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
         Form.Meta.addItem("description", context.GetMessage( " Trn_Dynamic Form Translation", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPBD0( ) ;
      }

      protected void WSBD2( )
      {
         STARTBD2( ) ;
         EVTBD2( ) ;
      }

      protected void EVTBD2( )
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
                              E11BD2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E12BD2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E13BD2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                              E14BD2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E15BD2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E16BD2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E17BD2 ();
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
                              A585DynamicFormTranslationId = StringUtil.StrToGuid( cgiGet( edtDynamicFormTranslationId_Internalname));
                              A586DynamicFormTranslationWWpFormI = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtDynamicFormTranslationWWpFormI_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A587DynamicFormTranslationWWPFormV = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtDynamicFormTranslationWWPFormV_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A588DynamicFormTranslationWWPFormE = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtDynamicFormTranslationWWPFormE_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A589DynamicFormTranslationTrnName = cgiGet( edtDynamicFormTranslationTrnName_Internalname);
                              A590DynamicFormTranslationAttribut = cgiGet( edtDynamicFormTranslationAttribut_Internalname);
                              A591DynamicFormTranslationEnglish = cgiGet( edtDynamicFormTranslationEnglish_Internalname);
                              A592DynamicFormTranslationDutch = cgiGet( edtDynamicFormTranslationDutch_Internalname);
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
                                    E18BD2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E19BD2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E20BD2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VACTIONGROUP.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E21BD2 ();
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
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV16FilterFullText) != 0 )
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
                        if ( nCmpId == 60 )
                        {
                           OldWwpaux_wc = cgiGet( "W0060");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0060", "", sEvt);
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

      protected void WEBD2( )
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

      protected void PABD2( )
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
                                       string AV16FilterFullText ,
                                       short AV24ManageFiltersExecutionStep ,
                                       WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV19ColumnsSelector ,
                                       string AV52Pgmname ,
                                       int AV25TFDynamicFormTranslationWWpFormId ,
                                       int AV26TFDynamicFormTranslationWWpFormId_To ,
                                       int AV27TFDynamicFormTranslationWWPFormVersionNumber ,
                                       int AV28TFDynamicFormTranslationWWPFormVersionNumber_To ,
                                       int AV29TFDynamicFormTranslationWWPFormElementId ,
                                       int AV30TFDynamicFormTranslationWWPFormElementId_To ,
                                       string AV31TFDynamicFormTranslationTrnName ,
                                       string AV32TFDynamicFormTranslationTrnName_Sel ,
                                       string AV33TFDynamicFormTranslationAttributeName ,
                                       string AV34TFDynamicFormTranslationAttributeName_Sel ,
                                       string AV35TFDynamicFormTranslationEnglish ,
                                       string AV36TFDynamicFormTranslationEnglish_Sel ,
                                       string AV37TFDynamicFormTranslationDutch ,
                                       string AV38TFDynamicFormTranslationDutch_Sel ,
                                       bool AV48IsAuthorized_Display ,
                                       bool AV49IsAuthorized_Update ,
                                       bool AV50IsAuthorized_Delete ,
                                       bool AV46IsAuthorized_DynamicFormTranslationWWpFormId ,
                                       bool AV51IsAuthorized_Insert )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFBD2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_DYNAMICFORMTRANSLATIONID", GetSecureSignedToken( "", A585DynamicFormTranslationId, context));
         GxWebStd.gx_hidden_field( context, "DYNAMICFORMTRANSLATIONID", A585DynamicFormTranslationId.ToString());
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
         RFBD2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV52Pgmname = "Trn_DynamicFormTranslationWW";
      }

      protected void RFBD2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 39;
         /* Execute user event: Refresh */
         E19BD2 ();
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
                                                 AV53Trn_dynamicformtranslationwwds_1_filterfulltext ,
                                                 AV54Trn_dynamicformtranslationwwds_2_tfdynamicformtranslationwwpformid ,
                                                 AV55Trn_dynamicformtranslationwwds_3_tfdynamicformtranslationwwpformid_to ,
                                                 AV56Trn_dynamicformtranslationwwds_4_tfdynamicformtranslationwwpformversionnumber ,
                                                 AV57Trn_dynamicformtranslationwwds_5_tfdynamicformtranslationwwpformversionnumber_to ,
                                                 AV58Trn_dynamicformtranslationwwds_6_tfdynamicformtranslationwwpformelementid ,
                                                 AV59Trn_dynamicformtranslationwwds_7_tfdynamicformtranslationwwpformelementid_to ,
                                                 AV61Trn_dynamicformtranslationwwds_9_tfdynamicformtranslationtrnname_sel ,
                                                 AV60Trn_dynamicformtranslationwwds_8_tfdynamicformtranslationtrnname ,
                                                 AV63Trn_dynamicformtranslationwwds_11_tfdynamicformtranslationattributename_sel ,
                                                 AV62Trn_dynamicformtranslationwwds_10_tfdynamicformtranslationattributename ,
                                                 AV65Trn_dynamicformtranslationwwds_13_tfdynamicformtranslationenglish_sel ,
                                                 AV64Trn_dynamicformtranslationwwds_12_tfdynamicformtranslationenglish ,
                                                 AV67Trn_dynamicformtranslationwwds_15_tfdynamicformtranslationdutch_sel ,
                                                 AV66Trn_dynamicformtranslationwwds_14_tfdynamicformtranslationdutch ,
                                                 A586DynamicFormTranslationWWpFormI ,
                                                 A587DynamicFormTranslationWWPFormV ,
                                                 A588DynamicFormTranslationWWPFormE ,
                                                 A589DynamicFormTranslationTrnName ,
                                                 A590DynamicFormTranslationAttribut ,
                                                 A591DynamicFormTranslationEnglish ,
                                                 A592DynamicFormTranslationDutch ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT,
                                                 TypeConstants.BOOLEAN
                                                 }
            });
            lV53Trn_dynamicformtranslationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Trn_dynamicformtranslationwwds_1_filterfulltext), "%", "");
            lV53Trn_dynamicformtranslationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Trn_dynamicformtranslationwwds_1_filterfulltext), "%", "");
            lV53Trn_dynamicformtranslationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Trn_dynamicformtranslationwwds_1_filterfulltext), "%", "");
            lV53Trn_dynamicformtranslationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Trn_dynamicformtranslationwwds_1_filterfulltext), "%", "");
            lV53Trn_dynamicformtranslationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Trn_dynamicformtranslationwwds_1_filterfulltext), "%", "");
            lV53Trn_dynamicformtranslationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Trn_dynamicformtranslationwwds_1_filterfulltext), "%", "");
            lV53Trn_dynamicformtranslationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Trn_dynamicformtranslationwwds_1_filterfulltext), "%", "");
            lV60Trn_dynamicformtranslationwwds_8_tfdynamicformtranslationtrnname = StringUtil.Concat( StringUtil.RTrim( AV60Trn_dynamicformtranslationwwds_8_tfdynamicformtranslationtrnname), "%", "");
            lV62Trn_dynamicformtranslationwwds_10_tfdynamicformtranslationattributename = StringUtil.Concat( StringUtil.RTrim( AV62Trn_dynamicformtranslationwwds_10_tfdynamicformtranslationattributename), "%", "");
            lV64Trn_dynamicformtranslationwwds_12_tfdynamicformtranslationenglish = StringUtil.Concat( StringUtil.RTrim( AV64Trn_dynamicformtranslationwwds_12_tfdynamicformtranslationenglish), "%", "");
            lV66Trn_dynamicformtranslationwwds_14_tfdynamicformtranslationdutch = StringUtil.Concat( StringUtil.RTrim( AV66Trn_dynamicformtranslationwwds_14_tfdynamicformtranslationdutch), "%", "");
            /* Using cursor H00BD2 */
            pr_default.execute(0, new Object[] {lV53Trn_dynamicformtranslationwwds_1_filterfulltext, lV53Trn_dynamicformtranslationwwds_1_filterfulltext, lV53Trn_dynamicformtranslationwwds_1_filterfulltext, lV53Trn_dynamicformtranslationwwds_1_filterfulltext, lV53Trn_dynamicformtranslationwwds_1_filterfulltext, lV53Trn_dynamicformtranslationwwds_1_filterfulltext, lV53Trn_dynamicformtranslationwwds_1_filterfulltext, AV54Trn_dynamicformtranslationwwds_2_tfdynamicformtranslationwwpformid, AV55Trn_dynamicformtranslationwwds_3_tfdynamicformtranslationwwpformid_to, AV56Trn_dynamicformtranslationwwds_4_tfdynamicformtranslationwwpformversionnumber, AV57Trn_dynamicformtranslationwwds_5_tfdynamicformtranslationwwpformversionnumber_to, AV58Trn_dynamicformtranslationwwds_6_tfdynamicformtranslationwwpformelementid, AV59Trn_dynamicformtranslationwwds_7_tfdynamicformtranslationwwpformelementid_to, lV60Trn_dynamicformtranslationwwds_8_tfdynamicformtranslationtrnname, AV61Trn_dynamicformtranslationwwds_9_tfdynamicformtranslationtrnname_sel, lV62Trn_dynamicformtranslationwwds_10_tfdynamicformtranslationattributename, AV63Trn_dynamicformtranslationwwds_11_tfdynamicformtranslationattributename_sel, lV64Trn_dynamicformtranslationwwds_12_tfdynamicformtranslationenglish, AV65Trn_dynamicformtranslationwwds_13_tfdynamicformtranslationenglish_sel, lV66Trn_dynamicformtranslationwwds_14_tfdynamicformtranslationdutch, AV67Trn_dynamicformtranslationwwds_15_tfdynamicformtranslationdutch_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_39_idx = 1;
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A592DynamicFormTranslationDutch = H00BD2_A592DynamicFormTranslationDutch[0];
               A591DynamicFormTranslationEnglish = H00BD2_A591DynamicFormTranslationEnglish[0];
               A590DynamicFormTranslationAttribut = H00BD2_A590DynamicFormTranslationAttribut[0];
               A589DynamicFormTranslationTrnName = H00BD2_A589DynamicFormTranslationTrnName[0];
               A588DynamicFormTranslationWWPFormE = H00BD2_A588DynamicFormTranslationWWPFormE[0];
               A587DynamicFormTranslationWWPFormV = H00BD2_A587DynamicFormTranslationWWPFormV[0];
               A586DynamicFormTranslationWWpFormI = H00BD2_A586DynamicFormTranslationWWpFormI[0];
               A585DynamicFormTranslationId = H00BD2_A585DynamicFormTranslationId[0];
               /* Execute user event: Grid.Load */
               E20BD2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 39;
            WBBD0( ) ;
         }
         bGXsfl_39_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesBD2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV52Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV52Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV48IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV48IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV49IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV49IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV50IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV50IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DYNAMICFORMTRANSLATIONWWPFORMID", AV46IsAuthorized_DynamicFormTranslationWWpFormId);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DYNAMICFORMTRANSLATIONWWPFORMID", GetSecureSignedToken( "", AV46IsAuthorized_DynamicFormTranslationWWpFormId, context));
         GxWebStd.gx_hidden_field( context, "gxhash_DYNAMICFORMTRANSLATIONID"+"_"+sGXsfl_39_idx, GetSecureSignedToken( sGXsfl_39_idx, A585DynamicFormTranslationId, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV51IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV51IsAuthorized_Insert, context));
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
         AV53Trn_dynamicformtranslationwwds_1_filterfulltext = AV16FilterFullText;
         AV54Trn_dynamicformtranslationwwds_2_tfdynamicformtranslationwwpformid = AV25TFDynamicFormTranslationWWpFormId;
         AV55Trn_dynamicformtranslationwwds_3_tfdynamicformtranslationwwpformid_to = AV26TFDynamicFormTranslationWWpFormId_To;
         AV56Trn_dynamicformtranslationwwds_4_tfdynamicformtranslationwwpformversionnumber = AV27TFDynamicFormTranslationWWPFormVersionNumber;
         AV57Trn_dynamicformtranslationwwds_5_tfdynamicformtranslationwwpformversionnumber_to = AV28TFDynamicFormTranslationWWPFormVersionNumber_To;
         AV58Trn_dynamicformtranslationwwds_6_tfdynamicformtranslationwwpformelementid = AV29TFDynamicFormTranslationWWPFormElementId;
         AV59Trn_dynamicformtranslationwwds_7_tfdynamicformtranslationwwpformelementid_to = AV30TFDynamicFormTranslationWWPFormElementId_To;
         AV60Trn_dynamicformtranslationwwds_8_tfdynamicformtranslationtrnname = AV31TFDynamicFormTranslationTrnName;
         AV61Trn_dynamicformtranslationwwds_9_tfdynamicformtranslationtrnname_sel = AV32TFDynamicFormTranslationTrnName_Sel;
         AV62Trn_dynamicformtranslationwwds_10_tfdynamicformtranslationattributename = AV33TFDynamicFormTranslationAttributeName;
         AV63Trn_dynamicformtranslationwwds_11_tfdynamicformtranslationattributename_sel = AV34TFDynamicFormTranslationAttributeName_Sel;
         AV64Trn_dynamicformtranslationwwds_12_tfdynamicformtranslationenglish = AV35TFDynamicFormTranslationEnglish;
         AV65Trn_dynamicformtranslationwwds_13_tfdynamicformtranslationenglish_sel = AV36TFDynamicFormTranslationEnglish_Sel;
         AV66Trn_dynamicformtranslationwwds_14_tfdynamicformtranslationdutch = AV37TFDynamicFormTranslationDutch;
         AV67Trn_dynamicformtranslationwwds_15_tfdynamicformtranslationdutch_sel = AV38TFDynamicFormTranslationDutch_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV53Trn_dynamicformtranslationwwds_1_filterfulltext ,
                                              AV54Trn_dynamicformtranslationwwds_2_tfdynamicformtranslationwwpformid ,
                                              AV55Trn_dynamicformtranslationwwds_3_tfdynamicformtranslationwwpformid_to ,
                                              AV56Trn_dynamicformtranslationwwds_4_tfdynamicformtranslationwwpformversionnumber ,
                                              AV57Trn_dynamicformtranslationwwds_5_tfdynamicformtranslationwwpformversionnumber_to ,
                                              AV58Trn_dynamicformtranslationwwds_6_tfdynamicformtranslationwwpformelementid ,
                                              AV59Trn_dynamicformtranslationwwds_7_tfdynamicformtranslationwwpformelementid_to ,
                                              AV61Trn_dynamicformtranslationwwds_9_tfdynamicformtranslationtrnname_sel ,
                                              AV60Trn_dynamicformtranslationwwds_8_tfdynamicformtranslationtrnname ,
                                              AV63Trn_dynamicformtranslationwwds_11_tfdynamicformtranslationattributename_sel ,
                                              AV62Trn_dynamicformtranslationwwds_10_tfdynamicformtranslationattributename ,
                                              AV65Trn_dynamicformtranslationwwds_13_tfdynamicformtranslationenglish_sel ,
                                              AV64Trn_dynamicformtranslationwwds_12_tfdynamicformtranslationenglish ,
                                              AV67Trn_dynamicformtranslationwwds_15_tfdynamicformtranslationdutch_sel ,
                                              AV66Trn_dynamicformtranslationwwds_14_tfdynamicformtranslationdutch ,
                                              A586DynamicFormTranslationWWpFormI ,
                                              A587DynamicFormTranslationWWPFormV ,
                                              A588DynamicFormTranslationWWPFormE ,
                                              A589DynamicFormTranslationTrnName ,
                                              A590DynamicFormTranslationAttribut ,
                                              A591DynamicFormTranslationEnglish ,
                                              A592DynamicFormTranslationDutch ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV53Trn_dynamicformtranslationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Trn_dynamicformtranslationwwds_1_filterfulltext), "%", "");
         lV53Trn_dynamicformtranslationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Trn_dynamicformtranslationwwds_1_filterfulltext), "%", "");
         lV53Trn_dynamicformtranslationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Trn_dynamicformtranslationwwds_1_filterfulltext), "%", "");
         lV53Trn_dynamicformtranslationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Trn_dynamicformtranslationwwds_1_filterfulltext), "%", "");
         lV53Trn_dynamicformtranslationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Trn_dynamicformtranslationwwds_1_filterfulltext), "%", "");
         lV53Trn_dynamicformtranslationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Trn_dynamicformtranslationwwds_1_filterfulltext), "%", "");
         lV53Trn_dynamicformtranslationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Trn_dynamicformtranslationwwds_1_filterfulltext), "%", "");
         lV60Trn_dynamicformtranslationwwds_8_tfdynamicformtranslationtrnname = StringUtil.Concat( StringUtil.RTrim( AV60Trn_dynamicformtranslationwwds_8_tfdynamicformtranslationtrnname), "%", "");
         lV62Trn_dynamicformtranslationwwds_10_tfdynamicformtranslationattributename = StringUtil.Concat( StringUtil.RTrim( AV62Trn_dynamicformtranslationwwds_10_tfdynamicformtranslationattributename), "%", "");
         lV64Trn_dynamicformtranslationwwds_12_tfdynamicformtranslationenglish = StringUtil.Concat( StringUtil.RTrim( AV64Trn_dynamicformtranslationwwds_12_tfdynamicformtranslationenglish), "%", "");
         lV66Trn_dynamicformtranslationwwds_14_tfdynamicformtranslationdutch = StringUtil.Concat( StringUtil.RTrim( AV66Trn_dynamicformtranslationwwds_14_tfdynamicformtranslationdutch), "%", "");
         /* Using cursor H00BD3 */
         pr_default.execute(1, new Object[] {lV53Trn_dynamicformtranslationwwds_1_filterfulltext, lV53Trn_dynamicformtranslationwwds_1_filterfulltext, lV53Trn_dynamicformtranslationwwds_1_filterfulltext, lV53Trn_dynamicformtranslationwwds_1_filterfulltext, lV53Trn_dynamicformtranslationwwds_1_filterfulltext, lV53Trn_dynamicformtranslationwwds_1_filterfulltext, lV53Trn_dynamicformtranslationwwds_1_filterfulltext, AV54Trn_dynamicformtranslationwwds_2_tfdynamicformtranslationwwpformid, AV55Trn_dynamicformtranslationwwds_3_tfdynamicformtranslationwwpformid_to, AV56Trn_dynamicformtranslationwwds_4_tfdynamicformtranslationwwpformversionnumber, AV57Trn_dynamicformtranslationwwds_5_tfdynamicformtranslationwwpformversionnumber_to, AV58Trn_dynamicformtranslationwwds_6_tfdynamicformtranslationwwpformelementid, AV59Trn_dynamicformtranslationwwds_7_tfdynamicformtranslationwwpformelementid_to, lV60Trn_dynamicformtranslationwwds_8_tfdynamicformtranslationtrnname, AV61Trn_dynamicformtranslationwwds_9_tfdynamicformtranslationtrnname_sel, lV62Trn_dynamicformtranslationwwds_10_tfdynamicformtranslationattributename, AV63Trn_dynamicformtranslationwwds_11_tfdynamicformtranslationattributename_sel, lV64Trn_dynamicformtranslationwwds_12_tfdynamicformtranslationenglish, AV65Trn_dynamicformtranslationwwds_13_tfdynamicformtranslationenglish_sel, lV66Trn_dynamicformtranslationwwds_14_tfdynamicformtranslationdutch, AV67Trn_dynamicformtranslationwwds_15_tfdynamicformtranslationdutch_sel});
         GRID_nRecordCount = H00BD3_AGRID_nRecordCount[0];
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
         AV53Trn_dynamicformtranslationwwds_1_filterfulltext = AV16FilterFullText;
         AV54Trn_dynamicformtranslationwwds_2_tfdynamicformtranslationwwpformid = AV25TFDynamicFormTranslationWWpFormId;
         AV55Trn_dynamicformtranslationwwds_3_tfdynamicformtranslationwwpformid_to = AV26TFDynamicFormTranslationWWpFormId_To;
         AV56Trn_dynamicformtranslationwwds_4_tfdynamicformtranslationwwpformversionnumber = AV27TFDynamicFormTranslationWWPFormVersionNumber;
         AV57Trn_dynamicformtranslationwwds_5_tfdynamicformtranslationwwpformversionnumber_to = AV28TFDynamicFormTranslationWWPFormVersionNumber_To;
         AV58Trn_dynamicformtranslationwwds_6_tfdynamicformtranslationwwpformelementid = AV29TFDynamicFormTranslationWWPFormElementId;
         AV59Trn_dynamicformtranslationwwds_7_tfdynamicformtranslationwwpformelementid_to = AV30TFDynamicFormTranslationWWPFormElementId_To;
         AV60Trn_dynamicformtranslationwwds_8_tfdynamicformtranslationtrnname = AV31TFDynamicFormTranslationTrnName;
         AV61Trn_dynamicformtranslationwwds_9_tfdynamicformtranslationtrnname_sel = AV32TFDynamicFormTranslationTrnName_Sel;
         AV62Trn_dynamicformtranslationwwds_10_tfdynamicformtranslationattributename = AV33TFDynamicFormTranslationAttributeName;
         AV63Trn_dynamicformtranslationwwds_11_tfdynamicformtranslationattributename_sel = AV34TFDynamicFormTranslationAttributeName_Sel;
         AV64Trn_dynamicformtranslationwwds_12_tfdynamicformtranslationenglish = AV35TFDynamicFormTranslationEnglish;
         AV65Trn_dynamicformtranslationwwds_13_tfdynamicformtranslationenglish_sel = AV36TFDynamicFormTranslationEnglish_Sel;
         AV66Trn_dynamicformtranslationwwds_14_tfdynamicformtranslationdutch = AV37TFDynamicFormTranslationDutch;
         AV67Trn_dynamicformtranslationwwds_15_tfdynamicformtranslationdutch_sel = AV38TFDynamicFormTranslationDutch_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV52Pgmname, AV25TFDynamicFormTranslationWWpFormId, AV26TFDynamicFormTranslationWWpFormId_To, AV27TFDynamicFormTranslationWWPFormVersionNumber, AV28TFDynamicFormTranslationWWPFormVersionNumber_To, AV29TFDynamicFormTranslationWWPFormElementId, AV30TFDynamicFormTranslationWWPFormElementId_To, AV31TFDynamicFormTranslationTrnName, AV32TFDynamicFormTranslationTrnName_Sel, AV33TFDynamicFormTranslationAttributeName, AV34TFDynamicFormTranslationAttributeName_Sel, AV35TFDynamicFormTranslationEnglish, AV36TFDynamicFormTranslationEnglish_Sel, AV37TFDynamicFormTranslationDutch, AV38TFDynamicFormTranslationDutch_Sel, AV48IsAuthorized_Display, AV49IsAuthorized_Update, AV50IsAuthorized_Delete, AV46IsAuthorized_DynamicFormTranslationWWpFormId, AV51IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV53Trn_dynamicformtranslationwwds_1_filterfulltext = AV16FilterFullText;
         AV54Trn_dynamicformtranslationwwds_2_tfdynamicformtranslationwwpformid = AV25TFDynamicFormTranslationWWpFormId;
         AV55Trn_dynamicformtranslationwwds_3_tfdynamicformtranslationwwpformid_to = AV26TFDynamicFormTranslationWWpFormId_To;
         AV56Trn_dynamicformtranslationwwds_4_tfdynamicformtranslationwwpformversionnumber = AV27TFDynamicFormTranslationWWPFormVersionNumber;
         AV57Trn_dynamicformtranslationwwds_5_tfdynamicformtranslationwwpformversionnumber_to = AV28TFDynamicFormTranslationWWPFormVersionNumber_To;
         AV58Trn_dynamicformtranslationwwds_6_tfdynamicformtranslationwwpformelementid = AV29TFDynamicFormTranslationWWPFormElementId;
         AV59Trn_dynamicformtranslationwwds_7_tfdynamicformtranslationwwpformelementid_to = AV30TFDynamicFormTranslationWWPFormElementId_To;
         AV60Trn_dynamicformtranslationwwds_8_tfdynamicformtranslationtrnname = AV31TFDynamicFormTranslationTrnName;
         AV61Trn_dynamicformtranslationwwds_9_tfdynamicformtranslationtrnname_sel = AV32TFDynamicFormTranslationTrnName_Sel;
         AV62Trn_dynamicformtranslationwwds_10_tfdynamicformtranslationattributename = AV33TFDynamicFormTranslationAttributeName;
         AV63Trn_dynamicformtranslationwwds_11_tfdynamicformtranslationattributename_sel = AV34TFDynamicFormTranslationAttributeName_Sel;
         AV64Trn_dynamicformtranslationwwds_12_tfdynamicformtranslationenglish = AV35TFDynamicFormTranslationEnglish;
         AV65Trn_dynamicformtranslationwwds_13_tfdynamicformtranslationenglish_sel = AV36TFDynamicFormTranslationEnglish_Sel;
         AV66Trn_dynamicformtranslationwwds_14_tfdynamicformtranslationdutch = AV37TFDynamicFormTranslationDutch;
         AV67Trn_dynamicformtranslationwwds_15_tfdynamicformtranslationdutch_sel = AV38TFDynamicFormTranslationDutch_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV52Pgmname, AV25TFDynamicFormTranslationWWpFormId, AV26TFDynamicFormTranslationWWpFormId_To, AV27TFDynamicFormTranslationWWPFormVersionNumber, AV28TFDynamicFormTranslationWWPFormVersionNumber_To, AV29TFDynamicFormTranslationWWPFormElementId, AV30TFDynamicFormTranslationWWPFormElementId_To, AV31TFDynamicFormTranslationTrnName, AV32TFDynamicFormTranslationTrnName_Sel, AV33TFDynamicFormTranslationAttributeName, AV34TFDynamicFormTranslationAttributeName_Sel, AV35TFDynamicFormTranslationEnglish, AV36TFDynamicFormTranslationEnglish_Sel, AV37TFDynamicFormTranslationDutch, AV38TFDynamicFormTranslationDutch_Sel, AV48IsAuthorized_Display, AV49IsAuthorized_Update, AV50IsAuthorized_Delete, AV46IsAuthorized_DynamicFormTranslationWWpFormId, AV51IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV53Trn_dynamicformtranslationwwds_1_filterfulltext = AV16FilterFullText;
         AV54Trn_dynamicformtranslationwwds_2_tfdynamicformtranslationwwpformid = AV25TFDynamicFormTranslationWWpFormId;
         AV55Trn_dynamicformtranslationwwds_3_tfdynamicformtranslationwwpformid_to = AV26TFDynamicFormTranslationWWpFormId_To;
         AV56Trn_dynamicformtranslationwwds_4_tfdynamicformtranslationwwpformversionnumber = AV27TFDynamicFormTranslationWWPFormVersionNumber;
         AV57Trn_dynamicformtranslationwwds_5_tfdynamicformtranslationwwpformversionnumber_to = AV28TFDynamicFormTranslationWWPFormVersionNumber_To;
         AV58Trn_dynamicformtranslationwwds_6_tfdynamicformtranslationwwpformelementid = AV29TFDynamicFormTranslationWWPFormElementId;
         AV59Trn_dynamicformtranslationwwds_7_tfdynamicformtranslationwwpformelementid_to = AV30TFDynamicFormTranslationWWPFormElementId_To;
         AV60Trn_dynamicformtranslationwwds_8_tfdynamicformtranslationtrnname = AV31TFDynamicFormTranslationTrnName;
         AV61Trn_dynamicformtranslationwwds_9_tfdynamicformtranslationtrnname_sel = AV32TFDynamicFormTranslationTrnName_Sel;
         AV62Trn_dynamicformtranslationwwds_10_tfdynamicformtranslationattributename = AV33TFDynamicFormTranslationAttributeName;
         AV63Trn_dynamicformtranslationwwds_11_tfdynamicformtranslationattributename_sel = AV34TFDynamicFormTranslationAttributeName_Sel;
         AV64Trn_dynamicformtranslationwwds_12_tfdynamicformtranslationenglish = AV35TFDynamicFormTranslationEnglish;
         AV65Trn_dynamicformtranslationwwds_13_tfdynamicformtranslationenglish_sel = AV36TFDynamicFormTranslationEnglish_Sel;
         AV66Trn_dynamicformtranslationwwds_14_tfdynamicformtranslationdutch = AV37TFDynamicFormTranslationDutch;
         AV67Trn_dynamicformtranslationwwds_15_tfdynamicformtranslationdutch_sel = AV38TFDynamicFormTranslationDutch_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV52Pgmname, AV25TFDynamicFormTranslationWWpFormId, AV26TFDynamicFormTranslationWWpFormId_To, AV27TFDynamicFormTranslationWWPFormVersionNumber, AV28TFDynamicFormTranslationWWPFormVersionNumber_To, AV29TFDynamicFormTranslationWWPFormElementId, AV30TFDynamicFormTranslationWWPFormElementId_To, AV31TFDynamicFormTranslationTrnName, AV32TFDynamicFormTranslationTrnName_Sel, AV33TFDynamicFormTranslationAttributeName, AV34TFDynamicFormTranslationAttributeName_Sel, AV35TFDynamicFormTranslationEnglish, AV36TFDynamicFormTranslationEnglish_Sel, AV37TFDynamicFormTranslationDutch, AV38TFDynamicFormTranslationDutch_Sel, AV48IsAuthorized_Display, AV49IsAuthorized_Update, AV50IsAuthorized_Delete, AV46IsAuthorized_DynamicFormTranslationWWpFormId, AV51IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV53Trn_dynamicformtranslationwwds_1_filterfulltext = AV16FilterFullText;
         AV54Trn_dynamicformtranslationwwds_2_tfdynamicformtranslationwwpformid = AV25TFDynamicFormTranslationWWpFormId;
         AV55Trn_dynamicformtranslationwwds_3_tfdynamicformtranslationwwpformid_to = AV26TFDynamicFormTranslationWWpFormId_To;
         AV56Trn_dynamicformtranslationwwds_4_tfdynamicformtranslationwwpformversionnumber = AV27TFDynamicFormTranslationWWPFormVersionNumber;
         AV57Trn_dynamicformtranslationwwds_5_tfdynamicformtranslationwwpformversionnumber_to = AV28TFDynamicFormTranslationWWPFormVersionNumber_To;
         AV58Trn_dynamicformtranslationwwds_6_tfdynamicformtranslationwwpformelementid = AV29TFDynamicFormTranslationWWPFormElementId;
         AV59Trn_dynamicformtranslationwwds_7_tfdynamicformtranslationwwpformelementid_to = AV30TFDynamicFormTranslationWWPFormElementId_To;
         AV60Trn_dynamicformtranslationwwds_8_tfdynamicformtranslationtrnname = AV31TFDynamicFormTranslationTrnName;
         AV61Trn_dynamicformtranslationwwds_9_tfdynamicformtranslationtrnname_sel = AV32TFDynamicFormTranslationTrnName_Sel;
         AV62Trn_dynamicformtranslationwwds_10_tfdynamicformtranslationattributename = AV33TFDynamicFormTranslationAttributeName;
         AV63Trn_dynamicformtranslationwwds_11_tfdynamicformtranslationattributename_sel = AV34TFDynamicFormTranslationAttributeName_Sel;
         AV64Trn_dynamicformtranslationwwds_12_tfdynamicformtranslationenglish = AV35TFDynamicFormTranslationEnglish;
         AV65Trn_dynamicformtranslationwwds_13_tfdynamicformtranslationenglish_sel = AV36TFDynamicFormTranslationEnglish_Sel;
         AV66Trn_dynamicformtranslationwwds_14_tfdynamicformtranslationdutch = AV37TFDynamicFormTranslationDutch;
         AV67Trn_dynamicformtranslationwwds_15_tfdynamicformtranslationdutch_sel = AV38TFDynamicFormTranslationDutch_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV52Pgmname, AV25TFDynamicFormTranslationWWpFormId, AV26TFDynamicFormTranslationWWpFormId_To, AV27TFDynamicFormTranslationWWPFormVersionNumber, AV28TFDynamicFormTranslationWWPFormVersionNumber_To, AV29TFDynamicFormTranslationWWPFormElementId, AV30TFDynamicFormTranslationWWPFormElementId_To, AV31TFDynamicFormTranslationTrnName, AV32TFDynamicFormTranslationTrnName_Sel, AV33TFDynamicFormTranslationAttributeName, AV34TFDynamicFormTranslationAttributeName_Sel, AV35TFDynamicFormTranslationEnglish, AV36TFDynamicFormTranslationEnglish_Sel, AV37TFDynamicFormTranslationDutch, AV38TFDynamicFormTranslationDutch_Sel, AV48IsAuthorized_Display, AV49IsAuthorized_Update, AV50IsAuthorized_Delete, AV46IsAuthorized_DynamicFormTranslationWWpFormId, AV51IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV53Trn_dynamicformtranslationwwds_1_filterfulltext = AV16FilterFullText;
         AV54Trn_dynamicformtranslationwwds_2_tfdynamicformtranslationwwpformid = AV25TFDynamicFormTranslationWWpFormId;
         AV55Trn_dynamicformtranslationwwds_3_tfdynamicformtranslationwwpformid_to = AV26TFDynamicFormTranslationWWpFormId_To;
         AV56Trn_dynamicformtranslationwwds_4_tfdynamicformtranslationwwpformversionnumber = AV27TFDynamicFormTranslationWWPFormVersionNumber;
         AV57Trn_dynamicformtranslationwwds_5_tfdynamicformtranslationwwpformversionnumber_to = AV28TFDynamicFormTranslationWWPFormVersionNumber_To;
         AV58Trn_dynamicformtranslationwwds_6_tfdynamicformtranslationwwpformelementid = AV29TFDynamicFormTranslationWWPFormElementId;
         AV59Trn_dynamicformtranslationwwds_7_tfdynamicformtranslationwwpformelementid_to = AV30TFDynamicFormTranslationWWPFormElementId_To;
         AV60Trn_dynamicformtranslationwwds_8_tfdynamicformtranslationtrnname = AV31TFDynamicFormTranslationTrnName;
         AV61Trn_dynamicformtranslationwwds_9_tfdynamicformtranslationtrnname_sel = AV32TFDynamicFormTranslationTrnName_Sel;
         AV62Trn_dynamicformtranslationwwds_10_tfdynamicformtranslationattributename = AV33TFDynamicFormTranslationAttributeName;
         AV63Trn_dynamicformtranslationwwds_11_tfdynamicformtranslationattributename_sel = AV34TFDynamicFormTranslationAttributeName_Sel;
         AV64Trn_dynamicformtranslationwwds_12_tfdynamicformtranslationenglish = AV35TFDynamicFormTranslationEnglish;
         AV65Trn_dynamicformtranslationwwds_13_tfdynamicformtranslationenglish_sel = AV36TFDynamicFormTranslationEnglish_Sel;
         AV66Trn_dynamicformtranslationwwds_14_tfdynamicformtranslationdutch = AV37TFDynamicFormTranslationDutch;
         AV67Trn_dynamicformtranslationwwds_15_tfdynamicformtranslationdutch_sel = AV38TFDynamicFormTranslationDutch_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV52Pgmname, AV25TFDynamicFormTranslationWWpFormId, AV26TFDynamicFormTranslationWWpFormId_To, AV27TFDynamicFormTranslationWWPFormVersionNumber, AV28TFDynamicFormTranslationWWPFormVersionNumber_To, AV29TFDynamicFormTranslationWWPFormElementId, AV30TFDynamicFormTranslationWWPFormElementId_To, AV31TFDynamicFormTranslationTrnName, AV32TFDynamicFormTranslationTrnName_Sel, AV33TFDynamicFormTranslationAttributeName, AV34TFDynamicFormTranslationAttributeName_Sel, AV35TFDynamicFormTranslationEnglish, AV36TFDynamicFormTranslationEnglish_Sel, AV37TFDynamicFormTranslationDutch, AV38TFDynamicFormTranslationDutch_Sel, AV48IsAuthorized_Display, AV49IsAuthorized_Update, AV50IsAuthorized_Delete, AV46IsAuthorized_DynamicFormTranslationWWpFormId, AV51IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV52Pgmname = "Trn_DynamicFormTranslationWW";
         edtDynamicFormTranslationId_Enabled = 0;
         edtDynamicFormTranslationWWpFormI_Enabled = 0;
         edtDynamicFormTranslationWWPFormV_Enabled = 0;
         edtDynamicFormTranslationWWPFormE_Enabled = 0;
         edtDynamicFormTranslationTrnName_Enabled = 0;
         edtDynamicFormTranslationAttribut_Enabled = 0;
         edtDynamicFormTranslationEnglish_Enabled = 0;
         edtDynamicFormTranslationDutch_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPBD0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E18BD2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV22ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV39DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV19ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_39 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_39"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV43GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV44GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV45GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
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
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV16FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            /* Read subfile selected row values. */
            nGXsfl_39_idx = (int)(Math.Round(context.localUtil.CToN( cgiGet( subGrid_Internalname+"_ROW"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
            if ( nGXsfl_39_idx > 0 )
            {
               A585DynamicFormTranslationId = StringUtil.StrToGuid( cgiGet( edtDynamicFormTranslationId_Internalname));
               A586DynamicFormTranslationWWpFormI = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtDynamicFormTranslationWWpFormI_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A587DynamicFormTranslationWWPFormV = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtDynamicFormTranslationWWPFormV_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A588DynamicFormTranslationWWPFormE = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtDynamicFormTranslationWWPFormE_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A589DynamicFormTranslationTrnName = cgiGet( edtDynamicFormTranslationTrnName_Internalname);
               A590DynamicFormTranslationAttribut = cgiGet( edtDynamicFormTranslationAttribut_Internalname);
               A591DynamicFormTranslationEnglish = cgiGet( edtDynamicFormTranslationEnglish_Internalname);
               A592DynamicFormTranslationDutch = cgiGet( edtDynamicFormTranslationDutch_Internalname);
               cmbavActiongroup.Name = cmbavActiongroup_Internalname;
               cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
               AV47ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV47ActionGroup), 4, 0));
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV16FilterFullText) != 0 )
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
         E18BD2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E18BD2( )
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
         GXt_boolean1 = AV46IsAuthorized_DynamicFormTranslationWWpFormId;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_dynamicformtranslationview_Execute", out  GXt_boolean1) ;
         AV46IsAuthorized_DynamicFormTranslationWWpFormId = GXt_boolean1;
         AssignAttri("", false, "AV46IsAuthorized_DynamicFormTranslationWWpFormId", AV46IsAuthorized_DynamicFormTranslationWWpFormId);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DYNAMICFORMTRANSLATIONWWPFORMID", GetSecureSignedToken( "", AV46IsAuthorized_DynamicFormTranslationWWpFormId, context));
         AV40GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV41GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV40GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = context.GetMessage( " Trn_Dynamic Form Translation", "");
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV39DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV39DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E19BD2( )
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
         if ( AV24ManageFiltersExecutionStep == 1 )
         {
            AV24ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV24ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV24ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV24ManageFiltersExecutionStep == 2 )
         {
            AV24ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV24ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV24ManageFiltersExecutionStep), 1, 0));
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
         if ( StringUtil.StrCmp(AV21Session.Get("Trn_DynamicFormTranslationWWColumnsSelector"), "") != 0 )
         {
            AV17ColumnsSelectorXML = AV21Session.Get("Trn_DynamicFormTranslationWWColumnsSelector");
            AV19ColumnsSelector.FromXml(AV17ColumnsSelectorXML, null, "", "");
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
         edtDynamicFormTranslationId_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtDynamicFormTranslationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDynamicFormTranslationId_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtDynamicFormTranslationWWpFormI_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtDynamicFormTranslationWWpFormI_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDynamicFormTranslationWWpFormI_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtDynamicFormTranslationWWPFormV_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtDynamicFormTranslationWWPFormV_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDynamicFormTranslationWWPFormV_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtDynamicFormTranslationWWPFormE_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtDynamicFormTranslationWWPFormE_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDynamicFormTranslationWWPFormE_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtDynamicFormTranslationTrnName_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtDynamicFormTranslationTrnName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDynamicFormTranslationTrnName_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtDynamicFormTranslationAttribut_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtDynamicFormTranslationAttribut_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDynamicFormTranslationAttribut_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtDynamicFormTranslationEnglish_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtDynamicFormTranslationEnglish_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDynamicFormTranslationEnglish_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtDynamicFormTranslationDutch_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtDynamicFormTranslationDutch_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDynamicFormTranslationDutch_Visible), 5, 0), !bGXsfl_39_Refreshing);
         AV43GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV43GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV43GridCurrentPage), 10, 0));
         AV44GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV44GridPageCount", StringUtil.LTrimStr( (decimal)(AV44GridPageCount), 10, 0));
         GXt_char3 = AV45GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV52Pgmname, out  GXt_char3) ;
         AV45GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV45GridAppliedFilters", AV45GridAppliedFilters);
         AV53Trn_dynamicformtranslationwwds_1_filterfulltext = AV16FilterFullText;
         AV54Trn_dynamicformtranslationwwds_2_tfdynamicformtranslationwwpformid = AV25TFDynamicFormTranslationWWpFormId;
         AV55Trn_dynamicformtranslationwwds_3_tfdynamicformtranslationwwpformid_to = AV26TFDynamicFormTranslationWWpFormId_To;
         AV56Trn_dynamicformtranslationwwds_4_tfdynamicformtranslationwwpformversionnumber = AV27TFDynamicFormTranslationWWPFormVersionNumber;
         AV57Trn_dynamicformtranslationwwds_5_tfdynamicformtranslationwwpformversionnumber_to = AV28TFDynamicFormTranslationWWPFormVersionNumber_To;
         AV58Trn_dynamicformtranslationwwds_6_tfdynamicformtranslationwwpformelementid = AV29TFDynamicFormTranslationWWPFormElementId;
         AV59Trn_dynamicformtranslationwwds_7_tfdynamicformtranslationwwpformelementid_to = AV30TFDynamicFormTranslationWWPFormElementId_To;
         AV60Trn_dynamicformtranslationwwds_8_tfdynamicformtranslationtrnname = AV31TFDynamicFormTranslationTrnName;
         AV61Trn_dynamicformtranslationwwds_9_tfdynamicformtranslationtrnname_sel = AV32TFDynamicFormTranslationTrnName_Sel;
         AV62Trn_dynamicformtranslationwwds_10_tfdynamicformtranslationattributename = AV33TFDynamicFormTranslationAttributeName;
         AV63Trn_dynamicformtranslationwwds_11_tfdynamicformtranslationattributename_sel = AV34TFDynamicFormTranslationAttributeName_Sel;
         AV64Trn_dynamicformtranslationwwds_12_tfdynamicformtranslationenglish = AV35TFDynamicFormTranslationEnglish;
         AV65Trn_dynamicformtranslationwwds_13_tfdynamicformtranslationenglish_sel = AV36TFDynamicFormTranslationEnglish_Sel;
         AV66Trn_dynamicformtranslationwwds_14_tfdynamicformtranslationdutch = AV37TFDynamicFormTranslationDutch;
         AV67Trn_dynamicformtranslationwwds_15_tfdynamicformtranslationdutch_sel = AV38TFDynamicFormTranslationDutch_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ColumnsSelector", AV19ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ManageFiltersData", AV22ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E12BD2( )
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
            AV42PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV42PageToGo) ;
         }
      }

      protected void E13BD2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E15BD2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DynamicFormTranslationWWpFormId") == 0 )
            {
               AV25TFDynamicFormTranslationWWpFormId = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV25TFDynamicFormTranslationWWpFormId", StringUtil.LTrimStr( (decimal)(AV25TFDynamicFormTranslationWWpFormId), 6, 0));
               AV26TFDynamicFormTranslationWWpFormId_To = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV26TFDynamicFormTranslationWWpFormId_To", StringUtil.LTrimStr( (decimal)(AV26TFDynamicFormTranslationWWpFormId_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DynamicFormTranslationWWPFormVersionNumber") == 0 )
            {
               AV27TFDynamicFormTranslationWWPFormVersionNumber = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV27TFDynamicFormTranslationWWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(AV27TFDynamicFormTranslationWWPFormVersionNumber), 6, 0));
               AV28TFDynamicFormTranslationWWPFormVersionNumber_To = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV28TFDynamicFormTranslationWWPFormVersionNumber_To", StringUtil.LTrimStr( (decimal)(AV28TFDynamicFormTranslationWWPFormVersionNumber_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DynamicFormTranslationWWPFormElementId") == 0 )
            {
               AV29TFDynamicFormTranslationWWPFormElementId = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV29TFDynamicFormTranslationWWPFormElementId", StringUtil.LTrimStr( (decimal)(AV29TFDynamicFormTranslationWWPFormElementId), 6, 0));
               AV30TFDynamicFormTranslationWWPFormElementId_To = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV30TFDynamicFormTranslationWWPFormElementId_To", StringUtil.LTrimStr( (decimal)(AV30TFDynamicFormTranslationWWPFormElementId_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DynamicFormTranslationTrnName") == 0 )
            {
               AV31TFDynamicFormTranslationTrnName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV31TFDynamicFormTranslationTrnName", AV31TFDynamicFormTranslationTrnName);
               AV32TFDynamicFormTranslationTrnName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV32TFDynamicFormTranslationTrnName_Sel", AV32TFDynamicFormTranslationTrnName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DynamicFormTranslationAttributeName") == 0 )
            {
               AV33TFDynamicFormTranslationAttributeName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV33TFDynamicFormTranslationAttributeName", AV33TFDynamicFormTranslationAttributeName);
               AV34TFDynamicFormTranslationAttributeName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV34TFDynamicFormTranslationAttributeName_Sel", AV34TFDynamicFormTranslationAttributeName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DynamicFormTranslationEnglish") == 0 )
            {
               AV35TFDynamicFormTranslationEnglish = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV35TFDynamicFormTranslationEnglish", AV35TFDynamicFormTranslationEnglish);
               AV36TFDynamicFormTranslationEnglish_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV36TFDynamicFormTranslationEnglish_Sel", AV36TFDynamicFormTranslationEnglish_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DynamicFormTranslationDutch") == 0 )
            {
               AV37TFDynamicFormTranslationDutch = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV37TFDynamicFormTranslationDutch", AV37TFDynamicFormTranslationDutch);
               AV38TFDynamicFormTranslationDutch_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV38TFDynamicFormTranslationDutch_Sel", AV38TFDynamicFormTranslationDutch_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E20BD2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavActiongroup.removeAllItems();
         cmbavActiongroup.addItem("0", ";fas fa-bars", 0);
         if ( AV48IsAuthorized_Display )
         {
            cmbavActiongroup.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
         }
         if ( AV49IsAuthorized_Update )
         {
            cmbavActiongroup.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "Edit", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
         }
         if ( AV50IsAuthorized_Delete )
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
         if ( AV46IsAuthorized_DynamicFormTranslationWWpFormId )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_dynamicformtranslationview.aspx"+UrlEncode(A585DynamicFormTranslationId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            edtDynamicFormTranslationWWpFormI_Link = formatLink("trn_dynamicformtranslationview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV47ActionGroup), 4, 0));
      }

      protected void E16BD2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV17ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV19ColumnsSelector.FromJSonString(AV17ColumnsSelectorXML, null);
         new WorkWithPlus.workwithplus_web.savecolumnsselectorstate(context ).execute(  "Trn_DynamicFormTranslationWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV17ColumnsSelectorXML)) ? "" : AV19ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ColumnsSelector", AV19ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ManageFiltersData", AV22ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E11BD2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("Trn_DynamicFormTranslationWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV52Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV24ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV24ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV24ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("Trn_DynamicFormTranslationWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV24ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV24ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV24ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV23ManageFiltersXml;
            new WorkWithPlus.workwithplus_web.getfilterbyname(context ).execute(  "Trn_DynamicFormTranslationWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV23ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV23ManageFiltersXml)) )
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
               new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV52Pgmname+"GridState",  AV23ManageFiltersXml) ;
               AV11GridState.FromXml(AV23ManageFiltersXml, null, "", "");
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ColumnsSelector", AV19ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ManageFiltersData", AV22ManageFiltersData);
      }

      protected void E21BD2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ColumnsSelector", AV19ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ManageFiltersData", AV22ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E17BD2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV51IsAuthorized_Insert )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_dynamicformtranslation.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(Guid.Empty.ToString());
            CallWebObject(formatLink("trn_dynamicformtranslation.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ColumnsSelector", AV19ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ManageFiltersData", AV22ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E14BD2( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0060",(string)"",(string)"Trn_DynamicFormTranslation",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0060"+"");
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
         AV19ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "DynamicFormTranslationId",  "",  "Translation Id",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "DynamicFormTranslationWWpFormId",  "",  "Form Id",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "DynamicFormTranslationWWPFormVersionNumber",  "",  "Version Number",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "DynamicFormTranslationWWPFormElementId",  "",  "Element Id",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "DynamicFormTranslationTrnName",  "",  "Trn Name",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "DynamicFormTranslationAttributeName",  "",  "Attribute Name",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "DynamicFormTranslationEnglish",  "",  "Translation English",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "DynamicFormTranslationDutch",  "",  "Translation Dutch",  true,  "") ;
         GXt_char3 = AV18UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "Trn_DynamicFormTranslationWWColumnsSelector", out  GXt_char3) ;
         AV18UserCustomValue = GXt_char3;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV18UserCustomValue)) ) )
         {
            AV20ColumnsSelectorAux.FromXml(AV18UserCustomValue, null, "", "");
            new WorkWithPlus.workwithplus_web.wwp_columnselector_updatecolumns(context ).execute( ref  AV20ColumnsSelectorAux, ref  AV19ColumnsSelector) ;
         }
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV48IsAuthorized_Display;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_dynamicformtranslationview_Execute", out  GXt_boolean1) ;
         AV48IsAuthorized_Display = GXt_boolean1;
         AssignAttri("", false, "AV48IsAuthorized_Display", AV48IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV48IsAuthorized_Display, context));
         GXt_boolean1 = AV49IsAuthorized_Update;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_dynamicformtranslation_Update", out  GXt_boolean1) ;
         AV49IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV49IsAuthorized_Update", AV49IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV49IsAuthorized_Update, context));
         GXt_boolean1 = AV50IsAuthorized_Delete;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_dynamicformtranslation_Delete", out  GXt_boolean1) ;
         AV50IsAuthorized_Delete = GXt_boolean1;
         AssignAttri("", false, "AV50IsAuthorized_Delete", AV50IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV50IsAuthorized_Delete, context));
         GXt_boolean1 = AV51IsAuthorized_Insert;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_dynamicformtranslation_Insert", out  GXt_boolean1) ;
         AV51IsAuthorized_Insert = GXt_boolean1;
         AssignAttri("", false, "AV51IsAuthorized_Insert", AV51IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV51IsAuthorized_Insert, context));
         if ( ! ( AV51IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
         if ( ! ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "Trn_DynamicFormTranslation",  1) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV22ManageFiltersData;
         new WorkWithPlus.workwithplus_web.wwp_managefiltersloadsavedfilters(context ).execute(  "Trn_DynamicFormTranslationWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV22ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S182( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV16FilterFullText = "";
         AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
         AV25TFDynamicFormTranslationWWpFormId = 0;
         AssignAttri("", false, "AV25TFDynamicFormTranslationWWpFormId", StringUtil.LTrimStr( (decimal)(AV25TFDynamicFormTranslationWWpFormId), 6, 0));
         AV26TFDynamicFormTranslationWWpFormId_To = 0;
         AssignAttri("", false, "AV26TFDynamicFormTranslationWWpFormId_To", StringUtil.LTrimStr( (decimal)(AV26TFDynamicFormTranslationWWpFormId_To), 6, 0));
         AV27TFDynamicFormTranslationWWPFormVersionNumber = 0;
         AssignAttri("", false, "AV27TFDynamicFormTranslationWWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(AV27TFDynamicFormTranslationWWPFormVersionNumber), 6, 0));
         AV28TFDynamicFormTranslationWWPFormVersionNumber_To = 0;
         AssignAttri("", false, "AV28TFDynamicFormTranslationWWPFormVersionNumber_To", StringUtil.LTrimStr( (decimal)(AV28TFDynamicFormTranslationWWPFormVersionNumber_To), 6, 0));
         AV29TFDynamicFormTranslationWWPFormElementId = 0;
         AssignAttri("", false, "AV29TFDynamicFormTranslationWWPFormElementId", StringUtil.LTrimStr( (decimal)(AV29TFDynamicFormTranslationWWPFormElementId), 6, 0));
         AV30TFDynamicFormTranslationWWPFormElementId_To = 0;
         AssignAttri("", false, "AV30TFDynamicFormTranslationWWPFormElementId_To", StringUtil.LTrimStr( (decimal)(AV30TFDynamicFormTranslationWWPFormElementId_To), 6, 0));
         AV31TFDynamicFormTranslationTrnName = "";
         AssignAttri("", false, "AV31TFDynamicFormTranslationTrnName", AV31TFDynamicFormTranslationTrnName);
         AV32TFDynamicFormTranslationTrnName_Sel = "";
         AssignAttri("", false, "AV32TFDynamicFormTranslationTrnName_Sel", AV32TFDynamicFormTranslationTrnName_Sel);
         AV33TFDynamicFormTranslationAttributeName = "";
         AssignAttri("", false, "AV33TFDynamicFormTranslationAttributeName", AV33TFDynamicFormTranslationAttributeName);
         AV34TFDynamicFormTranslationAttributeName_Sel = "";
         AssignAttri("", false, "AV34TFDynamicFormTranslationAttributeName_Sel", AV34TFDynamicFormTranslationAttributeName_Sel);
         AV35TFDynamicFormTranslationEnglish = "";
         AssignAttri("", false, "AV35TFDynamicFormTranslationEnglish", AV35TFDynamicFormTranslationEnglish);
         AV36TFDynamicFormTranslationEnglish_Sel = "";
         AssignAttri("", false, "AV36TFDynamicFormTranslationEnglish_Sel", AV36TFDynamicFormTranslationEnglish_Sel);
         AV37TFDynamicFormTranslationDutch = "";
         AssignAttri("", false, "AV37TFDynamicFormTranslationDutch", AV37TFDynamicFormTranslationDutch);
         AV38TFDynamicFormTranslationDutch_Sel = "";
         AssignAttri("", false, "AV38TFDynamicFormTranslationDutch_Sel", AV38TFDynamicFormTranslationDutch_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S202( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         if ( AV48IsAuthorized_Display )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_dynamicformtranslationview.aspx"+UrlEncode(A585DynamicFormTranslationId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            CallWebObject(formatLink("trn_dynamicformtranslationview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
         if ( AV49IsAuthorized_Update )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_dynamicformtranslation.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(A585DynamicFormTranslationId.ToString());
            CallWebObject(formatLink("trn_dynamicformtranslation.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
            GXEncryptionTmp = "trn_dynamicformtranslation.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(A585DynamicFormTranslationId.ToString());
            CallWebObject(formatLink("trn_dynamicformtranslation.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
         if ( StringUtil.StrCmp(AV21Session.Get(AV52Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV52Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV21Session.Get(AV52Pgmname+"GridState"), null, "", "");
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
         AV68GXV1 = 1;
         while ( AV68GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV68GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV16FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDYNAMICFORMTRANSLATIONWWPFORMID") == 0 )
            {
               AV25TFDynamicFormTranslationWWpFormId = (int)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV25TFDynamicFormTranslationWWpFormId", StringUtil.LTrimStr( (decimal)(AV25TFDynamicFormTranslationWWpFormId), 6, 0));
               AV26TFDynamicFormTranslationWWpFormId_To = (int)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV26TFDynamicFormTranslationWWpFormId_To", StringUtil.LTrimStr( (decimal)(AV26TFDynamicFormTranslationWWpFormId_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDYNAMICFORMTRANSLATIONWWPFORMVERSIONNUMBER") == 0 )
            {
               AV27TFDynamicFormTranslationWWPFormVersionNumber = (int)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV27TFDynamicFormTranslationWWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(AV27TFDynamicFormTranslationWWPFormVersionNumber), 6, 0));
               AV28TFDynamicFormTranslationWWPFormVersionNumber_To = (int)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV28TFDynamicFormTranslationWWPFormVersionNumber_To", StringUtil.LTrimStr( (decimal)(AV28TFDynamicFormTranslationWWPFormVersionNumber_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDYNAMICFORMTRANSLATIONWWPFORMELEMENTID") == 0 )
            {
               AV29TFDynamicFormTranslationWWPFormElementId = (int)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV29TFDynamicFormTranslationWWPFormElementId", StringUtil.LTrimStr( (decimal)(AV29TFDynamicFormTranslationWWPFormElementId), 6, 0));
               AV30TFDynamicFormTranslationWWPFormElementId_To = (int)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV30TFDynamicFormTranslationWWPFormElementId_To", StringUtil.LTrimStr( (decimal)(AV30TFDynamicFormTranslationWWPFormElementId_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDYNAMICFORMTRANSLATIONTRNNAME") == 0 )
            {
               AV31TFDynamicFormTranslationTrnName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV31TFDynamicFormTranslationTrnName", AV31TFDynamicFormTranslationTrnName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDYNAMICFORMTRANSLATIONTRNNAME_SEL") == 0 )
            {
               AV32TFDynamicFormTranslationTrnName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV32TFDynamicFormTranslationTrnName_Sel", AV32TFDynamicFormTranslationTrnName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDYNAMICFORMTRANSLATIONATTRIBUTENAME") == 0 )
            {
               AV33TFDynamicFormTranslationAttributeName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV33TFDynamicFormTranslationAttributeName", AV33TFDynamicFormTranslationAttributeName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDYNAMICFORMTRANSLATIONATTRIBUTENAME_SEL") == 0 )
            {
               AV34TFDynamicFormTranslationAttributeName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV34TFDynamicFormTranslationAttributeName_Sel", AV34TFDynamicFormTranslationAttributeName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDYNAMICFORMTRANSLATIONENGLISH") == 0 )
            {
               AV35TFDynamicFormTranslationEnglish = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV35TFDynamicFormTranslationEnglish", AV35TFDynamicFormTranslationEnglish);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDYNAMICFORMTRANSLATIONENGLISH_SEL") == 0 )
            {
               AV36TFDynamicFormTranslationEnglish_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV36TFDynamicFormTranslationEnglish_Sel", AV36TFDynamicFormTranslationEnglish_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDYNAMICFORMTRANSLATIONDUTCH") == 0 )
            {
               AV37TFDynamicFormTranslationDutch = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV37TFDynamicFormTranslationDutch", AV37TFDynamicFormTranslationDutch);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDYNAMICFORMTRANSLATIONDUTCH_SEL") == 0 )
            {
               AV38TFDynamicFormTranslationDutch_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV38TFDynamicFormTranslationDutch_Sel", AV38TFDynamicFormTranslationDutch_Sel);
            }
            AV68GXV1 = (int)(AV68GXV1+1);
         }
         GXt_char3 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV32TFDynamicFormTranslationTrnName_Sel)),  AV32TFDynamicFormTranslationTrnName_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFDynamicFormTranslationAttributeName_Sel)),  AV34TFDynamicFormTranslationAttributeName_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFDynamicFormTranslationEnglish_Sel)),  AV36TFDynamicFormTranslationEnglish_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFDynamicFormTranslationDutch_Sel)),  AV38TFDynamicFormTranslationDutch_Sel, out  GXt_char7) ;
         Ddo_grid_Selectedvalue_set = "||||"+GXt_char3+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char7 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV31TFDynamicFormTranslationTrnName)),  AV31TFDynamicFormTranslationTrnName, out  GXt_char7) ;
         GXt_char6 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV33TFDynamicFormTranslationAttributeName)),  AV33TFDynamicFormTranslationAttributeName, out  GXt_char6) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFDynamicFormTranslationEnglish)),  AV35TFDynamicFormTranslationEnglish, out  GXt_char5) ;
         GXt_char3 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFDynamicFormTranslationDutch)),  AV37TFDynamicFormTranslationDutch, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = "|"+((0==AV25TFDynamicFormTranslationWWpFormId) ? "" : StringUtil.Str( (decimal)(AV25TFDynamicFormTranslationWWpFormId), 6, 0))+"|"+((0==AV27TFDynamicFormTranslationWWPFormVersionNumber) ? "" : StringUtil.Str( (decimal)(AV27TFDynamicFormTranslationWWPFormVersionNumber), 6, 0))+"|"+((0==AV29TFDynamicFormTranslationWWPFormElementId) ? "" : StringUtil.Str( (decimal)(AV29TFDynamicFormTranslationWWPFormElementId), 6, 0))+"|"+GXt_char7+"|"+GXt_char6+"|"+GXt_char5+"|"+GXt_char3;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|"+((0==AV26TFDynamicFormTranslationWWpFormId_To) ? "" : StringUtil.Str( (decimal)(AV26TFDynamicFormTranslationWWpFormId_To), 6, 0))+"|"+((0==AV28TFDynamicFormTranslationWWPFormVersionNumber_To) ? "" : StringUtil.Str( (decimal)(AV28TFDynamicFormTranslationWWPFormVersionNumber_To), 6, 0))+"|"+((0==AV30TFDynamicFormTranslationWWPFormElementId_To) ? "" : StringUtil.Str( (decimal)(AV30TFDynamicFormTranslationWWPFormElementId_To), 6, 0))+"||||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV21Session.Get(AV52Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)),  0,  AV16FilterFullText,  AV16FilterFullText,  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFDYNAMICFORMTRANSLATIONWWPFORMID",  context.GetMessage( "Form Id", ""),  !((0==AV25TFDynamicFormTranslationWWpFormId)&&(0==AV26TFDynamicFormTranslationWWpFormId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV25TFDynamicFormTranslationWWpFormId), 6, 0)),  ((0==AV25TFDynamicFormTranslationWWpFormId) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV25TFDynamicFormTranslationWWpFormId), "ZZZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV26TFDynamicFormTranslationWWpFormId_To), 6, 0)),  ((0==AV26TFDynamicFormTranslationWWpFormId_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV26TFDynamicFormTranslationWWpFormId_To), "ZZZZZ9")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFDYNAMICFORMTRANSLATIONWWPFORMVERSIONNUMBER",  context.GetMessage( "Version Number", ""),  !((0==AV27TFDynamicFormTranslationWWPFormVersionNumber)&&(0==AV28TFDynamicFormTranslationWWPFormVersionNumber_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV27TFDynamicFormTranslationWWPFormVersionNumber), 6, 0)),  ((0==AV27TFDynamicFormTranslationWWPFormVersionNumber) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV27TFDynamicFormTranslationWWPFormVersionNumber), "ZZZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV28TFDynamicFormTranslationWWPFormVersionNumber_To), 6, 0)),  ((0==AV28TFDynamicFormTranslationWWPFormVersionNumber_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV28TFDynamicFormTranslationWWPFormVersionNumber_To), "ZZZZZ9")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFDYNAMICFORMTRANSLATIONWWPFORMELEMENTID",  context.GetMessage( "Element Id", ""),  !((0==AV29TFDynamicFormTranslationWWPFormElementId)&&(0==AV30TFDynamicFormTranslationWWPFormElementId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV29TFDynamicFormTranslationWWPFormElementId), 6, 0)),  ((0==AV29TFDynamicFormTranslationWWPFormElementId) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV29TFDynamicFormTranslationWWPFormElementId), "ZZZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV30TFDynamicFormTranslationWWPFormElementId_To), 6, 0)),  ((0==AV30TFDynamicFormTranslationWWPFormElementId_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV30TFDynamicFormTranslationWWPFormElementId_To), "ZZZZZ9")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFDYNAMICFORMTRANSLATIONTRNNAME",  context.GetMessage( "Trn Name", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV31TFDynamicFormTranslationTrnName)),  0,  AV31TFDynamicFormTranslationTrnName,  AV31TFDynamicFormTranslationTrnName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV32TFDynamicFormTranslationTrnName_Sel)),  AV32TFDynamicFormTranslationTrnName_Sel,  AV32TFDynamicFormTranslationTrnName_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFDYNAMICFORMTRANSLATIONATTRIBUTENAME",  context.GetMessage( "Attribute Name", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV33TFDynamicFormTranslationAttributeName)),  0,  AV33TFDynamicFormTranslationAttributeName,  AV33TFDynamicFormTranslationAttributeName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFDynamicFormTranslationAttributeName_Sel)),  AV34TFDynamicFormTranslationAttributeName_Sel,  AV34TFDynamicFormTranslationAttributeName_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFDYNAMICFORMTRANSLATIONENGLISH",  context.GetMessage( "Translation English", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFDynamicFormTranslationEnglish)),  0,  AV35TFDynamicFormTranslationEnglish,  AV35TFDynamicFormTranslationEnglish,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFDynamicFormTranslationEnglish_Sel)),  AV36TFDynamicFormTranslationEnglish_Sel,  AV36TFDynamicFormTranslationEnglish_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFDYNAMICFORMTRANSLATIONDUTCH",  context.GetMessage( "Translation Dutch", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFDynamicFormTranslationDutch)),  0,  AV37TFDynamicFormTranslationDutch,  AV37TFDynamicFormTranslationDutch,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFDynamicFormTranslationDutch_Sel)),  AV38TFDynamicFormTranslationDutch_Sel,  AV38TFDynamicFormTranslationDutch_Sel) ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV52Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV52Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Trn_DynamicFormTranslation";
         AV21Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
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
         PABD2( ) ;
         WSBD2( ) ;
         WEBD2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202562017154094", true, true);
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
         context.AddJavascriptSource("trn_dynamicformtranslationww.js", "?202562017154096", false, true);
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
         edtDynamicFormTranslationId_Internalname = "DYNAMICFORMTRANSLATIONID_"+sGXsfl_39_idx;
         edtDynamicFormTranslationWWpFormI_Internalname = "DYNAMICFORMTRANSLATIONWWPFORMI_"+sGXsfl_39_idx;
         edtDynamicFormTranslationWWPFormV_Internalname = "DYNAMICFORMTRANSLATIONWWPFORMV_"+sGXsfl_39_idx;
         edtDynamicFormTranslationWWPFormE_Internalname = "DYNAMICFORMTRANSLATIONWWPFORME_"+sGXsfl_39_idx;
         edtDynamicFormTranslationTrnName_Internalname = "DYNAMICFORMTRANSLATIONTRNNAME_"+sGXsfl_39_idx;
         edtDynamicFormTranslationAttribut_Internalname = "DYNAMICFORMTRANSLATIONATTRIBUT_"+sGXsfl_39_idx;
         edtDynamicFormTranslationEnglish_Internalname = "DYNAMICFORMTRANSLATIONENGLISH_"+sGXsfl_39_idx;
         edtDynamicFormTranslationDutch_Internalname = "DYNAMICFORMTRANSLATIONDUTCH_"+sGXsfl_39_idx;
         cmbavActiongroup_Internalname = "vACTIONGROUP_"+sGXsfl_39_idx;
      }

      protected void SubsflControlProps_fel_392( )
      {
         edtDynamicFormTranslationId_Internalname = "DYNAMICFORMTRANSLATIONID_"+sGXsfl_39_fel_idx;
         edtDynamicFormTranslationWWpFormI_Internalname = "DYNAMICFORMTRANSLATIONWWPFORMI_"+sGXsfl_39_fel_idx;
         edtDynamicFormTranslationWWPFormV_Internalname = "DYNAMICFORMTRANSLATIONWWPFORMV_"+sGXsfl_39_fel_idx;
         edtDynamicFormTranslationWWPFormE_Internalname = "DYNAMICFORMTRANSLATIONWWPFORME_"+sGXsfl_39_fel_idx;
         edtDynamicFormTranslationTrnName_Internalname = "DYNAMICFORMTRANSLATIONTRNNAME_"+sGXsfl_39_fel_idx;
         edtDynamicFormTranslationAttribut_Internalname = "DYNAMICFORMTRANSLATIONATTRIBUT_"+sGXsfl_39_fel_idx;
         edtDynamicFormTranslationEnglish_Internalname = "DYNAMICFORMTRANSLATIONENGLISH_"+sGXsfl_39_fel_idx;
         edtDynamicFormTranslationDutch_Internalname = "DYNAMICFORMTRANSLATIONDUTCH_"+sGXsfl_39_fel_idx;
         cmbavActiongroup_Internalname = "vACTIONGROUP_"+sGXsfl_39_fel_idx;
      }

      protected void sendrow_392( )
      {
         sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
         SubsflControlProps_392( ) ;
         WBBD0( ) ;
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtDynamicFormTranslationId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDynamicFormTranslationId_Internalname,A585DynamicFormTranslationId.ToString(),A585DynamicFormTranslationId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDynamicFormTranslationId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtDynamicFormTranslationId_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)39,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtDynamicFormTranslationWWpFormI_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDynamicFormTranslationWWpFormI_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A586DynamicFormTranslationWWpFormI), 6, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A586DynamicFormTranslationWWpFormI), "ZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtDynamicFormTranslationWWpFormI_Link,(string)"",(string)"",(string)"",(string)edtDynamicFormTranslationWWpFormI_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtDynamicFormTranslationWWpFormI_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtDynamicFormTranslationWWPFormV_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDynamicFormTranslationWWPFormV_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A587DynamicFormTranslationWWPFormV), 6, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A587DynamicFormTranslationWWPFormV), "ZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDynamicFormTranslationWWPFormV_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtDynamicFormTranslationWWPFormV_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtDynamicFormTranslationWWPFormE_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDynamicFormTranslationWWPFormE_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A588DynamicFormTranslationWWPFormE), 6, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A588DynamicFormTranslationWWPFormE), "ZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDynamicFormTranslationWWPFormE_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtDynamicFormTranslationWWPFormE_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtDynamicFormTranslationTrnName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDynamicFormTranslationTrnName_Internalname,(string)A589DynamicFormTranslationTrnName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDynamicFormTranslationTrnName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtDynamicFormTranslationTrnName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)400,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtDynamicFormTranslationAttribut_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDynamicFormTranslationAttribut_Internalname,(string)A590DynamicFormTranslationAttribut,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDynamicFormTranslationAttribut_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtDynamicFormTranslationAttribut_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtDynamicFormTranslationEnglish_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDynamicFormTranslationEnglish_Internalname,(string)A591DynamicFormTranslationEnglish,(string)A591DynamicFormTranslationEnglish,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDynamicFormTranslationEnglish_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtDynamicFormTranslationEnglish_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)39,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtDynamicFormTranslationDutch_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDynamicFormTranslationDutch_Internalname,(string)A592DynamicFormTranslationDutch,(string)A592DynamicFormTranslationDutch,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDynamicFormTranslationDutch_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtDynamicFormTranslationDutch_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)39,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'" + sGXsfl_39_idx + "',39)\"";
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
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavActiongroup,(string)cmbavActiongroup_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV47ActionGroup), 4, 0)),(short)1,(string)cmbavActiongroup_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVACTIONGROUP.CLICK."+sGXsfl_39_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)cmbavActiongroup_Class,(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"",(string)"",(bool)true,(short)0});
            cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV47ActionGroup), 4, 0));
            AssignProp("", false, cmbavActiongroup_Internalname, "Values", (string)(cmbavActiongroup.ToJavascriptSource()), !bGXsfl_39_Refreshing);
            send_integrity_lvl_hashesBD2( ) ;
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
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtDynamicFormTranslationId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Translation Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtDynamicFormTranslationWWpFormI_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Form Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtDynamicFormTranslationWWPFormV_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Version Number", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtDynamicFormTranslationWWPFormE_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Element Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtDynamicFormTranslationTrnName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Trn Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtDynamicFormTranslationAttribut_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Attribute Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtDynamicFormTranslationEnglish_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Translation English", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtDynamicFormTranslationDutch_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Translation Dutch", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A585DynamicFormTranslationId.ToString()));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDynamicFormTranslationId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A586DynamicFormTranslationWWpFormI), 6, 0, ".", ""))));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtDynamicFormTranslationWWpFormI_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDynamicFormTranslationWWpFormI_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A587DynamicFormTranslationWWPFormV), 6, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDynamicFormTranslationWWPFormV_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A588DynamicFormTranslationWWPFormE), 6, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDynamicFormTranslationWWPFormE_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A589DynamicFormTranslationTrnName));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDynamicFormTranslationTrnName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A590DynamicFormTranslationAttribut));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDynamicFormTranslationAttribut_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A591DynamicFormTranslationEnglish));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDynamicFormTranslationEnglish_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A592DynamicFormTranslationDutch));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDynamicFormTranslationDutch_Visible), 5, 0, ".", "")));
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
         edtDynamicFormTranslationId_Internalname = "DYNAMICFORMTRANSLATIONID";
         edtDynamicFormTranslationWWpFormI_Internalname = "DYNAMICFORMTRANSLATIONWWPFORMI";
         edtDynamicFormTranslationWWPFormV_Internalname = "DYNAMICFORMTRANSLATIONWWPFORMV";
         edtDynamicFormTranslationWWPFormE_Internalname = "DYNAMICFORMTRANSLATIONWWPFORME";
         edtDynamicFormTranslationTrnName_Internalname = "DYNAMICFORMTRANSLATIONTRNNAME";
         edtDynamicFormTranslationAttribut_Internalname = "DYNAMICFORMTRANSLATIONATTRIBUT";
         edtDynamicFormTranslationEnglish_Internalname = "DYNAMICFORMTRANSLATIONENGLISH";
         edtDynamicFormTranslationDutch_Internalname = "DYNAMICFORMTRANSLATIONDUTCH";
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
         edtDynamicFormTranslationDutch_Jsonclick = "";
         edtDynamicFormTranslationEnglish_Jsonclick = "";
         edtDynamicFormTranslationAttribut_Jsonclick = "";
         edtDynamicFormTranslationTrnName_Jsonclick = "";
         edtDynamicFormTranslationWWPFormE_Jsonclick = "";
         edtDynamicFormTranslationWWPFormV_Jsonclick = "";
         edtDynamicFormTranslationWWpFormI_Jsonclick = "";
         edtDynamicFormTranslationWWpFormI_Link = "";
         edtDynamicFormTranslationId_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWithSelection WorkWith";
         subGrid_Backcolorstyle = 0;
         edtDynamicFormTranslationDutch_Visible = -1;
         edtDynamicFormTranslationEnglish_Visible = -1;
         edtDynamicFormTranslationAttribut_Visible = -1;
         edtDynamicFormTranslationTrnName_Visible = -1;
         edtDynamicFormTranslationWWPFormE_Visible = -1;
         edtDynamicFormTranslationWWPFormV_Visible = -1;
         edtDynamicFormTranslationWWpFormI_Visible = -1;
         edtDynamicFormTranslationId_Visible = -1;
         edtDynamicFormTranslationDutch_Enabled = 0;
         edtDynamicFormTranslationEnglish_Enabled = 0;
         edtDynamicFormTranslationAttribut_Enabled = 0;
         edtDynamicFormTranslationTrnName_Enabled = 0;
         edtDynamicFormTranslationWWPFormE_Enabled = 0;
         edtDynamicFormTranslationWWPFormV_Enabled = 0;
         edtDynamicFormTranslationWWpFormI_Enabled = 0;
         edtDynamicFormTranslationId_Enabled = 0;
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
         Ddo_grid_Format = "|6.0|6.0|6.0||||";
         Ddo_grid_Datalistproc = "Trn_DynamicFormTranslationWWGetFilterData";
         Ddo_grid_Datalisttype = "||||Dynamic|Dynamic|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "||||T|T|T|T";
         Ddo_grid_Filterisrange = "|T|T|T||||";
         Ddo_grid_Filtertype = "|Numeric|Numeric|Numeric|Character|Character|Character|Character";
         Ddo_grid_Includefilter = "|T|T|T|T|T|T|T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|1|3|4|5|6|7|8";
         Ddo_grid_Columnids = "0:DynamicFormTranslationId|1:DynamicFormTranslationWWpFormId|2:DynamicFormTranslationWWPFormVersionNumber|3:DynamicFormTranslationWWPFormElementId|4:DynamicFormTranslationTrnName|5:DynamicFormTranslationAttributeName|6:DynamicFormTranslationEnglish|7:DynamicFormTranslationDutch";
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
         Form.Caption = context.GetMessage( " Trn_Dynamic Form Translation", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV52Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV25TFDynamicFormTranslationWWpFormId","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMID","pic":"ZZZZZ9"},{"av":"AV26TFDynamicFormTranslationWWpFormId_To","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMID_TO","pic":"ZZZZZ9"},{"av":"AV27TFDynamicFormTranslationWWPFormVersionNumber","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMVERSIONNUMBER","pic":"ZZZZZ9"},{"av":"AV28TFDynamicFormTranslationWWPFormVersionNumber_To","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMVERSIONNUMBER_TO","pic":"ZZZZZ9"},{"av":"AV29TFDynamicFormTranslationWWPFormElementId","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMELEMENTID","pic":"ZZZZZ9"},{"av":"AV30TFDynamicFormTranslationWWPFormElementId_To","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMELEMENTID_TO","pic":"ZZZZZ9"},{"av":"AV31TFDynamicFormTranslationTrnName","fld":"vTFDYNAMICFORMTRANSLATIONTRNNAME"},{"av":"AV32TFDynamicFormTranslationTrnName_Sel","fld":"vTFDYNAMICFORMTRANSLATIONTRNNAME_SEL"},{"av":"AV33TFDynamicFormTranslationAttributeName","fld":"vTFDYNAMICFORMTRANSLATIONATTRIBUTENAME"},{"av":"AV34TFDynamicFormTranslationAttributeName_Sel","fld":"vTFDYNAMICFORMTRANSLATIONATTRIBUTENAME_SEL"},{"av":"AV35TFDynamicFormTranslationEnglish","fld":"vTFDYNAMICFORMTRANSLATIONENGLISH"},{"av":"AV36TFDynamicFormTranslationEnglish_Sel","fld":"vTFDYNAMICFORMTRANSLATIONENGLISH_SEL"},{"av":"AV37TFDynamicFormTranslationDutch","fld":"vTFDYNAMICFORMTRANSLATIONDUTCH"},{"av":"AV38TFDynamicFormTranslationDutch_Sel","fld":"vTFDYNAMICFORMTRANSLATIONDUTCH_SEL"},{"av":"AV48IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV49IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV50IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV46IsAuthorized_DynamicFormTranslationWWpFormId","fld":"vISAUTHORIZED_DYNAMICFORMTRANSLATIONWWPFORMID","hsh":true},{"av":"AV51IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtDynamicFormTranslationId_Visible","ctrl":"DYNAMICFORMTRANSLATIONID","prop":"Visible"},{"av":"edtDynamicFormTranslationWWpFormI_Visible","ctrl":"DYNAMICFORMTRANSLATIONWWPFORMI","prop":"Visible"},{"av":"edtDynamicFormTranslationWWPFormV_Visible","ctrl":"DYNAMICFORMTRANSLATIONWWPFORMV","prop":"Visible"},{"av":"edtDynamicFormTranslationWWPFormE_Visible","ctrl":"DYNAMICFORMTRANSLATIONWWPFORME","prop":"Visible"},{"av":"edtDynamicFormTranslationTrnName_Visible","ctrl":"DYNAMICFORMTRANSLATIONTRNNAME","prop":"Visible"},{"av":"edtDynamicFormTranslationAttribut_Visible","ctrl":"DYNAMICFORMTRANSLATIONATTRIBUT","prop":"Visible"},{"av":"edtDynamicFormTranslationEnglish_Visible","ctrl":"DYNAMICFORMTRANSLATIONENGLISH","prop":"Visible"},{"av":"edtDynamicFormTranslationDutch_Visible","ctrl":"DYNAMICFORMTRANSLATIONDUTCH","prop":"Visible"},{"av":"AV43GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV44GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV45GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV48IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV49IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV50IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV51IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV22ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E12BD2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV52Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV25TFDynamicFormTranslationWWpFormId","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMID","pic":"ZZZZZ9"},{"av":"AV26TFDynamicFormTranslationWWpFormId_To","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMID_TO","pic":"ZZZZZ9"},{"av":"AV27TFDynamicFormTranslationWWPFormVersionNumber","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMVERSIONNUMBER","pic":"ZZZZZ9"},{"av":"AV28TFDynamicFormTranslationWWPFormVersionNumber_To","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMVERSIONNUMBER_TO","pic":"ZZZZZ9"},{"av":"AV29TFDynamicFormTranslationWWPFormElementId","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMELEMENTID","pic":"ZZZZZ9"},{"av":"AV30TFDynamicFormTranslationWWPFormElementId_To","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMELEMENTID_TO","pic":"ZZZZZ9"},{"av":"AV31TFDynamicFormTranslationTrnName","fld":"vTFDYNAMICFORMTRANSLATIONTRNNAME"},{"av":"AV32TFDynamicFormTranslationTrnName_Sel","fld":"vTFDYNAMICFORMTRANSLATIONTRNNAME_SEL"},{"av":"AV33TFDynamicFormTranslationAttributeName","fld":"vTFDYNAMICFORMTRANSLATIONATTRIBUTENAME"},{"av":"AV34TFDynamicFormTranslationAttributeName_Sel","fld":"vTFDYNAMICFORMTRANSLATIONATTRIBUTENAME_SEL"},{"av":"AV35TFDynamicFormTranslationEnglish","fld":"vTFDYNAMICFORMTRANSLATIONENGLISH"},{"av":"AV36TFDynamicFormTranslationEnglish_Sel","fld":"vTFDYNAMICFORMTRANSLATIONENGLISH_SEL"},{"av":"AV37TFDynamicFormTranslationDutch","fld":"vTFDYNAMICFORMTRANSLATIONDUTCH"},{"av":"AV38TFDynamicFormTranslationDutch_Sel","fld":"vTFDYNAMICFORMTRANSLATIONDUTCH_SEL"},{"av":"AV48IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV49IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV50IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV46IsAuthorized_DynamicFormTranslationWWpFormId","fld":"vISAUTHORIZED_DYNAMICFORMTRANSLATIONWWPFORMID","hsh":true},{"av":"AV51IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E13BD2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV52Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV25TFDynamicFormTranslationWWpFormId","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMID","pic":"ZZZZZ9"},{"av":"AV26TFDynamicFormTranslationWWpFormId_To","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMID_TO","pic":"ZZZZZ9"},{"av":"AV27TFDynamicFormTranslationWWPFormVersionNumber","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMVERSIONNUMBER","pic":"ZZZZZ9"},{"av":"AV28TFDynamicFormTranslationWWPFormVersionNumber_To","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMVERSIONNUMBER_TO","pic":"ZZZZZ9"},{"av":"AV29TFDynamicFormTranslationWWPFormElementId","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMELEMENTID","pic":"ZZZZZ9"},{"av":"AV30TFDynamicFormTranslationWWPFormElementId_To","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMELEMENTID_TO","pic":"ZZZZZ9"},{"av":"AV31TFDynamicFormTranslationTrnName","fld":"vTFDYNAMICFORMTRANSLATIONTRNNAME"},{"av":"AV32TFDynamicFormTranslationTrnName_Sel","fld":"vTFDYNAMICFORMTRANSLATIONTRNNAME_SEL"},{"av":"AV33TFDynamicFormTranslationAttributeName","fld":"vTFDYNAMICFORMTRANSLATIONATTRIBUTENAME"},{"av":"AV34TFDynamicFormTranslationAttributeName_Sel","fld":"vTFDYNAMICFORMTRANSLATIONATTRIBUTENAME_SEL"},{"av":"AV35TFDynamicFormTranslationEnglish","fld":"vTFDYNAMICFORMTRANSLATIONENGLISH"},{"av":"AV36TFDynamicFormTranslationEnglish_Sel","fld":"vTFDYNAMICFORMTRANSLATIONENGLISH_SEL"},{"av":"AV37TFDynamicFormTranslationDutch","fld":"vTFDYNAMICFORMTRANSLATIONDUTCH"},{"av":"AV38TFDynamicFormTranslationDutch_Sel","fld":"vTFDYNAMICFORMTRANSLATIONDUTCH_SEL"},{"av":"AV48IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV49IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV50IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV46IsAuthorized_DynamicFormTranslationWWpFormId","fld":"vISAUTHORIZED_DYNAMICFORMTRANSLATIONWWPFORMID","hsh":true},{"av":"AV51IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E15BD2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV52Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV25TFDynamicFormTranslationWWpFormId","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMID","pic":"ZZZZZ9"},{"av":"AV26TFDynamicFormTranslationWWpFormId_To","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMID_TO","pic":"ZZZZZ9"},{"av":"AV27TFDynamicFormTranslationWWPFormVersionNumber","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMVERSIONNUMBER","pic":"ZZZZZ9"},{"av":"AV28TFDynamicFormTranslationWWPFormVersionNumber_To","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMVERSIONNUMBER_TO","pic":"ZZZZZ9"},{"av":"AV29TFDynamicFormTranslationWWPFormElementId","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMELEMENTID","pic":"ZZZZZ9"},{"av":"AV30TFDynamicFormTranslationWWPFormElementId_To","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMELEMENTID_TO","pic":"ZZZZZ9"},{"av":"AV31TFDynamicFormTranslationTrnName","fld":"vTFDYNAMICFORMTRANSLATIONTRNNAME"},{"av":"AV32TFDynamicFormTranslationTrnName_Sel","fld":"vTFDYNAMICFORMTRANSLATIONTRNNAME_SEL"},{"av":"AV33TFDynamicFormTranslationAttributeName","fld":"vTFDYNAMICFORMTRANSLATIONATTRIBUTENAME"},{"av":"AV34TFDynamicFormTranslationAttributeName_Sel","fld":"vTFDYNAMICFORMTRANSLATIONATTRIBUTENAME_SEL"},{"av":"AV35TFDynamicFormTranslationEnglish","fld":"vTFDYNAMICFORMTRANSLATIONENGLISH"},{"av":"AV36TFDynamicFormTranslationEnglish_Sel","fld":"vTFDYNAMICFORMTRANSLATIONENGLISH_SEL"},{"av":"AV37TFDynamicFormTranslationDutch","fld":"vTFDYNAMICFORMTRANSLATIONDUTCH"},{"av":"AV38TFDynamicFormTranslationDutch_Sel","fld":"vTFDYNAMICFORMTRANSLATIONDUTCH_SEL"},{"av":"AV48IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV49IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV50IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV46IsAuthorized_DynamicFormTranslationWWpFormId","fld":"vISAUTHORIZED_DYNAMICFORMTRANSLATIONWWPFORMID","hsh":true},{"av":"AV51IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV37TFDynamicFormTranslationDutch","fld":"vTFDYNAMICFORMTRANSLATIONDUTCH"},{"av":"AV38TFDynamicFormTranslationDutch_Sel","fld":"vTFDYNAMICFORMTRANSLATIONDUTCH_SEL"},{"av":"AV35TFDynamicFormTranslationEnglish","fld":"vTFDYNAMICFORMTRANSLATIONENGLISH"},{"av":"AV36TFDynamicFormTranslationEnglish_Sel","fld":"vTFDYNAMICFORMTRANSLATIONENGLISH_SEL"},{"av":"AV33TFDynamicFormTranslationAttributeName","fld":"vTFDYNAMICFORMTRANSLATIONATTRIBUTENAME"},{"av":"AV34TFDynamicFormTranslationAttributeName_Sel","fld":"vTFDYNAMICFORMTRANSLATIONATTRIBUTENAME_SEL"},{"av":"AV31TFDynamicFormTranslationTrnName","fld":"vTFDYNAMICFORMTRANSLATIONTRNNAME"},{"av":"AV32TFDynamicFormTranslationTrnName_Sel","fld":"vTFDYNAMICFORMTRANSLATIONTRNNAME_SEL"},{"av":"AV29TFDynamicFormTranslationWWPFormElementId","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMELEMENTID","pic":"ZZZZZ9"},{"av":"AV30TFDynamicFormTranslationWWPFormElementId_To","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMELEMENTID_TO","pic":"ZZZZZ9"},{"av":"AV27TFDynamicFormTranslationWWPFormVersionNumber","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMVERSIONNUMBER","pic":"ZZZZZ9"},{"av":"AV28TFDynamicFormTranslationWWPFormVersionNumber_To","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMVERSIONNUMBER_TO","pic":"ZZZZZ9"},{"av":"AV25TFDynamicFormTranslationWWpFormId","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMID","pic":"ZZZZZ9"},{"av":"AV26TFDynamicFormTranslationWWpFormId_To","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMID_TO","pic":"ZZZZZ9"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E20BD2","iparms":[{"av":"AV48IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV49IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV50IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV46IsAuthorized_DynamicFormTranslationWWpFormId","fld":"vISAUTHORIZED_DYNAMICFORMTRANSLATIONWWPFORMID","hsh":true},{"av":"A585DynamicFormTranslationId","fld":"DYNAMICFORMTRANSLATIONID","hsh":true}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"cmbavActiongroup"},{"av":"AV47ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"edtDynamicFormTranslationWWpFormI_Link","ctrl":"DYNAMICFORMTRANSLATIONWWPFORMI","prop":"Link"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E16BD2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV52Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV25TFDynamicFormTranslationWWpFormId","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMID","pic":"ZZZZZ9"},{"av":"AV26TFDynamicFormTranslationWWpFormId_To","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMID_TO","pic":"ZZZZZ9"},{"av":"AV27TFDynamicFormTranslationWWPFormVersionNumber","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMVERSIONNUMBER","pic":"ZZZZZ9"},{"av":"AV28TFDynamicFormTranslationWWPFormVersionNumber_To","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMVERSIONNUMBER_TO","pic":"ZZZZZ9"},{"av":"AV29TFDynamicFormTranslationWWPFormElementId","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMELEMENTID","pic":"ZZZZZ9"},{"av":"AV30TFDynamicFormTranslationWWPFormElementId_To","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMELEMENTID_TO","pic":"ZZZZZ9"},{"av":"AV31TFDynamicFormTranslationTrnName","fld":"vTFDYNAMICFORMTRANSLATIONTRNNAME"},{"av":"AV32TFDynamicFormTranslationTrnName_Sel","fld":"vTFDYNAMICFORMTRANSLATIONTRNNAME_SEL"},{"av":"AV33TFDynamicFormTranslationAttributeName","fld":"vTFDYNAMICFORMTRANSLATIONATTRIBUTENAME"},{"av":"AV34TFDynamicFormTranslationAttributeName_Sel","fld":"vTFDYNAMICFORMTRANSLATIONATTRIBUTENAME_SEL"},{"av":"AV35TFDynamicFormTranslationEnglish","fld":"vTFDYNAMICFORMTRANSLATIONENGLISH"},{"av":"AV36TFDynamicFormTranslationEnglish_Sel","fld":"vTFDYNAMICFORMTRANSLATIONENGLISH_SEL"},{"av":"AV37TFDynamicFormTranslationDutch","fld":"vTFDYNAMICFORMTRANSLATIONDUTCH"},{"av":"AV38TFDynamicFormTranslationDutch_Sel","fld":"vTFDYNAMICFORMTRANSLATIONDUTCH_SEL"},{"av":"AV48IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV49IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV50IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV46IsAuthorized_DynamicFormTranslationWWpFormId","fld":"vISAUTHORIZED_DYNAMICFORMTRANSLATIONWWPFORMID","hsh":true},{"av":"AV51IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"edtDynamicFormTranslationId_Visible","ctrl":"DYNAMICFORMTRANSLATIONID","prop":"Visible"},{"av":"edtDynamicFormTranslationWWpFormI_Visible","ctrl":"DYNAMICFORMTRANSLATIONWWPFORMI","prop":"Visible"},{"av":"edtDynamicFormTranslationWWPFormV_Visible","ctrl":"DYNAMICFORMTRANSLATIONWWPFORMV","prop":"Visible"},{"av":"edtDynamicFormTranslationWWPFormE_Visible","ctrl":"DYNAMICFORMTRANSLATIONWWPFORME","prop":"Visible"},{"av":"edtDynamicFormTranslationTrnName_Visible","ctrl":"DYNAMICFORMTRANSLATIONTRNNAME","prop":"Visible"},{"av":"edtDynamicFormTranslationAttribut_Visible","ctrl":"DYNAMICFORMTRANSLATIONATTRIBUT","prop":"Visible"},{"av":"edtDynamicFormTranslationEnglish_Visible","ctrl":"DYNAMICFORMTRANSLATIONENGLISH","prop":"Visible"},{"av":"edtDynamicFormTranslationDutch_Visible","ctrl":"DYNAMICFORMTRANSLATIONDUTCH","prop":"Visible"},{"av":"AV43GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV44GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV45GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV48IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV49IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV50IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV51IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV22ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E11BD2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV52Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV25TFDynamicFormTranslationWWpFormId","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMID","pic":"ZZZZZ9"},{"av":"AV26TFDynamicFormTranslationWWpFormId_To","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMID_TO","pic":"ZZZZZ9"},{"av":"AV27TFDynamicFormTranslationWWPFormVersionNumber","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMVERSIONNUMBER","pic":"ZZZZZ9"},{"av":"AV28TFDynamicFormTranslationWWPFormVersionNumber_To","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMVERSIONNUMBER_TO","pic":"ZZZZZ9"},{"av":"AV29TFDynamicFormTranslationWWPFormElementId","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMELEMENTID","pic":"ZZZZZ9"},{"av":"AV30TFDynamicFormTranslationWWPFormElementId_To","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMELEMENTID_TO","pic":"ZZZZZ9"},{"av":"AV31TFDynamicFormTranslationTrnName","fld":"vTFDYNAMICFORMTRANSLATIONTRNNAME"},{"av":"AV32TFDynamicFormTranslationTrnName_Sel","fld":"vTFDYNAMICFORMTRANSLATIONTRNNAME_SEL"},{"av":"AV33TFDynamicFormTranslationAttributeName","fld":"vTFDYNAMICFORMTRANSLATIONATTRIBUTENAME"},{"av":"AV34TFDynamicFormTranslationAttributeName_Sel","fld":"vTFDYNAMICFORMTRANSLATIONATTRIBUTENAME_SEL"},{"av":"AV35TFDynamicFormTranslationEnglish","fld":"vTFDYNAMICFORMTRANSLATIONENGLISH"},{"av":"AV36TFDynamicFormTranslationEnglish_Sel","fld":"vTFDYNAMICFORMTRANSLATIONENGLISH_SEL"},{"av":"AV37TFDynamicFormTranslationDutch","fld":"vTFDYNAMICFORMTRANSLATIONDUTCH"},{"av":"AV38TFDynamicFormTranslationDutch_Sel","fld":"vTFDYNAMICFORMTRANSLATIONDUTCH_SEL"},{"av":"AV48IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV49IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV50IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV46IsAuthorized_DynamicFormTranslationWWpFormId","fld":"vISAUTHORIZED_DYNAMICFORMTRANSLATIONWWPFORMID","hsh":true},{"av":"AV51IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV25TFDynamicFormTranslationWWpFormId","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMID","pic":"ZZZZZ9"},{"av":"AV26TFDynamicFormTranslationWWpFormId_To","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMID_TO","pic":"ZZZZZ9"},{"av":"AV27TFDynamicFormTranslationWWPFormVersionNumber","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMVERSIONNUMBER","pic":"ZZZZZ9"},{"av":"AV28TFDynamicFormTranslationWWPFormVersionNumber_To","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMVERSIONNUMBER_TO","pic":"ZZZZZ9"},{"av":"AV29TFDynamicFormTranslationWWPFormElementId","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMELEMENTID","pic":"ZZZZZ9"},{"av":"AV30TFDynamicFormTranslationWWPFormElementId_To","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMELEMENTID_TO","pic":"ZZZZZ9"},{"av":"AV31TFDynamicFormTranslationTrnName","fld":"vTFDYNAMICFORMTRANSLATIONTRNNAME"},{"av":"AV32TFDynamicFormTranslationTrnName_Sel","fld":"vTFDYNAMICFORMTRANSLATIONTRNNAME_SEL"},{"av":"AV33TFDynamicFormTranslationAttributeName","fld":"vTFDYNAMICFORMTRANSLATIONATTRIBUTENAME"},{"av":"AV34TFDynamicFormTranslationAttributeName_Sel","fld":"vTFDYNAMICFORMTRANSLATIONATTRIBUTENAME_SEL"},{"av":"AV35TFDynamicFormTranslationEnglish","fld":"vTFDYNAMICFORMTRANSLATIONENGLISH"},{"av":"AV36TFDynamicFormTranslationEnglish_Sel","fld":"vTFDYNAMICFORMTRANSLATIONENGLISH_SEL"},{"av":"AV37TFDynamicFormTranslationDutch","fld":"vTFDYNAMICFORMTRANSLATIONDUTCH"},{"av":"AV38TFDynamicFormTranslationDutch_Sel","fld":"vTFDYNAMICFORMTRANSLATIONDUTCH_SEL"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtDynamicFormTranslationId_Visible","ctrl":"DYNAMICFORMTRANSLATIONID","prop":"Visible"},{"av":"edtDynamicFormTranslationWWpFormI_Visible","ctrl":"DYNAMICFORMTRANSLATIONWWPFORMI","prop":"Visible"},{"av":"edtDynamicFormTranslationWWPFormV_Visible","ctrl":"DYNAMICFORMTRANSLATIONWWPFORMV","prop":"Visible"},{"av":"edtDynamicFormTranslationWWPFormE_Visible","ctrl":"DYNAMICFORMTRANSLATIONWWPFORME","prop":"Visible"},{"av":"edtDynamicFormTranslationTrnName_Visible","ctrl":"DYNAMICFORMTRANSLATIONTRNNAME","prop":"Visible"},{"av":"edtDynamicFormTranslationAttribut_Visible","ctrl":"DYNAMICFORMTRANSLATIONATTRIBUT","prop":"Visible"},{"av":"edtDynamicFormTranslationEnglish_Visible","ctrl":"DYNAMICFORMTRANSLATIONENGLISH","prop":"Visible"},{"av":"edtDynamicFormTranslationDutch_Visible","ctrl":"DYNAMICFORMTRANSLATIONDUTCH","prop":"Visible"},{"av":"AV43GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV44GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV45GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV48IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV49IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV50IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV51IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV22ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("VACTIONGROUP.CLICK","""{"handler":"E21BD2","iparms":[{"av":"cmbavActiongroup"},{"av":"AV47ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV52Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV25TFDynamicFormTranslationWWpFormId","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMID","pic":"ZZZZZ9"},{"av":"AV26TFDynamicFormTranslationWWpFormId_To","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMID_TO","pic":"ZZZZZ9"},{"av":"AV27TFDynamicFormTranslationWWPFormVersionNumber","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMVERSIONNUMBER","pic":"ZZZZZ9"},{"av":"AV28TFDynamicFormTranslationWWPFormVersionNumber_To","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMVERSIONNUMBER_TO","pic":"ZZZZZ9"},{"av":"AV29TFDynamicFormTranslationWWPFormElementId","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMELEMENTID","pic":"ZZZZZ9"},{"av":"AV30TFDynamicFormTranslationWWPFormElementId_To","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMELEMENTID_TO","pic":"ZZZZZ9"},{"av":"AV31TFDynamicFormTranslationTrnName","fld":"vTFDYNAMICFORMTRANSLATIONTRNNAME"},{"av":"AV32TFDynamicFormTranslationTrnName_Sel","fld":"vTFDYNAMICFORMTRANSLATIONTRNNAME_SEL"},{"av":"AV33TFDynamicFormTranslationAttributeName","fld":"vTFDYNAMICFORMTRANSLATIONATTRIBUTENAME"},{"av":"AV34TFDynamicFormTranslationAttributeName_Sel","fld":"vTFDYNAMICFORMTRANSLATIONATTRIBUTENAME_SEL"},{"av":"AV35TFDynamicFormTranslationEnglish","fld":"vTFDYNAMICFORMTRANSLATIONENGLISH"},{"av":"AV36TFDynamicFormTranslationEnglish_Sel","fld":"vTFDYNAMICFORMTRANSLATIONENGLISH_SEL"},{"av":"AV37TFDynamicFormTranslationDutch","fld":"vTFDYNAMICFORMTRANSLATIONDUTCH"},{"av":"AV38TFDynamicFormTranslationDutch_Sel","fld":"vTFDYNAMICFORMTRANSLATIONDUTCH_SEL"},{"av":"AV48IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV49IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV50IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV46IsAuthorized_DynamicFormTranslationWWpFormId","fld":"vISAUTHORIZED_DYNAMICFORMTRANSLATIONWWPFORMID","hsh":true},{"av":"AV51IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"A585DynamicFormTranslationId","fld":"DYNAMICFORMTRANSLATIONID","hsh":true}]""");
         setEventMetadata("VACTIONGROUP.CLICK",""","oparms":[{"av":"cmbavActiongroup"},{"av":"AV47ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtDynamicFormTranslationId_Visible","ctrl":"DYNAMICFORMTRANSLATIONID","prop":"Visible"},{"av":"edtDynamicFormTranslationWWpFormI_Visible","ctrl":"DYNAMICFORMTRANSLATIONWWPFORMI","prop":"Visible"},{"av":"edtDynamicFormTranslationWWPFormV_Visible","ctrl":"DYNAMICFORMTRANSLATIONWWPFORMV","prop":"Visible"},{"av":"edtDynamicFormTranslationWWPFormE_Visible","ctrl":"DYNAMICFORMTRANSLATIONWWPFORME","prop":"Visible"},{"av":"edtDynamicFormTranslationTrnName_Visible","ctrl":"DYNAMICFORMTRANSLATIONTRNNAME","prop":"Visible"},{"av":"edtDynamicFormTranslationAttribut_Visible","ctrl":"DYNAMICFORMTRANSLATIONATTRIBUT","prop":"Visible"},{"av":"edtDynamicFormTranslationEnglish_Visible","ctrl":"DYNAMICFORMTRANSLATIONENGLISH","prop":"Visible"},{"av":"edtDynamicFormTranslationDutch_Visible","ctrl":"DYNAMICFORMTRANSLATIONDUTCH","prop":"Visible"},{"av":"AV43GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV44GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV45GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV48IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV49IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV50IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV51IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV22ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E17BD2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV52Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV25TFDynamicFormTranslationWWpFormId","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMID","pic":"ZZZZZ9"},{"av":"AV26TFDynamicFormTranslationWWpFormId_To","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMID_TO","pic":"ZZZZZ9"},{"av":"AV27TFDynamicFormTranslationWWPFormVersionNumber","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMVERSIONNUMBER","pic":"ZZZZZ9"},{"av":"AV28TFDynamicFormTranslationWWPFormVersionNumber_To","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMVERSIONNUMBER_TO","pic":"ZZZZZ9"},{"av":"AV29TFDynamicFormTranslationWWPFormElementId","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMELEMENTID","pic":"ZZZZZ9"},{"av":"AV30TFDynamicFormTranslationWWPFormElementId_To","fld":"vTFDYNAMICFORMTRANSLATIONWWPFORMELEMENTID_TO","pic":"ZZZZZ9"},{"av":"AV31TFDynamicFormTranslationTrnName","fld":"vTFDYNAMICFORMTRANSLATIONTRNNAME"},{"av":"AV32TFDynamicFormTranslationTrnName_Sel","fld":"vTFDYNAMICFORMTRANSLATIONTRNNAME_SEL"},{"av":"AV33TFDynamicFormTranslationAttributeName","fld":"vTFDYNAMICFORMTRANSLATIONATTRIBUTENAME"},{"av":"AV34TFDynamicFormTranslationAttributeName_Sel","fld":"vTFDYNAMICFORMTRANSLATIONATTRIBUTENAME_SEL"},{"av":"AV35TFDynamicFormTranslationEnglish","fld":"vTFDYNAMICFORMTRANSLATIONENGLISH"},{"av":"AV36TFDynamicFormTranslationEnglish_Sel","fld":"vTFDYNAMICFORMTRANSLATIONENGLISH_SEL"},{"av":"AV37TFDynamicFormTranslationDutch","fld":"vTFDYNAMICFORMTRANSLATIONDUTCH"},{"av":"AV38TFDynamicFormTranslationDutch_Sel","fld":"vTFDYNAMICFORMTRANSLATIONDUTCH_SEL"},{"av":"AV48IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV49IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV50IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV46IsAuthorized_DynamicFormTranslationWWpFormId","fld":"vISAUTHORIZED_DYNAMICFORMTRANSLATIONWWPFORMID","hsh":true},{"av":"AV51IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"A585DynamicFormTranslationId","fld":"DYNAMICFORMTRANSLATIONID","hsh":true}]""");
         setEventMetadata("'DOINSERT'",""","oparms":[{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtDynamicFormTranslationId_Visible","ctrl":"DYNAMICFORMTRANSLATIONID","prop":"Visible"},{"av":"edtDynamicFormTranslationWWpFormI_Visible","ctrl":"DYNAMICFORMTRANSLATIONWWPFORMI","prop":"Visible"},{"av":"edtDynamicFormTranslationWWPFormV_Visible","ctrl":"DYNAMICFORMTRANSLATIONWWPFORMV","prop":"Visible"},{"av":"edtDynamicFormTranslationWWPFormE_Visible","ctrl":"DYNAMICFORMTRANSLATIONWWPFORME","prop":"Visible"},{"av":"edtDynamicFormTranslationTrnName_Visible","ctrl":"DYNAMICFORMTRANSLATIONTRNNAME","prop":"Visible"},{"av":"edtDynamicFormTranslationAttribut_Visible","ctrl":"DYNAMICFORMTRANSLATIONATTRIBUT","prop":"Visible"},{"av":"edtDynamicFormTranslationEnglish_Visible","ctrl":"DYNAMICFORMTRANSLATIONENGLISH","prop":"Visible"},{"av":"edtDynamicFormTranslationDutch_Visible","ctrl":"DYNAMICFORMTRANSLATIONDUTCH","prop":"Visible"},{"av":"AV43GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV44GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV45GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV48IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV49IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV50IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV51IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV22ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","""{"handler":"E14BD2","iparms":[]""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
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
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV16FilterFullText = "";
         AV19ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV52Pgmname = "";
         AV31TFDynamicFormTranslationTrnName = "";
         AV32TFDynamicFormTranslationTrnName_Sel = "";
         AV33TFDynamicFormTranslationAttributeName = "";
         AV34TFDynamicFormTranslationAttributeName_Sel = "";
         AV35TFDynamicFormTranslationEnglish = "";
         AV36TFDynamicFormTranslationEnglish_Sel = "";
         AV37TFDynamicFormTranslationDutch = "";
         AV38TFDynamicFormTranslationDutch_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV22ManageFiltersData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV45GridAppliedFilters = "";
         AV39DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
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
         A585DynamicFormTranslationId = Guid.Empty;
         A589DynamicFormTranslationTrnName = "";
         A590DynamicFormTranslationAttribut = "";
         A591DynamicFormTranslationEnglish = "";
         A592DynamicFormTranslationDutch = "";
         lV53Trn_dynamicformtranslationwwds_1_filterfulltext = "";
         lV60Trn_dynamicformtranslationwwds_8_tfdynamicformtranslationtrnname = "";
         lV62Trn_dynamicformtranslationwwds_10_tfdynamicformtranslationattributename = "";
         lV64Trn_dynamicformtranslationwwds_12_tfdynamicformtranslationenglish = "";
         lV66Trn_dynamicformtranslationwwds_14_tfdynamicformtranslationdutch = "";
         AV53Trn_dynamicformtranslationwwds_1_filterfulltext = "";
         AV61Trn_dynamicformtranslationwwds_9_tfdynamicformtranslationtrnname_sel = "";
         AV60Trn_dynamicformtranslationwwds_8_tfdynamicformtranslationtrnname = "";
         AV63Trn_dynamicformtranslationwwds_11_tfdynamicformtranslationattributename_sel = "";
         AV62Trn_dynamicformtranslationwwds_10_tfdynamicformtranslationattributename = "";
         AV65Trn_dynamicformtranslationwwds_13_tfdynamicformtranslationenglish_sel = "";
         AV64Trn_dynamicformtranslationwwds_12_tfdynamicformtranslationenglish = "";
         AV67Trn_dynamicformtranslationwwds_15_tfdynamicformtranslationdutch_sel = "";
         AV66Trn_dynamicformtranslationwwds_14_tfdynamicformtranslationdutch = "";
         H00BD2_A592DynamicFormTranslationDutch = new string[] {""} ;
         H00BD2_A591DynamicFormTranslationEnglish = new string[] {""} ;
         H00BD2_A590DynamicFormTranslationAttribut = new string[] {""} ;
         H00BD2_A589DynamicFormTranslationTrnName = new string[] {""} ;
         H00BD2_A588DynamicFormTranslationWWPFormE = new int[1] ;
         H00BD2_A587DynamicFormTranslationWWPFormV = new int[1] ;
         H00BD2_A586DynamicFormTranslationWWpFormI = new int[1] ;
         H00BD2_A585DynamicFormTranslationId = new Guid[] {Guid.Empty} ;
         H00BD3_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         AV40GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV41GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV21Session = context.GetSession();
         AV17ColumnsSelectorXML = "";
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV23ManageFiltersXml = "";
         AV18UserCustomValue = "";
         AV20ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
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
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_dynamicformtranslationww__default(),
            new Object[][] {
                new Object[] {
               H00BD2_A592DynamicFormTranslationDutch, H00BD2_A591DynamicFormTranslationEnglish, H00BD2_A590DynamicFormTranslationAttribut, H00BD2_A589DynamicFormTranslationTrnName, H00BD2_A588DynamicFormTranslationWWPFormE, H00BD2_A587DynamicFormTranslationWWPFormV, H00BD2_A586DynamicFormTranslationWWpFormI, H00BD2_A585DynamicFormTranslationId
               }
               , new Object[] {
               H00BD3_AGRID_nRecordCount
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV52Pgmname = "Trn_DynamicFormTranslationWW";
         /* GeneXus formulas. */
         AV52Pgmname = "Trn_DynamicFormTranslationWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV24ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV47ActionGroup ;
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
      private int AV25TFDynamicFormTranslationWWpFormId ;
      private int AV26TFDynamicFormTranslationWWpFormId_To ;
      private int AV27TFDynamicFormTranslationWWPFormVersionNumber ;
      private int AV28TFDynamicFormTranslationWWPFormVersionNumber_To ;
      private int AV29TFDynamicFormTranslationWWPFormElementId ;
      private int AV30TFDynamicFormTranslationWWPFormElementId_To ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int bttBtnsubscriptions_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int A586DynamicFormTranslationWWpFormI ;
      private int A587DynamicFormTranslationWWPFormV ;
      private int A588DynamicFormTranslationWWPFormE ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV54Trn_dynamicformtranslationwwds_2_tfdynamicformtranslationwwpformid ;
      private int AV55Trn_dynamicformtranslationwwds_3_tfdynamicformtranslationwwpformid_to ;
      private int AV56Trn_dynamicformtranslationwwds_4_tfdynamicformtranslationwwpformversionnumber ;
      private int AV57Trn_dynamicformtranslationwwds_5_tfdynamicformtranslationwwpformversionnumber_to ;
      private int AV58Trn_dynamicformtranslationwwds_6_tfdynamicformtranslationwwpformelementid ;
      private int AV59Trn_dynamicformtranslationwwds_7_tfdynamicformtranslationwwpformelementid_to ;
      private int edtDynamicFormTranslationId_Enabled ;
      private int edtDynamicFormTranslationWWpFormI_Enabled ;
      private int edtDynamicFormTranslationWWPFormV_Enabled ;
      private int edtDynamicFormTranslationWWPFormE_Enabled ;
      private int edtDynamicFormTranslationTrnName_Enabled ;
      private int edtDynamicFormTranslationAttribut_Enabled ;
      private int edtDynamicFormTranslationEnglish_Enabled ;
      private int edtDynamicFormTranslationDutch_Enabled ;
      private int edtDynamicFormTranslationId_Visible ;
      private int edtDynamicFormTranslationWWpFormI_Visible ;
      private int edtDynamicFormTranslationWWPFormV_Visible ;
      private int edtDynamicFormTranslationWWPFormE_Visible ;
      private int edtDynamicFormTranslationTrnName_Visible ;
      private int edtDynamicFormTranslationAttribut_Visible ;
      private int edtDynamicFormTranslationEnglish_Visible ;
      private int edtDynamicFormTranslationDutch_Visible ;
      private int AV42PageToGo ;
      private int AV68GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV43GridCurrentPage ;
      private long AV44GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_39_idx="0001" ;
      private string AV52Pgmname ;
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
      private string Ddo_grid_Format ;
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
      private string edtDynamicFormTranslationId_Internalname ;
      private string edtDynamicFormTranslationWWpFormI_Internalname ;
      private string edtDynamicFormTranslationWWPFormV_Internalname ;
      private string edtDynamicFormTranslationWWPFormE_Internalname ;
      private string edtDynamicFormTranslationTrnName_Internalname ;
      private string edtDynamicFormTranslationAttribut_Internalname ;
      private string edtDynamicFormTranslationEnglish_Internalname ;
      private string edtDynamicFormTranslationDutch_Internalname ;
      private string cmbavActiongroup_Internalname ;
      private string cmbavActiongroup_Class ;
      private string edtDynamicFormTranslationWWpFormI_Link ;
      private string GXEncryptionTmp ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char3 ;
      private string sGXsfl_39_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtDynamicFormTranslationId_Jsonclick ;
      private string edtDynamicFormTranslationWWpFormI_Jsonclick ;
      private string edtDynamicFormTranslationWWPFormV_Jsonclick ;
      private string edtDynamicFormTranslationWWPFormE_Jsonclick ;
      private string edtDynamicFormTranslationTrnName_Jsonclick ;
      private string edtDynamicFormTranslationAttribut_Jsonclick ;
      private string edtDynamicFormTranslationEnglish_Jsonclick ;
      private string edtDynamicFormTranslationDutch_Jsonclick ;
      private string GXCCtl ;
      private string cmbavActiongroup_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV48IsAuthorized_Display ;
      private bool AV49IsAuthorized_Update ;
      private bool AV50IsAuthorized_Delete ;
      private bool AV46IsAuthorized_DynamicFormTranslationWWpFormId ;
      private bool AV51IsAuthorized_Insert ;
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
      private string A591DynamicFormTranslationEnglish ;
      private string A592DynamicFormTranslationDutch ;
      private string AV17ColumnsSelectorXML ;
      private string AV23ManageFiltersXml ;
      private string AV18UserCustomValue ;
      private string AV16FilterFullText ;
      private string AV31TFDynamicFormTranslationTrnName ;
      private string AV32TFDynamicFormTranslationTrnName_Sel ;
      private string AV33TFDynamicFormTranslationAttributeName ;
      private string AV34TFDynamicFormTranslationAttributeName_Sel ;
      private string AV35TFDynamicFormTranslationEnglish ;
      private string AV36TFDynamicFormTranslationEnglish_Sel ;
      private string AV37TFDynamicFormTranslationDutch ;
      private string AV38TFDynamicFormTranslationDutch_Sel ;
      private string AV45GridAppliedFilters ;
      private string A589DynamicFormTranslationTrnName ;
      private string A590DynamicFormTranslationAttribut ;
      private string lV53Trn_dynamicformtranslationwwds_1_filterfulltext ;
      private string lV60Trn_dynamicformtranslationwwds_8_tfdynamicformtranslationtrnname ;
      private string lV62Trn_dynamicformtranslationwwds_10_tfdynamicformtranslationattributename ;
      private string lV64Trn_dynamicformtranslationwwds_12_tfdynamicformtranslationenglish ;
      private string lV66Trn_dynamicformtranslationwwds_14_tfdynamicformtranslationdutch ;
      private string AV53Trn_dynamicformtranslationwwds_1_filterfulltext ;
      private string AV61Trn_dynamicformtranslationwwds_9_tfdynamicformtranslationtrnname_sel ;
      private string AV60Trn_dynamicformtranslationwwds_8_tfdynamicformtranslationtrnname ;
      private string AV63Trn_dynamicformtranslationwwds_11_tfdynamicformtranslationattributename_sel ;
      private string AV62Trn_dynamicformtranslationwwds_10_tfdynamicformtranslationattributename ;
      private string AV65Trn_dynamicformtranslationwwds_13_tfdynamicformtranslationenglish_sel ;
      private string AV64Trn_dynamicformtranslationwwds_12_tfdynamicformtranslationenglish ;
      private string AV67Trn_dynamicformtranslationwwds_15_tfdynamicformtranslationdutch_sel ;
      private string AV66Trn_dynamicformtranslationwwds_14_tfdynamicformtranslationdutch ;
      private Guid A585DynamicFormTranslationId ;
      private IGxSession AV21Session ;
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
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV19ColumnsSelector ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV22ManageFiltersData ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV39DDO_TitleSettingsIcons ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV11GridState ;
      private IDataStoreProvider pr_default ;
      private string[] H00BD2_A592DynamicFormTranslationDutch ;
      private string[] H00BD2_A591DynamicFormTranslationEnglish ;
      private string[] H00BD2_A590DynamicFormTranslationAttribut ;
      private string[] H00BD2_A589DynamicFormTranslationTrnName ;
      private int[] H00BD2_A588DynamicFormTranslationWWPFormE ;
      private int[] H00BD2_A587DynamicFormTranslationWWPFormV ;
      private int[] H00BD2_A586DynamicFormTranslationWWpFormI ;
      private Guid[] H00BD2_A585DynamicFormTranslationId ;
      private long[] H00BD3_AGRID_nRecordCount ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV40GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV41GAMErrors ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV20ColumnsSelectorAux ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class trn_dynamicformtranslationww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00BD2( IGxContext context ,
                                             string AV53Trn_dynamicformtranslationwwds_1_filterfulltext ,
                                             int AV54Trn_dynamicformtranslationwwds_2_tfdynamicformtranslationwwpformid ,
                                             int AV55Trn_dynamicformtranslationwwds_3_tfdynamicformtranslationwwpformid_to ,
                                             int AV56Trn_dynamicformtranslationwwds_4_tfdynamicformtranslationwwpformversionnumber ,
                                             int AV57Trn_dynamicformtranslationwwds_5_tfdynamicformtranslationwwpformversionnumber_to ,
                                             int AV58Trn_dynamicformtranslationwwds_6_tfdynamicformtranslationwwpformelementid ,
                                             int AV59Trn_dynamicformtranslationwwds_7_tfdynamicformtranslationwwpformelementid_to ,
                                             string AV61Trn_dynamicformtranslationwwds_9_tfdynamicformtranslationtrnname_sel ,
                                             string AV60Trn_dynamicformtranslationwwds_8_tfdynamicformtranslationtrnname ,
                                             string AV63Trn_dynamicformtranslationwwds_11_tfdynamicformtranslationattributename_sel ,
                                             string AV62Trn_dynamicformtranslationwwds_10_tfdynamicformtranslationattributename ,
                                             string AV65Trn_dynamicformtranslationwwds_13_tfdynamicformtranslationenglish_sel ,
                                             string AV64Trn_dynamicformtranslationwwds_12_tfdynamicformtranslationenglish ,
                                             string AV67Trn_dynamicformtranslationwwds_15_tfdynamicformtranslationdutch_sel ,
                                             string AV66Trn_dynamicformtranslationwwds_14_tfdynamicformtranslationdutch ,
                                             int A586DynamicFormTranslationWWpFormI ,
                                             int A587DynamicFormTranslationWWPFormV ,
                                             int A588DynamicFormTranslationWWPFormE ,
                                             string A589DynamicFormTranslationTrnName ,
                                             string A590DynamicFormTranslationAttribut ,
                                             string A591DynamicFormTranslationEnglish ,
                                             string A592DynamicFormTranslationDutch ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[24];
         Object[] GXv_Object9 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " DynamicFormTranslationDutch, DynamicFormTranslationEnglish, DynamicFormTranslationAttribut, DynamicFormTranslationTrnName, DynamicFormTranslationWWPFormE, DynamicFormTranslationWWPFormV, DynamicFormTranslationWWpFormI, DynamicFormTranslationId";
         sFromString = " FROM Trn_DynamicFormTranslation";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_dynamicformtranslationwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(DynamicFormTranslationWWpFormI,'999999'), 2) like '%' || :lV53Trn_dynamicformtranslationwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(DynamicFormTranslationWWPFormV,'999999'), 2) like '%' || :lV53Trn_dynamicformtranslationwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(DynamicFormTranslationWWPFormE,'999999'), 2) like '%' || :lV53Trn_dynamicformtranslationwwds_1_filterfulltext) or ( LOWER(DynamicFormTranslationTrnName) like '%' || LOWER(:lV53Trn_dynamicformtranslationwwds_1_filterfulltext)) or ( LOWER(DynamicFormTranslationAttribut) like '%' || LOWER(:lV53Trn_dynamicformtranslationwwds_1_filterfulltext)) or ( LOWER(DynamicFormTranslationEnglish) like '%' || LOWER(:lV53Trn_dynamicformtranslationwwds_1_filterfulltext)) or ( LOWER(DynamicFormTranslationDutch) like '%' || LOWER(:lV53Trn_dynamicformtranslationwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int8[0] = 1;
            GXv_int8[1] = 1;
            GXv_int8[2] = 1;
            GXv_int8[3] = 1;
            GXv_int8[4] = 1;
            GXv_int8[5] = 1;
            GXv_int8[6] = 1;
         }
         if ( ! (0==AV54Trn_dynamicformtranslationwwds_2_tfdynamicformtranslationwwpformid) )
         {
            AddWhere(sWhereString, "(DynamicFormTranslationWWpFormI >= :AV54Trn_dynamicformtranslationwwds_2_tfdynamicformtranslationww)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( ! (0==AV55Trn_dynamicformtranslationwwds_3_tfdynamicformtranslationwwpformid_to) )
         {
            AddWhere(sWhereString, "(DynamicFormTranslationWWpFormI <= :AV55Trn_dynamicformtranslationwwds_3_tfdynamicformtranslationww)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( ! (0==AV56Trn_dynamicformtranslationwwds_4_tfdynamicformtranslationwwpformversionnumber) )
         {
            AddWhere(sWhereString, "(DynamicFormTranslationWWPFormV >= :AV56Trn_dynamicformtranslationwwds_4_tfdynamicformtranslationww)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( ! (0==AV57Trn_dynamicformtranslationwwds_5_tfdynamicformtranslationwwpformversionnumber_to) )
         {
            AddWhere(sWhereString, "(DynamicFormTranslationWWPFormV <= :AV57Trn_dynamicformtranslationwwds_5_tfdynamicformtranslationww)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( ! (0==AV58Trn_dynamicformtranslationwwds_6_tfdynamicformtranslationwwpformelementid) )
         {
            AddWhere(sWhereString, "(DynamicFormTranslationWWPFormE >= :AV58Trn_dynamicformtranslationwwds_6_tfdynamicformtranslationww)");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( ! (0==AV59Trn_dynamicformtranslationwwds_7_tfdynamicformtranslationwwpformelementid_to) )
         {
            AddWhere(sWhereString, "(DynamicFormTranslationWWPFormE <= :AV59Trn_dynamicformtranslationwwds_7_tfdynamicformtranslationww)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_dynamicformtranslationwwds_9_tfdynamicformtranslationtrnname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_dynamicformtranslationwwds_8_tfdynamicformtranslationtrnname)) ) )
         {
            AddWhere(sWhereString, "(DynamicFormTranslationTrnName like :lV60Trn_dynamicformtranslationwwds_8_tfdynamicformtranslationtr)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_dynamicformtranslationwwds_9_tfdynamicformtranslationtrnname_sel)) && ! ( StringUtil.StrCmp(AV61Trn_dynamicformtranslationwwds_9_tfdynamicformtranslationtrnname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DynamicFormTranslationTrnName = ( :AV61Trn_dynamicformtranslationwwds_9_tfdynamicformtranslationtr))");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( StringUtil.StrCmp(AV61Trn_dynamicformtranslationwwds_9_tfdynamicformtranslationtrnname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DynamicFormTranslationTrnName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_dynamicformtranslationwwds_11_tfdynamicformtranslationattributename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_dynamicformtranslationwwds_10_tfdynamicformtranslationattributename)) ) )
         {
            AddWhere(sWhereString, "(DynamicFormTranslationAttribut like :lV62Trn_dynamicformtranslationwwds_10_tfdynamicformtranslationa)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_dynamicformtranslationwwds_11_tfdynamicformtranslationattributename_sel)) && ! ( StringUtil.StrCmp(AV63Trn_dynamicformtranslationwwds_11_tfdynamicformtranslationattributename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DynamicFormTranslationAttribut = ( :AV63Trn_dynamicformtranslationwwds_11_tfdynamicformtranslationa))");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( StringUtil.StrCmp(AV63Trn_dynamicformtranslationwwds_11_tfdynamicformtranslationattributename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DynamicFormTranslationAttribut))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_dynamicformtranslationwwds_13_tfdynamicformtranslationenglish_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_dynamicformtranslationwwds_12_tfdynamicformtranslationenglish)) ) )
         {
            AddWhere(sWhereString, "(DynamicFormTranslationEnglish like :lV64Trn_dynamicformtranslationwwds_12_tfdynamicformtranslatione)");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_dynamicformtranslationwwds_13_tfdynamicformtranslationenglish_sel)) && ! ( StringUtil.StrCmp(AV65Trn_dynamicformtranslationwwds_13_tfdynamicformtranslationenglish_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DynamicFormTranslationEnglish = ( :AV65Trn_dynamicformtranslationwwds_13_tfdynamicformtranslatione))");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_dynamicformtranslationwwds_13_tfdynamicformtranslationenglish_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DynamicFormTranslationEnglish))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_dynamicformtranslationwwds_15_tfdynamicformtranslationdutch_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_dynamicformtranslationwwds_14_tfdynamicformtranslationdutch)) ) )
         {
            AddWhere(sWhereString, "(DynamicFormTranslationDutch like :lV66Trn_dynamicformtranslationwwds_14_tfdynamicformtranslationd)");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_dynamicformtranslationwwds_15_tfdynamicformtranslationdutch_sel)) && ! ( StringUtil.StrCmp(AV67Trn_dynamicformtranslationwwds_15_tfdynamicformtranslationdutch_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DynamicFormTranslationDutch = ( :AV67Trn_dynamicformtranslationwwds_15_tfdynamicformtranslationd))");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( StringUtil.StrCmp(AV67Trn_dynamicformtranslationwwds_15_tfdynamicformtranslationdutch_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DynamicFormTranslationDutch))=0))");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY DynamicFormTranslationWWpFormI, DynamicFormTranslationId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY DynamicFormTranslationWWpFormI DESC, DynamicFormTranslationId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY DynamicFormTranslationId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY DynamicFormTranslationId DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY DynamicFormTranslationWWPFormV, DynamicFormTranslationId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY DynamicFormTranslationWWPFormV DESC, DynamicFormTranslationId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY DynamicFormTranslationWWPFormE, DynamicFormTranslationId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY DynamicFormTranslationWWPFormE DESC, DynamicFormTranslationId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY DynamicFormTranslationTrnName, DynamicFormTranslationId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY DynamicFormTranslationTrnName DESC, DynamicFormTranslationId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY DynamicFormTranslationAttribut, DynamicFormTranslationId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY DynamicFormTranslationAttribut DESC, DynamicFormTranslationId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY DynamicFormTranslationEnglish, DynamicFormTranslationId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY DynamicFormTranslationEnglish DESC, DynamicFormTranslationId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY DynamicFormTranslationDutch, DynamicFormTranslationId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY DynamicFormTranslationDutch DESC, DynamicFormTranslationId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY DynamicFormTranslationId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_H00BD3( IGxContext context ,
                                             string AV53Trn_dynamicformtranslationwwds_1_filterfulltext ,
                                             int AV54Trn_dynamicformtranslationwwds_2_tfdynamicformtranslationwwpformid ,
                                             int AV55Trn_dynamicformtranslationwwds_3_tfdynamicformtranslationwwpformid_to ,
                                             int AV56Trn_dynamicformtranslationwwds_4_tfdynamicformtranslationwwpformversionnumber ,
                                             int AV57Trn_dynamicformtranslationwwds_5_tfdynamicformtranslationwwpformversionnumber_to ,
                                             int AV58Trn_dynamicformtranslationwwds_6_tfdynamicformtranslationwwpformelementid ,
                                             int AV59Trn_dynamicformtranslationwwds_7_tfdynamicformtranslationwwpformelementid_to ,
                                             string AV61Trn_dynamicformtranslationwwds_9_tfdynamicformtranslationtrnname_sel ,
                                             string AV60Trn_dynamicformtranslationwwds_8_tfdynamicformtranslationtrnname ,
                                             string AV63Trn_dynamicformtranslationwwds_11_tfdynamicformtranslationattributename_sel ,
                                             string AV62Trn_dynamicformtranslationwwds_10_tfdynamicformtranslationattributename ,
                                             string AV65Trn_dynamicformtranslationwwds_13_tfdynamicformtranslationenglish_sel ,
                                             string AV64Trn_dynamicformtranslationwwds_12_tfdynamicformtranslationenglish ,
                                             string AV67Trn_dynamicformtranslationwwds_15_tfdynamicformtranslationdutch_sel ,
                                             string AV66Trn_dynamicformtranslationwwds_14_tfdynamicformtranslationdutch ,
                                             int A586DynamicFormTranslationWWpFormI ,
                                             int A587DynamicFormTranslationWWPFormV ,
                                             int A588DynamicFormTranslationWWPFormE ,
                                             string A589DynamicFormTranslationTrnName ,
                                             string A590DynamicFormTranslationAttribut ,
                                             string A591DynamicFormTranslationEnglish ,
                                             string A592DynamicFormTranslationDutch ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[21];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM Trn_DynamicFormTranslation";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_dynamicformtranslationwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(DynamicFormTranslationWWpFormI,'999999'), 2) like '%' || :lV53Trn_dynamicformtranslationwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(DynamicFormTranslationWWPFormV,'999999'), 2) like '%' || :lV53Trn_dynamicformtranslationwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(DynamicFormTranslationWWPFormE,'999999'), 2) like '%' || :lV53Trn_dynamicformtranslationwwds_1_filterfulltext) or ( LOWER(DynamicFormTranslationTrnName) like '%' || LOWER(:lV53Trn_dynamicformtranslationwwds_1_filterfulltext)) or ( LOWER(DynamicFormTranslationAttribut) like '%' || LOWER(:lV53Trn_dynamicformtranslationwwds_1_filterfulltext)) or ( LOWER(DynamicFormTranslationEnglish) like '%' || LOWER(:lV53Trn_dynamicformtranslationwwds_1_filterfulltext)) or ( LOWER(DynamicFormTranslationDutch) like '%' || LOWER(:lV53Trn_dynamicformtranslationwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int10[0] = 1;
            GXv_int10[1] = 1;
            GXv_int10[2] = 1;
            GXv_int10[3] = 1;
            GXv_int10[4] = 1;
            GXv_int10[5] = 1;
            GXv_int10[6] = 1;
         }
         if ( ! (0==AV54Trn_dynamicformtranslationwwds_2_tfdynamicformtranslationwwpformid) )
         {
            AddWhere(sWhereString, "(DynamicFormTranslationWWpFormI >= :AV54Trn_dynamicformtranslationwwds_2_tfdynamicformtranslationww)");
         }
         else
         {
            GXv_int10[7] = 1;
         }
         if ( ! (0==AV55Trn_dynamicformtranslationwwds_3_tfdynamicformtranslationwwpformid_to) )
         {
            AddWhere(sWhereString, "(DynamicFormTranslationWWpFormI <= :AV55Trn_dynamicformtranslationwwds_3_tfdynamicformtranslationww)");
         }
         else
         {
            GXv_int10[8] = 1;
         }
         if ( ! (0==AV56Trn_dynamicformtranslationwwds_4_tfdynamicformtranslationwwpformversionnumber) )
         {
            AddWhere(sWhereString, "(DynamicFormTranslationWWPFormV >= :AV56Trn_dynamicformtranslationwwds_4_tfdynamicformtranslationww)");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( ! (0==AV57Trn_dynamicformtranslationwwds_5_tfdynamicformtranslationwwpformversionnumber_to) )
         {
            AddWhere(sWhereString, "(DynamicFormTranslationWWPFormV <= :AV57Trn_dynamicformtranslationwwds_5_tfdynamicformtranslationww)");
         }
         else
         {
            GXv_int10[10] = 1;
         }
         if ( ! (0==AV58Trn_dynamicformtranslationwwds_6_tfdynamicformtranslationwwpformelementid) )
         {
            AddWhere(sWhereString, "(DynamicFormTranslationWWPFormE >= :AV58Trn_dynamicformtranslationwwds_6_tfdynamicformtranslationww)");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( ! (0==AV59Trn_dynamicformtranslationwwds_7_tfdynamicformtranslationwwpformelementid_to) )
         {
            AddWhere(sWhereString, "(DynamicFormTranslationWWPFormE <= :AV59Trn_dynamicformtranslationwwds_7_tfdynamicformtranslationww)");
         }
         else
         {
            GXv_int10[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_dynamicformtranslationwwds_9_tfdynamicformtranslationtrnname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_dynamicformtranslationwwds_8_tfdynamicformtranslationtrnname)) ) )
         {
            AddWhere(sWhereString, "(DynamicFormTranslationTrnName like :lV60Trn_dynamicformtranslationwwds_8_tfdynamicformtranslationtr)");
         }
         else
         {
            GXv_int10[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_dynamicformtranslationwwds_9_tfdynamicformtranslationtrnname_sel)) && ! ( StringUtil.StrCmp(AV61Trn_dynamicformtranslationwwds_9_tfdynamicformtranslationtrnname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DynamicFormTranslationTrnName = ( :AV61Trn_dynamicformtranslationwwds_9_tfdynamicformtranslationtr))");
         }
         else
         {
            GXv_int10[14] = 1;
         }
         if ( StringUtil.StrCmp(AV61Trn_dynamicformtranslationwwds_9_tfdynamicformtranslationtrnname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DynamicFormTranslationTrnName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_dynamicformtranslationwwds_11_tfdynamicformtranslationattributename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_dynamicformtranslationwwds_10_tfdynamicformtranslationattributename)) ) )
         {
            AddWhere(sWhereString, "(DynamicFormTranslationAttribut like :lV62Trn_dynamicformtranslationwwds_10_tfdynamicformtranslationa)");
         }
         else
         {
            GXv_int10[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_dynamicformtranslationwwds_11_tfdynamicformtranslationattributename_sel)) && ! ( StringUtil.StrCmp(AV63Trn_dynamicformtranslationwwds_11_tfdynamicformtranslationattributename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DynamicFormTranslationAttribut = ( :AV63Trn_dynamicformtranslationwwds_11_tfdynamicformtranslationa))");
         }
         else
         {
            GXv_int10[16] = 1;
         }
         if ( StringUtil.StrCmp(AV63Trn_dynamicformtranslationwwds_11_tfdynamicformtranslationattributename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DynamicFormTranslationAttribut))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_dynamicformtranslationwwds_13_tfdynamicformtranslationenglish_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_dynamicformtranslationwwds_12_tfdynamicformtranslationenglish)) ) )
         {
            AddWhere(sWhereString, "(DynamicFormTranslationEnglish like :lV64Trn_dynamicformtranslationwwds_12_tfdynamicformtranslatione)");
         }
         else
         {
            GXv_int10[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_dynamicformtranslationwwds_13_tfdynamicformtranslationenglish_sel)) && ! ( StringUtil.StrCmp(AV65Trn_dynamicformtranslationwwds_13_tfdynamicformtranslationenglish_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DynamicFormTranslationEnglish = ( :AV65Trn_dynamicformtranslationwwds_13_tfdynamicformtranslatione))");
         }
         else
         {
            GXv_int10[18] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_dynamicformtranslationwwds_13_tfdynamicformtranslationenglish_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DynamicFormTranslationEnglish))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_dynamicformtranslationwwds_15_tfdynamicformtranslationdutch_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_dynamicformtranslationwwds_14_tfdynamicformtranslationdutch)) ) )
         {
            AddWhere(sWhereString, "(DynamicFormTranslationDutch like :lV66Trn_dynamicformtranslationwwds_14_tfdynamicformtranslationd)");
         }
         else
         {
            GXv_int10[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_dynamicformtranslationwwds_15_tfdynamicformtranslationdutch_sel)) && ! ( StringUtil.StrCmp(AV67Trn_dynamicformtranslationwwds_15_tfdynamicformtranslationdutch_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DynamicFormTranslationDutch = ( :AV67Trn_dynamicformtranslationwwds_15_tfdynamicformtranslationd))");
         }
         else
         {
            GXv_int10[20] = 1;
         }
         if ( StringUtil.StrCmp(AV67Trn_dynamicformtranslationwwds_15_tfdynamicformtranslationdutch_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DynamicFormTranslationDutch))=0))");
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
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
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
                     return conditional_H00BD2(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (short)dynConstraints[22] , (bool)dynConstraints[23] );
               case 1 :
                     return conditional_H00BD3(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (short)dynConstraints[22] , (bool)dynConstraints[23] );
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
          Object[] prmH00BD2;
          prmH00BD2 = new Object[] {
          new ParDef("lV53Trn_dynamicformtranslationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Trn_dynamicformtranslationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Trn_dynamicformtranslationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Trn_dynamicformtranslationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Trn_dynamicformtranslationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Trn_dynamicformtranslationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Trn_dynamicformtranslationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV54Trn_dynamicformtranslationwwds_2_tfdynamicformtranslationww",GXType.Int32,6,0) ,
          new ParDef("AV55Trn_dynamicformtranslationwwds_3_tfdynamicformtranslationww",GXType.Int32,6,0) ,
          new ParDef("AV56Trn_dynamicformtranslationwwds_4_tfdynamicformtranslationww",GXType.Int32,6,0) ,
          new ParDef("AV57Trn_dynamicformtranslationwwds_5_tfdynamicformtranslationww",GXType.Int32,6,0) ,
          new ParDef("AV58Trn_dynamicformtranslationwwds_6_tfdynamicformtranslationww",GXType.Int32,6,0) ,
          new ParDef("AV59Trn_dynamicformtranslationwwds_7_tfdynamicformtranslationww",GXType.Int32,6,0) ,
          new ParDef("lV60Trn_dynamicformtranslationwwds_8_tfdynamicformtranslationtr",GXType.VarChar,400,0) ,
          new ParDef("AV61Trn_dynamicformtranslationwwds_9_tfdynamicformtranslationtr",GXType.VarChar,400,0) ,
          new ParDef("lV62Trn_dynamicformtranslationwwds_10_tfdynamicformtranslationa",GXType.VarChar,40,0) ,
          new ParDef("AV63Trn_dynamicformtranslationwwds_11_tfdynamicformtranslationa",GXType.VarChar,40,0) ,
          new ParDef("lV64Trn_dynamicformtranslationwwds_12_tfdynamicformtranslatione",GXType.VarChar,200,0) ,
          new ParDef("AV65Trn_dynamicformtranslationwwds_13_tfdynamicformtranslatione",GXType.VarChar,200,0) ,
          new ParDef("lV66Trn_dynamicformtranslationwwds_14_tfdynamicformtranslationd",GXType.VarChar,200,0) ,
          new ParDef("AV67Trn_dynamicformtranslationwwds_15_tfdynamicformtranslationd",GXType.VarChar,200,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00BD3;
          prmH00BD3 = new Object[] {
          new ParDef("lV53Trn_dynamicformtranslationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Trn_dynamicformtranslationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Trn_dynamicformtranslationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Trn_dynamicformtranslationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Trn_dynamicformtranslationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Trn_dynamicformtranslationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Trn_dynamicformtranslationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV54Trn_dynamicformtranslationwwds_2_tfdynamicformtranslationww",GXType.Int32,6,0) ,
          new ParDef("AV55Trn_dynamicformtranslationwwds_3_tfdynamicformtranslationww",GXType.Int32,6,0) ,
          new ParDef("AV56Trn_dynamicformtranslationwwds_4_tfdynamicformtranslationww",GXType.Int32,6,0) ,
          new ParDef("AV57Trn_dynamicformtranslationwwds_5_tfdynamicformtranslationww",GXType.Int32,6,0) ,
          new ParDef("AV58Trn_dynamicformtranslationwwds_6_tfdynamicformtranslationww",GXType.Int32,6,0) ,
          new ParDef("AV59Trn_dynamicformtranslationwwds_7_tfdynamicformtranslationww",GXType.Int32,6,0) ,
          new ParDef("lV60Trn_dynamicformtranslationwwds_8_tfdynamicformtranslationtr",GXType.VarChar,400,0) ,
          new ParDef("AV61Trn_dynamicformtranslationwwds_9_tfdynamicformtranslationtr",GXType.VarChar,400,0) ,
          new ParDef("lV62Trn_dynamicformtranslationwwds_10_tfdynamicformtranslationa",GXType.VarChar,40,0) ,
          new ParDef("AV63Trn_dynamicformtranslationwwds_11_tfdynamicformtranslationa",GXType.VarChar,40,0) ,
          new ParDef("lV64Trn_dynamicformtranslationwwds_12_tfdynamicformtranslatione",GXType.VarChar,200,0) ,
          new ParDef("AV65Trn_dynamicformtranslationwwds_13_tfdynamicformtranslatione",GXType.VarChar,200,0) ,
          new ParDef("lV66Trn_dynamicformtranslationwwds_14_tfdynamicformtranslationd",GXType.VarChar,200,0) ,
          new ParDef("AV67Trn_dynamicformtranslationwwds_15_tfdynamicformtranslationd",GXType.VarChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00BD2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BD2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00BD3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BD3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((Guid[]) buf[7])[0] = rslt.getGuid(8);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
