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
   public class wp_apppreview : GXHttpHandler
   {
      public wp_apppreview( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("NoStyle", true);
      }

      public wp_apppreview( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AppVersionId )
      {
         this.AV9AppVersionId = aP0_AppVersionId;
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
            gxfirstwebparm = GetFirstPar( "AppVersionId");
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
               gxfirstwebparm = GetFirstPar( "AppVersionId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "AppVersionId");
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
               AV9AppVersionId = StringUtil.StrToGuid( gxfirstwebparm);
               AssignAttri("", false, "AV9AppVersionId", AV9AppVersionId.ToString());
               GxWebStd.gx_hidden_field( context, "gxhash_vAPPVERSIONID", GetSecureSignedToken( "", AV9AppVersionId, context));
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
            ValidateSpaRequest();
            PAB02( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WSB02( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WEB02( ) ;
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
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( context.GetMessage( "App Preview", "")) ;
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
         context.AddJavascriptSource("UserControls/UC_AppPreviewRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_apppreview.aspx", new object[] {UrlEncode(AV9AppVersionId.ToString())}, new string[] {"AppVersionId"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vAPPVERSIONID", AV9AppVersionId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vAPPVERSIONID", GetSecureSignedToken( "", AV9AppVersionId, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDT_APPPREVIEW", AV19SDT_AppPreview);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDT_APPPREVIEW", AV19SDT_AppPreview);
         }
         GxWebStd.gx_hidden_field( context, "vAPPVERSIONID", AV9AppVersionId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vAPPVERSIONID", GetSecureSignedToken( "", AV9AppVersionId, context));
      }

      protected void RenderHtmlCloseFormB02( )
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
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
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "WP_AppPreview" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "App Preview", "") ;
      }

      protected void WBB00( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucApppreview.SetProperty("AppVersion", AV19SDT_AppPreview);
            ucApppreview.Render(context, "uc_apppreview", Apppreview_Internalname, "APPPREVIEWContainer");
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

      protected void STARTB02( )
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
         Form.Meta.addItem("description", context.GetMessage( "App Preview", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPB00( ) ;
      }

      protected void WSB02( )
      {
         STARTB02( ) ;
         EVTB02( ) ;
      }

      protected void EVTB02( )
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
                           E11B02 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E12B02 ();
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
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void WEB02( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseFormB02( ) ;
            }
         }
      }

      protected void PAB02( )
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
         RFB02( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFB02( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E12B02 ();
            WBB00( ) ;
         }
      }

      protected void send_integrity_lvl_hashesB02( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUPB00( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11B02 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vSDT_APPPREVIEW"), AV19SDT_AppPreview);
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
         E11B02 ();
         if (returnInSub) return;
      }

      protected void E11B02( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Headerrawhtml = Form.Headerrawhtml+"<link rel=\"stylesheet\" href=\"/Resources/AppPreview/public/styles.css\">"+"<link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css\" integrity=\"sha512-DTOQO9RWCH3ppGqcWaEA1BIZOC6xxalwEsw9c2QQeAIftl+Vegovlnee1c9QX4TctnWMn13TZye+giMm8e2LwA==\" crossorigin=\"anonymous\" referrerpolicy=\"no-referrer\" />"+"<link rel=\"stylesheet\" href=\"https://fonts.googleapis.com/css2?family=Inter:opsz@14..32&family=Roboto:ital,wght@0,100..900;1,100..900&display=swap\" >"+"<script type=\"module\" src=\"/Resources/AppPreview/dist/bundle.js\"></script>";
         AV8BC_Trn_AppVersion = new SdtTrn_AppVersion(context);
         AV8BC_Trn_AppVersion.Load(AV9AppVersionId);
         new prc_loadappversionsdt(context ).execute(  AV8BC_Trn_AppVersion, out  AV7SDT_AppVersion) ;
         AV19SDT_AppPreview = new SdtSDT_AppPreviewVersion(context);
         AV19SDT_AppPreview.gxTpr_Appversionid = AV7SDT_AppVersion.gxTpr_Appversionid;
         AV19SDT_AppPreview.gxTpr_Appversionname = AV7SDT_AppVersion.gxTpr_Appversionname;
         AV19SDT_AppPreview.gxTpr_Pages.FromJSonString(AV7SDT_AppVersion.gxTpr_Pages.ToJSonString(false), null);
         AV19SDT_AppPreview.gxTpr_Locationid = AV8BC_Trn_AppVersion.gxTpr_Locationid;
         /* Using cursor H00B02 */
         pr_default.execute(0, new Object[] {AV8BC_Trn_AppVersion.gxTpr_Locationid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = H00B02_A11OrganisationId[0];
            A584ActiveAppVersionId = H00B02_A584ActiveAppVersionId[0];
            n584ActiveAppVersionId = H00B02_n584ActiveAppVersionId[0];
            A598PublishedActiveAppVersionId = H00B02_A598PublishedActiveAppVersionId[0];
            n598PublishedActiveAppVersionId = H00B02_n598PublishedActiveAppVersionId[0];
            A29LocationId = H00B02_A29LocationId[0];
            A40000OrganisationLogo_GXI = H00B02_A40000OrganisationLogo_GXI[0];
            A40000OrganisationLogo_GXI = H00B02_A40000OrganisationLogo_GXI[0];
            /* Using cursor H00B03 */
            pr_default.execute(1, new Object[] {n598PublishedActiveAppVersionId, A598PublishedActiveAppVersionId});
            A273Trn_ThemeId = H00B03_A273Trn_ThemeId[0];
            pr_default.close(1);
            /* Using cursor H00B04 */
            pr_default.execute(2, new Object[] {n584ActiveAppVersionId, A584ActiveAppVersionId});
            A273Trn_ThemeId = H00B04_A273Trn_ThemeId[0];
            pr_default.close(2);
            AV11Current_Theme = A273Trn_ThemeId;
            AV19SDT_AppPreview.gxTpr_Organisationlogo = A40000OrganisationLogo_GXI;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         pr_default.close(2);
         GXt_objcol_SdtTrn_Theme1 = AV20Themes;
         new prc_getorganisationtheme(context ).execute(  AV8BC_Trn_AppVersion.gxTpr_Organisationid,  AV8BC_Trn_AppVersion.gxTpr_Locationid, out  AV25Icons, out  GXt_objcol_SdtTrn_Theme1) ;
         AV20Themes = GXt_objcol_SdtTrn_Theme1;
         AV27GXV1 = 1;
         while ( AV27GXV1 <= AV20Themes.Count )
         {
            AV21Theme = ((SdtTrn_Theme)AV20Themes.Item(AV27GXV1));
            if ( AV21Theme.gxTpr_Trn_themeid == AV11Current_Theme )
            {
               AV14SDT_Theme = new SdtSDT_Theme(context);
               AV14SDT_Theme.gxTpr_Themeid = AV21Theme.gxTpr_Trn_themeid;
               AV14SDT_Theme.gxTpr_Themename = AV21Theme.gxTpr_Trn_themename;
               AV14SDT_Theme.gxTpr_Themefontfamily = AV21Theme.gxTpr_Trn_themefontfamily;
               AV14SDT_Theme.gxTpr_Themefontsize = AV21Theme.gxTpr_Trn_themefontsize;
               AV28GXV2 = 1;
               while ( AV28GXV2 <= AV21Theme.gxTpr_Color.Count )
               {
                  AV23ThemeColor = ((SdtTrn_Theme_Color)AV21Theme.gxTpr_Color.Item(AV28GXV2));
                  AV15SDT_ThemeColor = new SdtSDT_Theme_ColorsItem(context);
                  AV15SDT_ThemeColor.gxTpr_Colorid = AV23ThemeColor.gxTpr_Colorid;
                  AV15SDT_ThemeColor.gxTpr_Colorname = AV23ThemeColor.gxTpr_Colorname;
                  AV15SDT_ThemeColor.gxTpr_Colorcode = AV23ThemeColor.gxTpr_Colorcode;
                  AV14SDT_Theme.gxTpr_Colors.Add(AV15SDT_ThemeColor, 0);
                  AV28GXV2 = (int)(AV28GXV2+1);
               }
               AV29GXV3 = 1;
               while ( AV29GXV3 <= AV21Theme.gxTpr_Icon.Count )
               {
                  AV22ThemeIcon = ((SdtTrn_Theme_Icon)AV21Theme.gxTpr_Icon.Item(AV29GXV3));
                  AV16SDT_ThemeIcon = new SdtSDT_Theme_IconsItem(context);
                  AV16SDT_ThemeIcon.gxTpr_Iconid = AV22ThemeIcon.gxTpr_Iconid;
                  AV16SDT_ThemeIcon.gxTpr_Iconname = AV22ThemeIcon.gxTpr_Iconname;
                  AV16SDT_ThemeIcon.gxTpr_Iconsvg = AV22ThemeIcon.gxTpr_Iconsvg;
                  AV16SDT_ThemeIcon.gxTpr_Iconcategory = AV22ThemeIcon.gxTpr_Iconcategory;
                  AV14SDT_Theme.gxTpr_Icons.Add(AV16SDT_ThemeIcon, 0);
                  AV29GXV3 = (int)(AV29GXV3+1);
               }
               AV30GXV4 = 1;
               while ( AV30GXV4 <= AV21Theme.gxTpr_Ctacolor.Count )
               {
                  AV24ThemeCtaColor = ((SdtTrn_Theme_CtaColor)AV21Theme.gxTpr_Ctacolor.Item(AV30GXV4));
                  AV18SDT_ThemeCtaColor = new SdtSDT_Theme_CtaColorsItem(context);
                  AV18SDT_ThemeCtaColor.gxTpr_Ctacolorid = AV24ThemeCtaColor.gxTpr_Ctacolorid;
                  AV18SDT_ThemeCtaColor.gxTpr_Ctacolorname = AV24ThemeCtaColor.gxTpr_Ctacolorname;
                  AV18SDT_ThemeCtaColor.gxTpr_Ctacolorcode = AV24ThemeCtaColor.gxTpr_Ctacolorcode;
                  AV14SDT_Theme.gxTpr_Ctacolors.Add(AV18SDT_ThemeCtaColor, 0);
                  AV30GXV4 = (int)(AV30GXV4+1);
               }
            }
            AV27GXV1 = (int)(AV27GXV1+1);
         }
         AV19SDT_AppPreview.gxTpr_Sdt_theme.FromJSonString(AV14SDT_Theme.ToJSonString(false, true), null);
      }

      protected void nextLoad( )
      {
      }

      protected void E12B02( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV9AppVersionId = (Guid)getParm(obj,0);
         AssignAttri("", false, "AV9AppVersionId", AV9AppVersionId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vAPPVERSIONID", GetSecureSignedToken( "", AV9AppVersionId, context));
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
         PAB02( ) ;
         WSB02( ) ;
         WEB02( ) ;
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
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20257213145046", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages."+StringUtil.Lower( context.GetLanguageProperty( "code"))+".js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("wp_apppreview.js", "?20257213145046", false, true);
            context.AddJavascriptSource("UserControls/UC_AppPreviewRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         Apppreview_Internalname = "APPPREVIEW";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("NoStyle", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV9AppVersionId","fld":"vAPPVERSIONID","hsh":true}]}""");
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

      protected override void CloseCursors( )
      {
         pr_default.close(1);
      }

      public override void initialize( )
      {
         wcpOAV9AppVersionId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV19SDT_AppPreview = new SdtSDT_AppPreviewVersion(context);
         GX_FocusControl = "";
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucApppreview = new GXUserControl();
         Form = new GXWebForm();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV8BC_Trn_AppVersion = new SdtTrn_AppVersion(context);
         AV7SDT_AppVersion = new SdtSDT_AppVersion(context);
         H00B02_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00B02_A584ActiveAppVersionId = new Guid[] {Guid.Empty} ;
         H00B02_n584ActiveAppVersionId = new bool[] {false} ;
         H00B02_A598PublishedActiveAppVersionId = new Guid[] {Guid.Empty} ;
         H00B02_n598PublishedActiveAppVersionId = new bool[] {false} ;
         H00B02_A29LocationId = new Guid[] {Guid.Empty} ;
         H00B02_A40000OrganisationLogo_GXI = new string[] {""} ;
         A11OrganisationId = Guid.Empty;
         A584ActiveAppVersionId = Guid.Empty;
         A598PublishedActiveAppVersionId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A40000OrganisationLogo_GXI = "";
         H00B03_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         A273Trn_ThemeId = Guid.Empty;
         H00B04_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         AV11Current_Theme = Guid.Empty;
         AV20Themes = new GXBCCollection<SdtTrn_Theme>( context, "Trn_Theme", "Comforta_version2");
         GXt_objcol_SdtTrn_Theme1 = new GXBCCollection<SdtTrn_Theme>( context, "Trn_Theme", "Comforta_version2");
         AV25Icons = new GXBaseCollection<SdtSDT_Icon>( context, "SDT_Icon", "Comforta_version2");
         AV21Theme = new SdtTrn_Theme(context);
         AV14SDT_Theme = new SdtSDT_Theme(context);
         AV23ThemeColor = new SdtTrn_Theme_Color(context);
         AV15SDT_ThemeColor = new SdtSDT_Theme_ColorsItem(context);
         AV22ThemeIcon = new SdtTrn_Theme_Icon(context);
         AV16SDT_ThemeIcon = new SdtSDT_Theme_IconsItem(context);
         AV24ThemeCtaColor = new SdtTrn_Theme_CtaColor(context);
         AV18SDT_ThemeCtaColor = new SdtSDT_Theme_CtaColorsItem(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_apppreview__default(),
            new Object[][] {
                new Object[] {
               H00B02_A11OrganisationId, H00B02_A584ActiveAppVersionId, H00B02_n584ActiveAppVersionId, H00B02_A598PublishedActiveAppVersionId, H00B02_n598PublishedActiveAppVersionId, H00B02_A29LocationId, H00B02_A40000OrganisationLogo_GXI
               }
               , new Object[] {
               H00B03_A273Trn_ThemeId
               }
               , new Object[] {
               H00B04_A273Trn_ThemeId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private int AV27GXV1 ;
      private int AV28GXV2 ;
      private int AV29GXV3 ;
      private int AV30GXV4 ;
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
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Apppreview_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n584ActiveAppVersionId ;
      private bool n598PublishedActiveAppVersionId ;
      private string A40000OrganisationLogo_GXI ;
      private Guid AV9AppVersionId ;
      private Guid wcpOAV9AppVersionId ;
      private Guid A11OrganisationId ;
      private Guid A584ActiveAppVersionId ;
      private Guid A598PublishedActiveAppVersionId ;
      private Guid A29LocationId ;
      private Guid A273Trn_ThemeId ;
      private Guid AV11Current_Theme ;
      private GXUserControl ucApppreview ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_AppPreviewVersion AV19SDT_AppPreview ;
      private SdtTrn_AppVersion AV8BC_Trn_AppVersion ;
      private SdtSDT_AppVersion AV7SDT_AppVersion ;
      private IDataStoreProvider pr_default ;
      private Guid[] H00B02_A11OrganisationId ;
      private Guid[] H00B02_A584ActiveAppVersionId ;
      private bool[] H00B02_n584ActiveAppVersionId ;
      private Guid[] H00B02_A598PublishedActiveAppVersionId ;
      private bool[] H00B02_n598PublishedActiveAppVersionId ;
      private Guid[] H00B02_A29LocationId ;
      private string[] H00B02_A40000OrganisationLogo_GXI ;
      private Guid[] H00B03_A273Trn_ThemeId ;
      private Guid[] H00B04_A273Trn_ThemeId ;
      private GXBCCollection<SdtTrn_Theme> AV20Themes ;
      private GXBCCollection<SdtTrn_Theme> GXt_objcol_SdtTrn_Theme1 ;
      private GXBaseCollection<SdtSDT_Icon> AV25Icons ;
      private SdtTrn_Theme AV21Theme ;
      private SdtSDT_Theme AV14SDT_Theme ;
      private SdtTrn_Theme_Color AV23ThemeColor ;
      private SdtSDT_Theme_ColorsItem AV15SDT_ThemeColor ;
      private SdtTrn_Theme_Icon AV22ThemeIcon ;
      private SdtSDT_Theme_IconsItem AV16SDT_ThemeIcon ;
      private SdtTrn_Theme_CtaColor AV24ThemeCtaColor ;
      private SdtSDT_Theme_CtaColorsItem AV18SDT_ThemeCtaColor ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wp_apppreview__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00B02;
          prmH00B02 = new Object[] {
          new ParDef("AV8BC_Tr_1Locationid",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmH00B03;
          prmH00B03 = new Object[] {
          new ParDef("PublishedActiveAppVersionId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmH00B04;
          prmH00B04 = new Object[] {
          new ParDef("ActiveAppVersionId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("H00B02", "SELECT T1.OrganisationId, T1.ActiveAppVersionId, T1.PublishedActiveAppVersionId, T1.LocationId, T2.OrganisationLogo_GXI FROM (Trn_Location T1 INNER JOIN Trn_Organisation T2 ON T2.OrganisationId = T1.OrganisationId) WHERE T1.LocationId = :AV8BC_Tr_1Locationid ORDER BY T1.LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00B02,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00B03", "SELECT Trn_ThemeId FROM Trn_AppVersion WHERE AppVersionId = :PublishedActiveAppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00B03,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00B04", "SELECT Trn_ThemeId FROM Trn_AppVersion WHERE AppVersionId = :ActiveAppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00B04,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((Guid[]) buf[5])[0] = rslt.getGuid(4);
                ((string[]) buf[6])[0] = rslt.getMultimediaUri(5);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
       }
    }

 }

}
