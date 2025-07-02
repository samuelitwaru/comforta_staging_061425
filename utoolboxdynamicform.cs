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
namespace GeneXus.Programs {
   public class utoolboxdynamicform : GXDataArea
   {
      public utoolboxdynamicform( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public utoolboxdynamicform( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_WWPFormId ,
                           string aP1_WWPDynamicFormMode ,
                           string aP2_DefaultFormType ,
                           short aP3_WWPFormType ,
                           string aP4_WWPFormReferenceName )
      {
         this.AV48WWPFormId = aP0_WWPFormId;
         this.AV42WWPDynamicFormMode = aP1_WWPDynamicFormMode;
         this.AV10DefaultFormType = aP2_DefaultFormType;
         this.AV49WWPFormType = aP3_WWPFormType;
         this.AV55WWPFormReferenceName = aP4_WWPFormReferenceName;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavDynamicsectiontoupdate = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "WWPFormId");
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
               gxfirstwebparm = GetFirstPar( "WWPFormId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "WWPFormId");
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
               AV48WWPFormId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV48WWPFormId", StringUtil.LTrimStr( (decimal)(AV48WWPFormId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV48WWPFormId), "ZZZ9"), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV42WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
                  AssignAttri("", false, "AV42WWPDynamicFormMode", AV42WWPDynamicFormMode);
                  GxWebStd.gx_hidden_field( context, "gxhash_vWWPDYNAMICFORMMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV42WWPDynamicFormMode, "")), context));
                  AV10DefaultFormType = GetPar( "DefaultFormType");
                  AssignAttri("", false, "AV10DefaultFormType", AV10DefaultFormType);
                  AV49WWPFormType = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormType"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV49WWPFormType", StringUtil.Str( (decimal)(AV49WWPFormType), 1, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV49WWPFormType), "9"), context));
                  AV55WWPFormReferenceName = GetPar( "WWPFormReferenceName");
                  AssignAttri("", false, "AV55WWPFormReferenceName", AV55WWPFormReferenceName);
                  GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMREFERENCENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV55WWPFormReferenceName, "")), context));
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
         PA9Y2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START9Y2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal ResidentForm\" data-gx-class=\"form-horizontal ResidentForm\" novalidate action=\""+formatLink("utoolboxdynamicform.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV48WWPFormId,4,0)),UrlEncode(StringUtil.RTrim(AV42WWPDynamicFormMode)),UrlEncode(StringUtil.RTrim(AV10DefaultFormType)),UrlEncode(StringUtil.LTrimStr(AV49WWPFormType,1,0)),UrlEncode(StringUtil.RTrim(AV55WWPFormReferenceName))}, new string[] {"WWPFormId","WWPDynamicFormMode","DefaultFormType","WWPFormType","WWPFormReferenceName"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vWWPFORMVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMVERSIONNUMBER", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV50WWPFormVersionNumber), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV48WWPFormId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV42WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPDYNAMICFORMMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV42WWPDynamicFormMode, "")), context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV49WWPFormType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV49WWPFormType), "9"), context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMREFERENCENAME", AV55WWPFormReferenceName);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMREFERENCENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV55WWPFormReferenceName, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vWWPFORMVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMVERSIONNUMBER", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV50WWPFormVersionNumber), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vREFRESHMASTERTITLE", AV23RefreshMasterTitle);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPFORM", AV43WWPForm);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPFORM", AV43WWPForm);
         }
         GxWebStd.gx_hidden_field( context, "vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV42WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPDYNAMICFORMMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV42WWPDynamicFormMode, "")), context));
         GxWebStd.gx_hidden_field( context, "vADDEDSTEPINDEX", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5AddedStepIndex), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vWWPFORMTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV49WWPFormType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV49WWPFormType), "9"), context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV48WWPFormId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vDEFAULTFORMTYPE", AV10DefaultFormType);
         GxWebStd.gx_hidden_field( context, "vWWPFORMREFERENCENAME", AV55WWPFormReferenceName);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMREFERENCENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV55WWPFormReferenceName, "")), context));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Width", StringUtil.RTrim( Dvpanel_unnamedtable1_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Cls", StringUtil.RTrim( Dvpanel_unnamedtable1_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Title", StringUtil.RTrim( Dvpanel_unnamedtable1_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable1_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Autoscroll));
         GxWebStd.gx_hidden_field( context, "vWWPFORM_Wwpformtitle", AV43WWPForm.gxTpr_Wwpformtitle);
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
            WE9Y2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT9Y2( ) ;
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
         return formatLink("utoolboxdynamicform.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV48WWPFormId,4,0)),UrlEncode(StringUtil.RTrim(AV42WWPDynamicFormMode)),UrlEncode(StringUtil.RTrim(AV10DefaultFormType)),UrlEncode(StringUtil.LTrimStr(AV49WWPFormType,1,0)),UrlEncode(StringUtil.RTrim(AV55WWPFormReferenceName))}, new string[] {"WWPFormId","WWPDynamicFormMode","DefaultFormType","WWPFormType","WWPFormReferenceName"})  ;
      }

      public override string GetPgmname( )
      {
         return "UToolboxDynamicForm" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Dynamic form", "") ;
      }

      protected void WB9Y0( )
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDvpanel_unnamedtable1_cell_Internalname, 1, 0, "px", 0, "px", divDvpanel_unnamedtable1_cell_Class, "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_unnamedtable1.SetProperty("Width", Dvpanel_unnamedtable1_Width);
            ucDvpanel_unnamedtable1.SetProperty("AutoWidth", Dvpanel_unnamedtable1_Autowidth);
            ucDvpanel_unnamedtable1.SetProperty("AutoHeight", Dvpanel_unnamedtable1_Autoheight);
            ucDvpanel_unnamedtable1.SetProperty("Cls", Dvpanel_unnamedtable1_Cls);
            ucDvpanel_unnamedtable1.SetProperty("Title", Dvpanel_unnamedtable1_Title);
            ucDvpanel_unnamedtable1.SetProperty("Collapsible", Dvpanel_unnamedtable1_Collapsible);
            ucDvpanel_unnamedtable1.SetProperty("Collapsed", Dvpanel_unnamedtable1_Collapsed);
            ucDvpanel_unnamedtable1.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable1_Showcollapseicon);
            ucDvpanel_unnamedtable1.SetProperty("IconPosition", Dvpanel_unnamedtable1_Iconposition);
            ucDvpanel_unnamedtable1.SetProperty("AutoScroll", Dvpanel_unnamedtable1_Autoscroll);
            ucDvpanel_unnamedtable1.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable1_Internalname, "DVPANEL_UNNAMEDTABLE1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_UNNAMEDTABLE1Container"+"UnnamedTable1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavDynamicsectiontoupdate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicsectiontoupdate_Internalname, context.GetMessage( "Dynamic Section", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicsectiontoupdate, cmbavDynamicsectiontoupdate_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV11DynamicSectionToUpdate), 4, 0)), 1, cmbavDynamicsectiontoupdate_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICSECTIONTOUPDATE.CLICK."+"'", "int", "", 1, cmbavDynamicsectiontoupdate.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "", true, 0, "HLP_UToolboxDynamicForm.htm");
            cmbavDynamicsectiontoupdate.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV11DynamicSectionToUpdate), 4, 0));
            AssignProp("", false, cmbavDynamicsectiontoupdate_Internalname, "Values", (string)(cmbavDynamicsectiontoupdate.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10 MobileButtonGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
            ClassString = "MobileSubmitBtn";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", context.GetMessage( "Submit", ""), bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_UToolboxDynamicForm.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FixingTopInvisible", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnrefreshgrid_Internalname, "", context.GetMessage( "UARefreshGrid", ""), bttBtnrefreshgrid_Jsonclick, 5, context.GetMessage( "UARefreshGrid", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOREFRESHGRID\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_UToolboxDynamicForm.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMissingform_Internalname, divMissingform_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFormdeleted_Internalname, context.GetMessage( "I18N_DELETEDFORMTOOLBOX", ""), "", "", lblFormdeleted_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "MissingFormLabel", 0, "", 1, 1, 0, 0, "HLP_UToolboxDynamicForm.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSessionid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV25SessionId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSessionid_Jsonclick, 0, "Attribute", "", "", "", "", edtavSessionid_Visible, 1, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_UToolboxDynamicForm.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START9Y2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Dynamic form", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP9Y0( ) ;
      }

      protected void WS9Y2( )
      {
         START9Y2( ) ;
         EVT9Y2( ) ;
      }

      protected void EVT9Y2( )
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
                              E119Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOREFRESHGRID'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoRefreshGrid' */
                              E129Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E139Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICSECTIONTOUPDATE.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E149Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E159Y2 ();
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
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE9Y2( )
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

      protected void PA9Y2( )
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
               GX_FocusControl = cmbavDynamicsectiontoupdate_Internalname;
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
         if ( cmbavDynamicsectiontoupdate.ItemCount > 0 )
         {
            AV11DynamicSectionToUpdate = (short)(Math.Round(NumberUtil.Val( cmbavDynamicsectiontoupdate.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV11DynamicSectionToUpdate), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV11DynamicSectionToUpdate", StringUtil.LTrimStr( (decimal)(AV11DynamicSectionToUpdate), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicsectiontoupdate.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV11DynamicSectionToUpdate), 4, 0));
            AssignProp("", false, cmbavDynamicsectiontoupdate_Internalname, "Values", cmbavDynamicsectiontoupdate.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF9Y2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF9Y2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E139Y2 ();
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
            E159Y2 ();
            WB9Y0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes9Y2( )
      {
         GxWebStd.gx_hidden_field( context, "vWWPFORMVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMVERSIONNUMBER", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV50WWPFormVersionNumber), "ZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9Y0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E119Y2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Dvpanel_unnamedtable1_Width = cgiGet( "DVPANEL_UNNAMEDTABLE1_Width");
            Dvpanel_unnamedtable1_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Autowidth"));
            Dvpanel_unnamedtable1_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Autoheight"));
            Dvpanel_unnamedtable1_Cls = cgiGet( "DVPANEL_UNNAMEDTABLE1_Cls");
            Dvpanel_unnamedtable1_Title = cgiGet( "DVPANEL_UNNAMEDTABLE1_Title");
            Dvpanel_unnamedtable1_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Collapsible"));
            Dvpanel_unnamedtable1_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Collapsed"));
            Dvpanel_unnamedtable1_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Showcollapseicon"));
            Dvpanel_unnamedtable1_Iconposition = cgiGet( "DVPANEL_UNNAMEDTABLE1_Iconposition");
            Dvpanel_unnamedtable1_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Autoscroll"));
            /* Read variables values. */
            cmbavDynamicsectiontoupdate.CurrentValue = cgiGet( cmbavDynamicsectiontoupdate_Internalname);
            AV11DynamicSectionToUpdate = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicsectiontoupdate_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV11DynamicSectionToUpdate", StringUtil.LTrimStr( (decimal)(AV11DynamicSectionToUpdate), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSessionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSessionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSESSIONID");
               GX_FocusControl = edtavSessionid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV25SessionId = 0;
               AssignAttri("", false, "AV25SessionId", StringUtil.LTrimStr( (decimal)(AV25SessionId), 4, 0));
            }
            else
            {
               AV25SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavSessionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV25SessionId", StringUtil.LTrimStr( (decimal)(AV25SessionId), 4, 0));
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
         E119Y2 ();
         if (returnInSub) return;
      }

      protected void E119Y2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV16HttpRequest.Method, "GET") == 0 )
         {
            AV25SessionId = (short)(NumberUtil.Random( )*10000);
            AssignAttri("", false, "AV25SessionId", StringUtil.LTrimStr( (decimal)(AV25SessionId), 4, 0));
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV55WWPFormReferenceName ,
                                                 A208WWPFormReferenceName ,
                                                 AV48WWPFormId ,
                                                 A206WWPFormId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor H009Y2 */
            pr_default.execute(0, new Object[] {AV48WWPFormId, AV55WWPFormReferenceName});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A208WWPFormReferenceName = H009Y2_A208WWPFormReferenceName[0];
               A206WWPFormId = H009Y2_A206WWPFormId[0];
               A207WWPFormVersionNumber = H009Y2_A207WWPFormVersionNumber[0];
               AV50WWPFormVersionNumber = A207WWPFormVersionNumber;
               AssignAttri("", false, "AV50WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(AV50WWPFormVersionNumber), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMVERSIONNUMBER", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV50WWPFormVersionNumber), "ZZZ9"), context));
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( (0==AV50WWPFormVersionNumber) )
            {
               bttBtnenter_Visible = 0;
               AssignProp("", false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
               divDvpanel_unnamedtable1_cell_Class = "Invisible";
               AssignProp("", false, divDvpanel_unnamedtable1_cell_Internalname, "Class", divDvpanel_unnamedtable1_cell_Class, true);
               edtavSessionid_Visible = 0;
               AssignProp("", false, edtavSessionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSessionid_Visible), 5, 0), true);
            }
            else
            {
               AV43WWPForm.Load(AV48WWPFormId, AV50WWPFormVersionNumber);
               AV43WWPForm.gxTpr_Element.Sort("WWPFormElementOrderIndex");
               bttBtnenter_Visible = 1;
               AssignProp("", false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
               Form.Caption = StringUtil.Format( context.GetMessage( "WWP_DynamicSectionsFor", ""), AV43WWPForm.gxTpr_Wwpformreferencename, "", "", "", "", "", "", "", "");
               AssignProp("", false, "FORM", "Caption", Form.Caption, true);
               divTablemain_Class = "TableMainDynamicForm TableMainDynamicSections";
               AssignProp("", false, divTablemain_Internalname, "Class", divTablemain_Class, true);
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_saveformdefinition(context ).execute(  AV25SessionId,  AV43WWPForm) ;
               if ( AV49WWPFormType == 1 )
               {
                  AV57GXV1 = 1;
                  while ( AV57GXV1 <= AV43WWPForm.gxTpr_Element.Count )
                  {
                     AV45WWPFormElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV43WWPForm.gxTpr_Element.Item(AV57GXV1));
                     if ( AV45WWPFormElement.gxTpr_Wwpformelementparentid == 0 )
                     {
                        cmbavDynamicsectiontoupdate.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV45WWPFormElement.gxTpr_Wwpformelementid), 4, 0)), AV45WWPFormElement.gxTpr_Wwpformelementreferenceid, 0);
                        if ( (0==AV11DynamicSectionToUpdate) )
                        {
                           AV11DynamicSectionToUpdate = AV45WWPFormElement.gxTpr_Wwpformelementid;
                           AssignAttri("", false, "AV11DynamicSectionToUpdate", StringUtil.LTrimStr( (decimal)(AV11DynamicSectionToUpdate), 4, 0));
                        }
                     }
                     AV57GXV1 = (int)(AV57GXV1+1);
                  }
               }
            }
         }
         if ( ! (0==AV50WWPFormVersionNumber) )
         {
            if ( StringUtil.StrCmp(AV42WWPDynamicFormMode, "DSP") == 0 )
            {
               divTablemain_Class = "TableMainDynamicForm TableMainDynamicFormDSP";
               AssignProp("", false, divTablemain_Internalname, "Class", divTablemain_Class, true);
            }
            /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
            S112 ();
            if (returnInSub) return;
            edtavSessionid_Visible = 0;
            AssignProp("", false, edtavSessionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSessionid_Visible), 5, 0), true);
         }
      }

      protected void E129Y2( )
      {
         /* 'DoRefreshGrid' Routine */
         returnInSub = false;
         GXt_SdtWWP_Form1 = AV43WWPForm;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadformdefinition(context ).execute(  AV25SessionId, out  GXt_SdtWWP_Form1) ;
         AV43WWPForm = GXt_SdtWWP_Form1;
         AV23RefreshMasterTitle = true;
         AssignAttri("", false, "AV23RefreshMasterTitle", AV23RefreshMasterTitle);
         AV5AddedStepIndex = (short)(Math.Round(NumberUtil.Val( AV32WebSession.Get("WWPDynFormCreation_DefaultStep"), "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV5AddedStepIndex", StringUtil.LTrimStr( (decimal)(AV5AddedStepIndex), 4, 0));
         AV32WebSession.Remove("WWPDynFormCreation_DefaultStep");
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43WWPForm", AV43WWPForm);
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         divMissingform_Visible = (((0==AV50WWPFormVersionNumber)) ? 1 : 0);
         AssignProp("", false, divMissingform_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divMissingform_Visible), 5, 0), true);
         if ( ! ( ( AV49WWPFormType == 1 ) ) )
         {
            divDvpanel_unnamedtable1_cell_Class = "Invisible";
            AssignProp("", false, divDvpanel_unnamedtable1_cell_Internalname, "Class", divDvpanel_unnamedtable1_cell_Class, true);
         }
         else
         {
            divDvpanel_unnamedtable1_cell_Class = "col-xs-12 CellMarginBottom15";
            AssignProp("", false, divDvpanel_unnamedtable1_cell_Internalname, "Class", divDvpanel_unnamedtable1_cell_Class, true);
         }
      }

      protected void E139Y2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         if ( ! (0==AV50WWPFormVersionNumber) )
         {
            if ( AV23RefreshMasterTitle )
            {
               Form.Caption = AV43WWPForm.gxTpr_Wwpformtitle;
               AssignProp("", false, "FORM", "Caption", Form.Caption, true);
               this.executeExternalObjectMethod("", false, "GlobalEvents", "Master_RefreshTitle", new Object[] {AV43WWPForm.gxTpr_Wwpformtitle}, true);
               AV23RefreshMasterTitle = false;
               AssignAttri("", false, "AV23RefreshMasterTitle", AV23RefreshMasterTitle);
            }
            if ( AV43WWPForm.gxTpr_Wwpformiswizard )
            {
               /* Object Property */
               if ( true )
               {
                  bDynCreated_Wcwwp_dynamicformfs_wc = true;
               }
               if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwwp_dynamicformfs_wc_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_Wizard_WC")) != 0 )
               {
                  WebComp_Wcwwp_dynamicformfs_wc = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_wizard_wc", new Object[] {context} );
                  WebComp_Wcwwp_dynamicformfs_wc.ComponentInit();
                  WebComp_Wcwwp_dynamicformfs_wc.Name = "WorkWithPlus.DynamicForms.WWP_DFC_Wizard_WC";
                  WebComp_Wcwwp_dynamicformfs_wc_Component = "WorkWithPlus.DynamicForms.WWP_DFC_Wizard_WC";
               }
               if ( StringUtil.Len( WebComp_Wcwwp_dynamicformfs_wc_Component) != 0 )
               {
                  WebComp_Wcwwp_dynamicformfs_wc.setjustcreated();
                  WebComp_Wcwwp_dynamicformfs_wc.componentprepare(new Object[] {(string)"W0025",(string)"",(string)AV42WWPDynamicFormMode,(short)AV25SessionId,(short)AV5AddedStepIndex,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV43WWPForm});
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
               AV5AddedStepIndex = 0;
               AssignAttri("", false, "AV5AddedStepIndex", StringUtil.LTrimStr( (decimal)(AV5AddedStepIndex), 4, 0));
            }
            else
            {
               AV46WWPFormElementId = (short)(((AV49WWPFormType==0) ? 0 : AV11DynamicSectionToUpdate));
               /* Object Property */
               if ( true )
               {
                  bDynCreated_Wcwwp_dynamicformfs_wc = true;
               }
               if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwwp_dynamicformfs_wc_Component), StringUtil.Lower( "UDFC_FS_WC")) != 0 )
               {
                  WebComp_Wcwwp_dynamicformfs_wc = getWebComponent(GetType(), "GeneXus.Programs", "udfc_fs_wc", new Object[] {context} );
                  WebComp_Wcwwp_dynamicformfs_wc.ComponentInit();
                  WebComp_Wcwwp_dynamicformfs_wc.Name = "UDFC_FS_WC";
                  WebComp_Wcwwp_dynamicformfs_wc_Component = "UDFC_FS_WC";
               }
               if ( StringUtil.Len( WebComp_Wcwwp_dynamicformfs_wc_Component) != 0 )
               {
                  WebComp_Wcwwp_dynamicformfs_wc.setjustcreated();
                  WebComp_Wcwwp_dynamicformfs_wc.componentprepare(new Object[] {(string)"W0025",(string)"",(string)AV42WWPDynamicFormMode,(short)AV46WWPFormElementId,(short)AV25SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV43WWPForm});
                  WebComp_Wcwwp_dynamicformfs_wc.componentbind(new Object[] {(string)"",(string)"",(string)"vSESSIONID",(string)""});
               }
               if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcwwp_dynamicformfs_wc )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0025"+"");
                  WebComp_Wcwwp_dynamicformfs_wc.componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
         }
         /*  Sending Event outputs  */
      }

      protected void E149Y2( )
      {
         /* Dynamicsectiontoupdate_Click Routine */
         returnInSub = false;
         GXt_SdtWWP_Form1 = AV43WWPForm;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadformdefinition(context ).execute(  AV25SessionId, out  GXt_SdtWWP_Form1) ;
         AV43WWPForm = GXt_SdtWWP_Form1;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcwwp_dynamicformfs_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwwp_dynamicformfs_wc_Component), StringUtil.Lower( "UDFC_FS_WC")) != 0 )
         {
            WebComp_Wcwwp_dynamicformfs_wc = getWebComponent(GetType(), "GeneXus.Programs", "udfc_fs_wc", new Object[] {context} );
            WebComp_Wcwwp_dynamicformfs_wc.ComponentInit();
            WebComp_Wcwwp_dynamicformfs_wc.Name = "UDFC_FS_WC";
            WebComp_Wcwwp_dynamicformfs_wc_Component = "UDFC_FS_WC";
         }
         if ( StringUtil.Len( WebComp_Wcwwp_dynamicformfs_wc_Component) != 0 )
         {
            WebComp_Wcwwp_dynamicformfs_wc.setjustcreated();
            WebComp_Wcwwp_dynamicformfs_wc.componentprepare(new Object[] {(string)"W0025",(string)"",(string)AV42WWPDynamicFormMode,(short)AV11DynamicSectionToUpdate,(short)AV25SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV43WWPForm});
            WebComp_Wcwwp_dynamicformfs_wc.componentbind(new Object[] {(string)"",(string)"vDYNAMICSECTIONTOUPDATE",(string)"vSESSIONID",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcwwp_dynamicformfs_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0025"+"");
            WebComp_Wcwwp_dynamicformfs_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43WWPForm", AV43WWPForm);
      }

      protected void nextLoad( )
      {
      }

      protected void E159Y2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV48WWPFormId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV48WWPFormId", StringUtil.LTrimStr( (decimal)(AV48WWPFormId), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV48WWPFormId), "ZZZ9"), context));
         AV42WWPDynamicFormMode = (string)getParm(obj,1);
         AssignAttri("", false, "AV42WWPDynamicFormMode", AV42WWPDynamicFormMode);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPDYNAMICFORMMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV42WWPDynamicFormMode, "")), context));
         AV10DefaultFormType = (string)getParm(obj,2);
         AssignAttri("", false, "AV10DefaultFormType", AV10DefaultFormType);
         AV49WWPFormType = Convert.ToInt16(getParm(obj,3));
         AssignAttri("", false, "AV49WWPFormType", StringUtil.Str( (decimal)(AV49WWPFormType), 1, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV49WWPFormType), "9"), context));
         AV55WWPFormReferenceName = (string)getParm(obj,4);
         AssignAttri("", false, "AV55WWPFormReferenceName", AV55WWPFormReferenceName);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMREFERENCENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV55WWPFormReferenceName, "")), context));
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
         PA9Y2( ) ;
         WS9Y2( ) ;
         WE9Y2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025721305638", true, true);
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
         context.AddJavascriptSource("utoolboxdynamicform.js", "?2025721305640", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicsectiontoupdate.Name = "vDYNAMICSECTIONTOUPDATE";
         cmbavDynamicsectiontoupdate.WebTags = "";
         if ( cmbavDynamicsectiontoupdate.ItemCount > 0 )
         {
            AV11DynamicSectionToUpdate = (short)(Math.Round(NumberUtil.Val( cmbavDynamicsectiontoupdate.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV11DynamicSectionToUpdate), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV11DynamicSectionToUpdate", StringUtil.LTrimStr( (decimal)(AV11DynamicSectionToUpdate), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         cmbavDynamicsectiontoupdate_Internalname = "vDYNAMICSECTIONTOUPDATE";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         Dvpanel_unnamedtable1_Internalname = "DVPANEL_UNNAMEDTABLE1";
         divDvpanel_unnamedtable1_cell_Internalname = "DVPANEL_UNNAMEDTABLE1_CELL";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtnrefreshgrid_Internalname = "BTNREFRESHGRID";
         lblFormdeleted_Internalname = "FORMDELETED";
         divMissingform_Internalname = "MISSINGFORM";
         divTablemain_Internalname = "TABLEMAIN";
         edtavSessionid_Internalname = "vSESSIONID";
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
         divMissingform_Visible = 1;
         bttBtnenter_Visible = 1;
         cmbavDynamicsectiontoupdate_Jsonclick = "";
         cmbavDynamicsectiontoupdate.Enabled = 1;
         divDvpanel_unnamedtable1_cell_Class = "col-xs-12";
         divTablemain_Class = "TableMain";
         Dvpanel_unnamedtable1_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Iconposition = "Right";
         Dvpanel_unnamedtable1_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable1_Title = "";
         Dvpanel_unnamedtable1_Cls = "PanelNoHeader";
         Dvpanel_unnamedtable1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Dynamic form", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV23RefreshMasterTitle","fld":"vREFRESHMASTERTITLE"},{"av":"AV43WWPForm","fld":"vWWPFORM"},{"av":"AV25SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV5AddedStepIndex","fld":"vADDEDSTEPINDEX","pic":"ZZZ9"},{"av":"cmbavDynamicsectiontoupdate"},{"av":"AV11DynamicSectionToUpdate","fld":"vDYNAMICSECTIONTOUPDATE","pic":"ZZZ9"},{"av":"AV50WWPFormVersionNumber","fld":"vWWPFORMVERSIONNUMBER","pic":"ZZZ9","hsh":true},{"av":"AV42WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE","hsh":true},{"av":"AV49WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV48WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV55WWPFormReferenceName","fld":"vWWPFORMREFERENCENAME","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"ctrl":"FORM","prop":"Caption"},{"av":"AV23RefreshMasterTitle","fld":"vREFRESHMASTERTITLE"},{"ctrl":"BTNENTER","prop":"Visible"},{"av":"AV5AddedStepIndex","fld":"vADDEDSTEPINDEX","pic":"ZZZ9"},{"ctrl":"WCWWP_DYNAMICFORMFS_WC"}]}""");
         setEventMetadata("'DOREFRESHGRID'","""{"handler":"E129Y2","iparms":[{"av":"AV25SessionId","fld":"vSESSIONID","pic":"ZZZ9"}]""");
         setEventMetadata("'DOREFRESHGRID'",""","oparms":[{"av":"AV43WWPForm","fld":"vWWPFORM"},{"av":"AV23RefreshMasterTitle","fld":"vREFRESHMASTERTITLE"},{"av":"AV5AddedStepIndex","fld":"vADDEDSTEPINDEX","pic":"ZZZ9"}]}""");
         setEventMetadata("VDYNAMICSECTIONTOUPDATE.CLICK","""{"handler":"E149Y2","iparms":[{"av":"AV25SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV42WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE","hsh":true},{"av":"cmbavDynamicsectiontoupdate"},{"av":"AV11DynamicSectionToUpdate","fld":"vDYNAMICSECTIONTOUPDATE","pic":"ZZZ9"}]""");
         setEventMetadata("VDYNAMICSECTIONTOUPDATE.CLICK",""","oparms":[{"av":"AV43WWPForm","fld":"vWWPFORM"},{"ctrl":"WCWWP_DYNAMICFORMFS_WC"}]}""");
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
         wcpOAV42WWPDynamicFormMode = "";
         wcpOAV10DefaultFormType = "";
         wcpOAV55WWPFormReferenceName = "";
         AV43WWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
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
         ucDvpanel_unnamedtable1 = new GXUserControl();
         TempTags = "";
         WebComp_Wcwwp_dynamicformfs_wc_Component = "";
         OldWcwwp_dynamicformfs_wc = "";
         bttBtnenter_Jsonclick = "";
         bttBtnrefreshgrid_Jsonclick = "";
         lblFormdeleted_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV16HttpRequest = new GxHttpRequest( context);
         A208WWPFormReferenceName = "";
         H009Y2_A208WWPFormReferenceName = new string[] {""} ;
         H009Y2_A206WWPFormId = new short[1] ;
         H009Y2_A207WWPFormVersionNumber = new short[1] ;
         AV45WWPFormElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         AV32WebSession = context.GetSession();
         GXt_SdtWWP_Form1 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.utoolboxdynamicform__default(),
            new Object[][] {
                new Object[] {
               H009Y2_A208WWPFormReferenceName, H009Y2_A206WWPFormId, H009Y2_A207WWPFormVersionNumber
               }
            }
         );
         WebComp_Wcwwp_dynamicformfs_wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short AV48WWPFormId ;
      private short AV49WWPFormType ;
      private short wcpOAV48WWPFormId ;
      private short wcpOAV49WWPFormType ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short AV50WWPFormVersionNumber ;
      private short AV5AddedStepIndex ;
      private short wbEnd ;
      private short wbStart ;
      private short AV11DynamicSectionToUpdate ;
      private short AV25SessionId ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private short AV46WWPFormElementId ;
      private short nGXWrapped ;
      private int bttBtnenter_Visible ;
      private int divMissingform_Visible ;
      private int edtavSessionid_Visible ;
      private int AV57GXV1 ;
      private int idxLst ;
      private string AV42WWPDynamicFormMode ;
      private string wcpOAV42WWPDynamicFormMode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Dvpanel_unnamedtable1_Width ;
      private string Dvpanel_unnamedtable1_Cls ;
      private string Dvpanel_unnamedtable1_Title ;
      private string Dvpanel_unnamedtable1_Iconposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTablemain_Class ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divDvpanel_unnamedtable1_cell_Internalname ;
      private string divDvpanel_unnamedtable1_cell_Class ;
      private string Dvpanel_unnamedtable1_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string cmbavDynamicsectiontoupdate_Internalname ;
      private string TempTags ;
      private string cmbavDynamicsectiontoupdate_Jsonclick ;
      private string WebComp_Wcwwp_dynamicformfs_wc_Component ;
      private string OldWcwwp_dynamicformfs_wc ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtnrefreshgrid_Internalname ;
      private string bttBtnrefreshgrid_Jsonclick ;
      private string divMissingform_Internalname ;
      private string lblFormdeleted_Internalname ;
      private string lblFormdeleted_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavSessionid_Internalname ;
      private string edtavSessionid_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV23RefreshMasterTitle ;
      private bool Dvpanel_unnamedtable1_Autowidth ;
      private bool Dvpanel_unnamedtable1_Autoheight ;
      private bool Dvpanel_unnamedtable1_Collapsible ;
      private bool Dvpanel_unnamedtable1_Collapsed ;
      private bool Dvpanel_unnamedtable1_Showcollapseicon ;
      private bool Dvpanel_unnamedtable1_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Wcwwp_dynamicformfs_wc ;
      private string AV10DefaultFormType ;
      private string AV55WWPFormReferenceName ;
      private string wcpOAV10DefaultFormType ;
      private string wcpOAV55WWPFormReferenceName ;
      private string A208WWPFormReferenceName ;
      private IGxSession AV32WebSession ;
      private GXWebComponent WebComp_Wcwwp_dynamicformfs_wc ;
      private GXUserControl ucDvpanel_unnamedtable1 ;
      private GxHttpRequest AV16HttpRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicsectiontoupdate ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV43WWPForm ;
      private IDataStoreProvider pr_default ;
      private string[] H009Y2_A208WWPFormReferenceName ;
      private short[] H009Y2_A206WWPFormId ;
      private short[] H009Y2_A207WWPFormVersionNumber ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV45WWPFormElement ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form GXt_SdtWWP_Form1 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class utoolboxdynamicform__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H009Y2( IGxContext context ,
                                             string AV55WWPFormReferenceName ,
                                             string A208WWPFormReferenceName ,
                                             short AV48WWPFormId ,
                                             short A206WWPFormId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[2];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT WWPFormReferenceName, WWPFormId, WWPFormVersionNumber FROM WWP_Form";
         AddWhere(sWhereString, "(WWPFormId = :AV48WWPFormId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55WWPFormReferenceName)) )
         {
            AddWhere(sWhereString, "(WWPFormReferenceName = ( :AV55WWPFormReferenceName))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY WWPFormId, WWPFormVersionNumber DESC";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H009Y2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH009Y2;
          prmH009Y2 = new Object[] {
          new ParDef("AV48WWPFormId",GXType.Int16,4,0) ,
          new ParDef("AV55WWPFormReferenceName",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H009Y2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009Y2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
       }
    }

 }

}
