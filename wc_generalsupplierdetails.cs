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
   public class wc_generalsupplierdetails : GXWebComponent
   {
      public wc_generalsupplierdetails( )
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

      public wc_generalsupplierdetails( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_TrnMode ,
                           Guid aP1_SupplierGenId )
      {
         this.AV11TrnMode = aP0_TrnMode;
         this.AV5SupplierGenId = aP1_SupplierGenId;
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
               gxfirstwebparm = GetFirstPar( "TrnMode");
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
                  AV11TrnMode = GetPar( "TrnMode");
                  AssignAttri(sPrefix, false, "AV11TrnMode", AV11TrnMode);
                  AV5SupplierGenId = StringUtil.StrToGuid( GetPar( "SupplierGenId"));
                  AssignAttri(sPrefix, false, "AV5SupplierGenId", AV5SupplierGenId.ToString());
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV11TrnMode,(Guid)AV5SupplierGenId});
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
                  gxfirstwebparm = GetFirstPar( "TrnMode");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "TrnMode");
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
            PA6I2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavTrn_suppliergen_suppliergencompanyname_Enabled = 0;
               AssignProp(sPrefix, false, edtavTrn_suppliergen_suppliergencompanyname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergencompanyname_Enabled), 5, 0), true);
               edtavTrn_suppliergen_suppliergenkvknumber_Enabled = 0;
               AssignProp(sPrefix, false, edtavTrn_suppliergen_suppliergenkvknumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergenkvknumber_Enabled), 5, 0), true);
               edtavTrn_suppliergen_suppliergentypename_Enabled = 0;
               AssignProp(sPrefix, false, edtavTrn_suppliergen_suppliergentypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergentypename_Enabled), 5, 0), true);
               edtavTrn_suppliergen_suppliergencontactname_Enabled = 0;
               AssignProp(sPrefix, false, edtavTrn_suppliergen_suppliergencontactname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergencontactname_Enabled), 5, 0), true);
               edtavTrn_suppliergen_suppliergencontactphone_Enabled = 0;
               AssignProp(sPrefix, false, edtavTrn_suppliergen_suppliergencontactphone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergencontactphone_Enabled), 5, 0), true);
               edtavTrn_suppliergen_suppliergenaddressline1_Enabled = 0;
               AssignProp(sPrefix, false, edtavTrn_suppliergen_suppliergenaddressline1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergenaddressline1_Enabled), 5, 0), true);
               edtavTrn_suppliergen_suppliergenaddressline2_Enabled = 0;
               AssignProp(sPrefix, false, edtavTrn_suppliergen_suppliergenaddressline2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergenaddressline2_Enabled), 5, 0), true);
               edtavTrn_suppliergen_suppliergenaddresszipcode_Enabled = 0;
               AssignProp(sPrefix, false, edtavTrn_suppliergen_suppliergenaddresszipcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergenaddresszipcode_Enabled), 5, 0), true);
               edtavTrn_suppliergen_suppliergenaddresscity_Enabled = 0;
               AssignProp(sPrefix, false, edtavTrn_suppliergen_suppliergenaddresscity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergenaddresscity_Enabled), 5, 0), true);
               edtavTrn_suppliergen_suppliergenaddresscountry_Enabled = 0;
               AssignProp(sPrefix, false, edtavTrn_suppliergen_suppliergenaddresscountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergenaddresscountry_Enabled), 5, 0), true);
               WS6I2( ) ;
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
            context.SendWebValue( context.GetMessage( "WC_General Supplier Details", "")) ;
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
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wc_generalsupplierdetails.aspx"+UrlEncode(StringUtil.RTrim(AV11TrnMode)) + "," + UrlEncode(AV5SupplierGenId.ToString());
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wc_generalsupplierdetails.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Trn_suppliergen", AV6Trn_SupplierGen);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Trn_suppliergen", AV6Trn_SupplierGen);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV11TrnMode", StringUtil.RTrim( wcpOAV11TrnMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV5SupplierGenId", wcpOAV5SupplierGenId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"vTRNMODE", StringUtil.RTrim( AV11TrnMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSUPPLIERGENID", AV5SupplierGenId.ToString());
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTRN_SUPPLIERGEN", AV6Trn_SupplierGen);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTRN_SUPPLIERGEN", AV6Trn_SupplierGen);
         }
      }

      protected void RenderHtmlCloseForm6I2( )
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
         return "WC_GeneralSupplierDetails" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WC_General Supplier Details", "") ;
      }

      protected void WB6I0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wc_generalsupplierdetails.aspx");
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_suppliergen_suppliergencompanyname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_suppliergen_suppliergencompanyname_Internalname, context.GetMessage( "Name", ""), "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_suppliergen_suppliergencompanyname_Internalname, AV6Trn_SupplierGen.gxTpr_Suppliergencompanyname, StringUtil.RTrim( context.localUtil.Format( AV6Trn_SupplierGen.gxTpr_Suppliergencompanyname, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_suppliergen_suppliergencompanyname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_suppliergen_suppliergencompanyname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WC_GeneralSupplierDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_suppliergen_suppliergenkvknumber_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_suppliergen_suppliergenkvknumber_Internalname, context.GetMessage( "KvK Number", ""), "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_suppliergen_suppliergenkvknumber_Internalname, AV6Trn_SupplierGen.gxTpr_Suppliergenkvknumber, StringUtil.RTrim( context.localUtil.Format( AV6Trn_SupplierGen.gxTpr_Suppliergenkvknumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_suppliergen_suppliergenkvknumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_suppliergen_suppliergenkvknumber_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WC_GeneralSupplierDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_suppliergen_suppliergentypename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_suppliergen_suppliergentypename_Internalname, context.GetMessage( "Category", ""), "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_suppliergen_suppliergentypename_Internalname, AV6Trn_SupplierGen.gxTpr_Suppliergentypename, StringUtil.RTrim( context.localUtil.Format( AV6Trn_SupplierGen.gxTpr_Suppliergentypename, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_suppliergen_suppliergentypename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_suppliergen_suppliergentypename_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WC_GeneralSupplierDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_suppliergen_suppliergencontactname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_suppliergen_suppliergencontactname_Internalname, context.GetMessage( "Contact Person", ""), "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_suppliergen_suppliergencontactname_Internalname, AV6Trn_SupplierGen.gxTpr_Suppliergencontactname, StringUtil.RTrim( context.localUtil.Format( AV6Trn_SupplierGen.gxTpr_Suppliergencontactname, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_suppliergen_suppliergencontactname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_suppliergen_suppliergencontactname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WC_GeneralSupplierDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_suppliergen_suppliergencontactphone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_suppliergen_suppliergencontactphone_Internalname, context.GetMessage( "Phone", ""), "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_suppliergen_suppliergencontactphone_Internalname, StringUtil.RTrim( AV6Trn_SupplierGen.gxTpr_Suppliergencontactphone), StringUtil.RTrim( context.localUtil.Format( AV6Trn_SupplierGen.gxTpr_Suppliergencontactphone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_suppliergen_suppliergencontactphone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_suppliergen_suppliergencontactphone_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, false, "", "start", true, "", "HLP_WC_GeneralSupplierDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_suppliergen_suppliergenaddressline1_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_suppliergen_suppliergenaddressline1_Internalname, context.GetMessage( "Address Line 1", ""), "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_suppliergen_suppliergenaddressline1_Internalname, AV6Trn_SupplierGen.gxTpr_Suppliergenaddressline1, StringUtil.RTrim( context.localUtil.Format( AV6Trn_SupplierGen.gxTpr_Suppliergenaddressline1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_suppliergen_suppliergenaddressline1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_suppliergen_suppliergenaddressline1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WC_GeneralSupplierDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_suppliergen_suppliergenaddressline2_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_suppliergen_suppliergenaddressline2_Internalname, context.GetMessage( "Address Line 2", ""), "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_suppliergen_suppliergenaddressline2_Internalname, AV6Trn_SupplierGen.gxTpr_Suppliergenaddressline2, StringUtil.RTrim( context.localUtil.Format( AV6Trn_SupplierGen.gxTpr_Suppliergenaddressline2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_suppliergen_suppliergenaddressline2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_suppliergen_suppliergenaddressline2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WC_GeneralSupplierDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_suppliergen_suppliergenaddresszipcode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_suppliergen_suppliergenaddresszipcode_Internalname, context.GetMessage( "Zipcode", ""), "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_suppliergen_suppliergenaddresszipcode_Internalname, AV6Trn_SupplierGen.gxTpr_Suppliergenaddresszipcode, StringUtil.RTrim( context.localUtil.Format( AV6Trn_SupplierGen.gxTpr_Suppliergenaddresszipcode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_suppliergen_suppliergenaddresszipcode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_suppliergen_suppliergenaddresszipcode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WC_GeneralSupplierDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_suppliergen_suppliergenaddresscity_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_suppliergen_suppliergenaddresscity_Internalname, context.GetMessage( "City", ""), "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_suppliergen_suppliergenaddresscity_Internalname, AV6Trn_SupplierGen.gxTpr_Suppliergenaddresscity, StringUtil.RTrim( context.localUtil.Format( AV6Trn_SupplierGen.gxTpr_Suppliergenaddresscity, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_suppliergen_suppliergenaddresscity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_suppliergen_suppliergenaddresscity_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WC_GeneralSupplierDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_suppliergen_suppliergenaddresscountry_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_suppliergen_suppliergenaddresscountry_Internalname, context.GetMessage( "Country", ""), "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_suppliergen_suppliergenaddresscountry_Internalname, AV6Trn_SupplierGen.gxTpr_Suppliergenaddresscountry, StringUtil.RTrim( context.localUtil.Format( AV6Trn_SupplierGen.gxTpr_Suppliergenaddresscountry, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_suppliergen_suppliergenaddresscountry_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_suppliergen_suppliergenaddresscountry_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WC_GeneralSupplierDetails.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_suppliergen_suppliergenphonecode_Internalname, AV6Trn_SupplierGen.gxTpr_Suppliergenphonecode, StringUtil.RTrim( context.localUtil.Format( AV6Trn_SupplierGen.gxTpr_Suppliergenphonecode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_suppliergen_suppliergenphonecode_Jsonclick, 0, "Attribute", "", "", "", "", edtavTrn_suppliergen_suppliergenphonecode_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WC_GeneralSupplierDetails.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_suppliergen_suppliergenphonenumber_Internalname, AV6Trn_SupplierGen.gxTpr_Suppliergenphonenumber, StringUtil.RTrim( context.localUtil.Format( AV6Trn_SupplierGen.gxTpr_Suppliergenphonenumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_suppliergen_suppliergenphonenumber_Jsonclick, 0, "Attribute", "", "", "", "", edtavTrn_suppliergen_suppliergenphonenumber_Visible, 1, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WC_GeneralSupplierDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START6I2( )
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
            Form.Meta.addItem("description", context.GetMessage( "WC_General Supplier Details", ""), 0) ;
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
               STRUP6I0( ) ;
            }
         }
      }

      protected void WS6I2( )
      {
         START6I2( ) ;
         EVT6I2( ) ;
      }

      protected void EVT6I2( )
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
                                 STRUP6I0( ) ;
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
                                 STRUP6I0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E116I2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6I0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E126I2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6I0( ) ;
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
                                 STRUP6I0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavTrn_suppliergen_suppliergencompanyname_Internalname;
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

      protected void WE6I2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm6I2( ) ;
            }
         }
      }

      protected void PA6I2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wc_generalsupplierdetails.aspx")), "wc_generalsupplierdetails.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wc_generalsupplierdetails.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "TrnMode");
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
               GX_FocusControl = edtavTrn_suppliergen_suppliergencompanyname_Internalname;
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
         RF6I2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavTrn_suppliergen_suppliergencompanyname_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_suppliergen_suppliergencompanyname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergencompanyname_Enabled), 5, 0), true);
         edtavTrn_suppliergen_suppliergenkvknumber_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_suppliergen_suppliergenkvknumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergenkvknumber_Enabled), 5, 0), true);
         edtavTrn_suppliergen_suppliergentypename_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_suppliergen_suppliergentypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergentypename_Enabled), 5, 0), true);
         edtavTrn_suppliergen_suppliergencontactname_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_suppliergen_suppliergencontactname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergencontactname_Enabled), 5, 0), true);
         edtavTrn_suppliergen_suppliergencontactphone_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_suppliergen_suppliergencontactphone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergencontactphone_Enabled), 5, 0), true);
         edtavTrn_suppliergen_suppliergenaddressline1_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_suppliergen_suppliergenaddressline1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergenaddressline1_Enabled), 5, 0), true);
         edtavTrn_suppliergen_suppliergenaddressline2_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_suppliergen_suppliergenaddressline2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergenaddressline2_Enabled), 5, 0), true);
         edtavTrn_suppliergen_suppliergenaddresszipcode_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_suppliergen_suppliergenaddresszipcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergenaddresszipcode_Enabled), 5, 0), true);
         edtavTrn_suppliergen_suppliergenaddresscity_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_suppliergen_suppliergenaddresscity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergenaddresscity_Enabled), 5, 0), true);
         edtavTrn_suppliergen_suppliergenaddresscountry_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_suppliergen_suppliergenaddresscountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergenaddresscountry_Enabled), 5, 0), true);
      }

      protected void RF6I2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E126I2 ();
            WB6I0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes6I2( )
      {
      }

      protected void before_start_formulas( )
      {
         edtavTrn_suppliergen_suppliergencompanyname_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_suppliergen_suppliergencompanyname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergencompanyname_Enabled), 5, 0), true);
         edtavTrn_suppliergen_suppliergenkvknumber_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_suppliergen_suppliergenkvknumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergenkvknumber_Enabled), 5, 0), true);
         edtavTrn_suppliergen_suppliergentypename_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_suppliergen_suppliergentypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergentypename_Enabled), 5, 0), true);
         edtavTrn_suppliergen_suppliergencontactname_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_suppliergen_suppliergencontactname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergencontactname_Enabled), 5, 0), true);
         edtavTrn_suppliergen_suppliergencontactphone_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_suppliergen_suppliergencontactphone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergencontactphone_Enabled), 5, 0), true);
         edtavTrn_suppliergen_suppliergenaddressline1_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_suppliergen_suppliergenaddressline1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergenaddressline1_Enabled), 5, 0), true);
         edtavTrn_suppliergen_suppliergenaddressline2_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_suppliergen_suppliergenaddressline2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergenaddressline2_Enabled), 5, 0), true);
         edtavTrn_suppliergen_suppliergenaddresszipcode_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_suppliergen_suppliergenaddresszipcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergenaddresszipcode_Enabled), 5, 0), true);
         edtavTrn_suppliergen_suppliergenaddresscity_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_suppliergen_suppliergenaddresscity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergenaddresscity_Enabled), 5, 0), true);
         edtavTrn_suppliergen_suppliergenaddresscountry_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_suppliergen_suppliergenaddresscountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergenaddresscountry_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP6I0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E116I2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vTRN_SUPPLIERGEN"), AV6Trn_SupplierGen);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Trn_suppliergen"), AV6Trn_SupplierGen);
            /* Read saved values. */
            wcpOAV11TrnMode = cgiGet( sPrefix+"wcpOAV11TrnMode");
            wcpOAV5SupplierGenId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV5SupplierGenId"));
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
         E116I2 ();
         if (returnInSub) return;
      }

      protected void E116I2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp(sPrefix, false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         AV12LoadSuccess = true;
         if ( ( ( StringUtil.StrCmp(AV11TrnMode, "DSP") == 0 ) ) || ( ( StringUtil.StrCmp(AV11TrnMode, "INS") == 0 ) && new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context).executeUdp(  "trn_suppliergen_Insert") ) || ( ( StringUtil.StrCmp(AV11TrnMode, "UPD") == 0 ) && new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context).executeUdp(  "trn_suppliergen_Update") ) || ( ( StringUtil.StrCmp(AV11TrnMode, "DLT") == 0 ) && new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context).executeUdp(  "trn_suppliergen_Delete") ) )
         {
            if ( StringUtil.StrCmp(AV11TrnMode, "INS") != 0 )
            {
               AV6Trn_SupplierGen.Load(AV5SupplierGenId);
               AV12LoadSuccess = AV6Trn_SupplierGen.Success();
               if ( ! AV12LoadSuccess )
               {
                  AV10Messages = AV6Trn_SupplierGen.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
               if ( ( StringUtil.StrCmp(AV11TrnMode, "DSP") == 0 ) || ( StringUtil.StrCmp(AV11TrnMode, "DLT") == 0 ) )
               {
               }
            }
         }
         else
         {
            AV12LoadSuccess = false;
            CallWebObject(formatLink("wp_notauthorized.aspx") );
            context.wjLocDisableFrm = 1;
         }
         if ( AV12LoadSuccess )
         {
            if ( StringUtil.StrCmp(AV11TrnMode, "DLT") == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""));
            }
         }
         edtavTrn_suppliergen_suppliergenphonecode_Visible = 0;
         AssignProp(sPrefix, false, edtavTrn_suppliergen_suppliergenphonecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergenphonecode_Visible), 5, 0), true);
         edtavTrn_suppliergen_suppliergenphonenumber_Visible = 0;
         AssignProp(sPrefix, false, edtavTrn_suppliergen_suppliergenphonenumber_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTrn_suppliergen_suppliergenphonenumber_Visible), 5, 0), true);
      }

      protected void S112( )
      {
         /* 'SHOW MESSAGES' Routine */
         returnInSub = false;
         AV27GXV13 = 1;
         while ( AV27GXV13 <= AV10Messages.Count )
         {
            AV9Message = ((GeneXus.Utils.SdtMessages_Message)AV10Messages.Item(AV27GXV13));
            GX_msglist.addItem(AV9Message.gxTpr_Description);
            AV27GXV13 = (int)(AV27GXV13+1);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E126I2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV11TrnMode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV11TrnMode", AV11TrnMode);
         AV5SupplierGenId = (Guid)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV5SupplierGenId", AV5SupplierGenId.ToString());
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
         PA6I2( ) ;
         WS6I2( ) ;
         WE6I2( ) ;
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
         sCtrlAV11TrnMode = (string)((string)getParm(obj,0));
         sCtrlAV5SupplierGenId = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA6I2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wc_generalsupplierdetails", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA6I2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV11TrnMode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV11TrnMode", AV11TrnMode);
            AV5SupplierGenId = (Guid)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV5SupplierGenId", AV5SupplierGenId.ToString());
         }
         wcpOAV11TrnMode = cgiGet( sPrefix+"wcpOAV11TrnMode");
         wcpOAV5SupplierGenId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV5SupplierGenId"));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV11TrnMode, wcpOAV11TrnMode) != 0 ) || ( AV5SupplierGenId != wcpOAV5SupplierGenId ) ) )
         {
            setjustcreated();
         }
         wcpOAV11TrnMode = AV11TrnMode;
         wcpOAV5SupplierGenId = AV5SupplierGenId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV11TrnMode = cgiGet( sPrefix+"AV11TrnMode_CTRL");
         if ( StringUtil.Len( sCtrlAV11TrnMode) > 0 )
         {
            AV11TrnMode = cgiGet( sCtrlAV11TrnMode);
            AssignAttri(sPrefix, false, "AV11TrnMode", AV11TrnMode);
         }
         else
         {
            AV11TrnMode = cgiGet( sPrefix+"AV11TrnMode_PARM");
         }
         sCtrlAV5SupplierGenId = cgiGet( sPrefix+"AV5SupplierGenId_CTRL");
         if ( StringUtil.Len( sCtrlAV5SupplierGenId) > 0 )
         {
            AV5SupplierGenId = StringUtil.StrToGuid( cgiGet( sCtrlAV5SupplierGenId));
            AssignAttri(sPrefix, false, "AV5SupplierGenId", AV5SupplierGenId.ToString());
         }
         else
         {
            AV5SupplierGenId = StringUtil.StrToGuid( cgiGet( sPrefix+"AV5SupplierGenId_PARM"));
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
         PA6I2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS6I2( ) ;
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
         WS6I2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV11TrnMode_PARM", StringUtil.RTrim( AV11TrnMode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV11TrnMode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV11TrnMode_CTRL", StringUtil.RTrim( sCtrlAV11TrnMode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV5SupplierGenId_PARM", AV5SupplierGenId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV5SupplierGenId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV5SupplierGenId_CTRL", StringUtil.RTrim( sCtrlAV5SupplierGenId));
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
         WE6I2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256145282255", true, true);
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
            context.AddJavascriptSource("wc_generalsupplierdetails.js", "?20256145282256", false, true);
         }
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavTrn_suppliergen_suppliergencompanyname_Internalname = sPrefix+"TRN_SUPPLIERGEN_SUPPLIERGENCOMPANYNAME";
         edtavTrn_suppliergen_suppliergenkvknumber_Internalname = sPrefix+"TRN_SUPPLIERGEN_SUPPLIERGENKVKNUMBER";
         edtavTrn_suppliergen_suppliergentypename_Internalname = sPrefix+"TRN_SUPPLIERGEN_SUPPLIERGENTYPENAME";
         edtavTrn_suppliergen_suppliergencontactname_Internalname = sPrefix+"TRN_SUPPLIERGEN_SUPPLIERGENCONTACTNAME";
         edtavTrn_suppliergen_suppliergencontactphone_Internalname = sPrefix+"TRN_SUPPLIERGEN_SUPPLIERGENCONTACTPHONE";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         edtavTrn_suppliergen_suppliergenaddressline1_Internalname = sPrefix+"TRN_SUPPLIERGEN_SUPPLIERGENADDRESSLINE1";
         edtavTrn_suppliergen_suppliergenaddressline2_Internalname = sPrefix+"TRN_SUPPLIERGEN_SUPPLIERGENADDRESSLINE2";
         edtavTrn_suppliergen_suppliergenaddresszipcode_Internalname = sPrefix+"TRN_SUPPLIERGEN_SUPPLIERGENADDRESSZIPCODE";
         edtavTrn_suppliergen_suppliergenaddresscity_Internalname = sPrefix+"TRN_SUPPLIERGEN_SUPPLIERGENADDRESSCITY";
         edtavTrn_suppliergen_suppliergenaddresscountry_Internalname = sPrefix+"TRN_SUPPLIERGEN_SUPPLIERGENADDRESSCOUNTRY";
         divTableattributes2_Internalname = sPrefix+"TABLEATTRIBUTES2";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavTrn_suppliergen_suppliergenphonecode_Internalname = sPrefix+"TRN_SUPPLIERGEN_SUPPLIERGENPHONECODE";
         edtavTrn_suppliergen_suppliergenphonenumber_Internalname = sPrefix+"TRN_SUPPLIERGEN_SUPPLIERGENPHONENUMBER";
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
         edtavTrn_suppliergen_suppliergenphonenumber_Jsonclick = "";
         edtavTrn_suppliergen_suppliergenphonenumber_Visible = 1;
         edtavTrn_suppliergen_suppliergenphonecode_Jsonclick = "";
         edtavTrn_suppliergen_suppliergenphonecode_Visible = 1;
         edtavTrn_suppliergen_suppliergenaddresscountry_Jsonclick = "";
         edtavTrn_suppliergen_suppliergenaddresscountry_Enabled = 0;
         edtavTrn_suppliergen_suppliergenaddresscity_Jsonclick = "";
         edtavTrn_suppliergen_suppliergenaddresscity_Enabled = 0;
         edtavTrn_suppliergen_suppliergenaddresszipcode_Jsonclick = "";
         edtavTrn_suppliergen_suppliergenaddresszipcode_Enabled = 0;
         edtavTrn_suppliergen_suppliergenaddressline2_Jsonclick = "";
         edtavTrn_suppliergen_suppliergenaddressline2_Enabled = 0;
         edtavTrn_suppliergen_suppliergenaddressline1_Jsonclick = "";
         edtavTrn_suppliergen_suppliergenaddressline1_Enabled = 0;
         edtavTrn_suppliergen_suppliergencontactphone_Jsonclick = "";
         edtavTrn_suppliergen_suppliergencontactphone_Enabled = 0;
         edtavTrn_suppliergen_suppliergencontactname_Jsonclick = "";
         edtavTrn_suppliergen_suppliergencontactname_Enabled = 0;
         edtavTrn_suppliergen_suppliergentypename_Jsonclick = "";
         edtavTrn_suppliergen_suppliergentypename_Enabled = 0;
         edtavTrn_suppliergen_suppliergenkvknumber_Jsonclick = "";
         edtavTrn_suppliergen_suppliergenkvknumber_Enabled = 0;
         edtavTrn_suppliergen_suppliergencompanyname_Jsonclick = "";
         edtavTrn_suppliergen_suppliergencompanyname_Enabled = 0;
         divLayoutmaintable_Class = "Table TableTransactionTemplate";
         edtavTrn_suppliergen_suppliergenaddresscountry_Enabled = -1;
         edtavTrn_suppliergen_suppliergenaddresscity_Enabled = -1;
         edtavTrn_suppliergen_suppliergenaddresszipcode_Enabled = -1;
         edtavTrn_suppliergen_suppliergenaddressline2_Enabled = -1;
         edtavTrn_suppliergen_suppliergenaddressline1_Enabled = -1;
         edtavTrn_suppliergen_suppliergencontactphone_Enabled = -1;
         edtavTrn_suppliergen_suppliergencontactname_Enabled = -1;
         edtavTrn_suppliergen_suppliergentypename_Enabled = -1;
         edtavTrn_suppliergen_suppliergenkvknumber_Enabled = -1;
         edtavTrn_suppliergen_suppliergencompanyname_Enabled = -1;
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
         setEventMetadata("VALIDV_GXV2","""{"handler":"Validv_Gxv2","iparms":[]}""");
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
         wcpOAV11TrnMode = "";
         wcpOAV5SupplierGenId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV6Trn_SupplierGen = new SdtTrn_SupplierGen(context);
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV10Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV9Message = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV11TrnMode = "";
         sCtrlAV5SupplierGenId = "";
         /* GeneXus formulas. */
         edtavTrn_suppliergen_suppliergencompanyname_Enabled = 0;
         edtavTrn_suppliergen_suppliergenkvknumber_Enabled = 0;
         edtavTrn_suppliergen_suppliergentypename_Enabled = 0;
         edtavTrn_suppliergen_suppliergencontactname_Enabled = 0;
         edtavTrn_suppliergen_suppliergencontactphone_Enabled = 0;
         edtavTrn_suppliergen_suppliergenaddressline1_Enabled = 0;
         edtavTrn_suppliergen_suppliergenaddressline2_Enabled = 0;
         edtavTrn_suppliergen_suppliergenaddresszipcode_Enabled = 0;
         edtavTrn_suppliergen_suppliergenaddresscity_Enabled = 0;
         edtavTrn_suppliergen_suppliergenaddresscountry_Enabled = 0;
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
      private int edtavTrn_suppliergen_suppliergencompanyname_Enabled ;
      private int edtavTrn_suppliergen_suppliergenkvknumber_Enabled ;
      private int edtavTrn_suppliergen_suppliergentypename_Enabled ;
      private int edtavTrn_suppliergen_suppliergencontactname_Enabled ;
      private int edtavTrn_suppliergen_suppliergencontactphone_Enabled ;
      private int edtavTrn_suppliergen_suppliergenaddressline1_Enabled ;
      private int edtavTrn_suppliergen_suppliergenaddressline2_Enabled ;
      private int edtavTrn_suppliergen_suppliergenaddresszipcode_Enabled ;
      private int edtavTrn_suppliergen_suppliergenaddresscity_Enabled ;
      private int edtavTrn_suppliergen_suppliergenaddresscountry_Enabled ;
      private int edtavTrn_suppliergen_suppliergenphonecode_Visible ;
      private int edtavTrn_suppliergen_suppliergenphonenumber_Visible ;
      private int AV27GXV13 ;
      private int idxLst ;
      private string AV11TrnMode ;
      private string wcpOAV11TrnMode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string edtavTrn_suppliergen_suppliergencompanyname_Internalname ;
      private string edtavTrn_suppliergen_suppliergenkvknumber_Internalname ;
      private string edtavTrn_suppliergen_suppliergentypename_Internalname ;
      private string edtavTrn_suppliergen_suppliergencontactname_Internalname ;
      private string edtavTrn_suppliergen_suppliergencontactphone_Internalname ;
      private string edtavTrn_suppliergen_suppliergenaddressline1_Internalname ;
      private string edtavTrn_suppliergen_suppliergenaddressline2_Internalname ;
      private string edtavTrn_suppliergen_suppliergenaddresszipcode_Internalname ;
      private string edtavTrn_suppliergen_suppliergenaddresscity_Internalname ;
      private string edtavTrn_suppliergen_suppliergenaddresscountry_Internalname ;
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
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtavTrn_suppliergen_suppliergencompanyname_Jsonclick ;
      private string edtavTrn_suppliergen_suppliergenkvknumber_Jsonclick ;
      private string edtavTrn_suppliergen_suppliergentypename_Jsonclick ;
      private string edtavTrn_suppliergen_suppliergencontactname_Jsonclick ;
      private string edtavTrn_suppliergen_suppliergencontactphone_Jsonclick ;
      private string divTableattributes2_Internalname ;
      private string edtavTrn_suppliergen_suppliergenaddressline1_Jsonclick ;
      private string edtavTrn_suppliergen_suppliergenaddressline2_Jsonclick ;
      private string edtavTrn_suppliergen_suppliergenaddresszipcode_Jsonclick ;
      private string edtavTrn_suppliergen_suppliergenaddresscity_Jsonclick ;
      private string edtavTrn_suppliergen_suppliergenaddresscountry_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavTrn_suppliergen_suppliergenphonecode_Internalname ;
      private string edtavTrn_suppliergen_suppliergenphonecode_Jsonclick ;
      private string edtavTrn_suppliergen_suppliergenphonenumber_Internalname ;
      private string edtavTrn_suppliergen_suppliergenphonenumber_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string sCtrlAV11TrnMode ;
      private string sCtrlAV5SupplierGenId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV12LoadSuccess ;
      private Guid AV5SupplierGenId ;
      private Guid wcpOAV5SupplierGenId ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtTrn_SupplierGen AV6Trn_SupplierGen ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV10Messages ;
      private GeneXus.Utils.SdtMessages_Message AV9Message ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
