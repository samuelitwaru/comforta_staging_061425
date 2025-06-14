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
   public class trn_suppliergen : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel26"+"_"+"SUPPLIERGENCONTACTPHONE") == 0 )
         {
            A353SupplierGenPhoneCode = GetPar( "SupplierGenPhoneCode");
            AssignAttri("", false, "A353SupplierGenPhoneCode", A353SupplierGenPhoneCode);
            A354SupplierGenPhoneNumber = GetPar( "SupplierGenPhoneNumber");
            AssignAttri("", false, "A354SupplierGenPhoneNumber", A354SupplierGenPhoneNumber);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX26ASASUPPLIERGENCONTACTPHONE069( A353SupplierGenPhoneCode, A354SupplierGenPhoneNumber) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel27"+"_"+"SUPPLIERGENLANDLINENUMBER") == 0 )
         {
            A605SupplierGenLandlineCode = GetPar( "SupplierGenLandlineCode");
            AssignAttri("", false, "A605SupplierGenLandlineCode", A605SupplierGenLandlineCode);
            A606SupplierGenLandlineSubNumber = GetPar( "SupplierGenLandlineSubNumber");
            AssignAttri("", false, "A606SupplierGenLandlineSubNumber", A606SupplierGenLandlineSubNumber);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX27ASASUPPLIERGENLANDLINENUMBER069( A605SupplierGenLandlineCode, A606SupplierGenLandlineSubNumber) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_46") == 0 )
         {
            A253SupplierGenTypeId = StringUtil.StrToGuid( GetPar( "SupplierGenTypeId"));
            AssignAttri("", false, "A253SupplierGenTypeId", A253SupplierGenTypeId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_46( A253SupplierGenTypeId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_47") == 0 )
         {
            A601SG_OrganisationSupplierId = StringUtil.StrToGuid( GetPar( "SG_OrganisationSupplierId"));
            n601SG_OrganisationSupplierId = false;
            AssignAttri("", false, "A601SG_OrganisationSupplierId", A601SG_OrganisationSupplierId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_47( A601SG_OrganisationSupplierId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_48") == 0 )
         {
            A603SG_LocationSupplierLocationId = StringUtil.StrToGuid( GetPar( "SG_LocationSupplierLocationId"));
            n603SG_LocationSupplierLocationId = false;
            AssignAttri("", false, "A603SG_LocationSupplierLocationId", A603SG_LocationSupplierLocationId.ToString());
            A602SG_LocationSupplierOrganisatio = StringUtil.StrToGuid( GetPar( "SG_LocationSupplierOrganisatio"));
            n602SG_LocationSupplierOrganisatio = false;
            AssignAttri("", false, "A602SG_LocationSupplierOrganisatio", A602SG_LocationSupplierOrganisatio.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_48( A603SG_LocationSupplierLocationId, A602SG_LocationSupplierOrganisatio) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_suppliergen.aspx")), "trn_suppliergen.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_suppliergen.aspx")))) ;
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
                  AV7SupplierGenId = StringUtil.StrToGuid( GetPar( "SupplierGenId"));
                  AssignAttri("", false, "AV7SupplierGenId", AV7SupplierGenId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vSUPPLIERGENID", GetSecureSignedToken( "", AV7SupplierGenId, context));
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
         Form.Meta.addItem("description", context.GetMessage( "Suppliers", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSupplierGenKvkNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_suppliergen( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_suppliergen( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_SupplierGenId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7SupplierGenId = aP1_SupplierGenId;
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
            return "trn_suppliergen_Execute" ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
         /* Control Group */
         GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, context.GetMessage( "Supplier Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_SupplierGen.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenKvkNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenKvkNumber_Internalname, context.GetMessage( "KvK Number", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenKvkNumber_Internalname, A43SupplierGenKvkNumber, StringUtil.RTrim( context.localUtil.Format( A43SupplierGenKvkNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "12345678", edtSupplierGenKvkNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenKvkNumber_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, true, "KvkNumber", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenCompanyName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenCompanyName_Internalname, context.GetMessage( "Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenCompanyName_Internalname, A44SupplierGenCompanyName, StringUtil.RTrim( context.localUtil.Format( A44SupplierGenCompanyName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "Name", ""), edtSupplierGenCompanyName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenCompanyName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedsuppliergentypeid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocksuppliergentypeid_Internalname, context.GetMessage( "Category", ""), "", "", lblTextblocksuppliergentypeid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_suppliergentypeid.SetProperty("Caption", Combo_suppliergentypeid_Caption);
         ucCombo_suppliergentypeid.SetProperty("Cls", Combo_suppliergentypeid_Cls);
         ucCombo_suppliergentypeid.SetProperty("EmptyItem", Combo_suppliergentypeid_Emptyitem);
         ucCombo_suppliergentypeid.SetProperty("IncludeAddNewOption", Combo_suppliergentypeid_Includeaddnewoption);
         ucCombo_suppliergentypeid.SetProperty("DropDownOptionsData", AV15SupplierGenTypeId_Data);
         ucCombo_suppliergentypeid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_suppliergentypeid_Internalname, "COMBO_SUPPLIERGENTYPEIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenTypeId_Internalname, context.GetMessage( "Category", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenTypeId_Internalname, A253SupplierGenTypeId.ToString(), A253SupplierGenTypeId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenTypeId_Jsonclick, 0, "Attribute", "", "", "", "", edtSupplierGenTypeId_Visible, edtSupplierGenTypeId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenContactName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenContactName_Internalname, context.GetMessage( "Contact Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenContactName_Internalname, A47SupplierGenContactName, StringUtil.RTrim( context.localUtil.Format( A47SupplierGenContactName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "Contact Name", ""), edtSupplierGenContactName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenContactName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable5_Internalname, divUnnamedtable5_Visible, 0, "px", 0, "px", "CellMarginBottom10", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblPhonelabel_Internalname, context.GetMessage( "Phone", ""), "", "", lblPhonelabel_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable10_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable11_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 PhoneLabel ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablesuppliergenphonecode_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_suppliergenphonecode.SetProperty("Caption", Combo_suppliergenphonecode_Caption);
         ucCombo_suppliergenphonecode.SetProperty("Cls", Combo_suppliergenphonecode_Cls);
         ucCombo_suppliergenphonecode.SetProperty("EmptyItem", Combo_suppliergenphonecode_Emptyitem);
         ucCombo_suppliergenphonecode.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_suppliergenphonecode.SetProperty("DropDownOptionsData", AV27SupplierGenPhoneCode_Data);
         ucCombo_suppliergenphonecode.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_suppliergenphonecode_Internalname, "COMBO_SUPPLIERGENPHONECODEContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenPhoneCode_Internalname, context.GetMessage( "Supplier Gen Phone Code", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenPhoneCode_Internalname, A353SupplierGenPhoneCode, StringUtil.RTrim( context.localUtil.Format( A353SupplierGenPhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenPhoneCode_Jsonclick, 0, "Attribute", "", "", "", "", edtSupplierGenPhoneCode_Visible, edtSupplierGenPhoneCode_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenPhoneNumber_Internalname, context.GetMessage( "Supplier Gen Phone Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenPhoneNumber_Internalname, A354SupplierGenPhoneNumber, StringUtil.RTrim( context.localUtil.Format( A354SupplierGenPhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "229123456", edtSupplierGenPhoneNumber_Jsonclick, 0, edtSupplierGenPhoneNumber_Class, "", "", "", "", 1, edtSupplierGenPhoneNumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGen.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable6_Internalname, divUnnamedtable6_Visible, 0, "px", 0, "px", "CellMarginBottom10", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblPhonelabellandline_Internalname, context.GetMessage( "Landline", ""), "", "", lblPhonelabellandline_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable8_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable9_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 PhoneLabel ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablesuppliergenlandlinecode_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_suppliergenlandlinecode.SetProperty("Caption", Combo_suppliergenlandlinecode_Caption);
         ucCombo_suppliergenlandlinecode.SetProperty("Cls", Combo_suppliergenlandlinecode_Cls);
         ucCombo_suppliergenlandlinecode.SetProperty("EmptyItem", Combo_suppliergenlandlinecode_Emptyitem);
         ucCombo_suppliergenlandlinecode.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_suppliergenlandlinecode.SetProperty("DropDownOptionsData", AV41SupplierGenLandlineCode_Data);
         ucCombo_suppliergenlandlinecode.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_suppliergenlandlinecode_Internalname, "COMBO_SUPPLIERGENLANDLINECODEContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenLandlineCode_Internalname, context.GetMessage( "Supplier Gen Landline Code", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenLandlineCode_Internalname, A605SupplierGenLandlineCode, StringUtil.RTrim( context.localUtil.Format( A605SupplierGenLandlineCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenLandlineCode_Jsonclick, 0, "Attribute", "", "", "", "", edtSupplierGenLandlineCode_Visible, edtSupplierGenLandlineCode_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenLandlineSubNumber_Internalname, context.GetMessage( "Supplier Gen Landline Sub Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenLandlineSubNumber_Internalname, A606SupplierGenLandlineSubNumber, StringUtil.RTrim( context.localUtil.Format( A606SupplierGenLandlineSubNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "229123456", edtSupplierGenLandlineSubNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenLandlineSubNumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGen.htm");
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
         GxWebStd.gx_div_start( context, divSuppliergencontactphone_cell_Internalname, 1, 0, "px", 0, "px", divSuppliergencontactphone_cell_Class, "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", edtSupplierGenContactPhone_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenContactPhone_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenContactPhone_Internalname, context.GetMessage( "Contact Phone", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A48SupplierGenContactPhone);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenContactPhone_Internalname, StringUtil.RTrim( A48SupplierGenContactPhone), StringUtil.RTrim( context.localUtil.Format( A48SupplierGenContactPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtSupplierGenContactPhone_Jsonclick, 0, "Attribute", "", "", "", "", edtSupplierGenContactPhone_Visible, edtSupplierGenContactPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSuppliergenlandlinenumber_cell_Internalname, 1, 0, "px", 0, "px", divSuppliergenlandlinenumber_cell_Class, "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", edtSupplierGenLandlineNumber_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenLandlineNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenLandlineNumber_Internalname, context.GetMessage( "Landline", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenLandlineNumber_Internalname, A607SupplierGenLandlineNumber, StringUtil.RTrim( context.localUtil.Format( A607SupplierGenLandlineNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenLandlineNumber_Jsonclick, 0, "Attribute", "", "", "", "", edtSupplierGenLandlineNumber_Visible, edtSupplierGenLandlineNumber_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenEmail_Internalname, context.GetMessage( "Email", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenEmail_Internalname, A501SupplierGenEmail, StringUtil.RTrim( context.localUtil.Format( A501SupplierGenEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,108);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A501SupplierGenEmail, "", "", "", edtSupplierGenEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenWebsite_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenWebsite_Internalname, context.GetMessage( "Website", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenWebsite_Internalname, A428SupplierGenWebsite, StringUtil.RTrim( context.localUtil.Format( A428SupplierGenWebsite, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,113);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "www.website.com", ""), edtSupplierGenWebsite_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenWebsite_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSuppliergendescription_cell_Internalname, 1, 0, "px", 0, "px", divSuppliergendescription_cell_Class, "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+Suppliergendescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, Suppliergendescription_Internalname, context.GetMessage( "Description", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* User Defined Control */
         ucSuppliergendescription.SetProperty("Width", Suppliergendescription_Width);
         ucSuppliergendescription.SetProperty("Height", Suppliergendescription_Height);
         ucSuppliergendescription.SetProperty("Attribute", SupplierGenDescription);
         ucSuppliergendescription.SetProperty("Skin", Suppliergendescription_Skin);
         ucSuppliergendescription.SetProperty("Toolbar", Suppliergendescription_Toolbar);
         ucSuppliergendescription.SetProperty("CustomToolbar", Suppliergendescription_Customtoolbar);
         ucSuppliergendescription.SetProperty("CustomConfiguration", Suppliergendescription_Customconfiguration);
         ucSuppliergendescription.SetProperty("ToolbarCanCollapse", Suppliergendescription_Toolbarcancollapse);
         ucSuppliergendescription.SetProperty("CaptionClass", Suppliergendescription_Captionclass);
         ucSuppliergendescription.SetProperty("CaptionStyle", Suppliergendescription_Captionstyle);
         ucSuppliergendescription.SetProperty("CaptionPosition", Suppliergendescription_Captionposition);
         ucSuppliergendescription.Render(context, "fckeditor", Suppliergendescription_Internalname, "SUPPLIERGENDESCRIPTIONContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divDescriptiontable_Internalname, divDescriptiontable_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockdescriptionlabel_Internalname, context.GetMessage( "Description", ""), "", "", lblTextblockdescriptionlabel_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable7_Internalname, 1, 0, "px", 0, "px", "HTMLTextOverfow", "start", "top", " "+"data-gx-flex"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblDescriptiontext_Internalname, "", "", "", lblDescriptiontext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DynamicFormHTMLEditor", 0, "", 1, 1, 0, 1, "HLP_Trn_SupplierGen.htm");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
         /* Control Group */
         GxWebStd.gx_group_start( context, grpUnnamedgroup4_Internalname, context.GetMessage( "Address Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_SupplierGen.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenAddressLine1_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenAddressLine1_Internalname, context.GetMessage( "Address Line 1", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenAddressLine1_Internalname, A310SupplierGenAddressLine1, StringUtil.RTrim( context.localUtil.Format( A310SupplierGenAddressLine1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,136);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "Address Line 1", ""), edtSupplierGenAddressLine1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenAddressLine1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenAddressLine2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenAddressLine2_Internalname, context.GetMessage( "Address Line 2", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 141,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenAddressLine2_Internalname, A311SupplierGenAddressLine2, StringUtil.RTrim( context.localUtil.Format( A311SupplierGenAddressLine2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,141);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "Address Line 2", ""), edtSupplierGenAddressLine2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenAddressLine2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenAddressZipCode_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenAddressZipCode_Internalname, context.GetMessage( "Zipcode", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenAddressZipCode_Internalname, A259SupplierGenAddressZipCode, StringUtil.RTrim( context.localUtil.Format( A259SupplierGenAddressZipCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,146);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "1234 AB", ""), edtSupplierGenAddressZipCode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenAddressZipCode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenAddressCity_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenAddressCity_Internalname, context.GetMessage( "City", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenAddressCity_Internalname, A260SupplierGenAddressCity, StringUtil.RTrim( context.localUtil.Format( A260SupplierGenAddressCity, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,151);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "City", ""), edtSupplierGenAddressCity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenAddressCity_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedsuppliergenaddresscountry_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocksuppliergenaddresscountry_Internalname, context.GetMessage( " Country", ""), "", "", lblTextblocksuppliergenaddresscountry_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_suppliergenaddresscountry.SetProperty("Caption", Combo_suppliergenaddresscountry_Caption);
         ucCombo_suppliergenaddresscountry.SetProperty("Cls", Combo_suppliergenaddresscountry_Cls);
         ucCombo_suppliergenaddresscountry.SetProperty("EmptyItem", Combo_suppliergenaddresscountry_Emptyitem);
         ucCombo_suppliergenaddresscountry.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_suppliergenaddresscountry.SetProperty("DropDownOptionsData", AV23SupplierGenAddressCountry_Data);
         ucCombo_suppliergenaddresscountry.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_suppliergenaddresscountry_Internalname, "COMBO_SUPPLIERGENADDRESSCOUNTRYContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenAddressCountry_Internalname, context.GetMessage( "Supplier Gen Address Country", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 162,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenAddressCountry_Internalname, A309SupplierGenAddressCountry, StringUtil.RTrim( context.localUtil.Format( A309SupplierGenAddressCountry, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,162);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenAddressCountry_Jsonclick, 0, "Attribute", "", "", "", "", edtSupplierGenAddressCountry_Visible, edtSupplierGenAddressCountry_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGen.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 167,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 169,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 171,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_SupplierGen.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_suppliergentypeid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 176,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombosuppliergentypeid_Internalname, AV20ComboSupplierGenTypeId.ToString(), AV20ComboSupplierGenTypeId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,176);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombosuppliergentypeid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombosuppliergentypeid_Visible, edtavCombosuppliergentypeid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_suppliergenphonecode_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 178,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombosuppliergenphonecode_Internalname, AV25ComboSupplierGenPhoneCode, StringUtil.RTrim( context.localUtil.Format( AV25ComboSupplierGenPhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,178);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombosuppliergenphonecode_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombosuppliergenphonecode_Visible, edtavCombosuppliergenphonecode_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_suppliergenlandlinecode_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 180,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombosuppliergenlandlinecode_Internalname, AV42ComboSupplierGenLandlineCode, StringUtil.RTrim( context.localUtil.Format( AV42ComboSupplierGenLandlineCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,180);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombosuppliergenlandlinecode_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombosuppliergenlandlinecode_Visible, edtavCombosuppliergenlandlinecode_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_suppliergenaddresscountry_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 182,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombosuppliergenaddresscountry_Internalname, AV24ComboSupplierGenAddressCountry, StringUtil.RTrim( context.localUtil.Format( AV24ComboSupplierGenAddressCountry, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,182);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombosuppliergenaddresscountry_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombosuppliergenaddresscountry_Visible, edtavCombosuppliergenaddresscountry_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 183,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenId_Internalname, A42SupplierGenId.ToString(), A42SupplierGenId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,183);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenId_Jsonclick, 0, "Attribute", "", "", "", "", edtSupplierGenId_Visible, edtSupplierGenId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_SupplierGen.htm");
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
         E11062 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vSUPPLIERGENTYPEID_DATA"), AV15SupplierGenTypeId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV16DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vSUPPLIERGENPHONECODE_DATA"), AV27SupplierGenPhoneCode_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vSUPPLIERGENLANDLINECODE_DATA"), AV41SupplierGenLandlineCode_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vSUPPLIERGENADDRESSCOUNTRY_DATA"), AV23SupplierGenAddressCountry_Data);
               /* Read saved values. */
               Z42SupplierGenId = StringUtil.StrToGuid( cgiGet( "Z42SupplierGenId"));
               Z309SupplierGenAddressCountry = cgiGet( "Z309SupplierGenAddressCountry");
               Z605SupplierGenLandlineCode = cgiGet( "Z605SupplierGenLandlineCode");
               Z353SupplierGenPhoneCode = cgiGet( "Z353SupplierGenPhoneCode");
               Z48SupplierGenContactPhone = cgiGet( "Z48SupplierGenContactPhone");
               Z607SupplierGenLandlineNumber = cgiGet( "Z607SupplierGenLandlineNumber");
               Z259SupplierGenAddressZipCode = cgiGet( "Z259SupplierGenAddressZipCode");
               Z43SupplierGenKvkNumber = cgiGet( "Z43SupplierGenKvkNumber");
               Z44SupplierGenCompanyName = cgiGet( "Z44SupplierGenCompanyName");
               Z260SupplierGenAddressCity = cgiGet( "Z260SupplierGenAddressCity");
               Z310SupplierGenAddressLine1 = cgiGet( "Z310SupplierGenAddressLine1");
               Z311SupplierGenAddressLine2 = cgiGet( "Z311SupplierGenAddressLine2");
               Z47SupplierGenContactName = cgiGet( "Z47SupplierGenContactName");
               Z354SupplierGenPhoneNumber = cgiGet( "Z354SupplierGenPhoneNumber");
               Z606SupplierGenLandlineSubNumber = cgiGet( "Z606SupplierGenLandlineSubNumber");
               Z501SupplierGenEmail = cgiGet( "Z501SupplierGenEmail");
               Z428SupplierGenWebsite = cgiGet( "Z428SupplierGenWebsite");
               Z253SupplierGenTypeId = StringUtil.StrToGuid( cgiGet( "Z253SupplierGenTypeId"));
               Z601SG_OrganisationSupplierId = StringUtil.StrToGuid( cgiGet( "Z601SG_OrganisationSupplierId"));
               n601SG_OrganisationSupplierId = ((Guid.Empty==A601SG_OrganisationSupplierId) ? true : false);
               Z602SG_LocationSupplierOrganisatio = StringUtil.StrToGuid( cgiGet( "Z602SG_LocationSupplierOrganisatio"));
               n602SG_LocationSupplierOrganisatio = ((Guid.Empty==A602SG_LocationSupplierOrganisatio) ? true : false);
               Z603SG_LocationSupplierLocationId = StringUtil.StrToGuid( cgiGet( "Z603SG_LocationSupplierLocationId"));
               n603SG_LocationSupplierLocationId = ((Guid.Empty==A603SG_LocationSupplierLocationId) ? true : false);
               A601SG_OrganisationSupplierId = StringUtil.StrToGuid( cgiGet( "Z601SG_OrganisationSupplierId"));
               n601SG_OrganisationSupplierId = false;
               n601SG_OrganisationSupplierId = ((Guid.Empty==A601SG_OrganisationSupplierId) ? true : false);
               A602SG_LocationSupplierOrganisatio = StringUtil.StrToGuid( cgiGet( "Z602SG_LocationSupplierOrganisatio"));
               n602SG_LocationSupplierOrganisatio = false;
               n602SG_LocationSupplierOrganisatio = ((Guid.Empty==A602SG_LocationSupplierOrganisatio) ? true : false);
               A603SG_LocationSupplierLocationId = StringUtil.StrToGuid( cgiGet( "Z603SG_LocationSupplierLocationId"));
               n603SG_LocationSupplierLocationId = false;
               n603SG_LocationSupplierLocationId = ((Guid.Empty==A603SG_LocationSupplierLocationId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N253SupplierGenTypeId = StringUtil.StrToGuid( cgiGet( "N253SupplierGenTypeId"));
               N601SG_OrganisationSupplierId = StringUtil.StrToGuid( cgiGet( "N601SG_OrganisationSupplierId"));
               n601SG_OrganisationSupplierId = ((Guid.Empty==A601SG_OrganisationSupplierId) ? true : false);
               N602SG_LocationSupplierOrganisatio = StringUtil.StrToGuid( cgiGet( "N602SG_LocationSupplierOrganisatio"));
               n602SG_LocationSupplierOrganisatio = ((Guid.Empty==A602SG_LocationSupplierOrganisatio) ? true : false);
               N603SG_LocationSupplierLocationId = StringUtil.StrToGuid( cgiGet( "N603SG_LocationSupplierLocationId"));
               n603SG_LocationSupplierLocationId = ((Guid.Empty==A603SG_LocationSupplierLocationId) ? true : false);
               AV7SupplierGenId = StringUtil.StrToGuid( cgiGet( "vSUPPLIERGENID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV13Insert_SupplierGenTypeId = StringUtil.StrToGuid( cgiGet( "vINSERT_SUPPLIERGENTYPEID"));
               AV34Insert_SG_OrganisationSupplierId = StringUtil.StrToGuid( cgiGet( "vINSERT_SG_ORGANISATIONSUPPLIERID"));
               AV40SG_OrganisationSupplierId = StringUtil.StrToGuid( cgiGet( "vSG_ORGANISATIONSUPPLIERID"));
               A601SG_OrganisationSupplierId = StringUtil.StrToGuid( cgiGet( "SG_ORGANISATIONSUPPLIERID"));
               n601SG_OrganisationSupplierId = ((Guid.Empty==A601SG_OrganisationSupplierId) ? true : false);
               AV35Insert_SG_LocationSupplierOrganisationId = StringUtil.StrToGuid( cgiGet( "vINSERT_SG_LOCATIONSUPPLIERORGANISATIONID"));
               AV38SG_LocationSupplierOrganisationId = StringUtil.StrToGuid( cgiGet( "vSG_LOCATIONSUPPLIERORGANISATIONID"));
               A602SG_LocationSupplierOrganisatio = StringUtil.StrToGuid( cgiGet( "SG_LOCATIONSUPPLIERORGANISATIO"));
               n602SG_LocationSupplierOrganisatio = ((Guid.Empty==A602SG_LocationSupplierOrganisatio) ? true : false);
               AV36Insert_SG_LocationSupplierLocationId = StringUtil.StrToGuid( cgiGet( "vINSERT_SG_LOCATIONSUPPLIERLOCATIONID"));
               AV39SG_LocationSupplierLocationId = StringUtil.StrToGuid( cgiGet( "vSG_LOCATIONSUPPLIERLOCATIONID"));
               A603SG_LocationSupplierLocationId = StringUtil.StrToGuid( cgiGet( "SG_LOCATIONSUPPLIERLOCATIONID"));
               n603SG_LocationSupplierLocationId = ((Guid.Empty==A603SG_LocationSupplierLocationId) ? true : false);
               A604SupplierGenDescription = cgiGet( "SUPPLIERGENDESCRIPTION");
               A254SupplierGenTypeName = cgiGet( "SUPPLIERGENTYPENAME");
               AV43Pgmname = cgiGet( "vPGMNAME");
               Combo_suppliergentypeid_Objectcall = cgiGet( "COMBO_SUPPLIERGENTYPEID_Objectcall");
               Combo_suppliergentypeid_Class = cgiGet( "COMBO_SUPPLIERGENTYPEID_Class");
               Combo_suppliergentypeid_Icontype = cgiGet( "COMBO_SUPPLIERGENTYPEID_Icontype");
               Combo_suppliergentypeid_Icon = cgiGet( "COMBO_SUPPLIERGENTYPEID_Icon");
               Combo_suppliergentypeid_Caption = cgiGet( "COMBO_SUPPLIERGENTYPEID_Caption");
               Combo_suppliergentypeid_Tooltip = cgiGet( "COMBO_SUPPLIERGENTYPEID_Tooltip");
               Combo_suppliergentypeid_Cls = cgiGet( "COMBO_SUPPLIERGENTYPEID_Cls");
               Combo_suppliergentypeid_Selectedvalue_set = cgiGet( "COMBO_SUPPLIERGENTYPEID_Selectedvalue_set");
               Combo_suppliergentypeid_Selectedvalue_get = cgiGet( "COMBO_SUPPLIERGENTYPEID_Selectedvalue_get");
               Combo_suppliergentypeid_Selectedtext_set = cgiGet( "COMBO_SUPPLIERGENTYPEID_Selectedtext_set");
               Combo_suppliergentypeid_Selectedtext_get = cgiGet( "COMBO_SUPPLIERGENTYPEID_Selectedtext_get");
               Combo_suppliergentypeid_Gamoauthtoken = cgiGet( "COMBO_SUPPLIERGENTYPEID_Gamoauthtoken");
               Combo_suppliergentypeid_Ddointernalname = cgiGet( "COMBO_SUPPLIERGENTYPEID_Ddointernalname");
               Combo_suppliergentypeid_Titlecontrolalign = cgiGet( "COMBO_SUPPLIERGENTYPEID_Titlecontrolalign");
               Combo_suppliergentypeid_Dropdownoptionstype = cgiGet( "COMBO_SUPPLIERGENTYPEID_Dropdownoptionstype");
               Combo_suppliergentypeid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENTYPEID_Enabled"));
               Combo_suppliergentypeid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENTYPEID_Visible"));
               Combo_suppliergentypeid_Titlecontrolidtoreplace = cgiGet( "COMBO_SUPPLIERGENTYPEID_Titlecontrolidtoreplace");
               Combo_suppliergentypeid_Datalisttype = cgiGet( "COMBO_SUPPLIERGENTYPEID_Datalisttype");
               Combo_suppliergentypeid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENTYPEID_Allowmultipleselection"));
               Combo_suppliergentypeid_Datalistfixedvalues = cgiGet( "COMBO_SUPPLIERGENTYPEID_Datalistfixedvalues");
               Combo_suppliergentypeid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENTYPEID_Isgriditem"));
               Combo_suppliergentypeid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENTYPEID_Hasdescription"));
               Combo_suppliergentypeid_Datalistproc = cgiGet( "COMBO_SUPPLIERGENTYPEID_Datalistproc");
               Combo_suppliergentypeid_Datalistprocparametersprefix = cgiGet( "COMBO_SUPPLIERGENTYPEID_Datalistprocparametersprefix");
               Combo_suppliergentypeid_Remoteservicesparameters = cgiGet( "COMBO_SUPPLIERGENTYPEID_Remoteservicesparameters");
               Combo_suppliergentypeid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERGENTYPEID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_suppliergentypeid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENTYPEID_Includeonlyselectedoption"));
               Combo_suppliergentypeid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENTYPEID_Includeselectalloption"));
               Combo_suppliergentypeid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENTYPEID_Emptyitem"));
               Combo_suppliergentypeid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENTYPEID_Includeaddnewoption"));
               Combo_suppliergentypeid_Htmltemplate = cgiGet( "COMBO_SUPPLIERGENTYPEID_Htmltemplate");
               Combo_suppliergentypeid_Multiplevaluestype = cgiGet( "COMBO_SUPPLIERGENTYPEID_Multiplevaluestype");
               Combo_suppliergentypeid_Loadingdata = cgiGet( "COMBO_SUPPLIERGENTYPEID_Loadingdata");
               Combo_suppliergentypeid_Noresultsfound = cgiGet( "COMBO_SUPPLIERGENTYPEID_Noresultsfound");
               Combo_suppliergentypeid_Emptyitemtext = cgiGet( "COMBO_SUPPLIERGENTYPEID_Emptyitemtext");
               Combo_suppliergentypeid_Onlyselectedvalues = cgiGet( "COMBO_SUPPLIERGENTYPEID_Onlyselectedvalues");
               Combo_suppliergentypeid_Selectalltext = cgiGet( "COMBO_SUPPLIERGENTYPEID_Selectalltext");
               Combo_suppliergentypeid_Multiplevaluesseparator = cgiGet( "COMBO_SUPPLIERGENTYPEID_Multiplevaluesseparator");
               Combo_suppliergentypeid_Addnewoptiontext = cgiGet( "COMBO_SUPPLIERGENTYPEID_Addnewoptiontext");
               Combo_suppliergentypeid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERGENTYPEID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_suppliergenphonecode_Objectcall = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Objectcall");
               Combo_suppliergenphonecode_Class = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Class");
               Combo_suppliergenphonecode_Icontype = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Icontype");
               Combo_suppliergenphonecode_Icon = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Icon");
               Combo_suppliergenphonecode_Caption = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Caption");
               Combo_suppliergenphonecode_Tooltip = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Tooltip");
               Combo_suppliergenphonecode_Cls = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Cls");
               Combo_suppliergenphonecode_Selectedvalue_set = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Selectedvalue_set");
               Combo_suppliergenphonecode_Selectedvalue_get = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Selectedvalue_get");
               Combo_suppliergenphonecode_Selectedtext_set = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Selectedtext_set");
               Combo_suppliergenphonecode_Selectedtext_get = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Selectedtext_get");
               Combo_suppliergenphonecode_Gamoauthtoken = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Gamoauthtoken");
               Combo_suppliergenphonecode_Ddointernalname = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Ddointernalname");
               Combo_suppliergenphonecode_Titlecontrolalign = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Titlecontrolalign");
               Combo_suppliergenphonecode_Dropdownoptionstype = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Dropdownoptionstype");
               Combo_suppliergenphonecode_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENPHONECODE_Enabled"));
               Combo_suppliergenphonecode_Visible = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENPHONECODE_Visible"));
               Combo_suppliergenphonecode_Titlecontrolidtoreplace = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Titlecontrolidtoreplace");
               Combo_suppliergenphonecode_Datalisttype = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Datalisttype");
               Combo_suppliergenphonecode_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENPHONECODE_Allowmultipleselection"));
               Combo_suppliergenphonecode_Datalistfixedvalues = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Datalistfixedvalues");
               Combo_suppliergenphonecode_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENPHONECODE_Isgriditem"));
               Combo_suppliergenphonecode_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENPHONECODE_Hasdescription"));
               Combo_suppliergenphonecode_Datalistproc = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Datalistproc");
               Combo_suppliergenphonecode_Datalistprocparametersprefix = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Datalistprocparametersprefix");
               Combo_suppliergenphonecode_Remoteservicesparameters = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Remoteservicesparameters");
               Combo_suppliergenphonecode_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERGENPHONECODE_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_suppliergenphonecode_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENPHONECODE_Includeonlyselectedoption"));
               Combo_suppliergenphonecode_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENPHONECODE_Includeselectalloption"));
               Combo_suppliergenphonecode_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENPHONECODE_Emptyitem"));
               Combo_suppliergenphonecode_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENPHONECODE_Includeaddnewoption"));
               Combo_suppliergenphonecode_Htmltemplate = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Htmltemplate");
               Combo_suppliergenphonecode_Multiplevaluestype = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Multiplevaluestype");
               Combo_suppliergenphonecode_Loadingdata = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Loadingdata");
               Combo_suppliergenphonecode_Noresultsfound = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Noresultsfound");
               Combo_suppliergenphonecode_Emptyitemtext = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Emptyitemtext");
               Combo_suppliergenphonecode_Onlyselectedvalues = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Onlyselectedvalues");
               Combo_suppliergenphonecode_Selectalltext = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Selectalltext");
               Combo_suppliergenphonecode_Multiplevaluesseparator = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Multiplevaluesseparator");
               Combo_suppliergenphonecode_Addnewoptiontext = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Addnewoptiontext");
               Combo_suppliergenphonecode_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERGENPHONECODE_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_suppliergenlandlinecode_Objectcall = cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Objectcall");
               Combo_suppliergenlandlinecode_Class = cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Class");
               Combo_suppliergenlandlinecode_Icontype = cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Icontype");
               Combo_suppliergenlandlinecode_Icon = cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Icon");
               Combo_suppliergenlandlinecode_Caption = cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Caption");
               Combo_suppliergenlandlinecode_Tooltip = cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Tooltip");
               Combo_suppliergenlandlinecode_Cls = cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Cls");
               Combo_suppliergenlandlinecode_Selectedvalue_set = cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Selectedvalue_set");
               Combo_suppliergenlandlinecode_Selectedvalue_get = cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Selectedvalue_get");
               Combo_suppliergenlandlinecode_Selectedtext_set = cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Selectedtext_set");
               Combo_suppliergenlandlinecode_Selectedtext_get = cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Selectedtext_get");
               Combo_suppliergenlandlinecode_Gamoauthtoken = cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Gamoauthtoken");
               Combo_suppliergenlandlinecode_Ddointernalname = cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Ddointernalname");
               Combo_suppliergenlandlinecode_Titlecontrolalign = cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Titlecontrolalign");
               Combo_suppliergenlandlinecode_Dropdownoptionstype = cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Dropdownoptionstype");
               Combo_suppliergenlandlinecode_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Enabled"));
               Combo_suppliergenlandlinecode_Visible = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Visible"));
               Combo_suppliergenlandlinecode_Titlecontrolidtoreplace = cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Titlecontrolidtoreplace");
               Combo_suppliergenlandlinecode_Datalisttype = cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Datalisttype");
               Combo_suppliergenlandlinecode_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Allowmultipleselection"));
               Combo_suppliergenlandlinecode_Datalistfixedvalues = cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Datalistfixedvalues");
               Combo_suppliergenlandlinecode_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Isgriditem"));
               Combo_suppliergenlandlinecode_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Hasdescription"));
               Combo_suppliergenlandlinecode_Datalistproc = cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Datalistproc");
               Combo_suppliergenlandlinecode_Datalistprocparametersprefix = cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Datalistprocparametersprefix");
               Combo_suppliergenlandlinecode_Remoteservicesparameters = cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Remoteservicesparameters");
               Combo_suppliergenlandlinecode_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_suppliergenlandlinecode_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Includeonlyselectedoption"));
               Combo_suppliergenlandlinecode_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Includeselectalloption"));
               Combo_suppliergenlandlinecode_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Emptyitem"));
               Combo_suppliergenlandlinecode_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Includeaddnewoption"));
               Combo_suppliergenlandlinecode_Htmltemplate = cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Htmltemplate");
               Combo_suppliergenlandlinecode_Multiplevaluestype = cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Multiplevaluestype");
               Combo_suppliergenlandlinecode_Loadingdata = cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Loadingdata");
               Combo_suppliergenlandlinecode_Noresultsfound = cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Noresultsfound");
               Combo_suppliergenlandlinecode_Emptyitemtext = cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Emptyitemtext");
               Combo_suppliergenlandlinecode_Onlyselectedvalues = cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Onlyselectedvalues");
               Combo_suppliergenlandlinecode_Selectalltext = cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Selectalltext");
               Combo_suppliergenlandlinecode_Multiplevaluesseparator = cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Multiplevaluesseparator");
               Combo_suppliergenlandlinecode_Addnewoptiontext = cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Addnewoptiontext");
               Combo_suppliergenlandlinecode_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERGENLANDLINECODE_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Suppliergendescription_Objectcall = cgiGet( "SUPPLIERGENDESCRIPTION_Objectcall");
               Suppliergendescription_Class = cgiGet( "SUPPLIERGENDESCRIPTION_Class");
               Suppliergendescription_Enabled = StringUtil.StrToBool( cgiGet( "SUPPLIERGENDESCRIPTION_Enabled"));
               Suppliergendescription_Width = cgiGet( "SUPPLIERGENDESCRIPTION_Width");
               Suppliergendescription_Height = cgiGet( "SUPPLIERGENDESCRIPTION_Height");
               Suppliergendescription_Skin = cgiGet( "SUPPLIERGENDESCRIPTION_Skin");
               Suppliergendescription_Toolbar = cgiGet( "SUPPLIERGENDESCRIPTION_Toolbar");
               Suppliergendescription_Customtoolbar = cgiGet( "SUPPLIERGENDESCRIPTION_Customtoolbar");
               Suppliergendescription_Customconfiguration = cgiGet( "SUPPLIERGENDESCRIPTION_Customconfiguration");
               Suppliergendescription_Toolbarcancollapse = StringUtil.StrToBool( cgiGet( "SUPPLIERGENDESCRIPTION_Toolbarcancollapse"));
               Suppliergendescription_Toolbarexpanded = StringUtil.StrToBool( cgiGet( "SUPPLIERGENDESCRIPTION_Toolbarexpanded"));
               Suppliergendescription_Color = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPPLIERGENDESCRIPTION_Color"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Suppliergendescription_Buttonpressedid = cgiGet( "SUPPLIERGENDESCRIPTION_Buttonpressedid");
               Suppliergendescription_Captionvalue = cgiGet( "SUPPLIERGENDESCRIPTION_Captionvalue");
               Suppliergendescription_Captionclass = cgiGet( "SUPPLIERGENDESCRIPTION_Captionclass");
               Suppliergendescription_Captionstyle = cgiGet( "SUPPLIERGENDESCRIPTION_Captionstyle");
               Suppliergendescription_Captionposition = cgiGet( "SUPPLIERGENDESCRIPTION_Captionposition");
               Suppliergendescription_Isabstractlayoutcontrol = StringUtil.StrToBool( cgiGet( "SUPPLIERGENDESCRIPTION_Isabstractlayoutcontrol"));
               Suppliergendescription_Coltitle = cgiGet( "SUPPLIERGENDESCRIPTION_Coltitle");
               Suppliergendescription_Coltitlefont = cgiGet( "SUPPLIERGENDESCRIPTION_Coltitlefont");
               Suppliergendescription_Coltitlecolor = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPPLIERGENDESCRIPTION_Coltitlecolor"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Suppliergendescription_Usercontroliscolumn = StringUtil.StrToBool( cgiGet( "SUPPLIERGENDESCRIPTION_Usercontroliscolumn"));
               Suppliergendescription_Visible = StringUtil.StrToBool( cgiGet( "SUPPLIERGENDESCRIPTION_Visible"));
               Combo_suppliergenaddresscountry_Objectcall = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Objectcall");
               Combo_suppliergenaddresscountry_Class = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Class");
               Combo_suppliergenaddresscountry_Icontype = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Icontype");
               Combo_suppliergenaddresscountry_Icon = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Icon");
               Combo_suppliergenaddresscountry_Caption = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Caption");
               Combo_suppliergenaddresscountry_Tooltip = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Tooltip");
               Combo_suppliergenaddresscountry_Cls = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Cls");
               Combo_suppliergenaddresscountry_Selectedvalue_set = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Selectedvalue_set");
               Combo_suppliergenaddresscountry_Selectedvalue_get = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Selectedvalue_get");
               Combo_suppliergenaddresscountry_Selectedtext_set = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Selectedtext_set");
               Combo_suppliergenaddresscountry_Selectedtext_get = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Selectedtext_get");
               Combo_suppliergenaddresscountry_Gamoauthtoken = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Gamoauthtoken");
               Combo_suppliergenaddresscountry_Ddointernalname = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Ddointernalname");
               Combo_suppliergenaddresscountry_Titlecontrolalign = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Titlecontrolalign");
               Combo_suppliergenaddresscountry_Dropdownoptionstype = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Dropdownoptionstype");
               Combo_suppliergenaddresscountry_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Enabled"));
               Combo_suppliergenaddresscountry_Visible = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Visible"));
               Combo_suppliergenaddresscountry_Titlecontrolidtoreplace = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Titlecontrolidtoreplace");
               Combo_suppliergenaddresscountry_Datalisttype = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Datalisttype");
               Combo_suppliergenaddresscountry_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Allowmultipleselection"));
               Combo_suppliergenaddresscountry_Datalistfixedvalues = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Datalistfixedvalues");
               Combo_suppliergenaddresscountry_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Isgriditem"));
               Combo_suppliergenaddresscountry_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Hasdescription"));
               Combo_suppliergenaddresscountry_Datalistproc = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Datalistproc");
               Combo_suppliergenaddresscountry_Datalistprocparametersprefix = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Datalistprocparametersprefix");
               Combo_suppliergenaddresscountry_Remoteservicesparameters = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Remoteservicesparameters");
               Combo_suppliergenaddresscountry_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_suppliergenaddresscountry_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Includeonlyselectedoption"));
               Combo_suppliergenaddresscountry_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Includeselectalloption"));
               Combo_suppliergenaddresscountry_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Emptyitem"));
               Combo_suppliergenaddresscountry_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Includeaddnewoption"));
               Combo_suppliergenaddresscountry_Htmltemplate = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Htmltemplate");
               Combo_suppliergenaddresscountry_Multiplevaluestype = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Multiplevaluestype");
               Combo_suppliergenaddresscountry_Loadingdata = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Loadingdata");
               Combo_suppliergenaddresscountry_Noresultsfound = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Noresultsfound");
               Combo_suppliergenaddresscountry_Emptyitemtext = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Emptyitemtext");
               Combo_suppliergenaddresscountry_Onlyselectedvalues = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Onlyselectedvalues");
               Combo_suppliergenaddresscountry_Selectalltext = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Selectalltext");
               Combo_suppliergenaddresscountry_Multiplevaluesseparator = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Multiplevaluesseparator");
               Combo_suppliergenaddresscountry_Addnewoptiontext = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Addnewoptiontext");
               Combo_suppliergenaddresscountry_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A43SupplierGenKvkNumber = cgiGet( edtSupplierGenKvkNumber_Internalname);
               AssignAttri("", false, "A43SupplierGenKvkNumber", A43SupplierGenKvkNumber);
               A44SupplierGenCompanyName = cgiGet( edtSupplierGenCompanyName_Internalname);
               AssignAttri("", false, "A44SupplierGenCompanyName", A44SupplierGenCompanyName);
               if ( StringUtil.StrCmp(cgiGet( edtSupplierGenTypeId_Internalname), "") == 0 )
               {
                  A253SupplierGenTypeId = Guid.Empty;
                  AssignAttri("", false, "A253SupplierGenTypeId", A253SupplierGenTypeId.ToString());
               }
               else
               {
                  try
                  {
                     A253SupplierGenTypeId = StringUtil.StrToGuid( cgiGet( edtSupplierGenTypeId_Internalname));
                     AssignAttri("", false, "A253SupplierGenTypeId", A253SupplierGenTypeId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "SUPPLIERGENTYPEID");
                     AnyError = 1;
                     GX_FocusControl = edtSupplierGenTypeId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               A47SupplierGenContactName = cgiGet( edtSupplierGenContactName_Internalname);
               AssignAttri("", false, "A47SupplierGenContactName", A47SupplierGenContactName);
               A353SupplierGenPhoneCode = cgiGet( edtSupplierGenPhoneCode_Internalname);
               AssignAttri("", false, "A353SupplierGenPhoneCode", A353SupplierGenPhoneCode);
               A354SupplierGenPhoneNumber = cgiGet( edtSupplierGenPhoneNumber_Internalname);
               AssignAttri("", false, "A354SupplierGenPhoneNumber", A354SupplierGenPhoneNumber);
               A605SupplierGenLandlineCode = cgiGet( edtSupplierGenLandlineCode_Internalname);
               AssignAttri("", false, "A605SupplierGenLandlineCode", A605SupplierGenLandlineCode);
               A606SupplierGenLandlineSubNumber = cgiGet( edtSupplierGenLandlineSubNumber_Internalname);
               AssignAttri("", false, "A606SupplierGenLandlineSubNumber", A606SupplierGenLandlineSubNumber);
               A48SupplierGenContactPhone = cgiGet( edtSupplierGenContactPhone_Internalname);
               AssignAttri("", false, "A48SupplierGenContactPhone", A48SupplierGenContactPhone);
               A607SupplierGenLandlineNumber = cgiGet( edtSupplierGenLandlineNumber_Internalname);
               AssignAttri("", false, "A607SupplierGenLandlineNumber", A607SupplierGenLandlineNumber);
               A501SupplierGenEmail = cgiGet( edtSupplierGenEmail_Internalname);
               AssignAttri("", false, "A501SupplierGenEmail", A501SupplierGenEmail);
               A428SupplierGenWebsite = cgiGet( edtSupplierGenWebsite_Internalname);
               AssignAttri("", false, "A428SupplierGenWebsite", A428SupplierGenWebsite);
               A310SupplierGenAddressLine1 = cgiGet( edtSupplierGenAddressLine1_Internalname);
               AssignAttri("", false, "A310SupplierGenAddressLine1", A310SupplierGenAddressLine1);
               A311SupplierGenAddressLine2 = cgiGet( edtSupplierGenAddressLine2_Internalname);
               AssignAttri("", false, "A311SupplierGenAddressLine2", A311SupplierGenAddressLine2);
               A259SupplierGenAddressZipCode = cgiGet( edtSupplierGenAddressZipCode_Internalname);
               AssignAttri("", false, "A259SupplierGenAddressZipCode", A259SupplierGenAddressZipCode);
               A260SupplierGenAddressCity = cgiGet( edtSupplierGenAddressCity_Internalname);
               AssignAttri("", false, "A260SupplierGenAddressCity", A260SupplierGenAddressCity);
               A309SupplierGenAddressCountry = cgiGet( edtSupplierGenAddressCountry_Internalname);
               AssignAttri("", false, "A309SupplierGenAddressCountry", A309SupplierGenAddressCountry);
               AV20ComboSupplierGenTypeId = StringUtil.StrToGuid( cgiGet( edtavCombosuppliergentypeid_Internalname));
               AssignAttri("", false, "AV20ComboSupplierGenTypeId", AV20ComboSupplierGenTypeId.ToString());
               AV25ComboSupplierGenPhoneCode = cgiGet( edtavCombosuppliergenphonecode_Internalname);
               AssignAttri("", false, "AV25ComboSupplierGenPhoneCode", AV25ComboSupplierGenPhoneCode);
               AV42ComboSupplierGenLandlineCode = cgiGet( edtavCombosuppliergenlandlinecode_Internalname);
               AssignAttri("", false, "AV42ComboSupplierGenLandlineCode", AV42ComboSupplierGenLandlineCode);
               AV24ComboSupplierGenAddressCountry = cgiGet( edtavCombosuppliergenaddresscountry_Internalname);
               AssignAttri("", false, "AV24ComboSupplierGenAddressCountry", AV24ComboSupplierGenAddressCountry);
               if ( StringUtil.StrCmp(cgiGet( edtSupplierGenId_Internalname), "") == 0 )
               {
                  A42SupplierGenId = Guid.Empty;
                  n42SupplierGenId = false;
                  AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
               }
               else
               {
                  try
                  {
                     A42SupplierGenId = StringUtil.StrToGuid( cgiGet( edtSupplierGenId_Internalname));
                     n42SupplierGenId = false;
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
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_SupplierGen");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A42SupplierGenId != Z42SupplierGenId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_suppliergen:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A42SupplierGenId = StringUtil.StrToGuid( GetPar( "SupplierGenId"));
                  n42SupplierGenId = false;
                  AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV7SupplierGenId) )
                  {
                     A42SupplierGenId = AV7SupplierGenId;
                     n42SupplierGenId = false;
                     AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A42SupplierGenId) && ( Gx_BScreen == 0 ) )
                     {
                        A42SupplierGenId = Guid.NewGuid( );
                        n42SupplierGenId = false;
                        AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
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
                     sMode9 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV7SupplierGenId) )
                     {
                        A42SupplierGenId = AV7SupplierGenId;
                        n42SupplierGenId = false;
                        AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A42SupplierGenId) && ( Gx_BScreen == 0 ) )
                        {
                           A42SupplierGenId = Guid.NewGuid( );
                           n42SupplierGenId = false;
                           AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
                        }
                     }
                     Gx_mode = sMode9;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound9 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_060( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "SUPPLIERGENID");
                        AnyError = 1;
                        GX_FocusControl = edtSupplierGenId_Internalname;
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
                        if ( StringUtil.StrCmp(sEvt, "COMBO_SUPPLIERGENTYPEID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Combo_suppliergentypeid.Onoptionclicked */
                           E12062 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11062 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E13062 ();
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
            E13062 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll069( ) ;
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
            DisableAttributes069( ) ;
         }
         AssignProp("", false, edtavCombosuppliergentypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosuppliergentypeid_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombosuppliergenphonecode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosuppliergenphonecode_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombosuppliergenlandlinecode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosuppliergenlandlinecode_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombosuppliergenaddresscountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosuppliergenaddresscountry_Enabled), 5, 0), true);
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

      protected void CONFIRM_060( )
      {
         BeforeValidate069( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls069( ) ;
            }
            else
            {
               CheckExtendedTable069( ) ;
               CloseExtendedTableCursors069( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption060( )
      {
      }

      protected void E11062( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            edtSupplierGenPhoneNumber_Class = context.GetMessage( "AttributePhoneNumberDisplay", "");
            AssignProp("", false, edtSupplierGenPhoneNumber_Internalname, "Class", edtSupplierGenPhoneNumber_Class, true);
         }
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV16DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV16DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtSupplierGenAddressCountry_Visible = 0;
         AssignProp("", false, edtSupplierGenAddressCountry_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierGenAddressCountry_Visible), 5, 0), true);
         AV24ComboSupplierGenAddressCountry = "";
         AssignAttri("", false, "AV24ComboSupplierGenAddressCountry", AV24ComboSupplierGenAddressCountry);
         edtavCombosuppliergenaddresscountry_Visible = 0;
         AssignProp("", false, edtavCombosuppliergenaddresscountry_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombosuppliergenaddresscountry_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_suppliergenaddresscountry_Htmltemplate = GXt_char2;
         ucCombo_suppliergenaddresscountry.SendProperty(context, "", false, Combo_suppliergenaddresscountry_Internalname, "HTMLTemplate", Combo_suppliergenaddresscountry_Htmltemplate);
         edtSupplierGenLandlineCode_Visible = 0;
         AssignProp("", false, edtSupplierGenLandlineCode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierGenLandlineCode_Visible), 5, 0), true);
         AV42ComboSupplierGenLandlineCode = "";
         AssignAttri("", false, "AV42ComboSupplierGenLandlineCode", AV42ComboSupplierGenLandlineCode);
         edtavCombosuppliergenlandlinecode_Visible = 0;
         AssignProp("", false, edtavCombosuppliergenlandlinecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombosuppliergenlandlinecode_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_suppliergenlandlinecode_Htmltemplate = GXt_char2;
         ucCombo_suppliergenlandlinecode.SendProperty(context, "", false, Combo_suppliergenlandlinecode_Internalname, "HTMLTemplate", Combo_suppliergenlandlinecode_Htmltemplate);
         edtSupplierGenPhoneCode_Visible = 0;
         AssignProp("", false, edtSupplierGenPhoneCode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierGenPhoneCode_Visible), 5, 0), true);
         AV25ComboSupplierGenPhoneCode = "";
         AssignAttri("", false, "AV25ComboSupplierGenPhoneCode", AV25ComboSupplierGenPhoneCode);
         edtavCombosuppliergenphonecode_Visible = 0;
         AssignProp("", false, edtavCombosuppliergenphonecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombosuppliergenphonecode_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_suppliergenphonecode_Htmltemplate = GXt_char2;
         ucCombo_suppliergenphonecode.SendProperty(context, "", false, Combo_suppliergenphonecode_Internalname, "HTMLTemplate", Combo_suppliergenphonecode_Htmltemplate);
         edtSupplierGenTypeId_Visible = 0;
         AssignProp("", false, edtSupplierGenTypeId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierGenTypeId_Visible), 5, 0), true);
         AV20ComboSupplierGenTypeId = Guid.Empty;
         AssignAttri("", false, "AV20ComboSupplierGenTypeId", AV20ComboSupplierGenTypeId.ToString());
         edtavCombosuppliergentypeid_Visible = 0;
         AssignProp("", false, edtavCombosuppliergentypeid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombosuppliergentypeid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERGENTYPEID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERGENPHONECODE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERGENLANDLINECODE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERGENADDRESSCOUNTRY' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV43Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV44GXV1 = 1;
            AssignAttri("", false, "AV44GXV1", StringUtil.LTrimStr( (decimal)(AV44GXV1), 8, 0));
            while ( AV44GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV44GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "SupplierGenTypeId") == 0 )
               {
                  AV13Insert_SupplierGenTypeId = StringUtil.StrToGuid( AV14TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV13Insert_SupplierGenTypeId", AV13Insert_SupplierGenTypeId.ToString());
                  if ( ! (Guid.Empty==AV13Insert_SupplierGenTypeId) )
                  {
                     AV20ComboSupplierGenTypeId = AV13Insert_SupplierGenTypeId;
                     AssignAttri("", false, "AV20ComboSupplierGenTypeId", AV20ComboSupplierGenTypeId.ToString());
                     Combo_suppliergentypeid_Selectedvalue_set = StringUtil.Trim( AV20ComboSupplierGenTypeId.ToString());
                     ucCombo_suppliergentypeid.SendProperty(context, "", false, Combo_suppliergentypeid_Internalname, "SelectedValue_set", Combo_suppliergentypeid_Selectedvalue_set);
                     Combo_suppliergentypeid_Enabled = false;
                     ucCombo_suppliergentypeid.SendProperty(context, "", false, Combo_suppliergentypeid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_suppliergentypeid_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "SG_OrganisationSupplierId") == 0 )
               {
                  AV34Insert_SG_OrganisationSupplierId = StringUtil.StrToGuid( AV14TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV34Insert_SG_OrganisationSupplierId", AV34Insert_SG_OrganisationSupplierId.ToString());
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "SG_LocationSupplierOrganisationId") == 0 )
               {
                  AV35Insert_SG_LocationSupplierOrganisationId = StringUtil.StrToGuid( AV14TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV35Insert_SG_LocationSupplierOrganisationId", AV35Insert_SG_LocationSupplierOrganisationId.ToString());
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "SG_LocationSupplierLocationId") == 0 )
               {
                  AV36Insert_SG_LocationSupplierLocationId = StringUtil.StrToGuid( AV14TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV36Insert_SG_LocationSupplierLocationId", AV36Insert_SG_LocationSupplierLocationId.ToString());
               }
               AV44GXV1 = (int)(AV44GXV1+1);
               AssignAttri("", false, "AV44GXV1", StringUtil.LTrimStr( (decimal)(AV44GXV1), 8, 0));
            }
         }
         edtSupplierGenId_Visible = 0;
         AssignProp("", false, edtSupplierGenId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierGenId_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV24ComboSupplierGenAddressCountry = "Netherlands";
            AssignAttri("", false, "AV24ComboSupplierGenAddressCountry", AV24ComboSupplierGenAddressCountry);
            Combo_suppliergenaddresscountry_Selectedtext_set = "Netherlands";
            ucCombo_suppliergenaddresscountry.SendProperty(context, "", false, Combo_suppliergenaddresscountry_Internalname, "SelectedText_set", Combo_suppliergenaddresscountry_Selectedtext_set);
            Combo_suppliergenaddresscountry_Selectedvalue_set = "Netherlands";
            ucCombo_suppliergenaddresscountry.SendProperty(context, "", false, Combo_suppliergenaddresscountry_Internalname, "SelectedValue_set", Combo_suppliergenaddresscountry_Selectedvalue_set);
            AV26defaultCountryPhoneCode = "+31";
            AssignAttri("", false, "AV26defaultCountryPhoneCode", AV26defaultCountryPhoneCode);
            Combo_suppliergenphonecode_Selectedtext_set = AV26defaultCountryPhoneCode;
            ucCombo_suppliergenphonecode.SendProperty(context, "", false, Combo_suppliergenphonecode_Internalname, "SelectedText_set", Combo_suppliergenphonecode_Selectedtext_set);
            Combo_suppliergenphonecode_Selectedvalue_set = AV26defaultCountryPhoneCode;
            ucCombo_suppliergenphonecode.SendProperty(context, "", false, Combo_suppliergenphonecode_Internalname, "SelectedValue_set", Combo_suppliergenphonecode_Selectedvalue_set);
            AV25ComboSupplierGenPhoneCode = AV26defaultCountryPhoneCode;
            AssignAttri("", false, "AV25ComboSupplierGenPhoneCode", AV25ComboSupplierGenPhoneCode);
            Combo_suppliergenlandlinecode_Selectedtext_set = AV26defaultCountryPhoneCode;
            ucCombo_suppliergenlandlinecode.SendProperty(context, "", false, Combo_suppliergenlandlinecode_Internalname, "SelectedText_set", Combo_suppliergenlandlinecode_Selectedtext_set);
            Combo_suppliergenlandlinecode_Selectedvalue_set = AV26defaultCountryPhoneCode;
            ucCombo_suppliergenlandlinecode.SendProperty(context, "", false, Combo_suppliergenlandlinecode_Internalname, "SelectedValue_set", Combo_suppliergenlandlinecode_Selectedvalue_set);
            AV42ComboSupplierGenLandlineCode = AV26defaultCountryPhoneCode;
            AssignAttri("", false, "AV42ComboSupplierGenLandlineCode", AV42ComboSupplierGenLandlineCode);
         }
         GXt_guid3 = AV39SG_LocationSupplierLocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid3) ;
         AV39SG_LocationSupplierLocationId = GXt_guid3;
         AssignAttri("", false, "AV39SG_LocationSupplierLocationId", AV39SG_LocationSupplierLocationId.ToString());
         if ( (Guid.Empty==AV39SG_LocationSupplierLocationId) )
         {
            A603SG_LocationSupplierLocationId = Guid.Empty;
            n603SG_LocationSupplierLocationId = false;
            AssignAttri("", false, "A603SG_LocationSupplierLocationId", A603SG_LocationSupplierLocationId.ToString());
            n603SG_LocationSupplierLocationId = true;
         }
         if ( ! (Guid.Empty==AV39SG_LocationSupplierLocationId) )
         {
            GXt_guid3 = AV38SG_LocationSupplierOrganisationId;
            new prc_getuserorganisationid(context ).execute( out  GXt_guid3) ;
            AV38SG_LocationSupplierOrganisationId = GXt_guid3;
            AssignAttri("", false, "AV38SG_LocationSupplierOrganisationId", AV38SG_LocationSupplierOrganisationId.ToString());
            if ( (Guid.Empty==AV38SG_LocationSupplierOrganisationId) )
            {
               A602SG_LocationSupplierOrganisatio = Guid.Empty;
               n602SG_LocationSupplierOrganisatio = false;
               AssignAttri("", false, "A602SG_LocationSupplierOrganisatio", A602SG_LocationSupplierOrganisatio.ToString());
               n602SG_LocationSupplierOrganisatio = true;
            }
         }
         if ( (Guid.Empty==AV39SG_LocationSupplierLocationId) )
         {
            GXt_guid3 = AV40SG_OrganisationSupplierId;
            new prc_getuserorganisationid(context ).execute( out  GXt_guid3) ;
            AV40SG_OrganisationSupplierId = GXt_guid3;
            AssignAttri("", false, "AV40SG_OrganisationSupplierId", AV40SG_OrganisationSupplierId.ToString());
            if ( (Guid.Empty==AV40SG_OrganisationSupplierId) )
            {
               A601SG_OrganisationSupplierId = Guid.Empty;
               n601SG_OrganisationSupplierId = false;
               AssignAttri("", false, "A601SG_OrganisationSupplierId", A601SG_OrganisationSupplierId.ToString());
               n601SG_OrganisationSupplierId = true;
            }
         }
      }

      protected void E13062( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV12WebSession.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "General Supplier Updated successfully", ""));
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV12WebSession.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "General Supplier Deleted successfully", ""));
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV12WebSession.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "General Supplier Inserted successfully", ""));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("trn_suppliergenww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      protected void S152( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         edtSupplierGenContactPhone_Visible = 0;
         AssignProp("", false, edtSupplierGenContactPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierGenContactPhone_Visible), 5, 0), true);
         divSuppliergencontactphone_cell_Class = "Invisible";
         AssignProp("", false, divSuppliergencontactphone_cell_Internalname, "Class", divSuppliergencontactphone_cell_Class, true);
         edtSupplierGenLandlineNumber_Visible = 0;
         AssignProp("", false, edtSupplierGenLandlineNumber_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierGenLandlineNumber_Visible), 5, 0), true);
         divSuppliergenlandlinenumber_cell_Class = "Invisible";
         AssignProp("", false, divSuppliergenlandlinenumber_cell_Internalname, "Class", divSuppliergenlandlinenumber_cell_Class, true);
         Suppliergendescription_Visible = false;
         AssignProp("", false, Suppliergendescription_Internalname, "Visible", StringUtil.BoolToStr( Suppliergendescription_Visible), true);
         divSuppliergendescription_cell_Class = "Invisible";
         AssignProp("", false, divSuppliergendescription_cell_Internalname, "Class", divSuppliergendescription_cell_Class, true);
      }

      protected void E12062( )
      {
         /* Combo_suppliergentypeid_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Combo_suppliergentypeid_Selectedvalue_get, "<#NEW#>") == 0 )
         {
            AV31DefaultSupplierGenTypeName = Combo_suppliergentypeid_Selectedtext_get;
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wp_createnewsuppliergentype.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(A253SupplierGenTypeId.ToString()) + "," + UrlEncode(StringUtil.RTrim(AV31DefaultSupplierGenTypeName));
            context.PopUp(formatLink("wp_createnewsuppliergentype.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         }
         else if ( StringUtil.StrCmp(Combo_suppliergentypeid_Selectedvalue_get, "<#POPUP_CLOSED#>") == 0 )
         {
            GXt_objcol_SdtDVB_SDTComboData_Item4 = AV15SupplierGenTypeId_Data;
            new trn_suppliergenloaddvcombo(context ).execute(  "SupplierGenTypeId",  "NEW",  AV7SupplierGenId, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_objcol_SdtDVB_SDTComboData_Item4) ;
            AV15SupplierGenTypeId_Data = GXt_objcol_SdtDVB_SDTComboData_Item4;
            AV17ComboSelectedValue = AV12WebSession.Get("SUPPLIERGENTYPEID");
            AV12WebSession.Remove("SUPPLIERGENTYPEID");
            Combo_suppliergentypeid_Selectedvalue_set = AV17ComboSelectedValue;
            ucCombo_suppliergentypeid.SendProperty(context, "", false, Combo_suppliergentypeid_Internalname, "SelectedValue_set", Combo_suppliergentypeid_Selectedvalue_set);
            AV20ComboSupplierGenTypeId = StringUtil.StrToGuid( AV17ComboSelectedValue);
            AssignAttri("", false, "AV20ComboSupplierGenTypeId", AV20ComboSupplierGenTypeId.ToString());
         }
         else
         {
            AV20ComboSupplierGenTypeId = StringUtil.StrToGuid( Combo_suppliergentypeid_Selectedvalue_get);
            AssignAttri("", false, "AV20ComboSupplierGenTypeId", AV20ComboSupplierGenTypeId.ToString());
            GXt_objcol_SdtDVB_SDTComboData_Item4 = AV15SupplierGenTypeId_Data;
            new trn_suppliergenloaddvcombo(context ).execute(  "SupplierGenTypeId",  "NEW",  AV7SupplierGenId, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_objcol_SdtDVB_SDTComboData_Item4) ;
            AV15SupplierGenTypeId_Data = GXt_objcol_SdtDVB_SDTComboData_Item4;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15SupplierGenTypeId_Data", AV15SupplierGenTypeId_Data);
      }

      protected void S142( )
      {
         /* 'LOADCOMBOSUPPLIERGENADDRESSCOUNTRY' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item4 = AV23SupplierGenAddressCountry_Data;
         new trn_suppliergenloaddvcombo(context ).execute(  "SupplierGenAddressCountry",  Gx_mode,  AV7SupplierGenId, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_objcol_SdtDVB_SDTComboData_Item4) ;
         AV23SupplierGenAddressCountry_Data = GXt_objcol_SdtDVB_SDTComboData_Item4;
         Combo_suppliergenaddresscountry_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_suppliergenaddresscountry.SendProperty(context, "", false, Combo_suppliergenaddresscountry_Internalname, "SelectedValue_set", Combo_suppliergenaddresscountry_Selectedvalue_set);
         AV24ComboSupplierGenAddressCountry = AV17ComboSelectedValue;
         AssignAttri("", false, "AV24ComboSupplierGenAddressCountry", AV24ComboSupplierGenAddressCountry);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_suppliergenaddresscountry_Enabled = false;
            ucCombo_suppliergenaddresscountry.SendProperty(context, "", false, Combo_suppliergenaddresscountry_Internalname, "Enabled", StringUtil.BoolToStr( Combo_suppliergenaddresscountry_Enabled));
         }
      }

      protected void S132( )
      {
         /* 'LOADCOMBOSUPPLIERGENLANDLINECODE' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item4 = AV41SupplierGenLandlineCode_Data;
         new trn_suppliergenloaddvcombo(context ).execute(  "SupplierGenLandlineCode",  Gx_mode,  AV7SupplierGenId, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_objcol_SdtDVB_SDTComboData_Item4) ;
         AV41SupplierGenLandlineCode_Data = GXt_objcol_SdtDVB_SDTComboData_Item4;
         Combo_suppliergenlandlinecode_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_suppliergenlandlinecode.SendProperty(context, "", false, Combo_suppliergenlandlinecode_Internalname, "SelectedValue_set", Combo_suppliergenlandlinecode_Selectedvalue_set);
         AV42ComboSupplierGenLandlineCode = AV17ComboSelectedValue;
         AssignAttri("", false, "AV42ComboSupplierGenLandlineCode", AV42ComboSupplierGenLandlineCode);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_suppliergenlandlinecode_Enabled = false;
            ucCombo_suppliergenlandlinecode.SendProperty(context, "", false, Combo_suppliergenlandlinecode_Internalname, "Enabled", StringUtil.BoolToStr( Combo_suppliergenlandlinecode_Enabled));
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBOSUPPLIERGENPHONECODE' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item4 = AV27SupplierGenPhoneCode_Data;
         new trn_suppliergenloaddvcombo(context ).execute(  "SupplierGenPhoneCode",  Gx_mode,  AV7SupplierGenId, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_objcol_SdtDVB_SDTComboData_Item4) ;
         AV27SupplierGenPhoneCode_Data = GXt_objcol_SdtDVB_SDTComboData_Item4;
         Combo_suppliergenphonecode_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_suppliergenphonecode.SendProperty(context, "", false, Combo_suppliergenphonecode_Internalname, "SelectedValue_set", Combo_suppliergenphonecode_Selectedvalue_set);
         AV25ComboSupplierGenPhoneCode = AV17ComboSelectedValue;
         AssignAttri("", false, "AV25ComboSupplierGenPhoneCode", AV25ComboSupplierGenPhoneCode);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_suppliergenphonecode_Enabled = false;
            ucCombo_suppliergenphonecode.SendProperty(context, "", false, Combo_suppliergenphonecode_Internalname, "Enabled", StringUtil.BoolToStr( Combo_suppliergenphonecode_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOSUPPLIERGENTYPEID' Routine */
         returnInSub = false;
         GXt_boolean5 = false;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "<Check_Is_Authenticated>", out  GXt_boolean5) ;
         Combo_suppliergentypeid_Includeaddnewoption = GXt_boolean5;
         ucCombo_suppliergentypeid.SendProperty(context, "", false, Combo_suppliergentypeid_Internalname, "IncludeAddNewOption", StringUtil.BoolToStr( Combo_suppliergentypeid_Includeaddnewoption));
         GXt_objcol_SdtDVB_SDTComboData_Item4 = AV15SupplierGenTypeId_Data;
         new trn_suppliergenloaddvcombo(context ).execute(  "SupplierGenTypeId",  Gx_mode,  AV7SupplierGenId, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_objcol_SdtDVB_SDTComboData_Item4) ;
         AV15SupplierGenTypeId_Data = GXt_objcol_SdtDVB_SDTComboData_Item4;
         Combo_suppliergentypeid_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_suppliergentypeid.SendProperty(context, "", false, Combo_suppliergentypeid_Internalname, "SelectedValue_set", Combo_suppliergentypeid_Selectedvalue_set);
         AV20ComboSupplierGenTypeId = StringUtil.StrToGuid( AV17ComboSelectedValue);
         AssignAttri("", false, "AV20ComboSupplierGenTypeId", AV20ComboSupplierGenTypeId.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_suppliergentypeid_Enabled = false;
            ucCombo_suppliergentypeid.SendProperty(context, "", false, Combo_suppliergentypeid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_suppliergentypeid_Enabled));
         }
      }

      protected void ZM069( short GX_JID )
      {
         if ( ( GX_JID == 45 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z309SupplierGenAddressCountry = T00063_A309SupplierGenAddressCountry[0];
               Z605SupplierGenLandlineCode = T00063_A605SupplierGenLandlineCode[0];
               Z353SupplierGenPhoneCode = T00063_A353SupplierGenPhoneCode[0];
               Z48SupplierGenContactPhone = T00063_A48SupplierGenContactPhone[0];
               Z607SupplierGenLandlineNumber = T00063_A607SupplierGenLandlineNumber[0];
               Z259SupplierGenAddressZipCode = T00063_A259SupplierGenAddressZipCode[0];
               Z43SupplierGenKvkNumber = T00063_A43SupplierGenKvkNumber[0];
               Z44SupplierGenCompanyName = T00063_A44SupplierGenCompanyName[0];
               Z260SupplierGenAddressCity = T00063_A260SupplierGenAddressCity[0];
               Z310SupplierGenAddressLine1 = T00063_A310SupplierGenAddressLine1[0];
               Z311SupplierGenAddressLine2 = T00063_A311SupplierGenAddressLine2[0];
               Z47SupplierGenContactName = T00063_A47SupplierGenContactName[0];
               Z354SupplierGenPhoneNumber = T00063_A354SupplierGenPhoneNumber[0];
               Z606SupplierGenLandlineSubNumber = T00063_A606SupplierGenLandlineSubNumber[0];
               Z501SupplierGenEmail = T00063_A501SupplierGenEmail[0];
               Z428SupplierGenWebsite = T00063_A428SupplierGenWebsite[0];
               Z253SupplierGenTypeId = T00063_A253SupplierGenTypeId[0];
               Z601SG_OrganisationSupplierId = T00063_A601SG_OrganisationSupplierId[0];
               Z602SG_LocationSupplierOrganisatio = T00063_A602SG_LocationSupplierOrganisatio[0];
               Z603SG_LocationSupplierLocationId = T00063_A603SG_LocationSupplierLocationId[0];
            }
            else
            {
               Z309SupplierGenAddressCountry = A309SupplierGenAddressCountry;
               Z605SupplierGenLandlineCode = A605SupplierGenLandlineCode;
               Z353SupplierGenPhoneCode = A353SupplierGenPhoneCode;
               Z48SupplierGenContactPhone = A48SupplierGenContactPhone;
               Z607SupplierGenLandlineNumber = A607SupplierGenLandlineNumber;
               Z259SupplierGenAddressZipCode = A259SupplierGenAddressZipCode;
               Z43SupplierGenKvkNumber = A43SupplierGenKvkNumber;
               Z44SupplierGenCompanyName = A44SupplierGenCompanyName;
               Z260SupplierGenAddressCity = A260SupplierGenAddressCity;
               Z310SupplierGenAddressLine1 = A310SupplierGenAddressLine1;
               Z311SupplierGenAddressLine2 = A311SupplierGenAddressLine2;
               Z47SupplierGenContactName = A47SupplierGenContactName;
               Z354SupplierGenPhoneNumber = A354SupplierGenPhoneNumber;
               Z606SupplierGenLandlineSubNumber = A606SupplierGenLandlineSubNumber;
               Z501SupplierGenEmail = A501SupplierGenEmail;
               Z428SupplierGenWebsite = A428SupplierGenWebsite;
               Z253SupplierGenTypeId = A253SupplierGenTypeId;
               Z601SG_OrganisationSupplierId = A601SG_OrganisationSupplierId;
               Z602SG_LocationSupplierOrganisatio = A602SG_LocationSupplierOrganisatio;
               Z603SG_LocationSupplierLocationId = A603SG_LocationSupplierLocationId;
            }
         }
         if ( GX_JID == -45 )
         {
            Z42SupplierGenId = A42SupplierGenId;
            Z309SupplierGenAddressCountry = A309SupplierGenAddressCountry;
            Z605SupplierGenLandlineCode = A605SupplierGenLandlineCode;
            Z353SupplierGenPhoneCode = A353SupplierGenPhoneCode;
            Z48SupplierGenContactPhone = A48SupplierGenContactPhone;
            Z607SupplierGenLandlineNumber = A607SupplierGenLandlineNumber;
            Z259SupplierGenAddressZipCode = A259SupplierGenAddressZipCode;
            Z43SupplierGenKvkNumber = A43SupplierGenKvkNumber;
            Z44SupplierGenCompanyName = A44SupplierGenCompanyName;
            Z260SupplierGenAddressCity = A260SupplierGenAddressCity;
            Z310SupplierGenAddressLine1 = A310SupplierGenAddressLine1;
            Z311SupplierGenAddressLine2 = A311SupplierGenAddressLine2;
            Z47SupplierGenContactName = A47SupplierGenContactName;
            Z354SupplierGenPhoneNumber = A354SupplierGenPhoneNumber;
            Z606SupplierGenLandlineSubNumber = A606SupplierGenLandlineSubNumber;
            Z501SupplierGenEmail = A501SupplierGenEmail;
            Z428SupplierGenWebsite = A428SupplierGenWebsite;
            Z604SupplierGenDescription = A604SupplierGenDescription;
            Z253SupplierGenTypeId = A253SupplierGenTypeId;
            Z601SG_OrganisationSupplierId = A601SG_OrganisationSupplierId;
            Z602SG_LocationSupplierOrganisatio = A602SG_LocationSupplierOrganisatio;
            Z603SG_LocationSupplierLocationId = A603SG_LocationSupplierLocationId;
            Z254SupplierGenTypeName = A254SupplierGenTypeName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtSupplierGenContactPhone_Visible = ((StringUtil.StrCmp(Gx_mode, "DSP")==0)||(StringUtil.StrCmp(Gx_mode, "DLT")==0) ? 1 : 0);
         AssignProp("", false, edtSupplierGenContactPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierGenContactPhone_Visible), 5, 0), true);
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) ) )
         {
            divSuppliergencontactphone_cell_Class = context.GetMessage( "Invisible", "");
            AssignProp("", false, divSuppliergencontactphone_cell_Internalname, "Class", divSuppliergencontactphone_cell_Class, true);
         }
         else
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               divSuppliergencontactphone_cell_Class = context.GetMessage( "col-xs-12 DataContentCell", "");
               AssignProp("", false, divSuppliergencontactphone_cell_Internalname, "Class", divSuppliergencontactphone_cell_Class, true);
            }
         }
         edtSupplierGenLandlineNumber_Visible = ((StringUtil.StrCmp(Gx_mode, "DSP")==0)||(StringUtil.StrCmp(Gx_mode, "DLT")==0) ? 1 : 0);
         AssignProp("", false, edtSupplierGenLandlineNumber_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierGenLandlineNumber_Visible), 5, 0), true);
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) ) )
         {
            divSuppliergenlandlinenumber_cell_Class = context.GetMessage( "Invisible", "");
            AssignProp("", false, divSuppliergenlandlinenumber_cell_Internalname, "Class", divSuppliergenlandlinenumber_cell_Class, true);
         }
         else
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               divSuppliergenlandlinenumber_cell_Class = context.GetMessage( "col-xs-12 DataContentCell", "");
               AssignProp("", false, divSuppliergenlandlinenumber_cell_Internalname, "Class", divSuppliergenlandlinenumber_cell_Class, true);
            }
         }
         Suppliergendescription_Visible = (bool)((StringUtil.StrCmp(Gx_mode, "INS")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0));
         AssignProp("", false, Suppliergendescription_Internalname, "Visible", StringUtil.BoolToStr( Suppliergendescription_Visible), true);
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) ) )
         {
            divSuppliergendescription_cell_Class = context.GetMessage( "Invisible", "");
            AssignProp("", false, divSuppliergendescription_cell_Internalname, "Class", divSuppliergendescription_cell_Class, true);
         }
         else
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
            {
               divSuppliergendescription_cell_Class = context.GetMessage( "col-xs-12 DataContentCell CKEditor", "");
               AssignProp("", false, divSuppliergendescription_cell_Internalname, "Class", divSuppliergendescription_cell_Class, true);
            }
         }
         divUnnamedtable5_Visible = (((StringUtil.StrCmp(Gx_mode, "INS")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0)) ? 1 : 0);
         AssignProp("", false, divUnnamedtable5_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUnnamedtable5_Visible), 5, 0), true);
         divUnnamedtable6_Visible = (((StringUtil.StrCmp(Gx_mode, "INS")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0)) ? 1 : 0);
         AssignProp("", false, divUnnamedtable6_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUnnamedtable6_Visible), 5, 0), true);
         divDescriptiontable_Visible = (((StringUtil.StrCmp(Gx_mode, "DSP")==0)) ? 1 : 0);
         AssignProp("", false, divDescriptiontable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDescriptiontable_Visible), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV43Pgmname = "Trn_SupplierGen";
         AssignAttri("", false, "AV43Pgmname", AV43Pgmname);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV7SupplierGenId) )
         {
            edtSupplierGenId_Enabled = 0;
            AssignProp("", false, edtSupplierGenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenId_Enabled), 5, 0), true);
         }
         else
         {
            edtSupplierGenId_Enabled = 1;
            AssignProp("", false, edtSupplierGenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7SupplierGenId) )
         {
            edtSupplierGenId_Enabled = 0;
            AssignProp("", false, edtSupplierGenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV13Insert_SupplierGenTypeId) )
         {
            edtSupplierGenTypeId_Enabled = 0;
            AssignProp("", false, edtSupplierGenTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenTypeId_Enabled), 5, 0), true);
         }
         else
         {
            edtSupplierGenTypeId_Enabled = 1;
            AssignProp("", false, edtSupplierGenTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenTypeId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV36Insert_SG_LocationSupplierLocationId) )
         {
            A603SG_LocationSupplierLocationId = AV36Insert_SG_LocationSupplierLocationId;
            n603SG_LocationSupplierLocationId = false;
            AssignAttri("", false, "A603SG_LocationSupplierLocationId", A603SG_LocationSupplierLocationId.ToString());
         }
         else
         {
            if ( IsIns( )  && ! (Guid.Empty==AV39SG_LocationSupplierLocationId) )
            {
               A603SG_LocationSupplierLocationId = AV39SG_LocationSupplierLocationId;
               n603SG_LocationSupplierLocationId = false;
               AssignAttri("", false, "A603SG_LocationSupplierLocationId", A603SG_LocationSupplierLocationId.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV35Insert_SG_LocationSupplierOrganisationId) )
         {
            A602SG_LocationSupplierOrganisatio = AV35Insert_SG_LocationSupplierOrganisationId;
            n602SG_LocationSupplierOrganisatio = false;
            AssignAttri("", false, "A602SG_LocationSupplierOrganisatio", A602SG_LocationSupplierOrganisatio.ToString());
         }
         else
         {
            if ( IsIns( )  && ! (Guid.Empty==AV38SG_LocationSupplierOrganisationId) )
            {
               A602SG_LocationSupplierOrganisatio = AV38SG_LocationSupplierOrganisationId;
               n602SG_LocationSupplierOrganisatio = false;
               AssignAttri("", false, "A602SG_LocationSupplierOrganisatio", A602SG_LocationSupplierOrganisatio.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV34Insert_SG_OrganisationSupplierId) )
         {
            A601SG_OrganisationSupplierId = AV34Insert_SG_OrganisationSupplierId;
            n601SG_OrganisationSupplierId = false;
            AssignAttri("", false, "A601SG_OrganisationSupplierId", A601SG_OrganisationSupplierId.ToString());
         }
         else
         {
            if ( IsIns( )  && ! (Guid.Empty==AV40SG_OrganisationSupplierId) )
            {
               A601SG_OrganisationSupplierId = AV40SG_OrganisationSupplierId;
               n601SG_OrganisationSupplierId = false;
               AssignAttri("", false, "A601SG_OrganisationSupplierId", A601SG_OrganisationSupplierId.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV13Insert_SupplierGenTypeId) )
         {
            A253SupplierGenTypeId = AV13Insert_SupplierGenTypeId;
            AssignAttri("", false, "A253SupplierGenTypeId", A253SupplierGenTypeId.ToString());
         }
         else
         {
            A253SupplierGenTypeId = AV20ComboSupplierGenTypeId;
            AssignAttri("", false, "A253SupplierGenTypeId", A253SupplierGenTypeId.ToString());
         }
         A353SupplierGenPhoneCode = AV25ComboSupplierGenPhoneCode;
         AssignAttri("", false, "A353SupplierGenPhoneCode", A353SupplierGenPhoneCode);
         A605SupplierGenLandlineCode = AV42ComboSupplierGenLandlineCode;
         AssignAttri("", false, "A605SupplierGenLandlineCode", A605SupplierGenLandlineCode);
         A309SupplierGenAddressCountry = AV24ComboSupplierGenAddressCountry;
         AssignAttri("", false, "A309SupplierGenAddressCountry", A309SupplierGenAddressCountry);
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
         if ( ! (Guid.Empty==AV7SupplierGenId) )
         {
            A42SupplierGenId = AV7SupplierGenId;
            n42SupplierGenId = false;
            AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A42SupplierGenId) && ( Gx_BScreen == 0 ) )
            {
               A42SupplierGenId = Guid.NewGuid( );
               n42SupplierGenId = false;
               AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00064 */
            pr_default.execute(2, new Object[] {A253SupplierGenTypeId});
            A254SupplierGenTypeName = T00064_A254SupplierGenTypeName[0];
            pr_default.close(2);
         }
      }

      protected void Load069( )
      {
         /* Using cursor T00067 */
         pr_default.execute(5, new Object[] {n42SupplierGenId, A42SupplierGenId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound9 = 1;
            A309SupplierGenAddressCountry = T00067_A309SupplierGenAddressCountry[0];
            AssignAttri("", false, "A309SupplierGenAddressCountry", A309SupplierGenAddressCountry);
            A605SupplierGenLandlineCode = T00067_A605SupplierGenLandlineCode[0];
            AssignAttri("", false, "A605SupplierGenLandlineCode", A605SupplierGenLandlineCode);
            A353SupplierGenPhoneCode = T00067_A353SupplierGenPhoneCode[0];
            AssignAttri("", false, "A353SupplierGenPhoneCode", A353SupplierGenPhoneCode);
            A48SupplierGenContactPhone = T00067_A48SupplierGenContactPhone[0];
            AssignAttri("", false, "A48SupplierGenContactPhone", A48SupplierGenContactPhone);
            A607SupplierGenLandlineNumber = T00067_A607SupplierGenLandlineNumber[0];
            AssignAttri("", false, "A607SupplierGenLandlineNumber", A607SupplierGenLandlineNumber);
            A259SupplierGenAddressZipCode = T00067_A259SupplierGenAddressZipCode[0];
            AssignAttri("", false, "A259SupplierGenAddressZipCode", A259SupplierGenAddressZipCode);
            A43SupplierGenKvkNumber = T00067_A43SupplierGenKvkNumber[0];
            AssignAttri("", false, "A43SupplierGenKvkNumber", A43SupplierGenKvkNumber);
            A254SupplierGenTypeName = T00067_A254SupplierGenTypeName[0];
            A44SupplierGenCompanyName = T00067_A44SupplierGenCompanyName[0];
            AssignAttri("", false, "A44SupplierGenCompanyName", A44SupplierGenCompanyName);
            A260SupplierGenAddressCity = T00067_A260SupplierGenAddressCity[0];
            AssignAttri("", false, "A260SupplierGenAddressCity", A260SupplierGenAddressCity);
            A310SupplierGenAddressLine1 = T00067_A310SupplierGenAddressLine1[0];
            AssignAttri("", false, "A310SupplierGenAddressLine1", A310SupplierGenAddressLine1);
            A311SupplierGenAddressLine2 = T00067_A311SupplierGenAddressLine2[0];
            AssignAttri("", false, "A311SupplierGenAddressLine2", A311SupplierGenAddressLine2);
            A47SupplierGenContactName = T00067_A47SupplierGenContactName[0];
            AssignAttri("", false, "A47SupplierGenContactName", A47SupplierGenContactName);
            A354SupplierGenPhoneNumber = T00067_A354SupplierGenPhoneNumber[0];
            AssignAttri("", false, "A354SupplierGenPhoneNumber", A354SupplierGenPhoneNumber);
            A606SupplierGenLandlineSubNumber = T00067_A606SupplierGenLandlineSubNumber[0];
            AssignAttri("", false, "A606SupplierGenLandlineSubNumber", A606SupplierGenLandlineSubNumber);
            A501SupplierGenEmail = T00067_A501SupplierGenEmail[0];
            AssignAttri("", false, "A501SupplierGenEmail", A501SupplierGenEmail);
            A428SupplierGenWebsite = T00067_A428SupplierGenWebsite[0];
            AssignAttri("", false, "A428SupplierGenWebsite", A428SupplierGenWebsite);
            A604SupplierGenDescription = T00067_A604SupplierGenDescription[0];
            A253SupplierGenTypeId = T00067_A253SupplierGenTypeId[0];
            AssignAttri("", false, "A253SupplierGenTypeId", A253SupplierGenTypeId.ToString());
            A601SG_OrganisationSupplierId = T00067_A601SG_OrganisationSupplierId[0];
            n601SG_OrganisationSupplierId = T00067_n601SG_OrganisationSupplierId[0];
            A602SG_LocationSupplierOrganisatio = T00067_A602SG_LocationSupplierOrganisatio[0];
            n602SG_LocationSupplierOrganisatio = T00067_n602SG_LocationSupplierOrganisatio[0];
            A603SG_LocationSupplierLocationId = T00067_A603SG_LocationSupplierLocationId[0];
            n603SG_LocationSupplierLocationId = T00067_n603SG_LocationSupplierLocationId[0];
            ZM069( -45) ;
         }
         pr_default.close(5);
         OnLoadActions069( ) ;
      }

      protected void OnLoadActions069( )
      {
         A259SupplierGenAddressZipCode = StringUtil.Upper( A259SupplierGenAddressZipCode);
         AssignAttri("", false, "A259SupplierGenAddressZipCode", A259SupplierGenAddressZipCode);
         GXt_char2 = A48SupplierGenContactPhone;
         new prc_concatenateintlphone(context ).execute(  A353SupplierGenPhoneCode,  A354SupplierGenPhoneNumber, out  GXt_char2) ;
         A48SupplierGenContactPhone = GXt_char2;
         AssignAttri("", false, "A48SupplierGenContactPhone", A48SupplierGenContactPhone);
         GXt_char2 = A607SupplierGenLandlineNumber;
         new prc_concatenateintlphone(context ).execute(  A605SupplierGenLandlineCode,  A606SupplierGenLandlineSubNumber, out  GXt_char2) ;
         A607SupplierGenLandlineNumber = GXt_char2;
         AssignAttri("", false, "A607SupplierGenLandlineNumber", A607SupplierGenLandlineNumber);
      }

      protected void CheckExtendedTable069( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A43SupplierGenKvkNumber,"\\b\\d{8}\\b") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "KvK number should contain 8 digits", ""), context.GetMessage( "Supplier Gen KvK Number", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "SUPPLIERGENKVKNUMBER");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenKvkNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A43SupplierGenKvkNumber)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier Gen KvK Number", ""), "", "", "", "", "", "", "", ""), 1, "SUPPLIERGENKVKNUMBER");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenKvkNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( StringUtil.Len( A43SupplierGenKvkNumber) != 8 )
         {
            GX_msglist.addItem(context.GetMessage( "KvK number should contain 8 digits", ""), 1, "SUPPLIERGENKVKNUMBER");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenKvkNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00064 */
         pr_default.execute(2, new Object[] {A253SupplierGenTypeId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "General Supplier Types", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SUPPLIERGENTYPEID");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenTypeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A254SupplierGenTypeName = T00064_A254SupplierGenTypeName[0];
         pr_default.close(2);
         if ( (Guid.Empty==A253SupplierGenTypeId) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Category", ""), "", "", "", "", "", "", "", ""), 1, "SUPPLIERGENTYPEID");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenTypeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A44SupplierGenCompanyName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Company Name", ""), "", "", "", "", "", "", "", ""), 1, "SUPPLIERGENCOMPANYNAME");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenCompanyName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A309SupplierGenAddressCountry)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier Gen Address Country", ""), "", "", "", "", "", "", "", ""), 1, "SUPPLIERGENADDRESSCOUNTRY");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenAddressCountry_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A260SupplierGenAddressCity)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "City", ""), "", "", "", "", "", "", "", ""), 1, "SUPPLIERGENADDRESSCITY");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenAddressCity_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A259SupplierGenAddressZipCode = StringUtil.Upper( A259SupplierGenAddressZipCode);
         AssignAttri("", false, "A259SupplierGenAddressZipCode", A259SupplierGenAddressZipCode);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A259SupplierGenAddressZipCode)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Zip Code", ""), "", "", "", "", "", "", "", ""), 1, "SUPPLIERGENADDRESSZIPCODE");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenAddressZipCode_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! GxRegex.IsMatch(A259SupplierGenAddressZipCode,context.GetMessage( "^\\d{4}\\s?[A-Z]{2}$", "")) && ! String.IsNullOrEmpty(StringUtil.RTrim( A259SupplierGenAddressZipCode)) )
         {
            GX_msglist.addItem(context.GetMessage( "Zip Code is incorrect", ""), 1, "SUPPLIERGENADDRESSZIPCODE");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenAddressZipCode_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A310SupplierGenAddressLine1)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Address Line1", ""), "", "", "", "", "", "", "", ""), 1, "SUPPLIERGENADDRESSLINE1");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenAddressLine1_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GXt_char2 = A48SupplierGenContactPhone;
         new prc_concatenateintlphone(context ).execute(  A353SupplierGenPhoneCode,  A354SupplierGenPhoneNumber, out  GXt_char2) ;
         A48SupplierGenContactPhone = GXt_char2;
         AssignAttri("", false, "A48SupplierGenContactPhone", A48SupplierGenContactPhone);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A354SupplierGenPhoneNumber)) && ! GxRegex.IsMatch(A354SupplierGenPhoneNumber,context.GetMessage( "^\\d{9}$", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Phone should contain 9 digits", ""), 1, "SUPPLIERGENPHONENUMBER");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenPhoneNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GXt_char2 = A607SupplierGenLandlineNumber;
         new prc_concatenateintlphone(context ).execute(  A605SupplierGenLandlineCode,  A606SupplierGenLandlineSubNumber, out  GXt_char2) ;
         A607SupplierGenLandlineNumber = GXt_char2;
         AssignAttri("", false, "A607SupplierGenLandlineNumber", A607SupplierGenLandlineNumber);
         if ( ! ( GxRegex.IsMatch(A501SupplierGenEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "Invalid email pattern", ""), context.GetMessage( "Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "SUPPLIERGENEMAIL");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! GxRegex.IsMatch(A428SupplierGenWebsite,context.GetMessage( "(?:https?://|www\\.)[^\\s/$.?#].[^\\s]*", "")) && ! String.IsNullOrEmpty(StringUtil.RTrim( A428SupplierGenWebsite)) )
         {
            GX_msglist.addItem(context.GetMessage( "Invalid website format", ""), 1, "SUPPLIERGENWEBSITE");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenWebsite_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00065 */
         pr_default.execute(3, new Object[] {n601SG_OrganisationSupplierId, A601SG_OrganisationSupplierId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (Guid.Empty==A601SG_OrganisationSupplierId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "SG_Organisation Supplier", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SG_ORGANISATIONSUPPLIERID");
               AnyError = 1;
            }
         }
         pr_default.close(3);
         /* Using cursor T00066 */
         pr_default.execute(4, new Object[] {n603SG_LocationSupplierLocationId, A603SG_LocationSupplierLocationId, n602SG_LocationSupplierOrganisatio, A602SG_LocationSupplierOrganisatio});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (Guid.Empty==A603SG_LocationSupplierLocationId) || (Guid.Empty==A602SG_LocationSupplierOrganisatio) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "SG_Location Supplier", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SG_LOCATIONSUPPLIERORGANISATIO");
               AnyError = 1;
            }
         }
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors069( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_46( Guid A253SupplierGenTypeId )
      {
         /* Using cursor T00068 */
         pr_default.execute(6, new Object[] {A253SupplierGenTypeId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "General Supplier Types", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SUPPLIERGENTYPEID");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenTypeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A254SupplierGenTypeName = T00068_A254SupplierGenTypeName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A254SupplierGenTypeName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_47( Guid A601SG_OrganisationSupplierId )
      {
         /* Using cursor T00069 */
         pr_default.execute(7, new Object[] {n601SG_OrganisationSupplierId, A601SG_OrganisationSupplierId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (Guid.Empty==A601SG_OrganisationSupplierId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "SG_Organisation Supplier", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SG_ORGANISATIONSUPPLIERID");
               AnyError = 1;
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

      protected void gxLoad_48( Guid A603SG_LocationSupplierLocationId ,
                                Guid A602SG_LocationSupplierOrganisatio )
      {
         /* Using cursor T000610 */
         pr_default.execute(8, new Object[] {n603SG_LocationSupplierLocationId, A603SG_LocationSupplierLocationId, n602SG_LocationSupplierOrganisatio, A602SG_LocationSupplierOrganisatio});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (Guid.Empty==A603SG_LocationSupplierLocationId) || (Guid.Empty==A602SG_LocationSupplierOrganisatio) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "SG_Location Supplier", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SG_LOCATIONSUPPLIERORGANISATIO");
               AnyError = 1;
            }
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

      protected void GetKey069( )
      {
         /* Using cursor T000611 */
         pr_default.execute(9, new Object[] {n42SupplierGenId, A42SupplierGenId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00063 */
         pr_default.execute(1, new Object[] {n42SupplierGenId, A42SupplierGenId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM069( 45) ;
            RcdFound9 = 1;
            A42SupplierGenId = T00063_A42SupplierGenId[0];
            n42SupplierGenId = T00063_n42SupplierGenId[0];
            AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
            A309SupplierGenAddressCountry = T00063_A309SupplierGenAddressCountry[0];
            AssignAttri("", false, "A309SupplierGenAddressCountry", A309SupplierGenAddressCountry);
            A605SupplierGenLandlineCode = T00063_A605SupplierGenLandlineCode[0];
            AssignAttri("", false, "A605SupplierGenLandlineCode", A605SupplierGenLandlineCode);
            A353SupplierGenPhoneCode = T00063_A353SupplierGenPhoneCode[0];
            AssignAttri("", false, "A353SupplierGenPhoneCode", A353SupplierGenPhoneCode);
            A48SupplierGenContactPhone = T00063_A48SupplierGenContactPhone[0];
            AssignAttri("", false, "A48SupplierGenContactPhone", A48SupplierGenContactPhone);
            A607SupplierGenLandlineNumber = T00063_A607SupplierGenLandlineNumber[0];
            AssignAttri("", false, "A607SupplierGenLandlineNumber", A607SupplierGenLandlineNumber);
            A259SupplierGenAddressZipCode = T00063_A259SupplierGenAddressZipCode[0];
            AssignAttri("", false, "A259SupplierGenAddressZipCode", A259SupplierGenAddressZipCode);
            A43SupplierGenKvkNumber = T00063_A43SupplierGenKvkNumber[0];
            AssignAttri("", false, "A43SupplierGenKvkNumber", A43SupplierGenKvkNumber);
            A44SupplierGenCompanyName = T00063_A44SupplierGenCompanyName[0];
            AssignAttri("", false, "A44SupplierGenCompanyName", A44SupplierGenCompanyName);
            A260SupplierGenAddressCity = T00063_A260SupplierGenAddressCity[0];
            AssignAttri("", false, "A260SupplierGenAddressCity", A260SupplierGenAddressCity);
            A310SupplierGenAddressLine1 = T00063_A310SupplierGenAddressLine1[0];
            AssignAttri("", false, "A310SupplierGenAddressLine1", A310SupplierGenAddressLine1);
            A311SupplierGenAddressLine2 = T00063_A311SupplierGenAddressLine2[0];
            AssignAttri("", false, "A311SupplierGenAddressLine2", A311SupplierGenAddressLine2);
            A47SupplierGenContactName = T00063_A47SupplierGenContactName[0];
            AssignAttri("", false, "A47SupplierGenContactName", A47SupplierGenContactName);
            A354SupplierGenPhoneNumber = T00063_A354SupplierGenPhoneNumber[0];
            AssignAttri("", false, "A354SupplierGenPhoneNumber", A354SupplierGenPhoneNumber);
            A606SupplierGenLandlineSubNumber = T00063_A606SupplierGenLandlineSubNumber[0];
            AssignAttri("", false, "A606SupplierGenLandlineSubNumber", A606SupplierGenLandlineSubNumber);
            A501SupplierGenEmail = T00063_A501SupplierGenEmail[0];
            AssignAttri("", false, "A501SupplierGenEmail", A501SupplierGenEmail);
            A428SupplierGenWebsite = T00063_A428SupplierGenWebsite[0];
            AssignAttri("", false, "A428SupplierGenWebsite", A428SupplierGenWebsite);
            A604SupplierGenDescription = T00063_A604SupplierGenDescription[0];
            A253SupplierGenTypeId = T00063_A253SupplierGenTypeId[0];
            AssignAttri("", false, "A253SupplierGenTypeId", A253SupplierGenTypeId.ToString());
            A601SG_OrganisationSupplierId = T00063_A601SG_OrganisationSupplierId[0];
            n601SG_OrganisationSupplierId = T00063_n601SG_OrganisationSupplierId[0];
            A602SG_LocationSupplierOrganisatio = T00063_A602SG_LocationSupplierOrganisatio[0];
            n602SG_LocationSupplierOrganisatio = T00063_n602SG_LocationSupplierOrganisatio[0];
            A603SG_LocationSupplierLocationId = T00063_A603SG_LocationSupplierLocationId[0];
            n603SG_LocationSupplierLocationId = T00063_n603SG_LocationSupplierLocationId[0];
            Z42SupplierGenId = A42SupplierGenId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load069( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey069( ) ;
            }
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey069( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey069( ) ;
         if ( RcdFound9 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound9 = 0;
         /* Using cursor T000612 */
         pr_default.execute(10, new Object[] {n42SupplierGenId, A42SupplierGenId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( GuidUtil.Compare(T000612_A42SupplierGenId[0], A42SupplierGenId, 0) < 0 ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( GuidUtil.Compare(T000612_A42SupplierGenId[0], A42SupplierGenId, 0) > 0 ) ) )
            {
               A42SupplierGenId = T000612_A42SupplierGenId[0];
               n42SupplierGenId = T000612_n42SupplierGenId[0];
               AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
               RcdFound9 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound9 = 0;
         /* Using cursor T000613 */
         pr_default.execute(11, new Object[] {n42SupplierGenId, A42SupplierGenId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( GuidUtil.Compare(T000613_A42SupplierGenId[0], A42SupplierGenId, 0) > 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( GuidUtil.Compare(T000613_A42SupplierGenId[0], A42SupplierGenId, 0) < 0 ) ) )
            {
               A42SupplierGenId = T000613_A42SupplierGenId[0];
               n42SupplierGenId = T000613_n42SupplierGenId[0];
               AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
               RcdFound9 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey069( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSupplierGenKvkNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert069( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( A42SupplierGenId != Z42SupplierGenId )
               {
                  A42SupplierGenId = Z42SupplierGenId;
                  n42SupplierGenId = false;
                  AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SUPPLIERGENID");
                  AnyError = 1;
                  GX_FocusControl = edtSupplierGenId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSupplierGenKvkNumber_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update069( ) ;
                  GX_FocusControl = edtSupplierGenKvkNumber_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A42SupplierGenId != Z42SupplierGenId )
               {
                  /* Insert record */
                  GX_FocusControl = edtSupplierGenKvkNumber_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert069( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SUPPLIERGENID");
                     AnyError = 1;
                     GX_FocusControl = edtSupplierGenId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtSupplierGenKvkNumber_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert069( ) ;
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
         if ( A42SupplierGenId != Z42SupplierGenId )
         {
            A42SupplierGenId = Z42SupplierGenId;
            n42SupplierGenId = false;
            AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SUPPLIERGENID");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSupplierGenKvkNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency069( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00062 */
            pr_default.execute(0, new Object[] {n42SupplierGenId, A42SupplierGenId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_SupplierGen"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z309SupplierGenAddressCountry, T00062_A309SupplierGenAddressCountry[0]) != 0 ) || ( StringUtil.StrCmp(Z605SupplierGenLandlineCode, T00062_A605SupplierGenLandlineCode[0]) != 0 ) || ( StringUtil.StrCmp(Z353SupplierGenPhoneCode, T00062_A353SupplierGenPhoneCode[0]) != 0 ) || ( StringUtil.StrCmp(Z48SupplierGenContactPhone, T00062_A48SupplierGenContactPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z607SupplierGenLandlineNumber, T00062_A607SupplierGenLandlineNumber[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z259SupplierGenAddressZipCode, T00062_A259SupplierGenAddressZipCode[0]) != 0 ) || ( StringUtil.StrCmp(Z43SupplierGenKvkNumber, T00062_A43SupplierGenKvkNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z44SupplierGenCompanyName, T00062_A44SupplierGenCompanyName[0]) != 0 ) || ( StringUtil.StrCmp(Z260SupplierGenAddressCity, T00062_A260SupplierGenAddressCity[0]) != 0 ) || ( StringUtil.StrCmp(Z310SupplierGenAddressLine1, T00062_A310SupplierGenAddressLine1[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z311SupplierGenAddressLine2, T00062_A311SupplierGenAddressLine2[0]) != 0 ) || ( StringUtil.StrCmp(Z47SupplierGenContactName, T00062_A47SupplierGenContactName[0]) != 0 ) || ( StringUtil.StrCmp(Z354SupplierGenPhoneNumber, T00062_A354SupplierGenPhoneNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z606SupplierGenLandlineSubNumber, T00062_A606SupplierGenLandlineSubNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z501SupplierGenEmail, T00062_A501SupplierGenEmail[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z428SupplierGenWebsite, T00062_A428SupplierGenWebsite[0]) != 0 ) || ( Z253SupplierGenTypeId != T00062_A253SupplierGenTypeId[0] ) || ( Z601SG_OrganisationSupplierId != T00062_A601SG_OrganisationSupplierId[0] ) || ( Z602SG_LocationSupplierOrganisatio != T00062_A602SG_LocationSupplierOrganisatio[0] ) || ( Z603SG_LocationSupplierLocationId != T00062_A603SG_LocationSupplierLocationId[0] ) )
            {
               if ( StringUtil.StrCmp(Z309SupplierGenAddressCountry, T00062_A309SupplierGenAddressCountry[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenAddressCountry");
                  GXUtil.WriteLogRaw("Old: ",Z309SupplierGenAddressCountry);
                  GXUtil.WriteLogRaw("Current: ",T00062_A309SupplierGenAddressCountry[0]);
               }
               if ( StringUtil.StrCmp(Z605SupplierGenLandlineCode, T00062_A605SupplierGenLandlineCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenLandlineCode");
                  GXUtil.WriteLogRaw("Old: ",Z605SupplierGenLandlineCode);
                  GXUtil.WriteLogRaw("Current: ",T00062_A605SupplierGenLandlineCode[0]);
               }
               if ( StringUtil.StrCmp(Z353SupplierGenPhoneCode, T00062_A353SupplierGenPhoneCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenPhoneCode");
                  GXUtil.WriteLogRaw("Old: ",Z353SupplierGenPhoneCode);
                  GXUtil.WriteLogRaw("Current: ",T00062_A353SupplierGenPhoneCode[0]);
               }
               if ( StringUtil.StrCmp(Z48SupplierGenContactPhone, T00062_A48SupplierGenContactPhone[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenContactPhone");
                  GXUtil.WriteLogRaw("Old: ",Z48SupplierGenContactPhone);
                  GXUtil.WriteLogRaw("Current: ",T00062_A48SupplierGenContactPhone[0]);
               }
               if ( StringUtil.StrCmp(Z607SupplierGenLandlineNumber, T00062_A607SupplierGenLandlineNumber[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenLandlineNumber");
                  GXUtil.WriteLogRaw("Old: ",Z607SupplierGenLandlineNumber);
                  GXUtil.WriteLogRaw("Current: ",T00062_A607SupplierGenLandlineNumber[0]);
               }
               if ( StringUtil.StrCmp(Z259SupplierGenAddressZipCode, T00062_A259SupplierGenAddressZipCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenAddressZipCode");
                  GXUtil.WriteLogRaw("Old: ",Z259SupplierGenAddressZipCode);
                  GXUtil.WriteLogRaw("Current: ",T00062_A259SupplierGenAddressZipCode[0]);
               }
               if ( StringUtil.StrCmp(Z43SupplierGenKvkNumber, T00062_A43SupplierGenKvkNumber[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenKvkNumber");
                  GXUtil.WriteLogRaw("Old: ",Z43SupplierGenKvkNumber);
                  GXUtil.WriteLogRaw("Current: ",T00062_A43SupplierGenKvkNumber[0]);
               }
               if ( StringUtil.StrCmp(Z44SupplierGenCompanyName, T00062_A44SupplierGenCompanyName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenCompanyName");
                  GXUtil.WriteLogRaw("Old: ",Z44SupplierGenCompanyName);
                  GXUtil.WriteLogRaw("Current: ",T00062_A44SupplierGenCompanyName[0]);
               }
               if ( StringUtil.StrCmp(Z260SupplierGenAddressCity, T00062_A260SupplierGenAddressCity[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenAddressCity");
                  GXUtil.WriteLogRaw("Old: ",Z260SupplierGenAddressCity);
                  GXUtil.WriteLogRaw("Current: ",T00062_A260SupplierGenAddressCity[0]);
               }
               if ( StringUtil.StrCmp(Z310SupplierGenAddressLine1, T00062_A310SupplierGenAddressLine1[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenAddressLine1");
                  GXUtil.WriteLogRaw("Old: ",Z310SupplierGenAddressLine1);
                  GXUtil.WriteLogRaw("Current: ",T00062_A310SupplierGenAddressLine1[0]);
               }
               if ( StringUtil.StrCmp(Z311SupplierGenAddressLine2, T00062_A311SupplierGenAddressLine2[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenAddressLine2");
                  GXUtil.WriteLogRaw("Old: ",Z311SupplierGenAddressLine2);
                  GXUtil.WriteLogRaw("Current: ",T00062_A311SupplierGenAddressLine2[0]);
               }
               if ( StringUtil.StrCmp(Z47SupplierGenContactName, T00062_A47SupplierGenContactName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenContactName");
                  GXUtil.WriteLogRaw("Old: ",Z47SupplierGenContactName);
                  GXUtil.WriteLogRaw("Current: ",T00062_A47SupplierGenContactName[0]);
               }
               if ( StringUtil.StrCmp(Z354SupplierGenPhoneNumber, T00062_A354SupplierGenPhoneNumber[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenPhoneNumber");
                  GXUtil.WriteLogRaw("Old: ",Z354SupplierGenPhoneNumber);
                  GXUtil.WriteLogRaw("Current: ",T00062_A354SupplierGenPhoneNumber[0]);
               }
               if ( StringUtil.StrCmp(Z606SupplierGenLandlineSubNumber, T00062_A606SupplierGenLandlineSubNumber[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenLandlineSubNumber");
                  GXUtil.WriteLogRaw("Old: ",Z606SupplierGenLandlineSubNumber);
                  GXUtil.WriteLogRaw("Current: ",T00062_A606SupplierGenLandlineSubNumber[0]);
               }
               if ( StringUtil.StrCmp(Z501SupplierGenEmail, T00062_A501SupplierGenEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenEmail");
                  GXUtil.WriteLogRaw("Old: ",Z501SupplierGenEmail);
                  GXUtil.WriteLogRaw("Current: ",T00062_A501SupplierGenEmail[0]);
               }
               if ( StringUtil.StrCmp(Z428SupplierGenWebsite, T00062_A428SupplierGenWebsite[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenWebsite");
                  GXUtil.WriteLogRaw("Old: ",Z428SupplierGenWebsite);
                  GXUtil.WriteLogRaw("Current: ",T00062_A428SupplierGenWebsite[0]);
               }
               if ( Z253SupplierGenTypeId != T00062_A253SupplierGenTypeId[0] )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenTypeId");
                  GXUtil.WriteLogRaw("Old: ",Z253SupplierGenTypeId);
                  GXUtil.WriteLogRaw("Current: ",T00062_A253SupplierGenTypeId[0]);
               }
               if ( Z601SG_OrganisationSupplierId != T00062_A601SG_OrganisationSupplierId[0] )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SG_OrganisationSupplierId");
                  GXUtil.WriteLogRaw("Old: ",Z601SG_OrganisationSupplierId);
                  GXUtil.WriteLogRaw("Current: ",T00062_A601SG_OrganisationSupplierId[0]);
               }
               if ( Z602SG_LocationSupplierOrganisatio != T00062_A602SG_LocationSupplierOrganisatio[0] )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SG_LocationSupplierOrganisatio");
                  GXUtil.WriteLogRaw("Old: ",Z602SG_LocationSupplierOrganisatio);
                  GXUtil.WriteLogRaw("Current: ",T00062_A602SG_LocationSupplierOrganisatio[0]);
               }
               if ( Z603SG_LocationSupplierLocationId != T00062_A603SG_LocationSupplierLocationId[0] )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SG_LocationSupplierLocationId");
                  GXUtil.WriteLogRaw("Old: ",Z603SG_LocationSupplierLocationId);
                  GXUtil.WriteLogRaw("Current: ",T00062_A603SG_LocationSupplierLocationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_SupplierGen"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert069( )
      {
         if ( ! IsAuthorized("trn_suppliergen_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate069( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable069( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM069( 0) ;
            CheckOptimisticConcurrency069( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm069( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert069( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000614 */
                     pr_default.execute(12, new Object[] {n42SupplierGenId, A42SupplierGenId, A309SupplierGenAddressCountry, A605SupplierGenLandlineCode, A353SupplierGenPhoneCode, A48SupplierGenContactPhone, A607SupplierGenLandlineNumber, A259SupplierGenAddressZipCode, A43SupplierGenKvkNumber, A44SupplierGenCompanyName, A260SupplierGenAddressCity, A310SupplierGenAddressLine1, A311SupplierGenAddressLine2, A47SupplierGenContactName, A354SupplierGenPhoneNumber, A606SupplierGenLandlineSubNumber, A501SupplierGenEmail, A428SupplierGenWebsite, A604SupplierGenDescription, A253SupplierGenTypeId, n601SG_OrganisationSupplierId, A601SG_OrganisationSupplierId, n602SG_LocationSupplierOrganisatio, A602SG_LocationSupplierOrganisatio, n603SG_LocationSupplierLocationId, A603SG_LocationSupplierLocationId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierGen");
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
               Load069( ) ;
            }
            EndLevel069( ) ;
         }
         CloseExtendedTableCursors069( ) ;
      }

      protected void Update069( )
      {
         if ( ! IsAuthorized("trn_suppliergen_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate069( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable069( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency069( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm069( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate069( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000615 */
                     pr_default.execute(13, new Object[] {A309SupplierGenAddressCountry, A605SupplierGenLandlineCode, A353SupplierGenPhoneCode, A48SupplierGenContactPhone, A607SupplierGenLandlineNumber, A259SupplierGenAddressZipCode, A43SupplierGenKvkNumber, A44SupplierGenCompanyName, A260SupplierGenAddressCity, A310SupplierGenAddressLine1, A311SupplierGenAddressLine2, A47SupplierGenContactName, A354SupplierGenPhoneNumber, A606SupplierGenLandlineSubNumber, A501SupplierGenEmail, A428SupplierGenWebsite, A604SupplierGenDescription, A253SupplierGenTypeId, n601SG_OrganisationSupplierId, A601SG_OrganisationSupplierId, n602SG_LocationSupplierOrganisatio, A602SG_LocationSupplierOrganisatio, n603SG_LocationSupplierLocationId, A603SG_LocationSupplierLocationId, n42SupplierGenId, A42SupplierGenId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierGen");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_SupplierGen"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate069( ) ;
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
            EndLevel069( ) ;
         }
         CloseExtendedTableCursors069( ) ;
      }

      protected void DeferredUpdate069( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_suppliergen_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate069( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency069( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls069( ) ;
            AfterConfirm069( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete069( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000616 */
                  pr_default.execute(14, new Object[] {n42SupplierGenId, A42SupplierGenId});
                  pr_default.close(14);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierGen");
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
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel069( ) ;
         Gx_mode = sMode9;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls069( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000617 */
            pr_default.execute(15, new Object[] {A253SupplierGenTypeId});
            A254SupplierGenTypeName = T000617_A254SupplierGenTypeName[0];
            pr_default.close(15);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000618 */
            pr_default.execute(16, new Object[] {n42SupplierGenId, A42SupplierGenId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Services", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T000619 */
            pr_default.execute(17, new Object[] {n42SupplierGenId, A42SupplierGenId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_SupplierDynamicForm", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
         }
      }

      protected void EndLevel069( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete069( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_suppliergen",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues060( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_suppliergen",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart069( )
      {
         /* Scan By routine */
         /* Using cursor T000620 */
         pr_default.execute(18);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound9 = 1;
            A42SupplierGenId = T000620_A42SupplierGenId[0];
            n42SupplierGenId = T000620_n42SupplierGenId[0];
            AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext069( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound9 = 1;
            A42SupplierGenId = T000620_A42SupplierGenId[0];
            n42SupplierGenId = T000620_n42SupplierGenId[0];
            AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
         }
      }

      protected void ScanEnd069( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm069( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert069( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate069( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete069( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete069( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate069( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes069( )
      {
         edtSupplierGenKvkNumber_Enabled = 0;
         AssignProp("", false, edtSupplierGenKvkNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenKvkNumber_Enabled), 5, 0), true);
         edtSupplierGenCompanyName_Enabled = 0;
         AssignProp("", false, edtSupplierGenCompanyName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenCompanyName_Enabled), 5, 0), true);
         edtSupplierGenTypeId_Enabled = 0;
         AssignProp("", false, edtSupplierGenTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenTypeId_Enabled), 5, 0), true);
         edtSupplierGenContactName_Enabled = 0;
         AssignProp("", false, edtSupplierGenContactName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenContactName_Enabled), 5, 0), true);
         edtSupplierGenPhoneCode_Enabled = 0;
         AssignProp("", false, edtSupplierGenPhoneCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenPhoneCode_Enabled), 5, 0), true);
         edtSupplierGenPhoneNumber_Enabled = 0;
         AssignProp("", false, edtSupplierGenPhoneNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenPhoneNumber_Enabled), 5, 0), true);
         edtSupplierGenLandlineCode_Enabled = 0;
         AssignProp("", false, edtSupplierGenLandlineCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenLandlineCode_Enabled), 5, 0), true);
         edtSupplierGenLandlineSubNumber_Enabled = 0;
         AssignProp("", false, edtSupplierGenLandlineSubNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenLandlineSubNumber_Enabled), 5, 0), true);
         edtSupplierGenContactPhone_Enabled = 0;
         AssignProp("", false, edtSupplierGenContactPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenContactPhone_Enabled), 5, 0), true);
         edtSupplierGenLandlineNumber_Enabled = 0;
         AssignProp("", false, edtSupplierGenLandlineNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenLandlineNumber_Enabled), 5, 0), true);
         edtSupplierGenEmail_Enabled = 0;
         AssignProp("", false, edtSupplierGenEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenEmail_Enabled), 5, 0), true);
         edtSupplierGenWebsite_Enabled = 0;
         AssignProp("", false, edtSupplierGenWebsite_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenWebsite_Enabled), 5, 0), true);
         edtSupplierGenAddressLine1_Enabled = 0;
         AssignProp("", false, edtSupplierGenAddressLine1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenAddressLine1_Enabled), 5, 0), true);
         edtSupplierGenAddressLine2_Enabled = 0;
         AssignProp("", false, edtSupplierGenAddressLine2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenAddressLine2_Enabled), 5, 0), true);
         edtSupplierGenAddressZipCode_Enabled = 0;
         AssignProp("", false, edtSupplierGenAddressZipCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenAddressZipCode_Enabled), 5, 0), true);
         edtSupplierGenAddressCity_Enabled = 0;
         AssignProp("", false, edtSupplierGenAddressCity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenAddressCity_Enabled), 5, 0), true);
         edtSupplierGenAddressCountry_Enabled = 0;
         AssignProp("", false, edtSupplierGenAddressCountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenAddressCountry_Enabled), 5, 0), true);
         edtavCombosuppliergentypeid_Enabled = 0;
         AssignProp("", false, edtavCombosuppliergentypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosuppliergentypeid_Enabled), 5, 0), true);
         edtavCombosuppliergenphonecode_Enabled = 0;
         AssignProp("", false, edtavCombosuppliergenphonecode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosuppliergenphonecode_Enabled), 5, 0), true);
         edtavCombosuppliergenlandlinecode_Enabled = 0;
         AssignProp("", false, edtavCombosuppliergenlandlinecode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosuppliergenlandlinecode_Enabled), 5, 0), true);
         edtavCombosuppliergenaddresscountry_Enabled = 0;
         AssignProp("", false, edtavCombosuppliergenaddresscountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosuppliergenaddresscountry_Enabled), 5, 0), true);
         edtSupplierGenId_Enabled = 0;
         AssignProp("", false, edtSupplierGenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenId_Enabled), 5, 0), true);
         Suppliergendescription_Enabled = Convert.ToBoolean( 0);
         AssignProp("", false, Suppliergendescription_Internalname, "Enabled", StringUtil.BoolToStr( Suppliergendescription_Enabled), true);
      }

      protected void send_integrity_lvl_hashes069( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues060( )
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
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
         GXEncryptionTmp = "trn_suppliergen.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7SupplierGenId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_suppliergen.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_SupplierGen");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_suppliergen:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z42SupplierGenId", Z42SupplierGenId.ToString());
         GxWebStd.gx_hidden_field( context, "Z309SupplierGenAddressCountry", Z309SupplierGenAddressCountry);
         GxWebStd.gx_hidden_field( context, "Z605SupplierGenLandlineCode", Z605SupplierGenLandlineCode);
         GxWebStd.gx_hidden_field( context, "Z353SupplierGenPhoneCode", Z353SupplierGenPhoneCode);
         GxWebStd.gx_hidden_field( context, "Z48SupplierGenContactPhone", StringUtil.RTrim( Z48SupplierGenContactPhone));
         GxWebStd.gx_hidden_field( context, "Z607SupplierGenLandlineNumber", Z607SupplierGenLandlineNumber);
         GxWebStd.gx_hidden_field( context, "Z259SupplierGenAddressZipCode", Z259SupplierGenAddressZipCode);
         GxWebStd.gx_hidden_field( context, "Z43SupplierGenKvkNumber", Z43SupplierGenKvkNumber);
         GxWebStd.gx_hidden_field( context, "Z44SupplierGenCompanyName", Z44SupplierGenCompanyName);
         GxWebStd.gx_hidden_field( context, "Z260SupplierGenAddressCity", Z260SupplierGenAddressCity);
         GxWebStd.gx_hidden_field( context, "Z310SupplierGenAddressLine1", Z310SupplierGenAddressLine1);
         GxWebStd.gx_hidden_field( context, "Z311SupplierGenAddressLine2", Z311SupplierGenAddressLine2);
         GxWebStd.gx_hidden_field( context, "Z47SupplierGenContactName", Z47SupplierGenContactName);
         GxWebStd.gx_hidden_field( context, "Z354SupplierGenPhoneNumber", Z354SupplierGenPhoneNumber);
         GxWebStd.gx_hidden_field( context, "Z606SupplierGenLandlineSubNumber", Z606SupplierGenLandlineSubNumber);
         GxWebStd.gx_hidden_field( context, "Z501SupplierGenEmail", Z501SupplierGenEmail);
         GxWebStd.gx_hidden_field( context, "Z428SupplierGenWebsite", Z428SupplierGenWebsite);
         GxWebStd.gx_hidden_field( context, "Z253SupplierGenTypeId", Z253SupplierGenTypeId.ToString());
         GxWebStd.gx_hidden_field( context, "Z601SG_OrganisationSupplierId", Z601SG_OrganisationSupplierId.ToString());
         GxWebStd.gx_hidden_field( context, "Z602SG_LocationSupplierOrganisatio", Z602SG_LocationSupplierOrganisatio.ToString());
         GxWebStd.gx_hidden_field( context, "Z603SG_LocationSupplierLocationId", Z603SG_LocationSupplierLocationId.ToString());
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N253SupplierGenTypeId", A253SupplierGenTypeId.ToString());
         GxWebStd.gx_hidden_field( context, "N601SG_OrganisationSupplierId", A601SG_OrganisationSupplierId.ToString());
         GxWebStd.gx_hidden_field( context, "N602SG_LocationSupplierOrganisatio", A602SG_LocationSupplierOrganisatio.ToString());
         GxWebStd.gx_hidden_field( context, "N603SG_LocationSupplierLocationId", A603SG_LocationSupplierLocationId.ToString());
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSUPPLIERGENTYPEID_DATA", AV15SupplierGenTypeId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSUPPLIERGENTYPEID_DATA", AV15SupplierGenTypeId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSUPPLIERGENPHONECODE_DATA", AV27SupplierGenPhoneCode_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSUPPLIERGENPHONECODE_DATA", AV27SupplierGenPhoneCode_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSUPPLIERGENLANDLINECODE_DATA", AV41SupplierGenLandlineCode_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSUPPLIERGENLANDLINECODE_DATA", AV41SupplierGenLandlineCode_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSUPPLIERGENADDRESSCOUNTRY_DATA", AV23SupplierGenAddressCountry_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSUPPLIERGENADDRESSCOUNTRY_DATA", AV23SupplierGenAddressCountry_Data);
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
         GxWebStd.gx_hidden_field( context, "vSUPPLIERGENID", AV7SupplierGenId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vSUPPLIERGENID", GetSecureSignedToken( "", AV7SupplierGenId, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_SUPPLIERGENTYPEID", AV13Insert_SupplierGenTypeId.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_SG_ORGANISATIONSUPPLIERID", AV34Insert_SG_OrganisationSupplierId.ToString());
         GxWebStd.gx_hidden_field( context, "vSG_ORGANISATIONSUPPLIERID", AV40SG_OrganisationSupplierId.ToString());
         GxWebStd.gx_hidden_field( context, "SG_ORGANISATIONSUPPLIERID", A601SG_OrganisationSupplierId.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_SG_LOCATIONSUPPLIERORGANISATIONID", AV35Insert_SG_LocationSupplierOrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "vSG_LOCATIONSUPPLIERORGANISATIONID", AV38SG_LocationSupplierOrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "SG_LOCATIONSUPPLIERORGANISATIO", A602SG_LocationSupplierOrganisatio.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_SG_LOCATIONSUPPLIERLOCATIONID", AV36Insert_SG_LocationSupplierLocationId.ToString());
         GxWebStd.gx_hidden_field( context, "vSG_LOCATIONSUPPLIERLOCATIONID", AV39SG_LocationSupplierLocationId.ToString());
         GxWebStd.gx_hidden_field( context, "SG_LOCATIONSUPPLIERLOCATIONID", A603SG_LocationSupplierLocationId.ToString());
         GxWebStd.gx_hidden_field( context, "SUPPLIERGENDESCRIPTION", A604SupplierGenDescription);
         GxWebStd.gx_hidden_field( context, "SUPPLIERGENTYPENAME", A254SupplierGenTypeName);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV43Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENTYPEID_Objectcall", StringUtil.RTrim( Combo_suppliergentypeid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENTYPEID_Cls", StringUtil.RTrim( Combo_suppliergentypeid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENTYPEID_Selectedvalue_set", StringUtil.RTrim( Combo_suppliergentypeid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENTYPEID_Enabled", StringUtil.BoolToStr( Combo_suppliergentypeid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENTYPEID_Emptyitem", StringUtil.BoolToStr( Combo_suppliergentypeid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENTYPEID_Includeaddnewoption", StringUtil.BoolToStr( Combo_suppliergentypeid_Includeaddnewoption));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENPHONECODE_Objectcall", StringUtil.RTrim( Combo_suppliergenphonecode_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENPHONECODE_Cls", StringUtil.RTrim( Combo_suppliergenphonecode_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENPHONECODE_Selectedvalue_set", StringUtil.RTrim( Combo_suppliergenphonecode_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENPHONECODE_Selectedtext_set", StringUtil.RTrim( Combo_suppliergenphonecode_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENPHONECODE_Enabled", StringUtil.BoolToStr( Combo_suppliergenphonecode_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENPHONECODE_Emptyitem", StringUtil.BoolToStr( Combo_suppliergenphonecode_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENPHONECODE_Htmltemplate", StringUtil.RTrim( Combo_suppliergenphonecode_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENLANDLINECODE_Objectcall", StringUtil.RTrim( Combo_suppliergenlandlinecode_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENLANDLINECODE_Cls", StringUtil.RTrim( Combo_suppliergenlandlinecode_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENLANDLINECODE_Selectedvalue_set", StringUtil.RTrim( Combo_suppliergenlandlinecode_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENLANDLINECODE_Selectedtext_set", StringUtil.RTrim( Combo_suppliergenlandlinecode_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENLANDLINECODE_Enabled", StringUtil.BoolToStr( Combo_suppliergenlandlinecode_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENLANDLINECODE_Emptyitem", StringUtil.BoolToStr( Combo_suppliergenlandlinecode_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENLANDLINECODE_Htmltemplate", StringUtil.RTrim( Combo_suppliergenlandlinecode_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "SUPPLIERGENDESCRIPTION_Objectcall", StringUtil.RTrim( Suppliergendescription_Objectcall));
         GxWebStd.gx_hidden_field( context, "SUPPLIERGENDESCRIPTION_Enabled", StringUtil.BoolToStr( Suppliergendescription_Enabled));
         GxWebStd.gx_hidden_field( context, "SUPPLIERGENDESCRIPTION_Width", StringUtil.RTrim( Suppliergendescription_Width));
         GxWebStd.gx_hidden_field( context, "SUPPLIERGENDESCRIPTION_Height", StringUtil.RTrim( Suppliergendescription_Height));
         GxWebStd.gx_hidden_field( context, "SUPPLIERGENDESCRIPTION_Skin", StringUtil.RTrim( Suppliergendescription_Skin));
         GxWebStd.gx_hidden_field( context, "SUPPLIERGENDESCRIPTION_Toolbar", StringUtil.RTrim( Suppliergendescription_Toolbar));
         GxWebStd.gx_hidden_field( context, "SUPPLIERGENDESCRIPTION_Customtoolbar", StringUtil.RTrim( Suppliergendescription_Customtoolbar));
         GxWebStd.gx_hidden_field( context, "SUPPLIERGENDESCRIPTION_Customconfiguration", StringUtil.RTrim( Suppliergendescription_Customconfiguration));
         GxWebStd.gx_hidden_field( context, "SUPPLIERGENDESCRIPTION_Toolbarcancollapse", StringUtil.BoolToStr( Suppliergendescription_Toolbarcancollapse));
         GxWebStd.gx_hidden_field( context, "SUPPLIERGENDESCRIPTION_Captionclass", StringUtil.RTrim( Suppliergendescription_Captionclass));
         GxWebStd.gx_hidden_field( context, "SUPPLIERGENDESCRIPTION_Captionstyle", StringUtil.RTrim( Suppliergendescription_Captionstyle));
         GxWebStd.gx_hidden_field( context, "SUPPLIERGENDESCRIPTION_Captionposition", StringUtil.RTrim( Suppliergendescription_Captionposition));
         GxWebStd.gx_hidden_field( context, "SUPPLIERGENDESCRIPTION_Visible", StringUtil.BoolToStr( Suppliergendescription_Visible));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENADDRESSCOUNTRY_Objectcall", StringUtil.RTrim( Combo_suppliergenaddresscountry_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENADDRESSCOUNTRY_Cls", StringUtil.RTrim( Combo_suppliergenaddresscountry_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENADDRESSCOUNTRY_Selectedvalue_set", StringUtil.RTrim( Combo_suppliergenaddresscountry_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENADDRESSCOUNTRY_Selectedtext_set", StringUtil.RTrim( Combo_suppliergenaddresscountry_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENADDRESSCOUNTRY_Enabled", StringUtil.BoolToStr( Combo_suppliergenaddresscountry_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENADDRESSCOUNTRY_Emptyitem", StringUtil.BoolToStr( Combo_suppliergenaddresscountry_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENADDRESSCOUNTRY_Htmltemplate", StringUtil.RTrim( Combo_suppliergenaddresscountry_Htmltemplate));
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
         GXEncryptionTmp = "trn_suppliergen.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7SupplierGenId.ToString());
         return formatLink("trn_suppliergen.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Trn_SupplierGen" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Suppliers", "") ;
      }

      protected void InitializeNonKey069( )
      {
         A253SupplierGenTypeId = Guid.Empty;
         AssignAttri("", false, "A253SupplierGenTypeId", A253SupplierGenTypeId.ToString());
         A601SG_OrganisationSupplierId = Guid.Empty;
         n601SG_OrganisationSupplierId = false;
         AssignAttri("", false, "A601SG_OrganisationSupplierId", A601SG_OrganisationSupplierId.ToString());
         A602SG_LocationSupplierOrganisatio = Guid.Empty;
         n602SG_LocationSupplierOrganisatio = false;
         AssignAttri("", false, "A602SG_LocationSupplierOrganisatio", A602SG_LocationSupplierOrganisatio.ToString());
         A603SG_LocationSupplierLocationId = Guid.Empty;
         n603SG_LocationSupplierLocationId = false;
         AssignAttri("", false, "A603SG_LocationSupplierLocationId", A603SG_LocationSupplierLocationId.ToString());
         A309SupplierGenAddressCountry = "";
         AssignAttri("", false, "A309SupplierGenAddressCountry", A309SupplierGenAddressCountry);
         A605SupplierGenLandlineCode = "";
         AssignAttri("", false, "A605SupplierGenLandlineCode", A605SupplierGenLandlineCode);
         A353SupplierGenPhoneCode = "";
         AssignAttri("", false, "A353SupplierGenPhoneCode", A353SupplierGenPhoneCode);
         A48SupplierGenContactPhone = "";
         AssignAttri("", false, "A48SupplierGenContactPhone", A48SupplierGenContactPhone);
         A607SupplierGenLandlineNumber = "";
         AssignAttri("", false, "A607SupplierGenLandlineNumber", A607SupplierGenLandlineNumber);
         A259SupplierGenAddressZipCode = "";
         AssignAttri("", false, "A259SupplierGenAddressZipCode", A259SupplierGenAddressZipCode);
         A43SupplierGenKvkNumber = "";
         AssignAttri("", false, "A43SupplierGenKvkNumber", A43SupplierGenKvkNumber);
         A254SupplierGenTypeName = "";
         AssignAttri("", false, "A254SupplierGenTypeName", A254SupplierGenTypeName);
         A44SupplierGenCompanyName = "";
         AssignAttri("", false, "A44SupplierGenCompanyName", A44SupplierGenCompanyName);
         A260SupplierGenAddressCity = "";
         AssignAttri("", false, "A260SupplierGenAddressCity", A260SupplierGenAddressCity);
         A310SupplierGenAddressLine1 = "";
         AssignAttri("", false, "A310SupplierGenAddressLine1", A310SupplierGenAddressLine1);
         A311SupplierGenAddressLine2 = "";
         AssignAttri("", false, "A311SupplierGenAddressLine2", A311SupplierGenAddressLine2);
         A47SupplierGenContactName = "";
         AssignAttri("", false, "A47SupplierGenContactName", A47SupplierGenContactName);
         A354SupplierGenPhoneNumber = "";
         AssignAttri("", false, "A354SupplierGenPhoneNumber", A354SupplierGenPhoneNumber);
         A606SupplierGenLandlineSubNumber = "";
         AssignAttri("", false, "A606SupplierGenLandlineSubNumber", A606SupplierGenLandlineSubNumber);
         A501SupplierGenEmail = "";
         AssignAttri("", false, "A501SupplierGenEmail", A501SupplierGenEmail);
         A428SupplierGenWebsite = "";
         AssignAttri("", false, "A428SupplierGenWebsite", A428SupplierGenWebsite);
         A604SupplierGenDescription = "";
         AssignAttri("", false, "A604SupplierGenDescription", A604SupplierGenDescription);
         Z309SupplierGenAddressCountry = "";
         Z605SupplierGenLandlineCode = "";
         Z353SupplierGenPhoneCode = "";
         Z48SupplierGenContactPhone = "";
         Z607SupplierGenLandlineNumber = "";
         Z259SupplierGenAddressZipCode = "";
         Z43SupplierGenKvkNumber = "";
         Z44SupplierGenCompanyName = "";
         Z260SupplierGenAddressCity = "";
         Z310SupplierGenAddressLine1 = "";
         Z311SupplierGenAddressLine2 = "";
         Z47SupplierGenContactName = "";
         Z354SupplierGenPhoneNumber = "";
         Z606SupplierGenLandlineSubNumber = "";
         Z501SupplierGenEmail = "";
         Z428SupplierGenWebsite = "";
         Z253SupplierGenTypeId = Guid.Empty;
         Z601SG_OrganisationSupplierId = Guid.Empty;
         Z602SG_LocationSupplierOrganisatio = Guid.Empty;
         Z603SG_LocationSupplierLocationId = Guid.Empty;
      }

      protected void InitAll069( )
      {
         A42SupplierGenId = Guid.NewGuid( );
         n42SupplierGenId = false;
         AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
         InitializeNonKey069( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A603SG_LocationSupplierLocationId = i603SG_LocationSupplierLocationId;
         n603SG_LocationSupplierLocationId = false;
         AssignAttri("", false, "A603SG_LocationSupplierLocationId", A603SG_LocationSupplierLocationId.ToString());
         A602SG_LocationSupplierOrganisatio = i602SG_LocationSupplierOrganisatio;
         n602SG_LocationSupplierOrganisatio = false;
         AssignAttri("", false, "A602SG_LocationSupplierOrganisatio", A602SG_LocationSupplierOrganisatio.ToString());
         A601SG_OrganisationSupplierId = i601SG_OrganisationSupplierId;
         n601SG_OrganisationSupplierId = false;
         AssignAttri("", false, "A601SG_OrganisationSupplierId", A601SG_OrganisationSupplierId.ToString());
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256147114374", true, true);
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
         context.AddJavascriptSource("trn_suppliergen.js", "?20256147114377", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtSupplierGenKvkNumber_Internalname = "SUPPLIERGENKVKNUMBER";
         edtSupplierGenCompanyName_Internalname = "SUPPLIERGENCOMPANYNAME";
         lblTextblocksuppliergentypeid_Internalname = "TEXTBLOCKSUPPLIERGENTYPEID";
         Combo_suppliergentypeid_Internalname = "COMBO_SUPPLIERGENTYPEID";
         edtSupplierGenTypeId_Internalname = "SUPPLIERGENTYPEID";
         divTablesplittedsuppliergentypeid_Internalname = "TABLESPLITTEDSUPPLIERGENTYPEID";
         edtSupplierGenContactName_Internalname = "SUPPLIERGENCONTACTNAME";
         lblPhonelabel_Internalname = "PHONELABEL";
         Combo_suppliergenphonecode_Internalname = "COMBO_SUPPLIERGENPHONECODE";
         edtSupplierGenPhoneCode_Internalname = "SUPPLIERGENPHONECODE";
         divUnnamedtablesuppliergenphonecode_Internalname = "UNNAMEDTABLESUPPLIERGENPHONECODE";
         divUnnamedtable11_Internalname = "UNNAMEDTABLE11";
         edtSupplierGenPhoneNumber_Internalname = "SUPPLIERGENPHONENUMBER";
         divUnnamedtable10_Internalname = "UNNAMEDTABLE10";
         divUnnamedtable5_Internalname = "UNNAMEDTABLE5";
         lblPhonelabellandline_Internalname = "PHONELABELLANDLINE";
         Combo_suppliergenlandlinecode_Internalname = "COMBO_SUPPLIERGENLANDLINECODE";
         edtSupplierGenLandlineCode_Internalname = "SUPPLIERGENLANDLINECODE";
         divUnnamedtablesuppliergenlandlinecode_Internalname = "UNNAMEDTABLESUPPLIERGENLANDLINECODE";
         divUnnamedtable9_Internalname = "UNNAMEDTABLE9";
         edtSupplierGenLandlineSubNumber_Internalname = "SUPPLIERGENLANDLINESUBNUMBER";
         divUnnamedtable8_Internalname = "UNNAMEDTABLE8";
         divUnnamedtable6_Internalname = "UNNAMEDTABLE6";
         edtSupplierGenContactPhone_Internalname = "SUPPLIERGENCONTACTPHONE";
         divSuppliergencontactphone_cell_Internalname = "SUPPLIERGENCONTACTPHONE_CELL";
         edtSupplierGenLandlineNumber_Internalname = "SUPPLIERGENLANDLINENUMBER";
         divSuppliergenlandlinenumber_cell_Internalname = "SUPPLIERGENLANDLINENUMBER_CELL";
         edtSupplierGenEmail_Internalname = "SUPPLIERGENEMAIL";
         edtSupplierGenWebsite_Internalname = "SUPPLIERGENWEBSITE";
         Suppliergendescription_Internalname = "SUPPLIERGENDESCRIPTION";
         divSuppliergendescription_cell_Internalname = "SUPPLIERGENDESCRIPTION_CELL";
         lblTextblockdescriptionlabel_Internalname = "TEXTBLOCKDESCRIPTIONLABEL";
         lblDescriptiontext_Internalname = "DESCRIPTIONTEXT";
         divUnnamedtable7_Internalname = "UNNAMEDTABLE7";
         divDescriptiontable_Internalname = "DESCRIPTIONTABLE";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         grpUnnamedgroup2_Internalname = "UNNAMEDGROUP2";
         edtSupplierGenAddressLine1_Internalname = "SUPPLIERGENADDRESSLINE1";
         edtSupplierGenAddressLine2_Internalname = "SUPPLIERGENADDRESSLINE2";
         edtSupplierGenAddressZipCode_Internalname = "SUPPLIERGENADDRESSZIPCODE";
         edtSupplierGenAddressCity_Internalname = "SUPPLIERGENADDRESSCITY";
         lblTextblocksuppliergenaddresscountry_Internalname = "TEXTBLOCKSUPPLIERGENADDRESSCOUNTRY";
         Combo_suppliergenaddresscountry_Internalname = "COMBO_SUPPLIERGENADDRESSCOUNTRY";
         edtSupplierGenAddressCountry_Internalname = "SUPPLIERGENADDRESSCOUNTRY";
         divTablesplittedsuppliergenaddresscountry_Internalname = "TABLESPLITTEDSUPPLIERGENADDRESSCOUNTRY";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         grpUnnamedgroup4_Internalname = "UNNAMEDGROUP4";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombosuppliergentypeid_Internalname = "vCOMBOSUPPLIERGENTYPEID";
         divSectionattribute_suppliergentypeid_Internalname = "SECTIONATTRIBUTE_SUPPLIERGENTYPEID";
         edtavCombosuppliergenphonecode_Internalname = "vCOMBOSUPPLIERGENPHONECODE";
         divSectionattribute_suppliergenphonecode_Internalname = "SECTIONATTRIBUTE_SUPPLIERGENPHONECODE";
         edtavCombosuppliergenlandlinecode_Internalname = "vCOMBOSUPPLIERGENLANDLINECODE";
         divSectionattribute_suppliergenlandlinecode_Internalname = "SECTIONATTRIBUTE_SUPPLIERGENLANDLINECODE";
         edtavCombosuppliergenaddresscountry_Internalname = "vCOMBOSUPPLIERGENADDRESSCOUNTRY";
         divSectionattribute_suppliergenaddresscountry_Internalname = "SECTIONATTRIBUTE_SUPPLIERGENADDRESSCOUNTRY";
         edtSupplierGenId_Internalname = "SUPPLIERGENID";
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
         Form.Caption = context.GetMessage( "Suppliers", "");
         Suppliergendescription_Visible = Convert.ToBoolean( -1);
         Combo_suppliergenphonecode_Htmltemplate = "";
         Combo_suppliergenlandlinecode_Htmltemplate = "";
         Combo_suppliergenaddresscountry_Htmltemplate = "";
         edtSupplierGenId_Jsonclick = "";
         edtSupplierGenId_Enabled = 1;
         edtSupplierGenId_Visible = 1;
         edtavCombosuppliergenaddresscountry_Jsonclick = "";
         edtavCombosuppliergenaddresscountry_Enabled = 0;
         edtavCombosuppliergenaddresscountry_Visible = 1;
         edtavCombosuppliergenlandlinecode_Jsonclick = "";
         edtavCombosuppliergenlandlinecode_Enabled = 0;
         edtavCombosuppliergenlandlinecode_Visible = 1;
         edtavCombosuppliergenphonecode_Jsonclick = "";
         edtavCombosuppliergenphonecode_Enabled = 0;
         edtavCombosuppliergenphonecode_Visible = 1;
         edtavCombosuppliergentypeid_Jsonclick = "";
         edtavCombosuppliergentypeid_Enabled = 0;
         edtavCombosuppliergentypeid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtSupplierGenAddressCountry_Jsonclick = "";
         edtSupplierGenAddressCountry_Enabled = 1;
         edtSupplierGenAddressCountry_Visible = 1;
         Combo_suppliergenaddresscountry_Emptyitem = Convert.ToBoolean( 0);
         Combo_suppliergenaddresscountry_Cls = "ExtendedCombo Attribute ExtendedComboWithImage";
         Combo_suppliergenaddresscountry_Caption = "";
         Combo_suppliergenaddresscountry_Enabled = Convert.ToBoolean( -1);
         edtSupplierGenAddressCity_Jsonclick = "";
         edtSupplierGenAddressCity_Enabled = 1;
         edtSupplierGenAddressZipCode_Jsonclick = "";
         edtSupplierGenAddressZipCode_Enabled = 1;
         edtSupplierGenAddressLine2_Jsonclick = "";
         edtSupplierGenAddressLine2_Enabled = 1;
         edtSupplierGenAddressLine1_Jsonclick = "";
         edtSupplierGenAddressLine1_Enabled = 1;
         divDescriptiontable_Visible = 1;
         Suppliergendescription_Captionposition = "Left";
         Suppliergendescription_Captionstyle = "";
         Suppliergendescription_Captionclass = "col-sm-4 AttributeLabel";
         Suppliergendescription_Toolbarcancollapse = Convert.ToBoolean( -1);
         Suppliergendescription_Customconfiguration = "myconfig.js";
         Suppliergendescription_Customtoolbar = "myToolbar";
         Suppliergendescription_Toolbar = "Custom";
         Suppliergendescription_Skin = "default";
         Suppliergendescription_Height = "250";
         Suppliergendescription_Width = "100%";
         Suppliergendescription_Enabled = Convert.ToBoolean( 1);
         divSuppliergendescription_cell_Class = "col-xs-12";
         edtSupplierGenWebsite_Jsonclick = "";
         edtSupplierGenWebsite_Enabled = 1;
         edtSupplierGenEmail_Jsonclick = "";
         edtSupplierGenEmail_Enabled = 1;
         edtSupplierGenLandlineNumber_Jsonclick = "";
         edtSupplierGenLandlineNumber_Enabled = 1;
         edtSupplierGenLandlineNumber_Visible = 1;
         divSuppliergenlandlinenumber_cell_Class = "col-xs-12";
         edtSupplierGenContactPhone_Jsonclick = "";
         edtSupplierGenContactPhone_Enabled = 1;
         edtSupplierGenContactPhone_Visible = 1;
         divSuppliergencontactphone_cell_Class = "col-xs-12";
         edtSupplierGenLandlineSubNumber_Jsonclick = "";
         edtSupplierGenLandlineSubNumber_Enabled = 1;
         edtSupplierGenLandlineCode_Jsonclick = "";
         edtSupplierGenLandlineCode_Enabled = 1;
         edtSupplierGenLandlineCode_Visible = 1;
         Combo_suppliergenlandlinecode_Emptyitem = Convert.ToBoolean( 0);
         Combo_suppliergenlandlinecode_Cls = "ExtendedCombo DropDownComponent ExtendedComboWithImage";
         Combo_suppliergenlandlinecode_Caption = "";
         Combo_suppliergenlandlinecode_Enabled = Convert.ToBoolean( -1);
         divUnnamedtable6_Visible = 1;
         edtSupplierGenPhoneNumber_Jsonclick = "";
         edtSupplierGenPhoneNumber_Class = "Attribute";
         edtSupplierGenPhoneNumber_Enabled = 1;
         edtSupplierGenPhoneCode_Jsonclick = "";
         edtSupplierGenPhoneCode_Enabled = 1;
         edtSupplierGenPhoneCode_Visible = 1;
         Combo_suppliergenphonecode_Emptyitem = Convert.ToBoolean( 0);
         Combo_suppliergenphonecode_Cls = "ExtendedCombo DropDownComponent ExtendedComboWithImage";
         Combo_suppliergenphonecode_Caption = "";
         Combo_suppliergenphonecode_Enabled = Convert.ToBoolean( -1);
         divUnnamedtable5_Visible = 1;
         edtSupplierGenContactName_Jsonclick = "";
         edtSupplierGenContactName_Enabled = 1;
         edtSupplierGenTypeId_Jsonclick = "";
         edtSupplierGenTypeId_Enabled = 1;
         edtSupplierGenTypeId_Visible = 1;
         Combo_suppliergentypeid_Includeaddnewoption = Convert.ToBoolean( -1);
         Combo_suppliergentypeid_Emptyitem = Convert.ToBoolean( 0);
         Combo_suppliergentypeid_Cls = "ExtendedCombo Attribute";
         Combo_suppliergentypeid_Enabled = Convert.ToBoolean( -1);
         edtSupplierGenCompanyName_Jsonclick = "";
         edtSupplierGenCompanyName_Enabled = 1;
         edtSupplierGenKvkNumber_Jsonclick = "";
         edtSupplierGenKvkNumber_Enabled = 1;
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

      protected void GX26ASASUPPLIERGENCONTACTPHONE069( string A353SupplierGenPhoneCode ,
                                                        string A354SupplierGenPhoneNumber )
      {
         GXt_char2 = A48SupplierGenContactPhone;
         new prc_concatenateintlphone(context ).execute(  A353SupplierGenPhoneCode,  A354SupplierGenPhoneNumber, out  GXt_char2) ;
         A48SupplierGenContactPhone = GXt_char2;
         AssignAttri("", false, "A48SupplierGenContactPhone", A48SupplierGenContactPhone);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A48SupplierGenContactPhone))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX27ASASUPPLIERGENLANDLINENUMBER069( string A605SupplierGenLandlineCode ,
                                                          string A606SupplierGenLandlineSubNumber )
      {
         GXt_char2 = A607SupplierGenLandlineNumber;
         new prc_concatenateintlphone(context ).execute(  A605SupplierGenLandlineCode,  A606SupplierGenLandlineSubNumber, out  GXt_char2) ;
         A607SupplierGenLandlineNumber = GXt_char2;
         AssignAttri("", false, "A607SupplierGenLandlineNumber", A607SupplierGenLandlineNumber);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A607SupplierGenLandlineNumber)+"\"") ;
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

      public void Valid_Suppliergentypeid( )
      {
         /* Using cursor T000617 */
         pr_default.execute(15, new Object[] {A253SupplierGenTypeId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "General Supplier Types", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SUPPLIERGENTYPEID");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenTypeId_Internalname;
         }
         A254SupplierGenTypeName = T000617_A254SupplierGenTypeName[0];
         pr_default.close(15);
         if ( (Guid.Empty==A253SupplierGenTypeId) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Category", ""), "", "", "", "", "", "", "", ""), 1, "SUPPLIERGENTYPEID");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenTypeId_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A254SupplierGenTypeName", A254SupplierGenTypeName);
      }

      public void Valid_Suppliergenphonenumber( )
      {
         GXt_char2 = A48SupplierGenContactPhone;
         new prc_concatenateintlphone(context ).execute(  A353SupplierGenPhoneCode,  A354SupplierGenPhoneNumber, out  GXt_char2) ;
         A48SupplierGenContactPhone = GXt_char2;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A354SupplierGenPhoneNumber)) && ! GxRegex.IsMatch(A354SupplierGenPhoneNumber,context.GetMessage( "^\\d{9}$", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Phone should contain 9 digits", ""), 1, "SUPPLIERGENPHONENUMBER");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenPhoneNumber_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A48SupplierGenContactPhone", StringUtil.RTrim( A48SupplierGenContactPhone));
      }

      public void Valid_Suppliergenlandlinesubnumber( )
      {
         GXt_char2 = A607SupplierGenLandlineNumber;
         new prc_concatenateintlphone(context ).execute(  A605SupplierGenLandlineCode,  A606SupplierGenLandlineSubNumber, out  GXt_char2) ;
         A607SupplierGenLandlineNumber = GXt_char2;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A607SupplierGenLandlineNumber", A607SupplierGenLandlineNumber);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7SupplierGenId","fld":"vSUPPLIERGENID","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7SupplierGenId","fld":"vSUPPLIERGENID","hsh":true}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E13062","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("COMBO_SUPPLIERGENTYPEID.ONOPTIONCLICKED","""{"handler":"E12062","iparms":[{"av":"Combo_suppliergentypeid_Selectedvalue_get","ctrl":"COMBO_SUPPLIERGENTYPEID","prop":"SelectedValue_get"},{"av":"Combo_suppliergentypeid_Selectedtext_get","ctrl":"COMBO_SUPPLIERGENTYPEID","prop":"SelectedText_get"},{"av":"A253SupplierGenTypeId","fld":"SUPPLIERGENTYPEID"},{"av":"AV7SupplierGenId","fld":"vSUPPLIERGENID","hsh":true}]""");
         setEventMetadata("COMBO_SUPPLIERGENTYPEID.ONOPTIONCLICKED",""","oparms":[{"av":"Combo_suppliergentypeid_Selectedvalue_set","ctrl":"COMBO_SUPPLIERGENTYPEID","prop":"SelectedValue_set"},{"av":"AV15SupplierGenTypeId_Data","fld":"vSUPPLIERGENTYPEID_DATA"},{"av":"AV20ComboSupplierGenTypeId","fld":"vCOMBOSUPPLIERGENTYPEID"}]}""");
         setEventMetadata("VALID_SUPPLIERGENKVKNUMBER","""{"handler":"Valid_Suppliergenkvknumber","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIERGENCOMPANYNAME","""{"handler":"Valid_Suppliergencompanyname","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIERGENTYPEID","""{"handler":"Valid_Suppliergentypeid","iparms":[{"av":"A253SupplierGenTypeId","fld":"SUPPLIERGENTYPEID"},{"av":"A254SupplierGenTypeName","fld":"SUPPLIERGENTYPENAME"}]""");
         setEventMetadata("VALID_SUPPLIERGENTYPEID",""","oparms":[{"av":"A254SupplierGenTypeName","fld":"SUPPLIERGENTYPENAME"}]}""");
         setEventMetadata("VALID_SUPPLIERGENPHONECODE","""{"handler":"Valid_Suppliergenphonecode","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIERGENPHONENUMBER","""{"handler":"Valid_Suppliergenphonenumber","iparms":[{"av":"A353SupplierGenPhoneCode","fld":"SUPPLIERGENPHONECODE"},{"av":"A354SupplierGenPhoneNumber","fld":"SUPPLIERGENPHONENUMBER"},{"av":"A48SupplierGenContactPhone","fld":"SUPPLIERGENCONTACTPHONE"}]""");
         setEventMetadata("VALID_SUPPLIERGENPHONENUMBER",""","oparms":[{"av":"A48SupplierGenContactPhone","fld":"SUPPLIERGENCONTACTPHONE"}]}""");
         setEventMetadata("VALID_SUPPLIERGENLANDLINECODE","""{"handler":"Valid_Suppliergenlandlinecode","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIERGENLANDLINESUBNUMBER","""{"handler":"Valid_Suppliergenlandlinesubnumber","iparms":[{"av":"A605SupplierGenLandlineCode","fld":"SUPPLIERGENLANDLINECODE"},{"av":"A606SupplierGenLandlineSubNumber","fld":"SUPPLIERGENLANDLINESUBNUMBER"},{"av":"A607SupplierGenLandlineNumber","fld":"SUPPLIERGENLANDLINENUMBER"}]""");
         setEventMetadata("VALID_SUPPLIERGENLANDLINESUBNUMBER",""","oparms":[{"av":"A607SupplierGenLandlineNumber","fld":"SUPPLIERGENLANDLINENUMBER"}]}""");
         setEventMetadata("VALID_SUPPLIERGENEMAIL","""{"handler":"Valid_Suppliergenemail","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIERGENWEBSITE","""{"handler":"Valid_Suppliergenwebsite","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIERGENADDRESSLINE1","""{"handler":"Valid_Suppliergenaddressline1","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIERGENADDRESSZIPCODE","""{"handler":"Valid_Suppliergenaddresszipcode","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIERGENADDRESSCITY","""{"handler":"Valid_Suppliergenaddresscity","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIERGENADDRESSCOUNTRY","""{"handler":"Valid_Suppliergenaddresscountry","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOSUPPLIERGENTYPEID","""{"handler":"Validv_Combosuppliergentypeid","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOSUPPLIERGENPHONECODE","""{"handler":"Validv_Combosuppliergenphonecode","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOSUPPLIERGENLANDLINECODE","""{"handler":"Validv_Combosuppliergenlandlinecode","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOSUPPLIERGENADDRESSCOUNTRY","""{"handler":"Validv_Combosuppliergenaddresscountry","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIERGENID","""{"handler":"Valid_Suppliergenid","iparms":[]}""");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7SupplierGenId = Guid.Empty;
         Z42SupplierGenId = Guid.Empty;
         Z309SupplierGenAddressCountry = "";
         Z605SupplierGenLandlineCode = "";
         Z353SupplierGenPhoneCode = "";
         Z48SupplierGenContactPhone = "";
         Z607SupplierGenLandlineNumber = "";
         Z259SupplierGenAddressZipCode = "";
         Z43SupplierGenKvkNumber = "";
         Z44SupplierGenCompanyName = "";
         Z260SupplierGenAddressCity = "";
         Z310SupplierGenAddressLine1 = "";
         Z311SupplierGenAddressLine2 = "";
         Z47SupplierGenContactName = "";
         Z354SupplierGenPhoneNumber = "";
         Z606SupplierGenLandlineSubNumber = "";
         Z501SupplierGenEmail = "";
         Z428SupplierGenWebsite = "";
         Z253SupplierGenTypeId = Guid.Empty;
         Z601SG_OrganisationSupplierId = Guid.Empty;
         Z602SG_LocationSupplierOrganisatio = Guid.Empty;
         Z603SG_LocationSupplierLocationId = Guid.Empty;
         N253SupplierGenTypeId = Guid.Empty;
         N601SG_OrganisationSupplierId = Guid.Empty;
         N602SG_LocationSupplierOrganisatio = Guid.Empty;
         N603SG_LocationSupplierLocationId = Guid.Empty;
         Combo_suppliergenaddresscountry_Selectedvalue_get = "";
         Combo_suppliergenlandlinecode_Selectedvalue_get = "";
         Combo_suppliergenphonecode_Selectedvalue_get = "";
         Combo_suppliergentypeid_Selectedvalue_get = "";
         Combo_suppliergentypeid_Selectedtext_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A353SupplierGenPhoneCode = "";
         A354SupplierGenPhoneNumber = "";
         A605SupplierGenLandlineCode = "";
         A606SupplierGenLandlineSubNumber = "";
         A253SupplierGenTypeId = Guid.Empty;
         A601SG_OrganisationSupplierId = Guid.Empty;
         A603SG_LocationSupplierLocationId = Guid.Empty;
         A602SG_LocationSupplierOrganisatio = Guid.Empty;
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A43SupplierGenKvkNumber = "";
         A44SupplierGenCompanyName = "";
         lblTextblocksuppliergentypeid_Jsonclick = "";
         ucCombo_suppliergentypeid = new GXUserControl();
         Combo_suppliergentypeid_Caption = "";
         AV15SupplierGenTypeId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A47SupplierGenContactName = "";
         lblPhonelabel_Jsonclick = "";
         ucCombo_suppliergenphonecode = new GXUserControl();
         AV16DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV27SupplierGenPhoneCode_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblPhonelabellandline_Jsonclick = "";
         ucCombo_suppliergenlandlinecode = new GXUserControl();
         AV41SupplierGenLandlineCode_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         gxphoneLink = "";
         A48SupplierGenContactPhone = "";
         A607SupplierGenLandlineNumber = "";
         A501SupplierGenEmail = "";
         A428SupplierGenWebsite = "";
         ucSuppliergendescription = new GXUserControl();
         SupplierGenDescription = "";
         lblTextblockdescriptionlabel_Jsonclick = "";
         lblDescriptiontext_Jsonclick = "";
         A310SupplierGenAddressLine1 = "";
         A311SupplierGenAddressLine2 = "";
         A259SupplierGenAddressZipCode = "";
         A260SupplierGenAddressCity = "";
         lblTextblocksuppliergenaddresscountry_Jsonclick = "";
         ucCombo_suppliergenaddresscountry = new GXUserControl();
         AV23SupplierGenAddressCountry_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A309SupplierGenAddressCountry = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV20ComboSupplierGenTypeId = Guid.Empty;
         AV25ComboSupplierGenPhoneCode = "";
         AV42ComboSupplierGenLandlineCode = "";
         AV24ComboSupplierGenAddressCountry = "";
         A42SupplierGenId = Guid.Empty;
         AV13Insert_SupplierGenTypeId = Guid.Empty;
         AV34Insert_SG_OrganisationSupplierId = Guid.Empty;
         AV40SG_OrganisationSupplierId = Guid.Empty;
         AV35Insert_SG_LocationSupplierOrganisationId = Guid.Empty;
         AV38SG_LocationSupplierOrganisationId = Guid.Empty;
         AV36Insert_SG_LocationSupplierLocationId = Guid.Empty;
         AV39SG_LocationSupplierLocationId = Guid.Empty;
         A604SupplierGenDescription = "";
         A254SupplierGenTypeName = "";
         AV43Pgmname = "";
         Combo_suppliergentypeid_Objectcall = "";
         Combo_suppliergentypeid_Class = "";
         Combo_suppliergentypeid_Icontype = "";
         Combo_suppliergentypeid_Icon = "";
         Combo_suppliergentypeid_Tooltip = "";
         Combo_suppliergentypeid_Selectedvalue_set = "";
         Combo_suppliergentypeid_Selectedtext_set = "";
         Combo_suppliergentypeid_Gamoauthtoken = "";
         Combo_suppliergentypeid_Ddointernalname = "";
         Combo_suppliergentypeid_Titlecontrolalign = "";
         Combo_suppliergentypeid_Dropdownoptionstype = "";
         Combo_suppliergentypeid_Titlecontrolidtoreplace = "";
         Combo_suppliergentypeid_Datalisttype = "";
         Combo_suppliergentypeid_Datalistfixedvalues = "";
         Combo_suppliergentypeid_Datalistproc = "";
         Combo_suppliergentypeid_Datalistprocparametersprefix = "";
         Combo_suppliergentypeid_Remoteservicesparameters = "";
         Combo_suppliergentypeid_Htmltemplate = "";
         Combo_suppliergentypeid_Multiplevaluestype = "";
         Combo_suppliergentypeid_Loadingdata = "";
         Combo_suppliergentypeid_Noresultsfound = "";
         Combo_suppliergentypeid_Emptyitemtext = "";
         Combo_suppliergentypeid_Onlyselectedvalues = "";
         Combo_suppliergentypeid_Selectalltext = "";
         Combo_suppliergentypeid_Multiplevaluesseparator = "";
         Combo_suppliergentypeid_Addnewoptiontext = "";
         Combo_suppliergenphonecode_Objectcall = "";
         Combo_suppliergenphonecode_Class = "";
         Combo_suppliergenphonecode_Icontype = "";
         Combo_suppliergenphonecode_Icon = "";
         Combo_suppliergenphonecode_Tooltip = "";
         Combo_suppliergenphonecode_Selectedvalue_set = "";
         Combo_suppliergenphonecode_Selectedtext_set = "";
         Combo_suppliergenphonecode_Selectedtext_get = "";
         Combo_suppliergenphonecode_Gamoauthtoken = "";
         Combo_suppliergenphonecode_Ddointernalname = "";
         Combo_suppliergenphonecode_Titlecontrolalign = "";
         Combo_suppliergenphonecode_Dropdownoptionstype = "";
         Combo_suppliergenphonecode_Titlecontrolidtoreplace = "";
         Combo_suppliergenphonecode_Datalisttype = "";
         Combo_suppliergenphonecode_Datalistfixedvalues = "";
         Combo_suppliergenphonecode_Datalistproc = "";
         Combo_suppliergenphonecode_Datalistprocparametersprefix = "";
         Combo_suppliergenphonecode_Remoteservicesparameters = "";
         Combo_suppliergenphonecode_Multiplevaluestype = "";
         Combo_suppliergenphonecode_Loadingdata = "";
         Combo_suppliergenphonecode_Noresultsfound = "";
         Combo_suppliergenphonecode_Emptyitemtext = "";
         Combo_suppliergenphonecode_Onlyselectedvalues = "";
         Combo_suppliergenphonecode_Selectalltext = "";
         Combo_suppliergenphonecode_Multiplevaluesseparator = "";
         Combo_suppliergenphonecode_Addnewoptiontext = "";
         Combo_suppliergenlandlinecode_Objectcall = "";
         Combo_suppliergenlandlinecode_Class = "";
         Combo_suppliergenlandlinecode_Icontype = "";
         Combo_suppliergenlandlinecode_Icon = "";
         Combo_suppliergenlandlinecode_Tooltip = "";
         Combo_suppliergenlandlinecode_Selectedvalue_set = "";
         Combo_suppliergenlandlinecode_Selectedtext_set = "";
         Combo_suppliergenlandlinecode_Selectedtext_get = "";
         Combo_suppliergenlandlinecode_Gamoauthtoken = "";
         Combo_suppliergenlandlinecode_Ddointernalname = "";
         Combo_suppliergenlandlinecode_Titlecontrolalign = "";
         Combo_suppliergenlandlinecode_Dropdownoptionstype = "";
         Combo_suppliergenlandlinecode_Titlecontrolidtoreplace = "";
         Combo_suppliergenlandlinecode_Datalisttype = "";
         Combo_suppliergenlandlinecode_Datalistfixedvalues = "";
         Combo_suppliergenlandlinecode_Datalistproc = "";
         Combo_suppliergenlandlinecode_Datalistprocparametersprefix = "";
         Combo_suppliergenlandlinecode_Remoteservicesparameters = "";
         Combo_suppliergenlandlinecode_Multiplevaluestype = "";
         Combo_suppliergenlandlinecode_Loadingdata = "";
         Combo_suppliergenlandlinecode_Noresultsfound = "";
         Combo_suppliergenlandlinecode_Emptyitemtext = "";
         Combo_suppliergenlandlinecode_Onlyselectedvalues = "";
         Combo_suppliergenlandlinecode_Selectalltext = "";
         Combo_suppliergenlandlinecode_Multiplevaluesseparator = "";
         Combo_suppliergenlandlinecode_Addnewoptiontext = "";
         Suppliergendescription_Objectcall = "";
         Suppliergendescription_Class = "";
         Suppliergendescription_Buttonpressedid = "";
         Suppliergendescription_Captionvalue = "";
         Suppliergendescription_Coltitle = "";
         Suppliergendescription_Coltitlefont = "";
         Combo_suppliergenaddresscountry_Objectcall = "";
         Combo_suppliergenaddresscountry_Class = "";
         Combo_suppliergenaddresscountry_Icontype = "";
         Combo_suppliergenaddresscountry_Icon = "";
         Combo_suppliergenaddresscountry_Tooltip = "";
         Combo_suppliergenaddresscountry_Selectedvalue_set = "";
         Combo_suppliergenaddresscountry_Selectedtext_set = "";
         Combo_suppliergenaddresscountry_Selectedtext_get = "";
         Combo_suppliergenaddresscountry_Gamoauthtoken = "";
         Combo_suppliergenaddresscountry_Ddointernalname = "";
         Combo_suppliergenaddresscountry_Titlecontrolalign = "";
         Combo_suppliergenaddresscountry_Dropdownoptionstype = "";
         Combo_suppliergenaddresscountry_Titlecontrolidtoreplace = "";
         Combo_suppliergenaddresscountry_Datalisttype = "";
         Combo_suppliergenaddresscountry_Datalistfixedvalues = "";
         Combo_suppliergenaddresscountry_Datalistproc = "";
         Combo_suppliergenaddresscountry_Datalistprocparametersprefix = "";
         Combo_suppliergenaddresscountry_Remoteservicesparameters = "";
         Combo_suppliergenaddresscountry_Multiplevaluestype = "";
         Combo_suppliergenaddresscountry_Loadingdata = "";
         Combo_suppliergenaddresscountry_Noresultsfound = "";
         Combo_suppliergenaddresscountry_Emptyitemtext = "";
         Combo_suppliergenaddresscountry_Onlyselectedvalues = "";
         Combo_suppliergenaddresscountry_Selectalltext = "";
         Combo_suppliergenaddresscountry_Multiplevaluesseparator = "";
         Combo_suppliergenaddresscountry_Addnewoptiontext = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode9 = "";
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
         AV14TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV26defaultCountryPhoneCode = "";
         GXt_guid3 = Guid.Empty;
         AV31DefaultSupplierGenTypeName = "";
         GXEncryptionTmp = "";
         AV17ComboSelectedValue = "";
         AV18ComboSelectedText = "";
         GXt_objcol_SdtDVB_SDTComboData_Item4 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         Z604SupplierGenDescription = "";
         Z254SupplierGenTypeName = "";
         T00064_A254SupplierGenTypeName = new string[] {""} ;
         T00067_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T00067_n42SupplierGenId = new bool[] {false} ;
         T00067_A309SupplierGenAddressCountry = new string[] {""} ;
         T00067_A605SupplierGenLandlineCode = new string[] {""} ;
         T00067_A353SupplierGenPhoneCode = new string[] {""} ;
         T00067_A48SupplierGenContactPhone = new string[] {""} ;
         T00067_A607SupplierGenLandlineNumber = new string[] {""} ;
         T00067_A259SupplierGenAddressZipCode = new string[] {""} ;
         T00067_A43SupplierGenKvkNumber = new string[] {""} ;
         T00067_A254SupplierGenTypeName = new string[] {""} ;
         T00067_A44SupplierGenCompanyName = new string[] {""} ;
         T00067_A260SupplierGenAddressCity = new string[] {""} ;
         T00067_A310SupplierGenAddressLine1 = new string[] {""} ;
         T00067_A311SupplierGenAddressLine2 = new string[] {""} ;
         T00067_A47SupplierGenContactName = new string[] {""} ;
         T00067_A354SupplierGenPhoneNumber = new string[] {""} ;
         T00067_A606SupplierGenLandlineSubNumber = new string[] {""} ;
         T00067_A501SupplierGenEmail = new string[] {""} ;
         T00067_A428SupplierGenWebsite = new string[] {""} ;
         T00067_A604SupplierGenDescription = new string[] {""} ;
         T00067_A253SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         T00067_A601SG_OrganisationSupplierId = new Guid[] {Guid.Empty} ;
         T00067_n601SG_OrganisationSupplierId = new bool[] {false} ;
         T00067_A602SG_LocationSupplierOrganisatio = new Guid[] {Guid.Empty} ;
         T00067_n602SG_LocationSupplierOrganisatio = new bool[] {false} ;
         T00067_A603SG_LocationSupplierLocationId = new Guid[] {Guid.Empty} ;
         T00067_n603SG_LocationSupplierLocationId = new bool[] {false} ;
         T00065_A601SG_OrganisationSupplierId = new Guid[] {Guid.Empty} ;
         T00065_n601SG_OrganisationSupplierId = new bool[] {false} ;
         T00066_A603SG_LocationSupplierLocationId = new Guid[] {Guid.Empty} ;
         T00066_n603SG_LocationSupplierLocationId = new bool[] {false} ;
         T00068_A254SupplierGenTypeName = new string[] {""} ;
         T00069_A601SG_OrganisationSupplierId = new Guid[] {Guid.Empty} ;
         T00069_n601SG_OrganisationSupplierId = new bool[] {false} ;
         T000610_A603SG_LocationSupplierLocationId = new Guid[] {Guid.Empty} ;
         T000610_n603SG_LocationSupplierLocationId = new bool[] {false} ;
         T000611_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T000611_n42SupplierGenId = new bool[] {false} ;
         T00063_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T00063_n42SupplierGenId = new bool[] {false} ;
         T00063_A309SupplierGenAddressCountry = new string[] {""} ;
         T00063_A605SupplierGenLandlineCode = new string[] {""} ;
         T00063_A353SupplierGenPhoneCode = new string[] {""} ;
         T00063_A48SupplierGenContactPhone = new string[] {""} ;
         T00063_A607SupplierGenLandlineNumber = new string[] {""} ;
         T00063_A259SupplierGenAddressZipCode = new string[] {""} ;
         T00063_A43SupplierGenKvkNumber = new string[] {""} ;
         T00063_A44SupplierGenCompanyName = new string[] {""} ;
         T00063_A260SupplierGenAddressCity = new string[] {""} ;
         T00063_A310SupplierGenAddressLine1 = new string[] {""} ;
         T00063_A311SupplierGenAddressLine2 = new string[] {""} ;
         T00063_A47SupplierGenContactName = new string[] {""} ;
         T00063_A354SupplierGenPhoneNumber = new string[] {""} ;
         T00063_A606SupplierGenLandlineSubNumber = new string[] {""} ;
         T00063_A501SupplierGenEmail = new string[] {""} ;
         T00063_A428SupplierGenWebsite = new string[] {""} ;
         T00063_A604SupplierGenDescription = new string[] {""} ;
         T00063_A253SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         T00063_A601SG_OrganisationSupplierId = new Guid[] {Guid.Empty} ;
         T00063_n601SG_OrganisationSupplierId = new bool[] {false} ;
         T00063_A602SG_LocationSupplierOrganisatio = new Guid[] {Guid.Empty} ;
         T00063_n602SG_LocationSupplierOrganisatio = new bool[] {false} ;
         T00063_A603SG_LocationSupplierLocationId = new Guid[] {Guid.Empty} ;
         T00063_n603SG_LocationSupplierLocationId = new bool[] {false} ;
         T000612_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T000612_n42SupplierGenId = new bool[] {false} ;
         T000613_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T000613_n42SupplierGenId = new bool[] {false} ;
         T00062_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T00062_n42SupplierGenId = new bool[] {false} ;
         T00062_A309SupplierGenAddressCountry = new string[] {""} ;
         T00062_A605SupplierGenLandlineCode = new string[] {""} ;
         T00062_A353SupplierGenPhoneCode = new string[] {""} ;
         T00062_A48SupplierGenContactPhone = new string[] {""} ;
         T00062_A607SupplierGenLandlineNumber = new string[] {""} ;
         T00062_A259SupplierGenAddressZipCode = new string[] {""} ;
         T00062_A43SupplierGenKvkNumber = new string[] {""} ;
         T00062_A44SupplierGenCompanyName = new string[] {""} ;
         T00062_A260SupplierGenAddressCity = new string[] {""} ;
         T00062_A310SupplierGenAddressLine1 = new string[] {""} ;
         T00062_A311SupplierGenAddressLine2 = new string[] {""} ;
         T00062_A47SupplierGenContactName = new string[] {""} ;
         T00062_A354SupplierGenPhoneNumber = new string[] {""} ;
         T00062_A606SupplierGenLandlineSubNumber = new string[] {""} ;
         T00062_A501SupplierGenEmail = new string[] {""} ;
         T00062_A428SupplierGenWebsite = new string[] {""} ;
         T00062_A604SupplierGenDescription = new string[] {""} ;
         T00062_A253SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         T00062_A601SG_OrganisationSupplierId = new Guid[] {Guid.Empty} ;
         T00062_n601SG_OrganisationSupplierId = new bool[] {false} ;
         T00062_A602SG_LocationSupplierOrganisatio = new Guid[] {Guid.Empty} ;
         T00062_n602SG_LocationSupplierOrganisatio = new bool[] {false} ;
         T00062_A603SG_LocationSupplierLocationId = new Guid[] {Guid.Empty} ;
         T00062_n603SG_LocationSupplierLocationId = new bool[] {false} ;
         T000617_A254SupplierGenTypeName = new string[] {""} ;
         T000618_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T000618_A29LocationId = new Guid[] {Guid.Empty} ;
         T000618_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000619_A616SupplierDynamicFormId = new Guid[] {Guid.Empty} ;
         T000619_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T000619_n42SupplierGenId = new bool[] {false} ;
         T000620_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T000620_n42SupplierGenId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i603SG_LocationSupplierLocationId = Guid.Empty;
         i602SG_LocationSupplierOrganisatio = Guid.Empty;
         i601SG_OrganisationSupplierId = Guid.Empty;
         GXt_char2 = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_suppliergen__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_suppliergen__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_suppliergen__default(),
            new Object[][] {
                new Object[] {
               T00062_A42SupplierGenId, T00062_A309SupplierGenAddressCountry, T00062_A605SupplierGenLandlineCode, T00062_A353SupplierGenPhoneCode, T00062_A48SupplierGenContactPhone, T00062_A607SupplierGenLandlineNumber, T00062_A259SupplierGenAddressZipCode, T00062_A43SupplierGenKvkNumber, T00062_A44SupplierGenCompanyName, T00062_A260SupplierGenAddressCity,
               T00062_A310SupplierGenAddressLine1, T00062_A311SupplierGenAddressLine2, T00062_A47SupplierGenContactName, T00062_A354SupplierGenPhoneNumber, T00062_A606SupplierGenLandlineSubNumber, T00062_A501SupplierGenEmail, T00062_A428SupplierGenWebsite, T00062_A604SupplierGenDescription, T00062_A253SupplierGenTypeId, T00062_A601SG_OrganisationSupplierId,
               T00062_n601SG_OrganisationSupplierId, T00062_A602SG_LocationSupplierOrganisatio, T00062_n602SG_LocationSupplierOrganisatio, T00062_A603SG_LocationSupplierLocationId, T00062_n603SG_LocationSupplierLocationId
               }
               , new Object[] {
               T00063_A42SupplierGenId, T00063_A309SupplierGenAddressCountry, T00063_A605SupplierGenLandlineCode, T00063_A353SupplierGenPhoneCode, T00063_A48SupplierGenContactPhone, T00063_A607SupplierGenLandlineNumber, T00063_A259SupplierGenAddressZipCode, T00063_A43SupplierGenKvkNumber, T00063_A44SupplierGenCompanyName, T00063_A260SupplierGenAddressCity,
               T00063_A310SupplierGenAddressLine1, T00063_A311SupplierGenAddressLine2, T00063_A47SupplierGenContactName, T00063_A354SupplierGenPhoneNumber, T00063_A606SupplierGenLandlineSubNumber, T00063_A501SupplierGenEmail, T00063_A428SupplierGenWebsite, T00063_A604SupplierGenDescription, T00063_A253SupplierGenTypeId, T00063_A601SG_OrganisationSupplierId,
               T00063_n601SG_OrganisationSupplierId, T00063_A602SG_LocationSupplierOrganisatio, T00063_n602SG_LocationSupplierOrganisatio, T00063_A603SG_LocationSupplierLocationId, T00063_n603SG_LocationSupplierLocationId
               }
               , new Object[] {
               T00064_A254SupplierGenTypeName
               }
               , new Object[] {
               T00065_A601SG_OrganisationSupplierId
               }
               , new Object[] {
               T00066_A603SG_LocationSupplierLocationId
               }
               , new Object[] {
               T00067_A42SupplierGenId, T00067_A309SupplierGenAddressCountry, T00067_A605SupplierGenLandlineCode, T00067_A353SupplierGenPhoneCode, T00067_A48SupplierGenContactPhone, T00067_A607SupplierGenLandlineNumber, T00067_A259SupplierGenAddressZipCode, T00067_A43SupplierGenKvkNumber, T00067_A254SupplierGenTypeName, T00067_A44SupplierGenCompanyName,
               T00067_A260SupplierGenAddressCity, T00067_A310SupplierGenAddressLine1, T00067_A311SupplierGenAddressLine2, T00067_A47SupplierGenContactName, T00067_A354SupplierGenPhoneNumber, T00067_A606SupplierGenLandlineSubNumber, T00067_A501SupplierGenEmail, T00067_A428SupplierGenWebsite, T00067_A604SupplierGenDescription, T00067_A253SupplierGenTypeId,
               T00067_A601SG_OrganisationSupplierId, T00067_n601SG_OrganisationSupplierId, T00067_A602SG_LocationSupplierOrganisatio, T00067_n602SG_LocationSupplierOrganisatio, T00067_A603SG_LocationSupplierLocationId, T00067_n603SG_LocationSupplierLocationId
               }
               , new Object[] {
               T00068_A254SupplierGenTypeName
               }
               , new Object[] {
               T00069_A601SG_OrganisationSupplierId
               }
               , new Object[] {
               T000610_A603SG_LocationSupplierLocationId
               }
               , new Object[] {
               T000611_A42SupplierGenId
               }
               , new Object[] {
               T000612_A42SupplierGenId
               }
               , new Object[] {
               T000613_A42SupplierGenId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000617_A254SupplierGenTypeName
               }
               , new Object[] {
               T000618_A58ProductServiceId, T000618_A29LocationId, T000618_A11OrganisationId
               }
               , new Object[] {
               T000619_A616SupplierDynamicFormId, T000619_A42SupplierGenId
               }
               , new Object[] {
               T000620_A42SupplierGenId
               }
            }
         );
         Z42SupplierGenId = Guid.NewGuid( );
         n42SupplierGenId = false;
         A42SupplierGenId = Guid.NewGuid( );
         n42SupplierGenId = false;
         AV43Pgmname = "Trn_SupplierGen";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound9 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtSupplierGenKvkNumber_Enabled ;
      private int edtSupplierGenCompanyName_Enabled ;
      private int edtSupplierGenTypeId_Visible ;
      private int edtSupplierGenTypeId_Enabled ;
      private int edtSupplierGenContactName_Enabled ;
      private int divUnnamedtable5_Visible ;
      private int edtSupplierGenPhoneCode_Visible ;
      private int edtSupplierGenPhoneCode_Enabled ;
      private int edtSupplierGenPhoneNumber_Enabled ;
      private int divUnnamedtable6_Visible ;
      private int edtSupplierGenLandlineCode_Visible ;
      private int edtSupplierGenLandlineCode_Enabled ;
      private int edtSupplierGenLandlineSubNumber_Enabled ;
      private int edtSupplierGenContactPhone_Visible ;
      private int edtSupplierGenContactPhone_Enabled ;
      private int edtSupplierGenLandlineNumber_Visible ;
      private int edtSupplierGenLandlineNumber_Enabled ;
      private int edtSupplierGenEmail_Enabled ;
      private int edtSupplierGenWebsite_Enabled ;
      private int divDescriptiontable_Visible ;
      private int edtSupplierGenAddressLine1_Enabled ;
      private int edtSupplierGenAddressLine2_Enabled ;
      private int edtSupplierGenAddressZipCode_Enabled ;
      private int edtSupplierGenAddressCity_Enabled ;
      private int edtSupplierGenAddressCountry_Visible ;
      private int edtSupplierGenAddressCountry_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavCombosuppliergentypeid_Visible ;
      private int edtavCombosuppliergentypeid_Enabled ;
      private int edtavCombosuppliergenphonecode_Visible ;
      private int edtavCombosuppliergenphonecode_Enabled ;
      private int edtavCombosuppliergenlandlinecode_Visible ;
      private int edtavCombosuppliergenlandlinecode_Enabled ;
      private int edtavCombosuppliergenaddresscountry_Visible ;
      private int edtavCombosuppliergenaddresscountry_Enabled ;
      private int edtSupplierGenId_Visible ;
      private int edtSupplierGenId_Enabled ;
      private int Combo_suppliergentypeid_Datalistupdateminimumcharacters ;
      private int Combo_suppliergentypeid_Gxcontroltype ;
      private int Combo_suppliergenphonecode_Datalistupdateminimumcharacters ;
      private int Combo_suppliergenphonecode_Gxcontroltype ;
      private int Combo_suppliergenlandlinecode_Datalistupdateminimumcharacters ;
      private int Combo_suppliergenlandlinecode_Gxcontroltype ;
      private int Suppliergendescription_Color ;
      private int Suppliergendescription_Coltitlecolor ;
      private int Combo_suppliergenaddresscountry_Datalistupdateminimumcharacters ;
      private int Combo_suppliergenaddresscountry_Gxcontroltype ;
      private int AV44GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z48SupplierGenContactPhone ;
      private string Combo_suppliergenaddresscountry_Selectedvalue_get ;
      private string Combo_suppliergenlandlinecode_Selectedvalue_get ;
      private string Combo_suppliergenphonecode_Selectedvalue_get ;
      private string Combo_suppliergentypeid_Selectedvalue_get ;
      private string Combo_suppliergentypeid_Selectedtext_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSupplierGenKvkNumber_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string grpUnnamedgroup2_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string TempTags ;
      private string edtSupplierGenKvkNumber_Jsonclick ;
      private string edtSupplierGenCompanyName_Internalname ;
      private string edtSupplierGenCompanyName_Jsonclick ;
      private string divTablesplittedsuppliergentypeid_Internalname ;
      private string lblTextblocksuppliergentypeid_Internalname ;
      private string lblTextblocksuppliergentypeid_Jsonclick ;
      private string Combo_suppliergentypeid_Caption ;
      private string Combo_suppliergentypeid_Cls ;
      private string Combo_suppliergentypeid_Internalname ;
      private string edtSupplierGenTypeId_Internalname ;
      private string edtSupplierGenTypeId_Jsonclick ;
      private string edtSupplierGenContactName_Internalname ;
      private string edtSupplierGenContactName_Jsonclick ;
      private string divUnnamedtable5_Internalname ;
      private string lblPhonelabel_Internalname ;
      private string lblPhonelabel_Jsonclick ;
      private string divUnnamedtable10_Internalname ;
      private string divUnnamedtable11_Internalname ;
      private string divUnnamedtablesuppliergenphonecode_Internalname ;
      private string Combo_suppliergenphonecode_Caption ;
      private string Combo_suppliergenphonecode_Cls ;
      private string Combo_suppliergenphonecode_Internalname ;
      private string edtSupplierGenPhoneCode_Internalname ;
      private string edtSupplierGenPhoneCode_Jsonclick ;
      private string edtSupplierGenPhoneNumber_Internalname ;
      private string edtSupplierGenPhoneNumber_Jsonclick ;
      private string edtSupplierGenPhoneNumber_Class ;
      private string divUnnamedtable6_Internalname ;
      private string lblPhonelabellandline_Internalname ;
      private string lblPhonelabellandline_Jsonclick ;
      private string divUnnamedtable8_Internalname ;
      private string divUnnamedtable9_Internalname ;
      private string divUnnamedtablesuppliergenlandlinecode_Internalname ;
      private string Combo_suppliergenlandlinecode_Caption ;
      private string Combo_suppliergenlandlinecode_Cls ;
      private string Combo_suppliergenlandlinecode_Internalname ;
      private string edtSupplierGenLandlineCode_Internalname ;
      private string edtSupplierGenLandlineCode_Jsonclick ;
      private string edtSupplierGenLandlineSubNumber_Internalname ;
      private string edtSupplierGenLandlineSubNumber_Jsonclick ;
      private string divSuppliergencontactphone_cell_Internalname ;
      private string divSuppliergencontactphone_cell_Class ;
      private string edtSupplierGenContactPhone_Internalname ;
      private string gxphoneLink ;
      private string A48SupplierGenContactPhone ;
      private string edtSupplierGenContactPhone_Jsonclick ;
      private string divSuppliergenlandlinenumber_cell_Internalname ;
      private string divSuppliergenlandlinenumber_cell_Class ;
      private string edtSupplierGenLandlineNumber_Internalname ;
      private string edtSupplierGenLandlineNumber_Jsonclick ;
      private string edtSupplierGenEmail_Internalname ;
      private string edtSupplierGenEmail_Jsonclick ;
      private string edtSupplierGenWebsite_Internalname ;
      private string edtSupplierGenWebsite_Jsonclick ;
      private string divSuppliergendescription_cell_Internalname ;
      private string divSuppliergendescription_cell_Class ;
      private string Suppliergendescription_Internalname ;
      private string Suppliergendescription_Width ;
      private string Suppliergendescription_Height ;
      private string Suppliergendescription_Skin ;
      private string Suppliergendescription_Toolbar ;
      private string Suppliergendescription_Customtoolbar ;
      private string Suppliergendescription_Customconfiguration ;
      private string Suppliergendescription_Captionclass ;
      private string Suppliergendescription_Captionstyle ;
      private string Suppliergendescription_Captionposition ;
      private string divDescriptiontable_Internalname ;
      private string lblTextblockdescriptionlabel_Internalname ;
      private string lblTextblockdescriptionlabel_Jsonclick ;
      private string divUnnamedtable7_Internalname ;
      private string lblDescriptiontext_Internalname ;
      private string lblDescriptiontext_Jsonclick ;
      private string grpUnnamedgroup4_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string edtSupplierGenAddressLine1_Internalname ;
      private string edtSupplierGenAddressLine1_Jsonclick ;
      private string edtSupplierGenAddressLine2_Internalname ;
      private string edtSupplierGenAddressLine2_Jsonclick ;
      private string edtSupplierGenAddressZipCode_Internalname ;
      private string edtSupplierGenAddressZipCode_Jsonclick ;
      private string edtSupplierGenAddressCity_Internalname ;
      private string edtSupplierGenAddressCity_Jsonclick ;
      private string divTablesplittedsuppliergenaddresscountry_Internalname ;
      private string lblTextblocksuppliergenaddresscountry_Internalname ;
      private string lblTextblocksuppliergenaddresscountry_Jsonclick ;
      private string Combo_suppliergenaddresscountry_Caption ;
      private string Combo_suppliergenaddresscountry_Cls ;
      private string Combo_suppliergenaddresscountry_Internalname ;
      private string edtSupplierGenAddressCountry_Internalname ;
      private string edtSupplierGenAddressCountry_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_suppliergentypeid_Internalname ;
      private string edtavCombosuppliergentypeid_Internalname ;
      private string edtavCombosuppliergentypeid_Jsonclick ;
      private string divSectionattribute_suppliergenphonecode_Internalname ;
      private string edtavCombosuppliergenphonecode_Internalname ;
      private string edtavCombosuppliergenphonecode_Jsonclick ;
      private string divSectionattribute_suppliergenlandlinecode_Internalname ;
      private string edtavCombosuppliergenlandlinecode_Internalname ;
      private string edtavCombosuppliergenlandlinecode_Jsonclick ;
      private string divSectionattribute_suppliergenaddresscountry_Internalname ;
      private string edtavCombosuppliergenaddresscountry_Internalname ;
      private string edtavCombosuppliergenaddresscountry_Jsonclick ;
      private string edtSupplierGenId_Internalname ;
      private string edtSupplierGenId_Jsonclick ;
      private string AV43Pgmname ;
      private string Combo_suppliergentypeid_Objectcall ;
      private string Combo_suppliergentypeid_Class ;
      private string Combo_suppliergentypeid_Icontype ;
      private string Combo_suppliergentypeid_Icon ;
      private string Combo_suppliergentypeid_Tooltip ;
      private string Combo_suppliergentypeid_Selectedvalue_set ;
      private string Combo_suppliergentypeid_Selectedtext_set ;
      private string Combo_suppliergentypeid_Gamoauthtoken ;
      private string Combo_suppliergentypeid_Ddointernalname ;
      private string Combo_suppliergentypeid_Titlecontrolalign ;
      private string Combo_suppliergentypeid_Dropdownoptionstype ;
      private string Combo_suppliergentypeid_Titlecontrolidtoreplace ;
      private string Combo_suppliergentypeid_Datalisttype ;
      private string Combo_suppliergentypeid_Datalistfixedvalues ;
      private string Combo_suppliergentypeid_Datalistproc ;
      private string Combo_suppliergentypeid_Datalistprocparametersprefix ;
      private string Combo_suppliergentypeid_Remoteservicesparameters ;
      private string Combo_suppliergentypeid_Htmltemplate ;
      private string Combo_suppliergentypeid_Multiplevaluestype ;
      private string Combo_suppliergentypeid_Loadingdata ;
      private string Combo_suppliergentypeid_Noresultsfound ;
      private string Combo_suppliergentypeid_Emptyitemtext ;
      private string Combo_suppliergentypeid_Onlyselectedvalues ;
      private string Combo_suppliergentypeid_Selectalltext ;
      private string Combo_suppliergentypeid_Multiplevaluesseparator ;
      private string Combo_suppliergentypeid_Addnewoptiontext ;
      private string Combo_suppliergenphonecode_Objectcall ;
      private string Combo_suppliergenphonecode_Class ;
      private string Combo_suppliergenphonecode_Icontype ;
      private string Combo_suppliergenphonecode_Icon ;
      private string Combo_suppliergenphonecode_Tooltip ;
      private string Combo_suppliergenphonecode_Selectedvalue_set ;
      private string Combo_suppliergenphonecode_Selectedtext_set ;
      private string Combo_suppliergenphonecode_Selectedtext_get ;
      private string Combo_suppliergenphonecode_Gamoauthtoken ;
      private string Combo_suppliergenphonecode_Ddointernalname ;
      private string Combo_suppliergenphonecode_Titlecontrolalign ;
      private string Combo_suppliergenphonecode_Dropdownoptionstype ;
      private string Combo_suppliergenphonecode_Titlecontrolidtoreplace ;
      private string Combo_suppliergenphonecode_Datalisttype ;
      private string Combo_suppliergenphonecode_Datalistfixedvalues ;
      private string Combo_suppliergenphonecode_Datalistproc ;
      private string Combo_suppliergenphonecode_Datalistprocparametersprefix ;
      private string Combo_suppliergenphonecode_Remoteservicesparameters ;
      private string Combo_suppliergenphonecode_Htmltemplate ;
      private string Combo_suppliergenphonecode_Multiplevaluestype ;
      private string Combo_suppliergenphonecode_Loadingdata ;
      private string Combo_suppliergenphonecode_Noresultsfound ;
      private string Combo_suppliergenphonecode_Emptyitemtext ;
      private string Combo_suppliergenphonecode_Onlyselectedvalues ;
      private string Combo_suppliergenphonecode_Selectalltext ;
      private string Combo_suppliergenphonecode_Multiplevaluesseparator ;
      private string Combo_suppliergenphonecode_Addnewoptiontext ;
      private string Combo_suppliergenlandlinecode_Objectcall ;
      private string Combo_suppliergenlandlinecode_Class ;
      private string Combo_suppliergenlandlinecode_Icontype ;
      private string Combo_suppliergenlandlinecode_Icon ;
      private string Combo_suppliergenlandlinecode_Tooltip ;
      private string Combo_suppliergenlandlinecode_Selectedvalue_set ;
      private string Combo_suppliergenlandlinecode_Selectedtext_set ;
      private string Combo_suppliergenlandlinecode_Selectedtext_get ;
      private string Combo_suppliergenlandlinecode_Gamoauthtoken ;
      private string Combo_suppliergenlandlinecode_Ddointernalname ;
      private string Combo_suppliergenlandlinecode_Titlecontrolalign ;
      private string Combo_suppliergenlandlinecode_Dropdownoptionstype ;
      private string Combo_suppliergenlandlinecode_Titlecontrolidtoreplace ;
      private string Combo_suppliergenlandlinecode_Datalisttype ;
      private string Combo_suppliergenlandlinecode_Datalistfixedvalues ;
      private string Combo_suppliergenlandlinecode_Datalistproc ;
      private string Combo_suppliergenlandlinecode_Datalistprocparametersprefix ;
      private string Combo_suppliergenlandlinecode_Remoteservicesparameters ;
      private string Combo_suppliergenlandlinecode_Htmltemplate ;
      private string Combo_suppliergenlandlinecode_Multiplevaluestype ;
      private string Combo_suppliergenlandlinecode_Loadingdata ;
      private string Combo_suppliergenlandlinecode_Noresultsfound ;
      private string Combo_suppliergenlandlinecode_Emptyitemtext ;
      private string Combo_suppliergenlandlinecode_Onlyselectedvalues ;
      private string Combo_suppliergenlandlinecode_Selectalltext ;
      private string Combo_suppliergenlandlinecode_Multiplevaluesseparator ;
      private string Combo_suppliergenlandlinecode_Addnewoptiontext ;
      private string Suppliergendescription_Objectcall ;
      private string Suppliergendescription_Class ;
      private string Suppliergendescription_Buttonpressedid ;
      private string Suppliergendescription_Captionvalue ;
      private string Suppliergendescription_Coltitle ;
      private string Suppliergendescription_Coltitlefont ;
      private string Combo_suppliergenaddresscountry_Objectcall ;
      private string Combo_suppliergenaddresscountry_Class ;
      private string Combo_suppliergenaddresscountry_Icontype ;
      private string Combo_suppliergenaddresscountry_Icon ;
      private string Combo_suppliergenaddresscountry_Tooltip ;
      private string Combo_suppliergenaddresscountry_Selectedvalue_set ;
      private string Combo_suppliergenaddresscountry_Selectedtext_set ;
      private string Combo_suppliergenaddresscountry_Selectedtext_get ;
      private string Combo_suppliergenaddresscountry_Gamoauthtoken ;
      private string Combo_suppliergenaddresscountry_Ddointernalname ;
      private string Combo_suppliergenaddresscountry_Titlecontrolalign ;
      private string Combo_suppliergenaddresscountry_Dropdownoptionstype ;
      private string Combo_suppliergenaddresscountry_Titlecontrolidtoreplace ;
      private string Combo_suppliergenaddresscountry_Datalisttype ;
      private string Combo_suppliergenaddresscountry_Datalistfixedvalues ;
      private string Combo_suppliergenaddresscountry_Datalistproc ;
      private string Combo_suppliergenaddresscountry_Datalistprocparametersprefix ;
      private string Combo_suppliergenaddresscountry_Remoteservicesparameters ;
      private string Combo_suppliergenaddresscountry_Htmltemplate ;
      private string Combo_suppliergenaddresscountry_Multiplevaluestype ;
      private string Combo_suppliergenaddresscountry_Loadingdata ;
      private string Combo_suppliergenaddresscountry_Noresultsfound ;
      private string Combo_suppliergenaddresscountry_Emptyitemtext ;
      private string Combo_suppliergenaddresscountry_Onlyselectedvalues ;
      private string Combo_suppliergenaddresscountry_Selectalltext ;
      private string Combo_suppliergenaddresscountry_Multiplevaluesseparator ;
      private string Combo_suppliergenaddresscountry_Addnewoptiontext ;
      private string hsh ;
      private string sMode9 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXEncryptionTmp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXt_char2 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n601SG_OrganisationSupplierId ;
      private bool n603SG_LocationSupplierLocationId ;
      private bool n602SG_LocationSupplierOrganisatio ;
      private bool wbErr ;
      private bool Combo_suppliergentypeid_Emptyitem ;
      private bool Combo_suppliergentypeid_Includeaddnewoption ;
      private bool Combo_suppliergenphonecode_Emptyitem ;
      private bool Combo_suppliergenlandlinecode_Emptyitem ;
      private bool Suppliergendescription_Toolbarcancollapse ;
      private bool Combo_suppliergenaddresscountry_Emptyitem ;
      private bool Combo_suppliergentypeid_Enabled ;
      private bool Combo_suppliergentypeid_Visible ;
      private bool Combo_suppliergentypeid_Allowmultipleselection ;
      private bool Combo_suppliergentypeid_Isgriditem ;
      private bool Combo_suppliergentypeid_Hasdescription ;
      private bool Combo_suppliergentypeid_Includeonlyselectedoption ;
      private bool Combo_suppliergentypeid_Includeselectalloption ;
      private bool Combo_suppliergenphonecode_Enabled ;
      private bool Combo_suppliergenphonecode_Visible ;
      private bool Combo_suppliergenphonecode_Allowmultipleselection ;
      private bool Combo_suppliergenphonecode_Isgriditem ;
      private bool Combo_suppliergenphonecode_Hasdescription ;
      private bool Combo_suppliergenphonecode_Includeonlyselectedoption ;
      private bool Combo_suppliergenphonecode_Includeselectalloption ;
      private bool Combo_suppliergenphonecode_Includeaddnewoption ;
      private bool Combo_suppliergenlandlinecode_Enabled ;
      private bool Combo_suppliergenlandlinecode_Visible ;
      private bool Combo_suppliergenlandlinecode_Allowmultipleselection ;
      private bool Combo_suppliergenlandlinecode_Isgriditem ;
      private bool Combo_suppliergenlandlinecode_Hasdescription ;
      private bool Combo_suppliergenlandlinecode_Includeonlyselectedoption ;
      private bool Combo_suppliergenlandlinecode_Includeselectalloption ;
      private bool Combo_suppliergenlandlinecode_Includeaddnewoption ;
      private bool Suppliergendescription_Enabled ;
      private bool Suppliergendescription_Toolbarexpanded ;
      private bool Suppliergendescription_Isabstractlayoutcontrol ;
      private bool Suppliergendescription_Usercontroliscolumn ;
      private bool Suppliergendescription_Visible ;
      private bool Combo_suppliergenaddresscountry_Enabled ;
      private bool Combo_suppliergenaddresscountry_Visible ;
      private bool Combo_suppliergenaddresscountry_Allowmultipleselection ;
      private bool Combo_suppliergenaddresscountry_Isgriditem ;
      private bool Combo_suppliergenaddresscountry_Hasdescription ;
      private bool Combo_suppliergenaddresscountry_Includeonlyselectedoption ;
      private bool Combo_suppliergenaddresscountry_Includeselectalloption ;
      private bool Combo_suppliergenaddresscountry_Includeaddnewoption ;
      private bool n42SupplierGenId ;
      private bool returnInSub ;
      private bool GXt_boolean5 ;
      private bool Gx_longc ;
      private string SupplierGenDescription ;
      private string A604SupplierGenDescription ;
      private string Z604SupplierGenDescription ;
      private string Z309SupplierGenAddressCountry ;
      private string Z605SupplierGenLandlineCode ;
      private string Z353SupplierGenPhoneCode ;
      private string Z607SupplierGenLandlineNumber ;
      private string Z259SupplierGenAddressZipCode ;
      private string Z43SupplierGenKvkNumber ;
      private string Z44SupplierGenCompanyName ;
      private string Z260SupplierGenAddressCity ;
      private string Z310SupplierGenAddressLine1 ;
      private string Z311SupplierGenAddressLine2 ;
      private string Z47SupplierGenContactName ;
      private string Z354SupplierGenPhoneNumber ;
      private string Z606SupplierGenLandlineSubNumber ;
      private string Z501SupplierGenEmail ;
      private string Z428SupplierGenWebsite ;
      private string A353SupplierGenPhoneCode ;
      private string A354SupplierGenPhoneNumber ;
      private string A605SupplierGenLandlineCode ;
      private string A606SupplierGenLandlineSubNumber ;
      private string A43SupplierGenKvkNumber ;
      private string A44SupplierGenCompanyName ;
      private string A47SupplierGenContactName ;
      private string A607SupplierGenLandlineNumber ;
      private string A501SupplierGenEmail ;
      private string A428SupplierGenWebsite ;
      private string A310SupplierGenAddressLine1 ;
      private string A311SupplierGenAddressLine2 ;
      private string A259SupplierGenAddressZipCode ;
      private string A260SupplierGenAddressCity ;
      private string A309SupplierGenAddressCountry ;
      private string AV25ComboSupplierGenPhoneCode ;
      private string AV42ComboSupplierGenLandlineCode ;
      private string AV24ComboSupplierGenAddressCountry ;
      private string A254SupplierGenTypeName ;
      private string AV26defaultCountryPhoneCode ;
      private string AV31DefaultSupplierGenTypeName ;
      private string AV17ComboSelectedValue ;
      private string AV18ComboSelectedText ;
      private string Z254SupplierGenTypeName ;
      private Guid wcpOAV7SupplierGenId ;
      private Guid Z42SupplierGenId ;
      private Guid Z253SupplierGenTypeId ;
      private Guid Z601SG_OrganisationSupplierId ;
      private Guid Z602SG_LocationSupplierOrganisatio ;
      private Guid Z603SG_LocationSupplierLocationId ;
      private Guid N253SupplierGenTypeId ;
      private Guid N601SG_OrganisationSupplierId ;
      private Guid N602SG_LocationSupplierOrganisatio ;
      private Guid N603SG_LocationSupplierLocationId ;
      private Guid A253SupplierGenTypeId ;
      private Guid A601SG_OrganisationSupplierId ;
      private Guid A603SG_LocationSupplierLocationId ;
      private Guid A602SG_LocationSupplierOrganisatio ;
      private Guid AV7SupplierGenId ;
      private Guid AV20ComboSupplierGenTypeId ;
      private Guid A42SupplierGenId ;
      private Guid AV13Insert_SupplierGenTypeId ;
      private Guid AV34Insert_SG_OrganisationSupplierId ;
      private Guid AV40SG_OrganisationSupplierId ;
      private Guid AV35Insert_SG_LocationSupplierOrganisationId ;
      private Guid AV38SG_LocationSupplierOrganisationId ;
      private Guid AV36Insert_SG_LocationSupplierLocationId ;
      private Guid AV39SG_LocationSupplierLocationId ;
      private Guid GXt_guid3 ;
      private Guid i603SG_LocationSupplierLocationId ;
      private Guid i602SG_LocationSupplierOrganisatio ;
      private Guid i601SG_OrganisationSupplierId ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucCombo_suppliergentypeid ;
      private GXUserControl ucCombo_suppliergenphonecode ;
      private GXUserControl ucCombo_suppliergenlandlinecode ;
      private GXUserControl ucSuppliergendescription ;
      private GXUserControl ucCombo_suppliergenaddresscountry ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV15SupplierGenTypeId_Data ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV16DDO_TitleSettingsIcons ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV27SupplierGenPhoneCode_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV41SupplierGenLandlineCode_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV23SupplierGenAddressCountry_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> GXt_objcol_SdtDVB_SDTComboData_Item4 ;
      private IDataStoreProvider pr_default ;
      private string[] T00064_A254SupplierGenTypeName ;
      private Guid[] T00067_A42SupplierGenId ;
      private bool[] T00067_n42SupplierGenId ;
      private string[] T00067_A309SupplierGenAddressCountry ;
      private string[] T00067_A605SupplierGenLandlineCode ;
      private string[] T00067_A353SupplierGenPhoneCode ;
      private string[] T00067_A48SupplierGenContactPhone ;
      private string[] T00067_A607SupplierGenLandlineNumber ;
      private string[] T00067_A259SupplierGenAddressZipCode ;
      private string[] T00067_A43SupplierGenKvkNumber ;
      private string[] T00067_A254SupplierGenTypeName ;
      private string[] T00067_A44SupplierGenCompanyName ;
      private string[] T00067_A260SupplierGenAddressCity ;
      private string[] T00067_A310SupplierGenAddressLine1 ;
      private string[] T00067_A311SupplierGenAddressLine2 ;
      private string[] T00067_A47SupplierGenContactName ;
      private string[] T00067_A354SupplierGenPhoneNumber ;
      private string[] T00067_A606SupplierGenLandlineSubNumber ;
      private string[] T00067_A501SupplierGenEmail ;
      private string[] T00067_A428SupplierGenWebsite ;
      private string[] T00067_A604SupplierGenDescription ;
      private Guid[] T00067_A253SupplierGenTypeId ;
      private Guid[] T00067_A601SG_OrganisationSupplierId ;
      private bool[] T00067_n601SG_OrganisationSupplierId ;
      private Guid[] T00067_A602SG_LocationSupplierOrganisatio ;
      private bool[] T00067_n602SG_LocationSupplierOrganisatio ;
      private Guid[] T00067_A603SG_LocationSupplierLocationId ;
      private bool[] T00067_n603SG_LocationSupplierLocationId ;
      private Guid[] T00065_A601SG_OrganisationSupplierId ;
      private bool[] T00065_n601SG_OrganisationSupplierId ;
      private Guid[] T00066_A603SG_LocationSupplierLocationId ;
      private bool[] T00066_n603SG_LocationSupplierLocationId ;
      private string[] T00068_A254SupplierGenTypeName ;
      private Guid[] T00069_A601SG_OrganisationSupplierId ;
      private bool[] T00069_n601SG_OrganisationSupplierId ;
      private Guid[] T000610_A603SG_LocationSupplierLocationId ;
      private bool[] T000610_n603SG_LocationSupplierLocationId ;
      private Guid[] T000611_A42SupplierGenId ;
      private bool[] T000611_n42SupplierGenId ;
      private Guid[] T00063_A42SupplierGenId ;
      private bool[] T00063_n42SupplierGenId ;
      private string[] T00063_A309SupplierGenAddressCountry ;
      private string[] T00063_A605SupplierGenLandlineCode ;
      private string[] T00063_A353SupplierGenPhoneCode ;
      private string[] T00063_A48SupplierGenContactPhone ;
      private string[] T00063_A607SupplierGenLandlineNumber ;
      private string[] T00063_A259SupplierGenAddressZipCode ;
      private string[] T00063_A43SupplierGenKvkNumber ;
      private string[] T00063_A44SupplierGenCompanyName ;
      private string[] T00063_A260SupplierGenAddressCity ;
      private string[] T00063_A310SupplierGenAddressLine1 ;
      private string[] T00063_A311SupplierGenAddressLine2 ;
      private string[] T00063_A47SupplierGenContactName ;
      private string[] T00063_A354SupplierGenPhoneNumber ;
      private string[] T00063_A606SupplierGenLandlineSubNumber ;
      private string[] T00063_A501SupplierGenEmail ;
      private string[] T00063_A428SupplierGenWebsite ;
      private string[] T00063_A604SupplierGenDescription ;
      private Guid[] T00063_A253SupplierGenTypeId ;
      private Guid[] T00063_A601SG_OrganisationSupplierId ;
      private bool[] T00063_n601SG_OrganisationSupplierId ;
      private Guid[] T00063_A602SG_LocationSupplierOrganisatio ;
      private bool[] T00063_n602SG_LocationSupplierOrganisatio ;
      private Guid[] T00063_A603SG_LocationSupplierLocationId ;
      private bool[] T00063_n603SG_LocationSupplierLocationId ;
      private Guid[] T000612_A42SupplierGenId ;
      private bool[] T000612_n42SupplierGenId ;
      private Guid[] T000613_A42SupplierGenId ;
      private bool[] T000613_n42SupplierGenId ;
      private Guid[] T00062_A42SupplierGenId ;
      private bool[] T00062_n42SupplierGenId ;
      private string[] T00062_A309SupplierGenAddressCountry ;
      private string[] T00062_A605SupplierGenLandlineCode ;
      private string[] T00062_A353SupplierGenPhoneCode ;
      private string[] T00062_A48SupplierGenContactPhone ;
      private string[] T00062_A607SupplierGenLandlineNumber ;
      private string[] T00062_A259SupplierGenAddressZipCode ;
      private string[] T00062_A43SupplierGenKvkNumber ;
      private string[] T00062_A44SupplierGenCompanyName ;
      private string[] T00062_A260SupplierGenAddressCity ;
      private string[] T00062_A310SupplierGenAddressLine1 ;
      private string[] T00062_A311SupplierGenAddressLine2 ;
      private string[] T00062_A47SupplierGenContactName ;
      private string[] T00062_A354SupplierGenPhoneNumber ;
      private string[] T00062_A606SupplierGenLandlineSubNumber ;
      private string[] T00062_A501SupplierGenEmail ;
      private string[] T00062_A428SupplierGenWebsite ;
      private string[] T00062_A604SupplierGenDescription ;
      private Guid[] T00062_A253SupplierGenTypeId ;
      private Guid[] T00062_A601SG_OrganisationSupplierId ;
      private bool[] T00062_n601SG_OrganisationSupplierId ;
      private Guid[] T00062_A602SG_LocationSupplierOrganisatio ;
      private bool[] T00062_n602SG_LocationSupplierOrganisatio ;
      private Guid[] T00062_A603SG_LocationSupplierLocationId ;
      private bool[] T00062_n603SG_LocationSupplierLocationId ;
      private string[] T000617_A254SupplierGenTypeName ;
      private Guid[] T000618_A58ProductServiceId ;
      private Guid[] T000618_A29LocationId ;
      private Guid[] T000618_A11OrganisationId ;
      private Guid[] T000619_A616SupplierDynamicFormId ;
      private Guid[] T000619_A42SupplierGenId ;
      private bool[] T000619_n42SupplierGenId ;
      private Guid[] T000620_A42SupplierGenId ;
      private bool[] T000620_n42SupplierGenId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_suppliergen__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_suppliergen__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_suppliergen__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmT00062;
       prmT00062 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT00063;
       prmT00063 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT00064;
       prmT00064 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00065;
       prmT00065 = new Object[] {
       new ParDef("SG_OrganisationSupplierId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT00066;
       prmT00066 = new Object[] {
       new ParDef("SG_LocationSupplierLocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("SG_LocationSupplierOrganisatio",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT00067;
       prmT00067 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT00068;
       prmT00068 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00069;
       prmT00069 = new Object[] {
       new ParDef("SG_OrganisationSupplierId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000610;
       prmT000610 = new Object[] {
       new ParDef("SG_LocationSupplierLocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("SG_LocationSupplierOrganisatio",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000611;
       prmT000611 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000612;
       prmT000612 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000613;
       prmT000613 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000614;
       prmT000614 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("SupplierGenAddressCountry",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenLandlineCode",GXType.VarChar,40,0) ,
       new ParDef("SupplierGenPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("SupplierGenContactPhone",GXType.Char,20,0) ,
       new ParDef("SupplierGenLandlineNumber",GXType.VarChar,40,0) ,
       new ParDef("SupplierGenAddressZipCode",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenKvkNumber",GXType.VarChar,8,0) ,
       new ParDef("SupplierGenCompanyName",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenAddressCity",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenAddressLine1",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenAddressLine2",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenContactName",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("SupplierGenLandlineSubNumber",GXType.VarChar,9,0) ,
       new ParDef("SupplierGenEmail",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenWebsite",GXType.VarChar,150,0) ,
       new ParDef("SupplierGenDescription",GXType.LongVarChar,2097152,0) ,
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_OrganisationSupplierId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("SG_LocationSupplierOrganisatio",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("SG_LocationSupplierLocationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000615;
       prmT000615 = new Object[] {
       new ParDef("SupplierGenAddressCountry",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenLandlineCode",GXType.VarChar,40,0) ,
       new ParDef("SupplierGenPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("SupplierGenContactPhone",GXType.Char,20,0) ,
       new ParDef("SupplierGenLandlineNumber",GXType.VarChar,40,0) ,
       new ParDef("SupplierGenAddressZipCode",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenKvkNumber",GXType.VarChar,8,0) ,
       new ParDef("SupplierGenCompanyName",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenAddressCity",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenAddressLine1",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenAddressLine2",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenContactName",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("SupplierGenLandlineSubNumber",GXType.VarChar,9,0) ,
       new ParDef("SupplierGenEmail",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenWebsite",GXType.VarChar,150,0) ,
       new ParDef("SupplierGenDescription",GXType.LongVarChar,2097152,0) ,
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_OrganisationSupplierId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("SG_LocationSupplierOrganisatio",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("SG_LocationSupplierLocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000616;
       prmT000616 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000617;
       prmT000617 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000618;
       prmT000618 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000619;
       prmT000619 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000620;
       prmT000620 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T00062", "SELECT SupplierGenId, SupplierGenAddressCountry, SupplierGenLandlineCode, SupplierGenPhoneCode, SupplierGenContactPhone, SupplierGenLandlineNumber, SupplierGenAddressZipCode, SupplierGenKvkNumber, SupplierGenCompanyName, SupplierGenAddressCity, SupplierGenAddressLine1, SupplierGenAddressLine2, SupplierGenContactName, SupplierGenPhoneNumber, SupplierGenLandlineSubNumber, SupplierGenEmail, SupplierGenWebsite, SupplierGenDescription, SupplierGenTypeId, SG_OrganisationSupplierId, SG_LocationSupplierOrganisatio, SG_LocationSupplierLocationId FROM Trn_SupplierGen WHERE SupplierGenId = :SupplierGenId  FOR UPDATE OF Trn_SupplierGen NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00062,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00063", "SELECT SupplierGenId, SupplierGenAddressCountry, SupplierGenLandlineCode, SupplierGenPhoneCode, SupplierGenContactPhone, SupplierGenLandlineNumber, SupplierGenAddressZipCode, SupplierGenKvkNumber, SupplierGenCompanyName, SupplierGenAddressCity, SupplierGenAddressLine1, SupplierGenAddressLine2, SupplierGenContactName, SupplierGenPhoneNumber, SupplierGenLandlineSubNumber, SupplierGenEmail, SupplierGenWebsite, SupplierGenDescription, SupplierGenTypeId, SG_OrganisationSupplierId, SG_LocationSupplierOrganisatio, SG_LocationSupplierLocationId FROM Trn_SupplierGen WHERE SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00063,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00064", "SELECT SupplierGenTypeName FROM Trn_SupplierGenType WHERE SupplierGenTypeId = :SupplierGenTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00064,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00065", "SELECT OrganisationId AS SG_OrganisationSupplierId FROM Trn_Organisation WHERE OrganisationId = :SG_OrganisationSupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00065,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00066", "SELECT LocationId AS SG_LocationSupplierLocationId FROM Trn_Location WHERE LocationId = :SG_LocationSupplierLocationId AND OrganisationId = :SG_LocationSupplierOrganisatio ",true, GxErrorMask.GX_NOMASK, false, this,prmT00066,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00067", "SELECT TM1.SupplierGenId, TM1.SupplierGenAddressCountry, TM1.SupplierGenLandlineCode, TM1.SupplierGenPhoneCode, TM1.SupplierGenContactPhone, TM1.SupplierGenLandlineNumber, TM1.SupplierGenAddressZipCode, TM1.SupplierGenKvkNumber, T2.SupplierGenTypeName, TM1.SupplierGenCompanyName, TM1.SupplierGenAddressCity, TM1.SupplierGenAddressLine1, TM1.SupplierGenAddressLine2, TM1.SupplierGenContactName, TM1.SupplierGenPhoneNumber, TM1.SupplierGenLandlineSubNumber, TM1.SupplierGenEmail, TM1.SupplierGenWebsite, TM1.SupplierGenDescription, TM1.SupplierGenTypeId, TM1.SG_OrganisationSupplierId AS SG_OrganisationSupplierId, TM1.SG_LocationSupplierOrganisatio AS SG_LocationSupplierOrganisatio, TM1.SG_LocationSupplierLocationId AS SG_LocationSupplierLocationId FROM (Trn_SupplierGen TM1 INNER JOIN Trn_SupplierGenType T2 ON T2.SupplierGenTypeId = TM1.SupplierGenTypeId) WHERE TM1.SupplierGenId = :SupplierGenId ORDER BY TM1.SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00067,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00068", "SELECT SupplierGenTypeName FROM Trn_SupplierGenType WHERE SupplierGenTypeId = :SupplierGenTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00068,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00069", "SELECT OrganisationId AS SG_OrganisationSupplierId FROM Trn_Organisation WHERE OrganisationId = :SG_OrganisationSupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00069,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000610", "SELECT LocationId AS SG_LocationSupplierLocationId FROM Trn_Location WHERE LocationId = :SG_LocationSupplierLocationId AND OrganisationId = :SG_LocationSupplierOrganisatio ",true, GxErrorMask.GX_NOMASK, false, this,prmT000610,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000611", "SELECT SupplierGenId FROM Trn_SupplierGen WHERE SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000611,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000612", "SELECT SupplierGenId FROM Trn_SupplierGen WHERE ( SupplierGenId > :SupplierGenId) ORDER BY SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000612,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000613", "SELECT SupplierGenId FROM Trn_SupplierGen WHERE ( SupplierGenId < :SupplierGenId) ORDER BY SupplierGenId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000613,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000614", "SAVEPOINT gxupdate;INSERT INTO Trn_SupplierGen(SupplierGenId, SupplierGenAddressCountry, SupplierGenLandlineCode, SupplierGenPhoneCode, SupplierGenContactPhone, SupplierGenLandlineNumber, SupplierGenAddressZipCode, SupplierGenKvkNumber, SupplierGenCompanyName, SupplierGenAddressCity, SupplierGenAddressLine1, SupplierGenAddressLine2, SupplierGenContactName, SupplierGenPhoneNumber, SupplierGenLandlineSubNumber, SupplierGenEmail, SupplierGenWebsite, SupplierGenDescription, SupplierGenTypeId, SG_OrganisationSupplierId, SG_LocationSupplierOrganisatio, SG_LocationSupplierLocationId) VALUES(:SupplierGenId, :SupplierGenAddressCountry, :SupplierGenLandlineCode, :SupplierGenPhoneCode, :SupplierGenContactPhone, :SupplierGenLandlineNumber, :SupplierGenAddressZipCode, :SupplierGenKvkNumber, :SupplierGenCompanyName, :SupplierGenAddressCity, :SupplierGenAddressLine1, :SupplierGenAddressLine2, :SupplierGenContactName, :SupplierGenPhoneNumber, :SupplierGenLandlineSubNumber, :SupplierGenEmail, :SupplierGenWebsite, :SupplierGenDescription, :SupplierGenTypeId, :SG_OrganisationSupplierId, :SG_LocationSupplierOrganisatio, :SG_LocationSupplierLocationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000614)
          ,new CursorDef("T000615", "SAVEPOINT gxupdate;UPDATE Trn_SupplierGen SET SupplierGenAddressCountry=:SupplierGenAddressCountry, SupplierGenLandlineCode=:SupplierGenLandlineCode, SupplierGenPhoneCode=:SupplierGenPhoneCode, SupplierGenContactPhone=:SupplierGenContactPhone, SupplierGenLandlineNumber=:SupplierGenLandlineNumber, SupplierGenAddressZipCode=:SupplierGenAddressZipCode, SupplierGenKvkNumber=:SupplierGenKvkNumber, SupplierGenCompanyName=:SupplierGenCompanyName, SupplierGenAddressCity=:SupplierGenAddressCity, SupplierGenAddressLine1=:SupplierGenAddressLine1, SupplierGenAddressLine2=:SupplierGenAddressLine2, SupplierGenContactName=:SupplierGenContactName, SupplierGenPhoneNumber=:SupplierGenPhoneNumber, SupplierGenLandlineSubNumber=:SupplierGenLandlineSubNumber, SupplierGenEmail=:SupplierGenEmail, SupplierGenWebsite=:SupplierGenWebsite, SupplierGenDescription=:SupplierGenDescription, SupplierGenTypeId=:SupplierGenTypeId, SG_OrganisationSupplierId=:SG_OrganisationSupplierId, SG_LocationSupplierOrganisatio=:SG_LocationSupplierOrganisatio, SG_LocationSupplierLocationId=:SG_LocationSupplierLocationId  WHERE SupplierGenId = :SupplierGenId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000615)
          ,new CursorDef("T000616", "SAVEPOINT gxupdate;DELETE FROM Trn_SupplierGen  WHERE SupplierGenId = :SupplierGenId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000616)
          ,new CursorDef("T000617", "SELECT SupplierGenTypeName FROM Trn_SupplierGenType WHERE SupplierGenTypeId = :SupplierGenTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000617,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000618", "SELECT ProductServiceId, LocationId, OrganisationId FROM Trn_ProductService WHERE SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000618,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000619", "SELECT SupplierDynamicFormId, SupplierGenId FROM Trn_SupplierDynamicForm WHERE SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000619,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000620", "SELECT SupplierGenId FROM Trn_SupplierGen ORDER BY SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000620,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((string[]) buf[15])[0] = rslt.getVarchar(16);
             ((string[]) buf[16])[0] = rslt.getVarchar(17);
             ((string[]) buf[17])[0] = rslt.getLongVarchar(18);
             ((Guid[]) buf[18])[0] = rslt.getGuid(19);
             ((Guid[]) buf[19])[0] = rslt.getGuid(20);
             ((bool[]) buf[20])[0] = rslt.wasNull(20);
             ((Guid[]) buf[21])[0] = rslt.getGuid(21);
             ((bool[]) buf[22])[0] = rslt.wasNull(21);
             ((Guid[]) buf[23])[0] = rslt.getGuid(22);
             ((bool[]) buf[24])[0] = rslt.wasNull(22);
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
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((string[]) buf[15])[0] = rslt.getVarchar(16);
             ((string[]) buf[16])[0] = rslt.getVarchar(17);
             ((string[]) buf[17])[0] = rslt.getLongVarchar(18);
             ((Guid[]) buf[18])[0] = rslt.getGuid(19);
             ((Guid[]) buf[19])[0] = rslt.getGuid(20);
             ((bool[]) buf[20])[0] = rslt.wasNull(20);
             ((Guid[]) buf[21])[0] = rslt.getGuid(21);
             ((bool[]) buf[22])[0] = rslt.wasNull(21);
             ((Guid[]) buf[23])[0] = rslt.getGuid(22);
             ((bool[]) buf[24])[0] = rslt.wasNull(22);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
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
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((string[]) buf[15])[0] = rslt.getVarchar(16);
             ((string[]) buf[16])[0] = rslt.getVarchar(17);
             ((string[]) buf[17])[0] = rslt.getVarchar(18);
             ((string[]) buf[18])[0] = rslt.getLongVarchar(19);
             ((Guid[]) buf[19])[0] = rslt.getGuid(20);
             ((Guid[]) buf[20])[0] = rslt.getGuid(21);
             ((bool[]) buf[21])[0] = rslt.wasNull(21);
             ((Guid[]) buf[22])[0] = rslt.getGuid(22);
             ((bool[]) buf[23])[0] = rslt.wasNull(22);
             ((Guid[]) buf[24])[0] = rslt.getGuid(23);
             ((bool[]) buf[25])[0] = rslt.wasNull(23);
             return;
          case 6 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 16 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 17 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 18 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
