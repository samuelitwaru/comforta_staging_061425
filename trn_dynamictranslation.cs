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
   public class trn_dynamictranslation : GXDataArea
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_dynamictranslation.aspx")), "trn_dynamictranslation.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_dynamictranslation.aspx")))) ;
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
                  AV7DynamicTranslationId = StringUtil.StrToGuid( GetPar( "DynamicTranslationId"));
                  AssignAttri("", false, "AV7DynamicTranslationId", AV7DynamicTranslationId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vDYNAMICTRANSLATIONID", GetSecureSignedToken( "", AV7DynamicTranslationId, context));
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
         Form.Meta.addItem("description", context.GetMessage( "Trn_Dynamic Translation", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtDynamicTranslationTrnName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_dynamictranslation( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_dynamictranslation( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_DynamicTranslationId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7DynamicTranslationId = aP1_DynamicTranslationId;
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
            return "trn_dynamictranslation_Execute" ;
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
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_DynamicTranslation.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDynamicTranslationTrnName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDynamicTranslationTrnName_Internalname, context.GetMessage( "Trn Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDynamicTranslationTrnName_Internalname, A579DynamicTranslationTrnName, StringUtil.RTrim( context.localUtil.Format( A579DynamicTranslationTrnName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDynamicTranslationTrnName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDynamicTranslationTrnName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_DynamicTranslation.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDynamicTranslationAttributeNam_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDynamicTranslationAttributeNam_Internalname, context.GetMessage( "Attribute Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDynamicTranslationAttributeNam_Internalname, A581DynamicTranslationAttributeNam, StringUtil.RTrim( context.localUtil.Format( A581DynamicTranslationAttributeNam, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDynamicTranslationAttributeNam_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDynamicTranslationAttributeNam_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_DynamicTranslation.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDynamicTranslationEnglish_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDynamicTranslationEnglish_Internalname, context.GetMessage( "Translation English", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtDynamicTranslationEnglish_Internalname, A582DynamicTranslationEnglish, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", 0, 1, edtDynamicTranslationEnglish_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_DynamicTranslation.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDynamicTranslationDutch_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDynamicTranslationDutch_Internalname, context.GetMessage( "Translation Dutch", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtDynamicTranslationDutch_Internalname, A583DynamicTranslationDutch, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", 0, 1, edtDynamicTranslationDutch_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_DynamicTranslation.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_DynamicTranslation.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_DynamicTranslation.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_DynamicTranslation.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDynamicTranslationId_Internalname, A578DynamicTranslationId.ToString(), A578DynamicTranslationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDynamicTranslationId_Jsonclick, 0, "Attribute", "", "", "", "", edtDynamicTranslationId_Visible, edtDynamicTranslationId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_DynamicTranslation.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDynamicTranslationPrimaryKey_Internalname, A580DynamicTranslationPrimaryKey.ToString(), A580DynamicTranslationPrimaryKey.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDynamicTranslationPrimaryKey_Jsonclick, 0, "Attribute", "", "", "", "", edtDynamicTranslationPrimaryKey_Visible, edtDynamicTranslationPrimaryKey_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_DynamicTranslation.htm");
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
         E111Q2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z578DynamicTranslationId = StringUtil.StrToGuid( cgiGet( "Z578DynamicTranslationId"));
               Z579DynamicTranslationTrnName = cgiGet( "Z579DynamicTranslationTrnName");
               Z580DynamicTranslationPrimaryKey = StringUtil.StrToGuid( cgiGet( "Z580DynamicTranslationPrimaryKey"));
               Z581DynamicTranslationAttributeNam = cgiGet( "Z581DynamicTranslationAttributeNam");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7DynamicTranslationId = StringUtil.StrToGuid( cgiGet( "vDYNAMICTRANSLATIONID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A579DynamicTranslationTrnName = cgiGet( edtDynamicTranslationTrnName_Internalname);
               AssignAttri("", false, "A579DynamicTranslationTrnName", A579DynamicTranslationTrnName);
               A581DynamicTranslationAttributeNam = cgiGet( edtDynamicTranslationAttributeNam_Internalname);
               AssignAttri("", false, "A581DynamicTranslationAttributeNam", A581DynamicTranslationAttributeNam);
               A582DynamicTranslationEnglish = cgiGet( edtDynamicTranslationEnglish_Internalname);
               AssignAttri("", false, "A582DynamicTranslationEnglish", A582DynamicTranslationEnglish);
               A583DynamicTranslationDutch = cgiGet( edtDynamicTranslationDutch_Internalname);
               AssignAttri("", false, "A583DynamicTranslationDutch", A583DynamicTranslationDutch);
               if ( StringUtil.StrCmp(cgiGet( edtDynamicTranslationId_Internalname), "") == 0 )
               {
                  A578DynamicTranslationId = Guid.Empty;
                  AssignAttri("", false, "A578DynamicTranslationId", A578DynamicTranslationId.ToString());
               }
               else
               {
                  try
                  {
                     A578DynamicTranslationId = StringUtil.StrToGuid( cgiGet( edtDynamicTranslationId_Internalname));
                     AssignAttri("", false, "A578DynamicTranslationId", A578DynamicTranslationId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "DYNAMICTRANSLATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtDynamicTranslationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               if ( StringUtil.StrCmp(cgiGet( edtDynamicTranslationPrimaryKey_Internalname), "") == 0 )
               {
                  A580DynamicTranslationPrimaryKey = Guid.Empty;
                  AssignAttri("", false, "A580DynamicTranslationPrimaryKey", A580DynamicTranslationPrimaryKey.ToString());
               }
               else
               {
                  try
                  {
                     A580DynamicTranslationPrimaryKey = StringUtil.StrToGuid( cgiGet( edtDynamicTranslationPrimaryKey_Internalname));
                     AssignAttri("", false, "A580DynamicTranslationPrimaryKey", A580DynamicTranslationPrimaryKey.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "DYNAMICTRANSLATIONPRIMARYKEY");
                     AnyError = 1;
                     GX_FocusControl = edtDynamicTranslationPrimaryKey_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_DynamicTranslation");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A578DynamicTranslationId != Z578DynamicTranslationId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_dynamictranslation:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A578DynamicTranslationId = StringUtil.StrToGuid( GetPar( "DynamicTranslationId"));
                  AssignAttri("", false, "A578DynamicTranslationId", A578DynamicTranslationId.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV7DynamicTranslationId) )
                  {
                     A578DynamicTranslationId = AV7DynamicTranslationId;
                     AssignAttri("", false, "A578DynamicTranslationId", A578DynamicTranslationId.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A578DynamicTranslationId) && ( Gx_BScreen == 0 ) )
                     {
                        A578DynamicTranslationId = Guid.NewGuid( );
                        AssignAttri("", false, "A578DynamicTranslationId", A578DynamicTranslationId.ToString());
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
                     sMode101 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV7DynamicTranslationId) )
                     {
                        A578DynamicTranslationId = AV7DynamicTranslationId;
                        AssignAttri("", false, "A578DynamicTranslationId", A578DynamicTranslationId.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A578DynamicTranslationId) && ( Gx_BScreen == 0 ) )
                        {
                           A578DynamicTranslationId = Guid.NewGuid( );
                           AssignAttri("", false, "A578DynamicTranslationId", A578DynamicTranslationId.ToString());
                        }
                     }
                     Gx_mode = sMode101;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound101 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1Q0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "DYNAMICTRANSLATIONID");
                        AnyError = 1;
                        GX_FocusControl = edtDynamicTranslationId_Internalname;
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
                           E111Q2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121Q2 ();
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
            E121Q2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1Q101( ) ;
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
            DisableAttributes1Q101( ) ;
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

      protected void CONFIRM_1Q0( )
      {
         BeforeValidate1Q101( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1Q101( ) ;
            }
            else
            {
               CheckExtendedTable1Q101( ) ;
               CloseExtendedTableCursors1Q101( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption1Q0( )
      {
      }

      protected void E111Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtDynamicTranslationId_Visible = 0;
         AssignProp("", false, edtDynamicTranslationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDynamicTranslationId_Visible), 5, 0), true);
         edtDynamicTranslationPrimaryKey_Visible = 0;
         AssignProp("", false, edtDynamicTranslationPrimaryKey_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDynamicTranslationPrimaryKey_Visible), 5, 0), true);
      }

      protected void E121Q2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("trn_dynamictranslationww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1Q101( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z579DynamicTranslationTrnName = T001Q3_A579DynamicTranslationTrnName[0];
               Z580DynamicTranslationPrimaryKey = T001Q3_A580DynamicTranslationPrimaryKey[0];
               Z581DynamicTranslationAttributeNam = T001Q3_A581DynamicTranslationAttributeNam[0];
            }
            else
            {
               Z579DynamicTranslationTrnName = A579DynamicTranslationTrnName;
               Z580DynamicTranslationPrimaryKey = A580DynamicTranslationPrimaryKey;
               Z581DynamicTranslationAttributeNam = A581DynamicTranslationAttributeNam;
            }
         }
         if ( GX_JID == -7 )
         {
            Z578DynamicTranslationId = A578DynamicTranslationId;
            Z579DynamicTranslationTrnName = A579DynamicTranslationTrnName;
            Z580DynamicTranslationPrimaryKey = A580DynamicTranslationPrimaryKey;
            Z581DynamicTranslationAttributeNam = A581DynamicTranslationAttributeNam;
            Z582DynamicTranslationEnglish = A582DynamicTranslationEnglish;
            Z583DynamicTranslationDutch = A583DynamicTranslationDutch;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV7DynamicTranslationId) )
         {
            edtDynamicTranslationId_Enabled = 0;
            AssignProp("", false, edtDynamicTranslationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDynamicTranslationId_Enabled), 5, 0), true);
         }
         else
         {
            edtDynamicTranslationId_Enabled = 1;
            AssignProp("", false, edtDynamicTranslationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDynamicTranslationId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7DynamicTranslationId) )
         {
            edtDynamicTranslationId_Enabled = 0;
            AssignProp("", false, edtDynamicTranslationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDynamicTranslationId_Enabled), 5, 0), true);
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
         if ( ! (Guid.Empty==AV7DynamicTranslationId) )
         {
            A578DynamicTranslationId = AV7DynamicTranslationId;
            AssignAttri("", false, "A578DynamicTranslationId", A578DynamicTranslationId.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A578DynamicTranslationId) && ( Gx_BScreen == 0 ) )
            {
               A578DynamicTranslationId = Guid.NewGuid( );
               AssignAttri("", false, "A578DynamicTranslationId", A578DynamicTranslationId.ToString());
            }
         }
         if ( IsIns( )  && (Guid.Empty==A580DynamicTranslationPrimaryKey) && ( Gx_BScreen == 0 ) )
         {
            A580DynamicTranslationPrimaryKey = Guid.NewGuid( );
            AssignAttri("", false, "A580DynamicTranslationPrimaryKey", A580DynamicTranslationPrimaryKey.ToString());
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1Q101( )
      {
         /* Using cursor T001Q4 */
         pr_default.execute(2, new Object[] {A578DynamicTranslationId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound101 = 1;
            A579DynamicTranslationTrnName = T001Q4_A579DynamicTranslationTrnName[0];
            AssignAttri("", false, "A579DynamicTranslationTrnName", A579DynamicTranslationTrnName);
            A580DynamicTranslationPrimaryKey = T001Q4_A580DynamicTranslationPrimaryKey[0];
            AssignAttri("", false, "A580DynamicTranslationPrimaryKey", A580DynamicTranslationPrimaryKey.ToString());
            A581DynamicTranslationAttributeNam = T001Q4_A581DynamicTranslationAttributeNam[0];
            AssignAttri("", false, "A581DynamicTranslationAttributeNam", A581DynamicTranslationAttributeNam);
            A582DynamicTranslationEnglish = T001Q4_A582DynamicTranslationEnglish[0];
            AssignAttri("", false, "A582DynamicTranslationEnglish", A582DynamicTranslationEnglish);
            A583DynamicTranslationDutch = T001Q4_A583DynamicTranslationDutch[0];
            AssignAttri("", false, "A583DynamicTranslationDutch", A583DynamicTranslationDutch);
            ZM1Q101( -7) ;
         }
         pr_default.close(2);
         OnLoadActions1Q101( ) ;
      }

      protected void OnLoadActions1Q101( )
      {
      }

      protected void CheckExtendedTable1Q101( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1Q101( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1Q101( )
      {
         /* Using cursor T001Q5 */
         pr_default.execute(3, new Object[] {A578DynamicTranslationId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound101 = 1;
         }
         else
         {
            RcdFound101 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001Q3 */
         pr_default.execute(1, new Object[] {A578DynamicTranslationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1Q101( 7) ;
            RcdFound101 = 1;
            A578DynamicTranslationId = T001Q3_A578DynamicTranslationId[0];
            AssignAttri("", false, "A578DynamicTranslationId", A578DynamicTranslationId.ToString());
            A579DynamicTranslationTrnName = T001Q3_A579DynamicTranslationTrnName[0];
            AssignAttri("", false, "A579DynamicTranslationTrnName", A579DynamicTranslationTrnName);
            A580DynamicTranslationPrimaryKey = T001Q3_A580DynamicTranslationPrimaryKey[0];
            AssignAttri("", false, "A580DynamicTranslationPrimaryKey", A580DynamicTranslationPrimaryKey.ToString());
            A581DynamicTranslationAttributeNam = T001Q3_A581DynamicTranslationAttributeNam[0];
            AssignAttri("", false, "A581DynamicTranslationAttributeNam", A581DynamicTranslationAttributeNam);
            A582DynamicTranslationEnglish = T001Q3_A582DynamicTranslationEnglish[0];
            AssignAttri("", false, "A582DynamicTranslationEnglish", A582DynamicTranslationEnglish);
            A583DynamicTranslationDutch = T001Q3_A583DynamicTranslationDutch[0];
            AssignAttri("", false, "A583DynamicTranslationDutch", A583DynamicTranslationDutch);
            Z578DynamicTranslationId = A578DynamicTranslationId;
            sMode101 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1Q101( ) ;
            if ( AnyError == 1 )
            {
               RcdFound101 = 0;
               InitializeNonKey1Q101( ) ;
            }
            Gx_mode = sMode101;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound101 = 0;
            InitializeNonKey1Q101( ) ;
            sMode101 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode101;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1Q101( ) ;
         if ( RcdFound101 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound101 = 0;
         /* Using cursor T001Q6 */
         pr_default.execute(4, new Object[] {A578DynamicTranslationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( GuidUtil.Compare(T001Q6_A578DynamicTranslationId[0], A578DynamicTranslationId, 0) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( GuidUtil.Compare(T001Q6_A578DynamicTranslationId[0], A578DynamicTranslationId, 0) > 0 ) ) )
            {
               A578DynamicTranslationId = T001Q6_A578DynamicTranslationId[0];
               AssignAttri("", false, "A578DynamicTranslationId", A578DynamicTranslationId.ToString());
               RcdFound101 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound101 = 0;
         /* Using cursor T001Q7 */
         pr_default.execute(5, new Object[] {A578DynamicTranslationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T001Q7_A578DynamicTranslationId[0], A578DynamicTranslationId, 0) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T001Q7_A578DynamicTranslationId[0], A578DynamicTranslationId, 0) < 0 ) ) )
            {
               A578DynamicTranslationId = T001Q7_A578DynamicTranslationId[0];
               AssignAttri("", false, "A578DynamicTranslationId", A578DynamicTranslationId.ToString());
               RcdFound101 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1Q101( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtDynamicTranslationTrnName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1Q101( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound101 == 1 )
            {
               if ( A578DynamicTranslationId != Z578DynamicTranslationId )
               {
                  A578DynamicTranslationId = Z578DynamicTranslationId;
                  AssignAttri("", false, "A578DynamicTranslationId", A578DynamicTranslationId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "DYNAMICTRANSLATIONID");
                  AnyError = 1;
                  GX_FocusControl = edtDynamicTranslationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtDynamicTranslationTrnName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1Q101( ) ;
                  GX_FocusControl = edtDynamicTranslationTrnName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A578DynamicTranslationId != Z578DynamicTranslationId )
               {
                  /* Insert record */
                  GX_FocusControl = edtDynamicTranslationTrnName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1Q101( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "DYNAMICTRANSLATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtDynamicTranslationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtDynamicTranslationTrnName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1Q101( ) ;
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
         if ( A578DynamicTranslationId != Z578DynamicTranslationId )
         {
            A578DynamicTranslationId = Z578DynamicTranslationId;
            AssignAttri("", false, "A578DynamicTranslationId", A578DynamicTranslationId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "DYNAMICTRANSLATIONID");
            AnyError = 1;
            GX_FocusControl = edtDynamicTranslationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtDynamicTranslationTrnName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1Q101( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001Q2 */
            pr_default.execute(0, new Object[] {A578DynamicTranslationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_DynamicTranslation"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z579DynamicTranslationTrnName, T001Q2_A579DynamicTranslationTrnName[0]) != 0 ) || ( Z580DynamicTranslationPrimaryKey != T001Q2_A580DynamicTranslationPrimaryKey[0] ) || ( StringUtil.StrCmp(Z581DynamicTranslationAttributeNam, T001Q2_A581DynamicTranslationAttributeNam[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z579DynamicTranslationTrnName, T001Q2_A579DynamicTranslationTrnName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_dynamictranslation:[seudo value changed for attri]"+"DynamicTranslationTrnName");
                  GXUtil.WriteLogRaw("Old: ",Z579DynamicTranslationTrnName);
                  GXUtil.WriteLogRaw("Current: ",T001Q2_A579DynamicTranslationTrnName[0]);
               }
               if ( Z580DynamicTranslationPrimaryKey != T001Q2_A580DynamicTranslationPrimaryKey[0] )
               {
                  GXUtil.WriteLog("trn_dynamictranslation:[seudo value changed for attri]"+"DynamicTranslationPrimaryKey");
                  GXUtil.WriteLogRaw("Old: ",Z580DynamicTranslationPrimaryKey);
                  GXUtil.WriteLogRaw("Current: ",T001Q2_A580DynamicTranslationPrimaryKey[0]);
               }
               if ( StringUtil.StrCmp(Z581DynamicTranslationAttributeNam, T001Q2_A581DynamicTranslationAttributeNam[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_dynamictranslation:[seudo value changed for attri]"+"DynamicTranslationAttributeNam");
                  GXUtil.WriteLogRaw("Old: ",Z581DynamicTranslationAttributeNam);
                  GXUtil.WriteLogRaw("Current: ",T001Q2_A581DynamicTranslationAttributeNam[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_DynamicTranslation"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1Q101( )
      {
         if ( ! IsAuthorized("trn_dynamictranslation_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1Q101( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Q101( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1Q101( 0) ;
            CheckOptimisticConcurrency1Q101( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Q101( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1Q101( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001Q8 */
                     pr_default.execute(6, new Object[] {A578DynamicTranslationId, A579DynamicTranslationTrnName, A580DynamicTranslationPrimaryKey, A581DynamicTranslationAttributeNam, A582DynamicTranslationEnglish, A583DynamicTranslationDutch});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_DynamicTranslation");
                     if ( (pr_default.getStatus(6) == 1) )
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
               Load1Q101( ) ;
            }
            EndLevel1Q101( ) ;
         }
         CloseExtendedTableCursors1Q101( ) ;
      }

      protected void Update1Q101( )
      {
         if ( ! IsAuthorized("trn_dynamictranslation_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1Q101( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Q101( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Q101( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Q101( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1Q101( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001Q9 */
                     pr_default.execute(7, new Object[] {A579DynamicTranslationTrnName, A580DynamicTranslationPrimaryKey, A581DynamicTranslationAttributeNam, A582DynamicTranslationEnglish, A583DynamicTranslationDutch, A578DynamicTranslationId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_DynamicTranslation");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_DynamicTranslation"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1Q101( ) ;
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
            EndLevel1Q101( ) ;
         }
         CloseExtendedTableCursors1Q101( ) ;
      }

      protected void DeferredUpdate1Q101( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_dynamictranslation_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1Q101( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Q101( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1Q101( ) ;
            AfterConfirm1Q101( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1Q101( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001Q10 */
                  pr_default.execute(8, new Object[] {A578DynamicTranslationId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_DynamicTranslation");
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
         sMode101 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1Q101( ) ;
         Gx_mode = sMode101;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1Q101( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1Q101( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1Q101( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_dynamictranslation",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1Q0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_dynamictranslation",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1Q101( )
      {
         /* Scan By routine */
         /* Using cursor T001Q11 */
         pr_default.execute(9);
         RcdFound101 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound101 = 1;
            A578DynamicTranslationId = T001Q11_A578DynamicTranslationId[0];
            AssignAttri("", false, "A578DynamicTranslationId", A578DynamicTranslationId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1Q101( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound101 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound101 = 1;
            A578DynamicTranslationId = T001Q11_A578DynamicTranslationId[0];
            AssignAttri("", false, "A578DynamicTranslationId", A578DynamicTranslationId.ToString());
         }
      }

      protected void ScanEnd1Q101( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm1Q101( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1Q101( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1Q101( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1Q101( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1Q101( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1Q101( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1Q101( )
      {
         edtDynamicTranslationTrnName_Enabled = 0;
         AssignProp("", false, edtDynamicTranslationTrnName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDynamicTranslationTrnName_Enabled), 5, 0), true);
         edtDynamicTranslationAttributeNam_Enabled = 0;
         AssignProp("", false, edtDynamicTranslationAttributeNam_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDynamicTranslationAttributeNam_Enabled), 5, 0), true);
         edtDynamicTranslationEnglish_Enabled = 0;
         AssignProp("", false, edtDynamicTranslationEnglish_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDynamicTranslationEnglish_Enabled), 5, 0), true);
         edtDynamicTranslationDutch_Enabled = 0;
         AssignProp("", false, edtDynamicTranslationDutch_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDynamicTranslationDutch_Enabled), 5, 0), true);
         edtDynamicTranslationId_Enabled = 0;
         AssignProp("", false, edtDynamicTranslationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDynamicTranslationId_Enabled), 5, 0), true);
         edtDynamicTranslationPrimaryKey_Enabled = 0;
         AssignProp("", false, edtDynamicTranslationPrimaryKey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDynamicTranslationPrimaryKey_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1Q101( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1Q0( )
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
         GXEncryptionTmp = "trn_dynamictranslation.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7DynamicTranslationId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_dynamictranslation.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_DynamicTranslation");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_dynamictranslation:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z578DynamicTranslationId", Z578DynamicTranslationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z579DynamicTranslationTrnName", Z579DynamicTranslationTrnName);
         GxWebStd.gx_hidden_field( context, "Z580DynamicTranslationPrimaryKey", Z580DynamicTranslationPrimaryKey.ToString());
         GxWebStd.gx_hidden_field( context, "Z581DynamicTranslationAttributeNam", Z581DynamicTranslationAttributeNam);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
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
         GxWebStd.gx_hidden_field( context, "vDYNAMICTRANSLATIONID", AV7DynamicTranslationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vDYNAMICTRANSLATIONID", GetSecureSignedToken( "", AV7DynamicTranslationId, context));
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
         GXEncryptionTmp = "trn_dynamictranslation.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7DynamicTranslationId.ToString());
         return formatLink("trn_dynamictranslation.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Trn_DynamicTranslation" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Dynamic Translation", "") ;
      }

      protected void InitializeNonKey1Q101( )
      {
         A579DynamicTranslationTrnName = "";
         AssignAttri("", false, "A579DynamicTranslationTrnName", A579DynamicTranslationTrnName);
         A581DynamicTranslationAttributeNam = "";
         AssignAttri("", false, "A581DynamicTranslationAttributeNam", A581DynamicTranslationAttributeNam);
         A582DynamicTranslationEnglish = "";
         AssignAttri("", false, "A582DynamicTranslationEnglish", A582DynamicTranslationEnglish);
         A583DynamicTranslationDutch = "";
         AssignAttri("", false, "A583DynamicTranslationDutch", A583DynamicTranslationDutch);
         A580DynamicTranslationPrimaryKey = Guid.NewGuid( );
         AssignAttri("", false, "A580DynamicTranslationPrimaryKey", A580DynamicTranslationPrimaryKey.ToString());
         Z579DynamicTranslationTrnName = "";
         Z580DynamicTranslationPrimaryKey = Guid.Empty;
         Z581DynamicTranslationAttributeNam = "";
      }

      protected void InitAll1Q101( )
      {
         A578DynamicTranslationId = Guid.NewGuid( );
         AssignAttri("", false, "A578DynamicTranslationId", A578DynamicTranslationId.ToString());
         InitializeNonKey1Q101( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A580DynamicTranslationPrimaryKey = i580DynamicTranslationPrimaryKey;
         AssignAttri("", false, "A580DynamicTranslationPrimaryKey", A580DynamicTranslationPrimaryKey.ToString());
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256309433257", true, true);
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
         context.AddJavascriptSource("trn_dynamictranslation.js", "?20256309433257", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtDynamicTranslationTrnName_Internalname = "DYNAMICTRANSLATIONTRNNAME";
         edtDynamicTranslationAttributeNam_Internalname = "DYNAMICTRANSLATIONATTRIBUTENAM";
         edtDynamicTranslationEnglish_Internalname = "DYNAMICTRANSLATIONENGLISH";
         edtDynamicTranslationDutch_Internalname = "DYNAMICTRANSLATIONDUTCH";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtDynamicTranslationId_Internalname = "DYNAMICTRANSLATIONID";
         edtDynamicTranslationPrimaryKey_Internalname = "DYNAMICTRANSLATIONPRIMARYKEY";
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
         Form.Caption = context.GetMessage( "Trn_Dynamic Translation", "");
         edtDynamicTranslationPrimaryKey_Jsonclick = "";
         edtDynamicTranslationPrimaryKey_Enabled = 1;
         edtDynamicTranslationPrimaryKey_Visible = 1;
         edtDynamicTranslationId_Jsonclick = "";
         edtDynamicTranslationId_Enabled = 1;
         edtDynamicTranslationId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtDynamicTranslationDutch_Enabled = 1;
         edtDynamicTranslationEnglish_Enabled = 1;
         edtDynamicTranslationAttributeNam_Jsonclick = "";
         edtDynamicTranslationAttributeNam_Enabled = 1;
         edtDynamicTranslationTrnName_Jsonclick = "";
         edtDynamicTranslationTrnName_Enabled = 1;
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

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7DynamicTranslationId","fld":"vDYNAMICTRANSLATIONID","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7DynamicTranslationId","fld":"vDYNAMICTRANSLATIONID","hsh":true}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E121Q2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_DYNAMICTRANSLATIONID","""{"handler":"Valid_Dynamictranslationid","iparms":[]}""");
         setEventMetadata("VALID_DYNAMICTRANSLATIONPRIMARYKEY","""{"handler":"Valid_Dynamictranslationprimarykey","iparms":[]}""");
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
         wcpOAV7DynamicTranslationId = Guid.Empty;
         Z578DynamicTranslationId = Guid.Empty;
         Z579DynamicTranslationTrnName = "";
         Z580DynamicTranslationPrimaryKey = Guid.Empty;
         Z581DynamicTranslationAttributeNam = "";
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
         A579DynamicTranslationTrnName = "";
         A581DynamicTranslationAttributeNam = "";
         A582DynamicTranslationEnglish = "";
         A583DynamicTranslationDutch = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A578DynamicTranslationId = Guid.Empty;
         A580DynamicTranslationPrimaryKey = Guid.Empty;
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode101 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z582DynamicTranslationEnglish = "";
         Z583DynamicTranslationDutch = "";
         T001Q4_A578DynamicTranslationId = new Guid[] {Guid.Empty} ;
         T001Q4_A579DynamicTranslationTrnName = new string[] {""} ;
         T001Q4_A580DynamicTranslationPrimaryKey = new Guid[] {Guid.Empty} ;
         T001Q4_A581DynamicTranslationAttributeNam = new string[] {""} ;
         T001Q4_A582DynamicTranslationEnglish = new string[] {""} ;
         T001Q4_A583DynamicTranslationDutch = new string[] {""} ;
         T001Q5_A578DynamicTranslationId = new Guid[] {Guid.Empty} ;
         T001Q3_A578DynamicTranslationId = new Guid[] {Guid.Empty} ;
         T001Q3_A579DynamicTranslationTrnName = new string[] {""} ;
         T001Q3_A580DynamicTranslationPrimaryKey = new Guid[] {Guid.Empty} ;
         T001Q3_A581DynamicTranslationAttributeNam = new string[] {""} ;
         T001Q3_A582DynamicTranslationEnglish = new string[] {""} ;
         T001Q3_A583DynamicTranslationDutch = new string[] {""} ;
         T001Q6_A578DynamicTranslationId = new Guid[] {Guid.Empty} ;
         T001Q7_A578DynamicTranslationId = new Guid[] {Guid.Empty} ;
         T001Q2_A578DynamicTranslationId = new Guid[] {Guid.Empty} ;
         T001Q2_A579DynamicTranslationTrnName = new string[] {""} ;
         T001Q2_A580DynamicTranslationPrimaryKey = new Guid[] {Guid.Empty} ;
         T001Q2_A581DynamicTranslationAttributeNam = new string[] {""} ;
         T001Q2_A582DynamicTranslationEnglish = new string[] {""} ;
         T001Q2_A583DynamicTranslationDutch = new string[] {""} ;
         T001Q11_A578DynamicTranslationId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i580DynamicTranslationPrimaryKey = Guid.Empty;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_dynamictranslation__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_dynamictranslation__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_dynamictranslation__default(),
            new Object[][] {
                new Object[] {
               T001Q2_A578DynamicTranslationId, T001Q2_A579DynamicTranslationTrnName, T001Q2_A580DynamicTranslationPrimaryKey, T001Q2_A581DynamicTranslationAttributeNam, T001Q2_A582DynamicTranslationEnglish, T001Q2_A583DynamicTranslationDutch
               }
               , new Object[] {
               T001Q3_A578DynamicTranslationId, T001Q3_A579DynamicTranslationTrnName, T001Q3_A580DynamicTranslationPrimaryKey, T001Q3_A581DynamicTranslationAttributeNam, T001Q3_A582DynamicTranslationEnglish, T001Q3_A583DynamicTranslationDutch
               }
               , new Object[] {
               T001Q4_A578DynamicTranslationId, T001Q4_A579DynamicTranslationTrnName, T001Q4_A580DynamicTranslationPrimaryKey, T001Q4_A581DynamicTranslationAttributeNam, T001Q4_A582DynamicTranslationEnglish, T001Q4_A583DynamicTranslationDutch
               }
               , new Object[] {
               T001Q5_A578DynamicTranslationId
               }
               , new Object[] {
               T001Q6_A578DynamicTranslationId
               }
               , new Object[] {
               T001Q7_A578DynamicTranslationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001Q11_A578DynamicTranslationId
               }
            }
         );
         Z580DynamicTranslationPrimaryKey = Guid.NewGuid( );
         A580DynamicTranslationPrimaryKey = Guid.NewGuid( );
         i580DynamicTranslationPrimaryKey = Guid.NewGuid( );
         Z578DynamicTranslationId = Guid.NewGuid( );
         A578DynamicTranslationId = Guid.NewGuid( );
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound101 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtDynamicTranslationTrnName_Enabled ;
      private int edtDynamicTranslationAttributeNam_Enabled ;
      private int edtDynamicTranslationEnglish_Enabled ;
      private int edtDynamicTranslationDutch_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtDynamicTranslationId_Visible ;
      private int edtDynamicTranslationId_Enabled ;
      private int edtDynamicTranslationPrimaryKey_Visible ;
      private int edtDynamicTranslationPrimaryKey_Enabled ;
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
      private string edtDynamicTranslationTrnName_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtDynamicTranslationTrnName_Jsonclick ;
      private string edtDynamicTranslationAttributeNam_Internalname ;
      private string edtDynamicTranslationAttributeNam_Jsonclick ;
      private string edtDynamicTranslationEnglish_Internalname ;
      private string edtDynamicTranslationDutch_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtDynamicTranslationId_Internalname ;
      private string edtDynamicTranslationId_Jsonclick ;
      private string edtDynamicTranslationPrimaryKey_Internalname ;
      private string edtDynamicTranslationPrimaryKey_Jsonclick ;
      private string hsh ;
      private string sMode101 ;
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
      private string A582DynamicTranslationEnglish ;
      private string A583DynamicTranslationDutch ;
      private string Z582DynamicTranslationEnglish ;
      private string Z583DynamicTranslationDutch ;
      private string Z579DynamicTranslationTrnName ;
      private string Z581DynamicTranslationAttributeNam ;
      private string A579DynamicTranslationTrnName ;
      private string A581DynamicTranslationAttributeNam ;
      private Guid wcpOAV7DynamicTranslationId ;
      private Guid Z578DynamicTranslationId ;
      private Guid Z580DynamicTranslationPrimaryKey ;
      private Guid AV7DynamicTranslationId ;
      private Guid A578DynamicTranslationId ;
      private Guid A580DynamicTranslationPrimaryKey ;
      private Guid i580DynamicTranslationPrimaryKey ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] T001Q4_A578DynamicTranslationId ;
      private string[] T001Q4_A579DynamicTranslationTrnName ;
      private Guid[] T001Q4_A580DynamicTranslationPrimaryKey ;
      private string[] T001Q4_A581DynamicTranslationAttributeNam ;
      private string[] T001Q4_A582DynamicTranslationEnglish ;
      private string[] T001Q4_A583DynamicTranslationDutch ;
      private Guid[] T001Q5_A578DynamicTranslationId ;
      private Guid[] T001Q3_A578DynamicTranslationId ;
      private string[] T001Q3_A579DynamicTranslationTrnName ;
      private Guid[] T001Q3_A580DynamicTranslationPrimaryKey ;
      private string[] T001Q3_A581DynamicTranslationAttributeNam ;
      private string[] T001Q3_A582DynamicTranslationEnglish ;
      private string[] T001Q3_A583DynamicTranslationDutch ;
      private Guid[] T001Q6_A578DynamicTranslationId ;
      private Guid[] T001Q7_A578DynamicTranslationId ;
      private Guid[] T001Q2_A578DynamicTranslationId ;
      private string[] T001Q2_A579DynamicTranslationTrnName ;
      private Guid[] T001Q2_A580DynamicTranslationPrimaryKey ;
      private string[] T001Q2_A581DynamicTranslationAttributeNam ;
      private string[] T001Q2_A582DynamicTranslationEnglish ;
      private string[] T001Q2_A583DynamicTranslationDutch ;
      private Guid[] T001Q11_A578DynamicTranslationId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_dynamictranslation__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_dynamictranslation__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_dynamictranslation__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[6])
      ,new UpdateCursor(def[7])
      ,new UpdateCursor(def[8])
      ,new ForEachCursor(def[9])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT001Q2;
       prmT001Q2 = new Object[] {
       new ParDef("DynamicTranslationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001Q3;
       prmT001Q3 = new Object[] {
       new ParDef("DynamicTranslationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001Q4;
       prmT001Q4 = new Object[] {
       new ParDef("DynamicTranslationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001Q5;
       prmT001Q5 = new Object[] {
       new ParDef("DynamicTranslationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001Q6;
       prmT001Q6 = new Object[] {
       new ParDef("DynamicTranslationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001Q7;
       prmT001Q7 = new Object[] {
       new ParDef("DynamicTranslationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001Q8;
       prmT001Q8 = new Object[] {
       new ParDef("DynamicTranslationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("DynamicTranslationTrnName",GXType.VarChar,100,0) ,
       new ParDef("DynamicTranslationPrimaryKey",GXType.UniqueIdentifier,36,0) ,
       new ParDef("DynamicTranslationAttributeNam",GXType.VarChar,100,0) ,
       new ParDef("DynamicTranslationEnglish",GXType.LongVarChar,2097152,0) ,
       new ParDef("DynamicTranslationDutch",GXType.LongVarChar,2097152,0)
       };
       Object[] prmT001Q9;
       prmT001Q9 = new Object[] {
       new ParDef("DynamicTranslationTrnName",GXType.VarChar,100,0) ,
       new ParDef("DynamicTranslationPrimaryKey",GXType.UniqueIdentifier,36,0) ,
       new ParDef("DynamicTranslationAttributeNam",GXType.VarChar,100,0) ,
       new ParDef("DynamicTranslationEnglish",GXType.LongVarChar,2097152,0) ,
       new ParDef("DynamicTranslationDutch",GXType.LongVarChar,2097152,0) ,
       new ParDef("DynamicTranslationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001Q10;
       prmT001Q10 = new Object[] {
       new ParDef("DynamicTranslationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001Q11;
       prmT001Q11 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T001Q2", "SELECT DynamicTranslationId, DynamicTranslationTrnName, DynamicTranslationPrimaryKey, DynamicTranslationAttributeNam, DynamicTranslationEnglish, DynamicTranslationDutch FROM Trn_DynamicTranslation WHERE DynamicTranslationId = :DynamicTranslationId  FOR UPDATE OF Trn_DynamicTranslation NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001Q3", "SELECT DynamicTranslationId, DynamicTranslationTrnName, DynamicTranslationPrimaryKey, DynamicTranslationAttributeNam, DynamicTranslationEnglish, DynamicTranslationDutch FROM Trn_DynamicTranslation WHERE DynamicTranslationId = :DynamicTranslationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001Q4", "SELECT TM1.DynamicTranslationId, TM1.DynamicTranslationTrnName, TM1.DynamicTranslationPrimaryKey, TM1.DynamicTranslationAttributeNam, TM1.DynamicTranslationEnglish, TM1.DynamicTranslationDutch FROM Trn_DynamicTranslation TM1 WHERE TM1.DynamicTranslationId = :DynamicTranslationId ORDER BY TM1.DynamicTranslationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001Q5", "SELECT DynamicTranslationId FROM Trn_DynamicTranslation WHERE DynamicTranslationId = :DynamicTranslationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001Q6", "SELECT DynamicTranslationId FROM Trn_DynamicTranslation WHERE ( DynamicTranslationId > :DynamicTranslationId) ORDER BY DynamicTranslationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q6,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001Q7", "SELECT DynamicTranslationId FROM Trn_DynamicTranslation WHERE ( DynamicTranslationId < :DynamicTranslationId) ORDER BY DynamicTranslationId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q7,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001Q8", "SAVEPOINT gxupdate;INSERT INTO Trn_DynamicTranslation(DynamicTranslationId, DynamicTranslationTrnName, DynamicTranslationPrimaryKey, DynamicTranslationAttributeNam, DynamicTranslationEnglish, DynamicTranslationDutch) VALUES(:DynamicTranslationId, :DynamicTranslationTrnName, :DynamicTranslationPrimaryKey, :DynamicTranslationAttributeNam, :DynamicTranslationEnglish, :DynamicTranslationDutch);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001Q8)
          ,new CursorDef("T001Q9", "SAVEPOINT gxupdate;UPDATE Trn_DynamicTranslation SET DynamicTranslationTrnName=:DynamicTranslationTrnName, DynamicTranslationPrimaryKey=:DynamicTranslationPrimaryKey, DynamicTranslationAttributeNam=:DynamicTranslationAttributeNam, DynamicTranslationEnglish=:DynamicTranslationEnglish, DynamicTranslationDutch=:DynamicTranslationDutch  WHERE DynamicTranslationId = :DynamicTranslationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001Q9)
          ,new CursorDef("T001Q10", "SAVEPOINT gxupdate;DELETE FROM Trn_DynamicTranslation  WHERE DynamicTranslationId = :DynamicTranslationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001Q10)
          ,new CursorDef("T001Q11", "SELECT DynamicTranslationId FROM Trn_DynamicTranslation ORDER BY DynamicTranslationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q11,100, GxCacheFrequency.OFF ,true,false )
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
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 9 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
