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
   public class wwp_df_htmleditor_wc : GXWebComponent
   {
      public wwp_df_htmleditor_wc( )
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

      public wwp_df_htmleditor_wc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPDynamicFormMode ,
                           short aP1_WWPFormElementId ,
                           short aP2_WWPFormInstanceElementId ,
                           short aP3_SessionId ,
                           ref GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP4_WWPFormInstance )
      {
         this.AV25WWPDynamicFormMode = aP0_WWPDynamicFormMode;
         this.AV26WWPFormElementId = aP1_WWPFormElementId;
         this.AV31WWPFormInstanceElementId = aP2_WWPFormInstanceElementId;
         this.AV19SessionId = aP3_SessionId;
         this.AV29WWPFormInstance = aP4_WWPFormInstance;
         ExecuteImpl();
         aP4_WWPFormInstance=this.AV29WWPFormInstance;
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
                  AV25WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
                  AssignAttri(sPrefix, false, "AV25WWPDynamicFormMode", AV25WWPDynamicFormMode);
                  AV26WWPFormElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV26WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV26WWPFormElementId), 4, 0));
                  AV31WWPFormInstanceElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormInstanceElementId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV31WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV31WWPFormInstanceElementId), 4, 0));
                  AV19SessionId = (short)(Math.Round(NumberUtil.Val( GetPar( "SessionId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV19SessionId", StringUtil.LTrimStr( (decimal)(AV19SessionId), 4, 0));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV29WWPFormInstance);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV25WWPDynamicFormMode,(short)AV26WWPFormElementId,(short)AV31WWPFormInstanceElementId,(short)AV19SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV29WWPFormInstance});
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
            PA2G2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS2G2( ) ;
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
            context.SendWebValue( context.GetMessage( "WWP_Dynamic Form_HTMLEditor_WC", "")) ;
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
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
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
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_df_htmleditor_wc.aspx"+UrlEncode(StringUtil.RTrim(AV25WWPDynamicFormMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV26WWPFormElementId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV31WWPFormInstanceElementId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV19SessionId,4,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.dynamicforms.wwp_df_htmleditor_wc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_CHARMETADATA", AV24WWP_DF_CharMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_CHARMETADATA", AV24WWP_DF_CharMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_CHARMETADATA", GetSecureSignedToken( sPrefix, AV24WWP_DF_CharMetadata, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTTITLE", AV28WWPFormElementTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTTITLE", GetSecureSignedToken( sPrefix, AV28WWPFormElementTitle, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vELEMENTINTERNALNAME", AV11ElementInternalName);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vELEMENTINTERNALNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV11ElementInternalName, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASREFERENCEID", AV13HasReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV13HasReferenceId, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"vDATA", AV8Data);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV25WWPDynamicFormMode", StringUtil.RTrim( wcpOAV25WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV26WWPFormElementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV26WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV31WWPFormInstanceElementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV31WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV19SessionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV19SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vERRORIDS", AV34ErrorIds);
         GxWebStd.gx_hidden_field( context, sPrefix+"vAUXSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6AuxSessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMINSTANCEELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vEXISTELEMENT", AV12ExistElement);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORMINSTANCE", AV29WWPFormInstance);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORMINSTANCE", AV29WWPFormInstance);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_CHARMETADATA", AV24WWP_DF_CharMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_CHARMETADATA", AV24WWP_DF_CharMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_CHARMETADATA", GetSecureSignedToken( sPrefix, AV24WWP_DF_CharMetadata, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTTITLE", AV28WWPFormElementTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTTITLE", GetSecureSignedToken( sPrefix, AV28WWPFormElementTitle, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vELEMENTINTERNALNAME", AV11ElementInternalName);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vELEMENTINTERNALNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV11ElementInternalName, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORMINSTANCEELEMENT", AV30WWPFormInstanceElement);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORMINSTANCEELEMENT", AV30WWPFormInstanceElement);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vVISIBLECONDITION", AV22VisibleCondition);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vVISIBLECONDITION", AV22VisibleCondition);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASREFERENCEID", AV13HasReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV13HasReferenceId, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV25WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"DATA_Enabled", StringUtil.BoolToStr( Data_Enabled));
         GxWebStd.gx_hidden_field( context, sPrefix+"DATA_Width", StringUtil.RTrim( Data_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DATA_Height", StringUtil.RTrim( Data_Height));
         GxWebStd.gx_hidden_field( context, sPrefix+"DATA_Skin", StringUtil.RTrim( Data_Skin));
         GxWebStd.gx_hidden_field( context, sPrefix+"DATA_Toolbar", StringUtil.RTrim( Data_Toolbar));
         GxWebStd.gx_hidden_field( context, sPrefix+"DATA_Customtoolbar", StringUtil.RTrim( Data_Customtoolbar));
         GxWebStd.gx_hidden_field( context, sPrefix+"DATA_Customconfiguration", StringUtil.RTrim( Data_Customconfiguration));
         GxWebStd.gx_hidden_field( context, sPrefix+"DATA_Captionclass", StringUtil.RTrim( Data_Captionclass));
         GxWebStd.gx_hidden_field( context, sPrefix+"DATA_Captionstyle", StringUtil.RTrim( Data_Captionstyle));
         GxWebStd.gx_hidden_field( context, sPrefix+"DATA_Captionposition", StringUtil.RTrim( Data_Captionposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DATA_Visible", StringUtil.BoolToStr( Data_Visible));
         GxWebStd.gx_hidden_field( context, sPrefix+"LAYOUTMAINTABLE_Class", StringUtil.RTrim( divLayoutmaintable_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"LAYOUTMAINTABLE_Class", StringUtil.RTrim( divLayoutmaintable_Class));
      }

      protected void RenderHtmlCloseForm2G2( )
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
         return "WorkWithPlus.DynamicForms.WWP_DF_HTMLEditor_WC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WWP_Dynamic Form_HTMLEditor_WC", "") ;
      }

      protected void WB2G0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "workwithplus.dynamicforms.wwp_df_htmleditor_wc.aspx");
               context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
               context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDatatitlecell_Internalname, divDatatitlecell_Visible, 0, "px", 0, "px", divDatatitlecell_Class, "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDatatitle_Internalname, lblDatatitle_Caption, "", "", lblDatatitle_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DF_HTMLEditor_WC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDatacellname_Internalname, 1, 0, "px", 0, "px", divDatacellname_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+Data_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, Data_Internalname, context.GetMessage( "Data", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* User Defined Control */
            ucData.SetProperty("Width", Data_Width);
            ucData.SetProperty("Height", Data_Height);
            ucData.SetProperty("Attribute", AV8Data);
            ucData.SetProperty("Skin", Data_Skin);
            ucData.SetProperty("Toolbar", Data_Toolbar);
            ucData.SetProperty("CustomToolbar", Data_Customtoolbar);
            ucData.SetProperty("CustomConfiguration", Data_Customconfiguration);
            ucData.SetProperty("CaptionClass", Data_Captionclass);
            ucData.SetProperty("CaptionStyle", Data_Captionstyle);
            ucData.SetProperty("CaptionPosition", Data_Captionposition);
            ucData.Render(context, "fckeditor", Data_Internalname, sPrefix+"DATAContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDatareadonlycell_Internalname, 1, 0, "px", 0, "px", divDatareadonlycell_Class, "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDatareadonly_Internalname, lblDatareadonly_Caption, "", "", lblDatareadonly_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DynamicFormHTMLEditor", 0, "", 1, 1, 0, 1, "HLP_WorkWithPlus/DynamicForms/WWP_DF_HTMLEditor_WC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START2G2( )
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
            Form.Meta.addItem("description", context.GetMessage( "WWP_Dynamic Form_HTMLEditor_WC", ""), 0) ;
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
               STRUP2G0( ) ;
            }
         }
      }

      protected void WS2G2( )
      {
         START2G2( ) ;
         EVT2G2( ) ;
      }

      protected void EVT2G2( )
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
                                 STRUP2G0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "VDATA.KEYUP") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E112G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E122G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.DYNAMICFORM_VALIDATE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E132G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E142G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E152G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2G0( ) ;
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
                                 STRUP2G0( ) ;
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE2G2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2G2( ) ;
            }
         }
      }

      protected void PA2G2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.dynamicforms.wwp_df_htmleditor_wc.aspx")), "workwithplus.dynamicforms.wwp_df_htmleditor_wc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.dynamicforms.wwp_df_htmleditor_wc.aspx")))) ;
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
         RF2G2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF2G2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E152G2 ();
            WB2G0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2G2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_CHARMETADATA", AV24WWP_DF_CharMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_CHARMETADATA", AV24WWP_DF_CharMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_CHARMETADATA", GetSecureSignedToken( sPrefix, AV24WWP_DF_CharMetadata, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTTITLE", AV28WWPFormElementTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTTITLE", GetSecureSignedToken( sPrefix, AV28WWPFormElementTitle, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vELEMENTINTERNALNAME", AV11ElementInternalName);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vELEMENTINTERNALNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV11ElementInternalName, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASREFERENCEID", AV13HasReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV13HasReferenceId, context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2G0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E122G2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            AV8Data = cgiGet( sPrefix+"vDATA");
            wcpOAV25WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV25WWPDynamicFormMode");
            wcpOAV26WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV26WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV31WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV31WWPFormInstanceElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV19SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV19SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Data_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"DATA_Enabled"));
            Data_Width = cgiGet( sPrefix+"DATA_Width");
            Data_Height = cgiGet( sPrefix+"DATA_Height");
            Data_Skin = cgiGet( sPrefix+"DATA_Skin");
            Data_Toolbar = cgiGet( sPrefix+"DATA_Toolbar");
            Data_Customtoolbar = cgiGet( sPrefix+"DATA_Customtoolbar");
            Data_Customconfiguration = cgiGet( sPrefix+"DATA_Customconfiguration");
            Data_Captionclass = cgiGet( sPrefix+"DATA_Captionclass");
            Data_Captionstyle = cgiGet( sPrefix+"DATA_Captionstyle");
            Data_Captionposition = cgiGet( sPrefix+"DATA_Captionposition");
            Data_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"DATA_Visible"));
            divLayoutmaintable_Class = cgiGet( sPrefix+"LAYOUTMAINTABLE_Class");
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
         E122G2 ();
         if (returnInSub) return;
      }

      protected void E122G2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV35SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformid = AV29WWPFormInstance.gxTpr_Wwpformid;
         AV35SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformversionnumber = AV29WWPFormInstance.gxTpr_Wwpformversionnumber;
         AV35SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformelementid = AV26WWPFormElementId;
         new prc_getdynamicformtranslation(context ).execute( ref  AV35SDT_DynamicFormTranslation) ;
         AV14IsElementFocusable = true;
         AV13HasReferenceId = false;
         AssignAttri(sPrefix, false, "AV13HasReferenceId", AV13HasReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV13HasReferenceId, context));
         AV36GXV1 = 1;
         while ( AV36GXV1 <= AV29WWPFormInstance.gxTpr_Element.Count )
         {
            AV30WWPFormInstanceElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV29WWPFormInstance.gxTpr_Element.Item(AV36GXV1));
            if ( ( AV30WWPFormInstanceElement.gxTpr_Wwpformelementid == AV26WWPFormElementId ) && ( AV30WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid == AV31WWPFormInstanceElementId ) )
            {
               AV7CurrentWWPFormInstanceElement = AV30WWPFormInstanceElement;
               AV13HasReferenceId = (bool)((!String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV30WWPFormInstanceElement.gxTpr_Wwpformelementreferenceid)))));
               AssignAttri(sPrefix, false, "AV13HasReferenceId", AV13HasReferenceId);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV13HasReferenceId, context));
               AV28WWPFormElementTitle = AV30WWPFormInstanceElement.gxTpr_Wwpformelementtitle;
               AssignAttri(sPrefix, false, "AV28WWPFormElementTitle", AV28WWPFormElementTitle);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTTITLE", GetSecureSignedToken( sPrefix, AV28WWPFormElementTitle, context));
               AV27WWPFormElementMetadata = AV30WWPFormInstanceElement.gxTpr_Wwpformelementmetadata;
               AssignAttri(sPrefix, false, "AV27WWPFormElementMetadata", AV27WWPFormElementMetadata);
               AV5WWPFormElementCaption = AV30WWPFormInstanceElement.gxTpr_Wwpformelementcaption;
               if (true) break;
            }
            AV36GXV1 = (int)(AV36GXV1+1);
         }
         /* Execute user subroutine: 'LOAD TITLE AND METADATA' */
         S182 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GET DATA FROM CURRENT ELEMENT' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UPDATE VISIBILITY' */
         S122 ();
         if (returnInSub) return;
         if ( AV14IsElementFocusable && ( StringUtil.StrCmp(divLayoutmaintable_Class, "Table") == 0 ) && ( StringUtil.StrCmp(AV23WebSession.Get("WWPDynFormSetFocus"), "") != 0 ) )
         {
            /* Execute user subroutine: 'SET FOCUS TO ELEMENT' */
            S132 ();
            if (returnInSub) return;
            AV23WebSession.Remove("WWPDynFormSetFocus");
         }
         if ( ( StringUtil.StrCmp(AV25WWPDynamicFormMode, "DSP") != 0 ) && ( StringUtil.StrCmp(AV25WWPDynamicFormMode, "DLT") != 0 ) )
         {
            AV10DataEnabled = true;
         }
         if ( ( StringUtil.StrCmp(AV25WWPDynamicFormMode, "INS") == 0 ) || ( StringUtil.StrCmp(AV25WWPDynamicFormMode, "UPD") == 0 ) )
         {
            divDatareadonlycell_Class = "";
            AssignProp(sPrefix, false, divDatareadonlycell_Internalname, "Class", divDatareadonlycell_Class, true);
            Data_Visible = true;
            AssignProp(sPrefix, false, Data_Internalname, "Visible", StringUtil.BoolToStr( Data_Visible), true);
         }
         else
         {
            Data_Visible = false;
            AssignProp(sPrefix, false, Data_Internalname, "Visible", StringUtil.BoolToStr( Data_Visible), true);
            divDatareadonlycell_Class = "DynamicFormHTMLEditorCell";
            AssignProp(sPrefix, false, divDatareadonlycell_Internalname, "Class", divDatareadonlycell_Class, true);
            lblDatareadonly_Caption = AV8Data;
            AssignProp(sPrefix, false, lblDatareadonly_Internalname, "Caption", lblDatareadonly_Caption, true);
         }
      }

      protected void E132G2( )
      {
         /* General\GlobalEvents_Dynamicform_validate Routine */
         returnInSub = false;
         if ( ( AV6AuxSessionId == AV19SessionId ) && ( StringUtil.StrCmp(divLayoutmaintable_Class, "Invisible") != 0 ) && StringUtil.Contains( AV34ErrorIds, "|"+StringUtil.Trim( StringUtil.Str( (decimal)(AV26WWPFormElementId), 4, 0))+"."+StringUtil.Trim( StringUtil.Str( (decimal)(AV31WWPFormInstanceElementId), 4, 0))+"|") )
         {
            /* Execute user subroutine: 'SAVE ELEMENT DATA TO SESSION' */
            S142 ();
            if (returnInSub) return;
            if ( AV12ExistElement )
            {
               /* Execute user subroutine: 'EXECUTE VALIDATIONS' */
               S152 ();
               if (returnInSub) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV30WWPFormInstanceElement", AV30WWPFormInstanceElement);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV29WWPFormInstance", AV29WWPFormInstance);
      }

      protected void E142G2( )
      {
         /* General\GlobalEvents_Dynamicform_updatevisibilities Routine */
         returnInSub = false;
         if ( ( AV6AuxSessionId == AV19SessionId ) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV22VisibleCondition.gxTpr_Expression))) )
         {
            /* Execute user subroutine: 'GET FORM INSTANCE' */
            S162 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'UPDATE VISIBILITY' */
            S122 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV29WWPFormInstance", AV29WWPFormInstance);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV22VisibleCondition", AV22VisibleCondition);
      }

      protected void S162( )
      {
         /* 'GET FORM INSTANCE' Routine */
         returnInSub = false;
         GXt_SdtWWP_FormInstance1 = AV29WWPFormInstance;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadforminstance(context ).execute(  AV19SessionId, out  GXt_SdtWWP_FormInstance1) ;
         AV29WWPFormInstance = GXt_SdtWWP_FormInstance1;
      }

      protected void S112( )
      {
         /* 'GET DATA FROM CURRENT ELEMENT' Routine */
         returnInSub = false;
         AV8Data = AV7CurrentWWPFormInstanceElement.gxTpr_Wwpforminstanceelemchar;
         AssignAttri(sPrefix, false, "AV8Data", AV8Data);
      }

      protected void S142( )
      {
         /* 'SAVE ELEMENT DATA TO SESSION' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GET FORM INSTANCE' */
         S162 ();
         if (returnInSub) return;
         AV12ExistElement = false;
         AssignAttri(sPrefix, false, "AV12ExistElement", AV12ExistElement);
         AV37GXV2 = 1;
         while ( AV37GXV2 <= AV29WWPFormInstance.gxTpr_Element.Count )
         {
            AV30WWPFormInstanceElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV29WWPFormInstance.gxTpr_Element.Item(AV37GXV2));
            if ( ( AV30WWPFormInstanceElement.gxTpr_Wwpformelementid == AV26WWPFormElementId ) && ( AV30WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid == AV31WWPFormInstanceElementId ) )
            {
               AV12ExistElement = true;
               AssignAttri(sPrefix, false, "AV12ExistElement", AV12ExistElement);
               if (true) break;
            }
            AV37GXV2 = (int)(AV37GXV2+1);
         }
         if ( AV12ExistElement )
         {
            /* Execute user subroutine: 'SET DATA TO ELEMENT' */
            S172 ();
            if (returnInSub) return;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_saveforminstance(context ).execute(  AV19SessionId,  AV29WWPFormInstance) ;
         }
      }

      protected void S172( )
      {
         /* 'SET DATA TO ELEMENT' Routine */
         returnInSub = false;
         AV30WWPFormInstanceElement.gxTpr_Wwpforminstanceelemchar = AV8Data;
      }

      protected void S122( )
      {
         /* 'UPDATE VISIBILITY' Routine */
         returnInSub = false;
         AV22VisibleCondition = AV24WWP_DF_CharMetadata.gxTpr_Visiblecondition;
         if ( new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_evaluateelementvisibility(context).executeUdp(  AV29WWPFormInstance,  AV31WWPFormInstanceElementId,  AV22VisibleCondition) )
         {
            divLayoutmaintable_Class = "Table";
            AssignProp(sPrefix, false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         }
         else
         {
            divLayoutmaintable_Class = "Invisible";
            AssignProp(sPrefix, false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         }
      }

      protected void S152( )
      {
         /* 'EXECUTE VALIDATIONS' Routine */
         returnInSub = false;
         AV15IsRequired = AV24WWP_DF_CharMetadata.gxTpr_Isrequired;
         AV21Validations = AV24WWP_DF_CharMetadata.gxTpr_Validations;
         AV20ThisValueStr = StringUtil.Format( "'%1'", StringUtil.StringReplace( AV8Data, "'", ""), "", "", "", "", "", "", "", "");
         AV16IsValid = true;
         if ( AV15IsRequired && ( StringUtil.StrCmp(StringUtil.Trim( AV20ThisValueStr), "''") == 0 ) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), AV28WWPFormElementTitle, "", "", "", "", "", "", "", ""),  "error",  AV11ElementInternalName,  "true",  ""));
            AV16IsValid = false;
         }
         else
         {
            if ( AV21Validations.Count > 0 )
            {
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_executeelementvalidations(context ).execute(  AV29WWPFormInstance,  AV31WWPFormInstanceElementId,  AV20ThisValueStr,  AV21Validations, out  AV18Messages) ;
               AV38GXV3 = 1;
               while ( AV38GXV3 <= AV18Messages.Count )
               {
                  AV17Message = ((GeneXus.Utils.SdtMessages_Message)AV18Messages.Item(AV38GXV3));
                  GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV17Message.gxTpr_Description,  ((AV17Message.gxTpr_Type==1) ? "error" : "info"),  AV11ElementInternalName,  "true",  ""));
                  if ( AV17Message.gxTpr_Type == 1 )
                  {
                     AV16IsValid = false;
                     if (true) break;
                  }
                  AV38GXV3 = (int)(AV38GXV3+1);
               }
            }
         }
      }

      protected void S182( )
      {
         /* 'LOAD TITLE AND METADATA' Routine */
         returnInSub = false;
         AV5WWPFormElementCaption = 0;
         if ( AV5WWPFormElementCaption == 2 )
         {
            lblDatatitle_Caption = AV28WWPFormElementTitle;
            AssignProp(sPrefix, false, lblDatatitle_Internalname, "Caption", lblDatatitle_Caption, true);
            divDatatitlecell_Visible = 1;
            AssignProp(sPrefix, false, divDatatitlecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDatatitlecell_Visible), 5, 0), true);
         }
         else
         {
            divDatatitlecell_Visible = 0;
            AssignProp(sPrefix, false, divDatatitlecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDatatitlecell_Visible), 5, 0), true);
         }
         AV9DataCellNameClass = "DataContentCell DscTop";
         if ( AV5WWPFormElementCaption != 1 )
         {
            AV9DataCellNameClass += " DataContentCellNoLabel";
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV35SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationvalue)) )
         {
            lblDatatitle_Caption = AV28WWPFormElementTitle;
            AssignProp(sPrefix, false, lblDatatitle_Internalname, "Caption", lblDatatitle_Caption, true);
         }
         else
         {
            lblDatatitle_Caption = AV35SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationvalue;
            AssignProp(sPrefix, false, lblDatatitle_Internalname, "Caption", lblDatatitle_Caption, true);
         }
         divDatatitlecell_Visible = 1;
         AssignProp(sPrefix, false, divDatatitlecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDatatitlecell_Visible), 5, 0), true);
         AV24WWP_DF_CharMetadata.FromJSonString(AV27WWPFormElementMetadata, null);
         if ( AV24WWP_DF_CharMetadata.gxTpr_Isrequired )
         {
            AV9DataCellNameClass = "Required" + AV9DataCellNameClass;
         }
         divDatacellname_Class = AV9DataCellNameClass;
         AssignProp(sPrefix, false, divDatacellname_Internalname, "Class", divDatacellname_Class, true);
         divDatatitlecell_Class = AV9DataCellNameClass;
         AssignProp(sPrefix, false, divDatatitlecell_Internalname, "Class", divDatatitlecell_Class, true);
      }

      protected void S132( )
      {
         /* 'SET FOCUS TO ELEMENT' Routine */
         returnInSub = false;
         GX_FocusControl = Data_Internalname;
         AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         context.DoAjaxSetFocus(GX_FocusControl);
      }

      protected void E112G2( )
      {
         /* Data_Keyup Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVE ELEMENT DATA TO SESSION' */
         S142 ();
         if (returnInSub) return;
         if ( AV13HasReferenceId )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "DynamicForm_UpdateVisibilities", new Object[] {(short)AV19SessionId}, true);
         }
         /* Execute user subroutine: 'EXECUTE VALIDATIONS' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV30WWPFormInstanceElement", AV30WWPFormInstanceElement);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV29WWPFormInstance", AV29WWPFormInstance);
      }

      protected void nextLoad( )
      {
      }

      protected void E152G2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV25WWPDynamicFormMode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV25WWPDynamicFormMode", AV25WWPDynamicFormMode);
         AV26WWPFormElementId = Convert.ToInt16(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV26WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV26WWPFormElementId), 4, 0));
         AV31WWPFormInstanceElementId = Convert.ToInt16(getParm(obj,2));
         AssignAttri(sPrefix, false, "AV31WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV31WWPFormInstanceElementId), 4, 0));
         AV19SessionId = Convert.ToInt16(getParm(obj,3));
         AssignAttri(sPrefix, false, "AV19SessionId", StringUtil.LTrimStr( (decimal)(AV19SessionId), 4, 0));
         AV29WWPFormInstance = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)getParm(obj,4);
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
         PA2G2( ) ;
         WS2G2( ) ;
         WE2G2( ) ;
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
         sCtrlAV25WWPDynamicFormMode = (string)((string)getParm(obj,0));
         sCtrlAV26WWPFormElementId = (string)((string)getParm(obj,1));
         sCtrlAV31WWPFormInstanceElementId = (string)((string)getParm(obj,2));
         sCtrlAV19SessionId = (string)((string)getParm(obj,3));
         sCtrlAV29WWPFormInstance = (string)((string)getParm(obj,4));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2G2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "workwithplus\\dynamicforms\\wwp_df_htmleditor_wc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2G2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV25WWPDynamicFormMode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV25WWPDynamicFormMode", AV25WWPDynamicFormMode);
            AV26WWPFormElementId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV26WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV26WWPFormElementId), 4, 0));
            AV31WWPFormInstanceElementId = Convert.ToInt16(getParm(obj,4));
            AssignAttri(sPrefix, false, "AV31WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV31WWPFormInstanceElementId), 4, 0));
            AV19SessionId = Convert.ToInt16(getParm(obj,5));
            AssignAttri(sPrefix, false, "AV19SessionId", StringUtil.LTrimStr( (decimal)(AV19SessionId), 4, 0));
            AV29WWPFormInstance = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)getParm(obj,6);
         }
         wcpOAV25WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV25WWPDynamicFormMode");
         wcpOAV26WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV26WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV31WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV31WWPFormInstanceElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV19SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV19SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV25WWPDynamicFormMode, wcpOAV25WWPDynamicFormMode) != 0 ) || ( AV26WWPFormElementId != wcpOAV26WWPFormElementId ) || ( AV31WWPFormInstanceElementId != wcpOAV31WWPFormInstanceElementId ) || ( AV19SessionId != wcpOAV19SessionId ) ) )
         {
            setjustcreated();
         }
         wcpOAV25WWPDynamicFormMode = AV25WWPDynamicFormMode;
         wcpOAV26WWPFormElementId = AV26WWPFormElementId;
         wcpOAV31WWPFormInstanceElementId = AV31WWPFormInstanceElementId;
         wcpOAV19SessionId = AV19SessionId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV25WWPDynamicFormMode = cgiGet( sPrefix+"AV25WWPDynamicFormMode_CTRL");
         if ( StringUtil.Len( sCtrlAV25WWPDynamicFormMode) > 0 )
         {
            AV25WWPDynamicFormMode = cgiGet( sCtrlAV25WWPDynamicFormMode);
            AssignAttri(sPrefix, false, "AV25WWPDynamicFormMode", AV25WWPDynamicFormMode);
         }
         else
         {
            AV25WWPDynamicFormMode = cgiGet( sPrefix+"AV25WWPDynamicFormMode_PARM");
         }
         sCtrlAV26WWPFormElementId = cgiGet( sPrefix+"AV26WWPFormElementId_CTRL");
         if ( StringUtil.Len( sCtrlAV26WWPFormElementId) > 0 )
         {
            AV26WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV26WWPFormElementId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV26WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV26WWPFormElementId), 4, 0));
         }
         else
         {
            AV26WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV26WWPFormElementId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV31WWPFormInstanceElementId = cgiGet( sPrefix+"AV31WWPFormInstanceElementId_CTRL");
         if ( StringUtil.Len( sCtrlAV31WWPFormInstanceElementId) > 0 )
         {
            AV31WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV31WWPFormInstanceElementId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV31WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV31WWPFormInstanceElementId), 4, 0));
         }
         else
         {
            AV31WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV31WWPFormInstanceElementId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV19SessionId = cgiGet( sPrefix+"AV19SessionId_CTRL");
         if ( StringUtil.Len( sCtrlAV19SessionId) > 0 )
         {
            AV19SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV19SessionId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV19SessionId", StringUtil.LTrimStr( (decimal)(AV19SessionId), 4, 0));
         }
         else
         {
            AV19SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV19SessionId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV29WWPFormInstance = cgiGet( sPrefix+"AV29WWPFormInstance_CTRL");
         if ( StringUtil.Len( sCtrlAV29WWPFormInstance) > 0 )
         {
            AV29WWPFormInstance.FromXml(cgiGet( sCtrlAV29WWPFormInstance), null, "", "");
         }
         else
         {
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"AV29WWPFormInstance_PARM"), AV29WWPFormInstance);
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
         PA2G2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2G2( ) ;
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
         WS2G2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV25WWPDynamicFormMode_PARM", StringUtil.RTrim( AV25WWPDynamicFormMode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV25WWPDynamicFormMode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV25WWPDynamicFormMode_CTRL", StringUtil.RTrim( sCtrlAV25WWPDynamicFormMode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV26WWPFormElementId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV26WWPFormElementId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV26WWPFormElementId_CTRL", StringUtil.RTrim( sCtrlAV26WWPFormElementId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV31WWPFormInstanceElementId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV31WWPFormInstanceElementId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV31WWPFormInstanceElementId_CTRL", StringUtil.RTrim( sCtrlAV31WWPFormInstanceElementId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV19SessionId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV19SessionId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV19SessionId_CTRL", StringUtil.RTrim( sCtrlAV19SessionId));
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"AV29WWPFormInstance_PARM", AV29WWPFormInstance);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"AV29WWPFormInstance_PARM", AV29WWPFormInstance);
         }
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV29WWPFormInstance)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV29WWPFormInstance_CTRL", StringUtil.RTrim( sCtrlAV29WWPFormInstance));
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
         WE2G2( ) ;
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
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202562016572637", true, true);
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
         context.AddJavascriptSource("workwithplus/dynamicforms/wwp_df_htmleditor_wc.js", "?202562016572638", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblDatatitle_Internalname = sPrefix+"DATATITLE";
         divDatatitlecell_Internalname = sPrefix+"DATATITLECELL";
         Data_Internalname = sPrefix+"DATA";
         divDatacellname_Internalname = sPrefix+"DATACELLNAME";
         lblDatareadonly_Internalname = sPrefix+"DATAREADONLY";
         divDatareadonlycell_Internalname = sPrefix+"DATAREADONLYCELL";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
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
         lblDatareadonly_Caption = " ";
         divDatareadonlycell_Class = "col-xs-12 DynamicFormHTMLEditorCell";
         Data_Enabled = Convert.ToBoolean( 1);
         divDatacellname_Class = "col-xs-12 DataContentCell CKEditor DscTop";
         lblDatatitle_Caption = context.GetMessage( "Title", "");
         divDatatitlecell_Class = "col-xs-12";
         divDatatitlecell_Visible = 1;
         divLayoutmaintable_Class = "Table";
         Data_Visible = Convert.ToBoolean( -1);
         Data_Captionposition = "Left";
         Data_Captionstyle = "";
         Data_Captionclass = " AttributeLabel";
         Data_Customconfiguration = "myconfig.js";
         Data_Customtoolbar = "myToolbar";
         Data_Toolbar = "Custom";
         Data_Skin = "default";
         Data_Height = "250";
         Data_Width = "100%";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV24WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA","hsh":true},{"av":"AV28WWPFormElementTitle","fld":"vWWPFORMELEMENTTITLE","hsh":true},{"av":"AV11ElementInternalName","fld":"vELEMENTINTERNALNAME","hsh":true},{"av":"AV13HasReferenceId","fld":"vHASREFERENCEID","hsh":true}]}""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_VALIDATE","""{"handler":"E132G2","iparms":[{"av":"AV34ErrorIds","fld":"vERRORIDS"},{"av":"AV6AuxSessionId","fld":"vAUXSESSIONID","pic":"ZZZ9"},{"av":"AV19SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"divLayoutmaintable_Class","ctrl":"LAYOUTMAINTABLE","prop":"Class"},{"av":"AV26WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV31WWPFormInstanceElementId","fld":"vWWPFORMINSTANCEELEMENTID","pic":"ZZZ9"},{"av":"AV12ExistElement","fld":"vEXISTELEMENT"},{"av":"AV29WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV24WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA","hsh":true},{"av":"AV8Data","fld":"vDATA"},{"av":"AV28WWPFormElementTitle","fld":"vWWPFORMELEMENTTITLE","hsh":true},{"av":"AV11ElementInternalName","fld":"vELEMENTINTERNALNAME","hsh":true},{"av":"AV30WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"}]""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_VALIDATE",""","oparms":[{"av":"AV12ExistElement","fld":"vEXISTELEMENT"},{"av":"AV30WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"},{"av":"AV29WWPFormInstance","fld":"vWWPFORMINSTANCE"}]}""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES","""{"handler":"E142G2","iparms":[{"av":"AV6AuxSessionId","fld":"vAUXSESSIONID","pic":"ZZZ9"},{"av":"AV19SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV22VisibleCondition","fld":"vVISIBLECONDITION"},{"av":"AV24WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA","hsh":true},{"av":"AV31WWPFormInstanceElementId","fld":"vWWPFORMINSTANCEELEMENTID","pic":"ZZZ9"},{"av":"AV29WWPFormInstance","fld":"vWWPFORMINSTANCE"}]""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES",""","oparms":[{"av":"AV29WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV22VisibleCondition","fld":"vVISIBLECONDITION"},{"av":"divLayoutmaintable_Class","ctrl":"LAYOUTMAINTABLE","prop":"Class"}]}""");
         setEventMetadata("VDATA.KEYUP","""{"handler":"E112G2","iparms":[{"av":"AV13HasReferenceId","fld":"vHASREFERENCEID","hsh":true},{"av":"AV19SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV29WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV26WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV31WWPFormInstanceElementId","fld":"vWWPFORMINSTANCEELEMENTID","pic":"ZZZ9"},{"av":"AV24WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA","hsh":true},{"av":"AV8Data","fld":"vDATA"},{"av":"AV28WWPFormElementTitle","fld":"vWWPFORMELEMENTTITLE","hsh":true},{"av":"AV11ElementInternalName","fld":"vELEMENTINTERNALNAME","hsh":true},{"av":"AV30WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"}]""");
         setEventMetadata("VDATA.KEYUP",""","oparms":[{"av":"AV12ExistElement","fld":"vEXISTELEMENT"},{"av":"AV30WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"},{"av":"AV29WWPFormInstance","fld":"vWWPFORMINSTANCE"}]}""");
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
         AV29WWPFormInstance = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         wcpOAV25WWPDynamicFormMode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV24WWP_DF_CharMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata(context);
         AV28WWPFormElementTitle = "";
         AV11ElementInternalName = "";
         AV8Data = "";
         AV34ErrorIds = "";
         AV30WWPFormInstanceElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         AV22VisibleCondition = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression(context);
         GX_FocusControl = "";
         lblDatatitle_Jsonclick = "";
         ucData = new GXUserControl();
         lblDatareadonly_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV35SDT_DynamicFormTranslation = new SdtSDT_DynamicFormTranslation(context);
         AV7CurrentWWPFormInstanceElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         AV27WWPFormElementMetadata = "";
         AV23WebSession = context.GetSession();
         GXt_SdtWWP_FormInstance1 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         AV21Validations = new GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation>( context, "WWP_DF_Validation", "Comforta_version2");
         AV20ThisValueStr = "";
         AV18Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV17Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV9DataCellNameClass = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV25WWPDynamicFormMode = "";
         sCtrlAV26WWPFormElementId = "";
         sCtrlAV31WWPFormInstanceElementId = "";
         sCtrlAV19SessionId = "";
         sCtrlAV29WWPFormInstance = "";
         /* GeneXus formulas. */
      }

      private short AV26WWPFormElementId ;
      private short AV31WWPFormInstanceElementId ;
      private short AV19SessionId ;
      private short wcpOAV26WWPFormElementId ;
      private short wcpOAV31WWPFormInstanceElementId ;
      private short wcpOAV19SessionId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV6AuxSessionId ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short AV5WWPFormElementCaption ;
      private short nGXWrapped ;
      private int divDatatitlecell_Visible ;
      private int AV36GXV1 ;
      private int AV37GXV2 ;
      private int AV38GXV3 ;
      private int idxLst ;
      private string AV25WWPDynamicFormMode ;
      private string wcpOAV25WWPDynamicFormMode ;
      private string divLayoutmaintable_Class ;
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
      private string Data_Width ;
      private string Data_Height ;
      private string Data_Skin ;
      private string Data_Toolbar ;
      private string Data_Customtoolbar ;
      private string Data_Customconfiguration ;
      private string Data_Captionclass ;
      private string Data_Captionstyle ;
      private string Data_Captionposition ;
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
      private string Data_Internalname ;
      private string divDatareadonlycell_Internalname ;
      private string divDatareadonlycell_Class ;
      private string lblDatareadonly_Internalname ;
      private string lblDatareadonly_Caption ;
      private string lblDatareadonly_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string sCtrlAV25WWPDynamicFormMode ;
      private string sCtrlAV26WWPFormElementId ;
      private string sCtrlAV31WWPFormInstanceElementId ;
      private string sCtrlAV19SessionId ;
      private string sCtrlAV29WWPFormInstance ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13HasReferenceId ;
      private bool AV12ExistElement ;
      private bool Data_Enabled ;
      private bool Data_Visible ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV14IsElementFocusable ;
      private bool AV10DataEnabled ;
      private bool AV15IsRequired ;
      private bool AV16IsValid ;
      private string AV28WWPFormElementTitle ;
      private string AV8Data ;
      private string AV27WWPFormElementMetadata ;
      private string AV11ElementInternalName ;
      private string AV34ErrorIds ;
      private string AV20ThisValueStr ;
      private string AV9DataCellNameClass ;
      private IGxSession AV23WebSession ;
      private GXUserControl ucData ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV29WWPFormInstance ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP4_WWPFormInstance ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata AV24WWP_DF_CharMetadata ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element AV30WWPFormInstanceElement ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression AV22VisibleCondition ;
      private SdtSDT_DynamicFormTranslation AV35SDT_DynamicFormTranslation ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element AV7CurrentWWPFormInstanceElement ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance GXt_SdtWWP_FormInstance1 ;
      private GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation> AV21Validations ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV18Messages ;
      private GeneXus.Utils.SdtMessages_Message AV17Message ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
