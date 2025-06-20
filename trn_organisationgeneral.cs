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
   public class trn_organisationgeneral : GXWebComponent
   {
      public trn_organisationgeneral( )
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

      public trn_organisationgeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_OrganisationId )
      {
         this.A11OrganisationId = aP0_OrganisationId;
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
               gxfirstwebparm = GetFirstPar( "OrganisationId");
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
                  A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  AssignAttri(sPrefix, false, "A11OrganisationId", A11OrganisationId.ToString());
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(Guid)A11OrganisationId});
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
                  gxfirstwebparm = GetFirstPar( "OrganisationId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "OrganisationId");
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
            PA3S2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV21Pgmname = "Trn_OrganisationGeneral";
               edtavOrganisationphonecode_description_Enabled = 0;
               AssignProp(sPrefix, false, edtavOrganisationphonecode_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOrganisationphonecode_description_Enabled), 5, 0), true);
               edtavOrganisationaddresscountry_description_Enabled = 0;
               AssignProp(sPrefix, false, edtavOrganisationaddresscountry_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOrganisationaddresscountry_description_Enabled), 5, 0), true);
               WS3S2( ) ;
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
            context.SendWebValue( context.GetMessage( "Trn_Organisation General", "")) ;
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
            GXEncryptionTmp = "trn_organisationgeneral.aspx"+UrlEncode(A11OrganisationId.ToString());
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_organisationgeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA11OrganisationId", wcpOA11OrganisationId.ToString());
      }

      protected void RenderHtmlCloseForm3S2( )
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
         return "Trn_OrganisationGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Organisation General", "") ;
      }

      protected void WB3S0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "trn_organisationgeneral.aspx");
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
            GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, context.GetMessage( "Organisation Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_OrganisationGeneral.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOrganisationName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtOrganisationName_Internalname, context.GetMessage( "Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtOrganisationName_Internalname, A13OrganisationName, StringUtil.RTrim( context.localUtil.Format( A13OrganisationName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrganisationName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_OrganisationGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOrganisationTypeName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtOrganisationTypeName_Internalname, context.GetMessage( "Type", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtOrganisationTypeName_Internalname, A20OrganisationTypeName, StringUtil.RTrim( context.localUtil.Format( A20OrganisationTypeName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtOrganisationTypeName_Link, "", "", "", edtOrganisationTypeName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrganisationTypeName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_OrganisationGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOrganisationKvkNumber_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtOrganisationKvkNumber_Internalname, context.GetMessage( "KVK Number", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtOrganisationKvkNumber_Internalname, A12OrganisationKvkNumber, StringUtil.RTrim( context.localUtil.Format( A12OrganisationKvkNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationKvkNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrganisationKvkNumber_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, true, "KvkNumber", "start", true, "", "HLP_Trn_OrganisationGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOrganisationVATNumber_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtOrganisationVATNumber_Internalname, context.GetMessage( "VAT Number", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtOrganisationVATNumber_Internalname, A18OrganisationVATNumber, StringUtil.RTrim( context.localUtil.Format( A18OrganisationVATNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationVATNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrganisationVATNumber_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, -1, true, "VATNumber", "start", true, "", "HLP_Trn_OrganisationGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOrganisationEmail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtOrganisationEmail_Internalname, context.GetMessage( "Email", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtOrganisationEmail_Internalname, A16OrganisationEmail, StringUtil.RTrim( context.localUtil.Format( A16OrganisationEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "mailto:"+A16OrganisationEmail, "", "", "", edtOrganisationEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrganisationEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Trn_OrganisationGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTransactiondetail_phone_Internalname, context.GetMessage( "Phone", ""), "", "", lblTransactiondetail_phone_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_Trn_OrganisationGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable6_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable7_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 PhoneLabel", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOrganisationphonecode_description_Internalname, context.GetMessage( "Organisation Phone Code_Description", ""), "col-sm-3 DropDownComponentLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOrganisationphonecode_description_Internalname, AV19OrganisationPhoneCode_Description, StringUtil.RTrim( context.localUtil.Format( AV19OrganisationPhoneCode_Description, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOrganisationphonecode_description_Jsonclick, 0, "DropDownComponent", "", "", "", "", 1, edtavOrganisationphonecode_description_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_OrganisationGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 col-sm-8 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtOrganisationPhoneNumber_Internalname, context.GetMessage( "Organisation Phone Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtOrganisationPhoneNumber_Internalname, A362OrganisationPhoneNumber, StringUtil.RTrim( context.localUtil.Format( A362OrganisationPhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationPhoneNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrganisationPhoneNumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_OrganisationGeneral.htm");
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
            GxWebStd.gx_div_start( context, divOrganisationphone_cell_Internalname, 1, 0, "px", 0, "px", divOrganisationphone_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtOrganisationPhone_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOrganisationPhone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtOrganisationPhone_Internalname, context.GetMessage( "Phone", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A17OrganisationPhone);
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtOrganisationPhone_Internalname, StringUtil.RTrim( A17OrganisationPhone), StringUtil.RTrim( context.localUtil.Format( A17OrganisationPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtOrganisationPhone_Jsonclick, 0, "Attribute", "", "", "", "", edtOrganisationPhone_Visible, edtOrganisationPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Trn_OrganisationGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgOrganisationLogo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", context.GetMessage( "Logo", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "Attribute";
            StyleString = "";
            A506OrganisationLogo_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A506OrganisationLogo))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000OrganisationLogo_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A506OrganisationLogo)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A506OrganisationLogo)) ? A40000OrganisationLogo_GXI : context.PathToRelativeUrl( A506OrganisationLogo));
            GxWebStd.gx_bitmap( context, imgOrganisationLogo_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, A506OrganisationLogo_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Trn_OrganisationGeneral.htm");
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
            GxWebStd.gx_group_start( context, grpUnnamedgroup4_Internalname, context.GetMessage( "Address Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_OrganisationGeneral.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOrganisationAddressLine1_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtOrganisationAddressLine1_Internalname, context.GetMessage( "Address Line1", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtOrganisationAddressLine1_Internalname, A304OrganisationAddressLine1, StringUtil.RTrim( context.localUtil.Format( A304OrganisationAddressLine1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationAddressLine1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrganisationAddressLine1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_OrganisationGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOrganisationAddressLine2_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtOrganisationAddressLine2_Internalname, context.GetMessage( "Address Line2", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtOrganisationAddressLine2_Internalname, A305OrganisationAddressLine2, StringUtil.RTrim( context.localUtil.Format( A305OrganisationAddressLine2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationAddressLine2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrganisationAddressLine2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_OrganisationGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOrganisationAddressZipCode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtOrganisationAddressZipCode_Internalname, context.GetMessage( "Zip Code", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtOrganisationAddressZipCode_Internalname, A251OrganisationAddressZipCode, StringUtil.RTrim( context.localUtil.Format( A251OrganisationAddressZipCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationAddressZipCode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrganisationAddressZipCode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_OrganisationGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOrganisationAddressCity_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtOrganisationAddressCity_Internalname, context.GetMessage( "City", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtOrganisationAddressCity_Internalname, A252OrganisationAddressCity, StringUtil.RTrim( context.localUtil.Format( A252OrganisationAddressCity, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationAddressCity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrganisationAddressCity_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_OrganisationGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOrganisationaddresscountry_description_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOrganisationaddresscountry_description_Internalname, context.GetMessage( "Country", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOrganisationaddresscountry_description_Internalname, AV16OrganisationAddressCountry_Description, StringUtil.RTrim( context.localUtil.Format( AV16OrganisationAddressCountry_Description, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOrganisationaddresscountry_description_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavOrganisationaddresscountry_description_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_OrganisationGeneral.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtncancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_OrganisationGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtOrganisationId_Internalname, A11OrganisationId.ToString(), A11OrganisationId.ToString(), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationId_Jsonclick, 0, "Attribute", "", "", "", "", edtOrganisationId_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_OrganisationGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START3S2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Trn_Organisation General", ""), 0) ;
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
               STRUP3S0( ) ;
            }
         }
      }

      protected void WS3S2( )
      {
         START3S2( ) ;
         EVT3S2( ) ;
      }

      protected void EVT3S2( )
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
                                 STRUP3S0( ) ;
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
                                 STRUP3S0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E113S2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3S0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E123S2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3S0( ) ;
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
                                 STRUP3S0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavOrganisationphonecode_description_Internalname;
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

      protected void WE3S2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm3S2( ) ;
            }
         }
      }

      protected void PA3S2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_organisationgeneral.aspx")), "trn_organisationgeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_organisationgeneral.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "OrganisationId");
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
               GX_FocusControl = edtavOrganisationphonecode_description_Internalname;
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
         RF3S2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV21Pgmname = "Trn_OrganisationGeneral";
         edtavOrganisationphonecode_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavOrganisationphonecode_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOrganisationphonecode_description_Enabled), 5, 0), true);
         edtavOrganisationaddresscountry_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavOrganisationaddresscountry_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOrganisationaddresscountry_description_Enabled), 5, 0), true);
      }

      protected void RF3S2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H003S2 */
            pr_default.execute(0, new Object[] {A11OrganisationId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A19OrganisationTypeId = H003S2_A19OrganisationTypeId[0];
               A252OrganisationAddressCity = H003S2_A252OrganisationAddressCity[0];
               AssignAttri(sPrefix, false, "A252OrganisationAddressCity", A252OrganisationAddressCity);
               A251OrganisationAddressZipCode = H003S2_A251OrganisationAddressZipCode[0];
               AssignAttri(sPrefix, false, "A251OrganisationAddressZipCode", A251OrganisationAddressZipCode);
               A305OrganisationAddressLine2 = H003S2_A305OrganisationAddressLine2[0];
               AssignAttri(sPrefix, false, "A305OrganisationAddressLine2", A305OrganisationAddressLine2);
               A304OrganisationAddressLine1 = H003S2_A304OrganisationAddressLine1[0];
               AssignAttri(sPrefix, false, "A304OrganisationAddressLine1", A304OrganisationAddressLine1);
               A40000OrganisationLogo_GXI = H003S2_A40000OrganisationLogo_GXI[0];
               AssignProp(sPrefix, false, imgOrganisationLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A506OrganisationLogo)) ? A40000OrganisationLogo_GXI : context.convertURL( context.PathToRelativeUrl( A506OrganisationLogo))), true);
               AssignProp(sPrefix, false, imgOrganisationLogo_Internalname, "SrcSet", context.GetImageSrcSet( A506OrganisationLogo), true);
               A17OrganisationPhone = H003S2_A17OrganisationPhone[0];
               AssignAttri(sPrefix, false, "A17OrganisationPhone", A17OrganisationPhone);
               A362OrganisationPhoneNumber = H003S2_A362OrganisationPhoneNumber[0];
               AssignAttri(sPrefix, false, "A362OrganisationPhoneNumber", A362OrganisationPhoneNumber);
               A16OrganisationEmail = H003S2_A16OrganisationEmail[0];
               AssignAttri(sPrefix, false, "A16OrganisationEmail", A16OrganisationEmail);
               A18OrganisationVATNumber = H003S2_A18OrganisationVATNumber[0];
               AssignAttri(sPrefix, false, "A18OrganisationVATNumber", A18OrganisationVATNumber);
               A12OrganisationKvkNumber = H003S2_A12OrganisationKvkNumber[0];
               AssignAttri(sPrefix, false, "A12OrganisationKvkNumber", A12OrganisationKvkNumber);
               A20OrganisationTypeName = H003S2_A20OrganisationTypeName[0];
               AssignAttri(sPrefix, false, "A20OrganisationTypeName", A20OrganisationTypeName);
               A13OrganisationName = H003S2_A13OrganisationName[0];
               AssignAttri(sPrefix, false, "A13OrganisationName", A13OrganisationName);
               A506OrganisationLogo = H003S2_A506OrganisationLogo[0];
               AssignAttri(sPrefix, false, "A506OrganisationLogo", A506OrganisationLogo);
               AssignProp(sPrefix, false, imgOrganisationLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A506OrganisationLogo)) ? A40000OrganisationLogo_GXI : context.convertURL( context.PathToRelativeUrl( A506OrganisationLogo))), true);
               AssignProp(sPrefix, false, imgOrganisationLogo_Internalname, "SrcSet", context.GetImageSrcSet( A506OrganisationLogo), true);
               A20OrganisationTypeName = H003S2_A20OrganisationTypeName[0];
               AssignAttri(sPrefix, false, "A20OrganisationTypeName", A20OrganisationTypeName);
               /* Execute user event: Load */
               E123S2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB3S0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3S2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV21Pgmname = "Trn_OrganisationGeneral";
         edtavOrganisationphonecode_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavOrganisationphonecode_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOrganisationphonecode_description_Enabled), 5, 0), true);
         edtavOrganisationaddresscountry_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavOrganisationaddresscountry_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOrganisationaddresscountry_description_Enabled), 5, 0), true);
         edtOrganisationName_Enabled = 0;
         AssignProp(sPrefix, false, edtOrganisationName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationName_Enabled), 5, 0), true);
         edtOrganisationTypeName_Enabled = 0;
         AssignProp(sPrefix, false, edtOrganisationTypeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationTypeName_Enabled), 5, 0), true);
         edtOrganisationKvkNumber_Enabled = 0;
         AssignProp(sPrefix, false, edtOrganisationKvkNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationKvkNumber_Enabled), 5, 0), true);
         edtOrganisationVATNumber_Enabled = 0;
         AssignProp(sPrefix, false, edtOrganisationVATNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationVATNumber_Enabled), 5, 0), true);
         edtOrganisationEmail_Enabled = 0;
         AssignProp(sPrefix, false, edtOrganisationEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationEmail_Enabled), 5, 0), true);
         edtOrganisationPhoneNumber_Enabled = 0;
         AssignProp(sPrefix, false, edtOrganisationPhoneNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationPhoneNumber_Enabled), 5, 0), true);
         edtOrganisationPhone_Enabled = 0;
         AssignProp(sPrefix, false, edtOrganisationPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationPhone_Enabled), 5, 0), true);
         imgOrganisationLogo_Enabled = 0;
         AssignProp(sPrefix, false, imgOrganisationLogo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgOrganisationLogo_Enabled), 5, 0), true);
         edtOrganisationAddressLine1_Enabled = 0;
         AssignProp(sPrefix, false, edtOrganisationAddressLine1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationAddressLine1_Enabled), 5, 0), true);
         edtOrganisationAddressLine2_Enabled = 0;
         AssignProp(sPrefix, false, edtOrganisationAddressLine2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationAddressLine2_Enabled), 5, 0), true);
         edtOrganisationAddressZipCode_Enabled = 0;
         AssignProp(sPrefix, false, edtOrganisationAddressZipCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationAddressZipCode_Enabled), 5, 0), true);
         edtOrganisationAddressCity_Enabled = 0;
         AssignProp(sPrefix, false, edtOrganisationAddressCity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationAddressCity_Enabled), 5, 0), true);
         edtOrganisationId_Enabled = 0;
         AssignProp(sPrefix, false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3S0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E113S2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA11OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA11OrganisationId"));
            /* Read variables values. */
            A13OrganisationName = cgiGet( edtOrganisationName_Internalname);
            AssignAttri(sPrefix, false, "A13OrganisationName", A13OrganisationName);
            A20OrganisationTypeName = cgiGet( edtOrganisationTypeName_Internalname);
            AssignAttri(sPrefix, false, "A20OrganisationTypeName", A20OrganisationTypeName);
            A12OrganisationKvkNumber = cgiGet( edtOrganisationKvkNumber_Internalname);
            AssignAttri(sPrefix, false, "A12OrganisationKvkNumber", A12OrganisationKvkNumber);
            A18OrganisationVATNumber = cgiGet( edtOrganisationVATNumber_Internalname);
            AssignAttri(sPrefix, false, "A18OrganisationVATNumber", A18OrganisationVATNumber);
            A16OrganisationEmail = cgiGet( edtOrganisationEmail_Internalname);
            AssignAttri(sPrefix, false, "A16OrganisationEmail", A16OrganisationEmail);
            AV19OrganisationPhoneCode_Description = cgiGet( edtavOrganisationphonecode_description_Internalname);
            AssignAttri(sPrefix, false, "AV19OrganisationPhoneCode_Description", AV19OrganisationPhoneCode_Description);
            A362OrganisationPhoneNumber = cgiGet( edtOrganisationPhoneNumber_Internalname);
            AssignAttri(sPrefix, false, "A362OrganisationPhoneNumber", A362OrganisationPhoneNumber);
            A17OrganisationPhone = cgiGet( edtOrganisationPhone_Internalname);
            AssignAttri(sPrefix, false, "A17OrganisationPhone", A17OrganisationPhone);
            A506OrganisationLogo = cgiGet( imgOrganisationLogo_Internalname);
            AssignAttri(sPrefix, false, "A506OrganisationLogo", A506OrganisationLogo);
            A304OrganisationAddressLine1 = cgiGet( edtOrganisationAddressLine1_Internalname);
            AssignAttri(sPrefix, false, "A304OrganisationAddressLine1", A304OrganisationAddressLine1);
            A305OrganisationAddressLine2 = cgiGet( edtOrganisationAddressLine2_Internalname);
            AssignAttri(sPrefix, false, "A305OrganisationAddressLine2", A305OrganisationAddressLine2);
            A251OrganisationAddressZipCode = cgiGet( edtOrganisationAddressZipCode_Internalname);
            AssignAttri(sPrefix, false, "A251OrganisationAddressZipCode", A251OrganisationAddressZipCode);
            A252OrganisationAddressCity = cgiGet( edtOrganisationAddressCity_Internalname);
            AssignAttri(sPrefix, false, "A252OrganisationAddressCity", A252OrganisationAddressCity);
            AV16OrganisationAddressCountry_Description = cgiGet( edtavOrganisationaddresscountry_description_Internalname);
            AssignAttri(sPrefix, false, "AV16OrganisationAddressCountry_Description", AV16OrganisationAddressCountry_Description);
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
         E113S2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E113S2( )
      {
         /* Start Routine */
         returnInSub = false;
         Gx_mode = "DSP";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         GXt_char1 = AV17Combo_DataJson;
         new trn_organisationloaddvcombo(context ).execute(  "OrganisationAddressCountry",  "GET_DSC",  false,  A11OrganisationId,  "", out  AV18ComboSelectedValue, out  AV16OrganisationAddressCountry_Description, out  GXt_char1) ;
         AssignAttri(sPrefix, false, "AV16OrganisationAddressCountry_Description", AV16OrganisationAddressCountry_Description);
         AV17Combo_DataJson = GXt_char1;
         GXt_char1 = AV17Combo_DataJson;
         new trn_organisationloaddvcombo(context ).execute(  "OrganisationPhoneCode",  "GET_DSC",  false,  A11OrganisationId,  "", out  AV18ComboSelectedValue, out  AV19OrganisationPhoneCode_Description, out  GXt_char1) ;
         AssignAttri(sPrefix, false, "AV19OrganisationPhoneCode_Description", AV19OrganisationPhoneCode_Description);
         AV17Combo_DataJson = GXt_char1;
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

      protected void E123S2( )
      {
         /* Load Routine */
         returnInSub = false;
         GXt_boolean2 = AV14TempBoolean;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_organisationtypeview_Execute", out  GXt_boolean2) ;
         AV14TempBoolean = GXt_boolean2;
         if ( AV14TempBoolean )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_organisationtypeview.aspx"+UrlEncode(A19OrganisationTypeId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            edtOrganisationTypeName_Link = formatLink("trn_organisationtypeview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AssignProp(sPrefix, false, edtOrganisationTypeName_Internalname, "Link", edtOrganisationTypeName_Link, true);
         }
         edtOrganisationId_Visible = 0;
         AssignProp(sPrefix, false, edtOrganisationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Visible), 5, 0), true);
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) ) )
         {
            edtOrganisationPhone_Visible = 0;
            AssignProp(sPrefix, false, edtOrganisationPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationPhone_Visible), 5, 0), true);
            divOrganisationphone_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divOrganisationphone_cell_Internalname, "Class", divOrganisationphone_cell_Class, true);
         }
         else
         {
            edtOrganisationPhone_Visible = 1;
            AssignProp(sPrefix, false, edtOrganisationPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationPhone_Visible), 5, 0), true);
            divOrganisationphone_cell_Class = "col-xs-12 DataContentCell";
            AssignProp(sPrefix, false, divOrganisationphone_cell_Internalname, "Class", divOrganisationphone_cell_Class, true);
         }
         divUnnamedtable5_Visible = (((StringUtil.StrCmp(Gx_mode, "INS")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0)) ? 1 : 0);
         AssignProp(sPrefix, false, divUnnamedtable5_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUnnamedtable5_Visible), 5, 0), true);
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV21Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Trn_Organisation";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A11OrganisationId = (Guid)getParm(obj,0);
         AssignAttri(sPrefix, false, "A11OrganisationId", A11OrganisationId.ToString());
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
         PA3S2( ) ;
         WS3S2( ) ;
         WE3S2( ) ;
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
         sCtrlA11OrganisationId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA3S2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "trn_organisationgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA3S2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A11OrganisationId = (Guid)getParm(obj,2);
            AssignAttri(sPrefix, false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         wcpOA11OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA11OrganisationId"));
         if ( ! GetJustCreated( ) && ( ( A11OrganisationId != wcpOA11OrganisationId ) ) )
         {
            setjustcreated();
         }
         wcpOA11OrganisationId = A11OrganisationId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA11OrganisationId = cgiGet( sPrefix+"A11OrganisationId_CTRL");
         if ( StringUtil.Len( sCtrlA11OrganisationId) > 0 )
         {
            A11OrganisationId = StringUtil.StrToGuid( cgiGet( sCtrlA11OrganisationId));
            AssignAttri(sPrefix, false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         else
         {
            A11OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"A11OrganisationId_PARM"));
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
         PA3S2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS3S2( ) ;
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
         WS3S2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A11OrganisationId_PARM", A11OrganisationId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA11OrganisationId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A11OrganisationId_CTRL", StringUtil.RTrim( sCtrlA11OrganisationId));
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
         WE3S2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256201223929", true, true);
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
         context.AddJavascriptSource("trn_organisationgeneral.js", "?20256201223929", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtOrganisationName_Internalname = sPrefix+"ORGANISATIONNAME";
         edtOrganisationTypeName_Internalname = sPrefix+"ORGANISATIONTYPENAME";
         edtOrganisationKvkNumber_Internalname = sPrefix+"ORGANISATIONKVKNUMBER";
         edtOrganisationVATNumber_Internalname = sPrefix+"ORGANISATIONVATNUMBER";
         edtOrganisationEmail_Internalname = sPrefix+"ORGANISATIONEMAIL";
         lblTransactiondetail_phone_Internalname = sPrefix+"TRANSACTIONDETAIL_PHONE";
         edtavOrganisationphonecode_description_Internalname = sPrefix+"vORGANISATIONPHONECODE_DESCRIPTION";
         divUnnamedtable7_Internalname = sPrefix+"UNNAMEDTABLE7";
         edtOrganisationPhoneNumber_Internalname = sPrefix+"ORGANISATIONPHONENUMBER";
         divUnnamedtable6_Internalname = sPrefix+"UNNAMEDTABLE6";
         divUnnamedtable5_Internalname = sPrefix+"UNNAMEDTABLE5";
         edtOrganisationPhone_Internalname = sPrefix+"ORGANISATIONPHONE";
         divOrganisationphone_cell_Internalname = sPrefix+"ORGANISATIONPHONE_CELL";
         imgOrganisationLogo_Internalname = sPrefix+"ORGANISATIONLOGO";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         grpUnnamedgroup2_Internalname = sPrefix+"UNNAMEDGROUP2";
         edtOrganisationAddressLine1_Internalname = sPrefix+"ORGANISATIONADDRESSLINE1";
         edtOrganisationAddressLine2_Internalname = sPrefix+"ORGANISATIONADDRESSLINE2";
         edtOrganisationAddressZipCode_Internalname = sPrefix+"ORGANISATIONADDRESSZIPCODE";
         edtOrganisationAddressCity_Internalname = sPrefix+"ORGANISATIONADDRESSCITY";
         edtavOrganisationaddresscountry_description_Internalname = sPrefix+"vORGANISATIONADDRESSCOUNTRY_DESCRIPTION";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         grpUnnamedgroup4_Internalname = sPrefix+"UNNAMEDGROUP4";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtncancel_Internalname = sPrefix+"BTNCANCEL";
         divTable_Internalname = sPrefix+"TABLE";
         edtOrganisationId_Internalname = sPrefix+"ORGANISATIONID";
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
         edtOrganisationId_Enabled = 0;
         imgOrganisationLogo_Enabled = 0;
         edtOrganisationId_Jsonclick = "";
         edtOrganisationId_Visible = 1;
         edtavOrganisationaddresscountry_description_Jsonclick = "";
         edtavOrganisationaddresscountry_description_Enabled = 1;
         edtOrganisationAddressCity_Jsonclick = "";
         edtOrganisationAddressCity_Enabled = 0;
         edtOrganisationAddressZipCode_Jsonclick = "";
         edtOrganisationAddressZipCode_Enabled = 0;
         edtOrganisationAddressLine2_Jsonclick = "";
         edtOrganisationAddressLine2_Enabled = 0;
         edtOrganisationAddressLine1_Jsonclick = "";
         edtOrganisationAddressLine1_Enabled = 0;
         edtOrganisationPhone_Jsonclick = "";
         edtOrganisationPhone_Enabled = 0;
         edtOrganisationPhone_Visible = 1;
         divOrganisationphone_cell_Class = "col-xs-12";
         edtOrganisationPhoneNumber_Jsonclick = "";
         edtOrganisationPhoneNumber_Enabled = 0;
         edtavOrganisationphonecode_description_Jsonclick = "";
         edtavOrganisationphonecode_description_Enabled = 1;
         divUnnamedtable5_Visible = 1;
         edtOrganisationEmail_Jsonclick = "";
         edtOrganisationEmail_Enabled = 0;
         edtOrganisationVATNumber_Jsonclick = "";
         edtOrganisationVATNumber_Enabled = 0;
         edtOrganisationKvkNumber_Jsonclick = "";
         edtOrganisationKvkNumber_Enabled = 0;
         edtOrganisationTypeName_Jsonclick = "";
         edtOrganisationTypeName_Link = "";
         edtOrganisationTypeName_Enabled = 0;
         edtOrganisationName_Jsonclick = "";
         edtOrganisationName_Enabled = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID"}]}""");
         setEventMetadata("VALID_ORGANISATIONID","""{"handler":"Valid_Organisationid","iparms":[]}""");
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
         wcpOA11OrganisationId = Guid.Empty;
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
         A13OrganisationName = "";
         A20OrganisationTypeName = "";
         A12OrganisationKvkNumber = "";
         A18OrganisationVATNumber = "";
         A16OrganisationEmail = "";
         lblTransactiondetail_phone_Jsonclick = "";
         AV19OrganisationPhoneCode_Description = "";
         A362OrganisationPhoneNumber = "";
         gxphoneLink = "";
         A17OrganisationPhone = "";
         ClassString = "";
         StyleString = "";
         A506OrganisationLogo = "";
         A40000OrganisationLogo_GXI = "";
         sImgUrl = "";
         A304OrganisationAddressLine1 = "";
         A305OrganisationAddressLine2 = "";
         A251OrganisationAddressZipCode = "";
         A252OrganisationAddressCity = "";
         AV16OrganisationAddressCountry_Description = "";
         bttBtncancel_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H003S2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H003S2_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         H003S2_A252OrganisationAddressCity = new string[] {""} ;
         H003S2_A251OrganisationAddressZipCode = new string[] {""} ;
         H003S2_A305OrganisationAddressLine2 = new string[] {""} ;
         H003S2_A304OrganisationAddressLine1 = new string[] {""} ;
         H003S2_A40000OrganisationLogo_GXI = new string[] {""} ;
         H003S2_A17OrganisationPhone = new string[] {""} ;
         H003S2_A362OrganisationPhoneNumber = new string[] {""} ;
         H003S2_A16OrganisationEmail = new string[] {""} ;
         H003S2_A18OrganisationVATNumber = new string[] {""} ;
         H003S2_A12OrganisationKvkNumber = new string[] {""} ;
         H003S2_A20OrganisationTypeName = new string[] {""} ;
         H003S2_A13OrganisationName = new string[] {""} ;
         H003S2_A506OrganisationLogo = new string[] {""} ;
         A19OrganisationTypeId = Guid.Empty;
         Gx_mode = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV17Combo_DataJson = "";
         AV18ComboSelectedValue = "";
         GXt_char1 = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA11OrganisationId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_organisationgeneral__default(),
            new Object[][] {
                new Object[] {
               H003S2_A11OrganisationId, H003S2_A19OrganisationTypeId, H003S2_A252OrganisationAddressCity, H003S2_A251OrganisationAddressZipCode, H003S2_A305OrganisationAddressLine2, H003S2_A304OrganisationAddressLine1, H003S2_A40000OrganisationLogo_GXI, H003S2_A17OrganisationPhone, H003S2_A362OrganisationPhoneNumber, H003S2_A16OrganisationEmail,
               H003S2_A18OrganisationVATNumber, H003S2_A12OrganisationKvkNumber, H003S2_A20OrganisationTypeName, H003S2_A13OrganisationName, H003S2_A506OrganisationLogo
               }
            }
         );
         AV21Pgmname = "Trn_OrganisationGeneral";
         /* GeneXus formulas. */
         AV21Pgmname = "Trn_OrganisationGeneral";
         edtavOrganisationphonecode_description_Enabled = 0;
         edtavOrganisationaddresscountry_description_Enabled = 0;
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
      private int edtavOrganisationphonecode_description_Enabled ;
      private int edtavOrganisationaddresscountry_description_Enabled ;
      private int edtOrganisationName_Enabled ;
      private int edtOrganisationTypeName_Enabled ;
      private int edtOrganisationKvkNumber_Enabled ;
      private int edtOrganisationVATNumber_Enabled ;
      private int edtOrganisationEmail_Enabled ;
      private int divUnnamedtable5_Visible ;
      private int edtOrganisationPhoneNumber_Enabled ;
      private int edtOrganisationPhone_Visible ;
      private int edtOrganisationPhone_Enabled ;
      private int edtOrganisationAddressLine1_Enabled ;
      private int edtOrganisationAddressLine2_Enabled ;
      private int edtOrganisationAddressZipCode_Enabled ;
      private int edtOrganisationAddressCity_Enabled ;
      private int edtOrganisationId_Visible ;
      private int imgOrganisationLogo_Enabled ;
      private int edtOrganisationId_Enabled ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV21Pgmname ;
      private string edtavOrganisationphonecode_description_Internalname ;
      private string edtavOrganisationaddresscountry_description_Internalname ;
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
      private string edtOrganisationName_Internalname ;
      private string TempTags ;
      private string edtOrganisationName_Jsonclick ;
      private string edtOrganisationTypeName_Internalname ;
      private string edtOrganisationTypeName_Link ;
      private string edtOrganisationTypeName_Jsonclick ;
      private string edtOrganisationKvkNumber_Internalname ;
      private string edtOrganisationKvkNumber_Jsonclick ;
      private string edtOrganisationVATNumber_Internalname ;
      private string edtOrganisationVATNumber_Jsonclick ;
      private string edtOrganisationEmail_Internalname ;
      private string edtOrganisationEmail_Jsonclick ;
      private string divUnnamedtable5_Internalname ;
      private string lblTransactiondetail_phone_Internalname ;
      private string lblTransactiondetail_phone_Jsonclick ;
      private string divUnnamedtable6_Internalname ;
      private string divUnnamedtable7_Internalname ;
      private string edtavOrganisationphonecode_description_Jsonclick ;
      private string edtOrganisationPhoneNumber_Internalname ;
      private string edtOrganisationPhoneNumber_Jsonclick ;
      private string divOrganisationphone_cell_Internalname ;
      private string divOrganisationphone_cell_Class ;
      private string edtOrganisationPhone_Internalname ;
      private string gxphoneLink ;
      private string A17OrganisationPhone ;
      private string edtOrganisationPhone_Jsonclick ;
      private string imgOrganisationLogo_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string grpUnnamedgroup4_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string edtOrganisationAddressLine1_Internalname ;
      private string edtOrganisationAddressLine1_Jsonclick ;
      private string edtOrganisationAddressLine2_Internalname ;
      private string edtOrganisationAddressLine2_Jsonclick ;
      private string edtOrganisationAddressZipCode_Internalname ;
      private string edtOrganisationAddressZipCode_Jsonclick ;
      private string edtOrganisationAddressCity_Internalname ;
      private string edtOrganisationAddressCity_Jsonclick ;
      private string edtavOrganisationaddresscountry_description_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtOrganisationId_Internalname ;
      private string edtOrganisationId_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string GXt_char1 ;
      private string sCtrlA11OrganisationId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool A506OrganisationLogo_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV14TempBoolean ;
      private bool GXt_boolean2 ;
      private string AV17Combo_DataJson ;
      private string A13OrganisationName ;
      private string A20OrganisationTypeName ;
      private string A12OrganisationKvkNumber ;
      private string A18OrganisationVATNumber ;
      private string A16OrganisationEmail ;
      private string AV19OrganisationPhoneCode_Description ;
      private string A362OrganisationPhoneNumber ;
      private string A40000OrganisationLogo_GXI ;
      private string A304OrganisationAddressLine1 ;
      private string A305OrganisationAddressLine2 ;
      private string A251OrganisationAddressZipCode ;
      private string A252OrganisationAddressCity ;
      private string AV16OrganisationAddressCountry_Description ;
      private string AV18ComboSelectedValue ;
      private string A506OrganisationLogo ;
      private Guid A11OrganisationId ;
      private Guid wcpOA11OrganisationId ;
      private Guid A19OrganisationTypeId ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] H003S2_A11OrganisationId ;
      private Guid[] H003S2_A19OrganisationTypeId ;
      private string[] H003S2_A252OrganisationAddressCity ;
      private string[] H003S2_A251OrganisationAddressZipCode ;
      private string[] H003S2_A305OrganisationAddressLine2 ;
      private string[] H003S2_A304OrganisationAddressLine1 ;
      private string[] H003S2_A40000OrganisationLogo_GXI ;
      private string[] H003S2_A17OrganisationPhone ;
      private string[] H003S2_A362OrganisationPhoneNumber ;
      private string[] H003S2_A16OrganisationEmail ;
      private string[] H003S2_A18OrganisationVATNumber ;
      private string[] H003S2_A12OrganisationKvkNumber ;
      private string[] H003S2_A20OrganisationTypeName ;
      private string[] H003S2_A13OrganisationName ;
      private string[] H003S2_A506OrganisationLogo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class trn_organisationgeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH003S2;
          prmH003S2 = new Object[] {
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("H003S2", "SELECT T1.OrganisationId, T1.OrganisationTypeId, T1.OrganisationAddressCity, T1.OrganisationAddressZipCode, T1.OrganisationAddressLine2, T1.OrganisationAddressLine1, T1.OrganisationLogo_GXI, T1.OrganisationPhone, T1.OrganisationPhoneNumber, T1.OrganisationEmail, T1.OrganisationVATNumber, T1.OrganisationKvkNumber, T2.OrganisationTypeName, T1.OrganisationName, T1.OrganisationLogo FROM (Trn_Organisation T1 INNER JOIN Trn_OrganisationType T2 ON T2.OrganisationTypeId = T1.OrganisationTypeId) WHERE T1.OrganisationId = :OrganisationId ORDER BY T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003S2,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((string[]) buf[12])[0] = rslt.getVarchar(13);
                ((string[]) buf[13])[0] = rslt.getVarchar(14);
                ((string[]) buf[14])[0] = rslt.getMultimediaFile(15, rslt.getVarchar(7));
                return;
       }
    }

 }

}
