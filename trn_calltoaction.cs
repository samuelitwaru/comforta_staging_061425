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
   public class trn_calltoaction : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel8"+"_"+"WWPFORMLATESTVERSIONNUMBER") == 0 )
         {
            A206WWPFormId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX8ASAWWPFORMLATESTVERSIONNUMBER1572( A206WWPFormId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel9"+"_"+"CALLTOACTIONURL") == 0 )
         {
            A340CallToActionType = GetPar( "CallToActionType");
            AssignAttri("", false, "A340CallToActionType", A340CallToActionType);
            A208WWPFormReferenceName = GetPar( "WWPFormReferenceName");
            AssignAttri("", false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX9ASACALLTOACTIONURL1572( A340CallToActionType, A208WWPFormReferenceName) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel10"+"_"+"vSDT_TRNATTRIBUTES") == 0 )
         {
            A339CallToActionId = StringUtil.StrToGuid( GetPar( "CallToActionId"));
            AssignAttri("", false, "A339CallToActionId", A339CallToActionId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX10ASASDT_TRNATTRIBUTES1572( A339CallToActionId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
         {
            A58ProductServiceId = StringUtil.StrToGuid( GetPar( "ProductServiceId"));
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
            A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A58ProductServiceId, A29LocationId, A11OrganisationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A366LocationDynamicFormId = StringUtil.StrToGuid( GetPar( "LocationDynamicFormId"));
            n366LocationDynamicFormId = false;
            AssignAttri("", false, "A366LocationDynamicFormId", A366LocationDynamicFormId.ToString());
            A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A366LocationDynamicFormId, A11OrganisationId, A29LocationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_17") == 0 )
         {
            A206WWPFormId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
            A207WWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormVersionNumber"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_17( A206WWPFormId, A207WWPFormVersionNumber) ;
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( "Trn_Call To Action", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCallToActionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_calltoaction( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_calltoaction( IGxContext context )
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
         cmbCallToActionType = new GXCombobox();
         chkWWPFormIsWizard = new GXCheckbox();
         cmbWWPFormResume = new GXCombobox();
         chkWWPFormInstantiated = new GXCheckbox();
         cmbWWPFormType = new GXCombobox();
         chkWWPFormIsForDynamicValidations = new GXCheckbox();
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
            return "trn_calltoaction_Execute" ;
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
         if ( cmbCallToActionType.ItemCount > 0 )
         {
            A340CallToActionType = cmbCallToActionType.getValidValue(A340CallToActionType);
            AssignAttri("", false, "A340CallToActionType", A340CallToActionType);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCallToActionType.CurrentValue = StringUtil.RTrim( A340CallToActionType);
            AssignProp("", false, cmbCallToActionType_Internalname, "Values", cmbCallToActionType.ToJavascriptSource(), true);
         }
         A232WWPFormIsWizard = StringUtil.StrToBool( StringUtil.BoolToStr( A232WWPFormIsWizard));
         AssignAttri("", false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
         if ( cmbWWPFormResume.ItemCount > 0 )
         {
            A216WWPFormResume = (short)(Math.Round(NumberUtil.Val( cmbWWPFormResume.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A216WWPFormResume", StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPFormResume.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
            AssignProp("", false, cmbWWPFormResume_Internalname, "Values", cmbWWPFormResume.ToJavascriptSource(), true);
         }
         A234WWPFormInstantiated = StringUtil.StrToBool( StringUtil.BoolToStr( A234WWPFormInstantiated));
         AssignAttri("", false, "A234WWPFormInstantiated", A234WWPFormInstantiated);
         if ( cmbWWPFormType.ItemCount > 0 )
         {
            A240WWPFormType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPFormType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            AssignProp("", false, cmbWWPFormType_Internalname, "Values", cmbWWPFormType.ToJavascriptSource(), true);
         }
         A242WWPFormIsForDynamicValidations = StringUtil.StrToBool( StringUtil.BoolToStr( A242WWPFormIsForDynamicValidations));
         AssignAttri("", false, "A242WWPFormIsForDynamicValidations", A242WWPFormIsForDynamicValidations);
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
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_CallToAction.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCallToActionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCallToActionId_Internalname, context.GetMessage( "Action Id", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCallToActionId_Internalname, A339CallToActionId.ToString(), A339CallToActionId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCallToActionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCallToActionId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_CallToAction.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductServiceId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductServiceId_Internalname, context.GetMessage( "Product/Service", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductServiceId_Internalname, A58ProductServiceId.ToString(), A58ProductServiceId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductServiceId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductServiceId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_CallToAction.htm");
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
         GxWebStd.gx_label_element( context, edtOrganisationId_Internalname, context.GetMessage( "Organisations", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationId_Internalname, A11OrganisationId.ToString(), A11OrganisationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrganisationId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_CallToAction.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCallToActionName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCallToActionName_Internalname, context.GetMessage( "Action Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCallToActionName_Internalname, A368CallToActionName, StringUtil.RTrim( context.localUtil.Format( A368CallToActionName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCallToActionName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCallToActionName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_CallToAction.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbCallToActionType_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbCallToActionType_Internalname, context.GetMessage( "Action Type", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbCallToActionType, cmbCallToActionType_Internalname, StringUtil.RTrim( A340CallToActionType), 1, cmbCallToActionType_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbCallToActionType.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 0, "HLP_Trn_CallToAction.htm");
         cmbCallToActionType.CurrentValue = StringUtil.RTrim( A340CallToActionType);
         AssignProp("", false, cmbCallToActionType_Internalname, "Values", (string)(cmbCallToActionType.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCallToActionPhone_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCallToActionPhone_Internalname, context.GetMessage( "Action Phone", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A342CallToActionPhone);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCallToActionPhone_Internalname, StringUtil.RTrim( A342CallToActionPhone), StringUtil.RTrim( context.localUtil.Format( A342CallToActionPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtCallToActionPhone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCallToActionPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Trn_CallToAction.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCallToActionUrl_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCallToActionUrl_Internalname, context.GetMessage( "Action Url", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCallToActionUrl_Internalname, A367CallToActionUrl, StringUtil.RTrim( context.localUtil.Format( A367CallToActionUrl, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", A367CallToActionUrl, "_blank", "", "", edtCallToActionUrl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCallToActionUrl_Enabled, 0, "url", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Url", "start", true, "", "HLP_Trn_CallToAction.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCallToActionEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCallToActionEmail_Internalname, context.GetMessage( "Action Email", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCallToActionEmail_Internalname, A341CallToActionEmail, StringUtil.RTrim( context.localUtil.Format( A341CallToActionEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A341CallToActionEmail, "", "", "", edtCallToActionEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCallToActionEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Trn_CallToAction.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationDynamicFormId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationDynamicFormId_Internalname, context.GetMessage( "Trn_Location Dynamic Form", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationDynamicFormId_Internalname, A366LocationDynamicFormId.ToString(), A366LocationDynamicFormId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationDynamicFormId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationDynamicFormId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_CallToAction.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormId_Internalname, context.GetMessage( "WWPForm Id", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPFormId_Enabled!=0) ? context.localUtil.Format( (decimal)(A206WWPFormId), "ZZZ9") : context.localUtil.Format( (decimal)(A206WWPFormId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPFormId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_CallToAction.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormVersionNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormVersionNumber_Internalname, context.GetMessage( "WWPForm Version Number", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormVersionNumber_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPFormVersionNumber_Enabled!=0) ? context.localUtil.Format( (decimal)(A207WWPFormVersionNumber), "ZZZ9") : context.localUtil.Format( (decimal)(A207WWPFormVersionNumber), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormVersionNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPFormVersionNumber_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_CallToAction.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormReferenceName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormReferenceName_Internalname, context.GetMessage( "WWPForm Reference Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormReferenceName_Internalname, A208WWPFormReferenceName, StringUtil.RTrim( context.localUtil.Format( A208WWPFormReferenceName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormReferenceName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPFormReferenceName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_CallToAction.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormTitle_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormTitle_Internalname, context.GetMessage( "WWPForm Title", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormTitle_Internalname, A209WWPFormTitle, StringUtil.RTrim( context.localUtil.Format( A209WWPFormTitle, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormTitle_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPFormTitle_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_CallToAction.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormDate_Internalname, context.GetMessage( "WWPForm Date", ""), "col-sm-4 AttributeDateTimeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPFormDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPFormDate_Internalname, context.localUtil.TToC( A231WWPFormDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A231WWPFormDate, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormDate_Jsonclick, 0, "AttributeDateTime", "", "", "", "", 1, edtWWPFormDate_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_CallToAction.htm");
         GxWebStd.gx_bitmap( context, edtWWPFormDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPFormDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_CallToAction.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPFormIsWizard_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPFormIsWizard_Internalname, context.GetMessage( "WWPForm Is Wizard", ""), "col-sm-4 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPFormIsWizard_Internalname, StringUtil.BoolToStr( A232WWPFormIsWizard), "", context.GetMessage( "WWPForm Is Wizard", ""), 1, chkWWPFormIsWizard.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(91, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,91);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbWWPFormResume_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbWWPFormResume_Internalname, context.GetMessage( "WWPForm Resume", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbWWPFormResume, cmbWWPFormResume_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0)), 1, cmbWWPFormResume_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbWWPFormResume.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "", true, 0, "HLP_Trn_CallToAction.htm");
         cmbWWPFormResume.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
         AssignProp("", false, cmbWWPFormResume_Internalname, "Values", (string)(cmbWWPFormResume.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormResumeMessage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormResumeMessage_Internalname, context.GetMessage( "WWPForm Resume Message", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPFormResumeMessage_Internalname, A235WWPFormResumeMessage, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", 0, 1, edtWWPFormResumeMessage_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_CallToAction.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormValidations_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormValidations_Internalname, context.GetMessage( "WWPForm Validations", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPFormValidations_Internalname, A233WWPFormValidations, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"", 0, 1, edtWWPFormValidations_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_CallToAction.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPFormInstantiated_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPFormInstantiated_Internalname, context.GetMessage( "WWPForm Instantiated", ""), "col-sm-4 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPFormInstantiated_Internalname, StringUtil.BoolToStr( A234WWPFormInstantiated), "", context.GetMessage( "WWPForm Instantiated", ""), 1, chkWWPFormInstantiated.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(111, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,111);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormLatestVersionNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormLatestVersionNumber_Internalname, context.GetMessage( "WWPForm Latest Version Number", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormLatestVersionNumber_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A219WWPFormLatestVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPFormLatestVersionNumber_Enabled!=0) ? context.localUtil.Format( (decimal)(A219WWPFormLatestVersionNumber), "ZZZ9") : context.localUtil.Format( (decimal)(A219WWPFormLatestVersionNumber), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,116);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormLatestVersionNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPFormLatestVersionNumber_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_CallToAction.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbWWPFormType_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbWWPFormType_Internalname, context.GetMessage( "WWPForm Type", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbWWPFormType, cmbWWPFormType_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0)), 1, cmbWWPFormType_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbWWPFormType.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,121);\"", "", true, 0, "HLP_Trn_CallToAction.htm");
         cmbWWPFormType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
         AssignProp("", false, cmbWWPFormType_Internalname, "Values", (string)(cmbWWPFormType.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormSectionRefElements_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormSectionRefElements_Internalname, context.GetMessage( "WWPForm Section Ref Elements", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPFormSectionRefElements_Internalname, A241WWPFormSectionRefElements, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,126);\"", 0, 1, edtWWPFormSectionRefElements_Enabled, 0, 80, "chr", 5, "row", 0, StyleString, ClassString, "", "", "400", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_CallToAction.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPFormIsForDynamicValidations_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPFormIsForDynamicValidations_Internalname, context.GetMessage( "WWPForm Is For Dynamic Validations", ""), "col-sm-4 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPFormIsForDynamicValidations_Internalname, StringUtil.BoolToStr( A242WWPFormIsForDynamicValidations), "", context.GetMessage( "WWPForm Is For Dynamic Validations", ""), 1, chkWWPFormIsForDynamicValidations.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(131, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,131);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_CallToAction.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_CallToAction.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 140,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_CallToAction.htm");
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
         E11152 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z339CallToActionId = StringUtil.StrToGuid( cgiGet( "Z339CallToActionId"));
               Z367CallToActionUrl = cgiGet( "Z367CallToActionUrl");
               Z368CallToActionName = cgiGet( "Z368CallToActionName");
               Z340CallToActionType = cgiGet( "Z340CallToActionType");
               Z342CallToActionPhone = cgiGet( "Z342CallToActionPhone");
               Z499CallToActionPhoneCode = cgiGet( "Z499CallToActionPhoneCode");
               Z500CallToActionPhoneNumber = cgiGet( "Z500CallToActionPhoneNumber");
               Z341CallToActionEmail = cgiGet( "Z341CallToActionEmail");
               Z11OrganisationId = StringUtil.StrToGuid( cgiGet( "Z11OrganisationId"));
               Z29LocationId = StringUtil.StrToGuid( cgiGet( "Z29LocationId"));
               Z58ProductServiceId = StringUtil.StrToGuid( cgiGet( "Z58ProductServiceId"));
               Z366LocationDynamicFormId = StringUtil.StrToGuid( cgiGet( "Z366LocationDynamicFormId"));
               n366LocationDynamicFormId = ((Guid.Empty==A366LocationDynamicFormId) ? true : false);
               A499CallToActionPhoneCode = cgiGet( "Z499CallToActionPhoneCode");
               A500CallToActionPhoneNumber = cgiGet( "Z500CallToActionPhoneNumber");
               A29LocationId = StringUtil.StrToGuid( cgiGet( "Z29LocationId"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               ajax_req_read_hidden_sdt(cgiGet( "vSDT_TRNATTRIBUTES"), AV27SDT_TrnAttributes);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A500CallToActionPhoneNumber = cgiGet( "CALLTOACTIONPHONENUMBER");
               A499CallToActionPhoneCode = cgiGet( "CALLTOACTIONPHONECODE");
               A29LocationId = StringUtil.StrToGuid( cgiGet( "LOCATIONID"));
               /* Read variables values. */
               if ( StringUtil.StrCmp(cgiGet( edtCallToActionId_Internalname), "") == 0 )
               {
                  A339CallToActionId = Guid.Empty;
                  AssignAttri("", false, "A339CallToActionId", A339CallToActionId.ToString());
               }
               else
               {
                  try
                  {
                     A339CallToActionId = StringUtil.StrToGuid( cgiGet( edtCallToActionId_Internalname));
                     AssignAttri("", false, "A339CallToActionId", A339CallToActionId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "CALLTOACTIONID");
                     AnyError = 1;
                     GX_FocusControl = edtCallToActionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               if ( StringUtil.StrCmp(cgiGet( edtProductServiceId_Internalname), "") == 0 )
               {
                  A58ProductServiceId = Guid.Empty;
                  AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
               }
               else
               {
                  try
                  {
                     A58ProductServiceId = StringUtil.StrToGuid( cgiGet( edtProductServiceId_Internalname));
                     AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "PRODUCTSERVICEID");
                     AnyError = 1;
                     GX_FocusControl = edtProductServiceId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               if ( StringUtil.StrCmp(cgiGet( edtOrganisationId_Internalname), "") == 0 )
               {
                  A11OrganisationId = Guid.Empty;
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               }
               else
               {
                  try
                  {
                     A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
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
               A368CallToActionName = cgiGet( edtCallToActionName_Internalname);
               AssignAttri("", false, "A368CallToActionName", A368CallToActionName);
               cmbCallToActionType.CurrentValue = cgiGet( cmbCallToActionType_Internalname);
               A340CallToActionType = cgiGet( cmbCallToActionType_Internalname);
               AssignAttri("", false, "A340CallToActionType", A340CallToActionType);
               A342CallToActionPhone = cgiGet( edtCallToActionPhone_Internalname);
               AssignAttri("", false, "A342CallToActionPhone", A342CallToActionPhone);
               A367CallToActionUrl = cgiGet( edtCallToActionUrl_Internalname);
               AssignAttri("", false, "A367CallToActionUrl", A367CallToActionUrl);
               A341CallToActionEmail = cgiGet( edtCallToActionEmail_Internalname);
               AssignAttri("", false, "A341CallToActionEmail", A341CallToActionEmail);
               if ( StringUtil.StrCmp(cgiGet( edtLocationDynamicFormId_Internalname), "") == 0 )
               {
                  A366LocationDynamicFormId = Guid.Empty;
                  n366LocationDynamicFormId = false;
                  AssignAttri("", false, "A366LocationDynamicFormId", A366LocationDynamicFormId.ToString());
               }
               else
               {
                  try
                  {
                     A366LocationDynamicFormId = StringUtil.StrToGuid( cgiGet( edtLocationDynamicFormId_Internalname));
                     n366LocationDynamicFormId = false;
                     AssignAttri("", false, "A366LocationDynamicFormId", A366LocationDynamicFormId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "LOCATIONDYNAMICFORMID");
                     AnyError = 1;
                     GX_FocusControl = edtLocationDynamicFormId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               n366LocationDynamicFormId = ((Guid.Empty==A366LocationDynamicFormId) ? true : false);
               A206WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
               A207WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
               A208WWPFormReferenceName = cgiGet( edtWWPFormReferenceName_Internalname);
               AssignAttri("", false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
               A209WWPFormTitle = cgiGet( edtWWPFormTitle_Internalname);
               AssignAttri("", false, "A209WWPFormTitle", A209WWPFormTitle);
               A231WWPFormDate = context.localUtil.CToT( cgiGet( edtWWPFormDate_Internalname));
               AssignAttri("", false, "A231WWPFormDate", context.localUtil.TToC( A231WWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               A232WWPFormIsWizard = StringUtil.StrToBool( cgiGet( chkWWPFormIsWizard_Internalname));
               AssignAttri("", false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
               cmbWWPFormResume.CurrentValue = cgiGet( cmbWWPFormResume_Internalname);
               A216WWPFormResume = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPFormResume_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A216WWPFormResume", StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
               A235WWPFormResumeMessage = cgiGet( edtWWPFormResumeMessage_Internalname);
               AssignAttri("", false, "A235WWPFormResumeMessage", A235WWPFormResumeMessage);
               A233WWPFormValidations = cgiGet( edtWWPFormValidations_Internalname);
               AssignAttri("", false, "A233WWPFormValidations", A233WWPFormValidations);
               A234WWPFormInstantiated = StringUtil.StrToBool( cgiGet( chkWWPFormInstantiated_Internalname));
               AssignAttri("", false, "A234WWPFormInstantiated", A234WWPFormInstantiated);
               A219WWPFormLatestVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormLatestVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A219WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A219WWPFormLatestVersionNumber), 4, 0));
               cmbWWPFormType.CurrentValue = cgiGet( cmbWWPFormType_Internalname);
               A240WWPFormType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPFormType_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
               A241WWPFormSectionRefElements = cgiGet( edtWWPFormSectionRefElements_Internalname);
               AssignAttri("", false, "A241WWPFormSectionRefElements", A241WWPFormSectionRefElements);
               A242WWPFormIsForDynamicValidations = StringUtil.StrToBool( cgiGet( chkWWPFormIsForDynamicValidations_Internalname));
               AssignAttri("", false, "A242WWPFormIsForDynamicValidations", A242WWPFormIsForDynamicValidations);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_CallToAction");
               forbiddenHiddens.Add("LocationId", A29LocationId.ToString());
               forbiddenHiddens.Add("CallToActionPhoneCode", StringUtil.RTrim( context.localUtil.Format( A499CallToActionPhoneCode, "")));
               forbiddenHiddens.Add("CallToActionPhoneNumber", StringUtil.RTrim( context.localUtil.Format( A500CallToActionPhoneNumber, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A339CallToActionId != Z339CallToActionId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_calltoaction:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A339CallToActionId = StringUtil.StrToGuid( GetPar( "CallToActionId"));
                  AssignAttri("", false, "A339CallToActionId", A339CallToActionId.ToString());
                  getEqualNoModal( ) ;
                  if ( IsIns( )  && (Guid.Empty==A339CallToActionId) && ( Gx_BScreen == 0 ) )
                  {
                     A339CallToActionId = Guid.NewGuid( );
                     AssignAttri("", false, "A339CallToActionId", A339CallToActionId.ToString());
                  }
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons_dsp( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  getEqualNoModal( ) ;
                  standaloneModal( ) ;
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
                           E11152 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12152 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
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
            E12152 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1572( ) ;
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
         if ( IsIns( ) )
         {
            bttBtntrn_delete_Enabled = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtntrn_enter_Visible = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
         }
         DisableAttributes1572( ) ;
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

      protected void ResetCaption150( )
      {
      }

      protected void E11152( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E12152( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1572( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z367CallToActionUrl = T00153_A367CallToActionUrl[0];
               Z368CallToActionName = T00153_A368CallToActionName[0];
               Z340CallToActionType = T00153_A340CallToActionType[0];
               Z342CallToActionPhone = T00153_A342CallToActionPhone[0];
               Z499CallToActionPhoneCode = T00153_A499CallToActionPhoneCode[0];
               Z500CallToActionPhoneNumber = T00153_A500CallToActionPhoneNumber[0];
               Z341CallToActionEmail = T00153_A341CallToActionEmail[0];
               Z11OrganisationId = T00153_A11OrganisationId[0];
               Z29LocationId = T00153_A29LocationId[0];
               Z58ProductServiceId = T00153_A58ProductServiceId[0];
               Z366LocationDynamicFormId = T00153_A366LocationDynamicFormId[0];
            }
            else
            {
               Z367CallToActionUrl = A367CallToActionUrl;
               Z368CallToActionName = A368CallToActionName;
               Z340CallToActionType = A340CallToActionType;
               Z342CallToActionPhone = A342CallToActionPhone;
               Z499CallToActionPhoneCode = A499CallToActionPhoneCode;
               Z500CallToActionPhoneNumber = A500CallToActionPhoneNumber;
               Z341CallToActionEmail = A341CallToActionEmail;
               Z11OrganisationId = A11OrganisationId;
               Z29LocationId = A29LocationId;
               Z58ProductServiceId = A58ProductServiceId;
               Z366LocationDynamicFormId = A366LocationDynamicFormId;
            }
         }
         if ( GX_JID == -14 )
         {
            Z339CallToActionId = A339CallToActionId;
            Z367CallToActionUrl = A367CallToActionUrl;
            Z368CallToActionName = A368CallToActionName;
            Z340CallToActionType = A340CallToActionType;
            Z342CallToActionPhone = A342CallToActionPhone;
            Z499CallToActionPhoneCode = A499CallToActionPhoneCode;
            Z500CallToActionPhoneNumber = A500CallToActionPhoneNumber;
            Z341CallToActionEmail = A341CallToActionEmail;
            Z11OrganisationId = A11OrganisationId;
            Z29LocationId = A29LocationId;
            Z58ProductServiceId = A58ProductServiceId;
            Z366LocationDynamicFormId = A366LocationDynamicFormId;
            Z206WWPFormId = A206WWPFormId;
            Z207WWPFormVersionNumber = A207WWPFormVersionNumber;
            Z208WWPFormReferenceName = A208WWPFormReferenceName;
            Z209WWPFormTitle = A209WWPFormTitle;
            Z231WWPFormDate = A231WWPFormDate;
            Z232WWPFormIsWizard = A232WWPFormIsWizard;
            Z216WWPFormResume = A216WWPFormResume;
            Z235WWPFormResumeMessage = A235WWPFormResumeMessage;
            Z233WWPFormValidations = A233WWPFormValidations;
            Z234WWPFormInstantiated = A234WWPFormInstantiated;
            Z240WWPFormType = A240WWPFormType;
            Z241WWPFormSectionRefElements = A241WWPFormSectionRefElements;
            Z242WWPFormIsForDynamicValidations = A242WWPFormIsForDynamicValidations;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A339CallToActionId) && ( Gx_BScreen == 0 ) )
         {
            A339CallToActionId = Guid.NewGuid( );
            AssignAttri("", false, "A339CallToActionId", A339CallToActionId.ToString());
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtntrn_delete_Enabled = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_delete_Enabled = 1;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1572( )
      {
         /* Using cursor T00157 */
         pr_default.execute(5, new Object[] {A339CallToActionId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound72 = 1;
            A367CallToActionUrl = T00157_A367CallToActionUrl[0];
            AssignAttri("", false, "A367CallToActionUrl", A367CallToActionUrl);
            A368CallToActionName = T00157_A368CallToActionName[0];
            AssignAttri("", false, "A368CallToActionName", A368CallToActionName);
            A340CallToActionType = T00157_A340CallToActionType[0];
            AssignAttri("", false, "A340CallToActionType", A340CallToActionType);
            A342CallToActionPhone = T00157_A342CallToActionPhone[0];
            AssignAttri("", false, "A342CallToActionPhone", A342CallToActionPhone);
            A499CallToActionPhoneCode = T00157_A499CallToActionPhoneCode[0];
            A500CallToActionPhoneNumber = T00157_A500CallToActionPhoneNumber[0];
            A341CallToActionEmail = T00157_A341CallToActionEmail[0];
            AssignAttri("", false, "A341CallToActionEmail", A341CallToActionEmail);
            A208WWPFormReferenceName = T00157_A208WWPFormReferenceName[0];
            AssignAttri("", false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
            A209WWPFormTitle = T00157_A209WWPFormTitle[0];
            AssignAttri("", false, "A209WWPFormTitle", A209WWPFormTitle);
            A231WWPFormDate = T00157_A231WWPFormDate[0];
            AssignAttri("", false, "A231WWPFormDate", context.localUtil.TToC( A231WWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A232WWPFormIsWizard = T00157_A232WWPFormIsWizard[0];
            AssignAttri("", false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
            A216WWPFormResume = T00157_A216WWPFormResume[0];
            AssignAttri("", false, "A216WWPFormResume", StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
            A235WWPFormResumeMessage = T00157_A235WWPFormResumeMessage[0];
            AssignAttri("", false, "A235WWPFormResumeMessage", A235WWPFormResumeMessage);
            A233WWPFormValidations = T00157_A233WWPFormValidations[0];
            AssignAttri("", false, "A233WWPFormValidations", A233WWPFormValidations);
            A234WWPFormInstantiated = T00157_A234WWPFormInstantiated[0];
            AssignAttri("", false, "A234WWPFormInstantiated", A234WWPFormInstantiated);
            A240WWPFormType = T00157_A240WWPFormType[0];
            AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            A241WWPFormSectionRefElements = T00157_A241WWPFormSectionRefElements[0];
            AssignAttri("", false, "A241WWPFormSectionRefElements", A241WWPFormSectionRefElements);
            A242WWPFormIsForDynamicValidations = T00157_A242WWPFormIsForDynamicValidations[0];
            AssignAttri("", false, "A242WWPFormIsForDynamicValidations", A242WWPFormIsForDynamicValidations);
            A11OrganisationId = T00157_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A29LocationId = T00157_A29LocationId[0];
            A58ProductServiceId = T00157_A58ProductServiceId[0];
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
            A366LocationDynamicFormId = T00157_A366LocationDynamicFormId[0];
            n366LocationDynamicFormId = T00157_n366LocationDynamicFormId[0];
            AssignAttri("", false, "A366LocationDynamicFormId", A366LocationDynamicFormId.ToString());
            A206WWPFormId = T00157_A206WWPFormId[0];
            AssignAttri("", false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
            A207WWPFormVersionNumber = T00157_A207WWPFormVersionNumber[0];
            AssignAttri("", false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
            ZM1572( -14) ;
         }
         pr_default.close(5);
         OnLoadActions1572( ) ;
      }

      protected void OnLoadActions1572( )
      {
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
         AssignAttri("", false, "A219WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A219WWPFormLatestVersionNumber), 4, 0));
         if ( StringUtil.StrCmp(A340CallToActionType, "Form") == 0 )
         {
            GXt_char2 = A367CallToActionUrl;
            new prc_getcalltoactionformurl(context ).execute( ref  A340CallToActionType, ref  A208WWPFormReferenceName, out  GXt_char2) ;
            AssignAttri("", false, "A340CallToActionType", A340CallToActionType);
            AssignAttri("", false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
            A367CallToActionUrl = GXt_char2;
            AssignAttri("", false, "A367CallToActionUrl", A367CallToActionUrl);
         }
      }

      protected void CheckExtendedTable1572( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T00154 */
         pr_default.execute(2, new Object[] {A58ProductServiceId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Services", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtProductServiceId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T00155 */
         pr_default.execute(3, new Object[] {n366LocationDynamicFormId, A366LocationDynamicFormId, A11OrganisationId, A29LocationId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (Guid.Empty==A366LocationDynamicFormId) || (Guid.Empty==A11OrganisationId) || (Guid.Empty==A29LocationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Location Dynamic Forms", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "LOCATIONID");
               AnyError = 1;
               GX_FocusControl = edtLocationDynamicFormId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A206WWPFormId = T00155_A206WWPFormId[0];
         AssignAttri("", false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
         A207WWPFormVersionNumber = T00155_A207WWPFormVersionNumber[0];
         AssignAttri("", false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
         pr_default.close(3);
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
         AssignAttri("", false, "A219WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A219WWPFormLatestVersionNumber), 4, 0));
         /* Using cursor T00156 */
         pr_default.execute(4, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A206WWPFormId) || (0==A207WWPFormVersionNumber) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Dynamic Form", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPFORMVERSIONNUMBER");
               AnyError = 1;
            }
         }
         A208WWPFormReferenceName = T00156_A208WWPFormReferenceName[0];
         AssignAttri("", false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
         A209WWPFormTitle = T00156_A209WWPFormTitle[0];
         AssignAttri("", false, "A209WWPFormTitle", A209WWPFormTitle);
         A231WWPFormDate = T00156_A231WWPFormDate[0];
         AssignAttri("", false, "A231WWPFormDate", context.localUtil.TToC( A231WWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A232WWPFormIsWizard = T00156_A232WWPFormIsWizard[0];
         AssignAttri("", false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
         A216WWPFormResume = T00156_A216WWPFormResume[0];
         AssignAttri("", false, "A216WWPFormResume", StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
         A235WWPFormResumeMessage = T00156_A235WWPFormResumeMessage[0];
         AssignAttri("", false, "A235WWPFormResumeMessage", A235WWPFormResumeMessage);
         A233WWPFormValidations = T00156_A233WWPFormValidations[0];
         AssignAttri("", false, "A233WWPFormValidations", A233WWPFormValidations);
         A234WWPFormInstantiated = T00156_A234WWPFormInstantiated[0];
         AssignAttri("", false, "A234WWPFormInstantiated", A234WWPFormInstantiated);
         A240WWPFormType = T00156_A240WWPFormType[0];
         AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
         A241WWPFormSectionRefElements = T00156_A241WWPFormSectionRefElements[0];
         AssignAttri("", false, "A241WWPFormSectionRefElements", A241WWPFormSectionRefElements);
         A242WWPFormIsForDynamicValidations = T00156_A242WWPFormIsForDynamicValidations[0];
         AssignAttri("", false, "A242WWPFormIsForDynamicValidations", A242WWPFormIsForDynamicValidations);
         pr_default.close(4);
         if ( StringUtil.StrCmp(A340CallToActionType, "Form") == 0 )
         {
            GXt_char2 = A367CallToActionUrl;
            new prc_getcalltoactionformurl(context ).execute( ref  A340CallToActionType, ref  A208WWPFormReferenceName, out  GXt_char2) ;
            AssignAttri("", false, "A340CallToActionType", A340CallToActionType);
            AssignAttri("", false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
            A367CallToActionUrl = GXt_char2;
            AssignAttri("", false, "A367CallToActionUrl", A367CallToActionUrl);
         }
         if ( ! ( ( StringUtil.StrCmp(A340CallToActionType, "Phone") == 0 ) || ( StringUtil.StrCmp(A340CallToActionType, "Email") == 0 ) || ( StringUtil.StrCmp(A340CallToActionType, "Form") == 0 ) || ( StringUtil.StrCmp(A340CallToActionType, "SiteUrl") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Call To Action Type", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "CALLTOACTIONTYPE");
            AnyError = 1;
            GX_FocusControl = cmbCallToActionType_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A367CallToActionUrl,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Call To Action Url", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "CALLTOACTIONURL");
            AnyError = 1;
            GX_FocusControl = edtCallToActionUrl_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A341CallToActionEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "Invalid email pattern", ""), context.GetMessage( "Call To Action Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "CALLTOACTIONEMAIL");
            AnyError = 1;
            GX_FocusControl = edtCallToActionEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1572( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_15( Guid A58ProductServiceId ,
                                Guid A29LocationId ,
                                Guid A11OrganisationId )
      {
         /* Using cursor T00158 */
         pr_default.execute(6, new Object[] {A58ProductServiceId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Services", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtProductServiceId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_16( Guid A366LocationDynamicFormId ,
                                Guid A11OrganisationId ,
                                Guid A29LocationId )
      {
         /* Using cursor T00159 */
         pr_default.execute(7, new Object[] {n366LocationDynamicFormId, A366LocationDynamicFormId, A11OrganisationId, A29LocationId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (Guid.Empty==A366LocationDynamicFormId) || (Guid.Empty==A11OrganisationId) || (Guid.Empty==A29LocationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Location Dynamic Forms", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "LOCATIONID");
               AnyError = 1;
               GX_FocusControl = edtLocationDynamicFormId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A206WWPFormId = T00159_A206WWPFormId[0];
         AssignAttri("", false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
         A207WWPFormVersionNumber = T00159_A207WWPFormVersionNumber[0];
         AssignAttri("", false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_17( short A206WWPFormId ,
                                short A207WWPFormVersionNumber )
      {
         /* Using cursor T001510 */
         pr_default.execute(8, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A206WWPFormId) || (0==A207WWPFormVersionNumber) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Dynamic Form", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPFORMVERSIONNUMBER");
               AnyError = 1;
            }
         }
         A208WWPFormReferenceName = T001510_A208WWPFormReferenceName[0];
         AssignAttri("", false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
         A209WWPFormTitle = T001510_A209WWPFormTitle[0];
         AssignAttri("", false, "A209WWPFormTitle", A209WWPFormTitle);
         A231WWPFormDate = T001510_A231WWPFormDate[0];
         AssignAttri("", false, "A231WWPFormDate", context.localUtil.TToC( A231WWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A232WWPFormIsWizard = T001510_A232WWPFormIsWizard[0];
         AssignAttri("", false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
         A216WWPFormResume = T001510_A216WWPFormResume[0];
         AssignAttri("", false, "A216WWPFormResume", StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
         A235WWPFormResumeMessage = T001510_A235WWPFormResumeMessage[0];
         AssignAttri("", false, "A235WWPFormResumeMessage", A235WWPFormResumeMessage);
         A233WWPFormValidations = T001510_A233WWPFormValidations[0];
         AssignAttri("", false, "A233WWPFormValidations", A233WWPFormValidations);
         A234WWPFormInstantiated = T001510_A234WWPFormInstantiated[0];
         AssignAttri("", false, "A234WWPFormInstantiated", A234WWPFormInstantiated);
         A240WWPFormType = T001510_A240WWPFormType[0];
         AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
         A241WWPFormSectionRefElements = T001510_A241WWPFormSectionRefElements[0];
         AssignAttri("", false, "A241WWPFormSectionRefElements", A241WWPFormSectionRefElements);
         A242WWPFormIsForDynamicValidations = T001510_A242WWPFormIsForDynamicValidations[0];
         AssignAttri("", false, "A242WWPFormIsForDynamicValidations", A242WWPFormIsForDynamicValidations);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A208WWPFormReferenceName)+"\""+","+"\""+GXUtil.EncodeJSConstant( A209WWPFormTitle)+"\""+","+"\""+GXUtil.EncodeJSConstant( context.localUtil.TToC( A231WWPFormDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( A232WWPFormIsWizard))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A216WWPFormResume), 1, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A235WWPFormResumeMessage)+"\""+","+"\""+GXUtil.EncodeJSConstant( A233WWPFormValidations)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( A234WWPFormInstantiated))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A240WWPFormType), 1, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A241WWPFormSectionRefElements)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( A242WWPFormIsForDynamicValidations))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey1572( )
      {
         /* Using cursor T001511 */
         pr_default.execute(9, new Object[] {A339CallToActionId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound72 = 1;
         }
         else
         {
            RcdFound72 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00153 */
         pr_default.execute(1, new Object[] {A339CallToActionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1572( 14) ;
            RcdFound72 = 1;
            A339CallToActionId = T00153_A339CallToActionId[0];
            AssignAttri("", false, "A339CallToActionId", A339CallToActionId.ToString());
            A367CallToActionUrl = T00153_A367CallToActionUrl[0];
            AssignAttri("", false, "A367CallToActionUrl", A367CallToActionUrl);
            A368CallToActionName = T00153_A368CallToActionName[0];
            AssignAttri("", false, "A368CallToActionName", A368CallToActionName);
            A340CallToActionType = T00153_A340CallToActionType[0];
            AssignAttri("", false, "A340CallToActionType", A340CallToActionType);
            A342CallToActionPhone = T00153_A342CallToActionPhone[0];
            AssignAttri("", false, "A342CallToActionPhone", A342CallToActionPhone);
            A499CallToActionPhoneCode = T00153_A499CallToActionPhoneCode[0];
            A500CallToActionPhoneNumber = T00153_A500CallToActionPhoneNumber[0];
            A341CallToActionEmail = T00153_A341CallToActionEmail[0];
            AssignAttri("", false, "A341CallToActionEmail", A341CallToActionEmail);
            A11OrganisationId = T00153_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A29LocationId = T00153_A29LocationId[0];
            A58ProductServiceId = T00153_A58ProductServiceId[0];
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
            A366LocationDynamicFormId = T00153_A366LocationDynamicFormId[0];
            n366LocationDynamicFormId = T00153_n366LocationDynamicFormId[0];
            AssignAttri("", false, "A366LocationDynamicFormId", A366LocationDynamicFormId.ToString());
            Z339CallToActionId = A339CallToActionId;
            sMode72 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1572( ) ;
            if ( AnyError == 1 )
            {
               RcdFound72 = 0;
               InitializeNonKey1572( ) ;
            }
            Gx_mode = sMode72;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound72 = 0;
            InitializeNonKey1572( ) ;
            sMode72 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode72;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1572( ) ;
         if ( RcdFound72 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound72 = 0;
         /* Using cursor T001512 */
         pr_default.execute(10, new Object[] {A339CallToActionId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( GuidUtil.Compare(T001512_A339CallToActionId[0], A339CallToActionId, 0) < 0 ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( GuidUtil.Compare(T001512_A339CallToActionId[0], A339CallToActionId, 0) > 0 ) ) )
            {
               A339CallToActionId = T001512_A339CallToActionId[0];
               AssignAttri("", false, "A339CallToActionId", A339CallToActionId.ToString());
               RcdFound72 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound72 = 0;
         /* Using cursor T001513 */
         pr_default.execute(11, new Object[] {A339CallToActionId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( GuidUtil.Compare(T001513_A339CallToActionId[0], A339CallToActionId, 0) > 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( GuidUtil.Compare(T001513_A339CallToActionId[0], A339CallToActionId, 0) < 0 ) ) )
            {
               A339CallToActionId = T001513_A339CallToActionId[0];
               AssignAttri("", false, "A339CallToActionId", A339CallToActionId.ToString());
               RcdFound72 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1572( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCallToActionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1572( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound72 == 1 )
            {
               if ( A339CallToActionId != Z339CallToActionId )
               {
                  A339CallToActionId = Z339CallToActionId;
                  AssignAttri("", false, "A339CallToActionId", A339CallToActionId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CALLTOACTIONID");
                  AnyError = 1;
                  GX_FocusControl = edtCallToActionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCallToActionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1572( ) ;
                  GX_FocusControl = edtCallToActionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A339CallToActionId != Z339CallToActionId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCallToActionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1572( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CALLTOACTIONID");
                     AnyError = 1;
                     GX_FocusControl = edtCallToActionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCallToActionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1572( ) ;
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
      }

      protected void btn_delete( )
      {
         if ( A339CallToActionId != Z339CallToActionId )
         {
            A339CallToActionId = Z339CallToActionId;
            AssignAttri("", false, "A339CallToActionId", A339CallToActionId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CALLTOACTIONID");
            AnyError = 1;
            GX_FocusControl = edtCallToActionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCallToActionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound72 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CALLTOACTIONID");
            AnyError = 1;
            GX_FocusControl = edtCallToActionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtProductServiceId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1572( ) ;
         if ( RcdFound72 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProductServiceId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1572( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound72 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProductServiceId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound72 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProductServiceId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1572( ) ;
         if ( RcdFound72 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound72 != 0 )
            {
               ScanNext1572( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProductServiceId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1572( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1572( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00152 */
            pr_default.execute(0, new Object[] {A339CallToActionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_CallToAction"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z367CallToActionUrl, T00152_A367CallToActionUrl[0]) != 0 ) || ( StringUtil.StrCmp(Z368CallToActionName, T00152_A368CallToActionName[0]) != 0 ) || ( StringUtil.StrCmp(Z340CallToActionType, T00152_A340CallToActionType[0]) != 0 ) || ( StringUtil.StrCmp(Z342CallToActionPhone, T00152_A342CallToActionPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z499CallToActionPhoneCode, T00152_A499CallToActionPhoneCode[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z500CallToActionPhoneNumber, T00152_A500CallToActionPhoneNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z341CallToActionEmail, T00152_A341CallToActionEmail[0]) != 0 ) || ( Z11OrganisationId != T00152_A11OrganisationId[0] ) || ( Z29LocationId != T00152_A29LocationId[0] ) || ( Z58ProductServiceId != T00152_A58ProductServiceId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z366LocationDynamicFormId != T00152_A366LocationDynamicFormId[0] ) )
            {
               if ( StringUtil.StrCmp(Z367CallToActionUrl, T00152_A367CallToActionUrl[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_calltoaction:[seudo value changed for attri]"+"CallToActionUrl");
                  GXUtil.WriteLogRaw("Old: ",Z367CallToActionUrl);
                  GXUtil.WriteLogRaw("Current: ",T00152_A367CallToActionUrl[0]);
               }
               if ( StringUtil.StrCmp(Z368CallToActionName, T00152_A368CallToActionName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_calltoaction:[seudo value changed for attri]"+"CallToActionName");
                  GXUtil.WriteLogRaw("Old: ",Z368CallToActionName);
                  GXUtil.WriteLogRaw("Current: ",T00152_A368CallToActionName[0]);
               }
               if ( StringUtil.StrCmp(Z340CallToActionType, T00152_A340CallToActionType[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_calltoaction:[seudo value changed for attri]"+"CallToActionType");
                  GXUtil.WriteLogRaw("Old: ",Z340CallToActionType);
                  GXUtil.WriteLogRaw("Current: ",T00152_A340CallToActionType[0]);
               }
               if ( StringUtil.StrCmp(Z342CallToActionPhone, T00152_A342CallToActionPhone[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_calltoaction:[seudo value changed for attri]"+"CallToActionPhone");
                  GXUtil.WriteLogRaw("Old: ",Z342CallToActionPhone);
                  GXUtil.WriteLogRaw("Current: ",T00152_A342CallToActionPhone[0]);
               }
               if ( StringUtil.StrCmp(Z499CallToActionPhoneCode, T00152_A499CallToActionPhoneCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_calltoaction:[seudo value changed for attri]"+"CallToActionPhoneCode");
                  GXUtil.WriteLogRaw("Old: ",Z499CallToActionPhoneCode);
                  GXUtil.WriteLogRaw("Current: ",T00152_A499CallToActionPhoneCode[0]);
               }
               if ( StringUtil.StrCmp(Z500CallToActionPhoneNumber, T00152_A500CallToActionPhoneNumber[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_calltoaction:[seudo value changed for attri]"+"CallToActionPhoneNumber");
                  GXUtil.WriteLogRaw("Old: ",Z500CallToActionPhoneNumber);
                  GXUtil.WriteLogRaw("Current: ",T00152_A500CallToActionPhoneNumber[0]);
               }
               if ( StringUtil.StrCmp(Z341CallToActionEmail, T00152_A341CallToActionEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_calltoaction:[seudo value changed for attri]"+"CallToActionEmail");
                  GXUtil.WriteLogRaw("Old: ",Z341CallToActionEmail);
                  GXUtil.WriteLogRaw("Current: ",T00152_A341CallToActionEmail[0]);
               }
               if ( Z11OrganisationId != T00152_A11OrganisationId[0] )
               {
                  GXUtil.WriteLog("trn_calltoaction:[seudo value changed for attri]"+"OrganisationId");
                  GXUtil.WriteLogRaw("Old: ",Z11OrganisationId);
                  GXUtil.WriteLogRaw("Current: ",T00152_A11OrganisationId[0]);
               }
               if ( Z29LocationId != T00152_A29LocationId[0] )
               {
                  GXUtil.WriteLog("trn_calltoaction:[seudo value changed for attri]"+"LocationId");
                  GXUtil.WriteLogRaw("Old: ",Z29LocationId);
                  GXUtil.WriteLogRaw("Current: ",T00152_A29LocationId[0]);
               }
               if ( Z58ProductServiceId != T00152_A58ProductServiceId[0] )
               {
                  GXUtil.WriteLog("trn_calltoaction:[seudo value changed for attri]"+"ProductServiceId");
                  GXUtil.WriteLogRaw("Old: ",Z58ProductServiceId);
                  GXUtil.WriteLogRaw("Current: ",T00152_A58ProductServiceId[0]);
               }
               if ( Z366LocationDynamicFormId != T00152_A366LocationDynamicFormId[0] )
               {
                  GXUtil.WriteLog("trn_calltoaction:[seudo value changed for attri]"+"LocationDynamicFormId");
                  GXUtil.WriteLogRaw("Old: ",Z366LocationDynamicFormId);
                  GXUtil.WriteLogRaw("Current: ",T00152_A366LocationDynamicFormId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_CallToAction"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1572( )
      {
         if ( ! IsAuthorized("trn_calltoaction_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1572( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1572( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1572( 0) ;
            CheckOptimisticConcurrency1572( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1572( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1572( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001514 */
                     pr_default.execute(12, new Object[] {A339CallToActionId, A367CallToActionUrl, A368CallToActionName, A340CallToActionType, A342CallToActionPhone, A499CallToActionPhoneCode, A500CallToActionPhoneNumber, A341CallToActionEmail, A11OrganisationId, A29LocationId, A58ProductServiceId, n366LocationDynamicFormId, A366LocationDynamicFormId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_CallToAction");
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
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption150( ) ;
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
               Load1572( ) ;
            }
            EndLevel1572( ) ;
         }
         CloseExtendedTableCursors1572( ) ;
      }

      protected void Update1572( )
      {
         if ( ! IsAuthorized("trn_calltoaction_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1572( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1572( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1572( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1572( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1572( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001515 */
                     pr_default.execute(13, new Object[] {A367CallToActionUrl, A368CallToActionName, A340CallToActionType, A342CallToActionPhone, A499CallToActionPhoneCode, A500CallToActionPhoneNumber, A341CallToActionEmail, A11OrganisationId, A29LocationId, A58ProductServiceId, n366LocationDynamicFormId, A366LocationDynamicFormId, A339CallToActionId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_CallToAction");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_CallToAction"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1572( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption150( ) ;
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
            EndLevel1572( ) ;
         }
         CloseExtendedTableCursors1572( ) ;
      }

      protected void DeferredUpdate1572( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_calltoaction_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1572( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1572( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1572( ) ;
            AfterConfirm1572( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1572( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001516 */
                  pr_default.execute(14, new Object[] {A339CallToActionId});
                  pr_default.close(14);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_CallToAction");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound72 == 0 )
                        {
                           InitAll1572( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption150( ) ;
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
         sMode72 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1572( ) ;
         Gx_mode = sMode72;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1572( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001517 */
            pr_default.execute(15, new Object[] {n366LocationDynamicFormId, A366LocationDynamicFormId, A11OrganisationId, A29LocationId});
            A206WWPFormId = T001517_A206WWPFormId[0];
            AssignAttri("", false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
            A207WWPFormVersionNumber = T001517_A207WWPFormVersionNumber[0];
            AssignAttri("", false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
            pr_default.close(15);
            GXt_int1 = A219WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
            A219WWPFormLatestVersionNumber = GXt_int1;
            AssignAttri("", false, "A219WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A219WWPFormLatestVersionNumber), 4, 0));
            /* Using cursor T001518 */
            pr_default.execute(16, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
            A208WWPFormReferenceName = T001518_A208WWPFormReferenceName[0];
            AssignAttri("", false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
            A209WWPFormTitle = T001518_A209WWPFormTitle[0];
            AssignAttri("", false, "A209WWPFormTitle", A209WWPFormTitle);
            A231WWPFormDate = T001518_A231WWPFormDate[0];
            AssignAttri("", false, "A231WWPFormDate", context.localUtil.TToC( A231WWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A232WWPFormIsWizard = T001518_A232WWPFormIsWizard[0];
            AssignAttri("", false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
            A216WWPFormResume = T001518_A216WWPFormResume[0];
            AssignAttri("", false, "A216WWPFormResume", StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
            A235WWPFormResumeMessage = T001518_A235WWPFormResumeMessage[0];
            AssignAttri("", false, "A235WWPFormResumeMessage", A235WWPFormResumeMessage);
            A233WWPFormValidations = T001518_A233WWPFormValidations[0];
            AssignAttri("", false, "A233WWPFormValidations", A233WWPFormValidations);
            A234WWPFormInstantiated = T001518_A234WWPFormInstantiated[0];
            AssignAttri("", false, "A234WWPFormInstantiated", A234WWPFormInstantiated);
            A240WWPFormType = T001518_A240WWPFormType[0];
            AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            A241WWPFormSectionRefElements = T001518_A241WWPFormSectionRefElements[0];
            AssignAttri("", false, "A241WWPFormSectionRefElements", A241WWPFormSectionRefElements);
            A242WWPFormIsForDynamicValidations = T001518_A242WWPFormIsForDynamicValidations[0];
            AssignAttri("", false, "A242WWPFormIsForDynamicValidations", A242WWPFormIsForDynamicValidations);
            pr_default.close(16);
         }
      }

      protected void EndLevel1572( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1572( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_calltoaction",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues150( ) ;
            }
            /* After transaction rules */
            new prc_addtodynamictransalation(context ).execute(  AV27SDT_TrnAttributes) ;
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_calltoaction",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1572( )
      {
         /* Scan By routine */
         /* Using cursor T001519 */
         pr_default.execute(17);
         RcdFound72 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound72 = 1;
            A339CallToActionId = T001519_A339CallToActionId[0];
            AssignAttri("", false, "A339CallToActionId", A339CallToActionId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1572( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound72 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound72 = 1;
            A339CallToActionId = T001519_A339CallToActionId[0];
            AssignAttri("", false, "A339CallToActionId", A339CallToActionId.ToString());
         }
      }

      protected void ScanEnd1572( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm1572( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1572( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1572( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1572( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1572( )
      {
         /* Before Complete Rules */
         GXt_SdtSDT_TrnAttributes3 = AV27SDT_TrnAttributes;
         new prc_addcalltoactionattributestosdt(context ).execute(  A339CallToActionId, out  GXt_SdtSDT_TrnAttributes3) ;
         AV27SDT_TrnAttributes = GXt_SdtSDT_TrnAttributes3;
      }

      protected void BeforeValidate1572( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1572( )
      {
         edtCallToActionId_Enabled = 0;
         AssignProp("", false, edtCallToActionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCallToActionId_Enabled), 5, 0), true);
         edtProductServiceId_Enabled = 0;
         AssignProp("", false, edtProductServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Enabled), 5, 0), true);
         edtOrganisationId_Enabled = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         edtCallToActionName_Enabled = 0;
         AssignProp("", false, edtCallToActionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCallToActionName_Enabled), 5, 0), true);
         cmbCallToActionType.Enabled = 0;
         AssignProp("", false, cmbCallToActionType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCallToActionType.Enabled), 5, 0), true);
         edtCallToActionPhone_Enabled = 0;
         AssignProp("", false, edtCallToActionPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCallToActionPhone_Enabled), 5, 0), true);
         edtCallToActionUrl_Enabled = 0;
         AssignProp("", false, edtCallToActionUrl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCallToActionUrl_Enabled), 5, 0), true);
         edtCallToActionEmail_Enabled = 0;
         AssignProp("", false, edtCallToActionEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCallToActionEmail_Enabled), 5, 0), true);
         edtLocationDynamicFormId_Enabled = 0;
         AssignProp("", false, edtLocationDynamicFormId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationDynamicFormId_Enabled), 5, 0), true);
         edtWWPFormId_Enabled = 0;
         AssignProp("", false, edtWWPFormId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormId_Enabled), 5, 0), true);
         edtWWPFormVersionNumber_Enabled = 0;
         AssignProp("", false, edtWWPFormVersionNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormVersionNumber_Enabled), 5, 0), true);
         edtWWPFormReferenceName_Enabled = 0;
         AssignProp("", false, edtWWPFormReferenceName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormReferenceName_Enabled), 5, 0), true);
         edtWWPFormTitle_Enabled = 0;
         AssignProp("", false, edtWWPFormTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormTitle_Enabled), 5, 0), true);
         edtWWPFormDate_Enabled = 0;
         AssignProp("", false, edtWWPFormDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormDate_Enabled), 5, 0), true);
         chkWWPFormIsWizard.Enabled = 0;
         AssignProp("", false, chkWWPFormIsWizard_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPFormIsWizard.Enabled), 5, 0), true);
         cmbWWPFormResume.Enabled = 0;
         AssignProp("", false, cmbWWPFormResume_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormResume.Enabled), 5, 0), true);
         edtWWPFormResumeMessage_Enabled = 0;
         AssignProp("", false, edtWWPFormResumeMessage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormResumeMessage_Enabled), 5, 0), true);
         edtWWPFormValidations_Enabled = 0;
         AssignProp("", false, edtWWPFormValidations_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormValidations_Enabled), 5, 0), true);
         chkWWPFormInstantiated.Enabled = 0;
         AssignProp("", false, chkWWPFormInstantiated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPFormInstantiated.Enabled), 5, 0), true);
         edtWWPFormLatestVersionNumber_Enabled = 0;
         AssignProp("", false, edtWWPFormLatestVersionNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormLatestVersionNumber_Enabled), 5, 0), true);
         cmbWWPFormType.Enabled = 0;
         AssignProp("", false, cmbWWPFormType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormType.Enabled), 5, 0), true);
         edtWWPFormSectionRefElements_Enabled = 0;
         AssignProp("", false, edtWWPFormSectionRefElements_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormSectionRefElements_Enabled), 5, 0), true);
         chkWWPFormIsForDynamicValidations.Enabled = 0;
         AssignProp("", false, chkWWPFormIsForDynamicValidations_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPFormIsForDynamicValidations.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1572( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues150( )
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-"+StringUtil.Substring( context.GetLanguageProperty( "culture"), 1, 2)+".js", "?"+context.GetBuildNumber( 1918140), false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_calltoaction.aspx") +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_CallToAction");
         forbiddenHiddens.Add("LocationId", A29LocationId.ToString());
         forbiddenHiddens.Add("CallToActionPhoneCode", StringUtil.RTrim( context.localUtil.Format( A499CallToActionPhoneCode, "")));
         forbiddenHiddens.Add("CallToActionPhoneNumber", StringUtil.RTrim( context.localUtil.Format( A500CallToActionPhoneNumber, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_calltoaction:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z339CallToActionId", Z339CallToActionId.ToString());
         GxWebStd.gx_hidden_field( context, "Z367CallToActionUrl", Z367CallToActionUrl);
         GxWebStd.gx_hidden_field( context, "Z368CallToActionName", Z368CallToActionName);
         GxWebStd.gx_hidden_field( context, "Z340CallToActionType", Z340CallToActionType);
         GxWebStd.gx_hidden_field( context, "Z342CallToActionPhone", StringUtil.RTrim( Z342CallToActionPhone));
         GxWebStd.gx_hidden_field( context, "Z499CallToActionPhoneCode", Z499CallToActionPhoneCode);
         GxWebStd.gx_hidden_field( context, "Z500CallToActionPhoneNumber", Z500CallToActionPhoneNumber);
         GxWebStd.gx_hidden_field( context, "Z341CallToActionEmail", Z341CallToActionEmail);
         GxWebStd.gx_hidden_field( context, "Z11OrganisationId", Z11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z29LocationId", Z29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z58ProductServiceId", Z58ProductServiceId.ToString());
         GxWebStd.gx_hidden_field( context, "Z366LocationDynamicFormId", Z366LocationDynamicFormId.ToString());
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDT_TRNATTRIBUTES", AV27SDT_TrnAttributes);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDT_TRNATTRIBUTES", AV27SDT_TrnAttributes);
         }
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "CALLTOACTIONPHONENUMBER", A500CallToActionPhoneNumber);
         GxWebStd.gx_hidden_field( context, "CALLTOACTIONPHONECODE", A499CallToActionPhoneCode);
         GxWebStd.gx_hidden_field( context, "LOCATIONID", A29LocationId.ToString());
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
         return formatLink("trn_calltoaction.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_CallToAction" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Call To Action", "") ;
      }

      protected void InitializeNonKey1572( )
      {
         A367CallToActionUrl = "";
         AssignAttri("", false, "A367CallToActionUrl", A367CallToActionUrl);
         AV27SDT_TrnAttributes = new SdtSDT_TrnAttributes(context);
         A219WWPFormLatestVersionNumber = 0;
         AssignAttri("", false, "A219WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A219WWPFormLatestVersionNumber), 4, 0));
         A58ProductServiceId = Guid.Empty;
         AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
         A11OrganisationId = Guid.Empty;
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         A29LocationId = Guid.Empty;
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         A368CallToActionName = "";
         AssignAttri("", false, "A368CallToActionName", A368CallToActionName);
         A340CallToActionType = "";
         AssignAttri("", false, "A340CallToActionType", A340CallToActionType);
         A342CallToActionPhone = "";
         AssignAttri("", false, "A342CallToActionPhone", A342CallToActionPhone);
         A499CallToActionPhoneCode = "";
         AssignAttri("", false, "A499CallToActionPhoneCode", A499CallToActionPhoneCode);
         A500CallToActionPhoneNumber = "";
         AssignAttri("", false, "A500CallToActionPhoneNumber", A500CallToActionPhoneNumber);
         A341CallToActionEmail = "";
         AssignAttri("", false, "A341CallToActionEmail", A341CallToActionEmail);
         A366LocationDynamicFormId = Guid.Empty;
         n366LocationDynamicFormId = false;
         AssignAttri("", false, "A366LocationDynamicFormId", A366LocationDynamicFormId.ToString());
         n366LocationDynamicFormId = ((Guid.Empty==A366LocationDynamicFormId) ? true : false);
         A206WWPFormId = 0;
         AssignAttri("", false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
         A207WWPFormVersionNumber = 0;
         AssignAttri("", false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
         A208WWPFormReferenceName = "";
         AssignAttri("", false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
         A209WWPFormTitle = "";
         AssignAttri("", false, "A209WWPFormTitle", A209WWPFormTitle);
         A231WWPFormDate = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A231WWPFormDate", context.localUtil.TToC( A231WWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A232WWPFormIsWizard = false;
         AssignAttri("", false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
         A216WWPFormResume = 0;
         AssignAttri("", false, "A216WWPFormResume", StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
         A235WWPFormResumeMessage = "";
         AssignAttri("", false, "A235WWPFormResumeMessage", A235WWPFormResumeMessage);
         A233WWPFormValidations = "";
         AssignAttri("", false, "A233WWPFormValidations", A233WWPFormValidations);
         A234WWPFormInstantiated = false;
         AssignAttri("", false, "A234WWPFormInstantiated", A234WWPFormInstantiated);
         A240WWPFormType = 0;
         AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
         A241WWPFormSectionRefElements = "";
         AssignAttri("", false, "A241WWPFormSectionRefElements", A241WWPFormSectionRefElements);
         A242WWPFormIsForDynamicValidations = false;
         AssignAttri("", false, "A242WWPFormIsForDynamicValidations", A242WWPFormIsForDynamicValidations);
         Z367CallToActionUrl = "";
         Z368CallToActionName = "";
         Z340CallToActionType = "";
         Z342CallToActionPhone = "";
         Z499CallToActionPhoneCode = "";
         Z500CallToActionPhoneNumber = "";
         Z341CallToActionEmail = "";
         Z11OrganisationId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         Z58ProductServiceId = Guid.Empty;
         Z366LocationDynamicFormId = Guid.Empty;
      }

      protected void InitAll1572( )
      {
         A339CallToActionId = Guid.NewGuid( );
         AssignAttri("", false, "A339CallToActionId", A339CallToActionId.ToString());
         InitializeNonKey1572( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025614536821", true, true);
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
         context.AddJavascriptSource("trn_calltoaction.js", "?2025614536825", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtCallToActionId_Internalname = "CALLTOACTIONID";
         edtProductServiceId_Internalname = "PRODUCTSERVICEID";
         edtOrganisationId_Internalname = "ORGANISATIONID";
         edtCallToActionName_Internalname = "CALLTOACTIONNAME";
         cmbCallToActionType_Internalname = "CALLTOACTIONTYPE";
         edtCallToActionPhone_Internalname = "CALLTOACTIONPHONE";
         edtCallToActionUrl_Internalname = "CALLTOACTIONURL";
         edtCallToActionEmail_Internalname = "CALLTOACTIONEMAIL";
         edtLocationDynamicFormId_Internalname = "LOCATIONDYNAMICFORMID";
         edtWWPFormId_Internalname = "WWPFORMID";
         edtWWPFormVersionNumber_Internalname = "WWPFORMVERSIONNUMBER";
         edtWWPFormReferenceName_Internalname = "WWPFORMREFERENCENAME";
         edtWWPFormTitle_Internalname = "WWPFORMTITLE";
         edtWWPFormDate_Internalname = "WWPFORMDATE";
         chkWWPFormIsWizard_Internalname = "WWPFORMISWIZARD";
         cmbWWPFormResume_Internalname = "WWPFORMRESUME";
         edtWWPFormResumeMessage_Internalname = "WWPFORMRESUMEMESSAGE";
         edtWWPFormValidations_Internalname = "WWPFORMVALIDATIONS";
         chkWWPFormInstantiated_Internalname = "WWPFORMINSTANTIATED";
         edtWWPFormLatestVersionNumber_Internalname = "WWPFORMLATESTVERSIONNUMBER";
         cmbWWPFormType_Internalname = "WWPFORMTYPE";
         edtWWPFormSectionRefElements_Internalname = "WWPFORMSECTIONREFELEMENTS";
         chkWWPFormIsForDynamicValidations_Internalname = "WWPFORMISFORDYNAMICVALIDATIONS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
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
         Form.Caption = context.GetMessage( "Trn_Call To Action", "");
         bttBtntrn_delete_Enabled = 1;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         chkWWPFormIsForDynamicValidations.Enabled = 0;
         edtWWPFormSectionRefElements_Enabled = 0;
         cmbWWPFormType_Jsonclick = "";
         cmbWWPFormType.Enabled = 0;
         edtWWPFormLatestVersionNumber_Jsonclick = "";
         edtWWPFormLatestVersionNumber_Enabled = 0;
         chkWWPFormInstantiated.Enabled = 0;
         edtWWPFormValidations_Enabled = 0;
         edtWWPFormResumeMessage_Enabled = 0;
         cmbWWPFormResume_Jsonclick = "";
         cmbWWPFormResume.Enabled = 0;
         chkWWPFormIsWizard.Enabled = 0;
         edtWWPFormDate_Jsonclick = "";
         edtWWPFormDate_Enabled = 0;
         edtWWPFormTitle_Jsonclick = "";
         edtWWPFormTitle_Enabled = 0;
         edtWWPFormReferenceName_Jsonclick = "";
         edtWWPFormReferenceName_Enabled = 0;
         edtWWPFormVersionNumber_Jsonclick = "";
         edtWWPFormVersionNumber_Enabled = 0;
         edtWWPFormId_Jsonclick = "";
         edtWWPFormId_Enabled = 0;
         edtLocationDynamicFormId_Jsonclick = "";
         edtLocationDynamicFormId_Enabled = 1;
         edtCallToActionEmail_Jsonclick = "";
         edtCallToActionEmail_Enabled = 1;
         edtCallToActionUrl_Jsonclick = "";
         edtCallToActionUrl_Enabled = 1;
         edtCallToActionPhone_Jsonclick = "";
         edtCallToActionPhone_Enabled = 1;
         cmbCallToActionType_Jsonclick = "";
         cmbCallToActionType.Enabled = 1;
         edtCallToActionName_Jsonclick = "";
         edtCallToActionName_Enabled = 1;
         edtOrganisationId_Jsonclick = "";
         edtOrganisationId_Enabled = 1;
         edtProductServiceId_Jsonclick = "";
         edtProductServiceId_Enabled = 1;
         edtCallToActionId_Jsonclick = "";
         edtCallToActionId_Enabled = 1;
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

      protected void GX8ASAWWPFORMLATESTVERSIONNUMBER1572( short A206WWPFormId )
      {
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
         AssignAttri("", false, "A219WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A219WWPFormLatestVersionNumber), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A219WWPFormLatestVersionNumber), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX9ASACALLTOACTIONURL1572( string A340CallToActionType ,
                                                string A208WWPFormReferenceName )
      {
         if ( StringUtil.StrCmp(A340CallToActionType, "Form") == 0 )
         {
            GXt_char2 = A367CallToActionUrl;
            new prc_getcalltoactionformurl(context ).execute( ref  A340CallToActionType, ref  A208WWPFormReferenceName, out  GXt_char2) ;
            AssignAttri("", false, "A340CallToActionType", A340CallToActionType);
            AssignAttri("", false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
            A367CallToActionUrl = GXt_char2;
            AssignAttri("", false, "A367CallToActionUrl", A367CallToActionUrl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A367CallToActionUrl)+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX10ASASDT_TRNATTRIBUTES1572( Guid A339CallToActionId )
      {
         GXt_SdtSDT_TrnAttributes3 = AV27SDT_TrnAttributes;
         new prc_addcalltoactionattributestosdt(context ).execute(  A339CallToActionId, out  GXt_SdtSDT_TrnAttributes3) ;
         AV27SDT_TrnAttributes = GXt_SdtSDT_TrnAttributes3;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV27SDT_TrnAttributes.ToXml(false, true, "", "")))+"\"") ;
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
         cmbCallToActionType.Name = "CALLTOACTIONTYPE";
         cmbCallToActionType.WebTags = "";
         cmbCallToActionType.addItem("Phone", context.GetMessage( "Phone", ""), 0);
         cmbCallToActionType.addItem("Email", context.GetMessage( "Email", ""), 0);
         cmbCallToActionType.addItem("Form", context.GetMessage( "Form", ""), 0);
         cmbCallToActionType.addItem("SiteUrl", context.GetMessage( "Url", ""), 0);
         if ( cmbCallToActionType.ItemCount > 0 )
         {
            A340CallToActionType = cmbCallToActionType.getValidValue(A340CallToActionType);
            AssignAttri("", false, "A340CallToActionType", A340CallToActionType);
         }
         chkWWPFormIsWizard.Name = "WWPFORMISWIZARD";
         chkWWPFormIsWizard.WebTags = "";
         chkWWPFormIsWizard.Caption = context.GetMessage( "WWPForm Is Wizard", "");
         AssignProp("", false, chkWWPFormIsWizard_Internalname, "TitleCaption", chkWWPFormIsWizard.Caption, true);
         chkWWPFormIsWizard.CheckedValue = "false";
         A232WWPFormIsWizard = StringUtil.StrToBool( StringUtil.BoolToStr( A232WWPFormIsWizard));
         AssignAttri("", false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
         cmbWWPFormResume.Name = "WWPFORMRESUME";
         cmbWWPFormResume.WebTags = "";
         cmbWWPFormResume.addItem("0", context.GetMessage( "WWP_DF_Resume_Never", ""), 0);
         cmbWWPFormResume.addItem("1", context.GetMessage( "WWP_DF_Resume_AskUser", ""), 0);
         cmbWWPFormResume.addItem("2", context.GetMessage( "WWP_DF_Resume_Always", ""), 0);
         if ( cmbWWPFormResume.ItemCount > 0 )
         {
            A216WWPFormResume = (short)(Math.Round(NumberUtil.Val( cmbWWPFormResume.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A216WWPFormResume", StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
         }
         chkWWPFormInstantiated.Name = "WWPFORMINSTANTIATED";
         chkWWPFormInstantiated.WebTags = "";
         chkWWPFormInstantiated.Caption = context.GetMessage( "WWPForm Instantiated", "");
         AssignProp("", false, chkWWPFormInstantiated_Internalname, "TitleCaption", chkWWPFormInstantiated.Caption, true);
         chkWWPFormInstantiated.CheckedValue = "false";
         A234WWPFormInstantiated = StringUtil.StrToBool( StringUtil.BoolToStr( A234WWPFormInstantiated));
         AssignAttri("", false, "A234WWPFormInstantiated", A234WWPFormInstantiated);
         cmbWWPFormType.Name = "WWPFORMTYPE";
         cmbWWPFormType.WebTags = "";
         cmbWWPFormType.addItem("0", context.GetMessage( "WWP_DF_Type_DynamicForm", ""), 0);
         cmbWWPFormType.addItem("1", context.GetMessage( "WWP_DF_Type_DynamicSection", ""), 0);
         if ( cmbWWPFormType.ItemCount > 0 )
         {
            A240WWPFormType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
         }
         chkWWPFormIsForDynamicValidations.Name = "WWPFORMISFORDYNAMICVALIDATIONS";
         chkWWPFormIsForDynamicValidations.WebTags = "";
         chkWWPFormIsForDynamicValidations.Caption = context.GetMessage( "WWPForm Is For Dynamic Validations", "");
         AssignProp("", false, chkWWPFormIsForDynamicValidations_Internalname, "TitleCaption", chkWWPFormIsForDynamicValidations.Caption, true);
         chkWWPFormIsForDynamicValidations.CheckedValue = "false";
         A242WWPFormIsForDynamicValidations = StringUtil.StrToBool( StringUtil.BoolToStr( A242WWPFormIsForDynamicValidations));
         AssignAttri("", false, "A242WWPFormIsForDynamicValidations", A242WWPFormIsForDynamicValidations);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtProductServiceId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
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

      public void Valid_Calltoactionid( )
      {
         A240WWPFormType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormType.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbWWPFormType.CurrentValue = StringUtil.Str( (decimal)(A240WWPFormType), 1, 0);
         A216WWPFormResume = (short)(Math.Round(NumberUtil.Val( cmbWWPFormResume.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbWWPFormResume.CurrentValue = StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0);
         A340CallToActionType = cmbCallToActionType.CurrentValue;
         cmbCallToActionType.CurrentValue = A340CallToActionType;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbCallToActionType.ItemCount > 0 )
         {
            A340CallToActionType = cmbCallToActionType.getValidValue(A340CallToActionType);
            cmbCallToActionType.CurrentValue = A340CallToActionType;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCallToActionType.CurrentValue = StringUtil.RTrim( A340CallToActionType);
         }
         A232WWPFormIsWizard = StringUtil.StrToBool( StringUtil.BoolToStr( A232WWPFormIsWizard));
         if ( cmbWWPFormResume.ItemCount > 0 )
         {
            A216WWPFormResume = (short)(Math.Round(NumberUtil.Val( cmbWWPFormResume.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0))), "."), 18, MidpointRounding.ToEven));
            cmbWWPFormResume.CurrentValue = StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPFormResume.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
         }
         A234WWPFormInstantiated = StringUtil.StrToBool( StringUtil.BoolToStr( A234WWPFormInstantiated));
         if ( cmbWWPFormType.ItemCount > 0 )
         {
            A240WWPFormType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0))), "."), 18, MidpointRounding.ToEven));
            cmbWWPFormType.CurrentValue = StringUtil.Str( (decimal)(A240WWPFormType), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPFormType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
         }
         A242WWPFormIsForDynamicValidations = StringUtil.StrToBool( StringUtil.BoolToStr( A242WWPFormIsForDynamicValidations));
         /*  Sending validation outputs */
         AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         AssignAttri("", false, "A368CallToActionName", A368CallToActionName);
         AssignAttri("", false, "A340CallToActionType", A340CallToActionType);
         cmbCallToActionType.CurrentValue = StringUtil.RTrim( A340CallToActionType);
         AssignProp("", false, cmbCallToActionType_Internalname, "Values", cmbCallToActionType.ToJavascriptSource(), true);
         AssignAttri("", false, "A342CallToActionPhone", StringUtil.RTrim( A342CallToActionPhone));
         AssignAttri("", false, "A499CallToActionPhoneCode", A499CallToActionPhoneCode);
         AssignAttri("", false, "A500CallToActionPhoneNumber", A500CallToActionPhoneNumber);
         AssignAttri("", false, "A341CallToActionEmail", A341CallToActionEmail);
         AssignAttri("", false, "A366LocationDynamicFormId", A366LocationDynamicFormId.ToString());
         AssignAttri("", false, "A206WWPFormId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, ".", "")));
         AssignAttri("", false, "A207WWPFormVersionNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, ".", "")));
         AssignAttri("", false, "A219WWPFormLatestVersionNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(A219WWPFormLatestVersionNumber), 4, 0, ".", "")));
         AssignAttri("", false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
         AssignAttri("", false, "A209WWPFormTitle", A209WWPFormTitle);
         AssignAttri("", false, "A231WWPFormDate", context.localUtil.TToC( A231WWPFormDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
         AssignAttri("", false, "A216WWPFormResume", StringUtil.LTrim( StringUtil.NToC( (decimal)(A216WWPFormResume), 1, 0, ".", "")));
         cmbWWPFormResume.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
         AssignProp("", false, cmbWWPFormResume_Internalname, "Values", cmbWWPFormResume.ToJavascriptSource(), true);
         AssignAttri("", false, "A235WWPFormResumeMessage", A235WWPFormResumeMessage);
         AssignAttri("", false, "A233WWPFormValidations", A233WWPFormValidations);
         AssignAttri("", false, "A234WWPFormInstantiated", A234WWPFormInstantiated);
         AssignAttri("", false, "A240WWPFormType", StringUtil.LTrim( StringUtil.NToC( (decimal)(A240WWPFormType), 1, 0, ".", "")));
         cmbWWPFormType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
         AssignProp("", false, cmbWWPFormType_Internalname, "Values", cmbWWPFormType.ToJavascriptSource(), true);
         AssignAttri("", false, "A241WWPFormSectionRefElements", A241WWPFormSectionRefElements);
         AssignAttri("", false, "A242WWPFormIsForDynamicValidations", A242WWPFormIsForDynamicValidations);
         AssignAttri("", false, "A367CallToActionUrl", A367CallToActionUrl);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z339CallToActionId", Z339CallToActionId.ToString());
         GxWebStd.gx_hidden_field( context, "Z58ProductServiceId", Z58ProductServiceId.ToString());
         GxWebStd.gx_hidden_field( context, "Z11OrganisationId", Z11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z29LocationId", Z29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z368CallToActionName", Z368CallToActionName);
         GxWebStd.gx_hidden_field( context, "Z340CallToActionType", Z340CallToActionType);
         GxWebStd.gx_hidden_field( context, "Z342CallToActionPhone", StringUtil.RTrim( Z342CallToActionPhone));
         GxWebStd.gx_hidden_field( context, "Z499CallToActionPhoneCode", Z499CallToActionPhoneCode);
         GxWebStd.gx_hidden_field( context, "Z500CallToActionPhoneNumber", Z500CallToActionPhoneNumber);
         GxWebStd.gx_hidden_field( context, "Z341CallToActionEmail", Z341CallToActionEmail);
         GxWebStd.gx_hidden_field( context, "Z366LocationDynamicFormId", Z366LocationDynamicFormId.ToString());
         GxWebStd.gx_hidden_field( context, "Z206WWPFormId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z206WWPFormId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z207WWPFormVersionNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z207WWPFormVersionNumber), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z219WWPFormLatestVersionNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z219WWPFormLatestVersionNumber), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z208WWPFormReferenceName", Z208WWPFormReferenceName);
         GxWebStd.gx_hidden_field( context, "Z209WWPFormTitle", Z209WWPFormTitle);
         GxWebStd.gx_hidden_field( context, "Z231WWPFormDate", context.localUtil.TToC( Z231WWPFormDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z232WWPFormIsWizard", StringUtil.BoolToStr( Z232WWPFormIsWizard));
         GxWebStd.gx_hidden_field( context, "Z216WWPFormResume", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z216WWPFormResume), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z235WWPFormResumeMessage", Z235WWPFormResumeMessage);
         GxWebStd.gx_hidden_field( context, "Z233WWPFormValidations", Z233WWPFormValidations);
         GxWebStd.gx_hidden_field( context, "Z234WWPFormInstantiated", StringUtil.BoolToStr( Z234WWPFormInstantiated));
         GxWebStd.gx_hidden_field( context, "Z240WWPFormType", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z240WWPFormType), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z241WWPFormSectionRefElements", Z241WWPFormSectionRefElements);
         GxWebStd.gx_hidden_field( context, "Z242WWPFormIsForDynamicValidations", StringUtil.BoolToStr( Z242WWPFormIsForDynamicValidations));
         GxWebStd.gx_hidden_field( context, "Z367CallToActionUrl", Z367CallToActionUrl);
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Organisationid( )
      {
         /* Using cursor T001520 */
         pr_default.execute(18, new Object[] {A58ProductServiceId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Services", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtProductServiceId_Internalname;
         }
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Locationdynamicformid( )
      {
         n366LocationDynamicFormId = false;
         A340CallToActionType = cmbCallToActionType.CurrentValue;
         A216WWPFormResume = (short)(Math.Round(NumberUtil.Val( cmbWWPFormResume.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbWWPFormResume.CurrentValue = StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0);
         A240WWPFormType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormType.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbWWPFormType.CurrentValue = StringUtil.Str( (decimal)(A240WWPFormType), 1, 0);
         /* Using cursor T001517 */
         pr_default.execute(15, new Object[] {n366LocationDynamicFormId, A366LocationDynamicFormId, A11OrganisationId, A29LocationId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (Guid.Empty==A366LocationDynamicFormId) || (Guid.Empty==A11OrganisationId) || (Guid.Empty==A29LocationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Location Dynamic Forms", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "LOCATIONID");
               AnyError = 1;
               GX_FocusControl = edtLocationDynamicFormId_Internalname;
            }
         }
         A206WWPFormId = T001517_A206WWPFormId[0];
         A207WWPFormVersionNumber = T001517_A207WWPFormVersionNumber[0];
         pr_default.close(15);
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
         /* Using cursor T001518 */
         pr_default.execute(16, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         if ( (pr_default.getStatus(16) == 101) )
         {
            if ( ! ( (0==A206WWPFormId) || (0==A207WWPFormVersionNumber) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Dynamic Form", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPFORMVERSIONNUMBER");
               AnyError = 1;
            }
         }
         A208WWPFormReferenceName = T001518_A208WWPFormReferenceName[0];
         A209WWPFormTitle = T001518_A209WWPFormTitle[0];
         A231WWPFormDate = T001518_A231WWPFormDate[0];
         A232WWPFormIsWizard = T001518_A232WWPFormIsWizard[0];
         A216WWPFormResume = T001518_A216WWPFormResume[0];
         cmbWWPFormResume.CurrentValue = StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0);
         A235WWPFormResumeMessage = T001518_A235WWPFormResumeMessage[0];
         A233WWPFormValidations = T001518_A233WWPFormValidations[0];
         A234WWPFormInstantiated = T001518_A234WWPFormInstantiated[0];
         A240WWPFormType = T001518_A240WWPFormType[0];
         cmbWWPFormType.CurrentValue = StringUtil.Str( (decimal)(A240WWPFormType), 1, 0);
         A241WWPFormSectionRefElements = T001518_A241WWPFormSectionRefElements[0];
         A242WWPFormIsForDynamicValidations = T001518_A242WWPFormIsForDynamicValidations[0];
         pr_default.close(16);
         if ( StringUtil.StrCmp(A340CallToActionType, "Form") == 0 )
         {
            GXt_char2 = A367CallToActionUrl;
            new prc_getcalltoactionformurl(context ).execute( ref  A340CallToActionType, ref  A208WWPFormReferenceName, out  GXt_char2) ;
            A367CallToActionUrl = GXt_char2;
         }
         if ( ! ( GxRegex.IsMatch(A367CallToActionUrl,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Call To Action Url", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "LOCATIONDYNAMICFORMID");
            AnyError = 1;
            GX_FocusControl = edtLocationDynamicFormId_Internalname;
         }
         dynload_actions( ) ;
         A232WWPFormIsWizard = StringUtil.StrToBool( StringUtil.BoolToStr( A232WWPFormIsWizard));
         if ( cmbWWPFormResume.ItemCount > 0 )
         {
            A216WWPFormResume = (short)(Math.Round(NumberUtil.Val( cmbWWPFormResume.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0))), "."), 18, MidpointRounding.ToEven));
            cmbWWPFormResume.CurrentValue = StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPFormResume.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
         }
         A234WWPFormInstantiated = StringUtil.StrToBool( StringUtil.BoolToStr( A234WWPFormInstantiated));
         if ( cmbWWPFormType.ItemCount > 0 )
         {
            A240WWPFormType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0))), "."), 18, MidpointRounding.ToEven));
            cmbWWPFormType.CurrentValue = StringUtil.Str( (decimal)(A240WWPFormType), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPFormType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
         }
         A242WWPFormIsForDynamicValidations = StringUtil.StrToBool( StringUtil.BoolToStr( A242WWPFormIsForDynamicValidations));
         /*  Sending validation outputs */
         AssignAttri("", false, "A206WWPFormId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, ".", "")));
         AssignAttri("", false, "A207WWPFormVersionNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, ".", "")));
         AssignAttri("", false, "A219WWPFormLatestVersionNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(A219WWPFormLatestVersionNumber), 4, 0, ".", "")));
         AssignAttri("", false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
         AssignAttri("", false, "A209WWPFormTitle", A209WWPFormTitle);
         AssignAttri("", false, "A231WWPFormDate", context.localUtil.TToC( A231WWPFormDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
         AssignAttri("", false, "A216WWPFormResume", StringUtil.LTrim( StringUtil.NToC( (decimal)(A216WWPFormResume), 1, 0, ".", "")));
         cmbWWPFormResume.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
         AssignProp("", false, cmbWWPFormResume_Internalname, "Values", cmbWWPFormResume.ToJavascriptSource(), true);
         AssignAttri("", false, "A235WWPFormResumeMessage", A235WWPFormResumeMessage);
         AssignAttri("", false, "A233WWPFormValidations", A233WWPFormValidations);
         AssignAttri("", false, "A234WWPFormInstantiated", A234WWPFormInstantiated);
         AssignAttri("", false, "A240WWPFormType", StringUtil.LTrim( StringUtil.NToC( (decimal)(A240WWPFormType), 1, 0, ".", "")));
         cmbWWPFormType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
         AssignProp("", false, cmbWWPFormType_Internalname, "Values", cmbWWPFormType.ToJavascriptSource(), true);
         AssignAttri("", false, "A241WWPFormSectionRefElements", A241WWPFormSectionRefElements);
         AssignAttri("", false, "A242WWPFormIsForDynamicValidations", A242WWPFormIsForDynamicValidations);
         AssignAttri("", false, "A367CallToActionUrl", A367CallToActionUrl);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A499CallToActionPhoneCode","fld":"CALLTOACTIONPHONECODE"},{"av":"A500CallToActionPhoneNumber","fld":"CALLTOACTIONPHONENUMBER"},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12152","iparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]""");
         setEventMetadata("AFTER TRN",""","oparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]}""");
         setEventMetadata("VALID_CALLTOACTIONID","""{"handler":"Valid_Calltoactionid","iparms":[{"av":"A499CallToActionPhoneCode","fld":"CALLTOACTIONPHONECODE"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9"},{"av":"cmbWWPFormResume"},{"av":"A216WWPFormResume","fld":"WWPFORMRESUME","pic":"9"},{"av":"cmbCallToActionType"},{"av":"A340CallToActionType","fld":"CALLTOACTIONTYPE"},{"av":"A339CallToActionId","fld":"CALLTOACTIONID"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9"},{"av":"A500CallToActionPhoneNumber","fld":"CALLTOACTIONPHONENUMBER"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]""");
         setEventMetadata("VALID_CALLTOACTIONID",""","oparms":[{"av":"A58ProductServiceId","fld":"PRODUCTSERVICEID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A368CallToActionName","fld":"CALLTOACTIONNAME"},{"av":"cmbCallToActionType"},{"av":"A340CallToActionType","fld":"CALLTOACTIONTYPE"},{"av":"A342CallToActionPhone","fld":"CALLTOACTIONPHONE"},{"av":"A499CallToActionPhoneCode","fld":"CALLTOACTIONPHONECODE"},{"av":"A500CallToActionPhoneNumber","fld":"CALLTOACTIONPHONENUMBER"},{"av":"A341CallToActionEmail","fld":"CALLTOACTIONEMAIL"},{"av":"A366LocationDynamicFormId","fld":"LOCATIONDYNAMICFORMID"},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"A219WWPFormLatestVersionNumber","fld":"WWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME"},{"av":"A209WWPFormTitle","fld":"WWPFORMTITLE"},{"av":"A231WWPFormDate","fld":"WWPFORMDATE","pic":"99/99/99 99:99"},{"av":"cmbWWPFormResume"},{"av":"A216WWPFormResume","fld":"WWPFORMRESUME","pic":"9"},{"av":"A235WWPFormResumeMessage","fld":"WWPFORMRESUMEMESSAGE"},{"av":"A233WWPFormValidations","fld":"WWPFORMVALIDATIONS"},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9"},{"av":"A241WWPFormSectionRefElements","fld":"WWPFORMSECTIONREFELEMENTS"},{"av":"A367CallToActionUrl","fld":"CALLTOACTIONURL"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z339CallToActionId"},{"av":"Z58ProductServiceId"},{"av":"Z11OrganisationId"},{"av":"Z29LocationId"},{"av":"Z368CallToActionName"},{"av":"Z340CallToActionType"},{"av":"Z342CallToActionPhone"},{"av":"Z499CallToActionPhoneCode"},{"av":"Z500CallToActionPhoneNumber"},{"av":"Z341CallToActionEmail"},{"av":"Z366LocationDynamicFormId"},{"av":"Z206WWPFormId"},{"av":"Z207WWPFormVersionNumber"},{"av":"Z219WWPFormLatestVersionNumber"},{"av":"Z208WWPFormReferenceName"},{"av":"Z209WWPFormTitle"},{"av":"Z231WWPFormDate"},{"av":"Z232WWPFormIsWizard"},{"av":"Z216WWPFormResume"},{"av":"Z235WWPFormResumeMessage"},{"av":"Z233WWPFormValidations"},{"av":"Z234WWPFormInstantiated"},{"av":"Z240WWPFormType"},{"av":"Z241WWPFormSectionRefElements"},{"av":"Z242WWPFormIsForDynamicValidations"},{"av":"Z367CallToActionUrl"},{"ctrl":"BTNTRN_DELETE","prop":"Enabled"},{"ctrl":"BTNTRN_ENTER","prop":"Enabled"},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]}""");
         setEventMetadata("VALID_PRODUCTSERVICEID","""{"handler":"Valid_Productserviceid","iparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]""");
         setEventMetadata("VALID_PRODUCTSERVICEID",""","oparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]}""");
         setEventMetadata("VALID_ORGANISATIONID","""{"handler":"Valid_Organisationid","iparms":[{"av":"A58ProductServiceId","fld":"PRODUCTSERVICEID"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]""");
         setEventMetadata("VALID_ORGANISATIONID",""","oparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]}""");
         setEventMetadata("VALID_CALLTOACTIONTYPE","""{"handler":"Valid_Calltoactiontype","iparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]""");
         setEventMetadata("VALID_CALLTOACTIONTYPE",""","oparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]}""");
         setEventMetadata("VALID_CALLTOACTIONURL","""{"handler":"Valid_Calltoactionurl","iparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]""");
         setEventMetadata("VALID_CALLTOACTIONURL",""","oparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]}""");
         setEventMetadata("VALID_CALLTOACTIONEMAIL","""{"handler":"Valid_Calltoactionemail","iparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]""");
         setEventMetadata("VALID_CALLTOACTIONEMAIL",""","oparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]}""");
         setEventMetadata("VALID_LOCATIONDYNAMICFORMID","""{"handler":"Valid_Locationdynamicformid","iparms":[{"av":"A366LocationDynamicFormId","fld":"LOCATIONDYNAMICFORMID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"cmbCallToActionType"},{"av":"A340CallToActionType","fld":"CALLTOACTIONTYPE"},{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME"},{"av":"A367CallToActionUrl","fld":"CALLTOACTIONURL"},{"av":"A219WWPFormLatestVersionNumber","fld":"WWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"A209WWPFormTitle","fld":"WWPFORMTITLE"},{"av":"A231WWPFormDate","fld":"WWPFORMDATE","pic":"99/99/99 99:99"},{"av":"cmbWWPFormResume"},{"av":"A216WWPFormResume","fld":"WWPFORMRESUME","pic":"9"},{"av":"A235WWPFormResumeMessage","fld":"WWPFORMRESUMEMESSAGE"},{"av":"A233WWPFormValidations","fld":"WWPFORMVALIDATIONS"},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9"},{"av":"A241WWPFormSectionRefElements","fld":"WWPFORMSECTIONREFELEMENTS"},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]""");
         setEventMetadata("VALID_LOCATIONDYNAMICFORMID",""","oparms":[{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"A219WWPFormLatestVersionNumber","fld":"WWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME"},{"av":"A209WWPFormTitle","fld":"WWPFORMTITLE"},{"av":"A231WWPFormDate","fld":"WWPFORMDATE","pic":"99/99/99 99:99"},{"av":"cmbWWPFormResume"},{"av":"A216WWPFormResume","fld":"WWPFORMRESUME","pic":"9"},{"av":"A235WWPFormResumeMessage","fld":"WWPFORMRESUMEMESSAGE"},{"av":"A233WWPFormValidations","fld":"WWPFORMVALIDATIONS"},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9"},{"av":"A241WWPFormSectionRefElements","fld":"WWPFORMSECTIONREFELEMENTS"},{"av":"A367CallToActionUrl","fld":"CALLTOACTIONURL"},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]}""");
         setEventMetadata("VALID_WWPFORMID","""{"handler":"Valid_Wwpformid","iparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]""");
         setEventMetadata("VALID_WWPFORMID",""","oparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]}""");
         setEventMetadata("VALID_WWPFORMVERSIONNUMBER","""{"handler":"Valid_Wwpformversionnumber","iparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]""");
         setEventMetadata("VALID_WWPFORMVERSIONNUMBER",""","oparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]}""");
         setEventMetadata("VALID_WWPFORMREFERENCENAME","""{"handler":"Valid_Wwpformreferencename","iparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]""");
         setEventMetadata("VALID_WWPFORMREFERENCENAME",""","oparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]}""");
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
         pr_default.close(18);
         pr_default.close(15);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z339CallToActionId = Guid.Empty;
         Z367CallToActionUrl = "";
         Z368CallToActionName = "";
         Z340CallToActionType = "";
         Z342CallToActionPhone = "";
         Z499CallToActionPhoneCode = "";
         Z500CallToActionPhoneNumber = "";
         Z341CallToActionEmail = "";
         Z11OrganisationId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         Z58ProductServiceId = Guid.Empty;
         Z366LocationDynamicFormId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A340CallToActionType = "";
         A208WWPFormReferenceName = "";
         A339CallToActionId = Guid.Empty;
         A58ProductServiceId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A366LocationDynamicFormId = Guid.Empty;
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A368CallToActionName = "";
         gxphoneLink = "";
         A342CallToActionPhone = "";
         A367CallToActionUrl = "";
         A341CallToActionEmail = "";
         A209WWPFormTitle = "";
         A231WWPFormDate = (DateTime)(DateTime.MinValue);
         A235WWPFormResumeMessage = "";
         A233WWPFormValidations = "";
         A241WWPFormSectionRefElements = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A499CallToActionPhoneCode = "";
         A500CallToActionPhoneNumber = "";
         Gx_mode = "";
         AV27SDT_TrnAttributes = new SdtSDT_TrnAttributes(context);
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z208WWPFormReferenceName = "";
         Z209WWPFormTitle = "";
         Z231WWPFormDate = (DateTime)(DateTime.MinValue);
         Z235WWPFormResumeMessage = "";
         Z233WWPFormValidations = "";
         Z241WWPFormSectionRefElements = "";
         T00157_A339CallToActionId = new Guid[] {Guid.Empty} ;
         T00157_A367CallToActionUrl = new string[] {""} ;
         T00157_A368CallToActionName = new string[] {""} ;
         T00157_A340CallToActionType = new string[] {""} ;
         T00157_A342CallToActionPhone = new string[] {""} ;
         T00157_A499CallToActionPhoneCode = new string[] {""} ;
         T00157_A500CallToActionPhoneNumber = new string[] {""} ;
         T00157_A341CallToActionEmail = new string[] {""} ;
         T00157_A208WWPFormReferenceName = new string[] {""} ;
         T00157_A209WWPFormTitle = new string[] {""} ;
         T00157_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         T00157_A232WWPFormIsWizard = new bool[] {false} ;
         T00157_A216WWPFormResume = new short[1] ;
         T00157_A235WWPFormResumeMessage = new string[] {""} ;
         T00157_A233WWPFormValidations = new string[] {""} ;
         T00157_A234WWPFormInstantiated = new bool[] {false} ;
         T00157_A240WWPFormType = new short[1] ;
         T00157_A241WWPFormSectionRefElements = new string[] {""} ;
         T00157_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         T00157_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00157_A29LocationId = new Guid[] {Guid.Empty} ;
         T00157_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T00157_A366LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         T00157_n366LocationDynamicFormId = new bool[] {false} ;
         T00157_A206WWPFormId = new short[1] ;
         T00157_A207WWPFormVersionNumber = new short[1] ;
         T00154_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T00155_A206WWPFormId = new short[1] ;
         T00155_A207WWPFormVersionNumber = new short[1] ;
         T00156_A208WWPFormReferenceName = new string[] {""} ;
         T00156_A209WWPFormTitle = new string[] {""} ;
         T00156_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         T00156_A232WWPFormIsWizard = new bool[] {false} ;
         T00156_A216WWPFormResume = new short[1] ;
         T00156_A235WWPFormResumeMessage = new string[] {""} ;
         T00156_A233WWPFormValidations = new string[] {""} ;
         T00156_A234WWPFormInstantiated = new bool[] {false} ;
         T00156_A240WWPFormType = new short[1] ;
         T00156_A241WWPFormSectionRefElements = new string[] {""} ;
         T00156_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         T00158_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T00159_A206WWPFormId = new short[1] ;
         T00159_A207WWPFormVersionNumber = new short[1] ;
         T001510_A208WWPFormReferenceName = new string[] {""} ;
         T001510_A209WWPFormTitle = new string[] {""} ;
         T001510_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         T001510_A232WWPFormIsWizard = new bool[] {false} ;
         T001510_A216WWPFormResume = new short[1] ;
         T001510_A235WWPFormResumeMessage = new string[] {""} ;
         T001510_A233WWPFormValidations = new string[] {""} ;
         T001510_A234WWPFormInstantiated = new bool[] {false} ;
         T001510_A240WWPFormType = new short[1] ;
         T001510_A241WWPFormSectionRefElements = new string[] {""} ;
         T001510_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         T001511_A339CallToActionId = new Guid[] {Guid.Empty} ;
         T00153_A339CallToActionId = new Guid[] {Guid.Empty} ;
         T00153_A367CallToActionUrl = new string[] {""} ;
         T00153_A368CallToActionName = new string[] {""} ;
         T00153_A340CallToActionType = new string[] {""} ;
         T00153_A342CallToActionPhone = new string[] {""} ;
         T00153_A499CallToActionPhoneCode = new string[] {""} ;
         T00153_A500CallToActionPhoneNumber = new string[] {""} ;
         T00153_A341CallToActionEmail = new string[] {""} ;
         T00153_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00153_A29LocationId = new Guid[] {Guid.Empty} ;
         T00153_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T00153_A366LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         T00153_n366LocationDynamicFormId = new bool[] {false} ;
         sMode72 = "";
         T001512_A339CallToActionId = new Guid[] {Guid.Empty} ;
         T001513_A339CallToActionId = new Guid[] {Guid.Empty} ;
         T00152_A339CallToActionId = new Guid[] {Guid.Empty} ;
         T00152_A367CallToActionUrl = new string[] {""} ;
         T00152_A368CallToActionName = new string[] {""} ;
         T00152_A340CallToActionType = new string[] {""} ;
         T00152_A342CallToActionPhone = new string[] {""} ;
         T00152_A499CallToActionPhoneCode = new string[] {""} ;
         T00152_A500CallToActionPhoneNumber = new string[] {""} ;
         T00152_A341CallToActionEmail = new string[] {""} ;
         T00152_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00152_A29LocationId = new Guid[] {Guid.Empty} ;
         T00152_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T00152_A366LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         T00152_n366LocationDynamicFormId = new bool[] {false} ;
         T001517_A206WWPFormId = new short[1] ;
         T001517_A207WWPFormVersionNumber = new short[1] ;
         T001518_A208WWPFormReferenceName = new string[] {""} ;
         T001518_A209WWPFormTitle = new string[] {""} ;
         T001518_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         T001518_A232WWPFormIsWizard = new bool[] {false} ;
         T001518_A216WWPFormResume = new short[1] ;
         T001518_A235WWPFormResumeMessage = new string[] {""} ;
         T001518_A233WWPFormValidations = new string[] {""} ;
         T001518_A234WWPFormInstantiated = new bool[] {false} ;
         T001518_A240WWPFormType = new short[1] ;
         T001518_A241WWPFormSectionRefElements = new string[] {""} ;
         T001518_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         T001519_A339CallToActionId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXt_SdtSDT_TrnAttributes3 = new SdtSDT_TrnAttributes(context);
         ZZ339CallToActionId = Guid.Empty;
         ZZ58ProductServiceId = Guid.Empty;
         ZZ11OrganisationId = Guid.Empty;
         ZZ29LocationId = Guid.Empty;
         ZZ368CallToActionName = "";
         ZZ340CallToActionType = "";
         ZZ342CallToActionPhone = "";
         ZZ499CallToActionPhoneCode = "";
         ZZ500CallToActionPhoneNumber = "";
         ZZ341CallToActionEmail = "";
         ZZ366LocationDynamicFormId = Guid.Empty;
         ZZ208WWPFormReferenceName = "";
         ZZ209WWPFormTitle = "";
         ZZ231WWPFormDate = (DateTime)(DateTime.MinValue);
         ZZ235WWPFormResumeMessage = "";
         ZZ233WWPFormValidations = "";
         ZZ241WWPFormSectionRefElements = "";
         ZZ367CallToActionUrl = "";
         T001520_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         GXt_char2 = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_calltoaction__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_calltoaction__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_calltoaction__default(),
            new Object[][] {
                new Object[] {
               T00152_A339CallToActionId, T00152_A367CallToActionUrl, T00152_A368CallToActionName, T00152_A340CallToActionType, T00152_A342CallToActionPhone, T00152_A499CallToActionPhoneCode, T00152_A500CallToActionPhoneNumber, T00152_A341CallToActionEmail, T00152_A11OrganisationId, T00152_A29LocationId,
               T00152_A58ProductServiceId, T00152_A366LocationDynamicFormId, T00152_n366LocationDynamicFormId
               }
               , new Object[] {
               T00153_A339CallToActionId, T00153_A367CallToActionUrl, T00153_A368CallToActionName, T00153_A340CallToActionType, T00153_A342CallToActionPhone, T00153_A499CallToActionPhoneCode, T00153_A500CallToActionPhoneNumber, T00153_A341CallToActionEmail, T00153_A11OrganisationId, T00153_A29LocationId,
               T00153_A58ProductServiceId, T00153_A366LocationDynamicFormId, T00153_n366LocationDynamicFormId
               }
               , new Object[] {
               T00154_A58ProductServiceId
               }
               , new Object[] {
               T00155_A206WWPFormId, T00155_A207WWPFormVersionNumber
               }
               , new Object[] {
               T00156_A208WWPFormReferenceName, T00156_A209WWPFormTitle, T00156_A231WWPFormDate, T00156_A232WWPFormIsWizard, T00156_A216WWPFormResume, T00156_A235WWPFormResumeMessage, T00156_A233WWPFormValidations, T00156_A234WWPFormInstantiated, T00156_A240WWPFormType, T00156_A241WWPFormSectionRefElements,
               T00156_A242WWPFormIsForDynamicValidations
               }
               , new Object[] {
               T00157_A339CallToActionId, T00157_A367CallToActionUrl, T00157_A368CallToActionName, T00157_A340CallToActionType, T00157_A342CallToActionPhone, T00157_A499CallToActionPhoneCode, T00157_A500CallToActionPhoneNumber, T00157_A341CallToActionEmail, T00157_A208WWPFormReferenceName, T00157_A209WWPFormTitle,
               T00157_A231WWPFormDate, T00157_A232WWPFormIsWizard, T00157_A216WWPFormResume, T00157_A235WWPFormResumeMessage, T00157_A233WWPFormValidations, T00157_A234WWPFormInstantiated, T00157_A240WWPFormType, T00157_A241WWPFormSectionRefElements, T00157_A242WWPFormIsForDynamicValidations, T00157_A11OrganisationId,
               T00157_A29LocationId, T00157_A58ProductServiceId, T00157_A366LocationDynamicFormId, T00157_n366LocationDynamicFormId, T00157_A206WWPFormId, T00157_A207WWPFormVersionNumber
               }
               , new Object[] {
               T00158_A58ProductServiceId
               }
               , new Object[] {
               T00159_A206WWPFormId, T00159_A207WWPFormVersionNumber
               }
               , new Object[] {
               T001510_A208WWPFormReferenceName, T001510_A209WWPFormTitle, T001510_A231WWPFormDate, T001510_A232WWPFormIsWizard, T001510_A216WWPFormResume, T001510_A235WWPFormResumeMessage, T001510_A233WWPFormValidations, T001510_A234WWPFormInstantiated, T001510_A240WWPFormType, T001510_A241WWPFormSectionRefElements,
               T001510_A242WWPFormIsForDynamicValidations
               }
               , new Object[] {
               T001511_A339CallToActionId
               }
               , new Object[] {
               T001512_A339CallToActionId
               }
               , new Object[] {
               T001513_A339CallToActionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001517_A206WWPFormId, T001517_A207WWPFormVersionNumber
               }
               , new Object[] {
               T001518_A208WWPFormReferenceName, T001518_A209WWPFormTitle, T001518_A231WWPFormDate, T001518_A232WWPFormIsWizard, T001518_A216WWPFormResume, T001518_A235WWPFormResumeMessage, T001518_A233WWPFormValidations, T001518_A234WWPFormInstantiated, T001518_A240WWPFormType, T001518_A241WWPFormSectionRefElements,
               T001518_A242WWPFormIsForDynamicValidations
               }
               , new Object[] {
               T001519_A339CallToActionId
               }
               , new Object[] {
               T001520_A58ProductServiceId
               }
            }
         );
         Z339CallToActionId = Guid.NewGuid( );
         A339CallToActionId = Guid.NewGuid( );
      }

      private short GxWebError ;
      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A216WWPFormResume ;
      private short A240WWPFormType ;
      private short A219WWPFormLatestVersionNumber ;
      private short Gx_BScreen ;
      private short Z206WWPFormId ;
      private short Z207WWPFormVersionNumber ;
      private short Z216WWPFormResume ;
      private short Z240WWPFormType ;
      private short RcdFound72 ;
      private short gxajaxcallmode ;
      private short Z219WWPFormLatestVersionNumber ;
      private short ZZ206WWPFormId ;
      private short ZZ207WWPFormVersionNumber ;
      private short ZZ219WWPFormLatestVersionNumber ;
      private short ZZ216WWPFormResume ;
      private short ZZ240WWPFormType ;
      private short GXt_int1 ;
      private int trnEnded ;
      private int edtCallToActionId_Enabled ;
      private int edtProductServiceId_Enabled ;
      private int edtOrganisationId_Enabled ;
      private int edtCallToActionName_Enabled ;
      private int edtCallToActionPhone_Enabled ;
      private int edtCallToActionUrl_Enabled ;
      private int edtCallToActionEmail_Enabled ;
      private int edtLocationDynamicFormId_Enabled ;
      private int edtWWPFormId_Enabled ;
      private int edtWWPFormVersionNumber_Enabled ;
      private int edtWWPFormReferenceName_Enabled ;
      private int edtWWPFormTitle_Enabled ;
      private int edtWWPFormDate_Enabled ;
      private int edtWWPFormResumeMessage_Enabled ;
      private int edtWWPFormValidations_Enabled ;
      private int edtWWPFormLatestVersionNumber_Enabled ;
      private int edtWWPFormSectionRefElements_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string Z342CallToActionPhone ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCallToActionId_Internalname ;
      private string cmbCallToActionType_Internalname ;
      private string cmbWWPFormResume_Internalname ;
      private string cmbWWPFormType_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtCallToActionId_Jsonclick ;
      private string edtProductServiceId_Internalname ;
      private string edtProductServiceId_Jsonclick ;
      private string edtOrganisationId_Internalname ;
      private string edtOrganisationId_Jsonclick ;
      private string edtCallToActionName_Internalname ;
      private string edtCallToActionName_Jsonclick ;
      private string cmbCallToActionType_Jsonclick ;
      private string edtCallToActionPhone_Internalname ;
      private string gxphoneLink ;
      private string A342CallToActionPhone ;
      private string edtCallToActionPhone_Jsonclick ;
      private string edtCallToActionUrl_Internalname ;
      private string edtCallToActionUrl_Jsonclick ;
      private string edtCallToActionEmail_Internalname ;
      private string edtCallToActionEmail_Jsonclick ;
      private string edtLocationDynamicFormId_Internalname ;
      private string edtLocationDynamicFormId_Jsonclick ;
      private string edtWWPFormId_Internalname ;
      private string edtWWPFormId_Jsonclick ;
      private string edtWWPFormVersionNumber_Internalname ;
      private string edtWWPFormVersionNumber_Jsonclick ;
      private string edtWWPFormReferenceName_Internalname ;
      private string edtWWPFormReferenceName_Jsonclick ;
      private string edtWWPFormTitle_Internalname ;
      private string edtWWPFormTitle_Jsonclick ;
      private string edtWWPFormDate_Internalname ;
      private string edtWWPFormDate_Jsonclick ;
      private string chkWWPFormIsWizard_Internalname ;
      private string cmbWWPFormResume_Jsonclick ;
      private string edtWWPFormResumeMessage_Internalname ;
      private string edtWWPFormValidations_Internalname ;
      private string chkWWPFormInstantiated_Internalname ;
      private string edtWWPFormLatestVersionNumber_Internalname ;
      private string edtWWPFormLatestVersionNumber_Jsonclick ;
      private string cmbWWPFormType_Jsonclick ;
      private string edtWWPFormSectionRefElements_Internalname ;
      private string chkWWPFormIsForDynamicValidations_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string Gx_mode ;
      private string hsh ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode72 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ342CallToActionPhone ;
      private string GXt_char2 ;
      private DateTime A231WWPFormDate ;
      private DateTime Z231WWPFormDate ;
      private DateTime ZZ231WWPFormDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n366LocationDynamicFormId ;
      private bool wbErr ;
      private bool A232WWPFormIsWizard ;
      private bool A234WWPFormInstantiated ;
      private bool A242WWPFormIsForDynamicValidations ;
      private bool returnInSub ;
      private bool Z232WWPFormIsWizard ;
      private bool Z234WWPFormInstantiated ;
      private bool Z242WWPFormIsForDynamicValidations ;
      private bool Gx_longc ;
      private bool ZZ232WWPFormIsWizard ;
      private bool ZZ234WWPFormInstantiated ;
      private bool ZZ242WWPFormIsForDynamicValidations ;
      private string A235WWPFormResumeMessage ;
      private string A233WWPFormValidations ;
      private string Z235WWPFormResumeMessage ;
      private string Z233WWPFormValidations ;
      private string ZZ235WWPFormResumeMessage ;
      private string ZZ233WWPFormValidations ;
      private string Z367CallToActionUrl ;
      private string Z368CallToActionName ;
      private string Z340CallToActionType ;
      private string Z499CallToActionPhoneCode ;
      private string Z500CallToActionPhoneNumber ;
      private string Z341CallToActionEmail ;
      private string A340CallToActionType ;
      private string A208WWPFormReferenceName ;
      private string A368CallToActionName ;
      private string A367CallToActionUrl ;
      private string A341CallToActionEmail ;
      private string A209WWPFormTitle ;
      private string A241WWPFormSectionRefElements ;
      private string A499CallToActionPhoneCode ;
      private string A500CallToActionPhoneNumber ;
      private string Z208WWPFormReferenceName ;
      private string Z209WWPFormTitle ;
      private string Z241WWPFormSectionRefElements ;
      private string ZZ368CallToActionName ;
      private string ZZ340CallToActionType ;
      private string ZZ499CallToActionPhoneCode ;
      private string ZZ500CallToActionPhoneNumber ;
      private string ZZ341CallToActionEmail ;
      private string ZZ208WWPFormReferenceName ;
      private string ZZ209WWPFormTitle ;
      private string ZZ241WWPFormSectionRefElements ;
      private string ZZ367CallToActionUrl ;
      private Guid Z339CallToActionId ;
      private Guid Z11OrganisationId ;
      private Guid Z29LocationId ;
      private Guid Z58ProductServiceId ;
      private Guid Z366LocationDynamicFormId ;
      private Guid A339CallToActionId ;
      private Guid A58ProductServiceId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A366LocationDynamicFormId ;
      private Guid ZZ339CallToActionId ;
      private Guid ZZ58ProductServiceId ;
      private Guid ZZ11OrganisationId ;
      private Guid ZZ29LocationId ;
      private Guid ZZ366LocationDynamicFormId ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbCallToActionType ;
      private GXCheckbox chkWWPFormIsWizard ;
      private GXCombobox cmbWWPFormResume ;
      private GXCheckbox chkWWPFormInstantiated ;
      private GXCombobox cmbWWPFormType ;
      private GXCheckbox chkWWPFormIsForDynamicValidations ;
      private SdtSDT_TrnAttributes AV27SDT_TrnAttributes ;
      private IDataStoreProvider pr_default ;
      private Guid[] T00157_A339CallToActionId ;
      private string[] T00157_A367CallToActionUrl ;
      private string[] T00157_A368CallToActionName ;
      private string[] T00157_A340CallToActionType ;
      private string[] T00157_A342CallToActionPhone ;
      private string[] T00157_A499CallToActionPhoneCode ;
      private string[] T00157_A500CallToActionPhoneNumber ;
      private string[] T00157_A341CallToActionEmail ;
      private string[] T00157_A208WWPFormReferenceName ;
      private string[] T00157_A209WWPFormTitle ;
      private DateTime[] T00157_A231WWPFormDate ;
      private bool[] T00157_A232WWPFormIsWizard ;
      private short[] T00157_A216WWPFormResume ;
      private string[] T00157_A235WWPFormResumeMessage ;
      private string[] T00157_A233WWPFormValidations ;
      private bool[] T00157_A234WWPFormInstantiated ;
      private short[] T00157_A240WWPFormType ;
      private string[] T00157_A241WWPFormSectionRefElements ;
      private bool[] T00157_A242WWPFormIsForDynamicValidations ;
      private Guid[] T00157_A11OrganisationId ;
      private Guid[] T00157_A29LocationId ;
      private Guid[] T00157_A58ProductServiceId ;
      private Guid[] T00157_A366LocationDynamicFormId ;
      private bool[] T00157_n366LocationDynamicFormId ;
      private short[] T00157_A206WWPFormId ;
      private short[] T00157_A207WWPFormVersionNumber ;
      private Guid[] T00154_A58ProductServiceId ;
      private short[] T00155_A206WWPFormId ;
      private short[] T00155_A207WWPFormVersionNumber ;
      private string[] T00156_A208WWPFormReferenceName ;
      private string[] T00156_A209WWPFormTitle ;
      private DateTime[] T00156_A231WWPFormDate ;
      private bool[] T00156_A232WWPFormIsWizard ;
      private short[] T00156_A216WWPFormResume ;
      private string[] T00156_A235WWPFormResumeMessage ;
      private string[] T00156_A233WWPFormValidations ;
      private bool[] T00156_A234WWPFormInstantiated ;
      private short[] T00156_A240WWPFormType ;
      private string[] T00156_A241WWPFormSectionRefElements ;
      private bool[] T00156_A242WWPFormIsForDynamicValidations ;
      private Guid[] T00158_A58ProductServiceId ;
      private short[] T00159_A206WWPFormId ;
      private short[] T00159_A207WWPFormVersionNumber ;
      private string[] T001510_A208WWPFormReferenceName ;
      private string[] T001510_A209WWPFormTitle ;
      private DateTime[] T001510_A231WWPFormDate ;
      private bool[] T001510_A232WWPFormIsWizard ;
      private short[] T001510_A216WWPFormResume ;
      private string[] T001510_A235WWPFormResumeMessage ;
      private string[] T001510_A233WWPFormValidations ;
      private bool[] T001510_A234WWPFormInstantiated ;
      private short[] T001510_A240WWPFormType ;
      private string[] T001510_A241WWPFormSectionRefElements ;
      private bool[] T001510_A242WWPFormIsForDynamicValidations ;
      private Guid[] T001511_A339CallToActionId ;
      private Guid[] T00153_A339CallToActionId ;
      private string[] T00153_A367CallToActionUrl ;
      private string[] T00153_A368CallToActionName ;
      private string[] T00153_A340CallToActionType ;
      private string[] T00153_A342CallToActionPhone ;
      private string[] T00153_A499CallToActionPhoneCode ;
      private string[] T00153_A500CallToActionPhoneNumber ;
      private string[] T00153_A341CallToActionEmail ;
      private Guid[] T00153_A11OrganisationId ;
      private Guid[] T00153_A29LocationId ;
      private Guid[] T00153_A58ProductServiceId ;
      private Guid[] T00153_A366LocationDynamicFormId ;
      private bool[] T00153_n366LocationDynamicFormId ;
      private Guid[] T001512_A339CallToActionId ;
      private Guid[] T001513_A339CallToActionId ;
      private Guid[] T00152_A339CallToActionId ;
      private string[] T00152_A367CallToActionUrl ;
      private string[] T00152_A368CallToActionName ;
      private string[] T00152_A340CallToActionType ;
      private string[] T00152_A342CallToActionPhone ;
      private string[] T00152_A499CallToActionPhoneCode ;
      private string[] T00152_A500CallToActionPhoneNumber ;
      private string[] T00152_A341CallToActionEmail ;
      private Guid[] T00152_A11OrganisationId ;
      private Guid[] T00152_A29LocationId ;
      private Guid[] T00152_A58ProductServiceId ;
      private Guid[] T00152_A366LocationDynamicFormId ;
      private bool[] T00152_n366LocationDynamicFormId ;
      private short[] T001517_A206WWPFormId ;
      private short[] T001517_A207WWPFormVersionNumber ;
      private string[] T001518_A208WWPFormReferenceName ;
      private string[] T001518_A209WWPFormTitle ;
      private DateTime[] T001518_A231WWPFormDate ;
      private bool[] T001518_A232WWPFormIsWizard ;
      private short[] T001518_A216WWPFormResume ;
      private string[] T001518_A235WWPFormResumeMessage ;
      private string[] T001518_A233WWPFormValidations ;
      private bool[] T001518_A234WWPFormInstantiated ;
      private short[] T001518_A240WWPFormType ;
      private string[] T001518_A241WWPFormSectionRefElements ;
      private bool[] T001518_A242WWPFormIsForDynamicValidations ;
      private Guid[] T001519_A339CallToActionId ;
      private SdtSDT_TrnAttributes GXt_SdtSDT_TrnAttributes3 ;
      private Guid[] T001520_A58ProductServiceId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_calltoaction__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_calltoaction__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_calltoaction__default : DataStoreHelperBase, IDataStoreHelper
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
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT00152;
       prmT00152 = new Object[] {
       new ParDef("CallToActionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00153;
       prmT00153 = new Object[] {
       new ParDef("CallToActionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00154;
       prmT00154 = new Object[] {
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00155;
       prmT00155 = new Object[] {
       new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00156;
       prmT00156 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT00157;
       prmT00157 = new Object[] {
       new ParDef("CallToActionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00158;
       prmT00158 = new Object[] {
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00159;
       prmT00159 = new Object[] {
       new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001510;
       prmT001510 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT001511;
       prmT001511 = new Object[] {
       new ParDef("CallToActionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001512;
       prmT001512 = new Object[] {
       new ParDef("CallToActionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001513;
       prmT001513 = new Object[] {
       new ParDef("CallToActionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001514;
       prmT001514 = new Object[] {
       new ParDef("CallToActionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("CallToActionUrl",GXType.VarChar,1000,0) ,
       new ParDef("CallToActionName",GXType.VarChar,100,0) ,
       new ParDef("CallToActionType",GXType.VarChar,100,0) ,
       new ParDef("CallToActionPhone",GXType.Char,20,0) ,
       new ParDef("CallToActionPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("CallToActionPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("CallToActionEmail",GXType.VarChar,100,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT001515;
       prmT001515 = new Object[] {
       new ParDef("CallToActionUrl",GXType.VarChar,1000,0) ,
       new ParDef("CallToActionName",GXType.VarChar,100,0) ,
       new ParDef("CallToActionType",GXType.VarChar,100,0) ,
       new ParDef("CallToActionPhone",GXType.Char,20,0) ,
       new ParDef("CallToActionPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("CallToActionPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("CallToActionEmail",GXType.VarChar,100,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CallToActionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001516;
       prmT001516 = new Object[] {
       new ParDef("CallToActionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001517;
       prmT001517 = new Object[] {
       new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001518;
       prmT001518 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT001519;
       prmT001519 = new Object[] {
       };
       Object[] prmT001520;
       prmT001520 = new Object[] {
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("T00152", "SELECT CallToActionId, CallToActionUrl, CallToActionName, CallToActionType, CallToActionPhone, CallToActionPhoneCode, CallToActionPhoneNumber, CallToActionEmail, OrganisationId, LocationId, ProductServiceId, LocationDynamicFormId FROM Trn_CallToAction WHERE CallToActionId = :CallToActionId  FOR UPDATE OF Trn_CallToAction NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00152,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00153", "SELECT CallToActionId, CallToActionUrl, CallToActionName, CallToActionType, CallToActionPhone, CallToActionPhoneCode, CallToActionPhoneNumber, CallToActionEmail, OrganisationId, LocationId, ProductServiceId, LocationDynamicFormId FROM Trn_CallToAction WHERE CallToActionId = :CallToActionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00153,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00154", "SELECT ProductServiceId FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00154,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00155", "SELECT WWPFormId, WWPFormVersionNumber FROM Trn_LocationDynamicForm WHERE LocationDynamicFormId = :LocationDynamicFormId AND OrganisationId = :OrganisationId AND LocationId = :LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00155,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00156", "SELECT WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT00156,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00157", "SELECT TM1.CallToActionId, TM1.CallToActionUrl, TM1.CallToActionName, TM1.CallToActionType, TM1.CallToActionPhone, TM1.CallToActionPhoneCode, TM1.CallToActionPhoneNumber, TM1.CallToActionEmail, T3.WWPFormReferenceName, T3.WWPFormTitle, T3.WWPFormDate, T3.WWPFormIsWizard, T3.WWPFormResume, T3.WWPFormResumeMessage, T3.WWPFormValidations, T3.WWPFormInstantiated, T3.WWPFormType, T3.WWPFormSectionRefElements, T3.WWPFormIsForDynamicValidations, TM1.OrganisationId, TM1.LocationId, TM1.ProductServiceId, TM1.LocationDynamicFormId, T2.WWPFormId, T2.WWPFormVersionNumber FROM ((Trn_CallToAction TM1 LEFT JOIN Trn_LocationDynamicForm T2 ON T2.LocationDynamicFormId = TM1.LocationDynamicFormId AND T2.OrganisationId = TM1.OrganisationId AND T2.LocationId = TM1.LocationId) LEFT JOIN WWP_Form T3 ON T3.WWPFormId = T2.WWPFormId AND T3.WWPFormVersionNumber = T2.WWPFormVersionNumber) WHERE TM1.CallToActionId = :CallToActionId ORDER BY TM1.CallToActionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00157,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00158", "SELECT ProductServiceId FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00158,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00159", "SELECT WWPFormId, WWPFormVersionNumber FROM Trn_LocationDynamicForm WHERE LocationDynamicFormId = :LocationDynamicFormId AND OrganisationId = :OrganisationId AND LocationId = :LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00159,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001510", "SELECT WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT001510,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001511", "SELECT CallToActionId FROM Trn_CallToAction WHERE CallToActionId = :CallToActionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001511,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001512", "SELECT CallToActionId FROM Trn_CallToAction WHERE ( CallToActionId > :CallToActionId) ORDER BY CallToActionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001512,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001513", "SELECT CallToActionId FROM Trn_CallToAction WHERE ( CallToActionId < :CallToActionId) ORDER BY CallToActionId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001513,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001514", "SAVEPOINT gxupdate;INSERT INTO Trn_CallToAction(CallToActionId, CallToActionUrl, CallToActionName, CallToActionType, CallToActionPhone, CallToActionPhoneCode, CallToActionPhoneNumber, CallToActionEmail, OrganisationId, LocationId, ProductServiceId, LocationDynamicFormId) VALUES(:CallToActionId, :CallToActionUrl, :CallToActionName, :CallToActionType, :CallToActionPhone, :CallToActionPhoneCode, :CallToActionPhoneNumber, :CallToActionEmail, :OrganisationId, :LocationId, :ProductServiceId, :LocationDynamicFormId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001514)
          ,new CursorDef("T001515", "SAVEPOINT gxupdate;UPDATE Trn_CallToAction SET CallToActionUrl=:CallToActionUrl, CallToActionName=:CallToActionName, CallToActionType=:CallToActionType, CallToActionPhone=:CallToActionPhone, CallToActionPhoneCode=:CallToActionPhoneCode, CallToActionPhoneNumber=:CallToActionPhoneNumber, CallToActionEmail=:CallToActionEmail, OrganisationId=:OrganisationId, LocationId=:LocationId, ProductServiceId=:ProductServiceId, LocationDynamicFormId=:LocationDynamicFormId  WHERE CallToActionId = :CallToActionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001515)
          ,new CursorDef("T001516", "SAVEPOINT gxupdate;DELETE FROM Trn_CallToAction  WHERE CallToActionId = :CallToActionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001516)
          ,new CursorDef("T001517", "SELECT WWPFormId, WWPFormVersionNumber FROM Trn_LocationDynamicForm WHERE LocationDynamicFormId = :LocationDynamicFormId AND OrganisationId = :OrganisationId AND LocationId = :LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001517,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001518", "SELECT WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT001518,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001519", "SELECT CallToActionId FROM Trn_CallToAction ORDER BY CallToActionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001519,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001520", "SELECT ProductServiceId FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001520,1, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((Guid[]) buf[8])[0] = rslt.getGuid(9);
             ((Guid[]) buf[9])[0] = rslt.getGuid(10);
             ((Guid[]) buf[10])[0] = rslt.getGuid(11);
             ((Guid[]) buf[11])[0] = rslt.getGuid(12);
             ((bool[]) buf[12])[0] = rslt.wasNull(12);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((Guid[]) buf[8])[0] = rslt.getGuid(9);
             ((Guid[]) buf[9])[0] = rslt.getGuid(10);
             ((Guid[]) buf[10])[0] = rslt.getGuid(11);
             ((Guid[]) buf[11])[0] = rslt.getGuid(12);
             ((bool[]) buf[12])[0] = rslt.wasNull(12);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 4 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((bool[]) buf[7])[0] = rslt.getBool(8);
             ((short[]) buf[8])[0] = rslt.getShort(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((bool[]) buf[10])[0] = rslt.getBool(11);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(11);
             ((bool[]) buf[11])[0] = rslt.getBool(12);
             ((short[]) buf[12])[0] = rslt.getShort(13);
             ((string[]) buf[13])[0] = rslt.getLongVarchar(14);
             ((string[]) buf[14])[0] = rslt.getLongVarchar(15);
             ((bool[]) buf[15])[0] = rslt.getBool(16);
             ((short[]) buf[16])[0] = rslt.getShort(17);
             ((string[]) buf[17])[0] = rslt.getVarchar(18);
             ((bool[]) buf[18])[0] = rslt.getBool(19);
             ((Guid[]) buf[19])[0] = rslt.getGuid(20);
             ((Guid[]) buf[20])[0] = rslt.getGuid(21);
             ((Guid[]) buf[21])[0] = rslt.getGuid(22);
             ((Guid[]) buf[22])[0] = rslt.getGuid(23);
             ((bool[]) buf[23])[0] = rslt.wasNull(23);
             ((short[]) buf[24])[0] = rslt.getShort(24);
             ((short[]) buf[25])[0] = rslt.getShort(25);
             return;
          case 6 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 7 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 8 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((bool[]) buf[7])[0] = rslt.getBool(8);
             ((short[]) buf[8])[0] = rslt.getShort(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((bool[]) buf[10])[0] = rslt.getBool(11);
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
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 16 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((bool[]) buf[7])[0] = rslt.getBool(8);
             ((short[]) buf[8])[0] = rslt.getShort(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((bool[]) buf[10])[0] = rslt.getBool(11);
             return;
          case 17 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 18 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
