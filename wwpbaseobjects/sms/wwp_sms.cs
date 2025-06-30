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
namespace GeneXus.Programs.wwpbaseobjects.sms {
   public class wwp_sms : GXDataArea
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
         Form.Meta.addItem("description", context.GetMessage( "WWP_SMS", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPSMSId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_sms( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_sms( IGxContext context )
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
         cmbWWPSMSStatus = new GXCombobox();
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
            return "sms_Execute" ;
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
         if ( cmbWWPSMSStatus.ItemCount > 0 )
         {
            A139WWPSMSStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPSMSStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A139WWPSMSStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A139WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A139WWPSMSStatus), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPSMSStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A139WWPSMSStatus), 4, 0));
            AssignProp("", false, cmbWWPSMSStatus_Internalname, "Values", cmbWWPSMSStatus.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "WWP_SMS", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSMSId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSId_Internalname, context.GetMessage( "Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPSMSId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A138WWPSMSId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPSMSId_Enabled!=0) ? context.localUtil.Format( (decimal)(A138WWPSMSId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A138WWPSMSId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPSMSId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPSMSId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSMSMessage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSMessage_Internalname, context.GetMessage( "Message", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPSMSMessage_Internalname, A142WWPSMSMessage, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", 0, 1, edtWWPSMSMessage_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSMSSenderNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSSenderNumber_Internalname, context.GetMessage( "Sender Number", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPSMSSenderNumber_Internalname, A143WWPSMSSenderNumber, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtWWPSMSSenderNumber_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSMSRecipientNumbers_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSRecipientNumbers_Internalname, context.GetMessage( "Recipient Numbers", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPSMSRecipientNumbers_Internalname, A144WWPSMSRecipientNumbers, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtWWPSMSRecipientNumbers_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbWWPSMSStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbWWPSMSStatus_Internalname, context.GetMessage( "Status", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbWWPSMSStatus, cmbWWPSMSStatus_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A139WWPSMSStatus), 4, 0)), 1, cmbWWPSMSStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbWWPSMSStatus.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", true, 0, "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         cmbWWPSMSStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A139WWPSMSStatus), 4, 0));
         AssignProp("", false, cmbWWPSMSStatus_Internalname, "Values", (string)(cmbWWPSMSStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSMSCreated_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSCreated_Internalname, context.GetMessage( "Created", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPSMSCreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPSMSCreated_Internalname, context.localUtil.TToC( A145WWPSMSCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A145WWPSMSCreated, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPSMSCreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPSMSCreated_Enabled, 0, "text", "", 27, "chr", 1, "row", 27, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_bitmap( context, edtWWPSMSCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPSMSCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSMSScheduled_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSScheduled_Internalname, context.GetMessage( "Scheduled", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPSMSScheduled_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPSMSScheduled_Internalname, context.localUtil.TToC( A146WWPSMSScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A146WWPSMSScheduled, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPSMSScheduled_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPSMSScheduled_Enabled, 0, "text", "", 27, "chr", 1, "row", 27, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_bitmap( context, edtWWPSMSScheduled_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPSMSScheduled_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSMSProcessed_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSProcessed_Internalname, context.GetMessage( "Processed", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPSMSProcessed_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPSMSProcessed_Internalname, context.localUtil.TToC( A140WWPSMSProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A140WWPSMSProcessed, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPSMSProcessed_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPSMSProcessed_Enabled, 0, "text", "", 27, "chr", 1, "row", 27, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_bitmap( context, edtWWPSMSProcessed_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPSMSProcessed_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSMSDetail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSDetail_Internalname, context.GetMessage( "Detail", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPSMSDetail_Internalname, A141WWPSMSDetail, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", 0, 1, edtWWPSMSDetail_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A127WWPNotificationId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPNotificationId_Enabled!=0) ? context.localUtil.Format( (decimal)(A127WWPNotificationId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A127WWPNotificationId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPNotificationCreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationCreated_Internalname, context.localUtil.TToC( A129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A129WWPNotificationCreated, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationCreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationCreated_Enabled, 0, "text", "", 27, "chr", 1, "row", 27, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_bitmap( context, edtWWPNotificationCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPNotificationCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
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
            Z138WWPSMSId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z138WWPSMSId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z139WWPSMSStatus = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z139WWPSMSStatus"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z145WWPSMSCreated = context.localUtil.CToT( cgiGet( "Z145WWPSMSCreated"), 0);
            Z146WWPSMSScheduled = context.localUtil.CToT( cgiGet( "Z146WWPSMSScheduled"), 0);
            Z140WWPSMSProcessed = context.localUtil.CToT( cgiGet( "Z140WWPSMSProcessed"), 0);
            n140WWPSMSProcessed = ((DateTime.MinValue==A140WWPSMSProcessed) ? true : false);
            Z127WWPNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z127WWPNotificationId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n127WWPNotificationId = ((0==A127WWPNotificationId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPSMSId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPSMSId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPSMSID");
               AnyError = 1;
               GX_FocusControl = edtWWPSMSId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A138WWPSMSId = 0;
               AssignAttri("", false, "A138WWPSMSId", StringUtil.LTrimStr( (decimal)(A138WWPSMSId), 10, 0));
            }
            else
            {
               A138WWPSMSId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPSMSId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A138WWPSMSId", StringUtil.LTrimStr( (decimal)(A138WWPSMSId), 10, 0));
            }
            A142WWPSMSMessage = cgiGet( edtWWPSMSMessage_Internalname);
            AssignAttri("", false, "A142WWPSMSMessage", A142WWPSMSMessage);
            A143WWPSMSSenderNumber = cgiGet( edtWWPSMSSenderNumber_Internalname);
            AssignAttri("", false, "A143WWPSMSSenderNumber", A143WWPSMSSenderNumber);
            A144WWPSMSRecipientNumbers = cgiGet( edtWWPSMSRecipientNumbers_Internalname);
            AssignAttri("", false, "A144WWPSMSRecipientNumbers", A144WWPSMSRecipientNumbers);
            cmbWWPSMSStatus.CurrentValue = cgiGet( cmbWWPSMSStatus_Internalname);
            A139WWPSMSStatus = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPSMSStatus_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A139WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A139WWPSMSStatus), 4, 0));
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPSMSCreated_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "SMS Created", "")}), 1, "WWPSMSCREATED");
               AnyError = 1;
               GX_FocusControl = edtWWPSMSCreated_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A145WWPSMSCreated = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A145WWPSMSCreated", context.localUtil.TToC( A145WWPSMSCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A145WWPSMSCreated = context.localUtil.CToT( cgiGet( edtWWPSMSCreated_Internalname));
               AssignAttri("", false, "A145WWPSMSCreated", context.localUtil.TToC( A145WWPSMSCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPSMSScheduled_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "SMS Scheduled", "")}), 1, "WWPSMSSCHEDULED");
               AnyError = 1;
               GX_FocusControl = edtWWPSMSScheduled_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A146WWPSMSScheduled = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A146WWPSMSScheduled", context.localUtil.TToC( A146WWPSMSScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A146WWPSMSScheduled = context.localUtil.CToT( cgiGet( edtWWPSMSScheduled_Internalname));
               AssignAttri("", false, "A146WWPSMSScheduled", context.localUtil.TToC( A146WWPSMSScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPSMSProcessed_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "SMS Processed", "")}), 1, "WWPSMSPROCESSED");
               AnyError = 1;
               GX_FocusControl = edtWWPSMSProcessed_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A140WWPSMSProcessed = (DateTime)(DateTime.MinValue);
               n140WWPSMSProcessed = false;
               AssignAttri("", false, "A140WWPSMSProcessed", context.localUtil.TToC( A140WWPSMSProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A140WWPSMSProcessed = context.localUtil.CToT( cgiGet( edtWWPSMSProcessed_Internalname));
               n140WWPSMSProcessed = false;
               AssignAttri("", false, "A140WWPSMSProcessed", context.localUtil.TToC( A140WWPSMSProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            n140WWPSMSProcessed = ((DateTime.MinValue==A140WWPSMSProcessed) ? true : false);
            A141WWPSMSDetail = cgiGet( edtWWPSMSDetail_Internalname);
            n141WWPSMSDetail = false;
            AssignAttri("", false, "A141WWPSMSDetail", A141WWPSMSDetail);
            n141WWPSMSDetail = (String.IsNullOrEmpty(StringUtil.RTrim( A141WWPSMSDetail)) ? true : false);
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
               A138WWPSMSId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPSMSId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A138WWPSMSId", StringUtil.LTrimStr( (decimal)(A138WWPSMSId), 10, 0));
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
               InitAll0K30( ) ;
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
         DisableAttributes0K30( ) ;
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

      protected void ResetCaption0K0( )
      {
      }

      protected void ZM0K30( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z139WWPSMSStatus = T000K3_A139WWPSMSStatus[0];
               Z145WWPSMSCreated = T000K3_A145WWPSMSCreated[0];
               Z146WWPSMSScheduled = T000K3_A146WWPSMSScheduled[0];
               Z140WWPSMSProcessed = T000K3_A140WWPSMSProcessed[0];
               Z127WWPNotificationId = T000K3_A127WWPNotificationId[0];
            }
            else
            {
               Z139WWPSMSStatus = A139WWPSMSStatus;
               Z145WWPSMSCreated = A145WWPSMSCreated;
               Z146WWPSMSScheduled = A146WWPSMSScheduled;
               Z140WWPSMSProcessed = A140WWPSMSProcessed;
               Z127WWPNotificationId = A127WWPNotificationId;
            }
         }
         if ( GX_JID == -5 )
         {
            Z138WWPSMSId = A138WWPSMSId;
            Z142WWPSMSMessage = A142WWPSMSMessage;
            Z143WWPSMSSenderNumber = A143WWPSMSSenderNumber;
            Z144WWPSMSRecipientNumbers = A144WWPSMSRecipientNumbers;
            Z139WWPSMSStatus = A139WWPSMSStatus;
            Z145WWPSMSCreated = A145WWPSMSCreated;
            Z146WWPSMSScheduled = A146WWPSMSScheduled;
            Z140WWPSMSProcessed = A140WWPSMSProcessed;
            Z141WWPSMSDetail = A141WWPSMSDetail;
            Z127WWPNotificationId = A127WWPNotificationId;
            Z129WWPNotificationCreated = A129WWPNotificationCreated;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (0==A139WWPSMSStatus) && ( Gx_BScreen == 0 ) )
         {
            A139WWPSMSStatus = 1;
            AssignAttri("", false, "A139WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A139WWPSMSStatus), 4, 0));
         }
         if ( IsIns( )  && (DateTime.MinValue==A145WWPSMSCreated) && ( Gx_BScreen == 0 ) )
         {
            A145WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A145WWPSMSCreated", context.localUtil.TToC( A145WWPSMSCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         }
         if ( IsIns( )  && (DateTime.MinValue==A146WWPSMSScheduled) && ( Gx_BScreen == 0 ) )
         {
            A146WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A146WWPSMSScheduled", context.localUtil.TToC( A146WWPSMSScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
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

      protected void Load0K30( )
      {
         /* Using cursor T000K5 */
         pr_default.execute(3, new Object[] {A138WWPSMSId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound30 = 1;
            A142WWPSMSMessage = T000K5_A142WWPSMSMessage[0];
            AssignAttri("", false, "A142WWPSMSMessage", A142WWPSMSMessage);
            A143WWPSMSSenderNumber = T000K5_A143WWPSMSSenderNumber[0];
            AssignAttri("", false, "A143WWPSMSSenderNumber", A143WWPSMSSenderNumber);
            A144WWPSMSRecipientNumbers = T000K5_A144WWPSMSRecipientNumbers[0];
            AssignAttri("", false, "A144WWPSMSRecipientNumbers", A144WWPSMSRecipientNumbers);
            A139WWPSMSStatus = T000K5_A139WWPSMSStatus[0];
            AssignAttri("", false, "A139WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A139WWPSMSStatus), 4, 0));
            A145WWPSMSCreated = T000K5_A145WWPSMSCreated[0];
            AssignAttri("", false, "A145WWPSMSCreated", context.localUtil.TToC( A145WWPSMSCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A146WWPSMSScheduled = T000K5_A146WWPSMSScheduled[0];
            AssignAttri("", false, "A146WWPSMSScheduled", context.localUtil.TToC( A146WWPSMSScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A140WWPSMSProcessed = T000K5_A140WWPSMSProcessed[0];
            n140WWPSMSProcessed = T000K5_n140WWPSMSProcessed[0];
            AssignAttri("", false, "A140WWPSMSProcessed", context.localUtil.TToC( A140WWPSMSProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A141WWPSMSDetail = T000K5_A141WWPSMSDetail[0];
            n141WWPSMSDetail = T000K5_n141WWPSMSDetail[0];
            AssignAttri("", false, "A141WWPSMSDetail", A141WWPSMSDetail);
            A129WWPNotificationCreated = T000K5_A129WWPNotificationCreated[0];
            AssignAttri("", false, "A129WWPNotificationCreated", context.localUtil.TToC( A129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A127WWPNotificationId = T000K5_A127WWPNotificationId[0];
            n127WWPNotificationId = T000K5_n127WWPNotificationId[0];
            AssignAttri("", false, "A127WWPNotificationId", StringUtil.LTrimStr( (decimal)(A127WWPNotificationId), 10, 0));
            ZM0K30( -5) ;
         }
         pr_default.close(3);
         OnLoadActions0K30( ) ;
      }

      protected void OnLoadActions0K30( )
      {
      }

      protected void CheckExtendedTable0K30( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ! ( ( A139WWPSMSStatus == 1 ) || ( A139WWPSMSStatus == 2 ) || ( A139WWPSMSStatus == 3 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "SMS Status", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "WWPSMSSTATUS");
            AnyError = 1;
            GX_FocusControl = cmbWWPSMSStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000K4 */
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
         A129WWPNotificationCreated = T000K4_A129WWPNotificationCreated[0];
         AssignAttri("", false, "A129WWPNotificationCreated", context.localUtil.TToC( A129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0K30( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_6( long A127WWPNotificationId )
      {
         /* Using cursor T000K6 */
         pr_default.execute(4, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A127WWPNotificationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Notification", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A129WWPNotificationCreated = T000K6_A129WWPNotificationCreated[0];
         AssignAttri("", false, "A129WWPNotificationCreated", context.localUtil.TToC( A129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( context.localUtil.TToC( A129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey0K30( )
      {
         /* Using cursor T000K7 */
         pr_default.execute(5, new Object[] {A138WWPSMSId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound30 = 1;
         }
         else
         {
            RcdFound30 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000K3 */
         pr_default.execute(1, new Object[] {A138WWPSMSId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0K30( 5) ;
            RcdFound30 = 1;
            A138WWPSMSId = T000K3_A138WWPSMSId[0];
            AssignAttri("", false, "A138WWPSMSId", StringUtil.LTrimStr( (decimal)(A138WWPSMSId), 10, 0));
            A142WWPSMSMessage = T000K3_A142WWPSMSMessage[0];
            AssignAttri("", false, "A142WWPSMSMessage", A142WWPSMSMessage);
            A143WWPSMSSenderNumber = T000K3_A143WWPSMSSenderNumber[0];
            AssignAttri("", false, "A143WWPSMSSenderNumber", A143WWPSMSSenderNumber);
            A144WWPSMSRecipientNumbers = T000K3_A144WWPSMSRecipientNumbers[0];
            AssignAttri("", false, "A144WWPSMSRecipientNumbers", A144WWPSMSRecipientNumbers);
            A139WWPSMSStatus = T000K3_A139WWPSMSStatus[0];
            AssignAttri("", false, "A139WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A139WWPSMSStatus), 4, 0));
            A145WWPSMSCreated = T000K3_A145WWPSMSCreated[0];
            AssignAttri("", false, "A145WWPSMSCreated", context.localUtil.TToC( A145WWPSMSCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A146WWPSMSScheduled = T000K3_A146WWPSMSScheduled[0];
            AssignAttri("", false, "A146WWPSMSScheduled", context.localUtil.TToC( A146WWPSMSScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A140WWPSMSProcessed = T000K3_A140WWPSMSProcessed[0];
            n140WWPSMSProcessed = T000K3_n140WWPSMSProcessed[0];
            AssignAttri("", false, "A140WWPSMSProcessed", context.localUtil.TToC( A140WWPSMSProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A141WWPSMSDetail = T000K3_A141WWPSMSDetail[0];
            n141WWPSMSDetail = T000K3_n141WWPSMSDetail[0];
            AssignAttri("", false, "A141WWPSMSDetail", A141WWPSMSDetail);
            A127WWPNotificationId = T000K3_A127WWPNotificationId[0];
            n127WWPNotificationId = T000K3_n127WWPNotificationId[0];
            AssignAttri("", false, "A127WWPNotificationId", StringUtil.LTrimStr( (decimal)(A127WWPNotificationId), 10, 0));
            Z138WWPSMSId = A138WWPSMSId;
            sMode30 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0K30( ) ;
            if ( AnyError == 1 )
            {
               RcdFound30 = 0;
               InitializeNonKey0K30( ) ;
            }
            Gx_mode = sMode30;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound30 = 0;
            InitializeNonKey0K30( ) ;
            sMode30 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode30;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0K30( ) ;
         if ( RcdFound30 == 0 )
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
         RcdFound30 = 0;
         /* Using cursor T000K8 */
         pr_default.execute(6, new Object[] {A138WWPSMSId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000K8_A138WWPSMSId[0] < A138WWPSMSId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000K8_A138WWPSMSId[0] > A138WWPSMSId ) ) )
            {
               A138WWPSMSId = T000K8_A138WWPSMSId[0];
               AssignAttri("", false, "A138WWPSMSId", StringUtil.LTrimStr( (decimal)(A138WWPSMSId), 10, 0));
               RcdFound30 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound30 = 0;
         /* Using cursor T000K9 */
         pr_default.execute(7, new Object[] {A138WWPSMSId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000K9_A138WWPSMSId[0] > A138WWPSMSId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000K9_A138WWPSMSId[0] < A138WWPSMSId ) ) )
            {
               A138WWPSMSId = T000K9_A138WWPSMSId[0];
               AssignAttri("", false, "A138WWPSMSId", StringUtil.LTrimStr( (decimal)(A138WWPSMSId), 10, 0));
               RcdFound30 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0K30( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPSMSId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0K30( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound30 == 1 )
            {
               if ( A138WWPSMSId != Z138WWPSMSId )
               {
                  A138WWPSMSId = Z138WWPSMSId;
                  AssignAttri("", false, "A138WWPSMSId", StringUtil.LTrimStr( (decimal)(A138WWPSMSId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPSMSID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPSMSId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPSMSId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0K30( ) ;
                  GX_FocusControl = edtWWPSMSId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A138WWPSMSId != Z138WWPSMSId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPSMSId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0K30( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPSMSID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPSMSId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPSMSId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0K30( ) ;
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
         if ( A138WWPSMSId != Z138WWPSMSId )
         {
            A138WWPSMSId = Z138WWPSMSId;
            AssignAttri("", false, "A138WWPSMSId", StringUtil.LTrimStr( (decimal)(A138WWPSMSId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPSMSID");
            AnyError = 1;
            GX_FocusControl = edtWWPSMSId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPSMSId_Internalname;
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
         if ( RcdFound30 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPSMSID");
            AnyError = 1;
            GX_FocusControl = edtWWPSMSId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtWWPSMSMessage_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0K30( ) ;
         if ( RcdFound30 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPSMSMessage_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0K30( ) ;
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
         if ( RcdFound30 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPSMSMessage_Internalname;
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
         if ( RcdFound30 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPSMSMessage_Internalname;
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
         ScanStart0K30( ) ;
         if ( RcdFound30 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound30 != 0 )
            {
               ScanNext0K30( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPSMSMessage_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0K30( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0K30( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000K2 */
            pr_default.execute(0, new Object[] {A138WWPSMSId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_SMS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z139WWPSMSStatus != T000K2_A139WWPSMSStatus[0] ) || ( Z145WWPSMSCreated != T000K2_A145WWPSMSCreated[0] ) || ( Z146WWPSMSScheduled != T000K2_A146WWPSMSScheduled[0] ) || ( Z140WWPSMSProcessed != T000K2_A140WWPSMSProcessed[0] ) || ( Z127WWPNotificationId != T000K2_A127WWPNotificationId[0] ) )
            {
               if ( Z139WWPSMSStatus != T000K2_A139WWPSMSStatus[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.sms.wwp_sms:[seudo value changed for attri]"+"WWPSMSStatus");
                  GXUtil.WriteLogRaw("Old: ",Z139WWPSMSStatus);
                  GXUtil.WriteLogRaw("Current: ",T000K2_A139WWPSMSStatus[0]);
               }
               if ( Z145WWPSMSCreated != T000K2_A145WWPSMSCreated[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.sms.wwp_sms:[seudo value changed for attri]"+"WWPSMSCreated");
                  GXUtil.WriteLogRaw("Old: ",Z145WWPSMSCreated);
                  GXUtil.WriteLogRaw("Current: ",T000K2_A145WWPSMSCreated[0]);
               }
               if ( Z146WWPSMSScheduled != T000K2_A146WWPSMSScheduled[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.sms.wwp_sms:[seudo value changed for attri]"+"WWPSMSScheduled");
                  GXUtil.WriteLogRaw("Old: ",Z146WWPSMSScheduled);
                  GXUtil.WriteLogRaw("Current: ",T000K2_A146WWPSMSScheduled[0]);
               }
               if ( Z140WWPSMSProcessed != T000K2_A140WWPSMSProcessed[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.sms.wwp_sms:[seudo value changed for attri]"+"WWPSMSProcessed");
                  GXUtil.WriteLogRaw("Old: ",Z140WWPSMSProcessed);
                  GXUtil.WriteLogRaw("Current: ",T000K2_A140WWPSMSProcessed[0]);
               }
               if ( Z127WWPNotificationId != T000K2_A127WWPNotificationId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.sms.wwp_sms:[seudo value changed for attri]"+"WWPNotificationId");
                  GXUtil.WriteLogRaw("Old: ",Z127WWPNotificationId);
                  GXUtil.WriteLogRaw("Current: ",T000K2_A127WWPNotificationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_SMS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0K30( )
      {
         if ( ! IsAuthorized("sms_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0K30( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0K30( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0K30( 0) ;
            CheckOptimisticConcurrency0K30( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0K30( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0K30( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000K10 */
                     pr_default.execute(8, new Object[] {A142WWPSMSMessage, A143WWPSMSSenderNumber, A144WWPSMSRecipientNumbers, A139WWPSMSStatus, A145WWPSMSCreated, A146WWPSMSScheduled, n140WWPSMSProcessed, A140WWPSMSProcessed, n141WWPSMSDetail, A141WWPSMSDetail, n127WWPNotificationId, A127WWPNotificationId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000K11 */
                     pr_default.execute(9);
                     A138WWPSMSId = T000K11_A138WWPSMSId[0];
                     AssignAttri("", false, "A138WWPSMSId", StringUtil.LTrimStr( (decimal)(A138WWPSMSId), 10, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_SMS");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0K0( ) ;
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
               Load0K30( ) ;
            }
            EndLevel0K30( ) ;
         }
         CloseExtendedTableCursors0K30( ) ;
      }

      protected void Update0K30( )
      {
         if ( ! IsAuthorized("sms_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0K30( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0K30( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0K30( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0K30( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0K30( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000K12 */
                     pr_default.execute(10, new Object[] {A142WWPSMSMessage, A143WWPSMSSenderNumber, A144WWPSMSRecipientNumbers, A139WWPSMSStatus, A145WWPSMSCreated, A146WWPSMSScheduled, n140WWPSMSProcessed, A140WWPSMSProcessed, n141WWPSMSDetail, A141WWPSMSDetail, n127WWPNotificationId, A127WWPNotificationId, A138WWPSMSId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_SMS");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_SMS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0K30( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0K0( ) ;
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
            EndLevel0K30( ) ;
         }
         CloseExtendedTableCursors0K30( ) ;
      }

      protected void DeferredUpdate0K30( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("sms_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0K30( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0K30( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0K30( ) ;
            AfterConfirm0K30( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0K30( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000K13 */
                  pr_default.execute(11, new Object[] {A138WWPSMSId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_SMS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound30 == 0 )
                        {
                           InitAll0K30( ) ;
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
                        ResetCaption0K0( ) ;
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
         sMode30 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0K30( ) ;
         Gx_mode = sMode30;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0K30( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000K14 */
            pr_default.execute(12, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
            A129WWPNotificationCreated = T000K14_A129WWPNotificationCreated[0];
            AssignAttri("", false, "A129WWPNotificationCreated", context.localUtil.TToC( A129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            pr_default.close(12);
         }
      }

      protected void EndLevel0K30( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0K30( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("wwpbaseobjects.sms.wwp_sms",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0K0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("wwpbaseobjects.sms.wwp_sms",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0K30( )
      {
         /* Using cursor T000K15 */
         pr_default.execute(13);
         RcdFound30 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound30 = 1;
            A138WWPSMSId = T000K15_A138WWPSMSId[0];
            AssignAttri("", false, "A138WWPSMSId", StringUtil.LTrimStr( (decimal)(A138WWPSMSId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0K30( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound30 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound30 = 1;
            A138WWPSMSId = T000K15_A138WWPSMSId[0];
            AssignAttri("", false, "A138WWPSMSId", StringUtil.LTrimStr( (decimal)(A138WWPSMSId), 10, 0));
         }
      }

      protected void ScanEnd0K30( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0K30( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0K30( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0K30( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0K30( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0K30( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0K30( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0K30( )
      {
         edtWWPSMSId_Enabled = 0;
         AssignProp("", false, edtWWPSMSId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSId_Enabled), 5, 0), true);
         edtWWPSMSMessage_Enabled = 0;
         AssignProp("", false, edtWWPSMSMessage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSMessage_Enabled), 5, 0), true);
         edtWWPSMSSenderNumber_Enabled = 0;
         AssignProp("", false, edtWWPSMSSenderNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSSenderNumber_Enabled), 5, 0), true);
         edtWWPSMSRecipientNumbers_Enabled = 0;
         AssignProp("", false, edtWWPSMSRecipientNumbers_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSRecipientNumbers_Enabled), 5, 0), true);
         cmbWWPSMSStatus.Enabled = 0;
         AssignProp("", false, cmbWWPSMSStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPSMSStatus.Enabled), 5, 0), true);
         edtWWPSMSCreated_Enabled = 0;
         AssignProp("", false, edtWWPSMSCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSCreated_Enabled), 5, 0), true);
         edtWWPSMSScheduled_Enabled = 0;
         AssignProp("", false, edtWWPSMSScheduled_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSScheduled_Enabled), 5, 0), true);
         edtWWPSMSProcessed_Enabled = 0;
         AssignProp("", false, edtWWPSMSProcessed_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSProcessed_Enabled), 5, 0), true);
         edtWWPSMSDetail_Enabled = 0;
         AssignProp("", false, edtWWPSMSDetail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSDetail_Enabled), 5, 0), true);
         edtWWPNotificationId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationId_Enabled), 5, 0), true);
         edtWWPNotificationCreated_Enabled = 0;
         AssignProp("", false, edtWWPNotificationCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationCreated_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0K30( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0K0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.sms.wwp_sms.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z138WWPSMSId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z138WWPSMSId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z139WWPSMSStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z139WWPSMSStatus), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z145WWPSMSCreated", context.localUtil.TToC( Z145WWPSMSCreated, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z146WWPSMSScheduled", context.localUtil.TToC( Z146WWPSMSScheduled, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z140WWPSMSProcessed", context.localUtil.TToC( Z140WWPSMSProcessed, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z127WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z127WWPNotificationId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         return formatLink("wwpbaseobjects.sms.wwp_sms.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.SMS.WWP_SMS" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WWP_SMS", "") ;
      }

      protected void InitializeNonKey0K30( )
      {
         A142WWPSMSMessage = "";
         AssignAttri("", false, "A142WWPSMSMessage", A142WWPSMSMessage);
         A143WWPSMSSenderNumber = "";
         AssignAttri("", false, "A143WWPSMSSenderNumber", A143WWPSMSSenderNumber);
         A144WWPSMSRecipientNumbers = "";
         AssignAttri("", false, "A144WWPSMSRecipientNumbers", A144WWPSMSRecipientNumbers);
         A140WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         n140WWPSMSProcessed = false;
         AssignAttri("", false, "A140WWPSMSProcessed", context.localUtil.TToC( A140WWPSMSProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         n140WWPSMSProcessed = ((DateTime.MinValue==A140WWPSMSProcessed) ? true : false);
         A141WWPSMSDetail = "";
         n141WWPSMSDetail = false;
         AssignAttri("", false, "A141WWPSMSDetail", A141WWPSMSDetail);
         n141WWPSMSDetail = (String.IsNullOrEmpty(StringUtil.RTrim( A141WWPSMSDetail)) ? true : false);
         A127WWPNotificationId = 0;
         n127WWPNotificationId = false;
         AssignAttri("", false, "A127WWPNotificationId", StringUtil.LTrimStr( (decimal)(A127WWPNotificationId), 10, 0));
         n127WWPNotificationId = ((0==A127WWPNotificationId) ? true : false);
         A129WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A129WWPNotificationCreated", context.localUtil.TToC( A129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A139WWPSMSStatus = 1;
         AssignAttri("", false, "A139WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A139WWPSMSStatus), 4, 0));
         A145WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A145WWPSMSCreated", context.localUtil.TToC( A145WWPSMSCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A146WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A146WWPSMSScheduled", context.localUtil.TToC( A146WWPSMSScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         Z139WWPSMSStatus = 0;
         Z145WWPSMSCreated = (DateTime)(DateTime.MinValue);
         Z146WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         Z140WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         Z127WWPNotificationId = 0;
      }

      protected void InitAll0K30( )
      {
         A138WWPSMSId = 0;
         AssignAttri("", false, "A138WWPSMSId", StringUtil.LTrimStr( (decimal)(A138WWPSMSId), 10, 0));
         InitializeNonKey0K30( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A139WWPSMSStatus = i139WWPSMSStatus;
         AssignAttri("", false, "A139WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A139WWPSMSStatus), 4, 0));
         A145WWPSMSCreated = i145WWPSMSCreated;
         AssignAttri("", false, "A145WWPSMSCreated", context.localUtil.TToC( A145WWPSMSCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A146WWPSMSScheduled = i146WWPSMSScheduled;
         AssignAttri("", false, "A146WWPSMSScheduled", context.localUtil.TToC( A146WWPSMSScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256309402882", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/sms/wwp_sms.js", "?20256309402883", false, true);
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
         edtWWPSMSId_Internalname = "WWPSMSID";
         edtWWPSMSMessage_Internalname = "WWPSMSMESSAGE";
         edtWWPSMSSenderNumber_Internalname = "WWPSMSSENDERNUMBER";
         edtWWPSMSRecipientNumbers_Internalname = "WWPSMSRECIPIENTNUMBERS";
         cmbWWPSMSStatus_Internalname = "WWPSMSSTATUS";
         edtWWPSMSCreated_Internalname = "WWPSMSCREATED";
         edtWWPSMSScheduled_Internalname = "WWPSMSSCHEDULED";
         edtWWPSMSProcessed_Internalname = "WWPSMSPROCESSED";
         edtWWPSMSDetail_Internalname = "WWPSMSDETAIL";
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID";
         edtWWPNotificationCreated_Internalname = "WWPNOTIFICATIONCREATED";
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
         Form.Caption = context.GetMessage( "WWP_SMS", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtWWPNotificationCreated_Jsonclick = "";
         edtWWPNotificationCreated_Enabled = 0;
         edtWWPNotificationId_Jsonclick = "";
         edtWWPNotificationId_Enabled = 1;
         edtWWPSMSDetail_Enabled = 1;
         edtWWPSMSProcessed_Jsonclick = "";
         edtWWPSMSProcessed_Enabled = 1;
         edtWWPSMSScheduled_Jsonclick = "";
         edtWWPSMSScheduled_Enabled = 1;
         edtWWPSMSCreated_Jsonclick = "";
         edtWWPSMSCreated_Enabled = 1;
         cmbWWPSMSStatus_Jsonclick = "";
         cmbWWPSMSStatus.Enabled = 1;
         edtWWPSMSRecipientNumbers_Enabled = 1;
         edtWWPSMSSenderNumber_Enabled = 1;
         edtWWPSMSMessage_Enabled = 1;
         edtWWPSMSId_Jsonclick = "";
         edtWWPSMSId_Enabled = 1;
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
         cmbWWPSMSStatus.Name = "WWPSMSSTATUS";
         cmbWWPSMSStatus.WebTags = "";
         cmbWWPSMSStatus.addItem("1", context.GetMessage( "Pending", ""), 0);
         cmbWWPSMSStatus.addItem("2", context.GetMessage( "Sent", ""), 0);
         cmbWWPSMSStatus.addItem("3", context.GetMessage( "Error", ""), 0);
         if ( cmbWWPSMSStatus.ItemCount > 0 )
         {
            if ( IsIns( ) && (0==A139WWPSMSStatus) )
            {
               A139WWPSMSStatus = 1;
               AssignAttri("", false, "A139WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A139WWPSMSStatus), 4, 0));
            }
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtWWPSMSMessage_Internalname;
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

      public void Valid_Wwpsmsid( )
      {
         A139WWPSMSStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPSMSStatus.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbWWPSMSStatus.CurrentValue = StringUtil.LTrimStr( (decimal)(A139WWPSMSStatus), 4, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbWWPSMSStatus.ItemCount > 0 )
         {
            A139WWPSMSStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPSMSStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A139WWPSMSStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
            cmbWWPSMSStatus.CurrentValue = StringUtil.LTrimStr( (decimal)(A139WWPSMSStatus), 4, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPSMSStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A139WWPSMSStatus), 4, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A142WWPSMSMessage", A142WWPSMSMessage);
         AssignAttri("", false, "A143WWPSMSSenderNumber", A143WWPSMSSenderNumber);
         AssignAttri("", false, "A144WWPSMSRecipientNumbers", A144WWPSMSRecipientNumbers);
         AssignAttri("", false, "A139WWPSMSStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(A139WWPSMSStatus), 4, 0, ".", "")));
         cmbWWPSMSStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A139WWPSMSStatus), 4, 0));
         AssignProp("", false, cmbWWPSMSStatus_Internalname, "Values", cmbWWPSMSStatus.ToJavascriptSource(), true);
         AssignAttri("", false, "A145WWPSMSCreated", context.localUtil.TToC( A145WWPSMSCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A146WWPSMSScheduled", context.localUtil.TToC( A146WWPSMSScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A140WWPSMSProcessed", context.localUtil.TToC( A140WWPSMSProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A141WWPSMSDetail", A141WWPSMSDetail);
         AssignAttri("", false, "A127WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A127WWPNotificationId), 10, 0, ".", "")));
         AssignAttri("", false, "A129WWPNotificationCreated", context.localUtil.TToC( A129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z138WWPSMSId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z138WWPSMSId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z142WWPSMSMessage", Z142WWPSMSMessage);
         GxWebStd.gx_hidden_field( context, "Z143WWPSMSSenderNumber", Z143WWPSMSSenderNumber);
         GxWebStd.gx_hidden_field( context, "Z144WWPSMSRecipientNumbers", Z144WWPSMSRecipientNumbers);
         GxWebStd.gx_hidden_field( context, "Z139WWPSMSStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z139WWPSMSStatus), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z145WWPSMSCreated", context.localUtil.TToC( Z145WWPSMSCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z146WWPSMSScheduled", context.localUtil.TToC( Z146WWPSMSScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z140WWPSMSProcessed", context.localUtil.TToC( Z140WWPSMSProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z141WWPSMSDetail", Z141WWPSMSDetail);
         GxWebStd.gx_hidden_field( context, "Z127WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z127WWPNotificationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z129WWPNotificationCreated", context.localUtil.TToC( Z129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpnotificationid( )
      {
         n127WWPNotificationId = false;
         /* Using cursor T000K14 */
         pr_default.execute(12, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            if ( ! ( (0==A127WWPNotificationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Notification", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
            }
         }
         A129WWPNotificationCreated = T000K14_A129WWPNotificationCreated[0];
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A129WWPNotificationCreated", context.localUtil.TToC( A129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("VALID_WWPSMSID","""{"handler":"Valid_Wwpsmsid","iparms":[{"av":"A138WWPSMSId","fld":"WWPSMSID","pic":"ZZZZZZZZZ9"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"cmbWWPSMSStatus"},{"av":"A139WWPSMSStatus","fld":"WWPSMSSTATUS","pic":"ZZZ9"},{"av":"A145WWPSMSCreated","fld":"WWPSMSCREATED","pic":"99/99/9999 99:99:99.999"},{"av":"A146WWPSMSScheduled","fld":"WWPSMSSCHEDULED","pic":"99/99/9999 99:99:99.999"}]""");
         setEventMetadata("VALID_WWPSMSID",""","oparms":[{"av":"A142WWPSMSMessage","fld":"WWPSMSMESSAGE"},{"av":"A143WWPSMSSenderNumber","fld":"WWPSMSSENDERNUMBER"},{"av":"A144WWPSMSRecipientNumbers","fld":"WWPSMSRECIPIENTNUMBERS"},{"av":"cmbWWPSMSStatus"},{"av":"A139WWPSMSStatus","fld":"WWPSMSSTATUS","pic":"ZZZ9"},{"av":"A145WWPSMSCreated","fld":"WWPSMSCREATED","pic":"99/99/9999 99:99:99.999"},{"av":"A146WWPSMSScheduled","fld":"WWPSMSSCHEDULED","pic":"99/99/9999 99:99:99.999"},{"av":"A140WWPSMSProcessed","fld":"WWPSMSPROCESSED","pic":"99/99/9999 99:99:99.999"},{"av":"A141WWPSMSDetail","fld":"WWPSMSDETAIL"},{"av":"A127WWPNotificationId","fld":"WWPNOTIFICATIONID","pic":"ZZZZZZZZZ9"},{"av":"A129WWPNotificationCreated","fld":"WWPNOTIFICATIONCREATED","pic":"99/99/9999 99:99:99.999"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z138WWPSMSId"},{"av":"Z142WWPSMSMessage"},{"av":"Z143WWPSMSSenderNumber"},{"av":"Z144WWPSMSRecipientNumbers"},{"av":"Z139WWPSMSStatus"},{"av":"Z145WWPSMSCreated"},{"av":"Z146WWPSMSScheduled"},{"av":"Z140WWPSMSProcessed"},{"av":"Z141WWPSMSDetail"},{"av":"Z127WWPNotificationId"},{"av":"Z129WWPNotificationCreated"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_WWPSMSSTATUS","""{"handler":"Valid_Wwpsmsstatus","iparms":[]}""");
         setEventMetadata("VALID_WWPNOTIFICATIONID","""{"handler":"Valid_Wwpnotificationid","iparms":[{"av":"A127WWPNotificationId","fld":"WWPNOTIFICATIONID","pic":"ZZZZZZZZZ9"},{"av":"A129WWPNotificationCreated","fld":"WWPNOTIFICATIONCREATED","pic":"99/99/9999 99:99:99.999"}]""");
         setEventMetadata("VALID_WWPNOTIFICATIONID",""","oparms":[{"av":"A129WWPNotificationCreated","fld":"WWPNOTIFICATIONCREATED","pic":"99/99/9999 99:99:99.999"}]}""");
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z145WWPSMSCreated = (DateTime)(DateTime.MinValue);
         Z146WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         Z140WWPSMSProcessed = (DateTime)(DateTime.MinValue);
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
         A142WWPSMSMessage = "";
         A143WWPSMSSenderNumber = "";
         A144WWPSMSRecipientNumbers = "";
         A145WWPSMSCreated = (DateTime)(DateTime.MinValue);
         A146WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         A140WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         A141WWPSMSDetail = "";
         A129WWPNotificationCreated = (DateTime)(DateTime.MinValue);
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
         Z142WWPSMSMessage = "";
         Z143WWPSMSSenderNumber = "";
         Z144WWPSMSRecipientNumbers = "";
         Z141WWPSMSDetail = "";
         Z129WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         T000K5_A138WWPSMSId = new long[1] ;
         T000K5_A142WWPSMSMessage = new string[] {""} ;
         T000K5_A143WWPSMSSenderNumber = new string[] {""} ;
         T000K5_A144WWPSMSRecipientNumbers = new string[] {""} ;
         T000K5_A139WWPSMSStatus = new short[1] ;
         T000K5_A145WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         T000K5_A146WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         T000K5_A140WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         T000K5_n140WWPSMSProcessed = new bool[] {false} ;
         T000K5_A141WWPSMSDetail = new string[] {""} ;
         T000K5_n141WWPSMSDetail = new bool[] {false} ;
         T000K5_A129WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000K5_A127WWPNotificationId = new long[1] ;
         T000K5_n127WWPNotificationId = new bool[] {false} ;
         T000K4_A129WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000K6_A129WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000K7_A138WWPSMSId = new long[1] ;
         T000K3_A138WWPSMSId = new long[1] ;
         T000K3_A142WWPSMSMessage = new string[] {""} ;
         T000K3_A143WWPSMSSenderNumber = new string[] {""} ;
         T000K3_A144WWPSMSRecipientNumbers = new string[] {""} ;
         T000K3_A139WWPSMSStatus = new short[1] ;
         T000K3_A145WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         T000K3_A146WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         T000K3_A140WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         T000K3_n140WWPSMSProcessed = new bool[] {false} ;
         T000K3_A141WWPSMSDetail = new string[] {""} ;
         T000K3_n141WWPSMSDetail = new bool[] {false} ;
         T000K3_A127WWPNotificationId = new long[1] ;
         T000K3_n127WWPNotificationId = new bool[] {false} ;
         sMode30 = "";
         T000K8_A138WWPSMSId = new long[1] ;
         T000K9_A138WWPSMSId = new long[1] ;
         T000K2_A138WWPSMSId = new long[1] ;
         T000K2_A142WWPSMSMessage = new string[] {""} ;
         T000K2_A143WWPSMSSenderNumber = new string[] {""} ;
         T000K2_A144WWPSMSRecipientNumbers = new string[] {""} ;
         T000K2_A139WWPSMSStatus = new short[1] ;
         T000K2_A145WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         T000K2_A146WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         T000K2_A140WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         T000K2_n140WWPSMSProcessed = new bool[] {false} ;
         T000K2_A141WWPSMSDetail = new string[] {""} ;
         T000K2_n141WWPSMSDetail = new bool[] {false} ;
         T000K2_A127WWPNotificationId = new long[1] ;
         T000K2_n127WWPNotificationId = new bool[] {false} ;
         T000K11_A138WWPSMSId = new long[1] ;
         T000K14_A129WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000K15_A138WWPSMSId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i145WWPSMSCreated = (DateTime)(DateTime.MinValue);
         i146WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         ZZ142WWPSMSMessage = "";
         ZZ143WWPSMSSenderNumber = "";
         ZZ144WWPSMSRecipientNumbers = "";
         ZZ145WWPSMSCreated = (DateTime)(DateTime.MinValue);
         ZZ146WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         ZZ140WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         ZZ141WWPSMSDetail = "";
         ZZ129WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.sms.wwp_sms__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.sms.wwp_sms__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.sms.wwp_sms__default(),
            new Object[][] {
                new Object[] {
               T000K2_A138WWPSMSId, T000K2_A142WWPSMSMessage, T000K2_A143WWPSMSSenderNumber, T000K2_A144WWPSMSRecipientNumbers, T000K2_A139WWPSMSStatus, T000K2_A145WWPSMSCreated, T000K2_A146WWPSMSScheduled, T000K2_A140WWPSMSProcessed, T000K2_n140WWPSMSProcessed, T000K2_A141WWPSMSDetail,
               T000K2_n141WWPSMSDetail, T000K2_A127WWPNotificationId, T000K2_n127WWPNotificationId
               }
               , new Object[] {
               T000K3_A138WWPSMSId, T000K3_A142WWPSMSMessage, T000K3_A143WWPSMSSenderNumber, T000K3_A144WWPSMSRecipientNumbers, T000K3_A139WWPSMSStatus, T000K3_A145WWPSMSCreated, T000K3_A146WWPSMSScheduled, T000K3_A140WWPSMSProcessed, T000K3_n140WWPSMSProcessed, T000K3_A141WWPSMSDetail,
               T000K3_n141WWPSMSDetail, T000K3_A127WWPNotificationId, T000K3_n127WWPNotificationId
               }
               , new Object[] {
               T000K4_A129WWPNotificationCreated
               }
               , new Object[] {
               T000K5_A138WWPSMSId, T000K5_A142WWPSMSMessage, T000K5_A143WWPSMSSenderNumber, T000K5_A144WWPSMSRecipientNumbers, T000K5_A139WWPSMSStatus, T000K5_A145WWPSMSCreated, T000K5_A146WWPSMSScheduled, T000K5_A140WWPSMSProcessed, T000K5_n140WWPSMSProcessed, T000K5_A141WWPSMSDetail,
               T000K5_n141WWPSMSDetail, T000K5_A129WWPNotificationCreated, T000K5_A127WWPNotificationId, T000K5_n127WWPNotificationId
               }
               , new Object[] {
               T000K6_A129WWPNotificationCreated
               }
               , new Object[] {
               T000K7_A138WWPSMSId
               }
               , new Object[] {
               T000K8_A138WWPSMSId
               }
               , new Object[] {
               T000K9_A138WWPSMSId
               }
               , new Object[] {
               }
               , new Object[] {
               T000K11_A138WWPSMSId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000K14_A129WWPNotificationCreated
               }
               , new Object[] {
               T000K15_A138WWPSMSId
               }
            }
         );
         Z146WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         A146WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         i146WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z145WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A145WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i145WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z139WWPSMSStatus = 1;
         A139WWPSMSStatus = 1;
         i139WWPSMSStatus = 1;
      }

      private short Z139WWPSMSStatus ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A139WWPSMSStatus ;
      private short Gx_BScreen ;
      private short RcdFound30 ;
      private short gxajaxcallmode ;
      private short i139WWPSMSStatus ;
      private short ZZ139WWPSMSStatus ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPSMSId_Enabled ;
      private int edtWWPSMSMessage_Enabled ;
      private int edtWWPSMSSenderNumber_Enabled ;
      private int edtWWPSMSRecipientNumbers_Enabled ;
      private int edtWWPSMSCreated_Enabled ;
      private int edtWWPSMSScheduled_Enabled ;
      private int edtWWPSMSProcessed_Enabled ;
      private int edtWWPSMSDetail_Enabled ;
      private int edtWWPNotificationId_Enabled ;
      private int edtWWPNotificationCreated_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z138WWPSMSId ;
      private long Z127WWPNotificationId ;
      private long A127WWPNotificationId ;
      private long A138WWPSMSId ;
      private long ZZ138WWPSMSId ;
      private long ZZ127WWPNotificationId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPSMSId_Internalname ;
      private string cmbWWPSMSStatus_Internalname ;
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
      private string edtWWPSMSId_Jsonclick ;
      private string edtWWPSMSMessage_Internalname ;
      private string edtWWPSMSSenderNumber_Internalname ;
      private string edtWWPSMSRecipientNumbers_Internalname ;
      private string cmbWWPSMSStatus_Jsonclick ;
      private string edtWWPSMSCreated_Internalname ;
      private string edtWWPSMSCreated_Jsonclick ;
      private string edtWWPSMSScheduled_Internalname ;
      private string edtWWPSMSScheduled_Jsonclick ;
      private string edtWWPSMSProcessed_Internalname ;
      private string edtWWPSMSProcessed_Jsonclick ;
      private string edtWWPSMSDetail_Internalname ;
      private string edtWWPNotificationId_Internalname ;
      private string edtWWPNotificationId_Jsonclick ;
      private string edtWWPNotificationCreated_Internalname ;
      private string edtWWPNotificationCreated_Jsonclick ;
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
      private string sMode30 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z145WWPSMSCreated ;
      private DateTime Z146WWPSMSScheduled ;
      private DateTime Z140WWPSMSProcessed ;
      private DateTime A145WWPSMSCreated ;
      private DateTime A146WWPSMSScheduled ;
      private DateTime A140WWPSMSProcessed ;
      private DateTime A129WWPNotificationCreated ;
      private DateTime Z129WWPNotificationCreated ;
      private DateTime i145WWPSMSCreated ;
      private DateTime i146WWPSMSScheduled ;
      private DateTime ZZ145WWPSMSCreated ;
      private DateTime ZZ146WWPSMSScheduled ;
      private DateTime ZZ140WWPSMSProcessed ;
      private DateTime ZZ129WWPNotificationCreated ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n127WWPNotificationId ;
      private bool wbErr ;
      private bool n140WWPSMSProcessed ;
      private bool n141WWPSMSDetail ;
      private string A142WWPSMSMessage ;
      private string A143WWPSMSSenderNumber ;
      private string A144WWPSMSRecipientNumbers ;
      private string A141WWPSMSDetail ;
      private string Z142WWPSMSMessage ;
      private string Z143WWPSMSSenderNumber ;
      private string Z144WWPSMSRecipientNumbers ;
      private string Z141WWPSMSDetail ;
      private string ZZ142WWPSMSMessage ;
      private string ZZ143WWPSMSSenderNumber ;
      private string ZZ144WWPSMSRecipientNumbers ;
      private string ZZ141WWPSMSDetail ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbWWPSMSStatus ;
      private IDataStoreProvider pr_default ;
      private long[] T000K5_A138WWPSMSId ;
      private string[] T000K5_A142WWPSMSMessage ;
      private string[] T000K5_A143WWPSMSSenderNumber ;
      private string[] T000K5_A144WWPSMSRecipientNumbers ;
      private short[] T000K5_A139WWPSMSStatus ;
      private DateTime[] T000K5_A145WWPSMSCreated ;
      private DateTime[] T000K5_A146WWPSMSScheduled ;
      private DateTime[] T000K5_A140WWPSMSProcessed ;
      private bool[] T000K5_n140WWPSMSProcessed ;
      private string[] T000K5_A141WWPSMSDetail ;
      private bool[] T000K5_n141WWPSMSDetail ;
      private DateTime[] T000K5_A129WWPNotificationCreated ;
      private long[] T000K5_A127WWPNotificationId ;
      private bool[] T000K5_n127WWPNotificationId ;
      private DateTime[] T000K4_A129WWPNotificationCreated ;
      private DateTime[] T000K6_A129WWPNotificationCreated ;
      private long[] T000K7_A138WWPSMSId ;
      private long[] T000K3_A138WWPSMSId ;
      private string[] T000K3_A142WWPSMSMessage ;
      private string[] T000K3_A143WWPSMSSenderNumber ;
      private string[] T000K3_A144WWPSMSRecipientNumbers ;
      private short[] T000K3_A139WWPSMSStatus ;
      private DateTime[] T000K3_A145WWPSMSCreated ;
      private DateTime[] T000K3_A146WWPSMSScheduled ;
      private DateTime[] T000K3_A140WWPSMSProcessed ;
      private bool[] T000K3_n140WWPSMSProcessed ;
      private string[] T000K3_A141WWPSMSDetail ;
      private bool[] T000K3_n141WWPSMSDetail ;
      private long[] T000K3_A127WWPNotificationId ;
      private bool[] T000K3_n127WWPNotificationId ;
      private long[] T000K8_A138WWPSMSId ;
      private long[] T000K9_A138WWPSMSId ;
      private long[] T000K2_A138WWPSMSId ;
      private string[] T000K2_A142WWPSMSMessage ;
      private string[] T000K2_A143WWPSMSSenderNumber ;
      private string[] T000K2_A144WWPSMSRecipientNumbers ;
      private short[] T000K2_A139WWPSMSStatus ;
      private DateTime[] T000K2_A145WWPSMSCreated ;
      private DateTime[] T000K2_A146WWPSMSScheduled ;
      private DateTime[] T000K2_A140WWPSMSProcessed ;
      private bool[] T000K2_n140WWPSMSProcessed ;
      private string[] T000K2_A141WWPSMSDetail ;
      private bool[] T000K2_n141WWPSMSDetail ;
      private long[] T000K2_A127WWPNotificationId ;
      private bool[] T000K2_n127WWPNotificationId ;
      private long[] T000K11_A138WWPSMSId ;
      private DateTime[] T000K14_A129WWPNotificationCreated ;
      private long[] T000K15_A138WWPSMSId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_sms__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_sms__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_sms__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[9])
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
       Object[] prmT000K2;
       prmT000K2 = new Object[] {
       new ParDef("WWPSMSId",GXType.Int64,10,0)
       };
       Object[] prmT000K3;
       prmT000K3 = new Object[] {
       new ParDef("WWPSMSId",GXType.Int64,10,0)
       };
       Object[] prmT000K4;
       prmT000K4 = new Object[] {
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmT000K5;
       prmT000K5 = new Object[] {
       new ParDef("WWPSMSId",GXType.Int64,10,0)
       };
       Object[] prmT000K6;
       prmT000K6 = new Object[] {
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmT000K7;
       prmT000K7 = new Object[] {
       new ParDef("WWPSMSId",GXType.Int64,10,0)
       };
       Object[] prmT000K8;
       prmT000K8 = new Object[] {
       new ParDef("WWPSMSId",GXType.Int64,10,0)
       };
       Object[] prmT000K9;
       prmT000K9 = new Object[] {
       new ParDef("WWPSMSId",GXType.Int64,10,0)
       };
       Object[] prmT000K10;
       prmT000K10 = new Object[] {
       new ParDef("WWPSMSMessage",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPSMSSenderNumber",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPSMSRecipientNumbers",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPSMSStatus",GXType.Int16,4,0) ,
       new ParDef("WWPSMSCreated",GXType.DateTime2,10,12) ,
       new ParDef("WWPSMSScheduled",GXType.DateTime2,10,12) ,
       new ParDef("WWPSMSProcessed",GXType.DateTime2,10,12){Nullable=true} ,
       new ParDef("WWPSMSDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmT000K11;
       prmT000K11 = new Object[] {
       };
       Object[] prmT000K12;
       prmT000K12 = new Object[] {
       new ParDef("WWPSMSMessage",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPSMSSenderNumber",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPSMSRecipientNumbers",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPSMSStatus",GXType.Int16,4,0) ,
       new ParDef("WWPSMSCreated",GXType.DateTime2,10,12) ,
       new ParDef("WWPSMSScheduled",GXType.DateTime2,10,12) ,
       new ParDef("WWPSMSProcessed",GXType.DateTime2,10,12){Nullable=true} ,
       new ParDef("WWPSMSDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true} ,
       new ParDef("WWPSMSId",GXType.Int64,10,0)
       };
       Object[] prmT000K13;
       prmT000K13 = new Object[] {
       new ParDef("WWPSMSId",GXType.Int64,10,0)
       };
       Object[] prmT000K14;
       prmT000K14 = new Object[] {
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmT000K15;
       prmT000K15 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T000K2", "SELECT WWPSMSId, WWPSMSMessage, WWPSMSSenderNumber, WWPSMSRecipientNumbers, WWPSMSStatus, WWPSMSCreated, WWPSMSScheduled, WWPSMSProcessed, WWPSMSDetail, WWPNotificationId FROM WWP_SMS WHERE WWPSMSId = :WWPSMSId  FOR UPDATE OF WWP_SMS NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000K2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000K3", "SELECT WWPSMSId, WWPSMSMessage, WWPSMSSenderNumber, WWPSMSRecipientNumbers, WWPSMSStatus, WWPSMSCreated, WWPSMSScheduled, WWPSMSProcessed, WWPSMSDetail, WWPNotificationId FROM WWP_SMS WHERE WWPSMSId = :WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000K4", "SELECT WWPNotificationCreated FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000K5", "SELECT TM1.WWPSMSId, TM1.WWPSMSMessage, TM1.WWPSMSSenderNumber, TM1.WWPSMSRecipientNumbers, TM1.WWPSMSStatus, TM1.WWPSMSCreated, TM1.WWPSMSScheduled, TM1.WWPSMSProcessed, TM1.WWPSMSDetail, T2.WWPNotificationCreated, TM1.WWPNotificationId FROM (WWP_SMS TM1 LEFT JOIN WWP_Notification T2 ON T2.WWPNotificationId = TM1.WWPNotificationId) WHERE TM1.WWPSMSId = :WWPSMSId ORDER BY TM1.WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K5,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000K6", "SELECT WWPNotificationCreated FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000K7", "SELECT WWPSMSId FROM WWP_SMS WHERE WWPSMSId = :WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000K8", "SELECT WWPSMSId FROM WWP_SMS WHERE ( WWPSMSId > :WWPSMSId) ORDER BY WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K8,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000K9", "SELECT WWPSMSId FROM WWP_SMS WHERE ( WWPSMSId < :WWPSMSId) ORDER BY WWPSMSId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K9,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000K10", "SAVEPOINT gxupdate;INSERT INTO WWP_SMS(WWPSMSMessage, WWPSMSSenderNumber, WWPSMSRecipientNumbers, WWPSMSStatus, WWPSMSCreated, WWPSMSScheduled, WWPSMSProcessed, WWPSMSDetail, WWPNotificationId) VALUES(:WWPSMSMessage, :WWPSMSSenderNumber, :WWPSMSRecipientNumbers, :WWPSMSStatus, :WWPSMSCreated, :WWPSMSScheduled, :WWPSMSProcessed, :WWPSMSDetail, :WWPNotificationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000K10)
          ,new CursorDef("T000K11", "SELECT currval('WWPSMSId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K11,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000K12", "SAVEPOINT gxupdate;UPDATE WWP_SMS SET WWPSMSMessage=:WWPSMSMessage, WWPSMSSenderNumber=:WWPSMSSenderNumber, WWPSMSRecipientNumbers=:WWPSMSRecipientNumbers, WWPSMSStatus=:WWPSMSStatus, WWPSMSCreated=:WWPSMSCreated, WWPSMSScheduled=:WWPSMSScheduled, WWPSMSProcessed=:WWPSMSProcessed, WWPSMSDetail=:WWPSMSDetail, WWPNotificationId=:WWPNotificationId  WHERE WWPSMSId = :WWPSMSId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000K12)
          ,new CursorDef("T000K13", "SAVEPOINT gxupdate;DELETE FROM WWP_SMS  WHERE WWPSMSId = :WWPSMSId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000K13)
          ,new CursorDef("T000K14", "SELECT WWPNotificationCreated FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K14,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000K15", "SELECT WWPSMSId FROM WWP_SMS ORDER BY WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K15,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
             ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
             ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
             ((bool[]) buf[8])[0] = rslt.wasNull(8);
             ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
             ((bool[]) buf[10])[0] = rslt.wasNull(9);
             ((long[]) buf[11])[0] = rslt.getLong(10);
             ((bool[]) buf[12])[0] = rslt.wasNull(10);
             return;
          case 1 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
             ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
             ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
             ((bool[]) buf[8])[0] = rslt.wasNull(8);
             ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
             ((bool[]) buf[10])[0] = rslt.wasNull(9);
             ((long[]) buf[11])[0] = rslt.getLong(10);
             ((bool[]) buf[12])[0] = rslt.wasNull(10);
             return;
          case 2 :
             ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
             return;
          case 3 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
             ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
             ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
             ((bool[]) buf[8])[0] = rslt.wasNull(8);
             ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
             ((bool[]) buf[10])[0] = rslt.wasNull(9);
             ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(10, true);
             ((long[]) buf[12])[0] = rslt.getLong(11);
             ((bool[]) buf[13])[0] = rslt.wasNull(11);
             return;
          case 4 :
             ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
             return;
          case 5 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 6 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 7 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 9 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 12 :
             ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
             return;
          case 13 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
    }
 }

}

}
