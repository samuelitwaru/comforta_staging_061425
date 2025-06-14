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
   public class wwp_dfc_label_wc : GXWebComponent
   {
      public wwp_dfc_label_wc( )
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

      public wwp_dfc_label_wc( IGxContext context )
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
         this.AV8WWPDynamicFormMode = aP0_WWPDynamicFormMode;
         this.AV11WWPFormElementId = aP1_WWPFormElementId;
         this.AV7SessionId = aP2_SessionId;
         this.AV9WWPForm = aP3_WWPForm;
         ExecuteImpl();
         aP3_WWPForm=this.AV9WWPForm;
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
                  AV8WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
                  AssignAttri(sPrefix, false, "AV8WWPDynamicFormMode", AV8WWPDynamicFormMode);
                  AV11WWPFormElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV11WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV11WWPFormElementId), 4, 0));
                  AV7SessionId = (short)(Math.Round(NumberUtil.Val( GetPar( "SessionId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV7SessionId", StringUtil.LTrimStr( (decimal)(AV7SessionId), 4, 0));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV9WWPForm);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV8WWPDynamicFormMode,(short)AV11WWPFormElementId,(short)AV7SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV9WWPForm});
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
            PA372( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS372( ) ;
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
            context.SendWebValue( context.GetMessage( "WWP_Dynamic Form Creation_Label_WC", "")) ;
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
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_dfc_label_wc.aspx"+UrlEncode(StringUtil.RTrim(AV8WWPDynamicFormMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV11WWPFormElementId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV7SessionId,4,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.dynamicforms.wwp_dfc_label_wc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISFIRSTELEMENT", AV5IsFirstElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISFIRSTELEMENT", GetSecureSignedToken( sPrefix, AV5IsFirstElement, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISLASTELEMENT", AV6IsLastElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISLASTELEMENT", GetSecureSignedToken( sPrefix, AV6IsLastElement, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vPARENTISGRIDMULTIPLEDATA", AV14ParentIsGridMultipleData);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPARENTISGRIDMULTIPLEDATA", GetSecureSignedToken( sPrefix, AV14ParentIsGridMultipleData, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWP_DYNAMICFORMDATATYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13WWP_DynamicFormDataType), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DYNAMICFORMDATATYPE", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV13WWP_DynamicFormDataType), "Z9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_DYNAMICFORMTRANSLATION", AV20SDT_DynamicFormTranslation);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_DYNAMICFORMTRANSLATION", AV20SDT_DynamicFormTranslation);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDT_DYNAMICFORMTRANSLATION", GetSecureSignedToken( sPrefix, AV20SDT_DynamicFormTranslation, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8WWPDynamicFormMode", StringUtil.RTrim( wcpOAV8WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV11WWPFormElementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV11WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7SessionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV7SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISFIRSTELEMENT", AV5IsFirstElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISFIRSTELEMENT", GetSecureSignedToken( sPrefix, AV5IsFirstElement, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISLASTELEMENT", AV6IsLastElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISLASTELEMENT", GetSecureSignedToken( sPrefix, AV6IsLastElement, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vNEEDTORELOADWC", AV12NeedToReloadWC);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORMELEMENT", AV10WWPFormElement);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORMELEMENT", AV10WWPFormElement);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vPARENTISGRIDMULTIPLEDATA", AV14ParentIsGridMultipleData);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPARENTISGRIDMULTIPLEDATA", GetSecureSignedToken( sPrefix, AV14ParentIsGridMultipleData, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWP_DYNAMICFORMDATATYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13WWP_DynamicFormDataType), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DYNAMICFORMDATATYPE", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV13WWP_DynamicFormDataType), "Z9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_DYNAMICFORMTRANSLATION", AV20SDT_DynamicFormTranslation);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_DYNAMICFORMTRANSLATION", AV20SDT_DynamicFormTranslation);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDT_DYNAMICFORMTRANSLATION", GetSecureSignedToken( sPrefix, AV20SDT_DynamicFormTranslation, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV8WWPDynamicFormMode));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORM", AV9WWPForm);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORM", AV9WWPForm);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_BTNDELETEELEMENT_Result", StringUtil.RTrim( Dvelop_confirmpanel_btndeleteelement_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"SETTINGS_MODAL_Result", StringUtil.RTrim( Settings_modal_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENT_Wwpformelementmetadata", AV10WWPFormElement.gxTpr_Wwpformelementmetadata);
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_BTNDELETEELEMENT_Result", StringUtil.RTrim( Dvelop_confirmpanel_btndeleteelement_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"SETTINGS_MODAL_Result", StringUtil.RTrim( Settings_modal_Result));
      }

      protected void RenderHtmlCloseForm372( )
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
         return "WorkWithPlus.DynamicForms.WWP_DFC_Label_WC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WWP_Dynamic Form Creation_Label_WC", "") ;
      }

      protected void WB370( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "workwithplus.dynamicforms.wwp_dfc_label_wc.aspx");
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableDynFormAddedElement", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLabelcell_Internalname, 1, 0, "px", 0, "px", divLabelcell_Class, "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLabel_Internalname, lblLabel_Caption, "", "", lblLabel_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", lblLabel_Class, 0, "", 1, 1, 0, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DFC_Label_WC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 TableDynAddElementActionsCell", "end", "top", "", "", "div");
            wb_table1_12_372( true) ;
         }
         else
         {
            wb_table1_12_372( false) ;
         }
         return  ;
      }

      protected void wb_table1_12_372e( bool wbgen )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            wb_table2_25_372( true) ;
         }
         else
         {
            wb_table2_25_372( false) ;
         }
         return  ;
      }

      protected void wb_table2_25_372e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table3_30_372( true) ;
         }
         else
         {
            wb_table3_30_372( false) ;
         }
         return  ;
      }

      protected void wb_table3_30_372e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, sPrefix+"W0036"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0036"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0036"+"");
                  }
                  WebComp_Wwpaux_wc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
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
         wbLoad = true;
      }

      protected void START372( )
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
            Form.Meta.addItem("description", context.GetMessage( "WWP_Dynamic Form Creation_Label_WC", ""), 0) ;
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
               STRUP370( ) ;
            }
         }
      }

      protected void WS372( )
      {
         START372( ) ;
         EVT372( ) ;
      }

      protected void EVT372( )
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
                                 STRUP370( ) ;
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
                                 STRUP370( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Dvelop_confirmpanel_btndeleteelement.Close */
                                    E11372 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "SETTINGS_MODAL.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP370( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Settings_modal.Close */
                                    E12372 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "SETTINGS_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP370( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Settings_modal.Onloadcomponent */
                                    E13372 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP370( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E14372 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP370( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E15372 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOMOVEUP'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP370( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoMoveUp' */
                                    E16372 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOMOVEDOWN'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP370( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoMoveDown' */
                                    E17372 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP370( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E18372 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP370( ) ;
                              }
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
                                 STRUP370( ) ;
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
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 36 )
                        {
                           OldWwpaux_wc = cgiGet( sPrefix+"W0036");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess(sPrefix+"W0036", "", sEvt);
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

      protected void WE372( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm372( ) ;
            }
         }
      }

      protected void PA372( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.dynamicforms.wwp_dfc_label_wc.aspx")), "workwithplus.dynamicforms.wwp_dfc_label_wc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.dynamicforms.wwp_dfc_label_wc.aspx")))) ;
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
         RF372( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF372( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E15372 ();
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
            /* Execute user event: Load */
            E18372 ();
            WB370( ) ;
         }
      }

      protected void send_integrity_lvl_hashes372( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISFIRSTELEMENT", AV5IsFirstElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISFIRSTELEMENT", GetSecureSignedToken( sPrefix, AV5IsFirstElement, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISLASTELEMENT", AV6IsLastElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISLASTELEMENT", GetSecureSignedToken( sPrefix, AV6IsLastElement, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vPARENTISGRIDMULTIPLEDATA", AV14ParentIsGridMultipleData);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPARENTISGRIDMULTIPLEDATA", GetSecureSignedToken( sPrefix, AV14ParentIsGridMultipleData, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWP_DYNAMICFORMDATATYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13WWP_DynamicFormDataType), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DYNAMICFORMDATATYPE", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV13WWP_DynamicFormDataType), "Z9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_DYNAMICFORMTRANSLATION", AV20SDT_DynamicFormTranslation);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_DYNAMICFORMTRANSLATION", AV20SDT_DynamicFormTranslation);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDT_DYNAMICFORMTRANSLATION", GetSecureSignedToken( sPrefix, AV20SDT_DynamicFormTranslation, context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP370( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E14372 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOAV8WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV8WWPDynamicFormMode");
            wcpOAV11WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV11WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV7SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Dvelop_confirmpanel_btndeleteelement_Result = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_BTNDELETEELEMENT_Result");
            Settings_modal_Result = cgiGet( sPrefix+"SETTINGS_MODAL_Result");
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
         E14372 ();
         if (returnInSub) return;
      }

      protected void E14372( )
      {
         /* Start Routine */
         returnInSub = false;
         AV20SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformid = AV9WWPForm.gxTpr_Wwpformid;
         AV20SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformversionnumber = AV9WWPForm.gxTpr_Wwpformversionnumber;
         AV20SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformelementid = AV11WWPFormElementId;
         new prc_getdynamicformtranslation(context ).execute( ref  AV20SDT_DynamicFormTranslation) ;
         GXt_SdtWWP_Form_Element1 = AV10WWPFormElement;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getelementbyid(context ).execute( ref  AV9WWPForm,  AV11WWPFormElementId, out  GXt_SdtWWP_Form_Element1) ;
         AV10WWPFormElement = GXt_SdtWWP_Form_Element1;
         AV13WWP_DynamicFormDataType = AV10WWPFormElement.gxTpr_Wwpformelementdatatype;
         AssignAttri(sPrefix, false, "AV13WWP_DynamicFormDataType", StringUtil.LTrimStr( (decimal)(AV13WWP_DynamicFormDataType), 2, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DYNAMICFORMDATATYPE", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV13WWP_DynamicFormDataType), "Z9"), context));
         /* Execute user subroutine: 'LOAD TITLE AND METADATA' */
         S112 ();
         if (returnInSub) return;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_dfc_canmoveelement(context ).execute(  AV9WWPForm,  AV10WWPFormElement, out  AV5IsFirstElement, out  AV6IsLastElement) ;
         AssignAttri(sPrefix, false, "AV5IsFirstElement", AV5IsFirstElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISFIRSTELEMENT", GetSecureSignedToken( sPrefix, AV5IsFirstElement, context));
         AssignAttri(sPrefix, false, "AV6IsLastElement", AV6IsLastElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISLASTELEMENT", GetSecureSignedToken( sPrefix, AV6IsLastElement, context));
         if ( new GeneXus.Programs.workwithplus.dynamicforms.wwp_dfc_showsmallbuttons(context).executeUdp( ref  AV9WWPForm,  AV10WWPFormElement.gxTpr_Wwpformelementparentid,  false, out  AV14ParentIsGridMultipleData) )
         {
            Btnmoveup_Caption = "";
            ucBtnmoveup.SendProperty(context, sPrefix, false, Btnmoveup_Internalname, "Caption", Btnmoveup_Caption);
            Btnmovedown_Caption = "";
            ucBtnmovedown.SendProperty(context, sPrefix, false, Btnmovedown_Internalname, "Caption", Btnmovedown_Caption);
            Btnsettings_Caption = "";
            ucBtnsettings.SendProperty(context, sPrefix, false, Btnsettings_Internalname, "Caption", Btnsettings_Caption);
            Btndeleteelement_Caption = "";
            ucBtndeleteelement.SendProperty(context, sPrefix, false, Btndeleteelement_Internalname, "Caption", Btndeleteelement_Caption);
            if ( AV14ParentIsGridMultipleData )
            {
               Btnmoveup_Tooltiptext = context.GetMessage( "Move left", "");
               ucBtnmoveup.SendProperty(context, sPrefix, false, Btnmoveup_Internalname, "TooltipText", Btnmoveup_Tooltiptext);
               Btnmoveup_Beforeiconclass = "fas fa-arrow-left";
               ucBtnmoveup.SendProperty(context, sPrefix, false, Btnmoveup_Internalname, "BeforeIconClass", Btnmoveup_Beforeiconclass);
               Btnmovedown_Tooltiptext = context.GetMessage( "Move right", "");
               ucBtnmovedown.SendProperty(context, sPrefix, false, Btnmovedown_Internalname, "TooltipText", Btnmovedown_Tooltiptext);
               Btnmovedown_Beforeiconclass = "fas fa-arrow-right";
               ucBtnmovedown.SendProperty(context, sPrefix, false, Btnmovedown_Internalname, "BeforeIconClass", Btnmovedown_Beforeiconclass);
            }
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
      }

      protected void E15372( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E16372( )
      {
         /* 'DoMoveUp' Routine */
         returnInSub = false;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_dfc_moveelement(context ).execute(  AV7SessionId,  AV11WWPFormElementId,  true) ;
         this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "DynamicForms_RefreshParentGrid", new Object[] {(string)divLayoutmaintable_Internalname,(string)"LayoutMainTable"}, false);
      }

      protected void E17372( )
      {
         /* 'DoMoveDown' Routine */
         returnInSub = false;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_dfc_moveelement(context ).execute(  AV7SessionId,  AV11WWPFormElementId,  false) ;
         this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "DynamicForms_RefreshParentGrid", new Object[] {(string)divLayoutmaintable_Internalname,(string)"LayoutMainTable"}, false);
      }

      protected void E11372( )
      {
         /* Dvelop_confirmpanel_btndeleteelement_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_btndeleteelement_Result, "Yes") == 0 )
         {
            GXt_SdtWWP_Form2 = AV9WWPForm;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadformdefinition(context ).execute(  AV7SessionId, out  GXt_SdtWWP_Form2) ;
            AV9WWPForm = GXt_SdtWWP_Form2;
            GXt_SdtWWP_Form_Element1 = AV10WWPFormElement;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getelementbyid(context ).execute( ref  AV9WWPForm,  AV11WWPFormElementId, out  GXt_SdtWWP_Form_Element1) ;
            AV10WWPFormElement = GXt_SdtWWP_Form_Element1;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_dfc_deleteelement(context ).execute( ref  AV9WWPForm, ref  AV10WWPFormElement) ;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_saveformdefinition(context ).execute(  AV7SessionId,  AV9WWPForm) ;
            this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "DynamicForms_RefreshParentGrid", new Object[] {(string)divLayoutmaintable_Internalname,(string)"LayoutMainTable"}, false);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV9WWPForm", AV9WWPForm);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10WWPFormElement", AV10WWPFormElement);
      }

      protected void E13372( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)sPrefix+"W0036",(string)"",(string)"UPD",(short)0,(short)AV11WWPFormElementId,(short)AV7SessionId});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0036"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S132( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ! AV5IsFirstElement ) )
         {
            Btnmoveup_Visible = false;
            ucBtnmoveup.SendProperty(context, sPrefix, false, Btnmoveup_Internalname, "Visible", StringUtil.BoolToStr( Btnmoveup_Visible));
         }
         if ( ! ( ! AV6IsLastElement ) )
         {
            Btnmovedown_Visible = false;
            ucBtnmovedown.SendProperty(context, sPrefix, false, Btnmovedown_Internalname, "Visible", StringUtil.BoolToStr( Btnmovedown_Visible));
         }
      }

      protected void S122( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         tblTableactions_Visible = (((StringUtil.StrCmp(AV8WWPDynamicFormMode, "DSP")!=0)) ? 1 : 0);
         AssignProp(sPrefix, false, tblTableactions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTableactions_Visible), 5, 0), true);
      }

      protected void E12372( )
      {
         /* Settings_modal_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Settings_modal_Result, "OK") == 0 )
         {
            GXt_SdtWWP_Form2 = AV9WWPForm;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadformdefinition(context ).execute(  AV7SessionId, out  GXt_SdtWWP_Form2) ;
            AV9WWPForm = GXt_SdtWWP_Form2;
            GXt_SdtWWP_Form_Element1 = AV10WWPFormElement;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getelementbyid(context ).execute( ref  AV9WWPForm,  AV11WWPFormElementId, out  GXt_SdtWWP_Form_Element1) ;
            AV10WWPFormElement = GXt_SdtWWP_Form_Element1;
            /* Execute user subroutine: 'NEED TO RELOAD WC' */
            S142 ();
            if (returnInSub) return;
            if ( AV12NeedToReloadWC )
            {
               this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "DynamicForms_RefreshParentGrid", new Object[] {(string)divLayoutmaintable_Internalname,(string)"LayoutMainTable"}, false);
            }
            else
            {
               /* Execute user subroutine: 'LOAD TITLE AND METADATA' */
               S112 ();
               if (returnInSub) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV9WWPForm", AV9WWPForm);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10WWPFormElement", AV10WWPFormElement);
      }

      protected void S142( )
      {
         /* 'NEED TO RELOAD WC' Routine */
         returnInSub = false;
         AV12NeedToReloadWC = (bool)((AV14ParentIsGridMultipleData||(AV10WWPFormElement.gxTpr_Wwpformelementdatatype!=AV13WWP_DynamicFormDataType)));
         AssignAttri(sPrefix, false, "AV12NeedToReloadWC", AV12NeedToReloadWC);
      }

      protected void S112( )
      {
         /* 'LOAD TITLE AND METADATA' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationvalue)) )
         {
            lblLabel_Caption = AV10WWPFormElement.gxTpr_Wwpformelementtitle;
            AssignProp(sPrefix, false, lblLabel_Internalname, "Caption", lblLabel_Caption, true);
         }
         else
         {
            lblLabel_Caption = AV20SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationvalue;
            AssignProp(sPrefix, false, lblLabel_Internalname, "Caption", lblLabel_Caption, true);
         }
         AV15WWP_DF_LabelMetadata.FromJSonString(AV10WWPFormElement.gxTpr_Wwpformelementmetadata, null);
         if ( AV15WWP_DF_LabelMetadata.gxTpr_Style == 0 )
         {
            lblLabel_Class = "DynFormDataDescription";
            AssignProp(sPrefix, false, lblLabel_Internalname, "Class", lblLabel_Class, true);
         }
         else
         {
            lblLabel_Class = "LabelElementTitle";
            AssignProp(sPrefix, false, lblLabel_Internalname, "Class", lblLabel_Class, true);
            divLabelcell_Class = "col-xs-12 LabelElementTitleCell";
            AssignProp(sPrefix, false, divLabelcell_Internalname, "Class", divLabelcell_Class, true);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E18372( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table3_30_372( bool wbgen )
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
            wb_table3_30_372e( true) ;
         }
         else
         {
            wb_table3_30_372e( false) ;
         }
      }

      protected void wb_table2_25_372( bool wbgen )
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
            wb_table2_25_372e( true) ;
         }
         else
         {
            wb_table2_25_372e( false) ;
         }
      }

      protected void wb_table1_12_372( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblTableactions_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblTableactions_Internalname, tblTableactions_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_12_372e( true) ;
         }
         else
         {
            wb_table1_12_372e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8WWPDynamicFormMode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV8WWPDynamicFormMode", AV8WWPDynamicFormMode);
         AV11WWPFormElementId = Convert.ToInt16(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV11WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV11WWPFormElementId), 4, 0));
         AV7SessionId = Convert.ToInt16(getParm(obj,2));
         AssignAttri(sPrefix, false, "AV7SessionId", StringUtil.LTrimStr( (decimal)(AV7SessionId), 4, 0));
         AV9WWPForm = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)getParm(obj,3);
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
         PA372( ) ;
         WS372( ) ;
         WE372( ) ;
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
         sCtrlAV8WWPDynamicFormMode = (string)((string)getParm(obj,0));
         sCtrlAV11WWPFormElementId = (string)((string)getParm(obj,1));
         sCtrlAV7SessionId = (string)((string)getParm(obj,2));
         sCtrlAV9WWPForm = (string)((string)getParm(obj,3));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA372( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "workwithplus\\dynamicforms\\wwp_dfc_label_wc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA372( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV8WWPDynamicFormMode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV8WWPDynamicFormMode", AV8WWPDynamicFormMode);
            AV11WWPFormElementId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV11WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV11WWPFormElementId), 4, 0));
            AV7SessionId = Convert.ToInt16(getParm(obj,4));
            AssignAttri(sPrefix, false, "AV7SessionId", StringUtil.LTrimStr( (decimal)(AV7SessionId), 4, 0));
            AV9WWPForm = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)getParm(obj,5);
         }
         wcpOAV8WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV8WWPDynamicFormMode");
         wcpOAV11WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV11WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV7SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV8WWPDynamicFormMode, wcpOAV8WWPDynamicFormMode) != 0 ) || ( AV11WWPFormElementId != wcpOAV11WWPFormElementId ) || ( AV7SessionId != wcpOAV7SessionId ) ) )
         {
            setjustcreated();
         }
         wcpOAV8WWPDynamicFormMode = AV8WWPDynamicFormMode;
         wcpOAV11WWPFormElementId = AV11WWPFormElementId;
         wcpOAV7SessionId = AV7SessionId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV8WWPDynamicFormMode = cgiGet( sPrefix+"AV8WWPDynamicFormMode_CTRL");
         if ( StringUtil.Len( sCtrlAV8WWPDynamicFormMode) > 0 )
         {
            AV8WWPDynamicFormMode = cgiGet( sCtrlAV8WWPDynamicFormMode);
            AssignAttri(sPrefix, false, "AV8WWPDynamicFormMode", AV8WWPDynamicFormMode);
         }
         else
         {
            AV8WWPDynamicFormMode = cgiGet( sPrefix+"AV8WWPDynamicFormMode_PARM");
         }
         sCtrlAV11WWPFormElementId = cgiGet( sPrefix+"AV11WWPFormElementId_CTRL");
         if ( StringUtil.Len( sCtrlAV11WWPFormElementId) > 0 )
         {
            AV11WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV11WWPFormElementId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV11WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV11WWPFormElementId), 4, 0));
         }
         else
         {
            AV11WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV11WWPFormElementId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV7SessionId = cgiGet( sPrefix+"AV7SessionId_CTRL");
         if ( StringUtil.Len( sCtrlAV7SessionId) > 0 )
         {
            AV7SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV7SessionId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV7SessionId", StringUtil.LTrimStr( (decimal)(AV7SessionId), 4, 0));
         }
         else
         {
            AV7SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV7SessionId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV9WWPForm = cgiGet( sPrefix+"AV9WWPForm_CTRL");
         if ( StringUtil.Len( sCtrlAV9WWPForm) > 0 )
         {
            AV9WWPForm.FromXml(cgiGet( sCtrlAV9WWPForm), null, "", "");
         }
         else
         {
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"AV9WWPForm_PARM"), AV9WWPForm);
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
         PA372( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS372( ) ;
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
         WS372( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8WWPDynamicFormMode_PARM", StringUtil.RTrim( AV8WWPDynamicFormMode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8WWPDynamicFormMode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8WWPDynamicFormMode_CTRL", StringUtil.RTrim( sCtrlAV8WWPDynamicFormMode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV11WWPFormElementId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV11WWPFormElementId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV11WWPFormElementId_CTRL", StringUtil.RTrim( sCtrlAV11WWPFormElementId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7SessionId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7SessionId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7SessionId_CTRL", StringUtil.RTrim( sCtrlAV7SessionId));
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"AV9WWPForm_PARM", AV9WWPForm);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"AV9WWPForm_PARM", AV9WWPForm);
         }
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV9WWPForm)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV9WWPForm_CTRL", StringUtil.RTrim( sCtrlAV9WWPForm));
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
         WE372( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256145242828", true, true);
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
         context.AddJavascriptSource("workwithplus/dynamicforms/wwp_dfc_label_wc.js", "?20256145242828", false, true);
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
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblLabel_Internalname = sPrefix+"LABEL";
         divLabelcell_Internalname = sPrefix+"LABELCELL";
         Btnmoveup_Internalname = sPrefix+"BTNMOVEUP";
         Btnmovedown_Internalname = sPrefix+"BTNMOVEDOWN";
         Btndeleteelement_Internalname = sPrefix+"BTNDELETEELEMENT";
         Btnsettings_Internalname = sPrefix+"BTNSETTINGS";
         tblTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         Dvelop_confirmpanel_btndeleteelement_Internalname = sPrefix+"DVELOP_CONFIRMPANEL_BTNDELETEELEMENT";
         tblTabledvelop_confirmpanel_btndeleteelement_Internalname = sPrefix+"TABLEDVELOP_CONFIRMPANEL_BTNDELETEELEMENT";
         Settings_modal_Internalname = sPrefix+"SETTINGS_MODAL";
         tblTablesettings_modal_Internalname = sPrefix+"TABLESETTINGS_MODAL";
         divDiv_wwpauxwc_Internalname = sPrefix+"DIV_WWPAUXWC";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
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
         Btnsettings_Class = "ButtonGray";
         Btnsettings_Beforeiconclass = "fas fa-gear";
         Btnsettings_Tooltiptext = "Settings";
         Btndeleteelement_Class = "ButtonGray";
         Btndeleteelement_Beforeiconclass = "fa-trash-can far";
         Btndeleteelement_Tooltiptext = "Delete";
         Btnmovedown_Class = "ButtonGray";
         Btnmoveup_Class = "ButtonGray";
         Dvelop_confirmpanel_btndeleteelement_Confirmtype = "1";
         Dvelop_confirmpanel_btndeleteelement_Yesbuttonposition = "left";
         Dvelop_confirmpanel_btndeleteelement_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_btndeleteelement_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_btndeleteelement_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_btndeleteelement_Confirmationtext = "DF_ConfirmCurrentElementDeletion";
         Dvelop_confirmpanel_btndeleteelement_Title = context.GetMessage( "GX_BtnDelete", "");
         Settings_modal_Bodytype = "WebComponent";
         Settings_modal_Confirmtype = "";
         Settings_modal_Title = context.GetMessage( "Add Element", "");
         Settings_modal_Width = "800";
         tblTableactions_Visible = 1;
         Btnmovedown_Visible = Convert.ToBoolean( -1);
         Btnmoveup_Visible = Convert.ToBoolean( -1);
         Btnmovedown_Beforeiconclass = "fas fa-arrow-down";
         Btnmovedown_Tooltiptext = "Move down";
         Btnmoveup_Beforeiconclass = "fas fa-arrow-up";
         Btnmoveup_Tooltiptext = "Move up";
         Btndeleteelement_Caption = context.GetMessage( "GX_BtnDelete", "");
         Btnsettings_Caption = context.GetMessage( "WWP_DF_Settings", "");
         Btnmovedown_Caption = context.GetMessage( "WWP_DF_MoveDown", "");
         Btnmoveup_Caption = context.GetMessage( "WWP_DF_MoveUp", "");
         lblLabel_Class = "LabelElementTitle";
         lblLabel_Caption = context.GetMessage( "Label", "");
         divLabelcell_Class = "col-xs-12";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV5IsFirstElement","fld":"vISFIRSTELEMENT","hsh":true},{"av":"AV6IsLastElement","fld":"vISLASTELEMENT","hsh":true},{"av":"AV14ParentIsGridMultipleData","fld":"vPARENTISGRIDMULTIPLEDATA","hsh":true},{"av":"AV13WWP_DynamicFormDataType","fld":"vWWP_DYNAMICFORMDATATYPE","pic":"Z9","hsh":true},{"av":"AV20SDT_DynamicFormTranslation","fld":"vSDT_DYNAMICFORMTRANSLATION","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"Btnmoveup_Visible","ctrl":"BTNMOVEUP","prop":"Visible"},{"av":"Btnmovedown_Visible","ctrl":"BTNMOVEDOWN","prop":"Visible"}]}""");
         setEventMetadata("'DOMOVEUP'","""{"handler":"E16372","iparms":[{"av":"AV7SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV11WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"}]}""");
         setEventMetadata("'DOMOVEDOWN'","""{"handler":"E17372","iparms":[{"av":"AV7SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV11WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_BTNDELETEELEMENT.CLOSE","""{"handler":"E11372","iparms":[{"av":"Dvelop_confirmpanel_btndeleteelement_Result","ctrl":"DVELOP_CONFIRMPANEL_BTNDELETEELEMENT","prop":"Result"},{"av":"AV7SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV11WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_BTNDELETEELEMENT.CLOSE",""","oparms":[{"av":"AV9WWPForm","fld":"vWWPFORM"},{"av":"AV10WWPFormElement","fld":"vWWPFORMELEMENT"}]}""");
         setEventMetadata("SETTINGS_MODAL.ONLOADCOMPONENT","""{"handler":"E13372","iparms":[{"av":"AV11WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV7SessionId","fld":"vSESSIONID","pic":"ZZZ9"}]""");
         setEventMetadata("SETTINGS_MODAL.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("SETTINGS_MODAL.CLOSE","""{"handler":"E12372","iparms":[{"av":"Settings_modal_Result","ctrl":"SETTINGS_MODAL","prop":"Result"},{"av":"AV7SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV11WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV12NeedToReloadWC","fld":"vNEEDTORELOADWC"},{"av":"AV10WWPFormElement","fld":"vWWPFORMELEMENT"},{"av":"AV14ParentIsGridMultipleData","fld":"vPARENTISGRIDMULTIPLEDATA","hsh":true},{"av":"AV13WWP_DynamicFormDataType","fld":"vWWP_DYNAMICFORMDATATYPE","pic":"Z9","hsh":true},{"av":"AV20SDT_DynamicFormTranslation","fld":"vSDT_DYNAMICFORMTRANSLATION","hsh":true}]""");
         setEventMetadata("SETTINGS_MODAL.CLOSE",""","oparms":[{"av":"AV9WWPForm","fld":"vWWPFORM"},{"av":"AV10WWPFormElement","fld":"vWWPFORMELEMENT"},{"av":"AV12NeedToReloadWC","fld":"vNEEDTORELOADWC"},{"av":"lblLabel_Caption","ctrl":"LABEL","prop":"Caption"},{"av":"divLabelcell_Class","ctrl":"LABELCELL","prop":"Class"},{"av":"lblLabel_Class","ctrl":"LABEL","prop":"Class"}]}""");
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
         AV9WWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         wcpOAV8WWPDynamicFormMode = "";
         Dvelop_confirmpanel_btndeleteelement_Result = "";
         Settings_modal_Result = "";
         AV10WWPFormElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV20SDT_DynamicFormTranslation = new SdtSDT_DynamicFormTranslation(context);
         GX_FocusControl = "";
         lblLabel_Jsonclick = "";
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         ucBtnmoveup = new GXUserControl();
         ucBtnmovedown = new GXUserControl();
         ucBtnsettings = new GXUserControl();
         ucBtndeleteelement = new GXUserControl();
         GXt_SdtWWP_Form2 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         GXt_SdtWWP_Form_Element1 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         AV15WWP_DF_LabelMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_LabelMetadata(context);
         sStyleString = "";
         ucSettings_modal = new GXUserControl();
         ucDvelop_confirmpanel_btndeleteelement = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV8WWPDynamicFormMode = "";
         sCtrlAV11WWPFormElementId = "";
         sCtrlAV7SessionId = "";
         sCtrlAV9WWPForm = "";
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short AV11WWPFormElementId ;
      private short AV7SessionId ;
      private short wcpOAV11WWPFormElementId ;
      private short wcpOAV7SessionId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV13WWP_DynamicFormDataType ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int tblTableactions_Visible ;
      private int idxLst ;
      private string AV8WWPDynamicFormMode ;
      private string wcpOAV8WWPDynamicFormMode ;
      private string Dvelop_confirmpanel_btndeleteelement_Result ;
      private string Settings_modal_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divLabelcell_Internalname ;
      private string divLabelcell_Class ;
      private string lblLabel_Internalname ;
      private string lblLabel_Caption ;
      private string lblLabel_Jsonclick ;
      private string lblLabel_Class ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string Btnmoveup_Caption ;
      private string Btnmoveup_Internalname ;
      private string Btnmovedown_Caption ;
      private string Btnmovedown_Internalname ;
      private string Btnsettings_Caption ;
      private string Btnsettings_Internalname ;
      private string Btndeleteelement_Caption ;
      private string Btndeleteelement_Internalname ;
      private string Btnmoveup_Tooltiptext ;
      private string Btnmoveup_Beforeiconclass ;
      private string Btnmovedown_Tooltiptext ;
      private string Btnmovedown_Beforeiconclass ;
      private string tblTableactions_Internalname ;
      private string sStyleString ;
      private string tblTablesettings_modal_Internalname ;
      private string Settings_modal_Width ;
      private string Settings_modal_Title ;
      private string Settings_modal_Confirmtype ;
      private string Settings_modal_Bodytype ;
      private string Settings_modal_Internalname ;
      private string tblTabledvelop_confirmpanel_btndeleteelement_Internalname ;
      private string Dvelop_confirmpanel_btndeleteelement_Title ;
      private string Dvelop_confirmpanel_btndeleteelement_Confirmationtext ;
      private string Dvelop_confirmpanel_btndeleteelement_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_btndeleteelement_Nobuttoncaption ;
      private string Dvelop_confirmpanel_btndeleteelement_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_btndeleteelement_Yesbuttonposition ;
      private string Dvelop_confirmpanel_btndeleteelement_Confirmtype ;
      private string Dvelop_confirmpanel_btndeleteelement_Internalname ;
      private string Btnmoveup_Class ;
      private string Btnmovedown_Class ;
      private string Btndeleteelement_Tooltiptext ;
      private string Btndeleteelement_Beforeiconclass ;
      private string Btndeleteelement_Class ;
      private string Btnsettings_Tooltiptext ;
      private string Btnsettings_Beforeiconclass ;
      private string Btnsettings_Class ;
      private string sCtrlAV8WWPDynamicFormMode ;
      private string sCtrlAV11WWPFormElementId ;
      private string sCtrlAV7SessionId ;
      private string sCtrlAV9WWPForm ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV5IsFirstElement ;
      private bool AV6IsLastElement ;
      private bool AV14ParentIsGridMultipleData ;
      private bool AV12NeedToReloadWC ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool Btnmoveup_Visible ;
      private bool Btnmovedown_Visible ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXUserControl ucBtnmoveup ;
      private GXUserControl ucBtnmovedown ;
      private GXUserControl ucBtnsettings ;
      private GXUserControl ucBtndeleteelement ;
      private GXUserControl ucSettings_modal ;
      private GXUserControl ucDvelop_confirmpanel_btndeleteelement ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV9WWPForm ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP3_WWPForm ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV10WWPFormElement ;
      private SdtSDT_DynamicFormTranslation AV20SDT_DynamicFormTranslation ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form GXt_SdtWWP_Form2 ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element GXt_SdtWWP_Form_Element1 ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_LabelMetadata AV15WWP_DF_LabelMetadata ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
