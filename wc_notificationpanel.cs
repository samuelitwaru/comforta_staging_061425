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
   public class wc_notificationpanel : GXWebComponent
   {
      public wc_notificationpanel( )
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

      public wc_notificationpanel( IGxContext context )
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

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         chkavIstoallusers = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
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
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix});
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
            PA7P2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS7P2( ) ;
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
            context.SendWebValue( context.GetMessage( "Notification Details", "")) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
            context.WriteHtmlText( " "+"class=\"form-horizontal AllowOverflowModal\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal AllowOverflowModal\" data-gx-class=\"form-horizontal AllowOverflowModal\" novalidate action=\""+formatLink("wc_notificationpanel.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal AllowOverflowModal", true);
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
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal AllowOverflowModal" : Form.Class)+"-fx");
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV17DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV17DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGROUPLIST_DATA", AV24GroupList_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGROUPLIST_DATA", AV24GroupList_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vRECIPIENTLIST_DATA", AV16RecipientList_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vRECIPIENTLIST_DATA", AV16RecipientList_Data);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV10CheckRequiredFieldsResult);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vUPDATEDRECIPIENTLIST", AV30UpdatedRecipientList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vUPDATEDRECIPIENTLIST", AV30UpdatedRecipientList);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vRECIPIENTLIST", AV14RecipientList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vRECIPIENTLIST", AV14RecipientList);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGROUPLIST", AV23GroupList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGROUPLIST", AV23GroupList);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"RESIDENTPACKAGEID", A527ResidentPackageId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"RESIDENTID", A62ResidentId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_GROUPLIST_Cls", StringUtil.RTrim( Combo_grouplist_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_GROUPLIST_Selectedvalue_set", StringUtil.RTrim( Combo_grouplist_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_GROUPLIST_Selectedtext_set", StringUtil.RTrim( Combo_grouplist_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_GROUPLIST_Gamoauthtoken", StringUtil.RTrim( Combo_grouplist_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_GROUPLIST_Ddointernalname", StringUtil.RTrim( Combo_grouplist_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_GROUPLIST_Allowmultipleselection", StringUtil.BoolToStr( Combo_grouplist_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_GROUPLIST_Datalistproc", StringUtil.RTrim( Combo_grouplist_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_GROUPLIST_Datalistprocparametersprefix", StringUtil.RTrim( Combo_grouplist_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_GROUPLIST_Includeonlyselectedoption", StringUtil.BoolToStr( Combo_grouplist_Includeonlyselectedoption));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_GROUPLIST_Htmltemplate", StringUtil.RTrim( Combo_grouplist_Htmltemplate));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_GROUPLIST_Multiplevaluestype", StringUtil.RTrim( Combo_grouplist_Multiplevaluestype));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_GROUPLIST_Emptyitemtext", StringUtil.RTrim( Combo_grouplist_Emptyitemtext));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RECIPIENTLIST_Cls", StringUtil.RTrim( Combo_recipientlist_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RECIPIENTLIST_Selectedvalue_set", StringUtil.RTrim( Combo_recipientlist_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RECIPIENTLIST_Selectedtext_set", StringUtil.RTrim( Combo_recipientlist_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RECIPIENTLIST_Gamoauthtoken", StringUtil.RTrim( Combo_recipientlist_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RECIPIENTLIST_Allowmultipleselection", StringUtil.BoolToStr( Combo_recipientlist_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RECIPIENTLIST_Datalistproc", StringUtil.RTrim( Combo_recipientlist_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RECIPIENTLIST_Datalistprocparametersprefix", StringUtil.RTrim( Combo_recipientlist_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RECIPIENTLIST_Includeonlyselectedoption", StringUtil.BoolToStr( Combo_recipientlist_Includeonlyselectedoption));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RECIPIENTLIST_Htmltemplate", StringUtil.RTrim( Combo_recipientlist_Htmltemplate));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RECIPIENTLIST_Multiplevaluestype", StringUtil.RTrim( Combo_recipientlist_Multiplevaluestype));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RECIPIENTLIST_Emptyitemtext", StringUtil.RTrim( Combo_recipientlist_Emptyitemtext));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RECIPIENTLIST_Selectedvalue_get", StringUtil.RTrim( Combo_recipientlist_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_GROUPLIST_Selectedvalue_get", StringUtil.RTrim( Combo_grouplist_Selectedvalue_get));
      }

      protected void RenderHtmlCloseForm7P2( )
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
         return "WC_NotificationPanel" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Notification Details", "") ;
      }

      protected void WB7P0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wc_notificationpanel.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainPopup", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTitle_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTitle_Internalname, context.GetMessage( "Title", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTitle_Internalname, AV7Title, StringUtil.RTrim( context.localUtil.Format( AV7Title, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "Notification Title", ""), edtavTitle_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTitle_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "GeneXusUnanimo\\Title", "start", true, "", "HLP_WC_NotificationPanel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavMessage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMessage_Internalname, context.GetMessage( "Message", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavMessage_Internalname, AV8Message, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", 0, 1, edtavMessage_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", context.GetMessage( "Notification Message...", ""), -1, true, "GeneXusUnanimo\\Description", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WC_NotificationPanel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedgrouplist_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_grouplist_Internalname, context.GetMessage( "Groups", ""), "", "", lblTextblockcombo_grouplist_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WC_NotificationPanel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_grouplist.SetProperty("Caption", Combo_grouplist_Caption);
            ucCombo_grouplist.SetProperty("Cls", Combo_grouplist_Cls);
            ucCombo_grouplist.SetProperty("AllowMultipleSelection", Combo_grouplist_Allowmultipleselection);
            ucCombo_grouplist.SetProperty("DataListProc", Combo_grouplist_Datalistproc);
            ucCombo_grouplist.SetProperty("DataListProcParametersPrefix", Combo_grouplist_Datalistprocparametersprefix);
            ucCombo_grouplist.SetProperty("IncludeOnlySelectedOption", Combo_grouplist_Includeonlyselectedoption);
            ucCombo_grouplist.SetProperty("MultipleValuesType", Combo_grouplist_Multiplevaluestype);
            ucCombo_grouplist.SetProperty("EmptyItemText", Combo_grouplist_Emptyitemtext);
            ucCombo_grouplist.SetProperty("DropDownOptionsTitleSettingsIcons", AV17DDO_TitleSettingsIcons);
            ucCombo_grouplist.SetProperty("DropDownOptionsData", AV24GroupList_Data);
            ucCombo_grouplist.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_grouplist_Internalname, sPrefix+"COMBO_GROUPLISTContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedrecipientlist_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_recipientlist_Internalname, context.GetMessage( "Recipients", ""), "", "", lblTextblockcombo_recipientlist_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WC_NotificationPanel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_recipientlist.SetProperty("Caption", Combo_recipientlist_Caption);
            ucCombo_recipientlist.SetProperty("Cls", Combo_recipientlist_Cls);
            ucCombo_recipientlist.SetProperty("AllowMultipleSelection", Combo_recipientlist_Allowmultipleselection);
            ucCombo_recipientlist.SetProperty("DataListProc", Combo_recipientlist_Datalistproc);
            ucCombo_recipientlist.SetProperty("DataListProcParametersPrefix", Combo_recipientlist_Datalistprocparametersprefix);
            ucCombo_recipientlist.SetProperty("IncludeOnlySelectedOption", Combo_recipientlist_Includeonlyselectedoption);
            ucCombo_recipientlist.SetProperty("MultipleValuesType", Combo_recipientlist_Multiplevaluestype);
            ucCombo_recipientlist.SetProperty("EmptyItemText", Combo_recipientlist_Emptyitemtext);
            ucCombo_recipientlist.SetProperty("DropDownOptionsTitleSettingsIcons", AV17DDO_TitleSettingsIcons);
            ucCombo_recipientlist.SetProperty("DropDownOptionsData", AV16RecipientList_Data);
            ucCombo_recipientlist.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_recipientlist_Internalname, sPrefix+"COMBO_RECIPIENTLISTContainer");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "end", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsendnotification_Internalname, "", context.GetMessage( "Send Notification", ""), bttBtnsendnotification_Jsonclick, 5, context.GetMessage( "Send Notification", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOSENDNOTIFICATION\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WC_NotificationPanel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "end", "top", "div");
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
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIstoallusers_Internalname, StringUtil.BoolToStr( AV9isToAllUsers), "", "", chkavIstoallusers.Visible, 1, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(50, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,50);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START7P2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Notification Details", ""), 0) ;
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
               STRUP7P0( ) ;
            }
         }
      }

      protected void WS7P2( )
      {
         START7P2( ) ;
         EVT7P2( ) ;
      }

      protected void EVT7P2( )
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
                                 STRUP7P0( ) ;
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
                                 STRUP7P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E117P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOSENDNOTIFICATION'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoSendNotification' */
                                    E127P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E137P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7P0( ) ;
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
                                 STRUP7P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavTitle_Internalname;
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

      protected void WE7P2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm7P2( ) ;
            }
         }
      }

      protected void PA7P2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Crypto.GetSiteKey( );
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
               GX_FocusControl = edtavTitle_Internalname;
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
         AV9isToAllUsers = StringUtil.StrToBool( StringUtil.BoolToStr( AV9isToAllUsers));
         AssignAttri(sPrefix, false, "AV9isToAllUsers", AV9isToAllUsers);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF7P2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF7P2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E137P2 ();
            WB7P0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes7P2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7P0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E117P2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV17DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vGROUPLIST_DATA"), AV24GroupList_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vRECIPIENTLIST_DATA"), AV16RecipientList_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vGROUPLIST"), AV23GroupList);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vRECIPIENTLIST"), AV14RecipientList);
            /* Read saved values. */
            Combo_grouplist_Cls = cgiGet( sPrefix+"COMBO_GROUPLIST_Cls");
            Combo_grouplist_Selectedvalue_set = cgiGet( sPrefix+"COMBO_GROUPLIST_Selectedvalue_set");
            Combo_grouplist_Selectedtext_set = cgiGet( sPrefix+"COMBO_GROUPLIST_Selectedtext_set");
            Combo_grouplist_Gamoauthtoken = cgiGet( sPrefix+"COMBO_GROUPLIST_Gamoauthtoken");
            Combo_grouplist_Ddointernalname = cgiGet( sPrefix+"COMBO_GROUPLIST_Ddointernalname");
            Combo_grouplist_Allowmultipleselection = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_GROUPLIST_Allowmultipleselection"));
            Combo_grouplist_Datalistproc = cgiGet( sPrefix+"COMBO_GROUPLIST_Datalistproc");
            Combo_grouplist_Datalistprocparametersprefix = cgiGet( sPrefix+"COMBO_GROUPLIST_Datalistprocparametersprefix");
            Combo_grouplist_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_GROUPLIST_Includeonlyselectedoption"));
            Combo_grouplist_Htmltemplate = cgiGet( sPrefix+"COMBO_GROUPLIST_Htmltemplate");
            Combo_grouplist_Multiplevaluestype = cgiGet( sPrefix+"COMBO_GROUPLIST_Multiplevaluestype");
            Combo_grouplist_Emptyitemtext = cgiGet( sPrefix+"COMBO_GROUPLIST_Emptyitemtext");
            Combo_recipientlist_Cls = cgiGet( sPrefix+"COMBO_RECIPIENTLIST_Cls");
            Combo_recipientlist_Selectedvalue_set = cgiGet( sPrefix+"COMBO_RECIPIENTLIST_Selectedvalue_set");
            Combo_recipientlist_Selectedtext_set = cgiGet( sPrefix+"COMBO_RECIPIENTLIST_Selectedtext_set");
            Combo_recipientlist_Gamoauthtoken = cgiGet( sPrefix+"COMBO_RECIPIENTLIST_Gamoauthtoken");
            Combo_recipientlist_Allowmultipleselection = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_RECIPIENTLIST_Allowmultipleselection"));
            Combo_recipientlist_Datalistproc = cgiGet( sPrefix+"COMBO_RECIPIENTLIST_Datalistproc");
            Combo_recipientlist_Datalistprocparametersprefix = cgiGet( sPrefix+"COMBO_RECIPIENTLIST_Datalistprocparametersprefix");
            Combo_recipientlist_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_RECIPIENTLIST_Includeonlyselectedoption"));
            Combo_recipientlist_Htmltemplate = cgiGet( sPrefix+"COMBO_RECIPIENTLIST_Htmltemplate");
            Combo_recipientlist_Multiplevaluestype = cgiGet( sPrefix+"COMBO_RECIPIENTLIST_Multiplevaluestype");
            Combo_recipientlist_Emptyitemtext = cgiGet( sPrefix+"COMBO_RECIPIENTLIST_Emptyitemtext");
            /* Read variables values. */
            AV7Title = cgiGet( edtavTitle_Internalname);
            AssignAttri(sPrefix, false, "AV7Title", AV7Title);
            AV8Message = cgiGet( edtavMessage_Internalname);
            AssignAttri(sPrefix, false, "AV8Message", AV8Message);
            AV9isToAllUsers = StringUtil.StrToBool( cgiGet( chkavIstoallusers_Internalname));
            AssignAttri(sPrefix, false, "AV9isToAllUsers", AV9isToAllUsers);
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
         E117P2 ();
         if (returnInSub) return;
      }

      protected void E117P2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp(sPrefix, false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV17DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV17DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV20GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV21GAMErrors);
         Combo_recipientlist_Gamoauthtoken = AV20GAMSession.gxTpr_Token;
         ucCombo_recipientlist.SendProperty(context, sPrefix, false, Combo_recipientlist_Internalname, "GAMOAuthToken", Combo_recipientlist_Gamoauthtoken);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and font icon", out  GXt_char2) ;
         Combo_recipientlist_Htmltemplate = GXt_char2;
         ucCombo_recipientlist.SendProperty(context, sPrefix, false, Combo_recipientlist_Internalname, "HTMLTemplate", Combo_recipientlist_Htmltemplate);
         Combo_grouplist_Gamoauthtoken = AV20GAMSession.gxTpr_Token;
         ucCombo_grouplist.SendProperty(context, sPrefix, false, Combo_grouplist_Internalname, "GAMOAuthToken", Combo_grouplist_Gamoauthtoken);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and font icon", out  GXt_char2) ;
         Combo_grouplist_Htmltemplate = GXt_char2;
         ucCombo_grouplist.SendProperty(context, sPrefix, false, Combo_grouplist_Internalname, "HTMLTemplate", Combo_grouplist_Htmltemplate);
         /* Execute user subroutine: 'LOADCOMBOGROUPLIST' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBORECIPIENTLIST' */
         S122 ();
         if (returnInSub) return;
         chkavIstoallusers.Visible = 0;
         AssignProp(sPrefix, false, chkavIstoallusers_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavIstoallusers.Visible), 5, 0), true);
         GXt_char2 = AV22ResidentsTitle;
         new prc_getorganisationdefinition(context ).execute(  "Residents", out  GXt_char2) ;
         AV22ResidentsTitle = GXt_char2;
         Combo_recipientlist_Emptyitemtext = context.GetMessage( "All ", "")+AV22ResidentsTitle;
         ucCombo_recipientlist.SendProperty(context, sPrefix, false, Combo_recipientlist_Internalname, "EmptyItemText", Combo_recipientlist_Emptyitemtext);
         Combo_grouplist_Ddointernalname = AV22ResidentsTitle+context.GetMessage( " Group", "");
         ucCombo_grouplist.SendProperty(context, sPrefix, false, Combo_grouplist_Internalname, "DDOInternalName", Combo_grouplist_Ddointernalname);
         Combo_grouplist_Emptyitemtext = context.GetMessage( "Select ", "")+AV22ResidentsTitle+context.GetMessage( " Group", "");
         ucCombo_grouplist.SendProperty(context, sPrefix, false, Combo_grouplist_Internalname, "EmptyItemText", Combo_grouplist_Emptyitemtext);
      }

      protected void E127P2( )
      {
         /* 'DoSendNotification' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S132 ();
         if (returnInSub) return;
         if ( AV10CheckRequiredFieldsResult )
         {
            AV13Metadata = new SdtSDT_OneSignalCustomData(context);
            AV13Metadata.gxTpr_Notificationcategory = "General";
            /* Execute user subroutine: 'GETRECIPIENTLIST' */
            S142 ();
            if (returnInSub) return;
            new prc_sendresidentnotification(context ).execute(  AV7Title,  AV8Message,  "GENERAL",  AV13Metadata,  AV30UpdatedRecipientList) ;
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  context.GetMessage( "Message sent", ""),  "success",  "",  "true",  ""));
            AV7Title = "";
            AssignAttri(sPrefix, false, "AV7Title", AV7Title);
            AV8Message = "";
            AssignAttri(sPrefix, false, "AV8Message", AV8Message);
            this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "WCPopup_Close", new Object[] {(string)""}, false);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV30UpdatedRecipientList", AV30UpdatedRecipientList);
      }

      protected void S132( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV10CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV7Title)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Title", ""), "", "", "", "", "", "", "", ""),  "error",  edtavTitle_Internalname,  "true",  ""));
            AV10CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8Message)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Message", ""), "", "", "", "", "", "", "", ""),  "error",  edtavMessage_Internalname,  "true",  ""));
            AV10CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBORECIPIENTLIST' Routine */
         returnInSub = false;
         Combo_recipientlist_Selectedtext_set = AV19RecipientListDescriptionCol.ToJSonString(false);
         ucCombo_recipientlist.SendProperty(context, sPrefix, false, Combo_recipientlist_Internalname, "SelectedText_set", Combo_recipientlist_Selectedtext_set);
         Combo_recipientlist_Selectedvalue_set = AV14RecipientList.ToJSonString(false);
         ucCombo_recipientlist.SendProperty(context, sPrefix, false, Combo_recipientlist_Internalname, "SelectedValue_set", Combo_recipientlist_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'LOADCOMBOGROUPLIST' Routine */
         returnInSub = false;
         Combo_grouplist_Selectedtext_set = AV25GroupListDescriptionCol.ToJSonString(false);
         ucCombo_grouplist.SendProperty(context, sPrefix, false, Combo_grouplist_Internalname, "SelectedText_set", Combo_grouplist_Selectedtext_set);
         Combo_grouplist_Selectedvalue_set = AV23GroupList.ToJSonString(false);
         ucCombo_grouplist.SendProperty(context, sPrefix, false, Combo_grouplist_Internalname, "SelectedValue_set", Combo_grouplist_Selectedvalue_set);
      }

      protected void S142( )
      {
         /* 'GETRECIPIENTLIST' Routine */
         returnInSub = false;
         AV29PackageGroupResidentIdCollection = (GxSimpleCollection<Guid>)(new GxSimpleCollection<Guid>());
         AV29PackageGroupResidentIdCollection = (GxSimpleCollection<Guid>)(AV14RecipientList.Clone());
         AV31GXV1 = 1;
         while ( AV31GXV1 <= AV23GroupList.Count )
         {
            AV28GroupListItem = ((Guid)AV23GroupList.Item(AV31GXV1));
            AssignAttri(sPrefix, false, "AV28GroupListItem", AV28GroupListItem.ToString());
            /* Using cursor H007P2 */
            pr_default.execute(0, new Object[] {AV28GroupListItem});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A527ResidentPackageId = H007P2_A527ResidentPackageId[0];
               n527ResidentPackageId = H007P2_n527ResidentPackageId[0];
               A62ResidentId = H007P2_A62ResidentId[0];
               if ( ! (AV29PackageGroupResidentIdCollection.IndexOf(A62ResidentId)>0) )
               {
                  AV29PackageGroupResidentIdCollection.Add(A62ResidentId, 0);
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV31GXV1 = (int)(AV31GXV1+1);
         }
         AV30UpdatedRecipientList = AV29PackageGroupResidentIdCollection;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void nextLoad( )
      {
      }

      protected void E137P2( )
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
         PA7P2( ) ;
         WS7P2( ) ;
         WE7P2( ) ;
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
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA7P2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wc_notificationpanel", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA7P2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
         }
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
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
         PA7P2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS7P2( ) ;
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
         WS7P2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
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
         WE7P2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202571111435240", true, true);
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
         context.AddJavascriptSource("wc_notificationpanel.js", "?202571111435242", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         chkavIstoallusers.Name = "vISTOALLUSERS";
         chkavIstoallusers.WebTags = "";
         chkavIstoallusers.Caption = "";
         AssignProp(sPrefix, false, chkavIstoallusers_Internalname, "TitleCaption", chkavIstoallusers.Caption, true);
         chkavIstoallusers.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavTitle_Internalname = sPrefix+"vTITLE";
         edtavMessage_Internalname = sPrefix+"vMESSAGE";
         lblTextblockcombo_grouplist_Internalname = sPrefix+"TEXTBLOCKCOMBO_GROUPLIST";
         Combo_grouplist_Internalname = sPrefix+"COMBO_GROUPLIST";
         divTablesplittedgrouplist_Internalname = sPrefix+"TABLESPLITTEDGROUPLIST";
         lblTextblockcombo_recipientlist_Internalname = sPrefix+"TEXTBLOCKCOMBO_RECIPIENTLIST";
         Combo_recipientlist_Internalname = sPrefix+"COMBO_RECIPIENTLIST";
         divTablesplittedrecipientlist_Internalname = sPrefix+"TABLESPLITTEDRECIPIENTLIST";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         bttBtnsendnotification_Internalname = sPrefix+"BTNSENDNOTIFICATION";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         chkavIstoallusers_Internalname = sPrefix+"vISTOALLUSERS";
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
         chkavIstoallusers.Caption = "";
         chkavIstoallusers.Visible = 1;
         Combo_recipientlist_Caption = "";
         Combo_grouplist_Caption = "";
         edtavMessage_Enabled = 1;
         edtavTitle_Jsonclick = "";
         edtavTitle_Enabled = 1;
         divLayoutmaintable_Class = "Table TableTransactionTemplate";
         Combo_recipientlist_Emptyitemtext = "All Location Residents";
         Combo_recipientlist_Multiplevaluestype = "Tags";
         Combo_recipientlist_Htmltemplate = "";
         Combo_recipientlist_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_recipientlist_Datalistprocparametersprefix = " \"ComboName\": \"RecipientList\"";
         Combo_recipientlist_Datalistproc = "WC_NotificationPanelLoadDVCombo";
         Combo_recipientlist_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_recipientlist_Cls = "ExtendedCombo Attribute ExtendedComboWithImage";
         Combo_grouplist_Emptyitemtext = "All Location Residents";
         Combo_grouplist_Multiplevaluestype = "Tags";
         Combo_grouplist_Htmltemplate = "";
         Combo_grouplist_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_grouplist_Datalistprocparametersprefix = " \"ComboName\": \"GroupList\"";
         Combo_grouplist_Datalistproc = "WC_NotificationPanelLoadDVCombo";
         Combo_grouplist_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_grouplist_Cls = "ExtendedCombo Attribute ExtendedComboWithImage";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV9isToAllUsers","fld":"vISTOALLUSERS"}]}""");
         setEventMetadata("'DOSENDNOTIFICATION'","""{"handler":"E127P2","iparms":[{"av":"AV10CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV7Title","fld":"vTITLE"},{"av":"AV8Message","fld":"vMESSAGE"},{"av":"AV30UpdatedRecipientList","fld":"vUPDATEDRECIPIENTLIST"},{"av":"AV14RecipientList","fld":"vRECIPIENTLIST"},{"av":"AV23GroupList","fld":"vGROUPLIST"},{"av":"A527ResidentPackageId","fld":"RESIDENTPACKAGEID"},{"av":"A62ResidentId","fld":"RESIDENTID"}]""");
         setEventMetadata("'DOSENDNOTIFICATION'",""","oparms":[{"av":"AV7Title","fld":"vTITLE"},{"av":"AV8Message","fld":"vMESSAGE"},{"av":"AV10CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV28GroupListItem","fld":"vGROUPLISTITEM"},{"av":"AV30UpdatedRecipientList","fld":"vUPDATEDRECIPIENTLIST"}]}""");
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
         Combo_recipientlist_Selectedvalue_get = "";
         Combo_grouplist_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV17DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV24GroupList_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV16RecipientList_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV30UpdatedRecipientList = new GxSimpleCollection<Guid>();
         AV14RecipientList = new GxSimpleCollection<Guid>();
         AV23GroupList = new GxSimpleCollection<Guid>();
         A527ResidentPackageId = Guid.Empty;
         A62ResidentId = Guid.Empty;
         Combo_grouplist_Selectedvalue_set = "";
         Combo_grouplist_Selectedtext_set = "";
         Combo_grouplist_Gamoauthtoken = "";
         Combo_grouplist_Ddointernalname = "";
         Combo_recipientlist_Selectedvalue_set = "";
         Combo_recipientlist_Selectedtext_set = "";
         Combo_recipientlist_Gamoauthtoken = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV7Title = "";
         AV8Message = "";
         lblTextblockcombo_grouplist_Jsonclick = "";
         ucCombo_grouplist = new GXUserControl();
         lblTextblockcombo_recipientlist_Jsonclick = "";
         ucCombo_recipientlist = new GXUserControl();
         bttBtnsendnotification_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV20GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV21GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV22ResidentsTitle = "";
         GXt_char2 = "";
         AV13Metadata = new SdtSDT_OneSignalCustomData(context);
         AV19RecipientListDescriptionCol = new GxSimpleCollection<string>();
         AV25GroupListDescriptionCol = new GxSimpleCollection<string>();
         AV29PackageGroupResidentIdCollection = new GxSimpleCollection<Guid>();
         AV28GroupListItem = Guid.Empty;
         H007P2_A29LocationId = new Guid[] {Guid.Empty} ;
         H007P2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H007P2_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         H007P2_n527ResidentPackageId = new bool[] {false} ;
         H007P2_A62ResidentId = new Guid[] {Guid.Empty} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wc_notificationpanel__default(),
            new Object[][] {
                new Object[] {
               H007P2_A29LocationId, H007P2_A11OrganisationId, H007P2_A527ResidentPackageId, H007P2_n527ResidentPackageId, H007P2_A62ResidentId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int edtavTitle_Enabled ;
      private int edtavMessage_Enabled ;
      private int AV31GXV1 ;
      private int idxLst ;
      private string Combo_recipientlist_Selectedvalue_get ;
      private string Combo_grouplist_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Combo_grouplist_Cls ;
      private string Combo_grouplist_Selectedvalue_set ;
      private string Combo_grouplist_Selectedtext_set ;
      private string Combo_grouplist_Gamoauthtoken ;
      private string Combo_grouplist_Ddointernalname ;
      private string Combo_grouplist_Datalistproc ;
      private string Combo_grouplist_Datalistprocparametersprefix ;
      private string Combo_grouplist_Htmltemplate ;
      private string Combo_grouplist_Multiplevaluestype ;
      private string Combo_grouplist_Emptyitemtext ;
      private string Combo_recipientlist_Cls ;
      private string Combo_recipientlist_Selectedvalue_set ;
      private string Combo_recipientlist_Selectedtext_set ;
      private string Combo_recipientlist_Gamoauthtoken ;
      private string Combo_recipientlist_Datalistproc ;
      private string Combo_recipientlist_Datalistprocparametersprefix ;
      private string Combo_recipientlist_Htmltemplate ;
      private string Combo_recipientlist_Multiplevaluestype ;
      private string Combo_recipientlist_Emptyitemtext ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtavTitle_Internalname ;
      private string TempTags ;
      private string edtavTitle_Jsonclick ;
      private string edtavMessage_Internalname ;
      private string divTablesplittedgrouplist_Internalname ;
      private string lblTextblockcombo_grouplist_Internalname ;
      private string lblTextblockcombo_grouplist_Jsonclick ;
      private string Combo_grouplist_Caption ;
      private string Combo_grouplist_Internalname ;
      private string divTablesplittedrecipientlist_Internalname ;
      private string lblTextblockcombo_recipientlist_Internalname ;
      private string lblTextblockcombo_recipientlist_Jsonclick ;
      private string Combo_recipientlist_Caption ;
      private string Combo_recipientlist_Internalname ;
      private string bttBtnsendnotification_Internalname ;
      private string bttBtnsendnotification_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string chkavIstoallusers_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXt_char2 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10CheckRequiredFieldsResult ;
      private bool Combo_grouplist_Allowmultipleselection ;
      private bool Combo_grouplist_Includeonlyselectedoption ;
      private bool Combo_recipientlist_Allowmultipleselection ;
      private bool Combo_recipientlist_Includeonlyselectedoption ;
      private bool wbLoad ;
      private bool AV9isToAllUsers ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n527ResidentPackageId ;
      private string AV7Title ;
      private string AV8Message ;
      private string AV22ResidentsTitle ;
      private Guid A527ResidentPackageId ;
      private Guid A62ResidentId ;
      private Guid AV28GroupListItem ;
      private GXUserControl ucCombo_grouplist ;
      private GXUserControl ucCombo_recipientlist ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavIstoallusers ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV17DDO_TitleSettingsIcons ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV24GroupList_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV16RecipientList_Data ;
      private GxSimpleCollection<Guid> AV30UpdatedRecipientList ;
      private GxSimpleCollection<Guid> AV14RecipientList ;
      private GxSimpleCollection<Guid> AV23GroupList ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV20GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV21GAMErrors ;
      private SdtSDT_OneSignalCustomData AV13Metadata ;
      private GxSimpleCollection<string> AV19RecipientListDescriptionCol ;
      private GxSimpleCollection<string> AV25GroupListDescriptionCol ;
      private GxSimpleCollection<Guid> AV29PackageGroupResidentIdCollection ;
      private IDataStoreProvider pr_default ;
      private Guid[] H007P2_A29LocationId ;
      private Guid[] H007P2_A11OrganisationId ;
      private Guid[] H007P2_A527ResidentPackageId ;
      private bool[] H007P2_n527ResidentPackageId ;
      private Guid[] H007P2_A62ResidentId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wc_notificationpanel__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH007P2;
          prmH007P2 = new Object[] {
          new ParDef("AV28GroupListItem",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("H007P2", "SELECT LocationId, OrganisationId, ResidentPackageId, ResidentId FROM Trn_Resident WHERE ResidentPackageId = :AV28GroupListItem ORDER BY ResidentPackageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007P2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((Guid[]) buf[4])[0] = rslt.getGuid(4);
                return;
       }
    }

 }

}
