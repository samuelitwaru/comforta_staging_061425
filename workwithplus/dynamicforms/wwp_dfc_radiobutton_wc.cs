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
   public class wwp_dfc_radiobutton_wc : GXWebComponent
   {
      public wwp_dfc_radiobutton_wc( )
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

      public wwp_dfc_radiobutton_wc( IGxContext context )
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
         this.AV15WWPDynamicFormMode = aP0_WWPDynamicFormMode;
         this.AV18WWPFormElementId = aP1_WWPFormElementId;
         this.AV12SessionId = aP2_SessionId;
         this.AV16WWPForm = aP3_WWPForm;
         ExecuteImpl();
         aP3_WWPForm=this.AV16WWPForm;
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
         radavData = new GXRadio();
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
                  AV15WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
                  AssignAttri(sPrefix, false, "AV15WWPDynamicFormMode", AV15WWPDynamicFormMode);
                  AV18WWPFormElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV18WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV18WWPFormElementId), 4, 0));
                  AV12SessionId = (short)(Math.Round(NumberUtil.Val( GetPar( "SessionId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV12SessionId", StringUtil.LTrimStr( (decimal)(AV12SessionId), 4, 0));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV16WWPForm);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV15WWPDynamicFormMode,(short)AV18WWPFormElementId,(short)AV12SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV16WWPForm});
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
            PA312( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS312( ) ;
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
            context.SendWebValue( context.GetMessage( "WWP_Dynamic Form Creation_Radiobutton_WC", "")) ;
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
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_dfc_radiobutton_wc.aspx"+UrlEncode(StringUtil.RTrim(AV15WWPDynamicFormMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV18WWPFormElementId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV12SessionId,4,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.dynamicforms.wwp_dfc_radiobutton_wc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISFIRSTELEMENT", AV9IsFirstElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISFIRSTELEMENT", GetSecureSignedToken( sPrefix, AV9IsFirstElement, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISLASTELEMENT", AV10IsLastElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISLASTELEMENT", GetSecureSignedToken( sPrefix, AV10IsLastElement, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vPARENTISGRIDMULTIPLEDATA", AV19ParentIsGridMultipleData);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPARENTISGRIDMULTIPLEDATA", GetSecureSignedToken( sPrefix, AV19ParentIsGridMultipleData, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWP_DYNAMICFORMDATATYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14WWP_DynamicFormDataType), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DYNAMICFORMDATATYPE", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV14WWP_DynamicFormDataType), "Z9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_DYNAMICFORMTRANSLATION", AV23SDT_DynamicFormTranslation);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_DYNAMICFORMTRANSLATION", AV23SDT_DynamicFormTranslation);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDT_DYNAMICFORMTRANSLATION", GetSecureSignedToken( sPrefix, AV23SDT_DynamicFormTranslation, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV15WWPDynamicFormMode", StringUtil.RTrim( wcpOAV15WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV18WWPFormElementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV18WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV12SessionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV12SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISFIRSTELEMENT", AV9IsFirstElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISFIRSTELEMENT", GetSecureSignedToken( sPrefix, AV9IsFirstElement, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISLASTELEMENT", AV10IsLastElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISLASTELEMENT", GetSecureSignedToken( sPrefix, AV10IsLastElement, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORMELEMENT", AV17WWPFormElement);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORMELEMENT", AV17WWPFormElement);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vNEEDTORELOADWC", AV11NeedToReloadWC);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vPARENTISGRIDMULTIPLEDATA", AV19ParentIsGridMultipleData);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPARENTISGRIDMULTIPLEDATA", GetSecureSignedToken( sPrefix, AV19ParentIsGridMultipleData, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWP_DYNAMICFORMDATATYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14WWP_DynamicFormDataType), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DYNAMICFORMDATATYPE", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV14WWP_DynamicFormDataType), "Z9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vOLDTITLE", AV7OldTitle);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_DYNAMICFORMTRANSLATION", AV23SDT_DynamicFormTranslation);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_DYNAMICFORMTRANSLATION", AV23SDT_DynamicFormTranslation);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDT_DYNAMICFORMTRANSLATION", GetSecureSignedToken( sPrefix, AV23SDT_DynamicFormTranslation, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV15WWPDynamicFormMode));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORM", AV16WWPForm);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORM", AV16WWPForm);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_BTNDELETEELEMENT_Result", StringUtil.RTrim( Dvelop_confirmpanel_btndeleteelement_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"SETTINGS_MODAL_Result", StringUtil.RTrim( Settings_modal_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENT_Wwpformelementmetadata", AV17WWPFormElement.gxTpr_Wwpformelementmetadata);
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_BTNDELETEELEMENT_Result", StringUtil.RTrim( Dvelop_confirmpanel_btndeleteelement_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"SETTINGS_MODAL_Result", StringUtil.RTrim( Settings_modal_Result));
      }

      protected void RenderHtmlCloseForm312( )
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
         return "WorkWithPlus.DynamicForms.WWP_DFC_Radiobutton_WC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WWP_Dynamic Form Creation_Radiobutton_WC", "") ;
      }

      protected void WB310( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "workwithplus.dynamicforms.wwp_dfc_radiobutton_wc.aspx");
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
            GxWebStd.gx_div_start( context, divDatatitlecell_Internalname, divDatatitlecell_Visible, 0, "px", 0, "px", divDatatitlecell_Class, "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDatatitle_Internalname, lblDatatitle_Caption, "", "", lblDatatitle_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DFC_Radiobutton_WC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDatacellname_Internalname, 1, 0, "px", 0, "px", divDatacellname_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+radavData_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", radavData.Caption, " AttributeLabel RadioWithDynamicOrientationLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Radio button */
            ClassString = "Attribute RadioWithDynamicOrientation";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavData, radavData_Internalname, StringUtil.RTrim( AV5Data), "", 1, 1, 0, 0, StyleString, ClassString, "", "", 0, radavData_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,14);\"", "HLP_WorkWithPlus/DynamicForms/WWP_DFC_Radiobutton_WC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 TableDynAddElementActionsCell", "end", "top", "", "", "div");
            wb_table1_17_312( true) ;
         }
         else
         {
            wb_table1_17_312( false) ;
         }
         return  ;
      }

      protected void wb_table1_17_312e( bool wbgen )
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
            wb_table2_30_312( true) ;
         }
         else
         {
            wb_table2_30_312( false) ;
         }
         return  ;
      }

      protected void wb_table2_30_312e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table3_35_312( true) ;
         }
         else
         {
            wb_table3_35_312( false) ;
         }
         return  ;
      }

      protected void wb_table3_35_312e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, sPrefix+"W0041"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0041"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0041"+"");
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

      protected void START312( )
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
            Form.Meta.addItem("description", context.GetMessage( "WWP_Dynamic Form Creation_Radiobutton_WC", ""), 0) ;
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
               STRUP310( ) ;
            }
         }
      }

      protected void WS312( )
      {
         START312( ) ;
         EVT312( ) ;
      }

      protected void EVT312( )
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
                                 STRUP310( ) ;
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
                                 STRUP310( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Dvelop_confirmpanel_btndeleteelement.Close */
                                    E11312 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "SETTINGS_MODAL.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP310( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Settings_modal.Close */
                                    E12312 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "SETTINGS_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP310( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Settings_modal.Onloadcomponent */
                                    E13312 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP310( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E14312 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP310( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E15312 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOMOVEUP'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP310( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoMoveUp' */
                                    E16312 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOMOVEDOWN'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP310( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoMoveDown' */
                                    E17312 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP310( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E18312 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP310( ) ;
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
                                 STRUP310( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = radavData_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
                        if ( nCmpId == 41 )
                        {
                           OldWwpaux_wc = cgiGet( sPrefix+"W0041");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess(sPrefix+"W0041", "", sEvt);
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

      protected void WE312( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm312( ) ;
            }
         }
      }

      protected void PA312( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.dynamicforms.wwp_dfc_radiobutton_wc.aspx")), "workwithplus.dynamicforms.wwp_dfc_radiobutton_wc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.dynamicforms.wwp_dfc_radiobutton_wc.aspx")))) ;
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
               GX_FocusControl = radavData_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
         AssignAttri(sPrefix, false, "AV5Data", AV5Data);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF312( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF312( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E15312 ();
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
            E18312 ();
            WB310( ) ;
         }
      }

      protected void send_integrity_lvl_hashes312( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISFIRSTELEMENT", AV9IsFirstElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISFIRSTELEMENT", GetSecureSignedToken( sPrefix, AV9IsFirstElement, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISLASTELEMENT", AV10IsLastElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISLASTELEMENT", GetSecureSignedToken( sPrefix, AV10IsLastElement, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vPARENTISGRIDMULTIPLEDATA", AV19ParentIsGridMultipleData);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPARENTISGRIDMULTIPLEDATA", GetSecureSignedToken( sPrefix, AV19ParentIsGridMultipleData, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWP_DYNAMICFORMDATATYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14WWP_DynamicFormDataType), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DYNAMICFORMDATATYPE", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV14WWP_DynamicFormDataType), "Z9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_DYNAMICFORMTRANSLATION", AV23SDT_DynamicFormTranslation);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_DYNAMICFORMTRANSLATION", AV23SDT_DynamicFormTranslation);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDT_DYNAMICFORMTRANSLATION", GetSecureSignedToken( sPrefix, AV23SDT_DynamicFormTranslation, context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP310( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E14312 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOAV15WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV15WWPDynamicFormMode");
            wcpOAV18WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV18WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV12SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV12SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Dvelop_confirmpanel_btndeleteelement_Result = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_BTNDELETEELEMENT_Result");
            Settings_modal_Result = cgiGet( sPrefix+"SETTINGS_MODAL_Result");
            /* Read variables values. */
            AV5Data = cgiGet( radavData_Internalname);
            AssignAttri(sPrefix, false, "AV5Data", AV5Data);
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
         E14312 ();
         if (returnInSub) return;
      }

      protected void E14312( )
      {
         /* Start Routine */
         returnInSub = false;
         AV23SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformid = AV16WWPForm.gxTpr_Wwpformid;
         AV23SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformversionnumber = AV16WWPForm.gxTpr_Wwpformversionnumber;
         AV23SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformelementid = AV18WWPFormElementId;
         new prc_getdynamicformtranslation(context ).execute( ref  AV23SDT_DynamicFormTranslation) ;
         GXt_SdtWWP_Form_Element1 = AV17WWPFormElement;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getelementbyid(context ).execute( ref  AV16WWPForm,  AV18WWPFormElementId, out  GXt_SdtWWP_Form_Element1) ;
         AV17WWPFormElement = GXt_SdtWWP_Form_Element1;
         AV14WWP_DynamicFormDataType = AV17WWPFormElement.gxTpr_Wwpformelementdatatype;
         AssignAttri(sPrefix, false, "AV14WWP_DynamicFormDataType", StringUtil.LTrimStr( (decimal)(AV14WWP_DynamicFormDataType), 2, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DYNAMICFORMDATATYPE", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV14WWP_DynamicFormDataType), "Z9"), context));
         /* Execute user subroutine: 'LOAD TITLE AND METADATA' */
         S112 ();
         if (returnInSub) return;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_dfc_canmoveelement(context ).execute(  AV16WWPForm,  AV17WWPFormElement, out  AV9IsFirstElement, out  AV10IsLastElement) ;
         AssignAttri(sPrefix, false, "AV9IsFirstElement", AV9IsFirstElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISFIRSTELEMENT", GetSecureSignedToken( sPrefix, AV9IsFirstElement, context));
         AssignAttri(sPrefix, false, "AV10IsLastElement", AV10IsLastElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISLASTELEMENT", GetSecureSignedToken( sPrefix, AV10IsLastElement, context));
         if ( new GeneXus.Programs.workwithplus.dynamicforms.wwp_dfc_showsmallbuttons(context).executeUdp( ref  AV16WWPForm,  AV17WWPFormElement.gxTpr_Wwpformelementparentid,  false, out  AV19ParentIsGridMultipleData) )
         {
            Btnmoveup_Caption = "";
            ucBtnmoveup.SendProperty(context, sPrefix, false, Btnmoveup_Internalname, "Caption", Btnmoveup_Caption);
            Btnmovedown_Caption = "";
            ucBtnmovedown.SendProperty(context, sPrefix, false, Btnmovedown_Internalname, "Caption", Btnmovedown_Caption);
            Btnsettings_Caption = "";
            ucBtnsettings.SendProperty(context, sPrefix, false, Btnsettings_Internalname, "Caption", Btnsettings_Caption);
            Btndeleteelement_Caption = "";
            ucBtndeleteelement.SendProperty(context, sPrefix, false, Btndeleteelement_Internalname, "Caption", Btndeleteelement_Caption);
            if ( AV19ParentIsGridMultipleData )
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

      protected void E15312( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E16312( )
      {
         /* 'DoMoveUp' Routine */
         returnInSub = false;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_dfc_moveelement(context ).execute(  AV12SessionId,  AV18WWPFormElementId,  true) ;
         this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "DynamicForms_RefreshParentGrid", new Object[] {(string)divLayoutmaintable_Internalname,(string)"LayoutMainTable"}, false);
      }

      protected void E17312( )
      {
         /* 'DoMoveDown' Routine */
         returnInSub = false;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_dfc_moveelement(context ).execute(  AV12SessionId,  AV18WWPFormElementId,  false) ;
         this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "DynamicForms_RefreshParentGrid", new Object[] {(string)divLayoutmaintable_Internalname,(string)"LayoutMainTable"}, false);
      }

      protected void E11312( )
      {
         /* Dvelop_confirmpanel_btndeleteelement_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_btndeleteelement_Result, "Yes") == 0 )
         {
            GXt_SdtWWP_Form2 = AV16WWPForm;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadformdefinition(context ).execute(  AV12SessionId, out  GXt_SdtWWP_Form2) ;
            AV16WWPForm = GXt_SdtWWP_Form2;
            GXt_SdtWWP_Form_Element1 = AV17WWPFormElement;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getelementbyid(context ).execute( ref  AV16WWPForm,  AV18WWPFormElementId, out  GXt_SdtWWP_Form_Element1) ;
            AV17WWPFormElement = GXt_SdtWWP_Form_Element1;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_dfc_deleteelement(context ).execute( ref  AV16WWPForm, ref  AV17WWPFormElement) ;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_saveformdefinition(context ).execute(  AV12SessionId,  AV16WWPForm) ;
            this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "DynamicForms_RefreshParentGrid", new Object[] {(string)divLayoutmaintable_Internalname,(string)"LayoutMainTable"}, false);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV16WWPForm", AV16WWPForm);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV17WWPFormElement", AV17WWPFormElement);
      }

      protected void E13312( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)sPrefix+"W0041",(string)"",(string)"UPD",(short)0,(short)AV18WWPFormElementId,(short)AV12SessionId});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0041"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S132( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
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
      }

      protected void S122( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         tblTableactions_Visible = (((StringUtil.StrCmp(AV15WWPDynamicFormMode, "DSP")!=0)) ? 1 : 0);
         AssignProp(sPrefix, false, tblTableactions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTableactions_Visible), 5, 0), true);
      }

      protected void S112( )
      {
         /* 'LOAD TITLE AND METADATA' Routine */
         returnInSub = false;
         if ( AV17WWPFormElement.gxTpr_Wwpformelementcaption == 2 )
         {
            lblDatatitle_Caption = AV17WWPFormElement.gxTpr_Wwpformelementtitle;
            AssignProp(sPrefix, false, lblDatatitle_Internalname, "Caption", lblDatatitle_Caption, true);
            divDatatitlecell_Visible = 1;
            AssignProp(sPrefix, false, divDatatitlecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDatatitlecell_Visible), 5, 0), true);
         }
         else
         {
            divDatatitlecell_Visible = 0;
            AssignProp(sPrefix, false, divDatatitlecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDatatitlecell_Visible), 5, 0), true);
         }
         AV6DataCellNameClass = "DataContentCell DscTop";
         if ( AV17WWPFormElement.gxTpr_Wwpformelementcaption != 1 )
         {
            AV6DataCellNameClass += " DataContentCellNoLabel";
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV23SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationvalue)) )
         {
            radavData.Caption = AV17WWPFormElement.gxTpr_Wwpformelementtitle;
            AssignProp(sPrefix, false, radavData_Internalname, "Caption", radavData.Caption, true);
         }
         else
         {
            radavData.Caption = AV23SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationvalue;
            AssignProp(sPrefix, false, radavData_Internalname, "Caption", radavData.Caption, true);
         }
         AV13WWP_DF_CharMetadata.FromJSonString(AV17WWPFormElement.gxTpr_Wwpformelementmetadata, null);
         AV5Data = AV13WWP_DF_CharMetadata.gxTpr_Defaultvalue;
         AssignAttri(sPrefix, false, "AV5Data", AV5Data);
         if ( AV13WWP_DF_CharMetadata.gxTpr_Isrequired )
         {
            AV6DataCellNameClass = "Required" + AV6DataCellNameClass;
         }
         radavData.removeAllItems();
         radavData.addItem("#Dummy#", "", 0);
         AV8i = 1;
         while ( AV8i <= AV13WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Options.Count )
         {
            radavData.addItem(((string)AV13WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Options.Item(AV8i)), ((string)AV13WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Options.Item(AV8i)), 0);
            AV8i = (short)(AV8i+1);
         }
         divDatacellname_Class = AV6DataCellNameClass;
         AssignProp(sPrefix, false, divDatacellname_Internalname, "Class", divDatacellname_Class, true);
         divDatatitlecell_Class = AV6DataCellNameClass;
         AssignProp(sPrefix, false, divDatatitlecell_Internalname, "Class", divDatatitlecell_Class, true);
         this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "RadioButton_SetOrientation", new Object[] {(string)radavData_Internalname,AV13WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Radiobutton.gxTpr_Directionvertical}, false);
      }

      protected void E12312( )
      {
         /* Settings_modal_Close Routine */
         returnInSub = false;
         AV7OldTitle = AV17WWPFormElement.gxTpr_Wwpformelementtitle;
         AssignAttri(sPrefix, false, "AV7OldTitle", AV7OldTitle);
         if ( StringUtil.StrCmp(Settings_modal_Result, "OK") == 0 )
         {
            GXt_SdtWWP_Form2 = AV16WWPForm;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadformdefinition(context ).execute(  AV12SessionId, out  GXt_SdtWWP_Form2) ;
            AV16WWPForm = GXt_SdtWWP_Form2;
            GXt_SdtWWP_Form_Element1 = AV17WWPFormElement;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getelementbyid(context ).execute( ref  AV16WWPForm,  AV18WWPFormElementId, out  GXt_SdtWWP_Form_Element1) ;
            AV17WWPFormElement = GXt_SdtWWP_Form_Element1;
            /* Execute user subroutine: 'NEED TO RELOAD WC' */
            S142 ();
            if (returnInSub) return;
            if ( AV11NeedToReloadWC )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV16WWPForm", AV16WWPForm);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV17WWPFormElement", AV17WWPFormElement);
         radavData.CurrentValue = StringUtil.RTrim( AV5Data);
         AssignProp(sPrefix, false, radavData_Internalname, "Values", radavData.ToJavascriptSource(), true);
      }

      protected void S142( )
      {
         /* 'NEED TO RELOAD WC' Routine */
         returnInSub = false;
         AV11NeedToReloadWC = (bool)((AV19ParentIsGridMultipleData||(AV17WWPFormElement.gxTpr_Wwpformelementdatatype!=AV14WWP_DynamicFormDataType)));
         AssignAttri(sPrefix, false, "AV11NeedToReloadWC", AV11NeedToReloadWC);
         if ( ! AV11NeedToReloadWC && ( AV17WWPFormElement.gxTpr_Wwpformelementcaption == 1 ) && ( StringUtil.StrCmp(AV7OldTitle, AV17WWPFormElement.gxTpr_Wwpformelementtitle) != 0 ) )
         {
            AV11NeedToReloadWC = true;
            AssignAttri(sPrefix, false, "AV11NeedToReloadWC", AV11NeedToReloadWC);
         }
         if ( ! AV11NeedToReloadWC )
         {
            AV13WWP_DF_CharMetadata.FromJSonString(AV17WWPFormElement.gxTpr_Wwpformelementmetadata, null);
            AV11NeedToReloadWC = (bool)(((AV13WWP_DF_CharMetadata.gxTpr_Controltype!=4)||(AV13WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Controltype!=3)));
            AssignAttri(sPrefix, false, "AV11NeedToReloadWC", AV11NeedToReloadWC);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E18312( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table3_35_312( bool wbgen )
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
            wb_table3_35_312e( true) ;
         }
         else
         {
            wb_table3_35_312e( false) ;
         }
      }

      protected void wb_table2_30_312( bool wbgen )
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
            wb_table2_30_312e( true) ;
         }
         else
         {
            wb_table2_30_312e( false) ;
         }
      }

      protected void wb_table1_17_312( bool wbgen )
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
            wb_table1_17_312e( true) ;
         }
         else
         {
            wb_table1_17_312e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV15WWPDynamicFormMode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV15WWPDynamicFormMode", AV15WWPDynamicFormMode);
         AV18WWPFormElementId = Convert.ToInt16(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV18WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV18WWPFormElementId), 4, 0));
         AV12SessionId = Convert.ToInt16(getParm(obj,2));
         AssignAttri(sPrefix, false, "AV12SessionId", StringUtil.LTrimStr( (decimal)(AV12SessionId), 4, 0));
         AV16WWPForm = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)getParm(obj,3);
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
         PA312( ) ;
         WS312( ) ;
         WE312( ) ;
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
         sCtrlAV15WWPDynamicFormMode = (string)((string)getParm(obj,0));
         sCtrlAV18WWPFormElementId = (string)((string)getParm(obj,1));
         sCtrlAV12SessionId = (string)((string)getParm(obj,2));
         sCtrlAV16WWPForm = (string)((string)getParm(obj,3));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA312( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "workwithplus\\dynamicforms\\wwp_dfc_radiobutton_wc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA312( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV15WWPDynamicFormMode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV15WWPDynamicFormMode", AV15WWPDynamicFormMode);
            AV18WWPFormElementId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV18WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV18WWPFormElementId), 4, 0));
            AV12SessionId = Convert.ToInt16(getParm(obj,4));
            AssignAttri(sPrefix, false, "AV12SessionId", StringUtil.LTrimStr( (decimal)(AV12SessionId), 4, 0));
            AV16WWPForm = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)getParm(obj,5);
         }
         wcpOAV15WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV15WWPDynamicFormMode");
         wcpOAV18WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV18WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV12SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV12SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV15WWPDynamicFormMode, wcpOAV15WWPDynamicFormMode) != 0 ) || ( AV18WWPFormElementId != wcpOAV18WWPFormElementId ) || ( AV12SessionId != wcpOAV12SessionId ) ) )
         {
            setjustcreated();
         }
         wcpOAV15WWPDynamicFormMode = AV15WWPDynamicFormMode;
         wcpOAV18WWPFormElementId = AV18WWPFormElementId;
         wcpOAV12SessionId = AV12SessionId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV15WWPDynamicFormMode = cgiGet( sPrefix+"AV15WWPDynamicFormMode_CTRL");
         if ( StringUtil.Len( sCtrlAV15WWPDynamicFormMode) > 0 )
         {
            AV15WWPDynamicFormMode = cgiGet( sCtrlAV15WWPDynamicFormMode);
            AssignAttri(sPrefix, false, "AV15WWPDynamicFormMode", AV15WWPDynamicFormMode);
         }
         else
         {
            AV15WWPDynamicFormMode = cgiGet( sPrefix+"AV15WWPDynamicFormMode_PARM");
         }
         sCtrlAV18WWPFormElementId = cgiGet( sPrefix+"AV18WWPFormElementId_CTRL");
         if ( StringUtil.Len( sCtrlAV18WWPFormElementId) > 0 )
         {
            AV18WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV18WWPFormElementId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV18WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV18WWPFormElementId), 4, 0));
         }
         else
         {
            AV18WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV18WWPFormElementId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV12SessionId = cgiGet( sPrefix+"AV12SessionId_CTRL");
         if ( StringUtil.Len( sCtrlAV12SessionId) > 0 )
         {
            AV12SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV12SessionId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV12SessionId", StringUtil.LTrimStr( (decimal)(AV12SessionId), 4, 0));
         }
         else
         {
            AV12SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV12SessionId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV16WWPForm = cgiGet( sPrefix+"AV16WWPForm_CTRL");
         if ( StringUtil.Len( sCtrlAV16WWPForm) > 0 )
         {
            AV16WWPForm.FromXml(cgiGet( sCtrlAV16WWPForm), null, "", "");
         }
         else
         {
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"AV16WWPForm_PARM"), AV16WWPForm);
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
         PA312( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS312( ) ;
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
         WS312( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV15WWPDynamicFormMode_PARM", StringUtil.RTrim( AV15WWPDynamicFormMode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV15WWPDynamicFormMode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV15WWPDynamicFormMode_CTRL", StringUtil.RTrim( sCtrlAV15WWPDynamicFormMode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV18WWPFormElementId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV18WWPFormElementId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV18WWPFormElementId_CTRL", StringUtil.RTrim( sCtrlAV18WWPFormElementId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV12SessionId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV12SessionId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV12SessionId_CTRL", StringUtil.RTrim( sCtrlAV12SessionId));
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"AV16WWPForm_PARM", AV16WWPForm);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"AV16WWPForm_PARM", AV16WWPForm);
         }
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV16WWPForm)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV16WWPForm_CTRL", StringUtil.RTrim( sCtrlAV16WWPForm));
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
         WE312( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202562016575478", true, true);
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
         context.AddJavascriptSource("workwithplus/dynamicforms/wwp_dfc_radiobutton_wc.js", "?202562016575479", false, true);
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
         radavData.Name = "vDATA";
         radavData.WebTags = "";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblDatatitle_Internalname = sPrefix+"DATATITLE";
         divDatatitlecell_Internalname = sPrefix+"DATATITLECELL";
         radavData_Internalname = sPrefix+"vDATA";
         divDatacellname_Internalname = sPrefix+"DATACELLNAME";
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
         radavData_Jsonclick = "";
         radavData.Caption = context.GetMessage( "Data", "");
         divDatacellname_Class = "col-xs-12 DataContentCell DscTop";
         lblDatatitle_Caption = context.GetMessage( "Title", "");
         divDatatitlecell_Class = "col-xs-12";
         divDatatitlecell_Visible = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"radavData"},{"av":"AV5Data","fld":"vDATA"},{"av":"AV9IsFirstElement","fld":"vISFIRSTELEMENT","hsh":true},{"av":"AV10IsLastElement","fld":"vISLASTELEMENT","hsh":true},{"av":"AV19ParentIsGridMultipleData","fld":"vPARENTISGRIDMULTIPLEDATA","hsh":true},{"av":"AV14WWP_DynamicFormDataType","fld":"vWWP_DYNAMICFORMDATATYPE","pic":"Z9","hsh":true},{"av":"AV23SDT_DynamicFormTranslation","fld":"vSDT_DYNAMICFORMTRANSLATION","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"Btnmoveup_Visible","ctrl":"BTNMOVEUP","prop":"Visible"},{"av":"Btnmovedown_Visible","ctrl":"BTNMOVEDOWN","prop":"Visible"}]}""");
         setEventMetadata("'DOMOVEUP'","""{"handler":"E16312","iparms":[{"av":"AV12SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV18WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"}]}""");
         setEventMetadata("'DOMOVEDOWN'","""{"handler":"E17312","iparms":[{"av":"AV12SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV18WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_BTNDELETEELEMENT.CLOSE","""{"handler":"E11312","iparms":[{"av":"Dvelop_confirmpanel_btndeleteelement_Result","ctrl":"DVELOP_CONFIRMPANEL_BTNDELETEELEMENT","prop":"Result"},{"av":"AV12SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV18WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_BTNDELETEELEMENT.CLOSE",""","oparms":[{"av":"AV16WWPForm","fld":"vWWPFORM"},{"av":"AV17WWPFormElement","fld":"vWWPFORMELEMENT"}]}""");
         setEventMetadata("SETTINGS_MODAL.ONLOADCOMPONENT","""{"handler":"E13312","iparms":[{"av":"AV18WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV12SessionId","fld":"vSESSIONID","pic":"ZZZ9"}]""");
         setEventMetadata("SETTINGS_MODAL.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("SETTINGS_MODAL.CLOSE","""{"handler":"E12312","iparms":[{"av":"AV17WWPFormElement","fld":"vWWPFORMELEMENT"},{"av":"Settings_modal_Result","ctrl":"SETTINGS_MODAL","prop":"Result"},{"av":"AV12SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV18WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV11NeedToReloadWC","fld":"vNEEDTORELOADWC"},{"av":"AV19ParentIsGridMultipleData","fld":"vPARENTISGRIDMULTIPLEDATA","hsh":true},{"av":"AV14WWP_DynamicFormDataType","fld":"vWWP_DYNAMICFORMDATATYPE","pic":"Z9","hsh":true},{"av":"AV7OldTitle","fld":"vOLDTITLE"},{"av":"AV23SDT_DynamicFormTranslation","fld":"vSDT_DYNAMICFORMTRANSLATION","hsh":true}]""");
         setEventMetadata("SETTINGS_MODAL.CLOSE",""","oparms":[{"av":"AV7OldTitle","fld":"vOLDTITLE"},{"av":"AV16WWPForm","fld":"vWWPFORM"},{"av":"AV17WWPFormElement","fld":"vWWPFORMELEMENT"},{"av":"AV11NeedToReloadWC","fld":"vNEEDTORELOADWC"},{"av":"lblDatatitle_Caption","ctrl":"DATATITLE","prop":"Caption"},{"av":"divDatatitlecell_Visible","ctrl":"DATATITLECELL","prop":"Visible"},{"av":"radavData"},{"av":"AV5Data","fld":"vDATA"},{"av":"divDatacellname_Class","ctrl":"DATACELLNAME","prop":"Class"},{"av":"divDatatitlecell_Class","ctrl":"DATATITLECELL","prop":"Class"}]}""");
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
         AV16WWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         wcpOAV15WWPDynamicFormMode = "";
         Dvelop_confirmpanel_btndeleteelement_Result = "";
         Settings_modal_Result = "";
         AV17WWPFormElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV23SDT_DynamicFormTranslation = new SdtSDT_DynamicFormTranslation(context);
         AV7OldTitle = "";
         GX_FocusControl = "";
         lblDatatitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV5Data = "";
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
         AV6DataCellNameClass = "";
         AV13WWP_DF_CharMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata(context);
         GXt_SdtWWP_Form2 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         GXt_SdtWWP_Form_Element1 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         sStyleString = "";
         ucSettings_modal = new GXUserControl();
         ucDvelop_confirmpanel_btndeleteelement = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV15WWPDynamicFormMode = "";
         sCtrlAV18WWPFormElementId = "";
         sCtrlAV12SessionId = "";
         sCtrlAV16WWPForm = "";
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short AV18WWPFormElementId ;
      private short AV12SessionId ;
      private short wcpOAV18WWPFormElementId ;
      private short wcpOAV12SessionId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV14WWP_DynamicFormDataType ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short AV8i ;
      private short nGXWrapped ;
      private int divDatatitlecell_Visible ;
      private int tblTableactions_Visible ;
      private int idxLst ;
      private string AV15WWPDynamicFormMode ;
      private string wcpOAV15WWPDynamicFormMode ;
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
      private string divDatatitlecell_Internalname ;
      private string divDatatitlecell_Class ;
      private string lblDatatitle_Internalname ;
      private string lblDatatitle_Caption ;
      private string lblDatatitle_Jsonclick ;
      private string divDatacellname_Internalname ;
      private string divDatacellname_Class ;
      private string radavData_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string TempTags ;
      private string radavData_Jsonclick ;
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
      private string sCtrlAV15WWPDynamicFormMode ;
      private string sCtrlAV18WWPFormElementId ;
      private string sCtrlAV12SessionId ;
      private string sCtrlAV16WWPForm ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV9IsFirstElement ;
      private bool AV10IsLastElement ;
      private bool AV19ParentIsGridMultipleData ;
      private bool AV11NeedToReloadWC ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool Btnmoveup_Visible ;
      private bool Btnmovedown_Visible ;
      private string AV7OldTitle ;
      private string AV5Data ;
      private string AV6DataCellNameClass ;
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
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV16WWPForm ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP3_WWPForm ;
      private GXRadio radavData ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV17WWPFormElement ;
      private SdtSDT_DynamicFormTranslation AV23SDT_DynamicFormTranslation ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata AV13WWP_DF_CharMetadata ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form GXt_SdtWWP_Form2 ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element GXt_SdtWWP_Form_Element1 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
