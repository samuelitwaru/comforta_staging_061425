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
   public class trn_residentnotification : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A486AppNotificationId = StringUtil.StrToGuid( GetPar( "AppNotificationId"));
            AssignAttri("", false, "A486AppNotificationId", A486AppNotificationId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A486AppNotificationId) ;
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
         Form.Meta.addItem("description", context.GetMessage( "Trn_Resident Notification", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtResidentNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_residentnotification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_residentnotification( IGxContext context )
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
            return "trn_residentnotification_Execute" ;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Trn_Resident Notification", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Trn_ResidentNotification.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ResidentNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ResidentNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ResidentNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ResidentNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Trn_ResidentNotification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentNotificationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentNotificationId_Internalname, context.GetMessage( "Notification Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentNotificationId_Internalname, A485ResidentNotificationId.ToString(), A485ResidentNotificationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentNotificationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentNotificationId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_ResidentNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAppNotificationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAppNotificationId_Internalname, context.GetMessage( "App Notification Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAppNotificationId_Internalname, A486AppNotificationId.ToString(), A486AppNotificationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAppNotificationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAppNotificationId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_ResidentNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAppNotificationDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAppNotificationDate_Internalname, context.GetMessage( "App Notification Date", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtAppNotificationDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtAppNotificationDate_Internalname, context.localUtil.TToC( A489AppNotificationDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A489AppNotificationDate, "99/99/9999 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAppNotificationDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAppNotificationDate_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_ResidentNotification.htm");
         GxWebStd.gx_bitmap( context, edtAppNotificationDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtAppNotificationDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_ResidentNotification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAppNotificationTitle_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAppNotificationTitle_Internalname, context.GetMessage( "App Notification Title", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAppNotificationTitle_Internalname, A487AppNotificationTitle, StringUtil.RTrim( context.localUtil.Format( A487AppNotificationTitle, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAppNotificationTitle_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAppNotificationTitle_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "GeneXusUnanimo\\Title", "start", true, "", "HLP_Trn_ResidentNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAppNotificationDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAppNotificationDescription_Internalname, context.GetMessage( "App Notification Description", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtAppNotificationDescription_Internalname, A488AppNotificationDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", 0, 1, edtAppNotificationDescription_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "GeneXusUnanimo\\Description", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_ResidentNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAppNotificationTopic_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAppNotificationTopic_Internalname, context.GetMessage( "App Notification Topic", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAppNotificationTopic_Internalname, A490AppNotificationTopic, StringUtil.RTrim( context.localUtil.Format( A490AppNotificationTopic, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAppNotificationTopic_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAppNotificationTopic_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_ResidentNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAppNotificationMetadata_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAppNotificationMetadata_Internalname, context.GetMessage( "App Notification Metadata", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtAppNotificationMetadata_Internalname, A498AppNotificationMetadata, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", 0, 1, edtAppNotificationMetadata_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_ResidentNotification.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentId_Internalname, A62ResidentId.ToString(), A62ResidentId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_ResidentNotification.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ResidentNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ResidentNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ResidentNotification.htm");
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
            Z485ResidentNotificationId = StringUtil.StrToGuid( cgiGet( "Z485ResidentNotificationId"));
            Z62ResidentId = StringUtil.StrToGuid( cgiGet( "Z62ResidentId"));
            Z486AppNotificationId = StringUtil.StrToGuid( cgiGet( "Z486AppNotificationId"));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( StringUtil.StrCmp(cgiGet( edtResidentNotificationId_Internalname), "") == 0 )
            {
               A485ResidentNotificationId = Guid.Empty;
               AssignAttri("", false, "A485ResidentNotificationId", A485ResidentNotificationId.ToString());
            }
            else
            {
               try
               {
                  A485ResidentNotificationId = StringUtil.StrToGuid( cgiGet( edtResidentNotificationId_Internalname));
                  AssignAttri("", false, "A485ResidentNotificationId", A485ResidentNotificationId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "RESIDENTNOTIFICATIONID");
                  AnyError = 1;
                  GX_FocusControl = edtResidentNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            if ( StringUtil.StrCmp(cgiGet( edtAppNotificationId_Internalname), "") == 0 )
            {
               A486AppNotificationId = Guid.Empty;
               AssignAttri("", false, "A486AppNotificationId", A486AppNotificationId.ToString());
            }
            else
            {
               try
               {
                  A486AppNotificationId = StringUtil.StrToGuid( cgiGet( edtAppNotificationId_Internalname));
                  AssignAttri("", false, "A486AppNotificationId", A486AppNotificationId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "APPNOTIFICATIONID");
                  AnyError = 1;
                  GX_FocusControl = edtAppNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            A489AppNotificationDate = context.localUtil.CToT( cgiGet( edtAppNotificationDate_Internalname));
            AssignAttri("", false, "A489AppNotificationDate", context.localUtil.TToC( A489AppNotificationDate, 10, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A487AppNotificationTitle = cgiGet( edtAppNotificationTitle_Internalname);
            AssignAttri("", false, "A487AppNotificationTitle", A487AppNotificationTitle);
            A488AppNotificationDescription = cgiGet( edtAppNotificationDescription_Internalname);
            AssignAttri("", false, "A488AppNotificationDescription", A488AppNotificationDescription);
            A490AppNotificationTopic = cgiGet( edtAppNotificationTopic_Internalname);
            AssignAttri("", false, "A490AppNotificationTopic", A490AppNotificationTopic);
            A498AppNotificationMetadata = cgiGet( edtAppNotificationMetadata_Internalname);
            n498AppNotificationMetadata = false;
            AssignAttri("", false, "A498AppNotificationMetadata", A498AppNotificationMetadata);
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
               A485ResidentNotificationId = StringUtil.StrToGuid( GetPar( "ResidentNotificationId"));
               AssignAttri("", false, "A485ResidentNotificationId", A485ResidentNotificationId.ToString());
               getEqualNoModal( ) ;
               if ( IsIns( )  && (Guid.Empty==A485ResidentNotificationId) && ( Gx_BScreen == 0 ) )
               {
                  A485ResidentNotificationId = Guid.NewGuid( );
                  AssignAttri("", false, "A485ResidentNotificationId", A485ResidentNotificationId.ToString());
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
               InitAll1F86( ) ;
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
         DisableAttributes1F86( ) ;
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

      protected void ResetCaption1F0( )
      {
      }

      protected void ZM1F86( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z62ResidentId = T001F3_A62ResidentId[0];
               Z486AppNotificationId = T001F3_A486AppNotificationId[0];
            }
            else
            {
               Z62ResidentId = A62ResidentId;
               Z486AppNotificationId = A486AppNotificationId;
            }
         }
         if ( GX_JID == -6 )
         {
            Z485ResidentNotificationId = A485ResidentNotificationId;
            Z62ResidentId = A62ResidentId;
            Z486AppNotificationId = A486AppNotificationId;
            Z489AppNotificationDate = A489AppNotificationDate;
            Z487AppNotificationTitle = A487AppNotificationTitle;
            Z488AppNotificationDescription = A488AppNotificationDescription;
            Z490AppNotificationTopic = A490AppNotificationTopic;
            Z498AppNotificationMetadata = A498AppNotificationMetadata;
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
         if ( IsIns( )  && (Guid.Empty==A485ResidentNotificationId) && ( Gx_BScreen == 0 ) )
         {
            A485ResidentNotificationId = Guid.NewGuid( );
            AssignAttri("", false, "A485ResidentNotificationId", A485ResidentNotificationId.ToString());
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

      protected void Load1F86( )
      {
         /* Using cursor T001F5 */
         pr_default.execute(3, new Object[] {A485ResidentNotificationId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound86 = 1;
            A489AppNotificationDate = T001F5_A489AppNotificationDate[0];
            AssignAttri("", false, "A489AppNotificationDate", context.localUtil.TToC( A489AppNotificationDate, 10, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A487AppNotificationTitle = T001F5_A487AppNotificationTitle[0];
            AssignAttri("", false, "A487AppNotificationTitle", A487AppNotificationTitle);
            A488AppNotificationDescription = T001F5_A488AppNotificationDescription[0];
            AssignAttri("", false, "A488AppNotificationDescription", A488AppNotificationDescription);
            A490AppNotificationTopic = T001F5_A490AppNotificationTopic[0];
            AssignAttri("", false, "A490AppNotificationTopic", A490AppNotificationTopic);
            A498AppNotificationMetadata = T001F5_A498AppNotificationMetadata[0];
            n498AppNotificationMetadata = T001F5_n498AppNotificationMetadata[0];
            AssignAttri("", false, "A498AppNotificationMetadata", A498AppNotificationMetadata);
            A62ResidentId = T001F5_A62ResidentId[0];
            AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
            A486AppNotificationId = T001F5_A486AppNotificationId[0];
            AssignAttri("", false, "A486AppNotificationId", A486AppNotificationId.ToString());
            ZM1F86( -6) ;
         }
         pr_default.close(3);
         OnLoadActions1F86( ) ;
      }

      protected void OnLoadActions1F86( )
      {
      }

      protected void CheckExtendedTable1F86( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T001F4 */
         pr_default.execute(2, new Object[] {A486AppNotificationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "App Notifications", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "APPNOTIFICATIONID");
            AnyError = 1;
            GX_FocusControl = edtAppNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A489AppNotificationDate = T001F4_A489AppNotificationDate[0];
         AssignAttri("", false, "A489AppNotificationDate", context.localUtil.TToC( A489AppNotificationDate, 10, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A487AppNotificationTitle = T001F4_A487AppNotificationTitle[0];
         AssignAttri("", false, "A487AppNotificationTitle", A487AppNotificationTitle);
         A488AppNotificationDescription = T001F4_A488AppNotificationDescription[0];
         AssignAttri("", false, "A488AppNotificationDescription", A488AppNotificationDescription);
         A490AppNotificationTopic = T001F4_A490AppNotificationTopic[0];
         AssignAttri("", false, "A490AppNotificationTopic", A490AppNotificationTopic);
         A498AppNotificationMetadata = T001F4_A498AppNotificationMetadata[0];
         n498AppNotificationMetadata = T001F4_n498AppNotificationMetadata[0];
         AssignAttri("", false, "A498AppNotificationMetadata", A498AppNotificationMetadata);
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors1F86( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_7( Guid A486AppNotificationId )
      {
         /* Using cursor T001F6 */
         pr_default.execute(4, new Object[] {A486AppNotificationId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "App Notifications", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "APPNOTIFICATIONID");
            AnyError = 1;
            GX_FocusControl = edtAppNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A489AppNotificationDate = T001F6_A489AppNotificationDate[0];
         AssignAttri("", false, "A489AppNotificationDate", context.localUtil.TToC( A489AppNotificationDate, 10, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A487AppNotificationTitle = T001F6_A487AppNotificationTitle[0];
         AssignAttri("", false, "A487AppNotificationTitle", A487AppNotificationTitle);
         A488AppNotificationDescription = T001F6_A488AppNotificationDescription[0];
         AssignAttri("", false, "A488AppNotificationDescription", A488AppNotificationDescription);
         A490AppNotificationTopic = T001F6_A490AppNotificationTopic[0];
         AssignAttri("", false, "A490AppNotificationTopic", A490AppNotificationTopic);
         A498AppNotificationMetadata = T001F6_A498AppNotificationMetadata[0];
         n498AppNotificationMetadata = T001F6_n498AppNotificationMetadata[0];
         AssignAttri("", false, "A498AppNotificationMetadata", A498AppNotificationMetadata);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( context.localUtil.TToC( A489AppNotificationDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "))+"\""+","+"\""+GXUtil.EncodeJSConstant( A487AppNotificationTitle)+"\""+","+"\""+GXUtil.EncodeJSConstant( A488AppNotificationDescription)+"\""+","+"\""+GXUtil.EncodeJSConstant( A490AppNotificationTopic)+"\""+","+"\""+GXUtil.EncodeJSConstant( A498AppNotificationMetadata)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey1F86( )
      {
         /* Using cursor T001F7 */
         pr_default.execute(5, new Object[] {A485ResidentNotificationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound86 = 1;
         }
         else
         {
            RcdFound86 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001F3 */
         pr_default.execute(1, new Object[] {A485ResidentNotificationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1F86( 6) ;
            RcdFound86 = 1;
            A485ResidentNotificationId = T001F3_A485ResidentNotificationId[0];
            AssignAttri("", false, "A485ResidentNotificationId", A485ResidentNotificationId.ToString());
            A62ResidentId = T001F3_A62ResidentId[0];
            AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
            A486AppNotificationId = T001F3_A486AppNotificationId[0];
            AssignAttri("", false, "A486AppNotificationId", A486AppNotificationId.ToString());
            Z485ResidentNotificationId = A485ResidentNotificationId;
            sMode86 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1F86( ) ;
            if ( AnyError == 1 )
            {
               RcdFound86 = 0;
               InitializeNonKey1F86( ) ;
            }
            Gx_mode = sMode86;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound86 = 0;
            InitializeNonKey1F86( ) ;
            sMode86 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode86;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1F86( ) ;
         if ( RcdFound86 == 0 )
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
         RcdFound86 = 0;
         /* Using cursor T001F8 */
         pr_default.execute(6, new Object[] {A485ResidentNotificationId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T001F8_A485ResidentNotificationId[0], A485ResidentNotificationId, 0) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T001F8_A485ResidentNotificationId[0], A485ResidentNotificationId, 0) > 0 ) ) )
            {
               A485ResidentNotificationId = T001F8_A485ResidentNotificationId[0];
               AssignAttri("", false, "A485ResidentNotificationId", A485ResidentNotificationId.ToString());
               RcdFound86 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound86 = 0;
         /* Using cursor T001F9 */
         pr_default.execute(7, new Object[] {A485ResidentNotificationId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T001F9_A485ResidentNotificationId[0], A485ResidentNotificationId, 0) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T001F9_A485ResidentNotificationId[0], A485ResidentNotificationId, 0) < 0 ) ) )
            {
               A485ResidentNotificationId = T001F9_A485ResidentNotificationId[0];
               AssignAttri("", false, "A485ResidentNotificationId", A485ResidentNotificationId.ToString());
               RcdFound86 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1F86( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtResidentNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1F86( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound86 == 1 )
            {
               if ( A485ResidentNotificationId != Z485ResidentNotificationId )
               {
                  A485ResidentNotificationId = Z485ResidentNotificationId;
                  AssignAttri("", false, "A485ResidentNotificationId", A485ResidentNotificationId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "RESIDENTNOTIFICATIONID");
                  AnyError = 1;
                  GX_FocusControl = edtResidentNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtResidentNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1F86( ) ;
                  GX_FocusControl = edtResidentNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A485ResidentNotificationId != Z485ResidentNotificationId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtResidentNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1F86( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "RESIDENTNOTIFICATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtResidentNotificationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtResidentNotificationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1F86( ) ;
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
         if ( A485ResidentNotificationId != Z485ResidentNotificationId )
         {
            A485ResidentNotificationId = Z485ResidentNotificationId;
            AssignAttri("", false, "A485ResidentNotificationId", A485ResidentNotificationId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "RESIDENTNOTIFICATIONID");
            AnyError = 1;
            GX_FocusControl = edtResidentNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtResidentNotificationId_Internalname;
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
         if ( RcdFound86 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "RESIDENTNOTIFICATIONID");
            AnyError = 1;
            GX_FocusControl = edtResidentNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtAppNotificationId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1F86( ) ;
         if ( RcdFound86 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAppNotificationId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1F86( ) ;
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
         if ( RcdFound86 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAppNotificationId_Internalname;
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
         if ( RcdFound86 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAppNotificationId_Internalname;
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
         ScanStart1F86( ) ;
         if ( RcdFound86 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound86 != 0 )
            {
               ScanNext1F86( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAppNotificationId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1F86( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1F86( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001F2 */
            pr_default.execute(0, new Object[] {A485ResidentNotificationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ResidentNotification"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z62ResidentId != T001F2_A62ResidentId[0] ) || ( Z486AppNotificationId != T001F2_A486AppNotificationId[0] ) )
            {
               if ( Z62ResidentId != T001F2_A62ResidentId[0] )
               {
                  GXUtil.WriteLog("trn_residentnotification:[seudo value changed for attri]"+"ResidentId");
                  GXUtil.WriteLogRaw("Old: ",Z62ResidentId);
                  GXUtil.WriteLogRaw("Current: ",T001F2_A62ResidentId[0]);
               }
               if ( Z486AppNotificationId != T001F2_A486AppNotificationId[0] )
               {
                  GXUtil.WriteLog("trn_residentnotification:[seudo value changed for attri]"+"AppNotificationId");
                  GXUtil.WriteLogRaw("Old: ",Z486AppNotificationId);
                  GXUtil.WriteLogRaw("Current: ",T001F2_A486AppNotificationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_ResidentNotification"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1F86( )
      {
         if ( ! IsAuthorized("trn_residentnotification_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1F86( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1F86( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1F86( 0) ;
            CheckOptimisticConcurrency1F86( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1F86( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1F86( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001F10 */
                     pr_default.execute(8, new Object[] {A485ResidentNotificationId, A62ResidentId, A486AppNotificationId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ResidentNotification");
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
                           ResetCaption1F0( ) ;
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
               Load1F86( ) ;
            }
            EndLevel1F86( ) ;
         }
         CloseExtendedTableCursors1F86( ) ;
      }

      protected void Update1F86( )
      {
         if ( ! IsAuthorized("trn_residentnotification_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1F86( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1F86( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1F86( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1F86( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1F86( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001F11 */
                     pr_default.execute(9, new Object[] {A62ResidentId, A486AppNotificationId, A485ResidentNotificationId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ResidentNotification");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ResidentNotification"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1F86( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1F0( ) ;
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
            EndLevel1F86( ) ;
         }
         CloseExtendedTableCursors1F86( ) ;
      }

      protected void DeferredUpdate1F86( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_residentnotification_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1F86( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1F86( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1F86( ) ;
            AfterConfirm1F86( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1F86( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001F12 */
                  pr_default.execute(10, new Object[] {A485ResidentNotificationId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ResidentNotification");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound86 == 0 )
                        {
                           InitAll1F86( ) ;
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
                        ResetCaption1F0( ) ;
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
         sMode86 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1F86( ) ;
         Gx_mode = sMode86;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1F86( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001F13 */
            pr_default.execute(11, new Object[] {A486AppNotificationId});
            A489AppNotificationDate = T001F13_A489AppNotificationDate[0];
            AssignAttri("", false, "A489AppNotificationDate", context.localUtil.TToC( A489AppNotificationDate, 10, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A487AppNotificationTitle = T001F13_A487AppNotificationTitle[0];
            AssignAttri("", false, "A487AppNotificationTitle", A487AppNotificationTitle);
            A488AppNotificationDescription = T001F13_A488AppNotificationDescription[0];
            AssignAttri("", false, "A488AppNotificationDescription", A488AppNotificationDescription);
            A490AppNotificationTopic = T001F13_A490AppNotificationTopic[0];
            AssignAttri("", false, "A490AppNotificationTopic", A490AppNotificationTopic);
            A498AppNotificationMetadata = T001F13_A498AppNotificationMetadata[0];
            n498AppNotificationMetadata = T001F13_n498AppNotificationMetadata[0];
            AssignAttri("", false, "A498AppNotificationMetadata", A498AppNotificationMetadata);
            pr_default.close(11);
         }
      }

      protected void EndLevel1F86( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1F86( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_residentnotification",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1F0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_residentnotification",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1F86( )
      {
         /* Using cursor T001F14 */
         pr_default.execute(12);
         RcdFound86 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound86 = 1;
            A485ResidentNotificationId = T001F14_A485ResidentNotificationId[0];
            AssignAttri("", false, "A485ResidentNotificationId", A485ResidentNotificationId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1F86( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound86 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound86 = 1;
            A485ResidentNotificationId = T001F14_A485ResidentNotificationId[0];
            AssignAttri("", false, "A485ResidentNotificationId", A485ResidentNotificationId.ToString());
         }
      }

      protected void ScanEnd1F86( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm1F86( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1F86( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1F86( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1F86( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1F86( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1F86( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1F86( )
      {
         edtResidentNotificationId_Enabled = 0;
         AssignProp("", false, edtResidentNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentNotificationId_Enabled), 5, 0), true);
         edtAppNotificationId_Enabled = 0;
         AssignProp("", false, edtAppNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAppNotificationId_Enabled), 5, 0), true);
         edtAppNotificationDate_Enabled = 0;
         AssignProp("", false, edtAppNotificationDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAppNotificationDate_Enabled), 5, 0), true);
         edtAppNotificationTitle_Enabled = 0;
         AssignProp("", false, edtAppNotificationTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAppNotificationTitle_Enabled), 5, 0), true);
         edtAppNotificationDescription_Enabled = 0;
         AssignProp("", false, edtAppNotificationDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAppNotificationDescription_Enabled), 5, 0), true);
         edtAppNotificationTopic_Enabled = 0;
         AssignProp("", false, edtAppNotificationTopic_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAppNotificationTopic_Enabled), 5, 0), true);
         edtAppNotificationMetadata_Enabled = 0;
         AssignProp("", false, edtAppNotificationMetadata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAppNotificationMetadata_Enabled), 5, 0), true);
         edtResidentId_Enabled = 0;
         AssignProp("", false, edtResidentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1F86( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1F0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_residentnotification.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z485ResidentNotificationId", Z485ResidentNotificationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z62ResidentId", Z62ResidentId.ToString());
         GxWebStd.gx_hidden_field( context, "Z486AppNotificationId", Z486AppNotificationId.ToString());
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
         return formatLink("trn_residentnotification.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_ResidentNotification" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Resident Notification", "") ;
      }

      protected void InitializeNonKey1F86( )
      {
         A486AppNotificationId = Guid.Empty;
         AssignAttri("", false, "A486AppNotificationId", A486AppNotificationId.ToString());
         A489AppNotificationDate = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A489AppNotificationDate", context.localUtil.TToC( A489AppNotificationDate, 10, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A487AppNotificationTitle = "";
         AssignAttri("", false, "A487AppNotificationTitle", A487AppNotificationTitle);
         A488AppNotificationDescription = "";
         AssignAttri("", false, "A488AppNotificationDescription", A488AppNotificationDescription);
         A490AppNotificationTopic = "";
         AssignAttri("", false, "A490AppNotificationTopic", A490AppNotificationTopic);
         A498AppNotificationMetadata = "";
         n498AppNotificationMetadata = false;
         AssignAttri("", false, "A498AppNotificationMetadata", A498AppNotificationMetadata);
         A62ResidentId = Guid.NewGuid( );
         AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
         Z62ResidentId = Guid.Empty;
         Z486AppNotificationId = Guid.Empty;
      }

      protected void InitAll1F86( )
      {
         A485ResidentNotificationId = Guid.NewGuid( );
         AssignAttri("", false, "A485ResidentNotificationId", A485ResidentNotificationId.ToString());
         InitializeNonKey1F86( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A62ResidentId = i62ResidentId;
         AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20257212512237", true, true);
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
         context.AddJavascriptSource("trn_residentnotification.js", "?20257212512237", false, true);
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
         edtResidentNotificationId_Internalname = "RESIDENTNOTIFICATIONID";
         edtAppNotificationId_Internalname = "APPNOTIFICATIONID";
         edtAppNotificationDate_Internalname = "APPNOTIFICATIONDATE";
         edtAppNotificationTitle_Internalname = "APPNOTIFICATIONTITLE";
         edtAppNotificationDescription_Internalname = "APPNOTIFICATIONDESCRIPTION";
         edtAppNotificationTopic_Internalname = "APPNOTIFICATIONTOPIC";
         edtAppNotificationMetadata_Internalname = "APPNOTIFICATIONMETADATA";
         edtResidentId_Internalname = "RESIDENTID";
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
         Form.Caption = context.GetMessage( "Trn_Resident Notification", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtResidentId_Jsonclick = "";
         edtResidentId_Enabled = 1;
         edtAppNotificationMetadata_Enabled = 0;
         edtAppNotificationTopic_Jsonclick = "";
         edtAppNotificationTopic_Enabled = 0;
         edtAppNotificationDescription_Enabled = 0;
         edtAppNotificationTitle_Jsonclick = "";
         edtAppNotificationTitle_Enabled = 0;
         edtAppNotificationDate_Jsonclick = "";
         edtAppNotificationDate_Enabled = 0;
         edtAppNotificationId_Jsonclick = "";
         edtAppNotificationId_Enabled = 1;
         edtResidentNotificationId_Jsonclick = "";
         edtResidentNotificationId_Enabled = 1;
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
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtAppNotificationId_Internalname;
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

      public void Valid_Residentnotificationid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A486AppNotificationId", A486AppNotificationId.ToString());
         AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
         AssignAttri("", false, "A489AppNotificationDate", context.localUtil.TToC( A489AppNotificationDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A487AppNotificationTitle", A487AppNotificationTitle);
         AssignAttri("", false, "A488AppNotificationDescription", A488AppNotificationDescription);
         AssignAttri("", false, "A490AppNotificationTopic", A490AppNotificationTopic);
         AssignAttri("", false, "A498AppNotificationMetadata", A498AppNotificationMetadata);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z485ResidentNotificationId", Z485ResidentNotificationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z486AppNotificationId", Z486AppNotificationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z62ResidentId", Z62ResidentId.ToString());
         GxWebStd.gx_hidden_field( context, "Z489AppNotificationDate", context.localUtil.TToC( Z489AppNotificationDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z487AppNotificationTitle", Z487AppNotificationTitle);
         GxWebStd.gx_hidden_field( context, "Z488AppNotificationDescription", Z488AppNotificationDescription);
         GxWebStd.gx_hidden_field( context, "Z490AppNotificationTopic", Z490AppNotificationTopic);
         GxWebStd.gx_hidden_field( context, "Z498AppNotificationMetadata", Z498AppNotificationMetadata);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Appnotificationid( )
      {
         n498AppNotificationMetadata = false;
         /* Using cursor T001F13 */
         pr_default.execute(11, new Object[] {A486AppNotificationId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "App Notifications", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "APPNOTIFICATIONID");
            AnyError = 1;
            GX_FocusControl = edtAppNotificationId_Internalname;
         }
         A489AppNotificationDate = T001F13_A489AppNotificationDate[0];
         A487AppNotificationTitle = T001F13_A487AppNotificationTitle[0];
         A488AppNotificationDescription = T001F13_A488AppNotificationDescription[0];
         A490AppNotificationTopic = T001F13_A490AppNotificationTopic[0];
         A498AppNotificationMetadata = T001F13_A498AppNotificationMetadata[0];
         n498AppNotificationMetadata = T001F13_n498AppNotificationMetadata[0];
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A489AppNotificationDate", context.localUtil.TToC( A489AppNotificationDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A487AppNotificationTitle", A487AppNotificationTitle);
         AssignAttri("", false, "A488AppNotificationDescription", A488AppNotificationDescription);
         AssignAttri("", false, "A490AppNotificationTopic", A490AppNotificationTopic);
         AssignAttri("", false, "A498AppNotificationMetadata", A498AppNotificationMetadata);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("VALID_RESIDENTNOTIFICATIONID","""{"handler":"Valid_Residentnotificationid","iparms":[{"av":"A485ResidentNotificationId","fld":"RESIDENTNOTIFICATIONID"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"A62ResidentId","fld":"RESIDENTID"}]""");
         setEventMetadata("VALID_RESIDENTNOTIFICATIONID",""","oparms":[{"av":"A486AppNotificationId","fld":"APPNOTIFICATIONID"},{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"A489AppNotificationDate","fld":"APPNOTIFICATIONDATE","pic":"99/99/9999 99:99"},{"av":"A487AppNotificationTitle","fld":"APPNOTIFICATIONTITLE"},{"av":"A488AppNotificationDescription","fld":"APPNOTIFICATIONDESCRIPTION"},{"av":"A490AppNotificationTopic","fld":"APPNOTIFICATIONTOPIC"},{"av":"A498AppNotificationMetadata","fld":"APPNOTIFICATIONMETADATA"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z485ResidentNotificationId"},{"av":"Z486AppNotificationId"},{"av":"Z62ResidentId"},{"av":"Z489AppNotificationDate"},{"av":"Z487AppNotificationTitle"},{"av":"Z488AppNotificationDescription"},{"av":"Z490AppNotificationTopic"},{"av":"Z498AppNotificationMetadata"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_APPNOTIFICATIONID","""{"handler":"Valid_Appnotificationid","iparms":[{"av":"A486AppNotificationId","fld":"APPNOTIFICATIONID"},{"av":"A489AppNotificationDate","fld":"APPNOTIFICATIONDATE","pic":"99/99/9999 99:99"},{"av":"A487AppNotificationTitle","fld":"APPNOTIFICATIONTITLE"},{"av":"A488AppNotificationDescription","fld":"APPNOTIFICATIONDESCRIPTION"},{"av":"A490AppNotificationTopic","fld":"APPNOTIFICATIONTOPIC"},{"av":"A498AppNotificationMetadata","fld":"APPNOTIFICATIONMETADATA"}]""");
         setEventMetadata("VALID_APPNOTIFICATIONID",""","oparms":[{"av":"A489AppNotificationDate","fld":"APPNOTIFICATIONDATE","pic":"99/99/9999 99:99"},{"av":"A487AppNotificationTitle","fld":"APPNOTIFICATIONTITLE"},{"av":"A488AppNotificationDescription","fld":"APPNOTIFICATIONDESCRIPTION"},{"av":"A490AppNotificationTopic","fld":"APPNOTIFICATIONTOPIC"},{"av":"A498AppNotificationMetadata","fld":"APPNOTIFICATIONMETADATA"}]}""");
         setEventMetadata("VALID_RESIDENTID","""{"handler":"Valid_Residentid","iparms":[]}""");
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z485ResidentNotificationId = Guid.Empty;
         Z62ResidentId = Guid.Empty;
         Z486AppNotificationId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A486AppNotificationId = Guid.Empty;
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
         A485ResidentNotificationId = Guid.Empty;
         A489AppNotificationDate = (DateTime)(DateTime.MinValue);
         A487AppNotificationTitle = "";
         A488AppNotificationDescription = "";
         A490AppNotificationTopic = "";
         A498AppNotificationMetadata = "";
         A62ResidentId = Guid.Empty;
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
         Z489AppNotificationDate = (DateTime)(DateTime.MinValue);
         Z487AppNotificationTitle = "";
         Z488AppNotificationDescription = "";
         Z490AppNotificationTopic = "";
         Z498AppNotificationMetadata = "";
         T001F5_A485ResidentNotificationId = new Guid[] {Guid.Empty} ;
         T001F5_A489AppNotificationDate = new DateTime[] {DateTime.MinValue} ;
         T001F5_A487AppNotificationTitle = new string[] {""} ;
         T001F5_A488AppNotificationDescription = new string[] {""} ;
         T001F5_A490AppNotificationTopic = new string[] {""} ;
         T001F5_A498AppNotificationMetadata = new string[] {""} ;
         T001F5_n498AppNotificationMetadata = new bool[] {false} ;
         T001F5_A62ResidentId = new Guid[] {Guid.Empty} ;
         T001F5_A486AppNotificationId = new Guid[] {Guid.Empty} ;
         T001F4_A489AppNotificationDate = new DateTime[] {DateTime.MinValue} ;
         T001F4_A487AppNotificationTitle = new string[] {""} ;
         T001F4_A488AppNotificationDescription = new string[] {""} ;
         T001F4_A490AppNotificationTopic = new string[] {""} ;
         T001F4_A498AppNotificationMetadata = new string[] {""} ;
         T001F4_n498AppNotificationMetadata = new bool[] {false} ;
         T001F6_A489AppNotificationDate = new DateTime[] {DateTime.MinValue} ;
         T001F6_A487AppNotificationTitle = new string[] {""} ;
         T001F6_A488AppNotificationDescription = new string[] {""} ;
         T001F6_A490AppNotificationTopic = new string[] {""} ;
         T001F6_A498AppNotificationMetadata = new string[] {""} ;
         T001F6_n498AppNotificationMetadata = new bool[] {false} ;
         T001F7_A485ResidentNotificationId = new Guid[] {Guid.Empty} ;
         T001F3_A485ResidentNotificationId = new Guid[] {Guid.Empty} ;
         T001F3_A62ResidentId = new Guid[] {Guid.Empty} ;
         T001F3_A486AppNotificationId = new Guid[] {Guid.Empty} ;
         sMode86 = "";
         T001F8_A485ResidentNotificationId = new Guid[] {Guid.Empty} ;
         T001F9_A485ResidentNotificationId = new Guid[] {Guid.Empty} ;
         T001F2_A485ResidentNotificationId = new Guid[] {Guid.Empty} ;
         T001F2_A62ResidentId = new Guid[] {Guid.Empty} ;
         T001F2_A486AppNotificationId = new Guid[] {Guid.Empty} ;
         T001F13_A489AppNotificationDate = new DateTime[] {DateTime.MinValue} ;
         T001F13_A487AppNotificationTitle = new string[] {""} ;
         T001F13_A488AppNotificationDescription = new string[] {""} ;
         T001F13_A490AppNotificationTopic = new string[] {""} ;
         T001F13_A498AppNotificationMetadata = new string[] {""} ;
         T001F13_n498AppNotificationMetadata = new bool[] {false} ;
         T001F14_A485ResidentNotificationId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i62ResidentId = Guid.Empty;
         ZZ485ResidentNotificationId = Guid.Empty;
         ZZ486AppNotificationId = Guid.Empty;
         ZZ62ResidentId = Guid.Empty;
         ZZ489AppNotificationDate = (DateTime)(DateTime.MinValue);
         ZZ487AppNotificationTitle = "";
         ZZ488AppNotificationDescription = "";
         ZZ490AppNotificationTopic = "";
         ZZ498AppNotificationMetadata = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_residentnotification__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_residentnotification__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_residentnotification__default(),
            new Object[][] {
                new Object[] {
               T001F2_A485ResidentNotificationId, T001F2_A62ResidentId, T001F2_A486AppNotificationId
               }
               , new Object[] {
               T001F3_A485ResidentNotificationId, T001F3_A62ResidentId, T001F3_A486AppNotificationId
               }
               , new Object[] {
               T001F4_A489AppNotificationDate, T001F4_A487AppNotificationTitle, T001F4_A488AppNotificationDescription, T001F4_A490AppNotificationTopic, T001F4_A498AppNotificationMetadata, T001F4_n498AppNotificationMetadata
               }
               , new Object[] {
               T001F5_A485ResidentNotificationId, T001F5_A489AppNotificationDate, T001F5_A487AppNotificationTitle, T001F5_A488AppNotificationDescription, T001F5_A490AppNotificationTopic, T001F5_A498AppNotificationMetadata, T001F5_n498AppNotificationMetadata, T001F5_A62ResidentId, T001F5_A486AppNotificationId
               }
               , new Object[] {
               T001F6_A489AppNotificationDate, T001F6_A487AppNotificationTitle, T001F6_A488AppNotificationDescription, T001F6_A490AppNotificationTopic, T001F6_A498AppNotificationMetadata, T001F6_n498AppNotificationMetadata
               }
               , new Object[] {
               T001F7_A485ResidentNotificationId
               }
               , new Object[] {
               T001F8_A485ResidentNotificationId
               }
               , new Object[] {
               T001F9_A485ResidentNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001F13_A489AppNotificationDate, T001F13_A487AppNotificationTitle, T001F13_A488AppNotificationDescription, T001F13_A490AppNotificationTopic, T001F13_A498AppNotificationMetadata, T001F13_n498AppNotificationMetadata
               }
               , new Object[] {
               T001F14_A485ResidentNotificationId
               }
            }
         );
         Z62ResidentId = Guid.NewGuid( );
         A62ResidentId = Guid.NewGuid( );
         i62ResidentId = Guid.NewGuid( );
         Z485ResidentNotificationId = Guid.NewGuid( );
         A485ResidentNotificationId = Guid.NewGuid( );
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound86 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtResidentNotificationId_Enabled ;
      private int edtAppNotificationId_Enabled ;
      private int edtAppNotificationDate_Enabled ;
      private int edtAppNotificationTitle_Enabled ;
      private int edtAppNotificationDescription_Enabled ;
      private int edtAppNotificationTopic_Enabled ;
      private int edtAppNotificationMetadata_Enabled ;
      private int edtResidentId_Enabled ;
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
      private string edtResidentNotificationId_Internalname ;
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
      private string edtResidentNotificationId_Jsonclick ;
      private string edtAppNotificationId_Internalname ;
      private string edtAppNotificationId_Jsonclick ;
      private string edtAppNotificationDate_Internalname ;
      private string edtAppNotificationDate_Jsonclick ;
      private string edtAppNotificationTitle_Internalname ;
      private string edtAppNotificationTitle_Jsonclick ;
      private string edtAppNotificationDescription_Internalname ;
      private string edtAppNotificationTopic_Internalname ;
      private string edtAppNotificationTopic_Jsonclick ;
      private string edtAppNotificationMetadata_Internalname ;
      private string edtResidentId_Internalname ;
      private string edtResidentId_Jsonclick ;
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
      private string sMode86 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime A489AppNotificationDate ;
      private DateTime Z489AppNotificationDate ;
      private DateTime ZZ489AppNotificationDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n498AppNotificationMetadata ;
      private string A498AppNotificationMetadata ;
      private string Z498AppNotificationMetadata ;
      private string ZZ498AppNotificationMetadata ;
      private string A487AppNotificationTitle ;
      private string A488AppNotificationDescription ;
      private string A490AppNotificationTopic ;
      private string Z487AppNotificationTitle ;
      private string Z488AppNotificationDescription ;
      private string Z490AppNotificationTopic ;
      private string ZZ487AppNotificationTitle ;
      private string ZZ488AppNotificationDescription ;
      private string ZZ490AppNotificationTopic ;
      private Guid Z485ResidentNotificationId ;
      private Guid Z62ResidentId ;
      private Guid Z486AppNotificationId ;
      private Guid A486AppNotificationId ;
      private Guid A485ResidentNotificationId ;
      private Guid A62ResidentId ;
      private Guid i62ResidentId ;
      private Guid ZZ485ResidentNotificationId ;
      private Guid ZZ486AppNotificationId ;
      private Guid ZZ62ResidentId ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] T001F5_A485ResidentNotificationId ;
      private DateTime[] T001F5_A489AppNotificationDate ;
      private string[] T001F5_A487AppNotificationTitle ;
      private string[] T001F5_A488AppNotificationDescription ;
      private string[] T001F5_A490AppNotificationTopic ;
      private string[] T001F5_A498AppNotificationMetadata ;
      private bool[] T001F5_n498AppNotificationMetadata ;
      private Guid[] T001F5_A62ResidentId ;
      private Guid[] T001F5_A486AppNotificationId ;
      private DateTime[] T001F4_A489AppNotificationDate ;
      private string[] T001F4_A487AppNotificationTitle ;
      private string[] T001F4_A488AppNotificationDescription ;
      private string[] T001F4_A490AppNotificationTopic ;
      private string[] T001F4_A498AppNotificationMetadata ;
      private bool[] T001F4_n498AppNotificationMetadata ;
      private DateTime[] T001F6_A489AppNotificationDate ;
      private string[] T001F6_A487AppNotificationTitle ;
      private string[] T001F6_A488AppNotificationDescription ;
      private string[] T001F6_A490AppNotificationTopic ;
      private string[] T001F6_A498AppNotificationMetadata ;
      private bool[] T001F6_n498AppNotificationMetadata ;
      private Guid[] T001F7_A485ResidentNotificationId ;
      private Guid[] T001F3_A485ResidentNotificationId ;
      private Guid[] T001F3_A62ResidentId ;
      private Guid[] T001F3_A486AppNotificationId ;
      private Guid[] T001F8_A485ResidentNotificationId ;
      private Guid[] T001F9_A485ResidentNotificationId ;
      private Guid[] T001F2_A485ResidentNotificationId ;
      private Guid[] T001F2_A62ResidentId ;
      private Guid[] T001F2_A486AppNotificationId ;
      private DateTime[] T001F13_A489AppNotificationDate ;
      private string[] T001F13_A487AppNotificationTitle ;
      private string[] T001F13_A488AppNotificationDescription ;
      private string[] T001F13_A490AppNotificationTopic ;
      private string[] T001F13_A498AppNotificationMetadata ;
      private bool[] T001F13_n498AppNotificationMetadata ;
      private Guid[] T001F14_A485ResidentNotificationId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_residentnotification__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_residentnotification__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_residentnotification__default : DataStoreHelperBase, IDataStoreHelper
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
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT001F2;
       prmT001F2 = new Object[] {
       new ParDef("ResidentNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001F3;
       prmT001F3 = new Object[] {
       new ParDef("ResidentNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001F4;
       prmT001F4 = new Object[] {
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001F5;
       prmT001F5 = new Object[] {
       new ParDef("ResidentNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001F6;
       prmT001F6 = new Object[] {
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001F7;
       prmT001F7 = new Object[] {
       new ParDef("ResidentNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001F8;
       prmT001F8 = new Object[] {
       new ParDef("ResidentNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001F9;
       prmT001F9 = new Object[] {
       new ParDef("ResidentNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001F10;
       prmT001F10 = new Object[] {
       new ParDef("ResidentNotificationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001F11;
       prmT001F11 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001F12;
       prmT001F12 = new Object[] {
       new ParDef("ResidentNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001F13;
       prmT001F13 = new Object[] {
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001F14;
       prmT001F14 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T001F2", "SELECT ResidentNotificationId, ResidentId, AppNotificationId FROM Trn_ResidentNotification WHERE ResidentNotificationId = :ResidentNotificationId  FOR UPDATE OF Trn_ResidentNotification NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001F2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001F3", "SELECT ResidentNotificationId, ResidentId, AppNotificationId FROM Trn_ResidentNotification WHERE ResidentNotificationId = :ResidentNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001F3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001F4", "SELECT AppNotificationDate, AppNotificationTitle, AppNotificationDescription, AppNotificationTopic, AppNotificationMetadata FROM Trn_AppNotification WHERE AppNotificationId = :AppNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001F4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001F5", "SELECT TM1.ResidentNotificationId, T2.AppNotificationDate, T2.AppNotificationTitle, T2.AppNotificationDescription, T2.AppNotificationTopic, T2.AppNotificationMetadata, TM1.ResidentId, TM1.AppNotificationId FROM (Trn_ResidentNotification TM1 INNER JOIN Trn_AppNotification T2 ON T2.AppNotificationId = TM1.AppNotificationId) WHERE TM1.ResidentNotificationId = :ResidentNotificationId ORDER BY TM1.ResidentNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001F5,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001F6", "SELECT AppNotificationDate, AppNotificationTitle, AppNotificationDescription, AppNotificationTopic, AppNotificationMetadata FROM Trn_AppNotification WHERE AppNotificationId = :AppNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001F6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001F7", "SELECT ResidentNotificationId FROM Trn_ResidentNotification WHERE ResidentNotificationId = :ResidentNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001F7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001F8", "SELECT ResidentNotificationId FROM Trn_ResidentNotification WHERE ( ResidentNotificationId > :ResidentNotificationId) ORDER BY ResidentNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001F8,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001F9", "SELECT ResidentNotificationId FROM Trn_ResidentNotification WHERE ( ResidentNotificationId < :ResidentNotificationId) ORDER BY ResidentNotificationId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001F9,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001F10", "SAVEPOINT gxupdate;INSERT INTO Trn_ResidentNotification(ResidentNotificationId, ResidentId, AppNotificationId) VALUES(:ResidentNotificationId, :ResidentId, :AppNotificationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001F10)
          ,new CursorDef("T001F11", "SAVEPOINT gxupdate;UPDATE Trn_ResidentNotification SET ResidentId=:ResidentId, AppNotificationId=:AppNotificationId  WHERE ResidentNotificationId = :ResidentNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001F11)
          ,new CursorDef("T001F12", "SAVEPOINT gxupdate;DELETE FROM Trn_ResidentNotification  WHERE ResidentNotificationId = :ResidentNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001F12)
          ,new CursorDef("T001F13", "SELECT AppNotificationDate, AppNotificationTitle, AppNotificationDescription, AppNotificationTopic, AppNotificationMetadata FROM Trn_AppNotification WHERE AppNotificationId = :AppNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001F13,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001F14", "SELECT ResidentNotificationId FROM Trn_ResidentNotification ORDER BY ResidentNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001F14,100, GxCacheFrequency.OFF ,true,false )
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
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 2 :
             ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((bool[]) buf[5])[0] = rslt.wasNull(5);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((bool[]) buf[6])[0] = rslt.wasNull(6);
             ((Guid[]) buf[7])[0] = rslt.getGuid(7);
             ((Guid[]) buf[8])[0] = rslt.getGuid(8);
             return;
          case 4 :
             ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((bool[]) buf[5])[0] = rslt.wasNull(5);
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
             ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((bool[]) buf[5])[0] = rslt.wasNull(5);
             return;
          case 12 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
