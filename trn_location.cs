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
   public class trn_location : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action39") == 0 )
         {
            A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
            n29LocationId = false;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_39_046( A29LocationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel23"+"_"+"LOCATIONPHONE") == 0 )
         {
            A355LocationPhoneCode = GetPar( "LocationPhoneCode");
            AssignAttri("", false, "A355LocationPhoneCode", A355LocationPhoneCode);
            A356LocationPhoneNumber = GetPar( "LocationPhoneNumber");
            AssignAttri("", false, "A356LocationPhoneNumber", A356LocationPhoneNumber);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX23ASALOCATIONPHONE046( A355LocationPhoneCode, A356LocationPhoneNumber) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_42") == 0 )
         {
            A630ToolBoxLastUpdateReceptionistI = StringUtil.StrToGuid( GetPar( "ToolBoxLastUpdateReceptionistI"));
            n630ToolBoxLastUpdateReceptionistI = false;
            AssignAttri("", false, "A630ToolBoxLastUpdateReceptionistI", A630ToolBoxLastUpdateReceptionistI.ToString());
            A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
            n11OrganisationId = false;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
            n29LocationId = false;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_42( A630ToolBoxLastUpdateReceptionistI, A11OrganisationId, A29LocationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_43") == 0 )
         {
            A577LocationThemeId = StringUtil.StrToGuid( GetPar( "LocationThemeId"));
            n577LocationThemeId = false;
            AssignAttri("", false, "A577LocationThemeId", A577LocationThemeId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_43( A577LocationThemeId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_44") == 0 )
         {
            A584ActiveAppVersionId = StringUtil.StrToGuid( GetPar( "ActiveAppVersionId"));
            n584ActiveAppVersionId = false;
            AssignAttri("", false, "A584ActiveAppVersionId", A584ActiveAppVersionId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_44( A584ActiveAppVersionId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_45") == 0 )
         {
            A598PublishedActiveAppVersionId = StringUtil.StrToGuid( GetPar( "PublishedActiveAppVersionId"));
            n598PublishedActiveAppVersionId = false;
            AssignAttri("", false, "A598PublishedActiveAppVersionId", A598PublishedActiveAppVersionId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_45( A598PublishedActiveAppVersionId) ;
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
         if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
               AssignAttri("", false, "AV7LocationId", AV7LocationId.ToString());
               GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", AV7LocationId, context));
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
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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
         Form.Meta.addItem("description", context.GetMessage( "Location", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtLocationName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_location( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_location( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_LocationId ,
                           Guid aP2_OrganisationId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7LocationId = aP1_LocationId;
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
            return "trn_location_Execute" ;
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
         GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, context.GetMessage( "Location Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_Location.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationName_Internalname, context.GetMessage( "Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationName_Internalname, A31LocationName, StringUtil.RTrim( context.localUtil.Format( A31LocationName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_Location.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationEmail_Internalname, context.GetMessage( "Email", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationEmail_Internalname, A34LocationEmail, StringUtil.RTrim( context.localUtil.Format( A34LocationEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A34LocationEmail, "", "", context.GetMessage( "johndoe@gmail.com", ""), edtLocationEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Trn_Location.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblPhone_Internalname, context.GetMessage( "Phone", ""), "", "", lblPhone_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_Trn_Location.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable9_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable10_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 PhoneLabel ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablelocationphonecode_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_locationphonecode.SetProperty("Caption", Combo_locationphonecode_Caption);
         ucCombo_locationphonecode.SetProperty("Cls", Combo_locationphonecode_Cls);
         ucCombo_locationphonecode.SetProperty("EmptyItem", Combo_locationphonecode_Emptyitem);
         ucCombo_locationphonecode.SetProperty("DropDownOptionsTitleSettingsIcons", AV19DDO_TitleSettingsIcons);
         ucCombo_locationphonecode.SetProperty("DropDownOptionsData", AV21LocationPhoneCode_Data);
         ucCombo_locationphonecode.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_locationphonecode_Internalname, "COMBO_LOCATIONPHONECODEContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationPhoneCode_Internalname, context.GetMessage( "Location Phone Code", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationPhoneCode_Internalname, A355LocationPhoneCode, StringUtil.RTrim( context.localUtil.Format( A355LocationPhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationPhoneCode_Jsonclick, 0, "Attribute", "", "", "", "", edtLocationPhoneCode_Visible, edtLocationPhoneCode_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Location.htm");
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
         GxWebStd.gx_label_element( context, edtLocationPhoneNumber_Internalname, context.GetMessage( "Location Phone Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationPhoneNumber_Internalname, A356LocationPhoneNumber, StringUtil.RTrim( context.localUtil.Format( A356LocationPhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationPhoneNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationPhoneNumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Location.htm");
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
         GxWebStd.gx_div_start( context, divLocationphone_cell_Internalname, 1, 0, "px", 0, "px", divLocationphone_cell_Class, "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", edtLocationPhone_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationPhone_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationPhone_Internalname, context.GetMessage( "Phone", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A35LocationPhone);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationPhone_Internalname, StringUtil.RTrim( A35LocationPhone), StringUtil.RTrim( context.localUtil.Format( A35LocationPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtLocationPhone_Jsonclick, 0, "Attribute", "", "", "", "", edtLocationPhone_Visible, edtLocationPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Trn_Location.htm");
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
         GxWebStd.gx_label_ctrl( context, lblProductserviceimagetext_Internalname, context.GetMessage( "Images", ""), "", "", lblProductserviceimagetext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_Trn_Location.htm");
         GxWebStd.gx_div_end( context, "end", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUcfilecell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* User Defined Control */
         ucImageuploaduc.SetProperty("FailedUploadMessage", Imageuploaduc_Faileduploadmessage);
         ucImageuploaduc.SetProperty("MaxNumberOfFiles", Imageuploaduc_Maxnumberoffiles);
         ucImageuploaduc.SetProperty("isReadOnlyMode", Imageuploaduc_Isreadonlymode);
         ucImageuploaduc.SetProperty("MaxFileSize", Imageuploaduc_Maxfilesize);
         ucImageuploaduc.SetProperty("UploadedFiles", AV42UploadedFiles);
         ucImageuploaduc.SetProperty("FilesToEdit", AV41FilesToUpdate);
         ucImageuploaduc.Render(context, "uc_customimageupload", Imageuploaduc_Internalname, "IMAGEUPLOADUCContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divDecriptioneditortext_Internalname, 1, 0, "px", 0, "px", divDecriptioneditortext_Class, "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+Locationdescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, Locationdescription_Internalname, context.GetMessage( "Description", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* User Defined Control */
         ucLocationdescription.SetProperty("Width", Locationdescription_Width);
         ucLocationdescription.SetProperty("Height", Locationdescription_Height);
         ucLocationdescription.SetProperty("Attribute", LocationDescription);
         ucLocationdescription.SetProperty("Skin", Locationdescription_Skin);
         ucLocationdescription.SetProperty("Toolbar", Locationdescription_Toolbar);
         ucLocationdescription.SetProperty("CustomToolbar", Locationdescription_Customtoolbar);
         ucLocationdescription.SetProperty("CustomConfiguration", Locationdescription_Customconfiguration);
         ucLocationdescription.SetProperty("ToolbarCanCollapse", Locationdescription_Toolbarcancollapse);
         ucLocationdescription.SetProperty("Color", Locationdescription_Color);
         ucLocationdescription.SetProperty("CaptionClass", Locationdescription_Captionclass);
         ucLocationdescription.SetProperty("CaptionStyle", Locationdescription_Captionstyle);
         ucLocationdescription.SetProperty("CaptionPosition", Locationdescription_Captionposition);
         ucLocationdescription.Render(context, "fckeditor", Locationdescription_Internalname, "LOCATIONDESCRIPTIONContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable7_Internalname, divUnnamedtable7_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockdescriptionlabel_Internalname, context.GetMessage( "Description", ""), "", "", lblTextblockdescriptionlabel_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_Trn_Location.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable8_Internalname, 1, 0, "px", 0, "px", "HTMLTextOverfow", "start", "top", " "+"data-gx-flex"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblDescriptiontext_Internalname, "", "", "", lblDescriptiontext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DynamicFormHTMLEditor", 0, "", 1, 1, 0, 1, "HLP_Trn_Location.htm");
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
         GxWebStd.gx_group_start( context, grpUnnamedgroup4_Internalname, context.GetMessage( "Address Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_Location.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationAddressLine1_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationAddressLine1_Internalname, context.GetMessage( "Address Line 1", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationAddressLine1_Internalname, A330LocationAddressLine1, StringUtil.RTrim( context.localUtil.Format( A330LocationAddressLine1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationAddressLine1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationAddressLine1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Location.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationAddressLine2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationAddressLine2_Internalname, context.GetMessage( "Address Line 2", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationAddressLine2_Internalname, A331LocationAddressLine2, StringUtil.RTrim( context.localUtil.Format( A331LocationAddressLine2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationAddressLine2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationAddressLine2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Location.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationZipCode_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationZipCode_Internalname, context.GetMessage( "Zip Code", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationZipCode_Internalname, A329LocationZipCode, StringUtil.RTrim( context.localUtil.Format( A329LocationZipCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "1234 AB", ""), edtLocationZipCode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationZipCode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Location.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationCity_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationCity_Internalname, context.GetMessage( "City", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationCity_Internalname, A328LocationCity, StringUtil.RTrim( context.localUtil.Format( A328LocationCity, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationCity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationCity_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Location.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedlocationcountry_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocklocationcountry_Internalname, context.GetMessage( "Country", ""), "", "", lblTextblocklocationcountry_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_Location.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_locationcountry.SetProperty("Caption", Combo_locationcountry_Caption);
         ucCombo_locationcountry.SetProperty("Cls", Combo_locationcountry_Cls);
         ucCombo_locationcountry.SetProperty("EmptyItem", Combo_locationcountry_Emptyitem);
         ucCombo_locationcountry.SetProperty("DropDownOptionsTitleSettingsIcons", AV19DDO_TitleSettingsIcons);
         ucCombo_locationcountry.SetProperty("DropDownOptionsData", AV22LocationCountry_Data);
         ucCombo_locationcountry.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_locationcountry_Internalname, "COMBO_LOCATIONCOUNTRYContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationCountry_Internalname, context.GetMessage( "Location Country", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationCountry_Internalname, A327LocationCountry, StringUtil.RTrim( context.localUtil.Format( A327LocationCountry, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,115);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationCountry_Jsonclick, 0, "Attribute", "", "", "", "", edtLocationCountry_Visible, edtLocationCountry_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Location.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Location.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 122,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Location.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault hidden-xs hidden-sm hidden-md hidden-lg";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Location.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtnudelete_Internalname, "", context.GetMessage( "Delete", ""), bttBtnudelete_Jsonclick, 5, context.GetMessage( "Delete", ""), "", StyleString, ClassString, bttBtnudelete_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOUDELETE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Location.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_locationphonecode_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombolocationphonecode_Internalname, AV16ComboLocationPhoneCode, StringUtil.RTrim( context.localUtil.Format( AV16ComboLocationPhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,131);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombolocationphonecode_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombolocationphonecode_Visible, edtavCombolocationphonecode_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Location.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_locationcountry_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 133,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombolocationcountry_Internalname, AV23ComboLocationCountry, StringUtil.RTrim( context.localUtil.Format( AV23ComboLocationCountry, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,133);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombolocationcountry_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombolocationcountry_Visible, edtavCombolocationcountry_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Location.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationId_Internalname, A29LocationId.ToString(), A29LocationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,134);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationId_Jsonclick, 0, "Attribute", "", "", "", "", edtLocationId_Visible, edtLocationId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Location.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 135,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationId_Internalname, A11OrganisationId.ToString(), A11OrganisationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,135);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationId_Jsonclick, 0, "Attribute", "", "", "", "", edtOrganisationId_Visible, edtOrganisationId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Location.htm");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A494LocationImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A494LocationImage))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000LocationImage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A494LocationImage)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A494LocationImage)) ? A40000LocationImage_GXI : context.PathToRelativeUrl( A494LocationImage));
         GxWebStd.gx_bitmap( context, imgLocationImage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgLocationImage_Visible, imgLocationImage_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,136);\"", "", "", "", 0, A494LocationImage_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Trn_Location.htm");
         AssignProp("", false, imgLocationImage_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A494LocationImage)) ? A40000LocationImage_GXI : context.PathToRelativeUrl( A494LocationImage)), true);
         AssignProp("", false, imgLocationImage_Internalname, "IsBlob", StringUtil.BoolToStr( A494LocationImage_IsBlob), true);
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
         E11042 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV19DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vLOCATIONPHONECODE_DATA"), AV21LocationPhoneCode_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vUPLOADEDFILES"), AV42UploadedFiles);
               ajax_req_read_hidden_sdt(cgiGet( "vFILESTOUPDATE"), AV41FilesToUpdate);
               ajax_req_read_hidden_sdt(cgiGet( "vLOCATIONCOUNTRY_DATA"), AV22LocationCountry_Data);
               /* Read saved values. */
               Z29LocationId = StringUtil.StrToGuid( cgiGet( "Z29LocationId"));
               Z11OrganisationId = StringUtil.StrToGuid( cgiGet( "Z11OrganisationId"));
               Z327LocationCountry = cgiGet( "Z327LocationCountry");
               Z355LocationPhoneCode = cgiGet( "Z355LocationPhoneCode");
               Z35LocationPhone = cgiGet( "Z35LocationPhone");
               Z329LocationZipCode = cgiGet( "Z329LocationZipCode");
               Z31LocationName = cgiGet( "Z31LocationName");
               Z328LocationCity = cgiGet( "Z328LocationCity");
               Z330LocationAddressLine1 = cgiGet( "Z330LocationAddressLine1");
               Z331LocationAddressLine2 = cgiGet( "Z331LocationAddressLine2");
               Z34LocationEmail = cgiGet( "Z34LocationEmail");
               Z356LocationPhoneNumber = cgiGet( "Z356LocationPhoneNumber");
               Z570LocationHasMyCare = StringUtil.StrToBool( cgiGet( "Z570LocationHasMyCare"));
               Z571LocationHasMyServices = StringUtil.StrToBool( cgiGet( "Z571LocationHasMyServices"));
               Z572LocationHasMyLiving = StringUtil.StrToBool( cgiGet( "Z572LocationHasMyLiving"));
               Z573LocationHasOwnBrand = StringUtil.StrToBool( cgiGet( "Z573LocationHasOwnBrand"));
               Z504ToolBoxDefaultProfileImage = cgiGet( "Z504ToolBoxDefaultProfileImage");
               n504ToolBoxDefaultProfileImage = (String.IsNullOrEmpty(StringUtil.RTrim( A504ToolBoxDefaultProfileImage)) ? true : false);
               Z503ToolBoxDefaultLogo = cgiGet( "Z503ToolBoxDefaultLogo");
               n503ToolBoxDefaultLogo = (String.IsNullOrEmpty(StringUtil.RTrim( A503ToolBoxDefaultLogo)) ? true : false);
               Z575ReceptionDescription = cgiGet( "Z575ReceptionDescription");
               n575ReceptionDescription = (String.IsNullOrEmpty(StringUtil.RTrim( A575ReceptionDescription)) ? true : false);
               Z631ToolBoxLastUpdateTime = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z631ToolBoxLastUpdateTime"), 0));
               n631ToolBoxLastUpdateTime = ((DateTime.MinValue==A631ToolBoxLastUpdateTime) ? true : false);
               Z630ToolBoxLastUpdateReceptionistI = StringUtil.StrToGuid( cgiGet( "Z630ToolBoxLastUpdateReceptionistI"));
               n630ToolBoxLastUpdateReceptionistI = ((Guid.Empty==A630ToolBoxLastUpdateReceptionistI) ? true : false);
               Z577LocationThemeId = StringUtil.StrToGuid( cgiGet( "Z577LocationThemeId"));
               n577LocationThemeId = ((Guid.Empty==A577LocationThemeId) ? true : false);
               Z584ActiveAppVersionId = StringUtil.StrToGuid( cgiGet( "Z584ActiveAppVersionId"));
               n584ActiveAppVersionId = ((Guid.Empty==A584ActiveAppVersionId) ? true : false);
               Z598PublishedActiveAppVersionId = StringUtil.StrToGuid( cgiGet( "Z598PublishedActiveAppVersionId"));
               n598PublishedActiveAppVersionId = ((Guid.Empty==A598PublishedActiveAppVersionId) ? true : false);
               A570LocationHasMyCare = StringUtil.StrToBool( cgiGet( "Z570LocationHasMyCare"));
               A571LocationHasMyServices = StringUtil.StrToBool( cgiGet( "Z571LocationHasMyServices"));
               A572LocationHasMyLiving = StringUtil.StrToBool( cgiGet( "Z572LocationHasMyLiving"));
               A573LocationHasOwnBrand = StringUtil.StrToBool( cgiGet( "Z573LocationHasOwnBrand"));
               A504ToolBoxDefaultProfileImage = cgiGet( "Z504ToolBoxDefaultProfileImage");
               n504ToolBoxDefaultProfileImage = false;
               n504ToolBoxDefaultProfileImage = (String.IsNullOrEmpty(StringUtil.RTrim( A504ToolBoxDefaultProfileImage)) ? true : false);
               A503ToolBoxDefaultLogo = cgiGet( "Z503ToolBoxDefaultLogo");
               n503ToolBoxDefaultLogo = false;
               n503ToolBoxDefaultLogo = (String.IsNullOrEmpty(StringUtil.RTrim( A503ToolBoxDefaultLogo)) ? true : false);
               A575ReceptionDescription = cgiGet( "Z575ReceptionDescription");
               n575ReceptionDescription = false;
               n575ReceptionDescription = (String.IsNullOrEmpty(StringUtil.RTrim( A575ReceptionDescription)) ? true : false);
               A631ToolBoxLastUpdateTime = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z631ToolBoxLastUpdateTime"), 0));
               n631ToolBoxLastUpdateTime = false;
               n631ToolBoxLastUpdateTime = ((DateTime.MinValue==A631ToolBoxLastUpdateTime) ? true : false);
               A630ToolBoxLastUpdateReceptionistI = StringUtil.StrToGuid( cgiGet( "Z630ToolBoxLastUpdateReceptionistI"));
               n630ToolBoxLastUpdateReceptionistI = false;
               n630ToolBoxLastUpdateReceptionistI = ((Guid.Empty==A630ToolBoxLastUpdateReceptionistI) ? true : false);
               A577LocationThemeId = StringUtil.StrToGuid( cgiGet( "Z577LocationThemeId"));
               n577LocationThemeId = false;
               n577LocationThemeId = ((Guid.Empty==A577LocationThemeId) ? true : false);
               A584ActiveAppVersionId = StringUtil.StrToGuid( cgiGet( "Z584ActiveAppVersionId"));
               n584ActiveAppVersionId = false;
               n584ActiveAppVersionId = ((Guid.Empty==A584ActiveAppVersionId) ? true : false);
               A598PublishedActiveAppVersionId = StringUtil.StrToGuid( cgiGet( "Z598PublishedActiveAppVersionId"));
               n598PublishedActiveAppVersionId = false;
               n598PublishedActiveAppVersionId = ((Guid.Empty==A598PublishedActiveAppVersionId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N584ActiveAppVersionId = StringUtil.StrToGuid( cgiGet( "N584ActiveAppVersionId"));
               n584ActiveAppVersionId = ((Guid.Empty==A584ActiveAppVersionId) ? true : false);
               N598PublishedActiveAppVersionId = StringUtil.StrToGuid( cgiGet( "N598PublishedActiveAppVersionId"));
               n598PublishedActiveAppVersionId = ((Guid.Empty==A598PublishedActiveAppVersionId) ? true : false);
               N577LocationThemeId = StringUtil.StrToGuid( cgiGet( "N577LocationThemeId"));
               n577LocationThemeId = ((Guid.Empty==A577LocationThemeId) ? true : false);
               N630ToolBoxLastUpdateReceptionistI = StringUtil.StrToGuid( cgiGet( "N630ToolBoxLastUpdateReceptionistI"));
               n630ToolBoxLastUpdateReceptionistI = ((Guid.Empty==A630ToolBoxLastUpdateReceptionistI) ? true : false);
               AV7LocationId = StringUtil.StrToGuid( cgiGet( "vLOCATIONID"));
               AV8OrganisationId = StringUtil.StrToGuid( cgiGet( "vORGANISATIONID"));
               AV34Insert_ActiveAppVersionId = StringUtil.StrToGuid( cgiGet( "vINSERT_ACTIVEAPPVERSIONID"));
               A584ActiveAppVersionId = StringUtil.StrToGuid( cgiGet( "ACTIVEAPPVERSIONID"));
               n584ActiveAppVersionId = ((Guid.Empty==A584ActiveAppVersionId) ? true : false);
               AV40Insert_PublishedActiveAppVersionId = StringUtil.StrToGuid( cgiGet( "vINSERT_PUBLISHEDACTIVEAPPVERSIONID"));
               A598PublishedActiveAppVersionId = StringUtil.StrToGuid( cgiGet( "PUBLISHEDACTIVEAPPVERSIONID"));
               n598PublishedActiveAppVersionId = ((Guid.Empty==A598PublishedActiveAppVersionId) ? true : false);
               AV32Insert_LocationThemeId = StringUtil.StrToGuid( cgiGet( "vINSERT_LOCATIONTHEMEID"));
               A577LocationThemeId = StringUtil.StrToGuid( cgiGet( "LOCATIONTHEMEID"));
               n577LocationThemeId = ((Guid.Empty==A577LocationThemeId) ? true : false);
               AV43Insert_ToolBoxLastUpdateReceptionistId = StringUtil.StrToGuid( cgiGet( "vINSERT_TOOLBOXLASTUPDATERECEPTIONISTID"));
               A630ToolBoxLastUpdateReceptionistI = StringUtil.StrToGuid( cgiGet( "TOOLBOXLASTUPDATERECEPTIONISTI"));
               n630ToolBoxLastUpdateReceptionistI = ((Guid.Empty==A630ToolBoxLastUpdateReceptionistI) ? true : false);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A573LocationHasOwnBrand = StringUtil.StrToBool( cgiGet( "LOCATIONHASOWNBRAND"));
               A572LocationHasMyLiving = StringUtil.StrToBool( cgiGet( "LOCATIONHASMYLIVING"));
               A571LocationHasMyServices = StringUtil.StrToBool( cgiGet( "LOCATIONHASMYSERVICES"));
               A570LocationHasMyCare = StringUtil.StrToBool( cgiGet( "LOCATIONHASMYCARE"));
               AV31ReceptionDescriptionVar = cgiGet( "vRECEPTIONDESCRIPTIONVAR");
               A575ReceptionDescription = cgiGet( "RECEPTIONDESCRIPTION");
               n575ReceptionDescription = (String.IsNullOrEmpty(StringUtil.RTrim( A575ReceptionDescription)) ? true : false);
               AV30ReceptionImageVar = cgiGet( "vRECEPTIONIMAGEVAR");
               A574ReceptionImage = cgiGet( "RECEPTIONIMAGE");
               n574ReceptionImage = false;
               n574ReceptionImage = (String.IsNullOrEmpty(StringUtil.RTrim( A574ReceptionImage)) ? true : false);
               A40000LocationImage_GXI = cgiGet( "LOCATIONIMAGE_GXI");
               n40000LocationImage_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000LocationImage_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A494LocationImage)) ? true : false);
               A36LocationDescription = cgiGet( "LOCATIONDESCRIPTION");
               A568LocationBrandTheme = cgiGet( "LOCATIONBRANDTHEME");
               n568LocationBrandTheme = false;
               n568LocationBrandTheme = (String.IsNullOrEmpty(StringUtil.RTrim( A568LocationBrandTheme)) ? true : false);
               A569LocationCtaTheme = cgiGet( "LOCATIONCTATHEME");
               n569LocationCtaTheme = false;
               n569LocationCtaTheme = (String.IsNullOrEmpty(StringUtil.RTrim( A569LocationCtaTheme)) ? true : false);
               A504ToolBoxDefaultProfileImage = cgiGet( "TOOLBOXDEFAULTPROFILEIMAGE");
               n504ToolBoxDefaultProfileImage = (String.IsNullOrEmpty(StringUtil.RTrim( A504ToolBoxDefaultProfileImage)) ? true : false);
               A503ToolBoxDefaultLogo = cgiGet( "TOOLBOXDEFAULTLOGO");
               n503ToolBoxDefaultLogo = (String.IsNullOrEmpty(StringUtil.RTrim( A503ToolBoxDefaultLogo)) ? true : false);
               A40001ReceptionImage_GXI = cgiGet( "RECEPTIONIMAGE_GXI");
               n40001ReceptionImage_GXI = false;
               n40001ReceptionImage_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40001ReceptionImage_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A574ReceptionImage)) ? true : false);
               A631ToolBoxLastUpdateTime = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "TOOLBOXLASTUPDATETIME"), 0));
               n631ToolBoxLastUpdateTime = ((DateTime.MinValue==A631ToolBoxLastUpdateTime) ? true : false);
               A273Trn_ThemeId = StringUtil.StrToGuid( cgiGet( "TRN_THEMEID"));
               AV46Pgmname = cgiGet( "vPGMNAME");
               Combo_locationphonecode_Objectcall = cgiGet( "COMBO_LOCATIONPHONECODE_Objectcall");
               Combo_locationphonecode_Class = cgiGet( "COMBO_LOCATIONPHONECODE_Class");
               Combo_locationphonecode_Icontype = cgiGet( "COMBO_LOCATIONPHONECODE_Icontype");
               Combo_locationphonecode_Icon = cgiGet( "COMBO_LOCATIONPHONECODE_Icon");
               Combo_locationphonecode_Caption = cgiGet( "COMBO_LOCATIONPHONECODE_Caption");
               Combo_locationphonecode_Tooltip = cgiGet( "COMBO_LOCATIONPHONECODE_Tooltip");
               Combo_locationphonecode_Cls = cgiGet( "COMBO_LOCATIONPHONECODE_Cls");
               Combo_locationphonecode_Selectedvalue_set = cgiGet( "COMBO_LOCATIONPHONECODE_Selectedvalue_set");
               Combo_locationphonecode_Selectedvalue_get = cgiGet( "COMBO_LOCATIONPHONECODE_Selectedvalue_get");
               Combo_locationphonecode_Selectedtext_set = cgiGet( "COMBO_LOCATIONPHONECODE_Selectedtext_set");
               Combo_locationphonecode_Selectedtext_get = cgiGet( "COMBO_LOCATIONPHONECODE_Selectedtext_get");
               Combo_locationphonecode_Gamoauthtoken = cgiGet( "COMBO_LOCATIONPHONECODE_Gamoauthtoken");
               Combo_locationphonecode_Ddointernalname = cgiGet( "COMBO_LOCATIONPHONECODE_Ddointernalname");
               Combo_locationphonecode_Titlecontrolalign = cgiGet( "COMBO_LOCATIONPHONECODE_Titlecontrolalign");
               Combo_locationphonecode_Dropdownoptionstype = cgiGet( "COMBO_LOCATIONPHONECODE_Dropdownoptionstype");
               Combo_locationphonecode_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONPHONECODE_Enabled"));
               Combo_locationphonecode_Visible = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONPHONECODE_Visible"));
               Combo_locationphonecode_Titlecontrolidtoreplace = cgiGet( "COMBO_LOCATIONPHONECODE_Titlecontrolidtoreplace");
               Combo_locationphonecode_Datalisttype = cgiGet( "COMBO_LOCATIONPHONECODE_Datalisttype");
               Combo_locationphonecode_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONPHONECODE_Allowmultipleselection"));
               Combo_locationphonecode_Datalistfixedvalues = cgiGet( "COMBO_LOCATIONPHONECODE_Datalistfixedvalues");
               Combo_locationphonecode_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONPHONECODE_Isgriditem"));
               Combo_locationphonecode_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONPHONECODE_Hasdescription"));
               Combo_locationphonecode_Datalistproc = cgiGet( "COMBO_LOCATIONPHONECODE_Datalistproc");
               Combo_locationphonecode_Datalistprocparametersprefix = cgiGet( "COMBO_LOCATIONPHONECODE_Datalistprocparametersprefix");
               Combo_locationphonecode_Remoteservicesparameters = cgiGet( "COMBO_LOCATIONPHONECODE_Remoteservicesparameters");
               Combo_locationphonecode_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_LOCATIONPHONECODE_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_locationphonecode_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONPHONECODE_Includeonlyselectedoption"));
               Combo_locationphonecode_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONPHONECODE_Includeselectalloption"));
               Combo_locationphonecode_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONPHONECODE_Emptyitem"));
               Combo_locationphonecode_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONPHONECODE_Includeaddnewoption"));
               Combo_locationphonecode_Htmltemplate = cgiGet( "COMBO_LOCATIONPHONECODE_Htmltemplate");
               Combo_locationphonecode_Multiplevaluestype = cgiGet( "COMBO_LOCATIONPHONECODE_Multiplevaluestype");
               Combo_locationphonecode_Loadingdata = cgiGet( "COMBO_LOCATIONPHONECODE_Loadingdata");
               Combo_locationphonecode_Noresultsfound = cgiGet( "COMBO_LOCATIONPHONECODE_Noresultsfound");
               Combo_locationphonecode_Emptyitemtext = cgiGet( "COMBO_LOCATIONPHONECODE_Emptyitemtext");
               Combo_locationphonecode_Onlyselectedvalues = cgiGet( "COMBO_LOCATIONPHONECODE_Onlyselectedvalues");
               Combo_locationphonecode_Selectalltext = cgiGet( "COMBO_LOCATIONPHONECODE_Selectalltext");
               Combo_locationphonecode_Multiplevaluesseparator = cgiGet( "COMBO_LOCATIONPHONECODE_Multiplevaluesseparator");
               Combo_locationphonecode_Addnewoptiontext = cgiGet( "COMBO_LOCATIONPHONECODE_Addnewoptiontext");
               Combo_locationphonecode_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_LOCATIONPHONECODE_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Imageuploaduc_Objectcall = cgiGet( "IMAGEUPLOADUC_Objectcall");
               Imageuploaduc_Class = cgiGet( "IMAGEUPLOADUC_Class");
               Imageuploaduc_Enabled = StringUtil.StrToBool( cgiGet( "IMAGEUPLOADUC_Enabled"));
               Imageuploaduc_Faileduploadmessage = cgiGet( "IMAGEUPLOADUC_Faileduploadmessage");
               Imageuploaduc_Maxnumberoffiles = cgiGet( "IMAGEUPLOADUC_Maxnumberoffiles");
               Imageuploaduc_Isreadonlymode = cgiGet( "IMAGEUPLOADUC_Isreadonlymode");
               Imageuploaduc_Maxfilesize = cgiGet( "IMAGEUPLOADUC_Maxfilesize");
               Imageuploaduc_Visible = StringUtil.StrToBool( cgiGet( "IMAGEUPLOADUC_Visible"));
               Locationdescription_Objectcall = cgiGet( "LOCATIONDESCRIPTION_Objectcall");
               Locationdescription_Class = cgiGet( "LOCATIONDESCRIPTION_Class");
               Locationdescription_Enabled = StringUtil.StrToBool( cgiGet( "LOCATIONDESCRIPTION_Enabled"));
               Locationdescription_Width = cgiGet( "LOCATIONDESCRIPTION_Width");
               Locationdescription_Height = cgiGet( "LOCATIONDESCRIPTION_Height");
               Locationdescription_Skin = cgiGet( "LOCATIONDESCRIPTION_Skin");
               Locationdescription_Toolbar = cgiGet( "LOCATIONDESCRIPTION_Toolbar");
               Locationdescription_Customtoolbar = cgiGet( "LOCATIONDESCRIPTION_Customtoolbar");
               Locationdescription_Customconfiguration = cgiGet( "LOCATIONDESCRIPTION_Customconfiguration");
               Locationdescription_Toolbarcancollapse = StringUtil.StrToBool( cgiGet( "LOCATIONDESCRIPTION_Toolbarcancollapse"));
               Locationdescription_Toolbarexpanded = StringUtil.StrToBool( cgiGet( "LOCATIONDESCRIPTION_Toolbarexpanded"));
               Locationdescription_Color = (int)(Math.Round(context.localUtil.CToN( cgiGet( "LOCATIONDESCRIPTION_Color"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Locationdescription_Buttonpressedid = cgiGet( "LOCATIONDESCRIPTION_Buttonpressedid");
               Locationdescription_Captionvalue = cgiGet( "LOCATIONDESCRIPTION_Captionvalue");
               Locationdescription_Captionclass = cgiGet( "LOCATIONDESCRIPTION_Captionclass");
               Locationdescription_Captionstyle = cgiGet( "LOCATIONDESCRIPTION_Captionstyle");
               Locationdescription_Captionposition = cgiGet( "LOCATIONDESCRIPTION_Captionposition");
               Locationdescription_Isabstractlayoutcontrol = StringUtil.StrToBool( cgiGet( "LOCATIONDESCRIPTION_Isabstractlayoutcontrol"));
               Locationdescription_Coltitle = cgiGet( "LOCATIONDESCRIPTION_Coltitle");
               Locationdescription_Coltitlefont = cgiGet( "LOCATIONDESCRIPTION_Coltitlefont");
               Locationdescription_Coltitlecolor = (int)(Math.Round(context.localUtil.CToN( cgiGet( "LOCATIONDESCRIPTION_Coltitlecolor"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Locationdescription_Usercontroliscolumn = StringUtil.StrToBool( cgiGet( "LOCATIONDESCRIPTION_Usercontroliscolumn"));
               Locationdescription_Visible = StringUtil.StrToBool( cgiGet( "LOCATIONDESCRIPTION_Visible"));
               Combo_locationcountry_Objectcall = cgiGet( "COMBO_LOCATIONCOUNTRY_Objectcall");
               Combo_locationcountry_Class = cgiGet( "COMBO_LOCATIONCOUNTRY_Class");
               Combo_locationcountry_Icontype = cgiGet( "COMBO_LOCATIONCOUNTRY_Icontype");
               Combo_locationcountry_Icon = cgiGet( "COMBO_LOCATIONCOUNTRY_Icon");
               Combo_locationcountry_Caption = cgiGet( "COMBO_LOCATIONCOUNTRY_Caption");
               Combo_locationcountry_Tooltip = cgiGet( "COMBO_LOCATIONCOUNTRY_Tooltip");
               Combo_locationcountry_Cls = cgiGet( "COMBO_LOCATIONCOUNTRY_Cls");
               Combo_locationcountry_Selectedvalue_set = cgiGet( "COMBO_LOCATIONCOUNTRY_Selectedvalue_set");
               Combo_locationcountry_Selectedvalue_get = cgiGet( "COMBO_LOCATIONCOUNTRY_Selectedvalue_get");
               Combo_locationcountry_Selectedtext_set = cgiGet( "COMBO_LOCATIONCOUNTRY_Selectedtext_set");
               Combo_locationcountry_Selectedtext_get = cgiGet( "COMBO_LOCATIONCOUNTRY_Selectedtext_get");
               Combo_locationcountry_Gamoauthtoken = cgiGet( "COMBO_LOCATIONCOUNTRY_Gamoauthtoken");
               Combo_locationcountry_Ddointernalname = cgiGet( "COMBO_LOCATIONCOUNTRY_Ddointernalname");
               Combo_locationcountry_Titlecontrolalign = cgiGet( "COMBO_LOCATIONCOUNTRY_Titlecontrolalign");
               Combo_locationcountry_Dropdownoptionstype = cgiGet( "COMBO_LOCATIONCOUNTRY_Dropdownoptionstype");
               Combo_locationcountry_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONCOUNTRY_Enabled"));
               Combo_locationcountry_Visible = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONCOUNTRY_Visible"));
               Combo_locationcountry_Titlecontrolidtoreplace = cgiGet( "COMBO_LOCATIONCOUNTRY_Titlecontrolidtoreplace");
               Combo_locationcountry_Datalisttype = cgiGet( "COMBO_LOCATIONCOUNTRY_Datalisttype");
               Combo_locationcountry_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONCOUNTRY_Allowmultipleselection"));
               Combo_locationcountry_Datalistfixedvalues = cgiGet( "COMBO_LOCATIONCOUNTRY_Datalistfixedvalues");
               Combo_locationcountry_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONCOUNTRY_Isgriditem"));
               Combo_locationcountry_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONCOUNTRY_Hasdescription"));
               Combo_locationcountry_Datalistproc = cgiGet( "COMBO_LOCATIONCOUNTRY_Datalistproc");
               Combo_locationcountry_Datalistprocparametersprefix = cgiGet( "COMBO_LOCATIONCOUNTRY_Datalistprocparametersprefix");
               Combo_locationcountry_Remoteservicesparameters = cgiGet( "COMBO_LOCATIONCOUNTRY_Remoteservicesparameters");
               Combo_locationcountry_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_LOCATIONCOUNTRY_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_locationcountry_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONCOUNTRY_Includeonlyselectedoption"));
               Combo_locationcountry_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONCOUNTRY_Includeselectalloption"));
               Combo_locationcountry_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONCOUNTRY_Emptyitem"));
               Combo_locationcountry_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONCOUNTRY_Includeaddnewoption"));
               Combo_locationcountry_Htmltemplate = cgiGet( "COMBO_LOCATIONCOUNTRY_Htmltemplate");
               Combo_locationcountry_Multiplevaluestype = cgiGet( "COMBO_LOCATIONCOUNTRY_Multiplevaluestype");
               Combo_locationcountry_Loadingdata = cgiGet( "COMBO_LOCATIONCOUNTRY_Loadingdata");
               Combo_locationcountry_Noresultsfound = cgiGet( "COMBO_LOCATIONCOUNTRY_Noresultsfound");
               Combo_locationcountry_Emptyitemtext = cgiGet( "COMBO_LOCATIONCOUNTRY_Emptyitemtext");
               Combo_locationcountry_Onlyselectedvalues = cgiGet( "COMBO_LOCATIONCOUNTRY_Onlyselectedvalues");
               Combo_locationcountry_Selectalltext = cgiGet( "COMBO_LOCATIONCOUNTRY_Selectalltext");
               Combo_locationcountry_Multiplevaluesseparator = cgiGet( "COMBO_LOCATIONCOUNTRY_Multiplevaluesseparator");
               Combo_locationcountry_Addnewoptiontext = cgiGet( "COMBO_LOCATIONCOUNTRY_Addnewoptiontext");
               Combo_locationcountry_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_LOCATIONCOUNTRY_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A31LocationName = cgiGet( edtLocationName_Internalname);
               AssignAttri("", false, "A31LocationName", A31LocationName);
               A34LocationEmail = cgiGet( edtLocationEmail_Internalname);
               AssignAttri("", false, "A34LocationEmail", A34LocationEmail);
               A355LocationPhoneCode = cgiGet( edtLocationPhoneCode_Internalname);
               AssignAttri("", false, "A355LocationPhoneCode", A355LocationPhoneCode);
               A356LocationPhoneNumber = cgiGet( edtLocationPhoneNumber_Internalname);
               AssignAttri("", false, "A356LocationPhoneNumber", A356LocationPhoneNumber);
               A35LocationPhone = cgiGet( edtLocationPhone_Internalname);
               AssignAttri("", false, "A35LocationPhone", A35LocationPhone);
               A330LocationAddressLine1 = cgiGet( edtLocationAddressLine1_Internalname);
               AssignAttri("", false, "A330LocationAddressLine1", A330LocationAddressLine1);
               A331LocationAddressLine2 = cgiGet( edtLocationAddressLine2_Internalname);
               AssignAttri("", false, "A331LocationAddressLine2", A331LocationAddressLine2);
               A329LocationZipCode = cgiGet( edtLocationZipCode_Internalname);
               AssignAttri("", false, "A329LocationZipCode", A329LocationZipCode);
               A328LocationCity = cgiGet( edtLocationCity_Internalname);
               AssignAttri("", false, "A328LocationCity", A328LocationCity);
               A327LocationCountry = cgiGet( edtLocationCountry_Internalname);
               AssignAttri("", false, "A327LocationCountry", A327LocationCountry);
               AV16ComboLocationPhoneCode = cgiGet( edtavCombolocationphonecode_Internalname);
               AssignAttri("", false, "AV16ComboLocationPhoneCode", AV16ComboLocationPhoneCode);
               AV23ComboLocationCountry = cgiGet( edtavCombolocationcountry_Internalname);
               AssignAttri("", false, "AV23ComboLocationCountry", AV23ComboLocationCountry);
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
               A494LocationImage = cgiGet( imgLocationImage_Internalname);
               n494LocationImage = false;
               AssignAttri("", false, "A494LocationImage", A494LocationImage);
               n494LocationImage = (String.IsNullOrEmpty(StringUtil.RTrim( A494LocationImage)) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgLocationImage_Internalname, ref  A494LocationImage, ref  A40000LocationImage_GXI);
               n40000LocationImage_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000LocationImage_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A494LocationImage)) ? true : false);
               n494LocationImage = (String.IsNullOrEmpty(StringUtil.RTrim( A494LocationImage)) ? true : false);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Location");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("LocationHasMyCare", StringUtil.BoolToStr( A570LocationHasMyCare));
               forbiddenHiddens.Add("LocationHasMyServices", StringUtil.BoolToStr( A571LocationHasMyServices));
               forbiddenHiddens.Add("LocationHasMyLiving", StringUtil.BoolToStr( A572LocationHasMyLiving));
               forbiddenHiddens.Add("LocationHasOwnBrand", StringUtil.BoolToStr( A573LocationHasOwnBrand));
               forbiddenHiddens.Add("ToolBoxDefaultProfileImage", StringUtil.RTrim( context.localUtil.Format( A504ToolBoxDefaultProfileImage, "")));
               forbiddenHiddens.Add("ToolBoxDefaultLogo", StringUtil.RTrim( context.localUtil.Format( A503ToolBoxDefaultLogo, "")));
               forbiddenHiddens.Add("ReceptionDescription", StringUtil.RTrim( context.localUtil.Format( A575ReceptionDescription, "")));
               forbiddenHiddens.Add("ToolBoxLastUpdateTime", context.localUtil.Format( A631ToolBoxLastUpdateTime, "99:99"));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_location:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
                  n29LocationId = false;
                  AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
                  A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  n11OrganisationId = false;
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode6 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode6;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound6 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_040( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "LOCATIONID");
                        AnyError = 1;
                        GX_FocusControl = edtLocationId_Internalname;
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
                        if ( StringUtil.StrCmp(sEvt, "IMAGEUPLOADUC.ONFAILEDUPLOAD") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Imageuploaduc.Onfailedupload */
                           E12042 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11042 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E13042 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "'DOUDELETE'") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: 'DoUDelete' */
                           E14042 ();
                           nKeyPressed = 3;
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
            E13042 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll046( ) ;
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
            DisableAttributes046( ) ;
         }
         AssignProp("", false, edtavCombolocationphonecode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombolocationphonecode_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombolocationcountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombolocationcountry_Enabled), 5, 0), true);
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

      protected void CONFIRM_040( )
      {
         BeforeValidate046( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls046( ) ;
            }
            else
            {
               CheckExtendedTable046( ) ;
               CloseExtendedTableCursors046( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption040( )
      {
      }

      protected void E11042( )
      {
         /* Start Routine */
         returnInSub = false;
         AV31ReceptionDescriptionVar = context.GetMessage( "Welkom bij de receptie van onze app. Hier kunt u al uw vragen stellen en krijgt u direct hulp van ons team. Of het nu gaat om technische ondersteuning, informatie over diensten, of algemene vragen, wij zijn er om u te helpen.", "");
         AssignAttri("", false, "AV31ReceptionDescriptionVar", AV31ReceptionDescriptionVar);
         imgReceptionimagevar_gximage = "ReceptionImageFile";
         AssignProp("", false, imgReceptionimagevar_Internalname, "gximage", imgReceptionimagevar_gximage, true);
         AV30ReceptionImageVar = context.GetImagePath( "7a779875-7e6f-4e4f-8ef6-6c9464d2a2f0", "", context.GetTheme( ));
         AssignAttri("", false, "AV30ReceptionImageVar", AV30ReceptionImageVar);
         AV45Receptionimagevar_GXI = GXDbFile.PathToUrl( context.GetImagePath( "7a779875-7e6f-4e4f-8ef6-6c9464d2a2f0", "", context.GetTheme( )), context);
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV19DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV19DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtLocationCountry_Visible = 0;
         AssignProp("", false, edtLocationCountry_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLocationCountry_Visible), 5, 0), true);
         AV23ComboLocationCountry = "";
         AssignAttri("", false, "AV23ComboLocationCountry", AV23ComboLocationCountry);
         edtavCombolocationcountry_Visible = 0;
         AssignProp("", false, edtavCombolocationcountry_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombolocationcountry_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_locationcountry_Htmltemplate = GXt_char2;
         ucCombo_locationcountry.SendProperty(context, "", false, Combo_locationcountry_Internalname, "HTMLTemplate", Combo_locationcountry_Htmltemplate);
         edtLocationPhoneCode_Visible = 0;
         AssignProp("", false, edtLocationPhoneCode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLocationPhoneCode_Visible), 5, 0), true);
         AV16ComboLocationPhoneCode = "";
         AssignAttri("", false, "AV16ComboLocationPhoneCode", AV16ComboLocationPhoneCode);
         edtavCombolocationphonecode_Visible = 0;
         AssignProp("", false, edtavCombolocationphonecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombolocationphonecode_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_locationphonecode_Htmltemplate = GXt_char2;
         ucCombo_locationphonecode.SendProperty(context, "", false, Combo_locationphonecode_Internalname, "HTMLTemplate", Combo_locationphonecode_Htmltemplate);
         /* Execute user subroutine: 'LOADCOMBOLOCATIONPHONECODE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOLOCATIONCOUNTRY' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV12TrnContext.gxTpr_Transactionname, AV46Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV47GXV1 = 1;
            AssignAttri("", false, "AV47GXV1", StringUtil.LTrimStr( (decimal)(AV47GXV1), 8, 0));
            while ( AV47GXV1 <= AV12TrnContext.gxTpr_Attributes.Count )
            {
               AV26TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV12TrnContext.gxTpr_Attributes.Item(AV47GXV1));
               if ( StringUtil.StrCmp(AV26TrnContextAtt.gxTpr_Attributename, "ActiveAppVersionId") == 0 )
               {
                  AV34Insert_ActiveAppVersionId = StringUtil.StrToGuid( AV26TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV34Insert_ActiveAppVersionId", AV34Insert_ActiveAppVersionId.ToString());
               }
               else if ( StringUtil.StrCmp(AV26TrnContextAtt.gxTpr_Attributename, "PublishedActiveAppVersionId") == 0 )
               {
                  AV40Insert_PublishedActiveAppVersionId = StringUtil.StrToGuid( AV26TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV40Insert_PublishedActiveAppVersionId", AV40Insert_PublishedActiveAppVersionId.ToString());
               }
               else if ( StringUtil.StrCmp(AV26TrnContextAtt.gxTpr_Attributename, "LocationThemeId") == 0 )
               {
                  AV32Insert_LocationThemeId = StringUtil.StrToGuid( AV26TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV32Insert_LocationThemeId", AV32Insert_LocationThemeId.ToString());
               }
               else if ( StringUtil.StrCmp(AV26TrnContextAtt.gxTpr_Attributename, "ToolBoxLastUpdateReceptionistId") == 0 )
               {
                  AV43Insert_ToolBoxLastUpdateReceptionistId = StringUtil.StrToGuid( AV26TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV43Insert_ToolBoxLastUpdateReceptionistId", AV43Insert_ToolBoxLastUpdateReceptionistId.ToString());
               }
               AV47GXV1 = (int)(AV47GXV1+1);
               AssignAttri("", false, "AV47GXV1", StringUtil.LTrimStr( (decimal)(AV47GXV1), 8, 0));
            }
         }
         edtLocationId_Visible = 0;
         AssignProp("", false, edtLocationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLocationId_Visible), 5, 0), true);
         edtOrganisationId_Visible = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Visible), 5, 0), true);
         imgLocationImage_Visible = 0;
         AssignProp("", false, imgLocationImage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgLocationImage_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            GXt_objcol_SdtSDT_FileUploadData3 = AV41FilesToUpdate;
            new prc_getlocationimages(context ).execute(  AV7LocationId, out  GXt_objcol_SdtSDT_FileUploadData3) ;
            AV41FilesToUpdate = GXt_objcol_SdtSDT_FileUploadData3;
         }
      }

      protected void E13042( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            new prc_updatelocationimages(context ).execute(  AV7LocationId,  AV42UploadedFiles,  AV41FilesToUpdate) ;
            AV13WebSession.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "Location Updated successfully", ""));
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV13WebSession.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "Location Deleted successfully", ""));
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV13WebSession.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "Location Inserted successfully", ""));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV12TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("trn_locationww.aspx") );
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

      protected void S132( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         edtLocationPhone_Visible = 0;
         AssignProp("", false, edtLocationPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLocationPhone_Visible), 5, 0), true);
         divLocationphone_cell_Class = "Invisible";
         AssignProp("", false, divLocationphone_cell_Internalname, "Class", divLocationphone_cell_Class, true);
         Locationdescription_Visible = false;
         AssignProp("", false, Locationdescription_Internalname, "Visible", StringUtil.BoolToStr( Locationdescription_Visible), true);
         divDecriptioneditortext_Class = "Invisible";
         AssignProp("", false, divDecriptioneditortext_Internalname, "Class", divDecriptioneditortext_Class, true);
      }

      protected void E14042( )
      {
         /* 'DoUDelete' Routine */
         returnInSub = false;
         new prc_deletecascadelocation(context ).execute(  A29LocationId,  Guid.Empty,  A11OrganisationId,  true, ref  AV28isSuccessful, ref  AV29Message) ;
         AssignAttri("", false, "AV28isSuccessful", AV28isSuccessful);
         AssignAttri("", false, "AV29Message", AV29Message);
         if ( AV28isSuccessful )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Success",  context.GetMessage( "Deleted location successfully", ""),  "success",  "",  "true",  ""));
            CallWebObject(formatLink("trn_locationww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Failed",  AV29Message,  "error",  "",  "true",  ""));
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'LOADCOMBOLOCATIONCOUNTRY' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item4 = AV22LocationCountry_Data;
         new trn_locationloaddvcombo(context ).execute(  "LocationCountry",  Gx_mode,  AV7LocationId,  AV8OrganisationId, out  AV18ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_objcol_SdtDVB_SDTComboData_Item4) ;
         AV22LocationCountry_Data = GXt_objcol_SdtDVB_SDTComboData_Item4;
         Combo_locationcountry_Selectedvalue_set = AV18ComboSelectedValue;
         ucCombo_locationcountry.SendProperty(context, "", false, Combo_locationcountry_Internalname, "SelectedValue_set", Combo_locationcountry_Selectedvalue_set);
         AV23ComboLocationCountry = AV18ComboSelectedValue;
         AssignAttri("", false, "AV23ComboLocationCountry", AV23ComboLocationCountry);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_locationcountry_Enabled = false;
            ucCombo_locationcountry.SendProperty(context, "", false, Combo_locationcountry_Internalname, "Enabled", StringUtil.BoolToStr( Combo_locationcountry_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOLOCATIONPHONECODE' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item4 = AV21LocationPhoneCode_Data;
         new trn_locationloaddvcombo(context ).execute(  "LocationPhoneCode",  Gx_mode,  AV7LocationId,  AV8OrganisationId, out  AV18ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_objcol_SdtDVB_SDTComboData_Item4) ;
         AV21LocationPhoneCode_Data = GXt_objcol_SdtDVB_SDTComboData_Item4;
         Combo_locationphonecode_Selectedvalue_set = AV18ComboSelectedValue;
         ucCombo_locationphonecode.SendProperty(context, "", false, Combo_locationphonecode_Internalname, "SelectedValue_set", Combo_locationphonecode_Selectedvalue_set);
         AV16ComboLocationPhoneCode = AV18ComboSelectedValue;
         AssignAttri("", false, "AV16ComboLocationPhoneCode", AV16ComboLocationPhoneCode);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_locationphonecode_Enabled = false;
            ucCombo_locationphonecode.SendProperty(context, "", false, Combo_locationphonecode_Internalname, "Enabled", StringUtil.BoolToStr( Combo_locationphonecode_Enabled));
         }
      }

      protected void E12042( )
      {
         /* Imageuploaduc_Onfailedupload Routine */
         returnInSub = false;
         GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  Imageuploaduc_Faileduploadmessage,  "error",  "",  "true",  ""));
      }

      protected void ZM046( short GX_JID )
      {
         if ( ( GX_JID == 41 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z327LocationCountry = T00043_A327LocationCountry[0];
               Z355LocationPhoneCode = T00043_A355LocationPhoneCode[0];
               Z35LocationPhone = T00043_A35LocationPhone[0];
               Z329LocationZipCode = T00043_A329LocationZipCode[0];
               Z31LocationName = T00043_A31LocationName[0];
               Z328LocationCity = T00043_A328LocationCity[0];
               Z330LocationAddressLine1 = T00043_A330LocationAddressLine1[0];
               Z331LocationAddressLine2 = T00043_A331LocationAddressLine2[0];
               Z34LocationEmail = T00043_A34LocationEmail[0];
               Z356LocationPhoneNumber = T00043_A356LocationPhoneNumber[0];
               Z570LocationHasMyCare = T00043_A570LocationHasMyCare[0];
               Z571LocationHasMyServices = T00043_A571LocationHasMyServices[0];
               Z572LocationHasMyLiving = T00043_A572LocationHasMyLiving[0];
               Z573LocationHasOwnBrand = T00043_A573LocationHasOwnBrand[0];
               Z504ToolBoxDefaultProfileImage = T00043_A504ToolBoxDefaultProfileImage[0];
               Z503ToolBoxDefaultLogo = T00043_A503ToolBoxDefaultLogo[0];
               Z575ReceptionDescription = T00043_A575ReceptionDescription[0];
               Z631ToolBoxLastUpdateTime = T00043_A631ToolBoxLastUpdateTime[0];
               Z630ToolBoxLastUpdateReceptionistI = T00043_A630ToolBoxLastUpdateReceptionistI[0];
               Z577LocationThemeId = T00043_A577LocationThemeId[0];
               Z584ActiveAppVersionId = T00043_A584ActiveAppVersionId[0];
               Z598PublishedActiveAppVersionId = T00043_A598PublishedActiveAppVersionId[0];
            }
            else
            {
               Z327LocationCountry = A327LocationCountry;
               Z355LocationPhoneCode = A355LocationPhoneCode;
               Z35LocationPhone = A35LocationPhone;
               Z329LocationZipCode = A329LocationZipCode;
               Z31LocationName = A31LocationName;
               Z328LocationCity = A328LocationCity;
               Z330LocationAddressLine1 = A330LocationAddressLine1;
               Z331LocationAddressLine2 = A331LocationAddressLine2;
               Z34LocationEmail = A34LocationEmail;
               Z356LocationPhoneNumber = A356LocationPhoneNumber;
               Z570LocationHasMyCare = A570LocationHasMyCare;
               Z571LocationHasMyServices = A571LocationHasMyServices;
               Z572LocationHasMyLiving = A572LocationHasMyLiving;
               Z573LocationHasOwnBrand = A573LocationHasOwnBrand;
               Z504ToolBoxDefaultProfileImage = A504ToolBoxDefaultProfileImage;
               Z503ToolBoxDefaultLogo = A503ToolBoxDefaultLogo;
               Z575ReceptionDescription = A575ReceptionDescription;
               Z631ToolBoxLastUpdateTime = A631ToolBoxLastUpdateTime;
               Z630ToolBoxLastUpdateReceptionistI = A630ToolBoxLastUpdateReceptionistI;
               Z577LocationThemeId = A577LocationThemeId;
               Z584ActiveAppVersionId = A584ActiveAppVersionId;
               Z598PublishedActiveAppVersionId = A598PublishedActiveAppVersionId;
            }
         }
         if ( GX_JID == -41 )
         {
            Z327LocationCountry = A327LocationCountry;
            Z355LocationPhoneCode = A355LocationPhoneCode;
            Z35LocationPhone = A35LocationPhone;
            Z329LocationZipCode = A329LocationZipCode;
            Z31LocationName = A31LocationName;
            Z494LocationImage = A494LocationImage;
            Z40000LocationImage_GXI = A40000LocationImage_GXI;
            Z328LocationCity = A328LocationCity;
            Z330LocationAddressLine1 = A330LocationAddressLine1;
            Z331LocationAddressLine2 = A331LocationAddressLine2;
            Z34LocationEmail = A34LocationEmail;
            Z356LocationPhoneNumber = A356LocationPhoneNumber;
            Z36LocationDescription = A36LocationDescription;
            Z568LocationBrandTheme = A568LocationBrandTheme;
            Z569LocationCtaTheme = A569LocationCtaTheme;
            Z570LocationHasMyCare = A570LocationHasMyCare;
            Z571LocationHasMyServices = A571LocationHasMyServices;
            Z572LocationHasMyLiving = A572LocationHasMyLiving;
            Z573LocationHasOwnBrand = A573LocationHasOwnBrand;
            Z504ToolBoxDefaultProfileImage = A504ToolBoxDefaultProfileImage;
            Z503ToolBoxDefaultLogo = A503ToolBoxDefaultLogo;
            Z574ReceptionImage = A574ReceptionImage;
            Z40001ReceptionImage_GXI = A40001ReceptionImage_GXI;
            Z575ReceptionDescription = A575ReceptionDescription;
            Z631ToolBoxLastUpdateTime = A631ToolBoxLastUpdateTime;
            Z630ToolBoxLastUpdateReceptionistI = A630ToolBoxLastUpdateReceptionistI;
            Z11OrganisationId = A11OrganisationId;
            Z29LocationId = A29LocationId;
            Z577LocationThemeId = A577LocationThemeId;
            Z584ActiveAppVersionId = A584ActiveAppVersionId;
            Z598PublishedActiveAppVersionId = A598PublishedActiveAppVersionId;
         }
      }

      protected void standaloneNotModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            bttBtnudelete_Visible = 1;
            AssignProp("", false, bttBtnudelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnudelete_Visible), 5, 0), true);
         }
         else
         {
            if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) ) )
            {
               bttBtnudelete_Visible = 0;
               AssignProp("", false, bttBtnudelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnudelete_Visible), 5, 0), true);
            }
         }
         edtLocationPhone_Visible = ((StringUtil.StrCmp(Gx_mode, "DSP")==0)||(StringUtil.StrCmp(Gx_mode, "DLT")==0) ? 1 : 0);
         AssignProp("", false, edtLocationPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLocationPhone_Visible), 5, 0), true);
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) ) )
         {
            divLocationphone_cell_Class = context.GetMessage( "Invisible", "");
            AssignProp("", false, divLocationphone_cell_Internalname, "Class", divLocationphone_cell_Class, true);
         }
         else
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               divLocationphone_cell_Class = context.GetMessage( "col-xs-12 DataContentCell", "");
               AssignProp("", false, divLocationphone_cell_Internalname, "Class", divLocationphone_cell_Class, true);
            }
         }
         Locationdescription_Visible = (bool)((StringUtil.StrCmp(Gx_mode, "INS")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0));
         AssignProp("", false, Locationdescription_Internalname, "Visible", StringUtil.BoolToStr( Locationdescription_Visible), true);
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) ) )
         {
            divDecriptioneditortext_Class = context.GetMessage( "Invisible", "");
            AssignProp("", false, divDecriptioneditortext_Internalname, "Class", divDecriptioneditortext_Class, true);
         }
         else
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
            {
               divDecriptioneditortext_Class = context.GetMessage( "col-xs-12 DataContentCell CKEditor", "");
               AssignProp("", false, divDecriptioneditortext_Internalname, "Class", divDecriptioneditortext_Class, true);
            }
         }
         divUnnamedtable5_Visible = (((StringUtil.StrCmp(Gx_mode, "INS")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0)) ? 1 : 0);
         AssignProp("", false, divUnnamedtable5_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUnnamedtable5_Visible), 5, 0), true);
         divUnnamedtable7_Visible = (((StringUtil.StrCmp(Gx_mode, "DSP")==0)) ? 1 : 0);
         AssignProp("", false, divUnnamedtable7_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUnnamedtable7_Visible), 5, 0), true);
         AV46Pgmname = "Trn_Location";
         AssignAttri("", false, "AV46Pgmname", AV46Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV7LocationId) )
         {
            A29LocationId = AV7LocationId;
            n29LocationId = false;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         }
         if ( ! (Guid.Empty==AV7LocationId) )
         {
            edtLocationId_Enabled = 0;
            AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         }
         else
         {
            edtLocationId_Enabled = 1;
            AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7LocationId) )
         {
            edtLocationId_Enabled = 0;
            AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV8OrganisationId) )
         {
            A11OrganisationId = AV8OrganisationId;
            n11OrganisationId = false;
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV32Insert_LocationThemeId) )
         {
            A577LocationThemeId = AV32Insert_LocationThemeId;
            n577LocationThemeId = false;
            AssignAttri("", false, "A577LocationThemeId", A577LocationThemeId.ToString());
         }
         else
         {
            A577LocationThemeId = Guid.Empty;
            n577LocationThemeId = false;
            AssignAttri("", false, "A577LocationThemeId", A577LocationThemeId.ToString());
            n577LocationThemeId = true;
            AssignAttri("", false, "A577LocationThemeId", A577LocationThemeId.ToString());
         }
         A355LocationPhoneCode = AV16ComboLocationPhoneCode;
         AssignAttri("", false, "A355LocationPhoneCode", A355LocationPhoneCode);
         A327LocationCountry = AV23ComboLocationCountry;
         AssignAttri("", false, "A327LocationCountry", A327LocationCountry);
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
         if ( IsIns( )  && (false==A573LocationHasOwnBrand) && ( Gx_BScreen == 0 ) )
         {
            A573LocationHasOwnBrand = false;
            AssignAttri("", false, "A573LocationHasOwnBrand", A573LocationHasOwnBrand);
         }
         if ( IsIns( )  && (false==A572LocationHasMyLiving) && ( Gx_BScreen == 0 ) )
         {
            A572LocationHasMyLiving = false;
            AssignAttri("", false, "A572LocationHasMyLiving", A572LocationHasMyLiving);
         }
         if ( IsIns( )  && (false==A571LocationHasMyServices) && ( Gx_BScreen == 0 ) )
         {
            A571LocationHasMyServices = false;
            AssignAttri("", false, "A571LocationHasMyServices", A571LocationHasMyServices);
         }
         if ( IsIns( )  && (false==A570LocationHasMyCare) && ( Gx_BScreen == 0 ) )
         {
            A570LocationHasMyCare = false;
            AssignAttri("", false, "A570LocationHasMyCare", A570LocationHasMyCare);
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A575ReceptionDescription)) && ( Gx_BScreen == 0 ) )
         {
            A575ReceptionDescription = AV31ReceptionDescriptionVar;
            n575ReceptionDescription = false;
            AssignAttri("", false, "A575ReceptionDescription", A575ReceptionDescription);
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A574ReceptionImage)) && ( Gx_BScreen == 0 ) )
         {
            A574ReceptionImage = AV30ReceptionImageVar;
            n574ReceptionImage = false;
            AssignAttri("", false, "A574ReceptionImage", A574ReceptionImage);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load046( )
      {
         /* Using cursor T00048 */
         pr_default.execute(6, new Object[] {n11OrganisationId, A11OrganisationId, n29LocationId, A29LocationId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound6 = 1;
            A327LocationCountry = T00048_A327LocationCountry[0];
            AssignAttri("", false, "A327LocationCountry", A327LocationCountry);
            A355LocationPhoneCode = T00048_A355LocationPhoneCode[0];
            AssignAttri("", false, "A355LocationPhoneCode", A355LocationPhoneCode);
            A35LocationPhone = T00048_A35LocationPhone[0];
            AssignAttri("", false, "A35LocationPhone", A35LocationPhone);
            A329LocationZipCode = T00048_A329LocationZipCode[0];
            AssignAttri("", false, "A329LocationZipCode", A329LocationZipCode);
            A31LocationName = T00048_A31LocationName[0];
            AssignAttri("", false, "A31LocationName", A31LocationName);
            A40000LocationImage_GXI = T00048_A40000LocationImage_GXI[0];
            n40000LocationImage_GXI = T00048_n40000LocationImage_GXI[0];
            AssignProp("", false, imgLocationImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A494LocationImage)) ? A40000LocationImage_GXI : context.convertURL( context.PathToRelativeUrl( A494LocationImage))), true);
            AssignProp("", false, imgLocationImage_Internalname, "SrcSet", context.GetImageSrcSet( A494LocationImage), true);
            A328LocationCity = T00048_A328LocationCity[0];
            AssignAttri("", false, "A328LocationCity", A328LocationCity);
            A330LocationAddressLine1 = T00048_A330LocationAddressLine1[0];
            AssignAttri("", false, "A330LocationAddressLine1", A330LocationAddressLine1);
            A331LocationAddressLine2 = T00048_A331LocationAddressLine2[0];
            AssignAttri("", false, "A331LocationAddressLine2", A331LocationAddressLine2);
            A34LocationEmail = T00048_A34LocationEmail[0];
            AssignAttri("", false, "A34LocationEmail", A34LocationEmail);
            A356LocationPhoneNumber = T00048_A356LocationPhoneNumber[0];
            AssignAttri("", false, "A356LocationPhoneNumber", A356LocationPhoneNumber);
            A36LocationDescription = T00048_A36LocationDescription[0];
            A568LocationBrandTheme = T00048_A568LocationBrandTheme[0];
            n568LocationBrandTheme = T00048_n568LocationBrandTheme[0];
            A569LocationCtaTheme = T00048_A569LocationCtaTheme[0];
            n569LocationCtaTheme = T00048_n569LocationCtaTheme[0];
            A570LocationHasMyCare = T00048_A570LocationHasMyCare[0];
            A571LocationHasMyServices = T00048_A571LocationHasMyServices[0];
            A572LocationHasMyLiving = T00048_A572LocationHasMyLiving[0];
            A573LocationHasOwnBrand = T00048_A573LocationHasOwnBrand[0];
            A504ToolBoxDefaultProfileImage = T00048_A504ToolBoxDefaultProfileImage[0];
            n504ToolBoxDefaultProfileImage = T00048_n504ToolBoxDefaultProfileImage[0];
            A503ToolBoxDefaultLogo = T00048_A503ToolBoxDefaultLogo[0];
            n503ToolBoxDefaultLogo = T00048_n503ToolBoxDefaultLogo[0];
            A40001ReceptionImage_GXI = T00048_A40001ReceptionImage_GXI[0];
            n40001ReceptionImage_GXI = T00048_n40001ReceptionImage_GXI[0];
            A575ReceptionDescription = T00048_A575ReceptionDescription[0];
            n575ReceptionDescription = T00048_n575ReceptionDescription[0];
            A631ToolBoxLastUpdateTime = T00048_A631ToolBoxLastUpdateTime[0];
            n631ToolBoxLastUpdateTime = T00048_n631ToolBoxLastUpdateTime[0];
            A630ToolBoxLastUpdateReceptionistI = T00048_A630ToolBoxLastUpdateReceptionistI[0];
            n630ToolBoxLastUpdateReceptionistI = T00048_n630ToolBoxLastUpdateReceptionistI[0];
            A577LocationThemeId = T00048_A577LocationThemeId[0];
            n577LocationThemeId = T00048_n577LocationThemeId[0];
            A584ActiveAppVersionId = T00048_A584ActiveAppVersionId[0];
            n584ActiveAppVersionId = T00048_n584ActiveAppVersionId[0];
            A598PublishedActiveAppVersionId = T00048_A598PublishedActiveAppVersionId[0];
            n598PublishedActiveAppVersionId = T00048_n598PublishedActiveAppVersionId[0];
            A494LocationImage = T00048_A494LocationImage[0];
            n494LocationImage = T00048_n494LocationImage[0];
            AssignAttri("", false, "A494LocationImage", A494LocationImage);
            AssignProp("", false, imgLocationImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A494LocationImage)) ? A40000LocationImage_GXI : context.convertURL( context.PathToRelativeUrl( A494LocationImage))), true);
            AssignProp("", false, imgLocationImage_Internalname, "SrcSet", context.GetImageSrcSet( A494LocationImage), true);
            A574ReceptionImage = T00048_A574ReceptionImage[0];
            n574ReceptionImage = T00048_n574ReceptionImage[0];
            ZM046( -41) ;
         }
         pr_default.close(6);
         OnLoadActions046( ) ;
      }

      protected void OnLoadActions046( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV34Insert_ActiveAppVersionId) )
         {
            A584ActiveAppVersionId = AV34Insert_ActiveAppVersionId;
            n584ActiveAppVersionId = false;
            AssignAttri("", false, "A584ActiveAppVersionId", A584ActiveAppVersionId.ToString());
         }
         else
         {
            if ( (Guid.Empty==A584ActiveAppVersionId) )
            {
               A584ActiveAppVersionId = Guid.Empty;
               n584ActiveAppVersionId = false;
               AssignAttri("", false, "A584ActiveAppVersionId", A584ActiveAppVersionId.ToString());
               n584ActiveAppVersionId = true;
               AssignAttri("", false, "A584ActiveAppVersionId", A584ActiveAppVersionId.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV40Insert_PublishedActiveAppVersionId) )
         {
            A598PublishedActiveAppVersionId = AV40Insert_PublishedActiveAppVersionId;
            n598PublishedActiveAppVersionId = false;
            AssignAttri("", false, "A598PublishedActiveAppVersionId", A598PublishedActiveAppVersionId.ToString());
         }
         else
         {
            if ( (Guid.Empty==A598PublishedActiveAppVersionId) )
            {
               A598PublishedActiveAppVersionId = Guid.Empty;
               n598PublishedActiveAppVersionId = false;
               AssignAttri("", false, "A598PublishedActiveAppVersionId", A598PublishedActiveAppVersionId.ToString());
               n598PublishedActiveAppVersionId = true;
               AssignAttri("", false, "A598PublishedActiveAppVersionId", A598PublishedActiveAppVersionId.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV43Insert_ToolBoxLastUpdateReceptionistId) )
         {
            A630ToolBoxLastUpdateReceptionistI = AV43Insert_ToolBoxLastUpdateReceptionistId;
            n630ToolBoxLastUpdateReceptionistI = false;
            AssignAttri("", false, "A630ToolBoxLastUpdateReceptionistI", A630ToolBoxLastUpdateReceptionistI.ToString());
         }
         else
         {
            if ( (Guid.Empty==A630ToolBoxLastUpdateReceptionistI) )
            {
               A630ToolBoxLastUpdateReceptionistI = Guid.Empty;
               n630ToolBoxLastUpdateReceptionistI = false;
               AssignAttri("", false, "A630ToolBoxLastUpdateReceptionistI", A630ToolBoxLastUpdateReceptionistI.ToString());
               n630ToolBoxLastUpdateReceptionistI = true;
               AssignAttri("", false, "A630ToolBoxLastUpdateReceptionistI", A630ToolBoxLastUpdateReceptionistI.ToString());
            }
         }
         A329LocationZipCode = StringUtil.Upper( A329LocationZipCode);
         AssignAttri("", false, "A329LocationZipCode", A329LocationZipCode);
         GXt_char2 = A35LocationPhone;
         new prc_concatenateintlphone(context ).execute(  A355LocationPhoneCode,  A356LocationPhoneNumber, out  GXt_char2) ;
         A35LocationPhone = GXt_char2;
         AssignAttri("", false, "A35LocationPhone", A35LocationPhone);
         /* Using cursor T00046 */
         pr_default.execute(4, new Object[] {n584ActiveAppVersionId, A584ActiveAppVersionId});
         A273Trn_ThemeId = T00046_A273Trn_ThemeId[0];
         pr_default.close(4);
         /* Using cursor T00047 */
         pr_default.execute(5, new Object[] {n598PublishedActiveAppVersionId, A598PublishedActiveAppVersionId});
         A273Trn_ThemeId = T00047_A273Trn_ThemeId[0];
         pr_default.close(5);
      }

      protected void CheckExtendedTable046( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV34Insert_ActiveAppVersionId) )
         {
            A584ActiveAppVersionId = AV34Insert_ActiveAppVersionId;
            n584ActiveAppVersionId = false;
            AssignAttri("", false, "A584ActiveAppVersionId", A584ActiveAppVersionId.ToString());
         }
         else
         {
            if ( (Guid.Empty==A584ActiveAppVersionId) )
            {
               A584ActiveAppVersionId = Guid.Empty;
               n584ActiveAppVersionId = false;
               AssignAttri("", false, "A584ActiveAppVersionId", A584ActiveAppVersionId.ToString());
               n584ActiveAppVersionId = true;
               AssignAttri("", false, "A584ActiveAppVersionId", A584ActiveAppVersionId.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV40Insert_PublishedActiveAppVersionId) )
         {
            A598PublishedActiveAppVersionId = AV40Insert_PublishedActiveAppVersionId;
            n598PublishedActiveAppVersionId = false;
            AssignAttri("", false, "A598PublishedActiveAppVersionId", A598PublishedActiveAppVersionId.ToString());
         }
         else
         {
            if ( (Guid.Empty==A598PublishedActiveAppVersionId) )
            {
               A598PublishedActiveAppVersionId = Guid.Empty;
               n598PublishedActiveAppVersionId = false;
               AssignAttri("", false, "A598PublishedActiveAppVersionId", A598PublishedActiveAppVersionId.ToString());
               n598PublishedActiveAppVersionId = true;
               AssignAttri("", false, "A598PublishedActiveAppVersionId", A598PublishedActiveAppVersionId.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV43Insert_ToolBoxLastUpdateReceptionistId) )
         {
            A630ToolBoxLastUpdateReceptionistI = AV43Insert_ToolBoxLastUpdateReceptionistId;
            n630ToolBoxLastUpdateReceptionistI = false;
            AssignAttri("", false, "A630ToolBoxLastUpdateReceptionistI", A630ToolBoxLastUpdateReceptionistI.ToString());
         }
         else
         {
            if ( (Guid.Empty==A630ToolBoxLastUpdateReceptionistI) )
            {
               A630ToolBoxLastUpdateReceptionistI = Guid.Empty;
               n630ToolBoxLastUpdateReceptionistI = false;
               AssignAttri("", false, "A630ToolBoxLastUpdateReceptionistI", A630ToolBoxLastUpdateReceptionistI.ToString());
               n630ToolBoxLastUpdateReceptionistI = true;
               AssignAttri("", false, "A630ToolBoxLastUpdateReceptionistI", A630ToolBoxLastUpdateReceptionistI.ToString());
            }
         }
         /* Using cursor T00044 */
         pr_default.execute(2, new Object[] {n630ToolBoxLastUpdateReceptionistI, A630ToolBoxLastUpdateReceptionistI, n11OrganisationId, A11OrganisationId, n29LocationId, A29LocationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (Guid.Empty==A630ToolBoxLastUpdateReceptionistI) || (Guid.Empty==A11OrganisationId) || (Guid.Empty==A29LocationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), "", "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "LOCATIONID");
               AnyError = 1;
               GX_FocusControl = edtOrganisationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
         A329LocationZipCode = StringUtil.Upper( A329LocationZipCode);
         AssignAttri("", false, "A329LocationZipCode", A329LocationZipCode);
         if ( ! GxRegex.IsMatch(A329LocationZipCode,context.GetMessage( "^\\d{4}\\s?[A-Z]{2}$", "")) && ! String.IsNullOrEmpty(StringUtil.RTrim( A329LocationZipCode)) )
         {
            GX_msglist.addItem(context.GetMessage( "Zip Code is incorrect", ""), 1, "LOCATIONZIPCODE");
            AnyError = 1;
            GX_FocusControl = edtLocationZipCode_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A34LocationEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "Invalid email pattern", ""), context.GetMessage( "Location Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "LOCATIONEMAIL");
            AnyError = 1;
            GX_FocusControl = edtLocationEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A34LocationEmail)) && ! GxRegex.IsMatch(A34LocationEmail,context.GetMessage( "^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Email format is invalid", ""), 1, "LOCATIONEMAIL");
            AnyError = 1;
            GX_FocusControl = edtLocationEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GXt_char2 = A35LocationPhone;
         new prc_concatenateintlphone(context ).execute(  A355LocationPhoneCode,  A356LocationPhoneNumber, out  GXt_char2) ;
         A35LocationPhone = GXt_char2;
         AssignAttri("", false, "A35LocationPhone", A35LocationPhone);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A356LocationPhoneNumber)) && ! GxRegex.IsMatch(A356LocationPhoneNumber,context.GetMessage( "^\\d{9}$", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Phone contains 9 digits", ""), 1, "LOCATIONPHONENUMBER");
            AnyError = 1;
            GX_FocusControl = edtLocationPhoneNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00045 */
         pr_default.execute(3, new Object[] {n577LocationThemeId, A577LocationThemeId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (Guid.Empty==A577LocationThemeId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "SG_Location Theme", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "LOCATIONTHEMEID");
               AnyError = 1;
            }
         }
         pr_default.close(3);
         /* Using cursor T00046 */
         pr_default.execute(4, new Object[] {n584ActiveAppVersionId, A584ActiveAppVersionId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (Guid.Empty==A584ActiveAppVersionId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), "", "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ACTIVEAPPVERSIONID");
               AnyError = 1;
            }
         }
         A273Trn_ThemeId = T00046_A273Trn_ThemeId[0];
         pr_default.close(4);
         /* Using cursor T00047 */
         pr_default.execute(5, new Object[] {n598PublishedActiveAppVersionId, A598PublishedActiveAppVersionId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (Guid.Empty==A598PublishedActiveAppVersionId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), "", "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PUBLISHEDACTIVEAPPVERSIONID");
               AnyError = 1;
            }
         }
         A273Trn_ThemeId = T00047_A273Trn_ThemeId[0];
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors046( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_42( Guid A630ToolBoxLastUpdateReceptionistI ,
                                Guid A11OrganisationId ,
                                Guid A29LocationId )
      {
         /* Using cursor T00049 */
         pr_default.execute(7, new Object[] {n630ToolBoxLastUpdateReceptionistI, A630ToolBoxLastUpdateReceptionistI, n11OrganisationId, A11OrganisationId, n29LocationId, A29LocationId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (Guid.Empty==A630ToolBoxLastUpdateReceptionistI) || (Guid.Empty==A11OrganisationId) || (Guid.Empty==A29LocationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), "", "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "LOCATIONID");
               AnyError = 1;
               GX_FocusControl = edtOrganisationId_Internalname;
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

      protected void gxLoad_43( Guid A577LocationThemeId )
      {
         /* Using cursor T000410 */
         pr_default.execute(8, new Object[] {n577LocationThemeId, A577LocationThemeId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (Guid.Empty==A577LocationThemeId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "SG_Location Theme", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "LOCATIONTHEMEID");
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

      protected void gxLoad_44( Guid A584ActiveAppVersionId )
      {
         /* Using cursor T000411 */
         pr_default.execute(9, new Object[] {n584ActiveAppVersionId, A584ActiveAppVersionId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (Guid.Empty==A584ActiveAppVersionId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), "", "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ACTIVEAPPVERSIONID");
               AnyError = 1;
            }
         }
         A273Trn_ThemeId = T000411_A273Trn_ThemeId[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A273Trn_ThemeId.ToString())+"\""+","+"\""+GXUtil.EncodeJSConstant( A598PublishedActiveAppVersionId.ToString())+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_45( Guid A598PublishedActiveAppVersionId )
      {
         /* Using cursor T000412 */
         pr_default.execute(10, new Object[] {n598PublishedActiveAppVersionId, A598PublishedActiveAppVersionId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (Guid.Empty==A598PublishedActiveAppVersionId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), "", "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PUBLISHEDACTIVEAPPVERSIONID");
               AnyError = 1;
            }
         }
         A273Trn_ThemeId = T000412_A273Trn_ThemeId[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A273Trn_ThemeId.ToString())+"\""+","+"\""+GXUtil.EncodeJSConstant( A584ActiveAppVersionId.ToString())+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void GetKey046( )
      {
         /* Using cursor T000413 */
         pr_default.execute(11, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(11);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00043 */
         pr_default.execute(1, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM046( 41) ;
            RcdFound6 = 1;
            A327LocationCountry = T00043_A327LocationCountry[0];
            AssignAttri("", false, "A327LocationCountry", A327LocationCountry);
            A355LocationPhoneCode = T00043_A355LocationPhoneCode[0];
            AssignAttri("", false, "A355LocationPhoneCode", A355LocationPhoneCode);
            A35LocationPhone = T00043_A35LocationPhone[0];
            AssignAttri("", false, "A35LocationPhone", A35LocationPhone);
            A329LocationZipCode = T00043_A329LocationZipCode[0];
            AssignAttri("", false, "A329LocationZipCode", A329LocationZipCode);
            A31LocationName = T00043_A31LocationName[0];
            AssignAttri("", false, "A31LocationName", A31LocationName);
            A40000LocationImage_GXI = T00043_A40000LocationImage_GXI[0];
            n40000LocationImage_GXI = T00043_n40000LocationImage_GXI[0];
            AssignProp("", false, imgLocationImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A494LocationImage)) ? A40000LocationImage_GXI : context.convertURL( context.PathToRelativeUrl( A494LocationImage))), true);
            AssignProp("", false, imgLocationImage_Internalname, "SrcSet", context.GetImageSrcSet( A494LocationImage), true);
            A328LocationCity = T00043_A328LocationCity[0];
            AssignAttri("", false, "A328LocationCity", A328LocationCity);
            A330LocationAddressLine1 = T00043_A330LocationAddressLine1[0];
            AssignAttri("", false, "A330LocationAddressLine1", A330LocationAddressLine1);
            A331LocationAddressLine2 = T00043_A331LocationAddressLine2[0];
            AssignAttri("", false, "A331LocationAddressLine2", A331LocationAddressLine2);
            A34LocationEmail = T00043_A34LocationEmail[0];
            AssignAttri("", false, "A34LocationEmail", A34LocationEmail);
            A356LocationPhoneNumber = T00043_A356LocationPhoneNumber[0];
            AssignAttri("", false, "A356LocationPhoneNumber", A356LocationPhoneNumber);
            A36LocationDescription = T00043_A36LocationDescription[0];
            A568LocationBrandTheme = T00043_A568LocationBrandTheme[0];
            n568LocationBrandTheme = T00043_n568LocationBrandTheme[0];
            A569LocationCtaTheme = T00043_A569LocationCtaTheme[0];
            n569LocationCtaTheme = T00043_n569LocationCtaTheme[0];
            A570LocationHasMyCare = T00043_A570LocationHasMyCare[0];
            A571LocationHasMyServices = T00043_A571LocationHasMyServices[0];
            A572LocationHasMyLiving = T00043_A572LocationHasMyLiving[0];
            A573LocationHasOwnBrand = T00043_A573LocationHasOwnBrand[0];
            A504ToolBoxDefaultProfileImage = T00043_A504ToolBoxDefaultProfileImage[0];
            n504ToolBoxDefaultProfileImage = T00043_n504ToolBoxDefaultProfileImage[0];
            A503ToolBoxDefaultLogo = T00043_A503ToolBoxDefaultLogo[0];
            n503ToolBoxDefaultLogo = T00043_n503ToolBoxDefaultLogo[0];
            A40001ReceptionImage_GXI = T00043_A40001ReceptionImage_GXI[0];
            n40001ReceptionImage_GXI = T00043_n40001ReceptionImage_GXI[0];
            A575ReceptionDescription = T00043_A575ReceptionDescription[0];
            n575ReceptionDescription = T00043_n575ReceptionDescription[0];
            A631ToolBoxLastUpdateTime = T00043_A631ToolBoxLastUpdateTime[0];
            n631ToolBoxLastUpdateTime = T00043_n631ToolBoxLastUpdateTime[0];
            A630ToolBoxLastUpdateReceptionistI = T00043_A630ToolBoxLastUpdateReceptionistI[0];
            n630ToolBoxLastUpdateReceptionistI = T00043_n630ToolBoxLastUpdateReceptionistI[0];
            A11OrganisationId = T00043_A11OrganisationId[0];
            n11OrganisationId = T00043_n11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A29LocationId = T00043_A29LocationId[0];
            n29LocationId = T00043_n29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A577LocationThemeId = T00043_A577LocationThemeId[0];
            n577LocationThemeId = T00043_n577LocationThemeId[0];
            A584ActiveAppVersionId = T00043_A584ActiveAppVersionId[0];
            n584ActiveAppVersionId = T00043_n584ActiveAppVersionId[0];
            A598PublishedActiveAppVersionId = T00043_A598PublishedActiveAppVersionId[0];
            n598PublishedActiveAppVersionId = T00043_n598PublishedActiveAppVersionId[0];
            A494LocationImage = T00043_A494LocationImage[0];
            n494LocationImage = T00043_n494LocationImage[0];
            AssignAttri("", false, "A494LocationImage", A494LocationImage);
            AssignProp("", false, imgLocationImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A494LocationImage)) ? A40000LocationImage_GXI : context.convertURL( context.PathToRelativeUrl( A494LocationImage))), true);
            AssignProp("", false, imgLocationImage_Internalname, "SrcSet", context.GetImageSrcSet( A494LocationImage), true);
            A574ReceptionImage = T00043_A574ReceptionImage[0];
            n574ReceptionImage = T00043_n574ReceptionImage[0];
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load046( ) ;
            if ( AnyError == 1 )
            {
               RcdFound6 = 0;
               InitializeNonKey046( ) ;
            }
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey046( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey046( ) ;
         if ( RcdFound6 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound6 = 0;
         /* Using cursor T000414 */
         pr_default.execute(12, new Object[] {n11OrganisationId, A11OrganisationId, n29LocationId, A29LocationId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( GuidUtil.Compare(T000414_A11OrganisationId[0], A11OrganisationId, 0) < 0 ) || ( T000414_A11OrganisationId[0] == A11OrganisationId ) && ( GuidUtil.Compare(T000414_A29LocationId[0], A29LocationId, 0) < 0 ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( GuidUtil.Compare(T000414_A11OrganisationId[0], A11OrganisationId, 0) > 0 ) || ( T000414_A11OrganisationId[0] == A11OrganisationId ) && ( GuidUtil.Compare(T000414_A29LocationId[0], A29LocationId, 0) > 0 ) ) )
            {
               A11OrganisationId = T000414_A11OrganisationId[0];
               n11OrganisationId = T000414_n11OrganisationId[0];
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               A29LocationId = T000414_A29LocationId[0];
               n29LocationId = T000414_n29LocationId[0];
               AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
               RcdFound6 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void move_previous( )
      {
         RcdFound6 = 0;
         /* Using cursor T000415 */
         pr_default.execute(13, new Object[] {n11OrganisationId, A11OrganisationId, n29LocationId, A29LocationId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( GuidUtil.Compare(T000415_A11OrganisationId[0], A11OrganisationId, 0) > 0 ) || ( T000415_A11OrganisationId[0] == A11OrganisationId ) && ( GuidUtil.Compare(T000415_A29LocationId[0], A29LocationId, 0) > 0 ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( GuidUtil.Compare(T000415_A11OrganisationId[0], A11OrganisationId, 0) < 0 ) || ( T000415_A11OrganisationId[0] == A11OrganisationId ) && ( GuidUtil.Compare(T000415_A29LocationId[0], A29LocationId, 0) < 0 ) ) )
            {
               A11OrganisationId = T000415_A11OrganisationId[0];
               n11OrganisationId = T000415_n11OrganisationId[0];
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               A29LocationId = T000415_A29LocationId[0];
               n29LocationId = T000415_n29LocationId[0];
               AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
               RcdFound6 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey046( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtLocationName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert046( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound6 == 1 )
            {
               if ( ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
               {
                  A29LocationId = Z29LocationId;
                  n29LocationId = false;
                  AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
                  A11OrganisationId = Z11OrganisationId;
                  n11OrganisationId = false;
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "LOCATIONID");
                  AnyError = 1;
                  GX_FocusControl = edtLocationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtLocationName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update046( ) ;
                  GX_FocusControl = edtLocationName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtLocationName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert046( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "LOCATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtLocationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtLocationName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert046( ) ;
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
         if ( ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
         {
            A29LocationId = Z29LocationId;
            n29LocationId = false;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = Z11OrganisationId;
            n11OrganisationId = false;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "LOCATIONID");
            AnyError = 1;
            GX_FocusControl = edtLocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtLocationName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency046( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00042 */
            pr_default.execute(0, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Location"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z327LocationCountry, T00042_A327LocationCountry[0]) != 0 ) || ( StringUtil.StrCmp(Z355LocationPhoneCode, T00042_A355LocationPhoneCode[0]) != 0 ) || ( StringUtil.StrCmp(Z35LocationPhone, T00042_A35LocationPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z329LocationZipCode, T00042_A329LocationZipCode[0]) != 0 ) || ( StringUtil.StrCmp(Z31LocationName, T00042_A31LocationName[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z328LocationCity, T00042_A328LocationCity[0]) != 0 ) || ( StringUtil.StrCmp(Z330LocationAddressLine1, T00042_A330LocationAddressLine1[0]) != 0 ) || ( StringUtil.StrCmp(Z331LocationAddressLine2, T00042_A331LocationAddressLine2[0]) != 0 ) || ( StringUtil.StrCmp(Z34LocationEmail, T00042_A34LocationEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z356LocationPhoneNumber, T00042_A356LocationPhoneNumber[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z570LocationHasMyCare != T00042_A570LocationHasMyCare[0] ) || ( Z571LocationHasMyServices != T00042_A571LocationHasMyServices[0] ) || ( Z572LocationHasMyLiving != T00042_A572LocationHasMyLiving[0] ) || ( Z573LocationHasOwnBrand != T00042_A573LocationHasOwnBrand[0] ) || ( StringUtil.StrCmp(Z504ToolBoxDefaultProfileImage, T00042_A504ToolBoxDefaultProfileImage[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z503ToolBoxDefaultLogo, T00042_A503ToolBoxDefaultLogo[0]) != 0 ) || ( StringUtil.StrCmp(Z575ReceptionDescription, T00042_A575ReceptionDescription[0]) != 0 ) || ( Z631ToolBoxLastUpdateTime != T00042_A631ToolBoxLastUpdateTime[0] ) || ( Z630ToolBoxLastUpdateReceptionistI != T00042_A630ToolBoxLastUpdateReceptionistI[0] ) || ( Z577LocationThemeId != T00042_A577LocationThemeId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z584ActiveAppVersionId != T00042_A584ActiveAppVersionId[0] ) || ( Z598PublishedActiveAppVersionId != T00042_A598PublishedActiveAppVersionId[0] ) )
            {
               if ( StringUtil.StrCmp(Z327LocationCountry, T00042_A327LocationCountry[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"LocationCountry");
                  GXUtil.WriteLogRaw("Old: ",Z327LocationCountry);
                  GXUtil.WriteLogRaw("Current: ",T00042_A327LocationCountry[0]);
               }
               if ( StringUtil.StrCmp(Z355LocationPhoneCode, T00042_A355LocationPhoneCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"LocationPhoneCode");
                  GXUtil.WriteLogRaw("Old: ",Z355LocationPhoneCode);
                  GXUtil.WriteLogRaw("Current: ",T00042_A355LocationPhoneCode[0]);
               }
               if ( StringUtil.StrCmp(Z35LocationPhone, T00042_A35LocationPhone[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"LocationPhone");
                  GXUtil.WriteLogRaw("Old: ",Z35LocationPhone);
                  GXUtil.WriteLogRaw("Current: ",T00042_A35LocationPhone[0]);
               }
               if ( StringUtil.StrCmp(Z329LocationZipCode, T00042_A329LocationZipCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"LocationZipCode");
                  GXUtil.WriteLogRaw("Old: ",Z329LocationZipCode);
                  GXUtil.WriteLogRaw("Current: ",T00042_A329LocationZipCode[0]);
               }
               if ( StringUtil.StrCmp(Z31LocationName, T00042_A31LocationName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"LocationName");
                  GXUtil.WriteLogRaw("Old: ",Z31LocationName);
                  GXUtil.WriteLogRaw("Current: ",T00042_A31LocationName[0]);
               }
               if ( StringUtil.StrCmp(Z328LocationCity, T00042_A328LocationCity[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"LocationCity");
                  GXUtil.WriteLogRaw("Old: ",Z328LocationCity);
                  GXUtil.WriteLogRaw("Current: ",T00042_A328LocationCity[0]);
               }
               if ( StringUtil.StrCmp(Z330LocationAddressLine1, T00042_A330LocationAddressLine1[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"LocationAddressLine1");
                  GXUtil.WriteLogRaw("Old: ",Z330LocationAddressLine1);
                  GXUtil.WriteLogRaw("Current: ",T00042_A330LocationAddressLine1[0]);
               }
               if ( StringUtil.StrCmp(Z331LocationAddressLine2, T00042_A331LocationAddressLine2[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"LocationAddressLine2");
                  GXUtil.WriteLogRaw("Old: ",Z331LocationAddressLine2);
                  GXUtil.WriteLogRaw("Current: ",T00042_A331LocationAddressLine2[0]);
               }
               if ( StringUtil.StrCmp(Z34LocationEmail, T00042_A34LocationEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"LocationEmail");
                  GXUtil.WriteLogRaw("Old: ",Z34LocationEmail);
                  GXUtil.WriteLogRaw("Current: ",T00042_A34LocationEmail[0]);
               }
               if ( StringUtil.StrCmp(Z356LocationPhoneNumber, T00042_A356LocationPhoneNumber[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"LocationPhoneNumber");
                  GXUtil.WriteLogRaw("Old: ",Z356LocationPhoneNumber);
                  GXUtil.WriteLogRaw("Current: ",T00042_A356LocationPhoneNumber[0]);
               }
               if ( Z570LocationHasMyCare != T00042_A570LocationHasMyCare[0] )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"LocationHasMyCare");
                  GXUtil.WriteLogRaw("Old: ",Z570LocationHasMyCare);
                  GXUtil.WriteLogRaw("Current: ",T00042_A570LocationHasMyCare[0]);
               }
               if ( Z571LocationHasMyServices != T00042_A571LocationHasMyServices[0] )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"LocationHasMyServices");
                  GXUtil.WriteLogRaw("Old: ",Z571LocationHasMyServices);
                  GXUtil.WriteLogRaw("Current: ",T00042_A571LocationHasMyServices[0]);
               }
               if ( Z572LocationHasMyLiving != T00042_A572LocationHasMyLiving[0] )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"LocationHasMyLiving");
                  GXUtil.WriteLogRaw("Old: ",Z572LocationHasMyLiving);
                  GXUtil.WriteLogRaw("Current: ",T00042_A572LocationHasMyLiving[0]);
               }
               if ( Z573LocationHasOwnBrand != T00042_A573LocationHasOwnBrand[0] )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"LocationHasOwnBrand");
                  GXUtil.WriteLogRaw("Old: ",Z573LocationHasOwnBrand);
                  GXUtil.WriteLogRaw("Current: ",T00042_A573LocationHasOwnBrand[0]);
               }
               if ( StringUtil.StrCmp(Z504ToolBoxDefaultProfileImage, T00042_A504ToolBoxDefaultProfileImage[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"ToolBoxDefaultProfileImage");
                  GXUtil.WriteLogRaw("Old: ",Z504ToolBoxDefaultProfileImage);
                  GXUtil.WriteLogRaw("Current: ",T00042_A504ToolBoxDefaultProfileImage[0]);
               }
               if ( StringUtil.StrCmp(Z503ToolBoxDefaultLogo, T00042_A503ToolBoxDefaultLogo[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"ToolBoxDefaultLogo");
                  GXUtil.WriteLogRaw("Old: ",Z503ToolBoxDefaultLogo);
                  GXUtil.WriteLogRaw("Current: ",T00042_A503ToolBoxDefaultLogo[0]);
               }
               if ( StringUtil.StrCmp(Z575ReceptionDescription, T00042_A575ReceptionDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"ReceptionDescription");
                  GXUtil.WriteLogRaw("Old: ",Z575ReceptionDescription);
                  GXUtil.WriteLogRaw("Current: ",T00042_A575ReceptionDescription[0]);
               }
               if ( Z631ToolBoxLastUpdateTime != T00042_A631ToolBoxLastUpdateTime[0] )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"ToolBoxLastUpdateTime");
                  GXUtil.WriteLogRaw("Old: ",Z631ToolBoxLastUpdateTime);
                  GXUtil.WriteLogRaw("Current: ",T00042_A631ToolBoxLastUpdateTime[0]);
               }
               if ( Z630ToolBoxLastUpdateReceptionistI != T00042_A630ToolBoxLastUpdateReceptionistI[0] )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"ToolBoxLastUpdateReceptionistI");
                  GXUtil.WriteLogRaw("Old: ",Z630ToolBoxLastUpdateReceptionistI);
                  GXUtil.WriteLogRaw("Current: ",T00042_A630ToolBoxLastUpdateReceptionistI[0]);
               }
               if ( Z577LocationThemeId != T00042_A577LocationThemeId[0] )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"LocationThemeId");
                  GXUtil.WriteLogRaw("Old: ",Z577LocationThemeId);
                  GXUtil.WriteLogRaw("Current: ",T00042_A577LocationThemeId[0]);
               }
               if ( Z584ActiveAppVersionId != T00042_A584ActiveAppVersionId[0] )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"ActiveAppVersionId");
                  GXUtil.WriteLogRaw("Old: ",Z584ActiveAppVersionId);
                  GXUtil.WriteLogRaw("Current: ",T00042_A584ActiveAppVersionId[0]);
               }
               if ( Z598PublishedActiveAppVersionId != T00042_A598PublishedActiveAppVersionId[0] )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"PublishedActiveAppVersionId");
                  GXUtil.WriteLogRaw("Old: ",Z598PublishedActiveAppVersionId);
                  GXUtil.WriteLogRaw("Current: ",T00042_A598PublishedActiveAppVersionId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Location"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert046( )
      {
         if ( ! IsAuthorized("trn_location_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate046( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable046( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM046( 0) ;
            CheckOptimisticConcurrency046( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm046( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert046( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000416 */
                     pr_default.execute(14, new Object[] {A327LocationCountry, A355LocationPhoneCode, A35LocationPhone, A329LocationZipCode, A31LocationName, n494LocationImage, A494LocationImage, n40000LocationImage_GXI, A40000LocationImage_GXI, A328LocationCity, A330LocationAddressLine1, A331LocationAddressLine2, A34LocationEmail, A356LocationPhoneNumber, A36LocationDescription, n568LocationBrandTheme, A568LocationBrandTheme, n569LocationCtaTheme, A569LocationCtaTheme, A570LocationHasMyCare, A571LocationHasMyServices, A572LocationHasMyLiving, A573LocationHasOwnBrand, n504ToolBoxDefaultProfileImage, A504ToolBoxDefaultProfileImage, n503ToolBoxDefaultLogo, A503ToolBoxDefaultLogo, n574ReceptionImage, A574ReceptionImage, n40001ReceptionImage_GXI, A40001ReceptionImage_GXI, n575ReceptionDescription, A575ReceptionDescription, n631ToolBoxLastUpdateTime, A631ToolBoxLastUpdateTime, n630ToolBoxLastUpdateReceptionistI, A630ToolBoxLastUpdateReceptionistI, n11OrganisationId, A11OrganisationId, n29LocationId, A29LocationId, n577LocationThemeId, A577LocationThemeId, n584ActiveAppVersionId, A584ActiveAppVersionId, n598PublishedActiveAppVersionId, A598PublishedActiveAppVersionId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Location");
                     if ( (pr_default.getStatus(14) == 1) )
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
                           ResetCaption040( ) ;
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
               Load046( ) ;
            }
            EndLevel046( ) ;
         }
         CloseExtendedTableCursors046( ) ;
      }

      protected void Update046( )
      {
         if ( ! IsAuthorized("trn_location_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate046( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable046( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency046( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm046( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate046( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000417 */
                     pr_default.execute(15, new Object[] {A327LocationCountry, A355LocationPhoneCode, A35LocationPhone, A329LocationZipCode, A31LocationName, A328LocationCity, A330LocationAddressLine1, A331LocationAddressLine2, A34LocationEmail, A356LocationPhoneNumber, A36LocationDescription, n568LocationBrandTheme, A568LocationBrandTheme, n569LocationCtaTheme, A569LocationCtaTheme, A570LocationHasMyCare, A571LocationHasMyServices, A572LocationHasMyLiving, A573LocationHasOwnBrand, n504ToolBoxDefaultProfileImage, A504ToolBoxDefaultProfileImage, n503ToolBoxDefaultLogo, A503ToolBoxDefaultLogo, n575ReceptionDescription, A575ReceptionDescription, n631ToolBoxLastUpdateTime, A631ToolBoxLastUpdateTime, n630ToolBoxLastUpdateReceptionistI, A630ToolBoxLastUpdateReceptionistI, n577LocationThemeId, A577LocationThemeId, n584ActiveAppVersionId, A584ActiveAppVersionId, n598PublishedActiveAppVersionId, A598PublishedActiveAppVersionId, n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Location");
                     if ( (pr_default.getStatus(15) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Location"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate046( ) ;
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
            EndLevel046( ) ;
         }
         CloseExtendedTableCursors046( ) ;
      }

      protected void DeferredUpdate046( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000418 */
            pr_default.execute(16, new Object[] {n494LocationImage, A494LocationImage, n40000LocationImage_GXI, A40000LocationImage_GXI, n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            pr_default.close(16);
            pr_default.SmartCacheProvider.SetUpdated("Trn_Location");
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000419 */
            pr_default.execute(17, new Object[] {n574ReceptionImage, A574ReceptionImage, n40001ReceptionImage_GXI, A40001ReceptionImage_GXI, n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            pr_default.close(17);
            pr_default.SmartCacheProvider.SetUpdated("Trn_Location");
         }
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_location_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate046( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency046( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls046( ) ;
            AfterConfirm046( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete046( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000420 */
                  pr_default.execute(18, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
                  pr_default.close(18);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Location");
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
         sMode6 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel046( ) ;
         Gx_mode = sMode6;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls046( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000421 */
            pr_default.execute(19, new Object[] {n584ActiveAppVersionId, A584ActiveAppVersionId});
            A273Trn_ThemeId = T000421_A273Trn_ThemeId[0];
            pr_default.close(19);
            /* Using cursor T000422 */
            pr_default.execute(20, new Object[] {n598PublishedActiveAppVersionId, A598PublishedActiveAppVersionId});
            A273Trn_ThemeId = T000422_A273Trn_ThemeId[0];
            pr_default.close(20);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000423 */
            pr_default.execute(21, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "General Suppliers", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor T000424 */
            pr_default.execute(22, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_ResidentPackage", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor T000425 */
            pr_default.execute(23, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor T000426 */
            pr_default.execute(24, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Agenda/Calendar", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
            /* Using cursor T000427 */
            pr_default.execute(25, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Location Dynamic Forms", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
            /* Using cursor T000428 */
            pr_default.execute(26, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Services", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
            /* Using cursor T000429 */
            pr_default.execute(27, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_Resident", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(27);
            /* Using cursor T000430 */
            pr_default.execute(28, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(28) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(28);
         }
      }

      protected void EndLevel046( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete046( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_location",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues040( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_location",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart046( )
      {
         /* Scan By routine */
         /* Using cursor T000431 */
         pr_default.execute(29);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound6 = 1;
            A29LocationId = T000431_A29LocationId[0];
            n29LocationId = T000431_n29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = T000431_A11OrganisationId[0];
            n11OrganisationId = T000431_n11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext046( )
      {
         /* Scan next routine */
         pr_default.readNext(29);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound6 = 1;
            A29LocationId = T000431_A29LocationId[0];
            n29LocationId = T000431_n29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = T000431_A11OrganisationId[0];
            n11OrganisationId = T000431_n11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
      }

      protected void ScanEnd046( )
      {
         pr_default.close(29);
      }

      protected void AfterConfirm046( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert046( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate046( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete046( )
      {
         /* Before Delete Rules */
         new trn_deletelocationpages(context ).execute(  A29LocationId) ;
      }

      protected void BeforeComplete046( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate046( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes046( )
      {
         edtLocationName_Enabled = 0;
         AssignProp("", false, edtLocationName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationName_Enabled), 5, 0), true);
         edtLocationEmail_Enabled = 0;
         AssignProp("", false, edtLocationEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationEmail_Enabled), 5, 0), true);
         edtLocationPhoneCode_Enabled = 0;
         AssignProp("", false, edtLocationPhoneCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationPhoneCode_Enabled), 5, 0), true);
         edtLocationPhoneNumber_Enabled = 0;
         AssignProp("", false, edtLocationPhoneNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationPhoneNumber_Enabled), 5, 0), true);
         edtLocationPhone_Enabled = 0;
         AssignProp("", false, edtLocationPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationPhone_Enabled), 5, 0), true);
         edtLocationAddressLine1_Enabled = 0;
         AssignProp("", false, edtLocationAddressLine1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationAddressLine1_Enabled), 5, 0), true);
         edtLocationAddressLine2_Enabled = 0;
         AssignProp("", false, edtLocationAddressLine2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationAddressLine2_Enabled), 5, 0), true);
         edtLocationZipCode_Enabled = 0;
         AssignProp("", false, edtLocationZipCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationZipCode_Enabled), 5, 0), true);
         edtLocationCity_Enabled = 0;
         AssignProp("", false, edtLocationCity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationCity_Enabled), 5, 0), true);
         edtLocationCountry_Enabled = 0;
         AssignProp("", false, edtLocationCountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationCountry_Enabled), 5, 0), true);
         edtavCombolocationphonecode_Enabled = 0;
         AssignProp("", false, edtavCombolocationphonecode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombolocationphonecode_Enabled), 5, 0), true);
         edtavCombolocationcountry_Enabled = 0;
         AssignProp("", false, edtavCombolocationcountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombolocationcountry_Enabled), 5, 0), true);
         edtLocationId_Enabled = 0;
         AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         edtOrganisationId_Enabled = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         imgLocationImage_Enabled = 0;
         AssignProp("", false, imgLocationImage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgLocationImage_Enabled), 5, 0), true);
         Locationdescription_Enabled = Convert.ToBoolean( 0);
         AssignProp("", false, Locationdescription_Internalname, "Enabled", StringUtil.BoolToStr( Locationdescription_Enabled), true);
      }

      protected void send_integrity_lvl_hashes046( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues040( )
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
         context.AddJavascriptSource("UserControls/UC_CustomImageUploadRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_location.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(AV7LocationId.ToString()),UrlEncode(AV8OrganisationId.ToString())}, new string[] {"Gx_mode","LocationId","OrganisationId"}) +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Location");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("LocationHasMyCare", StringUtil.BoolToStr( A570LocationHasMyCare));
         forbiddenHiddens.Add("LocationHasMyServices", StringUtil.BoolToStr( A571LocationHasMyServices));
         forbiddenHiddens.Add("LocationHasMyLiving", StringUtil.BoolToStr( A572LocationHasMyLiving));
         forbiddenHiddens.Add("LocationHasOwnBrand", StringUtil.BoolToStr( A573LocationHasOwnBrand));
         forbiddenHiddens.Add("ToolBoxDefaultProfileImage", StringUtil.RTrim( context.localUtil.Format( A504ToolBoxDefaultProfileImage, "")));
         forbiddenHiddens.Add("ToolBoxDefaultLogo", StringUtil.RTrim( context.localUtil.Format( A503ToolBoxDefaultLogo, "")));
         forbiddenHiddens.Add("ReceptionDescription", StringUtil.RTrim( context.localUtil.Format( A575ReceptionDescription, "")));
         forbiddenHiddens.Add("ToolBoxLastUpdateTime", context.localUtil.Format( A631ToolBoxLastUpdateTime, "99:99"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_location:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z29LocationId", Z29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z11OrganisationId", Z11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z327LocationCountry", Z327LocationCountry);
         GxWebStd.gx_hidden_field( context, "Z355LocationPhoneCode", Z355LocationPhoneCode);
         GxWebStd.gx_hidden_field( context, "Z35LocationPhone", StringUtil.RTrim( Z35LocationPhone));
         GxWebStd.gx_hidden_field( context, "Z329LocationZipCode", Z329LocationZipCode);
         GxWebStd.gx_hidden_field( context, "Z31LocationName", Z31LocationName);
         GxWebStd.gx_hidden_field( context, "Z328LocationCity", Z328LocationCity);
         GxWebStd.gx_hidden_field( context, "Z330LocationAddressLine1", Z330LocationAddressLine1);
         GxWebStd.gx_hidden_field( context, "Z331LocationAddressLine2", Z331LocationAddressLine2);
         GxWebStd.gx_hidden_field( context, "Z34LocationEmail", Z34LocationEmail);
         GxWebStd.gx_hidden_field( context, "Z356LocationPhoneNumber", Z356LocationPhoneNumber);
         GxWebStd.gx_boolean_hidden_field( context, "Z570LocationHasMyCare", Z570LocationHasMyCare);
         GxWebStd.gx_boolean_hidden_field( context, "Z571LocationHasMyServices", Z571LocationHasMyServices);
         GxWebStd.gx_boolean_hidden_field( context, "Z572LocationHasMyLiving", Z572LocationHasMyLiving);
         GxWebStd.gx_boolean_hidden_field( context, "Z573LocationHasOwnBrand", Z573LocationHasOwnBrand);
         GxWebStd.gx_hidden_field( context, "Z504ToolBoxDefaultProfileImage", Z504ToolBoxDefaultProfileImage);
         GxWebStd.gx_hidden_field( context, "Z503ToolBoxDefaultLogo", Z503ToolBoxDefaultLogo);
         GxWebStd.gx_hidden_field( context, "Z575ReceptionDescription", Z575ReceptionDescription);
         GxWebStd.gx_hidden_field( context, "Z631ToolBoxLastUpdateTime", context.localUtil.TToC( Z631ToolBoxLastUpdateTime, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z630ToolBoxLastUpdateReceptionistI", Z630ToolBoxLastUpdateReceptionistI.ToString());
         GxWebStd.gx_hidden_field( context, "Z577LocationThemeId", Z577LocationThemeId.ToString());
         GxWebStd.gx_hidden_field( context, "Z584ActiveAppVersionId", Z584ActiveAppVersionId.ToString());
         GxWebStd.gx_hidden_field( context, "Z598PublishedActiveAppVersionId", Z598PublishedActiveAppVersionId.ToString());
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N584ActiveAppVersionId", A584ActiveAppVersionId.ToString());
         GxWebStd.gx_hidden_field( context, "N598PublishedActiveAppVersionId", A598PublishedActiveAppVersionId.ToString());
         GxWebStd.gx_hidden_field( context, "N577LocationThemeId", A577LocationThemeId.ToString());
         GxWebStd.gx_hidden_field( context, "N630ToolBoxLastUpdateReceptionistI", A630ToolBoxLastUpdateReceptionistI.ToString());
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLOCATIONPHONECODE_DATA", AV21LocationPhoneCode_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLOCATIONPHONECODE_DATA", AV21LocationPhoneCode_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUPLOADEDFILES", AV42UploadedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUPLOADEDFILES", AV42UploadedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILESTOUPDATE", AV41FilesToUpdate);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILESTOUPDATE", AV41FilesToUpdate);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLOCATIONCOUNTRY_DATA", AV22LocationCountry_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLOCATIONCOUNTRY_DATA", AV22LocationCountry_Data);
         }
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
         GxWebStd.gx_boolean_hidden_field( context, "vISSUCCESSFUL", AV28isSuccessful);
         GxWebStd.gx_hidden_field( context, "vMESSAGE", StringUtil.RTrim( AV29Message));
         GxWebStd.gx_hidden_field( context, "vLOCATIONID", AV7LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", AV7LocationId, context));
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV8OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV8OrganisationId, context));
         GxWebStd.gx_hidden_field( context, "vINSERT_ACTIVEAPPVERSIONID", AV34Insert_ActiveAppVersionId.ToString());
         GxWebStd.gx_hidden_field( context, "ACTIVEAPPVERSIONID", A584ActiveAppVersionId.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_PUBLISHEDACTIVEAPPVERSIONID", AV40Insert_PublishedActiveAppVersionId.ToString());
         GxWebStd.gx_hidden_field( context, "PUBLISHEDACTIVEAPPVERSIONID", A598PublishedActiveAppVersionId.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_LOCATIONTHEMEID", AV32Insert_LocationThemeId.ToString());
         GxWebStd.gx_hidden_field( context, "LOCATIONTHEMEID", A577LocationThemeId.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_TOOLBOXLASTUPDATERECEPTIONISTID", AV43Insert_ToolBoxLastUpdateReceptionistId.ToString());
         GxWebStd.gx_hidden_field( context, "TOOLBOXLASTUPDATERECEPTIONISTI", A630ToolBoxLastUpdateReceptionistI.ToString());
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "LOCATIONHASOWNBRAND", A573LocationHasOwnBrand);
         GxWebStd.gx_boolean_hidden_field( context, "LOCATIONHASMYLIVING", A572LocationHasMyLiving);
         GxWebStd.gx_boolean_hidden_field( context, "LOCATIONHASMYSERVICES", A571LocationHasMyServices);
         GxWebStd.gx_boolean_hidden_field( context, "LOCATIONHASMYCARE", A570LocationHasMyCare);
         GxWebStd.gx_hidden_field( context, "vRECEPTIONDESCRIPTIONVAR", AV31ReceptionDescriptionVar);
         GxWebStd.gx_hidden_field( context, "RECEPTIONDESCRIPTION", A575ReceptionDescription);
         GxWebStd.gx_hidden_field( context, "vRECEPTIONIMAGEVAR", AV30ReceptionImageVar);
         GxWebStd.gx_hidden_field( context, "RECEPTIONIMAGE", A574ReceptionImage);
         GxWebStd.gx_hidden_field( context, "LOCATIONIMAGE_GXI", A40000LocationImage_GXI);
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTION", A36LocationDescription);
         GxWebStd.gx_hidden_field( context, "LOCATIONBRANDTHEME", A568LocationBrandTheme);
         GxWebStd.gx_hidden_field( context, "LOCATIONCTATHEME", A569LocationCtaTheme);
         GxWebStd.gx_hidden_field( context, "TOOLBOXDEFAULTPROFILEIMAGE", A504ToolBoxDefaultProfileImage);
         GxWebStd.gx_hidden_field( context, "TOOLBOXDEFAULTLOGO", A503ToolBoxDefaultLogo);
         GxWebStd.gx_hidden_field( context, "RECEPTIONIMAGE_GXI", A40001ReceptionImage_GXI);
         GxWebStd.gx_hidden_field( context, "TOOLBOXLASTUPDATETIME", context.localUtil.TToC( A631ToolBoxLastUpdateTime, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "TRN_THEMEID", A273Trn_ThemeId.ToString());
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV46Pgmname));
         GXCCtlgxBlob = "LOCATIONIMAGE" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A494LocationImage);
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONPHONECODE_Objectcall", StringUtil.RTrim( Combo_locationphonecode_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONPHONECODE_Cls", StringUtil.RTrim( Combo_locationphonecode_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONPHONECODE_Selectedvalue_set", StringUtil.RTrim( Combo_locationphonecode_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONPHONECODE_Enabled", StringUtil.BoolToStr( Combo_locationphonecode_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONPHONECODE_Emptyitem", StringUtil.BoolToStr( Combo_locationphonecode_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONPHONECODE_Htmltemplate", StringUtil.RTrim( Combo_locationphonecode_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "IMAGEUPLOADUC_Objectcall", StringUtil.RTrim( Imageuploaduc_Objectcall));
         GxWebStd.gx_hidden_field( context, "IMAGEUPLOADUC_Enabled", StringUtil.BoolToStr( Imageuploaduc_Enabled));
         GxWebStd.gx_hidden_field( context, "IMAGEUPLOADUC_Faileduploadmessage", StringUtil.RTrim( Imageuploaduc_Faileduploadmessage));
         GxWebStd.gx_hidden_field( context, "IMAGEUPLOADUC_Maxnumberoffiles", StringUtil.RTrim( Imageuploaduc_Maxnumberoffiles));
         GxWebStd.gx_hidden_field( context, "IMAGEUPLOADUC_Isreadonlymode", StringUtil.RTrim( Imageuploaduc_Isreadonlymode));
         GxWebStd.gx_hidden_field( context, "IMAGEUPLOADUC_Maxfilesize", StringUtil.RTrim( Imageuploaduc_Maxfilesize));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTION_Objectcall", StringUtil.RTrim( Locationdescription_Objectcall));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTION_Enabled", StringUtil.BoolToStr( Locationdescription_Enabled));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTION_Width", StringUtil.RTrim( Locationdescription_Width));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTION_Height", StringUtil.RTrim( Locationdescription_Height));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTION_Skin", StringUtil.RTrim( Locationdescription_Skin));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTION_Toolbar", StringUtil.RTrim( Locationdescription_Toolbar));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTION_Customtoolbar", StringUtil.RTrim( Locationdescription_Customtoolbar));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTION_Customconfiguration", StringUtil.RTrim( Locationdescription_Customconfiguration));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTION_Toolbarcancollapse", StringUtil.BoolToStr( Locationdescription_Toolbarcancollapse));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTION_Color", StringUtil.LTrim( StringUtil.NToC( (decimal)(Locationdescription_Color), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTION_Captionclass", StringUtil.RTrim( Locationdescription_Captionclass));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTION_Captionstyle", StringUtil.RTrim( Locationdescription_Captionstyle));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTION_Captionposition", StringUtil.RTrim( Locationdescription_Captionposition));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTION_Visible", StringUtil.BoolToStr( Locationdescription_Visible));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONCOUNTRY_Objectcall", StringUtil.RTrim( Combo_locationcountry_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONCOUNTRY_Cls", StringUtil.RTrim( Combo_locationcountry_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONCOUNTRY_Selectedvalue_set", StringUtil.RTrim( Combo_locationcountry_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONCOUNTRY_Enabled", StringUtil.BoolToStr( Combo_locationcountry_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONCOUNTRY_Emptyitem", StringUtil.BoolToStr( Combo_locationcountry_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONCOUNTRY_Htmltemplate", StringUtil.RTrim( Combo_locationcountry_Htmltemplate));
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
         return formatLink("trn_location.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(AV7LocationId.ToString()),UrlEncode(AV8OrganisationId.ToString())}, new string[] {"Gx_mode","LocationId","OrganisationId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_Location" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Location", "") ;
      }

      protected void InitializeNonKey046( )
      {
         A523AppVersionId = Guid.Empty;
         AssignAttri("", false, "A523AppVersionId", A523AppVersionId.ToString());
         A89ReceptionistId = Guid.Empty;
         AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
         A584ActiveAppVersionId = Guid.Empty;
         n584ActiveAppVersionId = false;
         AssignAttri("", false, "A584ActiveAppVersionId", A584ActiveAppVersionId.ToString());
         A598PublishedActiveAppVersionId = Guid.Empty;
         n598PublishedActiveAppVersionId = false;
         AssignAttri("", false, "A598PublishedActiveAppVersionId", A598PublishedActiveAppVersionId.ToString());
         A577LocationThemeId = Guid.Empty;
         n577LocationThemeId = false;
         AssignAttri("", false, "A577LocationThemeId", A577LocationThemeId.ToString());
         A630ToolBoxLastUpdateReceptionistI = Guid.Empty;
         n630ToolBoxLastUpdateReceptionistI = false;
         AssignAttri("", false, "A630ToolBoxLastUpdateReceptionistI", A630ToolBoxLastUpdateReceptionistI.ToString());
         A327LocationCountry = "";
         AssignAttri("", false, "A327LocationCountry", A327LocationCountry);
         A355LocationPhoneCode = "";
         AssignAttri("", false, "A355LocationPhoneCode", A355LocationPhoneCode);
         A35LocationPhone = "";
         AssignAttri("", false, "A35LocationPhone", A35LocationPhone);
         A329LocationZipCode = "";
         AssignAttri("", false, "A329LocationZipCode", A329LocationZipCode);
         A31LocationName = "";
         AssignAttri("", false, "A31LocationName", A31LocationName);
         A494LocationImage = "";
         n494LocationImage = false;
         AssignAttri("", false, "A494LocationImage", A494LocationImage);
         AssignProp("", false, imgLocationImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A494LocationImage)) ? A40000LocationImage_GXI : context.convertURL( context.PathToRelativeUrl( A494LocationImage))), true);
         AssignProp("", false, imgLocationImage_Internalname, "SrcSet", context.GetImageSrcSet( A494LocationImage), true);
         n494LocationImage = (String.IsNullOrEmpty(StringUtil.RTrim( A494LocationImage)) ? true : false);
         A40000LocationImage_GXI = "";
         n40000LocationImage_GXI = false;
         AssignProp("", false, imgLocationImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A494LocationImage)) ? A40000LocationImage_GXI : context.convertURL( context.PathToRelativeUrl( A494LocationImage))), true);
         AssignProp("", false, imgLocationImage_Internalname, "SrcSet", context.GetImageSrcSet( A494LocationImage), true);
         A328LocationCity = "";
         AssignAttri("", false, "A328LocationCity", A328LocationCity);
         A330LocationAddressLine1 = "";
         AssignAttri("", false, "A330LocationAddressLine1", A330LocationAddressLine1);
         A331LocationAddressLine2 = "";
         AssignAttri("", false, "A331LocationAddressLine2", A331LocationAddressLine2);
         A34LocationEmail = "";
         AssignAttri("", false, "A34LocationEmail", A34LocationEmail);
         A356LocationPhoneNumber = "";
         AssignAttri("", false, "A356LocationPhoneNumber", A356LocationPhoneNumber);
         A36LocationDescription = "";
         AssignAttri("", false, "A36LocationDescription", A36LocationDescription);
         A568LocationBrandTheme = "";
         n568LocationBrandTheme = false;
         AssignAttri("", false, "A568LocationBrandTheme", A568LocationBrandTheme);
         A569LocationCtaTheme = "";
         n569LocationCtaTheme = false;
         AssignAttri("", false, "A569LocationCtaTheme", A569LocationCtaTheme);
         A504ToolBoxDefaultProfileImage = "";
         n504ToolBoxDefaultProfileImage = false;
         AssignAttri("", false, "A504ToolBoxDefaultProfileImage", A504ToolBoxDefaultProfileImage);
         A503ToolBoxDefaultLogo = "";
         n503ToolBoxDefaultLogo = false;
         AssignAttri("", false, "A503ToolBoxDefaultLogo", A503ToolBoxDefaultLogo);
         A40001ReceptionImage_GXI = "";
         n40001ReceptionImage_GXI = false;
         AssignAttri("", false, "A40001ReceptionImage_GXI", A40001ReceptionImage_GXI);
         A273Trn_ThemeId = Guid.Empty;
         AssignAttri("", false, "A273Trn_ThemeId", A273Trn_ThemeId.ToString());
         A631ToolBoxLastUpdateTime = (DateTime)(DateTime.MinValue);
         n631ToolBoxLastUpdateTime = false;
         AssignAttri("", false, "A631ToolBoxLastUpdateTime", context.localUtil.TToC( A631ToolBoxLastUpdateTime, 0, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A570LocationHasMyCare = false;
         AssignAttri("", false, "A570LocationHasMyCare", A570LocationHasMyCare);
         A571LocationHasMyServices = false;
         AssignAttri("", false, "A571LocationHasMyServices", A571LocationHasMyServices);
         A572LocationHasMyLiving = false;
         AssignAttri("", false, "A572LocationHasMyLiving", A572LocationHasMyLiving);
         A573LocationHasOwnBrand = false;
         AssignAttri("", false, "A573LocationHasOwnBrand", A573LocationHasOwnBrand);
         A574ReceptionImage = AV30ReceptionImageVar;
         n574ReceptionImage = false;
         AssignAttri("", false, "A574ReceptionImage", A574ReceptionImage);
         A575ReceptionDescription = AV31ReceptionDescriptionVar;
         n575ReceptionDescription = false;
         AssignAttri("", false, "A575ReceptionDescription", A575ReceptionDescription);
         Z327LocationCountry = "";
         Z355LocationPhoneCode = "";
         Z35LocationPhone = "";
         Z329LocationZipCode = "";
         Z31LocationName = "";
         Z328LocationCity = "";
         Z330LocationAddressLine1 = "";
         Z331LocationAddressLine2 = "";
         Z34LocationEmail = "";
         Z356LocationPhoneNumber = "";
         Z570LocationHasMyCare = false;
         Z571LocationHasMyServices = false;
         Z572LocationHasMyLiving = false;
         Z573LocationHasOwnBrand = false;
         Z504ToolBoxDefaultProfileImage = "";
         Z503ToolBoxDefaultLogo = "";
         Z575ReceptionDescription = "";
         Z631ToolBoxLastUpdateTime = (DateTime)(DateTime.MinValue);
         Z630ToolBoxLastUpdateReceptionistI = Guid.Empty;
         Z577LocationThemeId = Guid.Empty;
         Z584ActiveAppVersionId = Guid.Empty;
         Z598PublishedActiveAppVersionId = Guid.Empty;
      }

      protected void InitAll046( )
      {
         A29LocationId = Guid.Empty;
         n29LocationId = false;
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         A11OrganisationId = Guid.Empty;
         n11OrganisationId = false;
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         InitializeNonKey046( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A573LocationHasOwnBrand = i573LocationHasOwnBrand;
         AssignAttri("", false, "A573LocationHasOwnBrand", A573LocationHasOwnBrand);
         A572LocationHasMyLiving = i572LocationHasMyLiving;
         AssignAttri("", false, "A572LocationHasMyLiving", A572LocationHasMyLiving);
         A571LocationHasMyServices = i571LocationHasMyServices;
         AssignAttri("", false, "A571LocationHasMyServices", A571LocationHasMyServices);
         A570LocationHasMyCare = i570LocationHasMyCare;
         AssignAttri("", false, "A570LocationHasMyCare", A570LocationHasMyCare);
         A575ReceptionDescription = i575ReceptionDescription;
         n575ReceptionDescription = false;
         AssignAttri("", false, "A575ReceptionDescription", A575ReceptionDescription);
         A574ReceptionImage = i574ReceptionImage;
         n574ReceptionImage = false;
         AssignAttri("", false, "A574ReceptionImage", A574ReceptionImage);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025721816302", true, true);
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
         context.AddJavascriptSource("trn_location.js", "?2025721816307", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UC_CustomImageUploadRender.js", "", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtLocationName_Internalname = "LOCATIONNAME";
         edtLocationEmail_Internalname = "LOCATIONEMAIL";
         lblPhone_Internalname = "PHONE";
         Combo_locationphonecode_Internalname = "COMBO_LOCATIONPHONECODE";
         edtLocationPhoneCode_Internalname = "LOCATIONPHONECODE";
         divUnnamedtablelocationphonecode_Internalname = "UNNAMEDTABLELOCATIONPHONECODE";
         divUnnamedtable10_Internalname = "UNNAMEDTABLE10";
         edtLocationPhoneNumber_Internalname = "LOCATIONPHONENUMBER";
         divUnnamedtable9_Internalname = "UNNAMEDTABLE9";
         divUnnamedtable5_Internalname = "UNNAMEDTABLE5";
         edtLocationPhone_Internalname = "LOCATIONPHONE";
         divLocationphone_cell_Internalname = "LOCATIONPHONE_CELL";
         lblProductserviceimagetext_Internalname = "PRODUCTSERVICEIMAGETEXT";
         Imageuploaduc_Internalname = "IMAGEUPLOADUC";
         divUcfilecell_Internalname = "UCFILECELL";
         divUnnamedtable6_Internalname = "UNNAMEDTABLE6";
         Locationdescription_Internalname = "LOCATIONDESCRIPTION";
         divDecriptioneditortext_Internalname = "DECRIPTIONEDITORTEXT";
         lblTextblockdescriptionlabel_Internalname = "TEXTBLOCKDESCRIPTIONLABEL";
         lblDescriptiontext_Internalname = "DESCRIPTIONTEXT";
         divUnnamedtable8_Internalname = "UNNAMEDTABLE8";
         divUnnamedtable7_Internalname = "UNNAMEDTABLE7";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         grpUnnamedgroup2_Internalname = "UNNAMEDGROUP2";
         edtLocationAddressLine1_Internalname = "LOCATIONADDRESSLINE1";
         edtLocationAddressLine2_Internalname = "LOCATIONADDRESSLINE2";
         edtLocationZipCode_Internalname = "LOCATIONZIPCODE";
         edtLocationCity_Internalname = "LOCATIONCITY";
         lblTextblocklocationcountry_Internalname = "TEXTBLOCKLOCATIONCOUNTRY";
         Combo_locationcountry_Internalname = "COMBO_LOCATIONCOUNTRY";
         edtLocationCountry_Internalname = "LOCATIONCOUNTRY";
         divTablesplittedlocationcountry_Internalname = "TABLESPLITTEDLOCATIONCOUNTRY";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         grpUnnamedgroup4_Internalname = "UNNAMEDGROUP4";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         bttBtnudelete_Internalname = "BTNUDELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombolocationphonecode_Internalname = "vCOMBOLOCATIONPHONECODE";
         divSectionattribute_locationphonecode_Internalname = "SECTIONATTRIBUTE_LOCATIONPHONECODE";
         edtavCombolocationcountry_Internalname = "vCOMBOLOCATIONCOUNTRY";
         divSectionattribute_locationcountry_Internalname = "SECTIONATTRIBUTE_LOCATIONCOUNTRY";
         edtLocationId_Internalname = "LOCATIONID";
         edtOrganisationId_Internalname = "ORGANISATIONID";
         imgLocationImage_Internalname = "LOCATIONIMAGE";
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
         Form.Caption = context.GetMessage( "Location", "");
         Locationdescription_Visible = Convert.ToBoolean( -1);
         Combo_locationphonecode_Htmltemplate = "";
         Combo_locationcountry_Htmltemplate = "";
         imgLocationImage_Enabled = 1;
         imgLocationImage_Visible = 1;
         edtOrganisationId_Jsonclick = "";
         edtOrganisationId_Enabled = 1;
         edtOrganisationId_Visible = 1;
         edtLocationId_Jsonclick = "";
         edtLocationId_Enabled = 1;
         edtLocationId_Visible = 1;
         edtavCombolocationcountry_Jsonclick = "";
         edtavCombolocationcountry_Enabled = 0;
         edtavCombolocationcountry_Visible = 1;
         edtavCombolocationphonecode_Jsonclick = "";
         edtavCombolocationphonecode_Enabled = 0;
         edtavCombolocationphonecode_Visible = 1;
         bttBtnudelete_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtLocationCountry_Jsonclick = "";
         edtLocationCountry_Enabled = 1;
         edtLocationCountry_Visible = 1;
         Combo_locationcountry_Emptyitem = Convert.ToBoolean( 0);
         Combo_locationcountry_Cls = "ExtendedCombo Attribute ExtendedComboWithImage";
         Combo_locationcountry_Caption = "";
         Combo_locationcountry_Enabled = Convert.ToBoolean( -1);
         edtLocationCity_Jsonclick = "";
         edtLocationCity_Enabled = 1;
         edtLocationZipCode_Jsonclick = "";
         edtLocationZipCode_Enabled = 1;
         edtLocationAddressLine2_Jsonclick = "";
         edtLocationAddressLine2_Enabled = 1;
         edtLocationAddressLine1_Jsonclick = "";
         edtLocationAddressLine1_Enabled = 1;
         divUnnamedtable7_Visible = 1;
         Locationdescription_Captionposition = "Left";
         Locationdescription_Captionstyle = "";
         Locationdescription_Captionclass = "col-sm-4 AttributeLabel";
         Locationdescription_Color = (int)(0xD3D3D3);
         Locationdescription_Toolbarcancollapse = Convert.ToBoolean( 0);
         Locationdescription_Customconfiguration = "myconfig.js";
         Locationdescription_Customtoolbar = "myToolbar";
         Locationdescription_Toolbar = "Custom";
         Locationdescription_Skin = "default";
         Locationdescription_Height = "250";
         Locationdescription_Width = "100%";
         Locationdescription_Enabled = Convert.ToBoolean( 1);
         divDecriptioneditortext_Class = "col-xs-12 DataContentCell CKEditor";
         Imageuploaduc_Maxfilesize = "10";
         Imageuploaduc_Isreadonlymode = "false";
         Imageuploaduc_Maxnumberoffiles = "5";
         Imageuploaduc_Faileduploadmessage = "Upload Failed";
         edtLocationPhone_Jsonclick = "";
         edtLocationPhone_Enabled = 1;
         edtLocationPhone_Visible = 1;
         divLocationphone_cell_Class = "col-xs-12";
         edtLocationPhoneNumber_Jsonclick = "";
         edtLocationPhoneNumber_Enabled = 1;
         edtLocationPhoneCode_Jsonclick = "";
         edtLocationPhoneCode_Enabled = 1;
         edtLocationPhoneCode_Visible = 1;
         Combo_locationphonecode_Emptyitem = Convert.ToBoolean( 0);
         Combo_locationphonecode_Cls = "ExtendedCombo Attribute ExtendedComboWithImage";
         Combo_locationphonecode_Caption = "";
         Combo_locationphonecode_Enabled = Convert.ToBoolean( -1);
         divUnnamedtable5_Visible = 1;
         edtLocationEmail_Jsonclick = "";
         edtLocationEmail_Enabled = 1;
         edtLocationName_Jsonclick = "";
         edtLocationName_Enabled = 1;
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

      protected void GX23ASALOCATIONPHONE046( string A355LocationPhoneCode ,
                                              string A356LocationPhoneNumber )
      {
         GXt_char2 = A35LocationPhone;
         new prc_concatenateintlphone(context ).execute(  A355LocationPhoneCode,  A356LocationPhoneNumber, out  GXt_char2) ;
         A35LocationPhone = GXt_char2;
         AssignAttri("", false, "A35LocationPhone", A35LocationPhone);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A35LocationPhone))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_39_046( Guid A29LocationId )
      {
         new trn_deletelocationpages(context ).execute(  A29LocationId) ;
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

      public void Valid_Locationphonenumber( )
      {
         GXt_char2 = A35LocationPhone;
         new prc_concatenateintlphone(context ).execute(  A355LocationPhoneCode,  A356LocationPhoneNumber, out  GXt_char2) ;
         A35LocationPhone = GXt_char2;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A356LocationPhoneNumber)) && ! GxRegex.IsMatch(A356LocationPhoneNumber,context.GetMessage( "^\\d{9}$", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Phone contains 9 digits", ""), 1, "LOCATIONPHONENUMBER");
            AnyError = 1;
            GX_FocusControl = edtLocationPhoneNumber_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A35LocationPhone", StringUtil.RTrim( A35LocationPhone));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV8OrganisationId","fld":"vORGANISATIONID","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV12TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV8OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"A570LocationHasMyCare","fld":"LOCATIONHASMYCARE"},{"av":"A571LocationHasMyServices","fld":"LOCATIONHASMYSERVICES"},{"av":"A572LocationHasMyLiving","fld":"LOCATIONHASMYLIVING"},{"av":"A573LocationHasOwnBrand","fld":"LOCATIONHASOWNBRAND"},{"av":"A504ToolBoxDefaultProfileImage","fld":"TOOLBOXDEFAULTPROFILEIMAGE"},{"av":"A503ToolBoxDefaultLogo","fld":"TOOLBOXDEFAULTLOGO"},{"av":"A575ReceptionDescription","fld":"RECEPTIONDESCRIPTION"},{"av":"A631ToolBoxLastUpdateTime","fld":"TOOLBOXLASTUPDATETIME","pic":"99:99"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E13042","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV42UploadedFiles","fld":"vUPLOADEDFILES"},{"av":"AV41FilesToUpdate","fld":"vFILESTOUPDATE"},{"av":"AV12TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("'DOUDELETE'","""{"handler":"E14042","iparms":[{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV28isSuccessful","fld":"vISSUCCESSFUL"},{"av":"AV29Message","fld":"vMESSAGE"}]""");
         setEventMetadata("'DOUDELETE'",""","oparms":[{"av":"AV29Message","fld":"vMESSAGE"},{"av":"AV28isSuccessful","fld":"vISSUCCESSFUL"}]}""");
         setEventMetadata("IMAGEUPLOADUC.ONFAILEDUPLOAD","""{"handler":"E12042","iparms":[{"av":"Imageuploaduc_Faileduploadmessage","ctrl":"IMAGEUPLOADUC","prop":"FailedUploadMessage"}]}""");
         setEventMetadata("VALID_LOCATIONEMAIL","""{"handler":"Valid_Locationemail","iparms":[]}""");
         setEventMetadata("VALID_LOCATIONPHONECODE","""{"handler":"Valid_Locationphonecode","iparms":[]}""");
         setEventMetadata("VALID_LOCATIONPHONENUMBER","""{"handler":"Valid_Locationphonenumber","iparms":[{"av":"A355LocationPhoneCode","fld":"LOCATIONPHONECODE"},{"av":"A356LocationPhoneNumber","fld":"LOCATIONPHONENUMBER"},{"av":"A35LocationPhone","fld":"LOCATIONPHONE"}]""");
         setEventMetadata("VALID_LOCATIONPHONENUMBER",""","oparms":[{"av":"A35LocationPhone","fld":"LOCATIONPHONE"}]}""");
         setEventMetadata("VALID_LOCATIONZIPCODE","""{"handler":"Valid_Locationzipcode","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOLOCATIONPHONECODE","""{"handler":"Validv_Combolocationphonecode","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOLOCATIONCOUNTRY","""{"handler":"Validv_Combolocationcountry","iparms":[]}""");
         setEventMetadata("VALID_LOCATIONID","""{"handler":"Valid_Locationid","iparms":[]}""");
         setEventMetadata("VALID_ORGANISATIONID","""{"handler":"Valid_Organisationid","iparms":[]}""");
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
         pr_default.close(20);
         pr_default.close(19);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7LocationId = Guid.Empty;
         wcpOAV8OrganisationId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         Z327LocationCountry = "";
         Z355LocationPhoneCode = "";
         Z35LocationPhone = "";
         Z329LocationZipCode = "";
         Z31LocationName = "";
         Z328LocationCity = "";
         Z330LocationAddressLine1 = "";
         Z331LocationAddressLine2 = "";
         Z34LocationEmail = "";
         Z356LocationPhoneNumber = "";
         Z504ToolBoxDefaultProfileImage = "";
         Z503ToolBoxDefaultLogo = "";
         Z575ReceptionDescription = "";
         Z631ToolBoxLastUpdateTime = (DateTime)(DateTime.MinValue);
         Z630ToolBoxLastUpdateReceptionistI = Guid.Empty;
         Z577LocationThemeId = Guid.Empty;
         Z584ActiveAppVersionId = Guid.Empty;
         Z598PublishedActiveAppVersionId = Guid.Empty;
         N584ActiveAppVersionId = Guid.Empty;
         N598PublishedActiveAppVersionId = Guid.Empty;
         N577LocationThemeId = Guid.Empty;
         N630ToolBoxLastUpdateReceptionistI = Guid.Empty;
         Combo_locationcountry_Selectedvalue_get = "";
         Combo_locationphonecode_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A29LocationId = Guid.Empty;
         A355LocationPhoneCode = "";
         A356LocationPhoneNumber = "";
         A630ToolBoxLastUpdateReceptionistI = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A577LocationThemeId = Guid.Empty;
         A584ActiveAppVersionId = Guid.Empty;
         A598PublishedActiveAppVersionId = Guid.Empty;
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A31LocationName = "";
         A34LocationEmail = "";
         lblPhone_Jsonclick = "";
         ucCombo_locationphonecode = new GXUserControl();
         AV19DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV21LocationPhoneCode_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         gxphoneLink = "";
         A35LocationPhone = "";
         lblProductserviceimagetext_Jsonclick = "";
         ucImageuploaduc = new GXUserControl();
         AV42UploadedFiles = new GXBaseCollection<SdtSDT_FileUploadData>( context, "SDT_FileUploadData", "Comforta_version2");
         AV41FilesToUpdate = new GXBaseCollection<SdtSDT_FileUploadData>( context, "SDT_FileUploadData", "Comforta_version2");
         ucLocationdescription = new GXUserControl();
         LocationDescription = "";
         lblTextblockdescriptionlabel_Jsonclick = "";
         lblDescriptiontext_Jsonclick = "";
         A330LocationAddressLine1 = "";
         A331LocationAddressLine2 = "";
         A329LocationZipCode = "";
         A328LocationCity = "";
         lblTextblocklocationcountry_Jsonclick = "";
         ucCombo_locationcountry = new GXUserControl();
         AV22LocationCountry_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A327LocationCountry = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         bttBtnudelete_Jsonclick = "";
         AV16ComboLocationPhoneCode = "";
         AV23ComboLocationCountry = "";
         A494LocationImage = "";
         A40000LocationImage_GXI = "";
         sImgUrl = "";
         A504ToolBoxDefaultProfileImage = "";
         A503ToolBoxDefaultLogo = "";
         A575ReceptionDescription = "";
         A631ToolBoxLastUpdateTime = (DateTime)(DateTime.MinValue);
         AV34Insert_ActiveAppVersionId = Guid.Empty;
         AV40Insert_PublishedActiveAppVersionId = Guid.Empty;
         AV32Insert_LocationThemeId = Guid.Empty;
         AV43Insert_ToolBoxLastUpdateReceptionistId = Guid.Empty;
         AV31ReceptionDescriptionVar = "";
         AV30ReceptionImageVar = "";
         A574ReceptionImage = "";
         A36LocationDescription = "";
         A568LocationBrandTheme = "";
         A569LocationCtaTheme = "";
         A40001ReceptionImage_GXI = "";
         A273Trn_ThemeId = Guid.Empty;
         AV46Pgmname = "";
         Combo_locationphonecode_Objectcall = "";
         Combo_locationphonecode_Class = "";
         Combo_locationphonecode_Icontype = "";
         Combo_locationphonecode_Icon = "";
         Combo_locationphonecode_Tooltip = "";
         Combo_locationphonecode_Selectedvalue_set = "";
         Combo_locationphonecode_Selectedtext_set = "";
         Combo_locationphonecode_Selectedtext_get = "";
         Combo_locationphonecode_Gamoauthtoken = "";
         Combo_locationphonecode_Ddointernalname = "";
         Combo_locationphonecode_Titlecontrolalign = "";
         Combo_locationphonecode_Dropdownoptionstype = "";
         Combo_locationphonecode_Titlecontrolidtoreplace = "";
         Combo_locationphonecode_Datalisttype = "";
         Combo_locationphonecode_Datalistfixedvalues = "";
         Combo_locationphonecode_Datalistproc = "";
         Combo_locationphonecode_Datalistprocparametersprefix = "";
         Combo_locationphonecode_Remoteservicesparameters = "";
         Combo_locationphonecode_Multiplevaluestype = "";
         Combo_locationphonecode_Loadingdata = "";
         Combo_locationphonecode_Noresultsfound = "";
         Combo_locationphonecode_Emptyitemtext = "";
         Combo_locationphonecode_Onlyselectedvalues = "";
         Combo_locationphonecode_Selectalltext = "";
         Combo_locationphonecode_Multiplevaluesseparator = "";
         Combo_locationphonecode_Addnewoptiontext = "";
         Imageuploaduc_Objectcall = "";
         Imageuploaduc_Class = "";
         Locationdescription_Objectcall = "";
         Locationdescription_Class = "";
         Locationdescription_Buttonpressedid = "";
         Locationdescription_Captionvalue = "";
         Locationdescription_Coltitle = "";
         Locationdescription_Coltitlefont = "";
         Combo_locationcountry_Objectcall = "";
         Combo_locationcountry_Class = "";
         Combo_locationcountry_Icontype = "";
         Combo_locationcountry_Icon = "";
         Combo_locationcountry_Tooltip = "";
         Combo_locationcountry_Selectedvalue_set = "";
         Combo_locationcountry_Selectedtext_set = "";
         Combo_locationcountry_Selectedtext_get = "";
         Combo_locationcountry_Gamoauthtoken = "";
         Combo_locationcountry_Ddointernalname = "";
         Combo_locationcountry_Titlecontrolalign = "";
         Combo_locationcountry_Dropdownoptionstype = "";
         Combo_locationcountry_Titlecontrolidtoreplace = "";
         Combo_locationcountry_Datalisttype = "";
         Combo_locationcountry_Datalistfixedvalues = "";
         Combo_locationcountry_Datalistproc = "";
         Combo_locationcountry_Datalistprocparametersprefix = "";
         Combo_locationcountry_Remoteservicesparameters = "";
         Combo_locationcountry_Multiplevaluestype = "";
         Combo_locationcountry_Loadingdata = "";
         Combo_locationcountry_Noresultsfound = "";
         Combo_locationcountry_Emptyitemtext = "";
         Combo_locationcountry_Onlyselectedvalues = "";
         Combo_locationcountry_Selectalltext = "";
         Combo_locationcountry_Multiplevaluesseparator = "";
         Combo_locationcountry_Addnewoptiontext = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode6 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         imgReceptionimagevar_gximage = "";
         imgReceptionimagevar_Internalname = "";
         AV45Receptionimagevar_GXI = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV12TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV13WebSession = context.GetSession();
         AV26TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         GXt_objcol_SdtSDT_FileUploadData3 = new GXBaseCollection<SdtSDT_FileUploadData>( context, "SDT_FileUploadData", "Comforta_version2");
         AV29Message = "";
         AV18ComboSelectedValue = "";
         AV17ComboSelectedText = "";
         GXt_objcol_SdtDVB_SDTComboData_Item4 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         Z494LocationImage = "";
         Z40000LocationImage_GXI = "";
         Z36LocationDescription = "";
         Z568LocationBrandTheme = "";
         Z569LocationCtaTheme = "";
         Z574ReceptionImage = "";
         Z40001ReceptionImage_GXI = "";
         T00048_A327LocationCountry = new string[] {""} ;
         T00048_A355LocationPhoneCode = new string[] {""} ;
         T00048_A35LocationPhone = new string[] {""} ;
         T00048_A329LocationZipCode = new string[] {""} ;
         T00048_A31LocationName = new string[] {""} ;
         T00048_A40000LocationImage_GXI = new string[] {""} ;
         T00048_n40000LocationImage_GXI = new bool[] {false} ;
         T00048_A328LocationCity = new string[] {""} ;
         T00048_A330LocationAddressLine1 = new string[] {""} ;
         T00048_A331LocationAddressLine2 = new string[] {""} ;
         T00048_A34LocationEmail = new string[] {""} ;
         T00048_A356LocationPhoneNumber = new string[] {""} ;
         T00048_A36LocationDescription = new string[] {""} ;
         T00048_A568LocationBrandTheme = new string[] {""} ;
         T00048_n568LocationBrandTheme = new bool[] {false} ;
         T00048_A569LocationCtaTheme = new string[] {""} ;
         T00048_n569LocationCtaTheme = new bool[] {false} ;
         T00048_A570LocationHasMyCare = new bool[] {false} ;
         T00048_A571LocationHasMyServices = new bool[] {false} ;
         T00048_A572LocationHasMyLiving = new bool[] {false} ;
         T00048_A573LocationHasOwnBrand = new bool[] {false} ;
         T00048_A504ToolBoxDefaultProfileImage = new string[] {""} ;
         T00048_n504ToolBoxDefaultProfileImage = new bool[] {false} ;
         T00048_A503ToolBoxDefaultLogo = new string[] {""} ;
         T00048_n503ToolBoxDefaultLogo = new bool[] {false} ;
         T00048_A40001ReceptionImage_GXI = new string[] {""} ;
         T00048_n40001ReceptionImage_GXI = new bool[] {false} ;
         T00048_A575ReceptionDescription = new string[] {""} ;
         T00048_n575ReceptionDescription = new bool[] {false} ;
         T00048_A631ToolBoxLastUpdateTime = new DateTime[] {DateTime.MinValue} ;
         T00048_n631ToolBoxLastUpdateTime = new bool[] {false} ;
         T00048_A630ToolBoxLastUpdateReceptionistI = new Guid[] {Guid.Empty} ;
         T00048_n630ToolBoxLastUpdateReceptionistI = new bool[] {false} ;
         T00048_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00048_n11OrganisationId = new bool[] {false} ;
         T00048_A29LocationId = new Guid[] {Guid.Empty} ;
         T00048_n29LocationId = new bool[] {false} ;
         T00048_A577LocationThemeId = new Guid[] {Guid.Empty} ;
         T00048_n577LocationThemeId = new bool[] {false} ;
         T00048_A584ActiveAppVersionId = new Guid[] {Guid.Empty} ;
         T00048_n584ActiveAppVersionId = new bool[] {false} ;
         T00048_A598PublishedActiveAppVersionId = new Guid[] {Guid.Empty} ;
         T00048_n598PublishedActiveAppVersionId = new bool[] {false} ;
         T00048_A494LocationImage = new string[] {""} ;
         T00048_n494LocationImage = new bool[] {false} ;
         T00048_A574ReceptionImage = new string[] {""} ;
         T00048_n574ReceptionImage = new bool[] {false} ;
         T00046_A523AppVersionId = new Guid[] {Guid.Empty} ;
         T00046_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T00047_A523AppVersionId = new Guid[] {Guid.Empty} ;
         T00047_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T00044_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         T00045_A577LocationThemeId = new Guid[] {Guid.Empty} ;
         T00045_n577LocationThemeId = new bool[] {false} ;
         T00049_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         T000410_A577LocationThemeId = new Guid[] {Guid.Empty} ;
         T000410_n577LocationThemeId = new bool[] {false} ;
         T000411_A523AppVersionId = new Guid[] {Guid.Empty} ;
         T000411_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000412_A523AppVersionId = new Guid[] {Guid.Empty} ;
         T000412_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000413_A29LocationId = new Guid[] {Guid.Empty} ;
         T000413_n29LocationId = new bool[] {false} ;
         T000413_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000413_n11OrganisationId = new bool[] {false} ;
         T00043_A327LocationCountry = new string[] {""} ;
         T00043_A355LocationPhoneCode = new string[] {""} ;
         T00043_A35LocationPhone = new string[] {""} ;
         T00043_A329LocationZipCode = new string[] {""} ;
         T00043_A31LocationName = new string[] {""} ;
         T00043_A40000LocationImage_GXI = new string[] {""} ;
         T00043_n40000LocationImage_GXI = new bool[] {false} ;
         T00043_A328LocationCity = new string[] {""} ;
         T00043_A330LocationAddressLine1 = new string[] {""} ;
         T00043_A331LocationAddressLine2 = new string[] {""} ;
         T00043_A34LocationEmail = new string[] {""} ;
         T00043_A356LocationPhoneNumber = new string[] {""} ;
         T00043_A36LocationDescription = new string[] {""} ;
         T00043_A568LocationBrandTheme = new string[] {""} ;
         T00043_n568LocationBrandTheme = new bool[] {false} ;
         T00043_A569LocationCtaTheme = new string[] {""} ;
         T00043_n569LocationCtaTheme = new bool[] {false} ;
         T00043_A570LocationHasMyCare = new bool[] {false} ;
         T00043_A571LocationHasMyServices = new bool[] {false} ;
         T00043_A572LocationHasMyLiving = new bool[] {false} ;
         T00043_A573LocationHasOwnBrand = new bool[] {false} ;
         T00043_A504ToolBoxDefaultProfileImage = new string[] {""} ;
         T00043_n504ToolBoxDefaultProfileImage = new bool[] {false} ;
         T00043_A503ToolBoxDefaultLogo = new string[] {""} ;
         T00043_n503ToolBoxDefaultLogo = new bool[] {false} ;
         T00043_A40001ReceptionImage_GXI = new string[] {""} ;
         T00043_n40001ReceptionImage_GXI = new bool[] {false} ;
         T00043_A575ReceptionDescription = new string[] {""} ;
         T00043_n575ReceptionDescription = new bool[] {false} ;
         T00043_A631ToolBoxLastUpdateTime = new DateTime[] {DateTime.MinValue} ;
         T00043_n631ToolBoxLastUpdateTime = new bool[] {false} ;
         T00043_A630ToolBoxLastUpdateReceptionistI = new Guid[] {Guid.Empty} ;
         T00043_n630ToolBoxLastUpdateReceptionistI = new bool[] {false} ;
         T00043_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00043_n11OrganisationId = new bool[] {false} ;
         T00043_A29LocationId = new Guid[] {Guid.Empty} ;
         T00043_n29LocationId = new bool[] {false} ;
         T00043_A577LocationThemeId = new Guid[] {Guid.Empty} ;
         T00043_n577LocationThemeId = new bool[] {false} ;
         T00043_A584ActiveAppVersionId = new Guid[] {Guid.Empty} ;
         T00043_n584ActiveAppVersionId = new bool[] {false} ;
         T00043_A598PublishedActiveAppVersionId = new Guid[] {Guid.Empty} ;
         T00043_n598PublishedActiveAppVersionId = new bool[] {false} ;
         T00043_A494LocationImage = new string[] {""} ;
         T00043_n494LocationImage = new bool[] {false} ;
         T00043_A574ReceptionImage = new string[] {""} ;
         T00043_n574ReceptionImage = new bool[] {false} ;
         T000414_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000414_n11OrganisationId = new bool[] {false} ;
         T000414_A29LocationId = new Guid[] {Guid.Empty} ;
         T000414_n29LocationId = new bool[] {false} ;
         T000415_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000415_n11OrganisationId = new bool[] {false} ;
         T000415_A29LocationId = new Guid[] {Guid.Empty} ;
         T000415_n29LocationId = new bool[] {false} ;
         T00042_A327LocationCountry = new string[] {""} ;
         T00042_A355LocationPhoneCode = new string[] {""} ;
         T00042_A35LocationPhone = new string[] {""} ;
         T00042_A329LocationZipCode = new string[] {""} ;
         T00042_A31LocationName = new string[] {""} ;
         T00042_A40000LocationImage_GXI = new string[] {""} ;
         T00042_n40000LocationImage_GXI = new bool[] {false} ;
         T00042_A328LocationCity = new string[] {""} ;
         T00042_A330LocationAddressLine1 = new string[] {""} ;
         T00042_A331LocationAddressLine2 = new string[] {""} ;
         T00042_A34LocationEmail = new string[] {""} ;
         T00042_A356LocationPhoneNumber = new string[] {""} ;
         T00042_A36LocationDescription = new string[] {""} ;
         T00042_A568LocationBrandTheme = new string[] {""} ;
         T00042_n568LocationBrandTheme = new bool[] {false} ;
         T00042_A569LocationCtaTheme = new string[] {""} ;
         T00042_n569LocationCtaTheme = new bool[] {false} ;
         T00042_A570LocationHasMyCare = new bool[] {false} ;
         T00042_A571LocationHasMyServices = new bool[] {false} ;
         T00042_A572LocationHasMyLiving = new bool[] {false} ;
         T00042_A573LocationHasOwnBrand = new bool[] {false} ;
         T00042_A504ToolBoxDefaultProfileImage = new string[] {""} ;
         T00042_n504ToolBoxDefaultProfileImage = new bool[] {false} ;
         T00042_A503ToolBoxDefaultLogo = new string[] {""} ;
         T00042_n503ToolBoxDefaultLogo = new bool[] {false} ;
         T00042_A40001ReceptionImage_GXI = new string[] {""} ;
         T00042_n40001ReceptionImage_GXI = new bool[] {false} ;
         T00042_A575ReceptionDescription = new string[] {""} ;
         T00042_n575ReceptionDescription = new bool[] {false} ;
         T00042_A631ToolBoxLastUpdateTime = new DateTime[] {DateTime.MinValue} ;
         T00042_n631ToolBoxLastUpdateTime = new bool[] {false} ;
         T00042_A630ToolBoxLastUpdateReceptionistI = new Guid[] {Guid.Empty} ;
         T00042_n630ToolBoxLastUpdateReceptionistI = new bool[] {false} ;
         T00042_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00042_n11OrganisationId = new bool[] {false} ;
         T00042_A29LocationId = new Guid[] {Guid.Empty} ;
         T00042_n29LocationId = new bool[] {false} ;
         T00042_A577LocationThemeId = new Guid[] {Guid.Empty} ;
         T00042_n577LocationThemeId = new bool[] {false} ;
         T00042_A584ActiveAppVersionId = new Guid[] {Guid.Empty} ;
         T00042_n584ActiveAppVersionId = new bool[] {false} ;
         T00042_A598PublishedActiveAppVersionId = new Guid[] {Guid.Empty} ;
         T00042_n598PublishedActiveAppVersionId = new bool[] {false} ;
         T00042_A494LocationImage = new string[] {""} ;
         T00042_n494LocationImage = new bool[] {false} ;
         T00042_A574ReceptionImage = new string[] {""} ;
         T00042_n574ReceptionImage = new bool[] {false} ;
         T000421_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000422_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000423_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T000424_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         T000425_A523AppVersionId = new Guid[] {Guid.Empty} ;
         T000426_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         T000427_A366LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         T000427_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000427_n11OrganisationId = new bool[] {false} ;
         T000427_A29LocationId = new Guid[] {Guid.Empty} ;
         T000427_n29LocationId = new bool[] {false} ;
         T000428_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T000428_A29LocationId = new Guid[] {Guid.Empty} ;
         T000428_n29LocationId = new bool[] {false} ;
         T000428_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000428_n11OrganisationId = new bool[] {false} ;
         T000429_A62ResidentId = new Guid[] {Guid.Empty} ;
         T000429_A29LocationId = new Guid[] {Guid.Empty} ;
         T000429_n29LocationId = new bool[] {false} ;
         T000429_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000429_n11OrganisationId = new bool[] {false} ;
         T000430_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         T000430_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000430_n11OrganisationId = new bool[] {false} ;
         T000430_A29LocationId = new Guid[] {Guid.Empty} ;
         T000430_n29LocationId = new bool[] {false} ;
         T000431_A29LocationId = new Guid[] {Guid.Empty} ;
         T000431_n29LocationId = new bool[] {false} ;
         T000431_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000431_n11OrganisationId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         A523AppVersionId = Guid.Empty;
         A89ReceptionistId = Guid.Empty;
         i575ReceptionDescription = "";
         i574ReceptionImage = "";
         GXt_char2 = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_location__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_location__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_location__default(),
            new Object[][] {
                new Object[] {
               T00042_A327LocationCountry, T00042_A355LocationPhoneCode, T00042_A35LocationPhone, T00042_A329LocationZipCode, T00042_A31LocationName, T00042_A40000LocationImage_GXI, T00042_n40000LocationImage_GXI, T00042_A328LocationCity, T00042_A330LocationAddressLine1, T00042_A331LocationAddressLine2,
               T00042_A34LocationEmail, T00042_A356LocationPhoneNumber, T00042_A36LocationDescription, T00042_A568LocationBrandTheme, T00042_n568LocationBrandTheme, T00042_A569LocationCtaTheme, T00042_n569LocationCtaTheme, T00042_A570LocationHasMyCare, T00042_A571LocationHasMyServices, T00042_A572LocationHasMyLiving,
               T00042_A573LocationHasOwnBrand, T00042_A504ToolBoxDefaultProfileImage, T00042_n504ToolBoxDefaultProfileImage, T00042_A503ToolBoxDefaultLogo, T00042_n503ToolBoxDefaultLogo, T00042_A40001ReceptionImage_GXI, T00042_n40001ReceptionImage_GXI, T00042_A575ReceptionDescription, T00042_n575ReceptionDescription, T00042_A631ToolBoxLastUpdateTime,
               T00042_n631ToolBoxLastUpdateTime, T00042_A630ToolBoxLastUpdateReceptionistI, T00042_n630ToolBoxLastUpdateReceptionistI, T00042_A11OrganisationId, T00042_A29LocationId, T00042_A577LocationThemeId, T00042_n577LocationThemeId, T00042_A584ActiveAppVersionId, T00042_n584ActiveAppVersionId, T00042_A598PublishedActiveAppVersionId,
               T00042_n598PublishedActiveAppVersionId, T00042_A494LocationImage, T00042_n494LocationImage, T00042_A574ReceptionImage, T00042_n574ReceptionImage
               }
               , new Object[] {
               T00043_A327LocationCountry, T00043_A355LocationPhoneCode, T00043_A35LocationPhone, T00043_A329LocationZipCode, T00043_A31LocationName, T00043_A40000LocationImage_GXI, T00043_n40000LocationImage_GXI, T00043_A328LocationCity, T00043_A330LocationAddressLine1, T00043_A331LocationAddressLine2,
               T00043_A34LocationEmail, T00043_A356LocationPhoneNumber, T00043_A36LocationDescription, T00043_A568LocationBrandTheme, T00043_n568LocationBrandTheme, T00043_A569LocationCtaTheme, T00043_n569LocationCtaTheme, T00043_A570LocationHasMyCare, T00043_A571LocationHasMyServices, T00043_A572LocationHasMyLiving,
               T00043_A573LocationHasOwnBrand, T00043_A504ToolBoxDefaultProfileImage, T00043_n504ToolBoxDefaultProfileImage, T00043_A503ToolBoxDefaultLogo, T00043_n503ToolBoxDefaultLogo, T00043_A40001ReceptionImage_GXI, T00043_n40001ReceptionImage_GXI, T00043_A575ReceptionDescription, T00043_n575ReceptionDescription, T00043_A631ToolBoxLastUpdateTime,
               T00043_n631ToolBoxLastUpdateTime, T00043_A630ToolBoxLastUpdateReceptionistI, T00043_n630ToolBoxLastUpdateReceptionistI, T00043_A11OrganisationId, T00043_A29LocationId, T00043_A577LocationThemeId, T00043_n577LocationThemeId, T00043_A584ActiveAppVersionId, T00043_n584ActiveAppVersionId, T00043_A598PublishedActiveAppVersionId,
               T00043_n598PublishedActiveAppVersionId, T00043_A494LocationImage, T00043_n494LocationImage, T00043_A574ReceptionImage, T00043_n574ReceptionImage
               }
               , new Object[] {
               T00044_A89ReceptionistId
               }
               , new Object[] {
               T00045_A577LocationThemeId
               }
               , new Object[] {
               T00046_A523AppVersionId, T00046_A273Trn_ThemeId
               }
               , new Object[] {
               T00047_A523AppVersionId, T00047_A273Trn_ThemeId
               }
               , new Object[] {
               T00048_A327LocationCountry, T00048_A355LocationPhoneCode, T00048_A35LocationPhone, T00048_A329LocationZipCode, T00048_A31LocationName, T00048_A40000LocationImage_GXI, T00048_n40000LocationImage_GXI, T00048_A328LocationCity, T00048_A330LocationAddressLine1, T00048_A331LocationAddressLine2,
               T00048_A34LocationEmail, T00048_A356LocationPhoneNumber, T00048_A36LocationDescription, T00048_A568LocationBrandTheme, T00048_n568LocationBrandTheme, T00048_A569LocationCtaTheme, T00048_n569LocationCtaTheme, T00048_A570LocationHasMyCare, T00048_A571LocationHasMyServices, T00048_A572LocationHasMyLiving,
               T00048_A573LocationHasOwnBrand, T00048_A504ToolBoxDefaultProfileImage, T00048_n504ToolBoxDefaultProfileImage, T00048_A503ToolBoxDefaultLogo, T00048_n503ToolBoxDefaultLogo, T00048_A40001ReceptionImage_GXI, T00048_n40001ReceptionImage_GXI, T00048_A575ReceptionDescription, T00048_n575ReceptionDescription, T00048_A631ToolBoxLastUpdateTime,
               T00048_n631ToolBoxLastUpdateTime, T00048_A630ToolBoxLastUpdateReceptionistI, T00048_n630ToolBoxLastUpdateReceptionistI, T00048_A11OrganisationId, T00048_A29LocationId, T00048_A577LocationThemeId, T00048_n577LocationThemeId, T00048_A584ActiveAppVersionId, T00048_n584ActiveAppVersionId, T00048_A598PublishedActiveAppVersionId,
               T00048_n598PublishedActiveAppVersionId, T00048_A494LocationImage, T00048_n494LocationImage, T00048_A574ReceptionImage, T00048_n574ReceptionImage
               }
               , new Object[] {
               T00049_A89ReceptionistId
               }
               , new Object[] {
               T000410_A577LocationThemeId
               }
               , new Object[] {
               T000411_A523AppVersionId, T000411_A273Trn_ThemeId
               }
               , new Object[] {
               T000412_A523AppVersionId, T000412_A273Trn_ThemeId
               }
               , new Object[] {
               T000413_A29LocationId, T000413_A11OrganisationId
               }
               , new Object[] {
               T000414_A11OrganisationId, T000414_A29LocationId
               }
               , new Object[] {
               T000415_A11OrganisationId, T000415_A29LocationId
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
               }
               , new Object[] {
               T000421_A273Trn_ThemeId
               }
               , new Object[] {
               T000422_A273Trn_ThemeId
               }
               , new Object[] {
               T000423_A42SupplierGenId
               }
               , new Object[] {
               T000424_A527ResidentPackageId
               }
               , new Object[] {
               T000425_A523AppVersionId
               }
               , new Object[] {
               T000426_A268AgendaCalendarId
               }
               , new Object[] {
               T000427_A366LocationDynamicFormId, T000427_A11OrganisationId, T000427_A29LocationId
               }
               , new Object[] {
               T000428_A58ProductServiceId, T000428_A29LocationId, T000428_A11OrganisationId
               }
               , new Object[] {
               T000429_A62ResidentId, T000429_A29LocationId, T000429_A11OrganisationId
               }
               , new Object[] {
               T000430_A89ReceptionistId, T000430_A11OrganisationId, T000430_A29LocationId
               }
               , new Object[] {
               T000431_A29LocationId, T000431_A11OrganisationId
               }
            }
         );
         Z573LocationHasOwnBrand = false;
         A573LocationHasOwnBrand = false;
         i573LocationHasOwnBrand = false;
         Z572LocationHasMyLiving = false;
         A572LocationHasMyLiving = false;
         i572LocationHasMyLiving = false;
         Z571LocationHasMyServices = false;
         A571LocationHasMyServices = false;
         i571LocationHasMyServices = false;
         Z570LocationHasMyCare = false;
         A570LocationHasMyCare = false;
         i570LocationHasMyCare = false;
         AV46Pgmname = "Trn_Location";
         A574ReceptionImage = "";
         n574ReceptionImage = false;
         Z574ReceptionImage = "";
         n574ReceptionImage = false;
         i574ReceptionImage = "";
         n574ReceptionImage = false;
         Z575ReceptionDescription = "";
         n575ReceptionDescription = false;
         A575ReceptionDescription = "";
         n575ReceptionDescription = false;
         i575ReceptionDescription = "";
         n575ReceptionDescription = false;
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound6 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtLocationName_Enabled ;
      private int edtLocationEmail_Enabled ;
      private int divUnnamedtable5_Visible ;
      private int edtLocationPhoneCode_Visible ;
      private int edtLocationPhoneCode_Enabled ;
      private int edtLocationPhoneNumber_Enabled ;
      private int edtLocationPhone_Visible ;
      private int edtLocationPhone_Enabled ;
      private int Locationdescription_Color ;
      private int divUnnamedtable7_Visible ;
      private int edtLocationAddressLine1_Enabled ;
      private int edtLocationAddressLine2_Enabled ;
      private int edtLocationZipCode_Enabled ;
      private int edtLocationCity_Enabled ;
      private int edtLocationCountry_Visible ;
      private int edtLocationCountry_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int bttBtnudelete_Visible ;
      private int edtavCombolocationphonecode_Visible ;
      private int edtavCombolocationphonecode_Enabled ;
      private int edtavCombolocationcountry_Visible ;
      private int edtavCombolocationcountry_Enabled ;
      private int edtLocationId_Visible ;
      private int edtLocationId_Enabled ;
      private int edtOrganisationId_Visible ;
      private int edtOrganisationId_Enabled ;
      private int imgLocationImage_Visible ;
      private int imgLocationImage_Enabled ;
      private int Combo_locationphonecode_Datalistupdateminimumcharacters ;
      private int Combo_locationphonecode_Gxcontroltype ;
      private int Locationdescription_Coltitlecolor ;
      private int Combo_locationcountry_Datalistupdateminimumcharacters ;
      private int Combo_locationcountry_Gxcontroltype ;
      private int AV47GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z35LocationPhone ;
      private string Combo_locationcountry_Selectedvalue_get ;
      private string Combo_locationphonecode_Selectedvalue_get ;
      private string Imageuploaduc_Faileduploadmessage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtLocationName_Internalname ;
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
      private string edtLocationName_Jsonclick ;
      private string edtLocationEmail_Internalname ;
      private string edtLocationEmail_Jsonclick ;
      private string divUnnamedtable5_Internalname ;
      private string lblPhone_Internalname ;
      private string lblPhone_Jsonclick ;
      private string divUnnamedtable9_Internalname ;
      private string divUnnamedtable10_Internalname ;
      private string divUnnamedtablelocationphonecode_Internalname ;
      private string Combo_locationphonecode_Caption ;
      private string Combo_locationphonecode_Cls ;
      private string Combo_locationphonecode_Internalname ;
      private string edtLocationPhoneCode_Internalname ;
      private string edtLocationPhoneCode_Jsonclick ;
      private string edtLocationPhoneNumber_Internalname ;
      private string edtLocationPhoneNumber_Jsonclick ;
      private string divLocationphone_cell_Internalname ;
      private string divLocationphone_cell_Class ;
      private string edtLocationPhone_Internalname ;
      private string gxphoneLink ;
      private string A35LocationPhone ;
      private string edtLocationPhone_Jsonclick ;
      private string divUnnamedtable6_Internalname ;
      private string lblProductserviceimagetext_Internalname ;
      private string lblProductserviceimagetext_Jsonclick ;
      private string divUcfilecell_Internalname ;
      private string Imageuploaduc_Maxnumberoffiles ;
      private string Imageuploaduc_Isreadonlymode ;
      private string Imageuploaduc_Maxfilesize ;
      private string Imageuploaduc_Internalname ;
      private string divDecriptioneditortext_Internalname ;
      private string divDecriptioneditortext_Class ;
      private string Locationdescription_Internalname ;
      private string Locationdescription_Width ;
      private string Locationdescription_Height ;
      private string Locationdescription_Skin ;
      private string Locationdescription_Toolbar ;
      private string Locationdescription_Customtoolbar ;
      private string Locationdescription_Customconfiguration ;
      private string Locationdescription_Captionclass ;
      private string Locationdescription_Captionstyle ;
      private string Locationdescription_Captionposition ;
      private string divUnnamedtable7_Internalname ;
      private string lblTextblockdescriptionlabel_Internalname ;
      private string lblTextblockdescriptionlabel_Jsonclick ;
      private string divUnnamedtable8_Internalname ;
      private string lblDescriptiontext_Internalname ;
      private string lblDescriptiontext_Jsonclick ;
      private string grpUnnamedgroup4_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string edtLocationAddressLine1_Internalname ;
      private string edtLocationAddressLine1_Jsonclick ;
      private string edtLocationAddressLine2_Internalname ;
      private string edtLocationAddressLine2_Jsonclick ;
      private string edtLocationZipCode_Internalname ;
      private string edtLocationZipCode_Jsonclick ;
      private string edtLocationCity_Internalname ;
      private string edtLocationCity_Jsonclick ;
      private string divTablesplittedlocationcountry_Internalname ;
      private string lblTextblocklocationcountry_Internalname ;
      private string lblTextblocklocationcountry_Jsonclick ;
      private string Combo_locationcountry_Caption ;
      private string Combo_locationcountry_Cls ;
      private string Combo_locationcountry_Internalname ;
      private string edtLocationCountry_Internalname ;
      private string edtLocationCountry_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string bttBtnudelete_Internalname ;
      private string bttBtnudelete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_locationphonecode_Internalname ;
      private string edtavCombolocationphonecode_Internalname ;
      private string edtavCombolocationphonecode_Jsonclick ;
      private string divSectionattribute_locationcountry_Internalname ;
      private string edtavCombolocationcountry_Internalname ;
      private string edtavCombolocationcountry_Jsonclick ;
      private string edtLocationId_Internalname ;
      private string edtLocationId_Jsonclick ;
      private string edtOrganisationId_Internalname ;
      private string edtOrganisationId_Jsonclick ;
      private string sImgUrl ;
      private string imgLocationImage_Internalname ;
      private string AV46Pgmname ;
      private string Combo_locationphonecode_Objectcall ;
      private string Combo_locationphonecode_Class ;
      private string Combo_locationphonecode_Icontype ;
      private string Combo_locationphonecode_Icon ;
      private string Combo_locationphonecode_Tooltip ;
      private string Combo_locationphonecode_Selectedvalue_set ;
      private string Combo_locationphonecode_Selectedtext_set ;
      private string Combo_locationphonecode_Selectedtext_get ;
      private string Combo_locationphonecode_Gamoauthtoken ;
      private string Combo_locationphonecode_Ddointernalname ;
      private string Combo_locationphonecode_Titlecontrolalign ;
      private string Combo_locationphonecode_Dropdownoptionstype ;
      private string Combo_locationphonecode_Titlecontrolidtoreplace ;
      private string Combo_locationphonecode_Datalisttype ;
      private string Combo_locationphonecode_Datalistfixedvalues ;
      private string Combo_locationphonecode_Datalistproc ;
      private string Combo_locationphonecode_Datalistprocparametersprefix ;
      private string Combo_locationphonecode_Remoteservicesparameters ;
      private string Combo_locationphonecode_Htmltemplate ;
      private string Combo_locationphonecode_Multiplevaluestype ;
      private string Combo_locationphonecode_Loadingdata ;
      private string Combo_locationphonecode_Noresultsfound ;
      private string Combo_locationphonecode_Emptyitemtext ;
      private string Combo_locationphonecode_Onlyselectedvalues ;
      private string Combo_locationphonecode_Selectalltext ;
      private string Combo_locationphonecode_Multiplevaluesseparator ;
      private string Combo_locationphonecode_Addnewoptiontext ;
      private string Imageuploaduc_Objectcall ;
      private string Imageuploaduc_Class ;
      private string Locationdescription_Objectcall ;
      private string Locationdescription_Class ;
      private string Locationdescription_Buttonpressedid ;
      private string Locationdescription_Captionvalue ;
      private string Locationdescription_Coltitle ;
      private string Locationdescription_Coltitlefont ;
      private string Combo_locationcountry_Objectcall ;
      private string Combo_locationcountry_Class ;
      private string Combo_locationcountry_Icontype ;
      private string Combo_locationcountry_Icon ;
      private string Combo_locationcountry_Tooltip ;
      private string Combo_locationcountry_Selectedvalue_set ;
      private string Combo_locationcountry_Selectedtext_set ;
      private string Combo_locationcountry_Selectedtext_get ;
      private string Combo_locationcountry_Gamoauthtoken ;
      private string Combo_locationcountry_Ddointernalname ;
      private string Combo_locationcountry_Titlecontrolalign ;
      private string Combo_locationcountry_Dropdownoptionstype ;
      private string Combo_locationcountry_Titlecontrolidtoreplace ;
      private string Combo_locationcountry_Datalisttype ;
      private string Combo_locationcountry_Datalistfixedvalues ;
      private string Combo_locationcountry_Datalistproc ;
      private string Combo_locationcountry_Datalistprocparametersprefix ;
      private string Combo_locationcountry_Remoteservicesparameters ;
      private string Combo_locationcountry_Htmltemplate ;
      private string Combo_locationcountry_Multiplevaluestype ;
      private string Combo_locationcountry_Loadingdata ;
      private string Combo_locationcountry_Noresultsfound ;
      private string Combo_locationcountry_Emptyitemtext ;
      private string Combo_locationcountry_Onlyselectedvalues ;
      private string Combo_locationcountry_Selectalltext ;
      private string Combo_locationcountry_Multiplevaluesseparator ;
      private string Combo_locationcountry_Addnewoptiontext ;
      private string hsh ;
      private string sMode6 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string imgReceptionimagevar_gximage ;
      private string imgReceptionimagevar_Internalname ;
      private string AV29Message ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string GXt_char2 ;
      private DateTime Z631ToolBoxLastUpdateTime ;
      private DateTime A631ToolBoxLastUpdateTime ;
      private bool Z570LocationHasMyCare ;
      private bool Z571LocationHasMyServices ;
      private bool Z572LocationHasMyLiving ;
      private bool Z573LocationHasOwnBrand ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n29LocationId ;
      private bool n630ToolBoxLastUpdateReceptionistI ;
      private bool n11OrganisationId ;
      private bool n577LocationThemeId ;
      private bool n584ActiveAppVersionId ;
      private bool n598PublishedActiveAppVersionId ;
      private bool wbErr ;
      private bool Combo_locationphonecode_Emptyitem ;
      private bool Locationdescription_Toolbarcancollapse ;
      private bool Combo_locationcountry_Emptyitem ;
      private bool A494LocationImage_IsBlob ;
      private bool n504ToolBoxDefaultProfileImage ;
      private bool n503ToolBoxDefaultLogo ;
      private bool n575ReceptionDescription ;
      private bool n631ToolBoxLastUpdateTime ;
      private bool A570LocationHasMyCare ;
      private bool A571LocationHasMyServices ;
      private bool A572LocationHasMyLiving ;
      private bool A573LocationHasOwnBrand ;
      private bool n574ReceptionImage ;
      private bool n40000LocationImage_GXI ;
      private bool n568LocationBrandTheme ;
      private bool n569LocationCtaTheme ;
      private bool n40001ReceptionImage_GXI ;
      private bool Combo_locationphonecode_Enabled ;
      private bool Combo_locationphonecode_Visible ;
      private bool Combo_locationphonecode_Allowmultipleselection ;
      private bool Combo_locationphonecode_Isgriditem ;
      private bool Combo_locationphonecode_Hasdescription ;
      private bool Combo_locationphonecode_Includeonlyselectedoption ;
      private bool Combo_locationphonecode_Includeselectalloption ;
      private bool Combo_locationphonecode_Includeaddnewoption ;
      private bool Imageuploaduc_Enabled ;
      private bool Imageuploaduc_Visible ;
      private bool Locationdescription_Enabled ;
      private bool Locationdescription_Toolbarexpanded ;
      private bool Locationdescription_Isabstractlayoutcontrol ;
      private bool Locationdescription_Usercontroliscolumn ;
      private bool Locationdescription_Visible ;
      private bool Combo_locationcountry_Enabled ;
      private bool Combo_locationcountry_Visible ;
      private bool Combo_locationcountry_Allowmultipleselection ;
      private bool Combo_locationcountry_Isgriditem ;
      private bool Combo_locationcountry_Hasdescription ;
      private bool Combo_locationcountry_Includeonlyselectedoption ;
      private bool Combo_locationcountry_Includeselectalloption ;
      private bool Combo_locationcountry_Includeaddnewoption ;
      private bool n494LocationImage ;
      private bool returnInSub ;
      private bool AV28isSuccessful ;
      private bool Gx_longc ;
      private bool i573LocationHasOwnBrand ;
      private bool i572LocationHasMyLiving ;
      private bool i571LocationHasMyServices ;
      private bool i570LocationHasMyCare ;
      private string LocationDescription ;
      private string A36LocationDescription ;
      private string A568LocationBrandTheme ;
      private string A569LocationCtaTheme ;
      private string Z36LocationDescription ;
      private string Z568LocationBrandTheme ;
      private string Z569LocationCtaTheme ;
      private string Z327LocationCountry ;
      private string Z355LocationPhoneCode ;
      private string Z329LocationZipCode ;
      private string Z31LocationName ;
      private string Z328LocationCity ;
      private string Z330LocationAddressLine1 ;
      private string Z331LocationAddressLine2 ;
      private string Z34LocationEmail ;
      private string Z356LocationPhoneNumber ;
      private string Z504ToolBoxDefaultProfileImage ;
      private string Z503ToolBoxDefaultLogo ;
      private string Z575ReceptionDescription ;
      private string A355LocationPhoneCode ;
      private string A356LocationPhoneNumber ;
      private string A31LocationName ;
      private string A34LocationEmail ;
      private string A330LocationAddressLine1 ;
      private string A331LocationAddressLine2 ;
      private string A329LocationZipCode ;
      private string A328LocationCity ;
      private string A327LocationCountry ;
      private string AV16ComboLocationPhoneCode ;
      private string AV23ComboLocationCountry ;
      private string A40000LocationImage_GXI ;
      private string A504ToolBoxDefaultProfileImage ;
      private string A503ToolBoxDefaultLogo ;
      private string A575ReceptionDescription ;
      private string AV31ReceptionDescriptionVar ;
      private string A40001ReceptionImage_GXI ;
      private string AV45Receptionimagevar_GXI ;
      private string AV18ComboSelectedValue ;
      private string AV17ComboSelectedText ;
      private string Z40000LocationImage_GXI ;
      private string Z40001ReceptionImage_GXI ;
      private string i575ReceptionDescription ;
      private string A494LocationImage ;
      private string AV30ReceptionImageVar ;
      private string A574ReceptionImage ;
      private string Z494LocationImage ;
      private string Z574ReceptionImage ;
      private string i574ReceptionImage ;
      private Guid wcpOAV7LocationId ;
      private Guid wcpOAV8OrganisationId ;
      private Guid Z29LocationId ;
      private Guid Z11OrganisationId ;
      private Guid Z630ToolBoxLastUpdateReceptionistI ;
      private Guid Z577LocationThemeId ;
      private Guid Z584ActiveAppVersionId ;
      private Guid Z598PublishedActiveAppVersionId ;
      private Guid N584ActiveAppVersionId ;
      private Guid N598PublishedActiveAppVersionId ;
      private Guid N577LocationThemeId ;
      private Guid N630ToolBoxLastUpdateReceptionistI ;
      private Guid A29LocationId ;
      private Guid A630ToolBoxLastUpdateReceptionistI ;
      private Guid A11OrganisationId ;
      private Guid A577LocationThemeId ;
      private Guid A584ActiveAppVersionId ;
      private Guid A598PublishedActiveAppVersionId ;
      private Guid AV7LocationId ;
      private Guid AV8OrganisationId ;
      private Guid AV34Insert_ActiveAppVersionId ;
      private Guid AV40Insert_PublishedActiveAppVersionId ;
      private Guid AV32Insert_LocationThemeId ;
      private Guid AV43Insert_ToolBoxLastUpdateReceptionistId ;
      private Guid A273Trn_ThemeId ;
      private Guid A523AppVersionId ;
      private Guid A89ReceptionistId ;
      private IGxSession AV13WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucCombo_locationphonecode ;
      private GXUserControl ucImageuploaduc ;
      private GXUserControl ucLocationdescription ;
      private GXUserControl ucCombo_locationcountry ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV19DDO_TitleSettingsIcons ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV21LocationPhoneCode_Data ;
      private GXBaseCollection<SdtSDT_FileUploadData> AV42UploadedFiles ;
      private GXBaseCollection<SdtSDT_FileUploadData> AV41FilesToUpdate ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV22LocationCountry_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV12TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV26TrnContextAtt ;
      private GXBaseCollection<SdtSDT_FileUploadData> GXt_objcol_SdtSDT_FileUploadData3 ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> GXt_objcol_SdtDVB_SDTComboData_Item4 ;
      private IDataStoreProvider pr_default ;
      private string[] T00048_A327LocationCountry ;
      private string[] T00048_A355LocationPhoneCode ;
      private string[] T00048_A35LocationPhone ;
      private string[] T00048_A329LocationZipCode ;
      private string[] T00048_A31LocationName ;
      private string[] T00048_A40000LocationImage_GXI ;
      private bool[] T00048_n40000LocationImage_GXI ;
      private string[] T00048_A328LocationCity ;
      private string[] T00048_A330LocationAddressLine1 ;
      private string[] T00048_A331LocationAddressLine2 ;
      private string[] T00048_A34LocationEmail ;
      private string[] T00048_A356LocationPhoneNumber ;
      private string[] T00048_A36LocationDescription ;
      private string[] T00048_A568LocationBrandTheme ;
      private bool[] T00048_n568LocationBrandTheme ;
      private string[] T00048_A569LocationCtaTheme ;
      private bool[] T00048_n569LocationCtaTheme ;
      private bool[] T00048_A570LocationHasMyCare ;
      private bool[] T00048_A571LocationHasMyServices ;
      private bool[] T00048_A572LocationHasMyLiving ;
      private bool[] T00048_A573LocationHasOwnBrand ;
      private string[] T00048_A504ToolBoxDefaultProfileImage ;
      private bool[] T00048_n504ToolBoxDefaultProfileImage ;
      private string[] T00048_A503ToolBoxDefaultLogo ;
      private bool[] T00048_n503ToolBoxDefaultLogo ;
      private string[] T00048_A40001ReceptionImage_GXI ;
      private bool[] T00048_n40001ReceptionImage_GXI ;
      private string[] T00048_A575ReceptionDescription ;
      private bool[] T00048_n575ReceptionDescription ;
      private DateTime[] T00048_A631ToolBoxLastUpdateTime ;
      private bool[] T00048_n631ToolBoxLastUpdateTime ;
      private Guid[] T00048_A630ToolBoxLastUpdateReceptionistI ;
      private bool[] T00048_n630ToolBoxLastUpdateReceptionistI ;
      private Guid[] T00048_A11OrganisationId ;
      private bool[] T00048_n11OrganisationId ;
      private Guid[] T00048_A29LocationId ;
      private bool[] T00048_n29LocationId ;
      private Guid[] T00048_A577LocationThemeId ;
      private bool[] T00048_n577LocationThemeId ;
      private Guid[] T00048_A584ActiveAppVersionId ;
      private bool[] T00048_n584ActiveAppVersionId ;
      private Guid[] T00048_A598PublishedActiveAppVersionId ;
      private bool[] T00048_n598PublishedActiveAppVersionId ;
      private string[] T00048_A494LocationImage ;
      private bool[] T00048_n494LocationImage ;
      private string[] T00048_A574ReceptionImage ;
      private bool[] T00048_n574ReceptionImage ;
      private Guid[] T00046_A523AppVersionId ;
      private Guid[] T00046_A273Trn_ThemeId ;
      private Guid[] T00047_A523AppVersionId ;
      private Guid[] T00047_A273Trn_ThemeId ;
      private Guid[] T00044_A89ReceptionistId ;
      private Guid[] T00045_A577LocationThemeId ;
      private bool[] T00045_n577LocationThemeId ;
      private Guid[] T00049_A89ReceptionistId ;
      private Guid[] T000410_A577LocationThemeId ;
      private bool[] T000410_n577LocationThemeId ;
      private Guid[] T000411_A523AppVersionId ;
      private Guid[] T000411_A273Trn_ThemeId ;
      private Guid[] T000412_A523AppVersionId ;
      private Guid[] T000412_A273Trn_ThemeId ;
      private Guid[] T000413_A29LocationId ;
      private bool[] T000413_n29LocationId ;
      private Guid[] T000413_A11OrganisationId ;
      private bool[] T000413_n11OrganisationId ;
      private string[] T00043_A327LocationCountry ;
      private string[] T00043_A355LocationPhoneCode ;
      private string[] T00043_A35LocationPhone ;
      private string[] T00043_A329LocationZipCode ;
      private string[] T00043_A31LocationName ;
      private string[] T00043_A40000LocationImage_GXI ;
      private bool[] T00043_n40000LocationImage_GXI ;
      private string[] T00043_A328LocationCity ;
      private string[] T00043_A330LocationAddressLine1 ;
      private string[] T00043_A331LocationAddressLine2 ;
      private string[] T00043_A34LocationEmail ;
      private string[] T00043_A356LocationPhoneNumber ;
      private string[] T00043_A36LocationDescription ;
      private string[] T00043_A568LocationBrandTheme ;
      private bool[] T00043_n568LocationBrandTheme ;
      private string[] T00043_A569LocationCtaTheme ;
      private bool[] T00043_n569LocationCtaTheme ;
      private bool[] T00043_A570LocationHasMyCare ;
      private bool[] T00043_A571LocationHasMyServices ;
      private bool[] T00043_A572LocationHasMyLiving ;
      private bool[] T00043_A573LocationHasOwnBrand ;
      private string[] T00043_A504ToolBoxDefaultProfileImage ;
      private bool[] T00043_n504ToolBoxDefaultProfileImage ;
      private string[] T00043_A503ToolBoxDefaultLogo ;
      private bool[] T00043_n503ToolBoxDefaultLogo ;
      private string[] T00043_A40001ReceptionImage_GXI ;
      private bool[] T00043_n40001ReceptionImage_GXI ;
      private string[] T00043_A575ReceptionDescription ;
      private bool[] T00043_n575ReceptionDescription ;
      private DateTime[] T00043_A631ToolBoxLastUpdateTime ;
      private bool[] T00043_n631ToolBoxLastUpdateTime ;
      private Guid[] T00043_A630ToolBoxLastUpdateReceptionistI ;
      private bool[] T00043_n630ToolBoxLastUpdateReceptionistI ;
      private Guid[] T00043_A11OrganisationId ;
      private bool[] T00043_n11OrganisationId ;
      private Guid[] T00043_A29LocationId ;
      private bool[] T00043_n29LocationId ;
      private Guid[] T00043_A577LocationThemeId ;
      private bool[] T00043_n577LocationThemeId ;
      private Guid[] T00043_A584ActiveAppVersionId ;
      private bool[] T00043_n584ActiveAppVersionId ;
      private Guid[] T00043_A598PublishedActiveAppVersionId ;
      private bool[] T00043_n598PublishedActiveAppVersionId ;
      private string[] T00043_A494LocationImage ;
      private bool[] T00043_n494LocationImage ;
      private string[] T00043_A574ReceptionImage ;
      private bool[] T00043_n574ReceptionImage ;
      private Guid[] T000414_A11OrganisationId ;
      private bool[] T000414_n11OrganisationId ;
      private Guid[] T000414_A29LocationId ;
      private bool[] T000414_n29LocationId ;
      private Guid[] T000415_A11OrganisationId ;
      private bool[] T000415_n11OrganisationId ;
      private Guid[] T000415_A29LocationId ;
      private bool[] T000415_n29LocationId ;
      private string[] T00042_A327LocationCountry ;
      private string[] T00042_A355LocationPhoneCode ;
      private string[] T00042_A35LocationPhone ;
      private string[] T00042_A329LocationZipCode ;
      private string[] T00042_A31LocationName ;
      private string[] T00042_A40000LocationImage_GXI ;
      private bool[] T00042_n40000LocationImage_GXI ;
      private string[] T00042_A328LocationCity ;
      private string[] T00042_A330LocationAddressLine1 ;
      private string[] T00042_A331LocationAddressLine2 ;
      private string[] T00042_A34LocationEmail ;
      private string[] T00042_A356LocationPhoneNumber ;
      private string[] T00042_A36LocationDescription ;
      private string[] T00042_A568LocationBrandTheme ;
      private bool[] T00042_n568LocationBrandTheme ;
      private string[] T00042_A569LocationCtaTheme ;
      private bool[] T00042_n569LocationCtaTheme ;
      private bool[] T00042_A570LocationHasMyCare ;
      private bool[] T00042_A571LocationHasMyServices ;
      private bool[] T00042_A572LocationHasMyLiving ;
      private bool[] T00042_A573LocationHasOwnBrand ;
      private string[] T00042_A504ToolBoxDefaultProfileImage ;
      private bool[] T00042_n504ToolBoxDefaultProfileImage ;
      private string[] T00042_A503ToolBoxDefaultLogo ;
      private bool[] T00042_n503ToolBoxDefaultLogo ;
      private string[] T00042_A40001ReceptionImage_GXI ;
      private bool[] T00042_n40001ReceptionImage_GXI ;
      private string[] T00042_A575ReceptionDescription ;
      private bool[] T00042_n575ReceptionDescription ;
      private DateTime[] T00042_A631ToolBoxLastUpdateTime ;
      private bool[] T00042_n631ToolBoxLastUpdateTime ;
      private Guid[] T00042_A630ToolBoxLastUpdateReceptionistI ;
      private bool[] T00042_n630ToolBoxLastUpdateReceptionistI ;
      private Guid[] T00042_A11OrganisationId ;
      private bool[] T00042_n11OrganisationId ;
      private Guid[] T00042_A29LocationId ;
      private bool[] T00042_n29LocationId ;
      private Guid[] T00042_A577LocationThemeId ;
      private bool[] T00042_n577LocationThemeId ;
      private Guid[] T00042_A584ActiveAppVersionId ;
      private bool[] T00042_n584ActiveAppVersionId ;
      private Guid[] T00042_A598PublishedActiveAppVersionId ;
      private bool[] T00042_n598PublishedActiveAppVersionId ;
      private string[] T00042_A494LocationImage ;
      private bool[] T00042_n494LocationImage ;
      private string[] T00042_A574ReceptionImage ;
      private bool[] T00042_n574ReceptionImage ;
      private Guid[] T000421_A273Trn_ThemeId ;
      private Guid[] T000422_A273Trn_ThemeId ;
      private Guid[] T000423_A42SupplierGenId ;
      private Guid[] T000424_A527ResidentPackageId ;
      private Guid[] T000425_A523AppVersionId ;
      private Guid[] T000426_A268AgendaCalendarId ;
      private Guid[] T000427_A366LocationDynamicFormId ;
      private Guid[] T000427_A11OrganisationId ;
      private bool[] T000427_n11OrganisationId ;
      private Guid[] T000427_A29LocationId ;
      private bool[] T000427_n29LocationId ;
      private Guid[] T000428_A58ProductServiceId ;
      private Guid[] T000428_A29LocationId ;
      private bool[] T000428_n29LocationId ;
      private Guid[] T000428_A11OrganisationId ;
      private bool[] T000428_n11OrganisationId ;
      private Guid[] T000429_A62ResidentId ;
      private Guid[] T000429_A29LocationId ;
      private bool[] T000429_n29LocationId ;
      private Guid[] T000429_A11OrganisationId ;
      private bool[] T000429_n11OrganisationId ;
      private Guid[] T000430_A89ReceptionistId ;
      private Guid[] T000430_A11OrganisationId ;
      private bool[] T000430_n11OrganisationId ;
      private Guid[] T000430_A29LocationId ;
      private bool[] T000430_n29LocationId ;
      private Guid[] T000431_A29LocationId ;
      private bool[] T000431_n29LocationId ;
      private Guid[] T000431_A11OrganisationId ;
      private bool[] T000431_n11OrganisationId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_location__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_location__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_location__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[12])
      ,new ForEachCursor(def[13])
      ,new UpdateCursor(def[14])
      ,new UpdateCursor(def[15])
      ,new UpdateCursor(def[16])
      ,new UpdateCursor(def[17])
      ,new UpdateCursor(def[18])
      ,new ForEachCursor(def[19])
      ,new ForEachCursor(def[20])
      ,new ForEachCursor(def[21])
      ,new ForEachCursor(def[22])
      ,new ForEachCursor(def[23])
      ,new ForEachCursor(def[24])
      ,new ForEachCursor(def[25])
      ,new ForEachCursor(def[26])
      ,new ForEachCursor(def[27])
      ,new ForEachCursor(def[28])
      ,new ForEachCursor(def[29])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT00042;
       prmT00042 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT00043;
       prmT00043 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT00044;
       prmT00044 = new Object[] {
       new ParDef("ToolBoxLastUpdateReceptionistI",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT00045;
       prmT00045 = new Object[] {
       new ParDef("LocationThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT00046;
       prmT00046 = new Object[] {
       new ParDef("ActiveAppVersionId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT00047;
       prmT00047 = new Object[] {
       new ParDef("PublishedActiveAppVersionId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT00048;
       prmT00048 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT00049;
       prmT00049 = new Object[] {
       new ParDef("ToolBoxLastUpdateReceptionistI",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000410;
       prmT000410 = new Object[] {
       new ParDef("LocationThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000411;
       prmT000411 = new Object[] {
       new ParDef("ActiveAppVersionId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000412;
       prmT000412 = new Object[] {
       new ParDef("PublishedActiveAppVersionId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000413;
       prmT000413 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000414;
       prmT000414 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000415;
       prmT000415 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000416;
       prmT000416 = new Object[] {
       new ParDef("LocationCountry",GXType.VarChar,100,0) ,
       new ParDef("LocationPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("LocationPhone",GXType.Char,20,0) ,
       new ParDef("LocationZipCode",GXType.VarChar,100,0) ,
       new ParDef("LocationName",GXType.VarChar,100,0) ,
       new ParDef("LocationImage",GXType.Byte,1024,0){Nullable=true,InDB=false} ,
       new ParDef("LocationImage_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=5, Tbl="Trn_Location", Fld="LocationImage"} ,
       new ParDef("LocationCity",GXType.VarChar,100,0) ,
       new ParDef("LocationAddressLine1",GXType.VarChar,100,0) ,
       new ParDef("LocationAddressLine2",GXType.VarChar,100,0) ,
       new ParDef("LocationEmail",GXType.VarChar,100,0) ,
       new ParDef("LocationPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("LocationDescription",GXType.LongVarChar,2097152,0) ,
       new ParDef("LocationBrandTheme",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("LocationCtaTheme",GXType.LongVarChar,1000,0){Nullable=true} ,
       new ParDef("LocationHasMyCare",GXType.Boolean,4,0) ,
       new ParDef("LocationHasMyServices",GXType.Boolean,4,0) ,
       new ParDef("LocationHasMyLiving",GXType.Boolean,4,0) ,
       new ParDef("LocationHasOwnBrand",GXType.Boolean,4,0) ,
       new ParDef("ToolBoxDefaultProfileImage",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("ToolBoxDefaultLogo",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("ReceptionImage",GXType.Byte,1024,0){Nullable=true,InDB=false} ,
       new ParDef("ReceptionImage_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=21, Tbl="Trn_Location", Fld="ReceptionImage"} ,
       new ParDef("ReceptionDescription",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("ToolBoxLastUpdateTime",GXType.DateTime,0,5){Nullable=true} ,
       new ParDef("ToolBoxLastUpdateReceptionistI",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ActiveAppVersionId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("PublishedActiveAppVersionId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000417;
       prmT000417 = new Object[] {
       new ParDef("LocationCountry",GXType.VarChar,100,0) ,
       new ParDef("LocationPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("LocationPhone",GXType.Char,20,0) ,
       new ParDef("LocationZipCode",GXType.VarChar,100,0) ,
       new ParDef("LocationName",GXType.VarChar,100,0) ,
       new ParDef("LocationCity",GXType.VarChar,100,0) ,
       new ParDef("LocationAddressLine1",GXType.VarChar,100,0) ,
       new ParDef("LocationAddressLine2",GXType.VarChar,100,0) ,
       new ParDef("LocationEmail",GXType.VarChar,100,0) ,
       new ParDef("LocationPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("LocationDescription",GXType.LongVarChar,2097152,0) ,
       new ParDef("LocationBrandTheme",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("LocationCtaTheme",GXType.LongVarChar,1000,0){Nullable=true} ,
       new ParDef("LocationHasMyCare",GXType.Boolean,4,0) ,
       new ParDef("LocationHasMyServices",GXType.Boolean,4,0) ,
       new ParDef("LocationHasMyLiving",GXType.Boolean,4,0) ,
       new ParDef("LocationHasOwnBrand",GXType.Boolean,4,0) ,
       new ParDef("ToolBoxDefaultProfileImage",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("ToolBoxDefaultLogo",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("ReceptionDescription",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("ToolBoxLastUpdateTime",GXType.DateTime,0,5){Nullable=true} ,
       new ParDef("ToolBoxLastUpdateReceptionistI",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ActiveAppVersionId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("PublishedActiveAppVersionId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000418;
       prmT000418 = new Object[] {
       new ParDef("LocationImage",GXType.Byte,1024,0){Nullable=true,InDB=false} ,
       new ParDef("LocationImage_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="Trn_Location", Fld="LocationImage"} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000419;
       prmT000419 = new Object[] {
       new ParDef("ReceptionImage",GXType.Byte,1024,0){Nullable=true,InDB=false} ,
       new ParDef("ReceptionImage_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="Trn_Location", Fld="ReceptionImage"} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000420;
       prmT000420 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000421;
       prmT000421 = new Object[] {
       new ParDef("ActiveAppVersionId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000422;
       prmT000422 = new Object[] {
       new ParDef("PublishedActiveAppVersionId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000423;
       prmT000423 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000424;
       prmT000424 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000425;
       prmT000425 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000426;
       prmT000426 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000427;
       prmT000427 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000428;
       prmT000428 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000429;
       prmT000429 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000430;
       prmT000430 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000431;
       prmT000431 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T00042", "SELECT LocationCountry, LocationPhoneCode, LocationPhone, LocationZipCode, LocationName, LocationImage_GXI, LocationCity, LocationAddressLine1, LocationAddressLine2, LocationEmail, LocationPhoneNumber, LocationDescription, LocationBrandTheme, LocationCtaTheme, LocationHasMyCare, LocationHasMyServices, LocationHasMyLiving, LocationHasOwnBrand, ToolBoxDefaultProfileImage, ToolBoxDefaultLogo, ReceptionImage_GXI, ReceptionDescription, ToolBoxLastUpdateTime, ToolBoxLastUpdateReceptionistI, OrganisationId, LocationId, LocationThemeId, ActiveAppVersionId, PublishedActiveAppVersionId, LocationImage, ReceptionImage FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId  FOR UPDATE OF Trn_Location NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00042,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00043", "SELECT LocationCountry, LocationPhoneCode, LocationPhone, LocationZipCode, LocationName, LocationImage_GXI, LocationCity, LocationAddressLine1, LocationAddressLine2, LocationEmail, LocationPhoneNumber, LocationDescription, LocationBrandTheme, LocationCtaTheme, LocationHasMyCare, LocationHasMyServices, LocationHasMyLiving, LocationHasOwnBrand, ToolBoxDefaultProfileImage, ToolBoxDefaultLogo, ReceptionImage_GXI, ReceptionDescription, ToolBoxLastUpdateTime, ToolBoxLastUpdateReceptionistI, OrganisationId, LocationId, LocationThemeId, ActiveAppVersionId, PublishedActiveAppVersionId, LocationImage, ReceptionImage FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00043,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00044", "SELECT ReceptionistId FROM Trn_Receptionist WHERE ReceptionistId = :ToolBoxLastUpdateReceptionistI AND OrganisationId = :OrganisationId AND LocationId = :LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00044,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00045", "SELECT Trn_ThemeId AS LocationThemeId FROM Trn_Theme WHERE Trn_ThemeId = :LocationThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00045,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00046", "SELECT AppVersionId, Trn_ThemeId FROM Trn_AppVersion WHERE AppVersionId = :ActiveAppVersionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00046,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00047", "SELECT AppVersionId, Trn_ThemeId FROM Trn_AppVersion WHERE AppVersionId = :PublishedActiveAppVersionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00047,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00048", "SELECT TM1.LocationCountry, TM1.LocationPhoneCode, TM1.LocationPhone, TM1.LocationZipCode, TM1.LocationName, TM1.LocationImage_GXI, TM1.LocationCity, TM1.LocationAddressLine1, TM1.LocationAddressLine2, TM1.LocationEmail, TM1.LocationPhoneNumber, TM1.LocationDescription, TM1.LocationBrandTheme, TM1.LocationCtaTheme, TM1.LocationHasMyCare, TM1.LocationHasMyServices, TM1.LocationHasMyLiving, TM1.LocationHasOwnBrand, TM1.ToolBoxDefaultProfileImage, TM1.ToolBoxDefaultLogo, TM1.ReceptionImage_GXI, TM1.ReceptionDescription, TM1.ToolBoxLastUpdateTime, TM1.ToolBoxLastUpdateReceptionistI, TM1.OrganisationId, TM1.LocationId, TM1.LocationThemeId AS LocationThemeId, TM1.ActiveAppVersionId, TM1.PublishedActiveAppVersionId, TM1.LocationImage, TM1.ReceptionImage FROM Trn_Location TM1 WHERE TM1.OrganisationId = :OrganisationId and TM1.LocationId = :LocationId ORDER BY TM1.LocationId, TM1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00048,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00049", "SELECT ReceptionistId FROM Trn_Receptionist WHERE ReceptionistId = :ToolBoxLastUpdateReceptionistI AND OrganisationId = :OrganisationId AND LocationId = :LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00049,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000410", "SELECT Trn_ThemeId AS LocationThemeId FROM Trn_Theme WHERE Trn_ThemeId = :LocationThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000410,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000411", "SELECT AppVersionId, Trn_ThemeId FROM Trn_AppVersion WHERE AppVersionId = :ActiveAppVersionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000411,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000412", "SELECT AppVersionId, Trn_ThemeId FROM Trn_AppVersion WHERE AppVersionId = :PublishedActiveAppVersionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000412,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000413", "SELECT LocationId, OrganisationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000413,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000414", "SELECT OrganisationId, LocationId FROM Trn_Location WHERE ( OrganisationId > :OrganisationId or OrganisationId = :OrganisationId and LocationId > :LocationId) ORDER BY LocationId, OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000414,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000415", "SELECT OrganisationId, LocationId FROM Trn_Location WHERE ( OrganisationId < :OrganisationId or OrganisationId = :OrganisationId and LocationId < :LocationId) ORDER BY LocationId DESC, OrganisationId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000415,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000416", "SAVEPOINT gxupdate;INSERT INTO Trn_Location(LocationCountry, LocationPhoneCode, LocationPhone, LocationZipCode, LocationName, LocationImage, LocationImage_GXI, LocationCity, LocationAddressLine1, LocationAddressLine2, LocationEmail, LocationPhoneNumber, LocationDescription, LocationBrandTheme, LocationCtaTheme, LocationHasMyCare, LocationHasMyServices, LocationHasMyLiving, LocationHasOwnBrand, ToolBoxDefaultProfileImage, ToolBoxDefaultLogo, ReceptionImage, ReceptionImage_GXI, ReceptionDescription, ToolBoxLastUpdateTime, ToolBoxLastUpdateReceptionistI, OrganisationId, LocationId, LocationThemeId, ActiveAppVersionId, PublishedActiveAppVersionId) VALUES(:LocationCountry, :LocationPhoneCode, :LocationPhone, :LocationZipCode, :LocationName, :LocationImage, :LocationImage_GXI, :LocationCity, :LocationAddressLine1, :LocationAddressLine2, :LocationEmail, :LocationPhoneNumber, :LocationDescription, :LocationBrandTheme, :LocationCtaTheme, :LocationHasMyCare, :LocationHasMyServices, :LocationHasMyLiving, :LocationHasOwnBrand, :ToolBoxDefaultProfileImage, :ToolBoxDefaultLogo, :ReceptionImage, :ReceptionImage_GXI, :ReceptionDescription, :ToolBoxLastUpdateTime, :ToolBoxLastUpdateReceptionistI, :OrganisationId, :LocationId, :LocationThemeId, :ActiveAppVersionId, :PublishedActiveAppVersionId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000416)
          ,new CursorDef("T000417", "SAVEPOINT gxupdate;UPDATE Trn_Location SET LocationCountry=:LocationCountry, LocationPhoneCode=:LocationPhoneCode, LocationPhone=:LocationPhone, LocationZipCode=:LocationZipCode, LocationName=:LocationName, LocationCity=:LocationCity, LocationAddressLine1=:LocationAddressLine1, LocationAddressLine2=:LocationAddressLine2, LocationEmail=:LocationEmail, LocationPhoneNumber=:LocationPhoneNumber, LocationDescription=:LocationDescription, LocationBrandTheme=:LocationBrandTheme, LocationCtaTheme=:LocationCtaTheme, LocationHasMyCare=:LocationHasMyCare, LocationHasMyServices=:LocationHasMyServices, LocationHasMyLiving=:LocationHasMyLiving, LocationHasOwnBrand=:LocationHasOwnBrand, ToolBoxDefaultProfileImage=:ToolBoxDefaultProfileImage, ToolBoxDefaultLogo=:ToolBoxDefaultLogo, ReceptionDescription=:ReceptionDescription, ToolBoxLastUpdateTime=:ToolBoxLastUpdateTime, ToolBoxLastUpdateReceptionistI=:ToolBoxLastUpdateReceptionistI, LocationThemeId=:LocationThemeId, ActiveAppVersionId=:ActiveAppVersionId, PublishedActiveAppVersionId=:PublishedActiveAppVersionId  WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000417)
          ,new CursorDef("T000418", "SAVEPOINT gxupdate;UPDATE Trn_Location SET LocationImage=:LocationImage, LocationImage_GXI=:LocationImage_GXI  WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000418)
          ,new CursorDef("T000419", "SAVEPOINT gxupdate;UPDATE Trn_Location SET ReceptionImage=:ReceptionImage, ReceptionImage_GXI=:ReceptionImage_GXI  WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000419)
          ,new CursorDef("T000420", "SAVEPOINT gxupdate;DELETE FROM Trn_Location  WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000420)
          ,new CursorDef("T000421", "SELECT Trn_ThemeId FROM Trn_AppVersion WHERE AppVersionId = :ActiveAppVersionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000421,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000422", "SELECT Trn_ThemeId FROM Trn_AppVersion WHERE AppVersionId = :PublishedActiveAppVersionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000422,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000423", "SELECT SupplierGenId FROM Trn_SupplierGen WHERE SG_LocationSupplierLocationId = :LocationId AND SG_LocationSupplierOrganisatio = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000423,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000424", "SELECT ResidentPackageId FROM Trn_ResidentPackage WHERE SG_LocationId = :LocationId AND SG_OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000424,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000425", "SELECT AppVersionId FROM Trn_AppVersion WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000425,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000426", "SELECT AgendaCalendarId FROM Trn_AgendaCalendar WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000426,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000427", "SELECT LocationDynamicFormId, OrganisationId, LocationId FROM Trn_LocationDynamicForm WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000427,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000428", "SELECT ProductServiceId, LocationId, OrganisationId FROM Trn_ProductService WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000428,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000429", "SELECT ResidentId, LocationId, OrganisationId FROM Trn_Resident WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000429,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000430", "SELECT ReceptionistId, OrganisationId, LocationId FROM Trn_Receptionist WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000430,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000431", "SELECT LocationId, OrganisationId FROM Trn_Location ORDER BY LocationId, OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000431,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
             ((bool[]) buf[6])[0] = rslt.wasNull(6);
             ((string[]) buf[7])[0] = rslt.getVarchar(7);
             ((string[]) buf[8])[0] = rslt.getVarchar(8);
             ((string[]) buf[9])[0] = rslt.getVarchar(9);
             ((string[]) buf[10])[0] = rslt.getVarchar(10);
             ((string[]) buf[11])[0] = rslt.getVarchar(11);
             ((string[]) buf[12])[0] = rslt.getLongVarchar(12);
             ((string[]) buf[13])[0] = rslt.getLongVarchar(13);
             ((bool[]) buf[14])[0] = rslt.wasNull(13);
             ((string[]) buf[15])[0] = rslt.getLongVarchar(14);
             ((bool[]) buf[16])[0] = rslt.wasNull(14);
             ((bool[]) buf[17])[0] = rslt.getBool(15);
             ((bool[]) buf[18])[0] = rslt.getBool(16);
             ((bool[]) buf[19])[0] = rslt.getBool(17);
             ((bool[]) buf[20])[0] = rslt.getBool(18);
             ((string[]) buf[21])[0] = rslt.getVarchar(19);
             ((bool[]) buf[22])[0] = rslt.wasNull(19);
             ((string[]) buf[23])[0] = rslt.getVarchar(20);
             ((bool[]) buf[24])[0] = rslt.wasNull(20);
             ((string[]) buf[25])[0] = rslt.getMultimediaUri(21);
             ((bool[]) buf[26])[0] = rslt.wasNull(21);
             ((string[]) buf[27])[0] = rslt.getVarchar(22);
             ((bool[]) buf[28])[0] = rslt.wasNull(22);
             ((DateTime[]) buf[29])[0] = rslt.getGXDateTime(23);
             ((bool[]) buf[30])[0] = rslt.wasNull(23);
             ((Guid[]) buf[31])[0] = rslt.getGuid(24);
             ((bool[]) buf[32])[0] = rslt.wasNull(24);
             ((Guid[]) buf[33])[0] = rslt.getGuid(25);
             ((Guid[]) buf[34])[0] = rslt.getGuid(26);
             ((Guid[]) buf[35])[0] = rslt.getGuid(27);
             ((bool[]) buf[36])[0] = rslt.wasNull(27);
             ((Guid[]) buf[37])[0] = rslt.getGuid(28);
             ((bool[]) buf[38])[0] = rslt.wasNull(28);
             ((Guid[]) buf[39])[0] = rslt.getGuid(29);
             ((bool[]) buf[40])[0] = rslt.wasNull(29);
             ((string[]) buf[41])[0] = rslt.getMultimediaFile(30, rslt.getVarchar(6));
             ((bool[]) buf[42])[0] = rslt.wasNull(30);
             ((string[]) buf[43])[0] = rslt.getMultimediaFile(31, rslt.getVarchar(21));
             ((bool[]) buf[44])[0] = rslt.wasNull(31);
             return;
          case 1 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
             ((bool[]) buf[6])[0] = rslt.wasNull(6);
             ((string[]) buf[7])[0] = rslt.getVarchar(7);
             ((string[]) buf[8])[0] = rslt.getVarchar(8);
             ((string[]) buf[9])[0] = rslt.getVarchar(9);
             ((string[]) buf[10])[0] = rslt.getVarchar(10);
             ((string[]) buf[11])[0] = rslt.getVarchar(11);
             ((string[]) buf[12])[0] = rslt.getLongVarchar(12);
             ((string[]) buf[13])[0] = rslt.getLongVarchar(13);
             ((bool[]) buf[14])[0] = rslt.wasNull(13);
             ((string[]) buf[15])[0] = rslt.getLongVarchar(14);
             ((bool[]) buf[16])[0] = rslt.wasNull(14);
             ((bool[]) buf[17])[0] = rslt.getBool(15);
             ((bool[]) buf[18])[0] = rslt.getBool(16);
             ((bool[]) buf[19])[0] = rslt.getBool(17);
             ((bool[]) buf[20])[0] = rslt.getBool(18);
             ((string[]) buf[21])[0] = rslt.getVarchar(19);
             ((bool[]) buf[22])[0] = rslt.wasNull(19);
             ((string[]) buf[23])[0] = rslt.getVarchar(20);
             ((bool[]) buf[24])[0] = rslt.wasNull(20);
             ((string[]) buf[25])[0] = rslt.getMultimediaUri(21);
             ((bool[]) buf[26])[0] = rslt.wasNull(21);
             ((string[]) buf[27])[0] = rslt.getVarchar(22);
             ((bool[]) buf[28])[0] = rslt.wasNull(22);
             ((DateTime[]) buf[29])[0] = rslt.getGXDateTime(23);
             ((bool[]) buf[30])[0] = rslt.wasNull(23);
             ((Guid[]) buf[31])[0] = rslt.getGuid(24);
             ((bool[]) buf[32])[0] = rslt.wasNull(24);
             ((Guid[]) buf[33])[0] = rslt.getGuid(25);
             ((Guid[]) buf[34])[0] = rslt.getGuid(26);
             ((Guid[]) buf[35])[0] = rslt.getGuid(27);
             ((bool[]) buf[36])[0] = rslt.wasNull(27);
             ((Guid[]) buf[37])[0] = rslt.getGuid(28);
             ((bool[]) buf[38])[0] = rslt.wasNull(28);
             ((Guid[]) buf[39])[0] = rslt.getGuid(29);
             ((bool[]) buf[40])[0] = rslt.wasNull(29);
             ((string[]) buf[41])[0] = rslt.getMultimediaFile(30, rslt.getVarchar(6));
             ((bool[]) buf[42])[0] = rslt.wasNull(30);
             ((string[]) buf[43])[0] = rslt.getMultimediaFile(31, rslt.getVarchar(21));
             ((bool[]) buf[44])[0] = rslt.wasNull(31);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 6 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
             ((bool[]) buf[6])[0] = rslt.wasNull(6);
             ((string[]) buf[7])[0] = rslt.getVarchar(7);
             ((string[]) buf[8])[0] = rslt.getVarchar(8);
             ((string[]) buf[9])[0] = rslt.getVarchar(9);
             ((string[]) buf[10])[0] = rslt.getVarchar(10);
             ((string[]) buf[11])[0] = rslt.getVarchar(11);
             ((string[]) buf[12])[0] = rslt.getLongVarchar(12);
             ((string[]) buf[13])[0] = rslt.getLongVarchar(13);
             ((bool[]) buf[14])[0] = rslt.wasNull(13);
             ((string[]) buf[15])[0] = rslt.getLongVarchar(14);
             ((bool[]) buf[16])[0] = rslt.wasNull(14);
             ((bool[]) buf[17])[0] = rslt.getBool(15);
             ((bool[]) buf[18])[0] = rslt.getBool(16);
             ((bool[]) buf[19])[0] = rslt.getBool(17);
             ((bool[]) buf[20])[0] = rslt.getBool(18);
             ((string[]) buf[21])[0] = rslt.getVarchar(19);
             ((bool[]) buf[22])[0] = rslt.wasNull(19);
             ((string[]) buf[23])[0] = rslt.getVarchar(20);
             ((bool[]) buf[24])[0] = rslt.wasNull(20);
             ((string[]) buf[25])[0] = rslt.getMultimediaUri(21);
             ((bool[]) buf[26])[0] = rslt.wasNull(21);
             ((string[]) buf[27])[0] = rslt.getVarchar(22);
             ((bool[]) buf[28])[0] = rslt.wasNull(22);
             ((DateTime[]) buf[29])[0] = rslt.getGXDateTime(23);
             ((bool[]) buf[30])[0] = rslt.wasNull(23);
             ((Guid[]) buf[31])[0] = rslt.getGuid(24);
             ((bool[]) buf[32])[0] = rslt.wasNull(24);
             ((Guid[]) buf[33])[0] = rslt.getGuid(25);
             ((Guid[]) buf[34])[0] = rslt.getGuid(26);
             ((Guid[]) buf[35])[0] = rslt.getGuid(27);
             ((bool[]) buf[36])[0] = rslt.wasNull(27);
             ((Guid[]) buf[37])[0] = rslt.getGuid(28);
             ((bool[]) buf[38])[0] = rslt.wasNull(28);
             ((Guid[]) buf[39])[0] = rslt.getGuid(29);
             ((bool[]) buf[40])[0] = rslt.wasNull(29);
             ((string[]) buf[41])[0] = rslt.getMultimediaFile(30, rslt.getVarchar(6));
             ((bool[]) buf[42])[0] = rslt.wasNull(30);
             ((string[]) buf[43])[0] = rslt.getMultimediaFile(31, rslt.getVarchar(21));
             ((bool[]) buf[44])[0] = rslt.wasNull(31);
             return;
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 9 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 10 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 11 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 12 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 13 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 19 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 20 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 21 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 22 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 23 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 24 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 25 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 26 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 27 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 28 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 29 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
    }
 }

}

}
