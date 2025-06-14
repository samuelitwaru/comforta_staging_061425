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
   public class trn_device : GXDataArea
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
         Form.Meta.addItem("description", context.GetMessage( "Trn_Device", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtDeviceId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_device( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_device( IGxContext context )
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
         cmbDeviceType = new GXCombobox();
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
            return "trn_device_Execute" ;
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
         if ( cmbDeviceType.ItemCount > 0 )
         {
            A334DeviceType = (short)(Math.Round(NumberUtil.Val( cmbDeviceType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A334DeviceType), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A334DeviceType", StringUtil.Str( (decimal)(A334DeviceType), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbDeviceType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A334DeviceType), 1, 0));
            AssignProp("", false, cmbDeviceType_Internalname, "Values", cmbDeviceType.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Trn_Device", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Trn_Device.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Device.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Device.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Device.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Device.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Trn_Device.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDeviceId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDeviceId_Internalname, context.GetMessage( "Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDeviceId_Internalname, StringUtil.RTrim( A333DeviceId), StringUtil.RTrim( context.localUtil.Format( A333DeviceId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDeviceId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDeviceId_Enabled, 0, "text", "", 80, "chr", 1, "row", 128, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Device.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbDeviceType_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbDeviceType_Internalname, context.GetMessage( "Type", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbDeviceType, cmbDeviceType_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A334DeviceType), 1, 0)), 1, cmbDeviceType_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbDeviceType.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", true, 0, "HLP_Trn_Device.htm");
         cmbDeviceType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A334DeviceType), 1, 0));
         AssignProp("", false, cmbDeviceType_Internalname, "Values", (string)(cmbDeviceType.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDeviceToken_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDeviceToken_Internalname, context.GetMessage( "Token", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtDeviceToken_Internalname, StringUtil.RTrim( A335DeviceToken), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtDeviceToken_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_Device.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDeviceName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDeviceName_Internalname, context.GetMessage( "Name", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDeviceName_Internalname, StringUtil.RTrim( A336DeviceName), StringUtil.RTrim( context.localUtil.Format( A336DeviceName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDeviceName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDeviceName_Enabled, 0, "text", "", 80, "chr", 1, "row", 128, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Device.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDeviceUserId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDeviceUserId_Internalname, context.GetMessage( "User Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDeviceUserId_Internalname, A337DeviceUserId, StringUtil.RTrim( context.localUtil.Format( A337DeviceUserId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDeviceUserId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDeviceUserId_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_Trn_Device.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Device.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Device.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Device.htm");
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
            Z333DeviceId = cgiGet( "Z333DeviceId");
            Z334DeviceType = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z334DeviceType"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z335DeviceToken = cgiGet( "Z335DeviceToken");
            Z336DeviceName = cgiGet( "Z336DeviceName");
            Z337DeviceUserId = cgiGet( "Z337DeviceUserId");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A333DeviceId = cgiGet( edtDeviceId_Internalname);
            AssignAttri("", false, "A333DeviceId", A333DeviceId);
            cmbDeviceType.CurrentValue = cgiGet( cmbDeviceType_Internalname);
            A334DeviceType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbDeviceType_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A334DeviceType", StringUtil.Str( (decimal)(A334DeviceType), 1, 0));
            A335DeviceToken = cgiGet( edtDeviceToken_Internalname);
            AssignAttri("", false, "A335DeviceToken", A335DeviceToken);
            A336DeviceName = cgiGet( edtDeviceName_Internalname);
            AssignAttri("", false, "A336DeviceName", A336DeviceName);
            A337DeviceUserId = cgiGet( edtDeviceUserId_Internalname);
            AssignAttri("", false, "A337DeviceUserId", A337DeviceUserId);
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
               A333DeviceId = GetPar( "DeviceId");
               AssignAttri("", false, "A333DeviceId", A333DeviceId);
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
               InitAll1367( ) ;
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
         DisableAttributes1367( ) ;
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

      protected void ResetCaption130( )
      {
      }

      protected void ZM1367( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z334DeviceType = T00133_A334DeviceType[0];
               Z335DeviceToken = T00133_A335DeviceToken[0];
               Z336DeviceName = T00133_A336DeviceName[0];
               Z337DeviceUserId = T00133_A337DeviceUserId[0];
            }
            else
            {
               Z334DeviceType = A334DeviceType;
               Z335DeviceToken = A335DeviceToken;
               Z336DeviceName = A336DeviceName;
               Z337DeviceUserId = A337DeviceUserId;
            }
         }
         if ( GX_JID == -2 )
         {
            Z333DeviceId = A333DeviceId;
            Z334DeviceType = A334DeviceType;
            Z335DeviceToken = A335DeviceToken;
            Z336DeviceName = A336DeviceName;
            Z337DeviceUserId = A337DeviceUserId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
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

      protected void Load1367( )
      {
         /* Using cursor T00134 */
         pr_default.execute(2, new Object[] {A333DeviceId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound67 = 1;
            A334DeviceType = T00134_A334DeviceType[0];
            AssignAttri("", false, "A334DeviceType", StringUtil.Str( (decimal)(A334DeviceType), 1, 0));
            A335DeviceToken = T00134_A335DeviceToken[0];
            AssignAttri("", false, "A335DeviceToken", A335DeviceToken);
            A336DeviceName = T00134_A336DeviceName[0];
            AssignAttri("", false, "A336DeviceName", A336DeviceName);
            A337DeviceUserId = T00134_A337DeviceUserId[0];
            AssignAttri("", false, "A337DeviceUserId", A337DeviceUserId);
            ZM1367( -2) ;
         }
         pr_default.close(2);
         OnLoadActions1367( ) ;
      }

      protected void OnLoadActions1367( )
      {
      }

      protected void CheckExtendedTable1367( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( ( A334DeviceType == 0 ) || ( A334DeviceType == 1 ) || ( A334DeviceType == 2 ) || ( A334DeviceType == 3 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Device Type", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "DEVICETYPE");
            AnyError = 1;
            GX_FocusControl = cmbDeviceType_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1367( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1367( )
      {
         /* Using cursor T00135 */
         pr_default.execute(3, new Object[] {A333DeviceId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound67 = 1;
         }
         else
         {
            RcdFound67 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00133 */
         pr_default.execute(1, new Object[] {A333DeviceId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1367( 2) ;
            RcdFound67 = 1;
            A333DeviceId = T00133_A333DeviceId[0];
            AssignAttri("", false, "A333DeviceId", A333DeviceId);
            A334DeviceType = T00133_A334DeviceType[0];
            AssignAttri("", false, "A334DeviceType", StringUtil.Str( (decimal)(A334DeviceType), 1, 0));
            A335DeviceToken = T00133_A335DeviceToken[0];
            AssignAttri("", false, "A335DeviceToken", A335DeviceToken);
            A336DeviceName = T00133_A336DeviceName[0];
            AssignAttri("", false, "A336DeviceName", A336DeviceName);
            A337DeviceUserId = T00133_A337DeviceUserId[0];
            AssignAttri("", false, "A337DeviceUserId", A337DeviceUserId);
            Z333DeviceId = A333DeviceId;
            sMode67 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1367( ) ;
            if ( AnyError == 1 )
            {
               RcdFound67 = 0;
               InitializeNonKey1367( ) ;
            }
            Gx_mode = sMode67;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound67 = 0;
            InitializeNonKey1367( ) ;
            sMode67 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode67;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1367( ) ;
         if ( RcdFound67 == 0 )
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
         RcdFound67 = 0;
         /* Using cursor T00136 */
         pr_default.execute(4, new Object[] {A333DeviceId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00136_A333DeviceId[0], A333DeviceId) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00136_A333DeviceId[0], A333DeviceId) > 0 ) ) )
            {
               A333DeviceId = T00136_A333DeviceId[0];
               AssignAttri("", false, "A333DeviceId", A333DeviceId);
               RcdFound67 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound67 = 0;
         /* Using cursor T00137 */
         pr_default.execute(5, new Object[] {A333DeviceId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00137_A333DeviceId[0], A333DeviceId) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00137_A333DeviceId[0], A333DeviceId) < 0 ) ) )
            {
               A333DeviceId = T00137_A333DeviceId[0];
               AssignAttri("", false, "A333DeviceId", A333DeviceId);
               RcdFound67 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1367( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtDeviceId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1367( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound67 == 1 )
            {
               if ( StringUtil.StrCmp(A333DeviceId, Z333DeviceId) != 0 )
               {
                  A333DeviceId = Z333DeviceId;
                  AssignAttri("", false, "A333DeviceId", A333DeviceId);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "DEVICEID");
                  AnyError = 1;
                  GX_FocusControl = edtDeviceId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtDeviceId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1367( ) ;
                  GX_FocusControl = edtDeviceId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A333DeviceId, Z333DeviceId) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtDeviceId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1367( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "DEVICEID");
                     AnyError = 1;
                     GX_FocusControl = edtDeviceId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtDeviceId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1367( ) ;
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
         if ( StringUtil.StrCmp(A333DeviceId, Z333DeviceId) != 0 )
         {
            A333DeviceId = Z333DeviceId;
            AssignAttri("", false, "A333DeviceId", A333DeviceId);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "DEVICEID");
            AnyError = 1;
            GX_FocusControl = edtDeviceId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtDeviceId_Internalname;
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
         if ( RcdFound67 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "DEVICEID");
            AnyError = 1;
            GX_FocusControl = edtDeviceId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = cmbDeviceType_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1367( ) ;
         if ( RcdFound67 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = cmbDeviceType_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1367( ) ;
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
         if ( RcdFound67 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = cmbDeviceType_Internalname;
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
         if ( RcdFound67 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = cmbDeviceType_Internalname;
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
         ScanStart1367( ) ;
         if ( RcdFound67 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound67 != 0 )
            {
               ScanNext1367( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = cmbDeviceType_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1367( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1367( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00132 */
            pr_default.execute(0, new Object[] {A333DeviceId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Device"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z334DeviceType != T00132_A334DeviceType[0] ) || ( StringUtil.StrCmp(Z335DeviceToken, T00132_A335DeviceToken[0]) != 0 ) || ( StringUtil.StrCmp(Z336DeviceName, T00132_A336DeviceName[0]) != 0 ) || ( StringUtil.StrCmp(Z337DeviceUserId, T00132_A337DeviceUserId[0]) != 0 ) )
            {
               if ( Z334DeviceType != T00132_A334DeviceType[0] )
               {
                  GXUtil.WriteLog("trn_device:[seudo value changed for attri]"+"DeviceType");
                  GXUtil.WriteLogRaw("Old: ",Z334DeviceType);
                  GXUtil.WriteLogRaw("Current: ",T00132_A334DeviceType[0]);
               }
               if ( StringUtil.StrCmp(Z335DeviceToken, T00132_A335DeviceToken[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_device:[seudo value changed for attri]"+"DeviceToken");
                  GXUtil.WriteLogRaw("Old: ",Z335DeviceToken);
                  GXUtil.WriteLogRaw("Current: ",T00132_A335DeviceToken[0]);
               }
               if ( StringUtil.StrCmp(Z336DeviceName, T00132_A336DeviceName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_device:[seudo value changed for attri]"+"DeviceName");
                  GXUtil.WriteLogRaw("Old: ",Z336DeviceName);
                  GXUtil.WriteLogRaw("Current: ",T00132_A336DeviceName[0]);
               }
               if ( StringUtil.StrCmp(Z337DeviceUserId, T00132_A337DeviceUserId[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_device:[seudo value changed for attri]"+"DeviceUserId");
                  GXUtil.WriteLogRaw("Old: ",Z337DeviceUserId);
                  GXUtil.WriteLogRaw("Current: ",T00132_A337DeviceUserId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Device"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1367( )
      {
         if ( ! IsAuthorized("trn_device_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1367( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1367( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1367( 0) ;
            CheckOptimisticConcurrency1367( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1367( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1367( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00138 */
                     pr_default.execute(6, new Object[] {A333DeviceId, A334DeviceType, A335DeviceToken, A336DeviceName, A337DeviceUserId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Device");
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
                           ResetCaption130( ) ;
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
               Load1367( ) ;
            }
            EndLevel1367( ) ;
         }
         CloseExtendedTableCursors1367( ) ;
      }

      protected void Update1367( )
      {
         if ( ! IsAuthorized("trn_device_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1367( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1367( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1367( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1367( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1367( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00139 */
                     pr_default.execute(7, new Object[] {A334DeviceType, A335DeviceToken, A336DeviceName, A337DeviceUserId, A333DeviceId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Device");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Device"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1367( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption130( ) ;
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
            EndLevel1367( ) ;
         }
         CloseExtendedTableCursors1367( ) ;
      }

      protected void DeferredUpdate1367( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_device_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1367( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1367( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1367( ) ;
            AfterConfirm1367( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1367( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001310 */
                  pr_default.execute(8, new Object[] {A333DeviceId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Device");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound67 == 0 )
                        {
                           InitAll1367( ) ;
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
                        ResetCaption130( ) ;
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
         sMode67 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1367( ) ;
         Gx_mode = sMode67;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1367( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1367( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1367( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_device",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues130( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_device",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1367( )
      {
         /* Using cursor T001311 */
         pr_default.execute(9);
         RcdFound67 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound67 = 1;
            A333DeviceId = T001311_A333DeviceId[0];
            AssignAttri("", false, "A333DeviceId", A333DeviceId);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1367( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound67 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound67 = 1;
            A333DeviceId = T001311_A333DeviceId[0];
            AssignAttri("", false, "A333DeviceId", A333DeviceId);
         }
      }

      protected void ScanEnd1367( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm1367( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1367( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1367( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1367( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1367( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1367( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1367( )
      {
         edtDeviceId_Enabled = 0;
         AssignProp("", false, edtDeviceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDeviceId_Enabled), 5, 0), true);
         cmbDeviceType.Enabled = 0;
         AssignProp("", false, cmbDeviceType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbDeviceType.Enabled), 5, 0), true);
         edtDeviceToken_Enabled = 0;
         AssignProp("", false, edtDeviceToken_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDeviceToken_Enabled), 5, 0), true);
         edtDeviceName_Enabled = 0;
         AssignProp("", false, edtDeviceName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDeviceName_Enabled), 5, 0), true);
         edtDeviceUserId_Enabled = 0;
         AssignProp("", false, edtDeviceUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDeviceUserId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1367( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues130( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_device.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z333DeviceId", StringUtil.RTrim( Z333DeviceId));
         GxWebStd.gx_hidden_field( context, "Z334DeviceType", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z334DeviceType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z335DeviceToken", StringUtil.RTrim( Z335DeviceToken));
         GxWebStd.gx_hidden_field( context, "Z336DeviceName", StringUtil.RTrim( Z336DeviceName));
         GxWebStd.gx_hidden_field( context, "Z337DeviceUserId", Z337DeviceUserId);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
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
         return formatLink("trn_device.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_Device" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Device", "") ;
      }

      protected void InitializeNonKey1367( )
      {
         A334DeviceType = 0;
         AssignAttri("", false, "A334DeviceType", StringUtil.Str( (decimal)(A334DeviceType), 1, 0));
         A335DeviceToken = "";
         AssignAttri("", false, "A335DeviceToken", A335DeviceToken);
         A336DeviceName = "";
         AssignAttri("", false, "A336DeviceName", A336DeviceName);
         A337DeviceUserId = "";
         AssignAttri("", false, "A337DeviceUserId", A337DeviceUserId);
         Z334DeviceType = 0;
         Z335DeviceToken = "";
         Z336DeviceName = "";
         Z337DeviceUserId = "";
      }

      protected void InitAll1367( )
      {
         A333DeviceId = "";
         AssignAttri("", false, "A333DeviceId", A333DeviceId);
         InitializeNonKey1367( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256145351915", true, true);
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
         context.AddJavascriptSource("trn_device.js", "?20256145351915", false, true);
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
         edtDeviceId_Internalname = "DEVICEID";
         cmbDeviceType_Internalname = "DEVICETYPE";
         edtDeviceToken_Internalname = "DEVICETOKEN";
         edtDeviceName_Internalname = "DEVICENAME";
         edtDeviceUserId_Internalname = "DEVICEUSERID";
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
         Form.Caption = context.GetMessage( "Trn_Device", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtDeviceUserId_Jsonclick = "";
         edtDeviceUserId_Enabled = 1;
         edtDeviceName_Jsonclick = "";
         edtDeviceName_Enabled = 1;
         edtDeviceToken_Enabled = 1;
         cmbDeviceType_Jsonclick = "";
         cmbDeviceType.Enabled = 1;
         edtDeviceId_Jsonclick = "";
         edtDeviceId_Enabled = 1;
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
         cmbDeviceType.Name = "DEVICETYPE";
         cmbDeviceType.WebTags = "";
         cmbDeviceType.addItem("0", context.GetMessage( "iOS", ""), 0);
         cmbDeviceType.addItem("1", context.GetMessage( "Android", ""), 0);
         cmbDeviceType.addItem("2", context.GetMessage( "Blackberry", ""), 0);
         cmbDeviceType.addItem("3", context.GetMessage( "Windows", ""), 0);
         if ( cmbDeviceType.ItemCount > 0 )
         {
            A334DeviceType = (short)(Math.Round(NumberUtil.Val( cmbDeviceType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A334DeviceType), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A334DeviceType", StringUtil.Str( (decimal)(A334DeviceType), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = cmbDeviceType_Internalname;
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

      public void Valid_Deviceid( )
      {
         A334DeviceType = (short)(Math.Round(NumberUtil.Val( cmbDeviceType.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbDeviceType.CurrentValue = StringUtil.Str( (decimal)(A334DeviceType), 1, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbDeviceType.ItemCount > 0 )
         {
            A334DeviceType = (short)(Math.Round(NumberUtil.Val( cmbDeviceType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A334DeviceType), 1, 0))), "."), 18, MidpointRounding.ToEven));
            cmbDeviceType.CurrentValue = StringUtil.Str( (decimal)(A334DeviceType), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbDeviceType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A334DeviceType), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A334DeviceType", StringUtil.LTrim( StringUtil.NToC( (decimal)(A334DeviceType), 1, 0, ".", "")));
         cmbDeviceType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A334DeviceType), 1, 0));
         AssignProp("", false, cmbDeviceType_Internalname, "Values", cmbDeviceType.ToJavascriptSource(), true);
         AssignAttri("", false, "A335DeviceToken", StringUtil.RTrim( A335DeviceToken));
         AssignAttri("", false, "A336DeviceName", StringUtil.RTrim( A336DeviceName));
         AssignAttri("", false, "A337DeviceUserId", A337DeviceUserId);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z333DeviceId", StringUtil.RTrim( Z333DeviceId));
         GxWebStd.gx_hidden_field( context, "Z334DeviceType", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z334DeviceType), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z335DeviceToken", StringUtil.RTrim( Z335DeviceToken));
         GxWebStd.gx_hidden_field( context, "Z336DeviceName", StringUtil.RTrim( Z336DeviceName));
         GxWebStd.gx_hidden_field( context, "Z337DeviceUserId", Z337DeviceUserId);
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
         setEventMetadata("VALID_DEVICEID","""{"handler":"Valid_Deviceid","iparms":[{"av":"cmbDeviceType"},{"av":"A334DeviceType","fld":"DEVICETYPE","pic":"9"},{"av":"A333DeviceId","fld":"DEVICEID"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"}]""");
         setEventMetadata("VALID_DEVICEID",""","oparms":[{"av":"cmbDeviceType"},{"av":"A334DeviceType","fld":"DEVICETYPE","pic":"9"},{"av":"A335DeviceToken","fld":"DEVICETOKEN"},{"av":"A336DeviceName","fld":"DEVICENAME"},{"av":"A337DeviceUserId","fld":"DEVICEUSERID"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z333DeviceId"},{"av":"Z334DeviceType"},{"av":"Z335DeviceToken"},{"av":"Z336DeviceName"},{"av":"Z337DeviceUserId"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_DEVICETYPE","""{"handler":"Valid_Devicetype","iparms":[]}""");
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
         Z333DeviceId = "";
         Z335DeviceToken = "";
         Z336DeviceName = "";
         Z337DeviceUserId = "";
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
         A333DeviceId = "";
         A335DeviceToken = "";
         A336DeviceName = "";
         A337DeviceUserId = "";
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
         T00134_A333DeviceId = new string[] {""} ;
         T00134_A334DeviceType = new short[1] ;
         T00134_A335DeviceToken = new string[] {""} ;
         T00134_A336DeviceName = new string[] {""} ;
         T00134_A337DeviceUserId = new string[] {""} ;
         T00135_A333DeviceId = new string[] {""} ;
         T00133_A333DeviceId = new string[] {""} ;
         T00133_A334DeviceType = new short[1] ;
         T00133_A335DeviceToken = new string[] {""} ;
         T00133_A336DeviceName = new string[] {""} ;
         T00133_A337DeviceUserId = new string[] {""} ;
         sMode67 = "";
         T00136_A333DeviceId = new string[] {""} ;
         T00137_A333DeviceId = new string[] {""} ;
         T00132_A333DeviceId = new string[] {""} ;
         T00132_A334DeviceType = new short[1] ;
         T00132_A335DeviceToken = new string[] {""} ;
         T00132_A336DeviceName = new string[] {""} ;
         T00132_A337DeviceUserId = new string[] {""} ;
         T001311_A333DeviceId = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ333DeviceId = "";
         ZZ335DeviceToken = "";
         ZZ336DeviceName = "";
         ZZ337DeviceUserId = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_device__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_device__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_device__default(),
            new Object[][] {
                new Object[] {
               T00132_A333DeviceId, T00132_A334DeviceType, T00132_A335DeviceToken, T00132_A336DeviceName, T00132_A337DeviceUserId
               }
               , new Object[] {
               T00133_A333DeviceId, T00133_A334DeviceType, T00133_A335DeviceToken, T00133_A336DeviceName, T00133_A337DeviceUserId
               }
               , new Object[] {
               T00134_A333DeviceId, T00134_A334DeviceType, T00134_A335DeviceToken, T00134_A336DeviceName, T00134_A337DeviceUserId
               }
               , new Object[] {
               T00135_A333DeviceId
               }
               , new Object[] {
               T00136_A333DeviceId
               }
               , new Object[] {
               T00137_A333DeviceId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001311_A333DeviceId
               }
            }
         );
      }

      private short Z334DeviceType ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A334DeviceType ;
      private short RcdFound67 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ334DeviceType ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtDeviceId_Enabled ;
      private int edtDeviceToken_Enabled ;
      private int edtDeviceName_Enabled ;
      private int edtDeviceUserId_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string Z333DeviceId ;
      private string Z335DeviceToken ;
      private string Z336DeviceName ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtDeviceId_Internalname ;
      private string cmbDeviceType_Internalname ;
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
      private string A333DeviceId ;
      private string edtDeviceId_Jsonclick ;
      private string cmbDeviceType_Jsonclick ;
      private string edtDeviceToken_Internalname ;
      private string A335DeviceToken ;
      private string edtDeviceName_Internalname ;
      private string A336DeviceName ;
      private string edtDeviceName_Jsonclick ;
      private string edtDeviceUserId_Internalname ;
      private string edtDeviceUserId_Jsonclick ;
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
      private string sMode67 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ333DeviceId ;
      private string ZZ335DeviceToken ;
      private string ZZ336DeviceName ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z337DeviceUserId ;
      private string A337DeviceUserId ;
      private string ZZ337DeviceUserId ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbDeviceType ;
      private IDataStoreProvider pr_default ;
      private string[] T00134_A333DeviceId ;
      private short[] T00134_A334DeviceType ;
      private string[] T00134_A335DeviceToken ;
      private string[] T00134_A336DeviceName ;
      private string[] T00134_A337DeviceUserId ;
      private string[] T00135_A333DeviceId ;
      private string[] T00133_A333DeviceId ;
      private short[] T00133_A334DeviceType ;
      private string[] T00133_A335DeviceToken ;
      private string[] T00133_A336DeviceName ;
      private string[] T00133_A337DeviceUserId ;
      private string[] T00136_A333DeviceId ;
      private string[] T00137_A333DeviceId ;
      private string[] T00132_A333DeviceId ;
      private short[] T00132_A334DeviceType ;
      private string[] T00132_A335DeviceToken ;
      private string[] T00132_A336DeviceName ;
      private string[] T00132_A337DeviceUserId ;
      private string[] T001311_A333DeviceId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_device__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_device__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_device__default : DataStoreHelperBase, IDataStoreHelper
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
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT00132;
       prmT00132 = new Object[] {
       new ParDef("DeviceId",GXType.Char,128,0)
       };
       Object[] prmT00133;
       prmT00133 = new Object[] {
       new ParDef("DeviceId",GXType.Char,128,0)
       };
       Object[] prmT00134;
       prmT00134 = new Object[] {
       new ParDef("DeviceId",GXType.Char,128,0)
       };
       Object[] prmT00135;
       prmT00135 = new Object[] {
       new ParDef("DeviceId",GXType.Char,128,0)
       };
       Object[] prmT00136;
       prmT00136 = new Object[] {
       new ParDef("DeviceId",GXType.Char,128,0)
       };
       Object[] prmT00137;
       prmT00137 = new Object[] {
       new ParDef("DeviceId",GXType.Char,128,0)
       };
       Object[] prmT00138;
       prmT00138 = new Object[] {
       new ParDef("DeviceId",GXType.Char,128,0) ,
       new ParDef("DeviceType",GXType.Int16,1,0) ,
       new ParDef("DeviceToken",GXType.Char,1000,0) ,
       new ParDef("DeviceName",GXType.Char,128,0) ,
       new ParDef("DeviceUserId",GXType.VarChar,100,60)
       };
       Object[] prmT00139;
       prmT00139 = new Object[] {
       new ParDef("DeviceType",GXType.Int16,1,0) ,
       new ParDef("DeviceToken",GXType.Char,1000,0) ,
       new ParDef("DeviceName",GXType.Char,128,0) ,
       new ParDef("DeviceUserId",GXType.VarChar,100,60) ,
       new ParDef("DeviceId",GXType.Char,128,0)
       };
       Object[] prmT001310;
       prmT001310 = new Object[] {
       new ParDef("DeviceId",GXType.Char,128,0)
       };
       Object[] prmT001311;
       prmT001311 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T00132", "SELECT DeviceId, DeviceType, DeviceToken, DeviceName, DeviceUserId FROM Trn_Device WHERE DeviceId = :DeviceId  FOR UPDATE OF Trn_Device NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00132,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00133", "SELECT DeviceId, DeviceType, DeviceToken, DeviceName, DeviceUserId FROM Trn_Device WHERE DeviceId = :DeviceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00133,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00134", "SELECT TM1.DeviceId, TM1.DeviceType, TM1.DeviceToken, TM1.DeviceName, TM1.DeviceUserId FROM Trn_Device TM1 WHERE TM1.DeviceId = ( :DeviceId) ORDER BY TM1.DeviceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00134,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00135", "SELECT DeviceId FROM Trn_Device WHERE DeviceId = :DeviceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00135,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00136", "SELECT DeviceId FROM Trn_Device WHERE ( DeviceId > ( :DeviceId)) ORDER BY DeviceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00136,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T00137", "SELECT DeviceId FROM Trn_Device WHERE ( DeviceId < ( :DeviceId)) ORDER BY DeviceId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT00137,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T00138", "SAVEPOINT gxupdate;INSERT INTO Trn_Device(DeviceId, DeviceType, DeviceToken, DeviceName, DeviceUserId) VALUES(:DeviceId, :DeviceType, :DeviceToken, :DeviceName, :DeviceUserId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT00138)
          ,new CursorDef("T00139", "SAVEPOINT gxupdate;UPDATE Trn_Device SET DeviceType=:DeviceType, DeviceToken=:DeviceToken, DeviceName=:DeviceName, DeviceUserId=:DeviceUserId  WHERE DeviceId = :DeviceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT00139)
          ,new CursorDef("T001310", "SAVEPOINT gxupdate;DELETE FROM Trn_Device  WHERE DeviceId = :DeviceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001310)
          ,new CursorDef("T001311", "SELECT DeviceId FROM Trn_Device ORDER BY DeviceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001311,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[0])[0] = rslt.getString(1, 128);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 1000);
             ((string[]) buf[3])[0] = rslt.getString(4, 128);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             return;
          case 1 :
             ((string[]) buf[0])[0] = rslt.getString(1, 128);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 1000);
             ((string[]) buf[3])[0] = rslt.getString(4, 128);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getString(1, 128);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 1000);
             ((string[]) buf[3])[0] = rslt.getString(4, 128);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getString(1, 128);
             return;
          case 4 :
             ((string[]) buf[0])[0] = rslt.getString(1, 128);
             return;
          case 5 :
             ((string[]) buf[0])[0] = rslt.getString(1, 128);
             return;
          case 9 :
             ((string[]) buf[0])[0] = rslt.getString(1, 128);
             return;
    }
 }

}

}
