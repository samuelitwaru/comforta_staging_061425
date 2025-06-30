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
   public class wp_residentdynamicform : GXDataArea
   {
      public wp_residentdynamicform( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_residentdynamicform( IGxContext context )
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
                           string aP3_AccessToken )
      {
         this.AV7WWPFormReferenceName = aP0_WWPFormReferenceName;
         this.AV8WWPFormInstanceId = aP1_WWPFormInstanceId;
         this.AV9WWPDynamicFormMode = aP2_WWPDynamicFormMode;
         this.AV15AccessToken = aP3_AccessToken;
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
               AV7WWPFormReferenceName = gxfirstwebparm;
               AssignAttri("", false, "AV7WWPFormReferenceName", AV7WWPFormReferenceName);
               GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMREFERENCENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7WWPFormReferenceName, "")), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV8WWPFormInstanceId = (int)(Math.Round(NumberUtil.Val( GetPar( "WWPFormInstanceId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV8WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(AV8WWPFormInstanceId), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMINSTANCEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8WWPFormInstanceId), "ZZZZZ9"), context));
                  AV9WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
                  AssignAttri("", false, "AV9WWPDynamicFormMode", AV9WWPDynamicFormMode);
                  GxWebStd.gx_hidden_field( context, "gxhash_vWWPDYNAMICFORMMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9WWPDynamicFormMode, "")), context));
                  AV15AccessToken = GetPar( "AccessToken");
                  AssignAttri("", false, "AV15AccessToken", AV15AccessToken);
                  GxWebStd.gx_hidden_field( context, "gxhash_vACCESSTOKEN", GetSecureSignedToken( "", AV15AccessToken, context));
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
         PA7K2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START7K2( ) ;
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
         context.AddJavascriptSource("UserControls/UC_DynamicFormJSCSSRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal ResidentForm\" data-gx-class=\"form-horizontal ResidentForm\" novalidate action=\""+formatLink("wp_residentdynamicform.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV7WWPFormReferenceName)),UrlEncode(StringUtil.LTrimStr(AV8WWPFormInstanceId,6,0)),UrlEncode(StringUtil.RTrim(AV9WWPDynamicFormMode)),UrlEncode(StringUtil.RTrim(AV15AccessToken))}, new string[] {"WWPFormReferenceName","WWPFormInstanceId","WWPDynamicFormMode","AccessToken"}) +"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, "vSHOWLOADINGSTATE", AV17ShowLoadingState);
         GxWebStd.gx_hidden_field( context, "gxhash_vSHOWLOADINGSTATE", GetSecureSignedToken( "", AV17ShowLoadingState, context));
         GxWebStd.gx_boolean_hidden_field( context, "vSHOWNORECORDFOUND", AV14ShowNoRecordFound);
         GxWebStd.gx_hidden_field( context, "gxhash_vSHOWNORECORDFOUND", GetSecureSignedToken( "", AV14ShowNoRecordFound, context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMREFERENCENAME", AV7WWPFormReferenceName);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMREFERENCENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7WWPFormReferenceName, "")), context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMINSTANCEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8WWPFormInstanceId), 6, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMINSTANCEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8WWPFormInstanceId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV9WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPDYNAMICFORMMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9WWPDynamicFormMode, "")), context));
         GxWebStd.gx_hidden_field( context, "vACCESSTOKEN", AV15AccessToken);
         GxWebStd.gx_hidden_field( context, "gxhash_vACCESSTOKEN", GetSecureSignedToken( "", AV15AccessToken, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_boolean_hidden_field( context, "vSHOWLOADINGSTATE", AV17ShowLoadingState);
         GxWebStd.gx_hidden_field( context, "gxhash_vSHOWLOADINGSTATE", GetSecureSignedToken( "", AV17ShowLoadingState, context));
         GxWebStd.gx_boolean_hidden_field( context, "vSHOWNORECORDFOUND", AV14ShowNoRecordFound);
         GxWebStd.gx_hidden_field( context, "gxhash_vSHOWNORECORDFOUND", GetSecureSignedToken( "", AV14ShowNoRecordFound, context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMREFERENCENAME", AV7WWPFormReferenceName);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMREFERENCENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7WWPFormReferenceName, "")), context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMINSTANCEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8WWPFormInstanceId), 6, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMINSTANCEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8WWPFormInstanceId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV9WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPDYNAMICFORMMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9WWPDynamicFormMode, "")), context));
         GxWebStd.gx_hidden_field( context, "vACCESSTOKEN", AV15AccessToken);
         GxWebStd.gx_hidden_field( context, "gxhash_vACCESSTOKEN", GetSecureSignedToken( "", AV15AccessToken, context));
         GxWebStd.gx_hidden_field( context, "DYNAMICFORMJSCSS_Backgroundcolor", StringUtil.RTrim( Dynamicformjscss_Backgroundcolor));
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
         if ( ! ( WebComp_Wcwc_residentdynamicform == null ) )
         {
            WebComp_Wcwc_residentdynamicform.componentjscripts();
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
            WE7K2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT7K2( ) ;
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
         return formatLink("wp_residentdynamicform.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV7WWPFormReferenceName)),UrlEncode(StringUtil.LTrimStr(AV8WWPFormInstanceId,6,0)),UrlEncode(StringUtil.RTrim(AV9WWPDynamicFormMode)),UrlEncode(StringUtil.RTrim(AV15AccessToken))}, new string[] {"WWPFormReferenceName","WWPFormInstanceId","WWPDynamicFormMode","AccessToken"})  ;
      }

      public override string GetPgmname( )
      {
         return "WP_ResidentDynamicForm" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WP_Resident Dynamic Form", "") ;
      }

      protected void WB7K0( )
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
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
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0015"+"", StringUtil.RTrim( WebComp_Wcwc_residentdynamicform_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0015"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcwc_residentdynamicform_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwc_residentdynamicform), StringUtil.Lower( WebComp_Wcwc_residentdynamicform_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0015"+"");
                  }
                  WebComp_Wcwc_residentdynamicform.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwc_residentdynamicform), StringUtil.Lower( WebComp_Wcwc_residentdynamicform_Component)) != 0 )
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
            wb_table1_21_7K2( true) ;
         }
         else
         {
            wb_table1_21_7K2( false) ;
         }
         return  ;
      }

      protected void wb_table1_21_7K2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblBanicon_Internalname, context.GetMessage( "<i class='fas fa-ban' style='font-size: 50px'></i>", ""), "", "", lblBanicon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WP_ResidentDynamicForm.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table2_30_7K2( true) ;
         }
         else
         {
            wb_table2_30_7K2( false) ;
         }
         return  ;
      }

      protected void wb_table2_30_7K2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblErrormessage_Internalname, lblErrormessage_Caption, "", "", lblErrormessage_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WP_ResidentDynamicForm.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLoadertable_Internalname, divLoadertable_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgImage1_gximage, "")==0) ? "GX_Image_loaderA_Class" : "GX_Image_"+imgImage1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "e271ae3d-e9f9-4526-a23b-ea6d373d191b", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WP_ResidentDynamicForm.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDynamicformjscss.SetProperty("BackgroundColor", Dynamicformjscss_Backgroundcolor);
            ucDynamicformjscss.Render(context, "uc_dynamicformjscss", Dynamicformjscss_Internalname, "DYNAMICFORMJSCSSContainer");
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

      protected void START7K2( )
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
         Form.Meta.addItem("description", context.GetMessage( "WP_Resident Dynamic Form", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP7K0( ) ;
      }

      protected void WS7K2( )
      {
         START7K2( ) ;
         EVT7K2( ) ;
      }

      protected void EVT7K2( )
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
                              E117K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E127K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E137K2 ();
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
                           OldWcwc_residentdynamicform = cgiGet( "W0015");
                           if ( ( StringUtil.Len( OldWcwc_residentdynamicform) == 0 ) || ( StringUtil.StrCmp(OldWcwc_residentdynamicform, WebComp_Wcwc_residentdynamicform_Component) != 0 ) )
                           {
                              WebComp_Wcwc_residentdynamicform = getWebComponent(GetType(), "GeneXus.Programs", OldWcwc_residentdynamicform, new Object[] {context} );
                              WebComp_Wcwc_residentdynamicform.ComponentInit();
                              WebComp_Wcwc_residentdynamicform.Name = "OldWcwc_residentdynamicform";
                              WebComp_Wcwc_residentdynamicform_Component = OldWcwc_residentdynamicform;
                           }
                           if ( StringUtil.Len( WebComp_Wcwc_residentdynamicform_Component) != 0 )
                           {
                              WebComp_Wcwc_residentdynamicform.componentprocess("W0015", "", sEvt);
                           }
                           WebComp_Wcwc_residentdynamicform_Component = OldWcwc_residentdynamicform;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE7K2( )
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

      protected void PA7K2( )
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
         RF7K2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF7K2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E127K2 ();
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcwc_residentdynamicform_Component) != 0 )
               {
                  WebComp_Wcwc_residentdynamicform.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E137K2 ();
            WB7K0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes7K2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, "vSHOWLOADINGSTATE", AV17ShowLoadingState);
         GxWebStd.gx_hidden_field( context, "gxhash_vSHOWLOADINGSTATE", GetSecureSignedToken( "", AV17ShowLoadingState, context));
         GxWebStd.gx_boolean_hidden_field( context, "vSHOWNORECORDFOUND", AV14ShowNoRecordFound);
         GxWebStd.gx_hidden_field( context, "gxhash_vSHOWNORECORDFOUND", GetSecureSignedToken( "", AV14ShowNoRecordFound, context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7K0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E117K2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Dynamicformjscss_Backgroundcolor = cgiGet( "DYNAMICFORMJSCSS_Backgroundcolor");
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
         E117K2 ();
         if (returnInSub) return;
      }

      protected void E117K2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV17ShowLoadingState = true;
         AssignAttri("", false, "AV17ShowLoadingState", AV17ShowLoadingState);
         GxWebStd.gx_hidden_field( context, "gxhash_vSHOWLOADINGSTATE", GetSecureSignedToken( "", AV17ShowLoadingState, context));
         new prc_getuseridfromaccesstoken(context ).execute(  AV15AccessToken, out  AV11ResidentId, out  AV16isTokenValid) ;
         AssignAttri("", false, "AV11ResidentId", AV11ResidentId);
         if ( AV16isTokenValid )
         {
            /* Using cursor H007K2 */
            pr_default.execute(0, new Object[] {AV11ResidentId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A71ResidentGUID = H007K2_A71ResidentGUID[0];
               A599ResidentLanguage = H007K2_A599ResidentLanguage[0];
               A29LocationId = H007K2_A29LocationId[0];
               AV19Language = A599ResidentLanguage;
               AV22LocationId = A29LocationId;
               AssignAttri("", false, "AV22LocationId", AV22LocationId.ToString());
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( StringUtil.StrCmp(AV19Language, "en") == 0 )
            {
               AV18NumericVariable = (short)(context.SetLanguage( "English"));
            }
            else if ( StringUtil.StrCmp(AV19Language, "nl") == 0 )
            {
               AV18NumericVariable = (short)(context.SetLanguage( "Dutch"));
            }
            else
            {
               AV18NumericVariable = (short)(context.SetLanguage( "English"));
            }
            AV12WebSession.Set(context.GetMessage( "WebViewResidentId", ""), AV11ResidentId);
            AV14ShowNoRecordFound = false;
            AssignAttri("", false, "AV14ShowNoRecordFound", AV14ShowNoRecordFound);
            GxWebStd.gx_hidden_field( context, "gxhash_vSHOWNORECORDFOUND", GetSecureSignedToken( "", AV14ShowNoRecordFound, context));
            /* Using cursor H007K3 */
            pr_default.execute(1, new Object[] {AV22LocationId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A584ActiveAppVersionId = H007K3_A584ActiveAppVersionId[0];
               n584ActiveAppVersionId = H007K3_n584ActiveAppVersionId[0];
               A598PublishedActiveAppVersionId = H007K3_A598PublishedActiveAppVersionId[0];
               n598PublishedActiveAppVersionId = H007K3_n598PublishedActiveAppVersionId[0];
               A29LocationId = H007K3_A29LocationId[0];
               /* Using cursor H007K4 */
               pr_default.execute(2, new Object[] {n598PublishedActiveAppVersionId, A598PublishedActiveAppVersionId});
               A273Trn_ThemeId = H007K4_A273Trn_ThemeId[0];
               pr_default.close(2);
               /* Using cursor H007K5 */
               pr_default.execute(3, new Object[] {n584ActiveAppVersionId, A584ActiveAppVersionId});
               A273Trn_ThemeId = H007K5_A273Trn_ThemeId[0];
               pr_default.close(3);
               /* Using cursor H007K6 */
               pr_default.execute(4, new Object[] {A273Trn_ThemeId});
               while ( (pr_default.getStatus(4) != 101) )
               {
                  /* Using cursor H007K7 */
                  pr_default.execute(5, new Object[] {A273Trn_ThemeId});
                  while ( (pr_default.getStatus(5) != 101) )
                  {
                     A276ColorName = H007K7_A276ColorName[0];
                     A277ColorCode = H007K7_A277ColorCode[0];
                     if ( StringUtil.StrCmp(A276ColorName, context.GetMessage( "backgroundColor", "")) == 0 )
                     {
                        AV20BackgroundColor = A277ColorCode;
                     }
                     pr_default.readNext(5);
                  }
                  pr_default.close(5);
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(4);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            pr_default.close(3);
            Dynamicformjscss_Backgroundcolor = AV20BackgroundColor;
            ucDynamicformjscss.SendProperty(context, "", false, Dynamicformjscss_Internalname, "BackgroundColor", Dynamicformjscss_Backgroundcolor);
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
               bDynCreated_Wcwc_residentdynamicform = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwc_residentdynamicform_Component), StringUtil.Lower( "WC_ResidentDynamicForm")) != 0 )
            {
               WebComp_Wcwc_residentdynamicform = getWebComponent(GetType(), "GeneXus.Programs", "wc_residentdynamicform", new Object[] {context} );
               WebComp_Wcwc_residentdynamicform.ComponentInit();
               WebComp_Wcwc_residentdynamicform.Name = "WC_ResidentDynamicForm";
               WebComp_Wcwc_residentdynamicform_Component = "WC_ResidentDynamicForm";
            }
            if ( StringUtil.Len( WebComp_Wcwc_residentdynamicform_Component) != 0 )
            {
               WebComp_Wcwc_residentdynamicform.setjustcreated();
               WebComp_Wcwc_residentdynamicform.componentprepare(new Object[] {(string)"W0015",(string)"",(string)AV7WWPFormReferenceName,(int)AV8WWPFormInstanceId,(string)AV9WWPDynamicFormMode,(string)AV15AccessToken});
               WebComp_Wcwc_residentdynamicform.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
            }
         }
         else
         {
            AV14ShowNoRecordFound = true;
            AssignAttri("", false, "AV14ShowNoRecordFound", AV14ShowNoRecordFound);
            GxWebStd.gx_hidden_field( context, "gxhash_vSHOWNORECORDFOUND", GetSecureSignedToken( "", AV14ShowNoRecordFound, context));
            lblErrormessage_Caption = context.GetMessage( "The user session is invalid", "");
            AssignProp("", false, lblErrormessage_Internalname, "Caption", lblErrormessage_Caption, true);
         }
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         divLoadertable_Visible = (((AV17ShowLoadingState)) ? 1 : 0);
         AssignProp("", false, divLoadertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLoadertable_Visible), 5, 0), true);
         divNorecordfoundtable_Visible = (((AV14ShowNoRecordFound)) ? 1 : 0);
         AssignProp("", false, divNorecordfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divNorecordfoundtable_Visible), 5, 0), true);
      }

      protected void E127K2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         AV17ShowLoadingState = false;
         AssignAttri("", false, "AV17ShowLoadingState", AV17ShowLoadingState);
         GxWebStd.gx_hidden_field( context, "gxhash_vSHOWLOADINGSTATE", GetSecureSignedToken( "", AV17ShowLoadingState, context));
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E137K2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table2_30_7K2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, " ", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WP_ResidentDynamicForm.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_30_7K2e( true) ;
         }
         else
         {
            wb_table2_30_7K2e( false) ;
         }
      }

      protected void wb_table1_21_7K2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, " ", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WP_ResidentDynamicForm.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_21_7K2e( true) ;
         }
         else
         {
            wb_table1_21_7K2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV7WWPFormReferenceName = (string)getParm(obj,0);
         AssignAttri("", false, "AV7WWPFormReferenceName", AV7WWPFormReferenceName);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMREFERENCENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7WWPFormReferenceName, "")), context));
         AV8WWPFormInstanceId = Convert.ToInt32(getParm(obj,1));
         AssignAttri("", false, "AV8WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(AV8WWPFormInstanceId), 6, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMINSTANCEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8WWPFormInstanceId), "ZZZZZ9"), context));
         AV9WWPDynamicFormMode = (string)getParm(obj,2);
         AssignAttri("", false, "AV9WWPDynamicFormMode", AV9WWPDynamicFormMode);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPDYNAMICFORMMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9WWPDynamicFormMode, "")), context));
         AV15AccessToken = (string)getParm(obj,3);
         AssignAttri("", false, "AV15AccessToken", AV15AccessToken);
         GxWebStd.gx_hidden_field( context, "gxhash_vACCESSTOKEN", GetSecureSignedToken( "", AV15AccessToken, context));
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
         PA7K2( ) ;
         WS7K2( ) ;
         WE7K2( ) ;
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
         if ( ! ( WebComp_Wcwc_residentdynamicform == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcwc_residentdynamicform_Component) != 0 )
            {
               WebComp_Wcwc_residentdynamicform.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256309483899", true, true);
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
         context.AddJavascriptSource("wp_residentdynamicform.js", "?2025630948390", false, true);
         context.AddJavascriptSource("UserControls/UC_DynamicFormJSCSSRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblock1_Internalname = "TEXTBLOCK1";
         tblSpacetable1_Internalname = "SPACETABLE1";
         lblBanicon_Internalname = "BANICON";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         tblSpacetable2_Internalname = "SPACETABLE2";
         lblErrormessage_Internalname = "ERRORMESSAGE";
         divNorecordfoundtable_Internalname = "NORECORDFOUNDTABLE";
         divTablecontent_Internalname = "TABLECONTENT";
         imgImage1_Internalname = "IMAGE1";
         divLoadertable_Internalname = "LOADERTABLE";
         Dynamicformjscss_Internalname = "DYNAMICFORMJSCSS";
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
         tblSpacetable1_Height = 0;
         tblSpacetable2_Height = 0;
         divLoadertable_Visible = 1;
         lblErrormessage_Caption = context.GetMessage( "The record could not be found", "");
         divNorecordfoundtable_Visible = 1;
         Dynamicformjscss_Backgroundcolor = "&BackgroundColor";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "WP_Resident Dynamic Form", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV17ShowLoadingState","fld":"vSHOWLOADINGSTATE","hsh":true},{"av":"AV14ShowNoRecordFound","fld":"vSHOWNORECORDFOUND","hsh":true},{"av":"AV7WWPFormReferenceName","fld":"vWWPFORMREFERENCENAME","hsh":true},{"av":"AV8WWPFormInstanceId","fld":"vWWPFORMINSTANCEID","pic":"ZZZZZ9","hsh":true},{"av":"AV9WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE","hsh":true},{"av":"AV15AccessToken","fld":"vACCESSTOKEN","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV17ShowLoadingState","fld":"vSHOWLOADINGSTATE","hsh":true},{"av":"divLoadertable_Visible","ctrl":"LOADERTABLE","prop":"Visible"},{"av":"divNorecordfoundtable_Visible","ctrl":"NORECORDFOUNDTABLE","prop":"Visible"}]}""");
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
         pr_default.close(2);
      }

      public override void initialize( )
      {
         wcpOAV7WWPFormReferenceName = "";
         wcpOAV9WWPDynamicFormMode = "";
         wcpOAV15AccessToken = "";
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
         WebComp_Wcwc_residentdynamicform_Component = "";
         OldWcwc_residentdynamicform = "";
         lblBanicon_Jsonclick = "";
         lblErrormessage_Jsonclick = "";
         imgImage1_gximage = "";
         sImgUrl = "";
         ucDynamicformjscss = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV11ResidentId = "";
         H007K2_A62ResidentId = new Guid[] {Guid.Empty} ;
         H007K2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H007K2_A71ResidentGUID = new string[] {""} ;
         H007K2_A599ResidentLanguage = new string[] {""} ;
         H007K2_A29LocationId = new Guid[] {Guid.Empty} ;
         A71ResidentGUID = "";
         A599ResidentLanguage = "";
         A29LocationId = Guid.Empty;
         AV19Language = "";
         AV22LocationId = Guid.Empty;
         AV12WebSession = context.GetSession();
         H007K3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H007K3_A584ActiveAppVersionId = new Guid[] {Guid.Empty} ;
         H007K3_n584ActiveAppVersionId = new bool[] {false} ;
         H007K3_A598PublishedActiveAppVersionId = new Guid[] {Guid.Empty} ;
         H007K3_n598PublishedActiveAppVersionId = new bool[] {false} ;
         H007K3_A29LocationId = new Guid[] {Guid.Empty} ;
         A584ActiveAppVersionId = Guid.Empty;
         A598PublishedActiveAppVersionId = Guid.Empty;
         H007K4_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         A273Trn_ThemeId = Guid.Empty;
         H007K5_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         H007K6_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         H007K7_A275ColorId = new Guid[] {Guid.Empty} ;
         H007K7_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         H007K7_A276ColorName = new string[] {""} ;
         H007K7_A277ColorCode = new string[] {""} ;
         A276ColorName = "";
         A277ColorCode = "";
         AV20BackgroundColor = "";
         sStyleString = "";
         lblTextblock2_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_residentdynamicform__default(),
            new Object[][] {
                new Object[] {
               H007K2_A62ResidentId, H007K2_A11OrganisationId, H007K2_A71ResidentGUID, H007K2_A599ResidentLanguage, H007K2_A29LocationId
               }
               , new Object[] {
               H007K3_A11OrganisationId, H007K3_A584ActiveAppVersionId, H007K3_n584ActiveAppVersionId, H007K3_A598PublishedActiveAppVersionId, H007K3_n598PublishedActiveAppVersionId, H007K3_A29LocationId
               }
               , new Object[] {
               H007K4_A273Trn_ThemeId
               }
               , new Object[] {
               H007K5_A273Trn_ThemeId
               }
               , new Object[] {
               H007K6_A273Trn_ThemeId
               }
               , new Object[] {
               H007K7_A275ColorId, H007K7_A273Trn_ThemeId, H007K7_A276ColorName, H007K7_A277ColorCode
               }
            }
         );
         WebComp_Wcwc_residentdynamicform = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
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
      private short AV18NumericVariable ;
      private short nGXWrapped ;
      private int AV8WWPFormInstanceId ;
      private int wcpOAV8WWPFormInstanceId ;
      private int divNorecordfoundtable_Visible ;
      private int divLoadertable_Visible ;
      private int tblSpacetable2_Height ;
      private int tblSpacetable1_Height ;
      private int idxLst ;
      private string AV9WWPDynamicFormMode ;
      private string wcpOAV9WWPDynamicFormMode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Dynamicformjscss_Backgroundcolor ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string WebComp_Wcwc_residentdynamicform_Component ;
      private string OldWcwc_residentdynamicform ;
      private string divNorecordfoundtable_Internalname ;
      private string lblBanicon_Internalname ;
      private string lblBanicon_Jsonclick ;
      private string lblErrormessage_Internalname ;
      private string lblErrormessage_Caption ;
      private string lblErrormessage_Jsonclick ;
      private string divLoadertable_Internalname ;
      private string imgImage1_gximage ;
      private string sImgUrl ;
      private string imgImage1_Internalname ;
      private string Dynamicformjscss_Internalname ;
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
      private bool AV17ShowLoadingState ;
      private bool AV14ShowNoRecordFound ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV16isTokenValid ;
      private bool n584ActiveAppVersionId ;
      private bool n598PublishedActiveAppVersionId ;
      private bool bDynCreated_Wcwc_residentdynamicform ;
      private string AV15AccessToken ;
      private string wcpOAV15AccessToken ;
      private string AV7WWPFormReferenceName ;
      private string wcpOAV7WWPFormReferenceName ;
      private string AV11ResidentId ;
      private string A71ResidentGUID ;
      private string AV19Language ;
      private string A276ColorName ;
      private string A277ColorCode ;
      private string AV20BackgroundColor ;
      private Guid A29LocationId ;
      private Guid AV22LocationId ;
      private Guid A584ActiveAppVersionId ;
      private Guid A598PublishedActiveAppVersionId ;
      private Guid A273Trn_ThemeId ;
      private GXWebComponent WebComp_Wcwc_residentdynamicform ;
      private GXUserControl ucDynamicformjscss ;
      private IGxSession AV12WebSession ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] H007K2_A62ResidentId ;
      private Guid[] H007K2_A11OrganisationId ;
      private string[] H007K2_A71ResidentGUID ;
      private string[] H007K2_A599ResidentLanguage ;
      private Guid[] H007K2_A29LocationId ;
      private Guid[] H007K3_A11OrganisationId ;
      private Guid[] H007K3_A584ActiveAppVersionId ;
      private bool[] H007K3_n584ActiveAppVersionId ;
      private Guid[] H007K3_A598PublishedActiveAppVersionId ;
      private bool[] H007K3_n598PublishedActiveAppVersionId ;
      private Guid[] H007K3_A29LocationId ;
      private Guid[] H007K4_A273Trn_ThemeId ;
      private Guid[] H007K5_A273Trn_ThemeId ;
      private Guid[] H007K6_A273Trn_ThemeId ;
      private Guid[] H007K7_A275ColorId ;
      private Guid[] H007K7_A273Trn_ThemeId ;
      private string[] H007K7_A276ColorName ;
      private string[] H007K7_A277ColorCode ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wp_residentdynamicform__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH007K2;
          prmH007K2 = new Object[] {
          new ParDef("AV11ResidentId",GXType.VarChar,100,60)
          };
          Object[] prmH007K3;
          prmH007K3 = new Object[] {
          new ParDef("AV22LocationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmH007K4;
          prmH007K4 = new Object[] {
          new ParDef("PublishedActiveAppVersionId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmH007K5;
          prmH007K5 = new Object[] {
          new ParDef("ActiveAppVersionId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmH007K6;
          prmH007K6 = new Object[] {
          new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmH007K7;
          prmH007K7 = new Object[] {
          new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("H007K2", "SELECT ResidentId, OrganisationId, ResidentGUID, ResidentLanguage, LocationId FROM Trn_Resident WHERE ResidentGUID = ( :AV11ResidentId) ORDER BY ResidentId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007K2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H007K3", "SELECT OrganisationId, ActiveAppVersionId, PublishedActiveAppVersionId, LocationId FROM Trn_Location WHERE LocationId = :AV22LocationId ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007K3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007K4", "SELECT Trn_ThemeId FROM Trn_AppVersion WHERE AppVersionId = :PublishedActiveAppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007K4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007K5", "SELECT Trn_ThemeId FROM Trn_AppVersion WHERE AppVersionId = :ActiveAppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007K5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007K6", "SELECT Trn_ThemeId FROM Trn_Theme WHERE Trn_ThemeId = :Trn_ThemeId ORDER BY Trn_ThemeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007K6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H007K7", "SELECT ColorId, Trn_ThemeId, ColorName, ColorCode FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId ORDER BY Trn_ThemeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007K7,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((Guid[]) buf[5])[0] = rslt.getGuid(4);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}
