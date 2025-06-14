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
   public class wc_color : GXWebComponent
   {
      public wc_color( )
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

      public wc_color( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecuteImpl();
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
               gxfirstwebparm = GetNextPar( );
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
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix});
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
                  gxfirstwebparm = GetNextPar( );
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetNextPar( );
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Freestylegridcolor") == 0 )
               {
                  gxnrFreestylegridcolor_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Freestylegridcolor") == 0 )
               {
                  gxgrFreestylegridcolor_refresh_invoke( ) ;
                  return  ;
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

      protected void gxnrFreestylegridcolor_newrow_invoke( )
      {
         nRC_GXsfl_15 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_15"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_15_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_15_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_15_idx = GetPar( "sGXsfl_15_idx");
         sPrefix = GetPar( "sPrefix");
         edtavColorname_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavColorname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavColorname_Visible), 5, 0), !bGXsfl_15_Refreshing);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrFreestylegridcolor_newrow( ) ;
         /* End function gxnrFreestylegridcolor_newrow_invoke */
      }

      protected void gxgrFreestylegridcolor_refresh_invoke( )
      {
         edtavColorname_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavColorname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavColorname_Visible), 5, 0), !bGXsfl_15_Refreshing);
         AV9ColorItemClass = GetPar( "ColorItemClass");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10WWP_DesignSystemSettings);
         AV7ColorName = GetPar( "ColorName");
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrFreestylegridcolor_refresh( AV9ColorItemClass, AV10WWP_DesignSystemSettings, AV7ColorName, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrFreestylegridcolor_refresh_invoke */
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
            PA672( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS672( ) ;
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
            context.SendWebValue( context.GetMessage( "WC_Color", "")) ;
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
            FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wc_color.aspx") +"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
               context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
               AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
            }
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vCOLORITEMCLASS", AV9ColorItemClass);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCOLORITEMCLASS", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV9ColorItemClass, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_15", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_15), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCOLORITEMCLASS", AV9ColorItemClass);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCOLORITEMCLASS", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV9ColorItemClass, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DESIGNSYSTEMSETTINGS", AV10WWP_DesignSystemSettings);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DESIGNSYSTEMSETTINGS", AV10WWP_DesignSystemSettings);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"subFreestylegridcolor_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegridcolor_Recordcount), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCOLORNAME_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavColorname_Visible), 5, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm672( )
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
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "</form>") ;
            }
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
         return "WC_Color" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WC_Color", "") ;
      }

      protected void WB670( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wc_color.aspx");
            }
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingRight45", "start", "top", "", "", "div");
            /*  Grid Control  */
            FreestylegridcolorContainer.SetIsFreestyle(true);
            FreestylegridcolorContainer.SetWrapped(nGXWrapped);
            StartGridControl15( ) ;
         }
         if ( wbEnd == 15 )
         {
            wbEnd = 0;
            nRC_GXsfl_15 = (int)(nGXsfl_15_idx-1);
            if ( FreestylegridcolorContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"FreestylegridcolorContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Freestylegridcolor", FreestylegridcolorContainer, subFreestylegridcolor_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"FreestylegridcolorContainerData", FreestylegridcolorContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"FreestylegridcolorContainerData"+"V", FreestylegridcolorContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"FreestylegridcolorContainerData"+"V"+"\" value='"+FreestylegridcolorContainer.GridValuesHidden()+"'/>") ;
               }
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
         if ( wbEnd == 15 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( FreestylegridcolorContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"FreestylegridcolorContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Freestylegridcolor", FreestylegridcolorContainer, subFreestylegridcolor_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"FreestylegridcolorContainerData", FreestylegridcolorContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"FreestylegridcolorContainerData"+"V", FreestylegridcolorContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"FreestylegridcolorContainerData"+"V"+"\" value='"+FreestylegridcolorContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START672( )
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
            Form.Meta.addItem("description", context.GetMessage( "WC_Color", ""), 0) ;
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
               STRUP670( ) ;
            }
         }
      }

      protected void WS672( )
      {
         START672( ) ;
         EVT672( ) ;
      }

      protected void EVT672( )
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
                                 STRUP670( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "TABLECOLORITEM.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP670( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Tablecoloritem.Click */
                                    E11672 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP670( ) ;
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
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "FREESTYLEGRIDCOLOR.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "TABLECOLORITEM.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP670( ) ;
                              }
                              nGXsfl_15_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
                              SubsflControlProps_152( ) ;
                              AV7ColorName = cgiGet( edtavColorname_Internalname);
                              AssignAttri(sPrefix, false, edtavColorname_Internalname, AV7ColorName);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: Start */
                                          E12672 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "FREESTYLEGRIDCOLOR.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: Freestylegridcolor.Load */
                                          E13672 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "TABLECOLORITEM.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: Tablecoloritem.Click */
                                          E11672 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
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
                                       STRUP670( ) ;
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
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE672( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm672( ) ;
            }
         }
      }

      protected void PA672( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Crypto.GetSiteKey( );
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

      protected void gxnrFreestylegridcolor_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_152( ) ;
         while ( nGXsfl_15_idx <= nRC_GXsfl_15 )
         {
            sendrow_152( ) ;
            nGXsfl_15_idx = ((subFreestylegridcolor_Islastpage==1)&&(nGXsfl_15_idx+1>subFreestylegridcolor_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_idx+1);
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( FreestylegridcolorContainer)) ;
         /* End function gxnrFreestylegridcolor_newrow */
      }

      protected void gxgrFreestylegridcolor_refresh( string AV9ColorItemClass ,
                                                     WorkWithPlus.workwithplus_web.SdtWWP_DesignSystemSettings AV10WWP_DesignSystemSettings ,
                                                     string AV7ColorName ,
                                                     string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FREESTYLEGRIDCOLOR_nCurrentRecord = 0;
         RF672( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrFreestylegridcolor_refresh */
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
         RF672( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF672( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            FreestylegridcolorContainer.ClearRows();
         }
         wbStart = 15;
         nGXsfl_15_idx = 1;
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         bGXsfl_15_Refreshing = true;
         FreestylegridcolorContainer.AddObjectProperty("GridName", "Freestylegridcolor");
         FreestylegridcolorContainer.AddObjectProperty("CmpContext", sPrefix);
         FreestylegridcolorContainer.AddObjectProperty("InMasterPage", "false");
         FreestylegridcolorContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         FreestylegridcolorContainer.AddObjectProperty("Class", "FreeStyleGrid");
         FreestylegridcolorContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         FreestylegridcolorContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         FreestylegridcolorContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegridcolor_Backcolorstyle), 1, 0, ".", "")));
         FreestylegridcolorContainer.PageSize = subFreestylegridcolor_fnc_Recordsperpage( );
         if ( subFreestylegridcolor_Islastpage != 0 )
         {
            FREESTYLEGRIDCOLOR_nFirstRecordOnPage = (long)(subFreestylegridcolor_fnc_Recordcount( )-subFreestylegridcolor_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRIDCOLOR_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(FREESTYLEGRIDCOLOR_nFirstRecordOnPage), 15, 0, ".", "")));
            FreestylegridcolorContainer.AddObjectProperty("FREESTYLEGRIDCOLOR_nFirstRecordOnPage", FREESTYLEGRIDCOLOR_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_152( ) ;
            /* Execute user event: Freestylegridcolor.Load */
            E13672 ();
            wbEnd = 15;
            WB670( ) ;
         }
         bGXsfl_15_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes672( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vCOLORITEMCLASS", AV9ColorItemClass);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCOLORITEMCLASS", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV9ColorItemClass, "")), context));
      }

      protected int subFreestylegridcolor_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subFreestylegridcolor_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subFreestylegridcolor_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subFreestylegridcolor_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP670( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12672 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_15 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_15"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subFreestylegridcolor_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"subFreestylegridcolor_Recordcount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         E12672 ();
         if (returnInSub) return;
      }

      protected void E12672( )
      {
         /* Start Routine */
         returnInSub = false;
         edtavColorname_Visible = 0;
         AssignProp(sPrefix, false, edtavColorname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavColorname_Visible), 5, 0), !bGXsfl_15_Refreshing);
      }

      private void E13672( )
      {
         /* Freestylegridcolor_Load Routine */
         returnInSub = false;
         AV8ColorItemDefinition = "<div class=\"%1\" style=\"background-color:%2\">";
         AV7ColorName = "LightPink";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV7ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV8ColorItemDefinition, AV9ColorItemClass, "#b05792", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, FreestylegridcolorRow);
         }
         AV7ColorName = "MediumViolet";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV7ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV8ColorItemDefinition, AV9ColorItemClass, "MediumVioletRed", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, FreestylegridcolorRow);
         }
         AV7ColorName = "Pink";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV7ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV8ColorItemDefinition, AV9ColorItemClass, "#a11a74", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, FreestylegridcolorRow);
         }
         AV7ColorName = "MediumPink";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV7ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV8ColorItemDefinition, AV9ColorItemClass, "#ED66D2", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, FreestylegridcolorRow);
         }
         AV7ColorName = "MediumPurple";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV7ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV8ColorItemDefinition, AV9ColorItemClass, "MediumPurple", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, FreestylegridcolorRow);
         }
         AV7ColorName = "LightPurple";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV7ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV8ColorItemDefinition, AV9ColorItemClass, "#696ef2", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, FreestylegridcolorRow);
         }
         AV7ColorName = "Purple";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV7ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV8ColorItemDefinition, AV9ColorItemClass, "#7F4494", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, FreestylegridcolorRow);
         }
         AV7ColorName = "Indigo";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV7ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV8ColorItemDefinition, AV9ColorItemClass, "Indigo", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, FreestylegridcolorRow);
         }
         AV7ColorName = "LightBlue";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV7ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV8ColorItemDefinition, AV9ColorItemClass, "#39b3d7", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, FreestylegridcolorRow);
         }
         AV7ColorName = "Blue";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV7ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV8ColorItemDefinition, AV9ColorItemClass, "#078bcd", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, FreestylegridcolorRow);
         }
         AV7ColorName = "SkyBlue";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV7ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV8ColorItemDefinition, AV9ColorItemClass, "#4978b0", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, FreestylegridcolorRow);
         }
         AV7ColorName = "Navy";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV7ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV8ColorItemDefinition, AV9ColorItemClass, "#004080", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, FreestylegridcolorRow);
         }
         AV7ColorName = "Green";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV7ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV8ColorItemDefinition, AV9ColorItemClass, "#5CB85C", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, FreestylegridcolorRow);
         }
         AV7ColorName = "SeaGreen";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV7ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV8ColorItemDefinition, AV9ColorItemClass, "#08A086", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, FreestylegridcolorRow);
         }
         AV7ColorName = "Teal";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV7ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV8ColorItemDefinition, AV9ColorItemClass, "Teal", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, FreestylegridcolorRow);
         }
         AV7ColorName = "Olive";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV7ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV8ColorItemDefinition, AV9ColorItemClass, "#004000", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, FreestylegridcolorRow);
         }
         AV7ColorName = "Salmon";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV7ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV8ColorItemDefinition, AV9ColorItemClass, "Salmon", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, FreestylegridcolorRow);
         }
         AV7ColorName = "Red";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV7ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV8ColorItemDefinition, AV9ColorItemClass, "#d9534f", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, FreestylegridcolorRow);
         }
         AV7ColorName = "Tomato";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV7ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV8ColorItemDefinition, AV9ColorItemClass, "Tomato", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, FreestylegridcolorRow);
         }
         AV7ColorName = "Maroon";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV7ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV8ColorItemDefinition, AV9ColorItemClass, "#950000", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, FreestylegridcolorRow);
         }
         AV7ColorName = "Orange";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV7ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV8ColorItemDefinition, AV9ColorItemClass, "#FF8040", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, FreestylegridcolorRow);
         }
         AV7ColorName = "Yellow";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV7ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV8ColorItemDefinition, AV9ColorItemClass, "#f0ad4e", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, FreestylegridcolorRow);
         }
         AV7ColorName = "Ecru";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV7ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV8ColorItemDefinition, AV9ColorItemClass, "#B75B00", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, FreestylegridcolorRow);
         }
         AV7ColorName = "Brown";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV7ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV8ColorItemDefinition, AV9ColorItemClass, "#804000", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, FreestylegridcolorRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E11672( )
      {
         /* Tablecoloritem_Click Routine */
         returnInSub = false;
         GXt_SdtWWP_DesignSystemSettings1 = AV10WWP_DesignSystemSettings;
         new GeneXus.Programs.wwpbaseobjects.wwp_getdesignsystemsettings(context ).execute( out  GXt_SdtWWP_DesignSystemSettings1) ;
         AV10WWP_DesignSystemSettings = GXt_SdtWWP_DesignSystemSettings1;
         AV10WWP_DesignSystemSettings.gxTpr_Basecolor = AV7ColorName;
         this.executeExternalObjectMethod(sPrefix, false, "gx.core.ds", "setOption", new Object[] {(string)"base-color",AV10WWP_DesignSystemSettings.gxTpr_Basecolor}, false);
         AV12WebSession.Set(context.GetMessage( "SelectedBaseColor", ""), AV7ColorName);
         gxgrFreestylegridcolor_refresh( AV9ColorItemClass, AV10WWP_DesignSystemSettings, AV7ColorName, sPrefix) ;
         this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "EmpoweredGrids_Refresh", new Object[] {}, false);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10WWP_DesignSystemSettings", AV10WWP_DesignSystemSettings);
      }

      protected void S112( )
      {
         /* 'GETCOLORCLASS' Routine */
         returnInSub = false;
         AV11ColorItemBaseClass = "RuntimeSettingsColor";
         AV9ColorItemClass = ((StringUtil.StrCmp(AV10WWP_DesignSystemSettings.gxTpr_Basecolor, AV7ColorName)==0) ? AV11ColorItemBaseClass+"Selected" : AV11ColorItemBaseClass);
         AssignAttri(sPrefix, false, "AV9ColorItemClass", AV9ColorItemClass);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCOLORITEMCLASS", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV9ColorItemClass, "")), context));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA672( ) ;
         WS672( ) ;
         WE672( ) ;
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
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA672( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wc_color", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA672( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
         }
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
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
         PA672( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS672( ) ;
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
         WS672( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
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
         WE672( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256145235084", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("wc_color.js", "?20256145235084", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_152( )
      {
         lblColorsquare_Internalname = sPrefix+"COLORSQUARE_"+sGXsfl_15_idx;
         edtavColorname_Internalname = sPrefix+"vCOLORNAME_"+sGXsfl_15_idx;
      }

      protected void SubsflControlProps_fel_152( )
      {
         lblColorsquare_Internalname = sPrefix+"COLORSQUARE_"+sGXsfl_15_fel_idx;
         edtavColorname_Internalname = sPrefix+"vCOLORNAME_"+sGXsfl_15_fel_idx;
      }

      protected void sendrow_152( )
      {
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         WB670( ) ;
         FreestylegridcolorRow = GXWebRow.GetNew(context,FreestylegridcolorContainer);
         if ( subFreestylegridcolor_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subFreestylegridcolor_Backstyle = 0;
            if ( StringUtil.StrCmp(subFreestylegridcolor_Class, "") != 0 )
            {
               subFreestylegridcolor_Linesclass = subFreestylegridcolor_Class+"Odd";
            }
         }
         else if ( subFreestylegridcolor_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subFreestylegridcolor_Backstyle = 0;
            subFreestylegridcolor_Backcolor = subFreestylegridcolor_Allbackcolor;
            if ( StringUtil.StrCmp(subFreestylegridcolor_Class, "") != 0 )
            {
               subFreestylegridcolor_Linesclass = subFreestylegridcolor_Class+"Uniform";
            }
         }
         else if ( subFreestylegridcolor_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subFreestylegridcolor_Backstyle = 1;
            if ( StringUtil.StrCmp(subFreestylegridcolor_Class, "") != 0 )
            {
               subFreestylegridcolor_Linesclass = subFreestylegridcolor_Class+"Odd";
            }
            subFreestylegridcolor_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subFreestylegridcolor_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subFreestylegridcolor_Backstyle = 1;
            if ( ((int)((nGXsfl_15_idx) % (2))) == 0 )
            {
               subFreestylegridcolor_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subFreestylegridcolor_Class, "") != 0 )
               {
                  subFreestylegridcolor_Linesclass = subFreestylegridcolor_Class+"Even";
               }
            }
            else
            {
               subFreestylegridcolor_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subFreestylegridcolor_Class, "") != 0 )
               {
                  subFreestylegridcolor_Linesclass = subFreestylegridcolor_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( FreestylegridcolorContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subFreestylegridcolor_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_15_idx+"\">") ;
         }
         /* Table start */
         FreestylegridcolorRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblTablecoloritem_Internalname+"_"+sGXsfl_15_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         FreestylegridcolorRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         FreestylegridcolorRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Text block */
         FreestylegridcolorRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblColorsquare_Internalname,(string)lblColorsquare_Caption,(string)"",(string)"",(string)lblColorsquare_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)2});
         if ( FreestylegridcolorContainer.GetWrapped() == 1 )
         {
            FreestylegridcolorContainer.CloseTag("cell");
         }
         if ( FreestylegridcolorContainer.GetWrapped() == 1 )
         {
            FreestylegridcolorContainer.CloseTag("row");
         }
         FreestylegridcolorRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         FreestylegridcolorRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)"Invisible"});
         /* Table start */
         FreestylegridcolorRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsfreestylegridcolor_Internalname+"_"+sGXsfl_15_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         FreestylegridcolorRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         FreestylegridcolorRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         FreestylegridcolorRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FreestylegridcolorRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavColorname_Internalname,context.GetMessage( "Color Name", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         ROClassString = "Attribute";
         FreestylegridcolorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavColorname_Internalname,(string)AV7ColorName,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavColorname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavColorname_Visible,(short)0,(short)0,(string)"text",(string)"",(short)40,(string)"chr",(short)1,(string)"row",(short)40,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         FreestylegridcolorRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         if ( FreestylegridcolorContainer.GetWrapped() == 1 )
         {
            FreestylegridcolorContainer.CloseTag("cell");
         }
         if ( FreestylegridcolorContainer.GetWrapped() == 1 )
         {
            FreestylegridcolorContainer.CloseTag("row");
         }
         if ( FreestylegridcolorContainer.GetWrapped() == 1 )
         {
            FreestylegridcolorContainer.CloseTag("table");
         }
         /* End of table */
         if ( FreestylegridcolorContainer.GetWrapped() == 1 )
         {
            FreestylegridcolorContainer.CloseTag("cell");
         }
         if ( FreestylegridcolorContainer.GetWrapped() == 1 )
         {
            FreestylegridcolorContainer.CloseTag("row");
         }
         if ( FreestylegridcolorContainer.GetWrapped() == 1 )
         {
            FreestylegridcolorContainer.CloseTag("table");
         }
         /* End of table */
         send_integrity_lvl_hashes672( ) ;
         /* End of Columns property logic. */
         FreestylegridcolorContainer.AddRow(FreestylegridcolorRow);
         nGXsfl_15_idx = ((subFreestylegridcolor_Islastpage==1)&&(nGXsfl_15_idx+1>subFreestylegridcolor_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_idx+1);
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         /* End function sendrow_152 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl15( )
      {
         if ( FreestylegridcolorContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"FreestylegridcolorContainer"+"DivS\" data-gxgridid=\"15\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subFreestylegridcolor_Internalname, subFreestylegridcolor_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            FreestylegridcolorContainer.AddObjectProperty("GridName", "Freestylegridcolor");
         }
         else
         {
            FreestylegridcolorContainer.AddObjectProperty("GridName", "Freestylegridcolor");
            FreestylegridcolorContainer.AddObjectProperty("Header", subFreestylegridcolor_Header);
            FreestylegridcolorContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            FreestylegridcolorContainer.AddObjectProperty("Class", "FreeStyleGrid");
            FreestylegridcolorContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            FreestylegridcolorContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            FreestylegridcolorContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegridcolor_Backcolorstyle), 1, 0, ".", "")));
            FreestylegridcolorContainer.AddObjectProperty("CmpContext", sPrefix);
            FreestylegridcolorContainer.AddObjectProperty("InMasterPage", "false");
            FreestylegridcolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreestylegridcolorContainer.AddColumnProperties(FreestylegridcolorColumn);
            FreestylegridcolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreestylegridcolorContainer.AddColumnProperties(FreestylegridcolorColumn);
            FreestylegridcolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreestylegridcolorContainer.AddColumnProperties(FreestylegridcolorColumn);
            FreestylegridcolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreestylegridcolorColumn.AddObjectProperty("Value", lblColorsquare_Caption);
            FreestylegridcolorContainer.AddColumnProperties(FreestylegridcolorColumn);
            FreestylegridcolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreestylegridcolorContainer.AddColumnProperties(FreestylegridcolorColumn);
            FreestylegridcolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreestylegridcolorContainer.AddColumnProperties(FreestylegridcolorColumn);
            FreestylegridcolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreestylegridcolorContainer.AddColumnProperties(FreestylegridcolorColumn);
            FreestylegridcolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreestylegridcolorContainer.AddColumnProperties(FreestylegridcolorColumn);
            FreestylegridcolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreestylegridcolorContainer.AddColumnProperties(FreestylegridcolorColumn);
            FreestylegridcolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreestylegridcolorContainer.AddColumnProperties(FreestylegridcolorColumn);
            FreestylegridcolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreestylegridcolorContainer.AddColumnProperties(FreestylegridcolorColumn);
            FreestylegridcolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreestylegridcolorColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV7ColorName));
            FreestylegridcolorColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavColorname_Visible), 5, 0, ".", "")));
            FreestylegridcolorContainer.AddColumnProperties(FreestylegridcolorColumn);
            FreestylegridcolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreestylegridcolorContainer.AddColumnProperties(FreestylegridcolorColumn);
            FreestylegridcolorContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegridcolor_Selectedindex), 4, 0, ".", "")));
            FreestylegridcolorContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegridcolor_Allowselection), 1, 0, ".", "")));
            FreestylegridcolorContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegridcolor_Selectioncolor), 9, 0, ".", "")));
            FreestylegridcolorContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegridcolor_Allowhovering), 1, 0, ".", "")));
            FreestylegridcolorContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegridcolor_Hoveringcolor), 9, 0, ".", "")));
            FreestylegridcolorContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegridcolor_Allowcollapsing), 1, 0, ".", "")));
            FreestylegridcolorContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegridcolor_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblColorsquare_Internalname = sPrefix+"COLORSQUARE";
         edtavColorname_Internalname = sPrefix+"vCOLORNAME";
         tblUnnamedtablecontentfsfreestylegridcolor_Internalname = sPrefix+"UNNAMEDTABLECONTENTFSFREESTYLEGRIDCOLOR";
         tblTablecoloritem_Internalname = sPrefix+"TABLECOLORITEM";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subFreestylegridcolor_Internalname = sPrefix+"FREESTYLEGRIDCOLOR";
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
         subFreestylegridcolor_Allowcollapsing = 0;
         lblColorsquare_Caption = "";
         edtavColorname_Jsonclick = "";
         lblColorsquare_Caption = "";
         subFreestylegridcolor_Class = "FreeStyleGrid";
         subFreestylegridcolor_Backcolorstyle = 0;
         edtavColorname_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"FREESTYLEGRIDCOLOR_nFirstRecordOnPage"},{"av":"FREESTYLEGRIDCOLOR_nEOF"},{"av":"edtavColorname_Visible","ctrl":"vCOLORNAME","prop":"Visible"},{"av":"AV10WWP_DesignSystemSettings","fld":"vWWP_DESIGNSYSTEMSETTINGS"},{"av":"AV7ColorName","fld":"vCOLORNAME"},{"av":"sPrefix"},{"av":"AV9ColorItemClass","fld":"vCOLORITEMCLASS","hsh":true}]}""");
         setEventMetadata("FREESTYLEGRIDCOLOR.LOAD","""{"handler":"E13672","iparms":[{"av":"AV9ColorItemClass","fld":"vCOLORITEMCLASS","hsh":true},{"av":"AV10WWP_DesignSystemSettings","fld":"vWWP_DESIGNSYSTEMSETTINGS"},{"av":"AV7ColorName","fld":"vCOLORNAME"}]""");
         setEventMetadata("FREESTYLEGRIDCOLOR.LOAD",""","oparms":[{"av":"AV7ColorName","fld":"vCOLORNAME"},{"av":"lblColorsquare_Caption","ctrl":"COLORSQUARE","prop":"Caption"},{"av":"AV9ColorItemClass","fld":"vCOLORITEMCLASS","hsh":true}]}""");
         setEventMetadata("TABLECOLORITEM.CLICK","""{"handler":"E11672","iparms":[{"av":"FREESTYLEGRIDCOLOR_nFirstRecordOnPage"},{"av":"FREESTYLEGRIDCOLOR_nEOF"},{"av":"edtavColorname_Visible","ctrl":"vCOLORNAME","prop":"Visible"},{"av":"AV9ColorItemClass","fld":"vCOLORITEMCLASS","hsh":true},{"av":"AV10WWP_DesignSystemSettings","fld":"vWWP_DESIGNSYSTEMSETTINGS"},{"av":"AV7ColorName","fld":"vCOLORNAME"},{"av":"sPrefix"}]""");
         setEventMetadata("TABLECOLORITEM.CLICK",""","oparms":[{"av":"AV10WWP_DesignSystemSettings","fld":"vWWP_DESIGNSYSTEMSETTINGS"}]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Colorname","iparms":[]}""");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV9ColorItemClass = "";
         AV10WWP_DesignSystemSettings = new WorkWithPlus.workwithplus_web.SdtWWP_DesignSystemSettings(context);
         AV7ColorName = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         FreestylegridcolorContainer = new GXWebGrid( context);
         sStyleString = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV8ColorItemDefinition = "";
         FreestylegridcolorRow = new GXWebRow();
         GXt_SdtWWP_DesignSystemSettings1 = new WorkWithPlus.workwithplus_web.SdtWWP_DesignSystemSettings(context);
         AV12WebSession = context.GetSession();
         AV11ColorItemBaseClass = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subFreestylegridcolor_Linesclass = "";
         lblColorsquare_Jsonclick = "";
         ROClassString = "";
         subFreestylegridcolor_Header = "";
         FreestylegridcolorColumn = new GXWebColumn();
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short subFreestylegridcolor_Backcolorstyle ;
      private short FREESTYLEGRIDCOLOR_nEOF ;
      private short subFreestylegridcolor_Backstyle ;
      private short subFreestylegridcolor_Allowselection ;
      private short subFreestylegridcolor_Allowhovering ;
      private short subFreestylegridcolor_Allowcollapsing ;
      private short subFreestylegridcolor_Collapsed ;
      private int edtavColorname_Visible ;
      private int nRC_GXsfl_15 ;
      private int subFreestylegridcolor_Recordcount ;
      private int nGXsfl_15_idx=1 ;
      private int subFreestylegridcolor_Islastpage ;
      private int idxLst ;
      private int subFreestylegridcolor_Backcolor ;
      private int subFreestylegridcolor_Allbackcolor ;
      private int subFreestylegridcolor_Selectedindex ;
      private int subFreestylegridcolor_Selectioncolor ;
      private int subFreestylegridcolor_Hoveringcolor ;
      private long FREESTYLEGRIDCOLOR_nCurrentRecord ;
      private long FREESTYLEGRIDCOLOR_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_15_idx="0001" ;
      private string edtavColorname_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string sStyleString ;
      private string subFreestylegridcolor_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string lblColorsquare_Caption ;
      private string lblColorsquare_Internalname ;
      private string sGXsfl_15_fel_idx="0001" ;
      private string subFreestylegridcolor_Class ;
      private string subFreestylegridcolor_Linesclass ;
      private string tblTablecoloritem_Internalname ;
      private string lblColorsquare_Jsonclick ;
      private string tblUnnamedtablecontentfsfreestylegridcolor_Internalname ;
      private string ROClassString ;
      private string edtavColorname_Jsonclick ;
      private string subFreestylegridcolor_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_15_Refreshing=false ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV9ColorItemClass ;
      private string AV7ColorName ;
      private string AV8ColorItemDefinition ;
      private string AV11ColorItemBaseClass ;
      private GXWebGrid FreestylegridcolorContainer ;
      private GXWebRow FreestylegridcolorRow ;
      private GXWebColumn FreestylegridcolorColumn ;
      private GXWebForm Form ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private WorkWithPlus.workwithplus_web.SdtWWP_DesignSystemSettings AV10WWP_DesignSystemSettings ;
      private WorkWithPlus.workwithplus_web.SdtWWP_DesignSystemSettings GXt_SdtWWP_DesignSystemSettings1 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
