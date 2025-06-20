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
   public class wc_productservice : GXDataArea
   {
      public wc_productservice( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wc_productservice( IGxContext context )
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
         cmbavProductserviceclass = new GXCombobox();
         dynavProductservicegroup = new GXCombobox();
         chkavNofilteragb = new GXCheckbox();
         chkavNofiltergen = new GXCheckbox();
         cmbavCalltoactiontype = new GXCombobox();
         cmbavSdt_calltoaction__calltoactiontype = new GXCombobox();
         cmbavGridactiongroup1 = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vPRODUCTSERVICEGROUP") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDSVvPRODUCTSERVICEGROUPA02( ) ;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridsdt_calltoactions") == 0 )
            {
               gxnrGridsdt_calltoactions_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridsdt_calltoactions") == 0 )
            {
               gxgrGridsdt_calltoactions_refresh_invoke( ) ;
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

      protected void gxnrGridsdt_calltoactions_newrow_invoke( )
      {
         nRC_GXsfl_180 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_180"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_180_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_180_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_180_idx = GetPar( "sGXsfl_180_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridsdt_calltoactions_newrow( ) ;
         /* End function gxnrGridsdt_calltoactions_newrow_invoke */
      }

      protected void gxgrGridsdt_calltoactions_refresh_invoke( )
      {
         subGridsdt_calltoactions_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridsdt_calltoactions_Rows"), "."), 18, MidpointRounding.ToEven));
         AV36Step = (short)(Math.Round(NumberUtil.Val( GetPar( "Step"), "."), 18, MidpointRounding.ToEven));
         dynavProductservicegroup.FromJSonString( GetNextPar( ));
         AV13ProductServiceGroup = GetPar( "ProductServiceGroup");
         AV42noFilterAgb = StringUtil.StrToBool( GetPar( "noFilterAgb"));
         AV40noFilterGen = StringUtil.StrToBool( GetPar( "noFilterGen"));
         AV47OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridsdt_calltoactions_refresh( subGridsdt_calltoactions_Rows, AV36Step, AV13ProductServiceGroup, AV42noFilterAgb, AV40noFilterGen, AV47OrganisationId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridsdt_calltoactions_refresh_invoke */
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
         PAA02( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTA02( ) ;
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
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
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
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wc_productservice.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36Step), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSTEP", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV36Step), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV47OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV47OrganisationId, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdt_calltoaction", AV49SDT_CallToAction);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdt_calltoaction", AV49SDT_CallToAction);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_180", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_180), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUPLOADEDFILES", AV17UploadedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUPLOADEDFILES", AV17UploadedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFAILEDFILES", AV18FailedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFAILEDFILES", AV18FailedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSUPPLIERAGBID_DATA", AV46SupplierAgbId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSUPPLIERAGBID_DATA", AV46SupplierAgbId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSUPPLIERGENID_DATA", AV43SupplierGenId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSUPPLIERGENID_DATA", AV43SupplierGenId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV30DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV30DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPHONECODE_DATA", AV34PhoneCode_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPHONECODE_DATA", AV34PhoneCode_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLOCATIONDYNAMICFORMID_DATA", AV29LocationDynamicFormId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLOCATIONDYNAMICFORMID_DATA", AV29LocationDynamicFormId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36Step), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSTEP", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV36Step), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "SUPPLIERGENCOMPANYNAME", A44SupplierGenCompanyName);
         GxWebStd.gx_hidden_field( context, "ORGANISATIONID", A11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV47OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV47OrganisationId, context));
         GxWebStd.gx_hidden_field( context, "SUPPLIERGENID", A42SupplierGenId.ToString());
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDT_CALLTOACTION", AV49SDT_CallToAction);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDT_CALLTOACTION", AV49SDT_CallToAction);
         }
         GxWebStd.gx_hidden_field( context, "GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRIDSDT_CALLTOACTIONS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_CALLTOACTIONS_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRIDSDT_CALLTOACTIONS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONDYNAMICFORMID_Selectedvalue_get", StringUtil.RTrim( Combo_locationdynamicformid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_PHONECODE_Selectedvalue_get", StringUtil.RTrim( Combo_phonecode_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENID_Selectedvalue_get", StringUtil.RTrim( Combo_suppliergenid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERAGBID_Selectedvalue_get", StringUtil.RTrim( Combo_supplieragbid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONDYNAMICFORMID_Selectedvalue_get", StringUtil.RTrim( Combo_locationdynamicformid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENID_Selectedvalue_get", StringUtil.RTrim( Combo_suppliergenid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERAGBID_Selectedvalue_get", StringUtil.RTrim( Combo_supplieragbid_Selectedvalue_get));
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
            WEA02( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTA02( ) ;
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
         return formatLink("wc_productservice.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WC_ProductService" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Product/Service", "") ;
      }

      protected void WBA00( )
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divServicetable_Internalname, divServicetable_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup8_Internalname, context.GetMessage( "Service", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WC_ProductService.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divServicegroup_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable9_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavProductservicename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProductservicename_Internalname, context.GetMessage( "Name", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'" + sGXsfl_180_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProductservicename_Internalname, AV8ProductServiceName, StringUtil.RTrim( context.localUtil.Format( AV8ProductServiceName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProductservicename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavProductservicename_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WC_ProductService.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavProductservicetilename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProductservicetilename_Internalname, context.GetMessage( "Tile Name", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'" + sGXsfl_180_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProductservicetilename_Internalname, StringUtil.RTrim( AV9ProductServiceTileName), StringUtil.RTrim( context.localUtil.Format( AV9ProductServiceTileName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProductservicetilename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavProductservicetilename_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WC_ProductService.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable12_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "end", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblProductserviceimagetext_Internalname, context.GetMessage( "Image", ""), "", "", lblProductserviceimagetext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WC_ProductService.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUcfilecell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-lg-5", "start", "top", "", "", "div");
            wb_table1_40_A02( true) ;
         }
         else
         {
            wb_table1_40_A02( false) ;
         }
         return  ;
      }

      protected void wb_table1_40_A02e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable10_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavProductserviceclass_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavProductserviceclass_Internalname, context.GetMessage( "Category", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_180_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavProductserviceclass, cmbavProductserviceclass_Internalname, StringUtil.RTrim( AV12ProductServiceClass), 1, cmbavProductserviceclass_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavProductserviceclass.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "", true, 0, "HLP_WC_ProductService.htm");
            cmbavProductserviceclass.CurrentValue = StringUtil.RTrim( AV12ProductServiceClass);
            AssignProp("", false, cmbavProductserviceclass_Internalname, "Values", (string)(cmbavProductserviceclass.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynavProductservicegroup_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavProductservicegroup_Internalname, context.GetMessage( "Supplier Type", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'" + sGXsfl_180_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavProductservicegroup, dynavProductservicegroup_Internalname, StringUtil.RTrim( AV13ProductServiceGroup), 1, dynavProductservicegroup_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, dynavProductservicegroup.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "", true, 0, "HLP_WC_ProductService.htm");
            dynavProductservicegroup.CurrentValue = StringUtil.RTrim( AV13ProductServiceGroup);
            AssignProp("", false, dynavProductservicegroup_Internalname, "Values", (string)(dynavProductservicegroup.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable11_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesupplieragb_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedsupplieragbid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_supplieragbid_Internalname, context.GetMessage( "AGB Supplier", ""), "", "", lblTextblockcombo_supplieragbid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WC_ProductService.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table2_72_A02( true) ;
         }
         else
         {
            wb_table2_72_A02( false) ;
         }
         return  ;
      }

      protected void wb_table2_72_A02e( bool wbgen )
      {
         if ( wbgen )
         {
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
            GxWebStd.gx_div_start( context, divTablesuppliergen_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedsuppliergenid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_suppliergenid_Internalname, context.GetMessage( "General Supplier", ""), "", "", lblTextblockcombo_suppliergenid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WC_ProductService.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table3_89_A02( true) ;
         }
         else
         {
            wb_table3_89_A02( false) ;
         }
         return  ;
      }

      protected void wb_table3_89_A02e( bool wbgen )
      {
         if ( wbgen )
         {
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavProductservicedescription_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProductservicedescription_Internalname, context.GetMessage( "Description", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'" + sGXsfl_180_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavProductservicedescription_Internalname, AV20ProductServiceDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,100);\"", 0, 1, edtavProductservicedescription_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WC_ProductService.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, divCalltoactionstable_Internalname, divCalltoactionstable_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, context.GetMessage( "Call To Actions", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WC_ProductService.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCalltoactionsgroup_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavCalltoactiontype_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCalltoactiontype_Internalname, context.GetMessage( "Type", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'" + sGXsfl_180_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCalltoactiontype, cmbavCalltoactiontype_Internalname, StringUtil.RTrim( AV22CallToActionType), 1, cmbavCalltoactiontype_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavCalltoactiontype.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,112);\"", "", true, 0, "HLP_WC_ProductService.htm");
            cmbavCalltoactiontype.CurrentValue = StringUtil.RTrim( AV22CallToActionType);
            AssignProp("", false, cmbavCalltoactiontype_Internalname, "Values", (string)(cmbavCalltoactiontype.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCalltoactionname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCalltoactionname_Internalname, context.GetMessage( "Label", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'" + sGXsfl_180_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCalltoactionname_Internalname, AV23CallToActionName, StringUtil.RTrim( context.localUtil.Format( AV23CallToActionName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,117);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCalltoactionname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCalltoactionname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WC_ProductService.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable4_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableurl_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCalltoactionurl_cell_Internalname, 1, 0, "px", 0, "px", divCalltoactionurl_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCalltoactionurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCalltoactionurl_Internalname, context.GetMessage( "Url", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'" + sGXsfl_180_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCalltoactionurl_Internalname, AV28CallToActionUrl, StringUtil.RTrim( context.localUtil.Format( AV28CallToActionUrl, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,128);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "https://example.com", ""), edtavCalltoactionurl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCalltoactionurl_Enabled, 0, "text", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WC_ProductService.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablephone_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPhonelabel_Internalname, context.GetMessage( "Phone", ""), "", "", lblPhonelabel_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WC_ProductService.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 PhoneLabel ExtendedComboCell", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_phonecode.SetProperty("Caption", Combo_phonecode_Caption);
            ucCombo_phonecode.SetProperty("Cls", Combo_phonecode_Cls);
            ucCombo_phonecode.SetProperty("EmptyItem", Combo_phonecode_Emptyitem);
            ucCombo_phonecode.SetProperty("DropDownOptionsTitleSettingsIcons", AV30DDO_TitleSettingsIcons);
            ucCombo_phonecode.SetProperty("DropDownOptionsData", AV34PhoneCode_Data);
            ucCombo_phonecode.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_phonecode_Internalname, "COMBO_PHONECODEContainer");
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
            GxWebStd.gx_div_start( context, divPhonenumber_cell_Internalname, 1, 0, "px", 0, "px", divPhonenumber_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPhonenumber_Internalname, context.GetMessage( "Phone Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'',false,'" + sGXsfl_180_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPhonenumber_Internalname, AV26PhoneNumber, StringUtil.RTrim( context.localUtil.Format( AV26PhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,148);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPhonenumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavPhonenumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WC_ProductService.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableform_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCombo_locationdynamicformid_cell_Internalname, 1, 0, "px", 0, "px", divCombo_locationdynamicformid_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedlocationdynamicformid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_locationdynamicformid_Internalname, context.GetMessage( "Form", ""), "", "", lblTextblockcombo_locationdynamicformid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WC_ProductService.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_locationdynamicformid.SetProperty("Caption", Combo_locationdynamicformid_Caption);
            ucCombo_locationdynamicformid.SetProperty("Cls", Combo_locationdynamicformid_Cls);
            ucCombo_locationdynamicformid.SetProperty("EmptyItem", Combo_locationdynamicformid_Emptyitem);
            ucCombo_locationdynamicformid.SetProperty("DropDownOptionsTitleSettingsIcons", AV30DDO_TitleSettingsIcons);
            ucCombo_locationdynamicformid.SetProperty("DropDownOptionsData", AV29LocationDynamicFormId_Data);
            ucCombo_locationdynamicformid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_locationdynamicformid_Internalname, "COMBO_LOCATIONDYNAMICFORMIDContainer");
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
            GxWebStd.gx_div_start( context, divTableemail_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCalltoactionemail_cell_Internalname, 1, 0, "px", 0, "px", divCalltoactionemail_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCalltoactionemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCalltoactionemail_Internalname, context.GetMessage( "Email", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 167,'',false,'" + sGXsfl_180_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCalltoactionemail_Internalname, AV24CallToActionEmail, StringUtil.RTrim( context.localUtil.Format( AV24CallToActionEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,167);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "johndoe@gmail.com", ""), edtavCalltoactionemail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCalltoactionemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WC_ProductService.htm");
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
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 172,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseractionadd_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(180), 3, 0)+","+"null"+");", context.GetMessage( "Save", ""), bttBtnuseractionadd_Jsonclick, 7, context.GetMessage( "Save", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e11a01_client"+"'", TempTags, "", 2, "HLP_WC_ProductService.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 174,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseractionclear_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(180), 3, 0)+","+"null"+");", context.GetMessage( "Cancel", ""), bttBtnuseractionclear_Jsonclick, 7, context.GetMessage( "Cancel", ""), "", StyleString, ClassString, bttBtnuseractionclear_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e12a01_client"+"'", TempTags, "", 2, "HLP_WC_ProductService.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            Gridsdt_calltoactionsContainer.SetWrapped(nGXWrapped);
            StartGridControl180( ) ;
         }
         if ( wbEnd == 180 )
         {
            wbEnd = 0;
            nRC_GXsfl_180 = (int)(nGXsfl_180_idx-1);
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Gridsdt_calltoactionsContainer.AddObjectProperty("GRIDSDT_CALLTOACTIONS_nEOF", GRIDSDT_CALLTOACTIONS_nEOF);
               Gridsdt_calltoactionsContainer.AddObjectProperty("GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage", GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage);
               AV54GXV1 = nGXsfl_180_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Gridsdt_calltoactionsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridsdt_calltoactions", Gridsdt_calltoactionsContainer, subGridsdt_calltoactions_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Gridsdt_calltoactionsContainerData", Gridsdt_calltoactionsContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Gridsdt_calltoactionsContainerData"+"V", Gridsdt_calltoactionsContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridsdt_calltoactionsContainerData"+"V"+"\" value='"+Gridsdt_calltoactionsContainer.GridValuesHidden()+"'/>") ;
               }
            }
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
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* User Defined Control */
            ucBtnprevious.SetProperty("TooltipText", Btnprevious_Tooltiptext);
            ucBtnprevious.SetProperty("BeforeIconClass", Btnprevious_Beforeiconclass);
            ucBtnprevious.SetProperty("Caption", Btnprevious_Caption);
            ucBtnprevious.SetProperty("Class", Btnprevious_Class);
            ucBtnprevious.Render(context, "wwp_iconbutton", Btnprevious_Internalname, "BTNPREVIOUSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "end", "top", "", "", "div");
            /* User Defined Control */
            ucBtnnext.SetProperty("TooltipText", Btnnext_Tooltiptext);
            ucBtnnext.SetProperty("AfterIconClass", Btnnext_Aftericonclass);
            ucBtnnext.SetProperty("Caption", Btnnext_Caption);
            ucBtnnext.SetProperty("Class", Btnnext_Class);
            ucBtnnext.Render(context, "wwp_iconbutton", Btnnext_Internalname, "BTNNEXTContainer");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 204,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnfinish_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(180), 3, 0)+","+"null"+");", context.GetMessage( "Finish", ""), bttBtnfinish_Jsonclick, 7, context.GetMessage( "Finish", ""), "", StyleString, ClassString, bttBtnfinish_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e13a01_client"+"'", TempTags, "", 2, "HLP_WC_ProductService.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 208,'',false,'" + sGXsfl_180_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSupplieragbid_Internalname, AV41SupplierAgbId.ToString(), AV41SupplierAgbId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,208);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSupplieragbid_Jsonclick, 0, "Attribute", "", "", "", "", edtavSupplieragbid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WC_ProductService.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 209,'',false,'" + sGXsfl_180_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSuppliergenid_Internalname, AV39SupplierGenId.ToString(), AV39SupplierGenId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,209);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSuppliergenid_Jsonclick, 0, "Attribute", "", "", "", "", edtavSuppliergenid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WC_ProductService.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 210,'',false,'" + sGXsfl_180_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPhonecode_Internalname, AV27PhoneCode, StringUtil.RTrim( context.localUtil.Format( AV27PhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,210);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPhonecode_Jsonclick, 0, "Attribute", "", "", "", "", edtavPhonecode_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WC_ProductService.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 211,'',false,'" + sGXsfl_180_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLocationdynamicformid_Internalname, AV25LocationDynamicFormId.ToString(), AV25LocationDynamicFormId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,211);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLocationdynamicformid_Jsonclick, 0, "Attribute", "", "", "", "", edtavLocationdynamicformid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WC_ProductService.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 212,'',false,'" + sGXsfl_180_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCalltoactionid_Internalname, AV21CallToActionId.ToString(), AV21CallToActionId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,212);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCalltoactionid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCalltoactionid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WC_ProductService.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 213,'',false,'" + sGXsfl_180_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWwpformreferencename_Internalname, AV52WWPFormReferenceName, StringUtil.RTrim( context.localUtil.Format( AV52WWPFormReferenceName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,213);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWwpformreferencename_Jsonclick, 0, "Attribute", "", "", "", "", edtavWwpformreferencename_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WC_ProductService.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 214,'',false,'" + sGXsfl_180_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCalltoactionphone_Internalname, StringUtil.RTrim( AV53CallToActionPhone), StringUtil.RTrim( context.localUtil.Format( AV53CallToActionPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,214);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCalltoactionphone_Jsonclick, 0, "Attribute", "", "", "", "", edtavCalltoactionphone_Visible, 1, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WC_ProductService.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 215,'',false,'" + sGXsfl_180_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLocationid_Internalname, AV14LocationId.ToString(), AV14LocationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,215);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLocationid_Jsonclick, 0, "Attribute", "", "", "", "", edtavLocationid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WC_ProductService.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 216,'',false,'" + sGXsfl_180_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProductserviceid_Internalname, AV7ProductServiceId.ToString(), AV7ProductServiceId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,216);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProductserviceid_Jsonclick, 0, "Attribute", "", "", "", "", edtavProductserviceid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WC_ProductService.htm");
            /* User Defined Control */
            ucGridsdt_calltoactions_empowerer.Render(context, "wwp.gridempowerer", Gridsdt_calltoactions_empowerer_Internalname, "GRIDSDT_CALLTOACTIONS_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 180 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Gridsdt_calltoactionsContainer.AddObjectProperty("GRIDSDT_CALLTOACTIONS_nEOF", GRIDSDT_CALLTOACTIONS_nEOF);
                  Gridsdt_calltoactionsContainer.AddObjectProperty("GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage", GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage);
                  AV54GXV1 = nGXsfl_180_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Gridsdt_calltoactionsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridsdt_calltoactions", Gridsdt_calltoactionsContainer, subGridsdt_calltoactions_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Gridsdt_calltoactionsContainerData", Gridsdt_calltoactionsContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Gridsdt_calltoactionsContainerData"+"V", Gridsdt_calltoactionsContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridsdt_calltoactionsContainerData"+"V"+"\" value='"+Gridsdt_calltoactionsContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void STARTA02( )
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
         Form.Meta.addItem("description", context.GetMessage( "Product/Service", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPA00( ) ;
      }

      protected void WSA02( )
      {
         STARTA02( ) ;
         EVTA02( ) ;
      }

      protected void EVTA02( )
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_SUPPLIERAGBID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_supplieragbid.Onoptionclicked */
                              E14A02 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_SUPPLIERGENID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_suppliergenid.Onoptionclicked */
                              E15A02 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_LOCATIONDYNAMICFORMID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_locationdynamicformid.Onoptionclicked */
                              E16A02 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSDT_CALLTOACTIONSPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDSDT_CALLTOACTIONSPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgridsdt_calltoactions_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgridsdt_calltoactions_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgridsdt_calltoactions_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgridsdt_calltoactions_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 26), "GRIDSDT_CALLTOACTIONS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_180_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_180_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_180_idx), 4, 0), 4, "0");
                              SubsflControlProps_1802( ) ;
                              AV54GXV1 = (int)(nGXsfl_180_idx+GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage);
                              if ( ( AV49SDT_CallToAction.Count >= AV54GXV1 ) && ( AV54GXV1 > 0 ) )
                              {
                                 AV49SDT_CallToAction.CurrentItem = ((SdtSDT_CallToAction_SDT_CallToActionItem)AV49SDT_CallToAction.Item(AV54GXV1));
                                 AV50CallToActionVariable = cgiGet( edtavCalltoactionvariable_Internalname);
                                 AssignAttri("", false, edtavCalltoactionvariable_Internalname, AV50CallToActionVariable);
                                 cmbavGridactiongroup1.Name = cmbavGridactiongroup1_Internalname;
                                 cmbavGridactiongroup1.CurrentValue = cgiGet( cmbavGridactiongroup1_Internalname);
                                 AV51GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactiongroup1_Internalname), "."), 18, MidpointRounding.ToEven));
                                 AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV51GridActionGroup1), 4, 0));
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
                                    E17A02 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E18A02 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDSDT_CALLTOACTIONS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridsdt_calltoactions.Load */
                                    E19A02 ();
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

      protected void WEA02( )
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

      protected void PAA02( )
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
               GX_FocusControl = edtavProductservicename_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDSVvPRODUCTSERVICEGROUPA02( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDSVvPRODUCTSERVICEGROUP_dataA02( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrldescr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrldescr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvPRODUCTSERVICEGROUP_htmlA02( )
      {
         string gxdynajaxvalue;
         GXDSVvPRODUCTSERVICEGROUP_dataA02( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavProductservicegroup.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex));
            dynavProductservicegroup.addItem(gxdynajaxvalue, ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDSVvPRODUCTSERVICEGROUP_dataA02( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add("");
         gxdynajaxctrldescr.Add(context.GetMessage( "Select Supplier Type", ""));
         GXBaseCollection<SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem> gxcolvPRODUCTSERVICEGROUP;
         SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem gxcolitemvPRODUCTSERVICEGROUP;
         new dp_productservicesuppliergroup(context ).execute( out  gxcolvPRODUCTSERVICEGROUP) ;
         gxcolvPRODUCTSERVICEGROUP.Sort("Sdt_productservicesuppliergroupname");
         int gxindex = 1;
         while ( gxindex <= gxcolvPRODUCTSERVICEGROUP.Count )
         {
            gxcolitemvPRODUCTSERVICEGROUP = ((SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem)gxcolvPRODUCTSERVICEGROUP.Item(gxindex));
            gxdynajaxctrlcodr.Add(gxcolitemvPRODUCTSERVICEGROUP.gxTpr_Sdt_productservicesuppliergroupid);
            gxdynajaxctrldescr.Add(gxcolitemvPRODUCTSERVICEGROUP.gxTpr_Sdt_productservicesuppliergroupname);
            gxindex = (int)(gxindex+1);
         }
      }

      protected void gxnrGridsdt_calltoactions_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1802( ) ;
         while ( nGXsfl_180_idx <= nRC_GXsfl_180 )
         {
            sendrow_1802( ) ;
            nGXsfl_180_idx = ((subGridsdt_calltoactions_Islastpage==1)&&(nGXsfl_180_idx+1>subGridsdt_calltoactions_fnc_Recordsperpage( )) ? 1 : nGXsfl_180_idx+1);
            sGXsfl_180_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_180_idx), 4, 0), 4, "0");
            SubsflControlProps_1802( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridsdt_calltoactionsContainer)) ;
         /* End function gxnrGridsdt_calltoactions_newrow */
      }

      protected void gxgrGridsdt_calltoactions_refresh( int subGridsdt_calltoactions_Rows ,
                                                        short AV36Step ,
                                                        string AV13ProductServiceGroup ,
                                                        bool AV42noFilterAgb ,
                                                        bool AV40noFilterGen ,
                                                        Guid AV47OrganisationId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDSDT_CALLTOACTIONS_nCurrentRecord = 0;
         RFA02( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGridsdt_calltoactions_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvPRODUCTSERVICEGROUP_htmlA02( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbavProductserviceclass.ItemCount > 0 )
         {
            AV12ProductServiceClass = cmbavProductserviceclass.getValidValue(AV12ProductServiceClass);
            AssignAttri("", false, "AV12ProductServiceClass", AV12ProductServiceClass);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavProductserviceclass.CurrentValue = StringUtil.RTrim( AV12ProductServiceClass);
            AssignProp("", false, cmbavProductserviceclass_Internalname, "Values", cmbavProductserviceclass.ToJavascriptSource(), true);
         }
         if ( dynavProductservicegroup.ItemCount > 0 )
         {
            AV13ProductServiceGroup = dynavProductservicegroup.getValidValue(AV13ProductServiceGroup);
            AssignAttri("", false, "AV13ProductServiceGroup", AV13ProductServiceGroup);
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavProductservicegroup.CurrentValue = StringUtil.RTrim( AV13ProductServiceGroup);
            AssignProp("", false, dynavProductservicegroup_Internalname, "Values", dynavProductservicegroup.ToJavascriptSource(), true);
         }
         AV42noFilterAgb = StringUtil.StrToBool( StringUtil.BoolToStr( AV42noFilterAgb));
         AssignAttri("", false, "AV42noFilterAgb", AV42noFilterAgb);
         AV40noFilterGen = StringUtil.StrToBool( StringUtil.BoolToStr( AV40noFilterGen));
         AssignAttri("", false, "AV40noFilterGen", AV40noFilterGen);
         if ( cmbavCalltoactiontype.ItemCount > 0 )
         {
            AV22CallToActionType = cmbavCalltoactiontype.getValidValue(AV22CallToActionType);
            AssignAttri("", false, "AV22CallToActionType", AV22CallToActionType);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCalltoactiontype.CurrentValue = StringUtil.RTrim( AV22CallToActionType);
            AssignProp("", false, cmbavCalltoactiontype_Internalname, "Values", cmbavCalltoactiontype.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFA02( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavFilename_Enabled = 0;
         AssignProp("", false, edtavFilename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFilename_Enabled), 5, 0), true);
         edtavSdt_calltoaction__calltoactionid_Enabled = 0;
         edtavSdt_calltoaction__organisationid_Enabled = 0;
         edtavSdt_calltoaction__locationid_Enabled = 0;
         edtavSdt_calltoaction__productserviceid_Enabled = 0;
         edtavSdt_calltoaction__calltoactionname_Enabled = 0;
         cmbavSdt_calltoaction__calltoactiontype.Enabled = 0;
         edtavSdt_calltoaction__calltoactionphone_Enabled = 0;
         edtavSdt_calltoaction__calltoactionurl_Enabled = 0;
         edtavSdt_calltoaction__calltoactionemail_Enabled = 0;
         edtavSdt_calltoaction__locationdynamicformid_Enabled = 0;
         edtavSdt_calltoaction__wwpformreferencename_Enabled = 0;
         edtavCalltoactionvariable_Enabled = 0;
      }

      protected void RFA02( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Gridsdt_calltoactionsContainer.ClearRows();
         }
         wbStart = 180;
         /* Execute user event: Refresh */
         E18A02 ();
         nGXsfl_180_idx = 1;
         sGXsfl_180_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_180_idx), 4, 0), 4, "0");
         SubsflControlProps_1802( ) ;
         bGXsfl_180_Refreshing = true;
         Gridsdt_calltoactionsContainer.AddObjectProperty("GridName", "Gridsdt_calltoactions");
         Gridsdt_calltoactionsContainer.AddObjectProperty("CmpContext", "");
         Gridsdt_calltoactionsContainer.AddObjectProperty("InMasterPage", "false");
         Gridsdt_calltoactionsContainer.AddObjectProperty("Class", "WorkWith");
         Gridsdt_calltoactionsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridsdt_calltoactionsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridsdt_calltoactionsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Backcolorstyle), 1, 0, ".", "")));
         Gridsdt_calltoactionsContainer.PageSize = subGridsdt_calltoactions_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1802( ) ;
            /* Execute user event: Gridsdt_calltoactions.Load */
            E19A02 ();
            if ( ( subGridsdt_calltoactions_Islastpage == 0 ) && ( GRIDSDT_CALLTOACTIONS_nCurrentRecord > 0 ) && ( GRIDSDT_CALLTOACTIONS_nGridOutOfScope == 0 ) && ( nGXsfl_180_idx == 1 ) )
            {
               GRIDSDT_CALLTOACTIONS_nCurrentRecord = 0;
               GRIDSDT_CALLTOACTIONS_nGridOutOfScope = 1;
               subgridsdt_calltoactions_firstpage( ) ;
               /* Execute user event: Gridsdt_calltoactions.Load */
               E19A02 ();
            }
            wbEnd = 180;
            WBA00( ) ;
         }
         bGXsfl_180_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesA02( )
      {
         GxWebStd.gx_hidden_field( context, "vSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36Step), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSTEP", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV36Step), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV47OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV47OrganisationId, context));
      }

      protected int subGridsdt_calltoactions_fnc_Pagecount( )
      {
         GRIDSDT_CALLTOACTIONS_nRecordCount = subGridsdt_calltoactions_fnc_Recordcount( );
         if ( ((int)((GRIDSDT_CALLTOACTIONS_nRecordCount) % (subGridsdt_calltoactions_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDSDT_CALLTOACTIONS_nRecordCount/ (decimal)(subGridsdt_calltoactions_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDSDT_CALLTOACTIONS_nRecordCount/ (decimal)(subGridsdt_calltoactions_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGridsdt_calltoactions_fnc_Recordcount( )
      {
         return AV49SDT_CallToAction.Count ;
      }

      protected int subGridsdt_calltoactions_fnc_Recordsperpage( )
      {
         if ( subGridsdt_calltoactions_Rows > 0 )
         {
            return subGridsdt_calltoactions_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGridsdt_calltoactions_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage/ (decimal)(subGridsdt_calltoactions_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgridsdt_calltoactions_firstpage( )
      {
         GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_calltoactions_refresh( subGridsdt_calltoactions_Rows, AV36Step, AV13ProductServiceGroup, AV42noFilterAgb, AV40noFilterGen, AV47OrganisationId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridsdt_calltoactions_nextpage( )
      {
         GRIDSDT_CALLTOACTIONS_nRecordCount = subGridsdt_calltoactions_fnc_Recordcount( );
         if ( ( GRIDSDT_CALLTOACTIONS_nRecordCount >= subGridsdt_calltoactions_fnc_Recordsperpage( ) ) && ( GRIDSDT_CALLTOACTIONS_nEOF == 0 ) )
         {
            GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = (long)(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage+subGridsdt_calltoactions_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage), 15, 0, ".", "")));
         Gridsdt_calltoactionsContainer.AddObjectProperty("GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage", GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_calltoactions_refresh( subGridsdt_calltoactions_Rows, AV36Step, AV13ProductServiceGroup, AV42noFilterAgb, AV40noFilterGen, AV47OrganisationId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDSDT_CALLTOACTIONS_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridsdt_calltoactions_previouspage( )
      {
         if ( GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage >= subGridsdt_calltoactions_fnc_Recordsperpage( ) )
         {
            GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = (long)(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage-subGridsdt_calltoactions_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_calltoactions_refresh( subGridsdt_calltoactions_Rows, AV36Step, AV13ProductServiceGroup, AV42noFilterAgb, AV40noFilterGen, AV47OrganisationId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridsdt_calltoactions_lastpage( )
      {
         GRIDSDT_CALLTOACTIONS_nRecordCount = subGridsdt_calltoactions_fnc_Recordcount( );
         if ( GRIDSDT_CALLTOACTIONS_nRecordCount > subGridsdt_calltoactions_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRIDSDT_CALLTOACTIONS_nRecordCount) % (subGridsdt_calltoactions_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = (long)(GRIDSDT_CALLTOACTIONS_nRecordCount-subGridsdt_calltoactions_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = (long)(GRIDSDT_CALLTOACTIONS_nRecordCount-((int)((GRIDSDT_CALLTOACTIONS_nRecordCount) % (subGridsdt_calltoactions_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_calltoactions_refresh( subGridsdt_calltoactions_Rows, AV36Step, AV13ProductServiceGroup, AV42noFilterAgb, AV40noFilterGen, AV47OrganisationId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridsdt_calltoactions_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = (long)(subGridsdt_calltoactions_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_calltoactions_refresh( subGridsdt_calltoactions_Rows, AV36Step, AV13ProductServiceGroup, AV42noFilterAgb, AV40noFilterGen, AV47OrganisationId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavFilename_Enabled = 0;
         AssignProp("", false, edtavFilename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFilename_Enabled), 5, 0), true);
         edtavSdt_calltoaction__calltoactionid_Enabled = 0;
         edtavSdt_calltoaction__organisationid_Enabled = 0;
         edtavSdt_calltoaction__locationid_Enabled = 0;
         edtavSdt_calltoaction__productserviceid_Enabled = 0;
         edtavSdt_calltoaction__calltoactionname_Enabled = 0;
         cmbavSdt_calltoaction__calltoactiontype.Enabled = 0;
         edtavSdt_calltoaction__calltoactionphone_Enabled = 0;
         edtavSdt_calltoaction__calltoactionurl_Enabled = 0;
         edtavSdt_calltoaction__calltoactionemail_Enabled = 0;
         edtavSdt_calltoaction__locationdynamicformid_Enabled = 0;
         edtavSdt_calltoaction__wwpformreferencename_Enabled = 0;
         edtavCalltoactionvariable_Enabled = 0;
         GXVvPRODUCTSERVICEGROUP_htmlA02( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPA00( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E17A02 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Sdt_calltoaction"), AV49SDT_CallToAction);
            ajax_req_read_hidden_sdt(cgiGet( "vUPLOADEDFILES"), AV17UploadedFiles);
            ajax_req_read_hidden_sdt(cgiGet( "vFAILEDFILES"), AV18FailedFiles);
            ajax_req_read_hidden_sdt(cgiGet( "vSUPPLIERAGBID_DATA"), AV46SupplierAgbId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vSUPPLIERGENID_DATA"), AV43SupplierGenId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV30DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vPHONECODE_DATA"), AV34PhoneCode_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vLOCATIONDYNAMICFORMID_DATA"), AV29LocationDynamicFormId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vSDT_CALLTOACTION"), AV49SDT_CallToAction);
            /* Read saved values. */
            nRC_GXsfl_180 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_180"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDSDT_CALLTOACTIONS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDSDT_CALLTOACTIONS_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGridsdt_calltoactions_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDSDT_CALLTOACTIONS_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRIDSDT_CALLTOACTIONS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Rows), 6, 0, ".", "")));
            Combo_locationdynamicformid_Selectedvalue_get = cgiGet( "COMBO_LOCATIONDYNAMICFORMID_Selectedvalue_get");
            Combo_suppliergenid_Selectedvalue_get = cgiGet( "COMBO_SUPPLIERGENID_Selectedvalue_get");
            Combo_supplieragbid_Selectedvalue_get = cgiGet( "COMBO_SUPPLIERAGBID_Selectedvalue_get");
            nRC_GXsfl_180 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_180"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_180_fel_idx = 0;
            while ( nGXsfl_180_fel_idx < nRC_GXsfl_180 )
            {
               nGXsfl_180_fel_idx = ((subGridsdt_calltoactions_Islastpage==1)&&(nGXsfl_180_fel_idx+1>subGridsdt_calltoactions_fnc_Recordsperpage( )) ? 1 : nGXsfl_180_fel_idx+1);
               sGXsfl_180_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_180_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_1802( ) ;
               AV54GXV1 = (int)(nGXsfl_180_fel_idx+GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage);
               if ( ( AV49SDT_CallToAction.Count >= AV54GXV1 ) && ( AV54GXV1 > 0 ) )
               {
                  AV49SDT_CallToAction.CurrentItem = ((SdtSDT_CallToAction_SDT_CallToActionItem)AV49SDT_CallToAction.Item(AV54GXV1));
                  AV50CallToActionVariable = cgiGet( edtavCalltoactionvariable_Internalname);
                  cmbavGridactiongroup1.Name = cmbavGridactiongroup1_Internalname;
                  cmbavGridactiongroup1.CurrentValue = cgiGet( cmbavGridactiongroup1_Internalname);
                  AV51GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactiongroup1_Internalname), "."), 18, MidpointRounding.ToEven));
               }
            }
            if ( nGXsfl_180_fel_idx == 0 )
            {
               nGXsfl_180_idx = 1;
               sGXsfl_180_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_180_idx), 4, 0), 4, "0");
               SubsflControlProps_1802( ) ;
            }
            nGXsfl_180_fel_idx = 1;
            /* Read variables values. */
            AV8ProductServiceName = cgiGet( edtavProductservicename_Internalname);
            AssignAttri("", false, "AV8ProductServiceName", AV8ProductServiceName);
            AV9ProductServiceTileName = cgiGet( edtavProductservicetilename_Internalname);
            AssignAttri("", false, "AV9ProductServiceTileName", AV9ProductServiceTileName);
            AV15FileName = cgiGet( edtavFilename_Internalname);
            AssignAttri("", false, "AV15FileName", AV15FileName);
            cmbavProductserviceclass.Name = cmbavProductserviceclass_Internalname;
            cmbavProductserviceclass.CurrentValue = cgiGet( cmbavProductserviceclass_Internalname);
            AV12ProductServiceClass = cgiGet( cmbavProductserviceclass_Internalname);
            AssignAttri("", false, "AV12ProductServiceClass", AV12ProductServiceClass);
            dynavProductservicegroup.Name = dynavProductservicegroup_Internalname;
            dynavProductservicegroup.CurrentValue = cgiGet( dynavProductservicegroup_Internalname);
            AV13ProductServiceGroup = cgiGet( dynavProductservicegroup_Internalname);
            AssignAttri("", false, "AV13ProductServiceGroup", AV13ProductServiceGroup);
            AV42noFilterAgb = StringUtil.StrToBool( cgiGet( chkavNofilteragb_Internalname));
            AssignAttri("", false, "AV42noFilterAgb", AV42noFilterAgb);
            AV40noFilterGen = StringUtil.StrToBool( cgiGet( chkavNofiltergen_Internalname));
            AssignAttri("", false, "AV40noFilterGen", AV40noFilterGen);
            AV20ProductServiceDescription = cgiGet( edtavProductservicedescription_Internalname);
            AssignAttri("", false, "AV20ProductServiceDescription", AV20ProductServiceDescription);
            cmbavCalltoactiontype.Name = cmbavCalltoactiontype_Internalname;
            cmbavCalltoactiontype.CurrentValue = cgiGet( cmbavCalltoactiontype_Internalname);
            AV22CallToActionType = cgiGet( cmbavCalltoactiontype_Internalname);
            AssignAttri("", false, "AV22CallToActionType", AV22CallToActionType);
            AV23CallToActionName = cgiGet( edtavCalltoactionname_Internalname);
            AssignAttri("", false, "AV23CallToActionName", AV23CallToActionName);
            AV28CallToActionUrl = cgiGet( edtavCalltoactionurl_Internalname);
            AssignAttri("", false, "AV28CallToActionUrl", AV28CallToActionUrl);
            AV26PhoneNumber = cgiGet( edtavPhonenumber_Internalname);
            AssignAttri("", false, "AV26PhoneNumber", AV26PhoneNumber);
            AV24CallToActionEmail = cgiGet( edtavCalltoactionemail_Internalname);
            AssignAttri("", false, "AV24CallToActionEmail", AV24CallToActionEmail);
            if ( StringUtil.StrCmp(cgiGet( edtavSupplieragbid_Internalname), "") == 0 )
            {
               AV41SupplierAgbId = Guid.Empty;
               AssignAttri("", false, "AV41SupplierAgbId", AV41SupplierAgbId.ToString());
            }
            else
            {
               try
               {
                  AV41SupplierAgbId = StringUtil.StrToGuid( cgiGet( edtavSupplieragbid_Internalname));
                  AssignAttri("", false, "AV41SupplierAgbId", AV41SupplierAgbId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vSUPPLIERAGBID");
                  GX_FocusControl = edtavSupplieragbid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            if ( StringUtil.StrCmp(cgiGet( edtavSuppliergenid_Internalname), "") == 0 )
            {
               AV39SupplierGenId = Guid.Empty;
               AssignAttri("", false, "AV39SupplierGenId", AV39SupplierGenId.ToString());
            }
            else
            {
               try
               {
                  AV39SupplierGenId = StringUtil.StrToGuid( cgiGet( edtavSuppliergenid_Internalname));
                  AssignAttri("", false, "AV39SupplierGenId", AV39SupplierGenId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vSUPPLIERGENID");
                  GX_FocusControl = edtavSuppliergenid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            AV27PhoneCode = cgiGet( edtavPhonecode_Internalname);
            AssignAttri("", false, "AV27PhoneCode", AV27PhoneCode);
            if ( StringUtil.StrCmp(cgiGet( edtavLocationdynamicformid_Internalname), "") == 0 )
            {
               AV25LocationDynamicFormId = Guid.Empty;
               AssignAttri("", false, "AV25LocationDynamicFormId", AV25LocationDynamicFormId.ToString());
            }
            else
            {
               try
               {
                  AV25LocationDynamicFormId = StringUtil.StrToGuid( cgiGet( edtavLocationdynamicformid_Internalname));
                  AssignAttri("", false, "AV25LocationDynamicFormId", AV25LocationDynamicFormId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vLOCATIONDYNAMICFORMID");
                  GX_FocusControl = edtavLocationdynamicformid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            if ( StringUtil.StrCmp(cgiGet( edtavCalltoactionid_Internalname), "") == 0 )
            {
               AV21CallToActionId = Guid.Empty;
               AssignAttri("", false, "AV21CallToActionId", AV21CallToActionId.ToString());
            }
            else
            {
               try
               {
                  AV21CallToActionId = StringUtil.StrToGuid( cgiGet( edtavCalltoactionid_Internalname));
                  AssignAttri("", false, "AV21CallToActionId", AV21CallToActionId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vCALLTOACTIONID");
                  GX_FocusControl = edtavCalltoactionid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            AV52WWPFormReferenceName = cgiGet( edtavWwpformreferencename_Internalname);
            AssignAttri("", false, "AV52WWPFormReferenceName", AV52WWPFormReferenceName);
            AV53CallToActionPhone = cgiGet( edtavCalltoactionphone_Internalname);
            AssignAttri("", false, "AV53CallToActionPhone", AV53CallToActionPhone);
            if ( StringUtil.StrCmp(cgiGet( edtavLocationid_Internalname), "") == 0 )
            {
               AV14LocationId = Guid.Empty;
               AssignAttri("", false, "AV14LocationId", AV14LocationId.ToString());
            }
            else
            {
               try
               {
                  AV14LocationId = StringUtil.StrToGuid( cgiGet( edtavLocationid_Internalname));
                  AssignAttri("", false, "AV14LocationId", AV14LocationId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vLOCATIONID");
                  GX_FocusControl = edtavLocationid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            if ( StringUtil.StrCmp(cgiGet( edtavProductserviceid_Internalname), "") == 0 )
            {
               AV7ProductServiceId = Guid.Empty;
               AssignAttri("", false, "AV7ProductServiceId", AV7ProductServiceId.ToString());
            }
            else
            {
               try
               {
                  AV7ProductServiceId = StringUtil.StrToGuid( cgiGet( edtavProductserviceid_Internalname));
                  AssignAttri("", false, "AV7ProductServiceId", AV7ProductServiceId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vPRODUCTSERVICEID");
                  GX_FocusControl = edtavProductserviceid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
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
         E17A02 ();
         if (returnInSub) return;
      }

      protected void E17A02( )
      {
         /* Start Routine */
         returnInSub = false;
         divServicetable_Visible = 1;
         AssignProp("", false, divServicetable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divServicetable_Visible), 5, 0), true);
         divCalltoactionstable_Visible = 0;
         AssignProp("", false, divCalltoactionstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCalltoactionstable_Visible), 5, 0), true);
         GXt_guid1 = AV47OrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
         AV47OrganisationId = GXt_guid1;
         AssignAttri("", false, "AV47OrganisationId", AV47OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV47OrganisationId, context));
         GXt_objcol_guid2 = AV37PreferredAgbSuppliers;
         new prc_getpreferredagbsuppliers(context ).execute( ref  GXt_objcol_guid2) ;
         AV37PreferredAgbSuppliers = GXt_objcol_guid2;
         GXt_objcol_guid2 = AV38PreferredGenSuppliers;
         new prc_getpreferredgensuppliers(context ).execute( ref  GXt_objcol_guid2) ;
         AV38PreferredGenSuppliers = GXt_objcol_guid2;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3 = AV30DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3) ;
         AV30DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3;
         edtavLocationdynamicformid_Visible = 0;
         AssignProp("", false, edtavLocationdynamicformid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLocationdynamicformid_Visible), 5, 0), true);
         edtavPhonecode_Visible = 0;
         AssignProp("", false, edtavPhonecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPhonecode_Visible), 5, 0), true);
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char4) ;
         Combo_phonecode_Htmltemplate = GXt_char4;
         ucCombo_phonecode.SendProperty(context, "", false, Combo_phonecode_Internalname, "HTMLTemplate", Combo_phonecode_Htmltemplate);
         edtavSuppliergenid_Visible = 0;
         AssignProp("", false, edtavSuppliergenid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSuppliergenid_Visible), 5, 0), true);
         edtavSupplieragbid_Visible = 0;
         AssignProp("", false, edtavSupplieragbid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSupplieragbid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERAGBID' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERGENID' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOPHONECODE' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOLOCATIONDYNAMICFORMID' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S152 ();
         if (returnInSub) return;
         edtavCalltoactionid_Visible = 0;
         AssignProp("", false, edtavCalltoactionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCalltoactionid_Visible), 5, 0), true);
         edtavWwpformreferencename_Visible = 0;
         AssignProp("", false, edtavWwpformreferencename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpformreferencename_Visible), 5, 0), true);
         edtavCalltoactionphone_Visible = 0;
         AssignProp("", false, edtavCalltoactionphone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCalltoactionphone_Visible), 5, 0), true);
         edtavLocationid_Visible = 0;
         AssignProp("", false, edtavLocationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLocationid_Visible), 5, 0), true);
         edtavProductserviceid_Visible = 0;
         AssignProp("", false, edtavProductserviceid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProductserviceid_Visible), 5, 0), true);
         Gridsdt_calltoactions_empowerer_Gridinternalname = subGridsdt_calltoactions_Internalname;
         ucGridsdt_calltoactions_empowerer.SendProperty(context, "", false, Gridsdt_calltoactions_empowerer_Internalname, "GridInternalName", Gridsdt_calltoactions_empowerer_Gridinternalname);
         subGridsdt_calltoactions_Rows = 0;
         GxWebStd.gx_hidden_field( context, "GRIDSDT_CALLTOACTIONS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Rows), 6, 0, ".", "")));
      }

      protected void E18A02( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      private void E19A02( )
      {
         /* Gridsdt_calltoactions_Load Routine */
         returnInSub = false;
         AV54GXV1 = 1;
         while ( AV54GXV1 <= AV49SDT_CallToAction.Count )
         {
            AV49SDT_CallToAction.CurrentItem = ((SdtSDT_CallToAction_SDT_CallToActionItem)AV49SDT_CallToAction.Item(AV54GXV1));
            cmbavGridactiongroup1.removeAllItems();
            cmbavGridactiongroup1.addItem("0", ";fas fa-bars", 0);
            cmbavGridactiongroup1.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "Update", ""), "fas fa-pen", "", "", "", "", "", "", ""), 0);
            cmbavGridactiongroup1.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "Delete", ""), "fas fa-xmark", "", "", "", "", "", "", ""), 0);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 180;
            }
            if ( ( subGridsdt_calltoactions_Islastpage == 1 ) || ( subGridsdt_calltoactions_Rows == 0 ) || ( ( GRIDSDT_CALLTOACTIONS_nCurrentRecord >= GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage ) && ( GRIDSDT_CALLTOACTIONS_nCurrentRecord < GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage + subGridsdt_calltoactions_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_1802( ) ;
            }
            GRIDSDT_CALLTOACTIONS_nEOF = (short)(((GRIDSDT_CALLTOACTIONS_nCurrentRecord<GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage+subGridsdt_calltoactions_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRIDSDT_CALLTOACTIONS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_CALLTOACTIONS_nEOF), 1, 0, ".", "")));
            GRIDSDT_CALLTOACTIONS_nCurrentRecord = (long)(GRIDSDT_CALLTOACTIONS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_180_Refreshing )
            {
               DoAjaxLoad(180, Gridsdt_calltoactionsRow);
            }
            AV54GXV1 = (int)(AV54GXV1+1);
         }
         /*  Sending Event outputs  */
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV51GridActionGroup1), 4, 0));
      }

      protected void E16A02( )
      {
         /* Combo_locationdynamicformid_Onoptionclicked Routine */
         returnInSub = false;
         AV25LocationDynamicFormId = StringUtil.StrToGuid( Combo_locationdynamicformid_Selectedvalue_get);
         AssignAttri("", false, "AV25LocationDynamicFormId", AV25LocationDynamicFormId.ToString());
         /*  Sending Event outputs  */
      }

      protected void E15A02( )
      {
         /* Combo_suppliergenid_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Combo_suppliergenid_Selectedvalue_get, "<#NEW#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wp_createnewgeneralsupplier.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(AV39SupplierGenId.ToString());
            context.PopUp(formatLink("wp_createnewgeneralsupplier.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         }
         else if ( StringUtil.StrCmp(Combo_suppliergenid_Selectedvalue_get, "<#POPUP_CLOSED#>") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOSUPPLIERGENID' */
            S122 ();
            if (returnInSub) return;
            AV44ComboSelectedValue = AV45Session.Get("SUPPLIERGENID");
            AV45Session.Remove("SUPPLIERGENID");
            Combo_suppliergenid_Selectedvalue_set = AV44ComboSelectedValue;
            ucCombo_suppliergenid.SendProperty(context, "", false, Combo_suppliergenid_Internalname, "SelectedValue_set", Combo_suppliergenid_Selectedvalue_set);
            AV39SupplierGenId = StringUtil.StrToGuid( AV44ComboSelectedValue);
            AssignAttri("", false, "AV39SupplierGenId", AV39SupplierGenId.ToString());
         }
         else
         {
            AV39SupplierGenId = StringUtil.StrToGuid( Combo_suppliergenid_Selectedvalue_get);
            AssignAttri("", false, "AV39SupplierGenId", AV39SupplierGenId.ToString());
            /* Execute user subroutine: 'LOADCOMBOSUPPLIERGENID' */
            S122 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43SupplierGenId_Data", AV43SupplierGenId_Data);
      }

      protected void E14A02( )
      {
         /* Combo_supplieragbid_Onoptionclicked Routine */
         returnInSub = false;
         AV41SupplierAgbId = StringUtil.StrToGuid( Combo_supplieragbid_Selectedvalue_get);
         AssignAttri("", false, "AV41SupplierAgbId", AV41SupplierAgbId.ToString());
         /*  Sending Event outputs  */
      }

      protected void S162( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( AV36Step == 2 ) ) )
         {
            bttBtnfinish_Visible = 0;
            AssignProp("", false, bttBtnfinish_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnfinish_Visible), 5, 0), true);
         }
         if ( ! ( false ) )
         {
            bttBtnuseractionclear_Visible = 0;
            AssignProp("", false, bttBtnuseractionclear_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnuseractionclear_Visible), 5, 0), true);
         }
      }

      protected void S172( )
      {
         /* 'DO USERACTIONEDIT' Routine */
         returnInSub = false;
      }

      protected void S182( )
      {
         /* 'DO USERACTIONDELETE' Routine */
         returnInSub = false;
      }

      protected void S192( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV16CheckRequiredFieldsResult = true;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12ProductServiceClass)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Category", ""), "", "", "", "", "", "", "", ""),  "error",  cmbavProductserviceclass_Internalname,  "true",  ""));
            AV16CheckRequiredFieldsResult = false;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV23CallToActionName)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Label", ""), "", "", "", "", "", "", "", ""),  "error",  edtavCalltoactionname_Internalname,  "true",  ""));
            AV16CheckRequiredFieldsResult = false;
         }
         if ( ( ( StringUtil.StrCmp(AV22CallToActionType, "SiteUrl") == 0 ) ) && String.IsNullOrEmpty(StringUtil.RTrim( AV28CallToActionUrl)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Url", ""), "", "", "", "", "", "", "", ""),  "error",  edtavCalltoactionurl_Internalname,  "true",  ""));
            AV16CheckRequiredFieldsResult = false;
         }
         if ( ( ( StringUtil.StrCmp(AV22CallToActionType, "Phone") == 0 ) ) && String.IsNullOrEmpty(StringUtil.RTrim( AV26PhoneNumber)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Phone Number", ""), "", "", "", "", "", "", "", ""),  "error",  edtavPhonenumber_Internalname,  "true",  ""));
            AV16CheckRequiredFieldsResult = false;
         }
         if ( ( ( StringUtil.StrCmp(AV22CallToActionType, "Form") == 0 ) ) && (Guid.Empty==AV25LocationDynamicFormId) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Form", ""), "", "", "", "", "", "", "", ""),  "error",  Combo_locationdynamicformid_Ddointernalname,  "true",  ""));
            AV16CheckRequiredFieldsResult = false;
         }
         if ( ( ( StringUtil.StrCmp(AV22CallToActionType, "Email") == 0 ) ) && String.IsNullOrEmpty(StringUtil.RTrim( AV24CallToActionEmail)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Email", ""), "", "", "", "", "", "", "", ""),  "error",  edtavCalltoactionemail_Internalname,  "true",  ""));
            AV16CheckRequiredFieldsResult = false;
         }
      }

      protected void S152( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV22CallToActionType, "Email") == 0 )
         {
            divCalltoactionemail_cell_Class = "col-xs-12 col-sm-6 RequiredDataContentCell";
            AssignProp("", false, divCalltoactionemail_cell_Internalname, "Class", divCalltoactionemail_cell_Class, true);
         }
         else
         {
            divCalltoactionemail_cell_Class = "col-xs-12 col-sm-6 DataContentCell";
            AssignProp("", false, divCalltoactionemail_cell_Internalname, "Class", divCalltoactionemail_cell_Class, true);
         }
         if ( StringUtil.StrCmp(AV22CallToActionType, "Form") == 0 )
         {
            divCombo_locationdynamicformid_cell_Class = "col-xs-12 col-sm-6 RequiredDataContentCell ExtendedComboCell";
            AssignProp("", false, divCombo_locationdynamicformid_cell_Internalname, "Class", divCombo_locationdynamicformid_cell_Class, true);
         }
         else
         {
            divCombo_locationdynamicformid_cell_Class = "col-xs-12 col-sm-6 DataContentCell ExtendedComboCell";
            AssignProp("", false, divCombo_locationdynamicformid_cell_Internalname, "Class", divCombo_locationdynamicformid_cell_Class, true);
         }
         if ( StringUtil.StrCmp(AV22CallToActionType, "Phone") == 0 )
         {
            divPhonenumber_cell_Class = "col-xs-12 RequiredDataContentCell";
            AssignProp("", false, divPhonenumber_cell_Internalname, "Class", divPhonenumber_cell_Class, true);
         }
         else
         {
            divPhonenumber_cell_Class = "col-xs-12 DataContentCell";
            AssignProp("", false, divPhonenumber_cell_Internalname, "Class", divPhonenumber_cell_Class, true);
         }
         if ( StringUtil.StrCmp(AV22CallToActionType, "SiteUrl") == 0 )
         {
            divCalltoactionurl_cell_Class = "col-xs-12 col-sm-6 RequiredDataContentCell";
            AssignProp("", false, divCalltoactionurl_cell_Internalname, "Class", divCalltoactionurl_cell_Class, true);
         }
         else
         {
            divCalltoactionurl_cell_Class = "col-xs-12 col-sm-6 DataContentCell";
            AssignProp("", false, divCalltoactionurl_cell_Internalname, "Class", divCalltoactionurl_cell_Class, true);
         }
      }

      protected void S142( )
      {
         /* 'LOADCOMBOLOCATIONDYNAMICFORMID' Routine */
         returnInSub = false;
         AV67GXV14 = 1;
         GXt_objcol_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem5 = AV66GXV13;
         new dp_locationdynamicform(context ).execute( out  GXt_objcol_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem5) ;
         AV66GXV13 = GXt_objcol_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem5;
         while ( AV67GXV14 <= AV66GXV13.Count )
         {
            AV32LocationDynamicFormId_DPItem = ((SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem)AV66GXV13.Item(AV67GXV14));
            AV31Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV31Combo_DataItem.gxTpr_Id = StringUtil.Trim( AV32LocationDynamicFormId_DPItem.gxTpr_Locationdynamicformid.ToString());
            AV31Combo_DataItem.gxTpr_Title = AV32LocationDynamicFormId_DPItem.gxTpr_Wwpformreferencename;
            AV29LocationDynamicFormId_Data.Add(AV31Combo_DataItem, 0);
            AV67GXV14 = (int)(AV67GXV14+1);
         }
         AV29LocationDynamicFormId_Data.Sort("Title");
         Combo_locationdynamicformid_Selectedvalue_set = ((Guid.Empty==AV25LocationDynamicFormId) ? "" : StringUtil.Trim( AV25LocationDynamicFormId.ToString()));
         ucCombo_locationdynamicformid.SendProperty(context, "", false, Combo_locationdynamicformid_Internalname, "SelectedValue_set", Combo_locationdynamicformid_Selectedvalue_set);
      }

      protected void S132( )
      {
         /* 'LOADCOMBOPHONECODE' Routine */
         returnInSub = false;
         AV69GXV16 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem6 = AV68GXV15;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem6) ;
         AV68GXV15 = GXt_objcol_SdtSDT_Country_SDT_CountryItem6;
         while ( AV69GXV16 <= AV68GXV15.Count )
         {
            AV35PhoneCode_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV68GXV15.Item(AV69GXV16));
            AV31Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV31Combo_DataItem.gxTpr_Id = AV35PhoneCode_DPItem.gxTpr_Countrydialcode;
            AV33ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV33ComboTitles.Add(AV35PhoneCode_DPItem.gxTpr_Countrydialcode, 0);
            AV33ComboTitles.Add(AV35PhoneCode_DPItem.gxTpr_Countryflag, 0);
            AV31Combo_DataItem.gxTpr_Title = AV33ComboTitles.ToJSonString(false);
            AV34PhoneCode_Data.Add(AV31Combo_DataItem, 0);
            AV69GXV16 = (int)(AV69GXV16+1);
         }
         AV34PhoneCode_Data.Sort("Title");
         Combo_phonecode_Selectedvalue_set = AV27PhoneCode;
         ucCombo_phonecode.SendProperty(context, "", false, Combo_phonecode_Internalname, "SelectedValue_set", Combo_phonecode_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOSUPPLIERGENID' Routine */
         returnInSub = false;
         AV43SupplierGenId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         GXt_boolean7 = false;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "<Check_Is_Authenticated>", out  GXt_boolean7) ;
         Combo_suppliergenid_Includeaddnewoption = GXt_boolean7;
         ucCombo_suppliergenid.SendProperty(context, "", false, Combo_suppliergenid_Internalname, "IncludeAddNewOption", StringUtil.BoolToStr( Combo_suppliergenid_Includeaddnewoption));
         /* Using cursor H00A02 */
         pr_default.execute(0, new Object[] {AV47OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A602SG_LocationSupplierOrganisatio = H00A02_A602SG_LocationSupplierOrganisatio[0];
            n602SG_LocationSupplierOrganisatio = H00A02_n602SG_LocationSupplierOrganisatio[0];
            A603SG_LocationSupplierLocationId = H00A02_A603SG_LocationSupplierLocationId[0];
            n603SG_LocationSupplierLocationId = H00A02_n603SG_LocationSupplierLocationId[0];
            A630ToolBoxLastUpdateReceptionistI = H00A02_A630ToolBoxLastUpdateReceptionistI[0];
            n630ToolBoxLastUpdateReceptionistI = H00A02_n630ToolBoxLastUpdateReceptionistI[0];
            A89ReceptionistId = H00A02_A89ReceptionistId[0];
            A29LocationId = H00A02_A29LocationId[0];
            A42SupplierGenId = H00A02_A42SupplierGenId[0];
            A44SupplierGenCompanyName = H00A02_A44SupplierGenCompanyName[0];
            A630ToolBoxLastUpdateReceptionistI = H00A02_A630ToolBoxLastUpdateReceptionistI[0];
            n630ToolBoxLastUpdateReceptionistI = H00A02_n630ToolBoxLastUpdateReceptionistI[0];
            /* Using cursor H00A03 */
            pr_default.execute(1, new Object[] {n602SG_LocationSupplierOrganisatio, A602SG_LocationSupplierOrganisatio});
            pr_default.close(1);
            AV31Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV31Combo_DataItem.gxTpr_Id = StringUtil.Trim( A42SupplierGenId.ToString());
            AV31Combo_DataItem.gxTpr_Title = A44SupplierGenCompanyName;
            AV43SupplierGenId_Data.Add(AV31Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         pr_default.close(1);
         Combo_suppliergenid_Selectedvalue_set = ((Guid.Empty==AV39SupplierGenId) ? "" : StringUtil.Trim( AV39SupplierGenId.ToString()));
         ucCombo_suppliergenid.SendProperty(context, "", false, Combo_suppliergenid_Internalname, "SelectedValue_set", Combo_suppliergenid_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'LOADCOMBOSUPPLIERAGBID' Routine */
         returnInSub = false;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A49SupplierAgbId ,
                                              AV37PreferredAgbSuppliers } ,
                                              new int[]{
                                              }
         });
         /* Using cursor H00A04 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A49SupplierAgbId = H00A04_A49SupplierAgbId[0];
            A51SupplierAgbName = H00A04_A51SupplierAgbName[0];
            AV31Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV31Combo_DataItem.gxTpr_Id = StringUtil.Trim( A49SupplierAgbId.ToString());
            AV31Combo_DataItem.gxTpr_Title = A51SupplierAgbName;
            AV46SupplierAgbId_Data.Add(AV31Combo_DataItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         Combo_supplieragbid_Selectedvalue_set = ((Guid.Empty==AV41SupplierAgbId) ? "" : StringUtil.Trim( AV41SupplierAgbId.ToString()));
         ucCombo_supplieragbid.SendProperty(context, "", false, Combo_supplieragbid_Internalname, "SelectedValue_set", Combo_supplieragbid_Selectedvalue_set);
      }

      protected void S202( )
      {
         /* 'LOADCOMBOSUPPLIERAGBID_GENID' Routine */
         returnInSub = false;
         AV46SupplierAgbId_Data.Clear();
         AV43SupplierGenId_Data.Clear();
         if ( ! AV42noFilterAgb && ( StringUtil.StrCmp(AV13ProductServiceGroup, " AGB Supplier") == 0 ) )
         {
            /* Using cursor H00A05 */
            pr_default.execute(3);
            while ( (pr_default.getStatus(3) != 101) )
            {
               A49SupplierAgbId = H00A05_A49SupplierAgbId[0];
               A51SupplierAgbName = H00A05_A51SupplierAgbName[0];
               AV31Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
               AV31Combo_DataItem.gxTpr_Id = StringUtil.Trim( A49SupplierAgbId.ToString());
               AV31Combo_DataItem.gxTpr_Title = A51SupplierAgbName;
               AV46SupplierAgbId_Data.Add(AV31Combo_DataItem, 0);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            Combo_supplieragbid_Selectedvalue_set = ((Guid.Empty==AV41SupplierAgbId) ? "" : StringUtil.Trim( AV41SupplierAgbId.ToString()));
            ucCombo_supplieragbid.SendProperty(context, "", false, Combo_supplieragbid_Internalname, "SelectedValue_set", Combo_supplieragbid_Selectedvalue_set);
         }
         else if ( ( AV42noFilterAgb ) && ( StringUtil.StrCmp(AV13ProductServiceGroup, " AGB Supplier") == 0 ) )
         {
            pr_default.dynParam(4, new Object[]{ new Object[]{
                                                 A49SupplierAgbId ,
                                                 AV37PreferredAgbSuppliers } ,
                                                 new int[]{
                                                 }
            });
            /* Using cursor H00A06 */
            pr_default.execute(4);
            while ( (pr_default.getStatus(4) != 101) )
            {
               A49SupplierAgbId = H00A06_A49SupplierAgbId[0];
               A51SupplierAgbName = H00A06_A51SupplierAgbName[0];
               AV31Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
               AV31Combo_DataItem.gxTpr_Id = StringUtil.Trim( A49SupplierAgbId.ToString());
               AV31Combo_DataItem.gxTpr_Title = A51SupplierAgbName;
               AV46SupplierAgbId_Data.Add(AV31Combo_DataItem, 0);
               pr_default.readNext(4);
            }
            pr_default.close(4);
            if ( ! AV48isStart )
            {
               AV41SupplierAgbId = Guid.Empty;
               AssignAttri("", false, "AV41SupplierAgbId", AV41SupplierAgbId.ToString());
            }
            Combo_supplieragbid_Selectedvalue_set = ((Guid.Empty==AV41SupplierAgbId) ? "" : StringUtil.Trim( AV41SupplierAgbId.ToString()));
            ucCombo_supplieragbid.SendProperty(context, "", false, Combo_supplieragbid_Internalname, "SelectedValue_set", Combo_supplieragbid_Selectedvalue_set);
         }
         else if ( ! AV40noFilterGen && ( StringUtil.StrCmp(AV13ProductServiceGroup, "Supplier") == 0 ) )
         {
            pr_default.dynParam(5, new Object[]{ new Object[]{
                                                 A42SupplierGenId ,
                                                 AV38PreferredGenSuppliers ,
                                                 A11OrganisationId ,
                                                 AV47OrganisationId } ,
                                                 new int[]{
                                                 }
            });
            /* Using cursor H00A07 */
            pr_default.execute(5, new Object[] {AV47OrganisationId});
            while ( (pr_default.getStatus(5) != 101) )
            {
               A602SG_LocationSupplierOrganisatio = H00A07_A602SG_LocationSupplierOrganisatio[0];
               n602SG_LocationSupplierOrganisatio = H00A07_n602SG_LocationSupplierOrganisatio[0];
               A603SG_LocationSupplierLocationId = H00A07_A603SG_LocationSupplierLocationId[0];
               n603SG_LocationSupplierLocationId = H00A07_n603SG_LocationSupplierLocationId[0];
               A630ToolBoxLastUpdateReceptionistI = H00A07_A630ToolBoxLastUpdateReceptionistI[0];
               n630ToolBoxLastUpdateReceptionistI = H00A07_n630ToolBoxLastUpdateReceptionistI[0];
               A89ReceptionistId = H00A07_A89ReceptionistId[0];
               A29LocationId = H00A07_A29LocationId[0];
               A42SupplierGenId = H00A07_A42SupplierGenId[0];
               A44SupplierGenCompanyName = H00A07_A44SupplierGenCompanyName[0];
               A630ToolBoxLastUpdateReceptionistI = H00A07_A630ToolBoxLastUpdateReceptionistI[0];
               n630ToolBoxLastUpdateReceptionistI = H00A07_n630ToolBoxLastUpdateReceptionistI[0];
               /* Using cursor H00A08 */
               pr_default.execute(6, new Object[] {n602SG_LocationSupplierOrganisatio, A602SG_LocationSupplierOrganisatio});
               pr_default.close(6);
               AV31Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
               AV31Combo_DataItem.gxTpr_Id = StringUtil.Trim( A42SupplierGenId.ToString());
               AV31Combo_DataItem.gxTpr_Title = A44SupplierGenCompanyName;
               AV43SupplierGenId_Data.Add(AV31Combo_DataItem, 0);
               pr_default.readNext(5);
            }
            pr_default.close(5);
            pr_default.close(6);
            Combo_suppliergenid_Selectedvalue_set = ((Guid.Empty==AV39SupplierGenId) ? "" : StringUtil.Trim( AV39SupplierGenId.ToString()));
            ucCombo_suppliergenid.SendProperty(context, "", false, Combo_suppliergenid_Internalname, "SelectedValue_set", Combo_suppliergenid_Selectedvalue_set);
         }
         else if ( ( AV40noFilterGen ) && ( StringUtil.StrCmp(AV13ProductServiceGroup, "Supplier") == 0 ) )
         {
            pr_default.dynParam(7, new Object[]{ new Object[]{
                                                 A42SupplierGenId ,
                                                 AV38PreferredGenSuppliers } ,
                                                 new int[]{
                                                 }
            });
            /* Using cursor H00A09 */
            pr_default.execute(7);
            while ( (pr_default.getStatus(7) != 101) )
            {
               A42SupplierGenId = H00A09_A42SupplierGenId[0];
               A44SupplierGenCompanyName = H00A09_A44SupplierGenCompanyName[0];
               AV31Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
               AV31Combo_DataItem.gxTpr_Id = StringUtil.Trim( A42SupplierGenId.ToString());
               AV31Combo_DataItem.gxTpr_Title = A44SupplierGenCompanyName;
               AV43SupplierGenId_Data.Add(AV31Combo_DataItem, 0);
               pr_default.readNext(7);
            }
            pr_default.close(7);
            if ( ! AV48isStart )
            {
               AV39SupplierGenId = Guid.Empty;
               AssignAttri("", false, "AV39SupplierGenId", AV39SupplierGenId.ToString());
            }
            Combo_suppliergenid_Selectedvalue_set = ((Guid.Empty==AV39SupplierGenId) ? "" : StringUtil.Trim( AV39SupplierGenId.ToString()));
            ucCombo_suppliergenid.SendProperty(context, "", false, Combo_suppliergenid_Internalname, "SelectedValue_set", Combo_suppliergenid_Selectedvalue_set);
         }
         AV48isStart = false;
      }

      protected void wb_table3_89_A02( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedsuppliergenid_Internalname, tblTablemergedsuppliergenid_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* User Defined Control */
            ucCombo_suppliergenid.SetProperty("Caption", Combo_suppliergenid_Caption);
            ucCombo_suppliergenid.SetProperty("Cls", Combo_suppliergenid_Cls);
            ucCombo_suppliergenid.SetProperty("EmptyItem", Combo_suppliergenid_Emptyitem);
            ucCombo_suppliergenid.SetProperty("IncludeAddNewOption", Combo_suppliergenid_Includeaddnewoption);
            ucCombo_suppliergenid.SetProperty("DropDownOptionsData", AV43SupplierGenId_Data);
            ucCombo_suppliergenid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_suppliergenid_Internalname, "COMBO_SUPPLIERGENIDContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavNofiltergen_Internalname, context.GetMessage( "no Filter Gen", ""), "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'" + sGXsfl_180_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavNofiltergen_Internalname, StringUtil.BoolToStr( AV40noFilterGen), "", context.GetMessage( "no Filter Gen", ""), 1, chkavNofiltergen.Enabled, "true", context.GetMessage( "Preferred", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(95, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,95);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_89_A02e( true) ;
         }
         else
         {
            wb_table3_89_A02e( false) ;
         }
      }

      protected void wb_table2_72_A02( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedsupplieragbid_Internalname, tblTablemergedsupplieragbid_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* User Defined Control */
            ucCombo_supplieragbid.SetProperty("Caption", Combo_supplieragbid_Caption);
            ucCombo_supplieragbid.SetProperty("Cls", Combo_supplieragbid_Cls);
            ucCombo_supplieragbid.SetProperty("EmptyItem", Combo_supplieragbid_Emptyitem);
            ucCombo_supplieragbid.SetProperty("DropDownOptionsData", AV46SupplierAgbId_Data);
            ucCombo_supplieragbid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_supplieragbid_Internalname, "COMBO_SUPPLIERAGBIDContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavNofilteragb_Internalname, context.GetMessage( "no Filter Agb", ""), "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'" + sGXsfl_180_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavNofilteragb_Internalname, StringUtil.BoolToStr( AV42noFilterAgb), "", context.GetMessage( "no Filter Agb", ""), 1, chkavNofilteragb.Enabled, "true", context.GetMessage( "Preferred", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(78, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,78);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_72_A02e( true) ;
         }
         else
         {
            wb_table2_72_A02e( false) ;
         }
      }

      protected void wb_table1_40_A02( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedusercontrol1_Internalname, tblTablemergedusercontrol1_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* User Defined Control */
            ucUsercontrol1.SetProperty("AutoUpload", Usercontrol1_Autoupload);
            ucUsercontrol1.SetProperty("HideAdditionalButtons", Usercontrol1_Hideadditionalbuttons);
            ucUsercontrol1.SetProperty("TooltipText", Usercontrol1_Tooltiptext);
            ucUsercontrol1.SetProperty("EnableUploadedFileCanceling", Usercontrol1_Enableuploadedfilecanceling);
            ucUsercontrol1.SetProperty("DisableImageResize", Usercontrol1_Disableimageresize);
            ucUsercontrol1.SetProperty("MaxFileSize", Usercontrol1_Maxfilesize);
            ucUsercontrol1.SetProperty("MaxNumberOfFiles", Usercontrol1_Maxnumberoffiles);
            ucUsercontrol1.SetProperty("AutoDisableAddingFiles", Usercontrol1_Autodisableaddingfiles);
            ucUsercontrol1.SetProperty("AcceptedFileTypes", Usercontrol1_Acceptedfiletypes);
            ucUsercontrol1.SetProperty("UploadedFiles", AV17UploadedFiles);
            ucUsercontrol1.SetProperty("FailedFiles", AV18FailedFiles);
            ucUsercontrol1.Render(context, "fileupload", Usercontrol1_Internalname, "USERCONTROL1Container");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilename_Internalname, context.GetMessage( "File Name", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_180_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilename_Internalname, AV15FileName, StringUtil.RTrim( context.localUtil.Format( AV15FileName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFilename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilename_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WC_ProductService.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_40_A02e( true) ;
         }
         else
         {
            wb_table1_40_A02e( false) ;
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
         PAA02( ) ;
         WSA02( ) ;
         WEA02( ) ;
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
         AddStyleSheetFile("FileUpload/fileupload.min.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202562017153687", true, true);
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
         context.AddJavascriptSource("wc_productservice.js", "?202562017153688", false, true);
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
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
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1802( )
      {
         edtavSdt_calltoaction__calltoactionid_Internalname = "SDT_CALLTOACTION__CALLTOACTIONID_"+sGXsfl_180_idx;
         edtavSdt_calltoaction__organisationid_Internalname = "SDT_CALLTOACTION__ORGANISATIONID_"+sGXsfl_180_idx;
         edtavSdt_calltoaction__locationid_Internalname = "SDT_CALLTOACTION__LOCATIONID_"+sGXsfl_180_idx;
         edtavSdt_calltoaction__productserviceid_Internalname = "SDT_CALLTOACTION__PRODUCTSERVICEID_"+sGXsfl_180_idx;
         edtavSdt_calltoaction__calltoactionname_Internalname = "SDT_CALLTOACTION__CALLTOACTIONNAME_"+sGXsfl_180_idx;
         cmbavSdt_calltoaction__calltoactiontype_Internalname = "SDT_CALLTOACTION__CALLTOACTIONTYPE_"+sGXsfl_180_idx;
         edtavSdt_calltoaction__calltoactionphone_Internalname = "SDT_CALLTOACTION__CALLTOACTIONPHONE_"+sGXsfl_180_idx;
         edtavSdt_calltoaction__calltoactionurl_Internalname = "SDT_CALLTOACTION__CALLTOACTIONURL_"+sGXsfl_180_idx;
         edtavSdt_calltoaction__calltoactionemail_Internalname = "SDT_CALLTOACTION__CALLTOACTIONEMAIL_"+sGXsfl_180_idx;
         edtavSdt_calltoaction__locationdynamicformid_Internalname = "SDT_CALLTOACTION__LOCATIONDYNAMICFORMID_"+sGXsfl_180_idx;
         edtavSdt_calltoaction__wwpformreferencename_Internalname = "SDT_CALLTOACTION__WWPFORMREFERENCENAME_"+sGXsfl_180_idx;
         edtavCalltoactionvariable_Internalname = "vCALLTOACTIONVARIABLE_"+sGXsfl_180_idx;
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1_"+sGXsfl_180_idx;
      }

      protected void SubsflControlProps_fel_1802( )
      {
         edtavSdt_calltoaction__calltoactionid_Internalname = "SDT_CALLTOACTION__CALLTOACTIONID_"+sGXsfl_180_fel_idx;
         edtavSdt_calltoaction__organisationid_Internalname = "SDT_CALLTOACTION__ORGANISATIONID_"+sGXsfl_180_fel_idx;
         edtavSdt_calltoaction__locationid_Internalname = "SDT_CALLTOACTION__LOCATIONID_"+sGXsfl_180_fel_idx;
         edtavSdt_calltoaction__productserviceid_Internalname = "SDT_CALLTOACTION__PRODUCTSERVICEID_"+sGXsfl_180_fel_idx;
         edtavSdt_calltoaction__calltoactionname_Internalname = "SDT_CALLTOACTION__CALLTOACTIONNAME_"+sGXsfl_180_fel_idx;
         cmbavSdt_calltoaction__calltoactiontype_Internalname = "SDT_CALLTOACTION__CALLTOACTIONTYPE_"+sGXsfl_180_fel_idx;
         edtavSdt_calltoaction__calltoactionphone_Internalname = "SDT_CALLTOACTION__CALLTOACTIONPHONE_"+sGXsfl_180_fel_idx;
         edtavSdt_calltoaction__calltoactionurl_Internalname = "SDT_CALLTOACTION__CALLTOACTIONURL_"+sGXsfl_180_fel_idx;
         edtavSdt_calltoaction__calltoactionemail_Internalname = "SDT_CALLTOACTION__CALLTOACTIONEMAIL_"+sGXsfl_180_fel_idx;
         edtavSdt_calltoaction__locationdynamicformid_Internalname = "SDT_CALLTOACTION__LOCATIONDYNAMICFORMID_"+sGXsfl_180_fel_idx;
         edtavSdt_calltoaction__wwpformreferencename_Internalname = "SDT_CALLTOACTION__WWPFORMREFERENCENAME_"+sGXsfl_180_fel_idx;
         edtavCalltoactionvariable_Internalname = "vCALLTOACTIONVARIABLE_"+sGXsfl_180_fel_idx;
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1_"+sGXsfl_180_fel_idx;
      }

      protected void sendrow_1802( )
      {
         sGXsfl_180_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_180_idx), 4, 0), 4, "0");
         SubsflControlProps_1802( ) ;
         WBA00( ) ;
         if ( ( subGridsdt_calltoactions_Rows * 1 == 0 ) || ( nGXsfl_180_idx <= subGridsdt_calltoactions_fnc_Recordsperpage( ) * 1 ) )
         {
            Gridsdt_calltoactionsRow = GXWebRow.GetNew(context,Gridsdt_calltoactionsContainer);
            if ( subGridsdt_calltoactions_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridsdt_calltoactions_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridsdt_calltoactions_Class, "") != 0 )
               {
                  subGridsdt_calltoactions_Linesclass = subGridsdt_calltoactions_Class+"Odd";
               }
            }
            else if ( subGridsdt_calltoactions_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridsdt_calltoactions_Backstyle = 0;
               subGridsdt_calltoactions_Backcolor = subGridsdt_calltoactions_Allbackcolor;
               if ( StringUtil.StrCmp(subGridsdt_calltoactions_Class, "") != 0 )
               {
                  subGridsdt_calltoactions_Linesclass = subGridsdt_calltoactions_Class+"Uniform";
               }
            }
            else if ( subGridsdt_calltoactions_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridsdt_calltoactions_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridsdt_calltoactions_Class, "") != 0 )
               {
                  subGridsdt_calltoactions_Linesclass = subGridsdt_calltoactions_Class+"Odd";
               }
               subGridsdt_calltoactions_Backcolor = (int)(0x0);
            }
            else if ( subGridsdt_calltoactions_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridsdt_calltoactions_Backstyle = 1;
               if ( ((int)((nGXsfl_180_idx) % (2))) == 0 )
               {
                  subGridsdt_calltoactions_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridsdt_calltoactions_Class, "") != 0 )
                  {
                     subGridsdt_calltoactions_Linesclass = subGridsdt_calltoactions_Class+"Even";
                  }
               }
               else
               {
                  subGridsdt_calltoactions_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridsdt_calltoactions_Class, "") != 0 )
                  {
                     subGridsdt_calltoactions_Linesclass = subGridsdt_calltoactions_Class+"Odd";
                  }
               }
            }
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_180_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__calltoactionid_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV49SDT_CallToAction.Item(AV54GXV1)).gxTpr_Calltoactionid.ToString(),((SdtSDT_CallToAction_SDT_CallToActionItem)AV49SDT_CallToAction.Item(AV54GXV1)).gxTpr_Calltoactionid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__calltoactionid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__calltoactionid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)180,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__organisationid_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV49SDT_CallToAction.Item(AV54GXV1)).gxTpr_Organisationid.ToString(),((SdtSDT_CallToAction_SDT_CallToActionItem)AV49SDT_CallToAction.Item(AV54GXV1)).gxTpr_Organisationid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__organisationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__organisationid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)180,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__locationid_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV49SDT_CallToAction.Item(AV54GXV1)).gxTpr_Locationid.ToString(),((SdtSDT_CallToAction_SDT_CallToActionItem)AV49SDT_CallToAction.Item(AV54GXV1)).gxTpr_Locationid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__locationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__locationid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)180,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__productserviceid_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV49SDT_CallToAction.Item(AV54GXV1)).gxTpr_Productserviceid.ToString(),((SdtSDT_CallToAction_SDT_CallToActionItem)AV49SDT_CallToAction.Item(AV54GXV1)).gxTpr_Productserviceid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__productserviceid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__productserviceid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)180,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 185,'',false,'" + sGXsfl_180_idx + "',180)\"";
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__calltoactionname_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV49SDT_CallToAction.Item(AV54GXV1)).gxTpr_Calltoactionname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,185);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__calltoactionname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_calltoaction__calltoactionname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)180,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 186,'',false,'" + sGXsfl_180_idx + "',180)\"";
            if ( ( cmbavSdt_calltoaction__calltoactiontype.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SDT_CALLTOACTION__CALLTOACTIONTYPE_" + sGXsfl_180_idx;
               cmbavSdt_calltoaction__calltoactiontype.Name = GXCCtl;
               cmbavSdt_calltoaction__calltoactiontype.WebTags = "";
               cmbavSdt_calltoaction__calltoactiontype.addItem("Phone", context.GetMessage( "Phone", ""), 0);
               cmbavSdt_calltoaction__calltoactiontype.addItem("Email", context.GetMessage( "Email", ""), 0);
               cmbavSdt_calltoaction__calltoactiontype.addItem("Form", context.GetMessage( "Form", ""), 0);
               cmbavSdt_calltoaction__calltoactiontype.addItem("SiteUrl", context.GetMessage( "Url", ""), 0);
               if ( cmbavSdt_calltoaction__calltoactiontype.ItemCount > 0 )
               {
                  if ( ( AV54GXV1 > 0 ) && ( AV49SDT_CallToAction.Count >= AV54GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_CallToAction_SDT_CallToActionItem)AV49SDT_CallToAction.Item(AV54GXV1)).gxTpr_Calltoactiontype)) )
                  {
                     ((SdtSDT_CallToAction_SDT_CallToActionItem)AV49SDT_CallToAction.Item(AV54GXV1)).gxTpr_Calltoactiontype = cmbavSdt_calltoaction__calltoactiontype.getValidValue(((SdtSDT_CallToAction_SDT_CallToActionItem)AV49SDT_CallToAction.Item(AV54GXV1)).gxTpr_Calltoactiontype);
                  }
               }
            }
            /* ComboBox */
            Gridsdt_calltoactionsRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavSdt_calltoaction__calltoactiontype,(string)cmbavSdt_calltoaction__calltoactiontype_Internalname,StringUtil.RTrim( ((SdtSDT_CallToAction_SDT_CallToActionItem)AV49SDT_CallToAction.Item(AV54GXV1)).gxTpr_Calltoactiontype),(short)1,(string)cmbavSdt_calltoaction__calltoactiontype_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,cmbavSdt_calltoaction__calltoactiontype.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,186);\"",(string)"",(bool)true,(short)0});
            cmbavSdt_calltoaction__calltoactiontype.CurrentValue = StringUtil.RTrim( ((SdtSDT_CallToAction_SDT_CallToActionItem)AV49SDT_CallToAction.Item(AV54GXV1)).gxTpr_Calltoactiontype);
            AssignProp("", false, cmbavSdt_calltoaction__calltoactiontype_Internalname, "Values", (string)(cmbavSdt_calltoaction__calltoactiontype.ToJavascriptSource()), !bGXsfl_180_Refreshing);
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__calltoactionphone_Internalname,StringUtil.RTrim( ((SdtSDT_CallToAction_SDT_CallToActionItem)AV49SDT_CallToAction.Item(AV54GXV1)).gxTpr_Calltoactionphone),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__calltoactionphone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__calltoactionphone_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)180,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__calltoactionurl_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV49SDT_CallToAction.Item(AV54GXV1)).gxTpr_Calltoactionurl,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__calltoactionurl_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__calltoactionurl_Enabled,(short)0,(string)"text",(string)"",(short)570,(string)"px",(short)17,(string)"px",(short)1000,(short)0,(short)0,(short)180,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__calltoactionemail_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV49SDT_CallToAction.Item(AV54GXV1)).gxTpr_Calltoactionemail,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__calltoactionemail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__calltoactionemail_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)180,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__locationdynamicformid_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV49SDT_CallToAction.Item(AV54GXV1)).gxTpr_Locationdynamicformid.ToString(),((SdtSDT_CallToAction_SDT_CallToActionItem)AV49SDT_CallToAction.Item(AV54GXV1)).gxTpr_Locationdynamicformid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__locationdynamicformid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__locationdynamicformid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)180,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__wwpformreferencename_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV49SDT_CallToAction.Item(AV54GXV1)).gxTpr_Wwpformreferencename,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__wwpformreferencename_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__wwpformreferencename_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)180,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 192,'',false,'" + sGXsfl_180_idx + "',180)\"";
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCalltoactionvariable_Internalname,(string)AV50CallToActionVariable,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,192);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCalltoactionvariable_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavCalltoactionvariable_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1000,(short)0,(short)0,(short)180,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 193,'',false,'" + sGXsfl_180_idx + "',180)\"";
            if ( ( cmbavGridactiongroup1.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONGROUP1_" + sGXsfl_180_idx;
               cmbavGridactiongroup1.Name = GXCCtl;
               cmbavGridactiongroup1.WebTags = "";
               if ( cmbavGridactiongroup1.ItemCount > 0 )
               {
                  if ( ( AV54GXV1 > 0 ) && ( AV49SDT_CallToAction.Count >= AV54GXV1 ) && (0==AV51GridActionGroup1) )
                  {
                     AV51GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cmbavGridactiongroup1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV51GridActionGroup1), 4, 0))), "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV51GridActionGroup1), 4, 0));
                  }
               }
            }
            /* ComboBox */
            Gridsdt_calltoactionsRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactiongroup1,(string)cmbavGridactiongroup1_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV51GridActionGroup1), 4, 0)),(short)1,(string)cmbavGridactiongroup1_Jsonclick,(short)7,(string)"'"+""+"'"+",false,"+"'"+"e20a02_client"+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,193);\"",(string)"",(bool)true,(short)0});
            cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV51GridActionGroup1), 4, 0));
            AssignProp("", false, cmbavGridactiongroup1_Internalname, "Values", (string)(cmbavGridactiongroup1.ToJavascriptSource()), !bGXsfl_180_Refreshing);
            send_integrity_lvl_hashesA02( ) ;
            Gridsdt_calltoactionsContainer.AddRow(Gridsdt_calltoactionsRow);
            nGXsfl_180_idx = ((subGridsdt_calltoactions_Islastpage==1)&&(nGXsfl_180_idx+1>subGridsdt_calltoactions_fnc_Recordsperpage( )) ? 1 : nGXsfl_180_idx+1);
            sGXsfl_180_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_180_idx), 4, 0), 4, "0");
            SubsflControlProps_1802( ) ;
         }
         /* End function sendrow_1802 */
      }

      protected void init_web_controls( )
      {
         cmbavProductserviceclass.Name = "vPRODUCTSERVICECLASS";
         cmbavProductserviceclass.WebTags = "";
         cmbavProductserviceclass.addItem("", context.GetMessage( "Select Category", ""), 0);
         cmbavProductserviceclass.addItem("My Living", context.GetMessage( "My Living", ""), 0);
         cmbavProductserviceclass.addItem("My Care", context.GetMessage( "My Care", ""), 0);
         cmbavProductserviceclass.addItem("My Services", context.GetMessage( "My Services", ""), 0);
         if ( cmbavProductserviceclass.ItemCount > 0 )
         {
            AV12ProductServiceClass = cmbavProductserviceclass.getValidValue(AV12ProductServiceClass);
            AssignAttri("", false, "AV12ProductServiceClass", AV12ProductServiceClass);
         }
         dynavProductservicegroup.Name = "vPRODUCTSERVICEGROUP";
         dynavProductservicegroup.WebTags = "";
         chkavNofilteragb.Name = "vNOFILTERAGB";
         chkavNofilteragb.WebTags = "";
         chkavNofilteragb.Caption = context.GetMessage( "no Filter Agb", "");
         AssignProp("", false, chkavNofilteragb_Internalname, "TitleCaption", chkavNofilteragb.Caption, true);
         chkavNofilteragb.CheckedValue = "false";
         AV42noFilterAgb = StringUtil.StrToBool( StringUtil.BoolToStr( AV42noFilterAgb));
         AssignAttri("", false, "AV42noFilterAgb", AV42noFilterAgb);
         chkavNofiltergen.Name = "vNOFILTERGEN";
         chkavNofiltergen.WebTags = "";
         chkavNofiltergen.Caption = context.GetMessage( "no Filter Gen", "");
         AssignProp("", false, chkavNofiltergen_Internalname, "TitleCaption", chkavNofiltergen.Caption, true);
         chkavNofiltergen.CheckedValue = "false";
         AV40noFilterGen = StringUtil.StrToBool( StringUtil.BoolToStr( AV40noFilterGen));
         AssignAttri("", false, "AV40noFilterGen", AV40noFilterGen);
         cmbavCalltoactiontype.Name = "vCALLTOACTIONTYPE";
         cmbavCalltoactiontype.WebTags = "";
         cmbavCalltoactiontype.addItem("Phone", context.GetMessage( "Phone", ""), 0);
         cmbavCalltoactiontype.addItem("Email", context.GetMessage( "Email", ""), 0);
         cmbavCalltoactiontype.addItem("Form", context.GetMessage( "Form", ""), 0);
         cmbavCalltoactiontype.addItem("SiteUrl", context.GetMessage( "Url", ""), 0);
         if ( cmbavCalltoactiontype.ItemCount > 0 )
         {
            AV22CallToActionType = cmbavCalltoactiontype.getValidValue(AV22CallToActionType);
            AssignAttri("", false, "AV22CallToActionType", AV22CallToActionType);
         }
         GXCCtl = "SDT_CALLTOACTION__CALLTOACTIONTYPE_" + sGXsfl_180_idx;
         cmbavSdt_calltoaction__calltoactiontype.Name = GXCCtl;
         cmbavSdt_calltoaction__calltoactiontype.WebTags = "";
         cmbavSdt_calltoaction__calltoactiontype.addItem("Phone", context.GetMessage( "Phone", ""), 0);
         cmbavSdt_calltoaction__calltoactiontype.addItem("Email", context.GetMessage( "Email", ""), 0);
         cmbavSdt_calltoaction__calltoactiontype.addItem("Form", context.GetMessage( "Form", ""), 0);
         cmbavSdt_calltoaction__calltoactiontype.addItem("SiteUrl", context.GetMessage( "Url", ""), 0);
         if ( cmbavSdt_calltoaction__calltoactiontype.ItemCount > 0 )
         {
            if ( ( AV54GXV1 > 0 ) && ( AV49SDT_CallToAction.Count >= AV54GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_CallToAction_SDT_CallToActionItem)AV49SDT_CallToAction.Item(AV54GXV1)).gxTpr_Calltoactiontype)) )
            {
               ((SdtSDT_CallToAction_SDT_CallToActionItem)AV49SDT_CallToAction.Item(AV54GXV1)).gxTpr_Calltoactiontype = cmbavSdt_calltoaction__calltoactiontype.getValidValue(((SdtSDT_CallToAction_SDT_CallToActionItem)AV49SDT_CallToAction.Item(AV54GXV1)).gxTpr_Calltoactiontype);
            }
         }
         GXCCtl = "vGRIDACTIONGROUP1_" + sGXsfl_180_idx;
         cmbavGridactiongroup1.Name = GXCCtl;
         cmbavGridactiongroup1.WebTags = "";
         if ( cmbavGridactiongroup1.ItemCount > 0 )
         {
            if ( ( AV54GXV1 > 0 ) && ( AV49SDT_CallToAction.Count >= AV54GXV1 ) && (0==AV51GridActionGroup1) )
            {
               AV51GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cmbavGridactiongroup1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV51GridActionGroup1), 4, 0))), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV51GridActionGroup1), 4, 0));
            }
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl180( )
      {
         if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Gridsdt_calltoactionsContainer"+"DivS\" data-gxgridid=\"180\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridsdt_calltoactions_Internalname, subGridsdt_calltoactions_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridsdt_calltoactions_Backcolorstyle == 0 )
            {
               subGridsdt_calltoactions_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridsdt_calltoactions_Class) > 0 )
               {
                  subGridsdt_calltoactions_Linesclass = subGridsdt_calltoactions_Class+"Title";
               }
            }
            else
            {
               subGridsdt_calltoactions_Titlebackstyle = 1;
               if ( subGridsdt_calltoactions_Backcolorstyle == 1 )
               {
                  subGridsdt_calltoactions_Titlebackcolor = subGridsdt_calltoactions_Allbackcolor;
                  if ( StringUtil.Len( subGridsdt_calltoactions_Class) > 0 )
                  {
                     subGridsdt_calltoactions_Linesclass = subGridsdt_calltoactions_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridsdt_calltoactions_Class) > 0 )
                  {
                     subGridsdt_calltoactions_Linesclass = subGridsdt_calltoactions_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Call To Action Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Organisation Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Location Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Product Service Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Label", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Type", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Phone", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(570), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Url", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Email", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Form", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Reference Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Call To Action", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Gridsdt_calltoactionsContainer.AddObjectProperty("GridName", "Gridsdt_calltoactions");
         }
         else
         {
            Gridsdt_calltoactionsContainer.AddObjectProperty("GridName", "Gridsdt_calltoactions");
            Gridsdt_calltoactionsContainer.AddObjectProperty("Header", subGridsdt_calltoactions_Header);
            Gridsdt_calltoactionsContainer.AddObjectProperty("Class", "WorkWith");
            Gridsdt_calltoactionsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Backcolorstyle), 1, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("CmpContext", "");
            Gridsdt_calltoactionsContainer.AddObjectProperty("InMasterPage", "false");
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__calltoactionid_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__organisationid_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__locationid_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__productserviceid_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__calltoactionname_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavSdt_calltoaction__calltoactiontype.Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__calltoactionphone_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__calltoactionurl_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__calltoactionemail_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__locationdynamicformid_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__wwpformreferencename_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV50CallToActionVariable));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCalltoactionvariable_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV51GridActionGroup1), 4, 0, ".", ""))));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Selectedindex), 4, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Allowselection), 1, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Selectioncolor), 9, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Allowhovering), 1, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Hoveringcolor), 9, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Allowcollapsing), 1, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         edtavProductservicename_Internalname = "vPRODUCTSERVICENAME";
         edtavProductservicetilename_Internalname = "vPRODUCTSERVICETILENAME";
         lblProductserviceimagetext_Internalname = "PRODUCTSERVICEIMAGETEXT";
         Usercontrol1_Internalname = "USERCONTROL1";
         edtavFilename_Internalname = "vFILENAME";
         tblTablemergedusercontrol1_Internalname = "TABLEMERGEDUSERCONTROL1";
         divUcfilecell_Internalname = "UCFILECELL";
         divUnnamedtable12_Internalname = "UNNAMEDTABLE12";
         divUnnamedtable9_Internalname = "UNNAMEDTABLE9";
         cmbavProductserviceclass_Internalname = "vPRODUCTSERVICECLASS";
         dynavProductservicegroup_Internalname = "vPRODUCTSERVICEGROUP";
         lblTextblockcombo_supplieragbid_Internalname = "TEXTBLOCKCOMBO_SUPPLIERAGBID";
         Combo_supplieragbid_Internalname = "COMBO_SUPPLIERAGBID";
         chkavNofilteragb_Internalname = "vNOFILTERAGB";
         tblTablemergedsupplieragbid_Internalname = "TABLEMERGEDSUPPLIERAGBID";
         divTablesplittedsupplieragbid_Internalname = "TABLESPLITTEDSUPPLIERAGBID";
         divTablesupplieragb_Internalname = "TABLESUPPLIERAGB";
         lblTextblockcombo_suppliergenid_Internalname = "TEXTBLOCKCOMBO_SUPPLIERGENID";
         Combo_suppliergenid_Internalname = "COMBO_SUPPLIERGENID";
         chkavNofiltergen_Internalname = "vNOFILTERGEN";
         tblTablemergedsuppliergenid_Internalname = "TABLEMERGEDSUPPLIERGENID";
         divTablesplittedsuppliergenid_Internalname = "TABLESPLITTEDSUPPLIERGENID";
         divTablesuppliergen_Internalname = "TABLESUPPLIERGEN";
         divUnnamedtable11_Internalname = "UNNAMEDTABLE11";
         edtavProductservicedescription_Internalname = "vPRODUCTSERVICEDESCRIPTION";
         divUnnamedtable10_Internalname = "UNNAMEDTABLE10";
         divServicegroup_Internalname = "SERVICEGROUP";
         grpUnnamedgroup8_Internalname = "UNNAMEDGROUP8";
         divServicetable_Internalname = "SERVICETABLE";
         cmbavCalltoactiontype_Internalname = "vCALLTOACTIONTYPE";
         edtavCalltoactionname_Internalname = "vCALLTOACTIONNAME";
         edtavCalltoactionurl_Internalname = "vCALLTOACTIONURL";
         divCalltoactionurl_cell_Internalname = "CALLTOACTIONURL_CELL";
         divTableurl_Internalname = "TABLEURL";
         lblPhonelabel_Internalname = "PHONELABEL";
         Combo_phonecode_Internalname = "COMBO_PHONECODE";
         divUnnamedtable6_Internalname = "UNNAMEDTABLE6";
         edtavPhonenumber_Internalname = "vPHONENUMBER";
         divPhonenumber_cell_Internalname = "PHONENUMBER_CELL";
         divUnnamedtable7_Internalname = "UNNAMEDTABLE7";
         divUnnamedtable5_Internalname = "UNNAMEDTABLE5";
         divTablephone_Internalname = "TABLEPHONE";
         lblTextblockcombo_locationdynamicformid_Internalname = "TEXTBLOCKCOMBO_LOCATIONDYNAMICFORMID";
         Combo_locationdynamicformid_Internalname = "COMBO_LOCATIONDYNAMICFORMID";
         divTablesplittedlocationdynamicformid_Internalname = "TABLESPLITTEDLOCATIONDYNAMICFORMID";
         divCombo_locationdynamicformid_cell_Internalname = "COMBO_LOCATIONDYNAMICFORMID_CELL";
         divTableform_Internalname = "TABLEFORM";
         edtavCalltoactionemail_Internalname = "vCALLTOACTIONEMAIL";
         divCalltoactionemail_cell_Internalname = "CALLTOACTIONEMAIL_CELL";
         divTableemail_Internalname = "TABLEEMAIL";
         divUnnamedtable4_Internalname = "UNNAMEDTABLE4";
         divCalltoactionsgroup_Internalname = "CALLTOACTIONSGROUP";
         grpUnnamedgroup2_Internalname = "UNNAMEDGROUP2";
         bttBtnuseractionadd_Internalname = "BTNUSERACTIONADD";
         bttBtnuseractionclear_Internalname = "BTNUSERACTIONCLEAR";
         edtavSdt_calltoaction__calltoactionid_Internalname = "SDT_CALLTOACTION__CALLTOACTIONID";
         edtavSdt_calltoaction__organisationid_Internalname = "SDT_CALLTOACTION__ORGANISATIONID";
         edtavSdt_calltoaction__locationid_Internalname = "SDT_CALLTOACTION__LOCATIONID";
         edtavSdt_calltoaction__productserviceid_Internalname = "SDT_CALLTOACTION__PRODUCTSERVICEID";
         edtavSdt_calltoaction__calltoactionname_Internalname = "SDT_CALLTOACTION__CALLTOACTIONNAME";
         cmbavSdt_calltoaction__calltoactiontype_Internalname = "SDT_CALLTOACTION__CALLTOACTIONTYPE";
         edtavSdt_calltoaction__calltoactionphone_Internalname = "SDT_CALLTOACTION__CALLTOACTIONPHONE";
         edtavSdt_calltoaction__calltoactionurl_Internalname = "SDT_CALLTOACTION__CALLTOACTIONURL";
         edtavSdt_calltoaction__calltoactionemail_Internalname = "SDT_CALLTOACTION__CALLTOACTIONEMAIL";
         edtavSdt_calltoaction__locationdynamicformid_Internalname = "SDT_CALLTOACTION__LOCATIONDYNAMICFORMID";
         edtavSdt_calltoaction__wwpformreferencename_Internalname = "SDT_CALLTOACTION__WWPFORMREFERENCENAME";
         edtavCalltoactionvariable_Internalname = "vCALLTOACTIONVARIABLE";
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         divCalltoactionstable_Internalname = "CALLTOACTIONSTABLE";
         Btnprevious_Internalname = "BTNPREVIOUS";
         Btnnext_Internalname = "BTNNEXT";
         bttBtnfinish_Internalname = "BTNFINISH";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         edtavSupplieragbid_Internalname = "vSUPPLIERAGBID";
         edtavSuppliergenid_Internalname = "vSUPPLIERGENID";
         edtavPhonecode_Internalname = "vPHONECODE";
         edtavLocationdynamicformid_Internalname = "vLOCATIONDYNAMICFORMID";
         edtavCalltoactionid_Internalname = "vCALLTOACTIONID";
         edtavWwpformreferencename_Internalname = "vWWPFORMREFERENCENAME";
         edtavCalltoactionphone_Internalname = "vCALLTOACTIONPHONE";
         edtavLocationid_Internalname = "vLOCATIONID";
         edtavProductserviceid_Internalname = "vPRODUCTSERVICEID";
         Gridsdt_calltoactions_empowerer_Internalname = "GRIDSDT_CALLTOACTIONS_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridsdt_calltoactions_Internalname = "GRIDSDT_CALLTOACTIONS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridsdt_calltoactions_Allowcollapsing = 0;
         subGridsdt_calltoactions_Allowselection = 0;
         subGridsdt_calltoactions_Header = "";
         chkavNofiltergen.Caption = context.GetMessage( "no Filter Gen", "");
         chkavNofilteragb.Caption = context.GetMessage( "no Filter Agb", "");
         cmbavGridactiongroup1_Jsonclick = "";
         edtavCalltoactionvariable_Jsonclick = "";
         edtavCalltoactionvariable_Enabled = 1;
         edtavSdt_calltoaction__wwpformreferencename_Jsonclick = "";
         edtavSdt_calltoaction__wwpformreferencename_Enabled = 0;
         edtavSdt_calltoaction__locationdynamicformid_Jsonclick = "";
         edtavSdt_calltoaction__locationdynamicformid_Enabled = 0;
         edtavSdt_calltoaction__calltoactionemail_Jsonclick = "";
         edtavSdt_calltoaction__calltoactionemail_Enabled = 0;
         edtavSdt_calltoaction__calltoactionurl_Jsonclick = "";
         edtavSdt_calltoaction__calltoactionurl_Enabled = 0;
         edtavSdt_calltoaction__calltoactionphone_Jsonclick = "";
         edtavSdt_calltoaction__calltoactionphone_Enabled = 0;
         cmbavSdt_calltoaction__calltoactiontype_Jsonclick = "";
         cmbavSdt_calltoaction__calltoactiontype.Enabled = 0;
         edtavSdt_calltoaction__calltoactionname_Jsonclick = "";
         edtavSdt_calltoaction__calltoactionname_Enabled = 0;
         edtavSdt_calltoaction__productserviceid_Jsonclick = "";
         edtavSdt_calltoaction__productserviceid_Enabled = 0;
         edtavSdt_calltoaction__locationid_Jsonclick = "";
         edtavSdt_calltoaction__locationid_Enabled = 0;
         edtavSdt_calltoaction__organisationid_Jsonclick = "";
         edtavSdt_calltoaction__organisationid_Enabled = 0;
         edtavSdt_calltoaction__calltoactionid_Jsonclick = "";
         edtavSdt_calltoaction__calltoactionid_Enabled = 0;
         subGridsdt_calltoactions_Class = "WorkWith";
         subGridsdt_calltoactions_Backcolorstyle = 0;
         edtavFilename_Jsonclick = "";
         edtavFilename_Enabled = 1;
         Usercontrol1_Acceptedfiletypes = "image";
         Usercontrol1_Autodisableaddingfiles = Convert.ToBoolean( -1);
         Usercontrol1_Maxnumberoffiles = 1;
         Usercontrol1_Maxfilesize = 2000000;
         Usercontrol1_Disableimageresize = Convert.ToBoolean( 0);
         Usercontrol1_Enableuploadedfilecanceling = Convert.ToBoolean( -1);
         Usercontrol1_Tooltiptext = "";
         Usercontrol1_Hideadditionalbuttons = Convert.ToBoolean( -1);
         Usercontrol1_Autoupload = Convert.ToBoolean( -1);
         chkavNofilteragb.Enabled = 1;
         Combo_supplieragbid_Emptyitem = Convert.ToBoolean( 0);
         Combo_supplieragbid_Cls = "ExtendedCombo ExtendedCombo";
         chkavNofiltergen.Enabled = 1;
         Combo_suppliergenid_Emptyitem = Convert.ToBoolean( 0);
         Combo_suppliergenid_Cls = "ExtendedCombo ExtendedCombo";
         Combo_suppliergenid_Includeaddnewoption = Convert.ToBoolean( -1);
         Combo_phonecode_Htmltemplate = "";
         edtavSdt_calltoaction__wwpformreferencename_Enabled = -1;
         edtavSdt_calltoaction__locationdynamicformid_Enabled = -1;
         edtavSdt_calltoaction__calltoactionemail_Enabled = -1;
         edtavSdt_calltoaction__calltoactionurl_Enabled = -1;
         edtavSdt_calltoaction__calltoactionphone_Enabled = -1;
         cmbavSdt_calltoaction__calltoactiontype.Enabled = -1;
         edtavSdt_calltoaction__calltoactionname_Enabled = -1;
         edtavSdt_calltoaction__productserviceid_Enabled = -1;
         edtavSdt_calltoaction__locationid_Enabled = -1;
         edtavSdt_calltoaction__organisationid_Enabled = -1;
         edtavSdt_calltoaction__calltoactionid_Enabled = -1;
         edtavProductserviceid_Jsonclick = "";
         edtavProductserviceid_Visible = 1;
         edtavLocationid_Jsonclick = "";
         edtavLocationid_Visible = 1;
         edtavCalltoactionphone_Jsonclick = "";
         edtavCalltoactionphone_Visible = 1;
         edtavWwpformreferencename_Jsonclick = "";
         edtavWwpformreferencename_Visible = 1;
         edtavCalltoactionid_Jsonclick = "";
         edtavCalltoactionid_Visible = 1;
         edtavLocationdynamicformid_Jsonclick = "";
         edtavLocationdynamicformid_Visible = 1;
         edtavPhonecode_Jsonclick = "";
         edtavPhonecode_Visible = 1;
         edtavSuppliergenid_Jsonclick = "";
         edtavSuppliergenid_Visible = 1;
         edtavSupplieragbid_Jsonclick = "";
         edtavSupplieragbid_Visible = 1;
         bttBtnfinish_Visible = 1;
         Btnnext_Class = "ButtonMaterial";
         Btnnext_Caption = context.GetMessage( "Next", "");
         Btnnext_Aftericonclass = "fa fa-arrow-right";
         Btnnext_Tooltiptext = "";
         Btnprevious_Class = "ButtonMaterial";
         Btnprevious_Caption = context.GetMessage( "Previous", "");
         Btnprevious_Beforeiconclass = "fas fa-arrow-left";
         Btnprevious_Tooltiptext = "";
         bttBtnuseractionclear_Visible = 1;
         edtavCalltoactionemail_Jsonclick = "";
         edtavCalltoactionemail_Enabled = 1;
         divCalltoactionemail_cell_Class = "col-xs-12 col-sm-6";
         Combo_locationdynamicformid_Emptyitem = Convert.ToBoolean( 0);
         Combo_locationdynamicformid_Cls = "ExtendedCombo Attribute";
         Combo_locationdynamicformid_Caption = "";
         divCombo_locationdynamicformid_cell_Class = "col-xs-12 col-sm-6";
         edtavPhonenumber_Jsonclick = "";
         edtavPhonenumber_Enabled = 1;
         divPhonenumber_cell_Class = "col-xs-12";
         Combo_phonecode_Emptyitem = Convert.ToBoolean( 0);
         Combo_phonecode_Cls = "ExtendedCombo DropDownComponent ExtendedComboWithImage";
         Combo_phonecode_Caption = "";
         edtavCalltoactionurl_Jsonclick = "";
         edtavCalltoactionurl_Enabled = 1;
         divCalltoactionurl_cell_Class = "col-xs-12 col-sm-6";
         edtavCalltoactionname_Jsonclick = "";
         edtavCalltoactionname_Enabled = 1;
         cmbavCalltoactiontype_Jsonclick = "";
         cmbavCalltoactiontype.Enabled = 1;
         divCalltoactionstable_Visible = 1;
         edtavProductservicedescription_Enabled = 1;
         dynavProductservicegroup_Jsonclick = "";
         dynavProductservicegroup.Enabled = 1;
         cmbavProductserviceclass_Jsonclick = "";
         cmbavProductserviceclass.Enabled = 1;
         edtavProductservicetilename_Jsonclick = "";
         edtavProductservicetilename_Enabled = 1;
         edtavProductservicename_Jsonclick = "";
         edtavProductservicename_Enabled = 1;
         divServicetable_Visible = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Product/Service", "");
         subGridsdt_calltoactions_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"GRIDSDT_CALLTOACTIONS_nEOF"},{"av":"AV49SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":180},{"av":"nGXsfl_180_idx","ctrl":"GRID","prop":"GridCurrRow","grid":180},{"av":"nRC_GXsfl_180","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":180},{"av":"subGridsdt_calltoactions_Rows","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"Rows"},{"av":"dynavProductservicegroup"},{"av":"AV13ProductServiceGroup","fld":"vPRODUCTSERVICEGROUP"},{"av":"AV42noFilterAgb","fld":"vNOFILTERAGB"},{"av":"AV40noFilterGen","fld":"vNOFILTERGEN"},{"av":"AV36Step","fld":"vSTEP","pic":"ZZZ9","hsh":true},{"av":"AV47OrganisationId","fld":"vORGANISATIONID","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"ctrl":"BTNFINISH","prop":"Visible"},{"ctrl":"BTNUSERACTIONCLEAR","prop":"Visible"}]}""");
         setEventMetadata("GRIDSDT_CALLTOACTIONS.LOAD","""{"handler":"E19A02","iparms":[]""");
         setEventMetadata("GRIDSDT_CALLTOACTIONS.LOAD",""","oparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV51GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9"}]}""");
         setEventMetadata("'DOFINISH'","""{"handler":"E13A01","iparms":[]}""");
         setEventMetadata("'DOUSERACTIONADD'","""{"handler":"E11A01","iparms":[]}""");
         setEventMetadata("'DOUSERACTIONCLEAR'","""{"handler":"E12A01","iparms":[]}""");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK","""{"handler":"E20A02","iparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV51GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9"}]""");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK",""","oparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV51GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9"}]}""");
         setEventMetadata("COMBO_LOCATIONDYNAMICFORMID.ONOPTIONCLICKED","""{"handler":"E16A02","iparms":[{"av":"Combo_locationdynamicformid_Selectedvalue_get","ctrl":"COMBO_LOCATIONDYNAMICFORMID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_LOCATIONDYNAMICFORMID.ONOPTIONCLICKED",""","oparms":[{"av":"AV25LocationDynamicFormId","fld":"vLOCATIONDYNAMICFORMID"}]}""");
         setEventMetadata("COMBO_SUPPLIERGENID.ONOPTIONCLICKED","""{"handler":"E15A02","iparms":[{"av":"Combo_suppliergenid_Selectedvalue_get","ctrl":"COMBO_SUPPLIERGENID","prop":"SelectedValue_get"},{"av":"AV39SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"A44SupplierGenCompanyName","fld":"SUPPLIERGENCOMPANYNAME"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV47OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"A42SupplierGenId","fld":"SUPPLIERGENID"}]""");
         setEventMetadata("COMBO_SUPPLIERGENID.ONOPTIONCLICKED",""","oparms":[{"av":"Combo_suppliergenid_Selectedvalue_set","ctrl":"COMBO_SUPPLIERGENID","prop":"SelectedValue_set"},{"av":"AV39SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV43SupplierGenId_Data","fld":"vSUPPLIERGENID_DATA"},{"av":"Combo_suppliergenid_Includeaddnewoption","ctrl":"COMBO_SUPPLIERGENID","prop":"IncludeAddNewOption"}]}""");
         setEventMetadata("COMBO_SUPPLIERAGBID.ONOPTIONCLICKED","""{"handler":"E14A02","iparms":[{"av":"Combo_supplieragbid_Selectedvalue_get","ctrl":"COMBO_SUPPLIERAGBID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_SUPPLIERAGBID.ONOPTIONCLICKED",""","oparms":[{"av":"AV41SupplierAgbId","fld":"vSUPPLIERAGBID"}]}""");
         setEventMetadata("GRIDSDT_CALLTOACTIONS_FIRSTPAGE","""{"handler":"subgridsdt_calltoactions_firstpage","iparms":[{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"GRIDSDT_CALLTOACTIONS_nEOF"},{"av":"AV49SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":180},{"av":"nGXsfl_180_idx","ctrl":"GRID","prop":"GridCurrRow","grid":180},{"av":"nRC_GXsfl_180","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":180},{"av":"subGridsdt_calltoactions_Rows","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"Rows"},{"av":"AV47OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV36Step","fld":"vSTEP","pic":"ZZZ9","hsh":true},{"av":"dynavProductservicegroup"},{"av":"AV13ProductServiceGroup","fld":"vPRODUCTSERVICEGROUP"},{"av":"AV42noFilterAgb","fld":"vNOFILTERAGB"},{"av":"AV40noFilterGen","fld":"vNOFILTERGEN"}]""");
         setEventMetadata("GRIDSDT_CALLTOACTIONS_FIRSTPAGE",""","oparms":[{"ctrl":"BTNFINISH","prop":"Visible"},{"ctrl":"BTNUSERACTIONCLEAR","prop":"Visible"}]}""");
         setEventMetadata("GRIDSDT_CALLTOACTIONS_PREVPAGE","""{"handler":"subgridsdt_calltoactions_previouspage","iparms":[{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"GRIDSDT_CALLTOACTIONS_nEOF"},{"av":"AV49SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":180},{"av":"nGXsfl_180_idx","ctrl":"GRID","prop":"GridCurrRow","grid":180},{"av":"nRC_GXsfl_180","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":180},{"av":"subGridsdt_calltoactions_Rows","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"Rows"},{"av":"AV47OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV36Step","fld":"vSTEP","pic":"ZZZ9","hsh":true},{"av":"dynavProductservicegroup"},{"av":"AV13ProductServiceGroup","fld":"vPRODUCTSERVICEGROUP"},{"av":"AV42noFilterAgb","fld":"vNOFILTERAGB"},{"av":"AV40noFilterGen","fld":"vNOFILTERGEN"}]""");
         setEventMetadata("GRIDSDT_CALLTOACTIONS_PREVPAGE",""","oparms":[{"ctrl":"BTNFINISH","prop":"Visible"},{"ctrl":"BTNUSERACTIONCLEAR","prop":"Visible"}]}""");
         setEventMetadata("GRIDSDT_CALLTOACTIONS_NEXTPAGE","""{"handler":"subgridsdt_calltoactions_nextpage","iparms":[{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"GRIDSDT_CALLTOACTIONS_nEOF"},{"av":"AV49SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":180},{"av":"nGXsfl_180_idx","ctrl":"GRID","prop":"GridCurrRow","grid":180},{"av":"nRC_GXsfl_180","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":180},{"av":"subGridsdt_calltoactions_Rows","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"Rows"},{"av":"AV47OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV36Step","fld":"vSTEP","pic":"ZZZ9","hsh":true},{"av":"dynavProductservicegroup"},{"av":"AV13ProductServiceGroup","fld":"vPRODUCTSERVICEGROUP"},{"av":"AV42noFilterAgb","fld":"vNOFILTERAGB"},{"av":"AV40noFilterGen","fld":"vNOFILTERGEN"}]""");
         setEventMetadata("GRIDSDT_CALLTOACTIONS_NEXTPAGE",""","oparms":[{"ctrl":"BTNFINISH","prop":"Visible"},{"ctrl":"BTNUSERACTIONCLEAR","prop":"Visible"}]}""");
         setEventMetadata("GRIDSDT_CALLTOACTIONS_LASTPAGE","""{"handler":"subgridsdt_calltoactions_lastpage","iparms":[{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"GRIDSDT_CALLTOACTIONS_nEOF"},{"av":"AV49SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":180},{"av":"nGXsfl_180_idx","ctrl":"GRID","prop":"GridCurrRow","grid":180},{"av":"nRC_GXsfl_180","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":180},{"av":"subGridsdt_calltoactions_Rows","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"Rows"},{"av":"AV47OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV36Step","fld":"vSTEP","pic":"ZZZ9","hsh":true},{"av":"dynavProductservicegroup"},{"av":"AV13ProductServiceGroup","fld":"vPRODUCTSERVICEGROUP"},{"av":"AV42noFilterAgb","fld":"vNOFILTERAGB"},{"av":"AV40noFilterGen","fld":"vNOFILTERGEN"}]""");
         setEventMetadata("GRIDSDT_CALLTOACTIONS_LASTPAGE",""","oparms":[{"ctrl":"BTNFINISH","prop":"Visible"},{"ctrl":"BTNUSERACTIONCLEAR","prop":"Visible"}]}""");
         setEventMetadata("VALIDV_CALLTOACTIONTYPE","""{"handler":"Validv_Calltoactiontype","iparms":[]}""");
         setEventMetadata("VALIDV_CALLTOACTIONURL","""{"handler":"Validv_Calltoactionurl","iparms":[]}""");
         setEventMetadata("VALIDV_CALLTOACTIONEMAIL","""{"handler":"Validv_Calltoactionemail","iparms":[]}""");
         setEventMetadata("VALIDV_SUPPLIERAGBID","""{"handler":"Validv_Supplieragbid","iparms":[]}""");
         setEventMetadata("VALIDV_SUPPLIERGENID","""{"handler":"Validv_Suppliergenid","iparms":[]}""");
         setEventMetadata("VALIDV_LOCATIONDYNAMICFORMID","""{"handler":"Validv_Locationdynamicformid","iparms":[]}""");
         setEventMetadata("VALIDV_CALLTOACTIONID","""{"handler":"Validv_Calltoactionid","iparms":[]}""");
         setEventMetadata("VALIDV_LOCATIONID","""{"handler":"Validv_Locationid","iparms":[]}""");
         setEventMetadata("VALIDV_PRODUCTSERVICEID","""{"handler":"Validv_Productserviceid","iparms":[]}""");
         setEventMetadata("VALIDV_GXV2","""{"handler":"Validv_Gxv2","iparms":[]}""");
         setEventMetadata("VALIDV_GXV3","""{"handler":"Validv_Gxv3","iparms":[]}""");
         setEventMetadata("VALIDV_GXV4","""{"handler":"Validv_Gxv4","iparms":[]}""");
         setEventMetadata("VALIDV_GXV5","""{"handler":"Validv_Gxv5","iparms":[]}""");
         setEventMetadata("VALIDV_GXV7","""{"handler":"Validv_Gxv7","iparms":[]}""");
         setEventMetadata("VALIDV_GXV9","""{"handler":"Validv_Gxv9","iparms":[]}""");
         setEventMetadata("VALIDV_GXV10","""{"handler":"Validv_Gxv10","iparms":[]}""");
         setEventMetadata("VALIDV_GXV11","""{"handler":"Validv_Gxv11","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Gridactiongroup1","iparms":[]}""");
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

      public override bool UploadEnabled( )
      {
         return true ;
      }

      public override void initialize( )
      {
         Combo_locationdynamicformid_Selectedvalue_get = "";
         Combo_phonecode_Selectedvalue_get = "";
         Combo_suppliergenid_Selectedvalue_get = "";
         Combo_supplieragbid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV13ProductServiceGroup = "";
         AV47OrganisationId = Guid.Empty;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV49SDT_CallToAction = new GXBaseCollection<SdtSDT_CallToAction_SDT_CallToActionItem>( context, "SDT_CallToActionItem", "Comforta_version2");
         AV17UploadedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "Comforta_version2");
         AV18FailedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "Comforta_version2");
         AV46SupplierAgbId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV43SupplierGenId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV30DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV34PhoneCode_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV29LocationDynamicFormId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A44SupplierGenCompanyName = "";
         A11OrganisationId = Guid.Empty;
         A42SupplierGenId = Guid.Empty;
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV8ProductServiceName = "";
         AV9ProductServiceTileName = "";
         lblProductserviceimagetext_Jsonclick = "";
         AV12ProductServiceClass = "";
         lblTextblockcombo_supplieragbid_Jsonclick = "";
         lblTextblockcombo_suppliergenid_Jsonclick = "";
         AV20ProductServiceDescription = "";
         AV22CallToActionType = "";
         AV23CallToActionName = "";
         AV28CallToActionUrl = "";
         lblPhonelabel_Jsonclick = "";
         ucCombo_phonecode = new GXUserControl();
         AV26PhoneNumber = "";
         lblTextblockcombo_locationdynamicformid_Jsonclick = "";
         ucCombo_locationdynamicformid = new GXUserControl();
         AV24CallToActionEmail = "";
         bttBtnuseractionadd_Jsonclick = "";
         bttBtnuseractionclear_Jsonclick = "";
         Gridsdt_calltoactionsContainer = new GXWebGrid( context);
         sStyleString = "";
         ucBtnprevious = new GXUserControl();
         ucBtnnext = new GXUserControl();
         bttBtnfinish_Jsonclick = "";
         AV41SupplierAgbId = Guid.Empty;
         AV39SupplierGenId = Guid.Empty;
         AV27PhoneCode = "";
         AV25LocationDynamicFormId = Guid.Empty;
         AV21CallToActionId = Guid.Empty;
         AV52WWPFormReferenceName = "";
         AV53CallToActionPhone = "";
         AV14LocationId = Guid.Empty;
         AV7ProductServiceId = Guid.Empty;
         ucGridsdt_calltoactions_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV50CallToActionVariable = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         AV15FileName = "";
         GXt_guid1 = Guid.Empty;
         AV37PreferredAgbSuppliers = new GxSimpleCollection<Guid>();
         AV38PreferredGenSuppliers = new GxSimpleCollection<Guid>();
         GXt_objcol_guid2 = new GxSimpleCollection<Guid>();
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         GXt_char4 = "";
         Gridsdt_calltoactions_empowerer_Gridinternalname = "";
         Gridsdt_calltoactionsRow = new GXWebRow();
         GXEncryptionTmp = "";
         AV44ComboSelectedValue = "";
         AV45Session = context.GetSession();
         Combo_suppliergenid_Selectedvalue_set = "";
         ucCombo_suppliergenid = new GXUserControl();
         Combo_locationdynamicformid_Ddointernalname = "";
         AV66GXV13 = new GXBaseCollection<SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem>( context, "SDT_LocationDynamicFormItem", "Comforta_version2");
         GXt_objcol_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem5 = new GXBaseCollection<SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem>( context, "SDT_LocationDynamicFormItem", "Comforta_version2");
         AV32LocationDynamicFormId_DPItem = new SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem(context);
         AV31Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         Combo_locationdynamicformid_Selectedvalue_set = "";
         AV68GXV15 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         GXt_objcol_SdtSDT_Country_SDT_CountryItem6 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV35PhoneCode_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV33ComboTitles = new GxSimpleCollection<string>();
         Combo_phonecode_Selectedvalue_set = "";
         H00A02_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00A02_A602SG_LocationSupplierOrganisatio = new Guid[] {Guid.Empty} ;
         H00A02_n602SG_LocationSupplierOrganisatio = new bool[] {false} ;
         H00A02_A603SG_LocationSupplierLocationId = new Guid[] {Guid.Empty} ;
         H00A02_n603SG_LocationSupplierLocationId = new bool[] {false} ;
         H00A02_A630ToolBoxLastUpdateReceptionistI = new Guid[] {Guid.Empty} ;
         H00A02_n630ToolBoxLastUpdateReceptionistI = new bool[] {false} ;
         H00A02_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         H00A02_A29LocationId = new Guid[] {Guid.Empty} ;
         H00A02_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         H00A02_A44SupplierGenCompanyName = new string[] {""} ;
         A602SG_LocationSupplierOrganisatio = Guid.Empty;
         A603SG_LocationSupplierLocationId = Guid.Empty;
         A630ToolBoxLastUpdateReceptionistI = Guid.Empty;
         A89ReceptionistId = Guid.Empty;
         A29LocationId = Guid.Empty;
         H00A03_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A49SupplierAgbId = Guid.Empty;
         H00A04_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         H00A04_A51SupplierAgbName = new string[] {""} ;
         A51SupplierAgbName = "";
         Combo_supplieragbid_Selectedvalue_set = "";
         ucCombo_supplieragbid = new GXUserControl();
         H00A05_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         H00A05_A51SupplierAgbName = new string[] {""} ;
         H00A06_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         H00A06_A51SupplierAgbName = new string[] {""} ;
         H00A07_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00A07_A602SG_LocationSupplierOrganisatio = new Guid[] {Guid.Empty} ;
         H00A07_n602SG_LocationSupplierOrganisatio = new bool[] {false} ;
         H00A07_A603SG_LocationSupplierLocationId = new Guid[] {Guid.Empty} ;
         H00A07_n603SG_LocationSupplierLocationId = new bool[] {false} ;
         H00A07_A630ToolBoxLastUpdateReceptionistI = new Guid[] {Guid.Empty} ;
         H00A07_n630ToolBoxLastUpdateReceptionistI = new bool[] {false} ;
         H00A07_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         H00A07_A29LocationId = new Guid[] {Guid.Empty} ;
         H00A07_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         H00A07_A44SupplierGenCompanyName = new string[] {""} ;
         H00A08_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00A09_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         H00A09_A44SupplierGenCompanyName = new string[] {""} ;
         Combo_suppliergenid_Caption = "";
         Combo_supplieragbid_Caption = "";
         ucUsercontrol1 = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridsdt_calltoactions_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         Gridsdt_calltoactionsColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wc_productservice__default(),
            new Object[][] {
                new Object[] {
               H00A02_A11OrganisationId, H00A02_A602SG_LocationSupplierOrganisatio, H00A02_n602SG_LocationSupplierOrganisatio, H00A02_A603SG_LocationSupplierLocationId, H00A02_n603SG_LocationSupplierLocationId, H00A02_A630ToolBoxLastUpdateReceptionistI, H00A02_n630ToolBoxLastUpdateReceptionistI, H00A02_A89ReceptionistId, H00A02_A29LocationId, H00A02_A42SupplierGenId,
               H00A02_A44SupplierGenCompanyName
               }
               , new Object[] {
               H00A03_A11OrganisationId
               }
               , new Object[] {
               H00A04_A49SupplierAgbId, H00A04_A51SupplierAgbName
               }
               , new Object[] {
               H00A05_A49SupplierAgbId, H00A05_A51SupplierAgbName
               }
               , new Object[] {
               H00A06_A49SupplierAgbId, H00A06_A51SupplierAgbName
               }
               , new Object[] {
               H00A07_A11OrganisationId, H00A07_A602SG_LocationSupplierOrganisatio, H00A07_n602SG_LocationSupplierOrganisatio, H00A07_A603SG_LocationSupplierLocationId, H00A07_n603SG_LocationSupplierLocationId, H00A07_A630ToolBoxLastUpdateReceptionistI, H00A07_n630ToolBoxLastUpdateReceptionistI, H00A07_A89ReceptionistId, H00A07_A29LocationId, H00A07_A42SupplierGenId,
               H00A07_A44SupplierGenCompanyName
               }
               , new Object[] {
               H00A08_A11OrganisationId
               }
               , new Object[] {
               H00A09_A42SupplierGenId, H00A09_A44SupplierGenCompanyName
               }
            }
         );
         /* GeneXus formulas. */
         edtavFilename_Enabled = 0;
         edtavSdt_calltoaction__calltoactionid_Enabled = 0;
         edtavSdt_calltoaction__organisationid_Enabled = 0;
         edtavSdt_calltoaction__locationid_Enabled = 0;
         edtavSdt_calltoaction__productserviceid_Enabled = 0;
         edtavSdt_calltoaction__calltoactionname_Enabled = 0;
         cmbavSdt_calltoaction__calltoactiontype.Enabled = 0;
         edtavSdt_calltoaction__calltoactionphone_Enabled = 0;
         edtavSdt_calltoaction__calltoactionurl_Enabled = 0;
         edtavSdt_calltoaction__calltoactionemail_Enabled = 0;
         edtavSdt_calltoaction__locationdynamicformid_Enabled = 0;
         edtavSdt_calltoaction__wwpformreferencename_Enabled = 0;
         edtavCalltoactionvariable_Enabled = 0;
      }

      private short GRIDSDT_CALLTOACTIONS_nEOF ;
      private short nRcdExists_8 ;
      private short nIsMod_8 ;
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
      private short AV36Step ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV51GridActionGroup1 ;
      private short nDonePA ;
      private short subGridsdt_calltoactions_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGridsdt_calltoactions_Backstyle ;
      private short subGridsdt_calltoactions_Titlebackstyle ;
      private short subGridsdt_calltoactions_Allowselection ;
      private short subGridsdt_calltoactions_Allowhovering ;
      private short subGridsdt_calltoactions_Allowcollapsing ;
      private short subGridsdt_calltoactions_Collapsed ;
      private int nRC_GXsfl_180 ;
      private int subGridsdt_calltoactions_Rows ;
      private int nGXsfl_180_idx=1 ;
      private int divServicetable_Visible ;
      private int edtavProductservicename_Enabled ;
      private int edtavProductservicetilename_Enabled ;
      private int edtavProductservicedescription_Enabled ;
      private int divCalltoactionstable_Visible ;
      private int edtavCalltoactionname_Enabled ;
      private int edtavCalltoactionurl_Enabled ;
      private int edtavPhonenumber_Enabled ;
      private int edtavCalltoactionemail_Enabled ;
      private int bttBtnuseractionclear_Visible ;
      private int AV54GXV1 ;
      private int bttBtnfinish_Visible ;
      private int edtavSupplieragbid_Visible ;
      private int edtavSuppliergenid_Visible ;
      private int edtavPhonecode_Visible ;
      private int edtavLocationdynamicformid_Visible ;
      private int edtavCalltoactionid_Visible ;
      private int edtavWwpformreferencename_Visible ;
      private int edtavCalltoactionphone_Visible ;
      private int edtavLocationid_Visible ;
      private int edtavProductserviceid_Visible ;
      private int gxdynajaxindex ;
      private int subGridsdt_calltoactions_Islastpage ;
      private int edtavFilename_Enabled ;
      private int edtavSdt_calltoaction__calltoactionid_Enabled ;
      private int edtavSdt_calltoaction__organisationid_Enabled ;
      private int edtavSdt_calltoaction__locationid_Enabled ;
      private int edtavSdt_calltoaction__productserviceid_Enabled ;
      private int edtavSdt_calltoaction__calltoactionname_Enabled ;
      private int edtavSdt_calltoaction__calltoactionphone_Enabled ;
      private int edtavSdt_calltoaction__calltoactionurl_Enabled ;
      private int edtavSdt_calltoaction__calltoactionemail_Enabled ;
      private int edtavSdt_calltoaction__locationdynamicformid_Enabled ;
      private int edtavSdt_calltoaction__wwpformreferencename_Enabled ;
      private int edtavCalltoactionvariable_Enabled ;
      private int GRIDSDT_CALLTOACTIONS_nGridOutOfScope ;
      private int nGXsfl_180_fel_idx=1 ;
      private int AV67GXV14 ;
      private int AV69GXV16 ;
      private int Usercontrol1_Maxfilesize ;
      private int Usercontrol1_Maxnumberoffiles ;
      private int idxLst ;
      private int subGridsdt_calltoactions_Backcolor ;
      private int subGridsdt_calltoactions_Allbackcolor ;
      private int subGridsdt_calltoactions_Titlebackcolor ;
      private int subGridsdt_calltoactions_Selectedindex ;
      private int subGridsdt_calltoactions_Selectioncolor ;
      private int subGridsdt_calltoactions_Hoveringcolor ;
      private long GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage ;
      private long GRIDSDT_CALLTOACTIONS_nCurrentRecord ;
      private long GRIDSDT_CALLTOACTIONS_nRecordCount ;
      private string Combo_locationdynamicformid_Selectedvalue_get ;
      private string Combo_phonecode_Selectedvalue_get ;
      private string Combo_suppliergenid_Selectedvalue_get ;
      private string Combo_supplieragbid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_180_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divServicetable_Internalname ;
      private string grpUnnamedgroup8_Internalname ;
      private string divServicegroup_Internalname ;
      private string divUnnamedtable9_Internalname ;
      private string edtavProductservicename_Internalname ;
      private string TempTags ;
      private string edtavProductservicename_Jsonclick ;
      private string edtavProductservicetilename_Internalname ;
      private string AV9ProductServiceTileName ;
      private string edtavProductservicetilename_Jsonclick ;
      private string divUnnamedtable12_Internalname ;
      private string lblProductserviceimagetext_Internalname ;
      private string lblProductserviceimagetext_Jsonclick ;
      private string divUcfilecell_Internalname ;
      private string divUnnamedtable10_Internalname ;
      private string cmbavProductserviceclass_Internalname ;
      private string cmbavProductserviceclass_Jsonclick ;
      private string dynavProductservicegroup_Internalname ;
      private string dynavProductservicegroup_Jsonclick ;
      private string divUnnamedtable11_Internalname ;
      private string divTablesupplieragb_Internalname ;
      private string divTablesplittedsupplieragbid_Internalname ;
      private string lblTextblockcombo_supplieragbid_Internalname ;
      private string lblTextblockcombo_supplieragbid_Jsonclick ;
      private string divTablesuppliergen_Internalname ;
      private string divTablesplittedsuppliergenid_Internalname ;
      private string lblTextblockcombo_suppliergenid_Internalname ;
      private string lblTextblockcombo_suppliergenid_Jsonclick ;
      private string edtavProductservicedescription_Internalname ;
      private string divCalltoactionstable_Internalname ;
      private string grpUnnamedgroup2_Internalname ;
      private string divCalltoactionsgroup_Internalname ;
      private string cmbavCalltoactiontype_Internalname ;
      private string cmbavCalltoactiontype_Jsonclick ;
      private string edtavCalltoactionname_Internalname ;
      private string edtavCalltoactionname_Jsonclick ;
      private string divUnnamedtable4_Internalname ;
      private string divTableurl_Internalname ;
      private string divCalltoactionurl_cell_Internalname ;
      private string divCalltoactionurl_cell_Class ;
      private string edtavCalltoactionurl_Internalname ;
      private string edtavCalltoactionurl_Jsonclick ;
      private string divTablephone_Internalname ;
      private string lblPhonelabel_Internalname ;
      private string lblPhonelabel_Jsonclick ;
      private string divUnnamedtable5_Internalname ;
      private string divUnnamedtable6_Internalname ;
      private string Combo_phonecode_Caption ;
      private string Combo_phonecode_Cls ;
      private string Combo_phonecode_Internalname ;
      private string divUnnamedtable7_Internalname ;
      private string divPhonenumber_cell_Internalname ;
      private string divPhonenumber_cell_Class ;
      private string edtavPhonenumber_Internalname ;
      private string edtavPhonenumber_Jsonclick ;
      private string divTableform_Internalname ;
      private string divCombo_locationdynamicformid_cell_Internalname ;
      private string divCombo_locationdynamicformid_cell_Class ;
      private string divTablesplittedlocationdynamicformid_Internalname ;
      private string lblTextblockcombo_locationdynamicformid_Internalname ;
      private string lblTextblockcombo_locationdynamicformid_Jsonclick ;
      private string Combo_locationdynamicformid_Caption ;
      private string Combo_locationdynamicformid_Cls ;
      private string Combo_locationdynamicformid_Internalname ;
      private string divTableemail_Internalname ;
      private string divCalltoactionemail_cell_Internalname ;
      private string divCalltoactionemail_cell_Class ;
      private string edtavCalltoactionemail_Internalname ;
      private string edtavCalltoactionemail_Jsonclick ;
      private string bttBtnuseractionadd_Internalname ;
      private string bttBtnuseractionadd_Jsonclick ;
      private string bttBtnuseractionclear_Internalname ;
      private string bttBtnuseractionclear_Jsonclick ;
      private string divUnnamedtable3_Internalname ;
      private string sStyleString ;
      private string subGridsdt_calltoactions_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string Btnprevious_Tooltiptext ;
      private string Btnprevious_Beforeiconclass ;
      private string Btnprevious_Caption ;
      private string Btnprevious_Class ;
      private string Btnprevious_Internalname ;
      private string Btnnext_Tooltiptext ;
      private string Btnnext_Aftericonclass ;
      private string Btnnext_Caption ;
      private string Btnnext_Class ;
      private string Btnnext_Internalname ;
      private string bttBtnfinish_Internalname ;
      private string bttBtnfinish_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavSupplieragbid_Internalname ;
      private string edtavSupplieragbid_Jsonclick ;
      private string edtavSuppliergenid_Internalname ;
      private string edtavSuppliergenid_Jsonclick ;
      private string edtavPhonecode_Internalname ;
      private string edtavPhonecode_Jsonclick ;
      private string edtavLocationdynamicformid_Internalname ;
      private string edtavLocationdynamicformid_Jsonclick ;
      private string edtavCalltoactionid_Internalname ;
      private string edtavCalltoactionid_Jsonclick ;
      private string edtavWwpformreferencename_Internalname ;
      private string edtavWwpformreferencename_Jsonclick ;
      private string edtavCalltoactionphone_Internalname ;
      private string AV53CallToActionPhone ;
      private string edtavCalltoactionphone_Jsonclick ;
      private string edtavLocationid_Internalname ;
      private string edtavLocationid_Jsonclick ;
      private string edtavProductserviceid_Internalname ;
      private string edtavProductserviceid_Jsonclick ;
      private string Gridsdt_calltoactions_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavCalltoactionvariable_Internalname ;
      private string cmbavGridactiongroup1_Internalname ;
      private string gxwrpcisep ;
      private string edtavFilename_Internalname ;
      private string sGXsfl_180_fel_idx="0001" ;
      private string chkavNofilteragb_Internalname ;
      private string chkavNofiltergen_Internalname ;
      private string Combo_phonecode_Htmltemplate ;
      private string GXt_char4 ;
      private string Gridsdt_calltoactions_empowerer_Gridinternalname ;
      private string GXEncryptionTmp ;
      private string Combo_suppliergenid_Selectedvalue_set ;
      private string Combo_suppliergenid_Internalname ;
      private string Combo_locationdynamicformid_Ddointernalname ;
      private string Combo_locationdynamicformid_Selectedvalue_set ;
      private string Combo_phonecode_Selectedvalue_set ;
      private string Combo_supplieragbid_Selectedvalue_set ;
      private string Combo_supplieragbid_Internalname ;
      private string tblTablemergedsuppliergenid_Internalname ;
      private string Combo_suppliergenid_Caption ;
      private string Combo_suppliergenid_Cls ;
      private string tblTablemergedsupplieragbid_Internalname ;
      private string Combo_supplieragbid_Caption ;
      private string Combo_supplieragbid_Cls ;
      private string tblTablemergedusercontrol1_Internalname ;
      private string Usercontrol1_Tooltiptext ;
      private string Usercontrol1_Acceptedfiletypes ;
      private string Usercontrol1_Internalname ;
      private string edtavFilename_Jsonclick ;
      private string edtavSdt_calltoaction__calltoactionid_Internalname ;
      private string edtavSdt_calltoaction__organisationid_Internalname ;
      private string edtavSdt_calltoaction__locationid_Internalname ;
      private string edtavSdt_calltoaction__productserviceid_Internalname ;
      private string edtavSdt_calltoaction__calltoactionname_Internalname ;
      private string cmbavSdt_calltoaction__calltoactiontype_Internalname ;
      private string edtavSdt_calltoaction__calltoactionphone_Internalname ;
      private string edtavSdt_calltoaction__calltoactionurl_Internalname ;
      private string edtavSdt_calltoaction__calltoactionemail_Internalname ;
      private string edtavSdt_calltoaction__locationdynamicformid_Internalname ;
      private string edtavSdt_calltoaction__wwpformreferencename_Internalname ;
      private string subGridsdt_calltoactions_Class ;
      private string subGridsdt_calltoactions_Linesclass ;
      private string ROClassString ;
      private string edtavSdt_calltoaction__calltoactionid_Jsonclick ;
      private string edtavSdt_calltoaction__organisationid_Jsonclick ;
      private string edtavSdt_calltoaction__locationid_Jsonclick ;
      private string edtavSdt_calltoaction__productserviceid_Jsonclick ;
      private string edtavSdt_calltoaction__calltoactionname_Jsonclick ;
      private string GXCCtl ;
      private string cmbavSdt_calltoaction__calltoactiontype_Jsonclick ;
      private string edtavSdt_calltoaction__calltoactionphone_Jsonclick ;
      private string edtavSdt_calltoaction__calltoactionurl_Jsonclick ;
      private string edtavSdt_calltoaction__calltoactionemail_Jsonclick ;
      private string edtavSdt_calltoaction__locationdynamicformid_Jsonclick ;
      private string edtavSdt_calltoaction__wwpformreferencename_Jsonclick ;
      private string edtavCalltoactionvariable_Jsonclick ;
      private string cmbavGridactiongroup1_Jsonclick ;
      private string subGridsdt_calltoactions_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV42noFilterAgb ;
      private bool AV40noFilterGen ;
      private bool wbLoad ;
      private bool Combo_phonecode_Emptyitem ;
      private bool Combo_locationdynamicformid_Emptyitem ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_180_Refreshing=false ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV16CheckRequiredFieldsResult ;
      private bool Combo_suppliergenid_Includeaddnewoption ;
      private bool GXt_boolean7 ;
      private bool n602SG_LocationSupplierOrganisatio ;
      private bool n603SG_LocationSupplierLocationId ;
      private bool n630ToolBoxLastUpdateReceptionistI ;
      private bool AV48isStart ;
      private bool Combo_suppliergenid_Emptyitem ;
      private bool Combo_supplieragbid_Emptyitem ;
      private bool Usercontrol1_Autoupload ;
      private bool Usercontrol1_Hideadditionalbuttons ;
      private bool Usercontrol1_Enableuploadedfilecanceling ;
      private bool Usercontrol1_Disableimageresize ;
      private bool Usercontrol1_Autodisableaddingfiles ;
      private string AV20ProductServiceDescription ;
      private string AV13ProductServiceGroup ;
      private string A44SupplierGenCompanyName ;
      private string AV8ProductServiceName ;
      private string AV12ProductServiceClass ;
      private string AV22CallToActionType ;
      private string AV23CallToActionName ;
      private string AV28CallToActionUrl ;
      private string AV26PhoneNumber ;
      private string AV24CallToActionEmail ;
      private string AV27PhoneCode ;
      private string AV52WWPFormReferenceName ;
      private string AV50CallToActionVariable ;
      private string AV15FileName ;
      private string AV44ComboSelectedValue ;
      private string A51SupplierAgbName ;
      private Guid AV47OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A42SupplierGenId ;
      private Guid AV41SupplierAgbId ;
      private Guid AV39SupplierGenId ;
      private Guid AV25LocationDynamicFormId ;
      private Guid AV21CallToActionId ;
      private Guid AV14LocationId ;
      private Guid AV7ProductServiceId ;
      private Guid GXt_guid1 ;
      private Guid A602SG_LocationSupplierOrganisatio ;
      private Guid A603SG_LocationSupplierLocationId ;
      private Guid A630ToolBoxLastUpdateReceptionistI ;
      private Guid A89ReceptionistId ;
      private Guid A29LocationId ;
      private Guid A49SupplierAgbId ;
      private IGxSession AV45Session ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid Gridsdt_calltoactionsContainer ;
      private GXWebRow Gridsdt_calltoactionsRow ;
      private GXWebColumn Gridsdt_calltoactionsColumn ;
      private GXUserControl ucCombo_phonecode ;
      private GXUserControl ucCombo_locationdynamicformid ;
      private GXUserControl ucBtnprevious ;
      private GXUserControl ucBtnnext ;
      private GXUserControl ucGridsdt_calltoactions_empowerer ;
      private GXUserControl ucCombo_suppliergenid ;
      private GXUserControl ucCombo_supplieragbid ;
      private GXUserControl ucUsercontrol1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavProductserviceclass ;
      private GXCombobox dynavProductservicegroup ;
      private GXCheckbox chkavNofilteragb ;
      private GXCheckbox chkavNofiltergen ;
      private GXCombobox cmbavCalltoactiontype ;
      private GXCombobox cmbavSdt_calltoaction__calltoactiontype ;
      private GXCombobox cmbavGridactiongroup1 ;
      private GXBaseCollection<SdtSDT_CallToAction_SDT_CallToActionItem> AV49SDT_CallToAction ;
      private GXBaseCollection<SdtFileUploadData> AV17UploadedFiles ;
      private GXBaseCollection<SdtFileUploadData> AV18FailedFiles ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV46SupplierAgbId_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV43SupplierGenId_Data ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV30DDO_TitleSettingsIcons ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV34PhoneCode_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV29LocationDynamicFormId_Data ;
      private GxSimpleCollection<Guid> AV37PreferredAgbSuppliers ;
      private GxSimpleCollection<Guid> AV38PreferredGenSuppliers ;
      private GxSimpleCollection<Guid> GXt_objcol_guid2 ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3 ;
      private GXBaseCollection<SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem> AV66GXV13 ;
      private GXBaseCollection<SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem> GXt_objcol_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem5 ;
      private SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem AV32LocationDynamicFormId_DPItem ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV31Combo_DataItem ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV68GXV15 ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> GXt_objcol_SdtSDT_Country_SDT_CountryItem6 ;
      private SdtSDT_Country_SDT_CountryItem AV35PhoneCode_DPItem ;
      private GxSimpleCollection<string> AV33ComboTitles ;
      private IDataStoreProvider pr_default ;
      private Guid[] H00A02_A11OrganisationId ;
      private Guid[] H00A02_A602SG_LocationSupplierOrganisatio ;
      private bool[] H00A02_n602SG_LocationSupplierOrganisatio ;
      private Guid[] H00A02_A603SG_LocationSupplierLocationId ;
      private bool[] H00A02_n603SG_LocationSupplierLocationId ;
      private Guid[] H00A02_A630ToolBoxLastUpdateReceptionistI ;
      private bool[] H00A02_n630ToolBoxLastUpdateReceptionistI ;
      private Guid[] H00A02_A89ReceptionistId ;
      private Guid[] H00A02_A29LocationId ;
      private Guid[] H00A02_A42SupplierGenId ;
      private string[] H00A02_A44SupplierGenCompanyName ;
      private Guid[] H00A03_A11OrganisationId ;
      private Guid[] H00A04_A49SupplierAgbId ;
      private string[] H00A04_A51SupplierAgbName ;
      private Guid[] H00A05_A49SupplierAgbId ;
      private string[] H00A05_A51SupplierAgbName ;
      private Guid[] H00A06_A49SupplierAgbId ;
      private string[] H00A06_A51SupplierAgbName ;
      private Guid[] H00A07_A11OrganisationId ;
      private Guid[] H00A07_A602SG_LocationSupplierOrganisatio ;
      private bool[] H00A07_n602SG_LocationSupplierOrganisatio ;
      private Guid[] H00A07_A603SG_LocationSupplierLocationId ;
      private bool[] H00A07_n603SG_LocationSupplierLocationId ;
      private Guid[] H00A07_A630ToolBoxLastUpdateReceptionistI ;
      private bool[] H00A07_n630ToolBoxLastUpdateReceptionistI ;
      private Guid[] H00A07_A89ReceptionistId ;
      private Guid[] H00A07_A29LocationId ;
      private Guid[] H00A07_A42SupplierGenId ;
      private string[] H00A07_A44SupplierGenCompanyName ;
      private Guid[] H00A08_A11OrganisationId ;
      private Guid[] H00A09_A42SupplierGenId ;
      private string[] H00A09_A44SupplierGenCompanyName ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wc_productservice__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00A04( IGxContext context ,
                                             Guid A49SupplierAgbId ,
                                             GxSimpleCollection<Guid> AV37PreferredAgbSuppliers )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT SupplierAgbId, SupplierAgbName FROM Trn_SupplierAGB";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV37PreferredAgbSuppliers, "SupplierAgbId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SupplierAgbName";
         GXv_Object8[0] = scmdbuf;
         return GXv_Object8 ;
      }

      protected Object[] conditional_H00A06( IGxContext context ,
                                             Guid A49SupplierAgbId ,
                                             GxSimpleCollection<Guid> AV37PreferredAgbSuppliers )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT SupplierAgbId, SupplierAgbName FROM Trn_SupplierAGB";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV37PreferredAgbSuppliers, "SupplierAgbId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SupplierAgbName";
         GXv_Object10[0] = scmdbuf;
         return GXv_Object10 ;
      }

      protected Object[] conditional_H00A07( IGxContext context ,
                                             Guid A42SupplierGenId ,
                                             GxSimpleCollection<Guid> AV38PreferredGenSuppliers ,
                                             Guid A11OrganisationId ,
                                             Guid AV47OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int12 = new short[1];
         Object[] GXv_Object13 = new Object[2];
         scmdbuf = "SELECT T3.OrganisationId, T1.SG_LocationSupplierOrganisatio AS SG_LocationSupplierOrganisatio, T1.SG_LocationSupplierLocationId AS SG_LocationSupplierLocationId, T2.ToolBoxLastUpdateReceptionistI, T3.ReceptionistId, T3.LocationId, T1.SupplierGenId, T1.SupplierGenCompanyName FROM ((Trn_SupplierGen T1 LEFT JOIN Trn_Location T2 ON T2.LocationId = T1.SG_LocationSupplierLocationId AND T2.OrganisationId = T1.SG_LocationSupplierOrganisatio) LEFT JOIN Trn_Receptionist T3 ON T3.ReceptionistId = T2.ToolBoxLastUpdateReceptionistI AND T3.OrganisationId = T1.SG_LocationSupplierOrganisatio AND T3.LocationId = T1.SG_LocationSupplierLocationId)";
         AddWhere(sWhereString, "(Not "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV38PreferredGenSuppliers, "T1.SupplierGenId IN (", ")")+")");
         AddWhere(sWhereString, "(T3.OrganisationId = :AV47OrganisationId)");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SupplierGenCompanyName";
         GXv_Object13[0] = scmdbuf;
         GXv_Object13[1] = GXv_int12;
         return GXv_Object13 ;
      }

      protected Object[] conditional_H00A09( IGxContext context ,
                                             Guid A42SupplierGenId ,
                                             GxSimpleCollection<Guid> AV38PreferredGenSuppliers )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object14 = new Object[2];
         scmdbuf = "SELECT SupplierGenId, SupplierGenCompanyName FROM Trn_SupplierGen";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV38PreferredGenSuppliers, "SupplierGenId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SupplierGenCompanyName";
         GXv_Object14[0] = scmdbuf;
         return GXv_Object14 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 2 :
                     return conditional_H00A04(context, (Guid)dynConstraints[0] , (GxSimpleCollection<Guid>)dynConstraints[1] );
               case 4 :
                     return conditional_H00A06(context, (Guid)dynConstraints[0] , (GxSimpleCollection<Guid>)dynConstraints[1] );
               case 5 :
                     return conditional_H00A07(context, (Guid)dynConstraints[0] , (GxSimpleCollection<Guid>)dynConstraints[1] , (Guid)dynConstraints[2] , (Guid)dynConstraints[3] );
               case 7 :
                     return conditional_H00A09(context, (Guid)dynConstraints[0] , (GxSimpleCollection<Guid>)dynConstraints[1] );
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
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00A02;
          prmH00A02 = new Object[] {
          new ParDef("AV47OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmH00A03;
          prmH00A03 = new Object[] {
          new ParDef("SG_LocationSupplierOrganisatio",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmH00A05;
          prmH00A05 = new Object[] {
          };
          Object[] prmH00A08;
          prmH00A08 = new Object[] {
          new ParDef("SG_LocationSupplierOrganisatio",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmH00A04;
          prmH00A04 = new Object[] {
          };
          Object[] prmH00A06;
          prmH00A06 = new Object[] {
          };
          Object[] prmH00A07;
          prmH00A07 = new Object[] {
          new ParDef("AV47OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmH00A09;
          prmH00A09 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00A02", "SELECT T3.OrganisationId, T1.SG_LocationSupplierOrganisatio AS SG_LocationSupplierOrganisatio, T1.SG_LocationSupplierLocationId AS SG_LocationSupplierLocationId, T2.ToolBoxLastUpdateReceptionistI, T3.ReceptionistId, T3.LocationId, T1.SupplierGenId, T1.SupplierGenCompanyName FROM ((Trn_SupplierGen T1 LEFT JOIN Trn_Location T2 ON T2.LocationId = T1.SG_LocationSupplierLocationId AND T2.OrganisationId = T1.SG_LocationSupplierOrganisatio) LEFT JOIN Trn_Receptionist T3 ON T3.ReceptionistId = T2.ToolBoxLastUpdateReceptionistI AND T3.OrganisationId = T1.SG_LocationSupplierOrganisatio AND T3.LocationId = T1.SG_LocationSupplierLocationId) WHERE T3.OrganisationId = :AV47OrganisationId ORDER BY T1.SupplierGenCompanyName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A02,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00A03", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :SG_LocationSupplierOrganisatio ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A03,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00A04", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A04,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00A05", "SELECT SupplierAgbId, SupplierAgbName FROM Trn_SupplierAGB ORDER BY SupplierAgbName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A05,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00A06", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A06,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00A07", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A07,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00A08", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :SG_LocationSupplierOrganisatio ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A08,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00A09", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A09,100, GxCacheFrequency.OFF ,false,false )
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
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((Guid[]) buf[5])[0] = rslt.getGuid(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((Guid[]) buf[7])[0] = rslt.getGuid(5);
                ((Guid[]) buf[8])[0] = rslt.getGuid(6);
                ((Guid[]) buf[9])[0] = rslt.getGuid(7);
                ((string[]) buf[10])[0] = rslt.getVarchar(8);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((Guid[]) buf[5])[0] = rslt.getGuid(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((Guid[]) buf[7])[0] = rslt.getGuid(5);
                ((Guid[]) buf[8])[0] = rslt.getGuid(6);
                ((Guid[]) buf[9])[0] = rslt.getGuid(7);
                ((string[]) buf[10])[0] = rslt.getVarchar(8);
                return;
             case 6 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 7 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
