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
   public class trn_appversion : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel12"+"_"+"TRN_THEMEID") == 0 )
         {
            AV29Insert_Trn_ThemeId = StringUtil.StrToGuid( GetPar( "Insert_Trn_ThemeId"));
            AssignAttri("", false, "AV29Insert_Trn_ThemeId", AV29Insert_Trn_ThemeId.ToString());
            A273Trn_ThemeId = StringUtil.StrToGuid( GetPar( "Trn_ThemeId"));
            AssignAttri("", false, "A273Trn_ThemeId", A273Trn_ThemeId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX12ASATRN_THEMEID1L94( AV29Insert_Trn_ThemeId, A273Trn_ThemeId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_23") == 0 )
         {
            A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
            n29LocationId = false;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
            n11OrganisationId = false;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_23( A29LocationId, A11OrganisationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_22") == 0 )
         {
            A273Trn_ThemeId = StringUtil.StrToGuid( GetPar( "Trn_ThemeId"));
            AssignAttri("", false, "A273Trn_ThemeId", A273Trn_ThemeId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_22( A273Trn_ThemeId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_page") == 0 )
         {
            gxnrGridlevel_page_newrow_invoke( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_appversion.aspx")), "trn_appversion.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_appversion.aspx")))) ;
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
                  AV8AppVersionId = StringUtil.StrToGuid( GetPar( "AppVersionId"));
                  AssignAttri("", false, "AV8AppVersionId", AV8AppVersionId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vAPPVERSIONID", GetSecureSignedToken( "", AV8AppVersionId, context));
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
         Form.Meta.addItem("description", context.GetMessage( "Trn_App Version", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAppVersionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_page_newrow_invoke( )
      {
         nRC_GXsfl_47 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_47"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_47_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_47_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_47_idx = GetPar( "sGXsfl_47_idx");
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_page_newrow( ) ;
         /* End function gxnrGridlevel_page_newrow_invoke */
      }

      public trn_appversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_appversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_AppVersionId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV8AppVersionId = aP1_AppVersionId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkIsActive = new GXCheckbox();
         chkIsPredefined = new GXCheckbox();
         cmbPageType = new GXCombobox();
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
            return "trn_appversion_Execute" ;
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
         A535IsActive = StringUtil.StrToBool( StringUtil.BoolToStr( A535IsActive));
         AssignAttri("", false, "A535IsActive", A535IsActive);
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
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_AppVersion.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAppVersionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAppVersionId_Internalname, context.GetMessage( "Version Id", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAppVersionId_Internalname, A523AppVersionId.ToString(), A523AppVersionId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAppVersionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAppVersionId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_AppVersion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAppVersionName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAppVersionName_Internalname, context.GetMessage( "Version Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAppVersionName_Internalname, A524AppVersionName, StringUtil.RTrim( context.localUtil.Format( A524AppVersionName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAppVersionName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAppVersionName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_AppVersion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationId_Internalname, context.GetMessage( "Location Id", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationId_Internalname, A29LocationId.ToString(), A29LocationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_AppVersion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOrganisationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOrganisationId_Internalname, context.GetMessage( "Organisation Id", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationId_Internalname, A11OrganisationId.ToString(), A11OrganisationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrganisationId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_AppVersion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkIsActive_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkIsActive_Internalname, context.GetMessage( "Active", ""), "col-sm-4 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkIsActive_Internalname, StringUtil.BoolToStr( A535IsActive), "", context.GetMessage( "Active", ""), 1, chkIsActive.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(41, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,41);\"");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9 CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_page_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_page( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AppVersion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AppVersion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AppVersion.htm");
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

      protected void gxdraw_Gridlevel_page( )
      {
         /*  Grid Control  */
         StartGridControl47( ) ;
         nGXsfl_47_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount95 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_95 = 1;
               ScanStart1L95( ) ;
               while ( RcdFound95 != 0 )
               {
                  init_level_properties95( ) ;
                  getByPrimaryKey1L95( ) ;
                  AddRow1L95( ) ;
                  ScanNext1L95( ) ;
               }
               ScanEnd1L95( ) ;
               nBlankRcdCount95 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal1L95( ) ;
            standaloneModal1L95( ) ;
            sMode95 = Gx_mode;
            while ( nGXsfl_47_idx < nRC_GXsfl_47 )
            {
               bGXsfl_47_Refreshing = true;
               ReadRow1L95( ) ;
               edtPageId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAGEID_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageId_Enabled), 5, 0), !bGXsfl_47_Refreshing);
               edtPageName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAGENAME_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPageName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageName_Enabled), 5, 0), !bGXsfl_47_Refreshing);
               edtPageStructure_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAGESTRUCTURE_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPageStructure_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageStructure_Enabled), 5, 0), !bGXsfl_47_Refreshing);
               edtPagePublishedStructure_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAGEPUBLISHEDSTRUCTURE_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPagePublishedStructure_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagePublishedStructure_Enabled), 5, 0), !bGXsfl_47_Refreshing);
               chkIsPredefined.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ISPREDEFINED_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, chkIsPredefined_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkIsPredefined.Enabled), 5, 0), !bGXsfl_47_Refreshing);
               cmbPageType.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAGETYPE_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbPageType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPageType.Enabled), 5, 0), !bGXsfl_47_Refreshing);
               if ( ( nRcdExists_95 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal1L95( ) ;
               }
               SendRow1L95( ) ;
               bGXsfl_47_Refreshing = false;
            }
            Gx_mode = sMode95;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount95 = 5;
            nRcdExists_95 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart1L95( ) ;
               while ( RcdFound95 != 0 )
               {
                  sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_4795( ) ;
                  init_level_properties95( ) ;
                  standaloneNotModal1L95( ) ;
                  getByPrimaryKey1L95( ) ;
                  standaloneModal1L95( ) ;
                  AddRow1L95( ) ;
                  ScanNext1L95( ) ;
               }
               ScanEnd1L95( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode95 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx+1), 4, 0), 4, "0");
            SubsflControlProps_4795( ) ;
            InitAll1L95( ) ;
            init_level_properties95( ) ;
            nRcdExists_95 = 0;
            nIsMod_95 = 0;
            nRcdDeleted_95 = 0;
            nBlankRcdCount95 = (short)(nBlankRcdUsr95+nBlankRcdCount95);
            fRowAdded = 0;
            while ( nBlankRcdCount95 > 0 )
            {
               A516PageId = Guid.Empty;
               standaloneNotModal1L95( ) ;
               standaloneModal1L95( ) ;
               AddRow1L95( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtPageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount95 = (short)(nBlankRcdCount95-1);
            }
            Gx_mode = sMode95;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_pageContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_page", Gridlevel_pageContainer, subGridlevel_page_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_pageContainerData", Gridlevel_pageContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_pageContainerData"+"V", Gridlevel_pageContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_pageContainerData"+"V"+"\" value='"+Gridlevel_pageContainer.GridValuesHidden()+"'/>") ;
         }
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
         E111L2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z523AppVersionId = StringUtil.StrToGuid( cgiGet( "Z523AppVersionId"));
               Z524AppVersionName = cgiGet( "Z524AppVersionName");
               Z535IsActive = StringUtil.StrToBool( cgiGet( "Z535IsActive"));
               Z620IsVersionDeleted = StringUtil.StrToBool( cgiGet( "Z620IsVersionDeleted"));
               Z622VersionDeletedAt = context.localUtil.CToT( cgiGet( "Z622VersionDeletedAt"), 0);
               n622VersionDeletedAt = ((DateTime.MinValue==A622VersionDeletedAt) ? true : false);
               Z648AppVersionLanguage = cgiGet( "Z648AppVersionLanguage");
               Z11OrganisationId = StringUtil.StrToGuid( cgiGet( "Z11OrganisationId"));
               n11OrganisationId = ((Guid.Empty==A11OrganisationId) ? true : false);
               Z273Trn_ThemeId = StringUtil.StrToGuid( cgiGet( "Z273Trn_ThemeId"));
               Z29LocationId = StringUtil.StrToGuid( cgiGet( "Z29LocationId"));
               n29LocationId = ((Guid.Empty==A29LocationId) ? true : false);
               A620IsVersionDeleted = StringUtil.StrToBool( cgiGet( "Z620IsVersionDeleted"));
               A622VersionDeletedAt = context.localUtil.CToT( cgiGet( "Z622VersionDeletedAt"), 0);
               n622VersionDeletedAt = false;
               n622VersionDeletedAt = ((DateTime.MinValue==A622VersionDeletedAt) ? true : false);
               A648AppVersionLanguage = cgiGet( "Z648AppVersionLanguage");
               A273Trn_ThemeId = StringUtil.StrToGuid( cgiGet( "Z273Trn_ThemeId"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_47 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_47"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N29LocationId = StringUtil.StrToGuid( cgiGet( "N29LocationId"));
               n29LocationId = ((Guid.Empty==A29LocationId) ? true : false);
               N11OrganisationId = StringUtil.StrToGuid( cgiGet( "N11OrganisationId"));
               n11OrganisationId = ((Guid.Empty==A11OrganisationId) ? true : false);
               N273Trn_ThemeId = StringUtil.StrToGuid( cgiGet( "N273Trn_ThemeId"));
               AV8AppVersionId = StringUtil.StrToGuid( cgiGet( "vAPPVERSIONID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV14Insert_LocationId = StringUtil.StrToGuid( cgiGet( "vINSERT_LOCATIONID"));
               AV15Insert_OrganisationId = StringUtil.StrToGuid( cgiGet( "vINSERT_ORGANISATIONID"));
               AV29Insert_Trn_ThemeId = StringUtil.StrToGuid( cgiGet( "vINSERT_TRN_THEMEID"));
               A273Trn_ThemeId = StringUtil.StrToGuid( cgiGet( "TRN_THEMEID"));
               A620IsVersionDeleted = StringUtil.StrToBool( cgiGet( "ISVERSIONDELETED"));
               A622VersionDeletedAt = context.localUtil.CToT( cgiGet( "VERSIONDELETEDAT"), 0);
               n622VersionDeletedAt = ((DateTime.MinValue==A622VersionDeletedAt) ? true : false);
               A648AppVersionLanguage = cgiGet( "APPVERSIONLANGUAGE");
               AV31Pgmname = cgiGet( "vPGMNAME");
               A600PageThumbnail = cgiGet( "PAGETHUMBNAIL");
               n600PageThumbnail = false;
               n600PageThumbnail = (String.IsNullOrEmpty(StringUtil.RTrim( A600PageThumbnail)) ? true : false);
               A40000PageThumbnail_GXI = cgiGet( "PAGETHUMBNAIL_GXI");
               n40000PageThumbnail_GXI = false;
               n40000PageThumbnail_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000PageThumbnail_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A600PageThumbnail)) ? true : false);
               A621IsPageDeleted = StringUtil.StrToBool( cgiGet( "ISPAGEDELETED"));
               A623PageDeletedAt = context.localUtil.CToT( cgiGet( "PAGEDELETEDAT"), 0);
               n623PageDeletedAt = false;
               n623PageDeletedAt = ((DateTime.MinValue==A623PageDeletedAt) ? true : false);
               /* Read variables values. */
               if ( StringUtil.StrCmp(cgiGet( edtAppVersionId_Internalname), "") == 0 )
               {
                  A523AppVersionId = Guid.Empty;
                  AssignAttri("", false, "A523AppVersionId", A523AppVersionId.ToString());
               }
               else
               {
                  try
                  {
                     A523AppVersionId = StringUtil.StrToGuid( cgiGet( edtAppVersionId_Internalname));
                     AssignAttri("", false, "A523AppVersionId", A523AppVersionId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "APPVERSIONID");
                     AnyError = 1;
                     GX_FocusControl = edtAppVersionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               A524AppVersionName = cgiGet( edtAppVersionName_Internalname);
               AssignAttri("", false, "A524AppVersionName", A524AppVersionName);
               if ( StringUtil.StrCmp(cgiGet( edtLocationId_Internalname), "") == 0 )
               {
                  A29LocationId = Guid.Empty;
                  n29LocationId = false;
                  AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
               }
               else
               {
                  try
                  {
                     A29LocationId = StringUtil.StrToGuid( cgiGet( edtLocationId_Internalname));
                     n29LocationId = false;
                     AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "LOCATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtLocationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               n29LocationId = ((Guid.Empty==A29LocationId) ? true : false);
               if ( StringUtil.StrCmp(cgiGet( edtOrganisationId_Internalname), "") == 0 )
               {
                  A11OrganisationId = Guid.Empty;
                  n11OrganisationId = false;
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               }
               else
               {
                  try
                  {
                     A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
                     n11OrganisationId = false;
                     AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "ORGANISATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtOrganisationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               n11OrganisationId = ((Guid.Empty==A11OrganisationId) ? true : false);
               A535IsActive = StringUtil.StrToBool( cgiGet( chkIsActive_Internalname));
               AssignAttri("", false, "A535IsActive", A535IsActive);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_AppVersion");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("IsVersionDeleted", StringUtil.BoolToStr( A620IsVersionDeleted));
               forbiddenHiddens.Add("VersionDeletedAt", context.localUtil.Format( A622VersionDeletedAt, "99/99/99 99:99"));
               forbiddenHiddens.Add("AppVersionLanguage", StringUtil.RTrim( context.localUtil.Format( A648AppVersionLanguage, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A523AppVersionId != Z523AppVersionId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_appversion:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A523AppVersionId = StringUtil.StrToGuid( GetPar( "AppVersionId"));
                  AssignAttri("", false, "A523AppVersionId", A523AppVersionId.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV8AppVersionId) )
                  {
                     A523AppVersionId = AV8AppVersionId;
                     AssignAttri("", false, "A523AppVersionId", A523AppVersionId.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A523AppVersionId) && ( Gx_BScreen == 0 ) )
                     {
                        A523AppVersionId = Guid.NewGuid( );
                        AssignAttri("", false, "A523AppVersionId", A523AppVersionId.ToString());
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
                     sMode94 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV8AppVersionId) )
                     {
                        A523AppVersionId = AV8AppVersionId;
                        AssignAttri("", false, "A523AppVersionId", A523AppVersionId.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A523AppVersionId) && ( Gx_BScreen == 0 ) )
                        {
                           A523AppVersionId = Guid.NewGuid( );
                           AssignAttri("", false, "A523AppVersionId", A523AppVersionId.ToString());
                        }
                     }
                     Gx_mode = sMode94;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound94 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1L0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "APPVERSIONID");
                        AnyError = 1;
                        GX_FocusControl = edtAppVersionId_Internalname;
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
                           E111L2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121L2 ();
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
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
            E121L2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1L94( ) ;
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
            DisableAttributes1L94( ) ;
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

      protected void CONFIRM_1L0( )
      {
         BeforeValidate1L94( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1L94( ) ;
            }
            else
            {
               CheckExtendedTable1L94( ) ;
               CloseExtendedTableCursors1L94( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode94 = Gx_mode;
            CONFIRM_1L95( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode94;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode94;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_1L95( )
      {
         nGXsfl_47_idx = 0;
         while ( nGXsfl_47_idx < nRC_GXsfl_47 )
         {
            ReadRow1L95( ) ;
            if ( ( nRcdExists_95 != 0 ) || ( nIsMod_95 != 0 ) )
            {
               GetKey1L95( ) ;
               if ( ( nRcdExists_95 == 0 ) && ( nRcdDeleted_95 == 0 ) )
               {
                  if ( RcdFound95 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate1L95( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1L95( ) ;
                        CloseExtendedTableCursors1L95( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "PAGEID_" + sGXsfl_47_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtPageId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound95 != 0 )
                  {
                     if ( nRcdDeleted_95 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey1L95( ) ;
                        Load1L95( ) ;
                        BeforeValidate1L95( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1L95( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_95 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate1L95( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1L95( ) ;
                              CloseExtendedTableCursors1L95( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_95 == 0 )
                     {
                        GXCCtl = "PAGEID_" + sGXsfl_47_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtPageId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtPageId_Internalname, A516PageId.ToString()) ;
            ChangePostValue( edtPageName_Internalname, A517PageName) ;
            ChangePostValue( edtPageStructure_Internalname, A518PageStructure) ;
            ChangePostValue( edtPagePublishedStructure_Internalname, A536PagePublishedStructure) ;
            ChangePostValue( chkIsPredefined_Internalname, StringUtil.BoolToStr( A541IsPredefined)) ;
            ChangePostValue( cmbPageType_Internalname, A525PageType) ;
            ChangePostValue( "ZT_"+"Z516PageId_"+sGXsfl_47_idx, Z516PageId.ToString()) ;
            ChangePostValue( "ZT_"+"Z541IsPredefined_"+sGXsfl_47_idx, StringUtil.BoolToStr( Z541IsPredefined)) ;
            ChangePostValue( "ZT_"+"Z517PageName_"+sGXsfl_47_idx, Z517PageName) ;
            ChangePostValue( "ZT_"+"Z525PageType_"+sGXsfl_47_idx, Z525PageType) ;
            ChangePostValue( "ZT_"+"Z621IsPageDeleted_"+sGXsfl_47_idx, StringUtil.BoolToStr( Z621IsPageDeleted)) ;
            ChangePostValue( "ZT_"+"Z623PageDeletedAt_"+sGXsfl_47_idx, context.localUtil.TToC( Z623PageDeletedAt, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "nRcdDeleted_95_"+sGXsfl_47_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_95), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_95_"+sGXsfl_47_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_95), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_95_"+sGXsfl_47_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_95), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_95 != 0 )
            {
               ChangePostValue( "PAGEID_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAGENAME_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAGESTRUCTURE_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageStructure_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAGEPUBLISHEDSTRUCTURE_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPagePublishedStructure_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ISPREDEFINED_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkIsPredefined.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAGETYPE_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbPageType.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption1L0( )
      {
      }

      protected void E111L2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV12TrnContext.gxTpr_Transactionname, AV31Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV32GXV1 = 1;
            AssignAttri("", false, "AV32GXV1", StringUtil.LTrimStr( (decimal)(AV32GXV1), 8, 0));
            while ( AV32GXV1 <= AV12TrnContext.gxTpr_Attributes.Count )
            {
               AV16TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV12TrnContext.gxTpr_Attributes.Item(AV32GXV1));
               if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "LocationId") == 0 )
               {
                  AV14Insert_LocationId = StringUtil.StrToGuid( AV16TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV14Insert_LocationId", AV14Insert_LocationId.ToString());
               }
               else if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "OrganisationId") == 0 )
               {
                  AV15Insert_OrganisationId = StringUtil.StrToGuid( AV16TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV15Insert_OrganisationId", AV15Insert_OrganisationId.ToString());
               }
               else if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "Trn_ThemeId") == 0 )
               {
                  AV29Insert_Trn_ThemeId = StringUtil.StrToGuid( AV16TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV29Insert_Trn_ThemeId", AV29Insert_Trn_ThemeId.ToString());
               }
               AV32GXV1 = (int)(AV32GXV1+1);
               AssignAttri("", false, "AV32GXV1", StringUtil.LTrimStr( (decimal)(AV32GXV1), 8, 0));
            }
         }
      }

      protected void E121L2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV12TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("trn_appversionww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1L94( short GX_JID )
      {
         if ( ( GX_JID == 21 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z524AppVersionName = T001L5_A524AppVersionName[0];
               Z535IsActive = T001L5_A535IsActive[0];
               Z620IsVersionDeleted = T001L5_A620IsVersionDeleted[0];
               Z622VersionDeletedAt = T001L5_A622VersionDeletedAt[0];
               Z648AppVersionLanguage = T001L5_A648AppVersionLanguage[0];
               Z11OrganisationId = T001L5_A11OrganisationId[0];
               Z273Trn_ThemeId = T001L5_A273Trn_ThemeId[0];
               Z29LocationId = T001L5_A29LocationId[0];
            }
            else
            {
               Z524AppVersionName = A524AppVersionName;
               Z535IsActive = A535IsActive;
               Z620IsVersionDeleted = A620IsVersionDeleted;
               Z622VersionDeletedAt = A622VersionDeletedAt;
               Z648AppVersionLanguage = A648AppVersionLanguage;
               Z11OrganisationId = A11OrganisationId;
               Z273Trn_ThemeId = A273Trn_ThemeId;
               Z29LocationId = A29LocationId;
            }
         }
         if ( GX_JID == -21 )
         {
            Z523AppVersionId = A523AppVersionId;
            Z524AppVersionName = A524AppVersionName;
            Z535IsActive = A535IsActive;
            Z620IsVersionDeleted = A620IsVersionDeleted;
            Z622VersionDeletedAt = A622VersionDeletedAt;
            Z648AppVersionLanguage = A648AppVersionLanguage;
            Z11OrganisationId = A11OrganisationId;
            Z273Trn_ThemeId = A273Trn_ThemeId;
            Z29LocationId = A29LocationId;
         }
      }

      protected void standaloneNotModal( )
      {
         AV31Pgmname = "Trn_AppVersion";
         AssignAttri("", false, "AV31Pgmname", AV31Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV8AppVersionId) )
         {
            edtAppVersionId_Enabled = 0;
            AssignProp("", false, edtAppVersionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAppVersionId_Enabled), 5, 0), true);
         }
         else
         {
            edtAppVersionId_Enabled = 1;
            AssignProp("", false, edtAppVersionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAppVersionId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV8AppVersionId) )
         {
            edtAppVersionId_Enabled = 0;
            AssignProp("", false, edtAppVersionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAppVersionId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV14Insert_LocationId) )
         {
            edtLocationId_Enabled = 0;
            AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         }
         else
         {
            edtLocationId_Enabled = 1;
            AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV15Insert_OrganisationId) )
         {
            edtOrganisationId_Enabled = 0;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
         else
         {
            edtOrganisationId_Enabled = 1;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV15Insert_OrganisationId) )
         {
            A11OrganisationId = AV15Insert_OrganisationId;
            n11OrganisationId = false;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV14Insert_LocationId) )
         {
            A29LocationId = AV14Insert_LocationId;
            n29LocationId = false;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         }
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
         if ( ! (Guid.Empty==AV8AppVersionId) )
         {
            A523AppVersionId = AV8AppVersionId;
            AssignAttri("", false, "A523AppVersionId", A523AppVersionId.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A523AppVersionId) && ( Gx_BScreen == 0 ) )
            {
               A523AppVersionId = Guid.NewGuid( );
               AssignAttri("", false, "A523AppVersionId", A523AppVersionId.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1L94( )
      {
         /* Using cursor T001L8 */
         pr_default.execute(6, new Object[] {A523AppVersionId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound94 = 1;
            A524AppVersionName = T001L8_A524AppVersionName[0];
            AssignAttri("", false, "A524AppVersionName", A524AppVersionName);
            A535IsActive = T001L8_A535IsActive[0];
            AssignAttri("", false, "A535IsActive", A535IsActive);
            A620IsVersionDeleted = T001L8_A620IsVersionDeleted[0];
            A622VersionDeletedAt = T001L8_A622VersionDeletedAt[0];
            n622VersionDeletedAt = T001L8_n622VersionDeletedAt[0];
            A648AppVersionLanguage = T001L8_A648AppVersionLanguage[0];
            A11OrganisationId = T001L8_A11OrganisationId[0];
            n11OrganisationId = T001L8_n11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A273Trn_ThemeId = T001L8_A273Trn_ThemeId[0];
            A29LocationId = T001L8_A29LocationId[0];
            n29LocationId = T001L8_n29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            ZM1L94( -21) ;
         }
         pr_default.close(6);
         OnLoadActions1L94( ) ;
      }

      protected void OnLoadActions1L94( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV29Insert_Trn_ThemeId) )
         {
            A273Trn_ThemeId = AV29Insert_Trn_ThemeId;
            AssignAttri("", false, "A273Trn_ThemeId", A273Trn_ThemeId.ToString());
         }
         else
         {
            if ( (Guid.Empty==A273Trn_ThemeId) )
            {
               GXt_guid1 = A273Trn_ThemeId;
               new prc_getdefaulttheme(context ).execute( out  GXt_guid1) ;
               A273Trn_ThemeId = GXt_guid1;
               AssignAttri("", false, "A273Trn_ThemeId", A273Trn_ThemeId.ToString());
            }
         }
      }

      protected void CheckExtendedTable1L94( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV29Insert_Trn_ThemeId) )
         {
            A273Trn_ThemeId = AV29Insert_Trn_ThemeId;
            AssignAttri("", false, "A273Trn_ThemeId", A273Trn_ThemeId.ToString());
         }
         else
         {
            if ( (Guid.Empty==A273Trn_ThemeId) )
            {
               GXt_guid1 = A273Trn_ThemeId;
               new prc_getdefaulttheme(context ).execute( out  GXt_guid1) ;
               A273Trn_ThemeId = GXt_guid1;
               AssignAttri("", false, "A273Trn_ThemeId", A273Trn_ThemeId.ToString());
            }
         }
         /* Using cursor T001L7 */
         pr_default.execute(5, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (Guid.Empty==A29LocationId) || (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
               GX_FocusControl = edtLocationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(5);
         /* Using cursor T001L6 */
         pr_default.execute(4, new Object[] {A273Trn_ThemeId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), "", "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TRN_THEMEID");
            AnyError = 1;
         }
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors1L94( )
      {
         pr_default.close(5);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_23( Guid A29LocationId ,
                                Guid A11OrganisationId )
      {
         /* Using cursor T001L9 */
         pr_default.execute(7, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (Guid.Empty==A29LocationId) || (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
               GX_FocusControl = edtLocationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_22( Guid A273Trn_ThemeId )
      {
         /* Using cursor T001L10 */
         pr_default.execute(8, new Object[] {A273Trn_ThemeId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), "", "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TRN_THEMEID");
            AnyError = 1;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey1L94( )
      {
         /* Using cursor T001L11 */
         pr_default.execute(9, new Object[] {A523AppVersionId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound94 = 1;
         }
         else
         {
            RcdFound94 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001L5 */
         pr_default.execute(3, new Object[] {A523AppVersionId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM1L94( 21) ;
            RcdFound94 = 1;
            A523AppVersionId = T001L5_A523AppVersionId[0];
            AssignAttri("", false, "A523AppVersionId", A523AppVersionId.ToString());
            A524AppVersionName = T001L5_A524AppVersionName[0];
            AssignAttri("", false, "A524AppVersionName", A524AppVersionName);
            A535IsActive = T001L5_A535IsActive[0];
            AssignAttri("", false, "A535IsActive", A535IsActive);
            A620IsVersionDeleted = T001L5_A620IsVersionDeleted[0];
            A622VersionDeletedAt = T001L5_A622VersionDeletedAt[0];
            n622VersionDeletedAt = T001L5_n622VersionDeletedAt[0];
            A648AppVersionLanguage = T001L5_A648AppVersionLanguage[0];
            A11OrganisationId = T001L5_A11OrganisationId[0];
            n11OrganisationId = T001L5_n11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A273Trn_ThemeId = T001L5_A273Trn_ThemeId[0];
            A29LocationId = T001L5_A29LocationId[0];
            n29LocationId = T001L5_n29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            Z523AppVersionId = A523AppVersionId;
            sMode94 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1L94( ) ;
            if ( AnyError == 1 )
            {
               RcdFound94 = 0;
               InitializeNonKey1L94( ) ;
            }
            Gx_mode = sMode94;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound94 = 0;
            InitializeNonKey1L94( ) ;
            sMode94 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode94;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey1L94( ) ;
         if ( RcdFound94 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound94 = 0;
         /* Using cursor T001L12 */
         pr_default.execute(10, new Object[] {A523AppVersionId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( GuidUtil.Compare(T001L12_A523AppVersionId[0], A523AppVersionId, 0) < 0 ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( GuidUtil.Compare(T001L12_A523AppVersionId[0], A523AppVersionId, 0) > 0 ) ) )
            {
               A523AppVersionId = T001L12_A523AppVersionId[0];
               AssignAttri("", false, "A523AppVersionId", A523AppVersionId.ToString());
               RcdFound94 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound94 = 0;
         /* Using cursor T001L13 */
         pr_default.execute(11, new Object[] {A523AppVersionId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( GuidUtil.Compare(T001L13_A523AppVersionId[0], A523AppVersionId, 0) > 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( GuidUtil.Compare(T001L13_A523AppVersionId[0], A523AppVersionId, 0) < 0 ) ) )
            {
               A523AppVersionId = T001L13_A523AppVersionId[0];
               AssignAttri("", false, "A523AppVersionId", A523AppVersionId.ToString());
               RcdFound94 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1L94( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAppVersionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1L94( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound94 == 1 )
            {
               if ( A523AppVersionId != Z523AppVersionId )
               {
                  A523AppVersionId = Z523AppVersionId;
                  AssignAttri("", false, "A523AppVersionId", A523AppVersionId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "APPVERSIONID");
                  AnyError = 1;
                  GX_FocusControl = edtAppVersionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAppVersionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1L94( ) ;
                  GX_FocusControl = edtAppVersionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A523AppVersionId != Z523AppVersionId )
               {
                  /* Insert record */
                  GX_FocusControl = edtAppVersionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1L94( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "APPVERSIONID");
                     AnyError = 1;
                     GX_FocusControl = edtAppVersionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtAppVersionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1L94( ) ;
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
         if ( A523AppVersionId != Z523AppVersionId )
         {
            A523AppVersionId = Z523AppVersionId;
            AssignAttri("", false, "A523AppVersionId", A523AppVersionId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "APPVERSIONID");
            AnyError = 1;
            GX_FocusControl = edtAppVersionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAppVersionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1L94( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001L4 */
            pr_default.execute(2, new Object[] {A523AppVersionId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AppVersion"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z524AppVersionName, T001L4_A524AppVersionName[0]) != 0 ) || ( Z535IsActive != T001L4_A535IsActive[0] ) || ( Z620IsVersionDeleted != T001L4_A620IsVersionDeleted[0] ) || ( Z622VersionDeletedAt != T001L4_A622VersionDeletedAt[0] ) || ( StringUtil.StrCmp(Z648AppVersionLanguage, T001L4_A648AppVersionLanguage[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z11OrganisationId != T001L4_A11OrganisationId[0] ) || ( Z273Trn_ThemeId != T001L4_A273Trn_ThemeId[0] ) || ( Z29LocationId != T001L4_A29LocationId[0] ) )
            {
               if ( StringUtil.StrCmp(Z524AppVersionName, T001L4_A524AppVersionName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_appversion:[seudo value changed for attri]"+"AppVersionName");
                  GXUtil.WriteLogRaw("Old: ",Z524AppVersionName);
                  GXUtil.WriteLogRaw("Current: ",T001L4_A524AppVersionName[0]);
               }
               if ( Z535IsActive != T001L4_A535IsActive[0] )
               {
                  GXUtil.WriteLog("trn_appversion:[seudo value changed for attri]"+"IsActive");
                  GXUtil.WriteLogRaw("Old: ",Z535IsActive);
                  GXUtil.WriteLogRaw("Current: ",T001L4_A535IsActive[0]);
               }
               if ( Z620IsVersionDeleted != T001L4_A620IsVersionDeleted[0] )
               {
                  GXUtil.WriteLog("trn_appversion:[seudo value changed for attri]"+"IsVersionDeleted");
                  GXUtil.WriteLogRaw("Old: ",Z620IsVersionDeleted);
                  GXUtil.WriteLogRaw("Current: ",T001L4_A620IsVersionDeleted[0]);
               }
               if ( Z622VersionDeletedAt != T001L4_A622VersionDeletedAt[0] )
               {
                  GXUtil.WriteLog("trn_appversion:[seudo value changed for attri]"+"VersionDeletedAt");
                  GXUtil.WriteLogRaw("Old: ",Z622VersionDeletedAt);
                  GXUtil.WriteLogRaw("Current: ",T001L4_A622VersionDeletedAt[0]);
               }
               if ( StringUtil.StrCmp(Z648AppVersionLanguage, T001L4_A648AppVersionLanguage[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_appversion:[seudo value changed for attri]"+"AppVersionLanguage");
                  GXUtil.WriteLogRaw("Old: ",Z648AppVersionLanguage);
                  GXUtil.WriteLogRaw("Current: ",T001L4_A648AppVersionLanguage[0]);
               }
               if ( Z11OrganisationId != T001L4_A11OrganisationId[0] )
               {
                  GXUtil.WriteLog("trn_appversion:[seudo value changed for attri]"+"OrganisationId");
                  GXUtil.WriteLogRaw("Old: ",Z11OrganisationId);
                  GXUtil.WriteLogRaw("Current: ",T001L4_A11OrganisationId[0]);
               }
               if ( Z273Trn_ThemeId != T001L4_A273Trn_ThemeId[0] )
               {
                  GXUtil.WriteLog("trn_appversion:[seudo value changed for attri]"+"Trn_ThemeId");
                  GXUtil.WriteLogRaw("Old: ",Z273Trn_ThemeId);
                  GXUtil.WriteLogRaw("Current: ",T001L4_A273Trn_ThemeId[0]);
               }
               if ( Z29LocationId != T001L4_A29LocationId[0] )
               {
                  GXUtil.WriteLog("trn_appversion:[seudo value changed for attri]"+"LocationId");
                  GXUtil.WriteLogRaw("Old: ",Z29LocationId);
                  GXUtil.WriteLogRaw("Current: ",T001L4_A29LocationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_AppVersion"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1L94( )
      {
         if ( ! IsAuthorized("trn_appversion_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1L94( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1L94( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1L94( 0) ;
            CheckOptimisticConcurrency1L94( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1L94( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1L94( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001L14 */
                     pr_default.execute(12, new Object[] {A523AppVersionId, A524AppVersionName, A535IsActive, A620IsVersionDeleted, n622VersionDeletedAt, A622VersionDeletedAt, A648AppVersionLanguage, n11OrganisationId, A11OrganisationId, A273Trn_ThemeId, n29LocationId, A29LocationId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersion");
                     if ( (pr_default.getStatus(12) == 1) )
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
                           ProcessLevel1L94( ) ;
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
               Load1L94( ) ;
            }
            EndLevel1L94( ) ;
         }
         CloseExtendedTableCursors1L94( ) ;
      }

      protected void Update1L94( )
      {
         if ( ! IsAuthorized("trn_appversion_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1L94( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1L94( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1L94( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1L94( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1L94( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001L15 */
                     pr_default.execute(13, new Object[] {A524AppVersionName, A535IsActive, A620IsVersionDeleted, n622VersionDeletedAt, A622VersionDeletedAt, A648AppVersionLanguage, n11OrganisationId, A11OrganisationId, A273Trn_ThemeId, n29LocationId, A29LocationId, A523AppVersionId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersion");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AppVersion"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1L94( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1L94( ) ;
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
            }
            EndLevel1L94( ) ;
         }
         CloseExtendedTableCursors1L94( ) ;
      }

      protected void DeferredUpdate1L94( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_appversion_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1L94( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1L94( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1L94( ) ;
            AfterConfirm1L94( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1L94( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart1L95( ) ;
                  while ( RcdFound95 != 0 )
                  {
                     getByPrimaryKey1L95( ) ;
                     Delete1L95( ) ;
                     ScanNext1L95( ) ;
                  }
                  ScanEnd1L95( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001L16 */
                     pr_default.execute(14, new Object[] {A523AppVersionId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersion");
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
         }
         sMode94 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1L94( ) ;
         Gx_mode = sMode94;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1L94( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T001L17 */
            pr_default.execute(15, new Object[] {A523AppVersionId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Locations", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T001L18 */
            pr_default.execute(16, new Object[] {A523AppVersionId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Locations", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
         }
      }

      protected void ProcessNestedLevel1L95( )
      {
         nGXsfl_47_idx = 0;
         while ( nGXsfl_47_idx < nRC_GXsfl_47 )
         {
            ReadRow1L95( ) ;
            if ( ( nRcdExists_95 != 0 ) || ( nIsMod_95 != 0 ) )
            {
               standaloneNotModal1L95( ) ;
               GetKey1L95( ) ;
               if ( ( nRcdExists_95 == 0 ) && ( nRcdDeleted_95 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert1L95( ) ;
               }
               else
               {
                  if ( RcdFound95 != 0 )
                  {
                     if ( ( nRcdDeleted_95 != 0 ) && ( nRcdExists_95 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete1L95( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_95 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update1L95( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_95 == 0 )
                     {
                        GXCCtl = "PAGEID_" + sGXsfl_47_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtPageId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtPageId_Internalname, A516PageId.ToString()) ;
            ChangePostValue( edtPageName_Internalname, A517PageName) ;
            ChangePostValue( edtPageStructure_Internalname, A518PageStructure) ;
            ChangePostValue( edtPagePublishedStructure_Internalname, A536PagePublishedStructure) ;
            ChangePostValue( chkIsPredefined_Internalname, StringUtil.BoolToStr( A541IsPredefined)) ;
            ChangePostValue( cmbPageType_Internalname, A525PageType) ;
            ChangePostValue( "ZT_"+"Z516PageId_"+sGXsfl_47_idx, Z516PageId.ToString()) ;
            ChangePostValue( "ZT_"+"Z541IsPredefined_"+sGXsfl_47_idx, StringUtil.BoolToStr( Z541IsPredefined)) ;
            ChangePostValue( "ZT_"+"Z517PageName_"+sGXsfl_47_idx, Z517PageName) ;
            ChangePostValue( "ZT_"+"Z525PageType_"+sGXsfl_47_idx, Z525PageType) ;
            ChangePostValue( "ZT_"+"Z621IsPageDeleted_"+sGXsfl_47_idx, StringUtil.BoolToStr( Z621IsPageDeleted)) ;
            ChangePostValue( "ZT_"+"Z623PageDeletedAt_"+sGXsfl_47_idx, context.localUtil.TToC( Z623PageDeletedAt, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "nRcdDeleted_95_"+sGXsfl_47_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_95), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_95_"+sGXsfl_47_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_95), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_95_"+sGXsfl_47_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_95), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_95 != 0 )
            {
               ChangePostValue( "PAGEID_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAGENAME_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAGESTRUCTURE_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageStructure_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAGEPUBLISHEDSTRUCTURE_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPagePublishedStructure_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ISPREDEFINED_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkIsPredefined.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAGETYPE_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbPageType.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1L95( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_95 = 0;
         nIsMod_95 = 0;
         nRcdDeleted_95 = 0;
      }

      protected void ProcessLevel1L94( )
      {
         /* Save parent mode. */
         sMode94 = Gx_mode;
         ProcessNestedLevel1L95( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode94;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel1L94( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1L94( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_appversion",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1L0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_appversion",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1L94( )
      {
         /* Scan By routine */
         /* Using cursor T001L19 */
         pr_default.execute(17);
         RcdFound94 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound94 = 1;
            A523AppVersionId = T001L19_A523AppVersionId[0];
            AssignAttri("", false, "A523AppVersionId", A523AppVersionId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1L94( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound94 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound94 = 1;
            A523AppVersionId = T001L19_A523AppVersionId[0];
            AssignAttri("", false, "A523AppVersionId", A523AppVersionId.ToString());
         }
      }

      protected void ScanEnd1L94( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm1L94( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1L94( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1L94( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1L94( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1L94( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1L94( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1L94( )
      {
         edtAppVersionId_Enabled = 0;
         AssignProp("", false, edtAppVersionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAppVersionId_Enabled), 5, 0), true);
         edtAppVersionName_Enabled = 0;
         AssignProp("", false, edtAppVersionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAppVersionName_Enabled), 5, 0), true);
         edtLocationId_Enabled = 0;
         AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         edtOrganisationId_Enabled = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         chkIsActive.Enabled = 0;
         AssignProp("", false, chkIsActive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkIsActive.Enabled), 5, 0), true);
      }

      protected void ZM1L95( short GX_JID )
      {
         if ( ( GX_JID == 24 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z541IsPredefined = T001L3_A541IsPredefined[0];
               Z517PageName = T001L3_A517PageName[0];
               Z525PageType = T001L3_A525PageType[0];
               Z621IsPageDeleted = T001L3_A621IsPageDeleted[0];
               Z623PageDeletedAt = T001L3_A623PageDeletedAt[0];
            }
            else
            {
               Z541IsPredefined = A541IsPredefined;
               Z517PageName = A517PageName;
               Z525PageType = A525PageType;
               Z621IsPageDeleted = A621IsPageDeleted;
               Z623PageDeletedAt = A623PageDeletedAt;
            }
         }
         if ( GX_JID == -24 )
         {
            Z523AppVersionId = A523AppVersionId;
            Z516PageId = A516PageId;
            Z541IsPredefined = A541IsPredefined;
            Z517PageName = A517PageName;
            Z518PageStructure = A518PageStructure;
            Z536PagePublishedStructure = A536PagePublishedStructure;
            Z600PageThumbnail = A600PageThumbnail;
            Z40000PageThumbnail_GXI = A40000PageThumbnail_GXI;
            Z525PageType = A525PageType;
            Z621IsPageDeleted = A621IsPageDeleted;
            Z623PageDeletedAt = A623PageDeletedAt;
         }
      }

      protected void standaloneNotModal1L95( )
      {
      }

      protected void standaloneModal1L95( )
      {
         if ( IsIns( )  && (Guid.Empty==A516PageId) && ( Gx_BScreen == 0 ) )
         {
            A516PageId = Guid.NewGuid( );
         }
         if ( IsIns( )  && (false==A541IsPredefined) && ( Gx_BScreen == 0 ) )
         {
            A541IsPredefined = false;
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtPageId_Enabled = 0;
            AssignProp("", false, edtPageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageId_Enabled), 5, 0), !bGXsfl_47_Refreshing);
         }
         else
         {
            edtPageId_Enabled = 1;
            AssignProp("", false, edtPageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageId_Enabled), 5, 0), !bGXsfl_47_Refreshing);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1L95( )
      {
         /* Using cursor T001L20 */
         pr_default.execute(18, new Object[] {A523AppVersionId, A516PageId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound95 = 1;
            A541IsPredefined = T001L20_A541IsPredefined[0];
            A517PageName = T001L20_A517PageName[0];
            A518PageStructure = T001L20_A518PageStructure[0];
            A536PagePublishedStructure = T001L20_A536PagePublishedStructure[0];
            A40000PageThumbnail_GXI = T001L20_A40000PageThumbnail_GXI[0];
            n40000PageThumbnail_GXI = T001L20_n40000PageThumbnail_GXI[0];
            A525PageType = T001L20_A525PageType[0];
            A621IsPageDeleted = T001L20_A621IsPageDeleted[0];
            A623PageDeletedAt = T001L20_A623PageDeletedAt[0];
            n623PageDeletedAt = T001L20_n623PageDeletedAt[0];
            A600PageThumbnail = T001L20_A600PageThumbnail[0];
            n600PageThumbnail = T001L20_n600PageThumbnail[0];
            ZM1L95( -24) ;
         }
         pr_default.close(18);
         OnLoadActions1L95( ) ;
      }

      protected void OnLoadActions1L95( )
      {
      }

      protected void CheckExtendedTable1L95( )
      {
         nIsDirty_95 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal1L95( ) ;
         if ( ! ( ( StringUtil.StrCmp(A525PageType, "Menu") == 0 ) || ( StringUtil.StrCmp(A525PageType, "Content") == 0 ) || ( StringUtil.StrCmp(A525PageType, "WebLink") == 0 ) || ( StringUtil.StrCmp(A525PageType, "DynamicForm") == 0 ) || ( StringUtil.StrCmp(A525PageType, "Calendar") == 0 ) || ( StringUtil.StrCmp(A525PageType, "MyActivity") == 0 ) || ( StringUtil.StrCmp(A525PageType, "Map") == 0 ) || ( StringUtil.StrCmp(A525PageType, "Reception") == 0 ) || ( StringUtil.StrCmp(A525PageType, "Location") == 0 ) || ( StringUtil.StrCmp(A525PageType, "MyCare") == 0 ) || ( StringUtil.StrCmp(A525PageType, "MyLiving") == 0 ) || ( StringUtil.StrCmp(A525PageType, "MyService") == 0 ) || ( StringUtil.StrCmp(A525PageType, "Information") == 0 ) ) )
         {
            GXCCtl = "PAGETYPE_" + sGXsfl_47_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Page Type", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbPageType_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1L95( )
      {
      }

      protected void enableDisable1L95( )
      {
      }

      protected void GetKey1L95( )
      {
         /* Using cursor T001L21 */
         pr_default.execute(19, new Object[] {A523AppVersionId, A516PageId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound95 = 1;
         }
         else
         {
            RcdFound95 = 0;
         }
         pr_default.close(19);
      }

      protected void getByPrimaryKey1L95( )
      {
         /* Using cursor T001L3 */
         pr_default.execute(1, new Object[] {A523AppVersionId, A516PageId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1L95( 24) ;
            RcdFound95 = 1;
            InitializeNonKey1L95( ) ;
            A516PageId = T001L3_A516PageId[0];
            A541IsPredefined = T001L3_A541IsPredefined[0];
            A517PageName = T001L3_A517PageName[0];
            A518PageStructure = T001L3_A518PageStructure[0];
            A536PagePublishedStructure = T001L3_A536PagePublishedStructure[0];
            A40000PageThumbnail_GXI = T001L3_A40000PageThumbnail_GXI[0];
            n40000PageThumbnail_GXI = T001L3_n40000PageThumbnail_GXI[0];
            A525PageType = T001L3_A525PageType[0];
            A621IsPageDeleted = T001L3_A621IsPageDeleted[0];
            A623PageDeletedAt = T001L3_A623PageDeletedAt[0];
            n623PageDeletedAt = T001L3_n623PageDeletedAt[0];
            A600PageThumbnail = T001L3_A600PageThumbnail[0];
            n600PageThumbnail = T001L3_n600PageThumbnail[0];
            Z523AppVersionId = A523AppVersionId;
            Z516PageId = A516PageId;
            sMode95 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1L95( ) ;
            Gx_mode = sMode95;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound95 = 0;
            InitializeNonKey1L95( ) ;
            sMode95 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1L95( ) ;
            Gx_mode = sMode95;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1L95( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency1L95( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001L2 */
            pr_default.execute(0, new Object[] {A523AppVersionId, A516PageId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AppVersionPage"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z541IsPredefined != T001L2_A541IsPredefined[0] ) || ( StringUtil.StrCmp(Z517PageName, T001L2_A517PageName[0]) != 0 ) || ( StringUtil.StrCmp(Z525PageType, T001L2_A525PageType[0]) != 0 ) || ( Z621IsPageDeleted != T001L2_A621IsPageDeleted[0] ) || ( Z623PageDeletedAt != T001L2_A623PageDeletedAt[0] ) )
            {
               if ( Z541IsPredefined != T001L2_A541IsPredefined[0] )
               {
                  GXUtil.WriteLog("trn_appversion:[seudo value changed for attri]"+"IsPredefined");
                  GXUtil.WriteLogRaw("Old: ",Z541IsPredefined);
                  GXUtil.WriteLogRaw("Current: ",T001L2_A541IsPredefined[0]);
               }
               if ( StringUtil.StrCmp(Z517PageName, T001L2_A517PageName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_appversion:[seudo value changed for attri]"+"PageName");
                  GXUtil.WriteLogRaw("Old: ",Z517PageName);
                  GXUtil.WriteLogRaw("Current: ",T001L2_A517PageName[0]);
               }
               if ( StringUtil.StrCmp(Z525PageType, T001L2_A525PageType[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_appversion:[seudo value changed for attri]"+"PageType");
                  GXUtil.WriteLogRaw("Old: ",Z525PageType);
                  GXUtil.WriteLogRaw("Current: ",T001L2_A525PageType[0]);
               }
               if ( Z621IsPageDeleted != T001L2_A621IsPageDeleted[0] )
               {
                  GXUtil.WriteLog("trn_appversion:[seudo value changed for attri]"+"IsPageDeleted");
                  GXUtil.WriteLogRaw("Old: ",Z621IsPageDeleted);
                  GXUtil.WriteLogRaw("Current: ",T001L2_A621IsPageDeleted[0]);
               }
               if ( Z623PageDeletedAt != T001L2_A623PageDeletedAt[0] )
               {
                  GXUtil.WriteLog("trn_appversion:[seudo value changed for attri]"+"PageDeletedAt");
                  GXUtil.WriteLogRaw("Old: ",Z623PageDeletedAt);
                  GXUtil.WriteLogRaw("Current: ",T001L2_A623PageDeletedAt[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_AppVersionPage"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1L95( )
      {
         if ( ! IsAuthorized("trn_appversion_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1L95( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1L95( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1L95( 0) ;
            CheckOptimisticConcurrency1L95( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1L95( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1L95( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001L22 */
                     pr_default.execute(20, new Object[] {A523AppVersionId, A516PageId, A541IsPredefined, A517PageName, A518PageStructure, A536PagePublishedStructure, n600PageThumbnail, A600PageThumbnail, n40000PageThumbnail_GXI, A40000PageThumbnail_GXI, A525PageType, A621IsPageDeleted, n623PageDeletedAt, A623PageDeletedAt});
                     pr_default.close(20);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersionPage");
                     if ( (pr_default.getStatus(20) == 1) )
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
                           /* Save values for previous() function. */
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
               Load1L95( ) ;
            }
            EndLevel1L95( ) ;
         }
         CloseExtendedTableCursors1L95( ) ;
      }

      protected void Update1L95( )
      {
         if ( ! IsAuthorized("trn_appversion_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1L95( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1L95( ) ;
         }
         if ( ( nIsMod_95 != 0 ) || ( nIsDirty_95 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency1L95( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm1L95( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate1L95( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T001L23 */
                        pr_default.execute(21, new Object[] {A541IsPredefined, A517PageName, A518PageStructure, A536PagePublishedStructure, A525PageType, A621IsPageDeleted, n623PageDeletedAt, A623PageDeletedAt, A523AppVersionId, A516PageId});
                        pr_default.close(21);
                        pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersionPage");
                        if ( (pr_default.getStatus(21) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AppVersionPage"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate1L95( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey1L95( ) ;
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
               EndLevel1L95( ) ;
            }
         }
         CloseExtendedTableCursors1L95( ) ;
      }

      protected void DeferredUpdate1L95( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T001L24 */
            pr_default.execute(22, new Object[] {n600PageThumbnail, A600PageThumbnail, n40000PageThumbnail_GXI, A40000PageThumbnail_GXI, A523AppVersionId, A516PageId});
            pr_default.close(22);
            pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersionPage");
         }
      }

      protected void Delete1L95( )
      {
         if ( ! IsAuthorized("trn_appversion_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1L95( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1L95( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1L95( ) ;
            AfterConfirm1L95( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1L95( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001L25 */
                  pr_default.execute(23, new Object[] {A523AppVersionId, A516PageId});
                  pr_default.close(23);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersionPage");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode95 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1L95( ) ;
         Gx_mode = sMode95;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1L95( )
      {
         standaloneModal1L95( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1L95( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1L95( )
      {
         /* Scan By routine */
         /* Using cursor T001L26 */
         pr_default.execute(24, new Object[] {A523AppVersionId});
         RcdFound95 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound95 = 1;
            A516PageId = T001L26_A516PageId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1L95( )
      {
         /* Scan next routine */
         pr_default.readNext(24);
         RcdFound95 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound95 = 1;
            A516PageId = T001L26_A516PageId[0];
         }
      }

      protected void ScanEnd1L95( )
      {
         pr_default.close(24);
      }

      protected void AfterConfirm1L95( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1L95( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1L95( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1L95( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1L95( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1L95( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1L95( )
      {
         edtPageId_Enabled = 0;
         AssignProp("", false, edtPageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageId_Enabled), 5, 0), !bGXsfl_47_Refreshing);
         edtPageName_Enabled = 0;
         AssignProp("", false, edtPageName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageName_Enabled), 5, 0), !bGXsfl_47_Refreshing);
         edtPageStructure_Enabled = 0;
         AssignProp("", false, edtPageStructure_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageStructure_Enabled), 5, 0), !bGXsfl_47_Refreshing);
         edtPagePublishedStructure_Enabled = 0;
         AssignProp("", false, edtPagePublishedStructure_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagePublishedStructure_Enabled), 5, 0), !bGXsfl_47_Refreshing);
         chkIsPredefined.Enabled = 0;
         AssignProp("", false, chkIsPredefined_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkIsPredefined.Enabled), 5, 0), !bGXsfl_47_Refreshing);
         cmbPageType.Enabled = 0;
         AssignProp("", false, cmbPageType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPageType.Enabled), 5, 0), !bGXsfl_47_Refreshing);
      }

      protected void send_integrity_lvl_hashes1L95( )
      {
      }

      protected void send_integrity_lvl_hashes1L94( )
      {
      }

      protected void SubsflControlProps_4795( )
      {
         edtPageId_Internalname = "PAGEID_"+sGXsfl_47_idx;
         edtPageName_Internalname = "PAGENAME_"+sGXsfl_47_idx;
         edtPageStructure_Internalname = "PAGESTRUCTURE_"+sGXsfl_47_idx;
         edtPagePublishedStructure_Internalname = "PAGEPUBLISHEDSTRUCTURE_"+sGXsfl_47_idx;
         chkIsPredefined_Internalname = "ISPREDEFINED_"+sGXsfl_47_idx;
         cmbPageType_Internalname = "PAGETYPE_"+sGXsfl_47_idx;
      }

      protected void SubsflControlProps_fel_4795( )
      {
         edtPageId_Internalname = "PAGEID_"+sGXsfl_47_fel_idx;
         edtPageName_Internalname = "PAGENAME_"+sGXsfl_47_fel_idx;
         edtPageStructure_Internalname = "PAGESTRUCTURE_"+sGXsfl_47_fel_idx;
         edtPagePublishedStructure_Internalname = "PAGEPUBLISHEDSTRUCTURE_"+sGXsfl_47_fel_idx;
         chkIsPredefined_Internalname = "ISPREDEFINED_"+sGXsfl_47_fel_idx;
         cmbPageType_Internalname = "PAGETYPE_"+sGXsfl_47_fel_idx;
      }

      protected void AddRow1L95( )
      {
         nGXsfl_47_idx = (int)(nGXsfl_47_idx+1);
         sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
         SubsflControlProps_4795( ) ;
         SendRow1L95( ) ;
      }

      protected void SendRow1L95( )
      {
         Gridlevel_pageRow = GXWebRow.GetNew(context);
         if ( subGridlevel_page_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_page_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_page_Class, "") != 0 )
            {
               subGridlevel_page_Linesclass = subGridlevel_page_Class+"Odd";
            }
         }
         else if ( subGridlevel_page_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_page_Backstyle = 0;
            subGridlevel_page_Backcolor = subGridlevel_page_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_page_Class, "") != 0 )
            {
               subGridlevel_page_Linesclass = subGridlevel_page_Class+"Uniform";
            }
         }
         else if ( subGridlevel_page_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_page_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_page_Class, "") != 0 )
            {
               subGridlevel_page_Linesclass = subGridlevel_page_Class+"Odd";
            }
            subGridlevel_page_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_page_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_page_Backstyle = 1;
            if ( ((int)((nGXsfl_47_idx) % (2))) == 0 )
            {
               subGridlevel_page_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_page_Class, "") != 0 )
               {
                  subGridlevel_page_Linesclass = subGridlevel_page_Class+"Even";
               }
            }
            else
            {
               subGridlevel_page_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_page_Class, "") != 0 )
               {
                  subGridlevel_page_Linesclass = subGridlevel_page_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_95_" + sGXsfl_47_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 48,'',false,'" + sGXsfl_47_idx + "',47)\"";
         ROClassString = "Attribute";
         Gridlevel_pageRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPageId_Internalname,A516PageId.ToString(),A516PageId.ToString(),TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPageId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtPageId_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)47,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_95_" + sGXsfl_47_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_47_idx + "',47)\"";
         ROClassString = "Attribute";
         Gridlevel_pageRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPageName_Internalname,(string)A517PageName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPageName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtPageName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)47,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_95_" + sGXsfl_47_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_47_idx + "',47)\"";
         ROClassString = "Attribute";
         Gridlevel_pageRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPageStructure_Internalname,(string)A518PageStructure,(string)A518PageStructure,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPageStructure_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtPageStructure_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)47,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_95_" + sGXsfl_47_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_47_idx + "',47)\"";
         ROClassString = "Attribute";
         Gridlevel_pageRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPagePublishedStructure_Internalname,(string)A536PagePublishedStructure,(string)A536PagePublishedStructure,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPagePublishedStructure_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtPagePublishedStructure_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)47,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
         /* Subfile cell */
         /* Check box */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_95_" + sGXsfl_47_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_47_idx + "',47)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GXCCtl = "ISPREDEFINED_" + sGXsfl_47_idx;
         chkIsPredefined.Name = GXCCtl;
         chkIsPredefined.WebTags = "";
         chkIsPredefined.Caption = "";
         AssignProp("", false, chkIsPredefined_Internalname, "TitleCaption", chkIsPredefined.Caption, !bGXsfl_47_Refreshing);
         chkIsPredefined.CheckedValue = "false";
         if ( IsIns( ) && (false==A541IsPredefined) )
         {
            A541IsPredefined = false;
         }
         Gridlevel_pageRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkIsPredefined_Internalname,StringUtil.BoolToStr( A541IsPredefined),(string)"",(string)"",(short)-1,chkIsPredefined.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"TrnColumn",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(52, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,52);\""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_95_" + sGXsfl_47_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_47_idx + "',47)\"";
         if ( ( cmbPageType.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "PAGETYPE_" + sGXsfl_47_idx;
            cmbPageType.Name = GXCCtl;
            cmbPageType.WebTags = "";
            cmbPageType.addItem("Menu", context.GetMessage( "Menu", ""), 0);
            cmbPageType.addItem("Content", context.GetMessage( "Content", ""), 0);
            cmbPageType.addItem("WebLink", context.GetMessage( "Web Link", ""), 0);
            cmbPageType.addItem("DynamicForm", context.GetMessage( "Dynamic Form", ""), 0);
            cmbPageType.addItem("Calendar", context.GetMessage( "Calendar", ""), 0);
            cmbPageType.addItem("MyActivity", context.GetMessage( "My Activity", ""), 0);
            cmbPageType.addItem("Map", context.GetMessage( "Map", ""), 0);
            cmbPageType.addItem("Reception", context.GetMessage( "Reception", ""), 0);
            cmbPageType.addItem("Location", context.GetMessage( "Location", ""), 0);
            cmbPageType.addItem("MyCare", context.GetMessage( "My Care", ""), 0);
            cmbPageType.addItem("MyLiving", context.GetMessage( "My Living", ""), 0);
            cmbPageType.addItem("MyService", context.GetMessage( "My Service", ""), 0);
            cmbPageType.addItem("Information", context.GetMessage( "Information", ""), 0);
            if ( cmbPageType.ItemCount > 0 )
            {
               A525PageType = cmbPageType.getValidValue(A525PageType);
            }
         }
         /* ComboBox */
         Gridlevel_pageRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbPageType,(string)cmbPageType_Internalname,StringUtil.RTrim( A525PageType),(short)1,(string)cmbPageType_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,cmbPageType.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"",(string)"",(bool)true,(short)0});
         cmbPageType.CurrentValue = StringUtil.RTrim( A525PageType);
         AssignProp("", false, cmbPageType_Internalname, "Values", (string)(cmbPageType.ToJavascriptSource()), !bGXsfl_47_Refreshing);
         ajax_sending_grid_row(Gridlevel_pageRow);
         send_integrity_lvl_hashes1L95( ) ;
         GXCCtl = "Z516PageId_" + sGXsfl_47_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z516PageId.ToString());
         GXCCtl = "Z541IsPredefined_" + sGXsfl_47_idx;
         GxWebStd.gx_boolean_hidden_field( context, GXCCtl, Z541IsPredefined);
         GXCCtl = "Z517PageName_" + sGXsfl_47_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z517PageName);
         GXCCtl = "Z525PageType_" + sGXsfl_47_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z525PageType);
         GXCCtl = "Z621IsPageDeleted_" + sGXsfl_47_idx;
         GxWebStd.gx_boolean_hidden_field( context, GXCCtl, Z621IsPageDeleted);
         GXCCtl = "Z623PageDeletedAt_" + sGXsfl_47_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.TToC( Z623PageDeletedAt, 10, 8, 0, 0, "/", ":", " "));
         GXCCtl = "nRcdDeleted_95_" + sGXsfl_47_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_95), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_95_" + sGXsfl_47_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_95), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_95_" + sGXsfl_47_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_95), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_47_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_47_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV12TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV12TrnContext);
         }
         GXCCtl = "vAPPVERSIONID_" + sGXsfl_47_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, AV8AppVersionId.ToString());
         GxWebStd.gx_hidden_field( context, "PAGEID_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PAGENAME_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PAGESTRUCTURE_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageStructure_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PAGEPUBLISHEDSTRUCTURE_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPagePublishedStructure_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ISPREDEFINED_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkIsPredefined.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PAGETYPE_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbPageType.Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_pageContainer.AddRow(Gridlevel_pageRow);
      }

      protected void ReadRow1L95( )
      {
         nGXsfl_47_idx = (int)(nGXsfl_47_idx+1);
         sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
         SubsflControlProps_4795( ) ;
         edtPageId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAGEID_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtPageName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAGENAME_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtPageStructure_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAGESTRUCTURE_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtPagePublishedStructure_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAGEPUBLISHEDSTRUCTURE_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         chkIsPredefined.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ISPREDEFINED_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbPageType.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAGETYPE_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( StringUtil.StrCmp(cgiGet( edtPageId_Internalname), "") == 0 )
         {
            A516PageId = Guid.Empty;
         }
         else
         {
            try
            {
               A516PageId = StringUtil.StrToGuid( cgiGet( edtPageId_Internalname));
            }
            catch ( Exception  )
            {
               GXCCtl = "PAGEID_" + sGXsfl_47_idx;
               GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtPageId_Internalname;
               wbErr = true;
            }
         }
         A517PageName = cgiGet( edtPageName_Internalname);
         A518PageStructure = cgiGet( edtPageStructure_Internalname);
         A536PagePublishedStructure = cgiGet( edtPagePublishedStructure_Internalname);
         A541IsPredefined = StringUtil.StrToBool( cgiGet( chkIsPredefined_Internalname));
         cmbPageType.Name = cmbPageType_Internalname;
         cmbPageType.CurrentValue = cgiGet( cmbPageType_Internalname);
         A525PageType = cgiGet( cmbPageType_Internalname);
         GXCCtl = "Z516PageId_" + sGXsfl_47_idx;
         Z516PageId = StringUtil.StrToGuid( cgiGet( GXCCtl));
         GXCCtl = "Z541IsPredefined_" + sGXsfl_47_idx;
         Z541IsPredefined = StringUtil.StrToBool( cgiGet( GXCCtl));
         GXCCtl = "Z517PageName_" + sGXsfl_47_idx;
         Z517PageName = cgiGet( GXCCtl);
         GXCCtl = "Z525PageType_" + sGXsfl_47_idx;
         Z525PageType = cgiGet( GXCCtl);
         GXCCtl = "Z621IsPageDeleted_" + sGXsfl_47_idx;
         Z621IsPageDeleted = StringUtil.StrToBool( cgiGet( GXCCtl));
         GXCCtl = "Z623PageDeletedAt_" + sGXsfl_47_idx;
         Z623PageDeletedAt = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         n623PageDeletedAt = ((DateTime.MinValue==A623PageDeletedAt) ? true : false);
         GXCCtl = "Z621IsPageDeleted_" + sGXsfl_47_idx;
         A621IsPageDeleted = StringUtil.StrToBool( cgiGet( GXCCtl));
         GXCCtl = "Z623PageDeletedAt_" + sGXsfl_47_idx;
         A623PageDeletedAt = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         n623PageDeletedAt = false;
         n623PageDeletedAt = ((DateTime.MinValue==A623PageDeletedAt) ? true : false);
         GXCCtl = "nRcdDeleted_95_" + sGXsfl_47_idx;
         nRcdDeleted_95 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_95_" + sGXsfl_47_idx;
         nRcdExists_95 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_95_" + sGXsfl_47_idx;
         nIsMod_95 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtPageId_Enabled = edtPageId_Enabled;
      }

      protected void ConfirmValues1L0( )
      {
         nGXsfl_47_idx = 0;
         sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
         SubsflControlProps_4795( ) ;
         while ( nGXsfl_47_idx < nRC_GXsfl_47 )
         {
            nGXsfl_47_idx = (int)(nGXsfl_47_idx+1);
            sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
            SubsflControlProps_4795( ) ;
            ChangePostValue( "Z516PageId_"+sGXsfl_47_idx, cgiGet( "ZT_"+"Z516PageId_"+sGXsfl_47_idx)) ;
            DeletePostValue( "ZT_"+"Z516PageId_"+sGXsfl_47_idx) ;
            ChangePostValue( "Z541IsPredefined_"+sGXsfl_47_idx, cgiGet( "ZT_"+"Z541IsPredefined_"+sGXsfl_47_idx)) ;
            DeletePostValue( "ZT_"+"Z541IsPredefined_"+sGXsfl_47_idx) ;
            ChangePostValue( "Z517PageName_"+sGXsfl_47_idx, cgiGet( "ZT_"+"Z517PageName_"+sGXsfl_47_idx)) ;
            DeletePostValue( "ZT_"+"Z517PageName_"+sGXsfl_47_idx) ;
            ChangePostValue( "Z525PageType_"+sGXsfl_47_idx, cgiGet( "ZT_"+"Z525PageType_"+sGXsfl_47_idx)) ;
            DeletePostValue( "ZT_"+"Z525PageType_"+sGXsfl_47_idx) ;
            ChangePostValue( "Z621IsPageDeleted_"+sGXsfl_47_idx, cgiGet( "ZT_"+"Z621IsPageDeleted_"+sGXsfl_47_idx)) ;
            DeletePostValue( "ZT_"+"Z621IsPageDeleted_"+sGXsfl_47_idx) ;
            ChangePostValue( "Z623PageDeletedAt_"+sGXsfl_47_idx, cgiGet( "ZT_"+"Z623PageDeletedAt_"+sGXsfl_47_idx)) ;
            DeletePostValue( "ZT_"+"Z623PageDeletedAt_"+sGXsfl_47_idx) ;
         }
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
         GXEncryptionTmp = "trn_appversion.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV8AppVersionId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_appversion.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_AppVersion");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("IsVersionDeleted", StringUtil.BoolToStr( A620IsVersionDeleted));
         forbiddenHiddens.Add("VersionDeletedAt", context.localUtil.Format( A622VersionDeletedAt, "99/99/99 99:99"));
         forbiddenHiddens.Add("AppVersionLanguage", StringUtil.RTrim( context.localUtil.Format( A648AppVersionLanguage, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_appversion:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z523AppVersionId", Z523AppVersionId.ToString());
         GxWebStd.gx_hidden_field( context, "Z524AppVersionName", Z524AppVersionName);
         GxWebStd.gx_boolean_hidden_field( context, "Z535IsActive", Z535IsActive);
         GxWebStd.gx_boolean_hidden_field( context, "Z620IsVersionDeleted", Z620IsVersionDeleted);
         GxWebStd.gx_hidden_field( context, "Z622VersionDeletedAt", context.localUtil.TToC( Z622VersionDeletedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z648AppVersionLanguage", Z648AppVersionLanguage);
         GxWebStd.gx_hidden_field( context, "Z11OrganisationId", Z11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z273Trn_ThemeId", Z273Trn_ThemeId.ToString());
         GxWebStd.gx_hidden_field( context, "Z29LocationId", Z29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_47", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_47_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N29LocationId", A29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "N11OrganisationId", A11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "N273Trn_ThemeId", A273Trn_ThemeId.ToString());
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV12TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV12TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV12TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vAPPVERSIONID", AV8AppVersionId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vAPPVERSIONID", GetSecureSignedToken( "", AV8AppVersionId, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_LOCATIONID", AV14Insert_LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_ORGANISATIONID", AV15Insert_OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_TRN_THEMEID", AV29Insert_Trn_ThemeId.ToString());
         GxWebStd.gx_hidden_field( context, "TRN_THEMEID", A273Trn_ThemeId.ToString());
         GxWebStd.gx_boolean_hidden_field( context, "ISVERSIONDELETED", A620IsVersionDeleted);
         GxWebStd.gx_hidden_field( context, "VERSIONDELETEDAT", context.localUtil.TToC( A622VersionDeletedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "APPVERSIONLANGUAGE", A648AppVersionLanguage);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV31Pgmname));
         GxWebStd.gx_hidden_field( context, "PAGETHUMBNAIL", A600PageThumbnail);
         GxWebStd.gx_hidden_field( context, "PAGETHUMBNAIL_GXI", A40000PageThumbnail_GXI);
         GxWebStd.gx_boolean_hidden_field( context, "ISPAGEDELETED", A621IsPageDeleted);
         GxWebStd.gx_hidden_field( context, "PAGEDELETEDAT", context.localUtil.TToC( A623PageDeletedAt, 10, 8, 0, 0, "/", ":", " "));
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
         GXEncryptionTmp = "trn_appversion.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV8AppVersionId.ToString());
         return formatLink("trn_appversion.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Trn_AppVersion" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_App Version", "") ;
      }

      protected void InitializeNonKey1L94( )
      {
         A29LocationId = Guid.Empty;
         n29LocationId = false;
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         n29LocationId = ((Guid.Empty==A29LocationId) ? true : false);
         A11OrganisationId = Guid.Empty;
         n11OrganisationId = false;
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         n11OrganisationId = ((Guid.Empty==A11OrganisationId) ? true : false);
         A273Trn_ThemeId = Guid.Empty;
         AssignAttri("", false, "A273Trn_ThemeId", A273Trn_ThemeId.ToString());
         A524AppVersionName = "";
         AssignAttri("", false, "A524AppVersionName", A524AppVersionName);
         A535IsActive = false;
         AssignAttri("", false, "A535IsActive", A535IsActive);
         A620IsVersionDeleted = false;
         AssignAttri("", false, "A620IsVersionDeleted", A620IsVersionDeleted);
         A622VersionDeletedAt = (DateTime)(DateTime.MinValue);
         n622VersionDeletedAt = false;
         AssignAttri("", false, "A622VersionDeletedAt", context.localUtil.TToC( A622VersionDeletedAt, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A648AppVersionLanguage = "";
         AssignAttri("", false, "A648AppVersionLanguage", A648AppVersionLanguage);
         Z524AppVersionName = "";
         Z535IsActive = false;
         Z620IsVersionDeleted = false;
         Z622VersionDeletedAt = (DateTime)(DateTime.MinValue);
         Z648AppVersionLanguage = "";
         Z11OrganisationId = Guid.Empty;
         Z273Trn_ThemeId = Guid.Empty;
         Z29LocationId = Guid.Empty;
      }

      protected void InitAll1L94( )
      {
         A523AppVersionId = Guid.NewGuid( );
         AssignAttri("", false, "A523AppVersionId", A523AppVersionId.ToString());
         InitializeNonKey1L94( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey1L95( )
      {
         A517PageName = "";
         A518PageStructure = "";
         A536PagePublishedStructure = "";
         A600PageThumbnail = "";
         n600PageThumbnail = false;
         AssignAttri("", false, "A600PageThumbnail", A600PageThumbnail);
         A40000PageThumbnail_GXI = "";
         n40000PageThumbnail_GXI = false;
         AssignAttri("", false, "A40000PageThumbnail_GXI", A40000PageThumbnail_GXI);
         A525PageType = "";
         A621IsPageDeleted = false;
         AssignAttri("", false, "A621IsPageDeleted", A621IsPageDeleted);
         A623PageDeletedAt = (DateTime)(DateTime.MinValue);
         n623PageDeletedAt = false;
         AssignAttri("", false, "A623PageDeletedAt", context.localUtil.TToC( A623PageDeletedAt, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A541IsPredefined = false;
         Z541IsPredefined = false;
         Z517PageName = "";
         Z525PageType = "";
         Z621IsPageDeleted = false;
         Z623PageDeletedAt = (DateTime)(DateTime.MinValue);
      }

      protected void InitAll1L95( )
      {
         A516PageId = Guid.NewGuid( );
         InitializeNonKey1L95( ) ;
      }

      protected void StandaloneModalInsert1L95( )
      {
         A541IsPredefined = i541IsPredefined;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025625842145", true, true);
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
         context.AddJavascriptSource("trn_appversion.js", "?2025625842147", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties95( )
      {
         edtPageId_Enabled = defedtPageId_Enabled;
         AssignProp("", false, edtPageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageId_Enabled), 5, 0), !bGXsfl_47_Refreshing);
      }

      protected void StartGridControl47( )
      {
         Gridlevel_pageContainer.AddObjectProperty("GridName", "Gridlevel_page");
         Gridlevel_pageContainer.AddObjectProperty("Header", subGridlevel_page_Header);
         Gridlevel_pageContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_pageContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_pageContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_pageContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_page_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_pageContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_pageContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_pageColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_pageColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A516PageId.ToString()));
         Gridlevel_pageColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageId_Enabled), 5, 0, ".", "")));
         Gridlevel_pageContainer.AddColumnProperties(Gridlevel_pageColumn);
         Gridlevel_pageColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_pageColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A517PageName));
         Gridlevel_pageColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageName_Enabled), 5, 0, ".", "")));
         Gridlevel_pageContainer.AddColumnProperties(Gridlevel_pageColumn);
         Gridlevel_pageColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_pageColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A518PageStructure));
         Gridlevel_pageColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageStructure_Enabled), 5, 0, ".", "")));
         Gridlevel_pageContainer.AddColumnProperties(Gridlevel_pageColumn);
         Gridlevel_pageColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_pageColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A536PagePublishedStructure));
         Gridlevel_pageColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPagePublishedStructure_Enabled), 5, 0, ".", "")));
         Gridlevel_pageContainer.AddColumnProperties(Gridlevel_pageColumn);
         Gridlevel_pageColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_pageColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A541IsPredefined)));
         Gridlevel_pageColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkIsPredefined.Enabled), 5, 0, ".", "")));
         Gridlevel_pageContainer.AddColumnProperties(Gridlevel_pageColumn);
         Gridlevel_pageColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_pageColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A525PageType));
         Gridlevel_pageColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbPageType.Enabled), 5, 0, ".", "")));
         Gridlevel_pageContainer.AddColumnProperties(Gridlevel_pageColumn);
         Gridlevel_pageContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_page_Selectedindex), 4, 0, ".", "")));
         Gridlevel_pageContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_page_Allowselection), 1, 0, ".", "")));
         Gridlevel_pageContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_page_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_pageContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_page_Allowhovering), 1, 0, ".", "")));
         Gridlevel_pageContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_page_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_pageContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_page_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_pageContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_page_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         edtAppVersionId_Internalname = "APPVERSIONID";
         edtAppVersionName_Internalname = "APPVERSIONNAME";
         edtLocationId_Internalname = "LOCATIONID";
         edtOrganisationId_Internalname = "ORGANISATIONID";
         chkIsActive_Internalname = "ISACTIVE";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         edtPageId_Internalname = "PAGEID";
         edtPageName_Internalname = "PAGENAME";
         edtPageStructure_Internalname = "PAGESTRUCTURE";
         edtPagePublishedStructure_Internalname = "PAGEPUBLISHEDSTRUCTURE";
         chkIsPredefined_Internalname = "ISPREDEFINED";
         cmbPageType_Internalname = "PAGETYPE";
         divTableleaflevel_page_Internalname = "TABLELEAFLEVEL_PAGE";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridlevel_page_Internalname = "GRIDLEVEL_PAGE";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_page_Allowcollapsing = 0;
         subGridlevel_page_Allowselection = 0;
         subGridlevel_page_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Trn_App Version", "");
         cmbPageType_Jsonclick = "";
         chkIsPredefined.Caption = "";
         edtPagePublishedStructure_Jsonclick = "";
         edtPageStructure_Jsonclick = "";
         edtPageName_Jsonclick = "";
         edtPageId_Jsonclick = "";
         subGridlevel_page_Class = "WorkWith";
         subGridlevel_page_Backcolorstyle = 0;
         cmbPageType.Enabled = 1;
         chkIsPredefined.Enabled = 1;
         edtPagePublishedStructure_Enabled = 1;
         edtPageStructure_Enabled = 1;
         edtPageName_Enabled = 1;
         edtPageId_Enabled = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         chkIsActive.Enabled = 1;
         edtOrganisationId_Jsonclick = "";
         edtOrganisationId_Enabled = 1;
         edtLocationId_Jsonclick = "";
         edtLocationId_Enabled = 1;
         edtAppVersionName_Jsonclick = "";
         edtAppVersionName_Enabled = 1;
         edtAppVersionId_Jsonclick = "";
         edtAppVersionId_Enabled = 1;
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

      protected void GX12ASATRN_THEMEID1L94( Guid AV29Insert_Trn_ThemeId ,
                                             Guid A273Trn_ThemeId )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV29Insert_Trn_ThemeId) )
         {
            A273Trn_ThemeId = AV29Insert_Trn_ThemeId;
            AssignAttri("", false, "A273Trn_ThemeId", A273Trn_ThemeId.ToString());
         }
         else
         {
            if ( (Guid.Empty==A273Trn_ThemeId) )
            {
               GXt_guid1 = A273Trn_ThemeId;
               new prc_getdefaulttheme(context ).execute( out  GXt_guid1) ;
               A273Trn_ThemeId = GXt_guid1;
               AssignAttri("", false, "A273Trn_ThemeId", A273Trn_ThemeId.ToString());
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A273Trn_ThemeId.ToString())+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void gxnrGridlevel_page_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_4795( ) ;
         while ( nGXsfl_47_idx <= nRC_GXsfl_47 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal1L95( ) ;
            standaloneModal1L95( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow1L95( ) ;
            nGXsfl_47_idx = (int)(nGXsfl_47_idx+1);
            sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
            SubsflControlProps_4795( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_pageContainer)) ;
         /* End function gxnrGridlevel_page_newrow */
      }

      protected void init_web_controls( )
      {
         chkIsActive.Name = "ISACTIVE";
         chkIsActive.WebTags = "";
         chkIsActive.Caption = context.GetMessage( "Active", "");
         AssignProp("", false, chkIsActive_Internalname, "TitleCaption", chkIsActive.Caption, true);
         chkIsActive.CheckedValue = "false";
         A535IsActive = StringUtil.StrToBool( StringUtil.BoolToStr( A535IsActive));
         AssignAttri("", false, "A535IsActive", A535IsActive);
         GXCCtl = "ISPREDEFINED_" + sGXsfl_47_idx;
         chkIsPredefined.Name = GXCCtl;
         chkIsPredefined.WebTags = "";
         chkIsPredefined.Caption = "";
         AssignProp("", false, chkIsPredefined_Internalname, "TitleCaption", chkIsPredefined.Caption, !bGXsfl_47_Refreshing);
         chkIsPredefined.CheckedValue = "false";
         if ( IsIns( ) && (false==A541IsPredefined) )
         {
            A541IsPredefined = false;
         }
         GXCCtl = "PAGETYPE_" + sGXsfl_47_idx;
         cmbPageType.Name = GXCCtl;
         cmbPageType.WebTags = "";
         cmbPageType.addItem("Menu", context.GetMessage( "Menu", ""), 0);
         cmbPageType.addItem("Content", context.GetMessage( "Content", ""), 0);
         cmbPageType.addItem("WebLink", context.GetMessage( "Web Link", ""), 0);
         cmbPageType.addItem("DynamicForm", context.GetMessage( "Dynamic Form", ""), 0);
         cmbPageType.addItem("Calendar", context.GetMessage( "Calendar", ""), 0);
         cmbPageType.addItem("MyActivity", context.GetMessage( "My Activity", ""), 0);
         cmbPageType.addItem("Map", context.GetMessage( "Map", ""), 0);
         cmbPageType.addItem("Reception", context.GetMessage( "Reception", ""), 0);
         cmbPageType.addItem("Location", context.GetMessage( "Location", ""), 0);
         cmbPageType.addItem("MyCare", context.GetMessage( "My Care", ""), 0);
         cmbPageType.addItem("MyLiving", context.GetMessage( "My Living", ""), 0);
         cmbPageType.addItem("MyService", context.GetMessage( "My Service", ""), 0);
         cmbPageType.addItem("Information", context.GetMessage( "Information", ""), 0);
         if ( cmbPageType.ItemCount > 0 )
         {
            A525PageType = cmbPageType.getValidValue(A525PageType);
         }
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

      public void Valid_Organisationid( )
      {
         n29LocationId = false;
         n11OrganisationId = false;
         /* Using cursor T001L27 */
         pr_default.execute(25, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(25) == 101) )
         {
            if ( ! ( (Guid.Empty==A29LocationId) || (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
               GX_FocusControl = edtLocationId_Internalname;
            }
         }
         pr_default.close(25);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV8AppVersionId","fld":"vAPPVERSIONID","hsh":true},{"av":"A535IsActive","fld":"ISACTIVE"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A535IsActive","fld":"ISACTIVE"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV12TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV8AppVersionId","fld":"vAPPVERSIONID","hsh":true},{"av":"A620IsVersionDeleted","fld":"ISVERSIONDELETED"},{"av":"A622VersionDeletedAt","fld":"VERSIONDELETEDAT","pic":"99/99/99 99:99"},{"av":"A648AppVersionLanguage","fld":"APPVERSIONLANGUAGE"},{"av":"A535IsActive","fld":"ISACTIVE"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A535IsActive","fld":"ISACTIVE"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E121L2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV12TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"A535IsActive","fld":"ISACTIVE"}]""");
         setEventMetadata("AFTER TRN",""","oparms":[{"av":"A535IsActive","fld":"ISACTIVE"}]}""");
         setEventMetadata("VALID_APPVERSIONID","""{"handler":"Valid_Appversionid","iparms":[{"av":"A535IsActive","fld":"ISACTIVE"}]""");
         setEventMetadata("VALID_APPVERSIONID",""","oparms":[{"av":"A535IsActive","fld":"ISACTIVE"}]}""");
         setEventMetadata("VALID_LOCATIONID","""{"handler":"Valid_Locationid","iparms":[{"av":"A535IsActive","fld":"ISACTIVE"}]""");
         setEventMetadata("VALID_LOCATIONID",""","oparms":[{"av":"A535IsActive","fld":"ISACTIVE"}]}""");
         setEventMetadata("VALID_ORGANISATIONID","""{"handler":"Valid_Organisationid","iparms":[{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A535IsActive","fld":"ISACTIVE"}]""");
         setEventMetadata("VALID_ORGANISATIONID",""","oparms":[{"av":"A535IsActive","fld":"ISACTIVE"}]}""");
         setEventMetadata("VALID_PAGEID","""{"handler":"Valid_Pageid","iparms":[{"av":"A535IsActive","fld":"ISACTIVE"}]""");
         setEventMetadata("VALID_PAGEID",""","oparms":[{"av":"A535IsActive","fld":"ISACTIVE"}]}""");
         setEventMetadata("VALID_PAGETYPE","""{"handler":"Valid_Pagetype","iparms":[{"av":"A535IsActive","fld":"ISACTIVE"}]""");
         setEventMetadata("VALID_PAGETYPE",""","oparms":[{"av":"A535IsActive","fld":"ISACTIVE"}]}""");
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
         pr_default.close(3);
         pr_default.close(25);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV8AppVersionId = Guid.Empty;
         Z523AppVersionId = Guid.Empty;
         Z524AppVersionName = "";
         Z622VersionDeletedAt = (DateTime)(DateTime.MinValue);
         Z648AppVersionLanguage = "";
         Z11OrganisationId = Guid.Empty;
         Z273Trn_ThemeId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         N29LocationId = Guid.Empty;
         N11OrganisationId = Guid.Empty;
         N273Trn_ThemeId = Guid.Empty;
         Z516PageId = Guid.Empty;
         Z517PageName = "";
         Z525PageType = "";
         Z623PageDeletedAt = (DateTime)(DateTime.MinValue);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV29Insert_Trn_ThemeId = Guid.Empty;
         A273Trn_ThemeId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A523AppVersionId = Guid.Empty;
         A524AppVersionName = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Gridlevel_pageContainer = new GXWebGrid( context);
         sMode95 = "";
         A516PageId = Guid.Empty;
         sStyleString = "";
         A622VersionDeletedAt = (DateTime)(DateTime.MinValue);
         A648AppVersionLanguage = "";
         AV14Insert_LocationId = Guid.Empty;
         AV15Insert_OrganisationId = Guid.Empty;
         AV31Pgmname = "";
         A600PageThumbnail = "";
         A40000PageThumbnail_GXI = "";
         A623PageDeletedAt = (DateTime)(DateTime.MinValue);
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode94 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A517PageName = "";
         A518PageStructure = "";
         A536PagePublishedStructure = "";
         A525PageType = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV12TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV13WebSession = context.GetSession();
         AV16TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         T001L8_A523AppVersionId = new Guid[] {Guid.Empty} ;
         T001L8_A524AppVersionName = new string[] {""} ;
         T001L8_A535IsActive = new bool[] {false} ;
         T001L8_A620IsVersionDeleted = new bool[] {false} ;
         T001L8_A622VersionDeletedAt = new DateTime[] {DateTime.MinValue} ;
         T001L8_n622VersionDeletedAt = new bool[] {false} ;
         T001L8_A648AppVersionLanguage = new string[] {""} ;
         T001L8_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001L8_n11OrganisationId = new bool[] {false} ;
         T001L8_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T001L8_A29LocationId = new Guid[] {Guid.Empty} ;
         T001L8_n29LocationId = new bool[] {false} ;
         T001L7_A29LocationId = new Guid[] {Guid.Empty} ;
         T001L7_n29LocationId = new bool[] {false} ;
         T001L6_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T001L9_A29LocationId = new Guid[] {Guid.Empty} ;
         T001L9_n29LocationId = new bool[] {false} ;
         T001L10_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T001L11_A523AppVersionId = new Guid[] {Guid.Empty} ;
         T001L5_A523AppVersionId = new Guid[] {Guid.Empty} ;
         T001L5_A524AppVersionName = new string[] {""} ;
         T001L5_A535IsActive = new bool[] {false} ;
         T001L5_A620IsVersionDeleted = new bool[] {false} ;
         T001L5_A622VersionDeletedAt = new DateTime[] {DateTime.MinValue} ;
         T001L5_n622VersionDeletedAt = new bool[] {false} ;
         T001L5_A648AppVersionLanguage = new string[] {""} ;
         T001L5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001L5_n11OrganisationId = new bool[] {false} ;
         T001L5_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T001L5_A29LocationId = new Guid[] {Guid.Empty} ;
         T001L5_n29LocationId = new bool[] {false} ;
         T001L12_A523AppVersionId = new Guid[] {Guid.Empty} ;
         T001L13_A523AppVersionId = new Guid[] {Guid.Empty} ;
         T001L4_A523AppVersionId = new Guid[] {Guid.Empty} ;
         T001L4_A524AppVersionName = new string[] {""} ;
         T001L4_A535IsActive = new bool[] {false} ;
         T001L4_A620IsVersionDeleted = new bool[] {false} ;
         T001L4_A622VersionDeletedAt = new DateTime[] {DateTime.MinValue} ;
         T001L4_n622VersionDeletedAt = new bool[] {false} ;
         T001L4_A648AppVersionLanguage = new string[] {""} ;
         T001L4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001L4_n11OrganisationId = new bool[] {false} ;
         T001L4_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T001L4_A29LocationId = new Guid[] {Guid.Empty} ;
         T001L4_n29LocationId = new bool[] {false} ;
         T001L17_A29LocationId = new Guid[] {Guid.Empty} ;
         T001L17_n29LocationId = new bool[] {false} ;
         T001L17_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001L17_n11OrganisationId = new bool[] {false} ;
         T001L18_A29LocationId = new Guid[] {Guid.Empty} ;
         T001L18_n29LocationId = new bool[] {false} ;
         T001L18_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001L18_n11OrganisationId = new bool[] {false} ;
         T001L19_A523AppVersionId = new Guid[] {Guid.Empty} ;
         Z518PageStructure = "";
         Z536PagePublishedStructure = "";
         Z600PageThumbnail = "";
         Z40000PageThumbnail_GXI = "";
         T001L20_A523AppVersionId = new Guid[] {Guid.Empty} ;
         T001L20_A516PageId = new Guid[] {Guid.Empty} ;
         T001L20_A541IsPredefined = new bool[] {false} ;
         T001L20_A517PageName = new string[] {""} ;
         T001L20_A518PageStructure = new string[] {""} ;
         T001L20_A536PagePublishedStructure = new string[] {""} ;
         T001L20_A40000PageThumbnail_GXI = new string[] {""} ;
         T001L20_n40000PageThumbnail_GXI = new bool[] {false} ;
         T001L20_A525PageType = new string[] {""} ;
         T001L20_A621IsPageDeleted = new bool[] {false} ;
         T001L20_A623PageDeletedAt = new DateTime[] {DateTime.MinValue} ;
         T001L20_n623PageDeletedAt = new bool[] {false} ;
         T001L20_A600PageThumbnail = new string[] {""} ;
         T001L20_n600PageThumbnail = new bool[] {false} ;
         T001L21_A523AppVersionId = new Guid[] {Guid.Empty} ;
         T001L21_A516PageId = new Guid[] {Guid.Empty} ;
         T001L3_A523AppVersionId = new Guid[] {Guid.Empty} ;
         T001L3_A516PageId = new Guid[] {Guid.Empty} ;
         T001L3_A541IsPredefined = new bool[] {false} ;
         T001L3_A517PageName = new string[] {""} ;
         T001L3_A518PageStructure = new string[] {""} ;
         T001L3_A536PagePublishedStructure = new string[] {""} ;
         T001L3_A40000PageThumbnail_GXI = new string[] {""} ;
         T001L3_n40000PageThumbnail_GXI = new bool[] {false} ;
         T001L3_A525PageType = new string[] {""} ;
         T001L3_A621IsPageDeleted = new bool[] {false} ;
         T001L3_A623PageDeletedAt = new DateTime[] {DateTime.MinValue} ;
         T001L3_n623PageDeletedAt = new bool[] {false} ;
         T001L3_A600PageThumbnail = new string[] {""} ;
         T001L3_n600PageThumbnail = new bool[] {false} ;
         T001L2_A523AppVersionId = new Guid[] {Guid.Empty} ;
         T001L2_A516PageId = new Guid[] {Guid.Empty} ;
         T001L2_A541IsPredefined = new bool[] {false} ;
         T001L2_A517PageName = new string[] {""} ;
         T001L2_A518PageStructure = new string[] {""} ;
         T001L2_A536PagePublishedStructure = new string[] {""} ;
         T001L2_A40000PageThumbnail_GXI = new string[] {""} ;
         T001L2_n40000PageThumbnail_GXI = new bool[] {false} ;
         T001L2_A525PageType = new string[] {""} ;
         T001L2_A621IsPageDeleted = new bool[] {false} ;
         T001L2_A623PageDeletedAt = new DateTime[] {DateTime.MinValue} ;
         T001L2_n623PageDeletedAt = new bool[] {false} ;
         T001L2_A600PageThumbnail = new string[] {""} ;
         T001L2_n600PageThumbnail = new bool[] {false} ;
         T001L26_A523AppVersionId = new Guid[] {Guid.Empty} ;
         T001L26_A516PageId = new Guid[] {Guid.Empty} ;
         Gridlevel_pageRow = new GXWebRow();
         subGridlevel_page_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         Gridlevel_pageColumn = new GXWebColumn();
         GXt_guid1 = Guid.Empty;
         T001L27_A29LocationId = new Guid[] {Guid.Empty} ;
         T001L27_n29LocationId = new bool[] {false} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_appversion__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_appversion__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_appversion__default(),
            new Object[][] {
                new Object[] {
               T001L2_A523AppVersionId, T001L2_A516PageId, T001L2_A541IsPredefined, T001L2_A517PageName, T001L2_A518PageStructure, T001L2_A536PagePublishedStructure, T001L2_A40000PageThumbnail_GXI, T001L2_n40000PageThumbnail_GXI, T001L2_A525PageType, T001L2_A621IsPageDeleted,
               T001L2_A623PageDeletedAt, T001L2_n623PageDeletedAt, T001L2_A600PageThumbnail, T001L2_n600PageThumbnail
               }
               , new Object[] {
               T001L3_A523AppVersionId, T001L3_A516PageId, T001L3_A541IsPredefined, T001L3_A517PageName, T001L3_A518PageStructure, T001L3_A536PagePublishedStructure, T001L3_A40000PageThumbnail_GXI, T001L3_n40000PageThumbnail_GXI, T001L3_A525PageType, T001L3_A621IsPageDeleted,
               T001L3_A623PageDeletedAt, T001L3_n623PageDeletedAt, T001L3_A600PageThumbnail, T001L3_n600PageThumbnail
               }
               , new Object[] {
               T001L4_A523AppVersionId, T001L4_A524AppVersionName, T001L4_A535IsActive, T001L4_A620IsVersionDeleted, T001L4_A622VersionDeletedAt, T001L4_n622VersionDeletedAt, T001L4_A648AppVersionLanguage, T001L4_A11OrganisationId, T001L4_n11OrganisationId, T001L4_A273Trn_ThemeId,
               T001L4_A29LocationId, T001L4_n29LocationId
               }
               , new Object[] {
               T001L5_A523AppVersionId, T001L5_A524AppVersionName, T001L5_A535IsActive, T001L5_A620IsVersionDeleted, T001L5_A622VersionDeletedAt, T001L5_n622VersionDeletedAt, T001L5_A648AppVersionLanguage, T001L5_A11OrganisationId, T001L5_n11OrganisationId, T001L5_A273Trn_ThemeId,
               T001L5_A29LocationId, T001L5_n29LocationId
               }
               , new Object[] {
               T001L6_A273Trn_ThemeId
               }
               , new Object[] {
               T001L7_A29LocationId
               }
               , new Object[] {
               T001L8_A523AppVersionId, T001L8_A524AppVersionName, T001L8_A535IsActive, T001L8_A620IsVersionDeleted, T001L8_A622VersionDeletedAt, T001L8_n622VersionDeletedAt, T001L8_A648AppVersionLanguage, T001L8_A11OrganisationId, T001L8_n11OrganisationId, T001L8_A273Trn_ThemeId,
               T001L8_A29LocationId, T001L8_n29LocationId
               }
               , new Object[] {
               T001L9_A29LocationId
               }
               , new Object[] {
               T001L10_A273Trn_ThemeId
               }
               , new Object[] {
               T001L11_A523AppVersionId
               }
               , new Object[] {
               T001L12_A523AppVersionId
               }
               , new Object[] {
               T001L13_A523AppVersionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001L17_A29LocationId, T001L17_A11OrganisationId
               }
               , new Object[] {
               T001L18_A29LocationId, T001L18_A11OrganisationId
               }
               , new Object[] {
               T001L19_A523AppVersionId
               }
               , new Object[] {
               T001L20_A523AppVersionId, T001L20_A516PageId, T001L20_A541IsPredefined, T001L20_A517PageName, T001L20_A518PageStructure, T001L20_A536PagePublishedStructure, T001L20_A40000PageThumbnail_GXI, T001L20_n40000PageThumbnail_GXI, T001L20_A525PageType, T001L20_A621IsPageDeleted,
               T001L20_A623PageDeletedAt, T001L20_n623PageDeletedAt, T001L20_A600PageThumbnail, T001L20_n600PageThumbnail
               }
               , new Object[] {
               T001L21_A523AppVersionId, T001L21_A516PageId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001L26_A523AppVersionId, T001L26_A516PageId
               }
               , new Object[] {
               T001L27_A29LocationId
               }
            }
         );
         Z516PageId = Guid.NewGuid( );
         A516PageId = Guid.NewGuid( );
         Z523AppVersionId = Guid.NewGuid( );
         A523AppVersionId = Guid.NewGuid( );
         AV31Pgmname = "Trn_AppVersion";
         Z541IsPredefined = false;
         A541IsPredefined = false;
         i541IsPredefined = false;
      }

      private short nRcdDeleted_95 ;
      private short nRcdExists_95 ;
      private short nIsMod_95 ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short nBlankRcdCount95 ;
      private short RcdFound95 ;
      private short nBlankRcdUsr95 ;
      private short RcdFound94 ;
      private short nIsDirty_95 ;
      private short subGridlevel_page_Backcolorstyle ;
      private short subGridlevel_page_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridlevel_page_Allowselection ;
      private short subGridlevel_page_Allowhovering ;
      private short subGridlevel_page_Allowcollapsing ;
      private short subGridlevel_page_Collapsed ;
      private int nRC_GXsfl_47 ;
      private int nGXsfl_47_idx=1 ;
      private int trnEnded ;
      private int edtAppVersionId_Enabled ;
      private int edtAppVersionName_Enabled ;
      private int edtLocationId_Enabled ;
      private int edtOrganisationId_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtPageId_Enabled ;
      private int edtPageName_Enabled ;
      private int edtPageStructure_Enabled ;
      private int edtPagePublishedStructure_Enabled ;
      private int fRowAdded ;
      private int AV32GXV1 ;
      private int subGridlevel_page_Backcolor ;
      private int subGridlevel_page_Allbackcolor ;
      private int defedtPageId_Enabled ;
      private int idxLst ;
      private int subGridlevel_page_Selectedindex ;
      private int subGridlevel_page_Selectioncolor ;
      private int subGridlevel_page_Hoveringcolor ;
      private long GRIDLEVEL_PAGE_nFirstRecordOnPage ;
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
      private string edtAppVersionId_Internalname ;
      private string sGXsfl_47_idx="0001" ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtAppVersionId_Jsonclick ;
      private string edtAppVersionName_Internalname ;
      private string edtAppVersionName_Jsonclick ;
      private string edtLocationId_Internalname ;
      private string edtLocationId_Jsonclick ;
      private string edtOrganisationId_Internalname ;
      private string edtOrganisationId_Jsonclick ;
      private string chkIsActive_Internalname ;
      private string divTableleaflevel_page_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string sMode95 ;
      private string edtPageId_Internalname ;
      private string edtPageName_Internalname ;
      private string edtPageStructure_Internalname ;
      private string edtPagePublishedStructure_Internalname ;
      private string chkIsPredefined_Internalname ;
      private string cmbPageType_Internalname ;
      private string sStyleString ;
      private string subGridlevel_page_Internalname ;
      private string AV31Pgmname ;
      private string hsh ;
      private string sMode94 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string sGXsfl_47_fel_idx="0001" ;
      private string subGridlevel_page_Class ;
      private string subGridlevel_page_Linesclass ;
      private string ROClassString ;
      private string edtPageId_Jsonclick ;
      private string edtPageName_Jsonclick ;
      private string edtPageStructure_Jsonclick ;
      private string edtPagePublishedStructure_Jsonclick ;
      private string cmbPageType_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string subGridlevel_page_Header ;
      private DateTime Z622VersionDeletedAt ;
      private DateTime Z623PageDeletedAt ;
      private DateTime A622VersionDeletedAt ;
      private DateTime A623PageDeletedAt ;
      private bool Z535IsActive ;
      private bool Z620IsVersionDeleted ;
      private bool Z541IsPredefined ;
      private bool Z621IsPageDeleted ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n29LocationId ;
      private bool n11OrganisationId ;
      private bool wbErr ;
      private bool A535IsActive ;
      private bool bGXsfl_47_Refreshing=false ;
      private bool n622VersionDeletedAt ;
      private bool A620IsVersionDeleted ;
      private bool n600PageThumbnail ;
      private bool n40000PageThumbnail_GXI ;
      private bool A621IsPageDeleted ;
      private bool n623PageDeletedAt ;
      private bool A541IsPredefined ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool i541IsPredefined ;
      private string A518PageStructure ;
      private string A536PagePublishedStructure ;
      private string Z518PageStructure ;
      private string Z536PagePublishedStructure ;
      private string Z524AppVersionName ;
      private string Z648AppVersionLanguage ;
      private string Z517PageName ;
      private string Z525PageType ;
      private string A524AppVersionName ;
      private string A648AppVersionLanguage ;
      private string A40000PageThumbnail_GXI ;
      private string A517PageName ;
      private string A525PageType ;
      private string Z40000PageThumbnail_GXI ;
      private string A600PageThumbnail ;
      private string Z600PageThumbnail ;
      private Guid wcpOAV8AppVersionId ;
      private Guid Z523AppVersionId ;
      private Guid Z11OrganisationId ;
      private Guid Z273Trn_ThemeId ;
      private Guid Z29LocationId ;
      private Guid N29LocationId ;
      private Guid N11OrganisationId ;
      private Guid N273Trn_ThemeId ;
      private Guid Z516PageId ;
      private Guid AV29Insert_Trn_ThemeId ;
      private Guid A273Trn_ThemeId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid AV8AppVersionId ;
      private Guid A523AppVersionId ;
      private Guid A516PageId ;
      private Guid AV14Insert_LocationId ;
      private Guid AV15Insert_OrganisationId ;
      private Guid GXt_guid1 ;
      private IGxSession AV13WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_pageContainer ;
      private GXWebRow Gridlevel_pageRow ;
      private GXWebColumn Gridlevel_pageColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkIsActive ;
      private GXCheckbox chkIsPredefined ;
      private GXCombobox cmbPageType ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV12TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV16TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private Guid[] T001L8_A523AppVersionId ;
      private string[] T001L8_A524AppVersionName ;
      private bool[] T001L8_A535IsActive ;
      private bool[] T001L8_A620IsVersionDeleted ;
      private DateTime[] T001L8_A622VersionDeletedAt ;
      private bool[] T001L8_n622VersionDeletedAt ;
      private string[] T001L8_A648AppVersionLanguage ;
      private Guid[] T001L8_A11OrganisationId ;
      private bool[] T001L8_n11OrganisationId ;
      private Guid[] T001L8_A273Trn_ThemeId ;
      private Guid[] T001L8_A29LocationId ;
      private bool[] T001L8_n29LocationId ;
      private Guid[] T001L7_A29LocationId ;
      private bool[] T001L7_n29LocationId ;
      private Guid[] T001L6_A273Trn_ThemeId ;
      private Guid[] T001L9_A29LocationId ;
      private bool[] T001L9_n29LocationId ;
      private Guid[] T001L10_A273Trn_ThemeId ;
      private Guid[] T001L11_A523AppVersionId ;
      private Guid[] T001L5_A523AppVersionId ;
      private string[] T001L5_A524AppVersionName ;
      private bool[] T001L5_A535IsActive ;
      private bool[] T001L5_A620IsVersionDeleted ;
      private DateTime[] T001L5_A622VersionDeletedAt ;
      private bool[] T001L5_n622VersionDeletedAt ;
      private string[] T001L5_A648AppVersionLanguage ;
      private Guid[] T001L5_A11OrganisationId ;
      private bool[] T001L5_n11OrganisationId ;
      private Guid[] T001L5_A273Trn_ThemeId ;
      private Guid[] T001L5_A29LocationId ;
      private bool[] T001L5_n29LocationId ;
      private Guid[] T001L12_A523AppVersionId ;
      private Guid[] T001L13_A523AppVersionId ;
      private Guid[] T001L4_A523AppVersionId ;
      private string[] T001L4_A524AppVersionName ;
      private bool[] T001L4_A535IsActive ;
      private bool[] T001L4_A620IsVersionDeleted ;
      private DateTime[] T001L4_A622VersionDeletedAt ;
      private bool[] T001L4_n622VersionDeletedAt ;
      private string[] T001L4_A648AppVersionLanguage ;
      private Guid[] T001L4_A11OrganisationId ;
      private bool[] T001L4_n11OrganisationId ;
      private Guid[] T001L4_A273Trn_ThemeId ;
      private Guid[] T001L4_A29LocationId ;
      private bool[] T001L4_n29LocationId ;
      private Guid[] T001L17_A29LocationId ;
      private bool[] T001L17_n29LocationId ;
      private Guid[] T001L17_A11OrganisationId ;
      private bool[] T001L17_n11OrganisationId ;
      private Guid[] T001L18_A29LocationId ;
      private bool[] T001L18_n29LocationId ;
      private Guid[] T001L18_A11OrganisationId ;
      private bool[] T001L18_n11OrganisationId ;
      private Guid[] T001L19_A523AppVersionId ;
      private Guid[] T001L20_A523AppVersionId ;
      private Guid[] T001L20_A516PageId ;
      private bool[] T001L20_A541IsPredefined ;
      private string[] T001L20_A517PageName ;
      private string[] T001L20_A518PageStructure ;
      private string[] T001L20_A536PagePublishedStructure ;
      private string[] T001L20_A40000PageThumbnail_GXI ;
      private bool[] T001L20_n40000PageThumbnail_GXI ;
      private string[] T001L20_A525PageType ;
      private bool[] T001L20_A621IsPageDeleted ;
      private DateTime[] T001L20_A623PageDeletedAt ;
      private bool[] T001L20_n623PageDeletedAt ;
      private string[] T001L20_A600PageThumbnail ;
      private bool[] T001L20_n600PageThumbnail ;
      private Guid[] T001L21_A523AppVersionId ;
      private Guid[] T001L21_A516PageId ;
      private Guid[] T001L3_A523AppVersionId ;
      private Guid[] T001L3_A516PageId ;
      private bool[] T001L3_A541IsPredefined ;
      private string[] T001L3_A517PageName ;
      private string[] T001L3_A518PageStructure ;
      private string[] T001L3_A536PagePublishedStructure ;
      private string[] T001L3_A40000PageThumbnail_GXI ;
      private bool[] T001L3_n40000PageThumbnail_GXI ;
      private string[] T001L3_A525PageType ;
      private bool[] T001L3_A621IsPageDeleted ;
      private DateTime[] T001L3_A623PageDeletedAt ;
      private bool[] T001L3_n623PageDeletedAt ;
      private string[] T001L3_A600PageThumbnail ;
      private bool[] T001L3_n600PageThumbnail ;
      private Guid[] T001L2_A523AppVersionId ;
      private Guid[] T001L2_A516PageId ;
      private bool[] T001L2_A541IsPredefined ;
      private string[] T001L2_A517PageName ;
      private string[] T001L2_A518PageStructure ;
      private string[] T001L2_A536PagePublishedStructure ;
      private string[] T001L2_A40000PageThumbnail_GXI ;
      private bool[] T001L2_n40000PageThumbnail_GXI ;
      private string[] T001L2_A525PageType ;
      private bool[] T001L2_A621IsPageDeleted ;
      private DateTime[] T001L2_A623PageDeletedAt ;
      private bool[] T001L2_n623PageDeletedAt ;
      private string[] T001L2_A600PageThumbnail ;
      private bool[] T001L2_n600PageThumbnail ;
      private Guid[] T001L26_A523AppVersionId ;
      private Guid[] T001L26_A516PageId ;
      private Guid[] T001L27_A29LocationId ;
      private bool[] T001L27_n29LocationId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_appversion__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_appversion__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_appversion__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[7])
      ,new ForEachCursor(def[8])
      ,new ForEachCursor(def[9])
      ,new ForEachCursor(def[10])
      ,new ForEachCursor(def[11])
      ,new UpdateCursor(def[12])
      ,new UpdateCursor(def[13])
      ,new UpdateCursor(def[14])
      ,new ForEachCursor(def[15])
      ,new ForEachCursor(def[16])
      ,new ForEachCursor(def[17])
      ,new ForEachCursor(def[18])
      ,new ForEachCursor(def[19])
      ,new UpdateCursor(def[20])
      ,new UpdateCursor(def[21])
      ,new UpdateCursor(def[22])
      ,new UpdateCursor(def[23])
      ,new ForEachCursor(def[24])
      ,new ForEachCursor(def[25])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT001L2;
       prmT001L2 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L3;
       prmT001L3 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L4;
       prmT001L4 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L5;
       prmT001L5 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L6;
       prmT001L6 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L7;
       prmT001L7 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT001L8;
       prmT001L8 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L9;
       prmT001L9 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT001L10;
       prmT001L10 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L11;
       prmT001L11 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L12;
       prmT001L12 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L13;
       prmT001L13 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L14;
       prmT001L14 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AppVersionName",GXType.VarChar,100,0) ,
       new ParDef("IsActive",GXType.Boolean,4,0) ,
       new ParDef("IsVersionDeleted",GXType.Boolean,4,0) ,
       new ParDef("VersionDeletedAt",GXType.DateTime,8,5){Nullable=true} ,
       new ParDef("AppVersionLanguage",GXType.VarChar,40,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT001L15;
       prmT001L15 = new Object[] {
       new ParDef("AppVersionName",GXType.VarChar,100,0) ,
       new ParDef("IsActive",GXType.Boolean,4,0) ,
       new ParDef("IsVersionDeleted",GXType.Boolean,4,0) ,
       new ParDef("VersionDeletedAt",GXType.DateTime,8,5){Nullable=true} ,
       new ParDef("AppVersionLanguage",GXType.VarChar,40,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L16;
       prmT001L16 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L17;
       prmT001L17 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L18;
       prmT001L18 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L19;
       prmT001L19 = new Object[] {
       };
       Object[] prmT001L20;
       prmT001L20 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L21;
       prmT001L21 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L22;
       prmT001L22 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("IsPredefined",GXType.Boolean,4,0) ,
       new ParDef("PageName",GXType.VarChar,100,0) ,
       new ParDef("PageStructure",GXType.LongVarChar,2097152,0) ,
       new ParDef("PagePublishedStructure",GXType.LongVarChar,2097152,0) ,
       new ParDef("PageThumbnail",GXType.Byte,1024,0){Nullable=true,InDB=false} ,
       new ParDef("PageThumbnail_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=6, Tbl="Trn_AppVersionPage", Fld="PageThumbnail"} ,
       new ParDef("PageType",GXType.VarChar,40,0) ,
       new ParDef("IsPageDeleted",GXType.Boolean,4,0) ,
       new ParDef("PageDeletedAt",GXType.DateTime,8,5){Nullable=true}
       };
       Object[] prmT001L23;
       prmT001L23 = new Object[] {
       new ParDef("IsPredefined",GXType.Boolean,4,0) ,
       new ParDef("PageName",GXType.VarChar,100,0) ,
       new ParDef("PageStructure",GXType.LongVarChar,2097152,0) ,
       new ParDef("PagePublishedStructure",GXType.LongVarChar,2097152,0) ,
       new ParDef("PageType",GXType.VarChar,40,0) ,
       new ParDef("IsPageDeleted",GXType.Boolean,4,0) ,
       new ParDef("PageDeletedAt",GXType.DateTime,8,5){Nullable=true} ,
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L24;
       prmT001L24 = new Object[] {
       new ParDef("PageThumbnail",GXType.Byte,1024,0){Nullable=true,InDB=false} ,
       new ParDef("PageThumbnail_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="Trn_AppVersionPage", Fld="PageThumbnail"} ,
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L25;
       prmT001L25 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L26;
       prmT001L26 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L27;
       prmT001L27 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       def= new CursorDef[] {
           new CursorDef("T001L2", "SELECT AppVersionId, PageId, IsPredefined, PageName, PageStructure, PagePublishedStructure, PageThumbnail_GXI, PageType, IsPageDeleted, PageDeletedAt, PageThumbnail FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId AND PageId = :PageId  FOR UPDATE OF Trn_AppVersionPage NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001L2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L3", "SELECT AppVersionId, PageId, IsPredefined, PageName, PageStructure, PagePublishedStructure, PageThumbnail_GXI, PageType, IsPageDeleted, PageDeletedAt, PageThumbnail FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId AND PageId = :PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L4", "SELECT AppVersionId, AppVersionName, IsActive, IsVersionDeleted, VersionDeletedAt, AppVersionLanguage, OrganisationId, Trn_ThemeId, LocationId FROM Trn_AppVersion WHERE AppVersionId = :AppVersionId  FOR UPDATE OF Trn_AppVersion NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001L4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L5", "SELECT AppVersionId, AppVersionName, IsActive, IsVersionDeleted, VersionDeletedAt, AppVersionLanguage, OrganisationId, Trn_ThemeId, LocationId FROM Trn_AppVersion WHERE AppVersionId = :AppVersionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L6", "SELECT Trn_ThemeId FROM Trn_Theme WHERE Trn_ThemeId = :Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L7", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L8", "SELECT TM1.AppVersionId, TM1.AppVersionName, TM1.IsActive, TM1.IsVersionDeleted, TM1.VersionDeletedAt, TM1.AppVersionLanguage, TM1.OrganisationId, TM1.Trn_ThemeId, TM1.LocationId FROM Trn_AppVersion TM1 WHERE TM1.AppVersionId = :AppVersionId ORDER BY TM1.AppVersionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L8,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L9", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L9,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L10", "SELECT Trn_ThemeId FROM Trn_Theme WHERE Trn_ThemeId = :Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L10,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L11", "SELECT AppVersionId FROM Trn_AppVersion WHERE AppVersionId = :AppVersionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L11,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L12", "SELECT AppVersionId FROM Trn_AppVersion WHERE ( AppVersionId > :AppVersionId) ORDER BY AppVersionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L12,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001L13", "SELECT AppVersionId FROM Trn_AppVersion WHERE ( AppVersionId < :AppVersionId) ORDER BY AppVersionId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L13,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001L14", "SAVEPOINT gxupdate;INSERT INTO Trn_AppVersion(AppVersionId, AppVersionName, IsActive, IsVersionDeleted, VersionDeletedAt, AppVersionLanguage, OrganisationId, Trn_ThemeId, LocationId) VALUES(:AppVersionId, :AppVersionName, :IsActive, :IsVersionDeleted, :VersionDeletedAt, :AppVersionLanguage, :OrganisationId, :Trn_ThemeId, :LocationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001L14)
          ,new CursorDef("T001L15", "SAVEPOINT gxupdate;UPDATE Trn_AppVersion SET AppVersionName=:AppVersionName, IsActive=:IsActive, IsVersionDeleted=:IsVersionDeleted, VersionDeletedAt=:VersionDeletedAt, AppVersionLanguage=:AppVersionLanguage, OrganisationId=:OrganisationId, Trn_ThemeId=:Trn_ThemeId, LocationId=:LocationId  WHERE AppVersionId = :AppVersionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001L15)
          ,new CursorDef("T001L16", "SAVEPOINT gxupdate;DELETE FROM Trn_AppVersion  WHERE AppVersionId = :AppVersionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001L16)
          ,new CursorDef("T001L17", "SELECT LocationId, OrganisationId FROM Trn_Location WHERE PublishedActiveAppVersionId = :AppVersionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L17,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001L18", "SELECT LocationId, OrganisationId FROM Trn_Location WHERE ActiveAppVersionId = :AppVersionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L18,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001L19", "SELECT AppVersionId FROM Trn_AppVersion ORDER BY AppVersionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L19,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L20", "SELECT AppVersionId, PageId, IsPredefined, PageName, PageStructure, PagePublishedStructure, PageThumbnail_GXI, PageType, IsPageDeleted, PageDeletedAt, PageThumbnail FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId and PageId = :PageId ORDER BY AppVersionId, PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L20,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L21", "SELECT AppVersionId, PageId FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId AND PageId = :PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L21,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L22", "SAVEPOINT gxupdate;INSERT INTO Trn_AppVersionPage(AppVersionId, PageId, IsPredefined, PageName, PageStructure, PagePublishedStructure, PageThumbnail, PageThumbnail_GXI, PageType, IsPageDeleted, PageDeletedAt) VALUES(:AppVersionId, :PageId, :IsPredefined, :PageName, :PageStructure, :PagePublishedStructure, :PageThumbnail, :PageThumbnail_GXI, :PageType, :IsPageDeleted, :PageDeletedAt);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001L22)
          ,new CursorDef("T001L23", "SAVEPOINT gxupdate;UPDATE Trn_AppVersionPage SET IsPredefined=:IsPredefined, PageName=:PageName, PageStructure=:PageStructure, PagePublishedStructure=:PagePublishedStructure, PageType=:PageType, IsPageDeleted=:IsPageDeleted, PageDeletedAt=:PageDeletedAt  WHERE AppVersionId = :AppVersionId AND PageId = :PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001L23)
          ,new CursorDef("T001L24", "SAVEPOINT gxupdate;UPDATE Trn_AppVersionPage SET PageThumbnail=:PageThumbnail, PageThumbnail_GXI=:PageThumbnail_GXI  WHERE AppVersionId = :AppVersionId AND PageId = :PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001L24)
          ,new CursorDef("T001L25", "SAVEPOINT gxupdate;DELETE FROM Trn_AppVersionPage  WHERE AppVersionId = :AppVersionId AND PageId = :PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001L25)
          ,new CursorDef("T001L26", "SELECT AppVersionId, PageId FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId ORDER BY AppVersionId, PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L26,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L27", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L27,1, GxCacheFrequency.OFF ,true,false )
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
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
             ((bool[]) buf[7])[0] = rslt.wasNull(7);
             ((string[]) buf[8])[0] = rslt.getVarchar(8);
             ((bool[]) buf[9])[0] = rslt.getBool(9);
             ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(10);
             ((bool[]) buf[11])[0] = rslt.wasNull(10);
             ((string[]) buf[12])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(7));
             ((bool[]) buf[13])[0] = rslt.wasNull(11);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
             ((bool[]) buf[7])[0] = rslt.wasNull(7);
             ((string[]) buf[8])[0] = rslt.getVarchar(8);
             ((bool[]) buf[9])[0] = rslt.getBool(9);
             ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(10);
             ((bool[]) buf[11])[0] = rslt.wasNull(10);
             ((string[]) buf[12])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(7));
             ((bool[]) buf[13])[0] = rslt.wasNull(11);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
             ((bool[]) buf[5])[0] = rslt.wasNull(5);
             ((string[]) buf[6])[0] = rslt.getVarchar(6);
             ((Guid[]) buf[7])[0] = rslt.getGuid(7);
             ((bool[]) buf[8])[0] = rslt.wasNull(7);
             ((Guid[]) buf[9])[0] = rslt.getGuid(8);
             ((Guid[]) buf[10])[0] = rslt.getGuid(9);
             ((bool[]) buf[11])[0] = rslt.wasNull(9);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
             ((bool[]) buf[5])[0] = rslt.wasNull(5);
             ((string[]) buf[6])[0] = rslt.getVarchar(6);
             ((Guid[]) buf[7])[0] = rslt.getGuid(7);
             ((bool[]) buf[8])[0] = rslt.wasNull(7);
             ((Guid[]) buf[9])[0] = rslt.getGuid(8);
             ((Guid[]) buf[10])[0] = rslt.getGuid(9);
             ((bool[]) buf[11])[0] = rslt.wasNull(9);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 6 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
             ((bool[]) buf[5])[0] = rslt.wasNull(5);
             ((string[]) buf[6])[0] = rslt.getVarchar(6);
             ((Guid[]) buf[7])[0] = rslt.getGuid(7);
             ((bool[]) buf[8])[0] = rslt.wasNull(7);
             ((Guid[]) buf[9])[0] = rslt.getGuid(8);
             ((Guid[]) buf[10])[0] = rslt.getGuid(9);
             ((bool[]) buf[11])[0] = rslt.wasNull(9);
             return;
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 9 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 10 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 11 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 15 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 16 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 17 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 18 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
             ((bool[]) buf[7])[0] = rslt.wasNull(7);
             ((string[]) buf[8])[0] = rslt.getVarchar(8);
             ((bool[]) buf[9])[0] = rslt.getBool(9);
             ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(10);
             ((bool[]) buf[11])[0] = rslt.wasNull(10);
             ((string[]) buf[12])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(7));
             ((bool[]) buf[13])[0] = rslt.wasNull(11);
             return;
          case 19 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 24 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 25 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
