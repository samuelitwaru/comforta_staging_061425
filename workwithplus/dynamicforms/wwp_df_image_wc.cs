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
   public class wwp_df_image_wc : GXWebComponent
   {
      public wwp_df_image_wc( )
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

      public wwp_df_image_wc( IGxContext context )
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
         this.AV30WWPDynamicFormMode = aP0_WWPDynamicFormMode;
         this.AV32WWPFormElementId = aP1_WWPFormElementId;
         this.AV37WWPFormInstanceElementId = aP2_WWPFormInstanceElementId;
         this.AV21SessionId = aP3_SessionId;
         this.AV35WWPFormInstance = aP4_WWPFormInstance;
         ExecuteImpl();
         aP4_WWPFormInstance=this.AV35WWPFormInstance;
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
                  AV30WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
                  AssignAttri(sPrefix, false, "AV30WWPDynamicFormMode", AV30WWPDynamicFormMode);
                  AV32WWPFormElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV32WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV32WWPFormElementId), 4, 0));
                  AV37WWPFormInstanceElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormInstanceElementId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV37WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV37WWPFormInstanceElementId), 4, 0));
                  AV21SessionId = (short)(Math.Round(NumberUtil.Val( GetPar( "SessionId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV21SessionId", StringUtil.LTrimStr( (decimal)(AV21SessionId), 4, 0));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV35WWPFormInstance);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV30WWPDynamicFormMode,(short)AV32WWPFormElementId,(short)AV37WWPFormInstanceElementId,(short)AV21SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV35WWPFormInstance});
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
            PA2Q2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS2Q2( ) ;
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
            context.SendWebValue( context.GetMessage( "WWP_Dynamic Form_Image_WC", "")) ;
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
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_df_image_wc.aspx"+UrlEncode(StringUtil.RTrim(AV30WWPDynamicFormMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV32WWPFormElementId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV37WWPFormInstanceElementId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV21SessionId,4,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.dynamicforms.wwp_df_image_wc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_IMAGEMETADATA", AV29WWP_DF_ImageMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_IMAGEMETADATA", AV29WWP_DF_ImageMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_IMAGEMETADATA", GetSecureSignedToken( sPrefix, AV29WWP_DF_ImageMetadata, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTTITLE", AV34WWPFormElementTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTTITLE", GetSecureSignedToken( sPrefix, AV34WWPFormElementTitle, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vELEMENTINTERNALNAME", AV12ElementInternalName);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vELEMENTINTERNALNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV12ElementInternalName, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASREFERENCEID", AV14HasReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV14HasReferenceId, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vUPLOADEDFILES", AV25UploadedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vUPLOADEDFILES", AV25UploadedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFAILEDFILES", AV38FailedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFAILEDFILES", AV38FailedFiles);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV30WWPDynamicFormMode", StringUtil.RTrim( wcpOAV30WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV32WWPFormElementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV32WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV37WWPFormInstanceElementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV37WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV21SessionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV21SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV30WWPDynamicFormMode));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORMINSTANCE", AV35WWPFormInstance);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORMINSTANCE", AV35WWPFormInstance);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMINSTANCEELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vIMAGEREADONLY_GXI", AV45Imagereadonly_GXI);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORMINSTANCEELEMENT", AV36WWPFormInstanceElement);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORMINSTANCEELEMENT", AV36WWPFormInstanceElement);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDATAEXTENSION", AV10DataExtension);
         GxWebStd.gx_hidden_field( context, sPrefix+"vDATAFILENAME", AV11DataFileName);
         GxWebStd.gx_hidden_field( context, sPrefix+"vERRORIDS", AV42ErrorIds);
         GxWebStd.gx_hidden_field( context, sPrefix+"vAUXSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5AuxSessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vEXISTELEMENT", AV13ExistElement);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_IMAGEMETADATA", AV29WWP_DF_ImageMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_IMAGEMETADATA", AV29WWP_DF_ImageMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_IMAGEMETADATA", GetSecureSignedToken( sPrefix, AV29WWP_DF_ImageMetadata, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTTITLE", AV34WWPFormElementTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTTITLE", GetSecureSignedToken( sPrefix, AV34WWPFormElementTitle, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vELEMENTINTERNALNAME", AV12ElementInternalName);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vELEMENTINTERNALNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV12ElementInternalName, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vVISIBLECONDITION", AV27VisibleCondition);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vVISIBLECONDITION", AV27VisibleCondition);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASREFERENCEID", AV14HasReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV14HasReferenceId, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"LAYOUTMAINTABLE_Class", StringUtil.RTrim( divLayoutmaintable_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"LAYOUTMAINTABLE_Class", StringUtil.RTrim( divLayoutmaintable_Class));
      }

      protected void RenderHtmlCloseForm2Q2( )
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
         return "WorkWithPlus.DynamicForms.WWP_DF_Image_WC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WWP_Dynamic Form_Image_WC", "") ;
      }

      protected void WB2Q0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "workwithplus.dynamicforms.wwp_df_image_wc.aspx");
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
            GxWebStd.gx_div_start( context, divDatatitlecell_Internalname, divDatatitlecell_Visible, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDatatitle_Internalname, lblDatatitle_Caption, "", "", lblDatatitle_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DF_Image_WC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDatacellname_Internalname, 1, 0, "px", 0, "px", "col-xs-12 DataContentCell CellDynamicFormImage DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedimagereadonly_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTextblockimagereadonly_cell_Internalname, 1, 0, "px", 0, "px", divTextblockimagereadonly_cell_Class, "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockimagereadonly_Internalname, " ", "", "", lblTextblockimagereadonly_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DF_Image_WC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table1_17_2Q2( true) ;
         }
         else
         {
            wb_table1_17_2Q2( false) ;
         }
         return  ;
      }

      protected void wb_table1_17_2Q2e( bool wbgen )
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
         }
         wbLoad = true;
      }

      protected void START2Q2( )
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
            Form.Meta.addItem("description", context.GetMessage( "WWP_Dynamic Form_Image_WC", ""), 0) ;
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
               STRUP2Q0( ) ;
            }
         }
      }

      protected void WS2Q2( )
      {
         START2Q2( ) ;
         EVT2Q2( ) ;
      }

      protected void EVT2Q2( )
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
                                 STRUP2Q0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "UCIMAGES.UPLOADCOMPLETE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ucimages.Uploadcomplete */
                                    E112Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E122Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E132Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOREMOVEIMAGE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoRemoveImage' */
                                    E142Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.DYNAMICFORM_VALIDATE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E152Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E162Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E172Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Q0( ) ;
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
                                 STRUP2Q0( ) ;
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

      protected void WE2Q2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2Q2( ) ;
            }
         }
      }

      protected void PA2Q2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.dynamicforms.wwp_df_image_wc.aspx")), "workwithplus.dynamicforms.wwp_df_image_wc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.dynamicforms.wwp_df_image_wc.aspx")))) ;
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
         RF2Q2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF2Q2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E132Q2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E172Q2 ();
            WB2Q0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2Q2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_IMAGEMETADATA", AV29WWP_DF_ImageMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_IMAGEMETADATA", AV29WWP_DF_ImageMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_IMAGEMETADATA", GetSecureSignedToken( sPrefix, AV29WWP_DF_ImageMetadata, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTTITLE", AV34WWPFormElementTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTTITLE", GetSecureSignedToken( sPrefix, AV34WWPFormElementTitle, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vELEMENTINTERNALNAME", AV12ElementInternalName);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vELEMENTINTERNALNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV12ElementInternalName, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASREFERENCEID", AV14HasReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV14HasReferenceId, context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2Q0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E122Q2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vUPLOADEDFILES"), AV25UploadedFiles);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFAILEDFILES"), AV38FailedFiles);
            /* Read saved values. */
            wcpOAV30WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV30WWPDynamicFormMode");
            wcpOAV32WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV32WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV37WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV37WWPFormInstanceElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV21SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV21SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            divLayoutmaintable_Class = cgiGet( sPrefix+"LAYOUTMAINTABLE_Class");
            /* Read variables values. */
            AV15ImageReadonly = cgiGet( imgavImagereadonly_Internalname);
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
         E122Q2 ();
         if (returnInSub) return;
      }

      protected void E122Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV43SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformid = AV35WWPFormInstance.gxTpr_Wwpformid;
         AV43SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformversionnumber = AV35WWPFormInstance.gxTpr_Wwpformversionnumber;
         AV43SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformelementid = AV32WWPFormElementId;
         new prc_getdynamicformtranslation(context ).execute( ref  AV43SDT_DynamicFormTranslation) ;
         AV16IsElementFocusable = true;
         AV14HasReferenceId = false;
         AssignAttri(sPrefix, false, "AV14HasReferenceId", AV14HasReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV14HasReferenceId, context));
         AV44GXV1 = 1;
         while ( AV44GXV1 <= AV35WWPFormInstance.gxTpr_Element.Count )
         {
            AV36WWPFormInstanceElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV35WWPFormInstance.gxTpr_Element.Item(AV44GXV1));
            if ( ( AV36WWPFormInstanceElement.gxTpr_Wwpformelementid == AV32WWPFormElementId ) && ( AV36WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid == AV37WWPFormInstanceElementId ) )
            {
               AV6CurrentWWPFormInstanceElement = AV36WWPFormInstanceElement;
               AV14HasReferenceId = (bool)((!String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV36WWPFormInstanceElement.gxTpr_Wwpformelementreferenceid)))));
               AssignAttri(sPrefix, false, "AV14HasReferenceId", AV14HasReferenceId);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV14HasReferenceId, context));
               AV34WWPFormElementTitle = AV36WWPFormInstanceElement.gxTpr_Wwpformelementtitle;
               AssignAttri(sPrefix, false, "AV34WWPFormElementTitle", AV34WWPFormElementTitle);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTTITLE", GetSecureSignedToken( sPrefix, AV34WWPFormElementTitle, context));
               AV33WWPFormElementMetadata = AV36WWPFormInstanceElement.gxTpr_Wwpformelementmetadata;
               AV31WWPFormElementCaption = AV36WWPFormInstanceElement.gxTpr_Wwpformelementcaption;
               if (true) break;
            }
            AV44GXV1 = (int)(AV44GXV1+1);
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
         if ( AV16IsElementFocusable && ( StringUtil.StrCmp(divLayoutmaintable_Class, "Table") == 0 ) && ( StringUtil.StrCmp(AV28WebSession.Get("WWPDynFormSetFocus"), "") != 0 ) )
         {
            /* Execute user subroutine: 'SET FOCUS TO ELEMENT' */
            S132 ();
            if (returnInSub) return;
            AV28WebSession.Remove("WWPDynFormSetFocus");
         }
         if ( ( StringUtil.StrCmp(AV30WWPDynamicFormMode, "DSP") != 0 ) && ( StringUtil.StrCmp(AV30WWPDynamicFormMode, "DLT") != 0 ) )
         {
            AV9DataEnabled = true;
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S142 ();
         if (returnInSub) return;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV43SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationvalue)) )
         {
            lblDatatitle_Caption = AV34WWPFormElementTitle;
            AssignProp(sPrefix, false, lblDatatitle_Internalname, "Caption", lblDatatitle_Caption, true);
         }
         else
         {
            lblDatatitle_Caption = AV43SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationvalue;
            AssignProp(sPrefix, false, lblDatatitle_Internalname, "Caption", lblDatatitle_Caption, true);
         }
         divDatatitlecell_Visible = 1;
         AssignProp(sPrefix, false, divDatatitlecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDatatitlecell_Visible), 5, 0), true);
      }

      protected void E132Q2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E142Q2( )
      {
         /* 'DoRemoveImage' Routine */
         returnInSub = false;
         AV15ImageReadonly = "";
         AssignProp(sPrefix, false, imgavImagereadonly_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV15ImageReadonly)) ? AV45Imagereadonly_GXI : context.convertURL( context.PathToRelativeUrl( AV15ImageReadonly))), true);
         AssignProp(sPrefix, false, imgavImagereadonly_Internalname, "SrcSet", context.GetImageSrcSet( AV15ImageReadonly), true);
         AV45Imagereadonly_GXI = "";
         AssignProp(sPrefix, false, imgavImagereadonly_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV15ImageReadonly)) ? AV45Imagereadonly_GXI : context.convertURL( context.PathToRelativeUrl( AV15ImageReadonly))), true);
         AssignProp(sPrefix, false, imgavImagereadonly_Internalname, "SrcSet", context.GetImageSrcSet( AV15ImageReadonly), true);
         AV25UploadedFiles.Clear();
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV25UploadedFiles", AV25UploadedFiles);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV36WWPFormInstanceElement", AV36WWPFormInstanceElement);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35WWPFormInstance", AV35WWPFormInstance);
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( GxImageUtil.GetFileSize( AV15ImageReadonly) > 0 ) && ( AV25UploadedFiles.Count == 0 ) && ( ( StringUtil.StrCmp(AV30WWPDynamicFormMode, "UPD") == 0 ) || ( StringUtil.StrCmp(AV30WWPDynamicFormMode, "INS") == 0 ) ) ) )
         {
            Btnremoveimage_Visible = false;
            ucBtnremoveimage.SendProperty(context, sPrefix, false, Btnremoveimage_Internalname, "Visible", StringUtil.BoolToStr( Btnremoveimage_Visible));
         }
         if ( ( ( GxImageUtil.GetFileSize( AV15ImageReadonly) > 0 ) && ( ( StringUtil.StrCmp(AV30WWPDynamicFormMode, "UPD") == 0 ) || ( StringUtil.StrCmp(AV30WWPDynamicFormMode, "INS") == 0 ) ) ) || ( StringUtil.StrCmp(AV30WWPDynamicFormMode, "DLT") == 0 ) || ( StringUtil.StrCmp(AV30WWPDynamicFormMode, "DSP") == 0 ) )
         {
            cellUcimagescell_Class = "Invisible";
            AssignProp(sPrefix, false, cellUcimagescell_Internalname, "Class", cellUcimagescell_Class, true);
         }
         else
         {
            cellUcimagescell_Class = "WWP_DF_MergedBlobCell";
            AssignProp(sPrefix, false, cellUcimagescell_Internalname, "Class", cellUcimagescell_Class, true);
         }
         if ( ( StringUtil.StrCmp(AV30WWPDynamicFormMode, "INS") == 0 ) || ( StringUtil.StrCmp(AV30WWPDynamicFormMode, "UPD") == 0 ) )
         {
            imgavImagereadonly_Class = "Attribute DynamicFormEditableImage";
            AssignProp(sPrefix, false, imgavImagereadonly_Internalname, "Class", imgavImagereadonly_Class, true);
         }
      }

      protected void S142( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ( GxImageUtil.GetFileSize( AV15ImageReadonly) > 0 ) && ( AV25UploadedFiles.Count == 0 ) ) )
         {
            imgavImagereadonly_Visible = 0;
            AssignProp(sPrefix, false, imgavImagereadonly_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgavImagereadonly_Visible), 5, 0), true);
            cellImagereadonly_cell_Class = "Invisible";
            AssignProp(sPrefix, false, cellImagereadonly_cell_Internalname, "Class", cellImagereadonly_cell_Class, true);
            divTextblockimagereadonly_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divTextblockimagereadonly_cell_Internalname, "Class", divTextblockimagereadonly_cell_Class, true);
         }
         else
         {
            imgavImagereadonly_Visible = 1;
            AssignProp(sPrefix, false, imgavImagereadonly_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgavImagereadonly_Visible), 5, 0), true);
            cellImagereadonly_cell_Class = "MergeDataCell";
            AssignProp(sPrefix, false, cellImagereadonly_cell_Internalname, "Class", cellImagereadonly_cell_Class, true);
            divTextblockimagereadonly_cell_Class = "col-sm-12 MergeLabelCell";
            AssignProp(sPrefix, false, divTextblockimagereadonly_cell_Internalname, "Class", divTextblockimagereadonly_cell_Class, true);
         }
         divTextblockimagereadonly_cell_Class = "col-sm-3 MergeLabelCell";
         AssignProp(sPrefix, false, divTextblockimagereadonly_cell_Internalname, "Class", divTextblockimagereadonly_cell_Class, true);
      }

      protected void E152Q2( )
      {
         /* General\GlobalEvents_Dynamicform_validate Routine */
         returnInSub = false;
         if ( ( AV5AuxSessionId == AV21SessionId ) && ( StringUtil.StrCmp(divLayoutmaintable_Class, "Invisible") != 0 ) && StringUtil.Contains( AV42ErrorIds, "|"+StringUtil.Trim( StringUtil.Str( (decimal)(AV32WWPFormElementId), 4, 0))+"."+StringUtil.Trim( StringUtil.Str( (decimal)(AV37WWPFormInstanceElementId), 4, 0))+"|") )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV36WWPFormInstanceElement", AV36WWPFormInstanceElement);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35WWPFormInstance", AV35WWPFormInstance);
      }

      protected void E162Q2( )
      {
         /* General\GlobalEvents_Dynamicform_updatevisibilities Routine */
         returnInSub = false;
         if ( ( AV5AuxSessionId == AV21SessionId ) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV27VisibleCondition.gxTpr_Expression))) )
         {
            /* Execute user subroutine: 'GET FORM INSTANCE' */
            S182 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'UPDATE VISIBILITY' */
            S122 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35WWPFormInstance", AV35WWPFormInstance);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV27VisibleCondition", AV27VisibleCondition);
      }

      protected void S182( )
      {
         /* 'GET FORM INSTANCE' Routine */
         returnInSub = false;
         GXt_SdtWWP_FormInstance1 = AV35WWPFormInstance;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadforminstance(context ).execute(  AV21SessionId, out  GXt_SdtWWP_FormInstance1) ;
         AV35WWPFormInstance = GXt_SdtWWP_FormInstance1;
      }

      protected void S112( )
      {
         /* 'GET DATA FROM CURRENT ELEMENT' Routine */
         returnInSub = false;
         AV15ImageReadonly = AV6CurrentWWPFormInstanceElement.gxTpr_Wwpforminstanceelemblob;
         AssignProp(sPrefix, false, imgavImagereadonly_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV15ImageReadonly)) ? AV45Imagereadonly_GXI : context.convertURL( context.PathToRelativeUrl( AV15ImageReadonly))), true);
         AssignProp(sPrefix, false, imgavImagereadonly_Internalname, "SrcSet", context.GetImageSrcSet( AV15ImageReadonly), true);
         AV45Imagereadonly_GXI = GXDbFile.GetUriFromFile( "", "", AV6CurrentWWPFormInstanceElement.gxTpr_Wwpforminstanceelemblob);
         AssignProp(sPrefix, false, imgavImagereadonly_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV15ImageReadonly)) ? AV45Imagereadonly_GXI : context.convertURL( context.PathToRelativeUrl( AV15ImageReadonly))), true);
         AssignProp(sPrefix, false, imgavImagereadonly_Internalname, "SrcSet", context.GetImageSrcSet( AV15ImageReadonly), true);
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
         while ( AV46GXV2 <= AV35WWPFormInstance.gxTpr_Element.Count )
         {
            AV36WWPFormInstanceElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV35WWPFormInstance.gxTpr_Element.Item(AV46GXV2));
            if ( ( AV36WWPFormInstanceElement.gxTpr_Wwpformelementid == AV32WWPFormElementId ) && ( AV36WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid == AV37WWPFormInstanceElementId ) )
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
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_saveforminstance(context ).execute(  AV21SessionId,  AV35WWPFormInstance) ;
         }
      }

      protected void S192( )
      {
         /* 'SET DATA TO ELEMENT' Routine */
         returnInSub = false;
         AV23UpdateImage = true;
         if ( AV25UploadedFiles.Count > 0 )
         {
            AV24UploadedFile = ((SdtFileUploadData)AV25UploadedFiles.Item(1));
            AV7Data = AV24UploadedFile.gxTpr_File;
            AV10DataExtension = AV24UploadedFile.gxTpr_Extension;
            AssignAttri(sPrefix, false, "AV10DataExtension", AV10DataExtension);
            AV11DataFileName = AV24UploadedFile.gxTpr_Name;
            AssignAttri(sPrefix, false, "AV11DataFileName", AV11DataFileName);
         }
         else
         {
            if ( ( ( StringUtil.StrCmp(AV30WWPDynamicFormMode, "UPD") == 0 ) || ( StringUtil.StrCmp(AV30WWPDynamicFormMode, "INS") == 0 ) ) && ( StringUtil.StrCmp(AV45Imagereadonly_GXI, "") != 0 ) )
            {
               AV23UpdateImage = false;
            }
            AV7Data = "";
         }
         if ( AV23UpdateImage )
         {
            AV36WWPFormInstanceElement.gxTpr_Wwpforminstanceelemblob = AV7Data;
            AV36WWPFormInstanceElement.gxTpr_Wwpforminstanceelemblobfiletype = AV10DataExtension;
            AV36WWPFormInstanceElement.gxTpr_Wwpforminstanceelemblobfilename = AV11DataFileName;
         }
      }

      protected void S122( )
      {
         /* 'UPDATE VISIBILITY' Routine */
         returnInSub = false;
         AV27VisibleCondition = AV29WWP_DF_ImageMetadata.gxTpr_Visiblecondition;
         if ( new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_evaluateelementvisibility(context).executeUdp(  AV35WWPFormInstance,  AV37WWPFormInstanceElementId,  AV27VisibleCondition) )
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
         AV17IsRequired = AV29WWP_DF_ImageMetadata.gxTpr_Isrequired;
         AV26Validations = AV29WWP_DF_ImageMetadata.gxTpr_Validations;
         AV22ThisValueStr = StringUtil.Format( "'%1'", (!String.IsNullOrEmpty(StringUtil.RTrim( AV36WWPFormInstanceElement.gxTpr_Wwpforminstanceelemblob)) ? "FILE_VALUE" : ""), "", "", "", "", "", "", "", "");
         AV18IsValid = true;
         if ( AV17IsRequired && ( StringUtil.StrCmp(StringUtil.Trim( AV22ThisValueStr), "''") == 0 ) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), AV34WWPFormElementTitle, "", "", "", "", "", "", "", ""),  "error",  AV12ElementInternalName,  "true",  ""));
            AV18IsValid = false;
         }
         else
         {
            if ( AV26Validations.Count > 0 )
            {
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_executeelementvalidations(context ).execute(  AV35WWPFormInstance,  AV37WWPFormInstanceElementId,  AV22ThisValueStr,  AV26Validations, out  AV20Messages) ;
               AV47GXV3 = 1;
               while ( AV47GXV3 <= AV20Messages.Count )
               {
                  AV19Message = ((GeneXus.Utils.SdtMessages_Message)AV20Messages.Item(AV47GXV3));
                  GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV19Message.gxTpr_Description,  ((AV19Message.gxTpr_Type==1) ? "error" : "info"),  AV12ElementInternalName,  "true",  ""));
                  if ( AV19Message.gxTpr_Type == 1 )
                  {
                     AV18IsValid = false;
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
         AV31WWPFormElementCaption = 0;
         if ( AV31WWPFormElementCaption == 2 )
         {
            lblDatatitle_Caption = AV34WWPFormElementTitle;
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
         if ( AV31WWPFormElementCaption != 1 )
         {
            AV8DataCellNameClass += " DataContentCellNoLabel";
         }
         AV8DataCellNameClass += " CellDynamicFormImage";
         divDatatitlecell_Visible = 0;
         AssignProp(sPrefix, false, divDatatitlecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDatatitlecell_Visible), 5, 0), true);
      }

      protected void S132( )
      {
         /* 'SET FOCUS TO ELEMENT' Routine */
         returnInSub = false;
         GX_FocusControl = imgavImagereadonly_Internalname;
         AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         context.DoAjaxSetFocus(GX_FocusControl);
      }

      protected void E112Q2( )
      {
         /* Ucimages_Uploadcomplete Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVE ELEMENT DATA TO SESSION' */
         S162 ();
         if (returnInSub) return;
         if ( AV14HasReferenceId )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "DynamicForm_UpdateVisibilities", new Object[] {(short)AV21SessionId}, true);
         }
         /* Execute user subroutine: 'EXECUTE VALIDATIONS' */
         S172 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV36WWPFormInstanceElement", AV36WWPFormInstanceElement);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35WWPFormInstance", AV35WWPFormInstance);
      }

      protected void nextLoad( )
      {
      }

      protected void E172Q2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_17_2Q2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedimagereadonly_Internalname, tblTablemergedimagereadonly_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellImagereadonly_cell_Internalname+"\"  class='"+cellImagereadonly_cell_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", context.GetMessage( "Image Readonly", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Static Bitmap Variable */
            ClassString = imgavImagereadonly_Class + " " + ((StringUtil.StrCmp(imgavImagereadonly_gximage, "")==0) ? "" : "GX_Image_"+imgavImagereadonly_gximage+"_Class");
            StyleString = "";
            AV15ImageReadonly_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV15ImageReadonly))&&String.IsNullOrEmpty(StringUtil.RTrim( AV45Imagereadonly_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV15ImageReadonly)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV15ImageReadonly)) ? AV45Imagereadonly_GXI : context.PathToRelativeUrl( AV15ImageReadonly));
            GxWebStd.gx_bitmap( context, imgavImagereadonly_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgavImagereadonly_Visible, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV15ImageReadonly_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_WorkWithPlus/DynamicForms/WWP_DF_Image_WC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellUcimagescell_Internalname+"\"  class='"+cellUcimagescell_Class+"'>") ;
            /* User Defined Control */
            ucUcimages.SetProperty("AutoUpload", Ucimages_Autoupload);
            ucUcimages.SetProperty("HideAdditionalButtons", Ucimages_Hideadditionalbuttons);
            ucUcimages.SetProperty("TooltipText", Ucimages_Tooltiptext);
            ucUcimages.SetProperty("EnableUploadedFileCanceling", Ucimages_Enableuploadedfilecanceling);
            ucUcimages.SetProperty("MaxNumberOfFiles", Ucimages_Maxnumberoffiles);
            ucUcimages.SetProperty("AutoDisableAddingFiles", Ucimages_Autodisableaddingfiles);
            ucUcimages.SetProperty("AcceptedFileTypes", Ucimages_Acceptedfiletypes);
            ucUcimages.SetProperty("UploadedFiles", AV25UploadedFiles);
            ucUcimages.SetProperty("FailedFiles", AV38FailedFiles);
            ucUcimages.Render(context, "fileupload", Ucimages_Internalname, sPrefix+"UCIMAGESContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucBtnremoveimage.SetProperty("TooltipText", Btnremoveimage_Tooltiptext);
            ucBtnremoveimage.SetProperty("BeforeIconClass", Btnremoveimage_Beforeiconclass);
            ucBtnremoveimage.SetProperty("Caption", Btnremoveimage_Caption);
            ucBtnremoveimage.SetProperty("Class", Btnremoveimage_Class);
            ucBtnremoveimage.Render(context, "wwp_iconbutton", Btnremoveimage_Internalname, sPrefix+"BTNREMOVEIMAGEContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_17_2Q2e( true) ;
         }
         else
         {
            wb_table1_17_2Q2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV30WWPDynamicFormMode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV30WWPDynamicFormMode", AV30WWPDynamicFormMode);
         AV32WWPFormElementId = Convert.ToInt16(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV32WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV32WWPFormElementId), 4, 0));
         AV37WWPFormInstanceElementId = Convert.ToInt16(getParm(obj,2));
         AssignAttri(sPrefix, false, "AV37WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV37WWPFormInstanceElementId), 4, 0));
         AV21SessionId = Convert.ToInt16(getParm(obj,3));
         AssignAttri(sPrefix, false, "AV21SessionId", StringUtil.LTrimStr( (decimal)(AV21SessionId), 4, 0));
         AV35WWPFormInstance = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)getParm(obj,4);
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
         PA2Q2( ) ;
         WS2Q2( ) ;
         WE2Q2( ) ;
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
         sCtrlAV30WWPDynamicFormMode = (string)((string)getParm(obj,0));
         sCtrlAV32WWPFormElementId = (string)((string)getParm(obj,1));
         sCtrlAV37WWPFormInstanceElementId = (string)((string)getParm(obj,2));
         sCtrlAV21SessionId = (string)((string)getParm(obj,3));
         sCtrlAV35WWPFormInstance = (string)((string)getParm(obj,4));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2Q2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "workwithplus\\dynamicforms\\wwp_df_image_wc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2Q2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV30WWPDynamicFormMode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV30WWPDynamicFormMode", AV30WWPDynamicFormMode);
            AV32WWPFormElementId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV32WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV32WWPFormElementId), 4, 0));
            AV37WWPFormInstanceElementId = Convert.ToInt16(getParm(obj,4));
            AssignAttri(sPrefix, false, "AV37WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV37WWPFormInstanceElementId), 4, 0));
            AV21SessionId = Convert.ToInt16(getParm(obj,5));
            AssignAttri(sPrefix, false, "AV21SessionId", StringUtil.LTrimStr( (decimal)(AV21SessionId), 4, 0));
            AV35WWPFormInstance = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)getParm(obj,6);
         }
         wcpOAV30WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV30WWPDynamicFormMode");
         wcpOAV32WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV32WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV37WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV37WWPFormInstanceElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV21SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV21SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV30WWPDynamicFormMode, wcpOAV30WWPDynamicFormMode) != 0 ) || ( AV32WWPFormElementId != wcpOAV32WWPFormElementId ) || ( AV37WWPFormInstanceElementId != wcpOAV37WWPFormInstanceElementId ) || ( AV21SessionId != wcpOAV21SessionId ) ) )
         {
            setjustcreated();
         }
         wcpOAV30WWPDynamicFormMode = AV30WWPDynamicFormMode;
         wcpOAV32WWPFormElementId = AV32WWPFormElementId;
         wcpOAV37WWPFormInstanceElementId = AV37WWPFormInstanceElementId;
         wcpOAV21SessionId = AV21SessionId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV30WWPDynamicFormMode = cgiGet( sPrefix+"AV30WWPDynamicFormMode_CTRL");
         if ( StringUtil.Len( sCtrlAV30WWPDynamicFormMode) > 0 )
         {
            AV30WWPDynamicFormMode = cgiGet( sCtrlAV30WWPDynamicFormMode);
            AssignAttri(sPrefix, false, "AV30WWPDynamicFormMode", AV30WWPDynamicFormMode);
         }
         else
         {
            AV30WWPDynamicFormMode = cgiGet( sPrefix+"AV30WWPDynamicFormMode_PARM");
         }
         sCtrlAV32WWPFormElementId = cgiGet( sPrefix+"AV32WWPFormElementId_CTRL");
         if ( StringUtil.Len( sCtrlAV32WWPFormElementId) > 0 )
         {
            AV32WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV32WWPFormElementId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV32WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV32WWPFormElementId), 4, 0));
         }
         else
         {
            AV32WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV32WWPFormElementId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV37WWPFormInstanceElementId = cgiGet( sPrefix+"AV37WWPFormInstanceElementId_CTRL");
         if ( StringUtil.Len( sCtrlAV37WWPFormInstanceElementId) > 0 )
         {
            AV37WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV37WWPFormInstanceElementId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV37WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV37WWPFormInstanceElementId), 4, 0));
         }
         else
         {
            AV37WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV37WWPFormInstanceElementId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         sCtrlAV35WWPFormInstance = cgiGet( sPrefix+"AV35WWPFormInstance_CTRL");
         if ( StringUtil.Len( sCtrlAV35WWPFormInstance) > 0 )
         {
            AV35WWPFormInstance.FromXml(cgiGet( sCtrlAV35WWPFormInstance), null, "", "");
         }
         else
         {
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"AV35WWPFormInstance_PARM"), AV35WWPFormInstance);
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
         PA2Q2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2Q2( ) ;
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
         WS2Q2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV30WWPDynamicFormMode_PARM", StringUtil.RTrim( AV30WWPDynamicFormMode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV30WWPDynamicFormMode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV30WWPDynamicFormMode_CTRL", StringUtil.RTrim( sCtrlAV30WWPDynamicFormMode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV32WWPFormElementId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV32WWPFormElementId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV32WWPFormElementId_CTRL", StringUtil.RTrim( sCtrlAV32WWPFormElementId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV37WWPFormInstanceElementId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV37WWPFormInstanceElementId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV37WWPFormInstanceElementId_CTRL", StringUtil.RTrim( sCtrlAV37WWPFormInstanceElementId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV21SessionId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV21SessionId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV21SessionId_CTRL", StringUtil.RTrim( sCtrlAV21SessionId));
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"AV35WWPFormInstance_PARM", AV35WWPFormInstance);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"AV35WWPFormInstance_PARM", AV35WWPFormInstance);
         }
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV35WWPFormInstance)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV35WWPFormInstance_CTRL", StringUtil.RTrim( sCtrlAV35WWPFormInstance));
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
         WE2Q2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256309334352", true, true);
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
         context.AddJavascriptSource("workwithplus/dynamicforms/wwp_df_image_wc.js", "?20256309334353", false, true);
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
         lblTextblockimagereadonly_Internalname = sPrefix+"TEXTBLOCKIMAGEREADONLY";
         divTextblockimagereadonly_cell_Internalname = sPrefix+"TEXTBLOCKIMAGEREADONLY_CELL";
         imgavImagereadonly_Internalname = sPrefix+"vIMAGEREADONLY";
         cellImagereadonly_cell_Internalname = sPrefix+"IMAGEREADONLY_CELL";
         Ucimages_Internalname = sPrefix+"UCIMAGES";
         cellUcimagescell_Internalname = sPrefix+"UCIMAGESCELL";
         Btnremoveimage_Internalname = sPrefix+"BTNREMOVEIMAGE";
         tblTablemergedimagereadonly_Internalname = sPrefix+"TABLEMERGEDIMAGEREADONLY";
         divTablesplittedimagereadonly_Internalname = sPrefix+"TABLESPLITTEDIMAGEREADONLY";
         divDatacellname_Internalname = sPrefix+"DATACELLNAME";
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
         Btnremoveimage_Class = "Button ButtonDynamicFormRemove";
         Btnremoveimage_Caption = context.GetMessage( "Remove", "");
         Btnremoveimage_Beforeiconclass = "fas fa-trash-can DynamicFormRemoveImage";
         Btnremoveimage_Tooltiptext = "";
         Ucimages_Acceptedfiletypes = "image";
         Ucimages_Autodisableaddingfiles = Convert.ToBoolean( -1);
         Ucimages_Maxnumberoffiles = 1;
         Ucimages_Enableuploadedfilecanceling = Convert.ToBoolean( -1);
         Ucimages_Tooltiptext = "";
         Ucimages_Hideadditionalbuttons = Convert.ToBoolean( -1);
         Ucimages_Autoupload = Convert.ToBoolean( -1);
         cellUcimagescell_Class = "";
         imgavImagereadonly_gximage = "";
         cellImagereadonly_cell_Class = "";
         imgavImagereadonly_Visible = 1;
         imgavImagereadonly_Class = "Attribute";
         Btnremoveimage_Visible = Convert.ToBoolean( -1);
         divTextblockimagereadonly_cell_Class = "col-xs-12";
         lblDatatitle_Caption = context.GetMessage( "Title", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV15ImageReadonly","fld":"vIMAGEREADONLY"},{"av":"AV25UploadedFiles","fld":"vUPLOADEDFILES"},{"av":"AV30WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV29WWP_DF_ImageMetadata","fld":"vWWP_DF_IMAGEMETADATA","hsh":true},{"av":"AV34WWPFormElementTitle","fld":"vWWPFORMELEMENTTITLE","hsh":true},{"av":"AV12ElementInternalName","fld":"vELEMENTINTERNALNAME","hsh":true},{"av":"AV14HasReferenceId","fld":"vHASREFERENCEID","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"Btnremoveimage_Visible","ctrl":"BTNREMOVEIMAGE","prop":"Visible"},{"av":"cellUcimagescell_Class","ctrl":"UCIMAGESCELL","prop":"Class"},{"av":"imgavImagereadonly_Class","ctrl":"vIMAGEREADONLY","prop":"Class"}]}""");
         setEventMetadata("'DOREMOVEIMAGE'","""{"handler":"E142Q2","iparms":[{"av":"AV35WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV32WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV37WWPFormInstanceElementId","fld":"vWWPFORMINSTANCEELEMENTID","pic":"ZZZ9"},{"av":"AV21SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV15ImageReadonly","fld":"vIMAGEREADONLY"},{"av":"AV25UploadedFiles","fld":"vUPLOADEDFILES"},{"av":"AV30WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV45Imagereadonly_GXI","fld":"vIMAGEREADONLY_GXI"},{"av":"AV36WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"},{"av":"AV10DataExtension","fld":"vDATAEXTENSION"},{"av":"AV11DataFileName","fld":"vDATAFILENAME"}]""");
         setEventMetadata("'DOREMOVEIMAGE'",""","oparms":[{"av":"AV15ImageReadonly","fld":"vIMAGEREADONLY"},{"av":"AV45Imagereadonly_GXI","fld":"vIMAGEREADONLY_GXI"},{"av":"AV25UploadedFiles","fld":"vUPLOADEDFILES"},{"av":"AV13ExistElement","fld":"vEXISTELEMENT"},{"av":"AV36WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"},{"av":"imgavImagereadonly_Visible","ctrl":"vIMAGEREADONLY","prop":"Visible"},{"av":"cellImagereadonly_cell_Class","ctrl":"IMAGEREADONLY_CELL","prop":"Class"},{"av":"divTextblockimagereadonly_cell_Class","ctrl":"TEXTBLOCKIMAGEREADONLY_CELL","prop":"Class"},{"av":"Btnremoveimage_Visible","ctrl":"BTNREMOVEIMAGE","prop":"Visible"},{"av":"cellUcimagescell_Class","ctrl":"UCIMAGESCELL","prop":"Class"},{"av":"imgavImagereadonly_Class","ctrl":"vIMAGEREADONLY","prop":"Class"},{"av":"AV35WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV10DataExtension","fld":"vDATAEXTENSION"},{"av":"AV11DataFileName","fld":"vDATAFILENAME"}]}""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_VALIDATE","""{"handler":"E152Q2","iparms":[{"av":"AV42ErrorIds","fld":"vERRORIDS"},{"av":"AV5AuxSessionId","fld":"vAUXSESSIONID","pic":"ZZZ9"},{"av":"AV21SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"divLayoutmaintable_Class","ctrl":"LAYOUTMAINTABLE","prop":"Class"},{"av":"AV32WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV37WWPFormInstanceElementId","fld":"vWWPFORMINSTANCEELEMENTID","pic":"ZZZ9"},{"av":"AV13ExistElement","fld":"vEXISTELEMENT"},{"av":"AV35WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV29WWP_DF_ImageMetadata","fld":"vWWP_DF_IMAGEMETADATA","hsh":true},{"av":"AV36WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"},{"av":"AV34WWPFormElementTitle","fld":"vWWPFORMELEMENTTITLE","hsh":true},{"av":"AV12ElementInternalName","fld":"vELEMENTINTERNALNAME","hsh":true},{"av":"AV25UploadedFiles","fld":"vUPLOADEDFILES"},{"av":"AV45Imagereadonly_GXI","fld":"vIMAGEREADONLY_GXI"},{"av":"AV30WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV10DataExtension","fld":"vDATAEXTENSION"},{"av":"AV11DataFileName","fld":"vDATAFILENAME"}]""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_VALIDATE",""","oparms":[{"av":"AV13ExistElement","fld":"vEXISTELEMENT"},{"av":"AV36WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"},{"av":"AV35WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV10DataExtension","fld":"vDATAEXTENSION"},{"av":"AV11DataFileName","fld":"vDATAFILENAME"}]}""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES","""{"handler":"E162Q2","iparms":[{"av":"AV5AuxSessionId","fld":"vAUXSESSIONID","pic":"ZZZ9"},{"av":"AV21SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV27VisibleCondition","fld":"vVISIBLECONDITION"},{"av":"AV29WWP_DF_ImageMetadata","fld":"vWWP_DF_IMAGEMETADATA","hsh":true},{"av":"AV37WWPFormInstanceElementId","fld":"vWWPFORMINSTANCEELEMENTID","pic":"ZZZ9"},{"av":"AV35WWPFormInstance","fld":"vWWPFORMINSTANCE"}]""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES",""","oparms":[{"av":"AV35WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV27VisibleCondition","fld":"vVISIBLECONDITION"},{"av":"divLayoutmaintable_Class","ctrl":"LAYOUTMAINTABLE","prop":"Class"}]}""");
         setEventMetadata("UCIMAGES.UPLOADCOMPLETE","""{"handler":"E112Q2","iparms":[{"av":"AV14HasReferenceId","fld":"vHASREFERENCEID","hsh":true},{"av":"AV21SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV35WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV32WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV37WWPFormInstanceElementId","fld":"vWWPFORMINSTANCEELEMENTID","pic":"ZZZ9"},{"av":"AV29WWP_DF_ImageMetadata","fld":"vWWP_DF_IMAGEMETADATA","hsh":true},{"av":"AV36WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"},{"av":"AV34WWPFormElementTitle","fld":"vWWPFORMELEMENTTITLE","hsh":true},{"av":"AV12ElementInternalName","fld":"vELEMENTINTERNALNAME","hsh":true},{"av":"AV25UploadedFiles","fld":"vUPLOADEDFILES"},{"av":"AV45Imagereadonly_GXI","fld":"vIMAGEREADONLY_GXI"},{"av":"AV30WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV10DataExtension","fld":"vDATAEXTENSION"},{"av":"AV11DataFileName","fld":"vDATAFILENAME"}]""");
         setEventMetadata("UCIMAGES.UPLOADCOMPLETE",""","oparms":[{"av":"AV13ExistElement","fld":"vEXISTELEMENT"},{"av":"AV36WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"},{"av":"AV35WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV10DataExtension","fld":"vDATAEXTENSION"},{"av":"AV11DataFileName","fld":"vDATAFILENAME"}]}""");
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
         AV35WWPFormInstance = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         wcpOAV30WWPDynamicFormMode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV29WWP_DF_ImageMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ImageMetadata(context);
         AV34WWPFormElementTitle = "";
         AV12ElementInternalName = "";
         AV25UploadedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "Comforta_version2");
         AV38FailedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "Comforta_version2");
         AV45Imagereadonly_GXI = "";
         AV36WWPFormInstanceElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         AV10DataExtension = "";
         AV11DataFileName = "";
         AV42ErrorIds = "";
         AV27VisibleCondition = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression(context);
         GX_FocusControl = "";
         lblDatatitle_Jsonclick = "";
         lblTextblockimagereadonly_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV15ImageReadonly = "";
         AV43SDT_DynamicFormTranslation = new SdtSDT_DynamicFormTranslation(context);
         AV6CurrentWWPFormInstanceElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         AV33WWPFormElementMetadata = "";
         AV28WebSession = context.GetSession();
         ucBtnremoveimage = new GXUserControl();
         GXt_SdtWWP_FormInstance1 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         AV24UploadedFile = new SdtFileUploadData(context);
         AV7Data = "";
         AV26Validations = new GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation>( context, "WWP_DF_Validation", "Comforta_version2");
         AV22ThisValueStr = "";
         AV20Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV19Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV8DataCellNameClass = "";
         sStyleString = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         ucUcimages = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV30WWPDynamicFormMode = "";
         sCtrlAV32WWPFormElementId = "";
         sCtrlAV37WWPFormInstanceElementId = "";
         sCtrlAV21SessionId = "";
         sCtrlAV35WWPFormInstance = "";
         /* GeneXus formulas. */
      }

      private short AV32WWPFormElementId ;
      private short AV37WWPFormInstanceElementId ;
      private short AV21SessionId ;
      private short wcpOAV32WWPFormElementId ;
      private short wcpOAV37WWPFormInstanceElementId ;
      private short wcpOAV21SessionId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV5AuxSessionId ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short AV31WWPFormElementCaption ;
      private short nGXWrapped ;
      private int divDatatitlecell_Visible ;
      private int AV44GXV1 ;
      private int imgavImagereadonly_Visible ;
      private int AV46GXV2 ;
      private int AV47GXV3 ;
      private int Ucimages_Maxnumberoffiles ;
      private int idxLst ;
      private string AV30WWPDynamicFormMode ;
      private string wcpOAV30WWPDynamicFormMode ;
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
      private string lblDatatitle_Internalname ;
      private string lblDatatitle_Caption ;
      private string lblDatatitle_Jsonclick ;
      private string divDatacellname_Internalname ;
      private string divTablesplittedimagereadonly_Internalname ;
      private string divTextblockimagereadonly_cell_Internalname ;
      private string divTextblockimagereadonly_cell_Class ;
      private string lblTextblockimagereadonly_Internalname ;
      private string lblTextblockimagereadonly_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string imgavImagereadonly_Internalname ;
      private string Btnremoveimage_Internalname ;
      private string cellUcimagescell_Class ;
      private string cellUcimagescell_Internalname ;
      private string imgavImagereadonly_Class ;
      private string cellImagereadonly_cell_Class ;
      private string cellImagereadonly_cell_Internalname ;
      private string sStyleString ;
      private string tblTablemergedimagereadonly_Internalname ;
      private string ClassString ;
      private string imgavImagereadonly_gximage ;
      private string StyleString ;
      private string sImgUrl ;
      private string Ucimages_Tooltiptext ;
      private string Ucimages_Acceptedfiletypes ;
      private string Ucimages_Internalname ;
      private string Btnremoveimage_Tooltiptext ;
      private string Btnremoveimage_Beforeiconclass ;
      private string Btnremoveimage_Caption ;
      private string Btnremoveimage_Class ;
      private string sCtrlAV30WWPDynamicFormMode ;
      private string sCtrlAV32WWPFormElementId ;
      private string sCtrlAV37WWPFormInstanceElementId ;
      private string sCtrlAV21SessionId ;
      private string sCtrlAV35WWPFormInstance ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14HasReferenceId ;
      private bool AV13ExistElement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV16IsElementFocusable ;
      private bool AV9DataEnabled ;
      private bool Btnremoveimage_Visible ;
      private bool AV23UpdateImage ;
      private bool AV17IsRequired ;
      private bool AV18IsValid ;
      private bool AV15ImageReadonly_IsBlob ;
      private bool Ucimages_Autoupload ;
      private bool Ucimages_Hideadditionalbuttons ;
      private bool Ucimages_Enableuploadedfilecanceling ;
      private bool Ucimages_Autodisableaddingfiles ;
      private string AV34WWPFormElementTitle ;
      private string AV33WWPFormElementMetadata ;
      private string AV12ElementInternalName ;
      private string AV45Imagereadonly_GXI ;
      private string AV10DataExtension ;
      private string AV11DataFileName ;
      private string AV42ErrorIds ;
      private string AV22ThisValueStr ;
      private string AV8DataCellNameClass ;
      private string AV15ImageReadonly ;
      private string AV7Data ;
      private IGxSession AV28WebSession ;
      private GXUserControl ucBtnremoveimage ;
      private GXUserControl ucUcimages ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV35WWPFormInstance ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP4_WWPFormInstance ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ImageMetadata AV29WWP_DF_ImageMetadata ;
      private GXBaseCollection<SdtFileUploadData> AV25UploadedFiles ;
      private GXBaseCollection<SdtFileUploadData> AV38FailedFiles ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element AV36WWPFormInstanceElement ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression AV27VisibleCondition ;
      private SdtSDT_DynamicFormTranslation AV43SDT_DynamicFormTranslation ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element AV6CurrentWWPFormInstanceElement ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance GXt_SdtWWP_FormInstance1 ;
      private SdtFileUploadData AV24UploadedFile ;
      private GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation> AV26Validations ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV20Messages ;
      private GeneXus.Utils.SdtMessages_Message AV19Message ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
