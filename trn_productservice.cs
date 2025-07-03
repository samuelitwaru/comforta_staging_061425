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
   public class trn_productservice : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action52") == 0 )
         {
            A58ProductServiceId = StringUtil.StrToGuid( GetPar( "ProductServiceId"));
            n58ProductServiceId = false;
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
            ajax_req_read_hidden_sdt(GetNextPar( ), AV67UploadedFiles);
            ajax_req_read_hidden_sdt(GetNextPar( ), AV68FilesToUpdate);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_52_0868( A58ProductServiceId, AV67UploadedFiles, AV68FilesToUpdate) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"LOCATIONID") == 0 )
         {
            A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLALOCATIONID0868( A11OrganisationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"PRODUCTSERVICEGROUP") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDSAPRODUCTSERVICEGROUP0868( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel35"+"_"+"vSDT_TRNATTRIBUTES") == 0 )
         {
            A58ProductServiceId = StringUtil.StrToGuid( GetPar( "ProductServiceId"));
            n58ProductServiceId = false;
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX35ASASDT_TRNATTRIBUTES0868( A58ProductServiceId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_54") == 0 )
         {
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
            gxLoad_54( A29LocationId, A11OrganisationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_55") == 0 )
         {
            A42SupplierGenId = StringUtil.StrToGuid( GetPar( "SupplierGenId"));
            n42SupplierGenId = false;
            AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_55( A42SupplierGenId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_56") == 0 )
         {
            A49SupplierAgbId = StringUtil.StrToGuid( GetPar( "SupplierAgbId"));
            n49SupplierAgbId = false;
            AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_56( A49SupplierAgbId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_productservice.aspx")), "trn_productservice.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_productservice.aspx")))) ;
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
                  AV12ProductServiceId = StringUtil.StrToGuid( GetPar( "ProductServiceId"));
                  AssignAttri("", false, "AV12ProductServiceId", AV12ProductServiceId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vPRODUCTSERVICEID", GetSecureSignedToken( "", AV12ProductServiceId, context));
                  AV33LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
                  AssignAttri("", false, "AV33LocationId", AV33LocationId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", AV33LocationId, context));
                  AV34OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  AssignAttri("", false, "AV34OrganisationId", AV34OrganisationId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV34OrganisationId, context));
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
         Form.Meta.addItem("description", context.GetMessage( "Trn_Product Service", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = dynLocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_productservice( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_productservice( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_ProductServiceId ,
                           Guid aP2_LocationId ,
                           Guid aP3_OrganisationId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV12ProductServiceId = aP1_ProductServiceId;
         this.AV33LocationId = aP2_LocationId;
         this.AV34OrganisationId = aP3_OrganisationId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynLocationId = new GXCombobox();
         cmbProductServiceClass = new GXCombobox();
         dynProductServiceGroup = new GXCombobox();
         chkavListgen = new GXCheckbox();
         chkavListgenpre = new GXCheckbox();
         chkavListagb = new GXCheckbox();
         chkavListagbpre = new GXCheckbox();
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
            return "trn_productservice_Execute" ;
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
         if ( dynLocationId.ItemCount > 0 )
         {
            A29LocationId = StringUtil.StrToGuid( dynLocationId.getValidValue(A29LocationId.ToString()));
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         }
         if ( context.isAjaxRequest( ) )
         {
            dynLocationId.CurrentValue = A29LocationId.ToString();
            AssignProp("", false, dynLocationId_Internalname, "Values", dynLocationId.ToJavascriptSource(), true);
         }
         if ( cmbProductServiceClass.ItemCount > 0 )
         {
            A370ProductServiceClass = cmbProductServiceClass.getValidValue(A370ProductServiceClass);
            AssignAttri("", false, "A370ProductServiceClass", A370ProductServiceClass);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbProductServiceClass.CurrentValue = StringUtil.RTrim( A370ProductServiceClass);
            AssignProp("", false, cmbProductServiceClass_Internalname, "Values", cmbProductServiceClass.ToJavascriptSource(), true);
         }
         if ( dynProductServiceGroup.ItemCount > 0 )
         {
            A338ProductServiceGroup = dynProductServiceGroup.getValidValue(A338ProductServiceGroup);
            AssignAttri("", false, "A338ProductServiceGroup", A338ProductServiceGroup);
         }
         if ( context.isAjaxRequest( ) )
         {
            dynProductServiceGroup.CurrentValue = StringUtil.RTrim( A338ProductServiceGroup);
            AssignProp("", false, dynProductServiceGroup_Internalname, "Values", dynProductServiceGroup.ToJavascriptSource(), true);
         }
         AV43ListGen = StringUtil.StrToBool( StringUtil.BoolToStr( AV43ListGen));
         AssignAttri("", false, "AV43ListGen", AV43ListGen);
         AV51ListGenPre = StringUtil.StrToBool( StringUtil.BoolToStr( AV51ListGenPre));
         AssignAttri("", false, "AV51ListGenPre", AV51ListGenPre);
         AV42ListAgb = StringUtil.StrToBool( StringUtil.BoolToStr( AV42ListAgb));
         AssignAttri("", false, "AV42ListAgb", AV42ListAgb);
         AV52ListAgbPre = StringUtil.StrToBool( StringUtil.BoolToStr( AV52ListAgbPre));
         AssignAttri("", false, "AV52ListAgbPre", AV52ListAgbPre);
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
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "Service", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_ProductService.htm");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLocationid_cell_Internalname, 1, 0, "px", 0, "px", divLocationid_cell_Class, "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", dynLocationId.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynLocationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynLocationId_Internalname, context.GetMessage( "Location Id", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynLocationId, dynLocationId_Internalname, A29LocationId.ToString(), 1, dynLocationId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "guid", "", dynLocationId.Visible, dynLocationId.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "", true, 0, "HLP_Trn_ProductService.htm");
         dynLocationId.CurrentValue = A29LocationId.ToString();
         AssignProp("", false, dynLocationId_Internalname, "Values", (string)(dynLocationId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductServiceName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductServiceName_Internalname, context.GetMessage( "Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductServiceName_Internalname, A59ProductServiceName, StringUtil.RTrim( context.localUtil.Format( A59ProductServiceName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductServiceName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductServiceName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_ProductService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable6_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "end", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblProductserviceimagetext_Internalname, context.GetMessage( "Images", ""), "", "", lblProductserviceimagetext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_Trn_ProductService.htm");
         GxWebStd.gx_div_end( context, "end", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUcfilecell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* User Defined Control */
         ucImageuploaduc.SetProperty("FailedUploadMessage", Imageuploaduc_Faileduploadmessage);
         ucImageuploaduc.SetProperty("MaxNumberOfFiles", Imageuploaduc_Maxnumberoffiles);
         ucImageuploaduc.SetProperty("isReadOnlyMode", Imageuploaduc_Isreadonlymode);
         ucImageuploaduc.SetProperty("MaxFileSize", Imageuploaduc_Maxfilesize);
         ucImageuploaduc.SetProperty("UploadedFiles", AV67UploadedFiles);
         ucImageuploaduc.SetProperty("FilesToEdit", AV68FilesToUpdate);
         ucImageuploaduc.Render(context, "uc_customimageupload", Imageuploaduc_Internalname, "IMAGEUPLOADUCContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbProductServiceClass_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbProductServiceClass_Internalname, context.GetMessage( "Category", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbProductServiceClass, cmbProductServiceClass_Internalname, StringUtil.RTrim( A370ProductServiceClass), 1, cmbProductServiceClass_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbProductServiceClass.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", true, 0, "HLP_Trn_ProductService.htm");
         cmbProductServiceClass.CurrentValue = StringUtil.RTrim( A370ProductServiceClass);
         AssignProp("", false, cmbProductServiceClass_Internalname, "Values", (string)(cmbProductServiceClass.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynProductServiceGroup_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynProductServiceGroup_Internalname, context.GetMessage( "Delivered By", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynProductServiceGroup, dynProductServiceGroup_Internalname, StringUtil.RTrim( A338ProductServiceGroup), 1, dynProductServiceGroup_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, dynProductServiceGroup.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_Trn_ProductService.htm");
         dynProductServiceGroup.CurrentValue = StringUtil.RTrim( A338ProductServiceGroup);
         AssignProp("", false, dynProductServiceGroup_Internalname, "Values", (string)(dynProductServiceGroup.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSupplierlocation_cell_Internalname, 1, 0, "px", 0, "px", divSupplierlocation_cell_Class, "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", edtavSupplierlocation_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSupplierlocation_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtavSupplierlocation_Internalname, context.GetMessage( "Delivered By", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtavSupplierlocation_Internalname, AV60SupplierLocation, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", 0, edtavSupplierlocation_Visible, edtavSupplierlocation_Enabled, 0, 80, "chr", 5, "row", 0, StyleString, ClassString, "", "", "400", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_ProductService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable4_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablegen_Internalname, divTablegen_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSuppliergen_Internalname, divSuppliergen_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedsuppliergenid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocksuppliergenid_Internalname, context.GetMessage( "Supplier", ""), "", "", lblTextblocksuppliergenid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_ProductService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* Table start */
         sStyleString = "";
         GxWebStd.gx_table_start( context, tblTablemergedsuppliergenid_Internalname, tblTablemergedsuppliergenid_Internalname, "", tblTablemergedsuppliergenid_Class, 0, "", "", 0, 0, sStyleString, "", "", 0);
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td class='MergeDataCell'>") ;
         /* User Defined Control */
         ucCombo_suppliergenid.SetProperty("Caption", Combo_suppliergenid_Caption);
         ucCombo_suppliergenid.SetProperty("Cls", Combo_suppliergenid_Cls);
         ucCombo_suppliergenid.SetProperty("EmptyItem", Combo_suppliergenid_Emptyitem);
         ucCombo_suppliergenid.SetProperty("DropDownOptionsData", AV21SupplierGenId_Data);
         ucCombo_suppliergenid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_suppliergenid_Internalname, "COMBO_SUPPLIERGENIDContainer");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='Invisible'>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenId_Internalname, context.GetMessage( "Supplier Gen Id", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenId_Internalname, A42SupplierGenId.ToString(), A42SupplierGenId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenId_Jsonclick, 0, "Attribute", "", "", "", "", edtSupplierGenId_Visible, edtSupplierGenId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_ProductService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td id=\""+cellListgen_cell_Internalname+"\"  class='"+cellListgen_cell_Class+"'>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkavListgen_Internalname, context.GetMessage( "List Gen", ""), "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkavListgen_Internalname, StringUtil.BoolToStr( AV43ListGen), "", context.GetMessage( "List Gen", ""), chkavListgen.Visible, chkavListgen.Enabled, "true", context.GetMessage( "Preffered", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(80, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,80);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
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
         GxWebStd.gx_div_start( context, divSuppliergenpre_Internalname, divSuppliergenpre_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedsuppliergen_id_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockcombo_suppliergen_id_Internalname, context.GetMessage( "Supplier", ""), "", "", lblTextblockcombo_suppliergen_id_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_ProductService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* Table start */
         sStyleString = "";
         GxWebStd.gx_table_start( context, tblTablemergedsuppliergen_id_Internalname, tblTablemergedsuppliergen_id_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td class='MergeDataCell'>") ;
         /* User Defined Control */
         ucCombo_suppliergen_id.SetProperty("Caption", Combo_suppliergen_id_Caption);
         ucCombo_suppliergen_id.SetProperty("Cls", Combo_suppliergen_id_Cls);
         ucCombo_suppliergen_id.SetProperty("EmptyItem", Combo_suppliergen_id_Emptyitem);
         ucCombo_suppliergen_id.SetProperty("DropDownOptionsTitleSettingsIcons", AV22DDO_TitleSettingsIcons);
         ucCombo_suppliergen_id.SetProperty("DropDownOptionsData", AV49SupplierGen_Id_Data);
         ucCombo_suppliergen_id.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_suppliergen_id_Internalname, "COMBO_SUPPLIERGEN_IDContainer");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td id=\""+cellListgenpre_cell_Internalname+"\"  class='"+cellListgenpre_cell_Class+"'>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkavListgenpre_Internalname, context.GetMessage( "List Gen Pre", ""), "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkavListgenpre_Internalname, StringUtil.BoolToStr( AV51ListGenPre), "", context.GetMessage( "List Gen Pre", ""), chkavListgenpre.Visible, chkavListgenpre.Enabled, "true", context.GetMessage( "Preffered", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(97, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,97);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableagb_Internalname, divTableagb_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSupplieragb_Internalname, divSupplieragb_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedsupplieragbid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocksupplieragbid_Internalname, context.GetMessage( "Agb Suppliers", ""), "", "", lblTextblocksupplieragbid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_ProductService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* Table start */
         sStyleString = "";
         GxWebStd.gx_table_start( context, tblTablemergedsupplieragbid_Internalname, tblTablemergedsupplieragbid_Internalname, "", tblTablemergedsupplieragbid_Class, 0, "", "", 0, 0, sStyleString, "", "", 0);
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td class='MergeDataCell'>") ;
         /* User Defined Control */
         ucCombo_supplieragbid.SetProperty("Caption", Combo_supplieragbid_Caption);
         ucCombo_supplieragbid.SetProperty("Cls", Combo_supplieragbid_Cls);
         ucCombo_supplieragbid.SetProperty("EmptyItem", Combo_supplieragbid_Emptyitem);
         ucCombo_supplieragbid.SetProperty("DropDownOptionsData", AV29SupplierAgbId_Data);
         ucCombo_supplieragbid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_supplieragbid_Internalname, "COMBO_SUPPLIERAGBIDContainer");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='Invisible'>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierAgbId_Internalname, context.GetMessage( "Supplier Agb Id", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierAgbId_Internalname, A49SupplierAgbId.ToString(), A49SupplierAgbId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,117);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierAgbId_Jsonclick, 0, "Attribute", "", "", "", "", edtSupplierAgbId_Visible, edtSupplierAgbId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_ProductService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td id=\""+cellListagb_cell_Internalname+"\"  class='"+cellListagb_cell_Class+"'>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkavListagb_Internalname, context.GetMessage( "List Agb", ""), "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkavListagb_Internalname, StringUtil.BoolToStr( AV42ListAgb), "", context.GetMessage( "List Agb", ""), chkavListagb.Visible, chkavListagb.Enabled, "true", context.GetMessage( "Preffered", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(120, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,120);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
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
         GxWebStd.gx_div_start( context, divSupplieragbpre_Internalname, divSupplieragbpre_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedsupplieragb_id_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockcombo_supplieragb_id_Internalname, context.GetMessage( "Supplier Agb Id", ""), "", "", lblTextblockcombo_supplieragb_id_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_ProductService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* Table start */
         sStyleString = "";
         GxWebStd.gx_table_start( context, tblTablemergedsupplieragb_id_Internalname, tblTablemergedsupplieragb_id_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td class='MergeDataCell'>") ;
         /* User Defined Control */
         ucCombo_supplieragb_id.SetProperty("Caption", Combo_supplieragb_id_Caption);
         ucCombo_supplieragb_id.SetProperty("Cls", Combo_supplieragb_id_Cls);
         ucCombo_supplieragb_id.SetProperty("EmptyItem", Combo_supplieragb_id_Emptyitem);
         ucCombo_supplieragb_id.SetProperty("DropDownOptionsTitleSettingsIcons", AV22DDO_TitleSettingsIcons);
         ucCombo_supplieragb_id.SetProperty("DropDownOptionsData", AV48SupplierAgb_Id_Data);
         ucCombo_supplieragb_id.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_supplieragb_id_Internalname, "COMBO_SUPPLIERAGB_IDContainer");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td id=\""+cellListagbpre_cell_Internalname+"\"  class='"+cellListagbpre_cell_Class+"'>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkavListagbpre_Internalname, context.GetMessage( "List Agb Pre", ""), "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 137,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkavListagbpre_Internalname, StringUtil.BoolToStr( AV52ListAgbPre), "", context.GetMessage( "List Agb Pre", ""), chkavListagbpre.Visible, chkavListagbpre.Enabled, "true", context.GetMessage( "Preffered", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(137, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,137);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
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
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divProductservicedescription_cell_Internalname, 1, 0, "px", 0, "px", divProductservicedescription_cell_Class, "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+Productservicedescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, Productservicedescription_Internalname, context.GetMessage( "Description", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* User Defined Control */
         ucProductservicedescription.SetProperty("Width", Productservicedescription_Width);
         ucProductservicedescription.SetProperty("Height", Productservicedescription_Height);
         ucProductservicedescription.SetProperty("Attribute", ProductServiceDescription);
         ucProductservicedescription.SetProperty("Skin", Productservicedescription_Skin);
         ucProductservicedescription.SetProperty("Toolbar", Productservicedescription_Toolbar);
         ucProductservicedescription.SetProperty("CustomToolbar", Productservicedescription_Customtoolbar);
         ucProductservicedescription.SetProperty("CustomConfiguration", Productservicedescription_Customconfiguration);
         ucProductservicedescription.SetProperty("ToolbarCanCollapse", Productservicedescription_Toolbarcancollapse);
         ucProductservicedescription.SetProperty("CaptionClass", Productservicedescription_Captionclass);
         ucProductservicedescription.SetProperty("CaptionStyle", Productservicedescription_Captionstyle);
         ucProductservicedescription.SetProperty("CaptionPosition", Productservicedescription_Captionposition);
         ucProductservicedescription.Render(context, "fckeditor", Productservicedescription_Internalname, "PRODUCTSERVICEDESCRIPTIONContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divProductsevicetable_Internalname, divProductsevicetable_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockdescriptionlabel_Internalname, context.GetMessage( "Description", ""), "", "", lblTextblockdescriptionlabel_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_Trn_ProductService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable5_Internalname, 1, 0, "px", 0, "px", "HTMLTextOverfow", "start", "top", " "+"data-gx-flex"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblDescriptiontext_Internalname, "", "", "", lblDescriptiontext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DynamicFormHTMLEditor", 0, "", 1, 1, 0, 1, "HLP_Trn_ProductService.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 157,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ProductService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 159,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ProductService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 161,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ProductService.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_suppliergenid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 166,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombosuppliergenid_Internalname, AV26ComboSupplierGenId.ToString(), AV26ComboSupplierGenId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,166);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombosuppliergenid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombosuppliergenid_Visible, edtavCombosuppliergenid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Trn_ProductService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 167,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavSuppliergen_id_Internalname, AV47SupplierGen_Id.ToString(), AV47SupplierGen_Id.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,167);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSuppliergen_id_Jsonclick, 0, "Attribute", "", "", "", "", edtavSuppliergen_id_Visible, edtavSuppliergen_id_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Trn_ProductService.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_supplieragbid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 169,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombosupplieragbid_Internalname, AV30ComboSupplierAgbId.ToString(), AV30ComboSupplierAgbId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,169);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombosupplieragbid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombosupplieragbid_Visible, edtavCombosupplieragbid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Trn_ProductService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 170,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavSupplieragb_id_Internalname, AV46SupplierAgb_Id.ToString(), AV46SupplierAgb_Id.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,170);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSupplieragb_id_Jsonclick, 0, "Attribute", "", "", "", "", edtavSupplieragb_id_Visible, edtavSupplieragb_id_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Trn_ProductService.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 171,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductServiceId_Internalname, A58ProductServiceId.ToString(), A58ProductServiceId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,171);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductServiceId_Jsonclick, 0, "Attribute", "", "", "", "", edtProductServiceId_Visible, edtProductServiceId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_ProductService.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 172,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationId_Internalname, A11OrganisationId.ToString(), A11OrganisationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,172);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationId_Jsonclick, 0, "Attribute", "", "", "", "", edtOrganisationId_Visible, edtOrganisationId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_ProductService.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 173,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductServiceTileName_Internalname, StringUtil.RTrim( A266ProductServiceTileName), StringUtil.RTrim( context.localUtil.Format( A266ProductServiceTileName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,173);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductServiceTileName_Jsonclick, 0, "Attribute", "", "", "", "", edtProductServiceTileName_Visible, edtProductServiceTileName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_ProductService.htm");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 174,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A61ProductServiceImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProductServiceImage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.PathToRelativeUrl( A61ProductServiceImage));
         GxWebStd.gx_bitmap( context, imgProductServiceImage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgProductServiceImage_Visible, imgProductServiceImage_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,174);\"", "", "", "", 0, A61ProductServiceImage_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Trn_ProductService.htm");
         AssignProp("", false, imgProductServiceImage_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.PathToRelativeUrl( A61ProductServiceImage)), true);
         AssignProp("", false, imgProductServiceImage_Internalname, "IsBlob", StringUtil.BoolToStr( A61ProductServiceImage_IsBlob), true);
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
         E11082 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vUPLOADEDFILES"), AV67UploadedFiles);
               ajax_req_read_hidden_sdt(cgiGet( "vFILESTOUPDATE"), AV68FilesToUpdate);
               ajax_req_read_hidden_sdt(cgiGet( "vSUPPLIERGENID_DATA"), AV21SupplierGenId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV22DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vSUPPLIERGEN_ID_DATA"), AV49SupplierGen_Id_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vSUPPLIERAGBID_DATA"), AV29SupplierAgbId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vSUPPLIERAGB_ID_DATA"), AV48SupplierAgb_Id_Data);
               /* Read saved values. */
               Z58ProductServiceId = StringUtil.StrToGuid( cgiGet( "Z58ProductServiceId"));
               Z29LocationId = StringUtil.StrToGuid( cgiGet( "Z29LocationId"));
               Z11OrganisationId = StringUtil.StrToGuid( cgiGet( "Z11OrganisationId"));
               Z59ProductServiceName = cgiGet( "Z59ProductServiceName");
               Z266ProductServiceTileName = cgiGet( "Z266ProductServiceTileName");
               Z370ProductServiceClass = cgiGet( "Z370ProductServiceClass");
               Z338ProductServiceGroup = cgiGet( "Z338ProductServiceGroup");
               Z42SupplierGenId = StringUtil.StrToGuid( cgiGet( "Z42SupplierGenId"));
               Z49SupplierAgbId = StringUtil.StrToGuid( cgiGet( "Z49SupplierAgbId"));
               n49SupplierAgbId = ((Guid.Empty==A49SupplierAgbId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N42SupplierGenId = StringUtil.StrToGuid( cgiGet( "N42SupplierGenId"));
               N49SupplierAgbId = StringUtil.StrToGuid( cgiGet( "N49SupplierAgbId"));
               n49SupplierAgbId = ((Guid.Empty==A49SupplierAgbId) ? true : false);
               AV12ProductServiceId = StringUtil.StrToGuid( cgiGet( "vPRODUCTSERVICEID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV33LocationId = StringUtil.StrToGuid( cgiGet( "vLOCATIONID"));
               AV34OrganisationId = StringUtil.StrToGuid( cgiGet( "vORGANISATIONID"));
               AV10Insert_SupplierGenId = StringUtil.StrToGuid( cgiGet( "vINSERT_SUPPLIERGENID"));
               AV9Insert_SupplierAgbId = StringUtil.StrToGuid( cgiGet( "vINSERT_SUPPLIERAGBID"));
               AV57isManager = StringUtil.StrToBool( cgiGet( "vISMANAGER"));
               ajax_req_read_hidden_sdt(cgiGet( "vSDT_TRNATTRIBUTES"), AV66SDT_TrnAttributes);
               A60ProductServiceDescription = cgiGet( "PRODUCTSERVICEDESCRIPTION");
               A40000ProductServiceImage_GXI = cgiGet( "PRODUCTSERVICEIMAGE_GXI");
               A44SupplierGenCompanyName = cgiGet( "SUPPLIERGENCOMPANYNAME");
               A51SupplierAgbName = cgiGet( "SUPPLIERAGBNAME");
               AV71Pgmname = cgiGet( "vPGMNAME");
               Imageuploaduc_Objectcall = cgiGet( "IMAGEUPLOADUC_Objectcall");
               Imageuploaduc_Class = cgiGet( "IMAGEUPLOADUC_Class");
               Imageuploaduc_Enabled = StringUtil.StrToBool( cgiGet( "IMAGEUPLOADUC_Enabled"));
               Imageuploaduc_Faileduploadmessage = cgiGet( "IMAGEUPLOADUC_Faileduploadmessage");
               Imageuploaduc_Maxnumberoffiles = cgiGet( "IMAGEUPLOADUC_Maxnumberoffiles");
               Imageuploaduc_Isreadonlymode = cgiGet( "IMAGEUPLOADUC_Isreadonlymode");
               Imageuploaduc_Maxfilesize = cgiGet( "IMAGEUPLOADUC_Maxfilesize");
               Imageuploaduc_Visible = StringUtil.StrToBool( cgiGet( "IMAGEUPLOADUC_Visible"));
               Combo_suppliergenid_Objectcall = cgiGet( "COMBO_SUPPLIERGENID_Objectcall");
               Combo_suppliergenid_Class = cgiGet( "COMBO_SUPPLIERGENID_Class");
               Combo_suppliergenid_Icontype = cgiGet( "COMBO_SUPPLIERGENID_Icontype");
               Combo_suppliergenid_Icon = cgiGet( "COMBO_SUPPLIERGENID_Icon");
               Combo_suppliergenid_Caption = cgiGet( "COMBO_SUPPLIERGENID_Caption");
               Combo_suppliergenid_Tooltip = cgiGet( "COMBO_SUPPLIERGENID_Tooltip");
               Combo_suppliergenid_Cls = cgiGet( "COMBO_SUPPLIERGENID_Cls");
               Combo_suppliergenid_Selectedvalue_set = cgiGet( "COMBO_SUPPLIERGENID_Selectedvalue_set");
               Combo_suppliergenid_Selectedvalue_get = cgiGet( "COMBO_SUPPLIERGENID_Selectedvalue_get");
               Combo_suppliergenid_Selectedtext_set = cgiGet( "COMBO_SUPPLIERGENID_Selectedtext_set");
               Combo_suppliergenid_Selectedtext_get = cgiGet( "COMBO_SUPPLIERGENID_Selectedtext_get");
               Combo_suppliergenid_Gamoauthtoken = cgiGet( "COMBO_SUPPLIERGENID_Gamoauthtoken");
               Combo_suppliergenid_Ddointernalname = cgiGet( "COMBO_SUPPLIERGENID_Ddointernalname");
               Combo_suppliergenid_Titlecontrolalign = cgiGet( "COMBO_SUPPLIERGENID_Titlecontrolalign");
               Combo_suppliergenid_Dropdownoptionstype = cgiGet( "COMBO_SUPPLIERGENID_Dropdownoptionstype");
               Combo_suppliergenid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENID_Enabled"));
               Combo_suppliergenid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENID_Visible"));
               Combo_suppliergenid_Titlecontrolidtoreplace = cgiGet( "COMBO_SUPPLIERGENID_Titlecontrolidtoreplace");
               Combo_suppliergenid_Datalisttype = cgiGet( "COMBO_SUPPLIERGENID_Datalisttype");
               Combo_suppliergenid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENID_Allowmultipleselection"));
               Combo_suppliergenid_Datalistfixedvalues = cgiGet( "COMBO_SUPPLIERGENID_Datalistfixedvalues");
               Combo_suppliergenid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENID_Isgriditem"));
               Combo_suppliergenid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENID_Hasdescription"));
               Combo_suppliergenid_Datalistproc = cgiGet( "COMBO_SUPPLIERGENID_Datalistproc");
               Combo_suppliergenid_Datalistprocparametersprefix = cgiGet( "COMBO_SUPPLIERGENID_Datalistprocparametersprefix");
               Combo_suppliergenid_Remoteservicesparameters = cgiGet( "COMBO_SUPPLIERGENID_Remoteservicesparameters");
               Combo_suppliergenid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERGENID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_suppliergenid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENID_Includeonlyselectedoption"));
               Combo_suppliergenid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENID_Includeselectalloption"));
               Combo_suppliergenid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENID_Emptyitem"));
               Combo_suppliergenid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENID_Includeaddnewoption"));
               Combo_suppliergenid_Htmltemplate = cgiGet( "COMBO_SUPPLIERGENID_Htmltemplate");
               Combo_suppliergenid_Multiplevaluestype = cgiGet( "COMBO_SUPPLIERGENID_Multiplevaluestype");
               Combo_suppliergenid_Loadingdata = cgiGet( "COMBO_SUPPLIERGENID_Loadingdata");
               Combo_suppliergenid_Noresultsfound = cgiGet( "COMBO_SUPPLIERGENID_Noresultsfound");
               Combo_suppliergenid_Emptyitemtext = cgiGet( "COMBO_SUPPLIERGENID_Emptyitemtext");
               Combo_suppliergenid_Onlyselectedvalues = cgiGet( "COMBO_SUPPLIERGENID_Onlyselectedvalues");
               Combo_suppliergenid_Selectalltext = cgiGet( "COMBO_SUPPLIERGENID_Selectalltext");
               Combo_suppliergenid_Multiplevaluesseparator = cgiGet( "COMBO_SUPPLIERGENID_Multiplevaluesseparator");
               Combo_suppliergenid_Addnewoptiontext = cgiGet( "COMBO_SUPPLIERGENID_Addnewoptiontext");
               Combo_suppliergenid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERGENID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_suppliergen_id_Objectcall = cgiGet( "COMBO_SUPPLIERGEN_ID_Objectcall");
               Combo_suppliergen_id_Class = cgiGet( "COMBO_SUPPLIERGEN_ID_Class");
               Combo_suppliergen_id_Icontype = cgiGet( "COMBO_SUPPLIERGEN_ID_Icontype");
               Combo_suppliergen_id_Icon = cgiGet( "COMBO_SUPPLIERGEN_ID_Icon");
               Combo_suppliergen_id_Caption = cgiGet( "COMBO_SUPPLIERGEN_ID_Caption");
               Combo_suppliergen_id_Tooltip = cgiGet( "COMBO_SUPPLIERGEN_ID_Tooltip");
               Combo_suppliergen_id_Cls = cgiGet( "COMBO_SUPPLIERGEN_ID_Cls");
               Combo_suppliergen_id_Selectedvalue_set = cgiGet( "COMBO_SUPPLIERGEN_ID_Selectedvalue_set");
               Combo_suppliergen_id_Selectedvalue_get = cgiGet( "COMBO_SUPPLIERGEN_ID_Selectedvalue_get");
               Combo_suppliergen_id_Selectedtext_set = cgiGet( "COMBO_SUPPLIERGEN_ID_Selectedtext_set");
               Combo_suppliergen_id_Selectedtext_get = cgiGet( "COMBO_SUPPLIERGEN_ID_Selectedtext_get");
               Combo_suppliergen_id_Gamoauthtoken = cgiGet( "COMBO_SUPPLIERGEN_ID_Gamoauthtoken");
               Combo_suppliergen_id_Ddointernalname = cgiGet( "COMBO_SUPPLIERGEN_ID_Ddointernalname");
               Combo_suppliergen_id_Titlecontrolalign = cgiGet( "COMBO_SUPPLIERGEN_ID_Titlecontrolalign");
               Combo_suppliergen_id_Dropdownoptionstype = cgiGet( "COMBO_SUPPLIERGEN_ID_Dropdownoptionstype");
               Combo_suppliergen_id_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGEN_ID_Enabled"));
               Combo_suppliergen_id_Visible = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGEN_ID_Visible"));
               Combo_suppliergen_id_Titlecontrolidtoreplace = cgiGet( "COMBO_SUPPLIERGEN_ID_Titlecontrolidtoreplace");
               Combo_suppliergen_id_Datalisttype = cgiGet( "COMBO_SUPPLIERGEN_ID_Datalisttype");
               Combo_suppliergen_id_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGEN_ID_Allowmultipleselection"));
               Combo_suppliergen_id_Datalistfixedvalues = cgiGet( "COMBO_SUPPLIERGEN_ID_Datalistfixedvalues");
               Combo_suppliergen_id_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGEN_ID_Isgriditem"));
               Combo_suppliergen_id_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGEN_ID_Hasdescription"));
               Combo_suppliergen_id_Datalistproc = cgiGet( "COMBO_SUPPLIERGEN_ID_Datalistproc");
               Combo_suppliergen_id_Datalistprocparametersprefix = cgiGet( "COMBO_SUPPLIERGEN_ID_Datalistprocparametersprefix");
               Combo_suppliergen_id_Remoteservicesparameters = cgiGet( "COMBO_SUPPLIERGEN_ID_Remoteservicesparameters");
               Combo_suppliergen_id_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERGEN_ID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_suppliergen_id_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGEN_ID_Includeonlyselectedoption"));
               Combo_suppliergen_id_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGEN_ID_Includeselectalloption"));
               Combo_suppliergen_id_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGEN_ID_Emptyitem"));
               Combo_suppliergen_id_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGEN_ID_Includeaddnewoption"));
               Combo_suppliergen_id_Htmltemplate = cgiGet( "COMBO_SUPPLIERGEN_ID_Htmltemplate");
               Combo_suppliergen_id_Multiplevaluestype = cgiGet( "COMBO_SUPPLIERGEN_ID_Multiplevaluestype");
               Combo_suppliergen_id_Loadingdata = cgiGet( "COMBO_SUPPLIERGEN_ID_Loadingdata");
               Combo_suppliergen_id_Noresultsfound = cgiGet( "COMBO_SUPPLIERGEN_ID_Noresultsfound");
               Combo_suppliergen_id_Emptyitemtext = cgiGet( "COMBO_SUPPLIERGEN_ID_Emptyitemtext");
               Combo_suppliergen_id_Onlyselectedvalues = cgiGet( "COMBO_SUPPLIERGEN_ID_Onlyselectedvalues");
               Combo_suppliergen_id_Selectalltext = cgiGet( "COMBO_SUPPLIERGEN_ID_Selectalltext");
               Combo_suppliergen_id_Multiplevaluesseparator = cgiGet( "COMBO_SUPPLIERGEN_ID_Multiplevaluesseparator");
               Combo_suppliergen_id_Addnewoptiontext = cgiGet( "COMBO_SUPPLIERGEN_ID_Addnewoptiontext");
               Combo_suppliergen_id_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERGEN_ID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_supplieragbid_Objectcall = cgiGet( "COMBO_SUPPLIERAGBID_Objectcall");
               Combo_supplieragbid_Class = cgiGet( "COMBO_SUPPLIERAGBID_Class");
               Combo_supplieragbid_Icontype = cgiGet( "COMBO_SUPPLIERAGBID_Icontype");
               Combo_supplieragbid_Icon = cgiGet( "COMBO_SUPPLIERAGBID_Icon");
               Combo_supplieragbid_Caption = cgiGet( "COMBO_SUPPLIERAGBID_Caption");
               Combo_supplieragbid_Tooltip = cgiGet( "COMBO_SUPPLIERAGBID_Tooltip");
               Combo_supplieragbid_Cls = cgiGet( "COMBO_SUPPLIERAGBID_Cls");
               Combo_supplieragbid_Selectedvalue_set = cgiGet( "COMBO_SUPPLIERAGBID_Selectedvalue_set");
               Combo_supplieragbid_Selectedvalue_get = cgiGet( "COMBO_SUPPLIERAGBID_Selectedvalue_get");
               Combo_supplieragbid_Selectedtext_set = cgiGet( "COMBO_SUPPLIERAGBID_Selectedtext_set");
               Combo_supplieragbid_Selectedtext_get = cgiGet( "COMBO_SUPPLIERAGBID_Selectedtext_get");
               Combo_supplieragbid_Gamoauthtoken = cgiGet( "COMBO_SUPPLIERAGBID_Gamoauthtoken");
               Combo_supplieragbid_Ddointernalname = cgiGet( "COMBO_SUPPLIERAGBID_Ddointernalname");
               Combo_supplieragbid_Titlecontrolalign = cgiGet( "COMBO_SUPPLIERAGBID_Titlecontrolalign");
               Combo_supplieragbid_Dropdownoptionstype = cgiGet( "COMBO_SUPPLIERAGBID_Dropdownoptionstype");
               Combo_supplieragbid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBID_Enabled"));
               Combo_supplieragbid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBID_Visible"));
               Combo_supplieragbid_Titlecontrolidtoreplace = cgiGet( "COMBO_SUPPLIERAGBID_Titlecontrolidtoreplace");
               Combo_supplieragbid_Datalisttype = cgiGet( "COMBO_SUPPLIERAGBID_Datalisttype");
               Combo_supplieragbid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBID_Allowmultipleselection"));
               Combo_supplieragbid_Datalistfixedvalues = cgiGet( "COMBO_SUPPLIERAGBID_Datalistfixedvalues");
               Combo_supplieragbid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBID_Isgriditem"));
               Combo_supplieragbid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBID_Hasdescription"));
               Combo_supplieragbid_Datalistproc = cgiGet( "COMBO_SUPPLIERAGBID_Datalistproc");
               Combo_supplieragbid_Datalistprocparametersprefix = cgiGet( "COMBO_SUPPLIERAGBID_Datalistprocparametersprefix");
               Combo_supplieragbid_Remoteservicesparameters = cgiGet( "COMBO_SUPPLIERAGBID_Remoteservicesparameters");
               Combo_supplieragbid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERAGBID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_supplieragbid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBID_Includeonlyselectedoption"));
               Combo_supplieragbid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBID_Includeselectalloption"));
               Combo_supplieragbid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBID_Emptyitem"));
               Combo_supplieragbid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBID_Includeaddnewoption"));
               Combo_supplieragbid_Htmltemplate = cgiGet( "COMBO_SUPPLIERAGBID_Htmltemplate");
               Combo_supplieragbid_Multiplevaluestype = cgiGet( "COMBO_SUPPLIERAGBID_Multiplevaluestype");
               Combo_supplieragbid_Loadingdata = cgiGet( "COMBO_SUPPLIERAGBID_Loadingdata");
               Combo_supplieragbid_Noresultsfound = cgiGet( "COMBO_SUPPLIERAGBID_Noresultsfound");
               Combo_supplieragbid_Emptyitemtext = cgiGet( "COMBO_SUPPLIERAGBID_Emptyitemtext");
               Combo_supplieragbid_Onlyselectedvalues = cgiGet( "COMBO_SUPPLIERAGBID_Onlyselectedvalues");
               Combo_supplieragbid_Selectalltext = cgiGet( "COMBO_SUPPLIERAGBID_Selectalltext");
               Combo_supplieragbid_Multiplevaluesseparator = cgiGet( "COMBO_SUPPLIERAGBID_Multiplevaluesseparator");
               Combo_supplieragbid_Addnewoptiontext = cgiGet( "COMBO_SUPPLIERAGBID_Addnewoptiontext");
               Combo_supplieragbid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERAGBID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_supplieragb_id_Objectcall = cgiGet( "COMBO_SUPPLIERAGB_ID_Objectcall");
               Combo_supplieragb_id_Class = cgiGet( "COMBO_SUPPLIERAGB_ID_Class");
               Combo_supplieragb_id_Icontype = cgiGet( "COMBO_SUPPLIERAGB_ID_Icontype");
               Combo_supplieragb_id_Icon = cgiGet( "COMBO_SUPPLIERAGB_ID_Icon");
               Combo_supplieragb_id_Caption = cgiGet( "COMBO_SUPPLIERAGB_ID_Caption");
               Combo_supplieragb_id_Tooltip = cgiGet( "COMBO_SUPPLIERAGB_ID_Tooltip");
               Combo_supplieragb_id_Cls = cgiGet( "COMBO_SUPPLIERAGB_ID_Cls");
               Combo_supplieragb_id_Selectedvalue_set = cgiGet( "COMBO_SUPPLIERAGB_ID_Selectedvalue_set");
               Combo_supplieragb_id_Selectedvalue_get = cgiGet( "COMBO_SUPPLIERAGB_ID_Selectedvalue_get");
               Combo_supplieragb_id_Selectedtext_set = cgiGet( "COMBO_SUPPLIERAGB_ID_Selectedtext_set");
               Combo_supplieragb_id_Selectedtext_get = cgiGet( "COMBO_SUPPLIERAGB_ID_Selectedtext_get");
               Combo_supplieragb_id_Gamoauthtoken = cgiGet( "COMBO_SUPPLIERAGB_ID_Gamoauthtoken");
               Combo_supplieragb_id_Ddointernalname = cgiGet( "COMBO_SUPPLIERAGB_ID_Ddointernalname");
               Combo_supplieragb_id_Titlecontrolalign = cgiGet( "COMBO_SUPPLIERAGB_ID_Titlecontrolalign");
               Combo_supplieragb_id_Dropdownoptionstype = cgiGet( "COMBO_SUPPLIERAGB_ID_Dropdownoptionstype");
               Combo_supplieragb_id_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGB_ID_Enabled"));
               Combo_supplieragb_id_Visible = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGB_ID_Visible"));
               Combo_supplieragb_id_Titlecontrolidtoreplace = cgiGet( "COMBO_SUPPLIERAGB_ID_Titlecontrolidtoreplace");
               Combo_supplieragb_id_Datalisttype = cgiGet( "COMBO_SUPPLIERAGB_ID_Datalisttype");
               Combo_supplieragb_id_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGB_ID_Allowmultipleselection"));
               Combo_supplieragb_id_Datalistfixedvalues = cgiGet( "COMBO_SUPPLIERAGB_ID_Datalistfixedvalues");
               Combo_supplieragb_id_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGB_ID_Isgriditem"));
               Combo_supplieragb_id_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGB_ID_Hasdescription"));
               Combo_supplieragb_id_Datalistproc = cgiGet( "COMBO_SUPPLIERAGB_ID_Datalistproc");
               Combo_supplieragb_id_Datalistprocparametersprefix = cgiGet( "COMBO_SUPPLIERAGB_ID_Datalistprocparametersprefix");
               Combo_supplieragb_id_Remoteservicesparameters = cgiGet( "COMBO_SUPPLIERAGB_ID_Remoteservicesparameters");
               Combo_supplieragb_id_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERAGB_ID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_supplieragb_id_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGB_ID_Includeonlyselectedoption"));
               Combo_supplieragb_id_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGB_ID_Includeselectalloption"));
               Combo_supplieragb_id_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGB_ID_Emptyitem"));
               Combo_supplieragb_id_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGB_ID_Includeaddnewoption"));
               Combo_supplieragb_id_Htmltemplate = cgiGet( "COMBO_SUPPLIERAGB_ID_Htmltemplate");
               Combo_supplieragb_id_Multiplevaluestype = cgiGet( "COMBO_SUPPLIERAGB_ID_Multiplevaluestype");
               Combo_supplieragb_id_Loadingdata = cgiGet( "COMBO_SUPPLIERAGB_ID_Loadingdata");
               Combo_supplieragb_id_Noresultsfound = cgiGet( "COMBO_SUPPLIERAGB_ID_Noresultsfound");
               Combo_supplieragb_id_Emptyitemtext = cgiGet( "COMBO_SUPPLIERAGB_ID_Emptyitemtext");
               Combo_supplieragb_id_Onlyselectedvalues = cgiGet( "COMBO_SUPPLIERAGB_ID_Onlyselectedvalues");
               Combo_supplieragb_id_Selectalltext = cgiGet( "COMBO_SUPPLIERAGB_ID_Selectalltext");
               Combo_supplieragb_id_Multiplevaluesseparator = cgiGet( "COMBO_SUPPLIERAGB_ID_Multiplevaluesseparator");
               Combo_supplieragb_id_Addnewoptiontext = cgiGet( "COMBO_SUPPLIERAGB_ID_Addnewoptiontext");
               Combo_supplieragb_id_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERAGB_ID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Productservicedescription_Objectcall = cgiGet( "PRODUCTSERVICEDESCRIPTION_Objectcall");
               Productservicedescription_Class = cgiGet( "PRODUCTSERVICEDESCRIPTION_Class");
               Productservicedescription_Enabled = StringUtil.StrToBool( cgiGet( "PRODUCTSERVICEDESCRIPTION_Enabled"));
               Productservicedescription_Width = cgiGet( "PRODUCTSERVICEDESCRIPTION_Width");
               Productservicedescription_Height = cgiGet( "PRODUCTSERVICEDESCRIPTION_Height");
               Productservicedescription_Skin = cgiGet( "PRODUCTSERVICEDESCRIPTION_Skin");
               Productservicedescription_Toolbar = cgiGet( "PRODUCTSERVICEDESCRIPTION_Toolbar");
               Productservicedescription_Customtoolbar = cgiGet( "PRODUCTSERVICEDESCRIPTION_Customtoolbar");
               Productservicedescription_Customconfiguration = cgiGet( "PRODUCTSERVICEDESCRIPTION_Customconfiguration");
               Productservicedescription_Toolbarcancollapse = StringUtil.StrToBool( cgiGet( "PRODUCTSERVICEDESCRIPTION_Toolbarcancollapse"));
               Productservicedescription_Toolbarexpanded = StringUtil.StrToBool( cgiGet( "PRODUCTSERVICEDESCRIPTION_Toolbarexpanded"));
               Productservicedescription_Color = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTSERVICEDESCRIPTION_Color"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Productservicedescription_Buttonpressedid = cgiGet( "PRODUCTSERVICEDESCRIPTION_Buttonpressedid");
               Productservicedescription_Captionvalue = cgiGet( "PRODUCTSERVICEDESCRIPTION_Captionvalue");
               Productservicedescription_Captionclass = cgiGet( "PRODUCTSERVICEDESCRIPTION_Captionclass");
               Productservicedescription_Captionstyle = cgiGet( "PRODUCTSERVICEDESCRIPTION_Captionstyle");
               Productservicedescription_Captionposition = cgiGet( "PRODUCTSERVICEDESCRIPTION_Captionposition");
               Productservicedescription_Isabstractlayoutcontrol = StringUtil.StrToBool( cgiGet( "PRODUCTSERVICEDESCRIPTION_Isabstractlayoutcontrol"));
               Productservicedescription_Coltitle = cgiGet( "PRODUCTSERVICEDESCRIPTION_Coltitle");
               Productservicedescription_Coltitlefont = cgiGet( "PRODUCTSERVICEDESCRIPTION_Coltitlefont");
               Productservicedescription_Coltitlecolor = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTSERVICEDESCRIPTION_Coltitlecolor"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Productservicedescription_Usercontroliscolumn = StringUtil.StrToBool( cgiGet( "PRODUCTSERVICEDESCRIPTION_Usercontroliscolumn"));
               Productservicedescription_Visible = StringUtil.StrToBool( cgiGet( "PRODUCTSERVICEDESCRIPTION_Visible"));
               /* Read variables values. */
               dynLocationId.CurrentValue = cgiGet( dynLocationId_Internalname);
               A29LocationId = StringUtil.StrToGuid( cgiGet( dynLocationId_Internalname));
               AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
               A59ProductServiceName = cgiGet( edtProductServiceName_Internalname);
               AssignAttri("", false, "A59ProductServiceName", A59ProductServiceName);
               cmbProductServiceClass.CurrentValue = cgiGet( cmbProductServiceClass_Internalname);
               A370ProductServiceClass = cgiGet( cmbProductServiceClass_Internalname);
               AssignAttri("", false, "A370ProductServiceClass", A370ProductServiceClass);
               dynProductServiceGroup.CurrentValue = cgiGet( dynProductServiceGroup_Internalname);
               A338ProductServiceGroup = cgiGet( dynProductServiceGroup_Internalname);
               AssignAttri("", false, "A338ProductServiceGroup", A338ProductServiceGroup);
               AV60SupplierLocation = cgiGet( edtavSupplierlocation_Internalname);
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
               AV43ListGen = StringUtil.StrToBool( cgiGet( chkavListgen_Internalname));
               AssignAttri("", false, "AV43ListGen", AV43ListGen);
               AV51ListGenPre = StringUtil.StrToBool( cgiGet( chkavListgenpre_Internalname));
               AssignAttri("", false, "AV51ListGenPre", AV51ListGenPre);
               if ( StringUtil.StrCmp(cgiGet( edtSupplierAgbId_Internalname), "") == 0 )
               {
                  A49SupplierAgbId = Guid.Empty;
                  n49SupplierAgbId = false;
                  AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
               }
               else
               {
                  try
                  {
                     A49SupplierAgbId = StringUtil.StrToGuid( cgiGet( edtSupplierAgbId_Internalname));
                     n49SupplierAgbId = false;
                     AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "SUPPLIERAGBID");
                     AnyError = 1;
                     GX_FocusControl = edtSupplierAgbId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               n49SupplierAgbId = ((Guid.Empty==A49SupplierAgbId) ? true : false);
               AV42ListAgb = StringUtil.StrToBool( cgiGet( chkavListagb_Internalname));
               AssignAttri("", false, "AV42ListAgb", AV42ListAgb);
               AV52ListAgbPre = StringUtil.StrToBool( cgiGet( chkavListagbpre_Internalname));
               AssignAttri("", false, "AV52ListAgbPre", AV52ListAgbPre);
               AV26ComboSupplierGenId = StringUtil.StrToGuid( cgiGet( edtavCombosuppliergenid_Internalname));
               AssignAttri("", false, "AV26ComboSupplierGenId", AV26ComboSupplierGenId.ToString());
               AV47SupplierGen_Id = StringUtil.StrToGuid( cgiGet( edtavSuppliergen_id_Internalname));
               AssignAttri("", false, "AV47SupplierGen_Id", AV47SupplierGen_Id.ToString());
               AV30ComboSupplierAgbId = StringUtil.StrToGuid( cgiGet( edtavCombosupplieragbid_Internalname));
               AssignAttri("", false, "AV30ComboSupplierAgbId", AV30ComboSupplierAgbId.ToString());
               AV46SupplierAgb_Id = StringUtil.StrToGuid( cgiGet( edtavSupplieragb_id_Internalname));
               AssignAttri("", false, "AV46SupplierAgb_Id", AV46SupplierAgb_Id.ToString());
               if ( StringUtil.StrCmp(cgiGet( edtProductServiceId_Internalname), "") == 0 )
               {
                  A58ProductServiceId = Guid.Empty;
                  n58ProductServiceId = false;
                  AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
               }
               else
               {
                  try
                  {
                     A58ProductServiceId = StringUtil.StrToGuid( cgiGet( edtProductServiceId_Internalname));
                     n58ProductServiceId = false;
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
               A266ProductServiceTileName = cgiGet( edtProductServiceTileName_Internalname);
               AssignAttri("", false, "A266ProductServiceTileName", A266ProductServiceTileName);
               A61ProductServiceImage = cgiGet( imgProductServiceImage_Internalname);
               AssignAttri("", false, "A61ProductServiceImage", A61ProductServiceImage);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgProductServiceImage_Internalname, ref  A61ProductServiceImage, ref  A40000ProductServiceImage_GXI);
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_ProductService");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A58ProductServiceId != Z58ProductServiceId ) || ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_productservice:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A58ProductServiceId = StringUtil.StrToGuid( GetPar( "ProductServiceId"));
                  n58ProductServiceId = false;
                  AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
                  A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
                  AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
                  A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV12ProductServiceId) )
                  {
                     A58ProductServiceId = AV12ProductServiceId;
                     n58ProductServiceId = false;
                     AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A58ProductServiceId) && ( Gx_BScreen == 0 ) )
                     {
                        A58ProductServiceId = Guid.NewGuid( );
                        n58ProductServiceId = false;
                        AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
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
                     sMode68 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV12ProductServiceId) )
                     {
                        A58ProductServiceId = AV12ProductServiceId;
                        n58ProductServiceId = false;
                        AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A58ProductServiceId) && ( Gx_BScreen == 0 ) )
                        {
                           A58ProductServiceId = Guid.NewGuid( );
                           n58ProductServiceId = false;
                           AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
                        }
                     }
                     Gx_mode = sMode68;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound68 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_080( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PRODUCTSERVICEID");
                        AnyError = 1;
                        GX_FocusControl = edtProductServiceId_Internalname;
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
                        if ( StringUtil.StrCmp(sEvt, "COMBO_SUPPLIERGENID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Combo_suppliergenid.Onoptionclicked */
                           E12082 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "COMBO_SUPPLIERGEN_ID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Combo_suppliergen_id.Onoptionclicked */
                           E13082 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "COMBO_SUPPLIERAGBID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Combo_supplieragbid.Onoptionclicked */
                           E14082 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "COMBO_SUPPLIERAGB_ID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Combo_supplieragb_id.Onoptionclicked */
                           E15082 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11082 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E16082 ();
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
            E16082 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0868( ) ;
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
            DisableAttributes0868( ) ;
         }
         AssignProp("", false, edtavSupplierlocation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSupplierlocation_Enabled), 5, 0), true);
         AssignProp("", false, chkavListgen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavListgen.Enabled), 5, 0), true);
         AssignProp("", false, chkavListgenpre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavListgenpre.Enabled), 5, 0), true);
         AssignProp("", false, chkavListagb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavListagb.Enabled), 5, 0), true);
         AssignProp("", false, chkavListagbpre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavListagbpre.Enabled), 5, 0), true);
         AssignProp("", false, edtavCombosuppliergenid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosuppliergenid_Enabled), 5, 0), true);
         AssignProp("", false, edtavSuppliergen_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSuppliergen_id_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombosupplieragbid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosupplieragbid_Enabled), 5, 0), true);
         AssignProp("", false, edtavSupplieragb_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSupplieragb_id_Enabled), 5, 0), true);
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

      protected void CONFIRM_080( )
      {
         BeforeValidate0868( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0868( ) ;
            }
            else
            {
               CheckExtendedTable0868( ) ;
               CloseExtendedTableCursors0868( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption080( )
      {
      }

      protected void E11082( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_objcol_guid1 = AV41PreferredGenSuppliers;
         new prc_getpreferredgensuppliers(context ).execute( ref  GXt_objcol_guid1) ;
         AV41PreferredGenSuppliers = GXt_objcol_guid1;
         AV67UploadedFiles = new GXBaseCollection<SdtSDT_FileUploadData>( context, "SDT_FileUploadData", "Comforta_version2");
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV19WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV22DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV22DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         edtavSupplieragb_id_Visible = 0;
         AssignProp("", false, edtavSupplieragb_id_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSupplieragb_id_Visible), 5, 0), true);
         edtSupplierAgbId_Visible = 0;
         AssignProp("", false, edtSupplierAgbId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierAgbId_Visible), 5, 0), true);
         AV30ComboSupplierAgbId = Guid.Empty;
         AssignAttri("", false, "AV30ComboSupplierAgbId", AV30ComboSupplierAgbId.ToString());
         edtavCombosupplieragbid_Visible = 0;
         AssignProp("", false, edtavCombosupplieragbid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombosupplieragbid_Visible), 5, 0), true);
         edtavSuppliergen_id_Visible = 0;
         AssignProp("", false, edtavSuppliergen_id_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSuppliergen_id_Visible), 5, 0), true);
         edtSupplierGenId_Visible = 0;
         AssignProp("", false, edtSupplierGenId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierGenId_Visible), 5, 0), true);
         AV26ComboSupplierGenId = Guid.Empty;
         AssignAttri("", false, "AV26ComboSupplierGenId", AV26ComboSupplierGenId.ToString());
         edtavCombosuppliergenid_Visible = 0;
         AssignProp("", false, edtavCombosuppliergenid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombosuppliergenid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERGENID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERGEN_ID' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERAGBID' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERAGB_ID' */
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
         AV16TrnContext.FromXml(AV18WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV16TrnContext.gxTpr_Transactionname, AV71Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV72GXV1 = 1;
            AssignAttri("", false, "AV72GXV1", StringUtil.LTrimStr( (decimal)(AV72GXV1), 8, 0));
            while ( AV72GXV1 <= AV16TrnContext.gxTpr_Attributes.Count )
            {
               AV17TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV16TrnContext.gxTpr_Attributes.Item(AV72GXV1));
               if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "SupplierGenId") == 0 )
               {
                  AV10Insert_SupplierGenId = StringUtil.StrToGuid( AV17TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV10Insert_SupplierGenId", AV10Insert_SupplierGenId.ToString());
                  if ( ! (Guid.Empty==AV10Insert_SupplierGenId) )
                  {
                     AV26ComboSupplierGenId = AV10Insert_SupplierGenId;
                     AssignAttri("", false, "AV26ComboSupplierGenId", AV26ComboSupplierGenId.ToString());
                     Combo_suppliergenid_Selectedvalue_set = StringUtil.Trim( AV26ComboSupplierGenId.ToString());
                     ucCombo_suppliergenid.SendProperty(context, "", false, Combo_suppliergenid_Internalname, "SelectedValue_set", Combo_suppliergenid_Selectedvalue_set);
                     Combo_suppliergenid_Enabled = false;
                     ucCombo_suppliergenid.SendProperty(context, "", false, Combo_suppliergenid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_suppliergenid_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "SupplierAgbId") == 0 )
               {
                  AV9Insert_SupplierAgbId = StringUtil.StrToGuid( AV17TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV9Insert_SupplierAgbId", AV9Insert_SupplierAgbId.ToString());
                  if ( ! (Guid.Empty==AV9Insert_SupplierAgbId) )
                  {
                     AV30ComboSupplierAgbId = AV9Insert_SupplierAgbId;
                     AssignAttri("", false, "AV30ComboSupplierAgbId", AV30ComboSupplierAgbId.ToString());
                     Combo_supplieragbid_Selectedvalue_set = StringUtil.Trim( AV30ComboSupplierAgbId.ToString());
                     ucCombo_supplieragbid.SendProperty(context, "", false, Combo_supplieragbid_Internalname, "SelectedValue_set", Combo_supplieragbid_Selectedvalue_set);
                     Combo_supplieragbid_Enabled = false;
                     ucCombo_supplieragbid.SendProperty(context, "", false, Combo_supplieragbid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_supplieragbid_Enabled));
                  }
               }
               AV72GXV1 = (int)(AV72GXV1+1);
               AssignAttri("", false, "AV72GXV1", StringUtil.LTrimStr( (decimal)(AV72GXV1), 8, 0));
            }
         }
         edtProductServiceId_Visible = 0;
         AssignProp("", false, edtProductServiceId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Visible), 5, 0), true);
         edtOrganisationId_Visible = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Visible), 5, 0), true);
         edtProductServiceTileName_Visible = 0;
         AssignProp("", false, edtProductServiceTileName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProductServiceTileName_Visible), 5, 0), true);
         imgProductServiceImage_Visible = 0;
         AssignProp("", false, imgProductServiceImage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgProductServiceImage_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            tblTablemergedsuppliergenid_Class = "MergedCustomTableServiceSupplierDelete";
            AssignProp("", false, tblTablemergedsuppliergenid_Internalname, "Class", tblTablemergedsuppliergenid_Class, true);
            tblTablemergedsupplieragbid_Class = "MergedCustomTableServiceSupplierDelete";
            AssignProp("", false, tblTablemergedsupplieragbid_Internalname, "Class", tblTablemergedsupplieragbid_Class, true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            GXt_objcol_SdtSDT_FileUploadData3 = AV68FilesToUpdate;
            new prc_getserviceimages(context ).execute(  AV12ProductServiceId, out  GXt_objcol_SdtSDT_FileUploadData3) ;
            AV68FilesToUpdate = GXt_objcol_SdtSDT_FileUploadData3;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
         }
         else
         {
         }
         /* Execute user subroutine: 'SETSTATEOFSUPPLIER' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV57isManager = (bool)(AV19WWPContext.gxTpr_Isorganisationmanager||AV19WWPContext.gxTpr_Isrootadmin);
         AssignAttri("", false, "AV57isManager", AV57isManager);
      }

      protected void E16082( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( AV19WWPContext.gxTpr_Isreceptionist )
         {
            AV61RoleName = context.GetMessage( "Receptionist", "");
            AssignAttri("", false, "AV61RoleName", AV61RoleName);
            GxWebStd.gx_hidden_field( context, "gxhash_vROLENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV61RoleName, "")), context));
         }
         if ( AV19WWPContext.gxTpr_Isorganisationmanager )
         {
            AV61RoleName = context.GetMessage( "Manager", "");
            AssignAttri("", false, "AV61RoleName", AV61RoleName);
            GxWebStd.gx_hidden_field( context, "gxhash_vROLENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV61RoleName, "")), context));
         }
         AV53IsWeb = true;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV63SDT_NotificationMetadata = new SdtSDT_NotificationMetadata(context);
            AV63SDT_NotificationMetadata.gxTpr_Isparentnotification = true;
            AV63SDT_NotificationMetadata.gxTpr_Parentnotificationid = A58ProductServiceId.ToString();
            AV63SDT_NotificationMetadata.gxTpr_Notificationtriggeredtimestamp = DateTimeUtil.Now( context);
            AV63SDT_NotificationMetadata.gxTpr_Notificationorigin = "Product/Service";
            AV64WWPNotificationMetadataSDT = new SdtUSDTNotificationMetadata(context);
            AV64WWPNotificationMetadataSDT.gxTpr_Custommetadata = AV63SDT_NotificationMetadata;
            GXt_char4 = AV62NotificationDescription;
            GXt_char5 = AV62NotificationDescription;
            new uwwp_getloggeduserid(context ).execute( out  GXt_char5) ;
            new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  GXt_char5, out  GXt_char4) ;
            AV62NotificationDescription = StringUtil.Format( context.GetMessage( "%1 added by %2 %3", ""), A59ProductServiceName, AV61RoleName, GXt_char4, "", "", "", "", "", "");
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_productserviceview.aspx"+UrlEncode(A58ProductServiceId.ToString()) + "," + UrlEncode(A29LocationId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            AV55NotificationLink = formatLink("trn_productserviceview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendnotification(context ).execute(  "InsertRecord",  "Trn_ProductService",  "",  context.GetMessage( "fas fa-plus NotificationFontIconSuccess", ""),  context.GetMessage( "New Service", ""),  AV62NotificationDescription,  AV62NotificationDescription,  AV55NotificationLink,  AV64WWPNotificationMetadataSDT.ToJSonString(false, true),  "",  AV53IsWeb) ;
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV63SDT_NotificationMetadata = new SdtSDT_NotificationMetadata(context);
            AV63SDT_NotificationMetadata.gxTpr_Isparentnotification = false;
            AV63SDT_NotificationMetadata.gxTpr_Parentnotificationid = A58ProductServiceId.ToString();
            AV63SDT_NotificationMetadata.gxTpr_Notificationtriggeredtimestamp = DateTimeUtil.Now( context);
            AV63SDT_NotificationMetadata.gxTpr_Notificationorigin = "Product/Service";
            AV64WWPNotificationMetadataSDT = new SdtUSDTNotificationMetadata(context);
            AV64WWPNotificationMetadataSDT.gxTpr_Custommetadata = AV63SDT_NotificationMetadata;
            GXt_char5 = AV62NotificationDescription;
            GXt_char4 = AV62NotificationDescription;
            new uwwp_getloggeduserid(context ).execute( out  GXt_char4) ;
            new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  GXt_char4, out  GXt_char5) ;
            AV62NotificationDescription = StringUtil.Format( context.GetMessage( "%1 updated by %2 %3", ""), A59ProductServiceName, AV61RoleName, GXt_char5, "", "", "", "", "", "");
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_productserviceview.aspx"+UrlEncode(A58ProductServiceId.ToString()) + "," + UrlEncode(A29LocationId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            AV55NotificationLink = formatLink("trn_productserviceview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendnotification(context ).execute(  "UpdateRecord",  "Trn_ProductService",  "",  context.GetMessage( "fas fa-pencil-alt NotificationFontIconWarning", ""),  context.GetMessage( "Service Updated", ""),  AV62NotificationDescription,  AV62NotificationDescription,  AV55NotificationLink,  AV64WWPNotificationMetadataSDT.ToJSonString(false, true),  "",  AV53IsWeb) ;
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV63SDT_NotificationMetadata = new SdtSDT_NotificationMetadata(context);
            AV63SDT_NotificationMetadata.gxTpr_Isparentnotification = false;
            AV63SDT_NotificationMetadata.gxTpr_Parentnotificationid = A58ProductServiceId.ToString();
            AV63SDT_NotificationMetadata.gxTpr_Notificationtriggeredtimestamp = DateTimeUtil.Now( context);
            AV63SDT_NotificationMetadata.gxTpr_Notificationorigin = "Product/Service";
            AV64WWPNotificationMetadataSDT = new SdtUSDTNotificationMetadata(context);
            AV64WWPNotificationMetadataSDT.gxTpr_Custommetadata = AV63SDT_NotificationMetadata;
            GXt_char5 = AV62NotificationDescription;
            GXt_char4 = AV62NotificationDescription;
            new uwwp_getloggeduserid(context ).execute( out  GXt_char4) ;
            new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  GXt_char4, out  GXt_char5) ;
            AV62NotificationDescription = StringUtil.Format( context.GetMessage( "%1 deleted by %2 %3", ""), A59ProductServiceName, AV61RoleName, GXt_char5, "", "", "", "", "", "");
            new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendnotification(context ).execute(  "DeleteRecord",  "Trn_ProductService",  "",  context.GetMessage( "far fa-trash-alt NotificationFontIconDanger", ""),  context.GetMessage( "Service Deleted", ""),  AV62NotificationDescription,  AV62NotificationDescription,  "",  AV64WWPNotificationMetadataSDT.ToJSonString(false, true),  "",  AV53IsWeb) ;
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV18WebSession.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "Service Updated successfully", ""));
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV18WebSession.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "Service Deleted successfully", ""));
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV18WebSession.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "Service Inserted successfully", ""));
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV16TrnContext.gxTpr_Callerondelete )
            {
               CallWebObject(formatLink("trn_productserviceww.aspx") );
               context.wjLocDisableFrm = 1;
            }
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void S152( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         edtavSupplierlocation_Visible = 0;
         AssignProp("", false, edtavSupplierlocation_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSupplierlocation_Visible), 5, 0), true);
         divSupplierlocation_cell_Class = "Invisible";
         AssignProp("", false, divSupplierlocation_cell_Internalname, "Class", divSupplierlocation_cell_Class, true);
         Productservicedescription_Visible = false;
         AssignProp("", false, Productservicedescription_Internalname, "Visible", StringUtil.BoolToStr( Productservicedescription_Visible), true);
         divProductservicedescription_cell_Class = "Invisible";
         AssignProp("", false, divProductservicedescription_cell_Internalname, "Class", divProductservicedescription_cell_Class, true);
         chkavListagbpre.Visible = 0;
         AssignProp("", false, chkavListagbpre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavListagbpre.Visible), 5, 0), true);
         cellListagbpre_cell_Class = "Invisible";
         AssignProp("", false, cellListagbpre_cell_Internalname, "Class", cellListagbpre_cell_Class, true);
         chkavListagb.Visible = 0;
         AssignProp("", false, chkavListagb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavListagb.Visible), 5, 0), true);
         cellListagb_cell_Class = "Invisible";
         AssignProp("", false, cellListagb_cell_Internalname, "Class", cellListagb_cell_Class, true);
         chkavListgenpre.Visible = 0;
         AssignProp("", false, chkavListgenpre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavListgenpre.Visible), 5, 0), true);
         cellListgenpre_cell_Class = "Invisible";
         AssignProp("", false, cellListgenpre_cell_Internalname, "Class", cellListgenpre_cell_Class, true);
         chkavListgen.Visible = 0;
         AssignProp("", false, chkavListgen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavListgen.Visible), 5, 0), true);
         cellListgen_cell_Class = "Invisible";
         AssignProp("", false, cellListgen_cell_Internalname, "Class", cellListgen_cell_Class, true);
         dynLocationId.Visible = 0;
         AssignProp("", false, dynLocationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynLocationId.Visible), 5, 0), true);
         divLocationid_cell_Class = "Invisible";
         AssignProp("", false, divLocationid_cell_Internalname, "Class", divLocationid_cell_Class, true);
      }

      protected void E15082( )
      {
         /* Combo_supplieragb_id_Onoptionclicked Routine */
         returnInSub = false;
         AV46SupplierAgb_Id = StringUtil.StrToGuid( Combo_supplieragb_id_Selectedvalue_get);
         AssignAttri("", false, "AV46SupplierAgb_Id", AV46SupplierAgb_Id.ToString());
         /*  Sending Event outputs  */
      }

      protected void E14082( )
      {
         /* Combo_supplieragbid_Onoptionclicked Routine */
         returnInSub = false;
         AV30ComboSupplierAgbId = StringUtil.StrToGuid( Combo_supplieragbid_Selectedvalue_get);
         AssignAttri("", false, "AV30ComboSupplierAgbId", AV30ComboSupplierAgbId.ToString());
         /*  Sending Event outputs  */
      }

      protected void E13082( )
      {
         /* Combo_suppliergen_id_Onoptionclicked Routine */
         returnInSub = false;
         AV47SupplierGen_Id = StringUtil.StrToGuid( Combo_suppliergen_id_Selectedvalue_get);
         AssignAttri("", false, "AV47SupplierGen_Id", AV47SupplierGen_Id.ToString());
         AV26ComboSupplierGenId = AV47SupplierGen_Id;
         AssignAttri("", false, "AV26ComboSupplierGenId", AV26ComboSupplierGenId.ToString());
         /*  Sending Event outputs  */
      }

      protected void E12082( )
      {
         /* Combo_suppliergenid_Onoptionclicked Routine */
         returnInSub = false;
         AV26ComboSupplierGenId = StringUtil.StrToGuid( Combo_suppliergenid_Selectedvalue_get);
         AssignAttri("", false, "AV26ComboSupplierGenId", AV26ComboSupplierGenId.ToString());
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'LOADCOMBOSUPPLIERAGB_ID' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item6 = AV48SupplierAgb_Id_Data;
         new trn_productserviceloaddvcombo(context ).execute(  "SupplierAgb_Id",  Gx_mode,  AV12ProductServiceId,  AV33LocationId,  AV34OrganisationId, out  AV23ComboSelectedValue, out  GXt_objcol_SdtDVB_SDTComboData_Item6) ;
         AV48SupplierAgb_Id_Data = GXt_objcol_SdtDVB_SDTComboData_Item6;
         Combo_supplieragb_id_Selectedvalue_set = AV23ComboSelectedValue;
         ucCombo_supplieragb_id.SendProperty(context, "", false, Combo_supplieragb_id_Internalname, "SelectedValue_set", Combo_supplieragb_id_Selectedvalue_set);
         AV46SupplierAgb_Id = StringUtil.StrToGuid( AV23ComboSelectedValue);
         AssignAttri("", false, "AV46SupplierAgb_Id", AV46SupplierAgb_Id.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_supplieragb_id_Enabled = false;
            ucCombo_supplieragb_id.SendProperty(context, "", false, Combo_supplieragb_id_Internalname, "Enabled", StringUtil.BoolToStr( Combo_supplieragb_id_Enabled));
         }
      }

      protected void S132( )
      {
         /* 'LOADCOMBOSUPPLIERAGBID' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item6 = AV29SupplierAgbId_Data;
         new trn_productserviceloaddvcombo(context ).execute(  "SupplierAgbId",  Gx_mode,  AV12ProductServiceId,  AV33LocationId,  AV34OrganisationId, out  AV23ComboSelectedValue, out  GXt_objcol_SdtDVB_SDTComboData_Item6) ;
         AV29SupplierAgbId_Data = GXt_objcol_SdtDVB_SDTComboData_Item6;
         Combo_supplieragbid_Selectedvalue_set = AV23ComboSelectedValue;
         ucCombo_supplieragbid.SendProperty(context, "", false, Combo_supplieragbid_Internalname, "SelectedValue_set", Combo_supplieragbid_Selectedvalue_set);
         AV30ComboSupplierAgbId = StringUtil.StrToGuid( AV23ComboSelectedValue);
         AssignAttri("", false, "AV30ComboSupplierAgbId", AV30ComboSupplierAgbId.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_supplieragbid_Enabled = false;
            ucCombo_supplieragbid.SendProperty(context, "", false, Combo_supplieragbid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_supplieragbid_Enabled));
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBOSUPPLIERGEN_ID' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item6 = AV49SupplierGen_Id_Data;
         new trn_productserviceloaddvcombo(context ).execute(  "SupplierGen_Id",  Gx_mode,  AV12ProductServiceId,  AV33LocationId,  AV34OrganisationId, out  AV23ComboSelectedValue, out  GXt_objcol_SdtDVB_SDTComboData_Item6) ;
         AV49SupplierGen_Id_Data = GXt_objcol_SdtDVB_SDTComboData_Item6;
         Combo_suppliergen_id_Selectedvalue_set = AV23ComboSelectedValue;
         ucCombo_suppliergen_id.SendProperty(context, "", false, Combo_suppliergen_id_Internalname, "SelectedValue_set", Combo_suppliergen_id_Selectedvalue_set);
         AV47SupplierGen_Id = StringUtil.StrToGuid( AV23ComboSelectedValue);
         AssignAttri("", false, "AV47SupplierGen_Id", AV47SupplierGen_Id.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_suppliergen_id_Enabled = false;
            ucCombo_suppliergen_id.SendProperty(context, "", false, Combo_suppliergen_id_Internalname, "Enabled", StringUtil.BoolToStr( Combo_suppliergen_id_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOSUPPLIERGENID' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item6 = AV21SupplierGenId_Data;
         new trn_productserviceloaddvcombo(context ).execute(  "SupplierGenId",  Gx_mode,  AV12ProductServiceId,  AV33LocationId,  AV34OrganisationId, out  AV23ComboSelectedValue, out  GXt_objcol_SdtDVB_SDTComboData_Item6) ;
         AV21SupplierGenId_Data = GXt_objcol_SdtDVB_SDTComboData_Item6;
         Combo_suppliergenid_Selectedvalue_set = AV23ComboSelectedValue;
         ucCombo_suppliergenid.SendProperty(context, "", false, Combo_suppliergenid_Internalname, "SelectedValue_set", Combo_suppliergenid_Selectedvalue_set);
         AV26ComboSupplierGenId = StringUtil.StrToGuid( AV23ComboSelectedValue);
         AssignAttri("", false, "AV26ComboSupplierGenId", AV26ComboSupplierGenId.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_suppliergenid_Enabled = false;
            ucCombo_suppliergenid.SendProperty(context, "", false, Combo_suppliergenid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_suppliergenid_Enabled));
         }
      }

      protected void S162( )
      {
         /* 'SETSTATEOFSUPPLIER' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            if ( (AV41PreferredGenSuppliers.IndexOf(AV26ComboSupplierGenId)>0) )
            {
               AV43ListGen = true;
               AssignAttri("", false, "AV43ListGen", AV43ListGen);
               AV51ListGenPre = true;
               AssignAttri("", false, "AV51ListGenPre", AV51ListGenPre);
               Combo_suppliergen_id_Selectedvalue_set = AV26ComboSupplierGenId.ToString();
               ucCombo_suppliergen_id.SendProperty(context, "", false, Combo_suppliergen_id_Internalname, "SelectedValue_set", Combo_suppliergen_id_Selectedvalue_set);
            }
            else
            {
               AV43ListGen = false;
               AssignAttri("", false, "AV43ListGen", AV43ListGen);
               AV51ListGenPre = false;
               AssignAttri("", false, "AV51ListGenPre", AV51ListGenPre);
            }
         }
      }

      protected void ZM0868( short GX_JID )
      {
         if ( ( GX_JID == 53 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z59ProductServiceName = T00083_A59ProductServiceName[0];
               Z266ProductServiceTileName = T00083_A266ProductServiceTileName[0];
               Z370ProductServiceClass = T00083_A370ProductServiceClass[0];
               Z338ProductServiceGroup = T00083_A338ProductServiceGroup[0];
               Z42SupplierGenId = T00083_A42SupplierGenId[0];
               Z49SupplierAgbId = T00083_A49SupplierAgbId[0];
            }
            else
            {
               Z59ProductServiceName = A59ProductServiceName;
               Z266ProductServiceTileName = A266ProductServiceTileName;
               Z370ProductServiceClass = A370ProductServiceClass;
               Z338ProductServiceGroup = A338ProductServiceGroup;
               Z42SupplierGenId = A42SupplierGenId;
               Z49SupplierAgbId = A49SupplierAgbId;
            }
         }
         if ( GX_JID == -53 )
         {
            Z58ProductServiceId = A58ProductServiceId;
            Z59ProductServiceName = A59ProductServiceName;
            Z266ProductServiceTileName = A266ProductServiceTileName;
            Z60ProductServiceDescription = A60ProductServiceDescription;
            Z370ProductServiceClass = A370ProductServiceClass;
            Z61ProductServiceImage = A61ProductServiceImage;
            Z40000ProductServiceImage_GXI = A40000ProductServiceImage_GXI;
            Z338ProductServiceGroup = A338ProductServiceGroup;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            Z42SupplierGenId = A42SupplierGenId;
            Z49SupplierAgbId = A49SupplierAgbId;
            Z44SupplierGenCompanyName = A44SupplierGenCompanyName;
            Z51SupplierAgbName = A51SupplierAgbName;
         }
      }

      protected void standaloneNotModal( )
      {
         GXAPRODUCTSERVICEGROUP_html0868( ) ;
         Productservicedescription_Visible = (bool)((StringUtil.StrCmp(Gx_mode, "INS")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0));
         AssignProp("", false, Productservicedescription_Internalname, "Visible", StringUtil.BoolToStr( Productservicedescription_Visible), true);
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) ) )
         {
            divProductservicedescription_cell_Class = context.GetMessage( "Invisible", "");
            AssignProp("", false, divProductservicedescription_cell_Internalname, "Class", divProductservicedescription_cell_Class, true);
         }
         else
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
            {
               divProductservicedescription_cell_Class = context.GetMessage( "col-xs-12 DataContentCell CKEditor", "");
               AssignProp("", false, divProductservicedescription_cell_Internalname, "Class", divProductservicedescription_cell_Class, true);
            }
         }
         edtavSupplierlocation_Visible = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? 1 : 0);
         AssignProp("", false, edtavSupplierlocation_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSupplierlocation_Visible), 5, 0), true);
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) ) )
         {
            divSupplierlocation_cell_Class = context.GetMessage( "Invisible", "");
            AssignProp("", false, divSupplierlocation_cell_Internalname, "Class", divSupplierlocation_cell_Class, true);
         }
         else
         {
            if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
            {
               divSupplierlocation_cell_Class = context.GetMessage( "col-xs-12 DataContentCell", "");
               AssignProp("", false, divSupplierlocation_cell_Internalname, "Class", divSupplierlocation_cell_Class, true);
            }
         }
         chkavListagbpre.Visible = ((StringUtil.StrCmp(Gx_mode, "INS")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0) ? 1 : 0);
         AssignProp("", false, chkavListagbpre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavListagbpre.Visible), 5, 0), true);
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) ) )
         {
            cellListagbpre_cell_Class = context.GetMessage( "Invisible", "");
            AssignProp("", false, cellListagbpre_cell_Internalname, "Class", cellListagbpre_cell_Class, true);
         }
         else
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
            {
               cellListagbpre_cell_Class = context.GetMessage( "DataContentCell", "");
               AssignProp("", false, cellListagbpre_cell_Internalname, "Class", cellListagbpre_cell_Class, true);
            }
         }
         chkavListagb.Visible = ((StringUtil.StrCmp(Gx_mode, "INS")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0) ? 1 : 0);
         AssignProp("", false, chkavListagb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavListagb.Visible), 5, 0), true);
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) ) )
         {
            cellListagb_cell_Class = context.GetMessage( "Invisible", "");
            AssignProp("", false, cellListagb_cell_Internalname, "Class", cellListagb_cell_Class, true);
         }
         else
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
            {
               cellListagb_cell_Class = context.GetMessage( "DataContentCell", "");
               AssignProp("", false, cellListagb_cell_Internalname, "Class", cellListagb_cell_Class, true);
            }
         }
         chkavListgenpre.Visible = ((StringUtil.StrCmp(Gx_mode, "INS")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0) ? 1 : 0);
         AssignProp("", false, chkavListgenpre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavListgenpre.Visible), 5, 0), true);
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) ) )
         {
            cellListgenpre_cell_Class = context.GetMessage( "Invisible", "");
            AssignProp("", false, cellListgenpre_cell_Internalname, "Class", cellListgenpre_cell_Class, true);
         }
         else
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
            {
               cellListgenpre_cell_Class = context.GetMessage( "DataContentCell", "");
               AssignProp("", false, cellListgenpre_cell_Internalname, "Class", cellListgenpre_cell_Class, true);
            }
         }
         chkavListgen.Visible = ((StringUtil.StrCmp(Gx_mode, "INS")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0) ? 1 : 0);
         AssignProp("", false, chkavListgen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavListgen.Visible), 5, 0), true);
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) ) )
         {
            cellListgen_cell_Class = context.GetMessage( "Invisible", "");
            AssignProp("", false, cellListgen_cell_Internalname, "Class", cellListgen_cell_Class, true);
         }
         else
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
            {
               cellListgen_cell_Class = context.GetMessage( "DataContentCell", "");
               AssignProp("", false, cellListgen_cell_Internalname, "Class", cellListgen_cell_Class, true);
            }
         }
         divProductsevicetable_Visible = (((StringUtil.StrCmp(Gx_mode, "DSP")==0)) ? 1 : 0);
         AssignProp("", false, divProductsevicetable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divProductsevicetable_Visible), 5, 0), true);
         AV71Pgmname = "Trn_ProductService";
         AssignAttri("", false, "AV71Pgmname", AV71Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV12ProductServiceId) )
         {
            edtProductServiceId_Enabled = 0;
            AssignProp("", false, edtProductServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Enabled), 5, 0), true);
         }
         else
         {
            edtProductServiceId_Enabled = 1;
            AssignProp("", false, edtProductServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV12ProductServiceId) )
         {
            edtProductServiceId_Enabled = 0;
            AssignProp("", false, edtProductServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV33LocationId) )
         {
            A29LocationId = AV33LocationId;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         }
         if ( ! (Guid.Empty==AV33LocationId) )
         {
            dynLocationId.Enabled = 0;
            AssignProp("", false, dynLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynLocationId.Enabled), 5, 0), true);
         }
         else
         {
            dynLocationId.Enabled = 1;
            AssignProp("", false, dynLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynLocationId.Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV33LocationId) )
         {
            dynLocationId.Enabled = 0;
            AssignProp("", false, dynLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynLocationId.Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV34OrganisationId) )
         {
            A11OrganisationId = AV34OrganisationId;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         if ( ! (Guid.Empty==AV34OrganisationId) )
         {
            edtOrganisationId_Enabled = 0;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
         else
         {
            edtOrganisationId_Enabled = 1;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV34OrganisationId) )
         {
            edtOrganisationId_Enabled = 0;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV10Insert_SupplierGenId) )
         {
            edtSupplierGenId_Enabled = 0;
            AssignProp("", false, edtSupplierGenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenId_Enabled), 5, 0), true);
         }
         else
         {
            edtSupplierGenId_Enabled = 1;
            AssignProp("", false, edtSupplierGenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV9Insert_SupplierAgbId) )
         {
            edtSupplierAgbId_Enabled = 0;
            AssignProp("", false, edtSupplierAgbId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbId_Enabled), 5, 0), true);
         }
         else
         {
            edtSupplierAgbId_Enabled = 1;
            AssignProp("", false, edtSupplierAgbId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbId_Enabled), 5, 0), true);
         }
         dynLocationId.Visible = ((AV57isManager) ? 1 : 0);
         AssignProp("", false, dynLocationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynLocationId.Visible), 5, 0), true);
         if ( ! ( ( AV57isManager ) ) )
         {
            divLocationid_cell_Class = context.GetMessage( "Invisible", "");
            AssignProp("", false, divLocationid_cell_Internalname, "Class", divLocationid_cell_Class, true);
         }
         else
         {
            if ( AV57isManager )
            {
               divLocationid_cell_Class = context.GetMessage( "col-xs-12 DataContentCell", "");
               AssignProp("", false, divLocationid_cell_Internalname, "Class", divLocationid_cell_Class, true);
            }
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV10Insert_SupplierGenId) )
         {
            A42SupplierGenId = AV10Insert_SupplierGenId;
            n42SupplierGenId = false;
            AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
         }
         else
         {
            if ( (Guid.Empty==AV26ComboSupplierGenId) )
            {
               A42SupplierGenId = Guid.Empty;
               n42SupplierGenId = false;
               AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
               n42SupplierGenId = true;
               AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
            }
            else
            {
               if ( ! (Guid.Empty==AV26ComboSupplierGenId) )
               {
                  A42SupplierGenId = AV26ComboSupplierGenId;
                  n42SupplierGenId = false;
                  AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV9Insert_SupplierAgbId) )
         {
            A49SupplierAgbId = AV9Insert_SupplierAgbId;
            n49SupplierAgbId = false;
            AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
         }
         else
         {
            if ( (Guid.Empty==AV30ComboSupplierAgbId) )
            {
               A49SupplierAgbId = Guid.Empty;
               n49SupplierAgbId = false;
               AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
               n49SupplierAgbId = true;
               AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
            }
            else
            {
               if ( ! (Guid.Empty==AV30ComboSupplierAgbId) )
               {
                  A49SupplierAgbId = AV30ComboSupplierAgbId;
                  n49SupplierAgbId = false;
                  AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
               }
            }
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
         if ( ! (Guid.Empty==AV12ProductServiceId) )
         {
            A58ProductServiceId = AV12ProductServiceId;
            n58ProductServiceId = false;
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A58ProductServiceId) && ( Gx_BScreen == 0 ) )
            {
               A58ProductServiceId = Guid.NewGuid( );
               n58ProductServiceId = false;
               AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
            }
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A338ProductServiceGroup)) && ( Gx_BScreen == 0 ) )
         {
            A338ProductServiceGroup = "Location";
            AssignAttri("", false, "A338ProductServiceGroup", A338ProductServiceGroup);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            divTablegen_Visible = (((StringUtil.StrCmp(A338ProductServiceGroup, "Supplier")==0)) ? 1 : 0);
            AssignProp("", false, divTablegen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablegen_Visible), 5, 0), true);
            divTableagb_Visible = (((StringUtil.StrCmp(A338ProductServiceGroup, " AGB Supplier")==0)) ? 1 : 0);
            AssignProp("", false, divTableagb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableagb_Visible), 5, 0), true);
            GXALOCATIONID_html0868( A11OrganisationId) ;
            /* Using cursor T00085 */
            pr_default.execute(3, new Object[] {n42SupplierGenId, A42SupplierGenId});
            A44SupplierGenCompanyName = T00085_A44SupplierGenCompanyName[0];
            pr_default.close(3);
            /* Using cursor T00086 */
            pr_default.execute(4, new Object[] {n49SupplierAgbId, A49SupplierAgbId});
            A51SupplierAgbName = T00086_A51SupplierAgbName[0];
            pr_default.close(4);
         }
      }

      protected void Load0868( )
      {
         /* Using cursor T00087 */
         pr_default.execute(5, new Object[] {n58ProductServiceId, A58ProductServiceId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound68 = 1;
            A59ProductServiceName = T00087_A59ProductServiceName[0];
            AssignAttri("", false, "A59ProductServiceName", A59ProductServiceName);
            A266ProductServiceTileName = T00087_A266ProductServiceTileName[0];
            AssignAttri("", false, "A266ProductServiceTileName", A266ProductServiceTileName);
            A60ProductServiceDescription = T00087_A60ProductServiceDescription[0];
            A370ProductServiceClass = T00087_A370ProductServiceClass[0];
            AssignAttri("", false, "A370ProductServiceClass", A370ProductServiceClass);
            A40000ProductServiceImage_GXI = T00087_A40000ProductServiceImage_GXI[0];
            AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
            AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
            A338ProductServiceGroup = T00087_A338ProductServiceGroup[0];
            AssignAttri("", false, "A338ProductServiceGroup", A338ProductServiceGroup);
            A44SupplierGenCompanyName = T00087_A44SupplierGenCompanyName[0];
            A51SupplierAgbName = T00087_A51SupplierAgbName[0];
            A42SupplierGenId = T00087_A42SupplierGenId[0];
            n42SupplierGenId = T00087_n42SupplierGenId[0];
            AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
            A49SupplierAgbId = T00087_A49SupplierAgbId[0];
            n49SupplierAgbId = T00087_n49SupplierAgbId[0];
            AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
            A61ProductServiceImage = T00087_A61ProductServiceImage[0];
            AssignAttri("", false, "A61ProductServiceImage", A61ProductServiceImage);
            AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
            AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
            ZM0868( -53) ;
         }
         pr_default.close(5);
         OnLoadActions0868( ) ;
      }

      protected void OnLoadActions0868( )
      {
         GXALOCATIONID_html0868( A11OrganisationId) ;
         divTablegen_Visible = (((StringUtil.StrCmp(A338ProductServiceGroup, "Supplier")==0)) ? 1 : 0);
         AssignProp("", false, divTablegen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablegen_Visible), 5, 0), true);
         divTableagb_Visible = (((StringUtil.StrCmp(A338ProductServiceGroup, " AGB Supplier")==0)) ? 1 : 0);
         AssignProp("", false, divTableagb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableagb_Visible), 5, 0), true);
         divSupplieragb_Visible = ((!AV42ListAgb) ? 1 : 0);
         AssignProp("", false, divSupplieragb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divSupplieragb_Visible), 5, 0), true);
         divSupplieragbpre_Visible = (((AV42ListAgb)) ? 1 : 0);
         AssignProp("", false, divSupplieragbpre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divSupplieragbpre_Visible), 5, 0), true);
         divSuppliergen_Visible = ((!AV43ListGen) ? 1 : 0);
         AssignProp("", false, divSuppliergen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divSuppliergen_Visible), 5, 0), true);
         divSuppliergenpre_Visible = (((AV43ListGen)) ? 1 : 0);
         AssignProp("", false, divSuppliergenpre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divSuppliergenpre_Visible), 5, 0), true);
      }

      protected void CheckExtendedTable0868( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T00084 */
         pr_default.execute(2, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = dynLocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         GXALOCATIONID_html0868( A11OrganisationId) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A59ProductServiceName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Product Service Name", ""), "", "", "", "", "", "", "", ""), 1, "PRODUCTSERVICENAME");
            AnyError = 1;
            GX_FocusControl = edtProductServiceName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A266ProductServiceTileName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Product Service Tile Name", ""), "", "", "", "", "", "", "", ""), 1, "PRODUCTSERVICETILENAME");
            AnyError = 1;
            GX_FocusControl = edtProductServiceTileName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         divTablegen_Visible = (((StringUtil.StrCmp(A338ProductServiceGroup, "Supplier")==0)) ? 1 : 0);
         AssignProp("", false, divTablegen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablegen_Visible), 5, 0), true);
         divTableagb_Visible = (((StringUtil.StrCmp(A338ProductServiceGroup, " AGB Supplier")==0)) ? 1 : 0);
         AssignProp("", false, divTableagb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableagb_Visible), 5, 0), true);
         /* Using cursor T00085 */
         pr_default.execute(3, new Object[] {n42SupplierGenId, A42SupplierGenId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (Guid.Empty==A42SupplierGenId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "General Suppliers", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SUPPLIERGENID");
               AnyError = 1;
               GX_FocusControl = edtSupplierGenId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A44SupplierGenCompanyName = T00085_A44SupplierGenCompanyName[0];
         pr_default.close(3);
         /* Using cursor T00086 */
         pr_default.execute(4, new Object[] {n49SupplierAgbId, A49SupplierAgbId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (Guid.Empty==A49SupplierAgbId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "AGB Suppliers", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SUPPLIERAGBID");
               AnyError = 1;
               GX_FocusControl = edtSupplierAgbId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A51SupplierAgbName = T00086_A51SupplierAgbName[0];
         pr_default.close(4);
         divSupplieragb_Visible = ((!AV42ListAgb) ? 1 : 0);
         AssignProp("", false, divSupplieragb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divSupplieragb_Visible), 5, 0), true);
         divSupplieragbpre_Visible = (((AV42ListAgb)) ? 1 : 0);
         AssignProp("", false, divSupplieragbpre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divSupplieragbpre_Visible), 5, 0), true);
         divSuppliergen_Visible = ((!AV43ListGen) ? 1 : 0);
         AssignProp("", false, divSuppliergen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divSuppliergen_Visible), 5, 0), true);
         divSuppliergenpre_Visible = (((AV43ListGen)) ? 1 : 0);
         AssignProp("", false, divSuppliergenpre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divSuppliergenpre_Visible), 5, 0), true);
      }

      protected void CloseExtendedTableCursors0868( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_54( Guid A29LocationId ,
                                Guid A11OrganisationId )
      {
         /* Using cursor T00088 */
         pr_default.execute(6, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = dynLocationId_Internalname;
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

      protected void gxLoad_55( Guid A42SupplierGenId )
      {
         /* Using cursor T00089 */
         pr_default.execute(7, new Object[] {n42SupplierGenId, A42SupplierGenId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (Guid.Empty==A42SupplierGenId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "General Suppliers", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SUPPLIERGENID");
               AnyError = 1;
               GX_FocusControl = edtSupplierGenId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A44SupplierGenCompanyName = T00089_A44SupplierGenCompanyName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A44SupplierGenCompanyName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_56( Guid A49SupplierAgbId )
      {
         /* Using cursor T000810 */
         pr_default.execute(8, new Object[] {n49SupplierAgbId, A49SupplierAgbId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (Guid.Empty==A49SupplierAgbId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "AGB Suppliers", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SUPPLIERAGBID");
               AnyError = 1;
               GX_FocusControl = edtSupplierAgbId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A51SupplierAgbName = T000810_A51SupplierAgbName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A51SupplierAgbName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey0868( )
      {
         /* Using cursor T000811 */
         pr_default.execute(9, new Object[] {n58ProductServiceId, A58ProductServiceId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound68 = 1;
         }
         else
         {
            RcdFound68 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00083 */
         pr_default.execute(1, new Object[] {n58ProductServiceId, A58ProductServiceId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0868( 53) ;
            RcdFound68 = 1;
            A58ProductServiceId = T00083_A58ProductServiceId[0];
            n58ProductServiceId = T00083_n58ProductServiceId[0];
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
            A59ProductServiceName = T00083_A59ProductServiceName[0];
            AssignAttri("", false, "A59ProductServiceName", A59ProductServiceName);
            A266ProductServiceTileName = T00083_A266ProductServiceTileName[0];
            AssignAttri("", false, "A266ProductServiceTileName", A266ProductServiceTileName);
            A60ProductServiceDescription = T00083_A60ProductServiceDescription[0];
            A370ProductServiceClass = T00083_A370ProductServiceClass[0];
            AssignAttri("", false, "A370ProductServiceClass", A370ProductServiceClass);
            A40000ProductServiceImage_GXI = T00083_A40000ProductServiceImage_GXI[0];
            AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
            AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
            A338ProductServiceGroup = T00083_A338ProductServiceGroup[0];
            AssignAttri("", false, "A338ProductServiceGroup", A338ProductServiceGroup);
            A29LocationId = T00083_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = T00083_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A42SupplierGenId = T00083_A42SupplierGenId[0];
            n42SupplierGenId = T00083_n42SupplierGenId[0];
            AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
            A49SupplierAgbId = T00083_A49SupplierAgbId[0];
            n49SupplierAgbId = T00083_n49SupplierAgbId[0];
            AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
            A61ProductServiceImage = T00083_A61ProductServiceImage[0];
            AssignAttri("", false, "A61ProductServiceImage", A61ProductServiceImage);
            AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
            AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
            Z58ProductServiceId = A58ProductServiceId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            sMode68 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0868( ) ;
            if ( AnyError == 1 )
            {
               RcdFound68 = 0;
               InitializeNonKey0868( ) ;
            }
            Gx_mode = sMode68;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound68 = 0;
            InitializeNonKey0868( ) ;
            sMode68 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode68;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0868( ) ;
         if ( RcdFound68 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound68 = 0;
         /* Using cursor T000812 */
         pr_default.execute(10, new Object[] {n58ProductServiceId, A58ProductServiceId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( GuidUtil.Compare(T000812_A58ProductServiceId[0], A58ProductServiceId, 0) < 0 ) || ( T000812_A58ProductServiceId[0] == A58ProductServiceId ) && ( GuidUtil.Compare(T000812_A29LocationId[0], A29LocationId, 0) < 0 ) || ( T000812_A29LocationId[0] == A29LocationId ) && ( T000812_A58ProductServiceId[0] == A58ProductServiceId ) && ( GuidUtil.Compare(T000812_A11OrganisationId[0], A11OrganisationId, 0) < 0 ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( GuidUtil.Compare(T000812_A58ProductServiceId[0], A58ProductServiceId, 0) > 0 ) || ( T000812_A58ProductServiceId[0] == A58ProductServiceId ) && ( GuidUtil.Compare(T000812_A29LocationId[0], A29LocationId, 0) > 0 ) || ( T000812_A29LocationId[0] == A29LocationId ) && ( T000812_A58ProductServiceId[0] == A58ProductServiceId ) && ( GuidUtil.Compare(T000812_A11OrganisationId[0], A11OrganisationId, 0) > 0 ) ) )
            {
               A58ProductServiceId = T000812_A58ProductServiceId[0];
               n58ProductServiceId = T000812_n58ProductServiceId[0];
               AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
               A29LocationId = T000812_A29LocationId[0];
               AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
               A11OrganisationId = T000812_A11OrganisationId[0];
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               RcdFound68 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound68 = 0;
         /* Using cursor T000813 */
         pr_default.execute(11, new Object[] {n58ProductServiceId, A58ProductServiceId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( GuidUtil.Compare(T000813_A58ProductServiceId[0], A58ProductServiceId, 0) > 0 ) || ( T000813_A58ProductServiceId[0] == A58ProductServiceId ) && ( GuidUtil.Compare(T000813_A29LocationId[0], A29LocationId, 0) > 0 ) || ( T000813_A29LocationId[0] == A29LocationId ) && ( T000813_A58ProductServiceId[0] == A58ProductServiceId ) && ( GuidUtil.Compare(T000813_A11OrganisationId[0], A11OrganisationId, 0) > 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( GuidUtil.Compare(T000813_A58ProductServiceId[0], A58ProductServiceId, 0) < 0 ) || ( T000813_A58ProductServiceId[0] == A58ProductServiceId ) && ( GuidUtil.Compare(T000813_A29LocationId[0], A29LocationId, 0) < 0 ) || ( T000813_A29LocationId[0] == A29LocationId ) && ( T000813_A58ProductServiceId[0] == A58ProductServiceId ) && ( GuidUtil.Compare(T000813_A11OrganisationId[0], A11OrganisationId, 0) < 0 ) ) )
            {
               A58ProductServiceId = T000813_A58ProductServiceId[0];
               n58ProductServiceId = T000813_n58ProductServiceId[0];
               AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
               A29LocationId = T000813_A29LocationId[0];
               AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
               A11OrganisationId = T000813_A11OrganisationId[0];
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               RcdFound68 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0868( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = dynLocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0868( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound68 == 1 )
            {
               if ( ( A58ProductServiceId != Z58ProductServiceId ) || ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
               {
                  A58ProductServiceId = Z58ProductServiceId;
                  n58ProductServiceId = false;
                  AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
                  A29LocationId = Z29LocationId;
                  AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
                  A11OrganisationId = Z11OrganisationId;
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PRODUCTSERVICEID");
                  AnyError = 1;
                  GX_FocusControl = edtProductServiceId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = dynLocationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0868( ) ;
                  GX_FocusControl = dynLocationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A58ProductServiceId != Z58ProductServiceId ) || ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
               {
                  /* Insert record */
                  GX_FocusControl = dynLocationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0868( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PRODUCTSERVICEID");
                     AnyError = 1;
                     GX_FocusControl = edtProductServiceId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = dynLocationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0868( ) ;
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
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( ( A58ProductServiceId != Z58ProductServiceId ) || ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
         {
            A58ProductServiceId = Z58ProductServiceId;
            n58ProductServiceId = false;
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
            A29LocationId = Z29LocationId;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = Z11OrganisationId;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PRODUCTSERVICEID");
            AnyError = 1;
            GX_FocusControl = edtProductServiceId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = dynLocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0868( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00082 */
            pr_default.execute(0, new Object[] {n58ProductServiceId, A58ProductServiceId, A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ProductService"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z59ProductServiceName, T00082_A59ProductServiceName[0]) != 0 ) || ( StringUtil.StrCmp(Z266ProductServiceTileName, T00082_A266ProductServiceTileName[0]) != 0 ) || ( StringUtil.StrCmp(Z370ProductServiceClass, T00082_A370ProductServiceClass[0]) != 0 ) || ( StringUtil.StrCmp(Z338ProductServiceGroup, T00082_A338ProductServiceGroup[0]) != 0 ) || ( Z42SupplierGenId != T00082_A42SupplierGenId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z49SupplierAgbId != T00082_A49SupplierAgbId[0] ) )
            {
               if ( StringUtil.StrCmp(Z59ProductServiceName, T00082_A59ProductServiceName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_productservice:[seudo value changed for attri]"+"ProductServiceName");
                  GXUtil.WriteLogRaw("Old: ",Z59ProductServiceName);
                  GXUtil.WriteLogRaw("Current: ",T00082_A59ProductServiceName[0]);
               }
               if ( StringUtil.StrCmp(Z266ProductServiceTileName, T00082_A266ProductServiceTileName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_productservice:[seudo value changed for attri]"+"ProductServiceTileName");
                  GXUtil.WriteLogRaw("Old: ",Z266ProductServiceTileName);
                  GXUtil.WriteLogRaw("Current: ",T00082_A266ProductServiceTileName[0]);
               }
               if ( StringUtil.StrCmp(Z370ProductServiceClass, T00082_A370ProductServiceClass[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_productservice:[seudo value changed for attri]"+"ProductServiceClass");
                  GXUtil.WriteLogRaw("Old: ",Z370ProductServiceClass);
                  GXUtil.WriteLogRaw("Current: ",T00082_A370ProductServiceClass[0]);
               }
               if ( StringUtil.StrCmp(Z338ProductServiceGroup, T00082_A338ProductServiceGroup[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_productservice:[seudo value changed for attri]"+"ProductServiceGroup");
                  GXUtil.WriteLogRaw("Old: ",Z338ProductServiceGroup);
                  GXUtil.WriteLogRaw("Current: ",T00082_A338ProductServiceGroup[0]);
               }
               if ( Z42SupplierGenId != T00082_A42SupplierGenId[0] )
               {
                  GXUtil.WriteLog("trn_productservice:[seudo value changed for attri]"+"SupplierGenId");
                  GXUtil.WriteLogRaw("Old: ",Z42SupplierGenId);
                  GXUtil.WriteLogRaw("Current: ",T00082_A42SupplierGenId[0]);
               }
               if ( Z49SupplierAgbId != T00082_A49SupplierAgbId[0] )
               {
                  GXUtil.WriteLog("trn_productservice:[seudo value changed for attri]"+"SupplierAgbId");
                  GXUtil.WriteLogRaw("Old: ",Z49SupplierAgbId);
                  GXUtil.WriteLogRaw("Current: ",T00082_A49SupplierAgbId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_ProductService"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0868( )
      {
         if ( ! IsAuthorized("trn_productservice_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0868( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0868( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0868( 0) ;
            CheckOptimisticConcurrency0868( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0868( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0868( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000814 */
                     pr_default.execute(12, new Object[] {n58ProductServiceId, A58ProductServiceId, A59ProductServiceName, A266ProductServiceTileName, A60ProductServiceDescription, A370ProductServiceClass, A61ProductServiceImage, A40000ProductServiceImage_GXI, A338ProductServiceGroup, A29LocationId, A11OrganisationId, n42SupplierGenId, A42SupplierGenId, n49SupplierAgbId, A49SupplierAgbId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ProductService");
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
                           ResetCaption080( ) ;
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
               Load0868( ) ;
            }
            EndLevel0868( ) ;
         }
         CloseExtendedTableCursors0868( ) ;
      }

      protected void Update0868( )
      {
         if ( ! IsAuthorized("trn_productservice_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0868( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0868( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0868( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0868( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0868( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000815 */
                     pr_default.execute(13, new Object[] {A59ProductServiceName, A266ProductServiceTileName, A60ProductServiceDescription, A370ProductServiceClass, A338ProductServiceGroup, n42SupplierGenId, A42SupplierGenId, n49SupplierAgbId, A49SupplierAgbId, n58ProductServiceId, A58ProductServiceId, A29LocationId, A11OrganisationId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ProductService");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ProductService"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0868( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        new prc_updateserviceimages(context ).execute(  A58ProductServiceId,  AV67UploadedFiles,  AV68FilesToUpdate) ;
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
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
            EndLevel0868( ) ;
         }
         CloseExtendedTableCursors0868( ) ;
      }

      protected void DeferredUpdate0868( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000816 */
            pr_default.execute(14, new Object[] {A61ProductServiceImage, A40000ProductServiceImage_GXI, n58ProductServiceId, A58ProductServiceId, A29LocationId, A11OrganisationId});
            pr_default.close(14);
            pr_default.SmartCacheProvider.SetUpdated("Trn_ProductService");
         }
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_productservice_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0868( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0868( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0868( ) ;
            AfterConfirm0868( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0868( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000817 */
                  pr_default.execute(15, new Object[] {n58ProductServiceId, A58ProductServiceId, A29LocationId, A11OrganisationId});
                  pr_default.close(15);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ProductService");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
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
         sMode68 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0868( ) ;
         Gx_mode = sMode68;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0868( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXALOCATIONID_html0868( A11OrganisationId) ;
            divTablegen_Visible = (((StringUtil.StrCmp(A338ProductServiceGroup, "Supplier")==0)) ? 1 : 0);
            AssignProp("", false, divTablegen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablegen_Visible), 5, 0), true);
            divTableagb_Visible = (((StringUtil.StrCmp(A338ProductServiceGroup, " AGB Supplier")==0)) ? 1 : 0);
            AssignProp("", false, divTableagb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableagb_Visible), 5, 0), true);
            /* Using cursor T000818 */
            pr_default.execute(16, new Object[] {n42SupplierGenId, A42SupplierGenId});
            A44SupplierGenCompanyName = T000818_A44SupplierGenCompanyName[0];
            pr_default.close(16);
            /* Using cursor T000819 */
            pr_default.execute(17, new Object[] {n49SupplierAgbId, A49SupplierAgbId});
            A51SupplierAgbName = T000819_A51SupplierAgbName[0];
            pr_default.close(17);
            divSupplieragb_Visible = ((!AV42ListAgb) ? 1 : 0);
            AssignProp("", false, divSupplieragb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divSupplieragb_Visible), 5, 0), true);
            divSupplieragbpre_Visible = (((AV42ListAgb)) ? 1 : 0);
            AssignProp("", false, divSupplieragbpre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divSupplieragbpre_Visible), 5, 0), true);
            divSuppliergen_Visible = ((!AV43ListGen) ? 1 : 0);
            AssignProp("", false, divSuppliergen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divSuppliergen_Visible), 5, 0), true);
            divSuppliergenpre_Visible = (((AV43ListGen)) ? 1 : 0);
            AssignProp("", false, divSuppliergenpre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divSuppliergenpre_Visible), 5, 0), true);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000820 */
            pr_default.execute(18, new Object[] {n58ProductServiceId, A58ProductServiceId, A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_Page", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T000821 */
            pr_default.execute(19, new Object[] {n58ProductServiceId, A58ProductServiceId, A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Call To Actions", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
         }
      }

      protected void EndLevel0868( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0868( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_productservice",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues080( ) ;
            }
            /* After transaction rules */
            new prc_addtodynamictransalation(context ).execute(  AV66SDT_TrnAttributes) ;
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_productservice",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0868( )
      {
         /* Scan By routine */
         /* Using cursor T000822 */
         pr_default.execute(20);
         RcdFound68 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound68 = 1;
            A58ProductServiceId = T000822_A58ProductServiceId[0];
            n58ProductServiceId = T000822_n58ProductServiceId[0];
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
            A29LocationId = T000822_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = T000822_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0868( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound68 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound68 = 1;
            A58ProductServiceId = T000822_A58ProductServiceId[0];
            n58ProductServiceId = T000822_n58ProductServiceId[0];
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
            A29LocationId = T000822_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = T000822_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
      }

      protected void ScanEnd0868( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm0868( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0868( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0868( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0868( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0868( )
      {
         /* Before Complete Rules */
         GXt_SdtSDT_TrnAttributes7 = AV66SDT_TrnAttributes;
         new prc_addproductserviceattributestosdt(context ).execute(  A58ProductServiceId, out  GXt_SdtSDT_TrnAttributes7) ;
         AV66SDT_TrnAttributes = GXt_SdtSDT_TrnAttributes7;
      }

      protected void BeforeValidate0868( )
      {
         /* Before Validate Rules */
         if ( new prc_uniquelocationservicename(context).executeUdp(  A59ProductServiceName,  A29LocationId,  A58ProductServiceId) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  context.GetMessage( "Service name Already exists", ""),  "error",  "",  "true",  ""), 1, "LOCATIONID");
            AnyError = 1;
            GX_FocusControl = dynLocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void DisableAttributes0868( )
      {
         dynLocationId.Enabled = 0;
         AssignProp("", false, dynLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynLocationId.Enabled), 5, 0), true);
         edtProductServiceName_Enabled = 0;
         AssignProp("", false, edtProductServiceName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceName_Enabled), 5, 0), true);
         cmbProductServiceClass.Enabled = 0;
         AssignProp("", false, cmbProductServiceClass_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProductServiceClass.Enabled), 5, 0), true);
         dynProductServiceGroup.Enabled = 0;
         AssignProp("", false, dynProductServiceGroup_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynProductServiceGroup.Enabled), 5, 0), true);
         edtSupplierGenId_Enabled = 0;
         AssignProp("", false, edtSupplierGenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenId_Enabled), 5, 0), true);
         chkavListgen.Enabled = 0;
         AssignProp("", false, chkavListgen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavListgen.Enabled), 5, 0), true);
         chkavListgenpre.Enabled = 0;
         AssignProp("", false, chkavListgenpre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavListgenpre.Enabled), 5, 0), true);
         edtSupplierAgbId_Enabled = 0;
         AssignProp("", false, edtSupplierAgbId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbId_Enabled), 5, 0), true);
         chkavListagb.Enabled = 0;
         AssignProp("", false, chkavListagb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavListagb.Enabled), 5, 0), true);
         chkavListagbpre.Enabled = 0;
         AssignProp("", false, chkavListagbpre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavListagbpre.Enabled), 5, 0), true);
         edtavCombosuppliergenid_Enabled = 0;
         AssignProp("", false, edtavCombosuppliergenid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosuppliergenid_Enabled), 5, 0), true);
         edtavCombosupplieragbid_Enabled = 0;
         AssignProp("", false, edtavCombosupplieragbid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosupplieragbid_Enabled), 5, 0), true);
         edtProductServiceId_Enabled = 0;
         AssignProp("", false, edtProductServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Enabled), 5, 0), true);
         edtOrganisationId_Enabled = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         edtProductServiceTileName_Enabled = 0;
         AssignProp("", false, edtProductServiceTileName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceTileName_Enabled), 5, 0), true);
         imgProductServiceImage_Enabled = 0;
         AssignProp("", false, imgProductServiceImage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgProductServiceImage_Enabled), 5, 0), true);
         Productservicedescription_Enabled = Convert.ToBoolean( 0);
         AssignProp("", false, Productservicedescription_Internalname, "Enabled", StringUtil.BoolToStr( Productservicedescription_Enabled), true);
      }

      protected void send_integrity_lvl_hashes0868( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues080( )
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
         context.AddJavascriptSource("UserControls/UC_CustomImageUploadRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         GXEncryptionTmp = "trn_productservice.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV12ProductServiceId.ToString()) + "," + UrlEncode(AV33LocationId.ToString()) + "," + UrlEncode(AV34OrganisationId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_productservice.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_ProductService");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_productservice:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z58ProductServiceId", Z58ProductServiceId.ToString());
         GxWebStd.gx_hidden_field( context, "Z29LocationId", Z29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z11OrganisationId", Z11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z59ProductServiceName", Z59ProductServiceName);
         GxWebStd.gx_hidden_field( context, "Z266ProductServiceTileName", StringUtil.RTrim( Z266ProductServiceTileName));
         GxWebStd.gx_hidden_field( context, "Z370ProductServiceClass", Z370ProductServiceClass);
         GxWebStd.gx_hidden_field( context, "Z338ProductServiceGroup", Z338ProductServiceGroup);
         GxWebStd.gx_hidden_field( context, "Z42SupplierGenId", Z42SupplierGenId.ToString());
         GxWebStd.gx_hidden_field( context, "Z49SupplierAgbId", Z49SupplierAgbId.ToString());
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N42SupplierGenId", A42SupplierGenId.ToString());
         GxWebStd.gx_hidden_field( context, "N49SupplierAgbId", A49SupplierAgbId.ToString());
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSUPPLIERGENID_DATA", AV21SupplierGenId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSUPPLIERGENID_DATA", AV21SupplierGenId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV22DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV22DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSUPPLIERGEN_ID_DATA", AV49SupplierGen_Id_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSUPPLIERGEN_ID_DATA", AV49SupplierGen_Id_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSUPPLIERAGBID_DATA", AV29SupplierAgbId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSUPPLIERAGBID_DATA", AV29SupplierAgbId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSUPPLIERAGB_ID_DATA", AV48SupplierAgb_Id_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSUPPLIERAGB_ID_DATA", AV48SupplierAgb_Id_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV19WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV19WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV19WWPContext, context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vROLENAME", AV61RoleName);
         GxWebStd.gx_hidden_field( context, "gxhash_vROLENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV61RoleName, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV16TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV16TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV16TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vPRODUCTSERVICEID", AV12ProductServiceId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vPRODUCTSERVICEID", GetSecureSignedToken( "", AV12ProductServiceId, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vLOCATIONID", AV33LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", AV33LocationId, context));
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV34OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV34OrganisationId, context));
         GxWebStd.gx_hidden_field( context, "vINSERT_SUPPLIERGENID", AV10Insert_SupplierGenId.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_SUPPLIERAGBID", AV9Insert_SupplierAgbId.ToString());
         GxWebStd.gx_boolean_hidden_field( context, "vISMANAGER", AV57isManager);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDT_TRNATTRIBUTES", AV66SDT_TrnAttributes);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDT_TRNATTRIBUTES", AV66SDT_TrnAttributes);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUPLOADEDFILES", AV67UploadedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUPLOADEDFILES", AV67UploadedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILESTOUPDATE", AV68FilesToUpdate);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILESTOUPDATE", AV68FilesToUpdate);
         }
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEDESCRIPTION", A60ProductServiceDescription);
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEIMAGE_GXI", A40000ProductServiceImage_GXI);
         GxWebStd.gx_hidden_field( context, "SUPPLIERGENCOMPANYNAME", A44SupplierGenCompanyName);
         GxWebStd.gx_hidden_field( context, "SUPPLIERAGBNAME", A51SupplierAgbName);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV71Pgmname));
         GXCCtlgxBlob = "PRODUCTSERVICEIMAGE" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A61ProductServiceImage);
         GxWebStd.gx_hidden_field( context, "IMAGEUPLOADUC_Objectcall", StringUtil.RTrim( Imageuploaduc_Objectcall));
         GxWebStd.gx_hidden_field( context, "IMAGEUPLOADUC_Enabled", StringUtil.BoolToStr( Imageuploaduc_Enabled));
         GxWebStd.gx_hidden_field( context, "IMAGEUPLOADUC_Faileduploadmessage", StringUtil.RTrim( Imageuploaduc_Faileduploadmessage));
         GxWebStd.gx_hidden_field( context, "IMAGEUPLOADUC_Maxnumberoffiles", StringUtil.RTrim( Imageuploaduc_Maxnumberoffiles));
         GxWebStd.gx_hidden_field( context, "IMAGEUPLOADUC_Isreadonlymode", StringUtil.RTrim( Imageuploaduc_Isreadonlymode));
         GxWebStd.gx_hidden_field( context, "IMAGEUPLOADUC_Maxfilesize", StringUtil.RTrim( Imageuploaduc_Maxfilesize));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENID_Objectcall", StringUtil.RTrim( Combo_suppliergenid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENID_Cls", StringUtil.RTrim( Combo_suppliergenid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENID_Selectedvalue_set", StringUtil.RTrim( Combo_suppliergenid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENID_Enabled", StringUtil.BoolToStr( Combo_suppliergenid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENID_Emptyitem", StringUtil.BoolToStr( Combo_suppliergenid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGEN_ID_Objectcall", StringUtil.RTrim( Combo_suppliergen_id_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGEN_ID_Cls", StringUtil.RTrim( Combo_suppliergen_id_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGEN_ID_Selectedvalue_set", StringUtil.RTrim( Combo_suppliergen_id_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGEN_ID_Enabled", StringUtil.BoolToStr( Combo_suppliergen_id_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGEN_ID_Emptyitem", StringUtil.BoolToStr( Combo_suppliergen_id_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERAGBID_Objectcall", StringUtil.RTrim( Combo_supplieragbid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERAGBID_Cls", StringUtil.RTrim( Combo_supplieragbid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERAGBID_Selectedvalue_set", StringUtil.RTrim( Combo_supplieragbid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERAGBID_Enabled", StringUtil.BoolToStr( Combo_supplieragbid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERAGBID_Emptyitem", StringUtil.BoolToStr( Combo_supplieragbid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERAGB_ID_Objectcall", StringUtil.RTrim( Combo_supplieragb_id_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERAGB_ID_Cls", StringUtil.RTrim( Combo_supplieragb_id_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERAGB_ID_Selectedvalue_set", StringUtil.RTrim( Combo_supplieragb_id_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERAGB_ID_Enabled", StringUtil.BoolToStr( Combo_supplieragb_id_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERAGB_ID_Emptyitem", StringUtil.BoolToStr( Combo_supplieragb_id_Emptyitem));
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEDESCRIPTION_Objectcall", StringUtil.RTrim( Productservicedescription_Objectcall));
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEDESCRIPTION_Enabled", StringUtil.BoolToStr( Productservicedescription_Enabled));
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEDESCRIPTION_Width", StringUtil.RTrim( Productservicedescription_Width));
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEDESCRIPTION_Height", StringUtil.RTrim( Productservicedescription_Height));
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEDESCRIPTION_Skin", StringUtil.RTrim( Productservicedescription_Skin));
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEDESCRIPTION_Toolbar", StringUtil.RTrim( Productservicedescription_Toolbar));
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEDESCRIPTION_Customtoolbar", StringUtil.RTrim( Productservicedescription_Customtoolbar));
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEDESCRIPTION_Customconfiguration", StringUtil.RTrim( Productservicedescription_Customconfiguration));
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEDESCRIPTION_Toolbarcancollapse", StringUtil.BoolToStr( Productservicedescription_Toolbarcancollapse));
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEDESCRIPTION_Captionclass", StringUtil.RTrim( Productservicedescription_Captionclass));
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEDESCRIPTION_Captionstyle", StringUtil.RTrim( Productservicedescription_Captionstyle));
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEDESCRIPTION_Captionposition", StringUtil.RTrim( Productservicedescription_Captionposition));
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEDESCRIPTION_Visible", StringUtil.BoolToStr( Productservicedescription_Visible));
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
         GXEncryptionTmp = "trn_productservice.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV12ProductServiceId.ToString()) + "," + UrlEncode(AV33LocationId.ToString()) + "," + UrlEncode(AV34OrganisationId.ToString());
         return formatLink("trn_productservice.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Trn_ProductService" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Product Service", "") ;
      }

      protected void InitializeNonKey0868( )
      {
         A42SupplierGenId = Guid.Empty;
         n42SupplierGenId = false;
         AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
         A49SupplierAgbId = Guid.Empty;
         n49SupplierAgbId = false;
         AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
         n49SupplierAgbId = ((Guid.Empty==A49SupplierAgbId) ? true : false);
         AV52ListAgbPre = false;
         AssignAttri("", false, "AV52ListAgbPre", AV52ListAgbPre);
         AV42ListAgb = false;
         AssignAttri("", false, "AV42ListAgb", AV42ListAgb);
         AV51ListGenPre = false;
         AssignAttri("", false, "AV51ListGenPre", AV51ListGenPre);
         AV43ListGen = false;
         AssignAttri("", false, "AV43ListGen", AV43ListGen);
         AV66SDT_TrnAttributes = new SdtSDT_TrnAttributes(context);
         A59ProductServiceName = "";
         AssignAttri("", false, "A59ProductServiceName", A59ProductServiceName);
         A266ProductServiceTileName = "";
         AssignAttri("", false, "A266ProductServiceTileName", A266ProductServiceTileName);
         A60ProductServiceDescription = "";
         AssignAttri("", false, "A60ProductServiceDescription", A60ProductServiceDescription);
         A370ProductServiceClass = "";
         AssignAttri("", false, "A370ProductServiceClass", A370ProductServiceClass);
         A61ProductServiceImage = "";
         AssignAttri("", false, "A61ProductServiceImage", A61ProductServiceImage);
         AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
         AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
         A40000ProductServiceImage_GXI = "";
         AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
         AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
         A44SupplierGenCompanyName = "";
         AssignAttri("", false, "A44SupplierGenCompanyName", A44SupplierGenCompanyName);
         A51SupplierAgbName = "";
         AssignAttri("", false, "A51SupplierAgbName", A51SupplierAgbName);
         A338ProductServiceGroup = "Location";
         AssignAttri("", false, "A338ProductServiceGroup", A338ProductServiceGroup);
         Z59ProductServiceName = "";
         Z266ProductServiceTileName = "";
         Z370ProductServiceClass = "";
         Z338ProductServiceGroup = "";
         Z42SupplierGenId = Guid.Empty;
         Z49SupplierAgbId = Guid.Empty;
      }

      protected void InitAll0868( )
      {
         A58ProductServiceId = Guid.NewGuid( );
         n58ProductServiceId = false;
         AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
         A29LocationId = Guid.Empty;
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         A11OrganisationId = Guid.Empty;
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         InitializeNonKey0868( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A338ProductServiceGroup = i338ProductServiceGroup;
         AssignAttri("", false, "A338ProductServiceGroup", A338ProductServiceGroup);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025721817510", true, true);
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
         context.AddJavascriptSource("trn_productservice.js", "?2025721817517", false, true);
         context.AddJavascriptSource("UserControls/UC_CustomImageUploadRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         dynLocationId_Internalname = "LOCATIONID";
         divLocationid_cell_Internalname = "LOCATIONID_CELL";
         edtProductServiceName_Internalname = "PRODUCTSERVICENAME";
         lblProductserviceimagetext_Internalname = "PRODUCTSERVICEIMAGETEXT";
         Imageuploaduc_Internalname = "IMAGEUPLOADUC";
         divUcfilecell_Internalname = "UCFILECELL";
         divUnnamedtable6_Internalname = "UNNAMEDTABLE6";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         cmbProductServiceClass_Internalname = "PRODUCTSERVICECLASS";
         dynProductServiceGroup_Internalname = "PRODUCTSERVICEGROUP";
         edtavSupplierlocation_Internalname = "vSUPPLIERLOCATION";
         divSupplierlocation_cell_Internalname = "SUPPLIERLOCATION_CELL";
         lblTextblocksuppliergenid_Internalname = "TEXTBLOCKSUPPLIERGENID";
         Combo_suppliergenid_Internalname = "COMBO_SUPPLIERGENID";
         edtSupplierGenId_Internalname = "SUPPLIERGENID";
         chkavListgen_Internalname = "vLISTGEN";
         cellListgen_cell_Internalname = "LISTGEN_CELL";
         tblTablemergedsuppliergenid_Internalname = "TABLEMERGEDSUPPLIERGENID";
         divTablesplittedsuppliergenid_Internalname = "TABLESPLITTEDSUPPLIERGENID";
         divSuppliergen_Internalname = "SUPPLIERGEN";
         lblTextblockcombo_suppliergen_id_Internalname = "TEXTBLOCKCOMBO_SUPPLIERGEN_ID";
         Combo_suppliergen_id_Internalname = "COMBO_SUPPLIERGEN_ID";
         chkavListgenpre_Internalname = "vLISTGENPRE";
         cellListgenpre_cell_Internalname = "LISTGENPRE_CELL";
         tblTablemergedsuppliergen_id_Internalname = "TABLEMERGEDSUPPLIERGEN_ID";
         divTablesplittedsuppliergen_id_Internalname = "TABLESPLITTEDSUPPLIERGEN_ID";
         divSuppliergenpre_Internalname = "SUPPLIERGENPRE";
         divTablegen_Internalname = "TABLEGEN";
         lblTextblocksupplieragbid_Internalname = "TEXTBLOCKSUPPLIERAGBID";
         Combo_supplieragbid_Internalname = "COMBO_SUPPLIERAGBID";
         edtSupplierAgbId_Internalname = "SUPPLIERAGBID";
         chkavListagb_Internalname = "vLISTAGB";
         cellListagb_cell_Internalname = "LISTAGB_CELL";
         tblTablemergedsupplieragbid_Internalname = "TABLEMERGEDSUPPLIERAGBID";
         divTablesplittedsupplieragbid_Internalname = "TABLESPLITTEDSUPPLIERAGBID";
         divSupplieragb_Internalname = "SUPPLIERAGB";
         lblTextblockcombo_supplieragb_id_Internalname = "TEXTBLOCKCOMBO_SUPPLIERAGB_ID";
         Combo_supplieragb_id_Internalname = "COMBO_SUPPLIERAGB_ID";
         chkavListagbpre_Internalname = "vLISTAGBPRE";
         cellListagbpre_cell_Internalname = "LISTAGBPRE_CELL";
         tblTablemergedsupplieragb_id_Internalname = "TABLEMERGEDSUPPLIERAGB_ID";
         divTablesplittedsupplieragb_id_Internalname = "TABLESPLITTEDSUPPLIERAGB_ID";
         divSupplieragbpre_Internalname = "SUPPLIERAGBPRE";
         divTableagb_Internalname = "TABLEAGB";
         divUnnamedtable4_Internalname = "UNNAMEDTABLE4";
         Productservicedescription_Internalname = "PRODUCTSERVICEDESCRIPTION";
         divProductservicedescription_cell_Internalname = "PRODUCTSERVICEDESCRIPTION_CELL";
         lblTextblockdescriptionlabel_Internalname = "TEXTBLOCKDESCRIPTIONLABEL";
         lblDescriptiontext_Internalname = "DESCRIPTIONTEXT";
         divUnnamedtable5_Internalname = "UNNAMEDTABLE5";
         divProductsevicetable_Internalname = "PRODUCTSEVICETABLE";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombosuppliergenid_Internalname = "vCOMBOSUPPLIERGENID";
         divSectionattribute_suppliergenid_Internalname = "SECTIONATTRIBUTE_SUPPLIERGENID";
         edtavSuppliergen_id_Internalname = "vSUPPLIERGEN_ID";
         edtavCombosupplieragbid_Internalname = "vCOMBOSUPPLIERAGBID";
         divSectionattribute_supplieragbid_Internalname = "SECTIONATTRIBUTE_SUPPLIERAGBID";
         edtavSupplieragb_id_Internalname = "vSUPPLIERAGB_ID";
         edtProductServiceId_Internalname = "PRODUCTSERVICEID";
         edtOrganisationId_Internalname = "ORGANISATIONID";
         edtProductServiceTileName_Internalname = "PRODUCTSERVICETILENAME";
         imgProductServiceImage_Internalname = "PRODUCTSERVICEIMAGE";
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
         Form.Caption = context.GetMessage( "Trn_Product Service", "");
         Productservicedescription_Visible = Convert.ToBoolean( -1);
         imgProductServiceImage_Enabled = 1;
         imgProductServiceImage_Visible = 1;
         edtProductServiceTileName_Jsonclick = "";
         edtProductServiceTileName_Enabled = 1;
         edtProductServiceTileName_Visible = 1;
         edtOrganisationId_Jsonclick = "";
         edtOrganisationId_Enabled = 1;
         edtOrganisationId_Visible = 1;
         edtProductServiceId_Jsonclick = "";
         edtProductServiceId_Enabled = 1;
         edtProductServiceId_Visible = 1;
         edtavSupplieragb_id_Jsonclick = "";
         edtavSupplieragb_id_Enabled = 0;
         edtavSupplieragb_id_Visible = 1;
         edtavCombosupplieragbid_Jsonclick = "";
         edtavCombosupplieragbid_Enabled = 0;
         edtavCombosupplieragbid_Visible = 1;
         edtavSuppliergen_id_Jsonclick = "";
         edtavSuppliergen_id_Enabled = 0;
         edtavSuppliergen_id_Visible = 1;
         edtavCombosuppliergenid_Jsonclick = "";
         edtavCombosuppliergenid_Enabled = 0;
         edtavCombosuppliergenid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         divProductsevicetable_Visible = 1;
         Productservicedescription_Captionposition = "Left";
         Productservicedescription_Captionstyle = "";
         Productservicedescription_Captionclass = "col-sm-4 AttributeLabel";
         Productservicedescription_Toolbarcancollapse = Convert.ToBoolean( 0);
         Productservicedescription_Customconfiguration = "myconfig.js";
         Productservicedescription_Customtoolbar = "myToolbar";
         Productservicedescription_Toolbar = "Custom";
         Productservicedescription_Skin = "default";
         Productservicedescription_Height = "250";
         Productservicedescription_Width = "100%";
         Productservicedescription_Enabled = Convert.ToBoolean( 1);
         divProductservicedescription_cell_Class = "col-xs-12";
         chkavListagbpre.Enabled = 1;
         chkavListagbpre.Visible = 1;
         cellListagbpre_cell_Class = "";
         Combo_supplieragb_id_Emptyitem = Convert.ToBoolean( 0);
         Combo_supplieragb_id_Cls = "ExtendedCombo Attribute";
         Combo_supplieragb_id_Caption = "";
         Combo_supplieragb_id_Enabled = Convert.ToBoolean( -1);
         divSupplieragbpre_Visible = 1;
         chkavListagb.Enabled = 1;
         chkavListagb.Visible = 1;
         cellListagb_cell_Class = "";
         edtSupplierAgbId_Jsonclick = "";
         edtSupplierAgbId_Enabled = 1;
         edtSupplierAgbId_Visible = 1;
         Combo_supplieragbid_Emptyitem = Convert.ToBoolean( 0);
         Combo_supplieragbid_Cls = "ExtendedCombo Attribute";
         Combo_supplieragbid_Enabled = Convert.ToBoolean( -1);
         tblTablemergedsupplieragbid_Class = "TableMerged";
         divSupplieragb_Visible = 1;
         divTableagb_Visible = 1;
         chkavListgenpre.Enabled = 1;
         chkavListgenpre.Visible = 1;
         cellListgenpre_cell_Class = "";
         Combo_suppliergen_id_Emptyitem = Convert.ToBoolean( 0);
         Combo_suppliergen_id_Cls = "ExtendedCombo Attribute";
         Combo_suppliergen_id_Caption = "";
         Combo_suppliergen_id_Enabled = Convert.ToBoolean( -1);
         divSuppliergenpre_Visible = 1;
         chkavListgen.Enabled = 1;
         chkavListgen.Visible = 1;
         cellListgen_cell_Class = "";
         edtSupplierGenId_Jsonclick = "";
         edtSupplierGenId_Enabled = 1;
         edtSupplierGenId_Visible = 1;
         Combo_suppliergenid_Emptyitem = Convert.ToBoolean( 0);
         Combo_suppliergenid_Cls = "ExtendedCombo Attribute";
         Combo_suppliergenid_Enabled = Convert.ToBoolean( -1);
         tblTablemergedsuppliergenid_Class = "TableMerged";
         divSuppliergen_Visible = 1;
         divTablegen_Visible = 1;
         edtavSupplierlocation_Enabled = 0;
         edtavSupplierlocation_Visible = 1;
         divSupplierlocation_cell_Class = "col-xs-12";
         dynProductServiceGroup_Jsonclick = "";
         dynProductServiceGroup.Enabled = 1;
         cmbProductServiceClass_Jsonclick = "";
         cmbProductServiceClass.Enabled = 1;
         Imageuploaduc_Maxfilesize = "10";
         Imageuploaduc_Isreadonlymode = "false";
         Imageuploaduc_Maxnumberoffiles = "5";
         Imageuploaduc_Faileduploadmessage = "Upload Failed";
         edtProductServiceName_Jsonclick = "";
         edtProductServiceName_Enabled = 1;
         dynLocationId_Jsonclick = "";
         dynLocationId.Enabled = 1;
         dynLocationId.Visible = 1;
         divLocationid_cell_Class = "col-xs-12";
         divLayoutmaintable_Class = "Table";
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         GXALOCATIONID_html0868( A11OrganisationId) ;
         /* End function dynload_actions */
      }

      protected void GXDLALOCATIONID0868( Guid A11OrganisationId )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLALOCATIONID_data0868( A11OrganisationId) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXALOCATIONID_html0868( Guid A11OrganisationId )
      {
         Guid gxdynajaxvalue;
         GXDLALOCATIONID_data0868( A11OrganisationId) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynLocationId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = StringUtil.StrToGuid( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)));
            dynLocationId.addItem(gxdynajaxvalue.ToString(), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLALOCATIONID_data0868( Guid A11OrganisationId )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000823 */
         pr_default.execute(21);
         while ( (pr_default.getStatus(21) != 101) )
         {
            if ( A11OrganisationId == new prc_getuserorganisationid(context).executeUdp( ) )
            {
               gxdynajaxctrlcodr.Add(T000823_A29LocationId[0].ToString());
               gxdynajaxctrldescr.Add(T000823_A31LocationName[0]);
            }
            pr_default.readNext(21);
         }
         pr_default.close(21);
      }

      protected void GXDSAPRODUCTSERVICEGROUP0868( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDSAPRODUCTSERVICEGROUP_data0868( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrldescr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrldescr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXAPRODUCTSERVICEGROUP_html0868( )
      {
         string gxdynajaxvalue;
         GXDSAPRODUCTSERVICEGROUP_data0868( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynProductServiceGroup.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex));
            dynProductServiceGroup.addItem(gxdynajaxvalue, ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDSAPRODUCTSERVICEGROUP_data0868( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add("");
         gxdynajaxctrldescr.Add(context.GetMessage( "Select Supplier Type", ""));
         GXBaseCollection<SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem> gxcolPRODUCTSERVICEGROUP;
         SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem gxcolitemPRODUCTSERVICEGROUP;
         new dp_productservicesuppliergroup(context ).execute( out  gxcolPRODUCTSERVICEGROUP) ;
         gxcolPRODUCTSERVICEGROUP.Sort("Sdt_productservicesuppliergroupname");
         int gxindex = 1;
         while ( gxindex <= gxcolPRODUCTSERVICEGROUP.Count )
         {
            gxcolitemPRODUCTSERVICEGROUP = ((SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem)gxcolPRODUCTSERVICEGROUP.Item(gxindex));
            gxdynajaxctrlcodr.Add(gxcolitemPRODUCTSERVICEGROUP.gxTpr_Sdt_productservicesuppliergroupid);
            gxdynajaxctrldescr.Add(gxcolitemPRODUCTSERVICEGROUP.gxTpr_Sdt_productservicesuppliergroupname);
            gxindex = (int)(gxindex+1);
         }
      }

      protected void GX35ASASDT_TRNATTRIBUTES0868( Guid A58ProductServiceId )
      {
         GXt_SdtSDT_TrnAttributes7 = AV66SDT_TrnAttributes;
         new prc_addproductserviceattributestosdt(context ).execute(  A58ProductServiceId, out  GXt_SdtSDT_TrnAttributes7) ;
         AV66SDT_TrnAttributes = GXt_SdtSDT_TrnAttributes7;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV66SDT_TrnAttributes.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_52_0868( Guid A58ProductServiceId ,
                                 GXBaseCollection<SdtSDT_FileUploadData> AV67UploadedFiles ,
                                 GXBaseCollection<SdtSDT_FileUploadData> AV68FilesToUpdate )
      {
         new prc_updateserviceimages(context ).execute(  A58ProductServiceId,  AV67UploadedFiles,  AV68FilesToUpdate) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
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
         dynLocationId.Name = "LOCATIONID";
         dynLocationId.WebTags = "";
         cmbProductServiceClass.Name = "PRODUCTSERVICECLASS";
         cmbProductServiceClass.WebTags = "";
         cmbProductServiceClass.addItem("", context.GetMessage( "Select Category", ""), 0);
         cmbProductServiceClass.addItem("My Living", context.GetMessage( "My Living", ""), 0);
         cmbProductServiceClass.addItem("My Care", context.GetMessage( "My Care", ""), 0);
         cmbProductServiceClass.addItem("My Services", context.GetMessage( "My Services", ""), 0);
         if ( cmbProductServiceClass.ItemCount > 0 )
         {
            A370ProductServiceClass = cmbProductServiceClass.getValidValue(A370ProductServiceClass);
            AssignAttri("", false, "A370ProductServiceClass", A370ProductServiceClass);
         }
         dynProductServiceGroup.Name = "PRODUCTSERVICEGROUP";
         dynProductServiceGroup.WebTags = "";
         chkavListgen.Name = "vLISTGEN";
         chkavListgen.WebTags = "";
         chkavListgen.Caption = context.GetMessage( "List Gen", "");
         AssignProp("", false, chkavListgen_Internalname, "TitleCaption", chkavListgen.Caption, true);
         chkavListgen.CheckedValue = "false";
         AV43ListGen = StringUtil.StrToBool( StringUtil.BoolToStr( AV43ListGen));
         AssignAttri("", false, "AV43ListGen", AV43ListGen);
         chkavListgenpre.Name = "vLISTGENPRE";
         chkavListgenpre.WebTags = "";
         chkavListgenpre.Caption = context.GetMessage( "List Gen Pre", "");
         AssignProp("", false, chkavListgenpre_Internalname, "TitleCaption", chkavListgenpre.Caption, true);
         chkavListgenpre.CheckedValue = "false";
         AV51ListGenPre = StringUtil.StrToBool( StringUtil.BoolToStr( AV51ListGenPre));
         AssignAttri("", false, "AV51ListGenPre", AV51ListGenPre);
         chkavListagb.Name = "vLISTAGB";
         chkavListagb.WebTags = "";
         chkavListagb.Caption = context.GetMessage( "List Agb", "");
         AssignProp("", false, chkavListagb_Internalname, "TitleCaption", chkavListagb.Caption, true);
         chkavListagb.CheckedValue = "false";
         AV42ListAgb = StringUtil.StrToBool( StringUtil.BoolToStr( AV42ListAgb));
         AssignAttri("", false, "AV42ListAgb", AV42ListAgb);
         chkavListagbpre.Name = "vLISTAGBPRE";
         chkavListagbpre.WebTags = "";
         chkavListagbpre.Caption = context.GetMessage( "List Agb Pre", "");
         AssignProp("", false, chkavListagbpre_Internalname, "TitleCaption", chkavListagbpre.Caption, true);
         chkavListagbpre.CheckedValue = "false";
         AV52ListAgbPre = StringUtil.StrToBool( StringUtil.BoolToStr( AV52ListAgbPre));
         AssignAttri("", false, "AV52ListAgbPre", AV52ListAgbPre);
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
         A29LocationId = StringUtil.StrToGuid( dynLocationId.CurrentValue);
         A338ProductServiceGroup = dynProductServiceGroup.CurrentValue;
         /* Using cursor T000824 */
         pr_default.execute(22, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = dynLocationId_Internalname;
         }
         pr_default.close(22);
         GXALOCATIONID_html0868( A11OrganisationId) ;
         dynload_actions( ) ;
         if ( dynLocationId.ItemCount > 0 )
         {
            A29LocationId = StringUtil.StrToGuid( dynLocationId.getValidValue(A29LocationId.ToString()));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynLocationId.CurrentValue = A29LocationId.ToString();
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         dynLocationId.CurrentValue = A29LocationId.ToString();
         AssignProp("", false, dynLocationId_Internalname, "Values", dynLocationId.ToJavascriptSource(), true);
      }

      public void Valid_Suppliergenid( )
      {
         n42SupplierGenId = false;
         A29LocationId = StringUtil.StrToGuid( dynLocationId.CurrentValue);
         A338ProductServiceGroup = dynProductServiceGroup.CurrentValue;
         /* Using cursor T000825 */
         pr_default.execute(23, new Object[] {n42SupplierGenId, A42SupplierGenId});
         if ( (pr_default.getStatus(23) == 101) )
         {
            if ( ! ( (Guid.Empty==A42SupplierGenId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "General Suppliers", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SUPPLIERGENID");
               AnyError = 1;
               GX_FocusControl = edtSupplierGenId_Internalname;
            }
         }
         A44SupplierGenCompanyName = T000825_A44SupplierGenCompanyName[0];
         pr_default.close(23);
         dynload_actions( ) ;
         if ( dynLocationId.ItemCount > 0 )
         {
            A29LocationId = StringUtil.StrToGuid( dynLocationId.getValidValue(A29LocationId.ToString()));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynLocationId.CurrentValue = A29LocationId.ToString();
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A44SupplierGenCompanyName", A44SupplierGenCompanyName);
      }

      public void Validv_Listgen( )
      {
         A29LocationId = StringUtil.StrToGuid( dynLocationId.CurrentValue);
         A338ProductServiceGroup = dynProductServiceGroup.CurrentValue;
         divSuppliergen_Visible = ((!AV43ListGen) ? 1 : 0);
         divSuppliergenpre_Visible = (((AV43ListGen)) ? 1 : 0);
         dynload_actions( ) ;
         if ( dynLocationId.ItemCount > 0 )
         {
            A29LocationId = StringUtil.StrToGuid( dynLocationId.getValidValue(A29LocationId.ToString()));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynLocationId.CurrentValue = A29LocationId.ToString();
         }
         /*  Sending validation outputs */
         AssignProp("", false, divSuppliergen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divSuppliergen_Visible), 5, 0), true);
         AssignProp("", false, divSuppliergenpre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divSuppliergenpre_Visible), 5, 0), true);
      }

      public void Valid_Supplieragbid( )
      {
         n49SupplierAgbId = false;
         A29LocationId = StringUtil.StrToGuid( dynLocationId.CurrentValue);
         A338ProductServiceGroup = dynProductServiceGroup.CurrentValue;
         /* Using cursor T000826 */
         pr_default.execute(24, new Object[] {n49SupplierAgbId, A49SupplierAgbId});
         if ( (pr_default.getStatus(24) == 101) )
         {
            if ( ! ( (Guid.Empty==A49SupplierAgbId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "AGB Suppliers", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SUPPLIERAGBID");
               AnyError = 1;
               GX_FocusControl = edtSupplierAgbId_Internalname;
            }
         }
         A51SupplierAgbName = T000826_A51SupplierAgbName[0];
         pr_default.close(24);
         dynload_actions( ) ;
         if ( dynLocationId.ItemCount > 0 )
         {
            A29LocationId = StringUtil.StrToGuid( dynLocationId.getValidValue(A29LocationId.ToString()));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynLocationId.CurrentValue = A29LocationId.ToString();
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A51SupplierAgbName", A51SupplierAgbName);
      }

      public void Validv_Listagb( )
      {
         A29LocationId = StringUtil.StrToGuid( dynLocationId.CurrentValue);
         A338ProductServiceGroup = dynProductServiceGroup.CurrentValue;
         divSupplieragb_Visible = ((!AV42ListAgb) ? 1 : 0);
         divSupplieragbpre_Visible = (((AV42ListAgb)) ? 1 : 0);
         dynload_actions( ) ;
         if ( dynLocationId.ItemCount > 0 )
         {
            A29LocationId = StringUtil.StrToGuid( dynLocationId.getValidValue(A29LocationId.ToString()));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynLocationId.CurrentValue = A29LocationId.ToString();
         }
         /*  Sending validation outputs */
         AssignProp("", false, divSupplieragb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divSupplieragb_Visible), 5, 0), true);
         AssignProp("", false, divSupplieragbpre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divSupplieragbpre_Visible), 5, 0), true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV12ProductServiceId","fld":"vPRODUCTSERVICEID","hsh":true},{"av":"AV33LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV34OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV19WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV61RoleName","fld":"vROLENAME","hsh":true},{"av":"AV16TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV12ProductServiceId","fld":"vPRODUCTSERVICEID","hsh":true},{"av":"AV33LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV34OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E16082","iparms":[{"av":"AV19WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"A58ProductServiceId","fld":"PRODUCTSERVICEID"},{"av":"A59ProductServiceName","fld":"PRODUCTSERVICENAME"},{"av":"AV61RoleName","fld":"vROLENAME","hsh":true},{"av":"AV16TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]""");
         setEventMetadata("AFTER TRN",""","oparms":[{"av":"AV61RoleName","fld":"vROLENAME","hsh":true},{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]}""");
         setEventMetadata("COMBO_SUPPLIERAGB_ID.ONOPTIONCLICKED","""{"handler":"E15082","iparms":[{"av":"Combo_supplieragb_id_Selectedvalue_get","ctrl":"COMBO_SUPPLIERAGB_ID","prop":"SelectedValue_get"},{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]""");
         setEventMetadata("COMBO_SUPPLIERAGB_ID.ONOPTIONCLICKED",""","oparms":[{"av":"AV46SupplierAgb_Id","fld":"vSUPPLIERAGB_ID"},{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]}""");
         setEventMetadata("COMBO_SUPPLIERAGBID.ONOPTIONCLICKED","""{"handler":"E14082","iparms":[{"av":"Combo_supplieragbid_Selectedvalue_get","ctrl":"COMBO_SUPPLIERAGBID","prop":"SelectedValue_get"},{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]""");
         setEventMetadata("COMBO_SUPPLIERAGBID.ONOPTIONCLICKED",""","oparms":[{"av":"AV30ComboSupplierAgbId","fld":"vCOMBOSUPPLIERAGBID"},{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]}""");
         setEventMetadata("COMBO_SUPPLIERGEN_ID.ONOPTIONCLICKED","""{"handler":"E13082","iparms":[{"av":"Combo_suppliergen_id_Selectedvalue_get","ctrl":"COMBO_SUPPLIERGEN_ID","prop":"SelectedValue_get"},{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]""");
         setEventMetadata("COMBO_SUPPLIERGEN_ID.ONOPTIONCLICKED",""","oparms":[{"av":"AV47SupplierGen_Id","fld":"vSUPPLIERGEN_ID"},{"av":"AV26ComboSupplierGenId","fld":"vCOMBOSUPPLIERGENID"},{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]}""");
         setEventMetadata("COMBO_SUPPLIERGENID.ONOPTIONCLICKED","""{"handler":"E12082","iparms":[{"av":"Combo_suppliergenid_Selectedvalue_get","ctrl":"COMBO_SUPPLIERGENID","prop":"SelectedValue_get"},{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]""");
         setEventMetadata("COMBO_SUPPLIERGENID.ONOPTIONCLICKED",""","oparms":[{"av":"AV26ComboSupplierGenId","fld":"vCOMBOSUPPLIERGENID"},{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]}""");
         setEventMetadata("VALID_LOCATIONID","""{"handler":"Valid_Locationid","iparms":[{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]""");
         setEventMetadata("VALID_LOCATIONID",""","oparms":[{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]}""");
         setEventMetadata("VALID_PRODUCTSERVICENAME","""{"handler":"Valid_Productservicename","iparms":[{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]""");
         setEventMetadata("VALID_PRODUCTSERVICENAME",""","oparms":[{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]}""");
         setEventMetadata("VALID_PRODUCTSERVICEGROUP","""{"handler":"Valid_Productservicegroup","iparms":[{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]""");
         setEventMetadata("VALID_PRODUCTSERVICEGROUP",""","oparms":[{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]}""");
         setEventMetadata("VALID_SUPPLIERGENID","""{"handler":"Valid_Suppliergenid","iparms":[{"av":"A42SupplierGenId","fld":"SUPPLIERGENID"},{"av":"A44SupplierGenCompanyName","fld":"SUPPLIERGENCOMPANYNAME"},{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]""");
         setEventMetadata("VALID_SUPPLIERGENID",""","oparms":[{"av":"A44SupplierGenCompanyName","fld":"SUPPLIERGENCOMPANYNAME"},{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]}""");
         setEventMetadata("VALIDV_LISTGEN","""{"handler":"Validv_Listgen","iparms":[{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]""");
         setEventMetadata("VALIDV_LISTGEN",""","oparms":[{"av":"divSuppliergen_Visible","ctrl":"SUPPLIERGEN","prop":"Visible"},{"av":"divSuppliergenpre_Visible","ctrl":"SUPPLIERGENPRE","prop":"Visible"},{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]}""");
         setEventMetadata("VALID_SUPPLIERAGBID","""{"handler":"Valid_Supplieragbid","iparms":[{"av":"A49SupplierAgbId","fld":"SUPPLIERAGBID"},{"av":"A51SupplierAgbName","fld":"SUPPLIERAGBNAME"},{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]""");
         setEventMetadata("VALID_SUPPLIERAGBID",""","oparms":[{"av":"A51SupplierAgbName","fld":"SUPPLIERAGBNAME"},{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]}""");
         setEventMetadata("VALIDV_LISTAGB","""{"handler":"Validv_Listagb","iparms":[{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]""");
         setEventMetadata("VALIDV_LISTAGB",""","oparms":[{"av":"divSupplieragb_Visible","ctrl":"SUPPLIERAGB","prop":"Visible"},{"av":"divSupplieragbpre_Visible","ctrl":"SUPPLIERAGBPRE","prop":"Visible"},{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]}""");
         setEventMetadata("VALIDV_COMBOSUPPLIERGENID","""{"handler":"Validv_Combosuppliergenid","iparms":[{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]""");
         setEventMetadata("VALIDV_COMBOSUPPLIERGENID",""","oparms":[{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]}""");
         setEventMetadata("VALIDV_COMBOSUPPLIERAGBID","""{"handler":"Validv_Combosupplieragbid","iparms":[{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]""");
         setEventMetadata("VALIDV_COMBOSUPPLIERAGBID",""","oparms":[{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]}""");
         setEventMetadata("VALID_PRODUCTSERVICEID","""{"handler":"Valid_Productserviceid","iparms":[{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]""");
         setEventMetadata("VALID_PRODUCTSERVICEID",""","oparms":[{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]}""");
         setEventMetadata("VALID_ORGANISATIONID","""{"handler":"Valid_Organisationid","iparms":[{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]""");
         setEventMetadata("VALID_ORGANISATIONID",""","oparms":[{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]}""");
         setEventMetadata("VALID_PRODUCTSERVICETILENAME","""{"handler":"Valid_Productservicetilename","iparms":[{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]""");
         setEventMetadata("VALID_PRODUCTSERVICETILENAME",""","oparms":[{"av":"dynProductServiceGroup"},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV43ListGen","fld":"vLISTGEN"},{"av":"AV51ListGenPre","fld":"vLISTGENPRE"},{"av":"AV42ListAgb","fld":"vLISTAGB"},{"av":"AV52ListAgbPre","fld":"vLISTAGBPRE"}]}""");
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
         pr_default.close(22);
         pr_default.close(23);
         pr_default.close(16);
         pr_default.close(24);
         pr_default.close(17);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV12ProductServiceId = Guid.Empty;
         wcpOAV33LocationId = Guid.Empty;
         wcpOAV34OrganisationId = Guid.Empty;
         Z58ProductServiceId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         Z59ProductServiceName = "";
         Z266ProductServiceTileName = "";
         Z370ProductServiceClass = "";
         Z338ProductServiceGroup = "";
         Z42SupplierGenId = Guid.Empty;
         Z49SupplierAgbId = Guid.Empty;
         N42SupplierGenId = Guid.Empty;
         N49SupplierAgbId = Guid.Empty;
         Combo_supplieragb_id_Selectedvalue_get = "";
         Combo_supplieragbid_Selectedvalue_get = "";
         Combo_suppliergen_id_Selectedvalue_get = "";
         Combo_suppliergenid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A58ProductServiceId = Guid.Empty;
         AV67UploadedFiles = new GXBaseCollection<SdtSDT_FileUploadData>( context, "SDT_FileUploadData", "Comforta_version2");
         AV68FilesToUpdate = new GXBaseCollection<SdtSDT_FileUploadData>( context, "SDT_FileUploadData", "Comforta_version2");
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A42SupplierGenId = Guid.Empty;
         A49SupplierAgbId = Guid.Empty;
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A370ProductServiceClass = "";
         A338ProductServiceGroup = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A59ProductServiceName = "";
         lblProductserviceimagetext_Jsonclick = "";
         ucImageuploaduc = new GXUserControl();
         AV60SupplierLocation = "";
         lblTextblocksuppliergenid_Jsonclick = "";
         sStyleString = "";
         ucCombo_suppliergenid = new GXUserControl();
         Combo_suppliergenid_Caption = "";
         AV21SupplierGenId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockcombo_suppliergen_id_Jsonclick = "";
         ucCombo_suppliergen_id = new GXUserControl();
         AV22DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV49SupplierGen_Id_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblocksupplieragbid_Jsonclick = "";
         ucCombo_supplieragbid = new GXUserControl();
         Combo_supplieragbid_Caption = "";
         AV29SupplierAgbId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockcombo_supplieragb_id_Jsonclick = "";
         ucCombo_supplieragb_id = new GXUserControl();
         AV48SupplierAgb_Id_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         ucProductservicedescription = new GXUserControl();
         ProductServiceDescription = "";
         lblTextblockdescriptionlabel_Jsonclick = "";
         lblDescriptiontext_Jsonclick = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV26ComboSupplierGenId = Guid.Empty;
         AV47SupplierGen_Id = Guid.Empty;
         AV30ComboSupplierAgbId = Guid.Empty;
         AV46SupplierAgb_Id = Guid.Empty;
         A266ProductServiceTileName = "";
         A61ProductServiceImage = "";
         A40000ProductServiceImage_GXI = "";
         sImgUrl = "";
         AV10Insert_SupplierGenId = Guid.Empty;
         AV9Insert_SupplierAgbId = Guid.Empty;
         AV66SDT_TrnAttributes = new SdtSDT_TrnAttributes(context);
         A60ProductServiceDescription = "";
         A44SupplierGenCompanyName = "";
         A51SupplierAgbName = "";
         AV71Pgmname = "";
         Imageuploaduc_Objectcall = "";
         Imageuploaduc_Class = "";
         Combo_suppliergenid_Objectcall = "";
         Combo_suppliergenid_Class = "";
         Combo_suppliergenid_Icontype = "";
         Combo_suppliergenid_Icon = "";
         Combo_suppliergenid_Tooltip = "";
         Combo_suppliergenid_Selectedvalue_set = "";
         Combo_suppliergenid_Selectedtext_set = "";
         Combo_suppliergenid_Selectedtext_get = "";
         Combo_suppliergenid_Gamoauthtoken = "";
         Combo_suppliergenid_Ddointernalname = "";
         Combo_suppliergenid_Titlecontrolalign = "";
         Combo_suppliergenid_Dropdownoptionstype = "";
         Combo_suppliergenid_Titlecontrolidtoreplace = "";
         Combo_suppliergenid_Datalisttype = "";
         Combo_suppliergenid_Datalistfixedvalues = "";
         Combo_suppliergenid_Datalistproc = "";
         Combo_suppliergenid_Datalistprocparametersprefix = "";
         Combo_suppliergenid_Remoteservicesparameters = "";
         Combo_suppliergenid_Htmltemplate = "";
         Combo_suppliergenid_Multiplevaluestype = "";
         Combo_suppliergenid_Loadingdata = "";
         Combo_suppliergenid_Noresultsfound = "";
         Combo_suppliergenid_Emptyitemtext = "";
         Combo_suppliergenid_Onlyselectedvalues = "";
         Combo_suppliergenid_Selectalltext = "";
         Combo_suppliergenid_Multiplevaluesseparator = "";
         Combo_suppliergenid_Addnewoptiontext = "";
         Combo_suppliergen_id_Objectcall = "";
         Combo_suppliergen_id_Class = "";
         Combo_suppliergen_id_Icontype = "";
         Combo_suppliergen_id_Icon = "";
         Combo_suppliergen_id_Tooltip = "";
         Combo_suppliergen_id_Selectedvalue_set = "";
         Combo_suppliergen_id_Selectedtext_set = "";
         Combo_suppliergen_id_Selectedtext_get = "";
         Combo_suppliergen_id_Gamoauthtoken = "";
         Combo_suppliergen_id_Ddointernalname = "";
         Combo_suppliergen_id_Titlecontrolalign = "";
         Combo_suppliergen_id_Dropdownoptionstype = "";
         Combo_suppliergen_id_Titlecontrolidtoreplace = "";
         Combo_suppliergen_id_Datalisttype = "";
         Combo_suppliergen_id_Datalistfixedvalues = "";
         Combo_suppliergen_id_Datalistproc = "";
         Combo_suppliergen_id_Datalistprocparametersprefix = "";
         Combo_suppliergen_id_Remoteservicesparameters = "";
         Combo_suppliergen_id_Htmltemplate = "";
         Combo_suppliergen_id_Multiplevaluestype = "";
         Combo_suppliergen_id_Loadingdata = "";
         Combo_suppliergen_id_Noresultsfound = "";
         Combo_suppliergen_id_Emptyitemtext = "";
         Combo_suppliergen_id_Onlyselectedvalues = "";
         Combo_suppliergen_id_Selectalltext = "";
         Combo_suppliergen_id_Multiplevaluesseparator = "";
         Combo_suppliergen_id_Addnewoptiontext = "";
         Combo_supplieragbid_Objectcall = "";
         Combo_supplieragbid_Class = "";
         Combo_supplieragbid_Icontype = "";
         Combo_supplieragbid_Icon = "";
         Combo_supplieragbid_Tooltip = "";
         Combo_supplieragbid_Selectedvalue_set = "";
         Combo_supplieragbid_Selectedtext_set = "";
         Combo_supplieragbid_Selectedtext_get = "";
         Combo_supplieragbid_Gamoauthtoken = "";
         Combo_supplieragbid_Ddointernalname = "";
         Combo_supplieragbid_Titlecontrolalign = "";
         Combo_supplieragbid_Dropdownoptionstype = "";
         Combo_supplieragbid_Titlecontrolidtoreplace = "";
         Combo_supplieragbid_Datalisttype = "";
         Combo_supplieragbid_Datalistfixedvalues = "";
         Combo_supplieragbid_Datalistproc = "";
         Combo_supplieragbid_Datalistprocparametersprefix = "";
         Combo_supplieragbid_Remoteservicesparameters = "";
         Combo_supplieragbid_Htmltemplate = "";
         Combo_supplieragbid_Multiplevaluestype = "";
         Combo_supplieragbid_Loadingdata = "";
         Combo_supplieragbid_Noresultsfound = "";
         Combo_supplieragbid_Emptyitemtext = "";
         Combo_supplieragbid_Onlyselectedvalues = "";
         Combo_supplieragbid_Selectalltext = "";
         Combo_supplieragbid_Multiplevaluesseparator = "";
         Combo_supplieragbid_Addnewoptiontext = "";
         Combo_supplieragb_id_Objectcall = "";
         Combo_supplieragb_id_Class = "";
         Combo_supplieragb_id_Icontype = "";
         Combo_supplieragb_id_Icon = "";
         Combo_supplieragb_id_Tooltip = "";
         Combo_supplieragb_id_Selectedvalue_set = "";
         Combo_supplieragb_id_Selectedtext_set = "";
         Combo_supplieragb_id_Selectedtext_get = "";
         Combo_supplieragb_id_Gamoauthtoken = "";
         Combo_supplieragb_id_Ddointernalname = "";
         Combo_supplieragb_id_Titlecontrolalign = "";
         Combo_supplieragb_id_Dropdownoptionstype = "";
         Combo_supplieragb_id_Titlecontrolidtoreplace = "";
         Combo_supplieragb_id_Datalisttype = "";
         Combo_supplieragb_id_Datalistfixedvalues = "";
         Combo_supplieragb_id_Datalistproc = "";
         Combo_supplieragb_id_Datalistprocparametersprefix = "";
         Combo_supplieragb_id_Remoteservicesparameters = "";
         Combo_supplieragb_id_Htmltemplate = "";
         Combo_supplieragb_id_Multiplevaluestype = "";
         Combo_supplieragb_id_Loadingdata = "";
         Combo_supplieragb_id_Noresultsfound = "";
         Combo_supplieragb_id_Emptyitemtext = "";
         Combo_supplieragb_id_Onlyselectedvalues = "";
         Combo_supplieragb_id_Selectalltext = "";
         Combo_supplieragb_id_Multiplevaluesseparator = "";
         Combo_supplieragb_id_Addnewoptiontext = "";
         Productservicedescription_Objectcall = "";
         Productservicedescription_Class = "";
         Productservicedescription_Buttonpressedid = "";
         Productservicedescription_Captionvalue = "";
         Productservicedescription_Coltitle = "";
         Productservicedescription_Coltitlefont = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode68 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV41PreferredGenSuppliers = new GxSimpleCollection<Guid>();
         GXt_objcol_guid1 = new GxSimpleCollection<Guid>();
         AV19WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV16TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV18WebSession = context.GetSession();
         AV17TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         GXt_objcol_SdtSDT_FileUploadData3 = new GXBaseCollection<SdtSDT_FileUploadData>( context, "SDT_FileUploadData", "Comforta_version2");
         AV61RoleName = "";
         AV63SDT_NotificationMetadata = new SdtSDT_NotificationMetadata(context);
         AV64WWPNotificationMetadataSDT = new SdtUSDTNotificationMetadata(context);
         AV62NotificationDescription = "";
         AV55NotificationLink = "";
         GXEncryptionTmp = "";
         GXt_char5 = "";
         GXt_char4 = "";
         AV23ComboSelectedValue = "";
         GXt_objcol_SdtDVB_SDTComboData_Item6 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         Z60ProductServiceDescription = "";
         Z61ProductServiceImage = "";
         Z40000ProductServiceImage_GXI = "";
         Z44SupplierGenCompanyName = "";
         Z51SupplierAgbName = "";
         T00085_A44SupplierGenCompanyName = new string[] {""} ;
         T00086_A51SupplierAgbName = new string[] {""} ;
         T00087_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T00087_n58ProductServiceId = new bool[] {false} ;
         T00087_A59ProductServiceName = new string[] {""} ;
         T00087_A266ProductServiceTileName = new string[] {""} ;
         T00087_A60ProductServiceDescription = new string[] {""} ;
         T00087_A370ProductServiceClass = new string[] {""} ;
         T00087_A40000ProductServiceImage_GXI = new string[] {""} ;
         T00087_A338ProductServiceGroup = new string[] {""} ;
         T00087_A44SupplierGenCompanyName = new string[] {""} ;
         T00087_A51SupplierAgbName = new string[] {""} ;
         T00087_A29LocationId = new Guid[] {Guid.Empty} ;
         T00087_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00087_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T00087_n42SupplierGenId = new bool[] {false} ;
         T00087_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         T00087_n49SupplierAgbId = new bool[] {false} ;
         T00087_A61ProductServiceImage = new string[] {""} ;
         T00084_A29LocationId = new Guid[] {Guid.Empty} ;
         T00088_A29LocationId = new Guid[] {Guid.Empty} ;
         T00089_A44SupplierGenCompanyName = new string[] {""} ;
         T000810_A51SupplierAgbName = new string[] {""} ;
         T000811_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T000811_n58ProductServiceId = new bool[] {false} ;
         T000811_A29LocationId = new Guid[] {Guid.Empty} ;
         T000811_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00083_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T00083_n58ProductServiceId = new bool[] {false} ;
         T00083_A59ProductServiceName = new string[] {""} ;
         T00083_A266ProductServiceTileName = new string[] {""} ;
         T00083_A60ProductServiceDescription = new string[] {""} ;
         T00083_A370ProductServiceClass = new string[] {""} ;
         T00083_A40000ProductServiceImage_GXI = new string[] {""} ;
         T00083_A338ProductServiceGroup = new string[] {""} ;
         T00083_A29LocationId = new Guid[] {Guid.Empty} ;
         T00083_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00083_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T00083_n42SupplierGenId = new bool[] {false} ;
         T00083_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         T00083_n49SupplierAgbId = new bool[] {false} ;
         T00083_A61ProductServiceImage = new string[] {""} ;
         T000812_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T000812_n58ProductServiceId = new bool[] {false} ;
         T000812_A29LocationId = new Guid[] {Guid.Empty} ;
         T000812_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000813_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T000813_n58ProductServiceId = new bool[] {false} ;
         T000813_A29LocationId = new Guid[] {Guid.Empty} ;
         T000813_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00082_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T00082_n58ProductServiceId = new bool[] {false} ;
         T00082_A59ProductServiceName = new string[] {""} ;
         T00082_A266ProductServiceTileName = new string[] {""} ;
         T00082_A60ProductServiceDescription = new string[] {""} ;
         T00082_A370ProductServiceClass = new string[] {""} ;
         T00082_A40000ProductServiceImage_GXI = new string[] {""} ;
         T00082_A338ProductServiceGroup = new string[] {""} ;
         T00082_A29LocationId = new Guid[] {Guid.Empty} ;
         T00082_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00082_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T00082_n42SupplierGenId = new bool[] {false} ;
         T00082_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         T00082_n49SupplierAgbId = new bool[] {false} ;
         T00082_A61ProductServiceImage = new string[] {""} ;
         T000818_A44SupplierGenCompanyName = new string[] {""} ;
         T000819_A51SupplierAgbName = new string[] {""} ;
         T000820_A392Trn_PageId = new Guid[] {Guid.Empty} ;
         T000820_A29LocationId = new Guid[] {Guid.Empty} ;
         T000821_A339CallToActionId = new Guid[] {Guid.Empty} ;
         T000822_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T000822_n58ProductServiceId = new bool[] {false} ;
         T000822_A29LocationId = new Guid[] {Guid.Empty} ;
         T000822_A11OrganisationId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         i338ProductServiceGroup = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T000823_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000823_A29LocationId = new Guid[] {Guid.Empty} ;
         T000823_A31LocationName = new string[] {""} ;
         GXt_SdtSDT_TrnAttributes7 = new SdtSDT_TrnAttributes(context);
         T000824_A29LocationId = new Guid[] {Guid.Empty} ;
         T000825_A44SupplierGenCompanyName = new string[] {""} ;
         T000826_A51SupplierAgbName = new string[] {""} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_productservice__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_productservice__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_productservice__default(),
            new Object[][] {
                new Object[] {
               T00082_A58ProductServiceId, T00082_A59ProductServiceName, T00082_A266ProductServiceTileName, T00082_A60ProductServiceDescription, T00082_A370ProductServiceClass, T00082_A40000ProductServiceImage_GXI, T00082_A338ProductServiceGroup, T00082_A29LocationId, T00082_A11OrganisationId, T00082_A42SupplierGenId,
               T00082_n42SupplierGenId, T00082_A49SupplierAgbId, T00082_n49SupplierAgbId, T00082_A61ProductServiceImage
               }
               , new Object[] {
               T00083_A58ProductServiceId, T00083_A59ProductServiceName, T00083_A266ProductServiceTileName, T00083_A60ProductServiceDescription, T00083_A370ProductServiceClass, T00083_A40000ProductServiceImage_GXI, T00083_A338ProductServiceGroup, T00083_A29LocationId, T00083_A11OrganisationId, T00083_A42SupplierGenId,
               T00083_n42SupplierGenId, T00083_A49SupplierAgbId, T00083_n49SupplierAgbId, T00083_A61ProductServiceImage
               }
               , new Object[] {
               T00084_A29LocationId
               }
               , new Object[] {
               T00085_A44SupplierGenCompanyName
               }
               , new Object[] {
               T00086_A51SupplierAgbName
               }
               , new Object[] {
               T00087_A58ProductServiceId, T00087_A59ProductServiceName, T00087_A266ProductServiceTileName, T00087_A60ProductServiceDescription, T00087_A370ProductServiceClass, T00087_A40000ProductServiceImage_GXI, T00087_A338ProductServiceGroup, T00087_A44SupplierGenCompanyName, T00087_A51SupplierAgbName, T00087_A29LocationId,
               T00087_A11OrganisationId, T00087_A42SupplierGenId, T00087_n42SupplierGenId, T00087_A49SupplierAgbId, T00087_n49SupplierAgbId, T00087_A61ProductServiceImage
               }
               , new Object[] {
               T00088_A29LocationId
               }
               , new Object[] {
               T00089_A44SupplierGenCompanyName
               }
               , new Object[] {
               T000810_A51SupplierAgbName
               }
               , new Object[] {
               T000811_A58ProductServiceId, T000811_A29LocationId, T000811_A11OrganisationId
               }
               , new Object[] {
               T000812_A58ProductServiceId, T000812_A29LocationId, T000812_A11OrganisationId
               }
               , new Object[] {
               T000813_A58ProductServiceId, T000813_A29LocationId, T000813_A11OrganisationId
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
               T000818_A44SupplierGenCompanyName
               }
               , new Object[] {
               T000819_A51SupplierAgbName
               }
               , new Object[] {
               T000820_A392Trn_PageId, T000820_A29LocationId
               }
               , new Object[] {
               T000821_A339CallToActionId
               }
               , new Object[] {
               T000822_A58ProductServiceId, T000822_A29LocationId, T000822_A11OrganisationId
               }
               , new Object[] {
               T000823_A11OrganisationId, T000823_A29LocationId, T000823_A31LocationName
               }
               , new Object[] {
               T000824_A29LocationId
               }
               , new Object[] {
               T000825_A44SupplierGenCompanyName
               }
               , new Object[] {
               T000826_A51SupplierAgbName
               }
            }
         );
         Z58ProductServiceId = Guid.NewGuid( );
         n58ProductServiceId = false;
         A58ProductServiceId = Guid.NewGuid( );
         n58ProductServiceId = false;
         AV71Pgmname = "Trn_ProductService";
         Z338ProductServiceGroup = "Location";
         A338ProductServiceGroup = "Location";
         i338ProductServiceGroup = "Location";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound68 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtProductServiceName_Enabled ;
      private int edtavSupplierlocation_Visible ;
      private int edtavSupplierlocation_Enabled ;
      private int divTablegen_Visible ;
      private int divSuppliergen_Visible ;
      private int edtSupplierGenId_Visible ;
      private int edtSupplierGenId_Enabled ;
      private int divSuppliergenpre_Visible ;
      private int divTableagb_Visible ;
      private int divSupplieragb_Visible ;
      private int edtSupplierAgbId_Visible ;
      private int edtSupplierAgbId_Enabled ;
      private int divSupplieragbpre_Visible ;
      private int divProductsevicetable_Visible ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavCombosuppliergenid_Visible ;
      private int edtavCombosuppliergenid_Enabled ;
      private int edtavSuppliergen_id_Visible ;
      private int edtavSuppliergen_id_Enabled ;
      private int edtavCombosupplieragbid_Visible ;
      private int edtavCombosupplieragbid_Enabled ;
      private int edtavSupplieragb_id_Visible ;
      private int edtavSupplieragb_id_Enabled ;
      private int edtProductServiceId_Visible ;
      private int edtProductServiceId_Enabled ;
      private int edtOrganisationId_Visible ;
      private int edtOrganisationId_Enabled ;
      private int edtProductServiceTileName_Visible ;
      private int edtProductServiceTileName_Enabled ;
      private int imgProductServiceImage_Visible ;
      private int imgProductServiceImage_Enabled ;
      private int Combo_suppliergenid_Datalistupdateminimumcharacters ;
      private int Combo_suppliergenid_Gxcontroltype ;
      private int Combo_suppliergen_id_Datalistupdateminimumcharacters ;
      private int Combo_suppliergen_id_Gxcontroltype ;
      private int Combo_supplieragbid_Datalistupdateminimumcharacters ;
      private int Combo_supplieragbid_Gxcontroltype ;
      private int Combo_supplieragb_id_Datalistupdateminimumcharacters ;
      private int Combo_supplieragb_id_Gxcontroltype ;
      private int Productservicedescription_Color ;
      private int Productservicedescription_Coltitlecolor ;
      private int AV72GXV1 ;
      private int idxLst ;
      private int gxdynajaxindex ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z266ProductServiceTileName ;
      private string Combo_supplieragb_id_Selectedvalue_get ;
      private string Combo_supplieragbid_Selectedvalue_get ;
      private string Combo_suppliergen_id_Selectedvalue_get ;
      private string Combo_suppliergenid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string dynLocationId_Internalname ;
      private string cmbProductServiceClass_Internalname ;
      private string dynProductServiceGroup_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string divLocationid_cell_Internalname ;
      private string divLocationid_cell_Class ;
      private string TempTags ;
      private string dynLocationId_Jsonclick ;
      private string edtProductServiceName_Internalname ;
      private string edtProductServiceName_Jsonclick ;
      private string divUnnamedtable6_Internalname ;
      private string lblProductserviceimagetext_Internalname ;
      private string lblProductserviceimagetext_Jsonclick ;
      private string divUcfilecell_Internalname ;
      private string Imageuploaduc_Faileduploadmessage ;
      private string Imageuploaduc_Maxnumberoffiles ;
      private string Imageuploaduc_Isreadonlymode ;
      private string Imageuploaduc_Maxfilesize ;
      private string Imageuploaduc_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string cmbProductServiceClass_Jsonclick ;
      private string dynProductServiceGroup_Jsonclick ;
      private string divSupplierlocation_cell_Internalname ;
      private string divSupplierlocation_cell_Class ;
      private string edtavSupplierlocation_Internalname ;
      private string divUnnamedtable4_Internalname ;
      private string divTablegen_Internalname ;
      private string divSuppliergen_Internalname ;
      private string divTablesplittedsuppliergenid_Internalname ;
      private string lblTextblocksuppliergenid_Internalname ;
      private string lblTextblocksuppliergenid_Jsonclick ;
      private string sStyleString ;
      private string tblTablemergedsuppliergenid_Internalname ;
      private string tblTablemergedsuppliergenid_Class ;
      private string Combo_suppliergenid_Caption ;
      private string Combo_suppliergenid_Cls ;
      private string Combo_suppliergenid_Internalname ;
      private string edtSupplierGenId_Internalname ;
      private string edtSupplierGenId_Jsonclick ;
      private string cellListgen_cell_Internalname ;
      private string cellListgen_cell_Class ;
      private string chkavListgen_Internalname ;
      private string divSuppliergenpre_Internalname ;
      private string divTablesplittedsuppliergen_id_Internalname ;
      private string lblTextblockcombo_suppliergen_id_Internalname ;
      private string lblTextblockcombo_suppliergen_id_Jsonclick ;
      private string tblTablemergedsuppliergen_id_Internalname ;
      private string Combo_suppliergen_id_Caption ;
      private string Combo_suppliergen_id_Cls ;
      private string Combo_suppliergen_id_Internalname ;
      private string cellListgenpre_cell_Internalname ;
      private string cellListgenpre_cell_Class ;
      private string chkavListgenpre_Internalname ;
      private string divTableagb_Internalname ;
      private string divSupplieragb_Internalname ;
      private string divTablesplittedsupplieragbid_Internalname ;
      private string lblTextblocksupplieragbid_Internalname ;
      private string lblTextblocksupplieragbid_Jsonclick ;
      private string tblTablemergedsupplieragbid_Internalname ;
      private string tblTablemergedsupplieragbid_Class ;
      private string Combo_supplieragbid_Caption ;
      private string Combo_supplieragbid_Cls ;
      private string Combo_supplieragbid_Internalname ;
      private string edtSupplierAgbId_Internalname ;
      private string edtSupplierAgbId_Jsonclick ;
      private string cellListagb_cell_Internalname ;
      private string cellListagb_cell_Class ;
      private string chkavListagb_Internalname ;
      private string divSupplieragbpre_Internalname ;
      private string divTablesplittedsupplieragb_id_Internalname ;
      private string lblTextblockcombo_supplieragb_id_Internalname ;
      private string lblTextblockcombo_supplieragb_id_Jsonclick ;
      private string tblTablemergedsupplieragb_id_Internalname ;
      private string Combo_supplieragb_id_Caption ;
      private string Combo_supplieragb_id_Cls ;
      private string Combo_supplieragb_id_Internalname ;
      private string cellListagbpre_cell_Internalname ;
      private string cellListagbpre_cell_Class ;
      private string chkavListagbpre_Internalname ;
      private string divProductservicedescription_cell_Internalname ;
      private string divProductservicedescription_cell_Class ;
      private string Productservicedescription_Internalname ;
      private string Productservicedescription_Width ;
      private string Productservicedescription_Height ;
      private string Productservicedescription_Skin ;
      private string Productservicedescription_Toolbar ;
      private string Productservicedescription_Customtoolbar ;
      private string Productservicedescription_Customconfiguration ;
      private string Productservicedescription_Captionclass ;
      private string Productservicedescription_Captionstyle ;
      private string Productservicedescription_Captionposition ;
      private string divProductsevicetable_Internalname ;
      private string lblTextblockdescriptionlabel_Internalname ;
      private string lblTextblockdescriptionlabel_Jsonclick ;
      private string divUnnamedtable5_Internalname ;
      private string lblDescriptiontext_Internalname ;
      private string lblDescriptiontext_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_suppliergenid_Internalname ;
      private string edtavCombosuppliergenid_Internalname ;
      private string edtavCombosuppliergenid_Jsonclick ;
      private string edtavSuppliergen_id_Internalname ;
      private string edtavSuppliergen_id_Jsonclick ;
      private string divSectionattribute_supplieragbid_Internalname ;
      private string edtavCombosupplieragbid_Internalname ;
      private string edtavCombosupplieragbid_Jsonclick ;
      private string edtavSupplieragb_id_Internalname ;
      private string edtavSupplieragb_id_Jsonclick ;
      private string edtProductServiceId_Internalname ;
      private string edtProductServiceId_Jsonclick ;
      private string edtOrganisationId_Internalname ;
      private string edtOrganisationId_Jsonclick ;
      private string edtProductServiceTileName_Internalname ;
      private string A266ProductServiceTileName ;
      private string edtProductServiceTileName_Jsonclick ;
      private string sImgUrl ;
      private string imgProductServiceImage_Internalname ;
      private string AV71Pgmname ;
      private string Imageuploaduc_Objectcall ;
      private string Imageuploaduc_Class ;
      private string Combo_suppliergenid_Objectcall ;
      private string Combo_suppliergenid_Class ;
      private string Combo_suppliergenid_Icontype ;
      private string Combo_suppliergenid_Icon ;
      private string Combo_suppliergenid_Tooltip ;
      private string Combo_suppliergenid_Selectedvalue_set ;
      private string Combo_suppliergenid_Selectedtext_set ;
      private string Combo_suppliergenid_Selectedtext_get ;
      private string Combo_suppliergenid_Gamoauthtoken ;
      private string Combo_suppliergenid_Ddointernalname ;
      private string Combo_suppliergenid_Titlecontrolalign ;
      private string Combo_suppliergenid_Dropdownoptionstype ;
      private string Combo_suppliergenid_Titlecontrolidtoreplace ;
      private string Combo_suppliergenid_Datalisttype ;
      private string Combo_suppliergenid_Datalistfixedvalues ;
      private string Combo_suppliergenid_Datalistproc ;
      private string Combo_suppliergenid_Datalistprocparametersprefix ;
      private string Combo_suppliergenid_Remoteservicesparameters ;
      private string Combo_suppliergenid_Htmltemplate ;
      private string Combo_suppliergenid_Multiplevaluestype ;
      private string Combo_suppliergenid_Loadingdata ;
      private string Combo_suppliergenid_Noresultsfound ;
      private string Combo_suppliergenid_Emptyitemtext ;
      private string Combo_suppliergenid_Onlyselectedvalues ;
      private string Combo_suppliergenid_Selectalltext ;
      private string Combo_suppliergenid_Multiplevaluesseparator ;
      private string Combo_suppliergenid_Addnewoptiontext ;
      private string Combo_suppliergen_id_Objectcall ;
      private string Combo_suppliergen_id_Class ;
      private string Combo_suppliergen_id_Icontype ;
      private string Combo_suppliergen_id_Icon ;
      private string Combo_suppliergen_id_Tooltip ;
      private string Combo_suppliergen_id_Selectedvalue_set ;
      private string Combo_suppliergen_id_Selectedtext_set ;
      private string Combo_suppliergen_id_Selectedtext_get ;
      private string Combo_suppliergen_id_Gamoauthtoken ;
      private string Combo_suppliergen_id_Ddointernalname ;
      private string Combo_suppliergen_id_Titlecontrolalign ;
      private string Combo_suppliergen_id_Dropdownoptionstype ;
      private string Combo_suppliergen_id_Titlecontrolidtoreplace ;
      private string Combo_suppliergen_id_Datalisttype ;
      private string Combo_suppliergen_id_Datalistfixedvalues ;
      private string Combo_suppliergen_id_Datalistproc ;
      private string Combo_suppliergen_id_Datalistprocparametersprefix ;
      private string Combo_suppliergen_id_Remoteservicesparameters ;
      private string Combo_suppliergen_id_Htmltemplate ;
      private string Combo_suppliergen_id_Multiplevaluestype ;
      private string Combo_suppliergen_id_Loadingdata ;
      private string Combo_suppliergen_id_Noresultsfound ;
      private string Combo_suppliergen_id_Emptyitemtext ;
      private string Combo_suppliergen_id_Onlyselectedvalues ;
      private string Combo_suppliergen_id_Selectalltext ;
      private string Combo_suppliergen_id_Multiplevaluesseparator ;
      private string Combo_suppliergen_id_Addnewoptiontext ;
      private string Combo_supplieragbid_Objectcall ;
      private string Combo_supplieragbid_Class ;
      private string Combo_supplieragbid_Icontype ;
      private string Combo_supplieragbid_Icon ;
      private string Combo_supplieragbid_Tooltip ;
      private string Combo_supplieragbid_Selectedvalue_set ;
      private string Combo_supplieragbid_Selectedtext_set ;
      private string Combo_supplieragbid_Selectedtext_get ;
      private string Combo_supplieragbid_Gamoauthtoken ;
      private string Combo_supplieragbid_Ddointernalname ;
      private string Combo_supplieragbid_Titlecontrolalign ;
      private string Combo_supplieragbid_Dropdownoptionstype ;
      private string Combo_supplieragbid_Titlecontrolidtoreplace ;
      private string Combo_supplieragbid_Datalisttype ;
      private string Combo_supplieragbid_Datalistfixedvalues ;
      private string Combo_supplieragbid_Datalistproc ;
      private string Combo_supplieragbid_Datalistprocparametersprefix ;
      private string Combo_supplieragbid_Remoteservicesparameters ;
      private string Combo_supplieragbid_Htmltemplate ;
      private string Combo_supplieragbid_Multiplevaluestype ;
      private string Combo_supplieragbid_Loadingdata ;
      private string Combo_supplieragbid_Noresultsfound ;
      private string Combo_supplieragbid_Emptyitemtext ;
      private string Combo_supplieragbid_Onlyselectedvalues ;
      private string Combo_supplieragbid_Selectalltext ;
      private string Combo_supplieragbid_Multiplevaluesseparator ;
      private string Combo_supplieragbid_Addnewoptiontext ;
      private string Combo_supplieragb_id_Objectcall ;
      private string Combo_supplieragb_id_Class ;
      private string Combo_supplieragb_id_Icontype ;
      private string Combo_supplieragb_id_Icon ;
      private string Combo_supplieragb_id_Tooltip ;
      private string Combo_supplieragb_id_Selectedvalue_set ;
      private string Combo_supplieragb_id_Selectedtext_set ;
      private string Combo_supplieragb_id_Selectedtext_get ;
      private string Combo_supplieragb_id_Gamoauthtoken ;
      private string Combo_supplieragb_id_Ddointernalname ;
      private string Combo_supplieragb_id_Titlecontrolalign ;
      private string Combo_supplieragb_id_Dropdownoptionstype ;
      private string Combo_supplieragb_id_Titlecontrolidtoreplace ;
      private string Combo_supplieragb_id_Datalisttype ;
      private string Combo_supplieragb_id_Datalistfixedvalues ;
      private string Combo_supplieragb_id_Datalistproc ;
      private string Combo_supplieragb_id_Datalistprocparametersprefix ;
      private string Combo_supplieragb_id_Remoteservicesparameters ;
      private string Combo_supplieragb_id_Htmltemplate ;
      private string Combo_supplieragb_id_Multiplevaluestype ;
      private string Combo_supplieragb_id_Loadingdata ;
      private string Combo_supplieragb_id_Noresultsfound ;
      private string Combo_supplieragb_id_Emptyitemtext ;
      private string Combo_supplieragb_id_Onlyselectedvalues ;
      private string Combo_supplieragb_id_Selectalltext ;
      private string Combo_supplieragb_id_Multiplevaluesseparator ;
      private string Combo_supplieragb_id_Addnewoptiontext ;
      private string Productservicedescription_Objectcall ;
      private string Productservicedescription_Class ;
      private string Productservicedescription_Buttonpressedid ;
      private string Productservicedescription_Captionvalue ;
      private string Productservicedescription_Coltitle ;
      private string Productservicedescription_Coltitlefont ;
      private string hsh ;
      private string sMode68 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXEncryptionTmp ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string gxwrpcisep ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n58ProductServiceId ;
      private bool n42SupplierGenId ;
      private bool n49SupplierAgbId ;
      private bool wbErr ;
      private bool AV43ListGen ;
      private bool AV51ListGenPre ;
      private bool AV42ListAgb ;
      private bool AV52ListAgbPre ;
      private bool Combo_suppliergenid_Emptyitem ;
      private bool Combo_suppliergen_id_Emptyitem ;
      private bool Combo_supplieragbid_Emptyitem ;
      private bool Combo_supplieragb_id_Emptyitem ;
      private bool Productservicedescription_Toolbarcancollapse ;
      private bool A61ProductServiceImage_IsBlob ;
      private bool AV57isManager ;
      private bool Imageuploaduc_Enabled ;
      private bool Imageuploaduc_Visible ;
      private bool Combo_suppliergenid_Enabled ;
      private bool Combo_suppliergenid_Visible ;
      private bool Combo_suppliergenid_Allowmultipleselection ;
      private bool Combo_suppliergenid_Isgriditem ;
      private bool Combo_suppliergenid_Hasdescription ;
      private bool Combo_suppliergenid_Includeonlyselectedoption ;
      private bool Combo_suppliergenid_Includeselectalloption ;
      private bool Combo_suppliergenid_Includeaddnewoption ;
      private bool Combo_suppliergen_id_Enabled ;
      private bool Combo_suppliergen_id_Visible ;
      private bool Combo_suppliergen_id_Allowmultipleselection ;
      private bool Combo_suppliergen_id_Isgriditem ;
      private bool Combo_suppliergen_id_Hasdescription ;
      private bool Combo_suppliergen_id_Includeonlyselectedoption ;
      private bool Combo_suppliergen_id_Includeselectalloption ;
      private bool Combo_suppliergen_id_Includeaddnewoption ;
      private bool Combo_supplieragbid_Enabled ;
      private bool Combo_supplieragbid_Visible ;
      private bool Combo_supplieragbid_Allowmultipleselection ;
      private bool Combo_supplieragbid_Isgriditem ;
      private bool Combo_supplieragbid_Hasdescription ;
      private bool Combo_supplieragbid_Includeonlyselectedoption ;
      private bool Combo_supplieragbid_Includeselectalloption ;
      private bool Combo_supplieragbid_Includeaddnewoption ;
      private bool Combo_supplieragb_id_Enabled ;
      private bool Combo_supplieragb_id_Visible ;
      private bool Combo_supplieragb_id_Allowmultipleselection ;
      private bool Combo_supplieragb_id_Isgriditem ;
      private bool Combo_supplieragb_id_Hasdescription ;
      private bool Combo_supplieragb_id_Includeonlyselectedoption ;
      private bool Combo_supplieragb_id_Includeselectalloption ;
      private bool Combo_supplieragb_id_Includeaddnewoption ;
      private bool Productservicedescription_Enabled ;
      private bool Productservicedescription_Toolbarexpanded ;
      private bool Productservicedescription_Isabstractlayoutcontrol ;
      private bool Productservicedescription_Usercontroliscolumn ;
      private bool Productservicedescription_Visible ;
      private bool returnInSub ;
      private bool AV53IsWeb ;
      private bool Gx_longc ;
      private bool gxdyncontrolsrefreshing ;
      private string ProductServiceDescription ;
      private string A60ProductServiceDescription ;
      private string Z60ProductServiceDescription ;
      private string Z59ProductServiceName ;
      private string Z370ProductServiceClass ;
      private string Z338ProductServiceGroup ;
      private string A370ProductServiceClass ;
      private string A338ProductServiceGroup ;
      private string A59ProductServiceName ;
      private string AV60SupplierLocation ;
      private string A40000ProductServiceImage_GXI ;
      private string A44SupplierGenCompanyName ;
      private string A51SupplierAgbName ;
      private string AV61RoleName ;
      private string AV62NotificationDescription ;
      private string AV55NotificationLink ;
      private string AV23ComboSelectedValue ;
      private string Z40000ProductServiceImage_GXI ;
      private string Z44SupplierGenCompanyName ;
      private string Z51SupplierAgbName ;
      private string i338ProductServiceGroup ;
      private string A61ProductServiceImage ;
      private string Z61ProductServiceImage ;
      private Guid wcpOAV12ProductServiceId ;
      private Guid wcpOAV33LocationId ;
      private Guid wcpOAV34OrganisationId ;
      private Guid Z58ProductServiceId ;
      private Guid Z29LocationId ;
      private Guid Z11OrganisationId ;
      private Guid Z42SupplierGenId ;
      private Guid Z49SupplierAgbId ;
      private Guid N42SupplierGenId ;
      private Guid N49SupplierAgbId ;
      private Guid A58ProductServiceId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A42SupplierGenId ;
      private Guid A49SupplierAgbId ;
      private Guid AV12ProductServiceId ;
      private Guid AV33LocationId ;
      private Guid AV34OrganisationId ;
      private Guid AV26ComboSupplierGenId ;
      private Guid AV47SupplierGen_Id ;
      private Guid AV30ComboSupplierAgbId ;
      private Guid AV46SupplierAgb_Id ;
      private Guid AV10Insert_SupplierGenId ;
      private Guid AV9Insert_SupplierAgbId ;
      private IGxSession AV18WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucImageuploaduc ;
      private GXUserControl ucCombo_suppliergenid ;
      private GXUserControl ucCombo_suppliergen_id ;
      private GXUserControl ucCombo_supplieragbid ;
      private GXUserControl ucCombo_supplieragb_id ;
      private GXUserControl ucProductservicedescription ;
      private GXWebForm Form ;
      private GXBaseCollection<SdtSDT_FileUploadData> AV67UploadedFiles ;
      private GXBaseCollection<SdtSDT_FileUploadData> AV68FilesToUpdate ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynLocationId ;
      private GXCombobox cmbProductServiceClass ;
      private GXCombobox dynProductServiceGroup ;
      private GXCheckbox chkavListgen ;
      private GXCheckbox chkavListgenpre ;
      private GXCheckbox chkavListagb ;
      private GXCheckbox chkavListagbpre ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV21SupplierGenId_Data ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV22DDO_TitleSettingsIcons ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV49SupplierGen_Id_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV29SupplierAgbId_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV48SupplierAgb_Id_Data ;
      private SdtSDT_TrnAttributes AV66SDT_TrnAttributes ;
      private GxSimpleCollection<Guid> AV41PreferredGenSuppliers ;
      private GxSimpleCollection<Guid> GXt_objcol_guid1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV19WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV16TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV17TrnContextAtt ;
      private GXBaseCollection<SdtSDT_FileUploadData> GXt_objcol_SdtSDT_FileUploadData3 ;
      private SdtSDT_NotificationMetadata AV63SDT_NotificationMetadata ;
      private SdtUSDTNotificationMetadata AV64WWPNotificationMetadataSDT ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> GXt_objcol_SdtDVB_SDTComboData_Item6 ;
      private IDataStoreProvider pr_default ;
      private string[] T00085_A44SupplierGenCompanyName ;
      private string[] T00086_A51SupplierAgbName ;
      private Guid[] T00087_A58ProductServiceId ;
      private bool[] T00087_n58ProductServiceId ;
      private string[] T00087_A59ProductServiceName ;
      private string[] T00087_A266ProductServiceTileName ;
      private string[] T00087_A60ProductServiceDescription ;
      private string[] T00087_A370ProductServiceClass ;
      private string[] T00087_A40000ProductServiceImage_GXI ;
      private string[] T00087_A338ProductServiceGroup ;
      private string[] T00087_A44SupplierGenCompanyName ;
      private string[] T00087_A51SupplierAgbName ;
      private Guid[] T00087_A29LocationId ;
      private Guid[] T00087_A11OrganisationId ;
      private Guid[] T00087_A42SupplierGenId ;
      private bool[] T00087_n42SupplierGenId ;
      private Guid[] T00087_A49SupplierAgbId ;
      private bool[] T00087_n49SupplierAgbId ;
      private string[] T00087_A61ProductServiceImage ;
      private Guid[] T00084_A29LocationId ;
      private Guid[] T00088_A29LocationId ;
      private string[] T00089_A44SupplierGenCompanyName ;
      private string[] T000810_A51SupplierAgbName ;
      private Guid[] T000811_A58ProductServiceId ;
      private bool[] T000811_n58ProductServiceId ;
      private Guid[] T000811_A29LocationId ;
      private Guid[] T000811_A11OrganisationId ;
      private Guid[] T00083_A58ProductServiceId ;
      private bool[] T00083_n58ProductServiceId ;
      private string[] T00083_A59ProductServiceName ;
      private string[] T00083_A266ProductServiceTileName ;
      private string[] T00083_A60ProductServiceDescription ;
      private string[] T00083_A370ProductServiceClass ;
      private string[] T00083_A40000ProductServiceImage_GXI ;
      private string[] T00083_A338ProductServiceGroup ;
      private Guid[] T00083_A29LocationId ;
      private Guid[] T00083_A11OrganisationId ;
      private Guid[] T00083_A42SupplierGenId ;
      private bool[] T00083_n42SupplierGenId ;
      private Guid[] T00083_A49SupplierAgbId ;
      private bool[] T00083_n49SupplierAgbId ;
      private string[] T00083_A61ProductServiceImage ;
      private Guid[] T000812_A58ProductServiceId ;
      private bool[] T000812_n58ProductServiceId ;
      private Guid[] T000812_A29LocationId ;
      private Guid[] T000812_A11OrganisationId ;
      private Guid[] T000813_A58ProductServiceId ;
      private bool[] T000813_n58ProductServiceId ;
      private Guid[] T000813_A29LocationId ;
      private Guid[] T000813_A11OrganisationId ;
      private Guid[] T00082_A58ProductServiceId ;
      private bool[] T00082_n58ProductServiceId ;
      private string[] T00082_A59ProductServiceName ;
      private string[] T00082_A266ProductServiceTileName ;
      private string[] T00082_A60ProductServiceDescription ;
      private string[] T00082_A370ProductServiceClass ;
      private string[] T00082_A40000ProductServiceImage_GXI ;
      private string[] T00082_A338ProductServiceGroup ;
      private Guid[] T00082_A29LocationId ;
      private Guid[] T00082_A11OrganisationId ;
      private Guid[] T00082_A42SupplierGenId ;
      private bool[] T00082_n42SupplierGenId ;
      private Guid[] T00082_A49SupplierAgbId ;
      private bool[] T00082_n49SupplierAgbId ;
      private string[] T00082_A61ProductServiceImage ;
      private string[] T000818_A44SupplierGenCompanyName ;
      private string[] T000819_A51SupplierAgbName ;
      private Guid[] T000820_A392Trn_PageId ;
      private Guid[] T000820_A29LocationId ;
      private Guid[] T000821_A339CallToActionId ;
      private Guid[] T000822_A58ProductServiceId ;
      private bool[] T000822_n58ProductServiceId ;
      private Guid[] T000822_A29LocationId ;
      private Guid[] T000822_A11OrganisationId ;
      private Guid[] T000823_A11OrganisationId ;
      private Guid[] T000823_A29LocationId ;
      private string[] T000823_A31LocationName ;
      private SdtSDT_TrnAttributes GXt_SdtSDT_TrnAttributes7 ;
      private Guid[] T000824_A29LocationId ;
      private string[] T000825_A44SupplierGenCompanyName ;
      private string[] T000826_A51SupplierAgbName ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_productservice__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_productservice__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_productservice__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[15])
      ,new ForEachCursor(def[16])
      ,new ForEachCursor(def[17])
      ,new ForEachCursor(def[18])
      ,new ForEachCursor(def[19])
      ,new ForEachCursor(def[20])
      ,new ForEachCursor(def[21])
      ,new ForEachCursor(def[22])
      ,new ForEachCursor(def[23])
      ,new ForEachCursor(def[24])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT00082;
       prmT00082 = new Object[] {
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00083;
       prmT00083 = new Object[] {
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00084;
       prmT00084 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00085;
       prmT00085 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT00086;
       prmT00086 = new Object[] {
       new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT00087;
       prmT00087 = new Object[] {
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00088;
       prmT00088 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00089;
       prmT00089 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000810;
       prmT000810 = new Object[] {
       new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000811;
       prmT000811 = new Object[] {
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000812;
       prmT000812 = new Object[] {
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000813;
       prmT000813 = new Object[] {
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000814;
       prmT000814 = new Object[] {
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ProductServiceName",GXType.VarChar,100,0) ,
       new ParDef("ProductServiceTileName",GXType.Char,20,0) ,
       new ParDef("ProductServiceDescription",GXType.LongVarChar,2097152,0) ,
       new ParDef("ProductServiceClass",GXType.VarChar,400,0) ,
       new ParDef("ProductServiceImage",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("ProductServiceImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=5, Tbl="Trn_ProductService", Fld="ProductServiceImage"} ,
       new ParDef("ProductServiceGroup",GXType.VarChar,400,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000815;
       prmT000815 = new Object[] {
       new ParDef("ProductServiceName",GXType.VarChar,100,0) ,
       new ParDef("ProductServiceTileName",GXType.Char,20,0) ,
       new ParDef("ProductServiceDescription",GXType.LongVarChar,2097152,0) ,
       new ParDef("ProductServiceClass",GXType.VarChar,400,0) ,
       new ParDef("ProductServiceGroup",GXType.VarChar,400,0) ,
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000816;
       prmT000816 = new Object[] {
       new ParDef("ProductServiceImage",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("ProductServiceImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Trn_ProductService", Fld="ProductServiceImage"} ,
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000817;
       prmT000817 = new Object[] {
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000818;
       prmT000818 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000819;
       prmT000819 = new Object[] {
       new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000820;
       prmT000820 = new Object[] {
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000821;
       prmT000821 = new Object[] {
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000822;
       prmT000822 = new Object[] {
       };
       Object[] prmT000823;
       prmT000823 = new Object[] {
       };
       Object[] prmT000824;
       prmT000824 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000825;
       prmT000825 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000826;
       prmT000826 = new Object[] {
       new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       def= new CursorDef[] {
           new CursorDef("T00082", "SELECT ProductServiceId, ProductServiceName, ProductServiceTileName, ProductServiceDescription, ProductServiceClass, ProductServiceImage_GXI, ProductServiceGroup, LocationId, OrganisationId, SupplierGenId, SupplierAgbId, ProductServiceImage FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId  FOR UPDATE OF Trn_ProductService NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00082,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00083", "SELECT ProductServiceId, ProductServiceName, ProductServiceTileName, ProductServiceDescription, ProductServiceClass, ProductServiceImage_GXI, ProductServiceGroup, LocationId, OrganisationId, SupplierGenId, SupplierAgbId, ProductServiceImage FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00083,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00084", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00084,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00085", "SELECT SupplierGenCompanyName FROM Trn_SupplierGen WHERE SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00085,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00086", "SELECT SupplierAgbName FROM Trn_SupplierAGB WHERE SupplierAgbId = :SupplierAgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00086,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00087", "SELECT TM1.ProductServiceId, TM1.ProductServiceName, TM1.ProductServiceTileName, TM1.ProductServiceDescription, TM1.ProductServiceClass, TM1.ProductServiceImage_GXI, TM1.ProductServiceGroup, T2.SupplierGenCompanyName, T3.SupplierAgbName, TM1.LocationId, TM1.OrganisationId, TM1.SupplierGenId, TM1.SupplierAgbId, TM1.ProductServiceImage FROM ((Trn_ProductService TM1 LEFT JOIN Trn_SupplierGen T2 ON T2.SupplierGenId = TM1.SupplierGenId) LEFT JOIN Trn_SupplierAGB T3 ON T3.SupplierAgbId = TM1.SupplierAgbId) WHERE TM1.ProductServiceId = :ProductServiceId and TM1.LocationId = :LocationId and TM1.OrganisationId = :OrganisationId ORDER BY TM1.ProductServiceId, TM1.LocationId, TM1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00087,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00088", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00088,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00089", "SELECT SupplierGenCompanyName FROM Trn_SupplierGen WHERE SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00089,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000810", "SELECT SupplierAgbName FROM Trn_SupplierAGB WHERE SupplierAgbId = :SupplierAgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000810,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000811", "SELECT ProductServiceId, LocationId, OrganisationId FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000811,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000812", "SELECT ProductServiceId, LocationId, OrganisationId FROM Trn_ProductService WHERE ( ProductServiceId > :ProductServiceId or ProductServiceId = :ProductServiceId and LocationId > :LocationId or LocationId = :LocationId and ProductServiceId = :ProductServiceId and OrganisationId > :OrganisationId) ORDER BY ProductServiceId, LocationId, OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000812,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000813", "SELECT ProductServiceId, LocationId, OrganisationId FROM Trn_ProductService WHERE ( ProductServiceId < :ProductServiceId or ProductServiceId = :ProductServiceId and LocationId < :LocationId or LocationId = :LocationId and ProductServiceId = :ProductServiceId and OrganisationId < :OrganisationId) ORDER BY ProductServiceId DESC, LocationId DESC, OrganisationId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000813,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000814", "SAVEPOINT gxupdate;INSERT INTO Trn_ProductService(ProductServiceId, ProductServiceName, ProductServiceTileName, ProductServiceDescription, ProductServiceClass, ProductServiceImage, ProductServiceImage_GXI, ProductServiceGroup, LocationId, OrganisationId, SupplierGenId, SupplierAgbId) VALUES(:ProductServiceId, :ProductServiceName, :ProductServiceTileName, :ProductServiceDescription, :ProductServiceClass, :ProductServiceImage, :ProductServiceImage_GXI, :ProductServiceGroup, :LocationId, :OrganisationId, :SupplierGenId, :SupplierAgbId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000814)
          ,new CursorDef("T000815", "SAVEPOINT gxupdate;UPDATE Trn_ProductService SET ProductServiceName=:ProductServiceName, ProductServiceTileName=:ProductServiceTileName, ProductServiceDescription=:ProductServiceDescription, ProductServiceClass=:ProductServiceClass, ProductServiceGroup=:ProductServiceGroup, SupplierGenId=:SupplierGenId, SupplierAgbId=:SupplierAgbId  WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000815)
          ,new CursorDef("T000816", "SAVEPOINT gxupdate;UPDATE Trn_ProductService SET ProductServiceImage=:ProductServiceImage, ProductServiceImage_GXI=:ProductServiceImage_GXI  WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000816)
          ,new CursorDef("T000817", "SAVEPOINT gxupdate;DELETE FROM Trn_ProductService  WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000817)
          ,new CursorDef("T000818", "SELECT SupplierGenCompanyName FROM Trn_SupplierGen WHERE SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000818,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000819", "SELECT SupplierAgbName FROM Trn_SupplierAGB WHERE SupplierAgbId = :SupplierAgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000819,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000820", "SELECT Trn_PageId, LocationId FROM Trn_Page WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000820,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000821", "SELECT CallToActionId FROM Trn_CallToAction WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000821,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000822", "SELECT ProductServiceId, LocationId, OrganisationId FROM Trn_ProductService ORDER BY ProductServiceId, LocationId, OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000822,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000823", "SELECT OrganisationId, LocationId, LocationName FROM Trn_Location ORDER BY LocationName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000823,0, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000824", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000824,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000825", "SELECT SupplierGenCompanyName FROM Trn_SupplierGen WHERE SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000825,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000826", "SELECT SupplierAgbName FROM Trn_SupplierAGB WHERE SupplierAgbId = :SupplierAgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000826,1, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((Guid[]) buf[7])[0] = rslt.getGuid(8);
             ((Guid[]) buf[8])[0] = rslt.getGuid(9);
             ((Guid[]) buf[9])[0] = rslt.getGuid(10);
             ((bool[]) buf[10])[0] = rslt.wasNull(10);
             ((Guid[]) buf[11])[0] = rslt.getGuid(11);
             ((bool[]) buf[12])[0] = rslt.wasNull(11);
             ((string[]) buf[13])[0] = rslt.getMultimediaFile(12, rslt.getVarchar(6));
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((Guid[]) buf[7])[0] = rslt.getGuid(8);
             ((Guid[]) buf[8])[0] = rslt.getGuid(9);
             ((Guid[]) buf[9])[0] = rslt.getGuid(10);
             ((bool[]) buf[10])[0] = rslt.wasNull(10);
             ((Guid[]) buf[11])[0] = rslt.getGuid(11);
             ((bool[]) buf[12])[0] = rslt.wasNull(11);
             ((string[]) buf[13])[0] = rslt.getMultimediaFile(12, rslt.getVarchar(6));
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 4 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((Guid[]) buf[9])[0] = rslt.getGuid(10);
             ((Guid[]) buf[10])[0] = rslt.getGuid(11);
             ((Guid[]) buf[11])[0] = rslt.getGuid(12);
             ((bool[]) buf[12])[0] = rslt.wasNull(12);
             ((Guid[]) buf[13])[0] = rslt.getGuid(13);
             ((bool[]) buf[14])[0] = rslt.wasNull(13);
             ((string[]) buf[15])[0] = rslt.getMultimediaFile(14, rslt.getVarchar(6));
             return;
          case 6 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 7 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 8 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 9 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 10 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 11 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 16 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 17 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 18 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 19 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 20 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 21 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             return;
          case 22 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 23 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 24 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
    }
 }

}

}
