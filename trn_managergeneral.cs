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
   public class trn_managergeneral : GXWebComponent
   {
      public trn_managergeneral( )
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

      public trn_managergeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ManagerId ,
                           Guid aP1_OrganisationId )
      {
         this.A21ManagerId = aP0_ManagerId;
         this.A11OrganisationId = aP1_OrganisationId;
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
         cmbManagerGender = new GXCombobox();
         chkManagerIsMainManager = new GXCheckbox();
         chkManagerIsActive = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "ManagerId");
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
                  A21ManagerId = StringUtil.StrToGuid( GetPar( "ManagerId"));
                  AssignAttri(sPrefix, false, "A21ManagerId", A21ManagerId.ToString());
                  A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  AssignAttri(sPrefix, false, "A11OrganisationId", A11OrganisationId.ToString());
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(Guid)A21ManagerId,(Guid)A11OrganisationId});
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
                  gxfirstwebparm = GetFirstPar( "ManagerId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ManagerId");
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
            PA3H2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV22Pgmname = "Trn_ManagerGeneral";
               edtavManagerphonecode_description_Enabled = 0;
               AssignProp(sPrefix, false, edtavManagerphonecode_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavManagerphonecode_description_Enabled), 5, 0), true);
               WS3H2( ) ;
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
            context.SendWebValue( context.GetMessage( "Trn_Manager General", "")) ;
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
            GXEncryptionTmp = "trn_managergeneral.aspx"+UrlEncode(A21ManagerId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString());
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_managergeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA21ManagerId", wcpOA21ManagerId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA11OrganisationId", wcpOA11OrganisationId.ToString());
      }

      protected void RenderHtmlCloseForm3H2( )
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
         return "Trn_ManagerGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Manager General", "") ;
      }

      protected void WB3H0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "trn_managergeneral.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtManagerGivenName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtManagerGivenName_Internalname, context.GetMessage( "First Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtManagerGivenName_Internalname, A22ManagerGivenName, StringUtil.RTrim( context.localUtil.Format( A22ManagerGivenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,14);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtManagerGivenName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtManagerGivenName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_ManagerGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtManagerLastName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtManagerLastName_Internalname, context.GetMessage( "Last Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtManagerLastName_Internalname, A23ManagerLastName, StringUtil.RTrim( context.localUtil.Format( A23ManagerLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,19);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtManagerLastName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtManagerLastName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_ManagerGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbManagerGender_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbManagerGender_Internalname, context.GetMessage( "Gender", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbManagerGender, cmbManagerGender_Internalname, StringUtil.RTrim( A27ManagerGender), 1, cmbManagerGender_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbManagerGender.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "", true, 0, "HLP_Trn_ManagerGeneral.htm");
            cmbManagerGender.CurrentValue = StringUtil.RTrim( A27ManagerGender);
            AssignProp(sPrefix, false, cmbManagerGender_Internalname, "Values", (string)(cmbManagerGender.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtManagerEmail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtManagerEmail_Internalname, context.GetMessage( "Email", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtManagerEmail_Internalname, A25ManagerEmail, StringUtil.RTrim( context.localUtil.Format( A25ManagerEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "mailto:"+A25ManagerEmail, "", "", "", edtManagerEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtManagerEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Trn_ManagerGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, divUnnamedtable1_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTransactiondetail_phone_Internalname, context.GetMessage( "Phone", ""), "", "", lblTransactiondetail_phone_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_Trn_ManagerGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 PhoneLabel", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavManagerphonecode_description_Internalname, context.GetMessage( "Manager Phone Code_Description", ""), "col-sm-3 DropDownComponentLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavManagerphonecode_description_Internalname, AV14ManagerPhoneCode_Description, StringUtil.RTrim( context.localUtil.Format( AV14ManagerPhoneCode_Description, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavManagerphonecode_description_Jsonclick, 0, "DropDownComponent", "", "", "", "", 1, edtavManagerphonecode_description_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_ManagerGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtManagerPhoneNumber_Internalname, context.GetMessage( "Manager Phone Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtManagerPhoneNumber_Internalname, A358ManagerPhoneNumber, StringUtil.RTrim( context.localUtil.Format( A358ManagerPhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtManagerPhoneNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtManagerPhoneNumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_ManagerGeneral.htm");
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
            GxWebStd.gx_div_start( context, divManagerphone_cell_Internalname, 1, 0, "px", 0, "px", divManagerphone_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtManagerPhone_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtManagerPhone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtManagerPhone_Internalname, context.GetMessage( "Phone", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A26ManagerPhone);
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtManagerPhone_Internalname, StringUtil.RTrim( A26ManagerPhone), StringUtil.RTrim( context.localUtil.Format( A26ManagerPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtManagerPhone_Jsonclick, 0, "Attribute", "", "", "", "", edtManagerPhone_Visible, edtManagerPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Trn_ManagerGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkManagerIsMainManager_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkManagerIsMainManager_Internalname, context.GetMessage( "Is Main Manager?", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkManagerIsMainManager_Internalname, StringUtil.BoolToStr( A332ManagerIsMainManager), "", context.GetMessage( "Is Main Manager?", ""), 1, chkManagerIsMainManager.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(57, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,57);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divManagerisactive_cell_Internalname, 1, 0, "px", 0, "px", divManagerisactive_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkManagerIsActive.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkManagerIsActive_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkManagerIsActive_Internalname, context.GetMessage( "Is Active", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkManagerIsActive_Internalname, StringUtil.BoolToStr( A365ManagerIsActive), "", context.GetMessage( "Is Active", ""), chkManagerIsActive.Visible, chkManagerIsActive.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(62, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,62);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtncancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ManagerGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtManagerId_Internalname, A21ManagerId.ToString(), A21ManagerId.ToString(), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtManagerId_Jsonclick, 0, "Attribute", "", "", "", "", edtManagerId_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_ManagerGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtOrganisationId_Internalname, A11OrganisationId.ToString(), A11OrganisationId.ToString(), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationId_Jsonclick, 0, "Attribute", "", "", "", "", edtOrganisationId_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_ManagerGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtManagerInitials_Internalname, StringUtil.RTrim( A24ManagerInitials), StringUtil.RTrim( context.localUtil.Format( A24ManagerInitials, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtManagerInitials_Jsonclick, 0, "Attribute", "", "", "", "", edtManagerInitials_Visible, 0, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_ManagerGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtManagerGAMGUID_Internalname, A28ManagerGAMGUID, StringUtil.RTrim( context.localUtil.Format( A28ManagerGAMGUID, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtManagerGAMGUID_Jsonclick, 0, "Attribute", "", "", "", "", edtManagerGAMGUID_Visible, 0, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_Trn_ManagerGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START3H2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Trn_Manager General", ""), 0) ;
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
               STRUP3H0( ) ;
            }
         }
      }

      protected void WS3H2( )
      {
         START3H2( ) ;
         EVT3H2( ) ;
      }

      protected void EVT3H2( )
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
                                 STRUP3H0( ) ;
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
                                 STRUP3H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E113H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E123H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3H0( ) ;
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
                                 STRUP3H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavManagerphonecode_description_Internalname;
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

      protected void WE3H2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm3H2( ) ;
            }
         }
      }

      protected void PA3H2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_managergeneral.aspx")), "trn_managergeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_managergeneral.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "ManagerId");
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
               GX_FocusControl = edtavManagerphonecode_description_Internalname;
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
         if ( cmbManagerGender.ItemCount > 0 )
         {
            A27ManagerGender = cmbManagerGender.getValidValue(A27ManagerGender);
            AssignAttri(sPrefix, false, "A27ManagerGender", A27ManagerGender);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbManagerGender.CurrentValue = StringUtil.RTrim( A27ManagerGender);
            AssignProp(sPrefix, false, cmbManagerGender_Internalname, "Values", cmbManagerGender.ToJavascriptSource(), true);
         }
         A332ManagerIsMainManager = StringUtil.StrToBool( StringUtil.BoolToStr( A332ManagerIsMainManager));
         AssignAttri(sPrefix, false, "A332ManagerIsMainManager", A332ManagerIsMainManager);
         A365ManagerIsActive = StringUtil.StrToBool( StringUtil.BoolToStr( A365ManagerIsActive));
         AssignAttri(sPrefix, false, "A365ManagerIsActive", A365ManagerIsActive);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3H2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV22Pgmname = "Trn_ManagerGeneral";
         edtavManagerphonecode_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavManagerphonecode_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavManagerphonecode_description_Enabled), 5, 0), true);
      }

      protected void RF3H2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H003H2 */
            pr_default.execute(0, new Object[] {A21ManagerId, A11OrganisationId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A28ManagerGAMGUID = H003H2_A28ManagerGAMGUID[0];
               AssignAttri(sPrefix, false, "A28ManagerGAMGUID", A28ManagerGAMGUID);
               A24ManagerInitials = H003H2_A24ManagerInitials[0];
               AssignAttri(sPrefix, false, "A24ManagerInitials", A24ManagerInitials);
               A365ManagerIsActive = H003H2_A365ManagerIsActive[0];
               AssignAttri(sPrefix, false, "A365ManagerIsActive", A365ManagerIsActive);
               A332ManagerIsMainManager = H003H2_A332ManagerIsMainManager[0];
               AssignAttri(sPrefix, false, "A332ManagerIsMainManager", A332ManagerIsMainManager);
               A26ManagerPhone = H003H2_A26ManagerPhone[0];
               AssignAttri(sPrefix, false, "A26ManagerPhone", A26ManagerPhone);
               A358ManagerPhoneNumber = H003H2_A358ManagerPhoneNumber[0];
               AssignAttri(sPrefix, false, "A358ManagerPhoneNumber", A358ManagerPhoneNumber);
               A25ManagerEmail = H003H2_A25ManagerEmail[0];
               AssignAttri(sPrefix, false, "A25ManagerEmail", A25ManagerEmail);
               A27ManagerGender = H003H2_A27ManagerGender[0];
               AssignAttri(sPrefix, false, "A27ManagerGender", A27ManagerGender);
               A23ManagerLastName = H003H2_A23ManagerLastName[0];
               AssignAttri(sPrefix, false, "A23ManagerLastName", A23ManagerLastName);
               A22ManagerGivenName = H003H2_A22ManagerGivenName[0];
               AssignAttri(sPrefix, false, "A22ManagerGivenName", A22ManagerGivenName);
               /* Execute user event: Load */
               E123H2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB3H0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3H2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV22Pgmname = "Trn_ManagerGeneral";
         edtavManagerphonecode_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavManagerphonecode_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavManagerphonecode_description_Enabled), 5, 0), true);
         edtManagerGivenName_Enabled = 0;
         AssignProp(sPrefix, false, edtManagerGivenName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtManagerGivenName_Enabled), 5, 0), true);
         edtManagerLastName_Enabled = 0;
         AssignProp(sPrefix, false, edtManagerLastName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtManagerLastName_Enabled), 5, 0), true);
         cmbManagerGender.Enabled = 0;
         AssignProp(sPrefix, false, cmbManagerGender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbManagerGender.Enabled), 5, 0), true);
         edtManagerEmail_Enabled = 0;
         AssignProp(sPrefix, false, edtManagerEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtManagerEmail_Enabled), 5, 0), true);
         edtManagerPhoneNumber_Enabled = 0;
         AssignProp(sPrefix, false, edtManagerPhoneNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtManagerPhoneNumber_Enabled), 5, 0), true);
         edtManagerPhone_Enabled = 0;
         AssignProp(sPrefix, false, edtManagerPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtManagerPhone_Enabled), 5, 0), true);
         chkManagerIsMainManager.Enabled = 0;
         AssignProp(sPrefix, false, chkManagerIsMainManager_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkManagerIsMainManager.Enabled), 5, 0), true);
         chkManagerIsActive.Enabled = 0;
         AssignProp(sPrefix, false, chkManagerIsActive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkManagerIsActive.Enabled), 5, 0), true);
         edtManagerId_Enabled = 0;
         AssignProp(sPrefix, false, edtManagerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtManagerId_Enabled), 5, 0), true);
         edtOrganisationId_Enabled = 0;
         AssignProp(sPrefix, false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         edtManagerInitials_Enabled = 0;
         AssignProp(sPrefix, false, edtManagerInitials_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtManagerInitials_Enabled), 5, 0), true);
         edtManagerGAMGUID_Enabled = 0;
         AssignProp(sPrefix, false, edtManagerGAMGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtManagerGAMGUID_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3H0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E113H2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA21ManagerId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA21ManagerId"));
            wcpOA11OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA11OrganisationId"));
            /* Read variables values. */
            A22ManagerGivenName = cgiGet( edtManagerGivenName_Internalname);
            AssignAttri(sPrefix, false, "A22ManagerGivenName", A22ManagerGivenName);
            A23ManagerLastName = cgiGet( edtManagerLastName_Internalname);
            AssignAttri(sPrefix, false, "A23ManagerLastName", A23ManagerLastName);
            cmbManagerGender.CurrentValue = cgiGet( cmbManagerGender_Internalname);
            A27ManagerGender = cgiGet( cmbManagerGender_Internalname);
            AssignAttri(sPrefix, false, "A27ManagerGender", A27ManagerGender);
            A25ManagerEmail = cgiGet( edtManagerEmail_Internalname);
            AssignAttri(sPrefix, false, "A25ManagerEmail", A25ManagerEmail);
            AV14ManagerPhoneCode_Description = cgiGet( edtavManagerphonecode_description_Internalname);
            AssignAttri(sPrefix, false, "AV14ManagerPhoneCode_Description", AV14ManagerPhoneCode_Description);
            A358ManagerPhoneNumber = cgiGet( edtManagerPhoneNumber_Internalname);
            AssignAttri(sPrefix, false, "A358ManagerPhoneNumber", A358ManagerPhoneNumber);
            A26ManagerPhone = cgiGet( edtManagerPhone_Internalname);
            AssignAttri(sPrefix, false, "A26ManagerPhone", A26ManagerPhone);
            A332ManagerIsMainManager = StringUtil.StrToBool( cgiGet( chkManagerIsMainManager_Internalname));
            AssignAttri(sPrefix, false, "A332ManagerIsMainManager", A332ManagerIsMainManager);
            A365ManagerIsActive = StringUtil.StrToBool( cgiGet( chkManagerIsActive_Internalname));
            AssignAttri(sPrefix, false, "A365ManagerIsActive", A365ManagerIsActive);
            A24ManagerInitials = cgiGet( edtManagerInitials_Internalname);
            AssignAttri(sPrefix, false, "A24ManagerInitials", A24ManagerInitials);
            A28ManagerGAMGUID = cgiGet( edtManagerGAMGUID_Internalname);
            AssignAttri(sPrefix, false, "A28ManagerGAMGUID", A28ManagerGAMGUID);
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
         E113H2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E113H2( )
      {
         /* Start Routine */
         returnInSub = false;
         Gx_mode = "DSP";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         GXt_objcol_SdtDVB_SDTComboData_Item1 = AV15Combo_Data;
         new trn_managerloaddvcombo(context ).execute(  "ManagerPhoneCode",  "GET_DSC",  A21ManagerId,  A11OrganisationId, out  AV17ComboSelectedValue, out  AV14ManagerPhoneCode_Description, out  GXt_objcol_SdtDVB_SDTComboData_Item1) ;
         AssignAttri(sPrefix, false, "AV14ManagerPhoneCode_Description", AV14ManagerPhoneCode_Description);
         AV15Combo_Data = GXt_objcol_SdtDVB_SDTComboData_Item1;
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         GXt_boolean2 = AV18isMainManager;
         new prc_checkismainmanager(context ).execute( out  GXt_boolean2) ;
         AV18isMainManager = GXt_boolean2;
      }

      protected void nextLoad( )
      {
      }

      protected void E123H2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtManagerId_Visible = 0;
         AssignProp(sPrefix, false, edtManagerId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtManagerId_Visible), 5, 0), true);
         edtOrganisationId_Visible = 0;
         AssignProp(sPrefix, false, edtOrganisationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Visible), 5, 0), true);
         edtManagerInitials_Visible = 0;
         AssignProp(sPrefix, false, edtManagerInitials_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtManagerInitials_Visible), 5, 0), true);
         edtManagerGAMGUID_Visible = 0;
         AssignProp(sPrefix, false, edtManagerGAMGUID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtManagerGAMGUID_Visible), 5, 0), true);
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) ) )
         {
            edtManagerPhone_Visible = 0;
            AssignProp(sPrefix, false, edtManagerPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtManagerPhone_Visible), 5, 0), true);
            divManagerphone_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divManagerphone_cell_Internalname, "Class", divManagerphone_cell_Class, true);
         }
         else
         {
            edtManagerPhone_Visible = 1;
            AssignProp(sPrefix, false, edtManagerPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtManagerPhone_Visible), 5, 0), true);
            divManagerphone_cell_Class = "col-xs-12 col-sm-6 DataContentCell";
            AssignProp(sPrefix, false, divManagerphone_cell_Internalname, "Class", divManagerphone_cell_Class, true);
         }
         if ( ! ( ( AV20IsGAMActive ) ) )
         {
            chkManagerIsActive.Visible = 0;
            AssignProp(sPrefix, false, chkManagerIsActive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkManagerIsActive.Visible), 5, 0), true);
            divManagerisactive_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divManagerisactive_cell_Internalname, "Class", divManagerisactive_cell_Class, true);
         }
         else
         {
            chkManagerIsActive.Visible = 1;
            AssignProp(sPrefix, false, chkManagerIsActive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkManagerIsActive.Visible), 5, 0), true);
            divManagerisactive_cell_Class = "col-xs-12 col-sm-6 DataContentCell";
            AssignProp(sPrefix, false, divManagerisactive_cell_Internalname, "Class", divManagerisactive_cell_Class, true);
         }
         divUnnamedtable1_Visible = (((StringUtil.StrCmp(Gx_mode, "INS")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0)) ? 1 : 0);
         AssignProp(sPrefix, false, divUnnamedtable1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUnnamedtable1_Visible), 5, 0), true);
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV22Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Trn_Manager";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A21ManagerId = (Guid)getParm(obj,0);
         AssignAttri(sPrefix, false, "A21ManagerId", A21ManagerId.ToString());
         A11OrganisationId = (Guid)getParm(obj,1);
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
         PA3H2( ) ;
         WS3H2( ) ;
         WE3H2( ) ;
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
         sCtrlA21ManagerId = (string)((string)getParm(obj,0));
         sCtrlA11OrganisationId = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA3H2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "trn_managergeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA3H2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A21ManagerId = (Guid)getParm(obj,2);
            AssignAttri(sPrefix, false, "A21ManagerId", A21ManagerId.ToString());
            A11OrganisationId = (Guid)getParm(obj,3);
            AssignAttri(sPrefix, false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         wcpOA21ManagerId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA21ManagerId"));
         wcpOA11OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA11OrganisationId"));
         if ( ! GetJustCreated( ) && ( ( A21ManagerId != wcpOA21ManagerId ) || ( A11OrganisationId != wcpOA11OrganisationId ) ) )
         {
            setjustcreated();
         }
         wcpOA21ManagerId = A21ManagerId;
         wcpOA11OrganisationId = A11OrganisationId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA21ManagerId = cgiGet( sPrefix+"A21ManagerId_CTRL");
         if ( StringUtil.Len( sCtrlA21ManagerId) > 0 )
         {
            A21ManagerId = StringUtil.StrToGuid( cgiGet( sCtrlA21ManagerId));
            AssignAttri(sPrefix, false, "A21ManagerId", A21ManagerId.ToString());
         }
         else
         {
            A21ManagerId = StringUtil.StrToGuid( cgiGet( sPrefix+"A21ManagerId_PARM"));
         }
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
         PA3H2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS3H2( ) ;
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
         WS3H2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A21ManagerId_PARM", A21ManagerId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA21ManagerId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A21ManagerId_CTRL", StringUtil.RTrim( sCtrlA21ManagerId));
         }
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
         WE3H2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025630933395", true, true);
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
         context.AddJavascriptSource("trn_managergeneral.js", "?2025630933395", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbManagerGender.Name = "MANAGERGENDER";
         cmbManagerGender.WebTags = "";
         cmbManagerGender.addItem("Male", context.GetMessage( "Male", ""), 0);
         cmbManagerGender.addItem("Female", context.GetMessage( "Female", ""), 0);
         cmbManagerGender.addItem("Other", context.GetMessage( "Other", ""), 0);
         if ( cmbManagerGender.ItemCount > 0 )
         {
         }
         chkManagerIsMainManager.Name = "MANAGERISMAINMANAGER";
         chkManagerIsMainManager.WebTags = "";
         chkManagerIsMainManager.Caption = context.GetMessage( "Is Main Manager?", "");
         AssignProp(sPrefix, false, chkManagerIsMainManager_Internalname, "TitleCaption", chkManagerIsMainManager.Caption, true);
         chkManagerIsMainManager.CheckedValue = "false";
         chkManagerIsActive.Name = "MANAGERISACTIVE";
         chkManagerIsActive.WebTags = "";
         chkManagerIsActive.Caption = context.GetMessage( "Is Active", "");
         AssignProp(sPrefix, false, chkManagerIsActive_Internalname, "TitleCaption", chkManagerIsActive.Caption, true);
         chkManagerIsActive.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtManagerGivenName_Internalname = sPrefix+"MANAGERGIVENNAME";
         edtManagerLastName_Internalname = sPrefix+"MANAGERLASTNAME";
         cmbManagerGender_Internalname = sPrefix+"MANAGERGENDER";
         edtManagerEmail_Internalname = sPrefix+"MANAGEREMAIL";
         lblTransactiondetail_phone_Internalname = sPrefix+"TRANSACTIONDETAIL_PHONE";
         edtavManagerphonecode_description_Internalname = sPrefix+"vMANAGERPHONECODE_DESCRIPTION";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         edtManagerPhoneNumber_Internalname = sPrefix+"MANAGERPHONENUMBER";
         divUnnamedtable2_Internalname = sPrefix+"UNNAMEDTABLE2";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         edtManagerPhone_Internalname = sPrefix+"MANAGERPHONE";
         divManagerphone_cell_Internalname = sPrefix+"MANAGERPHONE_CELL";
         chkManagerIsMainManager_Internalname = sPrefix+"MANAGERISMAINMANAGER";
         chkManagerIsActive_Internalname = sPrefix+"MANAGERISACTIVE";
         divManagerisactive_cell_Internalname = sPrefix+"MANAGERISACTIVE_CELL";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtncancel_Internalname = sPrefix+"BTNCANCEL";
         divTable_Internalname = sPrefix+"TABLE";
         edtManagerId_Internalname = sPrefix+"MANAGERID";
         edtOrganisationId_Internalname = sPrefix+"ORGANISATIONID";
         edtManagerInitials_Internalname = sPrefix+"MANAGERINITIALS";
         edtManagerGAMGUID_Internalname = sPrefix+"MANAGERGAMGUID";
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
         chkManagerIsActive.Caption = context.GetMessage( "Is Active", "");
         chkManagerIsMainManager.Caption = context.GetMessage( "Is Main Manager?", "");
         edtManagerGAMGUID_Enabled = 0;
         edtManagerInitials_Enabled = 0;
         edtOrganisationId_Enabled = 0;
         edtManagerId_Enabled = 0;
         edtManagerGAMGUID_Jsonclick = "";
         edtManagerGAMGUID_Visible = 1;
         edtManagerInitials_Jsonclick = "";
         edtManagerInitials_Visible = 1;
         edtOrganisationId_Jsonclick = "";
         edtOrganisationId_Visible = 1;
         edtManagerId_Jsonclick = "";
         edtManagerId_Visible = 1;
         chkManagerIsActive.Enabled = 0;
         chkManagerIsActive.Visible = 1;
         divManagerisactive_cell_Class = "col-xs-12 col-sm-6";
         chkManagerIsMainManager.Enabled = 0;
         edtManagerPhone_Jsonclick = "";
         edtManagerPhone_Enabled = 0;
         edtManagerPhone_Visible = 1;
         divManagerphone_cell_Class = "col-xs-12 col-sm-6";
         edtManagerPhoneNumber_Jsonclick = "";
         edtManagerPhoneNumber_Enabled = 0;
         edtavManagerphonecode_description_Jsonclick = "";
         edtavManagerphonecode_description_Enabled = 1;
         divUnnamedtable1_Visible = 1;
         edtManagerEmail_Jsonclick = "";
         edtManagerEmail_Enabled = 0;
         cmbManagerGender_Jsonclick = "";
         cmbManagerGender.Enabled = 0;
         edtManagerLastName_Jsonclick = "";
         edtManagerLastName_Enabled = 0;
         edtManagerGivenName_Jsonclick = "";
         edtManagerGivenName_Enabled = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A21ManagerId","fld":"MANAGERID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A332ManagerIsMainManager","fld":"MANAGERISMAINMANAGER"},{"av":"A365ManagerIsActive","fld":"MANAGERISACTIVE"}]}""");
         setEventMetadata("VALID_MANAGERID","""{"handler":"Valid_Managerid","iparms":[]}""");
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
         wcpOA21ManagerId = Guid.Empty;
         wcpOA11OrganisationId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV22Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         TempTags = "";
         A22ManagerGivenName = "";
         A23ManagerLastName = "";
         A27ManagerGender = "";
         A25ManagerEmail = "";
         lblTransactiondetail_phone_Jsonclick = "";
         AV14ManagerPhoneCode_Description = "";
         A358ManagerPhoneNumber = "";
         gxphoneLink = "";
         A26ManagerPhone = "";
         ClassString = "";
         StyleString = "";
         bttBtncancel_Jsonclick = "";
         A24ManagerInitials = "";
         A28ManagerGAMGUID = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H003H2_A21ManagerId = new Guid[] {Guid.Empty} ;
         H003H2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H003H2_A28ManagerGAMGUID = new string[] {""} ;
         H003H2_A24ManagerInitials = new string[] {""} ;
         H003H2_A365ManagerIsActive = new bool[] {false} ;
         H003H2_A332ManagerIsMainManager = new bool[] {false} ;
         H003H2_A26ManagerPhone = new string[] {""} ;
         H003H2_A358ManagerPhoneNumber = new string[] {""} ;
         H003H2_A25ManagerEmail = new string[] {""} ;
         H003H2_A27ManagerGender = new string[] {""} ;
         H003H2_A23ManagerLastName = new string[] {""} ;
         H003H2_A22ManagerGivenName = new string[] {""} ;
         Gx_mode = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV15Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         GXt_objcol_SdtDVB_SDTComboData_Item1 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV17ComboSelectedValue = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA21ManagerId = "";
         sCtrlA11OrganisationId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_managergeneral__default(),
            new Object[][] {
                new Object[] {
               H003H2_A21ManagerId, H003H2_A11OrganisationId, H003H2_A28ManagerGAMGUID, H003H2_A24ManagerInitials, H003H2_A365ManagerIsActive, H003H2_A332ManagerIsMainManager, H003H2_A26ManagerPhone, H003H2_A358ManagerPhoneNumber, H003H2_A25ManagerEmail, H003H2_A27ManagerGender,
               H003H2_A23ManagerLastName, H003H2_A22ManagerGivenName
               }
            }
         );
         AV22Pgmname = "Trn_ManagerGeneral";
         /* GeneXus formulas. */
         AV22Pgmname = "Trn_ManagerGeneral";
         edtavManagerphonecode_description_Enabled = 0;
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
      private int edtavManagerphonecode_description_Enabled ;
      private int edtManagerGivenName_Enabled ;
      private int edtManagerLastName_Enabled ;
      private int edtManagerEmail_Enabled ;
      private int divUnnamedtable1_Visible ;
      private int edtManagerPhoneNumber_Enabled ;
      private int edtManagerPhone_Visible ;
      private int edtManagerPhone_Enabled ;
      private int edtManagerId_Visible ;
      private int edtOrganisationId_Visible ;
      private int edtManagerInitials_Visible ;
      private int edtManagerGAMGUID_Visible ;
      private int edtManagerId_Enabled ;
      private int edtOrganisationId_Enabled ;
      private int edtManagerInitials_Enabled ;
      private int edtManagerGAMGUID_Enabled ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV22Pgmname ;
      private string edtavManagerphonecode_description_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string edtManagerGivenName_Internalname ;
      private string TempTags ;
      private string edtManagerGivenName_Jsonclick ;
      private string edtManagerLastName_Internalname ;
      private string edtManagerLastName_Jsonclick ;
      private string cmbManagerGender_Internalname ;
      private string cmbManagerGender_Jsonclick ;
      private string edtManagerEmail_Internalname ;
      private string edtManagerEmail_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string lblTransactiondetail_phone_Internalname ;
      private string lblTransactiondetail_phone_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string edtavManagerphonecode_description_Jsonclick ;
      private string edtManagerPhoneNumber_Internalname ;
      private string edtManagerPhoneNumber_Jsonclick ;
      private string divManagerphone_cell_Internalname ;
      private string divManagerphone_cell_Class ;
      private string edtManagerPhone_Internalname ;
      private string gxphoneLink ;
      private string A26ManagerPhone ;
      private string edtManagerPhone_Jsonclick ;
      private string chkManagerIsMainManager_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divManagerisactive_cell_Internalname ;
      private string divManagerisactive_cell_Class ;
      private string chkManagerIsActive_Internalname ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtManagerId_Internalname ;
      private string edtManagerId_Jsonclick ;
      private string edtOrganisationId_Internalname ;
      private string edtOrganisationId_Jsonclick ;
      private string edtManagerInitials_Internalname ;
      private string A24ManagerInitials ;
      private string edtManagerInitials_Jsonclick ;
      private string edtManagerGAMGUID_Internalname ;
      private string edtManagerGAMGUID_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string sCtrlA21ManagerId ;
      private string sCtrlA11OrganisationId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool A332ManagerIsMainManager ;
      private bool A365ManagerIsActive ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV18isMainManager ;
      private bool GXt_boolean2 ;
      private bool AV20IsGAMActive ;
      private string A22ManagerGivenName ;
      private string A23ManagerLastName ;
      private string A27ManagerGender ;
      private string A25ManagerEmail ;
      private string AV14ManagerPhoneCode_Description ;
      private string A358ManagerPhoneNumber ;
      private string A28ManagerGAMGUID ;
      private string AV17ComboSelectedValue ;
      private Guid A21ManagerId ;
      private Guid A11OrganisationId ;
      private Guid wcpOA21ManagerId ;
      private Guid wcpOA11OrganisationId ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbManagerGender ;
      private GXCheckbox chkManagerIsMainManager ;
      private GXCheckbox chkManagerIsActive ;
      private IDataStoreProvider pr_default ;
      private Guid[] H003H2_A21ManagerId ;
      private Guid[] H003H2_A11OrganisationId ;
      private string[] H003H2_A28ManagerGAMGUID ;
      private string[] H003H2_A24ManagerInitials ;
      private bool[] H003H2_A365ManagerIsActive ;
      private bool[] H003H2_A332ManagerIsMainManager ;
      private string[] H003H2_A26ManagerPhone ;
      private string[] H003H2_A358ManagerPhoneNumber ;
      private string[] H003H2_A25ManagerEmail ;
      private string[] H003H2_A27ManagerGender ;
      private string[] H003H2_A23ManagerLastName ;
      private string[] H003H2_A22ManagerGivenName ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> GXt_objcol_SdtDVB_SDTComboData_Item1 ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class trn_managergeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH003H2;
          prmH003H2 = new Object[] {
          new ParDef("ManagerId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("H003H2", "SELECT ManagerId, OrganisationId, ManagerGAMGUID, ManagerInitials, ManagerIsActive, ManagerIsMainManager, ManagerPhone, ManagerPhoneNumber, ManagerEmail, ManagerGender, ManagerLastName, ManagerGivenName FROM Trn_Manager WHERE ManagerId = :ManagerId and OrganisationId = :OrganisationId ORDER BY ManagerId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003H2,1, GxCacheFrequency.OFF ,true,true )
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
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                return;
       }
    }

 }

}
