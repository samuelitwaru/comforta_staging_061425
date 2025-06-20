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
   public class wp_organisationagbsuppliers : GXDataArea
   {
      public wp_organisationagbsuppliers( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_organisationagbsuppliers( IGxContext context )
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
         chkavIsselected = new GXCheckbox();
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
         AV20OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV21OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV22FilterFullText = GetPar( "FilterFullText");
         AV28ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV70ColumnsSelector);
         AV74Pgmname = GetPar( "Pgmname");
         A386PreferredAgbOrganisationId = StringUtil.StrToGuid( GetPar( "PreferredAgbOrganisationId"));
         AV64OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
         A381PreferredSupplierAgbId = StringUtil.StrToGuid( GetPar( "PreferredSupplierAgbId"));
         AV29TFSupplierAgbName = GetPar( "TFSupplierAgbName");
         AV62TFSupplierAgbNameOperator = (short)(Math.Round(NumberUtil.Val( GetPar( "TFSupplierAgbNameOperator"), "."), 18, MidpointRounding.ToEven));
         AV30TFSupplierAgbName_Sel = GetPar( "TFSupplierAgbName_Sel");
         AV31TFSupplierAgbTypeName = GetPar( "TFSupplierAgbTypeName");
         AV32TFSupplierAgbTypeName_Sel = GetPar( "TFSupplierAgbTypeName_Sel");
         AV33TFSupplierAgbContactName = GetPar( "TFSupplierAgbContactName");
         AV34TFSupplierAgbContactName_Sel = GetPar( "TFSupplierAgbContactName_Sel");
         AV35TFSupplierAgbPhone = GetPar( "TFSupplierAgbPhone");
         AV36TFSupplierAgbPhone_Sel = GetPar( "TFSupplierAgbPhone_Sel");
         AV37TFSupplierAgbEmail = GetPar( "TFSupplierAgbEmail");
         AV38TFSupplierAgbEmail_Sel = GetPar( "TFSupplierAgbEmail_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV57PreferredSuppliers);
         AV49IsAuthorized_Display = StringUtil.StrToBool( GetPar( "IsAuthorized_Display"));
         AV46IsAuthorized_SupplierAgbName = StringUtil.StrToBool( GetPar( "IsAuthorized_SupplierAgbName"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV20OrderedBy, AV21OrderedDsc, AV22FilterFullText, AV28ManageFiltersExecutionStep, AV70ColumnsSelector, AV74Pgmname, A386PreferredAgbOrganisationId, AV64OrganisationId, A381PreferredSupplierAgbId, AV29TFSupplierAgbName, AV62TFSupplierAgbNameOperator, AV30TFSupplierAgbName_Sel, AV31TFSupplierAgbTypeName, AV32TFSupplierAgbTypeName_Sel, AV33TFSupplierAgbContactName, AV34TFSupplierAgbContactName_Sel, AV35TFSupplierAgbPhone, AV36TFSupplierAgbPhone_Sel, AV37TFSupplierAgbEmail, AV38TFSupplierAgbEmail_Sel, AV57PreferredSuppliers, AV49IsAuthorized_Display, AV46IsAuthorized_SupplierAgbName) ;
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
            return "wp_organisationagbsuppliers_Execute" ;
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
         PA6J2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START6J2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_organisationagbsuppliers.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV74Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV74Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV64OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV64OrganisationId, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPREFERREDSUPPLIERS", AV57PreferredSuppliers);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPREFERREDSUPPLIERS", AV57PreferredSuppliers);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vPREFERREDSUPPLIERS", GetSecureSignedToken( "", AV57PreferredSuppliers, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV49IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV49IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_SUPPLIERAGBNAME", AV46IsAuthorized_SupplierAgbName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SUPPLIERAGBNAME", GetSecureSignedToken( "", AV46IsAuthorized_SupplierAgbName, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV21OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV22FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_37", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_37), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV26ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV26ManageFiltersData);
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV70ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV70ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV74Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV74Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "PREFERREDAGBORGANISATIONID", A386PreferredAgbOrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV64OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV64OrganisationId, context));
         GxWebStd.gx_hidden_field( context, "PREFERREDSUPPLIERAGBID", A381PreferredSupplierAgbId.ToString());
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERAGBNAME", AV29TFSupplierAgbName);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERAGBNAMEOPERATOR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV62TFSupplierAgbNameOperator), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERAGBNAME_SEL", AV30TFSupplierAgbName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERAGBTYPENAME", AV31TFSupplierAgbTypeName);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERAGBTYPENAME_SEL", AV32TFSupplierAgbTypeName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERAGBCONTACTNAME", AV33TFSupplierAgbContactName);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERAGBCONTACTNAME_SEL", AV34TFSupplierAgbContactName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERAGBPHONE", StringUtil.RTrim( AV35TFSupplierAgbPhone));
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERAGBPHONE_SEL", StringUtil.RTrim( AV36TFSupplierAgbPhone_Sel));
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERAGBEMAIL", AV37TFSupplierAgbEmail);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERAGBEMAIL_SEL", AV38TFSupplierAgbEmail_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV21OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPREFERREDSUPPLIERS", AV57PreferredSuppliers);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPREFERREDSUPPLIERS", AV57PreferredSuppliers);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vPREFERREDSUPPLIERS", GetSecureSignedToken( "", AV57PreferredSuppliers, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV49IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV49IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_SUPPLIERAGBNAME", AV46IsAuthorized_SupplierAgbName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SUPPLIERAGBNAME", GetSecureSignedToken( "", AV46IsAuthorized_SupplierAgbName, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV18GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV18GridState);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRN_PREFERREDAGBSUPPLIER", AV56Trn_PreferredAgbSupplier);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRN_PREFERREDAGBSUPPLIER", AV56Trn_PreferredAgbSupplier);
         }
         GxWebStd.gx_hidden_field( context, "PREFERREDAGBSUPPLIERID", A384PreferredAgbSupplierId.ToString());
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Fixedfilters", StringUtil.RTrim( Ddo_grid_Fixedfilters));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedfixedfilter", StringUtil.RTrim( Ddo_grid_Selectedfixedfilter));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumnfixedfilter", StringUtil.RTrim( Ddo_grid_Selectedcolumnfixedfilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumnfixedfilter", StringUtil.RTrim( Ddo_grid_Selectedcolumnfixedfilter));
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
            WE6J2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT6J2( ) ;
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
         return formatLink("wp_organisationagbsuppliers.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WP_OrganisationAGBSuppliers" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Agb Suppliers", "") ;
      }

      protected void WB6J0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_OrganisationAGBSuppliers.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, context.GetMessage( "WWP_Subscriptions_Tooltip", ""), "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_OrganisationAGBSuppliers.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV26ManageFiltersData);
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV22FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV22FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWPFullTextFilter", "start", true, "", "HLP_WP_OrganisationAGBSuppliers.htm");
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
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("FixedFilters", Ddo_grid_Fixedfilters);
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
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV70ColumnsSelector);
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
               GxWebStd.gx_hidden_field( context, "W0070"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0070"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_37_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0070"+"");
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

      protected void START6J2( )
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
         Form.Meta.addItem("description", context.GetMessage( " Agb Suppliers", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP6J0( ) ;
      }

      protected void WS6J2( )
      {
         START6J2( ) ;
         EVT6J2( ) ;
      }

      protected void EVT6J2( )
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
                              E116J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E126J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E136J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                              E146J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E156J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E166J2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VACTIONGROUP.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "VISSELECTED.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "VISSELECTED.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VACTIONGROUP.CLICK") == 0 ) )
                           {
                              nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
                              SubsflControlProps_372( ) ;
                              AV23isSelected = StringUtil.StrToBool( cgiGet( chkavIsselected_Internalname));
                              AssignAttri("", false, chkavIsselected_Internalname, AV23isSelected);
                              A49SupplierAgbId = StringUtil.StrToGuid( cgiGet( edtSupplierAgbId_Internalname));
                              A50SupplierAgbNumber = cgiGet( edtSupplierAgbNumber_Internalname);
                              A255SupplierAgbTypeId = StringUtil.StrToGuid( cgiGet( edtSupplierAgbTypeId_Internalname));
                              AV63SupplierAgbNameWithTags = cgiGet( edtavSupplieragbnamewithtags_Internalname);
                              AssignAttri("", false, edtavSupplieragbnamewithtags_Internalname, AV63SupplierAgbNameWithTags);
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
                              AV59SupplierStatus = cgiGet( edtavSupplierstatus_Internalname);
                              AssignAttri("", false, edtavSupplierstatus_Internalname, AV59SupplierStatus);
                              AV24SupplierAddress = cgiGet( edtavSupplieraddress_Internalname);
                              AssignAttri("", false, edtavSupplieraddress_Internalname, AV24SupplierAddress);
                              cmbavActiongroup.Name = cmbavActiongroup_Internalname;
                              cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
                              AV66ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV66ActionGroup), 4, 0));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E176J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E186J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E196J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VACTIONGROUP.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E206J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VISSELECTED.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E216J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV20OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV21OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV22FilterFullText) != 0 )
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
                        if ( nCmpId == 70 )
                        {
                           OldWwpaux_wc = cgiGet( "W0070");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0070", "", sEvt);
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

      protected void WE6J2( )
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

      protected void PA6J2( )
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
                                       short AV20OrderedBy ,
                                       bool AV21OrderedDsc ,
                                       string AV22FilterFullText ,
                                       short AV28ManageFiltersExecutionStep ,
                                       WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV70ColumnsSelector ,
                                       string AV74Pgmname ,
                                       Guid A386PreferredAgbOrganisationId ,
                                       Guid AV64OrganisationId ,
                                       Guid A381PreferredSupplierAgbId ,
                                       string AV29TFSupplierAgbName ,
                                       short AV62TFSupplierAgbNameOperator ,
                                       string AV30TFSupplierAgbName_Sel ,
                                       string AV31TFSupplierAgbTypeName ,
                                       string AV32TFSupplierAgbTypeName_Sel ,
                                       string AV33TFSupplierAgbContactName ,
                                       string AV34TFSupplierAgbContactName_Sel ,
                                       string AV35TFSupplierAgbPhone ,
                                       string AV36TFSupplierAgbPhone_Sel ,
                                       string AV37TFSupplierAgbEmail ,
                                       string AV38TFSupplierAgbEmail_Sel ,
                                       GxSimpleCollection<Guid> AV57PreferredSuppliers ,
                                       bool AV49IsAuthorized_Display ,
                                       bool AV46IsAuthorized_SupplierAgbName )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF6J2( ) ;
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
         RF6J2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV74Pgmname = "WP_OrganisationAGBSuppliers";
         edtavSupplieragbnamewithtags_Enabled = 0;
         edtavSupplierstatus_Enabled = 0;
         edtavSupplieraddress_Enabled = 0;
      }

      protected void RF6J2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 37;
         /* Execute user event: Refresh */
         E186J2 ();
         nGXsfl_37_idx = 1;
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         bGXsfl_37_Refreshing = true;
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
            SubsflControlProps_372( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV76Wp_organisationagbsuppliersds_1_filterfulltext ,
                                                 AV79Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel ,
                                                 AV77Wp_organisationagbsuppliersds_2_tfsupplieragbname ,
                                                 AV78Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator ,
                                                 AV81Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel ,
                                                 AV80Wp_organisationagbsuppliersds_5_tfsupplieragbtypename ,
                                                 AV83Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel ,
                                                 AV82Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname ,
                                                 AV85Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel ,
                                                 AV84Wp_organisationagbsuppliersds_9_tfsupplieragbphone ,
                                                 AV87Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel ,
                                                 AV86Wp_organisationagbsuppliersds_11_tfsupplieragbemail ,
                                                 A51SupplierAgbName ,
                                                 A256SupplierAgbTypeName ,
                                                 A55SupplierAgbContactName ,
                                                 A56SupplierAgbPhone ,
                                                 A57SupplierAgbEmail ,
                                                 AV23isSelected ,
                                                 AV20OrderedBy ,
                                                 AV21OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV76Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV76Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
            lV76Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV76Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
            lV76Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV76Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
            lV76Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV76Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
            lV76Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV76Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
            lV77Wp_organisationagbsuppliersds_2_tfsupplieragbname = StringUtil.Concat( StringUtil.RTrim( AV77Wp_organisationagbsuppliersds_2_tfsupplieragbname), "%", "");
            lV80Wp_organisationagbsuppliersds_5_tfsupplieragbtypename = StringUtil.Concat( StringUtil.RTrim( AV80Wp_organisationagbsuppliersds_5_tfsupplieragbtypename), "%", "");
            lV82Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname = StringUtil.Concat( StringUtil.RTrim( AV82Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname), "%", "");
            lV84Wp_organisationagbsuppliersds_9_tfsupplieragbphone = StringUtil.PadR( StringUtil.RTrim( AV84Wp_organisationagbsuppliersds_9_tfsupplieragbphone), 20, "%");
            lV86Wp_organisationagbsuppliersds_11_tfsupplieragbemail = StringUtil.Concat( StringUtil.RTrim( AV86Wp_organisationagbsuppliersds_11_tfsupplieragbemail), "%", "");
            /* Using cursor H006J2 */
            pr_default.execute(0, new Object[] {lV76Wp_organisationagbsuppliersds_1_filterfulltext, lV76Wp_organisationagbsuppliersds_1_filterfulltext, lV76Wp_organisationagbsuppliersds_1_filterfulltext, lV76Wp_organisationagbsuppliersds_1_filterfulltext, lV76Wp_organisationagbsuppliersds_1_filterfulltext, lV77Wp_organisationagbsuppliersds_2_tfsupplieragbname, AV79Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel, AV23isSelected, lV80Wp_organisationagbsuppliersds_5_tfsupplieragbtypename, AV81Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel, lV82Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname, AV83Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel, lV84Wp_organisationagbsuppliersds_9_tfsupplieragbphone, AV85Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel, lV86Wp_organisationagbsuppliersds_11_tfsupplieragbemail, AV87Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_37_idx = 1;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A49SupplierAgbId = H006J2_A49SupplierAgbId[0];
               A57SupplierAgbEmail = H006J2_A57SupplierAgbEmail[0];
               A350SupplierAgbPhoneNumber = H006J2_A350SupplierAgbPhoneNumber[0];
               A349SupplierAgbPhoneCode = H006J2_A349SupplierAgbPhoneCode[0];
               A56SupplierAgbPhone = H006J2_A56SupplierAgbPhone[0];
               A55SupplierAgbContactName = H006J2_A55SupplierAgbContactName[0];
               A308SupplierAgbAddressLine2 = H006J2_A308SupplierAgbAddressLine2[0];
               A307SupplierAgbAddressLine1 = H006J2_A307SupplierAgbAddressLine1[0];
               A263SupplierAgbAddressZipCode = H006J2_A263SupplierAgbAddressZipCode[0];
               A264SupplierAgbAddressCity = H006J2_A264SupplierAgbAddressCity[0];
               A306SupplierAGBAddressCountry = H006J2_A306SupplierAGBAddressCountry[0];
               A52SupplierAgbKvkNumber = H006J2_A52SupplierAgbKvkNumber[0];
               A256SupplierAgbTypeName = H006J2_A256SupplierAgbTypeName[0];
               A51SupplierAgbName = H006J2_A51SupplierAgbName[0];
               A255SupplierAgbTypeId = H006J2_A255SupplierAgbTypeId[0];
               A50SupplierAgbNumber = H006J2_A50SupplierAgbNumber[0];
               A256SupplierAgbTypeName = H006J2_A256SupplierAgbTypeName[0];
               /* Execute user event: Grid.Load */
               E196J2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 37;
            WB6J0( ) ;
         }
         bGXsfl_37_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes6J2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV74Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV74Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV64OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV64OrganisationId, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPREFERREDSUPPLIERS", AV57PreferredSuppliers);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPREFERREDSUPPLIERS", AV57PreferredSuppliers);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vPREFERREDSUPPLIERS", GetSecureSignedToken( "", AV57PreferredSuppliers, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV49IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV49IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_SUPPLIERAGBNAME", AV46IsAuthorized_SupplierAgbName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SUPPLIERAGBNAME", GetSecureSignedToken( "", AV46IsAuthorized_SupplierAgbName, context));
         GxWebStd.gx_hidden_field( context, "gxhash_SUPPLIERAGBID"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, A49SupplierAgbId, context));
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
         AV76Wp_organisationagbsuppliersds_1_filterfulltext = AV22FilterFullText;
         AV77Wp_organisationagbsuppliersds_2_tfsupplieragbname = AV29TFSupplierAgbName;
         AV78Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator = AV62TFSupplierAgbNameOperator;
         AV79Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel = AV30TFSupplierAgbName_Sel;
         AV80Wp_organisationagbsuppliersds_5_tfsupplieragbtypename = AV31TFSupplierAgbTypeName;
         AV81Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel = AV32TFSupplierAgbTypeName_Sel;
         AV82Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname = AV33TFSupplierAgbContactName;
         AV83Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel = AV34TFSupplierAgbContactName_Sel;
         AV84Wp_organisationagbsuppliersds_9_tfsupplieragbphone = AV35TFSupplierAgbPhone;
         AV85Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel = AV36TFSupplierAgbPhone_Sel;
         AV86Wp_organisationagbsuppliersds_11_tfsupplieragbemail = AV37TFSupplierAgbEmail;
         AV87Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel = AV38TFSupplierAgbEmail_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV76Wp_organisationagbsuppliersds_1_filterfulltext ,
                                              AV79Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel ,
                                              AV77Wp_organisationagbsuppliersds_2_tfsupplieragbname ,
                                              AV78Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator ,
                                              AV81Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel ,
                                              AV80Wp_organisationagbsuppliersds_5_tfsupplieragbtypename ,
                                              AV83Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel ,
                                              AV82Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname ,
                                              AV85Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel ,
                                              AV84Wp_organisationagbsuppliersds_9_tfsupplieragbphone ,
                                              AV87Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel ,
                                              AV86Wp_organisationagbsuppliersds_11_tfsupplieragbemail ,
                                              A51SupplierAgbName ,
                                              A256SupplierAgbTypeName ,
                                              A55SupplierAgbContactName ,
                                              A56SupplierAgbPhone ,
                                              A57SupplierAgbEmail ,
                                              AV23isSelected ,
                                              AV20OrderedBy ,
                                              AV21OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV76Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV76Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
         lV76Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV76Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
         lV76Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV76Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
         lV76Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV76Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
         lV76Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV76Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
         lV77Wp_organisationagbsuppliersds_2_tfsupplieragbname = StringUtil.Concat( StringUtil.RTrim( AV77Wp_organisationagbsuppliersds_2_tfsupplieragbname), "%", "");
         lV80Wp_organisationagbsuppliersds_5_tfsupplieragbtypename = StringUtil.Concat( StringUtil.RTrim( AV80Wp_organisationagbsuppliersds_5_tfsupplieragbtypename), "%", "");
         lV82Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname = StringUtil.Concat( StringUtil.RTrim( AV82Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname), "%", "");
         lV84Wp_organisationagbsuppliersds_9_tfsupplieragbphone = StringUtil.PadR( StringUtil.RTrim( AV84Wp_organisationagbsuppliersds_9_tfsupplieragbphone), 20, "%");
         lV86Wp_organisationagbsuppliersds_11_tfsupplieragbemail = StringUtil.Concat( StringUtil.RTrim( AV86Wp_organisationagbsuppliersds_11_tfsupplieragbemail), "%", "");
         /* Using cursor H006J3 */
         pr_default.execute(1, new Object[] {lV76Wp_organisationagbsuppliersds_1_filterfulltext, lV76Wp_organisationagbsuppliersds_1_filterfulltext, lV76Wp_organisationagbsuppliersds_1_filterfulltext, lV76Wp_organisationagbsuppliersds_1_filterfulltext, lV76Wp_organisationagbsuppliersds_1_filterfulltext, lV77Wp_organisationagbsuppliersds_2_tfsupplieragbname, AV79Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel, AV23isSelected, lV80Wp_organisationagbsuppliersds_5_tfsupplieragbtypename, AV81Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel, lV82Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname, AV83Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel, lV84Wp_organisationagbsuppliersds_9_tfsupplieragbphone, AV85Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel, lV86Wp_organisationagbsuppliersds_11_tfsupplieragbemail, AV87Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel});
         GRID_nRecordCount = H006J3_AGRID_nRecordCount[0];
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
         AV76Wp_organisationagbsuppliersds_1_filterfulltext = AV22FilterFullText;
         AV77Wp_organisationagbsuppliersds_2_tfsupplieragbname = AV29TFSupplierAgbName;
         AV78Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator = AV62TFSupplierAgbNameOperator;
         AV79Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel = AV30TFSupplierAgbName_Sel;
         AV80Wp_organisationagbsuppliersds_5_tfsupplieragbtypename = AV31TFSupplierAgbTypeName;
         AV81Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel = AV32TFSupplierAgbTypeName_Sel;
         AV82Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname = AV33TFSupplierAgbContactName;
         AV83Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel = AV34TFSupplierAgbContactName_Sel;
         AV84Wp_organisationagbsuppliersds_9_tfsupplieragbphone = AV35TFSupplierAgbPhone;
         AV85Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel = AV36TFSupplierAgbPhone_Sel;
         AV86Wp_organisationagbsuppliersds_11_tfsupplieragbemail = AV37TFSupplierAgbEmail;
         AV87Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel = AV38TFSupplierAgbEmail_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV20OrderedBy, AV21OrderedDsc, AV22FilterFullText, AV28ManageFiltersExecutionStep, AV70ColumnsSelector, AV74Pgmname, A386PreferredAgbOrganisationId, AV64OrganisationId, A381PreferredSupplierAgbId, AV29TFSupplierAgbName, AV62TFSupplierAgbNameOperator, AV30TFSupplierAgbName_Sel, AV31TFSupplierAgbTypeName, AV32TFSupplierAgbTypeName_Sel, AV33TFSupplierAgbContactName, AV34TFSupplierAgbContactName_Sel, AV35TFSupplierAgbPhone, AV36TFSupplierAgbPhone_Sel, AV37TFSupplierAgbEmail, AV38TFSupplierAgbEmail_Sel, AV57PreferredSuppliers, AV49IsAuthorized_Display, AV46IsAuthorized_SupplierAgbName) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV76Wp_organisationagbsuppliersds_1_filterfulltext = AV22FilterFullText;
         AV77Wp_organisationagbsuppliersds_2_tfsupplieragbname = AV29TFSupplierAgbName;
         AV78Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator = AV62TFSupplierAgbNameOperator;
         AV79Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel = AV30TFSupplierAgbName_Sel;
         AV80Wp_organisationagbsuppliersds_5_tfsupplieragbtypename = AV31TFSupplierAgbTypeName;
         AV81Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel = AV32TFSupplierAgbTypeName_Sel;
         AV82Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname = AV33TFSupplierAgbContactName;
         AV83Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel = AV34TFSupplierAgbContactName_Sel;
         AV84Wp_organisationagbsuppliersds_9_tfsupplieragbphone = AV35TFSupplierAgbPhone;
         AV85Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel = AV36TFSupplierAgbPhone_Sel;
         AV86Wp_organisationagbsuppliersds_11_tfsupplieragbemail = AV37TFSupplierAgbEmail;
         AV87Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel = AV38TFSupplierAgbEmail_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV20OrderedBy, AV21OrderedDsc, AV22FilterFullText, AV28ManageFiltersExecutionStep, AV70ColumnsSelector, AV74Pgmname, A386PreferredAgbOrganisationId, AV64OrganisationId, A381PreferredSupplierAgbId, AV29TFSupplierAgbName, AV62TFSupplierAgbNameOperator, AV30TFSupplierAgbName_Sel, AV31TFSupplierAgbTypeName, AV32TFSupplierAgbTypeName_Sel, AV33TFSupplierAgbContactName, AV34TFSupplierAgbContactName_Sel, AV35TFSupplierAgbPhone, AV36TFSupplierAgbPhone_Sel, AV37TFSupplierAgbEmail, AV38TFSupplierAgbEmail_Sel, AV57PreferredSuppliers, AV49IsAuthorized_Display, AV46IsAuthorized_SupplierAgbName) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV76Wp_organisationagbsuppliersds_1_filterfulltext = AV22FilterFullText;
         AV77Wp_organisationagbsuppliersds_2_tfsupplieragbname = AV29TFSupplierAgbName;
         AV78Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator = AV62TFSupplierAgbNameOperator;
         AV79Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel = AV30TFSupplierAgbName_Sel;
         AV80Wp_organisationagbsuppliersds_5_tfsupplieragbtypename = AV31TFSupplierAgbTypeName;
         AV81Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel = AV32TFSupplierAgbTypeName_Sel;
         AV82Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname = AV33TFSupplierAgbContactName;
         AV83Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel = AV34TFSupplierAgbContactName_Sel;
         AV84Wp_organisationagbsuppliersds_9_tfsupplieragbphone = AV35TFSupplierAgbPhone;
         AV85Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel = AV36TFSupplierAgbPhone_Sel;
         AV86Wp_organisationagbsuppliersds_11_tfsupplieragbemail = AV37TFSupplierAgbEmail;
         AV87Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel = AV38TFSupplierAgbEmail_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV20OrderedBy, AV21OrderedDsc, AV22FilterFullText, AV28ManageFiltersExecutionStep, AV70ColumnsSelector, AV74Pgmname, A386PreferredAgbOrganisationId, AV64OrganisationId, A381PreferredSupplierAgbId, AV29TFSupplierAgbName, AV62TFSupplierAgbNameOperator, AV30TFSupplierAgbName_Sel, AV31TFSupplierAgbTypeName, AV32TFSupplierAgbTypeName_Sel, AV33TFSupplierAgbContactName, AV34TFSupplierAgbContactName_Sel, AV35TFSupplierAgbPhone, AV36TFSupplierAgbPhone_Sel, AV37TFSupplierAgbEmail, AV38TFSupplierAgbEmail_Sel, AV57PreferredSuppliers, AV49IsAuthorized_Display, AV46IsAuthorized_SupplierAgbName) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV76Wp_organisationagbsuppliersds_1_filterfulltext = AV22FilterFullText;
         AV77Wp_organisationagbsuppliersds_2_tfsupplieragbname = AV29TFSupplierAgbName;
         AV78Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator = AV62TFSupplierAgbNameOperator;
         AV79Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel = AV30TFSupplierAgbName_Sel;
         AV80Wp_organisationagbsuppliersds_5_tfsupplieragbtypename = AV31TFSupplierAgbTypeName;
         AV81Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel = AV32TFSupplierAgbTypeName_Sel;
         AV82Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname = AV33TFSupplierAgbContactName;
         AV83Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel = AV34TFSupplierAgbContactName_Sel;
         AV84Wp_organisationagbsuppliersds_9_tfsupplieragbphone = AV35TFSupplierAgbPhone;
         AV85Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel = AV36TFSupplierAgbPhone_Sel;
         AV86Wp_organisationagbsuppliersds_11_tfsupplieragbemail = AV37TFSupplierAgbEmail;
         AV87Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel = AV38TFSupplierAgbEmail_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV20OrderedBy, AV21OrderedDsc, AV22FilterFullText, AV28ManageFiltersExecutionStep, AV70ColumnsSelector, AV74Pgmname, A386PreferredAgbOrganisationId, AV64OrganisationId, A381PreferredSupplierAgbId, AV29TFSupplierAgbName, AV62TFSupplierAgbNameOperator, AV30TFSupplierAgbName_Sel, AV31TFSupplierAgbTypeName, AV32TFSupplierAgbTypeName_Sel, AV33TFSupplierAgbContactName, AV34TFSupplierAgbContactName_Sel, AV35TFSupplierAgbPhone, AV36TFSupplierAgbPhone_Sel, AV37TFSupplierAgbEmail, AV38TFSupplierAgbEmail_Sel, AV57PreferredSuppliers, AV49IsAuthorized_Display, AV46IsAuthorized_SupplierAgbName) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV76Wp_organisationagbsuppliersds_1_filterfulltext = AV22FilterFullText;
         AV77Wp_organisationagbsuppliersds_2_tfsupplieragbname = AV29TFSupplierAgbName;
         AV78Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator = AV62TFSupplierAgbNameOperator;
         AV79Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel = AV30TFSupplierAgbName_Sel;
         AV80Wp_organisationagbsuppliersds_5_tfsupplieragbtypename = AV31TFSupplierAgbTypeName;
         AV81Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel = AV32TFSupplierAgbTypeName_Sel;
         AV82Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname = AV33TFSupplierAgbContactName;
         AV83Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel = AV34TFSupplierAgbContactName_Sel;
         AV84Wp_organisationagbsuppliersds_9_tfsupplieragbphone = AV35TFSupplierAgbPhone;
         AV85Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel = AV36TFSupplierAgbPhone_Sel;
         AV86Wp_organisationagbsuppliersds_11_tfsupplieragbemail = AV37TFSupplierAgbEmail;
         AV87Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel = AV38TFSupplierAgbEmail_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV20OrderedBy, AV21OrderedDsc, AV22FilterFullText, AV28ManageFiltersExecutionStep, AV70ColumnsSelector, AV74Pgmname, A386PreferredAgbOrganisationId, AV64OrganisationId, A381PreferredSupplierAgbId, AV29TFSupplierAgbName, AV62TFSupplierAgbNameOperator, AV30TFSupplierAgbName_Sel, AV31TFSupplierAgbTypeName, AV32TFSupplierAgbTypeName_Sel, AV33TFSupplierAgbContactName, AV34TFSupplierAgbContactName_Sel, AV35TFSupplierAgbPhone, AV36TFSupplierAgbPhone_Sel, AV37TFSupplierAgbEmail, AV38TFSupplierAgbEmail_Sel, AV57PreferredSuppliers, AV49IsAuthorized_Display, AV46IsAuthorized_SupplierAgbName) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV74Pgmname = "WP_OrganisationAGBSuppliers";
         edtavSupplieragbnamewithtags_Enabled = 0;
         edtavSupplierstatus_Enabled = 0;
         edtavSupplieraddress_Enabled = 0;
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

      protected void STRUP6J0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E176J2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV26ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV39DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV70ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_37 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_37"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
            Ddo_grid_Fixedfilters = cgiGet( "DDO_GRID_Fixedfilters");
            Ddo_grid_Selectedfixedfilter = cgiGet( "DDO_GRID_Selectedfixedfilter");
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
            Ddo_grid_Selectedcolumnfixedfilter = cgiGet( "DDO_GRID_Selectedcolumnfixedfilter");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV22FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV22FilterFullText", AV22FilterFullText);
            /* Read subfile selected row values. */
            nGXsfl_37_idx = (int)(Math.Round(context.localUtil.CToN( cgiGet( subGrid_Internalname+"_ROW"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
            if ( nGXsfl_37_idx > 0 )
            {
               AV23isSelected = StringUtil.StrToBool( cgiGet( chkavIsselected_Internalname));
               AssignAttri("", false, chkavIsselected_Internalname, AV23isSelected);
               A49SupplierAgbId = StringUtil.StrToGuid( cgiGet( edtSupplierAgbId_Internalname));
               A50SupplierAgbNumber = cgiGet( edtSupplierAgbNumber_Internalname);
               A255SupplierAgbTypeId = StringUtil.StrToGuid( cgiGet( edtSupplierAgbTypeId_Internalname));
               AV63SupplierAgbNameWithTags = cgiGet( edtavSupplieragbnamewithtags_Internalname);
               AssignAttri("", false, edtavSupplieragbnamewithtags_Internalname, AV63SupplierAgbNameWithTags);
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
               AV59SupplierStatus = cgiGet( edtavSupplierstatus_Internalname);
               AssignAttri("", false, edtavSupplierstatus_Internalname, AV59SupplierStatus);
               AV24SupplierAddress = cgiGet( edtavSupplieraddress_Internalname);
               AssignAttri("", false, edtavSupplieraddress_Internalname, AV24SupplierAddress);
               cmbavActiongroup.Name = cmbavActiongroup_Internalname;
               cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
               AV66ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV66ActionGroup), 4, 0));
            }
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV20OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV21OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV22FilterFullText) != 0 )
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
         E176J2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E176J2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV72successmsg = AV73websession.Get(context.GetMessage( "NotificationMessage", ""));
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72successmsg)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Success",  AV72successmsg,  "success",  "",  "true",  ""));
            AV73websession.Remove(context.GetMessage( "NotificationMessage", ""));
         }
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV15HTTPRequest.Method, "GET") == 0 )
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
         GXt_boolean1 = AV46IsAuthorized_SupplierAgbName;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_supplieragbview_Execute", out  GXt_boolean1) ;
         AV46IsAuthorized_SupplierAgbName = GXt_boolean1;
         AssignAttri("", false, "AV46IsAuthorized_SupplierAgbName", AV46IsAuthorized_SupplierAgbName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SUPPLIERAGBNAME", GetSecureSignedToken( "", AV46IsAuthorized_SupplierAgbName, context));
         AV40GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV41GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV40GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = context.GetMessage( " Agb Suppliers", "");
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
         if ( AV20OrderedBy < 1 )
         {
            AV20OrderedBy = 1;
            AssignAttri("", false, "AV20OrderedBy", StringUtil.LTrimStr( (decimal)(AV20OrderedBy), 4, 0));
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
         GXt_guid3 = AV64OrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid3) ;
         AV64OrganisationId = GXt_guid3;
         AssignAttri("", false, "AV64OrganisationId", AV64OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV64OrganisationId, context));
      }

      protected void E186J2( )
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
         if ( AV28ManageFiltersExecutionStep == 1 )
         {
            AV28ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV28ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV28ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV28ManageFiltersExecutionStep == 2 )
         {
            AV28ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV28ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV28ManageFiltersExecutionStep), 1, 0));
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
         if ( StringUtil.StrCmp(AV25Session.Get("WP_OrganisationAGBSuppliersColumnsSelector"), "") != 0 )
         {
            AV68ColumnsSelectorXML = AV25Session.Get("WP_OrganisationAGBSuppliersColumnsSelector");
            AV70ColumnsSelector.FromXml(AV68ColumnsSelectorXML, null, "", "");
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
         chkavIsselected.Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV70ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, chkavIsselected_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavIsselected.Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtavSupplieragbnamewithtags_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV70ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavSupplieragbnamewithtags_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSupplieragbnamewithtags_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtSupplierAgbTypeName_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV70ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSupplierAgbTypeName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierAgbTypeName_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtSupplierAgbContactName_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV70ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSupplierAgbContactName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierAgbContactName_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtSupplierAgbPhone_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV70ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSupplierAgbPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierAgbPhone_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtSupplierAgbEmail_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV70ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSupplierAgbEmail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierAgbEmail_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtavSupplieraddress_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV70ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavSupplieraddress_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSupplieraddress_Visible), 5, 0), !bGXsfl_37_Refreshing);
         AV43GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV43GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV43GridCurrentPage), 10, 0));
         AV44GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV44GridPageCount", StringUtil.LTrimStr( (decimal)(AV44GridPageCount), 10, 0));
         GXt_char4 = AV45GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV74Pgmname, out  GXt_char4) ;
         AV45GridAppliedFilters = GXt_char4;
         AssignAttri("", false, "AV45GridAppliedFilters", AV45GridAppliedFilters);
         AV57PreferredSuppliers.Clear();
         /* Using cursor H006J4 */
         pr_default.execute(2, new Object[] {AV64OrganisationId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A386PreferredAgbOrganisationId = H006J4_A386PreferredAgbOrganisationId[0];
            A381PreferredSupplierAgbId = H006J4_A381PreferredSupplierAgbId[0];
            AV57PreferredSuppliers.Add(A381PreferredSupplierAgbId, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         AV76Wp_organisationagbsuppliersds_1_filterfulltext = AV22FilterFullText;
         AV77Wp_organisationagbsuppliersds_2_tfsupplieragbname = AV29TFSupplierAgbName;
         AV78Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator = AV62TFSupplierAgbNameOperator;
         AV79Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel = AV30TFSupplierAgbName_Sel;
         AV80Wp_organisationagbsuppliersds_5_tfsupplieragbtypename = AV31TFSupplierAgbTypeName;
         AV81Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel = AV32TFSupplierAgbTypeName_Sel;
         AV82Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname = AV33TFSupplierAgbContactName;
         AV83Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel = AV34TFSupplierAgbContactName_Sel;
         AV84Wp_organisationagbsuppliersds_9_tfsupplieragbphone = AV35TFSupplierAgbPhone;
         AV85Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel = AV36TFSupplierAgbPhone_Sel;
         AV86Wp_organisationagbsuppliersds_11_tfsupplieragbemail = AV37TFSupplierAgbEmail;
         AV87Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel = AV38TFSupplierAgbEmail_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV70ColumnsSelector", AV70ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV57PreferredSuppliers", AV57PreferredSuppliers);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV26ManageFiltersData", AV26ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18GridState", AV18GridState);
      }

      protected void E126J2( )
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

      protected void E136J2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E156J2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV20OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV20OrderedBy", StringUtil.LTrimStr( (decimal)(AV20OrderedBy), 4, 0));
            AV21OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV21OrderedDsc", AV21OrderedDsc);
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
               if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumnfixedfilter, "1") == 0 )
               {
                  AV62TFSupplierAgbNameOperator = 1;
                  AssignAttri("", false, "AV62TFSupplierAgbNameOperator", StringUtil.LTrimStr( (decimal)(AV62TFSupplierAgbNameOperator), 4, 0));
                  AV29TFSupplierAgbName = "";
                  AssignAttri("", false, "AV29TFSupplierAgbName", AV29TFSupplierAgbName);
                  AV30TFSupplierAgbName_Sel = "";
                  AssignAttri("", false, "AV30TFSupplierAgbName_Sel", AV30TFSupplierAgbName_Sel);
               }
               else
               {
                  AV62TFSupplierAgbNameOperator = 0;
                  AssignAttri("", false, "AV62TFSupplierAgbNameOperator", StringUtil.LTrimStr( (decimal)(AV62TFSupplierAgbNameOperator), 4, 0));
                  AV29TFSupplierAgbName = Ddo_grid_Filteredtext_get;
                  AssignAttri("", false, "AV29TFSupplierAgbName", AV29TFSupplierAgbName);
                  AV30TFSupplierAgbName_Sel = Ddo_grid_Selectedvalue_get;
                  AssignAttri("", false, "AV30TFSupplierAgbName_Sel", AV30TFSupplierAgbName_Sel);
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SupplierAgbTypeName") == 0 )
            {
               AV31TFSupplierAgbTypeName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV31TFSupplierAgbTypeName", AV31TFSupplierAgbTypeName);
               AV32TFSupplierAgbTypeName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV32TFSupplierAgbTypeName_Sel", AV32TFSupplierAgbTypeName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SupplierAgbContactName") == 0 )
            {
               AV33TFSupplierAgbContactName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV33TFSupplierAgbContactName", AV33TFSupplierAgbContactName);
               AV34TFSupplierAgbContactName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV34TFSupplierAgbContactName_Sel", AV34TFSupplierAgbContactName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SupplierAgbPhone") == 0 )
            {
               AV35TFSupplierAgbPhone = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV35TFSupplierAgbPhone", AV35TFSupplierAgbPhone);
               AV36TFSupplierAgbPhone_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV36TFSupplierAgbPhone_Sel", AV36TFSupplierAgbPhone_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SupplierAgbEmail") == 0 )
            {
               AV37TFSupplierAgbEmail = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV37TFSupplierAgbEmail", AV37TFSupplierAgbEmail);
               AV38TFSupplierAgbEmail_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV38TFSupplierAgbEmail_Sel", AV38TFSupplierAgbEmail_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E196J2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         GXt_char4 = AV24SupplierAddress;
         new prc_concatenateaddress(context ).execute(  A306SupplierAGBAddressCountry,  A264SupplierAgbAddressCity,  A263SupplierAgbAddressZipCode,  A307SupplierAgbAddressLine1,  A308SupplierAgbAddressLine2, out  GXt_char4) ;
         AV24SupplierAddress = GXt_char4;
         AssignAttri("", false, edtavSupplieraddress_Internalname, AV24SupplierAddress);
         if ( (AV57PreferredSuppliers.IndexOf(A49SupplierAgbId)>0) )
         {
            AV23isSelected = true;
            AssignAttri("", false, chkavIsselected_Internalname, AV23isSelected);
            AV59SupplierStatus = context.GetMessage( "Preferred", "");
            AssignAttri("", false, edtavSupplierstatus_Internalname, AV59SupplierStatus);
         }
         else
         {
            AV23isSelected = false;
            AssignAttri("", false, chkavIsselected_Internalname, AV23isSelected);
            AV59SupplierStatus = context.GetMessage( "Not Preferred", "");
            AssignAttri("", false, edtavSupplierstatus_Internalname, AV59SupplierStatus);
         }
         cmbavActiongroup.removeAllItems();
         cmbavActiongroup.addItem("0", ";fas fa-bars", 0);
         cmbavActiongroup.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "Display", ""), "fas fa-magnifying-glass", "", "", "", "", "", "", ""), 0);
         if ( AV49IsAuthorized_Display )
         {
            if ( false )
            {
               cmbavActiongroup.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
            }
         }
         if ( AV46IsAuthorized_SupplierAgbName )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_supplieragbview.aspx"+UrlEncode(A49SupplierAgbId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            edtavSupplieragbnamewithtags_Link = formatLink("trn_supplieragbview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         if ( StringUtil.StrCmp(AV59SupplierStatus, context.GetMessage( "Preferred", "")) == 0 )
         {
            edtavSupplierstatus_Columnclass = "WWColumn WWColumnTag WWColumnTagInfoLight WWColumnTagInfoLightSingleCell";
         }
         else if ( StringUtil.StrCmp(AV59SupplierStatus, context.GetMessage( "Not Preferred", "")) == 0 )
         {
            edtavSupplierstatus_Columnclass = "WWColumn WWColumnItalic WWColumnItalicSingleCell";
         }
         else
         {
            edtavSupplierstatus_Columnclass = "WWColumn";
         }
         GXt_char4 = AV63SupplierAgbNameWithTags;
         new WorkWithPlus.workwithplus_web.wwp_encodehtml(context ).execute(  A51SupplierAgbName, out  GXt_char4) ;
         AV63SupplierAgbNameWithTags = GXt_char4;
         AssignAttri("", false, edtavSupplieragbnamewithtags_Internalname, AV63SupplierAgbNameWithTags);
         if ( AV23isSelected )
         {
            AV63SupplierAgbNameWithTags = StringUtil.Format( "<i class='fa fa-star FontColorIconWarning TagBeforeText BootstrapTooltipTop' title='%1'></i>", context.GetMessage( "Preferred", ""), "", "", "", "", "", "", "", "") + AV63SupplierAgbNameWithTags;
            AssignAttri("", false, edtavSupplieragbnamewithtags_Internalname, AV63SupplierAgbNameWithTags);
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
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV66ActionGroup), 4, 0));
      }

      protected void E166J2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV68ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV70ColumnsSelector.FromJSonString(AV68ColumnsSelectorXML, null);
         new WorkWithPlus.workwithplus_web.savecolumnsselectorstate(context ).execute(  "WP_OrganisationAGBSuppliersColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV68ColumnsSelectorXML)) ? "" : AV70ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV70ColumnsSelector", AV70ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV57PreferredSuppliers", AV57PreferredSuppliers);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV26ManageFiltersData", AV26ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18GridState", AV18GridState);
      }

      protected void E116J2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("WP_OrganisationAGBSuppliersFilters")) + "," + UrlEncode(StringUtil.RTrim(AV74Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV28ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV28ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV28ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("WP_OrganisationAGBSuppliersFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV28ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV28ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV28ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char4 = AV27ManageFiltersXml;
            new WorkWithPlus.workwithplus_web.getfilterbyname(context ).execute(  "WP_OrganisationAGBSuppliersFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char4) ;
            AV27ManageFiltersXml = GXt_char4;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV27ManageFiltersXml)) )
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
               new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV74Pgmname+"GridState",  AV27ManageFiltersXml) ;
               AV18GridState.FromXml(AV27ManageFiltersXml, null, "", "");
               AV20OrderedBy = AV18GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV20OrderedBy", StringUtil.LTrimStr( (decimal)(AV20OrderedBy), 4, 0));
               AV21OrderedDsc = AV18GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV21OrderedDsc", AV21OrderedDsc);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18GridState", AV18GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV70ColumnsSelector", AV70ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV57PreferredSuppliers", AV57PreferredSuppliers);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV26ManageFiltersData", AV26ManageFiltersData);
      }

      protected void E206J2( )
      {
         /* Actiongroup_Click Routine */
         returnInSub = false;
         if ( AV66ActionGroup == 1 )
         {
            /* Execute user subroutine: 'DO UDISPLAY' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV66ActionGroup == 2 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV66ActionGroup = 0;
         AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV66ActionGroup), 4, 0));
         /*  Sending Event outputs  */
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV66ActionGroup), 4, 0));
         AssignProp("", false, cmbavActiongroup_Internalname, "Values", cmbavActiongroup.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV70ColumnsSelector", AV70ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV57PreferredSuppliers", AV57PreferredSuppliers);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV26ManageFiltersData", AV26ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18GridState", AV18GridState);
      }

      protected void E146J2( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0070",(string)"",(string)"Trn_SupplierAgb",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0070"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV20OrderedBy), 4, 0))+":"+(AV21OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S172( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV70ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV70ColumnsSelector,  "&isSelected",  "",  "",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV70ColumnsSelector,  "SupplierAgbName",  "",  "Name",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV70ColumnsSelector,  "SupplierAgbTypeName",  "",  "Category",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV70ColumnsSelector,  "SupplierAgbContactName",  "",  "Contact Person",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV70ColumnsSelector,  "SupplierAgbPhone",  "",  "Phone",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV70ColumnsSelector,  "SupplierAgbEmail",  "",  "Email",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV70ColumnsSelector,  "&SupplierAddress",  "",  "Address",  true,  "") ;
         GXt_char4 = AV69UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "WP_OrganisationAGBSuppliersColumnsSelector", out  GXt_char4) ;
         AV69UserCustomValue = GXt_char4;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV69UserCustomValue)) ) )
         {
            AV71ColumnsSelectorAux.FromXml(AV69UserCustomValue, null, "", "");
            new WorkWithPlus.workwithplus_web.wwp_columnselector_updatecolumns(context ).execute( ref  AV71ColumnsSelectorAux, ref  AV70ColumnsSelector) ;
         }
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV49IsAuthorized_Display;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_supplieragb_Execute", out  GXt_boolean1) ;
         AV49IsAuthorized_Display = GXt_boolean1;
         AssignAttri("", false, "AV49IsAuthorized_Display", AV49IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV49IsAuthorized_Display, context));
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 = AV26ManageFiltersData;
         new WorkWithPlus.workwithplus_web.wwp_managefiltersloadsavedfilters(context ).execute(  "WP_OrganisationAGBSuppliersFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5) ;
         AV26ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5;
      }

      protected void S182( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV22FilterFullText = "";
         AssignAttri("", false, "AV22FilterFullText", AV22FilterFullText);
         AV29TFSupplierAgbName = "";
         AssignAttri("", false, "AV29TFSupplierAgbName", AV29TFSupplierAgbName);
         AV30TFSupplierAgbName_Sel = "";
         AssignAttri("", false, "AV30TFSupplierAgbName_Sel", AV30TFSupplierAgbName_Sel);
         AV62TFSupplierAgbNameOperator = 0;
         AssignAttri("", false, "AV62TFSupplierAgbNameOperator", StringUtil.LTrimStr( (decimal)(AV62TFSupplierAgbNameOperator), 4, 0));
         Ddo_grid_Selectedfixedfilter = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedFixedFilter", Ddo_grid_Selectedfixedfilter);
         AV31TFSupplierAgbTypeName = "";
         AssignAttri("", false, "AV31TFSupplierAgbTypeName", AV31TFSupplierAgbTypeName);
         AV32TFSupplierAgbTypeName_Sel = "";
         AssignAttri("", false, "AV32TFSupplierAgbTypeName_Sel", AV32TFSupplierAgbTypeName_Sel);
         AV33TFSupplierAgbContactName = "";
         AssignAttri("", false, "AV33TFSupplierAgbContactName", AV33TFSupplierAgbContactName);
         AV34TFSupplierAgbContactName_Sel = "";
         AssignAttri("", false, "AV34TFSupplierAgbContactName_Sel", AV34TFSupplierAgbContactName_Sel);
         AV35TFSupplierAgbPhone = "";
         AssignAttri("", false, "AV35TFSupplierAgbPhone", AV35TFSupplierAgbPhone);
         AV36TFSupplierAgbPhone_Sel = "";
         AssignAttri("", false, "AV36TFSupplierAgbPhone_Sel", AV36TFSupplierAgbPhone_Sel);
         AV37TFSupplierAgbEmail = "";
         AssignAttri("", false, "AV37TFSupplierAgbEmail", AV37TFSupplierAgbEmail);
         AV38TFSupplierAgbEmail_Sel = "";
         AssignAttri("", false, "AV38TFSupplierAgbEmail_Sel", AV38TFSupplierAgbEmail_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S202( )
      {
         /* 'DO UDISPLAY' Routine */
         returnInSub = false;
         if ( AV49IsAuthorized_Display )
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
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         if ( AV49IsAuthorized_Display )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_supplieragb.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(A49SupplierAgbId.ToString());
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
         if ( StringUtil.StrCmp(AV25Session.Get(AV74Pgmname+"GridState"), "") == 0 )
         {
            AV18GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV74Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV18GridState.FromXml(AV25Session.Get(AV74Pgmname+"GridState"), null, "", "");
         }
         AV20OrderedBy = AV18GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV20OrderedBy", StringUtil.LTrimStr( (decimal)(AV20OrderedBy), 4, 0));
         AV21OrderedDsc = AV18GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV21OrderedDsc", AV21OrderedDsc);
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV18GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV18GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV18GridState.gxTpr_Currentpage) ;
      }

      protected void S192( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV88GXV1 = 1;
         while ( AV88GXV1 <= AV18GridState.gxTpr_Filtervalues.Count )
         {
            AV19GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV18GridState.gxTpr_Filtervalues.Item(AV88GXV1));
            if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV22FilterFullText = AV19GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV22FilterFullText", AV22FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBNAME") == 0 )
            {
               AV62TFSupplierAgbNameOperator = AV19GridStateFilterValue.gxTpr_Operator;
               AssignAttri("", false, "AV62TFSupplierAgbNameOperator", StringUtil.LTrimStr( (decimal)(AV62TFSupplierAgbNameOperator), 4, 0));
               if ( AV62TFSupplierAgbNameOperator == 0 )
               {
                  AV29TFSupplierAgbName = AV19GridStateFilterValue.gxTpr_Value;
                  AssignAttri("", false, "AV29TFSupplierAgbName", AV29TFSupplierAgbName);
               }
            }
            else if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBNAME_SEL") == 0 )
            {
               AV30TFSupplierAgbName_Sel = AV19GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV30TFSupplierAgbName_Sel", AV30TFSupplierAgbName_Sel);
            }
            else if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBTYPENAME") == 0 )
            {
               AV31TFSupplierAgbTypeName = AV19GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV31TFSupplierAgbTypeName", AV31TFSupplierAgbTypeName);
            }
            else if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBTYPENAME_SEL") == 0 )
            {
               AV32TFSupplierAgbTypeName_Sel = AV19GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV32TFSupplierAgbTypeName_Sel", AV32TFSupplierAgbTypeName_Sel);
            }
            else if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBCONTACTNAME") == 0 )
            {
               AV33TFSupplierAgbContactName = AV19GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV33TFSupplierAgbContactName", AV33TFSupplierAgbContactName);
            }
            else if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBCONTACTNAME_SEL") == 0 )
            {
               AV34TFSupplierAgbContactName_Sel = AV19GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV34TFSupplierAgbContactName_Sel", AV34TFSupplierAgbContactName_Sel);
            }
            else if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBPHONE") == 0 )
            {
               AV35TFSupplierAgbPhone = AV19GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV35TFSupplierAgbPhone", AV35TFSupplierAgbPhone);
            }
            else if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBPHONE_SEL") == 0 )
            {
               AV36TFSupplierAgbPhone_Sel = AV19GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV36TFSupplierAgbPhone_Sel", AV36TFSupplierAgbPhone_Sel);
            }
            else if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBEMAIL") == 0 )
            {
               AV37TFSupplierAgbEmail = AV19GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV37TFSupplierAgbEmail", AV37TFSupplierAgbEmail);
            }
            else if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBEMAIL_SEL") == 0 )
            {
               AV38TFSupplierAgbEmail_Sel = AV19GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV38TFSupplierAgbEmail_Sel", AV38TFSupplierAgbEmail_Sel);
            }
            AV88GXV1 = (int)(AV88GXV1+1);
         }
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV30TFSupplierAgbName_Sel)),  AV30TFSupplierAgbName_Sel, out  GXt_char4) ;
         GXt_char6 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV32TFSupplierAgbTypeName_Sel)),  AV32TFSupplierAgbTypeName_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFSupplierAgbContactName_Sel)),  AV34TFSupplierAgbContactName_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSupplierAgbPhone_Sel)),  AV36TFSupplierAgbPhone_Sel, out  GXt_char8) ;
         GXt_char9 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFSupplierAgbEmail_Sel)),  AV38TFSupplierAgbEmail_Sel, out  GXt_char9) ;
         Ddo_grid_Selectedvalue_set = GXt_char4+"|"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8+"|"+GXt_char9;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char9 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  !(0==AV62TFSupplierAgbNameOperator)||String.IsNullOrEmpty(StringUtil.RTrim( AV29TFSupplierAgbName)),  AV29TFSupplierAgbName, out  GXt_char9) ;
         GXt_char8 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV31TFSupplierAgbTypeName)),  AV31TFSupplierAgbTypeName, out  GXt_char8) ;
         GXt_char7 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV33TFSupplierAgbContactName)),  AV33TFSupplierAgbContactName, out  GXt_char7) ;
         GXt_char6 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFSupplierAgbPhone)),  AV35TFSupplierAgbPhone, out  GXt_char6) ;
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFSupplierAgbEmail)),  AV37TFSupplierAgbEmail, out  GXt_char4) ;
         Ddo_grid_Filteredtext_set = GXt_char9+"|"+GXt_char8+"|"+GXt_char7+"|"+GXt_char6+"|"+GXt_char4;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Selectedfixedfilter = ((AV62TFSupplierAgbNameOperator!=1) ? "" : "1")+"||||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedFixedFilter", Ddo_grid_Selectedfixedfilter);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV18GridState.FromXml(AV25Session.Get(AV74Pgmname+"GridState"), null, "", "");
         AV18GridState.gxTpr_Orderedby = AV20OrderedBy;
         AV18GridState.gxTpr_Ordereddsc = AV21OrderedDsc;
         AV18GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV18GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV22FilterFullText)),  0,  AV22FilterFullText,  AV22FilterFullText,  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV18GridState,  "TFSUPPLIERAGBNAME",  context.GetMessage( "Name", ""),  !(String.IsNullOrEmpty(StringUtil.RTrim( AV29TFSupplierAgbName))&&(0==AV62TFSupplierAgbNameOperator)),  AV62TFSupplierAgbNameOperator,  AV29TFSupplierAgbName,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV62TFSupplierAgbNameOperator+1), 10, 0)), AV29TFSupplierAgbName, context.GetMessage( "Preferred", ""), "", "", "", "", "", "", ""),  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV30TFSupplierAgbName_Sel)),  AV30TFSupplierAgbName_Sel,  AV30TFSupplierAgbName_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV18GridState,  "TFSUPPLIERAGBTYPENAME",  context.GetMessage( "Category", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV31TFSupplierAgbTypeName)),  0,  AV31TFSupplierAgbTypeName,  AV31TFSupplierAgbTypeName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV32TFSupplierAgbTypeName_Sel)),  AV32TFSupplierAgbTypeName_Sel,  AV32TFSupplierAgbTypeName_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV18GridState,  "TFSUPPLIERAGBCONTACTNAME",  context.GetMessage( "Contact Person", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV33TFSupplierAgbContactName)),  0,  AV33TFSupplierAgbContactName,  AV33TFSupplierAgbContactName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFSupplierAgbContactName_Sel)),  AV34TFSupplierAgbContactName_Sel,  AV34TFSupplierAgbContactName_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV18GridState,  "TFSUPPLIERAGBPHONE",  context.GetMessage( "Phone", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFSupplierAgbPhone)),  0,  AV35TFSupplierAgbPhone,  AV35TFSupplierAgbPhone,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSupplierAgbPhone_Sel)),  AV36TFSupplierAgbPhone_Sel,  AV36TFSupplierAgbPhone_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV18GridState,  "TFSUPPLIERAGBEMAIL",  context.GetMessage( "Email", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFSupplierAgbEmail)),  0,  AV37TFSupplierAgbEmail,  AV37TFSupplierAgbEmail,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFSupplierAgbEmail_Sel)),  AV38TFSupplierAgbEmail_Sel,  AV38TFSupplierAgbEmail_Sel) ;
         AV18GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV18GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV74Pgmname+"GridState",  AV18GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV16TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV16TrnContext.gxTpr_Callerobject = AV74Pgmname;
         AV16TrnContext.gxTpr_Callerondelete = true;
         AV16TrnContext.gxTpr_Callerurl = AV15HTTPRequest.ScriptName+"?"+AV15HTTPRequest.QueryString;
         AV16TrnContext.gxTpr_Transactionname = "Trn_SupplierAgb";
         AV25Session.Set("TrnContext", AV16TrnContext.ToXml(false, true, "", ""));
      }

      protected void E216J2( )
      {
         /* Isselected_Click Routine */
         returnInSub = false;
         if ( AV23isSelected )
         {
            AV56Trn_PreferredAgbSupplier.gxTpr_Preferredagbsupplierid = Guid.NewGuid( );
            AV56Trn_PreferredAgbSupplier.gxTpr_Preferredsupplieragbid = A49SupplierAgbId;
            AV56Trn_PreferredAgbSupplier.Insert();
         }
         else
         {
            /* Using cursor H006J5 */
            pr_default.execute(3, new Object[] {A49SupplierAgbId, AV64OrganisationId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A381PreferredSupplierAgbId = H006J5_A381PreferredSupplierAgbId[0];
               A386PreferredAgbOrganisationId = H006J5_A386PreferredAgbOrganisationId[0];
               A384PreferredAgbSupplierId = H006J5_A384PreferredAgbSupplierId[0];
               AV56Trn_PreferredAgbSupplier.Load(A384PreferredAgbSupplierId);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            AV56Trn_PreferredAgbSupplier.Delete();
         }
         context.CommitDataStores("wp_organisationagbsuppliers",pr_default);
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV56Trn_PreferredAgbSupplier", AV56Trn_PreferredAgbSupplier);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV70ColumnsSelector", AV70ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV57PreferredSuppliers", AV57PreferredSuppliers);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV26ManageFiltersData", AV26ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18GridState", AV18GridState);
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
         PA6J2( ) ;
         WS6J2( ) ;
         WE6J2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256201791710", true, true);
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
         context.AddJavascriptSource("wp_organisationagbsuppliers.js", "?20256201791713", false, true);
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

      protected void SubsflControlProps_372( )
      {
         chkavIsselected_Internalname = "vISSELECTED_"+sGXsfl_37_idx;
         edtSupplierAgbId_Internalname = "SUPPLIERAGBID_"+sGXsfl_37_idx;
         edtSupplierAgbNumber_Internalname = "SUPPLIERAGBNUMBER_"+sGXsfl_37_idx;
         edtSupplierAgbTypeId_Internalname = "SUPPLIERAGBTYPEID_"+sGXsfl_37_idx;
         edtavSupplieragbnamewithtags_Internalname = "vSUPPLIERAGBNAMEWITHTAGS_"+sGXsfl_37_idx;
         edtSupplierAgbName_Internalname = "SUPPLIERAGBNAME_"+sGXsfl_37_idx;
         edtSupplierAgbTypeName_Internalname = "SUPPLIERAGBTYPENAME_"+sGXsfl_37_idx;
         edtSupplierAgbKvkNumber_Internalname = "SUPPLIERAGBKVKNUMBER_"+sGXsfl_37_idx;
         edtSupplierAGBAddressCountry_Internalname = "SUPPLIERAGBADDRESSCOUNTRY_"+sGXsfl_37_idx;
         edtSupplierAgbAddressCity_Internalname = "SUPPLIERAGBADDRESSCITY_"+sGXsfl_37_idx;
         edtSupplierAgbAddressZipCode_Internalname = "SUPPLIERAGBADDRESSZIPCODE_"+sGXsfl_37_idx;
         edtSupplierAgbAddressLine1_Internalname = "SUPPLIERAGBADDRESSLINE1_"+sGXsfl_37_idx;
         edtSupplierAgbAddressLine2_Internalname = "SUPPLIERAGBADDRESSLINE2_"+sGXsfl_37_idx;
         edtSupplierAgbContactName_Internalname = "SUPPLIERAGBCONTACTNAME_"+sGXsfl_37_idx;
         edtSupplierAgbPhone_Internalname = "SUPPLIERAGBPHONE_"+sGXsfl_37_idx;
         edtSupplierAgbPhoneCode_Internalname = "SUPPLIERAGBPHONECODE_"+sGXsfl_37_idx;
         edtSupplierAgbPhoneNumber_Internalname = "SUPPLIERAGBPHONENUMBER_"+sGXsfl_37_idx;
         edtSupplierAgbEmail_Internalname = "SUPPLIERAGBEMAIL_"+sGXsfl_37_idx;
         edtavSupplierstatus_Internalname = "vSUPPLIERSTATUS_"+sGXsfl_37_idx;
         edtavSupplieraddress_Internalname = "vSUPPLIERADDRESS_"+sGXsfl_37_idx;
         cmbavActiongroup_Internalname = "vACTIONGROUP_"+sGXsfl_37_idx;
      }

      protected void SubsflControlProps_fel_372( )
      {
         chkavIsselected_Internalname = "vISSELECTED_"+sGXsfl_37_fel_idx;
         edtSupplierAgbId_Internalname = "SUPPLIERAGBID_"+sGXsfl_37_fel_idx;
         edtSupplierAgbNumber_Internalname = "SUPPLIERAGBNUMBER_"+sGXsfl_37_fel_idx;
         edtSupplierAgbTypeId_Internalname = "SUPPLIERAGBTYPEID_"+sGXsfl_37_fel_idx;
         edtavSupplieragbnamewithtags_Internalname = "vSUPPLIERAGBNAMEWITHTAGS_"+sGXsfl_37_fel_idx;
         edtSupplierAgbName_Internalname = "SUPPLIERAGBNAME_"+sGXsfl_37_fel_idx;
         edtSupplierAgbTypeName_Internalname = "SUPPLIERAGBTYPENAME_"+sGXsfl_37_fel_idx;
         edtSupplierAgbKvkNumber_Internalname = "SUPPLIERAGBKVKNUMBER_"+sGXsfl_37_fel_idx;
         edtSupplierAGBAddressCountry_Internalname = "SUPPLIERAGBADDRESSCOUNTRY_"+sGXsfl_37_fel_idx;
         edtSupplierAgbAddressCity_Internalname = "SUPPLIERAGBADDRESSCITY_"+sGXsfl_37_fel_idx;
         edtSupplierAgbAddressZipCode_Internalname = "SUPPLIERAGBADDRESSZIPCODE_"+sGXsfl_37_fel_idx;
         edtSupplierAgbAddressLine1_Internalname = "SUPPLIERAGBADDRESSLINE1_"+sGXsfl_37_fel_idx;
         edtSupplierAgbAddressLine2_Internalname = "SUPPLIERAGBADDRESSLINE2_"+sGXsfl_37_fel_idx;
         edtSupplierAgbContactName_Internalname = "SUPPLIERAGBCONTACTNAME_"+sGXsfl_37_fel_idx;
         edtSupplierAgbPhone_Internalname = "SUPPLIERAGBPHONE_"+sGXsfl_37_fel_idx;
         edtSupplierAgbPhoneCode_Internalname = "SUPPLIERAGBPHONECODE_"+sGXsfl_37_fel_idx;
         edtSupplierAgbPhoneNumber_Internalname = "SUPPLIERAGBPHONENUMBER_"+sGXsfl_37_fel_idx;
         edtSupplierAgbEmail_Internalname = "SUPPLIERAGBEMAIL_"+sGXsfl_37_fel_idx;
         edtavSupplierstatus_Internalname = "vSUPPLIERSTATUS_"+sGXsfl_37_fel_idx;
         edtavSupplieraddress_Internalname = "vSUPPLIERADDRESS_"+sGXsfl_37_fel_idx;
         cmbavActiongroup_Internalname = "vACTIONGROUP_"+sGXsfl_37_fel_idx;
      }

      protected void sendrow_372( )
      {
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         WB6J0( ) ;
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
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWithSelection WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_37_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkavIsselected.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "vISSELECTED_" + sGXsfl_37_idx;
            chkavIsselected.Name = GXCCtl;
            chkavIsselected.WebTags = "";
            chkavIsselected.Caption = "";
            AssignProp("", false, chkavIsselected_Internalname, "TitleCaption", chkavIsselected.Caption, !bGXsfl_37_Refreshing);
            chkavIsselected.CheckedValue = "false";
            AV23isSelected = StringUtil.StrToBool( StringUtil.BoolToStr( AV23isSelected));
            AssignAttri("", false, chkavIsselected_Internalname, AV23isSelected);
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavIsselected_Internalname,StringUtil.BoolToStr( AV23isSelected),(string)"",(string)"",chkavIsselected.Visible,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn WWIconActionColumn",(string)"",TempTags+" onblur=\""+""+";gx.evt.onblur(this,38);\""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbId_Internalname,A49SupplierAgbId.ToString(),A49SupplierAgbId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierAgbId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)37,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbNumber_Internalname,(string)A50SupplierAgbNumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierAgbNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"AgbNumber",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbTypeId_Internalname,A255SupplierAgbTypeId.ToString(),A255SupplierAgbTypeId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierAgbTypeId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)37,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavSupplieragbnamewithtags_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSupplieragbnamewithtags_Internalname,(string)AV63SupplierAgbNameWithTags,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavSupplieragbnamewithtags_Link,(string)"",(string)"",(string)"",(string)edtavSupplieragbnamewithtags_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavSupplieragbnamewithtags_Visible,(int)edtavSupplieragbnamewithtags_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbName_Internalname,(string)A51SupplierAgbName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierAgbName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSupplierAgbTypeName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbTypeName_Internalname,(string)A256SupplierAgbTypeName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierAgbTypeName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSupplierAgbTypeName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbKvkNumber_Internalname,(string)A52SupplierAgbKvkNumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierAgbKvkNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"KvkNumber",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAGBAddressCountry_Internalname,(string)A306SupplierAGBAddressCountry,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierAGBAddressCountry_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbAddressCity_Internalname,(string)A264SupplierAgbAddressCity,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierAgbAddressCity_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbAddressZipCode_Internalname,(string)A263SupplierAgbAddressZipCode,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierAgbAddressZipCode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbAddressLine1_Internalname,(string)A307SupplierAgbAddressLine1,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierAgbAddressLine1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbAddressLine2_Internalname,(string)A308SupplierAgbAddressLine2,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierAgbAddressLine2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSupplierAgbContactName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbContactName_Internalname,(string)A55SupplierAgbContactName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierAgbContactName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSupplierAgbContactName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbPhone_Internalname,StringUtil.RTrim( A56SupplierAgbPhone),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtSupplierAgbPhone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSupplierAgbPhone_Visible,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbPhoneCode_Internalname,(string)A349SupplierAgbPhoneCode,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierAgbPhoneCode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbPhoneNumber_Internalname,(string)A350SupplierAgbPhoneNumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierAgbPhoneNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSupplierAgbEmail_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbEmail_Internalname,(string)A57SupplierAgbEmail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A57SupplierAgbEmail,(string)"",(string)"",(string)"",(string)edtSupplierAgbEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSupplierAgbEmail_Visible,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSupplierstatus_Internalname,StringUtil.RTrim( AV59SupplierStatus),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSupplierstatus_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavSupplierstatus_Columnclass,(string)"",(short)0,(int)edtavSupplierstatus_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavSupplieraddress_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSupplieraddress_Internalname,(string)AV24SupplierAddress,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'","http://maps.google.com/maps?q="+GXUtil.UrlEncode( AV24SupplierAddress),(string)"_blank",(string)"",(string)"",(string)edtavSupplieraddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavSupplieraddress_Visible,(int)edtavSupplieraddress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Address",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'" + sGXsfl_37_idx + "',37)\"";
            if ( ( cmbavActiongroup.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vACTIONGROUP_" + sGXsfl_37_idx;
               cmbavActiongroup.Name = GXCCtl;
               cmbavActiongroup.WebTags = "";
               if ( cmbavActiongroup.ItemCount > 0 )
               {
                  AV66ActionGroup = (short)(Math.Round(NumberUtil.Val( cmbavActiongroup.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV66ActionGroup), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV66ActionGroup), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavActiongroup,(string)cmbavActiongroup_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV66ActionGroup), 4, 0)),(short)1,(string)cmbavActiongroup_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVACTIONGROUP.CLICK."+sGXsfl_37_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"",(string)"",(bool)true,(short)0});
            cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV66ActionGroup), 4, 0));
            AssignProp("", false, cmbavActiongroup_Internalname, "Values", (string)(cmbavActiongroup.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            send_integrity_lvl_hashes6J2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_37_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         /* End function sendrow_372 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vISSELECTED_" + sGXsfl_37_idx;
         chkavIsselected.Name = GXCCtl;
         chkavIsselected.WebTags = "";
         chkavIsselected.Caption = "";
         AssignProp("", false, chkavIsselected_Internalname, "TitleCaption", chkavIsselected.Caption, !bGXsfl_37_Refreshing);
         chkavIsselected.CheckedValue = "false";
         AV23isSelected = StringUtil.StrToBool( StringUtil.BoolToStr( AV23isSelected));
         AssignAttri("", false, chkavIsselected_Internalname, AV23isSelected);
         GXCCtl = "vACTIONGROUP_" + sGXsfl_37_idx;
         cmbavActiongroup.Name = GXCCtl;
         cmbavActiongroup.WebTags = "";
         if ( cmbavActiongroup.ItemCount > 0 )
         {
            AV66ActionGroup = (short)(Math.Round(NumberUtil.Val( cmbavActiongroup.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV66ActionGroup), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV66ActionGroup), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl37( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"37\">") ;
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
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+((chkavIsselected.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "&nbsp;", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavSupplieragbnamewithtags_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavSupplieraddress_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Address", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV23isSelected)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavIsselected.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV63SupplierAgbNameWithTags));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSupplieragbnamewithtags_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavSupplieragbnamewithtags_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSupplieragbnamewithtags_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A51SupplierAgbName));
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV59SupplierStatus)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavSupplierstatus_Columnclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSupplierstatus_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV24SupplierAddress));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSupplieraddress_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSupplieraddress_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV66ActionGroup), 4, 0, ".", ""))));
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
         bttBtnsubscriptions_Internalname = "BTNSUBSCRIPTIONS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         chkavIsselected_Internalname = "vISSELECTED";
         edtSupplierAgbId_Internalname = "SUPPLIERAGBID";
         edtSupplierAgbNumber_Internalname = "SUPPLIERAGBNUMBER";
         edtSupplierAgbTypeId_Internalname = "SUPPLIERAGBTYPEID";
         edtavSupplieragbnamewithtags_Internalname = "vSUPPLIERAGBNAMEWITHTAGS";
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
         edtavSupplierstatus_Internalname = "vSUPPLIERSTATUS";
         edtavSupplieraddress_Internalname = "vSUPPLIERADDRESS";
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
         edtavSupplieraddress_Jsonclick = "";
         edtavSupplieraddress_Enabled = 1;
         edtavSupplierstatus_Jsonclick = "";
         edtavSupplierstatus_Columnclass = "WWColumn";
         edtavSupplierstatus_Enabled = 1;
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
         edtavSupplieragbnamewithtags_Jsonclick = "";
         edtavSupplieragbnamewithtags_Link = "";
         edtavSupplieragbnamewithtags_Enabled = 1;
         edtSupplierAgbTypeId_Jsonclick = "";
         edtSupplierAgbNumber_Jsonclick = "";
         edtSupplierAgbId_Jsonclick = "";
         chkavIsselected.Caption = "";
         subGrid_Class = "GridWithPaginationBar WorkWithSelection WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavSupplieraddress_Visible = -1;
         edtSupplierAgbEmail_Visible = -1;
         edtSupplierAgbPhone_Visible = -1;
         edtSupplierAgbContactName_Visible = -1;
         edtSupplierAgbTypeName_Visible = -1;
         edtavSupplieragbnamewithtags_Visible = -1;
         chkavIsselected.Visible = -1;
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
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = context.GetMessage( "WWP_EditColumnsCaption", "");
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Fixedfilters = "1:Preferred:fa fa-star FontColorIconWarning ConditionalFormattingFilterIcon||||";
         Ddo_grid_Datalistproc = "WP_OrganisationAGBSuppliersGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character|Character|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5";
         Ddo_grid_Columnids = "4:SupplierAgbName|6:SupplierAgbTypeName|13:SupplierAgbContactName|14:SupplierAgbPhone|17:SupplierAgbEmail";
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
         Form.Caption = context.GetMessage( " Agb Suppliers", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV70ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV20OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV21OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV22FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV74Pgmname","fld":"vPGMNAME","hsh":true},{"av":"A386PreferredAgbOrganisationId","fld":"PREFERREDAGBORGANISATIONID"},{"av":"AV64OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"A381PreferredSupplierAgbId","fld":"PREFERREDSUPPLIERAGBID"},{"av":"AV29TFSupplierAgbName","fld":"vTFSUPPLIERAGBNAME"},{"av":"AV62TFSupplierAgbNameOperator","fld":"vTFSUPPLIERAGBNAMEOPERATOR","pic":"ZZZ9"},{"av":"AV30TFSupplierAgbName_Sel","fld":"vTFSUPPLIERAGBNAME_SEL"},{"av":"AV31TFSupplierAgbTypeName","fld":"vTFSUPPLIERAGBTYPENAME"},{"av":"AV32TFSupplierAgbTypeName_Sel","fld":"vTFSUPPLIERAGBTYPENAME_SEL"},{"av":"AV33TFSupplierAgbContactName","fld":"vTFSUPPLIERAGBCONTACTNAME"},{"av":"AV34TFSupplierAgbContactName_Sel","fld":"vTFSUPPLIERAGBCONTACTNAME_SEL"},{"av":"AV35TFSupplierAgbPhone","fld":"vTFSUPPLIERAGBPHONE"},{"av":"AV36TFSupplierAgbPhone_Sel","fld":"vTFSUPPLIERAGBPHONE_SEL"},{"av":"AV37TFSupplierAgbEmail","fld":"vTFSUPPLIERAGBEMAIL"},{"av":"AV38TFSupplierAgbEmail_Sel","fld":"vTFSUPPLIERAGBEMAIL_SEL"},{"av":"AV57PreferredSuppliers","fld":"vPREFERREDSUPPLIERS","hsh":true},{"av":"AV49IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV46IsAuthorized_SupplierAgbName","fld":"vISAUTHORIZED_SUPPLIERAGBNAME","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV70ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"chkavIsselected.Visible","ctrl":"vISSELECTED","prop":"Visible"},{"av":"edtavSupplieragbnamewithtags_Visible","ctrl":"vSUPPLIERAGBNAMEWITHTAGS","prop":"Visible"},{"av":"edtSupplierAgbTypeName_Visible","ctrl":"SUPPLIERAGBTYPENAME","prop":"Visible"},{"av":"edtSupplierAgbContactName_Visible","ctrl":"SUPPLIERAGBCONTACTNAME","prop":"Visible"},{"av":"edtSupplierAgbPhone_Visible","ctrl":"SUPPLIERAGBPHONE","prop":"Visible"},{"av":"edtSupplierAgbEmail_Visible","ctrl":"SUPPLIERAGBEMAIL","prop":"Visible"},{"av":"edtavSupplieraddress_Visible","ctrl":"vSUPPLIERADDRESS","prop":"Visible"},{"av":"AV43GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV44GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV45GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV57PreferredSuppliers","fld":"vPREFERREDSUPPLIERS","hsh":true},{"av":"AV49IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV26ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV18GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E126J2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV20OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV21OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV22FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV70ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV74Pgmname","fld":"vPGMNAME","hsh":true},{"av":"A386PreferredAgbOrganisationId","fld":"PREFERREDAGBORGANISATIONID"},{"av":"AV64OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"A381PreferredSupplierAgbId","fld":"PREFERREDSUPPLIERAGBID"},{"av":"AV29TFSupplierAgbName","fld":"vTFSUPPLIERAGBNAME"},{"av":"AV62TFSupplierAgbNameOperator","fld":"vTFSUPPLIERAGBNAMEOPERATOR","pic":"ZZZ9"},{"av":"AV30TFSupplierAgbName_Sel","fld":"vTFSUPPLIERAGBNAME_SEL"},{"av":"AV31TFSupplierAgbTypeName","fld":"vTFSUPPLIERAGBTYPENAME"},{"av":"AV32TFSupplierAgbTypeName_Sel","fld":"vTFSUPPLIERAGBTYPENAME_SEL"},{"av":"AV33TFSupplierAgbContactName","fld":"vTFSUPPLIERAGBCONTACTNAME"},{"av":"AV34TFSupplierAgbContactName_Sel","fld":"vTFSUPPLIERAGBCONTACTNAME_SEL"},{"av":"AV35TFSupplierAgbPhone","fld":"vTFSUPPLIERAGBPHONE"},{"av":"AV36TFSupplierAgbPhone_Sel","fld":"vTFSUPPLIERAGBPHONE_SEL"},{"av":"AV37TFSupplierAgbEmail","fld":"vTFSUPPLIERAGBEMAIL"},{"av":"AV38TFSupplierAgbEmail_Sel","fld":"vTFSUPPLIERAGBEMAIL_SEL"},{"av":"AV57PreferredSuppliers","fld":"vPREFERREDSUPPLIERS","hsh":true},{"av":"AV49IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV46IsAuthorized_SupplierAgbName","fld":"vISAUTHORIZED_SUPPLIERAGBNAME","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E136J2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV20OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV21OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV22FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV70ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV74Pgmname","fld":"vPGMNAME","hsh":true},{"av":"A386PreferredAgbOrganisationId","fld":"PREFERREDAGBORGANISATIONID"},{"av":"AV64OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"A381PreferredSupplierAgbId","fld":"PREFERREDSUPPLIERAGBID"},{"av":"AV29TFSupplierAgbName","fld":"vTFSUPPLIERAGBNAME"},{"av":"AV62TFSupplierAgbNameOperator","fld":"vTFSUPPLIERAGBNAMEOPERATOR","pic":"ZZZ9"},{"av":"AV30TFSupplierAgbName_Sel","fld":"vTFSUPPLIERAGBNAME_SEL"},{"av":"AV31TFSupplierAgbTypeName","fld":"vTFSUPPLIERAGBTYPENAME"},{"av":"AV32TFSupplierAgbTypeName_Sel","fld":"vTFSUPPLIERAGBTYPENAME_SEL"},{"av":"AV33TFSupplierAgbContactName","fld":"vTFSUPPLIERAGBCONTACTNAME"},{"av":"AV34TFSupplierAgbContactName_Sel","fld":"vTFSUPPLIERAGBCONTACTNAME_SEL"},{"av":"AV35TFSupplierAgbPhone","fld":"vTFSUPPLIERAGBPHONE"},{"av":"AV36TFSupplierAgbPhone_Sel","fld":"vTFSUPPLIERAGBPHONE_SEL"},{"av":"AV37TFSupplierAgbEmail","fld":"vTFSUPPLIERAGBEMAIL"},{"av":"AV38TFSupplierAgbEmail_Sel","fld":"vTFSUPPLIERAGBEMAIL_SEL"},{"av":"AV57PreferredSuppliers","fld":"vPREFERREDSUPPLIERS","hsh":true},{"av":"AV49IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV46IsAuthorized_SupplierAgbName","fld":"vISAUTHORIZED_SUPPLIERAGBNAME","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E156J2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV20OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV21OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV22FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV70ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV74Pgmname","fld":"vPGMNAME","hsh":true},{"av":"A386PreferredAgbOrganisationId","fld":"PREFERREDAGBORGANISATIONID"},{"av":"AV64OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"A381PreferredSupplierAgbId","fld":"PREFERREDSUPPLIERAGBID"},{"av":"AV29TFSupplierAgbName","fld":"vTFSUPPLIERAGBNAME"},{"av":"AV62TFSupplierAgbNameOperator","fld":"vTFSUPPLIERAGBNAMEOPERATOR","pic":"ZZZ9"},{"av":"AV30TFSupplierAgbName_Sel","fld":"vTFSUPPLIERAGBNAME_SEL"},{"av":"AV31TFSupplierAgbTypeName","fld":"vTFSUPPLIERAGBTYPENAME"},{"av":"AV32TFSupplierAgbTypeName_Sel","fld":"vTFSUPPLIERAGBTYPENAME_SEL"},{"av":"AV33TFSupplierAgbContactName","fld":"vTFSUPPLIERAGBCONTACTNAME"},{"av":"AV34TFSupplierAgbContactName_Sel","fld":"vTFSUPPLIERAGBCONTACTNAME_SEL"},{"av":"AV35TFSupplierAgbPhone","fld":"vTFSUPPLIERAGBPHONE"},{"av":"AV36TFSupplierAgbPhone_Sel","fld":"vTFSUPPLIERAGBPHONE_SEL"},{"av":"AV37TFSupplierAgbEmail","fld":"vTFSUPPLIERAGBEMAIL"},{"av":"AV38TFSupplierAgbEmail_Sel","fld":"vTFSUPPLIERAGBEMAIL_SEL"},{"av":"AV57PreferredSuppliers","fld":"vPREFERREDSUPPLIERS","hsh":true},{"av":"AV49IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV46IsAuthorized_SupplierAgbName","fld":"vISAUTHORIZED_SUPPLIERAGBNAME","hsh":true},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Selectedcolumnfixedfilter","ctrl":"DDO_GRID","prop":"SelectedColumnFixedFilter"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV20OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV21OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV62TFSupplierAgbNameOperator","fld":"vTFSUPPLIERAGBNAMEOPERATOR","pic":"ZZZ9"},{"av":"AV29TFSupplierAgbName","fld":"vTFSUPPLIERAGBNAME"},{"av":"AV30TFSupplierAgbName_Sel","fld":"vTFSUPPLIERAGBNAME_SEL"},{"av":"AV31TFSupplierAgbTypeName","fld":"vTFSUPPLIERAGBTYPENAME"},{"av":"AV32TFSupplierAgbTypeName_Sel","fld":"vTFSUPPLIERAGBTYPENAME_SEL"},{"av":"AV33TFSupplierAgbContactName","fld":"vTFSUPPLIERAGBCONTACTNAME"},{"av":"AV34TFSupplierAgbContactName_Sel","fld":"vTFSUPPLIERAGBCONTACTNAME_SEL"},{"av":"AV35TFSupplierAgbPhone","fld":"vTFSUPPLIERAGBPHONE"},{"av":"AV36TFSupplierAgbPhone_Sel","fld":"vTFSUPPLIERAGBPHONE_SEL"},{"av":"AV37TFSupplierAgbEmail","fld":"vTFSUPPLIERAGBEMAIL"},{"av":"AV38TFSupplierAgbEmail_Sel","fld":"vTFSUPPLIERAGBEMAIL_SEL"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E196J2","iparms":[{"av":"A306SupplierAGBAddressCountry","fld":"SUPPLIERAGBADDRESSCOUNTRY"},{"av":"A264SupplierAgbAddressCity","fld":"SUPPLIERAGBADDRESSCITY"},{"av":"A263SupplierAgbAddressZipCode","fld":"SUPPLIERAGBADDRESSZIPCODE"},{"av":"A307SupplierAgbAddressLine1","fld":"SUPPLIERAGBADDRESSLINE1"},{"av":"A308SupplierAgbAddressLine2","fld":"SUPPLIERAGBADDRESSLINE2"},{"av":"A49SupplierAgbId","fld":"SUPPLIERAGBID","hsh":true},{"av":"AV57PreferredSuppliers","fld":"vPREFERREDSUPPLIERS","hsh":true},{"av":"AV49IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV46IsAuthorized_SupplierAgbName","fld":"vISAUTHORIZED_SUPPLIERAGBNAME","hsh":true},{"av":"A51SupplierAgbName","fld":"SUPPLIERAGBNAME"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV24SupplierAddress","fld":"vSUPPLIERADDRESS"},{"av":"AV23isSelected","fld":"vISSELECTED"},{"av":"AV59SupplierStatus","fld":"vSUPPLIERSTATUS"},{"av":"cmbavActiongroup"},{"av":"AV66ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"edtavSupplieragbnamewithtags_Link","ctrl":"vSUPPLIERAGBNAMEWITHTAGS","prop":"Link"},{"av":"edtavSupplierstatus_Columnclass","ctrl":"vSUPPLIERSTATUS","prop":"Columnclass"},{"av":"AV63SupplierAgbNameWithTags","fld":"vSUPPLIERAGBNAMEWITHTAGS"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E166J2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV20OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV21OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV22FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV70ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV74Pgmname","fld":"vPGMNAME","hsh":true},{"av":"A386PreferredAgbOrganisationId","fld":"PREFERREDAGBORGANISATIONID"},{"av":"AV64OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"A381PreferredSupplierAgbId","fld":"PREFERREDSUPPLIERAGBID"},{"av":"AV29TFSupplierAgbName","fld":"vTFSUPPLIERAGBNAME"},{"av":"AV62TFSupplierAgbNameOperator","fld":"vTFSUPPLIERAGBNAMEOPERATOR","pic":"ZZZ9"},{"av":"AV30TFSupplierAgbName_Sel","fld":"vTFSUPPLIERAGBNAME_SEL"},{"av":"AV31TFSupplierAgbTypeName","fld":"vTFSUPPLIERAGBTYPENAME"},{"av":"AV32TFSupplierAgbTypeName_Sel","fld":"vTFSUPPLIERAGBTYPENAME_SEL"},{"av":"AV33TFSupplierAgbContactName","fld":"vTFSUPPLIERAGBCONTACTNAME"},{"av":"AV34TFSupplierAgbContactName_Sel","fld":"vTFSUPPLIERAGBCONTACTNAME_SEL"},{"av":"AV35TFSupplierAgbPhone","fld":"vTFSUPPLIERAGBPHONE"},{"av":"AV36TFSupplierAgbPhone_Sel","fld":"vTFSUPPLIERAGBPHONE_SEL"},{"av":"AV37TFSupplierAgbEmail","fld":"vTFSUPPLIERAGBEMAIL"},{"av":"AV38TFSupplierAgbEmail_Sel","fld":"vTFSUPPLIERAGBEMAIL_SEL"},{"av":"AV57PreferredSuppliers","fld":"vPREFERREDSUPPLIERS","hsh":true},{"av":"AV49IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV46IsAuthorized_SupplierAgbName","fld":"vISAUTHORIZED_SUPPLIERAGBNAME","hsh":true},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV70ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"chkavIsselected.Visible","ctrl":"vISSELECTED","prop":"Visible"},{"av":"edtavSupplieragbnamewithtags_Visible","ctrl":"vSUPPLIERAGBNAMEWITHTAGS","prop":"Visible"},{"av":"edtSupplierAgbTypeName_Visible","ctrl":"SUPPLIERAGBTYPENAME","prop":"Visible"},{"av":"edtSupplierAgbContactName_Visible","ctrl":"SUPPLIERAGBCONTACTNAME","prop":"Visible"},{"av":"edtSupplierAgbPhone_Visible","ctrl":"SUPPLIERAGBPHONE","prop":"Visible"},{"av":"edtSupplierAgbEmail_Visible","ctrl":"SUPPLIERAGBEMAIL","prop":"Visible"},{"av":"edtavSupplieraddress_Visible","ctrl":"vSUPPLIERADDRESS","prop":"Visible"},{"av":"AV43GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV44GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV45GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV57PreferredSuppliers","fld":"vPREFERREDSUPPLIERS","hsh":true},{"av":"AV49IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV26ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV18GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E116J2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV20OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV21OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV22FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV70ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV74Pgmname","fld":"vPGMNAME","hsh":true},{"av":"A386PreferredAgbOrganisationId","fld":"PREFERREDAGBORGANISATIONID"},{"av":"AV64OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"A381PreferredSupplierAgbId","fld":"PREFERREDSUPPLIERAGBID"},{"av":"AV29TFSupplierAgbName","fld":"vTFSUPPLIERAGBNAME"},{"av":"AV62TFSupplierAgbNameOperator","fld":"vTFSUPPLIERAGBNAMEOPERATOR","pic":"ZZZ9"},{"av":"AV30TFSupplierAgbName_Sel","fld":"vTFSUPPLIERAGBNAME_SEL"},{"av":"AV31TFSupplierAgbTypeName","fld":"vTFSUPPLIERAGBTYPENAME"},{"av":"AV32TFSupplierAgbTypeName_Sel","fld":"vTFSUPPLIERAGBTYPENAME_SEL"},{"av":"AV33TFSupplierAgbContactName","fld":"vTFSUPPLIERAGBCONTACTNAME"},{"av":"AV34TFSupplierAgbContactName_Sel","fld":"vTFSUPPLIERAGBCONTACTNAME_SEL"},{"av":"AV35TFSupplierAgbPhone","fld":"vTFSUPPLIERAGBPHONE"},{"av":"AV36TFSupplierAgbPhone_Sel","fld":"vTFSUPPLIERAGBPHONE_SEL"},{"av":"AV37TFSupplierAgbEmail","fld":"vTFSUPPLIERAGBEMAIL"},{"av":"AV38TFSupplierAgbEmail_Sel","fld":"vTFSUPPLIERAGBEMAIL_SEL"},{"av":"AV57PreferredSuppliers","fld":"vPREFERREDSUPPLIERS","hsh":true},{"av":"AV49IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV46IsAuthorized_SupplierAgbName","fld":"vISAUTHORIZED_SUPPLIERAGBNAME","hsh":true},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV18GridState","fld":"vGRIDSTATE"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18GridState","fld":"vGRIDSTATE"},{"av":"AV20OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV21OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV22FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV29TFSupplierAgbName","fld":"vTFSUPPLIERAGBNAME"},{"av":"AV30TFSupplierAgbName_Sel","fld":"vTFSUPPLIERAGBNAME_SEL"},{"av":"AV62TFSupplierAgbNameOperator","fld":"vTFSUPPLIERAGBNAMEOPERATOR","pic":"ZZZ9"},{"av":"Ddo_grid_Selectedfixedfilter","ctrl":"DDO_GRID","prop":"SelectedFixedFilter"},{"av":"AV31TFSupplierAgbTypeName","fld":"vTFSUPPLIERAGBTYPENAME"},{"av":"AV32TFSupplierAgbTypeName_Sel","fld":"vTFSUPPLIERAGBTYPENAME_SEL"},{"av":"AV33TFSupplierAgbContactName","fld":"vTFSUPPLIERAGBCONTACTNAME"},{"av":"AV34TFSupplierAgbContactName_Sel","fld":"vTFSUPPLIERAGBCONTACTNAME_SEL"},{"av":"AV35TFSupplierAgbPhone","fld":"vTFSUPPLIERAGBPHONE"},{"av":"AV36TFSupplierAgbPhone_Sel","fld":"vTFSUPPLIERAGBPHONE_SEL"},{"av":"AV37TFSupplierAgbEmail","fld":"vTFSUPPLIERAGBEMAIL"},{"av":"AV38TFSupplierAgbEmail_Sel","fld":"vTFSUPPLIERAGBEMAIL_SEL"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV70ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"chkavIsselected.Visible","ctrl":"vISSELECTED","prop":"Visible"},{"av":"edtavSupplieragbnamewithtags_Visible","ctrl":"vSUPPLIERAGBNAMEWITHTAGS","prop":"Visible"},{"av":"edtSupplierAgbTypeName_Visible","ctrl":"SUPPLIERAGBTYPENAME","prop":"Visible"},{"av":"edtSupplierAgbContactName_Visible","ctrl":"SUPPLIERAGBCONTACTNAME","prop":"Visible"},{"av":"edtSupplierAgbPhone_Visible","ctrl":"SUPPLIERAGBPHONE","prop":"Visible"},{"av":"edtSupplierAgbEmail_Visible","ctrl":"SUPPLIERAGBEMAIL","prop":"Visible"},{"av":"edtavSupplieraddress_Visible","ctrl":"vSUPPLIERADDRESS","prop":"Visible"},{"av":"AV43GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV44GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV45GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV57PreferredSuppliers","fld":"vPREFERREDSUPPLIERS","hsh":true},{"av":"AV49IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV26ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("VACTIONGROUP.CLICK","""{"handler":"E206J2","iparms":[{"av":"cmbavActiongroup"},{"av":"AV66ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV20OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV21OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV22FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV70ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV74Pgmname","fld":"vPGMNAME","hsh":true},{"av":"A386PreferredAgbOrganisationId","fld":"PREFERREDAGBORGANISATIONID"},{"av":"AV64OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"A381PreferredSupplierAgbId","fld":"PREFERREDSUPPLIERAGBID"},{"av":"AV29TFSupplierAgbName","fld":"vTFSUPPLIERAGBNAME"},{"av":"AV62TFSupplierAgbNameOperator","fld":"vTFSUPPLIERAGBNAMEOPERATOR","pic":"ZZZ9"},{"av":"AV30TFSupplierAgbName_Sel","fld":"vTFSUPPLIERAGBNAME_SEL"},{"av":"AV31TFSupplierAgbTypeName","fld":"vTFSUPPLIERAGBTYPENAME"},{"av":"AV32TFSupplierAgbTypeName_Sel","fld":"vTFSUPPLIERAGBTYPENAME_SEL"},{"av":"AV33TFSupplierAgbContactName","fld":"vTFSUPPLIERAGBCONTACTNAME"},{"av":"AV34TFSupplierAgbContactName_Sel","fld":"vTFSUPPLIERAGBCONTACTNAME_SEL"},{"av":"AV35TFSupplierAgbPhone","fld":"vTFSUPPLIERAGBPHONE"},{"av":"AV36TFSupplierAgbPhone_Sel","fld":"vTFSUPPLIERAGBPHONE_SEL"},{"av":"AV37TFSupplierAgbEmail","fld":"vTFSUPPLIERAGBEMAIL"},{"av":"AV38TFSupplierAgbEmail_Sel","fld":"vTFSUPPLIERAGBEMAIL_SEL"},{"av":"AV57PreferredSuppliers","fld":"vPREFERREDSUPPLIERS","hsh":true},{"av":"AV49IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV46IsAuthorized_SupplierAgbName","fld":"vISAUTHORIZED_SUPPLIERAGBNAME","hsh":true},{"av":"A49SupplierAgbId","fld":"SUPPLIERAGBID","hsh":true}]""");
         setEventMetadata("VACTIONGROUP.CLICK",""","oparms":[{"av":"cmbavActiongroup"},{"av":"AV66ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV70ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"chkavIsselected.Visible","ctrl":"vISSELECTED","prop":"Visible"},{"av":"edtavSupplieragbnamewithtags_Visible","ctrl":"vSUPPLIERAGBNAMEWITHTAGS","prop":"Visible"},{"av":"edtSupplierAgbTypeName_Visible","ctrl":"SUPPLIERAGBTYPENAME","prop":"Visible"},{"av":"edtSupplierAgbContactName_Visible","ctrl":"SUPPLIERAGBCONTACTNAME","prop":"Visible"},{"av":"edtSupplierAgbPhone_Visible","ctrl":"SUPPLIERAGBPHONE","prop":"Visible"},{"av":"edtSupplierAgbEmail_Visible","ctrl":"SUPPLIERAGBEMAIL","prop":"Visible"},{"av":"edtavSupplieraddress_Visible","ctrl":"vSUPPLIERADDRESS","prop":"Visible"},{"av":"AV43GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV44GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV45GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV57PreferredSuppliers","fld":"vPREFERREDSUPPLIERS","hsh":true},{"av":"AV49IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV26ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV18GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","""{"handler":"E146J2","iparms":[]""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("VISSELECTED.CLICK","""{"handler":"E216J2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV20OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV21OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV22FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV70ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV74Pgmname","fld":"vPGMNAME","hsh":true},{"av":"A386PreferredAgbOrganisationId","fld":"PREFERREDAGBORGANISATIONID"},{"av":"AV64OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"A381PreferredSupplierAgbId","fld":"PREFERREDSUPPLIERAGBID"},{"av":"AV29TFSupplierAgbName","fld":"vTFSUPPLIERAGBNAME"},{"av":"AV62TFSupplierAgbNameOperator","fld":"vTFSUPPLIERAGBNAMEOPERATOR","pic":"ZZZ9"},{"av":"AV30TFSupplierAgbName_Sel","fld":"vTFSUPPLIERAGBNAME_SEL"},{"av":"AV31TFSupplierAgbTypeName","fld":"vTFSUPPLIERAGBTYPENAME"},{"av":"AV32TFSupplierAgbTypeName_Sel","fld":"vTFSUPPLIERAGBTYPENAME_SEL"},{"av":"AV33TFSupplierAgbContactName","fld":"vTFSUPPLIERAGBCONTACTNAME"},{"av":"AV34TFSupplierAgbContactName_Sel","fld":"vTFSUPPLIERAGBCONTACTNAME_SEL"},{"av":"AV35TFSupplierAgbPhone","fld":"vTFSUPPLIERAGBPHONE"},{"av":"AV36TFSupplierAgbPhone_Sel","fld":"vTFSUPPLIERAGBPHONE_SEL"},{"av":"AV37TFSupplierAgbEmail","fld":"vTFSUPPLIERAGBEMAIL"},{"av":"AV38TFSupplierAgbEmail_Sel","fld":"vTFSUPPLIERAGBEMAIL_SEL"},{"av":"AV57PreferredSuppliers","fld":"vPREFERREDSUPPLIERS","hsh":true},{"av":"AV49IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV46IsAuthorized_SupplierAgbName","fld":"vISAUTHORIZED_SUPPLIERAGBNAME","hsh":true},{"av":"AV23isSelected","fld":"vISSELECTED"},{"av":"AV56Trn_PreferredAgbSupplier","fld":"vTRN_PREFERREDAGBSUPPLIER"},{"av":"A49SupplierAgbId","fld":"SUPPLIERAGBID","hsh":true},{"av":"A384PreferredAgbSupplierId","fld":"PREFERREDAGBSUPPLIERID"}]""");
         setEventMetadata("VISSELECTED.CLICK",""","oparms":[{"av":"AV56Trn_PreferredAgbSupplier","fld":"vTRN_PREFERREDAGBSUPPLIER"},{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV70ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"chkavIsselected.Visible","ctrl":"vISSELECTED","prop":"Visible"},{"av":"edtavSupplieragbnamewithtags_Visible","ctrl":"vSUPPLIERAGBNAMEWITHTAGS","prop":"Visible"},{"av":"edtSupplierAgbTypeName_Visible","ctrl":"SUPPLIERAGBTYPENAME","prop":"Visible"},{"av":"edtSupplierAgbContactName_Visible","ctrl":"SUPPLIERAGBCONTACTNAME","prop":"Visible"},{"av":"edtSupplierAgbPhone_Visible","ctrl":"SUPPLIERAGBPHONE","prop":"Visible"},{"av":"edtSupplierAgbEmail_Visible","ctrl":"SUPPLIERAGBEMAIL","prop":"Visible"},{"av":"edtavSupplieraddress_Visible","ctrl":"vSUPPLIERADDRESS","prop":"Visible"},{"av":"AV43GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV44GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV45GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV57PreferredSuppliers","fld":"vPREFERREDSUPPLIERS","hsh":true},{"av":"AV49IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV26ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV18GridState","fld":"vGRIDSTATE"}]}""");
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
         Ddo_grid_Selectedcolumnfixedfilter = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV22FilterFullText = "";
         AV70ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV74Pgmname = "";
         A386PreferredAgbOrganisationId = Guid.Empty;
         AV64OrganisationId = Guid.Empty;
         A381PreferredSupplierAgbId = Guid.Empty;
         AV29TFSupplierAgbName = "";
         AV30TFSupplierAgbName_Sel = "";
         AV31TFSupplierAgbTypeName = "";
         AV32TFSupplierAgbTypeName_Sel = "";
         AV33TFSupplierAgbContactName = "";
         AV34TFSupplierAgbContactName_Sel = "";
         AV35TFSupplierAgbPhone = "";
         AV36TFSupplierAgbPhone_Sel = "";
         AV37TFSupplierAgbEmail = "";
         AV38TFSupplierAgbEmail_Sel = "";
         AV57PreferredSuppliers = new GxSimpleCollection<Guid>();
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV26ManageFiltersData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV45GridAppliedFilters = "";
         AV39DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV18GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV56Trn_PreferredAgbSupplier = new SdtTrn_PreferredAgbSupplier(context);
         A384PreferredAgbSupplierId = Guid.Empty;
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Gamoauthtoken = "";
         Ddo_grid_Sortedstatus = "";
         Ddo_grid_Selectedfixedfilter = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
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
         AV63SupplierAgbNameWithTags = "";
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
         AV59SupplierStatus = "";
         AV24SupplierAddress = "";
         lV76Wp_organisationagbsuppliersds_1_filterfulltext = "";
         lV77Wp_organisationagbsuppliersds_2_tfsupplieragbname = "";
         lV80Wp_organisationagbsuppliersds_5_tfsupplieragbtypename = "";
         lV82Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname = "";
         lV84Wp_organisationagbsuppliersds_9_tfsupplieragbphone = "";
         lV86Wp_organisationagbsuppliersds_11_tfsupplieragbemail = "";
         AV76Wp_organisationagbsuppliersds_1_filterfulltext = "";
         AV79Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel = "";
         AV77Wp_organisationagbsuppliersds_2_tfsupplieragbname = "";
         AV81Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel = "";
         AV80Wp_organisationagbsuppliersds_5_tfsupplieragbtypename = "";
         AV83Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel = "";
         AV82Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname = "";
         AV85Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel = "";
         AV84Wp_organisationagbsuppliersds_9_tfsupplieragbphone = "";
         AV87Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel = "";
         AV86Wp_organisationagbsuppliersds_11_tfsupplieragbemail = "";
         H006J2_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         H006J2_A57SupplierAgbEmail = new string[] {""} ;
         H006J2_A350SupplierAgbPhoneNumber = new string[] {""} ;
         H006J2_A349SupplierAgbPhoneCode = new string[] {""} ;
         H006J2_A56SupplierAgbPhone = new string[] {""} ;
         H006J2_A55SupplierAgbContactName = new string[] {""} ;
         H006J2_A308SupplierAgbAddressLine2 = new string[] {""} ;
         H006J2_A307SupplierAgbAddressLine1 = new string[] {""} ;
         H006J2_A263SupplierAgbAddressZipCode = new string[] {""} ;
         H006J2_A264SupplierAgbAddressCity = new string[] {""} ;
         H006J2_A306SupplierAGBAddressCountry = new string[] {""} ;
         H006J2_A52SupplierAgbKvkNumber = new string[] {""} ;
         H006J2_A256SupplierAgbTypeName = new string[] {""} ;
         H006J2_A51SupplierAgbName = new string[] {""} ;
         H006J2_A255SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         H006J2_A50SupplierAgbNumber = new string[] {""} ;
         H006J3_AGRID_nRecordCount = new long[1] ;
         AV72successmsg = "";
         AV73websession = context.GetSession();
         AV15HTTPRequest = new GxHttpRequest( context);
         AV40GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV41GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         GXt_guid3 = Guid.Empty;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV25Session = context.GetSession();
         AV68ColumnsSelectorXML = "";
         H006J4_A384PreferredAgbSupplierId = new Guid[] {Guid.Empty} ;
         H006J4_A386PreferredAgbOrganisationId = new Guid[] {Guid.Empty} ;
         H006J4_A381PreferredSupplierAgbId = new Guid[] {Guid.Empty} ;
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV27ManageFiltersXml = "";
         AV69UserCustomValue = "";
         AV71ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV19GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         GXt_char9 = "";
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char4 = "";
         AV16TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         H006J5_A381PreferredSupplierAgbId = new Guid[] {Guid.Empty} ;
         H006J5_A386PreferredAgbOrganisationId = new Guid[] {Guid.Empty} ;
         H006J5_A384PreferredAgbSupplierId = new Guid[] {Guid.Empty} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         gxphoneLink = "";
         GridColumn = new GXWebColumn();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wp_organisationagbsuppliers__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wp_organisationagbsuppliers__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_organisationagbsuppliers__default(),
            new Object[][] {
                new Object[] {
               H006J2_A49SupplierAgbId, H006J2_A57SupplierAgbEmail, H006J2_A350SupplierAgbPhoneNumber, H006J2_A349SupplierAgbPhoneCode, H006J2_A56SupplierAgbPhone, H006J2_A55SupplierAgbContactName, H006J2_A308SupplierAgbAddressLine2, H006J2_A307SupplierAgbAddressLine1, H006J2_A263SupplierAgbAddressZipCode, H006J2_A264SupplierAgbAddressCity,
               H006J2_A306SupplierAGBAddressCountry, H006J2_A52SupplierAgbKvkNumber, H006J2_A256SupplierAgbTypeName, H006J2_A51SupplierAgbName, H006J2_A255SupplierAgbTypeId, H006J2_A50SupplierAgbNumber
               }
               , new Object[] {
               H006J3_AGRID_nRecordCount
               }
               , new Object[] {
               H006J4_A384PreferredAgbSupplierId, H006J4_A386PreferredAgbOrganisationId, H006J4_A381PreferredSupplierAgbId
               }
               , new Object[] {
               H006J5_A381PreferredSupplierAgbId, H006J5_A386PreferredAgbOrganisationId, H006J5_A384PreferredAgbSupplierId
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV74Pgmname = "WP_OrganisationAGBSuppliers";
         /* GeneXus formulas. */
         AV74Pgmname = "WP_OrganisationAGBSuppliers";
         edtavSupplieragbnamewithtags_Enabled = 0;
         edtavSupplierstatus_Enabled = 0;
         edtavSupplieraddress_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV20OrderedBy ;
      private short AV28ManageFiltersExecutionStep ;
      private short AV62TFSupplierAgbNameOperator ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV66ActionGroup ;
      private short nCmpId ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV78Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator ;
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
      private int bttBtnsubscriptions_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavSupplieragbnamewithtags_Enabled ;
      private int edtavSupplierstatus_Enabled ;
      private int edtavSupplieraddress_Enabled ;
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
      private int edtavSupplieragbnamewithtags_Visible ;
      private int edtSupplierAgbTypeName_Visible ;
      private int edtSupplierAgbContactName_Visible ;
      private int edtSupplierAgbPhone_Visible ;
      private int edtSupplierAgbEmail_Visible ;
      private int edtavSupplieraddress_Visible ;
      private int AV42PageToGo ;
      private int AV88GXV1 ;
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
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Selectedcolumnfixedfilter ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_37_idx="0001" ;
      private string AV74Pgmname ;
      private string AV35TFSupplierAgbPhone ;
      private string AV36TFSupplierAgbPhone_Sel ;
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
      private string Ddo_grid_Fixedfilters ;
      private string Ddo_grid_Selectedfixedfilter ;
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
      private string chkavIsselected_Internalname ;
      private string edtSupplierAgbId_Internalname ;
      private string edtSupplierAgbNumber_Internalname ;
      private string edtSupplierAgbTypeId_Internalname ;
      private string edtavSupplieragbnamewithtags_Internalname ;
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
      private string AV59SupplierStatus ;
      private string edtavSupplierstatus_Internalname ;
      private string edtavSupplieraddress_Internalname ;
      private string cmbavActiongroup_Internalname ;
      private string lV84Wp_organisationagbsuppliersds_9_tfsupplieragbphone ;
      private string AV85Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel ;
      private string AV84Wp_organisationagbsuppliersds_9_tfsupplieragbphone ;
      private string edtavSupplieragbnamewithtags_Link ;
      private string GXEncryptionTmp ;
      private string edtavSupplierstatus_Columnclass ;
      private string GXt_char9 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char4 ;
      private string sGXsfl_37_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string ROClassString ;
      private string edtSupplierAgbId_Jsonclick ;
      private string edtSupplierAgbNumber_Jsonclick ;
      private string edtSupplierAgbTypeId_Jsonclick ;
      private string edtavSupplieragbnamewithtags_Jsonclick ;
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
      private string edtavSupplierstatus_Jsonclick ;
      private string edtavSupplieraddress_Jsonclick ;
      private string cmbavActiongroup_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV21OrderedDsc ;
      private bool AV49IsAuthorized_Display ;
      private bool AV46IsAuthorized_SupplierAgbName ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool bGXsfl_37_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV23isSelected ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool GXt_boolean1 ;
      private string AV68ColumnsSelectorXML ;
      private string AV27ManageFiltersXml ;
      private string AV69UserCustomValue ;
      private string AV22FilterFullText ;
      private string AV29TFSupplierAgbName ;
      private string AV30TFSupplierAgbName_Sel ;
      private string AV31TFSupplierAgbTypeName ;
      private string AV32TFSupplierAgbTypeName_Sel ;
      private string AV33TFSupplierAgbContactName ;
      private string AV34TFSupplierAgbContactName_Sel ;
      private string AV37TFSupplierAgbEmail ;
      private string AV38TFSupplierAgbEmail_Sel ;
      private string AV45GridAppliedFilters ;
      private string A50SupplierAgbNumber ;
      private string AV63SupplierAgbNameWithTags ;
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
      private string AV24SupplierAddress ;
      private string lV76Wp_organisationagbsuppliersds_1_filterfulltext ;
      private string lV77Wp_organisationagbsuppliersds_2_tfsupplieragbname ;
      private string lV80Wp_organisationagbsuppliersds_5_tfsupplieragbtypename ;
      private string lV82Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname ;
      private string lV86Wp_organisationagbsuppliersds_11_tfsupplieragbemail ;
      private string AV76Wp_organisationagbsuppliersds_1_filterfulltext ;
      private string AV79Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel ;
      private string AV77Wp_organisationagbsuppliersds_2_tfsupplieragbname ;
      private string AV81Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel ;
      private string AV80Wp_organisationagbsuppliersds_5_tfsupplieragbtypename ;
      private string AV83Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel ;
      private string AV82Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname ;
      private string AV87Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel ;
      private string AV86Wp_organisationagbsuppliersds_11_tfsupplieragbemail ;
      private string AV72successmsg ;
      private Guid A386PreferredAgbOrganisationId ;
      private Guid AV64OrganisationId ;
      private Guid A381PreferredSupplierAgbId ;
      private Guid A384PreferredAgbSupplierId ;
      private Guid A49SupplierAgbId ;
      private Guid A255SupplierAgbTypeId ;
      private Guid GXt_guid3 ;
      private IGxSession AV73websession ;
      private IGxSession AV25Session ;
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
      private GxHttpRequest AV15HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavIsselected ;
      private GXCombobox cmbavActiongroup ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV70ColumnsSelector ;
      private GxSimpleCollection<Guid> AV57PreferredSuppliers ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV26ManageFiltersData ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV39DDO_TitleSettingsIcons ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV18GridState ;
      private SdtTrn_PreferredAgbSupplier AV56Trn_PreferredAgbSupplier ;
      private IDataStoreProvider pr_default ;
      private Guid[] H006J2_A49SupplierAgbId ;
      private string[] H006J2_A57SupplierAgbEmail ;
      private string[] H006J2_A350SupplierAgbPhoneNumber ;
      private string[] H006J2_A349SupplierAgbPhoneCode ;
      private string[] H006J2_A56SupplierAgbPhone ;
      private string[] H006J2_A55SupplierAgbContactName ;
      private string[] H006J2_A308SupplierAgbAddressLine2 ;
      private string[] H006J2_A307SupplierAgbAddressLine1 ;
      private string[] H006J2_A263SupplierAgbAddressZipCode ;
      private string[] H006J2_A264SupplierAgbAddressCity ;
      private string[] H006J2_A306SupplierAGBAddressCountry ;
      private string[] H006J2_A52SupplierAgbKvkNumber ;
      private string[] H006J2_A256SupplierAgbTypeName ;
      private string[] H006J2_A51SupplierAgbName ;
      private Guid[] H006J2_A255SupplierAgbTypeId ;
      private string[] H006J2_A50SupplierAgbNumber ;
      private long[] H006J3_AGRID_nRecordCount ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV40GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV41GAMErrors ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private Guid[] H006J4_A384PreferredAgbSupplierId ;
      private Guid[] H006J4_A386PreferredAgbOrganisationId ;
      private Guid[] H006J4_A381PreferredSupplierAgbId ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV71ColumnsSelectorAux ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV19GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV16TrnContext ;
      private Guid[] H006J5_A381PreferredSupplierAgbId ;
      private Guid[] H006J5_A386PreferredAgbOrganisationId ;
      private Guid[] H006J5_A384PreferredAgbSupplierId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wp_organisationagbsuppliers__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wp_organisationagbsuppliers__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wp_organisationagbsuppliers__default : DataStoreHelperBase, IDataStoreHelper
{
   protected Object[] conditional_H006J2( IGxContext context ,
                                          string AV76Wp_organisationagbsuppliersds_1_filterfulltext ,
                                          string AV79Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel ,
                                          string AV77Wp_organisationagbsuppliersds_2_tfsupplieragbname ,
                                          short AV78Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator ,
                                          string AV81Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel ,
                                          string AV80Wp_organisationagbsuppliersds_5_tfsupplieragbtypename ,
                                          string AV83Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel ,
                                          string AV82Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname ,
                                          string AV85Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel ,
                                          string AV84Wp_organisationagbsuppliersds_9_tfsupplieragbphone ,
                                          string AV87Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel ,
                                          string AV86Wp_organisationagbsuppliersds_11_tfsupplieragbemail ,
                                          string A51SupplierAgbName ,
                                          string A256SupplierAgbTypeName ,
                                          string A55SupplierAgbContactName ,
                                          string A56SupplierAgbPhone ,
                                          string A57SupplierAgbEmail ,
                                          bool AV23isSelected ,
                                          short AV20OrderedBy ,
                                          bool AV21OrderedDsc )
   {
      System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
      string scmdbuf;
      short[] GXv_int10 = new short[19];
      Object[] GXv_Object11 = new Object[2];
      string sSelectString;
      string sFromString;
      string sOrderString;
      sSelectString = " T1.SupplierAgbId, T1.SupplierAgbEmail, T1.SupplierAgbPhoneNumber, T1.SupplierAgbPhoneCode, T1.SupplierAgbPhone, T1.SupplierAgbContactName, T1.SupplierAgbAddressLine2, T1.SupplierAgbAddressLine1, T1.SupplierAgbAddressZipCode, T1.SupplierAgbAddressCity, T1.SupplierAGBAddressCountry, T1.SupplierAgbKvkNumber, T2.SupplierAgbTypeName, T1.SupplierAgbName, T1.SupplierAgbTypeId, T1.SupplierAgbNumber";
      sFromString = " FROM (Trn_SupplierAGB T1 INNER JOIN Trn_SupplierAgbType T2 ON T2.SupplierAgbTypeId = T1.SupplierAgbTypeId)";
      sOrderString = "";
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Wp_organisationagbsuppliersds_1_filterfulltext)) )
      {
         AddWhere(sWhereString, "(( LOWER(T1.SupplierAgbName) like '%' || LOWER(:lV76Wp_organisationagbsuppliersds_1_filterfulltext)) or ( LOWER(T2.SupplierAgbTypeName) like '%' || LOWER(:lV76Wp_organisationagbsuppliersds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbContactName) like '%' || LOWER(:lV76Wp_organisationagbsuppliersds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbPhone) like '%' || LOWER(:lV76Wp_organisationagbsuppliersds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbEmail) like '%' || LOWER(:lV76Wp_organisationagbsuppliersds_1_filterfulltext)))");
      }
      else
      {
         GXv_int10[0] = 1;
         GXv_int10[1] = 1;
         GXv_int10[2] = 1;
         GXv_int10[3] = 1;
         GXv_int10[4] = 1;
      }
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wp_organisationagbsuppliersds_2_tfsupplieragbname)) ) )
      {
         AddWhere(sWhereString, "(T1.SupplierAgbName like :lV77Wp_organisationagbsuppliersds_2_tfsupplieragbname)");
      }
      else
      {
         GXv_int10[5] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel)) && ! ( StringUtil.StrCmp(AV79Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(T1.SupplierAgbName = ( :AV79Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel))");
      }
      else
      {
         GXv_int10[6] = 1;
      }
      if ( StringUtil.StrCmp(AV79Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbName))=0))");
      }
      if ( AV78Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator == 1 )
      {
         AddWhere(sWhereString, "(:AV23isSelected = TRUE)");
      }
      else
      {
         GXv_int10[7] = 1;
      }
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wp_organisationagbsuppliersds_5_tfsupplieragbtypename)) ) )
      {
         AddWhere(sWhereString, "(T2.SupplierAgbTypeName like :lV80Wp_organisationagbsuppliersds_5_tfsupplieragbtypename)");
      }
      else
      {
         GXv_int10[8] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel)) && ! ( StringUtil.StrCmp(AV81Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(T2.SupplierAgbTypeName = ( :AV81Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel))");
      }
      else
      {
         GXv_int10[9] = 1;
      }
      if ( StringUtil.StrCmp(AV81Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierAgbTypeName))=0))");
      }
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname)) ) )
      {
         AddWhere(sWhereString, "(T1.SupplierAgbContactName like :lV82Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname)");
      }
      else
      {
         GXv_int10[10] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel)) && ! ( StringUtil.StrCmp(AV83Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(T1.SupplierAgbContactName = ( :AV83Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_se))");
      }
      else
      {
         GXv_int10[11] = 1;
      }
      if ( StringUtil.StrCmp(AV83Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbContactName))=0))");
      }
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wp_organisationagbsuppliersds_9_tfsupplieragbphone)) ) )
      {
         AddWhere(sWhereString, "(T1.SupplierAgbPhone like :lV84Wp_organisationagbsuppliersds_9_tfsupplieragbphone)");
      }
      else
      {
         GXv_int10[12] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel)) && ! ( StringUtil.StrCmp(AV85Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(T1.SupplierAgbPhone = ( :AV85Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel))");
      }
      else
      {
         GXv_int10[13] = 1;
      }
      if ( StringUtil.StrCmp(AV85Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbPhone))=0))");
      }
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wp_organisationagbsuppliersds_11_tfsupplieragbemail)) ) )
      {
         AddWhere(sWhereString, "(T1.SupplierAgbEmail like :lV86Wp_organisationagbsuppliersds_11_tfsupplieragbemail)");
      }
      else
      {
         GXv_int10[14] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel)) && ! ( StringUtil.StrCmp(AV87Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(T1.SupplierAgbEmail = ( :AV87Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel))");
      }
      else
      {
         GXv_int10[15] = 1;
      }
      if ( StringUtil.StrCmp(AV87Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbEmail))=0))");
      }
      if ( ( AV20OrderedBy == 1 ) && ! AV21OrderedDsc )
      {
         sOrderString += " ORDER BY T1.SupplierAgbName, T1.SupplierAgbId";
      }
      else if ( ( AV20OrderedBy == 1 ) && ( AV21OrderedDsc ) )
      {
         sOrderString += " ORDER BY T1.SupplierAgbName DESC, T1.SupplierAgbId";
      }
      else if ( ( AV20OrderedBy == 2 ) && ! AV21OrderedDsc )
      {
         sOrderString += " ORDER BY T2.SupplierAgbTypeName, T1.SupplierAgbId";
      }
      else if ( ( AV20OrderedBy == 2 ) && ( AV21OrderedDsc ) )
      {
         sOrderString += " ORDER BY T2.SupplierAgbTypeName DESC, T1.SupplierAgbId";
      }
      else if ( ( AV20OrderedBy == 3 ) && ! AV21OrderedDsc )
      {
         sOrderString += " ORDER BY T1.SupplierAgbContactName, T1.SupplierAgbId";
      }
      else if ( ( AV20OrderedBy == 3 ) && ( AV21OrderedDsc ) )
      {
         sOrderString += " ORDER BY T1.SupplierAgbContactName DESC, T1.SupplierAgbId";
      }
      else if ( ( AV20OrderedBy == 4 ) && ! AV21OrderedDsc )
      {
         sOrderString += " ORDER BY T1.SupplierAgbPhone, T1.SupplierAgbId";
      }
      else if ( ( AV20OrderedBy == 4 ) && ( AV21OrderedDsc ) )
      {
         sOrderString += " ORDER BY T1.SupplierAgbPhone DESC, T1.SupplierAgbId";
      }
      else if ( ( AV20OrderedBy == 5 ) && ! AV21OrderedDsc )
      {
         sOrderString += " ORDER BY T1.SupplierAgbEmail, T1.SupplierAgbId";
      }
      else if ( ( AV20OrderedBy == 5 ) && ( AV21OrderedDsc ) )
      {
         sOrderString += " ORDER BY T1.SupplierAgbEmail DESC, T1.SupplierAgbId";
      }
      else if ( true )
      {
         sOrderString += " ORDER BY T1.SupplierAgbId";
      }
      scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
      GXv_Object11[0] = scmdbuf;
      GXv_Object11[1] = GXv_int10;
      return GXv_Object11 ;
   }

   protected Object[] conditional_H006J3( IGxContext context ,
                                          string AV76Wp_organisationagbsuppliersds_1_filterfulltext ,
                                          string AV79Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel ,
                                          string AV77Wp_organisationagbsuppliersds_2_tfsupplieragbname ,
                                          short AV78Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator ,
                                          string AV81Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel ,
                                          string AV80Wp_organisationagbsuppliersds_5_tfsupplieragbtypename ,
                                          string AV83Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel ,
                                          string AV82Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname ,
                                          string AV85Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel ,
                                          string AV84Wp_organisationagbsuppliersds_9_tfsupplieragbphone ,
                                          string AV87Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel ,
                                          string AV86Wp_organisationagbsuppliersds_11_tfsupplieragbemail ,
                                          string A51SupplierAgbName ,
                                          string A256SupplierAgbTypeName ,
                                          string A55SupplierAgbContactName ,
                                          string A56SupplierAgbPhone ,
                                          string A57SupplierAgbEmail ,
                                          bool AV23isSelected ,
                                          short AV20OrderedBy ,
                                          bool AV21OrderedDsc )
   {
      System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
      string scmdbuf;
      short[] GXv_int12 = new short[16];
      Object[] GXv_Object13 = new Object[2];
      scmdbuf = "SELECT COUNT(*) FROM (Trn_SupplierAGB T1 INNER JOIN Trn_SupplierAgbType T2 ON T2.SupplierAgbTypeId = T1.SupplierAgbTypeId)";
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Wp_organisationagbsuppliersds_1_filterfulltext)) )
      {
         AddWhere(sWhereString, "(( LOWER(T1.SupplierAgbName) like '%' || LOWER(:lV76Wp_organisationagbsuppliersds_1_filterfulltext)) or ( LOWER(T2.SupplierAgbTypeName) like '%' || LOWER(:lV76Wp_organisationagbsuppliersds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbContactName) like '%' || LOWER(:lV76Wp_organisationagbsuppliersds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbPhone) like '%' || LOWER(:lV76Wp_organisationagbsuppliersds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbEmail) like '%' || LOWER(:lV76Wp_organisationagbsuppliersds_1_filterfulltext)))");
      }
      else
      {
         GXv_int12[0] = 1;
         GXv_int12[1] = 1;
         GXv_int12[2] = 1;
         GXv_int12[3] = 1;
         GXv_int12[4] = 1;
      }
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wp_organisationagbsuppliersds_2_tfsupplieragbname)) ) )
      {
         AddWhere(sWhereString, "(T1.SupplierAgbName like :lV77Wp_organisationagbsuppliersds_2_tfsupplieragbname)");
      }
      else
      {
         GXv_int12[5] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel)) && ! ( StringUtil.StrCmp(AV79Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(T1.SupplierAgbName = ( :AV79Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel))");
      }
      else
      {
         GXv_int12[6] = 1;
      }
      if ( StringUtil.StrCmp(AV79Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbName))=0))");
      }
      if ( AV78Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator == 1 )
      {
         AddWhere(sWhereString, "(:AV23isSelected = TRUE)");
      }
      else
      {
         GXv_int12[7] = 1;
      }
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wp_organisationagbsuppliersds_5_tfsupplieragbtypename)) ) )
      {
         AddWhere(sWhereString, "(T2.SupplierAgbTypeName like :lV80Wp_organisationagbsuppliersds_5_tfsupplieragbtypename)");
      }
      else
      {
         GXv_int12[8] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel)) && ! ( StringUtil.StrCmp(AV81Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(T2.SupplierAgbTypeName = ( :AV81Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel))");
      }
      else
      {
         GXv_int12[9] = 1;
      }
      if ( StringUtil.StrCmp(AV81Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierAgbTypeName))=0))");
      }
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname)) ) )
      {
         AddWhere(sWhereString, "(T1.SupplierAgbContactName like :lV82Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname)");
      }
      else
      {
         GXv_int12[10] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel)) && ! ( StringUtil.StrCmp(AV83Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(T1.SupplierAgbContactName = ( :AV83Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_se))");
      }
      else
      {
         GXv_int12[11] = 1;
      }
      if ( StringUtil.StrCmp(AV83Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbContactName))=0))");
      }
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wp_organisationagbsuppliersds_9_tfsupplieragbphone)) ) )
      {
         AddWhere(sWhereString, "(T1.SupplierAgbPhone like :lV84Wp_organisationagbsuppliersds_9_tfsupplieragbphone)");
      }
      else
      {
         GXv_int12[12] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel)) && ! ( StringUtil.StrCmp(AV85Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(T1.SupplierAgbPhone = ( :AV85Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel))");
      }
      else
      {
         GXv_int12[13] = 1;
      }
      if ( StringUtil.StrCmp(AV85Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbPhone))=0))");
      }
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wp_organisationagbsuppliersds_11_tfsupplieragbemail)) ) )
      {
         AddWhere(sWhereString, "(T1.SupplierAgbEmail like :lV86Wp_organisationagbsuppliersds_11_tfsupplieragbemail)");
      }
      else
      {
         GXv_int12[14] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel)) && ! ( StringUtil.StrCmp(AV87Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(T1.SupplierAgbEmail = ( :AV87Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel))");
      }
      else
      {
         GXv_int12[15] = 1;
      }
      if ( StringUtil.StrCmp(AV87Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbEmail))=0))");
      }
      scmdbuf += sWhereString;
      if ( ( AV20OrderedBy == 1 ) && ! AV21OrderedDsc )
      {
         scmdbuf += "";
      }
      else if ( ( AV20OrderedBy == 1 ) && ( AV21OrderedDsc ) )
      {
         scmdbuf += "";
      }
      else if ( ( AV20OrderedBy == 2 ) && ! AV21OrderedDsc )
      {
         scmdbuf += "";
      }
      else if ( ( AV20OrderedBy == 2 ) && ( AV21OrderedDsc ) )
      {
         scmdbuf += "";
      }
      else if ( ( AV20OrderedBy == 3 ) && ! AV21OrderedDsc )
      {
         scmdbuf += "";
      }
      else if ( ( AV20OrderedBy == 3 ) && ( AV21OrderedDsc ) )
      {
         scmdbuf += "";
      }
      else if ( ( AV20OrderedBy == 4 ) && ! AV21OrderedDsc )
      {
         scmdbuf += "";
      }
      else if ( ( AV20OrderedBy == 4 ) && ( AV21OrderedDsc ) )
      {
         scmdbuf += "";
      }
      else if ( ( AV20OrderedBy == 5 ) && ! AV21OrderedDsc )
      {
         scmdbuf += "";
      }
      else if ( ( AV20OrderedBy == 5 ) && ( AV21OrderedDsc ) )
      {
         scmdbuf += "";
      }
      else if ( true )
      {
         scmdbuf += "";
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
                  return conditional_H006J2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (bool)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] );
            case 1 :
                  return conditional_H006J3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (bool)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] );
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
      ,new ForEachCursor(def[3])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmH006J4;
       prmH006J4 = new Object[] {
       new ParDef("AV64OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmH006J5;
       prmH006J5 = new Object[] {
       new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV64OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmH006J2;
       prmH006J2 = new Object[] {
       new ParDef("lV76Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
       new ParDef("lV76Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
       new ParDef("lV76Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
       new ParDef("lV76Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
       new ParDef("lV76Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
       new ParDef("lV77Wp_organisationagbsuppliersds_2_tfsupplieragbname",GXType.VarChar,100,0) ,
       new ParDef("AV79Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel",GXType.VarChar,100,0) ,
       new ParDef("AV23isSelected",GXType.Boolean,4,0) ,
       new ParDef("lV80Wp_organisationagbsuppliersds_5_tfsupplieragbtypename",GXType.VarChar,100,0) ,
       new ParDef("AV81Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel",GXType.VarChar,100,0) ,
       new ParDef("lV82Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname",GXType.VarChar,100,0) ,
       new ParDef("AV83Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_se",GXType.VarChar,100,0) ,
       new ParDef("lV84Wp_organisationagbsuppliersds_9_tfsupplieragbphone",GXType.Char,20,0) ,
       new ParDef("AV85Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel",GXType.Char,20,0) ,
       new ParDef("lV86Wp_organisationagbsuppliersds_11_tfsupplieragbemail",GXType.VarChar,100,0) ,
       new ParDef("AV87Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel",GXType.VarChar,100,0) ,
       new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
       new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
       new ParDef("GXPagingTo2",GXType.Int32,9,0)
       };
       Object[] prmH006J3;
       prmH006J3 = new Object[] {
       new ParDef("lV76Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
       new ParDef("lV76Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
       new ParDef("lV76Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
       new ParDef("lV76Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
       new ParDef("lV76Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
       new ParDef("lV77Wp_organisationagbsuppliersds_2_tfsupplieragbname",GXType.VarChar,100,0) ,
       new ParDef("AV79Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel",GXType.VarChar,100,0) ,
       new ParDef("AV23isSelected",GXType.Boolean,4,0) ,
       new ParDef("lV80Wp_organisationagbsuppliersds_5_tfsupplieragbtypename",GXType.VarChar,100,0) ,
       new ParDef("AV81Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel",GXType.VarChar,100,0) ,
       new ParDef("lV82Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname",GXType.VarChar,100,0) ,
       new ParDef("AV83Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_se",GXType.VarChar,100,0) ,
       new ParDef("lV84Wp_organisationagbsuppliersds_9_tfsupplieragbphone",GXType.Char,20,0) ,
       new ParDef("AV85Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel",GXType.Char,20,0) ,
       new ParDef("lV86Wp_organisationagbsuppliersds_11_tfsupplieragbemail",GXType.VarChar,100,0) ,
       new ParDef("AV87Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel",GXType.VarChar,100,0)
       };
       def= new CursorDef[] {
           new CursorDef("H006J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006J2,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H006J3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006J3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H006J4", "SELECT PreferredAgbSupplierId, PreferredAgbOrganisationId, PreferredSupplierAgbId FROM Trn_PreferredAgbSupplier WHERE PreferredAgbOrganisationId = :AV64OrganisationId ORDER BY PreferredAgbSupplierId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006J4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H006J5", "SELECT PreferredSupplierAgbId, PreferredAgbOrganisationId, PreferredAgbSupplierId FROM Trn_PreferredAgbSupplier WHERE (PreferredSupplierAgbId = :SupplierAgbId) AND (PreferredAgbOrganisationId = :AV64OrganisationId) ORDER BY PreferredAgbSupplierId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006J5,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((Guid[]) buf[14])[0] = rslt.getGuid(15);
             ((string[]) buf[15])[0] = rslt.getVarchar(16);
             return;
          case 1 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
    }
 }

}

}
