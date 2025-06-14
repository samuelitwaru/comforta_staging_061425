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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_notification : GXDataArea
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
            A128WWPNotificationDefinitionId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPNotificationDefinitionId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A128WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A128WWPNotificationDefinitionId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A128WWPNotificationDefinitionId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A112WWPUserExtendedId = GetPar( "WWPUserExtendedId");
            n112WWPUserExtendedId = false;
            AssignAttri("", false, "A112WWPUserExtendedId", A112WWPUserExtendedId);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A112WWPUserExtendedId) ;
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
         Form.Meta.addItem("description", context.GetMessage( "Notification", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_notification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_notification( IGxContext context )
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
         chkWWPNotificationIsRead = new GXCheckbox();
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
            return "wwp_notification_Execute" ;
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
         A187WWPNotificationIsRead = StringUtil.StrToBool( StringUtil.BoolToStr( A187WWPNotificationIsRead));
         AssignAttri("", false, "A187WWPNotificationIsRead", A187WWPNotificationIsRead);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Notification", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationId_Internalname, context.GetMessage( "Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A127WWPNotificationId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPNotificationId_Enabled!=0) ? context.localUtil.Format( (decimal)(A127WWPNotificationId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A127WWPNotificationId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionId_Internalname, context.GetMessage( "Notification Definition Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A128WWPNotificationDefinitionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPNotificationDefinitionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A128WWPNotificationDefinitionId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A128WWPNotificationDefinitionId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationDefinitionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionName_Internalname, context.GetMessage( "Notification Definition Internal Name", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionName_Internalname, A164WWPNotificationDefinitionName, StringUtil.RTrim( context.localUtil.Format( A164WWPNotificationDefinitionName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationDefinitionName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationCreated_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationCreated_Internalname, context.GetMessage( "Created Date", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPNotificationCreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationCreated_Internalname, context.localUtil.TToC( A129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A129WWPNotificationCreated, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationCreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationCreated_Enabled, 0, "text", "", 27, "chr", 1, "row", 27, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_bitmap( context, edtWWPNotificationCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPNotificationCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationIcon_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationIcon_Internalname, context.GetMessage( "Icon", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationIcon_Internalname, A181WWPNotificationIcon, StringUtil.RTrim( context.localUtil.Format( A181WWPNotificationIcon, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationIcon_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationIcon_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationTitle_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationTitle_Internalname, context.GetMessage( "Title", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationTitle_Internalname, A182WWPNotificationTitle, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", 0, 1, edtWWPNotificationTitle_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationShortDescriptio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationShortDescriptio_Internalname, context.GetMessage( "Short Description", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationShortDescriptio_Internalname, A183WWPNotificationShortDescriptio, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", 0, 1, edtWWPNotificationShortDescriptio_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationLink_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationLink_Internalname, context.GetMessage( "Link", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationLink_Internalname, A184WWPNotificationLink, StringUtil.RTrim( context.localUtil.Format( A184WWPNotificationLink, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", A184WWPNotificationLink, "_blank", "", "", edtWWPNotificationLink_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationLink_Enabled, 0, "url", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Url", "start", true, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPNotificationIsRead_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPNotificationIsRead_Internalname, context.GetMessage( "Is Read", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPNotificationIsRead_Internalname, StringUtil.BoolToStr( A187WWPNotificationIsRead), "", context.GetMessage( "Is Read", ""), 1, chkWWPNotificationIsRead.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(74, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,74);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPUserExtendedId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedId_Internalname, context.GetMessage( "User Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedId_Internalname, StringUtil.RTrim( A112WWPUserExtendedId), StringUtil.RTrim( context.localUtil.Format( A112WWPUserExtendedId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedId_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_GAMGUID", "start", true, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPUserExtendedFullName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedFullName_Internalname, context.GetMessage( "User Full Name", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedFullName_Internalname, A113WWPUserExtendedFullName, StringUtil.RTrim( context.localUtil.Format( A113WWPUserExtendedFullName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedFullName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedFullName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationMetadata_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationMetadata_Internalname, context.GetMessage( "Metadata", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationMetadata_Internalname, A165WWPNotificationMetadata, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", 0, 1, edtWWPNotificationMetadata_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
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
            Z127WWPNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z127WWPNotificationId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z129WWPNotificationCreated = context.localUtil.CToT( cgiGet( "Z129WWPNotificationCreated"), 0);
            Z181WWPNotificationIcon = cgiGet( "Z181WWPNotificationIcon");
            Z182WWPNotificationTitle = cgiGet( "Z182WWPNotificationTitle");
            Z183WWPNotificationShortDescriptio = cgiGet( "Z183WWPNotificationShortDescriptio");
            Z184WWPNotificationLink = cgiGet( "Z184WWPNotificationLink");
            Z187WWPNotificationIsRead = StringUtil.StrToBool( cgiGet( "Z187WWPNotificationIsRead"));
            Z128WWPNotificationDefinitionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z128WWPNotificationDefinitionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z112WWPUserExtendedId = cgiGet( "Z112WWPUserExtendedId");
            n112WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A112WWPUserExtendedId)) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPNotificationId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPNotificationId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A127WWPNotificationId = 0;
               n127WWPNotificationId = false;
               AssignAttri("", false, "A127WWPNotificationId", StringUtil.LTrimStr( (decimal)(A127WWPNotificationId), 10, 0));
            }
            else
            {
               A127WWPNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPNotificationId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n127WWPNotificationId = false;
               AssignAttri("", false, "A127WWPNotificationId", StringUtil.LTrimStr( (decimal)(A127WWPNotificationId), 10, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPNotificationDefinitionId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPNotificationDefinitionId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPNOTIFICATIONDEFINITIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A128WWPNotificationDefinitionId = 0;
               AssignAttri("", false, "A128WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A128WWPNotificationDefinitionId), 10, 0));
            }
            else
            {
               A128WWPNotificationDefinitionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPNotificationDefinitionId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A128WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A128WWPNotificationDefinitionId), 10, 0));
            }
            A164WWPNotificationDefinitionName = cgiGet( edtWWPNotificationDefinitionName_Internalname);
            AssignAttri("", false, "A164WWPNotificationDefinitionName", A164WWPNotificationDefinitionName);
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPNotificationCreated_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Notification Created Date", "")}), 1, "WWPNOTIFICATIONCREATED");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationCreated_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A129WWPNotificationCreated = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A129WWPNotificationCreated", context.localUtil.TToC( A129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A129WWPNotificationCreated = context.localUtil.CToT( cgiGet( edtWWPNotificationCreated_Internalname));
               AssignAttri("", false, "A129WWPNotificationCreated", context.localUtil.TToC( A129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            A181WWPNotificationIcon = cgiGet( edtWWPNotificationIcon_Internalname);
            AssignAttri("", false, "A181WWPNotificationIcon", A181WWPNotificationIcon);
            A182WWPNotificationTitle = cgiGet( edtWWPNotificationTitle_Internalname);
            AssignAttri("", false, "A182WWPNotificationTitle", A182WWPNotificationTitle);
            A183WWPNotificationShortDescriptio = cgiGet( edtWWPNotificationShortDescriptio_Internalname);
            AssignAttri("", false, "A183WWPNotificationShortDescriptio", A183WWPNotificationShortDescriptio);
            A184WWPNotificationLink = cgiGet( edtWWPNotificationLink_Internalname);
            AssignAttri("", false, "A184WWPNotificationLink", A184WWPNotificationLink);
            A187WWPNotificationIsRead = StringUtil.StrToBool( cgiGet( chkWWPNotificationIsRead_Internalname));
            AssignAttri("", false, "A187WWPNotificationIsRead", A187WWPNotificationIsRead);
            A112WWPUserExtendedId = cgiGet( edtWWPUserExtendedId_Internalname);
            n112WWPUserExtendedId = false;
            AssignAttri("", false, "A112WWPUserExtendedId", A112WWPUserExtendedId);
            n112WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A112WWPUserExtendedId)) ? true : false);
            A113WWPUserExtendedFullName = cgiGet( edtWWPUserExtendedFullName_Internalname);
            AssignAttri("", false, "A113WWPUserExtendedFullName", A113WWPUserExtendedFullName);
            A165WWPNotificationMetadata = cgiGet( edtWWPNotificationMetadata_Internalname);
            n165WWPNotificationMetadata = false;
            AssignAttri("", false, "A165WWPNotificationMetadata", A165WWPNotificationMetadata);
            n165WWPNotificationMetadata = (String.IsNullOrEmpty(StringUtil.RTrim( A165WWPNotificationMetadata)) ? true : false);
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
               A127WWPNotificationId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPNotificationId"), "."), 18, MidpointRounding.ToEven));
               n127WWPNotificationId = false;
               AssignAttri("", false, "A127WWPNotificationId", StringUtil.LTrimStr( (decimal)(A127WWPNotificationId), 10, 0));
               getEqualNoModal( ) ;
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
               InitAll0O34( ) ;
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
         DisableAttributes0O34( ) ;
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

      protected void ResetCaption0O0( )
      {
      }

      protected void ZM0O34( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z129WWPNotificationCreated = T000O3_A129WWPNotificationCreated[0];
               Z181WWPNotificationIcon = T000O3_A181WWPNotificationIcon[0];
               Z182WWPNotificationTitle = T000O3_A182WWPNotificationTitle[0];
               Z183WWPNotificationShortDescriptio = T000O3_A183WWPNotificationShortDescriptio[0];
               Z184WWPNotificationLink = T000O3_A184WWPNotificationLink[0];
               Z187WWPNotificationIsRead = T000O3_A187WWPNotificationIsRead[0];
               Z128WWPNotificationDefinitionId = T000O3_A128WWPNotificationDefinitionId[0];
               Z112WWPUserExtendedId = T000O3_A112WWPUserExtendedId[0];
            }
            else
            {
               Z129WWPNotificationCreated = A129WWPNotificationCreated;
               Z181WWPNotificationIcon = A181WWPNotificationIcon;
               Z182WWPNotificationTitle = A182WWPNotificationTitle;
               Z183WWPNotificationShortDescriptio = A183WWPNotificationShortDescriptio;
               Z184WWPNotificationLink = A184WWPNotificationLink;
               Z187WWPNotificationIsRead = A187WWPNotificationIsRead;
               Z128WWPNotificationDefinitionId = A128WWPNotificationDefinitionId;
               Z112WWPUserExtendedId = A112WWPUserExtendedId;
            }
         }
         if ( GX_JID == -4 )
         {
            Z127WWPNotificationId = A127WWPNotificationId;
            Z129WWPNotificationCreated = A129WWPNotificationCreated;
            Z181WWPNotificationIcon = A181WWPNotificationIcon;
            Z182WWPNotificationTitle = A182WWPNotificationTitle;
            Z183WWPNotificationShortDescriptio = A183WWPNotificationShortDescriptio;
            Z184WWPNotificationLink = A184WWPNotificationLink;
            Z187WWPNotificationIsRead = A187WWPNotificationIsRead;
            Z165WWPNotificationMetadata = A165WWPNotificationMetadata;
            Z128WWPNotificationDefinitionId = A128WWPNotificationDefinitionId;
            Z112WWPUserExtendedId = A112WWPUserExtendedId;
            Z164WWPNotificationDefinitionName = A164WWPNotificationDefinitionName;
            Z113WWPUserExtendedFullName = A113WWPUserExtendedFullName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A129WWPNotificationCreated) && ( Gx_BScreen == 0 ) )
         {
            A129WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A129WWPNotificationCreated", context.localUtil.TToC( A129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
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
      }

      protected void Load0O34( )
      {
         /* Using cursor T000O6 */
         pr_default.execute(4, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound34 = 1;
            A164WWPNotificationDefinitionName = T000O6_A164WWPNotificationDefinitionName[0];
            AssignAttri("", false, "A164WWPNotificationDefinitionName", A164WWPNotificationDefinitionName);
            A129WWPNotificationCreated = T000O6_A129WWPNotificationCreated[0];
            AssignAttri("", false, "A129WWPNotificationCreated", context.localUtil.TToC( A129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A181WWPNotificationIcon = T000O6_A181WWPNotificationIcon[0];
            AssignAttri("", false, "A181WWPNotificationIcon", A181WWPNotificationIcon);
            A182WWPNotificationTitle = T000O6_A182WWPNotificationTitle[0];
            AssignAttri("", false, "A182WWPNotificationTitle", A182WWPNotificationTitle);
            A183WWPNotificationShortDescriptio = T000O6_A183WWPNotificationShortDescriptio[0];
            AssignAttri("", false, "A183WWPNotificationShortDescriptio", A183WWPNotificationShortDescriptio);
            A184WWPNotificationLink = T000O6_A184WWPNotificationLink[0];
            AssignAttri("", false, "A184WWPNotificationLink", A184WWPNotificationLink);
            A187WWPNotificationIsRead = T000O6_A187WWPNotificationIsRead[0];
            AssignAttri("", false, "A187WWPNotificationIsRead", A187WWPNotificationIsRead);
            A113WWPUserExtendedFullName = T000O6_A113WWPUserExtendedFullName[0];
            AssignAttri("", false, "A113WWPUserExtendedFullName", A113WWPUserExtendedFullName);
            A165WWPNotificationMetadata = T000O6_A165WWPNotificationMetadata[0];
            n165WWPNotificationMetadata = T000O6_n165WWPNotificationMetadata[0];
            AssignAttri("", false, "A165WWPNotificationMetadata", A165WWPNotificationMetadata);
            A128WWPNotificationDefinitionId = T000O6_A128WWPNotificationDefinitionId[0];
            AssignAttri("", false, "A128WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A128WWPNotificationDefinitionId), 10, 0));
            A112WWPUserExtendedId = T000O6_A112WWPUserExtendedId[0];
            n112WWPUserExtendedId = T000O6_n112WWPUserExtendedId[0];
            AssignAttri("", false, "A112WWPUserExtendedId", A112WWPUserExtendedId);
            ZM0O34( -4) ;
         }
         pr_default.close(4);
         OnLoadActions0O34( ) ;
      }

      protected void OnLoadActions0O34( )
      {
      }

      protected void CheckExtendedTable0O34( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000O4 */
         pr_default.execute(2, new Object[] {A128WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_NotificationDefinition", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A164WWPNotificationDefinitionName = T000O4_A164WWPNotificationDefinitionName[0];
         AssignAttri("", false, "A164WWPNotificationDefinitionName", A164WWPNotificationDefinitionName);
         pr_default.close(2);
         if ( ! ( GxRegex.IsMatch(A184WWPNotificationLink,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Notification Link", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "WWPNOTIFICATIONLINK");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationLink_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000O5 */
         pr_default.execute(3, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A112WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_UserExtended", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
               GX_FocusControl = edtWWPUserExtendedId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A113WWPUserExtendedFullName = T000O5_A113WWPUserExtendedFullName[0];
         AssignAttri("", false, "A113WWPUserExtendedFullName", A113WWPUserExtendedFullName);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0O34( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_5( long A128WWPNotificationDefinitionId )
      {
         /* Using cursor T000O7 */
         pr_default.execute(5, new Object[] {A128WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_NotificationDefinition", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A164WWPNotificationDefinitionName = T000O7_A164WWPNotificationDefinitionName[0];
         AssignAttri("", false, "A164WWPNotificationDefinitionName", A164WWPNotificationDefinitionName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A164WWPNotificationDefinitionName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_6( string A112WWPUserExtendedId )
      {
         /* Using cursor T000O8 */
         pr_default.execute(6, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A112WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_UserExtended", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
               GX_FocusControl = edtWWPUserExtendedId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A113WWPUserExtendedFullName = T000O8_A113WWPUserExtendedFullName[0];
         AssignAttri("", false, "A113WWPUserExtendedFullName", A113WWPUserExtendedFullName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A113WWPUserExtendedFullName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey0O34( )
      {
         /* Using cursor T000O9 */
         pr_default.execute(7, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound34 = 1;
         }
         else
         {
            RcdFound34 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000O3 */
         pr_default.execute(1, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0O34( 4) ;
            RcdFound34 = 1;
            A127WWPNotificationId = T000O3_A127WWPNotificationId[0];
            n127WWPNotificationId = T000O3_n127WWPNotificationId[0];
            AssignAttri("", false, "A127WWPNotificationId", StringUtil.LTrimStr( (decimal)(A127WWPNotificationId), 10, 0));
            A129WWPNotificationCreated = T000O3_A129WWPNotificationCreated[0];
            AssignAttri("", false, "A129WWPNotificationCreated", context.localUtil.TToC( A129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A181WWPNotificationIcon = T000O3_A181WWPNotificationIcon[0];
            AssignAttri("", false, "A181WWPNotificationIcon", A181WWPNotificationIcon);
            A182WWPNotificationTitle = T000O3_A182WWPNotificationTitle[0];
            AssignAttri("", false, "A182WWPNotificationTitle", A182WWPNotificationTitle);
            A183WWPNotificationShortDescriptio = T000O3_A183WWPNotificationShortDescriptio[0];
            AssignAttri("", false, "A183WWPNotificationShortDescriptio", A183WWPNotificationShortDescriptio);
            A184WWPNotificationLink = T000O3_A184WWPNotificationLink[0];
            AssignAttri("", false, "A184WWPNotificationLink", A184WWPNotificationLink);
            A187WWPNotificationIsRead = T000O3_A187WWPNotificationIsRead[0];
            AssignAttri("", false, "A187WWPNotificationIsRead", A187WWPNotificationIsRead);
            A165WWPNotificationMetadata = T000O3_A165WWPNotificationMetadata[0];
            n165WWPNotificationMetadata = T000O3_n165WWPNotificationMetadata[0];
            AssignAttri("", false, "A165WWPNotificationMetadata", A165WWPNotificationMetadata);
            A128WWPNotificationDefinitionId = T000O3_A128WWPNotificationDefinitionId[0];
            AssignAttri("", false, "A128WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A128WWPNotificationDefinitionId), 10, 0));
            A112WWPUserExtendedId = T000O3_A112WWPUserExtendedId[0];
            n112WWPUserExtendedId = T000O3_n112WWPUserExtendedId[0];
            AssignAttri("", false, "A112WWPUserExtendedId", A112WWPUserExtendedId);
            Z127WWPNotificationId = A127WWPNotificationId;
            sMode34 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0O34( ) ;
            if ( AnyError == 1 )
            {
               RcdFound34 = 0;
               InitializeNonKey0O34( ) ;
            }
            Gx_mode = sMode34;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound34 = 0;
            InitializeNonKey0O34( ) ;
            sMode34 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode34;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0O34( ) ;
         if ( RcdFound34 == 0 )
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
         RcdFound34 = 0;
         /* Using cursor T000O10 */
         pr_default.execute(8, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000O10_A127WWPNotificationId[0] < A127WWPNotificationId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000O10_A127WWPNotificationId[0] > A127WWPNotificationId ) ) )
            {
               A127WWPNotificationId = T000O10_A127WWPNotificationId[0];
               n127WWPNotificationId = T000O10_n127WWPNotificationId[0];
               AssignAttri("", false, "A127WWPNotificationId", StringUtil.LTrimStr( (decimal)(A127WWPNotificationId), 10, 0));
               RcdFound34 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound34 = 0;
         /* Using cursor T000O11 */
         pr_default.execute(9, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000O11_A127WWPNotificationId[0] > A127WWPNotificationId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000O11_A127WWPNotificationId[0] < A127WWPNotificationId ) ) )
            {
               A127WWPNotificationId = T000O11_A127WWPNotificationId[0];
               n127WWPNotificationId = T000O11_n127WWPNotificationId[0];
               AssignAttri("", false, "A127WWPNotificationId", StringUtil.LTrimStr( (decimal)(A127WWPNotificationId), 10, 0));
               RcdFound34 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0O34( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0O34( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound34 == 1 )
            {
               if ( A127WWPNotificationId != Z127WWPNotificationId )
               {
                  A127WWPNotificationId = Z127WWPNotificationId;
                  n127WWPNotificationId = false;
                  AssignAttri("", false, "A127WWPNotificationId", StringUtil.LTrimStr( (decimal)(A127WWPNotificationId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPNOTIFICATIONID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0O34( ) ;
                  GX_FocusControl = edtWWPNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A127WWPNotificationId != Z127WWPNotificationId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0O34( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPNOTIFICATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPNotificationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPNotificationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0O34( ) ;
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
         if ( A127WWPNotificationId != Z127WWPNotificationId )
         {
            A127WWPNotificationId = Z127WWPNotificationId;
            n127WWPNotificationId = false;
            AssignAttri("", false, "A127WWPNotificationId", StringUtil.LTrimStr( (decimal)(A127WWPNotificationId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPNOTIFICATIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPNotificationId_Internalname;
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
         if ( RcdFound34 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPNOTIFICATIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0O34( ) ;
         if ( RcdFound34 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0O34( ) ;
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
         if ( RcdFound34 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
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
         if ( RcdFound34 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
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
         ScanStart0O34( ) ;
         if ( RcdFound34 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound34 != 0 )
            {
               ScanNext0O34( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0O34( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0O34( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000O2 */
            pr_default.execute(0, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Notification"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z129WWPNotificationCreated != T000O2_A129WWPNotificationCreated[0] ) || ( StringUtil.StrCmp(Z181WWPNotificationIcon, T000O2_A181WWPNotificationIcon[0]) != 0 ) || ( StringUtil.StrCmp(Z182WWPNotificationTitle, T000O2_A182WWPNotificationTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z183WWPNotificationShortDescriptio, T000O2_A183WWPNotificationShortDescriptio[0]) != 0 ) || ( StringUtil.StrCmp(Z184WWPNotificationLink, T000O2_A184WWPNotificationLink[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z187WWPNotificationIsRead != T000O2_A187WWPNotificationIsRead[0] ) || ( Z128WWPNotificationDefinitionId != T000O2_A128WWPNotificationDefinitionId[0] ) || ( StringUtil.StrCmp(Z112WWPUserExtendedId, T000O2_A112WWPUserExtendedId[0]) != 0 ) )
            {
               if ( Z129WWPNotificationCreated != T000O2_A129WWPNotificationCreated[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationCreated");
                  GXUtil.WriteLogRaw("Old: ",Z129WWPNotificationCreated);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A129WWPNotificationCreated[0]);
               }
               if ( StringUtil.StrCmp(Z181WWPNotificationIcon, T000O2_A181WWPNotificationIcon[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationIcon");
                  GXUtil.WriteLogRaw("Old: ",Z181WWPNotificationIcon);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A181WWPNotificationIcon[0]);
               }
               if ( StringUtil.StrCmp(Z182WWPNotificationTitle, T000O2_A182WWPNotificationTitle[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationTitle");
                  GXUtil.WriteLogRaw("Old: ",Z182WWPNotificationTitle);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A182WWPNotificationTitle[0]);
               }
               if ( StringUtil.StrCmp(Z183WWPNotificationShortDescriptio, T000O2_A183WWPNotificationShortDescriptio[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationShortDescriptio");
                  GXUtil.WriteLogRaw("Old: ",Z183WWPNotificationShortDescriptio);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A183WWPNotificationShortDescriptio[0]);
               }
               if ( StringUtil.StrCmp(Z184WWPNotificationLink, T000O2_A184WWPNotificationLink[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationLink");
                  GXUtil.WriteLogRaw("Old: ",Z184WWPNotificationLink);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A184WWPNotificationLink[0]);
               }
               if ( Z187WWPNotificationIsRead != T000O2_A187WWPNotificationIsRead[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationIsRead");
                  GXUtil.WriteLogRaw("Old: ",Z187WWPNotificationIsRead);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A187WWPNotificationIsRead[0]);
               }
               if ( Z128WWPNotificationDefinitionId != T000O2_A128WWPNotificationDefinitionId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationDefinitionId");
                  GXUtil.WriteLogRaw("Old: ",Z128WWPNotificationDefinitionId);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A128WWPNotificationDefinitionId[0]);
               }
               if ( StringUtil.StrCmp(Z112WWPUserExtendedId, T000O2_A112WWPUserExtendedId[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPUserExtendedId");
                  GXUtil.WriteLogRaw("Old: ",Z112WWPUserExtendedId);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A112WWPUserExtendedId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Notification"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0O34( )
      {
         if ( ! IsAuthorized("wwp_notification_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0O34( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0O34( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0O34( 0) ;
            CheckOptimisticConcurrency0O34( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0O34( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0O34( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000O12 */
                     pr_default.execute(10, new Object[] {A129WWPNotificationCreated, A181WWPNotificationIcon, A182WWPNotificationTitle, A183WWPNotificationShortDescriptio, A184WWPNotificationLink, A187WWPNotificationIsRead, n165WWPNotificationMetadata, A165WWPNotificationMetadata, A128WWPNotificationDefinitionId, n112WWPUserExtendedId, A112WWPUserExtendedId});
                     pr_default.close(10);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000O13 */
                     pr_default.execute(11);
                     A127WWPNotificationId = T000O13_A127WWPNotificationId[0];
                     n127WWPNotificationId = T000O13_n127WWPNotificationId[0];
                     AssignAttri("", false, "A127WWPNotificationId", StringUtil.LTrimStr( (decimal)(A127WWPNotificationId), 10, 0));
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0O0( ) ;
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
               Load0O34( ) ;
            }
            EndLevel0O34( ) ;
         }
         CloseExtendedTableCursors0O34( ) ;
      }

      protected void Update0O34( )
      {
         if ( ! IsAuthorized("wwp_notification_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0O34( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0O34( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0O34( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0O34( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0O34( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000O14 */
                     pr_default.execute(12, new Object[] {A129WWPNotificationCreated, A181WWPNotificationIcon, A182WWPNotificationTitle, A183WWPNotificationShortDescriptio, A184WWPNotificationLink, A187WWPNotificationIsRead, n165WWPNotificationMetadata, A165WWPNotificationMetadata, A128WWPNotificationDefinitionId, n112WWPUserExtendedId, A112WWPUserExtendedId, n127WWPNotificationId, A127WWPNotificationId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Notification"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0O34( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0O0( ) ;
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
            EndLevel0O34( ) ;
         }
         CloseExtendedTableCursors0O34( ) ;
      }

      protected void DeferredUpdate0O34( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("wwp_notification_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0O34( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0O34( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0O34( ) ;
            AfterConfirm0O34( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0O34( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000O15 */
                  pr_default.execute(13, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound34 == 0 )
                        {
                           InitAll0O34( ) ;
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
                        ResetCaption0O0( ) ;
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
         sMode34 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0O34( ) ;
         Gx_mode = sMode34;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0O34( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000O16 */
            pr_default.execute(14, new Object[] {A128WWPNotificationDefinitionId});
            A164WWPNotificationDefinitionName = T000O16_A164WWPNotificationDefinitionName[0];
            AssignAttri("", false, "A164WWPNotificationDefinitionName", A164WWPNotificationDefinitionName);
            pr_default.close(14);
            /* Using cursor T000O17 */
            pr_default.execute(15, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
            A113WWPUserExtendedFullName = T000O17_A113WWPUserExtendedFullName[0];
            AssignAttri("", false, "A113WWPUserExtendedFullName", A113WWPUserExtendedFullName);
            pr_default.close(15);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000O18 */
            pr_default.execute(16, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_Mail", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T000O19 */
            pr_default.execute(17, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_WebNotification", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T000O20 */
            pr_default.execute(18, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_SMS", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
         }
      }

      protected void EndLevel0O34( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0O34( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("wwpbaseobjects.notifications.common.wwp_notification",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0O0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("wwpbaseobjects.notifications.common.wwp_notification",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0O34( )
      {
         /* Using cursor T000O21 */
         pr_default.execute(19);
         RcdFound34 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound34 = 1;
            A127WWPNotificationId = T000O21_A127WWPNotificationId[0];
            n127WWPNotificationId = T000O21_n127WWPNotificationId[0];
            AssignAttri("", false, "A127WWPNotificationId", StringUtil.LTrimStr( (decimal)(A127WWPNotificationId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0O34( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound34 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound34 = 1;
            A127WWPNotificationId = T000O21_A127WWPNotificationId[0];
            n127WWPNotificationId = T000O21_n127WWPNotificationId[0];
            AssignAttri("", false, "A127WWPNotificationId", StringUtil.LTrimStr( (decimal)(A127WWPNotificationId), 10, 0));
         }
      }

      protected void ScanEnd0O34( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm0O34( )
      {
         /* After Confirm Rules */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A112WWPUserExtendedId)) )
         {
            A112WWPUserExtendedId = "";
            n112WWPUserExtendedId = false;
            AssignAttri("", false, "A112WWPUserExtendedId", A112WWPUserExtendedId);
            n112WWPUserExtendedId = true;
            AssignAttri("", false, "A112WWPUserExtendedId", A112WWPUserExtendedId);
         }
      }

      protected void BeforeInsert0O34( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0O34( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0O34( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0O34( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0O34( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0O34( )
      {
         edtWWPNotificationId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationId_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionId_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionName_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionName_Enabled), 5, 0), true);
         edtWWPNotificationCreated_Enabled = 0;
         AssignProp("", false, edtWWPNotificationCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationCreated_Enabled), 5, 0), true);
         edtWWPNotificationIcon_Enabled = 0;
         AssignProp("", false, edtWWPNotificationIcon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationIcon_Enabled), 5, 0), true);
         edtWWPNotificationTitle_Enabled = 0;
         AssignProp("", false, edtWWPNotificationTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationTitle_Enabled), 5, 0), true);
         edtWWPNotificationShortDescriptio_Enabled = 0;
         AssignProp("", false, edtWWPNotificationShortDescriptio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationShortDescriptio_Enabled), 5, 0), true);
         edtWWPNotificationLink_Enabled = 0;
         AssignProp("", false, edtWWPNotificationLink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationLink_Enabled), 5, 0), true);
         chkWWPNotificationIsRead.Enabled = 0;
         AssignProp("", false, chkWWPNotificationIsRead_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPNotificationIsRead.Enabled), 5, 0), true);
         edtWWPUserExtendedId_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedId_Enabled), 5, 0), true);
         edtWWPUserExtendedFullName_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedFullName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedFullName_Enabled), 5, 0), true);
         edtWWPNotificationMetadata_Enabled = 0;
         AssignProp("", false, edtWWPNotificationMetadata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationMetadata_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0O34( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0O0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.notifications.common.wwp_notification.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z127WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z127WWPNotificationId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z129WWPNotificationCreated", context.localUtil.TToC( Z129WWPNotificationCreated, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z181WWPNotificationIcon", Z181WWPNotificationIcon);
         GxWebStd.gx_hidden_field( context, "Z182WWPNotificationTitle", Z182WWPNotificationTitle);
         GxWebStd.gx_hidden_field( context, "Z183WWPNotificationShortDescriptio", Z183WWPNotificationShortDescriptio);
         GxWebStd.gx_hidden_field( context, "Z184WWPNotificationLink", Z184WWPNotificationLink);
         GxWebStd.gx_boolean_hidden_field( context, "Z187WWPNotificationIsRead", Z187WWPNotificationIsRead);
         GxWebStd.gx_hidden_field( context, "Z128WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z128WWPNotificationDefinitionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z112WWPUserExtendedId", StringUtil.RTrim( Z112WWPUserExtendedId));
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
         return formatLink("wwpbaseobjects.notifications.common.wwp_notification.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Notifications.Common.WWP_Notification" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Notification", "") ;
      }

      protected void InitializeNonKey0O34( )
      {
         A128WWPNotificationDefinitionId = 0;
         AssignAttri("", false, "A128WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A128WWPNotificationDefinitionId), 10, 0));
         A164WWPNotificationDefinitionName = "";
         AssignAttri("", false, "A164WWPNotificationDefinitionName", A164WWPNotificationDefinitionName);
         A181WWPNotificationIcon = "";
         AssignAttri("", false, "A181WWPNotificationIcon", A181WWPNotificationIcon);
         A182WWPNotificationTitle = "";
         AssignAttri("", false, "A182WWPNotificationTitle", A182WWPNotificationTitle);
         A183WWPNotificationShortDescriptio = "";
         AssignAttri("", false, "A183WWPNotificationShortDescriptio", A183WWPNotificationShortDescriptio);
         A184WWPNotificationLink = "";
         AssignAttri("", false, "A184WWPNotificationLink", A184WWPNotificationLink);
         A187WWPNotificationIsRead = false;
         AssignAttri("", false, "A187WWPNotificationIsRead", A187WWPNotificationIsRead);
         A112WWPUserExtendedId = "";
         n112WWPUserExtendedId = false;
         AssignAttri("", false, "A112WWPUserExtendedId", A112WWPUserExtendedId);
         n112WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A112WWPUserExtendedId)) ? true : false);
         A113WWPUserExtendedFullName = "";
         AssignAttri("", false, "A113WWPUserExtendedFullName", A113WWPUserExtendedFullName);
         A165WWPNotificationMetadata = "";
         n165WWPNotificationMetadata = false;
         AssignAttri("", false, "A165WWPNotificationMetadata", A165WWPNotificationMetadata);
         n165WWPNotificationMetadata = (String.IsNullOrEmpty(StringUtil.RTrim( A165WWPNotificationMetadata)) ? true : false);
         A129WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A129WWPNotificationCreated", context.localUtil.TToC( A129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         Z129WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z181WWPNotificationIcon = "";
         Z182WWPNotificationTitle = "";
         Z183WWPNotificationShortDescriptio = "";
         Z184WWPNotificationLink = "";
         Z187WWPNotificationIsRead = false;
         Z128WWPNotificationDefinitionId = 0;
         Z112WWPUserExtendedId = "";
      }

      protected void InitAll0O34( )
      {
         A127WWPNotificationId = 0;
         n127WWPNotificationId = false;
         AssignAttri("", false, "A127WWPNotificationId", StringUtil.LTrimStr( (decimal)(A127WWPNotificationId), 10, 0));
         InitializeNonKey0O34( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A129WWPNotificationCreated = i129WWPNotificationCreated;
         AssignAttri("", false, "A129WWPNotificationCreated", context.localUtil.TToC( A129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256145335215", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/notifications/common/wwp_notification.js", "?20256145335216", false, true);
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
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID";
         edtWWPNotificationDefinitionId_Internalname = "WWPNOTIFICATIONDEFINITIONID";
         edtWWPNotificationDefinitionName_Internalname = "WWPNOTIFICATIONDEFINITIONNAME";
         edtWWPNotificationCreated_Internalname = "WWPNOTIFICATIONCREATED";
         edtWWPNotificationIcon_Internalname = "WWPNOTIFICATIONICON";
         edtWWPNotificationTitle_Internalname = "WWPNOTIFICATIONTITLE";
         edtWWPNotificationShortDescriptio_Internalname = "WWPNOTIFICATIONSHORTDESCRIPTIO";
         edtWWPNotificationLink_Internalname = "WWPNOTIFICATIONLINK";
         chkWWPNotificationIsRead_Internalname = "WWPNOTIFICATIONISREAD";
         edtWWPUserExtendedId_Internalname = "WWPUSEREXTENDEDID";
         edtWWPUserExtendedFullName_Internalname = "WWPUSEREXTENDEDFULLNAME";
         edtWWPNotificationMetadata_Internalname = "WWPNOTIFICATIONMETADATA";
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
         Form.Caption = context.GetMessage( "Notification", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtWWPNotificationMetadata_Enabled = 1;
         edtWWPUserExtendedFullName_Jsonclick = "";
         edtWWPUserExtendedFullName_Enabled = 0;
         edtWWPUserExtendedId_Jsonclick = "";
         edtWWPUserExtendedId_Enabled = 1;
         chkWWPNotificationIsRead.Enabled = 1;
         edtWWPNotificationLink_Jsonclick = "";
         edtWWPNotificationLink_Enabled = 1;
         edtWWPNotificationShortDescriptio_Enabled = 1;
         edtWWPNotificationTitle_Enabled = 1;
         edtWWPNotificationIcon_Jsonclick = "";
         edtWWPNotificationIcon_Enabled = 1;
         edtWWPNotificationCreated_Jsonclick = "";
         edtWWPNotificationCreated_Enabled = 1;
         edtWWPNotificationDefinitionName_Jsonclick = "";
         edtWWPNotificationDefinitionName_Enabled = 0;
         edtWWPNotificationDefinitionId_Jsonclick = "";
         edtWWPNotificationDefinitionId_Enabled = 1;
         edtWWPNotificationId_Jsonclick = "";
         edtWWPNotificationId_Enabled = 1;
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
         chkWWPNotificationIsRead.Name = "WWPNOTIFICATIONISREAD";
         chkWWPNotificationIsRead.WebTags = "";
         chkWWPNotificationIsRead.Caption = context.GetMessage( "Is Read", "");
         AssignProp("", false, chkWWPNotificationIsRead_Internalname, "TitleCaption", chkWWPNotificationIsRead.Caption, true);
         chkWWPNotificationIsRead.CheckedValue = "false";
         A187WWPNotificationIsRead = StringUtil.StrToBool( StringUtil.BoolToStr( A187WWPNotificationIsRead));
         AssignAttri("", false, "A187WWPNotificationIsRead", A187WWPNotificationIsRead);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
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

      public void Valid_Wwpnotificationid( )
      {
         n127WWPNotificationId = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A187WWPNotificationIsRead = StringUtil.StrToBool( StringUtil.BoolToStr( A187WWPNotificationIsRead));
         /*  Sending validation outputs */
         AssignAttri("", false, "A128WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A128WWPNotificationDefinitionId), 10, 0, ".", "")));
         AssignAttri("", false, "A129WWPNotificationCreated", context.localUtil.TToC( A129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A181WWPNotificationIcon", A181WWPNotificationIcon);
         AssignAttri("", false, "A182WWPNotificationTitle", A182WWPNotificationTitle);
         AssignAttri("", false, "A183WWPNotificationShortDescriptio", A183WWPNotificationShortDescriptio);
         AssignAttri("", false, "A184WWPNotificationLink", A184WWPNotificationLink);
         AssignAttri("", false, "A187WWPNotificationIsRead", A187WWPNotificationIsRead);
         AssignAttri("", false, "A112WWPUserExtendedId", StringUtil.RTrim( A112WWPUserExtendedId));
         AssignAttri("", false, "A165WWPNotificationMetadata", A165WWPNotificationMetadata);
         AssignAttri("", false, "A164WWPNotificationDefinitionName", A164WWPNotificationDefinitionName);
         AssignAttri("", false, "A113WWPUserExtendedFullName", A113WWPUserExtendedFullName);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z127WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z127WWPNotificationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z128WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z128WWPNotificationDefinitionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z129WWPNotificationCreated", context.localUtil.TToC( Z129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z181WWPNotificationIcon", Z181WWPNotificationIcon);
         GxWebStd.gx_hidden_field( context, "Z182WWPNotificationTitle", Z182WWPNotificationTitle);
         GxWebStd.gx_hidden_field( context, "Z183WWPNotificationShortDescriptio", Z183WWPNotificationShortDescriptio);
         GxWebStd.gx_hidden_field( context, "Z184WWPNotificationLink", Z184WWPNotificationLink);
         GxWebStd.gx_hidden_field( context, "Z187WWPNotificationIsRead", StringUtil.BoolToStr( Z187WWPNotificationIsRead));
         GxWebStd.gx_hidden_field( context, "Z112WWPUserExtendedId", StringUtil.RTrim( Z112WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "Z165WWPNotificationMetadata", Z165WWPNotificationMetadata);
         GxWebStd.gx_hidden_field( context, "Z164WWPNotificationDefinitionName", Z164WWPNotificationDefinitionName);
         GxWebStd.gx_hidden_field( context, "Z113WWPUserExtendedFullName", Z113WWPUserExtendedFullName);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpnotificationdefinitionid( )
      {
         /* Using cursor T000O16 */
         pr_default.execute(14, new Object[] {A128WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_NotificationDefinition", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
         }
         A164WWPNotificationDefinitionName = T000O16_A164WWPNotificationDefinitionName[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A164WWPNotificationDefinitionName", A164WWPNotificationDefinitionName);
      }

      public void Valid_Wwpuserextendedid( )
      {
         n112WWPUserExtendedId = false;
         /* Using cursor T000O17 */
         pr_default.execute(15, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A112WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_UserExtended", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
               GX_FocusControl = edtWWPUserExtendedId_Internalname;
            }
         }
         A113WWPUserExtendedFullName = T000O17_A113WWPUserExtendedFullName[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A113WWPUserExtendedFullName", A113WWPUserExtendedFullName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A187WWPNotificationIsRead","fld":"WWPNOTIFICATIONISREAD"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A187WWPNotificationIsRead","fld":"WWPNOTIFICATIONISREAD"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A187WWPNotificationIsRead","fld":"WWPNOTIFICATIONISREAD"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A187WWPNotificationIsRead","fld":"WWPNOTIFICATIONISREAD"}]}""");
         setEventMetadata("VALID_WWPNOTIFICATIONID","""{"handler":"Valid_Wwpnotificationid","iparms":[{"av":"A127WWPNotificationId","fld":"WWPNOTIFICATIONID","pic":"ZZZZZZZZZ9"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"A129WWPNotificationCreated","fld":"WWPNOTIFICATIONCREATED","pic":"99/99/9999 99:99:99.999"},{"av":"A187WWPNotificationIsRead","fld":"WWPNOTIFICATIONISREAD"}]""");
         setEventMetadata("VALID_WWPNOTIFICATIONID",""","oparms":[{"av":"A128WWPNotificationDefinitionId","fld":"WWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9"},{"av":"A129WWPNotificationCreated","fld":"WWPNOTIFICATIONCREATED","pic":"99/99/9999 99:99:99.999"},{"av":"A181WWPNotificationIcon","fld":"WWPNOTIFICATIONICON"},{"av":"A182WWPNotificationTitle","fld":"WWPNOTIFICATIONTITLE"},{"av":"A183WWPNotificationShortDescriptio","fld":"WWPNOTIFICATIONSHORTDESCRIPTIO"},{"av":"A184WWPNotificationLink","fld":"WWPNOTIFICATIONLINK"},{"av":"A112WWPUserExtendedId","fld":"WWPUSEREXTENDEDID"},{"av":"A165WWPNotificationMetadata","fld":"WWPNOTIFICATIONMETADATA"},{"av":"A164WWPNotificationDefinitionName","fld":"WWPNOTIFICATIONDEFINITIONNAME"},{"av":"A113WWPUserExtendedFullName","fld":"WWPUSEREXTENDEDFULLNAME"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z127WWPNotificationId"},{"av":"Z128WWPNotificationDefinitionId"},{"av":"Z129WWPNotificationCreated"},{"av":"Z181WWPNotificationIcon"},{"av":"Z182WWPNotificationTitle"},{"av":"Z183WWPNotificationShortDescriptio"},{"av":"Z184WWPNotificationLink"},{"av":"Z187WWPNotificationIsRead"},{"av":"Z112WWPUserExtendedId"},{"av":"Z165WWPNotificationMetadata"},{"av":"Z164WWPNotificationDefinitionName"},{"av":"Z113WWPUserExtendedFullName"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A187WWPNotificationIsRead","fld":"WWPNOTIFICATIONISREAD"}]}""");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONID","""{"handler":"Valid_Wwpnotificationdefinitionid","iparms":[{"av":"A128WWPNotificationDefinitionId","fld":"WWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9"},{"av":"A164WWPNotificationDefinitionName","fld":"WWPNOTIFICATIONDEFINITIONNAME"},{"av":"A187WWPNotificationIsRead","fld":"WWPNOTIFICATIONISREAD"}]""");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONID",""","oparms":[{"av":"A164WWPNotificationDefinitionName","fld":"WWPNOTIFICATIONDEFINITIONNAME"},{"av":"A187WWPNotificationIsRead","fld":"WWPNOTIFICATIONISREAD"}]}""");
         setEventMetadata("VALID_WWPNOTIFICATIONLINK","""{"handler":"Valid_Wwpnotificationlink","iparms":[{"av":"A187WWPNotificationIsRead","fld":"WWPNOTIFICATIONISREAD"}]""");
         setEventMetadata("VALID_WWPNOTIFICATIONLINK",""","oparms":[{"av":"A187WWPNotificationIsRead","fld":"WWPNOTIFICATIONISREAD"}]}""");
         setEventMetadata("VALID_WWPUSEREXTENDEDID","""{"handler":"Valid_Wwpuserextendedid","iparms":[{"av":"A112WWPUserExtendedId","fld":"WWPUSEREXTENDEDID"},{"av":"A113WWPUserExtendedFullName","fld":"WWPUSEREXTENDEDFULLNAME"},{"av":"A187WWPNotificationIsRead","fld":"WWPNOTIFICATIONISREAD"}]""");
         setEventMetadata("VALID_WWPUSEREXTENDEDID",""","oparms":[{"av":"A113WWPUserExtendedFullName","fld":"WWPUSEREXTENDEDFULLNAME"},{"av":"A187WWPNotificationIsRead","fld":"WWPNOTIFICATIONISREAD"}]}""");
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
         pr_default.close(14);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z129WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z181WWPNotificationIcon = "";
         Z182WWPNotificationTitle = "";
         Z183WWPNotificationShortDescriptio = "";
         Z184WWPNotificationLink = "";
         Z112WWPUserExtendedId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A112WWPUserExtendedId = "";
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
         A164WWPNotificationDefinitionName = "";
         A129WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A181WWPNotificationIcon = "";
         A182WWPNotificationTitle = "";
         A183WWPNotificationShortDescriptio = "";
         A184WWPNotificationLink = "";
         A113WWPUserExtendedFullName = "";
         A165WWPNotificationMetadata = "";
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
         Z165WWPNotificationMetadata = "";
         Z164WWPNotificationDefinitionName = "";
         Z113WWPUserExtendedFullName = "";
         T000O6_A127WWPNotificationId = new long[1] ;
         T000O6_n127WWPNotificationId = new bool[] {false} ;
         T000O6_A164WWPNotificationDefinitionName = new string[] {""} ;
         T000O6_A129WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000O6_A181WWPNotificationIcon = new string[] {""} ;
         T000O6_A182WWPNotificationTitle = new string[] {""} ;
         T000O6_A183WWPNotificationShortDescriptio = new string[] {""} ;
         T000O6_A184WWPNotificationLink = new string[] {""} ;
         T000O6_A187WWPNotificationIsRead = new bool[] {false} ;
         T000O6_A113WWPUserExtendedFullName = new string[] {""} ;
         T000O6_A165WWPNotificationMetadata = new string[] {""} ;
         T000O6_n165WWPNotificationMetadata = new bool[] {false} ;
         T000O6_A128WWPNotificationDefinitionId = new long[1] ;
         T000O6_A112WWPUserExtendedId = new string[] {""} ;
         T000O6_n112WWPUserExtendedId = new bool[] {false} ;
         T000O4_A164WWPNotificationDefinitionName = new string[] {""} ;
         T000O5_A113WWPUserExtendedFullName = new string[] {""} ;
         T000O7_A164WWPNotificationDefinitionName = new string[] {""} ;
         T000O8_A113WWPUserExtendedFullName = new string[] {""} ;
         T000O9_A127WWPNotificationId = new long[1] ;
         T000O9_n127WWPNotificationId = new bool[] {false} ;
         T000O3_A127WWPNotificationId = new long[1] ;
         T000O3_n127WWPNotificationId = new bool[] {false} ;
         T000O3_A129WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000O3_A181WWPNotificationIcon = new string[] {""} ;
         T000O3_A182WWPNotificationTitle = new string[] {""} ;
         T000O3_A183WWPNotificationShortDescriptio = new string[] {""} ;
         T000O3_A184WWPNotificationLink = new string[] {""} ;
         T000O3_A187WWPNotificationIsRead = new bool[] {false} ;
         T000O3_A165WWPNotificationMetadata = new string[] {""} ;
         T000O3_n165WWPNotificationMetadata = new bool[] {false} ;
         T000O3_A128WWPNotificationDefinitionId = new long[1] ;
         T000O3_A112WWPUserExtendedId = new string[] {""} ;
         T000O3_n112WWPUserExtendedId = new bool[] {false} ;
         sMode34 = "";
         T000O10_A127WWPNotificationId = new long[1] ;
         T000O10_n127WWPNotificationId = new bool[] {false} ;
         T000O11_A127WWPNotificationId = new long[1] ;
         T000O11_n127WWPNotificationId = new bool[] {false} ;
         T000O2_A127WWPNotificationId = new long[1] ;
         T000O2_n127WWPNotificationId = new bool[] {false} ;
         T000O2_A129WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000O2_A181WWPNotificationIcon = new string[] {""} ;
         T000O2_A182WWPNotificationTitle = new string[] {""} ;
         T000O2_A183WWPNotificationShortDescriptio = new string[] {""} ;
         T000O2_A184WWPNotificationLink = new string[] {""} ;
         T000O2_A187WWPNotificationIsRead = new bool[] {false} ;
         T000O2_A165WWPNotificationMetadata = new string[] {""} ;
         T000O2_n165WWPNotificationMetadata = new bool[] {false} ;
         T000O2_A128WWPNotificationDefinitionId = new long[1] ;
         T000O2_A112WWPUserExtendedId = new string[] {""} ;
         T000O2_n112WWPUserExtendedId = new bool[] {false} ;
         T000O13_A127WWPNotificationId = new long[1] ;
         T000O13_n127WWPNotificationId = new bool[] {false} ;
         T000O16_A164WWPNotificationDefinitionName = new string[] {""} ;
         T000O17_A113WWPUserExtendedFullName = new string[] {""} ;
         T000O18_A185WWPMailId = new long[1] ;
         T000O19_A152WWPWebNotificationId = new long[1] ;
         T000O20_A138WWPSMSId = new long[1] ;
         T000O21_A127WWPNotificationId = new long[1] ;
         T000O21_n127WWPNotificationId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i129WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         ZZ129WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         ZZ181WWPNotificationIcon = "";
         ZZ182WWPNotificationTitle = "";
         ZZ183WWPNotificationShortDescriptio = "";
         ZZ184WWPNotificationLink = "";
         ZZ112WWPUserExtendedId = "";
         ZZ165WWPNotificationMetadata = "";
         ZZ164WWPNotificationDefinitionName = "";
         ZZ113WWPUserExtendedFullName = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notification__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notification__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notification__default(),
            new Object[][] {
                new Object[] {
               T000O2_A127WWPNotificationId, T000O2_A129WWPNotificationCreated, T000O2_A181WWPNotificationIcon, T000O2_A182WWPNotificationTitle, T000O2_A183WWPNotificationShortDescriptio, T000O2_A184WWPNotificationLink, T000O2_A187WWPNotificationIsRead, T000O2_A165WWPNotificationMetadata, T000O2_n165WWPNotificationMetadata, T000O2_A128WWPNotificationDefinitionId,
               T000O2_A112WWPUserExtendedId, T000O2_n112WWPUserExtendedId
               }
               , new Object[] {
               T000O3_A127WWPNotificationId, T000O3_A129WWPNotificationCreated, T000O3_A181WWPNotificationIcon, T000O3_A182WWPNotificationTitle, T000O3_A183WWPNotificationShortDescriptio, T000O3_A184WWPNotificationLink, T000O3_A187WWPNotificationIsRead, T000O3_A165WWPNotificationMetadata, T000O3_n165WWPNotificationMetadata, T000O3_A128WWPNotificationDefinitionId,
               T000O3_A112WWPUserExtendedId, T000O3_n112WWPUserExtendedId
               }
               , new Object[] {
               T000O4_A164WWPNotificationDefinitionName
               }
               , new Object[] {
               T000O5_A113WWPUserExtendedFullName
               }
               , new Object[] {
               T000O6_A127WWPNotificationId, T000O6_A164WWPNotificationDefinitionName, T000O6_A129WWPNotificationCreated, T000O6_A181WWPNotificationIcon, T000O6_A182WWPNotificationTitle, T000O6_A183WWPNotificationShortDescriptio, T000O6_A184WWPNotificationLink, T000O6_A187WWPNotificationIsRead, T000O6_A113WWPUserExtendedFullName, T000O6_A165WWPNotificationMetadata,
               T000O6_n165WWPNotificationMetadata, T000O6_A128WWPNotificationDefinitionId, T000O6_A112WWPUserExtendedId, T000O6_n112WWPUserExtendedId
               }
               , new Object[] {
               T000O7_A164WWPNotificationDefinitionName
               }
               , new Object[] {
               T000O8_A113WWPUserExtendedFullName
               }
               , new Object[] {
               T000O9_A127WWPNotificationId
               }
               , new Object[] {
               T000O10_A127WWPNotificationId
               }
               , new Object[] {
               T000O11_A127WWPNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               T000O13_A127WWPNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000O16_A164WWPNotificationDefinitionName
               }
               , new Object[] {
               T000O17_A113WWPUserExtendedFullName
               }
               , new Object[] {
               T000O18_A185WWPMailId
               }
               , new Object[] {
               T000O19_A152WWPWebNotificationId
               }
               , new Object[] {
               T000O20_A138WWPSMSId
               }
               , new Object[] {
               T000O21_A127WWPNotificationId
               }
            }
         );
         Z129WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A129WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i129WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound34 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPNotificationId_Enabled ;
      private int edtWWPNotificationDefinitionId_Enabled ;
      private int edtWWPNotificationDefinitionName_Enabled ;
      private int edtWWPNotificationCreated_Enabled ;
      private int edtWWPNotificationIcon_Enabled ;
      private int edtWWPNotificationTitle_Enabled ;
      private int edtWWPNotificationShortDescriptio_Enabled ;
      private int edtWWPNotificationLink_Enabled ;
      private int edtWWPUserExtendedId_Enabled ;
      private int edtWWPUserExtendedFullName_Enabled ;
      private int edtWWPNotificationMetadata_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z127WWPNotificationId ;
      private long Z128WWPNotificationDefinitionId ;
      private long A128WWPNotificationDefinitionId ;
      private long A127WWPNotificationId ;
      private long ZZ127WWPNotificationId ;
      private long ZZ128WWPNotificationDefinitionId ;
      private string sPrefix ;
      private string Z112WWPUserExtendedId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A112WWPUserExtendedId ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPNotificationId_Internalname ;
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
      private string edtWWPNotificationId_Jsonclick ;
      private string edtWWPNotificationDefinitionId_Internalname ;
      private string edtWWPNotificationDefinitionId_Jsonclick ;
      private string edtWWPNotificationDefinitionName_Internalname ;
      private string edtWWPNotificationDefinitionName_Jsonclick ;
      private string edtWWPNotificationCreated_Internalname ;
      private string edtWWPNotificationCreated_Jsonclick ;
      private string edtWWPNotificationIcon_Internalname ;
      private string edtWWPNotificationIcon_Jsonclick ;
      private string edtWWPNotificationTitle_Internalname ;
      private string edtWWPNotificationShortDescriptio_Internalname ;
      private string edtWWPNotificationLink_Internalname ;
      private string edtWWPNotificationLink_Jsonclick ;
      private string chkWWPNotificationIsRead_Internalname ;
      private string edtWWPUserExtendedId_Internalname ;
      private string edtWWPUserExtendedId_Jsonclick ;
      private string edtWWPUserExtendedFullName_Internalname ;
      private string edtWWPUserExtendedFullName_Jsonclick ;
      private string edtWWPNotificationMetadata_Internalname ;
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
      private string sMode34 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ112WWPUserExtendedId ;
      private DateTime Z129WWPNotificationCreated ;
      private DateTime A129WWPNotificationCreated ;
      private DateTime i129WWPNotificationCreated ;
      private DateTime ZZ129WWPNotificationCreated ;
      private bool Z187WWPNotificationIsRead ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n112WWPUserExtendedId ;
      private bool wbErr ;
      private bool A187WWPNotificationIsRead ;
      private bool n127WWPNotificationId ;
      private bool n165WWPNotificationMetadata ;
      private bool Gx_longc ;
      private bool ZZ187WWPNotificationIsRead ;
      private string A165WWPNotificationMetadata ;
      private string Z165WWPNotificationMetadata ;
      private string ZZ165WWPNotificationMetadata ;
      private string Z181WWPNotificationIcon ;
      private string Z182WWPNotificationTitle ;
      private string Z183WWPNotificationShortDescriptio ;
      private string Z184WWPNotificationLink ;
      private string A164WWPNotificationDefinitionName ;
      private string A181WWPNotificationIcon ;
      private string A182WWPNotificationTitle ;
      private string A183WWPNotificationShortDescriptio ;
      private string A184WWPNotificationLink ;
      private string A113WWPUserExtendedFullName ;
      private string Z164WWPNotificationDefinitionName ;
      private string Z113WWPUserExtendedFullName ;
      private string ZZ181WWPNotificationIcon ;
      private string ZZ182WWPNotificationTitle ;
      private string ZZ183WWPNotificationShortDescriptio ;
      private string ZZ184WWPNotificationLink ;
      private string ZZ164WWPNotificationDefinitionName ;
      private string ZZ113WWPUserExtendedFullName ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkWWPNotificationIsRead ;
      private IDataStoreProvider pr_default ;
      private long[] T000O6_A127WWPNotificationId ;
      private bool[] T000O6_n127WWPNotificationId ;
      private string[] T000O6_A164WWPNotificationDefinitionName ;
      private DateTime[] T000O6_A129WWPNotificationCreated ;
      private string[] T000O6_A181WWPNotificationIcon ;
      private string[] T000O6_A182WWPNotificationTitle ;
      private string[] T000O6_A183WWPNotificationShortDescriptio ;
      private string[] T000O6_A184WWPNotificationLink ;
      private bool[] T000O6_A187WWPNotificationIsRead ;
      private string[] T000O6_A113WWPUserExtendedFullName ;
      private string[] T000O6_A165WWPNotificationMetadata ;
      private bool[] T000O6_n165WWPNotificationMetadata ;
      private long[] T000O6_A128WWPNotificationDefinitionId ;
      private string[] T000O6_A112WWPUserExtendedId ;
      private bool[] T000O6_n112WWPUserExtendedId ;
      private string[] T000O4_A164WWPNotificationDefinitionName ;
      private string[] T000O5_A113WWPUserExtendedFullName ;
      private string[] T000O7_A164WWPNotificationDefinitionName ;
      private string[] T000O8_A113WWPUserExtendedFullName ;
      private long[] T000O9_A127WWPNotificationId ;
      private bool[] T000O9_n127WWPNotificationId ;
      private long[] T000O3_A127WWPNotificationId ;
      private bool[] T000O3_n127WWPNotificationId ;
      private DateTime[] T000O3_A129WWPNotificationCreated ;
      private string[] T000O3_A181WWPNotificationIcon ;
      private string[] T000O3_A182WWPNotificationTitle ;
      private string[] T000O3_A183WWPNotificationShortDescriptio ;
      private string[] T000O3_A184WWPNotificationLink ;
      private bool[] T000O3_A187WWPNotificationIsRead ;
      private string[] T000O3_A165WWPNotificationMetadata ;
      private bool[] T000O3_n165WWPNotificationMetadata ;
      private long[] T000O3_A128WWPNotificationDefinitionId ;
      private string[] T000O3_A112WWPUserExtendedId ;
      private bool[] T000O3_n112WWPUserExtendedId ;
      private long[] T000O10_A127WWPNotificationId ;
      private bool[] T000O10_n127WWPNotificationId ;
      private long[] T000O11_A127WWPNotificationId ;
      private bool[] T000O11_n127WWPNotificationId ;
      private long[] T000O2_A127WWPNotificationId ;
      private bool[] T000O2_n127WWPNotificationId ;
      private DateTime[] T000O2_A129WWPNotificationCreated ;
      private string[] T000O2_A181WWPNotificationIcon ;
      private string[] T000O2_A182WWPNotificationTitle ;
      private string[] T000O2_A183WWPNotificationShortDescriptio ;
      private string[] T000O2_A184WWPNotificationLink ;
      private bool[] T000O2_A187WWPNotificationIsRead ;
      private string[] T000O2_A165WWPNotificationMetadata ;
      private bool[] T000O2_n165WWPNotificationMetadata ;
      private long[] T000O2_A128WWPNotificationDefinitionId ;
      private string[] T000O2_A112WWPUserExtendedId ;
      private bool[] T000O2_n112WWPUserExtendedId ;
      private long[] T000O13_A127WWPNotificationId ;
      private bool[] T000O13_n127WWPNotificationId ;
      private string[] T000O16_A164WWPNotificationDefinitionName ;
      private string[] T000O17_A113WWPUserExtendedFullName ;
      private long[] T000O18_A185WWPMailId ;
      private long[] T000O19_A152WWPWebNotificationId ;
      private long[] T000O20_A138WWPSMSId ;
      private long[] T000O21_A127WWPNotificationId ;
      private bool[] T000O21_n127WWPNotificationId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_notification__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_notification__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_notification__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[10])
      ,new ForEachCursor(def[11])
      ,new UpdateCursor(def[12])
      ,new UpdateCursor(def[13])
      ,new ForEachCursor(def[14])
      ,new ForEachCursor(def[15])
      ,new ForEachCursor(def[16])
      ,new ForEachCursor(def[17])
      ,new ForEachCursor(def[18])
      ,new ForEachCursor(def[19])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT000O2;
       prmT000O2 = new Object[] {
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmT000O3;
       prmT000O3 = new Object[] {
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmT000O4;
       prmT000O4 = new Object[] {
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       Object[] prmT000O5;
       prmT000O5 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmT000O6;
       prmT000O6 = new Object[] {
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmT000O7;
       prmT000O7 = new Object[] {
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       Object[] prmT000O8;
       prmT000O8 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmT000O9;
       prmT000O9 = new Object[] {
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmT000O10;
       prmT000O10 = new Object[] {
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmT000O11;
       prmT000O11 = new Object[] {
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmT000O12;
       prmT000O12 = new Object[] {
       new ParDef("WWPNotificationCreated",GXType.DateTime2,10,12) ,
       new ParDef("WWPNotificationIcon",GXType.VarChar,100,0) ,
       new ParDef("WWPNotificationTitle",GXType.VarChar,200,0) ,
       new ParDef("WWPNotificationShortDescriptio",GXType.VarChar,200,0) ,
       new ParDef("WWPNotificationLink",GXType.VarChar,1000,0) ,
       new ParDef("WWPNotificationIsRead",GXType.Boolean,4,0) ,
       new ParDef("WWPNotificationMetadata",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0) ,
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmT000O13;
       prmT000O13 = new Object[] {
       };
       Object[] prmT000O14;
       prmT000O14 = new Object[] {
       new ParDef("WWPNotificationCreated",GXType.DateTime2,10,12) ,
       new ParDef("WWPNotificationIcon",GXType.VarChar,100,0) ,
       new ParDef("WWPNotificationTitle",GXType.VarChar,200,0) ,
       new ParDef("WWPNotificationShortDescriptio",GXType.VarChar,200,0) ,
       new ParDef("WWPNotificationLink",GXType.VarChar,1000,0) ,
       new ParDef("WWPNotificationIsRead",GXType.Boolean,4,0) ,
       new ParDef("WWPNotificationMetadata",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0) ,
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true} ,
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmT000O15;
       prmT000O15 = new Object[] {
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmT000O16;
       prmT000O16 = new Object[] {
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       Object[] prmT000O17;
       prmT000O17 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmT000O18;
       prmT000O18 = new Object[] {
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmT000O19;
       prmT000O19 = new Object[] {
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmT000O20;
       prmT000O20 = new Object[] {
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmT000O21;
       prmT000O21 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T000O2", "SELECT WWPNotificationId, WWPNotificationCreated, WWPNotificationIcon, WWPNotificationTitle, WWPNotificationShortDescriptio, WWPNotificationLink, WWPNotificationIsRead, WWPNotificationMetadata, WWPNotificationDefinitionId, WWPUserExtendedId FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId  FOR UPDATE OF WWP_Notification NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000O2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000O3", "SELECT WWPNotificationId, WWPNotificationCreated, WWPNotificationIcon, WWPNotificationTitle, WWPNotificationShortDescriptio, WWPNotificationLink, WWPNotificationIsRead, WWPNotificationMetadata, WWPNotificationDefinitionId, WWPUserExtendedId FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000O4", "SELECT WWPNotificationDefinitionName FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000O5", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000O6", "SELECT TM1.WWPNotificationId, T2.WWPNotificationDefinitionName, TM1.WWPNotificationCreated, TM1.WWPNotificationIcon, TM1.WWPNotificationTitle, TM1.WWPNotificationShortDescriptio, TM1.WWPNotificationLink, TM1.WWPNotificationIsRead, T3.WWPUserExtendedFullName, TM1.WWPNotificationMetadata, TM1.WWPNotificationDefinitionId, TM1.WWPUserExtendedId FROM ((WWP_Notification TM1 INNER JOIN WWP_NotificationDefinition T2 ON T2.WWPNotificationDefinitionId = TM1.WWPNotificationDefinitionId) LEFT JOIN WWP_UserExtended T3 ON T3.WWPUserExtendedId = TM1.WWPUserExtendedId) WHERE TM1.WWPNotificationId = :WWPNotificationId ORDER BY TM1.WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O6,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000O7", "SELECT WWPNotificationDefinitionName FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000O8", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O8,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000O9", "SELECT WWPNotificationId FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O9,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000O10", "SELECT WWPNotificationId FROM WWP_Notification WHERE ( WWPNotificationId > :WWPNotificationId) ORDER BY WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O10,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000O11", "SELECT WWPNotificationId FROM WWP_Notification WHERE ( WWPNotificationId < :WWPNotificationId) ORDER BY WWPNotificationId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O11,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000O12", "SAVEPOINT gxupdate;INSERT INTO WWP_Notification(WWPNotificationCreated, WWPNotificationIcon, WWPNotificationTitle, WWPNotificationShortDescriptio, WWPNotificationLink, WWPNotificationIsRead, WWPNotificationMetadata, WWPNotificationDefinitionId, WWPUserExtendedId) VALUES(:WWPNotificationCreated, :WWPNotificationIcon, :WWPNotificationTitle, :WWPNotificationShortDescriptio, :WWPNotificationLink, :WWPNotificationIsRead, :WWPNotificationMetadata, :WWPNotificationDefinitionId, :WWPUserExtendedId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000O12)
          ,new CursorDef("T000O13", "SELECT currval('WWPNotificationId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O13,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000O14", "SAVEPOINT gxupdate;UPDATE WWP_Notification SET WWPNotificationCreated=:WWPNotificationCreated, WWPNotificationIcon=:WWPNotificationIcon, WWPNotificationTitle=:WWPNotificationTitle, WWPNotificationShortDescriptio=:WWPNotificationShortDescriptio, WWPNotificationLink=:WWPNotificationLink, WWPNotificationIsRead=:WWPNotificationIsRead, WWPNotificationMetadata=:WWPNotificationMetadata, WWPNotificationDefinitionId=:WWPNotificationDefinitionId, WWPUserExtendedId=:WWPUserExtendedId  WHERE WWPNotificationId = :WWPNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000O14)
          ,new CursorDef("T000O15", "SAVEPOINT gxupdate;DELETE FROM WWP_Notification  WHERE WWPNotificationId = :WWPNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000O15)
          ,new CursorDef("T000O16", "SELECT WWPNotificationDefinitionName FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O16,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000O17", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O17,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000O18", "SELECT WWPMailId FROM WWP_Mail WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O18,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000O19", "SELECT WWPWebNotificationId FROM WWP_WebNotification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O19,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000O20", "SELECT WWPSMSId FROM WWP_SMS WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O20,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000O21", "SELECT WWPNotificationId FROM WWP_Notification ORDER BY WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O21,100, GxCacheFrequency.OFF ,true,false )
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
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((bool[]) buf[6])[0] = rslt.getBool(7);
             ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
             ((bool[]) buf[8])[0] = rslt.wasNull(8);
             ((long[]) buf[9])[0] = rslt.getLong(9);
             ((string[]) buf[10])[0] = rslt.getString(10, 40);
             ((bool[]) buf[11])[0] = rslt.wasNull(10);
             return;
          case 1 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((bool[]) buf[6])[0] = rslt.getBool(7);
             ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
             ((bool[]) buf[8])[0] = rslt.wasNull(8);
             ((long[]) buf[9])[0] = rslt.getLong(9);
             ((string[]) buf[10])[0] = rslt.getString(10, 40);
             ((bool[]) buf[11])[0] = rslt.wasNull(10);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 4 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3, true);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((bool[]) buf[7])[0] = rslt.getBool(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getLongVarchar(10);
             ((bool[]) buf[10])[0] = rslt.wasNull(10);
             ((long[]) buf[11])[0] = rslt.getLong(11);
             ((string[]) buf[12])[0] = rslt.getString(12, 40);
             ((bool[]) buf[13])[0] = rslt.wasNull(12);
             return;
          case 5 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 6 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 7 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 8 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 9 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 11 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 14 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 15 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 16 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 17 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 18 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 19 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
    }
 }

}

}
