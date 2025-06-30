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
   public class wwp_dfc_group_wc : GXWebComponent
   {
      public wwp_dfc_group_wc( )
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

      public wwp_dfc_group_wc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPDynamicFormMode ,
                           short aP1_WWPFormElementId ,
                           short aP2_SessionId ,
                           ref GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP3_WWPForm )
      {
         this.AV7WWPDynamicFormMode = aP0_WWPDynamicFormMode;
         this.AV10WWPFormElementId = aP1_WWPFormElementId;
         this.AV5SessionId = aP2_SessionId;
         this.AV8WWPForm = aP3_WWPForm;
         ExecuteImpl();
         aP3_WWPForm=this.AV8WWPForm;
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
                  AV7WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
                  AssignAttri(sPrefix, false, "AV7WWPDynamicFormMode", AV7WWPDynamicFormMode);
                  AV10WWPFormElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV10WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV10WWPFormElementId), 4, 0));
                  AV5SessionId = (short)(Math.Round(NumberUtil.Val( GetPar( "SessionId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV5SessionId", StringUtil.LTrimStr( (decimal)(AV5SessionId), 4, 0));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV8WWPForm);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV7WWPDynamicFormMode,(short)AV10WWPFormElementId,(short)AV5SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV8WWPForm});
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
            PA352( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS352( ) ;
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
            context.SendWebValue( context.GetMessage( "WWP_Dynamic Form Creation_Group_WC", "")) ;
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
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_dfc_group_wc.aspx"+UrlEncode(StringUtil.RTrim(AV7WWPDynamicFormMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV10WWPFormElementId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV5SessionId,4,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.dynamicforms.wwp_dfc_group_wc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7WWPDynamicFormMode", StringUtil.RTrim( wcpOAV7WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV10WWPFormElementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV10WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV5SessionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV5SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV7WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORM", AV8WWPForm);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORM", AV8WWPForm);
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

      protected void RenderHtmlCloseForm352( )
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
            if ( ! ( WebComp_Wcwwp_dfc_fs_wc == null ) )
            {
               WebComp_Wcwwp_dfc_fs_wc.componentjscripts();
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
         return "WorkWithPlus.DynamicForms.WWP_DFC_Group_WC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WWP_Dynamic Form Creation_Group_WC", "") ;
      }

      protected void WB350( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "workwithplus.dynamicforms.wwp_dfc_group_wc.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
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
               GxWebStd.gx_hidden_field( context, sPrefix+"W0014"+"", StringUtil.RTrim( WebComp_Wcwwp_dfc_fs_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0014"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcwwp_dfc_fs_wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwwp_dfc_fs_wc), StringUtil.Lower( WebComp_Wcwwp_dfc_fs_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0014"+"");
                  }
                  WebComp_Wcwwp_dfc_fs_wc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwwp_dfc_fs_wc), StringUtil.Lower( WebComp_Wcwwp_dfc_fs_wc_Component)) != 0 )
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

      protected void START352( )
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
            Form.Meta.addItem("description", context.GetMessage( "WWP_Dynamic Form Creation_Group_WC", ""), 0) ;
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
               STRUP350( ) ;
            }
         }
      }

      protected void WS352( )
      {
         START352( ) ;
         EVT352( ) ;
      }

      protected void EVT352( )
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
                                 STRUP350( ) ;
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
                                 STRUP350( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11352 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP350( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E12352 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP350( ) ;
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
                                 STRUP350( ) ;
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
                           OldWcwwp_dfc_fs_wc = cgiGet( sPrefix+"W0014");
                           if ( ( StringUtil.Len( OldWcwwp_dfc_fs_wc) == 0 ) || ( StringUtil.StrCmp(OldWcwwp_dfc_fs_wc, WebComp_Wcwwp_dfc_fs_wc_Component) != 0 ) )
                           {
                              WebComp_Wcwwp_dfc_fs_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWcwwp_dfc_fs_wc, new Object[] {context} );
                              WebComp_Wcwwp_dfc_fs_wc.ComponentInit();
                              WebComp_Wcwwp_dfc_fs_wc.Name = "OldWcwwp_dfc_fs_wc";
                              WebComp_Wcwwp_dfc_fs_wc_Component = OldWcwwp_dfc_fs_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wcwwp_dfc_fs_wc_Component) != 0 )
                           {
                              WebComp_Wcwwp_dfc_fs_wc.componentprocess(sPrefix+"W0014", "", sEvt);
                           }
                           WebComp_Wcwwp_dfc_fs_wc_Component = OldWcwwp_dfc_fs_wc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE352( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm352( ) ;
            }
         }
      }

      protected void PA352( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.dynamicforms.wwp_dfc_group_wc.aspx")), "workwithplus.dynamicforms.wwp_dfc_group_wc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.dynamicforms.wwp_dfc_group_wc.aspx")))) ;
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
         RF352( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF352( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcwwp_dfc_fs_wc_Component) != 0 )
               {
                  WebComp_Wcwwp_dfc_fs_wc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E12352 ();
            WB350( ) ;
         }
      }

      protected void send_integrity_lvl_hashes352( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP350( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11352 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOAV7WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV7WWPDynamicFormMode");
            wcpOAV10WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV10WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV5SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV5SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         E11352 ();
         if (returnInSub) return;
      }

      protected void E11352( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtWWP_Form_Element1 = AV9WWPFormElement;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getelementbyid(context ).execute( ref  AV8WWPForm,  AV10WWPFormElementId, out  GXt_SdtWWP_Form_Element1) ;
         AV9WWPFormElement = GXt_SdtWWP_Form_Element1;
         /* Execute user subroutine: 'LOAD TITLE AND METADATA' */
         S112 ();
         if (returnInSub) return;
         /* Object Property */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            bDynCreated_Wcwwp_dfc_fs_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwwp_dfc_fs_wc_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_FS_WC")) != 0 )
         {
            WebComp_Wcwwp_dfc_fs_wc = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_fs_wc", new Object[] {context} );
            WebComp_Wcwwp_dfc_fs_wc.ComponentInit();
            WebComp_Wcwwp_dfc_fs_wc.Name = "WorkWithPlus.DynamicForms.WWP_DFC_FS_WC";
            WebComp_Wcwwp_dfc_fs_wc_Component = "WorkWithPlus.DynamicForms.WWP_DFC_FS_WC";
         }
         if ( StringUtil.Len( WebComp_Wcwwp_dfc_fs_wc_Component) != 0 )
         {
            WebComp_Wcwwp_dfc_fs_wc.setjustcreated();
            WebComp_Wcwwp_dfc_fs_wc.componentprepare(new Object[] {(string)sPrefix+"W0014",(string)"",(string)AV7WWPDynamicFormMode,(short)AV10WWPFormElementId,(short)AV5SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV8WWPForm});
            WebComp_Wcwwp_dfc_fs_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
      }

      protected void S112( )
      {
         /* 'LOAD TITLE AND METADATA' Routine */
         returnInSub = false;
         AV6WWP_DF_GroupMetadata.FromJSonString(AV9WWPFormElement.gxTpr_Wwpformelementmetadata, null);
         if ( AV6WWP_DF_GroupMetadata.gxTpr_Style == 2 )
         {
            Dvpanel_tablecontent_Title = AV9WWPFormElement.gxTpr_Wwpformelementtitle;
            ucDvpanel_tablecontent.SendProperty(context, sPrefix, false, Dvpanel_tablecontent_Internalname, "Title", Dvpanel_tablecontent_Title);
            Dvpanel_tablecontent_Collapsible = AV6WWP_DF_GroupMetadata.gxTpr_Collapsable;
            ucDvpanel_tablecontent.SendProperty(context, sPrefix, false, Dvpanel_tablecontent_Internalname, "Collapsible", StringUtil.BoolToStr( Dvpanel_tablecontent_Collapsible));
            Dvpanel_tablecontent_Collapsed = AV6WWP_DF_GroupMetadata.gxTpr_Collapsedbydefault;
            ucDvpanel_tablecontent.SendProperty(context, sPrefix, false, Dvpanel_tablecontent_Internalname, "Collapsed", StringUtil.BoolToStr( Dvpanel_tablecontent_Collapsed));
         }
         else
         {
            Dvpanel_tablecontent_Cls = "PanelNoHeader";
            ucDvpanel_tablecontent.SendProperty(context, sPrefix, false, Dvpanel_tablecontent_Internalname, "Cls", Dvpanel_tablecontent_Cls);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E12352( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV7WWPDynamicFormMode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV7WWPDynamicFormMode", AV7WWPDynamicFormMode);
         AV10WWPFormElementId = Convert.ToInt16(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV10WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV10WWPFormElementId), 4, 0));
         AV5SessionId = Convert.ToInt16(getParm(obj,2));
         AssignAttri(sPrefix, false, "AV5SessionId", StringUtil.LTrimStr( (decimal)(AV5SessionId), 4, 0));
         AV8WWPForm = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)getParm(obj,3);
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
         PA352( ) ;
         WS352( ) ;
         WE352( ) ;
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
         sCtrlAV7WWPDynamicFormMode = (string)((string)getParm(obj,0));
         sCtrlAV10WWPFormElementId = (string)((string)getParm(obj,1));
         sCtrlAV5SessionId = (string)((string)getParm(obj,2));
         sCtrlAV8WWPForm = (string)((string)getParm(obj,3));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA352( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "workwithplus\\dynamicforms\\wwp_dfc_group_wc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA352( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV7WWPDynamicFormMode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV7WWPDynamicFormMode", AV7WWPDynamicFormMode);
            AV10WWPFormElementId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV10WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV10WWPFormElementId), 4, 0));
            AV5SessionId = Convert.ToInt16(getParm(obj,4));
            AssignAttri(sPrefix, false, "AV5SessionId", StringUtil.LTrimStr( (decimal)(AV5SessionId), 4, 0));
            AV8WWPForm = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)getParm(obj,5);
         }
         wcpOAV7WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV7WWPDynamicFormMode");
         wcpOAV10WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV10WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV5SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV5SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV7WWPDynamicFormMode, wcpOAV7WWPDynamicFormMode) != 0 ) || ( AV10WWPFormElementId != wcpOAV10WWPFormElementId ) || ( AV5SessionId != wcpOAV5SessionId ) ) )
         {
            setjustcreated();
         }
         wcpOAV7WWPDynamicFormMode = AV7WWPDynamicFormMode;
         wcpOAV10WWPFormElementId = AV10WWPFormElementId;
         wcpOAV5SessionId = AV5SessionId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV7WWPDynamicFormMode = cgiGet( sPrefix+"AV7WWPDynamicFormMode_CTRL");
         if ( StringUtil.Len( sCtrlAV7WWPDynamicFormMode) > 0 )
         {
            AV7WWPDynamicFormMode = cgiGet( sCtrlAV7WWPDynamicFormMode);
            AssignAttri(sPrefix, false, "AV7WWPDynamicFormMode", AV7WWPDynamicFormMode);
         }
         else
         {
            AV7WWPDynamicFormMode = cgiGet( sPrefix+"AV7WWPDynamicFormMode_PARM");
         }
         sCtrlAV10WWPFormElementId = cgiGet( sPrefix+"AV10WWPFormElementId_CTRL");
         if ( StringUtil.Len( sCtrlAV10WWPFormElementId) > 0 )
         {
            AV10WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV10WWPFormElementId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV10WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV10WWPFormElementId), 4, 0));
         }
         else
         {
            AV10WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV10WWPFormElementId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV5SessionId = cgiGet( sPrefix+"AV5SessionId_CTRL");
         if ( StringUtil.Len( sCtrlAV5SessionId) > 0 )
         {
            AV5SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV5SessionId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV5SessionId", StringUtil.LTrimStr( (decimal)(AV5SessionId), 4, 0));
         }
         else
         {
            AV5SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV5SessionId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV8WWPForm = cgiGet( sPrefix+"AV8WWPForm_CTRL");
         if ( StringUtil.Len( sCtrlAV8WWPForm) > 0 )
         {
            AV8WWPForm.FromXml(cgiGet( sCtrlAV8WWPForm), null, "", "");
         }
         else
         {
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"AV8WWPForm_PARM"), AV8WWPForm);
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
         PA352( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS352( ) ;
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
         WS352( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7WWPDynamicFormMode_PARM", StringUtil.RTrim( AV7WWPDynamicFormMode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7WWPDynamicFormMode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7WWPDynamicFormMode_CTRL", StringUtil.RTrim( sCtrlAV7WWPDynamicFormMode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV10WWPFormElementId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV10WWPFormElementId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV10WWPFormElementId_CTRL", StringUtil.RTrim( sCtrlAV10WWPFormElementId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV5SessionId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV5SessionId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV5SessionId_CTRL", StringUtil.RTrim( sCtrlAV5SessionId));
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"AV8WWPForm_PARM", AV8WWPForm);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"AV8WWPForm_PARM", AV8WWPForm);
         }
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8WWPForm)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8WWPForm_CTRL", StringUtil.RTrim( sCtrlAV8WWPForm));
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
         WE352( ) ;
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
         if ( ! ( WebComp_Wcwwp_dfc_fs_wc == null ) )
         {
            WebComp_Wcwwp_dfc_fs_wc.componentjscripts();
         }
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wcwwp_dfc_fs_wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcwwp_dfc_fs_wc_Component) != 0 )
            {
               WebComp_Wcwwp_dfc_fs_wc.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256309341766", true, true);
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
         context.AddJavascriptSource("workwithplus/dynamicforms/wwp_dfc_group_wc.js", "?20256309341767", false, true);
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
         Dvpanel_tablecontent_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablecontent_Iconposition = "Right";
         Dvpanel_tablecontent_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablecontent_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablecontent_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tablecontent_Title = context.GetMessage( "Test", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
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
         AV8WWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         wcpOAV7WWPDynamicFormMode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         ucDvpanel_tablecontent = new GXUserControl();
         WebComp_Wcwwp_dfc_fs_wc_Component = "";
         OldWcwwp_dfc_fs_wc = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV9WWPFormElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         GXt_SdtWWP_Form_Element1 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         AV6WWP_DF_GroupMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ContainerMetadata(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV7WWPDynamicFormMode = "";
         sCtrlAV10WWPFormElementId = "";
         sCtrlAV5SessionId = "";
         sCtrlAV8WWPForm = "";
         WebComp_Wcwwp_dfc_fs_wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short AV10WWPFormElementId ;
      private short AV5SessionId ;
      private short wcpOAV10WWPFormElementId ;
      private short wcpOAV5SessionId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int idxLst ;
      private string AV7WWPDynamicFormMode ;
      private string wcpOAV7WWPDynamicFormMode ;
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
      private string divTablemain_Internalname ;
      private string Dvpanel_tablecontent_Internalname ;
      private string divTablecontent_Internalname ;
      private string WebComp_Wcwwp_dfc_fs_wc_Component ;
      private string OldWcwwp_dfc_fs_wc ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string sCtrlAV7WWPDynamicFormMode ;
      private string sCtrlAV10WWPFormElementId ;
      private string sCtrlAV5SessionId ;
      private string sCtrlAV8WWPForm ;
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
      private bool bDynCreated_Wcwwp_dfc_fs_wc ;
      private GXWebComponent WebComp_Wcwwp_dfc_fs_wc ;
      private GXUserControl ucDvpanel_tablecontent ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV8WWPForm ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP3_WWPForm ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV9WWPFormElement ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element GXt_SdtWWP_Form_Element1 ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ContainerMetadata AV6WWP_DF_GroupMetadata ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
