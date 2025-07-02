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
   public class wwp_dfc_wizard_wc : GXWebComponent
   {
      public wwp_dfc_wizard_wc( )
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

      public wwp_dfc_wizard_wc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPDynamicFormMode ,
                           short aP1_SessionId ,
                           short aP2_DefaultSelectedStepIndex ,
                           ref GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP3_WWPForm )
      {
         this.AV13WWPDynamicFormMode = aP0_WWPDynamicFormMode;
         this.AV9SessionId = aP1_SessionId;
         this.AV6DefaultSelectedStepIndex = aP2_DefaultSelectedStepIndex;
         this.AV14WWPForm = aP3_WWPForm;
         ExecuteImpl();
         aP3_WWPForm=this.AV14WWPForm;
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
                  AV13WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
                  AssignAttri(sPrefix, false, "AV13WWPDynamicFormMode", AV13WWPDynamicFormMode);
                  AV9SessionId = (short)(Math.Round(NumberUtil.Val( GetPar( "SessionId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV9SessionId", StringUtil.LTrimStr( (decimal)(AV9SessionId), 4, 0));
                  AV6DefaultSelectedStepIndex = (short)(Math.Round(NumberUtil.Val( GetPar( "DefaultSelectedStepIndex"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV6DefaultSelectedStepIndex", StringUtil.LTrimStr( (decimal)(AV6DefaultSelectedStepIndex), 4, 0));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV14WWPForm);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV13WWPDynamicFormMode,(short)AV9SessionId,(short)AV6DefaultSelectedStepIndex,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV14WWPForm});
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
            PA282( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS282( ) ;
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
            context.SendWebValue( context.GetMessage( "WWP_Dynamic Form Creation_Wizard_WC", "")) ;
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
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_dfc_wizard_wc.aspx"+UrlEncode(StringUtil.RTrim(AV13WWPDynamicFormMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV9SessionId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV6DefaultSelectedStepIndex,4,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.dynamicforms.wwp_dfc_wizard_wc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDSTEPS", AV12WizardSteps);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDSTEPS", AV12WizardSteps);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWIZARDSTEPS", GetSecureSignedToken( sPrefix, AV12WizardSteps, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV13WWPDynamicFormMode", StringUtil.RTrim( wcpOAV13WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV9SessionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV9SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6DefaultSelectedStepIndex", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV6DefaultSelectedStepIndex), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORM", AV14WWPForm);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORM", AV14WWPForm);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISFIRSTELEMENT", AV15IsFirstElement);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISLASTELEMENT", AV16IsLastElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"vSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDSTEPS", AV12WizardSteps);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDSTEPS", AV12WizardSteps);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWIZARDSTEPS", GetSecureSignedToken( sPrefix, AV12WizardSteps, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV13WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDEFAULTSELECTEDSTEPINDEX", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6DefaultSelectedStepIndex), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"SETTINGS_MODAL_Result", StringUtil.RTrim( Settings_modal_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"ADDELEMENT_MODAL_Result", StringUtil.RTrim( Addelement_modal_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"SETTINGS_MODAL_Result", StringUtil.RTrim( Settings_modal_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"ADDELEMENT_MODAL_Result", StringUtil.RTrim( Addelement_modal_Result));
      }

      protected void RenderHtmlCloseForm282( )
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
            if ( ! ( WebComp_Wizardheader == null ) )
            {
               WebComp_Wizardheader.componentjscripts();
            }
            if ( ! ( WebComp_Dynamicformfs_wc == null ) )
            {
               WebComp_Dynamicformfs_wc.componentjscripts();
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
         return "WorkWithPlus.DynamicForms.WWP_DFC_Wizard_WC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WWP_Dynamic Form Creation_Wizard_WC", "") ;
      }

      protected void WB280( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "workwithplus.dynamicforms.wwp_dfc_wizard_wc.aspx");
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablewizardmain_Internalname, divTablewizardmain_Visible, 0, "px", 0, "px", "TableWizardMainWithShadow", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WizardStepsCell", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, sPrefix+"W0012"+"", StringUtil.RTrim( WebComp_Wizardheader_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0012"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wizardheader_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWizardheader), StringUtil.Lower( WebComp_Wizardheader_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0012"+"");
                  }
                  WebComp_Wizardheader.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWizardheader), StringUtil.Lower( WebComp_Wizardheader_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblStepdescription_Internalname, lblStepdescription_Caption, "", "", lblStepdescription_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "WizardStepDescription", 0, "", lblStepdescription_Visible, 1, 0, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DFC_Wizard_WC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWizardsteps_Internalname, 1, 0, "px", 0, "px", "WizardStepsPositionCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, sPrefix+"W0021"+"", StringUtil.RTrim( WebComp_Dynamicformfs_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0021"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Dynamicformfs_wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldDynamicformfs_wc), StringUtil.Lower( WebComp_Dynamicformfs_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0021"+"");
                  }
                  WebComp_Dynamicformfs_wc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldDynamicformfs_wc), StringUtil.Lower( WebComp_Dynamicformfs_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactionscell_Internalname, 1, 0, "px", 0, "px", divTableactionscell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;justify-content:space-between;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucBtnprevious.SetProperty("TooltipText", Btnprevious_Tooltiptext);
            ucBtnprevious.SetProperty("BeforeIconClass", Btnprevious_Beforeiconclass);
            ucBtnprevious.SetProperty("Caption", Btnprevious_Caption);
            ucBtnprevious.SetProperty("Class", Btnprevious_Class);
            ucBtnprevious.Render(context, "wwp_iconbutton", Btnprevious_Internalname, sPrefix+"BTNPREVIOUSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucBtnnext.SetProperty("TooltipText", Btnnext_Tooltiptext);
            ucBtnnext.SetProperty("AfterIconClass", Btnnext_Aftericonclass);
            ucBtnnext.SetProperty("Caption", Btnnext_Caption);
            ucBtnnext.SetProperty("Class", Btnnext_Class);
            ucBtnnext.Render(context, "wwp_iconbutton", Btnnext_Internalname, sPrefix+"BTNNEXTContainer");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 TableDynFormAddElementCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "TableDynFormAddElement", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "end", "top", "", "", "div");
            wb_table1_34_282( true) ;
         }
         else
         {
            wb_table1_34_282( false) ;
         }
         return  ;
      }

      protected void wb_table1_34_282e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "end", "top", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCurrentstepaux_Internalname, AV5CurrentStepAux, StringUtil.RTrim( context.localUtil.Format( AV5CurrentStepAux, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCurrentstepaux_Jsonclick, 0, "Attribute", "", "", "", "", edtavCurrentstepaux_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WorkWithPlus/DynamicForms/WWP_DFC_Wizard_WC.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavI_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8i), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV8i), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,44);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavI_Jsonclick, 0, "Attribute", "", "", "", "", edtavI_Visible, 1, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkWithPlus/DynamicForms/WWP_DFC_Wizard_WC.htm");
            wb_table2_45_282( true) ;
         }
         else
         {
            wb_table2_45_282( false) ;
         }
         return  ;
      }

      protected void wb_table2_45_282e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table3_50_282( true) ;
         }
         else
         {
            wb_table3_50_282( false) ;
         }
         return  ;
      }

      protected void wb_table3_50_282e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, sPrefix+"W0056"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0056"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0056"+"");
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

      protected void START282( )
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
            Form.Meta.addItem("description", context.GetMessage( "WWP_Dynamic Form Creation_Wizard_WC", ""), 0) ;
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
               STRUP280( ) ;
            }
         }
      }

      protected void WS282( )
      {
         START282( ) ;
         EVT282( ) ;
      }

      protected void EVT282( )
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
                                 STRUP280( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "SETTINGS_MODAL.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP280( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Settings_modal.Close */
                                    E11282 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "SETTINGS_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP280( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Settings_modal.Onloadcomponent */
                                    E12282 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ADDELEMENT_MODAL.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP280( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Addelement_modal.Close */
                                    E13282 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ADDELEMENT_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP280( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Addelement_modal.Onloadcomponent */
                                    E14282 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP280( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E15282 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP280( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E16282 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOPREVIOUS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP280( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoPrevious' */
                                    E17282 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DONEXT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP280( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoNext' */
                                    E18282 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP280( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E19282 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP280( ) ;
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
                                 STRUP280( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavCurrentstepaux_Internalname;
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
                        if ( nCmpId == 12 )
                        {
                           OldWizardheader = cgiGet( sPrefix+"W0012");
                           if ( ( StringUtil.Len( OldWizardheader) == 0 ) || ( StringUtil.StrCmp(OldWizardheader, WebComp_Wizardheader_Component) != 0 ) )
                           {
                              WebComp_Wizardheader = getWebComponent(GetType(), "GeneXus.Programs", OldWizardheader, new Object[] {context} );
                              WebComp_Wizardheader.ComponentInit();
                              WebComp_Wizardheader.Name = "OldWizardheader";
                              WebComp_Wizardheader_Component = OldWizardheader;
                           }
                           if ( StringUtil.Len( WebComp_Wizardheader_Component) != 0 )
                           {
                              WebComp_Wizardheader.componentprocess(sPrefix+"W0012", "", sEvt);
                           }
                           WebComp_Wizardheader_Component = OldWizardheader;
                        }
                        else if ( nCmpId == 21 )
                        {
                           OldDynamicformfs_wc = cgiGet( sPrefix+"W0021");
                           if ( ( StringUtil.Len( OldDynamicformfs_wc) == 0 ) || ( StringUtil.StrCmp(OldDynamicformfs_wc, WebComp_Dynamicformfs_wc_Component) != 0 ) )
                           {
                              WebComp_Dynamicformfs_wc = getWebComponent(GetType(), "GeneXus.Programs", OldDynamicformfs_wc, new Object[] {context} );
                              WebComp_Dynamicformfs_wc.ComponentInit();
                              WebComp_Dynamicformfs_wc.Name = "OldDynamicformfs_wc";
                              WebComp_Dynamicformfs_wc_Component = OldDynamicformfs_wc;
                           }
                           if ( StringUtil.Len( WebComp_Dynamicformfs_wc_Component) != 0 )
                           {
                              WebComp_Dynamicformfs_wc.componentprocess(sPrefix+"W0021", "", sEvt);
                           }
                           WebComp_Dynamicformfs_wc_Component = OldDynamicformfs_wc;
                        }
                        else if ( nCmpId == 56 )
                        {
                           OldWwpaux_wc = cgiGet( sPrefix+"W0056");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess(sPrefix+"W0056", "", sEvt);
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

      protected void WE282( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm282( ) ;
            }
         }
      }

      protected void PA282( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.dynamicforms.wwp_dfc_wizard_wc.aspx")), "workwithplus.dynamicforms.wwp_dfc_wizard_wc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.dynamicforms.wwp_dfc_wizard_wc.aspx")))) ;
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
               GX_FocusControl = edtavCurrentstepaux_Internalname;
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
         RF282( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF282( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E16282 ();
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wizardheader_Component) != 0 )
               {
                  WebComp_Wizardheader.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Dynamicformfs_wc_Component) != 0 )
               {
                  WebComp_Dynamicformfs_wc.componentstart();
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
            /* Execute user event: Load */
            E19282 ();
            WB280( ) ;
         }
      }

      protected void send_integrity_lvl_hashes282( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDSTEPS", AV12WizardSteps);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDSTEPS", AV12WizardSteps);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWIZARDSTEPS", GetSecureSignedToken( sPrefix, AV12WizardSteps, context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP280( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E15282 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOAV13WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV13WWPDynamicFormMode");
            wcpOAV9SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV9SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV6DefaultSelectedStepIndex = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6DefaultSelectedStepIndex"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Settings_modal_Result = cgiGet( sPrefix+"SETTINGS_MODAL_Result");
            Addelement_modal_Result = cgiGet( sPrefix+"ADDELEMENT_MODAL_Result");
            /* Read variables values. */
            AV5CurrentStepAux = cgiGet( edtavCurrentstepaux_Internalname);
            AssignAttri(sPrefix, false, "AV5CurrentStepAux", AV5CurrentStepAux);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavI_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavI_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vI");
               GX_FocusControl = edtavI_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8i = 0;
               AssignAttri(sPrefix, false, "AV8i", StringUtil.LTrimStr( (decimal)(AV8i), 4, 0));
            }
            else
            {
               AV8i = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavI_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV8i", StringUtil.LTrimStr( (decimal)(AV8i), 4, 0));
            }
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
         E15282 ();
         if (returnInSub) return;
      }

      protected void E15282( )
      {
         /* Start Routine */
         returnInSub = false;
         divTableactionscell_Class = "Invisible";
         AssignProp(sPrefix, false, divTableactionscell_Internalname, "Class", divTableactionscell_Class, true);
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         edtavCurrentstepaux_Visible = 0;
         AssignProp(sPrefix, false, edtavCurrentstepaux_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCurrentstepaux_Visible), 5, 0), true);
         edtavI_Visible = 0;
         AssignProp(sPrefix, false, edtavI_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavI_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOAD WIZARD WCS' */
         S122 ();
         if (returnInSub) return;
         if ( AV12WizardSteps.Count == 0 )
         {
            divTablewizardmain_Visible = 0;
            AssignProp(sPrefix, false, divTablewizardmain_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablewizardmain_Visible), 5, 0), true);
         }
      }

      protected void E16282( )
      {
         /* Refresh Routine */
         returnInSub = false;
         if ( AV14WWPForm.gxTpr_Element.Count > 1 )
         {
            divTableactionscell_Class = "col-xs-12 CellWizardActions";
            AssignProp(sPrefix, false, divTableactionscell_Internalname, "Class", divTableactionscell_Class, true);
         }
         lblStepdescription_Visible = (((AV14WWPForm.gxTpr_Element.Count>0)) ? 1 : 0);
         AssignProp(sPrefix, false, lblStepdescription_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblStepdescription_Visible), 5, 0), true);
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E12282( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)sPrefix+"W0056",(string)"",(string)"UPD",(short)0,(short)0,(short)AV9SessionId});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0056"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E14282( )
      {
         /* Addelement_modal_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_AddElement")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_addelement", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WorkWithPlus.DynamicForms.WWP_DF_AddElement";
            WebComp_Wwpaux_wc_Component = "WorkWithPlus.DynamicForms.WWP_DF_AddElement";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)sPrefix+"W0056",(string)"",(string)"INS",(short)0,(short)0,(short)AV9SessionId});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0056"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E17282( )
      {
         /* 'DoPrevious' Routine */
         returnInSub = false;
         AV8i = 1;
         AssignAttri(sPrefix, false, "AV8i", StringUtil.LTrimStr( (decimal)(AV8i), 4, 0));
         AV23GXV1 = 1;
         while ( AV23GXV1 <= AV12WizardSteps.Count )
         {
            AV10WizardStep = ((WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem)AV12WizardSteps.Item(AV23GXV1));
            if ( StringUtil.StrCmp(AV10WizardStep.gxTpr_Code, AV5CurrentStepAux) == 0 )
            {
               if (true) break;
            }
            AV8i = (short)(AV8i+1);
            AssignAttri(sPrefix, false, "AV8i", StringUtil.LTrimStr( (decimal)(AV8i), 4, 0));
            AV23GXV1 = (int)(AV23GXV1+1);
         }
         if ( AV8i > 1 )
         {
            AV10WizardStep = ((WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem)AV12WizardSteps.Item(AV8i-1));
            AV5CurrentStepAux = AV10WizardStep.gxTpr_Code;
            AssignAttri(sPrefix, false, "AV5CurrentStepAux", AV5CurrentStepAux);
            /* Execute user subroutine: 'DISPLAYCURRENTSTEP' */
            S142 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
            S132 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV14WWPForm", AV14WWPForm);
      }

      protected void E18282( )
      {
         /* 'DoNext' Routine */
         returnInSub = false;
         AV8i = 1;
         AssignAttri(sPrefix, false, "AV8i", StringUtil.LTrimStr( (decimal)(AV8i), 4, 0));
         AV24GXV2 = 1;
         while ( AV24GXV2 <= AV12WizardSteps.Count )
         {
            AV10WizardStep = ((WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem)AV12WizardSteps.Item(AV24GXV2));
            if ( StringUtil.StrCmp(AV10WizardStep.gxTpr_Code, AV5CurrentStepAux) == 0 )
            {
               if (true) break;
            }
            AV8i = (short)(AV8i+1);
            AssignAttri(sPrefix, false, "AV8i", StringUtil.LTrimStr( (decimal)(AV8i), 4, 0));
            AV24GXV2 = (int)(AV24GXV2+1);
         }
         if ( AV8i < AV12WizardSteps.Count )
         {
            AV8i = (short)(AV8i+1);
            AssignAttri(sPrefix, false, "AV8i", StringUtil.LTrimStr( (decimal)(AV8i), 4, 0));
            AV11WizardStepAux = ((WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem)AV12WizardSteps.Item(AV8i));
            AV5CurrentStepAux = AV11WizardStepAux.gxTpr_Code;
            AssignAttri(sPrefix, false, "AV5CurrentStepAux", AV5CurrentStepAux);
            /* Execute user subroutine: 'DISPLAYCURRENTSTEP' */
            S142 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
            S132 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV14WWPForm", AV14WWPForm);
      }

      protected void S132( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         Btnprevious_Visible = true;
         ucBtnprevious.SendProperty(context, sPrefix, false, Btnprevious_Internalname, "Visible", StringUtil.BoolToStr( Btnprevious_Visible));
         Btnnext_Visible = true;
         ucBtnnext.SendProperty(context, sPrefix, false, Btnnext_Internalname, "Visible", StringUtil.BoolToStr( Btnnext_Visible));
         if ( ! ( ( AV14WWPForm.gxTpr_Element.Count > 0 ) && ! AV15IsFirstElement ) )
         {
            Btnprevious_Visible = false;
            ucBtnprevious.SendProperty(context, sPrefix, false, Btnprevious_Internalname, "Visible", StringUtil.BoolToStr( Btnprevious_Visible));
         }
         if ( ! ( ( AV14WWPForm.gxTpr_Element.Count > 0 ) && ! AV16IsLastElement ) )
         {
            Btnnext_Visible = false;
            ucBtnnext.SendProperty(context, sPrefix, false, Btnnext_Internalname, "Visible", StringUtil.BoolToStr( Btnnext_Visible));
         }
         AV17IsVis = Btnnext_Visible;
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         tblUnnamedtable2_Visible = (((StringUtil.StrCmp(AV13WWPDynamicFormMode, "DSP")!=0)) ? 1 : 0);
         AssignProp(sPrefix, false, tblUnnamedtable2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblUnnamedtable2_Visible), 5, 0), true);
      }

      protected void E11282( )
      {
         /* Settings_modal_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Settings_modal_Result, "OK_AND_REFRESH") == 0 )
         {
            AV8i = 1;
            AssignAttri(sPrefix, false, "AV8i", StringUtil.LTrimStr( (decimal)(AV8i), 4, 0));
            AV25GXV3 = 1;
            while ( AV25GXV3 <= AV12WizardSteps.Count )
            {
               AV10WizardStep = ((WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem)AV12WizardSteps.Item(AV25GXV3));
               if ( StringUtil.StrCmp(AV10WizardStep.gxTpr_Code, AV5CurrentStepAux) == 0 )
               {
                  if (true) break;
               }
               AV8i = (short)(AV8i+1);
               AssignAttri(sPrefix, false, "AV8i", StringUtil.LTrimStr( (decimal)(AV8i), 4, 0));
               AV25GXV3 = (int)(AV25GXV3+1);
            }
            AV19WebSession.Set("WWPDynFormCreation_DefaultStep", StringUtil.Trim( StringUtil.Str( (decimal)(AV8i), 4, 0)));
            this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "DynamicForms_RefreshParentGrid", new Object[] {(string)divLayoutmaintable_Internalname,(string)"LayoutMainTable"}, false);
         }
         /*  Sending Event outputs  */
      }

      protected void E13282( )
      {
         /* Addelement_modal_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Addelement_modal_Result, "OK") == 0 )
         {
            AV8i = (short)(AV12WizardSteps.Count+1);
            AssignAttri(sPrefix, false, "AV8i", StringUtil.LTrimStr( (decimal)(AV8i), 4, 0));
            AV19WebSession.Set("WWPDynFormCreation_DefaultStep", StringUtil.Trim( StringUtil.Str( (decimal)(AV8i), 4, 0)));
            this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "DynamicForms_RefreshParentGrid", new Object[] {(string)divLayoutmaintable_Internalname,(string)"LayoutMainTable"}, false);
         }
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'DISPLAYCURRENTSTEP' Routine */
         returnInSub = false;
         GXt_SdtWWP_Form1 = AV14WWPForm;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadformdefinition(context ).execute(  AV9SessionId, out  GXt_SdtWWP_Form1) ;
         AV14WWPForm = GXt_SdtWWP_Form1;
         /* Object Property */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            bDynCreated_Wizardheader = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wizardheader_Component), StringUtil.Lower( "WWPBaseObjects.WizardStepsBulletWC")) != 0 )
         {
            WebComp_Wizardheader = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.wizardstepsbulletwc", new Object[] {context} );
            WebComp_Wizardheader.ComponentInit();
            WebComp_Wizardheader.Name = "WWPBaseObjects.WizardStepsBulletWC";
            WebComp_Wizardheader_Component = "WWPBaseObjects.WizardStepsBulletWC";
         }
         if ( StringUtil.Len( WebComp_Wizardheader_Component) != 0 )
         {
            WebComp_Wizardheader.setjustcreated();
            WebComp_Wizardheader.componentprepare(new Object[] {(string)sPrefix+"W0012",(string)"",(string)"",(GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem>)AV12WizardSteps,(string)AV5CurrentStepAux});
            WebComp_Wizardheader.componentbind(new Object[] {(string)"",(string)"",(string)sPrefix+"vCURRENTSTEPAUX"});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wizardheader )
         {
            context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0012"+"");
            WebComp_Wizardheader.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         AV26GXV4 = 1;
         while ( AV26GXV4 <= AV14WWPForm.gxTpr_Element.Count )
         {
            AV7Element = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV14WWPForm.gxTpr_Element.Item(AV26GXV4));
            if ( ( AV7Element.gxTpr_Wwpformelementtype == 5 ) && ( StringUtil.StrCmp(AV7Element.gxTpr_Wwpformelementtitle, AV5CurrentStepAux) == 0 ) )
            {
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_dfc_canmoveelement(context ).execute(  AV14WWPForm,  AV7Element, out  AV15IsFirstElement, out  AV16IsLastElement) ;
               AssignAttri(sPrefix, false, "AV15IsFirstElement", AV15IsFirstElement);
               AssignAttri(sPrefix, false, "AV16IsLastElement", AV16IsLastElement);
               AV18WWP_DF_StepMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_StepMetadata(context);
               AV18WWP_DF_StepMetadata.FromJSonString(AV7Element.gxTpr_Wwpformelementmetadata, null);
               lblStepdescription_Caption = AV18WWP_DF_StepMetadata.gxTpr_Description;
               AssignProp(sPrefix, false, lblStepdescription_Internalname, "Caption", lblStepdescription_Caption, true);
               /* Object Property */
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  bDynCreated_Dynamicformfs_wc = true;
               }
               if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Dynamicformfs_wc_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_FS_WC")) != 0 )
               {
                  WebComp_Dynamicformfs_wc = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_fs_wc", new Object[] {context} );
                  WebComp_Dynamicformfs_wc.ComponentInit();
                  WebComp_Dynamicformfs_wc.Name = "WorkWithPlus.DynamicForms.WWP_DFC_FS_WC";
                  WebComp_Dynamicformfs_wc_Component = "WorkWithPlus.DynamicForms.WWP_DFC_FS_WC";
               }
               if ( StringUtil.Len( WebComp_Dynamicformfs_wc_Component) != 0 )
               {
                  WebComp_Dynamicformfs_wc.setjustcreated();
                  WebComp_Dynamicformfs_wc.componentprepare(new Object[] {(string)sPrefix+"W0021",(string)"",(string)AV13WWPDynamicFormMode,AV7Element.gxTpr_Wwpformelementid,(short)AV9SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV14WWPForm});
                  WebComp_Dynamicformfs_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
               }
               if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Dynamicformfs_wc )
               {
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0021"+"");
                  WebComp_Dynamicformfs_wc.componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
               if (true) break;
            }
            AV26GXV4 = (int)(AV26GXV4+1);
         }
      }

      protected void S122( )
      {
         /* 'LOAD WIZARD WCS' Routine */
         returnInSub = false;
         AV12WizardSteps = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem>( context, "WizardStepsItem", "Comforta_version2");
         AV5CurrentStepAux = "";
         AssignAttri(sPrefix, false, "AV5CurrentStepAux", AV5CurrentStepAux);
         AV27GXV5 = 1;
         while ( AV27GXV5 <= AV14WWPForm.gxTpr_Element.Count )
         {
            AV7Element = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV14WWPForm.gxTpr_Element.Item(AV27GXV5));
            if ( ( AV7Element.gxTpr_Wwpformelementtype == 5 ) && (0==AV7Element.gxTpr_Wwpformelementparentid) )
            {
               AV10WizardStep = new WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem(context);
               AV10WizardStep.gxTpr_Code = AV7Element.gxTpr_Wwpformelementtitle;
               AV10WizardStep.gxTpr_Title = AV7Element.gxTpr_Wwpformelementtitle;
               AV10WizardStep.gxTpr_Description = AV7Element.gxTpr_Wwpformelementtitle;
               AV12WizardSteps.Add(AV10WizardStep, 0);
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5CurrentStepAux)) && ( (0==AV6DefaultSelectedStepIndex) || ! (0==AV6DefaultSelectedStepIndex) && ( AV12WizardSteps.Count == AV6DefaultSelectedStepIndex ) ) )
               {
                  AV5CurrentStepAux = AV7Element.gxTpr_Wwpformelementtitle;
                  AssignAttri(sPrefix, false, "AV5CurrentStepAux", AV5CurrentStepAux);
               }
            }
            AV27GXV5 = (int)(AV27GXV5+1);
         }
         /* Object Property */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            bDynCreated_Wizardheader = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wizardheader_Component), StringUtil.Lower( "WWPBaseObjects.WizardStepsBulletWC")) != 0 )
         {
            WebComp_Wizardheader = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.wizardstepsbulletwc", new Object[] {context} );
            WebComp_Wizardheader.ComponentInit();
            WebComp_Wizardheader.Name = "WWPBaseObjects.WizardStepsBulletWC";
            WebComp_Wizardheader_Component = "WWPBaseObjects.WizardStepsBulletWC";
         }
         if ( StringUtil.Len( WebComp_Wizardheader_Component) != 0 )
         {
            WebComp_Wizardheader.setjustcreated();
            WebComp_Wizardheader.componentprepare(new Object[] {(string)sPrefix+"W0012",(string)"",(string)"",(GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem>)AV12WizardSteps,(string)AV5CurrentStepAux});
            WebComp_Wizardheader.componentbind(new Object[] {(string)"",(string)"",(string)sPrefix+"vCURRENTSTEPAUX"});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wizardheader )
         {
            context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0012"+"");
            WebComp_Wizardheader.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /* Execute user subroutine: 'DISPLAYCURRENTSTEP' */
         S142 ();
         if (returnInSub) return;
      }

      protected void nextLoad( )
      {
      }

      protected void E19282( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table3_50_282( bool wbgen )
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
            wb_table3_50_282e( true) ;
         }
         else
         {
            wb_table3_50_282e( false) ;
         }
      }

      protected void wb_table2_45_282( bool wbgen )
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
            wb_table2_45_282e( true) ;
         }
         else
         {
            wb_table2_45_282e( false) ;
         }
      }

      protected void wb_table1_34_282( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblUnnamedtable2_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblUnnamedtable2_Internalname, tblUnnamedtable2_Internalname, "", "TableDynAddElementActions", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
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
            wb_table1_34_282e( true) ;
         }
         else
         {
            wb_table1_34_282e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV13WWPDynamicFormMode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV13WWPDynamicFormMode", AV13WWPDynamicFormMode);
         AV9SessionId = Convert.ToInt16(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV9SessionId", StringUtil.LTrimStr( (decimal)(AV9SessionId), 4, 0));
         AV6DefaultSelectedStepIndex = Convert.ToInt16(getParm(obj,2));
         AssignAttri(sPrefix, false, "AV6DefaultSelectedStepIndex", StringUtil.LTrimStr( (decimal)(AV6DefaultSelectedStepIndex), 4, 0));
         AV14WWPForm = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)getParm(obj,3);
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
         PA282( ) ;
         WS282( ) ;
         WE282( ) ;
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
         sCtrlAV13WWPDynamicFormMode = (string)((string)getParm(obj,0));
         sCtrlAV9SessionId = (string)((string)getParm(obj,1));
         sCtrlAV6DefaultSelectedStepIndex = (string)((string)getParm(obj,2));
         sCtrlAV14WWPForm = (string)((string)getParm(obj,3));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA282( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "workwithplus\\dynamicforms\\wwp_dfc_wizard_wc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA282( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV13WWPDynamicFormMode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV13WWPDynamicFormMode", AV13WWPDynamicFormMode);
            AV9SessionId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV9SessionId", StringUtil.LTrimStr( (decimal)(AV9SessionId), 4, 0));
            AV6DefaultSelectedStepIndex = Convert.ToInt16(getParm(obj,4));
            AssignAttri(sPrefix, false, "AV6DefaultSelectedStepIndex", StringUtil.LTrimStr( (decimal)(AV6DefaultSelectedStepIndex), 4, 0));
            AV14WWPForm = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)getParm(obj,5);
         }
         wcpOAV13WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV13WWPDynamicFormMode");
         wcpOAV9SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV9SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV6DefaultSelectedStepIndex = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6DefaultSelectedStepIndex"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV13WWPDynamicFormMode, wcpOAV13WWPDynamicFormMode) != 0 ) || ( AV9SessionId != wcpOAV9SessionId ) || ( AV6DefaultSelectedStepIndex != wcpOAV6DefaultSelectedStepIndex ) ) )
         {
            setjustcreated();
         }
         wcpOAV13WWPDynamicFormMode = AV13WWPDynamicFormMode;
         wcpOAV9SessionId = AV9SessionId;
         wcpOAV6DefaultSelectedStepIndex = AV6DefaultSelectedStepIndex;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV13WWPDynamicFormMode = cgiGet( sPrefix+"AV13WWPDynamicFormMode_CTRL");
         if ( StringUtil.Len( sCtrlAV13WWPDynamicFormMode) > 0 )
         {
            AV13WWPDynamicFormMode = cgiGet( sCtrlAV13WWPDynamicFormMode);
            AssignAttri(sPrefix, false, "AV13WWPDynamicFormMode", AV13WWPDynamicFormMode);
         }
         else
         {
            AV13WWPDynamicFormMode = cgiGet( sPrefix+"AV13WWPDynamicFormMode_PARM");
         }
         sCtrlAV9SessionId = cgiGet( sPrefix+"AV9SessionId_CTRL");
         if ( StringUtil.Len( sCtrlAV9SessionId) > 0 )
         {
            AV9SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV9SessionId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV9SessionId", StringUtil.LTrimStr( (decimal)(AV9SessionId), 4, 0));
         }
         else
         {
            AV9SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV9SessionId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV6DefaultSelectedStepIndex = cgiGet( sPrefix+"AV6DefaultSelectedStepIndex_CTRL");
         if ( StringUtil.Len( sCtrlAV6DefaultSelectedStepIndex) > 0 )
         {
            AV6DefaultSelectedStepIndex = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV6DefaultSelectedStepIndex), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV6DefaultSelectedStepIndex", StringUtil.LTrimStr( (decimal)(AV6DefaultSelectedStepIndex), 4, 0));
         }
         else
         {
            AV6DefaultSelectedStepIndex = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV6DefaultSelectedStepIndex_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV14WWPForm = cgiGet( sPrefix+"AV14WWPForm_CTRL");
         if ( StringUtil.Len( sCtrlAV14WWPForm) > 0 )
         {
            AV14WWPForm.FromXml(cgiGet( sCtrlAV14WWPForm), null, "", "");
         }
         else
         {
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"AV14WWPForm_PARM"), AV14WWPForm);
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
         PA282( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS282( ) ;
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
         WS282( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV13WWPDynamicFormMode_PARM", StringUtil.RTrim( AV13WWPDynamicFormMode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV13WWPDynamicFormMode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV13WWPDynamicFormMode_CTRL", StringUtil.RTrim( sCtrlAV13WWPDynamicFormMode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV9SessionId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV9SessionId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV9SessionId_CTRL", StringUtil.RTrim( sCtrlAV9SessionId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6DefaultSelectedStepIndex_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6DefaultSelectedStepIndex), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6DefaultSelectedStepIndex)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6DefaultSelectedStepIndex_CTRL", StringUtil.RTrim( sCtrlAV6DefaultSelectedStepIndex));
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"AV14WWPForm_PARM", AV14WWPForm);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"AV14WWPForm_PARM", AV14WWPForm);
         }
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV14WWPForm)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV14WWPForm_CTRL", StringUtil.RTrim( sCtrlAV14WWPForm));
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
         WE282( ) ;
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
         if ( ! ( WebComp_Wizardheader == null ) )
         {
            WebComp_Wizardheader.componentjscripts();
         }
         if ( ! ( WebComp_Dynamicformfs_wc == null ) )
         {
            WebComp_Dynamicformfs_wc.componentjscripts();
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wizardheader == null ) )
         {
            if ( StringUtil.Len( WebComp_Wizardheader_Component) != 0 )
            {
               WebComp_Wizardheader.componentthemes();
            }
         }
         if ( ! ( WebComp_Dynamicformfs_wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Dynamicformfs_wc_Component) != 0 )
            {
               WebComp_Dynamicformfs_wc.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20257212435831", true, true);
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
         context.AddJavascriptSource("workwithplus/dynamicforms/wwp_dfc_wizard_wc.js", "?20257212435831", false, true);
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
         lblStepdescription_Internalname = sPrefix+"STEPDESCRIPTION";
         Btnprevious_Internalname = sPrefix+"BTNPREVIOUS";
         Btnnext_Internalname = sPrefix+"BTNNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTableactionscell_Internalname = sPrefix+"TABLEACTIONSCELL";
         divWizardsteps_Internalname = sPrefix+"WIZARDSTEPS";
         divTablewizardmain_Internalname = sPrefix+"TABLEWIZARDMAIN";
         Btnsettings_Internalname = sPrefix+"BTNSETTINGS";
         Btnaddelement_Internalname = sPrefix+"BTNADDELEMENT";
         tblUnnamedtable2_Internalname = sPrefix+"UNNAMEDTABLE2";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavCurrentstepaux_Internalname = sPrefix+"vCURRENTSTEPAUX";
         edtavI_Internalname = sPrefix+"vI";
         Settings_modal_Internalname = sPrefix+"SETTINGS_MODAL";
         tblTablesettings_modal_Internalname = sPrefix+"TABLESETTINGS_MODAL";
         Addelement_modal_Internalname = sPrefix+"ADDELEMENT_MODAL";
         tblTableaddelement_modal_Internalname = sPrefix+"TABLEADDELEMENT_MODAL";
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
         Btnaddelement_Class = "ButtonGray";
         Btnaddelement_Caption = context.GetMessage( "WWP_DF_AddStep", "");
         Btnaddelement_Beforeiconclass = "fas fa-circle-plus";
         Btnaddelement_Tooltiptext = "";
         Btnsettings_Class = "ButtonGray";
         Btnsettings_Caption = context.GetMessage( "WWP_DF_FormSettings", "");
         Btnsettings_Beforeiconclass = "fas fa-gear";
         Btnsettings_Tooltiptext = "";
         Settings_modal_Bodytype = "WebComponent";
         Settings_modal_Confirmtype = "";
         Settings_modal_Title = context.GetMessage( "Add Element", "");
         Settings_modal_Width = "800";
         Addelement_modal_Bodytype = "WebComponent";
         Addelement_modal_Confirmtype = "";
         Addelement_modal_Title = context.GetMessage( "Element settings", "");
         Addelement_modal_Width = "800";
         tblUnnamedtable2_Visible = 1;
         Btnnext_Visible = Convert.ToBoolean( -1);
         Btnprevious_Visible = Convert.ToBoolean( -1);
         edtavI_Jsonclick = "";
         edtavI_Visible = 1;
         edtavCurrentstepaux_Jsonclick = "";
         edtavCurrentstepaux_Visible = 1;
         Btnnext_Class = "MobileSubmitBtn NxtWzdBtn";
         Btnnext_Caption = context.GetMessage( "Next", "");
         Btnnext_Aftericonclass = "fas fa-arrow-right";
         Btnnext_Tooltiptext = "";
         Btnprevious_Class = "MobileSubmitBtn PrevWzdBtn";
         Btnprevious_Caption = context.GetMessage( "Previous", "");
         Btnprevious_Beforeiconclass = "fas fa-arrow-left";
         Btnprevious_Tooltiptext = "";
         divTableactionscell_Class = "col-xs-12";
         lblStepdescription_Caption = context.GetMessage( "Step Description", "");
         lblStepdescription_Visible = 1;
         divTablewizardmain_Visible = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV14WWPForm","fld":"vWWPFORM"},{"av":"AV15IsFirstElement","fld":"vISFIRSTELEMENT"},{"av":"AV16IsLastElement","fld":"vISLASTELEMENT"},{"av":"AV12WizardSteps","fld":"vWIZARDSTEPS","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"divTableactionscell_Class","ctrl":"TABLEACTIONSCELL","prop":"Class"},{"av":"lblStepdescription_Visible","ctrl":"STEPDESCRIPTION","prop":"Visible"},{"av":"Btnprevious_Visible","ctrl":"BTNPREVIOUS","prop":"Visible"},{"av":"Btnnext_Visible","ctrl":"BTNNEXT","prop":"Visible"}]}""");
         setEventMetadata("SETTINGS_MODAL.ONLOADCOMPONENT","""{"handler":"E12282","iparms":[{"av":"AV9SessionId","fld":"vSESSIONID","pic":"ZZZ9"}]""");
         setEventMetadata("SETTINGS_MODAL.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("ADDELEMENT_MODAL.ONLOADCOMPONENT","""{"handler":"E14282","iparms":[{"av":"AV9SessionId","fld":"vSESSIONID","pic":"ZZZ9"}]""");
         setEventMetadata("ADDELEMENT_MODAL.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("'DOPREVIOUS'","""{"handler":"E17282","iparms":[{"av":"AV12WizardSteps","fld":"vWIZARDSTEPS","hsh":true},{"av":"AV5CurrentStepAux","fld":"vCURRENTSTEPAUX"},{"av":"AV9SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV13WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV14WWPForm","fld":"vWWPFORM"},{"av":"AV15IsFirstElement","fld":"vISFIRSTELEMENT"},{"av":"AV16IsLastElement","fld":"vISLASTELEMENT"}]""");
         setEventMetadata("'DOPREVIOUS'",""","oparms":[{"av":"AV8i","fld":"vI","pic":"ZZZ9"},{"av":"AV5CurrentStepAux","fld":"vCURRENTSTEPAUX"},{"av":"AV14WWPForm","fld":"vWWPFORM"},{"ctrl":"WIZARDHEADER"},{"av":"AV16IsLastElement","fld":"vISLASTELEMENT"},{"av":"AV15IsFirstElement","fld":"vISFIRSTELEMENT"},{"av":"lblStepdescription_Caption","ctrl":"STEPDESCRIPTION","prop":"Caption"},{"ctrl":"DYNAMICFORMFS_WC"},{"av":"Btnprevious_Visible","ctrl":"BTNPREVIOUS","prop":"Visible"},{"av":"Btnnext_Visible","ctrl":"BTNNEXT","prop":"Visible"}]}""");
         setEventMetadata("'DONEXT'","""{"handler":"E18282","iparms":[{"av":"AV12WizardSteps","fld":"vWIZARDSTEPS","hsh":true},{"av":"AV5CurrentStepAux","fld":"vCURRENTSTEPAUX"},{"av":"AV9SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV13WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV14WWPForm","fld":"vWWPFORM"},{"av":"AV15IsFirstElement","fld":"vISFIRSTELEMENT"},{"av":"AV16IsLastElement","fld":"vISLASTELEMENT"}]""");
         setEventMetadata("'DONEXT'",""","oparms":[{"av":"AV8i","fld":"vI","pic":"ZZZ9"},{"av":"AV5CurrentStepAux","fld":"vCURRENTSTEPAUX"},{"av":"AV14WWPForm","fld":"vWWPFORM"},{"ctrl":"WIZARDHEADER"},{"av":"AV16IsLastElement","fld":"vISLASTELEMENT"},{"av":"AV15IsFirstElement","fld":"vISFIRSTELEMENT"},{"av":"lblStepdescription_Caption","ctrl":"STEPDESCRIPTION","prop":"Caption"},{"ctrl":"DYNAMICFORMFS_WC"},{"av":"Btnprevious_Visible","ctrl":"BTNPREVIOUS","prop":"Visible"},{"av":"Btnnext_Visible","ctrl":"BTNNEXT","prop":"Visible"}]}""");
         setEventMetadata("SETTINGS_MODAL.CLOSE","""{"handler":"E11282","iparms":[{"av":"Settings_modal_Result","ctrl":"SETTINGS_MODAL","prop":"Result"},{"av":"AV12WizardSteps","fld":"vWIZARDSTEPS","hsh":true},{"av":"AV5CurrentStepAux","fld":"vCURRENTSTEPAUX"}]""");
         setEventMetadata("SETTINGS_MODAL.CLOSE",""","oparms":[{"av":"AV8i","fld":"vI","pic":"ZZZ9"}]}""");
         setEventMetadata("ADDELEMENT_MODAL.CLOSE","""{"handler":"E13282","iparms":[{"av":"Addelement_modal_Result","ctrl":"ADDELEMENT_MODAL","prop":"Result"},{"av":"AV12WizardSteps","fld":"vWIZARDSTEPS","hsh":true}]""");
         setEventMetadata("ADDELEMENT_MODAL.CLOSE",""","oparms":[{"av":"AV8i","fld":"vI","pic":"ZZZ9"}]}""");
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
         AV14WWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         wcpOAV13WWPDynamicFormMode = "";
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
         AV12WizardSteps = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem>( context, "WizardStepsItem", "Comforta_version2");
         GX_FocusControl = "";
         WebComp_Wizardheader_Component = "";
         OldWizardheader = "";
         lblStepdescription_Jsonclick = "";
         WebComp_Dynamicformfs_wc_Component = "";
         OldDynamicformfs_wc = "";
         ucBtnprevious = new GXUserControl();
         ucBtnnext = new GXUserControl();
         TempTags = "";
         AV5CurrentStepAux = "";
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV10WizardStep = new WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem(context);
         AV11WizardStepAux = new WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem(context);
         AV19WebSession = context.GetSession();
         GXt_SdtWWP_Form1 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         AV7Element = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         AV18WWP_DF_StepMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_StepMetadata(context);
         sStyleString = "";
         ucAddelement_modal = new GXUserControl();
         ucSettings_modal = new GXUserControl();
         ucBtnsettings = new GXUserControl();
         ucBtnaddelement = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV13WWPDynamicFormMode = "";
         sCtrlAV9SessionId = "";
         sCtrlAV6DefaultSelectedStepIndex = "";
         sCtrlAV14WWPForm = "";
         WebComp_Wizardheader = new GeneXus.Http.GXNullWebComponent();
         WebComp_Dynamicformfs_wc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short AV9SessionId ;
      private short AV6DefaultSelectedStepIndex ;
      private short wcpOAV9SessionId ;
      private short wcpOAV6DefaultSelectedStepIndex ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short AV8i ;
      private short nDraw ;
      private short nDoneStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int divTablewizardmain_Visible ;
      private int lblStepdescription_Visible ;
      private int edtavCurrentstepaux_Visible ;
      private int edtavI_Visible ;
      private int AV23GXV1 ;
      private int AV24GXV2 ;
      private int tblUnnamedtable2_Visible ;
      private int AV25GXV3 ;
      private int AV26GXV4 ;
      private int AV27GXV5 ;
      private int idxLst ;
      private string AV13WWPDynamicFormMode ;
      private string wcpOAV13WWPDynamicFormMode ;
      private string Settings_modal_Result ;
      private string Addelement_modal_Result ;
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
      private string divTablewizardmain_Internalname ;
      private string WebComp_Wizardheader_Component ;
      private string OldWizardheader ;
      private string lblStepdescription_Internalname ;
      private string lblStepdescription_Caption ;
      private string lblStepdescription_Jsonclick ;
      private string divWizardsteps_Internalname ;
      private string WebComp_Dynamicformfs_wc_Component ;
      private string OldDynamicformfs_wc ;
      private string divTableactionscell_Internalname ;
      private string divTableactionscell_Class ;
      private string divTableactions_Internalname ;
      private string Btnprevious_Tooltiptext ;
      private string Btnprevious_Beforeiconclass ;
      private string Btnprevious_Caption ;
      private string Btnprevious_Class ;
      private string Btnprevious_Internalname ;
      private string Btnnext_Tooltiptext ;
      private string Btnnext_Aftericonclass ;
      private string Btnnext_Caption ;
      private string Btnnext_Class ;
      private string Btnnext_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string TempTags ;
      private string edtavCurrentstepaux_Internalname ;
      private string edtavCurrentstepaux_Jsonclick ;
      private string edtavI_Internalname ;
      private string edtavI_Jsonclick ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string tblUnnamedtable2_Internalname ;
      private string sStyleString ;
      private string tblTableaddelement_modal_Internalname ;
      private string Addelement_modal_Width ;
      private string Addelement_modal_Title ;
      private string Addelement_modal_Confirmtype ;
      private string Addelement_modal_Bodytype ;
      private string Addelement_modal_Internalname ;
      private string tblTablesettings_modal_Internalname ;
      private string Settings_modal_Width ;
      private string Settings_modal_Title ;
      private string Settings_modal_Confirmtype ;
      private string Settings_modal_Bodytype ;
      private string Settings_modal_Internalname ;
      private string Btnsettings_Tooltiptext ;
      private string Btnsettings_Beforeiconclass ;
      private string Btnsettings_Caption ;
      private string Btnsettings_Class ;
      private string Btnsettings_Internalname ;
      private string Btnaddelement_Tooltiptext ;
      private string Btnaddelement_Beforeiconclass ;
      private string Btnaddelement_Caption ;
      private string Btnaddelement_Class ;
      private string Btnaddelement_Internalname ;
      private string sCtrlAV13WWPDynamicFormMode ;
      private string sCtrlAV9SessionId ;
      private string sCtrlAV6DefaultSelectedStepIndex ;
      private string sCtrlAV14WWPForm ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15IsFirstElement ;
      private bool AV16IsLastElement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool Btnprevious_Visible ;
      private bool Btnnext_Visible ;
      private bool AV17IsVis ;
      private bool bDynCreated_Wizardheader ;
      private bool bDynCreated_Dynamicformfs_wc ;
      private string AV5CurrentStepAux ;
      private GXWebComponent WebComp_Wizardheader ;
      private GXWebComponent WebComp_Dynamicformfs_wc ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXUserControl ucBtnprevious ;
      private GXUserControl ucBtnnext ;
      private GXUserControl ucAddelement_modal ;
      private GXUserControl ucSettings_modal ;
      private GXUserControl ucBtnsettings ;
      private GXUserControl ucBtnaddelement ;
      private GXWebForm Form ;
      private IGxSession AV19WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV14WWPForm ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP3_WWPForm ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem> AV12WizardSteps ;
      private WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem AV10WizardStep ;
      private WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem AV11WizardStepAux ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form GXt_SdtWWP_Form1 ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV7Element ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_StepMetadata AV18WWP_DF_StepMetadata ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
