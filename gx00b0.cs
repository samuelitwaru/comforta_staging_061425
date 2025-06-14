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
   public class gx00b0 : GXDataArea
   {
      public gx00b0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx00b0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out Guid aP0_pSupplierAgbId )
      {
         this.AV12pSupplierAgbId = Guid.Empty ;
         ExecuteImpl();
         aP0_pSupplierAgbId=this.AV12pSupplierAgbId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pSupplierAgbId");
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
               gxfirstwebparm = GetFirstPar( "pSupplierAgbId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pSupplierAgbId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               gxnrGrid1_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               gxgrGrid1_refresh_invoke( ) ;
               return  ;
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV12pSupplierAgbId = StringUtil.StrToGuid( gxfirstwebparm);
               AssignAttri("", false, "AV12pSupplierAgbId", AV12pSupplierAgbId.ToString());
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

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_74 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_74"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_74_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_74_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_74_idx = GetPar( "sGXsfl_74_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid1_newrow( ) ;
         /* End function gxnrGrid1_newrow_invoke */
      }

      protected void gxgrGrid1_refresh_invoke( )
      {
         subGrid1_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."), 18, MidpointRounding.ToEven));
         AV6cSupplierAgbId = StringUtil.StrToGuid( GetPar( "cSupplierAgbId"));
         AV7cSupplierAgbNumber = GetPar( "cSupplierAgbNumber");
         AV8cSupplierAgbName = GetPar( "cSupplierAgbName");
         AV9cSupplierAgbKvkNumber = GetPar( "cSupplierAgbKvkNumber");
         AV10cSupplierAgbPhone = GetPar( "cSupplierAgbPhone");
         AV11cSupplierAgbEmail = GetPar( "cSupplierAgbEmail");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cSupplierAgbId, AV7cSupplierAgbNumber, AV8cSupplierAgbName, AV9cSupplierAgbKvkNumber, AV10cSupplierAgbPhone, AV11cSupplierAgbEmail) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "gx00b0_Execute" ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterprompt", "GeneXus.Programs.general.ui.masterprompt", new Object[] {context});
            MasterPageObj.setDataArea(this,true);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
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

      public override short ExecuteStartEvent( )
      {
         PA0B2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0B2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
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
         context.WriteHtmlText( Form.Headerrawhtml) ;
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
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00b0.aspx", new object[] {UrlEncode(AV12pSupplierAgbId.ToString())}, new string[] {"pSupplierAgbId"}) +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vCSUPPLIERAGBID", AV6cSupplierAgbId.ToString());
         GxWebStd.gx_hidden_field( context, "GXH_vCSUPPLIERAGBNUMBER", AV7cSupplierAgbNumber);
         GxWebStd.gx_hidden_field( context, "GXH_vCSUPPLIERAGBNAME", AV8cSupplierAgbName);
         GxWebStd.gx_hidden_field( context, "GXH_vCSUPPLIERAGBKVKNUMBER", AV9cSupplierAgbKvkNumber);
         GxWebStd.gx_hidden_field( context, "GXH_vCSUPPLIERAGBPHONE", StringUtil.RTrim( AV10cSupplierAgbPhone));
         GxWebStd.gx_hidden_field( context, "GXH_vCSUPPLIERAGBEMAIL", AV11cSupplierAgbEmail);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_74", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_74), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPSUPPLIERAGBID", AV12pSupplierAgbId.ToString());
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "SUPPLIERAGBIDFILTERCONTAINER_Class", StringUtil.RTrim( divSupplieragbidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SUPPLIERAGBNUMBERFILTERCONTAINER_Class", StringUtil.RTrim( divSupplieragbnumberfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SUPPLIERAGBNAMEFILTERCONTAINER_Class", StringUtil.RTrim( divSupplieragbnamefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SUPPLIERAGBKVKNUMBERFILTERCONTAINER_Class", StringUtil.RTrim( divSupplieragbkvknumberfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SUPPLIERAGBPHONEFILTERCONTAINER_Class", StringUtil.RTrim( divSupplieragbphonefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SUPPLIERAGBEMAILFILTERCONTAINER_Class", StringUtil.RTrim( divSupplieragbemailfiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0B2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0B2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("gx00b0.aspx", new object[] {UrlEncode(AV12pSupplierAgbId.ToString())}, new string[] {"pSupplierAgbId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00B0" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Trn_Supplier AGB", "") ;
      }

      protected void WB0B0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMain_Internalname, 1, 0, "px", 0, "px", "ContainerFluid PromptContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 PromptAdvancedBarCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedcontainer_Internalname, 1, 0, "px", 0, "px", divAdvancedcontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSupplieragbidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSupplieragbidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsupplieragbidfilter_Internalname, context.GetMessage( "Supplier Agb Id", ""), "", "", lblLblsupplieragbidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e110b1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00B0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsupplieragbid_Internalname, context.GetMessage( "Supplier Agb Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsupplieragbid_Internalname, AV6cSupplierAgbId.ToString(), AV6cSupplierAgbId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsupplieragbid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsupplieragbid_Visible, edtavCsupplieragbid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Gx00B0.htm");
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
            GxWebStd.gx_div_start( context, divSupplieragbnumberfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSupplieragbnumberfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsupplieragbnumberfilter_Internalname, context.GetMessage( "Supplier Agb Number", ""), "", "", lblLblsupplieragbnumberfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120b1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00B0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsupplieragbnumber_Internalname, context.GetMessage( "Supplier Agb Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsupplieragbnumber_Internalname, AV7cSupplierAgbNumber, StringUtil.RTrim( context.localUtil.Format( AV7cSupplierAgbNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsupplieragbnumber_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsupplieragbnumber_Visible, edtavCsupplieragbnumber_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx00B0.htm");
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
            GxWebStd.gx_div_start( context, divSupplieragbnamefiltercontainer_Internalname, 1, 0, "px", 0, "px", divSupplieragbnamefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsupplieragbnamefilter_Internalname, context.GetMessage( "Supplier Agb Name", ""), "", "", lblLblsupplieragbnamefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e130b1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00B0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsupplieragbname_Internalname, context.GetMessage( "Supplier Agb Name", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsupplieragbname_Internalname, AV8cSupplierAgbName, StringUtil.RTrim( context.localUtil.Format( AV8cSupplierAgbName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsupplieragbname_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsupplieragbname_Visible, edtavCsupplieragbname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx00B0.htm");
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
            GxWebStd.gx_div_start( context, divSupplieragbkvknumberfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSupplieragbkvknumberfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsupplieragbkvknumberfilter_Internalname, context.GetMessage( "Supplier Agb Kvk Number", ""), "", "", lblLblsupplieragbkvknumberfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e140b1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00B0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsupplieragbkvknumber_Internalname, context.GetMessage( "Supplier Agb Kvk Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsupplieragbkvknumber_Internalname, AV9cSupplierAgbKvkNumber, StringUtil.RTrim( context.localUtil.Format( AV9cSupplierAgbKvkNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsupplieragbkvknumber_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsupplieragbkvknumber_Visible, edtavCsupplieragbkvknumber_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx00B0.htm");
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
            GxWebStd.gx_div_start( context, divSupplieragbphonefiltercontainer_Internalname, 1, 0, "px", 0, "px", divSupplieragbphonefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsupplieragbphonefilter_Internalname, context.GetMessage( "Supplier Agb Phone", ""), "", "", lblLblsupplieragbphonefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e150b1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00B0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsupplieragbphone_Internalname, context.GetMessage( "Supplier Agb Phone", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsupplieragbphone_Internalname, StringUtil.RTrim( AV10cSupplierAgbPhone), StringUtil.RTrim( context.localUtil.Format( AV10cSupplierAgbPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsupplieragbphone_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsupplieragbphone_Visible, edtavCsupplieragbphone_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_Gx00B0.htm");
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
            GxWebStd.gx_div_start( context, divSupplieragbemailfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSupplieragbemailfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsupplieragbemailfilter_Internalname, context.GetMessage( "Supplier Agb Email", ""), "", "", lblLblsupplieragbemailfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e160b1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00B0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsupplieragbemail_Internalname, context.GetMessage( "Supplier Agb Email", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsupplieragbemail_Internalname, AV11cSupplierAgbEmail, StringUtil.RTrim( context.localUtil.Format( AV11cSupplierAgbEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsupplieragbemail_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsupplieragbemail_Visible, edtavCsupplieragbemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_Gx00B0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 WWGridCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm hidden-md hidden-lg ToggleCell", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e170b1_client"+"'", TempTags, "", 2, "HLP_Gx00B0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl74( ) ;
         }
         if ( wbEnd == 74 )
         {
            wbEnd = 0;
            nRC_GXsfl_74 = (int)(nGXsfl_74_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00B0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 74 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0B2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Trn_Supplier AGB", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0B0( ) ;
      }

      protected void WS0B2( )
      {
         START0B2( ) ;
         EVT0B2( ) ;
      }

      protected void EVT0B2( )
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
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
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
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_74_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
                              SubsflControlProps_742( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV14Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_74_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A49SupplierAgbId = StringUtil.StrToGuid( cgiGet( edtSupplierAgbId_Internalname));
                              A50SupplierAgbNumber = cgiGet( edtSupplierAgbNumber_Internalname);
                              A52SupplierAgbKvkNumber = cgiGet( edtSupplierAgbKvkNumber_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E180B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E190B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Csupplieragbid Changed */
                                       if ( StringUtil.StrToGuid( cgiGet( "GXH_vCSUPPLIERAGBID")) != AV6cSupplierAgbId )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csupplieragbnumber Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCSUPPLIERAGBNUMBER"), AV7cSupplierAgbNumber) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csupplieragbname Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCSUPPLIERAGBNAME"), AV8cSupplierAgbName) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csupplieragbkvknumber Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCSUPPLIERAGBKVKNUMBER"), AV9cSupplierAgbKvkNumber) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csupplieragbphone Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCSUPPLIERAGBPHONE"), AV10cSupplierAgbPhone) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csupplieragbemail Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCSUPPLIERAGBEMAIL"), AV11cSupplierAgbEmail) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E200B2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0B2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA0B2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_742( ) ;
         while ( nGXsfl_74_idx <= nRC_GXsfl_74 )
         {
            sendrow_742( ) ;
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        Guid AV6cSupplierAgbId ,
                                        string AV7cSupplierAgbNumber ,
                                        string AV8cSupplierAgbName ,
                                        string AV9cSupplierAgbKvkNumber ,
                                        string AV10cSupplierAgbPhone ,
                                        string AV11cSupplierAgbEmail )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0B2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SUPPLIERAGBID", GetSecureSignedToken( "", A49SupplierAgbId, context));
         GxWebStd.gx_hidden_field( context, "SUPPLIERAGBID", A49SupplierAgbId.ToString());
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
         RF0B2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF0B2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 74;
         nGXsfl_74_idx = 1;
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         bGXsfl_74_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "PromptGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_742( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cSupplierAgbNumber ,
                                                 AV8cSupplierAgbName ,
                                                 AV9cSupplierAgbKvkNumber ,
                                                 AV10cSupplierAgbPhone ,
                                                 AV11cSupplierAgbEmail ,
                                                 A50SupplierAgbNumber ,
                                                 A51SupplierAgbName ,
                                                 A52SupplierAgbKvkNumber ,
                                                 A56SupplierAgbPhone ,
                                                 A57SupplierAgbEmail ,
                                                 AV6cSupplierAgbId } ,
                                                 new int[]{
                                                 }
            });
            lV7cSupplierAgbNumber = StringUtil.Concat( StringUtil.RTrim( AV7cSupplierAgbNumber), "%", "");
            lV8cSupplierAgbName = StringUtil.Concat( StringUtil.RTrim( AV8cSupplierAgbName), "%", "");
            lV9cSupplierAgbKvkNumber = StringUtil.Concat( StringUtil.RTrim( AV9cSupplierAgbKvkNumber), "%", "");
            lV10cSupplierAgbPhone = StringUtil.PadR( StringUtil.RTrim( AV10cSupplierAgbPhone), 20, "%");
            lV11cSupplierAgbEmail = StringUtil.Concat( StringUtil.RTrim( AV11cSupplierAgbEmail), "%", "");
            /* Using cursor H000B2 */
            pr_default.execute(0, new Object[] {AV6cSupplierAgbId, lV7cSupplierAgbNumber, lV8cSupplierAgbName, lV9cSupplierAgbKvkNumber, lV10cSupplierAgbPhone, lV11cSupplierAgbEmail, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_74_idx = 1;
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A57SupplierAgbEmail = H000B2_A57SupplierAgbEmail[0];
               A56SupplierAgbPhone = H000B2_A56SupplierAgbPhone[0];
               A51SupplierAgbName = H000B2_A51SupplierAgbName[0];
               A52SupplierAgbKvkNumber = H000B2_A52SupplierAgbKvkNumber[0];
               A50SupplierAgbNumber = H000B2_A50SupplierAgbNumber[0];
               A49SupplierAgbId = H000B2_A49SupplierAgbId[0];
               /* Execute user event: Load */
               E190B2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 74;
            WB0B0( ) ;
         }
         bGXsfl_74_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0B2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SUPPLIERAGBID"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, A49SupplierAgbId, context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV7cSupplierAgbNumber ,
                                              AV8cSupplierAgbName ,
                                              AV9cSupplierAgbKvkNumber ,
                                              AV10cSupplierAgbPhone ,
                                              AV11cSupplierAgbEmail ,
                                              A50SupplierAgbNumber ,
                                              A51SupplierAgbName ,
                                              A52SupplierAgbKvkNumber ,
                                              A56SupplierAgbPhone ,
                                              A57SupplierAgbEmail ,
                                              AV6cSupplierAgbId } ,
                                              new int[]{
                                              }
         });
         lV7cSupplierAgbNumber = StringUtil.Concat( StringUtil.RTrim( AV7cSupplierAgbNumber), "%", "");
         lV8cSupplierAgbName = StringUtil.Concat( StringUtil.RTrim( AV8cSupplierAgbName), "%", "");
         lV9cSupplierAgbKvkNumber = StringUtil.Concat( StringUtil.RTrim( AV9cSupplierAgbKvkNumber), "%", "");
         lV10cSupplierAgbPhone = StringUtil.PadR( StringUtil.RTrim( AV10cSupplierAgbPhone), 20, "%");
         lV11cSupplierAgbEmail = StringUtil.Concat( StringUtil.RTrim( AV11cSupplierAgbEmail), "%", "");
         /* Using cursor H000B3 */
         pr_default.execute(1, new Object[] {AV6cSupplierAgbId, lV7cSupplierAgbNumber, lV8cSupplierAgbName, lV9cSupplierAgbKvkNumber, lV10cSupplierAgbPhone, lV11cSupplierAgbEmail});
         GRID1_nRecordCount = H000B3_AGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(10*1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSupplierAgbId, AV7cSupplierAgbNumber, AV8cSupplierAgbName, AV9cSupplierAgbKvkNumber, AV10cSupplierAgbPhone, AV11cSupplierAgbEmail) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSupplierAgbId, AV7cSupplierAgbNumber, AV8cSupplierAgbName, AV9cSupplierAgbKvkNumber, AV10cSupplierAgbPhone, AV11cSupplierAgbEmail) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSupplierAgbId, AV7cSupplierAgbNumber, AV8cSupplierAgbName, AV9cSupplierAgbKvkNumber, AV10cSupplierAgbPhone, AV11cSupplierAgbEmail) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSupplierAgbId, AV7cSupplierAgbNumber, AV8cSupplierAgbName, AV9cSupplierAgbKvkNumber, AV10cSupplierAgbPhone, AV11cSupplierAgbEmail) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSupplierAgbId, AV7cSupplierAgbNumber, AV8cSupplierAgbName, AV9cSupplierAgbKvkNumber, AV10cSupplierAgbPhone, AV11cSupplierAgbEmail) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtSupplierAgbId_Enabled = 0;
         edtSupplierAgbNumber_Enabled = 0;
         edtSupplierAgbKvkNumber_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0B0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E180B2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_74 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_74"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( StringUtil.StrCmp(cgiGet( edtavCsupplieragbid_Internalname), "") == 0 )
            {
               AV6cSupplierAgbId = Guid.Empty;
               AssignAttri("", false, "AV6cSupplierAgbId", AV6cSupplierAgbId.ToString());
            }
            else
            {
               try
               {
                  AV6cSupplierAgbId = StringUtil.StrToGuid( cgiGet( edtavCsupplieragbid_Internalname));
                  AssignAttri("", false, "AV6cSupplierAgbId", AV6cSupplierAgbId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vCSUPPLIERAGBID");
                  GX_FocusControl = edtavCsupplieragbid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            AV7cSupplierAgbNumber = cgiGet( edtavCsupplieragbnumber_Internalname);
            AssignAttri("", false, "AV7cSupplierAgbNumber", AV7cSupplierAgbNumber);
            AV8cSupplierAgbName = cgiGet( edtavCsupplieragbname_Internalname);
            AssignAttri("", false, "AV8cSupplierAgbName", AV8cSupplierAgbName);
            AV9cSupplierAgbKvkNumber = cgiGet( edtavCsupplieragbkvknumber_Internalname);
            AssignAttri("", false, "AV9cSupplierAgbKvkNumber", AV9cSupplierAgbKvkNumber);
            AV10cSupplierAgbPhone = cgiGet( edtavCsupplieragbphone_Internalname);
            AssignAttri("", false, "AV10cSupplierAgbPhone", AV10cSupplierAgbPhone);
            AV11cSupplierAgbEmail = cgiGet( edtavCsupplieragbemail_Internalname);
            AssignAttri("", false, "AV11cSupplierAgbEmail", AV11cSupplierAgbEmail);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrToGuid( cgiGet( "GXH_vCSUPPLIERAGBID")) != AV6cSupplierAgbId )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCSUPPLIERAGBNUMBER"), AV7cSupplierAgbNumber) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCSUPPLIERAGBNAME"), AV8cSupplierAgbName) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCSUPPLIERAGBKVKNUMBER"), AV9cSupplierAgbKvkNumber) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCSUPPLIERAGBPHONE"), AV10cSupplierAgbPhone) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCSUPPLIERAGBEMAIL"), AV11cSupplierAgbEmail) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E180B2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E180B2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Trn_Supplier AGB", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV13ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E190B2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "SelectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV14Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
         sendrow_742( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_74_Refreshing )
         {
            DoAjaxLoad(74, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E200B2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E200B2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV12pSupplierAgbId = A49SupplierAgbId;
         AssignAttri("", false, "AV12pSupplierAgbId", AV12pSupplierAgbId.ToString());
         context.setWebReturnParms(new Object[] {(Guid)AV12pSupplierAgbId});
         context.setWebReturnParmsMetadata(new Object[] {"AV12pSupplierAgbId"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV12pSupplierAgbId = (Guid)getParm(obj,0);
         AssignAttri("", false, "AV12pSupplierAgbId", AV12pSupplierAgbId.ToString());
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
         PA0B2( ) ;
         WS0B2( ) ;
         WE0B2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256146452932", true, true);
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
         context.AddJavascriptSource("gx00b0.js", "?20256146452933", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_idx;
         edtSupplierAgbId_Internalname = "SUPPLIERAGBID_"+sGXsfl_74_idx;
         edtSupplierAgbNumber_Internalname = "SUPPLIERAGBNUMBER_"+sGXsfl_74_idx;
         edtSupplierAgbKvkNumber_Internalname = "SUPPLIERAGBKVKNUMBER_"+sGXsfl_74_idx;
      }

      protected void SubsflControlProps_fel_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_fel_idx;
         edtSupplierAgbId_Internalname = "SUPPLIERAGBID_"+sGXsfl_74_fel_idx;
         edtSupplierAgbNumber_Internalname = "SUPPLIERAGBNUMBER_"+sGXsfl_74_fel_idx;
         edtSupplierAgbKvkNumber_Internalname = "SUPPLIERAGBKVKNUMBER_"+sGXsfl_74_fel_idx;
      }

      protected void sendrow_742( )
      {
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         WB0B0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_74_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container);
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0;
               subGrid1_Backcolor = subGrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform";
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_74_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_74_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( A49SupplierAgbId.ToString())+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_74_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV14Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV14Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbId_Internalname,A49SupplierAgbId.ToString(),A49SupplierAgbId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierAgbId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)74,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtSupplierAgbNumber_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( A49SupplierAgbId.ToString())+"'"+"]);";
            AssignProp("", false, edtSupplierAgbNumber_Internalname, "Link", edtSupplierAgbNumber_Link, !bGXsfl_74_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbNumber_Internalname,(string)A50SupplierAgbNumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtSupplierAgbNumber_Link,(string)"",(string)"",(string)"",(string)edtSupplierAgbNumber_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"AgbNumber",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbKvkNumber_Internalname,(string)A52SupplierAgbKvkNumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierAgbKvkNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"KvkNumber",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes0B2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         /* End function sendrow_742 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl74( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"74\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid1_Backcolorstyle == 0 )
            {
               subGrid1_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid1_Class) > 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Title";
               }
            }
            else
            {
               subGrid1_Titlebackstyle = 1;
               if ( subGrid1_Backcolorstyle == 1 )
               {
                  subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"SelectionAttribute"+" "+((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Agb Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Agb Number", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Kvk Number", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               Grid1Container = new GXWebGrid( context);
            }
            else
            {
               Grid1Container.Clear();
            }
            Grid1Container.SetWrapped(nGXWrapped);
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", "PromptGrid");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( AV5LinkSelection));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtavLinkselection_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A49SupplierAgbId.ToString()));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A50SupplierAgbNumber));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtSupplierAgbNumber_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A52SupplierAgbKvkNumber));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblLblsupplieragbidfilter_Internalname = "LBLSUPPLIERAGBIDFILTER";
         edtavCsupplieragbid_Internalname = "vCSUPPLIERAGBID";
         divSupplieragbidfiltercontainer_Internalname = "SUPPLIERAGBIDFILTERCONTAINER";
         lblLblsupplieragbnumberfilter_Internalname = "LBLSUPPLIERAGBNUMBERFILTER";
         edtavCsupplieragbnumber_Internalname = "vCSUPPLIERAGBNUMBER";
         divSupplieragbnumberfiltercontainer_Internalname = "SUPPLIERAGBNUMBERFILTERCONTAINER";
         lblLblsupplieragbnamefilter_Internalname = "LBLSUPPLIERAGBNAMEFILTER";
         edtavCsupplieragbname_Internalname = "vCSUPPLIERAGBNAME";
         divSupplieragbnamefiltercontainer_Internalname = "SUPPLIERAGBNAMEFILTERCONTAINER";
         lblLblsupplieragbkvknumberfilter_Internalname = "LBLSUPPLIERAGBKVKNUMBERFILTER";
         edtavCsupplieragbkvknumber_Internalname = "vCSUPPLIERAGBKVKNUMBER";
         divSupplieragbkvknumberfiltercontainer_Internalname = "SUPPLIERAGBKVKNUMBERFILTERCONTAINER";
         lblLblsupplieragbphonefilter_Internalname = "LBLSUPPLIERAGBPHONEFILTER";
         edtavCsupplieragbphone_Internalname = "vCSUPPLIERAGBPHONE";
         divSupplieragbphonefiltercontainer_Internalname = "SUPPLIERAGBPHONEFILTERCONTAINER";
         lblLblsupplieragbemailfilter_Internalname = "LBLSUPPLIERAGBEMAILFILTER";
         edtavCsupplieragbemail_Internalname = "vCSUPPLIERAGBEMAIL";
         divSupplieragbemailfiltercontainer_Internalname = "SUPPLIERAGBEMAILFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtSupplierAgbId_Internalname = "SUPPLIERAGBID";
         edtSupplierAgbNumber_Internalname = "SUPPLIERAGBNUMBER";
         edtSupplierAgbKvkNumber_Internalname = "SUPPLIERAGBKVKNUMBER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         divGridtable_Internalname = "GRIDTABLE";
         divMain_Internalname = "MAIN";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         edtSupplierAgbKvkNumber_Jsonclick = "";
         edtSupplierAgbNumber_Jsonclick = "";
         edtSupplierAgbNumber_Link = "";
         edtSupplierAgbId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtSupplierAgbKvkNumber_Enabled = 0;
         edtSupplierAgbNumber_Enabled = 0;
         edtSupplierAgbId_Enabled = 0;
         edtavCsupplieragbemail_Jsonclick = "";
         edtavCsupplieragbemail_Enabled = 1;
         edtavCsupplieragbemail_Visible = 1;
         edtavCsupplieragbphone_Jsonclick = "";
         edtavCsupplieragbphone_Enabled = 1;
         edtavCsupplieragbphone_Visible = 1;
         edtavCsupplieragbkvknumber_Jsonclick = "";
         edtavCsupplieragbkvknumber_Enabled = 1;
         edtavCsupplieragbkvknumber_Visible = 1;
         edtavCsupplieragbname_Jsonclick = "";
         edtavCsupplieragbname_Enabled = 1;
         edtavCsupplieragbname_Visible = 1;
         edtavCsupplieragbnumber_Jsonclick = "";
         edtavCsupplieragbnumber_Enabled = 1;
         edtavCsupplieragbnumber_Visible = 1;
         edtavCsupplieragbid_Jsonclick = "";
         edtavCsupplieragbid_Enabled = 1;
         edtavCsupplieragbid_Visible = 1;
         divSupplieragbemailfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divSupplieragbphonefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divSupplieragbkvknumberfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divSupplieragbnamefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divSupplieragbnumberfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divSupplieragbidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Trn_Supplier AGB", "");
         subGrid1_Rows = 10;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cSupplierAgbId","fld":"vCSUPPLIERAGBID"},{"av":"AV7cSupplierAgbNumber","fld":"vCSUPPLIERAGBNUMBER"},{"av":"AV8cSupplierAgbName","fld":"vCSUPPLIERAGBNAME"},{"av":"AV9cSupplierAgbKvkNumber","fld":"vCSUPPLIERAGBKVKNUMBER"},{"av":"AV10cSupplierAgbPhone","fld":"vCSUPPLIERAGBPHONE"},{"av":"AV11cSupplierAgbEmail","fld":"vCSUPPLIERAGBEMAIL"}]}""");
         setEventMetadata("'TOGGLE'","""{"handler":"E170B1","iparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]""");
         setEventMetadata("'TOGGLE'",""","oparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]}""");
         setEventMetadata("LBLSUPPLIERAGBIDFILTER.CLICK","""{"handler":"E110B1","iparms":[{"av":"divSupplieragbidfiltercontainer_Class","ctrl":"SUPPLIERAGBIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLSUPPLIERAGBIDFILTER.CLICK",""","oparms":[{"av":"divSupplieragbidfiltercontainer_Class","ctrl":"SUPPLIERAGBIDFILTERCONTAINER","prop":"Class"},{"av":"edtavCsupplieragbid_Visible","ctrl":"vCSUPPLIERAGBID","prop":"Visible"}]}""");
         setEventMetadata("LBLSUPPLIERAGBNUMBERFILTER.CLICK","""{"handler":"E120B1","iparms":[{"av":"divSupplieragbnumberfiltercontainer_Class","ctrl":"SUPPLIERAGBNUMBERFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLSUPPLIERAGBNUMBERFILTER.CLICK",""","oparms":[{"av":"divSupplieragbnumberfiltercontainer_Class","ctrl":"SUPPLIERAGBNUMBERFILTERCONTAINER","prop":"Class"},{"av":"edtavCsupplieragbnumber_Visible","ctrl":"vCSUPPLIERAGBNUMBER","prop":"Visible"}]}""");
         setEventMetadata("LBLSUPPLIERAGBNAMEFILTER.CLICK","""{"handler":"E130B1","iparms":[{"av":"divSupplieragbnamefiltercontainer_Class","ctrl":"SUPPLIERAGBNAMEFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLSUPPLIERAGBNAMEFILTER.CLICK",""","oparms":[{"av":"divSupplieragbnamefiltercontainer_Class","ctrl":"SUPPLIERAGBNAMEFILTERCONTAINER","prop":"Class"},{"av":"edtavCsupplieragbname_Visible","ctrl":"vCSUPPLIERAGBNAME","prop":"Visible"}]}""");
         setEventMetadata("LBLSUPPLIERAGBKVKNUMBERFILTER.CLICK","""{"handler":"E140B1","iparms":[{"av":"divSupplieragbkvknumberfiltercontainer_Class","ctrl":"SUPPLIERAGBKVKNUMBERFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLSUPPLIERAGBKVKNUMBERFILTER.CLICK",""","oparms":[{"av":"divSupplieragbkvknumberfiltercontainer_Class","ctrl":"SUPPLIERAGBKVKNUMBERFILTERCONTAINER","prop":"Class"},{"av":"edtavCsupplieragbkvknumber_Visible","ctrl":"vCSUPPLIERAGBKVKNUMBER","prop":"Visible"}]}""");
         setEventMetadata("LBLSUPPLIERAGBPHONEFILTER.CLICK","""{"handler":"E150B1","iparms":[{"av":"divSupplieragbphonefiltercontainer_Class","ctrl":"SUPPLIERAGBPHONEFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLSUPPLIERAGBPHONEFILTER.CLICK",""","oparms":[{"av":"divSupplieragbphonefiltercontainer_Class","ctrl":"SUPPLIERAGBPHONEFILTERCONTAINER","prop":"Class"},{"av":"edtavCsupplieragbphone_Visible","ctrl":"vCSUPPLIERAGBPHONE","prop":"Visible"}]}""");
         setEventMetadata("LBLSUPPLIERAGBEMAILFILTER.CLICK","""{"handler":"E160B1","iparms":[{"av":"divSupplieragbemailfiltercontainer_Class","ctrl":"SUPPLIERAGBEMAILFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLSUPPLIERAGBEMAILFILTER.CLICK",""","oparms":[{"av":"divSupplieragbemailfiltercontainer_Class","ctrl":"SUPPLIERAGBEMAILFILTERCONTAINER","prop":"Class"},{"av":"edtavCsupplieragbemail_Visible","ctrl":"vCSUPPLIERAGBEMAIL","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E200B2","iparms":[{"av":"A49SupplierAgbId","fld":"SUPPLIERAGBID","hsh":true}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV12pSupplierAgbId","fld":"vPSUPPLIERAGBID"}]}""");
         setEventMetadata("GRID1_FIRSTPAGE","""{"handler":"subgrid1_firstpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cSupplierAgbId","fld":"vCSUPPLIERAGBID"},{"av":"AV7cSupplierAgbNumber","fld":"vCSUPPLIERAGBNUMBER"},{"av":"AV8cSupplierAgbName","fld":"vCSUPPLIERAGBNAME"},{"av":"AV9cSupplierAgbKvkNumber","fld":"vCSUPPLIERAGBKVKNUMBER"},{"av":"AV10cSupplierAgbPhone","fld":"vCSUPPLIERAGBPHONE"},{"av":"AV11cSupplierAgbEmail","fld":"vCSUPPLIERAGBEMAIL"}]}""");
         setEventMetadata("GRID1_PREVPAGE","""{"handler":"subgrid1_previouspage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cSupplierAgbId","fld":"vCSUPPLIERAGBID"},{"av":"AV7cSupplierAgbNumber","fld":"vCSUPPLIERAGBNUMBER"},{"av":"AV8cSupplierAgbName","fld":"vCSUPPLIERAGBNAME"},{"av":"AV9cSupplierAgbKvkNumber","fld":"vCSUPPLIERAGBKVKNUMBER"},{"av":"AV10cSupplierAgbPhone","fld":"vCSUPPLIERAGBPHONE"},{"av":"AV11cSupplierAgbEmail","fld":"vCSUPPLIERAGBEMAIL"}]}""");
         setEventMetadata("GRID1_NEXTPAGE","""{"handler":"subgrid1_nextpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cSupplierAgbId","fld":"vCSUPPLIERAGBID"},{"av":"AV7cSupplierAgbNumber","fld":"vCSUPPLIERAGBNUMBER"},{"av":"AV8cSupplierAgbName","fld":"vCSUPPLIERAGBNAME"},{"av":"AV9cSupplierAgbKvkNumber","fld":"vCSUPPLIERAGBKVKNUMBER"},{"av":"AV10cSupplierAgbPhone","fld":"vCSUPPLIERAGBPHONE"},{"av":"AV11cSupplierAgbEmail","fld":"vCSUPPLIERAGBEMAIL"}]}""");
         setEventMetadata("GRID1_LASTPAGE","""{"handler":"subgrid1_lastpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cSupplierAgbId","fld":"vCSUPPLIERAGBID"},{"av":"AV7cSupplierAgbNumber","fld":"vCSUPPLIERAGBNUMBER"},{"av":"AV8cSupplierAgbName","fld":"vCSUPPLIERAGBNAME"},{"av":"AV9cSupplierAgbKvkNumber","fld":"vCSUPPLIERAGBKVKNUMBER"},{"av":"AV10cSupplierAgbPhone","fld":"vCSUPPLIERAGBPHONE"},{"av":"AV11cSupplierAgbEmail","fld":"vCSUPPLIERAGBEMAIL"}]}""");
         setEventMetadata("VALIDV_CSUPPLIERAGBID","""{"handler":"Validv_Csupplieragbid","iparms":[]}""");
         setEventMetadata("VALIDV_CSUPPLIERAGBKVKNUMBER","""{"handler":"Validv_Csupplieragbkvknumber","iparms":[]}""");
         setEventMetadata("VALIDV_CSUPPLIERAGBEMAIL","""{"handler":"Validv_Csupplieragbemail","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Supplieragbkvknumber","iparms":[]}""");
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
         AV12pSupplierAgbId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV6cSupplierAgbId = Guid.Empty;
         AV7cSupplierAgbNumber = "";
         AV8cSupplierAgbName = "";
         AV9cSupplierAgbKvkNumber = "";
         AV10cSupplierAgbPhone = "";
         AV11cSupplierAgbEmail = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblsupplieragbidfilter_Jsonclick = "";
         TempTags = "";
         lblLblsupplieragbnumberfilter_Jsonclick = "";
         lblLblsupplieragbnamefilter_Jsonclick = "";
         lblLblsupplieragbkvknumberfilter_Jsonclick = "";
         lblLblsupplieragbphonefilter_Jsonclick = "";
         lblLblsupplieragbemailfilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5LinkSelection = "";
         AV14Linkselection_GXI = "";
         A49SupplierAgbId = Guid.Empty;
         A50SupplierAgbNumber = "";
         A52SupplierAgbKvkNumber = "";
         lV7cSupplierAgbNumber = "";
         lV8cSupplierAgbName = "";
         lV9cSupplierAgbKvkNumber = "";
         lV10cSupplierAgbPhone = "";
         lV11cSupplierAgbEmail = "";
         A51SupplierAgbName = "";
         A56SupplierAgbPhone = "";
         A57SupplierAgbEmail = "";
         H000B2_A57SupplierAgbEmail = new string[] {""} ;
         H000B2_A56SupplierAgbPhone = new string[] {""} ;
         H000B2_A51SupplierAgbName = new string[] {""} ;
         H000B2_A52SupplierAgbKvkNumber = new string[] {""} ;
         H000B2_A50SupplierAgbNumber = new string[] {""} ;
         H000B2_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         H000B3_AGRID1_nRecordCount = new long[1] ;
         AV13ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00b0__default(),
            new Object[][] {
                new Object[] {
               H000B2_A57SupplierAgbEmail, H000B2_A56SupplierAgbPhone, H000B2_A51SupplierAgbName, H000B2_A52SupplierAgbKvkNumber, H000B2_A50SupplierAgbNumber, H000B2_A49SupplierAgbId
               }
               , new Object[] {
               H000B3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int nRC_GXsfl_74 ;
      private int subGrid1_Rows ;
      private int nGXsfl_74_idx=1 ;
      private int edtavCsupplieragbid_Visible ;
      private int edtavCsupplieragbid_Enabled ;
      private int edtavCsupplieragbnumber_Visible ;
      private int edtavCsupplieragbnumber_Enabled ;
      private int edtavCsupplieragbname_Visible ;
      private int edtavCsupplieragbname_Enabled ;
      private int edtavCsupplieragbkvknumber_Visible ;
      private int edtavCsupplieragbkvknumber_Enabled ;
      private int edtavCsupplieragbphone_Visible ;
      private int edtavCsupplieragbphone_Enabled ;
      private int edtavCsupplieragbemail_Visible ;
      private int edtavCsupplieragbemail_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtSupplierAgbId_Enabled ;
      private int edtSupplierAgbNumber_Enabled ;
      private int edtSupplierAgbKvkNumber_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divSupplieragbidfiltercontainer_Class ;
      private string divSupplieragbnumberfiltercontainer_Class ;
      private string divSupplieragbnamefiltercontainer_Class ;
      private string divSupplieragbkvknumberfiltercontainer_Class ;
      private string divSupplieragbphonefiltercontainer_Class ;
      private string divSupplieragbemailfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_74_idx="0001" ;
      private string AV10cSupplierAgbPhone ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divSupplieragbidfiltercontainer_Internalname ;
      private string lblLblsupplieragbidfilter_Internalname ;
      private string lblLblsupplieragbidfilter_Jsonclick ;
      private string edtavCsupplieragbid_Internalname ;
      private string TempTags ;
      private string edtavCsupplieragbid_Jsonclick ;
      private string divSupplieragbnumberfiltercontainer_Internalname ;
      private string lblLblsupplieragbnumberfilter_Internalname ;
      private string lblLblsupplieragbnumberfilter_Jsonclick ;
      private string edtavCsupplieragbnumber_Internalname ;
      private string edtavCsupplieragbnumber_Jsonclick ;
      private string divSupplieragbnamefiltercontainer_Internalname ;
      private string lblLblsupplieragbnamefilter_Internalname ;
      private string lblLblsupplieragbnamefilter_Jsonclick ;
      private string edtavCsupplieragbname_Internalname ;
      private string edtavCsupplieragbname_Jsonclick ;
      private string divSupplieragbkvknumberfiltercontainer_Internalname ;
      private string lblLblsupplieragbkvknumberfilter_Internalname ;
      private string lblLblsupplieragbkvknumberfilter_Jsonclick ;
      private string edtavCsupplieragbkvknumber_Internalname ;
      private string edtavCsupplieragbkvknumber_Jsonclick ;
      private string divSupplieragbphonefiltercontainer_Internalname ;
      private string lblLblsupplieragbphonefilter_Internalname ;
      private string lblLblsupplieragbphonefilter_Jsonclick ;
      private string edtavCsupplieragbphone_Internalname ;
      private string edtavCsupplieragbphone_Jsonclick ;
      private string divSupplieragbemailfiltercontainer_Internalname ;
      private string lblLblsupplieragbemailfilter_Internalname ;
      private string lblLblsupplieragbemailfilter_Jsonclick ;
      private string edtavCsupplieragbemail_Internalname ;
      private string edtavCsupplieragbemail_Jsonclick ;
      private string divGridtable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtSupplierAgbId_Internalname ;
      private string edtSupplierAgbNumber_Internalname ;
      private string edtSupplierAgbKvkNumber_Internalname ;
      private string lV10cSupplierAgbPhone ;
      private string A56SupplierAgbPhone ;
      private string AV13ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_74_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtSupplierAgbId_Jsonclick ;
      private string edtSupplierAgbNumber_Link ;
      private string edtSupplierAgbNumber_Jsonclick ;
      private string edtSupplierAgbKvkNumber_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_74_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV7cSupplierAgbNumber ;
      private string AV8cSupplierAgbName ;
      private string AV9cSupplierAgbKvkNumber ;
      private string AV11cSupplierAgbEmail ;
      private string AV14Linkselection_GXI ;
      private string A50SupplierAgbNumber ;
      private string A52SupplierAgbKvkNumber ;
      private string lV7cSupplierAgbNumber ;
      private string lV8cSupplierAgbName ;
      private string lV9cSupplierAgbKvkNumber ;
      private string lV11cSupplierAgbEmail ;
      private string A51SupplierAgbName ;
      private string A57SupplierAgbEmail ;
      private string AV5LinkSelection ;
      private Guid AV12pSupplierAgbId ;
      private Guid AV6cSupplierAgbId ;
      private Guid A49SupplierAgbId ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H000B2_A57SupplierAgbEmail ;
      private string[] H000B2_A56SupplierAgbPhone ;
      private string[] H000B2_A51SupplierAgbName ;
      private string[] H000B2_A52SupplierAgbKvkNumber ;
      private string[] H000B2_A50SupplierAgbNumber ;
      private Guid[] H000B2_A49SupplierAgbId ;
      private long[] H000B3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private Guid aP0_pSupplierAgbId ;
   }

   public class gx00b0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000B2( IGxContext context ,
                                             string AV7cSupplierAgbNumber ,
                                             string AV8cSupplierAgbName ,
                                             string AV9cSupplierAgbKvkNumber ,
                                             string AV10cSupplierAgbPhone ,
                                             string AV11cSupplierAgbEmail ,
                                             string A50SupplierAgbNumber ,
                                             string A51SupplierAgbName ,
                                             string A52SupplierAgbKvkNumber ,
                                             string A56SupplierAgbPhone ,
                                             string A57SupplierAgbEmail ,
                                             Guid AV6cSupplierAgbId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " SupplierAgbEmail, SupplierAgbPhone, SupplierAgbName, SupplierAgbKvkNumber, SupplierAgbNumber, SupplierAgbId";
         sFromString = " FROM Trn_SupplierAGB";
         sOrderString = "";
         AddWhere(sWhereString, "(SupplierAgbId >= :AV6cSupplierAgbId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cSupplierAgbNumber)) )
         {
            AddWhere(sWhereString, "(SupplierAgbNumber like :lV7cSupplierAgbNumber)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cSupplierAgbName)) )
         {
            AddWhere(sWhereString, "(SupplierAgbName like :lV8cSupplierAgbName)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cSupplierAgbKvkNumber)) )
         {
            AddWhere(sWhereString, "(SupplierAgbKvkNumber like :lV9cSupplierAgbKvkNumber)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cSupplierAgbPhone)) )
         {
            AddWhere(sWhereString, "(SupplierAgbPhone like :lV10cSupplierAgbPhone)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cSupplierAgbEmail)) )
         {
            AddWhere(sWhereString, "(SupplierAgbEmail like :lV11cSupplierAgbEmail)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         sOrderString += " ORDER BY SupplierAgbId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000B3( IGxContext context ,
                                             string AV7cSupplierAgbNumber ,
                                             string AV8cSupplierAgbName ,
                                             string AV9cSupplierAgbKvkNumber ,
                                             string AV10cSupplierAgbPhone ,
                                             string AV11cSupplierAgbEmail ,
                                             string A50SupplierAgbNumber ,
                                             string A51SupplierAgbName ,
                                             string A52SupplierAgbKvkNumber ,
                                             string A56SupplierAgbPhone ,
                                             string A57SupplierAgbEmail ,
                                             Guid AV6cSupplierAgbId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM Trn_SupplierAGB";
         AddWhere(sWhereString, "(SupplierAgbId >= :AV6cSupplierAgbId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cSupplierAgbNumber)) )
         {
            AddWhere(sWhereString, "(SupplierAgbNumber like :lV7cSupplierAgbNumber)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cSupplierAgbName)) )
         {
            AddWhere(sWhereString, "(SupplierAgbName like :lV8cSupplierAgbName)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cSupplierAgbKvkNumber)) )
         {
            AddWhere(sWhereString, "(SupplierAgbKvkNumber like :lV9cSupplierAgbKvkNumber)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cSupplierAgbPhone)) )
         {
            AddWhere(sWhereString, "(SupplierAgbPhone like :lV10cSupplierAgbPhone)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cSupplierAgbEmail)) )
         {
            AddWhere(sWhereString, "(SupplierAgbEmail like :lV11cSupplierAgbEmail)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H000B2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (Guid)dynConstraints[10] );
               case 1 :
                     return conditional_H000B3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (Guid)dynConstraints[10] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000B2;
          prmH000B2 = new Object[] {
          new ParDef("AV6cSupplierAgbId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV7cSupplierAgbNumber",GXType.VarChar,8,0) ,
          new ParDef("lV8cSupplierAgbName",GXType.VarChar,100,0) ,
          new ParDef("lV9cSupplierAgbKvkNumber",GXType.VarChar,8,0) ,
          new ParDef("lV10cSupplierAgbPhone",GXType.Char,20,0) ,
          new ParDef("lV11cSupplierAgbEmail",GXType.VarChar,100,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000B3;
          prmH000B3 = new Object[] {
          new ParDef("AV6cSupplierAgbId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV7cSupplierAgbNumber",GXType.VarChar,8,0) ,
          new ParDef("lV8cSupplierAgbName",GXType.VarChar,100,0) ,
          new ParDef("lV9cSupplierAgbKvkNumber",GXType.VarChar,8,0) ,
          new ParDef("lV10cSupplierAgbPhone",GXType.Char,20,0) ,
          new ParDef("lV11cSupplierAgbEmail",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000B2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000B2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H000B3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000B3,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((Guid[]) buf[5])[0] = rslt.getGuid(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
