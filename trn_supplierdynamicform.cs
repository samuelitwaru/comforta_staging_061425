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
   public class trn_supplierdynamicform : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel3"+"_"+"WWPFORMLATESTVERSIONNUMBER") == 0 )
         {
            A206WWPFormId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX3ASAWWPFORMLATESTVERSIONNUMBER1V106( A206WWPFormId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A42SupplierGenId = StringUtil.StrToGuid( GetPar( "SupplierGenId"));
            AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A42SupplierGenId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
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
            gxLoad_7( A206WWPFormId, A207WWPFormVersionNumber) ;
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
         Form.Meta.addItem("description", context.GetMessage( "Trn_Supplier Dynamic Form", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSupplierDynamicFormId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_supplierdynamicform( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_supplierdynamicform( IGxContext context )
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
            return "trn_supplierdynamicform_Execute" ;
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
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "title-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Trn_Supplier Dynamic Form", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Trn_SupplierDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
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
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "form-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 form__toolbar-cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-first";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_SupplierDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_SupplierDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_SupplierDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_SupplierDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Trn_SupplierDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell-advanced", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierDynamicFormId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierDynamicFormId_Internalname, context.GetMessage( "Form Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierDynamicFormId_Internalname, A616SupplierDynamicFormId.ToString(), A616SupplierDynamicFormId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierDynamicFormId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierDynamicFormId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_SupplierDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenId_Internalname, context.GetMessage( "Supplier Gen Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenId_Internalname, A42SupplierGenId.ToString(), A42SupplierGenId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_SupplierDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormId_Internalname, context.GetMessage( "WWPForm Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPFormId_Enabled!=0) ? context.localUtil.Format( (decimal)(A206WWPFormId), "ZZZ9") : context.localUtil.Format( (decimal)(A206WWPFormId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPFormId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_SupplierDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormVersionNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormVersionNumber_Internalname, context.GetMessage( "WWPForm Version Number", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormVersionNumber_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPFormVersionNumber_Enabled!=0) ? context.localUtil.Format( (decimal)(A207WWPFormVersionNumber), "ZZZ9") : context.localUtil.Format( (decimal)(A207WWPFormVersionNumber), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormVersionNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPFormVersionNumber_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_SupplierDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormReferenceName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormReferenceName_Internalname, context.GetMessage( "WWPForm Reference Name", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormReferenceName_Internalname, A208WWPFormReferenceName, StringUtil.RTrim( context.localUtil.Format( A208WWPFormReferenceName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormReferenceName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPFormReferenceName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormTitle_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormTitle_Internalname, context.GetMessage( "WWPForm Title", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormTitle_Internalname, A209WWPFormTitle, StringUtil.RTrim( context.localUtil.Format( A209WWPFormTitle, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormTitle_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPFormTitle_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormDate_Internalname, context.GetMessage( "WWPForm Date", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPFormDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPFormDate_Internalname, context.localUtil.TToC( A231WWPFormDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A231WWPFormDate, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPFormDate_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_SupplierDynamicForm.htm");
         GxWebStd.gx_bitmap( context, edtWWPFormDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPFormDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_SupplierDynamicForm.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPFormIsWizard_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPFormIsWizard_Internalname, context.GetMessage( "WWPForm Is Wizard", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPFormIsWizard_Internalname, StringUtil.BoolToStr( A232WWPFormIsWizard), "", context.GetMessage( "WWPForm Is Wizard", ""), 1, chkWWPFormIsWizard.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(69, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,69);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbWWPFormResume_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbWWPFormResume_Internalname, context.GetMessage( "WWPForm Resume", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbWWPFormResume, cmbWWPFormResume_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0)), 1, cmbWWPFormResume_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbWWPFormResume.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "", true, 0, "HLP_Trn_SupplierDynamicForm.htm");
         cmbWWPFormResume.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
         AssignProp("", false, cmbWWPFormResume_Internalname, "Values", (string)(cmbWWPFormResume.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormResumeMessage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormResumeMessage_Internalname, context.GetMessage( "WWPForm Resume Message", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPFormResumeMessage_Internalname, A235WWPFormResumeMessage, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", 0, 1, edtWWPFormResumeMessage_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_SupplierDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormValidations_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormValidations_Internalname, context.GetMessage( "WWPForm Validations", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPFormValidations_Internalname, A233WWPFormValidations, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", 0, 1, edtWWPFormValidations_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_SupplierDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPFormInstantiated_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPFormInstantiated_Internalname, context.GetMessage( "WWPForm Instantiated", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPFormInstantiated_Internalname, StringUtil.BoolToStr( A234WWPFormInstantiated), "", context.GetMessage( "WWPForm Instantiated", ""), 1, chkWWPFormInstantiated.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(89, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,89);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormLatestVersionNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormLatestVersionNumber_Internalname, context.GetMessage( "WWPForm Latest Version Number", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormLatestVersionNumber_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A219WWPFormLatestVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPFormLatestVersionNumber_Enabled!=0) ? context.localUtil.Format( (decimal)(A219WWPFormLatestVersionNumber), "ZZZ9") : context.localUtil.Format( (decimal)(A219WWPFormLatestVersionNumber), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormLatestVersionNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPFormLatestVersionNumber_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_SupplierDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbWWPFormType_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbWWPFormType_Internalname, context.GetMessage( "WWPForm Type", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbWWPFormType, cmbWWPFormType_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0)), 1, cmbWWPFormType_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbWWPFormType.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "", true, 0, "HLP_Trn_SupplierDynamicForm.htm");
         cmbWWPFormType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
         AssignProp("", false, cmbWWPFormType_Internalname, "Values", (string)(cmbWWPFormType.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormSectionRefElements_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormSectionRefElements_Internalname, context.GetMessage( "WWPForm Section Ref Elements", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPFormSectionRefElements_Internalname, A241WWPFormSectionRefElements, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", 0, 1, edtWWPFormSectionRefElements_Enabled, 0, 80, "chr", 5, "row", 0, StyleString, ClassString, "", "", "400", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_SupplierDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPFormIsForDynamicValidations_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPFormIsForDynamicValidations_Internalname, context.GetMessage( "WWPForm Is For Dynamic Validations", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPFormIsForDynamicValidations_Internalname, StringUtil.BoolToStr( A242WWPFormIsForDynamicValidations), "", context.GetMessage( "WWPForm Is For Dynamic Validations", ""), 1, chkWWPFormIsForDynamicValidations.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(109, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,109);\"");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "end", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_SupplierDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_SupplierDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_SupplierDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
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
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z616SupplierDynamicFormId = StringUtil.StrToGuid( cgiGet( "Z616SupplierDynamicFormId"));
            Z42SupplierGenId = StringUtil.StrToGuid( cgiGet( "Z42SupplierGenId"));
            Z206WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z206WWPFormId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z207WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z207WWPFormVersionNumber"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( StringUtil.StrCmp(cgiGet( edtSupplierDynamicFormId_Internalname), "") == 0 )
            {
               A616SupplierDynamicFormId = Guid.Empty;
               AssignAttri("", false, "A616SupplierDynamicFormId", A616SupplierDynamicFormId.ToString());
            }
            else
            {
               try
               {
                  A616SupplierDynamicFormId = StringUtil.StrToGuid( cgiGet( edtSupplierDynamicFormId_Internalname));
                  AssignAttri("", false, "A616SupplierDynamicFormId", A616SupplierDynamicFormId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "SUPPLIERDYNAMICFORMID");
                  AnyError = 1;
                  GX_FocusControl = edtSupplierDynamicFormId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            if ( StringUtil.StrCmp(cgiGet( edtSupplierGenId_Internalname), "") == 0 )
            {
               A42SupplierGenId = Guid.Empty;
               AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
            }
            else
            {
               try
               {
                  A42SupplierGenId = StringUtil.StrToGuid( cgiGet( edtSupplierGenId_Internalname));
                  AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "SUPPLIERGENID");
                  AnyError = 1;
                  GX_FocusControl = edtSupplierGenId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPFormId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPFormId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPFORMID");
               AnyError = 1;
               GX_FocusControl = edtWWPFormId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A206WWPFormId = 0;
               AssignAttri("", false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
            }
            else
            {
               A206WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPFormVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPFormVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPFORMVERSIONNUMBER");
               AnyError = 1;
               GX_FocusControl = edtWWPFormVersionNumber_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A207WWPFormVersionNumber = 0;
               AssignAttri("", false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
            }
            else
            {
               A207WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
            }
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
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A616SupplierDynamicFormId = StringUtil.StrToGuid( GetPar( "SupplierDynamicFormId"));
               AssignAttri("", false, "A616SupplierDynamicFormId", A616SupplierDynamicFormId.ToString());
               A42SupplierGenId = StringUtil.StrToGuid( GetPar( "SupplierGenId"));
               AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
               getEqualNoModal( ) ;
               if ( IsIns( )  && (Guid.Empty==A616SupplierDynamicFormId) && ( Gx_BScreen == 0 ) )
               {
                  A616SupplierDynamicFormId = Guid.NewGuid( );
                  AssignAttri("", false, "A616SupplierDynamicFormId", A616SupplierDynamicFormId.ToString());
               }
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
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
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1V106( ) ;
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
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes1V106( ) ;
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

      protected void ResetCaption1V0( )
      {
      }

      protected void ZM1V106( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z206WWPFormId = T001V3_A206WWPFormId[0];
               Z207WWPFormVersionNumber = T001V3_A207WWPFormVersionNumber[0];
            }
            else
            {
               Z206WWPFormId = A206WWPFormId;
               Z207WWPFormVersionNumber = A207WWPFormVersionNumber;
            }
         }
         if ( GX_JID == -5 )
         {
            Z616SupplierDynamicFormId = A616SupplierDynamicFormId;
            Z42SupplierGenId = A42SupplierGenId;
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
         if ( IsIns( )  && (Guid.Empty==A616SupplierDynamicFormId) && ( Gx_BScreen == 0 ) )
         {
            A616SupplierDynamicFormId = Guid.NewGuid( );
            AssignAttri("", false, "A616SupplierDynamicFormId", A616SupplierDynamicFormId.ToString());
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1V106( )
      {
         /* Using cursor T001V6 */
         pr_default.execute(4, new Object[] {A616SupplierDynamicFormId, A42SupplierGenId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound106 = 1;
            A208WWPFormReferenceName = T001V6_A208WWPFormReferenceName[0];
            AssignAttri("", false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
            A209WWPFormTitle = T001V6_A209WWPFormTitle[0];
            AssignAttri("", false, "A209WWPFormTitle", A209WWPFormTitle);
            A231WWPFormDate = T001V6_A231WWPFormDate[0];
            AssignAttri("", false, "A231WWPFormDate", context.localUtil.TToC( A231WWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A232WWPFormIsWizard = T001V6_A232WWPFormIsWizard[0];
            AssignAttri("", false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
            A216WWPFormResume = T001V6_A216WWPFormResume[0];
            AssignAttri("", false, "A216WWPFormResume", StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
            A235WWPFormResumeMessage = T001V6_A235WWPFormResumeMessage[0];
            AssignAttri("", false, "A235WWPFormResumeMessage", A235WWPFormResumeMessage);
            A233WWPFormValidations = T001V6_A233WWPFormValidations[0];
            AssignAttri("", false, "A233WWPFormValidations", A233WWPFormValidations);
            A234WWPFormInstantiated = T001V6_A234WWPFormInstantiated[0];
            AssignAttri("", false, "A234WWPFormInstantiated", A234WWPFormInstantiated);
            A240WWPFormType = T001V6_A240WWPFormType[0];
            AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            A241WWPFormSectionRefElements = T001V6_A241WWPFormSectionRefElements[0];
            AssignAttri("", false, "A241WWPFormSectionRefElements", A241WWPFormSectionRefElements);
            A242WWPFormIsForDynamicValidations = T001V6_A242WWPFormIsForDynamicValidations[0];
            AssignAttri("", false, "A242WWPFormIsForDynamicValidations", A242WWPFormIsForDynamicValidations);
            A206WWPFormId = T001V6_A206WWPFormId[0];
            AssignAttri("", false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
            A207WWPFormVersionNumber = T001V6_A207WWPFormVersionNumber[0];
            AssignAttri("", false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
            ZM1V106( -5) ;
         }
         pr_default.close(4);
         OnLoadActions1V106( ) ;
      }

      protected void OnLoadActions1V106( )
      {
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
         AssignAttri("", false, "A219WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A219WWPFormLatestVersionNumber), 4, 0));
      }

      protected void CheckExtendedTable1V106( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T001V4 */
         pr_default.execute(2, new Object[] {A42SupplierGenId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "General Suppliers", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SUPPLIERGENID");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T001V5 */
         pr_default.execute(3, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Dynamic Form", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPFORMVERSIONNUMBER");
            AnyError = 1;
            GX_FocusControl = edtWWPFormId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A208WWPFormReferenceName = T001V5_A208WWPFormReferenceName[0];
         AssignAttri("", false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
         A209WWPFormTitle = T001V5_A209WWPFormTitle[0];
         AssignAttri("", false, "A209WWPFormTitle", A209WWPFormTitle);
         A231WWPFormDate = T001V5_A231WWPFormDate[0];
         AssignAttri("", false, "A231WWPFormDate", context.localUtil.TToC( A231WWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A232WWPFormIsWizard = T001V5_A232WWPFormIsWizard[0];
         AssignAttri("", false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
         A216WWPFormResume = T001V5_A216WWPFormResume[0];
         AssignAttri("", false, "A216WWPFormResume", StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
         A235WWPFormResumeMessage = T001V5_A235WWPFormResumeMessage[0];
         AssignAttri("", false, "A235WWPFormResumeMessage", A235WWPFormResumeMessage);
         A233WWPFormValidations = T001V5_A233WWPFormValidations[0];
         AssignAttri("", false, "A233WWPFormValidations", A233WWPFormValidations);
         A234WWPFormInstantiated = T001V5_A234WWPFormInstantiated[0];
         AssignAttri("", false, "A234WWPFormInstantiated", A234WWPFormInstantiated);
         A240WWPFormType = T001V5_A240WWPFormType[0];
         AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
         A241WWPFormSectionRefElements = T001V5_A241WWPFormSectionRefElements[0];
         AssignAttri("", false, "A241WWPFormSectionRefElements", A241WWPFormSectionRefElements);
         A242WWPFormIsForDynamicValidations = T001V5_A242WWPFormIsForDynamicValidations[0];
         AssignAttri("", false, "A242WWPFormIsForDynamicValidations", A242WWPFormIsForDynamicValidations);
         pr_default.close(3);
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
         AssignAttri("", false, "A219WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A219WWPFormLatestVersionNumber), 4, 0));
      }

      protected void CloseExtendedTableCursors1V106( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_6( Guid A42SupplierGenId )
      {
         /* Using cursor T001V7 */
         pr_default.execute(5, new Object[] {A42SupplierGenId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "General Suppliers", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SUPPLIERGENID");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_7( short A206WWPFormId ,
                               short A207WWPFormVersionNumber )
      {
         /* Using cursor T001V8 */
         pr_default.execute(6, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Dynamic Form", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPFORMVERSIONNUMBER");
            AnyError = 1;
            GX_FocusControl = edtWWPFormId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A208WWPFormReferenceName = T001V8_A208WWPFormReferenceName[0];
         AssignAttri("", false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
         A209WWPFormTitle = T001V8_A209WWPFormTitle[0];
         AssignAttri("", false, "A209WWPFormTitle", A209WWPFormTitle);
         A231WWPFormDate = T001V8_A231WWPFormDate[0];
         AssignAttri("", false, "A231WWPFormDate", context.localUtil.TToC( A231WWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A232WWPFormIsWizard = T001V8_A232WWPFormIsWizard[0];
         AssignAttri("", false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
         A216WWPFormResume = T001V8_A216WWPFormResume[0];
         AssignAttri("", false, "A216WWPFormResume", StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
         A235WWPFormResumeMessage = T001V8_A235WWPFormResumeMessage[0];
         AssignAttri("", false, "A235WWPFormResumeMessage", A235WWPFormResumeMessage);
         A233WWPFormValidations = T001V8_A233WWPFormValidations[0];
         AssignAttri("", false, "A233WWPFormValidations", A233WWPFormValidations);
         A234WWPFormInstantiated = T001V8_A234WWPFormInstantiated[0];
         AssignAttri("", false, "A234WWPFormInstantiated", A234WWPFormInstantiated);
         A240WWPFormType = T001V8_A240WWPFormType[0];
         AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
         A241WWPFormSectionRefElements = T001V8_A241WWPFormSectionRefElements[0];
         AssignAttri("", false, "A241WWPFormSectionRefElements", A241WWPFormSectionRefElements);
         A242WWPFormIsForDynamicValidations = T001V8_A242WWPFormIsForDynamicValidations[0];
         AssignAttri("", false, "A242WWPFormIsForDynamicValidations", A242WWPFormIsForDynamicValidations);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A208WWPFormReferenceName)+"\""+","+"\""+GXUtil.EncodeJSConstant( A209WWPFormTitle)+"\""+","+"\""+GXUtil.EncodeJSConstant( context.localUtil.TToC( A231WWPFormDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( A232WWPFormIsWizard))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A216WWPFormResume), 1, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A235WWPFormResumeMessage)+"\""+","+"\""+GXUtil.EncodeJSConstant( A233WWPFormValidations)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( A234WWPFormInstantiated))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A240WWPFormType), 1, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A241WWPFormSectionRefElements)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( A242WWPFormIsForDynamicValidations))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey1V106( )
      {
         /* Using cursor T001V9 */
         pr_default.execute(7, new Object[] {A616SupplierDynamicFormId, A42SupplierGenId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound106 = 1;
         }
         else
         {
            RcdFound106 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001V3 */
         pr_default.execute(1, new Object[] {A616SupplierDynamicFormId, A42SupplierGenId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1V106( 5) ;
            RcdFound106 = 1;
            A616SupplierDynamicFormId = T001V3_A616SupplierDynamicFormId[0];
            AssignAttri("", false, "A616SupplierDynamicFormId", A616SupplierDynamicFormId.ToString());
            A42SupplierGenId = T001V3_A42SupplierGenId[0];
            AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
            A206WWPFormId = T001V3_A206WWPFormId[0];
            AssignAttri("", false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
            A207WWPFormVersionNumber = T001V3_A207WWPFormVersionNumber[0];
            AssignAttri("", false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
            Z616SupplierDynamicFormId = A616SupplierDynamicFormId;
            Z42SupplierGenId = A42SupplierGenId;
            sMode106 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1V106( ) ;
            if ( AnyError == 1 )
            {
               RcdFound106 = 0;
               InitializeNonKey1V106( ) ;
            }
            Gx_mode = sMode106;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound106 = 0;
            InitializeNonKey1V106( ) ;
            sMode106 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode106;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1V106( ) ;
         if ( RcdFound106 == 0 )
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
         RcdFound106 = 0;
         /* Using cursor T001V10 */
         pr_default.execute(8, new Object[] {A616SupplierDynamicFormId, A42SupplierGenId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( GuidUtil.Compare(T001V10_A616SupplierDynamicFormId[0], A616SupplierDynamicFormId, 0) < 0 ) || ( T001V10_A616SupplierDynamicFormId[0] == A616SupplierDynamicFormId ) && ( GuidUtil.Compare(T001V10_A42SupplierGenId[0], A42SupplierGenId, 0) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( GuidUtil.Compare(T001V10_A616SupplierDynamicFormId[0], A616SupplierDynamicFormId, 0) > 0 ) || ( T001V10_A616SupplierDynamicFormId[0] == A616SupplierDynamicFormId ) && ( GuidUtil.Compare(T001V10_A42SupplierGenId[0], A42SupplierGenId, 0) > 0 ) ) )
            {
               A616SupplierDynamicFormId = T001V10_A616SupplierDynamicFormId[0];
               AssignAttri("", false, "A616SupplierDynamicFormId", A616SupplierDynamicFormId.ToString());
               A42SupplierGenId = T001V10_A42SupplierGenId[0];
               AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
               RcdFound106 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound106 = 0;
         /* Using cursor T001V11 */
         pr_default.execute(9, new Object[] {A616SupplierDynamicFormId, A42SupplierGenId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( GuidUtil.Compare(T001V11_A616SupplierDynamicFormId[0], A616SupplierDynamicFormId, 0) > 0 ) || ( T001V11_A616SupplierDynamicFormId[0] == A616SupplierDynamicFormId ) && ( GuidUtil.Compare(T001V11_A42SupplierGenId[0], A42SupplierGenId, 0) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( GuidUtil.Compare(T001V11_A616SupplierDynamicFormId[0], A616SupplierDynamicFormId, 0) < 0 ) || ( T001V11_A616SupplierDynamicFormId[0] == A616SupplierDynamicFormId ) && ( GuidUtil.Compare(T001V11_A42SupplierGenId[0], A42SupplierGenId, 0) < 0 ) ) )
            {
               A616SupplierDynamicFormId = T001V11_A616SupplierDynamicFormId[0];
               AssignAttri("", false, "A616SupplierDynamicFormId", A616SupplierDynamicFormId.ToString());
               A42SupplierGenId = T001V11_A42SupplierGenId[0];
               AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
               RcdFound106 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1V106( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSupplierDynamicFormId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1V106( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound106 == 1 )
            {
               if ( ( A616SupplierDynamicFormId != Z616SupplierDynamicFormId ) || ( A42SupplierGenId != Z42SupplierGenId ) )
               {
                  A616SupplierDynamicFormId = Z616SupplierDynamicFormId;
                  AssignAttri("", false, "A616SupplierDynamicFormId", A616SupplierDynamicFormId.ToString());
                  A42SupplierGenId = Z42SupplierGenId;
                  AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SUPPLIERDYNAMICFORMID");
                  AnyError = 1;
                  GX_FocusControl = edtSupplierDynamicFormId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSupplierDynamicFormId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1V106( ) ;
                  GX_FocusControl = edtSupplierDynamicFormId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A616SupplierDynamicFormId != Z616SupplierDynamicFormId ) || ( A42SupplierGenId != Z42SupplierGenId ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtSupplierDynamicFormId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1V106( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SUPPLIERDYNAMICFORMID");
                     AnyError = 1;
                     GX_FocusControl = edtSupplierDynamicFormId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtSupplierDynamicFormId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1V106( ) ;
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
         if ( ( A616SupplierDynamicFormId != Z616SupplierDynamicFormId ) || ( A42SupplierGenId != Z42SupplierGenId ) )
         {
            A616SupplierDynamicFormId = Z616SupplierDynamicFormId;
            AssignAttri("", false, "A616SupplierDynamicFormId", A616SupplierDynamicFormId.ToString());
            A42SupplierGenId = Z42SupplierGenId;
            AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SUPPLIERDYNAMICFORMID");
            AnyError = 1;
            GX_FocusControl = edtSupplierDynamicFormId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSupplierDynamicFormId_Internalname;
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
         if ( RcdFound106 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "SUPPLIERDYNAMICFORMID");
            AnyError = 1;
            GX_FocusControl = edtSupplierDynamicFormId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtWWPFormId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1V106( ) ;
         if ( RcdFound106 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPFormId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1V106( ) ;
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
         if ( RcdFound106 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPFormId_Internalname;
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
         if ( RcdFound106 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPFormId_Internalname;
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
         ScanStart1V106( ) ;
         if ( RcdFound106 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound106 != 0 )
            {
               ScanNext1V106( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPFormId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1V106( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1V106( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001V2 */
            pr_default.execute(0, new Object[] {A616SupplierDynamicFormId, A42SupplierGenId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_SupplierDynamicForm"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z206WWPFormId != T001V2_A206WWPFormId[0] ) || ( Z207WWPFormVersionNumber != T001V2_A207WWPFormVersionNumber[0] ) )
            {
               if ( Z206WWPFormId != T001V2_A206WWPFormId[0] )
               {
                  GXUtil.WriteLog("trn_supplierdynamicform:[seudo value changed for attri]"+"WWPFormId");
                  GXUtil.WriteLogRaw("Old: ",Z206WWPFormId);
                  GXUtil.WriteLogRaw("Current: ",T001V2_A206WWPFormId[0]);
               }
               if ( Z207WWPFormVersionNumber != T001V2_A207WWPFormVersionNumber[0] )
               {
                  GXUtil.WriteLog("trn_supplierdynamicform:[seudo value changed for attri]"+"WWPFormVersionNumber");
                  GXUtil.WriteLogRaw("Old: ",Z207WWPFormVersionNumber);
                  GXUtil.WriteLogRaw("Current: ",T001V2_A207WWPFormVersionNumber[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_SupplierDynamicForm"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1V106( )
      {
         if ( ! IsAuthorized("trn_supplierdynamicform_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1V106( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1V106( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1V106( 0) ;
            CheckOptimisticConcurrency1V106( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1V106( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1V106( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001V12 */
                     pr_default.execute(10, new Object[] {A616SupplierDynamicFormId, A42SupplierGenId, A206WWPFormId, A207WWPFormVersionNumber});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierDynamicForm");
                     if ( (pr_default.getStatus(10) == 1) )
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
                           ResetCaption1V0( ) ;
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
               Load1V106( ) ;
            }
            EndLevel1V106( ) ;
         }
         CloseExtendedTableCursors1V106( ) ;
      }

      protected void Update1V106( )
      {
         if ( ! IsAuthorized("trn_supplierdynamicform_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1V106( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1V106( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1V106( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1V106( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1V106( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001V13 */
                     pr_default.execute(11, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, A616SupplierDynamicFormId, A42SupplierGenId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierDynamicForm");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_SupplierDynamicForm"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1V106( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1V0( ) ;
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
            EndLevel1V106( ) ;
         }
         CloseExtendedTableCursors1V106( ) ;
      }

      protected void DeferredUpdate1V106( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_supplierdynamicform_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1V106( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1V106( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1V106( ) ;
            AfterConfirm1V106( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1V106( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001V14 */
                  pr_default.execute(12, new Object[] {A616SupplierDynamicFormId, A42SupplierGenId});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierDynamicForm");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound106 == 0 )
                        {
                           InitAll1V106( ) ;
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
                        ResetCaption1V0( ) ;
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
         sMode106 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1V106( ) ;
         Gx_mode = sMode106;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1V106( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_int1 = A219WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
            A219WWPFormLatestVersionNumber = GXt_int1;
            AssignAttri("", false, "A219WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A219WWPFormLatestVersionNumber), 4, 0));
            /* Using cursor T001V15 */
            pr_default.execute(13, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
            A208WWPFormReferenceName = T001V15_A208WWPFormReferenceName[0];
            AssignAttri("", false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
            A209WWPFormTitle = T001V15_A209WWPFormTitle[0];
            AssignAttri("", false, "A209WWPFormTitle", A209WWPFormTitle);
            A231WWPFormDate = T001V15_A231WWPFormDate[0];
            AssignAttri("", false, "A231WWPFormDate", context.localUtil.TToC( A231WWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A232WWPFormIsWizard = T001V15_A232WWPFormIsWizard[0];
            AssignAttri("", false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
            A216WWPFormResume = T001V15_A216WWPFormResume[0];
            AssignAttri("", false, "A216WWPFormResume", StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
            A235WWPFormResumeMessage = T001V15_A235WWPFormResumeMessage[0];
            AssignAttri("", false, "A235WWPFormResumeMessage", A235WWPFormResumeMessage);
            A233WWPFormValidations = T001V15_A233WWPFormValidations[0];
            AssignAttri("", false, "A233WWPFormValidations", A233WWPFormValidations);
            A234WWPFormInstantiated = T001V15_A234WWPFormInstantiated[0];
            AssignAttri("", false, "A234WWPFormInstantiated", A234WWPFormInstantiated);
            A240WWPFormType = T001V15_A240WWPFormType[0];
            AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            A241WWPFormSectionRefElements = T001V15_A241WWPFormSectionRefElements[0];
            AssignAttri("", false, "A241WWPFormSectionRefElements", A241WWPFormSectionRefElements);
            A242WWPFormIsForDynamicValidations = T001V15_A242WWPFormIsForDynamicValidations[0];
            AssignAttri("", false, "A242WWPFormIsForDynamicValidations", A242WWPFormIsForDynamicValidations);
            pr_default.close(13);
         }
      }

      protected void EndLevel1V106( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1V106( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_supplierdynamicform",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1V0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_supplierdynamicform",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1V106( )
      {
         /* Using cursor T001V16 */
         pr_default.execute(14);
         RcdFound106 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound106 = 1;
            A616SupplierDynamicFormId = T001V16_A616SupplierDynamicFormId[0];
            AssignAttri("", false, "A616SupplierDynamicFormId", A616SupplierDynamicFormId.ToString());
            A42SupplierGenId = T001V16_A42SupplierGenId[0];
            AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1V106( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound106 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound106 = 1;
            A616SupplierDynamicFormId = T001V16_A616SupplierDynamicFormId[0];
            AssignAttri("", false, "A616SupplierDynamicFormId", A616SupplierDynamicFormId.ToString());
            A42SupplierGenId = T001V16_A42SupplierGenId[0];
            AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
         }
      }

      protected void ScanEnd1V106( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm1V106( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1V106( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1V106( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1V106( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1V106( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1V106( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1V106( )
      {
         edtSupplierDynamicFormId_Enabled = 0;
         AssignProp("", false, edtSupplierDynamicFormId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierDynamicFormId_Enabled), 5, 0), true);
         edtSupplierGenId_Enabled = 0;
         AssignProp("", false, edtSupplierGenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenId_Enabled), 5, 0), true);
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

      protected void send_integrity_lvl_hashes1V106( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1V0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_supplierdynamicform.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z616SupplierDynamicFormId", Z616SupplierDynamicFormId.ToString());
         GxWebStd.gx_hidden_field( context, "Z42SupplierGenId", Z42SupplierGenId.ToString());
         GxWebStd.gx_hidden_field( context, "Z206WWPFormId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z206WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z207WWPFormVersionNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z207WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
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
         return formatLink("trn_supplierdynamicform.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_SupplierDynamicForm" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Supplier Dynamic Form", "") ;
      }

      protected void InitializeNonKey1V106( )
      {
         A219WWPFormLatestVersionNumber = 0;
         AssignAttri("", false, "A219WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A219WWPFormLatestVersionNumber), 4, 0));
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
         Z206WWPFormId = 0;
         Z207WWPFormVersionNumber = 0;
      }

      protected void InitAll1V106( )
      {
         A616SupplierDynamicFormId = Guid.NewGuid( );
         AssignAttri("", false, "A616SupplierDynamicFormId", A616SupplierDynamicFormId.ToString());
         A42SupplierGenId = Guid.Empty;
         AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
         InitializeNonKey1V106( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025614538739", true, true);
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
         context.AddJavascriptSource("trn_supplierdynamicform.js", "?2025614538739", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtSupplierDynamicFormId_Internalname = "SUPPLIERDYNAMICFORMID";
         edtSupplierGenId_Internalname = "SUPPLIERGENID";
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
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
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
         Form.Caption = context.GetMessage( "Trn_Supplier Dynamic Form", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
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
         edtWWPFormVersionNumber_Enabled = 1;
         edtWWPFormId_Jsonclick = "";
         edtWWPFormId_Enabled = 1;
         edtSupplierGenId_Jsonclick = "";
         edtSupplierGenId_Enabled = 1;
         edtSupplierDynamicFormId_Jsonclick = "";
         edtSupplierDynamicFormId_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
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

      protected void GX3ASAWWPFORMLATESTVERSIONNUMBER1V106( short A206WWPFormId )
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

      protected void init_web_controls( )
      {
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
         /* Using cursor T001V17 */
         pr_default.execute(15, new Object[] {A42SupplierGenId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "General Suppliers", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SUPPLIERGENID");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(15);
         GX_FocusControl = edtWWPFormId_Internalname;
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

      public void Valid_Suppliergenid( )
      {
         A240WWPFormType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormType.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbWWPFormType.CurrentValue = StringUtil.Str( (decimal)(A240WWPFormType), 1, 0);
         A216WWPFormResume = (short)(Math.Round(NumberUtil.Val( cmbWWPFormResume.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbWWPFormResume.CurrentValue = StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T001V17 */
         pr_default.execute(15, new Object[] {A42SupplierGenId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "General Suppliers", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SUPPLIERGENID");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenId_Internalname;
         }
         pr_default.close(15);
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
         AssignAttri("", false, "A219WWPFormLatestVersionNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(A219WWPFormLatestVersionNumber), 4, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z616SupplierDynamicFormId", Z616SupplierDynamicFormId.ToString());
         GxWebStd.gx_hidden_field( context, "Z42SupplierGenId", Z42SupplierGenId.ToString());
         GxWebStd.gx_hidden_field( context, "Z206WWPFormId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z206WWPFormId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z207WWPFormVersionNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z207WWPFormVersionNumber), 4, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "Z219WWPFormLatestVersionNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z219WWPFormLatestVersionNumber), 4, 0, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpformid( )
      {
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A219WWPFormLatestVersionNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(A219WWPFormLatestVersionNumber), 4, 0, ".", "")));
      }

      public void Valid_Wwpformversionnumber( )
      {
         A216WWPFormResume = (short)(Math.Round(NumberUtil.Val( cmbWWPFormResume.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbWWPFormResume.CurrentValue = StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0);
         A240WWPFormType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormType.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbWWPFormType.CurrentValue = StringUtil.Str( (decimal)(A240WWPFormType), 1, 0);
         /* Using cursor T001V15 */
         pr_default.execute(13, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Dynamic Form", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPFORMVERSIONNUMBER");
            AnyError = 1;
            GX_FocusControl = edtWWPFormId_Internalname;
         }
         A208WWPFormReferenceName = T001V15_A208WWPFormReferenceName[0];
         A209WWPFormTitle = T001V15_A209WWPFormTitle[0];
         A231WWPFormDate = T001V15_A231WWPFormDate[0];
         A232WWPFormIsWizard = T001V15_A232WWPFormIsWizard[0];
         A216WWPFormResume = T001V15_A216WWPFormResume[0];
         cmbWWPFormResume.CurrentValue = StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0);
         A235WWPFormResumeMessage = T001V15_A235WWPFormResumeMessage[0];
         A233WWPFormValidations = T001V15_A233WWPFormValidations[0];
         A234WWPFormInstantiated = T001V15_A234WWPFormInstantiated[0];
         A240WWPFormType = T001V15_A240WWPFormType[0];
         cmbWWPFormType.CurrentValue = StringUtil.Str( (decimal)(A240WWPFormType), 1, 0);
         A241WWPFormSectionRefElements = T001V15_A241WWPFormSectionRefElements[0];
         A242WWPFormIsForDynamicValidations = T001V15_A242WWPFormIsForDynamicValidations[0];
         pr_default.close(13);
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
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]}""");
         setEventMetadata("VALID_SUPPLIERDYNAMICFORMID","""{"handler":"Valid_Supplierdynamicformid","iparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]""");
         setEventMetadata("VALID_SUPPLIERDYNAMICFORMID",""","oparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]}""");
         setEventMetadata("VALID_SUPPLIERGENID","""{"handler":"Valid_Suppliergenid","iparms":[{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9"},{"av":"cmbWWPFormResume"},{"av":"A216WWPFormResume","fld":"WWPFORMRESUME","pic":"9"},{"av":"A616SupplierDynamicFormId","fld":"SUPPLIERDYNAMICFORMID"},{"av":"A42SupplierGenId","fld":"SUPPLIERGENID"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]""");
         setEventMetadata("VALID_SUPPLIERGENID",""","oparms":[{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME"},{"av":"A209WWPFormTitle","fld":"WWPFORMTITLE"},{"av":"A231WWPFormDate","fld":"WWPFORMDATE","pic":"99/99/99 99:99"},{"av":"cmbWWPFormResume"},{"av":"A216WWPFormResume","fld":"WWPFORMRESUME","pic":"9"},{"av":"A235WWPFormResumeMessage","fld":"WWPFORMRESUMEMESSAGE"},{"av":"A233WWPFormValidations","fld":"WWPFORMVALIDATIONS"},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9"},{"av":"A241WWPFormSectionRefElements","fld":"WWPFORMSECTIONREFELEMENTS"},{"av":"A219WWPFormLatestVersionNumber","fld":"WWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z616SupplierDynamicFormId"},{"av":"Z42SupplierGenId"},{"av":"Z206WWPFormId"},{"av":"Z207WWPFormVersionNumber"},{"av":"Z208WWPFormReferenceName"},{"av":"Z209WWPFormTitle"},{"av":"Z231WWPFormDate"},{"av":"Z232WWPFormIsWizard"},{"av":"Z216WWPFormResume"},{"av":"Z235WWPFormResumeMessage"},{"av":"Z233WWPFormValidations"},{"av":"Z234WWPFormInstantiated"},{"av":"Z240WWPFormType"},{"av":"Z241WWPFormSectionRefElements"},{"av":"Z242WWPFormIsForDynamicValidations"},{"av":"Z219WWPFormLatestVersionNumber"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]}""");
         setEventMetadata("VALID_WWPFORMID","""{"handler":"Valid_Wwpformid","iparms":[{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"A219WWPFormLatestVersionNumber","fld":"WWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]""");
         setEventMetadata("VALID_WWPFORMID",""","oparms":[{"av":"A219WWPFormLatestVersionNumber","fld":"WWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]}""");
         setEventMetadata("VALID_WWPFORMVERSIONNUMBER","""{"handler":"Valid_Wwpformversionnumber","iparms":[{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME"},{"av":"A209WWPFormTitle","fld":"WWPFORMTITLE"},{"av":"A231WWPFormDate","fld":"WWPFORMDATE","pic":"99/99/99 99:99"},{"av":"cmbWWPFormResume"},{"av":"A216WWPFormResume","fld":"WWPFORMRESUME","pic":"9"},{"av":"A235WWPFormResumeMessage","fld":"WWPFORMRESUMEMESSAGE"},{"av":"A233WWPFormValidations","fld":"WWPFORMVALIDATIONS"},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9"},{"av":"A241WWPFormSectionRefElements","fld":"WWPFORMSECTIONREFELEMENTS"},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]""");
         setEventMetadata("VALID_WWPFORMVERSIONNUMBER",""","oparms":[{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME"},{"av":"A209WWPFormTitle","fld":"WWPFORMTITLE"},{"av":"A231WWPFormDate","fld":"WWPFORMDATE","pic":"99/99/99 99:99"},{"av":"cmbWWPFormResume"},{"av":"A216WWPFormResume","fld":"WWPFORMRESUME","pic":"9"},{"av":"A235WWPFormResumeMessage","fld":"WWPFORMRESUMEMESSAGE"},{"av":"A233WWPFormValidations","fld":"WWPFORMVALIDATIONS"},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9"},{"av":"A241WWPFormSectionRefElements","fld":"WWPFORMSECTIONREFELEMENTS"},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]}""");
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
         pr_default.close(15);
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z616SupplierDynamicFormId = Guid.Empty;
         Z42SupplierGenId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A42SupplierGenId = Guid.Empty;
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A616SupplierDynamicFormId = Guid.Empty;
         A208WWPFormReferenceName = "";
         A209WWPFormTitle = "";
         A231WWPFormDate = (DateTime)(DateTime.MinValue);
         A235WWPFormResumeMessage = "";
         A233WWPFormValidations = "";
         A241WWPFormSectionRefElements = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
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
         T001V6_A616SupplierDynamicFormId = new Guid[] {Guid.Empty} ;
         T001V6_A208WWPFormReferenceName = new string[] {""} ;
         T001V6_A209WWPFormTitle = new string[] {""} ;
         T001V6_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         T001V6_A232WWPFormIsWizard = new bool[] {false} ;
         T001V6_A216WWPFormResume = new short[1] ;
         T001V6_A235WWPFormResumeMessage = new string[] {""} ;
         T001V6_A233WWPFormValidations = new string[] {""} ;
         T001V6_A234WWPFormInstantiated = new bool[] {false} ;
         T001V6_A240WWPFormType = new short[1] ;
         T001V6_A241WWPFormSectionRefElements = new string[] {""} ;
         T001V6_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         T001V6_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T001V6_A206WWPFormId = new short[1] ;
         T001V6_A207WWPFormVersionNumber = new short[1] ;
         T001V4_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T001V5_A208WWPFormReferenceName = new string[] {""} ;
         T001V5_A209WWPFormTitle = new string[] {""} ;
         T001V5_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         T001V5_A232WWPFormIsWizard = new bool[] {false} ;
         T001V5_A216WWPFormResume = new short[1] ;
         T001V5_A235WWPFormResumeMessage = new string[] {""} ;
         T001V5_A233WWPFormValidations = new string[] {""} ;
         T001V5_A234WWPFormInstantiated = new bool[] {false} ;
         T001V5_A240WWPFormType = new short[1] ;
         T001V5_A241WWPFormSectionRefElements = new string[] {""} ;
         T001V5_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         T001V7_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T001V8_A208WWPFormReferenceName = new string[] {""} ;
         T001V8_A209WWPFormTitle = new string[] {""} ;
         T001V8_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         T001V8_A232WWPFormIsWizard = new bool[] {false} ;
         T001V8_A216WWPFormResume = new short[1] ;
         T001V8_A235WWPFormResumeMessage = new string[] {""} ;
         T001V8_A233WWPFormValidations = new string[] {""} ;
         T001V8_A234WWPFormInstantiated = new bool[] {false} ;
         T001V8_A240WWPFormType = new short[1] ;
         T001V8_A241WWPFormSectionRefElements = new string[] {""} ;
         T001V8_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         T001V9_A616SupplierDynamicFormId = new Guid[] {Guid.Empty} ;
         T001V9_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T001V3_A616SupplierDynamicFormId = new Guid[] {Guid.Empty} ;
         T001V3_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T001V3_A206WWPFormId = new short[1] ;
         T001V3_A207WWPFormVersionNumber = new short[1] ;
         sMode106 = "";
         T001V10_A616SupplierDynamicFormId = new Guid[] {Guid.Empty} ;
         T001V10_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T001V11_A616SupplierDynamicFormId = new Guid[] {Guid.Empty} ;
         T001V11_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T001V2_A616SupplierDynamicFormId = new Guid[] {Guid.Empty} ;
         T001V2_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T001V2_A206WWPFormId = new short[1] ;
         T001V2_A207WWPFormVersionNumber = new short[1] ;
         T001V15_A208WWPFormReferenceName = new string[] {""} ;
         T001V15_A209WWPFormTitle = new string[] {""} ;
         T001V15_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         T001V15_A232WWPFormIsWizard = new bool[] {false} ;
         T001V15_A216WWPFormResume = new short[1] ;
         T001V15_A235WWPFormResumeMessage = new string[] {""} ;
         T001V15_A233WWPFormValidations = new string[] {""} ;
         T001V15_A234WWPFormInstantiated = new bool[] {false} ;
         T001V15_A240WWPFormType = new short[1] ;
         T001V15_A241WWPFormSectionRefElements = new string[] {""} ;
         T001V15_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         T001V16_A616SupplierDynamicFormId = new Guid[] {Guid.Empty} ;
         T001V16_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T001V17_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         ZZ616SupplierDynamicFormId = Guid.Empty;
         ZZ42SupplierGenId = Guid.Empty;
         ZZ208WWPFormReferenceName = "";
         ZZ209WWPFormTitle = "";
         ZZ231WWPFormDate = (DateTime)(DateTime.MinValue);
         ZZ235WWPFormResumeMessage = "";
         ZZ233WWPFormValidations = "";
         ZZ241WWPFormSectionRefElements = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_supplierdynamicform__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_supplierdynamicform__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_supplierdynamicform__default(),
            new Object[][] {
                new Object[] {
               T001V2_A616SupplierDynamicFormId, T001V2_A42SupplierGenId, T001V2_A206WWPFormId, T001V2_A207WWPFormVersionNumber
               }
               , new Object[] {
               T001V3_A616SupplierDynamicFormId, T001V3_A42SupplierGenId, T001V3_A206WWPFormId, T001V3_A207WWPFormVersionNumber
               }
               , new Object[] {
               T001V4_A42SupplierGenId
               }
               , new Object[] {
               T001V5_A208WWPFormReferenceName, T001V5_A209WWPFormTitle, T001V5_A231WWPFormDate, T001V5_A232WWPFormIsWizard, T001V5_A216WWPFormResume, T001V5_A235WWPFormResumeMessage, T001V5_A233WWPFormValidations, T001V5_A234WWPFormInstantiated, T001V5_A240WWPFormType, T001V5_A241WWPFormSectionRefElements,
               T001V5_A242WWPFormIsForDynamicValidations
               }
               , new Object[] {
               T001V6_A616SupplierDynamicFormId, T001V6_A208WWPFormReferenceName, T001V6_A209WWPFormTitle, T001V6_A231WWPFormDate, T001V6_A232WWPFormIsWizard, T001V6_A216WWPFormResume, T001V6_A235WWPFormResumeMessage, T001V6_A233WWPFormValidations, T001V6_A234WWPFormInstantiated, T001V6_A240WWPFormType,
               T001V6_A241WWPFormSectionRefElements, T001V6_A242WWPFormIsForDynamicValidations, T001V6_A42SupplierGenId, T001V6_A206WWPFormId, T001V6_A207WWPFormVersionNumber
               }
               , new Object[] {
               T001V7_A42SupplierGenId
               }
               , new Object[] {
               T001V8_A208WWPFormReferenceName, T001V8_A209WWPFormTitle, T001V8_A231WWPFormDate, T001V8_A232WWPFormIsWizard, T001V8_A216WWPFormResume, T001V8_A235WWPFormResumeMessage, T001V8_A233WWPFormValidations, T001V8_A234WWPFormInstantiated, T001V8_A240WWPFormType, T001V8_A241WWPFormSectionRefElements,
               T001V8_A242WWPFormIsForDynamicValidations
               }
               , new Object[] {
               T001V9_A616SupplierDynamicFormId, T001V9_A42SupplierGenId
               }
               , new Object[] {
               T001V10_A616SupplierDynamicFormId, T001V10_A42SupplierGenId
               }
               , new Object[] {
               T001V11_A616SupplierDynamicFormId, T001V11_A42SupplierGenId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001V15_A208WWPFormReferenceName, T001V15_A209WWPFormTitle, T001V15_A231WWPFormDate, T001V15_A232WWPFormIsWizard, T001V15_A216WWPFormResume, T001V15_A235WWPFormResumeMessage, T001V15_A233WWPFormValidations, T001V15_A234WWPFormInstantiated, T001V15_A240WWPFormType, T001V15_A241WWPFormSectionRefElements,
               T001V15_A242WWPFormIsForDynamicValidations
               }
               , new Object[] {
               T001V16_A616SupplierDynamicFormId, T001V16_A42SupplierGenId
               }
               , new Object[] {
               T001V17_A42SupplierGenId
               }
            }
         );
         Z616SupplierDynamicFormId = Guid.NewGuid( );
         A616SupplierDynamicFormId = Guid.NewGuid( );
      }

      private short Z206WWPFormId ;
      private short Z207WWPFormVersionNumber ;
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
      private short Z216WWPFormResume ;
      private short Z240WWPFormType ;
      private short RcdFound106 ;
      private short gxajaxcallmode ;
      private short Z219WWPFormLatestVersionNumber ;
      private short ZZ206WWPFormId ;
      private short ZZ207WWPFormVersionNumber ;
      private short ZZ216WWPFormResume ;
      private short ZZ240WWPFormType ;
      private short ZZ219WWPFormLatestVersionNumber ;
      private short GXt_int1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtSupplierDynamicFormId_Enabled ;
      private int edtSupplierGenId_Enabled ;
      private int edtWWPFormId_Enabled ;
      private int edtWWPFormVersionNumber_Enabled ;
      private int edtWWPFormReferenceName_Enabled ;
      private int edtWWPFormTitle_Enabled ;
      private int edtWWPFormDate_Enabled ;
      private int edtWWPFormResumeMessage_Enabled ;
      private int edtWWPFormValidations_Enabled ;
      private int edtWWPFormLatestVersionNumber_Enabled ;
      private int edtWWPFormSectionRefElements_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSupplierDynamicFormId_Internalname ;
      private string cmbWWPFormResume_Internalname ;
      private string cmbWWPFormType_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtSupplierDynamicFormId_Jsonclick ;
      private string edtSupplierGenId_Internalname ;
      private string edtSupplierGenId_Jsonclick ;
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
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode106 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime A231WWPFormDate ;
      private DateTime Z231WWPFormDate ;
      private DateTime ZZ231WWPFormDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A232WWPFormIsWizard ;
      private bool A234WWPFormInstantiated ;
      private bool A242WWPFormIsForDynamicValidations ;
      private bool Z232WWPFormIsWizard ;
      private bool Z234WWPFormInstantiated ;
      private bool Z242WWPFormIsForDynamicValidations ;
      private bool ZZ232WWPFormIsWizard ;
      private bool ZZ234WWPFormInstantiated ;
      private bool ZZ242WWPFormIsForDynamicValidations ;
      private string A235WWPFormResumeMessage ;
      private string A233WWPFormValidations ;
      private string Z235WWPFormResumeMessage ;
      private string Z233WWPFormValidations ;
      private string ZZ235WWPFormResumeMessage ;
      private string ZZ233WWPFormValidations ;
      private string A208WWPFormReferenceName ;
      private string A209WWPFormTitle ;
      private string A241WWPFormSectionRefElements ;
      private string Z208WWPFormReferenceName ;
      private string Z209WWPFormTitle ;
      private string Z241WWPFormSectionRefElements ;
      private string ZZ208WWPFormReferenceName ;
      private string ZZ209WWPFormTitle ;
      private string ZZ241WWPFormSectionRefElements ;
      private Guid Z616SupplierDynamicFormId ;
      private Guid Z42SupplierGenId ;
      private Guid A42SupplierGenId ;
      private Guid A616SupplierDynamicFormId ;
      private Guid ZZ616SupplierDynamicFormId ;
      private Guid ZZ42SupplierGenId ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkWWPFormIsWizard ;
      private GXCombobox cmbWWPFormResume ;
      private GXCheckbox chkWWPFormInstantiated ;
      private GXCombobox cmbWWPFormType ;
      private GXCheckbox chkWWPFormIsForDynamicValidations ;
      private IDataStoreProvider pr_default ;
      private Guid[] T001V6_A616SupplierDynamicFormId ;
      private string[] T001V6_A208WWPFormReferenceName ;
      private string[] T001V6_A209WWPFormTitle ;
      private DateTime[] T001V6_A231WWPFormDate ;
      private bool[] T001V6_A232WWPFormIsWizard ;
      private short[] T001V6_A216WWPFormResume ;
      private string[] T001V6_A235WWPFormResumeMessage ;
      private string[] T001V6_A233WWPFormValidations ;
      private bool[] T001V6_A234WWPFormInstantiated ;
      private short[] T001V6_A240WWPFormType ;
      private string[] T001V6_A241WWPFormSectionRefElements ;
      private bool[] T001V6_A242WWPFormIsForDynamicValidations ;
      private Guid[] T001V6_A42SupplierGenId ;
      private short[] T001V6_A206WWPFormId ;
      private short[] T001V6_A207WWPFormVersionNumber ;
      private Guid[] T001V4_A42SupplierGenId ;
      private string[] T001V5_A208WWPFormReferenceName ;
      private string[] T001V5_A209WWPFormTitle ;
      private DateTime[] T001V5_A231WWPFormDate ;
      private bool[] T001V5_A232WWPFormIsWizard ;
      private short[] T001V5_A216WWPFormResume ;
      private string[] T001V5_A235WWPFormResumeMessage ;
      private string[] T001V5_A233WWPFormValidations ;
      private bool[] T001V5_A234WWPFormInstantiated ;
      private short[] T001V5_A240WWPFormType ;
      private string[] T001V5_A241WWPFormSectionRefElements ;
      private bool[] T001V5_A242WWPFormIsForDynamicValidations ;
      private Guid[] T001V7_A42SupplierGenId ;
      private string[] T001V8_A208WWPFormReferenceName ;
      private string[] T001V8_A209WWPFormTitle ;
      private DateTime[] T001V8_A231WWPFormDate ;
      private bool[] T001V8_A232WWPFormIsWizard ;
      private short[] T001V8_A216WWPFormResume ;
      private string[] T001V8_A235WWPFormResumeMessage ;
      private string[] T001V8_A233WWPFormValidations ;
      private bool[] T001V8_A234WWPFormInstantiated ;
      private short[] T001V8_A240WWPFormType ;
      private string[] T001V8_A241WWPFormSectionRefElements ;
      private bool[] T001V8_A242WWPFormIsForDynamicValidations ;
      private Guid[] T001V9_A616SupplierDynamicFormId ;
      private Guid[] T001V9_A42SupplierGenId ;
      private Guid[] T001V3_A616SupplierDynamicFormId ;
      private Guid[] T001V3_A42SupplierGenId ;
      private short[] T001V3_A206WWPFormId ;
      private short[] T001V3_A207WWPFormVersionNumber ;
      private Guid[] T001V10_A616SupplierDynamicFormId ;
      private Guid[] T001V10_A42SupplierGenId ;
      private Guid[] T001V11_A616SupplierDynamicFormId ;
      private Guid[] T001V11_A42SupplierGenId ;
      private Guid[] T001V2_A616SupplierDynamicFormId ;
      private Guid[] T001V2_A42SupplierGenId ;
      private short[] T001V2_A206WWPFormId ;
      private short[] T001V2_A207WWPFormVersionNumber ;
      private string[] T001V15_A208WWPFormReferenceName ;
      private string[] T001V15_A209WWPFormTitle ;
      private DateTime[] T001V15_A231WWPFormDate ;
      private bool[] T001V15_A232WWPFormIsWizard ;
      private short[] T001V15_A216WWPFormResume ;
      private string[] T001V15_A235WWPFormResumeMessage ;
      private string[] T001V15_A233WWPFormValidations ;
      private bool[] T001V15_A234WWPFormInstantiated ;
      private short[] T001V15_A240WWPFormType ;
      private string[] T001V15_A241WWPFormSectionRefElements ;
      private bool[] T001V15_A242WWPFormIsForDynamicValidations ;
      private Guid[] T001V16_A616SupplierDynamicFormId ;
      private Guid[] T001V16_A42SupplierGenId ;
      private Guid[] T001V17_A42SupplierGenId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_supplierdynamicform__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_supplierdynamicform__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_supplierdynamicform__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[10])
      ,new UpdateCursor(def[11])
      ,new UpdateCursor(def[12])
      ,new ForEachCursor(def[13])
      ,new ForEachCursor(def[14])
      ,new ForEachCursor(def[15])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT001V2;
       prmT001V2 = new Object[] {
       new ParDef("SupplierDynamicFormId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001V3;
       prmT001V3 = new Object[] {
       new ParDef("SupplierDynamicFormId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001V4;
       prmT001V4 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001V5;
       prmT001V5 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT001V6;
       prmT001V6 = new Object[] {
       new ParDef("SupplierDynamicFormId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001V7;
       prmT001V7 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001V8;
       prmT001V8 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT001V9;
       prmT001V9 = new Object[] {
       new ParDef("SupplierDynamicFormId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001V10;
       prmT001V10 = new Object[] {
       new ParDef("SupplierDynamicFormId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001V11;
       prmT001V11 = new Object[] {
       new ParDef("SupplierDynamicFormId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001V12;
       prmT001V12 = new Object[] {
       new ParDef("SupplierDynamicFormId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT001V13;
       prmT001V13 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("SupplierDynamicFormId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001V14;
       prmT001V14 = new Object[] {
       new ParDef("SupplierDynamicFormId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001V15;
       prmT001V15 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT001V16;
       prmT001V16 = new Object[] {
       };
       Object[] prmT001V17;
       prmT001V17 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("T001V2", "SELECT SupplierDynamicFormId, SupplierGenId, WWPFormId, WWPFormVersionNumber FROM Trn_SupplierDynamicForm WHERE SupplierDynamicFormId = :SupplierDynamicFormId AND SupplierGenId = :SupplierGenId  FOR UPDATE OF Trn_SupplierDynamicForm NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001V2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001V3", "SELECT SupplierDynamicFormId, SupplierGenId, WWPFormId, WWPFormVersionNumber FROM Trn_SupplierDynamicForm WHERE SupplierDynamicFormId = :SupplierDynamicFormId AND SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001V4", "SELECT SupplierGenId FROM Trn_SupplierGen WHERE SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001V5", "SELECT WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001V6", "SELECT TM1.SupplierDynamicFormId, T2.WWPFormReferenceName, T2.WWPFormTitle, T2.WWPFormDate, T2.WWPFormIsWizard, T2.WWPFormResume, T2.WWPFormResumeMessage, T2.WWPFormValidations, T2.WWPFormInstantiated, T2.WWPFormType, T2.WWPFormSectionRefElements, T2.WWPFormIsForDynamicValidations, TM1.SupplierGenId, TM1.WWPFormId, TM1.WWPFormVersionNumber FROM (Trn_SupplierDynamicForm TM1 INNER JOIN WWP_Form T2 ON T2.WWPFormId = TM1.WWPFormId AND T2.WWPFormVersionNumber = TM1.WWPFormVersionNumber) WHERE TM1.SupplierDynamicFormId = :SupplierDynamicFormId and TM1.SupplierGenId = :SupplierGenId ORDER BY TM1.SupplierDynamicFormId, TM1.SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V6,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001V7", "SELECT SupplierGenId FROM Trn_SupplierGen WHERE SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001V8", "SELECT WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V8,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001V9", "SELECT SupplierDynamicFormId, SupplierGenId FROM Trn_SupplierDynamicForm WHERE SupplierDynamicFormId = :SupplierDynamicFormId AND SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V9,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001V10", "SELECT SupplierDynamicFormId, SupplierGenId FROM Trn_SupplierDynamicForm WHERE ( SupplierDynamicFormId > :SupplierDynamicFormId or SupplierDynamicFormId = :SupplierDynamicFormId and SupplierGenId > :SupplierGenId) ORDER BY SupplierDynamicFormId, SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V10,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001V11", "SELECT SupplierDynamicFormId, SupplierGenId FROM Trn_SupplierDynamicForm WHERE ( SupplierDynamicFormId < :SupplierDynamicFormId or SupplierDynamicFormId = :SupplierDynamicFormId and SupplierGenId < :SupplierGenId) ORDER BY SupplierDynamicFormId DESC, SupplierGenId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V11,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001V12", "SAVEPOINT gxupdate;INSERT INTO Trn_SupplierDynamicForm(SupplierDynamicFormId, SupplierGenId, WWPFormId, WWPFormVersionNumber) VALUES(:SupplierDynamicFormId, :SupplierGenId, :WWPFormId, :WWPFormVersionNumber);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001V12)
          ,new CursorDef("T001V13", "SAVEPOINT gxupdate;UPDATE Trn_SupplierDynamicForm SET WWPFormId=:WWPFormId, WWPFormVersionNumber=:WWPFormVersionNumber  WHERE SupplierDynamicFormId = :SupplierDynamicFormId AND SupplierGenId = :SupplierGenId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001V13)
          ,new CursorDef("T001V14", "SAVEPOINT gxupdate;DELETE FROM Trn_SupplierDynamicForm  WHERE SupplierDynamicFormId = :SupplierDynamicFormId AND SupplierGenId = :SupplierGenId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001V14)
          ,new CursorDef("T001V15", "SELECT WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V15,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001V16", "SELECT SupplierDynamicFormId, SupplierGenId FROM Trn_SupplierDynamicForm ORDER BY SupplierDynamicFormId, SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V16,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001V17", "SELECT SupplierGenId FROM Trn_SupplierGen WHERE SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V17,1, GxCacheFrequency.OFF ,true,false )
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
             ((short[]) buf[2])[0] = rslt.getShort(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
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
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((bool[]) buf[4])[0] = rslt.getBool(5);
             ((short[]) buf[5])[0] = rslt.getShort(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((short[]) buf[9])[0] = rslt.getShort(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((bool[]) buf[11])[0] = rslt.getBool(12);
             ((Guid[]) buf[12])[0] = rslt.getGuid(13);
             ((short[]) buf[13])[0] = rslt.getShort(14);
             ((short[]) buf[14])[0] = rslt.getShort(15);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 6 :
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
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 9 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 13 :
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
          case 14 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 15 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
