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
   public class wc_agbsupplierdetails : GXWebComponent
   {
      public wc_agbsupplierdetails( )
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

      public wc_agbsupplierdetails( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_TrnMode ,
                           Guid aP1_SupplierAgbId )
      {
         this.AV10TrnMode = aP0_TrnMode;
         this.AV14SupplierAgbId = aP1_SupplierAgbId;
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
                  AV10TrnMode = GetPar( "TrnMode");
                  AssignAttri(sPrefix, false, "AV10TrnMode", AV10TrnMode);
                  AV14SupplierAgbId = StringUtil.StrToGuid( GetPar( "SupplierAgbId"));
                  AssignAttri(sPrefix, false, "AV14SupplierAgbId", AV14SupplierAgbId.ToString());
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV10TrnMode,(Guid)AV14SupplierAgbId});
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
            PA6K2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavTrn_supplieragb_supplieragbname_Enabled = 0;
               AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbname_Enabled), 5, 0), true);
               edtavTrn_supplieragb_supplieragbkvknumber_Enabled = 0;
               AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbkvknumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbkvknumber_Enabled), 5, 0), true);
               edtavTrn_supplieragb_supplieragbtypename_Enabled = 0;
               AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbtypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbtypename_Enabled), 5, 0), true);
               edtavTrn_supplieragb_supplieragbcontactname_Enabled = 0;
               AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbcontactname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbcontactname_Enabled), 5, 0), true);
               edtavTrn_supplieragb_supplieragbphone_Enabled = 0;
               AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbphone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbphone_Enabled), 5, 0), true);
               edtavTrn_supplieragb_supplieragbemail_Enabled = 0;
               AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbemail_Enabled), 5, 0), true);
               edtavTrn_supplieragb_supplieragbnumber_Enabled = 0;
               AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbnumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbnumber_Enabled), 5, 0), true);
               edtavTrn_supplieragb_supplieragbaddressline1_Enabled = 0;
               AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbaddressline1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbaddressline1_Enabled), 5, 0), true);
               edtavTrn_supplieragb_supplieragbaddressline2_Enabled = 0;
               AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbaddressline2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbaddressline2_Enabled), 5, 0), true);
               edtavTrn_supplieragb_supplieragbaddresszipcode_Enabled = 0;
               AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbaddresszipcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbaddresszipcode_Enabled), 5, 0), true);
               edtavTrn_supplieragb_supplieragbaddresscity_Enabled = 0;
               AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbaddresscity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbaddresscity_Enabled), 5, 0), true);
               edtavTrn_supplieragb_supplieragbaddresscountry_Enabled = 0;
               AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbaddresscountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbaddresscountry_Enabled), 5, 0), true);
               WS6K2( ) ;
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
            context.SendWebValue( context.GetMessage( "WC_Agb Supplier Details", "")) ;
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
               GXEncryptionTmp = "wc_agbsupplierdetails.aspx"+UrlEncode(StringUtil.RTrim(AV10TrnMode)) + "," + UrlEncode(AV14SupplierAgbId.ToString());
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wc_agbsupplierdetails.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Trn_supplieragb", AV7Trn_SupplierAgb);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Trn_supplieragb", AV7Trn_SupplierAgb);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV10TrnMode", StringUtil.RTrim( wcpOAV10TrnMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV14SupplierAgbId", wcpOAV14SupplierAgbId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"vTRNMODE", StringUtil.RTrim( AV10TrnMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSUPPLIERAGBID", AV14SupplierAgbId.ToString());
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTRN_SUPPLIERAGB", AV7Trn_SupplierAgb);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTRN_SUPPLIERAGB", AV7Trn_SupplierAgb);
         }
      }

      protected void RenderHtmlCloseForm6K2( )
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
         return "WC_AgbSupplierDetails" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WC_Agb Supplier Details", "") ;
      }

      protected void WB6K0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wc_agbsupplierdetails.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_supplieragb_supplieragbname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_supplieragb_supplieragbname_Internalname, context.GetMessage( "Name", ""), "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_supplieragb_supplieragbname_Internalname, AV7Trn_SupplierAgb.gxTpr_Supplieragbname, StringUtil.RTrim( context.localUtil.Format( AV7Trn_SupplierAgb.gxTpr_Supplieragbname, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_supplieragb_supplieragbname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_supplieragb_supplieragbname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WC_AgbSupplierDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_supplieragb_supplieragbkvknumber_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_supplieragb_supplieragbkvknumber_Internalname, context.GetMessage( "KvK Number", ""), "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_supplieragb_supplieragbkvknumber_Internalname, AV7Trn_SupplierAgb.gxTpr_Supplieragbkvknumber, StringUtil.RTrim( context.localUtil.Format( AV7Trn_SupplierAgb.gxTpr_Supplieragbkvknumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_supplieragb_supplieragbkvknumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_supplieragb_supplieragbkvknumber_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WC_AgbSupplierDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_supplieragb_supplieragbtypename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_supplieragb_supplieragbtypename_Internalname, context.GetMessage( "Category", ""), "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_supplieragb_supplieragbtypename_Internalname, AV7Trn_SupplierAgb.gxTpr_Supplieragbtypename, StringUtil.RTrim( context.localUtil.Format( AV7Trn_SupplierAgb.gxTpr_Supplieragbtypename, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_supplieragb_supplieragbtypename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_supplieragb_supplieragbtypename_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WC_AgbSupplierDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_supplieragb_supplieragbcontactname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_supplieragb_supplieragbcontactname_Internalname, context.GetMessage( "Contact Person", ""), "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_supplieragb_supplieragbcontactname_Internalname, AV7Trn_SupplierAgb.gxTpr_Supplieragbcontactname, StringUtil.RTrim( context.localUtil.Format( AV7Trn_SupplierAgb.gxTpr_Supplieragbcontactname, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_supplieragb_supplieragbcontactname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_supplieragb_supplieragbcontactname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WC_AgbSupplierDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_supplieragb_supplieragbphone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_supplieragb_supplieragbphone_Internalname, context.GetMessage( "Phone", ""), "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_supplieragb_supplieragbphone_Internalname, StringUtil.RTrim( AV7Trn_SupplierAgb.gxTpr_Supplieragbphone), StringUtil.RTrim( context.localUtil.Format( AV7Trn_SupplierAgb.gxTpr_Supplieragbphone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_supplieragb_supplieragbphone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_supplieragb_supplieragbphone_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, false, "", "start", true, "", "HLP_WC_AgbSupplierDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_supplieragb_supplieragbemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_supplieragb_supplieragbemail_Internalname, context.GetMessage( "Email", ""), "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_supplieragb_supplieragbemail_Internalname, AV7Trn_SupplierAgb.gxTpr_Supplieragbemail, StringUtil.RTrim( context.localUtil.Format( AV7Trn_SupplierAgb.gxTpr_Supplieragbemail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_supplieragb_supplieragbemail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_supplieragb_supplieragbemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, false, "", "start", true, "", "HLP_WC_AgbSupplierDetails.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_supplieragb_supplieragbnumber_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_supplieragb_supplieragbnumber_Internalname, context.GetMessage( "AGB Number", ""), "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_supplieragb_supplieragbnumber_Internalname, AV7Trn_SupplierAgb.gxTpr_Supplieragbnumber, StringUtil.RTrim( context.localUtil.Format( AV7Trn_SupplierAgb.gxTpr_Supplieragbnumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_supplieragb_supplieragbnumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_supplieragb_supplieragbnumber_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WC_AgbSupplierDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_supplieragb_supplieragbaddressline1_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_supplieragb_supplieragbaddressline1_Internalname, context.GetMessage( "Address Line 1", ""), "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_supplieragb_supplieragbaddressline1_Internalname, AV7Trn_SupplierAgb.gxTpr_Supplieragbaddressline1, StringUtil.RTrim( context.localUtil.Format( AV7Trn_SupplierAgb.gxTpr_Supplieragbaddressline1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_supplieragb_supplieragbaddressline1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_supplieragb_supplieragbaddressline1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WC_AgbSupplierDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_supplieragb_supplieragbaddressline2_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_supplieragb_supplieragbaddressline2_Internalname, context.GetMessage( "Address Line 2", ""), "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_supplieragb_supplieragbaddressline2_Internalname, AV7Trn_SupplierAgb.gxTpr_Supplieragbaddressline2, StringUtil.RTrim( context.localUtil.Format( AV7Trn_SupplierAgb.gxTpr_Supplieragbaddressline2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_supplieragb_supplieragbaddressline2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_supplieragb_supplieragbaddressline2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WC_AgbSupplierDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_supplieragb_supplieragbaddresszipcode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_supplieragb_supplieragbaddresszipcode_Internalname, context.GetMessage( "Zip Code", ""), "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_supplieragb_supplieragbaddresszipcode_Internalname, AV7Trn_SupplierAgb.gxTpr_Supplieragbaddresszipcode, StringUtil.RTrim( context.localUtil.Format( AV7Trn_SupplierAgb.gxTpr_Supplieragbaddresszipcode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_supplieragb_supplieragbaddresszipcode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_supplieragb_supplieragbaddresszipcode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WC_AgbSupplierDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_supplieragb_supplieragbaddresscity_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_supplieragb_supplieragbaddresscity_Internalname, context.GetMessage( "City", ""), "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_supplieragb_supplieragbaddresscity_Internalname, AV7Trn_SupplierAgb.gxTpr_Supplieragbaddresscity, StringUtil.RTrim( context.localUtil.Format( AV7Trn_SupplierAgb.gxTpr_Supplieragbaddresscity, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_supplieragb_supplieragbaddresscity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_supplieragb_supplieragbaddresscity_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WC_AgbSupplierDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_supplieragb_supplieragbaddresscountry_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_supplieragb_supplieragbaddresscountry_Internalname, context.GetMessage( "Country", ""), "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_supplieragb_supplieragbaddresscountry_Internalname, AV7Trn_SupplierAgb.gxTpr_Supplieragbaddresscountry, StringUtil.RTrim( context.localUtil.Format( AV7Trn_SupplierAgb.gxTpr_Supplieragbaddresscountry, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_supplieragb_supplieragbaddresscountry_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_supplieragb_supplieragbaddresscountry_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WC_AgbSupplierDetails.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_supplieragb_supplieragbid_Internalname, AV7Trn_SupplierAgb.gxTpr_Supplieragbid.ToString(), AV7Trn_SupplierAgb.gxTpr_Supplieragbid.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_supplieragb_supplieragbid_Jsonclick, 0, "Attribute", "", "", "", "", edtavTrn_supplieragb_supplieragbid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, false, "", "", false, "", "HLP_WC_AgbSupplierDetails.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_supplieragb_supplieragbtypeid_Internalname, AV7Trn_SupplierAgb.gxTpr_Supplieragbtypeid.ToString(), AV7Trn_SupplierAgb.gxTpr_Supplieragbtypeid.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_supplieragb_supplieragbtypeid_Jsonclick, 0, "Attribute", "", "", "", "", edtavTrn_supplieragb_supplieragbtypeid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, false, "", "", false, "", "HLP_WC_AgbSupplierDetails.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_supplieragb_supplieragbphonecode_Internalname, AV7Trn_SupplierAgb.gxTpr_Supplieragbphonecode, StringUtil.RTrim( context.localUtil.Format( AV7Trn_SupplierAgb.gxTpr_Supplieragbphonecode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_supplieragb_supplieragbphonecode_Jsonclick, 0, "Attribute", "", "", "", "", edtavTrn_supplieragb_supplieragbphonecode_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WC_AgbSupplierDetails.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_supplieragb_supplieragbphonenumber_Internalname, AV7Trn_SupplierAgb.gxTpr_Supplieragbphonenumber, StringUtil.RTrim( context.localUtil.Format( AV7Trn_SupplierAgb.gxTpr_Supplieragbphonenumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_supplieragb_supplieragbphonenumber_Jsonclick, 0, "Attribute", "", "", "", "", edtavTrn_supplieragb_supplieragbphonenumber_Visible, 1, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WC_AgbSupplierDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START6K2( )
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
            Form.Meta.addItem("description", context.GetMessage( "WC_Agb Supplier Details", ""), 0) ;
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
               STRUP6K0( ) ;
            }
         }
      }

      protected void WS6K2( )
      {
         START6K2( ) ;
         EVT6K2( ) ;
      }

      protected void EVT6K2( )
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
                                 STRUP6K0( ) ;
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
                                 STRUP6K0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E116K2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6K0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E126K2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6K0( ) ;
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
                                 STRUP6K0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavTrn_supplieragb_supplieragbname_Internalname;
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

      protected void WE6K2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm6K2( ) ;
            }
         }
      }

      protected void PA6K2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wc_agbsupplierdetails.aspx")), "wc_agbsupplierdetails.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wc_agbsupplierdetails.aspx")))) ;
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
               GX_FocusControl = edtavTrn_supplieragb_supplieragbname_Internalname;
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
         RF6K2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavTrn_supplieragb_supplieragbname_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbname_Enabled), 5, 0), true);
         edtavTrn_supplieragb_supplieragbkvknumber_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbkvknumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbkvknumber_Enabled), 5, 0), true);
         edtavTrn_supplieragb_supplieragbtypename_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbtypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbtypename_Enabled), 5, 0), true);
         edtavTrn_supplieragb_supplieragbcontactname_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbcontactname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbcontactname_Enabled), 5, 0), true);
         edtavTrn_supplieragb_supplieragbphone_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbphone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbphone_Enabled), 5, 0), true);
         edtavTrn_supplieragb_supplieragbemail_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbemail_Enabled), 5, 0), true);
         edtavTrn_supplieragb_supplieragbnumber_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbnumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbnumber_Enabled), 5, 0), true);
         edtavTrn_supplieragb_supplieragbaddressline1_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbaddressline1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbaddressline1_Enabled), 5, 0), true);
         edtavTrn_supplieragb_supplieragbaddressline2_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbaddressline2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbaddressline2_Enabled), 5, 0), true);
         edtavTrn_supplieragb_supplieragbaddresszipcode_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbaddresszipcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbaddresszipcode_Enabled), 5, 0), true);
         edtavTrn_supplieragb_supplieragbaddresscity_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbaddresscity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbaddresscity_Enabled), 5, 0), true);
         edtavTrn_supplieragb_supplieragbaddresscountry_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbaddresscountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbaddresscountry_Enabled), 5, 0), true);
      }

      protected void RF6K2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E126K2 ();
            WB6K0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes6K2( )
      {
      }

      protected void before_start_formulas( )
      {
         edtavTrn_supplieragb_supplieragbname_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbname_Enabled), 5, 0), true);
         edtavTrn_supplieragb_supplieragbkvknumber_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbkvknumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbkvknumber_Enabled), 5, 0), true);
         edtavTrn_supplieragb_supplieragbtypename_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbtypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbtypename_Enabled), 5, 0), true);
         edtavTrn_supplieragb_supplieragbcontactname_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbcontactname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbcontactname_Enabled), 5, 0), true);
         edtavTrn_supplieragb_supplieragbphone_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbphone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbphone_Enabled), 5, 0), true);
         edtavTrn_supplieragb_supplieragbemail_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbemail_Enabled), 5, 0), true);
         edtavTrn_supplieragb_supplieragbnumber_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbnumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbnumber_Enabled), 5, 0), true);
         edtavTrn_supplieragb_supplieragbaddressline1_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbaddressline1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbaddressline1_Enabled), 5, 0), true);
         edtavTrn_supplieragb_supplieragbaddressline2_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbaddressline2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbaddressline2_Enabled), 5, 0), true);
         edtavTrn_supplieragb_supplieragbaddresszipcode_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbaddresszipcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbaddresszipcode_Enabled), 5, 0), true);
         edtavTrn_supplieragb_supplieragbaddresscity_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbaddresscity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbaddresscity_Enabled), 5, 0), true);
         edtavTrn_supplieragb_supplieragbaddresscountry_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbaddresscountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbaddresscountry_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP6K0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E116K2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vTRN_SUPPLIERAGB"), AV7Trn_SupplierAgb);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Trn_supplieragb"), AV7Trn_SupplierAgb);
            /* Read saved values. */
            wcpOAV10TrnMode = cgiGet( sPrefix+"wcpOAV10TrnMode");
            wcpOAV14SupplierAgbId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV14SupplierAgbId"));
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
         E116K2 ();
         if (returnInSub) return;
      }

      protected void E116K2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp(sPrefix, false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         AV11LoadSuccess = true;
         if ( StringUtil.StrCmp(AV10TrnMode, "DSP") == 0 )
         {
            AV7Trn_SupplierAgb.Load(AV14SupplierAgbId);
            AV11LoadSuccess = AV7Trn_SupplierAgb.Success();
            if ( ! AV11LoadSuccess )
            {
               AV9Messages = AV7Trn_SupplierAgb.GetMessages();
               /* Execute user subroutine: 'SHOW MESSAGES' */
               S112 ();
               if (returnInSub) return;
            }
         }
         else
         {
            AV11LoadSuccess = false;
            CallWebObject(formatLink("wp_notauthorized.aspx") );
            context.wjLocDisableFrm = 1;
         }
         edtavTrn_supplieragb_supplieragbid_Visible = 0;
         AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbid_Visible), 5, 0), true);
         edtavTrn_supplieragb_supplieragbtypeid_Visible = 0;
         AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbtypeid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbtypeid_Visible), 5, 0), true);
         edtavTrn_supplieragb_supplieragbphonecode_Visible = 0;
         AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbphonecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbphonecode_Visible), 5, 0), true);
         edtavTrn_supplieragb_supplieragbphonenumber_Visible = 0;
         AssignProp(sPrefix, false, edtavTrn_supplieragb_supplieragbphonenumber_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTrn_supplieragb_supplieragbphonenumber_Visible), 5, 0), true);
      }

      protected void S112( )
      {
         /* 'SHOW MESSAGES' Routine */
         returnInSub = false;
         AV31GXV17 = 1;
         while ( AV31GXV17 <= AV9Messages.Count )
         {
            AV8Message = ((GeneXus.Utils.SdtMessages_Message)AV9Messages.Item(AV31GXV17));
            GX_msglist.addItem(AV8Message.gxTpr_Description);
            AV31GXV17 = (int)(AV31GXV17+1);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E126K2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV10TrnMode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV10TrnMode", AV10TrnMode);
         AV14SupplierAgbId = (Guid)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV14SupplierAgbId", AV14SupplierAgbId.ToString());
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
         PA6K2( ) ;
         WS6K2( ) ;
         WE6K2( ) ;
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
         sCtrlAV10TrnMode = (string)((string)getParm(obj,0));
         sCtrlAV14SupplierAgbId = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA6K2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wc_agbsupplierdetails", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA6K2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV10TrnMode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV10TrnMode", AV10TrnMode);
            AV14SupplierAgbId = (Guid)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV14SupplierAgbId", AV14SupplierAgbId.ToString());
         }
         wcpOAV10TrnMode = cgiGet( sPrefix+"wcpOAV10TrnMode");
         wcpOAV14SupplierAgbId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV14SupplierAgbId"));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV10TrnMode, wcpOAV10TrnMode) != 0 ) || ( AV14SupplierAgbId != wcpOAV14SupplierAgbId ) ) )
         {
            setjustcreated();
         }
         wcpOAV10TrnMode = AV10TrnMode;
         wcpOAV14SupplierAgbId = AV14SupplierAgbId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV10TrnMode = cgiGet( sPrefix+"AV10TrnMode_CTRL");
         if ( StringUtil.Len( sCtrlAV10TrnMode) > 0 )
         {
            AV10TrnMode = cgiGet( sCtrlAV10TrnMode);
            AssignAttri(sPrefix, false, "AV10TrnMode", AV10TrnMode);
         }
         else
         {
            AV10TrnMode = cgiGet( sPrefix+"AV10TrnMode_PARM");
         }
         sCtrlAV14SupplierAgbId = cgiGet( sPrefix+"AV14SupplierAgbId_CTRL");
         if ( StringUtil.Len( sCtrlAV14SupplierAgbId) > 0 )
         {
            AV14SupplierAgbId = StringUtil.StrToGuid( cgiGet( sCtrlAV14SupplierAgbId));
            AssignAttri(sPrefix, false, "AV14SupplierAgbId", AV14SupplierAgbId.ToString());
         }
         else
         {
            AV14SupplierAgbId = StringUtil.StrToGuid( cgiGet( sPrefix+"AV14SupplierAgbId_PARM"));
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
         PA6K2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS6K2( ) ;
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
         WS6K2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV10TrnMode_PARM", StringUtil.RTrim( AV10TrnMode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV10TrnMode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV10TrnMode_CTRL", StringUtil.RTrim( sCtrlAV10TrnMode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV14SupplierAgbId_PARM", AV14SupplierAgbId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV14SupplierAgbId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV14SupplierAgbId_CTRL", StringUtil.RTrim( sCtrlAV14SupplierAgbId));
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
         WE6K2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202562313451033", true, true);
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
            context.AddJavascriptSource("wc_agbsupplierdetails.js", "?202562313451033", false, true);
         }
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavTrn_supplieragb_supplieragbname_Internalname = sPrefix+"TRN_SUPPLIERAGB_SUPPLIERAGBNAME";
         edtavTrn_supplieragb_supplieragbkvknumber_Internalname = sPrefix+"TRN_SUPPLIERAGB_SUPPLIERAGBKVKNUMBER";
         edtavTrn_supplieragb_supplieragbtypename_Internalname = sPrefix+"TRN_SUPPLIERAGB_SUPPLIERAGBTYPENAME";
         edtavTrn_supplieragb_supplieragbcontactname_Internalname = sPrefix+"TRN_SUPPLIERAGB_SUPPLIERAGBCONTACTNAME";
         edtavTrn_supplieragb_supplieragbphone_Internalname = sPrefix+"TRN_SUPPLIERAGB_SUPPLIERAGBPHONE";
         edtavTrn_supplieragb_supplieragbemail_Internalname = sPrefix+"TRN_SUPPLIERAGB_SUPPLIERAGBEMAIL";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         edtavTrn_supplieragb_supplieragbnumber_Internalname = sPrefix+"TRN_SUPPLIERAGB_SUPPLIERAGBNUMBER";
         edtavTrn_supplieragb_supplieragbaddressline1_Internalname = sPrefix+"TRN_SUPPLIERAGB_SUPPLIERAGBADDRESSLINE1";
         edtavTrn_supplieragb_supplieragbaddressline2_Internalname = sPrefix+"TRN_SUPPLIERAGB_SUPPLIERAGBADDRESSLINE2";
         edtavTrn_supplieragb_supplieragbaddresszipcode_Internalname = sPrefix+"TRN_SUPPLIERAGB_SUPPLIERAGBADDRESSZIPCODE";
         edtavTrn_supplieragb_supplieragbaddresscity_Internalname = sPrefix+"TRN_SUPPLIERAGB_SUPPLIERAGBADDRESSCITY";
         edtavTrn_supplieragb_supplieragbaddresscountry_Internalname = sPrefix+"TRN_SUPPLIERAGB_SUPPLIERAGBADDRESSCOUNTRY";
         divTableattributes2_Internalname = sPrefix+"TABLEATTRIBUTES2";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavTrn_supplieragb_supplieragbid_Internalname = sPrefix+"TRN_SUPPLIERAGB_SUPPLIERAGBID";
         edtavTrn_supplieragb_supplieragbtypeid_Internalname = sPrefix+"TRN_SUPPLIERAGB_SUPPLIERAGBTYPEID";
         edtavTrn_supplieragb_supplieragbphonecode_Internalname = sPrefix+"TRN_SUPPLIERAGB_SUPPLIERAGBPHONECODE";
         edtavTrn_supplieragb_supplieragbphonenumber_Internalname = sPrefix+"TRN_SUPPLIERAGB_SUPPLIERAGBPHONENUMBER";
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
         edtavTrn_supplieragb_supplieragbphonenumber_Jsonclick = "";
         edtavTrn_supplieragb_supplieragbphonenumber_Visible = 1;
         edtavTrn_supplieragb_supplieragbphonecode_Jsonclick = "";
         edtavTrn_supplieragb_supplieragbphonecode_Visible = 1;
         edtavTrn_supplieragb_supplieragbtypeid_Jsonclick = "";
         edtavTrn_supplieragb_supplieragbtypeid_Visible = 1;
         edtavTrn_supplieragb_supplieragbid_Jsonclick = "";
         edtavTrn_supplieragb_supplieragbid_Visible = 1;
         edtavTrn_supplieragb_supplieragbaddresscountry_Jsonclick = "";
         edtavTrn_supplieragb_supplieragbaddresscountry_Enabled = 0;
         edtavTrn_supplieragb_supplieragbaddresscity_Jsonclick = "";
         edtavTrn_supplieragb_supplieragbaddresscity_Enabled = 0;
         edtavTrn_supplieragb_supplieragbaddresszipcode_Jsonclick = "";
         edtavTrn_supplieragb_supplieragbaddresszipcode_Enabled = 0;
         edtavTrn_supplieragb_supplieragbaddressline2_Jsonclick = "";
         edtavTrn_supplieragb_supplieragbaddressline2_Enabled = 0;
         edtavTrn_supplieragb_supplieragbaddressline1_Jsonclick = "";
         edtavTrn_supplieragb_supplieragbaddressline1_Enabled = 0;
         edtavTrn_supplieragb_supplieragbnumber_Jsonclick = "";
         edtavTrn_supplieragb_supplieragbnumber_Enabled = 0;
         edtavTrn_supplieragb_supplieragbemail_Jsonclick = "";
         edtavTrn_supplieragb_supplieragbemail_Enabled = 0;
         edtavTrn_supplieragb_supplieragbphone_Jsonclick = "";
         edtavTrn_supplieragb_supplieragbphone_Enabled = 0;
         edtavTrn_supplieragb_supplieragbcontactname_Jsonclick = "";
         edtavTrn_supplieragb_supplieragbcontactname_Enabled = 0;
         edtavTrn_supplieragb_supplieragbtypename_Jsonclick = "";
         edtavTrn_supplieragb_supplieragbtypename_Enabled = 0;
         edtavTrn_supplieragb_supplieragbkvknumber_Jsonclick = "";
         edtavTrn_supplieragb_supplieragbkvknumber_Enabled = 0;
         edtavTrn_supplieragb_supplieragbname_Jsonclick = "";
         edtavTrn_supplieragb_supplieragbname_Enabled = 0;
         divLayoutmaintable_Class = "Table TableTransactionTemplate";
         edtavTrn_supplieragb_supplieragbaddresscountry_Enabled = -1;
         edtavTrn_supplieragb_supplieragbaddresscity_Enabled = -1;
         edtavTrn_supplieragb_supplieragbaddresszipcode_Enabled = -1;
         edtavTrn_supplieragb_supplieragbaddressline2_Enabled = -1;
         edtavTrn_supplieragb_supplieragbaddressline1_Enabled = -1;
         edtavTrn_supplieragb_supplieragbnumber_Enabled = -1;
         edtavTrn_supplieragb_supplieragbemail_Enabled = -1;
         edtavTrn_supplieragb_supplieragbphone_Enabled = -1;
         edtavTrn_supplieragb_supplieragbcontactname_Enabled = -1;
         edtavTrn_supplieragb_supplieragbtypename_Enabled = -1;
         edtavTrn_supplieragb_supplieragbkvknumber_Enabled = -1;
         edtavTrn_supplieragb_supplieragbname_Enabled = -1;
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
         setEventMetadata("VALIDV_GXV6","""{"handler":"Validv_Gxv6","iparms":[]}""");
         setEventMetadata("VALIDV_GXV13","""{"handler":"Validv_Gxv13","iparms":[]}""");
         setEventMetadata("VALIDV_GXV14","""{"handler":"Validv_Gxv14","iparms":[]}""");
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
         wcpOAV10TrnMode = "";
         wcpOAV14SupplierAgbId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV7Trn_SupplierAgb = new SdtTrn_SupplierAgb(context);
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
         AV9Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV8Message = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV10TrnMode = "";
         sCtrlAV14SupplierAgbId = "";
         /* GeneXus formulas. */
         edtavTrn_supplieragb_supplieragbname_Enabled = 0;
         edtavTrn_supplieragb_supplieragbkvknumber_Enabled = 0;
         edtavTrn_supplieragb_supplieragbtypename_Enabled = 0;
         edtavTrn_supplieragb_supplieragbcontactname_Enabled = 0;
         edtavTrn_supplieragb_supplieragbphone_Enabled = 0;
         edtavTrn_supplieragb_supplieragbemail_Enabled = 0;
         edtavTrn_supplieragb_supplieragbnumber_Enabled = 0;
         edtavTrn_supplieragb_supplieragbaddressline1_Enabled = 0;
         edtavTrn_supplieragb_supplieragbaddressline2_Enabled = 0;
         edtavTrn_supplieragb_supplieragbaddresszipcode_Enabled = 0;
         edtavTrn_supplieragb_supplieragbaddresscity_Enabled = 0;
         edtavTrn_supplieragb_supplieragbaddresscountry_Enabled = 0;
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
      private int edtavTrn_supplieragb_supplieragbname_Enabled ;
      private int edtavTrn_supplieragb_supplieragbkvknumber_Enabled ;
      private int edtavTrn_supplieragb_supplieragbtypename_Enabled ;
      private int edtavTrn_supplieragb_supplieragbcontactname_Enabled ;
      private int edtavTrn_supplieragb_supplieragbphone_Enabled ;
      private int edtavTrn_supplieragb_supplieragbemail_Enabled ;
      private int edtavTrn_supplieragb_supplieragbnumber_Enabled ;
      private int edtavTrn_supplieragb_supplieragbaddressline1_Enabled ;
      private int edtavTrn_supplieragb_supplieragbaddressline2_Enabled ;
      private int edtavTrn_supplieragb_supplieragbaddresszipcode_Enabled ;
      private int edtavTrn_supplieragb_supplieragbaddresscity_Enabled ;
      private int edtavTrn_supplieragb_supplieragbaddresscountry_Enabled ;
      private int edtavTrn_supplieragb_supplieragbid_Visible ;
      private int edtavTrn_supplieragb_supplieragbtypeid_Visible ;
      private int edtavTrn_supplieragb_supplieragbphonecode_Visible ;
      private int edtavTrn_supplieragb_supplieragbphonenumber_Visible ;
      private int AV31GXV17 ;
      private int idxLst ;
      private string AV10TrnMode ;
      private string wcpOAV10TrnMode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string edtavTrn_supplieragb_supplieragbname_Internalname ;
      private string edtavTrn_supplieragb_supplieragbkvknumber_Internalname ;
      private string edtavTrn_supplieragb_supplieragbtypename_Internalname ;
      private string edtavTrn_supplieragb_supplieragbcontactname_Internalname ;
      private string edtavTrn_supplieragb_supplieragbphone_Internalname ;
      private string edtavTrn_supplieragb_supplieragbemail_Internalname ;
      private string edtavTrn_supplieragb_supplieragbnumber_Internalname ;
      private string edtavTrn_supplieragb_supplieragbaddressline1_Internalname ;
      private string edtavTrn_supplieragb_supplieragbaddressline2_Internalname ;
      private string edtavTrn_supplieragb_supplieragbaddresszipcode_Internalname ;
      private string edtavTrn_supplieragb_supplieragbaddresscity_Internalname ;
      private string edtavTrn_supplieragb_supplieragbaddresscountry_Internalname ;
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
      private string edtavTrn_supplieragb_supplieragbname_Jsonclick ;
      private string edtavTrn_supplieragb_supplieragbkvknumber_Jsonclick ;
      private string edtavTrn_supplieragb_supplieragbtypename_Jsonclick ;
      private string edtavTrn_supplieragb_supplieragbcontactname_Jsonclick ;
      private string edtavTrn_supplieragb_supplieragbphone_Jsonclick ;
      private string edtavTrn_supplieragb_supplieragbemail_Jsonclick ;
      private string divTableattributes2_Internalname ;
      private string edtavTrn_supplieragb_supplieragbnumber_Jsonclick ;
      private string edtavTrn_supplieragb_supplieragbaddressline1_Jsonclick ;
      private string edtavTrn_supplieragb_supplieragbaddressline2_Jsonclick ;
      private string edtavTrn_supplieragb_supplieragbaddresszipcode_Jsonclick ;
      private string edtavTrn_supplieragb_supplieragbaddresscity_Jsonclick ;
      private string edtavTrn_supplieragb_supplieragbaddresscountry_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavTrn_supplieragb_supplieragbid_Internalname ;
      private string edtavTrn_supplieragb_supplieragbid_Jsonclick ;
      private string edtavTrn_supplieragb_supplieragbtypeid_Internalname ;
      private string edtavTrn_supplieragb_supplieragbtypeid_Jsonclick ;
      private string edtavTrn_supplieragb_supplieragbphonecode_Internalname ;
      private string edtavTrn_supplieragb_supplieragbphonecode_Jsonclick ;
      private string edtavTrn_supplieragb_supplieragbphonenumber_Internalname ;
      private string edtavTrn_supplieragb_supplieragbphonenumber_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string sCtrlAV10TrnMode ;
      private string sCtrlAV14SupplierAgbId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV11LoadSuccess ;
      private Guid AV14SupplierAgbId ;
      private Guid wcpOAV14SupplierAgbId ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtTrn_SupplierAgb AV7Trn_SupplierAgb ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV9Messages ;
      private GeneXus.Utils.SdtMessages_Message AV8Message ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
