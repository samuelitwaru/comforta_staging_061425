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
   public class wwp_df_numeric_wc : GXWebComponent
   {
      public wwp_df_numeric_wc( )
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

      public wwp_df_numeric_wc( IGxContext context )
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
         this.AV6WWPFormInstanceElementId = aP2_WWPFormInstanceElementId;
         this.AV24SessionId = aP3_SessionId;
         this.AV5WWPFormInstance = aP4_WWPFormInstance;
         ExecuteImpl();
         aP4_WWPFormInstance=this.AV5WWPFormInstance;
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
                  AV6WWPFormInstanceElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormInstanceElementId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV6WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV6WWPFormInstanceElementId), 4, 0));
                  AV24SessionId = (short)(Math.Round(NumberUtil.Val( GetPar( "SessionId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV24SessionId", StringUtil.LTrimStr( (decimal)(AV24SessionId), 4, 0));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV5WWPFormInstance);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV30WWPDynamicFormMode,(short)AV32WWPFormElementId,(short)AV6WWPFormInstanceElementId,(short)AV24SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV5WWPFormInstance});
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
            PA2P2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS2P2( ) ;
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
            context.SendWebValue( context.GetMessage( "WWP_Dynamic Form_Numeric_WC", "")) ;
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
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_df_numeric_wc.aspx"+UrlEncode(StringUtil.RTrim(AV30WWPDynamicFormMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV32WWPFormElementId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV6WWPFormInstanceElementId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV24SessionId,4,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.dynamicforms.wwp_df_numeric_wc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASREFERENCEID", AV15HasReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV15HasReferenceId, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_NUMERICMETADATA", AV29WWP_DF_NumericMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_NUMERICMETADATA", AV29WWP_DF_NumericMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_NUMERICMETADATA", GetSecureSignedToken( sPrefix, AV29WWP_DF_NumericMetadata, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTTITLE", AV34WWPFormElementTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTTITLE", GetSecureSignedToken( sPrefix, AV34WWPFormElementTitle, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV30WWPDynamicFormMode", StringUtil.RTrim( wcpOAV30WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV32WWPFormElementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV32WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6WWPFormInstanceElementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV6WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV24SessionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV24SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDATACONTROLVALUECHANGED", AV11DataControlValueChanged);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASREFERENCEID", AV15HasReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV15HasReferenceId, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORMINSTANCE", AV5WWPFormInstance);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORMINSTANCE", AV5WWPFormInstance);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMINSTANCEELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_NUMERICMETADATA", AV29WWP_DF_NumericMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_NUMERICMETADATA", AV29WWP_DF_NumericMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_NUMERICMETADATA", GetSecureSignedToken( sPrefix, AV29WWP_DF_NumericMetadata, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTTITLE", AV34WWPFormElementTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTTITLE", GetSecureSignedToken( sPrefix, AV34WWPFormElementTitle, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORMINSTANCEELEMENT", AV35WWPFormInstanceElement);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORMINSTANCEELEMENT", AV35WWPFormInstanceElement);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vERRORIDS", AV38ErrorIds);
         GxWebStd.gx_hidden_field( context, sPrefix+"vAUXSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7AuxSessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vEXISTELEMENT", AV14ExistElement);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vVISIBLECONDITION", AV27VisibleCondition);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vVISIBLECONDITION", AV27VisibleCondition);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV30WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"LAYOUTMAINTABLE_Class", StringUtil.RTrim( divLayoutmaintable_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"LAYOUTMAINTABLE_Class", StringUtil.RTrim( divLayoutmaintable_Class));
      }

      protected void RenderHtmlCloseForm2P2( )
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
         return "WorkWithPlus.DynamicForms.WWP_DF_Numeric_WC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WWP_Dynamic Form_Numeric_WC", "") ;
      }

      protected void WB2P0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "workwithplus.dynamicforms.wwp_df_numeric_wc.aspx");
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
            GxWebStd.gx_label_ctrl( context, lblDatatitle_Internalname, lblDatatitle_Caption, "", "", lblDatatitle_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DynFormDataDescription", 0, "", 1, 1, 0, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DF_Numeric_WC.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavData_Internalname, AV9Data, StringUtil.RTrim( context.localUtil.Format( AV9Data, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,14);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavData_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavData_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WorkWithPlus/DynamicForms/WWP_DF_Numeric_WC.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtnfixcontrolvaluechanged_Internalname, "", context.GetMessage( "GX_BtnRefresh", ""), bttBtnfixcontrolvaluechanged_Jsonclick, 5, context.GetMessage( "GX_BtnRefresh", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOFIXCONTROLVALUECHANGED\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/DynamicForms/WWP_DF_Numeric_WC.htm");
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

      protected void START2P2( )
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
            Form.Meta.addItem("description", context.GetMessage( "WWP_Dynamic Form_Numeric_WC", ""), 0) ;
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
               STRUP2P0( ) ;
            }
         }
      }

      protected void WS2P2( )
      {
         START2P2( ) ;
         EVT2P2( ) ;
      }

      protected void EVT2P2( )
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
                                 STRUP2P0( ) ;
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
                                 STRUP2P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E112P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFIXCONTROLVALUECHANGED'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoFixControlValueChanged' */
                                    E122P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.DYNAMICFORM_VALIDATE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E132P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E142P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDATA.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E152P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E162P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2P0( ) ;
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
                                 STRUP2P0( ) ;
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

      protected void WE2P2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2P2( ) ;
            }
         }
      }

      protected void PA2P2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.dynamicforms.wwp_df_numeric_wc.aspx")), "workwithplus.dynamicforms.wwp_df_numeric_wc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.dynamicforms.wwp_df_numeric_wc.aspx")))) ;
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
         RF2P2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF2P2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E162P2 ();
            WB2P0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2P2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASREFERENCEID", AV15HasReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV15HasReferenceId, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_NUMERICMETADATA", AV29WWP_DF_NumericMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_NUMERICMETADATA", AV29WWP_DF_NumericMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_NUMERICMETADATA", GetSecureSignedToken( sPrefix, AV29WWP_DF_NumericMetadata, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTTITLE", AV34WWPFormElementTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTTITLE", GetSecureSignedToken( sPrefix, AV34WWPFormElementTitle, context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2P0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E112P2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOAV30WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV30WWPDynamicFormMode");
            wcpOAV32WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV32WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV6WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6WWPFormInstanceElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV24SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV24SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            divLayoutmaintable_Class = cgiGet( sPrefix+"LAYOUTMAINTABLE_Class");
            /* Read variables values. */
            AV9Data = cgiGet( edtavData_Internalname);
            AssignAttri(sPrefix, false, "AV9Data", AV9Data);
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
         E112P2 ();
         if (returnInSub) return;
      }

      protected void E112P2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV39SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformid = AV5WWPFormInstance.gxTpr_Wwpformid;
         AV39SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformversionnumber = AV5WWPFormInstance.gxTpr_Wwpformversionnumber;
         AV39SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformelementid = AV32WWPFormElementId;
         new prc_getdynamicformtranslation(context ).execute( ref  AV39SDT_DynamicFormTranslation) ;
         AV18IsElementFocusable = true;
         AV15HasReferenceId = false;
         AssignAttri(sPrefix, false, "AV15HasReferenceId", AV15HasReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV15HasReferenceId, context));
         AV40GXV1 = 1;
         while ( AV40GXV1 <= AV5WWPFormInstance.gxTpr_Element.Count )
         {
            AV35WWPFormInstanceElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV5WWPFormInstance.gxTpr_Element.Item(AV40GXV1));
            if ( ( AV35WWPFormInstanceElement.gxTpr_Wwpformelementid == AV32WWPFormElementId ) && ( AV35WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid == AV6WWPFormInstanceElementId ) )
            {
               AV8CurrentWWPFormInstanceElement = AV35WWPFormInstanceElement;
               AV15HasReferenceId = (bool)((!String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV35WWPFormInstanceElement.gxTpr_Wwpformelementreferenceid)))));
               AssignAttri(sPrefix, false, "AV15HasReferenceId", AV15HasReferenceId);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV15HasReferenceId, context));
               AV34WWPFormElementTitle = AV35WWPFormInstanceElement.gxTpr_Wwpformelementtitle;
               AssignAttri(sPrefix, false, "AV34WWPFormElementTitle", AV34WWPFormElementTitle);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTTITLE", GetSecureSignedToken( sPrefix, AV34WWPFormElementTitle, context));
               AV33WWPFormElementMetadata = AV35WWPFormInstanceElement.gxTpr_Wwpformelementmetadata;
               AssignAttri(sPrefix, false, "AV33WWPFormElementMetadata", AV33WWPFormElementMetadata);
               AV31WWPFormElementCaption = AV35WWPFormInstanceElement.gxTpr_Wwpformelementcaption;
               AssignAttri(sPrefix, false, "AV31WWPFormElementCaption", StringUtil.Str( (decimal)(AV31WWPFormElementCaption), 1, 0));
               if (true) break;
            }
            AV40GXV1 = (int)(AV40GXV1+1);
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
         if ( AV18IsElementFocusable && ( StringUtil.StrCmp(divLayoutmaintable_Class, "Table") == 0 ) && ( StringUtil.StrCmp(AV28WebSession.Get("WWPDynFormSetFocus"), "") != 0 ) )
         {
            /* Execute user subroutine: 'SET FOCUS TO ELEMENT' */
            S132 ();
            if (returnInSub) return;
            AV28WebSession.Remove("WWPDynFormSetFocus");
         }
         if ( ( StringUtil.StrCmp(AV30WWPDynamicFormMode, "DSP") != 0 ) && ( StringUtil.StrCmp(AV30WWPDynamicFormMode, "DLT") != 0 ) )
         {
            AV12DataEnabled = true;
            AssignAttri(sPrefix, false, "AV12DataEnabled", AV12DataEnabled);
         }
         AV21Mask = "";
         AV17Integers = (short)(((AV29WWP_DF_NumericMetadata.gxTpr_Decimals==0) ? AV29WWP_DF_NumericMetadata.gxTpr_Length : AV29WWP_DF_NumericMetadata.gxTpr_Length-AV29WWP_DF_NumericMetadata.gxTpr_Decimals-1));
         AV16i = 1;
         while ( AV16i <= AV17Integers )
         {
            AV21Mask = "9" + AV21Mask;
            AV16i = (short)(AV16i+1);
         }
         if ( AV29WWP_DF_NumericMetadata.gxTpr_Decimals > 0 )
         {
            AV21Mask += "<DEC>";
            AV16i = 1;
            while ( AV16i <= AV29WWP_DF_NumericMetadata.gxTpr_Decimals )
            {
               AV21Mask += "9";
               AV16i = (short)(AV16i+1);
            }
         }
         this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "Mask_Apply", new Object[] {(string)edtavData_Internalname,(string)AV21Mask,(bool)false,(bool)false}, false);
         edtavData_Enabled = (AV12DataEnabled ? 1 : 0);
         AssignProp(sPrefix, false, edtavData_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavData_Enabled), 5, 0), true);
         this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "Control_FixControlValueChanged", new Object[] {(string)edtavData_Internalname,(string)bttBtnfixcontrolvaluechanged_Internalname}, false);
         AV11DataControlValueChanged = (AV29WWP_DF_NumericMetadata.gxTpr_Isrequired&&String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV9Data))) ? "." : AV9Data);
         AssignAttri(sPrefix, false, "AV11DataControlValueChanged", AV11DataControlValueChanged);
      }

      protected void E122P2( )
      {
         /* 'DoFixControlValueChanged' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV11DataControlValueChanged, AV9Data) != 0 )
         {
            AV11DataControlValueChanged = AV9Data;
            AssignAttri(sPrefix, false, "AV11DataControlValueChanged", AV11DataControlValueChanged);
            /* Execute user subroutine: 'DATA CONTROL VALUE CHANGED' */
            S142 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35WWPFormInstanceElement", AV35WWPFormInstanceElement);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV5WWPFormInstance", AV5WWPFormInstance);
      }

      protected void E132P2( )
      {
         /* General\GlobalEvents_Dynamicform_validate Routine */
         returnInSub = false;
         if ( ( AV7AuxSessionId == AV24SessionId ) && ( StringUtil.StrCmp(divLayoutmaintable_Class, "Invisible") != 0 ) && StringUtil.Contains( AV38ErrorIds, "|"+StringUtil.Trim( StringUtil.Str( (decimal)(AV32WWPFormElementId), 4, 0))+"."+StringUtil.Trim( StringUtil.Str( (decimal)(AV6WWPFormInstanceElementId), 4, 0))+"|") )
         {
            /* Execute user subroutine: 'SAVE ELEMENT DATA TO SESSION' */
            S152 ();
            if (returnInSub) return;
            if ( AV14ExistElement )
            {
               /* Execute user subroutine: 'EXECUTE VALIDATIONS' */
               S162 ();
               if (returnInSub) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35WWPFormInstanceElement", AV35WWPFormInstanceElement);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV5WWPFormInstance", AV5WWPFormInstance);
      }

      protected void E142P2( )
      {
         /* General\GlobalEvents_Dynamicform_updatevisibilities Routine */
         returnInSub = false;
         if ( ( AV7AuxSessionId == AV24SessionId ) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV27VisibleCondition.gxTpr_Expression))) )
         {
            /* Execute user subroutine: 'GET FORM INSTANCE' */
            S172 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'UPDATE VISIBILITY' */
            S122 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV5WWPFormInstance", AV5WWPFormInstance);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV27VisibleCondition", AV27VisibleCondition);
      }

      protected void S172( )
      {
         /* 'GET FORM INSTANCE' Routine */
         returnInSub = false;
         GXt_SdtWWP_FormInstance1 = AV5WWPFormInstance;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadforminstance(context ).execute(  AV24SessionId, out  GXt_SdtWWP_FormInstance1) ;
         AV5WWPFormInstance = GXt_SdtWWP_FormInstance1;
      }

      protected void S112( )
      {
         /* 'GET DATA FROM CURRENT ELEMENT' Routine */
         returnInSub = false;
         if ( NumberUtil.Val( AV8CurrentWWPFormInstanceElement.gxTpr_Wwpforminstanceelemchar, ".") == AV8CurrentWWPFormInstanceElement.gxTpr_Wwpforminstanceelemnumeric )
         {
            AV9Data = AV8CurrentWWPFormInstanceElement.gxTpr_Wwpforminstanceelemchar;
            AssignAttri(sPrefix, false, "AV9Data", AV9Data);
         }
         else
         {
            AV9Data = StringUtil.Trim( StringUtil.Str( AV8CurrentWWPFormInstanceElement.gxTpr_Wwpforminstanceelemnumeric, 18, 5));
            AssignAttri(sPrefix, false, "AV9Data", AV9Data);
         }
      }

      protected void S152( )
      {
         /* 'SAVE ELEMENT DATA TO SESSION' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GET FORM INSTANCE' */
         S172 ();
         if (returnInSub) return;
         AV14ExistElement = false;
         AssignAttri(sPrefix, false, "AV14ExistElement", AV14ExistElement);
         AV41GXV2 = 1;
         while ( AV41GXV2 <= AV5WWPFormInstance.gxTpr_Element.Count )
         {
            AV35WWPFormInstanceElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV5WWPFormInstance.gxTpr_Element.Item(AV41GXV2));
            if ( ( AV35WWPFormInstanceElement.gxTpr_Wwpformelementid == AV32WWPFormElementId ) && ( AV35WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid == AV6WWPFormInstanceElementId ) )
            {
               AV14ExistElement = true;
               AssignAttri(sPrefix, false, "AV14ExistElement", AV14ExistElement);
               if (true) break;
            }
            AV41GXV2 = (int)(AV41GXV2+1);
         }
         if ( AV14ExistElement )
         {
            /* Execute user subroutine: 'SET DATA TO ELEMENT' */
            S182 ();
            if (returnInSub) return;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_saveforminstance(context ).execute(  AV24SessionId,  AV5WWPFormInstance) ;
         }
      }

      protected void S182( )
      {
         /* 'SET DATA TO ELEMENT' Routine */
         returnInSub = false;
         AV35WWPFormInstanceElement.gxTpr_Wwpforminstanceelemchar = AV9Data;
         AV35WWPFormInstanceElement.gxTpr_Wwpforminstanceelemnumeric = NumberUtil.Val( AV9Data, ".");
      }

      protected void S122( )
      {
         /* 'UPDATE VISIBILITY' Routine */
         returnInSub = false;
         AV27VisibleCondition = AV29WWP_DF_NumericMetadata.gxTpr_Visiblecondition;
         if ( new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_evaluateelementvisibility(context).executeUdp(  AV5WWPFormInstance,  AV6WWPFormInstanceElementId,  AV27VisibleCondition) )
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
         AV19IsRequired = AV29WWP_DF_NumericMetadata.gxTpr_Isrequired;
         AV26Validations = AV29WWP_DF_NumericMetadata.gxTpr_Validations;
         AV25ThisValueStr = ((Convert.ToDecimal(0)==NumberUtil.Val( AV9Data, ".")) ? "''" : AV9Data);
         AV13ElementInternalName = edtavData_Internalname;
         AV20IsValid = true;
         if ( AV19IsRequired && ( StringUtil.StrCmp(StringUtil.Trim( AV25ThisValueStr), "''") == 0 ) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), AV34WWPFormElementTitle, "", "", "", "", "", "", "", ""),  "error",  AV13ElementInternalName,  "true",  ""));
            AV20IsValid = false;
         }
         else
         {
            if ( AV26Validations.Count > 0 )
            {
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_executeelementvalidations(context ).execute(  AV5WWPFormInstance,  AV6WWPFormInstanceElementId,  AV25ThisValueStr,  AV26Validations, out  AV23Messages) ;
               AV42GXV3 = 1;
               while ( AV42GXV3 <= AV23Messages.Count )
               {
                  AV22Message = ((GeneXus.Utils.SdtMessages_Message)AV23Messages.Item(AV42GXV3));
                  GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV22Message.gxTpr_Description,  ((AV22Message.gxTpr_Type==1) ? "error" : "info"),  AV13ElementInternalName,  "true",  ""));
                  if ( AV22Message.gxTpr_Type == 1 )
                  {
                     AV20IsValid = false;
                     if (true) break;
                  }
                  AV42GXV3 = (int)(AV42GXV3+1);
               }
            }
         }
      }

      protected void S192( )
      {
         /* 'LOAD TITLE AND METADATA' Routine */
         returnInSub = false;
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
         AV10DataCellNameClass = "DataContentCell DscTop";
         if ( AV31WWPFormElementCaption != 1 )
         {
            AV10DataCellNameClass += " DataContentCellNoLabel";
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV39SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationvalue)) )
         {
            edtavData_Caption = AV34WWPFormElementTitle;
            AssignProp(sPrefix, false, edtavData_Internalname, "Caption", edtavData_Caption, true);
         }
         else
         {
            edtavData_Caption = AV39SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationvalue;
            AssignProp(sPrefix, false, edtavData_Internalname, "Caption", edtavData_Caption, true);
         }
         AV29WWP_DF_NumericMetadata.FromJSonString(AV33WWPFormElementMetadata, null);
         if ( AV29WWP_DF_NumericMetadata.gxTpr_Isrequired )
         {
            AV10DataCellNameClass = "Required" + AV10DataCellNameClass;
         }
         divDatacellname_Class = AV10DataCellNameClass;
         AssignProp(sPrefix, false, divDatacellname_Internalname, "Class", divDatacellname_Class, true);
         divDatatitlecell_Class = AV10DataCellNameClass;
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

      protected void E152P2( )
      {
         /* Data_Controlvaluechanged Routine */
         returnInSub = false;
         AV11DataControlValueChanged = AV9Data;
         AssignAttri(sPrefix, false, "AV11DataControlValueChanged", AV11DataControlValueChanged);
         /* Execute user subroutine: 'DATA CONTROL VALUE CHANGED' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35WWPFormInstanceElement", AV35WWPFormInstanceElement);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV5WWPFormInstance", AV5WWPFormInstance);
      }

      protected void S142( )
      {
         /* 'DATA CONTROL VALUE CHANGED' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVE ELEMENT DATA TO SESSION' */
         S152 ();
         if (returnInSub) return;
         if ( AV15HasReferenceId )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "DynamicForm_UpdateVisibilities", new Object[] {(short)AV24SessionId}, true);
         }
         /* Execute user subroutine: 'EXECUTE VALIDATIONS' */
         S162 ();
         if (returnInSub) return;
      }

      protected void nextLoad( )
      {
      }

      protected void E162P2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV30WWPDynamicFormMode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV30WWPDynamicFormMode", AV30WWPDynamicFormMode);
         AV32WWPFormElementId = Convert.ToInt16(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV32WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV32WWPFormElementId), 4, 0));
         AV6WWPFormInstanceElementId = Convert.ToInt16(getParm(obj,2));
         AssignAttri(sPrefix, false, "AV6WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV6WWPFormInstanceElementId), 4, 0));
         AV24SessionId = Convert.ToInt16(getParm(obj,3));
         AssignAttri(sPrefix, false, "AV24SessionId", StringUtil.LTrimStr( (decimal)(AV24SessionId), 4, 0));
         AV5WWPFormInstance = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)getParm(obj,4);
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
         PA2P2( ) ;
         WS2P2( ) ;
         WE2P2( ) ;
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
         sCtrlAV6WWPFormInstanceElementId = (string)((string)getParm(obj,2));
         sCtrlAV24SessionId = (string)((string)getParm(obj,3));
         sCtrlAV5WWPFormInstance = (string)((string)getParm(obj,4));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2P2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "workwithplus\\dynamicforms\\wwp_df_numeric_wc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2P2( ) ;
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
            AV6WWPFormInstanceElementId = Convert.ToInt16(getParm(obj,4));
            AssignAttri(sPrefix, false, "AV6WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV6WWPFormInstanceElementId), 4, 0));
            AV24SessionId = Convert.ToInt16(getParm(obj,5));
            AssignAttri(sPrefix, false, "AV24SessionId", StringUtil.LTrimStr( (decimal)(AV24SessionId), 4, 0));
            AV5WWPFormInstance = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)getParm(obj,6);
         }
         wcpOAV30WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV30WWPDynamicFormMode");
         wcpOAV32WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV32WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV6WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6WWPFormInstanceElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV24SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV24SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV30WWPDynamicFormMode, wcpOAV30WWPDynamicFormMode) != 0 ) || ( AV32WWPFormElementId != wcpOAV32WWPFormElementId ) || ( AV6WWPFormInstanceElementId != wcpOAV6WWPFormInstanceElementId ) || ( AV24SessionId != wcpOAV24SessionId ) ) )
         {
            setjustcreated();
         }
         wcpOAV30WWPDynamicFormMode = AV30WWPDynamicFormMode;
         wcpOAV32WWPFormElementId = AV32WWPFormElementId;
         wcpOAV6WWPFormInstanceElementId = AV6WWPFormInstanceElementId;
         wcpOAV24SessionId = AV24SessionId;
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
         sCtrlAV6WWPFormInstanceElementId = cgiGet( sPrefix+"AV6WWPFormInstanceElementId_CTRL");
         if ( StringUtil.Len( sCtrlAV6WWPFormInstanceElementId) > 0 )
         {
            AV6WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV6WWPFormInstanceElementId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV6WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV6WWPFormInstanceElementId), 4, 0));
         }
         else
         {
            AV6WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV6WWPFormInstanceElementId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV24SessionId = cgiGet( sPrefix+"AV24SessionId_CTRL");
         if ( StringUtil.Len( sCtrlAV24SessionId) > 0 )
         {
            AV24SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV24SessionId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV24SessionId", StringUtil.LTrimStr( (decimal)(AV24SessionId), 4, 0));
         }
         else
         {
            AV24SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV24SessionId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV5WWPFormInstance = cgiGet( sPrefix+"AV5WWPFormInstance_CTRL");
         if ( StringUtil.Len( sCtrlAV5WWPFormInstance) > 0 )
         {
            AV5WWPFormInstance.FromXml(cgiGet( sCtrlAV5WWPFormInstance), null, "", "");
         }
         else
         {
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"AV5WWPFormInstance_PARM"), AV5WWPFormInstance);
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
         PA2P2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2P2( ) ;
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
         WS2P2( ) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6WWPFormInstanceElementId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6WWPFormInstanceElementId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6WWPFormInstanceElementId_CTRL", StringUtil.RTrim( sCtrlAV6WWPFormInstanceElementId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV24SessionId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV24SessionId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV24SessionId_CTRL", StringUtil.RTrim( sCtrlAV24SessionId));
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"AV5WWPFormInstance_PARM", AV5WWPFormInstance);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"AV5WWPFormInstance_PARM", AV5WWPFormInstance);
         }
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV5WWPFormInstance)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV5WWPFormInstance_CTRL", StringUtil.RTrim( sCtrlAV5WWPFormInstance));
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
         WE2P2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256201657252", true, true);
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
         context.AddJavascriptSource("workwithplus/dynamicforms/wwp_df_numeric_wc.js", "?20256201657253", false, true);
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV15HasReferenceId","fld":"vHASREFERENCEID","hsh":true},{"av":"AV29WWP_DF_NumericMetadata","fld":"vWWP_DF_NUMERICMETADATA","hsh":true},{"av":"AV34WWPFormElementTitle","fld":"vWWPFORMELEMENTTITLE","hsh":true}]}""");
         setEventMetadata("'DOFIXCONTROLVALUECHANGED'","""{"handler":"E122P2","iparms":[{"av":"AV11DataControlValueChanged","fld":"vDATACONTROLVALUECHANGED"},{"av":"AV9Data","fld":"vDATA"},{"av":"AV15HasReferenceId","fld":"vHASREFERENCEID","hsh":true},{"av":"AV24SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV5WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV32WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV6WWPFormInstanceElementId","fld":"vWWPFORMINSTANCEELEMENTID","pic":"ZZZ9"},{"av":"AV29WWP_DF_NumericMetadata","fld":"vWWP_DF_NUMERICMETADATA","hsh":true},{"av":"AV34WWPFormElementTitle","fld":"vWWPFORMELEMENTTITLE","hsh":true},{"av":"AV35WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"}]""");
         setEventMetadata("'DOFIXCONTROLVALUECHANGED'",""","oparms":[{"av":"AV11DataControlValueChanged","fld":"vDATACONTROLVALUECHANGED"},{"av":"AV14ExistElement","fld":"vEXISTELEMENT"},{"av":"AV35WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"},{"av":"AV5WWPFormInstance","fld":"vWWPFORMINSTANCE"}]}""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_VALIDATE","""{"handler":"E132P2","iparms":[{"av":"AV38ErrorIds","fld":"vERRORIDS"},{"av":"AV7AuxSessionId","fld":"vAUXSESSIONID","pic":"ZZZ9"},{"av":"AV24SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"divLayoutmaintable_Class","ctrl":"LAYOUTMAINTABLE","prop":"Class"},{"av":"AV32WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV6WWPFormInstanceElementId","fld":"vWWPFORMINSTANCEELEMENTID","pic":"ZZZ9"},{"av":"AV14ExistElement","fld":"vEXISTELEMENT"},{"av":"AV5WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV29WWP_DF_NumericMetadata","fld":"vWWP_DF_NUMERICMETADATA","hsh":true},{"av":"AV9Data","fld":"vDATA"},{"av":"AV34WWPFormElementTitle","fld":"vWWPFORMELEMENTTITLE","hsh":true},{"av":"AV35WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"}]""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_VALIDATE",""","oparms":[{"av":"AV14ExistElement","fld":"vEXISTELEMENT"},{"av":"AV35WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"},{"av":"AV5WWPFormInstance","fld":"vWWPFORMINSTANCE"}]}""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES","""{"handler":"E142P2","iparms":[{"av":"AV7AuxSessionId","fld":"vAUXSESSIONID","pic":"ZZZ9"},{"av":"AV24SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV27VisibleCondition","fld":"vVISIBLECONDITION"},{"av":"AV29WWP_DF_NumericMetadata","fld":"vWWP_DF_NUMERICMETADATA","hsh":true},{"av":"AV6WWPFormInstanceElementId","fld":"vWWPFORMINSTANCEELEMENTID","pic":"ZZZ9"},{"av":"AV5WWPFormInstance","fld":"vWWPFORMINSTANCE"}]""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES",""","oparms":[{"av":"AV5WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV27VisibleCondition","fld":"vVISIBLECONDITION"},{"av":"divLayoutmaintable_Class","ctrl":"LAYOUTMAINTABLE","prop":"Class"}]}""");
         setEventMetadata("VDATA.CONTROLVALUECHANGED","""{"handler":"E152P2","iparms":[{"av":"AV9Data","fld":"vDATA"},{"av":"AV15HasReferenceId","fld":"vHASREFERENCEID","hsh":true},{"av":"AV24SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV5WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV32WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV6WWPFormInstanceElementId","fld":"vWWPFORMINSTANCEELEMENTID","pic":"ZZZ9"},{"av":"AV29WWP_DF_NumericMetadata","fld":"vWWP_DF_NUMERICMETADATA","hsh":true},{"av":"AV34WWPFormElementTitle","fld":"vWWPFORMELEMENTTITLE","hsh":true},{"av":"AV35WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"}]""");
         setEventMetadata("VDATA.CONTROLVALUECHANGED",""","oparms":[{"av":"AV11DataControlValueChanged","fld":"vDATACONTROLVALUECHANGED"},{"av":"AV14ExistElement","fld":"vEXISTELEMENT"},{"av":"AV35WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"},{"av":"AV5WWPFormInstance","fld":"vWWPFORMINSTANCE"}]}""");
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
         AV5WWPFormInstance = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         wcpOAV30WWPDynamicFormMode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV29WWP_DF_NumericMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_NumericMetadata(context);
         AV34WWPFormElementTitle = "";
         AV11DataControlValueChanged = "";
         AV35WWPFormInstanceElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         AV38ErrorIds = "";
         AV27VisibleCondition = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression(context);
         GX_FocusControl = "";
         lblDatatitle_Jsonclick = "";
         TempTags = "";
         AV9Data = "";
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
         AV39SDT_DynamicFormTranslation = new SdtSDT_DynamicFormTranslation(context);
         AV8CurrentWWPFormInstanceElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         AV33WWPFormElementMetadata = "";
         AV28WebSession = context.GetSession();
         AV21Mask = "";
         GXt_SdtWWP_FormInstance1 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         AV26Validations = new GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation>( context, "WWP_DF_Validation", "Comforta_version2");
         AV25ThisValueStr = "";
         AV13ElementInternalName = "";
         AV23Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV22Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV10DataCellNameClass = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV30WWPDynamicFormMode = "";
         sCtrlAV32WWPFormElementId = "";
         sCtrlAV6WWPFormInstanceElementId = "";
         sCtrlAV24SessionId = "";
         sCtrlAV5WWPFormInstance = "";
         /* GeneXus formulas. */
      }

      private short AV32WWPFormElementId ;
      private short AV6WWPFormInstanceElementId ;
      private short AV24SessionId ;
      private short wcpOAV32WWPFormElementId ;
      private short wcpOAV6WWPFormInstanceElementId ;
      private short wcpOAV24SessionId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV7AuxSessionId ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short AV31WWPFormElementCaption ;
      private short AV17Integers ;
      private short AV16i ;
      private short nGXWrapped ;
      private int divDatatitlecell_Visible ;
      private int edtavData_Enabled ;
      private int AV40GXV1 ;
      private int AV41GXV2 ;
      private int AV42GXV3 ;
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
      private string divDatatitlecell_Class ;
      private string lblDatatitle_Internalname ;
      private string lblDatatitle_Caption ;
      private string lblDatatitle_Jsonclick ;
      private string divDatacellname_Internalname ;
      private string divDatacellname_Class ;
      private string edtavData_Internalname ;
      private string edtavData_Caption ;
      private string TempTags ;
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
      private string sCtrlAV30WWPDynamicFormMode ;
      private string sCtrlAV32WWPFormElementId ;
      private string sCtrlAV6WWPFormInstanceElementId ;
      private string sCtrlAV24SessionId ;
      private string sCtrlAV5WWPFormInstance ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15HasReferenceId ;
      private bool AV14ExistElement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV18IsElementFocusable ;
      private bool AV12DataEnabled ;
      private bool AV19IsRequired ;
      private bool AV20IsValid ;
      private string AV34WWPFormElementTitle ;
      private string AV33WWPFormElementMetadata ;
      private string AV11DataControlValueChanged ;
      private string AV38ErrorIds ;
      private string AV9Data ;
      private string AV21Mask ;
      private string AV25ThisValueStr ;
      private string AV13ElementInternalName ;
      private string AV10DataCellNameClass ;
      private IGxSession AV28WebSession ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV5WWPFormInstance ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP4_WWPFormInstance ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_NumericMetadata AV29WWP_DF_NumericMetadata ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element AV35WWPFormInstanceElement ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression AV27VisibleCondition ;
      private SdtSDT_DynamicFormTranslation AV39SDT_DynamicFormTranslation ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element AV8CurrentWWPFormInstanceElement ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance GXt_SdtWWP_FormInstance1 ;
      private GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation> AV26Validations ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV23Messages ;
      private GeneXus.Utils.SdtMessages_Message AV22Message ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
