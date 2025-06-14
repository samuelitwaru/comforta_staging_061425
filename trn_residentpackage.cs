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
   public class trn_residentpackage : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action18") == 0 )
         {
            A527ResidentPackageId = StringUtil.StrToGuid( GetPar( "ResidentPackageId"));
            n527ResidentPackageId = false;
            AssignAttri("", false, "A527ResidentPackageId", A527ResidentPackageId.ToString());
            A528SG_LocationId = StringUtil.StrToGuid( GetPar( "SG_LocationId"));
            AssignAttri("", false, "A528SG_LocationId", A528SG_LocationId.ToString());
            A533ResidentPackageDefault = StringUtil.StrToBool( GetPar( "ResidentPackageDefault"));
            AssignAttri("", false, "A533ResidentPackageDefault", A533ResidentPackageDefault);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_18_1M96( A527ResidentPackageId, A528SG_LocationId, A533ResidentPackageDefault) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel8"+"_"+"SG_LOCATIONID") == 0 )
         {
            AV32Insert_SG_LocationId = StringUtil.StrToGuid( GetPar( "Insert_SG_LocationId"));
            AssignAttri("", false, "AV32Insert_SG_LocationId", AV32Insert_SG_LocationId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX8ASASG_LOCATIONID1M96( AV32Insert_SG_LocationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel10"+"_"+"SG_ORGANISATIONID") == 0 )
         {
            AV33Insert_SG_OrganisationId = StringUtil.StrToGuid( GetPar( "Insert_SG_OrganisationId"));
            AssignAttri("", false, "AV33Insert_SG_OrganisationId", AV33Insert_SG_OrganisationId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX10ASASG_ORGANISATIONID1M96( AV33Insert_SG_OrganisationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_20") == 0 )
         {
            A528SG_LocationId = StringUtil.StrToGuid( GetPar( "SG_LocationId"));
            AssignAttri("", false, "A528SG_LocationId", A528SG_LocationId.ToString());
            A529SG_OrganisationId = StringUtil.StrToGuid( GetPar( "SG_OrganisationId"));
            AssignAttri("", false, "A529SG_OrganisationId", A529SG_OrganisationId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_20( A528SG_LocationId, A529SG_OrganisationId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_residentpackage.aspx")), "trn_residentpackage.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_residentpackage.aspx")))) ;
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
                  AV7ResidentPackageId = StringUtil.StrToGuid( GetPar( "ResidentPackageId"));
                  AssignAttri("", false, "AV7ResidentPackageId", AV7ResidentPackageId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vRESIDENTPACKAGEID", GetSecureSignedToken( "", AV7ResidentPackageId, context));
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
         Form.Meta.addItem("description", context.GetMessage( "App Access Rights", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtResidentPackageName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_residentpackage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_residentpackage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_ResidentPackageId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ResidentPackageId = aP1_ResidentPackageId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkResidentPackageDefault = new GXCheckbox();
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
            return "trn_residentpackage_Execute" ;
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
         A533ResidentPackageDefault = StringUtil.StrToBool( StringUtil.BoolToStr( A533ResidentPackageDefault));
         AssignAttri("", false, "A533ResidentPackageDefault", A533ResidentPackageDefault);
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
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_ResidentPackage.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentPackageName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentPackageName_Internalname, context.GetMessage( "Access Rights Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentPackageName_Internalname, A531ResidentPackageName, StringUtil.RTrim( context.localUtil.Format( A531ResidentPackageName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentPackageName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentPackageName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_ResidentPackage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedresidentpackagemodules_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockresidentpackagemodules_Internalname, context.GetMessage( "Access rights", ""), "", "", lblTextblockresidentpackagemodules_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_ResidentPackage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_residentpackagemodules.SetProperty("Caption", Combo_residentpackagemodules_Caption);
         ucCombo_residentpackagemodules.SetProperty("Cls", Combo_residentpackagemodules_Cls);
         ucCombo_residentpackagemodules.SetProperty("AllowMultipleSelection", Combo_residentpackagemodules_Allowmultipleselection);
         ucCombo_residentpackagemodules.SetProperty("IncludeOnlySelectedOption", Combo_residentpackagemodules_Includeonlyselectedoption);
         ucCombo_residentpackagemodules.SetProperty("EmptyItem", Combo_residentpackagemodules_Emptyitem);
         ucCombo_residentpackagemodules.SetProperty("MultipleValuesType", Combo_residentpackagemodules_Multiplevaluestype);
         ucCombo_residentpackagemodules.SetProperty("DropDownOptionsTitleSettingsIcons", AV19DDO_TitleSettingsIcons);
         ucCombo_residentpackagemodules.SetProperty("DropDownOptionsData", AV18ResidentPackageModules_Data);
         ucCombo_residentpackagemodules.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_residentpackagemodules_Internalname, "COMBO_RESIDENTPACKAGEMODULESContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentPackageModules_Internalname, context.GetMessage( "Resident Package Modules", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtResidentPackageModules_Internalname, A532ResidentPackageModules, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", 0, 1, edtResidentPackageModules_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_ResidentPackage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         GxWebStd.gx_label_element( context, chkResidentPackageDefault_Internalname, " ", "col-sm-4 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkResidentPackageDefault_Internalname, StringUtil.BoolToStr( A533ResidentPackageDefault), "", " ", 1, chkResidentPackageDefault.Enabled, "true", context.GetMessage( "Default access rights", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(37, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,37);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ResidentPackage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ResidentPackage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ResidentPackage.htm");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_residentpackagemodules_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtavComboresidentpackagemodules_Internalname, AV22ComboResidentPackageModules, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", 0, edtavComboresidentpackagemodules_Visible, edtavComboresidentpackagemodules_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_ResidentPackage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentPackageId_Internalname, A527ResidentPackageId.ToString(), A527ResidentPackageId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentPackageId_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentPackageId_Visible, edtResidentPackageId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_ResidentPackage.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSG_OrganisationId_Internalname, A529SG_OrganisationId.ToString(), A529SG_OrganisationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSG_OrganisationId_Jsonclick, 0, "Attribute", "", "", "", "", edtSG_OrganisationId_Visible, edtSG_OrganisationId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_ResidentPackage.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSG_LocationId_Internalname, A528SG_LocationId.ToString(), A528SG_LocationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSG_LocationId_Jsonclick, 0, "Attribute", "", "", "", "", edtSG_LocationId_Visible, edtSG_LocationId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_ResidentPackage.htm");
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
         E111M2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV19DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vRESIDENTPACKAGEMODULES_DATA"), AV18ResidentPackageModules_Data);
               /* Read saved values. */
               Z527ResidentPackageId = StringUtil.StrToGuid( cgiGet( "Z527ResidentPackageId"));
               Z531ResidentPackageName = cgiGet( "Z531ResidentPackageName");
               Z533ResidentPackageDefault = StringUtil.StrToBool( cgiGet( "Z533ResidentPackageDefault"));
               Z528SG_LocationId = StringUtil.StrToGuid( cgiGet( "Z528SG_LocationId"));
               Z529SG_OrganisationId = StringUtil.StrToGuid( cgiGet( "Z529SG_OrganisationId"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N528SG_LocationId = StringUtil.StrToGuid( cgiGet( "N528SG_LocationId"));
               N529SG_OrganisationId = StringUtil.StrToGuid( cgiGet( "N529SG_OrganisationId"));
               AV7ResidentPackageId = StringUtil.StrToGuid( cgiGet( "vRESIDENTPACKAGEID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV32Insert_SG_LocationId = StringUtil.StrToGuid( cgiGet( "vINSERT_SG_LOCATIONID"));
               AV33Insert_SG_OrganisationId = StringUtil.StrToGuid( cgiGet( "vINSERT_SG_ORGANISATIONID"));
               AV34Pgmname = cgiGet( "vPGMNAME");
               Combo_residentpackagemodules_Objectcall = cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Objectcall");
               Combo_residentpackagemodules_Class = cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Class");
               Combo_residentpackagemodules_Icontype = cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Icontype");
               Combo_residentpackagemodules_Icon = cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Icon");
               Combo_residentpackagemodules_Caption = cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Caption");
               Combo_residentpackagemodules_Tooltip = cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Tooltip");
               Combo_residentpackagemodules_Cls = cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Cls");
               Combo_residentpackagemodules_Selectedvalue_set = cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Selectedvalue_set");
               Combo_residentpackagemodules_Selectedvalue_get = cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Selectedvalue_get");
               Combo_residentpackagemodules_Selectedtext_set = cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Selectedtext_set");
               Combo_residentpackagemodules_Selectedtext_get = cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Selectedtext_get");
               Combo_residentpackagemodules_Gamoauthtoken = cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Gamoauthtoken");
               Combo_residentpackagemodules_Ddointernalname = cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Ddointernalname");
               Combo_residentpackagemodules_Titlecontrolalign = cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Titlecontrolalign");
               Combo_residentpackagemodules_Dropdownoptionstype = cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Dropdownoptionstype");
               Combo_residentpackagemodules_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Enabled"));
               Combo_residentpackagemodules_Visible = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Visible"));
               Combo_residentpackagemodules_Titlecontrolidtoreplace = cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Titlecontrolidtoreplace");
               Combo_residentpackagemodules_Datalisttype = cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Datalisttype");
               Combo_residentpackagemodules_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Allowmultipleselection"));
               Combo_residentpackagemodules_Datalistfixedvalues = cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Datalistfixedvalues");
               Combo_residentpackagemodules_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Isgriditem"));
               Combo_residentpackagemodules_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Hasdescription"));
               Combo_residentpackagemodules_Datalistproc = cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Datalistproc");
               Combo_residentpackagemodules_Datalistprocparametersprefix = cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Datalistprocparametersprefix");
               Combo_residentpackagemodules_Remoteservicesparameters = cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Remoteservicesparameters");
               Combo_residentpackagemodules_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_residentpackagemodules_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Includeonlyselectedoption"));
               Combo_residentpackagemodules_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Includeselectalloption"));
               Combo_residentpackagemodules_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Emptyitem"));
               Combo_residentpackagemodules_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Includeaddnewoption"));
               Combo_residentpackagemodules_Htmltemplate = cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Htmltemplate");
               Combo_residentpackagemodules_Multiplevaluestype = cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Multiplevaluestype");
               Combo_residentpackagemodules_Loadingdata = cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Loadingdata");
               Combo_residentpackagemodules_Noresultsfound = cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Noresultsfound");
               Combo_residentpackagemodules_Emptyitemtext = cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Emptyitemtext");
               Combo_residentpackagemodules_Onlyselectedvalues = cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Onlyselectedvalues");
               Combo_residentpackagemodules_Selectalltext = cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Selectalltext");
               Combo_residentpackagemodules_Multiplevaluesseparator = cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Multiplevaluesseparator");
               Combo_residentpackagemodules_Addnewoptiontext = cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Addnewoptiontext");
               Combo_residentpackagemodules_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_RESIDENTPACKAGEMODULES_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A531ResidentPackageName = cgiGet( edtResidentPackageName_Internalname);
               AssignAttri("", false, "A531ResidentPackageName", A531ResidentPackageName);
               A532ResidentPackageModules = cgiGet( edtResidentPackageModules_Internalname);
               AssignAttri("", false, "A532ResidentPackageModules", A532ResidentPackageModules);
               A533ResidentPackageDefault = StringUtil.StrToBool( cgiGet( chkResidentPackageDefault_Internalname));
               AssignAttri("", false, "A533ResidentPackageDefault", A533ResidentPackageDefault);
               AV22ComboResidentPackageModules = cgiGet( edtavComboresidentpackagemodules_Internalname);
               AssignAttri("", false, "AV22ComboResidentPackageModules", AV22ComboResidentPackageModules);
               if ( StringUtil.StrCmp(cgiGet( edtResidentPackageId_Internalname), "") == 0 )
               {
                  A527ResidentPackageId = Guid.Empty;
                  n527ResidentPackageId = false;
                  AssignAttri("", false, "A527ResidentPackageId", A527ResidentPackageId.ToString());
               }
               else
               {
                  try
                  {
                     A527ResidentPackageId = StringUtil.StrToGuid( cgiGet( edtResidentPackageId_Internalname));
                     n527ResidentPackageId = false;
                     AssignAttri("", false, "A527ResidentPackageId", A527ResidentPackageId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "RESIDENTPACKAGEID");
                     AnyError = 1;
                     GX_FocusControl = edtResidentPackageId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               if ( StringUtil.StrCmp(cgiGet( edtSG_OrganisationId_Internalname), "") == 0 )
               {
                  A529SG_OrganisationId = Guid.Empty;
                  AssignAttri("", false, "A529SG_OrganisationId", A529SG_OrganisationId.ToString());
               }
               else
               {
                  try
                  {
                     A529SG_OrganisationId = StringUtil.StrToGuid( cgiGet( edtSG_OrganisationId_Internalname));
                     AssignAttri("", false, "A529SG_OrganisationId", A529SG_OrganisationId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "SG_ORGANISATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtSG_OrganisationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               if ( StringUtil.StrCmp(cgiGet( edtSG_LocationId_Internalname), "") == 0 )
               {
                  A528SG_LocationId = Guid.Empty;
                  AssignAttri("", false, "A528SG_LocationId", A528SG_LocationId.ToString());
               }
               else
               {
                  try
                  {
                     A528SG_LocationId = StringUtil.StrToGuid( cgiGet( edtSG_LocationId_Internalname));
                     AssignAttri("", false, "A528SG_LocationId", A528SG_LocationId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "SG_LOCATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtSG_LocationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_ResidentPackage");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A527ResidentPackageId != Z527ResidentPackageId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_residentpackage:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A527ResidentPackageId = StringUtil.StrToGuid( GetPar( "ResidentPackageId"));
                  n527ResidentPackageId = false;
                  AssignAttri("", false, "A527ResidentPackageId", A527ResidentPackageId.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV7ResidentPackageId) )
                  {
                     A527ResidentPackageId = AV7ResidentPackageId;
                     n527ResidentPackageId = false;
                     AssignAttri("", false, "A527ResidentPackageId", A527ResidentPackageId.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A527ResidentPackageId) && ( Gx_BScreen == 0 ) )
                     {
                        A527ResidentPackageId = Guid.NewGuid( );
                        n527ResidentPackageId = false;
                        AssignAttri("", false, "A527ResidentPackageId", A527ResidentPackageId.ToString());
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
                     sMode96 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV7ResidentPackageId) )
                     {
                        A527ResidentPackageId = AV7ResidentPackageId;
                        n527ResidentPackageId = false;
                        AssignAttri("", false, "A527ResidentPackageId", A527ResidentPackageId.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A527ResidentPackageId) && ( Gx_BScreen == 0 ) )
                        {
                           A527ResidentPackageId = Guid.NewGuid( );
                           n527ResidentPackageId = false;
                           AssignAttri("", false, "A527ResidentPackageId", A527ResidentPackageId.ToString());
                        }
                     }
                     Gx_mode = sMode96;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound96 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1M0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "RESIDENTPACKAGEID");
                        AnyError = 1;
                        GX_FocusControl = edtResidentPackageId_Internalname;
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
                           E111M2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121M2 ();
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
            E121M2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1M96( ) ;
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
            DisableAttributes1M96( ) ;
         }
         AssignProp("", false, edtavComboresidentpackagemodules_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboresidentpackagemodules_Enabled), 5, 0), true);
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

      protected void CONFIRM_1M0( )
      {
         BeforeValidate1M96( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1M96( ) ;
            }
            else
            {
               CheckExtendedTable1M96( ) ;
               CloseExtendedTableCursors1M96( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption1M0( )
      {
      }

      protected void E111M2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV19DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV19DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV22ComboResidentPackageModules = "";
         AssignAttri("", false, "AV22ComboResidentPackageModules", AV22ComboResidentPackageModules);
         edtavComboresidentpackagemodules_Visible = 0;
         AssignProp("", false, edtavComboresidentpackagemodules_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboresidentpackagemodules_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBORESIDENTPACKAGEMODULES' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV34Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV35GXV1 = 1;
            AssignAttri("", false, "AV35GXV1", StringUtil.LTrimStr( (decimal)(AV35GXV1), 8, 0));
            while ( AV35GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV35GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "SG_LocationId") == 0 )
               {
                  AV32Insert_SG_LocationId = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV32Insert_SG_LocationId", AV32Insert_SG_LocationId.ToString());
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "SG_OrganisationId") == 0 )
               {
                  AV33Insert_SG_OrganisationId = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV33Insert_SG_OrganisationId", AV33Insert_SG_OrganisationId.ToString());
               }
               AV35GXV1 = (int)(AV35GXV1+1);
               AssignAttri("", false, "AV35GXV1", StringUtil.LTrimStr( (decimal)(AV35GXV1), 8, 0));
            }
         }
         edtResidentPackageId_Visible = 0;
         AssignProp("", false, edtResidentPackageId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentPackageId_Visible), 5, 0), true);
         edtSG_OrganisationId_Visible = 0;
         AssignProp("", false, edtSG_OrganisationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSG_OrganisationId_Visible), 5, 0), true);
         edtSG_LocationId_Visible = 0;
         AssignProp("", false, edtSG_LocationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSG_LocationId_Visible), 5, 0), true);
      }

      protected void E121M2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("trn_residentpackageww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S112( )
      {
         /* 'LOADCOMBORESIDENTPACKAGEMODULES' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item2 = AV18ResidentPackageModules_Data;
         new trn_residentpackageloaddvcombo(context ).execute(  "ResidentPackageModules",  Gx_mode,  AV7ResidentPackageId, out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_objcol_SdtDVB_SDTComboData_Item2) ;
         AV18ResidentPackageModules_Data = GXt_objcol_SdtDVB_SDTComboData_Item2;
         Combo_residentpackagemodules_Selectedvalue_set = AV20ComboSelectedValue;
         ucCombo_residentpackagemodules.SendProperty(context, "", false, Combo_residentpackagemodules_Internalname, "SelectedValue_set", Combo_residentpackagemodules_Selectedvalue_set);
         AV22ComboResidentPackageModules = AV20ComboSelectedValue;
         AssignAttri("", false, "AV22ComboResidentPackageModules", AV22ComboResidentPackageModules);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_residentpackagemodules_Enabled = false;
            ucCombo_residentpackagemodules.SendProperty(context, "", false, Combo_residentpackagemodules_Internalname, "Enabled", StringUtil.BoolToStr( Combo_residentpackagemodules_Enabled));
         }
      }

      protected void ZM1M96( short GX_JID )
      {
         if ( ( GX_JID == 19 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z531ResidentPackageName = T001M3_A531ResidentPackageName[0];
               Z533ResidentPackageDefault = T001M3_A533ResidentPackageDefault[0];
               Z528SG_LocationId = T001M3_A528SG_LocationId[0];
               Z529SG_OrganisationId = T001M3_A529SG_OrganisationId[0];
            }
            else
            {
               Z531ResidentPackageName = A531ResidentPackageName;
               Z533ResidentPackageDefault = A533ResidentPackageDefault;
               Z528SG_LocationId = A528SG_LocationId;
               Z529SG_OrganisationId = A529SG_OrganisationId;
            }
         }
         if ( GX_JID == -19 )
         {
            Z527ResidentPackageId = A527ResidentPackageId;
            Z532ResidentPackageModules = A532ResidentPackageModules;
            Z531ResidentPackageName = A531ResidentPackageName;
            Z533ResidentPackageDefault = A533ResidentPackageDefault;
            Z528SG_LocationId = A528SG_LocationId;
            Z529SG_OrganisationId = A529SG_OrganisationId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV34Pgmname = "Trn_ResidentPackage";
         AssignAttri("", false, "AV34Pgmname", AV34Pgmname);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV7ResidentPackageId) )
         {
            edtResidentPackageId_Enabled = 0;
            AssignProp("", false, edtResidentPackageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentPackageId_Enabled), 5, 0), true);
         }
         else
         {
            edtResidentPackageId_Enabled = 1;
            AssignProp("", false, edtResidentPackageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentPackageId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7ResidentPackageId) )
         {
            edtResidentPackageId_Enabled = 0;
            AssignProp("", false, edtResidentPackageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentPackageId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV32Insert_SG_LocationId) )
         {
            edtSG_LocationId_Enabled = 0;
            AssignProp("", false, edtSG_LocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSG_LocationId_Enabled), 5, 0), true);
         }
         else
         {
            edtSG_LocationId_Enabled = 1;
            AssignProp("", false, edtSG_LocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSG_LocationId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV33Insert_SG_OrganisationId) )
         {
            edtSG_OrganisationId_Enabled = 0;
            AssignProp("", false, edtSG_OrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSG_OrganisationId_Enabled), 5, 0), true);
         }
         else
         {
            edtSG_OrganisationId_Enabled = 1;
            AssignProp("", false, edtSG_OrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSG_OrganisationId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV33Insert_SG_OrganisationId) )
         {
            A529SG_OrganisationId = AV33Insert_SG_OrganisationId;
            AssignAttri("", false, "A529SG_OrganisationId", A529SG_OrganisationId.ToString());
         }
         else
         {
            GXt_guid3 = A529SG_OrganisationId;
            new prc_getuserorganisationid(context ).execute( out  GXt_guid3) ;
            A529SG_OrganisationId = GXt_guid3;
            AssignAttri("", false, "A529SG_OrganisationId", A529SG_OrganisationId.ToString());
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV32Insert_SG_LocationId) )
         {
            A528SG_LocationId = AV32Insert_SG_LocationId;
            AssignAttri("", false, "A528SG_LocationId", A528SG_LocationId.ToString());
         }
         else
         {
            GXt_guid3 = A528SG_LocationId;
            new prc_getuserlocationid(context ).execute( out  GXt_guid3) ;
            A528SG_LocationId = GXt_guid3;
            AssignAttri("", false, "A528SG_LocationId", A528SG_LocationId.ToString());
         }
         A532ResidentPackageModules = AV22ComboResidentPackageModules;
         AssignAttri("", false, "A532ResidentPackageModules", A532ResidentPackageModules);
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
         if ( ! (Guid.Empty==AV7ResidentPackageId) )
         {
            A527ResidentPackageId = AV7ResidentPackageId;
            n527ResidentPackageId = false;
            AssignAttri("", false, "A527ResidentPackageId", A527ResidentPackageId.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A527ResidentPackageId) && ( Gx_BScreen == 0 ) )
            {
               A527ResidentPackageId = Guid.NewGuid( );
               n527ResidentPackageId = false;
               AssignAttri("", false, "A527ResidentPackageId", A527ResidentPackageId.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1M96( )
      {
         /* Using cursor T001M5 */
         pr_default.execute(3, new Object[] {n527ResidentPackageId, A527ResidentPackageId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound96 = 1;
            A532ResidentPackageModules = T001M5_A532ResidentPackageModules[0];
            AssignAttri("", false, "A532ResidentPackageModules", A532ResidentPackageModules);
            A531ResidentPackageName = T001M5_A531ResidentPackageName[0];
            AssignAttri("", false, "A531ResidentPackageName", A531ResidentPackageName);
            A533ResidentPackageDefault = T001M5_A533ResidentPackageDefault[0];
            AssignAttri("", false, "A533ResidentPackageDefault", A533ResidentPackageDefault);
            A528SG_LocationId = T001M5_A528SG_LocationId[0];
            AssignAttri("", false, "A528SG_LocationId", A528SG_LocationId.ToString());
            A529SG_OrganisationId = T001M5_A529SG_OrganisationId[0];
            AssignAttri("", false, "A529SG_OrganisationId", A529SG_OrganisationId.ToString());
            ZM1M96( -19) ;
         }
         pr_default.close(3);
         OnLoadActions1M96( ) ;
      }

      protected void OnLoadActions1M96( )
      {
      }

      protected void CheckExtendedTable1M96( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( A533ResidentPackageDefault )
         {
            new prc_defaultresidetpackage(context ).execute(  A527ResidentPackageId, ref  A528SG_LocationId) ;
            AssignAttri("", false, "A528SG_LocationId", A528SG_LocationId.ToString());
         }
         /* Using cursor T001M4 */
         pr_default.execute(2, new Object[] {A528SG_LocationId, A529SG_OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "SG_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SG_ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtSG_LocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A531ResidentPackageName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Resident Package Name", ""), "", "", "", "", "", "", "", ""), 1, "RESIDENTPACKAGENAME");
            AnyError = 1;
            GX_FocusControl = edtResidentPackageName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( StringUtil.Len( A532ResidentPackageModules) <= 2 )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Resident Package Modules", ""), "", "", "", "", "", "", "", ""), 1, "RESIDENTPACKAGEMODULES");
            AnyError = 1;
            GX_FocusControl = edtResidentPackageModules_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1M96( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_20( Guid A528SG_LocationId ,
                                Guid A529SG_OrganisationId )
      {
         /* Using cursor T001M6 */
         pr_default.execute(4, new Object[] {A528SG_LocationId, A529SG_OrganisationId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "SG_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SG_ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtSG_LocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey1M96( )
      {
         /* Using cursor T001M7 */
         pr_default.execute(5, new Object[] {n527ResidentPackageId, A527ResidentPackageId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound96 = 1;
         }
         else
         {
            RcdFound96 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001M3 */
         pr_default.execute(1, new Object[] {n527ResidentPackageId, A527ResidentPackageId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1M96( 19) ;
            RcdFound96 = 1;
            A527ResidentPackageId = T001M3_A527ResidentPackageId[0];
            n527ResidentPackageId = T001M3_n527ResidentPackageId[0];
            AssignAttri("", false, "A527ResidentPackageId", A527ResidentPackageId.ToString());
            A532ResidentPackageModules = T001M3_A532ResidentPackageModules[0];
            AssignAttri("", false, "A532ResidentPackageModules", A532ResidentPackageModules);
            A531ResidentPackageName = T001M3_A531ResidentPackageName[0];
            AssignAttri("", false, "A531ResidentPackageName", A531ResidentPackageName);
            A533ResidentPackageDefault = T001M3_A533ResidentPackageDefault[0];
            AssignAttri("", false, "A533ResidentPackageDefault", A533ResidentPackageDefault);
            A528SG_LocationId = T001M3_A528SG_LocationId[0];
            AssignAttri("", false, "A528SG_LocationId", A528SG_LocationId.ToString());
            A529SG_OrganisationId = T001M3_A529SG_OrganisationId[0];
            AssignAttri("", false, "A529SG_OrganisationId", A529SG_OrganisationId.ToString());
            Z527ResidentPackageId = A527ResidentPackageId;
            sMode96 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1M96( ) ;
            if ( AnyError == 1 )
            {
               RcdFound96 = 0;
               InitializeNonKey1M96( ) ;
            }
            Gx_mode = sMode96;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound96 = 0;
            InitializeNonKey1M96( ) ;
            sMode96 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode96;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1M96( ) ;
         if ( RcdFound96 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound96 = 0;
         /* Using cursor T001M8 */
         pr_default.execute(6, new Object[] {n527ResidentPackageId, A527ResidentPackageId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T001M8_A527ResidentPackageId[0], A527ResidentPackageId, 0) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T001M8_A527ResidentPackageId[0], A527ResidentPackageId, 0) > 0 ) ) )
            {
               A527ResidentPackageId = T001M8_A527ResidentPackageId[0];
               n527ResidentPackageId = T001M8_n527ResidentPackageId[0];
               AssignAttri("", false, "A527ResidentPackageId", A527ResidentPackageId.ToString());
               RcdFound96 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound96 = 0;
         /* Using cursor T001M9 */
         pr_default.execute(7, new Object[] {n527ResidentPackageId, A527ResidentPackageId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T001M9_A527ResidentPackageId[0], A527ResidentPackageId, 0) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T001M9_A527ResidentPackageId[0], A527ResidentPackageId, 0) < 0 ) ) )
            {
               A527ResidentPackageId = T001M9_A527ResidentPackageId[0];
               n527ResidentPackageId = T001M9_n527ResidentPackageId[0];
               AssignAttri("", false, "A527ResidentPackageId", A527ResidentPackageId.ToString());
               RcdFound96 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1M96( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtResidentPackageName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1M96( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound96 == 1 )
            {
               if ( A527ResidentPackageId != Z527ResidentPackageId )
               {
                  A527ResidentPackageId = Z527ResidentPackageId;
                  n527ResidentPackageId = false;
                  AssignAttri("", false, "A527ResidentPackageId", A527ResidentPackageId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "RESIDENTPACKAGEID");
                  AnyError = 1;
                  GX_FocusControl = edtResidentPackageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtResidentPackageName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1M96( ) ;
                  GX_FocusControl = edtResidentPackageName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A527ResidentPackageId != Z527ResidentPackageId )
               {
                  /* Insert record */
                  GX_FocusControl = edtResidentPackageName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1M96( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "RESIDENTPACKAGEID");
                     AnyError = 1;
                     GX_FocusControl = edtResidentPackageId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtResidentPackageName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1M96( ) ;
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
         if ( A527ResidentPackageId != Z527ResidentPackageId )
         {
            A527ResidentPackageId = Z527ResidentPackageId;
            n527ResidentPackageId = false;
            AssignAttri("", false, "A527ResidentPackageId", A527ResidentPackageId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "RESIDENTPACKAGEID");
            AnyError = 1;
            GX_FocusControl = edtResidentPackageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtResidentPackageName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1M96( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001M2 */
            pr_default.execute(0, new Object[] {n527ResidentPackageId, A527ResidentPackageId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ResidentPackage"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z531ResidentPackageName, T001M2_A531ResidentPackageName[0]) != 0 ) || ( Z533ResidentPackageDefault != T001M2_A533ResidentPackageDefault[0] ) || ( Z528SG_LocationId != T001M2_A528SG_LocationId[0] ) || ( Z529SG_OrganisationId != T001M2_A529SG_OrganisationId[0] ) )
            {
               if ( StringUtil.StrCmp(Z531ResidentPackageName, T001M2_A531ResidentPackageName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_residentpackage:[seudo value changed for attri]"+"ResidentPackageName");
                  GXUtil.WriteLogRaw("Old: ",Z531ResidentPackageName);
                  GXUtil.WriteLogRaw("Current: ",T001M2_A531ResidentPackageName[0]);
               }
               if ( Z533ResidentPackageDefault != T001M2_A533ResidentPackageDefault[0] )
               {
                  GXUtil.WriteLog("trn_residentpackage:[seudo value changed for attri]"+"ResidentPackageDefault");
                  GXUtil.WriteLogRaw("Old: ",Z533ResidentPackageDefault);
                  GXUtil.WriteLogRaw("Current: ",T001M2_A533ResidentPackageDefault[0]);
               }
               if ( Z528SG_LocationId != T001M2_A528SG_LocationId[0] )
               {
                  GXUtil.WriteLog("trn_residentpackage:[seudo value changed for attri]"+"SG_LocationId");
                  GXUtil.WriteLogRaw("Old: ",Z528SG_LocationId);
                  GXUtil.WriteLogRaw("Current: ",T001M2_A528SG_LocationId[0]);
               }
               if ( Z529SG_OrganisationId != T001M2_A529SG_OrganisationId[0] )
               {
                  GXUtil.WriteLog("trn_residentpackage:[seudo value changed for attri]"+"SG_OrganisationId");
                  GXUtil.WriteLogRaw("Old: ",Z529SG_OrganisationId);
                  GXUtil.WriteLogRaw("Current: ",T001M2_A529SG_OrganisationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_ResidentPackage"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1M96( )
      {
         if ( ! IsAuthorized("trn_residentpackage_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1M96( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1M96( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1M96( 0) ;
            CheckOptimisticConcurrency1M96( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1M96( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1M96( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001M10 */
                     pr_default.execute(8, new Object[] {n527ResidentPackageId, A527ResidentPackageId, A532ResidentPackageModules, A531ResidentPackageName, A533ResidentPackageDefault, A528SG_LocationId, A529SG_OrganisationId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ResidentPackage");
                     if ( (pr_default.getStatus(8) == 1) )
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
               Load1M96( ) ;
            }
            EndLevel1M96( ) ;
         }
         CloseExtendedTableCursors1M96( ) ;
      }

      protected void Update1M96( )
      {
         if ( ! IsAuthorized("trn_residentpackage_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1M96( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1M96( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1M96( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1M96( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1M96( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001M11 */
                     pr_default.execute(9, new Object[] {A532ResidentPackageModules, A531ResidentPackageName, A533ResidentPackageDefault, A528SG_LocationId, A529SG_OrganisationId, n527ResidentPackageId, A527ResidentPackageId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ResidentPackage");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ResidentPackage"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1M96( ) ;
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
            EndLevel1M96( ) ;
         }
         CloseExtendedTableCursors1M96( ) ;
      }

      protected void DeferredUpdate1M96( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_residentpackage_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1M96( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1M96( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1M96( ) ;
            AfterConfirm1M96( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1M96( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001M12 */
                  pr_default.execute(10, new Object[] {n527ResidentPackageId, A527ResidentPackageId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ResidentPackage");
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
         sMode96 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1M96( ) ;
         Gx_mode = sMode96;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1M96( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T001M13 */
            pr_default.execute(11, new Object[] {n527ResidentPackageId, A527ResidentPackageId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_Resident", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel1M96( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1M96( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_residentpackage",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1M0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_residentpackage",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1M96( )
      {
         /* Scan By routine */
         /* Using cursor T001M14 */
         pr_default.execute(12);
         RcdFound96 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound96 = 1;
            A527ResidentPackageId = T001M14_A527ResidentPackageId[0];
            n527ResidentPackageId = T001M14_n527ResidentPackageId[0];
            AssignAttri("", false, "A527ResidentPackageId", A527ResidentPackageId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1M96( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound96 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound96 = 1;
            A527ResidentPackageId = T001M14_A527ResidentPackageId[0];
            n527ResidentPackageId = T001M14_n527ResidentPackageId[0];
            AssignAttri("", false, "A527ResidentPackageId", A527ResidentPackageId.ToString());
         }
      }

      protected void ScanEnd1M96( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm1M96( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1M96( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1M96( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1M96( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1M96( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1M96( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1M96( )
      {
         edtResidentPackageName_Enabled = 0;
         AssignProp("", false, edtResidentPackageName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentPackageName_Enabled), 5, 0), true);
         edtResidentPackageModules_Enabled = 0;
         AssignProp("", false, edtResidentPackageModules_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentPackageModules_Enabled), 5, 0), true);
         chkResidentPackageDefault.Enabled = 0;
         AssignProp("", false, chkResidentPackageDefault_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkResidentPackageDefault.Enabled), 5, 0), true);
         edtavComboresidentpackagemodules_Enabled = 0;
         AssignProp("", false, edtavComboresidentpackagemodules_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboresidentpackagemodules_Enabled), 5, 0), true);
         edtResidentPackageId_Enabled = 0;
         AssignProp("", false, edtResidentPackageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentPackageId_Enabled), 5, 0), true);
         edtSG_OrganisationId_Enabled = 0;
         AssignProp("", false, edtSG_OrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSG_OrganisationId_Enabled), 5, 0), true);
         edtSG_LocationId_Enabled = 0;
         AssignProp("", false, edtSG_LocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSG_LocationId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1M96( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1M0( )
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         GXEncryptionTmp = "trn_residentpackage.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7ResidentPackageId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_residentpackage.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_ResidentPackage");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_residentpackage:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z527ResidentPackageId", Z527ResidentPackageId.ToString());
         GxWebStd.gx_hidden_field( context, "Z531ResidentPackageName", Z531ResidentPackageName);
         GxWebStd.gx_boolean_hidden_field( context, "Z533ResidentPackageDefault", Z533ResidentPackageDefault);
         GxWebStd.gx_hidden_field( context, "Z528SG_LocationId", Z528SG_LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z529SG_OrganisationId", Z529SG_OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N528SG_LocationId", A528SG_LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "N529SG_OrganisationId", A529SG_OrganisationId.ToString());
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV19DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV19DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vRESIDENTPACKAGEMODULES_DATA", AV18ResidentPackageModules_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vRESIDENTPACKAGEMODULES_DATA", AV18ResidentPackageModules_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV11TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV11TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vRESIDENTPACKAGEID", AV7ResidentPackageId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vRESIDENTPACKAGEID", GetSecureSignedToken( "", AV7ResidentPackageId, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_SG_LOCATIONID", AV32Insert_SG_LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_SG_ORGANISATIONID", AV33Insert_SG_OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV34Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPACKAGEMODULES_Objectcall", StringUtil.RTrim( Combo_residentpackagemodules_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPACKAGEMODULES_Cls", StringUtil.RTrim( Combo_residentpackagemodules_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPACKAGEMODULES_Selectedvalue_set", StringUtil.RTrim( Combo_residentpackagemodules_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPACKAGEMODULES_Enabled", StringUtil.BoolToStr( Combo_residentpackagemodules_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPACKAGEMODULES_Allowmultipleselection", StringUtil.BoolToStr( Combo_residentpackagemodules_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPACKAGEMODULES_Includeonlyselectedoption", StringUtil.BoolToStr( Combo_residentpackagemodules_Includeonlyselectedoption));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPACKAGEMODULES_Emptyitem", StringUtil.BoolToStr( Combo_residentpackagemodules_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPACKAGEMODULES_Multiplevaluestype", StringUtil.RTrim( Combo_residentpackagemodules_Multiplevaluestype));
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
         GXEncryptionTmp = "trn_residentpackage.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7ResidentPackageId.ToString());
         return formatLink("trn_residentpackage.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Trn_ResidentPackage" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "App Access Rights", "") ;
      }

      protected void InitializeNonKey1M96( )
      {
         A528SG_LocationId = Guid.Empty;
         AssignAttri("", false, "A528SG_LocationId", A528SG_LocationId.ToString());
         A529SG_OrganisationId = Guid.Empty;
         AssignAttri("", false, "A529SG_OrganisationId", A529SG_OrganisationId.ToString());
         A532ResidentPackageModules = "";
         AssignAttri("", false, "A532ResidentPackageModules", A532ResidentPackageModules);
         A531ResidentPackageName = "";
         AssignAttri("", false, "A531ResidentPackageName", A531ResidentPackageName);
         A533ResidentPackageDefault = false;
         AssignAttri("", false, "A533ResidentPackageDefault", A533ResidentPackageDefault);
         Z531ResidentPackageName = "";
         Z533ResidentPackageDefault = false;
         Z528SG_LocationId = Guid.Empty;
         Z529SG_OrganisationId = Guid.Empty;
      }

      protected void InitAll1M96( )
      {
         A527ResidentPackageId = Guid.NewGuid( );
         n527ResidentPackageId = false;
         AssignAttri("", false, "A527ResidentPackageId", A527ResidentPackageId.ToString());
         InitializeNonKey1M96( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256147114970", true, true);
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
         context.AddJavascriptSource("trn_residentpackage.js", "?20256147114973", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtResidentPackageName_Internalname = "RESIDENTPACKAGENAME";
         lblTextblockresidentpackagemodules_Internalname = "TEXTBLOCKRESIDENTPACKAGEMODULES";
         Combo_residentpackagemodules_Internalname = "COMBO_RESIDENTPACKAGEMODULES";
         edtResidentPackageModules_Internalname = "RESIDENTPACKAGEMODULES";
         divTablesplittedresidentpackagemodules_Internalname = "TABLESPLITTEDRESIDENTPACKAGEMODULES";
         chkResidentPackageDefault_Internalname = "RESIDENTPACKAGEDEFAULT";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavComboresidentpackagemodules_Internalname = "vCOMBORESIDENTPACKAGEMODULES";
         divSectionattribute_residentpackagemodules_Internalname = "SECTIONATTRIBUTE_RESIDENTPACKAGEMODULES";
         edtResidentPackageId_Internalname = "RESIDENTPACKAGEID";
         edtSG_OrganisationId_Internalname = "SG_ORGANISATIONID";
         edtSG_LocationId_Internalname = "SG_LOCATIONID";
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
         Form.Caption = context.GetMessage( "App Access Rights", "");
         edtSG_LocationId_Jsonclick = "";
         edtSG_LocationId_Enabled = 1;
         edtSG_LocationId_Visible = 1;
         edtSG_OrganisationId_Jsonclick = "";
         edtSG_OrganisationId_Enabled = 1;
         edtSG_OrganisationId_Visible = 1;
         edtResidentPackageId_Jsonclick = "";
         edtResidentPackageId_Enabled = 1;
         edtResidentPackageId_Visible = 1;
         edtavComboresidentpackagemodules_Enabled = 0;
         edtavComboresidentpackagemodules_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         chkResidentPackageDefault.Enabled = 1;
         edtResidentPackageModules_Enabled = 1;
         Combo_residentpackagemodules_Multiplevaluestype = "Tags";
         Combo_residentpackagemodules_Emptyitem = Convert.ToBoolean( 0);
         Combo_residentpackagemodules_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_residentpackagemodules_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_residentpackagemodules_Cls = "ExtendedCombo Attribute";
         Combo_residentpackagemodules_Caption = "";
         Combo_residentpackagemodules_Enabled = Convert.ToBoolean( -1);
         edtResidentPackageName_Jsonclick = "";
         edtResidentPackageName_Enabled = 1;
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

      protected void GX8ASASG_LOCATIONID1M96( Guid AV32Insert_SG_LocationId )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV32Insert_SG_LocationId) )
         {
            A528SG_LocationId = AV32Insert_SG_LocationId;
            AssignAttri("", false, "A528SG_LocationId", A528SG_LocationId.ToString());
         }
         else
         {
            GXt_guid3 = A528SG_LocationId;
            new prc_getuserlocationid(context ).execute( out  GXt_guid3) ;
            A528SG_LocationId = GXt_guid3;
            AssignAttri("", false, "A528SG_LocationId", A528SG_LocationId.ToString());
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A528SG_LocationId.ToString())+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX10ASASG_ORGANISATIONID1M96( Guid AV33Insert_SG_OrganisationId )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV33Insert_SG_OrganisationId) )
         {
            A529SG_OrganisationId = AV33Insert_SG_OrganisationId;
            AssignAttri("", false, "A529SG_OrganisationId", A529SG_OrganisationId.ToString());
         }
         else
         {
            GXt_guid3 = A529SG_OrganisationId;
            new prc_getuserorganisationid(context ).execute( out  GXt_guid3) ;
            A529SG_OrganisationId = GXt_guid3;
            AssignAttri("", false, "A529SG_OrganisationId", A529SG_OrganisationId.ToString());
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A529SG_OrganisationId.ToString())+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_18_1M96( Guid A527ResidentPackageId ,
                                 Guid A528SG_LocationId ,
                                 bool A533ResidentPackageDefault )
      {
         if ( A533ResidentPackageDefault )
         {
            new prc_defaultresidetpackage(context ).execute(  A527ResidentPackageId, ref  A528SG_LocationId) ;
            AssignAttri("", false, "A528SG_LocationId", A528SG_LocationId.ToString());
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A528SG_LocationId.ToString())+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void init_web_controls( )
      {
         chkResidentPackageDefault.Name = "RESIDENTPACKAGEDEFAULT";
         chkResidentPackageDefault.WebTags = "";
         chkResidentPackageDefault.Caption = " ";
         AssignProp("", false, chkResidentPackageDefault_Internalname, "TitleCaption", chkResidentPackageDefault.Caption, true);
         chkResidentPackageDefault.CheckedValue = "false";
         A533ResidentPackageDefault = StringUtil.StrToBool( StringUtil.BoolToStr( A533ResidentPackageDefault));
         AssignAttri("", false, "A533ResidentPackageDefault", A533ResidentPackageDefault);
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

      public void Valid_Sg_locationid( )
      {
         n527ResidentPackageId = false;
         /* Using cursor T001M15 */
         pr_default.execute(13, new Object[] {A528SG_LocationId, A529SG_OrganisationId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "SG_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SG_ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtSG_LocationId_Internalname;
         }
         pr_default.close(13);
         if ( A533ResidentPackageDefault )
         {
            new prc_defaultresidetpackage(context ).execute(  A527ResidentPackageId, ref  A528SG_LocationId) ;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A528SG_LocationId", A528SG_LocationId.ToString());
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7ResidentPackageId","fld":"vRESIDENTPACKAGEID","hsh":true},{"av":"A533ResidentPackageDefault","fld":"RESIDENTPACKAGEDEFAULT"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A533ResidentPackageDefault","fld":"RESIDENTPACKAGEDEFAULT"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7ResidentPackageId","fld":"vRESIDENTPACKAGEID","hsh":true},{"av":"A533ResidentPackageDefault","fld":"RESIDENTPACKAGEDEFAULT"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A533ResidentPackageDefault","fld":"RESIDENTPACKAGEDEFAULT"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E121M2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"A533ResidentPackageDefault","fld":"RESIDENTPACKAGEDEFAULT"}]""");
         setEventMetadata("AFTER TRN",""","oparms":[{"av":"A533ResidentPackageDefault","fld":"RESIDENTPACKAGEDEFAULT"}]}""");
         setEventMetadata("VALID_RESIDENTPACKAGENAME","""{"handler":"Valid_Residentpackagename","iparms":[{"av":"A533ResidentPackageDefault","fld":"RESIDENTPACKAGEDEFAULT"}]""");
         setEventMetadata("VALID_RESIDENTPACKAGENAME",""","oparms":[{"av":"A533ResidentPackageDefault","fld":"RESIDENTPACKAGEDEFAULT"}]}""");
         setEventMetadata("VALID_RESIDENTPACKAGEMODULES","""{"handler":"Valid_Residentpackagemodules","iparms":[{"av":"A533ResidentPackageDefault","fld":"RESIDENTPACKAGEDEFAULT"}]""");
         setEventMetadata("VALID_RESIDENTPACKAGEMODULES",""","oparms":[{"av":"A533ResidentPackageDefault","fld":"RESIDENTPACKAGEDEFAULT"}]}""");
         setEventMetadata("VALID_RESIDENTPACKAGEDEFAULT","""{"handler":"Valid_Residentpackagedefault","iparms":[{"av":"A533ResidentPackageDefault","fld":"RESIDENTPACKAGEDEFAULT"}]""");
         setEventMetadata("VALID_RESIDENTPACKAGEDEFAULT",""","oparms":[{"av":"A533ResidentPackageDefault","fld":"RESIDENTPACKAGEDEFAULT"}]}""");
         setEventMetadata("VALIDV_COMBORESIDENTPACKAGEMODULES","""{"handler":"Validv_Comboresidentpackagemodules","iparms":[{"av":"A533ResidentPackageDefault","fld":"RESIDENTPACKAGEDEFAULT"}]""");
         setEventMetadata("VALIDV_COMBORESIDENTPACKAGEMODULES",""","oparms":[{"av":"A533ResidentPackageDefault","fld":"RESIDENTPACKAGEDEFAULT"}]}""");
         setEventMetadata("VALID_RESIDENTPACKAGEID","""{"handler":"Valid_Residentpackageid","iparms":[{"av":"A533ResidentPackageDefault","fld":"RESIDENTPACKAGEDEFAULT"}]""");
         setEventMetadata("VALID_RESIDENTPACKAGEID",""","oparms":[{"av":"A533ResidentPackageDefault","fld":"RESIDENTPACKAGEDEFAULT"}]}""");
         setEventMetadata("VALID_SG_ORGANISATIONID","""{"handler":"Valid_Sg_organisationid","iparms":[{"av":"A533ResidentPackageDefault","fld":"RESIDENTPACKAGEDEFAULT"}]""");
         setEventMetadata("VALID_SG_ORGANISATIONID",""","oparms":[{"av":"A533ResidentPackageDefault","fld":"RESIDENTPACKAGEDEFAULT"}]}""");
         setEventMetadata("VALID_SG_LOCATIONID","""{"handler":"Valid_Sg_locationid","iparms":[{"av":"A528SG_LocationId","fld":"SG_LOCATIONID"},{"av":"A529SG_OrganisationId","fld":"SG_ORGANISATIONID"},{"av":"A527ResidentPackageId","fld":"RESIDENTPACKAGEID"},{"av":"A533ResidentPackageDefault","fld":"RESIDENTPACKAGEDEFAULT"}]""");
         setEventMetadata("VALID_SG_LOCATIONID",""","oparms":[{"av":"A528SG_LocationId","fld":"SG_LOCATIONID"},{"av":"A533ResidentPackageDefault","fld":"RESIDENTPACKAGEDEFAULT"}]}""");
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
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7ResidentPackageId = Guid.Empty;
         Z527ResidentPackageId = Guid.Empty;
         Z531ResidentPackageName = "";
         Z528SG_LocationId = Guid.Empty;
         Z529SG_OrganisationId = Guid.Empty;
         N528SG_LocationId = Guid.Empty;
         N529SG_OrganisationId = Guid.Empty;
         Combo_residentpackagemodules_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A527ResidentPackageId = Guid.Empty;
         A528SG_LocationId = Guid.Empty;
         AV32Insert_SG_LocationId = Guid.Empty;
         AV33Insert_SG_OrganisationId = Guid.Empty;
         A529SG_OrganisationId = Guid.Empty;
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A531ResidentPackageName = "";
         lblTextblockresidentpackagemodules_Jsonclick = "";
         ucCombo_residentpackagemodules = new GXUserControl();
         AV19DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV18ResidentPackageModules_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A532ResidentPackageModules = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV22ComboResidentPackageModules = "";
         AV34Pgmname = "";
         Combo_residentpackagemodules_Objectcall = "";
         Combo_residentpackagemodules_Class = "";
         Combo_residentpackagemodules_Icontype = "";
         Combo_residentpackagemodules_Icon = "";
         Combo_residentpackagemodules_Tooltip = "";
         Combo_residentpackagemodules_Selectedvalue_set = "";
         Combo_residentpackagemodules_Selectedtext_set = "";
         Combo_residentpackagemodules_Selectedtext_get = "";
         Combo_residentpackagemodules_Gamoauthtoken = "";
         Combo_residentpackagemodules_Ddointernalname = "";
         Combo_residentpackagemodules_Titlecontrolalign = "";
         Combo_residentpackagemodules_Dropdownoptionstype = "";
         Combo_residentpackagemodules_Titlecontrolidtoreplace = "";
         Combo_residentpackagemodules_Datalisttype = "";
         Combo_residentpackagemodules_Datalistfixedvalues = "";
         Combo_residentpackagemodules_Datalistproc = "";
         Combo_residentpackagemodules_Datalistprocparametersprefix = "";
         Combo_residentpackagemodules_Remoteservicesparameters = "";
         Combo_residentpackagemodules_Htmltemplate = "";
         Combo_residentpackagemodules_Loadingdata = "";
         Combo_residentpackagemodules_Noresultsfound = "";
         Combo_residentpackagemodules_Emptyitemtext = "";
         Combo_residentpackagemodules_Onlyselectedvalues = "";
         Combo_residentpackagemodules_Selectalltext = "";
         Combo_residentpackagemodules_Multiplevaluesseparator = "";
         Combo_residentpackagemodules_Addnewoptiontext = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode96 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV15TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         GXt_objcol_SdtDVB_SDTComboData_Item2 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV20ComboSelectedValue = "";
         AV21ComboSelectedText = "";
         Z532ResidentPackageModules = "";
         T001M5_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         T001M5_n527ResidentPackageId = new bool[] {false} ;
         T001M5_A532ResidentPackageModules = new string[] {""} ;
         T001M5_A531ResidentPackageName = new string[] {""} ;
         T001M5_A533ResidentPackageDefault = new bool[] {false} ;
         T001M5_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         T001M5_A529SG_OrganisationId = new Guid[] {Guid.Empty} ;
         T001M4_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         T001M6_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         T001M7_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         T001M7_n527ResidentPackageId = new bool[] {false} ;
         T001M3_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         T001M3_n527ResidentPackageId = new bool[] {false} ;
         T001M3_A532ResidentPackageModules = new string[] {""} ;
         T001M3_A531ResidentPackageName = new string[] {""} ;
         T001M3_A533ResidentPackageDefault = new bool[] {false} ;
         T001M3_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         T001M3_A529SG_OrganisationId = new Guid[] {Guid.Empty} ;
         T001M8_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         T001M8_n527ResidentPackageId = new bool[] {false} ;
         T001M9_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         T001M9_n527ResidentPackageId = new bool[] {false} ;
         T001M2_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         T001M2_n527ResidentPackageId = new bool[] {false} ;
         T001M2_A532ResidentPackageModules = new string[] {""} ;
         T001M2_A531ResidentPackageName = new string[] {""} ;
         T001M2_A533ResidentPackageDefault = new bool[] {false} ;
         T001M2_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         T001M2_A529SG_OrganisationId = new Guid[] {Guid.Empty} ;
         T001M13_A62ResidentId = new Guid[] {Guid.Empty} ;
         T001M13_A29LocationId = new Guid[] {Guid.Empty} ;
         T001M13_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001M14_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         T001M14_n527ResidentPackageId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXt_guid3 = Guid.Empty;
         T001M15_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_residentpackage__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_residentpackage__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_residentpackage__default(),
            new Object[][] {
                new Object[] {
               T001M2_A527ResidentPackageId, T001M2_A532ResidentPackageModules, T001M2_A531ResidentPackageName, T001M2_A533ResidentPackageDefault, T001M2_A528SG_LocationId, T001M2_A529SG_OrganisationId
               }
               , new Object[] {
               T001M3_A527ResidentPackageId, T001M3_A532ResidentPackageModules, T001M3_A531ResidentPackageName, T001M3_A533ResidentPackageDefault, T001M3_A528SG_LocationId, T001M3_A529SG_OrganisationId
               }
               , new Object[] {
               T001M4_A528SG_LocationId
               }
               , new Object[] {
               T001M5_A527ResidentPackageId, T001M5_A532ResidentPackageModules, T001M5_A531ResidentPackageName, T001M5_A533ResidentPackageDefault, T001M5_A528SG_LocationId, T001M5_A529SG_OrganisationId
               }
               , new Object[] {
               T001M6_A528SG_LocationId
               }
               , new Object[] {
               T001M7_A527ResidentPackageId
               }
               , new Object[] {
               T001M8_A527ResidentPackageId
               }
               , new Object[] {
               T001M9_A527ResidentPackageId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001M13_A62ResidentId, T001M13_A29LocationId, T001M13_A11OrganisationId
               }
               , new Object[] {
               T001M14_A527ResidentPackageId
               }
               , new Object[] {
               T001M15_A528SG_LocationId
               }
            }
         );
         Z527ResidentPackageId = Guid.NewGuid( );
         n527ResidentPackageId = false;
         A527ResidentPackageId = Guid.NewGuid( );
         n527ResidentPackageId = false;
         AV34Pgmname = "Trn_ResidentPackage";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound96 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtResidentPackageName_Enabled ;
      private int edtResidentPackageModules_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavComboresidentpackagemodules_Visible ;
      private int edtavComboresidentpackagemodules_Enabled ;
      private int edtResidentPackageId_Visible ;
      private int edtResidentPackageId_Enabled ;
      private int edtSG_OrganisationId_Visible ;
      private int edtSG_OrganisationId_Enabled ;
      private int edtSG_LocationId_Visible ;
      private int edtSG_LocationId_Enabled ;
      private int Combo_residentpackagemodules_Datalistupdateminimumcharacters ;
      private int Combo_residentpackagemodules_Gxcontroltype ;
      private int AV35GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_residentpackagemodules_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtResidentPackageName_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtResidentPackageName_Jsonclick ;
      private string divTablesplittedresidentpackagemodules_Internalname ;
      private string lblTextblockresidentpackagemodules_Internalname ;
      private string lblTextblockresidentpackagemodules_Jsonclick ;
      private string Combo_residentpackagemodules_Caption ;
      private string Combo_residentpackagemodules_Cls ;
      private string Combo_residentpackagemodules_Multiplevaluestype ;
      private string Combo_residentpackagemodules_Internalname ;
      private string edtResidentPackageModules_Internalname ;
      private string chkResidentPackageDefault_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_residentpackagemodules_Internalname ;
      private string edtavComboresidentpackagemodules_Internalname ;
      private string edtResidentPackageId_Internalname ;
      private string edtResidentPackageId_Jsonclick ;
      private string edtSG_OrganisationId_Internalname ;
      private string edtSG_OrganisationId_Jsonclick ;
      private string edtSG_LocationId_Internalname ;
      private string edtSG_LocationId_Jsonclick ;
      private string AV34Pgmname ;
      private string Combo_residentpackagemodules_Objectcall ;
      private string Combo_residentpackagemodules_Class ;
      private string Combo_residentpackagemodules_Icontype ;
      private string Combo_residentpackagemodules_Icon ;
      private string Combo_residentpackagemodules_Tooltip ;
      private string Combo_residentpackagemodules_Selectedvalue_set ;
      private string Combo_residentpackagemodules_Selectedtext_set ;
      private string Combo_residentpackagemodules_Selectedtext_get ;
      private string Combo_residentpackagemodules_Gamoauthtoken ;
      private string Combo_residentpackagemodules_Ddointernalname ;
      private string Combo_residentpackagemodules_Titlecontrolalign ;
      private string Combo_residentpackagemodules_Dropdownoptionstype ;
      private string Combo_residentpackagemodules_Titlecontrolidtoreplace ;
      private string Combo_residentpackagemodules_Datalisttype ;
      private string Combo_residentpackagemodules_Datalistfixedvalues ;
      private string Combo_residentpackagemodules_Datalistproc ;
      private string Combo_residentpackagemodules_Datalistprocparametersprefix ;
      private string Combo_residentpackagemodules_Remoteservicesparameters ;
      private string Combo_residentpackagemodules_Htmltemplate ;
      private string Combo_residentpackagemodules_Loadingdata ;
      private string Combo_residentpackagemodules_Noresultsfound ;
      private string Combo_residentpackagemodules_Emptyitemtext ;
      private string Combo_residentpackagemodules_Onlyselectedvalues ;
      private string Combo_residentpackagemodules_Selectalltext ;
      private string Combo_residentpackagemodules_Multiplevaluesseparator ;
      private string Combo_residentpackagemodules_Addnewoptiontext ;
      private string hsh ;
      private string sMode96 ;
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
      private bool Z533ResidentPackageDefault ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n527ResidentPackageId ;
      private bool A533ResidentPackageDefault ;
      private bool wbErr ;
      private bool Combo_residentpackagemodules_Allowmultipleselection ;
      private bool Combo_residentpackagemodules_Includeonlyselectedoption ;
      private bool Combo_residentpackagemodules_Emptyitem ;
      private bool Combo_residentpackagemodules_Enabled ;
      private bool Combo_residentpackagemodules_Visible ;
      private bool Combo_residentpackagemodules_Isgriditem ;
      private bool Combo_residentpackagemodules_Hasdescription ;
      private bool Combo_residentpackagemodules_Includeselectalloption ;
      private bool Combo_residentpackagemodules_Includeaddnewoption ;
      private bool returnInSub ;
      private string A532ResidentPackageModules ;
      private string AV22ComboResidentPackageModules ;
      private string Z532ResidentPackageModules ;
      private string Z531ResidentPackageName ;
      private string A531ResidentPackageName ;
      private string AV20ComboSelectedValue ;
      private string AV21ComboSelectedText ;
      private Guid wcpOAV7ResidentPackageId ;
      private Guid Z527ResidentPackageId ;
      private Guid Z528SG_LocationId ;
      private Guid Z529SG_OrganisationId ;
      private Guid N528SG_LocationId ;
      private Guid N529SG_OrganisationId ;
      private Guid A527ResidentPackageId ;
      private Guid A528SG_LocationId ;
      private Guid AV32Insert_SG_LocationId ;
      private Guid AV33Insert_SG_OrganisationId ;
      private Guid A529SG_OrganisationId ;
      private Guid AV7ResidentPackageId ;
      private Guid GXt_guid3 ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucCombo_residentpackagemodules ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkResidentPackageDefault ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV19DDO_TitleSettingsIcons ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV18ResidentPackageModules_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> GXt_objcol_SdtDVB_SDTComboData_Item2 ;
      private IDataStoreProvider pr_default ;
      private Guid[] T001M5_A527ResidentPackageId ;
      private bool[] T001M5_n527ResidentPackageId ;
      private string[] T001M5_A532ResidentPackageModules ;
      private string[] T001M5_A531ResidentPackageName ;
      private bool[] T001M5_A533ResidentPackageDefault ;
      private Guid[] T001M5_A528SG_LocationId ;
      private Guid[] T001M5_A529SG_OrganisationId ;
      private Guid[] T001M4_A528SG_LocationId ;
      private Guid[] T001M6_A528SG_LocationId ;
      private Guid[] T001M7_A527ResidentPackageId ;
      private bool[] T001M7_n527ResidentPackageId ;
      private Guid[] T001M3_A527ResidentPackageId ;
      private bool[] T001M3_n527ResidentPackageId ;
      private string[] T001M3_A532ResidentPackageModules ;
      private string[] T001M3_A531ResidentPackageName ;
      private bool[] T001M3_A533ResidentPackageDefault ;
      private Guid[] T001M3_A528SG_LocationId ;
      private Guid[] T001M3_A529SG_OrganisationId ;
      private Guid[] T001M8_A527ResidentPackageId ;
      private bool[] T001M8_n527ResidentPackageId ;
      private Guid[] T001M9_A527ResidentPackageId ;
      private bool[] T001M9_n527ResidentPackageId ;
      private Guid[] T001M2_A527ResidentPackageId ;
      private bool[] T001M2_n527ResidentPackageId ;
      private string[] T001M2_A532ResidentPackageModules ;
      private string[] T001M2_A531ResidentPackageName ;
      private bool[] T001M2_A533ResidentPackageDefault ;
      private Guid[] T001M2_A528SG_LocationId ;
      private Guid[] T001M2_A529SG_OrganisationId ;
      private Guid[] T001M13_A62ResidentId ;
      private Guid[] T001M13_A29LocationId ;
      private Guid[] T001M13_A11OrganisationId ;
      private Guid[] T001M14_A527ResidentPackageId ;
      private bool[] T001M14_n527ResidentPackageId ;
      private Guid[] T001M15_A528SG_LocationId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_residentpackage__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_residentpackage__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_residentpackage__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[8])
      ,new UpdateCursor(def[9])
      ,new UpdateCursor(def[10])
      ,new ForEachCursor(def[11])
      ,new ForEachCursor(def[12])
      ,new ForEachCursor(def[13])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT001M2;
       prmT001M2 = new Object[] {
       new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT001M3;
       prmT001M3 = new Object[] {
       new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT001M4;
       prmT001M4 = new Object[] {
       new ParDef("SG_LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001M5;
       prmT001M5 = new Object[] {
       new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT001M6;
       prmT001M6 = new Object[] {
       new ParDef("SG_LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001M7;
       prmT001M7 = new Object[] {
       new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT001M8;
       prmT001M8 = new Object[] {
       new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT001M9;
       prmT001M9 = new Object[] {
       new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT001M10;
       prmT001M10 = new Object[] {
       new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ResidentPackageModules",GXType.LongVarChar,2097152,0) ,
       new ParDef("ResidentPackageName",GXType.VarChar,100,0) ,
       new ParDef("ResidentPackageDefault",GXType.Boolean,4,0) ,
       new ParDef("SG_LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001M11;
       prmT001M11 = new Object[] {
       new ParDef("ResidentPackageModules",GXType.LongVarChar,2097152,0) ,
       new ParDef("ResidentPackageName",GXType.VarChar,100,0) ,
       new ParDef("ResidentPackageDefault",GXType.Boolean,4,0) ,
       new ParDef("SG_LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT001M12;
       prmT001M12 = new Object[] {
       new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT001M13;
       prmT001M13 = new Object[] {
       new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT001M14;
       prmT001M14 = new Object[] {
       };
       Object[] prmT001M15;
       prmT001M15 = new Object[] {
       new ParDef("SG_LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("T001M2", "SELECT ResidentPackageId, ResidentPackageModules, ResidentPackageName, ResidentPackageDefault, SG_LocationId, SG_OrganisationId FROM Trn_ResidentPackage WHERE ResidentPackageId = :ResidentPackageId  FOR UPDATE OF Trn_ResidentPackage NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001M2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001M3", "SELECT ResidentPackageId, ResidentPackageModules, ResidentPackageName, ResidentPackageDefault, SG_LocationId, SG_OrganisationId FROM Trn_ResidentPackage WHERE ResidentPackageId = :ResidentPackageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001M4", "SELECT LocationId AS SG_LocationId FROM Trn_Location WHERE LocationId = :SG_LocationId AND OrganisationId = :SG_OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001M5", "SELECT TM1.ResidentPackageId, TM1.ResidentPackageModules, TM1.ResidentPackageName, TM1.ResidentPackageDefault, TM1.SG_LocationId AS SG_LocationId, TM1.SG_OrganisationId AS SG_OrganisationId FROM Trn_ResidentPackage TM1 WHERE TM1.ResidentPackageId = :ResidentPackageId ORDER BY TM1.ResidentPackageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M5,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001M6", "SELECT LocationId AS SG_LocationId FROM Trn_Location WHERE LocationId = :SG_LocationId AND OrganisationId = :SG_OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001M7", "SELECT ResidentPackageId FROM Trn_ResidentPackage WHERE ResidentPackageId = :ResidentPackageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001M8", "SELECT ResidentPackageId FROM Trn_ResidentPackage WHERE ( ResidentPackageId > :ResidentPackageId) ORDER BY ResidentPackageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M8,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001M9", "SELECT ResidentPackageId FROM Trn_ResidentPackage WHERE ( ResidentPackageId < :ResidentPackageId) ORDER BY ResidentPackageId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M9,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001M10", "SAVEPOINT gxupdate;INSERT INTO Trn_ResidentPackage(ResidentPackageId, ResidentPackageModules, ResidentPackageName, ResidentPackageDefault, SG_LocationId, SG_OrganisationId) VALUES(:ResidentPackageId, :ResidentPackageModules, :ResidentPackageName, :ResidentPackageDefault, :SG_LocationId, :SG_OrganisationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001M10)
          ,new CursorDef("T001M11", "SAVEPOINT gxupdate;UPDATE Trn_ResidentPackage SET ResidentPackageModules=:ResidentPackageModules, ResidentPackageName=:ResidentPackageName, ResidentPackageDefault=:ResidentPackageDefault, SG_LocationId=:SG_LocationId, SG_OrganisationId=:SG_OrganisationId  WHERE ResidentPackageId = :ResidentPackageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001M11)
          ,new CursorDef("T001M12", "SAVEPOINT gxupdate;DELETE FROM Trn_ResidentPackage  WHERE ResidentPackageId = :ResidentPackageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001M12)
          ,new CursorDef("T001M13", "SELECT ResidentId, LocationId, OrganisationId FROM Trn_Resident WHERE ResidentPackageId = :ResidentPackageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M13,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001M14", "SELECT ResidentPackageId FROM Trn_ResidentPackage ORDER BY ResidentPackageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M14,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001M15", "SELECT LocationId AS SG_LocationId FROM Trn_Location WHERE LocationId = :SG_LocationId AND OrganisationId = :SG_OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M15,1, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             ((Guid[]) buf[5])[0] = rslt.getGuid(6);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             ((Guid[]) buf[5])[0] = rslt.getGuid(6);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             ((Guid[]) buf[5])[0] = rslt.getGuid(6);
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
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 11 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 12 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 13 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
