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
   public class wwp_df_file_wc : GXWebComponent
   {
      public wwp_df_file_wc( )
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

      public wwp_df_file_wc( IGxContext context )
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
         this.AV31WWPDynamicFormMode = aP0_WWPDynamicFormMode;
         this.AV33WWPFormElementId = aP1_WWPFormElementId;
         this.AV38WWPFormInstanceElementId = aP2_WWPFormInstanceElementId;
         this.AV22SessionId = aP3_SessionId;
         this.AV36WWPFormInstance = aP4_WWPFormInstance;
         ExecuteImpl();
         aP4_WWPFormInstance=this.AV36WWPFormInstance;
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
                  AV31WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
                  AssignAttri(sPrefix, false, "AV31WWPDynamicFormMode", AV31WWPDynamicFormMode);
                  AV33WWPFormElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV33WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV33WWPFormElementId), 4, 0));
                  AV38WWPFormInstanceElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormInstanceElementId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV38WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV38WWPFormInstanceElementId), 4, 0));
                  AV22SessionId = (short)(Math.Round(NumberUtil.Val( GetPar( "SessionId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV22SessionId", StringUtil.LTrimStr( (decimal)(AV22SessionId), 4, 0));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV36WWPFormInstance);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV31WWPDynamicFormMode,(short)AV33WWPFormElementId,(short)AV38WWPFormInstanceElementId,(short)AV22SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV36WWPFormInstance});
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
            PA2R2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavFilereadonly_Enabled = 0;
               AssignProp(sPrefix, false, edtavFilereadonly_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFilereadonly_Enabled), 5, 0), true);
               WS2R2( ) ;
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
            context.SendWebValue( context.GetMessage( "WWP_Dynamic Form_File_WC", "")) ;
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
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
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
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_df_file_wc.aspx"+UrlEncode(StringUtil.RTrim(AV31WWPDynamicFormMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV33WWPFormElementId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV38WWPFormInstanceElementId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV22SessionId,4,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.dynamicforms.wwp_df_file_wc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_IMAGEMETADATA", AV30WWP_DF_ImageMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_IMAGEMETADATA", AV30WWP_DF_ImageMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_IMAGEMETADATA", GetSecureSignedToken( sPrefix, AV30WWP_DF_ImageMetadata, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTTITLE", AV35WWPFormElementTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTTITLE", GetSecureSignedToken( sPrefix, AV35WWPFormElementTitle, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vELEMENTINTERNALNAME", AV12ElementInternalName);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vELEMENTINTERNALNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV12ElementInternalName, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASREFERENCEID", AV16HasReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV16HasReferenceId, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vUPLOADEDFILES", AV26UploadedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vUPLOADEDFILES", AV26UploadedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFAILEDFILES", AV39FailedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFAILEDFILES", AV39FailedFiles);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV31WWPDynamicFormMode", StringUtil.RTrim( wcpOAV31WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV33WWPFormElementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV33WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV38WWPFormInstanceElementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV38WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV22SessionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV22SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV31WWPDynamicFormMode));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORMINSTANCE", AV36WWPFormInstance);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORMINSTANCE", AV36WWPFormInstance);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMINSTANCEELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORMINSTANCEELEMENT", AV37WWPFormInstanceElement);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORMINSTANCEELEMENT", AV37WWPFormInstanceElement);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDATAEXTENSION", AV10DataExtension);
         GxWebStd.gx_hidden_field( context, sPrefix+"vDATAFILENAME", AV11DataFileName);
         GxWebStd.gx_hidden_field( context, sPrefix+"vERRORIDS", AV43ErrorIds);
         GxWebStd.gx_hidden_field( context, sPrefix+"vAUXSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5AuxSessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vEXISTELEMENT", AV13ExistElement);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_IMAGEMETADATA", AV30WWP_DF_ImageMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_IMAGEMETADATA", AV30WWP_DF_ImageMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_IMAGEMETADATA", GetSecureSignedToken( sPrefix, AV30WWP_DF_ImageMetadata, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTTITLE", AV35WWPFormElementTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTTITLE", GetSecureSignedToken( sPrefix, AV35WWPFormElementTitle, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vELEMENTINTERNALNAME", AV12ElementInternalName);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vELEMENTINTERNALNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV12ElementInternalName, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vVISIBLECONDITION", AV28VisibleCondition);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vVISIBLECONDITION", AV28VisibleCondition);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASREFERENCEID", AV16HasReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV16HasReferenceId, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"LAYOUTMAINTABLE_Class", StringUtil.RTrim( divLayoutmaintable_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"LAYOUTMAINTABLE_Class", StringUtil.RTrim( divLayoutmaintable_Class));
      }

      protected void RenderHtmlCloseForm2R2( )
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
         return "WorkWithPlus.DynamicForms.WWP_DF_File_WC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WWP_Dynamic Form_File_WC", "") ;
      }

      protected void WB2R0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "workwithplus.dynamicforms.wwp_df_file_wc.aspx");
               context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
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
            GxWebStd.gx_label_ctrl( context, lblDatatitle_Internalname, lblDatatitle_Caption, "", "", lblDatatitle_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DF_File_WC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDatacellname_Internalname, 1, 0, "px", 0, "px", divDatacellname_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavFilereadonly_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFilereadonly_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilereadonly_Internalname, " ", " AttributeDynamicFormFileLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            ClassString = "AttributeDynamicFormFile";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
            edtavFilereadonly_Filetype = "tmp";
            AssignProp(sPrefix, false, edtavFilereadonly_Internalname, "Filetype", edtavFilereadonly_Filetype, true);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14FileReadonly)) )
            {
               gxblobfileaux.Source = AV14FileReadonly;
               if ( ! gxblobfileaux.HasExtension() || ( StringUtil.StrCmp(edtavFilereadonly_Filetype, "tmp") != 0 ) )
               {
                  gxblobfileaux.SetExtension(StringUtil.Trim( edtavFilereadonly_Filetype));
               }
               if ( gxblobfileaux.ErrCode == 0 )
               {
                  AV14FileReadonly = gxblobfileaux.GetURI();
                  AssignProp(sPrefix, false, edtavFilereadonly_Internalname, "URL", context.PathToRelativeUrl( AV14FileReadonly), true);
                  edtavFilereadonly_Filetype = gxblobfileaux.GetExtension();
                  AssignProp(sPrefix, false, edtavFilereadonly_Internalname, "Filetype", edtavFilereadonly_Filetype, true);
               }
               AssignProp(sPrefix, false, edtavFilereadonly_Internalname, "URL", context.PathToRelativeUrl( AV14FileReadonly), true);
            }
            GxWebStd.gx_blob_field( context, edtavFilereadonly_Internalname, StringUtil.RTrim( AV14FileReadonly), context.PathToRelativeUrl( AV14FileReadonly), (String.IsNullOrEmpty(StringUtil.RTrim( edtavFilereadonly_Contenttype)) ? context.GetContentType( (String.IsNullOrEmpty(StringUtil.RTrim( edtavFilereadonly_Filetype)) ? AV14FileReadonly : edtavFilereadonly_Filetype)) : edtavFilereadonly_Contenttype), false, edtavFilereadonly_Linktarget, edtavFilereadonly_Parameters, edtavFilereadonly_Display, edtavFilereadonly_Enabled, edtavFilereadonly_Visible, "", "", 0, -1, 250, "px", 60, "px", 0, 0, 0, edtavFilereadonly_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", StyleString, ClassString, "", "", ""+TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,14);\"", "", "", "HLP_WorkWithPlus/DynamicForms/WWP_DF_File_WC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUcfilecell_Internalname, 1, 0, "px", 0, "px", divUcfilecell_Class, "start", "top", "", "", "div");
            wb_table1_17_2R2( true) ;
         }
         else
         {
            wb_table1_17_2R2( false) ;
         }
         return  ;
      }

      protected void wb_table1_17_2R2e( bool wbgen )
      {
         if ( wbgen )
         {
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
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavFilereadonlyaux_Internalname, AV15FileReadonlyAux, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", 0, edtavFilereadonlyaux_Visible, 1, 0, 80, "chr", 5, "row", 0, StyleString, ClassString, "", "", "400", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WorkWithPlus/DynamicForms/WWP_DF_File_WC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START2R2( )
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
            Form.Meta.addItem("description", context.GetMessage( "WWP_Dynamic Form_File_WC", ""), 0) ;
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
               STRUP2R0( ) ;
            }
         }
      }

      protected void WS2R2( )
      {
         START2R2( ) ;
         EVT2R2( ) ;
      }

      protected void EVT2R2( )
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
                                 STRUP2R0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "UCFILE.UPLOADCOMPLETE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2R0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ucfile.Uploadcomplete */
                                    E112R2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2R0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E122R2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2R0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E132R2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOREMOVEFILE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2R0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoRemoveFile' */
                                    E142R2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.DYNAMICFORM_VALIDATE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2R0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E152R2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2R0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E162R2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2R0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E172R2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2R0( ) ;
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
                                 STRUP2R0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavFilereadonly_Internalname;
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

      protected void WE2R2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2R2( ) ;
            }
         }
      }

      protected void PA2R2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.dynamicforms.wwp_df_file_wc.aspx")), "workwithplus.dynamicforms.wwp_df_file_wc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.dynamicforms.wwp_df_file_wc.aspx")))) ;
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
               GX_FocusControl = edtavFilereadonly_Internalname;
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
         RF2R2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavFilereadonly_Enabled = 0;
         AssignProp(sPrefix, false, edtavFilereadonly_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFilereadonly_Enabled), 5, 0), true);
      }

      protected void RF2R2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E132R2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E172R2 ();
            WB2R0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2R2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_IMAGEMETADATA", AV30WWP_DF_ImageMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_IMAGEMETADATA", AV30WWP_DF_ImageMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_IMAGEMETADATA", GetSecureSignedToken( sPrefix, AV30WWP_DF_ImageMetadata, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTTITLE", AV35WWPFormElementTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTTITLE", GetSecureSignedToken( sPrefix, AV35WWPFormElementTitle, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vELEMENTINTERNALNAME", AV12ElementInternalName);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vELEMENTINTERNALNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV12ElementInternalName, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASREFERENCEID", AV16HasReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV16HasReferenceId, context));
      }

      protected void before_start_formulas( )
      {
         edtavFilereadonly_Enabled = 0;
         AssignProp(sPrefix, false, edtavFilereadonly_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFilereadonly_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E122R2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vUPLOADEDFILES"), AV26UploadedFiles);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFAILEDFILES"), AV39FailedFiles);
            /* Read saved values. */
            wcpOAV31WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV31WWPDynamicFormMode");
            wcpOAV33WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV33WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV38WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV38WWPFormInstanceElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV22SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV22SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            divLayoutmaintable_Class = cgiGet( sPrefix+"LAYOUTMAINTABLE_Class");
            /* Read variables values. */
            AV14FileReadonly = cgiGet( edtavFilereadonly_Internalname);
            AV15FileReadonlyAux = cgiGet( edtavFilereadonlyaux_Internalname);
            AssignAttri(sPrefix, false, "AV15FileReadonlyAux", AV15FileReadonlyAux);
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
         E122R2 ();
         if (returnInSub) return;
      }

      protected void E122R2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV44SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformid = AV36WWPFormInstance.gxTpr_Wwpformid;
         AV44SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformversionnumber = AV36WWPFormInstance.gxTpr_Wwpformversionnumber;
         AV44SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformelementid = AV33WWPFormElementId;
         new prc_getdynamicformtranslation(context ).execute( ref  AV44SDT_DynamicFormTranslation) ;
         AV17IsElementFocusable = true;
         AV16HasReferenceId = false;
         AssignAttri(sPrefix, false, "AV16HasReferenceId", AV16HasReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV16HasReferenceId, context));
         AV45GXV1 = 1;
         while ( AV45GXV1 <= AV36WWPFormInstance.gxTpr_Element.Count )
         {
            AV37WWPFormInstanceElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV36WWPFormInstance.gxTpr_Element.Item(AV45GXV1));
            if ( ( AV37WWPFormInstanceElement.gxTpr_Wwpformelementid == AV33WWPFormElementId ) && ( AV37WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid == AV38WWPFormInstanceElementId ) )
            {
               AV6CurrentWWPFormInstanceElement = AV37WWPFormInstanceElement;
               AV16HasReferenceId = (bool)((!String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV37WWPFormInstanceElement.gxTpr_Wwpformelementreferenceid)))));
               AssignAttri(sPrefix, false, "AV16HasReferenceId", AV16HasReferenceId);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV16HasReferenceId, context));
               AV35WWPFormElementTitle = AV37WWPFormInstanceElement.gxTpr_Wwpformelementtitle;
               AssignAttri(sPrefix, false, "AV35WWPFormElementTitle", AV35WWPFormElementTitle);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTTITLE", GetSecureSignedToken( sPrefix, AV35WWPFormElementTitle, context));
               AV34WWPFormElementMetadata = AV37WWPFormInstanceElement.gxTpr_Wwpformelementmetadata;
               AssignAttri(sPrefix, false, "AV34WWPFormElementMetadata", AV34WWPFormElementMetadata);
               AV32WWPFormElementCaption = AV37WWPFormInstanceElement.gxTpr_Wwpformelementcaption;
               if (true) break;
            }
            AV45GXV1 = (int)(AV45GXV1+1);
         }
         /* Execute user subroutine: 'LOAD TITLE AND METADATA' */
         S202 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GET DATA FROM CURRENT ELEMENT' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UPDATE VISIBILITY' */
         S122 ();
         if (returnInSub) return;
         if ( AV17IsElementFocusable && ( StringUtil.StrCmp(divLayoutmaintable_Class, "Table") == 0 ) && ( StringUtil.StrCmp(AV29WebSession.Get("WWPDynFormSetFocus"), "") != 0 ) )
         {
            /* Execute user subroutine: 'SET FOCUS TO ELEMENT' */
            S132 ();
            if (returnInSub) return;
            AV29WebSession.Remove("WWPDynFormSetFocus");
         }
         if ( ( StringUtil.StrCmp(AV31WWPDynamicFormMode, "DSP") != 0 ) && ( StringUtil.StrCmp(AV31WWPDynamicFormMode, "DLT") != 0 ) )
         {
            AV9DataEnabled = true;
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S142 ();
         if (returnInSub) return;
         edtavFilereadonlyaux_Visible = 0;
         AssignProp(sPrefix, false, edtavFilereadonlyaux_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFilereadonlyaux_Visible), 5, 0), true);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationvalue)) )
         {
            lblDatatitle_Caption = AV35WWPFormElementTitle;
            AssignProp(sPrefix, false, lblDatatitle_Internalname, "Caption", lblDatatitle_Caption, true);
         }
         else
         {
            lblDatatitle_Caption = AV44SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationvalue;
            AssignProp(sPrefix, false, lblDatatitle_Internalname, "Caption", lblDatatitle_Caption, true);
         }
         divDatatitlecell_Visible = 1;
         AssignProp(sPrefix, false, divDatatitlecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDatatitlecell_Visible), 5, 0), true);
      }

      protected void E132R2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E142R2( )
      {
         /* 'DoRemoveFile' Routine */
         returnInSub = false;
         AV14FileReadonly = "";
         AssignProp(sPrefix, false, edtavFilereadonly_Internalname, "URL", context.PathToRelativeUrl( AV14FileReadonly), true);
         AV26UploadedFiles.Clear();
         AV15FileReadonlyAux = "";
         AssignAttri(sPrefix, false, "AV15FileReadonlyAux", AV15FileReadonlyAux);
         /* Execute user subroutine: 'SAVE ELEMENT DATA TO SESSION' */
         S162 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV26UploadedFiles", AV26UploadedFiles);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV37WWPFormInstanceElement", AV37WWPFormInstanceElement);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV36WWPFormInstance", AV36WWPFormInstance);
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV14FileReadonly, "") != 0 ) && ( AV26UploadedFiles.Count == 0 ) && ( ( StringUtil.StrCmp(AV31WWPDynamicFormMode, "UPD") == 0 ) || ( StringUtil.StrCmp(AV31WWPDynamicFormMode, "INS") == 0 ) ) ) )
         {
            Btnremovefile_Visible = false;
            ucBtnremovefile.SendProperty(context, sPrefix, false, Btnremovefile_Internalname, "Visible", StringUtil.BoolToStr( Btnremovefile_Visible));
         }
         if ( ( ( StringUtil.StrCmp(AV14FileReadonly, "") != 0 ) && ( ( StringUtil.StrCmp(AV31WWPDynamicFormMode, "UPD") == 0 ) || ( StringUtil.StrCmp(AV31WWPDynamicFormMode, "INS") == 0 ) ) ) || ( StringUtil.StrCmp(AV31WWPDynamicFormMode, "DLT") == 0 ) || ( StringUtil.StrCmp(AV31WWPDynamicFormMode, "DSP") == 0 ) )
         {
            divUcfilecell_Class = "Invisible";
            AssignProp(sPrefix, false, divUcfilecell_Internalname, "Class", divUcfilecell_Class, true);
         }
         else
         {
            divUcfilecell_Class = "";
            AssignProp(sPrefix, false, divUcfilecell_Internalname, "Class", divUcfilecell_Class, true);
         }
      }

      protected void S142( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV14FileReadonly, "") != 0 ) && ( AV26UploadedFiles.Count == 0 ) ) )
         {
            edtavFilereadonly_Visible = 0;
            AssignProp(sPrefix, false, edtavFilereadonly_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFilereadonly_Visible), 5, 0), true);
            divDatacellname_Class = "Invisible";
            AssignProp(sPrefix, false, divDatacellname_Internalname, "Class", divDatacellname_Class, true);
         }
         else
         {
            edtavFilereadonly_Visible = 1;
            AssignProp(sPrefix, false, edtavFilereadonly_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFilereadonly_Visible), 5, 0), true);
            divDatacellname_Class = "col-xs-12 DataContentCell CellDynamicFormImage DscTop";
            AssignProp(sPrefix, false, divDatacellname_Internalname, "Class", divDatacellname_Class, true);
         }
      }

      protected void E152R2( )
      {
         /* General\GlobalEvents_Dynamicform_validate Routine */
         returnInSub = false;
         if ( ( AV5AuxSessionId == AV22SessionId ) && ( StringUtil.StrCmp(divLayoutmaintable_Class, "Invisible") != 0 ) && StringUtil.Contains( AV43ErrorIds, "|"+StringUtil.Trim( StringUtil.Str( (decimal)(AV33WWPFormElementId), 4, 0))+"."+StringUtil.Trim( StringUtil.Str( (decimal)(AV38WWPFormInstanceElementId), 4, 0))+"|") )
         {
            /* Execute user subroutine: 'SAVE ELEMENT DATA TO SESSION' */
            S162 ();
            if (returnInSub) return;
            if ( AV13ExistElement )
            {
               /* Execute user subroutine: 'EXECUTE VALIDATIONS' */
               S172 ();
               if (returnInSub) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV37WWPFormInstanceElement", AV37WWPFormInstanceElement);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV36WWPFormInstance", AV36WWPFormInstance);
      }

      protected void E162R2( )
      {
         /* General\GlobalEvents_Dynamicform_updatevisibilities Routine */
         returnInSub = false;
         if ( ( AV5AuxSessionId == AV22SessionId ) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV28VisibleCondition.gxTpr_Expression))) )
         {
            /* Execute user subroutine: 'GET FORM INSTANCE' */
            S182 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'UPDATE VISIBILITY' */
            S122 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV36WWPFormInstance", AV36WWPFormInstance);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV28VisibleCondition", AV28VisibleCondition);
      }

      protected void S182( )
      {
         /* 'GET FORM INSTANCE' Routine */
         returnInSub = false;
         GXt_SdtWWP_FormInstance1 = AV36WWPFormInstance;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadforminstance(context ).execute(  AV22SessionId, out  GXt_SdtWWP_FormInstance1) ;
         AV36WWPFormInstance = GXt_SdtWWP_FormInstance1;
      }

      protected void S112( )
      {
         /* 'GET DATA FROM CURRENT ELEMENT' Routine */
         returnInSub = false;
         AV14FileReadonly = AV6CurrentWWPFormInstanceElement.gxTpr_Wwpforminstanceelemblob;
         AssignProp(sPrefix, false, edtavFilereadonly_Internalname, "URL", context.PathToRelativeUrl( AV14FileReadonly), true);
         edtavFilereadonly_Display = 1;
         edtavFilereadonly_Linktarget = "_blank";
         AssignProp(sPrefix, false, edtavFilereadonly_Internalname, "Linktarget", edtavFilereadonly_Linktarget, true);
      }

      protected void S162( )
      {
         /* 'SAVE ELEMENT DATA TO SESSION' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GET FORM INSTANCE' */
         S182 ();
         if (returnInSub) return;
         AV13ExistElement = false;
         AssignAttri(sPrefix, false, "AV13ExistElement", AV13ExistElement);
         AV46GXV2 = 1;
         while ( AV46GXV2 <= AV36WWPFormInstance.gxTpr_Element.Count )
         {
            AV37WWPFormInstanceElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV36WWPFormInstance.gxTpr_Element.Item(AV46GXV2));
            if ( ( AV37WWPFormInstanceElement.gxTpr_Wwpformelementid == AV33WWPFormElementId ) && ( AV37WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid == AV38WWPFormInstanceElementId ) )
            {
               AV13ExistElement = true;
               AssignAttri(sPrefix, false, "AV13ExistElement", AV13ExistElement);
               if (true) break;
            }
            AV46GXV2 = (int)(AV46GXV2+1);
         }
         if ( AV13ExistElement )
         {
            /* Execute user subroutine: 'SET DATA TO ELEMENT' */
            S192 ();
            if (returnInSub) return;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_saveforminstance(context ).execute(  AV22SessionId,  AV36WWPFormInstance) ;
         }
      }

      protected void S192( )
      {
         /* 'SET DATA TO ELEMENT' Routine */
         returnInSub = false;
         AV24UpdateFile = true;
         if ( AV26UploadedFiles.Count > 0 )
         {
            AV25UploadedFile = ((SdtFileUploadData)AV26UploadedFiles.Item(1));
            AV7Data = AV25UploadedFile.gxTpr_File;
            AV10DataExtension = AV25UploadedFile.gxTpr_Extension;
            AssignAttri(sPrefix, false, "AV10DataExtension", AV10DataExtension);
            AV11DataFileName = AV25UploadedFile.gxTpr_Name;
            AssignAttri(sPrefix, false, "AV11DataFileName", AV11DataFileName);
         }
         else
         {
            if ( ( StringUtil.StrCmp(AV31WWPDynamicFormMode, "UPD") == 0 ) && ( StringUtil.StrCmp(AV15FileReadonlyAux, "") != 0 ) )
            {
               AV24UpdateFile = false;
            }
            AV7Data = "";
         }
         if ( AV24UpdateFile )
         {
            AV37WWPFormInstanceElement.gxTpr_Wwpforminstanceelemblob = AV7Data;
            AV37WWPFormInstanceElement.gxTpr_Wwpforminstanceelemblobfiletype = AV10DataExtension;
            AV37WWPFormInstanceElement.gxTpr_Wwpforminstanceelemblobfilename = AV11DataFileName;
         }
      }

      protected void S122( )
      {
         /* 'UPDATE VISIBILITY' Routine */
         returnInSub = false;
         AV28VisibleCondition = AV30WWP_DF_ImageMetadata.gxTpr_Visiblecondition;
         if ( new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_evaluateelementvisibility(context).executeUdp(  AV36WWPFormInstance,  AV38WWPFormInstanceElementId,  AV28VisibleCondition) )
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

      protected void S172( )
      {
         /* 'EXECUTE VALIDATIONS' Routine */
         returnInSub = false;
         AV18IsRequired = AV30WWP_DF_ImageMetadata.gxTpr_Isrequired;
         AV27Validations = AV30WWP_DF_ImageMetadata.gxTpr_Validations;
         AV23ThisValueStr = StringUtil.Format( "'%1'", (!String.IsNullOrEmpty(StringUtil.RTrim( AV37WWPFormInstanceElement.gxTpr_Wwpforminstanceelemblob)) ? "FILE_VALUE" : ""), "", "", "", "", "", "", "", "");
         AV19IsValid = true;
         if ( AV18IsRequired && ( StringUtil.StrCmp(StringUtil.Trim( AV23ThisValueStr), "''") == 0 ) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), AV35WWPFormElementTitle, "", "", "", "", "", "", "", ""),  "error",  AV12ElementInternalName,  "true",  ""));
            AV19IsValid = false;
         }
         else
         {
            if ( AV27Validations.Count > 0 )
            {
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_executeelementvalidations(context ).execute(  AV36WWPFormInstance,  AV38WWPFormInstanceElementId,  AV23ThisValueStr,  AV27Validations, out  AV21Messages) ;
               AV47GXV3 = 1;
               while ( AV47GXV3 <= AV21Messages.Count )
               {
                  AV20Message = ((GeneXus.Utils.SdtMessages_Message)AV21Messages.Item(AV47GXV3));
                  GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV20Message.gxTpr_Description,  ((AV20Message.gxTpr_Type==1) ? "error" : "info"),  AV12ElementInternalName,  "true",  ""));
                  if ( AV20Message.gxTpr_Type == 1 )
                  {
                     AV19IsValid = false;
                     if (true) break;
                  }
                  AV47GXV3 = (int)(AV47GXV3+1);
               }
            }
         }
      }

      protected void S202( )
      {
         /* 'LOAD TITLE AND METADATA' Routine */
         returnInSub = false;
         AV32WWPFormElementCaption = 0;
         if ( AV32WWPFormElementCaption == 2 )
         {
            lblDatatitle_Caption = AV35WWPFormElementTitle;
            AssignProp(sPrefix, false, lblDatatitle_Internalname, "Caption", lblDatatitle_Caption, true);
            divDatatitlecell_Visible = 1;
            AssignProp(sPrefix, false, divDatatitlecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDatatitlecell_Visible), 5, 0), true);
         }
         else
         {
            divDatatitlecell_Visible = 0;
            AssignProp(sPrefix, false, divDatatitlecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDatatitlecell_Visible), 5, 0), true);
         }
         AV8DataCellNameClass = "DataContentCell DscTop";
         if ( AV32WWPFormElementCaption != 1 )
         {
            AV8DataCellNameClass += " DataContentCellNoLabel";
         }
         AV8DataCellNameClass += " CellDynamicFormImage";
         AV30WWP_DF_ImageMetadata.FromJSonString(AV34WWPFormElementMetadata, null);
         if ( AV30WWP_DF_ImageMetadata.gxTpr_Isrequired )
         {
            AV8DataCellNameClass = "Required" + AV8DataCellNameClass;
         }
         divDatacellname_Class = AV8DataCellNameClass;
         AssignProp(sPrefix, false, divDatacellname_Internalname, "Class", divDatacellname_Class, true);
         divDatatitlecell_Class = AV8DataCellNameClass;
         AssignProp(sPrefix, false, divDatatitlecell_Internalname, "Class", divDatatitlecell_Class, true);
         divDatatitlecell_Visible = 0;
         AssignProp(sPrefix, false, divDatatitlecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDatatitlecell_Visible), 5, 0), true);
      }

      protected void S132( )
      {
         /* 'SET FOCUS TO ELEMENT' Routine */
         returnInSub = false;
         GX_FocusControl = edtavFilereadonly_Internalname;
         AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         context.DoAjaxSetFocus(GX_FocusControl);
      }

      protected void E112R2( )
      {
         /* Ucfile_Uploadcomplete Routine */
         returnInSub = false;
         if ( AV26UploadedFiles.Count > 0 )
         {
            /* Execute user subroutine: 'SAVE ELEMENT DATA TO SESSION' */
            S162 ();
            if (returnInSub) return;
            if ( AV16HasReferenceId )
            {
               this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "DynamicForm_UpdateVisibilities", new Object[] {(short)AV22SessionId}, true);
            }
            /* Execute user subroutine: 'EXECUTE VALIDATIONS' */
            S172 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV37WWPFormInstanceElement", AV37WWPFormInstanceElement);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV36WWPFormInstance", AV36WWPFormInstance);
      }

      protected void nextLoad( )
      {
      }

      protected void E172R2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_17_2R2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeducfile_Internalname, tblTablemergeducfile_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* User Defined Control */
            ucUcfile.SetProperty("Class", Ucfile_Class);
            ucUcfile.SetProperty("AutoUpload", Ucfile_Autoupload);
            ucUcfile.SetProperty("HideAdditionalButtons", Ucfile_Hideadditionalbuttons);
            ucUcfile.SetProperty("TooltipText", Ucfile_Tooltiptext);
            ucUcfile.SetProperty("EnableUploadedFileCanceling", Ucfile_Enableuploadedfilecanceling);
            ucUcfile.SetProperty("MaxNumberOfFiles", Ucfile_Maxnumberoffiles);
            ucUcfile.SetProperty("AutoDisableAddingFiles", Ucfile_Autodisableaddingfiles);
            ucUcfile.SetProperty("AcceptedFileTypes", Ucfile_Acceptedfiletypes);
            ucUcfile.SetProperty("UploadedFiles", AV26UploadedFiles);
            ucUcfile.SetProperty("FailedFiles", AV39FailedFiles);
            ucUcfile.Render(context, "fileupload", Ucfile_Internalname, sPrefix+"UCFILEContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucBtnremovefile.SetProperty("TooltipText", Btnremovefile_Tooltiptext);
            ucBtnremovefile.SetProperty("BeforeIconClass", Btnremovefile_Beforeiconclass);
            ucBtnremovefile.SetProperty("Caption", Btnremovefile_Caption);
            ucBtnremovefile.SetProperty("Class", Btnremovefile_Class);
            ucBtnremovefile.Render(context, "wwp_iconbutton", Btnremovefile_Internalname, sPrefix+"BTNREMOVEFILEContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_17_2R2e( true) ;
         }
         else
         {
            wb_table1_17_2R2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV31WWPDynamicFormMode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV31WWPDynamicFormMode", AV31WWPDynamicFormMode);
         AV33WWPFormElementId = Convert.ToInt16(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV33WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV33WWPFormElementId), 4, 0));
         AV38WWPFormInstanceElementId = Convert.ToInt16(getParm(obj,2));
         AssignAttri(sPrefix, false, "AV38WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV38WWPFormInstanceElementId), 4, 0));
         AV22SessionId = Convert.ToInt16(getParm(obj,3));
         AssignAttri(sPrefix, false, "AV22SessionId", StringUtil.LTrimStr( (decimal)(AV22SessionId), 4, 0));
         AV36WWPFormInstance = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)getParm(obj,4);
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
         PA2R2( ) ;
         WS2R2( ) ;
         WE2R2( ) ;
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
         sCtrlAV31WWPDynamicFormMode = (string)((string)getParm(obj,0));
         sCtrlAV33WWPFormElementId = (string)((string)getParm(obj,1));
         sCtrlAV38WWPFormInstanceElementId = (string)((string)getParm(obj,2));
         sCtrlAV22SessionId = (string)((string)getParm(obj,3));
         sCtrlAV36WWPFormInstance = (string)((string)getParm(obj,4));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2R2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "workwithplus\\dynamicforms\\wwp_df_file_wc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2R2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV31WWPDynamicFormMode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV31WWPDynamicFormMode", AV31WWPDynamicFormMode);
            AV33WWPFormElementId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV33WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV33WWPFormElementId), 4, 0));
            AV38WWPFormInstanceElementId = Convert.ToInt16(getParm(obj,4));
            AssignAttri(sPrefix, false, "AV38WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV38WWPFormInstanceElementId), 4, 0));
            AV22SessionId = Convert.ToInt16(getParm(obj,5));
            AssignAttri(sPrefix, false, "AV22SessionId", StringUtil.LTrimStr( (decimal)(AV22SessionId), 4, 0));
            AV36WWPFormInstance = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)getParm(obj,6);
         }
         wcpOAV31WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV31WWPDynamicFormMode");
         wcpOAV33WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV33WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV38WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV38WWPFormInstanceElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV22SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV22SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV31WWPDynamicFormMode, wcpOAV31WWPDynamicFormMode) != 0 ) || ( AV33WWPFormElementId != wcpOAV33WWPFormElementId ) || ( AV38WWPFormInstanceElementId != wcpOAV38WWPFormInstanceElementId ) || ( AV22SessionId != wcpOAV22SessionId ) ) )
         {
            setjustcreated();
         }
         wcpOAV31WWPDynamicFormMode = AV31WWPDynamicFormMode;
         wcpOAV33WWPFormElementId = AV33WWPFormElementId;
         wcpOAV38WWPFormInstanceElementId = AV38WWPFormInstanceElementId;
         wcpOAV22SessionId = AV22SessionId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV31WWPDynamicFormMode = cgiGet( sPrefix+"AV31WWPDynamicFormMode_CTRL");
         if ( StringUtil.Len( sCtrlAV31WWPDynamicFormMode) > 0 )
         {
            AV31WWPDynamicFormMode = cgiGet( sCtrlAV31WWPDynamicFormMode);
            AssignAttri(sPrefix, false, "AV31WWPDynamicFormMode", AV31WWPDynamicFormMode);
         }
         else
         {
            AV31WWPDynamicFormMode = cgiGet( sPrefix+"AV31WWPDynamicFormMode_PARM");
         }
         sCtrlAV33WWPFormElementId = cgiGet( sPrefix+"AV33WWPFormElementId_CTRL");
         if ( StringUtil.Len( sCtrlAV33WWPFormElementId) > 0 )
         {
            AV33WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV33WWPFormElementId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV33WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV33WWPFormElementId), 4, 0));
         }
         else
         {
            AV33WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV33WWPFormElementId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV38WWPFormInstanceElementId = cgiGet( sPrefix+"AV38WWPFormInstanceElementId_CTRL");
         if ( StringUtil.Len( sCtrlAV38WWPFormInstanceElementId) > 0 )
         {
            AV38WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV38WWPFormInstanceElementId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV38WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV38WWPFormInstanceElementId), 4, 0));
         }
         else
         {
            AV38WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV38WWPFormInstanceElementId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV22SessionId = cgiGet( sPrefix+"AV22SessionId_CTRL");
         if ( StringUtil.Len( sCtrlAV22SessionId) > 0 )
         {
            AV22SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV22SessionId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV22SessionId", StringUtil.LTrimStr( (decimal)(AV22SessionId), 4, 0));
         }
         else
         {
            AV22SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV22SessionId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV36WWPFormInstance = cgiGet( sPrefix+"AV36WWPFormInstance_CTRL");
         if ( StringUtil.Len( sCtrlAV36WWPFormInstance) > 0 )
         {
            AV36WWPFormInstance.FromXml(cgiGet( sCtrlAV36WWPFormInstance), null, "", "");
         }
         else
         {
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"AV36WWPFormInstance_PARM"), AV36WWPFormInstance);
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
         PA2R2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2R2( ) ;
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
         WS2R2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV31WWPDynamicFormMode_PARM", StringUtil.RTrim( AV31WWPDynamicFormMode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV31WWPDynamicFormMode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV31WWPDynamicFormMode_CTRL", StringUtil.RTrim( sCtrlAV31WWPDynamicFormMode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV33WWPFormElementId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV33WWPFormElementId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV33WWPFormElementId_CTRL", StringUtil.RTrim( sCtrlAV33WWPFormElementId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV38WWPFormInstanceElementId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV38WWPFormInstanceElementId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV38WWPFormInstanceElementId_CTRL", StringUtil.RTrim( sCtrlAV38WWPFormInstanceElementId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV22SessionId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV22SessionId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV22SessionId_CTRL", StringUtil.RTrim( sCtrlAV22SessionId));
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"AV36WWPFormInstance_PARM", AV36WWPFormInstance);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"AV36WWPFormInstance_PARM", AV36WWPFormInstance);
         }
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV36WWPFormInstance)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV36WWPFormInstance_CTRL", StringUtil.RTrim( sCtrlAV36WWPFormInstance));
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
         WE2R2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256309334284", true, true);
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
         context.AddJavascriptSource("workwithplus/dynamicforms/wwp_df_file_wc.js", "?20256309334285", false, true);
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
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
         edtavFilereadonly_Internalname = sPrefix+"vFILEREADONLY";
         divDatacellname_Internalname = sPrefix+"DATACELLNAME";
         Ucfile_Internalname = sPrefix+"UCFILE";
         Btnremovefile_Internalname = sPrefix+"BTNREMOVEFILE";
         tblTablemergeducfile_Internalname = sPrefix+"TABLEMERGEDUCFILE";
         divUcfilecell_Internalname = sPrefix+"UCFILECELL";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavFilereadonlyaux_Internalname = sPrefix+"vFILEREADONLYAUX";
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
         Btnremovefile_Class = "ButtonDynamicFormRemove";
         Btnremovefile_Caption = context.GetMessage( "Remove", "");
         Btnremovefile_Beforeiconclass = "fas fa-trash-can DynamicFormRemoveImage";
         Btnremovefile_Tooltiptext = "";
         Ucfile_Acceptedfiletypes = "any";
         Ucfile_Autodisableaddingfiles = Convert.ToBoolean( -1);
         Ucfile_Maxnumberoffiles = 1;
         Ucfile_Enableuploadedfilecanceling = Convert.ToBoolean( -1);
         Ucfile_Tooltiptext = "";
         Ucfile_Hideadditionalbuttons = Convert.ToBoolean( -1);
         Ucfile_Autoupload = Convert.ToBoolean( -1);
         Ucfile_Class = "FileUpload CellDynamicFormImagePaddingLeft";
         Btnremovefile_Visible = Convert.ToBoolean( -1);
         edtavFilereadonlyaux_Visible = 1;
         divUcfilecell_Class = "col-xs-12";
         edtavFilereadonly_Jsonclick = "";
         edtavFilereadonly_Parameters = "";
         edtavFilereadonly_Contenttype = "";
         edtavFilereadonly_Filetype = "";
         edtavFilereadonly_Linktarget = "";
         edtavFilereadonly_Display = 0;
         edtavFilereadonly_Enabled = 1;
         edtavFilereadonly_Visible = 1;
         divDatacellname_Class = "col-xs-12 DataContentCell CellDynamicFormImage DscTop";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV14FileReadonly","fld":"vFILEREADONLY"},{"av":"AV26UploadedFiles","fld":"vUPLOADEDFILES"},{"av":"AV31WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV30WWP_DF_ImageMetadata","fld":"vWWP_DF_IMAGEMETADATA","hsh":true},{"av":"AV35WWPFormElementTitle","fld":"vWWPFORMELEMENTTITLE","hsh":true},{"av":"AV12ElementInternalName","fld":"vELEMENTINTERNALNAME","hsh":true},{"av":"AV16HasReferenceId","fld":"vHASREFERENCEID","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"Btnremovefile_Visible","ctrl":"BTNREMOVEFILE","prop":"Visible"},{"av":"divUcfilecell_Class","ctrl":"UCFILECELL","prop":"Class"}]}""");
         setEventMetadata("'DOREMOVEFILE'","""{"handler":"E142R2","iparms":[{"av":"AV36WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV33WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV38WWPFormInstanceElementId","fld":"vWWPFORMINSTANCEELEMENTID","pic":"ZZZ9"},{"av":"AV22SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV14FileReadonly","fld":"vFILEREADONLY"},{"av":"AV26UploadedFiles","fld":"vUPLOADEDFILES"},{"av":"AV31WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV15FileReadonlyAux","fld":"vFILEREADONLYAUX"},{"av":"AV37WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"},{"av":"AV10DataExtension","fld":"vDATAEXTENSION"},{"av":"AV11DataFileName","fld":"vDATAFILENAME"}]""");
         setEventMetadata("'DOREMOVEFILE'",""","oparms":[{"av":"AV14FileReadonly","fld":"vFILEREADONLY"},{"av":"AV26UploadedFiles","fld":"vUPLOADEDFILES"},{"av":"AV15FileReadonlyAux","fld":"vFILEREADONLYAUX"},{"av":"AV13ExistElement","fld":"vEXISTELEMENT"},{"av":"AV37WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"},{"av":"edtavFilereadonly_Visible","ctrl":"vFILEREADONLY","prop":"Visible"},{"av":"divDatacellname_Class","ctrl":"DATACELLNAME","prop":"Class"},{"av":"Btnremovefile_Visible","ctrl":"BTNREMOVEFILE","prop":"Visible"},{"av":"divUcfilecell_Class","ctrl":"UCFILECELL","prop":"Class"},{"av":"AV36WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV10DataExtension","fld":"vDATAEXTENSION"},{"av":"AV11DataFileName","fld":"vDATAFILENAME"}]}""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_VALIDATE","""{"handler":"E152R2","iparms":[{"av":"AV43ErrorIds","fld":"vERRORIDS"},{"av":"AV5AuxSessionId","fld":"vAUXSESSIONID","pic":"ZZZ9"},{"av":"AV22SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"divLayoutmaintable_Class","ctrl":"LAYOUTMAINTABLE","prop":"Class"},{"av":"AV33WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV38WWPFormInstanceElementId","fld":"vWWPFORMINSTANCEELEMENTID","pic":"ZZZ9"},{"av":"AV13ExistElement","fld":"vEXISTELEMENT"},{"av":"AV36WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV30WWP_DF_ImageMetadata","fld":"vWWP_DF_IMAGEMETADATA","hsh":true},{"av":"AV37WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"},{"av":"AV35WWPFormElementTitle","fld":"vWWPFORMELEMENTTITLE","hsh":true},{"av":"AV12ElementInternalName","fld":"vELEMENTINTERNALNAME","hsh":true},{"av":"AV26UploadedFiles","fld":"vUPLOADEDFILES"},{"av":"AV31WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV15FileReadonlyAux","fld":"vFILEREADONLYAUX"},{"av":"AV10DataExtension","fld":"vDATAEXTENSION"},{"av":"AV11DataFileName","fld":"vDATAFILENAME"}]""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_VALIDATE",""","oparms":[{"av":"AV13ExistElement","fld":"vEXISTELEMENT"},{"av":"AV37WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"},{"av":"AV36WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV10DataExtension","fld":"vDATAEXTENSION"},{"av":"AV11DataFileName","fld":"vDATAFILENAME"}]}""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES","""{"handler":"E162R2","iparms":[{"av":"AV5AuxSessionId","fld":"vAUXSESSIONID","pic":"ZZZ9"},{"av":"AV22SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV28VisibleCondition","fld":"vVISIBLECONDITION"},{"av":"AV30WWP_DF_ImageMetadata","fld":"vWWP_DF_IMAGEMETADATA","hsh":true},{"av":"AV38WWPFormInstanceElementId","fld":"vWWPFORMINSTANCEELEMENTID","pic":"ZZZ9"},{"av":"AV36WWPFormInstance","fld":"vWWPFORMINSTANCE"}]""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES",""","oparms":[{"av":"AV36WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV28VisibleCondition","fld":"vVISIBLECONDITION"},{"av":"divLayoutmaintable_Class","ctrl":"LAYOUTMAINTABLE","prop":"Class"}]}""");
         setEventMetadata("UCFILE.UPLOADCOMPLETE","""{"handler":"E112R2","iparms":[{"av":"AV26UploadedFiles","fld":"vUPLOADEDFILES"},{"av":"AV16HasReferenceId","fld":"vHASREFERENCEID","hsh":true},{"av":"AV22SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV36WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV33WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV38WWPFormInstanceElementId","fld":"vWWPFORMINSTANCEELEMENTID","pic":"ZZZ9"},{"av":"AV30WWP_DF_ImageMetadata","fld":"vWWP_DF_IMAGEMETADATA","hsh":true},{"av":"AV37WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"},{"av":"AV35WWPFormElementTitle","fld":"vWWPFORMELEMENTTITLE","hsh":true},{"av":"AV12ElementInternalName","fld":"vELEMENTINTERNALNAME","hsh":true},{"av":"AV31WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV15FileReadonlyAux","fld":"vFILEREADONLYAUX"},{"av":"AV10DataExtension","fld":"vDATAEXTENSION"},{"av":"AV11DataFileName","fld":"vDATAFILENAME"}]""");
         setEventMetadata("UCFILE.UPLOADCOMPLETE",""","oparms":[{"av":"AV13ExistElement","fld":"vEXISTELEMENT"},{"av":"AV37WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"},{"av":"AV36WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV10DataExtension","fld":"vDATAEXTENSION"},{"av":"AV11DataFileName","fld":"vDATAFILENAME"}]}""");
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
         AV36WWPFormInstance = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         wcpOAV31WWPDynamicFormMode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV30WWP_DF_ImageMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ImageMetadata(context);
         AV35WWPFormElementTitle = "";
         AV12ElementInternalName = "";
         AV26UploadedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "Comforta_version2");
         AV39FailedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "Comforta_version2");
         AV37WWPFormInstanceElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         AV10DataExtension = "";
         AV11DataFileName = "";
         AV43ErrorIds = "";
         AV28VisibleCondition = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression(context);
         GX_FocusControl = "";
         lblDatatitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         gxblobfileaux = new GxFile(context.GetPhysicalPath());
         AV14FileReadonly = "";
         AV15FileReadonlyAux = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV44SDT_DynamicFormTranslation = new SdtSDT_DynamicFormTranslation(context);
         AV6CurrentWWPFormInstanceElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         AV34WWPFormElementMetadata = "";
         AV29WebSession = context.GetSession();
         ucBtnremovefile = new GXUserControl();
         GXt_SdtWWP_FormInstance1 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         AV25UploadedFile = new SdtFileUploadData(context);
         AV7Data = "";
         AV27Validations = new GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation>( context, "WWP_DF_Validation", "Comforta_version2");
         AV23ThisValueStr = "";
         AV21Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV20Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV8DataCellNameClass = "";
         sStyleString = "";
         ucUcfile = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV31WWPDynamicFormMode = "";
         sCtrlAV33WWPFormElementId = "";
         sCtrlAV38WWPFormInstanceElementId = "";
         sCtrlAV22SessionId = "";
         sCtrlAV36WWPFormInstance = "";
         /* GeneXus formulas. */
         edtavFilereadonly_Enabled = 0;
      }

      private short AV33WWPFormElementId ;
      private short AV38WWPFormInstanceElementId ;
      private short AV22SessionId ;
      private short wcpOAV33WWPFormElementId ;
      private short wcpOAV38WWPFormInstanceElementId ;
      private short wcpOAV22SessionId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV5AuxSessionId ;
      private short wbEnd ;
      private short wbStart ;
      private short edtavFilereadonly_Display ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short AV32WWPFormElementCaption ;
      private short nGXWrapped ;
      private int edtavFilereadonly_Enabled ;
      private int divDatatitlecell_Visible ;
      private int edtavFilereadonly_Visible ;
      private int edtavFilereadonlyaux_Visible ;
      private int AV45GXV1 ;
      private int AV46GXV2 ;
      private int AV47GXV3 ;
      private int Ucfile_Maxnumberoffiles ;
      private int idxLst ;
      private string AV31WWPDynamicFormMode ;
      private string wcpOAV31WWPDynamicFormMode ;
      private string divLayoutmaintable_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string edtavFilereadonly_Internalname ;
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
      private string ClassString ;
      private string StyleString ;
      private string TempTags ;
      private string edtavFilereadonly_Filetype ;
      private string edtavFilereadonly_Contenttype ;
      private string edtavFilereadonly_Linktarget ;
      private string edtavFilereadonly_Parameters ;
      private string edtavFilereadonly_Jsonclick ;
      private string divUcfilecell_Internalname ;
      private string divUcfilecell_Class ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavFilereadonlyaux_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string Btnremovefile_Internalname ;
      private string sStyleString ;
      private string tblTablemergeducfile_Internalname ;
      private string Ucfile_Class ;
      private string Ucfile_Tooltiptext ;
      private string Ucfile_Acceptedfiletypes ;
      private string Ucfile_Internalname ;
      private string Btnremovefile_Tooltiptext ;
      private string Btnremovefile_Beforeiconclass ;
      private string Btnremovefile_Caption ;
      private string Btnremovefile_Class ;
      private string sCtrlAV31WWPDynamicFormMode ;
      private string sCtrlAV33WWPFormElementId ;
      private string sCtrlAV38WWPFormInstanceElementId ;
      private string sCtrlAV22SessionId ;
      private string sCtrlAV36WWPFormInstance ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV16HasReferenceId ;
      private bool AV13ExistElement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV17IsElementFocusable ;
      private bool AV9DataEnabled ;
      private bool Btnremovefile_Visible ;
      private bool AV24UpdateFile ;
      private bool AV18IsRequired ;
      private bool AV19IsValid ;
      private bool Ucfile_Autoupload ;
      private bool Ucfile_Hideadditionalbuttons ;
      private bool Ucfile_Enableuploadedfilecanceling ;
      private bool Ucfile_Autodisableaddingfiles ;
      private string AV35WWPFormElementTitle ;
      private string AV34WWPFormElementMetadata ;
      private string AV12ElementInternalName ;
      private string AV10DataExtension ;
      private string AV11DataFileName ;
      private string AV43ErrorIds ;
      private string AV15FileReadonlyAux ;
      private string AV23ThisValueStr ;
      private string AV8DataCellNameClass ;
      private string AV14FileReadonly ;
      private string AV7Data ;
      private IGxSession AV29WebSession ;
      private GxFile gxblobfileaux ;
      private GXUserControl ucBtnremovefile ;
      private GXUserControl ucUcfile ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV36WWPFormInstance ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP4_WWPFormInstance ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ImageMetadata AV30WWP_DF_ImageMetadata ;
      private GXBaseCollection<SdtFileUploadData> AV26UploadedFiles ;
      private GXBaseCollection<SdtFileUploadData> AV39FailedFiles ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element AV37WWPFormInstanceElement ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression AV28VisibleCondition ;
      private SdtSDT_DynamicFormTranslation AV44SDT_DynamicFormTranslation ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element AV6CurrentWWPFormInstanceElement ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance GXt_SdtWWP_FormInstance1 ;
      private SdtFileUploadData AV25UploadedFile ;
      private GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation> AV27Validations ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV21Messages ;
      private GeneXus.Utils.SdtMessages_Message AV20Message ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
