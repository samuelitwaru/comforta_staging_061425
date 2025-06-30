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
   public class trn_environmentvariable : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
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
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
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
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_environmentvariable.aspx")), "trn_environmentvariable.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_environmentvariable.aspx")))) ;
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
         if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mode");
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               Gx_mode = gxfirstwebparm;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV7EnvironmentVariableId = StringUtil.StrToGuid( GetPar( "EnvironmentVariableId"));
                  AssignAttri("", false, "AV7EnvironmentVariableId", AV7EnvironmentVariableId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vENVIRONMENTVARIABLEID", GetSecureSignedToken( "", AV7EnvironmentVariableId, context));
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( "Trn_Environment Variable", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtEnvironmentVariableKey_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_environmentvariable( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_environmentvariable( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_EnvironmentVariableId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7EnvironmentVariableId = aP1_EnvironmentVariableId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
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
            return "trn_environmentvariable_Execute" ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
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

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
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
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Control Group */
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_EnvironmentVariable.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEnvironmentVariableKey_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEnvironmentVariableKey_Internalname, context.GetMessage( "Variable Key", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtEnvironmentVariableKey_Internalname, A633EnvironmentVariableKey, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", 0, 1, edtEnvironmentVariableKey_Enabled, 0, 80, "chr", 5, "row", 0, StyleString, ClassString, "", "", "400", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_EnvironmentVariable.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEnvironmentVariableValue_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEnvironmentVariableValue_Internalname, context.GetMessage( "Variable Value", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtEnvironmentVariableValue_Internalname, A634EnvironmentVariableValue, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", 0, 1, edtEnvironmentVariableValue_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_EnvironmentVariable.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_EnvironmentVariable.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_EnvironmentVariable.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_EnvironmentVariable.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEnvironmentVariableId_Internalname, A632EnvironmentVariableId.ToString(), A632EnvironmentVariableId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEnvironmentVariableId_Jsonclick, 0, "Attribute", "", "", "", "", edtEnvironmentVariableId_Visible, edtEnvironmentVariableId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_EnvironmentVariable.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E111W2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z632EnvironmentVariableId = StringUtil.StrToGuid( cgiGet( "Z632EnvironmentVariableId"));
               Z633EnvironmentVariableKey = cgiGet( "Z633EnvironmentVariableKey");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7EnvironmentVariableId = StringUtil.StrToGuid( cgiGet( "vENVIRONMENTVARIABLEID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A633EnvironmentVariableKey = cgiGet( edtEnvironmentVariableKey_Internalname);
               AssignAttri("", false, "A633EnvironmentVariableKey", A633EnvironmentVariableKey);
               A634EnvironmentVariableValue = cgiGet( edtEnvironmentVariableValue_Internalname);
               AssignAttri("", false, "A634EnvironmentVariableValue", A634EnvironmentVariableValue);
               if ( StringUtil.StrCmp(cgiGet( edtEnvironmentVariableId_Internalname), "") == 0 )
               {
                  A632EnvironmentVariableId = Guid.Empty;
                  AssignAttri("", false, "A632EnvironmentVariableId", A632EnvironmentVariableId.ToString());
               }
               else
               {
                  try
                  {
                     A632EnvironmentVariableId = StringUtil.StrToGuid( cgiGet( edtEnvironmentVariableId_Internalname));
                     AssignAttri("", false, "A632EnvironmentVariableId", A632EnvironmentVariableId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "ENVIRONMENTVARIABLEID");
                     AnyError = 1;
                     GX_FocusControl = edtEnvironmentVariableId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_EnvironmentVariable");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A632EnvironmentVariableId != Z632EnvironmentVariableId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_environmentvariable:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A632EnvironmentVariableId = StringUtil.StrToGuid( GetPar( "EnvironmentVariableId"));
                  AssignAttri("", false, "A632EnvironmentVariableId", A632EnvironmentVariableId.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV7EnvironmentVariableId) )
                  {
                     A632EnvironmentVariableId = AV7EnvironmentVariableId;
                     AssignAttri("", false, "A632EnvironmentVariableId", A632EnvironmentVariableId.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A632EnvironmentVariableId) && ( Gx_BScreen == 0 ) )
                     {
                        A632EnvironmentVariableId = Guid.NewGuid( );
                        AssignAttri("", false, "A632EnvironmentVariableId", A632EnvironmentVariableId.ToString());
                     }
                  }
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode107 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV7EnvironmentVariableId) )
                     {
                        A632EnvironmentVariableId = AV7EnvironmentVariableId;
                        AssignAttri("", false, "A632EnvironmentVariableId", A632EnvironmentVariableId.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A632EnvironmentVariableId) && ( Gx_BScreen == 0 ) )
                        {
                           A632EnvironmentVariableId = Guid.NewGuid( );
                           AssignAttri("", false, "A632EnvironmentVariableId", A632EnvironmentVariableId.ToString());
                        }
                     }
                     Gx_mode = sMode107;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound107 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1W0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "ENVIRONMENTVARIABLEID");
                        AnyError = 1;
                        GX_FocusControl = edtEnvironmentVariableId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E111W2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121W2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
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

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E121W2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1W107( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtntrn_delete_Visible = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes1W107( ) ;
         }
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_1W0( )
      {
         BeforeValidate1W107( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1W107( ) ;
            }
            else
            {
               CheckExtendedTable1W107( ) ;
               CloseExtendedTableCursors1W107( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption1W0( )
      {
      }

      protected void E111W2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV10TrnContext.FromXml(AV11WebSession.Get("TrnContext"), null, "", "");
         edtEnvironmentVariableId_Visible = 0;
         AssignProp("", false, edtEnvironmentVariableId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEnvironmentVariableId_Visible), 5, 0), true);
      }

      protected void E121W2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV10TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("trn_environmentvariableww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1W107( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z633EnvironmentVariableKey = T001W3_A633EnvironmentVariableKey[0];
            }
            else
            {
               Z633EnvironmentVariableKey = A633EnvironmentVariableKey;
            }
         }
         if ( GX_JID == -5 )
         {
            Z632EnvironmentVariableId = A632EnvironmentVariableId;
            Z633EnvironmentVariableKey = A633EnvironmentVariableKey;
            Z634EnvironmentVariableValue = A634EnvironmentVariableValue;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV7EnvironmentVariableId) )
         {
            edtEnvironmentVariableId_Enabled = 0;
            AssignProp("", false, edtEnvironmentVariableId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEnvironmentVariableId_Enabled), 5, 0), true);
         }
         else
         {
            edtEnvironmentVariableId_Enabled = 1;
            AssignProp("", false, edtEnvironmentVariableId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEnvironmentVariableId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7EnvironmentVariableId) )
         {
            edtEnvironmentVariableId_Enabled = 0;
            AssignProp("", false, edtEnvironmentVariableId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEnvironmentVariableId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7EnvironmentVariableId) )
         {
            A632EnvironmentVariableId = AV7EnvironmentVariableId;
            AssignAttri("", false, "A632EnvironmentVariableId", A632EnvironmentVariableId.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A632EnvironmentVariableId) && ( Gx_BScreen == 0 ) )
            {
               A632EnvironmentVariableId = Guid.NewGuid( );
               AssignAttri("", false, "A632EnvironmentVariableId", A632EnvironmentVariableId.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1W107( )
      {
         /* Using cursor T001W4 */
         pr_default.execute(2, new Object[] {A632EnvironmentVariableId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound107 = 1;
            A633EnvironmentVariableKey = T001W4_A633EnvironmentVariableKey[0];
            AssignAttri("", false, "A633EnvironmentVariableKey", A633EnvironmentVariableKey);
            A634EnvironmentVariableValue = T001W4_A634EnvironmentVariableValue[0];
            AssignAttri("", false, "A634EnvironmentVariableValue", A634EnvironmentVariableValue);
            ZM1W107( -5) ;
         }
         pr_default.close(2);
         OnLoadActions1W107( ) ;
      }

      protected void OnLoadActions1W107( )
      {
      }

      protected void CheckExtendedTable1W107( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T001W5 */
         pr_default.execute(3, new Object[] {A633EnvironmentVariableKey, A632EnvironmentVariableId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Environment Variable Key", "")}), 1, "ENVIRONMENTVARIABLEKEY");
            AnyError = 1;
            GX_FocusControl = edtEnvironmentVariableKey_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors1W107( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1W107( )
      {
         /* Using cursor T001W6 */
         pr_default.execute(4, new Object[] {A632EnvironmentVariableId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound107 = 1;
         }
         else
         {
            RcdFound107 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001W3 */
         pr_default.execute(1, new Object[] {A632EnvironmentVariableId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1W107( 5) ;
            RcdFound107 = 1;
            A632EnvironmentVariableId = T001W3_A632EnvironmentVariableId[0];
            AssignAttri("", false, "A632EnvironmentVariableId", A632EnvironmentVariableId.ToString());
            A633EnvironmentVariableKey = T001W3_A633EnvironmentVariableKey[0];
            AssignAttri("", false, "A633EnvironmentVariableKey", A633EnvironmentVariableKey);
            A634EnvironmentVariableValue = T001W3_A634EnvironmentVariableValue[0];
            AssignAttri("", false, "A634EnvironmentVariableValue", A634EnvironmentVariableValue);
            Z632EnvironmentVariableId = A632EnvironmentVariableId;
            sMode107 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1W107( ) ;
            if ( AnyError == 1 )
            {
               RcdFound107 = 0;
               InitializeNonKey1W107( ) ;
            }
            Gx_mode = sMode107;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound107 = 0;
            InitializeNonKey1W107( ) ;
            sMode107 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode107;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1W107( ) ;
         if ( RcdFound107 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound107 = 0;
         /* Using cursor T001W7 */
         pr_default.execute(5, new Object[] {A632EnvironmentVariableId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T001W7_A632EnvironmentVariableId[0], A632EnvironmentVariableId, 0) < 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T001W7_A632EnvironmentVariableId[0], A632EnvironmentVariableId, 0) > 0 ) ) )
            {
               A632EnvironmentVariableId = T001W7_A632EnvironmentVariableId[0];
               AssignAttri("", false, "A632EnvironmentVariableId", A632EnvironmentVariableId.ToString());
               RcdFound107 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void move_previous( )
      {
         RcdFound107 = 0;
         /* Using cursor T001W8 */
         pr_default.execute(6, new Object[] {A632EnvironmentVariableId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T001W8_A632EnvironmentVariableId[0], A632EnvironmentVariableId, 0) > 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T001W8_A632EnvironmentVariableId[0], A632EnvironmentVariableId, 0) < 0 ) ) )
            {
               A632EnvironmentVariableId = T001W8_A632EnvironmentVariableId[0];
               AssignAttri("", false, "A632EnvironmentVariableId", A632EnvironmentVariableId.ToString());
               RcdFound107 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1W107( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtEnvironmentVariableKey_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1W107( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound107 == 1 )
            {
               if ( A632EnvironmentVariableId != Z632EnvironmentVariableId )
               {
                  A632EnvironmentVariableId = Z632EnvironmentVariableId;
                  AssignAttri("", false, "A632EnvironmentVariableId", A632EnvironmentVariableId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ENVIRONMENTVARIABLEID");
                  AnyError = 1;
                  GX_FocusControl = edtEnvironmentVariableId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtEnvironmentVariableKey_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1W107( ) ;
                  GX_FocusControl = edtEnvironmentVariableKey_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A632EnvironmentVariableId != Z632EnvironmentVariableId )
               {
                  /* Insert record */
                  GX_FocusControl = edtEnvironmentVariableKey_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1W107( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ENVIRONMENTVARIABLEID");
                     AnyError = 1;
                     GX_FocusControl = edtEnvironmentVariableId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtEnvironmentVariableKey_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1W107( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A632EnvironmentVariableId != Z632EnvironmentVariableId )
         {
            A632EnvironmentVariableId = Z632EnvironmentVariableId;
            AssignAttri("", false, "A632EnvironmentVariableId", A632EnvironmentVariableId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ENVIRONMENTVARIABLEID");
            AnyError = 1;
            GX_FocusControl = edtEnvironmentVariableId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtEnvironmentVariableKey_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1W107( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001W2 */
            pr_default.execute(0, new Object[] {A632EnvironmentVariableId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_EnvironmentVariable"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z633EnvironmentVariableKey, T001W2_A633EnvironmentVariableKey[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z633EnvironmentVariableKey, T001W2_A633EnvironmentVariableKey[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_environmentvariable:[seudo value changed for attri]"+"EnvironmentVariableKey");
                  GXUtil.WriteLogRaw("Old: ",Z633EnvironmentVariableKey);
                  GXUtil.WriteLogRaw("Current: ",T001W2_A633EnvironmentVariableKey[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_EnvironmentVariable"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1W107( )
      {
         if ( ! IsAuthorized("trn_environmentvariable_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1W107( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1W107( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1W107( 0) ;
            CheckOptimisticConcurrency1W107( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1W107( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1W107( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001W9 */
                     pr_default.execute(7, new Object[] {A632EnvironmentVariableId, A633EnvironmentVariableKey, A634EnvironmentVariableValue});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_EnvironmentVariable");
                     if ( (pr_default.getStatus(7) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load1W107( ) ;
            }
            EndLevel1W107( ) ;
         }
         CloseExtendedTableCursors1W107( ) ;
      }

      protected void Update1W107( )
      {
         if ( ! IsAuthorized("trn_environmentvariable_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1W107( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1W107( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1W107( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1W107( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1W107( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001W10 */
                     pr_default.execute(8, new Object[] {A633EnvironmentVariableKey, A634EnvironmentVariableValue, A632EnvironmentVariableId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_EnvironmentVariable");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_EnvironmentVariable"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1W107( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel1W107( ) ;
         }
         CloseExtendedTableCursors1W107( ) ;
      }

      protected void DeferredUpdate1W107( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_environmentvariable_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1W107( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1W107( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1W107( ) ;
            AfterConfirm1W107( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1W107( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001W11 */
                  pr_default.execute(9, new Object[] {A632EnvironmentVariableId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_EnvironmentVariable");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1;
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode107 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1W107( ) ;
         Gx_mode = sMode107;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1W107( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1W107( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1W107( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_environmentvariable",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1W0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_environmentvariable",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1W107( )
      {
         /* Scan By routine */
         /* Using cursor T001W12 */
         pr_default.execute(10);
         RcdFound107 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound107 = 1;
            A632EnvironmentVariableId = T001W12_A632EnvironmentVariableId[0];
            AssignAttri("", false, "A632EnvironmentVariableId", A632EnvironmentVariableId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1W107( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound107 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound107 = 1;
            A632EnvironmentVariableId = T001W12_A632EnvironmentVariableId[0];
            AssignAttri("", false, "A632EnvironmentVariableId", A632EnvironmentVariableId.ToString());
         }
      }

      protected void ScanEnd1W107( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm1W107( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1W107( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1W107( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1W107( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1W107( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1W107( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1W107( )
      {
         edtEnvironmentVariableKey_Enabled = 0;
         AssignProp("", false, edtEnvironmentVariableKey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEnvironmentVariableKey_Enabled), 5, 0), true);
         edtEnvironmentVariableValue_Enabled = 0;
         AssignProp("", false, edtEnvironmentVariableValue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEnvironmentVariableValue_Enabled), 5, 0), true);
         edtEnvironmentVariableId_Enabled = 0;
         AssignProp("", false, edtEnvironmentVariableId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEnvironmentVariableId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1W107( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1W0( )
      {
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
         MasterPageObj.master_styles();
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
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "trn_environmentvariable.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7EnvironmentVariableId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_environmentvariable.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_EnvironmentVariable");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_environmentvariable:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z632EnvironmentVariableId", Z632EnvironmentVariableId.ToString());
         GxWebStd.gx_hidden_field( context, "Z633EnvironmentVariableKey", Z633EnvironmentVariableKey);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV10TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV10TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV10TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vENVIRONMENTVARIABLEID", AV7EnvironmentVariableId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vENVIRONMENTVARIABLEID", GetSecureSignedToken( "", AV7EnvironmentVariableId, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "trn_environmentvariable.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7EnvironmentVariableId.ToString());
         return formatLink("trn_environmentvariable.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Trn_EnvironmentVariable" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Environment Variable", "") ;
      }

      protected void InitializeNonKey1W107( )
      {
         A633EnvironmentVariableKey = "";
         AssignAttri("", false, "A633EnvironmentVariableKey", A633EnvironmentVariableKey);
         A634EnvironmentVariableValue = "";
         AssignAttri("", false, "A634EnvironmentVariableValue", A634EnvironmentVariableValue);
         Z633EnvironmentVariableKey = "";
      }

      protected void InitAll1W107( )
      {
         A632EnvironmentVariableId = Guid.NewGuid( );
         AssignAttri("", false, "A632EnvironmentVariableId", A632EnvironmentVariableId.ToString());
         InitializeNonKey1W107( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256309434812", true, true);
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
         context.AddJavascriptSource("trn_environmentvariable.js", "?20256309434812", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtEnvironmentVariableKey_Internalname = "ENVIRONMENTVARIABLEKEY";
         edtEnvironmentVariableValue_Internalname = "ENVIRONMENTVARIABLEVALUE";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtEnvironmentVariableId_Internalname = "ENVIRONMENTVARIABLEID";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Trn_Environment Variable", "");
         edtEnvironmentVariableId_Jsonclick = "";
         edtEnvironmentVariableId_Enabled = 1;
         edtEnvironmentVariableId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtEnvironmentVariableValue_Enabled = 1;
         edtEnvironmentVariableKey_Enabled = 1;
         divLayoutmaintable_Class = "Table";
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Environmentvariablekey( )
      {
         /* Using cursor T001W13 */
         pr_default.execute(11, new Object[] {A633EnvironmentVariableKey, A632EnvironmentVariableId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Environment Variable Key", "")}), 1, "ENVIRONMENTVARIABLEKEY");
            AnyError = 1;
            GX_FocusControl = edtEnvironmentVariableKey_Internalname;
         }
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7EnvironmentVariableId","fld":"vENVIRONMENTVARIABLEID","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV10TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7EnvironmentVariableId","fld":"vENVIRONMENTVARIABLEID","hsh":true}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E121W2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV10TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_ENVIRONMENTVARIABLEKEY","""{"handler":"Valid_Environmentvariablekey","iparms":[{"av":"A633EnvironmentVariableKey","fld":"ENVIRONMENTVARIABLEKEY"},{"av":"A632EnvironmentVariableId","fld":"ENVIRONMENTVARIABLEID"}]}""");
         setEventMetadata("VALID_ENVIRONMENTVARIABLEID","""{"handler":"Valid_Environmentvariableid","iparms":[]}""");
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

      protected override void CloseCursors( )
      {
         pr_default.close(1);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7EnvironmentVariableId = Guid.Empty;
         Z632EnvironmentVariableId = Guid.Empty;
         Z633EnvironmentVariableKey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A633EnvironmentVariableKey = "";
         A634EnvironmentVariableValue = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A632EnvironmentVariableId = Guid.Empty;
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode107 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV10TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV11WebSession = context.GetSession();
         Z634EnvironmentVariableValue = "";
         T001W4_A632EnvironmentVariableId = new Guid[] {Guid.Empty} ;
         T001W4_A633EnvironmentVariableKey = new string[] {""} ;
         T001W4_A634EnvironmentVariableValue = new string[] {""} ;
         T001W5_A633EnvironmentVariableKey = new string[] {""} ;
         T001W6_A632EnvironmentVariableId = new Guid[] {Guid.Empty} ;
         T001W3_A632EnvironmentVariableId = new Guid[] {Guid.Empty} ;
         T001W3_A633EnvironmentVariableKey = new string[] {""} ;
         T001W3_A634EnvironmentVariableValue = new string[] {""} ;
         T001W7_A632EnvironmentVariableId = new Guid[] {Guid.Empty} ;
         T001W8_A632EnvironmentVariableId = new Guid[] {Guid.Empty} ;
         T001W2_A632EnvironmentVariableId = new Guid[] {Guid.Empty} ;
         T001W2_A633EnvironmentVariableKey = new string[] {""} ;
         T001W2_A634EnvironmentVariableValue = new string[] {""} ;
         T001W12_A632EnvironmentVariableId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T001W13_A633EnvironmentVariableKey = new string[] {""} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_environmentvariable__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_environmentvariable__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_environmentvariable__default(),
            new Object[][] {
                new Object[] {
               T001W2_A632EnvironmentVariableId, T001W2_A633EnvironmentVariableKey, T001W2_A634EnvironmentVariableValue
               }
               , new Object[] {
               T001W3_A632EnvironmentVariableId, T001W3_A633EnvironmentVariableKey, T001W3_A634EnvironmentVariableValue
               }
               , new Object[] {
               T001W4_A632EnvironmentVariableId, T001W4_A633EnvironmentVariableKey, T001W4_A634EnvironmentVariableValue
               }
               , new Object[] {
               T001W5_A633EnvironmentVariableKey
               }
               , new Object[] {
               T001W6_A632EnvironmentVariableId
               }
               , new Object[] {
               T001W7_A632EnvironmentVariableId
               }
               , new Object[] {
               T001W8_A632EnvironmentVariableId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001W12_A632EnvironmentVariableId
               }
               , new Object[] {
               T001W13_A633EnvironmentVariableKey
               }
            }
         );
         Z632EnvironmentVariableId = Guid.NewGuid( );
         A632EnvironmentVariableId = Guid.NewGuid( );
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound107 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtEnvironmentVariableKey_Enabled ;
      private int edtEnvironmentVariableValue_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtEnvironmentVariableId_Visible ;
      private int edtEnvironmentVariableId_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtEnvironmentVariableKey_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtEnvironmentVariableValue_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtEnvironmentVariableId_Internalname ;
      private string edtEnvironmentVariableId_Jsonclick ;
      private string hsh ;
      private string sMode107 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool returnInSub ;
      private string A634EnvironmentVariableValue ;
      private string Z634EnvironmentVariableValue ;
      private string Z633EnvironmentVariableKey ;
      private string A633EnvironmentVariableKey ;
      private Guid wcpOAV7EnvironmentVariableId ;
      private Guid Z632EnvironmentVariableId ;
      private Guid AV7EnvironmentVariableId ;
      private Guid A632EnvironmentVariableId ;
      private IGxSession AV11WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV10TrnContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] T001W4_A632EnvironmentVariableId ;
      private string[] T001W4_A633EnvironmentVariableKey ;
      private string[] T001W4_A634EnvironmentVariableValue ;
      private string[] T001W5_A633EnvironmentVariableKey ;
      private Guid[] T001W6_A632EnvironmentVariableId ;
      private Guid[] T001W3_A632EnvironmentVariableId ;
      private string[] T001W3_A633EnvironmentVariableKey ;
      private string[] T001W3_A634EnvironmentVariableValue ;
      private Guid[] T001W7_A632EnvironmentVariableId ;
      private Guid[] T001W8_A632EnvironmentVariableId ;
      private Guid[] T001W2_A632EnvironmentVariableId ;
      private string[] T001W2_A633EnvironmentVariableKey ;
      private string[] T001W2_A634EnvironmentVariableValue ;
      private Guid[] T001W12_A632EnvironmentVariableId ;
      private string[] T001W13_A633EnvironmentVariableKey ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_environmentvariable__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_environmentvariable__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_environmentvariable__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new ForEachCursor(def[2])
      ,new ForEachCursor(def[3])
      ,new ForEachCursor(def[4])
      ,new ForEachCursor(def[5])
      ,new ForEachCursor(def[6])
      ,new UpdateCursor(def[7])
      ,new UpdateCursor(def[8])
      ,new UpdateCursor(def[9])
      ,new ForEachCursor(def[10])
      ,new ForEachCursor(def[11])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT001W2;
       prmT001W2 = new Object[] {
       new ParDef("EnvironmentVariableId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001W3;
       prmT001W3 = new Object[] {
       new ParDef("EnvironmentVariableId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001W4;
       prmT001W4 = new Object[] {
       new ParDef("EnvironmentVariableId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001W5;
       prmT001W5 = new Object[] {
       new ParDef("EnvironmentVariableKey",GXType.VarChar,400,0) ,
       new ParDef("EnvironmentVariableId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001W6;
       prmT001W6 = new Object[] {
       new ParDef("EnvironmentVariableId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001W7;
       prmT001W7 = new Object[] {
       new ParDef("EnvironmentVariableId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001W8;
       prmT001W8 = new Object[] {
       new ParDef("EnvironmentVariableId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001W9;
       prmT001W9 = new Object[] {
       new ParDef("EnvironmentVariableId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("EnvironmentVariableKey",GXType.VarChar,400,0) ,
       new ParDef("EnvironmentVariableValue",GXType.LongVarChar,2097152,0)
       };
       Object[] prmT001W10;
       prmT001W10 = new Object[] {
       new ParDef("EnvironmentVariableKey",GXType.VarChar,400,0) ,
       new ParDef("EnvironmentVariableValue",GXType.LongVarChar,2097152,0) ,
       new ParDef("EnvironmentVariableId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001W11;
       prmT001W11 = new Object[] {
       new ParDef("EnvironmentVariableId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001W12;
       prmT001W12 = new Object[] {
       };
       Object[] prmT001W13;
       prmT001W13 = new Object[] {
       new ParDef("EnvironmentVariableKey",GXType.VarChar,400,0) ,
       new ParDef("EnvironmentVariableId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("T001W2", "SELECT EnvironmentVariableId, EnvironmentVariableKey, EnvironmentVariableValue FROM Trn_EnvironmentVariable WHERE EnvironmentVariableId = :EnvironmentVariableId  FOR UPDATE OF Trn_EnvironmentVariable NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001W2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001W3", "SELECT EnvironmentVariableId, EnvironmentVariableKey, EnvironmentVariableValue FROM Trn_EnvironmentVariable WHERE EnvironmentVariableId = :EnvironmentVariableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001W4", "SELECT TM1.EnvironmentVariableId, TM1.EnvironmentVariableKey, TM1.EnvironmentVariableValue FROM Trn_EnvironmentVariable TM1 WHERE TM1.EnvironmentVariableId = :EnvironmentVariableId ORDER BY TM1.EnvironmentVariableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001W5", "SELECT EnvironmentVariableKey FROM Trn_EnvironmentVariable WHERE (EnvironmentVariableKey = :EnvironmentVariableKey) AND (Not ( EnvironmentVariableId = :EnvironmentVariableId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001W6", "SELECT EnvironmentVariableId FROM Trn_EnvironmentVariable WHERE EnvironmentVariableId = :EnvironmentVariableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001W7", "SELECT EnvironmentVariableId FROM Trn_EnvironmentVariable WHERE ( EnvironmentVariableId > :EnvironmentVariableId) ORDER BY EnvironmentVariableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W7,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001W8", "SELECT EnvironmentVariableId FROM Trn_EnvironmentVariable WHERE ( EnvironmentVariableId < :EnvironmentVariableId) ORDER BY EnvironmentVariableId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W8,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001W9", "SAVEPOINT gxupdate;INSERT INTO Trn_EnvironmentVariable(EnvironmentVariableId, EnvironmentVariableKey, EnvironmentVariableValue) VALUES(:EnvironmentVariableId, :EnvironmentVariableKey, :EnvironmentVariableValue);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001W9)
          ,new CursorDef("T001W10", "SAVEPOINT gxupdate;UPDATE Trn_EnvironmentVariable SET EnvironmentVariableKey=:EnvironmentVariableKey, EnvironmentVariableValue=:EnvironmentVariableValue  WHERE EnvironmentVariableId = :EnvironmentVariableId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001W10)
          ,new CursorDef("T001W11", "SAVEPOINT gxupdate;DELETE FROM Trn_EnvironmentVariable  WHERE EnvironmentVariableId = :EnvironmentVariableId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001W11)
          ,new CursorDef("T001W12", "SELECT EnvironmentVariableId FROM Trn_EnvironmentVariable ORDER BY EnvironmentVariableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W12,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001W13", "SELECT EnvironmentVariableKey FROM Trn_EnvironmentVariable WHERE (EnvironmentVariableKey = :EnvironmentVariableKey) AND (Not ( EnvironmentVariableId = :EnvironmentVariableId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W13,1, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 6 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 10 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 11 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
    }
 }

}

}
