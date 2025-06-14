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
   public class gx0050 : GXDataArea
   {
      public gx0050( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx0050( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out Guid aP0_pManagerId ,
                           out Guid aP1_pOrganisationId )
      {
         this.AV13pManagerId = Guid.Empty ;
         this.AV14pOrganisationId = Guid.Empty ;
         ExecuteImpl();
         aP0_pManagerId=this.AV13pManagerId;
         aP1_pOrganisationId=this.AV14pOrganisationId;
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
            gxfirstwebparm = GetFirstPar( "pManagerId");
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
               gxfirstwebparm = GetFirstPar( "pManagerId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pManagerId");
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
               AV13pManagerId = StringUtil.StrToGuid( gxfirstwebparm);
               AssignAttri("", false, "AV13pManagerId", AV13pManagerId.ToString());
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV14pOrganisationId = StringUtil.StrToGuid( GetPar( "pOrganisationId"));
                  AssignAttri("", false, "AV14pOrganisationId", AV14pOrganisationId.ToString());
               }
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
         nRC_GXsfl_84 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_84"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_84_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_84_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_84_idx = GetPar( "sGXsfl_84_idx");
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
         AV6cManagerId = StringUtil.StrToGuid( GetPar( "cManagerId"));
         AV7cOrganisationId = StringUtil.StrToGuid( GetPar( "cOrganisationId"));
         AV8cManagerGivenName = GetPar( "cManagerGivenName");
         AV9cManagerLastName = GetPar( "cManagerLastName");
         AV10cManagerInitials = GetPar( "cManagerInitials");
         AV11cManagerEmail = GetPar( "cManagerEmail");
         AV12cManagerPhone = GetPar( "cManagerPhone");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cManagerId, AV7cOrganisationId, AV8cManagerGivenName, AV9cManagerLastName, AV10cManagerInitials, AV11cManagerEmail, AV12cManagerPhone) ;
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
            return "gx0050_Execute" ;
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
         PA062( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START062( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0050.aspx", new object[] {UrlEncode(AV13pManagerId.ToString()),UrlEncode(AV14pOrganisationId.ToString())}, new string[] {"pManagerId","pOrganisationId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCMANAGERID", AV6cManagerId.ToString());
         GxWebStd.gx_hidden_field( context, "GXH_vCORGANISATIONID", AV7cOrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "GXH_vCMANAGERGIVENNAME", AV8cManagerGivenName);
         GxWebStd.gx_hidden_field( context, "GXH_vCMANAGERLASTNAME", AV9cManagerLastName);
         GxWebStd.gx_hidden_field( context, "GXH_vCMANAGERINITIALS", StringUtil.RTrim( AV10cManagerInitials));
         GxWebStd.gx_hidden_field( context, "GXH_vCMANAGEREMAIL", AV11cManagerEmail);
         GxWebStd.gx_hidden_field( context, "GXH_vCMANAGERPHONE", StringUtil.RTrim( AV12cManagerPhone));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPMANAGERID", AV13pManagerId.ToString());
         GxWebStd.gx_hidden_field( context, "vPORGANISATIONID", AV14pOrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "MANAGERIDFILTERCONTAINER_Class", StringUtil.RTrim( divManageridfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ORGANISATIONIDFILTERCONTAINER_Class", StringUtil.RTrim( divOrganisationidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "MANAGERGIVENNAMEFILTERCONTAINER_Class", StringUtil.RTrim( divManagergivennamefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "MANAGERLASTNAMEFILTERCONTAINER_Class", StringUtil.RTrim( divManagerlastnamefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "MANAGERINITIALSFILTERCONTAINER_Class", StringUtil.RTrim( divManagerinitialsfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "MANAGEREMAILFILTERCONTAINER_Class", StringUtil.RTrim( divManageremailfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "MANAGERPHONEFILTERCONTAINER_Class", StringUtil.RTrim( divManagerphonefiltercontainer_Class));
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
            WE062( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT062( ) ;
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
         return formatLink("gx0050.aspx", new object[] {UrlEncode(AV13pManagerId.ToString()),UrlEncode(AV14pOrganisationId.ToString())}, new string[] {"pManagerId","pOrganisationId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0050" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Trn_Manager", "") ;
      }

      protected void WB060( )
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
            GxWebStd.gx_div_start( context, divManageridfiltercontainer_Internalname, 1, 0, "px", 0, "px", divManageridfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmanageridfilter_Internalname, context.GetMessage( "Manager Id", ""), "", "", lblLblmanageridfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11061_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0050.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmanagerid_Internalname, context.GetMessage( "Manager Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmanagerid_Internalname, AV6cManagerId.ToString(), AV6cManagerId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmanagerid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmanagerid_Visible, edtavCmanagerid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Gx0050.htm");
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
            GxWebStd.gx_div_start( context, divOrganisationidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divOrganisationidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblorganisationidfilter_Internalname, context.GetMessage( "Organisation Id", ""), "", "", lblLblorganisationidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12061_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0050.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCorganisationid_Internalname, context.GetMessage( "Organisation Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCorganisationid_Internalname, AV7cOrganisationId.ToString(), AV7cOrganisationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCorganisationid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCorganisationid_Visible, edtavCorganisationid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Gx0050.htm");
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
            GxWebStd.gx_div_start( context, divManagergivennamefiltercontainer_Internalname, 1, 0, "px", 0, "px", divManagergivennamefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmanagergivennamefilter_Internalname, context.GetMessage( "Manager Given Name", ""), "", "", lblLblmanagergivennamefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13061_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0050.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmanagergivenname_Internalname, context.GetMessage( "Manager Given Name", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmanagergivenname_Internalname, AV8cManagerGivenName, StringUtil.RTrim( context.localUtil.Format( AV8cManagerGivenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmanagergivenname_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmanagergivenname_Visible, edtavCmanagergivenname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0050.htm");
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
            GxWebStd.gx_div_start( context, divManagerlastnamefiltercontainer_Internalname, 1, 0, "px", 0, "px", divManagerlastnamefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmanagerlastnamefilter_Internalname, context.GetMessage( "Manager Last Name", ""), "", "", lblLblmanagerlastnamefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14061_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0050.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmanagerlastname_Internalname, context.GetMessage( "Manager Last Name", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmanagerlastname_Internalname, AV9cManagerLastName, StringUtil.RTrim( context.localUtil.Format( AV9cManagerLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmanagerlastname_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmanagerlastname_Visible, edtavCmanagerlastname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0050.htm");
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
            GxWebStd.gx_div_start( context, divManagerinitialsfiltercontainer_Internalname, 1, 0, "px", 0, "px", divManagerinitialsfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmanagerinitialsfilter_Internalname, context.GetMessage( "Manager Initials", ""), "", "", lblLblmanagerinitialsfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15061_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0050.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmanagerinitials_Internalname, context.GetMessage( "Manager Initials", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmanagerinitials_Internalname, StringUtil.RTrim( AV10cManagerInitials), StringUtil.RTrim( context.localUtil.Format( AV10cManagerInitials, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmanagerinitials_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmanagerinitials_Visible, edtavCmanagerinitials_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0050.htm");
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
            GxWebStd.gx_div_start( context, divManageremailfiltercontainer_Internalname, 1, 0, "px", 0, "px", divManageremailfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmanageremailfilter_Internalname, context.GetMessage( "Manager Email", ""), "", "", lblLblmanageremailfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16061_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0050.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmanageremail_Internalname, context.GetMessage( "Manager Email", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmanageremail_Internalname, AV11cManagerEmail, StringUtil.RTrim( context.localUtil.Format( AV11cManagerEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmanageremail_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmanageremail_Visible, edtavCmanageremail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_Gx0050.htm");
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
            GxWebStd.gx_div_start( context, divManagerphonefiltercontainer_Internalname, 1, 0, "px", 0, "px", divManagerphonefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmanagerphonefilter_Internalname, context.GetMessage( "Manager Phone", ""), "", "", lblLblmanagerphonefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e17061_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0050.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmanagerphone_Internalname, context.GetMessage( "Manager Phone", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmanagerphone_Internalname, StringUtil.RTrim( AV12cManagerPhone), StringUtil.RTrim( context.localUtil.Format( AV12cManagerPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmanagerphone_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmanagerphone_Visible, edtavCmanagerphone_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_Gx0050.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e18061_client"+"'", TempTags, "", 2, "HLP_Gx0050.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl84( ) ;
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            nRC_GXsfl_84 = (int)(nGXsfl_84_idx-1);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0050.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 84 )
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

      protected void START062( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Trn_Manager", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP060( ) ;
      }

      protected void WS062( )
      {
         START062( ) ;
         EVT062( ) ;
      }

      protected void EVT062( )
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
                              nGXsfl_84_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
                              SubsflControlProps_842( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV16Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A21ManagerId = StringUtil.StrToGuid( cgiGet( edtManagerId_Internalname));
                              A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
                              A24ManagerInitials = cgiGet( edtManagerInitials_Internalname);
                              A26ManagerPhone = cgiGet( edtManagerPhone_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E19062 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E20062 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cmanagerid Changed */
                                       if ( StringUtil.StrToGuid( cgiGet( "GXH_vCMANAGERID")) != AV6cManagerId )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Corganisationid Changed */
                                       if ( StringUtil.StrToGuid( cgiGet( "GXH_vCORGANISATIONID")) != AV7cOrganisationId )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmanagergivenname Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCMANAGERGIVENNAME"), AV8cManagerGivenName) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmanagerlastname Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCMANAGERLASTNAME"), AV9cManagerLastName) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmanagerinitials Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCMANAGERINITIALS"), AV10cManagerInitials) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmanageremail Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCMANAGEREMAIL"), AV11cManagerEmail) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmanagerphone Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCMANAGERPHONE"), AV12cManagerPhone) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E21062 ();
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

      protected void WE062( )
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

      protected void PA062( )
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
         SubsflControlProps_842( ) ;
         while ( nGXsfl_84_idx <= nRC_GXsfl_84 )
         {
            sendrow_842( ) ;
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        Guid AV6cManagerId ,
                                        Guid AV7cOrganisationId ,
                                        string AV8cManagerGivenName ,
                                        string AV9cManagerLastName ,
                                        string AV10cManagerInitials ,
                                        string AV11cManagerEmail ,
                                        string AV12cManagerPhone )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF062( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_MANAGERID", GetSecureSignedToken( "", A21ManagerId, context));
         GxWebStd.gx_hidden_field( context, "MANAGERID", A21ManagerId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_ORGANISATIONID", GetSecureSignedToken( "", A11OrganisationId, context));
         GxWebStd.gx_hidden_field( context, "ORGANISATIONID", A11OrganisationId.ToString());
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
         RF062( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF062( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 84;
         nGXsfl_84_idx = 1;
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         bGXsfl_84_Refreshing = true;
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
            SubsflControlProps_842( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV8cManagerGivenName ,
                                                 AV9cManagerLastName ,
                                                 AV10cManagerInitials ,
                                                 AV11cManagerEmail ,
                                                 AV12cManagerPhone ,
                                                 A22ManagerGivenName ,
                                                 A23ManagerLastName ,
                                                 A24ManagerInitials ,
                                                 A25ManagerEmail ,
                                                 A26ManagerPhone ,
                                                 AV6cManagerId ,
                                                 AV7cOrganisationId } ,
                                                 new int[]{
                                                 }
            });
            lV8cManagerGivenName = StringUtil.Concat( StringUtil.RTrim( AV8cManagerGivenName), "%", "");
            lV9cManagerLastName = StringUtil.Concat( StringUtil.RTrim( AV9cManagerLastName), "%", "");
            lV10cManagerInitials = StringUtil.PadR( StringUtil.RTrim( AV10cManagerInitials), 20, "%");
            lV11cManagerEmail = StringUtil.Concat( StringUtil.RTrim( AV11cManagerEmail), "%", "");
            lV12cManagerPhone = StringUtil.PadR( StringUtil.RTrim( AV12cManagerPhone), 20, "%");
            /* Using cursor H00062 */
            pr_default.execute(0, new Object[] {AV6cManagerId, AV7cOrganisationId, lV8cManagerGivenName, lV9cManagerLastName, lV10cManagerInitials, lV11cManagerEmail, lV12cManagerPhone, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A25ManagerEmail = H00062_A25ManagerEmail[0];
               A23ManagerLastName = H00062_A23ManagerLastName[0];
               A22ManagerGivenName = H00062_A22ManagerGivenName[0];
               A26ManagerPhone = H00062_A26ManagerPhone[0];
               A24ManagerInitials = H00062_A24ManagerInitials[0];
               A11OrganisationId = H00062_A11OrganisationId[0];
               A21ManagerId = H00062_A21ManagerId[0];
               /* Execute user event: Load */
               E20062 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB060( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes062( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_MANAGERID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, A21ManagerId, context));
         GxWebStd.gx_hidden_field( context, "gxhash_ORGANISATIONID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, A11OrganisationId, context));
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
                                              AV8cManagerGivenName ,
                                              AV9cManagerLastName ,
                                              AV10cManagerInitials ,
                                              AV11cManagerEmail ,
                                              AV12cManagerPhone ,
                                              A22ManagerGivenName ,
                                              A23ManagerLastName ,
                                              A24ManagerInitials ,
                                              A25ManagerEmail ,
                                              A26ManagerPhone ,
                                              AV6cManagerId ,
                                              AV7cOrganisationId } ,
                                              new int[]{
                                              }
         });
         lV8cManagerGivenName = StringUtil.Concat( StringUtil.RTrim( AV8cManagerGivenName), "%", "");
         lV9cManagerLastName = StringUtil.Concat( StringUtil.RTrim( AV9cManagerLastName), "%", "");
         lV10cManagerInitials = StringUtil.PadR( StringUtil.RTrim( AV10cManagerInitials), 20, "%");
         lV11cManagerEmail = StringUtil.Concat( StringUtil.RTrim( AV11cManagerEmail), "%", "");
         lV12cManagerPhone = StringUtil.PadR( StringUtil.RTrim( AV12cManagerPhone), 20, "%");
         /* Using cursor H00063 */
         pr_default.execute(1, new Object[] {AV6cManagerId, AV7cOrganisationId, lV8cManagerGivenName, lV9cManagerLastName, lV10cManagerInitials, lV11cManagerEmail, lV12cManagerPhone});
         GRID1_nRecordCount = H00063_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cManagerId, AV7cOrganisationId, AV8cManagerGivenName, AV9cManagerLastName, AV10cManagerInitials, AV11cManagerEmail, AV12cManagerPhone) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cManagerId, AV7cOrganisationId, AV8cManagerGivenName, AV9cManagerLastName, AV10cManagerInitials, AV11cManagerEmail, AV12cManagerPhone) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cManagerId, AV7cOrganisationId, AV8cManagerGivenName, AV9cManagerLastName, AV10cManagerInitials, AV11cManagerEmail, AV12cManagerPhone) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cManagerId, AV7cOrganisationId, AV8cManagerGivenName, AV9cManagerLastName, AV10cManagerInitials, AV11cManagerEmail, AV12cManagerPhone) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cManagerId, AV7cOrganisationId, AV8cManagerGivenName, AV9cManagerLastName, AV10cManagerInitials, AV11cManagerEmail, AV12cManagerPhone) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtManagerId_Enabled = 0;
         edtOrganisationId_Enabled = 0;
         edtManagerInitials_Enabled = 0;
         edtManagerPhone_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP060( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E19062 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_84 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_84"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( StringUtil.StrCmp(cgiGet( edtavCmanagerid_Internalname), "") == 0 )
            {
               AV6cManagerId = Guid.Empty;
               AssignAttri("", false, "AV6cManagerId", AV6cManagerId.ToString());
            }
            else
            {
               try
               {
                  AV6cManagerId = StringUtil.StrToGuid( cgiGet( edtavCmanagerid_Internalname));
                  AssignAttri("", false, "AV6cManagerId", AV6cManagerId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vCMANAGERID");
                  GX_FocusControl = edtavCmanagerid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            if ( StringUtil.StrCmp(cgiGet( edtavCorganisationid_Internalname), "") == 0 )
            {
               AV7cOrganisationId = Guid.Empty;
               AssignAttri("", false, "AV7cOrganisationId", AV7cOrganisationId.ToString());
            }
            else
            {
               try
               {
                  AV7cOrganisationId = StringUtil.StrToGuid( cgiGet( edtavCorganisationid_Internalname));
                  AssignAttri("", false, "AV7cOrganisationId", AV7cOrganisationId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vCORGANISATIONID");
                  GX_FocusControl = edtavCorganisationid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            AV8cManagerGivenName = cgiGet( edtavCmanagergivenname_Internalname);
            AssignAttri("", false, "AV8cManagerGivenName", AV8cManagerGivenName);
            AV9cManagerLastName = cgiGet( edtavCmanagerlastname_Internalname);
            AssignAttri("", false, "AV9cManagerLastName", AV9cManagerLastName);
            AV10cManagerInitials = cgiGet( edtavCmanagerinitials_Internalname);
            AssignAttri("", false, "AV10cManagerInitials", AV10cManagerInitials);
            AV11cManagerEmail = cgiGet( edtavCmanageremail_Internalname);
            AssignAttri("", false, "AV11cManagerEmail", AV11cManagerEmail);
            AV12cManagerPhone = cgiGet( edtavCmanagerphone_Internalname);
            AssignAttri("", false, "AV12cManagerPhone", AV12cManagerPhone);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrToGuid( cgiGet( "GXH_vCMANAGERID")) != AV6cManagerId )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToGuid( cgiGet( "GXH_vCORGANISATIONID")) != AV7cOrganisationId )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCMANAGERGIVENNAME"), AV8cManagerGivenName) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCMANAGERLASTNAME"), AV9cManagerLastName) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCMANAGERINITIALS"), AV10cManagerInitials) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCMANAGEREMAIL"), AV11cManagerEmail) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCMANAGERPHONE"), AV12cManagerPhone) != 0 )
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
         E19062 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19062( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Trn_Manager", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV15ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E20062( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "SelectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV16Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
         sendrow_842( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_84_Refreshing )
         {
            DoAjaxLoad(84, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E21062 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E21062( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pManagerId = A21ManagerId;
         AssignAttri("", false, "AV13pManagerId", AV13pManagerId.ToString());
         AV14pOrganisationId = A11OrganisationId;
         AssignAttri("", false, "AV14pOrganisationId", AV14pOrganisationId.ToString());
         context.setWebReturnParms(new Object[] {(Guid)AV13pManagerId,(Guid)AV14pOrganisationId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pManagerId","AV14pOrganisationId"});
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
         AV13pManagerId = (Guid)getParm(obj,0);
         AssignAttri("", false, "AV13pManagerId", AV13pManagerId.ToString());
         AV14pOrganisationId = (Guid)getParm(obj,1);
         AssignAttri("", false, "AV14pOrganisationId", AV14pOrganisationId.ToString());
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
         PA062( ) ;
         WS062( ) ;
         WE062( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025614645269", true, true);
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
         context.AddJavascriptSource("gx0050.js", "?2025614645269", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtManagerId_Internalname = "MANAGERID_"+sGXsfl_84_idx;
         edtOrganisationId_Internalname = "ORGANISATIONID_"+sGXsfl_84_idx;
         edtManagerInitials_Internalname = "MANAGERINITIALS_"+sGXsfl_84_idx;
         edtManagerPhone_Internalname = "MANAGERPHONE_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtManagerId_Internalname = "MANAGERID_"+sGXsfl_84_fel_idx;
         edtOrganisationId_Internalname = "ORGANISATIONID_"+sGXsfl_84_fel_idx;
         edtManagerInitials_Internalname = "MANAGERINITIALS_"+sGXsfl_84_fel_idx;
         edtManagerPhone_Internalname = "MANAGERPHONE_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         WB060( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_84_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_84_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_84_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( A21ManagerId.ToString())+"'"+", "+"'"+GXUtil.EncodeJSConstant( A11OrganisationId.ToString())+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV16Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV16Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtManagerId_Internalname,A21ManagerId.ToString(),A21ManagerId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtManagerId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)84,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrganisationId_Internalname,A11OrganisationId.ToString(),A11OrganisationId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOrganisationId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)84,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtManagerInitials_Internalname,StringUtil.RTrim( A24ManagerInitials),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtManagerInitials_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A26ManagerPhone);
            }
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtManagerPhone_Internalname,StringUtil.RTrim( A26ManagerPhone),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtManagerPhone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes062( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl84( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"84\">") ;
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
            context.SendWebValue( context.GetMessage( "Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Organisation Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Initials", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Phone", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A21ManagerId.ToString()));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A11OrganisationId.ToString()));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A24ManagerInitials)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A26ManagerPhone)));
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
         lblLblmanageridfilter_Internalname = "LBLMANAGERIDFILTER";
         edtavCmanagerid_Internalname = "vCMANAGERID";
         divManageridfiltercontainer_Internalname = "MANAGERIDFILTERCONTAINER";
         lblLblorganisationidfilter_Internalname = "LBLORGANISATIONIDFILTER";
         edtavCorganisationid_Internalname = "vCORGANISATIONID";
         divOrganisationidfiltercontainer_Internalname = "ORGANISATIONIDFILTERCONTAINER";
         lblLblmanagergivennamefilter_Internalname = "LBLMANAGERGIVENNAMEFILTER";
         edtavCmanagergivenname_Internalname = "vCMANAGERGIVENNAME";
         divManagergivennamefiltercontainer_Internalname = "MANAGERGIVENNAMEFILTERCONTAINER";
         lblLblmanagerlastnamefilter_Internalname = "LBLMANAGERLASTNAMEFILTER";
         edtavCmanagerlastname_Internalname = "vCMANAGERLASTNAME";
         divManagerlastnamefiltercontainer_Internalname = "MANAGERLASTNAMEFILTERCONTAINER";
         lblLblmanagerinitialsfilter_Internalname = "LBLMANAGERINITIALSFILTER";
         edtavCmanagerinitials_Internalname = "vCMANAGERINITIALS";
         divManagerinitialsfiltercontainer_Internalname = "MANAGERINITIALSFILTERCONTAINER";
         lblLblmanageremailfilter_Internalname = "LBLMANAGEREMAILFILTER";
         edtavCmanageremail_Internalname = "vCMANAGEREMAIL";
         divManageremailfiltercontainer_Internalname = "MANAGEREMAILFILTERCONTAINER";
         lblLblmanagerphonefilter_Internalname = "LBLMANAGERPHONEFILTER";
         edtavCmanagerphone_Internalname = "vCMANAGERPHONE";
         divManagerphonefiltercontainer_Internalname = "MANAGERPHONEFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtManagerId_Internalname = "MANAGERID";
         edtOrganisationId_Internalname = "ORGANISATIONID";
         edtManagerInitials_Internalname = "MANAGERINITIALS";
         edtManagerPhone_Internalname = "MANAGERPHONE";
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
         edtManagerPhone_Jsonclick = "";
         edtManagerInitials_Jsonclick = "";
         edtOrganisationId_Jsonclick = "";
         edtManagerId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtManagerPhone_Enabled = 0;
         edtManagerInitials_Enabled = 0;
         edtOrganisationId_Enabled = 0;
         edtManagerId_Enabled = 0;
         edtavCmanagerphone_Jsonclick = "";
         edtavCmanagerphone_Enabled = 1;
         edtavCmanagerphone_Visible = 1;
         edtavCmanageremail_Jsonclick = "";
         edtavCmanageremail_Enabled = 1;
         edtavCmanageremail_Visible = 1;
         edtavCmanagerinitials_Jsonclick = "";
         edtavCmanagerinitials_Enabled = 1;
         edtavCmanagerinitials_Visible = 1;
         edtavCmanagerlastname_Jsonclick = "";
         edtavCmanagerlastname_Enabled = 1;
         edtavCmanagerlastname_Visible = 1;
         edtavCmanagergivenname_Jsonclick = "";
         edtavCmanagergivenname_Enabled = 1;
         edtavCmanagergivenname_Visible = 1;
         edtavCorganisationid_Jsonclick = "";
         edtavCorganisationid_Enabled = 1;
         edtavCorganisationid_Visible = 1;
         edtavCmanagerid_Jsonclick = "";
         edtavCmanagerid_Enabled = 1;
         edtavCmanagerid_Visible = 1;
         divManagerphonefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divManageremailfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divManagerinitialsfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divManagerlastnamefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divManagergivennamefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divOrganisationidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divManageridfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Trn_Manager", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cManagerId","fld":"vCMANAGERID"},{"av":"AV7cOrganisationId","fld":"vCORGANISATIONID"},{"av":"AV8cManagerGivenName","fld":"vCMANAGERGIVENNAME"},{"av":"AV9cManagerLastName","fld":"vCMANAGERLASTNAME"},{"av":"AV10cManagerInitials","fld":"vCMANAGERINITIALS"},{"av":"AV11cManagerEmail","fld":"vCMANAGEREMAIL"},{"av":"AV12cManagerPhone","fld":"vCMANAGERPHONE"}]}""");
         setEventMetadata("'TOGGLE'","""{"handler":"E18061","iparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]""");
         setEventMetadata("'TOGGLE'",""","oparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]}""");
         setEventMetadata("LBLMANAGERIDFILTER.CLICK","""{"handler":"E11061","iparms":[{"av":"divManageridfiltercontainer_Class","ctrl":"MANAGERIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLMANAGERIDFILTER.CLICK",""","oparms":[{"av":"divManageridfiltercontainer_Class","ctrl":"MANAGERIDFILTERCONTAINER","prop":"Class"},{"av":"edtavCmanagerid_Visible","ctrl":"vCMANAGERID","prop":"Visible"}]}""");
         setEventMetadata("LBLORGANISATIONIDFILTER.CLICK","""{"handler":"E12061","iparms":[{"av":"divOrganisationidfiltercontainer_Class","ctrl":"ORGANISATIONIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLORGANISATIONIDFILTER.CLICK",""","oparms":[{"av":"divOrganisationidfiltercontainer_Class","ctrl":"ORGANISATIONIDFILTERCONTAINER","prop":"Class"},{"av":"edtavCorganisationid_Visible","ctrl":"vCORGANISATIONID","prop":"Visible"}]}""");
         setEventMetadata("LBLMANAGERGIVENNAMEFILTER.CLICK","""{"handler":"E13061","iparms":[{"av":"divManagergivennamefiltercontainer_Class","ctrl":"MANAGERGIVENNAMEFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLMANAGERGIVENNAMEFILTER.CLICK",""","oparms":[{"av":"divManagergivennamefiltercontainer_Class","ctrl":"MANAGERGIVENNAMEFILTERCONTAINER","prop":"Class"},{"av":"edtavCmanagergivenname_Visible","ctrl":"vCMANAGERGIVENNAME","prop":"Visible"}]}""");
         setEventMetadata("LBLMANAGERLASTNAMEFILTER.CLICK","""{"handler":"E14061","iparms":[{"av":"divManagerlastnamefiltercontainer_Class","ctrl":"MANAGERLASTNAMEFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLMANAGERLASTNAMEFILTER.CLICK",""","oparms":[{"av":"divManagerlastnamefiltercontainer_Class","ctrl":"MANAGERLASTNAMEFILTERCONTAINER","prop":"Class"},{"av":"edtavCmanagerlastname_Visible","ctrl":"vCMANAGERLASTNAME","prop":"Visible"}]}""");
         setEventMetadata("LBLMANAGERINITIALSFILTER.CLICK","""{"handler":"E15061","iparms":[{"av":"divManagerinitialsfiltercontainer_Class","ctrl":"MANAGERINITIALSFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLMANAGERINITIALSFILTER.CLICK",""","oparms":[{"av":"divManagerinitialsfiltercontainer_Class","ctrl":"MANAGERINITIALSFILTERCONTAINER","prop":"Class"},{"av":"edtavCmanagerinitials_Visible","ctrl":"vCMANAGERINITIALS","prop":"Visible"}]}""");
         setEventMetadata("LBLMANAGEREMAILFILTER.CLICK","""{"handler":"E16061","iparms":[{"av":"divManageremailfiltercontainer_Class","ctrl":"MANAGEREMAILFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLMANAGEREMAILFILTER.CLICK",""","oparms":[{"av":"divManageremailfiltercontainer_Class","ctrl":"MANAGEREMAILFILTERCONTAINER","prop":"Class"},{"av":"edtavCmanageremail_Visible","ctrl":"vCMANAGEREMAIL","prop":"Visible"}]}""");
         setEventMetadata("LBLMANAGERPHONEFILTER.CLICK","""{"handler":"E17061","iparms":[{"av":"divManagerphonefiltercontainer_Class","ctrl":"MANAGERPHONEFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLMANAGERPHONEFILTER.CLICK",""","oparms":[{"av":"divManagerphonefiltercontainer_Class","ctrl":"MANAGERPHONEFILTERCONTAINER","prop":"Class"},{"av":"edtavCmanagerphone_Visible","ctrl":"vCMANAGERPHONE","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E21062","iparms":[{"av":"A21ManagerId","fld":"MANAGERID","hsh":true},{"av":"A11OrganisationId","fld":"ORGANISATIONID","hsh":true}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV13pManagerId","fld":"vPMANAGERID"},{"av":"AV14pOrganisationId","fld":"vPORGANISATIONID"}]}""");
         setEventMetadata("GRID1_FIRSTPAGE","""{"handler":"subgrid1_firstpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cManagerId","fld":"vCMANAGERID"},{"av":"AV7cOrganisationId","fld":"vCORGANISATIONID"},{"av":"AV8cManagerGivenName","fld":"vCMANAGERGIVENNAME"},{"av":"AV9cManagerLastName","fld":"vCMANAGERLASTNAME"},{"av":"AV10cManagerInitials","fld":"vCMANAGERINITIALS"},{"av":"AV11cManagerEmail","fld":"vCMANAGEREMAIL"},{"av":"AV12cManagerPhone","fld":"vCMANAGERPHONE"}]}""");
         setEventMetadata("GRID1_PREVPAGE","""{"handler":"subgrid1_previouspage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cManagerId","fld":"vCMANAGERID"},{"av":"AV7cOrganisationId","fld":"vCORGANISATIONID"},{"av":"AV8cManagerGivenName","fld":"vCMANAGERGIVENNAME"},{"av":"AV9cManagerLastName","fld":"vCMANAGERLASTNAME"},{"av":"AV10cManagerInitials","fld":"vCMANAGERINITIALS"},{"av":"AV11cManagerEmail","fld":"vCMANAGEREMAIL"},{"av":"AV12cManagerPhone","fld":"vCMANAGERPHONE"}]}""");
         setEventMetadata("GRID1_NEXTPAGE","""{"handler":"subgrid1_nextpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cManagerId","fld":"vCMANAGERID"},{"av":"AV7cOrganisationId","fld":"vCORGANISATIONID"},{"av":"AV8cManagerGivenName","fld":"vCMANAGERGIVENNAME"},{"av":"AV9cManagerLastName","fld":"vCMANAGERLASTNAME"},{"av":"AV10cManagerInitials","fld":"vCMANAGERINITIALS"},{"av":"AV11cManagerEmail","fld":"vCMANAGEREMAIL"},{"av":"AV12cManagerPhone","fld":"vCMANAGERPHONE"}]}""");
         setEventMetadata("GRID1_LASTPAGE","""{"handler":"subgrid1_lastpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cManagerId","fld":"vCMANAGERID"},{"av":"AV7cOrganisationId","fld":"vCORGANISATIONID"},{"av":"AV8cManagerGivenName","fld":"vCMANAGERGIVENNAME"},{"av":"AV9cManagerLastName","fld":"vCMANAGERLASTNAME"},{"av":"AV10cManagerInitials","fld":"vCMANAGERINITIALS"},{"av":"AV11cManagerEmail","fld":"vCMANAGEREMAIL"},{"av":"AV12cManagerPhone","fld":"vCMANAGERPHONE"}]}""");
         setEventMetadata("VALIDV_CMANAGERID","""{"handler":"Validv_Cmanagerid","iparms":[]}""");
         setEventMetadata("VALIDV_CORGANISATIONID","""{"handler":"Validv_Corganisationid","iparms":[]}""");
         setEventMetadata("VALIDV_CMANAGEREMAIL","""{"handler":"Validv_Cmanageremail","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Managerphone","iparms":[]}""");
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
         AV13pManagerId = Guid.Empty;
         AV14pOrganisationId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV6cManagerId = Guid.Empty;
         AV7cOrganisationId = Guid.Empty;
         AV8cManagerGivenName = "";
         AV9cManagerLastName = "";
         AV10cManagerInitials = "";
         AV11cManagerEmail = "";
         AV12cManagerPhone = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblmanageridfilter_Jsonclick = "";
         TempTags = "";
         lblLblorganisationidfilter_Jsonclick = "";
         lblLblmanagergivennamefilter_Jsonclick = "";
         lblLblmanagerlastnamefilter_Jsonclick = "";
         lblLblmanagerinitialsfilter_Jsonclick = "";
         lblLblmanageremailfilter_Jsonclick = "";
         lblLblmanagerphonefilter_Jsonclick = "";
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
         AV16Linkselection_GXI = "";
         A21ManagerId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A24ManagerInitials = "";
         A26ManagerPhone = "";
         lV8cManagerGivenName = "";
         lV9cManagerLastName = "";
         lV10cManagerInitials = "";
         lV11cManagerEmail = "";
         lV12cManagerPhone = "";
         A22ManagerGivenName = "";
         A23ManagerLastName = "";
         A25ManagerEmail = "";
         H00062_A25ManagerEmail = new string[] {""} ;
         H00062_A23ManagerLastName = new string[] {""} ;
         H00062_A22ManagerGivenName = new string[] {""} ;
         H00062_A26ManagerPhone = new string[] {""} ;
         H00062_A24ManagerInitials = new string[] {""} ;
         H00062_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00062_A21ManagerId = new Guid[] {Guid.Empty} ;
         H00063_AGRID1_nRecordCount = new long[1] ;
         AV15ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         gxphoneLink = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0050__default(),
            new Object[][] {
                new Object[] {
               H00062_A25ManagerEmail, H00062_A23ManagerLastName, H00062_A22ManagerGivenName, H00062_A26ManagerPhone, H00062_A24ManagerInitials, H00062_A11OrganisationId, H00062_A21ManagerId
               }
               , new Object[] {
               H00063_AGRID1_nRecordCount
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
      private int nRC_GXsfl_84 ;
      private int subGrid1_Rows ;
      private int nGXsfl_84_idx=1 ;
      private int edtavCmanagerid_Visible ;
      private int edtavCmanagerid_Enabled ;
      private int edtavCorganisationid_Visible ;
      private int edtavCorganisationid_Enabled ;
      private int edtavCmanagergivenname_Visible ;
      private int edtavCmanagergivenname_Enabled ;
      private int edtavCmanagerlastname_Visible ;
      private int edtavCmanagerlastname_Enabled ;
      private int edtavCmanagerinitials_Visible ;
      private int edtavCmanagerinitials_Enabled ;
      private int edtavCmanageremail_Visible ;
      private int edtavCmanageremail_Enabled ;
      private int edtavCmanagerphone_Visible ;
      private int edtavCmanagerphone_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtManagerId_Enabled ;
      private int edtOrganisationId_Enabled ;
      private int edtManagerInitials_Enabled ;
      private int edtManagerPhone_Enabled ;
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
      private string divManageridfiltercontainer_Class ;
      private string divOrganisationidfiltercontainer_Class ;
      private string divManagergivennamefiltercontainer_Class ;
      private string divManagerlastnamefiltercontainer_Class ;
      private string divManagerinitialsfiltercontainer_Class ;
      private string divManageremailfiltercontainer_Class ;
      private string divManagerphonefiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string AV10cManagerInitials ;
      private string AV12cManagerPhone ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divManageridfiltercontainer_Internalname ;
      private string lblLblmanageridfilter_Internalname ;
      private string lblLblmanageridfilter_Jsonclick ;
      private string edtavCmanagerid_Internalname ;
      private string TempTags ;
      private string edtavCmanagerid_Jsonclick ;
      private string divOrganisationidfiltercontainer_Internalname ;
      private string lblLblorganisationidfilter_Internalname ;
      private string lblLblorganisationidfilter_Jsonclick ;
      private string edtavCorganisationid_Internalname ;
      private string edtavCorganisationid_Jsonclick ;
      private string divManagergivennamefiltercontainer_Internalname ;
      private string lblLblmanagergivennamefilter_Internalname ;
      private string lblLblmanagergivennamefilter_Jsonclick ;
      private string edtavCmanagergivenname_Internalname ;
      private string edtavCmanagergivenname_Jsonclick ;
      private string divManagerlastnamefiltercontainer_Internalname ;
      private string lblLblmanagerlastnamefilter_Internalname ;
      private string lblLblmanagerlastnamefilter_Jsonclick ;
      private string edtavCmanagerlastname_Internalname ;
      private string edtavCmanagerlastname_Jsonclick ;
      private string divManagerinitialsfiltercontainer_Internalname ;
      private string lblLblmanagerinitialsfilter_Internalname ;
      private string lblLblmanagerinitialsfilter_Jsonclick ;
      private string edtavCmanagerinitials_Internalname ;
      private string edtavCmanagerinitials_Jsonclick ;
      private string divManageremailfiltercontainer_Internalname ;
      private string lblLblmanageremailfilter_Internalname ;
      private string lblLblmanageremailfilter_Jsonclick ;
      private string edtavCmanageremail_Internalname ;
      private string edtavCmanageremail_Jsonclick ;
      private string divManagerphonefiltercontainer_Internalname ;
      private string lblLblmanagerphonefilter_Internalname ;
      private string lblLblmanagerphonefilter_Jsonclick ;
      private string edtavCmanagerphone_Internalname ;
      private string edtavCmanagerphone_Jsonclick ;
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
      private string edtManagerId_Internalname ;
      private string edtOrganisationId_Internalname ;
      private string A24ManagerInitials ;
      private string edtManagerInitials_Internalname ;
      private string A26ManagerPhone ;
      private string edtManagerPhone_Internalname ;
      private string lV10cManagerInitials ;
      private string lV12cManagerPhone ;
      private string AV15ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtManagerId_Jsonclick ;
      private string edtOrganisationId_Jsonclick ;
      private string edtManagerInitials_Jsonclick ;
      private string gxphoneLink ;
      private string edtManagerPhone_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV8cManagerGivenName ;
      private string AV9cManagerLastName ;
      private string AV11cManagerEmail ;
      private string AV16Linkselection_GXI ;
      private string lV8cManagerGivenName ;
      private string lV9cManagerLastName ;
      private string lV11cManagerEmail ;
      private string A22ManagerGivenName ;
      private string A23ManagerLastName ;
      private string A25ManagerEmail ;
      private string AV5LinkSelection ;
      private Guid AV13pManagerId ;
      private Guid AV14pOrganisationId ;
      private Guid AV6cManagerId ;
      private Guid AV7cOrganisationId ;
      private Guid A21ManagerId ;
      private Guid A11OrganisationId ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H00062_A25ManagerEmail ;
      private string[] H00062_A23ManagerLastName ;
      private string[] H00062_A22ManagerGivenName ;
      private string[] H00062_A26ManagerPhone ;
      private string[] H00062_A24ManagerInitials ;
      private Guid[] H00062_A11OrganisationId ;
      private Guid[] H00062_A21ManagerId ;
      private long[] H00063_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private Guid aP0_pManagerId ;
      private Guid aP1_pOrganisationId ;
   }

   public class gx0050__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00062( IGxContext context ,
                                             string AV8cManagerGivenName ,
                                             string AV9cManagerLastName ,
                                             string AV10cManagerInitials ,
                                             string AV11cManagerEmail ,
                                             string AV12cManagerPhone ,
                                             string A22ManagerGivenName ,
                                             string A23ManagerLastName ,
                                             string A24ManagerInitials ,
                                             string A25ManagerEmail ,
                                             string A26ManagerPhone ,
                                             Guid AV6cManagerId ,
                                             Guid AV7cOrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " ManagerEmail, ManagerLastName, ManagerGivenName, ManagerPhone, ManagerInitials, OrganisationId, ManagerId";
         sFromString = " FROM Trn_Manager";
         sOrderString = "";
         AddWhere(sWhereString, "(ManagerId >= :AV6cManagerId and OrganisationId >= :AV7cOrganisationId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cManagerGivenName)) )
         {
            AddWhere(sWhereString, "(ManagerGivenName like :lV8cManagerGivenName)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cManagerLastName)) )
         {
            AddWhere(sWhereString, "(ManagerLastName like :lV9cManagerLastName)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cManagerInitials)) )
         {
            AddWhere(sWhereString, "(ManagerInitials like :lV10cManagerInitials)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cManagerEmail)) )
         {
            AddWhere(sWhereString, "(ManagerEmail like :lV11cManagerEmail)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12cManagerPhone)) )
         {
            AddWhere(sWhereString, "(ManagerPhone like :lV12cManagerPhone)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY ManagerId, OrganisationId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00063( IGxContext context ,
                                             string AV8cManagerGivenName ,
                                             string AV9cManagerLastName ,
                                             string AV10cManagerInitials ,
                                             string AV11cManagerEmail ,
                                             string AV12cManagerPhone ,
                                             string A22ManagerGivenName ,
                                             string A23ManagerLastName ,
                                             string A24ManagerInitials ,
                                             string A25ManagerEmail ,
                                             string A26ManagerPhone ,
                                             Guid AV6cManagerId ,
                                             Guid AV7cOrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM Trn_Manager";
         AddWhere(sWhereString, "(ManagerId >= :AV6cManagerId and OrganisationId >= :AV7cOrganisationId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cManagerGivenName)) )
         {
            AddWhere(sWhereString, "(ManagerGivenName like :lV8cManagerGivenName)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cManagerLastName)) )
         {
            AddWhere(sWhereString, "(ManagerLastName like :lV9cManagerLastName)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cManagerInitials)) )
         {
            AddWhere(sWhereString, "(ManagerInitials like :lV10cManagerInitials)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cManagerEmail)) )
         {
            AddWhere(sWhereString, "(ManagerEmail like :lV11cManagerEmail)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12cManagerPhone)) )
         {
            AddWhere(sWhereString, "(ManagerPhone like :lV12cManagerPhone)");
         }
         else
         {
            GXv_int3[6] = 1;
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
                     return conditional_H00062(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (Guid)dynConstraints[10] , (Guid)dynConstraints[11] );
               case 1 :
                     return conditional_H00063(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (Guid)dynConstraints[10] , (Guid)dynConstraints[11] );
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
          Object[] prmH00062;
          prmH00062 = new Object[] {
          new ParDef("AV6cManagerId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV7cOrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV8cManagerGivenName",GXType.VarChar,100,0) ,
          new ParDef("lV9cManagerLastName",GXType.VarChar,100,0) ,
          new ParDef("lV10cManagerInitials",GXType.Char,20,0) ,
          new ParDef("lV11cManagerEmail",GXType.VarChar,100,0) ,
          new ParDef("lV12cManagerPhone",GXType.Char,20,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00063;
          prmH00063 = new Object[] {
          new ParDef("AV6cManagerId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV7cOrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV8cManagerGivenName",GXType.VarChar,100,0) ,
          new ParDef("lV9cManagerLastName",GXType.VarChar,100,0) ,
          new ParDef("lV10cManagerInitials",GXType.Char,20,0) ,
          new ParDef("lV11cManagerEmail",GXType.VarChar,100,0) ,
          new ParDef("lV12cManagerPhone",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00062", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00062,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00063", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00063,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((Guid[]) buf[5])[0] = rslt.getGuid(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
