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
namespace GeneXus.Programs.wwpbaseobjects.notifications.web {
   public class wwp_webnotification : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A127WWPNotificationId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPNotificationId"), "."), 18, MidpointRounding.ToEven));
            n127WWPNotificationId = false;
            AssignAttri("", false, "A127WWPNotificationId", StringUtil.LTrimStr( (decimal)(A127WWPNotificationId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A127WWPNotificationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A128WWPNotificationDefinitionId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPNotificationDefinitionId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A128WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A128WWPNotificationDefinitionId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A128WWPNotificationDefinitionId) ;
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
         Form.Meta.addItem("description", context.GetMessage( "WWP_Web Notification", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPWebNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_webnotification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_webnotification( IGxContext context )
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
         cmbWWPWebNotificationStatus = new GXCombobox();
         chkWWPWebNotificationReceived = new GXCheckbox();
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
            return "webnotification_Execute" ;
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
         if ( cmbWWPWebNotificationStatus.ItemCount > 0 )
         {
            A159WWPWebNotificationStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPWebNotificationStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A159WWPWebNotificationStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A159WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A159WWPWebNotificationStatus), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPWebNotificationStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A159WWPWebNotificationStatus), 4, 0));
            AssignProp("", false, cmbWWPWebNotificationStatus_Internalname, "Values", cmbWWPWebNotificationStatus.ToJavascriptSource(), true);
         }
         A162WWPWebNotificationReceived = StringUtil.StrToBool( StringUtil.BoolToStr( A162WWPWebNotificationReceived));
         n162WWPWebNotificationReceived = false;
         AssignAttri("", false, "A162WWPWebNotificationReceived", A162WWPWebNotificationReceived);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "WWP_Web Notification", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationId_Internalname, context.GetMessage( "Notification Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A152WWPWebNotificationId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPWebNotificationId_Enabled!=0) ? context.localUtil.Format( (decimal)(A152WWPWebNotificationId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A152WWPWebNotificationId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationTitle_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationTitle_Internalname, context.GetMessage( "Notification Title", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationTitle_Internalname, A147WWPWebNotificationTitle, StringUtil.RTrim( context.localUtil.Format( A147WWPWebNotificationTitle, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationTitle_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationTitle_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationId_Internalname, context.GetMessage( "Notification Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A127WWPNotificationId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPNotificationId_Enabled!=0) ? context.localUtil.Format( (decimal)(A127WWPNotificationId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A127WWPNotificationId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
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
         GxWebStd.gx_label_element( context, edtWWPNotificationCreated_Internalname, context.GetMessage( "Notification Created Date", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPNotificationCreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationCreated_Internalname, context.localUtil.TToC( A129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A129WWPNotificationCreated, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationCreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationCreated_Enabled, 0, "text", "", 27, "chr", 1, "row", 27, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_bitmap( context, edtWWPNotificationCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPNotificationCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationMetadata_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationMetadata_Internalname, context.GetMessage( "WWPNotification Metadata", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationMetadata_Internalname, A165WWPNotificationMetadata, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", 0, 1, edtWWPNotificationMetadata_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionName_Internalname, A164WWPNotificationDefinitionName, StringUtil.RTrim( context.localUtil.Format( A164WWPNotificationDefinitionName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationDefinitionName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationText_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationText_Internalname, context.GetMessage( "Notification Text", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationText_Internalname, A148WWPWebNotificationText, StringUtil.RTrim( context.localUtil.Format( A148WWPWebNotificationText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationText_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationText_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationIcon_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationIcon_Internalname, context.GetMessage( "Notification Icon", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPWebNotificationIcon_Internalname, A149WWPWebNotificationIcon, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", 0, 1, edtWWPWebNotificationIcon_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationClientId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationClientId_Internalname, context.GetMessage( "Client Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPWebNotificationClientId_Internalname, A158WWPWebNotificationClientId, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", 0, 1, edtWWPWebNotificationClientId_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbWWPWebNotificationStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbWWPWebNotificationStatus_Internalname, context.GetMessage( "Notification Status", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbWWPWebNotificationStatus, cmbWWPWebNotificationStatus_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A159WWPWebNotificationStatus), 4, 0)), 1, cmbWWPWebNotificationStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbWWPWebNotificationStatus.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "", true, 0, "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         cmbWWPWebNotificationStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A159WWPWebNotificationStatus), 4, 0));
         AssignProp("", false, cmbWWPWebNotificationStatus_Internalname, "Values", (string)(cmbWWPWebNotificationStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationCreated_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationCreated_Internalname, context.GetMessage( "Notification Created", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPWebNotificationCreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationCreated_Internalname, context.localUtil.TToC( A150WWPWebNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A150WWPWebNotificationCreated, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationCreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationCreated_Enabled, 0, "text", "", 27, "chr", 1, "row", 27, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_bitmap( context, edtWWPWebNotificationCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPWebNotificationCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationScheduled_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationScheduled_Internalname, context.GetMessage( "Notification Scheduled", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPWebNotificationScheduled_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationScheduled_Internalname, context.localUtil.TToC( A163WWPWebNotificationScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A163WWPWebNotificationScheduled, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationScheduled_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationScheduled_Enabled, 0, "text", "", 27, "chr", 1, "row", 27, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_bitmap( context, edtWWPWebNotificationScheduled_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPWebNotificationScheduled_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationProcessed_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationProcessed_Internalname, context.GetMessage( "Notification Processed", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPWebNotificationProcessed_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationProcessed_Internalname, context.localUtil.TToC( A160WWPWebNotificationProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A160WWPWebNotificationProcessed, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationProcessed_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationProcessed_Enabled, 0, "text", "", 27, "chr", 1, "row", 27, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_bitmap( context, edtWWPWebNotificationProcessed_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPWebNotificationProcessed_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationRead_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationRead_Internalname, context.GetMessage( "Notification Read", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPWebNotificationRead_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationRead_Internalname, context.localUtil.TToC( A151WWPWebNotificationRead, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A151WWPWebNotificationRead, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationRead_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationRead_Enabled, 0, "text", "", 27, "chr", 1, "row", 27, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_bitmap( context, edtWWPWebNotificationRead_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPWebNotificationRead_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationDetail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationDetail_Internalname, context.GetMessage( "Notification Detail", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPWebNotificationDetail_Internalname, A161WWPWebNotificationDetail, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", 0, 1, edtWWPWebNotificationDetail_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPWebNotificationReceived_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPWebNotificationReceived_Internalname, context.GetMessage( "Notification Received", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPWebNotificationReceived_Internalname, StringUtil.BoolToStr( A162WWPWebNotificationReceived), "", context.GetMessage( "Notification Received", ""), 1, chkWWPWebNotificationReceived.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(109, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,109);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
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
            Z152WWPWebNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z152WWPWebNotificationId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z147WWPWebNotificationTitle = cgiGet( "Z147WWPWebNotificationTitle");
            Z148WWPWebNotificationText = cgiGet( "Z148WWPWebNotificationText");
            Z149WWPWebNotificationIcon = cgiGet( "Z149WWPWebNotificationIcon");
            Z159WWPWebNotificationStatus = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z159WWPWebNotificationStatus"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z150WWPWebNotificationCreated = context.localUtil.CToT( cgiGet( "Z150WWPWebNotificationCreated"), 0);
            Z163WWPWebNotificationScheduled = context.localUtil.CToT( cgiGet( "Z163WWPWebNotificationScheduled"), 0);
            Z160WWPWebNotificationProcessed = context.localUtil.CToT( cgiGet( "Z160WWPWebNotificationProcessed"), 0);
            Z151WWPWebNotificationRead = context.localUtil.CToT( cgiGet( "Z151WWPWebNotificationRead"), 0);
            n151WWPWebNotificationRead = ((DateTime.MinValue==A151WWPWebNotificationRead) ? true : false);
            Z162WWPWebNotificationReceived = StringUtil.StrToBool( cgiGet( "Z162WWPWebNotificationReceived"));
            n162WWPWebNotificationReceived = ((false==A162WWPWebNotificationReceived) ? true : false);
            Z127WWPNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z127WWPNotificationId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n127WWPNotificationId = ((0==A127WWPNotificationId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            A128WWPNotificationDefinitionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "WWPNOTIFICATIONDEFINITIONID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPWebNotificationId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPWebNotificationId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPWEBNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPWebNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A152WWPWebNotificationId = 0;
               AssignAttri("", false, "A152WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A152WWPWebNotificationId), 10, 0));
            }
            else
            {
               A152WWPWebNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPWebNotificationId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A152WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A152WWPWebNotificationId), 10, 0));
            }
            A147WWPWebNotificationTitle = cgiGet( edtWWPWebNotificationTitle_Internalname);
            AssignAttri("", false, "A147WWPWebNotificationTitle", A147WWPWebNotificationTitle);
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
            n127WWPNotificationId = ((0==A127WWPNotificationId) ? true : false);
            A129WWPNotificationCreated = context.localUtil.CToT( cgiGet( edtWWPNotificationCreated_Internalname));
            AssignAttri("", false, "A129WWPNotificationCreated", context.localUtil.TToC( A129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A165WWPNotificationMetadata = cgiGet( edtWWPNotificationMetadata_Internalname);
            n165WWPNotificationMetadata = false;
            AssignAttri("", false, "A165WWPNotificationMetadata", A165WWPNotificationMetadata);
            A164WWPNotificationDefinitionName = cgiGet( edtWWPNotificationDefinitionName_Internalname);
            AssignAttri("", false, "A164WWPNotificationDefinitionName", A164WWPNotificationDefinitionName);
            A148WWPWebNotificationText = cgiGet( edtWWPWebNotificationText_Internalname);
            AssignAttri("", false, "A148WWPWebNotificationText", A148WWPWebNotificationText);
            A149WWPWebNotificationIcon = cgiGet( edtWWPWebNotificationIcon_Internalname);
            AssignAttri("", false, "A149WWPWebNotificationIcon", A149WWPWebNotificationIcon);
            A158WWPWebNotificationClientId = cgiGet( edtWWPWebNotificationClientId_Internalname);
            AssignAttri("", false, "A158WWPWebNotificationClientId", A158WWPWebNotificationClientId);
            cmbWWPWebNotificationStatus.CurrentValue = cgiGet( cmbWWPWebNotificationStatus_Internalname);
            A159WWPWebNotificationStatus = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPWebNotificationStatus_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A159WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A159WWPWebNotificationStatus), 4, 0));
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPWebNotificationCreated_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Web Notification Created", "")}), 1, "WWPWEBNOTIFICATIONCREATED");
               AnyError = 1;
               GX_FocusControl = edtWWPWebNotificationCreated_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A150WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A150WWPWebNotificationCreated", context.localUtil.TToC( A150WWPWebNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A150WWPWebNotificationCreated = context.localUtil.CToT( cgiGet( edtWWPWebNotificationCreated_Internalname));
               AssignAttri("", false, "A150WWPWebNotificationCreated", context.localUtil.TToC( A150WWPWebNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPWebNotificationScheduled_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Web Notification Scheduled", "")}), 1, "WWPWEBNOTIFICATIONSCHEDULED");
               AnyError = 1;
               GX_FocusControl = edtWWPWebNotificationScheduled_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A163WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A163WWPWebNotificationScheduled", context.localUtil.TToC( A163WWPWebNotificationScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A163WWPWebNotificationScheduled = context.localUtil.CToT( cgiGet( edtWWPWebNotificationScheduled_Internalname));
               AssignAttri("", false, "A163WWPWebNotificationScheduled", context.localUtil.TToC( A163WWPWebNotificationScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPWebNotificationProcessed_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Web Notification Processed", "")}), 1, "WWPWEBNOTIFICATIONPROCESSED");
               AnyError = 1;
               GX_FocusControl = edtWWPWebNotificationProcessed_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A160WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A160WWPWebNotificationProcessed", context.localUtil.TToC( A160WWPWebNotificationProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A160WWPWebNotificationProcessed = context.localUtil.CToT( cgiGet( edtWWPWebNotificationProcessed_Internalname));
               AssignAttri("", false, "A160WWPWebNotificationProcessed", context.localUtil.TToC( A160WWPWebNotificationProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPWebNotificationRead_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Web Notification Read", "")}), 1, "WWPWEBNOTIFICATIONREAD");
               AnyError = 1;
               GX_FocusControl = edtWWPWebNotificationRead_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A151WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
               n151WWPWebNotificationRead = false;
               AssignAttri("", false, "A151WWPWebNotificationRead", context.localUtil.TToC( A151WWPWebNotificationRead, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A151WWPWebNotificationRead = context.localUtil.CToT( cgiGet( edtWWPWebNotificationRead_Internalname));
               n151WWPWebNotificationRead = false;
               AssignAttri("", false, "A151WWPWebNotificationRead", context.localUtil.TToC( A151WWPWebNotificationRead, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            n151WWPWebNotificationRead = ((DateTime.MinValue==A151WWPWebNotificationRead) ? true : false);
            A161WWPWebNotificationDetail = cgiGet( edtWWPWebNotificationDetail_Internalname);
            n161WWPWebNotificationDetail = false;
            AssignAttri("", false, "A161WWPWebNotificationDetail", A161WWPWebNotificationDetail);
            n161WWPWebNotificationDetail = (String.IsNullOrEmpty(StringUtil.RTrim( A161WWPWebNotificationDetail)) ? true : false);
            A162WWPWebNotificationReceived = StringUtil.StrToBool( cgiGet( chkWWPWebNotificationReceived_Internalname));
            n162WWPWebNotificationReceived = false;
            AssignAttri("", false, "A162WWPWebNotificationReceived", A162WWPWebNotificationReceived);
            n162WWPWebNotificationReceived = ((false==A162WWPWebNotificationReceived) ? true : false);
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
               A152WWPWebNotificationId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPWebNotificationId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A152WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A152WWPWebNotificationId), 10, 0));
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
               InitAll0L31( ) ;
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
         DisableAttributes0L31( ) ;
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

      protected void ResetCaption0L0( )
      {
      }

      protected void ZM0L31( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z147WWPWebNotificationTitle = T000L3_A147WWPWebNotificationTitle[0];
               Z148WWPWebNotificationText = T000L3_A148WWPWebNotificationText[0];
               Z149WWPWebNotificationIcon = T000L3_A149WWPWebNotificationIcon[0];
               Z159WWPWebNotificationStatus = T000L3_A159WWPWebNotificationStatus[0];
               Z150WWPWebNotificationCreated = T000L3_A150WWPWebNotificationCreated[0];
               Z163WWPWebNotificationScheduled = T000L3_A163WWPWebNotificationScheduled[0];
               Z160WWPWebNotificationProcessed = T000L3_A160WWPWebNotificationProcessed[0];
               Z151WWPWebNotificationRead = T000L3_A151WWPWebNotificationRead[0];
               Z162WWPWebNotificationReceived = T000L3_A162WWPWebNotificationReceived[0];
               Z127WWPNotificationId = T000L3_A127WWPNotificationId[0];
            }
            else
            {
               Z147WWPWebNotificationTitle = A147WWPWebNotificationTitle;
               Z148WWPWebNotificationText = A148WWPWebNotificationText;
               Z149WWPWebNotificationIcon = A149WWPWebNotificationIcon;
               Z159WWPWebNotificationStatus = A159WWPWebNotificationStatus;
               Z150WWPWebNotificationCreated = A150WWPWebNotificationCreated;
               Z163WWPWebNotificationScheduled = A163WWPWebNotificationScheduled;
               Z160WWPWebNotificationProcessed = A160WWPWebNotificationProcessed;
               Z151WWPWebNotificationRead = A151WWPWebNotificationRead;
               Z162WWPWebNotificationReceived = A162WWPWebNotificationReceived;
               Z127WWPNotificationId = A127WWPNotificationId;
            }
         }
         if ( GX_JID == -5 )
         {
            Z152WWPWebNotificationId = A152WWPWebNotificationId;
            Z147WWPWebNotificationTitle = A147WWPWebNotificationTitle;
            Z148WWPWebNotificationText = A148WWPWebNotificationText;
            Z149WWPWebNotificationIcon = A149WWPWebNotificationIcon;
            Z158WWPWebNotificationClientId = A158WWPWebNotificationClientId;
            Z159WWPWebNotificationStatus = A159WWPWebNotificationStatus;
            Z150WWPWebNotificationCreated = A150WWPWebNotificationCreated;
            Z163WWPWebNotificationScheduled = A163WWPWebNotificationScheduled;
            Z160WWPWebNotificationProcessed = A160WWPWebNotificationProcessed;
            Z151WWPWebNotificationRead = A151WWPWebNotificationRead;
            Z161WWPWebNotificationDetail = A161WWPWebNotificationDetail;
            Z162WWPWebNotificationReceived = A162WWPWebNotificationReceived;
            Z127WWPNotificationId = A127WWPNotificationId;
            Z128WWPNotificationDefinitionId = A128WWPNotificationDefinitionId;
            Z129WWPNotificationCreated = A129WWPNotificationCreated;
            Z165WWPNotificationMetadata = A165WWPNotificationMetadata;
            Z164WWPNotificationDefinitionName = A164WWPNotificationDefinitionName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (0==A159WWPWebNotificationStatus) && ( Gx_BScreen == 0 ) )
         {
            A159WWPWebNotificationStatus = 1;
            AssignAttri("", false, "A159WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A159WWPWebNotificationStatus), 4, 0));
         }
         if ( IsIns( )  && (DateTime.MinValue==A150WWPWebNotificationCreated) && ( Gx_BScreen == 0 ) )
         {
            A150WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A150WWPWebNotificationCreated", context.localUtil.TToC( A150WWPWebNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         }
         if ( IsIns( )  && (DateTime.MinValue==A163WWPWebNotificationScheduled) && ( Gx_BScreen == 0 ) )
         {
            A163WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A163WWPWebNotificationScheduled", context.localUtil.TToC( A163WWPWebNotificationScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
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

      protected void Load0L31( )
      {
         /* Using cursor T000L6 */
         pr_default.execute(4, new Object[] {A152WWPWebNotificationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound31 = 1;
            A128WWPNotificationDefinitionId = T000L6_A128WWPNotificationDefinitionId[0];
            A147WWPWebNotificationTitle = T000L6_A147WWPWebNotificationTitle[0];
            AssignAttri("", false, "A147WWPWebNotificationTitle", A147WWPWebNotificationTitle);
            A129WWPNotificationCreated = T000L6_A129WWPNotificationCreated[0];
            AssignAttri("", false, "A129WWPNotificationCreated", context.localUtil.TToC( A129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A165WWPNotificationMetadata = T000L6_A165WWPNotificationMetadata[0];
            n165WWPNotificationMetadata = T000L6_n165WWPNotificationMetadata[0];
            AssignAttri("", false, "A165WWPNotificationMetadata", A165WWPNotificationMetadata);
            A164WWPNotificationDefinitionName = T000L6_A164WWPNotificationDefinitionName[0];
            AssignAttri("", false, "A164WWPNotificationDefinitionName", A164WWPNotificationDefinitionName);
            A148WWPWebNotificationText = T000L6_A148WWPWebNotificationText[0];
            AssignAttri("", false, "A148WWPWebNotificationText", A148WWPWebNotificationText);
            A149WWPWebNotificationIcon = T000L6_A149WWPWebNotificationIcon[0];
            AssignAttri("", false, "A149WWPWebNotificationIcon", A149WWPWebNotificationIcon);
            A158WWPWebNotificationClientId = T000L6_A158WWPWebNotificationClientId[0];
            AssignAttri("", false, "A158WWPWebNotificationClientId", A158WWPWebNotificationClientId);
            A159WWPWebNotificationStatus = T000L6_A159WWPWebNotificationStatus[0];
            AssignAttri("", false, "A159WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A159WWPWebNotificationStatus), 4, 0));
            A150WWPWebNotificationCreated = T000L6_A150WWPWebNotificationCreated[0];
            AssignAttri("", false, "A150WWPWebNotificationCreated", context.localUtil.TToC( A150WWPWebNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A163WWPWebNotificationScheduled = T000L6_A163WWPWebNotificationScheduled[0];
            AssignAttri("", false, "A163WWPWebNotificationScheduled", context.localUtil.TToC( A163WWPWebNotificationScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A160WWPWebNotificationProcessed = T000L6_A160WWPWebNotificationProcessed[0];
            AssignAttri("", false, "A160WWPWebNotificationProcessed", context.localUtil.TToC( A160WWPWebNotificationProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A151WWPWebNotificationRead = T000L6_A151WWPWebNotificationRead[0];
            n151WWPWebNotificationRead = T000L6_n151WWPWebNotificationRead[0];
            AssignAttri("", false, "A151WWPWebNotificationRead", context.localUtil.TToC( A151WWPWebNotificationRead, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A161WWPWebNotificationDetail = T000L6_A161WWPWebNotificationDetail[0];
            n161WWPWebNotificationDetail = T000L6_n161WWPWebNotificationDetail[0];
            AssignAttri("", false, "A161WWPWebNotificationDetail", A161WWPWebNotificationDetail);
            A162WWPWebNotificationReceived = T000L6_A162WWPWebNotificationReceived[0];
            n162WWPWebNotificationReceived = T000L6_n162WWPWebNotificationReceived[0];
            AssignAttri("", false, "A162WWPWebNotificationReceived", A162WWPWebNotificationReceived);
            A127WWPNotificationId = T000L6_A127WWPNotificationId[0];
            n127WWPNotificationId = T000L6_n127WWPNotificationId[0];
            AssignAttri("", false, "A127WWPNotificationId", StringUtil.LTrimStr( (decimal)(A127WWPNotificationId), 10, 0));
            ZM0L31( -5) ;
         }
         pr_default.close(4);
         OnLoadActions0L31( ) ;
      }

      protected void OnLoadActions0L31( )
      {
      }

      protected void CheckExtendedTable0L31( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000L4 */
         pr_default.execute(2, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A127WWPNotificationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Notification", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A128WWPNotificationDefinitionId = T000L4_A128WWPNotificationDefinitionId[0];
         A129WWPNotificationCreated = T000L4_A129WWPNotificationCreated[0];
         AssignAttri("", false, "A129WWPNotificationCreated", context.localUtil.TToC( A129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A165WWPNotificationMetadata = T000L4_A165WWPNotificationMetadata[0];
         n165WWPNotificationMetadata = T000L4_n165WWPNotificationMetadata[0];
         AssignAttri("", false, "A165WWPNotificationMetadata", A165WWPNotificationMetadata);
         pr_default.close(2);
         /* Using cursor T000L5 */
         pr_default.execute(3, new Object[] {A128WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A128WWPNotificationDefinitionId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_NotificationDefinition", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
               AnyError = 1;
            }
         }
         A164WWPNotificationDefinitionName = T000L5_A164WWPNotificationDefinitionName[0];
         AssignAttri("", false, "A164WWPNotificationDefinitionName", A164WWPNotificationDefinitionName);
         pr_default.close(3);
         if ( ! ( ( A159WWPWebNotificationStatus == 1 ) || ( A159WWPWebNotificationStatus == 2 ) || ( A159WWPWebNotificationStatus == 3 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Web Notification Status", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "WWPWEBNOTIFICATIONSTATUS");
            AnyError = 1;
            GX_FocusControl = cmbWWPWebNotificationStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0L31( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_6( long A127WWPNotificationId )
      {
         /* Using cursor T000L7 */
         pr_default.execute(5, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A127WWPNotificationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Notification", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A128WWPNotificationDefinitionId = T000L7_A128WWPNotificationDefinitionId[0];
         A129WWPNotificationCreated = T000L7_A129WWPNotificationCreated[0];
         AssignAttri("", false, "A129WWPNotificationCreated", context.localUtil.TToC( A129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A165WWPNotificationMetadata = T000L7_A165WWPNotificationMetadata[0];
         n165WWPNotificationMetadata = T000L7_n165WWPNotificationMetadata[0];
         AssignAttri("", false, "A165WWPNotificationMetadata", A165WWPNotificationMetadata);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A128WWPNotificationDefinitionId), 10, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( context.localUtil.TToC( A129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "))+"\""+","+"\""+GXUtil.EncodeJSConstant( A165WWPNotificationMetadata)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_7( long A128WWPNotificationDefinitionId )
      {
         /* Using cursor T000L8 */
         pr_default.execute(6, new Object[] {A128WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A128WWPNotificationDefinitionId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_NotificationDefinition", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
               AnyError = 1;
            }
         }
         A164WWPNotificationDefinitionName = T000L8_A164WWPNotificationDefinitionName[0];
         AssignAttri("", false, "A164WWPNotificationDefinitionName", A164WWPNotificationDefinitionName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A164WWPNotificationDefinitionName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey0L31( )
      {
         /* Using cursor T000L9 */
         pr_default.execute(7, new Object[] {A152WWPWebNotificationId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound31 = 1;
         }
         else
         {
            RcdFound31 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000L3 */
         pr_default.execute(1, new Object[] {A152WWPWebNotificationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0L31( 5) ;
            RcdFound31 = 1;
            A152WWPWebNotificationId = T000L3_A152WWPWebNotificationId[0];
            AssignAttri("", false, "A152WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A152WWPWebNotificationId), 10, 0));
            A147WWPWebNotificationTitle = T000L3_A147WWPWebNotificationTitle[0];
            AssignAttri("", false, "A147WWPWebNotificationTitle", A147WWPWebNotificationTitle);
            A148WWPWebNotificationText = T000L3_A148WWPWebNotificationText[0];
            AssignAttri("", false, "A148WWPWebNotificationText", A148WWPWebNotificationText);
            A149WWPWebNotificationIcon = T000L3_A149WWPWebNotificationIcon[0];
            AssignAttri("", false, "A149WWPWebNotificationIcon", A149WWPWebNotificationIcon);
            A158WWPWebNotificationClientId = T000L3_A158WWPWebNotificationClientId[0];
            AssignAttri("", false, "A158WWPWebNotificationClientId", A158WWPWebNotificationClientId);
            A159WWPWebNotificationStatus = T000L3_A159WWPWebNotificationStatus[0];
            AssignAttri("", false, "A159WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A159WWPWebNotificationStatus), 4, 0));
            A150WWPWebNotificationCreated = T000L3_A150WWPWebNotificationCreated[0];
            AssignAttri("", false, "A150WWPWebNotificationCreated", context.localUtil.TToC( A150WWPWebNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A163WWPWebNotificationScheduled = T000L3_A163WWPWebNotificationScheduled[0];
            AssignAttri("", false, "A163WWPWebNotificationScheduled", context.localUtil.TToC( A163WWPWebNotificationScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A160WWPWebNotificationProcessed = T000L3_A160WWPWebNotificationProcessed[0];
            AssignAttri("", false, "A160WWPWebNotificationProcessed", context.localUtil.TToC( A160WWPWebNotificationProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A151WWPWebNotificationRead = T000L3_A151WWPWebNotificationRead[0];
            n151WWPWebNotificationRead = T000L3_n151WWPWebNotificationRead[0];
            AssignAttri("", false, "A151WWPWebNotificationRead", context.localUtil.TToC( A151WWPWebNotificationRead, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A161WWPWebNotificationDetail = T000L3_A161WWPWebNotificationDetail[0];
            n161WWPWebNotificationDetail = T000L3_n161WWPWebNotificationDetail[0];
            AssignAttri("", false, "A161WWPWebNotificationDetail", A161WWPWebNotificationDetail);
            A162WWPWebNotificationReceived = T000L3_A162WWPWebNotificationReceived[0];
            n162WWPWebNotificationReceived = T000L3_n162WWPWebNotificationReceived[0];
            AssignAttri("", false, "A162WWPWebNotificationReceived", A162WWPWebNotificationReceived);
            A127WWPNotificationId = T000L3_A127WWPNotificationId[0];
            n127WWPNotificationId = T000L3_n127WWPNotificationId[0];
            AssignAttri("", false, "A127WWPNotificationId", StringUtil.LTrimStr( (decimal)(A127WWPNotificationId), 10, 0));
            Z152WWPWebNotificationId = A152WWPWebNotificationId;
            sMode31 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0L31( ) ;
            if ( AnyError == 1 )
            {
               RcdFound31 = 0;
               InitializeNonKey0L31( ) ;
            }
            Gx_mode = sMode31;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound31 = 0;
            InitializeNonKey0L31( ) ;
            sMode31 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode31;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0L31( ) ;
         if ( RcdFound31 == 0 )
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
         RcdFound31 = 0;
         /* Using cursor T000L10 */
         pr_default.execute(8, new Object[] {A152WWPWebNotificationId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000L10_A152WWPWebNotificationId[0] < A152WWPWebNotificationId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000L10_A152WWPWebNotificationId[0] > A152WWPWebNotificationId ) ) )
            {
               A152WWPWebNotificationId = T000L10_A152WWPWebNotificationId[0];
               AssignAttri("", false, "A152WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A152WWPWebNotificationId), 10, 0));
               RcdFound31 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound31 = 0;
         /* Using cursor T000L11 */
         pr_default.execute(9, new Object[] {A152WWPWebNotificationId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000L11_A152WWPWebNotificationId[0] > A152WWPWebNotificationId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000L11_A152WWPWebNotificationId[0] < A152WWPWebNotificationId ) ) )
            {
               A152WWPWebNotificationId = T000L11_A152WWPWebNotificationId[0];
               AssignAttri("", false, "A152WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A152WWPWebNotificationId), 10, 0));
               RcdFound31 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0L31( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPWebNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0L31( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound31 == 1 )
            {
               if ( A152WWPWebNotificationId != Z152WWPWebNotificationId )
               {
                  A152WWPWebNotificationId = Z152WWPWebNotificationId;
                  AssignAttri("", false, "A152WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A152WWPWebNotificationId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPWEBNOTIFICATIONID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPWebNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPWebNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0L31( ) ;
                  GX_FocusControl = edtWWPWebNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A152WWPWebNotificationId != Z152WWPWebNotificationId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPWebNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0L31( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPWEBNOTIFICATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPWebNotificationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPWebNotificationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0L31( ) ;
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
         if ( A152WWPWebNotificationId != Z152WWPWebNotificationId )
         {
            A152WWPWebNotificationId = Z152WWPWebNotificationId;
            AssignAttri("", false, "A152WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A152WWPWebNotificationId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPWEBNOTIFICATIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPWebNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPWebNotificationId_Internalname;
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
         if ( RcdFound31 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPWEBNOTIFICATIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPWebNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtWWPWebNotificationTitle_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0L31( ) ;
         if ( RcdFound31 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPWebNotificationTitle_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0L31( ) ;
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
         if ( RcdFound31 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPWebNotificationTitle_Internalname;
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
         if ( RcdFound31 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPWebNotificationTitle_Internalname;
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
         ScanStart0L31( ) ;
         if ( RcdFound31 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound31 != 0 )
            {
               ScanNext0L31( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPWebNotificationTitle_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0L31( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0L31( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000L2 */
            pr_default.execute(0, new Object[] {A152WWPWebNotificationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebNotification"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z147WWPWebNotificationTitle, T000L2_A147WWPWebNotificationTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z148WWPWebNotificationText, T000L2_A148WWPWebNotificationText[0]) != 0 ) || ( StringUtil.StrCmp(Z149WWPWebNotificationIcon, T000L2_A149WWPWebNotificationIcon[0]) != 0 ) || ( Z159WWPWebNotificationStatus != T000L2_A159WWPWebNotificationStatus[0] ) || ( Z150WWPWebNotificationCreated != T000L2_A150WWPWebNotificationCreated[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z163WWPWebNotificationScheduled != T000L2_A163WWPWebNotificationScheduled[0] ) || ( Z160WWPWebNotificationProcessed != T000L2_A160WWPWebNotificationProcessed[0] ) || ( Z151WWPWebNotificationRead != T000L2_A151WWPWebNotificationRead[0] ) || ( Z162WWPWebNotificationReceived != T000L2_A162WWPWebNotificationReceived[0] ) || ( Z127WWPNotificationId != T000L2_A127WWPNotificationId[0] ) )
            {
               if ( StringUtil.StrCmp(Z147WWPWebNotificationTitle, T000L2_A147WWPWebNotificationTitle[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationTitle");
                  GXUtil.WriteLogRaw("Old: ",Z147WWPWebNotificationTitle);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A147WWPWebNotificationTitle[0]);
               }
               if ( StringUtil.StrCmp(Z148WWPWebNotificationText, T000L2_A148WWPWebNotificationText[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationText");
                  GXUtil.WriteLogRaw("Old: ",Z148WWPWebNotificationText);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A148WWPWebNotificationText[0]);
               }
               if ( StringUtil.StrCmp(Z149WWPWebNotificationIcon, T000L2_A149WWPWebNotificationIcon[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationIcon");
                  GXUtil.WriteLogRaw("Old: ",Z149WWPWebNotificationIcon);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A149WWPWebNotificationIcon[0]);
               }
               if ( Z159WWPWebNotificationStatus != T000L2_A159WWPWebNotificationStatus[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationStatus");
                  GXUtil.WriteLogRaw("Old: ",Z159WWPWebNotificationStatus);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A159WWPWebNotificationStatus[0]);
               }
               if ( Z150WWPWebNotificationCreated != T000L2_A150WWPWebNotificationCreated[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationCreated");
                  GXUtil.WriteLogRaw("Old: ",Z150WWPWebNotificationCreated);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A150WWPWebNotificationCreated[0]);
               }
               if ( Z163WWPWebNotificationScheduled != T000L2_A163WWPWebNotificationScheduled[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationScheduled");
                  GXUtil.WriteLogRaw("Old: ",Z163WWPWebNotificationScheduled);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A163WWPWebNotificationScheduled[0]);
               }
               if ( Z160WWPWebNotificationProcessed != T000L2_A160WWPWebNotificationProcessed[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationProcessed");
                  GXUtil.WriteLogRaw("Old: ",Z160WWPWebNotificationProcessed);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A160WWPWebNotificationProcessed[0]);
               }
               if ( Z151WWPWebNotificationRead != T000L2_A151WWPWebNotificationRead[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationRead");
                  GXUtil.WriteLogRaw("Old: ",Z151WWPWebNotificationRead);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A151WWPWebNotificationRead[0]);
               }
               if ( Z162WWPWebNotificationReceived != T000L2_A162WWPWebNotificationReceived[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationReceived");
                  GXUtil.WriteLogRaw("Old: ",Z162WWPWebNotificationReceived);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A162WWPWebNotificationReceived[0]);
               }
               if ( Z127WWPNotificationId != T000L2_A127WWPNotificationId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPNotificationId");
                  GXUtil.WriteLogRaw("Old: ",Z127WWPNotificationId);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A127WWPNotificationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_WebNotification"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0L31( )
      {
         if ( ! IsAuthorized("webnotification_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0L31( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0L31( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0L31( 0) ;
            CheckOptimisticConcurrency0L31( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0L31( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0L31( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000L12 */
                     pr_default.execute(10, new Object[] {A147WWPWebNotificationTitle, A148WWPWebNotificationText, A149WWPWebNotificationIcon, A158WWPWebNotificationClientId, A159WWPWebNotificationStatus, A150WWPWebNotificationCreated, A163WWPWebNotificationScheduled, A160WWPWebNotificationProcessed, n151WWPWebNotificationRead, A151WWPWebNotificationRead, n161WWPWebNotificationDetail, A161WWPWebNotificationDetail, n162WWPWebNotificationReceived, A162WWPWebNotificationReceived, n127WWPNotificationId, A127WWPNotificationId});
                     pr_default.close(10);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000L13 */
                     pr_default.execute(11);
                     A152WWPWebNotificationId = T000L13_A152WWPWebNotificationId[0];
                     AssignAttri("", false, "A152WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A152WWPWebNotificationId), 10, 0));
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_WebNotification");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0L0( ) ;
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
               Load0L31( ) ;
            }
            EndLevel0L31( ) ;
         }
         CloseExtendedTableCursors0L31( ) ;
      }

      protected void Update0L31( )
      {
         if ( ! IsAuthorized("webnotification_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0L31( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0L31( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0L31( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0L31( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0L31( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000L14 */
                     pr_default.execute(12, new Object[] {A147WWPWebNotificationTitle, A148WWPWebNotificationText, A149WWPWebNotificationIcon, A158WWPWebNotificationClientId, A159WWPWebNotificationStatus, A150WWPWebNotificationCreated, A163WWPWebNotificationScheduled, A160WWPWebNotificationProcessed, n151WWPWebNotificationRead, A151WWPWebNotificationRead, n161WWPWebNotificationDetail, A161WWPWebNotificationDetail, n162WWPWebNotificationReceived, A162WWPWebNotificationReceived, n127WWPNotificationId, A127WWPNotificationId, A152WWPWebNotificationId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_WebNotification");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebNotification"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0L31( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0L0( ) ;
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
            EndLevel0L31( ) ;
         }
         CloseExtendedTableCursors0L31( ) ;
      }

      protected void DeferredUpdate0L31( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("webnotification_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0L31( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0L31( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0L31( ) ;
            AfterConfirm0L31( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0L31( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000L15 */
                  pr_default.execute(13, new Object[] {A152WWPWebNotificationId});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_WebNotification");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound31 == 0 )
                        {
                           InitAll0L31( ) ;
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
                        ResetCaption0L0( ) ;
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
         sMode31 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0L31( ) ;
         Gx_mode = sMode31;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0L31( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000L16 */
            pr_default.execute(14, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
            A128WWPNotificationDefinitionId = T000L16_A128WWPNotificationDefinitionId[0];
            A129WWPNotificationCreated = T000L16_A129WWPNotificationCreated[0];
            AssignAttri("", false, "A129WWPNotificationCreated", context.localUtil.TToC( A129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A165WWPNotificationMetadata = T000L16_A165WWPNotificationMetadata[0];
            n165WWPNotificationMetadata = T000L16_n165WWPNotificationMetadata[0];
            AssignAttri("", false, "A165WWPNotificationMetadata", A165WWPNotificationMetadata);
            pr_default.close(14);
            /* Using cursor T000L17 */
            pr_default.execute(15, new Object[] {A128WWPNotificationDefinitionId});
            A164WWPNotificationDefinitionName = T000L17_A164WWPNotificationDefinitionName[0];
            AssignAttri("", false, "A164WWPNotificationDefinitionName", A164WWPNotificationDefinitionName);
            pr_default.close(15);
         }
      }

      protected void EndLevel0L31( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0L31( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("wwpbaseobjects.notifications.web.wwp_webnotification",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0L0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("wwpbaseobjects.notifications.web.wwp_webnotification",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0L31( )
      {
         /* Using cursor T000L18 */
         pr_default.execute(16);
         RcdFound31 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound31 = 1;
            A152WWPWebNotificationId = T000L18_A152WWPWebNotificationId[0];
            AssignAttri("", false, "A152WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A152WWPWebNotificationId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0L31( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound31 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound31 = 1;
            A152WWPWebNotificationId = T000L18_A152WWPWebNotificationId[0];
            AssignAttri("", false, "A152WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A152WWPWebNotificationId), 10, 0));
         }
      }

      protected void ScanEnd0L31( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm0L31( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0L31( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0L31( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0L31( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0L31( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0L31( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0L31( )
      {
         edtWWPWebNotificationId_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationId_Enabled), 5, 0), true);
         edtWWPWebNotificationTitle_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationTitle_Enabled), 5, 0), true);
         edtWWPNotificationId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationId_Enabled), 5, 0), true);
         edtWWPNotificationCreated_Enabled = 0;
         AssignProp("", false, edtWWPNotificationCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationCreated_Enabled), 5, 0), true);
         edtWWPNotificationMetadata_Enabled = 0;
         AssignProp("", false, edtWWPNotificationMetadata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationMetadata_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionName_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionName_Enabled), 5, 0), true);
         edtWWPWebNotificationText_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationText_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationText_Enabled), 5, 0), true);
         edtWWPWebNotificationIcon_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationIcon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationIcon_Enabled), 5, 0), true);
         edtWWPWebNotificationClientId_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationClientId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationClientId_Enabled), 5, 0), true);
         cmbWWPWebNotificationStatus.Enabled = 0;
         AssignProp("", false, cmbWWPWebNotificationStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPWebNotificationStatus.Enabled), 5, 0), true);
         edtWWPWebNotificationCreated_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationCreated_Enabled), 5, 0), true);
         edtWWPWebNotificationScheduled_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationScheduled_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationScheduled_Enabled), 5, 0), true);
         edtWWPWebNotificationProcessed_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationProcessed_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationProcessed_Enabled), 5, 0), true);
         edtWWPWebNotificationRead_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationRead_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationRead_Enabled), 5, 0), true);
         edtWWPWebNotificationDetail_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationDetail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationDetail_Enabled), 5, 0), true);
         chkWWPWebNotificationReceived.Enabled = 0;
         AssignProp("", false, chkWWPWebNotificationReceived_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPWebNotificationReceived.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0L31( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0L0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.notifications.web.wwp_webnotification.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z152WWPWebNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z152WWPWebNotificationId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z147WWPWebNotificationTitle", Z147WWPWebNotificationTitle);
         GxWebStd.gx_hidden_field( context, "Z148WWPWebNotificationText", Z148WWPWebNotificationText);
         GxWebStd.gx_hidden_field( context, "Z149WWPWebNotificationIcon", Z149WWPWebNotificationIcon);
         GxWebStd.gx_hidden_field( context, "Z159WWPWebNotificationStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z159WWPWebNotificationStatus), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z150WWPWebNotificationCreated", context.localUtil.TToC( Z150WWPWebNotificationCreated, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z163WWPWebNotificationScheduled", context.localUtil.TToC( Z163WWPWebNotificationScheduled, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z160WWPWebNotificationProcessed", context.localUtil.TToC( Z160WWPWebNotificationProcessed, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z151WWPWebNotificationRead", context.localUtil.TToC( Z151WWPWebNotificationRead, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_boolean_hidden_field( context, "Z162WWPWebNotificationReceived", Z162WWPWebNotificationReceived);
         GxWebStd.gx_hidden_field( context, "Z127WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z127WWPNotificationId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "WWPNOTIFICATIONDEFINITIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A128WWPNotificationDefinitionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         return formatLink("wwpbaseobjects.notifications.web.wwp_webnotification.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Notifications.Web.WWP_WebNotification" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WWP_Web Notification", "") ;
      }

      protected void InitializeNonKey0L31( )
      {
         A128WWPNotificationDefinitionId = 0;
         AssignAttri("", false, "A128WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A128WWPNotificationDefinitionId), 10, 0));
         A147WWPWebNotificationTitle = "";
         AssignAttri("", false, "A147WWPWebNotificationTitle", A147WWPWebNotificationTitle);
         A127WWPNotificationId = 0;
         n127WWPNotificationId = false;
         AssignAttri("", false, "A127WWPNotificationId", StringUtil.LTrimStr( (decimal)(A127WWPNotificationId), 10, 0));
         n127WWPNotificationId = ((0==A127WWPNotificationId) ? true : false);
         A129WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A129WWPNotificationCreated", context.localUtil.TToC( A129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A165WWPNotificationMetadata = "";
         n165WWPNotificationMetadata = false;
         AssignAttri("", false, "A165WWPNotificationMetadata", A165WWPNotificationMetadata);
         A164WWPNotificationDefinitionName = "";
         AssignAttri("", false, "A164WWPNotificationDefinitionName", A164WWPNotificationDefinitionName);
         A148WWPWebNotificationText = "";
         AssignAttri("", false, "A148WWPWebNotificationText", A148WWPWebNotificationText);
         A149WWPWebNotificationIcon = "";
         AssignAttri("", false, "A149WWPWebNotificationIcon", A149WWPWebNotificationIcon);
         A158WWPWebNotificationClientId = "";
         AssignAttri("", false, "A158WWPWebNotificationClientId", A158WWPWebNotificationClientId);
         A160WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A160WWPWebNotificationProcessed", context.localUtil.TToC( A160WWPWebNotificationProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A151WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         n151WWPWebNotificationRead = false;
         AssignAttri("", false, "A151WWPWebNotificationRead", context.localUtil.TToC( A151WWPWebNotificationRead, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         n151WWPWebNotificationRead = ((DateTime.MinValue==A151WWPWebNotificationRead) ? true : false);
         A161WWPWebNotificationDetail = "";
         n161WWPWebNotificationDetail = false;
         AssignAttri("", false, "A161WWPWebNotificationDetail", A161WWPWebNotificationDetail);
         n161WWPWebNotificationDetail = (String.IsNullOrEmpty(StringUtil.RTrim( A161WWPWebNotificationDetail)) ? true : false);
         A162WWPWebNotificationReceived = false;
         n162WWPWebNotificationReceived = false;
         AssignAttri("", false, "A162WWPWebNotificationReceived", A162WWPWebNotificationReceived);
         n162WWPWebNotificationReceived = ((false==A162WWPWebNotificationReceived) ? true : false);
         A159WWPWebNotificationStatus = 1;
         AssignAttri("", false, "A159WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A159WWPWebNotificationStatus), 4, 0));
         A150WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A150WWPWebNotificationCreated", context.localUtil.TToC( A150WWPWebNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A163WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A163WWPWebNotificationScheduled", context.localUtil.TToC( A163WWPWebNotificationScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         Z147WWPWebNotificationTitle = "";
         Z148WWPWebNotificationText = "";
         Z149WWPWebNotificationIcon = "";
         Z159WWPWebNotificationStatus = 0;
         Z150WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         Z163WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         Z160WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         Z151WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         Z162WWPWebNotificationReceived = false;
         Z127WWPNotificationId = 0;
      }

      protected void InitAll0L31( )
      {
         A152WWPWebNotificationId = 0;
         AssignAttri("", false, "A152WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A152WWPWebNotificationId), 10, 0));
         InitializeNonKey0L31( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A159WWPWebNotificationStatus = i159WWPWebNotificationStatus;
         AssignAttri("", false, "A159WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A159WWPWebNotificationStatus), 4, 0));
         A150WWPWebNotificationCreated = i150WWPWebNotificationCreated;
         AssignAttri("", false, "A150WWPWebNotificationCreated", context.localUtil.TToC( A150WWPWebNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A163WWPWebNotificationScheduled = i163WWPWebNotificationScheduled;
         AssignAttri("", false, "A163WWPWebNotificationScheduled", context.localUtil.TToC( A163WWPWebNotificationScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256145332875", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/notifications/web/wwp_webnotification.js", "?20256145332875", false, true);
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
         edtWWPWebNotificationId_Internalname = "WWPWEBNOTIFICATIONID";
         edtWWPWebNotificationTitle_Internalname = "WWPWEBNOTIFICATIONTITLE";
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID";
         edtWWPNotificationCreated_Internalname = "WWPNOTIFICATIONCREATED";
         edtWWPNotificationMetadata_Internalname = "WWPNOTIFICATIONMETADATA";
         edtWWPNotificationDefinitionName_Internalname = "WWPNOTIFICATIONDEFINITIONNAME";
         edtWWPWebNotificationText_Internalname = "WWPWEBNOTIFICATIONTEXT";
         edtWWPWebNotificationIcon_Internalname = "WWPWEBNOTIFICATIONICON";
         edtWWPWebNotificationClientId_Internalname = "WWPWEBNOTIFICATIONCLIENTID";
         cmbWWPWebNotificationStatus_Internalname = "WWPWEBNOTIFICATIONSTATUS";
         edtWWPWebNotificationCreated_Internalname = "WWPWEBNOTIFICATIONCREATED";
         edtWWPWebNotificationScheduled_Internalname = "WWPWEBNOTIFICATIONSCHEDULED";
         edtWWPWebNotificationProcessed_Internalname = "WWPWEBNOTIFICATIONPROCESSED";
         edtWWPWebNotificationRead_Internalname = "WWPWEBNOTIFICATIONREAD";
         edtWWPWebNotificationDetail_Internalname = "WWPWEBNOTIFICATIONDETAIL";
         chkWWPWebNotificationReceived_Internalname = "WWPWEBNOTIFICATIONRECEIVED";
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
         Form.Caption = context.GetMessage( "WWP_Web Notification", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkWWPWebNotificationReceived.Enabled = 1;
         edtWWPWebNotificationDetail_Enabled = 1;
         edtWWPWebNotificationRead_Jsonclick = "";
         edtWWPWebNotificationRead_Enabled = 1;
         edtWWPWebNotificationProcessed_Jsonclick = "";
         edtWWPWebNotificationProcessed_Enabled = 1;
         edtWWPWebNotificationScheduled_Jsonclick = "";
         edtWWPWebNotificationScheduled_Enabled = 1;
         edtWWPWebNotificationCreated_Jsonclick = "";
         edtWWPWebNotificationCreated_Enabled = 1;
         cmbWWPWebNotificationStatus_Jsonclick = "";
         cmbWWPWebNotificationStatus.Enabled = 1;
         edtWWPWebNotificationClientId_Enabled = 1;
         edtWWPWebNotificationIcon_Enabled = 1;
         edtWWPWebNotificationText_Jsonclick = "";
         edtWWPWebNotificationText_Enabled = 1;
         edtWWPNotificationDefinitionName_Jsonclick = "";
         edtWWPNotificationDefinitionName_Enabled = 0;
         edtWWPNotificationMetadata_Enabled = 0;
         edtWWPNotificationCreated_Jsonclick = "";
         edtWWPNotificationCreated_Enabled = 0;
         edtWWPNotificationId_Jsonclick = "";
         edtWWPNotificationId_Enabled = 1;
         edtWWPWebNotificationTitle_Jsonclick = "";
         edtWWPWebNotificationTitle_Enabled = 1;
         edtWWPWebNotificationId_Jsonclick = "";
         edtWWPWebNotificationId_Enabled = 1;
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
         cmbWWPWebNotificationStatus.Name = "WWPWEBNOTIFICATIONSTATUS";
         cmbWWPWebNotificationStatus.WebTags = "";
         cmbWWPWebNotificationStatus.addItem("1", context.GetMessage( "Pending", ""), 0);
         cmbWWPWebNotificationStatus.addItem("2", context.GetMessage( "Sent", ""), 0);
         cmbWWPWebNotificationStatus.addItem("3", context.GetMessage( "Error", ""), 0);
         if ( cmbWWPWebNotificationStatus.ItemCount > 0 )
         {
            if ( IsIns( ) && (0==A159WWPWebNotificationStatus) )
            {
               A159WWPWebNotificationStatus = 1;
               AssignAttri("", false, "A159WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A159WWPWebNotificationStatus), 4, 0));
            }
         }
         chkWWPWebNotificationReceived.Name = "WWPWEBNOTIFICATIONRECEIVED";
         chkWWPWebNotificationReceived.WebTags = "";
         chkWWPWebNotificationReceived.Caption = context.GetMessage( "Notification Received", "");
         AssignProp("", false, chkWWPWebNotificationReceived_Internalname, "TitleCaption", chkWWPWebNotificationReceived.Caption, true);
         chkWWPWebNotificationReceived.CheckedValue = "false";
         A162WWPWebNotificationReceived = StringUtil.StrToBool( StringUtil.BoolToStr( A162WWPWebNotificationReceived));
         n162WWPWebNotificationReceived = false;
         AssignAttri("", false, "A162WWPWebNotificationReceived", A162WWPWebNotificationReceived);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtWWPWebNotificationTitle_Internalname;
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

      public void Valid_Wwpwebnotificationid( )
      {
         A159WWPWebNotificationStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPWebNotificationStatus.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbWWPWebNotificationStatus.CurrentValue = StringUtil.LTrimStr( (decimal)(A159WWPWebNotificationStatus), 4, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbWWPWebNotificationStatus.ItemCount > 0 )
         {
            A159WWPWebNotificationStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPWebNotificationStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A159WWPWebNotificationStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
            cmbWWPWebNotificationStatus.CurrentValue = StringUtil.LTrimStr( (decimal)(A159WWPWebNotificationStatus), 4, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPWebNotificationStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A159WWPWebNotificationStatus), 4, 0));
         }
         A162WWPWebNotificationReceived = StringUtil.StrToBool( StringUtil.BoolToStr( A162WWPWebNotificationReceived));
         n162WWPWebNotificationReceived = false;
         /*  Sending validation outputs */
         AssignAttri("", false, "A147WWPWebNotificationTitle", A147WWPWebNotificationTitle);
         AssignAttri("", false, "A127WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A127WWPNotificationId), 10, 0, ".", "")));
         AssignAttri("", false, "A148WWPWebNotificationText", A148WWPWebNotificationText);
         AssignAttri("", false, "A149WWPWebNotificationIcon", A149WWPWebNotificationIcon);
         AssignAttri("", false, "A158WWPWebNotificationClientId", A158WWPWebNotificationClientId);
         AssignAttri("", false, "A159WWPWebNotificationStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(A159WWPWebNotificationStatus), 4, 0, ".", "")));
         cmbWWPWebNotificationStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A159WWPWebNotificationStatus), 4, 0));
         AssignProp("", false, cmbWWPWebNotificationStatus_Internalname, "Values", cmbWWPWebNotificationStatus.ToJavascriptSource(), true);
         AssignAttri("", false, "A150WWPWebNotificationCreated", context.localUtil.TToC( A150WWPWebNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A163WWPWebNotificationScheduled", context.localUtil.TToC( A163WWPWebNotificationScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A160WWPWebNotificationProcessed", context.localUtil.TToC( A160WWPWebNotificationProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A151WWPWebNotificationRead", context.localUtil.TToC( A151WWPWebNotificationRead, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A161WWPWebNotificationDetail", A161WWPWebNotificationDetail);
         AssignAttri("", false, "A162WWPWebNotificationReceived", A162WWPWebNotificationReceived);
         AssignAttri("", false, "A128WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A128WWPNotificationDefinitionId), 10, 0, ".", "")));
         AssignAttri("", false, "A129WWPNotificationCreated", context.localUtil.TToC( A129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A165WWPNotificationMetadata", A165WWPNotificationMetadata);
         AssignAttri("", false, "A164WWPNotificationDefinitionName", A164WWPNotificationDefinitionName);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z152WWPWebNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z152WWPWebNotificationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z147WWPWebNotificationTitle", Z147WWPWebNotificationTitle);
         GxWebStd.gx_hidden_field( context, "Z127WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z127WWPNotificationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z148WWPWebNotificationText", Z148WWPWebNotificationText);
         GxWebStd.gx_hidden_field( context, "Z149WWPWebNotificationIcon", Z149WWPWebNotificationIcon);
         GxWebStd.gx_hidden_field( context, "Z158WWPWebNotificationClientId", Z158WWPWebNotificationClientId);
         GxWebStd.gx_hidden_field( context, "Z159WWPWebNotificationStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z159WWPWebNotificationStatus), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z150WWPWebNotificationCreated", context.localUtil.TToC( Z150WWPWebNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z163WWPWebNotificationScheduled", context.localUtil.TToC( Z163WWPWebNotificationScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z160WWPWebNotificationProcessed", context.localUtil.TToC( Z160WWPWebNotificationProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z151WWPWebNotificationRead", context.localUtil.TToC( Z151WWPWebNotificationRead, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z161WWPWebNotificationDetail", Z161WWPWebNotificationDetail);
         GxWebStd.gx_hidden_field( context, "Z162WWPWebNotificationReceived", StringUtil.BoolToStr( Z162WWPWebNotificationReceived));
         GxWebStd.gx_hidden_field( context, "Z128WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z128WWPNotificationDefinitionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z129WWPNotificationCreated", context.localUtil.TToC( Z129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z165WWPNotificationMetadata", Z165WWPNotificationMetadata);
         GxWebStd.gx_hidden_field( context, "Z164WWPNotificationDefinitionName", Z164WWPNotificationDefinitionName);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpnotificationid( )
      {
         n127WWPNotificationId = false;
         n165WWPNotificationMetadata = false;
         /* Using cursor T000L16 */
         pr_default.execute(14, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A127WWPNotificationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Notification", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
            }
         }
         A128WWPNotificationDefinitionId = T000L16_A128WWPNotificationDefinitionId[0];
         A129WWPNotificationCreated = T000L16_A129WWPNotificationCreated[0];
         A165WWPNotificationMetadata = T000L16_A165WWPNotificationMetadata[0];
         n165WWPNotificationMetadata = T000L16_n165WWPNotificationMetadata[0];
         pr_default.close(14);
         /* Using cursor T000L17 */
         pr_default.execute(15, new Object[] {A128WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (0==A128WWPNotificationDefinitionId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_NotificationDefinition", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
               AnyError = 1;
            }
         }
         A164WWPNotificationDefinitionName = T000L17_A164WWPNotificationDefinitionName[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A128WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A128WWPNotificationDefinitionId), 10, 0, ".", "")));
         AssignAttri("", false, "A129WWPNotificationCreated", context.localUtil.TToC( A129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A165WWPNotificationMetadata", A165WWPNotificationMetadata);
         AssignAttri("", false, "A164WWPNotificationDefinitionName", A164WWPNotificationDefinitionName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A162WWPWebNotificationReceived","fld":"WWPWEBNOTIFICATIONRECEIVED"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A162WWPWebNotificationReceived","fld":"WWPWEBNOTIFICATIONRECEIVED"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A162WWPWebNotificationReceived","fld":"WWPWEBNOTIFICATIONRECEIVED"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A162WWPWebNotificationReceived","fld":"WWPWEBNOTIFICATIONRECEIVED"}]}""");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONID","""{"handler":"Valid_Wwpwebnotificationid","iparms":[{"av":"A152WWPWebNotificationId","fld":"WWPWEBNOTIFICATIONID","pic":"ZZZZZZZZZ9"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"cmbWWPWebNotificationStatus"},{"av":"A159WWPWebNotificationStatus","fld":"WWPWEBNOTIFICATIONSTATUS","pic":"ZZZ9"},{"av":"A150WWPWebNotificationCreated","fld":"WWPWEBNOTIFICATIONCREATED","pic":"99/99/9999 99:99:99.999"},{"av":"A163WWPWebNotificationScheduled","fld":"WWPWEBNOTIFICATIONSCHEDULED","pic":"99/99/9999 99:99:99.999"},{"av":"A162WWPWebNotificationReceived","fld":"WWPWEBNOTIFICATIONRECEIVED"}]""");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONID",""","oparms":[{"av":"A147WWPWebNotificationTitle","fld":"WWPWEBNOTIFICATIONTITLE"},{"av":"A127WWPNotificationId","fld":"WWPNOTIFICATIONID","pic":"ZZZZZZZZZ9"},{"av":"A148WWPWebNotificationText","fld":"WWPWEBNOTIFICATIONTEXT"},{"av":"A149WWPWebNotificationIcon","fld":"WWPWEBNOTIFICATIONICON"},{"av":"A158WWPWebNotificationClientId","fld":"WWPWEBNOTIFICATIONCLIENTID"},{"av":"cmbWWPWebNotificationStatus"},{"av":"A159WWPWebNotificationStatus","fld":"WWPWEBNOTIFICATIONSTATUS","pic":"ZZZ9"},{"av":"A150WWPWebNotificationCreated","fld":"WWPWEBNOTIFICATIONCREATED","pic":"99/99/9999 99:99:99.999"},{"av":"A163WWPWebNotificationScheduled","fld":"WWPWEBNOTIFICATIONSCHEDULED","pic":"99/99/9999 99:99:99.999"},{"av":"A160WWPWebNotificationProcessed","fld":"WWPWEBNOTIFICATIONPROCESSED","pic":"99/99/9999 99:99:99.999"},{"av":"A151WWPWebNotificationRead","fld":"WWPWEBNOTIFICATIONREAD","pic":"99/99/9999 99:99:99.999"},{"av":"A161WWPWebNotificationDetail","fld":"WWPWEBNOTIFICATIONDETAIL"},{"av":"A128WWPNotificationDefinitionId","fld":"WWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9"},{"av":"A129WWPNotificationCreated","fld":"WWPNOTIFICATIONCREATED","pic":"99/99/9999 99:99:99.999"},{"av":"A165WWPNotificationMetadata","fld":"WWPNOTIFICATIONMETADATA"},{"av":"A164WWPNotificationDefinitionName","fld":"WWPNOTIFICATIONDEFINITIONNAME"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z152WWPWebNotificationId"},{"av":"Z147WWPWebNotificationTitle"},{"av":"Z127WWPNotificationId"},{"av":"Z148WWPWebNotificationText"},{"av":"Z149WWPWebNotificationIcon"},{"av":"Z158WWPWebNotificationClientId"},{"av":"Z159WWPWebNotificationStatus"},{"av":"Z150WWPWebNotificationCreated"},{"av":"Z163WWPWebNotificationScheduled"},{"av":"Z160WWPWebNotificationProcessed"},{"av":"Z151WWPWebNotificationRead"},{"av":"Z161WWPWebNotificationDetail"},{"av":"Z162WWPWebNotificationReceived"},{"av":"Z128WWPNotificationDefinitionId"},{"av":"Z129WWPNotificationCreated"},{"av":"Z165WWPNotificationMetadata"},{"av":"Z164WWPNotificationDefinitionName"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A162WWPWebNotificationReceived","fld":"WWPWEBNOTIFICATIONRECEIVED"}]}""");
         setEventMetadata("VALID_WWPNOTIFICATIONID","""{"handler":"Valid_Wwpnotificationid","iparms":[{"av":"A127WWPNotificationId","fld":"WWPNOTIFICATIONID","pic":"ZZZZZZZZZ9"},{"av":"A128WWPNotificationDefinitionId","fld":"WWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9"},{"av":"A129WWPNotificationCreated","fld":"WWPNOTIFICATIONCREATED","pic":"99/99/9999 99:99:99.999"},{"av":"A165WWPNotificationMetadata","fld":"WWPNOTIFICATIONMETADATA"},{"av":"A164WWPNotificationDefinitionName","fld":"WWPNOTIFICATIONDEFINITIONNAME"},{"av":"A162WWPWebNotificationReceived","fld":"WWPWEBNOTIFICATIONRECEIVED"}]""");
         setEventMetadata("VALID_WWPNOTIFICATIONID",""","oparms":[{"av":"A128WWPNotificationDefinitionId","fld":"WWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9"},{"av":"A129WWPNotificationCreated","fld":"WWPNOTIFICATIONCREATED","pic":"99/99/9999 99:99:99.999"},{"av":"A165WWPNotificationMetadata","fld":"WWPNOTIFICATIONMETADATA"},{"av":"A164WWPNotificationDefinitionName","fld":"WWPNOTIFICATIONDEFINITIONNAME"},{"av":"A162WWPWebNotificationReceived","fld":"WWPWEBNOTIFICATIONRECEIVED"}]}""");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONSTATUS","""{"handler":"Valid_Wwpwebnotificationstatus","iparms":[{"av":"A162WWPWebNotificationReceived","fld":"WWPWEBNOTIFICATIONRECEIVED"}]""");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONSTATUS",""","oparms":[{"av":"A162WWPWebNotificationReceived","fld":"WWPWEBNOTIFICATIONRECEIVED"}]}""");
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
         Z147WWPWebNotificationTitle = "";
         Z148WWPWebNotificationText = "";
         Z149WWPWebNotificationIcon = "";
         Z150WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         Z163WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         Z160WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         Z151WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
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
         A147WWPWebNotificationTitle = "";
         A129WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A165WWPNotificationMetadata = "";
         A164WWPNotificationDefinitionName = "";
         A148WWPWebNotificationText = "";
         A149WWPWebNotificationIcon = "";
         A158WWPWebNotificationClientId = "";
         A150WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         A163WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         A160WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         A151WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         A161WWPWebNotificationDetail = "";
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
         Z158WWPWebNotificationClientId = "";
         Z161WWPWebNotificationDetail = "";
         Z129WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z165WWPNotificationMetadata = "";
         Z164WWPNotificationDefinitionName = "";
         T000L6_A128WWPNotificationDefinitionId = new long[1] ;
         T000L6_A152WWPWebNotificationId = new long[1] ;
         T000L6_A147WWPWebNotificationTitle = new string[] {""} ;
         T000L6_A129WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000L6_A165WWPNotificationMetadata = new string[] {""} ;
         T000L6_n165WWPNotificationMetadata = new bool[] {false} ;
         T000L6_A164WWPNotificationDefinitionName = new string[] {""} ;
         T000L6_A148WWPWebNotificationText = new string[] {""} ;
         T000L6_A149WWPWebNotificationIcon = new string[] {""} ;
         T000L6_A158WWPWebNotificationClientId = new string[] {""} ;
         T000L6_A159WWPWebNotificationStatus = new short[1] ;
         T000L6_A150WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000L6_A163WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         T000L6_A160WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         T000L6_A151WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         T000L6_n151WWPWebNotificationRead = new bool[] {false} ;
         T000L6_A161WWPWebNotificationDetail = new string[] {""} ;
         T000L6_n161WWPWebNotificationDetail = new bool[] {false} ;
         T000L6_A162WWPWebNotificationReceived = new bool[] {false} ;
         T000L6_n162WWPWebNotificationReceived = new bool[] {false} ;
         T000L6_A127WWPNotificationId = new long[1] ;
         T000L6_n127WWPNotificationId = new bool[] {false} ;
         T000L4_A128WWPNotificationDefinitionId = new long[1] ;
         T000L4_A129WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000L4_A165WWPNotificationMetadata = new string[] {""} ;
         T000L4_n165WWPNotificationMetadata = new bool[] {false} ;
         T000L5_A164WWPNotificationDefinitionName = new string[] {""} ;
         T000L7_A128WWPNotificationDefinitionId = new long[1] ;
         T000L7_A129WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000L7_A165WWPNotificationMetadata = new string[] {""} ;
         T000L7_n165WWPNotificationMetadata = new bool[] {false} ;
         T000L8_A164WWPNotificationDefinitionName = new string[] {""} ;
         T000L9_A152WWPWebNotificationId = new long[1] ;
         T000L3_A152WWPWebNotificationId = new long[1] ;
         T000L3_A147WWPWebNotificationTitle = new string[] {""} ;
         T000L3_A148WWPWebNotificationText = new string[] {""} ;
         T000L3_A149WWPWebNotificationIcon = new string[] {""} ;
         T000L3_A158WWPWebNotificationClientId = new string[] {""} ;
         T000L3_A159WWPWebNotificationStatus = new short[1] ;
         T000L3_A150WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000L3_A163WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         T000L3_A160WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         T000L3_A151WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         T000L3_n151WWPWebNotificationRead = new bool[] {false} ;
         T000L3_A161WWPWebNotificationDetail = new string[] {""} ;
         T000L3_n161WWPWebNotificationDetail = new bool[] {false} ;
         T000L3_A162WWPWebNotificationReceived = new bool[] {false} ;
         T000L3_n162WWPWebNotificationReceived = new bool[] {false} ;
         T000L3_A127WWPNotificationId = new long[1] ;
         T000L3_n127WWPNotificationId = new bool[] {false} ;
         sMode31 = "";
         T000L10_A152WWPWebNotificationId = new long[1] ;
         T000L11_A152WWPWebNotificationId = new long[1] ;
         T000L2_A152WWPWebNotificationId = new long[1] ;
         T000L2_A147WWPWebNotificationTitle = new string[] {""} ;
         T000L2_A148WWPWebNotificationText = new string[] {""} ;
         T000L2_A149WWPWebNotificationIcon = new string[] {""} ;
         T000L2_A158WWPWebNotificationClientId = new string[] {""} ;
         T000L2_A159WWPWebNotificationStatus = new short[1] ;
         T000L2_A150WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000L2_A163WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         T000L2_A160WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         T000L2_A151WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         T000L2_n151WWPWebNotificationRead = new bool[] {false} ;
         T000L2_A161WWPWebNotificationDetail = new string[] {""} ;
         T000L2_n161WWPWebNotificationDetail = new bool[] {false} ;
         T000L2_A162WWPWebNotificationReceived = new bool[] {false} ;
         T000L2_n162WWPWebNotificationReceived = new bool[] {false} ;
         T000L2_A127WWPNotificationId = new long[1] ;
         T000L2_n127WWPNotificationId = new bool[] {false} ;
         T000L13_A152WWPWebNotificationId = new long[1] ;
         T000L16_A128WWPNotificationDefinitionId = new long[1] ;
         T000L16_A129WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000L16_A165WWPNotificationMetadata = new string[] {""} ;
         T000L16_n165WWPNotificationMetadata = new bool[] {false} ;
         T000L17_A164WWPNotificationDefinitionName = new string[] {""} ;
         T000L18_A152WWPWebNotificationId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i150WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         i163WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         ZZ147WWPWebNotificationTitle = "";
         ZZ148WWPWebNotificationText = "";
         ZZ149WWPWebNotificationIcon = "";
         ZZ158WWPWebNotificationClientId = "";
         ZZ150WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         ZZ163WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         ZZ160WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         ZZ151WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         ZZ161WWPWebNotificationDetail = "";
         ZZ129WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         ZZ165WWPNotificationMetadata = "";
         ZZ164WWPNotificationDefinitionName = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webnotification__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webnotification__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webnotification__default(),
            new Object[][] {
                new Object[] {
               T000L2_A152WWPWebNotificationId, T000L2_A147WWPWebNotificationTitle, T000L2_A148WWPWebNotificationText, T000L2_A149WWPWebNotificationIcon, T000L2_A158WWPWebNotificationClientId, T000L2_A159WWPWebNotificationStatus, T000L2_A150WWPWebNotificationCreated, T000L2_A163WWPWebNotificationScheduled, T000L2_A160WWPWebNotificationProcessed, T000L2_A151WWPWebNotificationRead,
               T000L2_n151WWPWebNotificationRead, T000L2_A161WWPWebNotificationDetail, T000L2_n161WWPWebNotificationDetail, T000L2_A162WWPWebNotificationReceived, T000L2_n162WWPWebNotificationReceived, T000L2_A127WWPNotificationId, T000L2_n127WWPNotificationId
               }
               , new Object[] {
               T000L3_A152WWPWebNotificationId, T000L3_A147WWPWebNotificationTitle, T000L3_A148WWPWebNotificationText, T000L3_A149WWPWebNotificationIcon, T000L3_A158WWPWebNotificationClientId, T000L3_A159WWPWebNotificationStatus, T000L3_A150WWPWebNotificationCreated, T000L3_A163WWPWebNotificationScheduled, T000L3_A160WWPWebNotificationProcessed, T000L3_A151WWPWebNotificationRead,
               T000L3_n151WWPWebNotificationRead, T000L3_A161WWPWebNotificationDetail, T000L3_n161WWPWebNotificationDetail, T000L3_A162WWPWebNotificationReceived, T000L3_n162WWPWebNotificationReceived, T000L3_A127WWPNotificationId, T000L3_n127WWPNotificationId
               }
               , new Object[] {
               T000L4_A128WWPNotificationDefinitionId, T000L4_A129WWPNotificationCreated, T000L4_A165WWPNotificationMetadata, T000L4_n165WWPNotificationMetadata
               }
               , new Object[] {
               T000L5_A164WWPNotificationDefinitionName
               }
               , new Object[] {
               T000L6_A128WWPNotificationDefinitionId, T000L6_A152WWPWebNotificationId, T000L6_A147WWPWebNotificationTitle, T000L6_A129WWPNotificationCreated, T000L6_A165WWPNotificationMetadata, T000L6_n165WWPNotificationMetadata, T000L6_A164WWPNotificationDefinitionName, T000L6_A148WWPWebNotificationText, T000L6_A149WWPWebNotificationIcon, T000L6_A158WWPWebNotificationClientId,
               T000L6_A159WWPWebNotificationStatus, T000L6_A150WWPWebNotificationCreated, T000L6_A163WWPWebNotificationScheduled, T000L6_A160WWPWebNotificationProcessed, T000L6_A151WWPWebNotificationRead, T000L6_n151WWPWebNotificationRead, T000L6_A161WWPWebNotificationDetail, T000L6_n161WWPWebNotificationDetail, T000L6_A162WWPWebNotificationReceived, T000L6_n162WWPWebNotificationReceived,
               T000L6_A127WWPNotificationId, T000L6_n127WWPNotificationId
               }
               , new Object[] {
               T000L7_A128WWPNotificationDefinitionId, T000L7_A129WWPNotificationCreated, T000L7_A165WWPNotificationMetadata, T000L7_n165WWPNotificationMetadata
               }
               , new Object[] {
               T000L8_A164WWPNotificationDefinitionName
               }
               , new Object[] {
               T000L9_A152WWPWebNotificationId
               }
               , new Object[] {
               T000L10_A152WWPWebNotificationId
               }
               , new Object[] {
               T000L11_A152WWPWebNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               T000L13_A152WWPWebNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000L16_A128WWPNotificationDefinitionId, T000L16_A129WWPNotificationCreated, T000L16_A165WWPNotificationMetadata, T000L16_n165WWPNotificationMetadata
               }
               , new Object[] {
               T000L17_A164WWPNotificationDefinitionName
               }
               , new Object[] {
               T000L18_A152WWPWebNotificationId
               }
            }
         );
         Z163WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         A163WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         i163WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z150WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A150WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i150WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z159WWPWebNotificationStatus = 1;
         A159WWPWebNotificationStatus = 1;
         i159WWPWebNotificationStatus = 1;
      }

      private short Z159WWPWebNotificationStatus ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A159WWPWebNotificationStatus ;
      private short Gx_BScreen ;
      private short RcdFound31 ;
      private short gxajaxcallmode ;
      private short i159WWPWebNotificationStatus ;
      private short ZZ159WWPWebNotificationStatus ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPWebNotificationId_Enabled ;
      private int edtWWPWebNotificationTitle_Enabled ;
      private int edtWWPNotificationId_Enabled ;
      private int edtWWPNotificationCreated_Enabled ;
      private int edtWWPNotificationMetadata_Enabled ;
      private int edtWWPNotificationDefinitionName_Enabled ;
      private int edtWWPWebNotificationText_Enabled ;
      private int edtWWPWebNotificationIcon_Enabled ;
      private int edtWWPWebNotificationClientId_Enabled ;
      private int edtWWPWebNotificationCreated_Enabled ;
      private int edtWWPWebNotificationScheduled_Enabled ;
      private int edtWWPWebNotificationProcessed_Enabled ;
      private int edtWWPWebNotificationRead_Enabled ;
      private int edtWWPWebNotificationDetail_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z152WWPWebNotificationId ;
      private long Z127WWPNotificationId ;
      private long A127WWPNotificationId ;
      private long A128WWPNotificationDefinitionId ;
      private long A152WWPWebNotificationId ;
      private long Z128WWPNotificationDefinitionId ;
      private long ZZ152WWPWebNotificationId ;
      private long ZZ127WWPNotificationId ;
      private long ZZ128WWPNotificationDefinitionId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPWebNotificationId_Internalname ;
      private string cmbWWPWebNotificationStatus_Internalname ;
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
      private string edtWWPWebNotificationId_Jsonclick ;
      private string edtWWPWebNotificationTitle_Internalname ;
      private string edtWWPWebNotificationTitle_Jsonclick ;
      private string edtWWPNotificationId_Internalname ;
      private string edtWWPNotificationId_Jsonclick ;
      private string edtWWPNotificationCreated_Internalname ;
      private string edtWWPNotificationCreated_Jsonclick ;
      private string edtWWPNotificationMetadata_Internalname ;
      private string edtWWPNotificationDefinitionName_Internalname ;
      private string edtWWPNotificationDefinitionName_Jsonclick ;
      private string edtWWPWebNotificationText_Internalname ;
      private string edtWWPWebNotificationText_Jsonclick ;
      private string edtWWPWebNotificationIcon_Internalname ;
      private string edtWWPWebNotificationClientId_Internalname ;
      private string cmbWWPWebNotificationStatus_Jsonclick ;
      private string edtWWPWebNotificationCreated_Internalname ;
      private string edtWWPWebNotificationCreated_Jsonclick ;
      private string edtWWPWebNotificationScheduled_Internalname ;
      private string edtWWPWebNotificationScheduled_Jsonclick ;
      private string edtWWPWebNotificationProcessed_Internalname ;
      private string edtWWPWebNotificationProcessed_Jsonclick ;
      private string edtWWPWebNotificationRead_Internalname ;
      private string edtWWPWebNotificationRead_Jsonclick ;
      private string edtWWPWebNotificationDetail_Internalname ;
      private string chkWWPWebNotificationReceived_Internalname ;
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
      private string sMode31 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z150WWPWebNotificationCreated ;
      private DateTime Z163WWPWebNotificationScheduled ;
      private DateTime Z160WWPWebNotificationProcessed ;
      private DateTime Z151WWPWebNotificationRead ;
      private DateTime A129WWPNotificationCreated ;
      private DateTime A150WWPWebNotificationCreated ;
      private DateTime A163WWPWebNotificationScheduled ;
      private DateTime A160WWPWebNotificationProcessed ;
      private DateTime A151WWPWebNotificationRead ;
      private DateTime Z129WWPNotificationCreated ;
      private DateTime i150WWPWebNotificationCreated ;
      private DateTime i163WWPWebNotificationScheduled ;
      private DateTime ZZ150WWPWebNotificationCreated ;
      private DateTime ZZ163WWPWebNotificationScheduled ;
      private DateTime ZZ160WWPWebNotificationProcessed ;
      private DateTime ZZ151WWPWebNotificationRead ;
      private DateTime ZZ129WWPNotificationCreated ;
      private bool Z162WWPWebNotificationReceived ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n127WWPNotificationId ;
      private bool wbErr ;
      private bool A162WWPWebNotificationReceived ;
      private bool n162WWPWebNotificationReceived ;
      private bool n151WWPWebNotificationRead ;
      private bool n165WWPNotificationMetadata ;
      private bool n161WWPWebNotificationDetail ;
      private bool Gx_longc ;
      private bool ZZ162WWPWebNotificationReceived ;
      private string A165WWPNotificationMetadata ;
      private string A158WWPWebNotificationClientId ;
      private string A161WWPWebNotificationDetail ;
      private string Z158WWPWebNotificationClientId ;
      private string Z161WWPWebNotificationDetail ;
      private string Z165WWPNotificationMetadata ;
      private string ZZ158WWPWebNotificationClientId ;
      private string ZZ161WWPWebNotificationDetail ;
      private string ZZ165WWPNotificationMetadata ;
      private string Z147WWPWebNotificationTitle ;
      private string Z148WWPWebNotificationText ;
      private string Z149WWPWebNotificationIcon ;
      private string A147WWPWebNotificationTitle ;
      private string A164WWPNotificationDefinitionName ;
      private string A148WWPWebNotificationText ;
      private string A149WWPWebNotificationIcon ;
      private string Z164WWPNotificationDefinitionName ;
      private string ZZ147WWPWebNotificationTitle ;
      private string ZZ148WWPWebNotificationText ;
      private string ZZ149WWPWebNotificationIcon ;
      private string ZZ164WWPNotificationDefinitionName ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbWWPWebNotificationStatus ;
      private GXCheckbox chkWWPWebNotificationReceived ;
      private IDataStoreProvider pr_default ;
      private long[] T000L6_A128WWPNotificationDefinitionId ;
      private long[] T000L6_A152WWPWebNotificationId ;
      private string[] T000L6_A147WWPWebNotificationTitle ;
      private DateTime[] T000L6_A129WWPNotificationCreated ;
      private string[] T000L6_A165WWPNotificationMetadata ;
      private bool[] T000L6_n165WWPNotificationMetadata ;
      private string[] T000L6_A164WWPNotificationDefinitionName ;
      private string[] T000L6_A148WWPWebNotificationText ;
      private string[] T000L6_A149WWPWebNotificationIcon ;
      private string[] T000L6_A158WWPWebNotificationClientId ;
      private short[] T000L6_A159WWPWebNotificationStatus ;
      private DateTime[] T000L6_A150WWPWebNotificationCreated ;
      private DateTime[] T000L6_A163WWPWebNotificationScheduled ;
      private DateTime[] T000L6_A160WWPWebNotificationProcessed ;
      private DateTime[] T000L6_A151WWPWebNotificationRead ;
      private bool[] T000L6_n151WWPWebNotificationRead ;
      private string[] T000L6_A161WWPWebNotificationDetail ;
      private bool[] T000L6_n161WWPWebNotificationDetail ;
      private bool[] T000L6_A162WWPWebNotificationReceived ;
      private bool[] T000L6_n162WWPWebNotificationReceived ;
      private long[] T000L6_A127WWPNotificationId ;
      private bool[] T000L6_n127WWPNotificationId ;
      private long[] T000L4_A128WWPNotificationDefinitionId ;
      private DateTime[] T000L4_A129WWPNotificationCreated ;
      private string[] T000L4_A165WWPNotificationMetadata ;
      private bool[] T000L4_n165WWPNotificationMetadata ;
      private string[] T000L5_A164WWPNotificationDefinitionName ;
      private long[] T000L7_A128WWPNotificationDefinitionId ;
      private DateTime[] T000L7_A129WWPNotificationCreated ;
      private string[] T000L7_A165WWPNotificationMetadata ;
      private bool[] T000L7_n165WWPNotificationMetadata ;
      private string[] T000L8_A164WWPNotificationDefinitionName ;
      private long[] T000L9_A152WWPWebNotificationId ;
      private long[] T000L3_A152WWPWebNotificationId ;
      private string[] T000L3_A147WWPWebNotificationTitle ;
      private string[] T000L3_A148WWPWebNotificationText ;
      private string[] T000L3_A149WWPWebNotificationIcon ;
      private string[] T000L3_A158WWPWebNotificationClientId ;
      private short[] T000L3_A159WWPWebNotificationStatus ;
      private DateTime[] T000L3_A150WWPWebNotificationCreated ;
      private DateTime[] T000L3_A163WWPWebNotificationScheduled ;
      private DateTime[] T000L3_A160WWPWebNotificationProcessed ;
      private DateTime[] T000L3_A151WWPWebNotificationRead ;
      private bool[] T000L3_n151WWPWebNotificationRead ;
      private string[] T000L3_A161WWPWebNotificationDetail ;
      private bool[] T000L3_n161WWPWebNotificationDetail ;
      private bool[] T000L3_A162WWPWebNotificationReceived ;
      private bool[] T000L3_n162WWPWebNotificationReceived ;
      private long[] T000L3_A127WWPNotificationId ;
      private bool[] T000L3_n127WWPNotificationId ;
      private long[] T000L10_A152WWPWebNotificationId ;
      private long[] T000L11_A152WWPWebNotificationId ;
      private long[] T000L2_A152WWPWebNotificationId ;
      private string[] T000L2_A147WWPWebNotificationTitle ;
      private string[] T000L2_A148WWPWebNotificationText ;
      private string[] T000L2_A149WWPWebNotificationIcon ;
      private string[] T000L2_A158WWPWebNotificationClientId ;
      private short[] T000L2_A159WWPWebNotificationStatus ;
      private DateTime[] T000L2_A150WWPWebNotificationCreated ;
      private DateTime[] T000L2_A163WWPWebNotificationScheduled ;
      private DateTime[] T000L2_A160WWPWebNotificationProcessed ;
      private DateTime[] T000L2_A151WWPWebNotificationRead ;
      private bool[] T000L2_n151WWPWebNotificationRead ;
      private string[] T000L2_A161WWPWebNotificationDetail ;
      private bool[] T000L2_n161WWPWebNotificationDetail ;
      private bool[] T000L2_A162WWPWebNotificationReceived ;
      private bool[] T000L2_n162WWPWebNotificationReceived ;
      private long[] T000L2_A127WWPNotificationId ;
      private bool[] T000L2_n127WWPNotificationId ;
      private long[] T000L13_A152WWPWebNotificationId ;
      private long[] T000L16_A128WWPNotificationDefinitionId ;
      private DateTime[] T000L16_A129WWPNotificationCreated ;
      private string[] T000L16_A165WWPNotificationMetadata ;
      private bool[] T000L16_n165WWPNotificationMetadata ;
      private string[] T000L17_A164WWPNotificationDefinitionName ;
      private long[] T000L18_A152WWPWebNotificationId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_webnotification__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_webnotification__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_webnotification__default : DataStoreHelperBase, IDataStoreHelper
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
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT000L2;
       prmT000L2 = new Object[] {
       new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
       };
       Object[] prmT000L3;
       prmT000L3 = new Object[] {
       new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
       };
       Object[] prmT000L4;
       prmT000L4 = new Object[] {
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmT000L5;
       prmT000L5 = new Object[] {
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       Object[] prmT000L6;
       prmT000L6 = new Object[] {
       new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
       };
       Object[] prmT000L7;
       prmT000L7 = new Object[] {
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmT000L8;
       prmT000L8 = new Object[] {
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       Object[] prmT000L9;
       prmT000L9 = new Object[] {
       new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
       };
       Object[] prmT000L10;
       prmT000L10 = new Object[] {
       new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
       };
       Object[] prmT000L11;
       prmT000L11 = new Object[] {
       new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
       };
       Object[] prmT000L12;
       prmT000L12 = new Object[] {
       new ParDef("WWPWebNotificationTitle",GXType.VarChar,40,0) ,
       new ParDef("WWPWebNotificationText",GXType.VarChar,120,0) ,
       new ParDef("WWPWebNotificationIcon",GXType.VarChar,255,0) ,
       new ParDef("WWPWebNotificationClientId",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPWebNotificationStatus",GXType.Int16,4,0) ,
       new ParDef("WWPWebNotificationCreated",GXType.DateTime2,10,12) ,
       new ParDef("WWPWebNotificationScheduled",GXType.DateTime2,10,12) ,
       new ParDef("WWPWebNotificationProcessed",GXType.DateTime2,10,12) ,
       new ParDef("WWPWebNotificationRead",GXType.DateTime2,10,12){Nullable=true} ,
       new ParDef("WWPWebNotificationDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("WWPWebNotificationReceived",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmT000L13;
       prmT000L13 = new Object[] {
       };
       Object[] prmT000L14;
       prmT000L14 = new Object[] {
       new ParDef("WWPWebNotificationTitle",GXType.VarChar,40,0) ,
       new ParDef("WWPWebNotificationText",GXType.VarChar,120,0) ,
       new ParDef("WWPWebNotificationIcon",GXType.VarChar,255,0) ,
       new ParDef("WWPWebNotificationClientId",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPWebNotificationStatus",GXType.Int16,4,0) ,
       new ParDef("WWPWebNotificationCreated",GXType.DateTime2,10,12) ,
       new ParDef("WWPWebNotificationScheduled",GXType.DateTime2,10,12) ,
       new ParDef("WWPWebNotificationProcessed",GXType.DateTime2,10,12) ,
       new ParDef("WWPWebNotificationRead",GXType.DateTime2,10,12){Nullable=true} ,
       new ParDef("WWPWebNotificationDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("WWPWebNotificationReceived",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true} ,
       new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
       };
       Object[] prmT000L15;
       prmT000L15 = new Object[] {
       new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
       };
       Object[] prmT000L16;
       prmT000L16 = new Object[] {
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmT000L17;
       prmT000L17 = new Object[] {
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       Object[] prmT000L18;
       prmT000L18 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T000L2", "SELECT WWPWebNotificationId, WWPWebNotificationTitle, WWPWebNotificationText, WWPWebNotificationIcon, WWPWebNotificationClientId, WWPWebNotificationStatus, WWPWebNotificationCreated, WWPWebNotificationScheduled, WWPWebNotificationProcessed, WWPWebNotificationRead, WWPWebNotificationDetail, WWPWebNotificationReceived, WWPNotificationId FROM WWP_WebNotification WHERE WWPWebNotificationId = :WWPWebNotificationId  FOR UPDATE OF WWP_WebNotification NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000L2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000L3", "SELECT WWPWebNotificationId, WWPWebNotificationTitle, WWPWebNotificationText, WWPWebNotificationIcon, WWPWebNotificationClientId, WWPWebNotificationStatus, WWPWebNotificationCreated, WWPWebNotificationScheduled, WWPWebNotificationProcessed, WWPWebNotificationRead, WWPWebNotificationDetail, WWPWebNotificationReceived, WWPNotificationId FROM WWP_WebNotification WHERE WWPWebNotificationId = :WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000L4", "SELECT WWPNotificationDefinitionId, WWPNotificationCreated, WWPNotificationMetadata FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000L5", "SELECT WWPNotificationDefinitionName FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000L6", "SELECT T2.WWPNotificationDefinitionId, TM1.WWPWebNotificationId, TM1.WWPWebNotificationTitle, T2.WWPNotificationCreated, T2.WWPNotificationMetadata, T3.WWPNotificationDefinitionName, TM1.WWPWebNotificationText, TM1.WWPWebNotificationIcon, TM1.WWPWebNotificationClientId, TM1.WWPWebNotificationStatus, TM1.WWPWebNotificationCreated, TM1.WWPWebNotificationScheduled, TM1.WWPWebNotificationProcessed, TM1.WWPWebNotificationRead, TM1.WWPWebNotificationDetail, TM1.WWPWebNotificationReceived, TM1.WWPNotificationId FROM ((WWP_WebNotification TM1 LEFT JOIN WWP_Notification T2 ON T2.WWPNotificationId = TM1.WWPNotificationId) LEFT JOIN WWP_NotificationDefinition T3 ON T3.WWPNotificationDefinitionId = T2.WWPNotificationDefinitionId) WHERE TM1.WWPWebNotificationId = :WWPWebNotificationId ORDER BY TM1.WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L6,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000L7", "SELECT WWPNotificationDefinitionId, WWPNotificationCreated, WWPNotificationMetadata FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000L8", "SELECT WWPNotificationDefinitionName FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L8,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000L9", "SELECT WWPWebNotificationId FROM WWP_WebNotification WHERE WWPWebNotificationId = :WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L9,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000L10", "SELECT WWPWebNotificationId FROM WWP_WebNotification WHERE ( WWPWebNotificationId > :WWPWebNotificationId) ORDER BY WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L10,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000L11", "SELECT WWPWebNotificationId FROM WWP_WebNotification WHERE ( WWPWebNotificationId < :WWPWebNotificationId) ORDER BY WWPWebNotificationId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L11,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000L12", "SAVEPOINT gxupdate;INSERT INTO WWP_WebNotification(WWPWebNotificationTitle, WWPWebNotificationText, WWPWebNotificationIcon, WWPWebNotificationClientId, WWPWebNotificationStatus, WWPWebNotificationCreated, WWPWebNotificationScheduled, WWPWebNotificationProcessed, WWPWebNotificationRead, WWPWebNotificationDetail, WWPWebNotificationReceived, WWPNotificationId) VALUES(:WWPWebNotificationTitle, :WWPWebNotificationText, :WWPWebNotificationIcon, :WWPWebNotificationClientId, :WWPWebNotificationStatus, :WWPWebNotificationCreated, :WWPWebNotificationScheduled, :WWPWebNotificationProcessed, :WWPWebNotificationRead, :WWPWebNotificationDetail, :WWPWebNotificationReceived, :WWPNotificationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000L12)
          ,new CursorDef("T000L13", "SELECT currval('WWPWebNotificationId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L13,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000L14", "SAVEPOINT gxupdate;UPDATE WWP_WebNotification SET WWPWebNotificationTitle=:WWPWebNotificationTitle, WWPWebNotificationText=:WWPWebNotificationText, WWPWebNotificationIcon=:WWPWebNotificationIcon, WWPWebNotificationClientId=:WWPWebNotificationClientId, WWPWebNotificationStatus=:WWPWebNotificationStatus, WWPWebNotificationCreated=:WWPWebNotificationCreated, WWPWebNotificationScheduled=:WWPWebNotificationScheduled, WWPWebNotificationProcessed=:WWPWebNotificationProcessed, WWPWebNotificationRead=:WWPWebNotificationRead, WWPWebNotificationDetail=:WWPWebNotificationDetail, WWPWebNotificationReceived=:WWPWebNotificationReceived, WWPNotificationId=:WWPNotificationId  WHERE WWPWebNotificationId = :WWPWebNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000L14)
          ,new CursorDef("T000L15", "SAVEPOINT gxupdate;DELETE FROM WWP_WebNotification  WHERE WWPWebNotificationId = :WWPWebNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000L15)
          ,new CursorDef("T000L16", "SELECT WWPNotificationDefinitionId, WWPNotificationCreated, WWPNotificationMetadata FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L16,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000L17", "SELECT WWPNotificationDefinitionName FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L17,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000L18", "SELECT WWPWebNotificationId FROM WWP_WebNotification ORDER BY WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L18,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((short[]) buf[5])[0] = rslt.getShort(6);
             ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
             ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
             ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9, true);
             ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(10, true);
             ((bool[]) buf[10])[0] = rslt.wasNull(10);
             ((string[]) buf[11])[0] = rslt.getLongVarchar(11);
             ((bool[]) buf[12])[0] = rslt.wasNull(11);
             ((bool[]) buf[13])[0] = rslt.getBool(12);
             ((bool[]) buf[14])[0] = rslt.wasNull(12);
             ((long[]) buf[15])[0] = rslt.getLong(13);
             ((bool[]) buf[16])[0] = rslt.wasNull(13);
             return;
          case 1 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((short[]) buf[5])[0] = rslt.getShort(6);
             ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
             ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
             ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9, true);
             ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(10, true);
             ((bool[]) buf[10])[0] = rslt.wasNull(10);
             ((string[]) buf[11])[0] = rslt.getLongVarchar(11);
             ((bool[]) buf[12])[0] = rslt.wasNull(11);
             ((bool[]) buf[13])[0] = rslt.getBool(12);
             ((bool[]) buf[14])[0] = rslt.wasNull(12);
             ((long[]) buf[15])[0] = rslt.getLong(13);
             ((bool[]) buf[16])[0] = rslt.wasNull(13);
             return;
          case 2 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 4 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((long[]) buf[1])[0] = rslt.getLong(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((bool[]) buf[5])[0] = rslt.wasNull(5);
             ((string[]) buf[6])[0] = rslt.getVarchar(6);
             ((string[]) buf[7])[0] = rslt.getVarchar(7);
             ((string[]) buf[8])[0] = rslt.getVarchar(8);
             ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
             ((short[]) buf[10])[0] = rslt.getShort(10);
             ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(11, true);
             ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(12, true);
             ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(13, true);
             ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(14, true);
             ((bool[]) buf[15])[0] = rslt.wasNull(14);
             ((string[]) buf[16])[0] = rslt.getLongVarchar(15);
             ((bool[]) buf[17])[0] = rslt.wasNull(15);
             ((bool[]) buf[18])[0] = rslt.getBool(16);
             ((bool[]) buf[19])[0] = rslt.wasNull(16);
             ((long[]) buf[20])[0] = rslt.getLong(17);
             ((bool[]) buf[21])[0] = rslt.wasNull(17);
             return;
          case 5 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
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
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
             return;
          case 15 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 16 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
    }
 }

}

}
