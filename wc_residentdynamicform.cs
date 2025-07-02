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
   public class wc_residentdynamicform : GXWebComponent
   {
      public wc_residentdynamicform( )
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

      public wc_residentdynamicform( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPFormReferenceName ,
                           int aP1_WWPFormInstanceId ,
                           string aP2_WWPDynamicFormMode ,
                           string aP3_AccessToken )
      {
         this.AV14WWPFormReferenceName = aP0_WWPFormReferenceName;
         this.AV9WWPFormInstanceId = aP1_WWPFormInstanceId;
         this.AV8WWPDynamicFormMode = aP2_WWPDynamicFormMode;
         this.AV28AccessToken = aP3_AccessToken;
         ExecuteImpl();
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
               gxfirstwebparm = GetFirstPar( "WWPFormReferenceName");
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
                  AV14WWPFormReferenceName = GetPar( "WWPFormReferenceName");
                  AssignAttri(sPrefix, false, "AV14WWPFormReferenceName", AV14WWPFormReferenceName);
                  AV9WWPFormInstanceId = (int)(Math.Round(NumberUtil.Val( GetPar( "WWPFormInstanceId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV9WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(AV9WWPFormInstanceId), 6, 0));
                  AV8WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
                  AssignAttri(sPrefix, false, "AV8WWPDynamicFormMode", AV8WWPDynamicFormMode);
                  AV28AccessToken = GetPar( "AccessToken");
                  AssignAttri(sPrefix, false, "AV28AccessToken", AV28AccessToken);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV14WWPFormReferenceName,(int)AV9WWPFormInstanceId,(string)AV8WWPDynamicFormMode,(string)AV28AccessToken});
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
                  gxfirstwebparm = GetFirstPar( "WWPFormReferenceName");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "WWPFormReferenceName");
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
            PA7J2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS7J2( ) ;
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
            FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
            context.WriteHtmlText( " "+"class=\"form-horizontal ResidentForm\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal ResidentForm\" data-gx-class=\"form-horizontal ResidentForm\" novalidate action=\""+formatLink("wc_residentdynamicform.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV14WWPFormReferenceName)),UrlEncode(StringUtil.LTrimStr(AV9WWPFormInstanceId,6,0)),UrlEncode(StringUtil.RTrim(AV8WWPDynamicFormMode)),UrlEncode(StringUtil.RTrim(AV28AccessToken))}, new string[] {"WWPFormReferenceName","WWPFormInstanceId","WWPDynamicFormMode","AccessToken"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal ResidentForm", true);
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
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal ResidentForm" : Form.Class)+"-fx");
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vFORMNAME", AV32FormName);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFORMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV32FormName, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vRESIDENTGUID", AV27ResidentGUID);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESIDENTGUID", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV27ResidentGUID, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vRESIDENTNAME", AV30ResidentName);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESIDENTNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV30ResidentName, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV14WWPFormReferenceName", wcpOAV14WWPFormReferenceName);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV9WWPFormInstanceId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV9WWPFormInstanceId), 6, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8WWPDynamicFormMode", StringUtil.RTrim( wcpOAV8WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV28AccessToken", wcpOAV28AccessToken);
         GxWebStd.gx_hidden_field( context, sPrefix+"vFORMNAME", AV32FormName);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFORMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV32FormName, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV8WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMREFERENCENAME", A208WWPFormReferenceName);
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMREFERENCENAME", AV14WWPFormReferenceName);
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORMINSTANCE", AV7WWPFormInstance);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORMINSTANCE", AV7WWPFormInstance);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"WWPFORMISWIZARD", A232WWPFormIsWizard);
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMTITLE", A209WWPFormTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"vDEFAULTSTEP", AV22DefaultStep);
         GxWebStd.gx_hidden_field( context, sPrefix+"vACCESSTOKEN", AV28AccessToken);
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMINSTANCEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9WWPFormInstanceId), 6, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vEXECUTEENTEREVENT", AV23ExecuteEnterEvent);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vWWPFORMISWIZARD", AV11WWPFormIsWizard);
         GxWebStd.gx_hidden_field( context, sPrefix+"vRESIDENTGUID", AV27ResidentGUID);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESIDENTGUID", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV27ResidentGUID, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vRESIDENTNAME", AV30ResidentName);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESIDENTNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV30ResidentName, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_UARESUME_Title", StringUtil.RTrim( Dvelop_confirmpanel_uaresume_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_UARESUME_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_uaresume_Confirmationtext));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_UARESUME_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_uaresume_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_UARESUME_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_uaresume_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_UARESUME_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_uaresume_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_UARESUME_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_uaresume_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_UARESUME_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_uaresume_Confirmtype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_UARESUME_Result", StringUtil.RTrim( Dvelop_confirmpanel_uaresume_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_UARESUME_Result", StringUtil.RTrim( Dvelop_confirmpanel_uaresume_Result));
      }

      protected void RenderHtmlCloseForm7J2( )
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
            if ( ! ( WebComp_Wcwwp_dynamicformfs_wc == null ) )
            {
               WebComp_Wcwwp_dynamicformfs_wc.componentjscripts();
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
         return "WC_ResidentDynamicForm" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Dynamic Form", "") ;
      }

      protected void WB7J0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wc_residentdynamicform.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", divTablemain_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableright_Internalname, divTableright_Visible, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "justify-content:flex-end;align-items:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
            ClassString = "MobileSubmitBtn";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnopendiscussion_Internalname, "", context.GetMessage( "Discussion", ""), bttBtnopendiscussion_Jsonclick, 7, context.GetMessage( "Discussion", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e117j1_client"+"'", TempTags, "", 2, "HLP_WC_ResidentDynamicForm.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, sPrefix+"W0020"+"", StringUtil.RTrim( WebComp_Wcwwp_dynamicformfs_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0020"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcwwp_dynamicformfs_wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwwp_dynamicformfs_wc), StringUtil.Lower( WebComp_Wcwwp_dynamicformfs_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0020"+"");
                  }
                  WebComp_Wcwwp_dynamicformfs_wc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwwp_dynamicformfs_wc), StringUtil.Lower( WebComp_Wcwwp_dynamicformfs_wc_Component)) != 0 )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10 MobileButtonGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'" + sPrefix + "',false,'',0)\"";
            ClassString = "MobileSubmitBtn";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", context.GetMessage( "Submit", ""), bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WC_ResidentDynamicForm.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtncancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtncancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WC_ResidentDynamicForm.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuaresume_Internalname, "", context.GetMessage( "Resume", ""), bttBtnuaresume_Jsonclick, 7, context.GetMessage( "Resume", ""), "", StyleString, ClassString, bttBtnuaresume_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e127j1_client"+"'", TempTags, "", 2, "HLP_WC_ResidentDynamicForm.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMissingform_Internalname, divMissingform_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFormdeleted_Internalname, context.GetMessage( "I18N_DELETEDFORMAPP", ""), "", "", lblFormdeleted_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "MissingFormLabel", 0, "", 1, 1, 0, 0, "HLP_WC_ResidentDynamicForm.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSessionid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5SessionId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,39);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSessionid_Jsonclick, 0, "Attribute", "", "", "", "", edtavSessionid_Visible, 1, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WC_ResidentDynamicForm.htm");
            wb_table1_40_7J2( true) ;
         }
         else
         {
            wb_table1_40_7J2( false) ;
         }
         return  ;
      }

      protected void wb_table1_40_7J2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START7J2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
               }
            }
            Form.Meta.addItem("description", context.GetMessage( "Dynamic Form", ""), 0) ;
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
               STRUP7J0( ) ;
            }
         }
      }

      protected void WS7J2( )
      {
         START7J2( ) ;
         EVT7J2( ) ;
      }

      protected void EVT7J2( )
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
                                 STRUP7J0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_UARESUME.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7J0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Dvelop_confirmpanel_uaresume.Close */
                                    E137J2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7J0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E147J2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7J0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E157J2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7J0( ) ;
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
                                          /* Execute user event: Enter */
                                          E167J2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7J0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E177J2 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7J0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavSessionid_Internalname;
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
                        if ( nCmpId == 20 )
                        {
                           OldWcwwp_dynamicformfs_wc = cgiGet( sPrefix+"W0020");
                           if ( ( StringUtil.Len( OldWcwwp_dynamicformfs_wc) == 0 ) || ( StringUtil.StrCmp(OldWcwwp_dynamicformfs_wc, WebComp_Wcwwp_dynamicformfs_wc_Component) != 0 ) )
                           {
                              WebComp_Wcwwp_dynamicformfs_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWcwwp_dynamicformfs_wc, new Object[] {context} );
                              WebComp_Wcwwp_dynamicformfs_wc.ComponentInit();
                              WebComp_Wcwwp_dynamicformfs_wc.Name = "OldWcwwp_dynamicformfs_wc";
                              WebComp_Wcwwp_dynamicformfs_wc_Component = OldWcwwp_dynamicformfs_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wcwwp_dynamicformfs_wc_Component) != 0 )
                           {
                              WebComp_Wcwwp_dynamicformfs_wc.componentprocess(sPrefix+"W0020", "", sEvt);
                           }
                           WebComp_Wcwwp_dynamicformfs_wc_Component = OldWcwwp_dynamicformfs_wc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE7J2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm7J2( ) ;
            }
         }
      }

      protected void PA7J2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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
               GX_FocusControl = edtavSessionid_Internalname;
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF7J2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF7J2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E157J2 ();
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcwwp_dynamicformfs_wc_Component) != 0 )
               {
                  WebComp_Wcwwp_dynamicformfs_wc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E177J2 ();
            WB7J0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes7J2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vFORMNAME", AV32FormName);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFORMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV32FormName, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vRESIDENTGUID", AV27ResidentGUID);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESIDENTGUID", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV27ResidentGUID, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vRESIDENTNAME", AV30ResidentName);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESIDENTNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV30ResidentName, "")), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7J0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E147J2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOAV14WWPFormReferenceName = cgiGet( sPrefix+"wcpOAV14WWPFormReferenceName");
            wcpOAV9WWPFormInstanceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV9WWPFormInstanceId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV8WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV8WWPDynamicFormMode");
            wcpOAV28AccessToken = cgiGet( sPrefix+"wcpOAV28AccessToken");
            AV28AccessToken = cgiGet( sPrefix+"vACCESSTOKEN");
            AV9WWPFormInstanceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vWWPFORMINSTANCEID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Dvelop_confirmpanel_uaresume_Title = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_UARESUME_Title");
            Dvelop_confirmpanel_uaresume_Confirmationtext = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_UARESUME_Confirmationtext");
            Dvelop_confirmpanel_uaresume_Yesbuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_UARESUME_Yesbuttoncaption");
            Dvelop_confirmpanel_uaresume_Nobuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_UARESUME_Nobuttoncaption");
            Dvelop_confirmpanel_uaresume_Cancelbuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_UARESUME_Cancelbuttoncaption");
            Dvelop_confirmpanel_uaresume_Yesbuttonposition = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_UARESUME_Yesbuttonposition");
            Dvelop_confirmpanel_uaresume_Confirmtype = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_UARESUME_Confirmtype");
            Dvelop_confirmpanel_uaresume_Result = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_UARESUME_Result");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSessionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSessionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSESSIONID");
               GX_FocusControl = edtavSessionid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5SessionId = 0;
               AssignAttri(sPrefix, false, "AV5SessionId", StringUtil.LTrimStr( (decimal)(AV5SessionId), 4, 0));
            }
            else
            {
               AV5SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavSessionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV5SessionId", StringUtil.LTrimStr( (decimal)(AV5SessionId), 4, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E147J2 ();
         if (returnInSub) return;
      }

      protected void E147J2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV27ResidentGUID = AV6WebSession.Get(context.GetMessage( "WebViewResidentId", ""));
         AssignAttri(sPrefix, false, "AV27ResidentGUID", AV27ResidentGUID);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESIDENTGUID", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV27ResidentGUID, "")), context));
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV27ResidentGUID)) )
         {
            new prc_getuseridfromaccesstoken(context ).execute(  AV28AccessToken, out  AV27ResidentGUID, out  AV39isTokenValid) ;
            AssignAttri(sPrefix, false, "AV27ResidentGUID", AV27ResidentGUID);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESIDENTGUID", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV27ResidentGUID, "")), context));
         }
         AV29GAMUser.load( AV27ResidentGUID);
         if ( AV29GAMUser.success() )
         {
            AV30ResidentName = AV29GAMUser.gxTpr_Firstname + " " + AV29GAMUser.gxTpr_Lastname;
            AssignAttri(sPrefix, false, "AV30ResidentName", AV30ResidentName);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESIDENTNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV30ResidentName, "")), context));
         }
         if ( StringUtil.StrCmp(AV10HttpRequest.Method, "GET") == 0 )
         {
            AV5SessionId = (short)(NumberUtil.Random( )*10000);
            AssignAttri(sPrefix, false, "AV5SessionId", StringUtil.LTrimStr( (decimal)(AV5SessionId), 4, 0));
            AV7WWPFormInstance = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
            if ( StringUtil.StrCmp(AV8WWPDynamicFormMode, "INS") == 0 )
            {
               /* Using cursor H007J2 */
               pr_default.execute(0);
               while ( (pr_default.getStatus(0) != 101) )
               {
                  BRK7J3 = false;
                  A207WWPFormVersionNumber = H007J2_A207WWPFormVersionNumber[0];
                  A206WWPFormId = H007J2_A206WWPFormId[0];
                  A208WWPFormReferenceName = H007J2_A208WWPFormReferenceName[0];
                  A216WWPFormResume = H007J2_A216WWPFormResume[0];
                  A235WWPFormResumeMessage = H007J2_A235WWPFormResumeMessage[0];
                  A209WWPFormTitle = H007J2_A209WWPFormTitle[0];
                  if ( StringUtil.StrCmp(A208WWPFormReferenceName, AV14WWPFormReferenceName) == 0 )
                  {
                     AV7WWPFormInstance.gxTpr_Wwpformid = A206WWPFormId;
                     AV7WWPFormInstance.gxTpr_Wwpformversionnumber = A207WWPFormVersionNumber;
                     AV15WWPFormResume = A216WWPFormResume;
                     AssignAttri(sPrefix, false, "AV15WWPFormResume", StringUtil.Str( (decimal)(AV15WWPFormResume), 1, 0));
                     AV18WWPFormResumeMessage = A235WWPFormResumeMessage;
                     AssignAttri(sPrefix, false, "AV18WWPFormResumeMessage", AV18WWPFormResumeMessage);
                     AV7WWPFormInstance.gxTpr_Wwpuserextendedid = AV27ResidentGUID;
                     AV32FormName = A209WWPFormTitle;
                     AssignAttri(sPrefix, false, "AV32FormName", AV32FormName);
                     GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFORMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV32FormName, "")), context));
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
                  while ( (pr_default.getStatus(0) != 101) && ( H007J2_A206WWPFormId[0] == A206WWPFormId ) )
                  {
                     BRK7J3 = false;
                     A207WWPFormVersionNumber = H007J2_A207WWPFormVersionNumber[0];
                     A208WWPFormReferenceName = H007J2_A208WWPFormReferenceName[0];
                     A216WWPFormResume = H007J2_A216WWPFormResume[0];
                     A235WWPFormResumeMessage = H007J2_A235WWPFormResumeMessage[0];
                     A209WWPFormTitle = H007J2_A209WWPFormTitle[0];
                     BRK7J3 = true;
                     pr_default.readNext(0);
                  }
                  if ( ! BRK7J3 )
                  {
                     BRK7J3 = true;
                     pr_default.readNext(0);
                  }
               }
               pr_default.close(0);
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32FormName)) )
               {
                  AV7WWPFormInstance.gxTpr_Wwpforminstanceid = AV9WWPFormInstanceId;
                  AV17Resuming = false;
                  if ( AV15WWPFormResume != 0 )
                  {
                     AV5SessionId = (short)(Math.Round(NumberUtil.Val( new GeneXus.Programs.wwpbaseobjects.loaduserkeyvalue(context).executeUdp(  StringUtil.Format( "WWPDynFormCurrentForm_%1", StringUtil.Trim( StringUtil.Str( (decimal)(AV7WWPFormInstance.gxTpr_Wwpformid), 4, 0)), "", "", "", "", "", "", "", "")), "."), 18, MidpointRounding.ToEven));
                     AssignAttri(sPrefix, false, "AV5SessionId", StringUtil.LTrimStr( (decimal)(AV5SessionId), 4, 0));
                     if ( (0==AV5SessionId) || ( ! AV16AllowResumingDeprecatedFormVersion && ( NumberUtil.Val( new GeneXus.Programs.wwpbaseobjects.loaduserkeyvalue(context).executeUdp(  StringUtil.Format( "WWPDynFormCurrentFormVersion_%1", StringUtil.Trim( StringUtil.Str( (decimal)(AV7WWPFormInstance.gxTpr_Wwpformid), 4, 0)), "", "", "", "", "", "", "", "")), ".") != Convert.ToDecimal( AV7WWPFormInstance.gxTpr_Wwpformversionnumber )) ) )
                     {
                        AV5SessionId = (short)(NumberUtil.Random( )*10000);
                        AssignAttri(sPrefix, false, "AV5SessionId", StringUtil.LTrimStr( (decimal)(AV5SessionId), 4, 0));
                     }
                     else
                     {
                        AV17Resuming = true;
                        if ( AV15WWPFormResume == 1 )
                        {
                           Dvelop_confirmpanel_uaresume_Confirmationtext = AV18WWPFormResumeMessage;
                           ucDvelop_confirmpanel_uaresume.SendProperty(context, sPrefix, false, Dvelop_confirmpanel_uaresume_Internalname, "ConfirmationText", Dvelop_confirmpanel_uaresume_Confirmationtext);
                           this.executeUsercontrolMethod(sPrefix, false, "DVELOP_CONFIRMPANEL_UARESUMEContainer", "Confirm", "", new Object[] {});
                        }
                     }
                  }
                  if ( AV17Resuming )
                  {
                     AV7WWPFormInstance = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
                     AV7WWPFormInstance.FromJSonString(new GeneXus.Programs.wwpbaseobjects.loaduserkeyvalue(context).executeUdp(  StringUtil.Format( "WWP_DF_%1", StringUtil.Trim( StringUtil.Str( (decimal)(AV5SessionId), 4, 0)), "", "", "", "", "", "", "", "")), null);
                     GXt_char1 = AV22DefaultStep;
                     new GeneXus.Programs.wwpbaseobjects.loaduserkeyvalue(context ).execute(  StringUtil.Format( "WWPDynFormCurrentStep_%1", StringUtil.Trim( StringUtil.Str( (decimal)(AV7WWPFormInstance.gxTpr_Wwpformid), 4, 0)), "", "", "", "", "", "", "", ""), out  GXt_char1) ;
                     AV22DefaultStep = GXt_char1;
                     AssignAttri(sPrefix, false, "AV22DefaultStep", AV22DefaultStep);
                  }
                  else
                  {
                     /* Execute user subroutine: 'INITIALIZE NEW INSTANCE' */
                     S112 ();
                     if (returnInSub) return;
                  }
               }
               else
               {
                  bttBtnenter_Visible = 0;
                  AssignProp(sPrefix, false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
                  bttBtncancel_Visible = 0;
                  AssignProp(sPrefix, false, bttBtncancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtncancel_Visible), 5, 0), true);
               }
            }
            else
            {
               AV7WWPFormInstance.Load(AV9WWPFormInstanceId);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32FormName)) || ( StringUtil.StrCmp(AV8WWPDynamicFormMode, "INS") != 0 ) )
            {
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_saveforminstance(context ).execute(  AV5SessionId,  AV7WWPFormInstance) ;
               /* Execute user subroutine: 'INITIALIZE WC' */
               S122 ();
               if (returnInSub) return;
            }
         }
         this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "ConfirmInTransaction_AttachToButton", new Object[] {(string)divLayoutmaintable_Internalname,(string)bttBtnenter_Internalname}, false);
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp(sPrefix, false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S132 ();
         if (returnInSub) return;
         edtavSessionid_Visible = 0;
         AssignProp(sPrefix, false, edtavSessionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSessionid_Visible), 5, 0), true);
      }

      protected void E157J2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S142 ();
         if (returnInSub) return;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV32FormName)) )
         {
            bttBtnenter_Visible = 0;
            AssignProp(sPrefix, false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
            bttBtncancel_Visible = 0;
            AssignProp(sPrefix, false, bttBtncancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtncancel_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
      }

      protected void E137J2( )
      {
         /* Dvelop_confirmpanel_uaresume_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_uaresume_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION UARESUME' */
            S152 ();
            if (returnInSub) return;
         }
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_uaresume_Result, "No") == 0 )
         {
            AV6WebSession.Remove(StringUtil.Format( "WWP_DF_%1", StringUtil.Trim( StringUtil.Str( (decimal)(AV5SessionId), 4, 0)), "", "", "", "", "", "", "", ""));
            AV5SessionId = (short)(NumberUtil.Random( )*10000);
            AssignAttri(sPrefix, false, "AV5SessionId", StringUtil.LTrimStr( (decimal)(AV5SessionId), 4, 0));
            AV7WWPFormInstance = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
            /* Using cursor H007J3 */
            pr_default.execute(1, new Object[] {AV14WWPFormReferenceName});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A208WWPFormReferenceName = H007J3_A208WWPFormReferenceName[0];
               A206WWPFormId = H007J3_A206WWPFormId[0];
               A207WWPFormVersionNumber = H007J3_A207WWPFormVersionNumber[0];
               AV7WWPFormInstance.gxTpr_Wwpformid = A206WWPFormId;
               AV7WWPFormInstance.gxTpr_Wwpformversionnumber = A207WWPFormVersionNumber;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Execute user subroutine: 'INITIALIZE NEW INSTANCE' */
            S112 ();
            if (returnInSub) return;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_saveforminstance(context ).execute(  AV5SessionId,  AV7WWPFormInstance) ;
            AV22DefaultStep = "";
            AssignAttri(sPrefix, false, "AV22DefaultStep", AV22DefaultStep);
            /* Execute user subroutine: 'INITIALIZE WC' */
            S122 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV7WWPFormInstance", AV7WWPFormInstance);
      }

      protected void S142( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV8WWPDynamicFormMode, "DSP") != 0 ) ) )
         {
            bttBtnenter_Visible = 0;
            AssignProp(sPrefix, false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
         }
         if ( ! ( ( 1 == 0 ) ) )
         {
            bttBtncancel_Visible = 0;
            AssignProp(sPrefix, false, bttBtncancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtncancel_Visible), 5, 0), true);
         }
         if ( ! ( ( 1 == 0 ) ) )
         {
            bttBtnuaresume_Visible = 0;
            AssignProp(sPrefix, false, bttBtnuaresume_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnuaresume_Visible), 5, 0), true);
         }
      }

      protected void S152( )
      {
         /* 'DO ACTION UARESUME' Routine */
         returnInSub = false;
      }

      protected void S132( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         divTableright_Visible = (((StringUtil.StrCmp(AV8WWPDynamicFormMode, "DSP")==0)&&!String.IsNullOrEmpty(StringUtil.RTrim( AV32FormName))) ? 1 : 0);
         AssignProp(sPrefix, false, divTableright_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableright_Visible), 5, 0), true);
         divMissingform_Visible = (((StringUtil.StrCmp(AV8WWPDynamicFormMode, "INS")==0)&&String.IsNullOrEmpty(StringUtil.RTrim( AV32FormName))) ? 1 : 0);
         AssignProp(sPrefix, false, divMissingform_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divMissingform_Visible), 5, 0), true);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E167J2 ();
         if (returnInSub) return;
      }

      protected void E167J2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( ! AV23ExecuteEnterEvent )
         {
            AV23ExecuteEnterEvent = true;
            AssignAttri(sPrefix, false, "AV23ExecuteEnterEvent", AV23ExecuteEnterEvent);
            this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "ConfirmInTransaction_Confirm", new Object[] {}, false);
         }
         else
         {
            AV23ExecuteEnterEvent = false;
            AssignAttri(sPrefix, false, "AV23ExecuteEnterEvent", AV23ExecuteEnterEvent);
            if ( ! AV11WWPFormIsWizard )
            {
               if ( StringUtil.StrCmp(AV8WWPDynamicFormMode, "DSP") != 0 )
               {
                  GXt_SdtWWP_FormInstance2 = AV7WWPFormInstance;
                  new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadforminstance(context ).execute(  AV5SessionId, out  GXt_SdtWWP_FormInstance2) ;
                  AV7WWPFormInstance = GXt_SdtWWP_FormInstance2;
                  new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_validateinstance(context ).execute(  AV7WWPFormInstance,  true, out  AV20HasErrors, out  AV13ErrorIds, out  AV21Messages) ;
                  if ( ! AV20HasErrors )
                  {
                     if ( ( StringUtil.StrCmp(AV8WWPDynamicFormMode, "UPD") == 0 ) || ( StringUtil.StrCmp(AV8WWPDynamicFormMode, "INS") == 0 ) )
                     {
                        AV7WWPFormInstance.gxTpr_Wwpuserextendedid = AV27ResidentGUID;
                        AV7WWPFormInstance.Save();
                     }
                     else if ( StringUtil.StrCmp(AV8WWPDynamicFormMode, "DLT") == 0 )
                     {
                        AV7WWPFormInstance.Delete();
                     }
                     if ( AV7WWPFormInstance.Success() )
                     {
                        AV6WebSession.Remove(StringUtil.Format( "WWP_DF_%1", StringUtil.Trim( StringUtil.Str( (decimal)(AV5SessionId), 4, 0)), "", "", "", "", "", "", "", ""));
                        new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue(context ).execute(  StringUtil.Format( "WWP_DF_%1", StringUtil.Trim( StringUtil.Str( (decimal)(AV5SessionId), 4, 0)), "", "", "", "", "", "", "", ""),  "") ;
                        new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue(context ).execute(  StringUtil.Format( "WWPDynFormCurrentForm_%1", StringUtil.Trim( StringUtil.Str( (decimal)(AV7WWPFormInstance.gxTpr_Wwpformid), 4, 0)), "", "", "", "", "", "", "", ""),  "") ;
                        new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue(context ).execute(  StringUtil.Format( "WWPDynFormCurrentFormVersion_%1", StringUtil.Trim( StringUtil.Str( (decimal)(AV7WWPFormInstance.gxTpr_Wwpformid), 4, 0)), "", "", "", "", "", "", "", ""),  "") ;
                        context.CommitDataStores("wc_residentdynamicform",pr_default);
                        GX_msglist.addItem(context.GetMessage( "Form Submitted successfully", ""));
                        AV33FormInstanceIdString = StringUtil.Trim( StringUtil.Str( (decimal)(AV9WWPFormInstanceId), 6, 0));
                        AV44Formlink = formatLink("workwithplus.dynamicforms.wwp_dynamicform.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV14WWPFormReferenceName)),UrlEncode(StringUtil.LTrimStr(AV7WWPFormInstance.gxTpr_Wwpforminstanceid,6,0)),UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.BoolToStr(false))}, new string[] {"WWPFormReferenceName","WWPFormInstanceId","WWPDynamicFormMode","isLinkingDiscussion"}) ;
                        if ( StringUtil.StrCmp(AV8WWPDynamicFormMode, "INS") == 0 )
                        {
                           AV31NotificationDescription = AV32FormName + " - " + AV30ResidentName;
                           AV36SDT_NotificationMetadata = new SdtSDT_NotificationMetadata(context);
                           AV36SDT_NotificationMetadata.gxTpr_Isparentnotification = true;
                           AV36SDT_NotificationMetadata.gxTpr_Parentnotificationid = StringUtil.Trim( StringUtil.Str( (decimal)(AV7WWPFormInstance.gxTpr_Wwpforminstanceid), 6, 0));
                           AV36SDT_NotificationMetadata.gxTpr_Formreferencename = AV14WWPFormReferenceName;
                           AV36SDT_NotificationMetadata.gxTpr_Notificationtriggeredtimestamp = DateTimeUtil.Now( context);
                           AV36SDT_NotificationMetadata.gxTpr_Notificationorigin = context.GetMessage( "DynamicForms", "");
                           AV37WWPNotificationMetadataSDT = new SdtUSDTNotificationMetadata(context);
                           AV37WWPNotificationMetadataSDT.gxTpr_Custommetadata = AV36SDT_NotificationMetadata;
                           AV6WebSession.Set(context.GetMessage( "FormFilledMessage", ""), context.GetMessage( "Form submitted successfully", ""));
                           new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendnotification(context ).execute(  "DynamicFormNotification",  "DynamicForms",  "",  "fas fa-file-alt NotificationFontIconSuccess",  "New Form Response",  AV31NotificationDescription,  AV31NotificationDescription,  AV44Formlink,  AV37WWPNotificationMetadataSDT.ToJSonString(false, true),  "",  true) ;
                           AV34ResidentIdCollection.Clear();
                           AV34ResidentIdCollection.Add(new prc_getresidentidfromguid(context).executeUdp(  AV27ResidentGUID), 0);
                           AV38Metadata = new SdtSDT_OneSignalCustomData(context);
                           AV38Metadata.gxTpr_Notificationcategory = "Form";
                           AV38Metadata.gxTpr_Formdetails.gxTpr_Forminstanceid = (short)(AV7WWPFormInstance.gxTpr_Wwpforminstanceid);
                           AV38Metadata.gxTpr_Formdetails.gxTpr_Formmode = "DSP";
                           AV38Metadata.gxTpr_Formdetails.gxTpr_Formreferencename = AV14WWPFormReferenceName;
                           new prc_sendresidentnotification(context ).execute(  "New Filled Form",  "You have filled out a form ("+AV32FormName+")",  context.GetMessage( "FORM", ""),  AV38Metadata,  AV34ResidentIdCollection) ;
                           new prc_subscriberesidenttodiscussion(context ).execute(  context.GetMessage( "GeneralDiscussion", ""),  context.GetMessage( "Discussion", ""),  StringUtil.Trim( StringUtil.Str( (decimal)(AV7WWPFormInstance.gxTpr_Wwpforminstanceid), 6, 0)),  AV31NotificationDescription,  AV27ResidentGUID) ;
                        }
                        else if ( StringUtil.StrCmp(AV8WWPDynamicFormMode, "UPD") == 0 )
                        {
                           AV31NotificationDescription = "Resident: " + AV30ResidentName + " " + context.GetMessage( "has updated their filled out form (", "") + AV32FormName + ")";
                           AV36SDT_NotificationMetadata = new SdtSDT_NotificationMetadata(context);
                           AV36SDT_NotificationMetadata.gxTpr_Isparentnotification = false;
                           AV36SDT_NotificationMetadata.gxTpr_Parentnotificationid = StringUtil.Str( (decimal)(AV7WWPFormInstance.gxTpr_Wwpforminstanceid), 6, 0);
                           AV36SDT_NotificationMetadata.gxTpr_Formreferencename = AV14WWPFormReferenceName;
                           AV36SDT_NotificationMetadata.gxTpr_Notificationtriggeredtimestamp = DateTimeUtil.Now( context);
                           AV36SDT_NotificationMetadata.gxTpr_Notificationorigin = "DynamicForms";
                           AV37WWPNotificationMetadataSDT = new SdtUSDTNotificationMetadata(context);
                           AV37WWPNotificationMetadataSDT.gxTpr_Custommetadata = AV36SDT_NotificationMetadata;
                           AV6WebSession.Set(context.GetMessage( "FormFilledMessage", ""), context.GetMessage( "Form updated successfully", ""));
                           new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendnotification(context ).execute(  context.GetMessage( "DynamicFormNotification", ""),  context.GetMessage( "DynamicForms", ""),  "",  context.GetMessage( "fas fa-pencil-alt NotificationFontIconWarning", ""),  "Form Response Updated",  AV31NotificationDescription,  AV31NotificationDescription,  AV44Formlink,  AV37WWPNotificationMetadataSDT.ToJSonString(false, true),  "",  true) ;
                        }
                        else if ( StringUtil.StrCmp(AV8WWPDynamicFormMode, "DLT") == 0 )
                        {
                           AV31NotificationDescription = "Resident: " + AV30ResidentName + " " + context.GetMessage( "has delete their filled out form (", "") + AV32FormName + ")";
                           AV36SDT_NotificationMetadata = new SdtSDT_NotificationMetadata(context);
                           AV36SDT_NotificationMetadata.gxTpr_Isparentnotification = false;
                           AV36SDT_NotificationMetadata.gxTpr_Parentnotificationid = StringUtil.Str( (decimal)(AV7WWPFormInstance.gxTpr_Wwpforminstanceid), 6, 0);
                           AV36SDT_NotificationMetadata.gxTpr_Formreferencename = AV14WWPFormReferenceName;
                           AV36SDT_NotificationMetadata.gxTpr_Notificationtriggeredtimestamp = DateTimeUtil.Now( context);
                           AV36SDT_NotificationMetadata.gxTpr_Notificationorigin = "DynamicForms";
                           AV37WWPNotificationMetadataSDT = new SdtUSDTNotificationMetadata(context);
                           AV37WWPNotificationMetadataSDT.gxTpr_Custommetadata = AV36SDT_NotificationMetadata;
                           AV6WebSession.Set(context.GetMessage( "FormFilledMessage", ""), context.GetMessage( "Form deleted successfully", ""));
                           new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendnotification(context ).execute(  "DynamicFormNotification",  "DynamicForms",  "",  "fas fa-trash-alt NotificationFontIconDanger",  "Form Response Deleted",  AV31NotificationDescription,  AV31NotificationDescription,  AV44Formlink,  AV37WWPNotificationMetadataSDT.ToJSonString(false, true),  "",  true) ;
                        }
                        CallWebObject(formatLink("wp_residentfilledforms.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV28AccessToken))}, new string[] {"AccessToken"}) );
                        context.wjLocDisableFrm = 1;
                     }
                     else
                     {
                        AV20HasErrors = true;
                        AV21Messages = AV7WWPFormInstance.GetMessages();
                     }
                  }
                  if ( AV20HasErrors )
                  {
                     if ( AV21Messages.Count == 0 )
                     {
                        this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "DynamicForm_Validate", new Object[] {(short)AV5SessionId,(string)AV13ErrorIds}, true);
                     }
                     else
                     {
                        AV45GXV1 = 1;
                        while ( AV45GXV1 <= AV21Messages.Count )
                        {
                           AV19Message = ((GeneXus.Utils.SdtMessages_Message)AV21Messages.Item(AV45GXV1));
                           GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV19Message.gxTpr_Description,  "error",  "",  "true",  ""));
                           AV45GXV1 = (int)(AV45GXV1+1);
                        }
                     }
                  }
               }
               else
               {
                  context.setWebReturnParms(new Object[] {});
                  context.setWebReturnParmsMetadata(new Object[] {});
                  context.wjLocDisableFrm = 1;
                  context.nUserReturn = 1;
                  returnInSub = true;
                  if (true) return;
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV7WWPFormInstance", AV7WWPFormInstance);
      }

      protected void S112( )
      {
         /* 'INITIALIZE NEW INSTANCE' Routine */
         returnInSub = false;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_createchildren(context ).execute(  0,  0, ref  AV7WWPFormInstance) ;
         AV7WWPFormInstance.Check();
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_clearunusedreferences(context ).execute( ref  AV7WWPFormInstance) ;
         if ( ! AV7WWPFormInstance.Success() )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_DF_ErrorLoadingFormInstance", ""), ((GeneXus.Utils.SdtMessages_Message)AV7WWPFormInstance.GetMessages().Item(1)).gxTpr_Description, "", "", "", "", "", "", "", ""));
         }
         AV12WWPForm.Load(AV7WWPFormInstance.gxTpr_Wwpformid, AV7WWPFormInstance.gxTpr_Wwpformversionnumber);
         if ( ! AV12WWPForm.gxTpr_Wwpforminstantiated )
         {
            AV12WWPForm.gxTpr_Wwpforminstantiated = true;
            AV12WWPForm.Save();
            context.CommitDataStores("wc_residentdynamicform",pr_default);
         }
         if ( AV12WWPForm.gxTpr_Wwpformresume != 0 )
         {
            new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue(context ).execute(  StringUtil.Format( "WWPDynFormCurrentForm_%1", StringUtil.Trim( StringUtil.Str( (decimal)(AV7WWPFormInstance.gxTpr_Wwpformid), 4, 0)), "", "", "", "", "", "", "", ""),  StringUtil.Trim( StringUtil.Str( (decimal)(AV5SessionId), 4, 0))) ;
            new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue(context ).execute(  StringUtil.Format( "WWPDynFormCurrentFormVersion_%1", StringUtil.Trim( StringUtil.Str( (decimal)(AV7WWPFormInstance.gxTpr_Wwpformid), 4, 0)), "", "", "", "", "", "", "", ""),  StringUtil.Trim( StringUtil.Str( (decimal)(AV7WWPFormInstance.gxTpr_Wwpformversionnumber), 4, 0))) ;
         }
      }

      protected void S122( )
      {
         /* 'INITIALIZE WC' Routine */
         returnInSub = false;
         AV6WebSession.Set("WWPDynFormSetFocus", "T");
         /* Using cursor H007J4 */
         pr_default.execute(2, new Object[] {AV7WWPFormInstance.gxTpr_Wwpformid, AV7WWPFormInstance.gxTpr_Wwpformversionnumber});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A207WWPFormVersionNumber = H007J4_A207WWPFormVersionNumber[0];
            A206WWPFormId = H007J4_A206WWPFormId[0];
            A232WWPFormIsWizard = H007J4_A232WWPFormIsWizard[0];
            A209WWPFormTitle = H007J4_A209WWPFormTitle[0];
            AV11WWPFormIsWizard = A232WWPFormIsWizard;
            AssignAttri(sPrefix, false, "AV11WWPFormIsWizard", AV11WWPFormIsWizard);
            Form.Caption = A209WWPFormTitle;
            AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
         if ( AV11WWPFormIsWizard )
         {
            /* Object Property */
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               bDynCreated_Wcwwp_dynamicformfs_wc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwwp_dynamicformfs_wc_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_Wizard_WC")) != 0 )
            {
               WebComp_Wcwwp_dynamicformfs_wc = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_wizard_wc", new Object[] {context} );
               WebComp_Wcwwp_dynamicformfs_wc.ComponentInit();
               WebComp_Wcwwp_dynamicformfs_wc.Name = "WorkWithPlus.DynamicForms.WWP_DF_Wizard_WC";
               WebComp_Wcwwp_dynamicformfs_wc_Component = "WorkWithPlus.DynamicForms.WWP_DF_Wizard_WC";
            }
            if ( StringUtil.Len( WebComp_Wcwwp_dynamicformfs_wc_Component) != 0 )
            {
               WebComp_Wcwwp_dynamicformfs_wc.setjustcreated();
               WebComp_Wcwwp_dynamicformfs_wc.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)"",(string)AV8WWPDynamicFormMode,(short)AV5SessionId,(string)AV22DefaultStep,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV7WWPFormInstance,(string)AV28AccessToken});
               WebComp_Wcwwp_dynamicformfs_wc.componentbind(new Object[] {(string)"",(string)sPrefix+"vSESSIONID",(string)"",(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcwwp_dynamicformfs_wc )
            {
               context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0020"+"");
               WebComp_Wcwwp_dynamicformfs_wc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            bttBtnenter_Visible = 0;
            AssignProp(sPrefix, false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
            bttBtncancel_Visible = 0;
            AssignProp(sPrefix, false, bttBtncancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtncancel_Visible), 5, 0), true);
         }
         else
         {
            divTablemain_Class = "TableMainDynamicForm PlainDynamicForm";
            AssignProp(sPrefix, false, divTablemain_Internalname, "Class", divTablemain_Class, true);
            bttBtnenter_Visible = 1;
            AssignProp(sPrefix, false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
            bttBtncancel_Visible = 1;
            AssignProp(sPrefix, false, bttBtncancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtncancel_Visible), 5, 0), true);
            /* Object Property */
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               bDynCreated_Wcwwp_dynamicformfs_wc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwwp_dynamicformfs_wc_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_FS_WC")) != 0 )
            {
               WebComp_Wcwwp_dynamicformfs_wc = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_fs_wc", new Object[] {context} );
               WebComp_Wcwwp_dynamicformfs_wc.ComponentInit();
               WebComp_Wcwwp_dynamicformfs_wc.Name = "WorkWithPlus.DynamicForms.WWP_DF_FS_WC";
               WebComp_Wcwwp_dynamicformfs_wc_Component = "WorkWithPlus.DynamicForms.WWP_DF_FS_WC";
            }
            if ( StringUtil.Len( WebComp_Wcwwp_dynamicformfs_wc_Component) != 0 )
            {
               WebComp_Wcwwp_dynamicformfs_wc.setjustcreated();
               WebComp_Wcwwp_dynamicformfs_wc.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)"",(string)AV8WWPDynamicFormMode,(short)0,(short)0,(short)AV5SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV7WWPFormInstance});
               WebComp_Wcwwp_dynamicformfs_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)sPrefix+"vSESSIONID",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcwwp_dynamicformfs_wc )
            {
               context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0020"+"");
               WebComp_Wcwwp_dynamicformfs_wc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E177J2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_40_7J2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_uaresume_Internalname, tblTabledvelop_confirmpanel_uaresume_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_uaresume.SetProperty("Title", Dvelop_confirmpanel_uaresume_Title);
            ucDvelop_confirmpanel_uaresume.SetProperty("ConfirmationText", Dvelop_confirmpanel_uaresume_Confirmationtext);
            ucDvelop_confirmpanel_uaresume.SetProperty("YesButtonCaption", Dvelop_confirmpanel_uaresume_Yesbuttoncaption);
            ucDvelop_confirmpanel_uaresume.SetProperty("NoButtonCaption", Dvelop_confirmpanel_uaresume_Nobuttoncaption);
            ucDvelop_confirmpanel_uaresume.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_uaresume_Cancelbuttoncaption);
            ucDvelop_confirmpanel_uaresume.SetProperty("YesButtonPosition", Dvelop_confirmpanel_uaresume_Yesbuttonposition);
            ucDvelop_confirmpanel_uaresume.SetProperty("ConfirmType", Dvelop_confirmpanel_uaresume_Confirmtype);
            ucDvelop_confirmpanel_uaresume.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_uaresume_Internalname, sPrefix+"DVELOP_CONFIRMPANEL_UARESUMEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVELOP_CONFIRMPANEL_UARESUMEContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_40_7J2e( true) ;
         }
         else
         {
            wb_table1_40_7J2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV14WWPFormReferenceName = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV14WWPFormReferenceName", AV14WWPFormReferenceName);
         AV9WWPFormInstanceId = Convert.ToInt32(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV9WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(AV9WWPFormInstanceId), 6, 0));
         AV8WWPDynamicFormMode = (string)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV8WWPDynamicFormMode", AV8WWPDynamicFormMode);
         AV28AccessToken = (string)getParm(obj,3);
         AssignAttri(sPrefix, false, "AV28AccessToken", AV28AccessToken);
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
         PA7J2( ) ;
         WS7J2( ) ;
         WE7J2( ) ;
         cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlAV14WWPFormReferenceName = (string)((string)getParm(obj,0));
         sCtrlAV9WWPFormInstanceId = (string)((string)getParm(obj,1));
         sCtrlAV8WWPDynamicFormMode = (string)((string)getParm(obj,2));
         sCtrlAV28AccessToken = (string)((string)getParm(obj,3));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA7J2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wc_residentdynamicform", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA7J2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV14WWPFormReferenceName = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV14WWPFormReferenceName", AV14WWPFormReferenceName);
            AV9WWPFormInstanceId = Convert.ToInt32(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV9WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(AV9WWPFormInstanceId), 6, 0));
            AV8WWPDynamicFormMode = (string)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV8WWPDynamicFormMode", AV8WWPDynamicFormMode);
            AV28AccessToken = (string)getParm(obj,5);
            AssignAttri(sPrefix, false, "AV28AccessToken", AV28AccessToken);
         }
         wcpOAV14WWPFormReferenceName = cgiGet( sPrefix+"wcpOAV14WWPFormReferenceName");
         wcpOAV9WWPFormInstanceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV9WWPFormInstanceId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV8WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV8WWPDynamicFormMode");
         wcpOAV28AccessToken = cgiGet( sPrefix+"wcpOAV28AccessToken");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV14WWPFormReferenceName, wcpOAV14WWPFormReferenceName) != 0 ) || ( AV9WWPFormInstanceId != wcpOAV9WWPFormInstanceId ) || ( StringUtil.StrCmp(AV8WWPDynamicFormMode, wcpOAV8WWPDynamicFormMode) != 0 ) || ( StringUtil.StrCmp(AV28AccessToken, wcpOAV28AccessToken) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOAV14WWPFormReferenceName = AV14WWPFormReferenceName;
         wcpOAV9WWPFormInstanceId = AV9WWPFormInstanceId;
         wcpOAV8WWPDynamicFormMode = AV8WWPDynamicFormMode;
         wcpOAV28AccessToken = AV28AccessToken;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV14WWPFormReferenceName = cgiGet( sPrefix+"AV14WWPFormReferenceName_CTRL");
         if ( StringUtil.Len( sCtrlAV14WWPFormReferenceName) > 0 )
         {
            AV14WWPFormReferenceName = cgiGet( sCtrlAV14WWPFormReferenceName);
            AssignAttri(sPrefix, false, "AV14WWPFormReferenceName", AV14WWPFormReferenceName);
         }
         else
         {
            AV14WWPFormReferenceName = cgiGet( sPrefix+"AV14WWPFormReferenceName_PARM");
         }
         sCtrlAV9WWPFormInstanceId = cgiGet( sPrefix+"AV9WWPFormInstanceId_CTRL");
         if ( StringUtil.Len( sCtrlAV9WWPFormInstanceId) > 0 )
         {
            AV9WWPFormInstanceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV9WWPFormInstanceId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV9WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(AV9WWPFormInstanceId), 6, 0));
         }
         else
         {
            AV9WWPFormInstanceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV9WWPFormInstanceId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
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
         sCtrlAV28AccessToken = cgiGet( sPrefix+"AV28AccessToken_CTRL");
         if ( StringUtil.Len( sCtrlAV28AccessToken) > 0 )
         {
            AV28AccessToken = cgiGet( sCtrlAV28AccessToken);
            AssignAttri(sPrefix, false, "AV28AccessToken", AV28AccessToken);
         }
         else
         {
            AV28AccessToken = cgiGet( sPrefix+"AV28AccessToken_PARM");
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
         PA7J2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS7J2( ) ;
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
         WS7J2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV14WWPFormReferenceName_PARM", AV14WWPFormReferenceName);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV14WWPFormReferenceName)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV14WWPFormReferenceName_CTRL", StringUtil.RTrim( sCtrlAV14WWPFormReferenceName));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV9WWPFormInstanceId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9WWPFormInstanceId), 6, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV9WWPFormInstanceId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV9WWPFormInstanceId_CTRL", StringUtil.RTrim( sCtrlAV9WWPFormInstanceId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8WWPDynamicFormMode_PARM", StringUtil.RTrim( AV8WWPDynamicFormMode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8WWPDynamicFormMode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8WWPDynamicFormMode_CTRL", StringUtil.RTrim( sCtrlAV8WWPDynamicFormMode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV28AccessToken_PARM", AV28AccessToken);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV28AccessToken)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV28AccessToken_CTRL", StringUtil.RTrim( sCtrlAV28AccessToken));
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
         WE7J2( ) ;
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
         if ( ! ( WebComp_Wcwwp_dynamicformfs_wc == null ) )
         {
            WebComp_Wcwwp_dynamicformfs_wc.componentjscripts();
         }
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wcwwp_dynamicformfs_wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcwwp_dynamicformfs_wc_Component) != 0 )
            {
               WebComp_Wcwwp_dynamicformfs_wc.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025721244457", true, true);
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
         context.AddJavascriptSource("wc_residentdynamicform.js", "?2025721244460", false, true);
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
         bttBtnopendiscussion_Internalname = sPrefix+"BTNOPENDISCUSSION";
         divTableright_Internalname = sPrefix+"TABLERIGHT";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         bttBtnenter_Internalname = sPrefix+"BTNENTER";
         bttBtncancel_Internalname = sPrefix+"BTNCANCEL";
         bttBtnuaresume_Internalname = sPrefix+"BTNUARESUME";
         lblFormdeleted_Internalname = sPrefix+"FORMDELETED";
         divMissingform_Internalname = sPrefix+"MISSINGFORM";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavSessionid_Internalname = sPrefix+"vSESSIONID";
         Dvelop_confirmpanel_uaresume_Internalname = sPrefix+"DVELOP_CONFIRMPANEL_UARESUME";
         tblTabledvelop_confirmpanel_uaresume_Internalname = sPrefix+"TABLEDVELOP_CONFIRMPANEL_UARESUME";
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
         edtavSessionid_Jsonclick = "";
         edtavSessionid_Visible = 1;
         divMissingform_Visible = 1;
         bttBtnuaresume_Visible = 1;
         bttBtncancel_Visible = 1;
         bttBtnenter_Visible = 1;
         divTableright_Visible = 1;
         divTablemain_Class = "TableMainDynamicForm";
         divLayoutmaintable_Class = "Table TableTransactionTemplate";
         Dvelop_confirmpanel_uaresume_Confirmtype = "1";
         Dvelop_confirmpanel_uaresume_Yesbuttonposition = "left";
         Dvelop_confirmpanel_uaresume_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_uaresume_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_uaresume_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_uaresume_Confirmationtext = "";
         Dvelop_confirmpanel_uaresume_Title = context.GetMessage( "Resume", "");
         Form.Caption = context.GetMessage( "Dynamic Form", "");
         context.GX_msglist.DisplayMode = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV8WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV32FormName","fld":"vFORMNAME","hsh":true},{"av":"AV27ResidentGUID","fld":"vRESIDENTGUID","hsh":true},{"av":"AV30ResidentName","fld":"vRESIDENTNAME","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"ctrl":"BTNENTER","prop":"Visible"},{"ctrl":"BTNCANCEL","prop":"Visible"},{"ctrl":"BTNUARESUME","prop":"Visible"}]}""");
         setEventMetadata("'DOUARESUME'","""{"handler":"E127J1","iparms":[]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_UARESUME.CLOSE","""{"handler":"E137J2","iparms":[{"av":"Dvelop_confirmpanel_uaresume_Result","ctrl":"DVELOP_CONFIRMPANEL_UARESUME","prop":"Result"},{"av":"AV5SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME"},{"av":"AV14WWPFormReferenceName","fld":"vWWPFORMREFERENCENAME"},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"AV7WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A209WWPFormTitle","fld":"WWPFORMTITLE"},{"av":"AV8WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV22DefaultStep","fld":"vDEFAULTSTEP"},{"av":"AV28AccessToken","fld":"vACCESSTOKEN"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_UARESUME.CLOSE",""","oparms":[{"av":"AV5SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV7WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV22DefaultStep","fld":"vDEFAULTSTEP"},{"av":"AV11WWPFormIsWizard","fld":"vWWPFORMISWIZARD"},{"ctrl":"FORM","prop":"Caption"},{"av":"divTablemain_Class","ctrl":"TABLEMAIN","prop":"Class"},{"ctrl":"WCWWP_DYNAMICFORMFS_WC"},{"ctrl":"BTNENTER","prop":"Visible"},{"ctrl":"BTNCANCEL","prop":"Visible"}]}""");
         setEventMetadata("'DOOPENDISCUSSION'","""{"handler":"E117J1","iparms":[{"av":"AV9WWPFormInstanceId","fld":"vWWPFORMINSTANCEID","pic":"ZZZZZ9"},{"av":"AV28AccessToken","fld":"vACCESSTOKEN"}]}""");
         setEventMetadata("ENTER","""{"handler":"E167J2","iparms":[{"av":"AV23ExecuteEnterEvent","fld":"vEXECUTEENTEREVENT"},{"av":"AV11WWPFormIsWizard","fld":"vWWPFORMISWIZARD"},{"av":"AV8WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV5SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV27ResidentGUID","fld":"vRESIDENTGUID","hsh":true},{"av":"AV9WWPFormInstanceId","fld":"vWWPFORMINSTANCEID","pic":"ZZZZZ9"},{"av":"AV14WWPFormReferenceName","fld":"vWWPFORMREFERENCENAME"},{"av":"AV32FormName","fld":"vFORMNAME","hsh":true},{"av":"AV30ResidentName","fld":"vRESIDENTNAME","hsh":true},{"av":"AV28AccessToken","fld":"vACCESSTOKEN"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV7WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV23ExecuteEnterEvent","fld":"vEXECUTEENTEREVENT"}]}""");
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
         wcpOAV14WWPFormReferenceName = "";
         wcpOAV8WWPDynamicFormMode = "";
         wcpOAV28AccessToken = "";
         Dvelop_confirmpanel_uaresume_Result = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         AV32FormName = "";
         AV27ResidentGUID = "";
         AV30ResidentName = "";
         GXKey = "";
         A208WWPFormReferenceName = "";
         AV7WWPFormInstance = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         A209WWPFormTitle = "";
         AV22DefaultStep = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtnopendiscussion_Jsonclick = "";
         WebComp_Wcwwp_dynamicformfs_wc_Component = "";
         OldWcwwp_dynamicformfs_wc = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         bttBtnuaresume_Jsonclick = "";
         lblFormdeleted_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV6WebSession = context.GetSession();
         AV29GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV10HttpRequest = new GxHttpRequest( context);
         H007J2_A207WWPFormVersionNumber = new short[1] ;
         H007J2_A206WWPFormId = new short[1] ;
         H007J2_A208WWPFormReferenceName = new string[] {""} ;
         H007J2_A216WWPFormResume = new short[1] ;
         H007J2_A235WWPFormResumeMessage = new string[] {""} ;
         H007J2_A209WWPFormTitle = new string[] {""} ;
         A235WWPFormResumeMessage = "";
         AV18WWPFormResumeMessage = "";
         ucDvelop_confirmpanel_uaresume = new GXUserControl();
         GXt_char1 = "";
         H007J3_A208WWPFormReferenceName = new string[] {""} ;
         H007J3_A206WWPFormId = new short[1] ;
         H007J3_A207WWPFormVersionNumber = new short[1] ;
         GXt_SdtWWP_FormInstance2 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         AV13ErrorIds = "";
         AV21Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV33FormInstanceIdString = "";
         AV44Formlink = "";
         AV31NotificationDescription = "";
         AV36SDT_NotificationMetadata = new SdtSDT_NotificationMetadata(context);
         AV37WWPNotificationMetadataSDT = new SdtUSDTNotificationMetadata(context);
         AV34ResidentIdCollection = new GxSimpleCollection<Guid>();
         AV38Metadata = new SdtSDT_OneSignalCustomData(context);
         AV19Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV12WWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         H007J4_A207WWPFormVersionNumber = new short[1] ;
         H007J4_A206WWPFormId = new short[1] ;
         H007J4_A232WWPFormIsWizard = new bool[] {false} ;
         H007J4_A209WWPFormTitle = new string[] {""} ;
         sStyleString = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV14WWPFormReferenceName = "";
         sCtrlAV9WWPFormInstanceId = "";
         sCtrlAV8WWPDynamicFormMode = "";
         sCtrlAV28AccessToken = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wc_residentdynamicform__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wc_residentdynamicform__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wc_residentdynamicform__default(),
            new Object[][] {
                new Object[] {
               H007J2_A207WWPFormVersionNumber, H007J2_A206WWPFormId, H007J2_A208WWPFormReferenceName, H007J2_A216WWPFormResume, H007J2_A235WWPFormResumeMessage, H007J2_A209WWPFormTitle
               }
               , new Object[] {
               H007J3_A208WWPFormReferenceName, H007J3_A206WWPFormId, H007J3_A207WWPFormVersionNumber
               }
               , new Object[] {
               H007J4_A207WWPFormVersionNumber, H007J4_A206WWPFormId, H007J4_A232WWPFormIsWizard, H007J4_A209WWPFormTitle
               }
            }
         );
         WebComp_Wcwwp_dynamicformfs_wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short A207WWPFormVersionNumber ;
      private short A206WWPFormId ;
      private short wbEnd ;
      private short wbStart ;
      private short AV5SessionId ;
      private short nDraw ;
      private short nDoneStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short A216WWPFormResume ;
      private short AV15WWPFormResume ;
      private short nGXWrapped ;
      private int AV9WWPFormInstanceId ;
      private int wcpOAV9WWPFormInstanceId ;
      private int divTableright_Visible ;
      private int bttBtnenter_Visible ;
      private int bttBtncancel_Visible ;
      private int bttBtnuaresume_Visible ;
      private int divMissingform_Visible ;
      private int edtavSessionid_Visible ;
      private int AV45GXV1 ;
      private int idxLst ;
      private string AV8WWPDynamicFormMode ;
      private string wcpOAV8WWPDynamicFormMode ;
      private string Dvelop_confirmpanel_uaresume_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Dvelop_confirmpanel_uaresume_Title ;
      private string Dvelop_confirmpanel_uaresume_Confirmationtext ;
      private string Dvelop_confirmpanel_uaresume_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_uaresume_Nobuttoncaption ;
      private string Dvelop_confirmpanel_uaresume_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_uaresume_Yesbuttonposition ;
      private string Dvelop_confirmpanel_uaresume_Confirmtype ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string divTablemain_Class ;
      private string ClassString ;
      private string StyleString ;
      private string divTableright_Internalname ;
      private string TempTags ;
      private string bttBtnopendiscussion_Internalname ;
      private string bttBtnopendiscussion_Jsonclick ;
      private string divTablecontent_Internalname ;
      private string WebComp_Wcwwp_dynamicformfs_wc_Component ;
      private string OldWcwwp_dynamicformfs_wc ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string bttBtnuaresume_Internalname ;
      private string bttBtnuaresume_Jsonclick ;
      private string divMissingform_Internalname ;
      private string lblFormdeleted_Internalname ;
      private string lblFormdeleted_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavSessionid_Internalname ;
      private string edtavSessionid_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string Dvelop_confirmpanel_uaresume_Internalname ;
      private string GXt_char1 ;
      private string AV33FormInstanceIdString ;
      private string AV44Formlink ;
      private string sStyleString ;
      private string tblTabledvelop_confirmpanel_uaresume_Internalname ;
      private string sCtrlAV14WWPFormReferenceName ;
      private string sCtrlAV9WWPFormInstanceId ;
      private string sCtrlAV8WWPDynamicFormMode ;
      private string sCtrlAV28AccessToken ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool A232WWPFormIsWizard ;
      private bool AV23ExecuteEnterEvent ;
      private bool AV11WWPFormIsWizard ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV39isTokenValid ;
      private bool BRK7J3 ;
      private bool AV17Resuming ;
      private bool AV16AllowResumingDeprecatedFormVersion ;
      private bool AV20HasErrors ;
      private bool bDynCreated_Wcwwp_dynamicformfs_wc ;
      private string AV28AccessToken ;
      private string wcpOAV28AccessToken ;
      private string A235WWPFormResumeMessage ;
      private string AV18WWPFormResumeMessage ;
      private string AV14WWPFormReferenceName ;
      private string wcpOAV14WWPFormReferenceName ;
      private string AV32FormName ;
      private string AV27ResidentGUID ;
      private string AV30ResidentName ;
      private string A208WWPFormReferenceName ;
      private string A209WWPFormTitle ;
      private string AV22DefaultStep ;
      private string AV13ErrorIds ;
      private string AV31NotificationDescription ;
      private IGxSession AV6WebSession ;
      private GXWebComponent WebComp_Wcwwp_dynamicformfs_wc ;
      private GXUserControl ucDvelop_confirmpanel_uaresume ;
      private GXWebForm Form ;
      private GxHttpRequest AV10HttpRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV7WWPFormInstance ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV29GAMUser ;
      private IDataStoreProvider pr_default ;
      private short[] H007J2_A207WWPFormVersionNumber ;
      private short[] H007J2_A206WWPFormId ;
      private string[] H007J2_A208WWPFormReferenceName ;
      private short[] H007J2_A216WWPFormResume ;
      private string[] H007J2_A235WWPFormResumeMessage ;
      private string[] H007J2_A209WWPFormTitle ;
      private string[] H007J3_A208WWPFormReferenceName ;
      private short[] H007J3_A206WWPFormId ;
      private short[] H007J3_A207WWPFormVersionNumber ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance GXt_SdtWWP_FormInstance2 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV21Messages ;
      private SdtSDT_NotificationMetadata AV36SDT_NotificationMetadata ;
      private SdtUSDTNotificationMetadata AV37WWPNotificationMetadataSDT ;
      private GxSimpleCollection<Guid> AV34ResidentIdCollection ;
      private SdtSDT_OneSignalCustomData AV38Metadata ;
      private GeneXus.Utils.SdtMessages_Message AV19Message ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV12WWPForm ;
      private short[] H007J4_A207WWPFormVersionNumber ;
      private short[] H007J4_A206WWPFormId ;
      private bool[] H007J4_A232WWPFormIsWizard ;
      private string[] H007J4_A209WWPFormTitle ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wc_residentdynamicform__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wc_residentdynamicform__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wc_residentdynamicform__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new ForEachCursor(def[2])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmH007J2;
       prmH007J2 = new Object[] {
       };
       Object[] prmH007J3;
       prmH007J3 = new Object[] {
       new ParDef("AV14WWPFormReferenceName",GXType.VarChar,100,0)
       };
       Object[] prmH007J4;
       prmH007J4 = new Object[] {
       new ParDef("AV7WWPFormInstance__Wwpformid",GXType.Int16,4,0) ,
       new ParDef("AV7WWPFo_1Wwpformversionnumbe",GXType.Int16,4,0)
       };
       def= new CursorDef[] {
           new CursorDef("H007J2", "SELECT WWPFormVersionNumber, WWPFormId, WWPFormReferenceName, WWPFormResume, WWPFormResumeMessage, WWPFormTitle FROM WWP_Form ORDER BY WWPFormId DESC, WWPFormVersionNumber DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007J2,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H007J3", "SELECT WWPFormReferenceName, WWPFormId, WWPFormVersionNumber FROM WWP_Form WHERE WWPFormReferenceName = ( :AV14WWPFormReferenceName) ORDER BY WWPFormReferenceName, WWPFormVersionNumber DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007J3,1, GxCacheFrequency.OFF ,false,true )
          ,new CursorDef("H007J4", "SELECT WWPFormVersionNumber, WWPFormId, WWPFormIsWizard, WWPFormTitle FROM WWP_Form WHERE WWPFormId = :AV7WWPFormInstance__Wwpformid and WWPFormVersionNumber = :AV7WWPFo_1Wwpformversionnumbe ORDER BY WWPFormId, WWPFormVersionNumber ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007J4,1, GxCacheFrequency.OFF ,false,true )
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
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             return;
          case 1 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             return;
          case 2 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
    }
 }

}

}
