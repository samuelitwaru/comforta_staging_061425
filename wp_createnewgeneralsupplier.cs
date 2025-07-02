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
   public class wp_createnewgeneralsupplier : GXDataArea
   {
      public wp_createnewgeneralsupplier( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_createnewgeneralsupplier( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_TrnMode ,
                           Guid aP1_SupplierGenId )
      {
         this.AV16TrnMode = aP0_TrnMode;
         this.AV20SupplierGenId = aP1_SupplierGenId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavIspreffered = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "TrnMode");
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
               gxfirstwebparm = GetFirstPar( "TrnMode");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "TrnMode");
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
            return GAMSecurityLevel.SecurityLow ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpageprompt", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpageprompt", new Object[] {context});
            MasterPageObj.setDataArea(this,true);
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
         PA7Y2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START7Y2( ) ;
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
         context.WriteHtmlText( " "+"class=\"form-horizontal FormNoBackgroundColor\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wp_createnewgeneralsupplier.aspx"+UrlEncode(StringUtil.RTrim(AV16TrnMode)) + "," + UrlEncode(AV20SupplierGenId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormNoBackgroundColor\" data-gx-class=\"form-horizontal FormNoBackgroundColor\" novalidate action=\""+formatLink("wp_createnewgeneralsupplier.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal FormNoBackgroundColor", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV16TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV16TrnMode, "")), context));
         GxWebStd.gx_hidden_field( context, "vSUPPLIERGENID", AV20SupplierGenId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vSUPPLIERGENID", GetSecureSignedToken( "", AV20SupplierGenId, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Trn_suppliergen", AV7Trn_SupplierGen);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Trn_suppliergen", AV7Trn_SupplierGen);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRN_SUPPLIERGEN_SUPPLIERGENTYPEID_DATA", AV8Trn_SupplierGen_SupplierGenTypeId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRN_SUPPLIERGEN_SUPPLIERGENTYPEID_DATA", AV8Trn_SupplierGen_SupplierGenTypeId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV12DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV12DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRN_SUPPLIERGEN_SUPPLIERGENPHONECODE_DATA", AV11Trn_SupplierGen_SupplierGenPhoneCode_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRN_SUPPLIERGEN_SUPPLIERGENPHONECODE_DATA", AV11Trn_SupplierGen_SupplierGenPhoneCode_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRN_SUPPLIERGEN_SUPPLIERGENADDRESSCOUNTRY_DATA", AV23Trn_SupplierGen_SupplierGenAddressCountry_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRN_SUPPLIERGEN_SUPPLIERGENADDRESSCOUNTRY_DATA", AV23Trn_SupplierGen_SupplierGenAddressCountry_Data);
         }
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV16TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV16TrnMode, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV18CheckRequiredFieldsResult);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRN_PREFERREDGENSUPPLIER", AV28Trn_PreferredGenSupplier);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRN_PREFERREDGENSUPPLIER", AV28Trn_PreferredGenSupplier);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGES", AV15Messages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGES", AV15Messages);
         }
         GxWebStd.gx_hidden_field( context, "vSUPPLIERGENID", AV20SupplierGenId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vSUPPLIERGENID", GetSecureSignedToken( "", AV20SupplierGenId, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRN_SUPPLIERGEN", AV7Trn_SupplierGen);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRN_SUPPLIERGEN", AV7Trn_SupplierGen);
         }
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENTYPEID_Cls", StringUtil.RTrim( Combo_trn_suppliergen_suppliergentypeid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENTYPEID_Selectedvalue_set", StringUtil.RTrim( Combo_trn_suppliergen_suppliergentypeid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENTYPEID_Enabled", StringUtil.BoolToStr( Combo_trn_suppliergen_suppliergentypeid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENTYPEID_Emptyitem", StringUtil.BoolToStr( Combo_trn_suppliergen_suppliergentypeid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENPHONECODE_Cls", StringUtil.RTrim( Combo_trn_suppliergen_suppliergenphonecode_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENPHONECODE_Selectedvalue_set", StringUtil.RTrim( Combo_trn_suppliergen_suppliergenphonecode_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENPHONECODE_Selectedtext_set", StringUtil.RTrim( Combo_trn_suppliergen_suppliergenphonecode_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENPHONECODE_Enabled", StringUtil.BoolToStr( Combo_trn_suppliergen_suppliergenphonecode_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENPHONECODE_Emptyitem", StringUtil.BoolToStr( Combo_trn_suppliergen_suppliergenphonecode_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENPHONECODE_Htmltemplate", StringUtil.RTrim( Combo_trn_suppliergen_suppliergenphonecode_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENADDRESSCOUNTRY_Cls", StringUtil.RTrim( Combo_trn_suppliergen_suppliergenaddresscountry_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENADDRESSCOUNTRY_Selectedvalue_set", StringUtil.RTrim( Combo_trn_suppliergen_suppliergenaddresscountry_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENADDRESSCOUNTRY_Selectedtext_set", StringUtil.RTrim( Combo_trn_suppliergen_suppliergenaddresscountry_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENADDRESSCOUNTRY_Enabled", StringUtil.BoolToStr( Combo_trn_suppliergen_suppliergenaddresscountry_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENADDRESSCOUNTRY_Emptyitem", StringUtil.BoolToStr( Combo_trn_suppliergen_suppliergenaddresscountry_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENADDRESSCOUNTRY_Htmltemplate", StringUtil.RTrim( Combo_trn_suppliergen_suppliergenaddresscountry_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENADDRESSCOUNTRY_Selectedvalue_get", StringUtil.RTrim( Combo_trn_suppliergen_suppliergenaddresscountry_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENPHONECODE_Selectedvalue_get", StringUtil.RTrim( Combo_trn_suppliergen_suppliergenphonecode_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENTYPEID_Selectedvalue_get", StringUtil.RTrim( Combo_trn_suppliergen_suppliergentypeid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENTYPEID_Ddointernalname", StringUtil.RTrim( Combo_trn_suppliergen_suppliergentypeid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENADDRESSCOUNTRY_Ddointernalname", StringUtil.RTrim( Combo_trn_suppliergen_suppliergenaddresscountry_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENTYPEID_Selectedvalue_get", StringUtil.RTrim( Combo_trn_suppliergen_suppliergentypeid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENTYPEID_Ddointernalname", StringUtil.RTrim( Combo_trn_suppliergen_suppliergentypeid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENADDRESSCOUNTRY_Ddointernalname", StringUtil.RTrim( Combo_trn_suppliergen_suppliergenaddresscountry_Ddointernalname));
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
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal FormNoBackgroundColor" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE7Y2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT7Y2( ) ;
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
         GXEncryptionTmp = "wp_createnewgeneralsupplier.aspx"+UrlEncode(StringUtil.RTrim(AV16TrnMode)) + "," + UrlEncode(AV20SupplierGenId.ToString());
         return formatLink("wp_createnewgeneralsupplier.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WP_CreateNewGeneralSupplier" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Add New General Supplier", "") ;
      }

      protected void WB7Y0( )
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "Supplier Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WP_CreateNewGeneralSupplier.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSupplierinformation_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_suppliergen_suppliergenkvknumber_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_suppliergen_suppliergenkvknumber_Internalname, context.GetMessage( "KvK Number", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_suppliergen_suppliergenkvknumber_Internalname, AV7Trn_SupplierGen.gxTpr_Suppliergenkvknumber, StringUtil.RTrim( context.localUtil.Format( AV7Trn_SupplierGen.gxTpr_Suppliergenkvknumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_suppliergen_suppliergenkvknumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_suppliergen_suppliergenkvknumber_Enabled, 1, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateNewGeneralSupplier.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_suppliergen_suppliergencompanyname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_suppliergen_suppliergencompanyname_Internalname, context.GetMessage( "Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_suppliergen_suppliergencompanyname_Internalname, AV7Trn_SupplierGen.gxTpr_Suppliergencompanyname, StringUtil.RTrim( context.localUtil.Format( AV7Trn_SupplierGen.gxTpr_Suppliergencompanyname, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_suppliergen_suppliergencompanyname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_suppliergen_suppliergencompanyname_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateNewGeneralSupplier.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedtrn_suppliergen_suppliergentypeid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_trn_suppliergen_suppliergentypeid_Internalname, context.GetMessage( "Category", ""), "", "", lblTextblockcombo_trn_suppliergen_suppliergentypeid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_CreateNewGeneralSupplier.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_trn_suppliergen_suppliergentypeid.SetProperty("Caption", Combo_trn_suppliergen_suppliergentypeid_Caption);
            ucCombo_trn_suppliergen_suppliergentypeid.SetProperty("Cls", Combo_trn_suppliergen_suppliergentypeid_Cls);
            ucCombo_trn_suppliergen_suppliergentypeid.SetProperty("EmptyItem", Combo_trn_suppliergen_suppliergentypeid_Emptyitem);
            ucCombo_trn_suppliergen_suppliergentypeid.SetProperty("DropDownOptionsData", AV8Trn_SupplierGen_SupplierGenTypeId_Data);
            ucCombo_trn_suppliergen_suppliergentypeid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_trn_suppliergen_suppliergentypeid_Internalname, "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENTYPEIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_suppliergen_suppliergencontactname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_suppliergen_suppliergencontactname_Internalname, context.GetMessage( "Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_suppliergen_suppliergencontactname_Internalname, AV7Trn_SupplierGen.gxTpr_Suppliergencontactname, StringUtil.RTrim( context.localUtil.Format( AV7Trn_SupplierGen.gxTpr_Suppliergencontactname, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_suppliergen_suppliergencontactname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_suppliergen_suppliergencontactname_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateNewGeneralSupplier.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable4_Internalname, 1, 0, "px", 0, "px", "CellMarginBottom10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 control-label", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPhonelabelhome_Internalname, context.GetMessage( "Phone", ""), "", "", lblPhonelabelhome_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WP_CreateNewGeneralSupplier.htm");
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
            ucCombo_trn_suppliergen_suppliergenphonecode.SetProperty("Caption", Combo_trn_suppliergen_suppliergenphonecode_Caption);
            ucCombo_trn_suppliergen_suppliergenphonecode.SetProperty("Cls", Combo_trn_suppliergen_suppliergenphonecode_Cls);
            ucCombo_trn_suppliergen_suppliergenphonecode.SetProperty("EmptyItem", Combo_trn_suppliergen_suppliergenphonecode_Emptyitem);
            ucCombo_trn_suppliergen_suppliergenphonecode.SetProperty("DropDownOptionsTitleSettingsIcons", AV12DDO_TitleSettingsIcons);
            ucCombo_trn_suppliergen_suppliergenphonecode.SetProperty("DropDownOptionsData", AV11Trn_SupplierGen_SupplierGenPhoneCode_Data);
            ucCombo_trn_suppliergen_suppliergenphonecode.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_trn_suppliergen_suppliergenphonecode_Internalname, "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENPHONECODEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable7_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_suppliergen_suppliergenphonenumber_Internalname, context.GetMessage( "Supplier Gen Phone Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_suppliergen_suppliergenphonenumber_Internalname, AV7Trn_SupplierGen.gxTpr_Suppliergenphonenumber, StringUtil.RTrim( context.localUtil.Format( AV7Trn_SupplierGen.gxTpr_Suppliergenphonenumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "229123456", edtavTrn_suppliergen_suppliergenphonenumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_suppliergen_suppliergenphonenumber_Enabled, 1, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateNewGeneralSupplier.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_suppliergen_suppliergenemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_suppliergen_suppliergenemail_Internalname, context.GetMessage( "Email", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_suppliergen_suppliergenemail_Internalname, AV7Trn_SupplierGen.gxTpr_Suppliergenemail, StringUtil.RTrim( context.localUtil.Format( AV7Trn_SupplierGen.gxTpr_Suppliergenemail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_suppliergen_suppliergenemail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_suppliergen_suppliergenemail_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WP_CreateNewGeneralSupplier.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_suppliergen_suppliergenwebsite_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_suppliergen_suppliergenwebsite_Internalname, context.GetMessage( "Website", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_suppliergen_suppliergenwebsite_Internalname, AV7Trn_SupplierGen.gxTpr_Suppliergenwebsite, StringUtil.RTrim( context.localUtil.Format( AV7Trn_SupplierGen.gxTpr_Suppliergenwebsite, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_suppliergen_suppliergenwebsite_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_suppliergen_suppliergenwebsite_Enabled, 1, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateNewGeneralSupplier.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavIspreffered_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavIspreffered_Internalname, context.GetMessage( "is Preffered", ""), "col-sm-4 AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIspreffered_Internalname, StringUtil.BoolToStr( AV26isPreffered), "", context.GetMessage( "is Preffered", ""), 1, chkavIspreffered.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(74, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,74);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup3_Internalname, context.GetMessage( "Address Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WP_CreateNewGeneralSupplier.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_suppliergen_suppliergenaddressline1_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_suppliergen_suppliergenaddressline1_Internalname, context.GetMessage( "Address Line 1", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_suppliergen_suppliergenaddressline1_Internalname, AV7Trn_SupplierGen.gxTpr_Suppliergenaddressline1, StringUtil.RTrim( context.localUtil.Format( AV7Trn_SupplierGen.gxTpr_Suppliergenaddressline1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_suppliergen_suppliergenaddressline1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_suppliergen_suppliergenaddressline1_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateNewGeneralSupplier.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_suppliergen_suppliergenaddressline2_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_suppliergen_suppliergenaddressline2_Internalname, context.GetMessage( "Address Line 2", ""), "col-sm-4 AttributeLabel spacefieldsLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_suppliergen_suppliergenaddressline2_Internalname, AV7Trn_SupplierGen.gxTpr_Suppliergenaddressline2, StringUtil.RTrim( context.localUtil.Format( AV7Trn_SupplierGen.gxTpr_Suppliergenaddressline2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_suppliergen_suppliergenaddressline2_Jsonclick, 0, "Attribute spacefields", "", "", "", "", 1, edtavTrn_suppliergen_suppliergenaddressline2_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateNewGeneralSupplier.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_suppliergen_suppliergenaddresszipcode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_suppliergen_suppliergenaddresszipcode_Internalname, context.GetMessage( "Zip Code", ""), "col-sm-4 AttributeLabel spacefieldsLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_suppliergen_suppliergenaddresszipcode_Internalname, AV7Trn_SupplierGen.gxTpr_Suppliergenaddresszipcode, StringUtil.RTrim( context.localUtil.Format( AV7Trn_SupplierGen.gxTpr_Suppliergenaddresszipcode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,92);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_suppliergen_suppliergenaddresszipcode_Jsonclick, 0, "Attribute spacefields", "", "", "", "", 1, edtavTrn_suppliergen_suppliergenaddresszipcode_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateNewGeneralSupplier.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_suppliergen_suppliergenaddresscity_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_suppliergen_suppliergenaddresscity_Internalname, context.GetMessage( "City", ""), "col-sm-4 AttributeLabel spacefieldsLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_suppliergen_suppliergenaddresscity_Internalname, AV7Trn_SupplierGen.gxTpr_Suppliergenaddresscity, StringUtil.RTrim( context.localUtil.Format( AV7Trn_SupplierGen.gxTpr_Suppliergenaddresscity, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,97);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_suppliergen_suppliergenaddresscity_Jsonclick, 0, "Attribute spacefields", "", "", "", "", 1, edtavTrn_suppliergen_suppliergenaddresscity_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateNewGeneralSupplier.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedtrn_suppliergen_suppliergenaddresscountry_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_trn_suppliergen_suppliergenaddresscountry_Internalname, context.GetMessage( "Country", ""), "", "", lblTextblockcombo_trn_suppliergen_suppliergenaddresscountry_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_CreateNewGeneralSupplier.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_trn_suppliergen_suppliergenaddresscountry.SetProperty("Caption", Combo_trn_suppliergen_suppliergenaddresscountry_Caption);
            ucCombo_trn_suppliergen_suppliergenaddresscountry.SetProperty("Cls", Combo_trn_suppliergen_suppliergenaddresscountry_Cls);
            ucCombo_trn_suppliergen_suppliergenaddresscountry.SetProperty("EmptyItem", Combo_trn_suppliergen_suppliergenaddresscountry_Emptyitem);
            ucCombo_trn_suppliergen_suppliergenaddresscountry.SetProperty("DropDownOptionsTitleSettingsIcons", AV12DDO_TitleSettingsIcons);
            ucCombo_trn_suppliergen_suppliergenaddresscountry.SetProperty("DropDownOptionsData", AV23Trn_SupplierGen_SupplierGenAddressCountry_Data);
            ucCombo_trn_suppliergen_suppliergenaddresscountry.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_trn_suppliergen_suppliergenaddresscountry_Internalname, "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENADDRESSCOUNTRYContainer");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_CreateNewGeneralSupplier.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtncancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_CreateNewGeneralSupplier.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_suppliergen_suppliergenid_Internalname, AV7Trn_SupplierGen.gxTpr_Suppliergenid.ToString(), AV7Trn_SupplierGen.gxTpr_Suppliergenid.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,116);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_suppliergen_suppliergenid_Jsonclick, 0, "Attribute", "", "", "", "", edtavTrn_suppliergen_suppliergenid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_CreateNewGeneralSupplier.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_suppliergen_suppliergentypename_Internalname, AV7Trn_SupplierGen.gxTpr_Suppliergentypename, StringUtil.RTrim( context.localUtil.Format( AV7Trn_SupplierGen.gxTpr_Suppliergentypename, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,117);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_suppliergen_suppliergentypename_Jsonclick, 0, "Attribute", "", "", "", "", edtavTrn_suppliergen_suppliergentypename_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateNewGeneralSupplier.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_suppliergen_suppliergencontactphone_Internalname, StringUtil.RTrim( AV7Trn_SupplierGen.gxTpr_Suppliergencontactphone), StringUtil.RTrim( context.localUtil.Format( AV7Trn_SupplierGen.gxTpr_Suppliergencontactphone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,118);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_suppliergen_suppliergencontactphone_Jsonclick, 0, "Attribute", "", "", "", "", edtavTrn_suppliergen_suppliergencontactphone_Visible, 1, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WP_CreateNewGeneralSupplier.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START7Y2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Add New General Supplier", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP7Y0( ) ;
      }

      protected void WS7Y2( )
      {
         START7Y2( ) ;
         EVT7Y2( ) ;
      }

      protected void EVT7Y2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENTYPEID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_trn_suppliergen_suppliergentypeid.Onoptionclicked */
                              E117Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E127Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E137Y2 ();
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
                                    E147Y2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E157Y2 ();
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

      protected void WE7Y2( )
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

      protected void PA7Y2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_createnewgeneralsupplier.aspx")), "wp_createnewgeneralsupplier.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_createnewgeneralsupplier.aspx")))) ;
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
                  gxfirstwebparm = GetFirstPar( "TrnMode");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV16TrnMode = gxfirstwebparm;
                     AssignAttri("", false, "AV16TrnMode", AV16TrnMode);
                     GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV16TrnMode, "")), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV20SupplierGenId = StringUtil.StrToGuid( GetPar( "SupplierGenId"));
                        AssignAttri("", false, "AV20SupplierGenId", AV20SupplierGenId.ToString());
                        GxWebStd.gx_hidden_field( context, "gxhash_vSUPPLIERGENID", GetSecureSignedToken( "", AV20SupplierGenId, context));
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
               GX_FocusControl = edtavTrn_suppliergen_suppliergenkvknumber_Internalname;
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
         AV26isPreffered = StringUtil.StrToBool( StringUtil.BoolToStr( AV26isPreffered));
         AssignAttri("", false, "AV26isPreffered", AV26isPreffered);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF7Y2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF7Y2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E137Y2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E157Y2 ();
            WB7Y0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes7Y2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7Y0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E127Y2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vTRN_SUPPLIERGEN"), AV7Trn_SupplierGen);
            ajax_req_read_hidden_sdt(cgiGet( "Trn_suppliergen"), AV7Trn_SupplierGen);
            ajax_req_read_hidden_sdt(cgiGet( "vTRN_SUPPLIERGEN_SUPPLIERGENTYPEID_DATA"), AV8Trn_SupplierGen_SupplierGenTypeId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV12DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vTRN_SUPPLIERGEN_SUPPLIERGENPHONECODE_DATA"), AV11Trn_SupplierGen_SupplierGenPhoneCode_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vTRN_SUPPLIERGEN_SUPPLIERGENADDRESSCOUNTRY_DATA"), AV23Trn_SupplierGen_SupplierGenAddressCountry_Data);
            /* Read saved values. */
            Combo_trn_suppliergen_suppliergentypeid_Cls = cgiGet( "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENTYPEID_Cls");
            Combo_trn_suppliergen_suppliergentypeid_Selectedvalue_set = cgiGet( "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENTYPEID_Selectedvalue_set");
            Combo_trn_suppliergen_suppliergentypeid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENTYPEID_Enabled"));
            Combo_trn_suppliergen_suppliergentypeid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENTYPEID_Emptyitem"));
            Combo_trn_suppliergen_suppliergenphonecode_Cls = cgiGet( "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENPHONECODE_Cls");
            Combo_trn_suppliergen_suppliergenphonecode_Selectedvalue_set = cgiGet( "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENPHONECODE_Selectedvalue_set");
            Combo_trn_suppliergen_suppliergenphonecode_Selectedtext_set = cgiGet( "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENPHONECODE_Selectedtext_set");
            Combo_trn_suppliergen_suppliergenphonecode_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENPHONECODE_Enabled"));
            Combo_trn_suppliergen_suppliergenphonecode_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENPHONECODE_Emptyitem"));
            Combo_trn_suppliergen_suppliergenphonecode_Htmltemplate = cgiGet( "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENPHONECODE_Htmltemplate");
            Combo_trn_suppliergen_suppliergenaddresscountry_Cls = cgiGet( "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENADDRESSCOUNTRY_Cls");
            Combo_trn_suppliergen_suppliergenaddresscountry_Selectedvalue_set = cgiGet( "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENADDRESSCOUNTRY_Selectedvalue_set");
            Combo_trn_suppliergen_suppliergenaddresscountry_Selectedtext_set = cgiGet( "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENADDRESSCOUNTRY_Selectedtext_set");
            Combo_trn_suppliergen_suppliergenaddresscountry_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENADDRESSCOUNTRY_Enabled"));
            Combo_trn_suppliergen_suppliergenaddresscountry_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENADDRESSCOUNTRY_Emptyitem"));
            Combo_trn_suppliergen_suppliergenaddresscountry_Htmltemplate = cgiGet( "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENADDRESSCOUNTRY_Htmltemplate");
            Combo_trn_suppliergen_suppliergentypeid_Selectedvalue_get = cgiGet( "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENTYPEID_Selectedvalue_get");
            Combo_trn_suppliergen_suppliergentypeid_Ddointernalname = cgiGet( "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENTYPEID_Ddointernalname");
            Combo_trn_suppliergen_suppliergenaddresscountry_Ddointernalname = cgiGet( "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENADDRESSCOUNTRY_Ddointernalname");
            /* Read variables values. */
            AV7Trn_SupplierGen.gxTpr_Suppliergenkvknumber = cgiGet( edtavTrn_suppliergen_suppliergenkvknumber_Internalname);
            AV7Trn_SupplierGen.gxTpr_Suppliergencompanyname = cgiGet( edtavTrn_suppliergen_suppliergencompanyname_Internalname);
            AV7Trn_SupplierGen.gxTpr_Suppliergencontactname = cgiGet( edtavTrn_suppliergen_suppliergencontactname_Internalname);
            AV7Trn_SupplierGen.gxTpr_Suppliergenphonenumber = cgiGet( edtavTrn_suppliergen_suppliergenphonenumber_Internalname);
            AV7Trn_SupplierGen.gxTpr_Suppliergenemail = cgiGet( edtavTrn_suppliergen_suppliergenemail_Internalname);
            AV7Trn_SupplierGen.gxTpr_Suppliergenwebsite = cgiGet( edtavTrn_suppliergen_suppliergenwebsite_Internalname);
            AV26isPreffered = StringUtil.StrToBool( cgiGet( chkavIspreffered_Internalname));
            AssignAttri("", false, "AV26isPreffered", AV26isPreffered);
            AV7Trn_SupplierGen.gxTpr_Suppliergenaddressline1 = cgiGet( edtavTrn_suppliergen_suppliergenaddressline1_Internalname);
            AV7Trn_SupplierGen.gxTpr_Suppliergenaddressline2 = cgiGet( edtavTrn_suppliergen_suppliergenaddressline2_Internalname);
            AV7Trn_SupplierGen.gxTpr_Suppliergenaddresszipcode = cgiGet( edtavTrn_suppliergen_suppliergenaddresszipcode_Internalname);
            AV7Trn_SupplierGen.gxTpr_Suppliergenaddresscity = cgiGet( edtavTrn_suppliergen_suppliergenaddresscity_Internalname);
            if ( StringUtil.StrCmp(cgiGet( edtavTrn_suppliergen_suppliergenid_Internalname), "") == 0 )
            {
               AV7Trn_SupplierGen.gxTpr_Suppliergenid = Guid.Empty;
            }
            else
            {
               try
               {
                  AV7Trn_SupplierGen.gxTpr_Suppliergenid = StringUtil.StrToGuid( cgiGet( edtavTrn_suppliergen_suppliergenid_Internalname));
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "TRN_SUPPLIERGEN_SUPPLIERGENID");
                  GX_FocusControl = edtavTrn_suppliergen_suppliergenid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            AV7Trn_SupplierGen.gxTpr_Suppliergentypename = cgiGet( edtavTrn_suppliergen_suppliergentypename_Internalname);
            AV7Trn_SupplierGen.gxTpr_Suppliergencontactphone = cgiGet( edtavTrn_suppliergen_suppliergencontactphone_Internalname);
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
         E127Y2 ();
         if (returnInSub) return;
      }

      protected void E127Y2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         AV17LoadSuccess = true;
         if ( ( ( StringUtil.StrCmp(AV16TrnMode, "DSP") == 0 ) ) || ( ( StringUtil.StrCmp(AV16TrnMode, "INS") == 0 ) && new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context).executeUdp(  "trn_suppliergen_Insert") ) || ( ( StringUtil.StrCmp(AV16TrnMode, "UPD") == 0 ) && new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context).executeUdp(  "trn_suppliergen_Update") ) || ( ( StringUtil.StrCmp(AV16TrnMode, "DLT") == 0 ) && new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context).executeUdp(  "trn_suppliergen_Delete") ) )
         {
            if ( StringUtil.StrCmp(AV16TrnMode, "INS") != 0 )
            {
               AV7Trn_SupplierGen.Load(AV20SupplierGenId);
               AV17LoadSuccess = AV7Trn_SupplierGen.Success();
               if ( ! AV17LoadSuccess )
               {
                  AV15Messages = AV7Trn_SupplierGen.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
               if ( ( StringUtil.StrCmp(AV16TrnMode, "DSP") == 0 ) || ( StringUtil.StrCmp(AV16TrnMode, "DLT") == 0 ) )
               {
                  edtavTrn_suppliergen_suppliergenaddressline1_Enabled = 0;
                  AssignProp("", false, edtavTrn_suppliergen_suppliergenaddressline1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergenaddressline1_Enabled), 5, 0), true);
                  edtavTrn_suppliergen_suppliergenaddressline2_Enabled = 0;
                  AssignProp("", false, edtavTrn_suppliergen_suppliergenaddressline2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergenaddressline2_Enabled), 5, 0), true);
                  edtavTrn_suppliergen_suppliergenaddresszipcode_Enabled = 0;
                  AssignProp("", false, edtavTrn_suppliergen_suppliergenaddresszipcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergenaddresszipcode_Enabled), 5, 0), true);
                  edtavTrn_suppliergen_suppliergenaddresscity_Enabled = 0;
                  AssignProp("", false, edtavTrn_suppliergen_suppliergenaddresscity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergenaddresscity_Enabled), 5, 0), true);
                  Combo_trn_suppliergen_suppliergenaddresscountry_Enabled = false;
                  ucCombo_trn_suppliergen_suppliergenaddresscountry.SendProperty(context, "", false, Combo_trn_suppliergen_suppliergenaddresscountry_Internalname, "Enabled", StringUtil.BoolToStr( Combo_trn_suppliergen_suppliergenaddresscountry_Enabled));
                  edtavTrn_suppliergen_suppliergenkvknumber_Enabled = 0;
                  AssignProp("", false, edtavTrn_suppliergen_suppliergenkvknumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergenkvknumber_Enabled), 5, 0), true);
                  edtavTrn_suppliergen_suppliergencompanyname_Enabled = 0;
                  AssignProp("", false, edtavTrn_suppliergen_suppliergencompanyname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergencompanyname_Enabled), 5, 0), true);
                  Combo_trn_suppliergen_suppliergentypeid_Enabled = false;
                  ucCombo_trn_suppliergen_suppliergentypeid.SendProperty(context, "", false, Combo_trn_suppliergen_suppliergentypeid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_trn_suppliergen_suppliergentypeid_Enabled));
                  edtavTrn_suppliergen_suppliergencontactname_Enabled = 0;
                  AssignProp("", false, edtavTrn_suppliergen_suppliergencontactname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergencontactname_Enabled), 5, 0), true);
                  edtavTrn_suppliergen_suppliergenemail_Enabled = 0;
                  AssignProp("", false, edtavTrn_suppliergen_suppliergenemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergenemail_Enabled), 5, 0), true);
                  edtavTrn_suppliergen_suppliergenwebsite_Enabled = 0;
                  AssignProp("", false, edtavTrn_suppliergen_suppliergenwebsite_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergenwebsite_Enabled), 5, 0), true);
                  chkavIspreffered.Enabled = 0;
                  AssignProp("", false, chkavIspreffered_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIspreffered.Enabled), 5, 0), true);
                  edtavTrn_suppliergen_suppliergenphonenumber_Enabled = 0;
                  AssignProp("", false, edtavTrn_suppliergen_suppliergenphonenumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergenphonenumber_Enabled), 5, 0), true);
                  Combo_trn_suppliergen_suppliergenphonecode_Enabled = false;
                  ucCombo_trn_suppliergen_suppliergenphonecode.SendProperty(context, "", false, Combo_trn_suppliergen_suppliergenphonecode_Internalname, "Enabled", StringUtil.BoolToStr( Combo_trn_suppliergen_suppliergenphonecode_Enabled));
               }
            }
         }
         else
         {
            AV17LoadSuccess = false;
            CallWebObject(formatLink("wp_notauthorized.aspx") );
            context.wjLocDisableFrm = 1;
         }
         if ( AV17LoadSuccess )
         {
            if ( StringUtil.StrCmp(AV16TrnMode, "DLT") == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""));
            }
         }
         AV21WebSession.Remove("SUPPLIERGENID");
         AV21WebSession.Remove("SUPPLIERGENCOMPANYNAME");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV12DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV12DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_trn_suppliergen_suppliergenaddresscountry_Htmltemplate = GXt_char2;
         ucCombo_trn_suppliergen_suppliergenaddresscountry.SendProperty(context, "", false, Combo_trn_suppliergen_suppliergenaddresscountry_Internalname, "HTMLTemplate", Combo_trn_suppliergen_suppliergenaddresscountry_Htmltemplate);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_trn_suppliergen_suppliergenphonecode_Htmltemplate = GXt_char2;
         ucCombo_trn_suppliergen_suppliergenphonecode.SendProperty(context, "", false, Combo_trn_suppliergen_suppliergenphonecode_Internalname, "HTMLTemplate", Combo_trn_suppliergen_suppliergenphonecode_Htmltemplate);
         /* Execute user subroutine: 'LOADCOMBOTRN_SUPPLIERGEN_SUPPLIERGENTYPEID' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOTRN_SUPPLIERGEN_SUPPLIERGENPHONECODE' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOTRN_SUPPLIERGEN_SUPPLIERGENADDRESSCOUNTRY' */
         S142 ();
         if (returnInSub) return;
         edtavTrn_suppliergen_suppliergenid_Visible = 0;
         AssignProp("", false, edtavTrn_suppliergen_suppliergenid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergenid_Visible), 5, 0), true);
         edtavTrn_suppliergen_suppliergentypename_Visible = 0;
         AssignProp("", false, edtavTrn_suppliergen_suppliergentypename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergentypename_Visible), 5, 0), true);
         edtavTrn_suppliergen_suppliergencontactphone_Visible = 0;
         AssignProp("", false, edtavTrn_suppliergen_suppliergencontactphone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergencontactphone_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV16TrnMode, "INS") == 0 )
         {
            AV25defaultCountry = "Netherlands";
            AV7Trn_SupplierGen.gxTpr_Suppliergenaddresscountry = AV25defaultCountry;
            Combo_trn_suppliergen_suppliergenaddresscountry_Selectedtext_set = AV25defaultCountry;
            ucCombo_trn_suppliergen_suppliergenaddresscountry.SendProperty(context, "", false, Combo_trn_suppliergen_suppliergenaddresscountry_Internalname, "SelectedText_set", Combo_trn_suppliergen_suppliergenaddresscountry_Selectedtext_set);
            Combo_trn_suppliergen_suppliergenaddresscountry_Selectedvalue_set = AV25defaultCountry;
            ucCombo_trn_suppliergen_suppliergenaddresscountry.SendProperty(context, "", false, Combo_trn_suppliergen_suppliergenaddresscountry_Internalname, "SelectedValue_set", Combo_trn_suppliergen_suppliergenaddresscountry_Selectedvalue_set);
         }
         AV22defaultCountryPhoneCode = "+31";
         Combo_trn_suppliergen_suppliergenphonecode_Selectedtext_set = AV22defaultCountryPhoneCode;
         ucCombo_trn_suppliergen_suppliergenphonecode.SendProperty(context, "", false, Combo_trn_suppliergen_suppliergenphonecode_Internalname, "SelectedText_set", Combo_trn_suppliergen_suppliergenphonecode_Selectedtext_set);
         Combo_trn_suppliergen_suppliergenphonecode_Selectedvalue_set = AV22defaultCountryPhoneCode;
         ucCombo_trn_suppliergen_suppliergenphonecode.SendProperty(context, "", false, Combo_trn_suppliergen_suppliergenphonecode_Internalname, "SelectedValue_set", Combo_trn_suppliergen_suppliergenphonecode_Selectedvalue_set);
         AV7Trn_SupplierGen.gxTpr_Suppliergenphonecode = AV22defaultCountryPhoneCode;
      }

      protected void E137Y2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E117Y2( )
      {
         /* Combo_trn_suppliergen_suppliergentypeid_Onoptionclicked Routine */
         returnInSub = false;
         AV7Trn_SupplierGen.gxTpr_Suppliergentypeid = StringUtil.StrToGuid( Combo_trn_suppliergen_suppliergentypeid_Selectedvalue_get);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7Trn_SupplierGen", AV7Trn_SupplierGen);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E147Y2 ();
         if (returnInSub) return;
      }

      protected void E147Y2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV16TrnMode, "DSP") != 0 )
         {
            if ( StringUtil.StrCmp(AV16TrnMode, "DLT") != 0 )
            {
               /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
               S162 ();
               if (returnInSub) return;
            }
            if ( ( StringUtil.StrCmp(AV16TrnMode, "DLT") == 0 ) || AV18CheckRequiredFieldsResult )
            {
               if ( StringUtil.StrCmp(AV16TrnMode, "DLT") == 0 )
               {
                  AV7Trn_SupplierGen.Delete();
               }
               else
               {
                  AV7Trn_SupplierGen.Save();
                  if ( StringUtil.StrCmp(AV16TrnMode, "INS") == 0 )
                  {
                     AV21WebSession.Set("SUPPLIERGENID", StringUtil.Trim( AV7Trn_SupplierGen.gxTpr_Suppliergenid.ToString()));
                     AV21WebSession.Set("SUPPLIERGENCOMPANYNAME", AV7Trn_SupplierGen.gxTpr_Suppliergencompanyname);
                  }
               }
               if ( AV7Trn_SupplierGen.Success() )
               {
                  /* Execute user subroutine: 'AFTER_TRN' */
                  S172 ();
                  if (returnInSub) return;
               }
               else
               {
                  AV15Messages = AV7Trn_SupplierGen.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7Trn_SupplierGen", AV7Trn_SupplierGen);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15Messages", AV15Messages);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28Trn_PreferredGenSupplier", AV28Trn_PreferredGenSupplier);
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV16TrnMode, "DSP") != 0 ) ) )
         {
            bttBtnenter_Visible = 0;
            AssignProp("", false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
         }
      }

      protected void S162( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV18CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV18CheckRequiredFieldsResult", AV18CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV7Trn_SupplierGen.gxTpr_Suppliergenkvknumber)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "KvK Number", ""), "", "", "", "", "", "", "", ""),  "error",  edtavTrn_suppliergen_suppliergenkvknumber_Internalname,  "true",  ""));
            AV18CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV18CheckRequiredFieldsResult", AV18CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV7Trn_SupplierGen.gxTpr_Suppliergencompanyname)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Name", ""), "", "", "", "", "", "", "", ""),  "error",  edtavTrn_suppliergen_suppliergencompanyname_Internalname,  "true",  ""));
            AV18CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV18CheckRequiredFieldsResult", AV18CheckRequiredFieldsResult);
         }
         if ( (Guid.Empty==AV7Trn_SupplierGen.gxTpr_Suppliergentypeid) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Category", ""), "", "", "", "", "", "", "", ""),  "error",  Combo_trn_suppliergen_suppliergentypeid_Ddointernalname,  "true",  ""));
            AV18CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV18CheckRequiredFieldsResult", AV18CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV7Trn_SupplierGen.gxTpr_Suppliergenaddressline1)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Address Line 1", ""), "", "", "", "", "", "", "", ""),  "error",  edtavTrn_suppliergen_suppliergenaddressline1_Internalname,  "true",  ""));
            AV18CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV18CheckRequiredFieldsResult", AV18CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV7Trn_SupplierGen.gxTpr_Suppliergenaddresszipcode)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Zip Code", ""), "", "", "", "", "", "", "", ""),  "error",  edtavTrn_suppliergen_suppliergenaddresszipcode_Internalname,  "true",  ""));
            AV18CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV18CheckRequiredFieldsResult", AV18CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV7Trn_SupplierGen.gxTpr_Suppliergenaddresscity)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "City", ""), "", "", "", "", "", "", "", ""),  "error",  edtavTrn_suppliergen_suppliergenaddresscity_Internalname,  "true",  ""));
            AV18CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV18CheckRequiredFieldsResult", AV18CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV7Trn_SupplierGen.gxTpr_Suppliergenaddresscountry)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Country", ""), "", "", "", "", "", "", "", ""),  "error",  Combo_trn_suppliergen_suppliergenaddresscountry_Ddointernalname,  "true",  ""));
            AV18CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV18CheckRequiredFieldsResult", AV18CheckRequiredFieldsResult);
         }
      }

      protected void S142( )
      {
         /* 'LOADCOMBOTRN_SUPPLIERGEN_SUPPLIERGENADDRESSCOUNTRY' Routine */
         returnInSub = false;
         AV43GXV15 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = AV42GXV14;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem3) ;
         AV42GXV14 = GXt_objcol_SdtSDT_Country_SDT_CountryItem3;
         while ( AV43GXV15 <= AV42GXV14.Count )
         {
            AV24Trn_SupplierGen_SupplierGenAddressCountry_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV42GXV14.Item(AV43GXV15));
            AV9Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV9Combo_DataItem.gxTpr_Id = AV24Trn_SupplierGen_SupplierGenAddressCountry_DPItem.gxTpr_Countryname;
            AV10ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV10ComboTitles.Add(AV24Trn_SupplierGen_SupplierGenAddressCountry_DPItem.gxTpr_Countryname, 0);
            AV10ComboTitles.Add(AV24Trn_SupplierGen_SupplierGenAddressCountry_DPItem.gxTpr_Countryflag, 0);
            AV9Combo_DataItem.gxTpr_Title = AV10ComboTitles.ToJSonString(false);
            AV23Trn_SupplierGen_SupplierGenAddressCountry_Data.Add(AV9Combo_DataItem, 0);
            AV43GXV15 = (int)(AV43GXV15+1);
         }
         AV23Trn_SupplierGen_SupplierGenAddressCountry_Data.Sort("Title");
         Combo_trn_suppliergen_suppliergenaddresscountry_Selectedvalue_set = AV7Trn_SupplierGen.gxTpr_Suppliergenaddresscountry;
         ucCombo_trn_suppliergen_suppliergenaddresscountry.SendProperty(context, "", false, Combo_trn_suppliergen_suppliergenaddresscountry_Internalname, "SelectedValue_set", Combo_trn_suppliergen_suppliergenaddresscountry_Selectedvalue_set);
      }

      protected void S132( )
      {
         /* 'LOADCOMBOTRN_SUPPLIERGEN_SUPPLIERGENPHONECODE' Routine */
         returnInSub = false;
         AV45GXV17 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = AV44GXV16;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem3) ;
         AV44GXV16 = GXt_objcol_SdtSDT_Country_SDT_CountryItem3;
         while ( AV45GXV17 <= AV44GXV16.Count )
         {
            AV13Trn_SupplierGen_SupplierGenPhoneCode_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV44GXV16.Item(AV45GXV17));
            AV9Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV9Combo_DataItem.gxTpr_Id = AV13Trn_SupplierGen_SupplierGenPhoneCode_DPItem.gxTpr_Countrydialcode;
            AV10ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV10ComboTitles.Add(AV13Trn_SupplierGen_SupplierGenPhoneCode_DPItem.gxTpr_Countrydialcode, 0);
            AV10ComboTitles.Add(AV13Trn_SupplierGen_SupplierGenPhoneCode_DPItem.gxTpr_Countryflag, 0);
            AV9Combo_DataItem.gxTpr_Title = AV10ComboTitles.ToJSonString(false);
            AV11Trn_SupplierGen_SupplierGenPhoneCode_Data.Add(AV9Combo_DataItem, 0);
            AV45GXV17 = (int)(AV45GXV17+1);
         }
         AV11Trn_SupplierGen_SupplierGenPhoneCode_Data.Sort("Title");
         Combo_trn_suppliergen_suppliergenphonecode_Selectedvalue_set = AV7Trn_SupplierGen.gxTpr_Suppliergenphonecode;
         ucCombo_trn_suppliergen_suppliergenphonecode.SendProperty(context, "", false, Combo_trn_suppliergen_suppliergenphonecode_Internalname, "SelectedValue_set", Combo_trn_suppliergen_suppliergenphonecode_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOTRN_SUPPLIERGEN_SUPPLIERGENTYPEID' Routine */
         returnInSub = false;
         /* Using cursor H007Y2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A253SupplierGenTypeId = H007Y2_A253SupplierGenTypeId[0];
            A254SupplierGenTypeName = H007Y2_A254SupplierGenTypeName[0];
            AV9Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV9Combo_DataItem.gxTpr_Id = StringUtil.Trim( A253SupplierGenTypeId.ToString());
            AV9Combo_DataItem.gxTpr_Title = A254SupplierGenTypeName;
            AV8Trn_SupplierGen_SupplierGenTypeId_Data.Add(AV9Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         Combo_trn_suppliergen_suppliergentypeid_Selectedvalue_set = ((Guid.Empty==AV7Trn_SupplierGen.gxTpr_Suppliergentypeid) ? "" : StringUtil.Trim( AV7Trn_SupplierGen.gxTpr_Suppliergentypeid.ToString()));
         ucCombo_trn_suppliergen_suppliergentypeid.SendProperty(context, "", false, Combo_trn_suppliergen_suppliergentypeid_Internalname, "SelectedValue_set", Combo_trn_suppliergen_suppliergentypeid_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'SHOW MESSAGES' Routine */
         returnInSub = false;
         AV47GXV18 = 1;
         while ( AV47GXV18 <= AV15Messages.Count )
         {
            AV14Message = ((GeneXus.Utils.SdtMessages_Message)AV15Messages.Item(AV47GXV18));
            GX_msglist.addItem(AV14Message.gxTpr_Description);
            AV47GXV18 = (int)(AV47GXV18+1);
         }
      }

      protected void S172( )
      {
         /* 'AFTER_TRN' Routine */
         returnInSub = false;
         if ( AV26isPreffered )
         {
            AV28Trn_PreferredGenSupplier.gxTpr_Preferredgensupplierid = Guid.NewGuid( );
            AV28Trn_PreferredGenSupplier.gxTpr_Preferredsuppliergenid = AV7Trn_SupplierGen.gxTpr_Suppliergenid;
            AV28Trn_PreferredGenSupplier.Insert();
         }
         context.CommitDataStores("wp_createnewgeneralsupplier",pr_default);
         this.executeExternalObjectMethod("", false, "GlobalEvents", "RefreshPreferredSupplier", new Object[] {}, true);
         context.CommitDataStores("wp_createnewgeneralsupplier",pr_default);
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void nextLoad( )
      {
      }

      protected void E157Y2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV16TrnMode = (string)getParm(obj,0);
         AssignAttri("", false, "AV16TrnMode", AV16TrnMode);
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV16TrnMode, "")), context));
         AV20SupplierGenId = (Guid)getParm(obj,1);
         AssignAttri("", false, "AV20SupplierGenId", AV20SupplierGenId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vSUPPLIERGENID", GetSecureSignedToken( "", AV20SupplierGenId, context));
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
         PA7Y2( ) ;
         WS7Y2( ) ;
         WE7Y2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025721256521", true, true);
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
         context.AddJavascriptSource("wp_createnewgeneralsupplier.js", "?2025721256521", false, true);
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
         chkavIspreffered.Name = "vISPREFFERED";
         chkavIspreffered.WebTags = "";
         chkavIspreffered.Caption = context.GetMessage( "is Preffered", "");
         AssignProp("", false, chkavIspreffered_Internalname, "TitleCaption", chkavIspreffered.Caption, true);
         chkavIspreffered.CheckedValue = "false";
         AV26isPreffered = StringUtil.StrToBool( StringUtil.BoolToStr( AV26isPreffered));
         AssignAttri("", false, "AV26isPreffered", AV26isPreffered);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavTrn_suppliergen_suppliergenkvknumber_Internalname = "TRN_SUPPLIERGEN_SUPPLIERGENKVKNUMBER";
         edtavTrn_suppliergen_suppliergencompanyname_Internalname = "TRN_SUPPLIERGEN_SUPPLIERGENCOMPANYNAME";
         lblTextblockcombo_trn_suppliergen_suppliergentypeid_Internalname = "TEXTBLOCKCOMBO_TRN_SUPPLIERGEN_SUPPLIERGENTYPEID";
         Combo_trn_suppliergen_suppliergentypeid_Internalname = "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENTYPEID";
         divTablesplittedtrn_suppliergen_suppliergentypeid_Internalname = "TABLESPLITTEDTRN_SUPPLIERGEN_SUPPLIERGENTYPEID";
         edtavTrn_suppliergen_suppliergencontactname_Internalname = "TRN_SUPPLIERGEN_SUPPLIERGENCONTACTNAME";
         lblPhonelabelhome_Internalname = "PHONELABELHOME";
         Combo_trn_suppliergen_suppliergenphonecode_Internalname = "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENPHONECODE";
         divUnnamedtable6_Internalname = "UNNAMEDTABLE6";
         edtavTrn_suppliergen_suppliergenphonenumber_Internalname = "TRN_SUPPLIERGEN_SUPPLIERGENPHONENUMBER";
         divUnnamedtable7_Internalname = "UNNAMEDTABLE7";
         divUnnamedtable5_Internalname = "UNNAMEDTABLE5";
         divUnnamedtable4_Internalname = "UNNAMEDTABLE4";
         edtavTrn_suppliergen_suppliergenemail_Internalname = "TRN_SUPPLIERGEN_SUPPLIERGENEMAIL";
         edtavTrn_suppliergen_suppliergenwebsite_Internalname = "TRN_SUPPLIERGEN_SUPPLIERGENWEBSITE";
         chkavIspreffered_Internalname = "vISPREFFERED";
         divSupplierinformation_Internalname = "SUPPLIERINFORMATION";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         edtavTrn_suppliergen_suppliergenaddressline1_Internalname = "TRN_SUPPLIERGEN_SUPPLIERGENADDRESSLINE1";
         edtavTrn_suppliergen_suppliergenaddressline2_Internalname = "TRN_SUPPLIERGEN_SUPPLIERGENADDRESSLINE2";
         edtavTrn_suppliergen_suppliergenaddresszipcode_Internalname = "TRN_SUPPLIERGEN_SUPPLIERGENADDRESSZIPCODE";
         edtavTrn_suppliergen_suppliergenaddresscity_Internalname = "TRN_SUPPLIERGEN_SUPPLIERGENADDRESSCITY";
         lblTextblockcombo_trn_suppliergen_suppliergenaddresscountry_Internalname = "TEXTBLOCKCOMBO_TRN_SUPPLIERGEN_SUPPLIERGENADDRESSCOUNTRY";
         Combo_trn_suppliergen_suppliergenaddresscountry_Internalname = "COMBO_TRN_SUPPLIERGEN_SUPPLIERGENADDRESSCOUNTRY";
         divTablesplittedtrn_suppliergen_suppliergenaddresscountry_Internalname = "TABLESPLITTEDTRN_SUPPLIERGEN_SUPPLIERGENADDRESSCOUNTRY";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         grpUnnamedgroup3_Internalname = "UNNAMEDGROUP3";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtavTrn_suppliergen_suppliergenid_Internalname = "TRN_SUPPLIERGEN_SUPPLIERGENID";
         edtavTrn_suppliergen_suppliergentypename_Internalname = "TRN_SUPPLIERGEN_SUPPLIERGENTYPENAME";
         edtavTrn_suppliergen_suppliergencontactphone_Internalname = "TRN_SUPPLIERGEN_SUPPLIERGENCONTACTPHONE";
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
         chkavIspreffered.Caption = context.GetMessage( "is Preffered", "");
         edtavTrn_suppliergen_suppliergenphonenumber_Enabled = 1;
         edtavTrn_suppliergen_suppliergenwebsite_Enabled = 1;
         edtavTrn_suppliergen_suppliergenemail_Enabled = 1;
         edtavTrn_suppliergen_suppliergencontactname_Enabled = 1;
         edtavTrn_suppliergen_suppliergencompanyname_Enabled = 1;
         edtavTrn_suppliergen_suppliergenkvknumber_Enabled = 1;
         edtavTrn_suppliergen_suppliergenaddresscity_Enabled = 1;
         edtavTrn_suppliergen_suppliergenaddresszipcode_Enabled = 1;
         edtavTrn_suppliergen_suppliergenaddressline2_Enabled = 1;
         edtavTrn_suppliergen_suppliergenaddressline1_Enabled = 1;
         edtavTrn_suppliergen_suppliergencontactphone_Jsonclick = "";
         edtavTrn_suppliergen_suppliergencontactphone_Visible = 1;
         edtavTrn_suppliergen_suppliergentypename_Jsonclick = "";
         edtavTrn_suppliergen_suppliergentypename_Visible = 1;
         edtavTrn_suppliergen_suppliergenid_Jsonclick = "";
         edtavTrn_suppliergen_suppliergenid_Visible = 1;
         bttBtnenter_Visible = 1;
         Combo_trn_suppliergen_suppliergenaddresscountry_Caption = "";
         edtavTrn_suppliergen_suppliergenaddresscity_Jsonclick = "";
         edtavTrn_suppliergen_suppliergenaddresscity_Enabled = 1;
         edtavTrn_suppliergen_suppliergenaddresszipcode_Jsonclick = "";
         edtavTrn_suppliergen_suppliergenaddresszipcode_Enabled = 1;
         edtavTrn_suppliergen_suppliergenaddressline2_Jsonclick = "";
         edtavTrn_suppliergen_suppliergenaddressline2_Enabled = 1;
         edtavTrn_suppliergen_suppliergenaddressline1_Jsonclick = "";
         edtavTrn_suppliergen_suppliergenaddressline1_Enabled = 1;
         chkavIspreffered.Enabled = 1;
         edtavTrn_suppliergen_suppliergenwebsite_Jsonclick = "";
         edtavTrn_suppliergen_suppliergenwebsite_Enabled = 1;
         edtavTrn_suppliergen_suppliergenemail_Jsonclick = "";
         edtavTrn_suppliergen_suppliergenemail_Enabled = 1;
         edtavTrn_suppliergen_suppliergenphonenumber_Jsonclick = "";
         edtavTrn_suppliergen_suppliergenphonenumber_Enabled = 1;
         Combo_trn_suppliergen_suppliergenphonecode_Caption = "";
         edtavTrn_suppliergen_suppliergencontactname_Jsonclick = "";
         edtavTrn_suppliergen_suppliergencontactname_Enabled = 1;
         edtavTrn_suppliergen_suppliergencompanyname_Jsonclick = "";
         edtavTrn_suppliergen_suppliergencompanyname_Enabled = 1;
         edtavTrn_suppliergen_suppliergenkvknumber_Jsonclick = "";
         edtavTrn_suppliergen_suppliergenkvknumber_Enabled = 1;
         divLayoutmaintable_Class = "Table TableTransactionTemplate";
         Combo_trn_suppliergen_suppliergenaddresscountry_Htmltemplate = "";
         Combo_trn_suppliergen_suppliergenaddresscountry_Emptyitem = Convert.ToBoolean( 0);
         Combo_trn_suppliergen_suppliergenaddresscountry_Enabled = Convert.ToBoolean( -1);
         Combo_trn_suppliergen_suppliergenaddresscountry_Cls = "ExtendedCombo ExtendedComboPopupAttribute Attribute ExtendedComboWithImage";
         Combo_trn_suppliergen_suppliergenphonecode_Htmltemplate = "";
         Combo_trn_suppliergen_suppliergenphonecode_Emptyitem = Convert.ToBoolean( 0);
         Combo_trn_suppliergen_suppliergenphonecode_Enabled = Convert.ToBoolean( -1);
         Combo_trn_suppliergen_suppliergenphonecode_Cls = "ExtendedCombo DropDownComponent ExtendedComboWithImage";
         Combo_trn_suppliergen_suppliergentypeid_Emptyitem = Convert.ToBoolean( 0);
         Combo_trn_suppliergen_suppliergentypeid_Enabled = Convert.ToBoolean( -1);
         Combo_trn_suppliergen_suppliergentypeid_Cls = "ExtendedCombo ExtendedComboPopupAttribute";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Add New General Supplier", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV26isPreffered","fld":"vISPREFFERED"},{"av":"AV16TrnMode","fld":"vTRNMODE","hsh":true},{"av":"AV20SupplierGenId","fld":"vSUPPLIERGENID","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"ctrl":"BTNENTER","prop":"Visible"}]}""");
         setEventMetadata("COMBO_TRN_SUPPLIERGEN_SUPPLIERGENTYPEID.ONOPTIONCLICKED","""{"handler":"E117Y2","iparms":[{"av":"Combo_trn_suppliergen_suppliergentypeid_Selectedvalue_get","ctrl":"COMBO_TRN_SUPPLIERGEN_SUPPLIERGENTYPEID","prop":"SelectedValue_get"},{"av":"AV7Trn_SupplierGen","fld":"vTRN_SUPPLIERGEN"}]""");
         setEventMetadata("COMBO_TRN_SUPPLIERGEN_SUPPLIERGENTYPEID.ONOPTIONCLICKED",""","oparms":[{"av":"AV7Trn_SupplierGen","fld":"vTRN_SUPPLIERGEN"}]}""");
         setEventMetadata("ENTER","""{"handler":"E147Y2","iparms":[{"av":"AV16TrnMode","fld":"vTRNMODE","hsh":true},{"av":"AV18CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV7Trn_SupplierGen","fld":"vTRN_SUPPLIERGEN"},{"av":"Combo_trn_suppliergen_suppliergentypeid_Ddointernalname","ctrl":"COMBO_TRN_SUPPLIERGEN_SUPPLIERGENTYPEID","prop":"DDOInternalName"},{"av":"Combo_trn_suppliergen_suppliergenaddresscountry_Ddointernalname","ctrl":"COMBO_TRN_SUPPLIERGEN_SUPPLIERGENADDRESSCOUNTRY","prop":"DDOInternalName"},{"av":"AV26isPreffered","fld":"vISPREFFERED"},{"av":"AV28Trn_PreferredGenSupplier","fld":"vTRN_PREFERREDGENSUPPLIER"},{"av":"AV15Messages","fld":"vMESSAGES"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV7Trn_SupplierGen","fld":"vTRN_SUPPLIERGEN"},{"av":"AV15Messages","fld":"vMESSAGES"},{"av":"AV18CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV28Trn_PreferredGenSupplier","fld":"vTRN_PREFERREDGENSUPPLIER"}]}""");
         setEventMetadata("VALIDV_GXV1","""{"handler":"Validv_Gxv1","iparms":[]}""");
         setEventMetadata("VALIDV_GXV5","""{"handler":"Validv_Gxv5","iparms":[]}""");
         setEventMetadata("VALIDV_GXV11","""{"handler":"Validv_Gxv11","iparms":[]}""");
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
         wcpOAV16TrnMode = "";
         wcpOAV20SupplierGenId = Guid.Empty;
         Combo_trn_suppliergen_suppliergenaddresscountry_Selectedvalue_get = "";
         Combo_trn_suppliergen_suppliergenphonecode_Selectedvalue_get = "";
         Combo_trn_suppliergen_suppliergentypeid_Selectedvalue_get = "";
         Combo_trn_suppliergen_suppliergentypeid_Ddointernalname = "";
         Combo_trn_suppliergen_suppliergenaddresscountry_Ddointernalname = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV7Trn_SupplierGen = new SdtTrn_SupplierGen(context);
         AV8Trn_SupplierGen_SupplierGenTypeId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV12DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11Trn_SupplierGen_SupplierGenPhoneCode_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV23Trn_SupplierGen_SupplierGenAddressCountry_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV28Trn_PreferredGenSupplier = new SdtTrn_PreferredGenSupplier(context);
         AV15Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         Combo_trn_suppliergen_suppliergentypeid_Selectedvalue_set = "";
         Combo_trn_suppliergen_suppliergenphonecode_Selectedvalue_set = "";
         Combo_trn_suppliergen_suppliergenphonecode_Selectedtext_set = "";
         Combo_trn_suppliergen_suppliergenaddresscountry_Selectedvalue_set = "";
         Combo_trn_suppliergen_suppliergenaddresscountry_Selectedtext_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         lblTextblockcombo_trn_suppliergen_suppliergentypeid_Jsonclick = "";
         ucCombo_trn_suppliergen_suppliergentypeid = new GXUserControl();
         Combo_trn_suppliergen_suppliergentypeid_Caption = "";
         lblPhonelabelhome_Jsonclick = "";
         ucCombo_trn_suppliergen_suppliergenphonecode = new GXUserControl();
         lblTextblockcombo_trn_suppliergen_suppliergenaddresscountry_Jsonclick = "";
         ucCombo_trn_suppliergen_suppliergenaddresscountry = new GXUserControl();
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV21WebSession = context.GetSession();
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         GXt_char2 = "";
         AV25defaultCountry = "";
         AV22defaultCountryPhoneCode = "";
         AV42GXV14 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV24Trn_SupplierGen_SupplierGenAddressCountry_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV9Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         AV10ComboTitles = new GxSimpleCollection<string>();
         AV44GXV16 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV13Trn_SupplierGen_SupplierGenPhoneCode_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         H007Y2_A253SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         H007Y2_A254SupplierGenTypeName = new string[] {""} ;
         A253SupplierGenTypeId = Guid.Empty;
         A254SupplierGenTypeName = "";
         AV14Message = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wp_createnewgeneralsupplier__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wp_createnewgeneralsupplier__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_createnewgeneralsupplier__default(),
            new Object[][] {
                new Object[] {
               H007Y2_A253SupplierGenTypeId, H007Y2_A254SupplierGenTypeName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int edtavTrn_suppliergen_suppliergenkvknumber_Enabled ;
      private int edtavTrn_suppliergen_suppliergencompanyname_Enabled ;
      private int edtavTrn_suppliergen_suppliergencontactname_Enabled ;
      private int edtavTrn_suppliergen_suppliergenphonenumber_Enabled ;
      private int edtavTrn_suppliergen_suppliergenemail_Enabled ;
      private int edtavTrn_suppliergen_suppliergenwebsite_Enabled ;
      private int edtavTrn_suppliergen_suppliergenaddressline1_Enabled ;
      private int edtavTrn_suppliergen_suppliergenaddressline2_Enabled ;
      private int edtavTrn_suppliergen_suppliergenaddresszipcode_Enabled ;
      private int edtavTrn_suppliergen_suppliergenaddresscity_Enabled ;
      private int bttBtnenter_Visible ;
      private int edtavTrn_suppliergen_suppliergenid_Visible ;
      private int edtavTrn_suppliergen_suppliergentypename_Visible ;
      private int edtavTrn_suppliergen_suppliergencontactphone_Visible ;
      private int AV43GXV15 ;
      private int AV45GXV17 ;
      private int AV47GXV18 ;
      private int idxLst ;
      private string AV16TrnMode ;
      private string wcpOAV16TrnMode ;
      private string Combo_trn_suppliergen_suppliergenaddresscountry_Selectedvalue_get ;
      private string Combo_trn_suppliergen_suppliergenphonecode_Selectedvalue_get ;
      private string Combo_trn_suppliergen_suppliergentypeid_Selectedvalue_get ;
      private string Combo_trn_suppliergen_suppliergentypeid_Ddointernalname ;
      private string Combo_trn_suppliergen_suppliergenaddresscountry_Ddointernalname ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Combo_trn_suppliergen_suppliergentypeid_Cls ;
      private string Combo_trn_suppliergen_suppliergentypeid_Selectedvalue_set ;
      private string Combo_trn_suppliergen_suppliergenphonecode_Cls ;
      private string Combo_trn_suppliergen_suppliergenphonecode_Selectedvalue_set ;
      private string Combo_trn_suppliergen_suppliergenphonecode_Selectedtext_set ;
      private string Combo_trn_suppliergen_suppliergenphonecode_Htmltemplate ;
      private string Combo_trn_suppliergen_suppliergenaddresscountry_Cls ;
      private string Combo_trn_suppliergen_suppliergenaddresscountry_Selectedvalue_set ;
      private string Combo_trn_suppliergen_suppliergenaddresscountry_Selectedtext_set ;
      private string Combo_trn_suppliergen_suppliergenaddresscountry_Htmltemplate ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTableattributes_Internalname ;
      private string grpUnnamedgroup1_Internalname ;
      private string divSupplierinformation_Internalname ;
      private string edtavTrn_suppliergen_suppliergenkvknumber_Internalname ;
      private string TempTags ;
      private string edtavTrn_suppliergen_suppliergenkvknumber_Jsonclick ;
      private string edtavTrn_suppliergen_suppliergencompanyname_Internalname ;
      private string edtavTrn_suppliergen_suppliergencompanyname_Jsonclick ;
      private string divTablesplittedtrn_suppliergen_suppliergentypeid_Internalname ;
      private string lblTextblockcombo_trn_suppliergen_suppliergentypeid_Internalname ;
      private string lblTextblockcombo_trn_suppliergen_suppliergentypeid_Jsonclick ;
      private string Combo_trn_suppliergen_suppliergentypeid_Caption ;
      private string Combo_trn_suppliergen_suppliergentypeid_Internalname ;
      private string edtavTrn_suppliergen_suppliergencontactname_Internalname ;
      private string edtavTrn_suppliergen_suppliergencontactname_Jsonclick ;
      private string divUnnamedtable4_Internalname ;
      private string lblPhonelabelhome_Internalname ;
      private string lblPhonelabelhome_Jsonclick ;
      private string divUnnamedtable5_Internalname ;
      private string divUnnamedtable6_Internalname ;
      private string Combo_trn_suppliergen_suppliergenphonecode_Caption ;
      private string Combo_trn_suppliergen_suppliergenphonecode_Internalname ;
      private string divUnnamedtable7_Internalname ;
      private string edtavTrn_suppliergen_suppliergenphonenumber_Internalname ;
      private string edtavTrn_suppliergen_suppliergenphonenumber_Jsonclick ;
      private string edtavTrn_suppliergen_suppliergenemail_Internalname ;
      private string edtavTrn_suppliergen_suppliergenemail_Jsonclick ;
      private string edtavTrn_suppliergen_suppliergenwebsite_Internalname ;
      private string edtavTrn_suppliergen_suppliergenwebsite_Jsonclick ;
      private string chkavIspreffered_Internalname ;
      private string grpUnnamedgroup3_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string edtavTrn_suppliergen_suppliergenaddressline1_Internalname ;
      private string edtavTrn_suppliergen_suppliergenaddressline1_Jsonclick ;
      private string edtavTrn_suppliergen_suppliergenaddressline2_Internalname ;
      private string edtavTrn_suppliergen_suppliergenaddressline2_Jsonclick ;
      private string edtavTrn_suppliergen_suppliergenaddresszipcode_Internalname ;
      private string edtavTrn_suppliergen_suppliergenaddresszipcode_Jsonclick ;
      private string edtavTrn_suppliergen_suppliergenaddresscity_Internalname ;
      private string edtavTrn_suppliergen_suppliergenaddresscity_Jsonclick ;
      private string divTablesplittedtrn_suppliergen_suppliergenaddresscountry_Internalname ;
      private string lblTextblockcombo_trn_suppliergen_suppliergenaddresscountry_Internalname ;
      private string lblTextblockcombo_trn_suppliergen_suppliergenaddresscountry_Jsonclick ;
      private string Combo_trn_suppliergen_suppliergenaddresscountry_Caption ;
      private string Combo_trn_suppliergen_suppliergenaddresscountry_Internalname ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavTrn_suppliergen_suppliergenid_Internalname ;
      private string edtavTrn_suppliergen_suppliergenid_Jsonclick ;
      private string edtavTrn_suppliergen_suppliergentypename_Internalname ;
      private string edtavTrn_suppliergen_suppliergentypename_Jsonclick ;
      private string edtavTrn_suppliergen_suppliergencontactphone_Internalname ;
      private string edtavTrn_suppliergen_suppliergencontactphone_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string GXt_char2 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV18CheckRequiredFieldsResult ;
      private bool Combo_trn_suppliergen_suppliergentypeid_Enabled ;
      private bool Combo_trn_suppliergen_suppliergentypeid_Emptyitem ;
      private bool Combo_trn_suppliergen_suppliergenphonecode_Enabled ;
      private bool Combo_trn_suppliergen_suppliergenphonecode_Emptyitem ;
      private bool Combo_trn_suppliergen_suppliergenaddresscountry_Enabled ;
      private bool Combo_trn_suppliergen_suppliergenaddresscountry_Emptyitem ;
      private bool wbLoad ;
      private bool AV26isPreffered ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV17LoadSuccess ;
      private string AV25defaultCountry ;
      private string AV22defaultCountryPhoneCode ;
      private string A254SupplierGenTypeName ;
      private Guid AV20SupplierGenId ;
      private Guid wcpOAV20SupplierGenId ;
      private Guid A253SupplierGenTypeId ;
      private GXUserControl ucCombo_trn_suppliergen_suppliergentypeid ;
      private GXUserControl ucCombo_trn_suppliergen_suppliergenphonecode ;
      private GXUserControl ucCombo_trn_suppliergen_suppliergenaddresscountry ;
      private IGxSession AV21WebSession ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavIspreffered ;
      private SdtTrn_SupplierGen AV7Trn_SupplierGen ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV8Trn_SupplierGen_SupplierGenTypeId_Data ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV12DDO_TitleSettingsIcons ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV11Trn_SupplierGen_SupplierGenPhoneCode_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV23Trn_SupplierGen_SupplierGenAddressCountry_Data ;
      private SdtTrn_PreferredGenSupplier AV28Trn_PreferredGenSupplier ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV15Messages ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV42GXV14 ;
      private SdtSDT_Country_SDT_CountryItem AV24Trn_SupplierGen_SupplierGenAddressCountry_DPItem ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV9Combo_DataItem ;
      private GxSimpleCollection<string> AV10ComboTitles ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV44GXV16 ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> GXt_objcol_SdtSDT_Country_SDT_CountryItem3 ;
      private SdtSDT_Country_SDT_CountryItem AV13Trn_SupplierGen_SupplierGenPhoneCode_DPItem ;
      private IDataStoreProvider pr_default ;
      private Guid[] H007Y2_A253SupplierGenTypeId ;
      private string[] H007Y2_A254SupplierGenTypeName ;
      private GeneXus.Utils.SdtMessages_Message AV14Message ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wp_createnewgeneralsupplier__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wp_createnewgeneralsupplier__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wp_createnewgeneralsupplier__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmH007Y2;
       prmH007Y2 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("H007Y2", "SELECT SupplierGenTypeId, SupplierGenTypeName FROM Trn_SupplierGenType ORDER BY SupplierGenTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007Y2,100, GxCacheFrequency.OFF ,false,false )
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
             return;
    }
 }

}

}
