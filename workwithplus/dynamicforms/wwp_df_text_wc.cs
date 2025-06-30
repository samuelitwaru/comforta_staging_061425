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
   public class wwp_df_text_wc : GXWebComponent
   {
      public wwp_df_text_wc( )
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

      public wwp_df_text_wc( IGxContext context )
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
         this.AV27WWPDynamicFormMode = aP0_WWPDynamicFormMode;
         this.AV29WWPFormElementId = aP1_WWPFormElementId;
         this.AV34WWPFormInstanceElementId = aP2_WWPFormInstanceElementId;
         this.AV21SessionId = aP3_SessionId;
         this.AV32WWPFormInstance = aP4_WWPFormInstance;
         ExecuteImpl();
         aP4_WWPFormInstance=this.AV32WWPFormInstance;
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
                  AV27WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
                  AssignAttri(sPrefix, false, "AV27WWPDynamicFormMode", AV27WWPDynamicFormMode);
                  AV29WWPFormElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV29WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV29WWPFormElementId), 4, 0));
                  AV34WWPFormInstanceElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormInstanceElementId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV34WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV34WWPFormInstanceElementId), 4, 0));
                  AV21SessionId = (short)(Math.Round(NumberUtil.Val( GetPar( "SessionId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV21SessionId", StringUtil.LTrimStr( (decimal)(AV21SessionId), 4, 0));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV32WWPFormInstance);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV27WWPDynamicFormMode,(short)AV29WWPFormElementId,(short)AV34WWPFormInstanceElementId,(short)AV21SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV32WWPFormInstance});
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
            PA2E2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS2E2( ) ;
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
            context.SendWebValue( context.GetMessage( "WWP_Dynamic Form_Text_WC", "")) ;
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
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_df_text_wc.aspx"+UrlEncode(StringUtil.RTrim(AV27WWPDynamicFormMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV29WWPFormElementId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV34WWPFormInstanceElementId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV21SessionId,4,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.dynamicforms.wwp_df_text_wc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASREFERENCEID", AV13HasReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV13HasReferenceId, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_CHARMETADATA", AV26WWP_DF_CharMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_CHARMETADATA", AV26WWP_DF_CharMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_CHARMETADATA", GetSecureSignedToken( sPrefix, AV26WWP_DF_CharMetadata, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vERRORMESSAGE", AV35ErrorMessage);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vERRORMESSAGE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV35ErrorMessage, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTDATATYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28WWPFormElementDataType), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTDATATYPE", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV28WWPFormElementDataType), "Z9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTTITLE", AV31WWPFormElementTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTTITLE", GetSecureSignedToken( sPrefix, AV31WWPFormElementTitle, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV27WWPDynamicFormMode", StringUtil.RTrim( wcpOAV27WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV29WWPFormElementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV29WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV34WWPFormInstanceElementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV34WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV21SessionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV21SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDATACONTROLVALUECHANGED", AV36DataControlValueChanged);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASREFERENCEID", AV13HasReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV13HasReferenceId, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORMINSTANCE", AV32WWPFormInstance);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORMINSTANCE", AV32WWPFormInstance);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMINSTANCEELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_CHARMETADATA", AV26WWP_DF_CharMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_CHARMETADATA", AV26WWP_DF_CharMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_CHARMETADATA", GetSecureSignedToken( sPrefix, AV26WWP_DF_CharMetadata, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vERRORMESSAGE", AV35ErrorMessage);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vERRORMESSAGE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV35ErrorMessage, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTDATATYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28WWPFormElementDataType), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTDATATYPE", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV28WWPFormElementDataType), "Z9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTTITLE", AV31WWPFormElementTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTTITLE", GetSecureSignedToken( sPrefix, AV31WWPFormElementTitle, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORMINSTANCEELEMENT", AV33WWPFormInstanceElement);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORMINSTANCEELEMENT", AV33WWPFormInstanceElement);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vERRORIDS", AV39ErrorIds);
         GxWebStd.gx_hidden_field( context, sPrefix+"vAUXSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6AuxSessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vEXISTELEMENT", AV12ExistElement);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vVISIBLECONDITION", AV24VisibleCondition);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vVISIBLECONDITION", AV24VisibleCondition);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV27WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"LAYOUTMAINTABLE_Class", StringUtil.RTrim( divLayoutmaintable_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"LAYOUTMAINTABLE_Class", StringUtil.RTrim( divLayoutmaintable_Class));
      }

      protected void RenderHtmlCloseForm2E2( )
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
         return "WorkWithPlus.DynamicForms.WWP_DF_Text_WC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WWP_Dynamic Form_Text_WC", "") ;
      }

      protected void WB2E0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "workwithplus.dynamicforms.wwp_df_text_wc.aspx");
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
            GxWebStd.gx_label_ctrl( context, lblDatatitle_Internalname, lblDatatitle_Caption, "", "", lblDatatitle_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DynFormDataDescription", 0, "", 1, 1, 0, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DF_Text_WC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDatacellname_Internalname, 1, 0, "px", 0, "px", divDatacellname_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavData_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavData_Internalname, edtavData_Caption, " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavData_Internalname, AV8Data, StringUtil.RTrim( context.localUtil.Format( AV8Data, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,14);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtavData_Link, edtavData_Linktarget, "", "", edtavData_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavData_Enabled, 1, "text", "", 80, "chr", 1, "row", 150, edtavData_Ispassword, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WorkWithPlus/DynamicForms/WWP_DF_Text_WC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FixingTopInvisible", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnfixcontrolvaluechanged_Internalname, "", context.GetMessage( "GX_BtnRefresh", ""), bttBtnfixcontrolvaluechanged_Jsonclick, 5, context.GetMessage( "GX_BtnRefresh", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOFIXCONTROLVALUECHANGED\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/DynamicForms/WWP_DF_Text_WC.htm");
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

      protected void START2E2( )
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
            Form.Meta.addItem("description", context.GetMessage( "WWP_Dynamic Form_Text_WC", ""), 0) ;
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
               STRUP2E0( ) ;
            }
         }
      }

      protected void WS2E2( )
      {
         START2E2( ) ;
         EVT2E2( ) ;
      }

      protected void EVT2E2( )
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
                                 STRUP2E0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2E0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E112E2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFIXCONTROLVALUECHANGED'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2E0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoFixControlValueChanged' */
                                    E122E2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.DYNAMICFORM_VALIDATE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2E0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E132E2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2E0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E142E2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDATA.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2E0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E152E2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2E0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E162E2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2E0( ) ;
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
                                 STRUP2E0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavData_Internalname;
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE2E2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2E2( ) ;
            }
         }
      }

      protected void PA2E2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.dynamicforms.wwp_df_text_wc.aspx")), "workwithplus.dynamicforms.wwp_df_text_wc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.dynamicforms.wwp_df_text_wc.aspx")))) ;
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
               GX_FocusControl = edtavData_Internalname;
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
         RF2E2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF2E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E162E2 ();
            WB2E0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2E2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASREFERENCEID", AV13HasReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV13HasReferenceId, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_CHARMETADATA", AV26WWP_DF_CharMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_CHARMETADATA", AV26WWP_DF_CharMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_CHARMETADATA", GetSecureSignedToken( sPrefix, AV26WWP_DF_CharMetadata, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vERRORMESSAGE", AV35ErrorMessage);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vERRORMESSAGE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV35ErrorMessage, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTDATATYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28WWPFormElementDataType), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTDATATYPE", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV28WWPFormElementDataType), "Z9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTTITLE", AV31WWPFormElementTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTTITLE", GetSecureSignedToken( sPrefix, AV31WWPFormElementTitle, context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E112E2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOAV27WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV27WWPDynamicFormMode");
            wcpOAV29WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV29WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV34WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV34WWPFormInstanceElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV21SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV21SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            divLayoutmaintable_Class = cgiGet( sPrefix+"LAYOUTMAINTABLE_Class");
            /* Read variables values. */
            AV8Data = cgiGet( edtavData_Internalname);
            AssignAttri(sPrefix, false, "AV8Data", AV8Data);
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
         E112E2 ();
         if (returnInSub) return;
      }

      protected void E112E2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV15IsElementFocusable = true;
         AV40SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformid = AV32WWPFormInstance.gxTpr_Wwpformid;
         AV40SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformversionnumber = AV32WWPFormInstance.gxTpr_Wwpformversionnumber;
         AV40SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformelementid = AV29WWPFormElementId;
         new prc_getdynamicformtranslation(context ).execute( ref  AV40SDT_DynamicFormTranslation) ;
         AV13HasReferenceId = false;
         AssignAttri(sPrefix, false, "AV13HasReferenceId", AV13HasReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV13HasReferenceId, context));
         AV42GXV1 = 1;
         while ( AV42GXV1 <= AV32WWPFormInstance.gxTpr_Element.Count )
         {
            AV33WWPFormInstanceElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV32WWPFormInstance.gxTpr_Element.Item(AV42GXV1));
            if ( ( AV33WWPFormInstanceElement.gxTpr_Wwpformelementid == AV29WWPFormElementId ) && ( AV33WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid == AV34WWPFormInstanceElementId ) )
            {
               AV7CurrentWWPFormInstanceElement = AV33WWPFormInstanceElement;
               AV13HasReferenceId = (bool)((!String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV33WWPFormInstanceElement.gxTpr_Wwpformelementreferenceid)))));
               AssignAttri(sPrefix, false, "AV13HasReferenceId", AV13HasReferenceId);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV13HasReferenceId, context));
               AV31WWPFormElementTitle = AV33WWPFormInstanceElement.gxTpr_Wwpformelementtitle;
               AssignAttri(sPrefix, false, "AV31WWPFormElementTitle", AV31WWPFormElementTitle);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTTITLE", GetSecureSignedToken( sPrefix, AV31WWPFormElementTitle, context));
               AV30WWPFormElementMetadata = AV33WWPFormInstanceElement.gxTpr_Wwpformelementmetadata;
               AssignAttri(sPrefix, false, "AV30WWPFormElementMetadata", AV30WWPFormElementMetadata);
               AV5WWPFormElementCaption = AV33WWPFormInstanceElement.gxTpr_Wwpformelementcaption;
               AssignAttri(sPrefix, false, "AV5WWPFormElementCaption", StringUtil.Str( (decimal)(AV5WWPFormElementCaption), 1, 0));
               if (true) break;
            }
            AV42GXV1 = (int)(AV42GXV1+1);
         }
         /* Execute user subroutine: 'LOAD TITLE AND METADATA' */
         S192 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GET DATA FROM CURRENT ELEMENT' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UPDATE VISIBILITY' */
         S122 ();
         if (returnInSub) return;
         if ( AV15IsElementFocusable && ( StringUtil.StrCmp(divLayoutmaintable_Class, "Table") == 0 ) && ( StringUtil.StrCmp(AV25WebSession.Get("WWPDynFormSetFocus"), "") != 0 ) )
         {
            /* Execute user subroutine: 'SET FOCUS TO ELEMENT' */
            S132 ();
            if (returnInSub) return;
            AV25WebSession.Remove("WWPDynFormSetFocus");
         }
         if ( ( StringUtil.StrCmp(AV27WWPDynamicFormMode, "DSP") != 0 ) && ( StringUtil.StrCmp(AV27WWPDynamicFormMode, "DLT") != 0 ) )
         {
            AV10DataEnabled = true;
            AssignAttri(sPrefix, false, "AV10DataEnabled", AV10DataEnabled);
         }
         if ( AV28WWPFormElementDataType != 2 )
         {
            AV26WWP_DF_CharMetadata.gxTpr_Length = 150;
         }
         AV14i = 1;
         while ( AV14i <= AV26WWP_DF_CharMetadata.gxTpr_Length )
         {
            AV18Mask += "Z";
            AssignAttri(sPrefix, false, "AV18Mask", AV18Mask);
            AV14i = (short)(AV14i+1);
         }
         this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "Mask_Apply", new Object[] {(string)edtavData_Internalname,(string)AV18Mask,(bool)false,(bool)false}, false);
         if ( AV28WWPFormElementDataType == 6 )
         {
            edtavData_Ispassword = 1;
            AssignProp(sPrefix, false, edtavData_Internalname, "Ispassword", StringUtil.Str( (decimal)(edtavData_Ispassword), 1, 0), true);
         }
         edtavData_Enabled = (AV10DataEnabled ? 1 : 0);
         AssignProp(sPrefix, false, edtavData_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavData_Enabled), 5, 0), true);
         if ( ! AV10DataEnabled && ! String.IsNullOrEmpty(StringUtil.RTrim( AV8Data)) )
         {
            edtavData_Linktarget = "_blank";
            AssignProp(sPrefix, false, edtavData_Internalname, "Linktarget", edtavData_Linktarget, true);
            if ( AV28WWPFormElementDataType == 7 )
            {
               edtavData_Link = "mailto:"+AV8Data;
               AssignProp(sPrefix, false, edtavData_Internalname, "Link", edtavData_Link, true);
            }
            else if ( AV28WWPFormElementDataType == 8 )
            {
               edtavData_Link = AV8Data;
               AssignProp(sPrefix, false, edtavData_Internalname, "Link", edtavData_Link, true);
            }
         }
         this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "Control_FixControlValueChanged", new Object[] {(string)edtavData_Internalname,(string)bttBtnfixcontrolvaluechanged_Internalname}, false);
         AV36DataControlValueChanged = (AV26WWP_DF_CharMetadata.gxTpr_Isrequired&&String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV8Data))) ? "." : AV8Data);
         AssignAttri(sPrefix, false, "AV36DataControlValueChanged", AV36DataControlValueChanged);
      }

      protected void E122E2( )
      {
         /* 'DoFixControlValueChanged' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV36DataControlValueChanged, AV8Data) != 0 )
         {
            AV36DataControlValueChanged = AV8Data;
            AssignAttri(sPrefix, false, "AV36DataControlValueChanged", AV36DataControlValueChanged);
            /* Execute user subroutine: 'DATA CONTROL VALUE CHANGED' */
            S142 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV33WWPFormInstanceElement", AV33WWPFormInstanceElement);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32WWPFormInstance", AV32WWPFormInstance);
      }

      protected void E132E2( )
      {
         /* General\GlobalEvents_Dynamicform_validate Routine */
         returnInSub = false;
         if ( ( AV6AuxSessionId == AV21SessionId ) && ( StringUtil.StrCmp(divLayoutmaintable_Class, "Invisible") != 0 ) && StringUtil.Contains( AV39ErrorIds, "|"+StringUtil.Trim( StringUtil.Str( (decimal)(AV29WWPFormElementId), 4, 0))+"."+StringUtil.Trim( StringUtil.Str( (decimal)(AV34WWPFormInstanceElementId), 4, 0))+"|") )
         {
            /* Execute user subroutine: 'SAVE ELEMENT DATA TO SESSION' */
            S152 ();
            if (returnInSub) return;
            if ( AV12ExistElement )
            {
               /* Execute user subroutine: 'EXECUTE VALIDATIONS' */
               S162 ();
               if (returnInSub) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV33WWPFormInstanceElement", AV33WWPFormInstanceElement);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32WWPFormInstance", AV32WWPFormInstance);
      }

      protected void E142E2( )
      {
         /* General\GlobalEvents_Dynamicform_updatevisibilities Routine */
         returnInSub = false;
         if ( ( AV6AuxSessionId == AV21SessionId ) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV24VisibleCondition.gxTpr_Expression))) )
         {
            /* Execute user subroutine: 'GET FORM INSTANCE' */
            S172 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'UPDATE VISIBILITY' */
            S122 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32WWPFormInstance", AV32WWPFormInstance);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV24VisibleCondition", AV24VisibleCondition);
      }

      protected void S172( )
      {
         /* 'GET FORM INSTANCE' Routine */
         returnInSub = false;
         GXt_SdtWWP_FormInstance1 = AV32WWPFormInstance;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadforminstance(context ).execute(  AV21SessionId, out  GXt_SdtWWP_FormInstance1) ;
         AV32WWPFormInstance = GXt_SdtWWP_FormInstance1;
      }

      protected void S112( )
      {
         /* 'GET DATA FROM CURRENT ELEMENT' Routine */
         returnInSub = false;
         AV8Data = AV7CurrentWWPFormInstanceElement.gxTpr_Wwpforminstanceelemchar;
         AssignAttri(sPrefix, false, "AV8Data", AV8Data);
         AV28WWPFormElementDataType = AV7CurrentWWPFormInstanceElement.gxTpr_Wwpformelementdatatype;
         AssignAttri(sPrefix, false, "AV28WWPFormElementDataType", StringUtil.LTrimStr( (decimal)(AV28WWPFormElementDataType), 2, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTDATATYPE", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV28WWPFormElementDataType), "Z9"), context));
      }

      protected void S152( )
      {
         /* 'SAVE ELEMENT DATA TO SESSION' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GET FORM INSTANCE' */
         S172 ();
         if (returnInSub) return;
         AV12ExistElement = false;
         AssignAttri(sPrefix, false, "AV12ExistElement", AV12ExistElement);
         AV43GXV2 = 1;
         while ( AV43GXV2 <= AV32WWPFormInstance.gxTpr_Element.Count )
         {
            AV33WWPFormInstanceElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV32WWPFormInstance.gxTpr_Element.Item(AV43GXV2));
            if ( ( AV33WWPFormInstanceElement.gxTpr_Wwpformelementid == AV29WWPFormElementId ) && ( AV33WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid == AV34WWPFormInstanceElementId ) )
            {
               AV12ExistElement = true;
               AssignAttri(sPrefix, false, "AV12ExistElement", AV12ExistElement);
               if (true) break;
            }
            AV43GXV2 = (int)(AV43GXV2+1);
         }
         if ( AV12ExistElement )
         {
            /* Execute user subroutine: 'SET DATA TO ELEMENT' */
            S182 ();
            if (returnInSub) return;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_saveforminstance(context ).execute(  AV21SessionId,  AV32WWPFormInstance) ;
         }
      }

      protected void S182( )
      {
         /* 'SET DATA TO ELEMENT' Routine */
         returnInSub = false;
         AV33WWPFormInstanceElement.gxTpr_Wwpforminstanceelemchar = AV8Data;
      }

      protected void S122( )
      {
         /* 'UPDATE VISIBILITY' Routine */
         returnInSub = false;
         AV24VisibleCondition = AV26WWP_DF_CharMetadata.gxTpr_Visiblecondition;
         if ( new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_evaluateelementvisibility(context).executeUdp(  AV32WWPFormInstance,  AV34WWPFormInstanceElementId,  AV24VisibleCondition) )
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

      protected void S162( )
      {
         /* 'EXECUTE VALIDATIONS' Routine */
         returnInSub = false;
         AV16IsRequired = AV26WWP_DF_CharMetadata.gxTpr_Isrequired;
         AV23Validations = AV26WWP_DF_CharMetadata.gxTpr_Validations;
         AV22ThisValueStr = StringUtil.Format( "'%1'", StringUtil.StringReplace( AV8Data, "'", ""), "", "", "", "", "", "", "", "");
         AV11ElementInternalName = edtavData_Internalname;
         if ( new WorkWithPlus.workwithplus_dynamicforms.wwp_df_validatetextvalue(context).executeUdp(  AV28WWPFormElementDataType,  AV8Data, out  AV35ErrorMessage) )
         {
            AV17IsValid = true;
            if ( AV16IsRequired && ( StringUtil.StrCmp(StringUtil.Trim( AV22ThisValueStr), "''") == 0 ) )
            {
               GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), AV31WWPFormElementTitle, "", "", "", "", "", "", "", ""),  "error",  AV11ElementInternalName,  "true",  ""));
               AV17IsValid = false;
            }
            else
            {
               if ( AV23Validations.Count > 0 )
               {
                  new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_executeelementvalidations(context ).execute(  AV32WWPFormInstance,  AV34WWPFormInstanceElementId,  AV22ThisValueStr,  AV23Validations, out  AV20Messages) ;
                  AV44GXV3 = 1;
                  while ( AV44GXV3 <= AV20Messages.Count )
                  {
                     AV19Message = ((GeneXus.Utils.SdtMessages_Message)AV20Messages.Item(AV44GXV3));
                     GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV19Message.gxTpr_Description,  ((AV19Message.gxTpr_Type==1) ? "error" : "info"),  AV11ElementInternalName,  "true",  ""));
                     if ( AV19Message.gxTpr_Type == 1 )
                     {
                        AV17IsValid = false;
                        if (true) break;
                     }
                     AV44GXV3 = (int)(AV44GXV3+1);
                  }
               }
            }
         }
         else
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV35ErrorMessage,  "error",  AV11ElementInternalName,  "true",  ""));
         }
      }

      protected void S192( )
      {
         /* 'LOAD TITLE AND METADATA' Routine */
         returnInSub = false;
         if ( AV5WWPFormElementCaption == 2 )
         {
            lblDatatitle_Caption = AV31WWPFormElementTitle;
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
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV40SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationvalue)) )
         {
            edtavData_Caption = AV31WWPFormElementTitle;
            AssignProp(sPrefix, false, edtavData_Internalname, "Caption", edtavData_Caption, true);
         }
         else
         {
            edtavData_Caption = AV40SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationvalue;
            AssignProp(sPrefix, false, edtavData_Internalname, "Caption", edtavData_Caption, true);
         }
         AV26WWP_DF_CharMetadata.FromJSonString(AV30WWPFormElementMetadata, null);
         if ( AV26WWP_DF_CharMetadata.gxTpr_Isrequired )
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
         GX_FocusControl = edtavData_Internalname;
         AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         context.DoAjaxSetFocus(GX_FocusControl);
      }

      protected void E152E2( )
      {
         /* Data_Controlvaluechanged Routine */
         returnInSub = false;
         AV36DataControlValueChanged = AV8Data;
         AssignAttri(sPrefix, false, "AV36DataControlValueChanged", AV36DataControlValueChanged);
         /* Execute user subroutine: 'DATA CONTROL VALUE CHANGED' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV33WWPFormInstanceElement", AV33WWPFormInstanceElement);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32WWPFormInstance", AV32WWPFormInstance);
      }

      protected void S142( )
      {
         /* 'DATA CONTROL VALUE CHANGED' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVE ELEMENT DATA TO SESSION' */
         S152 ();
         if (returnInSub) return;
         if ( AV13HasReferenceId )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "DynamicForm_UpdateVisibilities", new Object[] {(short)AV21SessionId}, true);
         }
         /* Execute user subroutine: 'EXECUTE VALIDATIONS' */
         S162 ();
         if (returnInSub) return;
      }

      protected void nextLoad( )
      {
      }

      protected void E162E2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV27WWPDynamicFormMode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV27WWPDynamicFormMode", AV27WWPDynamicFormMode);
         AV29WWPFormElementId = Convert.ToInt16(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV29WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV29WWPFormElementId), 4, 0));
         AV34WWPFormInstanceElementId = Convert.ToInt16(getParm(obj,2));
         AssignAttri(sPrefix, false, "AV34WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV34WWPFormInstanceElementId), 4, 0));
         AV21SessionId = Convert.ToInt16(getParm(obj,3));
         AssignAttri(sPrefix, false, "AV21SessionId", StringUtil.LTrimStr( (decimal)(AV21SessionId), 4, 0));
         AV32WWPFormInstance = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)getParm(obj,4);
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
         PA2E2( ) ;
         WS2E2( ) ;
         WE2E2( ) ;
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
         sCtrlAV27WWPDynamicFormMode = (string)((string)getParm(obj,0));
         sCtrlAV29WWPFormElementId = (string)((string)getParm(obj,1));
         sCtrlAV34WWPFormInstanceElementId = (string)((string)getParm(obj,2));
         sCtrlAV21SessionId = (string)((string)getParm(obj,3));
         sCtrlAV32WWPFormInstance = (string)((string)getParm(obj,4));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2E2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "workwithplus\\dynamicforms\\wwp_df_text_wc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2E2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV27WWPDynamicFormMode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV27WWPDynamicFormMode", AV27WWPDynamicFormMode);
            AV29WWPFormElementId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV29WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV29WWPFormElementId), 4, 0));
            AV34WWPFormInstanceElementId = Convert.ToInt16(getParm(obj,4));
            AssignAttri(sPrefix, false, "AV34WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV34WWPFormInstanceElementId), 4, 0));
            AV21SessionId = Convert.ToInt16(getParm(obj,5));
            AssignAttri(sPrefix, false, "AV21SessionId", StringUtil.LTrimStr( (decimal)(AV21SessionId), 4, 0));
            AV32WWPFormInstance = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)getParm(obj,6);
         }
         wcpOAV27WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV27WWPDynamicFormMode");
         wcpOAV29WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV29WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV34WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV34WWPFormInstanceElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV21SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV21SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV27WWPDynamicFormMode, wcpOAV27WWPDynamicFormMode) != 0 ) || ( AV29WWPFormElementId != wcpOAV29WWPFormElementId ) || ( AV34WWPFormInstanceElementId != wcpOAV34WWPFormInstanceElementId ) || ( AV21SessionId != wcpOAV21SessionId ) ) )
         {
            setjustcreated();
         }
         wcpOAV27WWPDynamicFormMode = AV27WWPDynamicFormMode;
         wcpOAV29WWPFormElementId = AV29WWPFormElementId;
         wcpOAV34WWPFormInstanceElementId = AV34WWPFormInstanceElementId;
         wcpOAV21SessionId = AV21SessionId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV27WWPDynamicFormMode = cgiGet( sPrefix+"AV27WWPDynamicFormMode_CTRL");
         if ( StringUtil.Len( sCtrlAV27WWPDynamicFormMode) > 0 )
         {
            AV27WWPDynamicFormMode = cgiGet( sCtrlAV27WWPDynamicFormMode);
            AssignAttri(sPrefix, false, "AV27WWPDynamicFormMode", AV27WWPDynamicFormMode);
         }
         else
         {
            AV27WWPDynamicFormMode = cgiGet( sPrefix+"AV27WWPDynamicFormMode_PARM");
         }
         sCtrlAV29WWPFormElementId = cgiGet( sPrefix+"AV29WWPFormElementId_CTRL");
         if ( StringUtil.Len( sCtrlAV29WWPFormElementId) > 0 )
         {
            AV29WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV29WWPFormElementId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV29WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV29WWPFormElementId), 4, 0));
         }
         else
         {
            AV29WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV29WWPFormElementId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV34WWPFormInstanceElementId = cgiGet( sPrefix+"AV34WWPFormInstanceElementId_CTRL");
         if ( StringUtil.Len( sCtrlAV34WWPFormInstanceElementId) > 0 )
         {
            AV34WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV34WWPFormInstanceElementId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV34WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV34WWPFormInstanceElementId), 4, 0));
         }
         else
         {
            AV34WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV34WWPFormInstanceElementId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV21SessionId = cgiGet( sPrefix+"AV21SessionId_CTRL");
         if ( StringUtil.Len( sCtrlAV21SessionId) > 0 )
         {
            AV21SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV21SessionId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV21SessionId", StringUtil.LTrimStr( (decimal)(AV21SessionId), 4, 0));
         }
         else
         {
            AV21SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV21SessionId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV32WWPFormInstance = cgiGet( sPrefix+"AV32WWPFormInstance_CTRL");
         if ( StringUtil.Len( sCtrlAV32WWPFormInstance) > 0 )
         {
            AV32WWPFormInstance.FromXml(cgiGet( sCtrlAV32WWPFormInstance), null, "", "");
         }
         else
         {
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"AV32WWPFormInstance_PARM"), AV32WWPFormInstance);
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
         PA2E2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2E2( ) ;
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
         WS2E2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV27WWPDynamicFormMode_PARM", StringUtil.RTrim( AV27WWPDynamicFormMode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV27WWPDynamicFormMode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV27WWPDynamicFormMode_CTRL", StringUtil.RTrim( sCtrlAV27WWPDynamicFormMode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV29WWPFormElementId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV29WWPFormElementId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV29WWPFormElementId_CTRL", StringUtil.RTrim( sCtrlAV29WWPFormElementId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV34WWPFormInstanceElementId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV34WWPFormInstanceElementId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV34WWPFormInstanceElementId_CTRL", StringUtil.RTrim( sCtrlAV34WWPFormInstanceElementId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV21SessionId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV21SessionId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV21SessionId_CTRL", StringUtil.RTrim( sCtrlAV21SessionId));
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"AV32WWPFormInstance_PARM", AV32WWPFormInstance);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"AV32WWPFormInstance_PARM", AV32WWPFormInstance);
         }
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV32WWPFormInstance)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV32WWPFormInstance_CTRL", StringUtil.RTrim( sCtrlAV32WWPFormInstance));
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
         WE2E2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256309335271", true, true);
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
         context.AddJavascriptSource("workwithplus/dynamicforms/wwp_df_text_wc.js", "?20256309335271", false, true);
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
         edtavData_Internalname = sPrefix+"vDATA";
         divDatacellname_Internalname = sPrefix+"DATACELLNAME";
         bttBtnfixcontrolvaluechanged_Internalname = sPrefix+"BTNFIXCONTROLVALUECHANGED";
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
         edtavData_Jsonclick = "";
         edtavData_Linktarget = "";
         edtavData_Link = "";
         edtavData_Ispassword = 0;
         edtavData_Enabled = 1;
         edtavData_Caption = context.GetMessage( "Data", "");
         divDatacellname_Class = "col-xs-12 DataContentCell DscTop";
         lblDatatitle_Caption = context.GetMessage( "Title", "");
         divDatatitlecell_Class = "col-xs-12";
         divDatatitlecell_Visible = 1;
         divLayoutmaintable_Class = "Table";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV13HasReferenceId","fld":"vHASREFERENCEID","hsh":true},{"av":"AV26WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA","hsh":true},{"av":"AV35ErrorMessage","fld":"vERRORMESSAGE","hsh":true},{"av":"AV28WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"AV31WWPFormElementTitle","fld":"vWWPFORMELEMENTTITLE","hsh":true}]}""");
         setEventMetadata("'DOFIXCONTROLVALUECHANGED'","""{"handler":"E122E2","iparms":[{"av":"AV36DataControlValueChanged","fld":"vDATACONTROLVALUECHANGED"},{"av":"AV8Data","fld":"vDATA"},{"av":"AV13HasReferenceId","fld":"vHASREFERENCEID","hsh":true},{"av":"AV21SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV32WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV29WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV34WWPFormInstanceElementId","fld":"vWWPFORMINSTANCEELEMENTID","pic":"ZZZ9"},{"av":"AV26WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA","hsh":true},{"av":"AV35ErrorMessage","fld":"vERRORMESSAGE","hsh":true},{"av":"AV28WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"AV31WWPFormElementTitle","fld":"vWWPFORMELEMENTTITLE","hsh":true},{"av":"AV33WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"}]""");
         setEventMetadata("'DOFIXCONTROLVALUECHANGED'",""","oparms":[{"av":"AV36DataControlValueChanged","fld":"vDATACONTROLVALUECHANGED"},{"av":"AV12ExistElement","fld":"vEXISTELEMENT"},{"av":"AV33WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"},{"av":"AV32WWPFormInstance","fld":"vWWPFORMINSTANCE"}]}""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_VALIDATE","""{"handler":"E132E2","iparms":[{"av":"AV39ErrorIds","fld":"vERRORIDS"},{"av":"AV6AuxSessionId","fld":"vAUXSESSIONID","pic":"ZZZ9"},{"av":"AV21SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"divLayoutmaintable_Class","ctrl":"LAYOUTMAINTABLE","prop":"Class"},{"av":"AV29WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV34WWPFormInstanceElementId","fld":"vWWPFORMINSTANCEELEMENTID","pic":"ZZZ9"},{"av":"AV12ExistElement","fld":"vEXISTELEMENT"},{"av":"AV32WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV26WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA","hsh":true},{"av":"AV8Data","fld":"vDATA"},{"av":"AV35ErrorMessage","fld":"vERRORMESSAGE","hsh":true},{"av":"AV28WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"AV31WWPFormElementTitle","fld":"vWWPFORMELEMENTTITLE","hsh":true},{"av":"AV33WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"}]""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_VALIDATE",""","oparms":[{"av":"AV12ExistElement","fld":"vEXISTELEMENT"},{"av":"AV33WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"},{"av":"AV32WWPFormInstance","fld":"vWWPFORMINSTANCE"}]}""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES","""{"handler":"E142E2","iparms":[{"av":"AV6AuxSessionId","fld":"vAUXSESSIONID","pic":"ZZZ9"},{"av":"AV21SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV24VisibleCondition","fld":"vVISIBLECONDITION"},{"av":"AV26WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA","hsh":true},{"av":"AV34WWPFormInstanceElementId","fld":"vWWPFORMINSTANCEELEMENTID","pic":"ZZZ9"},{"av":"AV32WWPFormInstance","fld":"vWWPFORMINSTANCE"}]""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES",""","oparms":[{"av":"AV32WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV24VisibleCondition","fld":"vVISIBLECONDITION"},{"av":"divLayoutmaintable_Class","ctrl":"LAYOUTMAINTABLE","prop":"Class"}]}""");
         setEventMetadata("VDATA.CONTROLVALUECHANGED","""{"handler":"E152E2","iparms":[{"av":"AV8Data","fld":"vDATA"},{"av":"AV13HasReferenceId","fld":"vHASREFERENCEID","hsh":true},{"av":"AV21SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV32WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV29WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV34WWPFormInstanceElementId","fld":"vWWPFORMINSTANCEELEMENTID","pic":"ZZZ9"},{"av":"AV26WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA","hsh":true},{"av":"AV35ErrorMessage","fld":"vERRORMESSAGE","hsh":true},{"av":"AV28WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"AV31WWPFormElementTitle","fld":"vWWPFORMELEMENTTITLE","hsh":true},{"av":"AV33WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"}]""");
         setEventMetadata("VDATA.CONTROLVALUECHANGED",""","oparms":[{"av":"AV36DataControlValueChanged","fld":"vDATACONTROLVALUECHANGED"},{"av":"AV12ExistElement","fld":"vEXISTELEMENT"},{"av":"AV33WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"},{"av":"AV32WWPFormInstance","fld":"vWWPFORMINSTANCE"}]}""");
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
         AV32WWPFormInstance = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         wcpOAV27WWPDynamicFormMode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV26WWP_DF_CharMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata(context);
         AV35ErrorMessage = "";
         AV31WWPFormElementTitle = "";
         AV36DataControlValueChanged = "";
         AV33WWPFormInstanceElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         AV39ErrorIds = "";
         AV24VisibleCondition = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression(context);
         GX_FocusControl = "";
         lblDatatitle_Jsonclick = "";
         TempTags = "";
         AV8Data = "";
         ClassString = "";
         StyleString = "";
         bttBtnfixcontrolvaluechanged_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV40SDT_DynamicFormTranslation = new SdtSDT_DynamicFormTranslation(context);
         AV7CurrentWWPFormInstanceElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         AV30WWPFormElementMetadata = "";
         AV25WebSession = context.GetSession();
         AV18Mask = "";
         GXt_SdtWWP_FormInstance1 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         AV23Validations = new GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation>( context, "WWP_DF_Validation", "Comforta_version2");
         AV22ThisValueStr = "";
         AV11ElementInternalName = "";
         AV20Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV19Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV9DataCellNameClass = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV27WWPDynamicFormMode = "";
         sCtrlAV29WWPFormElementId = "";
         sCtrlAV34WWPFormInstanceElementId = "";
         sCtrlAV21SessionId = "";
         sCtrlAV32WWPFormInstance = "";
         /* GeneXus formulas. */
      }

      private short AV29WWPFormElementId ;
      private short AV34WWPFormInstanceElementId ;
      private short AV21SessionId ;
      private short wcpOAV29WWPFormElementId ;
      private short wcpOAV34WWPFormInstanceElementId ;
      private short wcpOAV21SessionId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV28WWPFormElementDataType ;
      private short AV6AuxSessionId ;
      private short wbEnd ;
      private short wbStart ;
      private short edtavData_Ispassword ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short AV5WWPFormElementCaption ;
      private short AV14i ;
      private short nGXWrapped ;
      private int divDatatitlecell_Visible ;
      private int edtavData_Enabled ;
      private int AV42GXV1 ;
      private int AV43GXV2 ;
      private int AV44GXV3 ;
      private int idxLst ;
      private string AV27WWPDynamicFormMode ;
      private string wcpOAV27WWPDynamicFormMode ;
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
      private string edtavData_Internalname ;
      private string edtavData_Caption ;
      private string TempTags ;
      private string edtavData_Link ;
      private string edtavData_Linktarget ;
      private string edtavData_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnfixcontrolvaluechanged_Internalname ;
      private string bttBtnfixcontrolvaluechanged_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string sCtrlAV27WWPDynamicFormMode ;
      private string sCtrlAV29WWPFormElementId ;
      private string sCtrlAV34WWPFormInstanceElementId ;
      private string sCtrlAV21SessionId ;
      private string sCtrlAV32WWPFormInstance ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13HasReferenceId ;
      private bool AV12ExistElement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV15IsElementFocusable ;
      private bool AV10DataEnabled ;
      private bool AV16IsRequired ;
      private bool AV17IsValid ;
      private string AV31WWPFormElementTitle ;
      private string AV30WWPFormElementMetadata ;
      private string AV35ErrorMessage ;
      private string AV36DataControlValueChanged ;
      private string AV39ErrorIds ;
      private string AV8Data ;
      private string AV18Mask ;
      private string AV22ThisValueStr ;
      private string AV11ElementInternalName ;
      private string AV9DataCellNameClass ;
      private IGxSession AV25WebSession ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV32WWPFormInstance ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP4_WWPFormInstance ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata AV26WWP_DF_CharMetadata ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element AV33WWPFormInstanceElement ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression AV24VisibleCondition ;
      private SdtSDT_DynamicFormTranslation AV40SDT_DynamicFormTranslation ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element AV7CurrentWWPFormInstanceElement ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance GXt_SdtWWP_FormInstance1 ;
      private GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation> AV23Validations ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV20Messages ;
      private GeneXus.Utils.SdtMessages_Message AV19Message ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
