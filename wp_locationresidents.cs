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
   public class wp_locationresidents : GXDataArea
   {
      public wp_locationresidents( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_locationresidents( IGxContext context )
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
         dynavLocationoption = new GXCombobox();
         cmbavSdt_residents__residentsalutation = new GXCombobox();
         cmbavSdt_residents__residentgender = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vLOCATIONOPTION") == 0 )
            {
               ajax_req_read_hidden_sdt(GetNextPar( ), AV29WWPContext);
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvLOCATIONOPTION5J2( AV29WWPContext) ;
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
         nRC_GXsfl_50 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_50"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_50_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_50_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_50_idx = GetPar( "sGXsfl_50_idx");
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
         AV18ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV38ColumnsSelector);
         AV99Pgmname = GetPar( "Pgmname");
         AV54OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV55OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV7FilterFullText = GetPar( "FilterFullText");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV22SDT_Residents);
         AV69ResidentPackageId = StringUtil.StrToGuid( GetPar( "ResidentPackageId"));
         A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV29WWPContext);
         AV101Udparg1 = StringUtil.StrToGuid( GetPar( "Udparg1"));
         A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
         dynavLocationoption.FromJSonString( GetNextPar( ));
         AV16LocationOption = StringUtil.StrToGuid( GetPar( "LocationOption"));
         A62ResidentId = StringUtil.StrToGuid( GetPar( "ResidentId"));
         A72ResidentSalutation = GetPar( "ResidentSalutation");
         A63ResidentBsnNumber = GetPar( "ResidentBsnNumber");
         A64ResidentGivenName = GetPar( "ResidentGivenName");
         A65ResidentLastName = GetPar( "ResidentLastName");
         A66ResidentInitials = GetPar( "ResidentInitials");
         A67ResidentEmail = GetPar( "ResidentEmail");
         A68ResidentGender = GetPar( "ResidentGender");
         A312ResidentCountry = GetPar( "ResidentCountry");
         A313ResidentCity = GetPar( "ResidentCity");
         A314ResidentZipCode = GetPar( "ResidentZipCode");
         A315ResidentAddressLine1 = GetPar( "ResidentAddressLine1");
         A316ResidentAddressLine2 = GetPar( "ResidentAddressLine2");
         A70ResidentPhone = GetPar( "ResidentPhone");
         A97ResidentTypeName = GetPar( "ResidentTypeName");
         A98MedicalIndicationId = StringUtil.StrToGuid( GetPar( "MedicalIndicationId"));
         n98MedicalIndicationId = false;
         A99MedicalIndicationName = GetPar( "MedicalIndicationName");
         A73ResidentBirthDate = context.localUtil.ParseDateParm( GetPar( "ResidentBirthDate"));
         A96ResidentTypeId = StringUtil.StrToGuid( GetPar( "ResidentTypeId"));
         n96ResidentTypeId = false;
         A71ResidentGUID = GetPar( "ResidentGUID");
         A527ResidentPackageId = StringUtil.StrToGuid( GetPar( "ResidentPackageId"));
         n527ResidentPackageId = false;
         AV33IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV41IsAuthorized_SDT_Residents = StringUtil.StrToBool( GetPar( "IsAuthorized_SDT_Residents"));
         AV78ResidentTitle = GetPar( "ResidentTitle");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV18ManageFiltersExecutionStep, AV38ColumnsSelector, AV99Pgmname, AV54OrderedBy, AV55OrderedDsc, AV7FilterFullText, AV22SDT_Residents, AV69ResidentPackageId, A11OrganisationId, AV29WWPContext, AV101Udparg1, A29LocationId, AV16LocationOption, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A312ResidentCountry, A313ResidentCity, A314ResidentZipCode, A315ResidentAddressLine1, A316ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, A527ResidentPackageId, AV33IsAuthorized_Delete, AV41IsAuthorized_SDT_Residents, AV78ResidentTitle) ;
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
            return "wp_locationresidents_Execute" ;
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
         PA5J2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5J2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_locationresidents.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV99Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV99Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV29WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV29WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV29WWPContext, context));
         GxWebStd.gx_hidden_field( context, "vUDPARG1", AV101Udparg1.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG1", GetSecureSignedToken( "", AV101Udparg1, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV33IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV33IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_SDT_RESIDENTS", AV41IsAuthorized_SDT_Residents);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SDT_RESIDENTS", GetSecureSignedToken( "", AV41IsAuthorized_SDT_Residents, context));
         GxWebStd.gx_hidden_field( context, "vRESIDENTTITLE", AV78ResidentTitle);
         GxWebStd.gx_hidden_field( context, "gxhash_vRESIDENTTITLE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV78ResidentTitle, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdt_residents", AV22SDT_Residents);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdt_residents", AV22SDT_Residents);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_50", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_50), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vRESIDENTPACKAGEID_DATA", AV70ResidentPackageId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vRESIDENTPACKAGEID_DATA", AV70ResidentPackageId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV17ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV17ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV9GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV40DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV40DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV38ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV38ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV99Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV99Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV54OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV55OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDT_RESIDENTS", AV22SDT_Residents);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDT_RESIDENTS", AV22SDT_Residents);
         }
         GxWebStd.gx_hidden_field( context, "ORGANISATIONID", A11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "vUDPARG1", AV101Udparg1.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG1", GetSecureSignedToken( "", AV101Udparg1, context));
         GxWebStd.gx_hidden_field( context, "LOCATIONID", A29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "RESIDENTID", A62ResidentId.ToString());
         GxWebStd.gx_hidden_field( context, "RESIDENTSALUTATION", StringUtil.RTrim( A72ResidentSalutation));
         GxWebStd.gx_hidden_field( context, "RESIDENTBSNNUMBER", A63ResidentBsnNumber);
         GxWebStd.gx_hidden_field( context, "RESIDENTGIVENNAME", A64ResidentGivenName);
         GxWebStd.gx_hidden_field( context, "RESIDENTLASTNAME", A65ResidentLastName);
         GxWebStd.gx_hidden_field( context, "RESIDENTINITIALS", StringUtil.RTrim( A66ResidentInitials));
         GxWebStd.gx_hidden_field( context, "RESIDENTEMAIL", A67ResidentEmail);
         GxWebStd.gx_hidden_field( context, "RESIDENTGENDER", A68ResidentGender);
         GxWebStd.gx_hidden_field( context, "RESIDENTCOUNTRY", A312ResidentCountry);
         GxWebStd.gx_hidden_field( context, "RESIDENTCITY", A313ResidentCity);
         GxWebStd.gx_hidden_field( context, "RESIDENTZIPCODE", A314ResidentZipCode);
         GxWebStd.gx_hidden_field( context, "RESIDENTADDRESSLINE1", A315ResidentAddressLine1);
         GxWebStd.gx_hidden_field( context, "RESIDENTADDRESSLINE2", A316ResidentAddressLine2);
         GxWebStd.gx_hidden_field( context, "RESIDENTPHONE", StringUtil.RTrim( A70ResidentPhone));
         GxWebStd.gx_hidden_field( context, "RESIDENTTYPENAME", A97ResidentTypeName);
         GxWebStd.gx_hidden_field( context, "MEDICALINDICATIONID", A98MedicalIndicationId.ToString());
         GxWebStd.gx_hidden_field( context, "MEDICALINDICATIONNAME", A99MedicalIndicationName);
         GxWebStd.gx_hidden_field( context, "RESIDENTBIRTHDATE", context.localUtil.DToC( A73ResidentBirthDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "RESIDENTTYPEID", A96ResidentTypeId.ToString());
         GxWebStd.gx_hidden_field( context, "RESIDENTGUID", A71ResidentGUID);
         GxWebStd.gx_hidden_field( context, "RESIDENTPACKAGEID", A527ResidentPackageId.ToString());
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV33IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV33IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_SDT_RESIDENTS", AV41IsAuthorized_SDT_Residents);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SDT_RESIDENTS", GetSecureSignedToken( "", AV41IsAuthorized_SDT_Residents, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV12GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV12GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISSENT", AV65isSent);
         GxWebStd.gx_hidden_field( context, "vERRDESCROPTION", StringUtil.RTrim( AV67ErrDescroption));
         GxWebStd.gx_hidden_field( context, "vRESIDENTTITLE", AV78ResidentTitle);
         GxWebStd.gx_hidden_field( context, "gxhash_vRESIDENTTITLE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV78ResidentTitle, "")), context));
         GxWebStd.gx_hidden_field( context, "vSELECTED_RESIDENTID", AV75Selected_ResidentId.ToString());
         GxWebStd.gx_hidden_field( context, "vSELECTED_LOCATIONID", AV76Selected_LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "vSELECTED_ORGANISATIONID", AV77Selected_OrganisationId.ToString());
         GxWebStd.gx_boolean_hidden_field( context, "vISSUCCESSFUL", AV34isSuccessful);
         GxWebStd.gx_hidden_field( context, "vMESSAGE", StringUtil.RTrim( AV72Message));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV29WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV29WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV29WWPContext, context));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPACKAGEID_Cls", StringUtil.RTrim( Combo_residentpackageid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPACKAGEID_Selectedvalue_set", StringUtil.RTrim( Combo_residentpackageid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPACKAGEID_Visible", StringUtil.BoolToStr( Combo_residentpackageid_Visible));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPACKAGEID_Emptyitemtext", StringUtil.RTrim( Combo_residentpackageid_Emptyitemtext));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
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
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Title", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Confirmtype));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Title", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Confirmtype));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_RESENDINVITE_Result", StringUtil.RTrim( Dvelop_confirmpanel_resendinvite_Result));
         GxWebStd.gx_hidden_field( context, "vHTTPREQUEST_Baseurl", StringUtil.RTrim( AV14HTTPRequest.BaseURL));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Result", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Result", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Result", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Result));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPACKAGEID_Selectedvalue_get", StringUtil.RTrim( Combo_residentpackageid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_RESENDINVITE_Result", StringUtil.RTrim( Dvelop_confirmpanel_resendinvite_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Result", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Result", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Result", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Result));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPACKAGEID_Selectedvalue_get", StringUtil.RTrim( Combo_residentpackageid_Selectedvalue_get));
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
            WE5J2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5J2( ) ;
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
         return formatLink("wp_locationresidents.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WP_LocationResidents" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Location Residents", "") ;
      }

      protected void WB5J0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(50), 2, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_LocationResidents.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(50), 2, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_LocationResidents.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, divUnnamedtable1_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCombo_residentpackageid_cell_Internalname, 1, 0, "px", 0, "px", divCombo_residentpackageid_cell_Class, "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_residentpackageid.SetProperty("Caption", Combo_residentpackageid_Caption);
            ucCombo_residentpackageid.SetProperty("Cls", Combo_residentpackageid_Cls);
            ucCombo_residentpackageid.SetProperty("EmptyItemText", Combo_residentpackageid_Emptyitemtext);
            ucCombo_residentpackageid.SetProperty("DropDownOptionsData", AV70ResidentPackageId_Data);
            ucCombo_residentpackageid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_residentpackageid_Internalname, "COMBO_RESIDENTPACKAGEIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'" + sGXsfl_50_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV7FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV7FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWPFullTextFilter", "start", true, "", "HLP_WP_LocationResidents.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablelocationoption_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_6_25", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocklocationoption_Internalname, "", "", "", lblTextblocklocationoption_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_LocationResidents.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_93_75", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavLocationoption_Internalname, context.GetMessage( "Location Option", ""), "col-sm-3 AddressAttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_50_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavLocationoption, dynavLocationoption_Internalname, AV16LocationOption.ToString(), 1, dynavLocationoption_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "guid", "", dynavLocationoption.Visible, dynavLocationoption.Enabled, 0, 0, 20, "em", 0, "", "", "AddressAttribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 0, "HLP_WP_LocationResidents.htm");
            dynavLocationoption.CurrentValue = AV16LocationOption.ToString();
            AssignProp("", false, dynavLocationoption_Internalname, "Values", (string)(dynavLocationoption.ToJavascriptSource()), true);
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
            StartGridControl50( ) ;
         }
         if ( wbEnd == 50 )
         {
            wbEnd = 0;
            nRC_GXsfl_50 = (int)(nGXsfl_50_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV80GXV1 = nGXsfl_50_idx;
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV10GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV11GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV9GridAppliedFilters);
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
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'" + sGXsfl_50_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentpackageid_Internalname, AV69ResidentPackageId.ToString(), AV69ResidentPackageId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentpackageid_Jsonclick, 0, "Attribute", "", "", "", "", edtavResidentpackageid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_LocationResidents.htm");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV40DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV40DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV38ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            wb_table1_80_5J2( true) ;
         }
         else
         {
            wb_table1_80_5J2( false) ;
         }
         return  ;
      }

      protected void wb_table1_80_5J2e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table2_85_5J2( true) ;
         }
         else
         {
            wb_table2_85_5J2( false) ;
         }
         return  ;
      }

      protected void wb_table2_85_5J2e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table3_90_5J2( true) ;
         }
         else
         {
            wb_table3_90_5J2( false) ;
         }
         return  ;
      }

      protected void wb_table3_90_5J2e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table4_95_5J2( true) ;
         }
         else
         {
            wb_table4_95_5J2( false) ;
         }
         return  ;
      }

      protected void wb_table4_95_5J2e( bool wbgen )
      {
         if ( wbgen )
         {
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
         if ( wbEnd == 50 )
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
                  AV80GXV1 = nGXsfl_50_idx;
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

      protected void START5J2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Location Residents", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5J0( ) ;
      }

      protected void WS5J2( )
      {
         START5J2( ) ;
         EVT5J2( ) ;
      }

      protected void EVT5J2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_RESIDENTPACKAGEID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_residentpackageid.Onoptionclicked */
                              E115J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_managefilters.Onoptionclicked */
                              E125J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E135J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E145J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E155J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E165J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_RESENDINVITE.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_resendinvite.Close */
                              E175J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_useractionunblock.Close */
                              E185J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_useractionblock.Close */
                              E195J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_UDELETE.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_udelete.Close */
                              E205J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E215J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VLOCATIONOPTION.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E225J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFILTERFULLTEXT.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E235J2 ();
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
                              nGXsfl_50_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_50_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_50_idx), 4, 0), 4, "0");
                              SubsflControlProps_502( ) ;
                              AV80GXV1 = (int)(nGXsfl_50_idx+GRID_nFirstRecordOnPage);
                              if ( ( AV22SDT_Residents.Count >= AV80GXV1 ) && ( AV80GXV1 > 0 ) )
                              {
                                 AV22SDT_Residents.CurrentItem = ((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1));
                                 AV44AccountStatus = cgiGet( edtavAccountstatus_Internalname);
                                 AssignAttri("", false, edtavAccountstatus_Internalname, AV44AccountStatus);
                                 cmbavActiongroup.Name = cmbavActiongroup_Internalname;
                                 cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
                                 AV35ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
                                 AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV35ActionGroup), 4, 0));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E245J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E255J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E265J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VACTIONGROUP.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E275J2 ();
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

      protected void WE5J2( )
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

      protected void PA5J2( )
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

      protected void GXDLVvLOCATIONOPTION5J2( GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV29WWPContext )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvLOCATIONOPTION_data5J2( AV29WWPContext) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvLOCATIONOPTION_html5J2( GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV29WWPContext )
      {
         Guid gxdynajaxvalue;
         GXDLVvLOCATIONOPTION_data5J2( AV29WWPContext) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavLocationoption.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = StringUtil.StrToGuid( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)));
            dynavLocationoption.addItem(gxdynajaxvalue.ToString(), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvLOCATIONOPTION_data5J2( GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV29WWPContext )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(Guid.Empty.ToString());
         gxdynajaxctrldescr.Add(context.GetMessage( "Select Location", ""));
         /* Using cursor H005J2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            if ( H005J2_A11OrganisationId[0] == (AV29WWPContext.gxTpr_Isrootadmin ? AV29WWPContext.gxTpr_Organisationid : new prc_getuserorganisationid(context).executeUdp( )) )
            {
               gxdynajaxctrlcodr.Add(H005J2_A29LocationId[0].ToString());
               gxdynajaxctrldescr.Add(H005J2_A31LocationName[0]);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_502( ) ;
         while ( nGXsfl_50_idx <= nRC_GXsfl_50 )
         {
            sendrow_502( ) ;
            nGXsfl_50_idx = ((subGrid_Islastpage==1)&&(nGXsfl_50_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_50_idx+1);
            sGXsfl_50_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_50_idx), 4, 0), 4, "0");
            SubsflControlProps_502( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV18ManageFiltersExecutionStep ,
                                       WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV38ColumnsSelector ,
                                       string AV99Pgmname ,
                                       short AV54OrderedBy ,
                                       bool AV55OrderedDsc ,
                                       string AV7FilterFullText ,
                                       GXBaseCollection<SdtSDT_Resident> AV22SDT_Residents ,
                                       Guid AV69ResidentPackageId ,
                                       Guid A11OrganisationId ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV29WWPContext ,
                                       Guid AV101Udparg1 ,
                                       Guid A29LocationId ,
                                       Guid AV16LocationOption ,
                                       Guid A62ResidentId ,
                                       string A72ResidentSalutation ,
                                       string A63ResidentBsnNumber ,
                                       string A64ResidentGivenName ,
                                       string A65ResidentLastName ,
                                       string A66ResidentInitials ,
                                       string A67ResidentEmail ,
                                       string A68ResidentGender ,
                                       string A312ResidentCountry ,
                                       string A313ResidentCity ,
                                       string A314ResidentZipCode ,
                                       string A315ResidentAddressLine1 ,
                                       string A316ResidentAddressLine2 ,
                                       string A70ResidentPhone ,
                                       string A97ResidentTypeName ,
                                       Guid A98MedicalIndicationId ,
                                       string A99MedicalIndicationName ,
                                       DateTime A73ResidentBirthDate ,
                                       Guid A96ResidentTypeId ,
                                       string A71ResidentGUID ,
                                       Guid A527ResidentPackageId ,
                                       bool AV33IsAuthorized_Delete ,
                                       bool AV41IsAuthorized_SDT_Residents ,
                                       string AV78ResidentTitle )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF5J2( ) ;
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
         if ( dynavLocationoption.ItemCount > 0 )
         {
            AV16LocationOption = StringUtil.StrToGuid( dynavLocationoption.getValidValue(AV16LocationOption.ToString()));
            AssignAttri("", false, "AV16LocationOption", AV16LocationOption.ToString());
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavLocationoption.CurrentValue = AV16LocationOption.ToString();
            AssignProp("", false, dynavLocationoption_Internalname, "Values", dynavLocationoption.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5J2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV99Pgmname = "WP_LocationResidents";
         edtavSdt_residents__residentid_Enabled = 0;
         edtavSdt_residents__locationid_Enabled = 0;
         edtavSdt_residents__organisationid_Enabled = 0;
         edtavSdt_residents__residentbsnnumber_Enabled = 0;
         cmbavSdt_residents__residentsalutation.Enabled = 0;
         edtavSdt_residents__residentgivenname_Enabled = 0;
         edtavSdt_residents__residentlastname_Enabled = 0;
         edtavSdt_residents__residentinitials_Enabled = 0;
         cmbavSdt_residents__residentgender.Enabled = 0;
         edtavSdt_residents__residentbirthdate_Enabled = 0;
         edtavSdt_residents__residentemail_Enabled = 0;
         edtavSdt_residents__residentphone_Enabled = 0;
         edtavSdt_residents__residentguid_Enabled = 0;
         edtavSdt_residents__residenttypeid_Enabled = 0;
         edtavSdt_residents__residenttypename_Enabled = 0;
         edtavSdt_residents__medicalindicationid_Enabled = 0;
         edtavSdt_residents__medicalindicationname_Enabled = 0;
         edtavSdt_residents__residentaddress_Enabled = 0;
         edtavAccountstatus_Enabled = 0;
      }

      protected void RF5J2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 50;
         /* Execute user event: Refresh */
         E255J2 ();
         nGXsfl_50_idx = 1;
         sGXsfl_50_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_50_idx), 4, 0), 4, "0");
         SubsflControlProps_502( ) ;
         bGXsfl_50_Refreshing = true;
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
            SubsflControlProps_502( ) ;
            /* Execute user event: Grid.Load */
            E265J2 ();
            if ( ( subGrid_Islastpage == 0 ) && ( GRID_nCurrentRecord > 0 ) && ( GRID_nGridOutOfScope == 0 ) && ( nGXsfl_50_idx == 1 ) )
            {
               GRID_nCurrentRecord = 0;
               GRID_nGridOutOfScope = 1;
               subgrid_firstpage( ) ;
               /* Execute user event: Grid.Load */
               E265J2 ();
            }
            wbEnd = 50;
            WB5J0( ) ;
         }
         bGXsfl_50_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5J2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV99Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV99Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV29WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV29WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV29WWPContext, context));
         GxWebStd.gx_hidden_field( context, "vUDPARG1", AV101Udparg1.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG1", GetSecureSignedToken( "", AV101Udparg1, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV33IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV33IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_SDT_RESIDENTS", AV41IsAuthorized_SDT_Residents);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SDT_RESIDENTS", GetSecureSignedToken( "", AV41IsAuthorized_SDT_Residents, context));
         GxWebStd.gx_hidden_field( context, "vRESIDENTTITLE", AV78ResidentTitle);
         GxWebStd.gx_hidden_field( context, "gxhash_vRESIDENTTITLE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV78ResidentTitle, "")), context));
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
         return AV22SDT_Residents.Count ;
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
            gxgrGrid_refresh( subGrid_Rows, AV18ManageFiltersExecutionStep, AV38ColumnsSelector, AV99Pgmname, AV54OrderedBy, AV55OrderedDsc, AV7FilterFullText, AV22SDT_Residents, AV69ResidentPackageId, A11OrganisationId, AV29WWPContext, AV101Udparg1, A29LocationId, AV16LocationOption, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A312ResidentCountry, A313ResidentCity, A314ResidentZipCode, A315ResidentAddressLine1, A316ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, A527ResidentPackageId, AV33IsAuthorized_Delete, AV41IsAuthorized_SDT_Residents, AV78ResidentTitle) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV18ManageFiltersExecutionStep, AV38ColumnsSelector, AV99Pgmname, AV54OrderedBy, AV55OrderedDsc, AV7FilterFullText, AV22SDT_Residents, AV69ResidentPackageId, A11OrganisationId, AV29WWPContext, AV101Udparg1, A29LocationId, AV16LocationOption, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A312ResidentCountry, A313ResidentCity, A314ResidentZipCode, A315ResidentAddressLine1, A316ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, A527ResidentPackageId, AV33IsAuthorized_Delete, AV41IsAuthorized_SDT_Residents, AV78ResidentTitle) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV18ManageFiltersExecutionStep, AV38ColumnsSelector, AV99Pgmname, AV54OrderedBy, AV55OrderedDsc, AV7FilterFullText, AV22SDT_Residents, AV69ResidentPackageId, A11OrganisationId, AV29WWPContext, AV101Udparg1, A29LocationId, AV16LocationOption, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A312ResidentCountry, A313ResidentCity, A314ResidentZipCode, A315ResidentAddressLine1, A316ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, A527ResidentPackageId, AV33IsAuthorized_Delete, AV41IsAuthorized_SDT_Residents, AV78ResidentTitle) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV18ManageFiltersExecutionStep, AV38ColumnsSelector, AV99Pgmname, AV54OrderedBy, AV55OrderedDsc, AV7FilterFullText, AV22SDT_Residents, AV69ResidentPackageId, A11OrganisationId, AV29WWPContext, AV101Udparg1, A29LocationId, AV16LocationOption, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A312ResidentCountry, A313ResidentCity, A314ResidentZipCode, A315ResidentAddressLine1, A316ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, A527ResidentPackageId, AV33IsAuthorized_Delete, AV41IsAuthorized_SDT_Residents, AV78ResidentTitle) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV18ManageFiltersExecutionStep, AV38ColumnsSelector, AV99Pgmname, AV54OrderedBy, AV55OrderedDsc, AV7FilterFullText, AV22SDT_Residents, AV69ResidentPackageId, A11OrganisationId, AV29WWPContext, AV101Udparg1, A29LocationId, AV16LocationOption, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A312ResidentCountry, A313ResidentCity, A314ResidentZipCode, A315ResidentAddressLine1, A316ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, A527ResidentPackageId, AV33IsAuthorized_Delete, AV41IsAuthorized_SDT_Residents, AV78ResidentTitle) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV99Pgmname = "WP_LocationResidents";
         edtavSdt_residents__residentid_Enabled = 0;
         edtavSdt_residents__locationid_Enabled = 0;
         edtavSdt_residents__organisationid_Enabled = 0;
         edtavSdt_residents__residentbsnnumber_Enabled = 0;
         cmbavSdt_residents__residentsalutation.Enabled = 0;
         edtavSdt_residents__residentgivenname_Enabled = 0;
         edtavSdt_residents__residentlastname_Enabled = 0;
         edtavSdt_residents__residentinitials_Enabled = 0;
         cmbavSdt_residents__residentgender.Enabled = 0;
         edtavSdt_residents__residentbirthdate_Enabled = 0;
         edtavSdt_residents__residentemail_Enabled = 0;
         edtavSdt_residents__residentphone_Enabled = 0;
         edtavSdt_residents__residentguid_Enabled = 0;
         edtavSdt_residents__residenttypeid_Enabled = 0;
         edtavSdt_residents__residenttypename_Enabled = 0;
         edtavSdt_residents__medicalindicationid_Enabled = 0;
         edtavSdt_residents__medicalindicationname_Enabled = 0;
         edtavSdt_residents__residentaddress_Enabled = 0;
         edtavAccountstatus_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5J0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E245J2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         GXVvLOCATIONOPTION_html5J2( AV29WWPContext) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Sdt_residents"), AV22SDT_Residents);
            ajax_req_read_hidden_sdt(cgiGet( "vRESIDENTPACKAGEID_DATA"), AV70ResidentPackageId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV17ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV40DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV38ColumnsSelector);
            ajax_req_read_hidden_sdt(cgiGet( "vSDT_RESIDENTS"), AV22SDT_Residents);
            /* Read saved values. */
            nRC_GXsfl_50 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_50"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV10GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV11GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV9GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Combo_residentpackageid_Cls = cgiGet( "COMBO_RESIDENTPACKAGEID_Cls");
            Combo_residentpackageid_Selectedvalue_set = cgiGet( "COMBO_RESIDENTPACKAGEID_Selectedvalue_set");
            Combo_residentpackageid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTPACKAGEID_Visible"));
            Combo_residentpackageid_Emptyitemtext = cgiGet( "COMBO_RESIDENTPACKAGEID_Emptyitemtext");
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
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
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
            Dvelop_confirmpanel_useractionunblock_Title = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Title");
            Dvelop_confirmpanel_useractionunblock_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Confirmationtext");
            Dvelop_confirmpanel_useractionunblock_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Yesbuttoncaption");
            Dvelop_confirmpanel_useractionunblock_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Nobuttoncaption");
            Dvelop_confirmpanel_useractionunblock_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Cancelbuttoncaption");
            Dvelop_confirmpanel_useractionunblock_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Yesbuttonposition");
            Dvelop_confirmpanel_useractionunblock_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Confirmtype");
            Dvelop_confirmpanel_useractionblock_Title = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Title");
            Dvelop_confirmpanel_useractionblock_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Confirmationtext");
            Dvelop_confirmpanel_useractionblock_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Yesbuttoncaption");
            Dvelop_confirmpanel_useractionblock_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Nobuttoncaption");
            Dvelop_confirmpanel_useractionblock_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Cancelbuttoncaption");
            Dvelop_confirmpanel_useractionblock_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Yesbuttonposition");
            Dvelop_confirmpanel_useractionblock_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Confirmtype");
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
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Dvelop_confirmpanel_resendinvite_Result = cgiGet( "DVELOP_CONFIRMPANEL_RESENDINVITE_Result");
            Dvelop_confirmpanel_useractionunblock_Result = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Result");
            Dvelop_confirmpanel_useractionblock_Result = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Result");
            Dvelop_confirmpanel_udelete_Result = cgiGet( "DVELOP_CONFIRMPANEL_UDELETE_Result");
            Combo_residentpackageid_Selectedvalue_get = cgiGet( "COMBO_RESIDENTPACKAGEID_Selectedvalue_get");
            nRC_GXsfl_50 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_50"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_50_fel_idx = 0;
            while ( nGXsfl_50_fel_idx < nRC_GXsfl_50 )
            {
               nGXsfl_50_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_50_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_50_fel_idx+1);
               sGXsfl_50_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_50_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_502( ) ;
               AV80GXV1 = (int)(nGXsfl_50_fel_idx+GRID_nFirstRecordOnPage);
               if ( ( AV22SDT_Residents.Count >= AV80GXV1 ) && ( AV80GXV1 > 0 ) )
               {
                  AV22SDT_Residents.CurrentItem = ((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1));
                  AV44AccountStatus = cgiGet( edtavAccountstatus_Internalname);
                  cmbavActiongroup.Name = cmbavActiongroup_Internalname;
                  cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
                  AV35ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
               }
            }
            if ( nGXsfl_50_fel_idx == 0 )
            {
               nGXsfl_50_idx = 1;
               sGXsfl_50_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_50_idx), 4, 0), 4, "0");
               SubsflControlProps_502( ) ;
            }
            nGXsfl_50_fel_idx = 1;
            /* Read variables values. */
            AV7FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV7FilterFullText", AV7FilterFullText);
            dynavLocationoption.Name = dynavLocationoption_Internalname;
            dynavLocationoption.CurrentValue = cgiGet( dynavLocationoption_Internalname);
            AV16LocationOption = StringUtil.StrToGuid( cgiGet( dynavLocationoption_Internalname));
            AssignAttri("", false, "AV16LocationOption", AV16LocationOption.ToString());
            if ( StringUtil.StrCmp(cgiGet( edtavResidentpackageid_Internalname), "") == 0 )
            {
               AV69ResidentPackageId = Guid.Empty;
               AssignAttri("", false, "AV69ResidentPackageId", AV69ResidentPackageId.ToString());
            }
            else
            {
               try
               {
                  AV69ResidentPackageId = StringUtil.StrToGuid( cgiGet( edtavResidentpackageid_Internalname));
                  AssignAttri("", false, "AV69ResidentPackageId", AV69ResidentPackageId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vRESIDENTPACKAGEID");
                  GX_FocusControl = edtavResidentpackageid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            /* Read subfile selected row values. */
            nGXsfl_50_idx = (int)(Math.Round(context.localUtil.CToN( cgiGet( subGrid_Internalname+"_ROW"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            sGXsfl_50_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_50_idx), 4, 0), 4, "0");
            SubsflControlProps_502( ) ;
            AV80GXV1 = (int)(nGXsfl_50_idx+GRID_nFirstRecordOnPage);
            if ( nGXsfl_50_idx > 0 )
            {
               AV80GXV1 = (int)(nGXsfl_50_idx+GRID_nFirstRecordOnPage);
               if ( ( AV22SDT_Residents.Count >= AV80GXV1 ) && ( AV80GXV1 > 0 ) )
               {
                  AV22SDT_Residents.CurrentItem = ((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1));
                  AV44AccountStatus = cgiGet( edtavAccountstatus_Internalname);
                  AssignAttri("", false, edtavAccountstatus_Internalname, AV44AccountStatus);
                  cmbavActiongroup.Name = cmbavActiongroup_Internalname;
                  cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
                  AV35ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV35ActionGroup), 4, 0));
               }
               if ( ( AV80GXV1 > 0 ) && ( AV22SDT_Residents.Count >= AV80GXV1 ) )
               {
                  AV22SDT_Residents.CurrentItem = ((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1));
               }
            }
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
         E245J2 ();
         if (returnInSub) return;
      }

      protected void E245J2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV59successmsg = AV60websession.Get(context.GetMessage( "NotificationMessage", ""));
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59successmsg)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Success",  AV59successmsg,  "success",  "",  "true",  ""));
            AV60websession.Remove(context.GetMessage( "NotificationMessage", ""));
         }
         GXt_SdtGAMUser1 = AV8GAMUser;
         new prc_getloggedinuser(context ).execute( out  GXt_SdtGAMUser1) ;
         AV8GAMUser = GXt_SdtGAMUser1;
         if ( AV8GAMUser.checkrole("Organisation Manager") )
         {
            dynavLocationoption.Visible = 1;
            AssignProp("", false, dynavLocationoption_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavLocationoption.Visible), 5, 0), true);
         }
         else
         {
            if ( AV8GAMUser.checkrole("Receptionist") )
            {
               GXt_guid2 = AV16LocationOption;
               new prc_getuserlocationid(context ).execute( out  GXt_guid2) ;
               AV16LocationOption = GXt_guid2;
               AssignAttri("", false, "AV16LocationOption", AV16LocationOption.ToString());
               dynavLocationoption.Visible = 0;
               AssignProp("", false, dynavLocationoption_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavLocationoption.Visible), 5, 0), true);
            }
            else
            {
               if ( AV8GAMUser.checkrole("Root Admin") )
               {
                  new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV29WWPContext) ;
                  if ( ! (Guid.Empty==AV29WWPContext.gxTpr_Locationid) )
                  {
                     AV16LocationOption = AV29WWPContext.gxTpr_Locationid;
                     AssignAttri("", false, "AV16LocationOption", AV16LocationOption.ToString());
                     dynavLocationoption.Visible = 0;
                     AssignProp("", false, dynavLocationoption_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavLocationoption.Visible), 5, 0), true);
                  }
                  else
                  {
                     dynavLocationoption.Visible = 1;
                     AssignProp("", false, dynavLocationoption_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavLocationoption.Visible), 5, 0), true);
                     AV16LocationOption = AV29WWPContext.gxTpr_Locationid;
                     AssignAttri("", false, "AV16LocationOption", AV16LocationOption.ToString());
                  }
               }
            }
         }
         edtavResidentpackageid_Visible = 0;
         AssignProp("", false, edtavResidentpackageid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResidentpackageid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBORESIDENTPACKAGEID' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV14HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S132 ();
            if (returnInSub) return;
         }
         GXt_boolean3 = AV41IsAuthorized_SDT_Residents;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_residentview_Execute", out  GXt_boolean3) ;
         AV41IsAuthorized_SDT_Residents = GXt_boolean3;
         AssignAttri("", false, "AV41IsAuthorized_SDT_Residents", AV41IsAuthorized_SDT_Residents);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SDT_RESIDENTS", GetSecureSignedToken( "", AV41IsAuthorized_SDT_Residents, context));
         GXt_boolean3 = AV41IsAuthorized_SDT_Residents;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_residentview_Execute", out  GXt_boolean3) ;
         AV41IsAuthorized_SDT_Residents = GXt_boolean3;
         AssignAttri("", false, "AV41IsAuthorized_SDT_Residents", AV41IsAuthorized_SDT_Residents);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SDT_RESIDENTS", GetSecureSignedToken( "", AV41IsAuthorized_SDT_Residents, context));
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = context.GetMessage( "Location Residents", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S142 ();
         if (returnInSub) return;
         if ( AV54OrderedBy < 1 )
         {
            AV54OrderedBy = 1;
            AssignAttri("", false, "AV54OrderedBy", StringUtil.LTrimStr( (decimal)(AV54OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S152 ();
            if (returnInSub) return;
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4 = AV40DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4) ;
         AV40DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         GXt_char5 = AV78ResidentTitle;
         new prc_getorganisationdefinition(context ).execute(  "Resident", out  GXt_char5) ;
         AV78ResidentTitle = GXt_char5;
         AssignAttri("", false, "AV78ResidentTitle", AV78ResidentTitle);
         GxWebStd.gx_hidden_field( context, "gxhash_vRESIDENTTITLE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV78ResidentTitle, "")), context));
         GXt_char5 = AV79ResidentsTitle;
         new prc_getorganisationdefinition(context ).execute(  "Residents", out  GXt_char5) ;
         AV79ResidentsTitle = GXt_char5;
         Form.Caption = context.GetMessage( "Location", "")+" "+AV79ResidentsTitle;
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
      }

      protected void E255J2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV29WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S162 ();
         if (returnInSub) return;
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
            S132 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S172 ();
         if (returnInSub) return;
         if ( StringUtil.StrCmp(AV24Session.Get("WP_LocationResidentsColumnsSelector"), "") != 0 )
         {
            AV36ColumnsSelectorXML = AV24Session.Get("WP_LocationResidentsColumnsSelector");
            AV38ColumnsSelector.FromXml(AV36ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S182 ();
            if (returnInSub) return;
         }
         edtavSdt_residents__residentgivenname_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavSdt_residents__residentgivenname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSdt_residents__residentgivenname_Visible), 5, 0), !bGXsfl_50_Refreshing);
         edtavSdt_residents__residentlastname_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavSdt_residents__residentlastname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSdt_residents__residentlastname_Visible), 5, 0), !bGXsfl_50_Refreshing);
         cmbavSdt_residents__residentgender.Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbavSdt_residents__residentgender_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavSdt_residents__residentgender.Visible), 5, 0), !bGXsfl_50_Refreshing);
         edtavSdt_residents__residentemail_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavSdt_residents__residentemail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSdt_residents__residentemail_Visible), 5, 0), !bGXsfl_50_Refreshing);
         edtavSdt_residents__residentphone_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavSdt_residents__residentphone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSdt_residents__residentphone_Visible), 5, 0), !bGXsfl_50_Refreshing);
         edtavAccountstatus_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavAccountstatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAccountstatus_Visible), 5, 0), !bGXsfl_50_Refreshing);
         /* Execute user subroutine: 'LOADGRIDSDT' */
         S192 ();
         if (returnInSub) return;
         AV10GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV10GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV10GridCurrentPage), 10, 0));
         AV11GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV11GridPageCount", StringUtil.LTrimStr( (decimal)(AV11GridPageCount), 10, 0));
         GXt_char5 = AV9GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV99Pgmname, out  GXt_char5) ;
         AV9GridAppliedFilters = GXt_char5;
         AssignAttri("", false, "AV9GridAppliedFilters", AV9GridAppliedFilters);
         edtavAccountstatus_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtavAccountstatus_Internalname, "Columnheaderclass", edtavAccountstatus_Columnheaderclass, !bGXsfl_50_Refreshing);
         /* Execute user subroutine: 'RELOADGRIDSDT' */
         S202 ();
         if (returnInSub) return;
         dynload_actions( ) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29WWPContext", AV29WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12GridState", AV12GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22SDT_Residents", AV22SDT_Residents);
      }

      protected void E135J2( )
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
            AV20PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV20PageToGo) ;
         }
      }

      protected void E145J2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E155J2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV54OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV54OrderedBy", StringUtil.LTrimStr( (decimal)(AV54OrderedBy), 4, 0));
            AV55OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV55OrderedDsc", AV55OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S152 ();
            if (returnInSub) return;
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E265J2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV80GXV1 = 1;
         while ( AV80GXV1 <= AV22SDT_Residents.Count )
         {
            AV22SDT_Residents.CurrentItem = ((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1));
            GXt_boolean3 = false;
            new prc_checkgamuseractivationstatus(context ).execute(  ((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Residentguid, out  GXt_boolean3) ;
            AV42IsGAMActive = (short)(Convert.ToInt16(GXt_boolean3));
            GXt_boolean3 = AV43IsGAMBlocked;
            new prc_checkgamuserblockedstatus(context ).execute(  ((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Residentguid, out  GXt_boolean3) ;
            AV43IsGAMBlocked = GXt_boolean3;
            if ( ( AV42IsGAMActive == 1 ) && ! AV43IsGAMBlocked )
            {
               AV44AccountStatus = "Active";
               AssignAttri("", false, edtavAccountstatus_Internalname, AV44AccountStatus);
            }
            else if ( ( AV42IsGAMActive == 1 ) && ( AV43IsGAMBlocked ) )
            {
               AV44AccountStatus = "Blocked";
               AssignAttri("", false, edtavAccountstatus_Internalname, AV44AccountStatus);
            }
            else if ( AV42IsGAMActive == 0 )
            {
               AV44AccountStatus = "Inactive";
               AssignAttri("", false, edtavAccountstatus_Internalname, AV44AccountStatus);
            }
            cmbavActiongroup.removeAllItems();
            cmbavActiongroup.addItem("0", ";fas fa-bars", 0);
            if ( AV42IsGAMActive == 0 )
            {
               cmbavActiongroup.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "Invite", ""), "fas fa-share", "", "", "", "", "", "", ""), 0);
            }
            if ( ( AV42IsGAMActive == 1 ) && ( AV43IsGAMBlocked ) )
            {
               cmbavActiongroup.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "Unblock", ""), "fas fa-lock-open", "", "", "", "", "", "", ""), 0);
            }
            if ( ( AV42IsGAMActive == 1 ) && ! AV43IsGAMBlocked )
            {
               cmbavActiongroup.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "Block", ""), "fas fa-lock", "", "", "", "", "", "", ""), 0);
            }
            if ( 1 == 0 )
            {
               cmbavActiongroup.addItem("4", StringUtil.Format( "%1;%2", context.GetMessage( "QR code", ""), "fas fa-qrcode", "", "", "", "", "", "", ""), 0);
            }
            cmbavActiongroup.addItem("5", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
            cmbavActiongroup.addItem("6", StringUtil.Format( "%1;%2", context.GetMessage( "Edit", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
            if ( AV33IsAuthorized_Delete )
            {
               if ( false )
               {
                  cmbavActiongroup.addItem("7", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "fa fa-times", "", "", "", "", "", "", ""), 0);
               }
            }
            cmbavActiongroup.addItem("8", StringUtil.Format( "%1;%2", context.GetMessage( "Delete", ""), "fas fa-x", "", "", "", "", "", "", ""), 0);
            if ( AV41IsAuthorized_SDT_Residents )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "trn_residentview.aspx"+UrlEncode(((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Residentid.ToString()) + "," + UrlEncode(((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Locationid.ToString()) + "," + UrlEncode(((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Organisationid.ToString());
               edtavSdt_residents__residentgivenname_Link = formatLink("trn_residentview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            if ( AV41IsAuthorized_SDT_Residents )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "trn_residentview.aspx"+UrlEncode(((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Residentid.ToString()) + "," + UrlEncode(((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Locationid.ToString()) + "," + UrlEncode(((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Organisationid.ToString());
               edtavSdt_residents__residentlastname_Link = formatLink("trn_residentview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            if ( ( AV42IsGAMActive == 1 ) && ! AV43IsGAMBlocked )
            {
               edtavAccountstatus_Columnclass = "WWColumn WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
            }
            else if ( ( AV42IsGAMActive == 1 ) && ( AV43IsGAMBlocked ) )
            {
               edtavAccountstatus_Columnclass = "WWColumn WWColumnTag WWColumnTagDanger WWColumnTagDangerSingleCell";
            }
            else if ( AV42IsGAMActive == 0 )
            {
               edtavAccountstatus_Columnclass = "WWColumn WWColumnTag WWColumnTagWarning WWColumnTagWarningSingleCell";
            }
            else
            {
               edtavAccountstatus_Columnclass = "WWColumn";
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 50;
            }
            if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_502( ) ;
            }
            GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_50_Refreshing )
            {
               DoAjaxLoad(50, GridRow);
            }
            AV80GXV1 = (int)(AV80GXV1+1);
         }
         /*  Sending Event outputs  */
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV35ActionGroup), 4, 0));
      }

      protected void E165J2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV36ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV38ColumnsSelector.FromJSonString(AV36ColumnsSelectorXML, null);
         new WorkWithPlus.workwithplus_web.savecolumnsselectorstate(context ).execute(  "WP_LocationResidentsColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV36ColumnsSelectorXML)) ? "" : AV38ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29WWPContext", AV29WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12GridState", AV12GridState);
         if ( gx_BV50 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22SDT_Residents", AV22SDT_Residents);
            nGXsfl_50_bak_idx = nGXsfl_50_idx;
            gxgrGrid_refresh( subGrid_Rows, AV18ManageFiltersExecutionStep, AV38ColumnsSelector, AV99Pgmname, AV54OrderedBy, AV55OrderedDsc, AV7FilterFullText, AV22SDT_Residents, AV69ResidentPackageId, A11OrganisationId, AV29WWPContext, AV101Udparg1, A29LocationId, AV16LocationOption, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A312ResidentCountry, A313ResidentCity, A314ResidentZipCode, A315ResidentAddressLine1, A316ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, A527ResidentPackageId, AV33IsAuthorized_Delete, AV41IsAuthorized_SDT_Residents, AV78ResidentTitle) ;
            nGXsfl_50_idx = nGXsfl_50_bak_idx;
            sGXsfl_50_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_50_idx), 4, 0), 4, "0");
            SubsflControlProps_502( ) ;
         }
      }

      protected void E125J2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S212 ();
            if (returnInSub) return;
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S172 ();
            if (returnInSub) return;
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("WP_LocationResidentsFilters")) + "," + UrlEncode(StringUtil.RTrim(AV99Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV18ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV18ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV18ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("WP_LocationResidentsFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV18ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV18ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV18ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char5 = AV19ManageFiltersXml;
            new WorkWithPlus.workwithplus_web.getfilterbyname(context ).execute(  "WP_LocationResidentsFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char5) ;
            AV19ManageFiltersXml = GXt_char5;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV19ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S212 ();
               if (returnInSub) return;
               new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV99Pgmname+"GridState",  AV19ManageFiltersXml) ;
               AV12GridState.FromXml(AV19ManageFiltersXml, null, "", "");
               AV54OrderedBy = AV12GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV54OrderedBy", StringUtil.LTrimStr( (decimal)(AV54OrderedBy), 4, 0));
               AV55OrderedDsc = AV12GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV55OrderedDsc", AV55OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S152 ();
               if (returnInSub) return;
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S222 ();
               if (returnInSub) return;
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12GridState", AV12GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29WWPContext", AV29WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         if ( gx_BV50 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22SDT_Residents", AV22SDT_Residents);
            nGXsfl_50_bak_idx = nGXsfl_50_idx;
            gxgrGrid_refresh( subGrid_Rows, AV18ManageFiltersExecutionStep, AV38ColumnsSelector, AV99Pgmname, AV54OrderedBy, AV55OrderedDsc, AV7FilterFullText, AV22SDT_Residents, AV69ResidentPackageId, A11OrganisationId, AV29WWPContext, AV101Udparg1, A29LocationId, AV16LocationOption, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A312ResidentCountry, A313ResidentCity, A314ResidentZipCode, A315ResidentAddressLine1, A316ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, A527ResidentPackageId, AV33IsAuthorized_Delete, AV41IsAuthorized_SDT_Residents, AV78ResidentTitle) ;
            nGXsfl_50_idx = nGXsfl_50_bak_idx;
            sGXsfl_50_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_50_idx), 4, 0), 4, "0");
            SubsflControlProps_502( ) ;
         }
      }

      protected void E275J2( )
      {
         AV80GXV1 = (int)(nGXsfl_50_idx+GRID_nFirstRecordOnPage);
         if ( ( AV80GXV1 > 0 ) && ( AV22SDT_Residents.Count >= AV80GXV1 ) )
         {
            AV22SDT_Residents.CurrentItem = ((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1));
         }
         /* Actiongroup_Click Routine */
         returnInSub = false;
         if ( AV35ActionGroup == 1 )
         {
            /* Execute user subroutine: 'DO RESENDINVITE' */
            S232 ();
            if (returnInSub) return;
         }
         else if ( AV35ActionGroup == 2 )
         {
            /* Execute user subroutine: 'DO USERACTIONUNBLOCK' */
            S242 ();
            if (returnInSub) return;
         }
         else if ( AV35ActionGroup == 3 )
         {
            /* Execute user subroutine: 'DO USERACTIONBLOCK' */
            S252 ();
            if (returnInSub) return;
         }
         else if ( AV35ActionGroup == 4 )
         {
            /* Execute user subroutine: 'DO VIEWQRCODE' */
            S262 ();
            if (returnInSub) return;
         }
         else if ( AV35ActionGroup == 5 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S272 ();
            if (returnInSub) return;
         }
         else if ( AV35ActionGroup == 6 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S282 ();
            if (returnInSub) return;
         }
         else if ( AV35ActionGroup == 7 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S292 ();
            if (returnInSub) return;
         }
         else if ( AV35ActionGroup == 8 )
         {
            /* Execute user subroutine: 'DO UDELETE' */
            S302 ();
            if (returnInSub) return;
         }
         AV35ActionGroup = 0;
         AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV35ActionGroup), 4, 0));
         /*  Sending Event outputs  */
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV35ActionGroup), 4, 0));
         AssignProp("", false, cmbavActiongroup_Internalname, "Values", cmbavActiongroup.ToJavascriptSource(), true);
      }

      protected void E175J2( )
      {
         AV80GXV1 = (int)(nGXsfl_50_idx+GRID_nFirstRecordOnPage);
         if ( ( AV80GXV1 > 0 ) && ( AV22SDT_Residents.Count >= AV80GXV1 ) )
         {
            AV22SDT_Residents.CurrentItem = ((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1));
         }
         /* Dvelop_confirmpanel_resendinvite_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_resendinvite_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION RESENDINVITE' */
            S312 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E185J2( )
      {
         AV80GXV1 = (int)(nGXsfl_50_idx+GRID_nFirstRecordOnPage);
         if ( ( AV80GXV1 > 0 ) && ( AV22SDT_Residents.Count >= AV80GXV1 ) )
         {
            AV22SDT_Residents.CurrentItem = ((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1));
         }
         /* Dvelop_confirmpanel_useractionunblock_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_useractionunblock_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION USERACTIONUNBLOCK' */
            S322 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29WWPContext", AV29WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12GridState", AV12GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22SDT_Residents", AV22SDT_Residents);
         nGXsfl_50_bak_idx = nGXsfl_50_idx;
         gxgrGrid_refresh( subGrid_Rows, AV18ManageFiltersExecutionStep, AV38ColumnsSelector, AV99Pgmname, AV54OrderedBy, AV55OrderedDsc, AV7FilterFullText, AV22SDT_Residents, AV69ResidentPackageId, A11OrganisationId, AV29WWPContext, AV101Udparg1, A29LocationId, AV16LocationOption, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A312ResidentCountry, A313ResidentCity, A314ResidentZipCode, A315ResidentAddressLine1, A316ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, A527ResidentPackageId, AV33IsAuthorized_Delete, AV41IsAuthorized_SDT_Residents, AV78ResidentTitle) ;
         nGXsfl_50_idx = nGXsfl_50_bak_idx;
         sGXsfl_50_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_50_idx), 4, 0), 4, "0");
         SubsflControlProps_502( ) ;
      }

      protected void E195J2( )
      {
         AV80GXV1 = (int)(nGXsfl_50_idx+GRID_nFirstRecordOnPage);
         if ( ( AV80GXV1 > 0 ) && ( AV22SDT_Residents.Count >= AV80GXV1 ) )
         {
            AV22SDT_Residents.CurrentItem = ((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1));
         }
         /* Dvelop_confirmpanel_useractionblock_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_useractionblock_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION USERACTIONBLOCK' */
            S332 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29WWPContext", AV29WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12GridState", AV12GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22SDT_Residents", AV22SDT_Residents);
         nGXsfl_50_bak_idx = nGXsfl_50_idx;
         gxgrGrid_refresh( subGrid_Rows, AV18ManageFiltersExecutionStep, AV38ColumnsSelector, AV99Pgmname, AV54OrderedBy, AV55OrderedDsc, AV7FilterFullText, AV22SDT_Residents, AV69ResidentPackageId, A11OrganisationId, AV29WWPContext, AV101Udparg1, A29LocationId, AV16LocationOption, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A312ResidentCountry, A313ResidentCity, A314ResidentZipCode, A315ResidentAddressLine1, A316ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, A527ResidentPackageId, AV33IsAuthorized_Delete, AV41IsAuthorized_SDT_Residents, AV78ResidentTitle) ;
         nGXsfl_50_idx = nGXsfl_50_bak_idx;
         sGXsfl_50_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_50_idx), 4, 0), 4, "0");
         SubsflControlProps_502( ) ;
      }

      protected void E205J2( )
      {
         /* Dvelop_confirmpanel_udelete_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_udelete_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION UDELETE' */
            S342 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29WWPContext", AV29WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12GridState", AV12GridState);
         if ( gx_BV50 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22SDT_Residents", AV22SDT_Residents);
            nGXsfl_50_bak_idx = nGXsfl_50_idx;
            gxgrGrid_refresh( subGrid_Rows, AV18ManageFiltersExecutionStep, AV38ColumnsSelector, AV99Pgmname, AV54OrderedBy, AV55OrderedDsc, AV7FilterFullText, AV22SDT_Residents, AV69ResidentPackageId, A11OrganisationId, AV29WWPContext, AV101Udparg1, A29LocationId, AV16LocationOption, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A312ResidentCountry, A313ResidentCity, A314ResidentZipCode, A315ResidentAddressLine1, A316ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, A527ResidentPackageId, AV33IsAuthorized_Delete, AV41IsAuthorized_SDT_Residents, AV78ResidentTitle) ;
            nGXsfl_50_idx = nGXsfl_50_bak_idx;
            sGXsfl_50_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_50_idx), 4, 0), 4, "0");
            SubsflControlProps_502( ) ;
         }
      }

      protected void E215J2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "trn_resident.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(Guid.Empty.ToString()) + "," + UrlEncode(AV29WWPContext.gxTpr_Locationid.ToString()) + "," + UrlEncode(AV29WWPContext.gxTpr_Organisationid.ToString());
         CallWebObject(formatLink("trn_resident.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E115J2( )
      {
         AV80GXV1 = (int)(nGXsfl_50_idx+GRID_nFirstRecordOnPage);
         if ( ( AV80GXV1 > 0 ) && ( AV22SDT_Residents.Count >= AV80GXV1 ) )
         {
            AV22SDT_Residents.CurrentItem = ((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1));
         }
         /* Combo_residentpackageid_Onoptionclicked Routine */
         returnInSub = false;
         AV69ResidentPackageId = StringUtil.StrToGuid( Combo_residentpackageid_Selectedvalue_get);
         AssignAttri("", false, "AV69ResidentPackageId", AV69ResidentPackageId.ToString());
         /* Execute user subroutine: 'LOADGRIDSDT' */
         S192 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22SDT_Residents", AV22SDT_Residents);
         nGXsfl_50_bak_idx = nGXsfl_50_idx;
         gxgrGrid_refresh( subGrid_Rows, AV18ManageFiltersExecutionStep, AV38ColumnsSelector, AV99Pgmname, AV54OrderedBy, AV55OrderedDsc, AV7FilterFullText, AV22SDT_Residents, AV69ResidentPackageId, A11OrganisationId, AV29WWPContext, AV101Udparg1, A29LocationId, AV16LocationOption, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A312ResidentCountry, A313ResidentCity, A314ResidentZipCode, A315ResidentAddressLine1, A316ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, A527ResidentPackageId, AV33IsAuthorized_Delete, AV41IsAuthorized_SDT_Residents, AV78ResidentTitle) ;
         nGXsfl_50_idx = nGXsfl_50_bak_idx;
         sGXsfl_50_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_50_idx), 4, 0), 4, "0");
         SubsflControlProps_502( ) ;
      }

      protected void S192( )
      {
         /* 'LOADGRIDSDT' Routine */
         returnInSub = false;
         if ( AV54OrderedBy != 4 )
         {
            AV22SDT_Residents.Sort((AV55OrderedDsc ? "[" : "")+StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV54OrderedBy), 4, 0)), "ResidentGivenName", "ResidentLastName", "ResidentEmail", "", "", "", "", "", "")+(AV55OrderedDsc ? "]" : ""));
            gx_BV50 = true;
         }
         if ( (Guid.Empty==AV69ResidentPackageId) )
         {
            AV22SDT_Residents.Clear();
            gx_BV50 = true;
            AV101Udparg1 = new prc_getuserorganisationid(context).executeUdp( );
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV16LocationOption ,
                                                 A29LocationId ,
                                                 A11OrganisationId ,
                                                 AV29WWPContext.gxTpr_Isrootadmin ,
                                                 AV29WWPContext.gxTpr_Organisationid ,
                                                 AV101Udparg1 } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN
                                                 }
            });
            /* Using cursor H005J3 */
            pr_default.execute(1, new Object[] {AV29WWPContext.gxTpr_Organisationid, AV29WWPContext.gxTpr_Isrootadmin, AV101Udparg1, AV16LocationOption});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A29LocationId = H005J3_A29LocationId[0];
               A11OrganisationId = H005J3_A11OrganisationId[0];
               A62ResidentId = H005J3_A62ResidentId[0];
               A72ResidentSalutation = H005J3_A72ResidentSalutation[0];
               A63ResidentBsnNumber = H005J3_A63ResidentBsnNumber[0];
               A64ResidentGivenName = H005J3_A64ResidentGivenName[0];
               A65ResidentLastName = H005J3_A65ResidentLastName[0];
               A66ResidentInitials = H005J3_A66ResidentInitials[0];
               A67ResidentEmail = H005J3_A67ResidentEmail[0];
               A68ResidentGender = H005J3_A68ResidentGender[0];
               A312ResidentCountry = H005J3_A312ResidentCountry[0];
               A313ResidentCity = H005J3_A313ResidentCity[0];
               A314ResidentZipCode = H005J3_A314ResidentZipCode[0];
               A315ResidentAddressLine1 = H005J3_A315ResidentAddressLine1[0];
               A316ResidentAddressLine2 = H005J3_A316ResidentAddressLine2[0];
               A70ResidentPhone = H005J3_A70ResidentPhone[0];
               A97ResidentTypeName = H005J3_A97ResidentTypeName[0];
               A98MedicalIndicationId = H005J3_A98MedicalIndicationId[0];
               n98MedicalIndicationId = H005J3_n98MedicalIndicationId[0];
               A99MedicalIndicationName = H005J3_A99MedicalIndicationName[0];
               A73ResidentBirthDate = H005J3_A73ResidentBirthDate[0];
               A96ResidentTypeId = H005J3_A96ResidentTypeId[0];
               n96ResidentTypeId = H005J3_n96ResidentTypeId[0];
               A71ResidentGUID = H005J3_A71ResidentGUID[0];
               A99MedicalIndicationName = H005J3_A99MedicalIndicationName[0];
               A97ResidentTypeName = H005J3_A97ResidentTypeName[0];
               AV21SDT_Resident = new SdtSDT_Resident(context);
               AV21SDT_Resident.gxTpr_Residentid = A62ResidentId;
               AV21SDT_Resident.gxTpr_Locationid = A29LocationId;
               AV21SDT_Resident.gxTpr_Organisationid = A11OrganisationId;
               AV21SDT_Resident.gxTpr_Residentsalutation = A72ResidentSalutation;
               AV21SDT_Resident.gxTpr_Residentbsnnumber = A63ResidentBsnNumber;
               AV21SDT_Resident.gxTpr_Residentgivenname = A64ResidentGivenName;
               AV21SDT_Resident.gxTpr_Residentlastname = A65ResidentLastName;
               AV21SDT_Resident.gxTpr_Residentinitials = A66ResidentInitials;
               AV21SDT_Resident.gxTpr_Residentemail = A67ResidentEmail;
               AV21SDT_Resident.gxTpr_Residentgender = A68ResidentGender;
               GXt_char5 = "";
               new prc_concatenateaddress(context ).execute(  A312ResidentCountry,  A313ResidentCity,  A314ResidentZipCode,  A315ResidentAddressLine1,  A316ResidentAddressLine2, out  GXt_char5) ;
               AV21SDT_Resident.gxTpr_Residentaddress = GXt_char5;
               AV21SDT_Resident.gxTpr_Residentphone = A70ResidentPhone;
               AV21SDT_Resident.gxTpr_Residenttypename = A97ResidentTypeName;
               AV21SDT_Resident.gxTpr_Medicalindicationid = A98MedicalIndicationId;
               AV21SDT_Resident.gxTpr_Medicalindicationname = A99MedicalIndicationName;
               AV21SDT_Resident.gxTpr_Residentbirthdate = A73ResidentBirthDate;
               AV21SDT_Resident.gxTpr_Residenttypeid = A96ResidentTypeId;
               AV21SDT_Resident.gxTpr_Residenttypename = A97ResidentTypeName;
               AV21SDT_Resident.gxTpr_Residentguid = A71ResidentGUID;
               AV22SDT_Residents.Add(AV21SDT_Resident, 0);
               gx_BV50 = true;
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         else
         {
            if ( ! (Guid.Empty==AV69ResidentPackageId) )
            {
               AV22SDT_Residents.Clear();
               gx_BV50 = true;
               pr_default.dynParam(2, new Object[]{ new Object[]{
                                                    AV16LocationOption ,
                                                    AV69ResidentPackageId ,
                                                    A29LocationId ,
                                                    A527ResidentPackageId } ,
                                                    new int[]{
                                                    TypeConstants.BOOLEAN
                                                    }
               });
               /* Using cursor H005J4 */
               pr_default.execute(2, new Object[] {AV16LocationOption, AV69ResidentPackageId});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A527ResidentPackageId = H005J4_A527ResidentPackageId[0];
                  n527ResidentPackageId = H005J4_n527ResidentPackageId[0];
                  A29LocationId = H005J4_A29LocationId[0];
                  A62ResidentId = H005J4_A62ResidentId[0];
                  A11OrganisationId = H005J4_A11OrganisationId[0];
                  A72ResidentSalutation = H005J4_A72ResidentSalutation[0];
                  A63ResidentBsnNumber = H005J4_A63ResidentBsnNumber[0];
                  A64ResidentGivenName = H005J4_A64ResidentGivenName[0];
                  A65ResidentLastName = H005J4_A65ResidentLastName[0];
                  A66ResidentInitials = H005J4_A66ResidentInitials[0];
                  A67ResidentEmail = H005J4_A67ResidentEmail[0];
                  A68ResidentGender = H005J4_A68ResidentGender[0];
                  A312ResidentCountry = H005J4_A312ResidentCountry[0];
                  A313ResidentCity = H005J4_A313ResidentCity[0];
                  A314ResidentZipCode = H005J4_A314ResidentZipCode[0];
                  A315ResidentAddressLine1 = H005J4_A315ResidentAddressLine1[0];
                  A316ResidentAddressLine2 = H005J4_A316ResidentAddressLine2[0];
                  A70ResidentPhone = H005J4_A70ResidentPhone[0];
                  A97ResidentTypeName = H005J4_A97ResidentTypeName[0];
                  A98MedicalIndicationId = H005J4_A98MedicalIndicationId[0];
                  n98MedicalIndicationId = H005J4_n98MedicalIndicationId[0];
                  A99MedicalIndicationName = H005J4_A99MedicalIndicationName[0];
                  A73ResidentBirthDate = H005J4_A73ResidentBirthDate[0];
                  A96ResidentTypeId = H005J4_A96ResidentTypeId[0];
                  n96ResidentTypeId = H005J4_n96ResidentTypeId[0];
                  A71ResidentGUID = H005J4_A71ResidentGUID[0];
                  A99MedicalIndicationName = H005J4_A99MedicalIndicationName[0];
                  A97ResidentTypeName = H005J4_A97ResidentTypeName[0];
                  AV21SDT_Resident = new SdtSDT_Resident(context);
                  AV21SDT_Resident.gxTpr_Residentid = A62ResidentId;
                  AV21SDT_Resident.gxTpr_Locationid = A29LocationId;
                  AV21SDT_Resident.gxTpr_Organisationid = A11OrganisationId;
                  AV21SDT_Resident.gxTpr_Residentsalutation = A72ResidentSalutation;
                  AV21SDT_Resident.gxTpr_Residentbsnnumber = A63ResidentBsnNumber;
                  AV21SDT_Resident.gxTpr_Residentgivenname = A64ResidentGivenName;
                  AV21SDT_Resident.gxTpr_Residentlastname = A65ResidentLastName;
                  AV21SDT_Resident.gxTpr_Residentinitials = A66ResidentInitials;
                  AV21SDT_Resident.gxTpr_Residentemail = A67ResidentEmail;
                  AV21SDT_Resident.gxTpr_Residentgender = A68ResidentGender;
                  GXt_char5 = "";
                  new prc_concatenateaddress(context ).execute(  A312ResidentCountry,  A313ResidentCity,  A314ResidentZipCode,  A315ResidentAddressLine1,  A316ResidentAddressLine2, out  GXt_char5) ;
                  AV21SDT_Resident.gxTpr_Residentaddress = GXt_char5;
                  AV21SDT_Resident.gxTpr_Residentphone = A70ResidentPhone;
                  AV21SDT_Resident.gxTpr_Residenttypename = A97ResidentTypeName;
                  AV21SDT_Resident.gxTpr_Medicalindicationid = A98MedicalIndicationId;
                  AV21SDT_Resident.gxTpr_Medicalindicationname = A99MedicalIndicationName;
                  AV21SDT_Resident.gxTpr_Residentbirthdate = A73ResidentBirthDate;
                  AV21SDT_Resident.gxTpr_Residenttypeid = A96ResidentTypeId;
                  AV21SDT_Resident.gxTpr_Residenttypename = A97ResidentTypeName;
                  AV21SDT_Resident.gxTpr_Residentguid = A71ResidentGUID;
                  AV22SDT_Residents.Add(AV21SDT_Resident, 0);
                  gx_BV50 = true;
                  pr_default.readNext(2);
               }
               pr_default.close(2);
            }
         }
      }

      protected void S152( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV54OrderedBy), 4, 0))+":"+(AV55OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S182( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV38ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "SDT_Residents__ResidentGivenName",  "",  "First Name",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "SDT_Residents__ResidentLastName",  "",  "Last Name",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "SDT_Residents__ResidentGender",  "",  "Gender",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "SDT_Residents__ResidentEmail",  "",  "Email",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "SDT_Residents__ResidentPhone",  "",  "Phone",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "&AccountStatus",  "",  "Account Status",  true,  "") ;
         GXt_char5 = AV37UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "WP_LocationResidentsColumnsSelector", out  GXt_char5) ;
         AV37UserCustomValue = GXt_char5;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37UserCustomValue)) ) )
         {
            AV39ColumnsSelectorAux.FromXml(AV37UserCustomValue, null, "", "");
            new WorkWithPlus.workwithplus_web.wwp_columnselector_updatecolumns(context ).execute( ref  AV39ColumnsSelectorAux, ref  AV38ColumnsSelector) ;
         }
      }

      protected void S162( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean3 = AV33IsAuthorized_Delete;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_resident_Delete", out  GXt_boolean3) ;
         AV33IsAuthorized_Delete = GXt_boolean3;
         AssignAttri("", false, "AV33IsAuthorized_Delete", AV33IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV33IsAuthorized_Delete, context));
         GXt_boolean3 = AV31IsAuthorized_Insert;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_resident_Insert", out  GXt_boolean3) ;
         AV31IsAuthorized_Insert = GXt_boolean3;
         if ( ! ( AV31IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item6 = AV17ManageFiltersData;
         new WorkWithPlus.workwithplus_web.wwp_managefiltersloadsavedfilters(context ).execute(  "WP_LocationResidentsFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item6) ;
         AV17ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item6;
      }

      protected void S212( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV7FilterFullText = "";
         AssignAttri("", false, "AV7FilterFullText", AV7FilterFullText);
      }

      protected void S232( )
      {
         /* 'DO RESENDINVITE' Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "DVELOP_CONFIRMPANEL_RESENDINVITEContainer", "Confirm", "", new Object[] {});
      }

      protected void S312( )
      {
         /* 'DO ACTION RESENDINVITE' Routine */
         returnInSub = false;
         AV61baseUrl = AV14HTTPRequest.BaseURL;
         AV62ResidentGuid_Selected = ((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Residentguid;
         AV63GAMUser_Resident.load( AV62ResidentGuid_Selected);
         AV49GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV64ActivactionKey = AV63GAMUser_Resident.getnewactivationkey(out  AV49GAMErrors);
         if ( AV49GAMErrors.Count > 0 )
         {
            AV103GXV20 = 1;
            while ( AV103GXV20 <= AV49GAMErrors.Count )
            {
               AV47GAMError = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV49GAMErrors.Item(AV103GXV20));
               GX_msglist.addItem(AV47GAMError.gxTpr_Message);
               AV103GXV20 = (int)(AV103GXV20+1);
            }
         }
         else
         {
            context.CommitDataStores("wp_locationresidents",pr_default);
            new prc_senduseractivationlink(context).executeSubmit(  AV62ResidentGuid_Selected,  AV64ActivactionKey,  AV61baseUrl, ref  AV65isSent, ref  AV67ErrDescroption, ref  AV68GamErrorCollection) ;
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Success",  context.GetMessage( "Invitation sent successfully.", ""),  "success",  "",  "true",  ""));
         }
      }

      protected void S242( )
      {
         /* 'DO USERACTIONUNBLOCK' Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCKContainer", "Confirm", "", new Object[] {});
      }

      protected void S322( )
      {
         /* 'DO ACTION USERACTIONUNBLOCK' Routine */
         returnInSub = false;
         AV49GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         new prc_unblockuser(context ).execute(  ((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Residentguid, out  AV50IsunBlocked, out  AV49GAMErrors) ;
         if ( AV50IsunBlocked )
         {
            gxgrGrid_refresh( subGrid_Rows, AV18ManageFiltersExecutionStep, AV38ColumnsSelector, AV99Pgmname, AV54OrderedBy, AV55OrderedDsc, AV7FilterFullText, AV22SDT_Residents, AV69ResidentPackageId, A11OrganisationId, AV29WWPContext, AV101Udparg1, A29LocationId, AV16LocationOption, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A312ResidentCountry, A313ResidentCity, A314ResidentZipCode, A315ResidentAddressLine1, A316ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, A527ResidentPackageId, AV33IsAuthorized_Delete, AV41IsAuthorized_SDT_Residents, AV78ResidentTitle) ;
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV78ResidentTitle+" "+context.GetMessage( "Unblocked sucessfully", ""),  "success",  "",  "true",  ""));
         }
         if ( AV49GAMErrors.Count > 0 )
         {
            AV104GXV21 = 1;
            while ( AV104GXV21 <= AV49GAMErrors.Count )
            {
               AV47GAMError = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV49GAMErrors.Item(AV104GXV21));
               GX_msglist.addItem(AV47GAMError.gxTpr_Message);
               AV104GXV21 = (int)(AV104GXV21+1);
            }
         }
      }

      protected void S252( )
      {
         /* 'DO USERACTIONBLOCK' Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "DVELOP_CONFIRMPANEL_USERACTIONBLOCKContainer", "Confirm", "", new Object[] {});
      }

      protected void S332( )
      {
         /* 'DO ACTION USERACTIONBLOCK' Routine */
         returnInSub = false;
         AV49GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         new prc_blockuser(context ).execute(  ((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Residentguid, out  AV48IsBlocked, out  AV49GAMErrors) ;
         if ( AV48IsBlocked )
         {
            gxgrGrid_refresh( subGrid_Rows, AV18ManageFiltersExecutionStep, AV38ColumnsSelector, AV99Pgmname, AV54OrderedBy, AV55OrderedDsc, AV7FilterFullText, AV22SDT_Residents, AV69ResidentPackageId, A11OrganisationId, AV29WWPContext, AV101Udparg1, A29LocationId, AV16LocationOption, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A312ResidentCountry, A313ResidentCity, A314ResidentZipCode, A315ResidentAddressLine1, A316ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, A527ResidentPackageId, AV33IsAuthorized_Delete, AV41IsAuthorized_SDT_Residents, AV78ResidentTitle) ;
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV78ResidentTitle+" "+context.GetMessage( "Blocked sucessfully", ""),  "success",  "",  "true",  ""));
         }
         if ( AV49GAMErrors.Count > 0 )
         {
            AV105GXV22 = 1;
            while ( AV105GXV22 <= AV49GAMErrors.Count )
            {
               AV47GAMError = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV49GAMErrors.Item(AV105GXV22));
               GX_msglist.addItem(AV47GAMError.gxTpr_Message);
               AV105GXV22 = (int)(AV105GXV22+1);
            }
         }
      }

      protected void S262( )
      {
         /* 'DO VIEWQRCODE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wp_residentqrcode.aspx"+UrlEncode(StringUtil.RTrim(((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Residentguid)) + "," + UrlEncode(StringUtil.RTrim(((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Residentemail));
         context.PopUp(formatLink("wp_residentqrcode.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
      }

      protected void S272( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "trn_residentview.aspx"+UrlEncode(((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Residentid.ToString()) + "," + UrlEncode(((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Locationid.ToString()) + "," + UrlEncode(((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Organisationid.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("trn_residentview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S282( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "trn_resident.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Residentid.ToString()) + "," + UrlEncode(((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Locationid.ToString()) + "," + UrlEncode(((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Organisationid.ToString());
         CallWebObject(formatLink("trn_resident.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S292( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "trn_resident.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Residentid.ToString()) + "," + UrlEncode(((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Locationid.ToString()) + "," + UrlEncode(((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Organisationid.ToString());
         CallWebObject(formatLink("trn_resident.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S302( )
      {
         /* 'DO UDELETE' Routine */
         returnInSub = false;
         Dvelop_confirmpanel_udelete_Title = context.GetMessage( "Confirm delete action", "");
         ucDvelop_confirmpanel_udelete.SendProperty(context, "", false, Dvelop_confirmpanel_udelete_Internalname, "Title", Dvelop_confirmpanel_udelete_Title);
         Dvelop_confirmpanel_udelete_Confirmationtext = context.GetMessage( "The following data associated with the resident will be deleted: Memos", "");
         ucDvelop_confirmpanel_udelete.SendProperty(context, "", false, Dvelop_confirmpanel_udelete_Internalname, "ConfirmationText", Dvelop_confirmpanel_udelete_Confirmationtext);
         AV75Selected_ResidentId = ((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Residentid;
         AssignAttri("", false, "AV75Selected_ResidentId", AV75Selected_ResidentId.ToString());
         AV76Selected_LocationId = ((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Locationid;
         AssignAttri("", false, "AV76Selected_LocationId", AV76Selected_LocationId.ToString());
         AV77Selected_OrganisationId = ((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Organisationid;
         AssignAttri("", false, "AV77Selected_OrganisationId", AV77Selected_OrganisationId.ToString());
         this.executeUsercontrolMethod("", false, "DVELOP_CONFIRMPANEL_UDELETEContainer", "Confirm", "", new Object[] {});
      }

      protected void S342( )
      {
         /* 'DO ACTION UDELETE' Routine */
         returnInSub = false;
         new prc_deletecascaderesident(context ).execute(  AV75Selected_ResidentId,  AV76Selected_LocationId,  AV77Selected_OrganisationId,  true, ref  AV34isSuccessful, ref  AV72Message) ;
         AssignAttri("", false, "AV34isSuccessful", AV34isSuccessful);
         AssignAttri("", false, "AV72Message", AV72Message);
         if ( AV34isSuccessful )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  context.GetMessage( "Deleted ", "")+AV78ResidentTitle+context.GetMessage( " successfully", ""),  "success",  "",  "true",  ""));
            gxgrGrid_refresh( subGrid_Rows, AV18ManageFiltersExecutionStep, AV38ColumnsSelector, AV99Pgmname, AV54OrderedBy, AV55OrderedDsc, AV7FilterFullText, AV22SDT_Residents, AV69ResidentPackageId, A11OrganisationId, AV29WWPContext, AV101Udparg1, A29LocationId, AV16LocationOption, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A312ResidentCountry, A313ResidentCity, A314ResidentZipCode, A315ResidentAddressLine1, A316ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, A527ResidentPackageId, AV33IsAuthorized_Delete, AV41IsAuthorized_SDT_Residents, AV78ResidentTitle) ;
         }
         else
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV72Message,  "error",  "",  "true",  ""));
         }
      }

      protected void S142( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV24Session.Get(AV99Pgmname+"GridState"), "") == 0 )
         {
            AV12GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV99Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV12GridState.FromXml(AV24Session.Get(AV99Pgmname+"GridState"), null, "", "");
         }
         AV54OrderedBy = AV12GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV54OrderedBy", StringUtil.LTrimStr( (decimal)(AV54OrderedBy), 4, 0));
         AV55OrderedDsc = AV12GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV55OrderedDsc", AV55OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S152 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S222 ();
         if (returnInSub) return;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV12GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV12GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV12GridState.gxTpr_Currentpage) ;
      }

      protected void S222( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV106GXV23 = 1;
         while ( AV106GXV23 <= AV12GridState.gxTpr_Filtervalues.Count )
         {
            AV13GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV12GridState.gxTpr_Filtervalues.Item(AV106GXV23));
            if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV7FilterFullText = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV7FilterFullText", AV7FilterFullText);
            }
            AV106GXV23 = (int)(AV106GXV23+1);
         }
      }

      protected void S172( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV12GridState.FromXml(AV24Session.Get(AV99Pgmname+"GridState"), null, "", "");
         AV12GridState.gxTpr_Orderedby = AV54OrderedBy;
         AV12GridState.gxTpr_Ordereddsc = AV55OrderedDsc;
         AV12GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV7FilterFullText)),  0,  AV7FilterFullText,  AV7FilterFullText,  false,  "",  "") ;
         AV12GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV12GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV99Pgmname+"GridState",  AV12GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ! (Guid.Empty==AV16LocationOption) ) )
         {
            Combo_residentpackageid_Visible = false;
            ucCombo_residentpackageid.SendProperty(context, "", false, Combo_residentpackageid_Internalname, "Visible", StringUtil.BoolToStr( Combo_residentpackageid_Visible));
            divCombo_residentpackageid_cell_Class = "Invisible";
            AssignProp("", false, divCombo_residentpackageid_cell_Internalname, "Class", divCombo_residentpackageid_cell_Class, true);
         }
         else
         {
            Combo_residentpackageid_Visible = true;
            ucCombo_residentpackageid.SendProperty(context, "", false, Combo_residentpackageid_Internalname, "Visible", StringUtil.BoolToStr( Combo_residentpackageid_Visible));
            divCombo_residentpackageid_cell_Class = "col-xs-12 ExtendedComboCell";
            AssignProp("", false, divCombo_residentpackageid_cell_Internalname, "Class", divCombo_residentpackageid_cell_Class, true);
         }
         if ( ! Combo_residentpackageid_Visible )
         {
            divUnnamedtable1_Visible = 0;
            AssignProp("", false, divUnnamedtable1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUnnamedtable1_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBORESIDENTPACKAGEID' Routine */
         returnInSub = false;
         /* Using cursor H005J5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A527ResidentPackageId = H005J5_A527ResidentPackageId[0];
            n527ResidentPackageId = H005J5_n527ResidentPackageId[0];
            A531ResidentPackageName = H005J5_A531ResidentPackageName[0];
            AV71Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV71Combo_DataItem.gxTpr_Id = StringUtil.Trim( A527ResidentPackageId.ToString());
            AV71Combo_DataItem.gxTpr_Title = A531ResidentPackageName;
            AV70ResidentPackageId_Data.Add(AV71Combo_DataItem, 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         Combo_residentpackageid_Selectedvalue_set = ((Guid.Empty==AV69ResidentPackageId) ? "" : StringUtil.Trim( AV69ResidentPackageId.ToString()));
         ucCombo_residentpackageid.SendProperty(context, "", false, Combo_residentpackageid_Internalname, "SelectedValue_set", Combo_residentpackageid_Selectedvalue_set);
      }

      protected void E225J2( )
      {
         AV80GXV1 = (int)(nGXsfl_50_idx+GRID_nFirstRecordOnPage);
         if ( ( AV80GXV1 > 0 ) && ( AV22SDT_Residents.Count >= AV80GXV1 ) )
         {
            AV22SDT_Residents.CurrentItem = ((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1));
         }
         /* Locationoption_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSDT' */
         S192 ();
         if (returnInSub) return;
         AV16LocationOption = AV29WWPContext.gxTpr_Locationid;
         AssignAttri("", false, "AV16LocationOption", AV16LocationOption.ToString());
         /*  Sending Event outputs  */
         dynavLocationoption.CurrentValue = AV16LocationOption.ToString();
         AssignProp("", false, dynavLocationoption_Internalname, "Values", dynavLocationoption.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22SDT_Residents", AV22SDT_Residents);
         nGXsfl_50_bak_idx = nGXsfl_50_idx;
         gxgrGrid_refresh( subGrid_Rows, AV18ManageFiltersExecutionStep, AV38ColumnsSelector, AV99Pgmname, AV54OrderedBy, AV55OrderedDsc, AV7FilterFullText, AV22SDT_Residents, AV69ResidentPackageId, A11OrganisationId, AV29WWPContext, AV101Udparg1, A29LocationId, AV16LocationOption, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A312ResidentCountry, A313ResidentCity, A314ResidentZipCode, A315ResidentAddressLine1, A316ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, A527ResidentPackageId, AV33IsAuthorized_Delete, AV41IsAuthorized_SDT_Residents, AV78ResidentTitle) ;
         nGXsfl_50_idx = nGXsfl_50_bak_idx;
         sGXsfl_50_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_50_idx), 4, 0), 4, "0");
         SubsflControlProps_502( ) ;
      }

      protected void E235J2( )
      {
         /* Filterfulltext_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'RELOADGRIDSDT' */
         S202 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         if ( gx_BV50 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22SDT_Residents", AV22SDT_Residents);
            nGXsfl_50_bak_idx = nGXsfl_50_idx;
            gxgrGrid_refresh( subGrid_Rows, AV18ManageFiltersExecutionStep, AV38ColumnsSelector, AV99Pgmname, AV54OrderedBy, AV55OrderedDsc, AV7FilterFullText, AV22SDT_Residents, AV69ResidentPackageId, A11OrganisationId, AV29WWPContext, AV101Udparg1, A29LocationId, AV16LocationOption, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A312ResidentCountry, A313ResidentCity, A314ResidentZipCode, A315ResidentAddressLine1, A316ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, A527ResidentPackageId, AV33IsAuthorized_Delete, AV41IsAuthorized_SDT_Residents, AV78ResidentTitle) ;
            nGXsfl_50_idx = nGXsfl_50_bak_idx;
            sGXsfl_50_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_50_idx), 4, 0), 4, "0");
            SubsflControlProps_502( ) ;
         }
      }

      protected void S202( )
      {
         /* 'RELOADGRIDSDT' Routine */
         returnInSub = false;
         if ( (Guid.Empty==AV69ResidentPackageId) )
         {
            AV22SDT_Residents.Clear();
            gx_BV50 = true;
            AV101Udparg1 = new prc_getuserorganisationid(context).executeUdp( );
            pr_default.dynParam(4, new Object[]{ new Object[]{
                                                 AV16LocationOption ,
                                                 A29LocationId ,
                                                 A11OrganisationId ,
                                                 AV29WWPContext.gxTpr_Isrootadmin ,
                                                 AV29WWPContext.gxTpr_Organisationid ,
                                                 AV101Udparg1 } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN
                                                 }
            });
            /* Using cursor H005J6 */
            pr_default.execute(4, new Object[] {AV29WWPContext.gxTpr_Organisationid, AV29WWPContext.gxTpr_Isrootadmin, AV101Udparg1, AV16LocationOption});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A29LocationId = H005J6_A29LocationId[0];
               A11OrganisationId = H005J6_A11OrganisationId[0];
               A62ResidentId = H005J6_A62ResidentId[0];
               A72ResidentSalutation = H005J6_A72ResidentSalutation[0];
               A63ResidentBsnNumber = H005J6_A63ResidentBsnNumber[0];
               A64ResidentGivenName = H005J6_A64ResidentGivenName[0];
               A65ResidentLastName = H005J6_A65ResidentLastName[0];
               A66ResidentInitials = H005J6_A66ResidentInitials[0];
               A67ResidentEmail = H005J6_A67ResidentEmail[0];
               A68ResidentGender = H005J6_A68ResidentGender[0];
               A312ResidentCountry = H005J6_A312ResidentCountry[0];
               A313ResidentCity = H005J6_A313ResidentCity[0];
               A314ResidentZipCode = H005J6_A314ResidentZipCode[0];
               A315ResidentAddressLine1 = H005J6_A315ResidentAddressLine1[0];
               A316ResidentAddressLine2 = H005J6_A316ResidentAddressLine2[0];
               A70ResidentPhone = H005J6_A70ResidentPhone[0];
               A97ResidentTypeName = H005J6_A97ResidentTypeName[0];
               A98MedicalIndicationId = H005J6_A98MedicalIndicationId[0];
               n98MedicalIndicationId = H005J6_n98MedicalIndicationId[0];
               A99MedicalIndicationName = H005J6_A99MedicalIndicationName[0];
               A73ResidentBirthDate = H005J6_A73ResidentBirthDate[0];
               A96ResidentTypeId = H005J6_A96ResidentTypeId[0];
               n96ResidentTypeId = H005J6_n96ResidentTypeId[0];
               A71ResidentGUID = H005J6_A71ResidentGUID[0];
               A99MedicalIndicationName = H005J6_A99MedicalIndicationName[0];
               A97ResidentTypeName = H005J6_A97ResidentTypeName[0];
               AV21SDT_Resident = new SdtSDT_Resident(context);
               AV21SDT_Resident.gxTpr_Residentid = A62ResidentId;
               AV21SDT_Resident.gxTpr_Locationid = A29LocationId;
               AV21SDT_Resident.gxTpr_Organisationid = A11OrganisationId;
               AV21SDT_Resident.gxTpr_Residentsalutation = A72ResidentSalutation;
               AV21SDT_Resident.gxTpr_Residentbsnnumber = A63ResidentBsnNumber;
               AV21SDT_Resident.gxTpr_Residentgivenname = A64ResidentGivenName;
               AV21SDT_Resident.gxTpr_Residentlastname = A65ResidentLastName;
               AV21SDT_Resident.gxTpr_Residentinitials = A66ResidentInitials;
               AV21SDT_Resident.gxTpr_Residentemail = A67ResidentEmail;
               AV21SDT_Resident.gxTpr_Residentgender = A68ResidentGender;
               GXt_char5 = "";
               new prc_concatenateaddress(context ).execute(  A312ResidentCountry,  A313ResidentCity,  A314ResidentZipCode,  A315ResidentAddressLine1,  A316ResidentAddressLine2, out  GXt_char5) ;
               AV21SDT_Resident.gxTpr_Residentaddress = GXt_char5;
               AV21SDT_Resident.gxTpr_Residentphone = A70ResidentPhone;
               AV21SDT_Resident.gxTpr_Residenttypename = A97ResidentTypeName;
               AV21SDT_Resident.gxTpr_Medicalindicationid = A98MedicalIndicationId;
               AV21SDT_Resident.gxTpr_Medicalindicationname = A99MedicalIndicationName;
               AV21SDT_Resident.gxTpr_Residentbirthdate = A73ResidentBirthDate;
               AV21SDT_Resident.gxTpr_Residenttypeid = A96ResidentTypeId;
               AV21SDT_Resident.gxTpr_Residenttypename = A97ResidentTypeName;
               AV21SDT_Resident.gxTpr_Residentguid = A71ResidentGUID;
               AV22SDT_Residents.Add(AV21SDT_Resident, 0);
               gx_BV50 = true;
               pr_default.readNext(4);
            }
            pr_default.close(4);
         }
         else
         {
            if ( ! (Guid.Empty==AV69ResidentPackageId) )
            {
               AV22SDT_Residents.Clear();
               gx_BV50 = true;
               pr_default.dynParam(5, new Object[]{ new Object[]{
                                                    AV16LocationOption ,
                                                    AV69ResidentPackageId ,
                                                    A29LocationId ,
                                                    A527ResidentPackageId } ,
                                                    new int[]{
                                                    TypeConstants.BOOLEAN
                                                    }
               });
               /* Using cursor H005J7 */
               pr_default.execute(5, new Object[] {AV16LocationOption, AV69ResidentPackageId});
               while ( (pr_default.getStatus(5) != 101) )
               {
                  A527ResidentPackageId = H005J7_A527ResidentPackageId[0];
                  n527ResidentPackageId = H005J7_n527ResidentPackageId[0];
                  A29LocationId = H005J7_A29LocationId[0];
                  A62ResidentId = H005J7_A62ResidentId[0];
                  A11OrganisationId = H005J7_A11OrganisationId[0];
                  A72ResidentSalutation = H005J7_A72ResidentSalutation[0];
                  A63ResidentBsnNumber = H005J7_A63ResidentBsnNumber[0];
                  A64ResidentGivenName = H005J7_A64ResidentGivenName[0];
                  A65ResidentLastName = H005J7_A65ResidentLastName[0];
                  A66ResidentInitials = H005J7_A66ResidentInitials[0];
                  A67ResidentEmail = H005J7_A67ResidentEmail[0];
                  A68ResidentGender = H005J7_A68ResidentGender[0];
                  A312ResidentCountry = H005J7_A312ResidentCountry[0];
                  A313ResidentCity = H005J7_A313ResidentCity[0];
                  A314ResidentZipCode = H005J7_A314ResidentZipCode[0];
                  A315ResidentAddressLine1 = H005J7_A315ResidentAddressLine1[0];
                  A316ResidentAddressLine2 = H005J7_A316ResidentAddressLine2[0];
                  A70ResidentPhone = H005J7_A70ResidentPhone[0];
                  A97ResidentTypeName = H005J7_A97ResidentTypeName[0];
                  A98MedicalIndicationId = H005J7_A98MedicalIndicationId[0];
                  n98MedicalIndicationId = H005J7_n98MedicalIndicationId[0];
                  A99MedicalIndicationName = H005J7_A99MedicalIndicationName[0];
                  A73ResidentBirthDate = H005J7_A73ResidentBirthDate[0];
                  A96ResidentTypeId = H005J7_A96ResidentTypeId[0];
                  n96ResidentTypeId = H005J7_n96ResidentTypeId[0];
                  A71ResidentGUID = H005J7_A71ResidentGUID[0];
                  A99MedicalIndicationName = H005J7_A99MedicalIndicationName[0];
                  A97ResidentTypeName = H005J7_A97ResidentTypeName[0];
                  AV21SDT_Resident = new SdtSDT_Resident(context);
                  AV21SDT_Resident.gxTpr_Residentid = A62ResidentId;
                  AV21SDT_Resident.gxTpr_Locationid = A29LocationId;
                  AV21SDT_Resident.gxTpr_Organisationid = A11OrganisationId;
                  AV21SDT_Resident.gxTpr_Residentsalutation = A72ResidentSalutation;
                  AV21SDT_Resident.gxTpr_Residentbsnnumber = A63ResidentBsnNumber;
                  AV21SDT_Resident.gxTpr_Residentgivenname = A64ResidentGivenName;
                  AV21SDT_Resident.gxTpr_Residentlastname = A65ResidentLastName;
                  AV21SDT_Resident.gxTpr_Residentinitials = A66ResidentInitials;
                  AV21SDT_Resident.gxTpr_Residentemail = A67ResidentEmail;
                  AV21SDT_Resident.gxTpr_Residentgender = A68ResidentGender;
                  GXt_char5 = "";
                  new prc_concatenateaddress(context ).execute(  A312ResidentCountry,  A313ResidentCity,  A314ResidentZipCode,  A315ResidentAddressLine1,  A316ResidentAddressLine2, out  GXt_char5) ;
                  AV21SDT_Resident.gxTpr_Residentaddress = GXt_char5;
                  AV21SDT_Resident.gxTpr_Residentphone = A70ResidentPhone;
                  AV21SDT_Resident.gxTpr_Residenttypename = A97ResidentTypeName;
                  AV21SDT_Resident.gxTpr_Medicalindicationid = A98MedicalIndicationId;
                  AV21SDT_Resident.gxTpr_Medicalindicationname = A99MedicalIndicationName;
                  AV21SDT_Resident.gxTpr_Residentbirthdate = A73ResidentBirthDate;
                  AV21SDT_Resident.gxTpr_Residenttypeid = A96ResidentTypeId;
                  AV21SDT_Resident.gxTpr_Residenttypename = A97ResidentTypeName;
                  AV21SDT_Resident.gxTpr_Residentguid = A71ResidentGUID;
                  AV22SDT_Residents.Add(AV21SDT_Resident, 0);
                  gx_BV50 = true;
                  pr_default.readNext(5);
               }
               pr_default.close(5);
            }
         }
      }

      protected void wb_table4_95_5J2( bool wbgen )
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
            wb_table4_95_5J2e( true) ;
         }
         else
         {
            wb_table4_95_5J2e( false) ;
         }
      }

      protected void wb_table3_90_5J2( bool wbgen )
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
            wb_table3_90_5J2e( true) ;
         }
         else
         {
            wb_table3_90_5J2e( false) ;
         }
      }

      protected void wb_table2_85_5J2( bool wbgen )
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
            wb_table2_85_5J2e( true) ;
         }
         else
         {
            wb_table2_85_5J2e( false) ;
         }
      }

      protected void wb_table1_80_5J2( bool wbgen )
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
            wb_table1_80_5J2e( true) ;
         }
         else
         {
            wb_table1_80_5J2e( false) ;
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
         PA5J2( ) ;
         WS5J2( ) ;
         WE5J2( ) ;
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
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20257212571254", true, true);
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
         context.AddJavascriptSource("wp_locationresidents.js", "?20257212571256", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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

      protected void SubsflControlProps_502( )
      {
         edtavSdt_residents__residentid_Internalname = "SDT_RESIDENTS__RESIDENTID_"+sGXsfl_50_idx;
         edtavSdt_residents__locationid_Internalname = "SDT_RESIDENTS__LOCATIONID_"+sGXsfl_50_idx;
         edtavSdt_residents__organisationid_Internalname = "SDT_RESIDENTS__ORGANISATIONID_"+sGXsfl_50_idx;
         edtavSdt_residents__residentbsnnumber_Internalname = "SDT_RESIDENTS__RESIDENTBSNNUMBER_"+sGXsfl_50_idx;
         cmbavSdt_residents__residentsalutation_Internalname = "SDT_RESIDENTS__RESIDENTSALUTATION_"+sGXsfl_50_idx;
         edtavSdt_residents__residentgivenname_Internalname = "SDT_RESIDENTS__RESIDENTGIVENNAME_"+sGXsfl_50_idx;
         edtavSdt_residents__residentlastname_Internalname = "SDT_RESIDENTS__RESIDENTLASTNAME_"+sGXsfl_50_idx;
         edtavSdt_residents__residentinitials_Internalname = "SDT_RESIDENTS__RESIDENTINITIALS_"+sGXsfl_50_idx;
         cmbavSdt_residents__residentgender_Internalname = "SDT_RESIDENTS__RESIDENTGENDER_"+sGXsfl_50_idx;
         edtavSdt_residents__residentbirthdate_Internalname = "SDT_RESIDENTS__RESIDENTBIRTHDATE_"+sGXsfl_50_idx;
         edtavSdt_residents__residentemail_Internalname = "SDT_RESIDENTS__RESIDENTEMAIL_"+sGXsfl_50_idx;
         edtavSdt_residents__residentphone_Internalname = "SDT_RESIDENTS__RESIDENTPHONE_"+sGXsfl_50_idx;
         edtavSdt_residents__residentguid_Internalname = "SDT_RESIDENTS__RESIDENTGUID_"+sGXsfl_50_idx;
         edtavSdt_residents__residenttypeid_Internalname = "SDT_RESIDENTS__RESIDENTTYPEID_"+sGXsfl_50_idx;
         edtavSdt_residents__residenttypename_Internalname = "SDT_RESIDENTS__RESIDENTTYPENAME_"+sGXsfl_50_idx;
         edtavSdt_residents__medicalindicationid_Internalname = "SDT_RESIDENTS__MEDICALINDICATIONID_"+sGXsfl_50_idx;
         edtavSdt_residents__medicalindicationname_Internalname = "SDT_RESIDENTS__MEDICALINDICATIONNAME_"+sGXsfl_50_idx;
         edtavSdt_residents__residentaddress_Internalname = "SDT_RESIDENTS__RESIDENTADDRESS_"+sGXsfl_50_idx;
         edtavAccountstatus_Internalname = "vACCOUNTSTATUS_"+sGXsfl_50_idx;
         cmbavActiongroup_Internalname = "vACTIONGROUP_"+sGXsfl_50_idx;
      }

      protected void SubsflControlProps_fel_502( )
      {
         edtavSdt_residents__residentid_Internalname = "SDT_RESIDENTS__RESIDENTID_"+sGXsfl_50_fel_idx;
         edtavSdt_residents__locationid_Internalname = "SDT_RESIDENTS__LOCATIONID_"+sGXsfl_50_fel_idx;
         edtavSdt_residents__organisationid_Internalname = "SDT_RESIDENTS__ORGANISATIONID_"+sGXsfl_50_fel_idx;
         edtavSdt_residents__residentbsnnumber_Internalname = "SDT_RESIDENTS__RESIDENTBSNNUMBER_"+sGXsfl_50_fel_idx;
         cmbavSdt_residents__residentsalutation_Internalname = "SDT_RESIDENTS__RESIDENTSALUTATION_"+sGXsfl_50_fel_idx;
         edtavSdt_residents__residentgivenname_Internalname = "SDT_RESIDENTS__RESIDENTGIVENNAME_"+sGXsfl_50_fel_idx;
         edtavSdt_residents__residentlastname_Internalname = "SDT_RESIDENTS__RESIDENTLASTNAME_"+sGXsfl_50_fel_idx;
         edtavSdt_residents__residentinitials_Internalname = "SDT_RESIDENTS__RESIDENTINITIALS_"+sGXsfl_50_fel_idx;
         cmbavSdt_residents__residentgender_Internalname = "SDT_RESIDENTS__RESIDENTGENDER_"+sGXsfl_50_fel_idx;
         edtavSdt_residents__residentbirthdate_Internalname = "SDT_RESIDENTS__RESIDENTBIRTHDATE_"+sGXsfl_50_fel_idx;
         edtavSdt_residents__residentemail_Internalname = "SDT_RESIDENTS__RESIDENTEMAIL_"+sGXsfl_50_fel_idx;
         edtavSdt_residents__residentphone_Internalname = "SDT_RESIDENTS__RESIDENTPHONE_"+sGXsfl_50_fel_idx;
         edtavSdt_residents__residentguid_Internalname = "SDT_RESIDENTS__RESIDENTGUID_"+sGXsfl_50_fel_idx;
         edtavSdt_residents__residenttypeid_Internalname = "SDT_RESIDENTS__RESIDENTTYPEID_"+sGXsfl_50_fel_idx;
         edtavSdt_residents__residenttypename_Internalname = "SDT_RESIDENTS__RESIDENTTYPENAME_"+sGXsfl_50_fel_idx;
         edtavSdt_residents__medicalindicationid_Internalname = "SDT_RESIDENTS__MEDICALINDICATIONID_"+sGXsfl_50_fel_idx;
         edtavSdt_residents__medicalindicationname_Internalname = "SDT_RESIDENTS__MEDICALINDICATIONNAME_"+sGXsfl_50_fel_idx;
         edtavSdt_residents__residentaddress_Internalname = "SDT_RESIDENTS__RESIDENTADDRESS_"+sGXsfl_50_fel_idx;
         edtavAccountstatus_Internalname = "vACCOUNTSTATUS_"+sGXsfl_50_fel_idx;
         cmbavActiongroup_Internalname = "vACTIONGROUP_"+sGXsfl_50_fel_idx;
      }

      protected void sendrow_502( )
      {
         sGXsfl_50_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_50_idx), 4, 0), 4, "0");
         SubsflControlProps_502( ) ;
         WB5J0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_50_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_50_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_50_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentid_Internalname,((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Residentid.ToString(),((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Residentid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residentid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)50,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__locationid_Internalname,((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Locationid.ToString(),((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Locationid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__locationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__locationid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)50,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__organisationid_Internalname,((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Organisationid.ToString(),((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Organisationid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__organisationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__organisationid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)50,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentbsnnumber_Internalname,((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Residentbsnnumber,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentbsnnumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residentbsnnumber_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)50,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbavSdt_residents__residentsalutation.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SDT_RESIDENTS__RESIDENTSALUTATION_" + sGXsfl_50_idx;
               cmbavSdt_residents__residentsalutation.Name = GXCCtl;
               cmbavSdt_residents__residentsalutation.WebTags = "";
               cmbavSdt_residents__residentsalutation.addItem("Mr", context.GetMessage( "Mr", ""), 0);
               cmbavSdt_residents__residentsalutation.addItem("Mrs", context.GetMessage( "Mrs", ""), 0);
               cmbavSdt_residents__residentsalutation.addItem("Dr", context.GetMessage( "Dr", ""), 0);
               cmbavSdt_residents__residentsalutation.addItem("Miss", context.GetMessage( "Miss", ""), 0);
               if ( cmbavSdt_residents__residentsalutation.ItemCount > 0 )
               {
                  if ( ( AV80GXV1 > 0 ) && ( AV22SDT_Residents.Count >= AV80GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Residentsalutation)) )
                  {
                     ((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Residentsalutation = cmbavSdt_residents__residentsalutation.getValidValue(((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Residentsalutation);
                  }
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavSdt_residents__residentsalutation,(string)cmbavSdt_residents__residentsalutation_Internalname,StringUtil.RTrim( ((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Residentsalutation),(short)1,(string)cmbavSdt_residents__residentsalutation_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)0,cmbavSdt_residents__residentsalutation.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"",(bool)true,(short)0});
            cmbavSdt_residents__residentsalutation.CurrentValue = StringUtil.RTrim( ((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Residentsalutation);
            AssignProp("", false, cmbavSdt_residents__residentsalutation_Internalname, "Values", (string)(cmbavSdt_residents__residentsalutation.ToJavascriptSource()), !bGXsfl_50_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavSdt_residents__residentgivenname_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_50_idx + "',50)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentgivenname_Internalname,((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Residentgivenname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavSdt_residents__residentgivenname_Link,(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentgivenname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavSdt_residents__residentgivenname_Visible,(int)edtavSdt_residents__residentgivenname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)50,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavSdt_residents__residentlastname_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_50_idx + "',50)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentlastname_Internalname,((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Residentlastname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavSdt_residents__residentlastname_Link,(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentlastname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavSdt_residents__residentlastname_Visible,(int)edtavSdt_residents__residentlastname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)50,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentinitials_Internalname,StringUtil.RTrim( ((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Residentinitials),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentinitials_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residentinitials_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)50,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbavSdt_residents__residentgender.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_50_idx + "',50)\"";
            if ( ( cmbavSdt_residents__residentgender.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SDT_RESIDENTS__RESIDENTGENDER_" + sGXsfl_50_idx;
               cmbavSdt_residents__residentgender.Name = GXCCtl;
               cmbavSdt_residents__residentgender.WebTags = "";
               cmbavSdt_residents__residentgender.addItem("Male", context.GetMessage( "Male", ""), 0);
               cmbavSdt_residents__residentgender.addItem("Female", context.GetMessage( "Female", ""), 0);
               cmbavSdt_residents__residentgender.addItem("Other", context.GetMessage( "Other", ""), 0);
               if ( cmbavSdt_residents__residentgender.ItemCount > 0 )
               {
                  if ( ( AV80GXV1 > 0 ) && ( AV22SDT_Residents.Count >= AV80GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Residentgender)) )
                  {
                     ((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Residentgender = cmbavSdt_residents__residentgender.getValidValue(((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Residentgender);
                  }
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavSdt_residents__residentgender,(string)cmbavSdt_residents__residentgender_Internalname,StringUtil.RTrim( ((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Residentgender),(short)1,(string)cmbavSdt_residents__residentgender_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",cmbavSdt_residents__residentgender.Visible,cmbavSdt_residents__residentgender.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"",(string)"",(bool)true,(short)0});
            cmbavSdt_residents__residentgender.CurrentValue = StringUtil.RTrim( ((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Residentgender);
            AssignProp("", false, cmbavSdt_residents__residentgender_Internalname, "Values", (string)(cmbavSdt_residents__residentgender.ToJavascriptSource()), !bGXsfl_50_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentbirthdate_Internalname,context.localUtil.Format(((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Residentbirthdate, "99/99/9999"),context.localUtil.Format( ((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Residentbirthdate, "99/99/9999"),""+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentbirthdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residentbirthdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)50,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavSdt_residents__residentemail_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'" + sGXsfl_50_idx + "',50)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentemail_Internalname,((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Residentemail,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentemail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavSdt_residents__residentemail_Visible,(int)edtavSdt_residents__residentemail_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)50,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavSdt_residents__residentphone_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'" + sGXsfl_50_idx + "',50)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentphone_Internalname,StringUtil.RTrim( ((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Residentphone),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentphone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavSdt_residents__residentphone_Visible,(int)edtavSdt_residents__residentphone_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)50,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentguid_Internalname,((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Residentguid,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentguid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residentguid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)50,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residenttypeid_Internalname,((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Residenttypeid.ToString(),((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Residenttypeid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residenttypeid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residenttypeid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)50,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residenttypename_Internalname,((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Residenttypename,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residenttypename_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residenttypename_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)50,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__medicalindicationid_Internalname,((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Medicalindicationid.ToString(),((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Medicalindicationid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__medicalindicationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__medicalindicationid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)50,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__medicalindicationname_Internalname,((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Medicalindicationname,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__medicalindicationname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__medicalindicationname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)50,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentaddress_Internalname,((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Residentaddress,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentaddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residentaddress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)50,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavAccountstatus_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'" + sGXsfl_50_idx + "',50)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavAccountstatus_Internalname,(string)AV44AccountStatus,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavAccountstatus_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavAccountstatus_Columnclass,(string)edtavAccountstatus_Columnheaderclass,(int)edtavAccountstatus_Visible,(int)edtavAccountstatus_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)50,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'" + sGXsfl_50_idx + "',50)\"";
            if ( ( cmbavActiongroup.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vACTIONGROUP_" + sGXsfl_50_idx;
               cmbavActiongroup.Name = GXCCtl;
               cmbavActiongroup.WebTags = "";
               if ( cmbavActiongroup.ItemCount > 0 )
               {
                  if ( ( AV80GXV1 > 0 ) && ( AV22SDT_Residents.Count >= AV80GXV1 ) && (0==AV35ActionGroup) )
                  {
                     AV35ActionGroup = (short)(Math.Round(NumberUtil.Val( cmbavActiongroup.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV35ActionGroup), 4, 0))), "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV35ActionGroup), 4, 0));
                  }
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavActiongroup,(string)cmbavActiongroup_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV35ActionGroup), 4, 0)),(short)1,(string)cmbavActiongroup_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVACTIONGROUP.CLICK."+sGXsfl_50_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,70);\"",(string)"",(bool)true,(short)0});
            cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV35ActionGroup), 4, 0));
            AssignProp("", false, cmbavActiongroup_Internalname, "Values", (string)(cmbavActiongroup.ToJavascriptSource()), !bGXsfl_50_Refreshing);
            send_integrity_lvl_hashes5J2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_50_idx = ((subGrid_Islastpage==1)&&(nGXsfl_50_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_50_idx+1);
            sGXsfl_50_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_50_idx), 4, 0), 4, "0");
            SubsflControlProps_502( ) ;
         }
         /* End function sendrow_502 */
      }

      protected void init_web_controls( )
      {
         dynavLocationoption.Name = "vLOCATIONOPTION";
         dynavLocationoption.WebTags = "";
         GXCCtl = "SDT_RESIDENTS__RESIDENTSALUTATION_" + sGXsfl_50_idx;
         cmbavSdt_residents__residentsalutation.Name = GXCCtl;
         cmbavSdt_residents__residentsalutation.WebTags = "";
         cmbavSdt_residents__residentsalutation.addItem("Mr", context.GetMessage( "Mr", ""), 0);
         cmbavSdt_residents__residentsalutation.addItem("Mrs", context.GetMessage( "Mrs", ""), 0);
         cmbavSdt_residents__residentsalutation.addItem("Dr", context.GetMessage( "Dr", ""), 0);
         cmbavSdt_residents__residentsalutation.addItem("Miss", context.GetMessage( "Miss", ""), 0);
         if ( cmbavSdt_residents__residentsalutation.ItemCount > 0 )
         {
            if ( ( AV80GXV1 > 0 ) && ( AV22SDT_Residents.Count >= AV80GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Residentsalutation)) )
            {
               ((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Residentsalutation = cmbavSdt_residents__residentsalutation.getValidValue(((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Residentsalutation);
            }
         }
         GXCCtl = "SDT_RESIDENTS__RESIDENTGENDER_" + sGXsfl_50_idx;
         cmbavSdt_residents__residentgender.Name = GXCCtl;
         cmbavSdt_residents__residentgender.WebTags = "";
         cmbavSdt_residents__residentgender.addItem("Male", context.GetMessage( "Male", ""), 0);
         cmbavSdt_residents__residentgender.addItem("Female", context.GetMessage( "Female", ""), 0);
         cmbavSdt_residents__residentgender.addItem("Other", context.GetMessage( "Other", ""), 0);
         if ( cmbavSdt_residents__residentgender.ItemCount > 0 )
         {
            if ( ( AV80GXV1 > 0 ) && ( AV22SDT_Residents.Count >= AV80GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Residentgender)) )
            {
               ((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Residentgender = cmbavSdt_residents__residentgender.getValidValue(((SdtSDT_Resident)AV22SDT_Residents.Item(AV80GXV1)).gxTpr_Residentgender);
            }
         }
         GXCCtl = "vACTIONGROUP_" + sGXsfl_50_idx;
         cmbavActiongroup.Name = GXCCtl;
         cmbavActiongroup.WebTags = "";
         if ( cmbavActiongroup.ItemCount > 0 )
         {
            if ( ( AV80GXV1 > 0 ) && ( AV22SDT_Residents.Count >= AV80GXV1 ) && (0==AV35ActionGroup) )
            {
               AV35ActionGroup = (short)(Math.Round(NumberUtil.Val( cmbavActiongroup.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV35ActionGroup), 4, 0))), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV35ActionGroup), 4, 0));
            }
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl50( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"50\">") ;
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
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavSdt_residents__residentgivenname_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "First Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavSdt_residents__residentlastname_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Last Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbavSdt_residents__residentgender.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Gender", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavSdt_residents__residentemail_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Email", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavSdt_residents__residentphone_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
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
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavAccountstatus_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Account Status", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
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
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__locationid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__organisationid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentbsnnumber_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavSdt_residents__residentsalutation.Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentgivenname_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavSdt_residents__residentgivenname_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentgivenname_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentlastname_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavSdt_residents__residentlastname_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentlastname_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentinitials_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavSdt_residents__residentgender.Visible), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavSdt_residents__residentgender.Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentbirthdate_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentemail_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentemail_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentphone_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentphone_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentguid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residenttypeid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residenttypename_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__medicalindicationid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__medicalindicationname_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentaddress_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV44AccountStatus));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavAccountstatus_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavAccountstatus_Columnheaderclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAccountstatus_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAccountstatus_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35ActionGroup), 4, 0, ".", ""))));
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
         Combo_residentpackageid_Internalname = "COMBO_RESIDENTPACKAGEID";
         divCombo_residentpackageid_cell_Internalname = "COMBO_RESIDENTPACKAGEID_CELL";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         lblTextblocklocationoption_Internalname = "TEXTBLOCKLOCATIONOPTION";
         dynavLocationoption_Internalname = "vLOCATIONOPTION";
         divUnnamedtablelocationoption_Internalname = "UNNAMEDTABLELOCATIONOPTION";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtavSdt_residents__residentid_Internalname = "SDT_RESIDENTS__RESIDENTID";
         edtavSdt_residents__locationid_Internalname = "SDT_RESIDENTS__LOCATIONID";
         edtavSdt_residents__organisationid_Internalname = "SDT_RESIDENTS__ORGANISATIONID";
         edtavSdt_residents__residentbsnnumber_Internalname = "SDT_RESIDENTS__RESIDENTBSNNUMBER";
         cmbavSdt_residents__residentsalutation_Internalname = "SDT_RESIDENTS__RESIDENTSALUTATION";
         edtavSdt_residents__residentgivenname_Internalname = "SDT_RESIDENTS__RESIDENTGIVENNAME";
         edtavSdt_residents__residentlastname_Internalname = "SDT_RESIDENTS__RESIDENTLASTNAME";
         edtavSdt_residents__residentinitials_Internalname = "SDT_RESIDENTS__RESIDENTINITIALS";
         cmbavSdt_residents__residentgender_Internalname = "SDT_RESIDENTS__RESIDENTGENDER";
         edtavSdt_residents__residentbirthdate_Internalname = "SDT_RESIDENTS__RESIDENTBIRTHDATE";
         edtavSdt_residents__residentemail_Internalname = "SDT_RESIDENTS__RESIDENTEMAIL";
         edtavSdt_residents__residentphone_Internalname = "SDT_RESIDENTS__RESIDENTPHONE";
         edtavSdt_residents__residentguid_Internalname = "SDT_RESIDENTS__RESIDENTGUID";
         edtavSdt_residents__residenttypeid_Internalname = "SDT_RESIDENTS__RESIDENTTYPEID";
         edtavSdt_residents__residenttypename_Internalname = "SDT_RESIDENTS__RESIDENTTYPENAME";
         edtavSdt_residents__medicalindicationid_Internalname = "SDT_RESIDENTS__MEDICALINDICATIONID";
         edtavSdt_residents__medicalindicationname_Internalname = "SDT_RESIDENTS__MEDICALINDICATIONNAME";
         edtavSdt_residents__residentaddress_Internalname = "SDT_RESIDENTS__RESIDENTADDRESS";
         edtavAccountstatus_Internalname = "vACCOUNTSTATUS";
         cmbavActiongroup_Internalname = "vACTIONGROUP";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         edtavResidentpackageid_Internalname = "vRESIDENTPACKAGEID";
         Ddo_grid_Internalname = "DDO_GRID";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Dvelop_confirmpanel_resendinvite_Internalname = "DVELOP_CONFIRMPANEL_RESENDINVITE";
         tblTabledvelop_confirmpanel_resendinvite_Internalname = "TABLEDVELOP_CONFIRMPANEL_RESENDINVITE";
         Dvelop_confirmpanel_useractionunblock_Internalname = "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK";
         tblTabledvelop_confirmpanel_useractionunblock_Internalname = "TABLEDVELOP_CONFIRMPANEL_USERACTIONUNBLOCK";
         Dvelop_confirmpanel_useractionblock_Internalname = "DVELOP_CONFIRMPANEL_USERACTIONBLOCK";
         tblTabledvelop_confirmpanel_useractionblock_Internalname = "TABLEDVELOP_CONFIRMPANEL_USERACTIONBLOCK";
         Dvelop_confirmpanel_udelete_Internalname = "DVELOP_CONFIRMPANEL_UDELETE";
         tblTabledvelop_confirmpanel_udelete_Internalname = "TABLEDVELOP_CONFIRMPANEL_UDELETE";
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
         subGrid_Allowhovering = -1;
         subGrid_Allowselection = 1;
         subGrid_Header = "";
         cmbavActiongroup_Jsonclick = "";
         edtavAccountstatus_Jsonclick = "";
         edtavAccountstatus_Columnclass = "WWColumn";
         edtavAccountstatus_Enabled = 1;
         edtavSdt_residents__residentaddress_Jsonclick = "";
         edtavSdt_residents__residentaddress_Enabled = 0;
         edtavSdt_residents__medicalindicationname_Jsonclick = "";
         edtavSdt_residents__medicalindicationname_Enabled = 0;
         edtavSdt_residents__medicalindicationid_Jsonclick = "";
         edtavSdt_residents__medicalindicationid_Enabled = 0;
         edtavSdt_residents__residenttypename_Jsonclick = "";
         edtavSdt_residents__residenttypename_Enabled = 0;
         edtavSdt_residents__residenttypeid_Jsonclick = "";
         edtavSdt_residents__residenttypeid_Enabled = 0;
         edtavSdt_residents__residentguid_Jsonclick = "";
         edtavSdt_residents__residentguid_Enabled = 0;
         edtavSdt_residents__residentphone_Jsonclick = "";
         edtavSdt_residents__residentphone_Enabled = 0;
         edtavSdt_residents__residentphone_Visible = -1;
         edtavSdt_residents__residentemail_Jsonclick = "";
         edtavSdt_residents__residentemail_Enabled = 0;
         edtavSdt_residents__residentemail_Visible = -1;
         edtavSdt_residents__residentbirthdate_Jsonclick = "";
         edtavSdt_residents__residentbirthdate_Enabled = 0;
         cmbavSdt_residents__residentgender_Jsonclick = "";
         cmbavSdt_residents__residentgender.Enabled = 0;
         cmbavSdt_residents__residentgender.Visible = -1;
         edtavSdt_residents__residentinitials_Jsonclick = "";
         edtavSdt_residents__residentinitials_Enabled = 0;
         edtavSdt_residents__residentlastname_Jsonclick = "";
         edtavSdt_residents__residentlastname_Link = "";
         edtavSdt_residents__residentlastname_Enabled = 0;
         edtavSdt_residents__residentlastname_Visible = -1;
         edtavSdt_residents__residentgivenname_Jsonclick = "";
         edtavSdt_residents__residentgivenname_Link = "";
         edtavSdt_residents__residentgivenname_Enabled = 0;
         edtavSdt_residents__residentgivenname_Visible = -1;
         cmbavSdt_residents__residentsalutation_Jsonclick = "";
         cmbavSdt_residents__residentsalutation.Enabled = 0;
         edtavSdt_residents__residentbsnnumber_Jsonclick = "";
         edtavSdt_residents__residentbsnnumber_Enabled = 0;
         edtavSdt_residents__organisationid_Jsonclick = "";
         edtavSdt_residents__organisationid_Enabled = 0;
         edtavSdt_residents__locationid_Jsonclick = "";
         edtavSdt_residents__locationid_Enabled = 0;
         edtavSdt_residents__residentid_Jsonclick = "";
         edtavSdt_residents__residentid_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar WorkWithSelection WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavAccountstatus_Columnheaderclass = "";
         edtavAccountstatus_Visible = -1;
         edtavSdt_residents__residentphone_Visible = -1;
         edtavSdt_residents__residentemail_Visible = -1;
         cmbavSdt_residents__residentgender.Visible = -1;
         edtavSdt_residents__residentlastname_Visible = -1;
         edtavSdt_residents__residentgivenname_Visible = -1;
         subGrid_Sortable = 0;
         edtavSdt_residents__residentaddress_Enabled = -1;
         edtavSdt_residents__medicalindicationname_Enabled = -1;
         edtavSdt_residents__medicalindicationid_Enabled = -1;
         edtavSdt_residents__residenttypename_Enabled = -1;
         edtavSdt_residents__residenttypeid_Enabled = -1;
         edtavSdt_residents__residentguid_Enabled = -1;
         edtavSdt_residents__residentphone_Enabled = -1;
         edtavSdt_residents__residentemail_Enabled = -1;
         edtavSdt_residents__residentbirthdate_Enabled = -1;
         cmbavSdt_residents__residentgender.Enabled = -1;
         edtavSdt_residents__residentinitials_Enabled = -1;
         edtavSdt_residents__residentlastname_Enabled = -1;
         edtavSdt_residents__residentgivenname_Enabled = -1;
         cmbavSdt_residents__residentsalutation.Enabled = -1;
         edtavSdt_residents__residentbsnnumber_Enabled = -1;
         edtavSdt_residents__organisationid_Enabled = -1;
         edtavSdt_residents__locationid_Enabled = -1;
         edtavSdt_residents__residentid_Enabled = -1;
         edtavResidentpackageid_Jsonclick = "";
         edtavResidentpackageid_Visible = 1;
         dynavLocationoption_Jsonclick = "";
         dynavLocationoption.Visible = 1;
         dynavLocationoption.Enabled = 1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         divCombo_residentpackageid_cell_Class = "col-xs-12";
         divUnnamedtable1_Visible = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Dvelop_confirmpanel_udelete_Confirmtype = "1";
         Dvelop_confirmpanel_udelete_Yesbuttonposition = "left";
         Dvelop_confirmpanel_udelete_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_udelete_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_udelete_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_udelete_Confirmationtext = "The following data associated with the resident will be deleted: Memos";
         Dvelop_confirmpanel_udelete_Title = context.GetMessage( "Confirm delete action", "");
         Dvelop_confirmpanel_useractionblock_Confirmtype = "1";
         Dvelop_confirmpanel_useractionblock_Yesbuttonposition = "left";
         Dvelop_confirmpanel_useractionblock_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_useractionblock_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_useractionblock_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_useractionblock_Confirmationtext = "Are you sure you want to block resident?";
         Dvelop_confirmpanel_useractionblock_Title = context.GetMessage( "Block Resident", "");
         Dvelop_confirmpanel_useractionunblock_Confirmtype = "1";
         Dvelop_confirmpanel_useractionunblock_Yesbuttonposition = "left";
         Dvelop_confirmpanel_useractionunblock_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_useractionunblock_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_useractionunblock_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_useractionunblock_Confirmationtext = "Are you sure you want to unblock Resident?";
         Dvelop_confirmpanel_useractionunblock_Title = context.GetMessage( "Unblock user", "");
         Dvelop_confirmpanel_resendinvite_Confirmtype = "1";
         Dvelop_confirmpanel_resendinvite_Yesbuttonposition = "left";
         Dvelop_confirmpanel_resendinvite_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_resendinvite_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_resendinvite_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_resendinvite_Confirmationtext = "Are you sure you want to re-send an invititation to this resident?";
         Dvelop_confirmpanel_resendinvite_Title = context.GetMessage( "Re - Send Invitation", "");
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = context.GetMessage( "WWP_EditColumnsCaption", "");
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4";
         Ddo_grid_Columnids = "5:SDT_Residents__ResidentGivenName|6:SDT_Residents__ResidentLastName|10:SDT_Residents__ResidentEmail|18:AccountStatus";
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
         Combo_residentpackageid_Emptyitemtext = "Select Access";
         Combo_residentpackageid_Visible = Convert.ToBoolean( -1);
         Combo_residentpackageid_Cls = "ExtendedCombo btn-default";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Location Residents", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV38ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV99Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV54OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV55OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV7FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":50},{"av":"nGXsfl_50_idx","ctrl":"GRID","prop":"GridCurrRow","grid":50},{"av":"nRC_GXsfl_50","ctrl":"GRID","prop":"GridRC","grid":50},{"av":"AV69ResidentPackageId","fld":"vRESIDENTPACKAGEID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV29WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV101Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"dynavLocationoption"},{"av":"AV16LocationOption","fld":"vLOCATIONOPTION"},{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"A72ResidentSalutation","fld":"RESIDENTSALUTATION"},{"av":"A63ResidentBsnNumber","fld":"RESIDENTBSNNUMBER"},{"av":"A64ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A65ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"},{"av":"A67ResidentEmail","fld":"RESIDENTEMAIL"},{"av":"A68ResidentGender","fld":"RESIDENTGENDER"},{"av":"A312ResidentCountry","fld":"RESIDENTCOUNTRY"},{"av":"A313ResidentCity","fld":"RESIDENTCITY"},{"av":"A314ResidentZipCode","fld":"RESIDENTZIPCODE"},{"av":"A315ResidentAddressLine1","fld":"RESIDENTADDRESSLINE1"},{"av":"A316ResidentAddressLine2","fld":"RESIDENTADDRESSLINE2"},{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"},{"av":"A73ResidentBirthDate","fld":"RESIDENTBIRTHDATE"},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A71ResidentGUID","fld":"RESIDENTGUID"},{"av":"A527ResidentPackageId","fld":"RESIDENTPACKAGEID"},{"av":"AV33IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV41IsAuthorized_SDT_Residents","fld":"vISAUTHORIZED_SDT_RESIDENTS","hsh":true},{"av":"AV78ResidentTitle","fld":"vRESIDENTTITLE","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV29WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV38ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"ctrl":"SDT_RESIDENTS__RESIDENTGIVENNAME","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTLASTNAME","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTGENDER","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTEMAIL","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTPHONE","prop":"Visible"},{"av":"edtavAccountstatus_Visible","ctrl":"vACCOUNTSTATUS","prop":"Visible"},{"av":"AV10GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV11GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV9GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavAccountstatus_Columnheaderclass","ctrl":"vACCOUNTSTATUS","prop":"Columnheaderclass"},{"av":"AV33IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV12GridState","fld":"vGRIDSTATE"},{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":50},{"av":"nGXsfl_50_idx","ctrl":"GRID","prop":"GridCurrRow","grid":50},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_50","ctrl":"GRID","prop":"GridRC","grid":50}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E135J2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV38ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV99Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV54OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV55OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV7FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":50},{"av":"nGXsfl_50_idx","ctrl":"GRID","prop":"GridCurrRow","grid":50},{"av":"nRC_GXsfl_50","ctrl":"GRID","prop":"GridRC","grid":50},{"av":"AV69ResidentPackageId","fld":"vRESIDENTPACKAGEID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV29WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV101Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"dynavLocationoption"},{"av":"AV16LocationOption","fld":"vLOCATIONOPTION"},{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"A72ResidentSalutation","fld":"RESIDENTSALUTATION"},{"av":"A63ResidentBsnNumber","fld":"RESIDENTBSNNUMBER"},{"av":"A64ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A65ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"},{"av":"A67ResidentEmail","fld":"RESIDENTEMAIL"},{"av":"A68ResidentGender","fld":"RESIDENTGENDER"},{"av":"A312ResidentCountry","fld":"RESIDENTCOUNTRY"},{"av":"A313ResidentCity","fld":"RESIDENTCITY"},{"av":"A314ResidentZipCode","fld":"RESIDENTZIPCODE"},{"av":"A315ResidentAddressLine1","fld":"RESIDENTADDRESSLINE1"},{"av":"A316ResidentAddressLine2","fld":"RESIDENTADDRESSLINE2"},{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"},{"av":"A73ResidentBirthDate","fld":"RESIDENTBIRTHDATE"},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A71ResidentGUID","fld":"RESIDENTGUID"},{"av":"A527ResidentPackageId","fld":"RESIDENTPACKAGEID"},{"av":"AV33IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV41IsAuthorized_SDT_Residents","fld":"vISAUTHORIZED_SDT_RESIDENTS","hsh":true},{"av":"AV78ResidentTitle","fld":"vRESIDENTTITLE","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E145J2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV38ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV99Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV54OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV55OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV7FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":50},{"av":"nGXsfl_50_idx","ctrl":"GRID","prop":"GridCurrRow","grid":50},{"av":"nRC_GXsfl_50","ctrl":"GRID","prop":"GridRC","grid":50},{"av":"AV69ResidentPackageId","fld":"vRESIDENTPACKAGEID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV29WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV101Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"dynavLocationoption"},{"av":"AV16LocationOption","fld":"vLOCATIONOPTION"},{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"A72ResidentSalutation","fld":"RESIDENTSALUTATION"},{"av":"A63ResidentBsnNumber","fld":"RESIDENTBSNNUMBER"},{"av":"A64ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A65ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"},{"av":"A67ResidentEmail","fld":"RESIDENTEMAIL"},{"av":"A68ResidentGender","fld":"RESIDENTGENDER"},{"av":"A312ResidentCountry","fld":"RESIDENTCOUNTRY"},{"av":"A313ResidentCity","fld":"RESIDENTCITY"},{"av":"A314ResidentZipCode","fld":"RESIDENTZIPCODE"},{"av":"A315ResidentAddressLine1","fld":"RESIDENTADDRESSLINE1"},{"av":"A316ResidentAddressLine2","fld":"RESIDENTADDRESSLINE2"},{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"},{"av":"A73ResidentBirthDate","fld":"RESIDENTBIRTHDATE"},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A71ResidentGUID","fld":"RESIDENTGUID"},{"av":"A527ResidentPackageId","fld":"RESIDENTPACKAGEID"},{"av":"AV33IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV41IsAuthorized_SDT_Residents","fld":"vISAUTHORIZED_SDT_RESIDENTS","hsh":true},{"av":"AV78ResidentTitle","fld":"vRESIDENTTITLE","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E155J2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV38ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV99Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV54OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV55OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV7FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":50},{"av":"nGXsfl_50_idx","ctrl":"GRID","prop":"GridCurrRow","grid":50},{"av":"nRC_GXsfl_50","ctrl":"GRID","prop":"GridRC","grid":50},{"av":"AV69ResidentPackageId","fld":"vRESIDENTPACKAGEID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV29WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV101Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"dynavLocationoption"},{"av":"AV16LocationOption","fld":"vLOCATIONOPTION"},{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"A72ResidentSalutation","fld":"RESIDENTSALUTATION"},{"av":"A63ResidentBsnNumber","fld":"RESIDENTBSNNUMBER"},{"av":"A64ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A65ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"},{"av":"A67ResidentEmail","fld":"RESIDENTEMAIL"},{"av":"A68ResidentGender","fld":"RESIDENTGENDER"},{"av":"A312ResidentCountry","fld":"RESIDENTCOUNTRY"},{"av":"A313ResidentCity","fld":"RESIDENTCITY"},{"av":"A314ResidentZipCode","fld":"RESIDENTZIPCODE"},{"av":"A315ResidentAddressLine1","fld":"RESIDENTADDRESSLINE1"},{"av":"A316ResidentAddressLine2","fld":"RESIDENTADDRESSLINE2"},{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"},{"av":"A73ResidentBirthDate","fld":"RESIDENTBIRTHDATE"},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A71ResidentGUID","fld":"RESIDENTGUID"},{"av":"A527ResidentPackageId","fld":"RESIDENTPACKAGEID"},{"av":"AV33IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV41IsAuthorized_SDT_Residents","fld":"vISAUTHORIZED_SDT_RESIDENTS","hsh":true},{"av":"AV78ResidentTitle","fld":"vRESIDENTTITLE","hsh":true},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV54OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV55OrderedDsc","fld":"vORDEREDDSC"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E265J2","iparms":[{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":50},{"av":"nGXsfl_50_idx","ctrl":"GRID","prop":"GridCurrRow","grid":50},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_50","ctrl":"GRID","prop":"GridRC","grid":50},{"av":"AV33IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV41IsAuthorized_SDT_Residents","fld":"vISAUTHORIZED_SDT_RESIDENTS","hsh":true}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV44AccountStatus","fld":"vACCOUNTSTATUS"},{"av":"cmbavActiongroup"},{"av":"AV35ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"ctrl":"SDT_RESIDENTS__RESIDENTGIVENNAME","prop":"Link"},{"ctrl":"SDT_RESIDENTS__RESIDENTLASTNAME","prop":"Link"},{"av":"edtavAccountstatus_Columnclass","ctrl":"vACCOUNTSTATUS","prop":"Columnclass"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E165J2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV38ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV99Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV54OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV55OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV7FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":50},{"av":"nGXsfl_50_idx","ctrl":"GRID","prop":"GridCurrRow","grid":50},{"av":"nRC_GXsfl_50","ctrl":"GRID","prop":"GridRC","grid":50},{"av":"AV69ResidentPackageId","fld":"vRESIDENTPACKAGEID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV29WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV101Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"dynavLocationoption"},{"av":"AV16LocationOption","fld":"vLOCATIONOPTION"},{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"A72ResidentSalutation","fld":"RESIDENTSALUTATION"},{"av":"A63ResidentBsnNumber","fld":"RESIDENTBSNNUMBER"},{"av":"A64ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A65ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"},{"av":"A67ResidentEmail","fld":"RESIDENTEMAIL"},{"av":"A68ResidentGender","fld":"RESIDENTGENDER"},{"av":"A312ResidentCountry","fld":"RESIDENTCOUNTRY"},{"av":"A313ResidentCity","fld":"RESIDENTCITY"},{"av":"A314ResidentZipCode","fld":"RESIDENTZIPCODE"},{"av":"A315ResidentAddressLine1","fld":"RESIDENTADDRESSLINE1"},{"av":"A316ResidentAddressLine2","fld":"RESIDENTADDRESSLINE2"},{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"},{"av":"A73ResidentBirthDate","fld":"RESIDENTBIRTHDATE"},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A71ResidentGUID","fld":"RESIDENTGUID"},{"av":"A527ResidentPackageId","fld":"RESIDENTPACKAGEID"},{"av":"AV33IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV41IsAuthorized_SDT_Residents","fld":"vISAUTHORIZED_SDT_RESIDENTS","hsh":true},{"av":"AV78ResidentTitle","fld":"vRESIDENTTITLE","hsh":true},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV38ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV29WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"ctrl":"SDT_RESIDENTS__RESIDENTGIVENNAME","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTLASTNAME","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTGENDER","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTEMAIL","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTPHONE","prop":"Visible"},{"av":"edtavAccountstatus_Visible","ctrl":"vACCOUNTSTATUS","prop":"Visible"},{"av":"AV10GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV11GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV9GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavAccountstatus_Columnheaderclass","ctrl":"vACCOUNTSTATUS","prop":"Columnheaderclass"},{"av":"AV33IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV12GridState","fld":"vGRIDSTATE"},{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":50},{"av":"nGXsfl_50_idx","ctrl":"GRID","prop":"GridCurrRow","grid":50},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_50","ctrl":"GRID","prop":"GridRC","grid":50}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E125J2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV38ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV99Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV54OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV55OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV7FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":50},{"av":"nGXsfl_50_idx","ctrl":"GRID","prop":"GridCurrRow","grid":50},{"av":"nRC_GXsfl_50","ctrl":"GRID","prop":"GridRC","grid":50},{"av":"AV69ResidentPackageId","fld":"vRESIDENTPACKAGEID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV29WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV101Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"dynavLocationoption"},{"av":"AV16LocationOption","fld":"vLOCATIONOPTION"},{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"A72ResidentSalutation","fld":"RESIDENTSALUTATION"},{"av":"A63ResidentBsnNumber","fld":"RESIDENTBSNNUMBER"},{"av":"A64ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A65ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"},{"av":"A67ResidentEmail","fld":"RESIDENTEMAIL"},{"av":"A68ResidentGender","fld":"RESIDENTGENDER"},{"av":"A312ResidentCountry","fld":"RESIDENTCOUNTRY"},{"av":"A313ResidentCity","fld":"RESIDENTCITY"},{"av":"A314ResidentZipCode","fld":"RESIDENTZIPCODE"},{"av":"A315ResidentAddressLine1","fld":"RESIDENTADDRESSLINE1"},{"av":"A316ResidentAddressLine2","fld":"RESIDENTADDRESSLINE2"},{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"},{"av":"A73ResidentBirthDate","fld":"RESIDENTBIRTHDATE"},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A71ResidentGUID","fld":"RESIDENTGUID"},{"av":"A527ResidentPackageId","fld":"RESIDENTPACKAGEID"},{"av":"AV33IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV41IsAuthorized_SDT_Residents","fld":"vISAUTHORIZED_SDT_RESIDENTS","hsh":true},{"av":"AV78ResidentTitle","fld":"vRESIDENTTITLE","hsh":true},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV12GridState","fld":"vGRIDSTATE"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV12GridState","fld":"vGRIDSTATE"},{"av":"AV54OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV55OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV7FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV29WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV38ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"ctrl":"SDT_RESIDENTS__RESIDENTGIVENNAME","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTLASTNAME","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTGENDER","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTEMAIL","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTPHONE","prop":"Visible"},{"av":"edtavAccountstatus_Visible","ctrl":"vACCOUNTSTATUS","prop":"Visible"},{"av":"AV10GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV11GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV9GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavAccountstatus_Columnheaderclass","ctrl":"vACCOUNTSTATUS","prop":"Columnheaderclass"},{"av":"AV33IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":50},{"av":"nGXsfl_50_idx","ctrl":"GRID","prop":"GridCurrRow","grid":50},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_50","ctrl":"GRID","prop":"GridRC","grid":50}]}""");
         setEventMetadata("VACTIONGROUP.CLICK","""{"handler":"E275J2","iparms":[{"av":"cmbavActiongroup"},{"av":"AV35ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":50},{"av":"nGXsfl_50_idx","ctrl":"GRID","prop":"GridCurrRow","grid":50},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_50","ctrl":"GRID","prop":"GridRC","grid":50}]""");
         setEventMetadata("VACTIONGROUP.CLICK",""","oparms":[{"av":"cmbavActiongroup"},{"av":"AV35ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"Dvelop_confirmpanel_udelete_Title","ctrl":"DVELOP_CONFIRMPANEL_UDELETE","prop":"Title"},{"av":"Dvelop_confirmpanel_udelete_Confirmationtext","ctrl":"DVELOP_CONFIRMPANEL_UDELETE","prop":"ConfirmationText"},{"av":"AV75Selected_ResidentId","fld":"vSELECTED_RESIDENTID"},{"av":"AV76Selected_LocationId","fld":"vSELECTED_LOCATIONID"},{"av":"AV77Selected_OrganisationId","fld":"vSELECTED_ORGANISATIONID"}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_RESENDINVITE.CLOSE","""{"handler":"E175J2","iparms":[{"av":"Dvelop_confirmpanel_resendinvite_Result","ctrl":"DVELOP_CONFIRMPANEL_RESENDINVITE","prop":"Result"},{"av":"AV14HTTPRequest.BaseURL","ctrl":"vHTTPREQUEST","prop":"Baseurl"},{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":50},{"av":"nGXsfl_50_idx","ctrl":"GRID","prop":"GridCurrRow","grid":50},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_50","ctrl":"GRID","prop":"GridRC","grid":50},{"av":"AV65isSent","fld":"vISSENT"},{"av":"AV67ErrDescroption","fld":"vERRDESCROPTION"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_RESENDINVITE.CLOSE",""","oparms":[{"av":"AV67ErrDescroption","fld":"vERRDESCROPTION"},{"av":"AV65isSent","fld":"vISSENT"}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK.CLOSE","""{"handler":"E185J2","iparms":[{"av":"Dvelop_confirmpanel_useractionunblock_Result","ctrl":"DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK","prop":"Result"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV38ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV99Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV54OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV55OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV7FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":50},{"av":"nGXsfl_50_idx","ctrl":"GRID","prop":"GridCurrRow","grid":50},{"av":"nRC_GXsfl_50","ctrl":"GRID","prop":"GridRC","grid":50},{"av":"AV69ResidentPackageId","fld":"vRESIDENTPACKAGEID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV29WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV101Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"dynavLocationoption"},{"av":"AV16LocationOption","fld":"vLOCATIONOPTION"},{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"A72ResidentSalutation","fld":"RESIDENTSALUTATION"},{"av":"A63ResidentBsnNumber","fld":"RESIDENTBSNNUMBER"},{"av":"A64ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A65ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"},{"av":"A67ResidentEmail","fld":"RESIDENTEMAIL"},{"av":"A68ResidentGender","fld":"RESIDENTGENDER"},{"av":"A312ResidentCountry","fld":"RESIDENTCOUNTRY"},{"av":"A313ResidentCity","fld":"RESIDENTCITY"},{"av":"A314ResidentZipCode","fld":"RESIDENTZIPCODE"},{"av":"A315ResidentAddressLine1","fld":"RESIDENTADDRESSLINE1"},{"av":"A316ResidentAddressLine2","fld":"RESIDENTADDRESSLINE2"},{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"},{"av":"A73ResidentBirthDate","fld":"RESIDENTBIRTHDATE"},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A71ResidentGUID","fld":"RESIDENTGUID"},{"av":"A527ResidentPackageId","fld":"RESIDENTPACKAGEID"},{"av":"AV33IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV41IsAuthorized_SDT_Residents","fld":"vISAUTHORIZED_SDT_RESIDENTS","hsh":true},{"av":"AV78ResidentTitle","fld":"vRESIDENTTITLE","hsh":true}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK.CLOSE",""","oparms":[{"av":"AV29WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV38ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"ctrl":"SDT_RESIDENTS__RESIDENTGIVENNAME","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTLASTNAME","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTGENDER","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTEMAIL","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTPHONE","prop":"Visible"},{"av":"edtavAccountstatus_Visible","ctrl":"vACCOUNTSTATUS","prop":"Visible"},{"av":"AV10GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV11GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV9GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavAccountstatus_Columnheaderclass","ctrl":"vACCOUNTSTATUS","prop":"Columnheaderclass"},{"av":"AV33IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV12GridState","fld":"vGRIDSTATE"},{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":50},{"av":"nGXsfl_50_idx","ctrl":"GRID","prop":"GridCurrRow","grid":50},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_50","ctrl":"GRID","prop":"GridRC","grid":50}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTIONBLOCK.CLOSE","""{"handler":"E195J2","iparms":[{"av":"Dvelop_confirmpanel_useractionblock_Result","ctrl":"DVELOP_CONFIRMPANEL_USERACTIONBLOCK","prop":"Result"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV38ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV99Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV54OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV55OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV7FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":50},{"av":"nGXsfl_50_idx","ctrl":"GRID","prop":"GridCurrRow","grid":50},{"av":"nRC_GXsfl_50","ctrl":"GRID","prop":"GridRC","grid":50},{"av":"AV69ResidentPackageId","fld":"vRESIDENTPACKAGEID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV29WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV101Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"dynavLocationoption"},{"av":"AV16LocationOption","fld":"vLOCATIONOPTION"},{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"A72ResidentSalutation","fld":"RESIDENTSALUTATION"},{"av":"A63ResidentBsnNumber","fld":"RESIDENTBSNNUMBER"},{"av":"A64ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A65ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"},{"av":"A67ResidentEmail","fld":"RESIDENTEMAIL"},{"av":"A68ResidentGender","fld":"RESIDENTGENDER"},{"av":"A312ResidentCountry","fld":"RESIDENTCOUNTRY"},{"av":"A313ResidentCity","fld":"RESIDENTCITY"},{"av":"A314ResidentZipCode","fld":"RESIDENTZIPCODE"},{"av":"A315ResidentAddressLine1","fld":"RESIDENTADDRESSLINE1"},{"av":"A316ResidentAddressLine2","fld":"RESIDENTADDRESSLINE2"},{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"},{"av":"A73ResidentBirthDate","fld":"RESIDENTBIRTHDATE"},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A71ResidentGUID","fld":"RESIDENTGUID"},{"av":"A527ResidentPackageId","fld":"RESIDENTPACKAGEID"},{"av":"AV33IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV41IsAuthorized_SDT_Residents","fld":"vISAUTHORIZED_SDT_RESIDENTS","hsh":true},{"av":"AV78ResidentTitle","fld":"vRESIDENTTITLE","hsh":true}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTIONBLOCK.CLOSE",""","oparms":[{"av":"AV29WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV38ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"ctrl":"SDT_RESIDENTS__RESIDENTGIVENNAME","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTLASTNAME","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTGENDER","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTEMAIL","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTPHONE","prop":"Visible"},{"av":"edtavAccountstatus_Visible","ctrl":"vACCOUNTSTATUS","prop":"Visible"},{"av":"AV10GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV11GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV9GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavAccountstatus_Columnheaderclass","ctrl":"vACCOUNTSTATUS","prop":"Columnheaderclass"},{"av":"AV33IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV12GridState","fld":"vGRIDSTATE"},{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":50},{"av":"nGXsfl_50_idx","ctrl":"GRID","prop":"GridCurrRow","grid":50},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_50","ctrl":"GRID","prop":"GridRC","grid":50}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_UDELETE.CLOSE","""{"handler":"E205J2","iparms":[{"av":"Dvelop_confirmpanel_udelete_Result","ctrl":"DVELOP_CONFIRMPANEL_UDELETE","prop":"Result"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV38ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV99Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV54OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV55OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV7FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":50},{"av":"nGXsfl_50_idx","ctrl":"GRID","prop":"GridCurrRow","grid":50},{"av":"nRC_GXsfl_50","ctrl":"GRID","prop":"GridRC","grid":50},{"av":"AV69ResidentPackageId","fld":"vRESIDENTPACKAGEID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV29WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV101Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"dynavLocationoption"},{"av":"AV16LocationOption","fld":"vLOCATIONOPTION"},{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"A72ResidentSalutation","fld":"RESIDENTSALUTATION"},{"av":"A63ResidentBsnNumber","fld":"RESIDENTBSNNUMBER"},{"av":"A64ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A65ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"},{"av":"A67ResidentEmail","fld":"RESIDENTEMAIL"},{"av":"A68ResidentGender","fld":"RESIDENTGENDER"},{"av":"A312ResidentCountry","fld":"RESIDENTCOUNTRY"},{"av":"A313ResidentCity","fld":"RESIDENTCITY"},{"av":"A314ResidentZipCode","fld":"RESIDENTZIPCODE"},{"av":"A315ResidentAddressLine1","fld":"RESIDENTADDRESSLINE1"},{"av":"A316ResidentAddressLine2","fld":"RESIDENTADDRESSLINE2"},{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"},{"av":"A73ResidentBirthDate","fld":"RESIDENTBIRTHDATE"},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A71ResidentGUID","fld":"RESIDENTGUID"},{"av":"A527ResidentPackageId","fld":"RESIDENTPACKAGEID"},{"av":"AV33IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV41IsAuthorized_SDT_Residents","fld":"vISAUTHORIZED_SDT_RESIDENTS","hsh":true},{"av":"AV78ResidentTitle","fld":"vRESIDENTTITLE","hsh":true},{"av":"AV75Selected_ResidentId","fld":"vSELECTED_RESIDENTID"},{"av":"AV76Selected_LocationId","fld":"vSELECTED_LOCATIONID"},{"av":"AV77Selected_OrganisationId","fld":"vSELECTED_ORGANISATIONID"},{"av":"AV34isSuccessful","fld":"vISSUCCESSFUL"},{"av":"AV72Message","fld":"vMESSAGE"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_UDELETE.CLOSE",""","oparms":[{"av":"AV72Message","fld":"vMESSAGE"},{"av":"AV34isSuccessful","fld":"vISSUCCESSFUL"},{"av":"AV29WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV38ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"ctrl":"SDT_RESIDENTS__RESIDENTGIVENNAME","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTLASTNAME","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTGENDER","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTEMAIL","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTPHONE","prop":"Visible"},{"av":"edtavAccountstatus_Visible","ctrl":"vACCOUNTSTATUS","prop":"Visible"},{"av":"AV10GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV11GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV9GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavAccountstatus_Columnheaderclass","ctrl":"vACCOUNTSTATUS","prop":"Columnheaderclass"},{"av":"AV33IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV12GridState","fld":"vGRIDSTATE"},{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":50},{"av":"nGXsfl_50_idx","ctrl":"GRID","prop":"GridCurrRow","grid":50},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_50","ctrl":"GRID","prop":"GridRC","grid":50}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E215J2","iparms":[{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"AV29WWPContext","fld":"vWWPCONTEXT","hsh":true}]}""");
         setEventMetadata("COMBO_RESIDENTPACKAGEID.ONOPTIONCLICKED","""{"handler":"E115J2","iparms":[{"av":"Combo_residentpackageid_Selectedvalue_get","ctrl":"COMBO_RESIDENTPACKAGEID","prop":"SelectedValue_get"},{"av":"AV54OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV55OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":50},{"av":"nGXsfl_50_idx","ctrl":"GRID","prop":"GridCurrRow","grid":50},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_50","ctrl":"GRID","prop":"GridRC","grid":50},{"av":"AV69ResidentPackageId","fld":"vRESIDENTPACKAGEID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV29WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV101Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"dynavLocationoption"},{"av":"AV16LocationOption","fld":"vLOCATIONOPTION"},{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"A72ResidentSalutation","fld":"RESIDENTSALUTATION"},{"av":"A63ResidentBsnNumber","fld":"RESIDENTBSNNUMBER"},{"av":"A64ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A65ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"},{"av":"A67ResidentEmail","fld":"RESIDENTEMAIL"},{"av":"A68ResidentGender","fld":"RESIDENTGENDER"},{"av":"A312ResidentCountry","fld":"RESIDENTCOUNTRY"},{"av":"A313ResidentCity","fld":"RESIDENTCITY"},{"av":"A314ResidentZipCode","fld":"RESIDENTZIPCODE"},{"av":"A315ResidentAddressLine1","fld":"RESIDENTADDRESSLINE1"},{"av":"A316ResidentAddressLine2","fld":"RESIDENTADDRESSLINE2"},{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"},{"av":"A73ResidentBirthDate","fld":"RESIDENTBIRTHDATE"},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A71ResidentGUID","fld":"RESIDENTGUID"},{"av":"A527ResidentPackageId","fld":"RESIDENTPACKAGEID"},{"av":"GRID_nEOF"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV38ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV99Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV7FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV33IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV41IsAuthorized_SDT_Residents","fld":"vISAUTHORIZED_SDT_RESIDENTS","hsh":true},{"av":"AV78ResidentTitle","fld":"vRESIDENTTITLE","hsh":true}]""");
         setEventMetadata("COMBO_RESIDENTPACKAGEID.ONOPTIONCLICKED",""","oparms":[{"av":"AV69ResidentPackageId","fld":"vRESIDENTPACKAGEID"},{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":50},{"av":"nGXsfl_50_idx","ctrl":"GRID","prop":"GridCurrRow","grid":50},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_50","ctrl":"GRID","prop":"GridRC","grid":50}]}""");
         setEventMetadata("VLOCATIONOPTION.CONTROLVALUECHANGED","""{"handler":"E225J2","iparms":[{"av":"AV29WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV54OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV55OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":50},{"av":"nGXsfl_50_idx","ctrl":"GRID","prop":"GridCurrRow","grid":50},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_50","ctrl":"GRID","prop":"GridRC","grid":50},{"av":"AV69ResidentPackageId","fld":"vRESIDENTPACKAGEID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV101Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"dynavLocationoption"},{"av":"AV16LocationOption","fld":"vLOCATIONOPTION"},{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"A72ResidentSalutation","fld":"RESIDENTSALUTATION"},{"av":"A63ResidentBsnNumber","fld":"RESIDENTBSNNUMBER"},{"av":"A64ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A65ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"},{"av":"A67ResidentEmail","fld":"RESIDENTEMAIL"},{"av":"A68ResidentGender","fld":"RESIDENTGENDER"},{"av":"A312ResidentCountry","fld":"RESIDENTCOUNTRY"},{"av":"A313ResidentCity","fld":"RESIDENTCITY"},{"av":"A314ResidentZipCode","fld":"RESIDENTZIPCODE"},{"av":"A315ResidentAddressLine1","fld":"RESIDENTADDRESSLINE1"},{"av":"A316ResidentAddressLine2","fld":"RESIDENTADDRESSLINE2"},{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"},{"av":"A73ResidentBirthDate","fld":"RESIDENTBIRTHDATE"},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A71ResidentGUID","fld":"RESIDENTGUID"},{"av":"A527ResidentPackageId","fld":"RESIDENTPACKAGEID"},{"av":"GRID_nEOF"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV38ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV99Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV7FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV33IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV41IsAuthorized_SDT_Residents","fld":"vISAUTHORIZED_SDT_RESIDENTS","hsh":true},{"av":"AV78ResidentTitle","fld":"vRESIDENTTITLE","hsh":true}]""");
         setEventMetadata("VLOCATIONOPTION.CONTROLVALUECHANGED",""","oparms":[{"av":"dynavLocationoption"},{"av":"AV16LocationOption","fld":"vLOCATIONOPTION"},{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":50},{"av":"nGXsfl_50_idx","ctrl":"GRID","prop":"GridCurrRow","grid":50},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_50","ctrl":"GRID","prop":"GridRC","grid":50}]}""");
         setEventMetadata("VFILTERFULLTEXT.CONTROLVALUECHANGED","""{"handler":"E235J2","iparms":[{"av":"AV69ResidentPackageId","fld":"vRESIDENTPACKAGEID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV29WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV101Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"dynavLocationoption"},{"av":"AV16LocationOption","fld":"vLOCATIONOPTION"},{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"A72ResidentSalutation","fld":"RESIDENTSALUTATION"},{"av":"A63ResidentBsnNumber","fld":"RESIDENTBSNNUMBER"},{"av":"A64ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A65ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"},{"av":"A67ResidentEmail","fld":"RESIDENTEMAIL"},{"av":"A68ResidentGender","fld":"RESIDENTGENDER"},{"av":"A312ResidentCountry","fld":"RESIDENTCOUNTRY"},{"av":"A313ResidentCity","fld":"RESIDENTCITY"},{"av":"A314ResidentZipCode","fld":"RESIDENTZIPCODE"},{"av":"A315ResidentAddressLine1","fld":"RESIDENTADDRESSLINE1"},{"av":"A316ResidentAddressLine2","fld":"RESIDENTADDRESSLINE2"},{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"},{"av":"A73ResidentBirthDate","fld":"RESIDENTBIRTHDATE"},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A71ResidentGUID","fld":"RESIDENTGUID"},{"av":"A527ResidentPackageId","fld":"RESIDENTPACKAGEID"},{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":50},{"av":"nGXsfl_50_idx","ctrl":"GRID","prop":"GridCurrRow","grid":50},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_50","ctrl":"GRID","prop":"GridRC","grid":50},{"av":"GRID_nEOF"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV38ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV99Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV54OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV55OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV7FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV33IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV41IsAuthorized_SDT_Residents","fld":"vISAUTHORIZED_SDT_RESIDENTS","hsh":true},{"av":"AV78ResidentTitle","fld":"vRESIDENTTITLE","hsh":true}]""");
         setEventMetadata("VFILTERFULLTEXT.CONTROLVALUECHANGED",""","oparms":[{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":50},{"av":"nGXsfl_50_idx","ctrl":"GRID","prop":"GridCurrRow","grid":50},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_50","ctrl":"GRID","prop":"GridRC","grid":50}]}""");
         setEventMetadata("VALIDV_LOCATIONOPTION","""{"handler":"Validv_Locationoption","iparms":[]}""");
         setEventMetadata("VALIDV_RESIDENTPACKAGEID","""{"handler":"Validv_Residentpackageid","iparms":[]}""");
         setEventMetadata("VALIDV_GXV2","""{"handler":"Validv_Gxv2","iparms":[]}""");
         setEventMetadata("VALIDV_GXV3","""{"handler":"Validv_Gxv3","iparms":[]}""");
         setEventMetadata("VALIDV_GXV4","""{"handler":"Validv_Gxv4","iparms":[]}""");
         setEventMetadata("VALIDV_GXV6","""{"handler":"Validv_Gxv6","iparms":[]}""");
         setEventMetadata("VALIDV_GXV10","""{"handler":"Validv_Gxv10","iparms":[]}""");
         setEventMetadata("VALIDV_GXV12","""{"handler":"Validv_Gxv12","iparms":[]}""");
         setEventMetadata("VALIDV_GXV15","""{"handler":"Validv_Gxv15","iparms":[]}""");
         setEventMetadata("VALIDV_GXV17","""{"handler":"Validv_Gxv17","iparms":[]}""");
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
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Dvelop_confirmpanel_resendinvite_Result = "";
         AV14HTTPRequest = new GxHttpRequest( context);
         Dvelop_confirmpanel_useractionunblock_Result = "";
         Dvelop_confirmpanel_useractionblock_Result = "";
         Dvelop_confirmpanel_udelete_Result = "";
         Combo_residentpackageid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV29WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV38ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV99Pgmname = "";
         AV7FilterFullText = "";
         AV22SDT_Residents = new GXBaseCollection<SdtSDT_Resident>( context, "SDT_Resident", "Comforta_version2");
         AV69ResidentPackageId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV101Udparg1 = Guid.Empty;
         A29LocationId = Guid.Empty;
         AV16LocationOption = Guid.Empty;
         A62ResidentId = Guid.Empty;
         A72ResidentSalutation = "";
         A63ResidentBsnNumber = "";
         A64ResidentGivenName = "";
         A65ResidentLastName = "";
         A66ResidentInitials = "";
         A67ResidentEmail = "";
         A68ResidentGender = "";
         A312ResidentCountry = "";
         A313ResidentCity = "";
         A314ResidentZipCode = "";
         A315ResidentAddressLine1 = "";
         A316ResidentAddressLine2 = "";
         A70ResidentPhone = "";
         A97ResidentTypeName = "";
         A98MedicalIndicationId = Guid.Empty;
         A99MedicalIndicationName = "";
         A73ResidentBirthDate = DateTime.MinValue;
         A96ResidentTypeId = Guid.Empty;
         A71ResidentGUID = "";
         A527ResidentPackageId = Guid.Empty;
         AV78ResidentTitle = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV70ResidentPackageId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV17ManageFiltersData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV9GridAppliedFilters = "";
         AV40DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV12GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV67ErrDescroption = "";
         AV75Selected_ResidentId = Guid.Empty;
         AV76Selected_LocationId = Guid.Empty;
         AV77Selected_OrganisationId = Guid.Empty;
         AV72Message = "";
         Combo_residentpackageid_Selectedvalue_set = "";
         Ddo_grid_Caption = "";
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
         ucCombo_residentpackageid = new GXUserControl();
         Combo_residentpackageid_Caption = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         lblTextblocklocationoption_Jsonclick = "";
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
         AV44AccountStatus = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H005J2_A29LocationId = new Guid[] {Guid.Empty} ;
         H005J2_A31LocationName = new string[] {""} ;
         H005J2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         AV59successmsg = "";
         AV60websession = context.GetSession();
         AV8GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         GXt_SdtGAMUser1 = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         GXt_guid2 = Guid.Empty;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV79ResidentsTitle = "";
         AV24Session = context.GetSession();
         AV36ColumnsSelectorXML = "";
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV19ManageFiltersXml = "";
         H005J3_A29LocationId = new Guid[] {Guid.Empty} ;
         H005J3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H005J3_A62ResidentId = new Guid[] {Guid.Empty} ;
         H005J3_A72ResidentSalutation = new string[] {""} ;
         H005J3_A63ResidentBsnNumber = new string[] {""} ;
         H005J3_A64ResidentGivenName = new string[] {""} ;
         H005J3_A65ResidentLastName = new string[] {""} ;
         H005J3_A66ResidentInitials = new string[] {""} ;
         H005J3_A67ResidentEmail = new string[] {""} ;
         H005J3_A68ResidentGender = new string[] {""} ;
         H005J3_A312ResidentCountry = new string[] {""} ;
         H005J3_A313ResidentCity = new string[] {""} ;
         H005J3_A314ResidentZipCode = new string[] {""} ;
         H005J3_A315ResidentAddressLine1 = new string[] {""} ;
         H005J3_A316ResidentAddressLine2 = new string[] {""} ;
         H005J3_A70ResidentPhone = new string[] {""} ;
         H005J3_A97ResidentTypeName = new string[] {""} ;
         H005J3_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         H005J3_n98MedicalIndicationId = new bool[] {false} ;
         H005J3_A99MedicalIndicationName = new string[] {""} ;
         H005J3_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         H005J3_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         H005J3_n96ResidentTypeId = new bool[] {false} ;
         H005J3_A71ResidentGUID = new string[] {""} ;
         AV21SDT_Resident = new SdtSDT_Resident(context);
         H005J4_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         H005J4_n527ResidentPackageId = new bool[] {false} ;
         H005J4_A29LocationId = new Guid[] {Guid.Empty} ;
         H005J4_A62ResidentId = new Guid[] {Guid.Empty} ;
         H005J4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H005J4_A72ResidentSalutation = new string[] {""} ;
         H005J4_A63ResidentBsnNumber = new string[] {""} ;
         H005J4_A64ResidentGivenName = new string[] {""} ;
         H005J4_A65ResidentLastName = new string[] {""} ;
         H005J4_A66ResidentInitials = new string[] {""} ;
         H005J4_A67ResidentEmail = new string[] {""} ;
         H005J4_A68ResidentGender = new string[] {""} ;
         H005J4_A312ResidentCountry = new string[] {""} ;
         H005J4_A313ResidentCity = new string[] {""} ;
         H005J4_A314ResidentZipCode = new string[] {""} ;
         H005J4_A315ResidentAddressLine1 = new string[] {""} ;
         H005J4_A316ResidentAddressLine2 = new string[] {""} ;
         H005J4_A70ResidentPhone = new string[] {""} ;
         H005J4_A97ResidentTypeName = new string[] {""} ;
         H005J4_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         H005J4_n98MedicalIndicationId = new bool[] {false} ;
         H005J4_A99MedicalIndicationName = new string[] {""} ;
         H005J4_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         H005J4_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         H005J4_n96ResidentTypeId = new bool[] {false} ;
         H005J4_A71ResidentGUID = new string[] {""} ;
         AV37UserCustomValue = "";
         AV39ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item6 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV61baseUrl = "";
         AV62ResidentGuid_Selected = "";
         AV63GAMUser_Resident = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV49GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV64ActivactionKey = "";
         AV47GAMError = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV68GamErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         ucDvelop_confirmpanel_udelete = new GXUserControl();
         AV13GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         H005J5_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         H005J5_n527ResidentPackageId = new bool[] {false} ;
         H005J5_A531ResidentPackageName = new string[] {""} ;
         A531ResidentPackageName = "";
         AV71Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         H005J6_A29LocationId = new Guid[] {Guid.Empty} ;
         H005J6_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H005J6_A62ResidentId = new Guid[] {Guid.Empty} ;
         H005J6_A72ResidentSalutation = new string[] {""} ;
         H005J6_A63ResidentBsnNumber = new string[] {""} ;
         H005J6_A64ResidentGivenName = new string[] {""} ;
         H005J6_A65ResidentLastName = new string[] {""} ;
         H005J6_A66ResidentInitials = new string[] {""} ;
         H005J6_A67ResidentEmail = new string[] {""} ;
         H005J6_A68ResidentGender = new string[] {""} ;
         H005J6_A312ResidentCountry = new string[] {""} ;
         H005J6_A313ResidentCity = new string[] {""} ;
         H005J6_A314ResidentZipCode = new string[] {""} ;
         H005J6_A315ResidentAddressLine1 = new string[] {""} ;
         H005J6_A316ResidentAddressLine2 = new string[] {""} ;
         H005J6_A70ResidentPhone = new string[] {""} ;
         H005J6_A97ResidentTypeName = new string[] {""} ;
         H005J6_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         H005J6_n98MedicalIndicationId = new bool[] {false} ;
         H005J6_A99MedicalIndicationName = new string[] {""} ;
         H005J6_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         H005J6_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         H005J6_n96ResidentTypeId = new bool[] {false} ;
         H005J6_A71ResidentGUID = new string[] {""} ;
         H005J7_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         H005J7_n527ResidentPackageId = new bool[] {false} ;
         H005J7_A29LocationId = new Guid[] {Guid.Empty} ;
         H005J7_A62ResidentId = new Guid[] {Guid.Empty} ;
         H005J7_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H005J7_A72ResidentSalutation = new string[] {""} ;
         H005J7_A63ResidentBsnNumber = new string[] {""} ;
         H005J7_A64ResidentGivenName = new string[] {""} ;
         H005J7_A65ResidentLastName = new string[] {""} ;
         H005J7_A66ResidentInitials = new string[] {""} ;
         H005J7_A67ResidentEmail = new string[] {""} ;
         H005J7_A68ResidentGender = new string[] {""} ;
         H005J7_A312ResidentCountry = new string[] {""} ;
         H005J7_A313ResidentCity = new string[] {""} ;
         H005J7_A314ResidentZipCode = new string[] {""} ;
         H005J7_A315ResidentAddressLine1 = new string[] {""} ;
         H005J7_A316ResidentAddressLine2 = new string[] {""} ;
         H005J7_A70ResidentPhone = new string[] {""} ;
         H005J7_A97ResidentTypeName = new string[] {""} ;
         H005J7_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         H005J7_n98MedicalIndicationId = new bool[] {false} ;
         H005J7_A99MedicalIndicationName = new string[] {""} ;
         H005J7_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         H005J7_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         H005J7_n96ResidentTypeId = new bool[] {false} ;
         H005J7_A71ResidentGUID = new string[] {""} ;
         GXt_char5 = "";
         ucDvelop_confirmpanel_useractionblock = new GXUserControl();
         ucDvelop_confirmpanel_useractionunblock = new GXUserControl();
         ucDvelop_confirmpanel_resendinvite = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wp_locationresidents__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wp_locationresidents__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_locationresidents__default(),
            new Object[][] {
                new Object[] {
               H005J2_A29LocationId, H005J2_A31LocationName, H005J2_A11OrganisationId
               }
               , new Object[] {
               H005J3_A29LocationId, H005J3_A11OrganisationId, H005J3_A62ResidentId, H005J3_A72ResidentSalutation, H005J3_A63ResidentBsnNumber, H005J3_A64ResidentGivenName, H005J3_A65ResidentLastName, H005J3_A66ResidentInitials, H005J3_A67ResidentEmail, H005J3_A68ResidentGender,
               H005J3_A312ResidentCountry, H005J3_A313ResidentCity, H005J3_A314ResidentZipCode, H005J3_A315ResidentAddressLine1, H005J3_A316ResidentAddressLine2, H005J3_A70ResidentPhone, H005J3_A97ResidentTypeName, H005J3_A98MedicalIndicationId, H005J3_n98MedicalIndicationId, H005J3_A99MedicalIndicationName,
               H005J3_A73ResidentBirthDate, H005J3_A96ResidentTypeId, H005J3_n96ResidentTypeId, H005J3_A71ResidentGUID
               }
               , new Object[] {
               H005J4_A527ResidentPackageId, H005J4_n527ResidentPackageId, H005J4_A29LocationId, H005J4_A62ResidentId, H005J4_A11OrganisationId, H005J4_A72ResidentSalutation, H005J4_A63ResidentBsnNumber, H005J4_A64ResidentGivenName, H005J4_A65ResidentLastName, H005J4_A66ResidentInitials,
               H005J4_A67ResidentEmail, H005J4_A68ResidentGender, H005J4_A312ResidentCountry, H005J4_A313ResidentCity, H005J4_A314ResidentZipCode, H005J4_A315ResidentAddressLine1, H005J4_A316ResidentAddressLine2, H005J4_A70ResidentPhone, H005J4_A97ResidentTypeName, H005J4_A98MedicalIndicationId,
               H005J4_n98MedicalIndicationId, H005J4_A99MedicalIndicationName, H005J4_A73ResidentBirthDate, H005J4_A96ResidentTypeId, H005J4_n96ResidentTypeId, H005J4_A71ResidentGUID
               }
               , new Object[] {
               H005J5_A527ResidentPackageId, H005J5_A531ResidentPackageName
               }
               , new Object[] {
               H005J6_A29LocationId, H005J6_A11OrganisationId, H005J6_A62ResidentId, H005J6_A72ResidentSalutation, H005J6_A63ResidentBsnNumber, H005J6_A64ResidentGivenName, H005J6_A65ResidentLastName, H005J6_A66ResidentInitials, H005J6_A67ResidentEmail, H005J6_A68ResidentGender,
               H005J6_A312ResidentCountry, H005J6_A313ResidentCity, H005J6_A314ResidentZipCode, H005J6_A315ResidentAddressLine1, H005J6_A316ResidentAddressLine2, H005J6_A70ResidentPhone, H005J6_A97ResidentTypeName, H005J6_A98MedicalIndicationId, H005J6_n98MedicalIndicationId, H005J6_A99MedicalIndicationName,
               H005J6_A73ResidentBirthDate, H005J6_A96ResidentTypeId, H005J6_n96ResidentTypeId, H005J6_A71ResidentGUID
               }
               , new Object[] {
               H005J7_A527ResidentPackageId, H005J7_n527ResidentPackageId, H005J7_A29LocationId, H005J7_A62ResidentId, H005J7_A11OrganisationId, H005J7_A72ResidentSalutation, H005J7_A63ResidentBsnNumber, H005J7_A64ResidentGivenName, H005J7_A65ResidentLastName, H005J7_A66ResidentInitials,
               H005J7_A67ResidentEmail, H005J7_A68ResidentGender, H005J7_A312ResidentCountry, H005J7_A313ResidentCity, H005J7_A314ResidentZipCode, H005J7_A315ResidentAddressLine1, H005J7_A316ResidentAddressLine2, H005J7_A70ResidentPhone, H005J7_A97ResidentTypeName, H005J7_A98MedicalIndicationId,
               H005J7_n98MedicalIndicationId, H005J7_A99MedicalIndicationName, H005J7_A73ResidentBirthDate, H005J7_A96ResidentTypeId, H005J7_n96ResidentTypeId, H005J7_A71ResidentGUID
               }
            }
         );
         AV99Pgmname = "WP_LocationResidents";
         /* GeneXus formulas. */
         AV99Pgmname = "WP_LocationResidents";
         edtavSdt_residents__residentid_Enabled = 0;
         edtavSdt_residents__locationid_Enabled = 0;
         edtavSdt_residents__organisationid_Enabled = 0;
         edtavSdt_residents__residentbsnnumber_Enabled = 0;
         cmbavSdt_residents__residentsalutation.Enabled = 0;
         edtavSdt_residents__residentgivenname_Enabled = 0;
         edtavSdt_residents__residentlastname_Enabled = 0;
         edtavSdt_residents__residentinitials_Enabled = 0;
         cmbavSdt_residents__residentgender.Enabled = 0;
         edtavSdt_residents__residentbirthdate_Enabled = 0;
         edtavSdt_residents__residentemail_Enabled = 0;
         edtavSdt_residents__residentphone_Enabled = 0;
         edtavSdt_residents__residentguid_Enabled = 0;
         edtavSdt_residents__residenttypeid_Enabled = 0;
         edtavSdt_residents__residenttypename_Enabled = 0;
         edtavSdt_residents__medicalindicationid_Enabled = 0;
         edtavSdt_residents__medicalindicationname_Enabled = 0;
         edtavSdt_residents__residentaddress_Enabled = 0;
         edtavAccountstatus_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV18ManageFiltersExecutionStep ;
      private short AV54OrderedBy ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV35ActionGroup ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV42IsGAMActive ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_50 ;
      private int nGXsfl_50_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int divUnnamedtable1_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int AV80GXV1 ;
      private int edtavResidentpackageid_Visible ;
      private int gxdynajaxindex ;
      private int subGrid_Islastpage ;
      private int edtavSdt_residents__residentid_Enabled ;
      private int edtavSdt_residents__locationid_Enabled ;
      private int edtavSdt_residents__organisationid_Enabled ;
      private int edtavSdt_residents__residentbsnnumber_Enabled ;
      private int edtavSdt_residents__residentgivenname_Enabled ;
      private int edtavSdt_residents__residentlastname_Enabled ;
      private int edtavSdt_residents__residentinitials_Enabled ;
      private int edtavSdt_residents__residentbirthdate_Enabled ;
      private int edtavSdt_residents__residentemail_Enabled ;
      private int edtavSdt_residents__residentphone_Enabled ;
      private int edtavSdt_residents__residentguid_Enabled ;
      private int edtavSdt_residents__residenttypeid_Enabled ;
      private int edtavSdt_residents__residenttypename_Enabled ;
      private int edtavSdt_residents__medicalindicationid_Enabled ;
      private int edtavSdt_residents__medicalindicationname_Enabled ;
      private int edtavSdt_residents__residentaddress_Enabled ;
      private int edtavAccountstatus_Enabled ;
      private int GRID_nGridOutOfScope ;
      private int nGXsfl_50_fel_idx=1 ;
      private int edtavSdt_residents__residentgivenname_Visible ;
      private int edtavSdt_residents__residentlastname_Visible ;
      private int edtavSdt_residents__residentemail_Visible ;
      private int edtavSdt_residents__residentphone_Visible ;
      private int edtavAccountstatus_Visible ;
      private int AV20PageToGo ;
      private int nGXsfl_50_bak_idx=1 ;
      private int AV103GXV20 ;
      private int AV104GXV21 ;
      private int AV105GXV22 ;
      private int AV106GXV23 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV10GridCurrentPage ;
      private long AV11GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Dvelop_confirmpanel_resendinvite_Result ;
      private string Dvelop_confirmpanel_useractionunblock_Result ;
      private string Dvelop_confirmpanel_useractionblock_Result ;
      private string Dvelop_confirmpanel_udelete_Result ;
      private string Combo_residentpackageid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_50_idx="0001" ;
      private string AV99Pgmname ;
      private string A72ResidentSalutation ;
      private string A66ResidentInitials ;
      private string A70ResidentPhone ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV67ErrDescroption ;
      private string AV72Message ;
      private string Combo_residentpackageid_Cls ;
      private string Combo_residentpackageid_Selectedvalue_set ;
      private string Combo_residentpackageid_Emptyitemtext ;
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
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
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
      private string Dvelop_confirmpanel_useractionunblock_Title ;
      private string Dvelop_confirmpanel_useractionunblock_Confirmationtext ;
      private string Dvelop_confirmpanel_useractionunblock_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_useractionunblock_Nobuttoncaption ;
      private string Dvelop_confirmpanel_useractionunblock_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_useractionunblock_Yesbuttonposition ;
      private string Dvelop_confirmpanel_useractionunblock_Confirmtype ;
      private string Dvelop_confirmpanel_useractionblock_Title ;
      private string Dvelop_confirmpanel_useractionblock_Confirmationtext ;
      private string Dvelop_confirmpanel_useractionblock_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_useractionblock_Nobuttoncaption ;
      private string Dvelop_confirmpanel_useractionblock_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_useractionblock_Yesbuttonposition ;
      private string Dvelop_confirmpanel_useractionblock_Confirmtype ;
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
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string divCombo_residentpackageid_cell_Internalname ;
      private string divCombo_residentpackageid_cell_Class ;
      private string Combo_residentpackageid_Caption ;
      private string Combo_residentpackageid_Internalname ;
      private string divTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string divTablefilters_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string divUnnamedtablelocationoption_Internalname ;
      private string lblTextblocklocationoption_Internalname ;
      private string lblTextblocklocationoption_Jsonclick ;
      private string dynavLocationoption_Internalname ;
      private string dynavLocationoption_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavResidentpackageid_Internalname ;
      private string edtavResidentpackageid_Jsonclick ;
      private string Ddo_grid_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavAccountstatus_Internalname ;
      private string cmbavActiongroup_Internalname ;
      private string gxwrpcisep ;
      private string sGXsfl_50_fel_idx="0001" ;
      private string edtavSdt_residents__residentgivenname_Internalname ;
      private string edtavSdt_residents__residentlastname_Internalname ;
      private string cmbavSdt_residents__residentgender_Internalname ;
      private string edtavSdt_residents__residentemail_Internalname ;
      private string edtavSdt_residents__residentphone_Internalname ;
      private string edtavAccountstatus_Columnheaderclass ;
      private string edtavSdt_residents__residentgivenname_Link ;
      private string GXEncryptionTmp ;
      private string edtavSdt_residents__residentlastname_Link ;
      private string edtavAccountstatus_Columnclass ;
      private string Dvelop_confirmpanel_udelete_Internalname ;
      private string GXt_char5 ;
      private string tblTabledvelop_confirmpanel_udelete_Internalname ;
      private string tblTabledvelop_confirmpanel_useractionblock_Internalname ;
      private string Dvelop_confirmpanel_useractionblock_Internalname ;
      private string tblTabledvelop_confirmpanel_useractionunblock_Internalname ;
      private string Dvelop_confirmpanel_useractionunblock_Internalname ;
      private string tblTabledvelop_confirmpanel_resendinvite_Internalname ;
      private string Dvelop_confirmpanel_resendinvite_Internalname ;
      private string edtavSdt_residents__residentid_Internalname ;
      private string edtavSdt_residents__locationid_Internalname ;
      private string edtavSdt_residents__organisationid_Internalname ;
      private string edtavSdt_residents__residentbsnnumber_Internalname ;
      private string cmbavSdt_residents__residentsalutation_Internalname ;
      private string edtavSdt_residents__residentinitials_Internalname ;
      private string edtavSdt_residents__residentbirthdate_Internalname ;
      private string edtavSdt_residents__residentguid_Internalname ;
      private string edtavSdt_residents__residenttypeid_Internalname ;
      private string edtavSdt_residents__residenttypename_Internalname ;
      private string edtavSdt_residents__medicalindicationid_Internalname ;
      private string edtavSdt_residents__medicalindicationname_Internalname ;
      private string edtavSdt_residents__residentaddress_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavSdt_residents__residentid_Jsonclick ;
      private string edtavSdt_residents__locationid_Jsonclick ;
      private string edtavSdt_residents__organisationid_Jsonclick ;
      private string edtavSdt_residents__residentbsnnumber_Jsonclick ;
      private string GXCCtl ;
      private string cmbavSdt_residents__residentsalutation_Jsonclick ;
      private string edtavSdt_residents__residentgivenname_Jsonclick ;
      private string edtavSdt_residents__residentlastname_Jsonclick ;
      private string edtavSdt_residents__residentinitials_Jsonclick ;
      private string cmbavSdt_residents__residentgender_Jsonclick ;
      private string edtavSdt_residents__residentbirthdate_Jsonclick ;
      private string edtavSdt_residents__residentemail_Jsonclick ;
      private string edtavSdt_residents__residentphone_Jsonclick ;
      private string edtavSdt_residents__residentguid_Jsonclick ;
      private string edtavSdt_residents__residenttypeid_Jsonclick ;
      private string edtavSdt_residents__residenttypename_Jsonclick ;
      private string edtavSdt_residents__medicalindicationid_Jsonclick ;
      private string edtavSdt_residents__medicalindicationname_Jsonclick ;
      private string edtavSdt_residents__residentaddress_Jsonclick ;
      private string edtavAccountstatus_Jsonclick ;
      private string cmbavActiongroup_Jsonclick ;
      private string subGrid_Header ;
      private DateTime A73ResidentBirthDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV55OrderedDsc ;
      private bool n98MedicalIndicationId ;
      private bool n96ResidentTypeId ;
      private bool n527ResidentPackageId ;
      private bool AV33IsAuthorized_Delete ;
      private bool AV41IsAuthorized_SDT_Residents ;
      private bool AV65isSent ;
      private bool AV34isSuccessful ;
      private bool Combo_residentpackageid_Visible ;
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
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_50_Refreshing=false ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV43IsGAMBlocked ;
      private bool gx_BV50 ;
      private bool AV29WWPContext_gxTpr_Isrootadmin ;
      private bool AV31IsAuthorized_Insert ;
      private bool GXt_boolean3 ;
      private bool AV50IsunBlocked ;
      private bool AV48IsBlocked ;
      private string AV36ColumnsSelectorXML ;
      private string AV19ManageFiltersXml ;
      private string AV37UserCustomValue ;
      private string AV7FilterFullText ;
      private string A63ResidentBsnNumber ;
      private string A64ResidentGivenName ;
      private string A65ResidentLastName ;
      private string A67ResidentEmail ;
      private string A68ResidentGender ;
      private string A312ResidentCountry ;
      private string A313ResidentCity ;
      private string A314ResidentZipCode ;
      private string A315ResidentAddressLine1 ;
      private string A316ResidentAddressLine2 ;
      private string A97ResidentTypeName ;
      private string A99MedicalIndicationName ;
      private string A71ResidentGUID ;
      private string AV78ResidentTitle ;
      private string AV9GridAppliedFilters ;
      private string AV44AccountStatus ;
      private string AV59successmsg ;
      private string AV79ResidentsTitle ;
      private string AV61baseUrl ;
      private string AV62ResidentGuid_Selected ;
      private string AV64ActivactionKey ;
      private string A531ResidentPackageName ;
      private Guid AV69ResidentPackageId ;
      private Guid A11OrganisationId ;
      private Guid AV101Udparg1 ;
      private Guid A29LocationId ;
      private Guid AV16LocationOption ;
      private Guid A62ResidentId ;
      private Guid A98MedicalIndicationId ;
      private Guid A96ResidentTypeId ;
      private Guid A527ResidentPackageId ;
      private Guid AV75Selected_ResidentId ;
      private Guid AV76Selected_LocationId ;
      private Guid AV77Selected_OrganisationId ;
      private Guid GXt_guid2 ;
      private Guid AV29WWPContext_gxTpr_Organisationid ;
      private IGxSession AV60websession ;
      private IGxSession AV24Session ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucCombo_residentpackageid ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucDvelop_confirmpanel_udelete ;
      private GXUserControl ucDvelop_confirmpanel_useractionblock ;
      private GXUserControl ucDvelop_confirmpanel_useractionunblock ;
      private GXUserControl ucDvelop_confirmpanel_resendinvite ;
      private GxHttpRequest AV14HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavLocationoption ;
      private GXCombobox cmbavSdt_residents__residentsalutation ;
      private GXCombobox cmbavSdt_residents__residentgender ;
      private GXCombobox cmbavActiongroup ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV29WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV38ColumnsSelector ;
      private GXBaseCollection<SdtSDT_Resident> AV22SDT_Residents ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV70ResidentPackageId_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV17ManageFiltersData ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV40DDO_TitleSettingsIcons ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV12GridState ;
      private IDataStoreProvider pr_default ;
      private Guid[] H005J2_A29LocationId ;
      private string[] H005J2_A31LocationName ;
      private Guid[] H005J2_A11OrganisationId ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV8GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser GXt_SdtGAMUser1 ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4 ;
      private Guid[] H005J3_A29LocationId ;
      private Guid[] H005J3_A11OrganisationId ;
      private Guid[] H005J3_A62ResidentId ;
      private string[] H005J3_A72ResidentSalutation ;
      private string[] H005J3_A63ResidentBsnNumber ;
      private string[] H005J3_A64ResidentGivenName ;
      private string[] H005J3_A65ResidentLastName ;
      private string[] H005J3_A66ResidentInitials ;
      private string[] H005J3_A67ResidentEmail ;
      private string[] H005J3_A68ResidentGender ;
      private string[] H005J3_A312ResidentCountry ;
      private string[] H005J3_A313ResidentCity ;
      private string[] H005J3_A314ResidentZipCode ;
      private string[] H005J3_A315ResidentAddressLine1 ;
      private string[] H005J3_A316ResidentAddressLine2 ;
      private string[] H005J3_A70ResidentPhone ;
      private string[] H005J3_A97ResidentTypeName ;
      private Guid[] H005J3_A98MedicalIndicationId ;
      private bool[] H005J3_n98MedicalIndicationId ;
      private string[] H005J3_A99MedicalIndicationName ;
      private DateTime[] H005J3_A73ResidentBirthDate ;
      private Guid[] H005J3_A96ResidentTypeId ;
      private bool[] H005J3_n96ResidentTypeId ;
      private string[] H005J3_A71ResidentGUID ;
      private SdtSDT_Resident AV21SDT_Resident ;
      private Guid[] H005J4_A527ResidentPackageId ;
      private bool[] H005J4_n527ResidentPackageId ;
      private Guid[] H005J4_A29LocationId ;
      private Guid[] H005J4_A62ResidentId ;
      private Guid[] H005J4_A11OrganisationId ;
      private string[] H005J4_A72ResidentSalutation ;
      private string[] H005J4_A63ResidentBsnNumber ;
      private string[] H005J4_A64ResidentGivenName ;
      private string[] H005J4_A65ResidentLastName ;
      private string[] H005J4_A66ResidentInitials ;
      private string[] H005J4_A67ResidentEmail ;
      private string[] H005J4_A68ResidentGender ;
      private string[] H005J4_A312ResidentCountry ;
      private string[] H005J4_A313ResidentCity ;
      private string[] H005J4_A314ResidentZipCode ;
      private string[] H005J4_A315ResidentAddressLine1 ;
      private string[] H005J4_A316ResidentAddressLine2 ;
      private string[] H005J4_A70ResidentPhone ;
      private string[] H005J4_A97ResidentTypeName ;
      private Guid[] H005J4_A98MedicalIndicationId ;
      private bool[] H005J4_n98MedicalIndicationId ;
      private string[] H005J4_A99MedicalIndicationName ;
      private DateTime[] H005J4_A73ResidentBirthDate ;
      private Guid[] H005J4_A96ResidentTypeId ;
      private bool[] H005J4_n96ResidentTypeId ;
      private string[] H005J4_A71ResidentGUID ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV39ColumnsSelectorAux ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item6 ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV63GAMUser_Resident ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV49GAMErrors ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV47GAMError ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV68GamErrorCollection ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV13GridStateFilterValue ;
      private Guid[] H005J5_A527ResidentPackageId ;
      private bool[] H005J5_n527ResidentPackageId ;
      private string[] H005J5_A531ResidentPackageName ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV71Combo_DataItem ;
      private Guid[] H005J6_A29LocationId ;
      private Guid[] H005J6_A11OrganisationId ;
      private Guid[] H005J6_A62ResidentId ;
      private string[] H005J6_A72ResidentSalutation ;
      private string[] H005J6_A63ResidentBsnNumber ;
      private string[] H005J6_A64ResidentGivenName ;
      private string[] H005J6_A65ResidentLastName ;
      private string[] H005J6_A66ResidentInitials ;
      private string[] H005J6_A67ResidentEmail ;
      private string[] H005J6_A68ResidentGender ;
      private string[] H005J6_A312ResidentCountry ;
      private string[] H005J6_A313ResidentCity ;
      private string[] H005J6_A314ResidentZipCode ;
      private string[] H005J6_A315ResidentAddressLine1 ;
      private string[] H005J6_A316ResidentAddressLine2 ;
      private string[] H005J6_A70ResidentPhone ;
      private string[] H005J6_A97ResidentTypeName ;
      private Guid[] H005J6_A98MedicalIndicationId ;
      private bool[] H005J6_n98MedicalIndicationId ;
      private string[] H005J6_A99MedicalIndicationName ;
      private DateTime[] H005J6_A73ResidentBirthDate ;
      private Guid[] H005J6_A96ResidentTypeId ;
      private bool[] H005J6_n96ResidentTypeId ;
      private string[] H005J6_A71ResidentGUID ;
      private Guid[] H005J7_A527ResidentPackageId ;
      private bool[] H005J7_n527ResidentPackageId ;
      private Guid[] H005J7_A29LocationId ;
      private Guid[] H005J7_A62ResidentId ;
      private Guid[] H005J7_A11OrganisationId ;
      private string[] H005J7_A72ResidentSalutation ;
      private string[] H005J7_A63ResidentBsnNumber ;
      private string[] H005J7_A64ResidentGivenName ;
      private string[] H005J7_A65ResidentLastName ;
      private string[] H005J7_A66ResidentInitials ;
      private string[] H005J7_A67ResidentEmail ;
      private string[] H005J7_A68ResidentGender ;
      private string[] H005J7_A312ResidentCountry ;
      private string[] H005J7_A313ResidentCity ;
      private string[] H005J7_A314ResidentZipCode ;
      private string[] H005J7_A315ResidentAddressLine1 ;
      private string[] H005J7_A316ResidentAddressLine2 ;
      private string[] H005J7_A70ResidentPhone ;
      private string[] H005J7_A97ResidentTypeName ;
      private Guid[] H005J7_A98MedicalIndicationId ;
      private bool[] H005J7_n98MedicalIndicationId ;
      private string[] H005J7_A99MedicalIndicationName ;
      private DateTime[] H005J7_A73ResidentBirthDate ;
      private Guid[] H005J7_A96ResidentTypeId ;
      private bool[] H005J7_n96ResidentTypeId ;
      private string[] H005J7_A71ResidentGUID ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wp_locationresidents__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wp_locationresidents__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wp_locationresidents__default : DataStoreHelperBase, IDataStoreHelper
{
   protected Object[] conditional_H005J3( IGxContext context ,
                                          Guid AV16LocationOption ,
                                          Guid A29LocationId ,
                                          Guid A11OrganisationId ,
                                          bool AV29WWPContext_gxTpr_Isrootadmin ,
                                          Guid AV29WWPContext_gxTpr_Organisationid ,
                                          Guid AV101Udparg1 )
   {
      System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
      string scmdbuf;
      short[] GXv_int7 = new short[4];
      Object[] GXv_Object8 = new Object[2];
      scmdbuf = "SELECT T1.LocationId, T1.OrganisationId, T1.ResidentId, T1.ResidentSalutation, T1.ResidentBsnNumber, T1.ResidentGivenName, T1.ResidentLastName, T1.ResidentInitials, T1.ResidentEmail, T1.ResidentGender, T1.ResidentCountry, T1.ResidentCity, T1.ResidentZipCode, T1.ResidentAddressLine1, T1.ResidentAddressLine2, T1.ResidentPhone, T3.ResidentTypeName, T1.MedicalIndicationId, T2.MedicalIndicationName, T1.ResidentBirthDate, T1.ResidentTypeId, T1.ResidentGUID FROM ((Trn_Resident T1 LEFT JOIN Trn_MedicalIndication T2 ON T2.MedicalIndicationId = T1.MedicalIndicationId) LEFT JOIN Trn_ResidentType T3 ON T3.ResidentTypeId = T1.ResidentTypeId)";
      AddWhere(sWhereString, "(T1.OrganisationId = CASE  WHEN :AV29WWPContext__Isrootadmin THEN :AV29WWPC_1Organisationid ELSE :AV101Udparg1 END)");
      if ( ! (Guid.Empty==AV16LocationOption) )
      {
         AddWhere(sWhereString, "(T1.LocationId = :AV16LocationOption)");
      }
      else
      {
         GXv_int7[3] = 1;
      }
      scmdbuf += sWhereString;
      scmdbuf += " ORDER BY T1.ResidentId, T1.LocationId, T1.OrganisationId";
      GXv_Object8[0] = scmdbuf;
      GXv_Object8[1] = GXv_int7;
      return GXv_Object8 ;
   }

   protected Object[] conditional_H005J4( IGxContext context ,
                                          Guid AV16LocationOption ,
                                          Guid AV69ResidentPackageId ,
                                          Guid A29LocationId ,
                                          Guid A527ResidentPackageId )
   {
      System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
      string scmdbuf;
      short[] GXv_int9 = new short[2];
      Object[] GXv_Object10 = new Object[2];
      scmdbuf = "SELECT T1.ResidentPackageId, T1.LocationId, T1.ResidentId, T1.OrganisationId, T1.ResidentSalutation, T1.ResidentBsnNumber, T1.ResidentGivenName, T1.ResidentLastName, T1.ResidentInitials, T1.ResidentEmail, T1.ResidentGender, T1.ResidentCountry, T1.ResidentCity, T1.ResidentZipCode, T1.ResidentAddressLine1, T1.ResidentAddressLine2, T1.ResidentPhone, T3.ResidentTypeName, T1.MedicalIndicationId, T2.MedicalIndicationName, T1.ResidentBirthDate, T1.ResidentTypeId, T1.ResidentGUID FROM ((Trn_Resident T1 LEFT JOIN Trn_MedicalIndication T2 ON T2.MedicalIndicationId = T1.MedicalIndicationId) LEFT JOIN Trn_ResidentType T3 ON T3.ResidentTypeId = T1.ResidentTypeId)";
      if ( ! (Guid.Empty==AV16LocationOption) )
      {
         AddWhere(sWhereString, "(T1.LocationId = :AV16LocationOption)");
      }
      else
      {
         GXv_int9[0] = 1;
      }
      if ( ! (Guid.Empty==AV69ResidentPackageId) )
      {
         AddWhere(sWhereString, "(T1.ResidentPackageId = :AV69ResidentPackageId)");
      }
      else
      {
         GXv_int9[1] = 1;
      }
      scmdbuf += sWhereString;
      scmdbuf += " ORDER BY T1.ResidentId, T1.LocationId, T1.OrganisationId";
      GXv_Object10[0] = scmdbuf;
      GXv_Object10[1] = GXv_int9;
      return GXv_Object10 ;
   }

   protected Object[] conditional_H005J6( IGxContext context ,
                                          Guid AV16LocationOption ,
                                          Guid A29LocationId ,
                                          Guid A11OrganisationId ,
                                          bool AV29WWPContext_gxTpr_Isrootadmin ,
                                          Guid AV29WWPContext_gxTpr_Organisationid ,
                                          Guid AV101Udparg1 )
   {
      System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
      string scmdbuf;
      short[] GXv_int11 = new short[4];
      Object[] GXv_Object12 = new Object[2];
      scmdbuf = "SELECT T1.LocationId, T1.OrganisationId, T1.ResidentId, T1.ResidentSalutation, T1.ResidentBsnNumber, T1.ResidentGivenName, T1.ResidentLastName, T1.ResidentInitials, T1.ResidentEmail, T1.ResidentGender, T1.ResidentCountry, T1.ResidentCity, T1.ResidentZipCode, T1.ResidentAddressLine1, T1.ResidentAddressLine2, T1.ResidentPhone, T3.ResidentTypeName, T1.MedicalIndicationId, T2.MedicalIndicationName, T1.ResidentBirthDate, T1.ResidentTypeId, T1.ResidentGUID FROM ((Trn_Resident T1 LEFT JOIN Trn_MedicalIndication T2 ON T2.MedicalIndicationId = T1.MedicalIndicationId) LEFT JOIN Trn_ResidentType T3 ON T3.ResidentTypeId = T1.ResidentTypeId)";
      AddWhere(sWhereString, "(T1.OrganisationId = CASE  WHEN :AV29WWPContext__Isrootadmin THEN :AV29WWPC_1Organisationid ELSE :AV101Udparg1 END)");
      if ( ! (Guid.Empty==AV16LocationOption) )
      {
         AddWhere(sWhereString, "(T1.LocationId = :AV16LocationOption)");
      }
      else
      {
         GXv_int11[3] = 1;
      }
      scmdbuf += sWhereString;
      scmdbuf += " ORDER BY T1.ResidentId, T1.LocationId, T1.OrganisationId";
      GXv_Object12[0] = scmdbuf;
      GXv_Object12[1] = GXv_int11;
      return GXv_Object12 ;
   }

   protected Object[] conditional_H005J7( IGxContext context ,
                                          Guid AV16LocationOption ,
                                          Guid AV69ResidentPackageId ,
                                          Guid A29LocationId ,
                                          Guid A527ResidentPackageId )
   {
      System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
      string scmdbuf;
      short[] GXv_int13 = new short[2];
      Object[] GXv_Object14 = new Object[2];
      scmdbuf = "SELECT T1.ResidentPackageId, T1.LocationId, T1.ResidentId, T1.OrganisationId, T1.ResidentSalutation, T1.ResidentBsnNumber, T1.ResidentGivenName, T1.ResidentLastName, T1.ResidentInitials, T1.ResidentEmail, T1.ResidentGender, T1.ResidentCountry, T1.ResidentCity, T1.ResidentZipCode, T1.ResidentAddressLine1, T1.ResidentAddressLine2, T1.ResidentPhone, T3.ResidentTypeName, T1.MedicalIndicationId, T2.MedicalIndicationName, T1.ResidentBirthDate, T1.ResidentTypeId, T1.ResidentGUID FROM ((Trn_Resident T1 LEFT JOIN Trn_MedicalIndication T2 ON T2.MedicalIndicationId = T1.MedicalIndicationId) LEFT JOIN Trn_ResidentType T3 ON T3.ResidentTypeId = T1.ResidentTypeId)";
      if ( ! (Guid.Empty==AV16LocationOption) )
      {
         AddWhere(sWhereString, "(T1.LocationId = :AV16LocationOption)");
      }
      else
      {
         GXv_int13[0] = 1;
      }
      if ( ! (Guid.Empty==AV69ResidentPackageId) )
      {
         AddWhere(sWhereString, "(T1.ResidentPackageId = :AV69ResidentPackageId)");
      }
      else
      {
         GXv_int13[1] = 1;
      }
      scmdbuf += sWhereString;
      scmdbuf += " ORDER BY T1.ResidentId, T1.LocationId, T1.OrganisationId";
      GXv_Object14[0] = scmdbuf;
      GXv_Object14[1] = GXv_int13;
      return GXv_Object14 ;
   }

   public override Object [] getDynamicStatement( int cursor ,
                                                  IGxContext context ,
                                                  Object [] dynConstraints )
   {
      switch ( cursor )
      {
            case 1 :
                  return conditional_H005J3(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] , (Guid)dynConstraints[2] , (bool)dynConstraints[3] , (Guid)dynConstraints[4] , (Guid)dynConstraints[5] );
            case 2 :
                  return conditional_H005J4(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] , (Guid)dynConstraints[2] , (Guid)dynConstraints[3] );
            case 4 :
                  return conditional_H005J6(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] , (Guid)dynConstraints[2] , (bool)dynConstraints[3] , (Guid)dynConstraints[4] , (Guid)dynConstraints[5] );
            case 5 :
                  return conditional_H005J7(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] , (Guid)dynConstraints[2] , (Guid)dynConstraints[3] );
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
      ,new ForEachCursor(def[4])
      ,new ForEachCursor(def[5])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmH005J2;
       prmH005J2 = new Object[] {
       };
       Object[] prmH005J5;
       prmH005J5 = new Object[] {
       };
       Object[] prmH005J3;
       prmH005J3 = new Object[] {
       new ParDef("AV29WWPC_1Organisationid",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV29WWPContext__Isrootadmin",GXType.Boolean,4,0) ,
       new ParDef("AV101Udparg1",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV16LocationOption",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmH005J4;
       prmH005J4 = new Object[] {
       new ParDef("AV16LocationOption",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV69ResidentPackageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmH005J6;
       prmH005J6 = new Object[] {
       new ParDef("AV29WWPC_1Organisationid",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV29WWPContext__Isrootadmin",GXType.Boolean,4,0) ,
       new ParDef("AV101Udparg1",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV16LocationOption",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmH005J7;
       prmH005J7 = new Object[] {
       new ParDef("AV16LocationOption",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV69ResidentPackageId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("H005J2", "SELECT LocationId, LocationName, OrganisationId FROM Trn_Location ORDER BY LocationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005J2,0, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H005J3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005J3,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H005J4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005J4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H005J5", "SELECT ResidentPackageId, ResidentPackageName FROM Trn_ResidentPackage ORDER BY ResidentPackageName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005J5,100, GxCacheFrequency.OFF ,false,false )
          ,new CursorDef("H005J6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005J6,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H005J7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005J7,100, GxCacheFrequency.OFF ,true,false )
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
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((string[]) buf[3])[0] = rslt.getString(4, 20);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getString(8, 20);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((string[]) buf[15])[0] = rslt.getString(16, 20);
             ((string[]) buf[16])[0] = rslt.getVarchar(17);
             ((Guid[]) buf[17])[0] = rslt.getGuid(18);
             ((bool[]) buf[18])[0] = rslt.wasNull(18);
             ((string[]) buf[19])[0] = rslt.getVarchar(19);
             ((DateTime[]) buf[20])[0] = rslt.getGXDate(20);
             ((Guid[]) buf[21])[0] = rslt.getGuid(21);
             ((bool[]) buf[22])[0] = rslt.wasNull(21);
             ((string[]) buf[23])[0] = rslt.getVarchar(22);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((bool[]) buf[1])[0] = rslt.wasNull(1);
             ((Guid[]) buf[2])[0] = rslt.getGuid(2);
             ((Guid[]) buf[3])[0] = rslt.getGuid(3);
             ((Guid[]) buf[4])[0] = rslt.getGuid(4);
             ((string[]) buf[5])[0] = rslt.getString(5, 20);
             ((string[]) buf[6])[0] = rslt.getVarchar(6);
             ((string[]) buf[7])[0] = rslt.getVarchar(7);
             ((string[]) buf[8])[0] = rslt.getVarchar(8);
             ((string[]) buf[9])[0] = rslt.getString(9, 20);
             ((string[]) buf[10])[0] = rslt.getVarchar(10);
             ((string[]) buf[11])[0] = rslt.getVarchar(11);
             ((string[]) buf[12])[0] = rslt.getVarchar(12);
             ((string[]) buf[13])[0] = rslt.getVarchar(13);
             ((string[]) buf[14])[0] = rslt.getVarchar(14);
             ((string[]) buf[15])[0] = rslt.getVarchar(15);
             ((string[]) buf[16])[0] = rslt.getVarchar(16);
             ((string[]) buf[17])[0] = rslt.getString(17, 20);
             ((string[]) buf[18])[0] = rslt.getVarchar(18);
             ((Guid[]) buf[19])[0] = rslt.getGuid(19);
             ((bool[]) buf[20])[0] = rslt.wasNull(19);
             ((string[]) buf[21])[0] = rslt.getVarchar(20);
             ((DateTime[]) buf[22])[0] = rslt.getGXDate(21);
             ((Guid[]) buf[23])[0] = rslt.getGuid(22);
             ((bool[]) buf[24])[0] = rslt.wasNull(22);
             ((string[]) buf[25])[0] = rslt.getVarchar(23);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((string[]) buf[3])[0] = rslt.getString(4, 20);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getString(8, 20);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((string[]) buf[15])[0] = rslt.getString(16, 20);
             ((string[]) buf[16])[0] = rslt.getVarchar(17);
             ((Guid[]) buf[17])[0] = rslt.getGuid(18);
             ((bool[]) buf[18])[0] = rslt.wasNull(18);
             ((string[]) buf[19])[0] = rslt.getVarchar(19);
             ((DateTime[]) buf[20])[0] = rslt.getGXDate(20);
             ((Guid[]) buf[21])[0] = rslt.getGuid(21);
             ((bool[]) buf[22])[0] = rslt.wasNull(21);
             ((string[]) buf[23])[0] = rslt.getVarchar(22);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((bool[]) buf[1])[0] = rslt.wasNull(1);
             ((Guid[]) buf[2])[0] = rslt.getGuid(2);
             ((Guid[]) buf[3])[0] = rslt.getGuid(3);
             ((Guid[]) buf[4])[0] = rslt.getGuid(4);
             ((string[]) buf[5])[0] = rslt.getString(5, 20);
             ((string[]) buf[6])[0] = rslt.getVarchar(6);
             ((string[]) buf[7])[0] = rslt.getVarchar(7);
             ((string[]) buf[8])[0] = rslt.getVarchar(8);
             ((string[]) buf[9])[0] = rslt.getString(9, 20);
             ((string[]) buf[10])[0] = rslt.getVarchar(10);
             ((string[]) buf[11])[0] = rslt.getVarchar(11);
             ((string[]) buf[12])[0] = rslt.getVarchar(12);
             ((string[]) buf[13])[0] = rslt.getVarchar(13);
             ((string[]) buf[14])[0] = rslt.getVarchar(14);
             ((string[]) buf[15])[0] = rslt.getVarchar(15);
             ((string[]) buf[16])[0] = rslt.getVarchar(16);
             ((string[]) buf[17])[0] = rslt.getString(17, 20);
             ((string[]) buf[18])[0] = rslt.getVarchar(18);
             ((Guid[]) buf[19])[0] = rslt.getGuid(19);
             ((bool[]) buf[20])[0] = rslt.wasNull(19);
             ((string[]) buf[21])[0] = rslt.getVarchar(20);
             ((DateTime[]) buf[22])[0] = rslt.getGXDate(21);
             ((Guid[]) buf[23])[0] = rslt.getGuid(22);
             ((bool[]) buf[24])[0] = rslt.wasNull(22);
             ((string[]) buf[25])[0] = rslt.getVarchar(23);
             return;
    }
 }

}

}
