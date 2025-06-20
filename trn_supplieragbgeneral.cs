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
   public class trn_supplieragbgeneral : GXWebComponent
   {
      public trn_supplieragbgeneral( )
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

      public trn_supplieragbgeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_SupplierAgbId )
      {
         this.A49SupplierAgbId = aP0_SupplierAgbId;
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
               gxfirstwebparm = GetFirstPar( "SupplierAgbId");
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
                  A49SupplierAgbId = StringUtil.StrToGuid( GetPar( "SupplierAgbId"));
                  AssignAttri(sPrefix, false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(Guid)A49SupplierAgbId});
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
                  gxfirstwebparm = GetFirstPar( "SupplierAgbId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "SupplierAgbId");
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
            PA4H2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV21Pgmname = "Trn_SupplierAgbGeneral";
               edtavSupplieragbphonecode_description_Enabled = 0;
               AssignProp(sPrefix, false, edtavSupplieragbphonecode_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSupplieragbphonecode_description_Enabled), 5, 0), true);
               edtavSupplieragbaddresscountry_description_Enabled = 0;
               AssignProp(sPrefix, false, edtavSupplieragbaddresscountry_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSupplieragbaddresscountry_description_Enabled), 5, 0), true);
               WS4H2( ) ;
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
            context.SendWebValue( context.GetMessage( "Trn_Supplier Agb General", "")) ;
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
            GXEncryptionTmp = "trn_supplieragbgeneral.aspx"+UrlEncode(A49SupplierAgbId.ToString());
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_supplieragbgeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA49SupplierAgbId", wcpOA49SupplierAgbId.ToString());
      }

      protected void RenderHtmlCloseForm4H2( )
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
         return "Trn_SupplierAgbGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Supplier Agb General", "") ;
      }

      protected void WB4H0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "trn_supplieragbgeneral.aspx");
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
            GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, context.GetMessage( "Supplier Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_SupplierAgbGeneral.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierAgbTypeName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplierAgbTypeName_Internalname, context.GetMessage( "Category", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplierAgbTypeName_Internalname, A256SupplierAgbTypeName, StringUtil.RTrim( context.localUtil.Format( A256SupplierAgbTypeName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierAgbTypeName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierAgbTypeName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_SupplierAgbGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierAgbNumber_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplierAgbNumber_Internalname, context.GetMessage( "AGB Number", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplierAgbNumber_Internalname, A50SupplierAgbNumber, StringUtil.RTrim( context.localUtil.Format( A50SupplierAgbNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierAgbNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierAgbNumber_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, true, "AgbNumber", "start", true, "", "HLP_Trn_SupplierAgbGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierAgbName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplierAgbName_Internalname, context.GetMessage( "Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplierAgbName_Internalname, A51SupplierAgbName, StringUtil.RTrim( context.localUtil.Format( A51SupplierAgbName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierAgbName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierAgbName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_SupplierAgbGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierAgbKvkNumber_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplierAgbKvkNumber_Internalname, context.GetMessage( "KvK Number", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplierAgbKvkNumber_Internalname, A52SupplierAgbKvkNumber, StringUtil.RTrim( context.localUtil.Format( A52SupplierAgbKvkNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierAgbKvkNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierAgbKvkNumber_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, true, "KvkNumber", "start", true, "", "HLP_Trn_SupplierAgbGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierAgbContactName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplierAgbContactName_Internalname, context.GetMessage( "Contact Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplierAgbContactName_Internalname, A55SupplierAgbContactName, StringUtil.RTrim( context.localUtil.Format( A55SupplierAgbContactName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierAgbContactName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierAgbContactName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_SupplierAgbGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_phonenumbertable_Internalname, divTransactiondetail_phonenumbertable_Visible, 0, "px", 0, "px", "CellMarginBottom10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTransactiondetail_phonelabel_Internalname, context.GetMessage( "Phone", ""), "", "", lblTransactiondetail_phonelabel_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_Trn_SupplierAgbGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable5_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable6_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 PhoneLabel", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSupplieragbphonecode_description_Internalname, context.GetMessage( "Supplier Agb Phone Code_Description", ""), "col-sm-3 DropDownComponentLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSupplieragbphonecode_description_Internalname, AV19SupplierAgbPhoneCode_Description, StringUtil.RTrim( context.localUtil.Format( AV19SupplierAgbPhoneCode_Description, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSupplieragbphonecode_description_Jsonclick, 0, "DropDownComponent", "", "", "", "", 1, edtavSupplieragbphonecode_description_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierAgbGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtSupplierAgbPhoneNumber_Internalname, context.GetMessage( "Supplier Agb Phone Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplierAgbPhoneNumber_Internalname, A350SupplierAgbPhoneNumber, StringUtil.RTrim( context.localUtil.Format( A350SupplierAgbPhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierAgbPhoneNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierAgbPhoneNumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierAgbGeneral.htm");
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
            GxWebStd.gx_div_start( context, divSupplieragbphone_cell_Internalname, 1, 0, "px", 0, "px", divSupplieragbphone_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtSupplierAgbPhone_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierAgbPhone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplierAgbPhone_Internalname, context.GetMessage( "Phone", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A56SupplierAgbPhone);
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplierAgbPhone_Internalname, StringUtil.RTrim( A56SupplierAgbPhone), StringUtil.RTrim( context.localUtil.Format( A56SupplierAgbPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtSupplierAgbPhone_Jsonclick, 0, "Attribute", "", "", "", "", edtSupplierAgbPhone_Visible, edtSupplierAgbPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Trn_SupplierAgbGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierAgbEmail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplierAgbEmail_Internalname, context.GetMessage( "Email", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplierAgbEmail_Internalname, A57SupplierAgbEmail, StringUtil.RTrim( context.localUtil.Format( A57SupplierAgbEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "mailto:"+A57SupplierAgbEmail, "", "", "", edtSupplierAgbEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierAgbEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Trn_SupplierAgbGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierAgbWebsite_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplierAgbWebsite_Internalname, context.GetMessage( "Website", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplierAgbWebsite_Internalname, A427SupplierAgbWebsite, StringUtil.RTrim( context.localUtil.Format( A427SupplierAgbWebsite, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierAgbWebsite_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierAgbWebsite_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "Website", "start", true, "", "HLP_Trn_SupplierAgbGeneral.htm");
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
            GxWebStd.gx_group_start( context, grpUnnamedgroup4_Internalname, context.GetMessage( "Address Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_SupplierAgbGeneral.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierAgbAddressLine1_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplierAgbAddressLine1_Internalname, context.GetMessage( "Address Line 1", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplierAgbAddressLine1_Internalname, A307SupplierAgbAddressLine1, StringUtil.RTrim( context.localUtil.Format( A307SupplierAgbAddressLine1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierAgbAddressLine1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierAgbAddressLine1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierAgbGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierAgbAddressLine2_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplierAgbAddressLine2_Internalname, context.GetMessage( "Address Line 2", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplierAgbAddressLine2_Internalname, A308SupplierAgbAddressLine2, StringUtil.RTrim( context.localUtil.Format( A308SupplierAgbAddressLine2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierAgbAddressLine2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierAgbAddressLine2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierAgbGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierAgbAddressZipCode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplierAgbAddressZipCode_Internalname, context.GetMessage( "Zip Code", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplierAgbAddressZipCode_Internalname, A263SupplierAgbAddressZipCode, StringUtil.RTrim( context.localUtil.Format( A263SupplierAgbAddressZipCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierAgbAddressZipCode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierAgbAddressZipCode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierAgbGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierAgbAddressCity_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplierAgbAddressCity_Internalname, context.GetMessage( "City", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplierAgbAddressCity_Internalname, A264SupplierAgbAddressCity, StringUtil.RTrim( context.localUtil.Format( A264SupplierAgbAddressCity, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierAgbAddressCity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierAgbAddressCity_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierAgbGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSupplieragbaddresscountry_description_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSupplieragbaddresscountry_description_Internalname, context.GetMessage( "Country", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSupplieragbaddresscountry_description_Internalname, AV14SupplierAGBAddressCountry_Description, StringUtil.RTrim( context.localUtil.Format( AV14SupplierAGBAddressCountry_Description, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSupplieragbaddresscountry_description_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSupplieragbaddresscountry_description_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierAgbGeneral.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtncancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_SupplierAgbGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtSupplierAgbId_Internalname, A49SupplierAgbId.ToString(), A49SupplierAgbId.ToString(), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierAgbId_Jsonclick, 0, "Attribute", "", "", "", "", edtSupplierAgbId_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_SupplierAgbGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START4H2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Trn_Supplier Agb General", ""), 0) ;
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
               STRUP4H0( ) ;
            }
         }
      }

      protected void WS4H2( )
      {
         START4H2( ) ;
         EVT4H2( ) ;
      }

      protected void EVT4H2( )
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
                                 STRUP4H0( ) ;
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
                                 STRUP4H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E114H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E124H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4H0( ) ;
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
                                 STRUP4H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavSupplieragbphonecode_description_Internalname;
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

      protected void WE4H2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm4H2( ) ;
            }
         }
      }

      protected void PA4H2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_supplieragbgeneral.aspx")), "trn_supplieragbgeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_supplieragbgeneral.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "SupplierAgbId");
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
               GX_FocusControl = edtavSupplieragbphonecode_description_Internalname;
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
         RF4H2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV21Pgmname = "Trn_SupplierAgbGeneral";
         edtavSupplieragbphonecode_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavSupplieragbphonecode_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSupplieragbphonecode_description_Enabled), 5, 0), true);
         edtavSupplieragbaddresscountry_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavSupplieragbaddresscountry_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSupplieragbaddresscountry_description_Enabled), 5, 0), true);
      }

      protected void RF4H2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H004H2 */
            pr_default.execute(0, new Object[] {A49SupplierAgbId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A255SupplierAgbTypeId = H004H2_A255SupplierAgbTypeId[0];
               A264SupplierAgbAddressCity = H004H2_A264SupplierAgbAddressCity[0];
               AssignAttri(sPrefix, false, "A264SupplierAgbAddressCity", A264SupplierAgbAddressCity);
               A263SupplierAgbAddressZipCode = H004H2_A263SupplierAgbAddressZipCode[0];
               AssignAttri(sPrefix, false, "A263SupplierAgbAddressZipCode", A263SupplierAgbAddressZipCode);
               A308SupplierAgbAddressLine2 = H004H2_A308SupplierAgbAddressLine2[0];
               AssignAttri(sPrefix, false, "A308SupplierAgbAddressLine2", A308SupplierAgbAddressLine2);
               A307SupplierAgbAddressLine1 = H004H2_A307SupplierAgbAddressLine1[0];
               AssignAttri(sPrefix, false, "A307SupplierAgbAddressLine1", A307SupplierAgbAddressLine1);
               A427SupplierAgbWebsite = H004H2_A427SupplierAgbWebsite[0];
               AssignAttri(sPrefix, false, "A427SupplierAgbWebsite", A427SupplierAgbWebsite);
               A57SupplierAgbEmail = H004H2_A57SupplierAgbEmail[0];
               AssignAttri(sPrefix, false, "A57SupplierAgbEmail", A57SupplierAgbEmail);
               A56SupplierAgbPhone = H004H2_A56SupplierAgbPhone[0];
               AssignAttri(sPrefix, false, "A56SupplierAgbPhone", A56SupplierAgbPhone);
               A350SupplierAgbPhoneNumber = H004H2_A350SupplierAgbPhoneNumber[0];
               AssignAttri(sPrefix, false, "A350SupplierAgbPhoneNumber", A350SupplierAgbPhoneNumber);
               A55SupplierAgbContactName = H004H2_A55SupplierAgbContactName[0];
               AssignAttri(sPrefix, false, "A55SupplierAgbContactName", A55SupplierAgbContactName);
               A52SupplierAgbKvkNumber = H004H2_A52SupplierAgbKvkNumber[0];
               AssignAttri(sPrefix, false, "A52SupplierAgbKvkNumber", A52SupplierAgbKvkNumber);
               A51SupplierAgbName = H004H2_A51SupplierAgbName[0];
               AssignAttri(sPrefix, false, "A51SupplierAgbName", A51SupplierAgbName);
               A50SupplierAgbNumber = H004H2_A50SupplierAgbNumber[0];
               AssignAttri(sPrefix, false, "A50SupplierAgbNumber", A50SupplierAgbNumber);
               A256SupplierAgbTypeName = H004H2_A256SupplierAgbTypeName[0];
               AssignAttri(sPrefix, false, "A256SupplierAgbTypeName", A256SupplierAgbTypeName);
               A256SupplierAgbTypeName = H004H2_A256SupplierAgbTypeName[0];
               AssignAttri(sPrefix, false, "A256SupplierAgbTypeName", A256SupplierAgbTypeName);
               /* Execute user event: Load */
               E124H2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB4H0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4H2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV21Pgmname = "Trn_SupplierAgbGeneral";
         edtavSupplieragbphonecode_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavSupplieragbphonecode_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSupplieragbphonecode_description_Enabled), 5, 0), true);
         edtavSupplieragbaddresscountry_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavSupplieragbaddresscountry_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSupplieragbaddresscountry_description_Enabled), 5, 0), true);
         edtSupplierAgbTypeName_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplierAgbTypeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbTypeName_Enabled), 5, 0), true);
         edtSupplierAgbNumber_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplierAgbNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbNumber_Enabled), 5, 0), true);
         edtSupplierAgbName_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplierAgbName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbName_Enabled), 5, 0), true);
         edtSupplierAgbKvkNumber_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplierAgbKvkNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbKvkNumber_Enabled), 5, 0), true);
         edtSupplierAgbContactName_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplierAgbContactName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbContactName_Enabled), 5, 0), true);
         edtSupplierAgbPhoneNumber_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplierAgbPhoneNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbPhoneNumber_Enabled), 5, 0), true);
         edtSupplierAgbPhone_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplierAgbPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbPhone_Enabled), 5, 0), true);
         edtSupplierAgbEmail_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplierAgbEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbEmail_Enabled), 5, 0), true);
         edtSupplierAgbWebsite_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplierAgbWebsite_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbWebsite_Enabled), 5, 0), true);
         edtSupplierAgbAddressLine1_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplierAgbAddressLine1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbAddressLine1_Enabled), 5, 0), true);
         edtSupplierAgbAddressLine2_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplierAgbAddressLine2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbAddressLine2_Enabled), 5, 0), true);
         edtSupplierAgbAddressZipCode_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplierAgbAddressZipCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbAddressZipCode_Enabled), 5, 0), true);
         edtSupplierAgbAddressCity_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplierAgbAddressCity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbAddressCity_Enabled), 5, 0), true);
         edtSupplierAgbId_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplierAgbId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbId_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4H0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E114H2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA49SupplierAgbId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA49SupplierAgbId"));
            /* Read variables values. */
            A256SupplierAgbTypeName = cgiGet( edtSupplierAgbTypeName_Internalname);
            AssignAttri(sPrefix, false, "A256SupplierAgbTypeName", A256SupplierAgbTypeName);
            A50SupplierAgbNumber = cgiGet( edtSupplierAgbNumber_Internalname);
            AssignAttri(sPrefix, false, "A50SupplierAgbNumber", A50SupplierAgbNumber);
            A51SupplierAgbName = cgiGet( edtSupplierAgbName_Internalname);
            AssignAttri(sPrefix, false, "A51SupplierAgbName", A51SupplierAgbName);
            A52SupplierAgbKvkNumber = cgiGet( edtSupplierAgbKvkNumber_Internalname);
            AssignAttri(sPrefix, false, "A52SupplierAgbKvkNumber", A52SupplierAgbKvkNumber);
            A55SupplierAgbContactName = cgiGet( edtSupplierAgbContactName_Internalname);
            AssignAttri(sPrefix, false, "A55SupplierAgbContactName", A55SupplierAgbContactName);
            AV19SupplierAgbPhoneCode_Description = cgiGet( edtavSupplieragbphonecode_description_Internalname);
            AssignAttri(sPrefix, false, "AV19SupplierAgbPhoneCode_Description", AV19SupplierAgbPhoneCode_Description);
            A350SupplierAgbPhoneNumber = cgiGet( edtSupplierAgbPhoneNumber_Internalname);
            AssignAttri(sPrefix, false, "A350SupplierAgbPhoneNumber", A350SupplierAgbPhoneNumber);
            A56SupplierAgbPhone = cgiGet( edtSupplierAgbPhone_Internalname);
            AssignAttri(sPrefix, false, "A56SupplierAgbPhone", A56SupplierAgbPhone);
            A57SupplierAgbEmail = cgiGet( edtSupplierAgbEmail_Internalname);
            AssignAttri(sPrefix, false, "A57SupplierAgbEmail", A57SupplierAgbEmail);
            A427SupplierAgbWebsite = cgiGet( edtSupplierAgbWebsite_Internalname);
            AssignAttri(sPrefix, false, "A427SupplierAgbWebsite", A427SupplierAgbWebsite);
            A307SupplierAgbAddressLine1 = cgiGet( edtSupplierAgbAddressLine1_Internalname);
            AssignAttri(sPrefix, false, "A307SupplierAgbAddressLine1", A307SupplierAgbAddressLine1);
            A308SupplierAgbAddressLine2 = cgiGet( edtSupplierAgbAddressLine2_Internalname);
            AssignAttri(sPrefix, false, "A308SupplierAgbAddressLine2", A308SupplierAgbAddressLine2);
            A263SupplierAgbAddressZipCode = cgiGet( edtSupplierAgbAddressZipCode_Internalname);
            AssignAttri(sPrefix, false, "A263SupplierAgbAddressZipCode", A263SupplierAgbAddressZipCode);
            A264SupplierAgbAddressCity = cgiGet( edtSupplierAgbAddressCity_Internalname);
            AssignAttri(sPrefix, false, "A264SupplierAgbAddressCity", A264SupplierAgbAddressCity);
            AV14SupplierAGBAddressCountry_Description = cgiGet( edtavSupplieragbaddresscountry_description_Internalname);
            AssignAttri(sPrefix, false, "AV14SupplierAGBAddressCountry_Description", AV14SupplierAGBAddressCountry_Description);
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
         E114H2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E114H2( )
      {
         /* Start Routine */
         returnInSub = false;
         Gx_mode = "DSP";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         GXt_objcol_SdtDVB_SDTComboData_Item1 = AV15Combo_Data;
         new trn_supplieragbloaddvcombo(context ).execute(  "SupplierAGBAddressCountry",  "GET_DSC",  A49SupplierAgbId, out  AV17ComboSelectedValue, out  AV14SupplierAGBAddressCountry_Description, out  GXt_objcol_SdtDVB_SDTComboData_Item1) ;
         AssignAttri(sPrefix, false, "AV14SupplierAGBAddressCountry_Description", AV14SupplierAGBAddressCountry_Description);
         AV15Combo_Data = GXt_objcol_SdtDVB_SDTComboData_Item1;
         GXt_objcol_SdtDVB_SDTComboData_Item1 = AV15Combo_Data;
         new trn_supplieragbloaddvcombo(context ).execute(  "SupplierAgbPhoneCode",  "GET_DSC",  A49SupplierAgbId, out  AV17ComboSelectedValue, out  AV19SupplierAgbPhoneCode_Description, out  GXt_objcol_SdtDVB_SDTComboData_Item1) ;
         AssignAttri(sPrefix, false, "AV19SupplierAgbPhoneCode_Description", AV19SupplierAgbPhoneCode_Description);
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

      protected void E124H2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtSupplierAgbId_Visible = 0;
         AssignProp(sPrefix, false, edtSupplierAgbId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierAgbId_Visible), 5, 0), true);
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) ) )
         {
            edtSupplierAgbPhone_Visible = 0;
            AssignProp(sPrefix, false, edtSupplierAgbPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierAgbPhone_Visible), 5, 0), true);
            divSupplieragbphone_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divSupplieragbphone_cell_Internalname, "Class", divSupplieragbphone_cell_Class, true);
         }
         else
         {
            edtSupplierAgbPhone_Visible = 1;
            AssignProp(sPrefix, false, edtSupplierAgbPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierAgbPhone_Visible), 5, 0), true);
            divSupplieragbphone_cell_Class = "col-xs-12 DataContentCell";
            AssignProp(sPrefix, false, divSupplieragbphone_cell_Internalname, "Class", divSupplieragbphone_cell_Class, true);
         }
         divTransactiondetail_phonenumbertable_Visible = (((StringUtil.StrCmp(Gx_mode, "INS")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0)) ? 1 : 0);
         AssignProp(sPrefix, false, divTransactiondetail_phonenumbertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTransactiondetail_phonenumbertable_Visible), 5, 0), true);
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV21Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Trn_SupplierAgb";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A49SupplierAgbId = (Guid)getParm(obj,0);
         AssignAttri(sPrefix, false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
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
         PA4H2( ) ;
         WS4H2( ) ;
         WE4H2( ) ;
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
         sCtrlA49SupplierAgbId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA4H2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "trn_supplieragbgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA4H2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A49SupplierAgbId = (Guid)getParm(obj,2);
            AssignAttri(sPrefix, false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
         }
         wcpOA49SupplierAgbId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA49SupplierAgbId"));
         if ( ! GetJustCreated( ) && ( ( A49SupplierAgbId != wcpOA49SupplierAgbId ) ) )
         {
            setjustcreated();
         }
         wcpOA49SupplierAgbId = A49SupplierAgbId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA49SupplierAgbId = cgiGet( sPrefix+"A49SupplierAgbId_CTRL");
         if ( StringUtil.Len( sCtrlA49SupplierAgbId) > 0 )
         {
            A49SupplierAgbId = StringUtil.StrToGuid( cgiGet( sCtrlA49SupplierAgbId));
            AssignAttri(sPrefix, false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
         }
         else
         {
            A49SupplierAgbId = StringUtil.StrToGuid( cgiGet( sPrefix+"A49SupplierAgbId_PARM"));
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
         PA4H2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS4H2( ) ;
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
         WS4H2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A49SupplierAgbId_PARM", A49SupplierAgbId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA49SupplierAgbId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A49SupplierAgbId_CTRL", StringUtil.RTrim( sCtrlA49SupplierAgbId));
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
         WE4H2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202562016571657", true, true);
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
         context.AddJavascriptSource("trn_supplieragbgeneral.js", "?202562016571658", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtSupplierAgbTypeName_Internalname = sPrefix+"SUPPLIERAGBTYPENAME";
         edtSupplierAgbNumber_Internalname = sPrefix+"SUPPLIERAGBNUMBER";
         edtSupplierAgbName_Internalname = sPrefix+"SUPPLIERAGBNAME";
         edtSupplierAgbKvkNumber_Internalname = sPrefix+"SUPPLIERAGBKVKNUMBER";
         edtSupplierAgbContactName_Internalname = sPrefix+"SUPPLIERAGBCONTACTNAME";
         lblTransactiondetail_phonelabel_Internalname = sPrefix+"TRANSACTIONDETAIL_PHONELABEL";
         edtavSupplieragbphonecode_description_Internalname = sPrefix+"vSUPPLIERAGBPHONECODE_DESCRIPTION";
         divUnnamedtable6_Internalname = sPrefix+"UNNAMEDTABLE6";
         edtSupplierAgbPhoneNumber_Internalname = sPrefix+"SUPPLIERAGBPHONENUMBER";
         divUnnamedtable5_Internalname = sPrefix+"UNNAMEDTABLE5";
         divTransactiondetail_phonenumbertable_Internalname = sPrefix+"TRANSACTIONDETAIL_PHONENUMBERTABLE";
         edtSupplierAgbPhone_Internalname = sPrefix+"SUPPLIERAGBPHONE";
         divSupplieragbphone_cell_Internalname = sPrefix+"SUPPLIERAGBPHONE_CELL";
         edtSupplierAgbEmail_Internalname = sPrefix+"SUPPLIERAGBEMAIL";
         edtSupplierAgbWebsite_Internalname = sPrefix+"SUPPLIERAGBWEBSITE";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         grpUnnamedgroup2_Internalname = sPrefix+"UNNAMEDGROUP2";
         edtSupplierAgbAddressLine1_Internalname = sPrefix+"SUPPLIERAGBADDRESSLINE1";
         edtSupplierAgbAddressLine2_Internalname = sPrefix+"SUPPLIERAGBADDRESSLINE2";
         edtSupplierAgbAddressZipCode_Internalname = sPrefix+"SUPPLIERAGBADDRESSZIPCODE";
         edtSupplierAgbAddressCity_Internalname = sPrefix+"SUPPLIERAGBADDRESSCITY";
         edtavSupplieragbaddresscountry_description_Internalname = sPrefix+"vSUPPLIERAGBADDRESSCOUNTRY_DESCRIPTION";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         grpUnnamedgroup4_Internalname = sPrefix+"UNNAMEDGROUP4";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtncancel_Internalname = sPrefix+"BTNCANCEL";
         divTable_Internalname = sPrefix+"TABLE";
         edtSupplierAgbId_Internalname = sPrefix+"SUPPLIERAGBID";
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
         edtSupplierAgbId_Enabled = 0;
         edtSupplierAgbId_Jsonclick = "";
         edtSupplierAgbId_Visible = 1;
         edtavSupplieragbaddresscountry_description_Jsonclick = "";
         edtavSupplieragbaddresscountry_description_Enabled = 1;
         edtSupplierAgbAddressCity_Jsonclick = "";
         edtSupplierAgbAddressCity_Enabled = 0;
         edtSupplierAgbAddressZipCode_Jsonclick = "";
         edtSupplierAgbAddressZipCode_Enabled = 0;
         edtSupplierAgbAddressLine2_Jsonclick = "";
         edtSupplierAgbAddressLine2_Enabled = 0;
         edtSupplierAgbAddressLine1_Jsonclick = "";
         edtSupplierAgbAddressLine1_Enabled = 0;
         edtSupplierAgbWebsite_Jsonclick = "";
         edtSupplierAgbWebsite_Enabled = 0;
         edtSupplierAgbEmail_Jsonclick = "";
         edtSupplierAgbEmail_Enabled = 0;
         edtSupplierAgbPhone_Jsonclick = "";
         edtSupplierAgbPhone_Enabled = 0;
         edtSupplierAgbPhone_Visible = 1;
         divSupplieragbphone_cell_Class = "col-xs-12";
         edtSupplierAgbPhoneNumber_Jsonclick = "";
         edtSupplierAgbPhoneNumber_Enabled = 0;
         edtavSupplieragbphonecode_description_Jsonclick = "";
         edtavSupplieragbphonecode_description_Enabled = 1;
         divTransactiondetail_phonenumbertable_Visible = 1;
         edtSupplierAgbContactName_Jsonclick = "";
         edtSupplierAgbContactName_Enabled = 0;
         edtSupplierAgbKvkNumber_Jsonclick = "";
         edtSupplierAgbKvkNumber_Enabled = 0;
         edtSupplierAgbName_Jsonclick = "";
         edtSupplierAgbName_Enabled = 0;
         edtSupplierAgbNumber_Jsonclick = "";
         edtSupplierAgbNumber_Enabled = 0;
         edtSupplierAgbTypeName_Jsonclick = "";
         edtSupplierAgbTypeName_Enabled = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A49SupplierAgbId","fld":"SUPPLIERAGBID"}]}""");
         setEventMetadata("VALID_SUPPLIERAGBID","""{"handler":"Valid_Supplieragbid","iparms":[]}""");
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
         wcpOA49SupplierAgbId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV21Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         TempTags = "";
         A256SupplierAgbTypeName = "";
         A50SupplierAgbNumber = "";
         A51SupplierAgbName = "";
         A52SupplierAgbKvkNumber = "";
         A55SupplierAgbContactName = "";
         lblTransactiondetail_phonelabel_Jsonclick = "";
         AV19SupplierAgbPhoneCode_Description = "";
         A350SupplierAgbPhoneNumber = "";
         gxphoneLink = "";
         A56SupplierAgbPhone = "";
         A57SupplierAgbEmail = "";
         A427SupplierAgbWebsite = "";
         A307SupplierAgbAddressLine1 = "";
         A308SupplierAgbAddressLine2 = "";
         A263SupplierAgbAddressZipCode = "";
         A264SupplierAgbAddressCity = "";
         AV14SupplierAGBAddressCountry_Description = "";
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
         H004H2_A255SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         H004H2_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         H004H2_A264SupplierAgbAddressCity = new string[] {""} ;
         H004H2_A263SupplierAgbAddressZipCode = new string[] {""} ;
         H004H2_A308SupplierAgbAddressLine2 = new string[] {""} ;
         H004H2_A307SupplierAgbAddressLine1 = new string[] {""} ;
         H004H2_A427SupplierAgbWebsite = new string[] {""} ;
         H004H2_A57SupplierAgbEmail = new string[] {""} ;
         H004H2_A56SupplierAgbPhone = new string[] {""} ;
         H004H2_A350SupplierAgbPhoneNumber = new string[] {""} ;
         H004H2_A55SupplierAgbContactName = new string[] {""} ;
         H004H2_A52SupplierAgbKvkNumber = new string[] {""} ;
         H004H2_A51SupplierAgbName = new string[] {""} ;
         H004H2_A50SupplierAgbNumber = new string[] {""} ;
         H004H2_A256SupplierAgbTypeName = new string[] {""} ;
         A255SupplierAgbTypeId = Guid.Empty;
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
         sCtrlA49SupplierAgbId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_supplieragbgeneral__default(),
            new Object[][] {
                new Object[] {
               H004H2_A255SupplierAgbTypeId, H004H2_A49SupplierAgbId, H004H2_A264SupplierAgbAddressCity, H004H2_A263SupplierAgbAddressZipCode, H004H2_A308SupplierAgbAddressLine2, H004H2_A307SupplierAgbAddressLine1, H004H2_A427SupplierAgbWebsite, H004H2_A57SupplierAgbEmail, H004H2_A56SupplierAgbPhone, H004H2_A350SupplierAgbPhoneNumber,
               H004H2_A55SupplierAgbContactName, H004H2_A52SupplierAgbKvkNumber, H004H2_A51SupplierAgbName, H004H2_A50SupplierAgbNumber, H004H2_A256SupplierAgbTypeName
               }
            }
         );
         AV21Pgmname = "Trn_SupplierAgbGeneral";
         /* GeneXus formulas. */
         AV21Pgmname = "Trn_SupplierAgbGeneral";
         edtavSupplieragbphonecode_description_Enabled = 0;
         edtavSupplieragbaddresscountry_description_Enabled = 0;
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
      private int edtavSupplieragbphonecode_description_Enabled ;
      private int edtavSupplieragbaddresscountry_description_Enabled ;
      private int edtSupplierAgbTypeName_Enabled ;
      private int edtSupplierAgbNumber_Enabled ;
      private int edtSupplierAgbName_Enabled ;
      private int edtSupplierAgbKvkNumber_Enabled ;
      private int edtSupplierAgbContactName_Enabled ;
      private int divTransactiondetail_phonenumbertable_Visible ;
      private int edtSupplierAgbPhoneNumber_Enabled ;
      private int edtSupplierAgbPhone_Visible ;
      private int edtSupplierAgbPhone_Enabled ;
      private int edtSupplierAgbEmail_Enabled ;
      private int edtSupplierAgbWebsite_Enabled ;
      private int edtSupplierAgbAddressLine1_Enabled ;
      private int edtSupplierAgbAddressLine2_Enabled ;
      private int edtSupplierAgbAddressZipCode_Enabled ;
      private int edtSupplierAgbAddressCity_Enabled ;
      private int edtSupplierAgbId_Visible ;
      private int edtSupplierAgbId_Enabled ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV21Pgmname ;
      private string edtavSupplieragbphonecode_description_Internalname ;
      private string edtavSupplieragbaddresscountry_description_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string grpUnnamedgroup2_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string edtSupplierAgbTypeName_Internalname ;
      private string TempTags ;
      private string edtSupplierAgbTypeName_Jsonclick ;
      private string edtSupplierAgbNumber_Internalname ;
      private string edtSupplierAgbNumber_Jsonclick ;
      private string edtSupplierAgbName_Internalname ;
      private string edtSupplierAgbName_Jsonclick ;
      private string edtSupplierAgbKvkNumber_Internalname ;
      private string edtSupplierAgbKvkNumber_Jsonclick ;
      private string edtSupplierAgbContactName_Internalname ;
      private string edtSupplierAgbContactName_Jsonclick ;
      private string divTransactiondetail_phonenumbertable_Internalname ;
      private string lblTransactiondetail_phonelabel_Internalname ;
      private string lblTransactiondetail_phonelabel_Jsonclick ;
      private string divUnnamedtable5_Internalname ;
      private string divUnnamedtable6_Internalname ;
      private string edtavSupplieragbphonecode_description_Jsonclick ;
      private string edtSupplierAgbPhoneNumber_Internalname ;
      private string edtSupplierAgbPhoneNumber_Jsonclick ;
      private string divSupplieragbphone_cell_Internalname ;
      private string divSupplieragbphone_cell_Class ;
      private string edtSupplierAgbPhone_Internalname ;
      private string gxphoneLink ;
      private string A56SupplierAgbPhone ;
      private string edtSupplierAgbPhone_Jsonclick ;
      private string edtSupplierAgbEmail_Internalname ;
      private string edtSupplierAgbEmail_Jsonclick ;
      private string edtSupplierAgbWebsite_Internalname ;
      private string edtSupplierAgbWebsite_Jsonclick ;
      private string grpUnnamedgroup4_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string edtSupplierAgbAddressLine1_Internalname ;
      private string edtSupplierAgbAddressLine1_Jsonclick ;
      private string edtSupplierAgbAddressLine2_Internalname ;
      private string edtSupplierAgbAddressLine2_Jsonclick ;
      private string edtSupplierAgbAddressZipCode_Internalname ;
      private string edtSupplierAgbAddressZipCode_Jsonclick ;
      private string edtSupplierAgbAddressCity_Internalname ;
      private string edtSupplierAgbAddressCity_Jsonclick ;
      private string edtavSupplieragbaddresscountry_description_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtSupplierAgbId_Internalname ;
      private string edtSupplierAgbId_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string sCtrlA49SupplierAgbId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string A256SupplierAgbTypeName ;
      private string A50SupplierAgbNumber ;
      private string A51SupplierAgbName ;
      private string A52SupplierAgbKvkNumber ;
      private string A55SupplierAgbContactName ;
      private string AV19SupplierAgbPhoneCode_Description ;
      private string A350SupplierAgbPhoneNumber ;
      private string A57SupplierAgbEmail ;
      private string A427SupplierAgbWebsite ;
      private string A307SupplierAgbAddressLine1 ;
      private string A308SupplierAgbAddressLine2 ;
      private string A263SupplierAgbAddressZipCode ;
      private string A264SupplierAgbAddressCity ;
      private string AV14SupplierAGBAddressCountry_Description ;
      private string AV17ComboSelectedValue ;
      private Guid A49SupplierAgbId ;
      private Guid wcpOA49SupplierAgbId ;
      private Guid A255SupplierAgbTypeId ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] H004H2_A255SupplierAgbTypeId ;
      private Guid[] H004H2_A49SupplierAgbId ;
      private string[] H004H2_A264SupplierAgbAddressCity ;
      private string[] H004H2_A263SupplierAgbAddressZipCode ;
      private string[] H004H2_A308SupplierAgbAddressLine2 ;
      private string[] H004H2_A307SupplierAgbAddressLine1 ;
      private string[] H004H2_A427SupplierAgbWebsite ;
      private string[] H004H2_A57SupplierAgbEmail ;
      private string[] H004H2_A56SupplierAgbPhone ;
      private string[] H004H2_A350SupplierAgbPhoneNumber ;
      private string[] H004H2_A55SupplierAgbContactName ;
      private string[] H004H2_A52SupplierAgbKvkNumber ;
      private string[] H004H2_A51SupplierAgbName ;
      private string[] H004H2_A50SupplierAgbNumber ;
      private string[] H004H2_A256SupplierAgbTypeName ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> GXt_objcol_SdtDVB_SDTComboData_Item1 ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class trn_supplieragbgeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH004H2;
          prmH004H2 = new Object[] {
          new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004H2", "SELECT T1.SupplierAgbTypeId, T1.SupplierAgbId, T1.SupplierAgbAddressCity, T1.SupplierAgbAddressZipCode, T1.SupplierAgbAddressLine2, T1.SupplierAgbAddressLine1, T1.SupplierAgbWebsite, T1.SupplierAgbEmail, T1.SupplierAgbPhone, T1.SupplierAgbPhoneNumber, T1.SupplierAgbContactName, T1.SupplierAgbKvkNumber, T1.SupplierAgbName, T1.SupplierAgbNumber, T2.SupplierAgbTypeName FROM (Trn_SupplierAGB T1 INNER JOIN Trn_SupplierAgbType T2 ON T2.SupplierAgbTypeId = T1.SupplierAgbTypeId) WHERE T1.SupplierAgbId = :SupplierAgbId ORDER BY T1.SupplierAgbId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004H2,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((string[]) buf[12])[0] = rslt.getVarchar(13);
                ((string[]) buf[13])[0] = rslt.getVarchar(14);
                ((string[]) buf[14])[0] = rslt.getVarchar(15);
                return;
       }
    }

 }

}
