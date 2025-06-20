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
   public class trn_residentgeneral : GXWebComponent
   {
      public trn_residentgeneral( )
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

      public trn_residentgeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ResidentId ,
                           Guid aP1_LocationId ,
                           Guid aP2_OrganisationId )
      {
         this.A62ResidentId = aP0_ResidentId;
         this.A29LocationId = aP1_LocationId;
         this.A11OrganisationId = aP2_OrganisationId;
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
         cmbResidentSalutation = new GXCombobox();
         cmbResidentGender = new GXCombobox();
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
                  A62ResidentId = StringUtil.StrToGuid( GetPar( "ResidentId"));
                  AssignAttri(sPrefix, false, "A62ResidentId", A62ResidentId.ToString());
                  A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
                  AssignAttri(sPrefix, false, "A29LocationId", A29LocationId.ToString());
                  A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  AssignAttri(sPrefix, false, "A11OrganisationId", A11OrganisationId.ToString());
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(Guid)A62ResidentId,(Guid)A29LocationId,(Guid)A11OrganisationId});
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
            PA5K2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV30Pgmname = "Trn_ResidentGeneral";
               edtavResidentphonecode_description_Enabled = 0;
               AssignProp(sPrefix, false, edtavResidentphonecode_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentphonecode_description_Enabled), 5, 0), true);
               edtavResidenthomephonecode_description_Enabled = 0;
               AssignProp(sPrefix, false, edtavResidenthomephonecode_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidenthomephonecode_description_Enabled), 5, 0), true);
               edtavResidentcountry_description_Enabled = 0;
               AssignProp(sPrefix, false, edtavResidentcountry_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentcountry_description_Enabled), 5, 0), true);
               WS5K2( ) ;
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
            context.SendWebValue( context.GetMessage( "Trn_Resident General", "")) ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-"+StringUtil.Substring( context.GetLanguageProperty( "culture"), 1, 2)+".js", "?"+context.GetBuildNumber( 1918140), false, true);
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
            GXEncryptionTmp = "trn_residentgeneral.aspx"+UrlEncode(A62ResidentId.ToString()) + "," + UrlEncode(A29LocationId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString());
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_residentgeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA62ResidentId", wcpOA62ResidentId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA29LocationId", wcpOA29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA11OrganisationId", wcpOA11OrganisationId.ToString());
      }

      protected void RenderHtmlCloseForm5K2( )
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
         return "Trn_ResidentGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Resident General", "") ;
      }

      protected void WB5K0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "trn_residentgeneral.aspx");
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
            GxWebStd.gx_group_start( context, grpTransactiondetail_residentinfogroup_Internalname, grpTransactiondetail_residentinfogroup_Caption, 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_ResidentGeneral.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbResidentSalutation_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbResidentSalutation_Internalname, context.GetMessage( "Salutation", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbResidentSalutation, cmbResidentSalutation_Internalname, StringUtil.RTrim( A72ResidentSalutation), 1, cmbResidentSalutation_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbResidentSalutation.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "", true, 0, "HLP_Trn_ResidentGeneral.htm");
            cmbResidentSalutation.CurrentValue = StringUtil.RTrim( A72ResidentSalutation);
            AssignProp(sPrefix, false, cmbResidentSalutation_Internalname, "Values", (string)(cmbResidentSalutation.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentGivenName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtResidentGivenName_Internalname, context.GetMessage( "First Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtResidentGivenName_Internalname, A64ResidentGivenName, StringUtil.RTrim( context.localUtil.Format( A64ResidentGivenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentGivenName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentGivenName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_ResidentGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentLastName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtResidentLastName_Internalname, context.GetMessage( "Last Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtResidentLastName_Internalname, A65ResidentLastName, StringUtil.RTrim( context.localUtil.Format( A65ResidentLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentLastName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentLastName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_ResidentGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbResidentGender_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbResidentGender_Internalname, context.GetMessage( "Gender", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbResidentGender, cmbResidentGender_Internalname, StringUtil.RTrim( A68ResidentGender), 1, cmbResidentGender_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbResidentGender.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "", true, 0, "HLP_Trn_ResidentGeneral.htm");
            cmbResidentGender.CurrentValue = StringUtil.RTrim( A68ResidentGender);
            AssignProp(sPrefix, false, cmbResidentGender_Internalname, "Values", (string)(cmbResidentGender.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentBirthDate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtResidentBirthDate_Internalname, context.GetMessage( "Birth Date", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtResidentBirthDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtResidentBirthDate_Internalname, context.localUtil.Format(A73ResidentBirthDate, "99/99/9999"), context.localUtil.Format( A73ResidentBirthDate, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,38);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentBirthDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentBirthDate_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_ResidentGeneral.htm");
            GxWebStd.gx_bitmap( context, edtResidentBirthDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtResidentBirthDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_ResidentGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentEmail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtResidentEmail_Internalname, context.GetMessage( "Email", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtResidentEmail_Internalname, A67ResidentEmail, StringUtil.RTrim( context.localUtil.Format( A67ResidentEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "mailto:"+A67ResidentEmail, "", "", "", edtResidentEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Trn_ResidentGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_phonenumber_Internalname, divTransactiondetail_phonenumber_Visible, 0, "px", 0, "px", "CellMarginBottom10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTransactiondetail_phonelabel_Internalname, context.GetMessage( "Mobile Phone", ""), "", "", lblTransactiondetail_phonelabel_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_Trn_ResidentGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable9_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable10_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 PhoneLabel", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentphonecode_description_Internalname, context.GetMessage( "Resident Phone Code_Description", ""), "col-sm-3 DropDownComponentLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentphonecode_description_Internalname, AV18ResidentPhoneCode_Description, StringUtil.RTrim( context.localUtil.Format( AV18ResidentPhoneCode_Description, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentphonecode_description_Jsonclick, 0, "DropDownComponent", "", "", "", "", 1, edtavResidentphonecode_description_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_ResidentGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtResidentPhoneNumber_Internalname, context.GetMessage( "Resident Phone Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtResidentPhoneNumber_Internalname, A348ResidentPhoneNumber, StringUtil.RTrim( context.localUtil.Format( A348ResidentPhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentPhoneNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentPhoneNumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_ResidentGeneral.htm");
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
            GxWebStd.gx_div_start( context, divTransactiondetail_homephonenumber_Internalname, divTransactiondetail_homephonenumber_Visible, 0, "px", 0, "px", "CellMarginBottom10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTransactiondetail_phone_Internalname, context.GetMessage( "Home Phone", ""), "", "", lblTransactiondetail_phone_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_Trn_ResidentGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable7_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable8_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 PhoneLabel", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidenthomephonecode_description_Internalname, context.GetMessage( "Resident Home Phone Code_Description", ""), "col-sm-3 DropDownComponentLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidenthomephonecode_description_Internalname, AV19ResidentHomePhoneCode_Description, StringUtil.RTrim( context.localUtil.Format( AV19ResidentHomePhoneCode_Description, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidenthomephonecode_description_Jsonclick, 0, "DropDownComponent", "", "", "", "", 1, edtavResidenthomephonecode_description_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_ResidentGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtResidentHomePhoneNumber_Internalname, context.GetMessage( "Resident Home Phone Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtResidentHomePhoneNumber_Internalname, A432ResidentHomePhoneNumber, StringUtil.RTrim( context.localUtil.Format( A432ResidentHomePhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentHomePhoneNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentHomePhoneNumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_ResidentGeneral.htm");
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
            GxWebStd.gx_div_start( context, divResidentphone_cell_Internalname, 1, 0, "px", 0, "px", divResidentphone_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtResidentPhone_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentPhone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtResidentPhone_Internalname, context.GetMessage( "Mobile Phone", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A70ResidentPhone);
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtResidentPhone_Internalname, StringUtil.RTrim( A70ResidentPhone), StringUtil.RTrim( context.localUtil.Format( A70ResidentPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtResidentPhone_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentPhone_Visible, edtResidentPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Trn_ResidentGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divResidenthomephone_cell_Internalname, 1, 0, "px", 0, "px", divResidenthomephone_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtResidentHomePhone_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentHomePhone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtResidentHomePhone_Internalname, context.GetMessage( "Home Phone", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A430ResidentHomePhone);
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtResidentHomePhone_Internalname, StringUtil.RTrim( A430ResidentHomePhone), StringUtil.RTrim( context.localUtil.Format( A430ResidentHomePhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtResidentHomePhone_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentHomePhone_Visible, edtResidentHomePhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Trn_ResidentGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentBsnNumber_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtResidentBsnNumber_Internalname, context.GetMessage( "BSN Number", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtResidentBsnNumber_Internalname, A63ResidentBsnNumber, StringUtil.RTrim( context.localUtil.Format( A63ResidentBsnNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentBsnNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentBsnNumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "BsnNumber", "start", true, "", "HLP_Trn_ResidentGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup4_Internalname, context.GetMessage( "Address Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_ResidentGeneral.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentAddressLine1_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtResidentAddressLine1_Internalname, context.GetMessage( "Address Line 1", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtResidentAddressLine1_Internalname, A315ResidentAddressLine1, StringUtil.RTrim( context.localUtil.Format( A315ResidentAddressLine1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,105);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentAddressLine1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentAddressLine1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_ResidentGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentAddressLine2_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtResidentAddressLine2_Internalname, context.GetMessage( "Address Line 2", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtResidentAddressLine2_Internalname, A316ResidentAddressLine2, StringUtil.RTrim( context.localUtil.Format( A316ResidentAddressLine2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,110);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentAddressLine2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentAddressLine2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_ResidentGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentZipCode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtResidentZipCode_Internalname, context.GetMessage( "Zip Code", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtResidentZipCode_Internalname, A314ResidentZipCode, StringUtil.RTrim( context.localUtil.Format( A314ResidentZipCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,115);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentZipCode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentZipCode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_ResidentGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentCity_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtResidentCity_Internalname, context.GetMessage( "City", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtResidentCity_Internalname, A313ResidentCity, StringUtil.RTrim( context.localUtil.Format( A313ResidentCity, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,120);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentCity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentCity_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_ResidentGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentcountry_description_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentcountry_description_Internalname, context.GetMessage( "Country", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentcountry_description_Internalname, AV15ResidentCountry_Description, StringUtil.RTrim( context.localUtil.Format( AV15ResidentCountry_Description, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,125);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentcountry_description_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentcountry_description_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_ResidentGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup6_Internalname, context.GetMessage( "Provisioning Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_ResidentGeneral.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable5_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentTypeName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtResidentTypeName_Internalname, context.GetMessage( "Resident Type", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtResidentTypeName_Internalname, A97ResidentTypeName, StringUtil.RTrim( context.localUtil.Format( A97ResidentTypeName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,134);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtResidentTypeName_Link, "", "", "", edtResidentTypeName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentTypeName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_ResidentGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentPackageName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtResidentPackageName_Internalname, context.GetMessage( "Access Rights Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtResidentPackageName_Internalname, A531ResidentPackageName, StringUtil.RTrim( context.localUtil.Format( A531ResidentPackageName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,139);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtResidentPackageName_Link, "", "", "", edtResidentPackageName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentPackageName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_ResidentGeneral.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtncancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ResidentGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtSG_OrganisationId_Internalname, A529SG_OrganisationId.ToString(), A529SG_OrganisationId.ToString(), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSG_OrganisationId_Jsonclick, 0, "Attribute", "", "", "", "", edtSG_OrganisationId_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_ResidentGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtSG_LocationId_Internalname, A528SG_LocationId.ToString(), A528SG_LocationId.ToString(), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSG_LocationId_Jsonclick, 0, "Attribute", "", "", "", "", edtSG_LocationId_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_ResidentGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtResidentId_Internalname, A62ResidentId.ToString(), A62ResidentId.ToString(), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentId_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentId_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_ResidentGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtLocationId_Internalname, A29LocationId.ToString(), A29LocationId.ToString(), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationId_Jsonclick, 0, "Attribute", "", "", "", "", edtLocationId_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_ResidentGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtOrganisationId_Internalname, A11OrganisationId.ToString(), A11OrganisationId.ToString(), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationId_Jsonclick, 0, "Attribute", "", "", "", "", edtOrganisationId_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_ResidentGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtResidentInitials_Internalname, StringUtil.RTrim( A66ResidentInitials), StringUtil.RTrim( context.localUtil.Format( A66ResidentInitials, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentInitials_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentInitials_Visible, 0, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_ResidentGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtResidentGUID_Internalname, A71ResidentGUID, StringUtil.RTrim( context.localUtil.Format( A71ResidentGUID, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentGUID_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentGUID_Visible, 0, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_Trn_ResidentGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMedicalIndicationId_Internalname, A98MedicalIndicationId.ToString(), A98MedicalIndicationId.ToString(), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMedicalIndicationId_Jsonclick, 0, "Attribute", "", "", "", "", edtMedicalIndicationId_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_ResidentGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START5K2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Trn_Resident General", ""), 0) ;
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
               STRUP5K0( ) ;
            }
         }
      }

      protected void WS5K2( )
      {
         START5K2( ) ;
         EVT5K2( ) ;
      }

      protected void EVT5K2( )
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
                                 STRUP5K0( ) ;
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
                                 STRUP5K0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E115K2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5K0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E125K2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5K0( ) ;
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
                                 STRUP5K0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavResidentphonecode_description_Internalname;
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

      protected void WE5K2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm5K2( ) ;
            }
         }
      }

      protected void PA5K2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_residentgeneral.aspx")), "trn_residentgeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_residentgeneral.aspx")))) ;
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
               GX_FocusControl = edtavResidentphonecode_description_Internalname;
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
         if ( cmbResidentSalutation.ItemCount > 0 )
         {
            A72ResidentSalutation = cmbResidentSalutation.getValidValue(A72ResidentSalutation);
            AssignAttri(sPrefix, false, "A72ResidentSalutation", A72ResidentSalutation);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbResidentSalutation.CurrentValue = StringUtil.RTrim( A72ResidentSalutation);
            AssignProp(sPrefix, false, cmbResidentSalutation_Internalname, "Values", cmbResidentSalutation.ToJavascriptSource(), true);
         }
         if ( cmbResidentGender.ItemCount > 0 )
         {
            A68ResidentGender = cmbResidentGender.getValidValue(A68ResidentGender);
            AssignAttri(sPrefix, false, "A68ResidentGender", A68ResidentGender);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbResidentGender.CurrentValue = StringUtil.RTrim( A68ResidentGender);
            AssignProp(sPrefix, false, cmbResidentGender_Internalname, "Values", cmbResidentGender.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5K2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV30Pgmname = "Trn_ResidentGeneral";
         edtavResidentphonecode_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavResidentphonecode_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentphonecode_description_Enabled), 5, 0), true);
         edtavResidenthomephonecode_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavResidenthomephonecode_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidenthomephonecode_description_Enabled), 5, 0), true);
         edtavResidentcountry_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavResidentcountry_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentcountry_description_Enabled), 5, 0), true);
      }

      protected void RF5K2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H005K2 */
            pr_default.execute(0, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A96ResidentTypeId = H005K2_A96ResidentTypeId[0];
               n96ResidentTypeId = H005K2_n96ResidentTypeId[0];
               A527ResidentPackageId = H005K2_A527ResidentPackageId[0];
               n527ResidentPackageId = H005K2_n527ResidentPackageId[0];
               A98MedicalIndicationId = H005K2_A98MedicalIndicationId[0];
               n98MedicalIndicationId = H005K2_n98MedicalIndicationId[0];
               AssignAttri(sPrefix, false, "A98MedicalIndicationId", A98MedicalIndicationId.ToString());
               A71ResidentGUID = H005K2_A71ResidentGUID[0];
               AssignAttri(sPrefix, false, "A71ResidentGUID", A71ResidentGUID);
               A66ResidentInitials = H005K2_A66ResidentInitials[0];
               AssignAttri(sPrefix, false, "A66ResidentInitials", A66ResidentInitials);
               A528SG_LocationId = H005K2_A528SG_LocationId[0];
               AssignAttri(sPrefix, false, "A528SG_LocationId", A528SG_LocationId.ToString());
               A529SG_OrganisationId = H005K2_A529SG_OrganisationId[0];
               AssignAttri(sPrefix, false, "A529SG_OrganisationId", A529SG_OrganisationId.ToString());
               A531ResidentPackageName = H005K2_A531ResidentPackageName[0];
               AssignAttri(sPrefix, false, "A531ResidentPackageName", A531ResidentPackageName);
               A97ResidentTypeName = H005K2_A97ResidentTypeName[0];
               AssignAttri(sPrefix, false, "A97ResidentTypeName", A97ResidentTypeName);
               A313ResidentCity = H005K2_A313ResidentCity[0];
               AssignAttri(sPrefix, false, "A313ResidentCity", A313ResidentCity);
               A314ResidentZipCode = H005K2_A314ResidentZipCode[0];
               AssignAttri(sPrefix, false, "A314ResidentZipCode", A314ResidentZipCode);
               A316ResidentAddressLine2 = H005K2_A316ResidentAddressLine2[0];
               AssignAttri(sPrefix, false, "A316ResidentAddressLine2", A316ResidentAddressLine2);
               A315ResidentAddressLine1 = H005K2_A315ResidentAddressLine1[0];
               AssignAttri(sPrefix, false, "A315ResidentAddressLine1", A315ResidentAddressLine1);
               A63ResidentBsnNumber = H005K2_A63ResidentBsnNumber[0];
               AssignAttri(sPrefix, false, "A63ResidentBsnNumber", A63ResidentBsnNumber);
               A430ResidentHomePhone = H005K2_A430ResidentHomePhone[0];
               AssignAttri(sPrefix, false, "A430ResidentHomePhone", A430ResidentHomePhone);
               A70ResidentPhone = H005K2_A70ResidentPhone[0];
               AssignAttri(sPrefix, false, "A70ResidentPhone", A70ResidentPhone);
               A432ResidentHomePhoneNumber = H005K2_A432ResidentHomePhoneNumber[0];
               AssignAttri(sPrefix, false, "A432ResidentHomePhoneNumber", A432ResidentHomePhoneNumber);
               A348ResidentPhoneNumber = H005K2_A348ResidentPhoneNumber[0];
               AssignAttri(sPrefix, false, "A348ResidentPhoneNumber", A348ResidentPhoneNumber);
               A67ResidentEmail = H005K2_A67ResidentEmail[0];
               AssignAttri(sPrefix, false, "A67ResidentEmail", A67ResidentEmail);
               A73ResidentBirthDate = H005K2_A73ResidentBirthDate[0];
               AssignAttri(sPrefix, false, "A73ResidentBirthDate", context.localUtil.Format(A73ResidentBirthDate, "99/99/9999"));
               A68ResidentGender = H005K2_A68ResidentGender[0];
               AssignAttri(sPrefix, false, "A68ResidentGender", A68ResidentGender);
               A65ResidentLastName = H005K2_A65ResidentLastName[0];
               AssignAttri(sPrefix, false, "A65ResidentLastName", A65ResidentLastName);
               A64ResidentGivenName = H005K2_A64ResidentGivenName[0];
               AssignAttri(sPrefix, false, "A64ResidentGivenName", A64ResidentGivenName);
               A72ResidentSalutation = H005K2_A72ResidentSalutation[0];
               AssignAttri(sPrefix, false, "A72ResidentSalutation", A72ResidentSalutation);
               A97ResidentTypeName = H005K2_A97ResidentTypeName[0];
               AssignAttri(sPrefix, false, "A97ResidentTypeName", A97ResidentTypeName);
               A528SG_LocationId = H005K2_A528SG_LocationId[0];
               AssignAttri(sPrefix, false, "A528SG_LocationId", A528SG_LocationId.ToString());
               A529SG_OrganisationId = H005K2_A529SG_OrganisationId[0];
               AssignAttri(sPrefix, false, "A529SG_OrganisationId", A529SG_OrganisationId.ToString());
               A531ResidentPackageName = H005K2_A531ResidentPackageName[0];
               AssignAttri(sPrefix, false, "A531ResidentPackageName", A531ResidentPackageName);
               /* Execute user event: Load */
               E125K2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB5K0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes5K2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV30Pgmname = "Trn_ResidentGeneral";
         edtavResidentphonecode_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavResidentphonecode_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentphonecode_description_Enabled), 5, 0), true);
         edtavResidenthomephonecode_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavResidenthomephonecode_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidenthomephonecode_description_Enabled), 5, 0), true);
         edtavResidentcountry_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavResidentcountry_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentcountry_description_Enabled), 5, 0), true);
         cmbResidentSalutation.Enabled = 0;
         AssignProp(sPrefix, false, cmbResidentSalutation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbResidentSalutation.Enabled), 5, 0), true);
         edtResidentGivenName_Enabled = 0;
         AssignProp(sPrefix, false, edtResidentGivenName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentGivenName_Enabled), 5, 0), true);
         edtResidentLastName_Enabled = 0;
         AssignProp(sPrefix, false, edtResidentLastName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentLastName_Enabled), 5, 0), true);
         cmbResidentGender.Enabled = 0;
         AssignProp(sPrefix, false, cmbResidentGender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbResidentGender.Enabled), 5, 0), true);
         edtResidentBirthDate_Enabled = 0;
         AssignProp(sPrefix, false, edtResidentBirthDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentBirthDate_Enabled), 5, 0), true);
         edtResidentEmail_Enabled = 0;
         AssignProp(sPrefix, false, edtResidentEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentEmail_Enabled), 5, 0), true);
         edtResidentPhoneNumber_Enabled = 0;
         AssignProp(sPrefix, false, edtResidentPhoneNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentPhoneNumber_Enabled), 5, 0), true);
         edtResidentHomePhoneNumber_Enabled = 0;
         AssignProp(sPrefix, false, edtResidentHomePhoneNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentHomePhoneNumber_Enabled), 5, 0), true);
         edtResidentPhone_Enabled = 0;
         AssignProp(sPrefix, false, edtResidentPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentPhone_Enabled), 5, 0), true);
         edtResidentHomePhone_Enabled = 0;
         AssignProp(sPrefix, false, edtResidentHomePhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentHomePhone_Enabled), 5, 0), true);
         edtResidentBsnNumber_Enabled = 0;
         AssignProp(sPrefix, false, edtResidentBsnNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentBsnNumber_Enabled), 5, 0), true);
         edtResidentAddressLine1_Enabled = 0;
         AssignProp(sPrefix, false, edtResidentAddressLine1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentAddressLine1_Enabled), 5, 0), true);
         edtResidentAddressLine2_Enabled = 0;
         AssignProp(sPrefix, false, edtResidentAddressLine2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentAddressLine2_Enabled), 5, 0), true);
         edtResidentZipCode_Enabled = 0;
         AssignProp(sPrefix, false, edtResidentZipCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentZipCode_Enabled), 5, 0), true);
         edtResidentCity_Enabled = 0;
         AssignProp(sPrefix, false, edtResidentCity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentCity_Enabled), 5, 0), true);
         edtResidentTypeName_Enabled = 0;
         AssignProp(sPrefix, false, edtResidentTypeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentTypeName_Enabled), 5, 0), true);
         edtResidentPackageName_Enabled = 0;
         AssignProp(sPrefix, false, edtResidentPackageName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentPackageName_Enabled), 5, 0), true);
         edtSG_OrganisationId_Enabled = 0;
         AssignProp(sPrefix, false, edtSG_OrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSG_OrganisationId_Enabled), 5, 0), true);
         edtSG_LocationId_Enabled = 0;
         AssignProp(sPrefix, false, edtSG_LocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSG_LocationId_Enabled), 5, 0), true);
         edtResidentId_Enabled = 0;
         AssignProp(sPrefix, false, edtResidentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentId_Enabled), 5, 0), true);
         edtLocationId_Enabled = 0;
         AssignProp(sPrefix, false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         edtOrganisationId_Enabled = 0;
         AssignProp(sPrefix, false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         edtResidentInitials_Enabled = 0;
         AssignProp(sPrefix, false, edtResidentInitials_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentInitials_Enabled), 5, 0), true);
         edtResidentGUID_Enabled = 0;
         AssignProp(sPrefix, false, edtResidentGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentGUID_Enabled), 5, 0), true);
         edtMedicalIndicationId_Enabled = 0;
         AssignProp(sPrefix, false, edtMedicalIndicationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMedicalIndicationId_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5K0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E115K2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA62ResidentId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA62ResidentId"));
            wcpOA29LocationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA29LocationId"));
            wcpOA11OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA11OrganisationId"));
            /* Read variables values. */
            cmbResidentSalutation.CurrentValue = cgiGet( cmbResidentSalutation_Internalname);
            A72ResidentSalutation = cgiGet( cmbResidentSalutation_Internalname);
            AssignAttri(sPrefix, false, "A72ResidentSalutation", A72ResidentSalutation);
            A64ResidentGivenName = cgiGet( edtResidentGivenName_Internalname);
            AssignAttri(sPrefix, false, "A64ResidentGivenName", A64ResidentGivenName);
            A65ResidentLastName = cgiGet( edtResidentLastName_Internalname);
            AssignAttri(sPrefix, false, "A65ResidentLastName", A65ResidentLastName);
            cmbResidentGender.CurrentValue = cgiGet( cmbResidentGender_Internalname);
            A68ResidentGender = cgiGet( cmbResidentGender_Internalname);
            AssignAttri(sPrefix, false, "A68ResidentGender", A68ResidentGender);
            A73ResidentBirthDate = context.localUtil.CToD( cgiGet( edtResidentBirthDate_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            AssignAttri(sPrefix, false, "A73ResidentBirthDate", context.localUtil.Format(A73ResidentBirthDate, "99/99/9999"));
            A67ResidentEmail = cgiGet( edtResidentEmail_Internalname);
            AssignAttri(sPrefix, false, "A67ResidentEmail", A67ResidentEmail);
            AV18ResidentPhoneCode_Description = cgiGet( edtavResidentphonecode_description_Internalname);
            AssignAttri(sPrefix, false, "AV18ResidentPhoneCode_Description", AV18ResidentPhoneCode_Description);
            A348ResidentPhoneNumber = cgiGet( edtResidentPhoneNumber_Internalname);
            AssignAttri(sPrefix, false, "A348ResidentPhoneNumber", A348ResidentPhoneNumber);
            AV19ResidentHomePhoneCode_Description = cgiGet( edtavResidenthomephonecode_description_Internalname);
            AssignAttri(sPrefix, false, "AV19ResidentHomePhoneCode_Description", AV19ResidentHomePhoneCode_Description);
            A432ResidentHomePhoneNumber = cgiGet( edtResidentHomePhoneNumber_Internalname);
            AssignAttri(sPrefix, false, "A432ResidentHomePhoneNumber", A432ResidentHomePhoneNumber);
            A70ResidentPhone = cgiGet( edtResidentPhone_Internalname);
            AssignAttri(sPrefix, false, "A70ResidentPhone", A70ResidentPhone);
            A430ResidentHomePhone = cgiGet( edtResidentHomePhone_Internalname);
            AssignAttri(sPrefix, false, "A430ResidentHomePhone", A430ResidentHomePhone);
            A63ResidentBsnNumber = cgiGet( edtResidentBsnNumber_Internalname);
            AssignAttri(sPrefix, false, "A63ResidentBsnNumber", A63ResidentBsnNumber);
            A315ResidentAddressLine1 = cgiGet( edtResidentAddressLine1_Internalname);
            AssignAttri(sPrefix, false, "A315ResidentAddressLine1", A315ResidentAddressLine1);
            A316ResidentAddressLine2 = cgiGet( edtResidentAddressLine2_Internalname);
            AssignAttri(sPrefix, false, "A316ResidentAddressLine2", A316ResidentAddressLine2);
            A314ResidentZipCode = cgiGet( edtResidentZipCode_Internalname);
            AssignAttri(sPrefix, false, "A314ResidentZipCode", A314ResidentZipCode);
            A313ResidentCity = cgiGet( edtResidentCity_Internalname);
            AssignAttri(sPrefix, false, "A313ResidentCity", A313ResidentCity);
            AV15ResidentCountry_Description = cgiGet( edtavResidentcountry_description_Internalname);
            AssignAttri(sPrefix, false, "AV15ResidentCountry_Description", AV15ResidentCountry_Description);
            A97ResidentTypeName = cgiGet( edtResidentTypeName_Internalname);
            AssignAttri(sPrefix, false, "A97ResidentTypeName", A97ResidentTypeName);
            A531ResidentPackageName = cgiGet( edtResidentPackageName_Internalname);
            AssignAttri(sPrefix, false, "A531ResidentPackageName", A531ResidentPackageName);
            A529SG_OrganisationId = StringUtil.StrToGuid( cgiGet( edtSG_OrganisationId_Internalname));
            AssignAttri(sPrefix, false, "A529SG_OrganisationId", A529SG_OrganisationId.ToString());
            A528SG_LocationId = StringUtil.StrToGuid( cgiGet( edtSG_LocationId_Internalname));
            AssignAttri(sPrefix, false, "A528SG_LocationId", A528SG_LocationId.ToString());
            A66ResidentInitials = cgiGet( edtResidentInitials_Internalname);
            AssignAttri(sPrefix, false, "A66ResidentInitials", A66ResidentInitials);
            A71ResidentGUID = cgiGet( edtResidentGUID_Internalname);
            AssignAttri(sPrefix, false, "A71ResidentGUID", A71ResidentGUID);
            A98MedicalIndicationId = StringUtil.StrToGuid( cgiGet( edtMedicalIndicationId_Internalname));
            n98MedicalIndicationId = false;
            AssignAttri(sPrefix, false, "A98MedicalIndicationId", A98MedicalIndicationId.ToString());
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
         E115K2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E115K2( )
      {
         /* Start Routine */
         returnInSub = false;
         Gx_mode = "DSP";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         GXt_objcol_SdtDVB_SDTComboData_Item1 = AV21Combo_Data;
         new trn_residentloaddvcombo(context ).execute(  "ResidentCountry",  "GET_DSC",  A62ResidentId,  A29LocationId,  A11OrganisationId, out  AV17ComboSelectedValue, out  AV15ResidentCountry_Description, out  GXt_objcol_SdtDVB_SDTComboData_Item1) ;
         AssignAttri(sPrefix, false, "AV15ResidentCountry_Description", AV15ResidentCountry_Description);
         AV21Combo_Data = GXt_objcol_SdtDVB_SDTComboData_Item1;
         GXt_objcol_SdtDVB_SDTComboData_Item1 = AV21Combo_Data;
         new trn_residentloaddvcombo(context ).execute(  "ResidentHomePhoneCode",  "GET_DSC",  A62ResidentId,  A29LocationId,  A11OrganisationId, out  AV17ComboSelectedValue, out  AV19ResidentHomePhoneCode_Description, out  GXt_objcol_SdtDVB_SDTComboData_Item1) ;
         AssignAttri(sPrefix, false, "AV19ResidentHomePhoneCode_Description", AV19ResidentHomePhoneCode_Description);
         AV21Combo_Data = GXt_objcol_SdtDVB_SDTComboData_Item1;
         GXt_objcol_SdtDVB_SDTComboData_Item1 = AV21Combo_Data;
         new trn_residentloaddvcombo(context ).execute(  "ResidentPhoneCode",  "GET_DSC",  A62ResidentId,  A29LocationId,  A11OrganisationId, out  AV17ComboSelectedValue, out  AV18ResidentPhoneCode_Description, out  GXt_objcol_SdtDVB_SDTComboData_Item1) ;
         AssignAttri(sPrefix, false, "AV18ResidentPhoneCode_Description", AV18ResidentPhoneCode_Description);
         AV21Combo_Data = GXt_objcol_SdtDVB_SDTComboData_Item1;
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         GXt_char2 = AV28ResidentTitle;
         new prc_getorganisationdefinition(context ).execute(  "Resident", out  GXt_char2) ;
         AV28ResidentTitle = GXt_char2;
         grpTransactiondetail_residentinfogroup_Caption = AV28ResidentTitle+" "+context.GetMessage( "Information", "");
         AssignProp(sPrefix, false, grpTransactiondetail_residentinfogroup_Internalname, "Caption", grpTransactiondetail_residentinfogroup_Caption, true);
      }

      protected void nextLoad( )
      {
      }

      protected void E125K2( )
      {
         /* Load Routine */
         returnInSub = false;
         GXt_boolean3 = AV14TempBoolean;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_residenttypeview_Execute", out  GXt_boolean3) ;
         AV14TempBoolean = GXt_boolean3;
         if ( AV14TempBoolean )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_residenttypeview.aspx"+UrlEncode(A96ResidentTypeId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            edtResidentTypeName_Link = formatLink("trn_residenttypeview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AssignProp(sPrefix, false, edtResidentTypeName_Internalname, "Link", edtResidentTypeName_Link, true);
         }
         GXt_boolean3 = AV14TempBoolean;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_residentpackageview_Execute", out  GXt_boolean3) ;
         AV14TempBoolean = GXt_boolean3;
         if ( AV14TempBoolean )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_residentpackageview.aspx"+UrlEncode(A527ResidentPackageId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            edtResidentPackageName_Link = formatLink("trn_residentpackageview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AssignProp(sPrefix, false, edtResidentPackageName_Internalname, "Link", edtResidentPackageName_Link, true);
         }
         edtSG_OrganisationId_Visible = 0;
         AssignProp(sPrefix, false, edtSG_OrganisationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSG_OrganisationId_Visible), 5, 0), true);
         edtSG_LocationId_Visible = 0;
         AssignProp(sPrefix, false, edtSG_LocationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSG_LocationId_Visible), 5, 0), true);
         edtResidentId_Visible = 0;
         AssignProp(sPrefix, false, edtResidentId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentId_Visible), 5, 0), true);
         edtLocationId_Visible = 0;
         AssignProp(sPrefix, false, edtLocationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLocationId_Visible), 5, 0), true);
         edtOrganisationId_Visible = 0;
         AssignProp(sPrefix, false, edtOrganisationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Visible), 5, 0), true);
         edtResidentInitials_Visible = 0;
         AssignProp(sPrefix, false, edtResidentInitials_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentInitials_Visible), 5, 0), true);
         edtResidentGUID_Visible = 0;
         AssignProp(sPrefix, false, edtResidentGUID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentGUID_Visible), 5, 0), true);
         edtMedicalIndicationId_Visible = 0;
         AssignProp(sPrefix, false, edtMedicalIndicationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMedicalIndicationId_Visible), 5, 0), true);
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) ) )
         {
            edtResidentPhone_Visible = 0;
            AssignProp(sPrefix, false, edtResidentPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentPhone_Visible), 5, 0), true);
            divResidentphone_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divResidentphone_cell_Internalname, "Class", divResidentphone_cell_Class, true);
         }
         else
         {
            edtResidentPhone_Visible = 1;
            AssignProp(sPrefix, false, edtResidentPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentPhone_Visible), 5, 0), true);
            divResidentphone_cell_Class = "col-xs-12 DataContentCell";
            AssignProp(sPrefix, false, divResidentphone_cell_Internalname, "Class", divResidentphone_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) ) )
         {
            edtResidentHomePhone_Visible = 0;
            AssignProp(sPrefix, false, edtResidentHomePhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentHomePhone_Visible), 5, 0), true);
            divResidenthomephone_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divResidenthomephone_cell_Internalname, "Class", divResidenthomephone_cell_Class, true);
         }
         else
         {
            edtResidentHomePhone_Visible = 1;
            AssignProp(sPrefix, false, edtResidentHomePhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentHomePhone_Visible), 5, 0), true);
            divResidenthomephone_cell_Class = "col-xs-12 DataContentCell";
            AssignProp(sPrefix, false, divResidenthomephone_cell_Internalname, "Class", divResidenthomephone_cell_Class, true);
         }
         divTransactiondetail_phonenumber_Visible = (((StringUtil.StrCmp(Gx_mode, "INS")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0)) ? 1 : 0);
         AssignProp(sPrefix, false, divTransactiondetail_phonenumber_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTransactiondetail_phonenumber_Visible), 5, 0), true);
         divTransactiondetail_homephonenumber_Visible = (((StringUtil.StrCmp(Gx_mode, "INS")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0)) ? 1 : 0);
         AssignProp(sPrefix, false, divTransactiondetail_homephonenumber_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTransactiondetail_homephonenumber_Visible), 5, 0), true);
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV30Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Trn_Resident";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A62ResidentId = (Guid)getParm(obj,0);
         AssignAttri(sPrefix, false, "A62ResidentId", A62ResidentId.ToString());
         A29LocationId = (Guid)getParm(obj,1);
         AssignAttri(sPrefix, false, "A29LocationId", A29LocationId.ToString());
         A11OrganisationId = (Guid)getParm(obj,2);
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
         PA5K2( ) ;
         WS5K2( ) ;
         WE5K2( ) ;
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
         sCtrlA62ResidentId = (string)((string)getParm(obj,0));
         sCtrlA29LocationId = (string)((string)getParm(obj,1));
         sCtrlA11OrganisationId = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA5K2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "trn_residentgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA5K2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A62ResidentId = (Guid)getParm(obj,2);
            AssignAttri(sPrefix, false, "A62ResidentId", A62ResidentId.ToString());
            A29LocationId = (Guid)getParm(obj,3);
            AssignAttri(sPrefix, false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = (Guid)getParm(obj,4);
            AssignAttri(sPrefix, false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         wcpOA62ResidentId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA62ResidentId"));
         wcpOA29LocationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA29LocationId"));
         wcpOA11OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA11OrganisationId"));
         if ( ! GetJustCreated( ) && ( ( A62ResidentId != wcpOA62ResidentId ) || ( A29LocationId != wcpOA29LocationId ) || ( A11OrganisationId != wcpOA11OrganisationId ) ) )
         {
            setjustcreated();
         }
         wcpOA62ResidentId = A62ResidentId;
         wcpOA29LocationId = A29LocationId;
         wcpOA11OrganisationId = A11OrganisationId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA62ResidentId = cgiGet( sPrefix+"A62ResidentId_CTRL");
         if ( StringUtil.Len( sCtrlA62ResidentId) > 0 )
         {
            A62ResidentId = StringUtil.StrToGuid( cgiGet( sCtrlA62ResidentId));
            AssignAttri(sPrefix, false, "A62ResidentId", A62ResidentId.ToString());
         }
         else
         {
            A62ResidentId = StringUtil.StrToGuid( cgiGet( sPrefix+"A62ResidentId_PARM"));
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
         PA5K2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS5K2( ) ;
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
         WS5K2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A62ResidentId_PARM", A62ResidentId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA62ResidentId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A62ResidentId_CTRL", StringUtil.RTrim( sCtrlA62ResidentId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"A29LocationId_PARM", A29LocationId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA29LocationId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A29LocationId_CTRL", StringUtil.RTrim( sCtrlA29LocationId));
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
         WE5K2( ) ;
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
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256201657181", true, true);
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
         context.AddJavascriptSource("trn_residentgeneral.js", "?20256201657181", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbResidentSalutation.Name = "RESIDENTSALUTATION";
         cmbResidentSalutation.WebTags = "";
         cmbResidentSalutation.addItem("Mr", context.GetMessage( "Mr", ""), 0);
         cmbResidentSalutation.addItem("Mrs", context.GetMessage( "Mrs", ""), 0);
         cmbResidentSalutation.addItem("Dr", context.GetMessage( "Dr", ""), 0);
         cmbResidentSalutation.addItem("Miss", context.GetMessage( "Miss", ""), 0);
         if ( cmbResidentSalutation.ItemCount > 0 )
         {
         }
         cmbResidentGender.Name = "RESIDENTGENDER";
         cmbResidentGender.WebTags = "";
         cmbResidentGender.addItem("Male", context.GetMessage( "Male", ""), 0);
         cmbResidentGender.addItem("Female", context.GetMessage( "Female", ""), 0);
         cmbResidentGender.addItem("Other", context.GetMessage( "Other", ""), 0);
         if ( cmbResidentGender.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         cmbResidentSalutation_Internalname = sPrefix+"RESIDENTSALUTATION";
         edtResidentGivenName_Internalname = sPrefix+"RESIDENTGIVENNAME";
         edtResidentLastName_Internalname = sPrefix+"RESIDENTLASTNAME";
         cmbResidentGender_Internalname = sPrefix+"RESIDENTGENDER";
         edtResidentBirthDate_Internalname = sPrefix+"RESIDENTBIRTHDATE";
         edtResidentEmail_Internalname = sPrefix+"RESIDENTEMAIL";
         lblTransactiondetail_phonelabel_Internalname = sPrefix+"TRANSACTIONDETAIL_PHONELABEL";
         edtavResidentphonecode_description_Internalname = sPrefix+"vRESIDENTPHONECODE_DESCRIPTION";
         divUnnamedtable10_Internalname = sPrefix+"UNNAMEDTABLE10";
         edtResidentPhoneNumber_Internalname = sPrefix+"RESIDENTPHONENUMBER";
         divUnnamedtable9_Internalname = sPrefix+"UNNAMEDTABLE9";
         divTransactiondetail_phonenumber_Internalname = sPrefix+"TRANSACTIONDETAIL_PHONENUMBER";
         lblTransactiondetail_phone_Internalname = sPrefix+"TRANSACTIONDETAIL_PHONE";
         edtavResidenthomephonecode_description_Internalname = sPrefix+"vRESIDENTHOMEPHONECODE_DESCRIPTION";
         divUnnamedtable8_Internalname = sPrefix+"UNNAMEDTABLE8";
         edtResidentHomePhoneNumber_Internalname = sPrefix+"RESIDENTHOMEPHONENUMBER";
         divUnnamedtable7_Internalname = sPrefix+"UNNAMEDTABLE7";
         divTransactiondetail_homephonenumber_Internalname = sPrefix+"TRANSACTIONDETAIL_HOMEPHONENUMBER";
         edtResidentPhone_Internalname = sPrefix+"RESIDENTPHONE";
         divResidentphone_cell_Internalname = sPrefix+"RESIDENTPHONE_CELL";
         edtResidentHomePhone_Internalname = sPrefix+"RESIDENTHOMEPHONE";
         divResidenthomephone_cell_Internalname = sPrefix+"RESIDENTHOMEPHONE_CELL";
         edtResidentBsnNumber_Internalname = sPrefix+"RESIDENTBSNNUMBER";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         grpTransactiondetail_residentinfogroup_Internalname = sPrefix+"TRANSACTIONDETAIL_RESIDENTINFOGROUP";
         edtResidentAddressLine1_Internalname = sPrefix+"RESIDENTADDRESSLINE1";
         edtResidentAddressLine2_Internalname = sPrefix+"RESIDENTADDRESSLINE2";
         edtResidentZipCode_Internalname = sPrefix+"RESIDENTZIPCODE";
         edtResidentCity_Internalname = sPrefix+"RESIDENTCITY";
         edtavResidentcountry_description_Internalname = sPrefix+"vRESIDENTCOUNTRY_DESCRIPTION";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         grpUnnamedgroup4_Internalname = sPrefix+"UNNAMEDGROUP4";
         edtResidentTypeName_Internalname = sPrefix+"RESIDENTTYPENAME";
         edtResidentPackageName_Internalname = sPrefix+"RESIDENTPACKAGENAME";
         divUnnamedtable5_Internalname = sPrefix+"UNNAMEDTABLE5";
         grpUnnamedgroup6_Internalname = sPrefix+"UNNAMEDGROUP6";
         divUnnamedtable2_Internalname = sPrefix+"UNNAMEDTABLE2";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtncancel_Internalname = sPrefix+"BTNCANCEL";
         divTable_Internalname = sPrefix+"TABLE";
         edtSG_OrganisationId_Internalname = sPrefix+"SG_ORGANISATIONID";
         edtSG_LocationId_Internalname = sPrefix+"SG_LOCATIONID";
         edtResidentId_Internalname = sPrefix+"RESIDENTID";
         edtLocationId_Internalname = sPrefix+"LOCATIONID";
         edtOrganisationId_Internalname = sPrefix+"ORGANISATIONID";
         edtResidentInitials_Internalname = sPrefix+"RESIDENTINITIALS";
         edtResidentGUID_Internalname = sPrefix+"RESIDENTGUID";
         edtMedicalIndicationId_Internalname = sPrefix+"MEDICALINDICATIONID";
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
         edtMedicalIndicationId_Enabled = 0;
         edtResidentGUID_Enabled = 0;
         edtResidentInitials_Enabled = 0;
         edtOrganisationId_Enabled = 0;
         edtLocationId_Enabled = 0;
         edtResidentId_Enabled = 0;
         edtSG_LocationId_Enabled = 0;
         edtSG_OrganisationId_Enabled = 0;
         edtMedicalIndicationId_Jsonclick = "";
         edtMedicalIndicationId_Visible = 1;
         edtResidentGUID_Jsonclick = "";
         edtResidentGUID_Visible = 1;
         edtResidentInitials_Jsonclick = "";
         edtResidentInitials_Visible = 1;
         edtOrganisationId_Jsonclick = "";
         edtOrganisationId_Visible = 1;
         edtLocationId_Jsonclick = "";
         edtLocationId_Visible = 1;
         edtResidentId_Jsonclick = "";
         edtResidentId_Visible = 1;
         edtSG_LocationId_Jsonclick = "";
         edtSG_LocationId_Visible = 1;
         edtSG_OrganisationId_Jsonclick = "";
         edtSG_OrganisationId_Visible = 1;
         edtResidentPackageName_Jsonclick = "";
         edtResidentPackageName_Link = "";
         edtResidentPackageName_Enabled = 0;
         edtResidentTypeName_Jsonclick = "";
         edtResidentTypeName_Link = "";
         edtResidentTypeName_Enabled = 0;
         edtavResidentcountry_description_Jsonclick = "";
         edtavResidentcountry_description_Enabled = 1;
         edtResidentCity_Jsonclick = "";
         edtResidentCity_Enabled = 0;
         edtResidentZipCode_Jsonclick = "";
         edtResidentZipCode_Enabled = 0;
         edtResidentAddressLine2_Jsonclick = "";
         edtResidentAddressLine2_Enabled = 0;
         edtResidentAddressLine1_Jsonclick = "";
         edtResidentAddressLine1_Enabled = 0;
         edtResidentBsnNumber_Jsonclick = "";
         edtResidentBsnNumber_Enabled = 0;
         edtResidentHomePhone_Jsonclick = "";
         edtResidentHomePhone_Enabled = 0;
         edtResidentHomePhone_Visible = 1;
         divResidenthomephone_cell_Class = "col-xs-12";
         edtResidentPhone_Jsonclick = "";
         edtResidentPhone_Enabled = 0;
         edtResidentPhone_Visible = 1;
         divResidentphone_cell_Class = "col-xs-12";
         edtResidentHomePhoneNumber_Jsonclick = "";
         edtResidentHomePhoneNumber_Enabled = 0;
         edtavResidenthomephonecode_description_Jsonclick = "";
         edtavResidenthomephonecode_description_Enabled = 1;
         divTransactiondetail_homephonenumber_Visible = 1;
         edtResidentPhoneNumber_Jsonclick = "";
         edtResidentPhoneNumber_Enabled = 0;
         edtavResidentphonecode_description_Jsonclick = "";
         edtavResidentphonecode_description_Enabled = 1;
         divTransactiondetail_phonenumber_Visible = 1;
         edtResidentEmail_Jsonclick = "";
         edtResidentEmail_Enabled = 0;
         edtResidentBirthDate_Jsonclick = "";
         edtResidentBirthDate_Enabled = 0;
         cmbResidentGender_Jsonclick = "";
         cmbResidentGender.Enabled = 0;
         edtResidentLastName_Jsonclick = "";
         edtResidentLastName_Enabled = 0;
         edtResidentGivenName_Jsonclick = "";
         edtResidentGivenName_Enabled = 0;
         cmbResidentSalutation_Jsonclick = "";
         cmbResidentSalutation.Enabled = 0;
         grpTransactiondetail_residentinfogroup_Caption = context.GetMessage( "Resident Information", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"}]}""");
         setEventMetadata("VALID_RESIDENTID","""{"handler":"Valid_Residentid","iparms":[]}""");
         setEventMetadata("VALID_LOCATIONID","""{"handler":"Valid_Locationid","iparms":[]}""");
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
         wcpOA62ResidentId = Guid.Empty;
         wcpOA29LocationId = Guid.Empty;
         wcpOA11OrganisationId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV30Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         TempTags = "";
         A72ResidentSalutation = "";
         A64ResidentGivenName = "";
         A65ResidentLastName = "";
         A68ResidentGender = "";
         A73ResidentBirthDate = DateTime.MinValue;
         A67ResidentEmail = "";
         lblTransactiondetail_phonelabel_Jsonclick = "";
         AV18ResidentPhoneCode_Description = "";
         A348ResidentPhoneNumber = "";
         lblTransactiondetail_phone_Jsonclick = "";
         AV19ResidentHomePhoneCode_Description = "";
         A432ResidentHomePhoneNumber = "";
         gxphoneLink = "";
         A70ResidentPhone = "";
         A430ResidentHomePhone = "";
         A63ResidentBsnNumber = "";
         A315ResidentAddressLine1 = "";
         A316ResidentAddressLine2 = "";
         A314ResidentZipCode = "";
         A313ResidentCity = "";
         AV15ResidentCountry_Description = "";
         A97ResidentTypeName = "";
         A531ResidentPackageName = "";
         ClassString = "";
         StyleString = "";
         bttBtncancel_Jsonclick = "";
         A529SG_OrganisationId = Guid.Empty;
         A528SG_LocationId = Guid.Empty;
         A66ResidentInitials = "";
         A71ResidentGUID = "";
         A98MedicalIndicationId = Guid.Empty;
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H005K2_A62ResidentId = new Guid[] {Guid.Empty} ;
         H005K2_A29LocationId = new Guid[] {Guid.Empty} ;
         H005K2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H005K2_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         H005K2_n96ResidentTypeId = new bool[] {false} ;
         H005K2_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         H005K2_n527ResidentPackageId = new bool[] {false} ;
         H005K2_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         H005K2_n98MedicalIndicationId = new bool[] {false} ;
         H005K2_A71ResidentGUID = new string[] {""} ;
         H005K2_A66ResidentInitials = new string[] {""} ;
         H005K2_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         H005K2_A529SG_OrganisationId = new Guid[] {Guid.Empty} ;
         H005K2_A531ResidentPackageName = new string[] {""} ;
         H005K2_A97ResidentTypeName = new string[] {""} ;
         H005K2_A313ResidentCity = new string[] {""} ;
         H005K2_A314ResidentZipCode = new string[] {""} ;
         H005K2_A316ResidentAddressLine2 = new string[] {""} ;
         H005K2_A315ResidentAddressLine1 = new string[] {""} ;
         H005K2_A63ResidentBsnNumber = new string[] {""} ;
         H005K2_A430ResidentHomePhone = new string[] {""} ;
         H005K2_A70ResidentPhone = new string[] {""} ;
         H005K2_A432ResidentHomePhoneNumber = new string[] {""} ;
         H005K2_A348ResidentPhoneNumber = new string[] {""} ;
         H005K2_A67ResidentEmail = new string[] {""} ;
         H005K2_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         H005K2_A68ResidentGender = new string[] {""} ;
         H005K2_A65ResidentLastName = new string[] {""} ;
         H005K2_A64ResidentGivenName = new string[] {""} ;
         H005K2_A72ResidentSalutation = new string[] {""} ;
         A96ResidentTypeId = Guid.Empty;
         A527ResidentPackageId = Guid.Empty;
         Gx_mode = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV21Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV17ComboSelectedValue = "";
         GXt_objcol_SdtDVB_SDTComboData_Item1 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV28ResidentTitle = "";
         GXt_char2 = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA62ResidentId = "";
         sCtrlA29LocationId = "";
         sCtrlA11OrganisationId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_residentgeneral__default(),
            new Object[][] {
                new Object[] {
               H005K2_A62ResidentId, H005K2_A29LocationId, H005K2_A11OrganisationId, H005K2_A96ResidentTypeId, H005K2_n96ResidentTypeId, H005K2_A527ResidentPackageId, H005K2_n527ResidentPackageId, H005K2_A98MedicalIndicationId, H005K2_n98MedicalIndicationId, H005K2_A71ResidentGUID,
               H005K2_A66ResidentInitials, H005K2_A528SG_LocationId, H005K2_A529SG_OrganisationId, H005K2_A531ResidentPackageName, H005K2_A97ResidentTypeName, H005K2_A313ResidentCity, H005K2_A314ResidentZipCode, H005K2_A316ResidentAddressLine2, H005K2_A315ResidentAddressLine1, H005K2_A63ResidentBsnNumber,
               H005K2_A430ResidentHomePhone, H005K2_A70ResidentPhone, H005K2_A432ResidentHomePhoneNumber, H005K2_A348ResidentPhoneNumber, H005K2_A67ResidentEmail, H005K2_A73ResidentBirthDate, H005K2_A68ResidentGender, H005K2_A65ResidentLastName, H005K2_A64ResidentGivenName, H005K2_A72ResidentSalutation
               }
            }
         );
         AV30Pgmname = "Trn_ResidentGeneral";
         /* GeneXus formulas. */
         AV30Pgmname = "Trn_ResidentGeneral";
         edtavResidentphonecode_description_Enabled = 0;
         edtavResidenthomephonecode_description_Enabled = 0;
         edtavResidentcountry_description_Enabled = 0;
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
      private int edtavResidentphonecode_description_Enabled ;
      private int edtavResidenthomephonecode_description_Enabled ;
      private int edtavResidentcountry_description_Enabled ;
      private int edtResidentGivenName_Enabled ;
      private int edtResidentLastName_Enabled ;
      private int edtResidentBirthDate_Enabled ;
      private int edtResidentEmail_Enabled ;
      private int divTransactiondetail_phonenumber_Visible ;
      private int edtResidentPhoneNumber_Enabled ;
      private int divTransactiondetail_homephonenumber_Visible ;
      private int edtResidentHomePhoneNumber_Enabled ;
      private int edtResidentPhone_Visible ;
      private int edtResidentPhone_Enabled ;
      private int edtResidentHomePhone_Visible ;
      private int edtResidentHomePhone_Enabled ;
      private int edtResidentBsnNumber_Enabled ;
      private int edtResidentAddressLine1_Enabled ;
      private int edtResidentAddressLine2_Enabled ;
      private int edtResidentZipCode_Enabled ;
      private int edtResidentCity_Enabled ;
      private int edtResidentTypeName_Enabled ;
      private int edtResidentPackageName_Enabled ;
      private int edtSG_OrganisationId_Visible ;
      private int edtSG_LocationId_Visible ;
      private int edtResidentId_Visible ;
      private int edtLocationId_Visible ;
      private int edtOrganisationId_Visible ;
      private int edtResidentInitials_Visible ;
      private int edtResidentGUID_Visible ;
      private int edtMedicalIndicationId_Visible ;
      private int edtSG_OrganisationId_Enabled ;
      private int edtSG_LocationId_Enabled ;
      private int edtResidentId_Enabled ;
      private int edtLocationId_Enabled ;
      private int edtOrganisationId_Enabled ;
      private int edtResidentInitials_Enabled ;
      private int edtResidentGUID_Enabled ;
      private int edtMedicalIndicationId_Enabled ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV30Pgmname ;
      private string edtavResidentphonecode_description_Internalname ;
      private string edtavResidenthomephonecode_description_Internalname ;
      private string edtavResidentcountry_description_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string grpTransactiondetail_residentinfogroup_Internalname ;
      private string grpTransactiondetail_residentinfogroup_Caption ;
      private string divUnnamedtable1_Internalname ;
      private string cmbResidentSalutation_Internalname ;
      private string TempTags ;
      private string A72ResidentSalutation ;
      private string cmbResidentSalutation_Jsonclick ;
      private string edtResidentGivenName_Internalname ;
      private string edtResidentGivenName_Jsonclick ;
      private string edtResidentLastName_Internalname ;
      private string edtResidentLastName_Jsonclick ;
      private string cmbResidentGender_Internalname ;
      private string cmbResidentGender_Jsonclick ;
      private string edtResidentBirthDate_Internalname ;
      private string edtResidentBirthDate_Jsonclick ;
      private string edtResidentEmail_Internalname ;
      private string edtResidentEmail_Jsonclick ;
      private string divTransactiondetail_phonenumber_Internalname ;
      private string lblTransactiondetail_phonelabel_Internalname ;
      private string lblTransactiondetail_phonelabel_Jsonclick ;
      private string divUnnamedtable9_Internalname ;
      private string divUnnamedtable10_Internalname ;
      private string edtavResidentphonecode_description_Jsonclick ;
      private string edtResidentPhoneNumber_Internalname ;
      private string edtResidentPhoneNumber_Jsonclick ;
      private string divTransactiondetail_homephonenumber_Internalname ;
      private string lblTransactiondetail_phone_Internalname ;
      private string lblTransactiondetail_phone_Jsonclick ;
      private string divUnnamedtable7_Internalname ;
      private string divUnnamedtable8_Internalname ;
      private string edtavResidenthomephonecode_description_Jsonclick ;
      private string edtResidentHomePhoneNumber_Internalname ;
      private string edtResidentHomePhoneNumber_Jsonclick ;
      private string divResidentphone_cell_Internalname ;
      private string divResidentphone_cell_Class ;
      private string edtResidentPhone_Internalname ;
      private string gxphoneLink ;
      private string A70ResidentPhone ;
      private string edtResidentPhone_Jsonclick ;
      private string divResidenthomephone_cell_Internalname ;
      private string divResidenthomephone_cell_Class ;
      private string edtResidentHomePhone_Internalname ;
      private string A430ResidentHomePhone ;
      private string edtResidentHomePhone_Jsonclick ;
      private string edtResidentBsnNumber_Internalname ;
      private string edtResidentBsnNumber_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string grpUnnamedgroup4_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string edtResidentAddressLine1_Internalname ;
      private string edtResidentAddressLine1_Jsonclick ;
      private string edtResidentAddressLine2_Internalname ;
      private string edtResidentAddressLine2_Jsonclick ;
      private string edtResidentZipCode_Internalname ;
      private string edtResidentZipCode_Jsonclick ;
      private string edtResidentCity_Internalname ;
      private string edtResidentCity_Jsonclick ;
      private string edtavResidentcountry_description_Jsonclick ;
      private string grpUnnamedgroup6_Internalname ;
      private string divUnnamedtable5_Internalname ;
      private string edtResidentTypeName_Internalname ;
      private string edtResidentTypeName_Link ;
      private string edtResidentTypeName_Jsonclick ;
      private string edtResidentPackageName_Internalname ;
      private string edtResidentPackageName_Link ;
      private string edtResidentPackageName_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtSG_OrganisationId_Internalname ;
      private string edtSG_OrganisationId_Jsonclick ;
      private string edtSG_LocationId_Internalname ;
      private string edtSG_LocationId_Jsonclick ;
      private string edtResidentId_Internalname ;
      private string edtResidentId_Jsonclick ;
      private string edtLocationId_Internalname ;
      private string edtLocationId_Jsonclick ;
      private string edtOrganisationId_Internalname ;
      private string edtOrganisationId_Jsonclick ;
      private string edtResidentInitials_Internalname ;
      private string A66ResidentInitials ;
      private string edtResidentInitials_Jsonclick ;
      private string edtResidentGUID_Internalname ;
      private string edtResidentGUID_Jsonclick ;
      private string edtMedicalIndicationId_Internalname ;
      private string edtMedicalIndicationId_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string GXt_char2 ;
      private string sCtrlA62ResidentId ;
      private string sCtrlA29LocationId ;
      private string sCtrlA11OrganisationId ;
      private DateTime A73ResidentBirthDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n96ResidentTypeId ;
      private bool n527ResidentPackageId ;
      private bool n98MedicalIndicationId ;
      private bool returnInSub ;
      private bool AV14TempBoolean ;
      private bool GXt_boolean3 ;
      private string A64ResidentGivenName ;
      private string A65ResidentLastName ;
      private string A68ResidentGender ;
      private string A67ResidentEmail ;
      private string AV18ResidentPhoneCode_Description ;
      private string A348ResidentPhoneNumber ;
      private string AV19ResidentHomePhoneCode_Description ;
      private string A432ResidentHomePhoneNumber ;
      private string A63ResidentBsnNumber ;
      private string A315ResidentAddressLine1 ;
      private string A316ResidentAddressLine2 ;
      private string A314ResidentZipCode ;
      private string A313ResidentCity ;
      private string AV15ResidentCountry_Description ;
      private string A97ResidentTypeName ;
      private string A531ResidentPackageName ;
      private string A71ResidentGUID ;
      private string AV17ComboSelectedValue ;
      private string AV28ResidentTitle ;
      private Guid A62ResidentId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid wcpOA62ResidentId ;
      private Guid wcpOA29LocationId ;
      private Guid wcpOA11OrganisationId ;
      private Guid A529SG_OrganisationId ;
      private Guid A528SG_LocationId ;
      private Guid A98MedicalIndicationId ;
      private Guid A96ResidentTypeId ;
      private Guid A527ResidentPackageId ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbResidentSalutation ;
      private GXCombobox cmbResidentGender ;
      private IDataStoreProvider pr_default ;
      private Guid[] H005K2_A62ResidentId ;
      private Guid[] H005K2_A29LocationId ;
      private Guid[] H005K2_A11OrganisationId ;
      private Guid[] H005K2_A96ResidentTypeId ;
      private bool[] H005K2_n96ResidentTypeId ;
      private Guid[] H005K2_A527ResidentPackageId ;
      private bool[] H005K2_n527ResidentPackageId ;
      private Guid[] H005K2_A98MedicalIndicationId ;
      private bool[] H005K2_n98MedicalIndicationId ;
      private string[] H005K2_A71ResidentGUID ;
      private string[] H005K2_A66ResidentInitials ;
      private Guid[] H005K2_A528SG_LocationId ;
      private Guid[] H005K2_A529SG_OrganisationId ;
      private string[] H005K2_A531ResidentPackageName ;
      private string[] H005K2_A97ResidentTypeName ;
      private string[] H005K2_A313ResidentCity ;
      private string[] H005K2_A314ResidentZipCode ;
      private string[] H005K2_A316ResidentAddressLine2 ;
      private string[] H005K2_A315ResidentAddressLine1 ;
      private string[] H005K2_A63ResidentBsnNumber ;
      private string[] H005K2_A430ResidentHomePhone ;
      private string[] H005K2_A70ResidentPhone ;
      private string[] H005K2_A432ResidentHomePhoneNumber ;
      private string[] H005K2_A348ResidentPhoneNumber ;
      private string[] H005K2_A67ResidentEmail ;
      private DateTime[] H005K2_A73ResidentBirthDate ;
      private string[] H005K2_A68ResidentGender ;
      private string[] H005K2_A65ResidentLastName ;
      private string[] H005K2_A64ResidentGivenName ;
      private string[] H005K2_A72ResidentSalutation ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV21Combo_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> GXt_objcol_SdtDVB_SDTComboData_Item1 ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class trn_residentgeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH005K2;
          prmH005K2 = new Object[] {
          new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005K2", "SELECT T1.ResidentId, T1.LocationId, T1.OrganisationId, T1.ResidentTypeId, T1.ResidentPackageId, T1.MedicalIndicationId, T1.ResidentGUID, T1.ResidentInitials, T3.SG_LocationId, T3.SG_OrganisationId, T3.ResidentPackageName, T2.ResidentTypeName, T1.ResidentCity, T1.ResidentZipCode, T1.ResidentAddressLine2, T1.ResidentAddressLine1, T1.ResidentBsnNumber, T1.ResidentHomePhone, T1.ResidentPhone, T1.ResidentHomePhoneNumber, T1.ResidentPhoneNumber, T1.ResidentEmail, T1.ResidentBirthDate, T1.ResidentGender, T1.ResidentLastName, T1.ResidentGivenName, T1.ResidentSalutation FROM ((Trn_Resident T1 LEFT JOIN Trn_ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId) LEFT JOIN Trn_ResidentPackage T3 ON T3.ResidentPackageId = T1.ResidentPackageId) WHERE T1.ResidentId = :ResidentId and T1.LocationId = :LocationId and T1.OrganisationId = :OrganisationId ORDER BY T1.ResidentId, T1.LocationId, T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005K2,1, GxCacheFrequency.OFF ,true,true )
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
                ((Guid[]) buf[5])[0] = rslt.getGuid(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((Guid[]) buf[7])[0] = rslt.getGuid(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((string[]) buf[9])[0] = rslt.getVarchar(7);
                ((string[]) buf[10])[0] = rslt.getString(8, 20);
                ((Guid[]) buf[11])[0] = rslt.getGuid(9);
                ((Guid[]) buf[12])[0] = rslt.getGuid(10);
                ((string[]) buf[13])[0] = rslt.getVarchar(11);
                ((string[]) buf[14])[0] = rslt.getVarchar(12);
                ((string[]) buf[15])[0] = rslt.getVarchar(13);
                ((string[]) buf[16])[0] = rslt.getVarchar(14);
                ((string[]) buf[17])[0] = rslt.getVarchar(15);
                ((string[]) buf[18])[0] = rslt.getVarchar(16);
                ((string[]) buf[19])[0] = rslt.getVarchar(17);
                ((string[]) buf[20])[0] = rslt.getString(18, 20);
                ((string[]) buf[21])[0] = rslt.getString(19, 20);
                ((string[]) buf[22])[0] = rslt.getVarchar(20);
                ((string[]) buf[23])[0] = rslt.getVarchar(21);
                ((string[]) buf[24])[0] = rslt.getVarchar(22);
                ((DateTime[]) buf[25])[0] = rslt.getGXDate(23);
                ((string[]) buf[26])[0] = rslt.getVarchar(24);
                ((string[]) buf[27])[0] = rslt.getVarchar(25);
                ((string[]) buf[28])[0] = rslt.getVarchar(26);
                ((string[]) buf[29])[0] = rslt.getString(27, 20);
                return;
       }
    }

 }

}
