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
   public class wwp_df_datetime_wc : GXWebComponent
   {
      public wwp_df_datetime_wc( )
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

      public wwp_df_datetime_wc( IGxContext context )
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
         this.AV26WWPDynamicFormMode = aP0_WWPDynamicFormMode;
         this.AV27WWPFormElementId = aP1_WWPFormElementId;
         this.AV6WWPFormInstanceElementId = aP2_WWPFormInstanceElementId;
         this.AV20SessionId = aP3_SessionId;
         this.AV30WWPFormInstance = aP4_WWPFormInstance;
         ExecuteImpl();
         aP4_WWPFormInstance=this.AV30WWPFormInstance;
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
                  AV26WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
                  AssignAttri(sPrefix, false, "AV26WWPDynamicFormMode", AV26WWPDynamicFormMode);
                  AV27WWPFormElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV27WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV27WWPFormElementId), 4, 0));
                  AV6WWPFormInstanceElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormInstanceElementId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV6WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV6WWPFormInstanceElementId), 4, 0));
                  AV20SessionId = (short)(Math.Round(NumberUtil.Val( GetPar( "SessionId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV20SessionId", StringUtil.LTrimStr( (decimal)(AV20SessionId), 4, 0));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV30WWPFormInstance);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV26WWPDynamicFormMode,(short)AV27WWPFormElementId,(short)AV6WWPFormInstanceElementId,(short)AV20SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV30WWPFormInstance});
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
            PA2O2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS2O2( ) ;
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
            context.SendWebValue( context.GetMessage( "WWP_Dynamic Form_Datetime_WC", "")) ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-"+StringUtil.Substring( context.GetLanguageProperty( "culture"), 1, 2)+".js", "?"+context.GetBuildNumber( 1918140), false, true);
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
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_df_datetime_wc.aspx"+UrlEncode(StringUtil.RTrim(AV26WWPDynamicFormMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV27WWPFormElementId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV6WWPFormInstanceElementId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV20SessionId,4,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.dynamicforms.wwp_df_datetime_wc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_DATEMETADATA", AV25WWP_DF_DateMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_DATEMETADATA", AV25WWP_DF_DateMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_DATEMETADATA", GetSecureSignedToken( sPrefix, AV25WWP_DF_DateMetadata, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTTITLE", AV29WWPFormElementTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTTITLE", GetSecureSignedToken( sPrefix, AV29WWPFormElementTitle, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASREFERENCEID", AV14HasReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV14HasReferenceId, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV26WWPDynamicFormMode", StringUtil.RTrim( wcpOAV26WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV27WWPFormElementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV27WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6WWPFormInstanceElementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV6WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV20SessionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV20SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vERRORIDS", AV35ErrorIds);
         GxWebStd.gx_hidden_field( context, sPrefix+"vAUXSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7AuxSessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMINSTANCEELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vEXISTELEMENT", AV13ExistElement);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORMINSTANCE", AV30WWPFormInstance);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORMINSTANCE", AV30WWPFormInstance);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_DATEMETADATA", AV25WWP_DF_DateMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_DATEMETADATA", AV25WWP_DF_DateMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_DATEMETADATA", GetSecureSignedToken( sPrefix, AV25WWP_DF_DateMetadata, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTTITLE", AV29WWPFormElementTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTTITLE", GetSecureSignedToken( sPrefix, AV29WWPFormElementTitle, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORMINSTANCEELEMENT", AV31WWPFormInstanceElement);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORMINSTANCEELEMENT", AV31WWPFormInstanceElement);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vVISIBLECONDITION", AV23VisibleCondition);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vVISIBLECONDITION", AV23VisibleCondition);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASREFERENCEID", AV14HasReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV14HasReferenceId, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV26WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"LAYOUTMAINTABLE_Class", StringUtil.RTrim( divLayoutmaintable_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"LAYOUTMAINTABLE_Class", StringUtil.RTrim( divLayoutmaintable_Class));
      }

      protected void RenderHtmlCloseForm2O2( )
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
         return "WorkWithPlus.DynamicForms.WWP_DF_Datetime_WC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WWP_Dynamic Form_Datetime_WC", "") ;
      }

      protected void WB2O0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "workwithplus.dynamicforms.wwp_df_datetime_wc.aspx");
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
            GxWebStd.gx_label_ctrl( context, lblDatatitle_Internalname, lblDatatitle_Caption, "", "", lblDatatitle_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DynFormDataDescription", 0, "", 1, 1, 0, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DF_Datetime_WC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDatacellname_Internalname, 1, 0, "px", 0, "px", divDatacellname_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavData_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavData_Internalname, edtavData_Caption, " AttributeDateTimeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavData_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavData_Internalname, context.localUtil.TToC( AV9Data, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( AV9Data, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,14);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavData_Jsonclick, 0, "AttributeDateTime", "", "", "", "", 1, edtavData_Enabled, 1, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 0, -1, 0, false, "", "end", false, "", "HLP_WorkWithPlus/DynamicForms/WWP_DF_Datetime_WC.htm");
            GxWebStd.gx_bitmap( context, edtavData_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavData_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WorkWithPlus/DynamicForms/WWP_DF_Datetime_WC.htm");
            context.WriteHtmlTextNl( "</div>") ;
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

      protected void START2O2( )
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
            Form.Meta.addItem("description", context.GetMessage( "WWP_Dynamic Form_Datetime_WC", ""), 0) ;
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
               STRUP2O0( ) ;
            }
         }
      }

      protected void WS2O2( )
      {
         START2O2( ) ;
         EVT2O2( ) ;
      }

      protected void EVT2O2( )
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
                                 STRUP2O0( ) ;
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
                                 STRUP2O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E112O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.DYNAMICFORM_VALIDATE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E122O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E132O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDATA.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E142O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E152O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2O0( ) ;
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
                                 STRUP2O0( ) ;
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

      protected void WE2O2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2O2( ) ;
            }
         }
      }

      protected void PA2O2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.dynamicforms.wwp_df_datetime_wc.aspx")), "workwithplus.dynamicforms.wwp_df_datetime_wc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.dynamicforms.wwp_df_datetime_wc.aspx")))) ;
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
         RF2O2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF2O2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E152O2 ();
            WB2O0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2O2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_DATEMETADATA", AV25WWP_DF_DateMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_DATEMETADATA", AV25WWP_DF_DateMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_DATEMETADATA", GetSecureSignedToken( sPrefix, AV25WWP_DF_DateMetadata, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTTITLE", AV29WWPFormElementTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTTITLE", GetSecureSignedToken( sPrefix, AV29WWPFormElementTitle, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASREFERENCEID", AV14HasReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV14HasReferenceId, context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2O0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E112O2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOAV26WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV26WWPDynamicFormMode");
            wcpOAV27WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV27WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV6WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6WWPFormInstanceElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV20SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV20SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         E112O2 ();
         if (returnInSub) return;
      }

      protected void E112O2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV36SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformid = AV30WWPFormInstance.gxTpr_Wwpformid;
         AV36SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformversionnumber = AV30WWPFormInstance.gxTpr_Wwpformversionnumber;
         AV36SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformelementid = AV27WWPFormElementId;
         new prc_getdynamicformtranslation(context ).execute( ref  AV36SDT_DynamicFormTranslation) ;
         AV15IsElementFocusable = true;
         AV14HasReferenceId = false;
         AssignAttri(sPrefix, false, "AV14HasReferenceId", AV14HasReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV14HasReferenceId, context));
         AV37GXV1 = 1;
         while ( AV37GXV1 <= AV30WWPFormInstance.gxTpr_Element.Count )
         {
            AV31WWPFormInstanceElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV30WWPFormInstance.gxTpr_Element.Item(AV37GXV1));
            if ( ( AV31WWPFormInstanceElement.gxTpr_Wwpformelementid == AV27WWPFormElementId ) && ( AV31WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid == AV6WWPFormInstanceElementId ) )
            {
               AV8CurrentWWPFormInstanceElement = AV31WWPFormInstanceElement;
               AV14HasReferenceId = (bool)((!String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV31WWPFormInstanceElement.gxTpr_Wwpformelementreferenceid)))));
               AssignAttri(sPrefix, false, "AV14HasReferenceId", AV14HasReferenceId);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV14HasReferenceId, context));
               AV29WWPFormElementTitle = AV31WWPFormInstanceElement.gxTpr_Wwpformelementtitle;
               AssignAttri(sPrefix, false, "AV29WWPFormElementTitle", AV29WWPFormElementTitle);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTTITLE", GetSecureSignedToken( sPrefix, AV29WWPFormElementTitle, context));
               AV28WWPFormElementMetadata = AV31WWPFormInstanceElement.gxTpr_Wwpformelementmetadata;
               AssignAttri(sPrefix, false, "AV28WWPFormElementMetadata", AV28WWPFormElementMetadata);
               AV5WWPFormElementCaption = AV31WWPFormInstanceElement.gxTpr_Wwpformelementcaption;
               AssignAttri(sPrefix, false, "AV5WWPFormElementCaption", StringUtil.Str( (decimal)(AV5WWPFormElementCaption), 1, 0));
               if (true) break;
            }
            AV37GXV1 = (int)(AV37GXV1+1);
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
         if ( AV15IsElementFocusable && ( StringUtil.StrCmp(divLayoutmaintable_Class, "Table") == 0 ) && ( StringUtil.StrCmp(AV24WebSession.Get("WWPDynFormSetFocus"), "") != 0 ) )
         {
            /* Execute user subroutine: 'SET FOCUS TO ELEMENT' */
            S132 ();
            if (returnInSub) return;
            AV24WebSession.Remove("WWPDynFormSetFocus");
         }
         if ( ( StringUtil.StrCmp(AV26WWPDynamicFormMode, "DSP") != 0 ) && ( StringUtil.StrCmp(AV26WWPDynamicFormMode, "DLT") != 0 ) )
         {
            AV11DataEnabled = true;
            AssignAttri(sPrefix, false, "AV11DataEnabled", AV11DataEnabled);
         }
         edtavData_Enabled = (AV11DataEnabled ? 1 : 0);
         AssignProp(sPrefix, false, edtavData_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavData_Enabled), 5, 0), true);
      }

      protected void E122O2( )
      {
         /* General\GlobalEvents_Dynamicform_validate Routine */
         returnInSub = false;
         if ( ( AV7AuxSessionId == AV20SessionId ) && ( StringUtil.StrCmp(divLayoutmaintable_Class, "Invisible") != 0 ) && StringUtil.Contains( AV35ErrorIds, "|"+StringUtil.Trim( StringUtil.Str( (decimal)(AV27WWPFormElementId), 4, 0))+"."+StringUtil.Trim( StringUtil.Str( (decimal)(AV6WWPFormInstanceElementId), 4, 0))+"|") )
         {
            /* Execute user subroutine: 'SAVE ELEMENT DATA TO SESSION' */
            S142 ();
            if (returnInSub) return;
            if ( AV13ExistElement )
            {
               /* Execute user subroutine: 'EXECUTE VALIDATIONS' */
               S152 ();
               if (returnInSub) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV31WWPFormInstanceElement", AV31WWPFormInstanceElement);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV30WWPFormInstance", AV30WWPFormInstance);
      }

      protected void E132O2( )
      {
         /* General\GlobalEvents_Dynamicform_updatevisibilities Routine */
         returnInSub = false;
         if ( ( AV7AuxSessionId == AV20SessionId ) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV23VisibleCondition.gxTpr_Expression))) )
         {
            /* Execute user subroutine: 'GET FORM INSTANCE' */
            S162 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'UPDATE VISIBILITY' */
            S122 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV30WWPFormInstance", AV30WWPFormInstance);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23VisibleCondition", AV23VisibleCondition);
      }

      protected void S162( )
      {
         /* 'GET FORM INSTANCE' Routine */
         returnInSub = false;
         GXt_SdtWWP_FormInstance1 = AV30WWPFormInstance;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadforminstance(context ).execute(  AV20SessionId, out  GXt_SdtWWP_FormInstance1) ;
         AV30WWPFormInstance = GXt_SdtWWP_FormInstance1;
      }

      protected void S112( )
      {
         /* 'GET DATA FROM CURRENT ELEMENT' Routine */
         returnInSub = false;
         AV9Data = AV8CurrentWWPFormInstanceElement.gxTpr_Wwpforminstanceelemdatetime;
         AssignAttri(sPrefix, false, "AV9Data", context.localUtil.TToC( AV9Data, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
      }

      protected void S142( )
      {
         /* 'SAVE ELEMENT DATA TO SESSION' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GET FORM INSTANCE' */
         S162 ();
         if (returnInSub) return;
         AV13ExistElement = false;
         AssignAttri(sPrefix, false, "AV13ExistElement", AV13ExistElement);
         AV38GXV2 = 1;
         while ( AV38GXV2 <= AV30WWPFormInstance.gxTpr_Element.Count )
         {
            AV31WWPFormInstanceElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV30WWPFormInstance.gxTpr_Element.Item(AV38GXV2));
            if ( ( AV31WWPFormInstanceElement.gxTpr_Wwpformelementid == AV27WWPFormElementId ) && ( AV31WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid == AV6WWPFormInstanceElementId ) )
            {
               AV13ExistElement = true;
               AssignAttri(sPrefix, false, "AV13ExistElement", AV13ExistElement);
               if (true) break;
            }
            AV38GXV2 = (int)(AV38GXV2+1);
         }
         if ( AV13ExistElement )
         {
            /* Execute user subroutine: 'SET DATA TO ELEMENT' */
            S172 ();
            if (returnInSub) return;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_saveforminstance(context ).execute(  AV20SessionId,  AV30WWPFormInstance) ;
         }
      }

      protected void S172( )
      {
         /* 'SET DATA TO ELEMENT' Routine */
         returnInSub = false;
         AV31WWPFormInstanceElement.gxTpr_Wwpforminstanceelemdatetime = AV9Data;
      }

      protected void S122( )
      {
         /* 'UPDATE VISIBILITY' Routine */
         returnInSub = false;
         AV23VisibleCondition = AV25WWP_DF_DateMetadata.gxTpr_Visiblecondition;
         if ( new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_evaluateelementvisibility(context).executeUdp(  AV30WWPFormInstance,  AV6WWPFormInstanceElementId,  AV23VisibleCondition) )
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
         AV16IsRequired = AV25WWP_DF_DateMetadata.gxTpr_Isrequired;
         AV22Validations = AV25WWP_DF_DateMetadata.gxTpr_Validations;
         if ( (DateTime.MinValue==AV9Data) )
         {
            AV21ThisValueStr = "''";
         }
         else
         {
            GXt_decimal2 = AV32DateTimeNumber;
            new WorkWithPlus.workwithplus_dynamicforms.wwp_df_getdatetimenumber(context ).execute(  AV9Data, out  GXt_decimal2) ;
            AV32DateTimeNumber = GXt_decimal2;
            AV21ThisValueStr = StringUtil.Trim( StringUtil.Str( AV32DateTimeNumber, 13, 4));
         }
         AV12ElementInternalName = edtavData_Internalname;
         AV17IsValid = true;
         if ( AV16IsRequired && ( StringUtil.StrCmp(StringUtil.Trim( AV21ThisValueStr), "''") == 0 ) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), AV29WWPFormElementTitle, "", "", "", "", "", "", "", ""),  "error",  AV12ElementInternalName,  "true",  ""));
            AV17IsValid = false;
         }
         else
         {
            if ( AV22Validations.Count > 0 )
            {
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_executeelementvalidations(context ).execute(  AV30WWPFormInstance,  AV6WWPFormInstanceElementId,  AV21ThisValueStr,  AV22Validations, out  AV19Messages) ;
               AV39GXV3 = 1;
               while ( AV39GXV3 <= AV19Messages.Count )
               {
                  AV18Message = ((GeneXus.Utils.SdtMessages_Message)AV19Messages.Item(AV39GXV3));
                  GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV18Message.gxTpr_Description,  ((AV18Message.gxTpr_Type==1) ? "error" : "info"),  AV12ElementInternalName,  "true",  ""));
                  if ( AV18Message.gxTpr_Type == 1 )
                  {
                     AV17IsValid = false;
                     if (true) break;
                  }
                  AV39GXV3 = (int)(AV39GXV3+1);
               }
            }
         }
      }

      protected void S182( )
      {
         /* 'LOAD TITLE AND METADATA' Routine */
         returnInSub = false;
         if ( AV5WWPFormElementCaption == 2 )
         {
            lblDatatitle_Caption = AV29WWPFormElementTitle;
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
         if ( AV5WWPFormElementCaption != 1 )
         {
            AV10DataCellNameClass += " DataContentCellNoLabel";
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV36SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationvalue)) )
         {
            edtavData_Caption = AV29WWPFormElementTitle;
            AssignProp(sPrefix, false, edtavData_Internalname, "Caption", edtavData_Caption, true);
         }
         else
         {
            edtavData_Caption = AV36SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationvalue;
            AssignProp(sPrefix, false, edtavData_Internalname, "Caption", edtavData_Caption, true);
         }
         AV25WWP_DF_DateMetadata.FromJSonString(AV28WWPFormElementMetadata, null);
         if ( AV25WWP_DF_DateMetadata.gxTpr_Isrequired )
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

      protected void E142O2( )
      {
         /* Data_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVE ELEMENT DATA TO SESSION' */
         S142 ();
         if (returnInSub) return;
         if ( AV14HasReferenceId )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "DynamicForm_UpdateVisibilities", new Object[] {(short)AV20SessionId}, true);
         }
         /* Execute user subroutine: 'EXECUTE VALIDATIONS' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV31WWPFormInstanceElement", AV31WWPFormInstanceElement);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV30WWPFormInstance", AV30WWPFormInstance);
      }

      protected void nextLoad( )
      {
      }

      protected void E152O2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV26WWPDynamicFormMode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV26WWPDynamicFormMode", AV26WWPDynamicFormMode);
         AV27WWPFormElementId = Convert.ToInt16(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV27WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV27WWPFormElementId), 4, 0));
         AV6WWPFormInstanceElementId = Convert.ToInt16(getParm(obj,2));
         AssignAttri(sPrefix, false, "AV6WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV6WWPFormInstanceElementId), 4, 0));
         AV20SessionId = Convert.ToInt16(getParm(obj,3));
         AssignAttri(sPrefix, false, "AV20SessionId", StringUtil.LTrimStr( (decimal)(AV20SessionId), 4, 0));
         AV30WWPFormInstance = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)getParm(obj,4);
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
         PA2O2( ) ;
         WS2O2( ) ;
         WE2O2( ) ;
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
         sCtrlAV26WWPDynamicFormMode = (string)((string)getParm(obj,0));
         sCtrlAV27WWPFormElementId = (string)((string)getParm(obj,1));
         sCtrlAV6WWPFormInstanceElementId = (string)((string)getParm(obj,2));
         sCtrlAV20SessionId = (string)((string)getParm(obj,3));
         sCtrlAV30WWPFormInstance = (string)((string)getParm(obj,4));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2O2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "workwithplus\\dynamicforms\\wwp_df_datetime_wc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2O2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV26WWPDynamicFormMode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV26WWPDynamicFormMode", AV26WWPDynamicFormMode);
            AV27WWPFormElementId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV27WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV27WWPFormElementId), 4, 0));
            AV6WWPFormInstanceElementId = Convert.ToInt16(getParm(obj,4));
            AssignAttri(sPrefix, false, "AV6WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV6WWPFormInstanceElementId), 4, 0));
            AV20SessionId = Convert.ToInt16(getParm(obj,5));
            AssignAttri(sPrefix, false, "AV20SessionId", StringUtil.LTrimStr( (decimal)(AV20SessionId), 4, 0));
            AV30WWPFormInstance = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)getParm(obj,6);
         }
         wcpOAV26WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV26WWPDynamicFormMode");
         wcpOAV27WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV27WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV6WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6WWPFormInstanceElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV20SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV20SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV26WWPDynamicFormMode, wcpOAV26WWPDynamicFormMode) != 0 ) || ( AV27WWPFormElementId != wcpOAV27WWPFormElementId ) || ( AV6WWPFormInstanceElementId != wcpOAV6WWPFormInstanceElementId ) || ( AV20SessionId != wcpOAV20SessionId ) ) )
         {
            setjustcreated();
         }
         wcpOAV26WWPDynamicFormMode = AV26WWPDynamicFormMode;
         wcpOAV27WWPFormElementId = AV27WWPFormElementId;
         wcpOAV6WWPFormInstanceElementId = AV6WWPFormInstanceElementId;
         wcpOAV20SessionId = AV20SessionId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV26WWPDynamicFormMode = cgiGet( sPrefix+"AV26WWPDynamicFormMode_CTRL");
         if ( StringUtil.Len( sCtrlAV26WWPDynamicFormMode) > 0 )
         {
            AV26WWPDynamicFormMode = cgiGet( sCtrlAV26WWPDynamicFormMode);
            AssignAttri(sPrefix, false, "AV26WWPDynamicFormMode", AV26WWPDynamicFormMode);
         }
         else
         {
            AV26WWPDynamicFormMode = cgiGet( sPrefix+"AV26WWPDynamicFormMode_PARM");
         }
         sCtrlAV27WWPFormElementId = cgiGet( sPrefix+"AV27WWPFormElementId_CTRL");
         if ( StringUtil.Len( sCtrlAV27WWPFormElementId) > 0 )
         {
            AV27WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV27WWPFormElementId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV27WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV27WWPFormElementId), 4, 0));
         }
         else
         {
            AV27WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV27WWPFormElementId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         sCtrlAV20SessionId = cgiGet( sPrefix+"AV20SessionId_CTRL");
         if ( StringUtil.Len( sCtrlAV20SessionId) > 0 )
         {
            AV20SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV20SessionId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV20SessionId", StringUtil.LTrimStr( (decimal)(AV20SessionId), 4, 0));
         }
         else
         {
            AV20SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV20SessionId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV30WWPFormInstance = cgiGet( sPrefix+"AV30WWPFormInstance_CTRL");
         if ( StringUtil.Len( sCtrlAV30WWPFormInstance) > 0 )
         {
            AV30WWPFormInstance.FromXml(cgiGet( sCtrlAV30WWPFormInstance), null, "", "");
         }
         else
         {
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"AV30WWPFormInstance_PARM"), AV30WWPFormInstance);
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
         PA2O2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2O2( ) ;
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
         WS2O2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV26WWPDynamicFormMode_PARM", StringUtil.RTrim( AV26WWPDynamicFormMode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV26WWPDynamicFormMode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV26WWPDynamicFormMode_CTRL", StringUtil.RTrim( sCtrlAV26WWPDynamicFormMode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV27WWPFormElementId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV27WWPFormElementId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV27WWPFormElementId_CTRL", StringUtil.RTrim( sCtrlAV27WWPFormElementId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6WWPFormInstanceElementId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6WWPFormInstanceElementId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6WWPFormInstanceElementId_CTRL", StringUtil.RTrim( sCtrlAV6WWPFormInstanceElementId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV20SessionId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV20SessionId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV20SessionId_CTRL", StringUtil.RTrim( sCtrlAV20SessionId));
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"AV30WWPFormInstance_PARM", AV30WWPFormInstance);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"AV30WWPFormInstance_PARM", AV30WWPFormInstance);
         }
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV30WWPFormInstance)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV30WWPFormInstance_CTRL", StringUtil.RTrim( sCtrlAV30WWPFormInstance));
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
         WE2O2( ) ;
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
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025614524551", true, true);
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
         context.AddJavascriptSource("workwithplus/dynamicforms/wwp_df_datetime_wc.js", "?2025614524552", false, true);
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV25WWP_DF_DateMetadata","fld":"vWWP_DF_DATEMETADATA","hsh":true},{"av":"AV29WWPFormElementTitle","fld":"vWWPFORMELEMENTTITLE","hsh":true},{"av":"AV14HasReferenceId","fld":"vHASREFERENCEID","hsh":true}]}""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_VALIDATE","""{"handler":"E122O2","iparms":[{"av":"AV35ErrorIds","fld":"vERRORIDS"},{"av":"AV7AuxSessionId","fld":"vAUXSESSIONID","pic":"ZZZ9"},{"av":"AV20SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"divLayoutmaintable_Class","ctrl":"LAYOUTMAINTABLE","prop":"Class"},{"av":"AV27WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV6WWPFormInstanceElementId","fld":"vWWPFORMINSTANCEELEMENTID","pic":"ZZZ9"},{"av":"AV13ExistElement","fld":"vEXISTELEMENT"},{"av":"AV30WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV25WWP_DF_DateMetadata","fld":"vWWP_DF_DATEMETADATA","hsh":true},{"av":"AV9Data","fld":"vDATA","pic":"99/99/99 99:99"},{"av":"AV29WWPFormElementTitle","fld":"vWWPFORMELEMENTTITLE","hsh":true},{"av":"AV31WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"}]""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_VALIDATE",""","oparms":[{"av":"AV13ExistElement","fld":"vEXISTELEMENT"},{"av":"AV31WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"},{"av":"AV30WWPFormInstance","fld":"vWWPFORMINSTANCE"}]}""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES","""{"handler":"E132O2","iparms":[{"av":"AV7AuxSessionId","fld":"vAUXSESSIONID","pic":"ZZZ9"},{"av":"AV20SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV23VisibleCondition","fld":"vVISIBLECONDITION"},{"av":"AV25WWP_DF_DateMetadata","fld":"vWWP_DF_DATEMETADATA","hsh":true},{"av":"AV6WWPFormInstanceElementId","fld":"vWWPFORMINSTANCEELEMENTID","pic":"ZZZ9"},{"av":"AV30WWPFormInstance","fld":"vWWPFORMINSTANCE"}]""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES",""","oparms":[{"av":"AV30WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV23VisibleCondition","fld":"vVISIBLECONDITION"},{"av":"divLayoutmaintable_Class","ctrl":"LAYOUTMAINTABLE","prop":"Class"}]}""");
         setEventMetadata("VDATA.CONTROLVALUECHANGED","""{"handler":"E142O2","iparms":[{"av":"AV14HasReferenceId","fld":"vHASREFERENCEID","hsh":true},{"av":"AV20SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV30WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV27WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV6WWPFormInstanceElementId","fld":"vWWPFORMINSTANCEELEMENTID","pic":"ZZZ9"},{"av":"AV25WWP_DF_DateMetadata","fld":"vWWP_DF_DATEMETADATA","hsh":true},{"av":"AV9Data","fld":"vDATA","pic":"99/99/99 99:99"},{"av":"AV29WWPFormElementTitle","fld":"vWWPFORMELEMENTTITLE","hsh":true},{"av":"AV31WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"}]""");
         setEventMetadata("VDATA.CONTROLVALUECHANGED",""","oparms":[{"av":"AV13ExistElement","fld":"vEXISTELEMENT"},{"av":"AV31WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"},{"av":"AV30WWPFormInstance","fld":"vWWPFORMINSTANCE"}]}""");
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
         AV30WWPFormInstance = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         wcpOAV26WWPDynamicFormMode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV25WWP_DF_DateMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_DateMetadata(context);
         AV29WWPFormElementTitle = "";
         AV35ErrorIds = "";
         AV31WWPFormInstanceElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         AV23VisibleCondition = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression(context);
         GX_FocusControl = "";
         lblDatatitle_Jsonclick = "";
         TempTags = "";
         AV9Data = (DateTime)(DateTime.MinValue);
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV36SDT_DynamicFormTranslation = new SdtSDT_DynamicFormTranslation(context);
         AV8CurrentWWPFormInstanceElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         AV28WWPFormElementMetadata = "";
         AV24WebSession = context.GetSession();
         GXt_SdtWWP_FormInstance1 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         AV22Validations = new GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation>( context, "WWP_DF_Validation", "Comforta_version21");
         AV21ThisValueStr = "";
         AV12ElementInternalName = "";
         AV19Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV18Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV10DataCellNameClass = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV26WWPDynamicFormMode = "";
         sCtrlAV27WWPFormElementId = "";
         sCtrlAV6WWPFormInstanceElementId = "";
         sCtrlAV20SessionId = "";
         sCtrlAV30WWPFormInstance = "";
         /* GeneXus formulas. */
      }

      private short AV27WWPFormElementId ;
      private short AV6WWPFormInstanceElementId ;
      private short AV20SessionId ;
      private short wcpOAV27WWPFormElementId ;
      private short wcpOAV6WWPFormInstanceElementId ;
      private short wcpOAV20SessionId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV7AuxSessionId ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short AV5WWPFormElementCaption ;
      private short nGXWrapped ;
      private int divDatatitlecell_Visible ;
      private int edtavData_Enabled ;
      private int AV37GXV1 ;
      private int AV38GXV2 ;
      private int AV39GXV3 ;
      private int idxLst ;
      private decimal AV32DateTimeNumber ;
      private decimal GXt_decimal2 ;
      private string AV26WWPDynamicFormMode ;
      private string wcpOAV26WWPDynamicFormMode ;
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
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string sCtrlAV26WWPDynamicFormMode ;
      private string sCtrlAV27WWPFormElementId ;
      private string sCtrlAV6WWPFormInstanceElementId ;
      private string sCtrlAV20SessionId ;
      private string sCtrlAV30WWPFormInstance ;
      private DateTime AV9Data ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14HasReferenceId ;
      private bool AV13ExistElement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV15IsElementFocusable ;
      private bool AV11DataEnabled ;
      private bool AV16IsRequired ;
      private bool AV17IsValid ;
      private string AV29WWPFormElementTitle ;
      private string AV28WWPFormElementMetadata ;
      private string AV35ErrorIds ;
      private string AV21ThisValueStr ;
      private string AV12ElementInternalName ;
      private string AV10DataCellNameClass ;
      private IGxSession AV24WebSession ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV30WWPFormInstance ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP4_WWPFormInstance ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_DateMetadata AV25WWP_DF_DateMetadata ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element AV31WWPFormInstanceElement ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression AV23VisibleCondition ;
      private SdtSDT_DynamicFormTranslation AV36SDT_DynamicFormTranslation ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element AV8CurrentWWPFormInstanceElement ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance GXt_SdtWWP_FormInstance1 ;
      private GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation> AV22Validations ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV19Messages ;
      private GeneXus.Utils.SdtMessages_Message AV18Message ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
