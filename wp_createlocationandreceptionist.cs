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
   public class wp_createlocationandreceptionist : GXDataArea
   {
      public wp_createlocationandreceptionist( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_createlocationandreceptionist( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_PreviousStep ,
                           string aP1_CurrentStep ,
                           bool aP2_GoingBack ,
                           ref Guid aP3_OrganisationId )
      {
         this.AV10PreviousStep = aP0_PreviousStep;
         this.AV11CurrentStep = aP1_CurrentStep;
         this.AV9GoingBack = aP2_GoingBack;
         this.AV19OrganisationId = aP3_OrganisationId;
         ExecuteImpl();
         aP3_OrganisationId=this.AV19OrganisationId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "PreviousStep");
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "PreviousStep");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "PreviousStep");
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
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "wp_createlocationandreceptionist_Execute" ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
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

      public override short ExecuteStartEvent( )
      {
         PA5Y2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5Y2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         CloseStyles();
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
         context.WriteHtmlText( Form.Headerrawhtml) ;
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
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wp_createlocationandreceptionist.aspx"+UrlEncode(StringUtil.RTrim(AV10PreviousStep)) + "," + UrlEncode(StringUtil.RTrim(AV11CurrentStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV9GoingBack)) + "," + UrlEncode(AV19OrganisationId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_createlocationandreceptionist.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWIZARDSTEPS", AV13WizardSteps);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWIZARDSTEPS", AV13WizardSteps);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWIZARDSTEPS", GetSecureSignedToken( "", AV13WizardSteps, context));
         GxWebStd.gx_hidden_field( context, "vCURRENTSTEPAUX", AV12CurrentStepAux);
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTSTEPAUX", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12CurrentStepAux, "")), context));
         GxWebStd.gx_hidden_field( context, "vPREVIOUSSTEP", AV10PreviousStep);
         GxWebStd.gx_hidden_field( context, "gxhash_vPREVIOUSSTEP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10PreviousStep, "")), context));
         GxWebStd.gx_hidden_field( context, "vCURRENTSTEP", AV11CurrentStep);
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTSTEP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11CurrentStep, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vGOINGBACK", AV9GoingBack);
         GxWebStd.gx_hidden_field( context, "gxhash_vGOINGBACK", GetSecureSignedToken( "", AV9GoingBack, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWIZARDSTEPS", AV13WizardSteps);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWIZARDSTEPS", AV13WizardSteps);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWIZARDSTEPS", GetSecureSignedToken( "", AV13WizardSteps, context));
         GxWebStd.gx_hidden_field( context, "vCURRENTSTEPAUX", AV12CurrentStepAux);
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTSTEPAUX", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12CurrentStepAux, "")), context));
         GxWebStd.gx_hidden_field( context, "vPREVIOUSSTEP", AV10PreviousStep);
         GxWebStd.gx_hidden_field( context, "gxhash_vPREVIOUSSTEP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10PreviousStep, "")), context));
         GxWebStd.gx_hidden_field( context, "vCURRENTSTEP", AV11CurrentStep);
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTSTEP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11CurrentStep, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vGOINGBACK", AV9GoingBack);
         GxWebStd.gx_hidden_field( context, "gxhash_vGOINGBACK", GetSecureSignedToken( "", AV9GoingBack, context));
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV19OrganisationId.ToString());
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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
         if ( ! ( WebComp_Steptitles == null ) )
         {
            WebComp_Steptitles.componentjscripts();
         }
         if ( ! ( WebComp_Wizardstepwc == null ) )
         {
            WebComp_Wizardstepwc.componentjscripts();
         }
         context.WriteHtmlText( "<script type=\"text/javascript\">") ;
         context.WriteHtmlText( "gx.setLanguageCode(\""+context.GetLanguageProperty( "code")+"\");") ;
         if ( ! context.isSpaRequest( ) )
         {
            context.WriteHtmlText( "gx.setDateFormat(\""+context.GetLanguageProperty( "date_fmt")+"\");") ;
            context.WriteHtmlText( "gx.setTimeFormat("+context.GetLanguageProperty( "time_fmt")+");") ;
            context.WriteHtmlText( "gx.setCenturyFirstYear("+40+");") ;
            context.WriteHtmlText( "gx.setDecimalPoint(\""+context.GetLanguageProperty( "decimal_point")+"\");") ;
            context.WriteHtmlText( "gx.setThousandSeparator(\""+context.GetLanguageProperty( "thousand_sep")+"\");") ;
            context.WriteHtmlText( "gx.StorageTimeZone = "+1+";") ;
         }
         context.WriteHtmlText( "</script>") ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE5Y2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5Y2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wp_createlocationandreceptionist.aspx"+UrlEncode(StringUtil.RTrim(AV10PreviousStep)) + "," + UrlEncode(StringUtil.RTrim(AV11CurrentStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV9GoingBack)) + "," + UrlEncode(AV19OrganisationId.ToString());
         return formatLink("wp_createlocationandreceptionist.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WP_CreateLocationAndReceptionist" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Create Location", "") ;
      }

      protected void WB5Y0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
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
            GxWebStd.gx_div_start( context, divData_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0012"+"", StringUtil.RTrim( WebComp_Steptitles_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0012"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Steptitles_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldSteptitles), StringUtil.Lower( WebComp_Steptitles_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0012"+"");
                  }
                  WebComp_Steptitles.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldSteptitles), StringUtil.Lower( WebComp_Steptitles_Component)) != 0 )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblWizardstepdescription_Internalname, lblWizardstepdescription_Caption, "", "", lblWizardstepdescription_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WP_CreateLocationAndReceptionist.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WizardStepsPositionCell", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0018"+"", StringUtil.RTrim( WebComp_Wizardstepwc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0018"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wizardstepwc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWizardstepwc), StringUtil.Lower( WebComp_Wizardstepwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0018"+"");
                  }
                  WebComp_Wizardstepwc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWizardstepwc), StringUtil.Lower( WebComp_Wizardstepwc_Component)) != 0 )
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START5Y2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( "Create Location", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5Y0( ) ;
      }

      protected void WS5Y2( )
      {
         START5Y2( ) ;
         EVT5Y2( ) ;
      }

      protected void EVT5Y2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E115Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E125Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E135Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                 }
                                 dynload_actions( ) ;
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
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
                           OldSteptitles = cgiGet( "W0012");
                           if ( ( StringUtil.Len( OldSteptitles) == 0 ) || ( StringUtil.StrCmp(OldSteptitles, WebComp_Steptitles_Component) != 0 ) )
                           {
                              WebComp_Steptitles = getWebComponent(GetType(), "GeneXus.Programs", OldSteptitles, new Object[] {context} );
                              WebComp_Steptitles.ComponentInit();
                              WebComp_Steptitles.Name = "OldSteptitles";
                              WebComp_Steptitles_Component = OldSteptitles;
                           }
                           if ( StringUtil.Len( WebComp_Steptitles_Component) != 0 )
                           {
                              WebComp_Steptitles.componentprocess("W0012", "", sEvt);
                           }
                           WebComp_Steptitles_Component = OldSteptitles;
                        }
                        else if ( nCmpId == 18 )
                        {
                           OldWizardstepwc = cgiGet( "W0018");
                           if ( ( StringUtil.Len( OldWizardstepwc) == 0 ) || ( StringUtil.StrCmp(OldWizardstepwc, WebComp_Wizardstepwc_Component) != 0 ) )
                           {
                              WebComp_Wizardstepwc = getWebComponent(GetType(), "GeneXus.Programs", OldWizardstepwc, new Object[] {context} );
                              WebComp_Wizardstepwc.ComponentInit();
                              WebComp_Wizardstepwc.Name = "OldWizardstepwc";
                              WebComp_Wizardstepwc_Component = OldWizardstepwc;
                           }
                           if ( StringUtil.Len( WebComp_Wizardstepwc_Component) != 0 )
                           {
                              WebComp_Wizardstepwc.componentprocess("W0018", "", sEvt);
                           }
                           WebComp_Wizardstepwc_Component = OldWizardstepwc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE5Y2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA5Y2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_createlocationandreceptionist.aspx")), "wp_createlocationandreceptionist.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_createlocationandreceptionist.aspx")))) ;
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
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( nGotPars == 0 )
               {
                  entryPointCalled = false;
                  gxfirstwebparm = GetFirstPar( "PreviousStep");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV10PreviousStep = gxfirstwebparm;
                     AssignAttri("", false, "AV10PreviousStep", AV10PreviousStep);
                     GxWebStd.gx_hidden_field( context, "gxhash_vPREVIOUSSTEP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10PreviousStep, "")), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV11CurrentStep = GetPar( "CurrentStep");
                        AssignAttri("", false, "AV11CurrentStep", AV11CurrentStep);
                        GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTSTEP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11CurrentStep, "")), context));
                        AV9GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
                        AssignAttri("", false, "AV9GoingBack", AV9GoingBack);
                        GxWebStd.gx_hidden_field( context, "gxhash_vGOINGBACK", GetSecureSignedToken( "", AV9GoingBack, context));
                        AV19OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                        AssignAttri("", false, "AV19OrganisationId", AV19OrganisationId.ToString());
                     }
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
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
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
         RF5Y2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV20Pgmname = "WP_CreateLocationAndReceptionist";
      }

      protected void RF5Y2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E125Y2 ();
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Steptitles_Component) != 0 )
               {
                  WebComp_Steptitles.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wizardstepwc_Component) != 0 )
               {
                  WebComp_Wizardstepwc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E135Y2 ();
            WB5Y0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes5Y2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWIZARDSTEPS", AV13WizardSteps);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWIZARDSTEPS", AV13WizardSteps);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWIZARDSTEPS", GetSecureSignedToken( "", AV13WizardSteps, context));
         GxWebStd.gx_hidden_field( context, "vCURRENTSTEPAUX", AV12CurrentStepAux);
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTSTEPAUX", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12CurrentStepAux, "")), context));
      }

      protected void before_start_formulas( )
      {
         AV20Pgmname = "WP_CreateLocationAndReceptionist";
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5Y0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E115Y2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
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
         E115Y2 ();
         if (returnInSub) return;
      }

      protected void E115Y2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV13WizardSteps = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem>( context, "WizardStepsItem", "Comforta_version2");
         AV13WizardSteps.Add(new WorkWithPlus.workwithplus_web.wwp_wizardgetstep(context).executeUdp(  "Step1",  context.GetMessage( "Location", ""),  " ",  false), 0);
         AV13WizardSteps.Add(new WorkWithPlus.workwithplus_web.wwp_wizardgetstep(context).executeUdp(  "Step2",  context.GetMessage( "Receptionist", ""),  " ",  false), 0);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11CurrentStep)) )
         {
            AV12CurrentStepAux = "Step1";
            AssignAttri("", false, "AV12CurrentStepAux", AV12CurrentStepAux);
            GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTSTEPAUX", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12CurrentStepAux, "")), context));
            AV7WebSession.Remove(AV20Pgmname+"_Data");
         }
         else
         {
            AV12CurrentStepAux = AV11CurrentStep;
            AssignAttri("", false, "AV12CurrentStepAux", AV12CurrentStepAux);
            GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTSTEPAUX", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12CurrentStepAux, "")), context));
         }
         /* Execute user subroutine: 'LOADWIZARDSTEPWC' */
         S112 ();
         if (returnInSub) return;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Steptitles = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Steptitles_Component), StringUtil.Lower( "WWPBaseObjects.WizardStepsBulletWC")) != 0 )
         {
            WebComp_Steptitles = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.wizardstepsbulletwc", new Object[] {context} );
            WebComp_Steptitles.ComponentInit();
            WebComp_Steptitles.Name = "WWPBaseObjects.WizardStepsBulletWC";
            WebComp_Steptitles_Component = "WWPBaseObjects.WizardStepsBulletWC";
         }
         if ( StringUtil.Len( WebComp_Steptitles_Component) != 0 )
         {
            WebComp_Steptitles.setjustcreated();
            WebComp_Steptitles.componentprepare(new Object[] {(string)"W0012",(string)"",(string)AV20Pgmname+"_Data",(GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem>)AV13WizardSteps,(string)AV12CurrentStepAux});
            WebComp_Steptitles.componentbind(new Object[] {(string)""+""+"",(string)"",(string)""});
         }
         AV13WizardSteps = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem>( context, "WizardStepsItem", "Comforta_version2");
         AV13WizardSteps.Add(new WorkWithPlus.workwithplus_web.wwp_wizardgetstep(context).executeUdp(  "Step1",  context.GetMessage( "Location", ""),  " ",  false), 0);
         AV13WizardSteps.Add(new WorkWithPlus.workwithplus_web.wwp_wizardgetstep(context).executeUdp(  "Step2",  new prc_getorganisationdefinition(context).executeUdp(  "Receptionists"),  " ",  false), 0);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11CurrentStep)) )
         {
            AV12CurrentStepAux = "Step1";
            AssignAttri("", false, "AV12CurrentStepAux", AV12CurrentStepAux);
            GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTSTEPAUX", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12CurrentStepAux, "")), context));
            AV7WebSession.Remove(AV20Pgmname+"_Data");
         }
         else
         {
            AV12CurrentStepAux = AV11CurrentStep;
            AssignAttri("", false, "AV12CurrentStepAux", AV12CurrentStepAux);
            GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTSTEPAUX", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12CurrentStepAux, "")), context));
         }
         /* Execute user subroutine: 'LOADWIZARDSTEPWC' */
         S112 ();
         if (returnInSub) return;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Steptitles = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Steptitles_Component), StringUtil.Lower( "WWPBaseObjects.WizardStepsBulletWC")) != 0 )
         {
            WebComp_Steptitles = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.wizardstepsbulletwc", new Object[] {context} );
            WebComp_Steptitles.ComponentInit();
            WebComp_Steptitles.Name = "WWPBaseObjects.WizardStepsBulletWC";
            WebComp_Steptitles_Component = "WWPBaseObjects.WizardStepsBulletWC";
         }
         if ( StringUtil.Len( WebComp_Steptitles_Component) != 0 )
         {
            WebComp_Steptitles.setjustcreated();
            WebComp_Steptitles.componentprepare(new Object[] {(string)"W0012",(string)"",(string)AV20Pgmname+"_Data",(GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem>)AV13WizardSteps,(string)AV12CurrentStepAux});
            WebComp_Steptitles.componentbind(new Object[] {(string)""+""+"",(string)"",(string)""});
         }
      }

      protected void S112( )
      {
         /* 'LOADWIZARDSTEPWC' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV12CurrentStepAux, "Step1") == 0 )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wizardstepwc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wizardstepwc_Component), StringUtil.Lower( "WP_CreateLocationAndReceptionistStep1")) != 0 )
            {
               WebComp_Wizardstepwc = getWebComponent(GetType(), "GeneXus.Programs", "wp_createlocationandreceptioniststep1", new Object[] {context} );
               WebComp_Wizardstepwc.ComponentInit();
               WebComp_Wizardstepwc.Name = "WP_CreateLocationAndReceptionistStep1";
               WebComp_Wizardstepwc_Component = "WP_CreateLocationAndReceptionistStep1";
            }
            if ( StringUtil.Len( WebComp_Wizardstepwc_Component) != 0 )
            {
               WebComp_Wizardstepwc.setjustcreated();
               WebComp_Wizardstepwc.componentprepare(new Object[] {(string)"W0018",(string)"",(string)AV20Pgmname+"_Data",(string)AV10PreviousStep,(bool)AV9GoingBack,(Guid)AV19OrganisationId});
               WebComp_Wizardstepwc.componentbind(new Object[] {(string)""+""+"",(string)"",(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wizardstepwc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0018"+"");
               WebComp_Wizardstepwc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         else if ( StringUtil.StrCmp(AV12CurrentStepAux, "Step2") == 0 )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wizardstepwc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wizardstepwc_Component), StringUtil.Lower( "WP_CreateLocationAndReceptionistStep2")) != 0 )
            {
               WebComp_Wizardstepwc = getWebComponent(GetType(), "GeneXus.Programs", "wp_createlocationandreceptioniststep2", new Object[] {context} );
               WebComp_Wizardstepwc.ComponentInit();
               WebComp_Wizardstepwc.Name = "WP_CreateLocationAndReceptionistStep2";
               WebComp_Wizardstepwc_Component = "WP_CreateLocationAndReceptionistStep2";
            }
            if ( StringUtil.Len( WebComp_Wizardstepwc_Component) != 0 )
            {
               WebComp_Wizardstepwc.setjustcreated();
               WebComp_Wizardstepwc.componentprepare(new Object[] {(string)"W0018",(string)"",(string)AV20Pgmname+"_Data",(string)AV10PreviousStep,(bool)AV9GoingBack,(Guid)AV19OrganisationId});
               WebComp_Wizardstepwc.componentbind(new Object[] {(string)""+""+"",(string)"",(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wizardstepwc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0018"+"");
               WebComp_Wizardstepwc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
      }

      protected void E125Y2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         lblWizardstepdescription_Caption = "";
         AssignProp("", false, lblWizardstepdescription_Internalname, "Caption", lblWizardstepdescription_Caption, true);
         AV15StepNumber = 1;
         AV21GXV1 = 1;
         while ( AV21GXV1 <= AV13WizardSteps.Count )
         {
            AV14WizardStep = ((WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem)AV13WizardSteps.Item(AV21GXV1));
            if ( StringUtil.StrCmp(AV14WizardStep.gxTpr_Code, AV12CurrentStepAux) == 0 )
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14WizardStep.gxTpr_Description)) )
               {
                  lblWizardstepdescription_Caption = StringUtil.Format( context.GetMessage( "Step %1/%2 :: %3", ""), StringUtil.Trim( StringUtil.Str( (decimal)(AV15StepNumber), 2, 0)), StringUtil.Trim( StringUtil.Str( (decimal)(AV13WizardSteps.Count), 9, 0)), AV14WizardStep.gxTpr_Description, "", "", "", "", "", "");
                  AssignProp("", false, lblWizardstepdescription_Internalname, "Caption", lblWizardstepdescription_Caption, true);
               }
            }
            else
            {
               AV15StepNumber = (short)(AV15StepNumber+1);
            }
            AV21GXV1 = (int)(AV21GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E135Y2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV10PreviousStep = (string)getParm(obj,0);
         AssignAttri("", false, "AV10PreviousStep", AV10PreviousStep);
         GxWebStd.gx_hidden_field( context, "gxhash_vPREVIOUSSTEP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10PreviousStep, "")), context));
         AV11CurrentStep = (string)getParm(obj,1);
         AssignAttri("", false, "AV11CurrentStep", AV11CurrentStep);
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTSTEP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11CurrentStep, "")), context));
         AV9GoingBack = (bool)getParm(obj,2);
         AssignAttri("", false, "AV9GoingBack", AV9GoingBack);
         GxWebStd.gx_hidden_field( context, "gxhash_vGOINGBACK", GetSecureSignedToken( "", AV9GoingBack, context));
         AV19OrganisationId = (Guid)getParm(obj,3);
         AssignAttri("", false, "AV19OrganisationId", AV19OrganisationId.ToString());
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
         PA5Y2( ) ;
         WS5Y2( ) ;
         WE5Y2( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Steptitles == null ) )
         {
            if ( StringUtil.Len( WebComp_Steptitles_Component) != 0 )
            {
               WebComp_Steptitles.componentthemes();
            }
         }
         if ( ! ( WebComp_Wizardstepwc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wizardstepwc_Component) != 0 )
            {
               WebComp_Wizardstepwc.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025630947646", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages."+StringUtil.Lower( context.GetLanguageProperty( "code"))+".js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("wp_createlocationandreceptionist.js", "?2025630947646", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblWizardstepdescription_Internalname = "WIZARDSTEPDESCRIPTION";
         divData_Internalname = "DATA";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         lblWizardstepdescription_Caption = " ";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Create Location", "");
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV13WizardSteps","fld":"vWIZARDSTEPS","hsh":true},{"av":"AV12CurrentStepAux","fld":"vCURRENTSTEPAUX","hsh":true},{"av":"AV10PreviousStep","fld":"vPREVIOUSSTEP","hsh":true},{"av":"AV11CurrentStep","fld":"vCURRENTSTEP","hsh":true},{"av":"AV9GoingBack","fld":"vGOINGBACK","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"lblWizardstepdescription_Caption","ctrl":"WIZARDSTEPDESCRIPTION","prop":"Caption"}]}""");
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
         wcpOAV10PreviousStep = "";
         wcpOAV11CurrentStep = "";
         wcpOAV19OrganisationId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV13WizardSteps = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem>( context, "WizardStepsItem", "Comforta_version2");
         AV12CurrentStepAux = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         WebComp_Steptitles_Component = "";
         OldSteptitles = "";
         lblWizardstepdescription_Jsonclick = "";
         WebComp_Wizardstepwc_Component = "";
         OldWizardstepwc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV20Pgmname = "";
         AV7WebSession = context.GetSession();
         AV14WizardStep = new WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         WebComp_Steptitles = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wizardstepwc = new GeneXus.Http.GXNullWebComponent();
         AV20Pgmname = "WP_CreateLocationAndReceptionist";
         /* GeneXus formulas. */
         AV20Pgmname = "WP_CreateLocationAndReceptionist";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short AV15StepNumber ;
      private short nGXWrapped ;
      private int AV21GXV1 ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divData_Internalname ;
      private string WebComp_Steptitles_Component ;
      private string OldSteptitles ;
      private string lblWizardstepdescription_Internalname ;
      private string lblWizardstepdescription_Caption ;
      private string lblWizardstepdescription_Jsonclick ;
      private string WebComp_Wizardstepwc_Component ;
      private string OldWizardstepwc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string AV20Pgmname ;
      private bool AV9GoingBack ;
      private bool wcpOAV9GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Steptitles ;
      private bool bDynCreated_Wizardstepwc ;
      private string AV10PreviousStep ;
      private string AV11CurrentStep ;
      private string wcpOAV10PreviousStep ;
      private string wcpOAV11CurrentStep ;
      private string AV12CurrentStepAux ;
      private Guid AV19OrganisationId ;
      private Guid wcpOAV19OrganisationId ;
      private GXWebComponent WebComp_Steptitles ;
      private GXWebComponent WebComp_Wizardstepwc ;
      private IGxSession AV7WebSession ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Guid aP3_OrganisationId ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem> AV13WizardSteps ;
      private WorkWithPlus.workwithplus_web.SdtWizardSteps_WizardStepsItem AV14WizardStep ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
