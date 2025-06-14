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
   public class trn_pagegeneral : GXWebComponent
   {
      public trn_pagegeneral( )
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

      public trn_pagegeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_Trn_PageId ,
                           Guid aP1_LocationId )
      {
         this.A392Trn_PageId = aP0_Trn_PageId;
         this.A29LocationId = aP1_LocationId;
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
         chkPageIsPublished = new GXCheckbox();
         cmbPageIsContentPage = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "Trn_PageId");
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
                  A392Trn_PageId = StringUtil.StrToGuid( GetPar( "Trn_PageId"));
                  AssignAttri(sPrefix, false, "A392Trn_PageId", A392Trn_PageId.ToString());
                  A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
                  AssignAttri(sPrefix, false, "A29LocationId", A29LocationId.ToString());
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(Guid)A392Trn_PageId,(Guid)A29LocationId});
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
                  gxfirstwebparm = GetFirstPar( "Trn_PageId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "Trn_PageId");
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
            PA792( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV15Pgmname = "Trn_PageGeneral";
               WS792( ) ;
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
            context.SendWebValue( context.GetMessage( "Trn_Page General", "")) ;
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
            GXEncryptionTmp = "trn_pagegeneral.aspx"+UrlEncode(A392Trn_PageId.ToString()) + "," + UrlEncode(A29LocationId.ToString());
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_pagegeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA392Trn_PageId", wcpOA392Trn_PageId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA29LocationId", wcpOA29LocationId.ToString());
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"LOCATIONID", A29LocationId.ToString());
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
      }

      protected void RenderHtmlCloseForm792( )
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
         return "Trn_PageGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Page General", "") ;
      }

      protected void WB790( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "trn_pagegeneral.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTrn_PageId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtTrn_PageId_Internalname, context.GetMessage( "Id", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtTrn_PageId_Internalname, A392Trn_PageId.ToString(), A392Trn_PageId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,14);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrn_PageId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrn_PageId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_PageGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTrn_PageName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtTrn_PageName_Internalname, context.GetMessage( "Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtTrn_PageName_Internalname, A397Trn_PageName, StringUtil.RTrim( context.localUtil.Format( A397Trn_PageName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,19);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrn_PageName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrn_PageName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_PageGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtLocationName_Internalname, context.GetMessage( "Location", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtLocationName_Internalname, A31LocationName, StringUtil.RTrim( context.localUtil.Format( A31LocationName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtLocationName_Link, "", "", "", edtLocationName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_PageGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPageJsonContent_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPageJsonContent_Internalname, context.GetMessage( "Json Content", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtPageJsonContent_Internalname, A420PageJsonContent, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", 0, 1, edtPageJsonContent_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_PageGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPageGJSHtml_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPageGJSHtml_Internalname, context.GetMessage( "GJSHtml", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtPageGJSHtml_Internalname, A421PageGJSHtml, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", 1, 1, edtPageGJSHtml_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "GeneXus\\Html", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_PageGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPageGJSJson_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPageGJSJson_Internalname, context.GetMessage( "GJSJson", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtPageGJSJson_Internalname, A422PageGJSJson, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", 0, 1, edtPageGJSJson_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_PageGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkPageIsPublished_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkPageIsPublished_Internalname, context.GetMessage( "Is Published", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkPageIsPublished_Internalname, StringUtil.BoolToStr( A423PageIsPublished), "", context.GetMessage( "Is Published", ""), 1, chkPageIsPublished.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(44, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,44);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbPageIsContentPage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbPageIsContentPage_Internalname, context.GetMessage( "Content Page", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbPageIsContentPage, cmbPageIsContentPage_Internalname, StringUtil.BoolToStr( A429PageIsContentPage), 1, cmbPageIsContentPage_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbPageIsContentPage.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_Trn_PageGeneral.htm");
            cmbPageIsContentPage.CurrentValue = StringUtil.BoolToStr( A429PageIsContentPage);
            AssignProp(sPrefix, false, cmbPageIsContentPage_Internalname, "Values", (string)(cmbPageIsContentPage.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPageChildren_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPageChildren_Internalname, context.GetMessage( "Children", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtPageChildren_Internalname, A424PageChildren, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", 0, 1, edtPageChildren_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_PageGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductServiceName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProductServiceName_Internalname, context.GetMessage( "Trn_Product Service", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProductServiceName_Internalname, A59ProductServiceName, StringUtil.RTrim( context.localUtil.Format( A59ProductServiceName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtProductServiceName_Link, "", "", "", edtProductServiceName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductServiceName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_PageGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOrganisationName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtOrganisationName_Internalname, context.GetMessage( "Organisations", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtOrganisationName_Internalname, A13OrganisationName, StringUtil.RTrim( context.localUtil.Format( A13OrganisationName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtOrganisationName_Link, "", "", "", edtOrganisationName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrganisationName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_PageGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", context.GetMessage( "Edit", ""), bttBtnupdate_Jsonclick, 5, context.GetMessage( "Edit", ""), "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_PageGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtndelete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODELETE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_PageGeneral.htm");
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

      protected void START792( )
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
            Form.Meta.addItem("description", context.GetMessage( "Trn_Page General", ""), 0) ;
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
               STRUP790( ) ;
            }
         }
      }

      protected void WS792( )
      {
         START792( ) ;
         EVT792( ) ;
      }

      protected void EVT792( )
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
                                 STRUP790( ) ;
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
                                 STRUP790( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11792 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP790( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E12792 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP790( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdate' */
                                    E13792 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP790( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDelete' */
                                    E14792 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP790( ) ;
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
                                 STRUP790( ) ;
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE792( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm792( ) ;
            }
         }
      }

      protected void PA792( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_pagegeneral.aspx")), "trn_pagegeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_pagegeneral.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "Trn_PageId");
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
         A423PageIsPublished = StringUtil.StrToBool( StringUtil.BoolToStr( A423PageIsPublished));
         n423PageIsPublished = false;
         AssignAttri(sPrefix, false, "A423PageIsPublished", A423PageIsPublished);
         if ( cmbPageIsContentPage.ItemCount > 0 )
         {
            A429PageIsContentPage = StringUtil.StrToBool( cmbPageIsContentPage.getValidValue(StringUtil.BoolToStr( A429PageIsContentPage)));
            n429PageIsContentPage = false;
            AssignAttri(sPrefix, false, "A429PageIsContentPage", A429PageIsContentPage);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPageIsContentPage.CurrentValue = StringUtil.BoolToStr( A429PageIsContentPage);
            AssignProp(sPrefix, false, cmbPageIsContentPage_Internalname, "Values", cmbPageIsContentPage.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF792( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV15Pgmname = "Trn_PageGeneral";
      }

      protected void RF792( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00792 */
            pr_default.execute(0, new Object[] {A392Trn_PageId, A29LocationId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A11OrganisationId = H00792_A11OrganisationId[0];
               A58ProductServiceId = H00792_A58ProductServiceId[0];
               n58ProductServiceId = H00792_n58ProductServiceId[0];
               A13OrganisationName = H00792_A13OrganisationName[0];
               AssignAttri(sPrefix, false, "A13OrganisationName", A13OrganisationName);
               A59ProductServiceName = H00792_A59ProductServiceName[0];
               AssignAttri(sPrefix, false, "A59ProductServiceName", A59ProductServiceName);
               A424PageChildren = H00792_A424PageChildren[0];
               n424PageChildren = H00792_n424PageChildren[0];
               AssignAttri(sPrefix, false, "A424PageChildren", A424PageChildren);
               A429PageIsContentPage = H00792_A429PageIsContentPage[0];
               n429PageIsContentPage = H00792_n429PageIsContentPage[0];
               AssignAttri(sPrefix, false, "A429PageIsContentPage", A429PageIsContentPage);
               A423PageIsPublished = H00792_A423PageIsPublished[0];
               n423PageIsPublished = H00792_n423PageIsPublished[0];
               AssignAttri(sPrefix, false, "A423PageIsPublished", A423PageIsPublished);
               A422PageGJSJson = H00792_A422PageGJSJson[0];
               n422PageGJSJson = H00792_n422PageGJSJson[0];
               AssignAttri(sPrefix, false, "A422PageGJSJson", A422PageGJSJson);
               A421PageGJSHtml = H00792_A421PageGJSHtml[0];
               n421PageGJSHtml = H00792_n421PageGJSHtml[0];
               AssignAttri(sPrefix, false, "A421PageGJSHtml", A421PageGJSHtml);
               A420PageJsonContent = H00792_A420PageJsonContent[0];
               n420PageJsonContent = H00792_n420PageJsonContent[0];
               AssignAttri(sPrefix, false, "A420PageJsonContent", A420PageJsonContent);
               A31LocationName = H00792_A31LocationName[0];
               AssignAttri(sPrefix, false, "A31LocationName", A31LocationName);
               A397Trn_PageName = H00792_A397Trn_PageName[0];
               AssignAttri(sPrefix, false, "A397Trn_PageName", A397Trn_PageName);
               A13OrganisationName = H00792_A13OrganisationName[0];
               AssignAttri(sPrefix, false, "A13OrganisationName", A13OrganisationName);
               A31LocationName = H00792_A31LocationName[0];
               AssignAttri(sPrefix, false, "A31LocationName", A31LocationName);
               A59ProductServiceName = H00792_A59ProductServiceName[0];
               AssignAttri(sPrefix, false, "A59ProductServiceName", A59ProductServiceName);
               /* Execute user event: Load */
               E12792 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB790( ) ;
         }
      }

      protected void send_integrity_lvl_hashes792( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
      }

      protected void before_start_formulas( )
      {
         AV15Pgmname = "Trn_PageGeneral";
         edtTrn_PageId_Enabled = 0;
         AssignProp(sPrefix, false, edtTrn_PageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_PageId_Enabled), 5, 0), true);
         edtTrn_PageName_Enabled = 0;
         AssignProp(sPrefix, false, edtTrn_PageName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_PageName_Enabled), 5, 0), true);
         edtLocationName_Enabled = 0;
         AssignProp(sPrefix, false, edtLocationName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationName_Enabled), 5, 0), true);
         edtPageJsonContent_Enabled = 0;
         AssignProp(sPrefix, false, edtPageJsonContent_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageJsonContent_Enabled), 5, 0), true);
         edtPageGJSHtml_Enabled = 0;
         AssignProp(sPrefix, false, edtPageGJSHtml_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageGJSHtml_Enabled), 5, 0), true);
         edtPageGJSJson_Enabled = 0;
         AssignProp(sPrefix, false, edtPageGJSJson_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageGJSJson_Enabled), 5, 0), true);
         chkPageIsPublished.Enabled = 0;
         AssignProp(sPrefix, false, chkPageIsPublished_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkPageIsPublished.Enabled), 5, 0), true);
         cmbPageIsContentPage.Enabled = 0;
         AssignProp(sPrefix, false, cmbPageIsContentPage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPageIsContentPage.Enabled), 5, 0), true);
         edtPageChildren_Enabled = 0;
         AssignProp(sPrefix, false, edtPageChildren_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageChildren_Enabled), 5, 0), true);
         edtProductServiceName_Enabled = 0;
         AssignProp(sPrefix, false, edtProductServiceName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceName_Enabled), 5, 0), true);
         edtOrganisationName_Enabled = 0;
         AssignProp(sPrefix, false, edtOrganisationName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationName_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP790( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11792 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA392Trn_PageId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA392Trn_PageId"));
            wcpOA29LocationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA29LocationId"));
            /* Read variables values. */
            A397Trn_PageName = cgiGet( edtTrn_PageName_Internalname);
            AssignAttri(sPrefix, false, "A397Trn_PageName", A397Trn_PageName);
            A31LocationName = cgiGet( edtLocationName_Internalname);
            AssignAttri(sPrefix, false, "A31LocationName", A31LocationName);
            A420PageJsonContent = cgiGet( edtPageJsonContent_Internalname);
            n420PageJsonContent = false;
            AssignAttri(sPrefix, false, "A420PageJsonContent", A420PageJsonContent);
            A421PageGJSHtml = cgiGet( edtPageGJSHtml_Internalname);
            n421PageGJSHtml = false;
            AssignAttri(sPrefix, false, "A421PageGJSHtml", A421PageGJSHtml);
            A422PageGJSJson = cgiGet( edtPageGJSJson_Internalname);
            n422PageGJSJson = false;
            AssignAttri(sPrefix, false, "A422PageGJSJson", A422PageGJSJson);
            A423PageIsPublished = StringUtil.StrToBool( cgiGet( chkPageIsPublished_Internalname));
            n423PageIsPublished = false;
            AssignAttri(sPrefix, false, "A423PageIsPublished", A423PageIsPublished);
            cmbPageIsContentPage.CurrentValue = cgiGet( cmbPageIsContentPage_Internalname);
            A429PageIsContentPage = StringUtil.StrToBool( cgiGet( cmbPageIsContentPage_Internalname));
            n429PageIsContentPage = false;
            AssignAttri(sPrefix, false, "A429PageIsContentPage", A429PageIsContentPage);
            A424PageChildren = cgiGet( edtPageChildren_Internalname);
            n424PageChildren = false;
            AssignAttri(sPrefix, false, "A424PageChildren", A424PageChildren);
            A59ProductServiceName = cgiGet( edtProductServiceName_Internalname);
            AssignAttri(sPrefix, false, "A59ProductServiceName", A59ProductServiceName);
            A13OrganisationName = cgiGet( edtOrganisationName_Internalname);
            AssignAttri(sPrefix, false, "A13OrganisationName", A13OrganisationName);
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
         E11792 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E11792( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
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

      protected void E12792( )
      {
         /* Load Routine */
         returnInSub = false;
         GXt_boolean1 = AV14TempBoolean;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_locationview_Execute", out  GXt_boolean1) ;
         AV14TempBoolean = GXt_boolean1;
         if ( AV14TempBoolean )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_locationview.aspx"+UrlEncode(A29LocationId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            edtLocationName_Link = formatLink("trn_locationview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AssignProp(sPrefix, false, edtLocationName_Internalname, "Link", edtLocationName_Link, true);
         }
         GXt_boolean1 = AV14TempBoolean;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_productserviceview_Execute", out  GXt_boolean1) ;
         AV14TempBoolean = GXt_boolean1;
         if ( AV14TempBoolean )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_productserviceview.aspx"+UrlEncode(A58ProductServiceId.ToString()) + "," + UrlEncode(A29LocationId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            edtProductServiceName_Link = formatLink("trn_productserviceview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AssignProp(sPrefix, false, edtProductServiceName_Internalname, "Link", edtProductServiceName_Link, true);
         }
         GXt_boolean1 = AV14TempBoolean;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_organisationview_Execute", out  GXt_boolean1) ;
         AV14TempBoolean = GXt_boolean1;
         if ( AV14TempBoolean )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_organisationview.aspx"+UrlEncode(A11OrganisationId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            edtOrganisationName_Link = formatLink("trn_organisationview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AssignProp(sPrefix, false, edtOrganisationName_Internalname, "Link", edtOrganisationName_Link, true);
         }
         GXt_boolean1 = AV12IsAuthorized_Update;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_page_Update", out  GXt_boolean1) ;
         AV12IsAuthorized_Update = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV12IsAuthorized_Update", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         if ( ! ( AV12IsAuthorized_Update ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV13IsAuthorized_Delete;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_page_Delete", out  GXt_boolean1) ;
         AV13IsAuthorized_Delete = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV13IsAuthorized_Delete", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
         if ( ! ( AV13IsAuthorized_Delete ) )
         {
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
      }

      protected void E13792( )
      {
         /* 'DoUpdate' Routine */
         returnInSub = false;
         if ( AV12IsAuthorized_Update )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_page.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(A392Trn_PageId.ToString()) + "," + UrlEncode(A29LocationId.ToString());
            CallWebObject(formatLink("trn_page.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
      }

      protected void E14792( )
      {
         /* 'DoDelete' Routine */
         returnInSub = false;
         if ( AV13IsAuthorized_Delete )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_page.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(A392Trn_PageId.ToString()) + "," + UrlEncode(A29LocationId.ToString());
            CallWebObject(formatLink("trn_page.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV15Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Trn_Page";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A392Trn_PageId = (Guid)getParm(obj,0);
         AssignAttri(sPrefix, false, "A392Trn_PageId", A392Trn_PageId.ToString());
         A29LocationId = (Guid)getParm(obj,1);
         AssignAttri(sPrefix, false, "A29LocationId", A29LocationId.ToString());
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
         PA792( ) ;
         WS792( ) ;
         WE792( ) ;
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
         sCtrlA392Trn_PageId = (string)((string)getParm(obj,0));
         sCtrlA29LocationId = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA792( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "trn_pagegeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA792( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A392Trn_PageId = (Guid)getParm(obj,2);
            AssignAttri(sPrefix, false, "A392Trn_PageId", A392Trn_PageId.ToString());
            A29LocationId = (Guid)getParm(obj,3);
            AssignAttri(sPrefix, false, "A29LocationId", A29LocationId.ToString());
         }
         wcpOA392Trn_PageId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA392Trn_PageId"));
         wcpOA29LocationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA29LocationId"));
         if ( ! GetJustCreated( ) && ( ( A392Trn_PageId != wcpOA392Trn_PageId ) || ( A29LocationId != wcpOA29LocationId ) ) )
         {
            setjustcreated();
         }
         wcpOA392Trn_PageId = A392Trn_PageId;
         wcpOA29LocationId = A29LocationId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA392Trn_PageId = cgiGet( sPrefix+"A392Trn_PageId_CTRL");
         if ( StringUtil.Len( sCtrlA392Trn_PageId) > 0 )
         {
            A392Trn_PageId = StringUtil.StrToGuid( cgiGet( sCtrlA392Trn_PageId));
            AssignAttri(sPrefix, false, "A392Trn_PageId", A392Trn_PageId.ToString());
         }
         else
         {
            A392Trn_PageId = StringUtil.StrToGuid( cgiGet( sPrefix+"A392Trn_PageId_PARM"));
         }
         sCtrlA29LocationId = cgiGet( sPrefix+"A29LocationId_CTRL");
         if ( StringUtil.Len( sCtrlA29LocationId) > 0 )
         {
            A29LocationId = StringUtil.StrToGuid( cgiGet( sCtrlA29LocationId));
            AssignAttri(sPrefix, false, "A29LocationId", A29LocationId.ToString());
         }
         else
         {
            A29LocationId = StringUtil.StrToGuid( cgiGet( sPrefix+"A29LocationId_PARM"));
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
         PA792( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS792( ) ;
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
         WS792( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A392Trn_PageId_PARM", A392Trn_PageId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA392Trn_PageId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A392Trn_PageId_CTRL", StringUtil.RTrim( sCtrlA392Trn_PageId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"A29LocationId_PARM", A29LocationId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA29LocationId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A29LocationId_CTRL", StringUtil.RTrim( sCtrlA29LocationId));
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
         WE792( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256145353535", true, true);
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
         context.AddJavascriptSource("trn_pagegeneral.js", "?20256145353536", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         chkPageIsPublished.Name = "PAGEISPUBLISHED";
         chkPageIsPublished.WebTags = "";
         chkPageIsPublished.Caption = context.GetMessage( "Is Published", "");
         AssignProp(sPrefix, false, chkPageIsPublished_Internalname, "TitleCaption", chkPageIsPublished.Caption, true);
         chkPageIsPublished.CheckedValue = "false";
         cmbPageIsContentPage.Name = "PAGEISCONTENTPAGE";
         cmbPageIsContentPage.WebTags = "";
         cmbPageIsContentPage.addItem(StringUtil.BoolToStr( true), context.GetMessage( "true", ""), 0);
         cmbPageIsContentPage.addItem(StringUtil.BoolToStr( false), context.GetMessage( "false", ""), 0);
         if ( cmbPageIsContentPage.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtTrn_PageId_Internalname = sPrefix+"TRN_PAGEID";
         edtTrn_PageName_Internalname = sPrefix+"TRN_PAGENAME";
         edtLocationName_Internalname = sPrefix+"LOCATIONNAME";
         edtPageJsonContent_Internalname = sPrefix+"PAGEJSONCONTENT";
         edtPageGJSHtml_Internalname = sPrefix+"PAGEGJSHTML";
         edtPageGJSJson_Internalname = sPrefix+"PAGEGJSJSON";
         chkPageIsPublished_Internalname = sPrefix+"PAGEISPUBLISHED";
         cmbPageIsContentPage_Internalname = sPrefix+"PAGEISCONTENTPAGE";
         edtPageChildren_Internalname = sPrefix+"PAGECHILDREN";
         edtProductServiceName_Internalname = sPrefix+"PRODUCTSERVICENAME";
         edtOrganisationName_Internalname = sPrefix+"ORGANISATIONNAME";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         divTable_Internalname = sPrefix+"TABLE";
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
         chkPageIsPublished.Caption = context.GetMessage( "Is Published", "");
         bttBtndelete_Visible = 1;
         bttBtnupdate_Visible = 1;
         edtOrganisationName_Jsonclick = "";
         edtOrganisationName_Link = "";
         edtOrganisationName_Enabled = 0;
         edtProductServiceName_Jsonclick = "";
         edtProductServiceName_Link = "";
         edtProductServiceName_Enabled = 0;
         edtPageChildren_Enabled = 0;
         cmbPageIsContentPage_Jsonclick = "";
         cmbPageIsContentPage.Enabled = 0;
         chkPageIsPublished.Enabled = 0;
         edtPageGJSJson_Enabled = 0;
         edtPageGJSHtml_Enabled = 0;
         edtPageJsonContent_Enabled = 0;
         edtLocationName_Jsonclick = "";
         edtLocationName_Link = "";
         edtLocationName_Enabled = 0;
         edtTrn_PageName_Jsonclick = "";
         edtTrn_PageName_Enabled = 0;
         edtTrn_PageId_Jsonclick = "";
         edtTrn_PageId_Enabled = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A392Trn_PageId","fld":"TRN_PAGEID"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A423PageIsPublished","fld":"PAGEISPUBLISHED"},{"av":"AV12IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV13IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true}]}""");
         setEventMetadata("'DOUPDATE'","""{"handler":"E13792","iparms":[{"av":"AV12IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"A392Trn_PageId","fld":"TRN_PAGEID"},{"av":"A29LocationId","fld":"LOCATIONID"}]""");
         setEventMetadata("'DOUPDATE'",""","oparms":[{"ctrl":"BTNUPDATE","prop":"Visible"}]}""");
         setEventMetadata("'DODELETE'","""{"handler":"E14792","iparms":[{"av":"AV13IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"A392Trn_PageId","fld":"TRN_PAGEID"},{"av":"A29LocationId","fld":"LOCATIONID"}]""");
         setEventMetadata("'DODELETE'",""","oparms":[{"ctrl":"BTNDELETE","prop":"Visible"}]}""");
         setEventMetadata("VALID_TRN_PAGEID","""{"handler":"Valid_Trn_pageid","iparms":[]}""");
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
         wcpOA392Trn_PageId = Guid.Empty;
         wcpOA29LocationId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV15Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         TempTags = "";
         A397Trn_PageName = "";
         A31LocationName = "";
         ClassString = "";
         StyleString = "";
         A420PageJsonContent = "";
         A421PageGJSHtml = "";
         A422PageGJSJson = "";
         A424PageChildren = "";
         A59ProductServiceName = "";
         A13OrganisationName = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H00792_A392Trn_PageId = new Guid[] {Guid.Empty} ;
         H00792_A29LocationId = new Guid[] {Guid.Empty} ;
         H00792_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00792_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         H00792_n58ProductServiceId = new bool[] {false} ;
         H00792_A13OrganisationName = new string[] {""} ;
         H00792_A59ProductServiceName = new string[] {""} ;
         H00792_A424PageChildren = new string[] {""} ;
         H00792_n424PageChildren = new bool[] {false} ;
         H00792_A429PageIsContentPage = new bool[] {false} ;
         H00792_n429PageIsContentPage = new bool[] {false} ;
         H00792_A423PageIsPublished = new bool[] {false} ;
         H00792_n423PageIsPublished = new bool[] {false} ;
         H00792_A422PageGJSJson = new string[] {""} ;
         H00792_n422PageGJSJson = new bool[] {false} ;
         H00792_A421PageGJSHtml = new string[] {""} ;
         H00792_n421PageGJSHtml = new bool[] {false} ;
         H00792_A420PageJsonContent = new string[] {""} ;
         H00792_n420PageJsonContent = new bool[] {false} ;
         H00792_A31LocationName = new string[] {""} ;
         H00792_A397Trn_PageName = new string[] {""} ;
         A11OrganisationId = Guid.Empty;
         A58ProductServiceId = Guid.Empty;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA392Trn_PageId = "";
         sCtrlA29LocationId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_pagegeneral__default(),
            new Object[][] {
                new Object[] {
               H00792_A392Trn_PageId, H00792_A29LocationId, H00792_A11OrganisationId, H00792_A58ProductServiceId, H00792_n58ProductServiceId, H00792_A13OrganisationName, H00792_A59ProductServiceName, H00792_A424PageChildren, H00792_n424PageChildren, H00792_A429PageIsContentPage,
               H00792_n429PageIsContentPage, H00792_A423PageIsPublished, H00792_n423PageIsPublished, H00792_A422PageGJSJson, H00792_n422PageGJSJson, H00792_A421PageGJSHtml, H00792_n421PageGJSHtml, H00792_A420PageJsonContent, H00792_n420PageJsonContent, H00792_A31LocationName,
               H00792_A397Trn_PageName
               }
            }
         );
         AV15Pgmname = "Trn_PageGeneral";
         /* GeneXus formulas. */
         AV15Pgmname = "Trn_PageGeneral";
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
      private int edtTrn_PageId_Enabled ;
      private int edtTrn_PageName_Enabled ;
      private int edtLocationName_Enabled ;
      private int edtPageJsonContent_Enabled ;
      private int edtPageGJSHtml_Enabled ;
      private int edtPageGJSJson_Enabled ;
      private int edtPageChildren_Enabled ;
      private int edtProductServiceName_Enabled ;
      private int edtOrganisationName_Enabled ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV15Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string edtTrn_PageId_Internalname ;
      private string TempTags ;
      private string edtTrn_PageId_Jsonclick ;
      private string edtTrn_PageName_Internalname ;
      private string edtTrn_PageName_Jsonclick ;
      private string edtLocationName_Internalname ;
      private string edtLocationName_Link ;
      private string edtLocationName_Jsonclick ;
      private string edtPageJsonContent_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string edtPageGJSHtml_Internalname ;
      private string edtPageGJSJson_Internalname ;
      private string chkPageIsPublished_Internalname ;
      private string cmbPageIsContentPage_Internalname ;
      private string cmbPageIsContentPage_Jsonclick ;
      private string edtPageChildren_Internalname ;
      private string edtProductServiceName_Internalname ;
      private string edtProductServiceName_Link ;
      private string edtProductServiceName_Jsonclick ;
      private string edtOrganisationName_Internalname ;
      private string edtOrganisationName_Link ;
      private string edtOrganisationName_Jsonclick ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string sCtrlA392Trn_PageId ;
      private string sCtrlA29LocationId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV12IsAuthorized_Update ;
      private bool AV13IsAuthorized_Delete ;
      private bool wbLoad ;
      private bool A423PageIsPublished ;
      private bool A429PageIsContentPage ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n423PageIsPublished ;
      private bool n429PageIsContentPage ;
      private bool gxdyncontrolsrefreshing ;
      private bool n58ProductServiceId ;
      private bool n424PageChildren ;
      private bool n422PageGJSJson ;
      private bool n421PageGJSHtml ;
      private bool n420PageJsonContent ;
      private bool returnInSub ;
      private bool AV14TempBoolean ;
      private bool GXt_boolean1 ;
      private string A420PageJsonContent ;
      private string A421PageGJSHtml ;
      private string A422PageGJSJson ;
      private string A424PageChildren ;
      private string A397Trn_PageName ;
      private string A31LocationName ;
      private string A59ProductServiceName ;
      private string A13OrganisationName ;
      private Guid A392Trn_PageId ;
      private Guid A29LocationId ;
      private Guid wcpOA392Trn_PageId ;
      private Guid wcpOA29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A58ProductServiceId ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkPageIsPublished ;
      private GXCombobox cmbPageIsContentPage ;
      private IDataStoreProvider pr_default ;
      private Guid[] H00792_A392Trn_PageId ;
      private Guid[] H00792_A29LocationId ;
      private Guid[] H00792_A11OrganisationId ;
      private Guid[] H00792_A58ProductServiceId ;
      private bool[] H00792_n58ProductServiceId ;
      private string[] H00792_A13OrganisationName ;
      private string[] H00792_A59ProductServiceName ;
      private string[] H00792_A424PageChildren ;
      private bool[] H00792_n424PageChildren ;
      private bool[] H00792_A429PageIsContentPage ;
      private bool[] H00792_n429PageIsContentPage ;
      private bool[] H00792_A423PageIsPublished ;
      private bool[] H00792_n423PageIsPublished ;
      private string[] H00792_A422PageGJSJson ;
      private bool[] H00792_n422PageGJSJson ;
      private string[] H00792_A421PageGJSHtml ;
      private bool[] H00792_n421PageGJSHtml ;
      private string[] H00792_A420PageJsonContent ;
      private bool[] H00792_n420PageJsonContent ;
      private string[] H00792_A31LocationName ;
      private string[] H00792_A397Trn_PageName ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class trn_pagegeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00792;
          prmH00792 = new Object[] {
          new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00792", "SELECT T1.Trn_PageId, T1.LocationId, T1.OrganisationId, T1.ProductServiceId, T2.OrganisationName, T4.ProductServiceName, T1.PageChildren, T1.PageIsContentPage, T1.PageIsPublished, T1.PageGJSJson, T1.PageGJSHtml, T1.PageJsonContent, T3.LocationName, T1.Trn_PageName FROM (((Trn_Page T1 INNER JOIN Trn_Organisation T2 ON T2.OrganisationId = T1.OrganisationId) INNER JOIN Trn_Location T3 ON T3.LocationId = T1.LocationId AND T3.OrganisationId = T1.OrganisationId) LEFT JOIN Trn_ProductService T4 ON T4.ProductServiceId = T1.ProductServiceId AND T4.LocationId = T1.LocationId AND T4.OrganisationId = T1.OrganisationId) WHERE T1.Trn_PageId = :Trn_PageId and T1.LocationId = :LocationId ORDER BY T1.Trn_PageId, T1.LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00792,1, GxCacheFrequency.OFF ,true,true )
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
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((bool[]) buf[9])[0] = rslt.getBool(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((bool[]) buf[11])[0] = rslt.getBool(9);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                ((string[]) buf[13])[0] = rslt.getLongVarchar(10);
                ((bool[]) buf[14])[0] = rslt.wasNull(10);
                ((string[]) buf[15])[0] = rslt.getLongVarchar(11);
                ((bool[]) buf[16])[0] = rslt.wasNull(11);
                ((string[]) buf[17])[0] = rslt.getLongVarchar(12);
                ((bool[]) buf[18])[0] = rslt.wasNull(12);
                ((string[]) buf[19])[0] = rslt.getVarchar(13);
                ((string[]) buf[20])[0] = rslt.getVarchar(14);
                return;
       }
    }

 }

}
