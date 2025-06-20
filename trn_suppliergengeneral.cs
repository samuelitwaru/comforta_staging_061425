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
   public class trn_suppliergengeneral : GXWebComponent
   {
      public trn_suppliergengeneral( )
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

      public trn_suppliergengeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_SupplierGenId )
      {
         this.A42SupplierGenId = aP0_SupplierGenId;
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
               gxfirstwebparm = GetFirstPar( "SupplierGenId");
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
                  A42SupplierGenId = StringUtil.StrToGuid( GetPar( "SupplierGenId"));
                  AssignAttri(sPrefix, false, "A42SupplierGenId", A42SupplierGenId.ToString());
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(Guid)A42SupplierGenId});
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
                  gxfirstwebparm = GetFirstPar( "SupplierGenId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "SupplierGenId");
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
            PA4E2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV23Pgmname = "Trn_SupplierGenGeneral";
               edtavSuppliergenphonecode_description_Enabled = 0;
               AssignProp(sPrefix, false, edtavSuppliergenphonecode_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSuppliergenphonecode_description_Enabled), 5, 0), true);
               edtavSuppliergenlandlinecode_description_Enabled = 0;
               AssignProp(sPrefix, false, edtavSuppliergenlandlinecode_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSuppliergenlandlinecode_description_Enabled), 5, 0), true);
               edtavSuppliergenaddresscountry_description_Enabled = 0;
               AssignProp(sPrefix, false, edtavSuppliergenaddresscountry_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSuppliergenaddresscountry_description_Enabled), 5, 0), true);
               WS4E2( ) ;
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
            context.SendWebValue( context.GetMessage( "Trn_Supplier Gen General", "")) ;
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
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
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
            GXEncryptionTmp = "trn_suppliergengeneral.aspx"+UrlEncode(A42SupplierGenId.ToString());
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_suppliergengeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"SUPPLIERGENDESCRIPTION", A604SupplierGenDescription);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA42SupplierGenId", wcpOA42SupplierGenId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"SUPPLIERGENDESCRIPTION_Enabled", StringUtil.BoolToStr( Suppliergendescription_Enabled));
         GxWebStd.gx_hidden_field( context, sPrefix+"SUPPLIERGENDESCRIPTION_Width", StringUtil.RTrim( Suppliergendescription_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"SUPPLIERGENDESCRIPTION_Height", StringUtil.RTrim( Suppliergendescription_Height));
         GxWebStd.gx_hidden_field( context, sPrefix+"SUPPLIERGENDESCRIPTION_Skin", StringUtil.RTrim( Suppliergendescription_Skin));
         GxWebStd.gx_hidden_field( context, sPrefix+"SUPPLIERGENDESCRIPTION_Toolbar", StringUtil.RTrim( Suppliergendescription_Toolbar));
         GxWebStd.gx_hidden_field( context, sPrefix+"SUPPLIERGENDESCRIPTION_Customtoolbar", StringUtil.RTrim( Suppliergendescription_Customtoolbar));
         GxWebStd.gx_hidden_field( context, sPrefix+"SUPPLIERGENDESCRIPTION_Customconfiguration", StringUtil.RTrim( Suppliergendescription_Customconfiguration));
         GxWebStd.gx_hidden_field( context, sPrefix+"SUPPLIERGENDESCRIPTION_Toolbarcancollapse", StringUtil.BoolToStr( Suppliergendescription_Toolbarcancollapse));
         GxWebStd.gx_hidden_field( context, sPrefix+"SUPPLIERGENDESCRIPTION_Captionclass", StringUtil.RTrim( Suppliergendescription_Captionclass));
         GxWebStd.gx_hidden_field( context, sPrefix+"SUPPLIERGENDESCRIPTION_Captionstyle", StringUtil.RTrim( Suppliergendescription_Captionstyle));
         GxWebStd.gx_hidden_field( context, sPrefix+"SUPPLIERGENDESCRIPTION_Captionposition", StringUtil.RTrim( Suppliergendescription_Captionposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"SUPPLIERGENDESCRIPTION_Visible", StringUtil.BoolToStr( Suppliergendescription_Visible));
      }

      protected void RenderHtmlCloseForm4E2( )
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
         return "Trn_SupplierGenGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Supplier Gen General", "") ;
      }

      protected void WB4E0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "trn_suppliergengeneral.aspx");
               context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
               context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, context.GetMessage( "Supplier Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_SupplierGenGeneral.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenKvkNumber_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplierGenKvkNumber_Internalname, context.GetMessage( "KvK Number", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplierGenKvkNumber_Internalname, A43SupplierGenKvkNumber, StringUtil.RTrim( context.localUtil.Format( A43SupplierGenKvkNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenKvkNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenKvkNumber_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, true, "KvkNumber", "start", true, "", "HLP_Trn_SupplierGenGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenCompanyName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplierGenCompanyName_Internalname, context.GetMessage( "Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplierGenCompanyName_Internalname, A44SupplierGenCompanyName, StringUtil.RTrim( context.localUtil.Format( A44SupplierGenCompanyName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenCompanyName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenCompanyName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_SupplierGenGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenTypeName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplierGenTypeName_Internalname, context.GetMessage( "Category", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplierGenTypeName_Internalname, A254SupplierGenTypeName, StringUtil.RTrim( context.localUtil.Format( A254SupplierGenTypeName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenTypeName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenTypeName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_SupplierGenGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenContactName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplierGenContactName_Internalname, context.GetMessage( "Contact Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplierGenContactName_Internalname, A47SupplierGenContactName, StringUtil.RTrim( context.localUtil.Format( A47SupplierGenContactName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenContactName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenContactName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_SupplierGenGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable5_Internalname, divUnnamedtable5_Visible, 0, "px", 0, "px", "CellMarginBottom10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTransactiondetail_phonelabel_Internalname, context.GetMessage( "Phone", ""), "", "", lblTransactiondetail_phonelabel_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_Trn_SupplierGenGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable10_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable11_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 PhoneLabel", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSuppliergenphonecode_description_Internalname, context.GetMessage( "Supplier Gen Phone Code_Description", ""), "col-sm-3 DropDownComponentLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSuppliergenphonecode_description_Internalname, AV19SupplierGenPhoneCode_Description, StringUtil.RTrim( context.localUtil.Format( AV19SupplierGenPhoneCode_Description, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSuppliergenphonecode_description_Jsonclick, 0, "DropDownComponent", "", "", "", "", 1, edtavSuppliergenphonecode_description_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGenGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplierGenPhoneNumber_Internalname, context.GetMessage( "Supplier Gen Phone Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplierGenPhoneNumber_Internalname, A354SupplierGenPhoneNumber, StringUtil.RTrim( context.localUtil.Format( A354SupplierGenPhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenPhoneNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenPhoneNumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGenGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, divUnnamedtable6_Internalname, divUnnamedtable6_Visible, 0, "px", 0, "px", "CellMarginBottom10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTransactiondetail_phonelabellandline_Internalname, context.GetMessage( "Landline", ""), "", "", lblTransactiondetail_phonelabellandline_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_Trn_SupplierGenGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable8_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable9_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 PhoneLabel", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSuppliergenlandlinecode_description_Internalname, context.GetMessage( "Supplier Gen Landline Code_Description", ""), "col-sm-3 DropDownComponentLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSuppliergenlandlinecode_description_Internalname, AV20SupplierGenLandlineCode_Description, StringUtil.RTrim( context.localUtil.Format( AV20SupplierGenLandlineCode_Description, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSuppliergenlandlinecode_description_Jsonclick, 0, "DropDownComponent", "", "", "", "", 1, edtavSuppliergenlandlinecode_description_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGenGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplierGenLandlineSubNumber_Internalname, context.GetMessage( "Supplier Gen Landline Sub Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplierGenLandlineSubNumber_Internalname, A606SupplierGenLandlineSubNumber, StringUtil.RTrim( context.localUtil.Format( A606SupplierGenLandlineSubNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenLandlineSubNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenLandlineSubNumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGenGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, divSuppliergencontactphone_cell_Internalname, 1, 0, "px", 0, "px", divSuppliergencontactphone_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtSupplierGenContactPhone_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenContactPhone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplierGenContactPhone_Internalname, context.GetMessage( "Contact Phone", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A48SupplierGenContactPhone);
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplierGenContactPhone_Internalname, StringUtil.RTrim( A48SupplierGenContactPhone), StringUtil.RTrim( context.localUtil.Format( A48SupplierGenContactPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtSupplierGenContactPhone_Jsonclick, 0, "Attribute", "", "", "", "", edtSupplierGenContactPhone_Visible, edtSupplierGenContactPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Trn_SupplierGenGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSuppliergenlandlinenumber_cell_Internalname, 1, 0, "px", 0, "px", divSuppliergenlandlinenumber_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtSupplierGenLandlineNumber_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenLandlineNumber_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplierGenLandlineNumber_Internalname, context.GetMessage( "Landline", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplierGenLandlineNumber_Internalname, A607SupplierGenLandlineNumber, StringUtil.RTrim( context.localUtil.Format( A607SupplierGenLandlineNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenLandlineNumber_Jsonclick, 0, "Attribute", "", "", "", "", edtSupplierGenLandlineNumber_Visible, edtSupplierGenLandlineNumber_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGenGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenEmail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplierGenEmail_Internalname, context.GetMessage( "Email", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplierGenEmail_Internalname, A501SupplierGenEmail, StringUtil.RTrim( context.localUtil.Format( A501SupplierGenEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "mailto:"+A501SupplierGenEmail, "", "", "", edtSupplierGenEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Trn_SupplierGenGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenWebsite_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplierGenWebsite_Internalname, context.GetMessage( "Website", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplierGenWebsite_Internalname, A428SupplierGenWebsite, StringUtil.RTrim( context.localUtil.Format( A428SupplierGenWebsite, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenWebsite_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenWebsite_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGenGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSuppliergendescription_cell_Internalname, 1, 0, "px", 0, "px", divSuppliergendescription_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+Suppliergendescription_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, Suppliergendescription_Internalname, context.GetMessage( "Description", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* User Defined Control */
            ucSuppliergendescription.SetProperty("Width", Suppliergendescription_Width);
            ucSuppliergendescription.SetProperty("Height", Suppliergendescription_Height);
            ucSuppliergendescription.SetProperty("Attribute", SupplierGenDescription);
            ucSuppliergendescription.SetProperty("Skin", Suppliergendescription_Skin);
            ucSuppliergendescription.SetProperty("Toolbar", Suppliergendescription_Toolbar);
            ucSuppliergendescription.SetProperty("CustomToolbar", Suppliergendescription_Customtoolbar);
            ucSuppliergendescription.SetProperty("CustomConfiguration", Suppliergendescription_Customconfiguration);
            ucSuppliergendescription.SetProperty("ToolbarCanCollapse", Suppliergendescription_Toolbarcancollapse);
            ucSuppliergendescription.SetProperty("CaptionClass", Suppliergendescription_Captionclass);
            ucSuppliergendescription.SetProperty("CaptionStyle", Suppliergendescription_Captionstyle);
            ucSuppliergendescription.SetProperty("CaptionPosition", Suppliergendescription_Captionposition);
            ucSuppliergendescription.Render(context, "fckeditor", Suppliergendescription_Internalname, sPrefix+"SUPPLIERGENDESCRIPTIONContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_descriptiontable_Internalname, divTransactiondetail_descriptiontable_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTransactiondetail_textblockdescriptionlabel_Internalname, context.GetMessage( "Description", ""), "", "", lblTransactiondetail_textblockdescriptionlabel_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_Trn_SupplierGenGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable7_Internalname, 1, 0, "px", 0, "px", "HTMLTextOverfow", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTransactiondetail_descriptiontext_Internalname, lblTransactiondetail_descriptiontext_Caption, "", "", lblTransactiondetail_descriptiontext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DynamicFormHTMLEditor", 0, "", 1, 1, 0, 1, "HLP_Trn_SupplierGenGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup4_Internalname, context.GetMessage( "Address Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_SupplierGenGeneral.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenAddressLine1_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplierGenAddressLine1_Internalname, context.GetMessage( "Address Line 1", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplierGenAddressLine1_Internalname, A310SupplierGenAddressLine1, StringUtil.RTrim( context.localUtil.Format( A310SupplierGenAddressLine1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,112);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenAddressLine1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenAddressLine1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGenGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenAddressLine2_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplierGenAddressLine2_Internalname, context.GetMessage( "Address Line 2", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplierGenAddressLine2_Internalname, A311SupplierGenAddressLine2, StringUtil.RTrim( context.localUtil.Format( A311SupplierGenAddressLine2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,117);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenAddressLine2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenAddressLine2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGenGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenAddressZipCode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplierGenAddressZipCode_Internalname, context.GetMessage( "Zipcode", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 122,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplierGenAddressZipCode_Internalname, A259SupplierGenAddressZipCode, StringUtil.RTrim( context.localUtil.Format( A259SupplierGenAddressZipCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,122);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenAddressZipCode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenAddressZipCode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGenGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenAddressCity_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplierGenAddressCity_Internalname, context.GetMessage( "City", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplierGenAddressCity_Internalname, A260SupplierGenAddressCity, StringUtil.RTrim( context.localUtil.Format( A260SupplierGenAddressCity, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,127);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenAddressCity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenAddressCity_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGenGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSuppliergenaddresscountry_description_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSuppliergenaddresscountry_description_Internalname, context.GetMessage( " Country", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 132,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSuppliergenaddresscountry_description_Internalname, AV14SupplierGenAddressCountry_Description, StringUtil.RTrim( context.localUtil.Format( AV14SupplierGenAddressCountry_Description, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,132);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSuppliergenaddresscountry_description_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSuppliergenaddresscountry_description_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGenGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 137,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtncancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_SupplierGenGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtSupplierGenId_Internalname, A42SupplierGenId.ToString(), A42SupplierGenId.ToString(), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenId_Jsonclick, 0, "Attribute", "", "", "", "", edtSupplierGenId_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_SupplierGenGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START4E2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Trn_Supplier Gen General", ""), 0) ;
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
               STRUP4E0( ) ;
            }
         }
      }

      protected void WS4E2( )
      {
         START4E2( ) ;
         EVT4E2( ) ;
      }

      protected void EVT4E2( )
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
                                 STRUP4E0( ) ;
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
                                 STRUP4E0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E114E2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4E0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E124E2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4E0( ) ;
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
                                 STRUP4E0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavSuppliergenphonecode_description_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
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
      }

      protected void WE4E2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm4E2( ) ;
            }
         }
      }

      protected void PA4E2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_suppliergengeneral.aspx")), "trn_suppliergengeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_suppliergengeneral.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "SupplierGenId");
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
               GX_FocusControl = edtavSuppliergenphonecode_description_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
         RF4E2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV23Pgmname = "Trn_SupplierGenGeneral";
         edtavSuppliergenphonecode_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavSuppliergenphonecode_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSuppliergenphonecode_description_Enabled), 5, 0), true);
         edtavSuppliergenlandlinecode_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavSuppliergenlandlinecode_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSuppliergenlandlinecode_description_Enabled), 5, 0), true);
         edtavSuppliergenaddresscountry_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavSuppliergenaddresscountry_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSuppliergenaddresscountry_description_Enabled), 5, 0), true);
      }

      protected void RF4E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H004E2 */
            pr_default.execute(0, new Object[] {A42SupplierGenId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A253SupplierGenTypeId = H004E2_A253SupplierGenTypeId[0];
               A260SupplierGenAddressCity = H004E2_A260SupplierGenAddressCity[0];
               AssignAttri(sPrefix, false, "A260SupplierGenAddressCity", A260SupplierGenAddressCity);
               A259SupplierGenAddressZipCode = H004E2_A259SupplierGenAddressZipCode[0];
               AssignAttri(sPrefix, false, "A259SupplierGenAddressZipCode", A259SupplierGenAddressZipCode);
               A311SupplierGenAddressLine2 = H004E2_A311SupplierGenAddressLine2[0];
               AssignAttri(sPrefix, false, "A311SupplierGenAddressLine2", A311SupplierGenAddressLine2);
               A310SupplierGenAddressLine1 = H004E2_A310SupplierGenAddressLine1[0];
               AssignAttri(sPrefix, false, "A310SupplierGenAddressLine1", A310SupplierGenAddressLine1);
               A604SupplierGenDescription = H004E2_A604SupplierGenDescription[0];
               A428SupplierGenWebsite = H004E2_A428SupplierGenWebsite[0];
               AssignAttri(sPrefix, false, "A428SupplierGenWebsite", A428SupplierGenWebsite);
               A501SupplierGenEmail = H004E2_A501SupplierGenEmail[0];
               AssignAttri(sPrefix, false, "A501SupplierGenEmail", A501SupplierGenEmail);
               A607SupplierGenLandlineNumber = H004E2_A607SupplierGenLandlineNumber[0];
               AssignAttri(sPrefix, false, "A607SupplierGenLandlineNumber", A607SupplierGenLandlineNumber);
               A48SupplierGenContactPhone = H004E2_A48SupplierGenContactPhone[0];
               AssignAttri(sPrefix, false, "A48SupplierGenContactPhone", A48SupplierGenContactPhone);
               A606SupplierGenLandlineSubNumber = H004E2_A606SupplierGenLandlineSubNumber[0];
               AssignAttri(sPrefix, false, "A606SupplierGenLandlineSubNumber", A606SupplierGenLandlineSubNumber);
               A354SupplierGenPhoneNumber = H004E2_A354SupplierGenPhoneNumber[0];
               AssignAttri(sPrefix, false, "A354SupplierGenPhoneNumber", A354SupplierGenPhoneNumber);
               A47SupplierGenContactName = H004E2_A47SupplierGenContactName[0];
               AssignAttri(sPrefix, false, "A47SupplierGenContactName", A47SupplierGenContactName);
               A254SupplierGenTypeName = H004E2_A254SupplierGenTypeName[0];
               AssignAttri(sPrefix, false, "A254SupplierGenTypeName", A254SupplierGenTypeName);
               A44SupplierGenCompanyName = H004E2_A44SupplierGenCompanyName[0];
               AssignAttri(sPrefix, false, "A44SupplierGenCompanyName", A44SupplierGenCompanyName);
               A43SupplierGenKvkNumber = H004E2_A43SupplierGenKvkNumber[0];
               AssignAttri(sPrefix, false, "A43SupplierGenKvkNumber", A43SupplierGenKvkNumber);
               A254SupplierGenTypeName = H004E2_A254SupplierGenTypeName[0];
               AssignAttri(sPrefix, false, "A254SupplierGenTypeName", A254SupplierGenTypeName);
               /* Execute user event: Load */
               E124E2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB4E0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4E2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV23Pgmname = "Trn_SupplierGenGeneral";
         edtavSuppliergenphonecode_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavSuppliergenphonecode_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSuppliergenphonecode_description_Enabled), 5, 0), true);
         edtavSuppliergenlandlinecode_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavSuppliergenlandlinecode_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSuppliergenlandlinecode_description_Enabled), 5, 0), true);
         edtavSuppliergenaddresscountry_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavSuppliergenaddresscountry_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSuppliergenaddresscountry_description_Enabled), 5, 0), true);
         edtSupplierGenKvkNumber_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplierGenKvkNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenKvkNumber_Enabled), 5, 0), true);
         edtSupplierGenCompanyName_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplierGenCompanyName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenCompanyName_Enabled), 5, 0), true);
         edtSupplierGenTypeName_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplierGenTypeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenTypeName_Enabled), 5, 0), true);
         edtSupplierGenContactName_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplierGenContactName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenContactName_Enabled), 5, 0), true);
         edtSupplierGenPhoneNumber_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplierGenPhoneNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenPhoneNumber_Enabled), 5, 0), true);
         edtSupplierGenLandlineSubNumber_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplierGenLandlineSubNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenLandlineSubNumber_Enabled), 5, 0), true);
         edtSupplierGenContactPhone_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplierGenContactPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenContactPhone_Enabled), 5, 0), true);
         edtSupplierGenLandlineNumber_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplierGenLandlineNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenLandlineNumber_Enabled), 5, 0), true);
         edtSupplierGenEmail_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplierGenEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenEmail_Enabled), 5, 0), true);
         edtSupplierGenWebsite_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplierGenWebsite_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenWebsite_Enabled), 5, 0), true);
         edtSupplierGenAddressLine1_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplierGenAddressLine1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenAddressLine1_Enabled), 5, 0), true);
         edtSupplierGenAddressLine2_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplierGenAddressLine2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenAddressLine2_Enabled), 5, 0), true);
         edtSupplierGenAddressZipCode_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplierGenAddressZipCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenAddressZipCode_Enabled), 5, 0), true);
         edtSupplierGenAddressCity_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplierGenAddressCity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenAddressCity_Enabled), 5, 0), true);
         edtSupplierGenId_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplierGenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenId_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E114E2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            A604SupplierGenDescription = cgiGet( sPrefix+"SUPPLIERGENDESCRIPTION");
            wcpOA42SupplierGenId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA42SupplierGenId"));
            Suppliergendescription_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"SUPPLIERGENDESCRIPTION_Enabled"));
            Suppliergendescription_Width = cgiGet( sPrefix+"SUPPLIERGENDESCRIPTION_Width");
            Suppliergendescription_Height = cgiGet( sPrefix+"SUPPLIERGENDESCRIPTION_Height");
            Suppliergendescription_Skin = cgiGet( sPrefix+"SUPPLIERGENDESCRIPTION_Skin");
            Suppliergendescription_Toolbar = cgiGet( sPrefix+"SUPPLIERGENDESCRIPTION_Toolbar");
            Suppliergendescription_Customtoolbar = cgiGet( sPrefix+"SUPPLIERGENDESCRIPTION_Customtoolbar");
            Suppliergendescription_Customconfiguration = cgiGet( sPrefix+"SUPPLIERGENDESCRIPTION_Customconfiguration");
            Suppliergendescription_Toolbarcancollapse = StringUtil.StrToBool( cgiGet( sPrefix+"SUPPLIERGENDESCRIPTION_Toolbarcancollapse"));
            Suppliergendescription_Captionclass = cgiGet( sPrefix+"SUPPLIERGENDESCRIPTION_Captionclass");
            Suppliergendescription_Captionstyle = cgiGet( sPrefix+"SUPPLIERGENDESCRIPTION_Captionstyle");
            Suppliergendescription_Captionposition = cgiGet( sPrefix+"SUPPLIERGENDESCRIPTION_Captionposition");
            Suppliergendescription_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"SUPPLIERGENDESCRIPTION_Visible"));
            /* Read variables values. */
            A43SupplierGenKvkNumber = cgiGet( edtSupplierGenKvkNumber_Internalname);
            AssignAttri(sPrefix, false, "A43SupplierGenKvkNumber", A43SupplierGenKvkNumber);
            A44SupplierGenCompanyName = cgiGet( edtSupplierGenCompanyName_Internalname);
            AssignAttri(sPrefix, false, "A44SupplierGenCompanyName", A44SupplierGenCompanyName);
            A254SupplierGenTypeName = cgiGet( edtSupplierGenTypeName_Internalname);
            AssignAttri(sPrefix, false, "A254SupplierGenTypeName", A254SupplierGenTypeName);
            A47SupplierGenContactName = cgiGet( edtSupplierGenContactName_Internalname);
            AssignAttri(sPrefix, false, "A47SupplierGenContactName", A47SupplierGenContactName);
            AV19SupplierGenPhoneCode_Description = cgiGet( edtavSuppliergenphonecode_description_Internalname);
            AssignAttri(sPrefix, false, "AV19SupplierGenPhoneCode_Description", AV19SupplierGenPhoneCode_Description);
            A354SupplierGenPhoneNumber = cgiGet( edtSupplierGenPhoneNumber_Internalname);
            AssignAttri(sPrefix, false, "A354SupplierGenPhoneNumber", A354SupplierGenPhoneNumber);
            AV20SupplierGenLandlineCode_Description = cgiGet( edtavSuppliergenlandlinecode_description_Internalname);
            AssignAttri(sPrefix, false, "AV20SupplierGenLandlineCode_Description", AV20SupplierGenLandlineCode_Description);
            A606SupplierGenLandlineSubNumber = cgiGet( edtSupplierGenLandlineSubNumber_Internalname);
            AssignAttri(sPrefix, false, "A606SupplierGenLandlineSubNumber", A606SupplierGenLandlineSubNumber);
            A48SupplierGenContactPhone = cgiGet( edtSupplierGenContactPhone_Internalname);
            AssignAttri(sPrefix, false, "A48SupplierGenContactPhone", A48SupplierGenContactPhone);
            A607SupplierGenLandlineNumber = cgiGet( edtSupplierGenLandlineNumber_Internalname);
            AssignAttri(sPrefix, false, "A607SupplierGenLandlineNumber", A607SupplierGenLandlineNumber);
            A501SupplierGenEmail = cgiGet( edtSupplierGenEmail_Internalname);
            AssignAttri(sPrefix, false, "A501SupplierGenEmail", A501SupplierGenEmail);
            A428SupplierGenWebsite = cgiGet( edtSupplierGenWebsite_Internalname);
            AssignAttri(sPrefix, false, "A428SupplierGenWebsite", A428SupplierGenWebsite);
            A310SupplierGenAddressLine1 = cgiGet( edtSupplierGenAddressLine1_Internalname);
            AssignAttri(sPrefix, false, "A310SupplierGenAddressLine1", A310SupplierGenAddressLine1);
            A311SupplierGenAddressLine2 = cgiGet( edtSupplierGenAddressLine2_Internalname);
            AssignAttri(sPrefix, false, "A311SupplierGenAddressLine2", A311SupplierGenAddressLine2);
            A259SupplierGenAddressZipCode = cgiGet( edtSupplierGenAddressZipCode_Internalname);
            AssignAttri(sPrefix, false, "A259SupplierGenAddressZipCode", A259SupplierGenAddressZipCode);
            A260SupplierGenAddressCity = cgiGet( edtSupplierGenAddressCity_Internalname);
            AssignAttri(sPrefix, false, "A260SupplierGenAddressCity", A260SupplierGenAddressCity);
            AV14SupplierGenAddressCountry_Description = cgiGet( edtavSuppliergenaddresscountry_description_Internalname);
            AssignAttri(sPrefix, false, "AV14SupplierGenAddressCountry_Description", AV14SupplierGenAddressCountry_Description);
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
         E114E2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E114E2( )
      {
         /* Start Routine */
         returnInSub = false;
         Gx_mode = "DSP";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         GXt_objcol_SdtDVB_SDTComboData_Item1 = AV15Combo_Data;
         new trn_suppliergenloaddvcombo(context ).execute(  "SupplierGenAddressCountry",  "GET_DSC",  A42SupplierGenId, out  AV17ComboSelectedValue, out  AV14SupplierGenAddressCountry_Description, out  GXt_objcol_SdtDVB_SDTComboData_Item1) ;
         AssignAttri(sPrefix, false, "AV14SupplierGenAddressCountry_Description", AV14SupplierGenAddressCountry_Description);
         AV15Combo_Data = GXt_objcol_SdtDVB_SDTComboData_Item1;
         GXt_objcol_SdtDVB_SDTComboData_Item1 = AV15Combo_Data;
         new trn_suppliergenloaddvcombo(context ).execute(  "SupplierGenLandlineCode",  "GET_DSC",  A42SupplierGenId, out  AV17ComboSelectedValue, out  AV20SupplierGenLandlineCode_Description, out  GXt_objcol_SdtDVB_SDTComboData_Item1) ;
         AssignAttri(sPrefix, false, "AV20SupplierGenLandlineCode_Description", AV20SupplierGenLandlineCode_Description);
         AV15Combo_Data = GXt_objcol_SdtDVB_SDTComboData_Item1;
         GXt_objcol_SdtDVB_SDTComboData_Item1 = AV15Combo_Data;
         new trn_suppliergenloaddvcombo(context ).execute(  "SupplierGenPhoneCode",  "GET_DSC",  A42SupplierGenId, out  AV17ComboSelectedValue, out  AV19SupplierGenPhoneCode_Description, out  GXt_objcol_SdtDVB_SDTComboData_Item1) ;
         AssignAttri(sPrefix, false, "AV19SupplierGenPhoneCode_Description", AV19SupplierGenPhoneCode_Description);
         AV15Combo_Data = GXt_objcol_SdtDVB_SDTComboData_Item1;
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E124E2( )
      {
         /* Load Routine */
         returnInSub = false;
         Gx_mode = "DSP";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         lblTransactiondetail_descriptiontext_Caption = A604SupplierGenDescription;
         AssignProp(sPrefix, false, lblTransactiondetail_descriptiontext_Internalname, "Caption", lblTransactiondetail_descriptiontext_Caption, true);
         edtSupplierGenId_Visible = 0;
         AssignProp(sPrefix, false, edtSupplierGenId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierGenId_Visible), 5, 0), true);
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) ) )
         {
            edtSupplierGenContactPhone_Visible = 0;
            AssignProp(sPrefix, false, edtSupplierGenContactPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierGenContactPhone_Visible), 5, 0), true);
            divSuppliergencontactphone_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divSuppliergencontactphone_cell_Internalname, "Class", divSuppliergencontactphone_cell_Class, true);
         }
         else
         {
            edtSupplierGenContactPhone_Visible = 1;
            AssignProp(sPrefix, false, edtSupplierGenContactPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierGenContactPhone_Visible), 5, 0), true);
            divSuppliergencontactphone_cell_Class = "col-xs-12 DataContentCell";
            AssignProp(sPrefix, false, divSuppliergencontactphone_cell_Internalname, "Class", divSuppliergencontactphone_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) ) )
         {
            edtSupplierGenLandlineNumber_Visible = 0;
            AssignProp(sPrefix, false, edtSupplierGenLandlineNumber_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierGenLandlineNumber_Visible), 5, 0), true);
            divSuppliergenlandlinenumber_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divSuppliergenlandlinenumber_cell_Internalname, "Class", divSuppliergenlandlinenumber_cell_Class, true);
         }
         else
         {
            edtSupplierGenLandlineNumber_Visible = 1;
            AssignProp(sPrefix, false, edtSupplierGenLandlineNumber_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierGenLandlineNumber_Visible), 5, 0), true);
            divSuppliergenlandlinenumber_cell_Class = "col-xs-12 DataContentCell";
            AssignProp(sPrefix, false, divSuppliergenlandlinenumber_cell_Internalname, "Class", divSuppliergenlandlinenumber_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) ) )
         {
            Suppliergendescription_Visible = false;
            AssignProp(sPrefix, false, Suppliergendescription_Internalname, "Visible", StringUtil.BoolToStr( Suppliergendescription_Visible), true);
            divSuppliergendescription_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divSuppliergendescription_cell_Internalname, "Class", divSuppliergendescription_cell_Class, true);
         }
         else
         {
            Suppliergendescription_Visible = true;
            AssignProp(sPrefix, false, Suppliergendescription_Internalname, "Visible", StringUtil.BoolToStr( Suppliergendescription_Visible), true);
            divSuppliergendescription_cell_Class = "col-xs-12 DataContentCell CKEditor";
            AssignProp(sPrefix, false, divSuppliergendescription_cell_Internalname, "Class", divSuppliergendescription_cell_Class, true);
         }
         divUnnamedtable5_Visible = (((StringUtil.StrCmp(Gx_mode, "INS")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0)) ? 1 : 0);
         AssignProp(sPrefix, false, divUnnamedtable5_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUnnamedtable5_Visible), 5, 0), true);
         divUnnamedtable6_Visible = (((StringUtil.StrCmp(Gx_mode, "INS")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0)) ? 1 : 0);
         AssignProp(sPrefix, false, divUnnamedtable6_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUnnamedtable6_Visible), 5, 0), true);
         divTransactiondetail_descriptiontable_Visible = (((StringUtil.StrCmp(Gx_mode, "DSP")==0)) ? 1 : 0);
         AssignProp(sPrefix, false, divTransactiondetail_descriptiontable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTransactiondetail_descriptiontable_Visible), 5, 0), true);
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV23Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Trn_SupplierGen";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A42SupplierGenId = (Guid)getParm(obj,0);
         AssignAttri(sPrefix, false, "A42SupplierGenId", A42SupplierGenId.ToString());
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
         PA4E2( ) ;
         WS4E2( ) ;
         WE4E2( ) ;
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
         sCtrlA42SupplierGenId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA4E2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "trn_suppliergengeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA4E2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A42SupplierGenId = (Guid)getParm(obj,2);
            AssignAttri(sPrefix, false, "A42SupplierGenId", A42SupplierGenId.ToString());
         }
         wcpOA42SupplierGenId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA42SupplierGenId"));
         if ( ! GetJustCreated( ) && ( ( A42SupplierGenId != wcpOA42SupplierGenId ) ) )
         {
            setjustcreated();
         }
         wcpOA42SupplierGenId = A42SupplierGenId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA42SupplierGenId = cgiGet( sPrefix+"A42SupplierGenId_CTRL");
         if ( StringUtil.Len( sCtrlA42SupplierGenId) > 0 )
         {
            A42SupplierGenId = StringUtil.StrToGuid( cgiGet( sCtrlA42SupplierGenId));
            AssignAttri(sPrefix, false, "A42SupplierGenId", A42SupplierGenId.ToString());
         }
         else
         {
            A42SupplierGenId = StringUtil.StrToGuid( cgiGet( sPrefix+"A42SupplierGenId_PARM"));
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
         PA4E2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS4E2( ) ;
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
         WS4E2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A42SupplierGenId_PARM", A42SupplierGenId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA42SupplierGenId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A42SupplierGenId_CTRL", StringUtil.RTrim( sCtrlA42SupplierGenId));
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
         WE4E2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202562016571978", true, true);
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
         context.AddJavascriptSource("trn_suppliergengeneral.js", "?202562016571978", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtSupplierGenKvkNumber_Internalname = sPrefix+"SUPPLIERGENKVKNUMBER";
         edtSupplierGenCompanyName_Internalname = sPrefix+"SUPPLIERGENCOMPANYNAME";
         edtSupplierGenTypeName_Internalname = sPrefix+"SUPPLIERGENTYPENAME";
         edtSupplierGenContactName_Internalname = sPrefix+"SUPPLIERGENCONTACTNAME";
         lblTransactiondetail_phonelabel_Internalname = sPrefix+"TRANSACTIONDETAIL_PHONELABEL";
         edtavSuppliergenphonecode_description_Internalname = sPrefix+"vSUPPLIERGENPHONECODE_DESCRIPTION";
         divUnnamedtable11_Internalname = sPrefix+"UNNAMEDTABLE11";
         edtSupplierGenPhoneNumber_Internalname = sPrefix+"SUPPLIERGENPHONENUMBER";
         divUnnamedtable10_Internalname = sPrefix+"UNNAMEDTABLE10";
         divUnnamedtable5_Internalname = sPrefix+"UNNAMEDTABLE5";
         lblTransactiondetail_phonelabellandline_Internalname = sPrefix+"TRANSACTIONDETAIL_PHONELABELLANDLINE";
         edtavSuppliergenlandlinecode_description_Internalname = sPrefix+"vSUPPLIERGENLANDLINECODE_DESCRIPTION";
         divUnnamedtable9_Internalname = sPrefix+"UNNAMEDTABLE9";
         edtSupplierGenLandlineSubNumber_Internalname = sPrefix+"SUPPLIERGENLANDLINESUBNUMBER";
         divUnnamedtable8_Internalname = sPrefix+"UNNAMEDTABLE8";
         divUnnamedtable6_Internalname = sPrefix+"UNNAMEDTABLE6";
         edtSupplierGenContactPhone_Internalname = sPrefix+"SUPPLIERGENCONTACTPHONE";
         divSuppliergencontactphone_cell_Internalname = sPrefix+"SUPPLIERGENCONTACTPHONE_CELL";
         edtSupplierGenLandlineNumber_Internalname = sPrefix+"SUPPLIERGENLANDLINENUMBER";
         divSuppliergenlandlinenumber_cell_Internalname = sPrefix+"SUPPLIERGENLANDLINENUMBER_CELL";
         edtSupplierGenEmail_Internalname = sPrefix+"SUPPLIERGENEMAIL";
         edtSupplierGenWebsite_Internalname = sPrefix+"SUPPLIERGENWEBSITE";
         Suppliergendescription_Internalname = sPrefix+"SUPPLIERGENDESCRIPTION";
         divSuppliergendescription_cell_Internalname = sPrefix+"SUPPLIERGENDESCRIPTION_CELL";
         lblTransactiondetail_textblockdescriptionlabel_Internalname = sPrefix+"TRANSACTIONDETAIL_TEXTBLOCKDESCRIPTIONLABEL";
         lblTransactiondetail_descriptiontext_Internalname = sPrefix+"TRANSACTIONDETAIL_DESCRIPTIONTEXT";
         divUnnamedtable7_Internalname = sPrefix+"UNNAMEDTABLE7";
         divTransactiondetail_descriptiontable_Internalname = sPrefix+"TRANSACTIONDETAIL_DESCRIPTIONTABLE";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         grpUnnamedgroup2_Internalname = sPrefix+"UNNAMEDGROUP2";
         edtSupplierGenAddressLine1_Internalname = sPrefix+"SUPPLIERGENADDRESSLINE1";
         edtSupplierGenAddressLine2_Internalname = sPrefix+"SUPPLIERGENADDRESSLINE2";
         edtSupplierGenAddressZipCode_Internalname = sPrefix+"SUPPLIERGENADDRESSZIPCODE";
         edtSupplierGenAddressCity_Internalname = sPrefix+"SUPPLIERGENADDRESSCITY";
         edtavSuppliergenaddresscountry_description_Internalname = sPrefix+"vSUPPLIERGENADDRESSCOUNTRY_DESCRIPTION";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         grpUnnamedgroup4_Internalname = sPrefix+"UNNAMEDGROUP4";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtncancel_Internalname = sPrefix+"BTNCANCEL";
         divTable_Internalname = sPrefix+"TABLE";
         edtSupplierGenId_Internalname = sPrefix+"SUPPLIERGENID";
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
         edtSupplierGenId_Enabled = 0;
         edtSupplierGenId_Jsonclick = "";
         edtSupplierGenId_Visible = 1;
         edtavSuppliergenaddresscountry_description_Jsonclick = "";
         edtavSuppliergenaddresscountry_description_Enabled = 1;
         edtSupplierGenAddressCity_Jsonclick = "";
         edtSupplierGenAddressCity_Enabled = 0;
         edtSupplierGenAddressZipCode_Jsonclick = "";
         edtSupplierGenAddressZipCode_Enabled = 0;
         edtSupplierGenAddressLine2_Jsonclick = "";
         edtSupplierGenAddressLine2_Enabled = 0;
         edtSupplierGenAddressLine1_Jsonclick = "";
         edtSupplierGenAddressLine1_Enabled = 0;
         lblTransactiondetail_descriptiontext_Caption = "";
         divTransactiondetail_descriptiontable_Visible = 1;
         Suppliergendescription_Enabled = Convert.ToBoolean( 0);
         divSuppliergendescription_cell_Class = "col-xs-12";
         edtSupplierGenWebsite_Jsonclick = "";
         edtSupplierGenWebsite_Enabled = 0;
         edtSupplierGenEmail_Jsonclick = "";
         edtSupplierGenEmail_Enabled = 0;
         edtSupplierGenLandlineNumber_Jsonclick = "";
         edtSupplierGenLandlineNumber_Enabled = 0;
         edtSupplierGenLandlineNumber_Visible = 1;
         divSuppliergenlandlinenumber_cell_Class = "col-xs-12";
         edtSupplierGenContactPhone_Jsonclick = "";
         edtSupplierGenContactPhone_Enabled = 0;
         edtSupplierGenContactPhone_Visible = 1;
         divSuppliergencontactphone_cell_Class = "col-xs-12";
         edtSupplierGenLandlineSubNumber_Jsonclick = "";
         edtSupplierGenLandlineSubNumber_Enabled = 0;
         edtavSuppliergenlandlinecode_description_Jsonclick = "";
         edtavSuppliergenlandlinecode_description_Enabled = 1;
         divUnnamedtable6_Visible = 1;
         edtSupplierGenPhoneNumber_Jsonclick = "";
         edtSupplierGenPhoneNumber_Enabled = 0;
         edtavSuppliergenphonecode_description_Jsonclick = "";
         edtavSuppliergenphonecode_description_Enabled = 1;
         divUnnamedtable5_Visible = 1;
         edtSupplierGenContactName_Jsonclick = "";
         edtSupplierGenContactName_Enabled = 0;
         edtSupplierGenTypeName_Jsonclick = "";
         edtSupplierGenTypeName_Enabled = 0;
         edtSupplierGenCompanyName_Jsonclick = "";
         edtSupplierGenCompanyName_Enabled = 0;
         edtSupplierGenKvkNumber_Jsonclick = "";
         edtSupplierGenKvkNumber_Enabled = 0;
         Suppliergendescription_Visible = Convert.ToBoolean( -1);
         Suppliergendescription_Captionposition = "Left";
         Suppliergendescription_Captionstyle = "";
         Suppliergendescription_Captionclass = "col-sm-4 AttributeLabel";
         Suppliergendescription_Toolbarcancollapse = Convert.ToBoolean( -1);
         Suppliergendescription_Customconfiguration = "myconfig.js";
         Suppliergendescription_Customtoolbar = "myToolbar";
         Suppliergendescription_Toolbar = "Custom";
         Suppliergendescription_Skin = "default";
         Suppliergendescription_Height = "250";
         Suppliergendescription_Width = "100%";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A42SupplierGenId","fld":"SUPPLIERGENID"}]}""");
         setEventMetadata("VALID_SUPPLIERGENID","""{"handler":"Valid_Suppliergenid","iparms":[]}""");
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
         wcpOA42SupplierGenId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV23Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         A604SupplierGenDescription = "";
         GX_FocusControl = "";
         TempTags = "";
         A43SupplierGenKvkNumber = "";
         A44SupplierGenCompanyName = "";
         A254SupplierGenTypeName = "";
         A47SupplierGenContactName = "";
         lblTransactiondetail_phonelabel_Jsonclick = "";
         AV19SupplierGenPhoneCode_Description = "";
         A354SupplierGenPhoneNumber = "";
         lblTransactiondetail_phonelabellandline_Jsonclick = "";
         AV20SupplierGenLandlineCode_Description = "";
         A606SupplierGenLandlineSubNumber = "";
         gxphoneLink = "";
         A48SupplierGenContactPhone = "";
         A607SupplierGenLandlineNumber = "";
         A501SupplierGenEmail = "";
         A428SupplierGenWebsite = "";
         ucSuppliergendescription = new GXUserControl();
         SupplierGenDescription = "";
         lblTransactiondetail_textblockdescriptionlabel_Jsonclick = "";
         lblTransactiondetail_descriptiontext_Jsonclick = "";
         A310SupplierGenAddressLine1 = "";
         A311SupplierGenAddressLine2 = "";
         A259SupplierGenAddressZipCode = "";
         A260SupplierGenAddressCity = "";
         AV14SupplierGenAddressCountry_Description = "";
         ClassString = "";
         StyleString = "";
         bttBtncancel_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H004E2_A253SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         H004E2_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         H004E2_A260SupplierGenAddressCity = new string[] {""} ;
         H004E2_A259SupplierGenAddressZipCode = new string[] {""} ;
         H004E2_A311SupplierGenAddressLine2 = new string[] {""} ;
         H004E2_A310SupplierGenAddressLine1 = new string[] {""} ;
         H004E2_A604SupplierGenDescription = new string[] {""} ;
         H004E2_A428SupplierGenWebsite = new string[] {""} ;
         H004E2_A501SupplierGenEmail = new string[] {""} ;
         H004E2_A607SupplierGenLandlineNumber = new string[] {""} ;
         H004E2_A48SupplierGenContactPhone = new string[] {""} ;
         H004E2_A606SupplierGenLandlineSubNumber = new string[] {""} ;
         H004E2_A354SupplierGenPhoneNumber = new string[] {""} ;
         H004E2_A47SupplierGenContactName = new string[] {""} ;
         H004E2_A254SupplierGenTypeName = new string[] {""} ;
         H004E2_A44SupplierGenCompanyName = new string[] {""} ;
         H004E2_A43SupplierGenKvkNumber = new string[] {""} ;
         A253SupplierGenTypeId = Guid.Empty;
         Gx_mode = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV15Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV17ComboSelectedValue = "";
         GXt_objcol_SdtDVB_SDTComboData_Item1 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA42SupplierGenId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_suppliergengeneral__default(),
            new Object[][] {
                new Object[] {
               H004E2_A253SupplierGenTypeId, H004E2_A42SupplierGenId, H004E2_A260SupplierGenAddressCity, H004E2_A259SupplierGenAddressZipCode, H004E2_A311SupplierGenAddressLine2, H004E2_A310SupplierGenAddressLine1, H004E2_A604SupplierGenDescription, H004E2_A428SupplierGenWebsite, H004E2_A501SupplierGenEmail, H004E2_A607SupplierGenLandlineNumber,
               H004E2_A48SupplierGenContactPhone, H004E2_A606SupplierGenLandlineSubNumber, H004E2_A354SupplierGenPhoneNumber, H004E2_A47SupplierGenContactName, H004E2_A254SupplierGenTypeName, H004E2_A44SupplierGenCompanyName, H004E2_A43SupplierGenKvkNumber
               }
            }
         );
         AV23Pgmname = "Trn_SupplierGenGeneral";
         /* GeneXus formulas. */
         AV23Pgmname = "Trn_SupplierGenGeneral";
         edtavSuppliergenphonecode_description_Enabled = 0;
         edtavSuppliergenlandlinecode_description_Enabled = 0;
         edtavSuppliergenaddresscountry_description_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int edtavSuppliergenphonecode_description_Enabled ;
      private int edtavSuppliergenlandlinecode_description_Enabled ;
      private int edtavSuppliergenaddresscountry_description_Enabled ;
      private int edtSupplierGenKvkNumber_Enabled ;
      private int edtSupplierGenCompanyName_Enabled ;
      private int edtSupplierGenTypeName_Enabled ;
      private int edtSupplierGenContactName_Enabled ;
      private int divUnnamedtable5_Visible ;
      private int edtSupplierGenPhoneNumber_Enabled ;
      private int divUnnamedtable6_Visible ;
      private int edtSupplierGenLandlineSubNumber_Enabled ;
      private int edtSupplierGenContactPhone_Visible ;
      private int edtSupplierGenContactPhone_Enabled ;
      private int edtSupplierGenLandlineNumber_Visible ;
      private int edtSupplierGenLandlineNumber_Enabled ;
      private int edtSupplierGenEmail_Enabled ;
      private int edtSupplierGenWebsite_Enabled ;
      private int divTransactiondetail_descriptiontable_Visible ;
      private int edtSupplierGenAddressLine1_Enabled ;
      private int edtSupplierGenAddressLine2_Enabled ;
      private int edtSupplierGenAddressZipCode_Enabled ;
      private int edtSupplierGenAddressCity_Enabled ;
      private int edtSupplierGenId_Visible ;
      private int edtSupplierGenId_Enabled ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV23Pgmname ;
      private string edtavSuppliergenphonecode_description_Internalname ;
      private string edtavSuppliergenlandlinecode_description_Internalname ;
      private string edtavSuppliergenaddresscountry_description_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Suppliergendescription_Width ;
      private string Suppliergendescription_Height ;
      private string Suppliergendescription_Skin ;
      private string Suppliergendescription_Toolbar ;
      private string Suppliergendescription_Customtoolbar ;
      private string Suppliergendescription_Customconfiguration ;
      private string Suppliergendescription_Captionclass ;
      private string Suppliergendescription_Captionstyle ;
      private string Suppliergendescription_Captionposition ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string grpUnnamedgroup2_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string edtSupplierGenKvkNumber_Internalname ;
      private string TempTags ;
      private string edtSupplierGenKvkNumber_Jsonclick ;
      private string edtSupplierGenCompanyName_Internalname ;
      private string edtSupplierGenCompanyName_Jsonclick ;
      private string edtSupplierGenTypeName_Internalname ;
      private string edtSupplierGenTypeName_Jsonclick ;
      private string edtSupplierGenContactName_Internalname ;
      private string edtSupplierGenContactName_Jsonclick ;
      private string divUnnamedtable5_Internalname ;
      private string lblTransactiondetail_phonelabel_Internalname ;
      private string lblTransactiondetail_phonelabel_Jsonclick ;
      private string divUnnamedtable10_Internalname ;
      private string divUnnamedtable11_Internalname ;
      private string edtavSuppliergenphonecode_description_Jsonclick ;
      private string edtSupplierGenPhoneNumber_Internalname ;
      private string edtSupplierGenPhoneNumber_Jsonclick ;
      private string divUnnamedtable6_Internalname ;
      private string lblTransactiondetail_phonelabellandline_Internalname ;
      private string lblTransactiondetail_phonelabellandline_Jsonclick ;
      private string divUnnamedtable8_Internalname ;
      private string divUnnamedtable9_Internalname ;
      private string edtavSuppliergenlandlinecode_description_Jsonclick ;
      private string edtSupplierGenLandlineSubNumber_Internalname ;
      private string edtSupplierGenLandlineSubNumber_Jsonclick ;
      private string divSuppliergencontactphone_cell_Internalname ;
      private string divSuppliergencontactphone_cell_Class ;
      private string edtSupplierGenContactPhone_Internalname ;
      private string gxphoneLink ;
      private string A48SupplierGenContactPhone ;
      private string edtSupplierGenContactPhone_Jsonclick ;
      private string divSuppliergenlandlinenumber_cell_Internalname ;
      private string divSuppliergenlandlinenumber_cell_Class ;
      private string edtSupplierGenLandlineNumber_Internalname ;
      private string edtSupplierGenLandlineNumber_Jsonclick ;
      private string edtSupplierGenEmail_Internalname ;
      private string edtSupplierGenEmail_Jsonclick ;
      private string edtSupplierGenWebsite_Internalname ;
      private string edtSupplierGenWebsite_Jsonclick ;
      private string divSuppliergendescription_cell_Internalname ;
      private string divSuppliergendescription_cell_Class ;
      private string Suppliergendescription_Internalname ;
      private string divTransactiondetail_descriptiontable_Internalname ;
      private string lblTransactiondetail_textblockdescriptionlabel_Internalname ;
      private string lblTransactiondetail_textblockdescriptionlabel_Jsonclick ;
      private string divUnnamedtable7_Internalname ;
      private string lblTransactiondetail_descriptiontext_Internalname ;
      private string lblTransactiondetail_descriptiontext_Caption ;
      private string lblTransactiondetail_descriptiontext_Jsonclick ;
      private string grpUnnamedgroup4_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string edtSupplierGenAddressLine1_Internalname ;
      private string edtSupplierGenAddressLine1_Jsonclick ;
      private string edtSupplierGenAddressLine2_Internalname ;
      private string edtSupplierGenAddressLine2_Jsonclick ;
      private string edtSupplierGenAddressZipCode_Internalname ;
      private string edtSupplierGenAddressZipCode_Jsonclick ;
      private string edtSupplierGenAddressCity_Internalname ;
      private string edtSupplierGenAddressCity_Jsonclick ;
      private string edtavSuppliergenaddresscountry_description_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtSupplierGenId_Internalname ;
      private string edtSupplierGenId_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string sCtrlA42SupplierGenId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Suppliergendescription_Enabled ;
      private bool Suppliergendescription_Toolbarcancollapse ;
      private bool Suppliergendescription_Visible ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string A604SupplierGenDescription ;
      private string SupplierGenDescription ;
      private string A43SupplierGenKvkNumber ;
      private string A44SupplierGenCompanyName ;
      private string A254SupplierGenTypeName ;
      private string A47SupplierGenContactName ;
      private string AV19SupplierGenPhoneCode_Description ;
      private string A354SupplierGenPhoneNumber ;
      private string AV20SupplierGenLandlineCode_Description ;
      private string A606SupplierGenLandlineSubNumber ;
      private string A607SupplierGenLandlineNumber ;
      private string A501SupplierGenEmail ;
      private string A428SupplierGenWebsite ;
      private string A310SupplierGenAddressLine1 ;
      private string A311SupplierGenAddressLine2 ;
      private string A259SupplierGenAddressZipCode ;
      private string A260SupplierGenAddressCity ;
      private string AV14SupplierGenAddressCountry_Description ;
      private string AV17ComboSelectedValue ;
      private Guid A42SupplierGenId ;
      private Guid wcpOA42SupplierGenId ;
      private Guid A253SupplierGenTypeId ;
      private GXUserControl ucSuppliergendescription ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] H004E2_A253SupplierGenTypeId ;
      private Guid[] H004E2_A42SupplierGenId ;
      private string[] H004E2_A260SupplierGenAddressCity ;
      private string[] H004E2_A259SupplierGenAddressZipCode ;
      private string[] H004E2_A311SupplierGenAddressLine2 ;
      private string[] H004E2_A310SupplierGenAddressLine1 ;
      private string[] H004E2_A604SupplierGenDescription ;
      private string[] H004E2_A428SupplierGenWebsite ;
      private string[] H004E2_A501SupplierGenEmail ;
      private string[] H004E2_A607SupplierGenLandlineNumber ;
      private string[] H004E2_A48SupplierGenContactPhone ;
      private string[] H004E2_A606SupplierGenLandlineSubNumber ;
      private string[] H004E2_A354SupplierGenPhoneNumber ;
      private string[] H004E2_A47SupplierGenContactName ;
      private string[] H004E2_A254SupplierGenTypeName ;
      private string[] H004E2_A44SupplierGenCompanyName ;
      private string[] H004E2_A43SupplierGenKvkNumber ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> GXt_objcol_SdtDVB_SDTComboData_Item1 ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class trn_suppliergengeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH004E2;
          prmH004E2 = new Object[] {
          new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004E2", "SELECT T1.SupplierGenTypeId, T1.SupplierGenId, T1.SupplierGenAddressCity, T1.SupplierGenAddressZipCode, T1.SupplierGenAddressLine2, T1.SupplierGenAddressLine1, T1.SupplierGenDescription, T1.SupplierGenWebsite, T1.SupplierGenEmail, T1.SupplierGenLandlineNumber, T1.SupplierGenContactPhone, T1.SupplierGenLandlineSubNumber, T1.SupplierGenPhoneNumber, T1.SupplierGenContactName, T2.SupplierGenTypeName, T1.SupplierGenCompanyName, T1.SupplierGenKvkNumber FROM (Trn_SupplierGen T1 INNER JOIN Trn_SupplierGenType T2 ON T2.SupplierGenTypeId = T1.SupplierGenTypeId) WHERE T1.SupplierGenId = :SupplierGenId ORDER BY T1.SupplierGenId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004E2,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 20);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((string[]) buf[12])[0] = rslt.getVarchar(13);
                ((string[]) buf[13])[0] = rslt.getVarchar(14);
                ((string[]) buf[14])[0] = rslt.getVarchar(15);
                ((string[]) buf[15])[0] = rslt.getVarchar(16);
                ((string[]) buf[16])[0] = rslt.getVarchar(17);
                return;
       }
    }

 }

}
