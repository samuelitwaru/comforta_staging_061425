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
   public class wp_residentdiscussion : GXDataArea
   {
      public wp_residentdiscussion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_residentdiscussion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DiscussionRecordId ,
                           string aP1_AccessToken )
      {
         this.AV13DiscussionRecordId = aP0_DiscussionRecordId;
         this.AV18AccessToken = aP1_AccessToken;
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
            gxfirstwebparm = GetFirstPar( "DiscussionRecordId");
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
               gxfirstwebparm = GetFirstPar( "DiscussionRecordId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "DiscussionRecordId");
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
               AV13DiscussionRecordId = gxfirstwebparm;
               AssignAttri("", false, "AV13DiscussionRecordId", AV13DiscussionRecordId);
               GxWebStd.gx_hidden_field( context, "gxhash_vDISCUSSIONRECORDID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV13DiscussionRecordId, "")), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV18AccessToken = GetPar( "AccessToken");
                  AssignAttri("", false, "AV18AccessToken", AV18AccessToken);
                  GxWebStd.gx_hidden_field( context, "gxhash_vACCESSTOKEN", GetSecureSignedToken( "", AV18AccessToken, context));
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpageempty", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpageempty", new Object[] {context});
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
         PA7N2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START7N2( ) ;
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
         context.WriteHtmlText( " "+"class=\"form-horizontal ResidentForm\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal ResidentForm\" data-gx-class=\"form-horizontal ResidentForm\" novalidate action=\""+formatLink("wp_residentdiscussion.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13DiscussionRecordId)),UrlEncode(StringUtil.RTrim(AV18AccessToken))}, new string[] {"DiscussionRecordId","AccessToken"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal ResidentForm", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vDISCUSSIONRECORDID", AV13DiscussionRecordId);
         GxWebStd.gx_hidden_field( context, "gxhash_vDISCUSSIONRECORDID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV13DiscussionRecordId, "")), context));
         GxWebStd.gx_hidden_field( context, "vACCESSTOKEN", AV18AccessToken);
         GxWebStd.gx_hidden_field( context, "gxhash_vACCESSTOKEN", GetSecureSignedToken( "", AV18AccessToken, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vDISCUSSIONRECORDID", AV13DiscussionRecordId);
         GxWebStd.gx_hidden_field( context, "gxhash_vDISCUSSIONRECORDID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV13DiscussionRecordId, "")), context));
         GxWebStd.gx_hidden_field( context, "vACCESSTOKEN", AV18AccessToken);
         GxWebStd.gx_hidden_field( context, "gxhash_vACCESSTOKEN", GetSecureSignedToken( "", AV18AccessToken, context));
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
         if ( ! ( WebComp_Discussioncomponent == null ) )
         {
            WebComp_Discussioncomponent.componentjscripts();
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
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal ResidentForm" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE7N2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT7N2( ) ;
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
         return formatLink("wp_residentdiscussion.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13DiscussionRecordId)),UrlEncode(StringUtil.RTrim(AV18AccessToken))}, new string[] {"DiscussionRecordId","AccessToken"})  ;
      }

      public override string GetPgmname( )
      {
         return "WP_ResidentDiscussion" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WP_Resident Discussion", "") ;
      }

      protected void WB7N0( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0015"+"", StringUtil.RTrim( WebComp_Discussioncomponent_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0015"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Discussioncomponent_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldDiscussioncomponent), StringUtil.Lower( WebComp_Discussioncomponent_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0015"+"");
                  }
                  WebComp_Discussioncomponent.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldDiscussioncomponent), StringUtil.Lower( WebComp_Discussioncomponent_Component)) != 0 )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divNorecordfoundtable_Internalname, divNorecordfoundtable_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table1_21_7N2( true) ;
         }
         else
         {
            wb_table1_21_7N2( false) ;
         }
         return  ;
      }

      protected void wb_table1_21_7N2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblBanicon_Internalname, context.GetMessage( "<i class='fas fa-ban' style='font-size: 50px'></i>", ""), "", "", lblBanicon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WP_ResidentDiscussion.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table2_30_7N2( true) ;
         }
         else
         {
            wb_table2_30_7N2( false) ;
         }
         return  ;
      }

      protected void wb_table2_30_7N2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblErrormessage_Internalname, lblErrormessage_Caption, "", "", lblErrormessage_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WP_ResidentDiscussion.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START7N2( )
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
         Form.Meta.addItem("description", context.GetMessage( "WP_Resident Discussion", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP7N0( ) ;
      }

      protected void WS7N2( )
      {
         START7N2( ) ;
         EVT7N2( ) ;
      }

      protected void EVT7N2( )
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
                              E117N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E127N2 ();
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
                        if ( nCmpId == 15 )
                        {
                           OldDiscussioncomponent = cgiGet( "W0015");
                           if ( ( StringUtil.Len( OldDiscussioncomponent) == 0 ) || ( StringUtil.StrCmp(OldDiscussioncomponent, WebComp_Discussioncomponent_Component) != 0 ) )
                           {
                              WebComp_Discussioncomponent = getWebComponent(GetType(), "GeneXus.Programs", OldDiscussioncomponent, new Object[] {context} );
                              WebComp_Discussioncomponent.ComponentInit();
                              WebComp_Discussioncomponent.Name = "OldDiscussioncomponent";
                              WebComp_Discussioncomponent_Component = OldDiscussioncomponent;
                           }
                           if ( StringUtil.Len( WebComp_Discussioncomponent_Component) != 0 )
                           {
                              WebComp_Discussioncomponent.componentprocess("W0015", "", sEvt);
                           }
                           WebComp_Discussioncomponent_Component = OldDiscussioncomponent;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE7N2( )
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

      protected void PA7N2( )
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
         RF7N2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF7N2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Discussioncomponent_Component) != 0 )
               {
                  WebComp_Discussioncomponent.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E127N2 ();
            WB7N0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes7N2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7N0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E117N2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
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
         E117N2 ();
         if (returnInSub) return;
      }

      protected void E117N2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV12WWPEntityName = context.GetMessage( "Discussion", "");
         AV19Description = context.GetMessage( "discussion", "");
         AV9ResidentId = AV11WebSession.Get(context.GetMessage( "WebViewResidentId", ""));
         AssignAttri("", false, "AV9ResidentId", AV9ResidentId);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9ResidentId)) )
         {
            new prc_getuseridfromaccesstoken(context ).execute(  AV18AccessToken, out  AV9ResidentId, out  AV20isTokenValid) ;
            AssignAttri("", false, "AV9ResidentId", AV9ResidentId);
         }
         else
         {
            AV20isTokenValid = true;
         }
         /* Using cursor H007N2 */
         pr_default.execute(0, new Object[] {AV9ResidentId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A71ResidentGUID = H007N2_A71ResidentGUID[0];
            A599ResidentLanguage = H007N2_A599ResidentLanguage[0];
            AV22Language = A599ResidentLanguage;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( StringUtil.StrCmp(AV22Language, "en") == 0 )
         {
            AV21NumericVariable = (short)(context.SetLanguage( "English"));
         }
         else if ( StringUtil.StrCmp(AV22Language, "nl") == 0 )
         {
            AV21NumericVariable = (short)(context.SetLanguage( "Dutch"));
         }
         else
         {
            AV21NumericVariable = (short)(context.SetLanguage( "English"));
         }
         if ( AV20isTokenValid )
         {
            AV11WebSession.Set(context.GetMessage( "WebViewResidentId", ""), AV9ResidentId);
            AV16WWP_UserExtended.Load(AV9ResidentId);
            if ( AV16WWP_UserExtended.Success() )
            {
               AV14WWP_FormInstance.Load((int)(Math.Round(NumberUtil.Val( AV13DiscussionRecordId, "."), 18, MidpointRounding.ToEven)));
               if ( AV14WWP_FormInstance.Success() )
               {
                  AV12WWPEntityName = context.GetMessage( "WWP_DynamicForm", "");
                  AV15WWPFormReferenceName = AV14WWP_FormInstance.gxTpr_Wwpformreferencename;
                  AssignAttri("", false, "AV15WWPFormReferenceName", AV15WWPFormReferenceName);
                  AV19Description = context.GetMessage( "A filled ", "") + AV14WWP_FormInstance.gxTpr_Wwpformtitle;
               }
               tblSpacetable2_Height = 30;
               AssignProp("", false, tblSpacetable2_Internalname, "Height", StringUtil.LTrimStr( (decimal)(tblSpacetable2_Height), 9, 0), true);
               tblSpacetable1_Height = 60;
               AssignProp("", false, tblSpacetable1_Internalname, "Height", StringUtil.LTrimStr( (decimal)(tblSpacetable1_Height), 9, 0), true);
               /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
               S112 ();
               if (returnInSub) return;
               /* Object Property */
               if ( true )
               {
                  bDynCreated_Discussioncomponent = true;
               }
               if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Discussioncomponent_Component), StringUtil.Lower( "WC_Discussions")) != 0 )
               {
                  WebComp_Discussioncomponent = getWebComponent(GetType(), "GeneXus.Programs", "wc_discussions", new Object[] {context} );
                  WebComp_Discussioncomponent.ComponentInit();
                  WebComp_Discussioncomponent.Name = "WC_Discussions";
                  WebComp_Discussioncomponent_Component = "WC_Discussions";
               }
               if ( StringUtil.Len( WebComp_Discussioncomponent_Component) != 0 )
               {
                  WebComp_Discussioncomponent.setjustcreated();
                  WebComp_Discussioncomponent.componentprepare(new Object[] {(string)"W0015",(string)"",(string)AV12WWPEntityName,StringUtil.Trim( AV13DiscussionRecordId),(string)AV19Description,formatLink("workwithplus.dynamicforms.wwp_dynamicform.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV15WWPFormReferenceName)),UrlEncode(StringUtil.RTrim(StringUtil.Trim( AV13DiscussionRecordId))),UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.BoolToStr(true))}, new string[] {"WWPFormReferenceName","WWPFormInstanceId","WWPDynamicFormMode","isLinkingDiscussion"}) });
                  WebComp_Discussioncomponent.componentbind(new Object[] {(string)"",(string)""+""+"",(string)"",(string)""+"",(string)"",(string)""+""+"",(string)"",(string)""+""});
               }
            }
            else
            {
               AV17ShowNoRecordFound = false;
               AssignAttri("", false, "AV17ShowNoRecordFound", AV17ShowNoRecordFound);
            }
         }
         else
         {
            AV17ShowNoRecordFound = true;
            AssignAttri("", false, "AV17ShowNoRecordFound", AV17ShowNoRecordFound);
            lblErrormessage_Caption = context.GetMessage( "The user session has expired", "");
            AssignProp("", false, lblErrormessage_Internalname, "Caption", lblErrormessage_Caption, true);
         }
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         divNorecordfoundtable_Visible = (((AV17ShowNoRecordFound)) ? 1 : 0);
         AssignProp("", false, divNorecordfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divNorecordfoundtable_Visible), 5, 0), true);
      }

      protected void nextLoad( )
      {
      }

      protected void E127N2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table2_30_7N2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            sStyleString += " height: " + StringUtil.LTrimStr( (decimal)(tblSpacetable2_Height), 10, 0) + "px" + ";";
            GxWebStd.gx_table_start( context, tblSpacetable2_Internalname, tblSpacetable2_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, " ", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WP_ResidentDiscussion.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_30_7N2e( true) ;
         }
         else
         {
            wb_table2_30_7N2e( false) ;
         }
      }

      protected void wb_table1_21_7N2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            sStyleString += " height: " + StringUtil.LTrimStr( (decimal)(tblSpacetable1_Height), 10, 0) + "px" + ";";
            GxWebStd.gx_table_start( context, tblSpacetable1_Internalname, tblSpacetable1_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, " ", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WP_ResidentDiscussion.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_21_7N2e( true) ;
         }
         else
         {
            wb_table1_21_7N2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV13DiscussionRecordId = (string)getParm(obj,0);
         AssignAttri("", false, "AV13DiscussionRecordId", AV13DiscussionRecordId);
         GxWebStd.gx_hidden_field( context, "gxhash_vDISCUSSIONRECORDID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV13DiscussionRecordId, "")), context));
         AV18AccessToken = (string)getParm(obj,1);
         AssignAttri("", false, "AV18AccessToken", AV18AccessToken);
         GxWebStd.gx_hidden_field( context, "gxhash_vACCESSTOKEN", GetSecureSignedToken( "", AV18AccessToken, context));
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
         PA7N2( ) ;
         WS7N2( ) ;
         WE7N2( ) ;
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
         if ( ! ( WebComp_Discussioncomponent == null ) )
         {
            if ( StringUtil.Len( WebComp_Discussioncomponent_Component) != 0 )
            {
               WebComp_Discussioncomponent.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256201791946", true, true);
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
         context.AddJavascriptSource("wp_residentdiscussion.js", "?20256201791947", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         divTablecontent_Internalname = "TABLECONTENT";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         tblSpacetable1_Internalname = "SPACETABLE1";
         lblBanicon_Internalname = "BANICON";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         tblSpacetable2_Internalname = "SPACETABLE2";
         lblErrormessage_Internalname = "ERRORMESSAGE";
         divNorecordfoundtable_Internalname = "NORECORDFOUNDTABLE";
         divMaintable_Internalname = "MAINTABLE";
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
         tblSpacetable1_Height = 0;
         tblSpacetable2_Height = 0;
         lblErrormessage_Caption = context.GetMessage( "The discussion record could not be found", "");
         divNorecordfoundtable_Visible = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "WP_Resident Discussion", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV13DiscussionRecordId","fld":"vDISCUSSIONRECORDID","hsh":true},{"av":"AV18AccessToken","fld":"vACCESSTOKEN","hsh":true}]}""");
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
         wcpOAV13DiscussionRecordId = "";
         wcpOAV18AccessToken = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         WebComp_Discussioncomponent_Component = "";
         OldDiscussioncomponent = "";
         lblBanicon_Jsonclick = "";
         lblErrormessage_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV12WWPEntityName = "";
         AV19Description = "";
         AV9ResidentId = "";
         AV11WebSession = context.GetSession();
         H007N2_A62ResidentId = new Guid[] {Guid.Empty} ;
         H007N2_A29LocationId = new Guid[] {Guid.Empty} ;
         H007N2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H007N2_A71ResidentGUID = new string[] {""} ;
         H007N2_A599ResidentLanguage = new string[] {""} ;
         A71ResidentGUID = "";
         A599ResidentLanguage = "";
         AV22Language = "";
         AV16WWP_UserExtended = new GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended(context);
         AV14WWP_FormInstance = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         AV15WWPFormReferenceName = "";
         sStyleString = "";
         lblTextblock2_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_residentdiscussion__default(),
            new Object[][] {
                new Object[] {
               H007N2_A62ResidentId, H007N2_A29LocationId, H007N2_A11OrganisationId, H007N2_A71ResidentGUID, H007N2_A599ResidentLanguage
               }
            }
         );
         WebComp_Discussioncomponent = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV21NumericVariable ;
      private short nGXWrapped ;
      private int divNorecordfoundtable_Visible ;
      private int tblSpacetable2_Height ;
      private int tblSpacetable1_Height ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string WebComp_Discussioncomponent_Component ;
      private string OldDiscussioncomponent ;
      private string divNorecordfoundtable_Internalname ;
      private string lblBanicon_Internalname ;
      private string lblBanicon_Jsonclick ;
      private string lblErrormessage_Internalname ;
      private string lblErrormessage_Caption ;
      private string lblErrormessage_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string A599ResidentLanguage ;
      private string tblSpacetable2_Internalname ;
      private string tblSpacetable1_Internalname ;
      private string sStyleString ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV20isTokenValid ;
      private bool bDynCreated_Discussioncomponent ;
      private bool AV17ShowNoRecordFound ;
      private string AV18AccessToken ;
      private string wcpOAV18AccessToken ;
      private string AV13DiscussionRecordId ;
      private string wcpOAV13DiscussionRecordId ;
      private string AV12WWPEntityName ;
      private string AV19Description ;
      private string AV9ResidentId ;
      private string A71ResidentGUID ;
      private string AV22Language ;
      private string AV15WWPFormReferenceName ;
      private IGxSession AV11WebSession ;
      private GXWebComponent WebComp_Discussioncomponent ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] H007N2_A62ResidentId ;
      private Guid[] H007N2_A29LocationId ;
      private Guid[] H007N2_A11OrganisationId ;
      private string[] H007N2_A71ResidentGUID ;
      private string[] H007N2_A599ResidentLanguage ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended AV16WWP_UserExtended ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV14WWP_FormInstance ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wp_residentdiscussion__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH007N2;
          prmH007N2 = new Object[] {
          new ParDef("AV9ResidentId",GXType.VarChar,100,60)
          };
          def= new CursorDef[] {
              new CursorDef("H007N2", "SELECT ResidentId, LocationId, OrganisationId, ResidentGUID, ResidentLanguage FROM Trn_Resident WHERE ResidentGUID = ( :AV9ResidentId) ORDER BY ResidentId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007N2,1, GxCacheFrequency.OFF ,false,true )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                return;
       }
    }

 }

}
