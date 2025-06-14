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
   public class trn_residentpackagegeneral : GXWebComponent
   {
      public trn_residentpackagegeneral( )
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

      public trn_residentpackagegeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ResidentPackageId )
      {
         this.A527ResidentPackageId = aP0_ResidentPackageId;
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
         chkResidentPackageDefault = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "ResidentPackageId");
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
                  A527ResidentPackageId = StringUtil.StrToGuid( GetPar( "ResidentPackageId"));
                  AssignAttri(sPrefix, false, "A527ResidentPackageId", A527ResidentPackageId.ToString());
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(Guid)A527ResidentPackageId});
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
                  gxfirstwebparm = GetFirstPar( "ResidentPackageId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ResidentPackageId");
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
            PAAF2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV21Pgmname = "Trn_ResidentPackageGeneral";
               edtavResidentpackagemodules_description_Enabled = 0;
               AssignProp(sPrefix, false, edtavResidentpackagemodules_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentpackagemodules_description_Enabled), 5, 0), true);
               WSAF2( ) ;
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
            context.SendWebValue( context.GetMessage( "Trn_Resident Package General", "")) ;
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
            GXEncryptionTmp = "trn_residentpackagegeneral.aspx"+UrlEncode(A527ResidentPackageId.ToString());
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_residentpackagegeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA527ResidentPackageId", wcpOA527ResidentPackageId.ToString());
      }

      protected void RenderHtmlCloseFormAF2( )
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
         return "Trn_ResidentPackageGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Resident Package General", "") ;
      }

      protected void WBAF0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "trn_residentpackagegeneral.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentPackageName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtResidentPackageName_Internalname, context.GetMessage( "Access Rights Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtResidentPackageName_Internalname, A531ResidentPackageName, StringUtil.RTrim( context.localUtil.Format( A531ResidentPackageName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,14);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentPackageName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentPackageName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_ResidentPackageGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentpackagemodules_description_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentpackagemodules_description_Internalname, context.GetMessage( "Access rights", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentpackagemodules_description_Internalname, AV12ResidentPackageModules_Description, StringUtil.RTrim( context.localUtil.Format( AV12ResidentPackageModules_Description, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,19);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentpackagemodules_description_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentpackagemodules_description_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_ResidentPackageGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkResidentPackageDefault_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkResidentPackageDefault_Internalname, " ", "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkResidentPackageDefault_Internalname, StringUtil.BoolToStr( A533ResidentPackageDefault), "", " ", 1, chkResidentPackageDefault.Enabled, "true", context.GetMessage( "Default access rights", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(24, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,24);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtncancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ResidentPackageGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtResidentPackageId_Internalname, A527ResidentPackageId.ToString(), A527ResidentPackageId.ToString(), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentPackageId_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentPackageId_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_ResidentPackageGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtSG_OrganisationId_Internalname, A529SG_OrganisationId.ToString(), A529SG_OrganisationId.ToString(), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSG_OrganisationId_Jsonclick, 0, "Attribute", "", "", "", "", edtSG_OrganisationId_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_ResidentPackageGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtSG_LocationId_Internalname, A528SG_LocationId.ToString(), A528SG_LocationId.ToString(), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSG_LocationId_Jsonclick, 0, "Attribute", "", "", "", "", edtSG_LocationId_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_ResidentPackageGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void STARTAF2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Trn_Resident Package General", ""), 0) ;
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
               STRUPAF0( ) ;
            }
         }
      }

      protected void WSAF2( )
      {
         STARTAF2( ) ;
         EVTAF2( ) ;
      }

      protected void EVTAF2( )
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
                                 STRUPAF0( ) ;
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
                                 STRUPAF0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11AF2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPAF0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E12AF2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPAF0( ) ;
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
                                 STRUPAF0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavResidentpackagemodules_description_Internalname;
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

      protected void WEAF2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseFormAF2( ) ;
            }
         }
      }

      protected void PAAF2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_residentpackagegeneral.aspx")), "trn_residentpackagegeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_residentpackagegeneral.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "ResidentPackageId");
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
               GX_FocusControl = edtavResidentpackagemodules_description_Internalname;
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
         A533ResidentPackageDefault = StringUtil.StrToBool( StringUtil.BoolToStr( A533ResidentPackageDefault));
         AssignAttri(sPrefix, false, "A533ResidentPackageDefault", A533ResidentPackageDefault);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFAF2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV21Pgmname = "Trn_ResidentPackageGeneral";
         edtavResidentpackagemodules_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavResidentpackagemodules_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentpackagemodules_description_Enabled), 5, 0), true);
      }

      protected void RFAF2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00AF2 */
            pr_default.execute(0, new Object[] {A527ResidentPackageId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A528SG_LocationId = H00AF2_A528SG_LocationId[0];
               AssignAttri(sPrefix, false, "A528SG_LocationId", A528SG_LocationId.ToString());
               A529SG_OrganisationId = H00AF2_A529SG_OrganisationId[0];
               AssignAttri(sPrefix, false, "A529SG_OrganisationId", A529SG_OrganisationId.ToString());
               A533ResidentPackageDefault = H00AF2_A533ResidentPackageDefault[0];
               AssignAttri(sPrefix, false, "A533ResidentPackageDefault", A533ResidentPackageDefault);
               A531ResidentPackageName = H00AF2_A531ResidentPackageName[0];
               AssignAttri(sPrefix, false, "A531ResidentPackageName", A531ResidentPackageName);
               /* Execute user event: Load */
               E12AF2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WBAF0( ) ;
         }
      }

      protected void send_integrity_lvl_hashesAF2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV21Pgmname = "Trn_ResidentPackageGeneral";
         edtavResidentpackagemodules_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavResidentpackagemodules_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentpackagemodules_description_Enabled), 5, 0), true);
         edtResidentPackageName_Enabled = 0;
         AssignProp(sPrefix, false, edtResidentPackageName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentPackageName_Enabled), 5, 0), true);
         chkResidentPackageDefault.Enabled = 0;
         AssignProp(sPrefix, false, chkResidentPackageDefault_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkResidentPackageDefault.Enabled), 5, 0), true);
         edtResidentPackageId_Enabled = 0;
         AssignProp(sPrefix, false, edtResidentPackageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentPackageId_Enabled), 5, 0), true);
         edtSG_OrganisationId_Enabled = 0;
         AssignProp(sPrefix, false, edtSG_OrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSG_OrganisationId_Enabled), 5, 0), true);
         edtSG_LocationId_Enabled = 0;
         AssignProp(sPrefix, false, edtSG_LocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSG_LocationId_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUPAF0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11AF2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA527ResidentPackageId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA527ResidentPackageId"));
            /* Read variables values. */
            A531ResidentPackageName = cgiGet( edtResidentPackageName_Internalname);
            AssignAttri(sPrefix, false, "A531ResidentPackageName", A531ResidentPackageName);
            AV12ResidentPackageModules_Description = cgiGet( edtavResidentpackagemodules_description_Internalname);
            AssignAttri(sPrefix, false, "AV12ResidentPackageModules_Description", AV12ResidentPackageModules_Description);
            A533ResidentPackageDefault = StringUtil.StrToBool( cgiGet( chkResidentPackageDefault_Internalname));
            AssignAttri(sPrefix, false, "A533ResidentPackageDefault", A533ResidentPackageDefault);
            A529SG_OrganisationId = StringUtil.StrToGuid( cgiGet( edtSG_OrganisationId_Internalname));
            AssignAttri(sPrefix, false, "A529SG_OrganisationId", A529SG_OrganisationId.ToString());
            A528SG_LocationId = StringUtil.StrToGuid( cgiGet( edtSG_LocationId_Internalname));
            AssignAttri(sPrefix, false, "A528SG_LocationId", A528SG_LocationId.ToString());
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
         E11AF2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E11AF2( )
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

      protected void E12AF2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtResidentPackageId_Visible = 0;
         AssignProp(sPrefix, false, edtResidentPackageId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentPackageId_Visible), 5, 0), true);
         edtSG_OrganisationId_Visible = 0;
         AssignProp(sPrefix, false, edtSG_OrganisationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSG_OrganisationId_Visible), 5, 0), true);
         edtSG_LocationId_Visible = 0;
         AssignProp(sPrefix, false, edtSG_LocationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSG_LocationId_Visible), 5, 0), true);
         GXt_objcol_SdtDVB_SDTComboData_Item1 = AV13Combo_Data;
         new trn_residentpackageloaddvcombo(context ).execute(  "ResidentPackageModules",  "UPD",  A527ResidentPackageId, out  AV15ComboSelectedValue, out  AV12ResidentPackageModules_Description, out  GXt_objcol_SdtDVB_SDTComboData_Item1) ;
         AssignAttri(sPrefix, false, "AV12ResidentPackageModules_Description", AV12ResidentPackageModules_Description);
         AV13Combo_Data = GXt_objcol_SdtDVB_SDTComboData_Item1;
         AV17ComboSelectedItems = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV17ComboSelectedItems.FromJSonString(AV15ComboSelectedValue, null);
         AV12ResidentPackageModules_Description = "";
         AssignAttri(sPrefix, false, "AV12ResidentPackageModules_Description", AV12ResidentPackageModules_Description);
         AV19GXV1 = 1;
         while ( AV19GXV1 <= AV17ComboSelectedItems.Count )
         {
            AV18ComboSelectedItem = ((string)AV17ComboSelectedItems.Item(AV19GXV1));
            AV20GXV2 = 1;
            while ( AV20GXV2 <= AV13Combo_Data.Count )
            {
               AV16Combo_DataItem = ((WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item)AV13Combo_Data.Item(AV20GXV2));
               if ( StringUtil.StrCmp(AV16Combo_DataItem.gxTpr_Id, AV18ComboSelectedItem) == 0 )
               {
                  AV12ResidentPackageModules_Description += (String.IsNullOrEmpty(StringUtil.RTrim( AV12ResidentPackageModules_Description)) ? "" : ", ") + AV16Combo_DataItem.gxTpr_Title;
                  AssignAttri(sPrefix, false, "AV12ResidentPackageModules_Description", AV12ResidentPackageModules_Description);
                  if (true) break;
               }
               AV20GXV2 = (int)(AV20GXV2+1);
            }
            AV19GXV1 = (int)(AV19GXV1+1);
         }
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV21Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Trn_ResidentPackage";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A527ResidentPackageId = (Guid)getParm(obj,0);
         AssignAttri(sPrefix, false, "A527ResidentPackageId", A527ResidentPackageId.ToString());
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
         PAAF2( ) ;
         WSAF2( ) ;
         WEAF2( ) ;
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
         sCtrlA527ResidentPackageId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PAAF2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "trn_residentpackagegeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PAAF2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A527ResidentPackageId = (Guid)getParm(obj,2);
            AssignAttri(sPrefix, false, "A527ResidentPackageId", A527ResidentPackageId.ToString());
         }
         wcpOA527ResidentPackageId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA527ResidentPackageId"));
         if ( ! GetJustCreated( ) && ( ( A527ResidentPackageId != wcpOA527ResidentPackageId ) ) )
         {
            setjustcreated();
         }
         wcpOA527ResidentPackageId = A527ResidentPackageId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA527ResidentPackageId = cgiGet( sPrefix+"A527ResidentPackageId_CTRL");
         if ( StringUtil.Len( sCtrlA527ResidentPackageId) > 0 )
         {
            A527ResidentPackageId = StringUtil.StrToGuid( cgiGet( sCtrlA527ResidentPackageId));
            AssignAttri(sPrefix, false, "A527ResidentPackageId", A527ResidentPackageId.ToString());
         }
         else
         {
            A527ResidentPackageId = StringUtil.StrToGuid( cgiGet( sPrefix+"A527ResidentPackageId_PARM"));
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
         PAAF2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WSAF2( ) ;
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
         WSAF2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A527ResidentPackageId_PARM", A527ResidentPackageId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA527ResidentPackageId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A527ResidentPackageId_CTRL", StringUtil.RTrim( sCtrlA527ResidentPackageId));
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
         WEAF2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256145234862", true, true);
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
         context.AddJavascriptSource("trn_residentpackagegeneral.js", "?20256145234862", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         chkResidentPackageDefault.Name = "RESIDENTPACKAGEDEFAULT";
         chkResidentPackageDefault.WebTags = "";
         chkResidentPackageDefault.Caption = " ";
         AssignProp(sPrefix, false, chkResidentPackageDefault_Internalname, "TitleCaption", chkResidentPackageDefault.Caption, true);
         chkResidentPackageDefault.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtResidentPackageName_Internalname = sPrefix+"RESIDENTPACKAGENAME";
         edtavResidentpackagemodules_description_Internalname = sPrefix+"vRESIDENTPACKAGEMODULES_DESCRIPTION";
         chkResidentPackageDefault_Internalname = sPrefix+"RESIDENTPACKAGEDEFAULT";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtncancel_Internalname = sPrefix+"BTNCANCEL";
         divTable_Internalname = sPrefix+"TABLE";
         edtResidentPackageId_Internalname = sPrefix+"RESIDENTPACKAGEID";
         edtSG_OrganisationId_Internalname = sPrefix+"SG_ORGANISATIONID";
         edtSG_LocationId_Internalname = sPrefix+"SG_LOCATIONID";
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
         chkResidentPackageDefault.Caption = " ";
         edtSG_LocationId_Enabled = 0;
         edtSG_OrganisationId_Enabled = 0;
         edtResidentPackageId_Enabled = 0;
         edtSG_LocationId_Jsonclick = "";
         edtSG_LocationId_Visible = 1;
         edtSG_OrganisationId_Jsonclick = "";
         edtSG_OrganisationId_Visible = 1;
         edtResidentPackageId_Jsonclick = "";
         edtResidentPackageId_Visible = 1;
         chkResidentPackageDefault.Enabled = 0;
         edtavResidentpackagemodules_description_Jsonclick = "";
         edtavResidentpackagemodules_description_Enabled = 1;
         edtResidentPackageName_Jsonclick = "";
         edtResidentPackageName_Enabled = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A527ResidentPackageId","fld":"RESIDENTPACKAGEID"},{"av":"A533ResidentPackageDefault","fld":"RESIDENTPACKAGEDEFAULT"}]}""");
         setEventMetadata("VALID_RESIDENTPACKAGEID","""{"handler":"Valid_Residentpackageid","iparms":[]}""");
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
         wcpOA527ResidentPackageId = Guid.Empty;
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
         A531ResidentPackageName = "";
         AV12ResidentPackageModules_Description = "";
         ClassString = "";
         StyleString = "";
         bttBtncancel_Jsonclick = "";
         A529SG_OrganisationId = Guid.Empty;
         A528SG_LocationId = Guid.Empty;
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H00AF2_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         H00AF2_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         H00AF2_A529SG_OrganisationId = new Guid[] {Guid.Empty} ;
         H00AF2_A533ResidentPackageDefault = new bool[] {false} ;
         H00AF2_A531ResidentPackageName = new string[] {""} ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV13Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         GXt_objcol_SdtDVB_SDTComboData_Item1 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV15ComboSelectedValue = "";
         AV17ComboSelectedItems = new GxSimpleCollection<string>();
         AV18ComboSelectedItem = "";
         AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA527ResidentPackageId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_residentpackagegeneral__default(),
            new Object[][] {
                new Object[] {
               H00AF2_A527ResidentPackageId, H00AF2_A528SG_LocationId, H00AF2_A529SG_OrganisationId, H00AF2_A533ResidentPackageDefault, H00AF2_A531ResidentPackageName
               }
            }
         );
         AV21Pgmname = "Trn_ResidentPackageGeneral";
         /* GeneXus formulas. */
         AV21Pgmname = "Trn_ResidentPackageGeneral";
         edtavResidentpackagemodules_description_Enabled = 0;
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
      private int edtavResidentpackagemodules_description_Enabled ;
      private int edtResidentPackageName_Enabled ;
      private int edtResidentPackageId_Visible ;
      private int edtSG_OrganisationId_Visible ;
      private int edtSG_LocationId_Visible ;
      private int edtResidentPackageId_Enabled ;
      private int edtSG_OrganisationId_Enabled ;
      private int edtSG_LocationId_Enabled ;
      private int AV19GXV1 ;
      private int AV20GXV2 ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV21Pgmname ;
      private string edtavResidentpackagemodules_description_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string edtResidentPackageName_Internalname ;
      private string TempTags ;
      private string edtResidentPackageName_Jsonclick ;
      private string edtavResidentpackagemodules_description_Jsonclick ;
      private string chkResidentPackageDefault_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtResidentPackageId_Internalname ;
      private string edtResidentPackageId_Jsonclick ;
      private string edtSG_OrganisationId_Internalname ;
      private string edtSG_OrganisationId_Jsonclick ;
      private string edtSG_LocationId_Internalname ;
      private string edtSG_LocationId_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string sCtrlA527ResidentPackageId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool A533ResidentPackageDefault ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string A531ResidentPackageName ;
      private string AV12ResidentPackageModules_Description ;
      private string AV15ComboSelectedValue ;
      private string AV18ComboSelectedItem ;
      private Guid A527ResidentPackageId ;
      private Guid wcpOA527ResidentPackageId ;
      private Guid A529SG_OrganisationId ;
      private Guid A528SG_LocationId ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkResidentPackageDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] H00AF2_A527ResidentPackageId ;
      private Guid[] H00AF2_A528SG_LocationId ;
      private Guid[] H00AF2_A529SG_OrganisationId ;
      private bool[] H00AF2_A533ResidentPackageDefault ;
      private string[] H00AF2_A531ResidentPackageName ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV13Combo_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> GXt_objcol_SdtDVB_SDTComboData_Item1 ;
      private GxSimpleCollection<string> AV17ComboSelectedItems ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class trn_residentpackagegeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00AF2;
          prmH00AF2 = new Object[] {
          new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00AF2", "SELECT ResidentPackageId, SG_LocationId, SG_OrganisationId, ResidentPackageDefault, ResidentPackageName FROM Trn_ResidentPackage WHERE ResidentPackageId = :ResidentPackageId ORDER BY ResidentPackageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00AF2,1, GxCacheFrequency.OFF ,true,true )
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
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
       }
    }

 }

}
