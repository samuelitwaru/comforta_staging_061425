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
   public class trn_agendacalendar : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel5"+"_"+"LOCATIONID") == 0 )
         {
            Gx_mode = GetPar( "Mode");
            AssignAttri("", false, "Gx_mode", Gx_mode);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX5ASALOCATIONID0Y50( Gx_mode) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel6"+"_"+"ORGANISATIONID") == 0 )
         {
            Gx_mode = GetPar( "Mode");
            AssignAttri("", false, "Gx_mode", Gx_mode);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX6ASAORGANISATIONID0Y50( Gx_mode) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
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
            gxLoad_10( A29LocationId, A11OrganisationId) ;
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
         Form.Meta.addItem("description", context.GetMessage( "Trn_Agenda Calendar", ""), 0) ;
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

      public trn_agendacalendar( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_agendacalendar( IGxContext context )
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
         cmbAgendaCalendarType = new GXCombobox();
         chkAgendaCalendarAllDay = new GXCheckbox();
         chkAgendaCalendarRecurring = new GXCheckbox();
         chkAgendaCalendarAddRSVP = new GXCheckbox();
         chkAgendaCalendarLocationEvent = new GXCheckbox();
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
            return "trn_agendacalendar_Execute" ;
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
         if ( cmbAgendaCalendarType.ItemCount > 0 )
         {
            A441AgendaCalendarType = cmbAgendaCalendarType.getValidValue(A441AgendaCalendarType);
            AssignAttri("", false, "A441AgendaCalendarType", A441AgendaCalendarType);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbAgendaCalendarType.CurrentValue = StringUtil.RTrim( A441AgendaCalendarType);
            AssignProp("", false, cmbAgendaCalendarType_Internalname, "Values", cmbAgendaCalendarType.ToJavascriptSource(), true);
         }
         A272AgendaCalendarAllDay = StringUtil.StrToBool( StringUtil.BoolToStr( A272AgendaCalendarAllDay));
         AssignAttri("", false, "A272AgendaCalendarAllDay", A272AgendaCalendarAllDay);
         A437AgendaCalendarRecurring = StringUtil.StrToBool( StringUtil.BoolToStr( A437AgendaCalendarRecurring));
         AssignAttri("", false, "A437AgendaCalendarRecurring", A437AgendaCalendarRecurring);
         A439AgendaCalendarAddRSVP = StringUtil.StrToBool( StringUtil.BoolToStr( A439AgendaCalendarAddRSVP));
         AssignAttri("", false, "A439AgendaCalendarAddRSVP", A439AgendaCalendarAddRSVP);
         A661AgendaCalendarLocationEvent = StringUtil.StrToBool( StringUtil.BoolToStr( A661AgendaCalendarLocationEvent));
         n661AgendaCalendarLocationEvent = false;
         AssignAttri("", false, "A661AgendaCalendarLocationEvent", A661AgendaCalendarLocationEvent);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Trn_Agenda Calendar", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Trn_AgendaCalendar.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AgendaCalendar.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AgendaCalendar.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AgendaCalendar.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AgendaCalendar.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Trn_AgendaCalendar.htm");
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
         GxWebStd.gx_label_element( context, edtAgendaCalendarId_Internalname, context.GetMessage( "Calendar Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAgendaCalendarId_Internalname, A268AgendaCalendarId.ToString(), A268AgendaCalendarId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAgendaCalendarId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAgendaCalendarId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_AgendaCalendar.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationId_Internalname, A29LocationId.ToString(), A29LocationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_AgendaCalendar.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationId_Internalname, A11OrganisationId.ToString(), A11OrganisationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrganisationId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_AgendaCalendar.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAgendaCalendarTitle_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAgendaCalendarTitle_Internalname, context.GetMessage( "Calendar Title", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAgendaCalendarTitle_Internalname, A269AgendaCalendarTitle, StringUtil.RTrim( context.localUtil.Format( A269AgendaCalendarTitle, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAgendaCalendarTitle_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAgendaCalendarTitle_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "GeneXusUnanimo\\Title", "start", true, "", "HLP_Trn_AgendaCalendar.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAgendaCalendarStartDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAgendaCalendarStartDate_Internalname, context.GetMessage( "Start Date", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtAgendaCalendarStartDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtAgendaCalendarStartDate_Internalname, context.localUtil.TToC( A270AgendaCalendarStartDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A270AgendaCalendarStartDate, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAgendaCalendarStartDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAgendaCalendarStartDate_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_AgendaCalendar.htm");
         GxWebStd.gx_bitmap( context, edtAgendaCalendarStartDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtAgendaCalendarStartDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_AgendaCalendar.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAgendaCalendarEndDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAgendaCalendarEndDate_Internalname, context.GetMessage( "End Date", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtAgendaCalendarEndDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtAgendaCalendarEndDate_Internalname, context.localUtil.TToC( A271AgendaCalendarEndDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A271AgendaCalendarEndDate, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAgendaCalendarEndDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAgendaCalendarEndDate_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_AgendaCalendar.htm");
         GxWebStd.gx_bitmap( context, edtAgendaCalendarEndDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtAgendaCalendarEndDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_AgendaCalendar.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbAgendaCalendarType_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbAgendaCalendarType_Internalname, context.GetMessage( "Calendar Type", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbAgendaCalendarType, cmbAgendaCalendarType_Internalname, StringUtil.RTrim( A441AgendaCalendarType), 1, cmbAgendaCalendarType_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbAgendaCalendarType.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "", true, 0, "HLP_Trn_AgendaCalendar.htm");
         cmbAgendaCalendarType.CurrentValue = StringUtil.RTrim( A441AgendaCalendarType);
         AssignProp("", false, cmbAgendaCalendarType_Internalname, "Values", (string)(cmbAgendaCalendarType.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkAgendaCalendarAllDay_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkAgendaCalendarAllDay_Internalname, context.GetMessage( "All Day", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkAgendaCalendarAllDay_Internalname, StringUtil.BoolToStr( A272AgendaCalendarAllDay), "", context.GetMessage( "All Day", ""), 1, chkAgendaCalendarAllDay.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(69, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,69);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkAgendaCalendarRecurring_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkAgendaCalendarRecurring_Internalname, context.GetMessage( "Calendar Recurring", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkAgendaCalendarRecurring_Internalname, StringUtil.BoolToStr( A437AgendaCalendarRecurring), "", context.GetMessage( "Calendar Recurring", ""), 1, chkAgendaCalendarRecurring.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(74, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,74);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAgendaCalendarRecurringType_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAgendaCalendarRecurringType_Internalname, context.GetMessage( "Recurring Type", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAgendaCalendarRecurringType_Internalname, A438AgendaCalendarRecurringType, StringUtil.RTrim( context.localUtil.Format( A438AgendaCalendarRecurringType, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAgendaCalendarRecurringType_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAgendaCalendarRecurringType_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_AgendaCalendar.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkAgendaCalendarAddRSVP_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkAgendaCalendarAddRSVP_Internalname, context.GetMessage( "Add RSVP", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkAgendaCalendarAddRSVP_Internalname, StringUtil.BoolToStr( A439AgendaCalendarAddRSVP), "", context.GetMessage( "Add RSVP", ""), 1, chkAgendaCalendarAddRSVP.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(84, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,84);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkAgendaCalendarLocationEvent_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkAgendaCalendarLocationEvent_Internalname, context.GetMessage( "location residents", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkAgendaCalendarLocationEvent_Internalname, StringUtil.BoolToStr( A661AgendaCalendarLocationEvent), "", context.GetMessage( "location residents", ""), 1, chkAgendaCalendarLocationEvent.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(89, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,89);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AgendaCalendar.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AgendaCalendar.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AgendaCalendar.htm");
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
            Z269AgendaCalendarTitle = cgiGet( "Z269AgendaCalendarTitle");
            Z270AgendaCalendarStartDate = context.localUtil.CToT( cgiGet( "Z270AgendaCalendarStartDate"), 0);
            Z271AgendaCalendarEndDate = context.localUtil.CToT( cgiGet( "Z271AgendaCalendarEndDate"), 0);
            Z441AgendaCalendarType = cgiGet( "Z441AgendaCalendarType");
            Z272AgendaCalendarAllDay = StringUtil.StrToBool( cgiGet( "Z272AgendaCalendarAllDay"));
            Z437AgendaCalendarRecurring = StringUtil.StrToBool( cgiGet( "Z437AgendaCalendarRecurring"));
            Z438AgendaCalendarRecurringType = cgiGet( "Z438AgendaCalendarRecurringType");
            Z439AgendaCalendarAddRSVP = StringUtil.StrToBool( cgiGet( "Z439AgendaCalendarAddRSVP"));
            Z661AgendaCalendarLocationEvent = StringUtil.StrToBool( cgiGet( "Z661AgendaCalendarLocationEvent"));
            n661AgendaCalendarLocationEvent = ((false==A661AgendaCalendarLocationEvent) ? true : false);
            Z29LocationId = StringUtil.StrToGuid( cgiGet( "Z29LocationId"));
            Z11OrganisationId = StringUtil.StrToGuid( cgiGet( "Z11OrganisationId"));
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
            if ( StringUtil.StrCmp(cgiGet( edtLocationId_Internalname), "") == 0 )
            {
               A29LocationId = Guid.Empty;
               AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            }
            else
            {
               try
               {
                  A29LocationId = StringUtil.StrToGuid( cgiGet( edtLocationId_Internalname));
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
            A269AgendaCalendarTitle = cgiGet( edtAgendaCalendarTitle_Internalname);
            AssignAttri("", false, "A269AgendaCalendarTitle", A269AgendaCalendarTitle);
            if ( context.localUtil.VCDateTime( cgiGet( edtAgendaCalendarStartDate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Agenda Calendar Start Date", "")}), 1, "AGENDACALENDARSTARTDATE");
               AnyError = 1;
               GX_FocusControl = edtAgendaCalendarStartDate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A270AgendaCalendarStartDate = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A270AgendaCalendarStartDate", context.localUtil.TToC( A270AgendaCalendarStartDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A270AgendaCalendarStartDate = context.localUtil.CToT( cgiGet( edtAgendaCalendarStartDate_Internalname));
               AssignAttri("", false, "A270AgendaCalendarStartDate", context.localUtil.TToC( A270AgendaCalendarStartDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtAgendaCalendarEndDate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Agenda Calendar End Date", "")}), 1, "AGENDACALENDARENDDATE");
               AnyError = 1;
               GX_FocusControl = edtAgendaCalendarEndDate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A271AgendaCalendarEndDate = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A271AgendaCalendarEndDate", context.localUtil.TToC( A271AgendaCalendarEndDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A271AgendaCalendarEndDate = context.localUtil.CToT( cgiGet( edtAgendaCalendarEndDate_Internalname));
               AssignAttri("", false, "A271AgendaCalendarEndDate", context.localUtil.TToC( A271AgendaCalendarEndDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            cmbAgendaCalendarType.CurrentValue = cgiGet( cmbAgendaCalendarType_Internalname);
            A441AgendaCalendarType = cgiGet( cmbAgendaCalendarType_Internalname);
            AssignAttri("", false, "A441AgendaCalendarType", A441AgendaCalendarType);
            A272AgendaCalendarAllDay = StringUtil.StrToBool( cgiGet( chkAgendaCalendarAllDay_Internalname));
            AssignAttri("", false, "A272AgendaCalendarAllDay", A272AgendaCalendarAllDay);
            A437AgendaCalendarRecurring = StringUtil.StrToBool( cgiGet( chkAgendaCalendarRecurring_Internalname));
            AssignAttri("", false, "A437AgendaCalendarRecurring", A437AgendaCalendarRecurring);
            A438AgendaCalendarRecurringType = cgiGet( edtAgendaCalendarRecurringType_Internalname);
            AssignAttri("", false, "A438AgendaCalendarRecurringType", A438AgendaCalendarRecurringType);
            A439AgendaCalendarAddRSVP = StringUtil.StrToBool( cgiGet( chkAgendaCalendarAddRSVP_Internalname));
            AssignAttri("", false, "A439AgendaCalendarAddRSVP", A439AgendaCalendarAddRSVP);
            A661AgendaCalendarLocationEvent = StringUtil.StrToBool( cgiGet( chkAgendaCalendarLocationEvent_Internalname));
            n661AgendaCalendarLocationEvent = false;
            AssignAttri("", false, "A661AgendaCalendarLocationEvent", A661AgendaCalendarLocationEvent);
            n661AgendaCalendarLocationEvent = ((false==A661AgendaCalendarLocationEvent) ? true : false);
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
               getEqualNoModal( ) ;
               if ( IsIns( )  && (Guid.Empty==A268AgendaCalendarId) && ( Gx_BScreen == 0 ) )
               {
                  A268AgendaCalendarId = Guid.NewGuid( );
                  AssignAttri("", false, "A268AgendaCalendarId", A268AgendaCalendarId.ToString());
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
               InitAll0Y50( ) ;
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
         DisableAttributes0Y50( ) ;
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

      protected void ResetCaption0Y0( )
      {
      }

      protected void ZM0Y50( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z269AgendaCalendarTitle = T000Y3_A269AgendaCalendarTitle[0];
               Z270AgendaCalendarStartDate = T000Y3_A270AgendaCalendarStartDate[0];
               Z271AgendaCalendarEndDate = T000Y3_A271AgendaCalendarEndDate[0];
               Z441AgendaCalendarType = T000Y3_A441AgendaCalendarType[0];
               Z272AgendaCalendarAllDay = T000Y3_A272AgendaCalendarAllDay[0];
               Z437AgendaCalendarRecurring = T000Y3_A437AgendaCalendarRecurring[0];
               Z438AgendaCalendarRecurringType = T000Y3_A438AgendaCalendarRecurringType[0];
               Z439AgendaCalendarAddRSVP = T000Y3_A439AgendaCalendarAddRSVP[0];
               Z661AgendaCalendarLocationEvent = T000Y3_A661AgendaCalendarLocationEvent[0];
               Z29LocationId = T000Y3_A29LocationId[0];
               Z11OrganisationId = T000Y3_A11OrganisationId[0];
            }
            else
            {
               Z269AgendaCalendarTitle = A269AgendaCalendarTitle;
               Z270AgendaCalendarStartDate = A270AgendaCalendarStartDate;
               Z271AgendaCalendarEndDate = A271AgendaCalendarEndDate;
               Z441AgendaCalendarType = A441AgendaCalendarType;
               Z272AgendaCalendarAllDay = A272AgendaCalendarAllDay;
               Z437AgendaCalendarRecurring = A437AgendaCalendarRecurring;
               Z438AgendaCalendarRecurringType = A438AgendaCalendarRecurringType;
               Z439AgendaCalendarAddRSVP = A439AgendaCalendarAddRSVP;
               Z661AgendaCalendarLocationEvent = A661AgendaCalendarLocationEvent;
               Z29LocationId = A29LocationId;
               Z11OrganisationId = A11OrganisationId;
            }
         }
         if ( GX_JID == -9 )
         {
            Z268AgendaCalendarId = A268AgendaCalendarId;
            Z269AgendaCalendarTitle = A269AgendaCalendarTitle;
            Z270AgendaCalendarStartDate = A270AgendaCalendarStartDate;
            Z271AgendaCalendarEndDate = A271AgendaCalendarEndDate;
            Z441AgendaCalendarType = A441AgendaCalendarType;
            Z272AgendaCalendarAllDay = A272AgendaCalendarAllDay;
            Z437AgendaCalendarRecurring = A437AgendaCalendarRecurring;
            Z438AgendaCalendarRecurringType = A438AgendaCalendarRecurringType;
            Z439AgendaCalendarAddRSVP = A439AgendaCalendarAddRSVP;
            Z661AgendaCalendarLocationEvent = A661AgendaCalendarLocationEvent;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         GXt_guid1 = A29LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         A29LocationId = GXt_guid1;
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         GXt_guid1 = A11OrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
         A11OrganisationId = GXt_guid1;
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         if ( IsIns( )  && (false==A661AgendaCalendarLocationEvent) && ( Gx_BScreen == 0 ) )
         {
            A661AgendaCalendarLocationEvent = true;
            n661AgendaCalendarLocationEvent = false;
            AssignAttri("", false, "A661AgendaCalendarLocationEvent", A661AgendaCalendarLocationEvent);
         }
         if ( IsIns( )  && (Guid.Empty==A268AgendaCalendarId) && ( Gx_BScreen == 0 ) )
         {
            A268AgendaCalendarId = Guid.NewGuid( );
            AssignAttri("", false, "A268AgendaCalendarId", A268AgendaCalendarId.ToString());
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

      protected void Load0Y50( )
      {
         /* Using cursor T000Y5 */
         pr_default.execute(3, new Object[] {A268AgendaCalendarId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound50 = 1;
            A269AgendaCalendarTitle = T000Y5_A269AgendaCalendarTitle[0];
            AssignAttri("", false, "A269AgendaCalendarTitle", A269AgendaCalendarTitle);
            A270AgendaCalendarStartDate = T000Y5_A270AgendaCalendarStartDate[0];
            AssignAttri("", false, "A270AgendaCalendarStartDate", context.localUtil.TToC( A270AgendaCalendarStartDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A271AgendaCalendarEndDate = T000Y5_A271AgendaCalendarEndDate[0];
            AssignAttri("", false, "A271AgendaCalendarEndDate", context.localUtil.TToC( A271AgendaCalendarEndDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A441AgendaCalendarType = T000Y5_A441AgendaCalendarType[0];
            AssignAttri("", false, "A441AgendaCalendarType", A441AgendaCalendarType);
            A272AgendaCalendarAllDay = T000Y5_A272AgendaCalendarAllDay[0];
            AssignAttri("", false, "A272AgendaCalendarAllDay", A272AgendaCalendarAllDay);
            A437AgendaCalendarRecurring = T000Y5_A437AgendaCalendarRecurring[0];
            AssignAttri("", false, "A437AgendaCalendarRecurring", A437AgendaCalendarRecurring);
            A438AgendaCalendarRecurringType = T000Y5_A438AgendaCalendarRecurringType[0];
            AssignAttri("", false, "A438AgendaCalendarRecurringType", A438AgendaCalendarRecurringType);
            A439AgendaCalendarAddRSVP = T000Y5_A439AgendaCalendarAddRSVP[0];
            AssignAttri("", false, "A439AgendaCalendarAddRSVP", A439AgendaCalendarAddRSVP);
            A661AgendaCalendarLocationEvent = T000Y5_A661AgendaCalendarLocationEvent[0];
            n661AgendaCalendarLocationEvent = T000Y5_n661AgendaCalendarLocationEvent[0];
            AssignAttri("", false, "A661AgendaCalendarLocationEvent", A661AgendaCalendarLocationEvent);
            A29LocationId = T000Y5_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = T000Y5_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            ZM0Y50( -9) ;
         }
         pr_default.close(3);
         OnLoadActions0Y50( ) ;
      }

      protected void OnLoadActions0Y50( )
      {
      }

      protected void CheckExtendedTable0Y50( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000Y4 */
         pr_default.execute(2, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtLocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( ! ( ( StringUtil.StrCmp(A441AgendaCalendarType, "Event") == 0 ) || ( StringUtil.StrCmp(A441AgendaCalendarType, "Activity") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Agenda Calendar Type", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "AGENDACALENDARTYPE");
            AnyError = 1;
            GX_FocusControl = cmbAgendaCalendarType_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0Y50( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_10( Guid A29LocationId ,
                                Guid A11OrganisationId )
      {
         /* Using cursor T000Y6 */
         pr_default.execute(4, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtLocationId_Internalname;
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

      protected void GetKey0Y50( )
      {
         /* Using cursor T000Y7 */
         pr_default.execute(5, new Object[] {A268AgendaCalendarId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound50 = 1;
         }
         else
         {
            RcdFound50 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000Y3 */
         pr_default.execute(1, new Object[] {A268AgendaCalendarId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0Y50( 9) ;
            RcdFound50 = 1;
            A268AgendaCalendarId = T000Y3_A268AgendaCalendarId[0];
            AssignAttri("", false, "A268AgendaCalendarId", A268AgendaCalendarId.ToString());
            A269AgendaCalendarTitle = T000Y3_A269AgendaCalendarTitle[0];
            AssignAttri("", false, "A269AgendaCalendarTitle", A269AgendaCalendarTitle);
            A270AgendaCalendarStartDate = T000Y3_A270AgendaCalendarStartDate[0];
            AssignAttri("", false, "A270AgendaCalendarStartDate", context.localUtil.TToC( A270AgendaCalendarStartDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A271AgendaCalendarEndDate = T000Y3_A271AgendaCalendarEndDate[0];
            AssignAttri("", false, "A271AgendaCalendarEndDate", context.localUtil.TToC( A271AgendaCalendarEndDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A441AgendaCalendarType = T000Y3_A441AgendaCalendarType[0];
            AssignAttri("", false, "A441AgendaCalendarType", A441AgendaCalendarType);
            A272AgendaCalendarAllDay = T000Y3_A272AgendaCalendarAllDay[0];
            AssignAttri("", false, "A272AgendaCalendarAllDay", A272AgendaCalendarAllDay);
            A437AgendaCalendarRecurring = T000Y3_A437AgendaCalendarRecurring[0];
            AssignAttri("", false, "A437AgendaCalendarRecurring", A437AgendaCalendarRecurring);
            A438AgendaCalendarRecurringType = T000Y3_A438AgendaCalendarRecurringType[0];
            AssignAttri("", false, "A438AgendaCalendarRecurringType", A438AgendaCalendarRecurringType);
            A439AgendaCalendarAddRSVP = T000Y3_A439AgendaCalendarAddRSVP[0];
            AssignAttri("", false, "A439AgendaCalendarAddRSVP", A439AgendaCalendarAddRSVP);
            A661AgendaCalendarLocationEvent = T000Y3_A661AgendaCalendarLocationEvent[0];
            n661AgendaCalendarLocationEvent = T000Y3_n661AgendaCalendarLocationEvent[0];
            AssignAttri("", false, "A661AgendaCalendarLocationEvent", A661AgendaCalendarLocationEvent);
            A29LocationId = T000Y3_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = T000Y3_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            Z268AgendaCalendarId = A268AgendaCalendarId;
            sMode50 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0Y50( ) ;
            if ( AnyError == 1 )
            {
               RcdFound50 = 0;
               InitializeNonKey0Y50( ) ;
            }
            Gx_mode = sMode50;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound50 = 0;
            InitializeNonKey0Y50( ) ;
            sMode50 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode50;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0Y50( ) ;
         if ( RcdFound50 == 0 )
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
         RcdFound50 = 0;
         /* Using cursor T000Y8 */
         pr_default.execute(6, new Object[] {A268AgendaCalendarId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T000Y8_A268AgendaCalendarId[0], A268AgendaCalendarId, 0) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T000Y8_A268AgendaCalendarId[0], A268AgendaCalendarId, 0) > 0 ) ) )
            {
               A268AgendaCalendarId = T000Y8_A268AgendaCalendarId[0];
               AssignAttri("", false, "A268AgendaCalendarId", A268AgendaCalendarId.ToString());
               RcdFound50 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound50 = 0;
         /* Using cursor T000Y9 */
         pr_default.execute(7, new Object[] {A268AgendaCalendarId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T000Y9_A268AgendaCalendarId[0], A268AgendaCalendarId, 0) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T000Y9_A268AgendaCalendarId[0], A268AgendaCalendarId, 0) < 0 ) ) )
            {
               A268AgendaCalendarId = T000Y9_A268AgendaCalendarId[0];
               AssignAttri("", false, "A268AgendaCalendarId", A268AgendaCalendarId.ToString());
               RcdFound50 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0Y50( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAgendaCalendarId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0Y50( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound50 == 1 )
            {
               if ( A268AgendaCalendarId != Z268AgendaCalendarId )
               {
                  A268AgendaCalendarId = Z268AgendaCalendarId;
                  AssignAttri("", false, "A268AgendaCalendarId", A268AgendaCalendarId.ToString());
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
                  Update0Y50( ) ;
                  GX_FocusControl = edtAgendaCalendarId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A268AgendaCalendarId != Z268AgendaCalendarId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtAgendaCalendarId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0Y50( ) ;
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
                     Insert0Y50( ) ;
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
         if ( A268AgendaCalendarId != Z268AgendaCalendarId )
         {
            A268AgendaCalendarId = Z268AgendaCalendarId;
            AssignAttri("", false, "A268AgendaCalendarId", A268AgendaCalendarId.ToString());
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
         if ( RcdFound50 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "AGENDACALENDARID");
            AnyError = 1;
            GX_FocusControl = edtAgendaCalendarId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtLocationId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0Y50( ) ;
         if ( RcdFound50 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLocationId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0Y50( ) ;
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
         if ( RcdFound50 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLocationId_Internalname;
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
         if ( RcdFound50 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLocationId_Internalname;
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
         ScanStart0Y50( ) ;
         if ( RcdFound50 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound50 != 0 )
            {
               ScanNext0Y50( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLocationId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0Y50( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0Y50( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000Y2 */
            pr_default.execute(0, new Object[] {A268AgendaCalendarId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AgendaCalendar"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z269AgendaCalendarTitle, T000Y2_A269AgendaCalendarTitle[0]) != 0 ) || ( Z270AgendaCalendarStartDate != T000Y2_A270AgendaCalendarStartDate[0] ) || ( Z271AgendaCalendarEndDate != T000Y2_A271AgendaCalendarEndDate[0] ) || ( StringUtil.StrCmp(Z441AgendaCalendarType, T000Y2_A441AgendaCalendarType[0]) != 0 ) || ( Z272AgendaCalendarAllDay != T000Y2_A272AgendaCalendarAllDay[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z437AgendaCalendarRecurring != T000Y2_A437AgendaCalendarRecurring[0] ) || ( StringUtil.StrCmp(Z438AgendaCalendarRecurringType, T000Y2_A438AgendaCalendarRecurringType[0]) != 0 ) || ( Z439AgendaCalendarAddRSVP != T000Y2_A439AgendaCalendarAddRSVP[0] ) || ( Z661AgendaCalendarLocationEvent != T000Y2_A661AgendaCalendarLocationEvent[0] ) || ( Z29LocationId != T000Y2_A29LocationId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z11OrganisationId != T000Y2_A11OrganisationId[0] ) )
            {
               if ( StringUtil.StrCmp(Z269AgendaCalendarTitle, T000Y2_A269AgendaCalendarTitle[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_agendacalendar:[seudo value changed for attri]"+"AgendaCalendarTitle");
                  GXUtil.WriteLogRaw("Old: ",Z269AgendaCalendarTitle);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A269AgendaCalendarTitle[0]);
               }
               if ( Z270AgendaCalendarStartDate != T000Y2_A270AgendaCalendarStartDate[0] )
               {
                  GXUtil.WriteLog("trn_agendacalendar:[seudo value changed for attri]"+"AgendaCalendarStartDate");
                  GXUtil.WriteLogRaw("Old: ",Z270AgendaCalendarStartDate);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A270AgendaCalendarStartDate[0]);
               }
               if ( Z271AgendaCalendarEndDate != T000Y2_A271AgendaCalendarEndDate[0] )
               {
                  GXUtil.WriteLog("trn_agendacalendar:[seudo value changed for attri]"+"AgendaCalendarEndDate");
                  GXUtil.WriteLogRaw("Old: ",Z271AgendaCalendarEndDate);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A271AgendaCalendarEndDate[0]);
               }
               if ( StringUtil.StrCmp(Z441AgendaCalendarType, T000Y2_A441AgendaCalendarType[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_agendacalendar:[seudo value changed for attri]"+"AgendaCalendarType");
                  GXUtil.WriteLogRaw("Old: ",Z441AgendaCalendarType);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A441AgendaCalendarType[0]);
               }
               if ( Z272AgendaCalendarAllDay != T000Y2_A272AgendaCalendarAllDay[0] )
               {
                  GXUtil.WriteLog("trn_agendacalendar:[seudo value changed for attri]"+"AgendaCalendarAllDay");
                  GXUtil.WriteLogRaw("Old: ",Z272AgendaCalendarAllDay);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A272AgendaCalendarAllDay[0]);
               }
               if ( Z437AgendaCalendarRecurring != T000Y2_A437AgendaCalendarRecurring[0] )
               {
                  GXUtil.WriteLog("trn_agendacalendar:[seudo value changed for attri]"+"AgendaCalendarRecurring");
                  GXUtil.WriteLogRaw("Old: ",Z437AgendaCalendarRecurring);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A437AgendaCalendarRecurring[0]);
               }
               if ( StringUtil.StrCmp(Z438AgendaCalendarRecurringType, T000Y2_A438AgendaCalendarRecurringType[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_agendacalendar:[seudo value changed for attri]"+"AgendaCalendarRecurringType");
                  GXUtil.WriteLogRaw("Old: ",Z438AgendaCalendarRecurringType);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A438AgendaCalendarRecurringType[0]);
               }
               if ( Z439AgendaCalendarAddRSVP != T000Y2_A439AgendaCalendarAddRSVP[0] )
               {
                  GXUtil.WriteLog("trn_agendacalendar:[seudo value changed for attri]"+"AgendaCalendarAddRSVP");
                  GXUtil.WriteLogRaw("Old: ",Z439AgendaCalendarAddRSVP);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A439AgendaCalendarAddRSVP[0]);
               }
               if ( Z661AgendaCalendarLocationEvent != T000Y2_A661AgendaCalendarLocationEvent[0] )
               {
                  GXUtil.WriteLog("trn_agendacalendar:[seudo value changed for attri]"+"AgendaCalendarLocationEvent");
                  GXUtil.WriteLogRaw("Old: ",Z661AgendaCalendarLocationEvent);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A661AgendaCalendarLocationEvent[0]);
               }
               if ( Z29LocationId != T000Y2_A29LocationId[0] )
               {
                  GXUtil.WriteLog("trn_agendacalendar:[seudo value changed for attri]"+"LocationId");
                  GXUtil.WriteLogRaw("Old: ",Z29LocationId);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A29LocationId[0]);
               }
               if ( Z11OrganisationId != T000Y2_A11OrganisationId[0] )
               {
                  GXUtil.WriteLog("trn_agendacalendar:[seudo value changed for attri]"+"OrganisationId");
                  GXUtil.WriteLogRaw("Old: ",Z11OrganisationId);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A11OrganisationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_AgendaCalendar"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Y50( )
      {
         if ( ! IsAuthorized("trn_agendacalendar_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0Y50( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Y50( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Y50( 0) ;
            CheckOptimisticConcurrency0Y50( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Y50( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Y50( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Y10 */
                     pr_default.execute(8, new Object[] {A268AgendaCalendarId, A269AgendaCalendarTitle, A270AgendaCalendarStartDate, A271AgendaCalendarEndDate, A441AgendaCalendarType, A272AgendaCalendarAllDay, A437AgendaCalendarRecurring, A438AgendaCalendarRecurringType, A439AgendaCalendarAddRSVP, n661AgendaCalendarLocationEvent, A661AgendaCalendarLocationEvent, A29LocationId, A11OrganisationId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AgendaCalendar");
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
                           ResetCaption0Y0( ) ;
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
               Load0Y50( ) ;
            }
            EndLevel0Y50( ) ;
         }
         CloseExtendedTableCursors0Y50( ) ;
      }

      protected void Update0Y50( )
      {
         if ( ! IsAuthorized("trn_agendacalendar_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0Y50( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Y50( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Y50( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Y50( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Y50( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Y11 */
                     pr_default.execute(9, new Object[] {A269AgendaCalendarTitle, A270AgendaCalendarStartDate, A271AgendaCalendarEndDate, A441AgendaCalendarType, A272AgendaCalendarAllDay, A437AgendaCalendarRecurring, A438AgendaCalendarRecurringType, A439AgendaCalendarAddRSVP, n661AgendaCalendarLocationEvent, A661AgendaCalendarLocationEvent, A29LocationId, A11OrganisationId, A268AgendaCalendarId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AgendaCalendar");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AgendaCalendar"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Y50( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0Y0( ) ;
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
            EndLevel0Y50( ) ;
         }
         CloseExtendedTableCursors0Y50( ) ;
      }

      protected void DeferredUpdate0Y50( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_agendacalendar_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0Y50( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Y50( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Y50( ) ;
            AfterConfirm0Y50( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Y50( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000Y12 */
                  pr_default.execute(10, new Object[] {A268AgendaCalendarId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_AgendaCalendar");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound50 == 0 )
                        {
                           InitAll0Y50( ) ;
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
                        ResetCaption0Y0( ) ;
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
         sMode50 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0Y50( ) ;
         Gx_mode = sMode50;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0Y50( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000Y13 */
            pr_default.execute(11, new Object[] {A268AgendaCalendarId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Agenda Event Residents", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel0Y50( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0Y50( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_agendacalendar",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0Y0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_agendacalendar",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0Y50( )
      {
         /* Using cursor T000Y14 */
         pr_default.execute(12);
         RcdFound50 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound50 = 1;
            A268AgendaCalendarId = T000Y14_A268AgendaCalendarId[0];
            AssignAttri("", false, "A268AgendaCalendarId", A268AgendaCalendarId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0Y50( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound50 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound50 = 1;
            A268AgendaCalendarId = T000Y14_A268AgendaCalendarId[0];
            AssignAttri("", false, "A268AgendaCalendarId", A268AgendaCalendarId.ToString());
         }
      }

      protected void ScanEnd0Y50( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0Y50( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Y50( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Y50( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Y50( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Y50( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Y50( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Y50( )
      {
         edtAgendaCalendarId_Enabled = 0;
         AssignProp("", false, edtAgendaCalendarId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAgendaCalendarId_Enabled), 5, 0), true);
         edtLocationId_Enabled = 0;
         AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         edtOrganisationId_Enabled = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         edtAgendaCalendarTitle_Enabled = 0;
         AssignProp("", false, edtAgendaCalendarTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAgendaCalendarTitle_Enabled), 5, 0), true);
         edtAgendaCalendarStartDate_Enabled = 0;
         AssignProp("", false, edtAgendaCalendarStartDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAgendaCalendarStartDate_Enabled), 5, 0), true);
         edtAgendaCalendarEndDate_Enabled = 0;
         AssignProp("", false, edtAgendaCalendarEndDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAgendaCalendarEndDate_Enabled), 5, 0), true);
         cmbAgendaCalendarType.Enabled = 0;
         AssignProp("", false, cmbAgendaCalendarType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbAgendaCalendarType.Enabled), 5, 0), true);
         chkAgendaCalendarAllDay.Enabled = 0;
         AssignProp("", false, chkAgendaCalendarAllDay_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkAgendaCalendarAllDay.Enabled), 5, 0), true);
         chkAgendaCalendarRecurring.Enabled = 0;
         AssignProp("", false, chkAgendaCalendarRecurring_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkAgendaCalendarRecurring.Enabled), 5, 0), true);
         edtAgendaCalendarRecurringType_Enabled = 0;
         AssignProp("", false, edtAgendaCalendarRecurringType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAgendaCalendarRecurringType_Enabled), 5, 0), true);
         chkAgendaCalendarAddRSVP.Enabled = 0;
         AssignProp("", false, chkAgendaCalendarAddRSVP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkAgendaCalendarAddRSVP.Enabled), 5, 0), true);
         chkAgendaCalendarLocationEvent.Enabled = 0;
         AssignProp("", false, chkAgendaCalendarLocationEvent_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkAgendaCalendarLocationEvent.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0Y50( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0Y0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_agendacalendar.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z269AgendaCalendarTitle", Z269AgendaCalendarTitle);
         GxWebStd.gx_hidden_field( context, "Z270AgendaCalendarStartDate", context.localUtil.TToC( Z270AgendaCalendarStartDate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z271AgendaCalendarEndDate", context.localUtil.TToC( Z271AgendaCalendarEndDate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z441AgendaCalendarType", Z441AgendaCalendarType);
         GxWebStd.gx_boolean_hidden_field( context, "Z272AgendaCalendarAllDay", Z272AgendaCalendarAllDay);
         GxWebStd.gx_boolean_hidden_field( context, "Z437AgendaCalendarRecurring", Z437AgendaCalendarRecurring);
         GxWebStd.gx_hidden_field( context, "Z438AgendaCalendarRecurringType", Z438AgendaCalendarRecurringType);
         GxWebStd.gx_boolean_hidden_field( context, "Z439AgendaCalendarAddRSVP", Z439AgendaCalendarAddRSVP);
         GxWebStd.gx_boolean_hidden_field( context, "Z661AgendaCalendarLocationEvent", Z661AgendaCalendarLocationEvent);
         GxWebStd.gx_hidden_field( context, "Z29LocationId", Z29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z11OrganisationId", Z11OrganisationId.ToString());
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
         return formatLink("trn_agendacalendar.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_AgendaCalendar" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Agenda Calendar", "") ;
      }

      protected void InitializeNonKey0Y50( )
      {
         A29LocationId = Guid.Empty;
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         A11OrganisationId = Guid.Empty;
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         A269AgendaCalendarTitle = "";
         AssignAttri("", false, "A269AgendaCalendarTitle", A269AgendaCalendarTitle);
         A270AgendaCalendarStartDate = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A270AgendaCalendarStartDate", context.localUtil.TToC( A270AgendaCalendarStartDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A271AgendaCalendarEndDate = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A271AgendaCalendarEndDate", context.localUtil.TToC( A271AgendaCalendarEndDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A441AgendaCalendarType = "";
         AssignAttri("", false, "A441AgendaCalendarType", A441AgendaCalendarType);
         A272AgendaCalendarAllDay = false;
         AssignAttri("", false, "A272AgendaCalendarAllDay", A272AgendaCalendarAllDay);
         A437AgendaCalendarRecurring = false;
         AssignAttri("", false, "A437AgendaCalendarRecurring", A437AgendaCalendarRecurring);
         A438AgendaCalendarRecurringType = "";
         AssignAttri("", false, "A438AgendaCalendarRecurringType", A438AgendaCalendarRecurringType);
         A439AgendaCalendarAddRSVP = false;
         AssignAttri("", false, "A439AgendaCalendarAddRSVP", A439AgendaCalendarAddRSVP);
         A661AgendaCalendarLocationEvent = true;
         n661AgendaCalendarLocationEvent = false;
         AssignAttri("", false, "A661AgendaCalendarLocationEvent", A661AgendaCalendarLocationEvent);
         Z269AgendaCalendarTitle = "";
         Z270AgendaCalendarStartDate = (DateTime)(DateTime.MinValue);
         Z271AgendaCalendarEndDate = (DateTime)(DateTime.MinValue);
         Z441AgendaCalendarType = "";
         Z272AgendaCalendarAllDay = false;
         Z437AgendaCalendarRecurring = false;
         Z438AgendaCalendarRecurringType = "";
         Z439AgendaCalendarAddRSVP = false;
         Z661AgendaCalendarLocationEvent = false;
         Z29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
      }

      protected void InitAll0Y50( )
      {
         A268AgendaCalendarId = Guid.NewGuid( );
         AssignAttri("", false, "A268AgendaCalendarId", A268AgendaCalendarId.ToString());
         InitializeNonKey0Y50( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A29LocationId = i29LocationId;
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         A11OrganisationId = i11OrganisationId;
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         A661AgendaCalendarLocationEvent = i661AgendaCalendarLocationEvent;
         n661AgendaCalendarLocationEvent = false;
         AssignAttri("", false, "A661AgendaCalendarLocationEvent", A661AgendaCalendarLocationEvent);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20257218175771", true, true);
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
         context.AddJavascriptSource("trn_agendacalendar.js", "?20257218175771", false, true);
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
         edtLocationId_Internalname = "LOCATIONID";
         edtOrganisationId_Internalname = "ORGANISATIONID";
         edtAgendaCalendarTitle_Internalname = "AGENDACALENDARTITLE";
         edtAgendaCalendarStartDate_Internalname = "AGENDACALENDARSTARTDATE";
         edtAgendaCalendarEndDate_Internalname = "AGENDACALENDARENDDATE";
         cmbAgendaCalendarType_Internalname = "AGENDACALENDARTYPE";
         chkAgendaCalendarAllDay_Internalname = "AGENDACALENDARALLDAY";
         chkAgendaCalendarRecurring_Internalname = "AGENDACALENDARRECURRING";
         edtAgendaCalendarRecurringType_Internalname = "AGENDACALENDARRECURRINGTYPE";
         chkAgendaCalendarAddRSVP_Internalname = "AGENDACALENDARADDRSVP";
         chkAgendaCalendarLocationEvent_Internalname = "AGENDACALENDARLOCATIONEVENT";
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
         Form.Caption = context.GetMessage( "Trn_Agenda Calendar", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkAgendaCalendarLocationEvent.Enabled = 1;
         chkAgendaCalendarAddRSVP.Enabled = 1;
         edtAgendaCalendarRecurringType_Jsonclick = "";
         edtAgendaCalendarRecurringType_Enabled = 1;
         chkAgendaCalendarRecurring.Enabled = 1;
         chkAgendaCalendarAllDay.Enabled = 1;
         cmbAgendaCalendarType_Jsonclick = "";
         cmbAgendaCalendarType.Enabled = 1;
         edtAgendaCalendarEndDate_Jsonclick = "";
         edtAgendaCalendarEndDate_Enabled = 1;
         edtAgendaCalendarStartDate_Jsonclick = "";
         edtAgendaCalendarStartDate_Enabled = 1;
         edtAgendaCalendarTitle_Jsonclick = "";
         edtAgendaCalendarTitle_Enabled = 1;
         edtOrganisationId_Jsonclick = "";
         edtOrganisationId_Enabled = 1;
         edtLocationId_Jsonclick = "";
         edtLocationId_Enabled = 1;
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

      protected void GX5ASALOCATIONID0Y50( string Gx_mode )
      {
         GXt_guid1 = A29LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         A29LocationId = GXt_guid1;
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A29LocationId.ToString())+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX6ASAORGANISATIONID0Y50( string Gx_mode )
      {
         GXt_guid1 = A11OrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
         A11OrganisationId = GXt_guid1;
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
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

      protected void init_web_controls( )
      {
         cmbAgendaCalendarType.Name = "AGENDACALENDARTYPE";
         cmbAgendaCalendarType.WebTags = "";
         cmbAgendaCalendarType.addItem("Event", context.GetMessage( "Event", ""), 0);
         cmbAgendaCalendarType.addItem("Activity", context.GetMessage( "Activity", ""), 0);
         if ( cmbAgendaCalendarType.ItemCount > 0 )
         {
            A441AgendaCalendarType = cmbAgendaCalendarType.getValidValue(A441AgendaCalendarType);
            AssignAttri("", false, "A441AgendaCalendarType", A441AgendaCalendarType);
         }
         chkAgendaCalendarAllDay.Name = "AGENDACALENDARALLDAY";
         chkAgendaCalendarAllDay.WebTags = "";
         chkAgendaCalendarAllDay.Caption = context.GetMessage( "All Day", "");
         AssignProp("", false, chkAgendaCalendarAllDay_Internalname, "TitleCaption", chkAgendaCalendarAllDay.Caption, true);
         chkAgendaCalendarAllDay.CheckedValue = "false";
         A272AgendaCalendarAllDay = StringUtil.StrToBool( StringUtil.BoolToStr( A272AgendaCalendarAllDay));
         AssignAttri("", false, "A272AgendaCalendarAllDay", A272AgendaCalendarAllDay);
         chkAgendaCalendarRecurring.Name = "AGENDACALENDARRECURRING";
         chkAgendaCalendarRecurring.WebTags = "";
         chkAgendaCalendarRecurring.Caption = context.GetMessage( "Calendar Recurring", "");
         AssignProp("", false, chkAgendaCalendarRecurring_Internalname, "TitleCaption", chkAgendaCalendarRecurring.Caption, true);
         chkAgendaCalendarRecurring.CheckedValue = "false";
         A437AgendaCalendarRecurring = StringUtil.StrToBool( StringUtil.BoolToStr( A437AgendaCalendarRecurring));
         AssignAttri("", false, "A437AgendaCalendarRecurring", A437AgendaCalendarRecurring);
         chkAgendaCalendarAddRSVP.Name = "AGENDACALENDARADDRSVP";
         chkAgendaCalendarAddRSVP.WebTags = "";
         chkAgendaCalendarAddRSVP.Caption = context.GetMessage( "Add RSVP", "");
         AssignProp("", false, chkAgendaCalendarAddRSVP_Internalname, "TitleCaption", chkAgendaCalendarAddRSVP.Caption, true);
         chkAgendaCalendarAddRSVP.CheckedValue = "false";
         A439AgendaCalendarAddRSVP = StringUtil.StrToBool( StringUtil.BoolToStr( A439AgendaCalendarAddRSVP));
         AssignAttri("", false, "A439AgendaCalendarAddRSVP", A439AgendaCalendarAddRSVP);
         chkAgendaCalendarLocationEvent.Name = "AGENDACALENDARLOCATIONEVENT";
         chkAgendaCalendarLocationEvent.WebTags = "";
         chkAgendaCalendarLocationEvent.Caption = context.GetMessage( "location residents", "");
         AssignProp("", false, chkAgendaCalendarLocationEvent_Internalname, "TitleCaption", chkAgendaCalendarLocationEvent.Caption, true);
         chkAgendaCalendarLocationEvent.CheckedValue = "false";
         if ( IsIns( ) && (false==A661AgendaCalendarLocationEvent) )
         {
            A661AgendaCalendarLocationEvent = true;
            n661AgendaCalendarLocationEvent = false;
            AssignAttri("", false, "A661AgendaCalendarLocationEvent", A661AgendaCalendarLocationEvent);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtLocationId_Internalname;
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
         A441AgendaCalendarType = cmbAgendaCalendarType.CurrentValue;
         cmbAgendaCalendarType.CurrentValue = A441AgendaCalendarType;
         n661AgendaCalendarLocationEvent = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbAgendaCalendarType.ItemCount > 0 )
         {
            A441AgendaCalendarType = cmbAgendaCalendarType.getValidValue(A441AgendaCalendarType);
            cmbAgendaCalendarType.CurrentValue = A441AgendaCalendarType;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbAgendaCalendarType.CurrentValue = StringUtil.RTrim( A441AgendaCalendarType);
         }
         A272AgendaCalendarAllDay = StringUtil.StrToBool( StringUtil.BoolToStr( A272AgendaCalendarAllDay));
         A437AgendaCalendarRecurring = StringUtil.StrToBool( StringUtil.BoolToStr( A437AgendaCalendarRecurring));
         A439AgendaCalendarAddRSVP = StringUtil.StrToBool( StringUtil.BoolToStr( A439AgendaCalendarAddRSVP));
         A661AgendaCalendarLocationEvent = StringUtil.StrToBool( StringUtil.BoolToStr( A661AgendaCalendarLocationEvent));
         n661AgendaCalendarLocationEvent = false;
         /*  Sending validation outputs */
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         AssignAttri("", false, "A269AgendaCalendarTitle", A269AgendaCalendarTitle);
         AssignAttri("", false, "A270AgendaCalendarStartDate", context.localUtil.TToC( A270AgendaCalendarStartDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A271AgendaCalendarEndDate", context.localUtil.TToC( A271AgendaCalendarEndDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A441AgendaCalendarType", A441AgendaCalendarType);
         cmbAgendaCalendarType.CurrentValue = StringUtil.RTrim( A441AgendaCalendarType);
         AssignProp("", false, cmbAgendaCalendarType_Internalname, "Values", cmbAgendaCalendarType.ToJavascriptSource(), true);
         AssignAttri("", false, "A272AgendaCalendarAllDay", A272AgendaCalendarAllDay);
         AssignAttri("", false, "A437AgendaCalendarRecurring", A437AgendaCalendarRecurring);
         AssignAttri("", false, "A438AgendaCalendarRecurringType", A438AgendaCalendarRecurringType);
         AssignAttri("", false, "A439AgendaCalendarAddRSVP", A439AgendaCalendarAddRSVP);
         AssignAttri("", false, "A661AgendaCalendarLocationEvent", A661AgendaCalendarLocationEvent);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z268AgendaCalendarId", Z268AgendaCalendarId.ToString());
         GxWebStd.gx_hidden_field( context, "Z29LocationId", Z29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z11OrganisationId", Z11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z269AgendaCalendarTitle", Z269AgendaCalendarTitle);
         GxWebStd.gx_hidden_field( context, "Z270AgendaCalendarStartDate", context.localUtil.TToC( Z270AgendaCalendarStartDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z271AgendaCalendarEndDate", context.localUtil.TToC( Z271AgendaCalendarEndDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z441AgendaCalendarType", Z441AgendaCalendarType);
         GxWebStd.gx_hidden_field( context, "Z272AgendaCalendarAllDay", StringUtil.BoolToStr( Z272AgendaCalendarAllDay));
         GxWebStd.gx_hidden_field( context, "Z437AgendaCalendarRecurring", StringUtil.BoolToStr( Z437AgendaCalendarRecurring));
         GxWebStd.gx_hidden_field( context, "Z438AgendaCalendarRecurringType", Z438AgendaCalendarRecurringType);
         GxWebStd.gx_hidden_field( context, "Z439AgendaCalendarAddRSVP", StringUtil.BoolToStr( Z439AgendaCalendarAddRSVP));
         GxWebStd.gx_hidden_field( context, "Z661AgendaCalendarLocationEvent", StringUtil.BoolToStr( Z661AgendaCalendarLocationEvent));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Organisationid( )
      {
         /* Using cursor T000Y15 */
         pr_default.execute(13, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtLocationId_Internalname;
         }
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A272AgendaCalendarAllDay","fld":"AGENDACALENDARALLDAY"},{"av":"A437AgendaCalendarRecurring","fld":"AGENDACALENDARRECURRING"},{"av":"A439AgendaCalendarAddRSVP","fld":"AGENDACALENDARADDRSVP"},{"av":"A661AgendaCalendarLocationEvent","fld":"AGENDACALENDARLOCATIONEVENT"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A272AgendaCalendarAllDay","fld":"AGENDACALENDARALLDAY"},{"av":"A437AgendaCalendarRecurring","fld":"AGENDACALENDARRECURRING"},{"av":"A439AgendaCalendarAddRSVP","fld":"AGENDACALENDARADDRSVP"},{"av":"A661AgendaCalendarLocationEvent","fld":"AGENDACALENDARLOCATIONEVENT"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A272AgendaCalendarAllDay","fld":"AGENDACALENDARALLDAY"},{"av":"A437AgendaCalendarRecurring","fld":"AGENDACALENDARRECURRING"},{"av":"A439AgendaCalendarAddRSVP","fld":"AGENDACALENDARADDRSVP"},{"av":"A661AgendaCalendarLocationEvent","fld":"AGENDACALENDARLOCATIONEVENT"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A272AgendaCalendarAllDay","fld":"AGENDACALENDARALLDAY"},{"av":"A437AgendaCalendarRecurring","fld":"AGENDACALENDARRECURRING"},{"av":"A439AgendaCalendarAddRSVP","fld":"AGENDACALENDARADDRSVP"},{"av":"A661AgendaCalendarLocationEvent","fld":"AGENDACALENDARLOCATIONEVENT"}]}""");
         setEventMetadata("VALID_AGENDACALENDARID","""{"handler":"Valid_Agendacalendarid","iparms":[{"av":"cmbAgendaCalendarType"},{"av":"A441AgendaCalendarType","fld":"AGENDACALENDARTYPE"},{"av":"A268AgendaCalendarId","fld":"AGENDACALENDARID"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A272AgendaCalendarAllDay","fld":"AGENDACALENDARALLDAY"},{"av":"A437AgendaCalendarRecurring","fld":"AGENDACALENDARRECURRING"},{"av":"A439AgendaCalendarAddRSVP","fld":"AGENDACALENDARADDRSVP"},{"av":"A661AgendaCalendarLocationEvent","fld":"AGENDACALENDARLOCATIONEVENT"}]""");
         setEventMetadata("VALID_AGENDACALENDARID",""","oparms":[{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A269AgendaCalendarTitle","fld":"AGENDACALENDARTITLE"},{"av":"A270AgendaCalendarStartDate","fld":"AGENDACALENDARSTARTDATE","pic":"99/99/99 99:99"},{"av":"A271AgendaCalendarEndDate","fld":"AGENDACALENDARENDDATE","pic":"99/99/99 99:99"},{"av":"cmbAgendaCalendarType"},{"av":"A441AgendaCalendarType","fld":"AGENDACALENDARTYPE"},{"av":"A438AgendaCalendarRecurringType","fld":"AGENDACALENDARRECURRINGTYPE"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z268AgendaCalendarId"},{"av":"Z29LocationId"},{"av":"Z11OrganisationId"},{"av":"Z269AgendaCalendarTitle"},{"av":"Z270AgendaCalendarStartDate"},{"av":"Z271AgendaCalendarEndDate"},{"av":"Z441AgendaCalendarType"},{"av":"Z272AgendaCalendarAllDay"},{"av":"Z437AgendaCalendarRecurring"},{"av":"Z438AgendaCalendarRecurringType"},{"av":"Z439AgendaCalendarAddRSVP"},{"av":"Z661AgendaCalendarLocationEvent"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A272AgendaCalendarAllDay","fld":"AGENDACALENDARALLDAY"},{"av":"A437AgendaCalendarRecurring","fld":"AGENDACALENDARRECURRING"},{"av":"A439AgendaCalendarAddRSVP","fld":"AGENDACALENDARADDRSVP"},{"av":"A661AgendaCalendarLocationEvent","fld":"AGENDACALENDARLOCATIONEVENT"}]}""");
         setEventMetadata("VALID_LOCATIONID","""{"handler":"Valid_Locationid","iparms":[{"av":"A272AgendaCalendarAllDay","fld":"AGENDACALENDARALLDAY"},{"av":"A437AgendaCalendarRecurring","fld":"AGENDACALENDARRECURRING"},{"av":"A439AgendaCalendarAddRSVP","fld":"AGENDACALENDARADDRSVP"},{"av":"A661AgendaCalendarLocationEvent","fld":"AGENDACALENDARLOCATIONEVENT"}]""");
         setEventMetadata("VALID_LOCATIONID",""","oparms":[{"av":"A272AgendaCalendarAllDay","fld":"AGENDACALENDARALLDAY"},{"av":"A437AgendaCalendarRecurring","fld":"AGENDACALENDARRECURRING"},{"av":"A439AgendaCalendarAddRSVP","fld":"AGENDACALENDARADDRSVP"},{"av":"A661AgendaCalendarLocationEvent","fld":"AGENDACALENDARLOCATIONEVENT"}]}""");
         setEventMetadata("VALID_ORGANISATIONID","""{"handler":"Valid_Organisationid","iparms":[{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A272AgendaCalendarAllDay","fld":"AGENDACALENDARALLDAY"},{"av":"A437AgendaCalendarRecurring","fld":"AGENDACALENDARRECURRING"},{"av":"A439AgendaCalendarAddRSVP","fld":"AGENDACALENDARADDRSVP"},{"av":"A661AgendaCalendarLocationEvent","fld":"AGENDACALENDARLOCATIONEVENT"}]""");
         setEventMetadata("VALID_ORGANISATIONID",""","oparms":[{"av":"A272AgendaCalendarAllDay","fld":"AGENDACALENDARALLDAY"},{"av":"A437AgendaCalendarRecurring","fld":"AGENDACALENDARRECURRING"},{"av":"A439AgendaCalendarAddRSVP","fld":"AGENDACALENDARADDRSVP"},{"av":"A661AgendaCalendarLocationEvent","fld":"AGENDACALENDARLOCATIONEVENT"}]}""");
         setEventMetadata("VALID_AGENDACALENDARTYPE","""{"handler":"Valid_Agendacalendartype","iparms":[{"av":"A272AgendaCalendarAllDay","fld":"AGENDACALENDARALLDAY"},{"av":"A437AgendaCalendarRecurring","fld":"AGENDACALENDARRECURRING"},{"av":"A439AgendaCalendarAddRSVP","fld":"AGENDACALENDARADDRSVP"},{"av":"A661AgendaCalendarLocationEvent","fld":"AGENDACALENDARLOCATIONEVENT"}]""");
         setEventMetadata("VALID_AGENDACALENDARTYPE",""","oparms":[{"av":"A272AgendaCalendarAllDay","fld":"AGENDACALENDARALLDAY"},{"av":"A437AgendaCalendarRecurring","fld":"AGENDACALENDARRECURRING"},{"av":"A439AgendaCalendarAddRSVP","fld":"AGENDACALENDARADDRSVP"},{"av":"A661AgendaCalendarLocationEvent","fld":"AGENDACALENDARLOCATIONEVENT"}]}""");
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
         Z268AgendaCalendarId = Guid.Empty;
         Z269AgendaCalendarTitle = "";
         Z270AgendaCalendarStartDate = (DateTime)(DateTime.MinValue);
         Z271AgendaCalendarEndDate = (DateTime)(DateTime.MinValue);
         Z441AgendaCalendarType = "";
         Z438AgendaCalendarRecurringType = "";
         Z29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         Gx_mode = "";
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A441AgendaCalendarType = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A268AgendaCalendarId = Guid.Empty;
         A269AgendaCalendarTitle = "";
         A270AgendaCalendarStartDate = (DateTime)(DateTime.MinValue);
         A271AgendaCalendarEndDate = (DateTime)(DateTime.MinValue);
         A438AgendaCalendarRecurringType = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         T000Y5_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         T000Y5_A269AgendaCalendarTitle = new string[] {""} ;
         T000Y5_A270AgendaCalendarStartDate = new DateTime[] {DateTime.MinValue} ;
         T000Y5_A271AgendaCalendarEndDate = new DateTime[] {DateTime.MinValue} ;
         T000Y5_A441AgendaCalendarType = new string[] {""} ;
         T000Y5_A272AgendaCalendarAllDay = new bool[] {false} ;
         T000Y5_A437AgendaCalendarRecurring = new bool[] {false} ;
         T000Y5_A438AgendaCalendarRecurringType = new string[] {""} ;
         T000Y5_A439AgendaCalendarAddRSVP = new bool[] {false} ;
         T000Y5_A661AgendaCalendarLocationEvent = new bool[] {false} ;
         T000Y5_n661AgendaCalendarLocationEvent = new bool[] {false} ;
         T000Y5_A29LocationId = new Guid[] {Guid.Empty} ;
         T000Y5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000Y4_A29LocationId = new Guid[] {Guid.Empty} ;
         T000Y6_A29LocationId = new Guid[] {Guid.Empty} ;
         T000Y7_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         T000Y3_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         T000Y3_A269AgendaCalendarTitle = new string[] {""} ;
         T000Y3_A270AgendaCalendarStartDate = new DateTime[] {DateTime.MinValue} ;
         T000Y3_A271AgendaCalendarEndDate = new DateTime[] {DateTime.MinValue} ;
         T000Y3_A441AgendaCalendarType = new string[] {""} ;
         T000Y3_A272AgendaCalendarAllDay = new bool[] {false} ;
         T000Y3_A437AgendaCalendarRecurring = new bool[] {false} ;
         T000Y3_A438AgendaCalendarRecurringType = new string[] {""} ;
         T000Y3_A439AgendaCalendarAddRSVP = new bool[] {false} ;
         T000Y3_A661AgendaCalendarLocationEvent = new bool[] {false} ;
         T000Y3_n661AgendaCalendarLocationEvent = new bool[] {false} ;
         T000Y3_A29LocationId = new Guid[] {Guid.Empty} ;
         T000Y3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         sMode50 = "";
         T000Y8_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         T000Y9_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         T000Y2_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         T000Y2_A269AgendaCalendarTitle = new string[] {""} ;
         T000Y2_A270AgendaCalendarStartDate = new DateTime[] {DateTime.MinValue} ;
         T000Y2_A271AgendaCalendarEndDate = new DateTime[] {DateTime.MinValue} ;
         T000Y2_A441AgendaCalendarType = new string[] {""} ;
         T000Y2_A272AgendaCalendarAllDay = new bool[] {false} ;
         T000Y2_A437AgendaCalendarRecurring = new bool[] {false} ;
         T000Y2_A438AgendaCalendarRecurringType = new string[] {""} ;
         T000Y2_A439AgendaCalendarAddRSVP = new bool[] {false} ;
         T000Y2_A661AgendaCalendarLocationEvent = new bool[] {false} ;
         T000Y2_n661AgendaCalendarLocationEvent = new bool[] {false} ;
         T000Y2_A29LocationId = new Guid[] {Guid.Empty} ;
         T000Y2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000Y13_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         T000Y13_A62ResidentId = new Guid[] {Guid.Empty} ;
         T000Y14_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i29LocationId = Guid.Empty;
         i11OrganisationId = Guid.Empty;
         GXt_guid1 = Guid.Empty;
         ZZ268AgendaCalendarId = Guid.Empty;
         ZZ29LocationId = Guid.Empty;
         ZZ11OrganisationId = Guid.Empty;
         ZZ269AgendaCalendarTitle = "";
         ZZ270AgendaCalendarStartDate = (DateTime)(DateTime.MinValue);
         ZZ271AgendaCalendarEndDate = (DateTime)(DateTime.MinValue);
         ZZ441AgendaCalendarType = "";
         ZZ438AgendaCalendarRecurringType = "";
         T000Y15_A29LocationId = new Guid[] {Guid.Empty} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_agendacalendar__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_agendacalendar__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_agendacalendar__default(),
            new Object[][] {
                new Object[] {
               T000Y2_A268AgendaCalendarId, T000Y2_A269AgendaCalendarTitle, T000Y2_A270AgendaCalendarStartDate, T000Y2_A271AgendaCalendarEndDate, T000Y2_A441AgendaCalendarType, T000Y2_A272AgendaCalendarAllDay, T000Y2_A437AgendaCalendarRecurring, T000Y2_A438AgendaCalendarRecurringType, T000Y2_A439AgendaCalendarAddRSVP, T000Y2_A661AgendaCalendarLocationEvent,
               T000Y2_n661AgendaCalendarLocationEvent, T000Y2_A29LocationId, T000Y2_A11OrganisationId
               }
               , new Object[] {
               T000Y3_A268AgendaCalendarId, T000Y3_A269AgendaCalendarTitle, T000Y3_A270AgendaCalendarStartDate, T000Y3_A271AgendaCalendarEndDate, T000Y3_A441AgendaCalendarType, T000Y3_A272AgendaCalendarAllDay, T000Y3_A437AgendaCalendarRecurring, T000Y3_A438AgendaCalendarRecurringType, T000Y3_A439AgendaCalendarAddRSVP, T000Y3_A661AgendaCalendarLocationEvent,
               T000Y3_n661AgendaCalendarLocationEvent, T000Y3_A29LocationId, T000Y3_A11OrganisationId
               }
               , new Object[] {
               T000Y4_A29LocationId
               }
               , new Object[] {
               T000Y5_A268AgendaCalendarId, T000Y5_A269AgendaCalendarTitle, T000Y5_A270AgendaCalendarStartDate, T000Y5_A271AgendaCalendarEndDate, T000Y5_A441AgendaCalendarType, T000Y5_A272AgendaCalendarAllDay, T000Y5_A437AgendaCalendarRecurring, T000Y5_A438AgendaCalendarRecurringType, T000Y5_A439AgendaCalendarAddRSVP, T000Y5_A661AgendaCalendarLocationEvent,
               T000Y5_n661AgendaCalendarLocationEvent, T000Y5_A29LocationId, T000Y5_A11OrganisationId
               }
               , new Object[] {
               T000Y6_A29LocationId
               }
               , new Object[] {
               T000Y7_A268AgendaCalendarId
               }
               , new Object[] {
               T000Y8_A268AgendaCalendarId
               }
               , new Object[] {
               T000Y9_A268AgendaCalendarId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000Y13_A268AgendaCalendarId, T000Y13_A62ResidentId
               }
               , new Object[] {
               T000Y14_A268AgendaCalendarId
               }
               , new Object[] {
               T000Y15_A29LocationId
               }
            }
         );
         Z661AgendaCalendarLocationEvent = true;
         n661AgendaCalendarLocationEvent = false;
         A661AgendaCalendarLocationEvent = true;
         n661AgendaCalendarLocationEvent = false;
         i661AgendaCalendarLocationEvent = true;
         n661AgendaCalendarLocationEvent = false;
         Z268AgendaCalendarId = Guid.NewGuid( );
         A268AgendaCalendarId = Guid.NewGuid( );
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound50 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtAgendaCalendarId_Enabled ;
      private int edtLocationId_Enabled ;
      private int edtOrganisationId_Enabled ;
      private int edtAgendaCalendarTitle_Enabled ;
      private int edtAgendaCalendarStartDate_Enabled ;
      private int edtAgendaCalendarEndDate_Enabled ;
      private int edtAgendaCalendarRecurringType_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtAgendaCalendarId_Internalname ;
      private string cmbAgendaCalendarType_Internalname ;
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
      private string edtLocationId_Internalname ;
      private string edtLocationId_Jsonclick ;
      private string edtOrganisationId_Internalname ;
      private string edtOrganisationId_Jsonclick ;
      private string edtAgendaCalendarTitle_Internalname ;
      private string edtAgendaCalendarTitle_Jsonclick ;
      private string edtAgendaCalendarStartDate_Internalname ;
      private string edtAgendaCalendarStartDate_Jsonclick ;
      private string edtAgendaCalendarEndDate_Internalname ;
      private string edtAgendaCalendarEndDate_Jsonclick ;
      private string cmbAgendaCalendarType_Jsonclick ;
      private string chkAgendaCalendarAllDay_Internalname ;
      private string chkAgendaCalendarRecurring_Internalname ;
      private string edtAgendaCalendarRecurringType_Internalname ;
      private string edtAgendaCalendarRecurringType_Jsonclick ;
      private string chkAgendaCalendarAddRSVP_Internalname ;
      private string chkAgendaCalendarLocationEvent_Internalname ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode50 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z270AgendaCalendarStartDate ;
      private DateTime Z271AgendaCalendarEndDate ;
      private DateTime A270AgendaCalendarStartDate ;
      private DateTime A271AgendaCalendarEndDate ;
      private DateTime ZZ270AgendaCalendarStartDate ;
      private DateTime ZZ271AgendaCalendarEndDate ;
      private bool Z272AgendaCalendarAllDay ;
      private bool Z437AgendaCalendarRecurring ;
      private bool Z439AgendaCalendarAddRSVP ;
      private bool Z661AgendaCalendarLocationEvent ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A272AgendaCalendarAllDay ;
      private bool A437AgendaCalendarRecurring ;
      private bool A439AgendaCalendarAddRSVP ;
      private bool A661AgendaCalendarLocationEvent ;
      private bool n661AgendaCalendarLocationEvent ;
      private bool Gx_longc ;
      private bool i661AgendaCalendarLocationEvent ;
      private bool ZZ272AgendaCalendarAllDay ;
      private bool ZZ437AgendaCalendarRecurring ;
      private bool ZZ439AgendaCalendarAddRSVP ;
      private bool ZZ661AgendaCalendarLocationEvent ;
      private string Z269AgendaCalendarTitle ;
      private string Z441AgendaCalendarType ;
      private string Z438AgendaCalendarRecurringType ;
      private string A441AgendaCalendarType ;
      private string A269AgendaCalendarTitle ;
      private string A438AgendaCalendarRecurringType ;
      private string ZZ269AgendaCalendarTitle ;
      private string ZZ441AgendaCalendarType ;
      private string ZZ438AgendaCalendarRecurringType ;
      private Guid Z268AgendaCalendarId ;
      private Guid Z29LocationId ;
      private Guid Z11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A268AgendaCalendarId ;
      private Guid i29LocationId ;
      private Guid i11OrganisationId ;
      private Guid GXt_guid1 ;
      private Guid ZZ268AgendaCalendarId ;
      private Guid ZZ29LocationId ;
      private Guid ZZ11OrganisationId ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbAgendaCalendarType ;
      private GXCheckbox chkAgendaCalendarAllDay ;
      private GXCheckbox chkAgendaCalendarRecurring ;
      private GXCheckbox chkAgendaCalendarAddRSVP ;
      private GXCheckbox chkAgendaCalendarLocationEvent ;
      private IDataStoreProvider pr_default ;
      private Guid[] T000Y5_A268AgendaCalendarId ;
      private string[] T000Y5_A269AgendaCalendarTitle ;
      private DateTime[] T000Y5_A270AgendaCalendarStartDate ;
      private DateTime[] T000Y5_A271AgendaCalendarEndDate ;
      private string[] T000Y5_A441AgendaCalendarType ;
      private bool[] T000Y5_A272AgendaCalendarAllDay ;
      private bool[] T000Y5_A437AgendaCalendarRecurring ;
      private string[] T000Y5_A438AgendaCalendarRecurringType ;
      private bool[] T000Y5_A439AgendaCalendarAddRSVP ;
      private bool[] T000Y5_A661AgendaCalendarLocationEvent ;
      private bool[] T000Y5_n661AgendaCalendarLocationEvent ;
      private Guid[] T000Y5_A29LocationId ;
      private Guid[] T000Y5_A11OrganisationId ;
      private Guid[] T000Y4_A29LocationId ;
      private Guid[] T000Y6_A29LocationId ;
      private Guid[] T000Y7_A268AgendaCalendarId ;
      private Guid[] T000Y3_A268AgendaCalendarId ;
      private string[] T000Y3_A269AgendaCalendarTitle ;
      private DateTime[] T000Y3_A270AgendaCalendarStartDate ;
      private DateTime[] T000Y3_A271AgendaCalendarEndDate ;
      private string[] T000Y3_A441AgendaCalendarType ;
      private bool[] T000Y3_A272AgendaCalendarAllDay ;
      private bool[] T000Y3_A437AgendaCalendarRecurring ;
      private string[] T000Y3_A438AgendaCalendarRecurringType ;
      private bool[] T000Y3_A439AgendaCalendarAddRSVP ;
      private bool[] T000Y3_A661AgendaCalendarLocationEvent ;
      private bool[] T000Y3_n661AgendaCalendarLocationEvent ;
      private Guid[] T000Y3_A29LocationId ;
      private Guid[] T000Y3_A11OrganisationId ;
      private Guid[] T000Y8_A268AgendaCalendarId ;
      private Guid[] T000Y9_A268AgendaCalendarId ;
      private Guid[] T000Y2_A268AgendaCalendarId ;
      private string[] T000Y2_A269AgendaCalendarTitle ;
      private DateTime[] T000Y2_A270AgendaCalendarStartDate ;
      private DateTime[] T000Y2_A271AgendaCalendarEndDate ;
      private string[] T000Y2_A441AgendaCalendarType ;
      private bool[] T000Y2_A272AgendaCalendarAllDay ;
      private bool[] T000Y2_A437AgendaCalendarRecurring ;
      private string[] T000Y2_A438AgendaCalendarRecurringType ;
      private bool[] T000Y2_A439AgendaCalendarAddRSVP ;
      private bool[] T000Y2_A661AgendaCalendarLocationEvent ;
      private bool[] T000Y2_n661AgendaCalendarLocationEvent ;
      private Guid[] T000Y2_A29LocationId ;
      private Guid[] T000Y2_A11OrganisationId ;
      private Guid[] T000Y13_A268AgendaCalendarId ;
      private Guid[] T000Y13_A62ResidentId ;
      private Guid[] T000Y14_A268AgendaCalendarId ;
      private Guid[] T000Y15_A29LocationId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_agendacalendar__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_agendacalendar__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_agendacalendar__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmT000Y2;
       prmT000Y2 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Y3;
       prmT000Y3 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Y4;
       prmT000Y4 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Y5;
       prmT000Y5 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Y6;
       prmT000Y6 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Y7;
       prmT000Y7 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Y8;
       prmT000Y8 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Y9;
       prmT000Y9 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Y10;
       prmT000Y10 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AgendaCalendarTitle",GXType.VarChar,100,0) ,
       new ParDef("AgendaCalendarStartDate",GXType.DateTime,8,5) ,
       new ParDef("AgendaCalendarEndDate",GXType.DateTime,8,5) ,
       new ParDef("AgendaCalendarType",GXType.VarChar,40,0) ,
       new ParDef("AgendaCalendarAllDay",GXType.Boolean,4,0) ,
       new ParDef("AgendaCalendarRecurring",GXType.Boolean,4,0) ,
       new ParDef("AgendaCalendarRecurringType",GXType.VarChar,100,0) ,
       new ParDef("AgendaCalendarAddRSVP",GXType.Boolean,4,0) ,
       new ParDef("AgendaCalendarLocationEvent",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Y11;
       prmT000Y11 = new Object[] {
       new ParDef("AgendaCalendarTitle",GXType.VarChar,100,0) ,
       new ParDef("AgendaCalendarStartDate",GXType.DateTime,8,5) ,
       new ParDef("AgendaCalendarEndDate",GXType.DateTime,8,5) ,
       new ParDef("AgendaCalendarType",GXType.VarChar,40,0) ,
       new ParDef("AgendaCalendarAllDay",GXType.Boolean,4,0) ,
       new ParDef("AgendaCalendarRecurring",GXType.Boolean,4,0) ,
       new ParDef("AgendaCalendarRecurringType",GXType.VarChar,100,0) ,
       new ParDef("AgendaCalendarAddRSVP",GXType.Boolean,4,0) ,
       new ParDef("AgendaCalendarLocationEvent",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Y12;
       prmT000Y12 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Y13;
       prmT000Y13 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Y14;
       prmT000Y14 = new Object[] {
       };
       Object[] prmT000Y15;
       prmT000Y15 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("T000Y2", "SELECT AgendaCalendarId, AgendaCalendarTitle, AgendaCalendarStartDate, AgendaCalendarEndDate, AgendaCalendarType, AgendaCalendarAllDay, AgendaCalendarRecurring, AgendaCalendarRecurringType, AgendaCalendarAddRSVP, AgendaCalendarLocationEvent, LocationId, OrganisationId FROM Trn_AgendaCalendar WHERE AgendaCalendarId = :AgendaCalendarId  FOR UPDATE OF Trn_AgendaCalendar NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Y3", "SELECT AgendaCalendarId, AgendaCalendarTitle, AgendaCalendarStartDate, AgendaCalendarEndDate, AgendaCalendarType, AgendaCalendarAllDay, AgendaCalendarRecurring, AgendaCalendarRecurringType, AgendaCalendarAddRSVP, AgendaCalendarLocationEvent, LocationId, OrganisationId FROM Trn_AgendaCalendar WHERE AgendaCalendarId = :AgendaCalendarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Y4", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Y5", "SELECT TM1.AgendaCalendarId, TM1.AgendaCalendarTitle, TM1.AgendaCalendarStartDate, TM1.AgendaCalendarEndDate, TM1.AgendaCalendarType, TM1.AgendaCalendarAllDay, TM1.AgendaCalendarRecurring, TM1.AgendaCalendarRecurringType, TM1.AgendaCalendarAddRSVP, TM1.AgendaCalendarLocationEvent, TM1.LocationId, TM1.OrganisationId FROM Trn_AgendaCalendar TM1 WHERE TM1.AgendaCalendarId = :AgendaCalendarId ORDER BY TM1.AgendaCalendarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y5,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Y6", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Y7", "SELECT AgendaCalendarId FROM Trn_AgendaCalendar WHERE AgendaCalendarId = :AgendaCalendarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Y8", "SELECT AgendaCalendarId FROM Trn_AgendaCalendar WHERE ( AgendaCalendarId > :AgendaCalendarId) ORDER BY AgendaCalendarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y8,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000Y9", "SELECT AgendaCalendarId FROM Trn_AgendaCalendar WHERE ( AgendaCalendarId < :AgendaCalendarId) ORDER BY AgendaCalendarId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y9,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000Y10", "SAVEPOINT gxupdate;INSERT INTO Trn_AgendaCalendar(AgendaCalendarId, AgendaCalendarTitle, AgendaCalendarStartDate, AgendaCalendarEndDate, AgendaCalendarType, AgendaCalendarAllDay, AgendaCalendarRecurring, AgendaCalendarRecurringType, AgendaCalendarAddRSVP, AgendaCalendarLocationEvent, LocationId, OrganisationId) VALUES(:AgendaCalendarId, :AgendaCalendarTitle, :AgendaCalendarStartDate, :AgendaCalendarEndDate, :AgendaCalendarType, :AgendaCalendarAllDay, :AgendaCalendarRecurring, :AgendaCalendarRecurringType, :AgendaCalendarAddRSVP, :AgendaCalendarLocationEvent, :LocationId, :OrganisationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Y10)
          ,new CursorDef("T000Y11", "SAVEPOINT gxupdate;UPDATE Trn_AgendaCalendar SET AgendaCalendarTitle=:AgendaCalendarTitle, AgendaCalendarStartDate=:AgendaCalendarStartDate, AgendaCalendarEndDate=:AgendaCalendarEndDate, AgendaCalendarType=:AgendaCalendarType, AgendaCalendarAllDay=:AgendaCalendarAllDay, AgendaCalendarRecurring=:AgendaCalendarRecurring, AgendaCalendarRecurringType=:AgendaCalendarRecurringType, AgendaCalendarAddRSVP=:AgendaCalendarAddRSVP, AgendaCalendarLocationEvent=:AgendaCalendarLocationEvent, LocationId=:LocationId, OrganisationId=:OrganisationId  WHERE AgendaCalendarId = :AgendaCalendarId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Y11)
          ,new CursorDef("T000Y12", "SAVEPOINT gxupdate;DELETE FROM Trn_AgendaCalendar  WHERE AgendaCalendarId = :AgendaCalendarId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Y12)
          ,new CursorDef("T000Y13", "SELECT AgendaCalendarId, ResidentId FROM Trn_AgendaEventGroup WHERE AgendaCalendarId = :AgendaCalendarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y13,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000Y14", "SELECT AgendaCalendarId FROM Trn_AgendaCalendar ORDER BY AgendaCalendarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y14,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Y15", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y15,1, GxCacheFrequency.OFF ,true,false )
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
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((bool[]) buf[5])[0] = rslt.getBool(6);
             ((bool[]) buf[6])[0] = rslt.getBool(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((bool[]) buf[10])[0] = rslt.wasNull(10);
             ((Guid[]) buf[11])[0] = rslt.getGuid(11);
             ((Guid[]) buf[12])[0] = rslt.getGuid(12);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((bool[]) buf[5])[0] = rslt.getBool(6);
             ((bool[]) buf[6])[0] = rslt.getBool(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((bool[]) buf[10])[0] = rslt.wasNull(10);
             ((Guid[]) buf[11])[0] = rslt.getGuid(11);
             ((Guid[]) buf[12])[0] = rslt.getGuid(12);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((bool[]) buf[5])[0] = rslt.getBool(6);
             ((bool[]) buf[6])[0] = rslt.getBool(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((bool[]) buf[10])[0] = rslt.wasNull(10);
             ((Guid[]) buf[11])[0] = rslt.getGuid(11);
             ((Guid[]) buf[12])[0] = rslt.getGuid(12);
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
