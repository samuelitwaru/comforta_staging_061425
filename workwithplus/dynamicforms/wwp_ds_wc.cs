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
   public class wwp_ds_wc : GXWebComponent
   {
      public wwp_ds_wc( )
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

      public wwp_ds_wc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_SessionId ,
                           string aP1_WWPFormReferenceName ,
                           string aP2_WWPFormContainerReferenceId ,
                           string aP3_WWPFormInstanceRecordKey ,
                           string aP4_Gx_mode )
      {
         this.AV5SessionId = aP0_SessionId;
         this.AV14WWPFormReferenceName = aP1_WWPFormReferenceName;
         this.AV25WWPFormContainerReferenceId = aP2_WWPFormContainerReferenceId;
         this.AV24WWPFormInstanceRecordKey = aP3_WWPFormInstanceRecordKey;
         this.Gx_mode = aP4_Gx_mode;
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
               gxfirstwebparm = GetFirstPar( "SessionId");
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
                  AV5SessionId = (short)(Math.Round(NumberUtil.Val( GetPar( "SessionId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV5SessionId", StringUtil.LTrimStr( (decimal)(AV5SessionId), 4, 0));
                  AV14WWPFormReferenceName = GetPar( "WWPFormReferenceName");
                  AssignAttri(sPrefix, false, "AV14WWPFormReferenceName", AV14WWPFormReferenceName);
                  AV25WWPFormContainerReferenceId = GetPar( "WWPFormContainerReferenceId");
                  AssignAttri(sPrefix, false, "AV25WWPFormContainerReferenceId", AV25WWPFormContainerReferenceId);
                  AV24WWPFormInstanceRecordKey = GetPar( "WWPFormInstanceRecordKey");
                  AssignAttri(sPrefix, false, "AV24WWPFormInstanceRecordKey", AV24WWPFormInstanceRecordKey);
                  Gx_mode = GetPar( "Mode");
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)AV5SessionId,(string)AV14WWPFormReferenceName,(string)AV25WWPFormContainerReferenceId,(string)AV24WWPFormInstanceRecordKey,(string)Gx_mode});
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
                  gxfirstwebparm = GetFirstPar( "SessionId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "SessionId");
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
            PA382( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS382( ) ;
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
            context.SendWebValue( context.GetMessage( "Dynamic Section", "")) ;
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
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_ds_wc.aspx"+UrlEncode(StringUtil.LTrimStr(AV5SessionId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV14WWPFormReferenceName)) + "," + UrlEncode(StringUtil.RTrim(AV25WWPFormContainerReferenceId)) + "," + UrlEncode(StringUtil.RTrim(AV24WWPFormInstanceRecordKey)) + "," + UrlEncode(StringUtil.RTrim(Gx_mode));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.dynamicforms.wwp_ds_wc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV5SessionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV5SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV14WWPFormReferenceName", wcpOAV14WWPFormReferenceName);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV25WWPFormContainerReferenceId", wcpOAV25WWPFormContainerReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV24WWPFormInstanceRecordKey", wcpOAV24WWPFormInstanceRecordKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMREFERENCENAME", AV14WWPFormReferenceName);
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMCONTAINERREFERENCEID", AV25WWPFormContainerReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMINSTANCERECORDKEY", AV24WWPFormInstanceRecordKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"vMODE", StringUtil.RTrim( Gx_mode));
      }

      protected void RenderHtmlCloseForm382( )
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
            if ( ! ( WebComp_Wcwwp_dynamicformfs_wc == null ) )
            {
               WebComp_Wcwwp_dynamicformfs_wc.componentjscripts();
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
         return "WorkWithPlus.DynamicForms.WWP_DS_WC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Dynamic Section", "") ;
      }

      protected void WB380( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "workwithplus.dynamicforms.wwp_ds_wc.aspx");
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainDynamicForm", "start", "top", "", "", "div");
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
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WorkWithPlus/DynamicForms/WWP_DS_WC.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, sPrefix+"W0016"+"", StringUtil.RTrim( WebComp_Wcwwp_dynamicformfs_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0016"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcwwp_dynamicformfs_wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwwp_dynamicformfs_wc), StringUtil.Lower( WebComp_Wcwwp_dynamicformfs_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0016"+"");
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
            context.WriteHtmlText( "</fieldset>") ;
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
            GxWebStd.gx_single_line_edit( context, edtavSessionid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5SessionId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSessionid_Jsonclick, 0, "Attribute", "", "", "", "", edtavSessionid_Visible, 0, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkWithPlus/DynamicForms/WWP_DS_WC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START382( )
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
            Form.Meta.addItem("description", context.GetMessage( "Dynamic Section", ""), 0) ;
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
               STRUP380( ) ;
            }
         }
      }

      protected void WS382( )
      {
         START382( ) ;
         EVT382( ) ;
      }

      protected void EVT382( )
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
                                 STRUP380( ) ;
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
                                 STRUP380( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11382 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP380( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E12382 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP380( ) ;
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
                                 STRUP380( ) ;
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
                        if ( nCmpId == 16 )
                        {
                           OldWcwwp_dynamicformfs_wc = cgiGet( sPrefix+"W0016");
                           if ( ( StringUtil.Len( OldWcwwp_dynamicformfs_wc) == 0 ) || ( StringUtil.StrCmp(OldWcwwp_dynamicformfs_wc, WebComp_Wcwwp_dynamicformfs_wc_Component) != 0 ) )
                           {
                              WebComp_Wcwwp_dynamicformfs_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWcwwp_dynamicformfs_wc, new Object[] {context} );
                              WebComp_Wcwwp_dynamicformfs_wc.ComponentInit();
                              WebComp_Wcwwp_dynamicformfs_wc.Name = "OldWcwwp_dynamicformfs_wc";
                              WebComp_Wcwwp_dynamicformfs_wc_Component = OldWcwwp_dynamicformfs_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wcwwp_dynamicformfs_wc_Component) != 0 )
                           {
                              WebComp_Wcwwp_dynamicformfs_wc.componentprocess(sPrefix+"W0016", "", sEvt);
                           }
                           WebComp_Wcwwp_dynamicformfs_wc_Component = OldWcwwp_dynamicformfs_wc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE382( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm382( ) ;
            }
         }
      }

      protected void PA382( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.dynamicforms.wwp_ds_wc.aspx")), "workwithplus.dynamicforms.wwp_ds_wc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.dynamicforms.wwp_ds_wc.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "SessionId");
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
         RF382( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF382( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
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
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E12382 ();
            WB380( ) ;
         }
      }

      protected void send_integrity_lvl_hashes382( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP380( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11382 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOAV5SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV5SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV14WWPFormReferenceName = cgiGet( sPrefix+"wcpOAV14WWPFormReferenceName");
            wcpOAV25WWPFormContainerReferenceId = cgiGet( sPrefix+"wcpOAV25WWPFormContainerReferenceId");
            wcpOAV24WWPFormInstanceRecordKey = cgiGet( sPrefix+"wcpOAV24WWPFormInstanceRecordKey");
            wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
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
         E11382 ();
         if (returnInSub) return;
      }

      protected void E11382( )
      {
         /* Start Routine */
         returnInSub = false;
         AV8WWPDynamicFormMode = Gx_mode;
         AssignAttri(sPrefix, false, "AV8WWPDynamicFormMode", AV8WWPDynamicFormMode);
         if ( StringUtil.StrCmp(AV10HttpRequest.Method, "GET") == 0 )
         {
            AV7WWPFormInstance = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
            GXt_SdtWWP_FormInstance1 = AV7WWPFormInstance;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadforminstance(context ).execute(  AV5SessionId, out  GXt_SdtWWP_FormInstance1) ;
            AV7WWPFormInstance = GXt_SdtWWP_FormInstance1;
            /* Execute user subroutine: 'INITIALIZE WC' */
            S112 ();
            if (returnInSub) return;
         }
         edtavSessionid_Visible = 0;
         AssignProp(sPrefix, false, edtavSessionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSessionid_Visible), 5, 0), true);
         if ( ( StringUtil.StrCmp(AV8WWPDynamicFormMode, "INS") == 0 ) || ( StringUtil.StrCmp(AV8WWPDynamicFormMode, "UPD") == 0 ) )
         {
            divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
            AssignProp(sPrefix, false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         }
      }

      protected void S112( )
      {
         /* 'INITIALIZE WC' Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(AV8WWPDynamicFormMode, "DSP") == 0 ) && ( AV7WWPFormInstance.gxTpr_Wwpformid == 0 ) )
         {
            /* Using cursor H00382 */
            pr_default.execute(0, new Object[] {AV24WWPFormInstanceRecordKey, AV14WWPFormReferenceName});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A206WWPFormId = H00382_A206WWPFormId[0];
               A207WWPFormVersionNumber = H00382_A207WWPFormVersionNumber[0];
               A208WWPFormReferenceName = H00382_A208WWPFormReferenceName[0];
               A243WWPFormInstanceRecordKey = H00382_A243WWPFormInstanceRecordKey[0];
               n243WWPFormInstanceRecordKey = H00382_n243WWPFormInstanceRecordKey[0];
               A214WWPFormInstanceId = H00382_A214WWPFormInstanceId[0];
               A208WWPFormReferenceName = H00382_A208WWPFormReferenceName[0];
               AV9WWPFormInstanceId = A214WWPFormInstanceId;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( AV9WWPFormInstanceId > 0 )
            {
               AV7WWPFormInstance.Load(AV9WWPFormInstanceId);
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_saveforminstance(context ).execute(  AV5SessionId,  AV7WWPFormInstance) ;
            }
         }
         else
         {
            /* Using cursor H00383 */
            pr_default.execute(1, new Object[] {AV7WWPFormInstance.gxTpr_Wwpformid, AV7WWPFormInstance.gxTpr_Wwpformversionnumber, AV25WWPFormContainerReferenceId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A213WWPFormElementReferenceId = H00383_A213WWPFormElementReferenceId[0];
               A207WWPFormVersionNumber = H00383_A207WWPFormVersionNumber[0];
               A206WWPFormId = H00383_A206WWPFormId[0];
               A210WWPFormElementId = H00383_A210WWPFormElementId[0];
               AV26WWPFormElementId = A210WWPFormElementId;
               AssignAttri(sPrefix, false, "AV26WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV26WWPFormElementId), 4, 0));
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         /* Object Property */
         if ( StringUtil.Len( sPrefix) == 0 )
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
            WebComp_Wcwwp_dynamicformfs_wc.componentprepare(new Object[] {(string)sPrefix+"W0016",(string)"",(string)AV8WWPDynamicFormMode,(short)AV26WWPFormElementId,(short)0,(short)AV5SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV7WWPFormInstance});
            WebComp_Wcwwp_dynamicformfs_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)sPrefix+"vSESSIONID",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcwwp_dynamicformfs_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0016"+"");
            WebComp_Wcwwp_dynamicformfs_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E12382( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV5SessionId = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV5SessionId", StringUtil.LTrimStr( (decimal)(AV5SessionId), 4, 0));
         AV14WWPFormReferenceName = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV14WWPFormReferenceName", AV14WWPFormReferenceName);
         AV25WWPFormContainerReferenceId = (string)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV25WWPFormContainerReferenceId", AV25WWPFormContainerReferenceId);
         AV24WWPFormInstanceRecordKey = (string)getParm(obj,3);
         AssignAttri(sPrefix, false, "AV24WWPFormInstanceRecordKey", AV24WWPFormInstanceRecordKey);
         Gx_mode = (string)getParm(obj,4);
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
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
         PA382( ) ;
         WS382( ) ;
         WE382( ) ;
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
         sCtrlAV5SessionId = (string)((string)getParm(obj,0));
         sCtrlAV14WWPFormReferenceName = (string)((string)getParm(obj,1));
         sCtrlAV25WWPFormContainerReferenceId = (string)((string)getParm(obj,2));
         sCtrlAV24WWPFormInstanceRecordKey = (string)((string)getParm(obj,3));
         sCtrlGx_mode = (string)((string)getParm(obj,4));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA382( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "workwithplus\\dynamicforms\\wwp_ds_wc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA382( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV5SessionId = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV5SessionId", StringUtil.LTrimStr( (decimal)(AV5SessionId), 4, 0));
            AV14WWPFormReferenceName = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV14WWPFormReferenceName", AV14WWPFormReferenceName);
            AV25WWPFormContainerReferenceId = (string)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV25WWPFormContainerReferenceId", AV25WWPFormContainerReferenceId);
            AV24WWPFormInstanceRecordKey = (string)getParm(obj,5);
            AssignAttri(sPrefix, false, "AV24WWPFormInstanceRecordKey", AV24WWPFormInstanceRecordKey);
            Gx_mode = (string)getParm(obj,6);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         wcpOAV5SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV5SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV14WWPFormReferenceName = cgiGet( sPrefix+"wcpOAV14WWPFormReferenceName");
         wcpOAV25WWPFormContainerReferenceId = cgiGet( sPrefix+"wcpOAV25WWPFormContainerReferenceId");
         wcpOAV24WWPFormInstanceRecordKey = cgiGet( sPrefix+"wcpOAV24WWPFormInstanceRecordKey");
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         if ( ! GetJustCreated( ) && ( ( AV5SessionId != wcpOAV5SessionId ) || ( StringUtil.StrCmp(AV14WWPFormReferenceName, wcpOAV14WWPFormReferenceName) != 0 ) || ( StringUtil.StrCmp(AV25WWPFormContainerReferenceId, wcpOAV25WWPFormContainerReferenceId) != 0 ) || ( StringUtil.StrCmp(AV24WWPFormInstanceRecordKey, wcpOAV24WWPFormInstanceRecordKey) != 0 ) || ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOAV5SessionId = AV5SessionId;
         wcpOAV14WWPFormReferenceName = AV14WWPFormReferenceName;
         wcpOAV25WWPFormContainerReferenceId = AV25WWPFormContainerReferenceId;
         wcpOAV24WWPFormInstanceRecordKey = AV24WWPFormInstanceRecordKey;
         wcpOGx_mode = Gx_mode;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
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
         sCtrlAV14WWPFormReferenceName = cgiGet( sPrefix+"AV14WWPFormReferenceName_CTRL");
         if ( StringUtil.Len( sCtrlAV14WWPFormReferenceName) > 0 )
         {
            AV14WWPFormReferenceName = cgiGet( sCtrlAV14WWPFormReferenceName);
            AssignAttri(sPrefix, false, "AV14WWPFormReferenceName", AV14WWPFormReferenceName);
         }
         else
         {
            AV14WWPFormReferenceName = cgiGet( sPrefix+"AV14WWPFormReferenceName_PARM");
         }
         sCtrlAV25WWPFormContainerReferenceId = cgiGet( sPrefix+"AV25WWPFormContainerReferenceId_CTRL");
         if ( StringUtil.Len( sCtrlAV25WWPFormContainerReferenceId) > 0 )
         {
            AV25WWPFormContainerReferenceId = cgiGet( sCtrlAV25WWPFormContainerReferenceId);
            AssignAttri(sPrefix, false, "AV25WWPFormContainerReferenceId", AV25WWPFormContainerReferenceId);
         }
         else
         {
            AV25WWPFormContainerReferenceId = cgiGet( sPrefix+"AV25WWPFormContainerReferenceId_PARM");
         }
         sCtrlAV24WWPFormInstanceRecordKey = cgiGet( sPrefix+"AV24WWPFormInstanceRecordKey_CTRL");
         if ( StringUtil.Len( sCtrlAV24WWPFormInstanceRecordKey) > 0 )
         {
            AV24WWPFormInstanceRecordKey = cgiGet( sCtrlAV24WWPFormInstanceRecordKey);
            AssignAttri(sPrefix, false, "AV24WWPFormInstanceRecordKey", AV24WWPFormInstanceRecordKey);
         }
         else
         {
            AV24WWPFormInstanceRecordKey = cgiGet( sPrefix+"AV24WWPFormInstanceRecordKey_PARM");
         }
         sCtrlGx_mode = cgiGet( sPrefix+"Gx_mode_CTRL");
         if ( StringUtil.Len( sCtrlGx_mode) > 0 )
         {
            Gx_mode = cgiGet( sCtrlGx_mode);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = cgiGet( sPrefix+"Gx_mode_PARM");
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
         PA382( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS382( ) ;
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
         WS382( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV5SessionId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV5SessionId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV5SessionId_CTRL", StringUtil.RTrim( sCtrlAV5SessionId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV14WWPFormReferenceName_PARM", AV14WWPFormReferenceName);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV14WWPFormReferenceName)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV14WWPFormReferenceName_CTRL", StringUtil.RTrim( sCtrlAV14WWPFormReferenceName));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV25WWPFormContainerReferenceId_PARM", AV25WWPFormContainerReferenceId);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV25WWPFormContainerReferenceId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV25WWPFormContainerReferenceId_CTRL", StringUtil.RTrim( sCtrlAV25WWPFormContainerReferenceId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV24WWPFormInstanceRecordKey_PARM", AV24WWPFormInstanceRecordKey);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV24WWPFormInstanceRecordKey)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV24WWPFormInstanceRecordKey_CTRL", StringUtil.RTrim( sCtrlAV24WWPFormInstanceRecordKey));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"Gx_mode_PARM", StringUtil.RTrim( Gx_mode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlGx_mode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"Gx_mode_CTRL", StringUtil.RTrim( sCtrlGx_mode));
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
         WE382( ) ;
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
         if ( ! ( WebComp_Wcwwp_dynamicformfs_wc == null ) )
         {
            WebComp_Wcwwp_dynamicformfs_wc.componentjscripts();
         }
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wcwwp_dynamicformfs_wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcwwp_dynamicformfs_wc_Component) != 0 )
            {
               WebComp_Wcwwp_dynamicformfs_wc.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025630936671", true, true);
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
         context.AddJavascriptSource("workwithplus/dynamicforms/wwp_ds_wc.js", "?2025630936671", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         grpUnnamedgroup1_Internalname = sPrefix+"UNNAMEDGROUP1";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavSessionid_Internalname = sPrefix+"vSESSIONID";
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
         edtavSessionid_Jsonclick = "";
         edtavSessionid_Visible = 1;
         divLayoutmaintable_Class = "Table TableTransactionTemplate";
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
         wcpOAV14WWPFormReferenceName = "";
         wcpOAV25WWPFormContainerReferenceId = "";
         wcpOAV24WWPFormInstanceRecordKey = "";
         wcpOGx_mode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         WebComp_Wcwwp_dynamicformfs_wc_Component = "";
         OldWcwwp_dynamicformfs_wc = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV8WWPDynamicFormMode = "";
         AV10HttpRequest = new GxHttpRequest( context);
         AV7WWPFormInstance = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         GXt_SdtWWP_FormInstance1 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         H00382_A206WWPFormId = new short[1] ;
         H00382_A207WWPFormVersionNumber = new short[1] ;
         H00382_A208WWPFormReferenceName = new string[] {""} ;
         H00382_A243WWPFormInstanceRecordKey = new string[] {""} ;
         H00382_n243WWPFormInstanceRecordKey = new bool[] {false} ;
         H00382_A214WWPFormInstanceId = new int[1] ;
         A208WWPFormReferenceName = "";
         A243WWPFormInstanceRecordKey = "";
         H00383_A213WWPFormElementReferenceId = new string[] {""} ;
         H00383_A207WWPFormVersionNumber = new short[1] ;
         H00383_A206WWPFormId = new short[1] ;
         H00383_A210WWPFormElementId = new short[1] ;
         A213WWPFormElementReferenceId = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV5SessionId = "";
         sCtrlAV14WWPFormReferenceName = "";
         sCtrlAV25WWPFormContainerReferenceId = "";
         sCtrlAV24WWPFormInstanceRecordKey = "";
         sCtrlGx_mode = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_ds_wc__default(),
            new Object[][] {
                new Object[] {
               H00382_A206WWPFormId, H00382_A207WWPFormVersionNumber, H00382_A208WWPFormReferenceName, H00382_A243WWPFormInstanceRecordKey, H00382_n243WWPFormInstanceRecordKey, H00382_A214WWPFormInstanceId
               }
               , new Object[] {
               H00383_A213WWPFormElementReferenceId, H00383_A207WWPFormVersionNumber, H00383_A206WWPFormId, H00383_A210WWPFormElementId
               }
            }
         );
         WebComp_Wcwwp_dynamicformfs_wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short AV5SessionId ;
      private short wcpOAV5SessionId ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private short A210WWPFormElementId ;
      private short AV26WWPFormElementId ;
      private short nGXWrapped ;
      private int edtavSessionid_Visible ;
      private int A214WWPFormInstanceId ;
      private int AV9WWPFormInstanceId ;
      private int idxLst ;
      private string Gx_mode ;
      private string wcpOGx_mode ;
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
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTablecontent_Internalname ;
      private string WebComp_Wcwwp_dynamicformfs_wc_Component ;
      private string OldWcwwp_dynamicformfs_wc ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavSessionid_Internalname ;
      private string edtavSessionid_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string AV8WWPDynamicFormMode ;
      private string sCtrlAV5SessionId ;
      private string sCtrlAV14WWPFormReferenceName ;
      private string sCtrlAV25WWPFormContainerReferenceId ;
      private string sCtrlAV24WWPFormInstanceRecordKey ;
      private string sCtrlGx_mode ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n243WWPFormInstanceRecordKey ;
      private bool bDynCreated_Wcwwp_dynamicformfs_wc ;
      private string AV24WWPFormInstanceRecordKey ;
      private string wcpOAV24WWPFormInstanceRecordKey ;
      private string A243WWPFormInstanceRecordKey ;
      private string AV14WWPFormReferenceName ;
      private string AV25WWPFormContainerReferenceId ;
      private string wcpOAV14WWPFormReferenceName ;
      private string wcpOAV25WWPFormContainerReferenceId ;
      private string A208WWPFormReferenceName ;
      private string A213WWPFormElementReferenceId ;
      private GXWebComponent WebComp_Wcwwp_dynamicformfs_wc ;
      private GXWebForm Form ;
      private GxHttpRequest AV10HttpRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV7WWPFormInstance ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance GXt_SdtWWP_FormInstance1 ;
      private IDataStoreProvider pr_default ;
      private short[] H00382_A206WWPFormId ;
      private short[] H00382_A207WWPFormVersionNumber ;
      private string[] H00382_A208WWPFormReferenceName ;
      private string[] H00382_A243WWPFormInstanceRecordKey ;
      private bool[] H00382_n243WWPFormInstanceRecordKey ;
      private int[] H00382_A214WWPFormInstanceId ;
      private string[] H00383_A213WWPFormElementReferenceId ;
      private short[] H00383_A207WWPFormVersionNumber ;
      private short[] H00383_A206WWPFormId ;
      private short[] H00383_A210WWPFormElementId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wwp_ds_wc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00382;
          prmH00382 = new Object[] {
          new ParDef("AV24WWPFormInstanceRecordKey",GXType.LongVarChar,2097152,0) ,
          new ParDef("AV14WWPFormReferenceName",GXType.VarChar,100,0)
          };
          Object[] prmH00383;
          prmH00383 = new Object[] {
          new ParDef("AV7WWPFormInstance__Wwpformid",GXType.Int16,4,0) ,
          new ParDef("AV7WWPFo_1Wwpformversionnumbe",GXType.Int16,4,0) ,
          new ParDef("AV25WWPFormContainerReferenceId",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00382", "SELECT T1.WWPFormId, T1.WWPFormVersionNumber, T2.WWPFormReferenceName, T1.WWPFormInstanceRecordKey, T1.WWPFormInstanceId FROM (WWP_FormInstance T1 INNER JOIN WWP_Form T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber) WHERE (T1.WWPFormInstanceRecordKey = ( :AV24WWPFormInstanceRecordKey)) AND (T2.WWPFormReferenceName = ( :AV14WWPFormReferenceName)) ORDER BY T1.WWPFormInstanceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00382,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H00383", "SELECT WWPFormElementReferenceId, WWPFormVersionNumber, WWPFormId, WWPFormElementId FROM WWP_FormElement WHERE (WWPFormId = :AV7WWPFormInstance__Wwpformid and WWPFormVersionNumber = :AV7WWPFo_1Wwpformversionnumbe) AND (WWPFormElementReferenceId = ( :AV25WWPFormContainerReferenceId)) ORDER BY WWPFormId, WWPFormVersionNumber ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00383,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
       }
    }

 }

}
