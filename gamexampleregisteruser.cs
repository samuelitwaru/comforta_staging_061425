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
   public class gamexampleregisteruser : GXHttpHandler
   {
      public gamexampleregisteruser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gamexampleregisteruser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavGender = new GXCombobox();
         cmbavLanguage = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
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
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            ValidateSpaRequest();
            PA0W2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS0W2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE0W2( ) ;
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
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( context.GetMessage( "GAM_Registeruser ", "")) ;
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
         CloseStyles();
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
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamexampleregisteruser.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGES", AV17Messages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGES", AV17Messages);
         }
      }

      protected void RenderHtmlCloseForm0W2( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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
         context.WriteHtmlText( "<script type=\"text/javascript\">") ;
         context.WriteHtmlText( "gx.setLanguageCode(\""+context.GetLanguageProperty( "code")+"\");") ;
         if ( ! context.isSpaRequest( ) )
         {
            context.WriteHtmlText( "gx.setDateFormat(\""+context.GetLanguageProperty( "date_fmt")+"\");") ;
            context.WriteHtmlText( "gx.setTimeFormat("+context.GetLanguageProperty( "time_fmt")+");") ;
            context.WriteHtmlText( "gx.setCenturyFirstYear("+40+");") ;
            context.WriteHtmlText( "gx.setDecimalPoint(\""+context.GetLanguageProperty( "decimal_point")+"\");") ;
            context.WriteHtmlText( "gx.setThousandSeparator(\""+context.GetLanguageProperty( "thousand_sep")+"\");") ;
            context.WriteHtmlText( "gx.StorageTimeZone = "+1+";") ;
         }
         context.WriteHtmlText( "</script>") ;
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "GAMExampleRegisterUser" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "GAM_Registeruser ", "") ;
      }

      protected void WB0W0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTbpwd_Internalname, 1, 0, "px", 0, "px", "table-login stack-top-xxl", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 stack-bottom-xl", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbtitle_Internalname, context.GetMessage( "GAM_Register", ""), "", "", lblTbtitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "end", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbhaveaccount_Internalname, context.GetMessage( "GAM_Alreadyhaveanaccount", ""), "", "", lblTbhaveaccount_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTblogin_Internalname, context.GetMessage( "GAM_Login", ""), "", "", lblTblogin_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'LOGIN\\'."+"'", "", "TextBlock", 5, "", 1, 1, 0, 0, "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 stack-top-xl", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavName_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavName_Internalname, context.GetMessage( "GAM_UserName*", ""), "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, AV18Name, StringUtil.RTrim( context.localUtil.Format( AV18Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "Attribute", "", "", "", "", edtavName_Visible, edtavName_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmail_Internalname, edtavEmail_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmail_Internalname, AV5EMail, StringUtil.RTrim( context.localUtil.Format( AV5EMail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavEmail_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMEMail", "start", true, "", "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPassword_Internalname, context.GetMessage( "GAM_Password", ""), "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPassword_Internalname, StringUtil.RTrim( AV19Password), StringUtil.RTrim( context.localUtil.Format( AV19Password, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPassword_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavPassword_Enabled, 1, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "start", true, "", "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbpwdrequirements_Internalname, lblTbpwdrequirements_Caption, "", "", lblTbpwdrequirements_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "text-helper-gray", 0, "", 1, 1, 0, 1, "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPasswordconf_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPasswordconf_Internalname, context.GetMessage( "GAM_ConfirmPassword", ""), "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPasswordconf_Internalname, StringUtil.RTrim( AV20PasswordConf), StringUtil.RTrim( context.localUtil.Format( AV20PasswordConf, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPasswordconf_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavPasswordconf_Enabled, 1, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "start", true, "", "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCell_firstname_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFirstname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFirstname_Internalname, edtavFirstname_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFirstname_Internalname, StringUtil.RTrim( AV6FirstName), StringUtil.RTrim( context.localUtil.Format( AV6FirstName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFirstname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFirstname_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCell_lastname_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLastname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLastname_Internalname, edtavLastname_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLastname_Internalname, StringUtil.RTrim( AV13LastName), StringUtil.RTrim( context.localUtil.Format( AV13LastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLastname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLastname_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCell_phone_Internalname, divCell_phone_Visible, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPhone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPhone_Internalname, edtavPhone_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPhone_Internalname, StringUtil.RTrim( AV102Phone), StringUtil.RTrim( context.localUtil.Format( AV102Phone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPhone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavPhone_Enabled, 1, "text", "", 60, "chr", 1, "row", 254, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMAddress", "start", true, "", "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCell_birthday_Internalname, divCell_birthday_Visible, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavBirthday_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBirthday_Internalname, edtavBirthday_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavBirthday_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavBirthday_Internalname, context.localUtil.Format(AV22Birthday, "99/99/9999"), context.localUtil.Format( AV22Birthday, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBirthday_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavBirthday_Enabled, 1, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMDate", "end", false, "", "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_bitmap( context, edtavBirthday_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavBirthday_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_GAMExampleRegisterUser.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCell_gender_Internalname, divCell_gender_Visible, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavGender_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGender_Internalname, cmbavGender.Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGender, cmbavGender_Internalname, StringUtil.RTrim( AV23Gender), 1, cmbavGender_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavGender.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "", true, 0, "HLP_GAMExampleRegisterUser.htm");
            cmbavGender.CurrentValue = StringUtil.RTrim( AV23Gender);
            AssignProp("", false, cmbavGender_Internalname, "Values", (string)(cmbavGender.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCell_address_Internalname, divCell_address_Visible, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavAddress_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAddress_Internalname, edtavAddress_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAddress_Internalname, StringUtil.RTrim( AV103Address), StringUtil.RTrim( context.localUtil.Format( AV103Address, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAddress_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAddress_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMAddress", "start", true, "", "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCell_city_Internalname, divCell_city_Visible, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCity_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCity_Internalname, edtavCity_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCity_Internalname, StringUtil.RTrim( AV104City), StringUtil.RTrim( context.localUtil.Format( AV104City, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCity_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMAddress", "start", true, "", "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCell_state_Internalname, divCell_state_Visible, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavState_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavState_Internalname, edtavState_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavState_Internalname, StringUtil.RTrim( AV105State), StringUtil.RTrim( context.localUtil.Format( AV105State, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavState_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavState_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMAddress", "start", true, "", "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCell_postcode_Internalname, divCell_postcode_Visible, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPostcode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPostcode_Internalname, edtavPostcode_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPostcode_Internalname, StringUtil.RTrim( AV106PostCode), StringUtil.RTrim( context.localUtil.Format( AV106PostCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPostcode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavPostcode_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCell_language_Internalname, divCell_language_Visible, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavLanguage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavLanguage_Internalname, cmbavLanguage.Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavLanguage, cmbavLanguage_Internalname, StringUtil.RTrim( AV107Language), 1, cmbavLanguage_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavLanguage.Enabled, 1, 0, 30, "%", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "", true, 0, "HLP_GAMExampleRegisterUser.htm");
            cmbavLanguage.CurrentValue = StringUtil.RTrim( AV107Language);
            AssignProp("", false, cmbavLanguage_Internalname, "Values", (string)(cmbavLanguage.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCell_timezone_Internalname, divCell_timezone_Visible, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTimezone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTimezone_Internalname, edtavTimezone_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTimezone_Internalname, StringUtil.RTrim( AV108Timezone), StringUtil.RTrim( context.localUtil.Format( AV108Timezone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTimezone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTimezone_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMTimeZone", "start", true, "", "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCell_photo_Internalname, divCell_photo_Visible, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUrlimage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUrlimage_Internalname, edtavUrlimage_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUrlimage_Internalname, AV111URLImage, StringUtil.RTrim( context.localUtil.Format( AV111URLImage, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUrlimage_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUrlimage_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 stack-top-xl", "end", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
            ClassString = "Button Primary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttLogin_Internalname, "", context.GetMessage( "GAM_CREATEACCOUNT", ""), bttLogin_Jsonclick, 5, context.GetMessage( "GAM_CREATEACCOUNT", ""), "", StyleString, ClassString, bttLogin_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0W2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( "GAM_Registeruser ", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0W0( ) ;
      }

      protected void WS0W2( )
      {
         START0W2( ) ;
         EVT0W2( ) ;
      }

      protected void EVT0W2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
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
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E110W2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! wbErr )
                           {
                              Rfr0gs = false;
                              if ( ! Rfr0gs )
                              {
                                 /* Execute user event: Enter */
                                 E120W2 ();
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "'LOGIN'") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: 'Login' */
                           E130W2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E140W2 ();
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
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

      protected void WE0W2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0W2( ) ;
            }
         }
      }

      protected void PA0W2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavName_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
         if ( cmbavGender.ItemCount > 0 )
         {
            AV23Gender = cmbavGender.getValidValue(AV23Gender);
            AssignAttri("", false, "AV23Gender", AV23Gender);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGender.CurrentValue = StringUtil.RTrim( AV23Gender);
            AssignProp("", false, cmbavGender_Internalname, "Values", cmbavGender.ToJavascriptSource(), true);
         }
         if ( cmbavLanguage.ItemCount > 0 )
         {
            AV107Language = cmbavLanguage.getValidValue(AV107Language);
            AssignAttri("", false, "AV107Language", AV107Language);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavLanguage.CurrentValue = StringUtil.RTrim( AV107Language);
            AssignProp("", false, cmbavLanguage_Internalname, "Values", cmbavLanguage.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0W2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF0W2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E140W2 ();
            WB0W0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0W2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0W0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110W2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV18Name = cgiGet( edtavName_Internalname);
            AssignAttri("", false, "AV18Name", AV18Name);
            AV5EMail = cgiGet( edtavEmail_Internalname);
            AssignAttri("", false, "AV5EMail", AV5EMail);
            AV19Password = cgiGet( edtavPassword_Internalname);
            AssignAttri("", false, "AV19Password", AV19Password);
            AV20PasswordConf = cgiGet( edtavPasswordconf_Internalname);
            AssignAttri("", false, "AV20PasswordConf", AV20PasswordConf);
            AV6FirstName = cgiGet( edtavFirstname_Internalname);
            AssignAttri("", false, "AV6FirstName", AV6FirstName);
            AV13LastName = cgiGet( edtavLastname_Internalname);
            AssignAttri("", false, "AV13LastName", AV13LastName);
            AV102Phone = cgiGet( edtavPhone_Internalname);
            AssignAttri("", false, "AV102Phone", AV102Phone);
            if ( context.localUtil.VCDate( cgiGet( edtavBirthday_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Birthday", "")}), 1, "vBIRTHDAY");
               GX_FocusControl = edtavBirthday_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV22Birthday = DateTime.MinValue;
               AssignAttri("", false, "AV22Birthday", context.localUtil.Format(AV22Birthday, "99/99/9999"));
            }
            else
            {
               AV22Birthday = context.localUtil.CToD( cgiGet( edtavBirthday_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV22Birthday", context.localUtil.Format(AV22Birthday, "99/99/9999"));
            }
            cmbavGender.CurrentValue = cgiGet( cmbavGender_Internalname);
            AV23Gender = cgiGet( cmbavGender_Internalname);
            AssignAttri("", false, "AV23Gender", AV23Gender);
            AV103Address = cgiGet( edtavAddress_Internalname);
            AssignAttri("", false, "AV103Address", AV103Address);
            AV104City = cgiGet( edtavCity_Internalname);
            AssignAttri("", false, "AV104City", AV104City);
            AV105State = cgiGet( edtavState_Internalname);
            AssignAttri("", false, "AV105State", AV105State);
            AV106PostCode = cgiGet( edtavPostcode_Internalname);
            AssignAttri("", false, "AV106PostCode", AV106PostCode);
            cmbavLanguage.CurrentValue = cgiGet( cmbavLanguage_Internalname);
            AV107Language = cgiGet( cmbavLanguage_Internalname);
            AssignAttri("", false, "AV107Language", AV107Language);
            AV108Timezone = cgiGet( edtavTimezone_Internalname);
            AssignAttri("", false, "AV108Timezone", AV108Timezone);
            AV111URLImage = cgiGet( edtavUrlimage_Internalname);
            AssignAttri("", false, "AV111URLImage", AV111URLImage);
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
         E110W2 ();
         if (returnInSub) return;
      }

      protected void E110W2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_char1 = "";
         new gam_gettextpasswordrequirement(context ).execute( out  GXt_char1) ;
         lblTbpwdrequirements_Caption = GXt_char1;
         AssignProp("", false, lblTbpwdrequirements_Internalname, "Caption", lblTbpwdrequirements_Caption, true);
         AV99GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         if ( StringUtil.StrCmp(AV99GAMRepository.gxTpr_Useridentification, "email") == 0 )
         {
            edtavName_Visible = 0;
            AssignProp("", false, edtavName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavName_Visible), 5, 0), true);
         }
         /* Execute user subroutine: 'MARKREQUIEREDUSERDATA' */
         S112 ();
         if (returnInSub) return;
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E120W2 ();
         if (returnInSub) return;
      }

      protected void E120W2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV99GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         if ( StringUtil.StrCmp(AV19Password, AV20PasswordConf) == 0 )
         {
            AV100GAMUser.gxTpr_Name = AV18Name;
            AV100GAMUser.gxTpr_Email = AV5EMail;
            AV100GAMUser.gxTpr_Password = AV19Password;
            AV100GAMUser.gxTpr_Firstname = AV6FirstName;
            AV100GAMUser.gxTpr_Lastname = AV13LastName;
            AV100GAMUser.gxTpr_Phone = AV102Phone;
            AV100GAMUser.gxTpr_Birthday = AV22Birthday;
            AV100GAMUser.gxTpr_Gender = AV23Gender;
            AV100GAMUser.gxTpr_Address = AV103Address;
            AV100GAMUser.gxTpr_City = AV104City;
            AV100GAMUser.gxTpr_State = AV105State;
            AV100GAMUser.gxTpr_Postcode = AV106PostCode;
            AV100GAMUser.gxTpr_Language = AV107Language;
            AV100GAMUser.gxTpr_Timezone = AV108Timezone;
            AV100GAMUser.gxTpr_Urlimage = AV111URLImage;
            AV100GAMUser.save();
            if ( AV100GAMUser.success() )
            {
               context.CommitDataStores("gamexampleregisteruser",pr_default);
               if ( StringUtil.StrCmp(AV99GAMRepository.gxTpr_Useractivationmethod, "A") == 0 )
               {
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18Name)) )
                  {
                     AV18Name = AV5EMail;
                     AssignAttri("", false, "AV18Name", AV18Name);
                  }
                  AV15LoginOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).login(AV18Name, AV19Password, AV98GAMLoginAdditionalParameters, out  AV97GAMErrorCollection);
                  if ( AV15LoginOK )
                  {
                     CallWebObject(formatLink("gamhome.aspx") );
                     context.wjLocDisableFrm = 1;
                  }
                  else
                  {
                     /* Execute user subroutine: 'DISPLAYMESSAGES' */
                     S122 ();
                     if (returnInSub) return;
                  }
               }
               else
               {
                  AV14LinkURL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).applicationgetaccountactivationurl("");
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14LinkURL)) )
                  {
                     GXt_char1 = AV14LinkURL;
                     new gam_buildappurl(context ).execute(  "gam_activateuseraccount", out  GXt_char1) ;
                     AV14LinkURL = GXt_char1;
                     AV14LinkURL += "%1";
                  }
                  new gam_checkuseractivationmethod(context ).execute(  AV100GAMUser.gxTpr_Guid,  AV14LinkURL, out  AV17Messages) ;
                  AV101isRegisterError = false;
                  AV112GXV1 = 1;
                  while ( AV112GXV1 <= AV17Messages.Count )
                  {
                     AV16Message = ((GeneXus.Utils.SdtMessages_Message)AV17Messages.Item(AV112GXV1));
                     if ( AV16Message.gxTpr_Type == 1 )
                     {
                        AV101isRegisterError = true;
                        if (true) break;
                     }
                     AV112GXV1 = (int)(AV112GXV1+1);
                  }
                  if ( ! AV101isRegisterError )
                  {
                     edtavName_Enabled = 0;
                     AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
                     edtavEmail_Enabled = 0;
                     AssignProp("", false, edtavEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmail_Enabled), 5, 0), true);
                     edtavPassword_Enabled = 0;
                     AssignProp("", false, edtavPassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPassword_Enabled), 5, 0), true);
                     edtavPasswordconf_Enabled = 0;
                     AssignProp("", false, edtavPasswordconf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPasswordconf_Enabled), 5, 0), true);
                     edtavFirstname_Enabled = 0;
                     AssignProp("", false, edtavFirstname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFirstname_Enabled), 5, 0), true);
                     edtavLastname_Enabled = 0;
                     AssignProp("", false, edtavLastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLastname_Enabled), 5, 0), true);
                     edtavPhone_Enabled = 0;
                     AssignProp("", false, edtavPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPhone_Enabled), 5, 0), true);
                     edtavBirthday_Enabled = 0;
                     AssignProp("", false, edtavBirthday_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBirthday_Enabled), 5, 0), true);
                     cmbavGender.Enabled = 0;
                     AssignProp("", false, cmbavGender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavGender.Enabled), 5, 0), true);
                     edtavAddress_Enabled = 0;
                     AssignProp("", false, edtavAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAddress_Enabled), 5, 0), true);
                     edtavCity_Enabled = 0;
                     AssignProp("", false, edtavCity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCity_Enabled), 5, 0), true);
                     edtavState_Enabled = 0;
                     AssignProp("", false, edtavState_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavState_Enabled), 5, 0), true);
                     edtavPostcode_Enabled = 0;
                     AssignProp("", false, edtavPostcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPostcode_Enabled), 5, 0), true);
                     cmbavLanguage.Enabled = 0;
                     AssignProp("", false, cmbavLanguage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavLanguage.Enabled), 5, 0), true);
                     edtavTimezone_Enabled = 0;
                     AssignProp("", false, edtavTimezone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTimezone_Enabled), 5, 0), true);
                     edtavUrlimage_Enabled = 0;
                     AssignProp("", false, edtavUrlimage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUrlimage_Enabled), 5, 0), true);
                     bttLogin_Visible = 0;
                     AssignProp("", false, bttLogin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttLogin_Visible), 5, 0), true);
                  }
                  /* Execute user subroutine: 'DISPLAYMESSAGES' */
                  S122 ();
                  if (returnInSub) return;
               }
            }
            else
            {
               AV97GAMErrorCollection = AV100GAMUser.geterrors();
               /* Execute user subroutine: 'DISPLAYMESSAGES' */
               S122 ();
               if (returnInSub) return;
            }
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "GAM_Thepasswordandconfirmationpassworddonotmatch", ""));
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV99GAMRepository", AV99GAMRepository);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV100GAMUser", AV100GAMUser);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17Messages", AV17Messages);
      }

      protected void S112( )
      {
         /* 'MARKREQUIEREDUSERDATA' Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(AV99GAMRepository.gxTpr_Useridentification, "email") == 0 ) || ( StringUtil.StrCmp(AV99GAMRepository.gxTpr_Useridentification, "namema") == 0 ) )
         {
            if ( AV99GAMRepository.gxTpr_Requiredemail )
            {
               edtavEmail_Caption = edtavEmail_Caption+"  *";
               AssignProp("", false, edtavEmail_Internalname, "Caption", edtavEmail_Caption, true);
            }
         }
         if ( AV99GAMRepository.gxTpr_Requiredfirstname )
         {
            edtavFirstname_Caption = edtavFirstname_Caption+"  *";
            AssignProp("", false, edtavFirstname_Internalname, "Caption", edtavFirstname_Caption, true);
         }
         if ( AV99GAMRepository.gxTpr_Requiredlastname )
         {
            edtavLastname_Caption = edtavLastname_Caption+"  *";
            AssignProp("", false, edtavLastname_Internalname, "Caption", edtavLastname_Caption, true);
         }
         divCell_phone_Visible = 0;
         AssignProp("", false, divCell_phone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_phone_Visible), 5, 0), true);
         if ( AV99GAMRepository.gxTpr_Requiredphone )
         {
            divCell_phone_Visible = 1;
            AssignProp("", false, divCell_phone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_phone_Visible), 5, 0), true);
            edtavPhone_Caption = edtavPhone_Caption+"  *";
            AssignProp("", false, edtavPhone_Internalname, "Caption", edtavPhone_Caption, true);
         }
         divCell_birthday_Visible = 0;
         AssignProp("", false, divCell_birthday_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_birthday_Visible), 5, 0), true);
         if ( AV99GAMRepository.gxTpr_Requiredbirthday )
         {
            divCell_birthday_Visible = 1;
            AssignProp("", false, divCell_birthday_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_birthday_Visible), 5, 0), true);
            edtavBirthday_Caption = edtavBirthday_Caption+"  *";
            AssignProp("", false, edtavBirthday_Internalname, "Caption", edtavBirthday_Caption, true);
         }
         divCell_gender_Visible = 0;
         AssignProp("", false, divCell_gender_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_gender_Visible), 5, 0), true);
         if ( AV99GAMRepository.gxTpr_Requiredgender )
         {
            divCell_gender_Visible = 1;
            AssignProp("", false, divCell_gender_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_gender_Visible), 5, 0), true);
            cmbavGender.Caption = cmbavGender.Caption+"  *";
            AssignProp("", false, cmbavGender_Internalname, "Caption", cmbavGender.Caption, true);
         }
         divCell_address_Visible = 0;
         AssignProp("", false, divCell_address_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_address_Visible), 5, 0), true);
         if ( AV99GAMRepository.gxTpr_Requiredaddress )
         {
            divCell_address_Visible = 1;
            AssignProp("", false, divCell_address_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_address_Visible), 5, 0), true);
            edtavAddress_Caption = edtavAddress_Caption+"  *";
            AssignProp("", false, edtavAddress_Internalname, "Caption", edtavAddress_Caption, true);
         }
         divCell_city_Visible = 0;
         AssignProp("", false, divCell_city_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_city_Visible), 5, 0), true);
         if ( AV99GAMRepository.gxTpr_Requiredcity )
         {
            divCell_city_Visible = 1;
            AssignProp("", false, divCell_city_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_city_Visible), 5, 0), true);
            edtavCity_Caption = edtavCity_Caption+"  *";
            AssignProp("", false, edtavCity_Internalname, "Caption", edtavCity_Caption, true);
         }
         divCell_state_Visible = 0;
         AssignProp("", false, divCell_state_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_state_Visible), 5, 0), true);
         if ( AV99GAMRepository.gxTpr_Requiredstate )
         {
            divCell_state_Visible = 1;
            AssignProp("", false, divCell_state_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_state_Visible), 5, 0), true);
            edtavState_Caption = edtavState_Caption+"  *";
            AssignProp("", false, edtavState_Internalname, "Caption", edtavState_Caption, true);
         }
         divCell_postcode_Visible = 0;
         AssignProp("", false, divCell_postcode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_postcode_Visible), 5, 0), true);
         if ( AV99GAMRepository.gxTpr_Requiredpostcode )
         {
            divCell_postcode_Visible = 1;
            AssignProp("", false, divCell_postcode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_postcode_Visible), 5, 0), true);
            edtavPostcode_Caption = edtavPostcode_Caption+"  *";
            AssignProp("", false, edtavPostcode_Internalname, "Caption", edtavPostcode_Caption, true);
         }
         divCell_language_Visible = 0;
         AssignProp("", false, divCell_language_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_language_Visible), 5, 0), true);
         if ( AV99GAMRepository.gxTpr_Requiredlanguage )
         {
            /* Execute user subroutine: 'LOADLANGUAGES' */
            S132 ();
            if (returnInSub) return;
            divCell_language_Visible = 1;
            AssignProp("", false, divCell_language_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_language_Visible), 5, 0), true);
            cmbavLanguage.Caption = cmbavLanguage.Caption+"  *";
            AssignProp("", false, cmbavLanguage_Internalname, "Caption", cmbavLanguage.Caption, true);
         }
         divCell_timezone_Visible = 0;
         AssignProp("", false, divCell_timezone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_timezone_Visible), 5, 0), true);
         if ( AV99GAMRepository.gxTpr_Requiredtimezone )
         {
            divCell_timezone_Visible = 1;
            AssignProp("", false, divCell_timezone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_timezone_Visible), 5, 0), true);
            edtavTimezone_Caption = edtavTimezone_Caption+"  *";
            AssignProp("", false, edtavTimezone_Internalname, "Caption", edtavTimezone_Caption, true);
         }
         divCell_photo_Visible = 0;
         AssignProp("", false, divCell_photo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_photo_Visible), 5, 0), true);
         if ( AV99GAMRepository.gxTpr_Requiredphoto )
         {
            divCell_photo_Visible = 1;
            AssignProp("", false, divCell_photo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_photo_Visible), 5, 0), true);
            edtavUrlimage_Caption = edtavUrlimage_Caption+"  *";
            AssignProp("", false, edtavUrlimage_Internalname, "Caption", edtavUrlimage_Caption, true);
         }
      }

      protected void E130W2( )
      {
         /* 'Login' Routine */
         returnInSub = false;
         CallWebObject(formatLink("gamexamplelogin.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void S132( )
      {
         /* 'LOADLANGUAGES' Routine */
         returnInSub = false;
         AV30GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).get();
         AV109GAMApplicationLanguageCollection = AV30GAMApplication.gxTpr_Languages;
         AV113GXV2 = 1;
         while ( AV113GXV2 <= AV109GAMApplicationLanguageCollection.Count )
         {
            AV110GAMApplicationLanguage = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationLanguage)AV109GAMApplicationLanguageCollection.Item(AV113GXV2));
            if ( AV110GAMApplicationLanguage.gxTpr_Online )
            {
               cmbavLanguage.addItem(AV110GAMApplicationLanguage.gxTpr_Culture, AV110GAMApplicationLanguage.gxTpr_Description, 0);
            }
            AV113GXV2 = (int)(AV113GXV2+1);
         }
      }

      protected void S122( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         AV114GXV3 = 1;
         while ( AV114GXV3 <= AV17Messages.Count )
         {
            AV16Message = ((GeneXus.Utils.SdtMessages_Message)AV17Messages.Item(AV114GXV3));
            GX_msglist.addItem(AV16Message.gxTpr_Description);
            AV114GXV3 = (int)(AV114GXV3+1);
         }
         AV115GXV4 = 1;
         while ( AV115GXV4 <= AV97GAMErrorCollection.Count )
         {
            AV96GAMError = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV97GAMErrorCollection.Item(AV115GXV4));
            GX_msglist.addItem(AV96GAMError.gxTpr_Message);
            AV115GXV4 = (int)(AV115GXV4+1);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E140W2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA0W2( ) ;
         WS0W2( ) ;
         WE0W2( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025620177894", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages."+StringUtil.Lower( context.GetLanguageProperty( "code"))+".js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("gamexampleregisteruser.js", "?2025620177898", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavGender.Name = "vGENDER";
         cmbavGender.WebTags = "";
         cmbavGender.addItem("N", context.GetMessage( "GAM_NotSpecified", ""), 0);
         cmbavGender.addItem("F", context.GetMessage( "GAM_Female", ""), 0);
         cmbavGender.addItem("M", context.GetMessage( "GAM_Male", ""), 0);
         if ( cmbavGender.ItemCount > 0 )
         {
            AV23Gender = cmbavGender.getValidValue(AV23Gender);
            AssignAttri("", false, "AV23Gender", AV23Gender);
         }
         cmbavLanguage.Name = "vLANGUAGE";
         cmbavLanguage.WebTags = "";
         cmbavLanguage.addItem("", context.GetMessage( "GAM_None", ""), 0);
         if ( cmbavLanguage.ItemCount > 0 )
         {
            AV107Language = cmbavLanguage.getValidValue(AV107Language);
            AssignAttri("", false, "AV107Language", AV107Language);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTbtitle_Internalname = "TBTITLE";
         lblTbhaveaccount_Internalname = "TBHAVEACCOUNT";
         lblTblogin_Internalname = "TBLOGIN";
         edtavName_Internalname = "vNAME";
         edtavEmail_Internalname = "vEMAIL";
         edtavPassword_Internalname = "vPASSWORD";
         lblTbpwdrequirements_Internalname = "TBPWDREQUIREMENTS";
         edtavPasswordconf_Internalname = "vPASSWORDCONF";
         edtavFirstname_Internalname = "vFIRSTNAME";
         divCell_firstname_Internalname = "CELL_FIRSTNAME";
         edtavLastname_Internalname = "vLASTNAME";
         divCell_lastname_Internalname = "CELL_LASTNAME";
         edtavPhone_Internalname = "vPHONE";
         divCell_phone_Internalname = "CELL_PHONE";
         edtavBirthday_Internalname = "vBIRTHDAY";
         divCell_birthday_Internalname = "CELL_BIRTHDAY";
         cmbavGender_Internalname = "vGENDER";
         divCell_gender_Internalname = "CELL_GENDER";
         edtavAddress_Internalname = "vADDRESS";
         divCell_address_Internalname = "CELL_ADDRESS";
         edtavCity_Internalname = "vCITY";
         divCell_city_Internalname = "CELL_CITY";
         edtavState_Internalname = "vSTATE";
         divCell_state_Internalname = "CELL_STATE";
         edtavPostcode_Internalname = "vPOSTCODE";
         divCell_postcode_Internalname = "CELL_POSTCODE";
         cmbavLanguage_Internalname = "vLANGUAGE";
         divCell_language_Internalname = "CELL_LANGUAGE";
         edtavTimezone_Internalname = "vTIMEZONE";
         divCell_timezone_Internalname = "CELL_TIMEZONE";
         edtavUrlimage_Internalname = "vURLIMAGE";
         divCell_photo_Internalname = "CELL_PHOTO";
         bttLogin_Internalname = "LOGIN";
         divTbpwd_Internalname = "TBPWD";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         bttLogin_Visible = 1;
         edtavUrlimage_Jsonclick = "";
         edtavUrlimage_Enabled = 1;
         edtavUrlimage_Caption = context.GetMessage( "GAM_URLimage", "");
         divCell_photo_Visible = 1;
         edtavTimezone_Jsonclick = "";
         edtavTimezone_Enabled = 1;
         edtavTimezone_Caption = context.GetMessage( "GAM_Timezone", "");
         divCell_timezone_Visible = 1;
         cmbavLanguage_Jsonclick = "";
         cmbavLanguage.Enabled = 1;
         cmbavLanguage.Caption = context.GetMessage( "GAM_Language", "");
         divCell_language_Visible = 1;
         edtavPostcode_Jsonclick = "";
         edtavPostcode_Enabled = 1;
         edtavPostcode_Caption = context.GetMessage( "GAM_PostCode", "");
         divCell_postcode_Visible = 1;
         edtavState_Jsonclick = "";
         edtavState_Enabled = 1;
         edtavState_Caption = context.GetMessage( "GAM_State", "");
         divCell_state_Visible = 1;
         edtavCity_Jsonclick = "";
         edtavCity_Enabled = 1;
         edtavCity_Caption = context.GetMessage( "GAM_City", "");
         divCell_city_Visible = 1;
         edtavAddress_Jsonclick = "";
         edtavAddress_Enabled = 1;
         edtavAddress_Caption = context.GetMessage( "GAM_Address", "");
         divCell_address_Visible = 1;
         cmbavGender_Jsonclick = "";
         cmbavGender.Enabled = 1;
         cmbavGender.Caption = context.GetMessage( "GAM_Gender", "");
         divCell_gender_Visible = 1;
         edtavBirthday_Jsonclick = "";
         edtavBirthday_Enabled = 1;
         edtavBirthday_Caption = context.GetMessage( "GAM_Birthday", "");
         divCell_birthday_Visible = 1;
         edtavPhone_Jsonclick = "";
         edtavPhone_Enabled = 1;
         edtavPhone_Caption = context.GetMessage( "GAM_Phone", "");
         divCell_phone_Visible = 1;
         edtavLastname_Jsonclick = "";
         edtavLastname_Enabled = 1;
         edtavLastname_Caption = context.GetMessage( "GAM_LastName", "");
         edtavFirstname_Jsonclick = "";
         edtavFirstname_Enabled = 1;
         edtavFirstname_Caption = context.GetMessage( "GAM_FirstName", "");
         edtavPasswordconf_Jsonclick = "";
         edtavPasswordconf_Enabled = 1;
         lblTbpwdrequirements_Caption = "";
         edtavPassword_Jsonclick = "";
         edtavPassword_Enabled = 1;
         edtavEmail_Jsonclick = "";
         edtavEmail_Enabled = 1;
         edtavEmail_Caption = context.GetMessage( "GAM_Email", "");
         edtavName_Jsonclick = "";
         edtavName_Enabled = 1;
         edtavName_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("ENTER","""{"handler":"E120W2","iparms":[{"av":"AV19Password","fld":"vPASSWORD"},{"av":"AV20PasswordConf","fld":"vPASSWORDCONF"},{"av":"AV18Name","fld":"vNAME"},{"av":"AV5EMail","fld":"vEMAIL"},{"av":"AV6FirstName","fld":"vFIRSTNAME"},{"av":"AV13LastName","fld":"vLASTNAME"},{"av":"AV102Phone","fld":"vPHONE"},{"av":"AV22Birthday","fld":"vBIRTHDAY"},{"av":"cmbavGender"},{"av":"AV23Gender","fld":"vGENDER"},{"av":"AV103Address","fld":"vADDRESS"},{"av":"AV104City","fld":"vCITY"},{"av":"AV105State","fld":"vSTATE"},{"av":"AV106PostCode","fld":"vPOSTCODE"},{"av":"cmbavLanguage"},{"av":"AV107Language","fld":"vLANGUAGE"},{"av":"AV108Timezone","fld":"vTIMEZONE"},{"av":"AV111URLImage","fld":"vURLIMAGE"},{"av":"AV17Messages","fld":"vMESSAGES"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV18Name","fld":"vNAME"},{"av":"AV17Messages","fld":"vMESSAGES"},{"av":"edtavName_Enabled","ctrl":"vNAME","prop":"Enabled"},{"av":"edtavEmail_Enabled","ctrl":"vEMAIL","prop":"Enabled"},{"av":"edtavPassword_Enabled","ctrl":"vPASSWORD","prop":"Enabled"},{"av":"edtavPasswordconf_Enabled","ctrl":"vPASSWORDCONF","prop":"Enabled"},{"av":"edtavFirstname_Enabled","ctrl":"vFIRSTNAME","prop":"Enabled"},{"av":"edtavLastname_Enabled","ctrl":"vLASTNAME","prop":"Enabled"},{"av":"edtavPhone_Enabled","ctrl":"vPHONE","prop":"Enabled"},{"av":"edtavBirthday_Enabled","ctrl":"vBIRTHDAY","prop":"Enabled"},{"av":"cmbavGender"},{"av":"edtavAddress_Enabled","ctrl":"vADDRESS","prop":"Enabled"},{"av":"edtavCity_Enabled","ctrl":"vCITY","prop":"Enabled"},{"av":"edtavState_Enabled","ctrl":"vSTATE","prop":"Enabled"},{"av":"edtavPostcode_Enabled","ctrl":"vPOSTCODE","prop":"Enabled"},{"av":"cmbavLanguage"},{"av":"edtavTimezone_Enabled","ctrl":"vTIMEZONE","prop":"Enabled"},{"av":"edtavUrlimage_Enabled","ctrl":"vURLIMAGE","prop":"Enabled"},{"ctrl":"LOGIN","prop":"Visible"}]}""");
         setEventMetadata("'LOGIN'","""{"handler":"E130W2","iparms":[]}""");
         setEventMetadata("VALIDV_GENDER","""{"handler":"Validv_Gender","iparms":[]}""");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV17Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GX_FocusControl = "";
         sPrefix = "";
         lblTbtitle_Jsonclick = "";
         lblTbhaveaccount_Jsonclick = "";
         lblTblogin_Jsonclick = "";
         TempTags = "";
         AV18Name = "";
         AV5EMail = "";
         AV19Password = "";
         lblTbpwdrequirements_Jsonclick = "";
         AV20PasswordConf = "";
         AV6FirstName = "";
         AV13LastName = "";
         AV102Phone = "";
         AV22Birthday = DateTime.MinValue;
         AV23Gender = "";
         AV103Address = "";
         AV104City = "";
         AV105State = "";
         AV106PostCode = "";
         AV107Language = "";
         AV108Timezone = "";
         AV111URLImage = "";
         ClassString = "";
         StyleString = "";
         bttLogin_Jsonclick = "";
         Form = new GXWebForm();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV99GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV100GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV98GAMLoginAdditionalParameters = new GeneXus.Programs.genexussecurity.SdtGAMLoginAdditionalParameters(context);
         AV97GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV14LinkURL = "";
         GXt_char1 = "";
         AV16Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV30GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV109GAMApplicationLanguageCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationLanguage>( context, "GeneXus.Programs.genexussecurity.SdtGAMApplicationLanguage", "GeneXus.Programs");
         AV110GAMApplicationLanguage = new GeneXus.Programs.genexussecurity.SdtGAMApplicationLanguage(context);
         AV96GAMError = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.gamexampleregisteruser__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.gamexampleregisteruser__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gamexampleregisteruser__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int edtavName_Visible ;
      private int edtavName_Enabled ;
      private int edtavEmail_Enabled ;
      private int edtavPassword_Enabled ;
      private int edtavPasswordconf_Enabled ;
      private int edtavFirstname_Enabled ;
      private int edtavLastname_Enabled ;
      private int divCell_phone_Visible ;
      private int edtavPhone_Enabled ;
      private int divCell_birthday_Visible ;
      private int edtavBirthday_Enabled ;
      private int divCell_gender_Visible ;
      private int divCell_address_Visible ;
      private int edtavAddress_Enabled ;
      private int divCell_city_Visible ;
      private int edtavCity_Enabled ;
      private int divCell_state_Visible ;
      private int edtavState_Enabled ;
      private int divCell_postcode_Visible ;
      private int edtavPostcode_Enabled ;
      private int divCell_language_Visible ;
      private int divCell_timezone_Visible ;
      private int edtavTimezone_Enabled ;
      private int divCell_photo_Visible ;
      private int edtavUrlimage_Enabled ;
      private int bttLogin_Visible ;
      private int AV112GXV1 ;
      private int AV113GXV2 ;
      private int AV114GXV3 ;
      private int AV115GXV4 ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divTbpwd_Internalname ;
      private string lblTbtitle_Internalname ;
      private string lblTbtitle_Jsonclick ;
      private string lblTbhaveaccount_Internalname ;
      private string lblTbhaveaccount_Jsonclick ;
      private string lblTblogin_Internalname ;
      private string lblTblogin_Jsonclick ;
      private string edtavName_Internalname ;
      private string TempTags ;
      private string edtavName_Jsonclick ;
      private string edtavEmail_Internalname ;
      private string edtavEmail_Caption ;
      private string edtavEmail_Jsonclick ;
      private string edtavPassword_Internalname ;
      private string AV19Password ;
      private string edtavPassword_Jsonclick ;
      private string lblTbpwdrequirements_Internalname ;
      private string lblTbpwdrequirements_Caption ;
      private string lblTbpwdrequirements_Jsonclick ;
      private string edtavPasswordconf_Internalname ;
      private string AV20PasswordConf ;
      private string edtavPasswordconf_Jsonclick ;
      private string divCell_firstname_Internalname ;
      private string edtavFirstname_Internalname ;
      private string edtavFirstname_Caption ;
      private string AV6FirstName ;
      private string edtavFirstname_Jsonclick ;
      private string divCell_lastname_Internalname ;
      private string edtavLastname_Internalname ;
      private string edtavLastname_Caption ;
      private string AV13LastName ;
      private string edtavLastname_Jsonclick ;
      private string divCell_phone_Internalname ;
      private string edtavPhone_Internalname ;
      private string edtavPhone_Caption ;
      private string AV102Phone ;
      private string edtavPhone_Jsonclick ;
      private string divCell_birthday_Internalname ;
      private string edtavBirthday_Internalname ;
      private string edtavBirthday_Caption ;
      private string edtavBirthday_Jsonclick ;
      private string divCell_gender_Internalname ;
      private string cmbavGender_Internalname ;
      private string AV23Gender ;
      private string cmbavGender_Jsonclick ;
      private string divCell_address_Internalname ;
      private string edtavAddress_Internalname ;
      private string edtavAddress_Caption ;
      private string AV103Address ;
      private string edtavAddress_Jsonclick ;
      private string divCell_city_Internalname ;
      private string edtavCity_Internalname ;
      private string edtavCity_Caption ;
      private string AV104City ;
      private string edtavCity_Jsonclick ;
      private string divCell_state_Internalname ;
      private string edtavState_Internalname ;
      private string edtavState_Caption ;
      private string AV105State ;
      private string edtavState_Jsonclick ;
      private string divCell_postcode_Internalname ;
      private string edtavPostcode_Internalname ;
      private string edtavPostcode_Caption ;
      private string AV106PostCode ;
      private string edtavPostcode_Jsonclick ;
      private string divCell_language_Internalname ;
      private string cmbavLanguage_Internalname ;
      private string cmbavLanguage_Jsonclick ;
      private string divCell_timezone_Internalname ;
      private string edtavTimezone_Internalname ;
      private string edtavTimezone_Caption ;
      private string AV108Timezone ;
      private string edtavTimezone_Jsonclick ;
      private string divCell_photo_Internalname ;
      private string edtavUrlimage_Internalname ;
      private string edtavUrlimage_Caption ;
      private string edtavUrlimage_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string bttLogin_Internalname ;
      private string bttLogin_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXt_char1 ;
      private DateTime AV22Birthday ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV15LoginOK ;
      private bool AV101isRegisterError ;
      private string AV18Name ;
      private string AV5EMail ;
      private string AV107Language ;
      private string AV111URLImage ;
      private string AV14LinkURL ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavGender ;
      private GXCombobox cmbavLanguage ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV17Messages ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV99GAMRepository ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV100GAMUser ;
      private IDataStoreProvider pr_default ;
      private GeneXus.Programs.genexussecurity.SdtGAMLoginAdditionalParameters AV98GAMLoginAdditionalParameters ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV97GAMErrorCollection ;
      private GeneXus.Utils.SdtMessages_Message AV16Message ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV30GAMApplication ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationLanguage> AV109GAMApplicationLanguageCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationLanguage AV110GAMApplicationLanguage ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV96GAMError ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class gamexampleregisteruser__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class gamexampleregisteruser__gam : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

  public override string getDataStoreName( )
  {
     return "GAM";
  }

}

public class gamexampleregisteruser__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       def= new CursorDef[] {
       };
    }
 }

 public void getResults( int cursor ,
                         IFieldGetter rslt ,
                         Object[] buf )
 {
 }

}

}
