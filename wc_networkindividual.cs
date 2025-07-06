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
   public class wc_networkindividual : GXWebComponent
   {
      public wc_networkindividual( )
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

      public wc_networkindividual( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ResidentId )
      {
         this.AV27ResidentId = aP0_ResidentId;
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
         cmbavTrn_networkindividual_networkindividualsalutation = new GXCombobox();
         cmbavTrn_networkindividual_networkindividualgender = new GXCombobox();
         cmbavTrn_networkindividual_networkindividualrelationship = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "ResidentId");
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
                  AV27ResidentId = StringUtil.StrToGuid( GetPar( "ResidentId"));
                  AssignAttri(sPrefix, false, "AV27ResidentId", AV27ResidentId.ToString());
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(Guid)AV27ResidentId});
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
                  gxfirstwebparm = GetFirstPar( "ResidentId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ResidentId");
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
            PABW2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               cmbavTrn_networkindividual_networkindividualsalutation.Enabled = 0;
               AssignProp(sPrefix, false, cmbavTrn_networkindividual_networkindividualsalutation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTrn_networkindividual_networkindividualsalutation.Enabled), 5, 0), true);
               edtavTrn_networkindividual_networkindividualgivenname_Enabled = 0;
               AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualgivenname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualgivenname_Enabled), 5, 0), true);
               edtavTrn_networkindividual_networkindividuallastname_Enabled = 0;
               AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividuallastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividuallastname_Enabled), 5, 0), true);
               cmbavTrn_networkindividual_networkindividualgender.Enabled = 0;
               AssignProp(sPrefix, false, cmbavTrn_networkindividual_networkindividualgender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTrn_networkindividual_networkindividualgender.Enabled), 5, 0), true);
               cmbavTrn_networkindividual_networkindividualrelationship.Enabled = 0;
               AssignProp(sPrefix, false, cmbavTrn_networkindividual_networkindividualrelationship_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTrn_networkindividual_networkindividualrelationship.Enabled), 5, 0), true);
               edtavTrn_networkindividual_networkindividualemail_Enabled = 0;
               AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualemail_Enabled), 5, 0), true);
               edtavTrn_networkindividual_networkindividualphone_Enabled = 0;
               AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualphone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualphone_Enabled), 5, 0), true);
               edtavTrn_networkindividual_networkindividualhomephone_Enabled = 0;
               AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualhomephone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualhomephone_Enabled), 5, 0), true);
               edtavTrn_networkindividual_networkindividualbsnnumber_Enabled = 0;
               AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualbsnnumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualbsnnumber_Enabled), 5, 0), true);
               edtavTrn_networkindividual_networkindividualaddressline1_Enabled = 0;
               AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualaddressline1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualaddressline1_Enabled), 5, 0), true);
               edtavTrn_networkindividual_networkindividualaddressline2_Enabled = 0;
               AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualaddressline2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualaddressline2_Enabled), 5, 0), true);
               edtavTrn_networkindividual_networkindividualzipcode_Enabled = 0;
               AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualzipcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualzipcode_Enabled), 5, 0), true);
               edtavTrn_networkindividual_networkindividualcity_Enabled = 0;
               AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualcity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualcity_Enabled), 5, 0), true);
               edtavTrn_networkindividual_networkindividualcountry_Enabled = 0;
               AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualcountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualcountry_Enabled), 5, 0), true);
               WSBW2( ) ;
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
            context.SendWebValue( context.GetMessage( "WC_Network Individual", "")) ;
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
               GXEncryptionTmp = "wc_networkindividual.aspx"+UrlEncode(AV27ResidentId.ToString());
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wc_networkindividual.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Trn_networkindividual", AV6Trn_NetworkIndividual);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Trn_networkindividual", AV6Trn_NetworkIndividual);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV27ResidentId", wcpOAV27ResidentId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"vRESIDENTID", AV27ResidentId.ToString());
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTRN_NETWORKINDIVIDUAL", AV6Trn_NetworkIndividual);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTRN_NETWORKINDIVIDUAL", AV6Trn_NetworkIndividual);
         }
      }

      protected void RenderHtmlCloseFormBW2( )
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
         return "WC_NetworkIndividual" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WC_Network Individual", "") ;
      }

      protected void WBBW0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wc_networkindividual.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpNextofkininfogroup_Internalname, context.GetMessage( "Next of Kin Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WC_NetworkIndividual.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavTrn_networkindividual_networkindividualsalutation_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavTrn_networkindividual_networkindividualsalutation_Internalname, context.GetMessage( "Salutation", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavTrn_networkindividual_networkindividualsalutation, cmbavTrn_networkindividual_networkindividualsalutation_Internalname, StringUtil.RTrim( AV6Trn_NetworkIndividual.gxTpr_Networkindividualsalutation), 1, cmbavTrn_networkindividual_networkindividualsalutation_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavTrn_networkindividual_networkindividualsalutation.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "", false, 0, "HLP_WC_NetworkIndividual.htm");
            cmbavTrn_networkindividual_networkindividualsalutation.CurrentValue = StringUtil.RTrim( AV6Trn_NetworkIndividual.gxTpr_Networkindividualsalutation);
            AssignProp(sPrefix, false, cmbavTrn_networkindividual_networkindividualsalutation_Internalname, "Values", (string)(cmbavTrn_networkindividual_networkindividualsalutation.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_networkindividual_networkindividualgivenname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_networkindividual_networkindividualgivenname_Internalname, context.GetMessage( "First Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_networkindividual_networkindividualgivenname_Internalname, AV6Trn_NetworkIndividual.gxTpr_Networkindividualgivenname, StringUtil.RTrim( context.localUtil.Format( AV6Trn_NetworkIndividual.gxTpr_Networkindividualgivenname, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_networkindividual_networkindividualgivenname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_networkindividual_networkindividualgivenname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WC_NetworkIndividual.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_networkindividual_networkindividuallastname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_networkindividual_networkindividuallastname_Internalname, context.GetMessage( "Last Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_networkindividual_networkindividuallastname_Internalname, AV6Trn_NetworkIndividual.gxTpr_Networkindividuallastname, StringUtil.RTrim( context.localUtil.Format( AV6Trn_NetworkIndividual.gxTpr_Networkindividuallastname, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_networkindividual_networkindividuallastname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_networkindividual_networkindividuallastname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WC_NetworkIndividual.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavTrn_networkindividual_networkindividualgender_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavTrn_networkindividual_networkindividualgender_Internalname, context.GetMessage( "Gender", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavTrn_networkindividual_networkindividualgender, cmbavTrn_networkindividual_networkindividualgender_Internalname, StringUtil.RTrim( AV6Trn_NetworkIndividual.gxTpr_Networkindividualgender), 1, cmbavTrn_networkindividual_networkindividualgender_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavTrn_networkindividual_networkindividualgender.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", false, 0, "HLP_WC_NetworkIndividual.htm");
            cmbavTrn_networkindividual_networkindividualgender.CurrentValue = StringUtil.RTrim( AV6Trn_NetworkIndividual.gxTpr_Networkindividualgender);
            AssignProp(sPrefix, false, cmbavTrn_networkindividual_networkindividualgender_Internalname, "Values", (string)(cmbavTrn_networkindividual_networkindividualgender.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavTrn_networkindividual_networkindividualrelationship_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavTrn_networkindividual_networkindividualrelationship_Internalname, context.GetMessage( "Relationship", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavTrn_networkindividual_networkindividualrelationship, cmbavTrn_networkindividual_networkindividualrelationship_Internalname, StringUtil.RTrim( AV6Trn_NetworkIndividual.gxTpr_Networkindividualrelationship), 1, cmbavTrn_networkindividual_networkindividualrelationship_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavTrn_networkindividual_networkindividualrelationship.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", false, 0, "HLP_WC_NetworkIndividual.htm");
            cmbavTrn_networkindividual_networkindividualrelationship.CurrentValue = StringUtil.RTrim( AV6Trn_NetworkIndividual.gxTpr_Networkindividualrelationship);
            AssignProp(sPrefix, false, cmbavTrn_networkindividual_networkindividualrelationship_Internalname, "Values", (string)(cmbavTrn_networkindividual_networkindividualrelationship.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_networkindividual_networkindividualemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_networkindividual_networkindividualemail_Internalname, context.GetMessage( "Email", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_networkindividual_networkindividualemail_Internalname, AV6Trn_NetworkIndividual.gxTpr_Networkindividualemail, StringUtil.RTrim( context.localUtil.Format( AV6Trn_NetworkIndividual.gxTpr_Networkindividualemail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_networkindividual_networkindividualemail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_networkindividual_networkindividualemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, false, "", "start", true, "", "HLP_WC_NetworkIndividual.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTrn_networkindividual_networkindividualphone_cell_Internalname, 1, 0, "px", 0, "px", divTrn_networkindividual_networkindividualphone_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavTrn_networkindividual_networkindividualphone_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_networkindividual_networkindividualphone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_networkindividual_networkindividualphone_Internalname, context.GetMessage( "Mobile Phone", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_networkindividual_networkindividualphone_Internalname, StringUtil.RTrim( AV6Trn_NetworkIndividual.gxTpr_Networkindividualphone), StringUtil.RTrim( context.localUtil.Format( AV6Trn_NetworkIndividual.gxTpr_Networkindividualphone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_networkindividual_networkindividualphone_Jsonclick, 0, "Attribute", "", "", "", "", edtavTrn_networkindividual_networkindividualphone_Visible, edtavTrn_networkindividual_networkindividualphone_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, false, "", "start", true, "", "HLP_WC_NetworkIndividual.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTrn_networkindividual_networkindividualhomephone_cell_Internalname, 1, 0, "px", 0, "px", divTrn_networkindividual_networkindividualhomephone_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavTrn_networkindividual_networkindividualhomephone_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_networkindividual_networkindividualhomephone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_networkindividual_networkindividualhomephone_Internalname, context.GetMessage( "Home Phone", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_networkindividual_networkindividualhomephone_Internalname, StringUtil.RTrim( AV6Trn_NetworkIndividual.gxTpr_Networkindividualhomephone), StringUtil.RTrim( context.localUtil.Format( AV6Trn_NetworkIndividual.gxTpr_Networkindividualhomephone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_networkindividual_networkindividualhomephone_Jsonclick, 0, "Attribute", "", "", "", "", edtavTrn_networkindividual_networkindividualhomephone_Visible, edtavTrn_networkindividual_networkindividualhomephone_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, false, "", "start", true, "", "HLP_WC_NetworkIndividual.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_networkindividual_networkindividualbsnnumber_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_networkindividual_networkindividualbsnnumber_Internalname, context.GetMessage( "BSN Number", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_networkindividual_networkindividualbsnnumber_Internalname, AV6Trn_NetworkIndividual.gxTpr_Networkindividualbsnnumber, StringUtil.RTrim( context.localUtil.Format( AV6Trn_NetworkIndividual.gxTpr_Networkindividualbsnnumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_networkindividual_networkindividualbsnnumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_networkindividual_networkindividualbsnnumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WC_NetworkIndividual.htm");
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
            GxWebStd.gx_group_start( context, grpUnnamedgroup3_Internalname, context.GetMessage( "Address Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WC_NetworkIndividual.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_networkindividual_networkindividualaddressline1_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_networkindividual_networkindividualaddressline1_Internalname, context.GetMessage( "Address Line 1", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_networkindividual_networkindividualaddressline1_Internalname, AV6Trn_NetworkIndividual.gxTpr_Networkindividualaddressline1, StringUtil.RTrim( context.localUtil.Format( AV6Trn_NetworkIndividual.gxTpr_Networkindividualaddressline1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_networkindividual_networkindividualaddressline1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_networkindividual_networkindividualaddressline1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WC_NetworkIndividual.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_networkindividual_networkindividualaddressline2_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_networkindividual_networkindividualaddressline2_Internalname, context.GetMessage( "Address Line 2", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_networkindividual_networkindividualaddressline2_Internalname, AV6Trn_NetworkIndividual.gxTpr_Networkindividualaddressline2, StringUtil.RTrim( context.localUtil.Format( AV6Trn_NetworkIndividual.gxTpr_Networkindividualaddressline2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_networkindividual_networkindividualaddressline2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_networkindividual_networkindividualaddressline2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WC_NetworkIndividual.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_networkindividual_networkindividualzipcode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_networkindividual_networkindividualzipcode_Internalname, context.GetMessage( "Zip Code", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_networkindividual_networkindividualzipcode_Internalname, AV6Trn_NetworkIndividual.gxTpr_Networkindividualzipcode, StringUtil.RTrim( context.localUtil.Format( AV6Trn_NetworkIndividual.gxTpr_Networkindividualzipcode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_networkindividual_networkindividualzipcode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_networkindividual_networkindividualzipcode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WC_NetworkIndividual.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_networkindividual_networkindividualcity_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_networkindividual_networkindividualcity_Internalname, context.GetMessage( "City", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_networkindividual_networkindividualcity_Internalname, AV6Trn_NetworkIndividual.gxTpr_Networkindividualcity, StringUtil.RTrim( context.localUtil.Format( AV6Trn_NetworkIndividual.gxTpr_Networkindividualcity, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_networkindividual_networkindividualcity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_networkindividual_networkindividualcity_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WC_NetworkIndividual.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_networkindividual_networkindividualcountry_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_networkindividual_networkindividualcountry_Internalname, context.GetMessage( "Country", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_networkindividual_networkindividualcountry_Internalname, AV6Trn_NetworkIndividual.gxTpr_Networkindividualcountry, StringUtil.RTrim( context.localUtil.Format( AV6Trn_NetworkIndividual.gxTpr_Networkindividualcountry, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,92);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_networkindividual_networkindividualcountry_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_networkindividual_networkindividualcountry_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WC_NetworkIndividual.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_networkindividual_networkindividualid_Internalname, AV6Trn_NetworkIndividual.gxTpr_Networkindividualid.ToString(), AV6Trn_NetworkIndividual.gxTpr_Networkindividualid.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_networkindividual_networkindividualid_Jsonclick, 0, "Attribute", "", "", "", "", edtavTrn_networkindividual_networkindividualid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, false, "", "", false, "", "HLP_WC_NetworkIndividual.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void STARTBW2( )
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
            Form.Meta.addItem("description", context.GetMessage( "WC_Network Individual", ""), 0) ;
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
               STRUPBW0( ) ;
            }
         }
      }

      protected void WSBW2( )
      {
         STARTBW2( ) ;
         EVTBW2( ) ;
      }

      protected void EVTBW2( )
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
                                 STRUPBW0( ) ;
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
                                 STRUPBW0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11BW2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBW0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E12BW2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBW0( ) ;
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
                                 STRUPBW0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = cmbavTrn_networkindividual_networkindividualsalutation_Internalname;
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

      protected void WEBW2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseFormBW2( ) ;
            }
         }
      }

      protected void PABW2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wc_networkindividual.aspx")), "wc_networkindividual.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wc_networkindividual.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "ResidentId");
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
               GX_FocusControl = cmbavTrn_networkindividual_networkindividualsalutation_Internalname;
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
         if ( cmbavTrn_networkindividual_networkindividualsalutation.ItemCount > 0 )
         {
            AV6Trn_NetworkIndividual.gxTpr_Networkindividualsalutation = cmbavTrn_networkindividual_networkindividualsalutation.getValidValue(AV6Trn_NetworkIndividual.gxTpr_Networkindividualsalutation);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavTrn_networkindividual_networkindividualsalutation.CurrentValue = StringUtil.RTrim( AV6Trn_NetworkIndividual.gxTpr_Networkindividualsalutation);
            AssignProp(sPrefix, false, cmbavTrn_networkindividual_networkindividualsalutation_Internalname, "Values", cmbavTrn_networkindividual_networkindividualsalutation.ToJavascriptSource(), true);
         }
         if ( cmbavTrn_networkindividual_networkindividualgender.ItemCount > 0 )
         {
            AV6Trn_NetworkIndividual.gxTpr_Networkindividualgender = cmbavTrn_networkindividual_networkindividualgender.getValidValue(AV6Trn_NetworkIndividual.gxTpr_Networkindividualgender);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavTrn_networkindividual_networkindividualgender.CurrentValue = StringUtil.RTrim( AV6Trn_NetworkIndividual.gxTpr_Networkindividualgender);
            AssignProp(sPrefix, false, cmbavTrn_networkindividual_networkindividualgender_Internalname, "Values", cmbavTrn_networkindividual_networkindividualgender.ToJavascriptSource(), true);
         }
         if ( cmbavTrn_networkindividual_networkindividualrelationship.ItemCount > 0 )
         {
            AV6Trn_NetworkIndividual.gxTpr_Networkindividualrelationship = cmbavTrn_networkindividual_networkindividualrelationship.getValidValue(AV6Trn_NetworkIndividual.gxTpr_Networkindividualrelationship);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavTrn_networkindividual_networkindividualrelationship.CurrentValue = StringUtil.RTrim( AV6Trn_NetworkIndividual.gxTpr_Networkindividualrelationship);
            AssignProp(sPrefix, false, cmbavTrn_networkindividual_networkindividualrelationship_Internalname, "Values", cmbavTrn_networkindividual_networkindividualrelationship.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFBW2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         cmbavTrn_networkindividual_networkindividualsalutation.Enabled = 0;
         AssignProp(sPrefix, false, cmbavTrn_networkindividual_networkindividualsalutation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTrn_networkindividual_networkindividualsalutation.Enabled), 5, 0), true);
         edtavTrn_networkindividual_networkindividualgivenname_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualgivenname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualgivenname_Enabled), 5, 0), true);
         edtavTrn_networkindividual_networkindividuallastname_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividuallastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividuallastname_Enabled), 5, 0), true);
         cmbavTrn_networkindividual_networkindividualgender.Enabled = 0;
         AssignProp(sPrefix, false, cmbavTrn_networkindividual_networkindividualgender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTrn_networkindividual_networkindividualgender.Enabled), 5, 0), true);
         cmbavTrn_networkindividual_networkindividualrelationship.Enabled = 0;
         AssignProp(sPrefix, false, cmbavTrn_networkindividual_networkindividualrelationship_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTrn_networkindividual_networkindividualrelationship.Enabled), 5, 0), true);
         edtavTrn_networkindividual_networkindividualemail_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualemail_Enabled), 5, 0), true);
         edtavTrn_networkindividual_networkindividualphone_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualphone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualphone_Enabled), 5, 0), true);
         edtavTrn_networkindividual_networkindividualhomephone_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualhomephone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualhomephone_Enabled), 5, 0), true);
         edtavTrn_networkindividual_networkindividualbsnnumber_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualbsnnumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualbsnnumber_Enabled), 5, 0), true);
         edtavTrn_networkindividual_networkindividualaddressline1_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualaddressline1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualaddressline1_Enabled), 5, 0), true);
         edtavTrn_networkindividual_networkindividualaddressline2_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualaddressline2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualaddressline2_Enabled), 5, 0), true);
         edtavTrn_networkindividual_networkindividualzipcode_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualzipcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualzipcode_Enabled), 5, 0), true);
         edtavTrn_networkindividual_networkindividualcity_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualcity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualcity_Enabled), 5, 0), true);
         edtavTrn_networkindividual_networkindividualcountry_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualcountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualcountry_Enabled), 5, 0), true);
      }

      protected void RFBW2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E12BW2 ();
            WBBW0( ) ;
         }
      }

      protected void send_integrity_lvl_hashesBW2( )
      {
      }

      protected void before_start_formulas( )
      {
         cmbavTrn_networkindividual_networkindividualsalutation.Enabled = 0;
         AssignProp(sPrefix, false, cmbavTrn_networkindividual_networkindividualsalutation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTrn_networkindividual_networkindividualsalutation.Enabled), 5, 0), true);
         edtavTrn_networkindividual_networkindividualgivenname_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualgivenname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualgivenname_Enabled), 5, 0), true);
         edtavTrn_networkindividual_networkindividuallastname_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividuallastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividuallastname_Enabled), 5, 0), true);
         cmbavTrn_networkindividual_networkindividualgender.Enabled = 0;
         AssignProp(sPrefix, false, cmbavTrn_networkindividual_networkindividualgender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTrn_networkindividual_networkindividualgender.Enabled), 5, 0), true);
         cmbavTrn_networkindividual_networkindividualrelationship.Enabled = 0;
         AssignProp(sPrefix, false, cmbavTrn_networkindividual_networkindividualrelationship_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTrn_networkindividual_networkindividualrelationship.Enabled), 5, 0), true);
         edtavTrn_networkindividual_networkindividualemail_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualemail_Enabled), 5, 0), true);
         edtavTrn_networkindividual_networkindividualphone_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualphone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualphone_Enabled), 5, 0), true);
         edtavTrn_networkindividual_networkindividualhomephone_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualhomephone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualhomephone_Enabled), 5, 0), true);
         edtavTrn_networkindividual_networkindividualbsnnumber_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualbsnnumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualbsnnumber_Enabled), 5, 0), true);
         edtavTrn_networkindividual_networkindividualaddressline1_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualaddressline1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualaddressline1_Enabled), 5, 0), true);
         edtavTrn_networkindividual_networkindividualaddressline2_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualaddressline2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualaddressline2_Enabled), 5, 0), true);
         edtavTrn_networkindividual_networkindividualzipcode_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualzipcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualzipcode_Enabled), 5, 0), true);
         edtavTrn_networkindividual_networkindividualcity_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualcity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualcity_Enabled), 5, 0), true);
         edtavTrn_networkindividual_networkindividualcountry_Enabled = 0;
         AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualcountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualcountry_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUPBW0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11BW2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vTRN_NETWORKINDIVIDUAL"), AV6Trn_NetworkIndividual);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Trn_networkindividual"), AV6Trn_NetworkIndividual);
            /* Read saved values. */
            wcpOAV27ResidentId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV27ResidentId"));
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
         E11BW2 ();
         if (returnInSub) return;
      }

      protected void E11BW2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Using cursor H00BW2 */
         pr_default.execute(0, new Object[] {AV27ResidentId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A62ResidentId = H00BW2_A62ResidentId[0];
            A74NetworkIndividualId = H00BW2_A74NetworkIndividualId[0];
            AV6Trn_NetworkIndividual.Load(A74NetworkIndividualId);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         new prc_logtofile(context ).execute(  context.GetMessage( "Network Ind", "")+AV6Trn_NetworkIndividual.ToJSonString(true, true)) ;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp(sPrefix, false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         edtavTrn_networkindividual_networkindividualid_Visible = 0;
         AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualid_Visible), 5, 0), true);
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) ) )
         {
            edtavTrn_networkindividual_networkindividualphone_Visible = 0;
            AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualphone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualphone_Visible), 5, 0), true);
            divTrn_networkindividual_networkindividualphone_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divTrn_networkindividual_networkindividualphone_cell_Internalname, "Class", divTrn_networkindividual_networkindividualphone_cell_Class, true);
         }
         else
         {
            edtavTrn_networkindividual_networkindividualphone_Visible = 1;
            AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualphone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualphone_Visible), 5, 0), true);
            divTrn_networkindividual_networkindividualphone_cell_Class = "col-xs-12 DataContentCell";
            AssignProp(sPrefix, false, divTrn_networkindividual_networkindividualphone_cell_Internalname, "Class", divTrn_networkindividual_networkindividualphone_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) ) )
         {
            edtavTrn_networkindividual_networkindividualhomephone_Visible = 0;
            AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualhomephone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualhomephone_Visible), 5, 0), true);
            divTrn_networkindividual_networkindividualhomephone_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divTrn_networkindividual_networkindividualhomephone_cell_Internalname, "Class", divTrn_networkindividual_networkindividualhomephone_cell_Class, true);
         }
         else
         {
            edtavTrn_networkindividual_networkindividualhomephone_Visible = 1;
            AssignProp(sPrefix, false, edtavTrn_networkindividual_networkindividualhomephone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTrn_networkindividual_networkindividualhomephone_Visible), 5, 0), true);
            divTrn_networkindividual_networkindividualhomephone_cell_Class = "col-xs-12 DataContentCell";
            AssignProp(sPrefix, false, divTrn_networkindividual_networkindividualhomephone_cell_Internalname, "Class", divTrn_networkindividual_networkindividualhomephone_cell_Class, true);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E12BW2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV27ResidentId = (Guid)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV27ResidentId", AV27ResidentId.ToString());
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
         PABW2( ) ;
         WSBW2( ) ;
         WEBW2( ) ;
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
         sCtrlAV27ResidentId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PABW2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wc_networkindividual", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PABW2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV27ResidentId = (Guid)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV27ResidentId", AV27ResidentId.ToString());
         }
         wcpOAV27ResidentId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV27ResidentId"));
         if ( ! GetJustCreated( ) && ( ( AV27ResidentId != wcpOAV27ResidentId ) ) )
         {
            setjustcreated();
         }
         wcpOAV27ResidentId = AV27ResidentId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV27ResidentId = cgiGet( sPrefix+"AV27ResidentId_CTRL");
         if ( StringUtil.Len( sCtrlAV27ResidentId) > 0 )
         {
            AV27ResidentId = StringUtil.StrToGuid( cgiGet( sCtrlAV27ResidentId));
            AssignAttri(sPrefix, false, "AV27ResidentId", AV27ResidentId.ToString());
         }
         else
         {
            AV27ResidentId = StringUtil.StrToGuid( cgiGet( sPrefix+"AV27ResidentId_PARM"));
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
         PABW2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WSBW2( ) ;
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
         WSBW2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV27ResidentId_PARM", AV27ResidentId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV27ResidentId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV27ResidentId_CTRL", StringUtil.RTrim( sCtrlAV27ResidentId));
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
         WEBW2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20257616572228", true, true);
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
            context.AddJavascriptSource("wc_networkindividual.js", "?20257616572229", false, true);
         }
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavTrn_networkindividual_networkindividualsalutation.Name = "TRN_NETWORKINDIVIDUAL_NETWORKINDIVIDUALSALUTATION";
         cmbavTrn_networkindividual_networkindividualsalutation.WebTags = "";
         cmbavTrn_networkindividual_networkindividualsalutation.addItem("Mr", context.GetMessage( "Mr", ""), 0);
         cmbavTrn_networkindividual_networkindividualsalutation.addItem("Mrs", context.GetMessage( "Mrs", ""), 0);
         cmbavTrn_networkindividual_networkindividualsalutation.addItem("Dr", context.GetMessage( "Dr", ""), 0);
         cmbavTrn_networkindividual_networkindividualsalutation.addItem("Miss", context.GetMessage( "Miss", ""), 0);
         if ( cmbavTrn_networkindividual_networkindividualsalutation.ItemCount > 0 )
         {
         }
         cmbavTrn_networkindividual_networkindividualgender.Name = "TRN_NETWORKINDIVIDUAL_NETWORKINDIVIDUALGENDER";
         cmbavTrn_networkindividual_networkindividualgender.WebTags = "";
         cmbavTrn_networkindividual_networkindividualgender.addItem("Male", context.GetMessage( "Male", ""), 0);
         cmbavTrn_networkindividual_networkindividualgender.addItem("Female", context.GetMessage( "Female", ""), 0);
         cmbavTrn_networkindividual_networkindividualgender.addItem("Other", context.GetMessage( "Other", ""), 0);
         if ( cmbavTrn_networkindividual_networkindividualgender.ItemCount > 0 )
         {
         }
         cmbavTrn_networkindividual_networkindividualrelationship.Name = "TRN_NETWORKINDIVIDUAL_NETWORKINDIVIDUALRELATIONSHIP";
         cmbavTrn_networkindividual_networkindividualrelationship.WebTags = "";
         cmbavTrn_networkindividual_networkindividualrelationship.addItem("", context.GetMessage( "Other", ""), 0);
         cmbavTrn_networkindividual_networkindividualrelationship.addItem("Father", context.GetMessage( "Father", ""), 0);
         cmbavTrn_networkindividual_networkindividualrelationship.addItem("Mother", context.GetMessage( "Mother", ""), 0);
         cmbavTrn_networkindividual_networkindividualrelationship.addItem("Daughter", context.GetMessage( "Daughter", ""), 0);
         cmbavTrn_networkindividual_networkindividualrelationship.addItem("Son", context.GetMessage( "Son", ""), 0);
         cmbavTrn_networkindividual_networkindividualrelationship.addItem("Aunt", context.GetMessage( "Aunt", ""), 0);
         cmbavTrn_networkindividual_networkindividualrelationship.addItem("Uncle", context.GetMessage( "Uncle", ""), 0);
         cmbavTrn_networkindividual_networkindividualrelationship.addItem("GrandMother", context.GetMessage( "GrandMother", ""), 0);
         cmbavTrn_networkindividual_networkindividualrelationship.addItem("GrandFather", context.GetMessage( "GrandFather", ""), 0);
         cmbavTrn_networkindividual_networkindividualrelationship.addItem("Cousin", context.GetMessage( "Cousin", ""), 0);
         cmbavTrn_networkindividual_networkindividualrelationship.addItem("Friend", context.GetMessage( "Friend", ""), 0);
         if ( cmbavTrn_networkindividual_networkindividualrelationship.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         cmbavTrn_networkindividual_networkindividualsalutation_Internalname = sPrefix+"TRN_NETWORKINDIVIDUAL_NETWORKINDIVIDUALSALUTATION";
         edtavTrn_networkindividual_networkindividualgivenname_Internalname = sPrefix+"TRN_NETWORKINDIVIDUAL_NETWORKINDIVIDUALGIVENNAME";
         edtavTrn_networkindividual_networkindividuallastname_Internalname = sPrefix+"TRN_NETWORKINDIVIDUAL_NETWORKINDIVIDUALLASTNAME";
         cmbavTrn_networkindividual_networkindividualgender_Internalname = sPrefix+"TRN_NETWORKINDIVIDUAL_NETWORKINDIVIDUALGENDER";
         cmbavTrn_networkindividual_networkindividualrelationship_Internalname = sPrefix+"TRN_NETWORKINDIVIDUAL_NETWORKINDIVIDUALRELATIONSHIP";
         edtavTrn_networkindividual_networkindividualemail_Internalname = sPrefix+"TRN_NETWORKINDIVIDUAL_NETWORKINDIVIDUALEMAIL";
         edtavTrn_networkindividual_networkindividualphone_Internalname = sPrefix+"TRN_NETWORKINDIVIDUAL_NETWORKINDIVIDUALPHONE";
         divTrn_networkindividual_networkindividualphone_cell_Internalname = sPrefix+"TRN_NETWORKINDIVIDUAL_NETWORKINDIVIDUALPHONE_CELL";
         edtavTrn_networkindividual_networkindividualhomephone_Internalname = sPrefix+"TRN_NETWORKINDIVIDUAL_NETWORKINDIVIDUALHOMEPHONE";
         divTrn_networkindividual_networkindividualhomephone_cell_Internalname = sPrefix+"TRN_NETWORKINDIVIDUAL_NETWORKINDIVIDUALHOMEPHONE_CELL";
         edtavTrn_networkindividual_networkindividualbsnnumber_Internalname = sPrefix+"TRN_NETWORKINDIVIDUAL_NETWORKINDIVIDUALBSNNUMBER";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         grpNextofkininfogroup_Internalname = sPrefix+"NEXTOFKININFOGROUP";
         edtavTrn_networkindividual_networkindividualaddressline1_Internalname = sPrefix+"TRN_NETWORKINDIVIDUAL_NETWORKINDIVIDUALADDRESSLINE1";
         edtavTrn_networkindividual_networkindividualaddressline2_Internalname = sPrefix+"TRN_NETWORKINDIVIDUAL_NETWORKINDIVIDUALADDRESSLINE2";
         edtavTrn_networkindividual_networkindividualzipcode_Internalname = sPrefix+"TRN_NETWORKINDIVIDUAL_NETWORKINDIVIDUALZIPCODE";
         edtavTrn_networkindividual_networkindividualcity_Internalname = sPrefix+"TRN_NETWORKINDIVIDUAL_NETWORKINDIVIDUALCITY";
         edtavTrn_networkindividual_networkindividualcountry_Internalname = sPrefix+"TRN_NETWORKINDIVIDUAL_NETWORKINDIVIDUALCOUNTRY";
         divUnnamedtable2_Internalname = sPrefix+"UNNAMEDTABLE2";
         grpUnnamedgroup3_Internalname = sPrefix+"UNNAMEDGROUP3";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavTrn_networkindividual_networkindividualid_Internalname = sPrefix+"TRN_NETWORKINDIVIDUAL_NETWORKINDIVIDUALID";
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
         edtavTrn_networkindividual_networkindividualid_Jsonclick = "";
         edtavTrn_networkindividual_networkindividualid_Visible = 1;
         edtavTrn_networkindividual_networkindividualcountry_Jsonclick = "";
         edtavTrn_networkindividual_networkindividualcountry_Enabled = 0;
         edtavTrn_networkindividual_networkindividualcity_Jsonclick = "";
         edtavTrn_networkindividual_networkindividualcity_Enabled = 0;
         edtavTrn_networkindividual_networkindividualzipcode_Jsonclick = "";
         edtavTrn_networkindividual_networkindividualzipcode_Enabled = 0;
         edtavTrn_networkindividual_networkindividualaddressline2_Jsonclick = "";
         edtavTrn_networkindividual_networkindividualaddressline2_Enabled = 0;
         edtavTrn_networkindividual_networkindividualaddressline1_Jsonclick = "";
         edtavTrn_networkindividual_networkindividualaddressline1_Enabled = 0;
         edtavTrn_networkindividual_networkindividualbsnnumber_Jsonclick = "";
         edtavTrn_networkindividual_networkindividualbsnnumber_Enabled = 0;
         edtavTrn_networkindividual_networkindividualhomephone_Jsonclick = "";
         edtavTrn_networkindividual_networkindividualhomephone_Enabled = 0;
         edtavTrn_networkindividual_networkindividualhomephone_Visible = 1;
         divTrn_networkindividual_networkindividualhomephone_cell_Class = "col-xs-12";
         edtavTrn_networkindividual_networkindividualphone_Jsonclick = "";
         edtavTrn_networkindividual_networkindividualphone_Enabled = 0;
         edtavTrn_networkindividual_networkindividualphone_Visible = 1;
         divTrn_networkindividual_networkindividualphone_cell_Class = "col-xs-12";
         edtavTrn_networkindividual_networkindividualemail_Jsonclick = "";
         edtavTrn_networkindividual_networkindividualemail_Enabled = 0;
         cmbavTrn_networkindividual_networkindividualrelationship_Jsonclick = "";
         cmbavTrn_networkindividual_networkindividualrelationship.Enabled = 0;
         cmbavTrn_networkindividual_networkindividualgender_Jsonclick = "";
         cmbavTrn_networkindividual_networkindividualgender.Enabled = 0;
         edtavTrn_networkindividual_networkindividuallastname_Jsonclick = "";
         edtavTrn_networkindividual_networkindividuallastname_Enabled = 0;
         edtavTrn_networkindividual_networkindividualgivenname_Jsonclick = "";
         edtavTrn_networkindividual_networkindividualgivenname_Enabled = 0;
         cmbavTrn_networkindividual_networkindividualsalutation_Jsonclick = "";
         cmbavTrn_networkindividual_networkindividualsalutation.Enabled = 0;
         divLayoutmaintable_Class = "Table TableTransactionTemplate";
         edtavTrn_networkindividual_networkindividualcountry_Enabled = -1;
         edtavTrn_networkindividual_networkindividualcity_Enabled = -1;
         edtavTrn_networkindividual_networkindividualzipcode_Enabled = -1;
         edtavTrn_networkindividual_networkindividualaddressline2_Enabled = -1;
         edtavTrn_networkindividual_networkindividualaddressline1_Enabled = -1;
         edtavTrn_networkindividual_networkindividualbsnnumber_Enabled = -1;
         edtavTrn_networkindividual_networkindividualhomephone_Enabled = -1;
         edtavTrn_networkindividual_networkindividualphone_Enabled = -1;
         edtavTrn_networkindividual_networkindividualemail_Enabled = -1;
         cmbavTrn_networkindividual_networkindividualrelationship.Enabled = -1;
         cmbavTrn_networkindividual_networkindividualgender.Enabled = -1;
         edtavTrn_networkindividual_networkindividuallastname_Enabled = -1;
         edtavTrn_networkindividual_networkindividualgivenname_Enabled = -1;
         cmbavTrn_networkindividual_networkindividualsalutation.Enabled = -1;
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
         setEventMetadata("VALIDV_GXV1","""{"handler":"Validv_Gxv1","iparms":[]}""");
         setEventMetadata("VALIDV_GXV4","""{"handler":"Validv_Gxv4","iparms":[]}""");
         setEventMetadata("VALIDV_GXV6","""{"handler":"Validv_Gxv6","iparms":[]}""");
         setEventMetadata("VALIDV_GXV15","""{"handler":"Validv_Gxv15","iparms":[]}""");
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
         wcpOAV27ResidentId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV6Trn_NetworkIndividual = new SdtTrn_NetworkIndividual(context);
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
         H00BW2_A62ResidentId = new Guid[] {Guid.Empty} ;
         H00BW2_A74NetworkIndividualId = new Guid[] {Guid.Empty} ;
         A62ResidentId = Guid.Empty;
         A74NetworkIndividualId = Guid.Empty;
         Gx_mode = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV27ResidentId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wc_networkindividual__default(),
            new Object[][] {
                new Object[] {
               H00BW2_A62ResidentId, H00BW2_A74NetworkIndividualId
               }
            }
         );
         /* GeneXus formulas. */
         cmbavTrn_networkindividual_networkindividualsalutation.Enabled = 0;
         edtavTrn_networkindividual_networkindividualgivenname_Enabled = 0;
         edtavTrn_networkindividual_networkindividuallastname_Enabled = 0;
         cmbavTrn_networkindividual_networkindividualgender.Enabled = 0;
         cmbavTrn_networkindividual_networkindividualrelationship.Enabled = 0;
         edtavTrn_networkindividual_networkindividualemail_Enabled = 0;
         edtavTrn_networkindividual_networkindividualphone_Enabled = 0;
         edtavTrn_networkindividual_networkindividualhomephone_Enabled = 0;
         edtavTrn_networkindividual_networkindividualbsnnumber_Enabled = 0;
         edtavTrn_networkindividual_networkindividualaddressline1_Enabled = 0;
         edtavTrn_networkindividual_networkindividualaddressline2_Enabled = 0;
         edtavTrn_networkindividual_networkindividualzipcode_Enabled = 0;
         edtavTrn_networkindividual_networkindividualcity_Enabled = 0;
         edtavTrn_networkindividual_networkindividualcountry_Enabled = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private int edtavTrn_networkindividual_networkindividualgivenname_Enabled ;
      private int edtavTrn_networkindividual_networkindividuallastname_Enabled ;
      private int edtavTrn_networkindividual_networkindividualemail_Enabled ;
      private int edtavTrn_networkindividual_networkindividualphone_Enabled ;
      private int edtavTrn_networkindividual_networkindividualhomephone_Enabled ;
      private int edtavTrn_networkindividual_networkindividualbsnnumber_Enabled ;
      private int edtavTrn_networkindividual_networkindividualaddressline1_Enabled ;
      private int edtavTrn_networkindividual_networkindividualaddressline2_Enabled ;
      private int edtavTrn_networkindividual_networkindividualzipcode_Enabled ;
      private int edtavTrn_networkindividual_networkindividualcity_Enabled ;
      private int edtavTrn_networkindividual_networkindividualcountry_Enabled ;
      private int edtavTrn_networkindividual_networkindividualphone_Visible ;
      private int edtavTrn_networkindividual_networkindividualhomephone_Visible ;
      private int edtavTrn_networkindividual_networkindividualid_Visible ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string cmbavTrn_networkindividual_networkindividualsalutation_Internalname ;
      private string edtavTrn_networkindividual_networkindividualgivenname_Internalname ;
      private string edtavTrn_networkindividual_networkindividuallastname_Internalname ;
      private string cmbavTrn_networkindividual_networkindividualgender_Internalname ;
      private string cmbavTrn_networkindividual_networkindividualrelationship_Internalname ;
      private string edtavTrn_networkindividual_networkindividualemail_Internalname ;
      private string edtavTrn_networkindividual_networkindividualphone_Internalname ;
      private string edtavTrn_networkindividual_networkindividualhomephone_Internalname ;
      private string edtavTrn_networkindividual_networkindividualbsnnumber_Internalname ;
      private string edtavTrn_networkindividual_networkindividualaddressline1_Internalname ;
      private string edtavTrn_networkindividual_networkindividualaddressline2_Internalname ;
      private string edtavTrn_networkindividual_networkindividualzipcode_Internalname ;
      private string edtavTrn_networkindividual_networkindividualcity_Internalname ;
      private string edtavTrn_networkindividual_networkindividualcountry_Internalname ;
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
      private string grpNextofkininfogroup_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string TempTags ;
      private string cmbavTrn_networkindividual_networkindividualsalutation_Jsonclick ;
      private string edtavTrn_networkindividual_networkindividualgivenname_Jsonclick ;
      private string edtavTrn_networkindividual_networkindividuallastname_Jsonclick ;
      private string cmbavTrn_networkindividual_networkindividualgender_Jsonclick ;
      private string cmbavTrn_networkindividual_networkindividualrelationship_Jsonclick ;
      private string edtavTrn_networkindividual_networkindividualemail_Jsonclick ;
      private string divTrn_networkindividual_networkindividualphone_cell_Internalname ;
      private string divTrn_networkindividual_networkindividualphone_cell_Class ;
      private string edtavTrn_networkindividual_networkindividualphone_Jsonclick ;
      private string divTrn_networkindividual_networkindividualhomephone_cell_Internalname ;
      private string divTrn_networkindividual_networkindividualhomephone_cell_Class ;
      private string edtavTrn_networkindividual_networkindividualhomephone_Jsonclick ;
      private string edtavTrn_networkindividual_networkindividualbsnnumber_Jsonclick ;
      private string grpUnnamedgroup3_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string edtavTrn_networkindividual_networkindividualaddressline1_Jsonclick ;
      private string edtavTrn_networkindividual_networkindividualaddressline2_Jsonclick ;
      private string edtavTrn_networkindividual_networkindividualzipcode_Jsonclick ;
      private string edtavTrn_networkindividual_networkindividualcity_Jsonclick ;
      private string edtavTrn_networkindividual_networkindividualcountry_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavTrn_networkindividual_networkindividualid_Internalname ;
      private string edtavTrn_networkindividual_networkindividualid_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string sCtrlAV27ResidentId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private Guid AV27ResidentId ;
      private Guid wcpOAV27ResidentId ;
      private Guid A62ResidentId ;
      private Guid A74NetworkIndividualId ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavTrn_networkindividual_networkindividualsalutation ;
      private GXCombobox cmbavTrn_networkindividual_networkindividualgender ;
      private GXCombobox cmbavTrn_networkindividual_networkindividualrelationship ;
      private SdtTrn_NetworkIndividual AV6Trn_NetworkIndividual ;
      private IDataStoreProvider pr_default ;
      private Guid[] H00BW2_A62ResidentId ;
      private Guid[] H00BW2_A74NetworkIndividualId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wc_networkindividual__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00BW2;
          prmH00BW2 = new Object[] {
          new ParDef("AV27ResidentId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00BW2", "SELECT ResidentId, NetworkIndividualId FROM Trn_NetworkIndividual WHERE ResidentId = :AV27ResidentId ORDER BY NetworkIndividualId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BW2,100, GxCacheFrequency.OFF ,true,false )
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
                return;
       }
    }

 }

}
