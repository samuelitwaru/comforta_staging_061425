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
   public class udfc_fs_wc : GXWebComponent
   {
      public udfc_fs_wc( )
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

      public udfc_fs_wc( IGxContext context )
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
         this.AV22WWPDynamicFormMode = aP0_WWPDynamicFormMode;
         this.AV25WWPFormElementId = aP1_WWPFormElementId;
         this.AV15SessionId = aP2_SessionId;
         this.AV23WWPForm = aP3_WWPForm;
         ExecuteImpl();
         aP3_WWPForm=this.AV23WWPForm;
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
                  AV22WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
                  AssignAttri(sPrefix, false, "AV22WWPDynamicFormMode", AV22WWPDynamicFormMode);
                  AV25WWPFormElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV25WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV25WWPFormElementId), 4, 0));
                  AV15SessionId = (short)(Math.Round(NumberUtil.Val( GetPar( "SessionId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV15SessionId", StringUtil.LTrimStr( (decimal)(AV15SessionId), 4, 0));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV23WWPForm);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV22WWPDynamicFormMode,(short)AV25WWPFormElementId,(short)AV15SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV23WWPForm});
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
         AV10IsFirstElement = StringUtil.StrToBool( GetPar( "IsFirstElement"));
         AV11IsLastElement = StringUtil.StrToBool( GetPar( "IsLastElement"));
         AV5AllowDeletion = StringUtil.StrToBool( GetPar( "AllowDeletion"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV23WWPForm);
         AV25WWPFormElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementId"), "."), 18, MidpointRounding.ToEven));
         AV22WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
         AV15SessionId = (short)(Math.Round(NumberUtil.Val( GetPar( "SessionId"), "."), 18, MidpointRounding.ToEven));
         AV6Columns = (short)(Math.Round(NumberUtil.Val( GetPar( "Columns"), "."), 18, MidpointRounding.ToEven));
         AV12IsStep = StringUtil.StrToBool( GetPar( "IsStep"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrFsgrid_refresh( AV10IsFirstElement, AV11IsLastElement, AV5AllowDeletion, AV23WWPForm, AV25WWPFormElementId, AV22WWPDynamicFormMode, AV15SessionId, AV6Columns, AV12IsStep, sPrefix) ;
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
            PA9T2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS9T2( ) ;
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
            GXEncryptionTmp = "udfc_fs_wc.aspx"+UrlEncode(StringUtil.RTrim(AV22WWPDynamicFormMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV25WWPFormElementId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV15SessionId,4,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("udfc_fs_wc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISFIRSTELEMENT", AV10IsFirstElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISFIRSTELEMENT", GetSecureSignedToken( sPrefix, AV10IsFirstElement, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISLASTELEMENT", AV11IsLastElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISLASTELEMENT", GetSecureSignedToken( sPrefix, AV11IsLastElement, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vALLOWDELETION", AV5AllowDeletion);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vALLOWDELETION", GetSecureSignedToken( sPrefix, AV5AllowDeletion, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCOLUMNS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6Columns), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCOLUMNS", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV6Columns), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISSTEP", AV12IsStep);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISSTEP", GetSecureSignedToken( sPrefix, AV12IsStep, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_9", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_9), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV22WWPDynamicFormMode", StringUtil.RTrim( wcpOAV22WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV25WWPFormElementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV25WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV15SessionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV15SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISFIRSTELEMENT", AV10IsFirstElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISFIRSTELEMENT", GetSecureSignedToken( sPrefix, AV10IsFirstElement, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISLASTELEMENT", AV11IsLastElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISLASTELEMENT", GetSecureSignedToken( sPrefix, AV11IsLastElement, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vALLOWDELETION", AV5AllowDeletion);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vALLOWDELETION", GetSecureSignedToken( sPrefix, AV5AllowDeletion, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORM", AV23WWPForm);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORM", AV23WWPForm);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV22WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCOLUMNS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6Columns), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCOLUMNS", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV6Columns), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISSTEP", AV12IsStep);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISSTEP", GetSecureSignedToken( sPrefix, AV12IsStep, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"subFsgrid_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFsgrid_Recordcount), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_BTNDELETEELEMENT_Result", StringUtil.RTrim( Dvelop_confirmpanel_btndeleteelement_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"SETTINGS_MODAL_Result", StringUtil.RTrim( Settings_modal_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"ADDELEMENT_MODAL_Result", StringUtil.RTrim( Addelement_modal_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_BTNDELETEELEMENT_Result", StringUtil.RTrim( Dvelop_confirmpanel_btndeleteelement_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"SETTINGS_MODAL_Result", StringUtil.RTrim( Settings_modal_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"ADDELEMENT_MODAL_Result", StringUtil.RTrim( Addelement_modal_Result));
      }

      protected void RenderHtmlCloseForm9T2( )
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
            if ( ! ( WebComp_Wcchildren == null ) )
            {
               WebComp_Wcchildren.componentjscripts();
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
         return "UDFC_FS_WC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WWP_Dynamic Form Creation_FS_WC", "") ;
      }

      protected void WB9T0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "udfc_fs_wc.aspx");
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
            GxWebStd.gx_div_start( context, divFsgridcell_Internalname, 1, 0, "px", 0, "px", divFsgridcell_Class, "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 TableDynFormAddElementCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", divTableactions_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "end", "top", "", "", "div");
            wb_table1_19_9T2( true) ;
         }
         else
         {
            wb_table1_19_9T2( false) ;
         }
         return  ;
      }

      protected void wb_table1_19_9T2e( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnrefreshgrid_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(9), 1, 0)+","+"null"+");", context.GetMessage( "Refresh", ""), bttBtnrefreshgrid_Jsonclick, 5, context.GetMessage( "Refresh", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOREFRESHGRID\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_UDFC_FS_WC.htm");
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
            wb_table2_37_9T2( true) ;
         }
         else
         {
            wb_table2_37_9T2( false) ;
         }
         return  ;
      }

      protected void wb_table2_37_9T2e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table3_42_9T2( true) ;
         }
         else
         {
            wb_table3_42_9T2( false) ;
         }
         return  ;
      }

      protected void wb_table3_42_9T2e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table4_47_9T2( true) ;
         }
         else
         {
            wb_table4_47_9T2( false) ;
         }
         return  ;
      }

      protected void wb_table4_47_9T2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, sPrefix+"W0053"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0053"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_9_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0053"+"");
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

      protected void START9T2( )
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
            Form.Meta.addItem("description", context.GetMessage( "WWP_Dynamic Form Creation_FS_WC", ""), 0) ;
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
               STRUP9T0( ) ;
            }
         }
      }

      protected void WS9T2( )
      {
         START9T2( ) ;
         EVT9T2( ) ;
      }

      protected void EVT9T2( )
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
                                 STRUP9T0( ) ;
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
                                 STRUP9T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Dvelop_confirmpanel_btndeleteelement.Close */
                                    E119T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "SETTINGS_MODAL.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP9T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Settings_modal.Close */
                                    E129T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "SETTINGS_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP9T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Settings_modal.Onloadcomponent */
                                    E139T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ADDELEMENT_MODAL.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP9T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Addelement_modal.Close */
                                    E149T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ADDELEMENT_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP9T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Addelement_modal.Onloadcomponent */
                                    E159T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOREFRESHGRID'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP9T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoRefreshGrid' */
                                    E169T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOMOVEUP'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP9T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoMoveUp' */
                                    E179T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOMOVEDOWN'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP9T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoMoveDown' */
                                    E189T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP9T0( ) ;
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
                                 STRUP9T0( ) ;
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
                                          E199T2 ();
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
                                          E209T2 ();
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
                                          E219T2 ();
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
                                       STRUP9T0( ) ;
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
                        if ( nCmpId == 53 )
                        {
                           OldWwpaux_wc = cgiGet( sPrefix+"W0053");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess(sPrefix+"W0053", "", sEvt);
                           }
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                        else if ( nCmpId == 13 )
                        {
                           sEvtType = StringUtil.Left( sEvt, 4);
                           sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           sCmpCtrl = "W0013" + sEvtType;
                           OldWcchildren = cgiGet( sPrefix+sCmpCtrl);
                           if ( ( StringUtil.Len( OldWcchildren) == 0 ) || ( StringUtil.StrCmp(OldWcchildren, WebComp_GX_Process_Component) != 0 ) )
                           {
                              WebComp_GX_Process = getWebComponent(GetType(), "GeneXus.Programs", OldWcchildren, new Object[] {context} );
                              WebComp_GX_Process.ComponentInit();
                              WebComp_GX_Process.Name = "OldWcchildren";
                              WebComp_GX_Process_Component = OldWcchildren;
                           }
                           if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
                           {
                              WebComp_GX_Process.componentprocess(sPrefix+"W0013", sEvtType, sEvt);
                           }
                           nGXsfl_9_webc_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                           WebCompHandler = "Wcchildren";
                           WebComp_GX_Process_Component = OldWcchildren;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE9T2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm9T2( ) ;
            }
         }
      }

      protected void PA9T2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "udfc_fs_wc.aspx")), "udfc_fs_wc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "udfc_fs_wc.aspx")))) ;
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

      protected void gxgrFsgrid_refresh( bool AV10IsFirstElement ,
                                         bool AV11IsLastElement ,
                                         bool AV5AllowDeletion ,
                                         GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV23WWPForm ,
                                         short AV25WWPFormElementId ,
                                         string AV22WWPDynamicFormMode ,
                                         short AV15SessionId ,
                                         short AV6Columns ,
                                         bool AV12IsStep ,
                                         string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FSGRID_nCurrentRecord = 0;
         RF9T2( ) ;
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
         RF9T2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF9T2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            FsgridContainer.ClearRows();
         }
         wbStart = 9;
         /* Execute user event: Refresh */
         E209T2 ();
         nGXsfl_9_idx = 1;
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
         bGXsfl_9_Refreshing = true;
         FsgridContainer.AddObjectProperty("GridName", "Fsgrid");
         FsgridContainer.AddObjectProperty("CmpContext", sPrefix);
         FsgridContainer.AddObjectProperty("InMasterPage", "false");
         FsgridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         FsgridContainer.AddObjectProperty("Class", "FreeStyleGrid");
         FsgridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         FsgridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
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
               if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
               {
                  WebComp_Wcchildren.componentstart();
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
            E219T2 ();
            wbEnd = 9;
            WB9T0( ) ;
         }
         bGXsfl_9_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes9T2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISFIRSTELEMENT", AV10IsFirstElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISFIRSTELEMENT", GetSecureSignedToken( sPrefix, AV10IsFirstElement, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISLASTELEMENT", AV11IsLastElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISLASTELEMENT", GetSecureSignedToken( sPrefix, AV11IsLastElement, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vALLOWDELETION", AV5AllowDeletion);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vALLOWDELETION", GetSecureSignedToken( sPrefix, AV5AllowDeletion, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCOLUMNS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6Columns), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCOLUMNS", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV6Columns), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISSTEP", AV12IsStep);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISSTEP", GetSecureSignedToken( sPrefix, AV12IsStep, context));
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

      protected void STRUP9T0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E199T2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_9 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_9"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV22WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV22WWPDynamicFormMode");
            wcpOAV25WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV25WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV15SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV15SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         E199T2 ();
         if (returnInSub) return;
      }

      protected void E199T2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV10IsFirstElement = true;
         AssignAttri(sPrefix, false, "AV10IsFirstElement", AV10IsFirstElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISFIRSTELEMENT", GetSecureSignedToken( sPrefix, AV10IsFirstElement, context));
         AV11IsLastElement = true;
         AssignAttri(sPrefix, false, "AV11IsLastElement", AV11IsLastElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISLASTELEMENT", GetSecureSignedToken( sPrefix, AV11IsLastElement, context));
         if ( (0==AV25WWPFormElementId) )
         {
            AV5AllowDeletion = false;
            AssignAttri(sPrefix, false, "AV5AllowDeletion", AV5AllowDeletion);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vALLOWDELETION", GetSecureSignedToken( sPrefix, AV5AllowDeletion, context));
            Btnsettings_Caption = context.GetMessage( "WWP_DF_FormSettings", "");
            ucBtnsettings.SendProperty(context, sPrefix, false, Btnsettings_Internalname, "Caption", Btnsettings_Caption);
         }
         else
         {
            AV5AllowDeletion = true;
            AssignAttri(sPrefix, false, "AV5AllowDeletion", AV5AllowDeletion);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vALLOWDELETION", GetSecureSignedToken( sPrefix, AV5AllowDeletion, context));
            GXt_SdtWWP_Form_Element1 = AV7CurrentElement;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getelementbyid(context ).execute( ref  AV23WWPForm,  AV25WWPFormElementId, out  GXt_SdtWWP_Form_Element1) ;
            AV7CurrentElement = GXt_SdtWWP_Form_Element1;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_dfc_canmoveelement(context ).execute(  AV23WWPForm,  AV7CurrentElement, out  AV10IsFirstElement, out  AV11IsLastElement) ;
            AssignAttri(sPrefix, false, "AV10IsFirstElement", AV10IsFirstElement);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISFIRSTELEMENT", GetSecureSignedToken( sPrefix, AV10IsFirstElement, context));
            AssignAttri(sPrefix, false, "AV11IsLastElement", AV11IsLastElement);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISLASTELEMENT", GetSecureSignedToken( sPrefix, AV11IsLastElement, context));
            if ( AV7CurrentElement.gxTpr_Wwpformelementtype == 2 )
            {
               AV19WWP_DF_GroupMetadata.FromJSonString(AV7CurrentElement.gxTpr_Wwpformelementmetadata, null);
               if ( AV19WWP_DF_GroupMetadata.gxTpr_Style == 0 )
               {
                  divLayoutmaintable_Class = "Table TableDynFormConatinerNoStyle";
                  AssignProp(sPrefix, false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
                  divTableactions_Class = divTableactions_Class+" TableDynFormAddElementConatinerNoStyle";
                  AssignProp(sPrefix, false, divTableactions_Internalname, "Class", divTableactions_Class, true);
               }
               AV6Columns = AV19WWP_DF_GroupMetadata.gxTpr_Columns;
               AssignAttri(sPrefix, false, "AV6Columns", StringUtil.LTrimStr( (decimal)(AV6Columns), 4, 0));
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCOLUMNS", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV6Columns), "ZZZ9"), context));
               Dvelop_confirmpanel_btndeleteelement_Confirmationtext = StringUtil.Format( context.GetMessage( "WWP_DF_ConfirmationDeleteElement", ""), context.GetMessage( "WWP_DF_Container", ""), "", "", "", "", "", "", "", "");
               ucDvelop_confirmpanel_btndeleteelement.SendProperty(context, sPrefix, false, Dvelop_confirmpanel_btndeleteelement_Internalname, "ConfirmationText", Dvelop_confirmpanel_btndeleteelement_Confirmationtext);
               Btnmoveup_Caption = StringUtil.Format( context.GetMessage( "WWP_DF_MoveUpElement", ""), context.GetMessage( "WWP_DF_Container", ""), "", "", "", "", "", "", "", "");
               ucBtnmoveup.SendProperty(context, sPrefix, false, Btnmoveup_Internalname, "Caption", Btnmoveup_Caption);
               Btnmovedown_Caption = StringUtil.Format( context.GetMessage( "WWP_DF_MoveDownElement", ""), context.GetMessage( "WWP_DF_Container", ""), "", "", "", "", "", "", "", "");
               ucBtnmovedown.SendProperty(context, sPrefix, false, Btnmovedown_Internalname, "Caption", Btnmovedown_Caption);
               AV5AllowDeletion = false;
               AssignAttri(sPrefix, false, "AV5AllowDeletion", AV5AllowDeletion);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vALLOWDELETION", GetSecureSignedToken( sPrefix, AV5AllowDeletion, context));
               Btnsettings_Caption = StringUtil.Format( context.GetMessage( "WWP_DF_ElementSettings", ""), context.GetMessage( "WWP_DF_Container", ""), "", "", "", "", "", "", "", "");
               ucBtnsettings.SendProperty(context, sPrefix, false, Btnsettings_Internalname, "Caption", Btnsettings_Caption);
               Btndeleteelement_Caption = StringUtil.Format( context.GetMessage( "WWP_DF_DeleteElement", ""), context.GetMessage( "WWP_DF_Container", ""), "", "", "", "", "", "", "", "");
               ucBtndeleteelement.SendProperty(context, sPrefix, false, Btndeleteelement_Internalname, "Caption", Btndeleteelement_Caption);
            }
            else if ( AV7CurrentElement.gxTpr_Wwpformelementtype == 5 )
            {
               AV12IsStep = true;
               AssignAttri(sPrefix, false, "AV12IsStep", AV12IsStep);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISSTEP", GetSecureSignedToken( sPrefix, AV12IsStep, context));
               AV21WWP_DF_StepMetadata.FromJSonString(AV7CurrentElement.gxTpr_Wwpformelementmetadata, null);
               AV6Columns = AV21WWP_DF_StepMetadata.gxTpr_Columns;
               AssignAttri(sPrefix, false, "AV6Columns", StringUtil.LTrimStr( (decimal)(AV6Columns), 4, 0));
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCOLUMNS", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV6Columns), "ZZZ9"), context));
               Btnmoveup_Caption = context.GetMessage( "WWP_DF_MoveStepLeft", "");
               ucBtnmoveup.SendProperty(context, sPrefix, false, Btnmoveup_Internalname, "Caption", Btnmoveup_Caption);
               Btnmoveup_Beforeiconclass = "fas fa-arrow-left";
               ucBtnmoveup.SendProperty(context, sPrefix, false, Btnmoveup_Internalname, "BeforeIconClass", Btnmoveup_Beforeiconclass);
               Btnmovedown_Caption = context.GetMessage( "WWP_DF_MoveStepRight", "");
               ucBtnmovedown.SendProperty(context, sPrefix, false, Btnmovedown_Internalname, "Caption", Btnmovedown_Caption);
               Btnmovedown_Beforeiconclass = "fas fa-arrow-right";
               ucBtnmovedown.SendProperty(context, sPrefix, false, Btnmovedown_Internalname, "BeforeIconClass", Btnmovedown_Beforeiconclass);
               Btnsettings_Caption = StringUtil.Format( context.GetMessage( "WWP_DF_ElementSettings", ""), context.GetMessage( "WWP_DF_Step", ""), "", "", "", "", "", "", "", "");
               ucBtnsettings.SendProperty(context, sPrefix, false, Btnsettings_Internalname, "Caption", Btnsettings_Caption);
               Btndeleteelement_Caption = StringUtil.Format( context.GetMessage( "WWP_DF_DeleteElement", ""), context.GetMessage( "WWP_DF_Step", ""), "", "", "", "", "", "", "", "");
               ucBtndeleteelement.SendProperty(context, sPrefix, false, Btndeleteelement_Internalname, "Caption", Btndeleteelement_Caption);
               Dvelop_confirmpanel_btndeleteelement_Confirmationtext = StringUtil.Format( context.GetMessage( "WWP_DF_ConfirmationDeleteContainer", ""), context.GetMessage( "WWP_DF_Step", ""), "", "", "", "", "", "", "", "");
               ucDvelop_confirmpanel_btndeleteelement.SendProperty(context, sPrefix, false, Dvelop_confirmpanel_btndeleteelement_Internalname, "ConfirmationText", Dvelop_confirmpanel_btndeleteelement_Confirmationtext);
            }
            else if ( AV7CurrentElement.gxTpr_Wwpformelementtype == 3 )
            {
               AV20WWP_DF_ElementsRepeaterMetadata.FromJSonString(AV7CurrentElement.gxTpr_Wwpformelementmetadata, null);
               AV6Columns = AV20WWP_DF_ElementsRepeaterMetadata.gxTpr_Columns;
               AssignAttri(sPrefix, false, "AV6Columns", StringUtil.LTrimStr( (decimal)(AV6Columns), 4, 0));
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCOLUMNS", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV6Columns), "ZZZ9"), context));
               divTablemain_Class = ((AV20WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionsdatatype==1) ? "TableDynFormMultipleDataCreation" : "Table");
               AssignProp(sPrefix, false, divTablemain_Internalname, "Class", divTablemain_Class, true);
               AV20WWP_DF_ElementsRepeaterMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ElementsRepeaterMetadata(context);
               Dvelop_confirmpanel_btndeleteelement_Confirmationtext = StringUtil.Format( context.GetMessage( "WWP_DF_ConfirmationDeleteContainer", ""), context.GetMessage( "WWP_DF_MultipleDataSection", ""), "", "", "", "", "", "", "", "");
               ucDvelop_confirmpanel_btndeleteelement.SendProperty(context, sPrefix, false, Dvelop_confirmpanel_btndeleteelement_Internalname, "ConfirmationText", Dvelop_confirmpanel_btndeleteelement_Confirmationtext);
               Btnmoveup_Caption = StringUtil.Format( context.GetMessage( "WWP_DF_MoveUpElement", ""), context.GetMessage( "WWP_DF_MultipleDataSection", ""), "", "", "", "", "", "", "", "");
               ucBtnmoveup.SendProperty(context, sPrefix, false, Btnmoveup_Internalname, "Caption", Btnmoveup_Caption);
               Btnmovedown_Caption = StringUtil.Format( context.GetMessage( "WWP_DF_MoveDownElement", ""), context.GetMessage( "WWP_DF_MultipleDataSection", ""), "", "", "", "", "", "", "", "");
               ucBtnmovedown.SendProperty(context, sPrefix, false, Btnmovedown_Internalname, "Caption", Btnmovedown_Caption);
               Btndeleteelement_Caption = StringUtil.Format( context.GetMessage( "WWP_DF_DeleteElement", ""), context.GetMessage( "WWP_DF_MultipleDataSection", ""), "", "", "", "", "", "", "", "");
               ucBtndeleteelement.SendProperty(context, sPrefix, false, Btndeleteelement_Internalname, "Caption", Btndeleteelement_Caption);
               if ( ! AV10IsFirstElement && ! AV11IsLastElement )
               {
                  Btnsettings_Caption = StringUtil.Format( context.GetMessage( "WWP_DF_ElementSettings", ""), context.GetMessage( "WWP_DF_MultipleDataSection", ""), "", "", "", "", "", "", "", "");
                  ucBtnsettings.SendProperty(context, sPrefix, false, Btnsettings_Internalname, "Caption", Btnsettings_Caption);
               }
            }
            GXt_boolean2 = (bool)(Convert.ToBoolean(AV14ParentIsGridMultipleData));
            if ( new GeneXus.Programs.workwithplus.dynamicforms.wwp_dfc_showsmallbuttons(context).executeUdp( ref  AV23WWPForm,  AV7CurrentElement.gxTpr_Wwpformelementparentid,  true, out  GXt_boolean2) )
            {
               Btnmoveup_Tooltiptext = Btnmoveup_Caption;
               ucBtnmoveup.SendProperty(context, sPrefix, false, Btnmoveup_Internalname, "TooltipText", Btnmoveup_Tooltiptext);
               Btnmoveup_Caption = "";
               ucBtnmoveup.SendProperty(context, sPrefix, false, Btnmoveup_Internalname, "Caption", Btnmoveup_Caption);
               Btnmovedown_Tooltiptext = Btnmovedown_Caption;
               ucBtnmovedown.SendProperty(context, sPrefix, false, Btnmovedown_Internalname, "TooltipText", Btnmovedown_Tooltiptext);
               Btnmovedown_Caption = "";
               ucBtnmovedown.SendProperty(context, sPrefix, false, Btnmovedown_Internalname, "Caption", Btnmovedown_Caption);
               Btnsettings_Tooltiptext = Btnsettings_Caption;
               ucBtnsettings.SendProperty(context, sPrefix, false, Btnsettings_Internalname, "TooltipText", Btnsettings_Tooltiptext);
               Btnsettings_Caption = "";
               ucBtnsettings.SendProperty(context, sPrefix, false, Btnsettings_Internalname, "Caption", Btnsettings_Caption);
               Btndeleteelement_Tooltiptext = Btndeleteelement_Caption;
               ucBtndeleteelement.SendProperty(context, sPrefix, false, Btndeleteelement_Internalname, "TooltipText", Btndeleteelement_Tooltiptext);
               Btndeleteelement_Caption = "";
               ucBtndeleteelement.SendProperty(context, sPrefix, false, Btndeleteelement_Internalname, "Caption", Btndeleteelement_Caption);
            }
         }
         AV6Columns = (short)(((0==AV6Columns) ? 1 : AV6Columns));
         AssignAttri(sPrefix, false, "AV6Columns", StringUtil.LTrimStr( (decimal)(AV6Columns), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCOLUMNS", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV6Columns), "ZZZ9"), context));
         divFsgridcell_Class = StringUtil.Format( "col-xs-12 DynamicFormGridCell%1Columns", StringUtil.Trim( StringUtil.Str( (decimal)(AV6Columns), 4, 0)), "", "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, divFsgridcell_Internalname, "Class", divFsgridcell_Class, true);
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
      }

      protected void E209T2( )
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
         /*  Sending Event outputs  */
      }

      private void E219T2( )
      {
         /* Fsgrid_Load Routine */
         returnInSub = false;
         AV13LoadedElements = 0;
         AV28GXV1 = 1;
         while ( AV28GXV1 <= AV23WWPForm.gxTpr_Element.Count )
         {
            AV24WWPFormElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV23WWPForm.gxTpr_Element.Item(AV28GXV1));
            if ( AV24WWPFormElement.gxTpr_Wwpformelementparentid == AV25WWPFormElementId )
            {
               if ( AV24WWPFormElement.gxTpr_Wwpformelementtype == 1 )
               {
                  if ( AV24WWPFormElement.gxTpr_Wwpformelementdatatype == 1 )
                  {
                     AV17WWP_DF_BooleanMetadata.FromJSonString(AV24WWPFormElement.gxTpr_Wwpformelementmetadata, null);
                     if ( AV17WWP_DF_BooleanMetadata.gxTpr_Controltype == 1 )
                     {
                        /* Object Property */
                        if ( StringUtil.Len( sPrefix) == 0 )
                        {
                           bDynCreated_Wcchildren = true;
                        }
                        if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_Checkbox_WC")) != 0 )
                        {
                           WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_checkbox_wc", new Object[] {context} );
                           WebComp_Wcchildren.ComponentInit();
                           WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DFC_Checkbox_WC";
                           WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DFC_Checkbox_WC";
                        }
                        if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                        {
                           WebComp_Wcchildren.setjustcreated();
                           WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV22WWPDynamicFormMode,AV24WWPFormElement.gxTpr_Wwpformelementid,(short)AV15SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV23WWPForm});
                           WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
                        }
                     }
                     else
                     {
                        /* Object Property */
                        if ( StringUtil.Len( sPrefix) == 0 )
                        {
                           bDynCreated_Wcchildren = true;
                        }
                        if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_Switch_WC")) != 0 )
                        {
                           WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_switch_wc", new Object[] {context} );
                           WebComp_Wcchildren.ComponentInit();
                           WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DFC_Switch_WC";
                           WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DFC_Switch_WC";
                        }
                        if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                        {
                           WebComp_Wcchildren.setjustcreated();
                           WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV22WWPDynamicFormMode,AV24WWPFormElement.gxTpr_Wwpformelementid,(short)AV15SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV23WWPForm});
                           WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
                        }
                     }
                  }
                  else if ( AV24WWPFormElement.gxTpr_Wwpformelementdatatype == 4 )
                  {
                     /* Object Property */
                     if ( StringUtil.Len( sPrefix) == 0 )
                     {
                        bDynCreated_Wcchildren = true;
                     }
                     if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_Date_WC")) != 0 )
                     {
                        WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_date_wc", new Object[] {context} );
                        WebComp_Wcchildren.ComponentInit();
                        WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DFC_Date_WC";
                        WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DFC_Date_WC";
                     }
                     if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                     {
                        WebComp_Wcchildren.setjustcreated();
                        WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV22WWPDynamicFormMode,AV24WWPFormElement.gxTpr_Wwpformelementid,(short)AV15SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV23WWPForm});
                        WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
                     }
                  }
                  else if ( AV24WWPFormElement.gxTpr_Wwpformelementdatatype == 5 )
                  {
                     /* Object Property */
                     if ( StringUtil.Len( sPrefix) == 0 )
                     {
                        bDynCreated_Wcchildren = true;
                     }
                     if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_Datetime_WC")) != 0 )
                     {
                        WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_datetime_wc", new Object[] {context} );
                        WebComp_Wcchildren.ComponentInit();
                        WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DFC_Datetime_WC";
                        WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DFC_Datetime_WC";
                     }
                     if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                     {
                        WebComp_Wcchildren.setjustcreated();
                        WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV22WWPDynamicFormMode,AV24WWPFormElement.gxTpr_Wwpformelementid,(short)AV15SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV23WWPForm});
                        WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
                     }
                  }
                  else if ( AV24WWPFormElement.gxTpr_Wwpformelementdatatype == 2 )
                  {
                     /* Object Property */
                     if ( StringUtil.Len( sPrefix) == 0 )
                     {
                        bDynCreated_Wcchildren = true;
                     }
                     if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_Datetime_WC")) != 0 )
                     {
                        WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_datetime_wc", new Object[] {context} );
                        WebComp_Wcchildren.ComponentInit();
                        WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DFC_Datetime_WC";
                        WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DFC_Datetime_WC";
                     }
                     if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                     {
                        WebComp_Wcchildren.setjustcreated();
                        WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV22WWPDynamicFormMode,AV24WWPFormElement.gxTpr_Wwpformelementid,(short)AV15SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV23WWPForm});
                        WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
                     }
                     AV18WWP_DF_CharMetadata.FromJSonString(AV24WWPFormElement.gxTpr_Wwpformelementmetadata, null);
                     if ( AV18WWP_DF_CharMetadata.gxTpr_Controltype == 2 )
                     {
                        /* Object Property */
                        if ( StringUtil.Len( sPrefix) == 0 )
                        {
                           bDynCreated_Wcchildren = true;
                        }
                        if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_TextArea_WC")) != 0 )
                        {
                           WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_textarea_wc", new Object[] {context} );
                           WebComp_Wcchildren.ComponentInit();
                           WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DFC_TextArea_WC";
                           WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DFC_TextArea_WC";
                        }
                        if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                        {
                           WebComp_Wcchildren.setjustcreated();
                           WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV22WWPDynamicFormMode,AV24WWPFormElement.gxTpr_Wwpformelementid,(short)AV15SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV23WWPForm});
                           WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
                        }
                     }
                     else if ( AV18WWP_DF_CharMetadata.gxTpr_Controltype == 3 )
                     {
                        /* Object Property */
                        if ( StringUtil.Len( sPrefix) == 0 )
                        {
                           bDynCreated_Wcchildren = true;
                        }
                        if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_HTMLEditor_WC")) != 0 )
                        {
                           WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_htmleditor_wc", new Object[] {context} );
                           WebComp_Wcchildren.ComponentInit();
                           WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DFC_HTMLEditor_WC";
                           WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DFC_HTMLEditor_WC";
                        }
                        if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                        {
                           WebComp_Wcchildren.setjustcreated();
                           WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV22WWPDynamicFormMode,AV24WWPFormElement.gxTpr_Wwpformelementid,(short)AV15SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV23WWPForm});
                           WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
                        }
                     }
                     else if ( ( AV18WWP_DF_CharMetadata.gxTpr_Controltype == 4 ) && ( AV18WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Controltype != 2 ) )
                     {
                        if ( AV18WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Controltype == 1 )
                        {
                           /* Object Property */
                           if ( StringUtil.Len( sPrefix) == 0 )
                           {
                              bDynCreated_Wcchildren = true;
                           }
                           if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_ComboBox_WC")) != 0 )
                           {
                              WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_combobox_wc", new Object[] {context} );
                              WebComp_Wcchildren.ComponentInit();
                              WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DFC_ComboBox_WC";
                              WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DFC_ComboBox_WC";
                           }
                           if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                           {
                              WebComp_Wcchildren.setjustcreated();
                              WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV22WWPDynamicFormMode,AV24WWPFormElement.gxTpr_Wwpformelementid,(short)AV15SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV23WWPForm});
                              WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
                           }
                        }
                        else if ( AV18WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Controltype == 3 )
                        {
                           /* Object Property */
                           if ( StringUtil.Len( sPrefix) == 0 )
                           {
                              bDynCreated_Wcchildren = true;
                           }
                           if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_Radiobutton_WC")) != 0 )
                           {
                              WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_radiobutton_wc", new Object[] {context} );
                              WebComp_Wcchildren.ComponentInit();
                              WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DFC_Radiobutton_WC";
                              WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DFC_Radiobutton_WC";
                           }
                           if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                           {
                              WebComp_Wcchildren.setjustcreated();
                              WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV22WWPDynamicFormMode,AV24WWPFormElement.gxTpr_Wwpformelementid,(short)AV15SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV23WWPForm});
                              WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
                           }
                        }
                        else if ( AV18WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Controltype == 4 )
                        {
                           /* Object Property */
                           if ( StringUtil.Len( sPrefix) == 0 )
                           {
                              bDynCreated_Wcchildren = true;
                           }
                           if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_MCheckBox_WC")) != 0 )
                           {
                              WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_mcheckbox_wc", new Object[] {context} );
                              WebComp_Wcchildren.ComponentInit();
                              WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DFC_MCheckBox_WC";
                              WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DFC_MCheckBox_WC";
                           }
                           if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                           {
                              WebComp_Wcchildren.setjustcreated();
                              WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV22WWPDynamicFormMode,AV24WWPFormElement.gxTpr_Wwpformelementid,(short)AV15SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV23WWPForm});
                              WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
                           }
                        }
                     }
                     else
                     {
                        /* Object Property */
                        if ( StringUtil.Len( sPrefix) == 0 )
                        {
                           bDynCreated_Wcchildren = true;
                        }
                        if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_Text_WC")) != 0 )
                        {
                           WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_text_wc", new Object[] {context} );
                           WebComp_Wcchildren.ComponentInit();
                           WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DFC_Text_WC";
                           WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DFC_Text_WC";
                        }
                        if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                        {
                           WebComp_Wcchildren.setjustcreated();
                           WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV22WWPDynamicFormMode,AV24WWPFormElement.gxTpr_Wwpformelementid,(short)AV15SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV23WWPForm});
                           WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
                        }
                     }
                  }
                  else if ( ( AV24WWPFormElement.gxTpr_Wwpformelementdatatype == 10 ) || ( AV24WWPFormElement.gxTpr_Wwpformelementdatatype == 9 ) )
                  {
                     /* Object Property */
                     if ( StringUtil.Len( sPrefix) == 0 )
                     {
                        bDynCreated_Wcchildren = true;
                     }
                     if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_File_WC")) != 0 )
                     {
                        WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_file_wc", new Object[] {context} );
                        WebComp_Wcchildren.ComponentInit();
                        WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DFC_File_WC";
                        WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DFC_File_WC";
                     }
                     if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                     {
                        WebComp_Wcchildren.setjustcreated();
                        WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV22WWPDynamicFormMode,AV24WWPFormElement.gxTpr_Wwpformelementid,(short)AV15SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV23WWPForm});
                        WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
                     }
                  }
                  else
                  {
                     /* Object Property */
                     if ( StringUtil.Len( sPrefix) == 0 )
                     {
                        bDynCreated_Wcchildren = true;
                     }
                     if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_Text_WC")) != 0 )
                     {
                        WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_text_wc", new Object[] {context} );
                        WebComp_Wcchildren.ComponentInit();
                        WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DFC_Text_WC";
                        WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DFC_Text_WC";
                     }
                     if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                     {
                        WebComp_Wcchildren.setjustcreated();
                        WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV22WWPDynamicFormMode,AV24WWPFormElement.gxTpr_Wwpformelementid,(short)AV15SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV23WWPForm});
                        WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
                     }
                  }
               }
               else if ( AV24WWPFormElement.gxTpr_Wwpformelementtype == 2 )
               {
                  AV19WWP_DF_GroupMetadata.FromJSonString(AV24WWPFormElement.gxTpr_Wwpformelementmetadata, null);
                  if ( AV19WWP_DF_GroupMetadata.gxTpr_Style == 0 )
                  {
                     /* Object Property */
                     if ( StringUtil.Len( sPrefix) == 0 )
                     {
                        bDynCreated_Wcchildren = true;
                     }
                     if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "UDFC_FS_WC")) != 0 )
                     {
                        WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "udfc_fs_wc", new Object[] {context} );
                        WebComp_Wcchildren.ComponentInit();
                        WebComp_Wcchildren.Name = "UDFC_FS_WC";
                        WebComp_Wcchildren_Component = "UDFC_FS_WC";
                     }
                     if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                     {
                        WebComp_Wcchildren.setjustcreated();
                        WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV22WWPDynamicFormMode,AV24WWPFormElement.gxTpr_Wwpformelementid,(short)AV15SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV23WWPForm});
                        WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
                     }
                  }
                  else
                  {
                     /* Object Property */
                     if ( StringUtil.Len( sPrefix) == 0 )
                     {
                        bDynCreated_Wcchildren = true;
                     }
                     if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_Group_WC")) != 0 )
                     {
                        WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_group_wc", new Object[] {context} );
                        WebComp_Wcchildren.ComponentInit();
                        WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DFC_Group_WC";
                        WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DFC_Group_WC";
                     }
                     if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                     {
                        WebComp_Wcchildren.setjustcreated();
                        WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV22WWPDynamicFormMode,AV24WWPFormElement.gxTpr_Wwpformelementid,(short)AV15SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV23WWPForm});
                        WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
                     }
                  }
               }
               else if ( AV24WWPFormElement.gxTpr_Wwpformelementtype == 3 )
               {
                  AV20WWP_DF_ElementsRepeaterMetadata.FromJSonString(AV24WWPFormElement.gxTpr_Wwpformelementmetadata, null);
                  if ( AV20WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionsdatatype == 1 )
                  {
                     /* Object Property */
                     if ( StringUtil.Len( sPrefix) == 0 )
                     {
                        bDynCreated_Wcchildren = true;
                     }
                     if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "UDFC_FS_WC")) != 0 )
                     {
                        WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "udfc_fs_wc", new Object[] {context} );
                        WebComp_Wcchildren.ComponentInit();
                        WebComp_Wcchildren.Name = "UDFC_FS_WC";
                        WebComp_Wcchildren_Component = "UDFC_FS_WC";
                     }
                     if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                     {
                        WebComp_Wcchildren.setjustcreated();
                        WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV22WWPDynamicFormMode,AV24WWPFormElement.gxTpr_Wwpformelementid,(short)AV15SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV23WWPForm});
                        WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
                     }
                  }
                  else
                  {
                     /* Object Property */
                     if ( StringUtil.Len( sPrefix) == 0 )
                     {
                        bDynCreated_Wcchildren = true;
                     }
                     if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_MultipleDataGrid_WC")) != 0 )
                     {
                        WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_multipledatagrid_wc", new Object[] {context} );
                        WebComp_Wcchildren.ComponentInit();
                        WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DFC_MultipleDataGrid_WC";
                        WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DFC_MultipleDataGrid_WC";
                     }
                     if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                     {
                        WebComp_Wcchildren.setjustcreated();
                        WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV22WWPDynamicFormMode,AV24WWPFormElement.gxTpr_Wwpformelementid,(short)AV15SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV23WWPForm});
                        WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
                     }
                  }
               }
               else if ( AV24WWPFormElement.gxTpr_Wwpformelementtype == 4 )
               {
                  /* Object Property */
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     bDynCreated_Wcchildren = true;
                  }
                  if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_Label_WC")) != 0 )
                  {
                     WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_label_wc", new Object[] {context} );
                     WebComp_Wcchildren.ComponentInit();
                     WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DFC_Label_WC";
                     WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DFC_Label_WC";
                  }
                  if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                  {
                     WebComp_Wcchildren.setjustcreated();
                     WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV22WWPDynamicFormMode,AV24WWPFormElement.gxTpr_Wwpformelementid,(short)AV15SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV23WWPForm});
                     WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
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
               AV13LoadedElements = (short)(AV13LoadedElements+1);
               if ( ( AV6Columns > 1 ) && ( AV13LoadedElements == AV6Columns ) )
               {
                  /* Object Property */
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     bDynCreated_Wcchildren = true;
                  }
                  if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_EmptyWC")) != 0 )
                  {
                     WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_emptywc", new Object[] {context} );
                     WebComp_Wcchildren.ComponentInit();
                     WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_EmptyWC";
                     WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_EmptyWC";
                  }
                  if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                  {
                     WebComp_Wcchildren.setjustcreated();
                     WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx});
                     WebComp_Wcchildren.componentbind(new Object[] {});
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
                  AV13LoadedElements = 0;
               }
            }
            AV28GXV1 = (int)(AV28GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E169T2( )
      {
         /* 'DoRefreshGrid' Routine */
         returnInSub = false;
         GXt_SdtWWP_Form3 = AV23WWPForm;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadformdefinition(context ).execute(  AV15SessionId, out  GXt_SdtWWP_Form3) ;
         AV23WWPForm = GXt_SdtWWP_Form3;
         gxgrFsgrid_refresh( AV10IsFirstElement, AV11IsLastElement, AV5AllowDeletion, AV23WWPForm, AV25WWPFormElementId, AV22WWPDynamicFormMode, AV15SessionId, AV6Columns, AV12IsStep, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23WWPForm", AV23WWPForm);
      }

      protected void E179T2( )
      {
         /* 'DoMoveUp' Routine */
         returnInSub = false;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_dfc_moveelement(context ).execute(  AV15SessionId,  AV25WWPFormElementId,  true) ;
         this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "DynamicForms_RefreshParentGrid", new Object[] {(string)divLayoutmaintable_Internalname,(string)"LayoutMainTable"}, false);
      }

      protected void E189T2( )
      {
         /* 'DoMoveDown' Routine */
         returnInSub = false;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_dfc_moveelement(context ).execute(  AV15SessionId,  AV25WWPFormElementId,  false) ;
         this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "DynamicForms_RefreshParentGrid", new Object[] {(string)divLayoutmaintable_Internalname,(string)"LayoutMainTable"}, false);
      }

      protected void E119T2( )
      {
         /* Dvelop_confirmpanel_btndeleteelement_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_btndeleteelement_Result, "Yes") == 0 )
         {
            GXt_SdtWWP_Form3 = AV23WWPForm;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadformdefinition(context ).execute(  AV15SessionId, out  GXt_SdtWWP_Form3) ;
            AV23WWPForm = GXt_SdtWWP_Form3;
            GXt_SdtWWP_Form_Element1 = AV7CurrentElement;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getelementbyid(context ).execute( ref  AV23WWPForm,  AV25WWPFormElementId, out  GXt_SdtWWP_Form_Element1) ;
            AV7CurrentElement = GXt_SdtWWP_Form_Element1;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_dfc_deleteelement(context ).execute( ref  AV23WWPForm, ref  AV7CurrentElement) ;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_saveformdefinition(context ).execute(  AV15SessionId,  AV23WWPForm) ;
            this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "DynamicForms_RefreshParentGrid", new Object[] {(string)divLayoutmaintable_Internalname,(string)"LayoutMainTable"}, false);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23WWPForm", AV23WWPForm);
      }

      protected void E139T2( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)sPrefix+"W0053",(string)"",(string)"UPD",(short)0,(short)AV25WWPFormElementId,(short)AV15SessionId});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0053"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E159T2( )
      {
         /* Addelement_modal_Onloadcomponent Routine */
         returnInSub = false;
         Addelement_modal_Title = context.GetMessage( "WWP_DF_AddElement", "");
         ucAddelement_modal.SendProperty(context, sPrefix, false, Addelement_modal_Internalname, "Title", Addelement_modal_Title);
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)sPrefix+"W0053",(string)"",(string)"INS",(short)AV25WWPFormElementId,(short)0,(short)AV15SessionId});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0053"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ! AV10IsFirstElement ) )
         {
            Btnmoveup_Visible = false;
            ucBtnmoveup.SendProperty(context, sPrefix, false, Btnmoveup_Internalname, "Visible", StringUtil.BoolToStr( Btnmoveup_Visible));
         }
         if ( ! ( ! AV11IsLastElement ) )
         {
            Btnmovedown_Visible = false;
            ucBtnmovedown.SendProperty(context, sPrefix, false, Btnmovedown_Internalname, "Visible", StringUtil.BoolToStr( Btnmovedown_Visible));
         }
         if ( ! ( AV5AllowDeletion ) )
         {
            Btndeleteelement_Visible = false;
            ucBtndeleteelement.SendProperty(context, sPrefix, false, Btndeleteelement_Internalname, "Visible", StringUtil.BoolToStr( Btndeleteelement_Visible));
         }
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         tblUnnamedtable1_Visible = (((StringUtil.StrCmp(AV22WWPDynamicFormMode, "DSP")!=0)) ? 1 : 0);
         AssignProp(sPrefix, false, tblUnnamedtable1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblUnnamedtable1_Visible), 5, 0), true);
      }

      protected void E129T2( )
      {
         /* Settings_modal_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Settings_modal_Result, "OK") == 0 )
         {
            if ( AV12IsStep )
            {
               GXt_SdtWWP_Form3 = AV23WWPForm;
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadformdefinition(context ).execute(  AV15SessionId, out  GXt_SdtWWP_Form3) ;
               AV23WWPForm = GXt_SdtWWP_Form3;
               AV8CurrentStepIndex = 0;
               AV29GXV2 = 1;
               while ( AV29GXV2 <= AV23WWPForm.gxTpr_Element.Count )
               {
                  AV9Element = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV23WWPForm.gxTpr_Element.Item(AV29GXV2));
                  if ( AV9Element.gxTpr_Wwpformelementtype == 5 )
                  {
                     AV8CurrentStepIndex = (short)(AV8CurrentStepIndex+1);
                     if ( AV9Element.gxTpr_Wwpformelementid == AV25WWPFormElementId )
                     {
                        if (true) break;
                     }
                  }
                  AV29GXV2 = (int)(AV29GXV2+1);
               }
               AV16WebSession.Set("WWPDynFormCreation_DefaultStep", StringUtil.Trim( StringUtil.Str( (decimal)(AV8CurrentStepIndex), 4, 0)));
            }
            if ( ! AV12IsStep && (0==AV25WWPFormElementId) )
            {
               GXt_SdtWWP_Form3 = AV23WWPForm;
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadformdefinition(context ).execute(  AV15SessionId, out  GXt_SdtWWP_Form3) ;
               AV23WWPForm = GXt_SdtWWP_Form3;
               Form.Caption = AV23WWPForm.gxTpr_Wwpformtitle;
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else
            {
               this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "DynamicForms_RefreshParentGrid", new Object[] {(string)divLayoutmaintable_Internalname,(string)"LayoutMainTable"}, false);
            }
         }
         else if ( (0==AV25WWPFormElementId) && ( StringUtil.StrCmp(Settings_modal_Result, "OK_AND_REFRESH") == 0 ) )
         {
            this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "DynamicForms_RefreshParentGrid", new Object[] {(string)divLayoutmaintable_Internalname,(string)"LayoutMainTable"}, false);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23WWPForm", AV23WWPForm);
      }

      protected void E149T2( )
      {
         /* Addelement_modal_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Addelement_modal_Result, "OK") == 0 )
         {
            GXt_SdtWWP_Form3 = AV23WWPForm;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadformdefinition(context ).execute(  AV15SessionId, out  GXt_SdtWWP_Form3) ;
            AV23WWPForm = GXt_SdtWWP_Form3;
            gxgrFsgrid_refresh( AV10IsFirstElement, AV11IsLastElement, AV5AllowDeletion, AV23WWPForm, AV25WWPFormElementId, AV22WWPDynamicFormMode, AV15SessionId, AV6Columns, AV12IsStep, sPrefix) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23WWPForm", AV23WWPForm);
      }

      protected void wb_table4_47_9T2( bool wbgen )
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
            wb_table4_47_9T2e( true) ;
         }
         else
         {
            wb_table4_47_9T2e( false) ;
         }
      }

      protected void wb_table3_42_9T2( bool wbgen )
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
            wb_table3_42_9T2e( true) ;
         }
         else
         {
            wb_table3_42_9T2e( false) ;
         }
      }

      protected void wb_table2_37_9T2( bool wbgen )
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
            wb_table2_37_9T2e( true) ;
         }
         else
         {
            wb_table2_37_9T2e( false) ;
         }
      }

      protected void wb_table1_19_9T2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblUnnamedtable1_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblUnnamedtable1_Internalname, tblUnnamedtable1_Internalname, "", "TableDynAddElementActions", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            wb_table1_19_9T2e( true) ;
         }
         else
         {
            wb_table1_19_9T2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV22WWPDynamicFormMode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV22WWPDynamicFormMode", AV22WWPDynamicFormMode);
         AV25WWPFormElementId = Convert.ToInt16(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV25WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV25WWPFormElementId), 4, 0));
         AV15SessionId = Convert.ToInt16(getParm(obj,2));
         AssignAttri(sPrefix, false, "AV15SessionId", StringUtil.LTrimStr( (decimal)(AV15SessionId), 4, 0));
         AV23WWPForm = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)getParm(obj,3);
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
         PA9T2( ) ;
         WS9T2( ) ;
         WE9T2( ) ;
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
         sCtrlAV22WWPDynamicFormMode = (string)((string)getParm(obj,0));
         sCtrlAV25WWPFormElementId = (string)((string)getParm(obj,1));
         sCtrlAV15SessionId = (string)((string)getParm(obj,2));
         sCtrlAV23WWPForm = (string)((string)getParm(obj,3));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA9T2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "udfc_fs_wc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA9T2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV22WWPDynamicFormMode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV22WWPDynamicFormMode", AV22WWPDynamicFormMode);
            AV25WWPFormElementId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV25WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV25WWPFormElementId), 4, 0));
            AV15SessionId = Convert.ToInt16(getParm(obj,4));
            AssignAttri(sPrefix, false, "AV15SessionId", StringUtil.LTrimStr( (decimal)(AV15SessionId), 4, 0));
            AV23WWPForm = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)getParm(obj,5);
         }
         wcpOAV22WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV22WWPDynamicFormMode");
         wcpOAV25WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV25WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV15SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV15SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV22WWPDynamicFormMode, wcpOAV22WWPDynamicFormMode) != 0 ) || ( AV25WWPFormElementId != wcpOAV25WWPFormElementId ) || ( AV15SessionId != wcpOAV15SessionId ) ) )
         {
            setjustcreated();
         }
         wcpOAV22WWPDynamicFormMode = AV22WWPDynamicFormMode;
         wcpOAV25WWPFormElementId = AV25WWPFormElementId;
         wcpOAV15SessionId = AV15SessionId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV22WWPDynamicFormMode = cgiGet( sPrefix+"AV22WWPDynamicFormMode_CTRL");
         if ( StringUtil.Len( sCtrlAV22WWPDynamicFormMode) > 0 )
         {
            AV22WWPDynamicFormMode = cgiGet( sCtrlAV22WWPDynamicFormMode);
            AssignAttri(sPrefix, false, "AV22WWPDynamicFormMode", AV22WWPDynamicFormMode);
         }
         else
         {
            AV22WWPDynamicFormMode = cgiGet( sPrefix+"AV22WWPDynamicFormMode_PARM");
         }
         sCtrlAV25WWPFormElementId = cgiGet( sPrefix+"AV25WWPFormElementId_CTRL");
         if ( StringUtil.Len( sCtrlAV25WWPFormElementId) > 0 )
         {
            AV25WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV25WWPFormElementId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV25WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV25WWPFormElementId), 4, 0));
         }
         else
         {
            AV25WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV25WWPFormElementId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV15SessionId = cgiGet( sPrefix+"AV15SessionId_CTRL");
         if ( StringUtil.Len( sCtrlAV15SessionId) > 0 )
         {
            AV15SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV15SessionId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV15SessionId", StringUtil.LTrimStr( (decimal)(AV15SessionId), 4, 0));
         }
         else
         {
            AV15SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV15SessionId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV23WWPForm = cgiGet( sPrefix+"AV23WWPForm_CTRL");
         if ( StringUtil.Len( sCtrlAV23WWPForm) > 0 )
         {
            AV23WWPForm.FromXml(cgiGet( sCtrlAV23WWPForm), null, "", "");
         }
         else
         {
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"AV23WWPForm_PARM"), AV23WWPForm);
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
         PA9T2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS9T2( ) ;
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
         WS9T2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV22WWPDynamicFormMode_PARM", StringUtil.RTrim( AV22WWPDynamicFormMode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV22WWPDynamicFormMode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV22WWPDynamicFormMode_CTRL", StringUtil.RTrim( sCtrlAV22WWPDynamicFormMode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV25WWPFormElementId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV25WWPFormElementId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV25WWPFormElementId_CTRL", StringUtil.RTrim( sCtrlAV25WWPFormElementId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV15SessionId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV15SessionId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV15SessionId_CTRL", StringUtil.RTrim( sCtrlAV15SessionId));
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"AV23WWPForm_PARM", AV23WWPForm);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"AV23WWPForm_PARM", AV23WWPForm);
         }
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV23WWPForm)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV23WWPForm_CTRL", StringUtil.RTrim( sCtrlAV23WWPForm));
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
         WE9T2( ) ;
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
         if ( ! ( WebComp_Wcchildren == null ) )
         {
            WebComp_Wcchildren.componentjscripts();
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
         if ( ! ( WebComp_Wcchildren == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
            {
               WebComp_Wcchildren.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025630934732", true, true);
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
         context.AddJavascriptSource("udfc_fs_wc.js", "?2025630934733", false, true);
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
      }

      protected void SubsflControlProps_fel_92( )
      {
      }

      protected void sendrow_92( )
      {
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
         WB9T0( ) ;
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
         /* Start of Columns property logic. */
         if ( FsgridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subFsgrid_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_9_idx+"\">") ;
         }
         /* Div Control */
         FsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divFsgridlayouttable_Internalname+"_"+sGXsfl_9_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* WebComponent */
         GxWebStd.gx_hidden_field( context, sPrefix+"W0013"+sGXsfl_9_idx, StringUtil.RTrim( WebComp_Wcchildren_Component));
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gxwebcomponent"+" gxwebcomponent-loading");
         context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0013"+sGXsfl_9_idx+"\""+"") ;
         context.WriteHtmlText( ">") ;
         if ( bGXsfl_9_Refreshing )
         {
            if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
            {
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StringSearch( sPrefix+"W0013"+sGXsfl_9_idx, cgiGet( "_EventName"), 1) != 0 ) )
               {
                  if ( 1 != 0 )
                  {
                     if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                     {
                        WebComp_Wcchildren.componentstart();
                     }
                  }
               }
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldWcchildren), StringUtil.Lower( WebComp_Wcchildren_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0013"+sGXsfl_9_idx);
               }
               WebComp_Wcchildren.componentdraw();
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldWcchildren), StringUtil.Lower( WebComp_Wcchildren_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
         }
         context.WriteHtmlText( "</div>") ;
         WebComp_Wcchildren_Component = "";
         WebComp_Wcchildren.componentjscripts();
         FsgridRow.AddColumnProperties("webcomp", -1, isAjaxCallMode( ), new Object[] {(string)"Wcchildren"});
         FsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         send_integrity_lvl_hashes9T2( ) ;
         /* End of Columns property logic. */
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
            GxWebStd.gx_table_start( context, subFsgrid_Internalname, subFsgrid_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            FsgridContainer.AddObjectProperty("GridName", "Fsgrid");
         }
         else
         {
            FsgridContainer.AddObjectProperty("GridName", "Fsgrid");
            FsgridContainer.AddObjectProperty("Header", subFsgrid_Header);
            FsgridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            FsgridContainer.AddObjectProperty("Class", "FreeStyleGrid");
            FsgridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            FsgridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
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
         divFsgridlayouttable_Internalname = sPrefix+"FSGRIDLAYOUTTABLE";
         divFsgridcell_Internalname = sPrefix+"FSGRIDCELL";
         Btnmoveup_Internalname = sPrefix+"BTNMOVEUP";
         Btnmovedown_Internalname = sPrefix+"BTNMOVEDOWN";
         Btndeleteelement_Internalname = sPrefix+"BTNDELETEELEMENT";
         Btnsettings_Internalname = sPrefix+"BTNSETTINGS";
         Btnaddelement_Internalname = sPrefix+"BTNADDELEMENT";
         tblUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
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
         subFsgrid_Class = "FreeStyleGrid";
         Btnaddelement_Class = "ButtonGray";
         Btnaddelement_Caption = context.GetMessage( "WWP_DF_AddElement", "");
         Btnaddelement_Beforeiconclass = "fas fa-circle-plus";
         Btnaddelement_Tooltiptext = "";
         Btnsettings_Class = "ButtonGray";
         Btnsettings_Beforeiconclass = "fas fa-gear";
         Btndeleteelement_Class = "ButtonGray";
         Btndeleteelement_Beforeiconclass = "fa-trash-can far";
         Btnmovedown_Class = "ButtonGray";
         Btnmoveup_Class = "ButtonGray";
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
         tblUnnamedtable1_Visible = 1;
         Btndeleteelement_Visible = Convert.ToBoolean( -1);
         Btnmovedown_Visible = Convert.ToBoolean( -1);
         Btnmoveup_Visible = Convert.ToBoolean( -1);
         Addelement_modal_Title = context.GetMessage( "Add Element", "");
         Btndeleteelement_Tooltiptext = "";
         Btnsettings_Tooltiptext = "";
         Btnmovedown_Tooltiptext = "";
         Btnmoveup_Tooltiptext = "";
         Btnmovedown_Beforeiconclass = "fas fa-arrow-down";
         Btnmoveup_Beforeiconclass = "fas fa-arrow-up";
         Btndeleteelement_Caption = context.GetMessage( "GX_BtnDelete", "");
         Btnmovedown_Caption = context.GetMessage( "WWP_DF_MoveDown", "");
         Btnmoveup_Caption = context.GetMessage( "WWP_DF_MoveUp", "");
         Dvelop_confirmpanel_btndeleteelement_Confirmationtext = "Are you sure you want to delete this element?";
         Btnsettings_Caption = context.GetMessage( "WWP_DF_Settings", "");
         subFsgrid_Backcolorstyle = 0;
         divTableactions_Class = "TableDynFormAddElement";
         divFsgridcell_Class = "col-xs-12";
         divTablemain_Class = "Table";
         divLayoutmaintable_Class = "Table";
         Form.Caption = context.GetMessage( "WWP_Dynamic Form Creation_FS_WC", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"FSGRID_nFirstRecordOnPage"},{"av":"FSGRID_nEOF"},{"av":"AV23WWPForm","fld":"vWWPFORM"},{"av":"AV25WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV22WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV15SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"sPrefix"},{"av":"AV10IsFirstElement","fld":"vISFIRSTELEMENT","hsh":true},{"av":"AV11IsLastElement","fld":"vISLASTELEMENT","hsh":true},{"av":"AV5AllowDeletion","fld":"vALLOWDELETION","hsh":true},{"av":"AV6Columns","fld":"vCOLUMNS","pic":"ZZZ9","hsh":true},{"av":"AV12IsStep","fld":"vISSTEP","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"Btnmoveup_Visible","ctrl":"BTNMOVEUP","prop":"Visible"},{"av":"Btnmovedown_Visible","ctrl":"BTNMOVEDOWN","prop":"Visible"},{"av":"Btndeleteelement_Visible","ctrl":"BTNDELETEELEMENT","prop":"Visible"}]}""");
         setEventMetadata("FSGRID.LOAD","""{"handler":"E219T2","iparms":[{"av":"AV23WWPForm","fld":"vWWPFORM"},{"av":"AV25WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV22WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV15SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV6Columns","fld":"vCOLUMNS","pic":"ZZZ9","hsh":true}]""");
         setEventMetadata("FSGRID.LOAD",""","oparms":[{"ctrl":"WCCHILDREN"}]}""");
         setEventMetadata("'DOREFRESHGRID'","""{"handler":"E169T2","iparms":[{"av":"FSGRID_nFirstRecordOnPage"},{"av":"FSGRID_nEOF"},{"av":"AV10IsFirstElement","fld":"vISFIRSTELEMENT","hsh":true},{"av":"AV11IsLastElement","fld":"vISLASTELEMENT","hsh":true},{"av":"AV5AllowDeletion","fld":"vALLOWDELETION","hsh":true},{"av":"AV23WWPForm","fld":"vWWPFORM"},{"av":"AV25WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV22WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV15SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV6Columns","fld":"vCOLUMNS","pic":"ZZZ9","hsh":true},{"av":"AV12IsStep","fld":"vISSTEP","hsh":true},{"av":"sPrefix"}]""");
         setEventMetadata("'DOREFRESHGRID'",""","oparms":[{"av":"AV23WWPForm","fld":"vWWPFORM"},{"av":"Btnmoveup_Visible","ctrl":"BTNMOVEUP","prop":"Visible"},{"av":"Btnmovedown_Visible","ctrl":"BTNMOVEDOWN","prop":"Visible"},{"av":"Btndeleteelement_Visible","ctrl":"BTNDELETEELEMENT","prop":"Visible"}]}""");
         setEventMetadata("'DOMOVEUP'","""{"handler":"E179T2","iparms":[{"av":"AV15SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV25WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"}]}""");
         setEventMetadata("'DOMOVEDOWN'","""{"handler":"E189T2","iparms":[{"av":"AV15SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV25WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_BTNDELETEELEMENT.CLOSE","""{"handler":"E119T2","iparms":[{"av":"Dvelop_confirmpanel_btndeleteelement_Result","ctrl":"DVELOP_CONFIRMPANEL_BTNDELETEELEMENT","prop":"Result"},{"av":"AV15SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV25WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_BTNDELETEELEMENT.CLOSE",""","oparms":[{"av":"AV23WWPForm","fld":"vWWPFORM"}]}""");
         setEventMetadata("SETTINGS_MODAL.ONLOADCOMPONENT","""{"handler":"E139T2","iparms":[{"av":"AV25WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV15SessionId","fld":"vSESSIONID","pic":"ZZZ9"}]""");
         setEventMetadata("SETTINGS_MODAL.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("ADDELEMENT_MODAL.ONLOADCOMPONENT","""{"handler":"E159T2","iparms":[{"av":"AV25WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV15SessionId","fld":"vSESSIONID","pic":"ZZZ9"}]""");
         setEventMetadata("ADDELEMENT_MODAL.ONLOADCOMPONENT",""","oparms":[{"av":"Addelement_modal_Title","ctrl":"ADDELEMENT_MODAL","prop":"Title"},{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("SETTINGS_MODAL.CLOSE","""{"handler":"E129T2","iparms":[{"av":"Settings_modal_Result","ctrl":"SETTINGS_MODAL","prop":"Result"},{"av":"AV12IsStep","fld":"vISSTEP","hsh":true},{"av":"AV15SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV25WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"}]""");
         setEventMetadata("SETTINGS_MODAL.CLOSE",""","oparms":[{"av":"AV23WWPForm","fld":"vWWPFORM"},{"ctrl":"FORM","prop":"Caption"}]}""");
         setEventMetadata("ADDELEMENT_MODAL.CLOSE","""{"handler":"E149T2","iparms":[{"av":"FSGRID_nFirstRecordOnPage"},{"av":"FSGRID_nEOF"},{"av":"AV10IsFirstElement","fld":"vISFIRSTELEMENT","hsh":true},{"av":"AV11IsLastElement","fld":"vISLASTELEMENT","hsh":true},{"av":"AV5AllowDeletion","fld":"vALLOWDELETION","hsh":true},{"av":"AV23WWPForm","fld":"vWWPFORM"},{"av":"AV25WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV22WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV15SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV6Columns","fld":"vCOLUMNS","pic":"ZZZ9","hsh":true},{"av":"AV12IsStep","fld":"vISSTEP","hsh":true},{"av":"sPrefix"},{"av":"Addelement_modal_Result","ctrl":"ADDELEMENT_MODAL","prop":"Result"}]""");
         setEventMetadata("ADDELEMENT_MODAL.CLOSE",""","oparms":[{"av":"AV23WWPForm","fld":"vWWPFORM"},{"av":"Btnmoveup_Visible","ctrl":"BTNMOVEUP","prop":"Visible"},{"av":"Btnmovedown_Visible","ctrl":"BTNMOVEDOWN","prop":"Visible"},{"av":"Btndeleteelement_Visible","ctrl":"BTNDELETEELEMENT","prop":"Visible"}]}""");
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
         AV23WWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         wcpOAV22WWPDynamicFormMode = "";
         Dvelop_confirmpanel_btndeleteelement_Result = "";
         Settings_modal_Result = "";
         Addelement_modal_Result = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
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
         bttBtnrefreshgrid_Jsonclick = "";
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         OldWcchildren = "";
         sCmpCtrl = "";
         WebComp_GX_Process_Component = "";
         GXDecQS = "";
         WebComp_Wcchildren_Component = "";
         ucBtnsettings = new GXUserControl();
         AV7CurrentElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         AV19WWP_DF_GroupMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ContainerMetadata(context);
         ucDvelop_confirmpanel_btndeleteelement = new GXUserControl();
         ucBtnmoveup = new GXUserControl();
         ucBtnmovedown = new GXUserControl();
         ucBtndeleteelement = new GXUserControl();
         AV21WWP_DF_StepMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_StepMetadata(context);
         AV20WWP_DF_ElementsRepeaterMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ElementsRepeaterMetadata(context);
         AV24WWPFormElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         AV17WWP_DF_BooleanMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_BooleanMetadata(context);
         AV18WWP_DF_CharMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata(context);
         FsgridRow = new GXWebRow();
         GXt_SdtWWP_Form_Element1 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         ucAddelement_modal = new GXUserControl();
         AV9Element = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         AV16WebSession = context.GetSession();
         GXt_SdtWWP_Form3 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         ucSettings_modal = new GXUserControl();
         ucBtnaddelement = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV22WWPDynamicFormMode = "";
         sCtrlAV25WWPFormElementId = "";
         sCtrlAV15SessionId = "";
         sCtrlAV23WWPForm = "";
         subFsgrid_Linesclass = "";
         subFsgrid_Header = "";
         FsgridColumn = new GXWebColumn();
         WebComp_GX_Process = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcchildren = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short AV25WWPFormElementId ;
      private short AV15SessionId ;
      private short wcpOAV25WWPFormElementId ;
      private short wcpOAV15SessionId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV6Columns ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short subFsgrid_Backcolorstyle ;
      private short AV14ParentIsGridMultipleData ;
      private short FSGRID_nEOF ;
      private short AV13LoadedElements ;
      private short AV8CurrentStepIndex ;
      private short nGXWrapped ;
      private short subFsgrid_Backstyle ;
      private short subFsgrid_Allowselection ;
      private short subFsgrid_Allowhovering ;
      private short subFsgrid_Allowcollapsing ;
      private short subFsgrid_Collapsed ;
      private int nRC_GXsfl_9 ;
      private int subFsgrid_Recordcount ;
      private int nGXsfl_9_idx=1 ;
      private int nGXsfl_9_webc_idx=0 ;
      private int subFsgrid_Islastpage ;
      private int AV28GXV1 ;
      private int tblUnnamedtable1_Visible ;
      private int AV29GXV2 ;
      private int idxLst ;
      private int subFsgrid_Backcolor ;
      private int subFsgrid_Allbackcolor ;
      private int subFsgrid_Selectedindex ;
      private int subFsgrid_Selectioncolor ;
      private int subFsgrid_Hoveringcolor ;
      private long FSGRID_nCurrentRecord ;
      private long FSGRID_nFirstRecordOnPage ;
      private string AV22WWPDynamicFormMode ;
      private string wcpOAV22WWPDynamicFormMode ;
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
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string divTablemain_Class ;
      private string divFsgridcell_Internalname ;
      private string divFsgridcell_Class ;
      private string sStyleString ;
      private string subFsgrid_Internalname ;
      private string divTableactions_Internalname ;
      private string divTableactions_Class ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
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
      private string OldWcchildren ;
      private string sCmpCtrl ;
      private string WebComp_GX_Process_Component ;
      private string WebCompHandler="" ;
      private string GXDecQS ;
      private string WebComp_Wcchildren_Component ;
      private string Btnsettings_Caption ;
      private string Btnsettings_Internalname ;
      private string Dvelop_confirmpanel_btndeleteelement_Confirmationtext ;
      private string Dvelop_confirmpanel_btndeleteelement_Internalname ;
      private string Btnmoveup_Caption ;
      private string Btnmoveup_Internalname ;
      private string Btnmovedown_Caption ;
      private string Btnmovedown_Internalname ;
      private string Btndeleteelement_Caption ;
      private string Btndeleteelement_Internalname ;
      private string Btnmoveup_Beforeiconclass ;
      private string Btnmovedown_Beforeiconclass ;
      private string Btnmoveup_Tooltiptext ;
      private string Btnmovedown_Tooltiptext ;
      private string Btnsettings_Tooltiptext ;
      private string Btndeleteelement_Tooltiptext ;
      private string Addelement_modal_Title ;
      private string Addelement_modal_Internalname ;
      private string tblUnnamedtable1_Internalname ;
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
      private string Btnmoveup_Class ;
      private string Btnmovedown_Class ;
      private string Btndeleteelement_Beforeiconclass ;
      private string Btndeleteelement_Class ;
      private string Btnsettings_Beforeiconclass ;
      private string Btnsettings_Class ;
      private string Btnaddelement_Tooltiptext ;
      private string Btnaddelement_Beforeiconclass ;
      private string Btnaddelement_Caption ;
      private string Btnaddelement_Class ;
      private string Btnaddelement_Internalname ;
      private string sCtrlAV22WWPDynamicFormMode ;
      private string sCtrlAV25WWPFormElementId ;
      private string sCtrlAV15SessionId ;
      private string sCtrlAV23WWPForm ;
      private string subFsgrid_Class ;
      private string subFsgrid_Linesclass ;
      private string divFsgridlayouttable_Internalname ;
      private string subFsgrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10IsFirstElement ;
      private bool AV11IsLastElement ;
      private bool AV5AllowDeletion ;
      private bool AV12IsStep ;
      private bool wbLoad ;
      private bool bGXsfl_9_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool GXt_boolean2 ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wcchildren ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool Btnmoveup_Visible ;
      private bool Btnmovedown_Visible ;
      private bool Btndeleteelement_Visible ;
      private GXWebComponent WebComp_Wcchildren ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid FsgridContainer ;
      private GXWebRow FsgridRow ;
      private GXWebColumn FsgridColumn ;
      private GXUserControl ucBtnsettings ;
      private GXUserControl ucDvelop_confirmpanel_btndeleteelement ;
      private GXUserControl ucBtnmoveup ;
      private GXUserControl ucBtnmovedown ;
      private GXUserControl ucBtndeleteelement ;
      private GXUserControl ucAddelement_modal ;
      private GXUserControl ucSettings_modal ;
      private GXUserControl ucBtnaddelement ;
      private GXWebForm Form ;
      private IGxSession AV16WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV23WWPForm ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP3_WWPForm ;
      private GXWebComponent WebComp_GX_Process ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV7CurrentElement ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ContainerMetadata AV19WWP_DF_GroupMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_StepMetadata AV21WWP_DF_StepMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ElementsRepeaterMetadata AV20WWP_DF_ElementsRepeaterMetadata ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV24WWPFormElement ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_BooleanMetadata AV17WWP_DF_BooleanMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata AV18WWP_DF_CharMetadata ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element GXt_SdtWWP_Form_Element1 ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV9Element ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form GXt_SdtWWP_Form3 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
