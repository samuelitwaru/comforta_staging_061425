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
   public class trn_appnotification : GXDataArea
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
         Form.Meta.addItem("description", context.GetMessage( "App Notification Definitions", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAppNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_appnotification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_appnotification( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "App Notification Definitions", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Trn_AppNotification.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AppNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AppNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AppNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AppNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Trn_AppNotification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAppNotificationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAppNotificationId_Internalname, context.GetMessage( "Notification Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAppNotificationId_Internalname, A486AppNotificationId.ToString(), A486AppNotificationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAppNotificationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAppNotificationId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_AppNotification.htm");
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
         GxWebStd.gx_label_element( context, edtAppNotificationTitle_Internalname, context.GetMessage( "Notification Title", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAppNotificationTitle_Internalname, A487AppNotificationTitle, StringUtil.RTrim( context.localUtil.Format( A487AppNotificationTitle, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAppNotificationTitle_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAppNotificationTitle_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "GeneXusUnanimo\\Title", "start", true, "", "HLP_Trn_AppNotification.htm");
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
         GxWebStd.gx_label_element( context, edtAppNotificationDescription_Internalname, context.GetMessage( "Notification Description", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtAppNotificationDescription_Internalname, A488AppNotificationDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtAppNotificationDescription_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "GeneXusUnanimo\\Description", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_AppNotification.htm");
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
         GxWebStd.gx_label_element( context, edtAppNotificationDate_Internalname, context.GetMessage( "Notification Date", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtAppNotificationDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtAppNotificationDate_Internalname, context.localUtil.TToC( A489AppNotificationDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A489AppNotificationDate, "99/99/9999 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAppNotificationDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAppNotificationDate_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_AppNotification.htm");
         GxWebStd.gx_bitmap( context, edtAppNotificationDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtAppNotificationDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_AppNotification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAppNotificationTopic_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAppNotificationTopic_Internalname, context.GetMessage( "Notification Topic", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAppNotificationTopic_Internalname, A490AppNotificationTopic, StringUtil.RTrim( context.localUtil.Format( A490AppNotificationTopic, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAppNotificationTopic_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAppNotificationTopic_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_AppNotification.htm");
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
         GxWebStd.gx_label_element( context, edtAppNotificationMetadata_Internalname, context.GetMessage( "Notification Metadata", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtAppNotificationMetadata_Internalname, A498AppNotificationMetadata, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", 0, 1, edtAppNotificationMetadata_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_AppNotification.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AppNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AppNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AppNotification.htm");
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
            Z486AppNotificationId = StringUtil.StrToGuid( cgiGet( "Z486AppNotificationId"));
            Z487AppNotificationTitle = cgiGet( "Z487AppNotificationTitle");
            Z488AppNotificationDescription = cgiGet( "Z488AppNotificationDescription");
            Z489AppNotificationDate = context.localUtil.CToT( cgiGet( "Z489AppNotificationDate"), 0);
            Z490AppNotificationTopic = cgiGet( "Z490AppNotificationTopic");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
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
            A487AppNotificationTitle = cgiGet( edtAppNotificationTitle_Internalname);
            AssignAttri("", false, "A487AppNotificationTitle", A487AppNotificationTitle);
            A488AppNotificationDescription = cgiGet( edtAppNotificationDescription_Internalname);
            AssignAttri("", false, "A488AppNotificationDescription", A488AppNotificationDescription);
            if ( context.localUtil.VCDateTime( cgiGet( edtAppNotificationDate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "App Notification Date", "")}), 1, "APPNOTIFICATIONDATE");
               AnyError = 1;
               GX_FocusControl = edtAppNotificationDate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A489AppNotificationDate = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A489AppNotificationDate", context.localUtil.TToC( A489AppNotificationDate, 10, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A489AppNotificationDate = context.localUtil.CToT( cgiGet( edtAppNotificationDate_Internalname));
               AssignAttri("", false, "A489AppNotificationDate", context.localUtil.TToC( A489AppNotificationDate, 10, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            A490AppNotificationTopic = cgiGet( edtAppNotificationTopic_Internalname);
            AssignAttri("", false, "A490AppNotificationTopic", A490AppNotificationTopic);
            A498AppNotificationMetadata = cgiGet( edtAppNotificationMetadata_Internalname);
            n498AppNotificationMetadata = false;
            AssignAttri("", false, "A498AppNotificationMetadata", A498AppNotificationMetadata);
            n498AppNotificationMetadata = (String.IsNullOrEmpty(StringUtil.RTrim( A498AppNotificationMetadata)) ? true : false);
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
               A486AppNotificationId = StringUtil.StrToGuid( GetPar( "AppNotificationId"));
               AssignAttri("", false, "A486AppNotificationId", A486AppNotificationId.ToString());
               getEqualNoModal( ) ;
               if ( IsIns( )  && (Guid.Empty==A486AppNotificationId) && ( Gx_BScreen == 0 ) )
               {
                  A486AppNotificationId = Guid.NewGuid( );
                  AssignAttri("", false, "A486AppNotificationId", A486AppNotificationId.ToString());
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
               InitAll1E85( ) ;
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
         DisableAttributes1E85( ) ;
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

      protected void ResetCaption1E0( )
      {
      }

      protected void ZM1E85( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z487AppNotificationTitle = T001E3_A487AppNotificationTitle[0];
               Z488AppNotificationDescription = T001E3_A488AppNotificationDescription[0];
               Z489AppNotificationDate = T001E3_A489AppNotificationDate[0];
               Z490AppNotificationTopic = T001E3_A490AppNotificationTopic[0];
            }
            else
            {
               Z487AppNotificationTitle = A487AppNotificationTitle;
               Z488AppNotificationDescription = A488AppNotificationDescription;
               Z489AppNotificationDate = A489AppNotificationDate;
               Z490AppNotificationTopic = A490AppNotificationTopic;
            }
         }
         if ( GX_JID == -3 )
         {
            Z486AppNotificationId = A486AppNotificationId;
            Z487AppNotificationTitle = A487AppNotificationTitle;
            Z488AppNotificationDescription = A488AppNotificationDescription;
            Z489AppNotificationDate = A489AppNotificationDate;
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
         if ( IsIns( )  && (Guid.Empty==A486AppNotificationId) && ( Gx_BScreen == 0 ) )
         {
            A486AppNotificationId = Guid.NewGuid( );
            AssignAttri("", false, "A486AppNotificationId", A486AppNotificationId.ToString());
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

      protected void Load1E85( )
      {
         /* Using cursor T001E4 */
         pr_default.execute(2, new Object[] {A486AppNotificationId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound85 = 1;
            A487AppNotificationTitle = T001E4_A487AppNotificationTitle[0];
            AssignAttri("", false, "A487AppNotificationTitle", A487AppNotificationTitle);
            A488AppNotificationDescription = T001E4_A488AppNotificationDescription[0];
            AssignAttri("", false, "A488AppNotificationDescription", A488AppNotificationDescription);
            A489AppNotificationDate = T001E4_A489AppNotificationDate[0];
            AssignAttri("", false, "A489AppNotificationDate", context.localUtil.TToC( A489AppNotificationDate, 10, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A490AppNotificationTopic = T001E4_A490AppNotificationTopic[0];
            AssignAttri("", false, "A490AppNotificationTopic", A490AppNotificationTopic);
            A498AppNotificationMetadata = T001E4_A498AppNotificationMetadata[0];
            n498AppNotificationMetadata = T001E4_n498AppNotificationMetadata[0];
            AssignAttri("", false, "A498AppNotificationMetadata", A498AppNotificationMetadata);
            ZM1E85( -3) ;
         }
         pr_default.close(2);
         OnLoadActions1E85( ) ;
      }

      protected void OnLoadActions1E85( )
      {
      }

      protected void CheckExtendedTable1E85( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1E85( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1E85( )
      {
         /* Using cursor T001E5 */
         pr_default.execute(3, new Object[] {A486AppNotificationId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound85 = 1;
         }
         else
         {
            RcdFound85 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001E3 */
         pr_default.execute(1, new Object[] {A486AppNotificationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1E85( 3) ;
            RcdFound85 = 1;
            A486AppNotificationId = T001E3_A486AppNotificationId[0];
            AssignAttri("", false, "A486AppNotificationId", A486AppNotificationId.ToString());
            A487AppNotificationTitle = T001E3_A487AppNotificationTitle[0];
            AssignAttri("", false, "A487AppNotificationTitle", A487AppNotificationTitle);
            A488AppNotificationDescription = T001E3_A488AppNotificationDescription[0];
            AssignAttri("", false, "A488AppNotificationDescription", A488AppNotificationDescription);
            A489AppNotificationDate = T001E3_A489AppNotificationDate[0];
            AssignAttri("", false, "A489AppNotificationDate", context.localUtil.TToC( A489AppNotificationDate, 10, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A490AppNotificationTopic = T001E3_A490AppNotificationTopic[0];
            AssignAttri("", false, "A490AppNotificationTopic", A490AppNotificationTopic);
            A498AppNotificationMetadata = T001E3_A498AppNotificationMetadata[0];
            n498AppNotificationMetadata = T001E3_n498AppNotificationMetadata[0];
            AssignAttri("", false, "A498AppNotificationMetadata", A498AppNotificationMetadata);
            Z486AppNotificationId = A486AppNotificationId;
            sMode85 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1E85( ) ;
            if ( AnyError == 1 )
            {
               RcdFound85 = 0;
               InitializeNonKey1E85( ) ;
            }
            Gx_mode = sMode85;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound85 = 0;
            InitializeNonKey1E85( ) ;
            sMode85 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode85;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1E85( ) ;
         if ( RcdFound85 == 0 )
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
         RcdFound85 = 0;
         /* Using cursor T001E6 */
         pr_default.execute(4, new Object[] {A486AppNotificationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( GuidUtil.Compare(T001E6_A486AppNotificationId[0], A486AppNotificationId, 0) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( GuidUtil.Compare(T001E6_A486AppNotificationId[0], A486AppNotificationId, 0) > 0 ) ) )
            {
               A486AppNotificationId = T001E6_A486AppNotificationId[0];
               AssignAttri("", false, "A486AppNotificationId", A486AppNotificationId.ToString());
               RcdFound85 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound85 = 0;
         /* Using cursor T001E7 */
         pr_default.execute(5, new Object[] {A486AppNotificationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T001E7_A486AppNotificationId[0], A486AppNotificationId, 0) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T001E7_A486AppNotificationId[0], A486AppNotificationId, 0) < 0 ) ) )
            {
               A486AppNotificationId = T001E7_A486AppNotificationId[0];
               AssignAttri("", false, "A486AppNotificationId", A486AppNotificationId.ToString());
               RcdFound85 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1E85( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAppNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1E85( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound85 == 1 )
            {
               if ( A486AppNotificationId != Z486AppNotificationId )
               {
                  A486AppNotificationId = Z486AppNotificationId;
                  AssignAttri("", false, "A486AppNotificationId", A486AppNotificationId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "APPNOTIFICATIONID");
                  AnyError = 1;
                  GX_FocusControl = edtAppNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAppNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1E85( ) ;
                  GX_FocusControl = edtAppNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A486AppNotificationId != Z486AppNotificationId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtAppNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1E85( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "APPNOTIFICATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtAppNotificationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtAppNotificationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1E85( ) ;
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
         if ( A486AppNotificationId != Z486AppNotificationId )
         {
            A486AppNotificationId = Z486AppNotificationId;
            AssignAttri("", false, "A486AppNotificationId", A486AppNotificationId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "APPNOTIFICATIONID");
            AnyError = 1;
            GX_FocusControl = edtAppNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAppNotificationId_Internalname;
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
         if ( RcdFound85 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "APPNOTIFICATIONID");
            AnyError = 1;
            GX_FocusControl = edtAppNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtAppNotificationTitle_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1E85( ) ;
         if ( RcdFound85 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAppNotificationTitle_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1E85( ) ;
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
         if ( RcdFound85 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAppNotificationTitle_Internalname;
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
         if ( RcdFound85 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAppNotificationTitle_Internalname;
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
         ScanStart1E85( ) ;
         if ( RcdFound85 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound85 != 0 )
            {
               ScanNext1E85( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAppNotificationTitle_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1E85( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1E85( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001E2 */
            pr_default.execute(0, new Object[] {A486AppNotificationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AppNotification"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z487AppNotificationTitle, T001E2_A487AppNotificationTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z488AppNotificationDescription, T001E2_A488AppNotificationDescription[0]) != 0 ) || ( Z489AppNotificationDate != T001E2_A489AppNotificationDate[0] ) || ( StringUtil.StrCmp(Z490AppNotificationTopic, T001E2_A490AppNotificationTopic[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z487AppNotificationTitle, T001E2_A487AppNotificationTitle[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_appnotification:[seudo value changed for attri]"+"AppNotificationTitle");
                  GXUtil.WriteLogRaw("Old: ",Z487AppNotificationTitle);
                  GXUtil.WriteLogRaw("Current: ",T001E2_A487AppNotificationTitle[0]);
               }
               if ( StringUtil.StrCmp(Z488AppNotificationDescription, T001E2_A488AppNotificationDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_appnotification:[seudo value changed for attri]"+"AppNotificationDescription");
                  GXUtil.WriteLogRaw("Old: ",Z488AppNotificationDescription);
                  GXUtil.WriteLogRaw("Current: ",T001E2_A488AppNotificationDescription[0]);
               }
               if ( Z489AppNotificationDate != T001E2_A489AppNotificationDate[0] )
               {
                  GXUtil.WriteLog("trn_appnotification:[seudo value changed for attri]"+"AppNotificationDate");
                  GXUtil.WriteLogRaw("Old: ",Z489AppNotificationDate);
                  GXUtil.WriteLogRaw("Current: ",T001E2_A489AppNotificationDate[0]);
               }
               if ( StringUtil.StrCmp(Z490AppNotificationTopic, T001E2_A490AppNotificationTopic[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_appnotification:[seudo value changed for attri]"+"AppNotificationTopic");
                  GXUtil.WriteLogRaw("Old: ",Z490AppNotificationTopic);
                  GXUtil.WriteLogRaw("Current: ",T001E2_A490AppNotificationTopic[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_AppNotification"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1E85( )
      {
         if ( ! IsAuthorized("trn_residentnotification_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1E85( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1E85( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1E85( 0) ;
            CheckOptimisticConcurrency1E85( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1E85( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1E85( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001E8 */
                     pr_default.execute(6, new Object[] {A486AppNotificationId, A487AppNotificationTitle, A488AppNotificationDescription, A489AppNotificationDate, A490AppNotificationTopic, n498AppNotificationMetadata, A498AppNotificationMetadata});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AppNotification");
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
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption1E0( ) ;
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
               Load1E85( ) ;
            }
            EndLevel1E85( ) ;
         }
         CloseExtendedTableCursors1E85( ) ;
      }

      protected void Update1E85( )
      {
         if ( ! IsAuthorized("trn_residentnotification_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1E85( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1E85( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1E85( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1E85( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1E85( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001E9 */
                     pr_default.execute(7, new Object[] {A487AppNotificationTitle, A488AppNotificationDescription, A489AppNotificationDate, A490AppNotificationTopic, n498AppNotificationMetadata, A498AppNotificationMetadata, A486AppNotificationId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AppNotification");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AppNotification"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1E85( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1E0( ) ;
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
            EndLevel1E85( ) ;
         }
         CloseExtendedTableCursors1E85( ) ;
      }

      protected void DeferredUpdate1E85( )
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
         BeforeValidate1E85( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1E85( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1E85( ) ;
            AfterConfirm1E85( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1E85( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001E10 */
                  pr_default.execute(8, new Object[] {A486AppNotificationId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_AppNotification");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound85 == 0 )
                        {
                           InitAll1E85( ) ;
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
                        ResetCaption1E0( ) ;
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
         sMode85 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1E85( ) ;
         Gx_mode = sMode85;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1E85( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T001E11 */
            pr_default.execute(9, new Object[] {A486AppNotificationId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Resident Notifications", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel1E85( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1E85( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_appnotification",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1E0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_appnotification",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1E85( )
      {
         /* Using cursor T001E12 */
         pr_default.execute(10);
         RcdFound85 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound85 = 1;
            A486AppNotificationId = T001E12_A486AppNotificationId[0];
            AssignAttri("", false, "A486AppNotificationId", A486AppNotificationId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1E85( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound85 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound85 = 1;
            A486AppNotificationId = T001E12_A486AppNotificationId[0];
            AssignAttri("", false, "A486AppNotificationId", A486AppNotificationId.ToString());
         }
      }

      protected void ScanEnd1E85( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm1E85( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1E85( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1E85( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1E85( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1E85( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1E85( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1E85( )
      {
         edtAppNotificationId_Enabled = 0;
         AssignProp("", false, edtAppNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAppNotificationId_Enabled), 5, 0), true);
         edtAppNotificationTitle_Enabled = 0;
         AssignProp("", false, edtAppNotificationTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAppNotificationTitle_Enabled), 5, 0), true);
         edtAppNotificationDescription_Enabled = 0;
         AssignProp("", false, edtAppNotificationDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAppNotificationDescription_Enabled), 5, 0), true);
         edtAppNotificationDate_Enabled = 0;
         AssignProp("", false, edtAppNotificationDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAppNotificationDate_Enabled), 5, 0), true);
         edtAppNotificationTopic_Enabled = 0;
         AssignProp("", false, edtAppNotificationTopic_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAppNotificationTopic_Enabled), 5, 0), true);
         edtAppNotificationMetadata_Enabled = 0;
         AssignProp("", false, edtAppNotificationMetadata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAppNotificationMetadata_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1E85( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1E0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_appnotification.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z486AppNotificationId", Z486AppNotificationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z487AppNotificationTitle", Z487AppNotificationTitle);
         GxWebStd.gx_hidden_field( context, "Z488AppNotificationDescription", Z488AppNotificationDescription);
         GxWebStd.gx_hidden_field( context, "Z489AppNotificationDate", context.localUtil.TToC( Z489AppNotificationDate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z490AppNotificationTopic", Z490AppNotificationTopic);
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
         return formatLink("trn_appnotification.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_AppNotification" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "App Notification Definitions", "") ;
      }

      protected void InitializeNonKey1E85( )
      {
         A487AppNotificationTitle = "";
         AssignAttri("", false, "A487AppNotificationTitle", A487AppNotificationTitle);
         A488AppNotificationDescription = "";
         AssignAttri("", false, "A488AppNotificationDescription", A488AppNotificationDescription);
         A489AppNotificationDate = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A489AppNotificationDate", context.localUtil.TToC( A489AppNotificationDate, 10, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A490AppNotificationTopic = "";
         AssignAttri("", false, "A490AppNotificationTopic", A490AppNotificationTopic);
         A498AppNotificationMetadata = "";
         n498AppNotificationMetadata = false;
         AssignAttri("", false, "A498AppNotificationMetadata", A498AppNotificationMetadata);
         n498AppNotificationMetadata = (String.IsNullOrEmpty(StringUtil.RTrim( A498AppNotificationMetadata)) ? true : false);
         Z487AppNotificationTitle = "";
         Z488AppNotificationDescription = "";
         Z489AppNotificationDate = (DateTime)(DateTime.MinValue);
         Z490AppNotificationTopic = "";
      }

      protected void InitAll1E85( )
      {
         A486AppNotificationId = Guid.NewGuid( );
         AssignAttri("", false, "A486AppNotificationId", A486AppNotificationId.ToString());
         InitializeNonKey1E85( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025614535431", true, true);
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
         context.AddJavascriptSource("trn_appnotification.js", "?2025614535432", false, true);
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
         edtAppNotificationId_Internalname = "APPNOTIFICATIONID";
         edtAppNotificationTitle_Internalname = "APPNOTIFICATIONTITLE";
         edtAppNotificationDescription_Internalname = "APPNOTIFICATIONDESCRIPTION";
         edtAppNotificationDate_Internalname = "APPNOTIFICATIONDATE";
         edtAppNotificationTopic_Internalname = "APPNOTIFICATIONTOPIC";
         edtAppNotificationMetadata_Internalname = "APPNOTIFICATIONMETADATA";
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
         Form.Caption = context.GetMessage( "App Notification Definitions", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtAppNotificationMetadata_Enabled = 1;
         edtAppNotificationTopic_Jsonclick = "";
         edtAppNotificationTopic_Enabled = 1;
         edtAppNotificationDate_Jsonclick = "";
         edtAppNotificationDate_Enabled = 1;
         edtAppNotificationDescription_Enabled = 1;
         edtAppNotificationTitle_Jsonclick = "";
         edtAppNotificationTitle_Enabled = 1;
         edtAppNotificationId_Jsonclick = "";
         edtAppNotificationId_Enabled = 1;
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
         GX_FocusControl = edtAppNotificationTitle_Internalname;
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

      public void Valid_Appnotificationid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A487AppNotificationTitle", A487AppNotificationTitle);
         AssignAttri("", false, "A488AppNotificationDescription", A488AppNotificationDescription);
         AssignAttri("", false, "A489AppNotificationDate", context.localUtil.TToC( A489AppNotificationDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A490AppNotificationTopic", A490AppNotificationTopic);
         AssignAttri("", false, "A498AppNotificationMetadata", A498AppNotificationMetadata);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z486AppNotificationId", Z486AppNotificationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z487AppNotificationTitle", Z487AppNotificationTitle);
         GxWebStd.gx_hidden_field( context, "Z488AppNotificationDescription", Z488AppNotificationDescription);
         GxWebStd.gx_hidden_field( context, "Z489AppNotificationDate", context.localUtil.TToC( Z489AppNotificationDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z490AppNotificationTopic", Z490AppNotificationTopic);
         GxWebStd.gx_hidden_field( context, "Z498AppNotificationMetadata", Z498AppNotificationMetadata);
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("VALID_APPNOTIFICATIONID","""{"handler":"Valid_Appnotificationid","iparms":[{"av":"A486AppNotificationId","fld":"APPNOTIFICATIONID"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"}]""");
         setEventMetadata("VALID_APPNOTIFICATIONID",""","oparms":[{"av":"A487AppNotificationTitle","fld":"APPNOTIFICATIONTITLE"},{"av":"A488AppNotificationDescription","fld":"APPNOTIFICATIONDESCRIPTION"},{"av":"A489AppNotificationDate","fld":"APPNOTIFICATIONDATE","pic":"99/99/9999 99:99"},{"av":"A490AppNotificationTopic","fld":"APPNOTIFICATIONTOPIC"},{"av":"A498AppNotificationMetadata","fld":"APPNOTIFICATIONMETADATA"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z486AppNotificationId"},{"av":"Z487AppNotificationTitle"},{"av":"Z488AppNotificationDescription"},{"av":"Z489AppNotificationDate"},{"av":"Z490AppNotificationTopic"},{"av":"Z498AppNotificationMetadata"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
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
         Z486AppNotificationId = Guid.Empty;
         Z487AppNotificationTitle = "";
         Z488AppNotificationDescription = "";
         Z489AppNotificationDate = (DateTime)(DateTime.MinValue);
         Z490AppNotificationTopic = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
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
         A486AppNotificationId = Guid.Empty;
         A487AppNotificationTitle = "";
         A488AppNotificationDescription = "";
         A489AppNotificationDate = (DateTime)(DateTime.MinValue);
         A490AppNotificationTopic = "";
         A498AppNotificationMetadata = "";
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
         Z498AppNotificationMetadata = "";
         T001E4_A486AppNotificationId = new Guid[] {Guid.Empty} ;
         T001E4_A487AppNotificationTitle = new string[] {""} ;
         T001E4_A488AppNotificationDescription = new string[] {""} ;
         T001E4_A489AppNotificationDate = new DateTime[] {DateTime.MinValue} ;
         T001E4_A490AppNotificationTopic = new string[] {""} ;
         T001E4_A498AppNotificationMetadata = new string[] {""} ;
         T001E4_n498AppNotificationMetadata = new bool[] {false} ;
         T001E5_A486AppNotificationId = new Guid[] {Guid.Empty} ;
         T001E3_A486AppNotificationId = new Guid[] {Guid.Empty} ;
         T001E3_A487AppNotificationTitle = new string[] {""} ;
         T001E3_A488AppNotificationDescription = new string[] {""} ;
         T001E3_A489AppNotificationDate = new DateTime[] {DateTime.MinValue} ;
         T001E3_A490AppNotificationTopic = new string[] {""} ;
         T001E3_A498AppNotificationMetadata = new string[] {""} ;
         T001E3_n498AppNotificationMetadata = new bool[] {false} ;
         sMode85 = "";
         T001E6_A486AppNotificationId = new Guid[] {Guid.Empty} ;
         T001E7_A486AppNotificationId = new Guid[] {Guid.Empty} ;
         T001E2_A486AppNotificationId = new Guid[] {Guid.Empty} ;
         T001E2_A487AppNotificationTitle = new string[] {""} ;
         T001E2_A488AppNotificationDescription = new string[] {""} ;
         T001E2_A489AppNotificationDate = new DateTime[] {DateTime.MinValue} ;
         T001E2_A490AppNotificationTopic = new string[] {""} ;
         T001E2_A498AppNotificationMetadata = new string[] {""} ;
         T001E2_n498AppNotificationMetadata = new bool[] {false} ;
         T001E11_A485ResidentNotificationId = new Guid[] {Guid.Empty} ;
         T001E12_A486AppNotificationId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ486AppNotificationId = Guid.Empty;
         ZZ487AppNotificationTitle = "";
         ZZ488AppNotificationDescription = "";
         ZZ489AppNotificationDate = (DateTime)(DateTime.MinValue);
         ZZ490AppNotificationTopic = "";
         ZZ498AppNotificationMetadata = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_appnotification__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_appnotification__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_appnotification__default(),
            new Object[][] {
                new Object[] {
               T001E2_A486AppNotificationId, T001E2_A487AppNotificationTitle, T001E2_A488AppNotificationDescription, T001E2_A489AppNotificationDate, T001E2_A490AppNotificationTopic, T001E2_A498AppNotificationMetadata, T001E2_n498AppNotificationMetadata
               }
               , new Object[] {
               T001E3_A486AppNotificationId, T001E3_A487AppNotificationTitle, T001E3_A488AppNotificationDescription, T001E3_A489AppNotificationDate, T001E3_A490AppNotificationTopic, T001E3_A498AppNotificationMetadata, T001E3_n498AppNotificationMetadata
               }
               , new Object[] {
               T001E4_A486AppNotificationId, T001E4_A487AppNotificationTitle, T001E4_A488AppNotificationDescription, T001E4_A489AppNotificationDate, T001E4_A490AppNotificationTopic, T001E4_A498AppNotificationMetadata, T001E4_n498AppNotificationMetadata
               }
               , new Object[] {
               T001E5_A486AppNotificationId
               }
               , new Object[] {
               T001E6_A486AppNotificationId
               }
               , new Object[] {
               T001E7_A486AppNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001E11_A485ResidentNotificationId
               }
               , new Object[] {
               T001E12_A486AppNotificationId
               }
            }
         );
         Z486AppNotificationId = Guid.NewGuid( );
         A486AppNotificationId = Guid.NewGuid( );
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound85 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtAppNotificationId_Enabled ;
      private int edtAppNotificationTitle_Enabled ;
      private int edtAppNotificationDescription_Enabled ;
      private int edtAppNotificationDate_Enabled ;
      private int edtAppNotificationTopic_Enabled ;
      private int edtAppNotificationMetadata_Enabled ;
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
      private string edtAppNotificationId_Internalname ;
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
      private string edtAppNotificationId_Jsonclick ;
      private string edtAppNotificationTitle_Internalname ;
      private string edtAppNotificationTitle_Jsonclick ;
      private string edtAppNotificationDescription_Internalname ;
      private string edtAppNotificationDate_Internalname ;
      private string edtAppNotificationDate_Jsonclick ;
      private string edtAppNotificationTopic_Internalname ;
      private string edtAppNotificationTopic_Jsonclick ;
      private string edtAppNotificationMetadata_Internalname ;
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
      private string sMode85 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z489AppNotificationDate ;
      private DateTime A489AppNotificationDate ;
      private DateTime ZZ489AppNotificationDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n498AppNotificationMetadata ;
      private string A498AppNotificationMetadata ;
      private string Z498AppNotificationMetadata ;
      private string ZZ498AppNotificationMetadata ;
      private string Z487AppNotificationTitle ;
      private string Z488AppNotificationDescription ;
      private string Z490AppNotificationTopic ;
      private string A487AppNotificationTitle ;
      private string A488AppNotificationDescription ;
      private string A490AppNotificationTopic ;
      private string ZZ487AppNotificationTitle ;
      private string ZZ488AppNotificationDescription ;
      private string ZZ490AppNotificationTopic ;
      private Guid Z486AppNotificationId ;
      private Guid A486AppNotificationId ;
      private Guid ZZ486AppNotificationId ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] T001E4_A486AppNotificationId ;
      private string[] T001E4_A487AppNotificationTitle ;
      private string[] T001E4_A488AppNotificationDescription ;
      private DateTime[] T001E4_A489AppNotificationDate ;
      private string[] T001E4_A490AppNotificationTopic ;
      private string[] T001E4_A498AppNotificationMetadata ;
      private bool[] T001E4_n498AppNotificationMetadata ;
      private Guid[] T001E5_A486AppNotificationId ;
      private Guid[] T001E3_A486AppNotificationId ;
      private string[] T001E3_A487AppNotificationTitle ;
      private string[] T001E3_A488AppNotificationDescription ;
      private DateTime[] T001E3_A489AppNotificationDate ;
      private string[] T001E3_A490AppNotificationTopic ;
      private string[] T001E3_A498AppNotificationMetadata ;
      private bool[] T001E3_n498AppNotificationMetadata ;
      private Guid[] T001E6_A486AppNotificationId ;
      private Guid[] T001E7_A486AppNotificationId ;
      private Guid[] T001E2_A486AppNotificationId ;
      private string[] T001E2_A487AppNotificationTitle ;
      private string[] T001E2_A488AppNotificationDescription ;
      private DateTime[] T001E2_A489AppNotificationDate ;
      private string[] T001E2_A490AppNotificationTopic ;
      private string[] T001E2_A498AppNotificationMetadata ;
      private bool[] T001E2_n498AppNotificationMetadata ;
      private Guid[] T001E11_A485ResidentNotificationId ;
      private Guid[] T001E12_A486AppNotificationId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_appnotification__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_appnotification__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_appnotification__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[10])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT001E2;
       prmT001E2 = new Object[] {
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001E3;
       prmT001E3 = new Object[] {
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001E4;
       prmT001E4 = new Object[] {
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001E5;
       prmT001E5 = new Object[] {
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001E6;
       prmT001E6 = new Object[] {
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001E7;
       prmT001E7 = new Object[] {
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001E8;
       prmT001E8 = new Object[] {
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AppNotificationTitle",GXType.VarChar,100,0) ,
       new ParDef("AppNotificationDescription",GXType.VarChar,200,0) ,
       new ParDef("AppNotificationDate",GXType.DateTime,10,5) ,
       new ParDef("AppNotificationTopic",GXType.VarChar,100,0) ,
       new ParDef("AppNotificationMetadata",GXType.LongVarChar,2097152,0){Nullable=true}
       };
       Object[] prmT001E9;
       prmT001E9 = new Object[] {
       new ParDef("AppNotificationTitle",GXType.VarChar,100,0) ,
       new ParDef("AppNotificationDescription",GXType.VarChar,200,0) ,
       new ParDef("AppNotificationDate",GXType.DateTime,10,5) ,
       new ParDef("AppNotificationTopic",GXType.VarChar,100,0) ,
       new ParDef("AppNotificationMetadata",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001E10;
       prmT001E10 = new Object[] {
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001E11;
       prmT001E11 = new Object[] {
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001E12;
       prmT001E12 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T001E2", "SELECT AppNotificationId, AppNotificationTitle, AppNotificationDescription, AppNotificationDate, AppNotificationTopic, AppNotificationMetadata FROM Trn_AppNotification WHERE AppNotificationId = :AppNotificationId  FOR UPDATE OF Trn_AppNotification NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001E2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001E3", "SELECT AppNotificationId, AppNotificationTitle, AppNotificationDescription, AppNotificationDate, AppNotificationTopic, AppNotificationMetadata FROM Trn_AppNotification WHERE AppNotificationId = :AppNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001E3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001E4", "SELECT TM1.AppNotificationId, TM1.AppNotificationTitle, TM1.AppNotificationDescription, TM1.AppNotificationDate, TM1.AppNotificationTopic, TM1.AppNotificationMetadata FROM Trn_AppNotification TM1 WHERE TM1.AppNotificationId = :AppNotificationId ORDER BY TM1.AppNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001E4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001E5", "SELECT AppNotificationId FROM Trn_AppNotification WHERE AppNotificationId = :AppNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001E5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001E6", "SELECT AppNotificationId FROM Trn_AppNotification WHERE ( AppNotificationId > :AppNotificationId) ORDER BY AppNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001E6,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001E7", "SELECT AppNotificationId FROM Trn_AppNotification WHERE ( AppNotificationId < :AppNotificationId) ORDER BY AppNotificationId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001E7,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001E8", "SAVEPOINT gxupdate;INSERT INTO Trn_AppNotification(AppNotificationId, AppNotificationTitle, AppNotificationDescription, AppNotificationDate, AppNotificationTopic, AppNotificationMetadata) VALUES(:AppNotificationId, :AppNotificationTitle, :AppNotificationDescription, :AppNotificationDate, :AppNotificationTopic, :AppNotificationMetadata);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001E8)
          ,new CursorDef("T001E9", "SAVEPOINT gxupdate;UPDATE Trn_AppNotification SET AppNotificationTitle=:AppNotificationTitle, AppNotificationDescription=:AppNotificationDescription, AppNotificationDate=:AppNotificationDate, AppNotificationTopic=:AppNotificationTopic, AppNotificationMetadata=:AppNotificationMetadata  WHERE AppNotificationId = :AppNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001E9)
          ,new CursorDef("T001E10", "SAVEPOINT gxupdate;DELETE FROM Trn_AppNotification  WHERE AppNotificationId = :AppNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001E10)
          ,new CursorDef("T001E11", "SELECT ResidentNotificationId FROM Trn_ResidentNotification WHERE AppNotificationId = :AppNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001E11,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001E12", "SELECT AppNotificationId FROM Trn_AppNotification ORDER BY AppNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001E12,100, GxCacheFrequency.OFF ,true,false )
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
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((bool[]) buf[6])[0] = rslt.wasNull(6);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((bool[]) buf[6])[0] = rslt.wasNull(6);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((bool[]) buf[6])[0] = rslt.wasNull(6);
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
          case 10 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
