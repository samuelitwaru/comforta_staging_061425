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
   public class wwp_df_wizard_wc : GXWebComponent
   {
      public wwp_df_wizard_wc( )
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

      public wwp_df_wizard_wc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPDynamicFormMode ,
                           short aP1_SessionId ,
                           string aP2_DefaultStep ,
                           ref GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP3_WWPFormInstance ,
                           string aP4_AccessToken )
      {
         this.AV19WWPDynamicFormMode = aP0_WWPDynamicFormMode;
         this.AV15SessionId = aP1_SessionId;
         this.AV29DefaultStep = aP2_DefaultStep;
         this.AV21WWPFormInstance = aP3_WWPFormInstance;
         this.AV33AccessToken = aP4_AccessToken;
         ExecuteImpl();
         aP3_WWPFormInstance=this.AV21WWPFormInstance;
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
                  AV19WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
                  AssignAttri(sPrefix, false, "AV19WWPDynamicFormMode", AV19WWPDynamicFormMode);
                  AV15SessionId = (short)(Math.Round(NumberUtil.Val( GetPar( "SessionId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV15SessionId", StringUtil.LTrimStr( (decimal)(AV15SessionId), 4, 0));
                  AV29DefaultStep = GetPar( "DefaultStep");
                  AssignAttri(sPrefix, false, "AV29DefaultStep", AV29DefaultStep);
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV21WWPFormInstance);
                  AV33AccessToken = GetPar( "AccessToken");
                  AssignAttri(sPrefix, false, "AV33AccessToken", AV33AccessToken);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV19WWPDynamicFormMode,(short)AV15SessionId,(string)AV29DefaultStep,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV21WWPFormInstance,(string)AV33AccessToken});
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
            PA252( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS252( ) ;
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
            context.SendWebValue( context.GetMessage( "WWP_Dynamic Form_Wizard_WC", "")) ;
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
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_df_wizard_wc.aspx"+UrlEncode(StringUtil.RTrim(AV19WWPDynamicFormMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV15SessionId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV29DefaultStep)) + "," + UrlEncode(StringUtil.RTrim(AV33AccessToken));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.dynamicforms.wwp_df_wizard_wc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV19WWPDynamicFormMode", StringUtil.RTrim( wcpOAV19WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV15SessionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV15SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV29DefaultStep", wcpOAV29DefaultStep);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV33AccessToken", wcpOAV33AccessToken);
         GxWebStd.gx_hidden_field( context, sPrefix+"vNEXTORPREVSTEPINDEX", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25NextOrPrevStepIndex), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCURRENTSTEPINDEX", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12CurrentStepIndex), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDSTEPS", AV18WizardSteps);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDSTEPS", AV18WizardSteps);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASCONDITIONALSTEPS", AV23HasConditionalSteps);
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTORDERINDEX", StringUtil.LTrim( StringUtil.NToC( (decimal)(A212WWPFormElementOrderIndex), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORMINSTANCE", AV21WWPFormInstance);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORMINSTANCE", AV21WWPFormInstance);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(A217WWPFormElementType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTMETADATA", A236WWPFormElementMetadata);
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A210WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTTITLE", A229WWPFormElementTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"vCURRENTSTEP", AV10CurrentStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vWIZARDCONTENTALREADYLOADED", AV28WizardContentAlreadyLoaded);
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV19WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vFINDNEXT", AV13FindNext);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASERRORS", AV5HasErrors);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMESSAGES", AV7Messages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMESSAGES", AV7Messages);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vERRORIDS", AV9ErrorIds);
         GxWebStd.gx_hidden_field( context, sPrefix+"vACCESSTOKEN", AV33AccessToken);
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMREFERENCENAME", A208WWPFormReferenceName);
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMTITLE", A209WWPFormTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"vFORMNAME", AV35FormName);
         GxWebStd.gx_hidden_field( context, sPrefix+"vRESIDENTNAME", AV38ResidentName);
         GxWebStd.gx_hidden_field( context, sPrefix+"vAUXSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27AuxSessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDEFAULTSTEP", AV29DefaultStep);
      }

      protected void RenderHtmlCloseForm252( )
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
         return "WorkWithPlus.DynamicForms.WWP_DF_Wizard_WC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WWP_Dynamic Form_Wizard_WC", "") ;
      }

      protected void WB250( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "workwithplus.dynamicforms.wwp_df_wizard_wc.aspx");
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableWizardMainWithShadow", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WizardStepsCell", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, sPrefix+"W0009"+"", StringUtil.RTrim( WebComp_Wizardheader_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0009"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wizardheader_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWizardheader), StringUtil.Lower( WebComp_Wizardheader_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0009"+"");
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
            GxWebStd.gx_label_ctrl( context, lblStepdescription_Internalname, lblStepdescription_Caption, "", "", lblStepdescription_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "WizardStepDescription", 0, "", 1, 1, 0, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DF_Wizard_WC.htm");
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
               GxWebStd.gx_hidden_field( context, sPrefix+"W0018"+"", StringUtil.RTrim( WebComp_Dynamicformfs_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0018"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Dynamicformfs_wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldDynamicformfs_wc), StringUtil.Lower( WebComp_Dynamicformfs_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0018"+"");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellWizardActions", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;justify-content:space-between;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnprevious_Internalname, "", context.GetMessage( "GXM_previous", ""), bttBtnprevious_Jsonclick, 5, context.GetMessage( "GXM_previous", ""), "", StyleString, ClassString, bttBtnprevious_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOPREVIOUS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/DynamicForms/WWP_DF_Wizard_WC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnnext_Internalname, "", bttBtnnext_Caption, bttBtnnext_Jsonclick, 5, context.GetMessage( "GXM_next", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DONEXT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/DynamicForms/WWP_DF_Wizard_WC.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCurrentstepaux_Internalname, AV11CurrentStepAux, StringUtil.RTrim( context.localUtil.Format( AV11CurrentStepAux, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCurrentstepaux_Jsonclick, 0, "Attribute", "", "", "", "", edtavCurrentstepaux_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WorkWithPlus/DynamicForms/WWP_DF_Wizard_WC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START252( )
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
            Form.Meta.addItem("description", context.GetMessage( "WWP_Dynamic Form_Wizard_WC", ""), 0) ;
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
               STRUP250( ) ;
            }
         }
      }

      protected void WS252( )
      {
         START252( ) ;
         EVT252( ) ;
      }

      protected void EVT252( )
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
                                 STRUP250( ) ;
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
                                 STRUP250( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11252 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOPREVIOUS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP250( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoPrevious' */
                                    E12252 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DONEXT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP250( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoNext' */
                                    E13252 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP250( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E14252 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP250( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E15252 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP250( ) ;
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
                                 STRUP250( ) ;
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
                        if ( nCmpId == 9 )
                        {
                           OldWizardheader = cgiGet( sPrefix+"W0009");
                           if ( ( StringUtil.Len( OldWizardheader) == 0 ) || ( StringUtil.StrCmp(OldWizardheader, WebComp_Wizardheader_Component) != 0 ) )
                           {
                              WebComp_Wizardheader = getWebComponent(GetType(), "GeneXus.Programs", OldWizardheader, new Object[] {context} );
                              WebComp_Wizardheader.ComponentInit();
                              WebComp_Wizardheader.Name = "OldWizardheader";
                              WebComp_Wizardheader_Component = OldWizardheader;
                           }
                           if ( StringUtil.Len( WebComp_Wizardheader_Component) != 0 )
                           {
                              WebComp_Wizardheader.componentprocess(sPrefix+"W0009", "", sEvt);
                           }
                           WebComp_Wizardheader_Component = OldWizardheader;
                        }
                        else if ( nCmpId == 18 )
                        {
                           OldDynamicformfs_wc = cgiGet( sPrefix+"W0018");
                           if ( ( StringUtil.Len( OldDynamicformfs_wc) == 0 ) || ( StringUtil.StrCmp(OldDynamicformfs_wc, WebComp_Dynamicformfs_wc_Component) != 0 ) )
                           {
                              WebComp_Dynamicformfs_wc = getWebComponent(GetType(), "GeneXus.Programs", OldDynamicformfs_wc, new Object[] {context} );
                              WebComp_Dynamicformfs_wc.ComponentInit();
                              WebComp_Dynamicformfs_wc.Name = "OldDynamicformfs_wc";
                              WebComp_Dynamicformfs_wc_Component = OldDynamicformfs_wc;
                           }
                           if ( StringUtil.Len( WebComp_Dynamicformfs_wc_Component) != 0 )
                           {
                              WebComp_Dynamicformfs_wc.componentprocess(sPrefix+"W0018", "", sEvt);
                           }
                           WebComp_Dynamicformfs_wc_Component = OldDynamicformfs_wc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE252( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm252( ) ;
            }
         }
      }

      protected void PA252( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.dynamicforms.wwp_df_wizard_wc.aspx")), "workwithplus.dynamicforms.wwp_df_wizard_wc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.dynamicforms.wwp_df_wizard_wc.aspx")))) ;
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
         RF252( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF252( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
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
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E15252 ();
            WB250( ) ;
         }
      }

      protected void send_integrity_lvl_hashes252( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP250( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11252 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOAV19WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV19WWPDynamicFormMode");
            wcpOAV15SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV15SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV29DefaultStep = cgiGet( sPrefix+"wcpOAV29DefaultStep");
            wcpOAV33AccessToken = cgiGet( sPrefix+"wcpOAV33AccessToken");
            /* Read variables values. */
            AV11CurrentStepAux = cgiGet( edtavCurrentstepaux_Internalname);
            AssignAttri(sPrefix, false, "AV11CurrentStepAux", AV11CurrentStepAux);
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
         E11252 ();
         if (returnInSub) return;
      }

      protected void E11252( )
      {
         /* Start Routine */
         returnInSub = false;
         edtavCurrentstepaux_Visible = 0;
         AssignProp(sPrefix, false, edtavCurrentstepaux_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCurrentstepaux_Visible), 5, 0), true);
         AV23HasConditionalSteps = true;
         AssignAttri(sPrefix, false, "AV23HasConditionalSteps", AV23HasConditionalSteps);
         AV10CurrentStep = AV29DefaultStep;
         AssignAttri(sPrefix, false, "AV10CurrentStep", AV10CurrentStep);
         /* Execute user subroutine: 'LOAD WIZARD STEPS AND CONTENT' */
         S112 ();
         if (returnInSub) return;
      }

      protected void E12252( )
      {
         /* 'DoPrevious' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GET CURRENT STEP INDEX' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GET PREVIOUS VISIBLE STEP' */
         S132 ();
         if (returnInSub) return;
         if ( (0==AV25NextOrPrevStepIndex) )
         {
            AV25NextOrPrevStepIndex = AV12CurrentStepIndex;
            AssignAttri(sPrefix, false, "AV25NextOrPrevStepIndex", StringUtil.LTrimStr( (decimal)(AV25NextOrPrevStepIndex), 4, 0));
         }
         AV10CurrentStep = ((WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem)AV18WizardSteps.Item(AV25NextOrPrevStepIndex)).gxTpr_Code;
         AssignAttri(sPrefix, false, "AV10CurrentStep", AV10CurrentStep);
         /* Execute user subroutine: 'LOAD WIZARD STEPS AND CONTENT' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18WizardSteps", AV18WizardSteps);
      }

      protected void E13252( )
      {
         /* 'DoNext' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GET CURRENT STEP INDEX' */
         S122 ();
         if (returnInSub) return;
         AV11CurrentStepAux = ((WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem)AV18WizardSteps.Item(AV12CurrentStepIndex)).gxTpr_Code;
         AssignAttri(sPrefix, false, "AV11CurrentStepAux", AV11CurrentStepAux);
         AV20WWPFormElementId = (short)(Math.Round(NumberUtil.Val( ((WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem)AV18WizardSteps.Item(AV12CurrentStepIndex)).gxTpr_Code, "."), 18, MidpointRounding.ToEven));
         GXt_SdtWWP_FormInstance1 = AV21WWPFormInstance;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadforminstance(context ).execute(  AV15SessionId, out  GXt_SdtWWP_FormInstance1) ;
         AV21WWPFormInstance = GXt_SdtWWP_FormInstance1;
         if ( StringUtil.StrCmp(AV19WWPDynamicFormMode, "DSP") != 0 )
         {
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_validatestep(context ).execute(  AV21WWPFormInstance,  AV20WWPFormElementId,  true, out  AV5HasErrors, out  AV9ErrorIds, out  AV7Messages) ;
            AssignAttri(sPrefix, false, "AV5HasErrors", AV5HasErrors);
            AssignAttri(sPrefix, false, "AV9ErrorIds", AV9ErrorIds);
         }
         if ( AV5HasErrors )
         {
            if ( AV7Messages.Count == 0 )
            {
               this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "DynamicForm_Validate", new Object[] {(short)AV15SessionId,(string)AV9ErrorIds}, true);
            }
            else
            {
               AV44GXV1 = 1;
               while ( AV44GXV1 <= AV7Messages.Count )
               {
                  AV6Message = ((GeneXus.Utils.SdtMessages_Message)AV7Messages.Item(AV44GXV1));
                  GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV6Message.gxTpr_Description,  "error",  "",  "true",  ""));
                  AV44GXV1 = (int)(AV44GXV1+1);
               }
            }
         }
         else
         {
            /* Execute user subroutine: 'GET NEXT VISIBLE STEP' */
            S142 ();
            if (returnInSub) return;
            if ( (0==AV25NextOrPrevStepIndex) )
            {
               /* Execute user subroutine: 'FINISHWIZARD' */
               S152 ();
               if (returnInSub) return;
            }
            else
            {
               AV10CurrentStep = ((WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem)AV18WizardSteps.Item(AV25NextOrPrevStepIndex)).gxTpr_Code;
               AssignAttri(sPrefix, false, "AV10CurrentStep", AV10CurrentStep);
               /* Execute user subroutine: 'LOAD WIZARD STEPS AND CONTENT' */
               S112 ();
               if (returnInSub) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21WWPFormInstance", AV21WWPFormInstance);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV7Messages", AV7Messages);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18WizardSteps", AV18WizardSteps);
      }

      protected void E14252( )
      {
         /* General\GlobalEvents_Dynamicform_updatevisibilities Routine */
         returnInSub = false;
         if ( ( AV27AuxSessionId == AV15SessionId ) && AV23HasConditionalSteps )
         {
            GXt_SdtWWP_FormInstance1 = AV21WWPFormInstance;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadforminstance(context ).execute(  AV15SessionId, out  GXt_SdtWWP_FormInstance1) ;
            AV21WWPFormInstance = GXt_SdtWWP_FormInstance1;
            AV28WizardContentAlreadyLoaded = true;
            AssignAttri(sPrefix, false, "AV28WizardContentAlreadyLoaded", AV28WizardContentAlreadyLoaded);
            /* Execute user subroutine: 'LOAD WIZARD STEPS AND CONTENT' */
            S112 ();
            if (returnInSub) return;
            AV28WizardContentAlreadyLoaded = false;
            AssignAttri(sPrefix, false, "AV28WizardContentAlreadyLoaded", AV28WizardContentAlreadyLoaded);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21WWPFormInstance", AV21WWPFormInstance);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18WizardSteps", AV18WizardSteps);
      }

      protected void S152( )
      {
         /* 'FINISHWIZARD' Routine */
         returnInSub = false;
         AV5HasErrors = false;
         AssignAttri(sPrefix, false, "AV5HasErrors", AV5HasErrors);
         if ( StringUtil.StrCmp(AV19WWPDynamicFormMode, "DSP") != 0 )
         {
            /* Using cursor H00252 */
            pr_default.execute(0, new Object[] {AV21WWPFormInstance.gxTpr_Wwpformid, AV21WWPFormInstance.gxTpr_Wwpformversionnumber});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A217WWPFormElementType = H00252_A217WWPFormElementType[0];
               A207WWPFormVersionNumber = H00252_A207WWPFormVersionNumber[0];
               A206WWPFormId = H00252_A206WWPFormId[0];
               A210WWPFormElementId = H00252_A210WWPFormElementId[0];
               A212WWPFormElementOrderIndex = H00252_A212WWPFormElementOrderIndex[0];
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_validatestep(context ).execute(  AV21WWPFormInstance,  A210WWPFormElementId,  true, out  AV5HasErrors, out  AV9ErrorIds, out  AV7Messages) ;
               AssignAttri(sPrefix, false, "AV5HasErrors", AV5HasErrors);
               AssignAttri(sPrefix, false, "AV9ErrorIds", AV9ErrorIds);
               if ( AV5HasErrors )
               {
                  if ( AV7Messages.Count == 0 )
                  {
                     AV10CurrentStep = StringUtil.Trim( StringUtil.Str( (decimal)(A210WWPFormElementId), 4, 0));
                     AssignAttri(sPrefix, false, "AV10CurrentStep", AV10CurrentStep);
                     /* Execute user subroutine: 'LOAD WIZARD STEPS AND CONTENT' */
                     S112 ();
                     if ( returnInSub )
                     {
                        pr_default.close(0);
                        returnInSub = true;
                        if (true) return;
                     }
                     this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "DynamicForm_Validate", new Object[] {(short)AV15SessionId,(string)AV9ErrorIds}, true);
                  }
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( ! AV5HasErrors )
            {
               AV22Validations = new GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation>( context, "WWP_DF_Validation", "Comforta_version2");
               AV22Validations.FromJSonString(AV21WWPFormInstance.gxTpr_Wwpformvalidations, null);
               if ( AV22Validations.Count > 0 )
               {
                  new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_executeelementvalidations(context ).execute(  AV21WWPFormInstance,  0,  "",  AV22Validations, out  AV7Messages) ;
                  if ( AV7Messages.Count > 0 )
                  {
                     AV5HasErrors = true;
                     AssignAttri(sPrefix, false, "AV5HasErrors", AV5HasErrors);
                  }
               }
            }
            if ( ! AV5HasErrors )
            {
               AV32ResidentGUID = AV16WebSession.Get(context.GetMessage( "WebViewResidentId", ""));
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV32ResidentGUID)) )
               {
                  new prc_getuseridfromaccesstoken(context ).execute(  AV33AccessToken, out  AV32ResidentGUID, out  AV37isTokenValid) ;
               }
               AV36GAMUser.load( AV32ResidentGUID);
               if ( AV36GAMUser.success() )
               {
                  AV38ResidentName = AV36GAMUser.gxTpr_Firstname + " " + AV36GAMUser.gxTpr_Lastname;
                  AssignAttri(sPrefix, false, "AV38ResidentName", AV38ResidentName);
               }
               /* Using cursor H00253 */
               pr_default.execute(1);
               while ( (pr_default.getStatus(1) != 101) )
               {
                  BRK254 = false;
                  A207WWPFormVersionNumber = H00253_A207WWPFormVersionNumber[0];
                  A206WWPFormId = H00253_A206WWPFormId[0];
                  A208WWPFormReferenceName = H00253_A208WWPFormReferenceName[0];
                  A209WWPFormTitle = H00253_A209WWPFormTitle[0];
                  if ( StringUtil.StrCmp(A208WWPFormReferenceName, AV21WWPFormInstance.gxTpr_Wwpformreferencename) == 0 )
                  {
                     AV35FormName = A209WWPFormTitle;
                     AssignAttri(sPrefix, false, "AV35FormName", AV35FormName);
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
                  while ( (pr_default.getStatus(1) != 101) && ( H00253_A206WWPFormId[0] == A206WWPFormId ) )
                  {
                     BRK254 = false;
                     A207WWPFormVersionNumber = H00253_A207WWPFormVersionNumber[0];
                     A208WWPFormReferenceName = H00253_A208WWPFormReferenceName[0];
                     A209WWPFormTitle = H00253_A209WWPFormTitle[0];
                     BRK254 = true;
                     pr_default.readNext(1);
                  }
                  if ( ! BRK254 )
                  {
                     BRK254 = true;
                     pr_default.readNext(1);
                  }
               }
               pr_default.close(1);
               if ( ( StringUtil.StrCmp(AV19WWPDynamicFormMode, "UPD") == 0 ) || ( StringUtil.StrCmp(AV19WWPDynamicFormMode, "INS") == 0 ) )
               {
                  AV21WWPFormInstance.gxTpr_Wwpuserextendedid = AV32ResidentGUID;
                  AV21WWPFormInstance.Save();
               }
               else if ( StringUtil.StrCmp(AV19WWPDynamicFormMode, "DLT") == 0 )
               {
                  AV21WWPFormInstance.Delete();
               }
               if ( AV21WWPFormInstance.Success() )
               {
                  AV16WebSession.Remove(StringUtil.Format( "WWP_DF_%1", StringUtil.Trim( StringUtil.Str( (decimal)(AV15SessionId), 4, 0)), "", "", "", "", "", "", "", ""));
                  new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue(context ).execute(  StringUtil.Format( "WWP_DF_%1", StringUtil.Trim( StringUtil.Str( (decimal)(AV15SessionId), 4, 0)), "", "", "", "", "", "", "", ""),  "") ;
                  new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue(context ).execute(  StringUtil.Format( "WWPDynFormCurrentForm_%1", StringUtil.Trim( StringUtil.Str( (decimal)(AV21WWPFormInstance.gxTpr_Wwpformid), 4, 0)), "", "", "", "", "", "", "", ""),  "") ;
                  new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue(context ).execute(  StringUtil.Format( "WWPDynFormCurrentFormVersion_%1", StringUtil.Trim( StringUtil.Str( (decimal)(AV21WWPFormInstance.gxTpr_Wwpformid), 4, 0)), "", "", "", "", "", "", "", ""),  "") ;
                  new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue(context ).execute(  StringUtil.Format( "WWPDynFormCurrentStep_%1", StringUtil.Trim( StringUtil.Str( (decimal)(AV21WWPFormInstance.gxTpr_Wwpformid), 4, 0)), "", "", "", "", "", "", "", ""),  "") ;
                  context.CommitDataStores("workwithplus.dynamicforms.wwp_df_wizard_wc",pr_default);
                  GX_msglist.addItem(context.GetMessage( "Form Submitted successfully", ""));
                  AV34FormInstanceIdString = StringUtil.Trim( StringUtil.Str( (decimal)(AV21WWPFormInstance.gxTpr_Wwpforminstanceid), 6, 0));
                  AV48Formlink = formatLink("workwithplus.dynamicforms.wwp_dynamicform.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV21WWPFormInstance.gxTpr_Wwpformreferencename)),UrlEncode(StringUtil.LTrimStr(AV21WWPFormInstance.gxTpr_Wwpforminstanceid,6,0)),UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.BoolToStr(false))}, new string[] {"WWPFormReferenceName","WWPFormInstanceId","WWPDynamicFormMode","isLinkingDiscussion"}) ;
                  if ( StringUtil.StrCmp(AV19WWPDynamicFormMode, "INS") == 0 )
                  {
                     AV42NotificationDescription = AV35FormName + " - " + AV38ResidentName;
                     AV39SDT_NotificationMetadata = new SdtSDT_NotificationMetadata(context);
                     AV39SDT_NotificationMetadata.gxTpr_Isparentnotification = true;
                     AV39SDT_NotificationMetadata.gxTpr_Parentnotificationid = StringUtil.Trim( StringUtil.Str( (decimal)(AV21WWPFormInstance.gxTpr_Wwpforminstanceid), 6, 0));
                     AV39SDT_NotificationMetadata.gxTpr_Formreferencename = AV21WWPFormInstance.gxTpr_Wwpformreferencename;
                     AV39SDT_NotificationMetadata.gxTpr_Notificationtriggeredtimestamp = DateTimeUtil.Now( context);
                     AV39SDT_NotificationMetadata.gxTpr_Notificationorigin = context.GetMessage( "DynamicForms", "");
                     AV40WWPNotificationMetadataSDT = new SdtUSDTNotificationMetadata(context);
                     AV40WWPNotificationMetadataSDT.gxTpr_Custommetadata = AV39SDT_NotificationMetadata;
                     AV16WebSession.Set(context.GetMessage( "FormFilledMessage", ""), context.GetMessage( "Form submitted successfully", ""));
                     new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendnotification(context ).execute(  "DynamicFormNotification",  "DynamicForms",  "",  "fas fa-file-alt NotificationFontIconSuccess",  "New Form Response",  AV42NotificationDescription,  AV42NotificationDescription,  AV48Formlink,  AV40WWPNotificationMetadataSDT.ToJSonString(false, true),  "",  true) ;
                     AV43ResidentIdCollection.Clear();
                     AV43ResidentIdCollection.Add(new prc_getresidentidfromguid(context).executeUdp(  AV32ResidentGUID), 0);
                     AV41Metadata = new SdtSDT_OneSignalCustomData(context);
                     AV41Metadata.gxTpr_Notificationcategory = "Form";
                     AV41Metadata.gxTpr_Formdetails.gxTpr_Forminstanceid = (short)(AV21WWPFormInstance.gxTpr_Wwpforminstanceid);
                     AV41Metadata.gxTpr_Formdetails.gxTpr_Formmode = "DSP";
                     AV41Metadata.gxTpr_Formdetails.gxTpr_Formreferencename = AV21WWPFormInstance.gxTpr_Wwpformreferencename;
                     new prc_sendresidentnotification(context ).execute(  "New Filled Form",  "You have filled out a form ("+AV35FormName+")",  context.GetMessage( "FORM", ""),  AV41Metadata,  AV43ResidentIdCollection) ;
                     new prc_subscriberesidenttodiscussion(context ).execute(  context.GetMessage( "GeneralDiscussion", ""),  context.GetMessage( "Discussion", ""),  StringUtil.Trim( StringUtil.Str( (decimal)(AV21WWPFormInstance.gxTpr_Wwpforminstanceid), 6, 0)),  AV42NotificationDescription,  AV32ResidentGUID) ;
                  }
                  else if ( StringUtil.StrCmp(AV19WWPDynamicFormMode, "UPD") == 0 )
                  {
                     AV42NotificationDescription = "Resident: " + AV38ResidentName + " " + context.GetMessage( "has updated their filled out form (", "") + AV35FormName + ")";
                     AV39SDT_NotificationMetadata = new SdtSDT_NotificationMetadata(context);
                     AV39SDT_NotificationMetadata.gxTpr_Isparentnotification = false;
                     AV39SDT_NotificationMetadata.gxTpr_Parentnotificationid = StringUtil.Str( (decimal)(AV21WWPFormInstance.gxTpr_Wwpforminstanceid), 6, 0);
                     AV39SDT_NotificationMetadata.gxTpr_Formreferencename = AV21WWPFormInstance.gxTpr_Wwpformreferencename;
                     AV39SDT_NotificationMetadata.gxTpr_Notificationtriggeredtimestamp = DateTimeUtil.Now( context);
                     AV39SDT_NotificationMetadata.gxTpr_Notificationorigin = "DynamicForms";
                     AV40WWPNotificationMetadataSDT = new SdtUSDTNotificationMetadata(context);
                     AV40WWPNotificationMetadataSDT.gxTpr_Custommetadata = AV39SDT_NotificationMetadata;
                     AV16WebSession.Set(context.GetMessage( "FormFilledMessage", ""), context.GetMessage( "Form updated successfully", ""));
                     new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendnotification(context ).execute(  context.GetMessage( "DynamicFormNotification", ""),  context.GetMessage( "DynamicForms", ""),  "",  context.GetMessage( "fas fa-pencil-alt NotificationFontIconWarning", ""),  "Form Response Updated",  AV42NotificationDescription,  AV42NotificationDescription,  AV48Formlink,  AV40WWPNotificationMetadataSDT.ToJSonString(false, true),  "",  true) ;
                  }
                  else if ( StringUtil.StrCmp(AV19WWPDynamicFormMode, "DLT") == 0 )
                  {
                     AV42NotificationDescription = "Resident: " + AV38ResidentName + " " + context.GetMessage( "has delete their filled out form (", "") + AV35FormName + ")";
                     AV39SDT_NotificationMetadata = new SdtSDT_NotificationMetadata(context);
                     AV39SDT_NotificationMetadata.gxTpr_Isparentnotification = false;
                     AV39SDT_NotificationMetadata.gxTpr_Parentnotificationid = StringUtil.Str( (decimal)(AV21WWPFormInstance.gxTpr_Wwpforminstanceid), 6, 0);
                     AV39SDT_NotificationMetadata.gxTpr_Formreferencename = AV21WWPFormInstance.gxTpr_Wwpformreferencename;
                     AV39SDT_NotificationMetadata.gxTpr_Notificationtriggeredtimestamp = DateTimeUtil.Now( context);
                     AV39SDT_NotificationMetadata.gxTpr_Notificationorigin = "DynamicForms";
                     AV40WWPNotificationMetadataSDT = new SdtUSDTNotificationMetadata(context);
                     AV40WWPNotificationMetadataSDT.gxTpr_Custommetadata = AV39SDT_NotificationMetadata;
                     AV16WebSession.Set(context.GetMessage( "FormFilledMessage", ""), context.GetMessage( "Form deleted successfully", ""));
                     new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendnotification(context ).execute(  "DynamicFormNotification",  "DynamicForms",  "",  "fas fa-trash-alt NotificationFontIconDanger",  "Form Response Deleted",  AV42NotificationDescription,  AV42NotificationDescription,  AV48Formlink,  AV40WWPNotificationMetadataSDT.ToJSonString(false, true),  "",  true) ;
                  }
                  CallWebObject(formatLink("wp_residentfilledforms.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV33AccessToken))}, new string[] {"AccessToken"}) );
                  context.wjLocDisableFrm = 1;
               }
               else
               {
                  AV5HasErrors = true;
                  AssignAttri(sPrefix, false, "AV5HasErrors", AV5HasErrors);
                  AV7Messages = AV21WWPFormInstance.GetMessages();
               }
            }
            if ( AV5HasErrors && ( AV7Messages.Count > 0 ) )
            {
               AV49GXV2 = 1;
               while ( AV49GXV2 <= AV7Messages.Count )
               {
                  AV6Message = ((GeneXus.Utils.SdtMessages_Message)AV7Messages.Item(AV49GXV2));
                  GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV6Message.gxTpr_Description,  "error",  "",  "true",  ""));
                  AV49GXV2 = (int)(AV49GXV2+1);
               }
            }
         }
         else
         {
            context.setWebReturnParms(new Object[] {(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV21WWPFormInstance});
            context.setWebReturnParmsMetadata(new Object[] {"AV21WWPFormInstance"});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S142( )
      {
         /* 'GET NEXT VISIBLE STEP' Routine */
         returnInSub = false;
         AV13FindNext = true;
         AssignAttri(sPrefix, false, "AV13FindNext", AV13FindNext);
         /* Execute user subroutine: 'GET NEXT OR PREVIOUS VISIBLE STEP' */
         S162 ();
         if (returnInSub) return;
      }

      protected void S132( )
      {
         /* 'GET PREVIOUS VISIBLE STEP' Routine */
         returnInSub = false;
         AV13FindNext = false;
         AssignAttri(sPrefix, false, "AV13FindNext", AV13FindNext);
         /* Execute user subroutine: 'GET NEXT OR PREVIOUS VISIBLE STEP' */
         S162 ();
         if (returnInSub) return;
      }

      protected void S162( )
      {
         /* 'GET NEXT OR PREVIOUS VISIBLE STEP' Routine */
         returnInSub = false;
         if ( AV23HasConditionalSteps )
         {
            AV25NextOrPrevStepIndex = AV12CurrentStepIndex;
            AssignAttri(sPrefix, false, "AV25NextOrPrevStepIndex", StringUtil.LTrimStr( (decimal)(AV25NextOrPrevStepIndex), 4, 0));
            AV25NextOrPrevStepIndex = (short)(AV25NextOrPrevStepIndex+(AV13FindNext ? 1 : -1));
            AssignAttri(sPrefix, false, "AV25NextOrPrevStepIndex", StringUtil.LTrimStr( (decimal)(AV25NextOrPrevStepIndex), 4, 0));
            while ( ( AV25NextOrPrevStepIndex >= 1 ) && ( AV25NextOrPrevStepIndex <= AV18WizardSteps.Count ) )
            {
               AV26NextOrPrevStepId = (short)(Math.Round(NumberUtil.Val( ((WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem)AV18WizardSteps.Item(AV25NextOrPrevStepIndex)).gxTpr_Code, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV26NextOrPrevStepId", StringUtil.LTrimStr( (decimal)(AV26NextOrPrevStepId), 4, 0));
               AV8WWP_DF_StepMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_StepMetadata(context);
               /* Using cursor H00254 */
               pr_default.execute(2, new Object[] {AV21WWPFormInstance.gxTpr_Wwpformid, AV21WWPFormInstance.gxTpr_Wwpformversionnumber, AV26NextOrPrevStepId});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A210WWPFormElementId = H00254_A210WWPFormElementId[0];
                  A217WWPFormElementType = H00254_A217WWPFormElementType[0];
                  A207WWPFormVersionNumber = H00254_A207WWPFormVersionNumber[0];
                  A206WWPFormId = H00254_A206WWPFormId[0];
                  A236WWPFormElementMetadata = H00254_A236WWPFormElementMetadata[0];
                  AV8WWP_DF_StepMetadata.FromJSonString(A236WWPFormElementMetadata, null);
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(2);
               if ( new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_evaluateelementvisibility(context).executeUdp(  AV21WWPFormInstance,  0,  AV8WWP_DF_StepMetadata.gxTpr_Visiblecondition) )
               {
                  if (true) break;
               }
               else
               {
                  AV25NextOrPrevStepIndex = (short)(AV25NextOrPrevStepIndex+(AV13FindNext ? 1 : -1));
                  AssignAttri(sPrefix, false, "AV25NextOrPrevStepIndex", StringUtil.LTrimStr( (decimal)(AV25NextOrPrevStepIndex), 4, 0));
               }
            }
         }
         else
         {
            AV25NextOrPrevStepIndex = (short)(AV12CurrentStepIndex+(AV13FindNext ? 1 : -1));
            AssignAttri(sPrefix, false, "AV25NextOrPrevStepIndex", StringUtil.LTrimStr( (decimal)(AV25NextOrPrevStepIndex), 4, 0));
         }
         if ( ! ( ( AV25NextOrPrevStepIndex >= 1 ) && ( AV25NextOrPrevStepIndex <= AV18WizardSteps.Count ) ) )
         {
            AV25NextOrPrevStepIndex = 0;
            AssignAttri(sPrefix, false, "AV25NextOrPrevStepIndex", StringUtil.LTrimStr( (decimal)(AV25NextOrPrevStepIndex), 4, 0));
         }
      }

      protected void S112( )
      {
         /* 'LOAD WIZARD STEPS AND CONTENT' Routine */
         returnInSub = false;
         AV16WebSession.Set("WWPDynFormSetFocus", "T");
         if ( AV23HasConditionalSteps )
         {
            AV18WizardSteps = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem>( context, "WizardStepsItem", "Comforta_version2");
            AV14IsCurrentStepAuxAssigned = false;
            AV23HasConditionalSteps = false;
            AssignAttri(sPrefix, false, "AV23HasConditionalSteps", AV23HasConditionalSteps);
            /* Using cursor H00255 */
            pr_default.execute(3, new Object[] {AV21WWPFormInstance.gxTpr_Wwpformid, AV21WWPFormInstance.gxTpr_Wwpformversionnumber});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A217WWPFormElementType = H00255_A217WWPFormElementType[0];
               A207WWPFormVersionNumber = H00255_A207WWPFormVersionNumber[0];
               A206WWPFormId = H00255_A206WWPFormId[0];
               A236WWPFormElementMetadata = H00255_A236WWPFormElementMetadata[0];
               A210WWPFormElementId = H00255_A210WWPFormElementId[0];
               A229WWPFormElementTitle = H00255_A229WWPFormElementTitle[0];
               A212WWPFormElementOrderIndex = H00255_A212WWPFormElementOrderIndex[0];
               AV8WWP_DF_StepMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_StepMetadata(context);
               AV8WWP_DF_StepMetadata.FromJSonString(A236WWPFormElementMetadata, null);
               AV24IncludeStep = true;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV8WWP_DF_StepMetadata.gxTpr_Visiblecondition.gxTpr_Expression))) )
               {
                  AV23HasConditionalSteps = true;
                  AssignAttri(sPrefix, false, "AV23HasConditionalSteps", AV23HasConditionalSteps);
                  if ( ! new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_evaluateelementvisibility(context).executeUdp(  AV21WWPFormInstance,  0,  AV8WWP_DF_StepMetadata.gxTpr_Visiblecondition) )
                  {
                     AV24IncludeStep = false;
                  }
               }
               if ( AV24IncludeStep )
               {
                  AV17WizardStep = new WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem(context);
                  AV17WizardStep.gxTpr_Code = StringUtil.Trim( StringUtil.Str( (decimal)(A210WWPFormElementId), 4, 0));
                  AV17WizardStep.gxTpr_Title = A229WWPFormElementTitle;
                  AV17WizardStep.gxTpr_Description = AV8WWP_DF_StepMetadata.gxTpr_Description;
                  AV18WizardSteps.Add(AV17WizardStep, 0);
                  if ( ( String.IsNullOrEmpty(StringUtil.RTrim( AV10CurrentStep)) || ( StringUtil.StrCmp(AV10CurrentStep, AV17WizardStep.gxTpr_Code) == 0 ) ) && ! AV14IsCurrentStepAuxAssigned && ! AV28WizardContentAlreadyLoaded )
                  {
                     AV12CurrentStepIndex = (short)(AV18WizardSteps.Count);
                     AssignAttri(sPrefix, false, "AV12CurrentStepIndex", StringUtil.LTrimStr( (decimal)(AV12CurrentStepIndex), 4, 0));
                     AV11CurrentStepAux = AV17WizardStep.gxTpr_Code;
                     AssignAttri(sPrefix, false, "AV11CurrentStepAux", AV11CurrentStepAux);
                     AV14IsCurrentStepAuxAssigned = true;
                     lblStepdescription_Caption = AV17WizardStep.gxTpr_Description;
                     AssignProp(sPrefix, false, lblStepdescription_Internalname, "Caption", lblStepdescription_Caption, true);
                     /* Object Property */
                     if ( StringUtil.Len( sPrefix) == 0 )
                     {
                        bDynCreated_Dynamicformfs_wc = true;
                     }
                     if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Dynamicformfs_wc_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_FS_WC")) != 0 )
                     {
                        WebComp_Dynamicformfs_wc = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_fs_wc", new Object[] {context} );
                        WebComp_Dynamicformfs_wc.ComponentInit();
                        WebComp_Dynamicformfs_wc.Name = "WorkWithPlus.DynamicForms.WWP_DF_FS_WC";
                        WebComp_Dynamicformfs_wc_Component = "WorkWithPlus.DynamicForms.WWP_DF_FS_WC";
                     }
                     if ( StringUtil.Len( WebComp_Dynamicformfs_wc_Component) != 0 )
                     {
                        WebComp_Dynamicformfs_wc.setjustcreated();
                        WebComp_Dynamicformfs_wc.componentprepare(new Object[] {(string)sPrefix+"W0018",(string)"",(string)AV19WWPDynamicFormMode,(short)A210WWPFormElementId,(short)0,(short)AV15SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV21WWPFormInstance});
                        WebComp_Dynamicformfs_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                     }
                     if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Dynamicformfs_wc )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0018"+"");
                        WebComp_Dynamicformfs_wc.componentdraw();
                        context.httpAjaxContext.ajax_rspEndCmp();
                     }
                  }
               }
               pr_default.readNext(3);
            }
            pr_default.close(3);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10CurrentStep)) )
            {
               AV11CurrentStepAux = AV10CurrentStep;
               AssignAttri(sPrefix, false, "AV11CurrentStepAux", AV11CurrentStepAux);
            }
         }
         else
         {
            AV11CurrentStepAux = AV10CurrentStep;
            AssignAttri(sPrefix, false, "AV11CurrentStepAux", AV11CurrentStepAux);
            /* Execute user subroutine: 'GET CURRENT STEP INDEX' */
            S122 ();
            if (returnInSub) return;
            lblStepdescription_Caption = ((WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem)AV18WizardSteps.Item(AV12CurrentStepIndex)).gxTpr_Description;
            AssignProp(sPrefix, false, lblStepdescription_Internalname, "Caption", lblStepdescription_Caption, true);
            AV20WWPFormElementId = (short)(Math.Round(NumberUtil.Val( ((WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem)AV18WizardSteps.Item(AV12CurrentStepIndex)).gxTpr_Code, "."), 18, MidpointRounding.ToEven));
            /* Object Property */
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               bDynCreated_Dynamicformfs_wc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Dynamicformfs_wc_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_FS_WC")) != 0 )
            {
               WebComp_Dynamicformfs_wc = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_fs_wc", new Object[] {context} );
               WebComp_Dynamicformfs_wc.ComponentInit();
               WebComp_Dynamicformfs_wc.Name = "WorkWithPlus.DynamicForms.WWP_DF_FS_WC";
               WebComp_Dynamicformfs_wc_Component = "WorkWithPlus.DynamicForms.WWP_DF_FS_WC";
            }
            if ( StringUtil.Len( WebComp_Dynamicformfs_wc_Component) != 0 )
            {
               WebComp_Dynamicformfs_wc.setjustcreated();
               WebComp_Dynamicformfs_wc.componentprepare(new Object[] {(string)sPrefix+"W0018",(string)"",(string)AV19WWPDynamicFormMode,(short)AV20WWPFormElementId,(short)0,(short)AV15SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV21WWPFormInstance});
               WebComp_Dynamicformfs_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Dynamicformfs_wc )
            {
               context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0018"+"");
               WebComp_Dynamicformfs_wc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue(context ).execute(  StringUtil.Format( "WWPDynFormCurrentStep_%1", StringUtil.Trim( StringUtil.Str( (decimal)(AV21WWPFormInstance.gxTpr_Wwpformid), 4, 0)), "", "", "", "", "", "", "", ""),  AV11CurrentStepAux) ;
         /* Execute user subroutine: 'UPDATE BUTTONS VISIBILITY AND CAPTIONS' */
         S172 ();
         if (returnInSub) return;
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
            WebComp_Wizardheader.componentprepare(new Object[] {(string)sPrefix+"W0009",(string)"",(string)"",(GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem>)AV18WizardSteps,(string)AV11CurrentStepAux});
            WebComp_Wizardheader.componentbind(new Object[] {(string)"",(string)"",(string)sPrefix+"vCURRENTSTEPAUX"});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wizardheader )
         {
            context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0009"+"");
            WebComp_Wizardheader.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
      }

      protected void S172( )
      {
         /* 'UPDATE BUTTONS VISIBILITY AND CAPTIONS' Routine */
         returnInSub = false;
         bttBtnprevious_Visible = (((AV12CurrentStepIndex>1)) ? 1 : 0);
         AssignProp(sPrefix, false, bttBtnprevious_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnprevious_Visible), 5, 0), true);
         bttBtnnext_Caption = ((AV12CurrentStepIndex<AV18WizardSteps.Count) ? context.GetMessage( "GXM_next", "") : context.GetMessage( "WWP_WizardFinishCaption", ""));
         AssignProp(sPrefix, false, bttBtnnext_Internalname, "Caption", bttBtnnext_Caption, true);
      }

      protected void S122( )
      {
         /* 'GET CURRENT STEP INDEX' Routine */
         returnInSub = false;
         AV12CurrentStepIndex = 1;
         AssignAttri(sPrefix, false, "AV12CurrentStepIndex", StringUtil.LTrimStr( (decimal)(AV12CurrentStepIndex), 4, 0));
         AV52GXV3 = 1;
         while ( AV52GXV3 <= AV18WizardSteps.Count )
         {
            AV17WizardStep = ((WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem)AV18WizardSteps.Item(AV52GXV3));
            if ( StringUtil.StrCmp(AV17WizardStep.gxTpr_Code, AV11CurrentStepAux) == 0 )
            {
               if (true) break;
            }
            AV12CurrentStepIndex = (short)(AV12CurrentStepIndex+1);
            AssignAttri(sPrefix, false, "AV12CurrentStepIndex", StringUtil.LTrimStr( (decimal)(AV12CurrentStepIndex), 4, 0));
            AV52GXV3 = (int)(AV52GXV3+1);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E15252( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV19WWPDynamicFormMode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV19WWPDynamicFormMode", AV19WWPDynamicFormMode);
         AV15SessionId = Convert.ToInt16(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV15SessionId", StringUtil.LTrimStr( (decimal)(AV15SessionId), 4, 0));
         AV29DefaultStep = (string)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV29DefaultStep", AV29DefaultStep);
         AV21WWPFormInstance = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)getParm(obj,3);
         AV33AccessToken = (string)getParm(obj,4);
         AssignAttri(sPrefix, false, "AV33AccessToken", AV33AccessToken);
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
         PA252( ) ;
         WS252( ) ;
         WE252( ) ;
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
         sCtrlAV19WWPDynamicFormMode = (string)((string)getParm(obj,0));
         sCtrlAV15SessionId = (string)((string)getParm(obj,1));
         sCtrlAV29DefaultStep = (string)((string)getParm(obj,2));
         sCtrlAV21WWPFormInstance = (string)((string)getParm(obj,3));
         sCtrlAV33AccessToken = (string)((string)getParm(obj,4));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA252( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "workwithplus\\dynamicforms\\wwp_df_wizard_wc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA252( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV19WWPDynamicFormMode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV19WWPDynamicFormMode", AV19WWPDynamicFormMode);
            AV15SessionId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV15SessionId", StringUtil.LTrimStr( (decimal)(AV15SessionId), 4, 0));
            AV29DefaultStep = (string)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV29DefaultStep", AV29DefaultStep);
            AV21WWPFormInstance = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)getParm(obj,5);
            AV33AccessToken = (string)getParm(obj,6);
            AssignAttri(sPrefix, false, "AV33AccessToken", AV33AccessToken);
         }
         wcpOAV19WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV19WWPDynamicFormMode");
         wcpOAV15SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV15SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV29DefaultStep = cgiGet( sPrefix+"wcpOAV29DefaultStep");
         wcpOAV33AccessToken = cgiGet( sPrefix+"wcpOAV33AccessToken");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV19WWPDynamicFormMode, wcpOAV19WWPDynamicFormMode) != 0 ) || ( AV15SessionId != wcpOAV15SessionId ) || ( StringUtil.StrCmp(AV29DefaultStep, wcpOAV29DefaultStep) != 0 ) || ( StringUtil.StrCmp(AV33AccessToken, wcpOAV33AccessToken) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOAV19WWPDynamicFormMode = AV19WWPDynamicFormMode;
         wcpOAV15SessionId = AV15SessionId;
         wcpOAV29DefaultStep = AV29DefaultStep;
         wcpOAV33AccessToken = AV33AccessToken;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV19WWPDynamicFormMode = cgiGet( sPrefix+"AV19WWPDynamicFormMode_CTRL");
         if ( StringUtil.Len( sCtrlAV19WWPDynamicFormMode) > 0 )
         {
            AV19WWPDynamicFormMode = cgiGet( sCtrlAV19WWPDynamicFormMode);
            AssignAttri(sPrefix, false, "AV19WWPDynamicFormMode", AV19WWPDynamicFormMode);
         }
         else
         {
            AV19WWPDynamicFormMode = cgiGet( sPrefix+"AV19WWPDynamicFormMode_PARM");
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
         sCtrlAV29DefaultStep = cgiGet( sPrefix+"AV29DefaultStep_CTRL");
         if ( StringUtil.Len( sCtrlAV29DefaultStep) > 0 )
         {
            AV29DefaultStep = cgiGet( sCtrlAV29DefaultStep);
            AssignAttri(sPrefix, false, "AV29DefaultStep", AV29DefaultStep);
         }
         else
         {
            AV29DefaultStep = cgiGet( sPrefix+"AV29DefaultStep_PARM");
         }
         sCtrlAV21WWPFormInstance = cgiGet( sPrefix+"AV21WWPFormInstance_CTRL");
         if ( StringUtil.Len( sCtrlAV21WWPFormInstance) > 0 )
         {
            AV21WWPFormInstance.FromXml(cgiGet( sCtrlAV21WWPFormInstance), null, "", "");
         }
         else
         {
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"AV21WWPFormInstance_PARM"), AV21WWPFormInstance);
         }
         sCtrlAV33AccessToken = cgiGet( sPrefix+"AV33AccessToken_CTRL");
         if ( StringUtil.Len( sCtrlAV33AccessToken) > 0 )
         {
            AV33AccessToken = cgiGet( sCtrlAV33AccessToken);
            AssignAttri(sPrefix, false, "AV33AccessToken", AV33AccessToken);
         }
         else
         {
            AV33AccessToken = cgiGet( sPrefix+"AV33AccessToken_PARM");
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
         PA252( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS252( ) ;
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
         WS252( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV19WWPDynamicFormMode_PARM", StringUtil.RTrim( AV19WWPDynamicFormMode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV19WWPDynamicFormMode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV19WWPDynamicFormMode_CTRL", StringUtil.RTrim( sCtrlAV19WWPDynamicFormMode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV15SessionId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV15SessionId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV15SessionId_CTRL", StringUtil.RTrim( sCtrlAV15SessionId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV29DefaultStep_PARM", AV29DefaultStep);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV29DefaultStep)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV29DefaultStep_CTRL", StringUtil.RTrim( sCtrlAV29DefaultStep));
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"AV21WWPFormInstance_PARM", AV21WWPFormInstance);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"AV21WWPFormInstance_PARM", AV21WWPFormInstance);
         }
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV21WWPFormInstance)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV21WWPFormInstance_CTRL", StringUtil.RTrim( sCtrlAV21WWPFormInstance));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV33AccessToken_PARM", AV33AccessToken);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV33AccessToken)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV33AccessToken_CTRL", StringUtil.RTrim( sCtrlAV33AccessToken));
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
         WE252( ) ;
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
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
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
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256309345377", true, true);
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
         context.AddJavascriptSource("workwithplus/dynamicforms/wwp_df_wizard_wc.js", "?20256309345380", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblStepdescription_Internalname = sPrefix+"STEPDESCRIPTION";
         bttBtnprevious_Internalname = sPrefix+"BTNPREVIOUS";
         bttBtnnext_Internalname = sPrefix+"BTNNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divWizardsteps_Internalname = sPrefix+"WIZARDSTEPS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavCurrentstepaux_Internalname = sPrefix+"vCURRENTSTEPAUX";
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
         edtavCurrentstepaux_Jsonclick = "";
         edtavCurrentstepaux_Visible = 1;
         bttBtnnext_Caption = context.GetMessage( "GXM_next", "");
         bttBtnprevious_Visible = 1;
         lblStepdescription_Caption = context.GetMessage( "Step Description", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("'DOPREVIOUS'","""{"handler":"E12252","iparms":[{"av":"AV25NextOrPrevStepIndex","fld":"vNEXTORPREVSTEPINDEX","pic":"ZZZ9"},{"av":"AV12CurrentStepIndex","fld":"vCURRENTSTEPINDEX","pic":"ZZZ9"},{"av":"AV18WizardSteps","fld":"vWIZARDSTEPS"},{"av":"AV11CurrentStepAux","fld":"vCURRENTSTEPAUX"},{"av":"AV23HasConditionalSteps","fld":"vHASCONDITIONALSTEPS"},{"av":"A212WWPFormElementOrderIndex","fld":"WWPFORMELEMENTORDERINDEX","pic":"ZZZ9"},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"AV21WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"A217WWPFormElementType","fld":"WWPFORMELEMENTTYPE","pic":"9"},{"av":"A236WWPFormElementMetadata","fld":"WWPFORMELEMENTMETADATA"},{"av":"A210WWPFormElementId","fld":"WWPFORMELEMENTID","pic":"ZZZ9"},{"av":"A229WWPFormElementTitle","fld":"WWPFORMELEMENTTITLE"},{"av":"AV10CurrentStep","fld":"vCURRENTSTEP"},{"av":"AV28WizardContentAlreadyLoaded","fld":"vWIZARDCONTENTALREADYLOADED"},{"av":"AV19WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV15SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV13FindNext","fld":"vFINDNEXT"}]""");
         setEventMetadata("'DOPREVIOUS'",""","oparms":[{"av":"AV25NextOrPrevStepIndex","fld":"vNEXTORPREVSTEPINDEX","pic":"ZZZ9"},{"av":"AV10CurrentStep","fld":"vCURRENTSTEP"},{"av":"AV12CurrentStepIndex","fld":"vCURRENTSTEPINDEX","pic":"ZZZ9"},{"av":"AV13FindNext","fld":"vFINDNEXT"},{"av":"AV18WizardSteps","fld":"vWIZARDSTEPS"},{"av":"AV23HasConditionalSteps","fld":"vHASCONDITIONALSTEPS"},{"av":"AV11CurrentStepAux","fld":"vCURRENTSTEPAUX"},{"av":"lblStepdescription_Caption","ctrl":"STEPDESCRIPTION","prop":"Caption"},{"ctrl":"DYNAMICFORMFS_WC"},{"ctrl":"WIZARDHEADER"},{"av":"AV26NextOrPrevStepId","fld":"vNEXTORPREVSTEPID","pic":"ZZZ9"},{"ctrl":"BTNPREVIOUS","prop":"Visible"},{"ctrl":"BTNNEXT","prop":"Caption"}]}""");
         setEventMetadata("'DONEXT'","""{"handler":"E13252","iparms":[{"av":"AV12CurrentStepIndex","fld":"vCURRENTSTEPINDEX","pic":"ZZZ9"},{"av":"AV18WizardSteps","fld":"vWIZARDSTEPS"},{"av":"AV15SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV19WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV5HasErrors","fld":"vHASERRORS"},{"av":"AV7Messages","fld":"vMESSAGES"},{"av":"AV9ErrorIds","fld":"vERRORIDS"},{"av":"AV25NextOrPrevStepIndex","fld":"vNEXTORPREVSTEPINDEX","pic":"ZZZ9"},{"av":"AV11CurrentStepAux","fld":"vCURRENTSTEPAUX"},{"av":"A212WWPFormElementOrderIndex","fld":"WWPFORMELEMENTORDERINDEX","pic":"ZZZ9"},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"AV21WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"A217WWPFormElementType","fld":"WWPFORMELEMENTTYPE","pic":"9"},{"av":"A210WWPFormElementId","fld":"WWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV33AccessToken","fld":"vACCESSTOKEN"},{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME"},{"av":"A209WWPFormTitle","fld":"WWPFORMTITLE"},{"av":"AV35FormName","fld":"vFORMNAME"},{"av":"AV38ResidentName","fld":"vRESIDENTNAME"},{"av":"AV23HasConditionalSteps","fld":"vHASCONDITIONALSTEPS"},{"av":"A236WWPFormElementMetadata","fld":"WWPFORMELEMENTMETADATA"},{"av":"A229WWPFormElementTitle","fld":"WWPFORMELEMENTTITLE"},{"av":"AV10CurrentStep","fld":"vCURRENTSTEP"},{"av":"AV28WizardContentAlreadyLoaded","fld":"vWIZARDCONTENTALREADYLOADED"},{"av":"AV13FindNext","fld":"vFINDNEXT"}]""");
         setEventMetadata("'DONEXT'",""","oparms":[{"av":"AV11CurrentStepAux","fld":"vCURRENTSTEPAUX"},{"av":"AV21WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV7Messages","fld":"vMESSAGES"},{"av":"AV9ErrorIds","fld":"vERRORIDS"},{"av":"AV5HasErrors","fld":"vHASERRORS"},{"av":"AV10CurrentStep","fld":"vCURRENTSTEP"},{"av":"AV12CurrentStepIndex","fld":"vCURRENTSTEPINDEX","pic":"ZZZ9"},{"av":"AV13FindNext","fld":"vFINDNEXT"},{"av":"AV38ResidentName","fld":"vRESIDENTNAME"},{"av":"AV35FormName","fld":"vFORMNAME"},{"av":"AV18WizardSteps","fld":"vWIZARDSTEPS"},{"av":"AV23HasConditionalSteps","fld":"vHASCONDITIONALSTEPS"},{"av":"lblStepdescription_Caption","ctrl":"STEPDESCRIPTION","prop":"Caption"},{"ctrl":"DYNAMICFORMFS_WC"},{"ctrl":"WIZARDHEADER"},{"av":"AV26NextOrPrevStepId","fld":"vNEXTORPREVSTEPID","pic":"ZZZ9"},{"av":"AV25NextOrPrevStepIndex","fld":"vNEXTORPREVSTEPINDEX","pic":"ZZZ9"},{"ctrl":"BTNPREVIOUS","prop":"Visible"},{"ctrl":"BTNNEXT","prop":"Caption"}]}""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES","""{"handler":"E14252","iparms":[{"av":"AV27AuxSessionId","fld":"vAUXSESSIONID","pic":"ZZZ9"},{"av":"AV15SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV23HasConditionalSteps","fld":"vHASCONDITIONALSTEPS"},{"av":"A212WWPFormElementOrderIndex","fld":"WWPFORMELEMENTORDERINDEX","pic":"ZZZ9"},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"AV21WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"A217WWPFormElementType","fld":"WWPFORMELEMENTTYPE","pic":"9"},{"av":"A236WWPFormElementMetadata","fld":"WWPFORMELEMENTMETADATA"},{"av":"A210WWPFormElementId","fld":"WWPFORMELEMENTID","pic":"ZZZ9"},{"av":"A229WWPFormElementTitle","fld":"WWPFORMELEMENTTITLE"},{"av":"AV10CurrentStep","fld":"vCURRENTSTEP"},{"av":"AV28WizardContentAlreadyLoaded","fld":"vWIZARDCONTENTALREADYLOADED"},{"av":"AV19WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV12CurrentStepIndex","fld":"vCURRENTSTEPINDEX","pic":"ZZZ9"},{"av":"AV18WizardSteps","fld":"vWIZARDSTEPS"},{"av":"AV11CurrentStepAux","fld":"vCURRENTSTEPAUX"}]""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES",""","oparms":[{"av":"AV21WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV28WizardContentAlreadyLoaded","fld":"vWIZARDCONTENTALREADYLOADED"},{"av":"AV18WizardSteps","fld":"vWIZARDSTEPS"},{"av":"AV23HasConditionalSteps","fld":"vHASCONDITIONALSTEPS"},{"av":"AV12CurrentStepIndex","fld":"vCURRENTSTEPINDEX","pic":"ZZZ9"},{"av":"AV11CurrentStepAux","fld":"vCURRENTSTEPAUX"},{"av":"lblStepdescription_Caption","ctrl":"STEPDESCRIPTION","prop":"Caption"},{"ctrl":"DYNAMICFORMFS_WC"},{"ctrl":"WIZARDHEADER"},{"ctrl":"BTNPREVIOUS","prop":"Visible"},{"ctrl":"BTNNEXT","prop":"Caption"}]}""");
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
         AV21WWPFormInstance = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         wcpOAV19WWPDynamicFormMode = "";
         wcpOAV29DefaultStep = "";
         wcpOAV33AccessToken = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV18WizardSteps = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem>( context, "WizardStepsItem", "Comforta_version2");
         A236WWPFormElementMetadata = "";
         A229WWPFormElementTitle = "";
         AV10CurrentStep = "";
         AV7Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV9ErrorIds = "";
         A208WWPFormReferenceName = "";
         A209WWPFormTitle = "";
         AV35FormName = "";
         AV38ResidentName = "";
         GX_FocusControl = "";
         WebComp_Wizardheader_Component = "";
         OldWizardheader = "";
         lblStepdescription_Jsonclick = "";
         WebComp_Dynamicformfs_wc_Component = "";
         OldDynamicformfs_wc = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnprevious_Jsonclick = "";
         bttBtnnext_Jsonclick = "";
         AV11CurrentStepAux = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV6Message = new GeneXus.Utils.SdtMessages_Message(context);
         GXt_SdtWWP_FormInstance1 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         H00252_A217WWPFormElementType = new short[1] ;
         H00252_A207WWPFormVersionNumber = new short[1] ;
         H00252_A206WWPFormId = new short[1] ;
         H00252_A210WWPFormElementId = new short[1] ;
         H00252_A212WWPFormElementOrderIndex = new short[1] ;
         AV22Validations = new GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation>( context, "WWP_DF_Validation", "Comforta_version2");
         AV32ResidentGUID = "";
         AV16WebSession = context.GetSession();
         AV36GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         H00253_A207WWPFormVersionNumber = new short[1] ;
         H00253_A206WWPFormId = new short[1] ;
         H00253_A208WWPFormReferenceName = new string[] {""} ;
         H00253_A209WWPFormTitle = new string[] {""} ;
         AV34FormInstanceIdString = "";
         AV48Formlink = "";
         AV42NotificationDescription = "";
         AV39SDT_NotificationMetadata = new SdtSDT_NotificationMetadata(context);
         AV40WWPNotificationMetadataSDT = new SdtUSDTNotificationMetadata(context);
         AV43ResidentIdCollection = new GxSimpleCollection<Guid>();
         AV41Metadata = new SdtSDT_OneSignalCustomData(context);
         AV8WWP_DF_StepMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_StepMetadata(context);
         H00254_A210WWPFormElementId = new short[1] ;
         H00254_A217WWPFormElementType = new short[1] ;
         H00254_A207WWPFormVersionNumber = new short[1] ;
         H00254_A206WWPFormId = new short[1] ;
         H00254_A236WWPFormElementMetadata = new string[] {""} ;
         H00255_A217WWPFormElementType = new short[1] ;
         H00255_A207WWPFormVersionNumber = new short[1] ;
         H00255_A206WWPFormId = new short[1] ;
         H00255_A236WWPFormElementMetadata = new string[] {""} ;
         H00255_A210WWPFormElementId = new short[1] ;
         H00255_A229WWPFormElementTitle = new string[] {""} ;
         H00255_A212WWPFormElementOrderIndex = new short[1] ;
         AV17WizardStep = new WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV19WWPDynamicFormMode = "";
         sCtrlAV15SessionId = "";
         sCtrlAV29DefaultStep = "";
         sCtrlAV21WWPFormInstance = "";
         sCtrlAV33AccessToken = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_wizard_wc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_wizard_wc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_wizard_wc__default(),
            new Object[][] {
                new Object[] {
               H00252_A217WWPFormElementType, H00252_A207WWPFormVersionNumber, H00252_A206WWPFormId, H00252_A210WWPFormElementId, H00252_A212WWPFormElementOrderIndex
               }
               , new Object[] {
               H00253_A207WWPFormVersionNumber, H00253_A206WWPFormId, H00253_A208WWPFormReferenceName, H00253_A209WWPFormTitle
               }
               , new Object[] {
               H00254_A210WWPFormElementId, H00254_A217WWPFormElementType, H00254_A207WWPFormVersionNumber, H00254_A206WWPFormId, H00254_A236WWPFormElementMetadata
               }
               , new Object[] {
               H00255_A217WWPFormElementType, H00255_A207WWPFormVersionNumber, H00255_A206WWPFormId, H00255_A236WWPFormElementMetadata, H00255_A210WWPFormElementId, H00255_A229WWPFormElementTitle, H00255_A212WWPFormElementOrderIndex
               }
            }
         );
         WebComp_Wizardheader = new GeneXus.Http.GXNullWebComponent();
         WebComp_Dynamicformfs_wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short AV15SessionId ;
      private short wcpOAV15SessionId ;
      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV25NextOrPrevStepIndex ;
      private short AV12CurrentStepIndex ;
      private short A212WWPFormElementOrderIndex ;
      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private short A217WWPFormElementType ;
      private short A210WWPFormElementId ;
      private short AV27AuxSessionId ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short AV20WWPFormElementId ;
      private short AV26NextOrPrevStepId ;
      private short nGXWrapped ;
      private int bttBtnprevious_Visible ;
      private int edtavCurrentstepaux_Visible ;
      private int AV44GXV1 ;
      private int AV49GXV2 ;
      private int AV52GXV3 ;
      private int idxLst ;
      private string AV19WWPDynamicFormMode ;
      private string wcpOAV19WWPDynamicFormMode ;
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
      private string WebComp_Wizardheader_Component ;
      private string OldWizardheader ;
      private string lblStepdescription_Internalname ;
      private string lblStepdescription_Caption ;
      private string lblStepdescription_Jsonclick ;
      private string divWizardsteps_Internalname ;
      private string WebComp_Dynamicformfs_wc_Component ;
      private string OldDynamicformfs_wc ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnprevious_Internalname ;
      private string bttBtnprevious_Jsonclick ;
      private string bttBtnnext_Internalname ;
      private string bttBtnnext_Caption ;
      private string bttBtnnext_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavCurrentstepaux_Internalname ;
      private string edtavCurrentstepaux_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string AV34FormInstanceIdString ;
      private string AV48Formlink ;
      private string sCtrlAV19WWPDynamicFormMode ;
      private string sCtrlAV15SessionId ;
      private string sCtrlAV29DefaultStep ;
      private string sCtrlAV21WWPFormInstance ;
      private string sCtrlAV33AccessToken ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV23HasConditionalSteps ;
      private bool AV28WizardContentAlreadyLoaded ;
      private bool AV13FindNext ;
      private bool AV5HasErrors ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV37isTokenValid ;
      private bool BRK254 ;
      private bool AV14IsCurrentStepAuxAssigned ;
      private bool AV24IncludeStep ;
      private bool bDynCreated_Dynamicformfs_wc ;
      private bool bDynCreated_Wizardheader ;
      private string AV33AccessToken ;
      private string wcpOAV33AccessToken ;
      private string A236WWPFormElementMetadata ;
      private string A229WWPFormElementTitle ;
      private string AV29DefaultStep ;
      private string wcpOAV29DefaultStep ;
      private string AV10CurrentStep ;
      private string AV9ErrorIds ;
      private string A208WWPFormReferenceName ;
      private string A209WWPFormTitle ;
      private string AV35FormName ;
      private string AV38ResidentName ;
      private string AV11CurrentStepAux ;
      private string AV32ResidentGUID ;
      private string AV42NotificationDescription ;
      private IGxSession AV16WebSession ;
      private GXWebComponent WebComp_Wizardheader ;
      private GXWebComponent WebComp_Dynamicformfs_wc ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV21WWPFormInstance ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP3_WWPFormInstance ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem> AV18WizardSteps ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV7Messages ;
      private GeneXus.Utils.SdtMessages_Message AV6Message ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance GXt_SdtWWP_FormInstance1 ;
      private IDataStoreProvider pr_default ;
      private short[] H00252_A217WWPFormElementType ;
      private short[] H00252_A207WWPFormVersionNumber ;
      private short[] H00252_A206WWPFormId ;
      private short[] H00252_A210WWPFormElementId ;
      private short[] H00252_A212WWPFormElementOrderIndex ;
      private GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation> AV22Validations ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV36GAMUser ;
      private short[] H00253_A207WWPFormVersionNumber ;
      private short[] H00253_A206WWPFormId ;
      private string[] H00253_A208WWPFormReferenceName ;
      private string[] H00253_A209WWPFormTitle ;
      private SdtSDT_NotificationMetadata AV39SDT_NotificationMetadata ;
      private SdtUSDTNotificationMetadata AV40WWPNotificationMetadataSDT ;
      private GxSimpleCollection<Guid> AV43ResidentIdCollection ;
      private SdtSDT_OneSignalCustomData AV41Metadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_StepMetadata AV8WWP_DF_StepMetadata ;
      private short[] H00254_A210WWPFormElementId ;
      private short[] H00254_A217WWPFormElementType ;
      private short[] H00254_A207WWPFormVersionNumber ;
      private short[] H00254_A206WWPFormId ;
      private string[] H00254_A236WWPFormElementMetadata ;
      private short[] H00255_A217WWPFormElementType ;
      private short[] H00255_A207WWPFormVersionNumber ;
      private short[] H00255_A206WWPFormId ;
      private string[] H00255_A236WWPFormElementMetadata ;
      private short[] H00255_A210WWPFormElementId ;
      private string[] H00255_A229WWPFormElementTitle ;
      private short[] H00255_A212WWPFormElementOrderIndex ;
      private WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem AV17WizardStep ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_df_wizard_wc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_df_wizard_wc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_df_wizard_wc__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new ForEachCursor(def[2])
      ,new ForEachCursor(def[3])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmH00252;
       prmH00252 = new Object[] {
       new ParDef("AV21WWPF_1Wwpformid",GXType.Int16,4,0) ,
       new ParDef("AV21WWPF_2Wwpformversionnumbe",GXType.Int16,4,0)
       };
       Object[] prmH00253;
       prmH00253 = new Object[] {
       };
       Object[] prmH00254;
       prmH00254 = new Object[] {
       new ParDef("AV21WWPF_1Wwpformid",GXType.Int16,4,0) ,
       new ParDef("AV21WWPF_2Wwpformversionnumbe",GXType.Int16,4,0) ,
       new ParDef("AV26NextOrPrevStepId",GXType.Int16,4,0)
       };
       Object[] prmH00255;
       prmH00255 = new Object[] {
       new ParDef("AV21WWPF_1Wwpformid",GXType.Int16,4,0) ,
       new ParDef("AV21WWPF_2Wwpformversionnumbe",GXType.Int16,4,0)
       };
       def= new CursorDef[] {
           new CursorDef("H00252", "SELECT WWPFormElementType, WWPFormVersionNumber, WWPFormId, WWPFormElementId, WWPFormElementOrderIndex FROM WWP_FormElement WHERE (WWPFormId = :AV21WWPF_1Wwpformid) AND (WWPFormVersionNumber = :AV21WWPF_2Wwpformversionnumbe) AND (WWPFormElementType = 5) ORDER BY WWPFormElementOrderIndex ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00252,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H00253", "SELECT WWPFormVersionNumber, WWPFormId, WWPFormReferenceName, WWPFormTitle FROM WWP_Form ORDER BY WWPFormId DESC, WWPFormVersionNumber DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00253,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H00254", "SELECT WWPFormElementId, WWPFormElementType, WWPFormVersionNumber, WWPFormId, WWPFormElementMetadata FROM WWP_FormElement WHERE (WWPFormId = :AV21WWPF_1Wwpformid and WWPFormVersionNumber = :AV21WWPF_2Wwpformversionnumbe and WWPFormElementId = :AV26NextOrPrevStepId) AND (WWPFormElementType = 5) ORDER BY WWPFormId, WWPFormVersionNumber, WWPFormElementId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00254,1, GxCacheFrequency.OFF ,false,true )
          ,new CursorDef("H00255", "SELECT WWPFormElementType, WWPFormVersionNumber, WWPFormId, WWPFormElementMetadata, WWPFormElementId, WWPFormElementTitle, WWPFormElementOrderIndex FROM WWP_FormElement WHERE (WWPFormId = :AV21WWPF_1Wwpformid) AND (WWPFormVersionNumber = :AV21WWPF_2Wwpformversionnumbe) AND (WWPFormElementType = 5) ORDER BY WWPFormElementOrderIndex ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00255,100, GxCacheFrequency.OFF ,true,false )
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
             ((short[]) buf[2])[0] = rslt.getShort(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             return;
          case 1 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 2 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             return;
          case 3 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((short[]) buf[6])[0] = rslt.getShort(7);
             return;
    }
 }

}

}
