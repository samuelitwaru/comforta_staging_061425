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
   public class trn_receptionist : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action33") == 0 )
         {
            A93ReceptionistEmail = GetPar( "ReceptionistEmail");
            AssignAttri("", false, "A93ReceptionistEmail", A93ReceptionistEmail);
            A90ReceptionistGivenName = GetPar( "ReceptionistGivenName");
            AssignAttri("", false, "A90ReceptionistGivenName", A90ReceptionistGivenName);
            A91ReceptionistLastName = GetPar( "ReceptionistLastName");
            AssignAttri("", false, "A91ReceptionistLastName", A91ReceptionistLastName);
            A95ReceptionistGAMGUID = GetPar( "ReceptionistGAMGUID");
            AssignAttri("", false, "A95ReceptionistGAMGUID", A95ReceptionistGAMGUID);
            AV14GAMErrorResponse = GetPar( "GAMErrorResponse");
            AssignAttri("", false, "AV14GAMErrorResponse", AV14GAMErrorResponse);
            Gx_mode = GetPar( "Mode");
            AssignAttri("", false, "Gx_mode", Gx_mode);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_33_0C63( A93ReceptionistEmail, A90ReceptionistGivenName, A91ReceptionistLastName, A95ReceptionistGAMGUID, AV14GAMErrorResponse, Gx_mode) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action35") == 0 )
         {
            A90ReceptionistGivenName = GetPar( "ReceptionistGivenName");
            AssignAttri("", false, "A90ReceptionistGivenName", A90ReceptionistGivenName);
            A91ReceptionistLastName = GetPar( "ReceptionistLastName");
            AssignAttri("", false, "A91ReceptionistLastName", A91ReceptionistLastName);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_35_0C63( A90ReceptionistGivenName, A91ReceptionistLastName) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action36") == 0 )
         {
            Gx_mode = GetPar( "Mode");
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A95ReceptionistGAMGUID = GetPar( "ReceptionistGAMGUID");
            AssignAttri("", false, "A95ReceptionistGAMGUID", A95ReceptionistGAMGUID);
            A90ReceptionistGivenName = GetPar( "ReceptionistGivenName");
            AssignAttri("", false, "A90ReceptionistGivenName", A90ReceptionistGivenName);
            A91ReceptionistLastName = GetPar( "ReceptionistLastName");
            AssignAttri("", false, "A91ReceptionistLastName", A91ReceptionistLastName);
            A345ReceptionistPhoneCode = GetPar( "ReceptionistPhoneCode");
            AssignAttri("", false, "A345ReceptionistPhoneCode", A345ReceptionistPhoneCode);
            A346ReceptionistPhoneNumber = GetPar( "ReceptionistPhoneNumber");
            AssignAttri("", false, "A346ReceptionistPhoneNumber", A346ReceptionistPhoneNumber);
            A447ReceptionistImage = GetPar( "ReceptionistImage");
            AssignAttri("", false, "A447ReceptionistImage", A447ReceptionistImage);
            A369ReceptionistIsActive = StringUtil.StrToBool( GetPar( "ReceptionistIsActive"));
            AssignAttri("", false, "A369ReceptionistIsActive", A369ReceptionistIsActive);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_36_0C63( Gx_mode, A95ReceptionistGAMGUID, A90ReceptionistGivenName, A91ReceptionistLastName, A345ReceptionistPhoneCode, A346ReceptionistPhoneNumber, A447ReceptionistImage, A369ReceptionistIsActive) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action38") == 0 )
         {
            Gx_mode = GetPar( "Mode");
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A95ReceptionistGAMGUID = GetPar( "ReceptionistGAMGUID");
            AssignAttri("", false, "A95ReceptionistGAMGUID", A95ReceptionistGAMGUID);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_38_0C63( Gx_mode, A95ReceptionistGAMGUID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"LOCATIONID") == 0 )
         {
            AV21OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
            AssignAttri("", false, "AV21OrganisationId", AV21OrganisationId.ToString());
            GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV21OrganisationId, context));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLALOCATIONID0C63( AV21OrganisationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel7"+"_"+"ORGANISATIONID") == 0 )
         {
            AV21OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
            AssignAttri("", false, "AV21OrganisationId", AV21OrganisationId.ToString());
            GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV21OrganisationId, context));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX7ASAORGANISATIONID0C63( AV21OrganisationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel18"+"_"+"RECEPTIONISTPHONE") == 0 )
         {
            A345ReceptionistPhoneCode = GetPar( "ReceptionistPhoneCode");
            AssignAttri("", false, "A345ReceptionistPhoneCode", A345ReceptionistPhoneCode);
            A346ReceptionistPhoneNumber = GetPar( "ReceptionistPhoneNumber");
            AssignAttri("", false, "A346ReceptionistPhoneNumber", A346ReceptionistPhoneNumber);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX18ASARECEPTIONISTPHONE0C63( A345ReceptionistPhoneCode, A346ReceptionistPhoneNumber) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel19"+"_"+"vISGAMACTIVE") == 0 )
         {
            A95ReceptionistGAMGUID = GetPar( "ReceptionistGAMGUID");
            AssignAttri("", false, "A95ReceptionistGAMGUID", A95ReceptionistGAMGUID);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX19ASAISGAMACTIVE0C63( A95ReceptionistGAMGUID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_43") == 0 )
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
            gxLoad_43( A29LocationId, A11OrganisationId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_receptionist.aspx")), "trn_receptionist.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_receptionist.aspx")))) ;
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
                  AV23ReceptionistId = StringUtil.StrToGuid( GetPar( "ReceptionistId"));
                  AssignAttri("", false, "AV23ReceptionistId", AV23ReceptionistId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vRECEPTIONISTID", GetSecureSignedToken( "", AV23ReceptionistId, context));
                  AV21OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  AssignAttri("", false, "AV21OrganisationId", AV21OrganisationId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV21OrganisationId, context));
                  AV19LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
                  AssignAttri("", false, "AV19LocationId", AV19LocationId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", AV19LocationId, context));
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
         Form.Meta.addItem("description", context.GetMessage( "Receptionist", ""), 0) ;
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

      public trn_receptionist( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_receptionist( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_ReceptionistId ,
                           Guid aP2_OrganisationId ,
                           Guid aP3_LocationId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV23ReceptionistId = aP1_ReceptionistId;
         this.AV21OrganisationId = aP2_OrganisationId;
         this.AV19LocationId = aP3_LocationId;
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
         chkReceptionistIsActive = new GXCheckbox();
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
            return "trn_receptionist_Execute" ;
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
         A369ReceptionistIsActive = StringUtil.StrToBool( StringUtil.BoolToStr( A369ReceptionistIsActive));
         AssignAttri("", false, "A369ReceptionistIsActive", A369ReceptionistIsActive);
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
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_Receptionist.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynLocationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynLocationId_Internalname, context.GetMessage( "Location Id", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynLocationId, dynLocationId_Internalname, A29LocationId.ToString(), 1, dynLocationId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "guid", "", 1, dynLocationId.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "", true, 0, "HLP_Trn_Receptionist.htm");
         dynLocationId.CurrentValue = A29LocationId.ToString();
         AssignProp("", false, dynLocationId_Internalname, "Values", (string)(dynLocationId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReceptionistGivenName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReceptionistGivenName_Internalname, context.GetMessage( "First Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReceptionistGivenName_Internalname, A90ReceptionistGivenName, StringUtil.RTrim( context.localUtil.Format( A90ReceptionistGivenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReceptionistGivenName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReceptionistGivenName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_Receptionist.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReceptionistLastName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReceptionistLastName_Internalname, context.GetMessage( "Last Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReceptionistLastName_Internalname, A91ReceptionistLastName, StringUtil.RTrim( context.localUtil.Format( A91ReceptionistLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReceptionistLastName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReceptionistLastName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_Receptionist.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReceptionistEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReceptionistEmail_Internalname, context.GetMessage( "Email", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReceptionistEmail_Internalname, A93ReceptionistEmail, StringUtil.RTrim( context.localUtil.Format( A93ReceptionistEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A93ReceptionistEmail, "", "", "", edtReceptionistEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReceptionistEmail_Enabled, 1, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Trn_Receptionist.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divReceptionistphone_cell_Internalname, 1, 0, "px", 0, "px", divReceptionistphone_cell_Class, "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", edtReceptionistPhone_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReceptionistPhone_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReceptionistPhone_Internalname, context.GetMessage( "Phone", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A94ReceptionistPhone);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReceptionistPhone_Internalname, StringUtil.RTrim( A94ReceptionistPhone), StringUtil.RTrim( context.localUtil.Format( A94ReceptionistPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtReceptionistPhone_Jsonclick, 0, "Attribute", "", "", "", "", edtReceptionistPhone_Visible, edtReceptionistPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Trn_Receptionist.htm");
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
         GxWebStd.gx_label_ctrl( context, lblPhone_Internalname, context.GetMessage( "Phone", ""), "", "", lblPhone_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_Trn_Receptionist.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTable_Internalname, 1, 0, "px", 0, "px", divTable_Class, "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 PhoneLabel ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablereceptionistphonecode_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_receptionistphonecode.SetProperty("Caption", Combo_receptionistphonecode_Caption);
         ucCombo_receptionistphonecode.SetProperty("Cls", Combo_receptionistphonecode_Cls);
         ucCombo_receptionistphonecode.SetProperty("EmptyItem", Combo_receptionistphonecode_Emptyitem);
         ucCombo_receptionistphonecode.SetProperty("DropDownOptionsTitleSettingsIcons", AV13DDO_TitleSettingsIcons);
         ucCombo_receptionistphonecode.SetProperty("DropDownOptionsData", AV34ReceptionistPhoneCode_Data);
         ucCombo_receptionistphonecode.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_receptionistphonecode_Internalname, "COMBO_RECEPTIONISTPHONECODEContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReceptionistPhoneCode_Internalname, context.GetMessage( "Receptionist Phone Code", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReceptionistPhoneCode_Internalname, A345ReceptionistPhoneCode, StringUtil.RTrim( context.localUtil.Format( A345ReceptionistPhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReceptionistPhoneCode_Jsonclick, 0, "Attribute", "", "", "", "", edtReceptionistPhoneCode_Visible, edtReceptionistPhoneCode_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Receptionist.htm");
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
         GxWebStd.gx_label_element( context, edtReceptionistPhoneNumber_Internalname, context.GetMessage( "Receptionist Phone Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReceptionistPhoneNumber_Internalname, A346ReceptionistPhoneNumber, StringUtil.RTrim( context.localUtil.Format( A346ReceptionistPhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReceptionistPhoneNumber_Jsonclick, 0, edtReceptionistPhoneNumber_Class, "", "", "", "", 1, edtReceptionistPhoneNumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Receptionist.htm");
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
         GxWebStd.gx_div_start( context, divReceptionistisactive_cell_Internalname, 1, 0, "px", 0, "px", divReceptionistisactive_cell_Class, "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", chkReceptionistIsActive.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkReceptionistIsActive_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkReceptionistIsActive_Internalname, context.GetMessage( "Is Active", ""), "col-sm-4 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkReceptionistIsActive_Internalname, StringUtil.BoolToStr( A369ReceptionistIsActive), "", context.GetMessage( "Is Active", ""), chkReceptionistIsActive.Visible, chkReceptionistIsActive.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(70, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,70);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Receptionist.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Receptionist.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Receptionist.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_receptionistphonecode_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboreceptionistphonecode_Internalname, AV31ComboReceptionistPhoneCode, StringUtil.RTrim( context.localUtil.Format( AV31ComboReceptionistPhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboreceptionistphonecode_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboreceptionistphonecode_Visible, edtavComboreceptionistphonecode_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Receptionist.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReceptionistId_Internalname, A89ReceptionistId.ToString(), A89ReceptionistId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReceptionistId_Jsonclick, 0, "Attribute", "", "", "", "", edtReceptionistId_Visible, edtReceptionistId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Receptionist.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationId_Internalname, A11OrganisationId.ToString(), A11OrganisationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationId_Jsonclick, 0, "Attribute", "", "", "", "", edtOrganisationId_Visible, edtOrganisationId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Receptionist.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReceptionistInitials_Internalname, StringUtil.RTrim( A92ReceptionistInitials), StringUtil.RTrim( context.localUtil.Format( A92ReceptionistInitials, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReceptionistInitials_Jsonclick, 0, "Attribute", "", "", "", "", edtReceptionistInitials_Visible, edtReceptionistInitials_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Receptionist.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReceptionistGAMGUID_Internalname, A95ReceptionistGAMGUID, StringUtil.RTrim( context.localUtil.Format( A95ReceptionistGAMGUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReceptionistGAMGUID_Jsonclick, 0, "Attribute", "", "", "", "", edtReceptionistGAMGUID_Visible, edtReceptionistGAMGUID_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_Trn_Receptionist.htm");
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
         E110C2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV13DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vRECEPTIONISTPHONECODE_DATA"), AV34ReceptionistPhoneCode_Data);
               /* Read saved values. */
               Z89ReceptionistId = StringUtil.StrToGuid( cgiGet( "Z89ReceptionistId"));
               Z11OrganisationId = StringUtil.StrToGuid( cgiGet( "Z11OrganisationId"));
               Z29LocationId = StringUtil.StrToGuid( cgiGet( "Z29LocationId"));
               Z345ReceptionistPhoneCode = cgiGet( "Z345ReceptionistPhoneCode");
               Z92ReceptionistInitials = cgiGet( "Z92ReceptionistInitials");
               Z94ReceptionistPhone = cgiGet( "Z94ReceptionistPhone");
               Z90ReceptionistGivenName = cgiGet( "Z90ReceptionistGivenName");
               Z91ReceptionistLastName = cgiGet( "Z91ReceptionistLastName");
               Z93ReceptionistEmail = cgiGet( "Z93ReceptionistEmail");
               Z346ReceptionistPhoneNumber = cgiGet( "Z346ReceptionistPhoneNumber");
               Z95ReceptionistGAMGUID = cgiGet( "Z95ReceptionistGAMGUID");
               Z369ReceptionistIsActive = StringUtil.StrToBool( cgiGet( "Z369ReceptionistIsActive"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV23ReceptionistId = StringUtil.StrToGuid( cgiGet( "vRECEPTIONISTID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV21OrganisationId = StringUtil.StrToGuid( cgiGet( "vORGANISATIONID"));
               AV19LocationId = StringUtil.StrToGuid( cgiGet( "vLOCATIONID"));
               AV14GAMErrorResponse = cgiGet( "vGAMERRORRESPONSE");
               AV37IsGAMActive = StringUtil.StrToBool( cgiGet( "vISGAMACTIVE"));
               ajax_req_read_hidden_sdt(cgiGet( "vAUDITINGOBJECT"), AV36AuditingObject);
               Gx_mode = cgiGet( "vMODE");
               A447ReceptionistImage = cgiGet( "RECEPTIONISTIMAGE");
               A40000ReceptionistImage_GXI = cgiGet( "RECEPTIONISTIMAGE_GXI");
               AV42Pgmname = cgiGet( "vPGMNAME");
               Combo_receptionistphonecode_Objectcall = cgiGet( "COMBO_RECEPTIONISTPHONECODE_Objectcall");
               Combo_receptionistphonecode_Class = cgiGet( "COMBO_RECEPTIONISTPHONECODE_Class");
               Combo_receptionistphonecode_Icontype = cgiGet( "COMBO_RECEPTIONISTPHONECODE_Icontype");
               Combo_receptionistphonecode_Icon = cgiGet( "COMBO_RECEPTIONISTPHONECODE_Icon");
               Combo_receptionistphonecode_Caption = cgiGet( "COMBO_RECEPTIONISTPHONECODE_Caption");
               Combo_receptionistphonecode_Tooltip = cgiGet( "COMBO_RECEPTIONISTPHONECODE_Tooltip");
               Combo_receptionistphonecode_Cls = cgiGet( "COMBO_RECEPTIONISTPHONECODE_Cls");
               Combo_receptionistphonecode_Selectedvalue_set = cgiGet( "COMBO_RECEPTIONISTPHONECODE_Selectedvalue_set");
               Combo_receptionistphonecode_Selectedvalue_get = cgiGet( "COMBO_RECEPTIONISTPHONECODE_Selectedvalue_get");
               Combo_receptionistphonecode_Selectedtext_set = cgiGet( "COMBO_RECEPTIONISTPHONECODE_Selectedtext_set");
               Combo_receptionistphonecode_Selectedtext_get = cgiGet( "COMBO_RECEPTIONISTPHONECODE_Selectedtext_get");
               Combo_receptionistphonecode_Gamoauthtoken = cgiGet( "COMBO_RECEPTIONISTPHONECODE_Gamoauthtoken");
               Combo_receptionistphonecode_Ddointernalname = cgiGet( "COMBO_RECEPTIONISTPHONECODE_Ddointernalname");
               Combo_receptionistphonecode_Titlecontrolalign = cgiGet( "COMBO_RECEPTIONISTPHONECODE_Titlecontrolalign");
               Combo_receptionistphonecode_Dropdownoptionstype = cgiGet( "COMBO_RECEPTIONISTPHONECODE_Dropdownoptionstype");
               Combo_receptionistphonecode_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_RECEPTIONISTPHONECODE_Enabled"));
               Combo_receptionistphonecode_Visible = StringUtil.StrToBool( cgiGet( "COMBO_RECEPTIONISTPHONECODE_Visible"));
               Combo_receptionistphonecode_Titlecontrolidtoreplace = cgiGet( "COMBO_RECEPTIONISTPHONECODE_Titlecontrolidtoreplace");
               Combo_receptionistphonecode_Datalisttype = cgiGet( "COMBO_RECEPTIONISTPHONECODE_Datalisttype");
               Combo_receptionistphonecode_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_RECEPTIONISTPHONECODE_Allowmultipleselection"));
               Combo_receptionistphonecode_Datalistfixedvalues = cgiGet( "COMBO_RECEPTIONISTPHONECODE_Datalistfixedvalues");
               Combo_receptionistphonecode_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_RECEPTIONISTPHONECODE_Isgriditem"));
               Combo_receptionistphonecode_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_RECEPTIONISTPHONECODE_Hasdescription"));
               Combo_receptionistphonecode_Datalistproc = cgiGet( "COMBO_RECEPTIONISTPHONECODE_Datalistproc");
               Combo_receptionistphonecode_Datalistprocparametersprefix = cgiGet( "COMBO_RECEPTIONISTPHONECODE_Datalistprocparametersprefix");
               Combo_receptionistphonecode_Remoteservicesparameters = cgiGet( "COMBO_RECEPTIONISTPHONECODE_Remoteservicesparameters");
               Combo_receptionistphonecode_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_RECEPTIONISTPHONECODE_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_receptionistphonecode_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_RECEPTIONISTPHONECODE_Includeonlyselectedoption"));
               Combo_receptionistphonecode_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_RECEPTIONISTPHONECODE_Includeselectalloption"));
               Combo_receptionistphonecode_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_RECEPTIONISTPHONECODE_Emptyitem"));
               Combo_receptionistphonecode_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_RECEPTIONISTPHONECODE_Includeaddnewoption"));
               Combo_receptionistphonecode_Htmltemplate = cgiGet( "COMBO_RECEPTIONISTPHONECODE_Htmltemplate");
               Combo_receptionistphonecode_Multiplevaluestype = cgiGet( "COMBO_RECEPTIONISTPHONECODE_Multiplevaluestype");
               Combo_receptionistphonecode_Loadingdata = cgiGet( "COMBO_RECEPTIONISTPHONECODE_Loadingdata");
               Combo_receptionistphonecode_Noresultsfound = cgiGet( "COMBO_RECEPTIONISTPHONECODE_Noresultsfound");
               Combo_receptionistphonecode_Emptyitemtext = cgiGet( "COMBO_RECEPTIONISTPHONECODE_Emptyitemtext");
               Combo_receptionistphonecode_Onlyselectedvalues = cgiGet( "COMBO_RECEPTIONISTPHONECODE_Onlyselectedvalues");
               Combo_receptionistphonecode_Selectalltext = cgiGet( "COMBO_RECEPTIONISTPHONECODE_Selectalltext");
               Combo_receptionistphonecode_Multiplevaluesseparator = cgiGet( "COMBO_RECEPTIONISTPHONECODE_Multiplevaluesseparator");
               Combo_receptionistphonecode_Addnewoptiontext = cgiGet( "COMBO_RECEPTIONISTPHONECODE_Addnewoptiontext");
               Combo_receptionistphonecode_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_RECEPTIONISTPHONECODE_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               dynLocationId.CurrentValue = cgiGet( dynLocationId_Internalname);
               A29LocationId = StringUtil.StrToGuid( cgiGet( dynLocationId_Internalname));
               AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
               A90ReceptionistGivenName = cgiGet( edtReceptionistGivenName_Internalname);
               AssignAttri("", false, "A90ReceptionistGivenName", A90ReceptionistGivenName);
               A91ReceptionistLastName = cgiGet( edtReceptionistLastName_Internalname);
               AssignAttri("", false, "A91ReceptionistLastName", A91ReceptionistLastName);
               A93ReceptionistEmail = cgiGet( edtReceptionistEmail_Internalname);
               AssignAttri("", false, "A93ReceptionistEmail", A93ReceptionistEmail);
               A94ReceptionistPhone = cgiGet( edtReceptionistPhone_Internalname);
               AssignAttri("", false, "A94ReceptionistPhone", A94ReceptionistPhone);
               A345ReceptionistPhoneCode = cgiGet( edtReceptionistPhoneCode_Internalname);
               AssignAttri("", false, "A345ReceptionistPhoneCode", A345ReceptionistPhoneCode);
               A346ReceptionistPhoneNumber = cgiGet( edtReceptionistPhoneNumber_Internalname);
               AssignAttri("", false, "A346ReceptionistPhoneNumber", A346ReceptionistPhoneNumber);
               A369ReceptionistIsActive = StringUtil.StrToBool( cgiGet( chkReceptionistIsActive_Internalname));
               AssignAttri("", false, "A369ReceptionistIsActive", A369ReceptionistIsActive);
               AV31ComboReceptionistPhoneCode = cgiGet( edtavComboreceptionistphonecode_Internalname);
               AssignAttri("", false, "AV31ComboReceptionistPhoneCode", AV31ComboReceptionistPhoneCode);
               if ( StringUtil.StrCmp(cgiGet( edtReceptionistId_Internalname), "") == 0 )
               {
                  A89ReceptionistId = Guid.Empty;
                  AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
               }
               else
               {
                  try
                  {
                     A89ReceptionistId = StringUtil.StrToGuid( cgiGet( edtReceptionistId_Internalname));
                     AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "RECEPTIONISTID");
                     AnyError = 1;
                     GX_FocusControl = edtReceptionistId_Internalname;
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
               A92ReceptionistInitials = cgiGet( edtReceptionistInitials_Internalname);
               AssignAttri("", false, "A92ReceptionistInitials", A92ReceptionistInitials);
               A95ReceptionistGAMGUID = cgiGet( edtReceptionistGAMGUID_Internalname);
               AssignAttri("", false, "A95ReceptionistGAMGUID", A95ReceptionistGAMGUID);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Receptionist");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV42Pgmname, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A89ReceptionistId != Z89ReceptionistId ) || ( A11OrganisationId != Z11OrganisationId ) || ( A29LocationId != Z29LocationId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_receptionist:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A89ReceptionistId = StringUtil.StrToGuid( GetPar( "ReceptionistId"));
                  AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
                  A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
                  A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
                  AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV23ReceptionistId) )
                  {
                     A89ReceptionistId = AV23ReceptionistId;
                     AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A89ReceptionistId) && ( Gx_BScreen == 0 ) )
                     {
                        A89ReceptionistId = Guid.NewGuid( );
                        AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
                     }
                  }
                  GXALOCATIONID_html0C63( AV21OrganisationId) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode63 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV23ReceptionistId) )
                     {
                        A89ReceptionistId = AV23ReceptionistId;
                        AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A89ReceptionistId) && ( Gx_BScreen == 0 ) )
                        {
                           A89ReceptionistId = Guid.NewGuid( );
                           AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
                        }
                     }
                     GXALOCATIONID_html0C63( AV21OrganisationId) ;
                     Gx_mode = sMode63;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound63 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0C0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "RECEPTIONISTID");
                        AnyError = 1;
                        GX_FocusControl = edtReceptionistId_Internalname;
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
                           E110C2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120C2 ();
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
            E120C2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0C63( ) ;
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
            DisableAttributes0C63( ) ;
         }
         AssignProp("", false, edtavComboreceptionistphonecode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboreceptionistphonecode_Enabled), 5, 0), true);
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

      protected void CONFIRM_0C0( )
      {
         BeforeValidate0C63( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0C63( ) ;
            }
            else
            {
               CheckExtendedTable0C63( ) ;
               CloseExtendedTableCursors0C63( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0C0( )
      {
      }

      protected void E110C2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            edtReceptionistPhoneNumber_Class = context.GetMessage( "PhoneNumberDisplay1", "");
            AssignProp("", false, edtReceptionistPhoneNumber_Internalname, "Class", edtReceptionistPhoneNumber_Class, true);
            divTable_Class = context.GetMessage( "AttributePhoneNumberDisplay", "");
            AssignProp("", false, divTable_Internalname, "Class", divTable_Class, true);
         }
         GXt_guid1 = AV21OrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
         AV21OrganisationId = GXt_guid1;
         AssignAttri("", false, "AV21OrganisationId", AV21OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV21OrganisationId, context));
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV29WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV13DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV13DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         edtReceptionistPhoneCode_Visible = 0;
         AssignProp("", false, edtReceptionistPhoneCode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtReceptionistPhoneCode_Visible), 5, 0), true);
         AV31ComboReceptionistPhoneCode = "";
         AssignAttri("", false, "AV31ComboReceptionistPhoneCode", AV31ComboReceptionistPhoneCode);
         edtavComboreceptionistphonecode_Visible = 0;
         AssignProp("", false, edtavComboreceptionistphonecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboreceptionistphonecode_Visible), 5, 0), true);
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char3) ;
         Combo_receptionistphonecode_Htmltemplate = GXt_char3;
         ucCombo_receptionistphonecode.SendProperty(context, "", false, Combo_receptionistphonecode_Internalname, "HTMLTemplate", Combo_receptionistphonecode_Htmltemplate);
         /* Execute user subroutine: 'LOADCOMBORECEPTIONISTPHONECODE' */
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
         AV25TrnContext.FromXml(AV28WebSession.Get("TrnContext"), null, "", "");
         edtReceptionistId_Visible = 0;
         AssignProp("", false, edtReceptionistId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtReceptionistId_Visible), 5, 0), true);
         edtOrganisationId_Visible = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Visible), 5, 0), true);
         edtReceptionistInitials_Visible = 0;
         AssignProp("", false, edtReceptionistInitials_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtReceptionistInitials_Visible), 5, 0), true);
         edtReceptionistGAMGUID_Visible = 0;
         AssignProp("", false, edtReceptionistGAMGUID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtReceptionistGAMGUID_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV32defaultCountryPhoneCode = "+31";
            AssignAttri("", false, "AV32defaultCountryPhoneCode", AV32defaultCountryPhoneCode);
            Combo_receptionistphonecode_Selectedtext_set = AV32defaultCountryPhoneCode;
            ucCombo_receptionistphonecode.SendProperty(context, "", false, Combo_receptionistphonecode_Internalname, "SelectedText_set", Combo_receptionistphonecode_Selectedtext_set);
            Combo_receptionistphonecode_Selectedvalue_set = AV32defaultCountryPhoneCode;
            ucCombo_receptionistphonecode.SendProperty(context, "", false, Combo_receptionistphonecode_Internalname, "SelectedValue_set", Combo_receptionistphonecode_Selectedvalue_set);
            AV31ComboReceptionistPhoneCode = AV32defaultCountryPhoneCode;
            AssignAttri("", false, "AV31ComboReceptionistPhoneCode", AV31ComboReceptionistPhoneCode);
         }
      }

      protected void E120C2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV36AuditingObject,  AV42Pgmname) ;
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV38Session.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "Receptionist Updated successfully", ""));
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV25TrnContext.gxTpr_Callerondelete )
         {
            AV38Session.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "Receptionist Deleted successfully", ""));
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV38Session.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "Receptionist Inserted successfully", ""));
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
         {
            new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV36AuditingObject,  AV42Pgmname) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV25TrnContext.gxTpr_Callerondelete )
            {
               CallWebObject(formatLink("trn_receptionistww.aspx") );
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
         edtReceptionistPhone_Visible = 0;
         AssignProp("", false, edtReceptionistPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtReceptionistPhone_Visible), 5, 0), true);
         divReceptionistphone_cell_Class = "Invisible";
         AssignProp("", false, divReceptionistphone_cell_Internalname, "Class", divReceptionistphone_cell_Class, true);
         chkReceptionistIsActive.Visible = 0;
         AssignProp("", false, chkReceptionistIsActive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkReceptionistIsActive.Visible), 5, 0), true);
         divReceptionistisactive_cell_Class = "Invisible";
         AssignProp("", false, divReceptionistisactive_cell_Internalname, "Class", divReceptionistisactive_cell_Class, true);
      }

      protected void S112( )
      {
         /* 'LOADCOMBORECEPTIONISTPHONECODE' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item4 = AV34ReceptionistPhoneCode_Data;
         new trn_receptionistloaddvcombo(context ).execute(  "ReceptionistPhoneCode",  Gx_mode,  AV23ReceptionistId,  AV21OrganisationId,  AV19LocationId, out  AV11ComboSelectedValue, out  AV10ComboSelectedText, out  GXt_objcol_SdtDVB_SDTComboData_Item4) ;
         AV34ReceptionistPhoneCode_Data = GXt_objcol_SdtDVB_SDTComboData_Item4;
         Combo_receptionistphonecode_Selectedvalue_set = AV11ComboSelectedValue;
         ucCombo_receptionistphonecode.SendProperty(context, "", false, Combo_receptionistphonecode_Internalname, "SelectedValue_set", Combo_receptionistphonecode_Selectedvalue_set);
         AV31ComboReceptionistPhoneCode = AV11ComboSelectedValue;
         AssignAttri("", false, "AV31ComboReceptionistPhoneCode", AV31ComboReceptionistPhoneCode);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_receptionistphonecode_Enabled = false;
            ucCombo_receptionistphonecode.SendProperty(context, "", false, Combo_receptionistphonecode_Internalname, "Enabled", StringUtil.BoolToStr( Combo_receptionistphonecode_Enabled));
         }
      }

      protected void ZM0C63( short GX_JID )
      {
         if ( ( GX_JID == 42 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z345ReceptionistPhoneCode = T000C3_A345ReceptionistPhoneCode[0];
               Z92ReceptionistInitials = T000C3_A92ReceptionistInitials[0];
               Z94ReceptionistPhone = T000C3_A94ReceptionistPhone[0];
               Z90ReceptionistGivenName = T000C3_A90ReceptionistGivenName[0];
               Z91ReceptionistLastName = T000C3_A91ReceptionistLastName[0];
               Z93ReceptionistEmail = T000C3_A93ReceptionistEmail[0];
               Z346ReceptionistPhoneNumber = T000C3_A346ReceptionistPhoneNumber[0];
               Z95ReceptionistGAMGUID = T000C3_A95ReceptionistGAMGUID[0];
               Z369ReceptionistIsActive = T000C3_A369ReceptionistIsActive[0];
            }
            else
            {
               Z345ReceptionistPhoneCode = A345ReceptionistPhoneCode;
               Z92ReceptionistInitials = A92ReceptionistInitials;
               Z94ReceptionistPhone = A94ReceptionistPhone;
               Z90ReceptionistGivenName = A90ReceptionistGivenName;
               Z91ReceptionistLastName = A91ReceptionistLastName;
               Z93ReceptionistEmail = A93ReceptionistEmail;
               Z346ReceptionistPhoneNumber = A346ReceptionistPhoneNumber;
               Z95ReceptionistGAMGUID = A95ReceptionistGAMGUID;
               Z369ReceptionistIsActive = A369ReceptionistIsActive;
            }
         }
         if ( GX_JID == -42 )
         {
            Z89ReceptionistId = A89ReceptionistId;
            Z345ReceptionistPhoneCode = A345ReceptionistPhoneCode;
            Z92ReceptionistInitials = A92ReceptionistInitials;
            Z94ReceptionistPhone = A94ReceptionistPhone;
            Z90ReceptionistGivenName = A90ReceptionistGivenName;
            Z91ReceptionistLastName = A91ReceptionistLastName;
            Z93ReceptionistEmail = A93ReceptionistEmail;
            Z346ReceptionistPhoneNumber = A346ReceptionistPhoneNumber;
            Z95ReceptionistGAMGUID = A95ReceptionistGAMGUID;
            Z369ReceptionistIsActive = A369ReceptionistIsActive;
            Z447ReceptionistImage = A447ReceptionistImage;
            Z40000ReceptionistImage_GXI = A40000ReceptionistImage_GXI;
            Z11OrganisationId = A11OrganisationId;
            Z29LocationId = A29LocationId;
         }
      }

      protected void standaloneNotModal( )
      {
         edtReceptionistPhone_Visible = ((StringUtil.StrCmp(Gx_mode, "DSP")==0)||(StringUtil.StrCmp(Gx_mode, "DLT")==0) ? 1 : 0);
         AssignProp("", false, edtReceptionistPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtReceptionistPhone_Visible), 5, 0), true);
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) ) )
         {
            divReceptionistphone_cell_Class = context.GetMessage( "Invisible", "");
            AssignProp("", false, divReceptionistphone_cell_Internalname, "Class", divReceptionistphone_cell_Class, true);
         }
         else
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               divReceptionistphone_cell_Class = context.GetMessage( "col-xs-12 col-sm-6 DataContentCell", "");
               AssignProp("", false, divReceptionistphone_cell_Internalname, "Class", divReceptionistphone_cell_Class, true);
            }
         }
         divUnnamedtable2_Visible = (((StringUtil.StrCmp(Gx_mode, "INS")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0)) ? 1 : 0);
         AssignProp("", false, divUnnamedtable2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUnnamedtable2_Visible), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV42Pgmname = "Trn_Receptionist";
         AssignAttri("", false, "AV42Pgmname", AV42Pgmname);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV23ReceptionistId) )
         {
            edtReceptionistId_Enabled = 0;
            AssignProp("", false, edtReceptionistId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistId_Enabled), 5, 0), true);
         }
         else
         {
            edtReceptionistId_Enabled = 1;
            AssignProp("", false, edtReceptionistId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV23ReceptionistId) )
         {
            edtReceptionistId_Enabled = 0;
            AssignProp("", false, edtReceptionistId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistId_Enabled), 5, 0), true);
         }
         GXALOCATIONID_html0C63( AV21OrganisationId) ;
         if ( ! (Guid.Empty==AV21OrganisationId) )
         {
            A11OrganisationId = AV21OrganisationId;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         else
         {
            GXt_guid1 = A11OrganisationId;
            new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
            A11OrganisationId = GXt_guid1;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         if ( ! (Guid.Empty==AV21OrganisationId) )
         {
            edtOrganisationId_Enabled = 0;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
         else
         {
            edtOrganisationId_Enabled = 1;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV21OrganisationId) )
         {
            edtOrganisationId_Enabled = 0;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV19LocationId) )
         {
            A29LocationId = AV19LocationId;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         }
      }

      protected void standaloneModal( )
      {
         if ( IsUpd( )  )
         {
            edtReceptionistEmail_Enabled = 0;
            AssignProp("", false, edtReceptionistEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistEmail_Enabled), 5, 0), true);
         }
         else
         {
            edtReceptionistEmail_Enabled = 1;
            AssignProp("", false, edtReceptionistEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistEmail_Enabled), 5, 0), true);
         }
         if ( IsUpd( )  )
         {
            edtReceptionistEmail_Enabled = 0;
            AssignProp("", false, edtReceptionistEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistEmail_Enabled), 5, 0), true);
         }
         A345ReceptionistPhoneCode = AV31ComboReceptionistPhoneCode;
         AssignAttri("", false, "A345ReceptionistPhoneCode", A345ReceptionistPhoneCode);
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
         if ( ! (Guid.Empty==AV23ReceptionistId) )
         {
            A89ReceptionistId = AV23ReceptionistId;
            AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A89ReceptionistId) && ( Gx_BScreen == 0 ) )
            {
               A89ReceptionistId = Guid.NewGuid( );
               AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0C63( )
      {
         /* Using cursor T000C5 */
         pr_default.execute(3, new Object[] {A89ReceptionistId, A11OrganisationId, A29LocationId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound63 = 1;
            A345ReceptionistPhoneCode = T000C5_A345ReceptionistPhoneCode[0];
            AssignAttri("", false, "A345ReceptionistPhoneCode", A345ReceptionistPhoneCode);
            A92ReceptionistInitials = T000C5_A92ReceptionistInitials[0];
            AssignAttri("", false, "A92ReceptionistInitials", A92ReceptionistInitials);
            A94ReceptionistPhone = T000C5_A94ReceptionistPhone[0];
            AssignAttri("", false, "A94ReceptionistPhone", A94ReceptionistPhone);
            A90ReceptionistGivenName = T000C5_A90ReceptionistGivenName[0];
            AssignAttri("", false, "A90ReceptionistGivenName", A90ReceptionistGivenName);
            A91ReceptionistLastName = T000C5_A91ReceptionistLastName[0];
            AssignAttri("", false, "A91ReceptionistLastName", A91ReceptionistLastName);
            A93ReceptionistEmail = T000C5_A93ReceptionistEmail[0];
            AssignAttri("", false, "A93ReceptionistEmail", A93ReceptionistEmail);
            A346ReceptionistPhoneNumber = T000C5_A346ReceptionistPhoneNumber[0];
            AssignAttri("", false, "A346ReceptionistPhoneNumber", A346ReceptionistPhoneNumber);
            A95ReceptionistGAMGUID = T000C5_A95ReceptionistGAMGUID[0];
            AssignAttri("", false, "A95ReceptionistGAMGUID", A95ReceptionistGAMGUID);
            A369ReceptionistIsActive = T000C5_A369ReceptionistIsActive[0];
            AssignAttri("", false, "A369ReceptionistIsActive", A369ReceptionistIsActive);
            A40000ReceptionistImage_GXI = T000C5_A40000ReceptionistImage_GXI[0];
            A447ReceptionistImage = T000C5_A447ReceptionistImage[0];
            ZM0C63( -42) ;
         }
         pr_default.close(3);
         OnLoadActions0C63( ) ;
      }

      protected void OnLoadActions0C63( )
      {
         GXt_char3 = A94ReceptionistPhone;
         new prc_concatenateintlphone(context ).execute(  A345ReceptionistPhoneCode,  A346ReceptionistPhoneNumber, out  GXt_char3) ;
         A94ReceptionistPhone = GXt_char3;
         AssignAttri("", false, "A94ReceptionistPhone", A94ReceptionistPhone);
         GXt_boolean5 = AV37IsGAMActive;
         new prc_checkgamuseractivationstatus(context ).execute(  A95ReceptionistGAMGUID, out  GXt_boolean5) ;
         AV37IsGAMActive = GXt_boolean5;
         AssignAttri("", false, "AV37IsGAMActive", AV37IsGAMActive);
         chkReceptionistIsActive.Visible = ((AV37IsGAMActive) ? 1 : 0);
         AssignProp("", false, chkReceptionistIsActive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkReceptionistIsActive.Visible), 5, 0), true);
         if ( ! ( ( AV37IsGAMActive ) ) )
         {
            divReceptionistisactive_cell_Class = context.GetMessage( "Invisible", "");
            AssignProp("", false, divReceptionistisactive_cell_Internalname, "Class", divReceptionistisactive_cell_Class, true);
         }
         else
         {
            if ( AV37IsGAMActive )
            {
               divReceptionistisactive_cell_Class = context.GetMessage( "col-xs-12 col-sm-6 DataContentCell", "");
               AssignProp("", false, divReceptionistisactive_cell_Internalname, "Class", divReceptionistisactive_cell_Class, true);
            }
         }
      }

      protected void CheckExtendedTable0C63( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000C4 */
         pr_default.execute(2, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = dynLocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( (Guid.Empty==A29LocationId) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Location Id", ""), "", "", "", "", "", "", "", ""), 1, "LOCATIONID");
            AnyError = 1;
            GX_FocusControl = dynLocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A90ReceptionistGivenName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Receptionist Given Name", ""), "", "", "", "", "", "", "", ""), 1, "RECEPTIONISTGIVENNAME");
            AnyError = 1;
            GX_FocusControl = edtReceptionistGivenName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A91ReceptionistLastName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Receptionist Last Name", ""), "", "", "", "", "", "", "", ""), 1, "RECEPTIONISTLASTNAME");
            AnyError = 1;
            GX_FocusControl = edtReceptionistLastName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A93ReceptionistEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "Invalid email pattern", ""), context.GetMessage( "Receptionist Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "RECEPTIONISTEMAIL");
            AnyError = 1;
            GX_FocusControl = edtReceptionistEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A93ReceptionistEmail)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Receptionist Email", ""), "", "", "", "", "", "", "", ""), 1, "RECEPTIONISTEMAIL");
            AnyError = 1;
            GX_FocusControl = edtReceptionistEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GXt_char3 = A94ReceptionistPhone;
         new prc_concatenateintlphone(context ).execute(  A345ReceptionistPhoneCode,  A346ReceptionistPhoneNumber, out  GXt_char3) ;
         A94ReceptionistPhone = GXt_char3;
         AssignAttri("", false, "A94ReceptionistPhone", A94ReceptionistPhone);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A346ReceptionistPhoneNumber)) && ! GxRegex.IsMatch(A346ReceptionistPhoneNumber,context.GetMessage( "^\\d{9}$", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Phone contains 9 digits", ""), 1, "RECEPTIONISTPHONENUMBER");
            AnyError = 1;
            GX_FocusControl = edtReceptionistPhoneNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GXt_boolean5 = AV37IsGAMActive;
         new prc_checkgamuseractivationstatus(context ).execute(  A95ReceptionistGAMGUID, out  GXt_boolean5) ;
         AV37IsGAMActive = GXt_boolean5;
         AssignAttri("", false, "AV37IsGAMActive", AV37IsGAMActive);
         chkReceptionistIsActive.Visible = ((AV37IsGAMActive) ? 1 : 0);
         AssignProp("", false, chkReceptionistIsActive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkReceptionistIsActive.Visible), 5, 0), true);
         if ( ! ( ( AV37IsGAMActive ) ) )
         {
            divReceptionistisactive_cell_Class = context.GetMessage( "Invisible", "");
            AssignProp("", false, divReceptionistisactive_cell_Internalname, "Class", divReceptionistisactive_cell_Class, true);
         }
         else
         {
            if ( AV37IsGAMActive )
            {
               divReceptionistisactive_cell_Class = context.GetMessage( "col-xs-12 col-sm-6 DataContentCell", "");
               AssignProp("", false, divReceptionistisactive_cell_Internalname, "Class", divReceptionistisactive_cell_Class, true);
            }
         }
      }

      protected void CloseExtendedTableCursors0C63( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_43( Guid A29LocationId ,
                                Guid A11OrganisationId )
      {
         /* Using cursor T000C6 */
         pr_default.execute(4, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = dynLocationId_Internalname;
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

      protected void GetKey0C63( )
      {
         /* Using cursor T000C7 */
         pr_default.execute(5, new Object[] {A89ReceptionistId, A11OrganisationId, A29LocationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound63 = 1;
         }
         else
         {
            RcdFound63 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000C3 */
         pr_default.execute(1, new Object[] {A89ReceptionistId, A11OrganisationId, A29LocationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0C63( 42) ;
            RcdFound63 = 1;
            A89ReceptionistId = T000C3_A89ReceptionistId[0];
            AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
            A345ReceptionistPhoneCode = T000C3_A345ReceptionistPhoneCode[0];
            AssignAttri("", false, "A345ReceptionistPhoneCode", A345ReceptionistPhoneCode);
            A92ReceptionistInitials = T000C3_A92ReceptionistInitials[0];
            AssignAttri("", false, "A92ReceptionistInitials", A92ReceptionistInitials);
            A94ReceptionistPhone = T000C3_A94ReceptionistPhone[0];
            AssignAttri("", false, "A94ReceptionistPhone", A94ReceptionistPhone);
            A90ReceptionistGivenName = T000C3_A90ReceptionistGivenName[0];
            AssignAttri("", false, "A90ReceptionistGivenName", A90ReceptionistGivenName);
            A91ReceptionistLastName = T000C3_A91ReceptionistLastName[0];
            AssignAttri("", false, "A91ReceptionistLastName", A91ReceptionistLastName);
            A93ReceptionistEmail = T000C3_A93ReceptionistEmail[0];
            AssignAttri("", false, "A93ReceptionistEmail", A93ReceptionistEmail);
            A346ReceptionistPhoneNumber = T000C3_A346ReceptionistPhoneNumber[0];
            AssignAttri("", false, "A346ReceptionistPhoneNumber", A346ReceptionistPhoneNumber);
            A95ReceptionistGAMGUID = T000C3_A95ReceptionistGAMGUID[0];
            AssignAttri("", false, "A95ReceptionistGAMGUID", A95ReceptionistGAMGUID);
            A369ReceptionistIsActive = T000C3_A369ReceptionistIsActive[0];
            AssignAttri("", false, "A369ReceptionistIsActive", A369ReceptionistIsActive);
            A40000ReceptionistImage_GXI = T000C3_A40000ReceptionistImage_GXI[0];
            A11OrganisationId = T000C3_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A29LocationId = T000C3_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A447ReceptionistImage = T000C3_A447ReceptionistImage[0];
            Z89ReceptionistId = A89ReceptionistId;
            Z11OrganisationId = A11OrganisationId;
            Z29LocationId = A29LocationId;
            sMode63 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0C63( ) ;
            if ( AnyError == 1 )
            {
               RcdFound63 = 0;
               InitializeNonKey0C63( ) ;
            }
            Gx_mode = sMode63;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound63 = 0;
            InitializeNonKey0C63( ) ;
            sMode63 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode63;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0C63( ) ;
         if ( RcdFound63 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound63 = 0;
         /* Using cursor T000C8 */
         pr_default.execute(6, new Object[] {A89ReceptionistId, A11OrganisationId, A29LocationId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T000C8_A89ReceptionistId[0], A89ReceptionistId, 0) < 0 ) || ( T000C8_A89ReceptionistId[0] == A89ReceptionistId ) && ( GuidUtil.Compare(T000C8_A11OrganisationId[0], A11OrganisationId, 0) < 0 ) || ( T000C8_A11OrganisationId[0] == A11OrganisationId ) && ( T000C8_A89ReceptionistId[0] == A89ReceptionistId ) && ( GuidUtil.Compare(T000C8_A29LocationId[0], A29LocationId, 0) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T000C8_A89ReceptionistId[0], A89ReceptionistId, 0) > 0 ) || ( T000C8_A89ReceptionistId[0] == A89ReceptionistId ) && ( GuidUtil.Compare(T000C8_A11OrganisationId[0], A11OrganisationId, 0) > 0 ) || ( T000C8_A11OrganisationId[0] == A11OrganisationId ) && ( T000C8_A89ReceptionistId[0] == A89ReceptionistId ) && ( GuidUtil.Compare(T000C8_A29LocationId[0], A29LocationId, 0) > 0 ) ) )
            {
               A89ReceptionistId = T000C8_A89ReceptionistId[0];
               AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
               A11OrganisationId = T000C8_A11OrganisationId[0];
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               A29LocationId = T000C8_A29LocationId[0];
               AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
               RcdFound63 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound63 = 0;
         /* Using cursor T000C9 */
         pr_default.execute(7, new Object[] {A89ReceptionistId, A11OrganisationId, A29LocationId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T000C9_A89ReceptionistId[0], A89ReceptionistId, 0) > 0 ) || ( T000C9_A89ReceptionistId[0] == A89ReceptionistId ) && ( GuidUtil.Compare(T000C9_A11OrganisationId[0], A11OrganisationId, 0) > 0 ) || ( T000C9_A11OrganisationId[0] == A11OrganisationId ) && ( T000C9_A89ReceptionistId[0] == A89ReceptionistId ) && ( GuidUtil.Compare(T000C9_A29LocationId[0], A29LocationId, 0) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T000C9_A89ReceptionistId[0], A89ReceptionistId, 0) < 0 ) || ( T000C9_A89ReceptionistId[0] == A89ReceptionistId ) && ( GuidUtil.Compare(T000C9_A11OrganisationId[0], A11OrganisationId, 0) < 0 ) || ( T000C9_A11OrganisationId[0] == A11OrganisationId ) && ( T000C9_A89ReceptionistId[0] == A89ReceptionistId ) && ( GuidUtil.Compare(T000C9_A29LocationId[0], A29LocationId, 0) < 0 ) ) )
            {
               A89ReceptionistId = T000C9_A89ReceptionistId[0];
               AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
               A11OrganisationId = T000C9_A11OrganisationId[0];
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               A29LocationId = T000C9_A29LocationId[0];
               AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
               RcdFound63 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0C63( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = dynLocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0C63( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound63 == 1 )
            {
               if ( ( A89ReceptionistId != Z89ReceptionistId ) || ( A11OrganisationId != Z11OrganisationId ) || ( A29LocationId != Z29LocationId ) )
               {
                  A89ReceptionistId = Z89ReceptionistId;
                  AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
                  A11OrganisationId = Z11OrganisationId;
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
                  A29LocationId = Z29LocationId;
                  AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "RECEPTIONISTID");
                  AnyError = 1;
                  GX_FocusControl = edtReceptionistId_Internalname;
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
                  Update0C63( ) ;
                  GX_FocusControl = dynLocationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A89ReceptionistId != Z89ReceptionistId ) || ( A11OrganisationId != Z11OrganisationId ) || ( A29LocationId != Z29LocationId ) )
               {
                  /* Insert record */
                  GX_FocusControl = dynLocationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0C63( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "RECEPTIONISTID");
                     AnyError = 1;
                     GX_FocusControl = edtReceptionistId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = dynLocationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0C63( ) ;
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
         if ( ( A89ReceptionistId != Z89ReceptionistId ) || ( A11OrganisationId != Z11OrganisationId ) || ( A29LocationId != Z29LocationId ) )
         {
            A89ReceptionistId = Z89ReceptionistId;
            AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
            A11OrganisationId = Z11OrganisationId;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A29LocationId = Z29LocationId;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "RECEPTIONISTID");
            AnyError = 1;
            GX_FocusControl = edtReceptionistId_Internalname;
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

      protected void CheckOptimisticConcurrency0C63( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000C2 */
            pr_default.execute(0, new Object[] {A89ReceptionistId, A11OrganisationId, A29LocationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Receptionist"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z345ReceptionistPhoneCode, T000C2_A345ReceptionistPhoneCode[0]) != 0 ) || ( StringUtil.StrCmp(Z92ReceptionistInitials, T000C2_A92ReceptionistInitials[0]) != 0 ) || ( StringUtil.StrCmp(Z94ReceptionistPhone, T000C2_A94ReceptionistPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z90ReceptionistGivenName, T000C2_A90ReceptionistGivenName[0]) != 0 ) || ( StringUtil.StrCmp(Z91ReceptionistLastName, T000C2_A91ReceptionistLastName[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z93ReceptionistEmail, T000C2_A93ReceptionistEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z346ReceptionistPhoneNumber, T000C2_A346ReceptionistPhoneNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z95ReceptionistGAMGUID, T000C2_A95ReceptionistGAMGUID[0]) != 0 ) || ( Z369ReceptionistIsActive != T000C2_A369ReceptionistIsActive[0] ) )
            {
               if ( StringUtil.StrCmp(Z345ReceptionistPhoneCode, T000C2_A345ReceptionistPhoneCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_receptionist:[seudo value changed for attri]"+"ReceptionistPhoneCode");
                  GXUtil.WriteLogRaw("Old: ",Z345ReceptionistPhoneCode);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A345ReceptionistPhoneCode[0]);
               }
               if ( StringUtil.StrCmp(Z92ReceptionistInitials, T000C2_A92ReceptionistInitials[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_receptionist:[seudo value changed for attri]"+"ReceptionistInitials");
                  GXUtil.WriteLogRaw("Old: ",Z92ReceptionistInitials);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A92ReceptionistInitials[0]);
               }
               if ( StringUtil.StrCmp(Z94ReceptionistPhone, T000C2_A94ReceptionistPhone[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_receptionist:[seudo value changed for attri]"+"ReceptionistPhone");
                  GXUtil.WriteLogRaw("Old: ",Z94ReceptionistPhone);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A94ReceptionistPhone[0]);
               }
               if ( StringUtil.StrCmp(Z90ReceptionistGivenName, T000C2_A90ReceptionistGivenName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_receptionist:[seudo value changed for attri]"+"ReceptionistGivenName");
                  GXUtil.WriteLogRaw("Old: ",Z90ReceptionistGivenName);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A90ReceptionistGivenName[0]);
               }
               if ( StringUtil.StrCmp(Z91ReceptionistLastName, T000C2_A91ReceptionistLastName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_receptionist:[seudo value changed for attri]"+"ReceptionistLastName");
                  GXUtil.WriteLogRaw("Old: ",Z91ReceptionistLastName);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A91ReceptionistLastName[0]);
               }
               if ( StringUtil.StrCmp(Z93ReceptionistEmail, T000C2_A93ReceptionistEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_receptionist:[seudo value changed for attri]"+"ReceptionistEmail");
                  GXUtil.WriteLogRaw("Old: ",Z93ReceptionistEmail);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A93ReceptionistEmail[0]);
               }
               if ( StringUtil.StrCmp(Z346ReceptionistPhoneNumber, T000C2_A346ReceptionistPhoneNumber[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_receptionist:[seudo value changed for attri]"+"ReceptionistPhoneNumber");
                  GXUtil.WriteLogRaw("Old: ",Z346ReceptionistPhoneNumber);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A346ReceptionistPhoneNumber[0]);
               }
               if ( StringUtil.StrCmp(Z95ReceptionistGAMGUID, T000C2_A95ReceptionistGAMGUID[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_receptionist:[seudo value changed for attri]"+"ReceptionistGAMGUID");
                  GXUtil.WriteLogRaw("Old: ",Z95ReceptionistGAMGUID);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A95ReceptionistGAMGUID[0]);
               }
               if ( Z369ReceptionistIsActive != T000C2_A369ReceptionistIsActive[0] )
               {
                  GXUtil.WriteLog("trn_receptionist:[seudo value changed for attri]"+"ReceptionistIsActive");
                  GXUtil.WriteLogRaw("Old: ",Z369ReceptionistIsActive);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A369ReceptionistIsActive[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Receptionist"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0C63( )
      {
         if ( ! IsAuthorized("trn_receptionist_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0C63( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C63( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0C63( 0) ;
            CheckOptimisticConcurrency0C63( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C63( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0C63( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000C10 */
                     pr_default.execute(8, new Object[] {A89ReceptionistId, A345ReceptionistPhoneCode, A92ReceptionistInitials, A94ReceptionistPhone, A90ReceptionistGivenName, A91ReceptionistLastName, A93ReceptionistEmail, A346ReceptionistPhoneNumber, A95ReceptionistGAMGUID, A369ReceptionistIsActive, A447ReceptionistImage, A40000ReceptionistImage_GXI, A11OrganisationId, A29LocationId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Receptionist");
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
                           ResetCaption0C0( ) ;
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
               Load0C63( ) ;
            }
            EndLevel0C63( ) ;
         }
         CloseExtendedTableCursors0C63( ) ;
      }

      protected void Update0C63( )
      {
         if ( ! IsAuthorized("trn_receptionist_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0C63( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C63( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C63( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C63( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0C63( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000C11 */
                     pr_default.execute(9, new Object[] {A345ReceptionistPhoneCode, A92ReceptionistInitials, A94ReceptionistPhone, A90ReceptionistGivenName, A91ReceptionistLastName, A93ReceptionistEmail, A346ReceptionistPhoneNumber, A95ReceptionistGAMGUID, A369ReceptionistIsActive, A89ReceptionistId, A11OrganisationId, A29LocationId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Receptionist");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Receptionist"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0C63( ) ;
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
            EndLevel0C63( ) ;
         }
         CloseExtendedTableCursors0C63( ) ;
      }

      protected void DeferredUpdate0C63( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000C12 */
            pr_default.execute(10, new Object[] {A447ReceptionistImage, A40000ReceptionistImage_GXI, A89ReceptionistId, A11OrganisationId, A29LocationId});
            pr_default.close(10);
            pr_default.SmartCacheProvider.SetUpdated("Trn_Receptionist");
         }
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_receptionist_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0C63( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C63( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0C63( ) ;
            AfterConfirm0C63( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0C63( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000C13 */
                  pr_default.execute(11, new Object[] {A89ReceptionistId, A11OrganisationId, A29LocationId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Receptionist");
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
         sMode63 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0C63( ) ;
         Gx_mode = sMode63;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0C63( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_boolean5 = AV37IsGAMActive;
            new prc_checkgamuseractivationstatus(context ).execute(  A95ReceptionistGAMGUID, out  GXt_boolean5) ;
            AV37IsGAMActive = GXt_boolean5;
            AssignAttri("", false, "AV37IsGAMActive", AV37IsGAMActive);
            chkReceptionistIsActive.Visible = ((AV37IsGAMActive) ? 1 : 0);
            AssignProp("", false, chkReceptionistIsActive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkReceptionistIsActive.Visible), 5, 0), true);
            if ( ! ( ( AV37IsGAMActive ) ) )
            {
               divReceptionistisactive_cell_Class = context.GetMessage( "Invisible", "");
               AssignProp("", false, divReceptionistisactive_cell_Internalname, "Class", divReceptionistisactive_cell_Class, true);
            }
            else
            {
               if ( AV37IsGAMActive )
               {
                  divReceptionistisactive_cell_Class = context.GetMessage( "col-xs-12 col-sm-6 DataContentCell", "");
                  AssignProp("", false, divReceptionistisactive_cell_Internalname, "Class", divReceptionistisactive_cell_Class, true);
               }
            }
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000C14 */
            pr_default.execute(12, new Object[] {A89ReceptionistId, A11OrganisationId, A29LocationId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Locations", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel0C63( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0C63( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_receptionist",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0C0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_receptionist",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0C63( )
      {
         /* Scan By routine */
         /* Using cursor T000C15 */
         pr_default.execute(13);
         RcdFound63 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound63 = 1;
            A89ReceptionistId = T000C15_A89ReceptionistId[0];
            AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
            A11OrganisationId = T000C15_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A29LocationId = T000C15_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0C63( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound63 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound63 = 1;
            A89ReceptionistId = T000C15_A89ReceptionistId[0];
            AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
            A11OrganisationId = T000C15_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A29LocationId = T000C15_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         }
      }

      protected void ScanEnd0C63( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0C63( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0C63( )
      {
         /* Before Insert Rules */
         AV14GAMErrorResponse = "";
         AssignAttri("", false, "AV14GAMErrorResponse", AV14GAMErrorResponse);
         AssignAttri("", false, "AV14GAMErrorResponse", AV14GAMErrorResponse);
         new prc_getnameinitials(context ).execute(  A90ReceptionistGivenName,  A91ReceptionistLastName, out  A92ReceptionistInitials) ;
         AssignAttri("", false, "A92ReceptionistInitials", A92ReceptionistInitials);
         if ( ( StringUtil.StrCmp(Gx_mode, context.GetMessage( "INS", "")) == 0 ) && String.IsNullOrEmpty(StringUtil.RTrim( A95ReceptionistGAMGUID)) )
         {
            new prc_creategamuseraccount(context ).execute(  A93ReceptionistEmail,  A90ReceptionistGivenName,  A91ReceptionistLastName,  "Receptionist", ref  A95ReceptionistGAMGUID, ref  AV14GAMErrorResponse) ;
            AssignAttri("", false, "A95ReceptionistGAMGUID", A95ReceptionistGAMGUID);
            AssignAttri("", false, "AV14GAMErrorResponse", AV14GAMErrorResponse);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, context.GetMessage( "INS", "")) == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV14GAMErrorResponse)) )
         {
            GX_msglist.addItem(AV14GAMErrorResponse, 1, "");
            AnyError = 1;
         }
      }

      protected void BeforeUpdate0C63( )
      {
         /* Before Update Rules */
         AV14GAMErrorResponse = "";
         AssignAttri("", false, "AV14GAMErrorResponse", AV14GAMErrorResponse);
         AssignAttri("", false, "AV14GAMErrorResponse", AV14GAMErrorResponse);
         new loadaudittrn_receptionist(context ).execute(  "Y", ref  AV36AuditingObject,  A89ReceptionistId,  A11OrganisationId,  A29LocationId,  Gx_mode) ;
         if ( IsUpd( )  )
         {
            new prc_updategamuseraccount(context ).execute(  A95ReceptionistGAMGUID,  A90ReceptionistGivenName,  A91ReceptionistLastName,  A345ReceptionistPhoneCode,  A346ReceptionistPhoneNumber,  A447ReceptionistImage,  A369ReceptionistIsActive,  "Receptionist", out  AV14GAMErrorResponse) ;
            AssignAttri("", false, "AV14GAMErrorResponse", AV14GAMErrorResponse);
         }
         if ( IsUpd( )  && ! String.IsNullOrEmpty(StringUtil.RTrim( AV14GAMErrorResponse)) )
         {
            GX_msglist.addItem(AV14GAMErrorResponse, 1, "");
            AnyError = 1;
         }
      }

      protected void BeforeDelete0C63( )
      {
         /* Before Delete Rules */
         AV14GAMErrorResponse = "";
         AssignAttri("", false, "AV14GAMErrorResponse", AV14GAMErrorResponse);
         AssignAttri("", false, "AV14GAMErrorResponse", AV14GAMErrorResponse);
         new loadaudittrn_receptionist(context ).execute(  "Y", ref  AV36AuditingObject,  A89ReceptionistId,  A11OrganisationId,  A29LocationId,  Gx_mode) ;
         if ( IsDlt( )  )
         {
            new prc_deletegamuseraccount(context ).execute(  A95ReceptionistGAMGUID, out  AV14GAMErrorResponse) ;
            AssignAttri("", false, "AV14GAMErrorResponse", AV14GAMErrorResponse);
         }
         if ( IsDlt( )  && ! String.IsNullOrEmpty(StringUtil.RTrim( AV14GAMErrorResponse)) )
         {
            GX_msglist.addItem(AV14GAMErrorResponse, 1, "");
            AnyError = 1;
         }
      }

      protected void BeforeComplete0C63( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new loadaudittrn_receptionist(context ).execute(  "N", ref  AV36AuditingObject,  A89ReceptionistId,  A11OrganisationId,  A29LocationId,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new loadaudittrn_receptionist(context ).execute(  "N", ref  AV36AuditingObject,  A89ReceptionistId,  A11OrganisationId,  A29LocationId,  Gx_mode) ;
         }
      }

      protected void BeforeValidate0C63( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0C63( )
      {
         dynLocationId.Enabled = 0;
         AssignProp("", false, dynLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynLocationId.Enabled), 5, 0), true);
         edtReceptionistGivenName_Enabled = 0;
         AssignProp("", false, edtReceptionistGivenName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistGivenName_Enabled), 5, 0), true);
         edtReceptionistLastName_Enabled = 0;
         AssignProp("", false, edtReceptionistLastName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistLastName_Enabled), 5, 0), true);
         edtReceptionistEmail_Enabled = 0;
         AssignProp("", false, edtReceptionistEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistEmail_Enabled), 5, 0), true);
         edtReceptionistPhone_Enabled = 0;
         AssignProp("", false, edtReceptionistPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistPhone_Enabled), 5, 0), true);
         edtReceptionistPhoneCode_Enabled = 0;
         AssignProp("", false, edtReceptionistPhoneCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistPhoneCode_Enabled), 5, 0), true);
         edtReceptionistPhoneNumber_Enabled = 0;
         AssignProp("", false, edtReceptionistPhoneNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistPhoneNumber_Enabled), 5, 0), true);
         chkReceptionistIsActive.Enabled = 0;
         AssignProp("", false, chkReceptionistIsActive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkReceptionistIsActive.Enabled), 5, 0), true);
         edtavComboreceptionistphonecode_Enabled = 0;
         AssignProp("", false, edtavComboreceptionistphonecode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboreceptionistphonecode_Enabled), 5, 0), true);
         edtReceptionistId_Enabled = 0;
         AssignProp("", false, edtReceptionistId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistId_Enabled), 5, 0), true);
         edtOrganisationId_Enabled = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         edtReceptionistInitials_Enabled = 0;
         AssignProp("", false, edtReceptionistInitials_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistInitials_Enabled), 5, 0), true);
         edtReceptionistGAMGUID_Enabled = 0;
         AssignProp("", false, edtReceptionistGAMGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistGAMGUID_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0C63( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0C0( )
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
         GXEncryptionTmp = "trn_receptionist.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV23ReceptionistId.ToString()) + "," + UrlEncode(AV21OrganisationId.ToString()) + "," + UrlEncode(AV19LocationId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_receptionist.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Receptionist");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV42Pgmname, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_receptionist:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z89ReceptionistId", Z89ReceptionistId.ToString());
         GxWebStd.gx_hidden_field( context, "Z11OrganisationId", Z11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z29LocationId", Z29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z345ReceptionistPhoneCode", Z345ReceptionistPhoneCode);
         GxWebStd.gx_hidden_field( context, "Z92ReceptionistInitials", StringUtil.RTrim( Z92ReceptionistInitials));
         GxWebStd.gx_hidden_field( context, "Z94ReceptionistPhone", StringUtil.RTrim( Z94ReceptionistPhone));
         GxWebStd.gx_hidden_field( context, "Z90ReceptionistGivenName", Z90ReceptionistGivenName);
         GxWebStd.gx_hidden_field( context, "Z91ReceptionistLastName", Z91ReceptionistLastName);
         GxWebStd.gx_hidden_field( context, "Z93ReceptionistEmail", Z93ReceptionistEmail);
         GxWebStd.gx_hidden_field( context, "Z346ReceptionistPhoneNumber", Z346ReceptionistPhoneNumber);
         GxWebStd.gx_hidden_field( context, "Z95ReceptionistGAMGUID", Z95ReceptionistGAMGUID);
         GxWebStd.gx_boolean_hidden_field( context, "Z369ReceptionistIsActive", Z369ReceptionistIsActive);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV13DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV13DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vRECEPTIONISTPHONECODE_DATA", AV34ReceptionistPhoneCode_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vRECEPTIONISTPHONECODE_DATA", AV34ReceptionistPhoneCode_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV25TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV25TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV25TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vRECEPTIONISTID", AV23ReceptionistId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vRECEPTIONISTID", GetSecureSignedToken( "", AV23ReceptionistId, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV21OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV21OrganisationId, context));
         GxWebStd.gx_hidden_field( context, "vLOCATIONID", AV19LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", AV19LocationId, context));
         GxWebStd.gx_hidden_field( context, "vGAMERRORRESPONSE", AV14GAMErrorResponse);
         GxWebStd.gx_boolean_hidden_field( context, "vISGAMACTIVE", AV37IsGAMActive);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAUDITINGOBJECT", AV36AuditingObject);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAUDITINGOBJECT", AV36AuditingObject);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "RECEPTIONISTIMAGE", A447ReceptionistImage);
         GxWebStd.gx_hidden_field( context, "RECEPTIONISTIMAGE_GXI", A40000ReceptionistImage_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV42Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_RECEPTIONISTPHONECODE_Objectcall", StringUtil.RTrim( Combo_receptionistphonecode_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_RECEPTIONISTPHONECODE_Cls", StringUtil.RTrim( Combo_receptionistphonecode_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_RECEPTIONISTPHONECODE_Selectedvalue_set", StringUtil.RTrim( Combo_receptionistphonecode_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RECEPTIONISTPHONECODE_Selectedtext_set", StringUtil.RTrim( Combo_receptionistphonecode_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RECEPTIONISTPHONECODE_Enabled", StringUtil.BoolToStr( Combo_receptionistphonecode_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_RECEPTIONISTPHONECODE_Emptyitem", StringUtil.BoolToStr( Combo_receptionistphonecode_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_RECEPTIONISTPHONECODE_Htmltemplate", StringUtil.RTrim( Combo_receptionistphonecode_Htmltemplate));
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
         GXEncryptionTmp = "trn_receptionist.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV23ReceptionistId.ToString()) + "," + UrlEncode(AV21OrganisationId.ToString()) + "," + UrlEncode(AV19LocationId.ToString());
         return formatLink("trn_receptionist.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Trn_Receptionist" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Receptionist", "") ;
      }

      protected void InitializeNonKey0C63( )
      {
         A345ReceptionistPhoneCode = "";
         AssignAttri("", false, "A345ReceptionistPhoneCode", A345ReceptionistPhoneCode);
         AV36AuditingObject = new WorkWithPlus.workwithplus_web.SdtAuditingObject(context);
         AV14GAMErrorResponse = "";
         AssignAttri("", false, "AV14GAMErrorResponse", AV14GAMErrorResponse);
         A92ReceptionistInitials = "";
         AssignAttri("", false, "A92ReceptionistInitials", A92ReceptionistInitials);
         A94ReceptionistPhone = "";
         AssignAttri("", false, "A94ReceptionistPhone", A94ReceptionistPhone);
         AV37IsGAMActive = false;
         AssignAttri("", false, "AV37IsGAMActive", AV37IsGAMActive);
         A90ReceptionistGivenName = "";
         AssignAttri("", false, "A90ReceptionistGivenName", A90ReceptionistGivenName);
         A91ReceptionistLastName = "";
         AssignAttri("", false, "A91ReceptionistLastName", A91ReceptionistLastName);
         A93ReceptionistEmail = "";
         AssignAttri("", false, "A93ReceptionistEmail", A93ReceptionistEmail);
         A346ReceptionistPhoneNumber = "";
         AssignAttri("", false, "A346ReceptionistPhoneNumber", A346ReceptionistPhoneNumber);
         A95ReceptionistGAMGUID = "";
         AssignAttri("", false, "A95ReceptionistGAMGUID", A95ReceptionistGAMGUID);
         A369ReceptionistIsActive = false;
         AssignAttri("", false, "A369ReceptionistIsActive", A369ReceptionistIsActive);
         A447ReceptionistImage = "";
         AssignAttri("", false, "A447ReceptionistImage", A447ReceptionistImage);
         A40000ReceptionistImage_GXI = "";
         AssignAttri("", false, "A40000ReceptionistImage_GXI", A40000ReceptionistImage_GXI);
         Z345ReceptionistPhoneCode = "";
         Z92ReceptionistInitials = "";
         Z94ReceptionistPhone = "";
         Z90ReceptionistGivenName = "";
         Z91ReceptionistLastName = "";
         Z93ReceptionistEmail = "";
         Z346ReceptionistPhoneNumber = "";
         Z95ReceptionistGAMGUID = "";
         Z369ReceptionistIsActive = false;
      }

      protected void InitAll0C63( )
      {
         A89ReceptionistId = Guid.NewGuid( );
         AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
         A11OrganisationId = Guid.Empty;
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         A29LocationId = Guid.Empty;
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         InitializeNonKey0C63( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20257212483146", true, true);
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
         context.AddJavascriptSource("trn_receptionist.js", "?20257212483149", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         dynLocationId_Internalname = "LOCATIONID";
         edtReceptionistGivenName_Internalname = "RECEPTIONISTGIVENNAME";
         edtReceptionistLastName_Internalname = "RECEPTIONISTLASTNAME";
         edtReceptionistEmail_Internalname = "RECEPTIONISTEMAIL";
         edtReceptionistPhone_Internalname = "RECEPTIONISTPHONE";
         divReceptionistphone_cell_Internalname = "RECEPTIONISTPHONE_CELL";
         lblPhone_Internalname = "PHONE";
         Combo_receptionistphonecode_Internalname = "COMBO_RECEPTIONISTPHONECODE";
         edtReceptionistPhoneCode_Internalname = "RECEPTIONISTPHONECODE";
         divUnnamedtablereceptionistphonecode_Internalname = "UNNAMEDTABLERECEPTIONISTPHONECODE";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         edtReceptionistPhoneNumber_Internalname = "RECEPTIONISTPHONENUMBER";
         divTable_Internalname = "TABLE";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         chkReceptionistIsActive_Internalname = "RECEPTIONISTISACTIVE";
         divReceptionistisactive_cell_Internalname = "RECEPTIONISTISACTIVE_CELL";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavComboreceptionistphonecode_Internalname = "vCOMBORECEPTIONISTPHONECODE";
         divSectionattribute_receptionistphonecode_Internalname = "SECTIONATTRIBUTE_RECEPTIONISTPHONECODE";
         edtReceptionistId_Internalname = "RECEPTIONISTID";
         edtOrganisationId_Internalname = "ORGANISATIONID";
         edtReceptionistInitials_Internalname = "RECEPTIONISTINITIALS";
         edtReceptionistGAMGUID_Internalname = "RECEPTIONISTGAMGUID";
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
         Form.Caption = context.GetMessage( "Receptionist", "");
         Combo_receptionistphonecode_Htmltemplate = "";
         edtReceptionistGAMGUID_Jsonclick = "";
         edtReceptionistGAMGUID_Enabled = 1;
         edtReceptionistGAMGUID_Visible = 1;
         edtReceptionistInitials_Jsonclick = "";
         edtReceptionistInitials_Enabled = 1;
         edtReceptionistInitials_Visible = 1;
         edtOrganisationId_Jsonclick = "";
         edtOrganisationId_Enabled = 1;
         edtOrganisationId_Visible = 1;
         edtReceptionistId_Jsonclick = "";
         edtReceptionistId_Enabled = 1;
         edtReceptionistId_Visible = 1;
         edtavComboreceptionistphonecode_Jsonclick = "";
         edtavComboreceptionistphonecode_Enabled = 0;
         edtavComboreceptionistphonecode_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         chkReceptionistIsActive.Enabled = 1;
         chkReceptionistIsActive.Visible = 1;
         divReceptionistisactive_cell_Class = "col-xs-12 col-sm-6";
         edtReceptionistPhoneNumber_Jsonclick = "";
         edtReceptionistPhoneNumber_Class = "Attribute";
         edtReceptionistPhoneNumber_Enabled = 1;
         edtReceptionistPhoneCode_Jsonclick = "";
         edtReceptionistPhoneCode_Enabled = 1;
         edtReceptionistPhoneCode_Visible = 1;
         Combo_receptionistphonecode_Emptyitem = Convert.ToBoolean( 0);
         Combo_receptionistphonecode_Cls = "ExtendedCombo DropDownComponent ExtendedComboWithImage";
         Combo_receptionistphonecode_Caption = "";
         Combo_receptionistphonecode_Enabled = Convert.ToBoolean( -1);
         divTable_Class = "Table";
         divUnnamedtable2_Visible = 1;
         edtReceptionistPhone_Jsonclick = "";
         edtReceptionistPhone_Enabled = 1;
         edtReceptionistPhone_Visible = 1;
         divReceptionistphone_cell_Class = "col-xs-12 col-sm-6";
         edtReceptionistEmail_Jsonclick = "";
         edtReceptionistEmail_Enabled = 1;
         edtReceptionistLastName_Jsonclick = "";
         edtReceptionistLastName_Enabled = 1;
         edtReceptionistGivenName_Jsonclick = "";
         edtReceptionistGivenName_Enabled = 1;
         dynLocationId_Jsonclick = "";
         dynLocationId.Enabled = 1;
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

      protected void GXDLALOCATIONID0C63( Guid AV21OrganisationId )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLALOCATIONID_data0C63( AV21OrganisationId) ;
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

      protected void GXALOCATIONID_html0C63( Guid AV21OrganisationId )
      {
         Guid gxdynajaxvalue;
         GXDLALOCATIONID_data0C63( AV21OrganisationId) ;
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

      protected void GXDLALOCATIONID_data0C63( Guid AV21OrganisationId )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000C16 */
         pr_default.execute(14, new Object[] {AV21OrganisationId});
         while ( (pr_default.getStatus(14) != 101) )
         {
            gxdynajaxctrlcodr.Add(T000C16_A29LocationId[0].ToString());
            gxdynajaxctrldescr.Add(T000C16_A31LocationName[0]);
            pr_default.readNext(14);
         }
         pr_default.close(14);
      }

      protected void GX7ASAORGANISATIONID0C63( Guid AV21OrganisationId )
      {
         if ( ! (Guid.Empty==AV21OrganisationId) )
         {
            A11OrganisationId = AV21OrganisationId;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         else
         {
            GXt_guid1 = A11OrganisationId;
            new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
            A11OrganisationId = GXt_guid1;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A11OrganisationId.ToString())+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX18ASARECEPTIONISTPHONE0C63( string A345ReceptionistPhoneCode ,
                                                   string A346ReceptionistPhoneNumber )
      {
         GXt_char3 = A94ReceptionistPhone;
         new prc_concatenateintlphone(context ).execute(  A345ReceptionistPhoneCode,  A346ReceptionistPhoneNumber, out  GXt_char3) ;
         A94ReceptionistPhone = GXt_char3;
         AssignAttri("", false, "A94ReceptionistPhone", A94ReceptionistPhone);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A94ReceptionistPhone))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX19ASAISGAMACTIVE0C63( string A95ReceptionistGAMGUID )
      {
         GXt_boolean5 = AV37IsGAMActive;
         new prc_checkgamuseractivationstatus(context ).execute(  A95ReceptionistGAMGUID, out  GXt_boolean5) ;
         AV37IsGAMActive = GXt_boolean5;
         AssignAttri("", false, "AV37IsGAMActive", AV37IsGAMActive);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( AV37IsGAMActive))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_29_0C63( WorkWithPlus.workwithplus_web.SdtAuditingObject AV36AuditingObject ,
                                 Guid A89ReceptionistId ,
                                 Guid A11OrganisationId ,
                                 Guid A29LocationId ,
                                 string Gx_mode )
      {
         new loadaudittrn_receptionist(context ).execute(  "Y", ref  AV36AuditingObject,  A89ReceptionistId,  A11OrganisationId,  A29LocationId,  Gx_mode) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV36AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_30_0C63( WorkWithPlus.workwithplus_web.SdtAuditingObject AV36AuditingObject ,
                                 Guid A89ReceptionistId ,
                                 Guid A11OrganisationId ,
                                 Guid A29LocationId ,
                                 string Gx_mode )
      {
         new loadaudittrn_receptionist(context ).execute(  "Y", ref  AV36AuditingObject,  A89ReceptionistId,  A11OrganisationId,  A29LocationId,  Gx_mode) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV36AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_31_0C63( string Gx_mode ,
                                 WorkWithPlus.workwithplus_web.SdtAuditingObject AV36AuditingObject ,
                                 Guid A89ReceptionistId ,
                                 Guid A11OrganisationId ,
                                 Guid A29LocationId )
      {
         if ( IsIns( )  )
         {
            new loadaudittrn_receptionist(context ).execute(  "N", ref  AV36AuditingObject,  A89ReceptionistId,  A11OrganisationId,  A29LocationId,  Gx_mode) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV36AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_32_0C63( string Gx_mode ,
                                 WorkWithPlus.workwithplus_web.SdtAuditingObject AV36AuditingObject ,
                                 Guid A89ReceptionistId ,
                                 Guid A11OrganisationId ,
                                 Guid A29LocationId )
      {
         if ( IsUpd( )  )
         {
            new loadaudittrn_receptionist(context ).execute(  "N", ref  AV36AuditingObject,  A89ReceptionistId,  A11OrganisationId,  A29LocationId,  Gx_mode) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV36AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_33_0C63( string A93ReceptionistEmail ,
                                 string A90ReceptionistGivenName ,
                                 string A91ReceptionistLastName ,
                                 string A95ReceptionistGAMGUID ,
                                 string AV14GAMErrorResponse ,
                                 string Gx_mode )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, context.GetMessage( "INS", "")) == 0 ) && String.IsNullOrEmpty(StringUtil.RTrim( A95ReceptionistGAMGUID)) )
         {
            new prc_creategamuseraccount(context ).execute(  A93ReceptionistEmail,  A90ReceptionistGivenName,  A91ReceptionistLastName,  "Receptionist", ref  A95ReceptionistGAMGUID, ref  AV14GAMErrorResponse) ;
            AssignAttri("", false, "A95ReceptionistGAMGUID", A95ReceptionistGAMGUID);
            AssignAttri("", false, "AV14GAMErrorResponse", AV14GAMErrorResponse);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A95ReceptionistGAMGUID)+"\""+","+"\""+GXUtil.EncodeJSConstant( AV14GAMErrorResponse)+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_35_0C63( string A90ReceptionistGivenName ,
                                 string A91ReceptionistLastName )
      {
         new prc_getnameinitials(context ).execute(  A90ReceptionistGivenName,  A91ReceptionistLastName, out  A92ReceptionistInitials) ;
         AssignAttri("", false, "A92ReceptionistInitials", A92ReceptionistInitials);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A92ReceptionistInitials))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_36_0C63( string Gx_mode ,
                                 string A95ReceptionistGAMGUID ,
                                 string A90ReceptionistGivenName ,
                                 string A91ReceptionistLastName ,
                                 string A345ReceptionistPhoneCode ,
                                 string A346ReceptionistPhoneNumber ,
                                 string A447ReceptionistImage ,
                                 bool A369ReceptionistIsActive )
      {
         if ( IsUpd( )  )
         {
            new prc_updategamuseraccount(context ).execute(  A95ReceptionistGAMGUID,  A90ReceptionistGivenName,  A91ReceptionistLastName,  A345ReceptionistPhoneCode,  A346ReceptionistPhoneNumber,  A447ReceptionistImage,  A369ReceptionistIsActive,  "Receptionist", out  AV14GAMErrorResponse) ;
            AssignAttri("", false, "AV14GAMErrorResponse", AV14GAMErrorResponse);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( AV14GAMErrorResponse)+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_38_0C63( string Gx_mode ,
                                 string A95ReceptionistGAMGUID )
      {
         if ( IsDlt( )  )
         {
            new prc_deletegamuseraccount(context ).execute(  A95ReceptionistGAMGUID, out  AV14GAMErrorResponse) ;
            AssignAttri("", false, "AV14GAMErrorResponse", AV14GAMErrorResponse);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( AV14GAMErrorResponse)+"\"") ;
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
         chkReceptionistIsActive.Name = "RECEPTIONISTISACTIVE";
         chkReceptionistIsActive.WebTags = "";
         chkReceptionistIsActive.Caption = context.GetMessage( "Is Active", "");
         AssignProp("", false, chkReceptionistIsActive_Internalname, "TitleCaption", chkReceptionistIsActive.Caption, true);
         chkReceptionistIsActive.CheckedValue = "false";
         A369ReceptionistIsActive = StringUtil.StrToBool( StringUtil.BoolToStr( A369ReceptionistIsActive));
         AssignAttri("", false, "A369ReceptionistIsActive", A369ReceptionistIsActive);
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
         /* Using cursor T000C17 */
         pr_default.execute(15, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = dynLocationId_Internalname;
         }
         pr_default.close(15);
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
      }

      public void Valid_Receptionistphonenumber( )
      {
         A29LocationId = StringUtil.StrToGuid( dynLocationId.CurrentValue);
         GXt_char3 = A94ReceptionistPhone;
         new prc_concatenateintlphone(context ).execute(  A345ReceptionistPhoneCode,  A346ReceptionistPhoneNumber, out  GXt_char3) ;
         A94ReceptionistPhone = GXt_char3;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A346ReceptionistPhoneNumber)) && ! GxRegex.IsMatch(A346ReceptionistPhoneNumber,context.GetMessage( "^\\d{9}$", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Phone contains 9 digits", ""), 1, "RECEPTIONISTPHONENUMBER");
            AnyError = 1;
            GX_FocusControl = edtReceptionistPhoneNumber_Internalname;
         }
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
         AssignAttri("", false, "A94ReceptionistPhone", StringUtil.RTrim( A94ReceptionistPhone));
      }

      public void Valid_Receptionistgamguid( )
      {
         A29LocationId = StringUtil.StrToGuid( dynLocationId.CurrentValue);
         GXt_boolean5 = AV37IsGAMActive;
         new prc_checkgamuseractivationstatus(context ).execute(  A95ReceptionistGAMGUID, out  GXt_boolean5) ;
         AV37IsGAMActive = GXt_boolean5;
         chkReceptionistIsActive.Visible = ((AV37IsGAMActive) ? 1 : 0);
         if ( ! ( ( AV37IsGAMActive ) ) )
         {
            divReceptionistisactive_cell_Class = context.GetMessage( "Invisible", "");
         }
         else
         {
            if ( AV37IsGAMActive )
            {
               divReceptionistisactive_cell_Class = context.GetMessage( "col-xs-12 col-sm-6 DataContentCell", "");
            }
         }
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
         AssignAttri("", false, "AV37IsGAMActive", AV37IsGAMActive);
         AssignProp("", false, chkReceptionistIsActive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkReceptionistIsActive.Visible), 5, 0), true);
         AssignProp("", false, divReceptionistisactive_cell_Internalname, "Class", divReceptionistisactive_cell_Class, true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV23ReceptionistId","fld":"vRECEPTIONISTID","hsh":true},{"av":"AV19LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV21OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV21OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV25TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV23ReceptionistId","fld":"vRECEPTIONISTID","hsh":true},{"av":"AV19LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV42Pgmname","fld":"vPGMNAME"},{"av":"AV21OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV21OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120C2","iparms":[{"av":"AV36AuditingObject","fld":"vAUDITINGOBJECT"},{"av":"AV42Pgmname","fld":"vPGMNAME"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV25TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV21OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"}]""");
         setEventMetadata("AFTER TRN",""","oparms":[{"av":"AV21OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"}]}""");
         setEventMetadata("VALID_LOCATIONID","""{"handler":"Valid_Locationid","iparms":[{"av":"AV21OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"}]""");
         setEventMetadata("VALID_LOCATIONID",""","oparms":[{"av":"AV21OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"}]}""");
         setEventMetadata("VALID_RECEPTIONISTGIVENNAME","""{"handler":"Valid_Receptionistgivenname","iparms":[{"av":"AV21OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"}]""");
         setEventMetadata("VALID_RECEPTIONISTGIVENNAME",""","oparms":[{"av":"AV21OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"}]}""");
         setEventMetadata("VALID_RECEPTIONISTLASTNAME","""{"handler":"Valid_Receptionistlastname","iparms":[{"av":"AV21OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"}]""");
         setEventMetadata("VALID_RECEPTIONISTLASTNAME",""","oparms":[{"av":"AV21OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"}]}""");
         setEventMetadata("VALID_RECEPTIONISTEMAIL","""{"handler":"Valid_Receptionistemail","iparms":[{"av":"AV21OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"}]""");
         setEventMetadata("VALID_RECEPTIONISTEMAIL",""","oparms":[{"av":"AV21OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"}]}""");
         setEventMetadata("VALID_RECEPTIONISTPHONECODE","""{"handler":"Valid_Receptionistphonecode","iparms":[{"av":"AV21OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"}]""");
         setEventMetadata("VALID_RECEPTIONISTPHONECODE",""","oparms":[{"av":"AV21OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"}]}""");
         setEventMetadata("VALID_RECEPTIONISTPHONENUMBER","""{"handler":"Valid_Receptionistphonenumber","iparms":[{"av":"A345ReceptionistPhoneCode","fld":"RECEPTIONISTPHONECODE"},{"av":"A346ReceptionistPhoneNumber","fld":"RECEPTIONISTPHONENUMBER"},{"av":"A94ReceptionistPhone","fld":"RECEPTIONISTPHONE"},{"av":"AV21OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"}]""");
         setEventMetadata("VALID_RECEPTIONISTPHONENUMBER",""","oparms":[{"av":"A94ReceptionistPhone","fld":"RECEPTIONISTPHONE"},{"av":"AV21OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"}]}""");
         setEventMetadata("VALID_RECEPTIONISTISACTIVE","""{"handler":"Valid_Receptionistisactive","iparms":[{"av":"AV21OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"}]""");
         setEventMetadata("VALID_RECEPTIONISTISACTIVE",""","oparms":[{"av":"AV21OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"}]}""");
         setEventMetadata("VALIDV_COMBORECEPTIONISTPHONECODE","""{"handler":"Validv_Comboreceptionistphonecode","iparms":[{"av":"AV21OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"}]""");
         setEventMetadata("VALIDV_COMBORECEPTIONISTPHONECODE",""","oparms":[{"av":"AV21OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"}]}""");
         setEventMetadata("VALID_RECEPTIONISTID","""{"handler":"Valid_Receptionistid","iparms":[{"av":"AV21OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"}]""");
         setEventMetadata("VALID_RECEPTIONISTID",""","oparms":[{"av":"AV21OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"}]}""");
         setEventMetadata("VALID_ORGANISATIONID","""{"handler":"Valid_Organisationid","iparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV21OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"}]""");
         setEventMetadata("VALID_ORGANISATIONID",""","oparms":[{"av":"AV21OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"}]}""");
         setEventMetadata("VALID_RECEPTIONISTGAMGUID","""{"handler":"Valid_Receptionistgamguid","iparms":[{"av":"A95ReceptionistGAMGUID","fld":"RECEPTIONISTGAMGUID"},{"av":"AV37IsGAMActive","fld":"vISGAMACTIVE"},{"av":"AV21OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"}]""");
         setEventMetadata("VALID_RECEPTIONISTGAMGUID",""","oparms":[{"av":"AV37IsGAMActive","fld":"vISGAMACTIVE"},{"av":"chkReceptionistIsActive.Visible","ctrl":"RECEPTIONISTISACTIVE","prop":"Visible"},{"av":"divReceptionistisactive_cell_Class","ctrl":"RECEPTIONISTISACTIVE_CELL","prop":"Class"},{"av":"AV21OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"}]}""");
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
         wcpOAV23ReceptionistId = Guid.Empty;
         wcpOAV21OrganisationId = Guid.Empty;
         wcpOAV19LocationId = Guid.Empty;
         Z89ReceptionistId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         Z345ReceptionistPhoneCode = "";
         Z92ReceptionistInitials = "";
         Z94ReceptionistPhone = "";
         Z90ReceptionistGivenName = "";
         Z91ReceptionistLastName = "";
         Z93ReceptionistEmail = "";
         Z346ReceptionistPhoneNumber = "";
         Z95ReceptionistGAMGUID = "";
         Combo_receptionistphonecode_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A93ReceptionistEmail = "";
         A90ReceptionistGivenName = "";
         A91ReceptionistLastName = "";
         A95ReceptionistGAMGUID = "";
         AV14GAMErrorResponse = "";
         A345ReceptionistPhoneCode = "";
         A346ReceptionistPhoneNumber = "";
         A447ReceptionistImage = "";
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
         gxphoneLink = "";
         A94ReceptionistPhone = "";
         lblPhone_Jsonclick = "";
         ucCombo_receptionistphonecode = new GXUserControl();
         AV13DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV34ReceptionistPhoneCode_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV31ComboReceptionistPhoneCode = "";
         A89ReceptionistId = Guid.Empty;
         A92ReceptionistInitials = "";
         AV36AuditingObject = new WorkWithPlus.workwithplus_web.SdtAuditingObject(context);
         A40000ReceptionistImage_GXI = "";
         AV42Pgmname = "";
         Combo_receptionistphonecode_Objectcall = "";
         Combo_receptionistphonecode_Class = "";
         Combo_receptionistphonecode_Icontype = "";
         Combo_receptionistphonecode_Icon = "";
         Combo_receptionistphonecode_Tooltip = "";
         Combo_receptionistphonecode_Selectedvalue_set = "";
         Combo_receptionistphonecode_Selectedtext_set = "";
         Combo_receptionistphonecode_Selectedtext_get = "";
         Combo_receptionistphonecode_Gamoauthtoken = "";
         Combo_receptionistphonecode_Ddointernalname = "";
         Combo_receptionistphonecode_Titlecontrolalign = "";
         Combo_receptionistphonecode_Dropdownoptionstype = "";
         Combo_receptionistphonecode_Titlecontrolidtoreplace = "";
         Combo_receptionistphonecode_Datalisttype = "";
         Combo_receptionistphonecode_Datalistfixedvalues = "";
         Combo_receptionistphonecode_Datalistproc = "";
         Combo_receptionistphonecode_Datalistprocparametersprefix = "";
         Combo_receptionistphonecode_Remoteservicesparameters = "";
         Combo_receptionistphonecode_Multiplevaluestype = "";
         Combo_receptionistphonecode_Loadingdata = "";
         Combo_receptionistphonecode_Noresultsfound = "";
         Combo_receptionistphonecode_Emptyitemtext = "";
         Combo_receptionistphonecode_Onlyselectedvalues = "";
         Combo_receptionistphonecode_Selectalltext = "";
         Combo_receptionistphonecode_Multiplevaluesseparator = "";
         Combo_receptionistphonecode_Addnewoptiontext = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode63 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV29WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV25TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV28WebSession = context.GetSession();
         AV32defaultCountryPhoneCode = "";
         AV38Session = context.GetSession();
         GXt_objcol_SdtDVB_SDTComboData_Item4 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV11ComboSelectedValue = "";
         AV10ComboSelectedText = "";
         Z447ReceptionistImage = "";
         Z40000ReceptionistImage_GXI = "";
         T000C5_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         T000C5_A345ReceptionistPhoneCode = new string[] {""} ;
         T000C5_A92ReceptionistInitials = new string[] {""} ;
         T000C5_A94ReceptionistPhone = new string[] {""} ;
         T000C5_A90ReceptionistGivenName = new string[] {""} ;
         T000C5_A91ReceptionistLastName = new string[] {""} ;
         T000C5_A93ReceptionistEmail = new string[] {""} ;
         T000C5_A346ReceptionistPhoneNumber = new string[] {""} ;
         T000C5_A95ReceptionistGAMGUID = new string[] {""} ;
         T000C5_A369ReceptionistIsActive = new bool[] {false} ;
         T000C5_A40000ReceptionistImage_GXI = new string[] {""} ;
         T000C5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000C5_A29LocationId = new Guid[] {Guid.Empty} ;
         T000C5_A447ReceptionistImage = new string[] {""} ;
         T000C4_A29LocationId = new Guid[] {Guid.Empty} ;
         T000C6_A29LocationId = new Guid[] {Guid.Empty} ;
         T000C7_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         T000C7_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000C7_A29LocationId = new Guid[] {Guid.Empty} ;
         T000C3_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         T000C3_A345ReceptionistPhoneCode = new string[] {""} ;
         T000C3_A92ReceptionistInitials = new string[] {""} ;
         T000C3_A94ReceptionistPhone = new string[] {""} ;
         T000C3_A90ReceptionistGivenName = new string[] {""} ;
         T000C3_A91ReceptionistLastName = new string[] {""} ;
         T000C3_A93ReceptionistEmail = new string[] {""} ;
         T000C3_A346ReceptionistPhoneNumber = new string[] {""} ;
         T000C3_A95ReceptionistGAMGUID = new string[] {""} ;
         T000C3_A369ReceptionistIsActive = new bool[] {false} ;
         T000C3_A40000ReceptionistImage_GXI = new string[] {""} ;
         T000C3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000C3_A29LocationId = new Guid[] {Guid.Empty} ;
         T000C3_A447ReceptionistImage = new string[] {""} ;
         T000C8_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         T000C8_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000C8_A29LocationId = new Guid[] {Guid.Empty} ;
         T000C9_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         T000C9_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000C9_A29LocationId = new Guid[] {Guid.Empty} ;
         T000C2_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         T000C2_A345ReceptionistPhoneCode = new string[] {""} ;
         T000C2_A92ReceptionistInitials = new string[] {""} ;
         T000C2_A94ReceptionistPhone = new string[] {""} ;
         T000C2_A90ReceptionistGivenName = new string[] {""} ;
         T000C2_A91ReceptionistLastName = new string[] {""} ;
         T000C2_A93ReceptionistEmail = new string[] {""} ;
         T000C2_A346ReceptionistPhoneNumber = new string[] {""} ;
         T000C2_A95ReceptionistGAMGUID = new string[] {""} ;
         T000C2_A369ReceptionistIsActive = new bool[] {false} ;
         T000C2_A40000ReceptionistImage_GXI = new string[] {""} ;
         T000C2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000C2_A29LocationId = new Guid[] {Guid.Empty} ;
         T000C2_A447ReceptionistImage = new string[] {""} ;
         T000C14_A29LocationId = new Guid[] {Guid.Empty} ;
         T000C14_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000C15_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         T000C15_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000C15_A29LocationId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T000C16_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000C16_A29LocationId = new Guid[] {Guid.Empty} ;
         T000C16_A31LocationName = new string[] {""} ;
         GXt_guid1 = Guid.Empty;
         T000C17_A29LocationId = new Guid[] {Guid.Empty} ;
         GXt_char3 = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_receptionist__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_receptionist__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_receptionist__default(),
            new Object[][] {
                new Object[] {
               T000C2_A89ReceptionistId, T000C2_A345ReceptionistPhoneCode, T000C2_A92ReceptionistInitials, T000C2_A94ReceptionistPhone, T000C2_A90ReceptionistGivenName, T000C2_A91ReceptionistLastName, T000C2_A93ReceptionistEmail, T000C2_A346ReceptionistPhoneNumber, T000C2_A95ReceptionistGAMGUID, T000C2_A369ReceptionistIsActive,
               T000C2_A40000ReceptionistImage_GXI, T000C2_A11OrganisationId, T000C2_A29LocationId, T000C2_A447ReceptionistImage
               }
               , new Object[] {
               T000C3_A89ReceptionistId, T000C3_A345ReceptionistPhoneCode, T000C3_A92ReceptionistInitials, T000C3_A94ReceptionistPhone, T000C3_A90ReceptionistGivenName, T000C3_A91ReceptionistLastName, T000C3_A93ReceptionistEmail, T000C3_A346ReceptionistPhoneNumber, T000C3_A95ReceptionistGAMGUID, T000C3_A369ReceptionistIsActive,
               T000C3_A40000ReceptionistImage_GXI, T000C3_A11OrganisationId, T000C3_A29LocationId, T000C3_A447ReceptionistImage
               }
               , new Object[] {
               T000C4_A29LocationId
               }
               , new Object[] {
               T000C5_A89ReceptionistId, T000C5_A345ReceptionistPhoneCode, T000C5_A92ReceptionistInitials, T000C5_A94ReceptionistPhone, T000C5_A90ReceptionistGivenName, T000C5_A91ReceptionistLastName, T000C5_A93ReceptionistEmail, T000C5_A346ReceptionistPhoneNumber, T000C5_A95ReceptionistGAMGUID, T000C5_A369ReceptionistIsActive,
               T000C5_A40000ReceptionistImage_GXI, T000C5_A11OrganisationId, T000C5_A29LocationId, T000C5_A447ReceptionistImage
               }
               , new Object[] {
               T000C6_A29LocationId
               }
               , new Object[] {
               T000C7_A89ReceptionistId, T000C7_A11OrganisationId, T000C7_A29LocationId
               }
               , new Object[] {
               T000C8_A89ReceptionistId, T000C8_A11OrganisationId, T000C8_A29LocationId
               }
               , new Object[] {
               T000C9_A89ReceptionistId, T000C9_A11OrganisationId, T000C9_A29LocationId
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
               T000C14_A29LocationId, T000C14_A11OrganisationId
               }
               , new Object[] {
               T000C15_A89ReceptionistId, T000C15_A11OrganisationId, T000C15_A29LocationId
               }
               , new Object[] {
               T000C16_A11OrganisationId, T000C16_A29LocationId, T000C16_A31LocationName
               }
               , new Object[] {
               T000C17_A29LocationId
               }
            }
         );
         Z89ReceptionistId = Guid.NewGuid( );
         A89ReceptionistId = Guid.NewGuid( );
         AV42Pgmname = "Trn_Receptionist";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound63 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtReceptionistGivenName_Enabled ;
      private int edtReceptionistLastName_Enabled ;
      private int edtReceptionistEmail_Enabled ;
      private int edtReceptionistPhone_Visible ;
      private int edtReceptionistPhone_Enabled ;
      private int divUnnamedtable2_Visible ;
      private int edtReceptionistPhoneCode_Visible ;
      private int edtReceptionistPhoneCode_Enabled ;
      private int edtReceptionistPhoneNumber_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavComboreceptionistphonecode_Visible ;
      private int edtavComboreceptionistphonecode_Enabled ;
      private int edtReceptionistId_Visible ;
      private int edtReceptionistId_Enabled ;
      private int edtOrganisationId_Visible ;
      private int edtOrganisationId_Enabled ;
      private int edtReceptionistInitials_Visible ;
      private int edtReceptionistInitials_Enabled ;
      private int edtReceptionistGAMGUID_Visible ;
      private int edtReceptionistGAMGUID_Enabled ;
      private int Combo_receptionistphonecode_Datalistupdateminimumcharacters ;
      private int Combo_receptionistphonecode_Gxcontroltype ;
      private int idxLst ;
      private int gxdynajaxindex ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z92ReceptionistInitials ;
      private string Z94ReceptionistPhone ;
      private string Combo_receptionistphonecode_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string GXDecQS ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string dynLocationId_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string dynLocationId_Jsonclick ;
      private string edtReceptionistGivenName_Internalname ;
      private string edtReceptionistGivenName_Jsonclick ;
      private string edtReceptionistLastName_Internalname ;
      private string edtReceptionistLastName_Jsonclick ;
      private string edtReceptionistEmail_Internalname ;
      private string edtReceptionistEmail_Jsonclick ;
      private string divReceptionistphone_cell_Internalname ;
      private string divReceptionistphone_cell_Class ;
      private string edtReceptionistPhone_Internalname ;
      private string gxphoneLink ;
      private string A94ReceptionistPhone ;
      private string edtReceptionistPhone_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string lblPhone_Internalname ;
      private string lblPhone_Jsonclick ;
      private string divTable_Internalname ;
      private string divTable_Class ;
      private string divUnnamedtable3_Internalname ;
      private string divUnnamedtablereceptionistphonecode_Internalname ;
      private string Combo_receptionistphonecode_Caption ;
      private string Combo_receptionistphonecode_Cls ;
      private string Combo_receptionistphonecode_Internalname ;
      private string edtReceptionistPhoneCode_Internalname ;
      private string edtReceptionistPhoneCode_Jsonclick ;
      private string edtReceptionistPhoneNumber_Internalname ;
      private string edtReceptionistPhoneNumber_Jsonclick ;
      private string edtReceptionistPhoneNumber_Class ;
      private string divReceptionistisactive_cell_Internalname ;
      private string divReceptionistisactive_cell_Class ;
      private string chkReceptionistIsActive_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_receptionistphonecode_Internalname ;
      private string edtavComboreceptionistphonecode_Internalname ;
      private string edtavComboreceptionistphonecode_Jsonclick ;
      private string edtReceptionistId_Internalname ;
      private string edtReceptionistId_Jsonclick ;
      private string edtOrganisationId_Internalname ;
      private string edtOrganisationId_Jsonclick ;
      private string edtReceptionistInitials_Internalname ;
      private string A92ReceptionistInitials ;
      private string edtReceptionistInitials_Jsonclick ;
      private string edtReceptionistGAMGUID_Internalname ;
      private string edtReceptionistGAMGUID_Jsonclick ;
      private string AV42Pgmname ;
      private string Combo_receptionistphonecode_Objectcall ;
      private string Combo_receptionistphonecode_Class ;
      private string Combo_receptionistphonecode_Icontype ;
      private string Combo_receptionistphonecode_Icon ;
      private string Combo_receptionistphonecode_Tooltip ;
      private string Combo_receptionistphonecode_Selectedvalue_set ;
      private string Combo_receptionistphonecode_Selectedtext_set ;
      private string Combo_receptionistphonecode_Selectedtext_get ;
      private string Combo_receptionistphonecode_Gamoauthtoken ;
      private string Combo_receptionistphonecode_Ddointernalname ;
      private string Combo_receptionistphonecode_Titlecontrolalign ;
      private string Combo_receptionistphonecode_Dropdownoptionstype ;
      private string Combo_receptionistphonecode_Titlecontrolidtoreplace ;
      private string Combo_receptionistphonecode_Datalisttype ;
      private string Combo_receptionistphonecode_Datalistfixedvalues ;
      private string Combo_receptionistphonecode_Datalistproc ;
      private string Combo_receptionistphonecode_Datalistprocparametersprefix ;
      private string Combo_receptionistphonecode_Remoteservicesparameters ;
      private string Combo_receptionistphonecode_Htmltemplate ;
      private string Combo_receptionistphonecode_Multiplevaluestype ;
      private string Combo_receptionistphonecode_Loadingdata ;
      private string Combo_receptionistphonecode_Noresultsfound ;
      private string Combo_receptionistphonecode_Emptyitemtext ;
      private string Combo_receptionistphonecode_Onlyselectedvalues ;
      private string Combo_receptionistphonecode_Selectalltext ;
      private string Combo_receptionistphonecode_Multiplevaluesseparator ;
      private string Combo_receptionistphonecode_Addnewoptiontext ;
      private string hsh ;
      private string sMode63 ;
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
      private string gxwrpcisep ;
      private string GXt_char3 ;
      private bool Z369ReceptionistIsActive ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool A369ReceptionistIsActive ;
      private bool wbErr ;
      private bool Combo_receptionistphonecode_Emptyitem ;
      private bool AV37IsGAMActive ;
      private bool Combo_receptionistphonecode_Enabled ;
      private bool Combo_receptionistphonecode_Visible ;
      private bool Combo_receptionistphonecode_Allowmultipleselection ;
      private bool Combo_receptionistphonecode_Isgriditem ;
      private bool Combo_receptionistphonecode_Hasdescription ;
      private bool Combo_receptionistphonecode_Includeonlyselectedoption ;
      private bool Combo_receptionistphonecode_Includeselectalloption ;
      private bool Combo_receptionistphonecode_Includeaddnewoption ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool gxdyncontrolsrefreshing ;
      private bool GXt_boolean5 ;
      private bool ZV37IsGAMActive ;
      private string AV14GAMErrorResponse ;
      private string Z345ReceptionistPhoneCode ;
      private string Z90ReceptionistGivenName ;
      private string Z91ReceptionistLastName ;
      private string Z93ReceptionistEmail ;
      private string Z346ReceptionistPhoneNumber ;
      private string Z95ReceptionistGAMGUID ;
      private string A93ReceptionistEmail ;
      private string A90ReceptionistGivenName ;
      private string A91ReceptionistLastName ;
      private string A95ReceptionistGAMGUID ;
      private string A345ReceptionistPhoneCode ;
      private string A346ReceptionistPhoneNumber ;
      private string AV31ComboReceptionistPhoneCode ;
      private string A40000ReceptionistImage_GXI ;
      private string AV32defaultCountryPhoneCode ;
      private string AV11ComboSelectedValue ;
      private string AV10ComboSelectedText ;
      private string Z40000ReceptionistImage_GXI ;
      private string A447ReceptionistImage ;
      private string Z447ReceptionistImage ;
      private Guid wcpOAV23ReceptionistId ;
      private Guid wcpOAV21OrganisationId ;
      private Guid wcpOAV19LocationId ;
      private Guid Z89ReceptionistId ;
      private Guid Z11OrganisationId ;
      private Guid Z29LocationId ;
      private Guid AV21OrganisationId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid AV23ReceptionistId ;
      private Guid AV19LocationId ;
      private Guid A89ReceptionistId ;
      private Guid GXt_guid1 ;
      private IGxSession AV28WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucCombo_receptionistphonecode ;
      private IGxSession AV38Session ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynLocationId ;
      private GXCheckbox chkReceptionistIsActive ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV13DDO_TitleSettingsIcons ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV34ReceptionistPhoneCode_Data ;
      private WorkWithPlus.workwithplus_web.SdtAuditingObject AV36AuditingObject ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV29WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV25TrnContext ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> GXt_objcol_SdtDVB_SDTComboData_Item4 ;
      private IDataStoreProvider pr_default ;
      private Guid[] T000C5_A89ReceptionistId ;
      private string[] T000C5_A345ReceptionistPhoneCode ;
      private string[] T000C5_A92ReceptionistInitials ;
      private string[] T000C5_A94ReceptionistPhone ;
      private string[] T000C5_A90ReceptionistGivenName ;
      private string[] T000C5_A91ReceptionistLastName ;
      private string[] T000C5_A93ReceptionistEmail ;
      private string[] T000C5_A346ReceptionistPhoneNumber ;
      private string[] T000C5_A95ReceptionistGAMGUID ;
      private bool[] T000C5_A369ReceptionistIsActive ;
      private string[] T000C5_A40000ReceptionistImage_GXI ;
      private Guid[] T000C5_A11OrganisationId ;
      private Guid[] T000C5_A29LocationId ;
      private string[] T000C5_A447ReceptionistImage ;
      private Guid[] T000C4_A29LocationId ;
      private Guid[] T000C6_A29LocationId ;
      private Guid[] T000C7_A89ReceptionistId ;
      private Guid[] T000C7_A11OrganisationId ;
      private Guid[] T000C7_A29LocationId ;
      private Guid[] T000C3_A89ReceptionistId ;
      private string[] T000C3_A345ReceptionistPhoneCode ;
      private string[] T000C3_A92ReceptionistInitials ;
      private string[] T000C3_A94ReceptionistPhone ;
      private string[] T000C3_A90ReceptionistGivenName ;
      private string[] T000C3_A91ReceptionistLastName ;
      private string[] T000C3_A93ReceptionistEmail ;
      private string[] T000C3_A346ReceptionistPhoneNumber ;
      private string[] T000C3_A95ReceptionistGAMGUID ;
      private bool[] T000C3_A369ReceptionistIsActive ;
      private string[] T000C3_A40000ReceptionistImage_GXI ;
      private Guid[] T000C3_A11OrganisationId ;
      private Guid[] T000C3_A29LocationId ;
      private string[] T000C3_A447ReceptionistImage ;
      private Guid[] T000C8_A89ReceptionistId ;
      private Guid[] T000C8_A11OrganisationId ;
      private Guid[] T000C8_A29LocationId ;
      private Guid[] T000C9_A89ReceptionistId ;
      private Guid[] T000C9_A11OrganisationId ;
      private Guid[] T000C9_A29LocationId ;
      private Guid[] T000C2_A89ReceptionistId ;
      private string[] T000C2_A345ReceptionistPhoneCode ;
      private string[] T000C2_A92ReceptionistInitials ;
      private string[] T000C2_A94ReceptionistPhone ;
      private string[] T000C2_A90ReceptionistGivenName ;
      private string[] T000C2_A91ReceptionistLastName ;
      private string[] T000C2_A93ReceptionistEmail ;
      private string[] T000C2_A346ReceptionistPhoneNumber ;
      private string[] T000C2_A95ReceptionistGAMGUID ;
      private bool[] T000C2_A369ReceptionistIsActive ;
      private string[] T000C2_A40000ReceptionistImage_GXI ;
      private Guid[] T000C2_A11OrganisationId ;
      private Guid[] T000C2_A29LocationId ;
      private string[] T000C2_A447ReceptionistImage ;
      private Guid[] T000C14_A29LocationId ;
      private Guid[] T000C14_A11OrganisationId ;
      private Guid[] T000C15_A89ReceptionistId ;
      private Guid[] T000C15_A11OrganisationId ;
      private Guid[] T000C15_A29LocationId ;
      private Guid[] T000C16_A11OrganisationId ;
      private Guid[] T000C16_A29LocationId ;
      private string[] T000C16_A31LocationName ;
      private Guid[] T000C17_A29LocationId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_receptionist__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_receptionist__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_receptionist__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[14])
      ,new ForEachCursor(def[15])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT000C2;
       prmT000C2 = new Object[] {
       new ParDef("ReceptionistId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000C3;
       prmT000C3 = new Object[] {
       new ParDef("ReceptionistId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000C4;
       prmT000C4 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000C5;
       prmT000C5 = new Object[] {
       new ParDef("ReceptionistId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000C6;
       prmT000C6 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000C7;
       prmT000C7 = new Object[] {
       new ParDef("ReceptionistId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000C8;
       prmT000C8 = new Object[] {
       new ParDef("ReceptionistId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000C9;
       prmT000C9 = new Object[] {
       new ParDef("ReceptionistId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000C10;
       prmT000C10 = new Object[] {
       new ParDef("ReceptionistId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ReceptionistPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("ReceptionistInitials",GXType.Char,20,0) ,
       new ParDef("ReceptionistPhone",GXType.Char,20,0) ,
       new ParDef("ReceptionistGivenName",GXType.VarChar,100,0) ,
       new ParDef("ReceptionistLastName",GXType.VarChar,100,0) ,
       new ParDef("ReceptionistEmail",GXType.VarChar,100,0) ,
       new ParDef("ReceptionistPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("ReceptionistGAMGUID",GXType.VarChar,100,60) ,
       new ParDef("ReceptionistIsActive",GXType.Boolean,4,0) ,
       new ParDef("ReceptionistImage",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("ReceptionistImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=10, Tbl="Trn_Receptionist", Fld="ReceptionistImage"} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000C11;
       prmT000C11 = new Object[] {
       new ParDef("ReceptionistPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("ReceptionistInitials",GXType.Char,20,0) ,
       new ParDef("ReceptionistPhone",GXType.Char,20,0) ,
       new ParDef("ReceptionistGivenName",GXType.VarChar,100,0) ,
       new ParDef("ReceptionistLastName",GXType.VarChar,100,0) ,
       new ParDef("ReceptionistEmail",GXType.VarChar,100,0) ,
       new ParDef("ReceptionistPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("ReceptionistGAMGUID",GXType.VarChar,100,60) ,
       new ParDef("ReceptionistIsActive",GXType.Boolean,4,0) ,
       new ParDef("ReceptionistId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000C12;
       prmT000C12 = new Object[] {
       new ParDef("ReceptionistImage",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("ReceptionistImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Trn_Receptionist", Fld="ReceptionistImage"} ,
       new ParDef("ReceptionistId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000C13;
       prmT000C13 = new Object[] {
       new ParDef("ReceptionistId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000C14;
       prmT000C14 = new Object[] {
       new ParDef("ReceptionistId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000C15;
       prmT000C15 = new Object[] {
       };
       Object[] prmT000C16;
       prmT000C16 = new Object[] {
       new ParDef("AV21OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000C17;
       prmT000C17 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("T000C2", "SELECT ReceptionistId, ReceptionistPhoneCode, ReceptionistInitials, ReceptionistPhone, ReceptionistGivenName, ReceptionistLastName, ReceptionistEmail, ReceptionistPhoneNumber, ReceptionistGAMGUID, ReceptionistIsActive, ReceptionistImage_GXI, OrganisationId, LocationId, ReceptionistImage FROM Trn_Receptionist WHERE ReceptionistId = :ReceptionistId AND OrganisationId = :OrganisationId AND LocationId = :LocationId  FOR UPDATE OF Trn_Receptionist NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000C2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000C3", "SELECT ReceptionistId, ReceptionistPhoneCode, ReceptionistInitials, ReceptionistPhone, ReceptionistGivenName, ReceptionistLastName, ReceptionistEmail, ReceptionistPhoneNumber, ReceptionistGAMGUID, ReceptionistIsActive, ReceptionistImage_GXI, OrganisationId, LocationId, ReceptionistImage FROM Trn_Receptionist WHERE ReceptionistId = :ReceptionistId AND OrganisationId = :OrganisationId AND LocationId = :LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000C4", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000C5", "SELECT TM1.ReceptionistId, TM1.ReceptionistPhoneCode, TM1.ReceptionistInitials, TM1.ReceptionistPhone, TM1.ReceptionistGivenName, TM1.ReceptionistLastName, TM1.ReceptionistEmail, TM1.ReceptionistPhoneNumber, TM1.ReceptionistGAMGUID, TM1.ReceptionistIsActive, TM1.ReceptionistImage_GXI, TM1.OrganisationId, TM1.LocationId, TM1.ReceptionistImage FROM Trn_Receptionist TM1 WHERE TM1.ReceptionistId = :ReceptionistId and TM1.OrganisationId = :OrganisationId and TM1.LocationId = :LocationId ORDER BY TM1.ReceptionistId, TM1.OrganisationId, TM1.LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C5,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000C6", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000C7", "SELECT ReceptionistId, OrganisationId, LocationId FROM Trn_Receptionist WHERE ReceptionistId = :ReceptionistId AND OrganisationId = :OrganisationId AND LocationId = :LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000C8", "SELECT ReceptionistId, OrganisationId, LocationId FROM Trn_Receptionist WHERE ( ReceptionistId > :ReceptionistId or ReceptionistId = :ReceptionistId and OrganisationId > :OrganisationId or OrganisationId = :OrganisationId and ReceptionistId = :ReceptionistId and LocationId > :LocationId) ORDER BY ReceptionistId, OrganisationId, LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C8,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000C9", "SELECT ReceptionistId, OrganisationId, LocationId FROM Trn_Receptionist WHERE ( ReceptionistId < :ReceptionistId or ReceptionistId = :ReceptionistId and OrganisationId < :OrganisationId or OrganisationId = :OrganisationId and ReceptionistId = :ReceptionistId and LocationId < :LocationId) ORDER BY ReceptionistId DESC, OrganisationId DESC, LocationId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C9,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000C10", "SAVEPOINT gxupdate;INSERT INTO Trn_Receptionist(ReceptionistId, ReceptionistPhoneCode, ReceptionistInitials, ReceptionistPhone, ReceptionistGivenName, ReceptionistLastName, ReceptionistEmail, ReceptionistPhoneNumber, ReceptionistGAMGUID, ReceptionistIsActive, ReceptionistImage, ReceptionistImage_GXI, OrganisationId, LocationId) VALUES(:ReceptionistId, :ReceptionistPhoneCode, :ReceptionistInitials, :ReceptionistPhone, :ReceptionistGivenName, :ReceptionistLastName, :ReceptionistEmail, :ReceptionistPhoneNumber, :ReceptionistGAMGUID, :ReceptionistIsActive, :ReceptionistImage, :ReceptionistImage_GXI, :OrganisationId, :LocationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000C10)
          ,new CursorDef("T000C11", "SAVEPOINT gxupdate;UPDATE Trn_Receptionist SET ReceptionistPhoneCode=:ReceptionistPhoneCode, ReceptionistInitials=:ReceptionistInitials, ReceptionistPhone=:ReceptionistPhone, ReceptionistGivenName=:ReceptionistGivenName, ReceptionistLastName=:ReceptionistLastName, ReceptionistEmail=:ReceptionistEmail, ReceptionistPhoneNumber=:ReceptionistPhoneNumber, ReceptionistGAMGUID=:ReceptionistGAMGUID, ReceptionistIsActive=:ReceptionistIsActive  WHERE ReceptionistId = :ReceptionistId AND OrganisationId = :OrganisationId AND LocationId = :LocationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000C11)
          ,new CursorDef("T000C12", "SAVEPOINT gxupdate;UPDATE Trn_Receptionist SET ReceptionistImage=:ReceptionistImage, ReceptionistImage_GXI=:ReceptionistImage_GXI  WHERE ReceptionistId = :ReceptionistId AND OrganisationId = :OrganisationId AND LocationId = :LocationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000C12)
          ,new CursorDef("T000C13", "SAVEPOINT gxupdate;DELETE FROM Trn_Receptionist  WHERE ReceptionistId = :ReceptionistId AND OrganisationId = :OrganisationId AND LocationId = :LocationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000C13)
          ,new CursorDef("T000C14", "SELECT LocationId, OrganisationId FROM Trn_Location WHERE ToolBoxLastUpdateReceptionistI = :ReceptionistId AND OrganisationId = :OrganisationId AND LocationId = :LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C14,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000C15", "SELECT ReceptionistId, OrganisationId, LocationId FROM Trn_Receptionist ORDER BY ReceptionistId, OrganisationId, LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C15,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000C16", "SELECT OrganisationId, LocationId, LocationName FROM Trn_Location WHERE OrganisationId = :AV21OrganisationId ORDER BY LocationName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C16,0, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000C17", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C17,1, GxCacheFrequency.OFF ,true,false )
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
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((string[]) buf[10])[0] = rslt.getMultimediaUri(11);
             ((Guid[]) buf[11])[0] = rslt.getGuid(12);
             ((Guid[]) buf[12])[0] = rslt.getGuid(13);
             ((string[]) buf[13])[0] = rslt.getMultimediaFile(14, rslt.getVarchar(11));
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
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((string[]) buf[10])[0] = rslt.getMultimediaUri(11);
             ((Guid[]) buf[11])[0] = rslt.getGuid(12);
             ((Guid[]) buf[12])[0] = rslt.getGuid(13);
             ((string[]) buf[13])[0] = rslt.getMultimediaFile(14, rslt.getVarchar(11));
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
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((string[]) buf[10])[0] = rslt.getMultimediaUri(11);
             ((Guid[]) buf[11])[0] = rslt.getGuid(12);
             ((Guid[]) buf[12])[0] = rslt.getGuid(13);
             ((string[]) buf[13])[0] = rslt.getMultimediaFile(14, rslt.getVarchar(11));
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 6 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 12 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 13 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 14 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             return;
          case 15 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
