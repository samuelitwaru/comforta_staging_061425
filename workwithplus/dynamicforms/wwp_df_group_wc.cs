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
   public class wwp_df_group_wc : GXWebComponent
   {
      public wwp_df_group_wc( )
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

      public wwp_df_group_wc( IGxContext context )
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
         this.AV8WWPDynamicFormMode = aP0_WWPDynamicFormMode;
         this.AV9WWPFormElementId = aP1_WWPFormElementId;
         this.AV11WWPFormInstanceElementId = aP2_WWPFormInstanceElementId;
         this.AV6SessionId = aP3_SessionId;
         this.AV10WWPFormInstance = aP4_WWPFormInstance;
         ExecuteImpl();
         aP4_WWPFormInstance=this.AV10WWPFormInstance;
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
                  AV8WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
                  AssignAttri(sPrefix, false, "AV8WWPDynamicFormMode", AV8WWPDynamicFormMode);
                  AV9WWPFormElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV9WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV9WWPFormElementId), 4, 0));
                  AV11WWPFormInstanceElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormInstanceElementId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV11WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV11WWPFormInstanceElementId), 4, 0));
                  AV6SessionId = (short)(Math.Round(NumberUtil.Val( GetPar( "SessionId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV6SessionId", StringUtil.LTrimStr( (decimal)(AV6SessionId), 4, 0));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV10WWPFormInstance);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV8WWPDynamicFormMode,(short)AV9WWPFormElementId,(short)AV11WWPFormInstanceElementId,(short)AV6SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV10WWPFormInstance});
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
            PA2A2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS2A2( ) ;
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
            context.SendWebValue( context.GetMessage( "WWP_Dynamic Form_Group_WC", "")) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_df_group_wc.aspx"+UrlEncode(StringUtil.RTrim(AV8WWPDynamicFormMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV9WWPFormElementId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV11WWPFormInstanceElementId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV6SessionId,4,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.dynamicforms.wwp_df_group_wc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_GROUPMETADATA", AV7WWP_DF_GroupMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_GROUPMETADATA", AV7WWP_DF_GroupMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_GROUPMETADATA", GetSecureSignedToken( sPrefix, AV7WWP_DF_GroupMetadata, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8WWPDynamicFormMode", StringUtil.RTrim( wcpOAV8WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV9WWPFormElementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV9WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV11WWPFormInstanceElementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV11WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6SessionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV6SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vAUXSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5AuxSessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_GROUPMETADATA", AV7WWP_DF_GroupMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_GROUPMETADATA", AV7WWP_DF_GroupMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_GROUPMETADATA", GetSecureSignedToken( sPrefix, AV7WWP_DF_GroupMetadata, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMINSTANCEELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV8WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORMINSTANCE", AV10WWPFormInstance);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORMINSTANCE", AV10WWPFormInstance);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLECONTENT_Width", StringUtil.RTrim( Dvpanel_tablecontent_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLECONTENT_Autowidth", StringUtil.BoolToStr( Dvpanel_tablecontent_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLECONTENT_Autoheight", StringUtil.BoolToStr( Dvpanel_tablecontent_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLECONTENT_Cls", StringUtil.RTrim( Dvpanel_tablecontent_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLECONTENT_Title", StringUtil.RTrim( Dvpanel_tablecontent_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLECONTENT_Collapsible", StringUtil.BoolToStr( Dvpanel_tablecontent_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLECONTENT_Collapsed", StringUtil.BoolToStr( Dvpanel_tablecontent_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLECONTENT_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablecontent_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLECONTENT_Iconposition", StringUtil.RTrim( Dvpanel_tablecontent_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLECONTENT_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablecontent_Autoscroll));
      }

      protected void RenderHtmlCloseForm2A2( )
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
            if ( ! ( WebComp_Wcchildren == null ) )
            {
               WebComp_Wcchildren.componentjscripts();
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
         return "WorkWithPlus.DynamicForms.WWP_DF_Group_WC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WWP_Dynamic Form_Group_WC", "") ;
      }

      protected void WB2A0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "workwithplus.dynamicforms.wwp_df_group_wc.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginBottom15", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablecontent.SetProperty("Width", Dvpanel_tablecontent_Width);
            ucDvpanel_tablecontent.SetProperty("AutoWidth", Dvpanel_tablecontent_Autowidth);
            ucDvpanel_tablecontent.SetProperty("AutoHeight", Dvpanel_tablecontent_Autoheight);
            ucDvpanel_tablecontent.SetProperty("Cls", Dvpanel_tablecontent_Cls);
            ucDvpanel_tablecontent.SetProperty("Title", Dvpanel_tablecontent_Title);
            ucDvpanel_tablecontent.SetProperty("Collapsible", Dvpanel_tablecontent_Collapsible);
            ucDvpanel_tablecontent.SetProperty("Collapsed", Dvpanel_tablecontent_Collapsed);
            ucDvpanel_tablecontent.SetProperty("ShowCollapseIcon", Dvpanel_tablecontent_Showcollapseicon);
            ucDvpanel_tablecontent.SetProperty("IconPosition", Dvpanel_tablecontent_Iconposition);
            ucDvpanel_tablecontent.SetProperty("AutoScroll", Dvpanel_tablecontent_Autoscroll);
            ucDvpanel_tablecontent.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablecontent_Internalname, sPrefix+"DVPANEL_TABLECONTENTContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_TABLECONTENTContainer"+"TableContent"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, sPrefix+"W0014"+"", StringUtil.RTrim( WebComp_Wcchildren_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0014"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcchildren), StringUtil.Lower( WebComp_Wcchildren_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0014"+"");
                  }
                  WebComp_Wcchildren.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcchildren), StringUtil.Lower( WebComp_Wcchildren_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
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

      protected void START2A2( )
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
            Form.Meta.addItem("description", context.GetMessage( "WWP_Dynamic Form_Group_WC", ""), 0) ;
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
               STRUP2A0( ) ;
            }
         }
      }

      protected void WS2A2( )
      {
         START2A2( ) ;
         EVT2A2( ) ;
      }

      protected void EVT2A2( )
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
                                 STRUP2A0( ) ;
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
                                 STRUP2A0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E112A2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2A0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E122A2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2A0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E132A2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2A0( ) ;
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
                                 STRUP2A0( ) ;
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
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 14 )
                        {
                           OldWcchildren = cgiGet( sPrefix+"W0014");
                           if ( ( StringUtil.Len( OldWcchildren) == 0 ) || ( StringUtil.StrCmp(OldWcchildren, WebComp_Wcchildren_Component) != 0 ) )
                           {
                              WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", OldWcchildren, new Object[] {context} );
                              WebComp_Wcchildren.ComponentInit();
                              WebComp_Wcchildren.Name = "OldWcchildren";
                              WebComp_Wcchildren_Component = OldWcchildren;
                           }
                           if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                           {
                              WebComp_Wcchildren.componentprocess(sPrefix+"W0014", "", sEvt);
                           }
                           WebComp_Wcchildren_Component = OldWcchildren;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE2A2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2A2( ) ;
            }
         }
      }

      protected void PA2A2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.dynamicforms.wwp_df_group_wc.aspx")), "workwithplus.dynamicforms.wwp_df_group_wc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.dynamicforms.wwp_df_group_wc.aspx")))) ;
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
         RF2A2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF2A2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
               {
                  WebComp_Wcchildren.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E132A2 ();
            WB2A0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2A2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_GROUPMETADATA", AV7WWP_DF_GroupMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_GROUPMETADATA", AV7WWP_DF_GroupMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_GROUPMETADATA", GetSecureSignedToken( sPrefix, AV7WWP_DF_GroupMetadata, context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2A0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E112A2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOAV8WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV8WWPDynamicFormMode");
            wcpOAV9WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV9WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV11WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV11WWPFormInstanceElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV6SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Dvpanel_tablecontent_Width = cgiGet( sPrefix+"DVPANEL_TABLECONTENT_Width");
            Dvpanel_tablecontent_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLECONTENT_Autowidth"));
            Dvpanel_tablecontent_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLECONTENT_Autoheight"));
            Dvpanel_tablecontent_Cls = cgiGet( sPrefix+"DVPANEL_TABLECONTENT_Cls");
            Dvpanel_tablecontent_Title = cgiGet( sPrefix+"DVPANEL_TABLECONTENT_Title");
            Dvpanel_tablecontent_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLECONTENT_Collapsible"));
            Dvpanel_tablecontent_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLECONTENT_Collapsed"));
            Dvpanel_tablecontent_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLECONTENT_Showcollapseicon"));
            Dvpanel_tablecontent_Iconposition = cgiGet( sPrefix+"DVPANEL_TABLECONTENT_Iconposition");
            Dvpanel_tablecontent_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLECONTENT_Autoscroll"));
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
         E112A2 ();
         if (returnInSub) return;
      }

      protected void E112A2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Using cursor H002A2 */
         pr_default.execute(0, new Object[] {AV10WWPFormInstance.gxTpr_Wwpformid, AV10WWPFormInstance.gxTpr_Wwpformversionnumber, AV9WWPFormElementId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A210WWPFormElementId = H002A2_A210WWPFormElementId[0];
            A207WWPFormVersionNumber = H002A2_A207WWPFormVersionNumber[0];
            A206WWPFormId = H002A2_A206WWPFormId[0];
            A229WWPFormElementTitle = H002A2_A229WWPFormElementTitle[0];
            A236WWPFormElementMetadata = H002A2_A236WWPFormElementMetadata[0];
            Dvpanel_tablecontent_Title = A229WWPFormElementTitle;
            ucDvpanel_tablecontent.SendProperty(context, sPrefix, false, Dvpanel_tablecontent_Internalname, "Title", Dvpanel_tablecontent_Title);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A229WWPFormElementTitle)) )
            {
               Dvpanel_tablecontent_Cls = "PanelNoHeader";
               ucDvpanel_tablecontent.SendProperty(context, sPrefix, false, Dvpanel_tablecontent_Internalname, "Cls", Dvpanel_tablecontent_Cls);
            }
            else
            {
               Dvpanel_tablecontent_Title = A229WWPFormElementTitle;
               ucDvpanel_tablecontent.SendProperty(context, sPrefix, false, Dvpanel_tablecontent_Internalname, "Title", Dvpanel_tablecontent_Title);
            }
            AV7WWP_DF_GroupMetadata.FromJSonString(A236WWPFormElementMetadata, null);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Object Property */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            bDynCreated_Wcchildren = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_FS_WC")) != 0 )
         {
            WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_fs_wc", new Object[] {context} );
            WebComp_Wcchildren.ComponentInit();
            WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_FS_WC";
            WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_FS_WC";
         }
         if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
         {
            WebComp_Wcchildren.setjustcreated();
            WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0014",(string)"",(string)AV8WWPDynamicFormMode,(short)AV9WWPFormElementId,(short)AV11WWPFormInstanceElementId,(short)AV6SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV10WWPFormInstance});
            WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
         }
         if ( AV7WWP_DF_GroupMetadata.gxTpr_Style == 2 )
         {
            Dvpanel_tablecontent_Collapsible = AV7WWP_DF_GroupMetadata.gxTpr_Collapsable;
            ucDvpanel_tablecontent.SendProperty(context, sPrefix, false, Dvpanel_tablecontent_Internalname, "Collapsible", StringUtil.BoolToStr( Dvpanel_tablecontent_Collapsible));
            Dvpanel_tablecontent_Collapsed = AV7WWP_DF_GroupMetadata.gxTpr_Collapsedbydefault;
            ucDvpanel_tablecontent.SendProperty(context, sPrefix, false, Dvpanel_tablecontent_Internalname, "Collapsed", StringUtil.BoolToStr( Dvpanel_tablecontent_Collapsed));
         }
         else
         {
            Dvpanel_tablecontent_Cls = "PanelNoHeader";
            ucDvpanel_tablecontent.SendProperty(context, sPrefix, false, Dvpanel_tablecontent_Internalname, "Cls", Dvpanel_tablecontent_Cls);
         }
         /* Execute user subroutine: 'UPDATE VISIBILITY' */
         S112 ();
         if (returnInSub) return;
      }

      protected void E122A2( )
      {
         /* General\GlobalEvents_Dynamicform_updatevisibilities Routine */
         returnInSub = false;
         if ( ( AV5AuxSessionId == AV6SessionId ) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV7WWP_DF_GroupMetadata.gxTpr_Visiblecondition.gxTpr_Expression))) )
         {
            GXt_SdtWWP_FormInstance1 = AV10WWPFormInstance;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadforminstance(context ).execute(  AV6SessionId, out  GXt_SdtWWP_FormInstance1) ;
            AV10WWPFormInstance = GXt_SdtWWP_FormInstance1;
            /* Execute user subroutine: 'UPDATE VISIBILITY' */
            S112 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10WWPFormInstance", AV10WWPFormInstance);
      }

      protected void S112( )
      {
         /* 'UPDATE VISIBILITY' Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV7WWP_DF_GroupMetadata.gxTpr_Visiblecondition.gxTpr_Expression))) )
         {
            GXt_SdtWWP_FormInstance1 = AV10WWPFormInstance;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadforminstance(context ).execute(  AV6SessionId, out  GXt_SdtWWP_FormInstance1) ;
            AV10WWPFormInstance = GXt_SdtWWP_FormInstance1;
            if ( new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_evaluateelementvisibility(context).executeUdp(  AV10WWPFormInstance,  AV11WWPFormInstanceElementId,  AV7WWP_DF_GroupMetadata.gxTpr_Visiblecondition) )
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
      }

      protected void nextLoad( )
      {
      }

      protected void E132A2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8WWPDynamicFormMode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV8WWPDynamicFormMode", AV8WWPDynamicFormMode);
         AV9WWPFormElementId = Convert.ToInt16(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV9WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV9WWPFormElementId), 4, 0));
         AV11WWPFormInstanceElementId = Convert.ToInt16(getParm(obj,2));
         AssignAttri(sPrefix, false, "AV11WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV11WWPFormInstanceElementId), 4, 0));
         AV6SessionId = Convert.ToInt16(getParm(obj,3));
         AssignAttri(sPrefix, false, "AV6SessionId", StringUtil.LTrimStr( (decimal)(AV6SessionId), 4, 0));
         AV10WWPFormInstance = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)getParm(obj,4);
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
         PA2A2( ) ;
         WS2A2( ) ;
         WE2A2( ) ;
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
         sCtrlAV8WWPDynamicFormMode = (string)((string)getParm(obj,0));
         sCtrlAV9WWPFormElementId = (string)((string)getParm(obj,1));
         sCtrlAV11WWPFormInstanceElementId = (string)((string)getParm(obj,2));
         sCtrlAV6SessionId = (string)((string)getParm(obj,3));
         sCtrlAV10WWPFormInstance = (string)((string)getParm(obj,4));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2A2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "workwithplus\\dynamicforms\\wwp_df_group_wc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2A2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV8WWPDynamicFormMode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV8WWPDynamicFormMode", AV8WWPDynamicFormMode);
            AV9WWPFormElementId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV9WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV9WWPFormElementId), 4, 0));
            AV11WWPFormInstanceElementId = Convert.ToInt16(getParm(obj,4));
            AssignAttri(sPrefix, false, "AV11WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV11WWPFormInstanceElementId), 4, 0));
            AV6SessionId = Convert.ToInt16(getParm(obj,5));
            AssignAttri(sPrefix, false, "AV6SessionId", StringUtil.LTrimStr( (decimal)(AV6SessionId), 4, 0));
            AV10WWPFormInstance = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)getParm(obj,6);
         }
         wcpOAV8WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV8WWPDynamicFormMode");
         wcpOAV9WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV9WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV11WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV11WWPFormInstanceElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV6SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV8WWPDynamicFormMode, wcpOAV8WWPDynamicFormMode) != 0 ) || ( AV9WWPFormElementId != wcpOAV9WWPFormElementId ) || ( AV11WWPFormInstanceElementId != wcpOAV11WWPFormInstanceElementId ) || ( AV6SessionId != wcpOAV6SessionId ) ) )
         {
            setjustcreated();
         }
         wcpOAV8WWPDynamicFormMode = AV8WWPDynamicFormMode;
         wcpOAV9WWPFormElementId = AV9WWPFormElementId;
         wcpOAV11WWPFormInstanceElementId = AV11WWPFormInstanceElementId;
         wcpOAV6SessionId = AV6SessionId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV8WWPDynamicFormMode = cgiGet( sPrefix+"AV8WWPDynamicFormMode_CTRL");
         if ( StringUtil.Len( sCtrlAV8WWPDynamicFormMode) > 0 )
         {
            AV8WWPDynamicFormMode = cgiGet( sCtrlAV8WWPDynamicFormMode);
            AssignAttri(sPrefix, false, "AV8WWPDynamicFormMode", AV8WWPDynamicFormMode);
         }
         else
         {
            AV8WWPDynamicFormMode = cgiGet( sPrefix+"AV8WWPDynamicFormMode_PARM");
         }
         sCtrlAV9WWPFormElementId = cgiGet( sPrefix+"AV9WWPFormElementId_CTRL");
         if ( StringUtil.Len( sCtrlAV9WWPFormElementId) > 0 )
         {
            AV9WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV9WWPFormElementId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV9WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV9WWPFormElementId), 4, 0));
         }
         else
         {
            AV9WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV9WWPFormElementId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV11WWPFormInstanceElementId = cgiGet( sPrefix+"AV11WWPFormInstanceElementId_CTRL");
         if ( StringUtil.Len( sCtrlAV11WWPFormInstanceElementId) > 0 )
         {
            AV11WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV11WWPFormInstanceElementId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV11WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV11WWPFormInstanceElementId), 4, 0));
         }
         else
         {
            AV11WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV11WWPFormInstanceElementId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV6SessionId = cgiGet( sPrefix+"AV6SessionId_CTRL");
         if ( StringUtil.Len( sCtrlAV6SessionId) > 0 )
         {
            AV6SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV6SessionId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV6SessionId", StringUtil.LTrimStr( (decimal)(AV6SessionId), 4, 0));
         }
         else
         {
            AV6SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV6SessionId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV10WWPFormInstance = cgiGet( sPrefix+"AV10WWPFormInstance_CTRL");
         if ( StringUtil.Len( sCtrlAV10WWPFormInstance) > 0 )
         {
            AV10WWPFormInstance.FromXml(cgiGet( sCtrlAV10WWPFormInstance), null, "", "");
         }
         else
         {
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"AV10WWPFormInstance_PARM"), AV10WWPFormInstance);
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
         PA2A2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2A2( ) ;
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
         WS2A2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8WWPDynamicFormMode_PARM", StringUtil.RTrim( AV8WWPDynamicFormMode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8WWPDynamicFormMode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8WWPDynamicFormMode_CTRL", StringUtil.RTrim( sCtrlAV8WWPDynamicFormMode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV9WWPFormElementId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV9WWPFormElementId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV9WWPFormElementId_CTRL", StringUtil.RTrim( sCtrlAV9WWPFormElementId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV11WWPFormInstanceElementId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV11WWPFormInstanceElementId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV11WWPFormInstanceElementId_CTRL", StringUtil.RTrim( sCtrlAV11WWPFormInstanceElementId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6SessionId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6SessionId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6SessionId_CTRL", StringUtil.RTrim( sCtrlAV6SessionId));
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"AV10WWPFormInstance_PARM", AV10WWPFormInstance);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"AV10WWPFormInstance_PARM", AV10WWPFormInstance);
         }
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV10WWPFormInstance)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV10WWPFormInstance_CTRL", StringUtil.RTrim( sCtrlAV10WWPFormInstance));
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
         WE2A2( ) ;
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
         if ( ! ( WebComp_Wcchildren == null ) )
         {
            WebComp_Wcchildren.componentjscripts();
         }
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wcchildren == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
            {
               WebComp_Wcchildren.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20257212432750", true, true);
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
         context.AddJavascriptSource("workwithplus/dynamicforms/wwp_df_group_wc.js", "?20257212432750", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         Dvpanel_tablecontent_Internalname = sPrefix+"DVPANEL_TABLECONTENT";
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
         divLayoutmaintable_Class = "Table";
         Dvpanel_tablecontent_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablecontent_Iconposition = "Right";
         Dvpanel_tablecontent_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablecontent_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablecontent_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tablecontent_Title = context.GetMessage( "Title", "");
         Dvpanel_tablecontent_Cls = "PanelWithBorder Panel_BaseColor";
         Dvpanel_tablecontent_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablecontent_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablecontent_Width = "100%";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV7WWP_DF_GroupMetadata","fld":"vWWP_DF_GROUPMETADATA","hsh":true}]}""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES","""{"handler":"E122A2","iparms":[{"av":"AV5AuxSessionId","fld":"vAUXSESSIONID","pic":"ZZZ9"},{"av":"AV6SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV7WWP_DF_GroupMetadata","fld":"vWWP_DF_GROUPMETADATA","hsh":true},{"av":"AV11WWPFormInstanceElementId","fld":"vWWPFORMINSTANCEELEMENTID","pic":"ZZZ9"}]""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES",""","oparms":[{"av":"AV10WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"divLayoutmaintable_Class","ctrl":"LAYOUTMAINTABLE","prop":"Class"}]}""");
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
         AV10WWPFormInstance = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         wcpOAV8WWPDynamicFormMode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV7WWP_DF_GroupMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ContainerMetadata(context);
         GX_FocusControl = "";
         ucDvpanel_tablecontent = new GXUserControl();
         WebComp_Wcchildren_Component = "";
         OldWcchildren = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H002A2_A210WWPFormElementId = new short[1] ;
         H002A2_A207WWPFormVersionNumber = new short[1] ;
         H002A2_A206WWPFormId = new short[1] ;
         H002A2_A229WWPFormElementTitle = new string[] {""} ;
         H002A2_A236WWPFormElementMetadata = new string[] {""} ;
         A229WWPFormElementTitle = "";
         A236WWPFormElementMetadata = "";
         GXt_SdtWWP_FormInstance1 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV8WWPDynamicFormMode = "";
         sCtrlAV9WWPFormElementId = "";
         sCtrlAV11WWPFormInstanceElementId = "";
         sCtrlAV6SessionId = "";
         sCtrlAV10WWPFormInstance = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_group_wc__default(),
            new Object[][] {
                new Object[] {
               H002A2_A210WWPFormElementId, H002A2_A207WWPFormVersionNumber, H002A2_A206WWPFormId, H002A2_A229WWPFormElementTitle, H002A2_A236WWPFormElementMetadata
               }
            }
         );
         WebComp_Wcchildren = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short AV9WWPFormElementId ;
      private short AV11WWPFormInstanceElementId ;
      private short AV6SessionId ;
      private short wcpOAV9WWPFormElementId ;
      private short wcpOAV11WWPFormInstanceElementId ;
      private short wcpOAV6SessionId ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV5AuxSessionId ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short A210WWPFormElementId ;
      private short A207WWPFormVersionNumber ;
      private short A206WWPFormId ;
      private short nGXWrapped ;
      private int idxLst ;
      private string AV8WWPDynamicFormMode ;
      private string wcpOAV8WWPDynamicFormMode ;
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
      private string Dvpanel_tablecontent_Width ;
      private string Dvpanel_tablecontent_Cls ;
      private string Dvpanel_tablecontent_Title ;
      private string Dvpanel_tablecontent_Iconposition ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string Dvpanel_tablecontent_Internalname ;
      private string divTablecontent_Internalname ;
      private string WebComp_Wcchildren_Component ;
      private string OldWcchildren ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string sCtrlAV8WWPDynamicFormMode ;
      private string sCtrlAV9WWPFormElementId ;
      private string sCtrlAV11WWPFormInstanceElementId ;
      private string sCtrlAV6SessionId ;
      private string sCtrlAV10WWPFormInstance ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_tablecontent_Autowidth ;
      private bool Dvpanel_tablecontent_Autoheight ;
      private bool Dvpanel_tablecontent_Collapsible ;
      private bool Dvpanel_tablecontent_Collapsed ;
      private bool Dvpanel_tablecontent_Showcollapseicon ;
      private bool Dvpanel_tablecontent_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Wcchildren ;
      private string A229WWPFormElementTitle ;
      private string A236WWPFormElementMetadata ;
      private GXWebComponent WebComp_Wcchildren ;
      private GXUserControl ucDvpanel_tablecontent ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV10WWPFormInstance ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP4_WWPFormInstance ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ContainerMetadata AV7WWP_DF_GroupMetadata ;
      private IDataStoreProvider pr_default ;
      private short[] H002A2_A210WWPFormElementId ;
      private short[] H002A2_A207WWPFormVersionNumber ;
      private short[] H002A2_A206WWPFormId ;
      private string[] H002A2_A229WWPFormElementTitle ;
      private string[] H002A2_A236WWPFormElementMetadata ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance GXt_SdtWWP_FormInstance1 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wwp_df_group_wc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH002A2;
          prmH002A2 = new Object[] {
          new ParDef("AV10WWPF_2Wwpformid",GXType.Int16,4,0) ,
          new ParDef("AV10WWPF_1Wwpformversionnumbe",GXType.Int16,4,0) ,
          new ParDef("AV9WWPFormElementId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002A2", "SELECT WWPFormElementId, WWPFormVersionNumber, WWPFormId, WWPFormElementTitle, WWPFormElementMetadata FROM WWP_FormElement WHERE WWPFormId = :AV10WWPF_2Wwpformid and WWPFormVersionNumber = :AV10WWPF_1Wwpformversionnumbe and WWPFormElementId = :AV9WWPFormElementId ORDER BY WWPFormId, WWPFormVersionNumber, WWPFormElementId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002A2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                return;
       }
    }

 }

}
