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
namespace GeneXus.Programs.workwithplus.dynamicforms {
   public class wwp_dfc_multipledatagrid_wc : GXWebComponent
   {
      public wwp_dfc_multipledatagrid_wc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
      }

      public wwp_dfc_multipledatagrid_wc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPDynamicFormMode ,
                           short aP1_WWPFormElementId ,
                           short aP2_SessionId ,
                           ref GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP3_WWPForm )
      {
         this.AV18WWPDynamicFormMode = aP0_WWPDynamicFormMode;
         this.AV21WWPFormElementId = aP1_WWPFormElementId;
         this.AV13SessionId = aP2_SessionId;
         this.AV19WWPForm = aP3_WWPForm;
         ExecuteImpl();
         aP3_WWPForm=this.AV19WWPForm;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "WWPDynamicFormMode");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  AV18WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
                  AssignAttri(sPrefix, false, "AV18WWPDynamicFormMode", AV18WWPDynamicFormMode);
                  AV21WWPFormElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV21WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV21WWPFormElementId), 4, 0));
                  AV13SessionId = (short)(Math.Round(NumberUtil.Val( GetPar( "SessionId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV13SessionId", StringUtil.LTrimStr( (decimal)(AV13SessionId), 4, 0));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV19WWPForm);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV18WWPDynamicFormMode,(short)AV21WWPFormElementId,(short)AV13SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV19WWPForm});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  gxfirstwebparm = GetFirstPar( "WWPDynamicFormMode");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "WWPDynamicFormMode");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Fsgrid") == 0 )
               {
                  gxnrFsgrid_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Fsgrid") == 0 )
               {
                  gxgrFsgrid_refresh_invoke( ) ;
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      protected void gxnrFsgrid_newrow_invoke( )
      {
         nRC_GXsfl_9 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_9"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_9_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_9_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_9_idx = GetPar( "sGXsfl_9_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrFsgrid_newrow( ) ;
         /* End function gxnrFsgrid_newrow_invoke */
      }

      protected void gxgrFsgrid_refresh_invoke( )
      {
         ajax_req_read_hidden_sdt(GetNextPar( ), AV19WWPForm);
         AV21WWPFormElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementId"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV17WWP_DF_ElementsRepeaterMetadata);
         AV9IsFirstElement = StringUtil.StrToBool( GetPar( "IsFirstElement"));
         AV10IsLastElement = StringUtil.StrToBool( GetPar( "IsLastElement"));
         AV18WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
         AV13SessionId = (short)(Math.Round(NumberUtil.Val( GetPar( "SessionId"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV22WWPFormInstance);
         AV11IsStep = StringUtil.StrToBool( GetPar( "IsStep"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrFsgrid_refresh( AV19WWPForm, AV21WWPFormElementId, AV17WWP_DF_ElementsRepeaterMetadata, AV9IsFirstElement, AV10IsLastElement, AV18WWPDynamicFormMode, AV13SessionId, AV22WWPFormInstance, AV11IsStep, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrFsgrid_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA362( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS362( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( context.GetMessage( "WWP_Dynamic Form Creation_Multiple Data Grid_WC", "")) ;
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
         }
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
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_dfc_multipledatagrid_wc.aspx"+UrlEncode(StringUtil.RTrim(AV18WWPDynamicFormMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV21WWPFormElementId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV13SessionId,4,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.dynamicforms.wwp_dfc_multipledatagrid_wc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_ELEMENTSREPEATERMETADATA", AV17WWP_DF_ElementsRepeaterMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_ELEMENTSREPEATERMETADATA", AV17WWP_DF_ElementsRepeaterMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_ELEMENTSREPEATERMETADATA", GetSecureSignedToken( sPrefix, AV17WWP_DF_ElementsRepeaterMetadata, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISFIRSTELEMENT", AV9IsFirstElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISFIRSTELEMENT", GetSecureSignedToken( sPrefix, AV9IsFirstElement, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISLASTELEMENT", AV10IsLastElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISLASTELEMENT", GetSecureSignedToken( sPrefix, AV10IsLastElement, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORMINSTANCE", AV22WWPFormInstance);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORMINSTANCE", AV22WWPFormInstance);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMINSTANCE", GetSecureSignedToken( sPrefix, AV22WWPFormInstance, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISSTEP", AV11IsStep);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISSTEP", GetSecureSignedToken( sPrefix, AV11IsStep, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_9", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_9), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV18WWPDynamicFormMode", StringUtil.RTrim( wcpOAV18WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV21WWPFormElementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV21WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV13SessionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV13SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORM", AV19WWPForm);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORM", AV19WWPForm);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_ELEMENTSREPEATERMETADATA", AV17WWP_DF_ElementsRepeaterMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_ELEMENTSREPEATERMETADATA", AV17WWP_DF_ElementsRepeaterMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_ELEMENTSREPEATERMETADATA", GetSecureSignedToken( sPrefix, AV17WWP_DF_ElementsRepeaterMetadata, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISFIRSTELEMENT", AV9IsFirstElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISFIRSTELEMENT", GetSecureSignedToken( sPrefix, AV9IsFirstElement, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISLASTELEMENT", AV10IsLastElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISLASTELEMENT", GetSecureSignedToken( sPrefix, AV10IsLastElement, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV18WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORMINSTANCE", AV22WWPFormInstance);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORMINSTANCE", AV22WWPFormInstance);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMINSTANCE", GetSecureSignedToken( sPrefix, AV22WWPFormInstance, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISSTEP", AV11IsStep);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISSTEP", GetSecureSignedToken( sPrefix, AV11IsStep, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"subFsgrid_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFsgrid_Recordcount), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_BTNDELETEELEMENT_Result", StringUtil.RTrim( Dvelop_confirmpanel_btndeleteelement_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"SETTINGS_MODAL_Result", StringUtil.RTrim( Settings_modal_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"ADDELEMENT_MODAL_Result", StringUtil.RTrim( Addelement_modal_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_BTNDELETEELEMENT_Result", StringUtil.RTrim( Dvelop_confirmpanel_btndeleteelement_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"SETTINGS_MODAL_Result", StringUtil.RTrim( Settings_modal_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"ADDELEMENT_MODAL_Result", StringUtil.RTrim( Addelement_modal_Result));
      }

      protected void RenderHtmlCloseForm362( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            if ( ! ( WebComp_Datawcchildren == null ) )
            {
               WebComp_Datawcchildren.componentjscripts();
            }
            if ( ! ( WebComp_Wwpaux_wc == null ) )
            {
               WebComp_Wwpaux_wc.componentjscripts();
            }
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "WorkWithPlus.DynamicForms.WWP_DFC_MultipleDataGrid_WC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WWP_Dynamic Form Creation_Multiple Data Grid_WC", "") ;
      }

      protected void WB360( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "workwithplus.dynamicforms.wwp_dfc_multipledatagrid_wc.aspx");
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableDynFormMultipleDataGridCreation", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MultipleDataGridCell GridNoBorder", "start", "top", "", "", "div");
            /*  Grid Control  */
            FsgridContainer.SetIsFreestyle(true);
            FsgridContainer.SetWrapped(nGXWrapped);
            StartGridControl9( ) ;
         }
         if ( wbEnd == 9 )
         {
            wbEnd = 0;
            nRC_GXsfl_9 = (int)(nGXsfl_9_idx-1);
            if ( FsgridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"FsgridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Fsgrid", FsgridContainer, subFsgrid_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"FsgridContainerData", FsgridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"FsgridContainerData"+"V", FsgridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"FsgridContainerData"+"V"+"\" value='"+FsgridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "end", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonGray DynFormCreationNotAllowedButton";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnaddchild_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(9), 1, 0)+","+"null"+");", bttBtnaddchild_Caption, bttBtnaddchild_Jsonclick, 7, context.GetMessage( "Add child", ""), "", StyleString, ClassString, bttBtnaddchild_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e11361_client"+"'", TempTags, "", 2, "HLP_WorkWithPlus/DynamicForms/WWP_DFC_MultipleDataGrid_WC.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 TableDynFormAddElementCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "TableDynFormAddElement", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "end", "top", "", "", "div");
            wb_table1_29_362( true) ;
         }
         else
         {
            wb_table1_29_362( false) ;
         }
         return  ;
      }

      protected void wb_table1_29_362e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "end", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FixingTopInvisible", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnrefreshgrid_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(9), 1, 0)+","+"null"+");", context.GetMessage( "Refresh", ""), bttBtnrefreshgrid_Jsonclick, 5, context.GetMessage( "Refresh", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOREFRESHGRID\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/DynamicForms/WWP_DFC_MultipleDataGrid_WC.htm");
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
            wb_table2_47_362( true) ;
         }
         else
         {
            wb_table2_47_362( false) ;
         }
         return  ;
      }

      protected void wb_table2_47_362e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table3_52_362( true) ;
         }
         else
         {
            wb_table3_52_362( false) ;
         }
         return  ;
      }

      protected void wb_table3_52_362e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table4_57_362( true) ;
         }
         else
         {
            wb_table4_57_362( false) ;
         }
         return  ;
      }

      protected void wb_table4_57_362e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, sPrefix+"W0063"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0063"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_9_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0063"+"");
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
         if ( wbEnd == 9 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( FsgridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"FsgridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Fsgrid", FsgridContainer, subFsgrid_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"FsgridContainerData", FsgridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"FsgridContainerData"+"V", FsgridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"FsgridContainerData"+"V"+"\" value='"+FsgridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START362( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GXKey = Crypto.GetSiteKey( );
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
               }
            }
            Form.Meta.addItem("description", context.GetMessage( "WWP_Dynamic Form Creation_Multiple Data Grid_WC", ""), 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP360( ) ;
            }
         }
      }

      protected void WS362( )
      {
         START362( ) ;
         EVT362( ) ;
      }

      protected void EVT362( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP360( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_BTNDELETEELEMENT.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP360( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Dvelop_confirmpanel_btndeleteelement.Close */
                                    E12362 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "SETTINGS_MODAL.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP360( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Settings_modal.Close */
                                    E13362 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "SETTINGS_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP360( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Settings_modal.Onloadcomponent */
                                    E14362 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ADDELEMENT_MODAL.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP360( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Addelement_modal.Close */
                                    E15362 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ADDELEMENT_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP360( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Addelement_modal.Onloadcomponent */
                                    E16362 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOREFRESHGRID'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP360( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoRefreshGrid' */
                                    E17362 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOMOVEUP'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP360( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoMoveUp' */
                                    E18362 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOMOVEDOWN'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP360( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoMoveDown' */
                                    E19362 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP360( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 11), "FSGRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP360( ) ;
                              }
                              nGXsfl_9_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
                              SubsflControlProps_92( ) ;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: Start */
                                          E20362 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: Refresh */
                                          E21362 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "FSGRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: Fsgrid.Load */
                                          E22362 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          if ( ! wbErr )
                                          {
                                             Rfr0gs = false;
                                             if ( ! Rfr0gs )
                                             {
                                             }
                                             dynload_actions( ) ;
                                          }
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP360( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                       }
                                    }
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
                           OldWwpaux_wc = cgiGet( sPrefix+"W0063");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess(sPrefix+"W0063", "", sEvt);
                           }
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                        else if ( nCmpId == 20 )
                        {
                           sEvtType = StringUtil.Left( sEvt, 4);
                           sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           sCmpCtrl = "W0020" + sEvtType;
                           OldDatawcchildren = cgiGet( sPrefix+sCmpCtrl);
                           if ( ( StringUtil.Len( OldDatawcchildren) == 0 ) || ( StringUtil.StrCmp(OldDatawcchildren, WebComp_GX_Process_Component) != 0 ) )
                           {
                              WebComp_GX_Process = getWebComponent(GetType(), "GeneXus.Programs", OldDatawcchildren, new Object[] {context} );
                              WebComp_GX_Process.ComponentInit();
                              WebComp_GX_Process.Name = "OldDatawcchildren";
                              WebComp_GX_Process_Component = OldDatawcchildren;
                           }
                           if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
                           {
                              WebComp_GX_Process.componentprocess(sPrefix+"W0020", sEvtType, sEvt);
                           }
                           nGXsfl_9_webc_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                           WebCompHandler = "Datawcchildren";
                           WebComp_GX_Process_Component = OldDatawcchildren;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE362( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm362( ) ;
            }
         }
      }

      protected void PA362( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Crypto.GetSiteKey( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
               {
                  GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.dynamicforms.wwp_dfc_multipledatagrid_wc.aspx")), "workwithplus.dynamicforms.wwp_dfc_multipledatagrid_wc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.dynamicforms.wwp_dfc_multipledatagrid_wc.aspx")))) ;
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
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  if ( nGotPars == 0 )
                  {
                     entryPointCalled = false;
                     gxfirstwebparm = GetFirstPar( "WWPDynamicFormMode");
                     toggleJsOutput = isJsOutputEnabled( );
                     if ( context.isSpaRequest( ) )
                     {
                        disableJsOutput();
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
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrFsgrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_92( ) ;
         while ( nGXsfl_9_idx <= nRC_GXsfl_9 )
         {
            sendrow_92( ) ;
            nGXsfl_9_idx = ((subFsgrid_Islastpage==1)&&(nGXsfl_9_idx+1>subFsgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_9_idx+1);
            sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
            SubsflControlProps_92( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( FsgridContainer)) ;
         /* End function gxnrFsgrid_newrow */
      }

      protected void gxgrFsgrid_refresh( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV19WWPForm ,
                                         short AV21WWPFormElementId ,
                                         WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ElementsRepeaterMetadata AV17WWP_DF_ElementsRepeaterMetadata ,
                                         bool AV9IsFirstElement ,
                                         bool AV10IsLastElement ,
                                         string AV18WWPDynamicFormMode ,
                                         short AV13SessionId ,
                                         GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV22WWPFormInstance ,
                                         bool AV11IsStep ,
                                         string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FSGRID_nCurrentRecord = 0;
         RF362( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrFsgrid_refresh */
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF362( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF362( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            FsgridContainer.ClearRows();
         }
         wbStart = 9;
         /* Execute user event: Refresh */
         E21362 ();
         nGXsfl_9_idx = 1;
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
         bGXsfl_9_Refreshing = true;
         FsgridContainer.AddObjectProperty("GridName", "Fsgrid");
         FsgridContainer.AddObjectProperty("SflColumns", subFsgrid_Columns);
         FsgridContainer.AddObjectProperty("CmpContext", sPrefix);
         FsgridContainer.AddObjectProperty("InMasterPage", "false");
         FsgridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         FsgridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(0), 4, 0, ".", "")));
         FsgridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(0), 4, 0, ".", "")));
         FsgridContainer.AddObjectProperty("Class", "FreeStyleGrid");
         FsgridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(0), 4, 0, ".", "")));
         FsgridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(0), 4, 0, ".", "")));
         FsgridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFsgrid_Backcolorstyle), 1, 0, ".", "")));
         FsgridContainer.PageSize = subFsgrid_fnc_Recordsperpage( );
         if ( subFsgrid_Islastpage != 0 )
         {
            FSGRID_nFirstRecordOnPage = (long)(subFsgrid_fnc_Recordcount( )-subFsgrid_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, sPrefix+"FSGRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(FSGRID_nFirstRecordOnPage), 15, 0, ".", "")));
            FsgridContainer.AddObjectProperty("FSGRID_nFirstRecordOnPage", FSGRID_nFirstRecordOnPage);
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
               {
                  WebComp_GX_Process.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
               {
                  WebComp_Datawcchildren.componentstart();
               }
            }
         }
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
            SubsflControlProps_92( ) ;
            /* Execute user event: Fsgrid.Load */
            E22362 ();
            wbEnd = 9;
            WB360( ) ;
         }
         bGXsfl_9_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes362( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_ELEMENTSREPEATERMETADATA", AV17WWP_DF_ElementsRepeaterMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_ELEMENTSREPEATERMETADATA", AV17WWP_DF_ElementsRepeaterMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_ELEMENTSREPEATERMETADATA", GetSecureSignedToken( sPrefix, AV17WWP_DF_ElementsRepeaterMetadata, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISFIRSTELEMENT", AV9IsFirstElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISFIRSTELEMENT", GetSecureSignedToken( sPrefix, AV9IsFirstElement, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISLASTELEMENT", AV10IsLastElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISLASTELEMENT", GetSecureSignedToken( sPrefix, AV10IsLastElement, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORMINSTANCE", AV22WWPFormInstance);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORMINSTANCE", AV22WWPFormInstance);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMINSTANCE", GetSecureSignedToken( sPrefix, AV22WWPFormInstance, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISSTEP", AV11IsStep);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISSTEP", GetSecureSignedToken( sPrefix, AV11IsStep, context));
      }

      protected int subFsgrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subFsgrid_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subFsgrid_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subFsgrid_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP360( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E20362 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_9 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_9"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV18WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV18WWPDynamicFormMode");
            wcpOAV21WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV21WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV13SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV13SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subFsgrid_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"subFsgrid_Recordcount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Dvelop_confirmpanel_btndeleteelement_Result = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_BTNDELETEELEMENT_Result");
            Settings_modal_Result = cgiGet( sPrefix+"SETTINGS_MODAL_Result");
            Addelement_modal_Result = cgiGet( sPrefix+"ADDELEMENT_MODAL_Result");
            /* Read variables values. */
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
         E20362 ();
         if (returnInSub) return;
      }

      protected void E20362( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtWWP_Form_Element1 = AV6CurrentElement;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getelementbyid(context ).execute( ref  AV19WWPForm,  AV21WWPFormElementId, out  GXt_SdtWWP_Form_Element1) ;
         AV6CurrentElement = GXt_SdtWWP_Form_Element1;
         AV17WWP_DF_ElementsRepeaterMetadata.FromJSonString(AV6CurrentElement.gxTpr_Wwpformelementmetadata, null);
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_dfc_canmoveelement(context ).execute(  AV19WWPForm,  AV6CurrentElement, out  AV9IsFirstElement, out  AV10IsLastElement) ;
         AssignAttri(sPrefix, false, "AV9IsFirstElement", AV9IsFirstElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISFIRSTELEMENT", GetSecureSignedToken( sPrefix, AV9IsFirstElement, context));
         AssignAttri(sPrefix, false, "AV10IsLastElement", AV10IsLastElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISLASTELEMENT", GetSecureSignedToken( sPrefix, AV10IsLastElement, context));
         Dvelop_confirmpanel_btndeleteelement_Confirmationtext = StringUtil.Format( context.GetMessage( "WWP_DF_ConfirmationDeleteContainer", ""), context.GetMessage( "WWP_DF_MultipleDataSection", ""), "", "", "", "", "", "", "", "");
         ucDvelop_confirmpanel_btndeleteelement.SendProperty(context, sPrefix, false, Dvelop_confirmpanel_btndeleteelement_Internalname, "ConfirmationText", Dvelop_confirmpanel_btndeleteelement_Confirmationtext);
         Btnmoveup_Caption = StringUtil.Format( context.GetMessage( "WWP_DF_MoveUpElement", ""), context.GetMessage( "WWP_DF_MultipleDataSection", ""), "", "", "", "", "", "", "", "");
         ucBtnmoveup.SendProperty(context, sPrefix, false, Btnmoveup_Internalname, "Caption", Btnmoveup_Caption);
         Btnmovedown_Caption = StringUtil.Format( context.GetMessage( "WWP_DF_MoveDownElement", ""), context.GetMessage( "WWP_DF_MultipleDataSection", ""), "", "", "", "", "", "", "", "");
         ucBtnmovedown.SendProperty(context, sPrefix, false, Btnmovedown_Internalname, "Caption", Btnmovedown_Caption);
         Btndeleteelement_Caption = StringUtil.Format( context.GetMessage( "WWP_DF_DeleteElement", ""), context.GetMessage( "WWP_DF_MultipleDataSection", ""), "", "", "", "", "", "", "", "");
         ucBtndeleteelement.SendProperty(context, sPrefix, false, Btndeleteelement_Internalname, "Caption", Btndeleteelement_Caption);
         if ( ! AV9IsFirstElement && ! AV10IsLastElement )
         {
            Btnsettings_Caption = StringUtil.Format( context.GetMessage( "WWP_DF_ElementSettings", ""), context.GetMessage( "WWP_DF_MultipleDataSection", ""), "", "", "", "", "", "", "", "");
            ucBtnsettings.SendProperty(context, sPrefix, false, Btnsettings_Internalname, "Caption", Btnsettings_Caption);
         }
         bttBtnaddchild_Caption = AV17WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildcaption;
         AssignProp(sPrefix, false, bttBtnaddchild_Internalname, "Caption", bttBtnaddchild_Caption, true);
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
      }

      protected void E21362( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S122 ();
         if (returnInSub) return;
         AV12MultipleDataElements = 0;
         AV25GXV1 = 1;
         while ( AV25GXV1 <= AV19WWPForm.gxTpr_Element.Count )
         {
            AV20WWPFormElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV19WWPForm.gxTpr_Element.Item(AV25GXV1));
            if ( AV20WWPFormElement.gxTpr_Wwpformelementparentid == AV21WWPFormElementId )
            {
               AV12MultipleDataElements = (short)(AV12MultipleDataElements+1);
            }
            AV25GXV1 = (int)(AV25GXV1+1);
         }
         if ( AV17WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype == 1 )
         {
            AV12MultipleDataElements = (short)(AV12MultipleDataElements+1);
         }
         subFsgrid_Columns = AV12MultipleDataElements;
         /*  Sending Event outputs  */
      }

      private void E22362( )
      {
         /* Fsgrid_Load Routine */
         returnInSub = false;
         AV14TitlesAreLoaded = false;
         divDatatablecell_Visible = 0;
         AssignProp(sPrefix, false, divDatatablecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDatatablecell_Visible), 5, 0), !bGXsfl_9_Refreshing);
         AV26GXV2 = 1;
         while ( AV26GXV2 <= AV19WWPForm.gxTpr_Element.Count )
         {
            AV20WWPFormElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV19WWPForm.gxTpr_Element.Item(AV26GXV2));
            if ( AV20WWPFormElement.gxTpr_Wwpformelementparentid == AV21WWPFormElementId )
            {
               lblTitletextblocktitle_Caption = AV20WWPFormElement.gxTpr_Wwpformelementtitle;
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 9;
               }
               sendrow_92( ) ;
               if ( isFullAjaxMode( ) && ! bGXsfl_9_Refreshing )
               {
                  DoAjaxLoad(9, FsgridRow);
               }
            }
            AV26GXV2 = (int)(AV26GXV2+1);
         }
         if ( AV17WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype == 1 )
         {
            lblTitletextblocktitle_Caption = "";
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 9;
            }
            sendrow_92( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_9_Refreshing )
            {
               DoAjaxLoad(9, FsgridRow);
            }
         }
         AV14TitlesAreLoaded = true;
         AV27GXV3 = 1;
         while ( AV27GXV3 <= AV19WWPForm.gxTpr_Element.Count )
         {
            AV20WWPFormElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV19WWPForm.gxTpr_Element.Item(AV27GXV3));
            if ( ( AV20WWPFormElement.gxTpr_Wwpformelementparentid == AV21WWPFormElementId ) && ( AV20WWPFormElement.gxTpr_Wwpformelementtype == 1 ) )
            {
               divTitletablecell_Visible = 0;
               AssignProp(sPrefix, false, divTitletablecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTitletablecell_Visible), 5, 0), !bGXsfl_9_Refreshing);
               divDatatablecell_Visible = 0;
               AssignProp(sPrefix, false, divDatatablecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDatatablecell_Visible), 5, 0), !bGXsfl_9_Refreshing);
               if ( AV14TitlesAreLoaded )
               {
                  divDatatablecell_Visible = 1;
                  AssignProp(sPrefix, false, divDatatablecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDatatablecell_Visible), 5, 0), !bGXsfl_9_Refreshing);
               }
               else
               {
                  divTitletablecell_Visible = 1;
                  AssignProp(sPrefix, false, divTitletablecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTitletablecell_Visible), 5, 0), !bGXsfl_9_Refreshing);
               }
               if ( AV20WWPFormElement.gxTpr_Wwpformelementdatatype == 1 )
               {
                  AV5WWP_DF_BooleanMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_BooleanMetadata(context);
                  AV5WWP_DF_BooleanMetadata.FromJSonString(AV20WWPFormElement.gxTpr_Wwpformelementmetadata, null);
                  if ( AV5WWP_DF_BooleanMetadata.gxTpr_Controltype == 1 )
                  {
                     /* Object Property */
                     if ( StringUtil.Len( sPrefix) == 0 )
                     {
                        bDynCreated_Datawcchildren = true;
                     }
                     if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_Checkbox_WC")) != 0 )
                     {
                        WebComp_Datawcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_checkbox_wc", new Object[] {context} );
                        WebComp_Datawcchildren.ComponentInit();
                        WebComp_Datawcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DFC_Checkbox_WC";
                        WebComp_Datawcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DFC_Checkbox_WC";
                     }
                     if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
                     {
                        WebComp_Datawcchildren.setjustcreated();
                        WebComp_Datawcchildren.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)sGXsfl_9_idx,(string)AV18WWPDynamicFormMode,AV20WWPFormElement.gxTpr_Wwpformelementid,(short)AV13SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV19WWPForm});
                        WebComp_Datawcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
                     }
                  }
                  else
                  {
                     /* Object Property */
                     if ( StringUtil.Len( sPrefix) == 0 )
                     {
                        bDynCreated_Datawcchildren = true;
                     }
                     if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_Switch_WC")) != 0 )
                     {
                        WebComp_Datawcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_switch_wc", new Object[] {context} );
                        WebComp_Datawcchildren.ComponentInit();
                        WebComp_Datawcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DFC_Switch_WC";
                        WebComp_Datawcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DFC_Switch_WC";
                     }
                     if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
                     {
                        WebComp_Datawcchildren.setjustcreated();
                        WebComp_Datawcchildren.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)sGXsfl_9_idx,(string)AV18WWPDynamicFormMode,AV20WWPFormElement.gxTpr_Wwpformelementid,(short)AV13SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV19WWPForm});
                        WebComp_Datawcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
                     }
                  }
               }
               else if ( AV20WWPFormElement.gxTpr_Wwpformelementdatatype == 4 )
               {
                  /* Object Property */
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     bDynCreated_Datawcchildren = true;
                  }
                  if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_Date_WC")) != 0 )
                  {
                     WebComp_Datawcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_date_wc", new Object[] {context} );
                     WebComp_Datawcchildren.ComponentInit();
                     WebComp_Datawcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DFC_Date_WC";
                     WebComp_Datawcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DFC_Date_WC";
                  }
                  if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
                  {
                     WebComp_Datawcchildren.setjustcreated();
                     WebComp_Datawcchildren.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)sGXsfl_9_idx,(string)AV18WWPDynamicFormMode,AV20WWPFormElement.gxTpr_Wwpformelementid,(short)AV13SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV19WWPForm});
                     WebComp_Datawcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
                  }
               }
               else if ( AV20WWPFormElement.gxTpr_Wwpformelementdatatype == 5 )
               {
                  /* Object Property */
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     bDynCreated_Datawcchildren = true;
                  }
                  if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_Datetime_WC")) != 0 )
                  {
                     WebComp_Datawcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_datetime_wc", new Object[] {context} );
                     WebComp_Datawcchildren.ComponentInit();
                     WebComp_Datawcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DFC_Datetime_WC";
                     WebComp_Datawcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DFC_Datetime_WC";
                  }
                  if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
                  {
                     WebComp_Datawcchildren.setjustcreated();
                     WebComp_Datawcchildren.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)sGXsfl_9_idx,(string)AV18WWPDynamicFormMode,AV20WWPFormElement.gxTpr_Wwpformelementid,(short)AV13SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV19WWPForm});
                     WebComp_Datawcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
                  }
               }
               else if ( AV20WWPFormElement.gxTpr_Wwpformelementdatatype == 2 )
               {
                  /* Object Property */
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     bDynCreated_Datawcchildren = true;
                  }
                  if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_Datetime_WC")) != 0 )
                  {
                     WebComp_Datawcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_datetime_wc", new Object[] {context} );
                     WebComp_Datawcchildren.ComponentInit();
                     WebComp_Datawcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DFC_Datetime_WC";
                     WebComp_Datawcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DFC_Datetime_WC";
                  }
                  if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
                  {
                     WebComp_Datawcchildren.setjustcreated();
                     WebComp_Datawcchildren.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)sGXsfl_9_idx,(string)AV18WWPDynamicFormMode,AV20WWPFormElement.gxTpr_Wwpformelementid,(short)AV13SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV19WWPForm});
                     WebComp_Datawcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
                  }
                  AV16WWP_DF_CharMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata(context);
                  AV16WWP_DF_CharMetadata.FromJSonString(AV20WWPFormElement.gxTpr_Wwpformelementmetadata, null);
                  if ( AV16WWP_DF_CharMetadata.gxTpr_Controltype == 2 )
                  {
                     /* Object Property */
                     if ( StringUtil.Len( sPrefix) == 0 )
                     {
                        bDynCreated_Datawcchildren = true;
                     }
                     if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_TextArea_WC")) != 0 )
                     {
                        WebComp_Datawcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_textarea_wc", new Object[] {context} );
                        WebComp_Datawcchildren.ComponentInit();
                        WebComp_Datawcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DFC_TextArea_WC";
                        WebComp_Datawcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DFC_TextArea_WC";
                     }
                     if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
                     {
                        WebComp_Datawcchildren.setjustcreated();
                        WebComp_Datawcchildren.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)sGXsfl_9_idx,(string)AV18WWPDynamicFormMode,AV20WWPFormElement.gxTpr_Wwpformelementid,(short)AV13SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV19WWPForm});
                        WebComp_Datawcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
                     }
                  }
                  else if ( AV16WWP_DF_CharMetadata.gxTpr_Controltype == 3 )
                  {
                     /* Object Property */
                     if ( StringUtil.Len( sPrefix) == 0 )
                     {
                        bDynCreated_Datawcchildren = true;
                     }
                     if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_HTMLEditor_WC")) != 0 )
                     {
                        WebComp_Datawcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_htmleditor_wc", new Object[] {context} );
                        WebComp_Datawcchildren.ComponentInit();
                        WebComp_Datawcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DFC_HTMLEditor_WC";
                        WebComp_Datawcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DFC_HTMLEditor_WC";
                     }
                     if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
                     {
                        WebComp_Datawcchildren.setjustcreated();
                        WebComp_Datawcchildren.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)sGXsfl_9_idx,(string)AV18WWPDynamicFormMode,AV20WWPFormElement.gxTpr_Wwpformelementid,(short)AV13SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV19WWPForm});
                        WebComp_Datawcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
                     }
                  }
                  else if ( ( AV16WWP_DF_CharMetadata.gxTpr_Controltype == 4 ) && ( AV16WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Controltype != 2 ) )
                  {
                     if ( AV16WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Controltype == 1 )
                     {
                        /* Object Property */
                        if ( StringUtil.Len( sPrefix) == 0 )
                        {
                           bDynCreated_Datawcchildren = true;
                        }
                        if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_ComboBox_WC")) != 0 )
                        {
                           WebComp_Datawcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_combobox_wc", new Object[] {context} );
                           WebComp_Datawcchildren.ComponentInit();
                           WebComp_Datawcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DFC_ComboBox_WC";
                           WebComp_Datawcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DFC_ComboBox_WC";
                        }
                        if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
                        {
                           WebComp_Datawcchildren.setjustcreated();
                           WebComp_Datawcchildren.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)sGXsfl_9_idx,(string)AV18WWPDynamicFormMode,AV20WWPFormElement.gxTpr_Wwpformelementid,(short)AV13SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV19WWPForm});
                           WebComp_Datawcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
                        }
                     }
                     else if ( AV16WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Controltype == 3 )
                     {
                        /* Object Property */
                        if ( StringUtil.Len( sPrefix) == 0 )
                        {
                           bDynCreated_Datawcchildren = true;
                        }
                        if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_Radiobutton_WC")) != 0 )
                        {
                           WebComp_Datawcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_radiobutton_wc", new Object[] {context} );
                           WebComp_Datawcchildren.ComponentInit();
                           WebComp_Datawcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DFC_Radiobutton_WC";
                           WebComp_Datawcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DFC_Radiobutton_WC";
                        }
                        if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
                        {
                           WebComp_Datawcchildren.setjustcreated();
                           WebComp_Datawcchildren.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)sGXsfl_9_idx,(string)AV18WWPDynamicFormMode,AV20WWPFormElement.gxTpr_Wwpformelementid,(short)AV13SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV19WWPForm});
                           WebComp_Datawcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
                        }
                     }
                     else if ( AV16WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Controltype == 4 )
                     {
                        /* Object Property */
                        if ( StringUtil.Len( sPrefix) == 0 )
                        {
                           bDynCreated_Datawcchildren = true;
                        }
                        if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_MCheckBox_WC")) != 0 )
                        {
                           WebComp_Datawcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_mcheckbox_wc", new Object[] {context} );
                           WebComp_Datawcchildren.ComponentInit();
                           WebComp_Datawcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DFC_MCheckBox_WC";
                           WebComp_Datawcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DFC_MCheckBox_WC";
                        }
                        if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
                        {
                           WebComp_Datawcchildren.setjustcreated();
                           WebComp_Datawcchildren.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)sGXsfl_9_idx,(string)AV18WWPDynamicFormMode,AV20WWPFormElement.gxTpr_Wwpformelementid,(short)AV13SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV19WWPForm});
                           WebComp_Datawcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
                        }
                     }
                  }
                  else
                  {
                     /* Object Property */
                     if ( StringUtil.Len( sPrefix) == 0 )
                     {
                        bDynCreated_Datawcchildren = true;
                     }
                     if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_Text_WC")) != 0 )
                     {
                        WebComp_Datawcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_text_wc", new Object[] {context} );
                        WebComp_Datawcchildren.ComponentInit();
                        WebComp_Datawcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DFC_Text_WC";
                        WebComp_Datawcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DFC_Text_WC";
                     }
                     if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
                     {
                        WebComp_Datawcchildren.setjustcreated();
                        WebComp_Datawcchildren.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)sGXsfl_9_idx,(string)AV18WWPDynamicFormMode,AV20WWPFormElement.gxTpr_Wwpformelementid,(short)AV13SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV19WWPForm});
                        WebComp_Datawcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
                     }
                  }
               }
               else if ( ( AV20WWPFormElement.gxTpr_Wwpformelementdatatype == 10 ) || ( AV20WWPFormElement.gxTpr_Wwpformelementdatatype == 9 ) )
               {
                  /* Object Property */
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     bDynCreated_Datawcchildren = true;
                  }
                  if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_File_WC")) != 0 )
                  {
                     WebComp_Datawcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_file_wc", new Object[] {context} );
                     WebComp_Datawcchildren.ComponentInit();
                     WebComp_Datawcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DFC_File_WC";
                     WebComp_Datawcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DFC_File_WC";
                  }
                  if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
                  {
                     WebComp_Datawcchildren.setjustcreated();
                     WebComp_Datawcchildren.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)sGXsfl_9_idx,(string)AV18WWPDynamicFormMode,AV20WWPFormElement.gxTpr_Wwpformelementid,(short)AV13SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV19WWPForm});
                     WebComp_Datawcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
                  }
               }
               else
               {
                  /* Object Property */
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     bDynCreated_Datawcchildren = true;
                  }
                  if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_Text_WC")) != 0 )
                  {
                     WebComp_Datawcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_text_wc", new Object[] {context} );
                     WebComp_Datawcchildren.ComponentInit();
                     WebComp_Datawcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DFC_Text_WC";
                     WebComp_Datawcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DFC_Text_WC";
                  }
                  if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
                  {
                     WebComp_Datawcchildren.setjustcreated();
                     WebComp_Datawcchildren.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)sGXsfl_9_idx,(string)AV18WWPDynamicFormMode,AV20WWPFormElement.gxTpr_Wwpformelementid,(short)AV13SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV19WWPForm});
                     WebComp_Datawcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
                  }
               }
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 9;
               }
               sendrow_92( ) ;
               if ( isFullAjaxMode( ) && ! bGXsfl_9_Refreshing )
               {
                  DoAjaxLoad(9, FsgridRow);
               }
            }
            AV27GXV3 = (int)(AV27GXV3+1);
         }
         if ( AV17WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype == 1 )
         {
            /* Object Property */
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               bDynCreated_Datawcchildren = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_MDataGrid_Remove_WC")) != 0 )
            {
               WebComp_Datawcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_mdatagrid_remove_wc", new Object[] {context} );
               WebComp_Datawcchildren.ComponentInit();
               WebComp_Datawcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_MDataGrid_Remove_WC";
               WebComp_Datawcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_MDataGrid_Remove_WC";
            }
            if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
            {
               WebComp_Datawcchildren.setjustcreated();
               WebComp_Datawcchildren.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)sGXsfl_9_idx,(short)0,(short)0,(short)0,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV22WWPFormInstance});
               WebComp_Datawcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 9;
            }
            sendrow_92( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_9_Refreshing )
            {
               DoAjaxLoad(9, FsgridRow);
            }
         }
         /*  Sending Event outputs  */
      }

      protected void E17362( )
      {
         /* 'DoRefreshGrid' Routine */
         returnInSub = false;
         GXt_SdtWWP_Form2 = AV19WWPForm;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadformdefinition(context ).execute(  AV13SessionId, out  GXt_SdtWWP_Form2) ;
         AV19WWPForm = GXt_SdtWWP_Form2;
         gxgrFsgrid_refresh( AV19WWPForm, AV21WWPFormElementId, AV17WWP_DF_ElementsRepeaterMetadata, AV9IsFirstElement, AV10IsLastElement, AV18WWPDynamicFormMode, AV13SessionId, AV22WWPFormInstance, AV11IsStep, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV19WWPForm", AV19WWPForm);
      }

      protected void E18362( )
      {
         /* 'DoMoveUp' Routine */
         returnInSub = false;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_dfc_moveelement(context ).execute(  AV13SessionId,  AV21WWPFormElementId,  true) ;
         this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "DynamicForms_RefreshParentGrid", new Object[] {(string)divLayoutmaintable_Internalname,(string)"LayoutMainTable"}, false);
      }

      protected void E19362( )
      {
         /* 'DoMoveDown' Routine */
         returnInSub = false;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_dfc_moveelement(context ).execute(  AV13SessionId,  AV21WWPFormElementId,  false) ;
         this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "DynamicForms_RefreshParentGrid", new Object[] {(string)divLayoutmaintable_Internalname,(string)"LayoutMainTable"}, false);
      }

      protected void E12362( )
      {
         /* Dvelop_confirmpanel_btndeleteelement_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_btndeleteelement_Result, "Yes") == 0 )
         {
            GXt_SdtWWP_Form2 = AV19WWPForm;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadformdefinition(context ).execute(  AV13SessionId, out  GXt_SdtWWP_Form2) ;
            AV19WWPForm = GXt_SdtWWP_Form2;
            GXt_SdtWWP_Form_Element1 = AV6CurrentElement;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getelementbyid(context ).execute( ref  AV19WWPForm,  AV21WWPFormElementId, out  GXt_SdtWWP_Form_Element1) ;
            AV6CurrentElement = GXt_SdtWWP_Form_Element1;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_dfc_deleteelement(context ).execute( ref  AV19WWPForm, ref  AV6CurrentElement) ;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_saveformdefinition(context ).execute(  AV13SessionId,  AV19WWPForm) ;
            this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "DynamicForms_RefreshParentGrid", new Object[] {(string)divLayoutmaintable_Internalname,(string)"LayoutMainTable"}, false);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV19WWPForm", AV19WWPForm);
      }

      protected void E14362( )
      {
         /* Settings_modal_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "UAddElement")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "uaddelement", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "UAddElement";
            WebComp_Wwpaux_wc_Component = "UAddElement";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)sPrefix+"W0063",(string)"",(string)"UPD",(short)0,(short)AV21WWPFormElementId,(short)AV13SessionId});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0063"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E16362( )
      {
         /* Addelement_modal_Onloadcomponent Routine */
         returnInSub = false;
         Addelement_modal_Title = context.GetMessage( "Add element", "");
         ucAddelement_modal.SendProperty(context, sPrefix, false, Addelement_modal_Internalname, "Title", Addelement_modal_Title);
         /* Object Property */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_AddElement")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_addelement", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WorkWithPlus.DynamicForms.WWP_DF_AddElement";
            WebComp_Wwpaux_wc_Component = "WorkWithPlus.DynamicForms.WWP_DF_AddElement";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)sPrefix+"W0063",(string)"",(string)"INS",(short)AV21WWPFormElementId,(short)0,(short)AV13SessionId});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0063"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( AV17WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype == 1 ) ) )
         {
            bttBtnaddchild_Visible = 0;
            AssignProp(sPrefix, false, bttBtnaddchild_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnaddchild_Visible), 5, 0), true);
         }
         if ( ! ( ! AV9IsFirstElement ) )
         {
            Btnmoveup_Visible = false;
            ucBtnmoveup.SendProperty(context, sPrefix, false, Btnmoveup_Internalname, "Visible", StringUtil.BoolToStr( Btnmoveup_Visible));
         }
         if ( ! ( ! AV10IsLastElement ) )
         {
            Btnmovedown_Visible = false;
            ucBtnmovedown.SendProperty(context, sPrefix, false, Btnmovedown_Internalname, "Visible", StringUtil.BoolToStr( Btnmovedown_Visible));
         }
         if ( ! ( ! (0==AV21WWPFormElementId) ) )
         {
            Btnsettings_Visible = false;
            ucBtnsettings.SendProperty(context, sPrefix, false, Btnsettings_Internalname, "Visible", StringUtil.BoolToStr( Btnsettings_Visible));
         }
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         tblUnnamedtable2_Visible = (((StringUtil.StrCmp(AV18WWPDynamicFormMode, "DSP")!=0)) ? 1 : 0);
         AssignProp(sPrefix, false, tblUnnamedtable2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblUnnamedtable2_Visible), 5, 0), true);
      }

      protected void E13362( )
      {
         /* Settings_modal_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Settings_modal_Result, "OK") == 0 )
         {
            if ( AV11IsStep )
            {
               GXt_SdtWWP_Form2 = AV19WWPForm;
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadformdefinition(context ).execute(  AV13SessionId, out  GXt_SdtWWP_Form2) ;
               AV19WWPForm = GXt_SdtWWP_Form2;
               AV7CurrentStepIndex = 0;
               AV28GXV4 = 1;
               while ( AV28GXV4 <= AV19WWPForm.gxTpr_Element.Count )
               {
                  AV8Element = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV19WWPForm.gxTpr_Element.Item(AV28GXV4));
                  if ( AV8Element.gxTpr_Wwpformelementtype == 5 )
                  {
                     AV7CurrentStepIndex = (short)(AV7CurrentStepIndex+1);
                     if ( AV8Element.gxTpr_Wwpformelementid == AV21WWPFormElementId )
                     {
                        if (true) break;
                     }
                  }
                  AV28GXV4 = (int)(AV28GXV4+1);
               }
               AV15WebSession.Set("WWPDynFormCreation_DefaultStep", StringUtil.Trim( StringUtil.Str( (decimal)(AV7CurrentStepIndex), 4, 0)));
            }
            this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "DynamicForms_RefreshParentGrid", new Object[] {(string)divLayoutmaintable_Internalname,(string)"LayoutMainTable"}, false);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV19WWPForm", AV19WWPForm);
      }

      protected void E15362( )
      {
         /* Addelement_modal_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Addelement_modal_Result, "OK") == 0 )
         {
            GXt_SdtWWP_Form2 = AV19WWPForm;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadformdefinition(context ).execute(  AV13SessionId, out  GXt_SdtWWP_Form2) ;
            AV19WWPForm = GXt_SdtWWP_Form2;
            gxgrFsgrid_refresh( AV19WWPForm, AV21WWPFormElementId, AV17WWP_DF_ElementsRepeaterMetadata, AV9IsFirstElement, AV10IsLastElement, AV18WWPDynamicFormMode, AV13SessionId, AV22WWPFormInstance, AV11IsStep, sPrefix) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV19WWPForm", AV19WWPForm);
      }

      protected void wb_table4_57_362( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTableaddelement_modal_Internalname, tblTableaddelement_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucAddelement_modal.SetProperty("Width", Addelement_modal_Width);
            ucAddelement_modal.SetProperty("Title", Addelement_modal_Title);
            ucAddelement_modal.SetProperty("ConfirmType", Addelement_modal_Confirmtype);
            ucAddelement_modal.SetProperty("BodyType", Addelement_modal_Bodytype);
            ucAddelement_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Addelement_modal_Internalname, sPrefix+"ADDELEMENT_MODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"ADDELEMENT_MODALContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_57_362e( true) ;
         }
         else
         {
            wb_table4_57_362e( false) ;
         }
      }

      protected void wb_table3_52_362( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablesettings_modal_Internalname, tblTablesettings_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucSettings_modal.SetProperty("Width", Settings_modal_Width);
            ucSettings_modal.SetProperty("Title", Settings_modal_Title);
            ucSettings_modal.SetProperty("ConfirmType", Settings_modal_Confirmtype);
            ucSettings_modal.SetProperty("BodyType", Settings_modal_Bodytype);
            ucSettings_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Settings_modal_Internalname, sPrefix+"SETTINGS_MODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"SETTINGS_MODALContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_52_362e( true) ;
         }
         else
         {
            wb_table3_52_362e( false) ;
         }
      }

      protected void wb_table2_47_362( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_btndeleteelement_Internalname, tblTabledvelop_confirmpanel_btndeleteelement_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_btndeleteelement.SetProperty("Title", Dvelop_confirmpanel_btndeleteelement_Title);
            ucDvelop_confirmpanel_btndeleteelement.SetProperty("ConfirmationText", Dvelop_confirmpanel_btndeleteelement_Confirmationtext);
            ucDvelop_confirmpanel_btndeleteelement.SetProperty("YesButtonCaption", Dvelop_confirmpanel_btndeleteelement_Yesbuttoncaption);
            ucDvelop_confirmpanel_btndeleteelement.SetProperty("NoButtonCaption", Dvelop_confirmpanel_btndeleteelement_Nobuttoncaption);
            ucDvelop_confirmpanel_btndeleteelement.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_btndeleteelement_Cancelbuttoncaption);
            ucDvelop_confirmpanel_btndeleteelement.SetProperty("YesButtonPosition", Dvelop_confirmpanel_btndeleteelement_Yesbuttonposition);
            ucDvelop_confirmpanel_btndeleteelement.SetProperty("ConfirmType", Dvelop_confirmpanel_btndeleteelement_Confirmtype);
            ucDvelop_confirmpanel_btndeleteelement.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_btndeleteelement_Internalname, sPrefix+"DVELOP_CONFIRMPANEL_BTNDELETEELEMENTContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVELOP_CONFIRMPANEL_BTNDELETEELEMENTContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_47_362e( true) ;
         }
         else
         {
            wb_table2_47_362e( false) ;
         }
      }

      protected void wb_table1_29_362( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblUnnamedtable2_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblUnnamedtable2_Internalname, tblUnnamedtable2_Internalname, "", "TableDynAddElementActions", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucBtnmoveup.SetProperty("TooltipText", Btnmoveup_Tooltiptext);
            ucBtnmoveup.SetProperty("BeforeIconClass", Btnmoveup_Beforeiconclass);
            ucBtnmoveup.SetProperty("Caption", Btnmoveup_Caption);
            ucBtnmoveup.SetProperty("Class", Btnmoveup_Class);
            ucBtnmoveup.Render(context, "wwp_iconbutton", Btnmoveup_Internalname, sPrefix+"BTNMOVEUPContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucBtnmovedown.SetProperty("TooltipText", Btnmovedown_Tooltiptext);
            ucBtnmovedown.SetProperty("BeforeIconClass", Btnmovedown_Beforeiconclass);
            ucBtnmovedown.SetProperty("Caption", Btnmovedown_Caption);
            ucBtnmovedown.SetProperty("Class", Btnmovedown_Class);
            ucBtnmovedown.Render(context, "wwp_iconbutton", Btnmovedown_Internalname, sPrefix+"BTNMOVEDOWNContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucBtndeleteelement.SetProperty("TooltipText", Btndeleteelement_Tooltiptext);
            ucBtndeleteelement.SetProperty("BeforeIconClass", Btndeleteelement_Beforeiconclass);
            ucBtndeleteelement.SetProperty("Caption", Btndeleteelement_Caption);
            ucBtndeleteelement.SetProperty("Class", Btndeleteelement_Class);
            ucBtndeleteelement.Render(context, "wwp_iconbutton", Btndeleteelement_Internalname, sPrefix+"BTNDELETEELEMENTContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucBtnsettings.SetProperty("TooltipText", Btnsettings_Tooltiptext);
            ucBtnsettings.SetProperty("BeforeIconClass", Btnsettings_Beforeiconclass);
            ucBtnsettings.SetProperty("Caption", Btnsettings_Caption);
            ucBtnsettings.SetProperty("Class", Btnsettings_Class);
            ucBtnsettings.Render(context, "wwp_iconbutton", Btnsettings_Internalname, sPrefix+"BTNSETTINGSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucBtnaddelement.SetProperty("TooltipText", Btnaddelement_Tooltiptext);
            ucBtnaddelement.SetProperty("BeforeIconClass", Btnaddelement_Beforeiconclass);
            ucBtnaddelement.SetProperty("Caption", Btnaddelement_Caption);
            ucBtnaddelement.SetProperty("Class", Btnaddelement_Class);
            ucBtnaddelement.Render(context, "wwp_iconbutton", Btnaddelement_Internalname, sPrefix+"BTNADDELEMENTContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_29_362e( true) ;
         }
         else
         {
            wb_table1_29_362e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV18WWPDynamicFormMode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV18WWPDynamicFormMode", AV18WWPDynamicFormMode);
         AV21WWPFormElementId = Convert.ToInt16(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV21WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV21WWPFormElementId), 4, 0));
         AV13SessionId = Convert.ToInt16(getParm(obj,2));
         AssignAttri(sPrefix, false, "AV13SessionId", StringUtil.LTrimStr( (decimal)(AV13SessionId), 4, 0));
         AV19WWPForm = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)getParm(obj,3);
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
         PA362( ) ;
         WS362( ) ;
         WE362( ) ;
         cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected override EncryptionType GetEncryptionType( )
      {
         return EncryptionType.SITE ;
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlAV18WWPDynamicFormMode = (string)((string)getParm(obj,0));
         sCtrlAV21WWPFormElementId = (string)((string)getParm(obj,1));
         sCtrlAV13SessionId = (string)((string)getParm(obj,2));
         sCtrlAV19WWPForm = (string)((string)getParm(obj,3));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA362( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "workwithplus\\dynamicforms\\wwp_dfc_multipledatagrid_wc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA362( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV18WWPDynamicFormMode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV18WWPDynamicFormMode", AV18WWPDynamicFormMode);
            AV21WWPFormElementId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV21WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV21WWPFormElementId), 4, 0));
            AV13SessionId = Convert.ToInt16(getParm(obj,4));
            AssignAttri(sPrefix, false, "AV13SessionId", StringUtil.LTrimStr( (decimal)(AV13SessionId), 4, 0));
            AV19WWPForm = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)getParm(obj,5);
         }
         wcpOAV18WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV18WWPDynamicFormMode");
         wcpOAV21WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV21WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV13SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV13SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV18WWPDynamicFormMode, wcpOAV18WWPDynamicFormMode) != 0 ) || ( AV21WWPFormElementId != wcpOAV21WWPFormElementId ) || ( AV13SessionId != wcpOAV13SessionId ) ) )
         {
            setjustcreated();
         }
         wcpOAV18WWPDynamicFormMode = AV18WWPDynamicFormMode;
         wcpOAV21WWPFormElementId = AV21WWPFormElementId;
         wcpOAV13SessionId = AV13SessionId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV18WWPDynamicFormMode = cgiGet( sPrefix+"AV18WWPDynamicFormMode_CTRL");
         if ( StringUtil.Len( sCtrlAV18WWPDynamicFormMode) > 0 )
         {
            AV18WWPDynamicFormMode = cgiGet( sCtrlAV18WWPDynamicFormMode);
            AssignAttri(sPrefix, false, "AV18WWPDynamicFormMode", AV18WWPDynamicFormMode);
         }
         else
         {
            AV18WWPDynamicFormMode = cgiGet( sPrefix+"AV18WWPDynamicFormMode_PARM");
         }
         sCtrlAV21WWPFormElementId = cgiGet( sPrefix+"AV21WWPFormElementId_CTRL");
         if ( StringUtil.Len( sCtrlAV21WWPFormElementId) > 0 )
         {
            AV21WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV21WWPFormElementId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV21WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV21WWPFormElementId), 4, 0));
         }
         else
         {
            AV21WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV21WWPFormElementId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV13SessionId = cgiGet( sPrefix+"AV13SessionId_CTRL");
         if ( StringUtil.Len( sCtrlAV13SessionId) > 0 )
         {
            AV13SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV13SessionId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV13SessionId", StringUtil.LTrimStr( (decimal)(AV13SessionId), 4, 0));
         }
         else
         {
            AV13SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV13SessionId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV19WWPForm = cgiGet( sPrefix+"AV19WWPForm_CTRL");
         if ( StringUtil.Len( sCtrlAV19WWPForm) > 0 )
         {
            AV19WWPForm.FromXml(cgiGet( sCtrlAV19WWPForm), null, "", "");
         }
         else
         {
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"AV19WWPForm_PARM"), AV19WWPForm);
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA362( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS362( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS362( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV18WWPDynamicFormMode_PARM", StringUtil.RTrim( AV18WWPDynamicFormMode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV18WWPDynamicFormMode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV18WWPDynamicFormMode_CTRL", StringUtil.RTrim( sCtrlAV18WWPDynamicFormMode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV21WWPFormElementId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV21WWPFormElementId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV21WWPFormElementId_CTRL", StringUtil.RTrim( sCtrlAV21WWPFormElementId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV13SessionId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV13SessionId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV13SessionId_CTRL", StringUtil.RTrim( sCtrlAV13SessionId));
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"AV19WWPForm_PARM", AV19WWPForm);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"AV19WWPForm_PARM", AV19WWPForm);
         }
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV19WWPForm)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV19WWPForm_CTRL", StringUtil.RTrim( sCtrlAV19WWPForm));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE362( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
         if ( ! ( WebComp_GX_Process == null ) )
         {
            WebComp_GX_Process.componentjscripts();
         }
         if ( ! ( WebComp_Datawcchildren == null ) )
         {
            WebComp_Datawcchildren.componentjscripts();
         }
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
         }
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Datawcchildren == null ) )
         {
            if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
            {
               WebComp_Datawcchildren.componentthemes();
            }
         }
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20257212434331", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("workwithplus/dynamicforms/wwp_dfc_multipledatagrid_wc.js", "?20257212434331", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_92( )
      {
         lblTitletextblocktitle_Internalname = sPrefix+"TITLETEXTBLOCKTITLE_"+sGXsfl_9_idx;
      }

      protected void SubsflControlProps_fel_92( )
      {
         lblTitletextblocktitle_Internalname = sPrefix+"TITLETEXTBLOCKTITLE_"+sGXsfl_9_fel_idx;
      }

      protected void sendrow_92( )
      {
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
         WB360( ) ;
         FsgridRow = GXWebRow.GetNew(context,FsgridContainer);
         if ( subFsgrid_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subFsgrid_Backstyle = 0;
            if ( StringUtil.StrCmp(subFsgrid_Class, "") != 0 )
            {
               subFsgrid_Linesclass = subFsgrid_Class+"Odd";
            }
         }
         else if ( subFsgrid_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subFsgrid_Backstyle = 0;
            subFsgrid_Backcolor = subFsgrid_Allbackcolor;
            if ( StringUtil.StrCmp(subFsgrid_Class, "") != 0 )
            {
               subFsgrid_Linesclass = subFsgrid_Class+"Uniform";
            }
         }
         else if ( subFsgrid_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subFsgrid_Backstyle = 1;
            if ( StringUtil.StrCmp(subFsgrid_Class, "") != 0 )
            {
               subFsgrid_Linesclass = subFsgrid_Class+"Odd";
            }
            subFsgrid_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subFsgrid_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subFsgrid_Backstyle = 1;
            if ( subFsgrid_Columns <= 0 )
            {
               subFsgrid_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subFsgrid_Class, "") != 0 )
               {
                  subFsgrid_Linesclass = subFsgrid_Class+"Odd";
               }
            }
            else if ( subFsgrid_Columns == 1 )
            {
               if ( ((int)((nGXsfl_9_idx) % (2))) == 0 )
               {
                  subFsgrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subFsgrid_Class, "") != 0 )
                  {
                     subFsgrid_Linesclass = subFsgrid_Class+"Even";
                  }
               }
               else
               {
                  subFsgrid_Backcolor = (int)(0xFFFFFF);
                  if ( StringUtil.StrCmp(subFsgrid_Class, "") != 0 )
                  {
                     subFsgrid_Linesclass = subFsgrid_Class+"Odd";
                  }
               }
            }
            else
            {
               if ( ((int)(((nGXsfl_9_idx-1)/ (decimal)(subFsgrid_Columns)) % (2))) == 0 )
               {
                  subFsgrid_Backcolor = (int)(0xFFFFFF);
                  if ( StringUtil.StrCmp(subFsgrid_Class, "") != 0 )
                  {
                     subFsgrid_Linesclass = subFsgrid_Class+"Odd";
                  }
               }
               else
               {
                  subFsgrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subFsgrid_Class, "") != 0 )
                  {
                     subFsgrid_Linesclass = subFsgrid_Class+"Even";
                  }
               }
            }
         }
         /* Start of Columns property logic. */
         if ( FsgridContainer.GetWrapped() == 1 )
         {
            if ( ( subFsgrid_Columns == 0 ) && ( nGXsfl_9_idx == 1 ) )
            {
               context.WriteHtmlText( "<tr"+" class=\""+subFsgrid_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_9_idx+"\">") ;
            }
            if ( subFsgrid_Columns > 0 )
            {
               if ( ( subFsgrid_Columns == 1 ) || ( ((int)((nGXsfl_9_idx) % (subFsgrid_Columns))) - 1 == 0 ) )
               {
                  context.WriteHtmlText( "<tr"+" class=\""+subFsgrid_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_9_idx+"\">") ;
               }
            }
         }
         FsgridRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)subFsgrid_Linesclass,(string)""});
         FsgridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         FsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divFsgridlayouttable_Internalname+"_"+sGXsfl_9_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"start",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"",(string)"div"});
         /* Div Control */
         FsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTitletablecell_Internalname+"_"+sGXsfl_9_idx,(int)divTitletablecell_Visible,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* Div Control */
         FsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTitletable_Internalname+"_"+sGXsfl_9_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"start",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"",(string)"div"});
         /* Div Control */
         FsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* Text block */
         FsgridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblTitletextblocktitle_Internalname,(string)lblTitletextblocktitle_Caption,(string)"",(string)"",(string)lblTitletextblocktitle_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"DynFormDataDescription",(short)0,(string)"",(short)1,(short)1,(short)0,(short)0});
         FsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         FsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divDatatablecell_Internalname+"_"+sGXsfl_9_idx,(int)divDatatablecell_Visible,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* Div Control */
         FsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divDatatable_Internalname+"_"+sGXsfl_9_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"start",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"",(string)"div"});
         /* Div Control */
         FsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* WebComponent */
         GxWebStd.gx_hidden_field( context, sPrefix+"W0020"+sGXsfl_9_idx, StringUtil.RTrim( WebComp_Datawcchildren_Component));
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gxwebcomponent"+" gxwebcomponent-loading");
         context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0020"+sGXsfl_9_idx+"\""+"") ;
         context.WriteHtmlText( ">") ;
         if ( bGXsfl_9_Refreshing )
         {
            if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
            {
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StringSearch( sPrefix+"W0020"+sGXsfl_9_idx, cgiGet( "_EventName"), 1) != 0 ) )
               {
                  if ( 1 != 0 )
                  {
                     if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
                     {
                        WebComp_Datawcchildren.componentstart();
                     }
                  }
               }
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldDatawcchildren), StringUtil.Lower( WebComp_Datawcchildren_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0020"+sGXsfl_9_idx);
               }
               WebComp_Datawcchildren.componentdraw();
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldDatawcchildren), StringUtil.Lower( WebComp_Datawcchildren_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
         }
         context.WriteHtmlText( "</div>") ;
         WebComp_Datawcchildren_Component = "";
         WebComp_Datawcchildren.componentjscripts();
         FsgridRow.AddColumnProperties("webcomp", -1, isAjaxCallMode( ), new Object[] {(string)"Datawcchildren"});
         FsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         if ( FsgridContainer.GetWrapped() == 1 )
         {
            FsgridContainer.CloseTag("cell");
         }
         if ( FsgridContainer.GetWrapped() == 1 )
         {
            FsgridContainer.CloseTag("row");
         }
         send_integrity_lvl_hashes362( ) ;
         /* End of Columns property logic. */
         if ( FsgridContainer.GetWrapped() == 1 )
         {
            if ( subFsgrid_Columns > 0 )
            {
               if ( ((int)((nGXsfl_9_idx) % (subFsgrid_Columns))) == 0 )
               {
                  context.WriteHtmlTextNl( "</tr>") ;
               }
            }
         }
         FsgridContainer.AddRow(FsgridRow);
         nGXsfl_9_idx = ((subFsgrid_Islastpage==1)&&(nGXsfl_9_idx+1>subFsgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_9_idx+1);
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
         /* End function sendrow_92 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl9( )
      {
         if ( FsgridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"FsgridContainer"+"DivS\" data-gxgridid=\"9\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subFsgrid_Internalname, subFsgrid_Internalname, "", "FreeStyleGrid", 0, "", "", 0, 0, sStyleString, "", "", 0);
            FsgridContainer.AddObjectProperty("GridName", "Fsgrid");
         }
         else
         {
            FsgridContainer.AddObjectProperty("GridName", "Fsgrid");
            FsgridContainer.AddObjectProperty("Header", subFsgrid_Header);
            FsgridContainer.AddObjectProperty("SflColumns", subFsgrid_Columns);
            FsgridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            FsgridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(0), 4, 0, ".", "")));
            FsgridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(0), 4, 0, ".", "")));
            FsgridContainer.AddObjectProperty("Class", "FreeStyleGrid");
            FsgridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(0), 4, 0, ".", "")));
            FsgridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(0), 4, 0, ".", "")));
            FsgridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFsgrid_Backcolorstyle), 1, 0, ".", "")));
            FsgridContainer.AddObjectProperty("CmpContext", sPrefix);
            FsgridContainer.AddObjectProperty("InMasterPage", "false");
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridColumn.AddObjectProperty("Value", lblTitletextblocktitle_Caption);
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFsgrid_Selectedindex), 4, 0, ".", "")));
            FsgridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFsgrid_Allowselection), 1, 0, ".", "")));
            FsgridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFsgrid_Selectioncolor), 9, 0, ".", "")));
            FsgridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFsgrid_Allowhovering), 1, 0, ".", "")));
            FsgridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFsgrid_Hoveringcolor), 9, 0, ".", "")));
            FsgridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFsgrid_Allowcollapsing), 1, 0, ".", "")));
            FsgridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFsgrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblTitletextblocktitle_Internalname = sPrefix+"TITLETEXTBLOCKTITLE";
         divTitletable_Internalname = sPrefix+"TITLETABLE";
         divTitletablecell_Internalname = sPrefix+"TITLETABLECELL";
         divDatatable_Internalname = sPrefix+"DATATABLE";
         divDatatablecell_Internalname = sPrefix+"DATATABLECELL";
         divFsgridlayouttable_Internalname = sPrefix+"FSGRIDLAYOUTTABLE";
         bttBtnaddchild_Internalname = sPrefix+"BTNADDCHILD";
         Btnmoveup_Internalname = sPrefix+"BTNMOVEUP";
         Btnmovedown_Internalname = sPrefix+"BTNMOVEDOWN";
         Btndeleteelement_Internalname = sPrefix+"BTNDELETEELEMENT";
         Btnsettings_Internalname = sPrefix+"BTNSETTINGS";
         Btnaddelement_Internalname = sPrefix+"BTNADDELEMENT";
         tblUnnamedtable2_Internalname = sPrefix+"UNNAMEDTABLE2";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         bttBtnrefreshgrid_Internalname = sPrefix+"BTNREFRESHGRID";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         Dvelop_confirmpanel_btndeleteelement_Internalname = sPrefix+"DVELOP_CONFIRMPANEL_BTNDELETEELEMENT";
         tblTabledvelop_confirmpanel_btndeleteelement_Internalname = sPrefix+"TABLEDVELOP_CONFIRMPANEL_BTNDELETEELEMENT";
         Settings_modal_Internalname = sPrefix+"SETTINGS_MODAL";
         tblTablesettings_modal_Internalname = sPrefix+"TABLESETTINGS_MODAL";
         Addelement_modal_Internalname = sPrefix+"ADDELEMENT_MODAL";
         tblTableaddelement_modal_Internalname = sPrefix+"TABLEADDELEMENT_MODAL";
         divDiv_wwpauxwc_Internalname = sPrefix+"DIV_WWPAUXWC";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subFsgrid_Internalname = sPrefix+"FSGRID";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         subFsgrid_Allowcollapsing = 0;
         lblTitletextblocktitle_Caption = context.GetMessage( "Title", "");
         divDatatablecell_Visible = 1;
         lblTitletextblocktitle_Caption = context.GetMessage( "Title", "");
         divTitletablecell_Visible = 1;
         subFsgrid_Class = "FreeStyleGrid";
         Btnaddelement_Class = "ButtonGray";
         Btnaddelement_Caption = context.GetMessage( "WWP_DF_AddElement", "");
         Btnaddelement_Beforeiconclass = "fas fa-circle-plus";
         Btnaddelement_Tooltiptext = "";
         Btnsettings_Class = "ButtonGray";
         Btnsettings_Beforeiconclass = "fas fa-gear";
         Btnsettings_Tooltiptext = "";
         Btndeleteelement_Class = "ButtonGray";
         Btndeleteelement_Beforeiconclass = "fa-trash-can far";
         Btndeleteelement_Tooltiptext = "";
         Btnmovedown_Class = "ButtonGray";
         Btnmovedown_Beforeiconclass = "fas fa-arrow-down";
         Btnmovedown_Tooltiptext = "";
         Btnmoveup_Class = "ButtonGray";
         Btnmoveup_Beforeiconclass = "fas fa-arrow-up";
         Btnmoveup_Tooltiptext = "";
         Dvelop_confirmpanel_btndeleteelement_Confirmtype = "1";
         Dvelop_confirmpanel_btndeleteelement_Yesbuttonposition = "left";
         Dvelop_confirmpanel_btndeleteelement_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_btndeleteelement_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_btndeleteelement_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_btndeleteelement_Title = context.GetMessage( "GX_BtnDelete", "");
         Settings_modal_Bodytype = "WebComponent";
         Settings_modal_Confirmtype = "";
         Settings_modal_Title = context.GetMessage( "Add Element", "");
         Settings_modal_Width = "800";
         Addelement_modal_Bodytype = "WebComponent";
         Addelement_modal_Confirmtype = "";
         Addelement_modal_Width = "800";
         tblUnnamedtable2_Visible = 1;
         Btnsettings_Visible = Convert.ToBoolean( -1);
         Btnmovedown_Visible = Convert.ToBoolean( -1);
         Btnmoveup_Visible = Convert.ToBoolean( -1);
         Addelement_modal_Title = context.GetMessage( "Element settings", "");
         Btnsettings_Caption = context.GetMessage( "WWP_DF_Settings", "");
         Btndeleteelement_Caption = context.GetMessage( "GX_BtnDelete", "");
         Btnmovedown_Caption = context.GetMessage( "WWP_DF_MoveDown", "");
         Btnmoveup_Caption = context.GetMessage( "WWP_DF_MoveUp", "");
         Dvelop_confirmpanel_btndeleteelement_Confirmationtext = "WWP_DF_ConfirmSelectedElementDeletion";
         subFsgrid_Backcolorstyle = 0;
         subFsgrid_Columns = 1;
         bttBtnaddchild_Caption = context.GetMessage( "Add child", "");
         bttBtnaddchild_Visible = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"FSGRID_nFirstRecordOnPage"},{"av":"FSGRID_nEOF"},{"av":"AV18WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV13SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"sPrefix"},{"av":"AV19WWPForm","fld":"vWWPFORM"},{"av":"AV21WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV17WWP_DF_ElementsRepeaterMetadata","fld":"vWWP_DF_ELEMENTSREPEATERMETADATA","hsh":true},{"av":"AV9IsFirstElement","fld":"vISFIRSTELEMENT","hsh":true},{"av":"AV10IsLastElement","fld":"vISLASTELEMENT","hsh":true},{"av":"AV22WWPFormInstance","fld":"vWWPFORMINSTANCE","hsh":true},{"av":"AV11IsStep","fld":"vISSTEP","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"subFsgrid_Columns","ctrl":"FSGRID","prop":"Columns"},{"ctrl":"BTNADDCHILD","prop":"Visible"},{"av":"Btnmoveup_Visible","ctrl":"BTNMOVEUP","prop":"Visible"},{"av":"Btnmovedown_Visible","ctrl":"BTNMOVEDOWN","prop":"Visible"},{"av":"Btnsettings_Visible","ctrl":"BTNSETTINGS","prop":"Visible"}]}""");
         setEventMetadata("FSGRID.LOAD","""{"handler":"E22362","iparms":[{"av":"AV19WWPForm","fld":"vWWPFORM"},{"av":"AV21WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV17WWP_DF_ElementsRepeaterMetadata","fld":"vWWP_DF_ELEMENTSREPEATERMETADATA","hsh":true},{"av":"AV18WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV13SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV22WWPFormInstance","fld":"vWWPFORMINSTANCE","hsh":true}]""");
         setEventMetadata("FSGRID.LOAD",""","oparms":[{"av":"divDatatablecell_Visible","ctrl":"DATATABLECELL","prop":"Visible"},{"av":"lblTitletextblocktitle_Caption","ctrl":"TITLETEXTBLOCKTITLE","prop":"Caption"},{"av":"divTitletablecell_Visible","ctrl":"TITLETABLECELL","prop":"Visible"},{"ctrl":"DATAWCCHILDREN"}]}""");
         setEventMetadata("'DOADDCHILD'","""{"handler":"E11361","iparms":[]}""");
         setEventMetadata("'DOREFRESHGRID'","""{"handler":"E17362","iparms":[{"av":"FSGRID_nFirstRecordOnPage"},{"av":"FSGRID_nEOF"},{"av":"AV19WWPForm","fld":"vWWPFORM"},{"av":"AV21WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV17WWP_DF_ElementsRepeaterMetadata","fld":"vWWP_DF_ELEMENTSREPEATERMETADATA","hsh":true},{"av":"AV9IsFirstElement","fld":"vISFIRSTELEMENT","hsh":true},{"av":"AV10IsLastElement","fld":"vISLASTELEMENT","hsh":true},{"av":"AV18WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV13SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV22WWPFormInstance","fld":"vWWPFORMINSTANCE","hsh":true},{"av":"AV11IsStep","fld":"vISSTEP","hsh":true},{"av":"sPrefix"}]""");
         setEventMetadata("'DOREFRESHGRID'",""","oparms":[{"av":"AV19WWPForm","fld":"vWWPFORM"},{"av":"subFsgrid_Columns","ctrl":"FSGRID","prop":"Columns"},{"ctrl":"BTNADDCHILD","prop":"Visible"},{"av":"Btnmoveup_Visible","ctrl":"BTNMOVEUP","prop":"Visible"},{"av":"Btnmovedown_Visible","ctrl":"BTNMOVEDOWN","prop":"Visible"},{"av":"Btnsettings_Visible","ctrl":"BTNSETTINGS","prop":"Visible"}]}""");
         setEventMetadata("'DOMOVEUP'","""{"handler":"E18362","iparms":[{"av":"AV13SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV21WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"}]}""");
         setEventMetadata("'DOMOVEDOWN'","""{"handler":"E19362","iparms":[{"av":"AV13SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV21WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_BTNDELETEELEMENT.CLOSE","""{"handler":"E12362","iparms":[{"av":"Dvelop_confirmpanel_btndeleteelement_Result","ctrl":"DVELOP_CONFIRMPANEL_BTNDELETEELEMENT","prop":"Result"},{"av":"AV13SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV21WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_BTNDELETEELEMENT.CLOSE",""","oparms":[{"av":"AV19WWPForm","fld":"vWWPFORM"}]}""");
         setEventMetadata("SETTINGS_MODAL.ONLOADCOMPONENT","""{"handler":"E14362","iparms":[{"av":"AV21WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV13SessionId","fld":"vSESSIONID","pic":"ZZZ9"}]""");
         setEventMetadata("SETTINGS_MODAL.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("ADDELEMENT_MODAL.ONLOADCOMPONENT","""{"handler":"E16362","iparms":[{"av":"AV21WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV13SessionId","fld":"vSESSIONID","pic":"ZZZ9"}]""");
         setEventMetadata("ADDELEMENT_MODAL.ONLOADCOMPONENT",""","oparms":[{"av":"Addelement_modal_Title","ctrl":"ADDELEMENT_MODAL","prop":"Title"},{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("SETTINGS_MODAL.CLOSE","""{"handler":"E13362","iparms":[{"av":"Settings_modal_Result","ctrl":"SETTINGS_MODAL","prop":"Result"},{"av":"AV11IsStep","fld":"vISSTEP","hsh":true},{"av":"AV13SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV21WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"}]""");
         setEventMetadata("SETTINGS_MODAL.CLOSE",""","oparms":[{"av":"AV19WWPForm","fld":"vWWPFORM"}]}""");
         setEventMetadata("ADDELEMENT_MODAL.CLOSE","""{"handler":"E15362","iparms":[{"av":"FSGRID_nFirstRecordOnPage"},{"av":"FSGRID_nEOF"},{"av":"AV19WWPForm","fld":"vWWPFORM"},{"av":"AV21WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV17WWP_DF_ElementsRepeaterMetadata","fld":"vWWP_DF_ELEMENTSREPEATERMETADATA","hsh":true},{"av":"AV9IsFirstElement","fld":"vISFIRSTELEMENT","hsh":true},{"av":"AV10IsLastElement","fld":"vISLASTELEMENT","hsh":true},{"av":"AV18WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV13SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV22WWPFormInstance","fld":"vWWPFORMINSTANCE","hsh":true},{"av":"AV11IsStep","fld":"vISSTEP","hsh":true},{"av":"sPrefix"},{"av":"Addelement_modal_Result","ctrl":"ADDELEMENT_MODAL","prop":"Result"}]""");
         setEventMetadata("ADDELEMENT_MODAL.CLOSE",""","oparms":[{"av":"AV19WWPForm","fld":"vWWPFORM"},{"av":"subFsgrid_Columns","ctrl":"FSGRID","prop":"Columns"},{"ctrl":"BTNADDCHILD","prop":"Visible"},{"av":"Btnmoveup_Visible","ctrl":"BTNMOVEUP","prop":"Visible"},{"av":"Btnmovedown_Visible","ctrl":"BTNMOVEDOWN","prop":"Visible"},{"av":"Btnsettings_Visible","ctrl":"BTNSETTINGS","prop":"Visible"}]}""");
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
         AV19WWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         wcpOAV18WWPDynamicFormMode = "";
         Dvelop_confirmpanel_btndeleteelement_Result = "";
         Settings_modal_Result = "";
         Addelement_modal_Result = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV17WWP_DF_ElementsRepeaterMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ElementsRepeaterMetadata(context);
         AV22WWPFormInstance = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         FsgridContainer = new GXWebGrid( context);
         sStyleString = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnaddchild_Jsonclick = "";
         bttBtnrefreshgrid_Jsonclick = "";
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         OldDatawcchildren = "";
         sCmpCtrl = "";
         WebComp_GX_Process_Component = "";
         GXDecQS = "";
         WebComp_Datawcchildren_Component = "";
         AV6CurrentElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         ucDvelop_confirmpanel_btndeleteelement = new GXUserControl();
         ucBtnmoveup = new GXUserControl();
         ucBtnmovedown = new GXUserControl();
         ucBtndeleteelement = new GXUserControl();
         ucBtnsettings = new GXUserControl();
         AV20WWPFormElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         FsgridRow = new GXWebRow();
         AV5WWP_DF_BooleanMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_BooleanMetadata(context);
         AV16WWP_DF_CharMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata(context);
         GXt_SdtWWP_Form_Element1 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         ucAddelement_modal = new GXUserControl();
         AV8Element = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         AV15WebSession = context.GetSession();
         GXt_SdtWWP_Form2 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         ucSettings_modal = new GXUserControl();
         ucBtnaddelement = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV18WWPDynamicFormMode = "";
         sCtrlAV21WWPFormElementId = "";
         sCtrlAV13SessionId = "";
         sCtrlAV19WWPForm = "";
         subFsgrid_Linesclass = "";
         lblTitletextblocktitle_Jsonclick = "";
         subFsgrid_Header = "";
         FsgridColumn = new GXWebColumn();
         WebComp_GX_Process = new GeneXus.Http.GXNullWebComponent();
         WebComp_Datawcchildren = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short AV21WWPFormElementId ;
      private short AV13SessionId ;
      private short wcpOAV21WWPFormElementId ;
      private short wcpOAV13SessionId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short subFsgrid_Columns ;
      private short subFsgrid_Backcolorstyle ;
      private short AV12MultipleDataElements ;
      private short FSGRID_nEOF ;
      private short AV7CurrentStepIndex ;
      private short nGXWrapped ;
      private short subFsgrid_Backstyle ;
      private short subFsgrid_Allowselection ;
      private short subFsgrid_Allowhovering ;
      private short subFsgrid_Allowcollapsing ;
      private short subFsgrid_Collapsed ;
      private int nRC_GXsfl_9 ;
      private int subFsgrid_Recordcount ;
      private int nGXsfl_9_idx=1 ;
      private int bttBtnaddchild_Visible ;
      private int nGXsfl_9_webc_idx=0 ;
      private int subFsgrid_Islastpage ;
      private int AV25GXV1 ;
      private int divDatatablecell_Visible ;
      private int AV26GXV2 ;
      private int AV27GXV3 ;
      private int divTitletablecell_Visible ;
      private int tblUnnamedtable2_Visible ;
      private int AV28GXV4 ;
      private int idxLst ;
      private int subFsgrid_Backcolor ;
      private int subFsgrid_Allbackcolor ;
      private int subFsgrid_Selectedindex ;
      private int subFsgrid_Selectioncolor ;
      private int subFsgrid_Hoveringcolor ;
      private long FSGRID_nCurrentRecord ;
      private long FSGRID_nFirstRecordOnPage ;
      private string AV18WWPDynamicFormMode ;
      private string wcpOAV18WWPDynamicFormMode ;
      private string Dvelop_confirmpanel_btndeleteelement_Result ;
      private string Settings_modal_Result ;
      private string Addelement_modal_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_9_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string sStyleString ;
      private string subFsgrid_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnaddchild_Internalname ;
      private string bttBtnaddchild_Caption ;
      private string bttBtnaddchild_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string bttBtnrefreshgrid_Internalname ;
      private string bttBtnrefreshgrid_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string OldDatawcchildren ;
      private string sCmpCtrl ;
      private string WebComp_GX_Process_Component ;
      private string WebCompHandler="" ;
      private string GXDecQS ;
      private string WebComp_Datawcchildren_Component ;
      private string Dvelop_confirmpanel_btndeleteelement_Confirmationtext ;
      private string Dvelop_confirmpanel_btndeleteelement_Internalname ;
      private string Btnmoveup_Caption ;
      private string Btnmoveup_Internalname ;
      private string Btnmovedown_Caption ;
      private string Btnmovedown_Internalname ;
      private string Btndeleteelement_Caption ;
      private string Btndeleteelement_Internalname ;
      private string Btnsettings_Caption ;
      private string Btnsettings_Internalname ;
      private string divDatatablecell_Internalname ;
      private string lblTitletextblocktitle_Caption ;
      private string divTitletablecell_Internalname ;
      private string Addelement_modal_Title ;
      private string Addelement_modal_Internalname ;
      private string tblUnnamedtable2_Internalname ;
      private string tblTableaddelement_modal_Internalname ;
      private string Addelement_modal_Width ;
      private string Addelement_modal_Confirmtype ;
      private string Addelement_modal_Bodytype ;
      private string tblTablesettings_modal_Internalname ;
      private string Settings_modal_Width ;
      private string Settings_modal_Title ;
      private string Settings_modal_Confirmtype ;
      private string Settings_modal_Bodytype ;
      private string Settings_modal_Internalname ;
      private string tblTabledvelop_confirmpanel_btndeleteelement_Internalname ;
      private string Dvelop_confirmpanel_btndeleteelement_Title ;
      private string Dvelop_confirmpanel_btndeleteelement_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_btndeleteelement_Nobuttoncaption ;
      private string Dvelop_confirmpanel_btndeleteelement_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_btndeleteelement_Yesbuttonposition ;
      private string Dvelop_confirmpanel_btndeleteelement_Confirmtype ;
      private string Btnmoveup_Tooltiptext ;
      private string Btnmoveup_Beforeiconclass ;
      private string Btnmoveup_Class ;
      private string Btnmovedown_Tooltiptext ;
      private string Btnmovedown_Beforeiconclass ;
      private string Btnmovedown_Class ;
      private string Btndeleteelement_Tooltiptext ;
      private string Btndeleteelement_Beforeiconclass ;
      private string Btndeleteelement_Class ;
      private string Btnsettings_Tooltiptext ;
      private string Btnsettings_Beforeiconclass ;
      private string Btnsettings_Class ;
      private string Btnaddelement_Tooltiptext ;
      private string Btnaddelement_Beforeiconclass ;
      private string Btnaddelement_Caption ;
      private string Btnaddelement_Class ;
      private string Btnaddelement_Internalname ;
      private string sCtrlAV18WWPDynamicFormMode ;
      private string sCtrlAV21WWPFormElementId ;
      private string sCtrlAV13SessionId ;
      private string sCtrlAV19WWPForm ;
      private string lblTitletextblocktitle_Internalname ;
      private string sGXsfl_9_fel_idx="0001" ;
      private string subFsgrid_Class ;
      private string subFsgrid_Linesclass ;
      private string divFsgridlayouttable_Internalname ;
      private string divTitletable_Internalname ;
      private string lblTitletextblocktitle_Jsonclick ;
      private string divDatatable_Internalname ;
      private string subFsgrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV9IsFirstElement ;
      private bool AV10IsLastElement ;
      private bool AV11IsStep ;
      private bool wbLoad ;
      private bool bGXsfl_9_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV14TitlesAreLoaded ;
      private bool bDynCreated_Datawcchildren ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool Btnmoveup_Visible ;
      private bool Btnmovedown_Visible ;
      private bool Btnsettings_Visible ;
      private GXWebComponent WebComp_Datawcchildren ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid FsgridContainer ;
      private GXWebRow FsgridRow ;
      private GXWebColumn FsgridColumn ;
      private GXUserControl ucDvelop_confirmpanel_btndeleteelement ;
      private GXUserControl ucBtnmoveup ;
      private GXUserControl ucBtnmovedown ;
      private GXUserControl ucBtndeleteelement ;
      private GXUserControl ucBtnsettings ;
      private GXUserControl ucAddelement_modal ;
      private GXUserControl ucSettings_modal ;
      private GXUserControl ucBtnaddelement ;
      private GXWebForm Form ;
      private IGxSession AV15WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV19WWPForm ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP3_WWPForm ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ElementsRepeaterMetadata AV17WWP_DF_ElementsRepeaterMetadata ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV22WWPFormInstance ;
      private GXWebComponent WebComp_GX_Process ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV6CurrentElement ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV20WWPFormElement ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_BooleanMetadata AV5WWP_DF_BooleanMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata AV16WWP_DF_CharMetadata ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element GXt_SdtWWP_Form_Element1 ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV8Element ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form GXt_SdtWWP_Form2 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
