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
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class wp_createresidentandnetwork : GXDataArea
   {
      public wp_createresidentandnetwork( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_createresidentandnetwork( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_ResidentId ,
                           Guid aP2_LocationId ,
                           Guid aP3_OrganisationId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV33ResidentId = aP1_ResidentId;
         this.AV34LocationId = aP2_LocationId;
         this.AV35OrganisationId = aP3_OrganisationId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavResidentsalutation = new GXCombobox();
         cmbavResidentgender = new GXCombobox();
         cmbavNetworkindividualsalutation = new GXCombobox();
         cmbavNetworkindividualgender = new GXCombobox();
         cmbavNetworkindividualrelationship = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mode");
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
               gxfirstwebparm = GetFirstPar( "Mode");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "Mode");
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
            return "wp_createresidentandnetwork_Execute" ;
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
         PABX2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTBX2( ) ;
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
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
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
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
         GXEncryptionTmp = "wp_createresidentandnetwork.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV33ResidentId.ToString()) + "," + UrlEncode(AV34LocationId.ToString()) + "," + UrlEncode(AV35OrganisationId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_createresidentandnetwork.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV85WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV85WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV85WWPContext, context));
         GxWebStd.gx_hidden_field( context, "vRESIDENTTITLEDEFINITION", AV89ResidentTitleDefinition);
         GxWebStd.gx_hidden_field( context, "gxhash_vRESIDENTTITLEDEFINITION", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV89ResidentTitleDefinition, "")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vRESIDENTID", GetSecureSignedToken( "", AV33ResidentId, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", AV34LocationId, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV35OrganisationId, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV54DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV54DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vRESIDENTPHONECODE_DATA", AV67ResidentPhoneCode_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vRESIDENTPHONECODE_DATA", AV67ResidentPhoneCode_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vRESIDENTHOMEPHONECODE_DATA", AV65ResidentHomePhoneCode_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vRESIDENTHOMEPHONECODE_DATA", AV65ResidentHomePhoneCode_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vRESIDENTCOUNTRY_DATA", AV63ResidentCountry_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vRESIDENTCOUNTRY_DATA", AV63ResidentCountry_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vRESIDENTTYPEID_DATA", AV61ResidentTypeId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vRESIDENTTYPEID_DATA", AV61ResidentTypeId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vRESIDENTPACKAGEID_DATA", AV62ResidentPackageId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vRESIDENTPACKAGEID_DATA", AV62ResidentPackageId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vNETWORKINDIVIDUALPHONECODE_DATA", AV59NetworkIndividualPhoneCode_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNETWORKINDIVIDUALPHONECODE_DATA", AV59NetworkIndividualPhoneCode_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vNETWORKINDIVIDUALHOMEPHONECODE_DATA", AV57NetworkIndividualHomePhoneCode_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNETWORKINDIVIDUALHOMEPHONECODE_DATA", AV57NetworkIndividualHomePhoneCode_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vNETWORKINDIVIDUALCOUNTRY_DATA", AV53NetworkIndividualCountry_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNETWORKINDIVIDUALCOUNTRY_DATA", AV53NetworkIndividualCountry_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV80CheckRequiredFieldsResult);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRN_RESIDENT", AV74Trn_Resident);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRN_RESIDENT", AV74Trn_Resident);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vRESIDENTPACKAGEID", AV25ResidentPackageId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vRESIDENTPACKAGEID", AV25ResidentPackageId);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV85WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV85WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV85WWPContext, context));
         GxWebStd.gx_hidden_field( context, "vRESIDENTTITLEDEFINITION", AV89ResidentTitleDefinition);
         GxWebStd.gx_hidden_field( context, "gxhash_vRESIDENTTITLEDEFINITION", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV89ResidentTitleDefinition, "")), context));
         GxWebStd.gx_hidden_field( context, "RESIDENTID", A62ResidentId.ToString());
         GxWebStd.gx_hidden_field( context, "NETWORKINDIVIDUALID", A74NetworkIndividualId.ToString());
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vERRORMESSAGECOLLECTION", AV81ErrorMessageCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vERRORMESSAGECOLLECTION", AV81ErrorMessageCollection);
         }
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPHONECODE_Cls", StringUtil.RTrim( Combo_residentphonecode_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPHONECODE_Selectedvalue_set", StringUtil.RTrim( Combo_residentphonecode_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPHONECODE_Selectedtext_set", StringUtil.RTrim( Combo_residentphonecode_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPHONECODE_Emptyitem", StringUtil.BoolToStr( Combo_residentphonecode_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPHONECODE_Htmltemplate", StringUtil.RTrim( Combo_residentphonecode_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTHOMEPHONECODE_Cls", StringUtil.RTrim( Combo_residenthomephonecode_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTHOMEPHONECODE_Selectedvalue_set", StringUtil.RTrim( Combo_residenthomephonecode_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTHOMEPHONECODE_Selectedtext_set", StringUtil.RTrim( Combo_residenthomephonecode_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTHOMEPHONECODE_Emptyitem", StringUtil.BoolToStr( Combo_residenthomephonecode_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTHOMEPHONECODE_Htmltemplate", StringUtil.RTrim( Combo_residenthomephonecode_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTCOUNTRY_Cls", StringUtil.RTrim( Combo_residentcountry_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTCOUNTRY_Selectedvalue_set", StringUtil.RTrim( Combo_residentcountry_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTCOUNTRY_Selectedtext_set", StringUtil.RTrim( Combo_residentcountry_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTCOUNTRY_Enabled", StringUtil.BoolToStr( Combo_residentcountry_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTCOUNTRY_Emptyitem", StringUtil.BoolToStr( Combo_residentcountry_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTCOUNTRY_Htmltemplate", StringUtil.RTrim( Combo_residentcountry_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTTYPEID_Cls", StringUtil.RTrim( Combo_residenttypeid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTTYPEID_Selectedvalue_set", StringUtil.RTrim( Combo_residenttypeid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTTYPEID_Selectedtext_set", StringUtil.RTrim( Combo_residenttypeid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTTYPEID_Enabled", StringUtil.BoolToStr( Combo_residenttypeid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTTYPEID_Emptyitem", StringUtil.BoolToStr( Combo_residenttypeid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPACKAGEID_Cls", StringUtil.RTrim( Combo_residentpackageid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPACKAGEID_Selectedvalue_set", StringUtil.RTrim( Combo_residentpackageid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPACKAGEID_Selectedtext_set", StringUtil.RTrim( Combo_residentpackageid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPACKAGEID_Enabled", StringUtil.BoolToStr( Combo_residentpackageid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPACKAGEID_Allowmultipleselection", StringUtil.BoolToStr( Combo_residentpackageid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPACKAGEID_Includeonlyselectedoption", StringUtil.BoolToStr( Combo_residentpackageid_Includeonlyselectedoption));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPACKAGEID_Emptyitem", StringUtil.BoolToStr( Combo_residentpackageid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPACKAGEID_Multiplevaluestype", StringUtil.RTrim( Combo_residentpackageid_Multiplevaluestype));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKINDIVIDUALPHONECODE_Cls", StringUtil.RTrim( Combo_networkindividualphonecode_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKINDIVIDUALPHONECODE_Selectedvalue_set", StringUtil.RTrim( Combo_networkindividualphonecode_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKINDIVIDUALPHONECODE_Selectedtext_set", StringUtil.RTrim( Combo_networkindividualphonecode_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKINDIVIDUALPHONECODE_Emptyitem", StringUtil.BoolToStr( Combo_networkindividualphonecode_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKINDIVIDUALPHONECODE_Htmltemplate", StringUtil.RTrim( Combo_networkindividualphonecode_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKINDIVIDUALHOMEPHONECODE_Cls", StringUtil.RTrim( Combo_networkindividualhomephonecode_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKINDIVIDUALHOMEPHONECODE_Selectedvalue_set", StringUtil.RTrim( Combo_networkindividualhomephonecode_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKINDIVIDUALHOMEPHONECODE_Selectedtext_set", StringUtil.RTrim( Combo_networkindividualhomephonecode_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKINDIVIDUALHOMEPHONECODE_Emptyitem", StringUtil.BoolToStr( Combo_networkindividualhomephonecode_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKINDIVIDUALHOMEPHONECODE_Htmltemplate", StringUtil.RTrim( Combo_networkindividualhomephonecode_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKINDIVIDUALCOUNTRY_Cls", StringUtil.RTrim( Combo_networkindividualcountry_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKINDIVIDUALCOUNTRY_Selectedvalue_set", StringUtil.RTrim( Combo_networkindividualcountry_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKINDIVIDUALCOUNTRY_Selectedtext_set", StringUtil.RTrim( Combo_networkindividualcountry_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKINDIVIDUALCOUNTRY_Enabled", StringUtil.BoolToStr( Combo_networkindividualcountry_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKINDIVIDUALCOUNTRY_Emptyitem", StringUtil.BoolToStr( Combo_networkindividualcountry_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKINDIVIDUALCOUNTRY_Htmltemplate", StringUtil.RTrim( Combo_networkindividualcountry_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabs_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Class", StringUtil.RTrim( Gxuitabspanel_tabs_Class));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_tabs_Historymanagement));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKINDIVIDUALCOUNTRY_Selectedvalue_get", StringUtil.RTrim( Combo_networkindividualcountry_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKINDIVIDUALHOMEPHONECODE_Selectedvalue_get", StringUtil.RTrim( Combo_networkindividualhomephonecode_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKINDIVIDUALPHONECODE_Selectedvalue_get", StringUtil.RTrim( Combo_networkindividualphonecode_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPACKAGEID_Selectedvalue_get", StringUtil.RTrim( Combo_residentpackageid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTTYPEID_Selectedvalue_get", StringUtil.RTrim( Combo_residenttypeid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTCOUNTRY_Selectedvalue_get", StringUtil.RTrim( Combo_residentcountry_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTHOMEPHONECODE_Selectedvalue_get", StringUtil.RTrim( Combo_residenthomephonecode_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPHONECODE_Selectedvalue_get", StringUtil.RTrim( Combo_residentphonecode_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTTYPEID_Selectedvalue_get", StringUtil.RTrim( Combo_residenttypeid_Selectedvalue_get));
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
            WEBX2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTBX2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wp_createresidentandnetwork.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV33ResidentId.ToString()) + "," + UrlEncode(AV34LocationId.ToString()) + "," + UrlEncode(AV35OrganisationId.ToString());
         return formatLink("wp_createresidentandnetwork.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WP_CreateResidentAndNetwork" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WP_Create Resident And Network", "") ;
      }

      protected void WBBX0( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGxuitabspanel_tabs.SetProperty("PageCount", Gxuitabspanel_tabs_Pagecount);
            ucGxuitabspanel_tabs.SetProperty("Class", Gxuitabspanel_tabs_Class);
            ucGxuitabspanel_tabs.SetProperty("HistoryManagement", Gxuitabspanel_tabs_Historymanagement);
            ucGxuitabspanel_tabs.Render(context, "tab", Gxuitabspanel_tabs_Internalname, "GXUITABSPANEL_TABSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabgeneral_title_Internalname, context.GetMessage( "General", ""), "", "", lblTabgeneral_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WP_CreateResidentAndNetwork.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "tabGeneral") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpResidentinfogroup_Internalname, grpResidentinfogroup_Caption, 1, 0, "px", 0, "px", "Group", "", "HLP_WP_CreateResidentAndNetwork.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable9_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavResidentsalutation_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavResidentsalutation_Internalname, context.GetMessage( "Salutation", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavResidentsalutation, cmbavResidentsalutation_Internalname, StringUtil.RTrim( AV36ResidentSalutation), 1, cmbavResidentsalutation_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavResidentsalutation.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "", true, 0, "HLP_WP_CreateResidentAndNetwork.htm");
            cmbavResidentsalutation.CurrentValue = StringUtil.RTrim( AV36ResidentSalutation);
            AssignProp("", false, cmbavResidentsalutation_Internalname, "Values", (string)(cmbavResidentsalutation.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divResidenttitle_cell_Internalname, 1, 0, "px", 0, "px", divResidenttitle_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavResidenttitle_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidenttitle_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidenttitle_Internalname, context.GetMessage( "Title", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidenttitle_Internalname, AV69ResidentTitle, StringUtil.RTrim( context.localUtil.Format( AV69ResidentTitle, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "Please specify salutation", ""), edtavResidenttitle_Jsonclick, 0, "Attribute", "", "", "", "", edtavResidenttitle_Visible, edtavResidenttitle_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentgivenname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentgivenname_Internalname, context.GetMessage( "First Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentgivenname_Internalname, AV37ResidentGivenName, StringUtil.RTrim( context.localUtil.Format( AV37ResidentGivenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentgivenname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentgivenname_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentlastname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentlastname_Internalname, context.GetMessage( "Last Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentlastname_Internalname, AV38ResidentLastName, StringUtil.RTrim( context.localUtil.Format( AV38ResidentLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentlastname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentlastname_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavResidentgender_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavResidentgender_Internalname, context.GetMessage( "Gender", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavResidentgender, cmbavResidentgender_Internalname, StringUtil.RTrim( AV40ResidentGender), 1, cmbavResidentgender_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavResidentgender.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_WP_CreateResidentAndNetwork.htm");
            cmbavResidentgender.CurrentValue = StringUtil.RTrim( AV40ResidentGender);
            AssignProp("", false, cmbavResidentgender_Internalname, "Values", (string)(cmbavResidentgender.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentbirthdate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentbirthdate_Internalname, context.GetMessage( "Birth Date", ""), "col-sm-4 AttributeDateLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavResidentbirthdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavResidentbirthdate_Internalname, context.localUtil.Format(AV41ResidentBirthDate, "99/99/9999"), context.localUtil.Format( AV41ResidentBirthDate, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentbirthdate_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavResidentbirthdate_Enabled, 1, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WP_CreateResidentAndNetwork.htm");
            GxWebStd.gx_bitmap( context, edtavResidentbirthdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavResidentbirthdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WP_CreateResidentAndNetwork.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentemail_Internalname, context.GetMessage( "Email", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentemail_Internalname, AV42ResidentEmail, StringUtil.RTrim( context.localUtil.Format( AV42ResidentEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentemail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentemail_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divPhonenumber_Internalname, divPhonenumber_Visible, 0, "px", 0, "px", "CellMarginBottom10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPhonelabel_Internalname, context.GetMessage( "Mobile Phone", ""), "", "", lblPhonelabel_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WP_CreateResidentAndNetwork.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable17_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable18_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 PhoneLabel ExtendedComboCell", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_residentphonecode.SetProperty("Caption", Combo_residentphonecode_Caption);
            ucCombo_residentphonecode.SetProperty("Cls", Combo_residentphonecode_Cls);
            ucCombo_residentphonecode.SetProperty("EmptyItem", Combo_residentphonecode_Emptyitem);
            ucCombo_residentphonecode.SetProperty("DropDownOptionsTitleSettingsIcons", AV54DDO_TitleSettingsIcons);
            ucCombo_residentphonecode.SetProperty("DropDownOptionsData", AV67ResidentPhoneCode_Data);
            ucCombo_residentphonecode.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_residentphonecode_Internalname, "COMBO_RESIDENTPHONECODEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentphonenumber_Internalname, context.GetMessage( "Resident Phone Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentphonenumber_Internalname, AV50ResidentPhoneNumber, StringUtil.RTrim( context.localUtil.Format( AV50ResidentPhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentphonenumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentphonenumber_Enabled, 1, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divHomephonenumber_Internalname, divHomephonenumber_Visible, 0, "px", 0, "px", "CellMarginBottom10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPhone_Internalname, context.GetMessage( "Home Phone", ""), "", "", lblPhone_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WP_CreateResidentAndNetwork.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable15_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable16_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 PhoneLabel ExtendedComboCell", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_residenthomephonecode.SetProperty("Caption", Combo_residenthomephonecode_Caption);
            ucCombo_residenthomephonecode.SetProperty("Cls", Combo_residenthomephonecode_Cls);
            ucCombo_residenthomephonecode.SetProperty("EmptyItem", Combo_residenthomephonecode_Emptyitem);
            ucCombo_residenthomephonecode.SetProperty("DropDownOptionsTitleSettingsIcons", AV54DDO_TitleSettingsIcons);
            ucCombo_residenthomephonecode.SetProperty("DropDownOptionsData", AV65ResidentHomePhoneCode_Data);
            ucCombo_residenthomephonecode.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_residenthomephonecode_Internalname, "COMBO_RESIDENTHOMEPHONECODEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidenthomephonenumber_Internalname, context.GetMessage( "Resident Home Phone Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidenthomephonenumber_Internalname, AV48ResidentHomePhoneNumber, StringUtil.RTrim( context.localUtil.Format( AV48ResidentHomePhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidenthomephonenumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidenthomephonenumber_Enabled, 1, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
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
            GxWebStd.gx_div_start( context, divResidentphone_cell_Internalname, 1, 0, "px", 0, "px", divResidentphone_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavResidentphone_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentphone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentphone_Internalname, context.GetMessage( "Mobile Phone", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentphone_Internalname, StringUtil.RTrim( AV43ResidentPhone), StringUtil.RTrim( context.localUtil.Format( AV43ResidentPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentphone_Jsonclick, 0, "Attribute", "", "", "", "", edtavResidentphone_Visible, edtavResidentphone_Enabled, 1, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divResidenthomephone_cell_Internalname, 1, 0, "px", 0, "px", divResidenthomephone_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavResidenthomephone_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidenthomephone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidenthomephone_Internalname, context.GetMessage( "Home Phone", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidenthomephone_Internalname, StringUtil.RTrim( AV44ResidentHomePhone), StringUtil.RTrim( context.localUtil.Format( AV44ResidentHomePhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidenthomephone_Jsonclick, 0, "Attribute", "", "", "", "", edtavResidenthomephone_Visible, edtavResidenthomephone_Enabled, 1, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentbsnnumber_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentbsnnumber_Internalname, context.GetMessage( "BSN Number", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentbsnnumber_Internalname, AV46ResidentBsnNumber, StringUtil.RTrim( context.localUtil.Format( AV46ResidentBsnNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,108);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentbsnnumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentbsnnumber_Enabled, 1, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable10_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup12_Internalname, context.GetMessage( "Address Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WP_CreateResidentAndNetwork.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable11_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentaddressline1_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentaddressline1_Internalname, context.GetMessage( "Address Line 1", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentaddressline1_Internalname, AV28ResidentAddressLine1, StringUtil.RTrim( context.localUtil.Format( AV28ResidentAddressLine1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,119);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentaddressline1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentaddressline1_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentaddressline2_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentaddressline2_Internalname, context.GetMessage( "Address Line 2", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentaddressline2_Internalname, AV29ResidentAddressLine2, StringUtil.RTrim( context.localUtil.Format( AV29ResidentAddressLine2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,124);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentaddressline2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentaddressline2_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentzipcode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentzipcode_Internalname, context.GetMessage( "Zip Code", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentzipcode_Internalname, AV30ResidentZipCode, StringUtil.RTrim( context.localUtil.Format( AV30ResidentZipCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,129);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentzipcode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentzipcode_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentcity_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentcity_Internalname, context.GetMessage( "City", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentcity_Internalname, AV31ResidentCity, StringUtil.RTrim( context.localUtil.Format( AV31ResidentCity, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,134);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentcity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentcity_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedresidentcountry_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_residentcountry_Internalname, context.GetMessage( "Country", ""), "", "", lblTextblockcombo_residentcountry_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_CreateResidentAndNetwork.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_residentcountry.SetProperty("Caption", Combo_residentcountry_Caption);
            ucCombo_residentcountry.SetProperty("Cls", Combo_residentcountry_Cls);
            ucCombo_residentcountry.SetProperty("EmptyItem", Combo_residentcountry_Emptyitem);
            ucCombo_residentcountry.SetProperty("DropDownOptionsTitleSettingsIcons", AV54DDO_TitleSettingsIcons);
            ucCombo_residentcountry.SetProperty("DropDownOptionsData", AV63ResidentCountry_Data);
            ucCombo_residentcountry.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_residentcountry_Internalname, "COMBO_RESIDENTCOUNTRYContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup14_Internalname, context.GetMessage( "Provisioning Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WP_CreateResidentAndNetwork.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable13_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedresidenttypeid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_residenttypeid_Internalname, lblTextblockcombo_residenttypeid_Caption, "", "", lblTextblockcombo_residenttypeid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_CreateResidentAndNetwork.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_residenttypeid.SetProperty("Caption", Combo_residenttypeid_Caption);
            ucCombo_residenttypeid.SetProperty("Cls", Combo_residenttypeid_Cls);
            ucCombo_residenttypeid.SetProperty("EmptyItem", Combo_residenttypeid_Emptyitem);
            ucCombo_residenttypeid.SetProperty("DropDownOptionsData", AV61ResidentTypeId_Data);
            ucCombo_residenttypeid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_residenttypeid_Internalname, "COMBO_RESIDENTTYPEIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedresidentpackageid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_residentpackageid_Internalname, context.GetMessage( "Groups", ""), "", "", lblTextblockcombo_residentpackageid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_CreateResidentAndNetwork.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_residentpackageid.SetProperty("Caption", Combo_residentpackageid_Caption);
            ucCombo_residentpackageid.SetProperty("Cls", Combo_residentpackageid_Cls);
            ucCombo_residentpackageid.SetProperty("AllowMultipleSelection", Combo_residentpackageid_Allowmultipleselection);
            ucCombo_residentpackageid.SetProperty("IncludeOnlySelectedOption", Combo_residentpackageid_Includeonlyselectedoption);
            ucCombo_residentpackageid.SetProperty("EmptyItem", Combo_residentpackageid_Emptyitem);
            ucCombo_residentpackageid.SetProperty("MultipleValuesType", Combo_residentpackageid_Multiplevaluestype);
            ucCombo_residentpackageid.SetProperty("DropDownOptionsTitleSettingsIcons", AV54DDO_TitleSettingsIcons);
            ucCombo_residentpackageid.SetProperty("DropDownOptionsData", AV62ResidentPackageId_Data);
            ucCombo_residentpackageid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_residentpackageid_Internalname, "COMBO_RESIDENTPACKAGEIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabnextofkin_title_Internalname, context.GetMessage( "Next of Kin", ""), "", "", lblTabnextofkin_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WP_CreateResidentAndNetwork.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabNextOfKin") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpNextofkininfogroup_Internalname, context.GetMessage( "Next of Kin Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WP_CreateResidentAndNetwork.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavNetworkindividualsalutation_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavNetworkindividualsalutation_Internalname, context.GetMessage( "Salutation", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 179,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavNetworkindividualsalutation, cmbavNetworkindividualsalutation_Internalname, StringUtil.RTrim( AV12NetworkIndividualSalutation), 1, cmbavNetworkindividualsalutation_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavNetworkindividualsalutation.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,179);\"", "", true, 0, "HLP_WP_CreateResidentAndNetwork.htm");
            cmbavNetworkindividualsalutation.CurrentValue = StringUtil.RTrim( AV12NetworkIndividualSalutation);
            AssignProp("", false, cmbavNetworkindividualsalutation_Internalname, "Values", (string)(cmbavNetworkindividualsalutation.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divNetworkindividualtitle_cell_Internalname, 1, 0, "px", 0, "px", divNetworkindividualtitle_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavNetworkindividualtitle_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNetworkindividualtitle_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNetworkindividualtitle_Internalname, context.GetMessage( "Title", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 184,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkindividualtitle_Internalname, AV88NetworkIndividualTitle, StringUtil.RTrim( context.localUtil.Format( AV88NetworkIndividualTitle, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,184);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "Please specify salutation", ""), edtavNetworkindividualtitle_Jsonclick, 0, "Attribute", "", "", "", "", edtavNetworkindividualtitle_Visible, edtavNetworkindividualtitle_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNetworkindividualgivenname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNetworkindividualgivenname_Internalname, context.GetMessage( "First Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 189,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkindividualgivenname_Internalname, AV13NetworkIndividualGivenName, StringUtil.RTrim( context.localUtil.Format( AV13NetworkIndividualGivenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,189);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNetworkindividualgivenname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNetworkindividualgivenname_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNetworkindividuallastname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNetworkindividuallastname_Internalname, context.GetMessage( "Last Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 194,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkindividuallastname_Internalname, AV14NetworkIndividualLastName, StringUtil.RTrim( context.localUtil.Format( AV14NetworkIndividualLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,194);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNetworkindividuallastname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNetworkindividuallastname_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavNetworkindividualgender_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavNetworkindividualgender_Internalname, context.GetMessage( "Gender", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 199,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavNetworkindividualgender, cmbavNetworkindividualgender_Internalname, StringUtil.RTrim( AV15NetworkIndividualGender), 1, cmbavNetworkindividualgender_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavNetworkindividualgender.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,199);\"", "", true, 0, "HLP_WP_CreateResidentAndNetwork.htm");
            cmbavNetworkindividualgender.CurrentValue = StringUtil.RTrim( AV15NetworkIndividualGender);
            AssignProp("", false, cmbavNetworkindividualgender_Internalname, "Values", (string)(cmbavNetworkindividualgender.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavNetworkindividualrelationship_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavNetworkindividualrelationship_Internalname, context.GetMessage( "Relationship", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 204,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavNetworkindividualrelationship, cmbavNetworkindividualrelationship_Internalname, StringUtil.RTrim( AV79NetworkIndividualRelationship), 1, cmbavNetworkindividualrelationship_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavNetworkindividualrelationship.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,204);\"", "", true, 0, "HLP_WP_CreateResidentAndNetwork.htm");
            cmbavNetworkindividualrelationship.CurrentValue = StringUtil.RTrim( AV79NetworkIndividualRelationship);
            AssignProp("", false, cmbavNetworkindividualrelationship_Internalname, "Values", (string)(cmbavNetworkindividualrelationship.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNetworkindividualemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNetworkindividualemail_Internalname, context.GetMessage( "Email", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 209,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkindividualemail_Internalname, AV16NetworkIndividualEmail, StringUtil.RTrim( context.localUtil.Format( AV16NetworkIndividualEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,209);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNetworkindividualemail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNetworkindividualemail_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divPhonenumber1_Internalname, divPhonenumber1_Visible, 0, "px", 0, "px", "CellMarginBottom10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPhonelabel2_Internalname, context.GetMessage( "Mobile Phone", ""), "", "", lblPhonelabel2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WP_CreateResidentAndNetwork.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable7_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable8_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 PhoneLabel ExtendedComboCell", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_networkindividualphonecode.SetProperty("Caption", Combo_networkindividualphonecode_Caption);
            ucCombo_networkindividualphonecode.SetProperty("Cls", Combo_networkindividualphonecode_Cls);
            ucCombo_networkindividualphonecode.SetProperty("EmptyItem", Combo_networkindividualphonecode_Emptyitem);
            ucCombo_networkindividualphonecode.SetProperty("DropDownOptionsTitleSettingsIcons", AV54DDO_TitleSettingsIcons);
            ucCombo_networkindividualphonecode.SetProperty("DropDownOptionsData", AV59NetworkIndividualPhoneCode_Data);
            ucCombo_networkindividualphonecode.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_networkindividualphonecode_Internalname, "COMBO_NETWORKINDIVIDUALPHONECODEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNetworkindividualphonenumber_Internalname, context.GetMessage( "Network Individual Phone Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 226,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkindividualphonenumber_Internalname, AV22NetworkIndividualPhoneNumber, StringUtil.RTrim( context.localUtil.Format( AV22NetworkIndividualPhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,226);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNetworkindividualphonenumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNetworkindividualphonenumber_Enabled, 1, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divHomephonenumber1_Internalname, divHomephonenumber1_Visible, 0, "px", 0, "px", "CellMarginBottom10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPhone2_Internalname, context.GetMessage( "Home Phone", ""), "", "", lblPhone2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WP_CreateResidentAndNetwork.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable5_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable6_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 PhoneLabel ExtendedComboCell", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_networkindividualhomephonecode.SetProperty("Caption", Combo_networkindividualhomephonecode_Caption);
            ucCombo_networkindividualhomephonecode.SetProperty("Cls", Combo_networkindividualhomephonecode_Cls);
            ucCombo_networkindividualhomephonecode.SetProperty("EmptyItem", Combo_networkindividualhomephonecode_Emptyitem);
            ucCombo_networkindividualhomephonecode.SetProperty("DropDownOptionsTitleSettingsIcons", AV54DDO_TitleSettingsIcons);
            ucCombo_networkindividualhomephonecode.SetProperty("DropDownOptionsData", AV57NetworkIndividualHomePhoneCode_Data);
            ucCombo_networkindividualhomephonecode.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_networkindividualhomephonecode_Internalname, "COMBO_NETWORKINDIVIDUALHOMEPHONECODEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNetworkindividualhomephonenumber_Internalname, context.GetMessage( "Network Individual Home Phone Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 243,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkindividualhomephonenumber_Internalname, AV20NetworkIndividualHomePhoneNumber, StringUtil.RTrim( context.localUtil.Format( AV20NetworkIndividualHomePhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,243);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNetworkindividualhomephonenumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNetworkindividualhomephonenumber_Enabled, 1, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
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
            GxWebStd.gx_div_start( context, divNetworkindividualphone_cell_Internalname, 1, 0, "px", 0, "px", divNetworkindividualphone_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavNetworkindividualphone_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNetworkindividualphone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNetworkindividualphone_Internalname, context.GetMessage( "Mobile Phone", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 248,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkindividualphone_Internalname, StringUtil.RTrim( AV17NetworkIndividualPhone), StringUtil.RTrim( context.localUtil.Format( AV17NetworkIndividualPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,248);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNetworkindividualphone_Jsonclick, 0, "Attribute", "", "", "", "", edtavNetworkindividualphone_Visible, edtavNetworkindividualphone_Enabled, 1, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divNetworkindividualhomephone_cell_Internalname, 1, 0, "px", 0, "px", divNetworkindividualhomephone_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavNetworkindividualhomephone_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNetworkindividualhomephone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNetworkindividualhomephone_Internalname, context.GetMessage( "Home Phone", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 253,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkindividualhomephone_Internalname, StringUtil.RTrim( AV18NetworkIndividualHomePhone), StringUtil.RTrim( context.localUtil.Format( AV18NetworkIndividualHomePhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,253);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNetworkindividualhomephone_Jsonclick, 0, "Attribute", "", "", "", "", edtavNetworkindividualhomephone_Visible, edtavNetworkindividualhomephone_Enabled, 1, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNetworkindividualbsnnumber_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNetworkindividualbsnnumber_Internalname, context.GetMessage( "BSN Number", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 258,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkindividualbsnnumber_Internalname, AV19NetworkIndividualBsnNumber, StringUtil.RTrim( context.localUtil.Format( AV19NetworkIndividualBsnNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,258);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNetworkindividualbsnnumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNetworkindividualbsnnumber_Enabled, 1, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup4_Internalname, context.GetMessage( "Address Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WP_CreateResidentAndNetwork.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNetworkindividualaddressline1_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNetworkindividualaddressline1_Internalname, context.GetMessage( "Address Line 1", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 269,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkindividualaddressline1_Internalname, AV6NetworkIndividualAddressLine1, StringUtil.RTrim( context.localUtil.Format( AV6NetworkIndividualAddressLine1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,269);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNetworkindividualaddressline1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNetworkindividualaddressline1_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNetworkindividualaddressline2_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNetworkindividualaddressline2_Internalname, context.GetMessage( "Address Line 2", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 274,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkindividualaddressline2_Internalname, AV7NetworkIndividualAddressLine2, StringUtil.RTrim( context.localUtil.Format( AV7NetworkIndividualAddressLine2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,274);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNetworkindividualaddressline2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNetworkindividualaddressline2_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNetworkindividualzipcode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNetworkindividualzipcode_Internalname, context.GetMessage( "Zip Code", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 279,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkindividualzipcode_Internalname, AV8NetworkIndividualZipCode, StringUtil.RTrim( context.localUtil.Format( AV8NetworkIndividualZipCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,279);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNetworkindividualzipcode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNetworkindividualzipcode_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNetworkindividualcity_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNetworkindividualcity_Internalname, context.GetMessage( "City", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 284,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkindividualcity_Internalname, AV9NetworkIndividualCity, StringUtil.RTrim( context.localUtil.Format( AV9NetworkIndividualCity, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,284);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNetworkindividualcity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNetworkindividualcity_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittednetworkindividualcountry_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_networkindividualcountry_Internalname, context.GetMessage( "Country", ""), "", "", lblTextblockcombo_networkindividualcountry_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_CreateResidentAndNetwork.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_networkindividualcountry.SetProperty("Caption", Combo_networkindividualcountry_Caption);
            ucCombo_networkindividualcountry.SetProperty("Cls", Combo_networkindividualcountry_Cls);
            ucCombo_networkindividualcountry.SetProperty("EmptyItem", Combo_networkindividualcountry_Emptyitem);
            ucCombo_networkindividualcountry.SetProperty("DropDownOptionsTitleSettingsIcons", AV54DDO_TitleSettingsIcons);
            ucCombo_networkindividualcountry.SetProperty("DropDownOptionsData", AV53NetworkIndividualCountry_Data);
            ucCombo_networkindividualcountry.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_networkindividualcountry_Internalname, "COMBO_NETWORKINDIVIDUALCOUNTRYContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 297,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_CreateResidentAndNetwork.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 299,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtncancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_CreateResidentAndNetwork.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 303,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentphonecode_Internalname, AV51ResidentPhoneCode, StringUtil.RTrim( context.localUtil.Format( AV51ResidentPhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,303);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentphonecode_Jsonclick, 0, "Attribute", "", "", "", "", edtavResidentphonecode_Visible, edtavResidentphonecode_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 304,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidenthomephonecode_Internalname, AV49ResidentHomePhoneCode, StringUtil.RTrim( context.localUtil.Format( AV49ResidentHomePhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,304);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidenthomephonecode_Jsonclick, 0, "Attribute", "", "", "", "", edtavResidenthomephonecode_Visible, edtavResidenthomephonecode_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 305,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentcountry_Internalname, AV32ResidentCountry, StringUtil.RTrim( context.localUtil.Format( AV32ResidentCountry, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,305);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentcountry_Jsonclick, 0, "Attribute", "", "", "", "", edtavResidentcountry_Visible, edtavResidentcountry_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 306,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidenttypeid_Internalname, AV24ResidentTypeId.ToString(), AV24ResidentTypeId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,306);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidenttypeid_Jsonclick, 0, "Attribute", "", "", "", "", edtavResidenttypeid_Visible, edtavResidenttypeid_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_CreateResidentAndNetwork.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 307,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkindividualphonecode_Internalname, AV23NetworkIndividualPhoneCode, StringUtil.RTrim( context.localUtil.Format( AV23NetworkIndividualPhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,307);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNetworkindividualphonecode_Jsonclick, 0, "Attribute", "", "", "", "", edtavNetworkindividualphonecode_Visible, edtavNetworkindividualphonecode_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 308,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkindividualhomephonecode_Internalname, AV21NetworkIndividualHomePhoneCode, StringUtil.RTrim( context.localUtil.Format( AV21NetworkIndividualHomePhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,308);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNetworkindividualhomephonecode_Jsonclick, 0, "Attribute", "", "", "", "", edtavNetworkindividualhomephonecode_Visible, edtavNetworkindividualhomephonecode_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 309,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkindividualcountry_Internalname, AV10NetworkIndividualCountry, StringUtil.RTrim( context.localUtil.Format( AV10NetworkIndividualCountry, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,309);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNetworkindividualcountry_Jsonclick, 0, "Attribute", "", "", "", "", edtavNetworkindividualcountry_Visible, edtavNetworkindividualcountry_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 310,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkindividualid_Internalname, AV11NetworkIndividualId.ToString(), AV11NetworkIndividualId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,310);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNetworkindividualid_Jsonclick, 0, "Attribute", "", "", "", "", edtavNetworkindividualid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_CreateResidentAndNetwork.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 311,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSg_organisationid_Internalname, AV26SG_OrganisationId.ToString(), AV26SG_OrganisationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,311);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSg_organisationid_Jsonclick, 0, "Attribute", "", "", "", "", edtavSg_organisationid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_CreateResidentAndNetwork.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 312,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSg_locationid_Internalname, AV27SG_LocationId.ToString(), AV27SG_LocationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,312);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSg_locationid_Jsonclick, 0, "Attribute", "", "", "", "", edtavSg_locationid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_CreateResidentAndNetwork.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavResidentid_Internalname, AV33ResidentId.ToString(), AV33ResidentId.ToString(), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentid_Jsonclick, 0, "Attribute", "", "", "", "", edtavResidentid_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_CreateResidentAndNetwork.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavLocationid_Internalname, AV34LocationId.ToString(), AV34LocationId.ToString(), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLocationid_Jsonclick, 0, "Attribute", "", "", "", "", edtavLocationid_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_CreateResidentAndNetwork.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavOrganisationid_Internalname, AV35OrganisationId.ToString(), AV35OrganisationId.ToString(), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOrganisationid_Jsonclick, 0, "Attribute", "", "", "", "", edtavOrganisationid_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_CreateResidentAndNetwork.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 316,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentinitials_Internalname, StringUtil.RTrim( AV39ResidentInitials), StringUtil.RTrim( context.localUtil.Format( AV39ResidentInitials, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,316);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentinitials_Jsonclick, 0, "Attribute", "", "", "", "", edtavResidentinitials_Visible, 1, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 317,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentguid_Internalname, AV45ResidentGUID, StringUtil.RTrim( context.localUtil.Format( AV45ResidentGUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,317);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentguid_Jsonclick, 0, "Attribute", "", "", "", "", edtavResidentguid_Visible, edtavResidentguid_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetwork.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 318,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMedicalindicationid_Internalname, AV47MedicalIndicationId.ToString(), AV47MedicalIndicationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,318);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMedicalindicationid_Jsonclick, 0, "Attribute", "", "", "", "", edtavMedicalindicationid_Visible, edtavMedicalindicationid_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_CreateResidentAndNetwork.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void STARTBX2( )
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
         Form.Meta.addItem("description", context.GetMessage( "WP_Create Resident And Network", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPBX0( ) ;
      }

      protected void WSBX2( )
      {
         STARTBX2( ) ;
         EVTBX2( ) ;
      }

      protected void EVTBX2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_RESIDENTTYPEID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_residenttypeid.Onoptionclicked */
                              E11BX2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E12BX2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E13BX2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E14BX2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E15BX2 ();
                              /* No code required for Cancel button. It is implemented as the Reset button. */
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
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WEBX2( )
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

      protected void PABX2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_createresidentandnetwork.aspx")), "wp_createresidentandnetwork.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_createresidentandnetwork.aspx")))) ;
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
                  gxfirstwebparm = GetFirstPar( "Mode");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     Gx_mode = gxfirstwebparm;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV33ResidentId = StringUtil.StrToGuid( GetPar( "ResidentId"));
                        AssignAttri("", false, "AV33ResidentId", AV33ResidentId.ToString());
                        GxWebStd.gx_hidden_field( context, "gxhash_vRESIDENTID", GetSecureSignedToken( "", AV33ResidentId, context));
                        AV34LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
                        AssignAttri("", false, "AV34LocationId", AV34LocationId.ToString());
                        GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", AV34LocationId, context));
                        AV35OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                        AssignAttri("", false, "AV35OrganisationId", AV35OrganisationId.ToString());
                        GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV35OrganisationId, context));
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
               GX_FocusControl = cmbavResidentsalutation_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
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
         if ( cmbavResidentsalutation.ItemCount > 0 )
         {
            AV36ResidentSalutation = cmbavResidentsalutation.getValidValue(AV36ResidentSalutation);
            AssignAttri("", false, "AV36ResidentSalutation", AV36ResidentSalutation);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavResidentsalutation.CurrentValue = StringUtil.RTrim( AV36ResidentSalutation);
            AssignProp("", false, cmbavResidentsalutation_Internalname, "Values", cmbavResidentsalutation.ToJavascriptSource(), true);
         }
         if ( cmbavResidentgender.ItemCount > 0 )
         {
            AV40ResidentGender = cmbavResidentgender.getValidValue(AV40ResidentGender);
            AssignAttri("", false, "AV40ResidentGender", AV40ResidentGender);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavResidentgender.CurrentValue = StringUtil.RTrim( AV40ResidentGender);
            AssignProp("", false, cmbavResidentgender_Internalname, "Values", cmbavResidentgender.ToJavascriptSource(), true);
         }
         if ( cmbavNetworkindividualsalutation.ItemCount > 0 )
         {
            AV12NetworkIndividualSalutation = cmbavNetworkindividualsalutation.getValidValue(AV12NetworkIndividualSalutation);
            AssignAttri("", false, "AV12NetworkIndividualSalutation", AV12NetworkIndividualSalutation);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavNetworkindividualsalutation.CurrentValue = StringUtil.RTrim( AV12NetworkIndividualSalutation);
            AssignProp("", false, cmbavNetworkindividualsalutation_Internalname, "Values", cmbavNetworkindividualsalutation.ToJavascriptSource(), true);
         }
         if ( cmbavNetworkindividualgender.ItemCount > 0 )
         {
            AV15NetworkIndividualGender = cmbavNetworkindividualgender.getValidValue(AV15NetworkIndividualGender);
            AssignAttri("", false, "AV15NetworkIndividualGender", AV15NetworkIndividualGender);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavNetworkindividualgender.CurrentValue = StringUtil.RTrim( AV15NetworkIndividualGender);
            AssignProp("", false, cmbavNetworkindividualgender_Internalname, "Values", cmbavNetworkindividualgender.ToJavascriptSource(), true);
         }
         if ( cmbavNetworkindividualrelationship.ItemCount > 0 )
         {
            AV79NetworkIndividualRelationship = cmbavNetworkindividualrelationship.getValidValue(AV79NetworkIndividualRelationship);
            AssignAttri("", false, "AV79NetworkIndividualRelationship", AV79NetworkIndividualRelationship);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavNetworkindividualrelationship.CurrentValue = StringUtil.RTrim( AV79NetworkIndividualRelationship);
            AssignProp("", false, cmbavNetworkindividualrelationship_Internalname, "Values", cmbavNetworkindividualrelationship.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFBX2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFBX2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E13BX2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E15BX2 ();
            WBBX0( ) ;
         }
      }

      protected void send_integrity_lvl_hashesBX2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV85WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV85WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV85WWPContext, context));
         GxWebStd.gx_hidden_field( context, "vRESIDENTTITLEDEFINITION", AV89ResidentTitleDefinition);
         GxWebStd.gx_hidden_field( context, "gxhash_vRESIDENTTITLEDEFINITION", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV89ResidentTitleDefinition, "")), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUPBX0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12BX2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV54DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vRESIDENTPHONECODE_DATA"), AV67ResidentPhoneCode_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vRESIDENTHOMEPHONECODE_DATA"), AV65ResidentHomePhoneCode_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vRESIDENTCOUNTRY_DATA"), AV63ResidentCountry_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vRESIDENTTYPEID_DATA"), AV61ResidentTypeId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vRESIDENTPACKAGEID_DATA"), AV62ResidentPackageId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vNETWORKINDIVIDUALPHONECODE_DATA"), AV59NetworkIndividualPhoneCode_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vNETWORKINDIVIDUALHOMEPHONECODE_DATA"), AV57NetworkIndividualHomePhoneCode_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vNETWORKINDIVIDUALCOUNTRY_DATA"), AV53NetworkIndividualCountry_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vRESIDENTPACKAGEID"), AV25ResidentPackageId);
            /* Read saved values. */
            Gx_mode = cgiGet( "vMODE");
            Combo_residentphonecode_Cls = cgiGet( "COMBO_RESIDENTPHONECODE_Cls");
            Combo_residentphonecode_Selectedvalue_set = cgiGet( "COMBO_RESIDENTPHONECODE_Selectedvalue_set");
            Combo_residentphonecode_Selectedtext_set = cgiGet( "COMBO_RESIDENTPHONECODE_Selectedtext_set");
            Combo_residentphonecode_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTPHONECODE_Emptyitem"));
            Combo_residentphonecode_Htmltemplate = cgiGet( "COMBO_RESIDENTPHONECODE_Htmltemplate");
            Combo_residenthomephonecode_Cls = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Cls");
            Combo_residenthomephonecode_Selectedvalue_set = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Selectedvalue_set");
            Combo_residenthomephonecode_Selectedtext_set = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Selectedtext_set");
            Combo_residenthomephonecode_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Emptyitem"));
            Combo_residenthomephonecode_Htmltemplate = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Htmltemplate");
            Combo_residentcountry_Cls = cgiGet( "COMBO_RESIDENTCOUNTRY_Cls");
            Combo_residentcountry_Selectedvalue_set = cgiGet( "COMBO_RESIDENTCOUNTRY_Selectedvalue_set");
            Combo_residentcountry_Selectedtext_set = cgiGet( "COMBO_RESIDENTCOUNTRY_Selectedtext_set");
            Combo_residentcountry_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTCOUNTRY_Enabled"));
            Combo_residentcountry_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTCOUNTRY_Emptyitem"));
            Combo_residentcountry_Htmltemplate = cgiGet( "COMBO_RESIDENTCOUNTRY_Htmltemplate");
            Combo_residenttypeid_Cls = cgiGet( "COMBO_RESIDENTTYPEID_Cls");
            Combo_residenttypeid_Selectedvalue_set = cgiGet( "COMBO_RESIDENTTYPEID_Selectedvalue_set");
            Combo_residenttypeid_Selectedtext_set = cgiGet( "COMBO_RESIDENTTYPEID_Selectedtext_set");
            Combo_residenttypeid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTTYPEID_Enabled"));
            Combo_residenttypeid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTTYPEID_Emptyitem"));
            Combo_residentpackageid_Cls = cgiGet( "COMBO_RESIDENTPACKAGEID_Cls");
            Combo_residentpackageid_Selectedvalue_set = cgiGet( "COMBO_RESIDENTPACKAGEID_Selectedvalue_set");
            Combo_residentpackageid_Selectedtext_set = cgiGet( "COMBO_RESIDENTPACKAGEID_Selectedtext_set");
            Combo_residentpackageid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTPACKAGEID_Enabled"));
            Combo_residentpackageid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTPACKAGEID_Allowmultipleselection"));
            Combo_residentpackageid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTPACKAGEID_Includeonlyselectedoption"));
            Combo_residentpackageid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTPACKAGEID_Emptyitem"));
            Combo_residentpackageid_Multiplevaluestype = cgiGet( "COMBO_RESIDENTPACKAGEID_Multiplevaluestype");
            Combo_networkindividualphonecode_Cls = cgiGet( "COMBO_NETWORKINDIVIDUALPHONECODE_Cls");
            Combo_networkindividualphonecode_Selectedvalue_set = cgiGet( "COMBO_NETWORKINDIVIDUALPHONECODE_Selectedvalue_set");
            Combo_networkindividualphonecode_Selectedtext_set = cgiGet( "COMBO_NETWORKINDIVIDUALPHONECODE_Selectedtext_set");
            Combo_networkindividualphonecode_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_NETWORKINDIVIDUALPHONECODE_Emptyitem"));
            Combo_networkindividualphonecode_Htmltemplate = cgiGet( "COMBO_NETWORKINDIVIDUALPHONECODE_Htmltemplate");
            Combo_networkindividualhomephonecode_Cls = cgiGet( "COMBO_NETWORKINDIVIDUALHOMEPHONECODE_Cls");
            Combo_networkindividualhomephonecode_Selectedvalue_set = cgiGet( "COMBO_NETWORKINDIVIDUALHOMEPHONECODE_Selectedvalue_set");
            Combo_networkindividualhomephonecode_Selectedtext_set = cgiGet( "COMBO_NETWORKINDIVIDUALHOMEPHONECODE_Selectedtext_set");
            Combo_networkindividualhomephonecode_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_NETWORKINDIVIDUALHOMEPHONECODE_Emptyitem"));
            Combo_networkindividualhomephonecode_Htmltemplate = cgiGet( "COMBO_NETWORKINDIVIDUALHOMEPHONECODE_Htmltemplate");
            Combo_networkindividualcountry_Cls = cgiGet( "COMBO_NETWORKINDIVIDUALCOUNTRY_Cls");
            Combo_networkindividualcountry_Selectedvalue_set = cgiGet( "COMBO_NETWORKINDIVIDUALCOUNTRY_Selectedvalue_set");
            Combo_networkindividualcountry_Selectedtext_set = cgiGet( "COMBO_NETWORKINDIVIDUALCOUNTRY_Selectedtext_set");
            Combo_networkindividualcountry_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_NETWORKINDIVIDUALCOUNTRY_Enabled"));
            Combo_networkindividualcountry_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_NETWORKINDIVIDUALCOUNTRY_Emptyitem"));
            Combo_networkindividualcountry_Htmltemplate = cgiGet( "COMBO_NETWORKINDIVIDUALCOUNTRY_Htmltemplate");
            Gxuitabspanel_tabs_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS_Pagecount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gxuitabspanel_tabs_Class = cgiGet( "GXUITABSPANEL_TABS_Class");
            Gxuitabspanel_tabs_Historymanagement = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS_Historymanagement"));
            Combo_residenttypeid_Selectedvalue_get = cgiGet( "COMBO_RESIDENTTYPEID_Selectedvalue_get");
            /* Read variables values. */
            cmbavResidentsalutation.CurrentValue = cgiGet( cmbavResidentsalutation_Internalname);
            AV36ResidentSalutation = cgiGet( cmbavResidentsalutation_Internalname);
            AssignAttri("", false, "AV36ResidentSalutation", AV36ResidentSalutation);
            AV69ResidentTitle = cgiGet( edtavResidenttitle_Internalname);
            AssignAttri("", false, "AV69ResidentTitle", AV69ResidentTitle);
            AV37ResidentGivenName = cgiGet( edtavResidentgivenname_Internalname);
            AssignAttri("", false, "AV37ResidentGivenName", AV37ResidentGivenName);
            AV38ResidentLastName = cgiGet( edtavResidentlastname_Internalname);
            AssignAttri("", false, "AV38ResidentLastName", AV38ResidentLastName);
            cmbavResidentgender.CurrentValue = cgiGet( cmbavResidentgender_Internalname);
            AV40ResidentGender = cgiGet( cmbavResidentgender_Internalname);
            AssignAttri("", false, "AV40ResidentGender", AV40ResidentGender);
            if ( context.localUtil.VCDate( cgiGet( edtavResidentbirthdate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Resident Birth Date", "")}), 1, "vRESIDENTBIRTHDATE");
               GX_FocusControl = edtavResidentbirthdate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV41ResidentBirthDate = DateTime.MinValue;
               AssignAttri("", false, "AV41ResidentBirthDate", context.localUtil.Format(AV41ResidentBirthDate, "99/99/9999"));
            }
            else
            {
               AV41ResidentBirthDate = context.localUtil.CToD( cgiGet( edtavResidentbirthdate_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV41ResidentBirthDate", context.localUtil.Format(AV41ResidentBirthDate, "99/99/9999"));
            }
            AV42ResidentEmail = cgiGet( edtavResidentemail_Internalname);
            AssignAttri("", false, "AV42ResidentEmail", AV42ResidentEmail);
            AV50ResidentPhoneNumber = cgiGet( edtavResidentphonenumber_Internalname);
            AssignAttri("", false, "AV50ResidentPhoneNumber", AV50ResidentPhoneNumber);
            AV48ResidentHomePhoneNumber = cgiGet( edtavResidenthomephonenumber_Internalname);
            AssignAttri("", false, "AV48ResidentHomePhoneNumber", AV48ResidentHomePhoneNumber);
            AV43ResidentPhone = cgiGet( edtavResidentphone_Internalname);
            AssignAttri("", false, "AV43ResidentPhone", AV43ResidentPhone);
            AV44ResidentHomePhone = cgiGet( edtavResidenthomephone_Internalname);
            AssignAttri("", false, "AV44ResidentHomePhone", AV44ResidentHomePhone);
            AV46ResidentBsnNumber = cgiGet( edtavResidentbsnnumber_Internalname);
            AssignAttri("", false, "AV46ResidentBsnNumber", AV46ResidentBsnNumber);
            AV28ResidentAddressLine1 = cgiGet( edtavResidentaddressline1_Internalname);
            AssignAttri("", false, "AV28ResidentAddressLine1", AV28ResidentAddressLine1);
            AV29ResidentAddressLine2 = cgiGet( edtavResidentaddressline2_Internalname);
            AssignAttri("", false, "AV29ResidentAddressLine2", AV29ResidentAddressLine2);
            AV30ResidentZipCode = cgiGet( edtavResidentzipcode_Internalname);
            AssignAttri("", false, "AV30ResidentZipCode", AV30ResidentZipCode);
            AV31ResidentCity = cgiGet( edtavResidentcity_Internalname);
            AssignAttri("", false, "AV31ResidentCity", AV31ResidentCity);
            cmbavNetworkindividualsalutation.CurrentValue = cgiGet( cmbavNetworkindividualsalutation_Internalname);
            AV12NetworkIndividualSalutation = cgiGet( cmbavNetworkindividualsalutation_Internalname);
            AssignAttri("", false, "AV12NetworkIndividualSalutation", AV12NetworkIndividualSalutation);
            AV88NetworkIndividualTitle = cgiGet( edtavNetworkindividualtitle_Internalname);
            AssignAttri("", false, "AV88NetworkIndividualTitle", AV88NetworkIndividualTitle);
            AV13NetworkIndividualGivenName = cgiGet( edtavNetworkindividualgivenname_Internalname);
            AssignAttri("", false, "AV13NetworkIndividualGivenName", AV13NetworkIndividualGivenName);
            AV14NetworkIndividualLastName = cgiGet( edtavNetworkindividuallastname_Internalname);
            AssignAttri("", false, "AV14NetworkIndividualLastName", AV14NetworkIndividualLastName);
            cmbavNetworkindividualgender.CurrentValue = cgiGet( cmbavNetworkindividualgender_Internalname);
            AV15NetworkIndividualGender = cgiGet( cmbavNetworkindividualgender_Internalname);
            AssignAttri("", false, "AV15NetworkIndividualGender", AV15NetworkIndividualGender);
            cmbavNetworkindividualrelationship.CurrentValue = cgiGet( cmbavNetworkindividualrelationship_Internalname);
            AV79NetworkIndividualRelationship = cgiGet( cmbavNetworkindividualrelationship_Internalname);
            AssignAttri("", false, "AV79NetworkIndividualRelationship", AV79NetworkIndividualRelationship);
            AV16NetworkIndividualEmail = cgiGet( edtavNetworkindividualemail_Internalname);
            AssignAttri("", false, "AV16NetworkIndividualEmail", AV16NetworkIndividualEmail);
            AV22NetworkIndividualPhoneNumber = cgiGet( edtavNetworkindividualphonenumber_Internalname);
            AssignAttri("", false, "AV22NetworkIndividualPhoneNumber", AV22NetworkIndividualPhoneNumber);
            AV20NetworkIndividualHomePhoneNumber = cgiGet( edtavNetworkindividualhomephonenumber_Internalname);
            AssignAttri("", false, "AV20NetworkIndividualHomePhoneNumber", AV20NetworkIndividualHomePhoneNumber);
            AV17NetworkIndividualPhone = cgiGet( edtavNetworkindividualphone_Internalname);
            AssignAttri("", false, "AV17NetworkIndividualPhone", AV17NetworkIndividualPhone);
            AV18NetworkIndividualHomePhone = cgiGet( edtavNetworkindividualhomephone_Internalname);
            AssignAttri("", false, "AV18NetworkIndividualHomePhone", AV18NetworkIndividualHomePhone);
            AV19NetworkIndividualBsnNumber = cgiGet( edtavNetworkindividualbsnnumber_Internalname);
            AssignAttri("", false, "AV19NetworkIndividualBsnNumber", AV19NetworkIndividualBsnNumber);
            AV6NetworkIndividualAddressLine1 = cgiGet( edtavNetworkindividualaddressline1_Internalname);
            AssignAttri("", false, "AV6NetworkIndividualAddressLine1", AV6NetworkIndividualAddressLine1);
            AV7NetworkIndividualAddressLine2 = cgiGet( edtavNetworkindividualaddressline2_Internalname);
            AssignAttri("", false, "AV7NetworkIndividualAddressLine2", AV7NetworkIndividualAddressLine2);
            AV8NetworkIndividualZipCode = cgiGet( edtavNetworkindividualzipcode_Internalname);
            AssignAttri("", false, "AV8NetworkIndividualZipCode", AV8NetworkIndividualZipCode);
            AV9NetworkIndividualCity = cgiGet( edtavNetworkindividualcity_Internalname);
            AssignAttri("", false, "AV9NetworkIndividualCity", AV9NetworkIndividualCity);
            AV51ResidentPhoneCode = cgiGet( edtavResidentphonecode_Internalname);
            AssignAttri("", false, "AV51ResidentPhoneCode", AV51ResidentPhoneCode);
            AV49ResidentHomePhoneCode = cgiGet( edtavResidenthomephonecode_Internalname);
            AssignAttri("", false, "AV49ResidentHomePhoneCode", AV49ResidentHomePhoneCode);
            AV32ResidentCountry = cgiGet( edtavResidentcountry_Internalname);
            AssignAttri("", false, "AV32ResidentCountry", AV32ResidentCountry);
            if ( StringUtil.StrCmp(cgiGet( edtavResidenttypeid_Internalname), "") == 0 )
            {
               AV24ResidentTypeId = Guid.Empty;
               AssignAttri("", false, "AV24ResidentTypeId", AV24ResidentTypeId.ToString());
            }
            else
            {
               try
               {
                  AV24ResidentTypeId = StringUtil.StrToGuid( cgiGet( edtavResidenttypeid_Internalname));
                  AssignAttri("", false, "AV24ResidentTypeId", AV24ResidentTypeId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vRESIDENTTYPEID");
                  GX_FocusControl = edtavResidenttypeid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            AV23NetworkIndividualPhoneCode = cgiGet( edtavNetworkindividualphonecode_Internalname);
            AssignAttri("", false, "AV23NetworkIndividualPhoneCode", AV23NetworkIndividualPhoneCode);
            AV21NetworkIndividualHomePhoneCode = cgiGet( edtavNetworkindividualhomephonecode_Internalname);
            AssignAttri("", false, "AV21NetworkIndividualHomePhoneCode", AV21NetworkIndividualHomePhoneCode);
            AV10NetworkIndividualCountry = cgiGet( edtavNetworkindividualcountry_Internalname);
            AssignAttri("", false, "AV10NetworkIndividualCountry", AV10NetworkIndividualCountry);
            if ( StringUtil.StrCmp(cgiGet( edtavNetworkindividualid_Internalname), "") == 0 )
            {
               AV11NetworkIndividualId = Guid.Empty;
               AssignAttri("", false, "AV11NetworkIndividualId", AV11NetworkIndividualId.ToString());
            }
            else
            {
               try
               {
                  AV11NetworkIndividualId = StringUtil.StrToGuid( cgiGet( edtavNetworkindividualid_Internalname));
                  AssignAttri("", false, "AV11NetworkIndividualId", AV11NetworkIndividualId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vNETWORKINDIVIDUALID");
                  GX_FocusControl = edtavNetworkindividualid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            if ( StringUtil.StrCmp(cgiGet( edtavSg_organisationid_Internalname), "") == 0 )
            {
               AV26SG_OrganisationId = Guid.Empty;
               AssignAttri("", false, "AV26SG_OrganisationId", AV26SG_OrganisationId.ToString());
            }
            else
            {
               try
               {
                  AV26SG_OrganisationId = StringUtil.StrToGuid( cgiGet( edtavSg_organisationid_Internalname));
                  AssignAttri("", false, "AV26SG_OrganisationId", AV26SG_OrganisationId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vSG_ORGANISATIONID");
                  GX_FocusControl = edtavSg_organisationid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            if ( StringUtil.StrCmp(cgiGet( edtavSg_locationid_Internalname), "") == 0 )
            {
               AV27SG_LocationId = Guid.Empty;
               AssignAttri("", false, "AV27SG_LocationId", AV27SG_LocationId.ToString());
            }
            else
            {
               try
               {
                  AV27SG_LocationId = StringUtil.StrToGuid( cgiGet( edtavSg_locationid_Internalname));
                  AssignAttri("", false, "AV27SG_LocationId", AV27SG_LocationId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vSG_LOCATIONID");
                  GX_FocusControl = edtavSg_locationid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            AV39ResidentInitials = cgiGet( edtavResidentinitials_Internalname);
            AssignAttri("", false, "AV39ResidentInitials", AV39ResidentInitials);
            AV45ResidentGUID = cgiGet( edtavResidentguid_Internalname);
            AssignAttri("", false, "AV45ResidentGUID", AV45ResidentGUID);
            if ( StringUtil.StrCmp(cgiGet( edtavMedicalindicationid_Internalname), "") == 0 )
            {
               AV47MedicalIndicationId = Guid.Empty;
               AssignAttri("", false, "AV47MedicalIndicationId", AV47MedicalIndicationId.ToString());
            }
            else
            {
               try
               {
                  AV47MedicalIndicationId = StringUtil.StrToGuid( cgiGet( edtavMedicalindicationid_Internalname));
                  AssignAttri("", false, "AV47MedicalIndicationId", AV47MedicalIndicationId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vMEDICALINDICATIONID");
                  GX_FocusControl = edtavMedicalindicationid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E12BX2 ();
         if (returnInSub) return;
      }

      protected void E12BX2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV54DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV54DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtavNetworkindividualcountry_Visible = 0;
         AssignProp("", false, edtavNetworkindividualcountry_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNetworkindividualcountry_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_networkindividualcountry_Htmltemplate = GXt_char2;
         ucCombo_networkindividualcountry.SendProperty(context, "", false, Combo_networkindividualcountry_Internalname, "HTMLTemplate", Combo_networkindividualcountry_Htmltemplate);
         edtavNetworkindividualhomephonecode_Visible = 0;
         AssignProp("", false, edtavNetworkindividualhomephonecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNetworkindividualhomephonecode_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_networkindividualhomephonecode_Htmltemplate = GXt_char2;
         ucCombo_networkindividualhomephonecode.SendProperty(context, "", false, Combo_networkindividualhomephonecode_Internalname, "HTMLTemplate", Combo_networkindividualhomephonecode_Htmltemplate);
         edtavNetworkindividualphonecode_Visible = 0;
         AssignProp("", false, edtavNetworkindividualphonecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNetworkindividualphonecode_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_networkindividualphonecode_Htmltemplate = GXt_char2;
         ucCombo_networkindividualphonecode.SendProperty(context, "", false, Combo_networkindividualphonecode_Internalname, "HTMLTemplate", Combo_networkindividualphonecode_Htmltemplate);
         edtavResidenttypeid_Visible = 0;
         AssignProp("", false, edtavResidenttypeid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResidenttypeid_Visible), 5, 0), true);
         edtavResidentcountry_Visible = 0;
         AssignProp("", false, edtavResidentcountry_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResidentcountry_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_residentcountry_Htmltemplate = GXt_char2;
         ucCombo_residentcountry.SendProperty(context, "", false, Combo_residentcountry_Internalname, "HTMLTemplate", Combo_residentcountry_Htmltemplate);
         edtavResidenthomephonecode_Visible = 0;
         AssignProp("", false, edtavResidenthomephonecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResidenthomephonecode_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_residenthomephonecode_Htmltemplate = GXt_char2;
         ucCombo_residenthomephonecode.SendProperty(context, "", false, Combo_residenthomephonecode_Internalname, "HTMLTemplate", Combo_residenthomephonecode_Htmltemplate);
         edtavResidentphonecode_Visible = 0;
         AssignProp("", false, edtavResidentphonecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResidentphonecode_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_residentphonecode_Htmltemplate = GXt_char2;
         ucCombo_residentphonecode.SendProperty(context, "", false, Combo_residentphonecode_Internalname, "HTMLTemplate", Combo_residentphonecode_Htmltemplate);
         /* Execute user subroutine: 'LOADCOMBORESIDENTPHONECODE' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBORESIDENTHOMEPHONECODE' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBORESIDENTCOUNTRY' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBORESIDENTTYPEID' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBORESIDENTPACKAGEID' */
         S152 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBONETWORKINDIVIDUALPHONECODE' */
         S162 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBONETWORKINDIVIDUALHOMEPHONECODE' */
         S172 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBONETWORKINDIVIDUALCOUNTRY' */
         S182 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S192 ();
         if (returnInSub) return;
         edtavNetworkindividualid_Visible = 0;
         AssignProp("", false, edtavNetworkindividualid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNetworkindividualid_Visible), 5, 0), true);
         edtavSg_organisationid_Visible = 0;
         AssignProp("", false, edtavSg_organisationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSg_organisationid_Visible), 5, 0), true);
         edtavSg_locationid_Visible = 0;
         AssignProp("", false, edtavSg_locationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSg_locationid_Visible), 5, 0), true);
         edtavResidentid_Visible = 0;
         AssignProp("", false, edtavResidentid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResidentid_Visible), 5, 0), true);
         edtavLocationid_Visible = 0;
         AssignProp("", false, edtavLocationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLocationid_Visible), 5, 0), true);
         edtavOrganisationid_Visible = 0;
         AssignProp("", false, edtavOrganisationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOrganisationid_Visible), 5, 0), true);
         edtavResidentinitials_Visible = 0;
         AssignProp("", false, edtavResidentinitials_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResidentinitials_Visible), 5, 0), true);
         edtavResidentguid_Visible = 0;
         AssignProp("", false, edtavResidentguid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResidentguid_Visible), 5, 0), true);
         edtavMedicalindicationid_Visible = 0;
         AssignProp("", false, edtavMedicalindicationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMedicalindicationid_Visible), 5, 0), true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV85WWPContext) ;
         AV71defaultCountryPhoneCode = "+31";
         AssignAttri("", false, "AV71defaultCountryPhoneCode", AV71defaultCountryPhoneCode);
         AV84defaultCountry = "Netherlands";
         AssignAttri("", false, "AV84defaultCountry", AV84defaultCountry);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            Combo_residentphonecode_Selectedvalue_set = AV71defaultCountryPhoneCode;
            ucCombo_residentphonecode.SendProperty(context, "", false, Combo_residentphonecode_Internalname, "SelectedValue_set", Combo_residentphonecode_Selectedvalue_set);
            Combo_residentphonecode_Selectedtext_set = AV71defaultCountryPhoneCode;
            ucCombo_residentphonecode.SendProperty(context, "", false, Combo_residentphonecode_Internalname, "SelectedText_set", Combo_residentphonecode_Selectedtext_set);
            Combo_residenthomephonecode_Selectedvalue_set = AV71defaultCountryPhoneCode;
            ucCombo_residenthomephonecode.SendProperty(context, "", false, Combo_residenthomephonecode_Internalname, "SelectedValue_set", Combo_residenthomephonecode_Selectedvalue_set);
            Combo_residenthomephonecode_Selectedtext_set = AV71defaultCountryPhoneCode;
            ucCombo_residenthomephonecode.SendProperty(context, "", false, Combo_residenthomephonecode_Internalname, "SelectedText_set", Combo_residenthomephonecode_Selectedtext_set);
            Combo_networkindividualphonecode_Selectedvalue_set = AV71defaultCountryPhoneCode;
            ucCombo_networkindividualphonecode.SendProperty(context, "", false, Combo_networkindividualphonecode_Internalname, "SelectedValue_set", Combo_networkindividualphonecode_Selectedvalue_set);
            Combo_networkindividualhomephonecode_Selectedvalue_set = AV71defaultCountryPhoneCode;
            ucCombo_networkindividualhomephonecode.SendProperty(context, "", false, Combo_networkindividualhomephonecode_Internalname, "SelectedValue_set", Combo_networkindividualhomephonecode_Selectedvalue_set);
            Combo_networkindividualphonecode_Selectedtext_set = AV71defaultCountryPhoneCode;
            ucCombo_networkindividualphonecode.SendProperty(context, "", false, Combo_networkindividualphonecode_Internalname, "SelectedText_set", Combo_networkindividualphonecode_Selectedtext_set);
            Combo_networkindividualhomephonecode_Selectedtext_set = AV71defaultCountryPhoneCode;
            ucCombo_networkindividualhomephonecode.SendProperty(context, "", false, Combo_networkindividualhomephonecode_Internalname, "SelectedText_set", Combo_networkindividualhomephonecode_Selectedtext_set);
            Combo_residentcountry_Selectedvalue_set = AV84defaultCountry;
            ucCombo_residentcountry.SendProperty(context, "", false, Combo_residentcountry_Internalname, "SelectedValue_set", Combo_residentcountry_Selectedvalue_set);
            Combo_residentcountry_Selectedtext_set = AV84defaultCountry;
            ucCombo_residentcountry.SendProperty(context, "", false, Combo_residentcountry_Internalname, "SelectedText_set", Combo_residentcountry_Selectedtext_set);
            Combo_networkindividualcountry_Selectedtext_set = AV84defaultCountry;
            ucCombo_networkindividualcountry.SendProperty(context, "", false, Combo_networkindividualcountry_Internalname, "SelectedText_set", Combo_networkindividualcountry_Selectedtext_set);
            Combo_networkindividualcountry_Selectedvalue_set = AV84defaultCountry;
            ucCombo_networkindividualcountry.SendProperty(context, "", false, Combo_networkindividualcountry_Internalname, "SelectedValue_set", Combo_networkindividualcountry_Selectedvalue_set);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            edtavResidentemail_Enabled = 0;
            AssignProp("", false, edtavResidentemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentemail_Enabled), 5, 0), true);
            /* Execute user subroutine: 'SETDEFAULTRESIDENTANDNETWORKDATA' */
            S202 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
            S192 ();
            if (returnInSub) return;
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            /* Execute user subroutine: 'SETDEFAULTRESIDENTANDNETWORKDATA' */
            S202 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'SETALLFIELDSTOREADONLY' */
            S212 ();
            if (returnInSub) return;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV32ResidentCountry)) )
         {
            AV32ResidentCountry = AV84defaultCountry;
            AssignAttri("", false, "AV32ResidentCountry", AV32ResidentCountry);
            Combo_residentcountry_Selectedtext_set = AV84defaultCountry;
            ucCombo_residentcountry.SendProperty(context, "", false, Combo_residentcountry_Internalname, "SelectedText_set", Combo_residentcountry_Selectedtext_set);
            Combo_residentcountry_Selectedvalue_set = AV84defaultCountry;
            ucCombo_residentcountry.SendProperty(context, "", false, Combo_residentcountry_Internalname, "SelectedValue_set", Combo_residentcountry_Selectedvalue_set);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV10NetworkIndividualCountry)) )
         {
            AV10NetworkIndividualCountry = AV84defaultCountry;
            AssignAttri("", false, "AV10NetworkIndividualCountry", AV10NetworkIndividualCountry);
            Combo_networkindividualcountry_Selectedtext_set = AV84defaultCountry;
            ucCombo_networkindividualcountry.SendProperty(context, "", false, Combo_networkindividualcountry_Internalname, "SelectedText_set", Combo_networkindividualcountry_Selectedtext_set);
            Combo_networkindividualcountry_Selectedvalue_set = AV84defaultCountry;
            ucCombo_networkindividualcountry.SendProperty(context, "", false, Combo_networkindividualcountry_Internalname, "SelectedValue_set", Combo_networkindividualcountry_Selectedvalue_set);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72ComboResidentPhoneCode)) )
         {
            AV72ComboResidentPhoneCode = AV71defaultCountryPhoneCode;
            AssignAttri("", false, "AV72ComboResidentPhoneCode", AV72ComboResidentPhoneCode);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73ComboResidentHomePhoneCode)) )
         {
            AV73ComboResidentHomePhoneCode = AV71defaultCountryPhoneCode;
            AssignAttri("", false, "AV73ComboResidentHomePhoneCode", AV73ComboResidentHomePhoneCode);
         }
         GXt_char2 = AV89ResidentTitleDefinition;
         new prc_getorganisationdefinition(context ).execute(  "Resident", out  GXt_char2) ;
         AV89ResidentTitleDefinition = GXt_char2;
         AssignAttri("", false, "AV89ResidentTitleDefinition", AV89ResidentTitleDefinition);
         GxWebStd.gx_hidden_field( context, "gxhash_vRESIDENTTITLEDEFINITION", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV89ResidentTitleDefinition, "")), context));
         grpResidentinfogroup_Caption = AV89ResidentTitleDefinition+" "+context.GetMessage( "Information", "");
         AssignProp("", false, grpResidentinfogroup_Internalname, "Caption", grpResidentinfogroup_Caption, true);
         lblTextblockcombo_residenttypeid_Caption = AV89ResidentTitleDefinition+" "+context.GetMessage( "Type", "");
         AssignProp("", false, lblTextblockcombo_residenttypeid_Internalname, "Caption", lblTextblockcombo_residenttypeid_Caption, true);
      }

      protected void E13BX2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S222 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E11BX2( )
      {
         /* Combo_residenttypeid_Onoptionclicked Routine */
         returnInSub = false;
         AV24ResidentTypeId = StringUtil.StrToGuid( Combo_residenttypeid_Selectedvalue_get);
         AssignAttri("", false, "AV24ResidentTypeId", AV24ResidentTypeId.ToString());
         /*  Sending Event outputs  */
      }

      protected void S222( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") != 0 ) ) )
         {
            bttBtnenter_Visible = 0;
            AssignProp("", false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
         }
      }

      protected void S232( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV80CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV80CheckRequiredFieldsResult", AV80CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV36ResidentSalutation)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Salutation", ""), "", "", "", "", "", "", "", ""),  "error",  cmbavResidentsalutation_Internalname,  "true",  ""));
            AV80CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV80CheckRequiredFieldsResult", AV80CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV37ResidentGivenName)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "First Name", ""), "", "", "", "", "", "", "", ""),  "error",  edtavResidentgivenname_Internalname,  "true",  ""));
            AV80CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV80CheckRequiredFieldsResult", AV80CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV38ResidentLastName)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Last Name", ""), "", "", "", "", "", "", "", ""),  "error",  edtavResidentlastname_Internalname,  "true",  ""));
            AV80CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV80CheckRequiredFieldsResult", AV80CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV42ResidentEmail)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Email", ""), "", "", "", "", "", "", "", ""),  "error",  edtavResidentemail_Internalname,  "true",  ""));
            AV80CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV80CheckRequiredFieldsResult", AV80CheckRequiredFieldsResult);
         }
      }

      protected void S192( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV12NetworkIndividualSalutation, "Other") == 0 ) ) )
         {
            edtavNetworkindividualtitle_Visible = 0;
            AssignProp("", false, edtavNetworkindividualtitle_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNetworkindividualtitle_Visible), 5, 0), true);
            divNetworkindividualtitle_cell_Class = "Invisible";
            AssignProp("", false, divNetworkindividualtitle_cell_Internalname, "Class", divNetworkindividualtitle_cell_Class, true);
         }
         else
         {
            edtavNetworkindividualtitle_Visible = 1;
            AssignProp("", false, edtavNetworkindividualtitle_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNetworkindividualtitle_Visible), 5, 0), true);
            divNetworkindividualtitle_cell_Class = "col-xs-12 DataContentCell";
            AssignProp("", false, divNetworkindividualtitle_cell_Internalname, "Class", divNetworkindividualtitle_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) ) )
         {
            edtavNetworkindividualphone_Visible = 0;
            AssignProp("", false, edtavNetworkindividualphone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNetworkindividualphone_Visible), 5, 0), true);
            divNetworkindividualphone_cell_Class = "Invisible";
            AssignProp("", false, divNetworkindividualphone_cell_Internalname, "Class", divNetworkindividualphone_cell_Class, true);
         }
         else
         {
            edtavNetworkindividualphone_Visible = 1;
            AssignProp("", false, edtavNetworkindividualphone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNetworkindividualphone_Visible), 5, 0), true);
            divNetworkindividualphone_cell_Class = "col-xs-12 DataContentCell";
            AssignProp("", false, divNetworkindividualphone_cell_Internalname, "Class", divNetworkindividualphone_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) ) )
         {
            edtavNetworkindividualhomephone_Visible = 0;
            AssignProp("", false, edtavNetworkindividualhomephone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNetworkindividualhomephone_Visible), 5, 0), true);
            divNetworkindividualhomephone_cell_Class = "Invisible";
            AssignProp("", false, divNetworkindividualhomephone_cell_Internalname, "Class", divNetworkindividualhomephone_cell_Class, true);
         }
         else
         {
            edtavNetworkindividualhomephone_Visible = 1;
            AssignProp("", false, edtavNetworkindividualhomephone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNetworkindividualhomephone_Visible), 5, 0), true);
            divNetworkindividualhomephone_cell_Class = "col-xs-12 DataContentCell";
            AssignProp("", false, divNetworkindividualhomephone_cell_Internalname, "Class", divNetworkindividualhomephone_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(AV36ResidentSalutation, "Other") == 0 ) ) )
         {
            edtavResidenttitle_Visible = 0;
            AssignProp("", false, edtavResidenttitle_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResidenttitle_Visible), 5, 0), true);
            divResidenttitle_cell_Class = "Invisible";
            AssignProp("", false, divResidenttitle_cell_Internalname, "Class", divResidenttitle_cell_Class, true);
         }
         else
         {
            edtavResidenttitle_Visible = 1;
            AssignProp("", false, edtavResidenttitle_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResidenttitle_Visible), 5, 0), true);
            divResidenttitle_cell_Class = "col-xs-12 DataContentCell";
            AssignProp("", false, divResidenttitle_cell_Internalname, "Class", divResidenttitle_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) ) )
         {
            edtavResidentphone_Visible = 0;
            AssignProp("", false, edtavResidentphone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResidentphone_Visible), 5, 0), true);
            divResidentphone_cell_Class = "Invisible";
            AssignProp("", false, divResidentphone_cell_Internalname, "Class", divResidentphone_cell_Class, true);
         }
         else
         {
            edtavResidentphone_Visible = 1;
            AssignProp("", false, edtavResidentphone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResidentphone_Visible), 5, 0), true);
            divResidentphone_cell_Class = "col-xs-12 DataContentCell";
            AssignProp("", false, divResidentphone_cell_Internalname, "Class", divResidentphone_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) ) )
         {
            edtavResidenthomephone_Visible = 0;
            AssignProp("", false, edtavResidenthomephone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResidenthomephone_Visible), 5, 0), true);
            divResidenthomephone_cell_Class = "Invisible";
            AssignProp("", false, divResidenthomephone_cell_Internalname, "Class", divResidenthomephone_cell_Class, true);
         }
         else
         {
            edtavResidenthomephone_Visible = 1;
            AssignProp("", false, edtavResidenthomephone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResidenthomephone_Visible), 5, 0), true);
            divResidenthomephone_cell_Class = "col-xs-12 DataContentCell";
            AssignProp("", false, divResidenthomephone_cell_Internalname, "Class", divResidenthomephone_cell_Class, true);
         }
         divPhonenumber1_Visible = (((StringUtil.StrCmp(Gx_mode, "INS")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0)) ? 1 : 0);
         AssignProp("", false, divPhonenumber1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divPhonenumber1_Visible), 5, 0), true);
         divHomephonenumber1_Visible = (((StringUtil.StrCmp(Gx_mode, "INS")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0)) ? 1 : 0);
         AssignProp("", false, divHomephonenumber1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divHomephonenumber1_Visible), 5, 0), true);
         divPhonenumber_Visible = (((StringUtil.StrCmp(Gx_mode, "INS")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0)) ? 1 : 0);
         AssignProp("", false, divPhonenumber_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divPhonenumber_Visible), 5, 0), true);
         divHomephonenumber_Visible = (((StringUtil.StrCmp(Gx_mode, "INS")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0)) ? 1 : 0);
         AssignProp("", false, divHomephonenumber_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divHomephonenumber_Visible), 5, 0), true);
      }

      protected void S182( )
      {
         /* 'LOADCOMBONETWORKINDIVIDUALCOUNTRY' Routine */
         returnInSub = false;
         AV93GXV2 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = AV92GXV1;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem3) ;
         AV92GXV1 = GXt_objcol_SdtSDT_Country_SDT_CountryItem3;
         while ( AV93GXV2 <= AV92GXV1.Count )
         {
            AV56NetworkIndividualCountry_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV92GXV1.Item(AV93GXV2));
            AV55Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV55Combo_DataItem.gxTpr_Id = AV56NetworkIndividualCountry_DPItem.gxTpr_Countryname;
            AV52ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV52ComboTitles.Add(AV56NetworkIndividualCountry_DPItem.gxTpr_Countryname, 0);
            AV52ComboTitles.Add(AV56NetworkIndividualCountry_DPItem.gxTpr_Countryflag, 0);
            AV55Combo_DataItem.gxTpr_Title = AV52ComboTitles.ToJSonString(false);
            AV53NetworkIndividualCountry_Data.Add(AV55Combo_DataItem, 0);
            AV93GXV2 = (int)(AV93GXV2+1);
         }
         AV53NetworkIndividualCountry_Data.Sort("Title");
         Combo_networkindividualcountry_Selectedvalue_set = AV10NetworkIndividualCountry;
         ucCombo_networkindividualcountry.SendProperty(context, "", false, Combo_networkindividualcountry_Internalname, "SelectedValue_set", Combo_networkindividualcountry_Selectedvalue_set);
      }

      protected void S172( )
      {
         /* 'LOADCOMBONETWORKINDIVIDUALHOMEPHONECODE' Routine */
         returnInSub = false;
         AV95GXV4 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = AV94GXV3;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem3) ;
         AV94GXV3 = GXt_objcol_SdtSDT_Country_SDT_CountryItem3;
         while ( AV95GXV4 <= AV94GXV3.Count )
         {
            AV58NetworkIndividualHomePhoneCode_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV94GXV3.Item(AV95GXV4));
            AV55Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV55Combo_DataItem.gxTpr_Id = AV58NetworkIndividualHomePhoneCode_DPItem.gxTpr_Countrydialcode;
            AV52ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV52ComboTitles.Add(AV58NetworkIndividualHomePhoneCode_DPItem.gxTpr_Countrydialcode, 0);
            AV52ComboTitles.Add(AV58NetworkIndividualHomePhoneCode_DPItem.gxTpr_Countryflag, 0);
            AV55Combo_DataItem.gxTpr_Title = AV52ComboTitles.ToJSonString(false);
            AV57NetworkIndividualHomePhoneCode_Data.Add(AV55Combo_DataItem, 0);
            AV95GXV4 = (int)(AV95GXV4+1);
         }
         AV57NetworkIndividualHomePhoneCode_Data.Sort("Title");
         Combo_networkindividualhomephonecode_Selectedvalue_set = AV21NetworkIndividualHomePhoneCode;
         ucCombo_networkindividualhomephonecode.SendProperty(context, "", false, Combo_networkindividualhomephonecode_Internalname, "SelectedValue_set", Combo_networkindividualhomephonecode_Selectedvalue_set);
      }

      protected void S162( )
      {
         /* 'LOADCOMBONETWORKINDIVIDUALPHONECODE' Routine */
         returnInSub = false;
         AV97GXV6 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = AV96GXV5;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem3) ;
         AV96GXV5 = GXt_objcol_SdtSDT_Country_SDT_CountryItem3;
         while ( AV97GXV6 <= AV96GXV5.Count )
         {
            AV60NetworkIndividualPhoneCode_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV96GXV5.Item(AV97GXV6));
            AV55Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV55Combo_DataItem.gxTpr_Id = AV60NetworkIndividualPhoneCode_DPItem.gxTpr_Countrydialcode;
            AV52ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV52ComboTitles.Add(AV60NetworkIndividualPhoneCode_DPItem.gxTpr_Countrydialcode, 0);
            AV52ComboTitles.Add(AV60NetworkIndividualPhoneCode_DPItem.gxTpr_Countryflag, 0);
            AV55Combo_DataItem.gxTpr_Title = AV52ComboTitles.ToJSonString(false);
            AV59NetworkIndividualPhoneCode_Data.Add(AV55Combo_DataItem, 0);
            AV97GXV6 = (int)(AV97GXV6+1);
         }
         AV59NetworkIndividualPhoneCode_Data.Sort("Title");
         Combo_networkindividualphonecode_Selectedvalue_set = AV23NetworkIndividualPhoneCode;
         ucCombo_networkindividualphonecode.SendProperty(context, "", false, Combo_networkindividualphonecode_Internalname, "SelectedValue_set", Combo_networkindividualphonecode_Selectedvalue_set);
      }

      protected void S152( )
      {
         /* 'LOADCOMBORESIDENTPACKAGEID' Routine */
         returnInSub = false;
         AV99Udparg1 = new prc_getuserlocationid(context).executeUdp( );
         /* Using cursor H00BX2 */
         pr_default.execute(0, new Object[] {AV99Udparg1});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A528SG_LocationId = H00BX2_A528SG_LocationId[0];
            A527ResidentPackageId = H00BX2_A527ResidentPackageId[0];
            A531ResidentPackageName = H00BX2_A531ResidentPackageName[0];
            AV55Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV55Combo_DataItem.gxTpr_Id = StringUtil.Trim( A527ResidentPackageId.ToString());
            AV55Combo_DataItem.gxTpr_Title = A531ResidentPackageName;
            AV62ResidentPackageId_Data.Add(AV55Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         Combo_residentpackageid_Selectedvalue_set = AV25ResidentPackageId.ToJSonString(false);
         ucCombo_residentpackageid.SendProperty(context, "", false, Combo_residentpackageid_Internalname, "SelectedValue_set", Combo_residentpackageid_Selectedvalue_set);
      }

      protected void S142( )
      {
         /* 'LOADCOMBORESIDENTTYPEID' Routine */
         returnInSub = false;
         /* Using cursor H00BX3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A96ResidentTypeId = H00BX3_A96ResidentTypeId[0];
            A97ResidentTypeName = H00BX3_A97ResidentTypeName[0];
            AV55Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV55Combo_DataItem.gxTpr_Id = StringUtil.Trim( A96ResidentTypeId.ToString());
            AV55Combo_DataItem.gxTpr_Title = A97ResidentTypeName;
            AV61ResidentTypeId_Data.Add(AV55Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         Combo_residenttypeid_Selectedvalue_set = ((Guid.Empty==AV24ResidentTypeId) ? "" : StringUtil.Trim( AV24ResidentTypeId.ToString()));
         ucCombo_residenttypeid.SendProperty(context, "", false, Combo_residenttypeid_Internalname, "SelectedValue_set", Combo_residenttypeid_Selectedvalue_set);
      }

      protected void S132( )
      {
         /* 'LOADCOMBORESIDENTCOUNTRY' Routine */
         returnInSub = false;
         AV102GXV8 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = AV101GXV7;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem3) ;
         AV101GXV7 = GXt_objcol_SdtSDT_Country_SDT_CountryItem3;
         while ( AV102GXV8 <= AV101GXV7.Count )
         {
            AV64ResidentCountry_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV101GXV7.Item(AV102GXV8));
            AV55Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV55Combo_DataItem.gxTpr_Id = AV64ResidentCountry_DPItem.gxTpr_Countryname;
            AV52ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV52ComboTitles.Add(AV64ResidentCountry_DPItem.gxTpr_Countryname, 0);
            AV52ComboTitles.Add(AV64ResidentCountry_DPItem.gxTpr_Countryflag, 0);
            AV55Combo_DataItem.gxTpr_Title = AV52ComboTitles.ToJSonString(false);
            AV63ResidentCountry_Data.Add(AV55Combo_DataItem, 0);
            AV102GXV8 = (int)(AV102GXV8+1);
         }
         AV63ResidentCountry_Data.Sort("Title");
         Combo_residentcountry_Selectedvalue_set = AV32ResidentCountry;
         ucCombo_residentcountry.SendProperty(context, "", false, Combo_residentcountry_Internalname, "SelectedValue_set", Combo_residentcountry_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBORESIDENTHOMEPHONECODE' Routine */
         returnInSub = false;
         AV104GXV10 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = AV103GXV9;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem3) ;
         AV103GXV9 = GXt_objcol_SdtSDT_Country_SDT_CountryItem3;
         while ( AV104GXV10 <= AV103GXV9.Count )
         {
            AV66ResidentHomePhoneCode_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV103GXV9.Item(AV104GXV10));
            AV55Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV55Combo_DataItem.gxTpr_Id = AV66ResidentHomePhoneCode_DPItem.gxTpr_Countrydialcode;
            AV52ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV52ComboTitles.Add(AV66ResidentHomePhoneCode_DPItem.gxTpr_Countrydialcode, 0);
            AV52ComboTitles.Add(AV66ResidentHomePhoneCode_DPItem.gxTpr_Countryflag, 0);
            AV55Combo_DataItem.gxTpr_Title = AV52ComboTitles.ToJSonString(false);
            AV65ResidentHomePhoneCode_Data.Add(AV55Combo_DataItem, 0);
            AV104GXV10 = (int)(AV104GXV10+1);
         }
         AV65ResidentHomePhoneCode_Data.Sort("Title");
         Combo_residenthomephonecode_Selectedvalue_set = AV49ResidentHomePhoneCode;
         ucCombo_residenthomephonecode.SendProperty(context, "", false, Combo_residenthomephonecode_Internalname, "SelectedValue_set", Combo_residenthomephonecode_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'LOADCOMBORESIDENTPHONECODE' Routine */
         returnInSub = false;
         AV106GXV12 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = AV105GXV11;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem3) ;
         AV105GXV11 = GXt_objcol_SdtSDT_Country_SDT_CountryItem3;
         while ( AV106GXV12 <= AV105GXV11.Count )
         {
            AV68ResidentPhoneCode_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV105GXV11.Item(AV106GXV12));
            AV55Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV55Combo_DataItem.gxTpr_Id = AV68ResidentPhoneCode_DPItem.gxTpr_Countrydialcode;
            AV52ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV52ComboTitles.Add(AV68ResidentPhoneCode_DPItem.gxTpr_Countrydialcode, 0);
            AV52ComboTitles.Add(AV68ResidentPhoneCode_DPItem.gxTpr_Countryflag, 0);
            AV55Combo_DataItem.gxTpr_Title = AV52ComboTitles.ToJSonString(false);
            AV67ResidentPhoneCode_Data.Add(AV55Combo_DataItem, 0);
            AV106GXV12 = (int)(AV106GXV12+1);
         }
         AV67ResidentPhoneCode_Data.Sort("Title");
         Combo_residentphonecode_Selectedvalue_set = AV51ResidentPhoneCode;
         ucCombo_residentphonecode.SendProperty(context, "", false, Combo_residentphonecode_Internalname, "SelectedValue_set", Combo_residentphonecode_Selectedvalue_set);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E14BX2 ();
         if (returnInSub) return;
      }

      protected void E14BX2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S232 ();
         if (returnInSub) return;
         if ( AV80CheckRequiredFieldsResult )
         {
            AV74Trn_Resident.gxTpr_Residentsalutation = AV36ResidentSalutation;
            if ( StringUtil.StrCmp(AV36ResidentSalutation, "Other") == 0 )
            {
               AV74Trn_Resident.gxTpr_Residenttitle = AV69ResidentTitle;
            }
            AV74Trn_Resident.gxTpr_Residentbsnnumber = AV46ResidentBsnNumber;
            AV74Trn_Resident.gxTpr_Residentgivenname = AV37ResidentGivenName;
            AV74Trn_Resident.gxTpr_Residentlastname = AV38ResidentLastName;
            AV74Trn_Resident.gxTpr_Residentemail = AV42ResidentEmail;
            AV74Trn_Resident.gxTpr_Residentgender = AV40ResidentGender;
            AV74Trn_Resident.gxTpr_Residentcountry = AV32ResidentCountry;
            AV74Trn_Resident.gxTpr_Residentcity = AV31ResidentCity;
            AV74Trn_Resident.gxTpr_Residentzipcode = AV30ResidentZipCode;
            AV74Trn_Resident.gxTpr_Residentaddressline1 = AV28ResidentAddressLine1;
            AV74Trn_Resident.gxTpr_Residentaddressline2 = AV29ResidentAddressLine2;
            AV74Trn_Resident.gxTpr_Residentbirthdate = AV41ResidentBirthDate;
            if ( StringUtil.EndsWith( AV24ResidentTypeId.ToString(), "000000000000") )
            {
               AV74Trn_Resident.gxTv_SdtTrn_Resident_Residenttypeid_SetNull();
            }
            else
            {
               AV74Trn_Resident.gxTpr_Residenttypeid = AV24ResidentTypeId;
            }
            AV74Trn_Resident.gxTv_SdtTrn_Resident_Residentpackageid_SetNull();
            AV74Trn_Resident.gxTpr_Residentgroups = AV25ResidentPackageId.ToJSonString(false);
            AV74Trn_Resident.gxTv_SdtTrn_Resident_Medicalindicationid_SetNull();
            AV74Trn_Resident.gxTpr_Residentphonecode = AV51ResidentPhoneCode;
            AV74Trn_Resident.gxTpr_Residentphonenumber = AV50ResidentPhoneNumber;
            AV74Trn_Resident.gxTpr_Residenthomephonecode = AV49ResidentHomePhoneCode;
            AV74Trn_Resident.gxTpr_Locationid = AV85WWPContext.gxTpr_Locationid;
            AV74Trn_Resident.gxTpr_Organisationid = AV85WWPContext.gxTpr_Organisationid;
            AV74Trn_Resident.gxTpr_Residenthomephonenumber = AV48ResidentHomePhoneNumber;
            if ( AV74Trn_Resident.InsertOrUpdate() )
            {
               AV87ActiveLanguageName = context.GetLanguage( );
               if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && StringUtil.Contains( AV87ActiveLanguageName, context.GetMessage( "English", "")) )
               {
                  /* Execute user subroutine: 'INSERTNETWORKINDIVIDUAL' */
                  S242 ();
                  if (returnInSub) return;
                  AV83Session.Set(context.GetMessage( "NotificationMessage", ""), AV89ResidentTitleDefinition+" "+context.GetMessage( " Inserted successfully", ""));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && StringUtil.Contains( AV87ActiveLanguageName, context.GetMessage( "Dutch", "")) )
                  {
                     /* Execute user subroutine: 'INSERTNETWORKINDIVIDUAL' */
                     S242 ();
                     if (returnInSub) return;
                     AV83Session.Set(context.GetMessage( "NotificationMessage", ""), AV89ResidentTitleDefinition+" "+context.GetMessage( "succesvol toegevoegd", ""));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && StringUtil.Contains( AV87ActiveLanguageName, context.GetMessage( "English", "")) )
                     {
                        /* Execute user subroutine: 'UPDATENETWORKINDIVIDUAL' */
                        S252 ();
                        if (returnInSub) return;
                        AV83Session.Set(context.GetMessage( "NotificationMessage", ""), AV89ResidentTitleDefinition+" "+context.GetMessage( "Updated successfully", ""));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && StringUtil.Contains( AV87ActiveLanguageName, context.GetMessage( "Dutch", "")) )
                        {
                           /* Execute user subroutine: 'UPDATENETWORKINDIVIDUAL' */
                           S252 ();
                           if (returnInSub) return;
                           AV83Session.Set(context.GetMessage( "NotificationMessage", ""), AV89ResidentTitleDefinition+" "+context.GetMessage( " succesvol bijgewerkt", ""));
                        }
                     }
                  }
               }
               context.CommitDataStores("wp_createresidentandnetwork",pr_default);
               context.setWebReturnParms(new Object[] {});
               context.setWebReturnParmsMetadata(new Object[] {});
               context.wjLocDisableFrm = 1;
               context.nUserReturn = 1;
               returnInSub = true;
               if (true) return;
            }
            else
            {
               AV81ErrorMessageCollection = AV74Trn_Resident.GetMessages();
               /* Execute user subroutine: 'DISPLAYMESSAGES' */
               S262 ();
               if (returnInSub) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV74Trn_Resident", AV74Trn_Resident);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV81ErrorMessageCollection", AV81ErrorMessageCollection);
      }

      protected void S202( )
      {
         /* 'SETDEFAULTRESIDENTANDNETWORKDATA' Routine */
         returnInSub = false;
         AV74Trn_Resident.Load(AV33ResidentId, AV34LocationId, AV35OrganisationId);
         if ( AV74Trn_Resident.Success() )
         {
            AV36ResidentSalutation = AV74Trn_Resident.gxTpr_Residentsalutation;
            AssignAttri("", false, "AV36ResidentSalutation", AV36ResidentSalutation);
            AV69ResidentTitle = AV74Trn_Resident.gxTpr_Residenttitle;
            AssignAttri("", false, "AV69ResidentTitle", AV69ResidentTitle);
            AV46ResidentBsnNumber = AV74Trn_Resident.gxTpr_Residentbsnnumber;
            AssignAttri("", false, "AV46ResidentBsnNumber", AV46ResidentBsnNumber);
            AV37ResidentGivenName = AV74Trn_Resident.gxTpr_Residentgivenname;
            AssignAttri("", false, "AV37ResidentGivenName", AV37ResidentGivenName);
            AV38ResidentLastName = AV74Trn_Resident.gxTpr_Residentlastname;
            AssignAttri("", false, "AV38ResidentLastName", AV38ResidentLastName);
            AV42ResidentEmail = AV74Trn_Resident.gxTpr_Residentemail;
            AssignAttri("", false, "AV42ResidentEmail", AV42ResidentEmail);
            AV40ResidentGender = AV74Trn_Resident.gxTpr_Residentgender;
            AssignAttri("", false, "AV40ResidentGender", AV40ResidentGender);
            AV32ResidentCountry = AV74Trn_Resident.gxTpr_Residentcountry;
            AssignAttri("", false, "AV32ResidentCountry", AV32ResidentCountry);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_Resident.gxTpr_Residentcountry)) )
            {
               Combo_residentcountry_Selectedvalue_set = AV84defaultCountry;
               ucCombo_residentcountry.SendProperty(context, "", false, Combo_residentcountry_Internalname, "SelectedValue_set", Combo_residentcountry_Selectedvalue_set);
               Combo_residentcountry_Selectedtext_set = AV84defaultCountry;
               ucCombo_residentcountry.SendProperty(context, "", false, Combo_residentcountry_Internalname, "SelectedText_set", Combo_residentcountry_Selectedtext_set);
            }
            else
            {
               Combo_residentcountry_Selectedvalue_set = AV74Trn_Resident.gxTpr_Residentcountry;
               ucCombo_residentcountry.SendProperty(context, "", false, Combo_residentcountry_Internalname, "SelectedValue_set", Combo_residentcountry_Selectedvalue_set);
               Combo_residentcountry_Selectedtext_set = AV74Trn_Resident.gxTpr_Residentcountry;
               ucCombo_residentcountry.SendProperty(context, "", false, Combo_residentcountry_Internalname, "SelectedText_set", Combo_residentcountry_Selectedtext_set);
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_Resident.gxTpr_Residentphonecode)) )
            {
               Combo_residentphonecode_Selectedvalue_set = AV71defaultCountryPhoneCode;
               ucCombo_residentphonecode.SendProperty(context, "", false, Combo_residentphonecode_Internalname, "SelectedValue_set", Combo_residentphonecode_Selectedvalue_set);
               Combo_residentphonecode_Selectedtext_set = AV71defaultCountryPhoneCode;
               ucCombo_residentphonecode.SendProperty(context, "", false, Combo_residentphonecode_Internalname, "SelectedText_set", Combo_residentphonecode_Selectedtext_set);
            }
            else
            {
               Combo_residentphonecode_Selectedvalue_set = AV74Trn_Resident.gxTpr_Residentphonecode;
               ucCombo_residentphonecode.SendProperty(context, "", false, Combo_residentphonecode_Internalname, "SelectedValue_set", Combo_residentphonecode_Selectedvalue_set);
               Combo_residentphonecode_Selectedtext_set = AV74Trn_Resident.gxTpr_Residentphonecode;
               ucCombo_residentphonecode.SendProperty(context, "", false, Combo_residentphonecode_Internalname, "SelectedText_set", Combo_residentphonecode_Selectedtext_set);
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_Resident.gxTpr_Residenthomephonecode)) )
            {
               Combo_residenthomephonecode_Selectedvalue_set = AV71defaultCountryPhoneCode;
               ucCombo_residenthomephonecode.SendProperty(context, "", false, Combo_residenthomephonecode_Internalname, "SelectedValue_set", Combo_residenthomephonecode_Selectedvalue_set);
               Combo_residenthomephonecode_Selectedtext_set = AV71defaultCountryPhoneCode;
               ucCombo_residenthomephonecode.SendProperty(context, "", false, Combo_residenthomephonecode_Internalname, "SelectedText_set", Combo_residenthomephonecode_Selectedtext_set);
            }
            else
            {
               Combo_residenthomephonecode_Selectedvalue_set = AV74Trn_Resident.gxTpr_Residenthomephonecode;
               ucCombo_residenthomephonecode.SendProperty(context, "", false, Combo_residenthomephonecode_Internalname, "SelectedValue_set", Combo_residenthomephonecode_Selectedvalue_set);
               Combo_residenthomephonecode_Selectedtext_set = AV74Trn_Resident.gxTpr_Residenthomephonecode;
               ucCombo_residenthomephonecode.SendProperty(context, "", false, Combo_residenthomephonecode_Internalname, "SelectedText_set", Combo_residenthomephonecode_Selectedtext_set);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_Resident.gxTpr_Residentgroups)) )
            {
               Combo_residentpackageid_Selectedvalue_set = AV74Trn_Resident.gxTpr_Residentgroups;
               ucCombo_residentpackageid.SendProperty(context, "", false, Combo_residentpackageid_Internalname, "SelectedValue_set", Combo_residentpackageid_Selectedvalue_set);
               Combo_residentpackageid_Selectedtext_set = AV74Trn_Resident.gxTpr_Residentgroups;
               ucCombo_residentpackageid.SendProperty(context, "", false, Combo_residentpackageid_Internalname, "SelectedText_set", Combo_residentpackageid_Selectedtext_set);
            }
            if ( ! (Guid.Empty==AV74Trn_Resident.gxTpr_Residenttypeid) )
            {
               Combo_residenttypeid_Selectedvalue_set = AV74Trn_Resident.gxTpr_Residenttypeid.ToString();
               ucCombo_residenttypeid.SendProperty(context, "", false, Combo_residenttypeid_Internalname, "SelectedValue_set", Combo_residenttypeid_Selectedvalue_set);
               Combo_residenttypeid_Selectedtext_set = AV74Trn_Resident.gxTpr_Residenttypeid.ToString();
               ucCombo_residenttypeid.SendProperty(context, "", false, Combo_residenttypeid_Internalname, "SelectedText_set", Combo_residenttypeid_Selectedtext_set);
            }
            AV31ResidentCity = AV74Trn_Resident.gxTpr_Residentcity;
            AssignAttri("", false, "AV31ResidentCity", AV31ResidentCity);
            AV30ResidentZipCode = AV74Trn_Resident.gxTpr_Residentzipcode;
            AssignAttri("", false, "AV30ResidentZipCode", AV30ResidentZipCode);
            AV28ResidentAddressLine1 = AV74Trn_Resident.gxTpr_Residentaddressline1;
            AssignAttri("", false, "AV28ResidentAddressLine1", AV28ResidentAddressLine1);
            AV29ResidentAddressLine2 = AV74Trn_Resident.gxTpr_Residentaddressline2;
            AssignAttri("", false, "AV29ResidentAddressLine2", AV29ResidentAddressLine2);
            AV43ResidentPhone = AV74Trn_Resident.gxTpr_Residentphone;
            AssignAttri("", false, "AV43ResidentPhone", AV43ResidentPhone);
            AV44ResidentHomePhone = AV74Trn_Resident.gxTpr_Residenthomephone;
            AssignAttri("", false, "AV44ResidentHomePhone", AV44ResidentHomePhone);
            AV41ResidentBirthDate = AV74Trn_Resident.gxTpr_Residentbirthdate;
            AssignAttri("", false, "AV41ResidentBirthDate", context.localUtil.Format(AV41ResidentBirthDate, "99/99/9999"));
            AV45ResidentGUID = AV74Trn_Resident.gxTpr_Residentguid;
            AssignAttri("", false, "AV45ResidentGUID", AV45ResidentGUID);
            AV24ResidentTypeId = AV74Trn_Resident.gxTpr_Residenttypeid;
            AssignAttri("", false, "AV24ResidentTypeId", AV24ResidentTypeId.ToString());
            AV47MedicalIndicationId = AV74Trn_Resident.gxTpr_Medicalindicationid;
            AssignAttri("", false, "AV47MedicalIndicationId", AV47MedicalIndicationId.ToString());
            AV51ResidentPhoneCode = AV74Trn_Resident.gxTpr_Residentphonecode;
            AssignAttri("", false, "AV51ResidentPhoneCode", AV51ResidentPhoneCode);
            AV50ResidentPhoneNumber = AV74Trn_Resident.gxTpr_Residentphonenumber;
            AssignAttri("", false, "AV50ResidentPhoneNumber", AV50ResidentPhoneNumber);
            AV49ResidentHomePhoneCode = AV74Trn_Resident.gxTpr_Residenthomephonecode;
            AssignAttri("", false, "AV49ResidentHomePhoneCode", AV49ResidentHomePhoneCode);
            AV48ResidentHomePhoneNumber = AV74Trn_Resident.gxTpr_Residenthomephonenumber;
            AssignAttri("", false, "AV48ResidentHomePhoneNumber", AV48ResidentHomePhoneNumber);
            /* Using cursor H00BX4 */
            pr_default.execute(2, new Object[] {AV74Trn_Resident.gxTpr_Residentid});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A62ResidentId = H00BX4_A62ResidentId[0];
               A74NetworkIndividualId = H00BX4_A74NetworkIndividualId[0];
               A75NetworkIndividualBsnNumber = H00BX4_A75NetworkIndividualBsnNumber[0];
               A76NetworkIndividualGivenName = H00BX4_A76NetworkIndividualGivenName[0];
               A77NetworkIndividualLastName = H00BX4_A77NetworkIndividualLastName[0];
               A78NetworkIndividualEmail = H00BX4_A78NetworkIndividualEmail[0];
               A79NetworkIndividualPhone = H00BX4_A79NetworkIndividualPhone[0];
               A433NetworkIndividualHomePhone = H00BX4_A433NetworkIndividualHomePhone[0];
               A359NetworkIndividualPhoneCode = H00BX4_A359NetworkIndividualPhoneCode[0];
               A434NetworkIndividualHomePhoneCode = H00BX4_A434NetworkIndividualHomePhoneCode[0];
               A360NetworkIndividualPhoneNumber = H00BX4_A360NetworkIndividualPhoneNumber[0];
               A435NetworkIndividualHomePhoneNumb = H00BX4_A435NetworkIndividualHomePhoneNumb[0];
               A495NetworkIndividualRelationship = H00BX4_A495NetworkIndividualRelationship[0];
               A81NetworkIndividualGender = H00BX4_A81NetworkIndividualGender[0];
               A322NetworkIndividualCountry = H00BX4_A322NetworkIndividualCountry[0];
               A323NetworkIndividualCity = H00BX4_A323NetworkIndividualCity[0];
               A324NetworkIndividualZipCode = H00BX4_A324NetworkIndividualZipCode[0];
               A325NetworkIndividualAddressLine1 = H00BX4_A325NetworkIndividualAddressLine1[0];
               A326NetworkIndividualAddressLine2 = H00BX4_A326NetworkIndividualAddressLine2[0];
               A664NetworkIndividualSalutation = H00BX4_A664NetworkIndividualSalutation[0];
               n664NetworkIndividualSalutation = H00BX4_n664NetworkIndividualSalutation[0];
               A668NetworkIndividualTitle = H00BX4_A668NetworkIndividualTitle[0];
               n668NetworkIndividualTitle = H00BX4_n668NetworkIndividualTitle[0];
               AV11NetworkIndividualId = A74NetworkIndividualId;
               AssignAttri("", false, "AV11NetworkIndividualId", AV11NetworkIndividualId.ToString());
               AV19NetworkIndividualBsnNumber = A75NetworkIndividualBsnNumber;
               AssignAttri("", false, "AV19NetworkIndividualBsnNumber", AV19NetworkIndividualBsnNumber);
               AV13NetworkIndividualGivenName = A76NetworkIndividualGivenName;
               AssignAttri("", false, "AV13NetworkIndividualGivenName", AV13NetworkIndividualGivenName);
               AV14NetworkIndividualLastName = A77NetworkIndividualLastName;
               AssignAttri("", false, "AV14NetworkIndividualLastName", AV14NetworkIndividualLastName);
               AV16NetworkIndividualEmail = A78NetworkIndividualEmail;
               AssignAttri("", false, "AV16NetworkIndividualEmail", AV16NetworkIndividualEmail);
               AV17NetworkIndividualPhone = A79NetworkIndividualPhone;
               AssignAttri("", false, "AV17NetworkIndividualPhone", AV17NetworkIndividualPhone);
               AV18NetworkIndividualHomePhone = A433NetworkIndividualHomePhone;
               AssignAttri("", false, "AV18NetworkIndividualHomePhone", AV18NetworkIndividualHomePhone);
               AV23NetworkIndividualPhoneCode = A359NetworkIndividualPhoneCode;
               AssignAttri("", false, "AV23NetworkIndividualPhoneCode", AV23NetworkIndividualPhoneCode);
               AV21NetworkIndividualHomePhoneCode = A434NetworkIndividualHomePhoneCode;
               AssignAttri("", false, "AV21NetworkIndividualHomePhoneCode", AV21NetworkIndividualHomePhoneCode);
               AV22NetworkIndividualPhoneNumber = A360NetworkIndividualPhoneNumber;
               AssignAttri("", false, "AV22NetworkIndividualPhoneNumber", AV22NetworkIndividualPhoneNumber);
               AV20NetworkIndividualHomePhoneNumber = A435NetworkIndividualHomePhoneNumb;
               AssignAttri("", false, "AV20NetworkIndividualHomePhoneNumber", AV20NetworkIndividualHomePhoneNumber);
               AV79NetworkIndividualRelationship = A495NetworkIndividualRelationship;
               AssignAttri("", false, "AV79NetworkIndividualRelationship", AV79NetworkIndividualRelationship);
               AV15NetworkIndividualGender = A81NetworkIndividualGender;
               AssignAttri("", false, "AV15NetworkIndividualGender", AV15NetworkIndividualGender);
               AV10NetworkIndividualCountry = A322NetworkIndividualCountry;
               AssignAttri("", false, "AV10NetworkIndividualCountry", AV10NetworkIndividualCountry);
               AV9NetworkIndividualCity = A323NetworkIndividualCity;
               AssignAttri("", false, "AV9NetworkIndividualCity", AV9NetworkIndividualCity);
               AV8NetworkIndividualZipCode = A324NetworkIndividualZipCode;
               AssignAttri("", false, "AV8NetworkIndividualZipCode", AV8NetworkIndividualZipCode);
               AV6NetworkIndividualAddressLine1 = A325NetworkIndividualAddressLine1;
               AssignAttri("", false, "AV6NetworkIndividualAddressLine1", AV6NetworkIndividualAddressLine1);
               AV7NetworkIndividualAddressLine2 = A326NetworkIndividualAddressLine2;
               AssignAttri("", false, "AV7NetworkIndividualAddressLine2", AV7NetworkIndividualAddressLine2);
               AV12NetworkIndividualSalutation = A664NetworkIndividualSalutation;
               AssignAttri("", false, "AV12NetworkIndividualSalutation", AV12NetworkIndividualSalutation);
               AV88NetworkIndividualTitle = A668NetworkIndividualTitle;
               AssignAttri("", false, "AV88NetworkIndividualTitle", AV88NetworkIndividualTitle);
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV10NetworkIndividualCountry)) )
               {
                  Combo_networkindividualcountry_Selectedvalue_set = AV84defaultCountry;
                  ucCombo_networkindividualcountry.SendProperty(context, "", false, Combo_networkindividualcountry_Internalname, "SelectedValue_set", Combo_networkindividualcountry_Selectedvalue_set);
                  Combo_networkindividualcountry_Selectedtext_set = AV84defaultCountry;
                  ucCombo_networkindividualcountry.SendProperty(context, "", false, Combo_networkindividualcountry_Internalname, "SelectedText_set", Combo_networkindividualcountry_Selectedtext_set);
               }
               else
               {
                  Combo_networkindividualcountry_Selectedvalue_set = AV10NetworkIndividualCountry;
                  ucCombo_networkindividualcountry.SendProperty(context, "", false, Combo_networkindividualcountry_Internalname, "SelectedValue_set", Combo_networkindividualcountry_Selectedvalue_set);
                  Combo_networkindividualcountry_Selectedtext_set = AV10NetworkIndividualCountry;
                  ucCombo_networkindividualcountry.SendProperty(context, "", false, Combo_networkindividualcountry_Internalname, "SelectedText_set", Combo_networkindividualcountry_Selectedtext_set);
               }
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV23NetworkIndividualPhoneCode)) )
               {
                  Combo_networkindividualphonecode_Selectedvalue_set = AV71defaultCountryPhoneCode;
                  ucCombo_networkindividualphonecode.SendProperty(context, "", false, Combo_networkindividualphonecode_Internalname, "SelectedValue_set", Combo_networkindividualphonecode_Selectedvalue_set);
                  Combo_networkindividualphonecode_Selectedtext_set = AV71defaultCountryPhoneCode;
                  ucCombo_networkindividualphonecode.SendProperty(context, "", false, Combo_networkindividualphonecode_Internalname, "SelectedText_set", Combo_networkindividualphonecode_Selectedtext_set);
               }
               else
               {
                  Combo_networkindividualphonecode_Selectedvalue_set = AV23NetworkIndividualPhoneCode;
                  ucCombo_networkindividualphonecode.SendProperty(context, "", false, Combo_networkindividualphonecode_Internalname, "SelectedValue_set", Combo_networkindividualphonecode_Selectedvalue_set);
                  Combo_networkindividualphonecode_Selectedtext_set = AV23NetworkIndividualPhoneCode;
                  ucCombo_networkindividualphonecode.SendProperty(context, "", false, Combo_networkindividualphonecode_Internalname, "SelectedText_set", Combo_networkindividualphonecode_Selectedtext_set);
               }
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV21NetworkIndividualHomePhoneCode)) )
               {
                  Combo_networkindividualhomephonecode_Selectedvalue_set = AV71defaultCountryPhoneCode;
                  ucCombo_networkindividualhomephonecode.SendProperty(context, "", false, Combo_networkindividualhomephonecode_Internalname, "SelectedValue_set", Combo_networkindividualhomephonecode_Selectedvalue_set);
                  Combo_networkindividualhomephonecode_Selectedtext_set = AV71defaultCountryPhoneCode;
                  ucCombo_networkindividualhomephonecode.SendProperty(context, "", false, Combo_networkindividualhomephonecode_Internalname, "SelectedText_set", Combo_networkindividualhomephonecode_Selectedtext_set);
               }
               else
               {
                  Combo_networkindividualhomephonecode_Selectedvalue_set = AV21NetworkIndividualHomePhoneCode;
                  ucCombo_networkindividualhomephonecode.SendProperty(context, "", false, Combo_networkindividualhomephonecode_Internalname, "SelectedValue_set", Combo_networkindividualhomephonecode_Selectedvalue_set);
                  Combo_networkindividualhomephonecode_Selectedtext_set = AV21NetworkIndividualHomePhoneCode;
                  ucCombo_networkindividualhomephonecode.SendProperty(context, "", false, Combo_networkindividualhomephonecode_Internalname, "SelectedText_set", Combo_networkindividualhomephonecode_Selectedtext_set);
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
         }
      }

      protected void S262( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         AV108GXV13 = 1;
         while ( AV108GXV13 <= AV81ErrorMessageCollection.Count )
         {
            AV82ErrorMessage = ((GeneXus.Utils.SdtMessages_Message)AV81ErrorMessageCollection.Item(AV108GXV13));
            if ( StringUtil.StrCmp(AV82ErrorMessage.gxTpr_Description, context.GetMessage( "GXM_unexp", "")) != 0 )
            {
               GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV82ErrorMessage.gxTpr_Description,  "error",  "",  "true",  ""));
            }
            AV108GXV13 = (int)(AV108GXV13+1);
         }
      }

      protected void S212( )
      {
         /* 'SETALLFIELDSTOREADONLY' Routine */
         returnInSub = false;
         cmbavResidentsalutation.Enabled = 0;
         AssignProp("", false, cmbavResidentsalutation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavResidentsalutation.Enabled), 5, 0), true);
         edtavResidentbsnnumber_Enabled = 0;
         AssignProp("", false, edtavResidentbsnnumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentbsnnumber_Enabled), 5, 0), true);
         edtavResidentgivenname_Enabled = 0;
         AssignProp("", false, edtavResidentgivenname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentgivenname_Enabled), 5, 0), true);
         edtavResidentlastname_Enabled = 0;
         AssignProp("", false, edtavResidentlastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentlastname_Enabled), 5, 0), true);
         edtavResidentemail_Enabled = 0;
         AssignProp("", false, edtavResidentemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentemail_Enabled), 5, 0), true);
         cmbavResidentgender.Enabled = 0;
         AssignProp("", false, cmbavResidentgender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavResidentgender.Enabled), 5, 0), true);
         edtavResidentcountry_Enabled = 0;
         AssignProp("", false, edtavResidentcountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentcountry_Enabled), 5, 0), true);
         edtavResidentcity_Enabled = 0;
         AssignProp("", false, edtavResidentcity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentcity_Enabled), 5, 0), true);
         edtavResidentzipcode_Enabled = 0;
         AssignProp("", false, edtavResidentzipcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentzipcode_Enabled), 5, 0), true);
         edtavResidentaddressline1_Enabled = 0;
         AssignProp("", false, edtavResidentaddressline1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentaddressline1_Enabled), 5, 0), true);
         edtavResidentaddressline2_Enabled = 0;
         AssignProp("", false, edtavResidentaddressline2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentaddressline2_Enabled), 5, 0), true);
         edtavResidentphone_Enabled = 0;
         AssignProp("", false, edtavResidentphone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentphone_Enabled), 5, 0), true);
         edtavResidenthomephone_Enabled = 0;
         AssignProp("", false, edtavResidenthomephone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidenthomephone_Enabled), 5, 0), true);
         edtavResidentbirthdate_Enabled = 0;
         AssignProp("", false, edtavResidentbirthdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentbirthdate_Enabled), 5, 0), true);
         edtavResidentguid_Enabled = 0;
         AssignProp("", false, edtavResidentguid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentguid_Enabled), 5, 0), true);
         edtavResidenttypeid_Enabled = 0;
         AssignProp("", false, edtavResidenttypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidenttypeid_Enabled), 5, 0), true);
         edtavMedicalindicationid_Enabled = 0;
         AssignProp("", false, edtavMedicalindicationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMedicalindicationid_Enabled), 5, 0), true);
         edtavResidentphonecode_Enabled = 0;
         AssignProp("", false, edtavResidentphonecode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentphonecode_Enabled), 5, 0), true);
         edtavResidentphonenumber_Enabled = 0;
         AssignProp("", false, edtavResidentphonenumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentphonenumber_Enabled), 5, 0), true);
         edtavResidenthomephonecode_Enabled = 0;
         AssignProp("", false, edtavResidenthomephonecode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidenthomephonecode_Enabled), 5, 0), true);
         edtavResidenthomephonenumber_Enabled = 0;
         AssignProp("", false, edtavResidenthomephonenumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidenthomephonenumber_Enabled), 5, 0), true);
         edtavNetworkindividualbsnnumber_Enabled = 0;
         AssignProp("", false, edtavNetworkindividualbsnnumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNetworkindividualbsnnumber_Enabled), 5, 0), true);
         edtavNetworkindividualgivenname_Enabled = 0;
         AssignProp("", false, edtavNetworkindividualgivenname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNetworkindividualgivenname_Enabled), 5, 0), true);
         edtavNetworkindividuallastname_Enabled = 0;
         AssignProp("", false, edtavNetworkindividuallastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNetworkindividuallastname_Enabled), 5, 0), true);
         edtavNetworkindividualemail_Enabled = 0;
         AssignProp("", false, edtavNetworkindividualemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNetworkindividualemail_Enabled), 5, 0), true);
         edtavNetworkindividualphone_Enabled = 0;
         AssignProp("", false, edtavNetworkindividualphone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNetworkindividualphone_Enabled), 5, 0), true);
         edtavNetworkindividualhomephone_Enabled = 0;
         AssignProp("", false, edtavNetworkindividualhomephone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNetworkindividualhomephone_Enabled), 5, 0), true);
         edtavNetworkindividualphonecode_Enabled = 0;
         AssignProp("", false, edtavNetworkindividualphonecode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNetworkindividualphonecode_Enabled), 5, 0), true);
         edtavNetworkindividualhomephonecode_Enabled = 0;
         AssignProp("", false, edtavNetworkindividualhomephonecode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNetworkindividualhomephonecode_Enabled), 5, 0), true);
         edtavNetworkindividualphonenumber_Enabled = 0;
         AssignProp("", false, edtavNetworkindividualphonenumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNetworkindividualphonenumber_Enabled), 5, 0), true);
         edtavNetworkindividualhomephonenumber_Enabled = 0;
         AssignProp("", false, edtavNetworkindividualhomephonenumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNetworkindividualhomephonenumber_Enabled), 5, 0), true);
         Combo_networkindividualcountry_Enabled = false;
         ucCombo_networkindividualcountry.SendProperty(context, "", false, Combo_networkindividualcountry_Internalname, "Enabled", StringUtil.BoolToStr( Combo_networkindividualcountry_Enabled));
         Combo_residentcountry_Enabled = false;
         ucCombo_residentcountry.SendProperty(context, "", false, Combo_residentcountry_Internalname, "Enabled", StringUtil.BoolToStr( Combo_residentcountry_Enabled));
         Combo_residentpackageid_Enabled = false;
         ucCombo_residentpackageid.SendProperty(context, "", false, Combo_residentpackageid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_residentpackageid_Enabled));
         Combo_residenttypeid_Enabled = false;
         ucCombo_residenttypeid.SendProperty(context, "", false, Combo_residenttypeid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_residenttypeid_Enabled));
         cmbavNetworkindividualgender.Enabled = 0;
         AssignProp("", false, cmbavNetworkindividualgender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavNetworkindividualgender.Enabled), 5, 0), true);
         edtavNetworkindividualcountry_Enabled = 0;
         AssignProp("", false, edtavNetworkindividualcountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNetworkindividualcountry_Enabled), 5, 0), true);
         edtavNetworkindividualcity_Enabled = 0;
         AssignProp("", false, edtavNetworkindividualcity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNetworkindividualcity_Enabled), 5, 0), true);
         edtavNetworkindividualzipcode_Enabled = 0;
         AssignProp("", false, edtavNetworkindividualzipcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNetworkindividualzipcode_Enabled), 5, 0), true);
         edtavNetworkindividualaddressline1_Enabled = 0;
         AssignProp("", false, edtavNetworkindividualaddressline1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNetworkindividualaddressline1_Enabled), 5, 0), true);
         edtavNetworkindividualaddressline2_Enabled = 0;
         AssignProp("", false, edtavNetworkindividualaddressline2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNetworkindividualaddressline2_Enabled), 5, 0), true);
         cmbavNetworkindividualsalutation.Enabled = 0;
         AssignProp("", false, cmbavNetworkindividualsalutation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavNetworkindividualsalutation.Enabled), 5, 0), true);
         cmbavNetworkindividualrelationship.Enabled = 0;
         AssignProp("", false, cmbavNetworkindividualrelationship_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavNetworkindividualrelationship.Enabled), 5, 0), true);
      }

      protected void S242( )
      {
         /* 'INSERTNETWORKINDIVIDUAL' Routine */
         returnInSub = false;
         AV78Trn_NetworkIndividual = new SdtTrn_NetworkIndividual(context);
         AV78Trn_NetworkIndividual.gxTpr_Networkindividualid = AV11NetworkIndividualId;
         AV78Trn_NetworkIndividual.gxTpr_Networkindividualbsnnumber = AV19NetworkIndividualBsnNumber;
         AV78Trn_NetworkIndividual.gxTpr_Networkindividualgivenname = AV13NetworkIndividualGivenName;
         AV78Trn_NetworkIndividual.gxTpr_Networkindividuallastname = AV14NetworkIndividualLastName;
         AV78Trn_NetworkIndividual.gxTpr_Networkindividualemail = AV16NetworkIndividualEmail;
         AV78Trn_NetworkIndividual.gxTpr_Networkindividualphonecode = AV23NetworkIndividualPhoneCode;
         AV78Trn_NetworkIndividual.gxTpr_Networkindividualhomephonecode = AV21NetworkIndividualHomePhoneCode;
         AV78Trn_NetworkIndividual.gxTpr_Networkindividualphonenumber = AV22NetworkIndividualPhoneNumber;
         AV78Trn_NetworkIndividual.gxTpr_Networkindividualhomephonenumber = AV20NetworkIndividualHomePhoneNumber;
         AV78Trn_NetworkIndividual.gxTpr_Networkindividualrelationship = AV79NetworkIndividualRelationship;
         AV78Trn_NetworkIndividual.gxTpr_Networkindividualgender = AV15NetworkIndividualGender;
         AV78Trn_NetworkIndividual.gxTpr_Networkindividualcountry = AV10NetworkIndividualCountry;
         AV78Trn_NetworkIndividual.gxTpr_Networkindividualcity = AV9NetworkIndividualCity;
         AV78Trn_NetworkIndividual.gxTpr_Networkindividualzipcode = AV8NetworkIndividualZipCode;
         AV78Trn_NetworkIndividual.gxTpr_Networkindividualaddressline1 = AV6NetworkIndividualAddressLine1;
         AV78Trn_NetworkIndividual.gxTpr_Networkindividualaddressline2 = AV7NetworkIndividualAddressLine2;
         AV78Trn_NetworkIndividual.gxTpr_Networkindividualsalutation = AV12NetworkIndividualSalutation;
         if ( StringUtil.StrCmp(AV12NetworkIndividualSalutation, "Other") == 0 )
         {
            AV78Trn_NetworkIndividual.gxTpr_Networkindividualtitle = AV88NetworkIndividualTitle;
         }
         AV78Trn_NetworkIndividual.gxTpr_Residentid = AV74Trn_Resident.gxTpr_Residentid;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13NetworkIndividualGivenName)) || String.IsNullOrEmpty(StringUtil.RTrim( AV14NetworkIndividualLastName)) )
         {
         }
         else
         {
            AV78Trn_NetworkIndividual.Insert();
         }
      }

      protected void S252( )
      {
         /* 'UPDATENETWORKINDIVIDUAL' Routine */
         returnInSub = false;
         /* Using cursor H00BX5 */
         pr_default.execute(3, new Object[] {AV33ResidentId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A62ResidentId = H00BX5_A62ResidentId[0];
            A74NetworkIndividualId = H00BX5_A74NetworkIndividualId[0];
            AV86NetworkIndividualIdToUpdate = A74NetworkIndividualId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(3);
         }
         pr_default.close(3);
         if ( ! (Guid.Empty==AV86NetworkIndividualIdToUpdate) )
         {
            AV78Trn_NetworkIndividual.Load(AV86NetworkIndividualIdToUpdate);
            AV78Trn_NetworkIndividual.gxTpr_Networkindividualid = AV11NetworkIndividualId;
            AV78Trn_NetworkIndividual.gxTpr_Networkindividualbsnnumber = AV19NetworkIndividualBsnNumber;
            AV78Trn_NetworkIndividual.gxTpr_Networkindividualgivenname = AV13NetworkIndividualGivenName;
            AV78Trn_NetworkIndividual.gxTpr_Networkindividuallastname = AV14NetworkIndividualLastName;
            AV78Trn_NetworkIndividual.gxTpr_Networkindividualemail = AV16NetworkIndividualEmail;
            AV78Trn_NetworkIndividual.gxTpr_Networkindividualphonecode = AV23NetworkIndividualPhoneCode;
            AV78Trn_NetworkIndividual.gxTpr_Networkindividualhomephonecode = AV21NetworkIndividualHomePhoneCode;
            AV78Trn_NetworkIndividual.gxTpr_Networkindividualphonenumber = AV22NetworkIndividualPhoneNumber;
            AV78Trn_NetworkIndividual.gxTpr_Networkindividualhomephonenumber = AV20NetworkIndividualHomePhoneNumber;
            AV78Trn_NetworkIndividual.gxTpr_Networkindividualrelationship = AV79NetworkIndividualRelationship;
            AV78Trn_NetworkIndividual.gxTpr_Networkindividualgender = AV15NetworkIndividualGender;
            AV78Trn_NetworkIndividual.gxTpr_Networkindividualcountry = AV10NetworkIndividualCountry;
            AV78Trn_NetworkIndividual.gxTpr_Networkindividualcity = AV9NetworkIndividualCity;
            AV78Trn_NetworkIndividual.gxTpr_Networkindividualzipcode = AV8NetworkIndividualZipCode;
            AV78Trn_NetworkIndividual.gxTpr_Networkindividualaddressline1 = AV6NetworkIndividualAddressLine1;
            AV78Trn_NetworkIndividual.gxTpr_Networkindividualaddressline2 = AV7NetworkIndividualAddressLine2;
            AV78Trn_NetworkIndividual.gxTpr_Networkindividualsalutation = AV12NetworkIndividualSalutation;
            AV78Trn_NetworkIndividual.gxTpr_Residentid = AV74Trn_Resident.gxTpr_Residentid;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13NetworkIndividualGivenName)) || String.IsNullOrEmpty(StringUtil.RTrim( AV14NetworkIndividualLastName)) )
            {
            }
            else
            {
               AV78Trn_NetworkIndividual.Update();
            }
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E15BX2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (string)getParm(obj,0);
         AssignAttri("", false, "Gx_mode", Gx_mode);
         AV33ResidentId = (Guid)getParm(obj,1);
         AssignAttri("", false, "AV33ResidentId", AV33ResidentId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vRESIDENTID", GetSecureSignedToken( "", AV33ResidentId, context));
         AV34LocationId = (Guid)getParm(obj,2);
         AssignAttri("", false, "AV34LocationId", AV34LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", AV34LocationId, context));
         AV35OrganisationId = (Guid)getParm(obj,3);
         AssignAttri("", false, "AV35OrganisationId", AV35OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV35OrganisationId, context));
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
         PABX2( ) ;
         WSBX2( ) ;
         WEBX2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20257267381198", true, true);
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
         context.AddJavascriptSource("wp_createresidentandnetwork.js", "?20257267381199", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
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
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavResidentsalutation.Name = "vRESIDENTSALUTATION";
         cmbavResidentsalutation.WebTags = "";
         cmbavResidentsalutation.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbavResidentsalutation.addItem("Mr", context.GetMessage( "Mr", ""), 0);
         cmbavResidentsalutation.addItem("Mrs", context.GetMessage( "Mrs", ""), 0);
         cmbavResidentsalutation.addItem("Ms", context.GetMessage( "Ms", ""), 0);
         cmbavResidentsalutation.addItem("Other", context.GetMessage( "Other", ""), 0);
         if ( cmbavResidentsalutation.ItemCount > 0 )
         {
            AV36ResidentSalutation = cmbavResidentsalutation.getValidValue(AV36ResidentSalutation);
            AssignAttri("", false, "AV36ResidentSalutation", AV36ResidentSalutation);
         }
         cmbavResidentgender.Name = "vRESIDENTGENDER";
         cmbavResidentgender.WebTags = "";
         cmbavResidentgender.addItem("Male", context.GetMessage( "Male", ""), 0);
         cmbavResidentgender.addItem("Female", context.GetMessage( "Female", ""), 0);
         cmbavResidentgender.addItem("Other", context.GetMessage( "Other", ""), 0);
         if ( cmbavResidentgender.ItemCount > 0 )
         {
            AV40ResidentGender = cmbavResidentgender.getValidValue(AV40ResidentGender);
            AssignAttri("", false, "AV40ResidentGender", AV40ResidentGender);
         }
         cmbavNetworkindividualsalutation.Name = "vNETWORKINDIVIDUALSALUTATION";
         cmbavNetworkindividualsalutation.WebTags = "";
         cmbavNetworkindividualsalutation.addItem("Mr", context.GetMessage( "Mr", ""), 0);
         cmbavNetworkindividualsalutation.addItem("Mrs", context.GetMessage( "Mrs", ""), 0);
         cmbavNetworkindividualsalutation.addItem("Ms", context.GetMessage( "Ms", ""), 0);
         cmbavNetworkindividualsalutation.addItem("Other", context.GetMessage( "Other", ""), 0);
         if ( cmbavNetworkindividualsalutation.ItemCount > 0 )
         {
            AV12NetworkIndividualSalutation = cmbavNetworkindividualsalutation.getValidValue(AV12NetworkIndividualSalutation);
            AssignAttri("", false, "AV12NetworkIndividualSalutation", AV12NetworkIndividualSalutation);
         }
         cmbavNetworkindividualgender.Name = "vNETWORKINDIVIDUALGENDER";
         cmbavNetworkindividualgender.WebTags = "";
         cmbavNetworkindividualgender.addItem("Male", context.GetMessage( "Male", ""), 0);
         cmbavNetworkindividualgender.addItem("Female", context.GetMessage( "Female", ""), 0);
         cmbavNetworkindividualgender.addItem("Other", context.GetMessage( "Other", ""), 0);
         if ( cmbavNetworkindividualgender.ItemCount > 0 )
         {
            AV15NetworkIndividualGender = cmbavNetworkindividualgender.getValidValue(AV15NetworkIndividualGender);
            AssignAttri("", false, "AV15NetworkIndividualGender", AV15NetworkIndividualGender);
         }
         cmbavNetworkindividualrelationship.Name = "vNETWORKINDIVIDUALRELATIONSHIP";
         cmbavNetworkindividualrelationship.WebTags = "";
         cmbavNetworkindividualrelationship.addItem("", context.GetMessage( "Other", ""), 0);
         cmbavNetworkindividualrelationship.addItem("Father", context.GetMessage( "Father", ""), 0);
         cmbavNetworkindividualrelationship.addItem("Mother", context.GetMessage( "Mother", ""), 0);
         cmbavNetworkindividualrelationship.addItem("Daughter", context.GetMessage( "Daughter", ""), 0);
         cmbavNetworkindividualrelationship.addItem("Son", context.GetMessage( "Son", ""), 0);
         cmbavNetworkindividualrelationship.addItem("Aunt", context.GetMessage( "Aunt", ""), 0);
         cmbavNetworkindividualrelationship.addItem("Uncle", context.GetMessage( "Uncle", ""), 0);
         cmbavNetworkindividualrelationship.addItem("GrandMother", context.GetMessage( "GrandMother", ""), 0);
         cmbavNetworkindividualrelationship.addItem("GrandFather", context.GetMessage( "GrandFather", ""), 0);
         cmbavNetworkindividualrelationship.addItem("Cousin", context.GetMessage( "Cousin", ""), 0);
         cmbavNetworkindividualrelationship.addItem("Friend", context.GetMessage( "Friend", ""), 0);
         if ( cmbavNetworkindividualrelationship.ItemCount > 0 )
         {
            AV79NetworkIndividualRelationship = cmbavNetworkindividualrelationship.getValidValue(AV79NetworkIndividualRelationship);
            AssignAttri("", false, "AV79NetworkIndividualRelationship", AV79NetworkIndividualRelationship);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTabgeneral_title_Internalname = "TABGENERAL_TITLE";
         cmbavResidentsalutation_Internalname = "vRESIDENTSALUTATION";
         edtavResidenttitle_Internalname = "vRESIDENTTITLE";
         divResidenttitle_cell_Internalname = "RESIDENTTITLE_CELL";
         edtavResidentgivenname_Internalname = "vRESIDENTGIVENNAME";
         edtavResidentlastname_Internalname = "vRESIDENTLASTNAME";
         cmbavResidentgender_Internalname = "vRESIDENTGENDER";
         edtavResidentbirthdate_Internalname = "vRESIDENTBIRTHDATE";
         edtavResidentemail_Internalname = "vRESIDENTEMAIL";
         lblPhonelabel_Internalname = "PHONELABEL";
         Combo_residentphonecode_Internalname = "COMBO_RESIDENTPHONECODE";
         divUnnamedtable18_Internalname = "UNNAMEDTABLE18";
         edtavResidentphonenumber_Internalname = "vRESIDENTPHONENUMBER";
         divUnnamedtable17_Internalname = "UNNAMEDTABLE17";
         divPhonenumber_Internalname = "PHONENUMBER";
         lblPhone_Internalname = "PHONE";
         Combo_residenthomephonecode_Internalname = "COMBO_RESIDENTHOMEPHONECODE";
         divUnnamedtable16_Internalname = "UNNAMEDTABLE16";
         edtavResidenthomephonenumber_Internalname = "vRESIDENTHOMEPHONENUMBER";
         divUnnamedtable15_Internalname = "UNNAMEDTABLE15";
         divHomephonenumber_Internalname = "HOMEPHONENUMBER";
         edtavResidentphone_Internalname = "vRESIDENTPHONE";
         divResidentphone_cell_Internalname = "RESIDENTPHONE_CELL";
         edtavResidenthomephone_Internalname = "vRESIDENTHOMEPHONE";
         divResidenthomephone_cell_Internalname = "RESIDENTHOMEPHONE_CELL";
         edtavResidentbsnnumber_Internalname = "vRESIDENTBSNNUMBER";
         divUnnamedtable9_Internalname = "UNNAMEDTABLE9";
         grpResidentinfogroup_Internalname = "RESIDENTINFOGROUP";
         edtavResidentaddressline1_Internalname = "vRESIDENTADDRESSLINE1";
         edtavResidentaddressline2_Internalname = "vRESIDENTADDRESSLINE2";
         edtavResidentzipcode_Internalname = "vRESIDENTZIPCODE";
         edtavResidentcity_Internalname = "vRESIDENTCITY";
         lblTextblockcombo_residentcountry_Internalname = "TEXTBLOCKCOMBO_RESIDENTCOUNTRY";
         Combo_residentcountry_Internalname = "COMBO_RESIDENTCOUNTRY";
         divTablesplittedresidentcountry_Internalname = "TABLESPLITTEDRESIDENTCOUNTRY";
         divUnnamedtable11_Internalname = "UNNAMEDTABLE11";
         grpUnnamedgroup12_Internalname = "UNNAMEDGROUP12";
         lblTextblockcombo_residenttypeid_Internalname = "TEXTBLOCKCOMBO_RESIDENTTYPEID";
         Combo_residenttypeid_Internalname = "COMBO_RESIDENTTYPEID";
         divTablesplittedresidenttypeid_Internalname = "TABLESPLITTEDRESIDENTTYPEID";
         lblTextblockcombo_residentpackageid_Internalname = "TEXTBLOCKCOMBO_RESIDENTPACKAGEID";
         Combo_residentpackageid_Internalname = "COMBO_RESIDENTPACKAGEID";
         divTablesplittedresidentpackageid_Internalname = "TABLESPLITTEDRESIDENTPACKAGEID";
         divUnnamedtable13_Internalname = "UNNAMEDTABLE13";
         grpUnnamedgroup14_Internalname = "UNNAMEDGROUP14";
         divUnnamedtable10_Internalname = "UNNAMEDTABLE10";
         divTableattributes1_Internalname = "TABLEATTRIBUTES1";
         divTable1_Internalname = "TABLE1";
         lblTabnextofkin_title_Internalname = "TABNEXTOFKIN_TITLE";
         cmbavNetworkindividualsalutation_Internalname = "vNETWORKINDIVIDUALSALUTATION";
         edtavNetworkindividualtitle_Internalname = "vNETWORKINDIVIDUALTITLE";
         divNetworkindividualtitle_cell_Internalname = "NETWORKINDIVIDUALTITLE_CELL";
         edtavNetworkindividualgivenname_Internalname = "vNETWORKINDIVIDUALGIVENNAME";
         edtavNetworkindividuallastname_Internalname = "vNETWORKINDIVIDUALLASTNAME";
         cmbavNetworkindividualgender_Internalname = "vNETWORKINDIVIDUALGENDER";
         cmbavNetworkindividualrelationship_Internalname = "vNETWORKINDIVIDUALRELATIONSHIP";
         edtavNetworkindividualemail_Internalname = "vNETWORKINDIVIDUALEMAIL";
         lblPhonelabel2_Internalname = "PHONELABEL2";
         Combo_networkindividualphonecode_Internalname = "COMBO_NETWORKINDIVIDUALPHONECODE";
         divUnnamedtable8_Internalname = "UNNAMEDTABLE8";
         edtavNetworkindividualphonenumber_Internalname = "vNETWORKINDIVIDUALPHONENUMBER";
         divUnnamedtable7_Internalname = "UNNAMEDTABLE7";
         divPhonenumber1_Internalname = "PHONENUMBER1";
         lblPhone2_Internalname = "PHONE2";
         Combo_networkindividualhomephonecode_Internalname = "COMBO_NETWORKINDIVIDUALHOMEPHONECODE";
         divUnnamedtable6_Internalname = "UNNAMEDTABLE6";
         edtavNetworkindividualhomephonenumber_Internalname = "vNETWORKINDIVIDUALHOMEPHONENUMBER";
         divUnnamedtable5_Internalname = "UNNAMEDTABLE5";
         divHomephonenumber1_Internalname = "HOMEPHONENUMBER1";
         edtavNetworkindividualphone_Internalname = "vNETWORKINDIVIDUALPHONE";
         divNetworkindividualphone_cell_Internalname = "NETWORKINDIVIDUALPHONE_CELL";
         edtavNetworkindividualhomephone_Internalname = "vNETWORKINDIVIDUALHOMEPHONE";
         divNetworkindividualhomephone_cell_Internalname = "NETWORKINDIVIDUALHOMEPHONE_CELL";
         edtavNetworkindividualbsnnumber_Internalname = "vNETWORKINDIVIDUALBSNNUMBER";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         grpNextofkininfogroup_Internalname = "NEXTOFKININFOGROUP";
         edtavNetworkindividualaddressline1_Internalname = "vNETWORKINDIVIDUALADDRESSLINE1";
         edtavNetworkindividualaddressline2_Internalname = "vNETWORKINDIVIDUALADDRESSLINE2";
         edtavNetworkindividualzipcode_Internalname = "vNETWORKINDIVIDUALZIPCODE";
         edtavNetworkindividualcity_Internalname = "vNETWORKINDIVIDUALCITY";
         lblTextblockcombo_networkindividualcountry_Internalname = "TEXTBLOCKCOMBO_NETWORKINDIVIDUALCOUNTRY";
         Combo_networkindividualcountry_Internalname = "COMBO_NETWORKINDIVIDUALCOUNTRY";
         divTablesplittednetworkindividualcountry_Internalname = "TABLESPLITTEDNETWORKINDIVIDUALCOUNTRY";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         grpUnnamedgroup4_Internalname = "UNNAMEDGROUP4";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         divTableattributes2_Internalname = "TABLEATTRIBUTES2";
         divTable2_Internalname = "TABLE2";
         Gxuitabspanel_tabs_Internalname = "GXUITABSPANEL_TABS";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtavResidentphonecode_Internalname = "vRESIDENTPHONECODE";
         edtavResidenthomephonecode_Internalname = "vRESIDENTHOMEPHONECODE";
         edtavResidentcountry_Internalname = "vRESIDENTCOUNTRY";
         edtavResidenttypeid_Internalname = "vRESIDENTTYPEID";
         edtavNetworkindividualphonecode_Internalname = "vNETWORKINDIVIDUALPHONECODE";
         edtavNetworkindividualhomephonecode_Internalname = "vNETWORKINDIVIDUALHOMEPHONECODE";
         edtavNetworkindividualcountry_Internalname = "vNETWORKINDIVIDUALCOUNTRY";
         edtavNetworkindividualid_Internalname = "vNETWORKINDIVIDUALID";
         edtavSg_organisationid_Internalname = "vSG_ORGANISATIONID";
         edtavSg_locationid_Internalname = "vSG_LOCATIONID";
         edtavResidentid_Internalname = "vRESIDENTID";
         edtavLocationid_Internalname = "vLOCATIONID";
         edtavOrganisationid_Internalname = "vORGANISATIONID";
         edtavResidentinitials_Internalname = "vRESIDENTINITIALS";
         edtavResidentguid_Internalname = "vRESIDENTGUID";
         edtavMedicalindicationid_Internalname = "vMEDICALINDICATIONID";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavMedicalindicationid_Jsonclick = "";
         edtavMedicalindicationid_Enabled = 1;
         edtavMedicalindicationid_Visible = 1;
         edtavResidentguid_Jsonclick = "";
         edtavResidentguid_Enabled = 1;
         edtavResidentguid_Visible = 1;
         edtavResidentinitials_Jsonclick = "";
         edtavResidentinitials_Visible = 1;
         edtavOrganisationid_Jsonclick = "";
         edtavOrganisationid_Visible = 1;
         edtavLocationid_Jsonclick = "";
         edtavLocationid_Visible = 1;
         edtavResidentid_Jsonclick = "";
         edtavResidentid_Visible = 1;
         edtavSg_locationid_Jsonclick = "";
         edtavSg_locationid_Visible = 1;
         edtavSg_organisationid_Jsonclick = "";
         edtavSg_organisationid_Visible = 1;
         edtavNetworkindividualid_Jsonclick = "";
         edtavNetworkindividualid_Visible = 1;
         edtavNetworkindividualcountry_Jsonclick = "";
         edtavNetworkindividualcountry_Enabled = 1;
         edtavNetworkindividualcountry_Visible = 1;
         edtavNetworkindividualhomephonecode_Jsonclick = "";
         edtavNetworkindividualhomephonecode_Enabled = 1;
         edtavNetworkindividualhomephonecode_Visible = 1;
         edtavNetworkindividualphonecode_Jsonclick = "";
         edtavNetworkindividualphonecode_Enabled = 1;
         edtavNetworkindividualphonecode_Visible = 1;
         edtavResidenttypeid_Jsonclick = "";
         edtavResidenttypeid_Enabled = 1;
         edtavResidenttypeid_Visible = 1;
         edtavResidentcountry_Jsonclick = "";
         edtavResidentcountry_Enabled = 1;
         edtavResidentcountry_Visible = 1;
         edtavResidenthomephonecode_Jsonclick = "";
         edtavResidenthomephonecode_Enabled = 1;
         edtavResidenthomephonecode_Visible = 1;
         edtavResidentphonecode_Jsonclick = "";
         edtavResidentphonecode_Enabled = 1;
         edtavResidentphonecode_Visible = 1;
         bttBtnenter_Visible = 1;
         Combo_networkindividualcountry_Caption = "";
         edtavNetworkindividualcity_Jsonclick = "";
         edtavNetworkindividualcity_Enabled = 1;
         edtavNetworkindividualzipcode_Jsonclick = "";
         edtavNetworkindividualzipcode_Enabled = 1;
         edtavNetworkindividualaddressline2_Jsonclick = "";
         edtavNetworkindividualaddressline2_Enabled = 1;
         edtavNetworkindividualaddressline1_Jsonclick = "";
         edtavNetworkindividualaddressline1_Enabled = 1;
         edtavNetworkindividualbsnnumber_Jsonclick = "";
         edtavNetworkindividualbsnnumber_Enabled = 1;
         edtavNetworkindividualhomephone_Jsonclick = "";
         edtavNetworkindividualhomephone_Enabled = 1;
         edtavNetworkindividualhomephone_Visible = 1;
         divNetworkindividualhomephone_cell_Class = "col-xs-12";
         edtavNetworkindividualphone_Jsonclick = "";
         edtavNetworkindividualphone_Enabled = 1;
         edtavNetworkindividualphone_Visible = 1;
         divNetworkindividualphone_cell_Class = "col-xs-12";
         edtavNetworkindividualhomephonenumber_Jsonclick = "";
         edtavNetworkindividualhomephonenumber_Enabled = 1;
         Combo_networkindividualhomephonecode_Caption = "";
         divHomephonenumber1_Visible = 1;
         edtavNetworkindividualphonenumber_Jsonclick = "";
         edtavNetworkindividualphonenumber_Enabled = 1;
         Combo_networkindividualphonecode_Caption = "";
         divPhonenumber1_Visible = 1;
         edtavNetworkindividualemail_Jsonclick = "";
         edtavNetworkindividualemail_Enabled = 1;
         cmbavNetworkindividualrelationship_Jsonclick = "";
         cmbavNetworkindividualrelationship.Enabled = 1;
         cmbavNetworkindividualgender_Jsonclick = "";
         cmbavNetworkindividualgender.Enabled = 1;
         edtavNetworkindividuallastname_Jsonclick = "";
         edtavNetworkindividuallastname_Enabled = 1;
         edtavNetworkindividualgivenname_Jsonclick = "";
         edtavNetworkindividualgivenname_Enabled = 1;
         edtavNetworkindividualtitle_Jsonclick = "";
         edtavNetworkindividualtitle_Enabled = 1;
         edtavNetworkindividualtitle_Visible = 1;
         divNetworkindividualtitle_cell_Class = "col-xs-12";
         cmbavNetworkindividualsalutation_Jsonclick = "";
         cmbavNetworkindividualsalutation.Enabled = 1;
         Combo_residentpackageid_Caption = "";
         lblTextblockcombo_residenttypeid_Caption = context.GetMessage( "Resident Type", "");
         Combo_residentcountry_Caption = "";
         edtavResidentcity_Jsonclick = "";
         edtavResidentcity_Enabled = 1;
         edtavResidentzipcode_Jsonclick = "";
         edtavResidentzipcode_Enabled = 1;
         edtavResidentaddressline2_Jsonclick = "";
         edtavResidentaddressline2_Enabled = 1;
         edtavResidentaddressline1_Jsonclick = "";
         edtavResidentaddressline1_Enabled = 1;
         edtavResidentbsnnumber_Jsonclick = "";
         edtavResidentbsnnumber_Enabled = 1;
         edtavResidenthomephone_Jsonclick = "";
         edtavResidenthomephone_Enabled = 1;
         edtavResidenthomephone_Visible = 1;
         divResidenthomephone_cell_Class = "col-xs-12";
         edtavResidentphone_Jsonclick = "";
         edtavResidentphone_Enabled = 1;
         edtavResidentphone_Visible = 1;
         divResidentphone_cell_Class = "col-xs-12";
         edtavResidenthomephonenumber_Jsonclick = "";
         edtavResidenthomephonenumber_Enabled = 1;
         Combo_residenthomephonecode_Caption = "";
         divHomephonenumber_Visible = 1;
         edtavResidentphonenumber_Jsonclick = "";
         edtavResidentphonenumber_Enabled = 1;
         Combo_residentphonecode_Caption = "";
         divPhonenumber_Visible = 1;
         edtavResidentemail_Jsonclick = "";
         edtavResidentemail_Enabled = 1;
         edtavResidentbirthdate_Jsonclick = "";
         edtavResidentbirthdate_Enabled = 1;
         cmbavResidentgender_Jsonclick = "";
         cmbavResidentgender.Enabled = 1;
         edtavResidentlastname_Jsonclick = "";
         edtavResidentlastname_Enabled = 1;
         edtavResidentgivenname_Jsonclick = "";
         edtavResidentgivenname_Enabled = 1;
         edtavResidenttitle_Jsonclick = "";
         edtavResidenttitle_Enabled = 1;
         edtavResidenttitle_Visible = 1;
         divResidenttitle_cell_Class = "col-xs-12";
         cmbavResidentsalutation_Jsonclick = "";
         cmbavResidentsalutation.Enabled = 1;
         grpResidentinfogroup_Caption = context.GetMessage( "Resident Information", "");
         divLayoutmaintable_Class = "Table TableTransactionTemplate";
         Gxuitabspanel_tabs_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabs_Class = "Tab";
         Gxuitabspanel_tabs_Pagecount = 2;
         Combo_networkindividualcountry_Htmltemplate = "";
         Combo_networkindividualcountry_Emptyitem = Convert.ToBoolean( 0);
         Combo_networkindividualcountry_Enabled = Convert.ToBoolean( -1);
         Combo_networkindividualcountry_Cls = "ExtendedCombo Attribute ExtendedComboWithImage";
         Combo_networkindividualhomephonecode_Htmltemplate = "";
         Combo_networkindividualhomephonecode_Emptyitem = Convert.ToBoolean( 0);
         Combo_networkindividualhomephonecode_Cls = "ExtendedCombo DropDownComponent ExtendedComboWithImage";
         Combo_networkindividualphonecode_Htmltemplate = "";
         Combo_networkindividualphonecode_Emptyitem = Convert.ToBoolean( 0);
         Combo_networkindividualphonecode_Cls = "ExtendedCombo DropDownComponent ExtendedComboWithImage";
         Combo_residentpackageid_Multiplevaluestype = "Tags";
         Combo_residentpackageid_Emptyitem = Convert.ToBoolean( 0);
         Combo_residentpackageid_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_residentpackageid_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_residentpackageid_Enabled = Convert.ToBoolean( -1);
         Combo_residentpackageid_Cls = "ExtendedCombo Attribute";
         Combo_residenttypeid_Emptyitem = Convert.ToBoolean( 0);
         Combo_residenttypeid_Enabled = Convert.ToBoolean( -1);
         Combo_residenttypeid_Cls = "ExtendedCombo Attribute";
         Combo_residentcountry_Htmltemplate = "";
         Combo_residentcountry_Emptyitem = Convert.ToBoolean( 0);
         Combo_residentcountry_Enabled = Convert.ToBoolean( -1);
         Combo_residentcountry_Cls = "ExtendedCombo Attribute ExtendedComboWithImage";
         Combo_residenthomephonecode_Htmltemplate = "";
         Combo_residenthomephonecode_Emptyitem = Convert.ToBoolean( 0);
         Combo_residenthomephonecode_Cls = "ExtendedCombo DropDownComponent ExtendedComboWithImage";
         Combo_residentphonecode_Htmltemplate = "";
         Combo_residentphonecode_Emptyitem = Convert.ToBoolean( 0);
         Combo_residentphonecode_Cls = "ExtendedCombo DropDownComponent ExtendedComboWithImage";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "WP_Create Resident And Network", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV85WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV89ResidentTitleDefinition","fld":"vRESIDENTTITLEDEFINITION","hsh":true},{"av":"AV33ResidentId","fld":"vRESIDENTID","hsh":true},{"av":"AV34LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV35OrganisationId","fld":"vORGANISATIONID","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"ctrl":"BTNENTER","prop":"Visible"}]}""");
         setEventMetadata("COMBO_RESIDENTTYPEID.ONOPTIONCLICKED","""{"handler":"E11BX2","iparms":[{"av":"Combo_residenttypeid_Selectedvalue_get","ctrl":"COMBO_RESIDENTTYPEID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_RESIDENTTYPEID.ONOPTIONCLICKED",""","oparms":[{"av":"AV24ResidentTypeId","fld":"vRESIDENTTYPEID"}]}""");
         setEventMetadata("ENTER","""{"handler":"E14BX2","iparms":[{"av":"AV80CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"cmbavResidentsalutation"},{"av":"AV36ResidentSalutation","fld":"vRESIDENTSALUTATION"},{"av":"AV74Trn_Resident","fld":"vTRN_RESIDENT"},{"av":"AV69ResidentTitle","fld":"vRESIDENTTITLE"},{"av":"AV46ResidentBsnNumber","fld":"vRESIDENTBSNNUMBER"},{"av":"AV37ResidentGivenName","fld":"vRESIDENTGIVENNAME"},{"av":"AV38ResidentLastName","fld":"vRESIDENTLASTNAME"},{"av":"AV42ResidentEmail","fld":"vRESIDENTEMAIL"},{"av":"cmbavResidentgender"},{"av":"AV40ResidentGender","fld":"vRESIDENTGENDER"},{"av":"AV32ResidentCountry","fld":"vRESIDENTCOUNTRY"},{"av":"AV31ResidentCity","fld":"vRESIDENTCITY"},{"av":"AV30ResidentZipCode","fld":"vRESIDENTZIPCODE"},{"av":"AV28ResidentAddressLine1","fld":"vRESIDENTADDRESSLINE1"},{"av":"AV29ResidentAddressLine2","fld":"vRESIDENTADDRESSLINE2"},{"av":"AV41ResidentBirthDate","fld":"vRESIDENTBIRTHDATE"},{"av":"AV24ResidentTypeId","fld":"vRESIDENTTYPEID"},{"av":"AV25ResidentPackageId","fld":"vRESIDENTPACKAGEID"},{"av":"AV51ResidentPhoneCode","fld":"vRESIDENTPHONECODE"},{"av":"AV50ResidentPhoneNumber","fld":"vRESIDENTPHONENUMBER"},{"av":"AV49ResidentHomePhoneCode","fld":"vRESIDENTHOMEPHONECODE"},{"av":"AV85WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV48ResidentHomePhoneNumber","fld":"vRESIDENTHOMEPHONENUMBER"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV89ResidentTitleDefinition","fld":"vRESIDENTTITLEDEFINITION","hsh":true},{"av":"AV11NetworkIndividualId","fld":"vNETWORKINDIVIDUALID"},{"av":"AV19NetworkIndividualBsnNumber","fld":"vNETWORKINDIVIDUALBSNNUMBER"},{"av":"AV13NetworkIndividualGivenName","fld":"vNETWORKINDIVIDUALGIVENNAME"},{"av":"AV14NetworkIndividualLastName","fld":"vNETWORKINDIVIDUALLASTNAME"},{"av":"AV16NetworkIndividualEmail","fld":"vNETWORKINDIVIDUALEMAIL"},{"av":"AV23NetworkIndividualPhoneCode","fld":"vNETWORKINDIVIDUALPHONECODE"},{"av":"AV21NetworkIndividualHomePhoneCode","fld":"vNETWORKINDIVIDUALHOMEPHONECODE"},{"av":"AV22NetworkIndividualPhoneNumber","fld":"vNETWORKINDIVIDUALPHONENUMBER"},{"av":"AV20NetworkIndividualHomePhoneNumber","fld":"vNETWORKINDIVIDUALHOMEPHONENUMBER"},{"av":"cmbavNetworkindividualrelationship"},{"av":"AV79NetworkIndividualRelationship","fld":"vNETWORKINDIVIDUALRELATIONSHIP"},{"av":"cmbavNetworkindividualgender"},{"av":"AV15NetworkIndividualGender","fld":"vNETWORKINDIVIDUALGENDER"},{"av":"AV10NetworkIndividualCountry","fld":"vNETWORKINDIVIDUALCOUNTRY"},{"av":"AV9NetworkIndividualCity","fld":"vNETWORKINDIVIDUALCITY"},{"av":"AV8NetworkIndividualZipCode","fld":"vNETWORKINDIVIDUALZIPCODE"},{"av":"AV6NetworkIndividualAddressLine1","fld":"vNETWORKINDIVIDUALADDRESSLINE1"},{"av":"AV7NetworkIndividualAddressLine2","fld":"vNETWORKINDIVIDUALADDRESSLINE2"},{"av":"cmbavNetworkindividualsalutation"},{"av":"AV12NetworkIndividualSalutation","fld":"vNETWORKINDIVIDUALSALUTATION"},{"av":"AV88NetworkIndividualTitle","fld":"vNETWORKINDIVIDUALTITLE"},{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"AV33ResidentId","fld":"vRESIDENTID","hsh":true},{"av":"A74NetworkIndividualId","fld":"NETWORKINDIVIDUALID"},{"av":"AV81ErrorMessageCollection","fld":"vERRORMESSAGECOLLECTION"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV74Trn_Resident","fld":"vTRN_RESIDENT"},{"av":"AV81ErrorMessageCollection","fld":"vERRORMESSAGECOLLECTION"},{"av":"AV80CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("VALIDV_RESIDENTSALUTATION","""{"handler":"Validv_Residentsalutation","iparms":[]}""");
         setEventMetadata("VALIDV_RESIDENTGENDER","""{"handler":"Validv_Residentgender","iparms":[]}""");
         setEventMetadata("VALIDV_RESIDENTEMAIL","""{"handler":"Validv_Residentemail","iparms":[]}""");
         setEventMetadata("VALIDV_NETWORKINDIVIDUALSALUTATION","""{"handler":"Validv_Networkindividualsalutation","iparms":[]}""");
         setEventMetadata("VALIDV_NETWORKINDIVIDUALGENDER","""{"handler":"Validv_Networkindividualgender","iparms":[]}""");
         setEventMetadata("VALIDV_NETWORKINDIVIDUALEMAIL","""{"handler":"Validv_Networkindividualemail","iparms":[]}""");
         setEventMetadata("VALIDV_RESIDENTTYPEID","""{"handler":"Validv_Residenttypeid","iparms":[]}""");
         setEventMetadata("VALIDV_NETWORKINDIVIDUALID","""{"handler":"Validv_Networkindividualid","iparms":[]}""");
         setEventMetadata("VALIDV_SG_ORGANISATIONID","""{"handler":"Validv_Sg_organisationid","iparms":[]}""");
         setEventMetadata("VALIDV_SG_LOCATIONID","""{"handler":"Validv_Sg_locationid","iparms":[]}""");
         setEventMetadata("VALIDV_MEDICALINDICATIONID","""{"handler":"Validv_Medicalindicationid","iparms":[]}""");
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
         wcpOGx_mode = "";
         wcpOAV33ResidentId = Guid.Empty;
         wcpOAV34LocationId = Guid.Empty;
         wcpOAV35OrganisationId = Guid.Empty;
         Combo_networkindividualcountry_Selectedvalue_get = "";
         Combo_networkindividualhomephonecode_Selectedvalue_get = "";
         Combo_networkindividualphonecode_Selectedvalue_get = "";
         Combo_residentpackageid_Selectedvalue_get = "";
         Combo_residenttypeid_Selectedvalue_get = "";
         Combo_residentcountry_Selectedvalue_get = "";
         Combo_residenthomephonecode_Selectedvalue_get = "";
         Combo_residentphonecode_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV85WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV89ResidentTitleDefinition = "";
         AV54DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV67ResidentPhoneCode_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV65ResidentHomePhoneCode_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV63ResidentCountry_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV61ResidentTypeId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV62ResidentPackageId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV59NetworkIndividualPhoneCode_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV57NetworkIndividualHomePhoneCode_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV53NetworkIndividualCountry_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV74Trn_Resident = new SdtTrn_Resident(context);
         AV25ResidentPackageId = new GxSimpleCollection<Guid>();
         A62ResidentId = Guid.Empty;
         A74NetworkIndividualId = Guid.Empty;
         AV81ErrorMessageCollection = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         Combo_residentphonecode_Selectedvalue_set = "";
         Combo_residentphonecode_Selectedtext_set = "";
         Combo_residenthomephonecode_Selectedvalue_set = "";
         Combo_residenthomephonecode_Selectedtext_set = "";
         Combo_residentcountry_Selectedvalue_set = "";
         Combo_residentcountry_Selectedtext_set = "";
         Combo_residenttypeid_Selectedvalue_set = "";
         Combo_residenttypeid_Selectedtext_set = "";
         Combo_residentpackageid_Selectedvalue_set = "";
         Combo_residentpackageid_Selectedtext_set = "";
         Combo_networkindividualphonecode_Selectedvalue_set = "";
         Combo_networkindividualphonecode_Selectedtext_set = "";
         Combo_networkindividualhomephonecode_Selectedvalue_set = "";
         Combo_networkindividualhomephonecode_Selectedtext_set = "";
         Combo_networkindividualcountry_Selectedvalue_set = "";
         Combo_networkindividualcountry_Selectedtext_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucGxuitabspanel_tabs = new GXUserControl();
         lblTabgeneral_title_Jsonclick = "";
         TempTags = "";
         AV36ResidentSalutation = "";
         AV69ResidentTitle = "";
         AV37ResidentGivenName = "";
         AV38ResidentLastName = "";
         AV40ResidentGender = "";
         AV41ResidentBirthDate = DateTime.MinValue;
         AV42ResidentEmail = "";
         lblPhonelabel_Jsonclick = "";
         ucCombo_residentphonecode = new GXUserControl();
         AV50ResidentPhoneNumber = "";
         lblPhone_Jsonclick = "";
         ucCombo_residenthomephonecode = new GXUserControl();
         AV48ResidentHomePhoneNumber = "";
         AV43ResidentPhone = "";
         AV44ResidentHomePhone = "";
         AV46ResidentBsnNumber = "";
         AV28ResidentAddressLine1 = "";
         AV29ResidentAddressLine2 = "";
         AV30ResidentZipCode = "";
         AV31ResidentCity = "";
         lblTextblockcombo_residentcountry_Jsonclick = "";
         ucCombo_residentcountry = new GXUserControl();
         lblTextblockcombo_residenttypeid_Jsonclick = "";
         ucCombo_residenttypeid = new GXUserControl();
         Combo_residenttypeid_Caption = "";
         lblTextblockcombo_residentpackageid_Jsonclick = "";
         ucCombo_residentpackageid = new GXUserControl();
         lblTabnextofkin_title_Jsonclick = "";
         AV12NetworkIndividualSalutation = "";
         AV88NetworkIndividualTitle = "";
         AV13NetworkIndividualGivenName = "";
         AV14NetworkIndividualLastName = "";
         AV15NetworkIndividualGender = "";
         AV79NetworkIndividualRelationship = "";
         AV16NetworkIndividualEmail = "";
         lblPhonelabel2_Jsonclick = "";
         ucCombo_networkindividualphonecode = new GXUserControl();
         AV22NetworkIndividualPhoneNumber = "";
         lblPhone2_Jsonclick = "";
         ucCombo_networkindividualhomephonecode = new GXUserControl();
         AV20NetworkIndividualHomePhoneNumber = "";
         AV17NetworkIndividualPhone = "";
         AV18NetworkIndividualHomePhone = "";
         AV19NetworkIndividualBsnNumber = "";
         AV6NetworkIndividualAddressLine1 = "";
         AV7NetworkIndividualAddressLine2 = "";
         AV8NetworkIndividualZipCode = "";
         AV9NetworkIndividualCity = "";
         lblTextblockcombo_networkindividualcountry_Jsonclick = "";
         ucCombo_networkindividualcountry = new GXUserControl();
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         AV51ResidentPhoneCode = "";
         AV49ResidentHomePhoneCode = "";
         AV32ResidentCountry = "";
         AV24ResidentTypeId = Guid.Empty;
         AV23NetworkIndividualPhoneCode = "";
         AV21NetworkIndividualHomePhoneCode = "";
         AV10NetworkIndividualCountry = "";
         AV11NetworkIndividualId = Guid.Empty;
         AV26SG_OrganisationId = Guid.Empty;
         AV27SG_LocationId = Guid.Empty;
         AV39ResidentInitials = "";
         AV45ResidentGUID = "";
         AV47MedicalIndicationId = Guid.Empty;
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV71defaultCountryPhoneCode = "";
         AV84defaultCountry = "";
         AV72ComboResidentPhoneCode = "";
         AV73ComboResidentHomePhoneCode = "";
         GXt_char2 = "";
         AV92GXV1 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV56NetworkIndividualCountry_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV55Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         AV52ComboTitles = new GxSimpleCollection<string>();
         AV94GXV3 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV58NetworkIndividualHomePhoneCode_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV96GXV5 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV60NetworkIndividualPhoneCode_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV99Udparg1 = Guid.Empty;
         H00BX2_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         H00BX2_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         H00BX2_A531ResidentPackageName = new string[] {""} ;
         A528SG_LocationId = Guid.Empty;
         A527ResidentPackageId = Guid.Empty;
         A531ResidentPackageName = "";
         H00BX3_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         H00BX3_A97ResidentTypeName = new string[] {""} ;
         A96ResidentTypeId = Guid.Empty;
         A97ResidentTypeName = "";
         AV101GXV7 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV64ResidentCountry_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV103GXV9 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV66ResidentHomePhoneCode_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV105GXV11 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV68ResidentPhoneCode_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV87ActiveLanguageName = "";
         AV83Session = context.GetSession();
         H00BX4_A62ResidentId = new Guid[] {Guid.Empty} ;
         H00BX4_A74NetworkIndividualId = new Guid[] {Guid.Empty} ;
         H00BX4_A75NetworkIndividualBsnNumber = new string[] {""} ;
         H00BX4_A76NetworkIndividualGivenName = new string[] {""} ;
         H00BX4_A77NetworkIndividualLastName = new string[] {""} ;
         H00BX4_A78NetworkIndividualEmail = new string[] {""} ;
         H00BX4_A79NetworkIndividualPhone = new string[] {""} ;
         H00BX4_A433NetworkIndividualHomePhone = new string[] {""} ;
         H00BX4_A359NetworkIndividualPhoneCode = new string[] {""} ;
         H00BX4_A434NetworkIndividualHomePhoneCode = new string[] {""} ;
         H00BX4_A360NetworkIndividualPhoneNumber = new string[] {""} ;
         H00BX4_A435NetworkIndividualHomePhoneNumb = new string[] {""} ;
         H00BX4_A495NetworkIndividualRelationship = new string[] {""} ;
         H00BX4_A81NetworkIndividualGender = new string[] {""} ;
         H00BX4_A322NetworkIndividualCountry = new string[] {""} ;
         H00BX4_A323NetworkIndividualCity = new string[] {""} ;
         H00BX4_A324NetworkIndividualZipCode = new string[] {""} ;
         H00BX4_A325NetworkIndividualAddressLine1 = new string[] {""} ;
         H00BX4_A326NetworkIndividualAddressLine2 = new string[] {""} ;
         H00BX4_A664NetworkIndividualSalutation = new string[] {""} ;
         H00BX4_n664NetworkIndividualSalutation = new bool[] {false} ;
         H00BX4_A668NetworkIndividualTitle = new string[] {""} ;
         H00BX4_n668NetworkIndividualTitle = new bool[] {false} ;
         A75NetworkIndividualBsnNumber = "";
         A76NetworkIndividualGivenName = "";
         A77NetworkIndividualLastName = "";
         A78NetworkIndividualEmail = "";
         A79NetworkIndividualPhone = "";
         A433NetworkIndividualHomePhone = "";
         A359NetworkIndividualPhoneCode = "";
         A434NetworkIndividualHomePhoneCode = "";
         A360NetworkIndividualPhoneNumber = "";
         A435NetworkIndividualHomePhoneNumb = "";
         A495NetworkIndividualRelationship = "";
         A81NetworkIndividualGender = "";
         A322NetworkIndividualCountry = "";
         A323NetworkIndividualCity = "";
         A324NetworkIndividualZipCode = "";
         A325NetworkIndividualAddressLine1 = "";
         A326NetworkIndividualAddressLine2 = "";
         A664NetworkIndividualSalutation = "";
         A668NetworkIndividualTitle = "";
         AV82ErrorMessage = new GeneXus.Utils.SdtMessages_Message(context);
         AV78Trn_NetworkIndividual = new SdtTrn_NetworkIndividual(context);
         H00BX5_A62ResidentId = new Guid[] {Guid.Empty} ;
         H00BX5_A74NetworkIndividualId = new Guid[] {Guid.Empty} ;
         AV86NetworkIndividualIdToUpdate = Guid.Empty;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wp_createresidentandnetwork__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wp_createresidentandnetwork__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_createresidentandnetwork__default(),
            new Object[][] {
                new Object[] {
               H00BX2_A528SG_LocationId, H00BX2_A527ResidentPackageId, H00BX2_A531ResidentPackageName
               }
               , new Object[] {
               H00BX3_A96ResidentTypeId, H00BX3_A97ResidentTypeName
               }
               , new Object[] {
               H00BX4_A62ResidentId, H00BX4_A74NetworkIndividualId, H00BX4_A75NetworkIndividualBsnNumber, H00BX4_A76NetworkIndividualGivenName, H00BX4_A77NetworkIndividualLastName, H00BX4_A78NetworkIndividualEmail, H00BX4_A79NetworkIndividualPhone, H00BX4_A433NetworkIndividualHomePhone, H00BX4_A359NetworkIndividualPhoneCode, H00BX4_A434NetworkIndividualHomePhoneCode,
               H00BX4_A360NetworkIndividualPhoneNumber, H00BX4_A435NetworkIndividualHomePhoneNumb, H00BX4_A495NetworkIndividualRelationship, H00BX4_A81NetworkIndividualGender, H00BX4_A322NetworkIndividualCountry, H00BX4_A323NetworkIndividualCity, H00BX4_A324NetworkIndividualZipCode, H00BX4_A325NetworkIndividualAddressLine1, H00BX4_A326NetworkIndividualAddressLine2, H00BX4_A664NetworkIndividualSalutation,
               H00BX4_n664NetworkIndividualSalutation, H00BX4_A668NetworkIndividualTitle, H00BX4_n668NetworkIndividualTitle
               }
               , new Object[] {
               H00BX5_A62ResidentId, H00BX5_A74NetworkIndividualId
               }
            }
         );
         /* GeneXus formulas. */
      }

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
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int Gxuitabspanel_tabs_Pagecount ;
      private int edtavResidenttitle_Visible ;
      private int edtavResidenttitle_Enabled ;
      private int edtavResidentgivenname_Enabled ;
      private int edtavResidentlastname_Enabled ;
      private int edtavResidentbirthdate_Enabled ;
      private int edtavResidentemail_Enabled ;
      private int divPhonenumber_Visible ;
      private int edtavResidentphonenumber_Enabled ;
      private int divHomephonenumber_Visible ;
      private int edtavResidenthomephonenumber_Enabled ;
      private int edtavResidentphone_Visible ;
      private int edtavResidentphone_Enabled ;
      private int edtavResidenthomephone_Visible ;
      private int edtavResidenthomephone_Enabled ;
      private int edtavResidentbsnnumber_Enabled ;
      private int edtavResidentaddressline1_Enabled ;
      private int edtavResidentaddressline2_Enabled ;
      private int edtavResidentzipcode_Enabled ;
      private int edtavResidentcity_Enabled ;
      private int edtavNetworkindividualtitle_Visible ;
      private int edtavNetworkindividualtitle_Enabled ;
      private int edtavNetworkindividualgivenname_Enabled ;
      private int edtavNetworkindividuallastname_Enabled ;
      private int edtavNetworkindividualemail_Enabled ;
      private int divPhonenumber1_Visible ;
      private int edtavNetworkindividualphonenumber_Enabled ;
      private int divHomephonenumber1_Visible ;
      private int edtavNetworkindividualhomephonenumber_Enabled ;
      private int edtavNetworkindividualphone_Visible ;
      private int edtavNetworkindividualphone_Enabled ;
      private int edtavNetworkindividualhomephone_Visible ;
      private int edtavNetworkindividualhomephone_Enabled ;
      private int edtavNetworkindividualbsnnumber_Enabled ;
      private int edtavNetworkindividualaddressline1_Enabled ;
      private int edtavNetworkindividualaddressline2_Enabled ;
      private int edtavNetworkindividualzipcode_Enabled ;
      private int edtavNetworkindividualcity_Enabled ;
      private int bttBtnenter_Visible ;
      private int edtavResidentphonecode_Visible ;
      private int edtavResidentphonecode_Enabled ;
      private int edtavResidenthomephonecode_Visible ;
      private int edtavResidenthomephonecode_Enabled ;
      private int edtavResidentcountry_Visible ;
      private int edtavResidentcountry_Enabled ;
      private int edtavResidenttypeid_Visible ;
      private int edtavResidenttypeid_Enabled ;
      private int edtavNetworkindividualphonecode_Visible ;
      private int edtavNetworkindividualphonecode_Enabled ;
      private int edtavNetworkindividualhomephonecode_Visible ;
      private int edtavNetworkindividualhomephonecode_Enabled ;
      private int edtavNetworkindividualcountry_Visible ;
      private int edtavNetworkindividualcountry_Enabled ;
      private int edtavNetworkindividualid_Visible ;
      private int edtavSg_organisationid_Visible ;
      private int edtavSg_locationid_Visible ;
      private int edtavResidentid_Visible ;
      private int edtavLocationid_Visible ;
      private int edtavOrganisationid_Visible ;
      private int edtavResidentinitials_Visible ;
      private int edtavResidentguid_Visible ;
      private int edtavResidentguid_Enabled ;
      private int edtavMedicalindicationid_Visible ;
      private int edtavMedicalindicationid_Enabled ;
      private int AV93GXV2 ;
      private int AV95GXV4 ;
      private int AV97GXV6 ;
      private int AV102GXV8 ;
      private int AV104GXV10 ;
      private int AV106GXV12 ;
      private int AV108GXV13 ;
      private int idxLst ;
      private string Gx_mode ;
      private string wcpOGx_mode ;
      private string Combo_networkindividualcountry_Selectedvalue_get ;
      private string Combo_networkindividualhomephonecode_Selectedvalue_get ;
      private string Combo_networkindividualphonecode_Selectedvalue_get ;
      private string Combo_residentpackageid_Selectedvalue_get ;
      private string Combo_residenttypeid_Selectedvalue_get ;
      private string Combo_residentcountry_Selectedvalue_get ;
      private string Combo_residenthomephonecode_Selectedvalue_get ;
      private string Combo_residentphonecode_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Combo_residentphonecode_Cls ;
      private string Combo_residentphonecode_Selectedvalue_set ;
      private string Combo_residentphonecode_Selectedtext_set ;
      private string Combo_residentphonecode_Htmltemplate ;
      private string Combo_residenthomephonecode_Cls ;
      private string Combo_residenthomephonecode_Selectedvalue_set ;
      private string Combo_residenthomephonecode_Selectedtext_set ;
      private string Combo_residenthomephonecode_Htmltemplate ;
      private string Combo_residentcountry_Cls ;
      private string Combo_residentcountry_Selectedvalue_set ;
      private string Combo_residentcountry_Selectedtext_set ;
      private string Combo_residentcountry_Htmltemplate ;
      private string Combo_residenttypeid_Cls ;
      private string Combo_residenttypeid_Selectedvalue_set ;
      private string Combo_residenttypeid_Selectedtext_set ;
      private string Combo_residentpackageid_Cls ;
      private string Combo_residentpackageid_Selectedvalue_set ;
      private string Combo_residentpackageid_Selectedtext_set ;
      private string Combo_residentpackageid_Multiplevaluestype ;
      private string Combo_networkindividualphonecode_Cls ;
      private string Combo_networkindividualphonecode_Selectedvalue_set ;
      private string Combo_networkindividualphonecode_Selectedtext_set ;
      private string Combo_networkindividualphonecode_Htmltemplate ;
      private string Combo_networkindividualhomephonecode_Cls ;
      private string Combo_networkindividualhomephonecode_Selectedvalue_set ;
      private string Combo_networkindividualhomephonecode_Selectedtext_set ;
      private string Combo_networkindividualhomephonecode_Htmltemplate ;
      private string Combo_networkindividualcountry_Cls ;
      private string Combo_networkindividualcountry_Selectedvalue_set ;
      private string Combo_networkindividualcountry_Selectedtext_set ;
      private string Combo_networkindividualcountry_Htmltemplate ;
      private string Gxuitabspanel_tabs_Class ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string Gxuitabspanel_tabs_Internalname ;
      private string lblTabgeneral_title_Internalname ;
      private string lblTabgeneral_title_Jsonclick ;
      private string divTable1_Internalname ;
      private string divTableattributes1_Internalname ;
      private string grpResidentinfogroup_Internalname ;
      private string grpResidentinfogroup_Caption ;
      private string divUnnamedtable9_Internalname ;
      private string cmbavResidentsalutation_Internalname ;
      private string TempTags ;
      private string AV36ResidentSalutation ;
      private string cmbavResidentsalutation_Jsonclick ;
      private string divResidenttitle_cell_Internalname ;
      private string divResidenttitle_cell_Class ;
      private string edtavResidenttitle_Internalname ;
      private string edtavResidenttitle_Jsonclick ;
      private string edtavResidentgivenname_Internalname ;
      private string edtavResidentgivenname_Jsonclick ;
      private string edtavResidentlastname_Internalname ;
      private string edtavResidentlastname_Jsonclick ;
      private string cmbavResidentgender_Internalname ;
      private string cmbavResidentgender_Jsonclick ;
      private string edtavResidentbirthdate_Internalname ;
      private string edtavResidentbirthdate_Jsonclick ;
      private string edtavResidentemail_Internalname ;
      private string edtavResidentemail_Jsonclick ;
      private string divPhonenumber_Internalname ;
      private string lblPhonelabel_Internalname ;
      private string lblPhonelabel_Jsonclick ;
      private string divUnnamedtable17_Internalname ;
      private string divUnnamedtable18_Internalname ;
      private string Combo_residentphonecode_Caption ;
      private string Combo_residentphonecode_Internalname ;
      private string edtavResidentphonenumber_Internalname ;
      private string edtavResidentphonenumber_Jsonclick ;
      private string divHomephonenumber_Internalname ;
      private string lblPhone_Internalname ;
      private string lblPhone_Jsonclick ;
      private string divUnnamedtable15_Internalname ;
      private string divUnnamedtable16_Internalname ;
      private string Combo_residenthomephonecode_Caption ;
      private string Combo_residenthomephonecode_Internalname ;
      private string edtavResidenthomephonenumber_Internalname ;
      private string edtavResidenthomephonenumber_Jsonclick ;
      private string divResidentphone_cell_Internalname ;
      private string divResidentphone_cell_Class ;
      private string edtavResidentphone_Internalname ;
      private string AV43ResidentPhone ;
      private string edtavResidentphone_Jsonclick ;
      private string divResidenthomephone_cell_Internalname ;
      private string divResidenthomephone_cell_Class ;
      private string edtavResidenthomephone_Internalname ;
      private string AV44ResidentHomePhone ;
      private string edtavResidenthomephone_Jsonclick ;
      private string edtavResidentbsnnumber_Internalname ;
      private string edtavResidentbsnnumber_Jsonclick ;
      private string divUnnamedtable10_Internalname ;
      private string grpUnnamedgroup12_Internalname ;
      private string divUnnamedtable11_Internalname ;
      private string edtavResidentaddressline1_Internalname ;
      private string edtavResidentaddressline1_Jsonclick ;
      private string edtavResidentaddressline2_Internalname ;
      private string edtavResidentaddressline2_Jsonclick ;
      private string edtavResidentzipcode_Internalname ;
      private string edtavResidentzipcode_Jsonclick ;
      private string edtavResidentcity_Internalname ;
      private string edtavResidentcity_Jsonclick ;
      private string divTablesplittedresidentcountry_Internalname ;
      private string lblTextblockcombo_residentcountry_Internalname ;
      private string lblTextblockcombo_residentcountry_Jsonclick ;
      private string Combo_residentcountry_Caption ;
      private string Combo_residentcountry_Internalname ;
      private string grpUnnamedgroup14_Internalname ;
      private string divUnnamedtable13_Internalname ;
      private string divTablesplittedresidenttypeid_Internalname ;
      private string lblTextblockcombo_residenttypeid_Internalname ;
      private string lblTextblockcombo_residenttypeid_Caption ;
      private string lblTextblockcombo_residenttypeid_Jsonclick ;
      private string Combo_residenttypeid_Caption ;
      private string Combo_residenttypeid_Internalname ;
      private string divTablesplittedresidentpackageid_Internalname ;
      private string lblTextblockcombo_residentpackageid_Internalname ;
      private string lblTextblockcombo_residentpackageid_Jsonclick ;
      private string Combo_residentpackageid_Caption ;
      private string Combo_residentpackageid_Internalname ;
      private string lblTabnextofkin_title_Internalname ;
      private string lblTabnextofkin_title_Jsonclick ;
      private string divTable2_Internalname ;
      private string divTableattributes2_Internalname ;
      private string grpNextofkininfogroup_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string cmbavNetworkindividualsalutation_Internalname ;
      private string AV12NetworkIndividualSalutation ;
      private string cmbavNetworkindividualsalutation_Jsonclick ;
      private string divNetworkindividualtitle_cell_Internalname ;
      private string divNetworkindividualtitle_cell_Class ;
      private string edtavNetworkindividualtitle_Internalname ;
      private string edtavNetworkindividualtitle_Jsonclick ;
      private string edtavNetworkindividualgivenname_Internalname ;
      private string edtavNetworkindividualgivenname_Jsonclick ;
      private string edtavNetworkindividuallastname_Internalname ;
      private string edtavNetworkindividuallastname_Jsonclick ;
      private string cmbavNetworkindividualgender_Internalname ;
      private string cmbavNetworkindividualgender_Jsonclick ;
      private string cmbavNetworkindividualrelationship_Internalname ;
      private string cmbavNetworkindividualrelationship_Jsonclick ;
      private string edtavNetworkindividualemail_Internalname ;
      private string edtavNetworkindividualemail_Jsonclick ;
      private string divPhonenumber1_Internalname ;
      private string lblPhonelabel2_Internalname ;
      private string lblPhonelabel2_Jsonclick ;
      private string divUnnamedtable7_Internalname ;
      private string divUnnamedtable8_Internalname ;
      private string Combo_networkindividualphonecode_Caption ;
      private string Combo_networkindividualphonecode_Internalname ;
      private string edtavNetworkindividualphonenumber_Internalname ;
      private string edtavNetworkindividualphonenumber_Jsonclick ;
      private string divHomephonenumber1_Internalname ;
      private string lblPhone2_Internalname ;
      private string lblPhone2_Jsonclick ;
      private string divUnnamedtable5_Internalname ;
      private string divUnnamedtable6_Internalname ;
      private string Combo_networkindividualhomephonecode_Caption ;
      private string Combo_networkindividualhomephonecode_Internalname ;
      private string edtavNetworkindividualhomephonenumber_Internalname ;
      private string edtavNetworkindividualhomephonenumber_Jsonclick ;
      private string divNetworkindividualphone_cell_Internalname ;
      private string divNetworkindividualphone_cell_Class ;
      private string edtavNetworkindividualphone_Internalname ;
      private string AV17NetworkIndividualPhone ;
      private string edtavNetworkindividualphone_Jsonclick ;
      private string divNetworkindividualhomephone_cell_Internalname ;
      private string divNetworkindividualhomephone_cell_Class ;
      private string edtavNetworkindividualhomephone_Internalname ;
      private string AV18NetworkIndividualHomePhone ;
      private string edtavNetworkindividualhomephone_Jsonclick ;
      private string edtavNetworkindividualbsnnumber_Internalname ;
      private string edtavNetworkindividualbsnnumber_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string grpUnnamedgroup4_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string edtavNetworkindividualaddressline1_Internalname ;
      private string edtavNetworkindividualaddressline1_Jsonclick ;
      private string edtavNetworkindividualaddressline2_Internalname ;
      private string edtavNetworkindividualaddressline2_Jsonclick ;
      private string edtavNetworkindividualzipcode_Internalname ;
      private string edtavNetworkindividualzipcode_Jsonclick ;
      private string edtavNetworkindividualcity_Internalname ;
      private string edtavNetworkindividualcity_Jsonclick ;
      private string divTablesplittednetworkindividualcountry_Internalname ;
      private string lblTextblockcombo_networkindividualcountry_Internalname ;
      private string lblTextblockcombo_networkindividualcountry_Jsonclick ;
      private string Combo_networkindividualcountry_Caption ;
      private string Combo_networkindividualcountry_Internalname ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavResidentphonecode_Internalname ;
      private string edtavResidentphonecode_Jsonclick ;
      private string edtavResidenthomephonecode_Internalname ;
      private string edtavResidenthomephonecode_Jsonclick ;
      private string edtavResidentcountry_Internalname ;
      private string edtavResidentcountry_Jsonclick ;
      private string edtavResidenttypeid_Internalname ;
      private string edtavResidenttypeid_Jsonclick ;
      private string edtavNetworkindividualphonecode_Internalname ;
      private string edtavNetworkindividualphonecode_Jsonclick ;
      private string edtavNetworkindividualhomephonecode_Internalname ;
      private string edtavNetworkindividualhomephonecode_Jsonclick ;
      private string edtavNetworkindividualcountry_Internalname ;
      private string edtavNetworkindividualcountry_Jsonclick ;
      private string edtavNetworkindividualid_Internalname ;
      private string edtavNetworkindividualid_Jsonclick ;
      private string edtavSg_organisationid_Internalname ;
      private string edtavSg_organisationid_Jsonclick ;
      private string edtavSg_locationid_Internalname ;
      private string edtavSg_locationid_Jsonclick ;
      private string edtavResidentid_Internalname ;
      private string edtavResidentid_Jsonclick ;
      private string edtavLocationid_Internalname ;
      private string edtavLocationid_Jsonclick ;
      private string edtavOrganisationid_Internalname ;
      private string edtavOrganisationid_Jsonclick ;
      private string edtavResidentinitials_Internalname ;
      private string AV39ResidentInitials ;
      private string edtavResidentinitials_Jsonclick ;
      private string edtavResidentguid_Internalname ;
      private string edtavResidentguid_Jsonclick ;
      private string edtavMedicalindicationid_Internalname ;
      private string edtavMedicalindicationid_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string GXt_char2 ;
      private string A79NetworkIndividualPhone ;
      private string A433NetworkIndividualHomePhone ;
      private string A664NetworkIndividualSalutation ;
      private DateTime AV41ResidentBirthDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV80CheckRequiredFieldsResult ;
      private bool Combo_residentphonecode_Emptyitem ;
      private bool Combo_residenthomephonecode_Emptyitem ;
      private bool Combo_residentcountry_Enabled ;
      private bool Combo_residentcountry_Emptyitem ;
      private bool Combo_residenttypeid_Enabled ;
      private bool Combo_residenttypeid_Emptyitem ;
      private bool Combo_residentpackageid_Enabled ;
      private bool Combo_residentpackageid_Allowmultipleselection ;
      private bool Combo_residentpackageid_Includeonlyselectedoption ;
      private bool Combo_residentpackageid_Emptyitem ;
      private bool Combo_networkindividualphonecode_Emptyitem ;
      private bool Combo_networkindividualhomephonecode_Emptyitem ;
      private bool Combo_networkindividualcountry_Enabled ;
      private bool Combo_networkindividualcountry_Emptyitem ;
      private bool Gxuitabspanel_tabs_Historymanagement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n664NetworkIndividualSalutation ;
      private bool n668NetworkIndividualTitle ;
      private string AV89ResidentTitleDefinition ;
      private string AV69ResidentTitle ;
      private string AV37ResidentGivenName ;
      private string AV38ResidentLastName ;
      private string AV40ResidentGender ;
      private string AV42ResidentEmail ;
      private string AV50ResidentPhoneNumber ;
      private string AV48ResidentHomePhoneNumber ;
      private string AV46ResidentBsnNumber ;
      private string AV28ResidentAddressLine1 ;
      private string AV29ResidentAddressLine2 ;
      private string AV30ResidentZipCode ;
      private string AV31ResidentCity ;
      private string AV88NetworkIndividualTitle ;
      private string AV13NetworkIndividualGivenName ;
      private string AV14NetworkIndividualLastName ;
      private string AV15NetworkIndividualGender ;
      private string AV79NetworkIndividualRelationship ;
      private string AV16NetworkIndividualEmail ;
      private string AV22NetworkIndividualPhoneNumber ;
      private string AV20NetworkIndividualHomePhoneNumber ;
      private string AV19NetworkIndividualBsnNumber ;
      private string AV6NetworkIndividualAddressLine1 ;
      private string AV7NetworkIndividualAddressLine2 ;
      private string AV8NetworkIndividualZipCode ;
      private string AV9NetworkIndividualCity ;
      private string AV51ResidentPhoneCode ;
      private string AV49ResidentHomePhoneCode ;
      private string AV32ResidentCountry ;
      private string AV23NetworkIndividualPhoneCode ;
      private string AV21NetworkIndividualHomePhoneCode ;
      private string AV10NetworkIndividualCountry ;
      private string AV45ResidentGUID ;
      private string AV71defaultCountryPhoneCode ;
      private string AV84defaultCountry ;
      private string AV72ComboResidentPhoneCode ;
      private string AV73ComboResidentHomePhoneCode ;
      private string A531ResidentPackageName ;
      private string A97ResidentTypeName ;
      private string AV87ActiveLanguageName ;
      private string A75NetworkIndividualBsnNumber ;
      private string A76NetworkIndividualGivenName ;
      private string A77NetworkIndividualLastName ;
      private string A78NetworkIndividualEmail ;
      private string A359NetworkIndividualPhoneCode ;
      private string A434NetworkIndividualHomePhoneCode ;
      private string A360NetworkIndividualPhoneNumber ;
      private string A435NetworkIndividualHomePhoneNumb ;
      private string A495NetworkIndividualRelationship ;
      private string A81NetworkIndividualGender ;
      private string A322NetworkIndividualCountry ;
      private string A323NetworkIndividualCity ;
      private string A324NetworkIndividualZipCode ;
      private string A325NetworkIndividualAddressLine1 ;
      private string A326NetworkIndividualAddressLine2 ;
      private string A668NetworkIndividualTitle ;
      private Guid AV33ResidentId ;
      private Guid AV34LocationId ;
      private Guid AV35OrganisationId ;
      private Guid wcpOAV33ResidentId ;
      private Guid wcpOAV34LocationId ;
      private Guid wcpOAV35OrganisationId ;
      private Guid A62ResidentId ;
      private Guid A74NetworkIndividualId ;
      private Guid AV24ResidentTypeId ;
      private Guid AV11NetworkIndividualId ;
      private Guid AV26SG_OrganisationId ;
      private Guid AV27SG_LocationId ;
      private Guid AV47MedicalIndicationId ;
      private Guid AV99Udparg1 ;
      private Guid A528SG_LocationId ;
      private Guid A527ResidentPackageId ;
      private Guid A96ResidentTypeId ;
      private Guid AV86NetworkIndividualIdToUpdate ;
      private GXUserControl ucGxuitabspanel_tabs ;
      private GXUserControl ucCombo_residentphonecode ;
      private GXUserControl ucCombo_residenthomephonecode ;
      private GXUserControl ucCombo_residentcountry ;
      private GXUserControl ucCombo_residenttypeid ;
      private GXUserControl ucCombo_residentpackageid ;
      private GXUserControl ucCombo_networkindividualphonecode ;
      private GXUserControl ucCombo_networkindividualhomephonecode ;
      private GXUserControl ucCombo_networkindividualcountry ;
      private IGxSession AV83Session ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavResidentsalutation ;
      private GXCombobox cmbavResidentgender ;
      private GXCombobox cmbavNetworkindividualsalutation ;
      private GXCombobox cmbavNetworkindividualgender ;
      private GXCombobox cmbavNetworkindividualrelationship ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV85WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV54DDO_TitleSettingsIcons ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV67ResidentPhoneCode_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV65ResidentHomePhoneCode_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV63ResidentCountry_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV61ResidentTypeId_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV62ResidentPackageId_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV59NetworkIndividualPhoneCode_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV57NetworkIndividualHomePhoneCode_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV53NetworkIndividualCountry_Data ;
      private SdtTrn_Resident AV74Trn_Resident ;
      private GxSimpleCollection<Guid> AV25ResidentPackageId ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV81ErrorMessageCollection ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV92GXV1 ;
      private SdtSDT_Country_SDT_CountryItem AV56NetworkIndividualCountry_DPItem ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV55Combo_DataItem ;
      private GxSimpleCollection<string> AV52ComboTitles ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV94GXV3 ;
      private SdtSDT_Country_SDT_CountryItem AV58NetworkIndividualHomePhoneCode_DPItem ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV96GXV5 ;
      private SdtSDT_Country_SDT_CountryItem AV60NetworkIndividualPhoneCode_DPItem ;
      private IDataStoreProvider pr_default ;
      private Guid[] H00BX2_A528SG_LocationId ;
      private Guid[] H00BX2_A527ResidentPackageId ;
      private string[] H00BX2_A531ResidentPackageName ;
      private Guid[] H00BX3_A96ResidentTypeId ;
      private string[] H00BX3_A97ResidentTypeName ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV101GXV7 ;
      private SdtSDT_Country_SDT_CountryItem AV64ResidentCountry_DPItem ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV103GXV9 ;
      private SdtSDT_Country_SDT_CountryItem AV66ResidentHomePhoneCode_DPItem ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV105GXV11 ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> GXt_objcol_SdtSDT_Country_SDT_CountryItem3 ;
      private SdtSDT_Country_SDT_CountryItem AV68ResidentPhoneCode_DPItem ;
      private Guid[] H00BX4_A62ResidentId ;
      private Guid[] H00BX4_A74NetworkIndividualId ;
      private string[] H00BX4_A75NetworkIndividualBsnNumber ;
      private string[] H00BX4_A76NetworkIndividualGivenName ;
      private string[] H00BX4_A77NetworkIndividualLastName ;
      private string[] H00BX4_A78NetworkIndividualEmail ;
      private string[] H00BX4_A79NetworkIndividualPhone ;
      private string[] H00BX4_A433NetworkIndividualHomePhone ;
      private string[] H00BX4_A359NetworkIndividualPhoneCode ;
      private string[] H00BX4_A434NetworkIndividualHomePhoneCode ;
      private string[] H00BX4_A360NetworkIndividualPhoneNumber ;
      private string[] H00BX4_A435NetworkIndividualHomePhoneNumb ;
      private string[] H00BX4_A495NetworkIndividualRelationship ;
      private string[] H00BX4_A81NetworkIndividualGender ;
      private string[] H00BX4_A322NetworkIndividualCountry ;
      private string[] H00BX4_A323NetworkIndividualCity ;
      private string[] H00BX4_A324NetworkIndividualZipCode ;
      private string[] H00BX4_A325NetworkIndividualAddressLine1 ;
      private string[] H00BX4_A326NetworkIndividualAddressLine2 ;
      private string[] H00BX4_A664NetworkIndividualSalutation ;
      private bool[] H00BX4_n664NetworkIndividualSalutation ;
      private string[] H00BX4_A668NetworkIndividualTitle ;
      private bool[] H00BX4_n668NetworkIndividualTitle ;
      private GeneXus.Utils.SdtMessages_Message AV82ErrorMessage ;
      private SdtTrn_NetworkIndividual AV78Trn_NetworkIndividual ;
      private Guid[] H00BX5_A62ResidentId ;
      private Guid[] H00BX5_A74NetworkIndividualId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wp_createresidentandnetwork__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wp_createresidentandnetwork__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wp_createresidentandnetwork__default : DataStoreHelperBase, IDataStoreHelper
{
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
       Object[] prmH00BX2;
       prmH00BX2 = new Object[] {
       new ParDef("AV99Udparg1",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmH00BX3;
       prmH00BX3 = new Object[] {
       };
       Object[] prmH00BX4;
       prmH00BX4 = new Object[] {
       new ParDef("AV74Trn_Resident__Residentid",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmH00BX5;
       prmH00BX5 = new Object[] {
       new ParDef("AV33ResidentId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("H00BX2", "SELECT SG_LocationId, ResidentPackageId, ResidentPackageName FROM Trn_ResidentPackage WHERE SG_LocationId = :AV99Udparg1 ORDER BY ResidentPackageName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BX2,100, GxCacheFrequency.OFF ,false,false )
          ,new CursorDef("H00BX3", "SELECT ResidentTypeId, ResidentTypeName FROM Trn_ResidentType ORDER BY ResidentTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BX3,100, GxCacheFrequency.OFF ,false,false )
          ,new CursorDef("H00BX4", "SELECT ResidentId, NetworkIndividualId, NetworkIndividualBsnNumber, NetworkIndividualGivenName, NetworkIndividualLastName, NetworkIndividualEmail, NetworkIndividualPhone, NetworkIndividualHomePhone, NetworkIndividualPhoneCode, NetworkIndividualHomePhoneCode, NetworkIndividualPhoneNumber, NetworkIndividualHomePhoneNumb, NetworkIndividualRelationship, NetworkIndividualGender, NetworkIndividualCountry, NetworkIndividualCity, NetworkIndividualZipCode, NetworkIndividualAddressLine1, NetworkIndividualAddressLine2, NetworkIndividualSalutation, NetworkIndividualTitle FROM Trn_NetworkIndividual WHERE ResidentId = :AV74Trn_Resident__Residentid ORDER BY NetworkIndividualId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BX4,100, GxCacheFrequency.OFF ,false,false )
          ,new CursorDef("H00BX5", "SELECT ResidentId, NetworkIndividualId FROM Trn_NetworkIndividual WHERE ResidentId = :AV33ResidentId ORDER BY NetworkIndividualId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BX5,1, GxCacheFrequency.OFF ,false,true )
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
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getString(7, 20);
             ((string[]) buf[7])[0] = rslt.getString(8, 20);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((string[]) buf[15])[0] = rslt.getVarchar(16);
             ((string[]) buf[16])[0] = rslt.getVarchar(17);
             ((string[]) buf[17])[0] = rslt.getVarchar(18);
             ((string[]) buf[18])[0] = rslt.getVarchar(19);
             ((string[]) buf[19])[0] = rslt.getString(20, 20);
             ((bool[]) buf[20])[0] = rslt.wasNull(20);
             ((string[]) buf[21])[0] = rslt.getVarchar(21);
             ((bool[]) buf[22])[0] = rslt.wasNull(21);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
    }
 }

}

}
