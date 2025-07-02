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
   public class trn_agendaeventgroup : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A268AgendaCalendarId = StringUtil.StrToGuid( GetPar( "AgendaCalendarId"));
            AssignAttri("", false, "A268AgendaCalendarId", A268AgendaCalendarId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A268AgendaCalendarId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A62ResidentId = StringUtil.StrToGuid( GetPar( "ResidentId"));
            AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
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
            gxLoad_6( A62ResidentId, A29LocationId, A11OrganisationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A96ResidentTypeId = StringUtil.StrToGuid( GetPar( "ResidentTypeId"));
            n96ResidentTypeId = false;
            AssignAttri("", false, "A96ResidentTypeId", A96ResidentTypeId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A96ResidentTypeId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A98MedicalIndicationId = StringUtil.StrToGuid( GetPar( "MedicalIndicationId"));
            n98MedicalIndicationId = false;
            AssignAttri("", false, "A98MedicalIndicationId", A98MedicalIndicationId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A98MedicalIndicationId) ;
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
         Form.Meta.addItem("description", context.GetMessage( "Trn_Agenda Event Group", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAgendaCalendarId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_agendaeventgroup( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_agendaeventgroup( IGxContext context )
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
         chkAgendaEventGroupRSVP = new GXCheckbox();
         cmbResidentSalutation = new GXCombobox();
         cmbResidentGender = new GXCombobox();
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
            return "trn_agendaeventgroup_Execute" ;
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
         A442AgendaEventGroupRSVP = StringUtil.StrToBool( StringUtil.BoolToStr( A442AgendaEventGroupRSVP));
         AssignAttri("", false, "A442AgendaEventGroupRSVP", A442AgendaEventGroupRSVP);
         if ( cmbResidentSalutation.ItemCount > 0 )
         {
            A72ResidentSalutation = cmbResidentSalutation.getValidValue(A72ResidentSalutation);
            AssignAttri("", false, "A72ResidentSalutation", A72ResidentSalutation);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbResidentSalutation.CurrentValue = StringUtil.RTrim( A72ResidentSalutation);
            AssignProp("", false, cmbResidentSalutation_Internalname, "Values", cmbResidentSalutation.ToJavascriptSource(), true);
         }
         if ( cmbResidentGender.ItemCount > 0 )
         {
            A68ResidentGender = cmbResidentGender.getValidValue(A68ResidentGender);
            AssignAttri("", false, "A68ResidentGender", A68ResidentGender);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbResidentGender.CurrentValue = StringUtil.RTrim( A68ResidentGender);
            AssignProp("", false, cmbResidentGender_Internalname, "Values", cmbResidentGender.ToJavascriptSource(), true);
         }
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Trn_Agenda Event Group", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Trn_AgendaEventGroup.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AgendaEventGroup.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AgendaEventGroup.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AgendaEventGroup.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AgendaEventGroup.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Trn_AgendaEventGroup.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAgendaCalendarId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAgendaCalendarId_Internalname, context.GetMessage( "Agenda Calendar Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAgendaCalendarId_Internalname, A268AgendaCalendarId.ToString(), A268AgendaCalendarId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAgendaCalendarId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAgendaCalendarId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_AgendaEventGroup.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentId_Internalname, context.GetMessage( "Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentId_Internalname, A62ResidentId.ToString(), A62ResidentId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_AgendaEventGroup.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkAgendaEventGroupRSVP_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkAgendaEventGroupRSVP_Internalname, context.GetMessage( "Group RSVP", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkAgendaEventGroupRSVP_Internalname, StringUtil.BoolToStr( A442AgendaEventGroupRSVP), "", context.GetMessage( "Group RSVP", ""), 1, chkAgendaEventGroupRSVP.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(44, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,44);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationId_Internalname, context.GetMessage( "Location Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationId_Internalname, A29LocationId.ToString(), A29LocationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_AgendaEventGroup.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOrganisationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOrganisationId_Internalname, context.GetMessage( "Organisation Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationId_Internalname, A11OrganisationId.ToString(), A11OrganisationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrganisationId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_AgendaEventGroup.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbResidentSalutation_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbResidentSalutation_Internalname, context.GetMessage( "Resident Salutation", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbResidentSalutation, cmbResidentSalutation_Internalname, StringUtil.RTrim( A72ResidentSalutation), 1, cmbResidentSalutation_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbResidentSalutation.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "", true, 0, "HLP_Trn_AgendaEventGroup.htm");
         cmbResidentSalutation.CurrentValue = StringUtil.RTrim( A72ResidentSalutation);
         AssignProp("", false, cmbResidentSalutation_Internalname, "Values", (string)(cmbResidentSalutation.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentBsnNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentBsnNumber_Internalname, context.GetMessage( "Resident Bsn Number", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentBsnNumber_Internalname, A63ResidentBsnNumber, StringUtil.RTrim( context.localUtil.Format( A63ResidentBsnNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentBsnNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentBsnNumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "BsnNumber", "start", true, "", "HLP_Trn_AgendaEventGroup.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentGivenName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentGivenName_Internalname, context.GetMessage( "Resident Given Name", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentGivenName_Internalname, A64ResidentGivenName, StringUtil.RTrim( context.localUtil.Format( A64ResidentGivenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentGivenName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentGivenName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_AgendaEventGroup.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentLastName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentLastName_Internalname, context.GetMessage( "Resident Last Name", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentLastName_Internalname, A65ResidentLastName, StringUtil.RTrim( context.localUtil.Format( A65ResidentLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentLastName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentLastName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_AgendaEventGroup.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentInitials_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentInitials_Internalname, context.GetMessage( "Resident Initials", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentInitials_Internalname, StringUtil.RTrim( A66ResidentInitials), StringUtil.RTrim( context.localUtil.Format( A66ResidentInitials, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentInitials_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentInitials_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_AgendaEventGroup.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentEmail_Internalname, context.GetMessage( "Resident Email", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentEmail_Internalname, A67ResidentEmail, StringUtil.RTrim( context.localUtil.Format( A67ResidentEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A67ResidentEmail, "", "", "", edtResidentEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Trn_AgendaEventGroup.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbResidentGender_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbResidentGender_Internalname, context.GetMessage( "Resident Gender", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbResidentGender, cmbResidentGender_Internalname, StringUtil.RTrim( A68ResidentGender), 1, cmbResidentGender_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbResidentGender.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "", true, 0, "HLP_Trn_AgendaEventGroup.htm");
         cmbResidentGender.CurrentValue = StringUtil.RTrim( A68ResidentGender);
         AssignProp("", false, cmbResidentGender_Internalname, "Values", (string)(cmbResidentGender.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentCountry_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentCountry_Internalname, context.GetMessage( "Resident Country", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentCountry_Internalname, A312ResidentCountry, StringUtil.RTrim( context.localUtil.Format( A312ResidentCountry, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentCountry_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentCountry_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_AgendaEventGroup.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentCity_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentCity_Internalname, context.GetMessage( "Resident City", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentCity_Internalname, A313ResidentCity, StringUtil.RTrim( context.localUtil.Format( A313ResidentCity, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentCity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentCity_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_AgendaEventGroup.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentZipCode_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentZipCode_Internalname, context.GetMessage( "Resident Zip Code", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentZipCode_Internalname, A314ResidentZipCode, StringUtil.RTrim( context.localUtil.Format( A314ResidentZipCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentZipCode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentZipCode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_AgendaEventGroup.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentAddressLine1_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentAddressLine1_Internalname, context.GetMessage( "Resident Address Line1", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentAddressLine1_Internalname, A315ResidentAddressLine1, StringUtil.RTrim( context.localUtil.Format( A315ResidentAddressLine1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentAddressLine1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentAddressLine1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_AgendaEventGroup.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentAddressLine2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentAddressLine2_Internalname, context.GetMessage( "Resident Address Line2", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentAddressLine2_Internalname, A316ResidentAddressLine2, StringUtil.RTrim( context.localUtil.Format( A316ResidentAddressLine2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,114);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentAddressLine2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentAddressLine2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_AgendaEventGroup.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentPhone_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentPhone_Internalname, context.GetMessage( "Resident Phone", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A70ResidentPhone);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentPhone_Internalname, StringUtil.RTrim( A70ResidentPhone), StringUtil.RTrim( context.localUtil.Format( A70ResidentPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,119);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtResidentPhone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Trn_AgendaEventGroup.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentBirthDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentBirthDate_Internalname, context.GetMessage( "Resident Birth Date", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtResidentBirthDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtResidentBirthDate_Internalname, context.localUtil.Format(A73ResidentBirthDate, "99/99/9999"), context.localUtil.Format( A73ResidentBirthDate, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,124);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentBirthDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentBirthDate_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_AgendaEventGroup.htm");
         GxWebStd.gx_bitmap( context, edtResidentBirthDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtResidentBirthDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_AgendaEventGroup.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentGUID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentGUID_Internalname, context.GetMessage( "Resident GUID", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentGUID_Internalname, A71ResidentGUID, StringUtil.RTrim( context.localUtil.Format( A71ResidentGUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,129);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentGUID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentGUID_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_Trn_AgendaEventGroup.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentTypeId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentTypeId_Internalname, context.GetMessage( "Resident Type Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentTypeId_Internalname, A96ResidentTypeId.ToString(), A96ResidentTypeId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,134);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentTypeId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentTypeId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_AgendaEventGroup.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentTypeName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentTypeName_Internalname, context.GetMessage( "Resident Type Name", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentTypeName_Internalname, A97ResidentTypeName, StringUtil.RTrim( context.localUtil.Format( A97ResidentTypeName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,139);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentTypeName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentTypeName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_AgendaEventGroup.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMedicalIndicationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMedicalIndicationId_Internalname, context.GetMessage( "Medical Indication Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMedicalIndicationId_Internalname, A98MedicalIndicationId.ToString(), A98MedicalIndicationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,144);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMedicalIndicationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMedicalIndicationId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_AgendaEventGroup.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMedicalIndicationName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMedicalIndicationName_Internalname, context.GetMessage( "Medical Indication Name", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 149,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMedicalIndicationName_Internalname, A99MedicalIndicationName, StringUtil.RTrim( context.localUtil.Format( A99MedicalIndicationName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,149);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMedicalIndicationName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMedicalIndicationName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_AgendaEventGroup.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentPhoneCode_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentPhoneCode_Internalname, context.GetMessage( "Resident Phone Code", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 154,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentPhoneCode_Internalname, A347ResidentPhoneCode, StringUtil.RTrim( context.localUtil.Format( A347ResidentPhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,154);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentPhoneCode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentPhoneCode_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_AgendaEventGroup.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentPhoneNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentPhoneNumber_Internalname, context.GetMessage( "Resident Phone Number", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 159,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentPhoneNumber_Internalname, A348ResidentPhoneNumber, StringUtil.RTrim( context.localUtil.Format( A348ResidentPhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,159);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentPhoneNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentPhoneNumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_AgendaEventGroup.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 164,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AgendaEventGroup.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 166,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AgendaEventGroup.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 168,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AgendaEventGroup.htm");
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
            Z268AgendaCalendarId = StringUtil.StrToGuid( cgiGet( "Z268AgendaCalendarId"));
            Z62ResidentId = StringUtil.StrToGuid( cgiGet( "Z62ResidentId"));
            Z442AgendaEventGroupRSVP = StringUtil.StrToBool( cgiGet( "Z442AgendaEventGroupRSVP"));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( StringUtil.StrCmp(cgiGet( edtAgendaCalendarId_Internalname), "") == 0 )
            {
               A268AgendaCalendarId = Guid.Empty;
               AssignAttri("", false, "A268AgendaCalendarId", A268AgendaCalendarId.ToString());
            }
            else
            {
               try
               {
                  A268AgendaCalendarId = StringUtil.StrToGuid( cgiGet( edtAgendaCalendarId_Internalname));
                  AssignAttri("", false, "A268AgendaCalendarId", A268AgendaCalendarId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "AGENDACALENDARID");
                  AnyError = 1;
                  GX_FocusControl = edtAgendaCalendarId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            if ( StringUtil.StrCmp(cgiGet( edtResidentId_Internalname), "") == 0 )
            {
               A62ResidentId = Guid.Empty;
               AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
            }
            else
            {
               try
               {
                  A62ResidentId = StringUtil.StrToGuid( cgiGet( edtResidentId_Internalname));
                  AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "RESIDENTID");
                  AnyError = 1;
                  GX_FocusControl = edtResidentId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            A442AgendaEventGroupRSVP = StringUtil.StrToBool( cgiGet( chkAgendaEventGroupRSVP_Internalname));
            AssignAttri("", false, "A442AgendaEventGroupRSVP", A442AgendaEventGroupRSVP);
            A29LocationId = StringUtil.StrToGuid( cgiGet( edtLocationId_Internalname));
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            cmbResidentSalutation.CurrentValue = cgiGet( cmbResidentSalutation_Internalname);
            A72ResidentSalutation = cgiGet( cmbResidentSalutation_Internalname);
            AssignAttri("", false, "A72ResidentSalutation", A72ResidentSalutation);
            A63ResidentBsnNumber = cgiGet( edtResidentBsnNumber_Internalname);
            AssignAttri("", false, "A63ResidentBsnNumber", A63ResidentBsnNumber);
            A64ResidentGivenName = cgiGet( edtResidentGivenName_Internalname);
            AssignAttri("", false, "A64ResidentGivenName", A64ResidentGivenName);
            A65ResidentLastName = cgiGet( edtResidentLastName_Internalname);
            AssignAttri("", false, "A65ResidentLastName", A65ResidentLastName);
            A66ResidentInitials = cgiGet( edtResidentInitials_Internalname);
            AssignAttri("", false, "A66ResidentInitials", A66ResidentInitials);
            A67ResidentEmail = cgiGet( edtResidentEmail_Internalname);
            AssignAttri("", false, "A67ResidentEmail", A67ResidentEmail);
            cmbResidentGender.CurrentValue = cgiGet( cmbResidentGender_Internalname);
            A68ResidentGender = cgiGet( cmbResidentGender_Internalname);
            AssignAttri("", false, "A68ResidentGender", A68ResidentGender);
            A312ResidentCountry = cgiGet( edtResidentCountry_Internalname);
            AssignAttri("", false, "A312ResidentCountry", A312ResidentCountry);
            A313ResidentCity = cgiGet( edtResidentCity_Internalname);
            AssignAttri("", false, "A313ResidentCity", A313ResidentCity);
            A314ResidentZipCode = cgiGet( edtResidentZipCode_Internalname);
            AssignAttri("", false, "A314ResidentZipCode", A314ResidentZipCode);
            A315ResidentAddressLine1 = cgiGet( edtResidentAddressLine1_Internalname);
            AssignAttri("", false, "A315ResidentAddressLine1", A315ResidentAddressLine1);
            A316ResidentAddressLine2 = cgiGet( edtResidentAddressLine2_Internalname);
            AssignAttri("", false, "A316ResidentAddressLine2", A316ResidentAddressLine2);
            A70ResidentPhone = cgiGet( edtResidentPhone_Internalname);
            AssignAttri("", false, "A70ResidentPhone", A70ResidentPhone);
            A73ResidentBirthDate = context.localUtil.CToD( cgiGet( edtResidentBirthDate_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            AssignAttri("", false, "A73ResidentBirthDate", context.localUtil.Format(A73ResidentBirthDate, "99/99/9999"));
            A71ResidentGUID = cgiGet( edtResidentGUID_Internalname);
            AssignAttri("", false, "A71ResidentGUID", A71ResidentGUID);
            A96ResidentTypeId = StringUtil.StrToGuid( cgiGet( edtResidentTypeId_Internalname));
            n96ResidentTypeId = false;
            AssignAttri("", false, "A96ResidentTypeId", A96ResidentTypeId.ToString());
            A97ResidentTypeName = cgiGet( edtResidentTypeName_Internalname);
            AssignAttri("", false, "A97ResidentTypeName", A97ResidentTypeName);
            A98MedicalIndicationId = StringUtil.StrToGuid( cgiGet( edtMedicalIndicationId_Internalname));
            n98MedicalIndicationId = false;
            AssignAttri("", false, "A98MedicalIndicationId", A98MedicalIndicationId.ToString());
            A99MedicalIndicationName = cgiGet( edtMedicalIndicationName_Internalname);
            AssignAttri("", false, "A99MedicalIndicationName", A99MedicalIndicationName);
            A347ResidentPhoneCode = cgiGet( edtResidentPhoneCode_Internalname);
            AssignAttri("", false, "A347ResidentPhoneCode", A347ResidentPhoneCode);
            A348ResidentPhoneNumber = cgiGet( edtResidentPhoneNumber_Internalname);
            AssignAttri("", false, "A348ResidentPhoneNumber", A348ResidentPhoneNumber);
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
               A268AgendaCalendarId = StringUtil.StrToGuid( GetPar( "AgendaCalendarId"));
               AssignAttri("", false, "A268AgendaCalendarId", A268AgendaCalendarId.ToString());
               A62ResidentId = StringUtil.StrToGuid( GetPar( "ResidentId"));
               AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
               getEqualNoModal( ) ;
               if ( IsIns( )  && (Guid.Empty==A62ResidentId) && ( Gx_BScreen == 0 ) )
               {
                  A62ResidentId = Guid.NewGuid( );
                  AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
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
               InitAll1C83( ) ;
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
         DisableAttributes1C83( ) ;
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

      protected void ResetCaption1C0( )
      {
      }

      protected void ZM1C83( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z442AgendaEventGroupRSVP = T001C3_A442AgendaEventGroupRSVP[0];
            }
            else
            {
               Z442AgendaEventGroupRSVP = A442AgendaEventGroupRSVP;
            }
         }
         if ( GX_JID == -4 )
         {
            Z442AgendaEventGroupRSVP = A442AgendaEventGroupRSVP;
            Z268AgendaCalendarId = A268AgendaCalendarId;
            Z62ResidentId = A62ResidentId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            Z72ResidentSalutation = A72ResidentSalutation;
            Z63ResidentBsnNumber = A63ResidentBsnNumber;
            Z64ResidentGivenName = A64ResidentGivenName;
            Z65ResidentLastName = A65ResidentLastName;
            Z66ResidentInitials = A66ResidentInitials;
            Z67ResidentEmail = A67ResidentEmail;
            Z68ResidentGender = A68ResidentGender;
            Z312ResidentCountry = A312ResidentCountry;
            Z313ResidentCity = A313ResidentCity;
            Z314ResidentZipCode = A314ResidentZipCode;
            Z315ResidentAddressLine1 = A315ResidentAddressLine1;
            Z316ResidentAddressLine2 = A316ResidentAddressLine2;
            Z70ResidentPhone = A70ResidentPhone;
            Z73ResidentBirthDate = A73ResidentBirthDate;
            Z71ResidentGUID = A71ResidentGUID;
            Z347ResidentPhoneCode = A347ResidentPhoneCode;
            Z348ResidentPhoneNumber = A348ResidentPhoneNumber;
            Z96ResidentTypeId = A96ResidentTypeId;
            Z98MedicalIndicationId = A98MedicalIndicationId;
            Z97ResidentTypeName = A97ResidentTypeName;
            Z99MedicalIndicationName = A99MedicalIndicationName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A62ResidentId) && ( Gx_BScreen == 0 ) )
         {
            A62ResidentId = Guid.NewGuid( );
            AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
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

      protected void Load1C83( )
      {
         /* Using cursor T001C8 */
         pr_default.execute(6, new Object[] {A268AgendaCalendarId, A62ResidentId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound83 = 1;
            A442AgendaEventGroupRSVP = T001C8_A442AgendaEventGroupRSVP[0];
            AssignAttri("", false, "A442AgendaEventGroupRSVP", A442AgendaEventGroupRSVP);
            A72ResidentSalutation = T001C8_A72ResidentSalutation[0];
            AssignAttri("", false, "A72ResidentSalutation", A72ResidentSalutation);
            A63ResidentBsnNumber = T001C8_A63ResidentBsnNumber[0];
            AssignAttri("", false, "A63ResidentBsnNumber", A63ResidentBsnNumber);
            A64ResidentGivenName = T001C8_A64ResidentGivenName[0];
            AssignAttri("", false, "A64ResidentGivenName", A64ResidentGivenName);
            A65ResidentLastName = T001C8_A65ResidentLastName[0];
            AssignAttri("", false, "A65ResidentLastName", A65ResidentLastName);
            A66ResidentInitials = T001C8_A66ResidentInitials[0];
            AssignAttri("", false, "A66ResidentInitials", A66ResidentInitials);
            A67ResidentEmail = T001C8_A67ResidentEmail[0];
            AssignAttri("", false, "A67ResidentEmail", A67ResidentEmail);
            A68ResidentGender = T001C8_A68ResidentGender[0];
            AssignAttri("", false, "A68ResidentGender", A68ResidentGender);
            A312ResidentCountry = T001C8_A312ResidentCountry[0];
            AssignAttri("", false, "A312ResidentCountry", A312ResidentCountry);
            A313ResidentCity = T001C8_A313ResidentCity[0];
            AssignAttri("", false, "A313ResidentCity", A313ResidentCity);
            A314ResidentZipCode = T001C8_A314ResidentZipCode[0];
            AssignAttri("", false, "A314ResidentZipCode", A314ResidentZipCode);
            A315ResidentAddressLine1 = T001C8_A315ResidentAddressLine1[0];
            AssignAttri("", false, "A315ResidentAddressLine1", A315ResidentAddressLine1);
            A316ResidentAddressLine2 = T001C8_A316ResidentAddressLine2[0];
            AssignAttri("", false, "A316ResidentAddressLine2", A316ResidentAddressLine2);
            A70ResidentPhone = T001C8_A70ResidentPhone[0];
            AssignAttri("", false, "A70ResidentPhone", A70ResidentPhone);
            A73ResidentBirthDate = T001C8_A73ResidentBirthDate[0];
            AssignAttri("", false, "A73ResidentBirthDate", context.localUtil.Format(A73ResidentBirthDate, "99/99/9999"));
            A71ResidentGUID = T001C8_A71ResidentGUID[0];
            AssignAttri("", false, "A71ResidentGUID", A71ResidentGUID);
            A97ResidentTypeName = T001C8_A97ResidentTypeName[0];
            AssignAttri("", false, "A97ResidentTypeName", A97ResidentTypeName);
            A99MedicalIndicationName = T001C8_A99MedicalIndicationName[0];
            AssignAttri("", false, "A99MedicalIndicationName", A99MedicalIndicationName);
            A347ResidentPhoneCode = T001C8_A347ResidentPhoneCode[0];
            AssignAttri("", false, "A347ResidentPhoneCode", A347ResidentPhoneCode);
            A348ResidentPhoneNumber = T001C8_A348ResidentPhoneNumber[0];
            AssignAttri("", false, "A348ResidentPhoneNumber", A348ResidentPhoneNumber);
            A29LocationId = T001C8_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = T001C8_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A96ResidentTypeId = T001C8_A96ResidentTypeId[0];
            n96ResidentTypeId = T001C8_n96ResidentTypeId[0];
            AssignAttri("", false, "A96ResidentTypeId", A96ResidentTypeId.ToString());
            A98MedicalIndicationId = T001C8_A98MedicalIndicationId[0];
            n98MedicalIndicationId = T001C8_n98MedicalIndicationId[0];
            AssignAttri("", false, "A98MedicalIndicationId", A98MedicalIndicationId.ToString());
            ZM1C83( -4) ;
         }
         pr_default.close(6);
         OnLoadActions1C83( ) ;
      }

      protected void OnLoadActions1C83( )
      {
      }

      protected void CheckExtendedTable1C83( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T001C4 */
         pr_default.execute(2, new Object[] {A268AgendaCalendarId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Agenda/Calendar", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "AGENDACALENDARID");
            AnyError = 1;
            GX_FocusControl = edtAgendaCalendarId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A29LocationId = T001C4_A29LocationId[0];
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         A11OrganisationId = T001C4_A11OrganisationId[0];
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         pr_default.close(2);
         /* Using cursor T001C5 */
         pr_default.execute(3, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Resident", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtResidentId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A72ResidentSalutation = T001C5_A72ResidentSalutation[0];
         AssignAttri("", false, "A72ResidentSalutation", A72ResidentSalutation);
         A63ResidentBsnNumber = T001C5_A63ResidentBsnNumber[0];
         AssignAttri("", false, "A63ResidentBsnNumber", A63ResidentBsnNumber);
         A64ResidentGivenName = T001C5_A64ResidentGivenName[0];
         AssignAttri("", false, "A64ResidentGivenName", A64ResidentGivenName);
         A65ResidentLastName = T001C5_A65ResidentLastName[0];
         AssignAttri("", false, "A65ResidentLastName", A65ResidentLastName);
         A66ResidentInitials = T001C5_A66ResidentInitials[0];
         AssignAttri("", false, "A66ResidentInitials", A66ResidentInitials);
         A67ResidentEmail = T001C5_A67ResidentEmail[0];
         AssignAttri("", false, "A67ResidentEmail", A67ResidentEmail);
         A68ResidentGender = T001C5_A68ResidentGender[0];
         AssignAttri("", false, "A68ResidentGender", A68ResidentGender);
         A312ResidentCountry = T001C5_A312ResidentCountry[0];
         AssignAttri("", false, "A312ResidentCountry", A312ResidentCountry);
         A313ResidentCity = T001C5_A313ResidentCity[0];
         AssignAttri("", false, "A313ResidentCity", A313ResidentCity);
         A314ResidentZipCode = T001C5_A314ResidentZipCode[0];
         AssignAttri("", false, "A314ResidentZipCode", A314ResidentZipCode);
         A315ResidentAddressLine1 = T001C5_A315ResidentAddressLine1[0];
         AssignAttri("", false, "A315ResidentAddressLine1", A315ResidentAddressLine1);
         A316ResidentAddressLine2 = T001C5_A316ResidentAddressLine2[0];
         AssignAttri("", false, "A316ResidentAddressLine2", A316ResidentAddressLine2);
         A70ResidentPhone = T001C5_A70ResidentPhone[0];
         AssignAttri("", false, "A70ResidentPhone", A70ResidentPhone);
         A73ResidentBirthDate = T001C5_A73ResidentBirthDate[0];
         AssignAttri("", false, "A73ResidentBirthDate", context.localUtil.Format(A73ResidentBirthDate, "99/99/9999"));
         A71ResidentGUID = T001C5_A71ResidentGUID[0];
         AssignAttri("", false, "A71ResidentGUID", A71ResidentGUID);
         A347ResidentPhoneCode = T001C5_A347ResidentPhoneCode[0];
         AssignAttri("", false, "A347ResidentPhoneCode", A347ResidentPhoneCode);
         A348ResidentPhoneNumber = T001C5_A348ResidentPhoneNumber[0];
         AssignAttri("", false, "A348ResidentPhoneNumber", A348ResidentPhoneNumber);
         A96ResidentTypeId = T001C5_A96ResidentTypeId[0];
         n96ResidentTypeId = T001C5_n96ResidentTypeId[0];
         AssignAttri("", false, "A96ResidentTypeId", A96ResidentTypeId.ToString());
         A98MedicalIndicationId = T001C5_A98MedicalIndicationId[0];
         n98MedicalIndicationId = T001C5_n98MedicalIndicationId[0];
         AssignAttri("", false, "A98MedicalIndicationId", A98MedicalIndicationId.ToString());
         pr_default.close(3);
         /* Using cursor T001C6 */
         pr_default.execute(4, new Object[] {n96ResidentTypeId, A96ResidentTypeId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (Guid.Empty==A96ResidentTypeId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Resident Types", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RESIDENTTYPEID");
               AnyError = 1;
            }
         }
         A97ResidentTypeName = T001C6_A97ResidentTypeName[0];
         AssignAttri("", false, "A97ResidentTypeName", A97ResidentTypeName);
         pr_default.close(4);
         /* Using cursor T001C7 */
         pr_default.execute(5, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (Guid.Empty==A98MedicalIndicationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Medical Indications", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MEDICALINDICATIONID");
               AnyError = 1;
            }
         }
         A99MedicalIndicationName = T001C7_A99MedicalIndicationName[0];
         AssignAttri("", false, "A99MedicalIndicationName", A99MedicalIndicationName);
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors1C83( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_5( Guid A268AgendaCalendarId )
      {
         /* Using cursor T001C9 */
         pr_default.execute(7, new Object[] {A268AgendaCalendarId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Agenda/Calendar", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "AGENDACALENDARID");
            AnyError = 1;
            GX_FocusControl = edtAgendaCalendarId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A29LocationId = T001C9_A29LocationId[0];
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         A11OrganisationId = T001C9_A11OrganisationId[0];
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A29LocationId.ToString())+"\""+","+"\""+GXUtil.EncodeJSConstant( A11OrganisationId.ToString())+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_6( Guid A62ResidentId ,
                               Guid A29LocationId ,
                               Guid A11OrganisationId )
      {
         /* Using cursor T001C10 */
         pr_default.execute(8, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Resident", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtResidentId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A72ResidentSalutation = T001C10_A72ResidentSalutation[0];
         AssignAttri("", false, "A72ResidentSalutation", A72ResidentSalutation);
         A63ResidentBsnNumber = T001C10_A63ResidentBsnNumber[0];
         AssignAttri("", false, "A63ResidentBsnNumber", A63ResidentBsnNumber);
         A64ResidentGivenName = T001C10_A64ResidentGivenName[0];
         AssignAttri("", false, "A64ResidentGivenName", A64ResidentGivenName);
         A65ResidentLastName = T001C10_A65ResidentLastName[0];
         AssignAttri("", false, "A65ResidentLastName", A65ResidentLastName);
         A66ResidentInitials = T001C10_A66ResidentInitials[0];
         AssignAttri("", false, "A66ResidentInitials", A66ResidentInitials);
         A67ResidentEmail = T001C10_A67ResidentEmail[0];
         AssignAttri("", false, "A67ResidentEmail", A67ResidentEmail);
         A68ResidentGender = T001C10_A68ResidentGender[0];
         AssignAttri("", false, "A68ResidentGender", A68ResidentGender);
         A312ResidentCountry = T001C10_A312ResidentCountry[0];
         AssignAttri("", false, "A312ResidentCountry", A312ResidentCountry);
         A313ResidentCity = T001C10_A313ResidentCity[0];
         AssignAttri("", false, "A313ResidentCity", A313ResidentCity);
         A314ResidentZipCode = T001C10_A314ResidentZipCode[0];
         AssignAttri("", false, "A314ResidentZipCode", A314ResidentZipCode);
         A315ResidentAddressLine1 = T001C10_A315ResidentAddressLine1[0];
         AssignAttri("", false, "A315ResidentAddressLine1", A315ResidentAddressLine1);
         A316ResidentAddressLine2 = T001C10_A316ResidentAddressLine2[0];
         AssignAttri("", false, "A316ResidentAddressLine2", A316ResidentAddressLine2);
         A70ResidentPhone = T001C10_A70ResidentPhone[0];
         AssignAttri("", false, "A70ResidentPhone", A70ResidentPhone);
         A73ResidentBirthDate = T001C10_A73ResidentBirthDate[0];
         AssignAttri("", false, "A73ResidentBirthDate", context.localUtil.Format(A73ResidentBirthDate, "99/99/9999"));
         A71ResidentGUID = T001C10_A71ResidentGUID[0];
         AssignAttri("", false, "A71ResidentGUID", A71ResidentGUID);
         A347ResidentPhoneCode = T001C10_A347ResidentPhoneCode[0];
         AssignAttri("", false, "A347ResidentPhoneCode", A347ResidentPhoneCode);
         A348ResidentPhoneNumber = T001C10_A348ResidentPhoneNumber[0];
         AssignAttri("", false, "A348ResidentPhoneNumber", A348ResidentPhoneNumber);
         A96ResidentTypeId = T001C10_A96ResidentTypeId[0];
         n96ResidentTypeId = T001C10_n96ResidentTypeId[0];
         AssignAttri("", false, "A96ResidentTypeId", A96ResidentTypeId.ToString());
         A98MedicalIndicationId = T001C10_A98MedicalIndicationId[0];
         n98MedicalIndicationId = T001C10_n98MedicalIndicationId[0];
         AssignAttri("", false, "A98MedicalIndicationId", A98MedicalIndicationId.ToString());
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A72ResidentSalutation))+"\""+","+"\""+GXUtil.EncodeJSConstant( A63ResidentBsnNumber)+"\""+","+"\""+GXUtil.EncodeJSConstant( A64ResidentGivenName)+"\""+","+"\""+GXUtil.EncodeJSConstant( A65ResidentLastName)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A66ResidentInitials))+"\""+","+"\""+GXUtil.EncodeJSConstant( A67ResidentEmail)+"\""+","+"\""+GXUtil.EncodeJSConstant( A68ResidentGender)+"\""+","+"\""+GXUtil.EncodeJSConstant( A312ResidentCountry)+"\""+","+"\""+GXUtil.EncodeJSConstant( A313ResidentCity)+"\""+","+"\""+GXUtil.EncodeJSConstant( A314ResidentZipCode)+"\""+","+"\""+GXUtil.EncodeJSConstant( A315ResidentAddressLine1)+"\""+","+"\""+GXUtil.EncodeJSConstant( A316ResidentAddressLine2)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A70ResidentPhone))+"\""+","+"\""+GXUtil.EncodeJSConstant( context.localUtil.Format(A73ResidentBirthDate, "99/99/9999"))+"\""+","+"\""+GXUtil.EncodeJSConstant( A71ResidentGUID)+"\""+","+"\""+GXUtil.EncodeJSConstant( A347ResidentPhoneCode)+"\""+","+"\""+GXUtil.EncodeJSConstant( A348ResidentPhoneNumber)+"\""+","+"\""+GXUtil.EncodeJSConstant( A96ResidentTypeId.ToString())+"\""+","+"\""+GXUtil.EncodeJSConstant( A98MedicalIndicationId.ToString())+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_7( Guid A96ResidentTypeId )
      {
         /* Using cursor T001C11 */
         pr_default.execute(9, new Object[] {n96ResidentTypeId, A96ResidentTypeId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (Guid.Empty==A96ResidentTypeId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Resident Types", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RESIDENTTYPEID");
               AnyError = 1;
            }
         }
         A97ResidentTypeName = T001C11_A97ResidentTypeName[0];
         AssignAttri("", false, "A97ResidentTypeName", A97ResidentTypeName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A97ResidentTypeName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_8( Guid A98MedicalIndicationId )
      {
         /* Using cursor T001C12 */
         pr_default.execute(10, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (Guid.Empty==A98MedicalIndicationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Medical Indications", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MEDICALINDICATIONID");
               AnyError = 1;
            }
         }
         A99MedicalIndicationName = T001C12_A99MedicalIndicationName[0];
         AssignAttri("", false, "A99MedicalIndicationName", A99MedicalIndicationName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A99MedicalIndicationName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void GetKey1C83( )
      {
         /* Using cursor T001C13 */
         pr_default.execute(11, new Object[] {A268AgendaCalendarId, A62ResidentId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound83 = 1;
         }
         else
         {
            RcdFound83 = 0;
         }
         pr_default.close(11);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001C3 */
         pr_default.execute(1, new Object[] {A268AgendaCalendarId, A62ResidentId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1C83( 4) ;
            RcdFound83 = 1;
            A442AgendaEventGroupRSVP = T001C3_A442AgendaEventGroupRSVP[0];
            AssignAttri("", false, "A442AgendaEventGroupRSVP", A442AgendaEventGroupRSVP);
            A268AgendaCalendarId = T001C3_A268AgendaCalendarId[0];
            AssignAttri("", false, "A268AgendaCalendarId", A268AgendaCalendarId.ToString());
            A62ResidentId = T001C3_A62ResidentId[0];
            AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
            Z268AgendaCalendarId = A268AgendaCalendarId;
            Z62ResidentId = A62ResidentId;
            sMode83 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1C83( ) ;
            if ( AnyError == 1 )
            {
               RcdFound83 = 0;
               InitializeNonKey1C83( ) ;
            }
            Gx_mode = sMode83;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound83 = 0;
            InitializeNonKey1C83( ) ;
            sMode83 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode83;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1C83( ) ;
         if ( RcdFound83 == 0 )
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
         RcdFound83 = 0;
         /* Using cursor T001C14 */
         pr_default.execute(12, new Object[] {A268AgendaCalendarId, A62ResidentId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( GuidUtil.Compare(T001C14_A268AgendaCalendarId[0], A268AgendaCalendarId, 0) < 0 ) || ( T001C14_A268AgendaCalendarId[0] == A268AgendaCalendarId ) && ( GuidUtil.Compare(T001C14_A62ResidentId[0], A62ResidentId, 0) < 0 ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( GuidUtil.Compare(T001C14_A268AgendaCalendarId[0], A268AgendaCalendarId, 0) > 0 ) || ( T001C14_A268AgendaCalendarId[0] == A268AgendaCalendarId ) && ( GuidUtil.Compare(T001C14_A62ResidentId[0], A62ResidentId, 0) > 0 ) ) )
            {
               A268AgendaCalendarId = T001C14_A268AgendaCalendarId[0];
               AssignAttri("", false, "A268AgendaCalendarId", A268AgendaCalendarId.ToString());
               A62ResidentId = T001C14_A62ResidentId[0];
               AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
               RcdFound83 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void move_previous( )
      {
         RcdFound83 = 0;
         /* Using cursor T001C15 */
         pr_default.execute(13, new Object[] {A268AgendaCalendarId, A62ResidentId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( GuidUtil.Compare(T001C15_A268AgendaCalendarId[0], A268AgendaCalendarId, 0) > 0 ) || ( T001C15_A268AgendaCalendarId[0] == A268AgendaCalendarId ) && ( GuidUtil.Compare(T001C15_A62ResidentId[0], A62ResidentId, 0) > 0 ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( GuidUtil.Compare(T001C15_A268AgendaCalendarId[0], A268AgendaCalendarId, 0) < 0 ) || ( T001C15_A268AgendaCalendarId[0] == A268AgendaCalendarId ) && ( GuidUtil.Compare(T001C15_A62ResidentId[0], A62ResidentId, 0) < 0 ) ) )
            {
               A268AgendaCalendarId = T001C15_A268AgendaCalendarId[0];
               AssignAttri("", false, "A268AgendaCalendarId", A268AgendaCalendarId.ToString());
               A62ResidentId = T001C15_A62ResidentId[0];
               AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
               RcdFound83 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1C83( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAgendaCalendarId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1C83( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound83 == 1 )
            {
               if ( ( A268AgendaCalendarId != Z268AgendaCalendarId ) || ( A62ResidentId != Z62ResidentId ) )
               {
                  A268AgendaCalendarId = Z268AgendaCalendarId;
                  AssignAttri("", false, "A268AgendaCalendarId", A268AgendaCalendarId.ToString());
                  A62ResidentId = Z62ResidentId;
                  AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "AGENDACALENDARID");
                  AnyError = 1;
                  GX_FocusControl = edtAgendaCalendarId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAgendaCalendarId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1C83( ) ;
                  GX_FocusControl = edtAgendaCalendarId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A268AgendaCalendarId != Z268AgendaCalendarId ) || ( A62ResidentId != Z62ResidentId ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtAgendaCalendarId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1C83( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "AGENDACALENDARID");
                     AnyError = 1;
                     GX_FocusControl = edtAgendaCalendarId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtAgendaCalendarId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1C83( ) ;
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
         if ( ( A268AgendaCalendarId != Z268AgendaCalendarId ) || ( A62ResidentId != Z62ResidentId ) )
         {
            A268AgendaCalendarId = Z268AgendaCalendarId;
            AssignAttri("", false, "A268AgendaCalendarId", A268AgendaCalendarId.ToString());
            A62ResidentId = Z62ResidentId;
            AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "AGENDACALENDARID");
            AnyError = 1;
            GX_FocusControl = edtAgendaCalendarId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAgendaCalendarId_Internalname;
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
         if ( RcdFound83 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "AGENDACALENDARID");
            AnyError = 1;
            GX_FocusControl = edtAgendaCalendarId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = chkAgendaEventGroupRSVP_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1C83( ) ;
         if ( RcdFound83 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = chkAgendaEventGroupRSVP_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1C83( ) ;
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
         if ( RcdFound83 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = chkAgendaEventGroupRSVP_Internalname;
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
         if ( RcdFound83 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = chkAgendaEventGroupRSVP_Internalname;
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
         ScanStart1C83( ) ;
         if ( RcdFound83 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound83 != 0 )
            {
               ScanNext1C83( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = chkAgendaEventGroupRSVP_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1C83( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1C83( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001C2 */
            pr_default.execute(0, new Object[] {A268AgendaCalendarId, A62ResidentId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AgendaEventGroup"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z442AgendaEventGroupRSVP != T001C2_A442AgendaEventGroupRSVP[0] ) )
            {
               if ( Z442AgendaEventGroupRSVP != T001C2_A442AgendaEventGroupRSVP[0] )
               {
                  GXUtil.WriteLog("trn_agendaeventgroup:[seudo value changed for attri]"+"AgendaEventGroupRSVP");
                  GXUtil.WriteLogRaw("Old: ",Z442AgendaEventGroupRSVP);
                  GXUtil.WriteLogRaw("Current: ",T001C2_A442AgendaEventGroupRSVP[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_AgendaEventGroup"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1C83( )
      {
         if ( ! IsAuthorized("trn_agendaeventgroup_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1C83( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1C83( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1C83( 0) ;
            CheckOptimisticConcurrency1C83( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1C83( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1C83( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001C16 */
                     pr_default.execute(14, new Object[] {A442AgendaEventGroupRSVP, A268AgendaCalendarId, A62ResidentId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AgendaEventGroup");
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
                           ResetCaption1C0( ) ;
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
               Load1C83( ) ;
            }
            EndLevel1C83( ) ;
         }
         CloseExtendedTableCursors1C83( ) ;
      }

      protected void Update1C83( )
      {
         if ( ! IsAuthorized("trn_agendaeventgroup_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1C83( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1C83( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1C83( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1C83( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1C83( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001C17 */
                     pr_default.execute(15, new Object[] {A442AgendaEventGroupRSVP, A268AgendaCalendarId, A62ResidentId});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AgendaEventGroup");
                     if ( (pr_default.getStatus(15) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AgendaEventGroup"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1C83( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1C0( ) ;
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
            EndLevel1C83( ) ;
         }
         CloseExtendedTableCursors1C83( ) ;
      }

      protected void DeferredUpdate1C83( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_agendaeventgroup_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1C83( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1C83( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1C83( ) ;
            AfterConfirm1C83( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1C83( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001C18 */
                  pr_default.execute(16, new Object[] {A268AgendaCalendarId, A62ResidentId});
                  pr_default.close(16);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_AgendaEventGroup");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound83 == 0 )
                        {
                           InitAll1C83( ) ;
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
                        ResetCaption1C0( ) ;
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
         sMode83 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1C83( ) ;
         Gx_mode = sMode83;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1C83( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001C19 */
            pr_default.execute(17, new Object[] {A268AgendaCalendarId});
            A29LocationId = T001C19_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = T001C19_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            pr_default.close(17);
            /* Using cursor T001C20 */
            pr_default.execute(18, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
            A72ResidentSalutation = T001C20_A72ResidentSalutation[0];
            AssignAttri("", false, "A72ResidentSalutation", A72ResidentSalutation);
            A63ResidentBsnNumber = T001C20_A63ResidentBsnNumber[0];
            AssignAttri("", false, "A63ResidentBsnNumber", A63ResidentBsnNumber);
            A64ResidentGivenName = T001C20_A64ResidentGivenName[0];
            AssignAttri("", false, "A64ResidentGivenName", A64ResidentGivenName);
            A65ResidentLastName = T001C20_A65ResidentLastName[0];
            AssignAttri("", false, "A65ResidentLastName", A65ResidentLastName);
            A66ResidentInitials = T001C20_A66ResidentInitials[0];
            AssignAttri("", false, "A66ResidentInitials", A66ResidentInitials);
            A67ResidentEmail = T001C20_A67ResidentEmail[0];
            AssignAttri("", false, "A67ResidentEmail", A67ResidentEmail);
            A68ResidentGender = T001C20_A68ResidentGender[0];
            AssignAttri("", false, "A68ResidentGender", A68ResidentGender);
            A312ResidentCountry = T001C20_A312ResidentCountry[0];
            AssignAttri("", false, "A312ResidentCountry", A312ResidentCountry);
            A313ResidentCity = T001C20_A313ResidentCity[0];
            AssignAttri("", false, "A313ResidentCity", A313ResidentCity);
            A314ResidentZipCode = T001C20_A314ResidentZipCode[0];
            AssignAttri("", false, "A314ResidentZipCode", A314ResidentZipCode);
            A315ResidentAddressLine1 = T001C20_A315ResidentAddressLine1[0];
            AssignAttri("", false, "A315ResidentAddressLine1", A315ResidentAddressLine1);
            A316ResidentAddressLine2 = T001C20_A316ResidentAddressLine2[0];
            AssignAttri("", false, "A316ResidentAddressLine2", A316ResidentAddressLine2);
            A70ResidentPhone = T001C20_A70ResidentPhone[0];
            AssignAttri("", false, "A70ResidentPhone", A70ResidentPhone);
            A73ResidentBirthDate = T001C20_A73ResidentBirthDate[0];
            AssignAttri("", false, "A73ResidentBirthDate", context.localUtil.Format(A73ResidentBirthDate, "99/99/9999"));
            A71ResidentGUID = T001C20_A71ResidentGUID[0];
            AssignAttri("", false, "A71ResidentGUID", A71ResidentGUID);
            A347ResidentPhoneCode = T001C20_A347ResidentPhoneCode[0];
            AssignAttri("", false, "A347ResidentPhoneCode", A347ResidentPhoneCode);
            A348ResidentPhoneNumber = T001C20_A348ResidentPhoneNumber[0];
            AssignAttri("", false, "A348ResidentPhoneNumber", A348ResidentPhoneNumber);
            A96ResidentTypeId = T001C20_A96ResidentTypeId[0];
            n96ResidentTypeId = T001C20_n96ResidentTypeId[0];
            AssignAttri("", false, "A96ResidentTypeId", A96ResidentTypeId.ToString());
            A98MedicalIndicationId = T001C20_A98MedicalIndicationId[0];
            n98MedicalIndicationId = T001C20_n98MedicalIndicationId[0];
            AssignAttri("", false, "A98MedicalIndicationId", A98MedicalIndicationId.ToString());
            pr_default.close(18);
            /* Using cursor T001C21 */
            pr_default.execute(19, new Object[] {n96ResidentTypeId, A96ResidentTypeId});
            A97ResidentTypeName = T001C21_A97ResidentTypeName[0];
            AssignAttri("", false, "A97ResidentTypeName", A97ResidentTypeName);
            pr_default.close(19);
            /* Using cursor T001C22 */
            pr_default.execute(20, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
            A99MedicalIndicationName = T001C22_A99MedicalIndicationName[0];
            AssignAttri("", false, "A99MedicalIndicationName", A99MedicalIndicationName);
            pr_default.close(20);
         }
      }

      protected void EndLevel1C83( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1C83( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_agendaeventgroup",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1C0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_agendaeventgroup",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1C83( )
      {
         /* Using cursor T001C23 */
         pr_default.execute(21);
         RcdFound83 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound83 = 1;
            A268AgendaCalendarId = T001C23_A268AgendaCalendarId[0];
            AssignAttri("", false, "A268AgendaCalendarId", A268AgendaCalendarId.ToString());
            A62ResidentId = T001C23_A62ResidentId[0];
            AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1C83( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound83 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound83 = 1;
            A268AgendaCalendarId = T001C23_A268AgendaCalendarId[0];
            AssignAttri("", false, "A268AgendaCalendarId", A268AgendaCalendarId.ToString());
            A62ResidentId = T001C23_A62ResidentId[0];
            AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
         }
      }

      protected void ScanEnd1C83( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm1C83( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1C83( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1C83( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1C83( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1C83( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1C83( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1C83( )
      {
         edtAgendaCalendarId_Enabled = 0;
         AssignProp("", false, edtAgendaCalendarId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAgendaCalendarId_Enabled), 5, 0), true);
         edtResidentId_Enabled = 0;
         AssignProp("", false, edtResidentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentId_Enabled), 5, 0), true);
         chkAgendaEventGroupRSVP.Enabled = 0;
         AssignProp("", false, chkAgendaEventGroupRSVP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkAgendaEventGroupRSVP.Enabled), 5, 0), true);
         edtLocationId_Enabled = 0;
         AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         edtOrganisationId_Enabled = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         cmbResidentSalutation.Enabled = 0;
         AssignProp("", false, cmbResidentSalutation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbResidentSalutation.Enabled), 5, 0), true);
         edtResidentBsnNumber_Enabled = 0;
         AssignProp("", false, edtResidentBsnNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentBsnNumber_Enabled), 5, 0), true);
         edtResidentGivenName_Enabled = 0;
         AssignProp("", false, edtResidentGivenName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentGivenName_Enabled), 5, 0), true);
         edtResidentLastName_Enabled = 0;
         AssignProp("", false, edtResidentLastName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentLastName_Enabled), 5, 0), true);
         edtResidentInitials_Enabled = 0;
         AssignProp("", false, edtResidentInitials_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentInitials_Enabled), 5, 0), true);
         edtResidentEmail_Enabled = 0;
         AssignProp("", false, edtResidentEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentEmail_Enabled), 5, 0), true);
         cmbResidentGender.Enabled = 0;
         AssignProp("", false, cmbResidentGender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbResidentGender.Enabled), 5, 0), true);
         edtResidentCountry_Enabled = 0;
         AssignProp("", false, edtResidentCountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentCountry_Enabled), 5, 0), true);
         edtResidentCity_Enabled = 0;
         AssignProp("", false, edtResidentCity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentCity_Enabled), 5, 0), true);
         edtResidentZipCode_Enabled = 0;
         AssignProp("", false, edtResidentZipCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentZipCode_Enabled), 5, 0), true);
         edtResidentAddressLine1_Enabled = 0;
         AssignProp("", false, edtResidentAddressLine1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentAddressLine1_Enabled), 5, 0), true);
         edtResidentAddressLine2_Enabled = 0;
         AssignProp("", false, edtResidentAddressLine2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentAddressLine2_Enabled), 5, 0), true);
         edtResidentPhone_Enabled = 0;
         AssignProp("", false, edtResidentPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentPhone_Enabled), 5, 0), true);
         edtResidentBirthDate_Enabled = 0;
         AssignProp("", false, edtResidentBirthDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentBirthDate_Enabled), 5, 0), true);
         edtResidentGUID_Enabled = 0;
         AssignProp("", false, edtResidentGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentGUID_Enabled), 5, 0), true);
         edtResidentTypeId_Enabled = 0;
         AssignProp("", false, edtResidentTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentTypeId_Enabled), 5, 0), true);
         edtResidentTypeName_Enabled = 0;
         AssignProp("", false, edtResidentTypeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentTypeName_Enabled), 5, 0), true);
         edtMedicalIndicationId_Enabled = 0;
         AssignProp("", false, edtMedicalIndicationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMedicalIndicationId_Enabled), 5, 0), true);
         edtMedicalIndicationName_Enabled = 0;
         AssignProp("", false, edtMedicalIndicationName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMedicalIndicationName_Enabled), 5, 0), true);
         edtResidentPhoneCode_Enabled = 0;
         AssignProp("", false, edtResidentPhoneCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentPhoneCode_Enabled), 5, 0), true);
         edtResidentPhoneNumber_Enabled = 0;
         AssignProp("", false, edtResidentPhoneNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentPhoneNumber_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1C83( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1C0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_agendaeventgroup.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z268AgendaCalendarId", Z268AgendaCalendarId.ToString());
         GxWebStd.gx_hidden_field( context, "Z62ResidentId", Z62ResidentId.ToString());
         GxWebStd.gx_boolean_hidden_field( context, "Z442AgendaEventGroupRSVP", Z442AgendaEventGroupRSVP);
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
         return formatLink("trn_agendaeventgroup.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_AgendaEventGroup" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Agenda Event Group", "") ;
      }

      protected void InitializeNonKey1C83( )
      {
         A442AgendaEventGroupRSVP = false;
         AssignAttri("", false, "A442AgendaEventGroupRSVP", A442AgendaEventGroupRSVP);
         A29LocationId = Guid.Empty;
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         A11OrganisationId = Guid.Empty;
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         A72ResidentSalutation = "";
         AssignAttri("", false, "A72ResidentSalutation", A72ResidentSalutation);
         A63ResidentBsnNumber = "";
         AssignAttri("", false, "A63ResidentBsnNumber", A63ResidentBsnNumber);
         A64ResidentGivenName = "";
         AssignAttri("", false, "A64ResidentGivenName", A64ResidentGivenName);
         A65ResidentLastName = "";
         AssignAttri("", false, "A65ResidentLastName", A65ResidentLastName);
         A66ResidentInitials = "";
         AssignAttri("", false, "A66ResidentInitials", A66ResidentInitials);
         A67ResidentEmail = "";
         AssignAttri("", false, "A67ResidentEmail", A67ResidentEmail);
         A68ResidentGender = "";
         AssignAttri("", false, "A68ResidentGender", A68ResidentGender);
         A312ResidentCountry = "";
         AssignAttri("", false, "A312ResidentCountry", A312ResidentCountry);
         A313ResidentCity = "";
         AssignAttri("", false, "A313ResidentCity", A313ResidentCity);
         A314ResidentZipCode = "";
         AssignAttri("", false, "A314ResidentZipCode", A314ResidentZipCode);
         A315ResidentAddressLine1 = "";
         AssignAttri("", false, "A315ResidentAddressLine1", A315ResidentAddressLine1);
         A316ResidentAddressLine2 = "";
         AssignAttri("", false, "A316ResidentAddressLine2", A316ResidentAddressLine2);
         A70ResidentPhone = "";
         AssignAttri("", false, "A70ResidentPhone", A70ResidentPhone);
         A73ResidentBirthDate = DateTime.MinValue;
         AssignAttri("", false, "A73ResidentBirthDate", context.localUtil.Format(A73ResidentBirthDate, "99/99/9999"));
         A71ResidentGUID = "";
         AssignAttri("", false, "A71ResidentGUID", A71ResidentGUID);
         A96ResidentTypeId = Guid.Empty;
         n96ResidentTypeId = false;
         AssignAttri("", false, "A96ResidentTypeId", A96ResidentTypeId.ToString());
         A97ResidentTypeName = "";
         AssignAttri("", false, "A97ResidentTypeName", A97ResidentTypeName);
         A98MedicalIndicationId = Guid.Empty;
         n98MedicalIndicationId = false;
         AssignAttri("", false, "A98MedicalIndicationId", A98MedicalIndicationId.ToString());
         A99MedicalIndicationName = "";
         AssignAttri("", false, "A99MedicalIndicationName", A99MedicalIndicationName);
         A347ResidentPhoneCode = "";
         AssignAttri("", false, "A347ResidentPhoneCode", A347ResidentPhoneCode);
         A348ResidentPhoneNumber = "";
         AssignAttri("", false, "A348ResidentPhoneNumber", A348ResidentPhoneNumber);
         Z442AgendaEventGroupRSVP = false;
      }

      protected void InitAll1C83( )
      {
         A268AgendaCalendarId = Guid.Empty;
         AssignAttri("", false, "A268AgendaCalendarId", A268AgendaCalendarId.ToString());
         A62ResidentId = Guid.NewGuid( );
         AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
         InitializeNonKey1C83( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20257212512756", true, true);
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
         context.AddJavascriptSource("trn_agendaeventgroup.js", "?20257212512757", false, true);
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
         edtAgendaCalendarId_Internalname = "AGENDACALENDARID";
         edtResidentId_Internalname = "RESIDENTID";
         chkAgendaEventGroupRSVP_Internalname = "AGENDAEVENTGROUPRSVP";
         edtLocationId_Internalname = "LOCATIONID";
         edtOrganisationId_Internalname = "ORGANISATIONID";
         cmbResidentSalutation_Internalname = "RESIDENTSALUTATION";
         edtResidentBsnNumber_Internalname = "RESIDENTBSNNUMBER";
         edtResidentGivenName_Internalname = "RESIDENTGIVENNAME";
         edtResidentLastName_Internalname = "RESIDENTLASTNAME";
         edtResidentInitials_Internalname = "RESIDENTINITIALS";
         edtResidentEmail_Internalname = "RESIDENTEMAIL";
         cmbResidentGender_Internalname = "RESIDENTGENDER";
         edtResidentCountry_Internalname = "RESIDENTCOUNTRY";
         edtResidentCity_Internalname = "RESIDENTCITY";
         edtResidentZipCode_Internalname = "RESIDENTZIPCODE";
         edtResidentAddressLine1_Internalname = "RESIDENTADDRESSLINE1";
         edtResidentAddressLine2_Internalname = "RESIDENTADDRESSLINE2";
         edtResidentPhone_Internalname = "RESIDENTPHONE";
         edtResidentBirthDate_Internalname = "RESIDENTBIRTHDATE";
         edtResidentGUID_Internalname = "RESIDENTGUID";
         edtResidentTypeId_Internalname = "RESIDENTTYPEID";
         edtResidentTypeName_Internalname = "RESIDENTTYPENAME";
         edtMedicalIndicationId_Internalname = "MEDICALINDICATIONID";
         edtMedicalIndicationName_Internalname = "MEDICALINDICATIONNAME";
         edtResidentPhoneCode_Internalname = "RESIDENTPHONECODE";
         edtResidentPhoneNumber_Internalname = "RESIDENTPHONENUMBER";
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
         Form.Caption = context.GetMessage( "Trn_Agenda Event Group", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtResidentPhoneNumber_Jsonclick = "";
         edtResidentPhoneNumber_Enabled = 0;
         edtResidentPhoneCode_Jsonclick = "";
         edtResidentPhoneCode_Enabled = 0;
         edtMedicalIndicationName_Jsonclick = "";
         edtMedicalIndicationName_Enabled = 0;
         edtMedicalIndicationId_Jsonclick = "";
         edtMedicalIndicationId_Enabled = 0;
         edtResidentTypeName_Jsonclick = "";
         edtResidentTypeName_Enabled = 0;
         edtResidentTypeId_Jsonclick = "";
         edtResidentTypeId_Enabled = 0;
         edtResidentGUID_Jsonclick = "";
         edtResidentGUID_Enabled = 0;
         edtResidentBirthDate_Jsonclick = "";
         edtResidentBirthDate_Enabled = 0;
         edtResidentPhone_Jsonclick = "";
         edtResidentPhone_Enabled = 0;
         edtResidentAddressLine2_Jsonclick = "";
         edtResidentAddressLine2_Enabled = 0;
         edtResidentAddressLine1_Jsonclick = "";
         edtResidentAddressLine1_Enabled = 0;
         edtResidentZipCode_Jsonclick = "";
         edtResidentZipCode_Enabled = 0;
         edtResidentCity_Jsonclick = "";
         edtResidentCity_Enabled = 0;
         edtResidentCountry_Jsonclick = "";
         edtResidentCountry_Enabled = 0;
         cmbResidentGender_Jsonclick = "";
         cmbResidentGender.Enabled = 0;
         edtResidentEmail_Jsonclick = "";
         edtResidentEmail_Enabled = 0;
         edtResidentInitials_Jsonclick = "";
         edtResidentInitials_Enabled = 0;
         edtResidentLastName_Jsonclick = "";
         edtResidentLastName_Enabled = 0;
         edtResidentGivenName_Jsonclick = "";
         edtResidentGivenName_Enabled = 0;
         edtResidentBsnNumber_Jsonclick = "";
         edtResidentBsnNumber_Enabled = 0;
         cmbResidentSalutation_Jsonclick = "";
         cmbResidentSalutation.Enabled = 0;
         edtOrganisationId_Jsonclick = "";
         edtOrganisationId_Enabled = 0;
         edtLocationId_Jsonclick = "";
         edtLocationId_Enabled = 0;
         chkAgendaEventGroupRSVP.Enabled = 1;
         edtResidentId_Jsonclick = "";
         edtResidentId_Enabled = 1;
         edtAgendaCalendarId_Jsonclick = "";
         edtAgendaCalendarId_Enabled = 1;
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

      protected void init_web_controls( )
      {
         chkAgendaEventGroupRSVP.Name = "AGENDAEVENTGROUPRSVP";
         chkAgendaEventGroupRSVP.WebTags = "";
         chkAgendaEventGroupRSVP.Caption = context.GetMessage( "Group RSVP", "");
         AssignProp("", false, chkAgendaEventGroupRSVP_Internalname, "TitleCaption", chkAgendaEventGroupRSVP.Caption, true);
         chkAgendaEventGroupRSVP.CheckedValue = "false";
         A442AgendaEventGroupRSVP = StringUtil.StrToBool( StringUtil.BoolToStr( A442AgendaEventGroupRSVP));
         AssignAttri("", false, "A442AgendaEventGroupRSVP", A442AgendaEventGroupRSVP);
         cmbResidentSalutation.Name = "RESIDENTSALUTATION";
         cmbResidentSalutation.WebTags = "";
         cmbResidentSalutation.addItem("Mr", context.GetMessage( "Mr", ""), 0);
         cmbResidentSalutation.addItem("Mrs", context.GetMessage( "Mrs", ""), 0);
         cmbResidentSalutation.addItem("Dr", context.GetMessage( "Dr", ""), 0);
         cmbResidentSalutation.addItem("Miss", context.GetMessage( "Miss", ""), 0);
         if ( cmbResidentSalutation.ItemCount > 0 )
         {
            A72ResidentSalutation = cmbResidentSalutation.getValidValue(A72ResidentSalutation);
            AssignAttri("", false, "A72ResidentSalutation", A72ResidentSalutation);
         }
         cmbResidentGender.Name = "RESIDENTGENDER";
         cmbResidentGender.WebTags = "";
         cmbResidentGender.addItem("Male", context.GetMessage( "Male", ""), 0);
         cmbResidentGender.addItem("Female", context.GetMessage( "Female", ""), 0);
         cmbResidentGender.addItem("Other", context.GetMessage( "Other", ""), 0);
         if ( cmbResidentGender.ItemCount > 0 )
         {
            A68ResidentGender = cmbResidentGender.getValidValue(A68ResidentGender);
            AssignAttri("", false, "A68ResidentGender", A68ResidentGender);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         /* Using cursor T001C19 */
         pr_default.execute(17, new Object[] {A268AgendaCalendarId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Agenda/Calendar", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "AGENDACALENDARID");
            AnyError = 1;
            GX_FocusControl = edtAgendaCalendarId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A29LocationId = T001C19_A29LocationId[0];
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         A11OrganisationId = T001C19_A11OrganisationId[0];
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         pr_default.close(17);
         /* Using cursor T001C20 */
         pr_default.execute(18, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Resident", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtResidentId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A72ResidentSalutation = T001C20_A72ResidentSalutation[0];
         AssignAttri("", false, "A72ResidentSalutation", A72ResidentSalutation);
         A63ResidentBsnNumber = T001C20_A63ResidentBsnNumber[0];
         AssignAttri("", false, "A63ResidentBsnNumber", A63ResidentBsnNumber);
         A64ResidentGivenName = T001C20_A64ResidentGivenName[0];
         AssignAttri("", false, "A64ResidentGivenName", A64ResidentGivenName);
         A65ResidentLastName = T001C20_A65ResidentLastName[0];
         AssignAttri("", false, "A65ResidentLastName", A65ResidentLastName);
         A66ResidentInitials = T001C20_A66ResidentInitials[0];
         AssignAttri("", false, "A66ResidentInitials", A66ResidentInitials);
         A67ResidentEmail = T001C20_A67ResidentEmail[0];
         AssignAttri("", false, "A67ResidentEmail", A67ResidentEmail);
         A68ResidentGender = T001C20_A68ResidentGender[0];
         AssignAttri("", false, "A68ResidentGender", A68ResidentGender);
         A312ResidentCountry = T001C20_A312ResidentCountry[0];
         AssignAttri("", false, "A312ResidentCountry", A312ResidentCountry);
         A313ResidentCity = T001C20_A313ResidentCity[0];
         AssignAttri("", false, "A313ResidentCity", A313ResidentCity);
         A314ResidentZipCode = T001C20_A314ResidentZipCode[0];
         AssignAttri("", false, "A314ResidentZipCode", A314ResidentZipCode);
         A315ResidentAddressLine1 = T001C20_A315ResidentAddressLine1[0];
         AssignAttri("", false, "A315ResidentAddressLine1", A315ResidentAddressLine1);
         A316ResidentAddressLine2 = T001C20_A316ResidentAddressLine2[0];
         AssignAttri("", false, "A316ResidentAddressLine2", A316ResidentAddressLine2);
         A70ResidentPhone = T001C20_A70ResidentPhone[0];
         AssignAttri("", false, "A70ResidentPhone", A70ResidentPhone);
         A73ResidentBirthDate = T001C20_A73ResidentBirthDate[0];
         AssignAttri("", false, "A73ResidentBirthDate", context.localUtil.Format(A73ResidentBirthDate, "99/99/9999"));
         A71ResidentGUID = T001C20_A71ResidentGUID[0];
         AssignAttri("", false, "A71ResidentGUID", A71ResidentGUID);
         A347ResidentPhoneCode = T001C20_A347ResidentPhoneCode[0];
         AssignAttri("", false, "A347ResidentPhoneCode", A347ResidentPhoneCode);
         A348ResidentPhoneNumber = T001C20_A348ResidentPhoneNumber[0];
         AssignAttri("", false, "A348ResidentPhoneNumber", A348ResidentPhoneNumber);
         A96ResidentTypeId = T001C20_A96ResidentTypeId[0];
         n96ResidentTypeId = T001C20_n96ResidentTypeId[0];
         AssignAttri("", false, "A96ResidentTypeId", A96ResidentTypeId.ToString());
         A98MedicalIndicationId = T001C20_A98MedicalIndicationId[0];
         n98MedicalIndicationId = T001C20_n98MedicalIndicationId[0];
         AssignAttri("", false, "A98MedicalIndicationId", A98MedicalIndicationId.ToString());
         pr_default.close(18);
         /* Using cursor T001C21 */
         pr_default.execute(19, new Object[] {n96ResidentTypeId, A96ResidentTypeId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            if ( ! ( (Guid.Empty==A96ResidentTypeId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Resident Types", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RESIDENTTYPEID");
               AnyError = 1;
            }
         }
         A97ResidentTypeName = T001C21_A97ResidentTypeName[0];
         AssignAttri("", false, "A97ResidentTypeName", A97ResidentTypeName);
         pr_default.close(19);
         /* Using cursor T001C22 */
         pr_default.execute(20, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            if ( ! ( (Guid.Empty==A98MedicalIndicationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Medical Indications", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MEDICALINDICATIONID");
               AnyError = 1;
            }
         }
         A99MedicalIndicationName = T001C22_A99MedicalIndicationName[0];
         AssignAttri("", false, "A99MedicalIndicationName", A99MedicalIndicationName);
         pr_default.close(20);
         GX_FocusControl = chkAgendaEventGroupRSVP_Internalname;
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

      public void Valid_Agendacalendarid( )
      {
         /* Using cursor T001C19 */
         pr_default.execute(17, new Object[] {A268AgendaCalendarId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Agenda/Calendar", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "AGENDACALENDARID");
            AnyError = 1;
            GX_FocusControl = edtAgendaCalendarId_Internalname;
         }
         A29LocationId = T001C19_A29LocationId[0];
         A11OrganisationId = T001C19_A11OrganisationId[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
      }

      public void Valid_Residentid( )
      {
         A68ResidentGender = cmbResidentGender.CurrentValue;
         cmbResidentGender.CurrentValue = A68ResidentGender;
         A72ResidentSalutation = cmbResidentSalutation.CurrentValue;
         cmbResidentSalutation.CurrentValue = A72ResidentSalutation;
         n96ResidentTypeId = false;
         n98MedicalIndicationId = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T001C20 */
         pr_default.execute(18, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Resident", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtResidentId_Internalname;
         }
         A72ResidentSalutation = T001C20_A72ResidentSalutation[0];
         cmbResidentSalutation.CurrentValue = A72ResidentSalutation;
         A63ResidentBsnNumber = T001C20_A63ResidentBsnNumber[0];
         A64ResidentGivenName = T001C20_A64ResidentGivenName[0];
         A65ResidentLastName = T001C20_A65ResidentLastName[0];
         A66ResidentInitials = T001C20_A66ResidentInitials[0];
         A67ResidentEmail = T001C20_A67ResidentEmail[0];
         A68ResidentGender = T001C20_A68ResidentGender[0];
         cmbResidentGender.CurrentValue = A68ResidentGender;
         A312ResidentCountry = T001C20_A312ResidentCountry[0];
         A313ResidentCity = T001C20_A313ResidentCity[0];
         A314ResidentZipCode = T001C20_A314ResidentZipCode[0];
         A315ResidentAddressLine1 = T001C20_A315ResidentAddressLine1[0];
         A316ResidentAddressLine2 = T001C20_A316ResidentAddressLine2[0];
         A70ResidentPhone = T001C20_A70ResidentPhone[0];
         A73ResidentBirthDate = T001C20_A73ResidentBirthDate[0];
         A71ResidentGUID = T001C20_A71ResidentGUID[0];
         A347ResidentPhoneCode = T001C20_A347ResidentPhoneCode[0];
         A348ResidentPhoneNumber = T001C20_A348ResidentPhoneNumber[0];
         A96ResidentTypeId = T001C20_A96ResidentTypeId[0];
         n96ResidentTypeId = T001C20_n96ResidentTypeId[0];
         A98MedicalIndicationId = T001C20_A98MedicalIndicationId[0];
         n98MedicalIndicationId = T001C20_n98MedicalIndicationId[0];
         pr_default.close(18);
         /* Using cursor T001C21 */
         pr_default.execute(19, new Object[] {n96ResidentTypeId, A96ResidentTypeId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            if ( ! ( (Guid.Empty==A96ResidentTypeId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Resident Types", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RESIDENTTYPEID");
               AnyError = 1;
            }
         }
         A97ResidentTypeName = T001C21_A97ResidentTypeName[0];
         pr_default.close(19);
         /* Using cursor T001C22 */
         pr_default.execute(20, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            if ( ! ( (Guid.Empty==A98MedicalIndicationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Medical Indications", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MEDICALINDICATIONID");
               AnyError = 1;
            }
         }
         A99MedicalIndicationName = T001C22_A99MedicalIndicationName[0];
         pr_default.close(20);
         dynload_actions( ) ;
         A442AgendaEventGroupRSVP = StringUtil.StrToBool( StringUtil.BoolToStr( A442AgendaEventGroupRSVP));
         if ( cmbResidentSalutation.ItemCount > 0 )
         {
            A72ResidentSalutation = cmbResidentSalutation.getValidValue(A72ResidentSalutation);
            cmbResidentSalutation.CurrentValue = A72ResidentSalutation;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbResidentSalutation.CurrentValue = StringUtil.RTrim( A72ResidentSalutation);
         }
         if ( cmbResidentGender.ItemCount > 0 )
         {
            A68ResidentGender = cmbResidentGender.getValidValue(A68ResidentGender);
            cmbResidentGender.CurrentValue = A68ResidentGender;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbResidentGender.CurrentValue = StringUtil.RTrim( A68ResidentGender);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A442AgendaEventGroupRSVP", A442AgendaEventGroupRSVP);
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         AssignAttri("", false, "A72ResidentSalutation", StringUtil.RTrim( A72ResidentSalutation));
         cmbResidentSalutation.CurrentValue = StringUtil.RTrim( A72ResidentSalutation);
         AssignProp("", false, cmbResidentSalutation_Internalname, "Values", cmbResidentSalutation.ToJavascriptSource(), true);
         AssignAttri("", false, "A63ResidentBsnNumber", A63ResidentBsnNumber);
         AssignAttri("", false, "A64ResidentGivenName", A64ResidentGivenName);
         AssignAttri("", false, "A65ResidentLastName", A65ResidentLastName);
         AssignAttri("", false, "A66ResidentInitials", StringUtil.RTrim( A66ResidentInitials));
         AssignAttri("", false, "A67ResidentEmail", A67ResidentEmail);
         AssignAttri("", false, "A68ResidentGender", A68ResidentGender);
         cmbResidentGender.CurrentValue = StringUtil.RTrim( A68ResidentGender);
         AssignProp("", false, cmbResidentGender_Internalname, "Values", cmbResidentGender.ToJavascriptSource(), true);
         AssignAttri("", false, "A312ResidentCountry", A312ResidentCountry);
         AssignAttri("", false, "A313ResidentCity", A313ResidentCity);
         AssignAttri("", false, "A314ResidentZipCode", A314ResidentZipCode);
         AssignAttri("", false, "A315ResidentAddressLine1", A315ResidentAddressLine1);
         AssignAttri("", false, "A316ResidentAddressLine2", A316ResidentAddressLine2);
         AssignAttri("", false, "A70ResidentPhone", StringUtil.RTrim( A70ResidentPhone));
         AssignAttri("", false, "A73ResidentBirthDate", context.localUtil.Format(A73ResidentBirthDate, "99/99/9999"));
         AssignAttri("", false, "A71ResidentGUID", A71ResidentGUID);
         AssignAttri("", false, "A347ResidentPhoneCode", A347ResidentPhoneCode);
         AssignAttri("", false, "A348ResidentPhoneNumber", A348ResidentPhoneNumber);
         AssignAttri("", false, "A96ResidentTypeId", A96ResidentTypeId.ToString());
         AssignAttri("", false, "A98MedicalIndicationId", A98MedicalIndicationId.ToString());
         AssignAttri("", false, "A97ResidentTypeName", A97ResidentTypeName);
         AssignAttri("", false, "A99MedicalIndicationName", A99MedicalIndicationName);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z268AgendaCalendarId", Z268AgendaCalendarId.ToString());
         GxWebStd.gx_hidden_field( context, "Z62ResidentId", Z62ResidentId.ToString());
         GxWebStd.gx_hidden_field( context, "Z442AgendaEventGroupRSVP", StringUtil.BoolToStr( Z442AgendaEventGroupRSVP));
         GxWebStd.gx_hidden_field( context, "Z29LocationId", Z29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z11OrganisationId", Z11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z72ResidentSalutation", StringUtil.RTrim( Z72ResidentSalutation));
         GxWebStd.gx_hidden_field( context, "Z63ResidentBsnNumber", Z63ResidentBsnNumber);
         GxWebStd.gx_hidden_field( context, "Z64ResidentGivenName", Z64ResidentGivenName);
         GxWebStd.gx_hidden_field( context, "Z65ResidentLastName", Z65ResidentLastName);
         GxWebStd.gx_hidden_field( context, "Z66ResidentInitials", StringUtil.RTrim( Z66ResidentInitials));
         GxWebStd.gx_hidden_field( context, "Z67ResidentEmail", Z67ResidentEmail);
         GxWebStd.gx_hidden_field( context, "Z68ResidentGender", Z68ResidentGender);
         GxWebStd.gx_hidden_field( context, "Z312ResidentCountry", Z312ResidentCountry);
         GxWebStd.gx_hidden_field( context, "Z313ResidentCity", Z313ResidentCity);
         GxWebStd.gx_hidden_field( context, "Z314ResidentZipCode", Z314ResidentZipCode);
         GxWebStd.gx_hidden_field( context, "Z315ResidentAddressLine1", Z315ResidentAddressLine1);
         GxWebStd.gx_hidden_field( context, "Z316ResidentAddressLine2", Z316ResidentAddressLine2);
         GxWebStd.gx_hidden_field( context, "Z70ResidentPhone", StringUtil.RTrim( Z70ResidentPhone));
         GxWebStd.gx_hidden_field( context, "Z73ResidentBirthDate", context.localUtil.Format(Z73ResidentBirthDate, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "Z71ResidentGUID", Z71ResidentGUID);
         GxWebStd.gx_hidden_field( context, "Z347ResidentPhoneCode", Z347ResidentPhoneCode);
         GxWebStd.gx_hidden_field( context, "Z348ResidentPhoneNumber", Z348ResidentPhoneNumber);
         GxWebStd.gx_hidden_field( context, "Z96ResidentTypeId", Z96ResidentTypeId.ToString());
         GxWebStd.gx_hidden_field( context, "Z98MedicalIndicationId", Z98MedicalIndicationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z97ResidentTypeName", Z97ResidentTypeName);
         GxWebStd.gx_hidden_field( context, "Z99MedicalIndicationName", Z99MedicalIndicationName);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A442AgendaEventGroupRSVP","fld":"AGENDAEVENTGROUPRSVP"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A442AgendaEventGroupRSVP","fld":"AGENDAEVENTGROUPRSVP"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A442AgendaEventGroupRSVP","fld":"AGENDAEVENTGROUPRSVP"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A442AgendaEventGroupRSVP","fld":"AGENDAEVENTGROUPRSVP"}]}""");
         setEventMetadata("VALID_AGENDACALENDARID","""{"handler":"Valid_Agendacalendarid","iparms":[{"av":"A268AgendaCalendarId","fld":"AGENDACALENDARID"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A442AgendaEventGroupRSVP","fld":"AGENDAEVENTGROUPRSVP"}]""");
         setEventMetadata("VALID_AGENDACALENDARID",""","oparms":[{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A442AgendaEventGroupRSVP","fld":"AGENDAEVENTGROUPRSVP"}]}""");
         setEventMetadata("VALID_RESIDENTID","""{"handler":"Valid_Residentid","iparms":[{"av":"cmbResidentGender"},{"av":"A68ResidentGender","fld":"RESIDENTGENDER"},{"av":"cmbResidentSalutation"},{"av":"A72ResidentSalutation","fld":"RESIDENTSALUTATION"},{"av":"A268AgendaCalendarId","fld":"AGENDACALENDARID"},{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"A442AgendaEventGroupRSVP","fld":"AGENDAEVENTGROUPRSVP"}]""");
         setEventMetadata("VALID_RESIDENTID",""","oparms":[{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"cmbResidentSalutation"},{"av":"A72ResidentSalutation","fld":"RESIDENTSALUTATION"},{"av":"A63ResidentBsnNumber","fld":"RESIDENTBSNNUMBER"},{"av":"A64ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A65ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"},{"av":"A67ResidentEmail","fld":"RESIDENTEMAIL"},{"av":"cmbResidentGender"},{"av":"A68ResidentGender","fld":"RESIDENTGENDER"},{"av":"A312ResidentCountry","fld":"RESIDENTCOUNTRY"},{"av":"A313ResidentCity","fld":"RESIDENTCITY"},{"av":"A314ResidentZipCode","fld":"RESIDENTZIPCODE"},{"av":"A315ResidentAddressLine1","fld":"RESIDENTADDRESSLINE1"},{"av":"A316ResidentAddressLine2","fld":"RESIDENTADDRESSLINE2"},{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"},{"av":"A73ResidentBirthDate","fld":"RESIDENTBIRTHDATE"},{"av":"A71ResidentGUID","fld":"RESIDENTGUID"},{"av":"A347ResidentPhoneCode","fld":"RESIDENTPHONECODE"},{"av":"A348ResidentPhoneNumber","fld":"RESIDENTPHONENUMBER"},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z268AgendaCalendarId"},{"av":"Z62ResidentId"},{"av":"Z442AgendaEventGroupRSVP"},{"av":"Z29LocationId"},{"av":"Z11OrganisationId"},{"av":"Z72ResidentSalutation"},{"av":"Z63ResidentBsnNumber"},{"av":"Z64ResidentGivenName"},{"av":"Z65ResidentLastName"},{"av":"Z66ResidentInitials"},{"av":"Z67ResidentEmail"},{"av":"Z68ResidentGender"},{"av":"Z312ResidentCountry"},{"av":"Z313ResidentCity"},{"av":"Z314ResidentZipCode"},{"av":"Z315ResidentAddressLine1"},{"av":"Z316ResidentAddressLine2"},{"av":"Z70ResidentPhone"},{"av":"Z73ResidentBirthDate"},{"av":"Z71ResidentGUID"},{"av":"Z347ResidentPhoneCode"},{"av":"Z348ResidentPhoneNumber"},{"av":"Z96ResidentTypeId"},{"av":"Z98MedicalIndicationId"},{"av":"Z97ResidentTypeName"},{"av":"Z99MedicalIndicationName"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A442AgendaEventGroupRSVP","fld":"AGENDAEVENTGROUPRSVP"}]}""");
         setEventMetadata("VALID_LOCATIONID","""{"handler":"Valid_Locationid","iparms":[{"av":"A442AgendaEventGroupRSVP","fld":"AGENDAEVENTGROUPRSVP"}]""");
         setEventMetadata("VALID_LOCATIONID",""","oparms":[{"av":"A442AgendaEventGroupRSVP","fld":"AGENDAEVENTGROUPRSVP"}]}""");
         setEventMetadata("VALID_ORGANISATIONID","""{"handler":"Valid_Organisationid","iparms":[{"av":"A442AgendaEventGroupRSVP","fld":"AGENDAEVENTGROUPRSVP"}]""");
         setEventMetadata("VALID_ORGANISATIONID",""","oparms":[{"av":"A442AgendaEventGroupRSVP","fld":"AGENDAEVENTGROUPRSVP"}]}""");
         setEventMetadata("VALID_RESIDENTTYPEID","""{"handler":"Valid_Residenttypeid","iparms":[{"av":"A442AgendaEventGroupRSVP","fld":"AGENDAEVENTGROUPRSVP"}]""");
         setEventMetadata("VALID_RESIDENTTYPEID",""","oparms":[{"av":"A442AgendaEventGroupRSVP","fld":"AGENDAEVENTGROUPRSVP"}]}""");
         setEventMetadata("VALID_MEDICALINDICATIONID","""{"handler":"Valid_Medicalindicationid","iparms":[{"av":"A442AgendaEventGroupRSVP","fld":"AGENDAEVENTGROUPRSVP"}]""");
         setEventMetadata("VALID_MEDICALINDICATIONID",""","oparms":[{"av":"A442AgendaEventGroupRSVP","fld":"AGENDAEVENTGROUPRSVP"}]}""");
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
         pr_default.close(17);
         pr_default.close(18);
         pr_default.close(19);
         pr_default.close(20);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z268AgendaCalendarId = Guid.Empty;
         Z62ResidentId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A268AgendaCalendarId = Guid.Empty;
         A62ResidentId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A96ResidentTypeId = Guid.Empty;
         A98MedicalIndicationId = Guid.Empty;
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A72ResidentSalutation = "";
         A68ResidentGender = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A63ResidentBsnNumber = "";
         A64ResidentGivenName = "";
         A65ResidentLastName = "";
         A66ResidentInitials = "";
         A67ResidentEmail = "";
         A312ResidentCountry = "";
         A313ResidentCity = "";
         A314ResidentZipCode = "";
         A315ResidentAddressLine1 = "";
         A316ResidentAddressLine2 = "";
         gxphoneLink = "";
         A70ResidentPhone = "";
         A73ResidentBirthDate = DateTime.MinValue;
         A71ResidentGUID = "";
         A97ResidentTypeName = "";
         A99MedicalIndicationName = "";
         A347ResidentPhoneCode = "";
         A348ResidentPhoneNumber = "";
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
         Z29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         Z72ResidentSalutation = "";
         Z63ResidentBsnNumber = "";
         Z64ResidentGivenName = "";
         Z65ResidentLastName = "";
         Z66ResidentInitials = "";
         Z67ResidentEmail = "";
         Z68ResidentGender = "";
         Z312ResidentCountry = "";
         Z313ResidentCity = "";
         Z314ResidentZipCode = "";
         Z315ResidentAddressLine1 = "";
         Z316ResidentAddressLine2 = "";
         Z70ResidentPhone = "";
         Z73ResidentBirthDate = DateTime.MinValue;
         Z71ResidentGUID = "";
         Z347ResidentPhoneCode = "";
         Z348ResidentPhoneNumber = "";
         Z96ResidentTypeId = Guid.Empty;
         Z98MedicalIndicationId = Guid.Empty;
         Z97ResidentTypeName = "";
         Z99MedicalIndicationName = "";
         T001C8_A442AgendaEventGroupRSVP = new bool[] {false} ;
         T001C8_A72ResidentSalutation = new string[] {""} ;
         T001C8_A63ResidentBsnNumber = new string[] {""} ;
         T001C8_A64ResidentGivenName = new string[] {""} ;
         T001C8_A65ResidentLastName = new string[] {""} ;
         T001C8_A66ResidentInitials = new string[] {""} ;
         T001C8_A67ResidentEmail = new string[] {""} ;
         T001C8_A68ResidentGender = new string[] {""} ;
         T001C8_A312ResidentCountry = new string[] {""} ;
         T001C8_A313ResidentCity = new string[] {""} ;
         T001C8_A314ResidentZipCode = new string[] {""} ;
         T001C8_A315ResidentAddressLine1 = new string[] {""} ;
         T001C8_A316ResidentAddressLine2 = new string[] {""} ;
         T001C8_A70ResidentPhone = new string[] {""} ;
         T001C8_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         T001C8_A71ResidentGUID = new string[] {""} ;
         T001C8_A97ResidentTypeName = new string[] {""} ;
         T001C8_A99MedicalIndicationName = new string[] {""} ;
         T001C8_A347ResidentPhoneCode = new string[] {""} ;
         T001C8_A348ResidentPhoneNumber = new string[] {""} ;
         T001C8_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         T001C8_A29LocationId = new Guid[] {Guid.Empty} ;
         T001C8_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001C8_A62ResidentId = new Guid[] {Guid.Empty} ;
         T001C8_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         T001C8_n96ResidentTypeId = new bool[] {false} ;
         T001C8_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         T001C8_n98MedicalIndicationId = new bool[] {false} ;
         T001C4_A29LocationId = new Guid[] {Guid.Empty} ;
         T001C4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001C5_A72ResidentSalutation = new string[] {""} ;
         T001C5_A63ResidentBsnNumber = new string[] {""} ;
         T001C5_A64ResidentGivenName = new string[] {""} ;
         T001C5_A65ResidentLastName = new string[] {""} ;
         T001C5_A66ResidentInitials = new string[] {""} ;
         T001C5_A67ResidentEmail = new string[] {""} ;
         T001C5_A68ResidentGender = new string[] {""} ;
         T001C5_A312ResidentCountry = new string[] {""} ;
         T001C5_A313ResidentCity = new string[] {""} ;
         T001C5_A314ResidentZipCode = new string[] {""} ;
         T001C5_A315ResidentAddressLine1 = new string[] {""} ;
         T001C5_A316ResidentAddressLine2 = new string[] {""} ;
         T001C5_A70ResidentPhone = new string[] {""} ;
         T001C5_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         T001C5_A71ResidentGUID = new string[] {""} ;
         T001C5_A347ResidentPhoneCode = new string[] {""} ;
         T001C5_A348ResidentPhoneNumber = new string[] {""} ;
         T001C5_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         T001C5_n96ResidentTypeId = new bool[] {false} ;
         T001C5_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         T001C5_n98MedicalIndicationId = new bool[] {false} ;
         T001C6_A97ResidentTypeName = new string[] {""} ;
         T001C7_A99MedicalIndicationName = new string[] {""} ;
         T001C9_A29LocationId = new Guid[] {Guid.Empty} ;
         T001C9_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001C10_A72ResidentSalutation = new string[] {""} ;
         T001C10_A63ResidentBsnNumber = new string[] {""} ;
         T001C10_A64ResidentGivenName = new string[] {""} ;
         T001C10_A65ResidentLastName = new string[] {""} ;
         T001C10_A66ResidentInitials = new string[] {""} ;
         T001C10_A67ResidentEmail = new string[] {""} ;
         T001C10_A68ResidentGender = new string[] {""} ;
         T001C10_A312ResidentCountry = new string[] {""} ;
         T001C10_A313ResidentCity = new string[] {""} ;
         T001C10_A314ResidentZipCode = new string[] {""} ;
         T001C10_A315ResidentAddressLine1 = new string[] {""} ;
         T001C10_A316ResidentAddressLine2 = new string[] {""} ;
         T001C10_A70ResidentPhone = new string[] {""} ;
         T001C10_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         T001C10_A71ResidentGUID = new string[] {""} ;
         T001C10_A347ResidentPhoneCode = new string[] {""} ;
         T001C10_A348ResidentPhoneNumber = new string[] {""} ;
         T001C10_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         T001C10_n96ResidentTypeId = new bool[] {false} ;
         T001C10_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         T001C10_n98MedicalIndicationId = new bool[] {false} ;
         T001C11_A97ResidentTypeName = new string[] {""} ;
         T001C12_A99MedicalIndicationName = new string[] {""} ;
         T001C13_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         T001C13_A62ResidentId = new Guid[] {Guid.Empty} ;
         T001C3_A442AgendaEventGroupRSVP = new bool[] {false} ;
         T001C3_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         T001C3_A62ResidentId = new Guid[] {Guid.Empty} ;
         sMode83 = "";
         T001C14_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         T001C14_A62ResidentId = new Guid[] {Guid.Empty} ;
         T001C15_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         T001C15_A62ResidentId = new Guid[] {Guid.Empty} ;
         T001C2_A442AgendaEventGroupRSVP = new bool[] {false} ;
         T001C2_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         T001C2_A62ResidentId = new Guid[] {Guid.Empty} ;
         T001C19_A29LocationId = new Guid[] {Guid.Empty} ;
         T001C19_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001C20_A72ResidentSalutation = new string[] {""} ;
         T001C20_A63ResidentBsnNumber = new string[] {""} ;
         T001C20_A64ResidentGivenName = new string[] {""} ;
         T001C20_A65ResidentLastName = new string[] {""} ;
         T001C20_A66ResidentInitials = new string[] {""} ;
         T001C20_A67ResidentEmail = new string[] {""} ;
         T001C20_A68ResidentGender = new string[] {""} ;
         T001C20_A312ResidentCountry = new string[] {""} ;
         T001C20_A313ResidentCity = new string[] {""} ;
         T001C20_A314ResidentZipCode = new string[] {""} ;
         T001C20_A315ResidentAddressLine1 = new string[] {""} ;
         T001C20_A316ResidentAddressLine2 = new string[] {""} ;
         T001C20_A70ResidentPhone = new string[] {""} ;
         T001C20_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         T001C20_A71ResidentGUID = new string[] {""} ;
         T001C20_A347ResidentPhoneCode = new string[] {""} ;
         T001C20_A348ResidentPhoneNumber = new string[] {""} ;
         T001C20_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         T001C20_n96ResidentTypeId = new bool[] {false} ;
         T001C20_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         T001C20_n98MedicalIndicationId = new bool[] {false} ;
         T001C21_A97ResidentTypeName = new string[] {""} ;
         T001C22_A99MedicalIndicationName = new string[] {""} ;
         T001C23_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         T001C23_A62ResidentId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ268AgendaCalendarId = Guid.Empty;
         ZZ62ResidentId = Guid.Empty;
         ZZ29LocationId = Guid.Empty;
         ZZ11OrganisationId = Guid.Empty;
         ZZ72ResidentSalutation = "";
         ZZ63ResidentBsnNumber = "";
         ZZ64ResidentGivenName = "";
         ZZ65ResidentLastName = "";
         ZZ66ResidentInitials = "";
         ZZ67ResidentEmail = "";
         ZZ68ResidentGender = "";
         ZZ312ResidentCountry = "";
         ZZ313ResidentCity = "";
         ZZ314ResidentZipCode = "";
         ZZ315ResidentAddressLine1 = "";
         ZZ316ResidentAddressLine2 = "";
         ZZ70ResidentPhone = "";
         ZZ73ResidentBirthDate = DateTime.MinValue;
         ZZ71ResidentGUID = "";
         ZZ347ResidentPhoneCode = "";
         ZZ348ResidentPhoneNumber = "";
         ZZ96ResidentTypeId = Guid.Empty;
         ZZ98MedicalIndicationId = Guid.Empty;
         ZZ97ResidentTypeName = "";
         ZZ99MedicalIndicationName = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_agendaeventgroup__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_agendaeventgroup__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_agendaeventgroup__default(),
            new Object[][] {
                new Object[] {
               T001C2_A442AgendaEventGroupRSVP, T001C2_A268AgendaCalendarId, T001C2_A62ResidentId
               }
               , new Object[] {
               T001C3_A442AgendaEventGroupRSVP, T001C3_A268AgendaCalendarId, T001C3_A62ResidentId
               }
               , new Object[] {
               T001C4_A29LocationId, T001C4_A11OrganisationId
               }
               , new Object[] {
               T001C5_A72ResidentSalutation, T001C5_A63ResidentBsnNumber, T001C5_A64ResidentGivenName, T001C5_A65ResidentLastName, T001C5_A66ResidentInitials, T001C5_A67ResidentEmail, T001C5_A68ResidentGender, T001C5_A312ResidentCountry, T001C5_A313ResidentCity, T001C5_A314ResidentZipCode,
               T001C5_A315ResidentAddressLine1, T001C5_A316ResidentAddressLine2, T001C5_A70ResidentPhone, T001C5_A73ResidentBirthDate, T001C5_A71ResidentGUID, T001C5_A347ResidentPhoneCode, T001C5_A348ResidentPhoneNumber, T001C5_A96ResidentTypeId, T001C5_n96ResidentTypeId, T001C5_A98MedicalIndicationId,
               T001C5_n98MedicalIndicationId
               }
               , new Object[] {
               T001C6_A97ResidentTypeName
               }
               , new Object[] {
               T001C7_A99MedicalIndicationName
               }
               , new Object[] {
               T001C8_A442AgendaEventGroupRSVP, T001C8_A72ResidentSalutation, T001C8_A63ResidentBsnNumber, T001C8_A64ResidentGivenName, T001C8_A65ResidentLastName, T001C8_A66ResidentInitials, T001C8_A67ResidentEmail, T001C8_A68ResidentGender, T001C8_A312ResidentCountry, T001C8_A313ResidentCity,
               T001C8_A314ResidentZipCode, T001C8_A315ResidentAddressLine1, T001C8_A316ResidentAddressLine2, T001C8_A70ResidentPhone, T001C8_A73ResidentBirthDate, T001C8_A71ResidentGUID, T001C8_A97ResidentTypeName, T001C8_A99MedicalIndicationName, T001C8_A347ResidentPhoneCode, T001C8_A348ResidentPhoneNumber,
               T001C8_A268AgendaCalendarId, T001C8_A29LocationId, T001C8_A11OrganisationId, T001C8_A62ResidentId, T001C8_A96ResidentTypeId, T001C8_n96ResidentTypeId, T001C8_A98MedicalIndicationId, T001C8_n98MedicalIndicationId
               }
               , new Object[] {
               T001C9_A29LocationId, T001C9_A11OrganisationId
               }
               , new Object[] {
               T001C10_A72ResidentSalutation, T001C10_A63ResidentBsnNumber, T001C10_A64ResidentGivenName, T001C10_A65ResidentLastName, T001C10_A66ResidentInitials, T001C10_A67ResidentEmail, T001C10_A68ResidentGender, T001C10_A312ResidentCountry, T001C10_A313ResidentCity, T001C10_A314ResidentZipCode,
               T001C10_A315ResidentAddressLine1, T001C10_A316ResidentAddressLine2, T001C10_A70ResidentPhone, T001C10_A73ResidentBirthDate, T001C10_A71ResidentGUID, T001C10_A347ResidentPhoneCode, T001C10_A348ResidentPhoneNumber, T001C10_A96ResidentTypeId, T001C10_n96ResidentTypeId, T001C10_A98MedicalIndicationId,
               T001C10_n98MedicalIndicationId
               }
               , new Object[] {
               T001C11_A97ResidentTypeName
               }
               , new Object[] {
               T001C12_A99MedicalIndicationName
               }
               , new Object[] {
               T001C13_A268AgendaCalendarId, T001C13_A62ResidentId
               }
               , new Object[] {
               T001C14_A268AgendaCalendarId, T001C14_A62ResidentId
               }
               , new Object[] {
               T001C15_A268AgendaCalendarId, T001C15_A62ResidentId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001C19_A29LocationId, T001C19_A11OrganisationId
               }
               , new Object[] {
               T001C20_A72ResidentSalutation, T001C20_A63ResidentBsnNumber, T001C20_A64ResidentGivenName, T001C20_A65ResidentLastName, T001C20_A66ResidentInitials, T001C20_A67ResidentEmail, T001C20_A68ResidentGender, T001C20_A312ResidentCountry, T001C20_A313ResidentCity, T001C20_A314ResidentZipCode,
               T001C20_A315ResidentAddressLine1, T001C20_A316ResidentAddressLine2, T001C20_A70ResidentPhone, T001C20_A73ResidentBirthDate, T001C20_A71ResidentGUID, T001C20_A347ResidentPhoneCode, T001C20_A348ResidentPhoneNumber, T001C20_A96ResidentTypeId, T001C20_n96ResidentTypeId, T001C20_A98MedicalIndicationId,
               T001C20_n98MedicalIndicationId
               }
               , new Object[] {
               T001C21_A97ResidentTypeName
               }
               , new Object[] {
               T001C22_A99MedicalIndicationName
               }
               , new Object[] {
               T001C23_A268AgendaCalendarId, T001C23_A62ResidentId
               }
            }
         );
         Z62ResidentId = Guid.NewGuid( );
         A62ResidentId = Guid.NewGuid( );
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound83 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtAgendaCalendarId_Enabled ;
      private int edtResidentId_Enabled ;
      private int edtLocationId_Enabled ;
      private int edtOrganisationId_Enabled ;
      private int edtResidentBsnNumber_Enabled ;
      private int edtResidentGivenName_Enabled ;
      private int edtResidentLastName_Enabled ;
      private int edtResidentInitials_Enabled ;
      private int edtResidentEmail_Enabled ;
      private int edtResidentCountry_Enabled ;
      private int edtResidentCity_Enabled ;
      private int edtResidentZipCode_Enabled ;
      private int edtResidentAddressLine1_Enabled ;
      private int edtResidentAddressLine2_Enabled ;
      private int edtResidentPhone_Enabled ;
      private int edtResidentBirthDate_Enabled ;
      private int edtResidentGUID_Enabled ;
      private int edtResidentTypeId_Enabled ;
      private int edtResidentTypeName_Enabled ;
      private int edtMedicalIndicationId_Enabled ;
      private int edtMedicalIndicationName_Enabled ;
      private int edtResidentPhoneCode_Enabled ;
      private int edtResidentPhoneNumber_Enabled ;
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
      private string edtAgendaCalendarId_Internalname ;
      private string A72ResidentSalutation ;
      private string cmbResidentSalutation_Internalname ;
      private string cmbResidentGender_Internalname ;
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
      private string edtAgendaCalendarId_Jsonclick ;
      private string edtResidentId_Internalname ;
      private string edtResidentId_Jsonclick ;
      private string chkAgendaEventGroupRSVP_Internalname ;
      private string edtLocationId_Internalname ;
      private string edtLocationId_Jsonclick ;
      private string edtOrganisationId_Internalname ;
      private string edtOrganisationId_Jsonclick ;
      private string cmbResidentSalutation_Jsonclick ;
      private string edtResidentBsnNumber_Internalname ;
      private string edtResidentBsnNumber_Jsonclick ;
      private string edtResidentGivenName_Internalname ;
      private string edtResidentGivenName_Jsonclick ;
      private string edtResidentLastName_Internalname ;
      private string edtResidentLastName_Jsonclick ;
      private string edtResidentInitials_Internalname ;
      private string A66ResidentInitials ;
      private string edtResidentInitials_Jsonclick ;
      private string edtResidentEmail_Internalname ;
      private string edtResidentEmail_Jsonclick ;
      private string cmbResidentGender_Jsonclick ;
      private string edtResidentCountry_Internalname ;
      private string edtResidentCountry_Jsonclick ;
      private string edtResidentCity_Internalname ;
      private string edtResidentCity_Jsonclick ;
      private string edtResidentZipCode_Internalname ;
      private string edtResidentZipCode_Jsonclick ;
      private string edtResidentAddressLine1_Internalname ;
      private string edtResidentAddressLine1_Jsonclick ;
      private string edtResidentAddressLine2_Internalname ;
      private string edtResidentAddressLine2_Jsonclick ;
      private string edtResidentPhone_Internalname ;
      private string gxphoneLink ;
      private string A70ResidentPhone ;
      private string edtResidentPhone_Jsonclick ;
      private string edtResidentBirthDate_Internalname ;
      private string edtResidentBirthDate_Jsonclick ;
      private string edtResidentGUID_Internalname ;
      private string edtResidentGUID_Jsonclick ;
      private string edtResidentTypeId_Internalname ;
      private string edtResidentTypeId_Jsonclick ;
      private string edtResidentTypeName_Internalname ;
      private string edtResidentTypeName_Jsonclick ;
      private string edtMedicalIndicationId_Internalname ;
      private string edtMedicalIndicationId_Jsonclick ;
      private string edtMedicalIndicationName_Internalname ;
      private string edtMedicalIndicationName_Jsonclick ;
      private string edtResidentPhoneCode_Internalname ;
      private string edtResidentPhoneCode_Jsonclick ;
      private string edtResidentPhoneNumber_Internalname ;
      private string edtResidentPhoneNumber_Jsonclick ;
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
      private string Z72ResidentSalutation ;
      private string Z66ResidentInitials ;
      private string Z70ResidentPhone ;
      private string sMode83 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ72ResidentSalutation ;
      private string ZZ66ResidentInitials ;
      private string ZZ70ResidentPhone ;
      private DateTime A73ResidentBirthDate ;
      private DateTime Z73ResidentBirthDate ;
      private DateTime ZZ73ResidentBirthDate ;
      private bool Z442AgendaEventGroupRSVP ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n96ResidentTypeId ;
      private bool n98MedicalIndicationId ;
      private bool wbErr ;
      private bool A442AgendaEventGroupRSVP ;
      private bool ZZ442AgendaEventGroupRSVP ;
      private string A68ResidentGender ;
      private string A63ResidentBsnNumber ;
      private string A64ResidentGivenName ;
      private string A65ResidentLastName ;
      private string A67ResidentEmail ;
      private string A312ResidentCountry ;
      private string A313ResidentCity ;
      private string A314ResidentZipCode ;
      private string A315ResidentAddressLine1 ;
      private string A316ResidentAddressLine2 ;
      private string A71ResidentGUID ;
      private string A97ResidentTypeName ;
      private string A99MedicalIndicationName ;
      private string A347ResidentPhoneCode ;
      private string A348ResidentPhoneNumber ;
      private string Z63ResidentBsnNumber ;
      private string Z64ResidentGivenName ;
      private string Z65ResidentLastName ;
      private string Z67ResidentEmail ;
      private string Z68ResidentGender ;
      private string Z312ResidentCountry ;
      private string Z313ResidentCity ;
      private string Z314ResidentZipCode ;
      private string Z315ResidentAddressLine1 ;
      private string Z316ResidentAddressLine2 ;
      private string Z71ResidentGUID ;
      private string Z347ResidentPhoneCode ;
      private string Z348ResidentPhoneNumber ;
      private string Z97ResidentTypeName ;
      private string Z99MedicalIndicationName ;
      private string ZZ63ResidentBsnNumber ;
      private string ZZ64ResidentGivenName ;
      private string ZZ65ResidentLastName ;
      private string ZZ67ResidentEmail ;
      private string ZZ68ResidentGender ;
      private string ZZ312ResidentCountry ;
      private string ZZ313ResidentCity ;
      private string ZZ314ResidentZipCode ;
      private string ZZ315ResidentAddressLine1 ;
      private string ZZ316ResidentAddressLine2 ;
      private string ZZ71ResidentGUID ;
      private string ZZ347ResidentPhoneCode ;
      private string ZZ348ResidentPhoneNumber ;
      private string ZZ97ResidentTypeName ;
      private string ZZ99MedicalIndicationName ;
      private Guid Z268AgendaCalendarId ;
      private Guid Z62ResidentId ;
      private Guid A268AgendaCalendarId ;
      private Guid A62ResidentId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A96ResidentTypeId ;
      private Guid A98MedicalIndicationId ;
      private Guid Z29LocationId ;
      private Guid Z11OrganisationId ;
      private Guid Z96ResidentTypeId ;
      private Guid Z98MedicalIndicationId ;
      private Guid ZZ268AgendaCalendarId ;
      private Guid ZZ62ResidentId ;
      private Guid ZZ29LocationId ;
      private Guid ZZ11OrganisationId ;
      private Guid ZZ96ResidentTypeId ;
      private Guid ZZ98MedicalIndicationId ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkAgendaEventGroupRSVP ;
      private GXCombobox cmbResidentSalutation ;
      private GXCombobox cmbResidentGender ;
      private IDataStoreProvider pr_default ;
      private bool[] T001C8_A442AgendaEventGroupRSVP ;
      private string[] T001C8_A72ResidentSalutation ;
      private string[] T001C8_A63ResidentBsnNumber ;
      private string[] T001C8_A64ResidentGivenName ;
      private string[] T001C8_A65ResidentLastName ;
      private string[] T001C8_A66ResidentInitials ;
      private string[] T001C8_A67ResidentEmail ;
      private string[] T001C8_A68ResidentGender ;
      private string[] T001C8_A312ResidentCountry ;
      private string[] T001C8_A313ResidentCity ;
      private string[] T001C8_A314ResidentZipCode ;
      private string[] T001C8_A315ResidentAddressLine1 ;
      private string[] T001C8_A316ResidentAddressLine2 ;
      private string[] T001C8_A70ResidentPhone ;
      private DateTime[] T001C8_A73ResidentBirthDate ;
      private string[] T001C8_A71ResidentGUID ;
      private string[] T001C8_A97ResidentTypeName ;
      private string[] T001C8_A99MedicalIndicationName ;
      private string[] T001C8_A347ResidentPhoneCode ;
      private string[] T001C8_A348ResidentPhoneNumber ;
      private Guid[] T001C8_A268AgendaCalendarId ;
      private Guid[] T001C8_A29LocationId ;
      private Guid[] T001C8_A11OrganisationId ;
      private Guid[] T001C8_A62ResidentId ;
      private Guid[] T001C8_A96ResidentTypeId ;
      private bool[] T001C8_n96ResidentTypeId ;
      private Guid[] T001C8_A98MedicalIndicationId ;
      private bool[] T001C8_n98MedicalIndicationId ;
      private Guid[] T001C4_A29LocationId ;
      private Guid[] T001C4_A11OrganisationId ;
      private string[] T001C5_A72ResidentSalutation ;
      private string[] T001C5_A63ResidentBsnNumber ;
      private string[] T001C5_A64ResidentGivenName ;
      private string[] T001C5_A65ResidentLastName ;
      private string[] T001C5_A66ResidentInitials ;
      private string[] T001C5_A67ResidentEmail ;
      private string[] T001C5_A68ResidentGender ;
      private string[] T001C5_A312ResidentCountry ;
      private string[] T001C5_A313ResidentCity ;
      private string[] T001C5_A314ResidentZipCode ;
      private string[] T001C5_A315ResidentAddressLine1 ;
      private string[] T001C5_A316ResidentAddressLine2 ;
      private string[] T001C5_A70ResidentPhone ;
      private DateTime[] T001C5_A73ResidentBirthDate ;
      private string[] T001C5_A71ResidentGUID ;
      private string[] T001C5_A347ResidentPhoneCode ;
      private string[] T001C5_A348ResidentPhoneNumber ;
      private Guid[] T001C5_A96ResidentTypeId ;
      private bool[] T001C5_n96ResidentTypeId ;
      private Guid[] T001C5_A98MedicalIndicationId ;
      private bool[] T001C5_n98MedicalIndicationId ;
      private string[] T001C6_A97ResidentTypeName ;
      private string[] T001C7_A99MedicalIndicationName ;
      private Guid[] T001C9_A29LocationId ;
      private Guid[] T001C9_A11OrganisationId ;
      private string[] T001C10_A72ResidentSalutation ;
      private string[] T001C10_A63ResidentBsnNumber ;
      private string[] T001C10_A64ResidentGivenName ;
      private string[] T001C10_A65ResidentLastName ;
      private string[] T001C10_A66ResidentInitials ;
      private string[] T001C10_A67ResidentEmail ;
      private string[] T001C10_A68ResidentGender ;
      private string[] T001C10_A312ResidentCountry ;
      private string[] T001C10_A313ResidentCity ;
      private string[] T001C10_A314ResidentZipCode ;
      private string[] T001C10_A315ResidentAddressLine1 ;
      private string[] T001C10_A316ResidentAddressLine2 ;
      private string[] T001C10_A70ResidentPhone ;
      private DateTime[] T001C10_A73ResidentBirthDate ;
      private string[] T001C10_A71ResidentGUID ;
      private string[] T001C10_A347ResidentPhoneCode ;
      private string[] T001C10_A348ResidentPhoneNumber ;
      private Guid[] T001C10_A96ResidentTypeId ;
      private bool[] T001C10_n96ResidentTypeId ;
      private Guid[] T001C10_A98MedicalIndicationId ;
      private bool[] T001C10_n98MedicalIndicationId ;
      private string[] T001C11_A97ResidentTypeName ;
      private string[] T001C12_A99MedicalIndicationName ;
      private Guid[] T001C13_A268AgendaCalendarId ;
      private Guid[] T001C13_A62ResidentId ;
      private bool[] T001C3_A442AgendaEventGroupRSVP ;
      private Guid[] T001C3_A268AgendaCalendarId ;
      private Guid[] T001C3_A62ResidentId ;
      private Guid[] T001C14_A268AgendaCalendarId ;
      private Guid[] T001C14_A62ResidentId ;
      private Guid[] T001C15_A268AgendaCalendarId ;
      private Guid[] T001C15_A62ResidentId ;
      private bool[] T001C2_A442AgendaEventGroupRSVP ;
      private Guid[] T001C2_A268AgendaCalendarId ;
      private Guid[] T001C2_A62ResidentId ;
      private Guid[] T001C19_A29LocationId ;
      private Guid[] T001C19_A11OrganisationId ;
      private string[] T001C20_A72ResidentSalutation ;
      private string[] T001C20_A63ResidentBsnNumber ;
      private string[] T001C20_A64ResidentGivenName ;
      private string[] T001C20_A65ResidentLastName ;
      private string[] T001C20_A66ResidentInitials ;
      private string[] T001C20_A67ResidentEmail ;
      private string[] T001C20_A68ResidentGender ;
      private string[] T001C20_A312ResidentCountry ;
      private string[] T001C20_A313ResidentCity ;
      private string[] T001C20_A314ResidentZipCode ;
      private string[] T001C20_A315ResidentAddressLine1 ;
      private string[] T001C20_A316ResidentAddressLine2 ;
      private string[] T001C20_A70ResidentPhone ;
      private DateTime[] T001C20_A73ResidentBirthDate ;
      private string[] T001C20_A71ResidentGUID ;
      private string[] T001C20_A347ResidentPhoneCode ;
      private string[] T001C20_A348ResidentPhoneNumber ;
      private Guid[] T001C20_A96ResidentTypeId ;
      private bool[] T001C20_n96ResidentTypeId ;
      private Guid[] T001C20_A98MedicalIndicationId ;
      private bool[] T001C20_n98MedicalIndicationId ;
      private string[] T001C21_A97ResidentTypeName ;
      private string[] T001C22_A99MedicalIndicationName ;
      private Guid[] T001C23_A268AgendaCalendarId ;
      private Guid[] T001C23_A62ResidentId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_agendaeventgroup__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_agendaeventgroup__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_agendaeventgroup__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[17])
      ,new ForEachCursor(def[18])
      ,new ForEachCursor(def[19])
      ,new ForEachCursor(def[20])
      ,new ForEachCursor(def[21])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT001C2;
       prmT001C2 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001C3;
       prmT001C3 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001C4;
       prmT001C4 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001C5;
       prmT001C5 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001C6;
       prmT001C6 = new Object[] {
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT001C7;
       prmT001C7 = new Object[] {
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT001C8;
       prmT001C8 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001C9;
       prmT001C9 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001C10;
       prmT001C10 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001C11;
       prmT001C11 = new Object[] {
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT001C12;
       prmT001C12 = new Object[] {
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT001C13;
       prmT001C13 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001C14;
       prmT001C14 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001C15;
       prmT001C15 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001C16;
       prmT001C16 = new Object[] {
       new ParDef("AgendaEventGroupRSVP",GXType.Boolean,4,0) ,
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001C17;
       prmT001C17 = new Object[] {
       new ParDef("AgendaEventGroupRSVP",GXType.Boolean,4,0) ,
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001C18;
       prmT001C18 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001C19;
       prmT001C19 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001C20;
       prmT001C20 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001C21;
       prmT001C21 = new Object[] {
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT001C22;
       prmT001C22 = new Object[] {
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT001C23;
       prmT001C23 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T001C2", "SELECT AgendaEventGroupRSVP, AgendaCalendarId, ResidentId FROM Trn_AgendaEventGroup WHERE AgendaCalendarId = :AgendaCalendarId AND ResidentId = :ResidentId  FOR UPDATE OF Trn_AgendaEventGroup NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001C2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001C3", "SELECT AgendaEventGroupRSVP, AgendaCalendarId, ResidentId FROM Trn_AgendaEventGroup WHERE AgendaCalendarId = :AgendaCalendarId AND ResidentId = :ResidentId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001C4", "SELECT LocationId, OrganisationId FROM Trn_AgendaCalendar WHERE AgendaCalendarId = :AgendaCalendarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001C5", "SELECT ResidentSalutation, ResidentBsnNumber, ResidentGivenName, ResidentLastName, ResidentInitials, ResidentEmail, ResidentGender, ResidentCountry, ResidentCity, ResidentZipCode, ResidentAddressLine1, ResidentAddressLine2, ResidentPhone, ResidentBirthDate, ResidentGUID, ResidentPhoneCode, ResidentPhoneNumber, ResidentTypeId, MedicalIndicationId FROM Trn_Resident WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001C6", "SELECT ResidentTypeName FROM Trn_ResidentType WHERE ResidentTypeId = :ResidentTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001C7", "SELECT MedicalIndicationName FROM Trn_MedicalIndication WHERE MedicalIndicationId = :MedicalIndicationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001C8", "SELECT TM1.AgendaEventGroupRSVP, T3.ResidentSalutation, T3.ResidentBsnNumber, T3.ResidentGivenName, T3.ResidentLastName, T3.ResidentInitials, T3.ResidentEmail, T3.ResidentGender, T3.ResidentCountry, T3.ResidentCity, T3.ResidentZipCode, T3.ResidentAddressLine1, T3.ResidentAddressLine2, T3.ResidentPhone, T3.ResidentBirthDate, T3.ResidentGUID, T4.ResidentTypeName, T5.MedicalIndicationName, T3.ResidentPhoneCode, T3.ResidentPhoneNumber, TM1.AgendaCalendarId, T2.LocationId, T2.OrganisationId, TM1.ResidentId, T3.ResidentTypeId, T3.MedicalIndicationId FROM ((((Trn_AgendaEventGroup TM1 INNER JOIN Trn_AgendaCalendar T2 ON T2.AgendaCalendarId = TM1.AgendaCalendarId) LEFT JOIN Trn_Resident T3 ON T3.ResidentId = TM1.ResidentId AND T3.LocationId = T2.LocationId AND T3.OrganisationId = T2.OrganisationId) LEFT JOIN Trn_ResidentType T4 ON T4.ResidentTypeId = T3.ResidentTypeId) LEFT JOIN Trn_MedicalIndication T5 ON T5.MedicalIndicationId = T3.MedicalIndicationId) WHERE TM1.AgendaCalendarId = :AgendaCalendarId and TM1.ResidentId = :ResidentId ORDER BY TM1.AgendaCalendarId, TM1.ResidentId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C8,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001C9", "SELECT LocationId, OrganisationId FROM Trn_AgendaCalendar WHERE AgendaCalendarId = :AgendaCalendarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C9,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001C10", "SELECT ResidentSalutation, ResidentBsnNumber, ResidentGivenName, ResidentLastName, ResidentInitials, ResidentEmail, ResidentGender, ResidentCountry, ResidentCity, ResidentZipCode, ResidentAddressLine1, ResidentAddressLine2, ResidentPhone, ResidentBirthDate, ResidentGUID, ResidentPhoneCode, ResidentPhoneNumber, ResidentTypeId, MedicalIndicationId FROM Trn_Resident WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C10,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001C11", "SELECT ResidentTypeName FROM Trn_ResidentType WHERE ResidentTypeId = :ResidentTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C11,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001C12", "SELECT MedicalIndicationName FROM Trn_MedicalIndication WHERE MedicalIndicationId = :MedicalIndicationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C12,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001C13", "SELECT AgendaCalendarId, ResidentId FROM Trn_AgendaEventGroup WHERE AgendaCalendarId = :AgendaCalendarId AND ResidentId = :ResidentId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C13,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001C14", "SELECT AgendaCalendarId, ResidentId FROM Trn_AgendaEventGroup WHERE ( AgendaCalendarId > :AgendaCalendarId or AgendaCalendarId = :AgendaCalendarId and ResidentId > :ResidentId) ORDER BY AgendaCalendarId, ResidentId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C14,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001C15", "SELECT AgendaCalendarId, ResidentId FROM Trn_AgendaEventGroup WHERE ( AgendaCalendarId < :AgendaCalendarId or AgendaCalendarId = :AgendaCalendarId and ResidentId < :ResidentId) ORDER BY AgendaCalendarId DESC, ResidentId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C15,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001C16", "SAVEPOINT gxupdate;INSERT INTO Trn_AgendaEventGroup(AgendaEventGroupRSVP, AgendaCalendarId, ResidentId) VALUES(:AgendaEventGroupRSVP, :AgendaCalendarId, :ResidentId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001C16)
          ,new CursorDef("T001C17", "SAVEPOINT gxupdate;UPDATE Trn_AgendaEventGroup SET AgendaEventGroupRSVP=:AgendaEventGroupRSVP  WHERE AgendaCalendarId = :AgendaCalendarId AND ResidentId = :ResidentId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001C17)
          ,new CursorDef("T001C18", "SAVEPOINT gxupdate;DELETE FROM Trn_AgendaEventGroup  WHERE AgendaCalendarId = :AgendaCalendarId AND ResidentId = :ResidentId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001C18)
          ,new CursorDef("T001C19", "SELECT LocationId, OrganisationId FROM Trn_AgendaCalendar WHERE AgendaCalendarId = :AgendaCalendarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C19,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001C20", "SELECT ResidentSalutation, ResidentBsnNumber, ResidentGivenName, ResidentLastName, ResidentInitials, ResidentEmail, ResidentGender, ResidentCountry, ResidentCity, ResidentZipCode, ResidentAddressLine1, ResidentAddressLine2, ResidentPhone, ResidentBirthDate, ResidentGUID, ResidentPhoneCode, ResidentPhoneNumber, ResidentTypeId, MedicalIndicationId FROM Trn_Resident WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C20,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001C21", "SELECT ResidentTypeName FROM Trn_ResidentType WHERE ResidentTypeId = :ResidentTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C21,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001C22", "SELECT MedicalIndicationName FROM Trn_MedicalIndication WHERE MedicalIndicationId = :MedicalIndicationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C22,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001C23", "SELECT AgendaCalendarId, ResidentId FROM Trn_AgendaEventGroup ORDER BY AgendaCalendarId, ResidentId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C23,100, GxCacheFrequency.OFF ,true,false )
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
             ((bool[]) buf[0])[0] = rslt.getBool(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 1 :
             ((bool[]) buf[0])[0] = rslt.getBool(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getString(1, 20);
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
             ((string[]) buf[12])[0] = rslt.getString(13, 20);
             ((DateTime[]) buf[13])[0] = rslt.getGXDate(14);
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((string[]) buf[15])[0] = rslt.getVarchar(16);
             ((string[]) buf[16])[0] = rslt.getVarchar(17);
             ((Guid[]) buf[17])[0] = rslt.getGuid(18);
             ((bool[]) buf[18])[0] = rslt.wasNull(18);
             ((Guid[]) buf[19])[0] = rslt.getGuid(19);
             ((bool[]) buf[20])[0] = rslt.wasNull(19);
             return;
          case 4 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 5 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 6 :
             ((bool[]) buf[0])[0] = rslt.getBool(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 20);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getString(6, 20);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getString(14, 20);
             ((DateTime[]) buf[14])[0] = rslt.getGXDate(15);
             ((string[]) buf[15])[0] = rslt.getVarchar(16);
             ((string[]) buf[16])[0] = rslt.getVarchar(17);
             ((string[]) buf[17])[0] = rslt.getVarchar(18);
             ((string[]) buf[18])[0] = rslt.getVarchar(19);
             ((string[]) buf[19])[0] = rslt.getVarchar(20);
             ((Guid[]) buf[20])[0] = rslt.getGuid(21);
             ((Guid[]) buf[21])[0] = rslt.getGuid(22);
             ((Guid[]) buf[22])[0] = rslt.getGuid(23);
             ((Guid[]) buf[23])[0] = rslt.getGuid(24);
             ((Guid[]) buf[24])[0] = rslt.getGuid(25);
             ((bool[]) buf[25])[0] = rslt.wasNull(25);
             ((Guid[]) buf[26])[0] = rslt.getGuid(26);
             ((bool[]) buf[27])[0] = rslt.wasNull(26);
             return;
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 8 :
             ((string[]) buf[0])[0] = rslt.getString(1, 20);
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
             ((string[]) buf[12])[0] = rslt.getString(13, 20);
             ((DateTime[]) buf[13])[0] = rslt.getGXDate(14);
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((string[]) buf[15])[0] = rslt.getVarchar(16);
             ((string[]) buf[16])[0] = rslt.getVarchar(17);
             ((Guid[]) buf[17])[0] = rslt.getGuid(18);
             ((bool[]) buf[18])[0] = rslt.wasNull(18);
             ((Guid[]) buf[19])[0] = rslt.getGuid(19);
             ((bool[]) buf[20])[0] = rslt.wasNull(19);
             return;
          case 9 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 10 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
          case 17 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 18 :
             ((string[]) buf[0])[0] = rslt.getString(1, 20);
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
             ((string[]) buf[12])[0] = rslt.getString(13, 20);
             ((DateTime[]) buf[13])[0] = rslt.getGXDate(14);
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((string[]) buf[15])[0] = rslt.getVarchar(16);
             ((string[]) buf[16])[0] = rslt.getVarchar(17);
             ((Guid[]) buf[17])[0] = rslt.getGuid(18);
             ((bool[]) buf[18])[0] = rslt.wasNull(18);
             ((Guid[]) buf[19])[0] = rslt.getGuid(19);
             ((bool[]) buf[20])[0] = rslt.wasNull(19);
             return;
          case 19 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 20 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 21 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
    }
 }

}

}
