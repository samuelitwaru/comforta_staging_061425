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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.workwithplus.dynamicforms {
   public class wwp_dynamicform : GXDataArea
   {
      public wwp_dynamicform( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_dynamicform( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPFormReferenceName ,
                           int aP1_WWPFormInstanceId ,
                           string aP2_WWPDynamicFormMode ,
                           bool aP3_isLinkingDiscussion )
      {
         this.AV14WWPFormReferenceName = aP0_WWPFormReferenceName;
         this.AV9WWPFormInstanceId = aP1_WWPFormInstanceId;
         this.AV8WWPDynamicFormMode = aP2_WWPDynamicFormMode;
         this.AV29isLinkingDiscussion = aP3_isLinkingDiscussion;
         ExecuteImpl();
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
            gxfirstwebparm = GetFirstPar( "WWPFormReferenceName");
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
               gxfirstwebparm = GetFirstPar( "WWPFormReferenceName");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "WWPFormReferenceName");
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV14WWPFormReferenceName = gxfirstwebparm;
               AssignAttri("", false, "AV14WWPFormReferenceName", AV14WWPFormReferenceName);
               GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMREFERENCENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14WWPFormReferenceName, "")), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV9WWPFormInstanceId = (int)(Math.Round(NumberUtil.Val( GetPar( "WWPFormInstanceId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV9WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(AV9WWPFormInstanceId), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMINSTANCEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9WWPFormInstanceId), "ZZZZZ9"), context));
                  AV8WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
                  AssignAttri("", false, "AV8WWPDynamicFormMode", AV8WWPDynamicFormMode);
                  GxWebStd.gx_hidden_field( context, "gxhash_vWWPDYNAMICFORMMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8WWPDynamicFormMode, "")), context));
                  AV29isLinkingDiscussion = StringUtil.StrToBool( GetPar( "isLinkingDiscussion"));
                  AssignAttri("", false, "AV29isLinkingDiscussion", AV29isLinkingDiscussion);
                  GxWebStd.gx_hidden_field( context, "gxhash_vISLINKINGDISCUSSION", GetSecureSignedToken( "", AV29isLinkingDiscussion, context));
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
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
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
         PA1Z2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1Z2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.dynamicforms.wwp_dynamicform.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV14WWPFormReferenceName)),UrlEncode(StringUtil.LTrimStr(AV9WWPFormInstanceId,6,0)),UrlEncode(StringUtil.RTrim(AV8WWPDynamicFormMode)),UrlEncode(StringUtil.BoolToStr(AV29isLinkingDiscussion))}, new string[] {"WWPFormReferenceName","WWPFormInstanceId","WWPDynamicFormMode","isLinkingDiscussion"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vWWPFORMREFERENCENAME", AV14WWPFormReferenceName);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMREFERENCENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14WWPFormReferenceName, "")), context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMINSTANCEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9WWPFormInstanceId), 6, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMINSTANCEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9WWPFormInstanceId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV8WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPDYNAMICFORMMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8WWPDynamicFormMode, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISLINKINGDISCUSSION", AV29isLinkingDiscussion);
         GxWebStd.gx_hidden_field( context, "gxhash_vISLINKINGDISCUSSION", GetSecureSignedToken( "", AV29isLinkingDiscussion, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV8WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPDYNAMICFORMMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8WWPDynamicFormMode, "")), context));
         GxWebStd.gx_hidden_field( context, "WWPFORMVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "WWPFORMREFERENCENAME", A208WWPFormReferenceName);
         GxWebStd.gx_hidden_field( context, "vWWPFORMREFERENCENAME", AV14WWPFormReferenceName);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMREFERENCENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14WWPFormReferenceName, "")), context));
         GxWebStd.gx_hidden_field( context, "WWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPFORMINSTANCE", AV7WWPFormInstance);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPFORMINSTANCE", AV7WWPFormInstance);
         }
         GxWebStd.gx_boolean_hidden_field( context, "WWPFORMISWIZARD", A232WWPFormIsWizard);
         GxWebStd.gx_hidden_field( context, "WWPFORMTITLE", A209WWPFormTitle);
         GxWebStd.gx_hidden_field( context, "vDEFAULTSTEP", AV22DefaultStep);
         GxWebStd.gx_hidden_field( context, "vWWPFORMINSTANCEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9WWPFormInstanceId), 6, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMINSTANCEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9WWPFormInstanceId), "ZZZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vEXECUTEENTEREVENT", AV23ExecuteEnterEvent);
         GxWebStd.gx_boolean_hidden_field( context, "vWWPFORMISWIZARD", AV11WWPFormIsWizard);
         GxWebStd.gx_boolean_hidden_field( context, "vISLINKINGDISCUSSION", AV29isLinkingDiscussion);
         GxWebStd.gx_hidden_field( context, "gxhash_vISLINKINGDISCUSSION", GetSecureSignedToken( "", AV29isLinkingDiscussion, context));
         GxWebStd.gx_hidden_field( context, "DDC_USERACTIONDISCUSSION_Icontype", StringUtil.RTrim( Ddc_useractiondiscussion_Icontype));
         GxWebStd.gx_hidden_field( context, "DDC_USERACTIONDISCUSSION_Icon", StringUtil.RTrim( Ddc_useractiondiscussion_Icon));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UARESUME_Title", StringUtil.RTrim( Dvelop_confirmpanel_uaresume_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UARESUME_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_uaresume_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UARESUME_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_uaresume_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UARESUME_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_uaresume_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UARESUME_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_uaresume_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UARESUME_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_uaresume_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UARESUME_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_uaresume_Confirmtype));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UARESUME_Result", StringUtil.RTrim( Dvelop_confirmpanel_uaresume_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UARESUME_Result", StringUtil.RTrim( Dvelop_confirmpanel_uaresume_Result));
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
         if ( ! ( WebComp_Wcwwp_dynamicformfs_wc == null ) )
         {
            WebComp_Wcwwp_dynamicformfs_wc.componentjscripts();
         }
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
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
            WE1Z2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1Z2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("workwithplus.dynamicforms.wwp_dynamicform.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV14WWPFormReferenceName)),UrlEncode(StringUtil.LTrimStr(AV9WWPFormInstanceId,6,0)),UrlEncode(StringUtil.RTrim(AV8WWPDynamicFormMode)),UrlEncode(StringUtil.BoolToStr(AV29isLinkingDiscussion))}, new string[] {"WWPFormReferenceName","WWPFormInstanceId","WWPDynamicFormMode","isLinkingDiscussion"})  ;
      }

      public override string GetPgmname( )
      {
         return "WorkWithPlus.DynamicForms.WWP_DynamicForm" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Dynamic Form", "") ;
      }

      protected void WB1Z0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblResidentname_Internalname, lblResidentname_Caption, "", "", lblResidentname_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "CellMarginBottom10 AttributeWeightBold AttributeSizeLarge", 0, "", 1, 1, 0, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DynamicForm.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6", "end", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableright_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "align-items:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ViewCellRightItem", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucDdc_useractiondiscussion.SetProperty("IconType", Ddc_useractiondiscussion_Icontype);
            ucDdc_useractiondiscussion.SetProperty("Icon", Ddc_useractiondiscussion_Icon);
            ucDdc_useractiondiscussion.SetProperty("Caption", Ddc_useractiondiscussion_Caption);
            ucDdc_useractiondiscussion.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_useractiondiscussion_Internalname, "DDC_USERACTIONDISCUSSIONContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0025"+"", StringUtil.RTrim( WebComp_Wcwwp_dynamicformfs_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0025"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcwwp_dynamicformfs_wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwwp_dynamicformfs_wc), StringUtil.Lower( WebComp_Wcwwp_dynamicformfs_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0025"+"");
                  }
                  WebComp_Wcwwp_dynamicformfs_wc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwwp_dynamicformfs_wc), StringUtil.Lower( WebComp_Wcwwp_dynamicformfs_wc_Component)) != 0 )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/DynamicForms/WWP_DynamicForm.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", context.GetMessage( "Close", ""), bttBtncancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtncancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/DynamicForms/WWP_DynamicForm.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuaresume_Internalname, "", context.GetMessage( "Resume", ""), bttBtnuaresume_Jsonclick, 7, context.GetMessage( "Resume", ""), "", StyleString, ClassString, bttBtnuaresume_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e111z1_client"+"'", TempTags, "", 2, "HLP_WorkWithPlus/DynamicForms/WWP_DynamicForm.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSessionid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5SessionId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSessionid_Jsonclick, 0, "Attribute", "", "", "", "", edtavSessionid_Visible, 1, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkWithPlus/DynamicForms/WWP_DynamicForm.htm");
            wb_table1_39_1Z2( true) ;
         }
         else
         {
            wb_table1_39_1Z2( false) ;
         }
         return  ;
      }

      protected void wb_table1_39_1Z2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0045"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0045"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0045"+"");
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

      protected void START1Z2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Dynamic Form", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1Z0( ) ;
      }

      protected void WS1Z2( )
      {
         START1Z2( ) ;
         EVT1Z2( ) ;
      }

      protected void EVT1Z2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "DDC_USERACTIONDISCUSSION.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_useractiondiscussion.Onloadcomponent */
                              E121Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_UARESUME.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_uaresume.Close */
                              E131Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E141Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E151Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E161Z2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E171Z2 ();
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
                        if ( nCmpId == 25 )
                        {
                           OldWcwwp_dynamicformfs_wc = cgiGet( "W0025");
                           if ( ( StringUtil.Len( OldWcwwp_dynamicformfs_wc) == 0 ) || ( StringUtil.StrCmp(OldWcwwp_dynamicformfs_wc, WebComp_Wcwwp_dynamicformfs_wc_Component) != 0 ) )
                           {
                              WebComp_Wcwwp_dynamicformfs_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWcwwp_dynamicformfs_wc, new Object[] {context} );
                              WebComp_Wcwwp_dynamicformfs_wc.ComponentInit();
                              WebComp_Wcwwp_dynamicformfs_wc.Name = "OldWcwwp_dynamicformfs_wc";
                              WebComp_Wcwwp_dynamicformfs_wc_Component = OldWcwwp_dynamicformfs_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wcwwp_dynamicformfs_wc_Component) != 0 )
                           {
                              WebComp_Wcwwp_dynamicformfs_wc.componentprocess("W0025", "", sEvt);
                           }
                           WebComp_Wcwwp_dynamicformfs_wc_Component = OldWcwwp_dynamicformfs_wc;
                        }
                        else if ( nCmpId == 45 )
                        {
                           OldWwpaux_wc = cgiGet( "W0045");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0045", "", sEvt);
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

      protected void WE1Z2( )
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

      protected void PA1Z2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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
               GX_FocusControl = edtavSessionid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
         RF1Z2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF1Z2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E151Z2 ();
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcwwp_dynamicformfs_wc_Component) != 0 )
               {
                  WebComp_Wcwwp_dynamicformfs_wc.componentstart();
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
            E171Z2 ();
            WB1Z0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes1Z2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1Z0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E141Z2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Ddc_useractiondiscussion_Icontype = cgiGet( "DDC_USERACTIONDISCUSSION_Icontype");
            Ddc_useractiondiscussion_Icon = cgiGet( "DDC_USERACTIONDISCUSSION_Icon");
            Dvelop_confirmpanel_uaresume_Title = cgiGet( "DVELOP_CONFIRMPANEL_UARESUME_Title");
            Dvelop_confirmpanel_uaresume_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_UARESUME_Confirmationtext");
            Dvelop_confirmpanel_uaresume_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_UARESUME_Yesbuttoncaption");
            Dvelop_confirmpanel_uaresume_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_UARESUME_Nobuttoncaption");
            Dvelop_confirmpanel_uaresume_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_UARESUME_Cancelbuttoncaption");
            Dvelop_confirmpanel_uaresume_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_UARESUME_Yesbuttonposition");
            Dvelop_confirmpanel_uaresume_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_UARESUME_Confirmtype");
            Dvelop_confirmpanel_uaresume_Result = cgiGet( "DVELOP_CONFIRMPANEL_UARESUME_Result");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSessionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSessionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSESSIONID");
               GX_FocusControl = edtavSessionid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5SessionId = 0;
               AssignAttri("", false, "AV5SessionId", StringUtil.LTrimStr( (decimal)(AV5SessionId), 4, 0));
            }
            else
            {
               AV5SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavSessionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV5SessionId", StringUtil.LTrimStr( (decimal)(AV5SessionId), 4, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E141Z2 ();
         if (returnInSub) return;
      }

      protected void E141Z2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( AV29isLinkingDiscussion )
         {
            this.executeUsercontrolMethod("", false, "DDC_USERACTIONDISCUSSIONContainer", "Open", "", new Object[] {});
         }
         if ( StringUtil.StrCmp(AV10HttpRequest.Method, "GET") == 0 )
         {
            AV5SessionId = (short)(NumberUtil.Random( )*10000);
            AssignAttri("", false, "AV5SessionId", StringUtil.LTrimStr( (decimal)(AV5SessionId), 4, 0));
            AV7WWPFormInstance = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
            if ( StringUtil.StrCmp(AV8WWPDynamicFormMode, "INS") == 0 )
            {
               /* Using cursor H001Z2 */
               pr_default.execute(0);
               while ( (pr_default.getStatus(0) != 101) )
               {
                  BRK1Z3 = false;
                  A207WWPFormVersionNumber = H001Z2_A207WWPFormVersionNumber[0];
                  A206WWPFormId = H001Z2_A206WWPFormId[0];
                  A208WWPFormReferenceName = H001Z2_A208WWPFormReferenceName[0];
                  A216WWPFormResume = H001Z2_A216WWPFormResume[0];
                  A235WWPFormResumeMessage = H001Z2_A235WWPFormResumeMessage[0];
                  if ( StringUtil.StrCmp(A208WWPFormReferenceName, AV14WWPFormReferenceName) == 0 )
                  {
                     AV7WWPFormInstance.gxTpr_Wwpformid = A206WWPFormId;
                     AV7WWPFormInstance.gxTpr_Wwpformversionnumber = A207WWPFormVersionNumber;
                     AV15WWPFormResume = A216WWPFormResume;
                     AssignAttri("", false, "AV15WWPFormResume", StringUtil.Str( (decimal)(AV15WWPFormResume), 1, 0));
                     AV18WWPFormResumeMessage = A235WWPFormResumeMessage;
                     AssignAttri("", false, "AV18WWPFormResumeMessage", AV18WWPFormResumeMessage);
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
                  while ( (pr_default.getStatus(0) != 101) && ( H001Z2_A206WWPFormId[0] == A206WWPFormId ) )
                  {
                     BRK1Z3 = false;
                     A207WWPFormVersionNumber = H001Z2_A207WWPFormVersionNumber[0];
                     A208WWPFormReferenceName = H001Z2_A208WWPFormReferenceName[0];
                     A216WWPFormResume = H001Z2_A216WWPFormResume[0];
                     A235WWPFormResumeMessage = H001Z2_A235WWPFormResumeMessage[0];
                     BRK1Z3 = true;
                     pr_default.readNext(0);
                  }
                  if ( ! BRK1Z3 )
                  {
                     BRK1Z3 = true;
                     pr_default.readNext(0);
                  }
               }
               pr_default.close(0);
               AV7WWPFormInstance.gxTpr_Wwpforminstanceid = AV9WWPFormInstanceId;
               AV17Resuming = false;
               if ( AV15WWPFormResume != 0 )
               {
                  AV5SessionId = (short)(Math.Round(NumberUtil.Val( new GeneXus.Programs.wwpbaseobjects.loaduserkeyvalue(context).executeUdp(  StringUtil.Format( "WWPDynFormCurrentForm_%1", StringUtil.Trim( StringUtil.Str( (decimal)(AV7WWPFormInstance.gxTpr_Wwpformid), 4, 0)), "", "", "", "", "", "", "", "")), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV5SessionId", StringUtil.LTrimStr( (decimal)(AV5SessionId), 4, 0));
                  if ( (0==AV5SessionId) || ( ! AV16AllowResumingDeprecatedFormVersion && ( NumberUtil.Val( new GeneXus.Programs.wwpbaseobjects.loaduserkeyvalue(context).executeUdp(  StringUtil.Format( "WWPDynFormCurrentFormVersion_%1", StringUtil.Trim( StringUtil.Str( (decimal)(AV7WWPFormInstance.gxTpr_Wwpformid), 4, 0)), "", "", "", "", "", "", "", "")), ".") != Convert.ToDecimal( AV7WWPFormInstance.gxTpr_Wwpformversionnumber )) ) )
                  {
                     AV5SessionId = (short)(NumberUtil.Random( )*10000);
                     AssignAttri("", false, "AV5SessionId", StringUtil.LTrimStr( (decimal)(AV5SessionId), 4, 0));
                  }
                  else
                  {
                     AV17Resuming = true;
                     if ( AV15WWPFormResume == 1 )
                     {
                        Dvelop_confirmpanel_uaresume_Confirmationtext = AV18WWPFormResumeMessage;
                        ucDvelop_confirmpanel_uaresume.SendProperty(context, "", false, Dvelop_confirmpanel_uaresume_Internalname, "ConfirmationText", Dvelop_confirmpanel_uaresume_Confirmationtext);
                        this.executeUsercontrolMethod("", false, "DVELOP_CONFIRMPANEL_UARESUMEContainer", "Confirm", "", new Object[] {});
                     }
                  }
               }
               if ( AV17Resuming )
               {
                  AV7WWPFormInstance = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
                  AV7WWPFormInstance.FromJSonString(new GeneXus.Programs.wwpbaseobjects.loaduserkeyvalue(context).executeUdp(  StringUtil.Format( "WWP_DF_%1", StringUtil.Trim( StringUtil.Str( (decimal)(AV5SessionId), 4, 0)), "", "", "", "", "", "", "", "")), null);
                  GXt_char1 = AV22DefaultStep;
                  new GeneXus.Programs.wwpbaseobjects.loaduserkeyvalue(context ).execute(  StringUtil.Format( "WWPDynFormCurrentStep_%1", StringUtil.Trim( StringUtil.Str( (decimal)(AV7WWPFormInstance.gxTpr_Wwpformid), 4, 0)), "", "", "", "", "", "", "", ""), out  GXt_char1) ;
                  AV22DefaultStep = GXt_char1;
                  AssignAttri("", false, "AV22DefaultStep", AV22DefaultStep);
               }
               else
               {
                  /* Execute user subroutine: 'INITIALIZE NEW INSTANCE' */
                  S112 ();
                  if (returnInSub) return;
               }
            }
            else
            {
               AV7WWPFormInstance.Load(AV9WWPFormInstanceId);
               lblResidentname_Caption = AV7WWPFormInstance.gxTpr_Wwpuserextendedfullname;
               AssignProp("", false, lblResidentname_Internalname, "Caption", lblResidentname_Caption, true);
            }
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_saveforminstance(context ).execute(  AV5SessionId,  AV7WWPFormInstance) ;
            /* Execute user subroutine: 'INITIALIZE WC' */
            S122 ();
            if (returnInSub) return;
         }
         this.executeExternalObjectMethod("", false, "WWPActions", "ConfirmInTransaction_AttachToButton", new Object[] {(string)divLayoutmaintable_Internalname,(string)bttBtnenter_Internalname}, false);
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         edtavSessionid_Visible = 0;
         AssignProp("", false, edtavSessionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSessionid_Visible), 5, 0), true);
      }

      protected void E151Z2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E131Z2( )
      {
         /* Dvelop_confirmpanel_uaresume_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_uaresume_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION UARESUME' */
            S142 ();
            if (returnInSub) return;
         }
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_uaresume_Result, "No") == 0 )
         {
            AV6WebSession.Remove(StringUtil.Format( "WWP_DF_%1", StringUtil.Trim( StringUtil.Str( (decimal)(AV5SessionId), 4, 0)), "", "", "", "", "", "", "", ""));
            AV5SessionId = (short)(NumberUtil.Random( )*10000);
            AssignAttri("", false, "AV5SessionId", StringUtil.LTrimStr( (decimal)(AV5SessionId), 4, 0));
            AV7WWPFormInstance = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
            /* Using cursor H001Z3 */
            pr_default.execute(1, new Object[] {AV14WWPFormReferenceName});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A208WWPFormReferenceName = H001Z3_A208WWPFormReferenceName[0];
               A206WWPFormId = H001Z3_A206WWPFormId[0];
               A207WWPFormVersionNumber = H001Z3_A207WWPFormVersionNumber[0];
               AV7WWPFormInstance.gxTpr_Wwpformid = A206WWPFormId;
               AV7WWPFormInstance.gxTpr_Wwpformversionnumber = A207WWPFormVersionNumber;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Execute user subroutine: 'INITIALIZE NEW INSTANCE' */
            S112 ();
            if (returnInSub) return;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_saveforminstance(context ).execute(  AV5SessionId,  AV7WWPFormInstance) ;
            AV22DefaultStep = "";
            AssignAttri("", false, "AV22DefaultStep", AV22DefaultStep);
            /* Execute user subroutine: 'INITIALIZE WC' */
            S122 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7WWPFormInstance", AV7WWPFormInstance);
      }

      protected void E121Z2( )
      {
         /* Ddc_useractiondiscussion_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.Discussions.WWP_DiscussionsWC")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.discussions.wwp_discussionswc", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WWPBaseObjects.Discussions.WWP_DiscussionsWC";
            WebComp_Wwpaux_wc_Component = "WWPBaseObjects.Discussions.WWP_DiscussionsWC";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0045",(string)"",(string)"WWP_DynamicForm",StringUtil.Trim( StringUtil.Str( (decimal)(AV9WWPFormInstanceId), 6, 0)),AV7WWPFormInstance.gxTpr_Wwpformtitle,formatLink("workwithplus.dynamicforms.wwp_dynamicform.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV14WWPFormReferenceName)),UrlEncode(StringUtil.LTrimStr(AV9WWPFormInstanceId,6,0)),UrlEncode(StringUtil.RTrim(AV8WWPDynamicFormMode)),UrlEncode(StringUtil.BoolToStr(true))}, new string[] {"WWPFormReferenceName","WWPFormInstanceId","WWPDynamicFormMode","isLinkingDiscussion"}) });
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)""+""+"",(string)"",(string)""+""+"",(string)"",(string)""+"",(string)"",(string)"",(string)"",(string)""+""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0045"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S132( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV8WWPDynamicFormMode, context.GetMessage( "INS", "")) == 0 ) ) )
         {
            bttBtnenter_Visible = 0;
            AssignProp("", false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
         }
         if ( ! ( ( 1 == 0 ) ) )
         {
            bttBtnuaresume_Visible = 0;
            AssignProp("", false, bttBtnuaresume_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnuaresume_Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'DO ACTION UARESUME' Routine */
         returnInSub = false;
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E161Z2 ();
         if (returnInSub) return;
      }

      protected void E161Z2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( ! AV23ExecuteEnterEvent )
         {
            AV23ExecuteEnterEvent = true;
            AssignAttri("", false, "AV23ExecuteEnterEvent", AV23ExecuteEnterEvent);
            this.executeExternalObjectMethod("", false, "WWPActions", "ConfirmInTransaction_Confirm", new Object[] {}, false);
         }
         else
         {
            AV23ExecuteEnterEvent = false;
            AssignAttri("", false, "AV23ExecuteEnterEvent", AV23ExecuteEnterEvent);
            if ( ! AV11WWPFormIsWizard )
            {
               if ( StringUtil.StrCmp(AV8WWPDynamicFormMode, "DSP") != 0 )
               {
                  GXt_SdtWWP_FormInstance2 = AV7WWPFormInstance;
                  new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadforminstance(context ).execute(  AV5SessionId, out  GXt_SdtWWP_FormInstance2) ;
                  AV7WWPFormInstance = GXt_SdtWWP_FormInstance2;
                  new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_validateinstance(context ).execute(  AV7WWPFormInstance,  true, out  AV20HasErrors, out  AV13ErrorIds, out  AV21Messages) ;
                  if ( ! AV20HasErrors )
                  {
                     if ( ( StringUtil.StrCmp(AV8WWPDynamicFormMode, "UPD") == 0 ) || ( StringUtil.StrCmp(AV8WWPDynamicFormMode, "INS") == 0 ) )
                     {
                        AV7WWPFormInstance.Save();
                     }
                     else if ( StringUtil.StrCmp(AV8WWPDynamicFormMode, "DLT") == 0 )
                     {
                        AV7WWPFormInstance.Delete();
                     }
                     if ( AV7WWPFormInstance.Success() )
                     {
                        AV6WebSession.Remove(StringUtil.Format( "WWP_DF_%1", StringUtil.Trim( StringUtil.Str( (decimal)(AV5SessionId), 4, 0)), "", "", "", "", "", "", "", ""));
                        new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue(context ).execute(  StringUtil.Format( "WWP_DF_%1", StringUtil.Trim( StringUtil.Str( (decimal)(AV5SessionId), 4, 0)), "", "", "", "", "", "", "", ""),  "") ;
                        new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue(context ).execute(  StringUtil.Format( "WWPDynFormCurrentForm_%1", StringUtil.Trim( StringUtil.Str( (decimal)(AV7WWPFormInstance.gxTpr_Wwpformid), 4, 0)), "", "", "", "", "", "", "", ""),  "") ;
                        new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue(context ).execute(  StringUtil.Format( "WWPDynFormCurrentFormVersion_%1", StringUtil.Trim( StringUtil.Str( (decimal)(AV7WWPFormInstance.gxTpr_Wwpformid), 4, 0)), "", "", "", "", "", "", "", ""),  "") ;
                        context.CommitDataStores("workwithplus.dynamicforms.wwp_dynamicform",pr_default);
                     }
                     else
                     {
                        AV20HasErrors = true;
                        AV21Messages = AV7WWPFormInstance.GetMessages();
                     }
                  }
                  if ( AV20HasErrors )
                  {
                     if ( AV21Messages.Count == 0 )
                     {
                        this.executeExternalObjectMethod("", false, "GlobalEvents", "DynamicForm_Validate", new Object[] {(short)AV5SessionId,(string)AV13ErrorIds}, true);
                     }
                     else
                     {
                        AV33GXV1 = 1;
                        while ( AV33GXV1 <= AV21Messages.Count )
                        {
                           AV19Message = ((GeneXus.Utils.SdtMessages_Message)AV21Messages.Item(AV33GXV1));
                           GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV19Message.gxTpr_Description,  "error",  "",  "true",  ""));
                           AV33GXV1 = (int)(AV33GXV1+1);
                        }
                     }
                  }
               }
               else
               {
                  context.setWebReturnParms(new Object[] {});
                  context.setWebReturnParmsMetadata(new Object[] {});
                  context.wjLocDisableFrm = 1;
                  context.nUserReturn = 1;
                  returnInSub = true;
                  if (true) return;
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7WWPFormInstance", AV7WWPFormInstance);
      }

      protected void S112( )
      {
         /* 'INITIALIZE NEW INSTANCE' Routine */
         returnInSub = false;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_createchildren(context ).execute(  0,  0, ref  AV7WWPFormInstance) ;
         AV7WWPFormInstance.Check();
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_clearunusedreferences(context ).execute( ref  AV7WWPFormInstance) ;
         if ( ! AV7WWPFormInstance.Success() )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_DF_ErrorLoadingFormInstance", ""), ((GeneXus.Utils.SdtMessages_Message)AV7WWPFormInstance.GetMessages().Item(1)).gxTpr_Description, "", "", "", "", "", "", "", ""));
         }
         AV12WWPForm.Load(AV7WWPFormInstance.gxTpr_Wwpformid, AV7WWPFormInstance.gxTpr_Wwpformversionnumber);
         if ( ! AV12WWPForm.gxTpr_Wwpforminstantiated )
         {
            AV12WWPForm.gxTpr_Wwpforminstantiated = true;
            AV12WWPForm.Save();
            context.CommitDataStores("workwithplus.dynamicforms.wwp_dynamicform",pr_default);
         }
         if ( AV12WWPForm.gxTpr_Wwpformresume != 0 )
         {
            new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue(context ).execute(  StringUtil.Format( "WWPDynFormCurrentForm_%1", StringUtil.Trim( StringUtil.Str( (decimal)(AV7WWPFormInstance.gxTpr_Wwpformid), 4, 0)), "", "", "", "", "", "", "", ""),  StringUtil.Trim( StringUtil.Str( (decimal)(AV5SessionId), 4, 0))) ;
            new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue(context ).execute(  StringUtil.Format( "WWPDynFormCurrentFormVersion_%1", StringUtil.Trim( StringUtil.Str( (decimal)(AV7WWPFormInstance.gxTpr_Wwpformid), 4, 0)), "", "", "", "", "", "", "", ""),  StringUtil.Trim( StringUtil.Str( (decimal)(AV7WWPFormInstance.gxTpr_Wwpformversionnumber), 4, 0))) ;
         }
      }

      protected void S122( )
      {
         /* 'INITIALIZE WC' Routine */
         returnInSub = false;
         AV6WebSession.Set("WWPDynFormSetFocus", "T");
         /* Using cursor H001Z4 */
         pr_default.execute(2, new Object[] {AV7WWPFormInstance.gxTpr_Wwpformid, AV7WWPFormInstance.gxTpr_Wwpformversionnumber});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A207WWPFormVersionNumber = H001Z4_A207WWPFormVersionNumber[0];
            A206WWPFormId = H001Z4_A206WWPFormId[0];
            A232WWPFormIsWizard = H001Z4_A232WWPFormIsWizard[0];
            A209WWPFormTitle = H001Z4_A209WWPFormTitle[0];
            AV11WWPFormIsWizard = A232WWPFormIsWizard;
            AssignAttri("", false, "AV11WWPFormIsWizard", AV11WWPFormIsWizard);
            Form.Caption = A209WWPFormTitle;
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
         if ( AV11WWPFormIsWizard )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wcwwp_dynamicformfs_wc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwwp_dynamicformfs_wc_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_Wizard_WC")) != 0 )
            {
               WebComp_Wcwwp_dynamicformfs_wc = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_wizard_wc", new Object[] {context} );
               WebComp_Wcwwp_dynamicformfs_wc.ComponentInit();
               WebComp_Wcwwp_dynamicformfs_wc.Name = "WorkWithPlus.DynamicForms.WWP_DF_Wizard_WC";
               WebComp_Wcwwp_dynamicformfs_wc_Component = "WorkWithPlus.DynamicForms.WWP_DF_Wizard_WC";
            }
            if ( StringUtil.Len( WebComp_Wcwwp_dynamicformfs_wc_Component) != 0 )
            {
               WebComp_Wcwwp_dynamicformfs_wc.setjustcreated();
               WebComp_Wcwwp_dynamicformfs_wc.componentprepare(new Object[] {(string)"W0025",(string)"",(string)AV8WWPDynamicFormMode,(short)AV5SessionId,(string)AV22DefaultStep,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV7WWPFormInstance});
               WebComp_Wcwwp_dynamicformfs_wc.componentbind(new Object[] {(string)"",(string)"vSESSIONID",(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcwwp_dynamicformfs_wc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0025"+"");
               WebComp_Wcwwp_dynamicformfs_wc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            bttBtnenter_Visible = 0;
            AssignProp("", false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
            bttBtncancel_Visible = 0;
            AssignProp("", false, bttBtncancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtncancel_Visible), 5, 0), true);
         }
         else
         {
            divTablemain_Class = "TableMainDynamicForm PlainDynamicForm";
            AssignProp("", false, divTablemain_Internalname, "Class", divTablemain_Class, true);
            bttBtnenter_Visible = 1;
            AssignProp("", false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
            bttBtncancel_Visible = 1;
            AssignProp("", false, bttBtncancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtncancel_Visible), 5, 0), true);
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wcwwp_dynamicformfs_wc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwwp_dynamicformfs_wc_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_FS_WC")) != 0 )
            {
               WebComp_Wcwwp_dynamicformfs_wc = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_fs_wc", new Object[] {context} );
               WebComp_Wcwwp_dynamicformfs_wc.ComponentInit();
               WebComp_Wcwwp_dynamicformfs_wc.Name = "WorkWithPlus.DynamicForms.WWP_DF_FS_WC";
               WebComp_Wcwwp_dynamicformfs_wc_Component = "WorkWithPlus.DynamicForms.WWP_DF_FS_WC";
            }
            if ( StringUtil.Len( WebComp_Wcwwp_dynamicformfs_wc_Component) != 0 )
            {
               WebComp_Wcwwp_dynamicformfs_wc.setjustcreated();
               WebComp_Wcwwp_dynamicformfs_wc.componentprepare(new Object[] {(string)"W0025",(string)"",(string)AV8WWPDynamicFormMode,(short)0,(short)0,(short)AV5SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV7WWPFormInstance});
               WebComp_Wcwwp_dynamicformfs_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"vSESSIONID",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcwwp_dynamicformfs_wc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0025"+"");
               WebComp_Wcwwp_dynamicformfs_wc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E171Z2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_39_1Z2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_uaresume_Internalname, tblTabledvelop_confirmpanel_uaresume_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_uaresume.SetProperty("Title", Dvelop_confirmpanel_uaresume_Title);
            ucDvelop_confirmpanel_uaresume.SetProperty("ConfirmationText", Dvelop_confirmpanel_uaresume_Confirmationtext);
            ucDvelop_confirmpanel_uaresume.SetProperty("YesButtonCaption", Dvelop_confirmpanel_uaresume_Yesbuttoncaption);
            ucDvelop_confirmpanel_uaresume.SetProperty("NoButtonCaption", Dvelop_confirmpanel_uaresume_Nobuttoncaption);
            ucDvelop_confirmpanel_uaresume.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_uaresume_Cancelbuttoncaption);
            ucDvelop_confirmpanel_uaresume.SetProperty("YesButtonPosition", Dvelop_confirmpanel_uaresume_Yesbuttonposition);
            ucDvelop_confirmpanel_uaresume.SetProperty("ConfirmType", Dvelop_confirmpanel_uaresume_Confirmtype);
            ucDvelop_confirmpanel_uaresume.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_uaresume_Internalname, "DVELOP_CONFIRMPANEL_UARESUMEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_UARESUMEContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_39_1Z2e( true) ;
         }
         else
         {
            wb_table1_39_1Z2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV14WWPFormReferenceName = (string)getParm(obj,0);
         AssignAttri("", false, "AV14WWPFormReferenceName", AV14WWPFormReferenceName);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMREFERENCENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14WWPFormReferenceName, "")), context));
         AV9WWPFormInstanceId = Convert.ToInt32(getParm(obj,1));
         AssignAttri("", false, "AV9WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(AV9WWPFormInstanceId), 6, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMINSTANCEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9WWPFormInstanceId), "ZZZZZ9"), context));
         AV8WWPDynamicFormMode = (string)getParm(obj,2);
         AssignAttri("", false, "AV8WWPDynamicFormMode", AV8WWPDynamicFormMode);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPDYNAMICFORMMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8WWPDynamicFormMode, "")), context));
         AV29isLinkingDiscussion = (bool)getParm(obj,3);
         AssignAttri("", false, "AV29isLinkingDiscussion", AV29isLinkingDiscussion);
         GxWebStd.gx_hidden_field( context, "gxhash_vISLINKINGDISCUSSION", GetSecureSignedToken( "", AV29isLinkingDiscussion, context));
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
         PA1Z2( ) ;
         WS1Z2( ) ;
         WE1Z2( ) ;
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
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wcwwp_dynamicformfs_wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcwwp_dynamicformfs_wc_Component) != 0 )
            {
               WebComp_Wcwwp_dynamicformfs_wc.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256309444693", true, true);
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
         context.AddJavascriptSource("workwithplus/dynamicforms/wwp_dynamicform.js", "?20256309444693", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         lblResidentname_Internalname = "RESIDENTNAME";
         Ddc_useractiondiscussion_Internalname = "DDC_USERACTIONDISCUSSION";
         divTableright_Internalname = "TABLERIGHT";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         bttBtnuaresume_Internalname = "BTNUARESUME";
         divTablemain_Internalname = "TABLEMAIN";
         edtavSessionid_Internalname = "vSESSIONID";
         Dvelop_confirmpanel_uaresume_Internalname = "DVELOP_CONFIRMPANEL_UARESUME";
         tblTabledvelop_confirmpanel_uaresume_Internalname = "TABLEDVELOP_CONFIRMPANEL_UARESUME";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
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
         edtavSessionid_Jsonclick = "";
         edtavSessionid_Visible = 1;
         bttBtnuaresume_Visible = 1;
         bttBtncancel_Visible = 1;
         bttBtnenter_Visible = 1;
         Ddc_useractiondiscussion_Caption = "";
         lblResidentname_Caption = context.GetMessage( "Resident Name", "");
         divTablemain_Class = "TableMainDynamicForm";
         divLayoutmaintable_Class = "Table TableTransactionTemplate";
         Dvelop_confirmpanel_uaresume_Confirmtype = "1";
         Dvelop_confirmpanel_uaresume_Yesbuttonposition = "left";
         Dvelop_confirmpanel_uaresume_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_uaresume_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_uaresume_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_uaresume_Confirmationtext = "";
         Dvelop_confirmpanel_uaresume_Title = context.GetMessage( "Resume", "");
         Ddc_useractiondiscussion_Icon = "far fa-comment-dots";
         Ddc_useractiondiscussion_Icontype = "FontIcon";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Dynamic Form", "");
         context.GX_msglist.DisplayMode = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV8WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE","hsh":true},{"av":"AV14WWPFormReferenceName","fld":"vWWPFORMREFERENCENAME","hsh":true},{"av":"AV9WWPFormInstanceId","fld":"vWWPFORMINSTANCEID","pic":"ZZZZZ9","hsh":true},{"av":"AV29isLinkingDiscussion","fld":"vISLINKINGDISCUSSION","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"ctrl":"BTNENTER","prop":"Visible"},{"ctrl":"BTNUARESUME","prop":"Visible"}]}""");
         setEventMetadata("'DOUARESUME'","""{"handler":"E111Z1","iparms":[]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_UARESUME.CLOSE","""{"handler":"E131Z2","iparms":[{"av":"Dvelop_confirmpanel_uaresume_Result","ctrl":"DVELOP_CONFIRMPANEL_UARESUME","prop":"Result"},{"av":"AV5SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME"},{"av":"AV14WWPFormReferenceName","fld":"vWWPFORMREFERENCENAME","hsh":true},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"AV7WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A209WWPFormTitle","fld":"WWPFORMTITLE"},{"av":"AV8WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE","hsh":true},{"av":"AV22DefaultStep","fld":"vDEFAULTSTEP"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_UARESUME.CLOSE",""","oparms":[{"av":"AV5SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV7WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV22DefaultStep","fld":"vDEFAULTSTEP"},{"av":"AV11WWPFormIsWizard","fld":"vWWPFORMISWIZARD"},{"ctrl":"FORM","prop":"Caption"},{"av":"divTablemain_Class","ctrl":"TABLEMAIN","prop":"Class"},{"ctrl":"WCWWP_DYNAMICFORMFS_WC"},{"ctrl":"BTNENTER","prop":"Visible"},{"ctrl":"BTNCANCEL","prop":"Visible"}]}""");
         setEventMetadata("DDC_USERACTIONDISCUSSION.ONLOADCOMPONENT","""{"handler":"E121Z2","iparms":[{"av":"AV7WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV14WWPFormReferenceName","fld":"vWWPFORMREFERENCENAME","hsh":true},{"av":"AV9WWPFormInstanceId","fld":"vWWPFORMINSTANCEID","pic":"ZZZZZ9","hsh":true},{"av":"AV8WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE","hsh":true}]""");
         setEventMetadata("DDC_USERACTIONDISCUSSION.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("ENTER","""{"handler":"E161Z2","iparms":[{"av":"AV23ExecuteEnterEvent","fld":"vEXECUTEENTEREVENT"},{"av":"AV11WWPFormIsWizard","fld":"vWWPFORMISWIZARD"},{"av":"AV8WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE","hsh":true},{"av":"AV5SessionId","fld":"vSESSIONID","pic":"ZZZ9"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV7WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV23ExecuteEnterEvent","fld":"vEXECUTEENTEREVENT"}]}""");
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
         wcpOAV14WWPFormReferenceName = "";
         wcpOAV8WWPDynamicFormMode = "";
         Dvelop_confirmpanel_uaresume_Result = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         A208WWPFormReferenceName = "";
         AV7WWPFormInstance = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         A209WWPFormTitle = "";
         AV22DefaultStep = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         lblResidentname_Jsonclick = "";
         ucDdc_useractiondiscussion = new GXUserControl();
         WebComp_Wcwwp_dynamicformfs_wc_Component = "";
         OldWcwwp_dynamicformfs_wc = "";
         TempTags = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         bttBtnuaresume_Jsonclick = "";
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV10HttpRequest = new GxHttpRequest( context);
         H001Z2_A207WWPFormVersionNumber = new short[1] ;
         H001Z2_A206WWPFormId = new short[1] ;
         H001Z2_A208WWPFormReferenceName = new string[] {""} ;
         H001Z2_A216WWPFormResume = new short[1] ;
         H001Z2_A235WWPFormResumeMessage = new string[] {""} ;
         A235WWPFormResumeMessage = "";
         AV18WWPFormResumeMessage = "";
         ucDvelop_confirmpanel_uaresume = new GXUserControl();
         GXt_char1 = "";
         AV6WebSession = context.GetSession();
         H001Z3_A208WWPFormReferenceName = new string[] {""} ;
         H001Z3_A206WWPFormId = new short[1] ;
         H001Z3_A207WWPFormVersionNumber = new short[1] ;
         GXt_SdtWWP_FormInstance2 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         AV13ErrorIds = "";
         AV21Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV19Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV12WWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         H001Z4_A207WWPFormVersionNumber = new short[1] ;
         H001Z4_A206WWPFormId = new short[1] ;
         H001Z4_A232WWPFormIsWizard = new bool[] {false} ;
         H001Z4_A209WWPFormTitle = new string[] {""} ;
         sStyleString = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_dynamicform__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_dynamicform__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_dynamicform__default(),
            new Object[][] {
                new Object[] {
               H001Z2_A207WWPFormVersionNumber, H001Z2_A206WWPFormId, H001Z2_A208WWPFormReferenceName, H001Z2_A216WWPFormResume, H001Z2_A235WWPFormResumeMessage
               }
               , new Object[] {
               H001Z3_A208WWPFormReferenceName, H001Z3_A206WWPFormId, H001Z3_A207WWPFormVersionNumber
               }
               , new Object[] {
               H001Z4_A207WWPFormVersionNumber, H001Z4_A206WWPFormId, H001Z4_A232WWPFormIsWizard, H001Z4_A209WWPFormTitle
               }
            }
         );
         WebComp_Wcwwp_dynamicformfs_wc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short A207WWPFormVersionNumber ;
      private short A206WWPFormId ;
      private short wbEnd ;
      private short wbStart ;
      private short AV5SessionId ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short A216WWPFormResume ;
      private short AV15WWPFormResume ;
      private short nGXWrapped ;
      private int AV9WWPFormInstanceId ;
      private int wcpOAV9WWPFormInstanceId ;
      private int bttBtnenter_Visible ;
      private int bttBtncancel_Visible ;
      private int bttBtnuaresume_Visible ;
      private int edtavSessionid_Visible ;
      private int AV33GXV1 ;
      private int idxLst ;
      private string AV8WWPDynamicFormMode ;
      private string wcpOAV8WWPDynamicFormMode ;
      private string Dvelop_confirmpanel_uaresume_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Ddc_useractiondiscussion_Icontype ;
      private string Ddc_useractiondiscussion_Icon ;
      private string Dvelop_confirmpanel_uaresume_Title ;
      private string Dvelop_confirmpanel_uaresume_Confirmationtext ;
      private string Dvelop_confirmpanel_uaresume_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_uaresume_Nobuttoncaption ;
      private string Dvelop_confirmpanel_uaresume_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_uaresume_Yesbuttonposition ;
      private string Dvelop_confirmpanel_uaresume_Confirmtype ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string divTablemain_Class ;
      private string ClassString ;
      private string StyleString ;
      private string divUnnamedtable1_Internalname ;
      private string lblResidentname_Internalname ;
      private string lblResidentname_Caption ;
      private string lblResidentname_Jsonclick ;
      private string divTableright_Internalname ;
      private string Ddc_useractiondiscussion_Caption ;
      private string Ddc_useractiondiscussion_Internalname ;
      private string divTablecontent_Internalname ;
      private string WebComp_Wcwwp_dynamicformfs_wc_Component ;
      private string OldWcwwp_dynamicformfs_wc ;
      private string TempTags ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string bttBtnuaresume_Internalname ;
      private string bttBtnuaresume_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavSessionid_Internalname ;
      private string edtavSessionid_Jsonclick ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string Dvelop_confirmpanel_uaresume_Internalname ;
      private string GXt_char1 ;
      private string sStyleString ;
      private string tblTabledvelop_confirmpanel_uaresume_Internalname ;
      private bool AV29isLinkingDiscussion ;
      private bool wcpOAV29isLinkingDiscussion ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool A232WWPFormIsWizard ;
      private bool AV23ExecuteEnterEvent ;
      private bool AV11WWPFormIsWizard ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool BRK1Z3 ;
      private bool AV17Resuming ;
      private bool AV16AllowResumingDeprecatedFormVersion ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool AV20HasErrors ;
      private bool bDynCreated_Wcwwp_dynamicformfs_wc ;
      private string A235WWPFormResumeMessage ;
      private string AV18WWPFormResumeMessage ;
      private string AV14WWPFormReferenceName ;
      private string wcpOAV14WWPFormReferenceName ;
      private string A208WWPFormReferenceName ;
      private string A209WWPFormTitle ;
      private string AV22DefaultStep ;
      private string AV13ErrorIds ;
      private GXWebComponent WebComp_Wcwwp_dynamicformfs_wc ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXUserControl ucDdc_useractiondiscussion ;
      private GXUserControl ucDvelop_confirmpanel_uaresume ;
      private GxHttpRequest AV10HttpRequest ;
      private IGxSession AV6WebSession ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV7WWPFormInstance ;
      private IDataStoreProvider pr_default ;
      private short[] H001Z2_A207WWPFormVersionNumber ;
      private short[] H001Z2_A206WWPFormId ;
      private string[] H001Z2_A208WWPFormReferenceName ;
      private short[] H001Z2_A216WWPFormResume ;
      private string[] H001Z2_A235WWPFormResumeMessage ;
      private string[] H001Z3_A208WWPFormReferenceName ;
      private short[] H001Z3_A206WWPFormId ;
      private short[] H001Z3_A207WWPFormVersionNumber ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance GXt_SdtWWP_FormInstance2 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV21Messages ;
      private GeneXus.Utils.SdtMessages_Message AV19Message ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV12WWPForm ;
      private short[] H001Z4_A207WWPFormVersionNumber ;
      private short[] H001Z4_A206WWPFormId ;
      private bool[] H001Z4_A232WWPFormIsWizard ;
      private string[] H001Z4_A209WWPFormTitle ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_dynamicform__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_dynamicform__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_dynamicform__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new ForEachCursor(def[2])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmH001Z2;
       prmH001Z2 = new Object[] {
       };
       Object[] prmH001Z3;
       prmH001Z3 = new Object[] {
       new ParDef("AV14WWPFormReferenceName",GXType.VarChar,100,0)
       };
       Object[] prmH001Z4;
       prmH001Z4 = new Object[] {
       new ParDef("AV7WWPFormInstance__Wwpformid",GXType.Int16,4,0) ,
       new ParDef("AV7WWPFo_1Wwpformversionnumbe",GXType.Int16,4,0)
       };
       def= new CursorDef[] {
           new CursorDef("H001Z2", "SELECT WWPFormVersionNumber, WWPFormId, WWPFormReferenceName, WWPFormResume, WWPFormResumeMessage FROM WWP_Form ORDER BY WWPFormId DESC, WWPFormVersionNumber DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001Z2,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H001Z3", "SELECT WWPFormReferenceName, WWPFormId, WWPFormVersionNumber FROM WWP_Form WHERE WWPFormReferenceName = ( :AV14WWPFormReferenceName) ORDER BY WWPFormReferenceName, WWPFormVersionNumber DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001Z3,1, GxCacheFrequency.OFF ,false,true )
          ,new CursorDef("H001Z4", "SELECT WWPFormVersionNumber, WWPFormId, WWPFormIsWizard, WWPFormTitle FROM WWP_Form WHERE WWPFormId = :AV7WWPFormInstance__Wwpformid and WWPFormVersionNumber = :AV7WWPFo_1Wwpformversionnumbe ORDER BY WWPFormId, WWPFormVersionNumber ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001Z4,1, GxCacheFrequency.OFF ,false,true )
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
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             return;
          case 1 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             return;
          case 2 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
    }
 }

}

}
