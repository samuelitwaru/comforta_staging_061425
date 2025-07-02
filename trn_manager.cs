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
   public class trn_manager : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action32") == 0 )
         {
            A25ManagerEmail = GetPar( "ManagerEmail");
            AssignAttri("", false, "A25ManagerEmail", A25ManagerEmail);
            A22ManagerGivenName = GetPar( "ManagerGivenName");
            AssignAttri("", false, "A22ManagerGivenName", A22ManagerGivenName);
            A23ManagerLastName = GetPar( "ManagerLastName");
            AssignAttri("", false, "A23ManagerLastName", A23ManagerLastName);
            A28ManagerGAMGUID = GetPar( "ManagerGAMGUID");
            AssignAttri("", false, "A28ManagerGAMGUID", A28ManagerGAMGUID);
            AV25GAMErrorResponse = GetPar( "GAMErrorResponse");
            AssignAttri("", false, "AV25GAMErrorResponse", AV25GAMErrorResponse);
            Gx_mode = GetPar( "Mode");
            AssignAttri("", false, "Gx_mode", Gx_mode);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_32_035( A25ManagerEmail, A22ManagerGivenName, A23ManagerLastName, A28ManagerGAMGUID, AV25GAMErrorResponse, Gx_mode) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action34") == 0 )
         {
            A22ManagerGivenName = GetPar( "ManagerGivenName");
            AssignAttri("", false, "A22ManagerGivenName", A22ManagerGivenName);
            A23ManagerLastName = GetPar( "ManagerLastName");
            AssignAttri("", false, "A23ManagerLastName", A23ManagerLastName);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_34_035( A22ManagerGivenName, A23ManagerLastName) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action36") == 0 )
         {
            Gx_mode = GetPar( "Mode");
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A28ManagerGAMGUID = GetPar( "ManagerGAMGUID");
            AssignAttri("", false, "A28ManagerGAMGUID", A28ManagerGAMGUID);
            A22ManagerGivenName = GetPar( "ManagerGivenName");
            AssignAttri("", false, "A22ManagerGivenName", A22ManagerGivenName);
            A23ManagerLastName = GetPar( "ManagerLastName");
            AssignAttri("", false, "A23ManagerLastName", A23ManagerLastName);
            A357ManagerPhoneCode = GetPar( "ManagerPhoneCode");
            AssignAttri("", false, "A357ManagerPhoneCode", A357ManagerPhoneCode);
            A358ManagerPhoneNumber = GetPar( "ManagerPhoneNumber");
            AssignAttri("", false, "A358ManagerPhoneNumber", A358ManagerPhoneNumber);
            A446ManagerImage = GetPar( "ManagerImage");
            AssignAttri("", false, "A446ManagerImage", A446ManagerImage);
            A365ManagerIsActive = StringUtil.StrToBool( GetPar( "ManagerIsActive"));
            AssignAttri("", false, "A365ManagerIsActive", A365ManagerIsActive);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_36_035( Gx_mode, A28ManagerGAMGUID, A22ManagerGivenName, A23ManagerLastName, A357ManagerPhoneCode, A358ManagerPhoneNumber, A446ManagerImage, A365ManagerIsActive) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action39") == 0 )
         {
            Gx_mode = GetPar( "Mode");
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A28ManagerGAMGUID = GetPar( "ManagerGAMGUID");
            AssignAttri("", false, "A28ManagerGAMGUID", A28ManagerGAMGUID);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_39_035( Gx_mode, A28ManagerGAMGUID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel9"+"_"+"") == 0 )
         {
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel18"+"_"+"MANAGERPHONE") == 0 )
         {
            A357ManagerPhoneCode = GetPar( "ManagerPhoneCode");
            AssignAttri("", false, "A357ManagerPhoneCode", A357ManagerPhoneCode);
            A358ManagerPhoneNumber = GetPar( "ManagerPhoneNumber");
            AssignAttri("", false, "A358ManagerPhoneNumber", A358ManagerPhoneNumber);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX18ASAMANAGERPHONE035( A357ManagerPhoneCode, A358ManagerPhoneNumber) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel19"+"_"+"vISGAMACTIVE") == 0 )
         {
            A28ManagerGAMGUID = GetPar( "ManagerGAMGUID");
            AssignAttri("", false, "A28ManagerGAMGUID", A28ManagerGAMGUID);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX19ASAISGAMACTIVE035( A28ManagerGAMGUID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_44") == 0 )
         {
            A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_44( A11OrganisationId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_manager.aspx")), "trn_manager.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_manager.aspx")))) ;
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
                  AV7ManagerId = StringUtil.StrToGuid( GetPar( "ManagerId"));
                  AssignAttri("", false, "AV7ManagerId", AV7ManagerId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vMANAGERID", GetSecureSignedToken( "", AV7ManagerId, context));
                  AV8OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  AssignAttri("", false, "AV8OrganisationId", AV8OrganisationId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV8OrganisationId, context));
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
         Form.Meta.addItem("description", context.GetMessage( "Managers", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtManagerGivenName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_manager( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_manager( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_ManagerId ,
                           Guid aP2_OrganisationId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ManagerId = aP1_ManagerId;
         this.AV8OrganisationId = aP2_OrganisationId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbManagerGender = new GXCombobox();
         chkManagerIsMainManager = new GXCheckbox();
         chkManagerIsActive = new GXCheckbox();
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
            return "trn_manager_Execute" ;
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
         if ( cmbManagerGender.ItemCount > 0 )
         {
            A27ManagerGender = cmbManagerGender.getValidValue(A27ManagerGender);
            AssignAttri("", false, "A27ManagerGender", A27ManagerGender);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbManagerGender.CurrentValue = StringUtil.RTrim( A27ManagerGender);
            AssignProp("", false, cmbManagerGender_Internalname, "Values", cmbManagerGender.ToJavascriptSource(), true);
         }
         A332ManagerIsMainManager = StringUtil.StrToBool( StringUtil.BoolToStr( A332ManagerIsMainManager));
         AssignAttri("", false, "A332ManagerIsMainManager", A332ManagerIsMainManager);
         A365ManagerIsActive = StringUtil.StrToBool( StringUtil.BoolToStr( A365ManagerIsActive));
         AssignAttri("", false, "A365ManagerIsActive", A365ManagerIsActive);
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
         /* Control Group */
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_Manager.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtManagerGivenName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtManagerGivenName_Internalname, context.GetMessage( "First Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtManagerGivenName_Internalname, A22ManagerGivenName, StringUtil.RTrim( context.localUtil.Format( A22ManagerGivenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtManagerGivenName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtManagerGivenName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_Manager.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtManagerLastName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtManagerLastName_Internalname, context.GetMessage( "Last Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtManagerLastName_Internalname, A23ManagerLastName, StringUtil.RTrim( context.localUtil.Format( A23ManagerLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtManagerLastName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtManagerLastName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_Manager.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbManagerGender_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbManagerGender_Internalname, context.GetMessage( "Gender", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbManagerGender, cmbManagerGender_Internalname, StringUtil.RTrim( A27ManagerGender), 1, cmbManagerGender_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbManagerGender.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "", true, 0, "HLP_Trn_Manager.htm");
         cmbManagerGender.CurrentValue = StringUtil.RTrim( A27ManagerGender);
         AssignProp("", false, cmbManagerGender_Internalname, "Values", (string)(cmbManagerGender.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtManagerEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtManagerEmail_Internalname, context.GetMessage( "Email", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtManagerEmail_Internalname, A25ManagerEmail, StringUtil.RTrim( context.localUtil.Format( A25ManagerEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A25ManagerEmail, "", "", "", edtManagerEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtManagerEmail_Enabled, 1, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Trn_Manager.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, divUnnamedtable2_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblPhone_Internalname, context.GetMessage( "Phone", ""), "", "", lblPhone_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_Trn_Manager.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable4_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 PhoneLabel ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablemanagerphonecode_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_managerphonecode.SetProperty("Caption", Combo_managerphonecode_Caption);
         ucCombo_managerphonecode.SetProperty("Cls", Combo_managerphonecode_Cls);
         ucCombo_managerphonecode.SetProperty("EmptyItem", Combo_managerphonecode_Emptyitem);
         ucCombo_managerphonecode.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
         ucCombo_managerphonecode.SetProperty("DropDownOptionsData", AV28ManagerPhoneCode_Data);
         ucCombo_managerphonecode.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_managerphonecode_Internalname, "COMBO_MANAGERPHONECODEContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtManagerPhoneCode_Internalname, context.GetMessage( "Manager Phone Code", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtManagerPhoneCode_Internalname, A357ManagerPhoneCode, StringUtil.RTrim( context.localUtil.Format( A357ManagerPhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtManagerPhoneCode_Jsonclick, 0, "Attribute", "", "", "", "", edtManagerPhoneCode_Visible, edtManagerPhoneCode_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Manager.htm");
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
         GxWebStd.gx_label_element( context, edtManagerPhoneNumber_Internalname, context.GetMessage( "Manager Phone Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtManagerPhoneNumber_Internalname, A358ManagerPhoneNumber, StringUtil.RTrim( context.localUtil.Format( A358ManagerPhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtManagerPhoneNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtManagerPhoneNumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Manager.htm");
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
         GxWebStd.gx_div_start( context, divManagerphone_cell_Internalname, 1, 0, "px", 0, "px", divManagerphone_cell_Class, "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", edtManagerPhone_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtManagerPhone_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtManagerPhone_Internalname, context.GetMessage( "Phone", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A26ManagerPhone);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtManagerPhone_Internalname, StringUtil.RTrim( A26ManagerPhone), StringUtil.RTrim( context.localUtil.Format( A26ManagerPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtManagerPhone_Jsonclick, 0, "Attribute", "", "", "", "", edtManagerPhone_Visible, edtManagerPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Trn_Manager.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkManagerIsMainManager_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkManagerIsMainManager_Internalname, context.GetMessage( "Is Main Manager?", ""), "col-sm-4 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkManagerIsMainManager_Internalname, StringUtil.BoolToStr( A332ManagerIsMainManager), "", context.GetMessage( "Is Main Manager?", ""), 1, chkManagerIsMainManager.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(70, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,70);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divManagerisactive_cell_Internalname, 1, 0, "px", 0, "px", divManagerisactive_cell_Class, "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", chkManagerIsActive.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkManagerIsActive_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkManagerIsActive_Internalname, context.GetMessage( "Is Active", ""), "col-sm-4 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkManagerIsActive_Internalname, StringUtil.BoolToStr( A365ManagerIsActive), "", context.GetMessage( "Is Active", ""), chkManagerIsActive.Visible, chkManagerIsActive.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(75, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,75);\"");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Manager.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Manager.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Manager.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_managerphonecode_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombomanagerphonecode_Internalname, AV26ComboManagerPhoneCode, StringUtil.RTrim( context.localUtil.Format( AV26ComboManagerPhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombomanagerphonecode_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombomanagerphonecode_Visible, edtavCombomanagerphonecode_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Manager.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtManagerId_Internalname, A21ManagerId.ToString(), A21ManagerId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtManagerId_Jsonclick, 0, "Attribute", "", "", "", "", edtManagerId_Visible, edtManagerId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Manager.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationId_Internalname, A11OrganisationId.ToString(), A11OrganisationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationId_Jsonclick, 0, "Attribute", "", "", "", "", edtOrganisationId_Visible, edtOrganisationId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Manager.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtManagerInitials_Internalname, StringUtil.RTrim( A24ManagerInitials), StringUtil.RTrim( context.localUtil.Format( A24ManagerInitials, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,92);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtManagerInitials_Jsonclick, 0, "Attribute", "", "", "", "", edtManagerInitials_Visible, edtManagerInitials_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Manager.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtManagerGAMGUID_Internalname, A28ManagerGAMGUID, StringUtil.RTrim( context.localUtil.Format( A28ManagerGAMGUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtManagerGAMGUID_Jsonclick, 0, "Attribute", "", "", "", "", edtManagerGAMGUID_Visible, edtManagerGAMGUID_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_Trn_Manager.htm");
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
         E11032 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV15DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vMANAGERPHONECODE_DATA"), AV28ManagerPhoneCode_Data);
               /* Read saved values. */
               Z21ManagerId = StringUtil.StrToGuid( cgiGet( "Z21ManagerId"));
               Z11OrganisationId = StringUtil.StrToGuid( cgiGet( "Z11OrganisationId"));
               Z357ManagerPhoneCode = cgiGet( "Z357ManagerPhoneCode");
               Z24ManagerInitials = cgiGet( "Z24ManagerInitials");
               Z26ManagerPhone = cgiGet( "Z26ManagerPhone");
               Z22ManagerGivenName = cgiGet( "Z22ManagerGivenName");
               Z23ManagerLastName = cgiGet( "Z23ManagerLastName");
               Z25ManagerEmail = cgiGet( "Z25ManagerEmail");
               Z358ManagerPhoneNumber = cgiGet( "Z358ManagerPhoneNumber");
               Z27ManagerGender = cgiGet( "Z27ManagerGender");
               Z28ManagerGAMGUID = cgiGet( "Z28ManagerGAMGUID");
               Z332ManagerIsMainManager = StringUtil.StrToBool( cgiGet( "Z332ManagerIsMainManager"));
               Z365ManagerIsActive = StringUtil.StrToBool( cgiGet( "Z365ManagerIsActive"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7ManagerId = StringUtil.StrToGuid( cgiGet( "vMANAGERID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV8OrganisationId = StringUtil.StrToGuid( cgiGet( "vORGANISATIONID"));
               AV25GAMErrorResponse = cgiGet( "vGAMERRORRESPONSE");
               AV32IsGAMActive = StringUtil.StrToBool( cgiGet( "vISGAMACTIVE"));
               ajax_req_read_hidden_sdt(cgiGet( "vAUDITINGOBJECT"), AV30AuditingObject);
               Gx_mode = cgiGet( "vMODE");
               A446ManagerImage = cgiGet( "MANAGERIMAGE");
               A40000ManagerImage_GXI = cgiGet( "MANAGERIMAGE_GXI");
               AV35Pgmname = cgiGet( "vPGMNAME");
               Combo_managerphonecode_Objectcall = cgiGet( "COMBO_MANAGERPHONECODE_Objectcall");
               Combo_managerphonecode_Class = cgiGet( "COMBO_MANAGERPHONECODE_Class");
               Combo_managerphonecode_Icontype = cgiGet( "COMBO_MANAGERPHONECODE_Icontype");
               Combo_managerphonecode_Icon = cgiGet( "COMBO_MANAGERPHONECODE_Icon");
               Combo_managerphonecode_Caption = cgiGet( "COMBO_MANAGERPHONECODE_Caption");
               Combo_managerphonecode_Tooltip = cgiGet( "COMBO_MANAGERPHONECODE_Tooltip");
               Combo_managerphonecode_Cls = cgiGet( "COMBO_MANAGERPHONECODE_Cls");
               Combo_managerphonecode_Selectedvalue_set = cgiGet( "COMBO_MANAGERPHONECODE_Selectedvalue_set");
               Combo_managerphonecode_Selectedvalue_get = cgiGet( "COMBO_MANAGERPHONECODE_Selectedvalue_get");
               Combo_managerphonecode_Selectedtext_set = cgiGet( "COMBO_MANAGERPHONECODE_Selectedtext_set");
               Combo_managerphonecode_Selectedtext_get = cgiGet( "COMBO_MANAGERPHONECODE_Selectedtext_get");
               Combo_managerphonecode_Gamoauthtoken = cgiGet( "COMBO_MANAGERPHONECODE_Gamoauthtoken");
               Combo_managerphonecode_Ddointernalname = cgiGet( "COMBO_MANAGERPHONECODE_Ddointernalname");
               Combo_managerphonecode_Titlecontrolalign = cgiGet( "COMBO_MANAGERPHONECODE_Titlecontrolalign");
               Combo_managerphonecode_Dropdownoptionstype = cgiGet( "COMBO_MANAGERPHONECODE_Dropdownoptionstype");
               Combo_managerphonecode_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_MANAGERPHONECODE_Enabled"));
               Combo_managerphonecode_Visible = StringUtil.StrToBool( cgiGet( "COMBO_MANAGERPHONECODE_Visible"));
               Combo_managerphonecode_Titlecontrolidtoreplace = cgiGet( "COMBO_MANAGERPHONECODE_Titlecontrolidtoreplace");
               Combo_managerphonecode_Datalisttype = cgiGet( "COMBO_MANAGERPHONECODE_Datalisttype");
               Combo_managerphonecode_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_MANAGERPHONECODE_Allowmultipleselection"));
               Combo_managerphonecode_Datalistfixedvalues = cgiGet( "COMBO_MANAGERPHONECODE_Datalistfixedvalues");
               Combo_managerphonecode_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_MANAGERPHONECODE_Isgriditem"));
               Combo_managerphonecode_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_MANAGERPHONECODE_Hasdescription"));
               Combo_managerphonecode_Datalistproc = cgiGet( "COMBO_MANAGERPHONECODE_Datalistproc");
               Combo_managerphonecode_Datalistprocparametersprefix = cgiGet( "COMBO_MANAGERPHONECODE_Datalistprocparametersprefix");
               Combo_managerphonecode_Remoteservicesparameters = cgiGet( "COMBO_MANAGERPHONECODE_Remoteservicesparameters");
               Combo_managerphonecode_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_MANAGERPHONECODE_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_managerphonecode_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_MANAGERPHONECODE_Includeonlyselectedoption"));
               Combo_managerphonecode_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_MANAGERPHONECODE_Includeselectalloption"));
               Combo_managerphonecode_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_MANAGERPHONECODE_Emptyitem"));
               Combo_managerphonecode_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_MANAGERPHONECODE_Includeaddnewoption"));
               Combo_managerphonecode_Htmltemplate = cgiGet( "COMBO_MANAGERPHONECODE_Htmltemplate");
               Combo_managerphonecode_Multiplevaluestype = cgiGet( "COMBO_MANAGERPHONECODE_Multiplevaluestype");
               Combo_managerphonecode_Loadingdata = cgiGet( "COMBO_MANAGERPHONECODE_Loadingdata");
               Combo_managerphonecode_Noresultsfound = cgiGet( "COMBO_MANAGERPHONECODE_Noresultsfound");
               Combo_managerphonecode_Emptyitemtext = cgiGet( "COMBO_MANAGERPHONECODE_Emptyitemtext");
               Combo_managerphonecode_Onlyselectedvalues = cgiGet( "COMBO_MANAGERPHONECODE_Onlyselectedvalues");
               Combo_managerphonecode_Selectalltext = cgiGet( "COMBO_MANAGERPHONECODE_Selectalltext");
               Combo_managerphonecode_Multiplevaluesseparator = cgiGet( "COMBO_MANAGERPHONECODE_Multiplevaluesseparator");
               Combo_managerphonecode_Addnewoptiontext = cgiGet( "COMBO_MANAGERPHONECODE_Addnewoptiontext");
               Combo_managerphonecode_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_MANAGERPHONECODE_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A22ManagerGivenName = cgiGet( edtManagerGivenName_Internalname);
               AssignAttri("", false, "A22ManagerGivenName", A22ManagerGivenName);
               A23ManagerLastName = cgiGet( edtManagerLastName_Internalname);
               AssignAttri("", false, "A23ManagerLastName", A23ManagerLastName);
               cmbManagerGender.CurrentValue = cgiGet( cmbManagerGender_Internalname);
               A27ManagerGender = cgiGet( cmbManagerGender_Internalname);
               AssignAttri("", false, "A27ManagerGender", A27ManagerGender);
               A25ManagerEmail = cgiGet( edtManagerEmail_Internalname);
               AssignAttri("", false, "A25ManagerEmail", A25ManagerEmail);
               A357ManagerPhoneCode = cgiGet( edtManagerPhoneCode_Internalname);
               AssignAttri("", false, "A357ManagerPhoneCode", A357ManagerPhoneCode);
               A358ManagerPhoneNumber = cgiGet( edtManagerPhoneNumber_Internalname);
               AssignAttri("", false, "A358ManagerPhoneNumber", A358ManagerPhoneNumber);
               A26ManagerPhone = cgiGet( edtManagerPhone_Internalname);
               AssignAttri("", false, "A26ManagerPhone", A26ManagerPhone);
               A332ManagerIsMainManager = StringUtil.StrToBool( cgiGet( chkManagerIsMainManager_Internalname));
               AssignAttri("", false, "A332ManagerIsMainManager", A332ManagerIsMainManager);
               A365ManagerIsActive = StringUtil.StrToBool( cgiGet( chkManagerIsActive_Internalname));
               AssignAttri("", false, "A365ManagerIsActive", A365ManagerIsActive);
               AV26ComboManagerPhoneCode = cgiGet( edtavCombomanagerphonecode_Internalname);
               AssignAttri("", false, "AV26ComboManagerPhoneCode", AV26ComboManagerPhoneCode);
               if ( StringUtil.StrCmp(cgiGet( edtManagerId_Internalname), "") == 0 )
               {
                  A21ManagerId = Guid.Empty;
                  AssignAttri("", false, "A21ManagerId", A21ManagerId.ToString());
               }
               else
               {
                  try
                  {
                     A21ManagerId = StringUtil.StrToGuid( cgiGet( edtManagerId_Internalname));
                     AssignAttri("", false, "A21ManagerId", A21ManagerId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "MANAGERID");
                     AnyError = 1;
                     GX_FocusControl = edtManagerId_Internalname;
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
               A24ManagerInitials = cgiGet( edtManagerInitials_Internalname);
               AssignAttri("", false, "A24ManagerInitials", A24ManagerInitials);
               A28ManagerGAMGUID = cgiGet( edtManagerGAMGUID_Internalname);
               AssignAttri("", false, "A28ManagerGAMGUID", A28ManagerGAMGUID);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Manager");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV35Pgmname, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A21ManagerId != Z21ManagerId ) || ( A11OrganisationId != Z11OrganisationId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_manager:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A21ManagerId = StringUtil.StrToGuid( GetPar( "ManagerId"));
                  AssignAttri("", false, "A21ManagerId", A21ManagerId.ToString());
                  A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV7ManagerId) )
                  {
                     A21ManagerId = AV7ManagerId;
                     AssignAttri("", false, "A21ManagerId", A21ManagerId.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A21ManagerId) && ( Gx_BScreen == 0 ) )
                     {
                        A21ManagerId = Guid.NewGuid( );
                        AssignAttri("", false, "A21ManagerId", A21ManagerId.ToString());
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
                     sMode5 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV7ManagerId) )
                     {
                        A21ManagerId = AV7ManagerId;
                        AssignAttri("", false, "A21ManagerId", A21ManagerId.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A21ManagerId) && ( Gx_BScreen == 0 ) )
                        {
                           A21ManagerId = Guid.NewGuid( );
                           AssignAttri("", false, "A21ManagerId", A21ManagerId.ToString());
                        }
                     }
                     Gx_mode = sMode5;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound5 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_030( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "MANAGERID");
                        AnyError = 1;
                        GX_FocusControl = edtManagerId_Internalname;
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
                           E11032 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12032 ();
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
            E12032 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll035( ) ;
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
            DisableAttributes035( ) ;
         }
         AssignProp("", false, edtavCombomanagerphonecode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombomanagerphonecode_Enabled), 5, 0), true);
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

      protected void CONFIRM_030( )
      {
         BeforeValidate035( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls035( ) ;
            }
            else
            {
               CheckExtendedTable035( ) ;
               CloseExtendedTableCursors035( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption030( )
      {
      }

      protected void E11032( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV15DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV15DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtManagerPhoneCode_Visible = 0;
         AssignProp("", false, edtManagerPhoneCode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtManagerPhoneCode_Visible), 5, 0), true);
         AV26ComboManagerPhoneCode = "";
         AssignAttri("", false, "AV26ComboManagerPhoneCode", AV26ComboManagerPhoneCode);
         edtavCombomanagerphonecode_Visible = 0;
         AssignProp("", false, edtavCombomanagerphonecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombomanagerphonecode_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_managerphonecode_Htmltemplate = GXt_char2;
         ucCombo_managerphonecode.SendProperty(context, "", false, Combo_managerphonecode_Internalname, "HTMLTemplate", Combo_managerphonecode_Htmltemplate);
         /* Execute user subroutine: 'LOADCOMBOMANAGERPHONECODE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
         edtManagerId_Visible = 0;
         AssignProp("", false, edtManagerId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtManagerId_Visible), 5, 0), true);
         edtOrganisationId_Visible = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Visible), 5, 0), true);
         edtManagerInitials_Visible = 0;
         AssignProp("", false, edtManagerInitials_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtManagerInitials_Visible), 5, 0), true);
         edtManagerGAMGUID_Visible = 0;
         AssignProp("", false, edtManagerGAMGUID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtManagerGAMGUID_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV27defaultCountryPhoneCode = "+31";
            AssignAttri("", false, "AV27defaultCountryPhoneCode", AV27defaultCountryPhoneCode);
            Combo_managerphonecode_Selectedtext_set = AV27defaultCountryPhoneCode;
            ucCombo_managerphonecode.SendProperty(context, "", false, Combo_managerphonecode_Internalname, "SelectedText_set", Combo_managerphonecode_Selectedtext_set);
            Combo_managerphonecode_Selectedvalue_set = AV27defaultCountryPhoneCode;
            ucCombo_managerphonecode.SendProperty(context, "", false, Combo_managerphonecode_Internalname, "SelectedValue_set", Combo_managerphonecode_Selectedvalue_set);
            AV26ComboManagerPhoneCode = AV27defaultCountryPhoneCode;
            AssignAttri("", false, "AV26ComboManagerPhoneCode", AV26ComboManagerPhoneCode);
         }
      }

      protected void E12032( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV13WebSession.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "Manager Updated successfully", ""));
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV13WebSession.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "Manager Deleted successfully", ""));
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV13WebSession.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "Manager Inserted successfully", ""));
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
         {
            new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV30AuditingObject,  AV35Pgmname) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV12TrnContext.gxTpr_Callerondelete )
            {
               CallWebObject(formatLink("trn_managerww.aspx") );
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

      protected void S122( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         edtManagerPhone_Visible = 0;
         AssignProp("", false, edtManagerPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtManagerPhone_Visible), 5, 0), true);
         divManagerphone_cell_Class = "Invisible";
         AssignProp("", false, divManagerphone_cell_Internalname, "Class", divManagerphone_cell_Class, true);
         chkManagerIsActive.Visible = 0;
         AssignProp("", false, chkManagerIsActive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkManagerIsActive.Visible), 5, 0), true);
         divManagerisactive_cell_Class = "Invisible";
         AssignProp("", false, divManagerisactive_cell_Internalname, "Class", divManagerisactive_cell_Class, true);
      }

      protected void S112( )
      {
         /* 'LOADCOMBOMANAGERPHONECODE' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item3 = AV28ManagerPhoneCode_Data;
         new trn_managerloaddvcombo(context ).execute(  "ManagerPhoneCode",  Gx_mode,  AV7ManagerId,  AV8OrganisationId, out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_objcol_SdtDVB_SDTComboData_Item3) ;
         AV28ManagerPhoneCode_Data = GXt_objcol_SdtDVB_SDTComboData_Item3;
         Combo_managerphonecode_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_managerphonecode.SendProperty(context, "", false, Combo_managerphonecode_Internalname, "SelectedValue_set", Combo_managerphonecode_Selectedvalue_set);
         AV26ComboManagerPhoneCode = AV16ComboSelectedValue;
         AssignAttri("", false, "AV26ComboManagerPhoneCode", AV26ComboManagerPhoneCode);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_managerphonecode_Enabled = false;
            ucCombo_managerphonecode.SendProperty(context, "", false, Combo_managerphonecode_Internalname, "Enabled", StringUtil.BoolToStr( Combo_managerphonecode_Enabled));
         }
      }

      protected void ZM035( short GX_JID )
      {
         if ( ( GX_JID == 43 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z357ManagerPhoneCode = T00033_A357ManagerPhoneCode[0];
               Z24ManagerInitials = T00033_A24ManagerInitials[0];
               Z26ManagerPhone = T00033_A26ManagerPhone[0];
               Z22ManagerGivenName = T00033_A22ManagerGivenName[0];
               Z23ManagerLastName = T00033_A23ManagerLastName[0];
               Z25ManagerEmail = T00033_A25ManagerEmail[0];
               Z358ManagerPhoneNumber = T00033_A358ManagerPhoneNumber[0];
               Z27ManagerGender = T00033_A27ManagerGender[0];
               Z28ManagerGAMGUID = T00033_A28ManagerGAMGUID[0];
               Z332ManagerIsMainManager = T00033_A332ManagerIsMainManager[0];
               Z365ManagerIsActive = T00033_A365ManagerIsActive[0];
            }
            else
            {
               Z357ManagerPhoneCode = A357ManagerPhoneCode;
               Z24ManagerInitials = A24ManagerInitials;
               Z26ManagerPhone = A26ManagerPhone;
               Z22ManagerGivenName = A22ManagerGivenName;
               Z23ManagerLastName = A23ManagerLastName;
               Z25ManagerEmail = A25ManagerEmail;
               Z358ManagerPhoneNumber = A358ManagerPhoneNumber;
               Z27ManagerGender = A27ManagerGender;
               Z28ManagerGAMGUID = A28ManagerGAMGUID;
               Z332ManagerIsMainManager = A332ManagerIsMainManager;
               Z365ManagerIsActive = A365ManagerIsActive;
            }
         }
         if ( GX_JID == -43 )
         {
            Z21ManagerId = A21ManagerId;
            Z357ManagerPhoneCode = A357ManagerPhoneCode;
            Z24ManagerInitials = A24ManagerInitials;
            Z26ManagerPhone = A26ManagerPhone;
            Z22ManagerGivenName = A22ManagerGivenName;
            Z23ManagerLastName = A23ManagerLastName;
            Z25ManagerEmail = A25ManagerEmail;
            Z358ManagerPhoneNumber = A358ManagerPhoneNumber;
            Z27ManagerGender = A27ManagerGender;
            Z28ManagerGAMGUID = A28ManagerGAMGUID;
            Z332ManagerIsMainManager = A332ManagerIsMainManager;
            Z365ManagerIsActive = A365ManagerIsActive;
            Z446ManagerImage = A446ManagerImage;
            Z40000ManagerImage_GXI = A40000ManagerImage_GXI;
            Z11OrganisationId = A11OrganisationId;
         }
      }

      protected void standaloneNotModal( )
      {
         edtManagerPhone_Visible = ((StringUtil.StrCmp(Gx_mode, "DSP")==0)||(StringUtil.StrCmp(Gx_mode, "DLT")==0) ? 1 : 0);
         AssignProp("", false, edtManagerPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtManagerPhone_Visible), 5, 0), true);
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) ) )
         {
            divManagerphone_cell_Class = context.GetMessage( "Invisible", "");
            AssignProp("", false, divManagerphone_cell_Internalname, "Class", divManagerphone_cell_Class, true);
         }
         else
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               divManagerphone_cell_Class = context.GetMessage( "col-xs-12 col-sm-6 DataContentCell", "");
               AssignProp("", false, divManagerphone_cell_Internalname, "Class", divManagerphone_cell_Class, true);
            }
         }
         divUnnamedtable2_Visible = (((StringUtil.StrCmp(Gx_mode, "INS")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0)) ? 1 : 0);
         AssignProp("", false, divUnnamedtable2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUnnamedtable2_Visible), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV35Pgmname = "Trn_Manager";
         AssignAttri("", false, "AV35Pgmname", AV35Pgmname);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV7ManagerId) )
         {
            edtManagerId_Enabled = 0;
            AssignProp("", false, edtManagerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtManagerId_Enabled), 5, 0), true);
         }
         else
         {
            edtManagerId_Enabled = 1;
            AssignProp("", false, edtManagerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtManagerId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7ManagerId) )
         {
            edtManagerId_Enabled = 0;
            AssignProp("", false, edtManagerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtManagerId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV8OrganisationId) )
         {
            A11OrganisationId = AV8OrganisationId;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         if ( ! (Guid.Empty==AV8OrganisationId) )
         {
            edtOrganisationId_Enabled = 0;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
         else
         {
            edtOrganisationId_Enabled = 1;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV8OrganisationId) )
         {
            edtOrganisationId_Enabled = 0;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( IsUpd( )  )
         {
            edtManagerEmail_Enabled = 0;
            AssignProp("", false, edtManagerEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtManagerEmail_Enabled), 5, 0), true);
         }
         else
         {
            edtManagerEmail_Enabled = 1;
            AssignProp("", false, edtManagerEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtManagerEmail_Enabled), 5, 0), true);
         }
         if ( IsUpd( )  )
         {
            edtManagerEmail_Enabled = 0;
            AssignProp("", false, edtManagerEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtManagerEmail_Enabled), 5, 0), true);
         }
         A357ManagerPhoneCode = AV26ComboManagerPhoneCode;
         AssignAttri("", false, "A357ManagerPhoneCode", A357ManagerPhoneCode);
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
         if ( ! (Guid.Empty==AV7ManagerId) )
         {
            A21ManagerId = AV7ManagerId;
            AssignAttri("", false, "A21ManagerId", A21ManagerId.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A21ManagerId) && ( Gx_BScreen == 0 ) )
            {
               A21ManagerId = Guid.NewGuid( );
               AssignAttri("", false, "A21ManagerId", A21ManagerId.ToString());
            }
         }
         if ( IsIns( )  && (false==A332ManagerIsMainManager) && ( Gx_BScreen == 0 ) )
         {
            A332ManagerIsMainManager = false;
            AssignAttri("", false, "A332ManagerIsMainManager", A332ManagerIsMainManager);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load035( )
      {
         /* Using cursor T00035 */
         pr_default.execute(3, new Object[] {A21ManagerId, A11OrganisationId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound5 = 1;
            A357ManagerPhoneCode = T00035_A357ManagerPhoneCode[0];
            AssignAttri("", false, "A357ManagerPhoneCode", A357ManagerPhoneCode);
            A24ManagerInitials = T00035_A24ManagerInitials[0];
            AssignAttri("", false, "A24ManagerInitials", A24ManagerInitials);
            A26ManagerPhone = T00035_A26ManagerPhone[0];
            AssignAttri("", false, "A26ManagerPhone", A26ManagerPhone);
            A22ManagerGivenName = T00035_A22ManagerGivenName[0];
            AssignAttri("", false, "A22ManagerGivenName", A22ManagerGivenName);
            A23ManagerLastName = T00035_A23ManagerLastName[0];
            AssignAttri("", false, "A23ManagerLastName", A23ManagerLastName);
            A25ManagerEmail = T00035_A25ManagerEmail[0];
            AssignAttri("", false, "A25ManagerEmail", A25ManagerEmail);
            A358ManagerPhoneNumber = T00035_A358ManagerPhoneNumber[0];
            AssignAttri("", false, "A358ManagerPhoneNumber", A358ManagerPhoneNumber);
            A27ManagerGender = T00035_A27ManagerGender[0];
            AssignAttri("", false, "A27ManagerGender", A27ManagerGender);
            A28ManagerGAMGUID = T00035_A28ManagerGAMGUID[0];
            AssignAttri("", false, "A28ManagerGAMGUID", A28ManagerGAMGUID);
            A332ManagerIsMainManager = T00035_A332ManagerIsMainManager[0];
            AssignAttri("", false, "A332ManagerIsMainManager", A332ManagerIsMainManager);
            A365ManagerIsActive = T00035_A365ManagerIsActive[0];
            AssignAttri("", false, "A365ManagerIsActive", A365ManagerIsActive);
            A40000ManagerImage_GXI = T00035_A40000ManagerImage_GXI[0];
            A446ManagerImage = T00035_A446ManagerImage[0];
            ZM035( -43) ;
         }
         pr_default.close(3);
         OnLoadActions035( ) ;
      }

      protected void OnLoadActions035( )
      {
         GXt_char2 = A26ManagerPhone;
         new prc_concatenateintlphone(context ).execute(  A357ManagerPhoneCode,  A358ManagerPhoneNumber, out  GXt_char2) ;
         A26ManagerPhone = GXt_char2;
         AssignAttri("", false, "A26ManagerPhone", A26ManagerPhone);
         GXt_char2 = "";
         new prc_getloggedinuserid(context ).execute( out  GXt_char2) ;
         if ( StringUtil.StrCmp(A28ManagerGAMGUID, GXt_char2) != 0 )
         {
            bttBtntrn_delete_Visible = 1;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         }
         else
         {
            GXt_char2 = "";
            new prc_getloggedinuserid(context ).execute( out  GXt_char2) ;
            if ( ! ( ( StringUtil.StrCmp(A28ManagerGAMGUID, GXt_char2) != 0 ) ) )
            {
               bttBtntrn_delete_Visible = 0;
               AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            }
         }
         GXt_boolean4 = AV32IsGAMActive;
         new prc_checkgamuseractivationstatus(context ).execute(  A28ManagerGAMGUID, out  GXt_boolean4) ;
         AV32IsGAMActive = GXt_boolean4;
         AssignAttri("", false, "AV32IsGAMActive", AV32IsGAMActive);
         chkManagerIsActive.Visible = ((AV32IsGAMActive) ? 1 : 0);
         AssignProp("", false, chkManagerIsActive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkManagerIsActive.Visible), 5, 0), true);
         if ( ! ( ( AV32IsGAMActive ) ) )
         {
            divManagerisactive_cell_Class = context.GetMessage( "Invisible", "");
            AssignProp("", false, divManagerisactive_cell_Internalname, "Class", divManagerisactive_cell_Class, true);
         }
         else
         {
            if ( AV32IsGAMActive )
            {
               divManagerisactive_cell_Class = context.GetMessage( "col-xs-12 col-sm-6 DataContentCell", "");
               AssignProp("", false, divManagerisactive_cell_Internalname, "Class", divManagerisactive_cell_Class, true);
            }
         }
      }

      protected void CheckExtendedTable035( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T00034 */
         pr_default.execute(2, new Object[] {A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Organisations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtOrganisationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( ! ( new prc_mainmanagerscount(context).executeUdp(  A11OrganisationId) > 0 ) && ( ( ! A332ManagerIsMainManager && IsUpd( )  ) || IsDlt( )  ) )
         {
            GX_msglist.addItem(context.GetMessage( "Organisation must have atleast one main Manager", ""), 1, "MANAGERISMAINMANAGER");
            AnyError = 1;
            GX_FocusControl = chkManagerIsMainManager_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A22ManagerGivenName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Manager Given Name", ""), "", "", "", "", "", "", "", ""), 1, "MANAGERGIVENNAME");
            AnyError = 1;
            GX_FocusControl = edtManagerGivenName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         new prc_getnameinitials(context ).execute(  A22ManagerGivenName,  A23ManagerLastName, out  A24ManagerInitials) ;
         AssignAttri("", false, "A24ManagerInitials", A24ManagerInitials);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A23ManagerLastName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Manager Last Name", ""), "", "", "", "", "", "", "", ""), 1, "MANAGERLASTNAME");
            AnyError = 1;
            GX_FocusControl = edtManagerLastName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A25ManagerEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "Invalid email pattern", ""), context.GetMessage( "Manager Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "MANAGEREMAIL");
            AnyError = 1;
            GX_FocusControl = edtManagerEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A25ManagerEmail)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Manager Email", ""), "", "", "", "", "", "", "", ""), 1, "MANAGEREMAIL");
            AnyError = 1;
            GX_FocusControl = edtManagerEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GXt_char2 = A26ManagerPhone;
         new prc_concatenateintlphone(context ).execute(  A357ManagerPhoneCode,  A358ManagerPhoneNumber, out  GXt_char2) ;
         A26ManagerPhone = GXt_char2;
         AssignAttri("", false, "A26ManagerPhone", A26ManagerPhone);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A358ManagerPhoneNumber)) && ! GxRegex.IsMatch(A358ManagerPhoneNumber,context.GetMessage( "^\\d{9}$", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Phone contains 9 digits", ""), 1, "MANAGERPHONENUMBER");
            AnyError = 1;
            GX_FocusControl = edtManagerPhoneNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A27ManagerGender, "Male") == 0 ) || ( StringUtil.StrCmp(A27ManagerGender, "Female") == 0 ) || ( StringUtil.StrCmp(A27ManagerGender, "Other") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Manager Gender", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "MANAGERGENDER");
            AnyError = 1;
            GX_FocusControl = cmbManagerGender_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GXt_char2 = "";
         new prc_getloggedinuserid(context ).execute( out  GXt_char2) ;
         if ( StringUtil.StrCmp(A28ManagerGAMGUID, GXt_char2) != 0 )
         {
            bttBtntrn_delete_Visible = 1;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         }
         else
         {
            GXt_char2 = "";
            new prc_getloggedinuserid(context ).execute( out  GXt_char2) ;
            if ( ! ( ( StringUtil.StrCmp(A28ManagerGAMGUID, GXt_char2) != 0 ) ) )
            {
               bttBtntrn_delete_Visible = 0;
               AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            }
         }
         GXt_boolean4 = AV32IsGAMActive;
         new prc_checkgamuseractivationstatus(context ).execute(  A28ManagerGAMGUID, out  GXt_boolean4) ;
         AV32IsGAMActive = GXt_boolean4;
         AssignAttri("", false, "AV32IsGAMActive", AV32IsGAMActive);
         chkManagerIsActive.Visible = ((AV32IsGAMActive) ? 1 : 0);
         AssignProp("", false, chkManagerIsActive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkManagerIsActive.Visible), 5, 0), true);
         if ( ! ( ( AV32IsGAMActive ) ) )
         {
            divManagerisactive_cell_Class = context.GetMessage( "Invisible", "");
            AssignProp("", false, divManagerisactive_cell_Internalname, "Class", divManagerisactive_cell_Class, true);
         }
         else
         {
            if ( AV32IsGAMActive )
            {
               divManagerisactive_cell_Class = context.GetMessage( "col-xs-12 col-sm-6 DataContentCell", "");
               AssignProp("", false, divManagerisactive_cell_Internalname, "Class", divManagerisactive_cell_Class, true);
            }
         }
      }

      protected void CloseExtendedTableCursors035( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_44( Guid A11OrganisationId )
      {
         /* Using cursor T00036 */
         pr_default.execute(4, new Object[] {A11OrganisationId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Organisations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtOrganisationId_Internalname;
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

      protected void GetKey035( )
      {
         /* Using cursor T00037 */
         pr_default.execute(5, new Object[] {A21ManagerId, A11OrganisationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00033 */
         pr_default.execute(1, new Object[] {A21ManagerId, A11OrganisationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM035( 43) ;
            RcdFound5 = 1;
            A21ManagerId = T00033_A21ManagerId[0];
            AssignAttri("", false, "A21ManagerId", A21ManagerId.ToString());
            A357ManagerPhoneCode = T00033_A357ManagerPhoneCode[0];
            AssignAttri("", false, "A357ManagerPhoneCode", A357ManagerPhoneCode);
            A24ManagerInitials = T00033_A24ManagerInitials[0];
            AssignAttri("", false, "A24ManagerInitials", A24ManagerInitials);
            A26ManagerPhone = T00033_A26ManagerPhone[0];
            AssignAttri("", false, "A26ManagerPhone", A26ManagerPhone);
            A22ManagerGivenName = T00033_A22ManagerGivenName[0];
            AssignAttri("", false, "A22ManagerGivenName", A22ManagerGivenName);
            A23ManagerLastName = T00033_A23ManagerLastName[0];
            AssignAttri("", false, "A23ManagerLastName", A23ManagerLastName);
            A25ManagerEmail = T00033_A25ManagerEmail[0];
            AssignAttri("", false, "A25ManagerEmail", A25ManagerEmail);
            A358ManagerPhoneNumber = T00033_A358ManagerPhoneNumber[0];
            AssignAttri("", false, "A358ManagerPhoneNumber", A358ManagerPhoneNumber);
            A27ManagerGender = T00033_A27ManagerGender[0];
            AssignAttri("", false, "A27ManagerGender", A27ManagerGender);
            A28ManagerGAMGUID = T00033_A28ManagerGAMGUID[0];
            AssignAttri("", false, "A28ManagerGAMGUID", A28ManagerGAMGUID);
            A332ManagerIsMainManager = T00033_A332ManagerIsMainManager[0];
            AssignAttri("", false, "A332ManagerIsMainManager", A332ManagerIsMainManager);
            A365ManagerIsActive = T00033_A365ManagerIsActive[0];
            AssignAttri("", false, "A365ManagerIsActive", A365ManagerIsActive);
            A40000ManagerImage_GXI = T00033_A40000ManagerImage_GXI[0];
            A11OrganisationId = T00033_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A446ManagerImage = T00033_A446ManagerImage[0];
            Z21ManagerId = A21ManagerId;
            Z11OrganisationId = A11OrganisationId;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load035( ) ;
            if ( AnyError == 1 )
            {
               RcdFound5 = 0;
               InitializeNonKey035( ) ;
            }
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey035( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey035( ) ;
         if ( RcdFound5 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound5 = 0;
         /* Using cursor T00038 */
         pr_default.execute(6, new Object[] {A21ManagerId, A11OrganisationId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T00038_A21ManagerId[0], A21ManagerId, 0) < 0 ) || ( T00038_A21ManagerId[0] == A21ManagerId ) && ( GuidUtil.Compare(T00038_A11OrganisationId[0], A11OrganisationId, 0) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T00038_A21ManagerId[0], A21ManagerId, 0) > 0 ) || ( T00038_A21ManagerId[0] == A21ManagerId ) && ( GuidUtil.Compare(T00038_A11OrganisationId[0], A11OrganisationId, 0) > 0 ) ) )
            {
               A21ManagerId = T00038_A21ManagerId[0];
               AssignAttri("", false, "A21ManagerId", A21ManagerId.ToString());
               A11OrganisationId = T00038_A11OrganisationId[0];
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               RcdFound5 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound5 = 0;
         /* Using cursor T00039 */
         pr_default.execute(7, new Object[] {A21ManagerId, A11OrganisationId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T00039_A21ManagerId[0], A21ManagerId, 0) > 0 ) || ( T00039_A21ManagerId[0] == A21ManagerId ) && ( GuidUtil.Compare(T00039_A11OrganisationId[0], A11OrganisationId, 0) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T00039_A21ManagerId[0], A21ManagerId, 0) < 0 ) || ( T00039_A21ManagerId[0] == A21ManagerId ) && ( GuidUtil.Compare(T00039_A11OrganisationId[0], A11OrganisationId, 0) < 0 ) ) )
            {
               A21ManagerId = T00039_A21ManagerId[0];
               AssignAttri("", false, "A21ManagerId", A21ManagerId.ToString());
               A11OrganisationId = T00039_A11OrganisationId[0];
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               RcdFound5 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey035( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtManagerGivenName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert035( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound5 == 1 )
            {
               if ( ( A21ManagerId != Z21ManagerId ) || ( A11OrganisationId != Z11OrganisationId ) )
               {
                  A21ManagerId = Z21ManagerId;
                  AssignAttri("", false, "A21ManagerId", A21ManagerId.ToString());
                  A11OrganisationId = Z11OrganisationId;
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "MANAGERID");
                  AnyError = 1;
                  GX_FocusControl = edtManagerId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtManagerGivenName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update035( ) ;
                  GX_FocusControl = edtManagerGivenName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A21ManagerId != Z21ManagerId ) || ( A11OrganisationId != Z11OrganisationId ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtManagerGivenName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert035( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MANAGERID");
                     AnyError = 1;
                     GX_FocusControl = edtManagerId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtManagerGivenName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert035( ) ;
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
         if ( ( A21ManagerId != Z21ManagerId ) || ( A11OrganisationId != Z11OrganisationId ) )
         {
            A21ManagerId = Z21ManagerId;
            AssignAttri("", false, "A21ManagerId", A21ManagerId.ToString());
            A11OrganisationId = Z11OrganisationId;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "MANAGERID");
            AnyError = 1;
            GX_FocusControl = edtManagerId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtManagerGivenName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency035( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00032 */
            pr_default.execute(0, new Object[] {A21ManagerId, A11OrganisationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Manager"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z357ManagerPhoneCode, T00032_A357ManagerPhoneCode[0]) != 0 ) || ( StringUtil.StrCmp(Z24ManagerInitials, T00032_A24ManagerInitials[0]) != 0 ) || ( StringUtil.StrCmp(Z26ManagerPhone, T00032_A26ManagerPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z22ManagerGivenName, T00032_A22ManagerGivenName[0]) != 0 ) || ( StringUtil.StrCmp(Z23ManagerLastName, T00032_A23ManagerLastName[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z25ManagerEmail, T00032_A25ManagerEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z358ManagerPhoneNumber, T00032_A358ManagerPhoneNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z27ManagerGender, T00032_A27ManagerGender[0]) != 0 ) || ( StringUtil.StrCmp(Z28ManagerGAMGUID, T00032_A28ManagerGAMGUID[0]) != 0 ) || ( Z332ManagerIsMainManager != T00032_A332ManagerIsMainManager[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z365ManagerIsActive != T00032_A365ManagerIsActive[0] ) )
            {
               if ( StringUtil.StrCmp(Z357ManagerPhoneCode, T00032_A357ManagerPhoneCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_manager:[seudo value changed for attri]"+"ManagerPhoneCode");
                  GXUtil.WriteLogRaw("Old: ",Z357ManagerPhoneCode);
                  GXUtil.WriteLogRaw("Current: ",T00032_A357ManagerPhoneCode[0]);
               }
               if ( StringUtil.StrCmp(Z24ManagerInitials, T00032_A24ManagerInitials[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_manager:[seudo value changed for attri]"+"ManagerInitials");
                  GXUtil.WriteLogRaw("Old: ",Z24ManagerInitials);
                  GXUtil.WriteLogRaw("Current: ",T00032_A24ManagerInitials[0]);
               }
               if ( StringUtil.StrCmp(Z26ManagerPhone, T00032_A26ManagerPhone[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_manager:[seudo value changed for attri]"+"ManagerPhone");
                  GXUtil.WriteLogRaw("Old: ",Z26ManagerPhone);
                  GXUtil.WriteLogRaw("Current: ",T00032_A26ManagerPhone[0]);
               }
               if ( StringUtil.StrCmp(Z22ManagerGivenName, T00032_A22ManagerGivenName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_manager:[seudo value changed for attri]"+"ManagerGivenName");
                  GXUtil.WriteLogRaw("Old: ",Z22ManagerGivenName);
                  GXUtil.WriteLogRaw("Current: ",T00032_A22ManagerGivenName[0]);
               }
               if ( StringUtil.StrCmp(Z23ManagerLastName, T00032_A23ManagerLastName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_manager:[seudo value changed for attri]"+"ManagerLastName");
                  GXUtil.WriteLogRaw("Old: ",Z23ManagerLastName);
                  GXUtil.WriteLogRaw("Current: ",T00032_A23ManagerLastName[0]);
               }
               if ( StringUtil.StrCmp(Z25ManagerEmail, T00032_A25ManagerEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_manager:[seudo value changed for attri]"+"ManagerEmail");
                  GXUtil.WriteLogRaw("Old: ",Z25ManagerEmail);
                  GXUtil.WriteLogRaw("Current: ",T00032_A25ManagerEmail[0]);
               }
               if ( StringUtil.StrCmp(Z358ManagerPhoneNumber, T00032_A358ManagerPhoneNumber[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_manager:[seudo value changed for attri]"+"ManagerPhoneNumber");
                  GXUtil.WriteLogRaw("Old: ",Z358ManagerPhoneNumber);
                  GXUtil.WriteLogRaw("Current: ",T00032_A358ManagerPhoneNumber[0]);
               }
               if ( StringUtil.StrCmp(Z27ManagerGender, T00032_A27ManagerGender[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_manager:[seudo value changed for attri]"+"ManagerGender");
                  GXUtil.WriteLogRaw("Old: ",Z27ManagerGender);
                  GXUtil.WriteLogRaw("Current: ",T00032_A27ManagerGender[0]);
               }
               if ( StringUtil.StrCmp(Z28ManagerGAMGUID, T00032_A28ManagerGAMGUID[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_manager:[seudo value changed for attri]"+"ManagerGAMGUID");
                  GXUtil.WriteLogRaw("Old: ",Z28ManagerGAMGUID);
                  GXUtil.WriteLogRaw("Current: ",T00032_A28ManagerGAMGUID[0]);
               }
               if ( Z332ManagerIsMainManager != T00032_A332ManagerIsMainManager[0] )
               {
                  GXUtil.WriteLog("trn_manager:[seudo value changed for attri]"+"ManagerIsMainManager");
                  GXUtil.WriteLogRaw("Old: ",Z332ManagerIsMainManager);
                  GXUtil.WriteLogRaw("Current: ",T00032_A332ManagerIsMainManager[0]);
               }
               if ( Z365ManagerIsActive != T00032_A365ManagerIsActive[0] )
               {
                  GXUtil.WriteLog("trn_manager:[seudo value changed for attri]"+"ManagerIsActive");
                  GXUtil.WriteLogRaw("Old: ",Z365ManagerIsActive);
                  GXUtil.WriteLogRaw("Current: ",T00032_A365ManagerIsActive[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Manager"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert035( )
      {
         if ( ! IsAuthorized("trn_manager_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate035( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable035( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM035( 0) ;
            CheckOptimisticConcurrency035( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm035( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert035( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000310 */
                     pr_default.execute(8, new Object[] {A21ManagerId, A357ManagerPhoneCode, A24ManagerInitials, A26ManagerPhone, A22ManagerGivenName, A23ManagerLastName, A25ManagerEmail, A358ManagerPhoneNumber, A27ManagerGender, A28ManagerGAMGUID, A332ManagerIsMainManager, A365ManagerIsActive, A446ManagerImage, A40000ManagerImage_GXI, A11OrganisationId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Manager");
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
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption030( ) ;
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
               Load035( ) ;
            }
            EndLevel035( ) ;
         }
         CloseExtendedTableCursors035( ) ;
      }

      protected void Update035( )
      {
         if ( ! IsAuthorized("trn_manager_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate035( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable035( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency035( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm035( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate035( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000311 */
                     pr_default.execute(9, new Object[] {A357ManagerPhoneCode, A24ManagerInitials, A26ManagerPhone, A22ManagerGivenName, A23ManagerLastName, A25ManagerEmail, A358ManagerPhoneNumber, A27ManagerGender, A28ManagerGAMGUID, A332ManagerIsMainManager, A365ManagerIsActive, A21ManagerId, A11OrganisationId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Manager");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Manager"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate035( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
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
            EndLevel035( ) ;
         }
         CloseExtendedTableCursors035( ) ;
      }

      protected void DeferredUpdate035( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000312 */
            pr_default.execute(10, new Object[] {A446ManagerImage, A40000ManagerImage_GXI, A21ManagerId, A11OrganisationId});
            pr_default.close(10);
            pr_default.SmartCacheProvider.SetUpdated("Trn_Manager");
         }
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_manager_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate035( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency035( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls035( ) ;
            AfterConfirm035( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete035( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000313 */
                  pr_default.execute(11, new Object[] {A21ManagerId, A11OrganisationId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Manager");
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
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel035( ) ;
         Gx_mode = sMode5;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls035( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            if ( ! ( new prc_mainmanagerscount(context).executeUdp(  A11OrganisationId) > 0 ) && ( ( ! A332ManagerIsMainManager && IsUpd( )  ) || IsDlt( )  ) )
            {
               GX_msglist.addItem(context.GetMessage( "Organisation must have atleast one main Manager", ""), 1, "MANAGERISMAINMANAGER");
               AnyError = 1;
               GX_FocusControl = chkManagerIsMainManager_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            GXt_char2 = "";
            new prc_getloggedinuserid(context ).execute( out  GXt_char2) ;
            if ( StringUtil.StrCmp(A28ManagerGAMGUID, GXt_char2) != 0 )
            {
               bttBtntrn_delete_Visible = 1;
               AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            }
            else
            {
               GXt_char2 = "";
               new prc_getloggedinuserid(context ).execute( out  GXt_char2) ;
               if ( ! ( ( StringUtil.StrCmp(A28ManagerGAMGUID, GXt_char2) != 0 ) ) )
               {
                  bttBtntrn_delete_Visible = 0;
                  AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
               }
            }
            GXt_boolean4 = AV32IsGAMActive;
            new prc_checkgamuseractivationstatus(context ).execute(  A28ManagerGAMGUID, out  GXt_boolean4) ;
            AV32IsGAMActive = GXt_boolean4;
            AssignAttri("", false, "AV32IsGAMActive", AV32IsGAMActive);
            chkManagerIsActive.Visible = ((AV32IsGAMActive) ? 1 : 0);
            AssignProp("", false, chkManagerIsActive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkManagerIsActive.Visible), 5, 0), true);
            if ( ! ( ( AV32IsGAMActive ) ) )
            {
               divManagerisactive_cell_Class = context.GetMessage( "Invisible", "");
               AssignProp("", false, divManagerisactive_cell_Internalname, "Class", divManagerisactive_cell_Class, true);
            }
            else
            {
               if ( AV32IsGAMActive )
               {
                  divManagerisactive_cell_Class = context.GetMessage( "col-xs-12 col-sm-6 DataContentCell", "");
                  AssignProp("", false, divManagerisactive_cell_Internalname, "Class", divManagerisactive_cell_Class, true);
               }
            }
            if ( IsDlt( )  && ( StringUtil.StrCmp(A28ManagerGAMGUID, new prc_getloggedinuserid(context).executeUdp( )) == 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "Invalid Delete Action: You cannot delete your own account.", ""), 1, "MANAGERGAMGUID");
               AnyError = 1;
               GX_FocusControl = edtManagerGAMGUID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
      }

      protected void EndLevel035( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete035( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_manager",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues030( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_manager",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart035( )
      {
         /* Scan By routine */
         /* Using cursor T000314 */
         pr_default.execute(12);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound5 = 1;
            A21ManagerId = T000314_A21ManagerId[0];
            AssignAttri("", false, "A21ManagerId", A21ManagerId.ToString());
            A11OrganisationId = T000314_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext035( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound5 = 1;
            A21ManagerId = T000314_A21ManagerId[0];
            AssignAttri("", false, "A21ManagerId", A21ManagerId.ToString());
            A11OrganisationId = T000314_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
      }

      protected void ScanEnd035( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm035( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert035( )
      {
         /* Before Insert Rules */
         AV25GAMErrorResponse = "";
         AssignAttri("", false, "AV25GAMErrorResponse", AV25GAMErrorResponse);
         AssignAttri("", false, "AV25GAMErrorResponse", AV25GAMErrorResponse);
         if ( ( StringUtil.StrCmp(Gx_mode, context.GetMessage( "INS", "")) == 0 ) && String.IsNullOrEmpty(StringUtil.RTrim( A28ManagerGAMGUID)) )
         {
            new prc_creategamuseraccount(context ).execute(  A25ManagerEmail,  A22ManagerGivenName,  A23ManagerLastName,  "Organisation Manager", ref  A28ManagerGAMGUID, ref  AV25GAMErrorResponse) ;
            AssignAttri("", false, "A28ManagerGAMGUID", A28ManagerGAMGUID);
            AssignAttri("", false, "AV25GAMErrorResponse", AV25GAMErrorResponse);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, context.GetMessage( "INS", "")) == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV25GAMErrorResponse)) )
         {
            GX_msglist.addItem(AV25GAMErrorResponse, 1, "");
            AnyError = 1;
         }
      }

      protected void BeforeUpdate035( )
      {
         /* Before Update Rules */
         AV25GAMErrorResponse = "";
         AssignAttri("", false, "AV25GAMErrorResponse", AV25GAMErrorResponse);
         AssignAttri("", false, "AV25GAMErrorResponse", AV25GAMErrorResponse);
         new loadaudittrn_manager(context ).execute(  "Y", ref  AV30AuditingObject,  A21ManagerId,  A11OrganisationId,  Gx_mode) ;
         if ( IsUpd( )  )
         {
            new prc_updategamuseraccount(context ).execute(  A28ManagerGAMGUID,  A22ManagerGivenName,  A23ManagerLastName,  A357ManagerPhoneCode,  A358ManagerPhoneNumber,  A446ManagerImage,  A365ManagerIsActive,  "Organisation Manager", out  AV25GAMErrorResponse) ;
            AssignAttri("", false, "AV25GAMErrorResponse", AV25GAMErrorResponse);
         }
         if ( IsUpd( )  && ! String.IsNullOrEmpty(StringUtil.RTrim( AV25GAMErrorResponse)) )
         {
            GX_msglist.addItem(AV25GAMErrorResponse, 1, "");
            AnyError = 1;
         }
         if ( IsDlt( )  && ! String.IsNullOrEmpty(StringUtil.RTrim( AV25GAMErrorResponse)) )
         {
            GX_msglist.addItem(AV25GAMErrorResponse, 1, "");
            AnyError = 1;
         }
      }

      protected void BeforeDelete035( )
      {
         /* Before Delete Rules */
         AV25GAMErrorResponse = "";
         AssignAttri("", false, "AV25GAMErrorResponse", AV25GAMErrorResponse);
         AssignAttri("", false, "AV25GAMErrorResponse", AV25GAMErrorResponse);
         new loadaudittrn_manager(context ).execute(  "Y", ref  AV30AuditingObject,  A21ManagerId,  A11OrganisationId,  Gx_mode) ;
         if ( IsDlt( )  )
         {
            new prc_deletegamuseraccount(context ).execute(  A28ManagerGAMGUID, out  AV25GAMErrorResponse) ;
            AssignAttri("", false, "AV25GAMErrorResponse", AV25GAMErrorResponse);
         }
      }

      protected void BeforeComplete035( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new loadaudittrn_manager(context ).execute(  "N", ref  AV30AuditingObject,  A21ManagerId,  A11OrganisationId,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new loadaudittrn_manager(context ).execute(  "N", ref  AV30AuditingObject,  A21ManagerId,  A11OrganisationId,  Gx_mode) ;
         }
      }

      protected void BeforeValidate035( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes035( )
      {
         edtManagerGivenName_Enabled = 0;
         AssignProp("", false, edtManagerGivenName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtManagerGivenName_Enabled), 5, 0), true);
         edtManagerLastName_Enabled = 0;
         AssignProp("", false, edtManagerLastName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtManagerLastName_Enabled), 5, 0), true);
         cmbManagerGender.Enabled = 0;
         AssignProp("", false, cmbManagerGender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbManagerGender.Enabled), 5, 0), true);
         edtManagerEmail_Enabled = 0;
         AssignProp("", false, edtManagerEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtManagerEmail_Enabled), 5, 0), true);
         edtManagerPhoneCode_Enabled = 0;
         AssignProp("", false, edtManagerPhoneCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtManagerPhoneCode_Enabled), 5, 0), true);
         edtManagerPhoneNumber_Enabled = 0;
         AssignProp("", false, edtManagerPhoneNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtManagerPhoneNumber_Enabled), 5, 0), true);
         edtManagerPhone_Enabled = 0;
         AssignProp("", false, edtManagerPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtManagerPhone_Enabled), 5, 0), true);
         chkManagerIsMainManager.Enabled = 0;
         AssignProp("", false, chkManagerIsMainManager_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkManagerIsMainManager.Enabled), 5, 0), true);
         chkManagerIsActive.Enabled = 0;
         AssignProp("", false, chkManagerIsActive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkManagerIsActive.Enabled), 5, 0), true);
         edtavCombomanagerphonecode_Enabled = 0;
         AssignProp("", false, edtavCombomanagerphonecode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombomanagerphonecode_Enabled), 5, 0), true);
         edtManagerId_Enabled = 0;
         AssignProp("", false, edtManagerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtManagerId_Enabled), 5, 0), true);
         edtOrganisationId_Enabled = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         edtManagerInitials_Enabled = 0;
         AssignProp("", false, edtManagerInitials_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtManagerInitials_Enabled), 5, 0), true);
         edtManagerGAMGUID_Enabled = 0;
         AssignProp("", false, edtManagerGAMGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtManagerGAMGUID_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes035( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues030( )
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
         GXEncryptionTmp = "trn_manager.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7ManagerId.ToString()) + "," + UrlEncode(AV8OrganisationId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_manager.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Manager");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV35Pgmname, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_manager:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z21ManagerId", Z21ManagerId.ToString());
         GxWebStd.gx_hidden_field( context, "Z11OrganisationId", Z11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z357ManagerPhoneCode", Z357ManagerPhoneCode);
         GxWebStd.gx_hidden_field( context, "Z24ManagerInitials", StringUtil.RTrim( Z24ManagerInitials));
         GxWebStd.gx_hidden_field( context, "Z26ManagerPhone", StringUtil.RTrim( Z26ManagerPhone));
         GxWebStd.gx_hidden_field( context, "Z22ManagerGivenName", Z22ManagerGivenName);
         GxWebStd.gx_hidden_field( context, "Z23ManagerLastName", Z23ManagerLastName);
         GxWebStd.gx_hidden_field( context, "Z25ManagerEmail", Z25ManagerEmail);
         GxWebStd.gx_hidden_field( context, "Z358ManagerPhoneNumber", Z358ManagerPhoneNumber);
         GxWebStd.gx_hidden_field( context, "Z27ManagerGender", Z27ManagerGender);
         GxWebStd.gx_hidden_field( context, "Z28ManagerGAMGUID", Z28ManagerGAMGUID);
         GxWebStd.gx_boolean_hidden_field( context, "Z332ManagerIsMainManager", Z332ManagerIsMainManager);
         GxWebStd.gx_boolean_hidden_field( context, "Z365ManagerIsActive", Z365ManagerIsActive);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV15DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV15DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGERPHONECODE_DATA", AV28ManagerPhoneCode_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGERPHONECODE_DATA", AV28ManagerPhoneCode_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV12TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV12TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV12TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vMANAGERID", AV7ManagerId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vMANAGERID", GetSecureSignedToken( "", AV7ManagerId, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV8OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV8OrganisationId, context));
         GxWebStd.gx_hidden_field( context, "vGAMERRORRESPONSE", AV25GAMErrorResponse);
         GxWebStd.gx_boolean_hidden_field( context, "vISGAMACTIVE", AV32IsGAMActive);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAUDITINGOBJECT", AV30AuditingObject);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAUDITINGOBJECT", AV30AuditingObject);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "MANAGERIMAGE", A446ManagerImage);
         GxWebStd.gx_hidden_field( context, "MANAGERIMAGE_GXI", A40000ManagerImage_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV35Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_MANAGERPHONECODE_Objectcall", StringUtil.RTrim( Combo_managerphonecode_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_MANAGERPHONECODE_Cls", StringUtil.RTrim( Combo_managerphonecode_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_MANAGERPHONECODE_Selectedvalue_set", StringUtil.RTrim( Combo_managerphonecode_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_MANAGERPHONECODE_Selectedtext_set", StringUtil.RTrim( Combo_managerphonecode_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_MANAGERPHONECODE_Enabled", StringUtil.BoolToStr( Combo_managerphonecode_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_MANAGERPHONECODE_Emptyitem", StringUtil.BoolToStr( Combo_managerphonecode_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_MANAGERPHONECODE_Htmltemplate", StringUtil.RTrim( Combo_managerphonecode_Htmltemplate));
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
         GXEncryptionTmp = "trn_manager.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7ManagerId.ToString()) + "," + UrlEncode(AV8OrganisationId.ToString());
         return formatLink("trn_manager.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Trn_Manager" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Managers", "") ;
      }

      protected void InitializeNonKey035( )
      {
         A357ManagerPhoneCode = "";
         AssignAttri("", false, "A357ManagerPhoneCode", A357ManagerPhoneCode);
         AV30AuditingObject = new WorkWithPlus.workwithplus_web.SdtAuditingObject(context);
         AV25GAMErrorResponse = "";
         AssignAttri("", false, "AV25GAMErrorResponse", AV25GAMErrorResponse);
         A24ManagerInitials = "";
         AssignAttri("", false, "A24ManagerInitials", A24ManagerInitials);
         A26ManagerPhone = "";
         AssignAttri("", false, "A26ManagerPhone", A26ManagerPhone);
         AV32IsGAMActive = false;
         AssignAttri("", false, "AV32IsGAMActive", AV32IsGAMActive);
         A22ManagerGivenName = "";
         AssignAttri("", false, "A22ManagerGivenName", A22ManagerGivenName);
         A23ManagerLastName = "";
         AssignAttri("", false, "A23ManagerLastName", A23ManagerLastName);
         A25ManagerEmail = "";
         AssignAttri("", false, "A25ManagerEmail", A25ManagerEmail);
         A358ManagerPhoneNumber = "";
         AssignAttri("", false, "A358ManagerPhoneNumber", A358ManagerPhoneNumber);
         A27ManagerGender = "";
         AssignAttri("", false, "A27ManagerGender", A27ManagerGender);
         A28ManagerGAMGUID = "";
         AssignAttri("", false, "A28ManagerGAMGUID", A28ManagerGAMGUID);
         A365ManagerIsActive = false;
         AssignAttri("", false, "A365ManagerIsActive", A365ManagerIsActive);
         A446ManagerImage = "";
         AssignAttri("", false, "A446ManagerImage", A446ManagerImage);
         A40000ManagerImage_GXI = "";
         AssignAttri("", false, "A40000ManagerImage_GXI", A40000ManagerImage_GXI);
         A332ManagerIsMainManager = false;
         AssignAttri("", false, "A332ManagerIsMainManager", A332ManagerIsMainManager);
         Z357ManagerPhoneCode = "";
         Z24ManagerInitials = "";
         Z26ManagerPhone = "";
         Z22ManagerGivenName = "";
         Z23ManagerLastName = "";
         Z25ManagerEmail = "";
         Z358ManagerPhoneNumber = "";
         Z27ManagerGender = "";
         Z28ManagerGAMGUID = "";
         Z332ManagerIsMainManager = false;
         Z365ManagerIsActive = false;
      }

      protected void InitAll035( )
      {
         A21ManagerId = Guid.NewGuid( );
         AssignAttri("", false, "A21ManagerId", A21ManagerId.ToString());
         A11OrganisationId = Guid.Empty;
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         InitializeNonKey035( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A332ManagerIsMainManager = i332ManagerIsMainManager;
         AssignAttri("", false, "A332ManagerIsMainManager", A332ManagerIsMainManager);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20257212461636", true, true);
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
         context.AddJavascriptSource("trn_manager.js", "?20257212461638", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtManagerGivenName_Internalname = "MANAGERGIVENNAME";
         edtManagerLastName_Internalname = "MANAGERLASTNAME";
         cmbManagerGender_Internalname = "MANAGERGENDER";
         edtManagerEmail_Internalname = "MANAGEREMAIL";
         lblPhone_Internalname = "PHONE";
         Combo_managerphonecode_Internalname = "COMBO_MANAGERPHONECODE";
         edtManagerPhoneCode_Internalname = "MANAGERPHONECODE";
         divUnnamedtablemanagerphonecode_Internalname = "UNNAMEDTABLEMANAGERPHONECODE";
         divUnnamedtable4_Internalname = "UNNAMEDTABLE4";
         edtManagerPhoneNumber_Internalname = "MANAGERPHONENUMBER";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         edtManagerPhone_Internalname = "MANAGERPHONE";
         divManagerphone_cell_Internalname = "MANAGERPHONE_CELL";
         chkManagerIsMainManager_Internalname = "MANAGERISMAINMANAGER";
         chkManagerIsActive_Internalname = "MANAGERISACTIVE";
         divManagerisactive_cell_Internalname = "MANAGERISACTIVE_CELL";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombomanagerphonecode_Internalname = "vCOMBOMANAGERPHONECODE";
         divSectionattribute_managerphonecode_Internalname = "SECTIONATTRIBUTE_MANAGERPHONECODE";
         edtManagerId_Internalname = "MANAGERID";
         edtOrganisationId_Internalname = "ORGANISATIONID";
         edtManagerInitials_Internalname = "MANAGERINITIALS";
         edtManagerGAMGUID_Internalname = "MANAGERGAMGUID";
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
         Form.Caption = context.GetMessage( "Managers", "");
         Combo_managerphonecode_Htmltemplate = "";
         edtManagerGAMGUID_Jsonclick = "";
         edtManagerGAMGUID_Enabled = 1;
         edtManagerGAMGUID_Visible = 1;
         edtManagerInitials_Jsonclick = "";
         edtManagerInitials_Enabled = 1;
         edtManagerInitials_Visible = 1;
         edtOrganisationId_Jsonclick = "";
         edtOrganisationId_Enabled = 1;
         edtOrganisationId_Visible = 1;
         edtManagerId_Jsonclick = "";
         edtManagerId_Enabled = 1;
         edtManagerId_Visible = 1;
         edtavCombomanagerphonecode_Jsonclick = "";
         edtavCombomanagerphonecode_Enabled = 0;
         edtavCombomanagerphonecode_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         chkManagerIsActive.Enabled = 1;
         chkManagerIsActive.Visible = 1;
         divManagerisactive_cell_Class = "col-xs-12 col-sm-6";
         chkManagerIsMainManager.Enabled = 1;
         edtManagerPhone_Jsonclick = "";
         edtManagerPhone_Enabled = 1;
         edtManagerPhone_Visible = 1;
         divManagerphone_cell_Class = "col-xs-12 col-sm-6";
         edtManagerPhoneNumber_Jsonclick = "";
         edtManagerPhoneNumber_Enabled = 1;
         edtManagerPhoneCode_Jsonclick = "";
         edtManagerPhoneCode_Enabled = 1;
         edtManagerPhoneCode_Visible = 1;
         Combo_managerphonecode_Emptyitem = Convert.ToBoolean( 0);
         Combo_managerphonecode_Cls = "ExtendedCombo DropDownComponent ExtendedComboWithImage";
         Combo_managerphonecode_Caption = "";
         Combo_managerphonecode_Enabled = Convert.ToBoolean( -1);
         divUnnamedtable2_Visible = 1;
         edtManagerEmail_Jsonclick = "";
         edtManagerEmail_Enabled = 1;
         cmbManagerGender_Jsonclick = "";
         cmbManagerGender.Enabled = 1;
         edtManagerLastName_Jsonclick = "";
         edtManagerLastName_Enabled = 1;
         edtManagerGivenName_Jsonclick = "";
         edtManagerGivenName_Enabled = 1;
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

      protected void GX18ASAMANAGERPHONE035( string A357ManagerPhoneCode ,
                                             string A358ManagerPhoneNumber )
      {
         GXt_char2 = A26ManagerPhone;
         new prc_concatenateintlphone(context ).execute(  A357ManagerPhoneCode,  A358ManagerPhoneNumber, out  GXt_char2) ;
         A26ManagerPhone = GXt_char2;
         AssignAttri("", false, "A26ManagerPhone", A26ManagerPhone);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A26ManagerPhone))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX19ASAISGAMACTIVE035( string A28ManagerGAMGUID )
      {
         GXt_boolean4 = AV32IsGAMActive;
         new prc_checkgamuseractivationstatus(context ).execute(  A28ManagerGAMGUID, out  GXt_boolean4) ;
         AV32IsGAMActive = GXt_boolean4;
         AssignAttri("", false, "AV32IsGAMActive", AV32IsGAMActive);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( AV32IsGAMActive))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_28_035( WorkWithPlus.workwithplus_web.SdtAuditingObject AV30AuditingObject ,
                                Guid A21ManagerId ,
                                Guid A11OrganisationId ,
                                string Gx_mode )
      {
         new loadaudittrn_manager(context ).execute(  "Y", ref  AV30AuditingObject,  A21ManagerId,  A11OrganisationId,  Gx_mode) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV30AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_29_035( WorkWithPlus.workwithplus_web.SdtAuditingObject AV30AuditingObject ,
                                Guid A21ManagerId ,
                                Guid A11OrganisationId ,
                                string Gx_mode )
      {
         new loadaudittrn_manager(context ).execute(  "Y", ref  AV30AuditingObject,  A21ManagerId,  A11OrganisationId,  Gx_mode) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV30AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_30_035( string Gx_mode ,
                                WorkWithPlus.workwithplus_web.SdtAuditingObject AV30AuditingObject ,
                                Guid A21ManagerId ,
                                Guid A11OrganisationId )
      {
         if ( IsIns( )  )
         {
            new loadaudittrn_manager(context ).execute(  "N", ref  AV30AuditingObject,  A21ManagerId,  A11OrganisationId,  Gx_mode) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV30AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_31_035( string Gx_mode ,
                                WorkWithPlus.workwithplus_web.SdtAuditingObject AV30AuditingObject ,
                                Guid A21ManagerId ,
                                Guid A11OrganisationId )
      {
         if ( IsUpd( )  )
         {
            new loadaudittrn_manager(context ).execute(  "N", ref  AV30AuditingObject,  A21ManagerId,  A11OrganisationId,  Gx_mode) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV30AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_32_035( string A25ManagerEmail ,
                                string A22ManagerGivenName ,
                                string A23ManagerLastName ,
                                string A28ManagerGAMGUID ,
                                string AV25GAMErrorResponse ,
                                string Gx_mode )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, context.GetMessage( "INS", "")) == 0 ) && String.IsNullOrEmpty(StringUtil.RTrim( A28ManagerGAMGUID)) )
         {
            new prc_creategamuseraccount(context ).execute(  A25ManagerEmail,  A22ManagerGivenName,  A23ManagerLastName,  "Organisation Manager", ref  A28ManagerGAMGUID, ref  AV25GAMErrorResponse) ;
            AssignAttri("", false, "A28ManagerGAMGUID", A28ManagerGAMGUID);
            AssignAttri("", false, "AV25GAMErrorResponse", AV25GAMErrorResponse);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A28ManagerGAMGUID)+"\""+","+"\""+GXUtil.EncodeJSConstant( AV25GAMErrorResponse)+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_34_035( string A22ManagerGivenName ,
                                string A23ManagerLastName )
      {
         new prc_getnameinitials(context ).execute(  A22ManagerGivenName,  A23ManagerLastName, out  A24ManagerInitials) ;
         AssignAttri("", false, "A24ManagerInitials", A24ManagerInitials);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A24ManagerInitials))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_36_035( string Gx_mode ,
                                string A28ManagerGAMGUID ,
                                string A22ManagerGivenName ,
                                string A23ManagerLastName ,
                                string A357ManagerPhoneCode ,
                                string A358ManagerPhoneNumber ,
                                string A446ManagerImage ,
                                bool A365ManagerIsActive )
      {
         if ( IsUpd( )  )
         {
            new prc_updategamuseraccount(context ).execute(  A28ManagerGAMGUID,  A22ManagerGivenName,  A23ManagerLastName,  A357ManagerPhoneCode,  A358ManagerPhoneNumber,  A446ManagerImage,  A365ManagerIsActive,  "Organisation Manager", out  AV25GAMErrorResponse) ;
            AssignAttri("", false, "AV25GAMErrorResponse", AV25GAMErrorResponse);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( AV25GAMErrorResponse)+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_39_035( string Gx_mode ,
                                string A28ManagerGAMGUID )
      {
         if ( IsDlt( )  )
         {
            new prc_deletegamuseraccount(context ).execute(  A28ManagerGAMGUID, out  AV25GAMErrorResponse) ;
            AssignAttri("", false, "AV25GAMErrorResponse", AV25GAMErrorResponse);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( AV25GAMErrorResponse)+"\"") ;
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
         cmbManagerGender.Name = "MANAGERGENDER";
         cmbManagerGender.WebTags = "";
         cmbManagerGender.addItem("Male", context.GetMessage( "Male", ""), 0);
         cmbManagerGender.addItem("Female", context.GetMessage( "Female", ""), 0);
         cmbManagerGender.addItem("Other", context.GetMessage( "Other", ""), 0);
         if ( cmbManagerGender.ItemCount > 0 )
         {
            A27ManagerGender = cmbManagerGender.getValidValue(A27ManagerGender);
            AssignAttri("", false, "A27ManagerGender", A27ManagerGender);
         }
         chkManagerIsMainManager.Name = "MANAGERISMAINMANAGER";
         chkManagerIsMainManager.WebTags = "";
         chkManagerIsMainManager.Caption = context.GetMessage( "Is Main Manager?", "");
         AssignProp("", false, chkManagerIsMainManager_Internalname, "TitleCaption", chkManagerIsMainManager.Caption, true);
         chkManagerIsMainManager.CheckedValue = "false";
         if ( IsIns( ) && (false==A332ManagerIsMainManager) )
         {
            A332ManagerIsMainManager = false;
            AssignAttri("", false, "A332ManagerIsMainManager", A332ManagerIsMainManager);
         }
         chkManagerIsActive.Name = "MANAGERISACTIVE";
         chkManagerIsActive.WebTags = "";
         chkManagerIsActive.Caption = context.GetMessage( "Is Active", "");
         AssignProp("", false, chkManagerIsActive_Internalname, "TitleCaption", chkManagerIsActive.Caption, true);
         chkManagerIsActive.CheckedValue = "false";
         A365ManagerIsActive = StringUtil.StrToBool( StringUtil.BoolToStr( A365ManagerIsActive));
         AssignAttri("", false, "A365ManagerIsActive", A365ManagerIsActive);
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
         /* Using cursor T000315 */
         pr_default.execute(13, new Object[] {A11OrganisationId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Organisations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtOrganisationId_Internalname;
         }
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Managerlastname( )
      {
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A23ManagerLastName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Manager Last Name", ""), "", "", "", "", "", "", "", ""), 1, "MANAGERLASTNAME");
            AnyError = 1;
            GX_FocusControl = edtManagerLastName_Internalname;
         }
         new prc_getnameinitials(context ).execute(  A22ManagerGivenName,  A23ManagerLastName, out  A24ManagerInitials) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A24ManagerInitials", StringUtil.RTrim( A24ManagerInitials));
      }

      public void Valid_Managerphonenumber( )
      {
         GXt_char2 = A26ManagerPhone;
         new prc_concatenateintlphone(context ).execute(  A357ManagerPhoneCode,  A358ManagerPhoneNumber, out  GXt_char2) ;
         A26ManagerPhone = GXt_char2;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A358ManagerPhoneNumber)) && ! GxRegex.IsMatch(A358ManagerPhoneNumber,context.GetMessage( "^\\d{9}$", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Phone contains 9 digits", ""), 1, "MANAGERPHONENUMBER");
            AnyError = 1;
            GX_FocusControl = edtManagerPhoneNumber_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A26ManagerPhone", StringUtil.RTrim( A26ManagerPhone));
      }

      public void Valid_Managerismainmanager( )
      {
         if ( ! ( new prc_mainmanagerscount(context).executeUdp(  A11OrganisationId) > 0 ) && ( ( ! A332ManagerIsMainManager && IsUpd( )  ) || IsDlt( )  ) )
         {
            GX_msglist.addItem(context.GetMessage( "Organisation must have atleast one main Manager", ""), 1, "MANAGERISMAINMANAGER");
            AnyError = 1;
            GX_FocusControl = chkManagerIsMainManager_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Managergamguid( )
      {
         GXt_char2 = "";
         new prc_getloggedinuserid(context ).execute( out  GXt_char2) ;
         if ( StringUtil.StrCmp(A28ManagerGAMGUID, GXt_char2) != 0 )
         {
            bttBtntrn_delete_Visible = 1;
         }
         else
         {
            GXt_char2 = "";
            new prc_getloggedinuserid(context ).execute( out  GXt_char2) ;
            if ( ! ( ( StringUtil.StrCmp(A28ManagerGAMGUID, GXt_char2) != 0 ) ) )
            {
               bttBtntrn_delete_Visible = 0;
            }
         }
         GXt_boolean4 = AV32IsGAMActive;
         new prc_checkgamuseractivationstatus(context ).execute(  A28ManagerGAMGUID, out  GXt_boolean4) ;
         AV32IsGAMActive = GXt_boolean4;
         chkManagerIsActive.Visible = ((AV32IsGAMActive) ? 1 : 0);
         if ( ! ( ( AV32IsGAMActive ) ) )
         {
            divManagerisactive_cell_Class = context.GetMessage( "Invisible", "");
         }
         else
         {
            if ( AV32IsGAMActive )
            {
               divManagerisactive_cell_Class = context.GetMessage( "col-xs-12 col-sm-6 DataContentCell", "");
            }
         }
         if ( IsDlt( )  && ( StringUtil.StrCmp(A28ManagerGAMGUID, new prc_getloggedinuserid(context).executeUdp( )) == 0 ) )
         {
            GX_msglist.addItem(context.GetMessage( "Invalid Delete Action: You cannot delete your own account.", ""), 1, "MANAGERGAMGUID");
            AnyError = 1;
            GX_FocusControl = edtManagerGAMGUID_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         AssignAttri("", false, "AV32IsGAMActive", AV32IsGAMActive);
         AssignProp("", false, chkManagerIsActive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkManagerIsActive.Visible), 5, 0), true);
         AssignProp("", false, divManagerisactive_cell_Internalname, "Class", divManagerisactive_cell_Class, true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7ManagerId","fld":"vMANAGERID","hsh":true},{"av":"AV8OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"A332ManagerIsMainManager","fld":"MANAGERISMAINMANAGER"},{"av":"A365ManagerIsActive","fld":"MANAGERISACTIVE"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A332ManagerIsMainManager","fld":"MANAGERISMAINMANAGER"},{"av":"A365ManagerIsActive","fld":"MANAGERISACTIVE"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV12TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7ManagerId","fld":"vMANAGERID","hsh":true},{"av":"AV8OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV35Pgmname","fld":"vPGMNAME"},{"av":"A332ManagerIsMainManager","fld":"MANAGERISMAINMANAGER"},{"av":"A365ManagerIsActive","fld":"MANAGERISACTIVE"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A332ManagerIsMainManager","fld":"MANAGERISMAINMANAGER"},{"av":"A365ManagerIsActive","fld":"MANAGERISACTIVE"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12032","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV30AuditingObject","fld":"vAUDITINGOBJECT"},{"av":"AV35Pgmname","fld":"vPGMNAME"},{"av":"AV12TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"A332ManagerIsMainManager","fld":"MANAGERISMAINMANAGER"},{"av":"A365ManagerIsActive","fld":"MANAGERISACTIVE"}]""");
         setEventMetadata("AFTER TRN",""","oparms":[{"av":"A332ManagerIsMainManager","fld":"MANAGERISMAINMANAGER"},{"av":"A365ManagerIsActive","fld":"MANAGERISACTIVE"}]}""");
         setEventMetadata("VALID_MANAGERGIVENNAME","""{"handler":"Valid_Managergivenname","iparms":[{"av":"A332ManagerIsMainManager","fld":"MANAGERISMAINMANAGER"},{"av":"A365ManagerIsActive","fld":"MANAGERISACTIVE"}]""");
         setEventMetadata("VALID_MANAGERGIVENNAME",""","oparms":[{"av":"A332ManagerIsMainManager","fld":"MANAGERISMAINMANAGER"},{"av":"A365ManagerIsActive","fld":"MANAGERISACTIVE"}]}""");
         setEventMetadata("VALID_MANAGERLASTNAME","""{"handler":"Valid_Managerlastname","iparms":[{"av":"A23ManagerLastName","fld":"MANAGERLASTNAME"},{"av":"A22ManagerGivenName","fld":"MANAGERGIVENNAME"},{"av":"A24ManagerInitials","fld":"MANAGERINITIALS"},{"av":"A332ManagerIsMainManager","fld":"MANAGERISMAINMANAGER"},{"av":"A365ManagerIsActive","fld":"MANAGERISACTIVE"}]""");
         setEventMetadata("VALID_MANAGERLASTNAME",""","oparms":[{"av":"A24ManagerInitials","fld":"MANAGERINITIALS"},{"av":"A332ManagerIsMainManager","fld":"MANAGERISMAINMANAGER"},{"av":"A365ManagerIsActive","fld":"MANAGERISACTIVE"}]}""");
         setEventMetadata("VALID_MANAGERGENDER","""{"handler":"Valid_Managergender","iparms":[{"av":"A332ManagerIsMainManager","fld":"MANAGERISMAINMANAGER"},{"av":"A365ManagerIsActive","fld":"MANAGERISACTIVE"}]""");
         setEventMetadata("VALID_MANAGERGENDER",""","oparms":[{"av":"A332ManagerIsMainManager","fld":"MANAGERISMAINMANAGER"},{"av":"A365ManagerIsActive","fld":"MANAGERISACTIVE"}]}""");
         setEventMetadata("VALID_MANAGEREMAIL","""{"handler":"Valid_Manageremail","iparms":[{"av":"A332ManagerIsMainManager","fld":"MANAGERISMAINMANAGER"},{"av":"A365ManagerIsActive","fld":"MANAGERISACTIVE"}]""");
         setEventMetadata("VALID_MANAGEREMAIL",""","oparms":[{"av":"A332ManagerIsMainManager","fld":"MANAGERISMAINMANAGER"},{"av":"A365ManagerIsActive","fld":"MANAGERISACTIVE"}]}""");
         setEventMetadata("VALID_MANAGERPHONECODE","""{"handler":"Valid_Managerphonecode","iparms":[{"av":"A332ManagerIsMainManager","fld":"MANAGERISMAINMANAGER"},{"av":"A365ManagerIsActive","fld":"MANAGERISACTIVE"}]""");
         setEventMetadata("VALID_MANAGERPHONECODE",""","oparms":[{"av":"A332ManagerIsMainManager","fld":"MANAGERISMAINMANAGER"},{"av":"A365ManagerIsActive","fld":"MANAGERISACTIVE"}]}""");
         setEventMetadata("VALID_MANAGERPHONENUMBER","""{"handler":"Valid_Managerphonenumber","iparms":[{"av":"A357ManagerPhoneCode","fld":"MANAGERPHONECODE"},{"av":"A358ManagerPhoneNumber","fld":"MANAGERPHONENUMBER"},{"av":"A26ManagerPhone","fld":"MANAGERPHONE"},{"av":"A332ManagerIsMainManager","fld":"MANAGERISMAINMANAGER"},{"av":"A365ManagerIsActive","fld":"MANAGERISACTIVE"}]""");
         setEventMetadata("VALID_MANAGERPHONENUMBER",""","oparms":[{"av":"A26ManagerPhone","fld":"MANAGERPHONE"},{"av":"A332ManagerIsMainManager","fld":"MANAGERISMAINMANAGER"},{"av":"A365ManagerIsActive","fld":"MANAGERISACTIVE"}]}""");
         setEventMetadata("VALID_MANAGERISMAINMANAGER","""{"handler":"Valid_Managerismainmanager","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A332ManagerIsMainManager","fld":"MANAGERISMAINMANAGER"},{"av":"A365ManagerIsActive","fld":"MANAGERISACTIVE"}]""");
         setEventMetadata("VALID_MANAGERISMAINMANAGER",""","oparms":[{"av":"A332ManagerIsMainManager","fld":"MANAGERISMAINMANAGER"},{"av":"A365ManagerIsActive","fld":"MANAGERISACTIVE"}]}""");
         setEventMetadata("VALID_MANAGERISACTIVE","""{"handler":"Valid_Managerisactive","iparms":[{"av":"A332ManagerIsMainManager","fld":"MANAGERISMAINMANAGER"},{"av":"A365ManagerIsActive","fld":"MANAGERISACTIVE"}]""");
         setEventMetadata("VALID_MANAGERISACTIVE",""","oparms":[{"av":"A332ManagerIsMainManager","fld":"MANAGERISMAINMANAGER"},{"av":"A365ManagerIsActive","fld":"MANAGERISACTIVE"}]}""");
         setEventMetadata("VALIDV_COMBOMANAGERPHONECODE","""{"handler":"Validv_Combomanagerphonecode","iparms":[{"av":"A332ManagerIsMainManager","fld":"MANAGERISMAINMANAGER"},{"av":"A365ManagerIsActive","fld":"MANAGERISACTIVE"}]""");
         setEventMetadata("VALIDV_COMBOMANAGERPHONECODE",""","oparms":[{"av":"A332ManagerIsMainManager","fld":"MANAGERISMAINMANAGER"},{"av":"A365ManagerIsActive","fld":"MANAGERISACTIVE"}]}""");
         setEventMetadata("VALID_MANAGERID","""{"handler":"Valid_Managerid","iparms":[{"av":"A332ManagerIsMainManager","fld":"MANAGERISMAINMANAGER"},{"av":"A365ManagerIsActive","fld":"MANAGERISACTIVE"}]""");
         setEventMetadata("VALID_MANAGERID",""","oparms":[{"av":"A332ManagerIsMainManager","fld":"MANAGERISMAINMANAGER"},{"av":"A365ManagerIsActive","fld":"MANAGERISACTIVE"}]}""");
         setEventMetadata("VALID_ORGANISATIONID","""{"handler":"Valid_Organisationid","iparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A332ManagerIsMainManager","fld":"MANAGERISMAINMANAGER"},{"av":"A365ManagerIsActive","fld":"MANAGERISACTIVE"}]""");
         setEventMetadata("VALID_ORGANISATIONID",""","oparms":[{"av":"A332ManagerIsMainManager","fld":"MANAGERISMAINMANAGER"},{"av":"A365ManagerIsActive","fld":"MANAGERISACTIVE"}]}""");
         setEventMetadata("VALID_MANAGERGAMGUID","""{"handler":"Valid_Managergamguid","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"A28ManagerGAMGUID","fld":"MANAGERGAMGUID"},{"av":"AV32IsGAMActive","fld":"vISGAMACTIVE"},{"av":"A332ManagerIsMainManager","fld":"MANAGERISMAINMANAGER"},{"av":"A365ManagerIsActive","fld":"MANAGERISACTIVE"}]""");
         setEventMetadata("VALID_MANAGERGAMGUID",""","oparms":[{"ctrl":"BTNTRN_DELETE","prop":"Visible"},{"av":"AV32IsGAMActive","fld":"vISGAMACTIVE"},{"av":"chkManagerIsActive.Visible","ctrl":"MANAGERISACTIVE","prop":"Visible"},{"av":"divManagerisactive_cell_Class","ctrl":"MANAGERISACTIVE_CELL","prop":"Class"},{"av":"A332ManagerIsMainManager","fld":"MANAGERISMAINMANAGER"},{"av":"A365ManagerIsActive","fld":"MANAGERISACTIVE"}]}""");
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
         wcpOAV7ManagerId = Guid.Empty;
         wcpOAV8OrganisationId = Guid.Empty;
         Z21ManagerId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         Z357ManagerPhoneCode = "";
         Z24ManagerInitials = "";
         Z26ManagerPhone = "";
         Z22ManagerGivenName = "";
         Z23ManagerLastName = "";
         Z25ManagerEmail = "";
         Z358ManagerPhoneNumber = "";
         Z27ManagerGender = "";
         Z28ManagerGAMGUID = "";
         Combo_managerphonecode_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A25ManagerEmail = "";
         A22ManagerGivenName = "";
         A23ManagerLastName = "";
         A28ManagerGAMGUID = "";
         AV25GAMErrorResponse = "";
         A357ManagerPhoneCode = "";
         A358ManagerPhoneNumber = "";
         A446ManagerImage = "";
         A11OrganisationId = Guid.Empty;
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A27ManagerGender = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         lblPhone_Jsonclick = "";
         ucCombo_managerphonecode = new GXUserControl();
         AV15DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV28ManagerPhoneCode_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         gxphoneLink = "";
         A26ManagerPhone = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV26ComboManagerPhoneCode = "";
         A21ManagerId = Guid.Empty;
         A24ManagerInitials = "";
         AV30AuditingObject = new WorkWithPlus.workwithplus_web.SdtAuditingObject(context);
         A40000ManagerImage_GXI = "";
         AV35Pgmname = "";
         Combo_managerphonecode_Objectcall = "";
         Combo_managerphonecode_Class = "";
         Combo_managerphonecode_Icontype = "";
         Combo_managerphonecode_Icon = "";
         Combo_managerphonecode_Tooltip = "";
         Combo_managerphonecode_Selectedvalue_set = "";
         Combo_managerphonecode_Selectedtext_set = "";
         Combo_managerphonecode_Selectedtext_get = "";
         Combo_managerphonecode_Gamoauthtoken = "";
         Combo_managerphonecode_Ddointernalname = "";
         Combo_managerphonecode_Titlecontrolalign = "";
         Combo_managerphonecode_Dropdownoptionstype = "";
         Combo_managerphonecode_Titlecontrolidtoreplace = "";
         Combo_managerphonecode_Datalisttype = "";
         Combo_managerphonecode_Datalistfixedvalues = "";
         Combo_managerphonecode_Datalistproc = "";
         Combo_managerphonecode_Datalistprocparametersprefix = "";
         Combo_managerphonecode_Remoteservicesparameters = "";
         Combo_managerphonecode_Multiplevaluestype = "";
         Combo_managerphonecode_Loadingdata = "";
         Combo_managerphonecode_Noresultsfound = "";
         Combo_managerphonecode_Emptyitemtext = "";
         Combo_managerphonecode_Onlyselectedvalues = "";
         Combo_managerphonecode_Selectalltext = "";
         Combo_managerphonecode_Multiplevaluesseparator = "";
         Combo_managerphonecode_Addnewoptiontext = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode5 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV12TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV13WebSession = context.GetSession();
         AV27defaultCountryPhoneCode = "";
         GXt_objcol_SdtDVB_SDTComboData_Item3 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV16ComboSelectedValue = "";
         AV17ComboSelectedText = "";
         Z446ManagerImage = "";
         Z40000ManagerImage_GXI = "";
         T00035_A21ManagerId = new Guid[] {Guid.Empty} ;
         T00035_A357ManagerPhoneCode = new string[] {""} ;
         T00035_A24ManagerInitials = new string[] {""} ;
         T00035_A26ManagerPhone = new string[] {""} ;
         T00035_A22ManagerGivenName = new string[] {""} ;
         T00035_A23ManagerLastName = new string[] {""} ;
         T00035_A25ManagerEmail = new string[] {""} ;
         T00035_A358ManagerPhoneNumber = new string[] {""} ;
         T00035_A27ManagerGender = new string[] {""} ;
         T00035_A28ManagerGAMGUID = new string[] {""} ;
         T00035_A332ManagerIsMainManager = new bool[] {false} ;
         T00035_A365ManagerIsActive = new bool[] {false} ;
         T00035_A40000ManagerImage_GXI = new string[] {""} ;
         T00035_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00035_A446ManagerImage = new string[] {""} ;
         T00034_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00036_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00037_A21ManagerId = new Guid[] {Guid.Empty} ;
         T00037_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00033_A21ManagerId = new Guid[] {Guid.Empty} ;
         T00033_A357ManagerPhoneCode = new string[] {""} ;
         T00033_A24ManagerInitials = new string[] {""} ;
         T00033_A26ManagerPhone = new string[] {""} ;
         T00033_A22ManagerGivenName = new string[] {""} ;
         T00033_A23ManagerLastName = new string[] {""} ;
         T00033_A25ManagerEmail = new string[] {""} ;
         T00033_A358ManagerPhoneNumber = new string[] {""} ;
         T00033_A27ManagerGender = new string[] {""} ;
         T00033_A28ManagerGAMGUID = new string[] {""} ;
         T00033_A332ManagerIsMainManager = new bool[] {false} ;
         T00033_A365ManagerIsActive = new bool[] {false} ;
         T00033_A40000ManagerImage_GXI = new string[] {""} ;
         T00033_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00033_A446ManagerImage = new string[] {""} ;
         T00038_A21ManagerId = new Guid[] {Guid.Empty} ;
         T00038_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00039_A21ManagerId = new Guid[] {Guid.Empty} ;
         T00039_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00032_A21ManagerId = new Guid[] {Guid.Empty} ;
         T00032_A357ManagerPhoneCode = new string[] {""} ;
         T00032_A24ManagerInitials = new string[] {""} ;
         T00032_A26ManagerPhone = new string[] {""} ;
         T00032_A22ManagerGivenName = new string[] {""} ;
         T00032_A23ManagerLastName = new string[] {""} ;
         T00032_A25ManagerEmail = new string[] {""} ;
         T00032_A358ManagerPhoneNumber = new string[] {""} ;
         T00032_A27ManagerGender = new string[] {""} ;
         T00032_A28ManagerGAMGUID = new string[] {""} ;
         T00032_A332ManagerIsMainManager = new bool[] {false} ;
         T00032_A365ManagerIsActive = new bool[] {false} ;
         T00032_A40000ManagerImage_GXI = new string[] {""} ;
         T00032_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00032_A446ManagerImage = new string[] {""} ;
         T000314_A21ManagerId = new Guid[] {Guid.Empty} ;
         T000314_A11OrganisationId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T000315_A11OrganisationId = new Guid[] {Guid.Empty} ;
         GXt_char2 = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_manager__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_manager__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_manager__default(),
            new Object[][] {
                new Object[] {
               T00032_A21ManagerId, T00032_A357ManagerPhoneCode, T00032_A24ManagerInitials, T00032_A26ManagerPhone, T00032_A22ManagerGivenName, T00032_A23ManagerLastName, T00032_A25ManagerEmail, T00032_A358ManagerPhoneNumber, T00032_A27ManagerGender, T00032_A28ManagerGAMGUID,
               T00032_A332ManagerIsMainManager, T00032_A365ManagerIsActive, T00032_A40000ManagerImage_GXI, T00032_A11OrganisationId, T00032_A446ManagerImage
               }
               , new Object[] {
               T00033_A21ManagerId, T00033_A357ManagerPhoneCode, T00033_A24ManagerInitials, T00033_A26ManagerPhone, T00033_A22ManagerGivenName, T00033_A23ManagerLastName, T00033_A25ManagerEmail, T00033_A358ManagerPhoneNumber, T00033_A27ManagerGender, T00033_A28ManagerGAMGUID,
               T00033_A332ManagerIsMainManager, T00033_A365ManagerIsActive, T00033_A40000ManagerImage_GXI, T00033_A11OrganisationId, T00033_A446ManagerImage
               }
               , new Object[] {
               T00034_A11OrganisationId
               }
               , new Object[] {
               T00035_A21ManagerId, T00035_A357ManagerPhoneCode, T00035_A24ManagerInitials, T00035_A26ManagerPhone, T00035_A22ManagerGivenName, T00035_A23ManagerLastName, T00035_A25ManagerEmail, T00035_A358ManagerPhoneNumber, T00035_A27ManagerGender, T00035_A28ManagerGAMGUID,
               T00035_A332ManagerIsMainManager, T00035_A365ManagerIsActive, T00035_A40000ManagerImage_GXI, T00035_A11OrganisationId, T00035_A446ManagerImage
               }
               , new Object[] {
               T00036_A11OrganisationId
               }
               , new Object[] {
               T00037_A21ManagerId, T00037_A11OrganisationId
               }
               , new Object[] {
               T00038_A21ManagerId, T00038_A11OrganisationId
               }
               , new Object[] {
               T00039_A21ManagerId, T00039_A11OrganisationId
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
               T000314_A21ManagerId, T000314_A11OrganisationId
               }
               , new Object[] {
               T000315_A11OrganisationId
               }
            }
         );
         Z332ManagerIsMainManager = false;
         A332ManagerIsMainManager = false;
         i332ManagerIsMainManager = false;
         Z21ManagerId = Guid.NewGuid( );
         A21ManagerId = Guid.NewGuid( );
         AV35Pgmname = "Trn_Manager";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound5 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtManagerGivenName_Enabled ;
      private int edtManagerLastName_Enabled ;
      private int edtManagerEmail_Enabled ;
      private int divUnnamedtable2_Visible ;
      private int edtManagerPhoneCode_Visible ;
      private int edtManagerPhoneCode_Enabled ;
      private int edtManagerPhoneNumber_Enabled ;
      private int edtManagerPhone_Visible ;
      private int edtManagerPhone_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavCombomanagerphonecode_Visible ;
      private int edtavCombomanagerphonecode_Enabled ;
      private int edtManagerId_Visible ;
      private int edtManagerId_Enabled ;
      private int edtOrganisationId_Visible ;
      private int edtOrganisationId_Enabled ;
      private int edtManagerInitials_Visible ;
      private int edtManagerInitials_Enabled ;
      private int edtManagerGAMGUID_Visible ;
      private int edtManagerGAMGUID_Enabled ;
      private int Combo_managerphonecode_Datalistupdateminimumcharacters ;
      private int Combo_managerphonecode_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z24ManagerInitials ;
      private string Z26ManagerPhone ;
      private string Combo_managerphonecode_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string GXDecQS ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtManagerGivenName_Internalname ;
      private string cmbManagerGender_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtManagerGivenName_Jsonclick ;
      private string edtManagerLastName_Internalname ;
      private string edtManagerLastName_Jsonclick ;
      private string cmbManagerGender_Jsonclick ;
      private string edtManagerEmail_Internalname ;
      private string edtManagerEmail_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string lblPhone_Internalname ;
      private string lblPhone_Jsonclick ;
      private string divUnnamedtable3_Internalname ;
      private string divUnnamedtable4_Internalname ;
      private string divUnnamedtablemanagerphonecode_Internalname ;
      private string Combo_managerphonecode_Caption ;
      private string Combo_managerphonecode_Cls ;
      private string Combo_managerphonecode_Internalname ;
      private string edtManagerPhoneCode_Internalname ;
      private string edtManagerPhoneCode_Jsonclick ;
      private string edtManagerPhoneNumber_Internalname ;
      private string edtManagerPhoneNumber_Jsonclick ;
      private string divManagerphone_cell_Internalname ;
      private string divManagerphone_cell_Class ;
      private string edtManagerPhone_Internalname ;
      private string gxphoneLink ;
      private string A26ManagerPhone ;
      private string edtManagerPhone_Jsonclick ;
      private string chkManagerIsMainManager_Internalname ;
      private string divManagerisactive_cell_Internalname ;
      private string divManagerisactive_cell_Class ;
      private string chkManagerIsActive_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_managerphonecode_Internalname ;
      private string edtavCombomanagerphonecode_Internalname ;
      private string edtavCombomanagerphonecode_Jsonclick ;
      private string edtManagerId_Internalname ;
      private string edtManagerId_Jsonclick ;
      private string edtOrganisationId_Internalname ;
      private string edtOrganisationId_Jsonclick ;
      private string edtManagerInitials_Internalname ;
      private string A24ManagerInitials ;
      private string edtManagerInitials_Jsonclick ;
      private string edtManagerGAMGUID_Internalname ;
      private string edtManagerGAMGUID_Jsonclick ;
      private string AV35Pgmname ;
      private string Combo_managerphonecode_Objectcall ;
      private string Combo_managerphonecode_Class ;
      private string Combo_managerphonecode_Icontype ;
      private string Combo_managerphonecode_Icon ;
      private string Combo_managerphonecode_Tooltip ;
      private string Combo_managerphonecode_Selectedvalue_set ;
      private string Combo_managerphonecode_Selectedtext_set ;
      private string Combo_managerphonecode_Selectedtext_get ;
      private string Combo_managerphonecode_Gamoauthtoken ;
      private string Combo_managerphonecode_Ddointernalname ;
      private string Combo_managerphonecode_Titlecontrolalign ;
      private string Combo_managerphonecode_Dropdownoptionstype ;
      private string Combo_managerphonecode_Titlecontrolidtoreplace ;
      private string Combo_managerphonecode_Datalisttype ;
      private string Combo_managerphonecode_Datalistfixedvalues ;
      private string Combo_managerphonecode_Datalistproc ;
      private string Combo_managerphonecode_Datalistprocparametersprefix ;
      private string Combo_managerphonecode_Remoteservicesparameters ;
      private string Combo_managerphonecode_Htmltemplate ;
      private string Combo_managerphonecode_Multiplevaluestype ;
      private string Combo_managerphonecode_Loadingdata ;
      private string Combo_managerphonecode_Noresultsfound ;
      private string Combo_managerphonecode_Emptyitemtext ;
      private string Combo_managerphonecode_Onlyselectedvalues ;
      private string Combo_managerphonecode_Selectalltext ;
      private string Combo_managerphonecode_Multiplevaluesseparator ;
      private string Combo_managerphonecode_Addnewoptiontext ;
      private string hsh ;
      private string sMode5 ;
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
      private string GXt_char2 ;
      private bool Z332ManagerIsMainManager ;
      private bool Z365ManagerIsActive ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool A365ManagerIsActive ;
      private bool wbErr ;
      private bool A332ManagerIsMainManager ;
      private bool Combo_managerphonecode_Emptyitem ;
      private bool AV32IsGAMActive ;
      private bool Combo_managerphonecode_Enabled ;
      private bool Combo_managerphonecode_Visible ;
      private bool Combo_managerphonecode_Allowmultipleselection ;
      private bool Combo_managerphonecode_Isgriditem ;
      private bool Combo_managerphonecode_Hasdescription ;
      private bool Combo_managerphonecode_Includeonlyselectedoption ;
      private bool Combo_managerphonecode_Includeselectalloption ;
      private bool Combo_managerphonecode_Includeaddnewoption ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool i332ManagerIsMainManager ;
      private bool GXt_boolean4 ;
      private bool ZV32IsGAMActive ;
      private string AV25GAMErrorResponse ;
      private string Z357ManagerPhoneCode ;
      private string Z22ManagerGivenName ;
      private string Z23ManagerLastName ;
      private string Z25ManagerEmail ;
      private string Z358ManagerPhoneNumber ;
      private string Z27ManagerGender ;
      private string Z28ManagerGAMGUID ;
      private string A25ManagerEmail ;
      private string A22ManagerGivenName ;
      private string A23ManagerLastName ;
      private string A28ManagerGAMGUID ;
      private string A357ManagerPhoneCode ;
      private string A358ManagerPhoneNumber ;
      private string A27ManagerGender ;
      private string AV26ComboManagerPhoneCode ;
      private string A40000ManagerImage_GXI ;
      private string AV27defaultCountryPhoneCode ;
      private string AV16ComboSelectedValue ;
      private string AV17ComboSelectedText ;
      private string Z40000ManagerImage_GXI ;
      private string A446ManagerImage ;
      private string Z446ManagerImage ;
      private Guid wcpOAV7ManagerId ;
      private Guid wcpOAV8OrganisationId ;
      private Guid Z21ManagerId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid AV7ManagerId ;
      private Guid AV8OrganisationId ;
      private Guid A21ManagerId ;
      private IGxSession AV13WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucCombo_managerphonecode ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbManagerGender ;
      private GXCheckbox chkManagerIsMainManager ;
      private GXCheckbox chkManagerIsActive ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV15DDO_TitleSettingsIcons ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV28ManagerPhoneCode_Data ;
      private WorkWithPlus.workwithplus_web.SdtAuditingObject AV30AuditingObject ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV12TrnContext ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> GXt_objcol_SdtDVB_SDTComboData_Item3 ;
      private IDataStoreProvider pr_default ;
      private Guid[] T00035_A21ManagerId ;
      private string[] T00035_A357ManagerPhoneCode ;
      private string[] T00035_A24ManagerInitials ;
      private string[] T00035_A26ManagerPhone ;
      private string[] T00035_A22ManagerGivenName ;
      private string[] T00035_A23ManagerLastName ;
      private string[] T00035_A25ManagerEmail ;
      private string[] T00035_A358ManagerPhoneNumber ;
      private string[] T00035_A27ManagerGender ;
      private string[] T00035_A28ManagerGAMGUID ;
      private bool[] T00035_A332ManagerIsMainManager ;
      private bool[] T00035_A365ManagerIsActive ;
      private string[] T00035_A40000ManagerImage_GXI ;
      private Guid[] T00035_A11OrganisationId ;
      private string[] T00035_A446ManagerImage ;
      private Guid[] T00034_A11OrganisationId ;
      private Guid[] T00036_A11OrganisationId ;
      private Guid[] T00037_A21ManagerId ;
      private Guid[] T00037_A11OrganisationId ;
      private Guid[] T00033_A21ManagerId ;
      private string[] T00033_A357ManagerPhoneCode ;
      private string[] T00033_A24ManagerInitials ;
      private string[] T00033_A26ManagerPhone ;
      private string[] T00033_A22ManagerGivenName ;
      private string[] T00033_A23ManagerLastName ;
      private string[] T00033_A25ManagerEmail ;
      private string[] T00033_A358ManagerPhoneNumber ;
      private string[] T00033_A27ManagerGender ;
      private string[] T00033_A28ManagerGAMGUID ;
      private bool[] T00033_A332ManagerIsMainManager ;
      private bool[] T00033_A365ManagerIsActive ;
      private string[] T00033_A40000ManagerImage_GXI ;
      private Guid[] T00033_A11OrganisationId ;
      private string[] T00033_A446ManagerImage ;
      private Guid[] T00038_A21ManagerId ;
      private Guid[] T00038_A11OrganisationId ;
      private Guid[] T00039_A21ManagerId ;
      private Guid[] T00039_A11OrganisationId ;
      private Guid[] T00032_A21ManagerId ;
      private string[] T00032_A357ManagerPhoneCode ;
      private string[] T00032_A24ManagerInitials ;
      private string[] T00032_A26ManagerPhone ;
      private string[] T00032_A22ManagerGivenName ;
      private string[] T00032_A23ManagerLastName ;
      private string[] T00032_A25ManagerEmail ;
      private string[] T00032_A358ManagerPhoneNumber ;
      private string[] T00032_A27ManagerGender ;
      private string[] T00032_A28ManagerGAMGUID ;
      private bool[] T00032_A332ManagerIsMainManager ;
      private bool[] T00032_A365ManagerIsActive ;
      private string[] T00032_A40000ManagerImage_GXI ;
      private Guid[] T00032_A11OrganisationId ;
      private string[] T00032_A446ManagerImage ;
      private Guid[] T000314_A21ManagerId ;
      private Guid[] T000314_A11OrganisationId ;
      private Guid[] T000315_A11OrganisationId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_manager__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_manager__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_manager__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[11])
      ,new ForEachCursor(def[12])
      ,new ForEachCursor(def[13])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT00032;
       prmT00032 = new Object[] {
       new ParDef("ManagerId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00033;
       prmT00033 = new Object[] {
       new ParDef("ManagerId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00034;
       prmT00034 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00035;
       prmT00035 = new Object[] {
       new ParDef("ManagerId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00036;
       prmT00036 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00037;
       prmT00037 = new Object[] {
       new ParDef("ManagerId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00038;
       prmT00038 = new Object[] {
       new ParDef("ManagerId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00039;
       prmT00039 = new Object[] {
       new ParDef("ManagerId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000310;
       prmT000310 = new Object[] {
       new ParDef("ManagerId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ManagerPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("ManagerInitials",GXType.Char,20,0) ,
       new ParDef("ManagerPhone",GXType.Char,20,0) ,
       new ParDef("ManagerGivenName",GXType.VarChar,100,0) ,
       new ParDef("ManagerLastName",GXType.VarChar,100,0) ,
       new ParDef("ManagerEmail",GXType.VarChar,100,0) ,
       new ParDef("ManagerPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("ManagerGender",GXType.VarChar,40,0) ,
       new ParDef("ManagerGAMGUID",GXType.VarChar,100,60) ,
       new ParDef("ManagerIsMainManager",GXType.Boolean,4,0) ,
       new ParDef("ManagerIsActive",GXType.Boolean,4,0) ,
       new ParDef("ManagerImage",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("ManagerImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=12, Tbl="Trn_Manager", Fld="ManagerImage"} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000311;
       prmT000311 = new Object[] {
       new ParDef("ManagerPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("ManagerInitials",GXType.Char,20,0) ,
       new ParDef("ManagerPhone",GXType.Char,20,0) ,
       new ParDef("ManagerGivenName",GXType.VarChar,100,0) ,
       new ParDef("ManagerLastName",GXType.VarChar,100,0) ,
       new ParDef("ManagerEmail",GXType.VarChar,100,0) ,
       new ParDef("ManagerPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("ManagerGender",GXType.VarChar,40,0) ,
       new ParDef("ManagerGAMGUID",GXType.VarChar,100,60) ,
       new ParDef("ManagerIsMainManager",GXType.Boolean,4,0) ,
       new ParDef("ManagerIsActive",GXType.Boolean,4,0) ,
       new ParDef("ManagerId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000312;
       prmT000312 = new Object[] {
       new ParDef("ManagerImage",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("ManagerImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Trn_Manager", Fld="ManagerImage"} ,
       new ParDef("ManagerId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000313;
       prmT000313 = new Object[] {
       new ParDef("ManagerId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000314;
       prmT000314 = new Object[] {
       };
       Object[] prmT000315;
       prmT000315 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("T00032", "SELECT ManagerId, ManagerPhoneCode, ManagerInitials, ManagerPhone, ManagerGivenName, ManagerLastName, ManagerEmail, ManagerPhoneNumber, ManagerGender, ManagerGAMGUID, ManagerIsMainManager, ManagerIsActive, ManagerImage_GXI, OrganisationId, ManagerImage FROM Trn_Manager WHERE ManagerId = :ManagerId AND OrganisationId = :OrganisationId  FOR UPDATE OF Trn_Manager NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00032,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00033", "SELECT ManagerId, ManagerPhoneCode, ManagerInitials, ManagerPhone, ManagerGivenName, ManagerLastName, ManagerEmail, ManagerPhoneNumber, ManagerGender, ManagerGAMGUID, ManagerIsMainManager, ManagerIsActive, ManagerImage_GXI, OrganisationId, ManagerImage FROM Trn_Manager WHERE ManagerId = :ManagerId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00033,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00034", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00034,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00035", "SELECT TM1.ManagerId, TM1.ManagerPhoneCode, TM1.ManagerInitials, TM1.ManagerPhone, TM1.ManagerGivenName, TM1.ManagerLastName, TM1.ManagerEmail, TM1.ManagerPhoneNumber, TM1.ManagerGender, TM1.ManagerGAMGUID, TM1.ManagerIsMainManager, TM1.ManagerIsActive, TM1.ManagerImage_GXI, TM1.OrganisationId, TM1.ManagerImage FROM Trn_Manager TM1 WHERE TM1.ManagerId = :ManagerId and TM1.OrganisationId = :OrganisationId ORDER BY TM1.ManagerId, TM1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00035,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00036", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00036,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00037", "SELECT ManagerId, OrganisationId FROM Trn_Manager WHERE ManagerId = :ManagerId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00037,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00038", "SELECT ManagerId, OrganisationId FROM Trn_Manager WHERE ( ManagerId > :ManagerId or ManagerId = :ManagerId and OrganisationId > :OrganisationId) ORDER BY ManagerId, OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00038,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T00039", "SELECT ManagerId, OrganisationId FROM Trn_Manager WHERE ( ManagerId < :ManagerId or ManagerId = :ManagerId and OrganisationId < :OrganisationId) ORDER BY ManagerId DESC, OrganisationId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT00039,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000310", "SAVEPOINT gxupdate;INSERT INTO Trn_Manager(ManagerId, ManagerPhoneCode, ManagerInitials, ManagerPhone, ManagerGivenName, ManagerLastName, ManagerEmail, ManagerPhoneNumber, ManagerGender, ManagerGAMGUID, ManagerIsMainManager, ManagerIsActive, ManagerImage, ManagerImage_GXI, OrganisationId) VALUES(:ManagerId, :ManagerPhoneCode, :ManagerInitials, :ManagerPhone, :ManagerGivenName, :ManagerLastName, :ManagerEmail, :ManagerPhoneNumber, :ManagerGender, :ManagerGAMGUID, :ManagerIsMainManager, :ManagerIsActive, :ManagerImage, :ManagerImage_GXI, :OrganisationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000310)
          ,new CursorDef("T000311", "SAVEPOINT gxupdate;UPDATE Trn_Manager SET ManagerPhoneCode=:ManagerPhoneCode, ManagerInitials=:ManagerInitials, ManagerPhone=:ManagerPhone, ManagerGivenName=:ManagerGivenName, ManagerLastName=:ManagerLastName, ManagerEmail=:ManagerEmail, ManagerPhoneNumber=:ManagerPhoneNumber, ManagerGender=:ManagerGender, ManagerGAMGUID=:ManagerGAMGUID, ManagerIsMainManager=:ManagerIsMainManager, ManagerIsActive=:ManagerIsActive  WHERE ManagerId = :ManagerId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000311)
          ,new CursorDef("T000312", "SAVEPOINT gxupdate;UPDATE Trn_Manager SET ManagerImage=:ManagerImage, ManagerImage_GXI=:ManagerImage_GXI  WHERE ManagerId = :ManagerId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000312)
          ,new CursorDef("T000313", "SAVEPOINT gxupdate;DELETE FROM Trn_Manager  WHERE ManagerId = :ManagerId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000313)
          ,new CursorDef("T000314", "SELECT ManagerId, OrganisationId FROM Trn_Manager ORDER BY ManagerId, OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000314,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000315", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000315,1, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[3])[0] = rslt.getString(4, 20);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((bool[]) buf[10])[0] = rslt.getBool(11);
             ((bool[]) buf[11])[0] = rslt.getBool(12);
             ((string[]) buf[12])[0] = rslt.getMultimediaUri(13);
             ((Guid[]) buf[13])[0] = rslt.getGuid(14);
             ((string[]) buf[14])[0] = rslt.getMultimediaFile(15, rslt.getVarchar(13));
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((string[]) buf[3])[0] = rslt.getString(4, 20);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((bool[]) buf[10])[0] = rslt.getBool(11);
             ((bool[]) buf[11])[0] = rslt.getBool(12);
             ((string[]) buf[12])[0] = rslt.getMultimediaUri(13);
             ((Guid[]) buf[13])[0] = rslt.getGuid(14);
             ((string[]) buf[14])[0] = rslt.getMultimediaFile(15, rslt.getVarchar(13));
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((string[]) buf[3])[0] = rslt.getString(4, 20);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((bool[]) buf[10])[0] = rslt.getBool(11);
             ((bool[]) buf[11])[0] = rslt.getBool(12);
             ((string[]) buf[12])[0] = rslt.getMultimediaUri(13);
             ((Guid[]) buf[13])[0] = rslt.getGuid(14);
             ((string[]) buf[14])[0] = rslt.getMultimediaFile(15, rslt.getVarchar(13));
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 6 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 12 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 13 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
