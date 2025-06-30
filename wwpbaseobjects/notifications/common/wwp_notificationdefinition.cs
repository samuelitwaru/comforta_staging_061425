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
   public class wwp_notificationdefinition : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel3"+"_"+"WWPNOTIFICATIONDEFINITIONISAUT") == 0 )
         {
            A172WWPNotificationDefinitionSecFu = GetPar( "WWPNotificationDefinitionSecFu");
            AssignAttri("", false, "A172WWPNotificationDefinitionSecFu", A172WWPNotificationDefinitionSecFu);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX3ASAWWPNOTIFICATIONDEFINITIONISAUT0N33( A172WWPNotificationDefinitionSecFu) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A125WWPEntityId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPEntityId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A125WWPEntityId", StringUtil.LTrimStr( (decimal)(A125WWPEntityId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A125WWPEntityId) ;
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
         Form.Meta.addItem("description", context.GetMessage( "Notification Definition", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_notificationdefinition( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_notificationdefinition( IGxContext context )
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
         cmbWWPNotificationDefinitionAppli = new GXCombobox();
         chkWWPNotificationDefinitionAllow = new GXCheckbox();
         chkWWPNotificationDefinitionIsAut = new GXCheckbox();
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
            return "wwpnotificationdefinition_Execute" ;
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
         if ( cmbWWPNotificationDefinitionAppli.ItemCount > 0 )
         {
            A135WWPNotificationDefinitionAppli = (short)(Math.Round(NumberUtil.Val( cmbWWPNotificationDefinitionAppli.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A135WWPNotificationDefinitionAppli), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A135WWPNotificationDefinitionAppli", StringUtil.Str( (decimal)(A135WWPNotificationDefinitionAppli), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPNotificationDefinitionAppli.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A135WWPNotificationDefinitionAppli), 1, 0));
            AssignProp("", false, cmbWWPNotificationDefinitionAppli_Internalname, "Values", cmbWWPNotificationDefinitionAppli.ToJavascriptSource(), true);
         }
         A136WWPNotificationDefinitionAllow = StringUtil.StrToBool( StringUtil.BoolToStr( A136WWPNotificationDefinitionAllow));
         AssignAttri("", false, "A136WWPNotificationDefinitionAllow", A136WWPNotificationDefinitionAllow);
         A173WWPNotificationDefinitionIsAut = StringUtil.StrToBool( StringUtil.BoolToStr( A173WWPNotificationDefinitionIsAut));
         AssignAttri("", false, "A173WWPNotificationDefinitionIsAut", A173WWPNotificationDefinitionIsAut);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Notification Definition", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionId_Internalname, context.GetMessage( "Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A128WWPNotificationDefinitionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPNotificationDefinitionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A128WWPNotificationDefinitionId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A128WWPNotificationDefinitionId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationDefinitionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
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
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionName_Internalname, context.GetMessage( "Internal Name", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionName_Internalname, A164WWPNotificationDefinitionName, StringUtil.RTrim( context.localUtil.Format( A164WWPNotificationDefinitionName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationDefinitionName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbWWPNotificationDefinitionAppli_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbWWPNotificationDefinitionAppli_Internalname, context.GetMessage( "Applies To", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbWWPNotificationDefinitionAppli, cmbWWPNotificationDefinitionAppli_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A135WWPNotificationDefinitionAppli), 1, 0)), 1, cmbWWPNotificationDefinitionAppli_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbWWPNotificationDefinitionAppli.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", true, 0, "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         cmbWWPNotificationDefinitionAppli.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A135WWPNotificationDefinitionAppli), 1, 0));
         AssignProp("", false, cmbWWPNotificationDefinitionAppli_Internalname, "Values", (string)(cmbWWPNotificationDefinitionAppli.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPNotificationDefinitionAllow_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPNotificationDefinitionAllow_Internalname, context.GetMessage( "Allow User Subscription", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPNotificationDefinitionAllow_Internalname, StringUtil.BoolToStr( A136WWPNotificationDefinitionAllow), "", context.GetMessage( "Allow User Subscription", ""), 1, chkWWPNotificationDefinitionAllow.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(49, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,49);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionDescr_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionDescr_Internalname, context.GetMessage( "Description", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationDefinitionDescr_Internalname, A134WWPNotificationDefinitionDescr, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", 0, 1, edtWWPNotificationDefinitionDescr_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionIcon_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionIcon_Internalname, context.GetMessage( "Default Icon", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionIcon_Internalname, A167WWPNotificationDefinitionIcon, StringUtil.RTrim( context.localUtil.Format( A167WWPNotificationDefinitionIcon, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationDefinitionIcon_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionIcon_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionTitle_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionTitle_Internalname, context.GetMessage( "Default Title", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationDefinitionTitle_Internalname, A168WWPNotificationDefinitionTitle, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", 0, 1, edtWWPNotificationDefinitionTitle_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionShort_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionShort_Internalname, context.GetMessage( "Default Short Description", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationDefinitionShort_Internalname, A169WWPNotificationDefinitionShort, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", 0, 1, edtWWPNotificationDefinitionShort_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionLongD_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionLongD_Internalname, context.GetMessage( "Default Long Description", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationDefinitionLongD_Internalname, A170WWPNotificationDefinitionLongD, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", 0, 1, edtWWPNotificationDefinitionLongD_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionLink_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionLink_Internalname, context.GetMessage( "Default Link", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionLink_Internalname, A171WWPNotificationDefinitionLink, StringUtil.RTrim( context.localUtil.Format( A171WWPNotificationDefinitionLink, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", A171WWPNotificationDefinitionLink, "_blank", "", "", edtWWPNotificationDefinitionLink_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionLink_Enabled, 0, "url", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Url", "start", true, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPEntityId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPEntityId_Internalname, context.GetMessage( "Entity Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPEntityId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A125WWPEntityId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPEntityId_Enabled!=0) ? context.localUtil.Format( (decimal)(A125WWPEntityId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A125WWPEntityId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPEntityId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPEntityId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPEntityName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPEntityName_Internalname, context.GetMessage( "Entity Name", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPEntityName_Internalname, A126WWPEntityName, StringUtil.RTrim( context.localUtil.Format( A126WWPEntityName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPEntityName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPEntityName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionSecFu_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionSecFu_Internalname, context.GetMessage( "Funcionality Key", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationDefinitionSecFu_Internalname, A172WWPNotificationDefinitionSecFu, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", 0, 1, edtWWPNotificationDefinitionSecFu_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPNotificationDefinitionIsAut_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPNotificationDefinitionIsAut_Internalname, context.GetMessage( "User Authorized", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPNotificationDefinitionIsAut_Internalname, StringUtil.BoolToStr( A173WWPNotificationDefinitionIsAut), "", context.GetMessage( "User Authorized", ""), 1, chkWWPNotificationDefinitionIsAut.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(99, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,99);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
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
            Z128WWPNotificationDefinitionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z128WWPNotificationDefinitionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z164WWPNotificationDefinitionName = cgiGet( "Z164WWPNotificationDefinitionName");
            Z135WWPNotificationDefinitionAppli = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z135WWPNotificationDefinitionAppli"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z136WWPNotificationDefinitionAllow = StringUtil.StrToBool( cgiGet( "Z136WWPNotificationDefinitionAllow"));
            Z134WWPNotificationDefinitionDescr = cgiGet( "Z134WWPNotificationDefinitionDescr");
            Z167WWPNotificationDefinitionIcon = cgiGet( "Z167WWPNotificationDefinitionIcon");
            Z168WWPNotificationDefinitionTitle = cgiGet( "Z168WWPNotificationDefinitionTitle");
            Z169WWPNotificationDefinitionShort = cgiGet( "Z169WWPNotificationDefinitionShort");
            Z170WWPNotificationDefinitionLongD = cgiGet( "Z170WWPNotificationDefinitionLongD");
            Z171WWPNotificationDefinitionLink = cgiGet( "Z171WWPNotificationDefinitionLink");
            Z172WWPNotificationDefinitionSecFu = cgiGet( "Z172WWPNotificationDefinitionSecFu");
            Z125WWPEntityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z125WWPEntityId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
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
            cmbWWPNotificationDefinitionAppli.CurrentValue = cgiGet( cmbWWPNotificationDefinitionAppli_Internalname);
            A135WWPNotificationDefinitionAppli = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPNotificationDefinitionAppli_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A135WWPNotificationDefinitionAppli", StringUtil.Str( (decimal)(A135WWPNotificationDefinitionAppli), 1, 0));
            A136WWPNotificationDefinitionAllow = StringUtil.StrToBool( cgiGet( chkWWPNotificationDefinitionAllow_Internalname));
            AssignAttri("", false, "A136WWPNotificationDefinitionAllow", A136WWPNotificationDefinitionAllow);
            A134WWPNotificationDefinitionDescr = cgiGet( edtWWPNotificationDefinitionDescr_Internalname);
            AssignAttri("", false, "A134WWPNotificationDefinitionDescr", A134WWPNotificationDefinitionDescr);
            A167WWPNotificationDefinitionIcon = cgiGet( edtWWPNotificationDefinitionIcon_Internalname);
            AssignAttri("", false, "A167WWPNotificationDefinitionIcon", A167WWPNotificationDefinitionIcon);
            A168WWPNotificationDefinitionTitle = cgiGet( edtWWPNotificationDefinitionTitle_Internalname);
            AssignAttri("", false, "A168WWPNotificationDefinitionTitle", A168WWPNotificationDefinitionTitle);
            A169WWPNotificationDefinitionShort = cgiGet( edtWWPNotificationDefinitionShort_Internalname);
            AssignAttri("", false, "A169WWPNotificationDefinitionShort", A169WWPNotificationDefinitionShort);
            A170WWPNotificationDefinitionLongD = cgiGet( edtWWPNotificationDefinitionLongD_Internalname);
            AssignAttri("", false, "A170WWPNotificationDefinitionLongD", A170WWPNotificationDefinitionLongD);
            A171WWPNotificationDefinitionLink = cgiGet( edtWWPNotificationDefinitionLink_Internalname);
            AssignAttri("", false, "A171WWPNotificationDefinitionLink", A171WWPNotificationDefinitionLink);
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPEntityId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPEntityId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPENTITYID");
               AnyError = 1;
               GX_FocusControl = edtWWPEntityId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A125WWPEntityId = 0;
               AssignAttri("", false, "A125WWPEntityId", StringUtil.LTrimStr( (decimal)(A125WWPEntityId), 10, 0));
            }
            else
            {
               A125WWPEntityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPEntityId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A125WWPEntityId", StringUtil.LTrimStr( (decimal)(A125WWPEntityId), 10, 0));
            }
            A126WWPEntityName = cgiGet( edtWWPEntityName_Internalname);
            AssignAttri("", false, "A126WWPEntityName", A126WWPEntityName);
            A172WWPNotificationDefinitionSecFu = cgiGet( edtWWPNotificationDefinitionSecFu_Internalname);
            AssignAttri("", false, "A172WWPNotificationDefinitionSecFu", A172WWPNotificationDefinitionSecFu);
            A173WWPNotificationDefinitionIsAut = StringUtil.StrToBool( cgiGet( chkWWPNotificationDefinitionIsAut_Internalname));
            AssignAttri("", false, "A173WWPNotificationDefinitionIsAut", A173WWPNotificationDefinitionIsAut);
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
               A128WWPNotificationDefinitionId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPNotificationDefinitionId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A128WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A128WWPNotificationDefinitionId), 10, 0));
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
               InitAll0N33( ) ;
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
         DisableAttributes0N33( ) ;
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

      protected void ResetCaption0N0( )
      {
      }

      protected void ZM0N33( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z164WWPNotificationDefinitionName = T000N3_A164WWPNotificationDefinitionName[0];
               Z135WWPNotificationDefinitionAppli = T000N3_A135WWPNotificationDefinitionAppli[0];
               Z136WWPNotificationDefinitionAllow = T000N3_A136WWPNotificationDefinitionAllow[0];
               Z134WWPNotificationDefinitionDescr = T000N3_A134WWPNotificationDefinitionDescr[0];
               Z167WWPNotificationDefinitionIcon = T000N3_A167WWPNotificationDefinitionIcon[0];
               Z168WWPNotificationDefinitionTitle = T000N3_A168WWPNotificationDefinitionTitle[0];
               Z169WWPNotificationDefinitionShort = T000N3_A169WWPNotificationDefinitionShort[0];
               Z170WWPNotificationDefinitionLongD = T000N3_A170WWPNotificationDefinitionLongD[0];
               Z171WWPNotificationDefinitionLink = T000N3_A171WWPNotificationDefinitionLink[0];
               Z172WWPNotificationDefinitionSecFu = T000N3_A172WWPNotificationDefinitionSecFu[0];
               Z125WWPEntityId = T000N3_A125WWPEntityId[0];
            }
            else
            {
               Z164WWPNotificationDefinitionName = A164WWPNotificationDefinitionName;
               Z135WWPNotificationDefinitionAppli = A135WWPNotificationDefinitionAppli;
               Z136WWPNotificationDefinitionAllow = A136WWPNotificationDefinitionAllow;
               Z134WWPNotificationDefinitionDescr = A134WWPNotificationDefinitionDescr;
               Z167WWPNotificationDefinitionIcon = A167WWPNotificationDefinitionIcon;
               Z168WWPNotificationDefinitionTitle = A168WWPNotificationDefinitionTitle;
               Z169WWPNotificationDefinitionShort = A169WWPNotificationDefinitionShort;
               Z170WWPNotificationDefinitionLongD = A170WWPNotificationDefinitionLongD;
               Z171WWPNotificationDefinitionLink = A171WWPNotificationDefinitionLink;
               Z172WWPNotificationDefinitionSecFu = A172WWPNotificationDefinitionSecFu;
               Z125WWPEntityId = A125WWPEntityId;
            }
         }
         if ( GX_JID == -4 )
         {
            Z128WWPNotificationDefinitionId = A128WWPNotificationDefinitionId;
            Z164WWPNotificationDefinitionName = A164WWPNotificationDefinitionName;
            Z135WWPNotificationDefinitionAppli = A135WWPNotificationDefinitionAppli;
            Z136WWPNotificationDefinitionAllow = A136WWPNotificationDefinitionAllow;
            Z134WWPNotificationDefinitionDescr = A134WWPNotificationDefinitionDescr;
            Z167WWPNotificationDefinitionIcon = A167WWPNotificationDefinitionIcon;
            Z168WWPNotificationDefinitionTitle = A168WWPNotificationDefinitionTitle;
            Z169WWPNotificationDefinitionShort = A169WWPNotificationDefinitionShort;
            Z170WWPNotificationDefinitionLongD = A170WWPNotificationDefinitionLongD;
            Z171WWPNotificationDefinitionLink = A171WWPNotificationDefinitionLink;
            Z172WWPNotificationDefinitionSecFu = A172WWPNotificationDefinitionSecFu;
            Z125WWPEntityId = A125WWPEntityId;
            Z126WWPEntityName = A126WWPEntityName;
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

      protected void Load0N33( )
      {
         /* Using cursor T000N5 */
         pr_default.execute(3, new Object[] {A128WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound33 = 1;
            A164WWPNotificationDefinitionName = T000N5_A164WWPNotificationDefinitionName[0];
            AssignAttri("", false, "A164WWPNotificationDefinitionName", A164WWPNotificationDefinitionName);
            A135WWPNotificationDefinitionAppli = T000N5_A135WWPNotificationDefinitionAppli[0];
            AssignAttri("", false, "A135WWPNotificationDefinitionAppli", StringUtil.Str( (decimal)(A135WWPNotificationDefinitionAppli), 1, 0));
            A136WWPNotificationDefinitionAllow = T000N5_A136WWPNotificationDefinitionAllow[0];
            AssignAttri("", false, "A136WWPNotificationDefinitionAllow", A136WWPNotificationDefinitionAllow);
            A134WWPNotificationDefinitionDescr = T000N5_A134WWPNotificationDefinitionDescr[0];
            AssignAttri("", false, "A134WWPNotificationDefinitionDescr", A134WWPNotificationDefinitionDescr);
            A167WWPNotificationDefinitionIcon = T000N5_A167WWPNotificationDefinitionIcon[0];
            AssignAttri("", false, "A167WWPNotificationDefinitionIcon", A167WWPNotificationDefinitionIcon);
            A168WWPNotificationDefinitionTitle = T000N5_A168WWPNotificationDefinitionTitle[0];
            AssignAttri("", false, "A168WWPNotificationDefinitionTitle", A168WWPNotificationDefinitionTitle);
            A169WWPNotificationDefinitionShort = T000N5_A169WWPNotificationDefinitionShort[0];
            AssignAttri("", false, "A169WWPNotificationDefinitionShort", A169WWPNotificationDefinitionShort);
            A170WWPNotificationDefinitionLongD = T000N5_A170WWPNotificationDefinitionLongD[0];
            AssignAttri("", false, "A170WWPNotificationDefinitionLongD", A170WWPNotificationDefinitionLongD);
            A171WWPNotificationDefinitionLink = T000N5_A171WWPNotificationDefinitionLink[0];
            AssignAttri("", false, "A171WWPNotificationDefinitionLink", A171WWPNotificationDefinitionLink);
            A126WWPEntityName = T000N5_A126WWPEntityName[0];
            AssignAttri("", false, "A126WWPEntityName", A126WWPEntityName);
            A172WWPNotificationDefinitionSecFu = T000N5_A172WWPNotificationDefinitionSecFu[0];
            AssignAttri("", false, "A172WWPNotificationDefinitionSecFu", A172WWPNotificationDefinitionSecFu);
            A125WWPEntityId = T000N5_A125WWPEntityId[0];
            AssignAttri("", false, "A125WWPEntityId", StringUtil.LTrimStr( (decimal)(A125WWPEntityId), 10, 0));
            ZM0N33( -4) ;
         }
         pr_default.close(3);
         OnLoadActions0N33( ) ;
      }

      protected void OnLoadActions0N33( )
      {
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A172WWPNotificationDefinitionSecFu)) )
         {
            A173WWPNotificationDefinitionIsAut = true;
            AssignAttri("", false, "A173WWPNotificationDefinitionIsAut", A173WWPNotificationDefinitionIsAut);
         }
         else
         {
            GXt_boolean1 = A173WWPNotificationDefinitionIsAut;
            new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  A172WWPNotificationDefinitionSecFu, out  GXt_boolean1) ;
            A173WWPNotificationDefinitionIsAut = GXt_boolean1;
            AssignAttri("", false, "A173WWPNotificationDefinitionIsAut", A173WWPNotificationDefinitionIsAut);
         }
      }

      protected void CheckExtendedTable0N33( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( ( A135WWPNotificationDefinitionAppli == 1 ) || ( A135WWPNotificationDefinitionAppli == 2 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Notification Definition Applies To", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "WWPNOTIFICATIONDEFINITIONAPPLI");
            AnyError = 1;
            GX_FocusControl = cmbWWPNotificationDefinitionAppli_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A171WWPNotificationDefinitionLink,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Notification Definition Default Link", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "WWPNOTIFICATIONDEFINITIONLINK");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionLink_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000N4 */
         pr_default.execute(2, new Object[] {A125WWPEntityId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Entity", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
            GX_FocusControl = edtWWPEntityId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A126WWPEntityName = T000N4_A126WWPEntityName[0];
         AssignAttri("", false, "A126WWPEntityName", A126WWPEntityName);
         pr_default.close(2);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A172WWPNotificationDefinitionSecFu)) )
         {
            A173WWPNotificationDefinitionIsAut = true;
            AssignAttri("", false, "A173WWPNotificationDefinitionIsAut", A173WWPNotificationDefinitionIsAut);
         }
         else
         {
            GXt_boolean1 = A173WWPNotificationDefinitionIsAut;
            new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  A172WWPNotificationDefinitionSecFu, out  GXt_boolean1) ;
            A173WWPNotificationDefinitionIsAut = GXt_boolean1;
            AssignAttri("", false, "A173WWPNotificationDefinitionIsAut", A173WWPNotificationDefinitionIsAut);
         }
      }

      protected void CloseExtendedTableCursors0N33( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_5( long A125WWPEntityId )
      {
         /* Using cursor T000N6 */
         pr_default.execute(4, new Object[] {A125WWPEntityId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Entity", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
            GX_FocusControl = edtWWPEntityId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A126WWPEntityName = T000N6_A126WWPEntityName[0];
         AssignAttri("", false, "A126WWPEntityName", A126WWPEntityName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A126WWPEntityName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey0N33( )
      {
         /* Using cursor T000N7 */
         pr_default.execute(5, new Object[] {A128WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound33 = 1;
         }
         else
         {
            RcdFound33 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000N3 */
         pr_default.execute(1, new Object[] {A128WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0N33( 4) ;
            RcdFound33 = 1;
            A128WWPNotificationDefinitionId = T000N3_A128WWPNotificationDefinitionId[0];
            AssignAttri("", false, "A128WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A128WWPNotificationDefinitionId), 10, 0));
            A164WWPNotificationDefinitionName = T000N3_A164WWPNotificationDefinitionName[0];
            AssignAttri("", false, "A164WWPNotificationDefinitionName", A164WWPNotificationDefinitionName);
            A135WWPNotificationDefinitionAppli = T000N3_A135WWPNotificationDefinitionAppli[0];
            AssignAttri("", false, "A135WWPNotificationDefinitionAppli", StringUtil.Str( (decimal)(A135WWPNotificationDefinitionAppli), 1, 0));
            A136WWPNotificationDefinitionAllow = T000N3_A136WWPNotificationDefinitionAllow[0];
            AssignAttri("", false, "A136WWPNotificationDefinitionAllow", A136WWPNotificationDefinitionAllow);
            A134WWPNotificationDefinitionDescr = T000N3_A134WWPNotificationDefinitionDescr[0];
            AssignAttri("", false, "A134WWPNotificationDefinitionDescr", A134WWPNotificationDefinitionDescr);
            A167WWPNotificationDefinitionIcon = T000N3_A167WWPNotificationDefinitionIcon[0];
            AssignAttri("", false, "A167WWPNotificationDefinitionIcon", A167WWPNotificationDefinitionIcon);
            A168WWPNotificationDefinitionTitle = T000N3_A168WWPNotificationDefinitionTitle[0];
            AssignAttri("", false, "A168WWPNotificationDefinitionTitle", A168WWPNotificationDefinitionTitle);
            A169WWPNotificationDefinitionShort = T000N3_A169WWPNotificationDefinitionShort[0];
            AssignAttri("", false, "A169WWPNotificationDefinitionShort", A169WWPNotificationDefinitionShort);
            A170WWPNotificationDefinitionLongD = T000N3_A170WWPNotificationDefinitionLongD[0];
            AssignAttri("", false, "A170WWPNotificationDefinitionLongD", A170WWPNotificationDefinitionLongD);
            A171WWPNotificationDefinitionLink = T000N3_A171WWPNotificationDefinitionLink[0];
            AssignAttri("", false, "A171WWPNotificationDefinitionLink", A171WWPNotificationDefinitionLink);
            A172WWPNotificationDefinitionSecFu = T000N3_A172WWPNotificationDefinitionSecFu[0];
            AssignAttri("", false, "A172WWPNotificationDefinitionSecFu", A172WWPNotificationDefinitionSecFu);
            A125WWPEntityId = T000N3_A125WWPEntityId[0];
            AssignAttri("", false, "A125WWPEntityId", StringUtil.LTrimStr( (decimal)(A125WWPEntityId), 10, 0));
            Z128WWPNotificationDefinitionId = A128WWPNotificationDefinitionId;
            sMode33 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0N33( ) ;
            if ( AnyError == 1 )
            {
               RcdFound33 = 0;
               InitializeNonKey0N33( ) ;
            }
            Gx_mode = sMode33;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound33 = 0;
            InitializeNonKey0N33( ) ;
            sMode33 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode33;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0N33( ) ;
         if ( RcdFound33 == 0 )
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
         RcdFound33 = 0;
         /* Using cursor T000N8 */
         pr_default.execute(6, new Object[] {A128WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000N8_A128WWPNotificationDefinitionId[0] < A128WWPNotificationDefinitionId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000N8_A128WWPNotificationDefinitionId[0] > A128WWPNotificationDefinitionId ) ) )
            {
               A128WWPNotificationDefinitionId = T000N8_A128WWPNotificationDefinitionId[0];
               AssignAttri("", false, "A128WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A128WWPNotificationDefinitionId), 10, 0));
               RcdFound33 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound33 = 0;
         /* Using cursor T000N9 */
         pr_default.execute(7, new Object[] {A128WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000N9_A128WWPNotificationDefinitionId[0] > A128WWPNotificationDefinitionId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000N9_A128WWPNotificationDefinitionId[0] < A128WWPNotificationDefinitionId ) ) )
            {
               A128WWPNotificationDefinitionId = T000N9_A128WWPNotificationDefinitionId[0];
               AssignAttri("", false, "A128WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A128WWPNotificationDefinitionId), 10, 0));
               RcdFound33 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0N33( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0N33( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound33 == 1 )
            {
               if ( A128WWPNotificationDefinitionId != Z128WWPNotificationDefinitionId )
               {
                  A128WWPNotificationDefinitionId = Z128WWPNotificationDefinitionId;
                  AssignAttri("", false, "A128WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A128WWPNotificationDefinitionId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0N33( ) ;
                  GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A128WWPNotificationDefinitionId != Z128WWPNotificationDefinitionId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0N33( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPNOTIFICATIONDEFINITIONID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0N33( ) ;
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
         if ( A128WWPNotificationDefinitionId != Z128WWPNotificationDefinitionId )
         {
            A128WWPNotificationDefinitionId = Z128WWPNotificationDefinitionId;
            AssignAttri("", false, "A128WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A128WWPNotificationDefinitionId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
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
         if ( RcdFound33 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtWWPNotificationDefinitionName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0N33( ) ;
         if ( RcdFound33 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0N33( ) ;
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
         if ( RcdFound33 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionName_Internalname;
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
         if ( RcdFound33 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionName_Internalname;
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
         ScanStart0N33( ) ;
         if ( RcdFound33 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound33 != 0 )
            {
               ScanNext0N33( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0N33( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0N33( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000N2 */
            pr_default.execute(0, new Object[] {A128WWPNotificationDefinitionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_NotificationDefinition"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z164WWPNotificationDefinitionName, T000N2_A164WWPNotificationDefinitionName[0]) != 0 ) || ( Z135WWPNotificationDefinitionAppli != T000N2_A135WWPNotificationDefinitionAppli[0] ) || ( Z136WWPNotificationDefinitionAllow != T000N2_A136WWPNotificationDefinitionAllow[0] ) || ( StringUtil.StrCmp(Z134WWPNotificationDefinitionDescr, T000N2_A134WWPNotificationDefinitionDescr[0]) != 0 ) || ( StringUtil.StrCmp(Z167WWPNotificationDefinitionIcon, T000N2_A167WWPNotificationDefinitionIcon[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z168WWPNotificationDefinitionTitle, T000N2_A168WWPNotificationDefinitionTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z169WWPNotificationDefinitionShort, T000N2_A169WWPNotificationDefinitionShort[0]) != 0 ) || ( StringUtil.StrCmp(Z170WWPNotificationDefinitionLongD, T000N2_A170WWPNotificationDefinitionLongD[0]) != 0 ) || ( StringUtil.StrCmp(Z171WWPNotificationDefinitionLink, T000N2_A171WWPNotificationDefinitionLink[0]) != 0 ) || ( StringUtil.StrCmp(Z172WWPNotificationDefinitionSecFu, T000N2_A172WWPNotificationDefinitionSecFu[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z125WWPEntityId != T000N2_A125WWPEntityId[0] ) )
            {
               if ( StringUtil.StrCmp(Z164WWPNotificationDefinitionName, T000N2_A164WWPNotificationDefinitionName[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionName");
                  GXUtil.WriteLogRaw("Old: ",Z164WWPNotificationDefinitionName);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A164WWPNotificationDefinitionName[0]);
               }
               if ( Z135WWPNotificationDefinitionAppli != T000N2_A135WWPNotificationDefinitionAppli[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionAppli");
                  GXUtil.WriteLogRaw("Old: ",Z135WWPNotificationDefinitionAppli);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A135WWPNotificationDefinitionAppli[0]);
               }
               if ( Z136WWPNotificationDefinitionAllow != T000N2_A136WWPNotificationDefinitionAllow[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionAllow");
                  GXUtil.WriteLogRaw("Old: ",Z136WWPNotificationDefinitionAllow);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A136WWPNotificationDefinitionAllow[0]);
               }
               if ( StringUtil.StrCmp(Z134WWPNotificationDefinitionDescr, T000N2_A134WWPNotificationDefinitionDescr[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionDescr");
                  GXUtil.WriteLogRaw("Old: ",Z134WWPNotificationDefinitionDescr);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A134WWPNotificationDefinitionDescr[0]);
               }
               if ( StringUtil.StrCmp(Z167WWPNotificationDefinitionIcon, T000N2_A167WWPNotificationDefinitionIcon[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionIcon");
                  GXUtil.WriteLogRaw("Old: ",Z167WWPNotificationDefinitionIcon);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A167WWPNotificationDefinitionIcon[0]);
               }
               if ( StringUtil.StrCmp(Z168WWPNotificationDefinitionTitle, T000N2_A168WWPNotificationDefinitionTitle[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionTitle");
                  GXUtil.WriteLogRaw("Old: ",Z168WWPNotificationDefinitionTitle);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A168WWPNotificationDefinitionTitle[0]);
               }
               if ( StringUtil.StrCmp(Z169WWPNotificationDefinitionShort, T000N2_A169WWPNotificationDefinitionShort[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionShort");
                  GXUtil.WriteLogRaw("Old: ",Z169WWPNotificationDefinitionShort);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A169WWPNotificationDefinitionShort[0]);
               }
               if ( StringUtil.StrCmp(Z170WWPNotificationDefinitionLongD, T000N2_A170WWPNotificationDefinitionLongD[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionLongD");
                  GXUtil.WriteLogRaw("Old: ",Z170WWPNotificationDefinitionLongD);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A170WWPNotificationDefinitionLongD[0]);
               }
               if ( StringUtil.StrCmp(Z171WWPNotificationDefinitionLink, T000N2_A171WWPNotificationDefinitionLink[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionLink");
                  GXUtil.WriteLogRaw("Old: ",Z171WWPNotificationDefinitionLink);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A171WWPNotificationDefinitionLink[0]);
               }
               if ( StringUtil.StrCmp(Z172WWPNotificationDefinitionSecFu, T000N2_A172WWPNotificationDefinitionSecFu[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionSecFu");
                  GXUtil.WriteLogRaw("Old: ",Z172WWPNotificationDefinitionSecFu);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A172WWPNotificationDefinitionSecFu[0]);
               }
               if ( Z125WWPEntityId != T000N2_A125WWPEntityId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPEntityId");
                  GXUtil.WriteLogRaw("Old: ",Z125WWPEntityId);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A125WWPEntityId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_NotificationDefinition"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0N33( )
      {
         if ( ! IsAuthorized("wwpnotificationdefinition_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0N33( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N33( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0N33( 0) ;
            CheckOptimisticConcurrency0N33( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N33( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0N33( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000N10 */
                     pr_default.execute(8, new Object[] {A164WWPNotificationDefinitionName, A135WWPNotificationDefinitionAppli, A136WWPNotificationDefinitionAllow, A134WWPNotificationDefinitionDescr, A167WWPNotificationDefinitionIcon, A168WWPNotificationDefinitionTitle, A169WWPNotificationDefinitionShort, A170WWPNotificationDefinitionLongD, A171WWPNotificationDefinitionLink, A172WWPNotificationDefinitionSecFu, A125WWPEntityId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000N11 */
                     pr_default.execute(9);
                     A128WWPNotificationDefinitionId = T000N11_A128WWPNotificationDefinitionId[0];
                     AssignAttri("", false, "A128WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A128WWPNotificationDefinitionId), 10, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_NotificationDefinition");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0N0( ) ;
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
               Load0N33( ) ;
            }
            EndLevel0N33( ) ;
         }
         CloseExtendedTableCursors0N33( ) ;
      }

      protected void Update0N33( )
      {
         if ( ! IsAuthorized("wwpnotificationdefinition_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0N33( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N33( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N33( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N33( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0N33( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000N12 */
                     pr_default.execute(10, new Object[] {A164WWPNotificationDefinitionName, A135WWPNotificationDefinitionAppli, A136WWPNotificationDefinitionAllow, A134WWPNotificationDefinitionDescr, A167WWPNotificationDefinitionIcon, A168WWPNotificationDefinitionTitle, A169WWPNotificationDefinitionShort, A170WWPNotificationDefinitionLongD, A171WWPNotificationDefinitionLink, A172WWPNotificationDefinitionSecFu, A125WWPEntityId, A128WWPNotificationDefinitionId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_NotificationDefinition");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_NotificationDefinition"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0N33( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0N0( ) ;
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
            EndLevel0N33( ) ;
         }
         CloseExtendedTableCursors0N33( ) ;
      }

      protected void DeferredUpdate0N33( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("wwpnotificationdefinition_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0N33( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N33( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0N33( ) ;
            AfterConfirm0N33( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0N33( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000N13 */
                  pr_default.execute(11, new Object[] {A128WWPNotificationDefinitionId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_NotificationDefinition");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound33 == 0 )
                        {
                           InitAll0N33( ) ;
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
                        ResetCaption0N0( ) ;
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
         sMode33 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0N33( ) ;
         Gx_mode = sMode33;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0N33( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000N14 */
            pr_default.execute(12, new Object[] {A125WWPEntityId});
            A126WWPEntityName = T000N14_A126WWPEntityName[0];
            AssignAttri("", false, "A126WWPEntityName", A126WWPEntityName);
            pr_default.close(12);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A172WWPNotificationDefinitionSecFu)) )
            {
               A173WWPNotificationDefinitionIsAut = true;
               AssignAttri("", false, "A173WWPNotificationDefinitionIsAut", A173WWPNotificationDefinitionIsAut);
            }
            else
            {
               GXt_boolean1 = A173WWPNotificationDefinitionIsAut;
               new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  A172WWPNotificationDefinitionSecFu, out  GXt_boolean1) ;
               A173WWPNotificationDefinitionIsAut = GXt_boolean1;
               AssignAttri("", false, "A173WWPNotificationDefinitionIsAut", A173WWPNotificationDefinitionIsAut);
            }
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000N15 */
            pr_default.execute(13, new Object[] {A128WWPNotificationDefinitionId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_Notification", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T000N16 */
            pr_default.execute(14, new Object[] {A128WWPNotificationDefinitionId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_Subscription", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void EndLevel0N33( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0N33( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("wwpbaseobjects.notifications.common.wwp_notificationdefinition",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0N0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("wwpbaseobjects.notifications.common.wwp_notificationdefinition",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0N33( )
      {
         /* Using cursor T000N17 */
         pr_default.execute(15);
         RcdFound33 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound33 = 1;
            A128WWPNotificationDefinitionId = T000N17_A128WWPNotificationDefinitionId[0];
            AssignAttri("", false, "A128WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A128WWPNotificationDefinitionId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0N33( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound33 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound33 = 1;
            A128WWPNotificationDefinitionId = T000N17_A128WWPNotificationDefinitionId[0];
            AssignAttri("", false, "A128WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A128WWPNotificationDefinitionId), 10, 0));
         }
      }

      protected void ScanEnd0N33( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm0N33( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0N33( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0N33( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0N33( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0N33( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0N33( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0N33( )
      {
         edtWWPNotificationDefinitionId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionId_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionName_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionName_Enabled), 5, 0), true);
         cmbWWPNotificationDefinitionAppli.Enabled = 0;
         AssignProp("", false, cmbWWPNotificationDefinitionAppli_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPNotificationDefinitionAppli.Enabled), 5, 0), true);
         chkWWPNotificationDefinitionAllow.Enabled = 0;
         AssignProp("", false, chkWWPNotificationDefinitionAllow_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPNotificationDefinitionAllow.Enabled), 5, 0), true);
         edtWWPNotificationDefinitionDescr_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionDescr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionDescr_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionIcon_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionIcon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionIcon_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionTitle_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionTitle_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionShort_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionShort_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionShort_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionLongD_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionLongD_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionLongD_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionLink_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionLink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionLink_Enabled), 5, 0), true);
         edtWWPEntityId_Enabled = 0;
         AssignProp("", false, edtWWPEntityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPEntityId_Enabled), 5, 0), true);
         edtWWPEntityName_Enabled = 0;
         AssignProp("", false, edtWWPEntityName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPEntityName_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionSecFu_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionSecFu_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionSecFu_Enabled), 5, 0), true);
         chkWWPNotificationDefinitionIsAut.Enabled = 0;
         AssignProp("", false, chkWWPNotificationDefinitionIsAut_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPNotificationDefinitionIsAut.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0N33( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0N0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.notifications.common.wwp_notificationdefinition.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z128WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z128WWPNotificationDefinitionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z164WWPNotificationDefinitionName", Z164WWPNotificationDefinitionName);
         GxWebStd.gx_hidden_field( context, "Z135WWPNotificationDefinitionAppli", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z135WWPNotificationDefinitionAppli), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z136WWPNotificationDefinitionAllow", Z136WWPNotificationDefinitionAllow);
         GxWebStd.gx_hidden_field( context, "Z134WWPNotificationDefinitionDescr", Z134WWPNotificationDefinitionDescr);
         GxWebStd.gx_hidden_field( context, "Z167WWPNotificationDefinitionIcon", Z167WWPNotificationDefinitionIcon);
         GxWebStd.gx_hidden_field( context, "Z168WWPNotificationDefinitionTitle", Z168WWPNotificationDefinitionTitle);
         GxWebStd.gx_hidden_field( context, "Z169WWPNotificationDefinitionShort", Z169WWPNotificationDefinitionShort);
         GxWebStd.gx_hidden_field( context, "Z170WWPNotificationDefinitionLongD", Z170WWPNotificationDefinitionLongD);
         GxWebStd.gx_hidden_field( context, "Z171WWPNotificationDefinitionLink", Z171WWPNotificationDefinitionLink);
         GxWebStd.gx_hidden_field( context, "Z172WWPNotificationDefinitionSecFu", Z172WWPNotificationDefinitionSecFu);
         GxWebStd.gx_hidden_field( context, "Z125WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z125WWPEntityId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         return formatLink("wwpbaseobjects.notifications.common.wwp_notificationdefinition.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Notifications.Common.WWP_NotificationDefinition" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Notification Definition", "") ;
      }

      protected void InitializeNonKey0N33( )
      {
         A173WWPNotificationDefinitionIsAut = false;
         AssignAttri("", false, "A173WWPNotificationDefinitionIsAut", A173WWPNotificationDefinitionIsAut);
         A164WWPNotificationDefinitionName = "";
         AssignAttri("", false, "A164WWPNotificationDefinitionName", A164WWPNotificationDefinitionName);
         A135WWPNotificationDefinitionAppli = 0;
         AssignAttri("", false, "A135WWPNotificationDefinitionAppli", StringUtil.Str( (decimal)(A135WWPNotificationDefinitionAppli), 1, 0));
         A136WWPNotificationDefinitionAllow = false;
         AssignAttri("", false, "A136WWPNotificationDefinitionAllow", A136WWPNotificationDefinitionAllow);
         A134WWPNotificationDefinitionDescr = "";
         AssignAttri("", false, "A134WWPNotificationDefinitionDescr", A134WWPNotificationDefinitionDescr);
         A167WWPNotificationDefinitionIcon = "";
         AssignAttri("", false, "A167WWPNotificationDefinitionIcon", A167WWPNotificationDefinitionIcon);
         A168WWPNotificationDefinitionTitle = "";
         AssignAttri("", false, "A168WWPNotificationDefinitionTitle", A168WWPNotificationDefinitionTitle);
         A169WWPNotificationDefinitionShort = "";
         AssignAttri("", false, "A169WWPNotificationDefinitionShort", A169WWPNotificationDefinitionShort);
         A170WWPNotificationDefinitionLongD = "";
         AssignAttri("", false, "A170WWPNotificationDefinitionLongD", A170WWPNotificationDefinitionLongD);
         A171WWPNotificationDefinitionLink = "";
         AssignAttri("", false, "A171WWPNotificationDefinitionLink", A171WWPNotificationDefinitionLink);
         A125WWPEntityId = 0;
         AssignAttri("", false, "A125WWPEntityId", StringUtil.LTrimStr( (decimal)(A125WWPEntityId), 10, 0));
         A126WWPEntityName = "";
         AssignAttri("", false, "A126WWPEntityName", A126WWPEntityName);
         A172WWPNotificationDefinitionSecFu = "";
         AssignAttri("", false, "A172WWPNotificationDefinitionSecFu", A172WWPNotificationDefinitionSecFu);
         Z164WWPNotificationDefinitionName = "";
         Z135WWPNotificationDefinitionAppli = 0;
         Z136WWPNotificationDefinitionAllow = false;
         Z134WWPNotificationDefinitionDescr = "";
         Z167WWPNotificationDefinitionIcon = "";
         Z168WWPNotificationDefinitionTitle = "";
         Z169WWPNotificationDefinitionShort = "";
         Z170WWPNotificationDefinitionLongD = "";
         Z171WWPNotificationDefinitionLink = "";
         Z172WWPNotificationDefinitionSecFu = "";
         Z125WWPEntityId = 0;
      }

      protected void InitAll0N33( )
      {
         A128WWPNotificationDefinitionId = 0;
         AssignAttri("", false, "A128WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A128WWPNotificationDefinitionId), 10, 0));
         InitializeNonKey0N33( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256309404555", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/notifications/common/wwp_notificationdefinition.js", "?20256309404555", false, true);
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
         edtWWPNotificationDefinitionId_Internalname = "WWPNOTIFICATIONDEFINITIONID";
         edtWWPNotificationDefinitionName_Internalname = "WWPNOTIFICATIONDEFINITIONNAME";
         cmbWWPNotificationDefinitionAppli_Internalname = "WWPNOTIFICATIONDEFINITIONAPPLI";
         chkWWPNotificationDefinitionAllow_Internalname = "WWPNOTIFICATIONDEFINITIONALLOW";
         edtWWPNotificationDefinitionDescr_Internalname = "WWPNOTIFICATIONDEFINITIONDESCR";
         edtWWPNotificationDefinitionIcon_Internalname = "WWPNOTIFICATIONDEFINITIONICON";
         edtWWPNotificationDefinitionTitle_Internalname = "WWPNOTIFICATIONDEFINITIONTITLE";
         edtWWPNotificationDefinitionShort_Internalname = "WWPNOTIFICATIONDEFINITIONSHORT";
         edtWWPNotificationDefinitionLongD_Internalname = "WWPNOTIFICATIONDEFINITIONLONGD";
         edtWWPNotificationDefinitionLink_Internalname = "WWPNOTIFICATIONDEFINITIONLINK";
         edtWWPEntityId_Internalname = "WWPENTITYID";
         edtWWPEntityName_Internalname = "WWPENTITYNAME";
         edtWWPNotificationDefinitionSecFu_Internalname = "WWPNOTIFICATIONDEFINITIONSECFU";
         chkWWPNotificationDefinitionIsAut_Internalname = "WWPNOTIFICATIONDEFINITIONISAUT";
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
         Form.Caption = context.GetMessage( "Notification Definition", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkWWPNotificationDefinitionIsAut.Enabled = 0;
         edtWWPNotificationDefinitionSecFu_Enabled = 1;
         edtWWPEntityName_Jsonclick = "";
         edtWWPEntityName_Enabled = 0;
         edtWWPEntityId_Jsonclick = "";
         edtWWPEntityId_Enabled = 1;
         edtWWPNotificationDefinitionLink_Jsonclick = "";
         edtWWPNotificationDefinitionLink_Enabled = 1;
         edtWWPNotificationDefinitionLongD_Enabled = 1;
         edtWWPNotificationDefinitionShort_Enabled = 1;
         edtWWPNotificationDefinitionTitle_Enabled = 1;
         edtWWPNotificationDefinitionIcon_Jsonclick = "";
         edtWWPNotificationDefinitionIcon_Enabled = 1;
         edtWWPNotificationDefinitionDescr_Enabled = 1;
         chkWWPNotificationDefinitionAllow.Enabled = 1;
         cmbWWPNotificationDefinitionAppli_Jsonclick = "";
         cmbWWPNotificationDefinitionAppli.Enabled = 1;
         edtWWPNotificationDefinitionName_Jsonclick = "";
         edtWWPNotificationDefinitionName_Enabled = 1;
         edtWWPNotificationDefinitionId_Jsonclick = "";
         edtWWPNotificationDefinitionId_Enabled = 1;
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

      protected void GX3ASAWWPNOTIFICATIONDEFINITIONISAUT0N33( string A172WWPNotificationDefinitionSecFu )
      {
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A172WWPNotificationDefinitionSecFu)) )
         {
            A173WWPNotificationDefinitionIsAut = true;
            AssignAttri("", false, "A173WWPNotificationDefinitionIsAut", A173WWPNotificationDefinitionIsAut);
         }
         else
         {
            GXt_boolean1 = A173WWPNotificationDefinitionIsAut;
            new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  A172WWPNotificationDefinitionSecFu, out  GXt_boolean1) ;
            A173WWPNotificationDefinitionIsAut = GXt_boolean1;
            AssignAttri("", false, "A173WWPNotificationDefinitionIsAut", A173WWPNotificationDefinitionIsAut);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( A173WWPNotificationDefinitionIsAut))+"\"") ;
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
         cmbWWPNotificationDefinitionAppli.Name = "WWPNOTIFICATIONDEFINITIONAPPLI";
         cmbWWPNotificationDefinitionAppli.WebTags = "";
         cmbWWPNotificationDefinitionAppli.addItem("1", context.GetMessage( "Any record", ""), 0);
         cmbWWPNotificationDefinitionAppli.addItem("2", context.GetMessage( "Specific record", ""), 0);
         if ( cmbWWPNotificationDefinitionAppli.ItemCount > 0 )
         {
            A135WWPNotificationDefinitionAppli = (short)(Math.Round(NumberUtil.Val( cmbWWPNotificationDefinitionAppli.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A135WWPNotificationDefinitionAppli), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A135WWPNotificationDefinitionAppli", StringUtil.Str( (decimal)(A135WWPNotificationDefinitionAppli), 1, 0));
         }
         chkWWPNotificationDefinitionAllow.Name = "WWPNOTIFICATIONDEFINITIONALLOW";
         chkWWPNotificationDefinitionAllow.WebTags = "";
         chkWWPNotificationDefinitionAllow.Caption = context.GetMessage( "Allow User Subscription", "");
         AssignProp("", false, chkWWPNotificationDefinitionAllow_Internalname, "TitleCaption", chkWWPNotificationDefinitionAllow.Caption, true);
         chkWWPNotificationDefinitionAllow.CheckedValue = "false";
         A136WWPNotificationDefinitionAllow = StringUtil.StrToBool( StringUtil.BoolToStr( A136WWPNotificationDefinitionAllow));
         AssignAttri("", false, "A136WWPNotificationDefinitionAllow", A136WWPNotificationDefinitionAllow);
         chkWWPNotificationDefinitionIsAut.Name = "WWPNOTIFICATIONDEFINITIONISAUT";
         chkWWPNotificationDefinitionIsAut.WebTags = "";
         chkWWPNotificationDefinitionIsAut.Caption = context.GetMessage( "User Authorized", "");
         AssignProp("", false, chkWWPNotificationDefinitionIsAut_Internalname, "TitleCaption", chkWWPNotificationDefinitionIsAut.Caption, true);
         chkWWPNotificationDefinitionIsAut.CheckedValue = "false";
         A173WWPNotificationDefinitionIsAut = StringUtil.StrToBool( StringUtil.BoolToStr( A173WWPNotificationDefinitionIsAut));
         AssignAttri("", false, "A173WWPNotificationDefinitionIsAut", A173WWPNotificationDefinitionIsAut);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtWWPNotificationDefinitionName_Internalname;
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

      public void Valid_Wwpnotificationdefinitionid( )
      {
         A135WWPNotificationDefinitionAppli = (short)(Math.Round(NumberUtil.Val( cmbWWPNotificationDefinitionAppli.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbWWPNotificationDefinitionAppli.CurrentValue = StringUtil.Str( (decimal)(A135WWPNotificationDefinitionAppli), 1, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbWWPNotificationDefinitionAppli.ItemCount > 0 )
         {
            A135WWPNotificationDefinitionAppli = (short)(Math.Round(NumberUtil.Val( cmbWWPNotificationDefinitionAppli.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A135WWPNotificationDefinitionAppli), 1, 0))), "."), 18, MidpointRounding.ToEven));
            cmbWWPNotificationDefinitionAppli.CurrentValue = StringUtil.Str( (decimal)(A135WWPNotificationDefinitionAppli), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPNotificationDefinitionAppli.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A135WWPNotificationDefinitionAppli), 1, 0));
         }
         A136WWPNotificationDefinitionAllow = StringUtil.StrToBool( StringUtil.BoolToStr( A136WWPNotificationDefinitionAllow));
         A173WWPNotificationDefinitionIsAut = StringUtil.StrToBool( StringUtil.BoolToStr( A173WWPNotificationDefinitionIsAut));
         /*  Sending validation outputs */
         AssignAttri("", false, "A164WWPNotificationDefinitionName", A164WWPNotificationDefinitionName);
         AssignAttri("", false, "A135WWPNotificationDefinitionAppli", StringUtil.LTrim( StringUtil.NToC( (decimal)(A135WWPNotificationDefinitionAppli), 1, 0, ".", "")));
         cmbWWPNotificationDefinitionAppli.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A135WWPNotificationDefinitionAppli), 1, 0));
         AssignProp("", false, cmbWWPNotificationDefinitionAppli_Internalname, "Values", cmbWWPNotificationDefinitionAppli.ToJavascriptSource(), true);
         AssignAttri("", false, "A136WWPNotificationDefinitionAllow", A136WWPNotificationDefinitionAllow);
         AssignAttri("", false, "A134WWPNotificationDefinitionDescr", A134WWPNotificationDefinitionDescr);
         AssignAttri("", false, "A167WWPNotificationDefinitionIcon", A167WWPNotificationDefinitionIcon);
         AssignAttri("", false, "A168WWPNotificationDefinitionTitle", A168WWPNotificationDefinitionTitle);
         AssignAttri("", false, "A169WWPNotificationDefinitionShort", A169WWPNotificationDefinitionShort);
         AssignAttri("", false, "A170WWPNotificationDefinitionLongD", A170WWPNotificationDefinitionLongD);
         AssignAttri("", false, "A171WWPNotificationDefinitionLink", A171WWPNotificationDefinitionLink);
         AssignAttri("", false, "A125WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A125WWPEntityId), 10, 0, ".", "")));
         AssignAttri("", false, "A172WWPNotificationDefinitionSecFu", A172WWPNotificationDefinitionSecFu);
         AssignAttri("", false, "A126WWPEntityName", A126WWPEntityName);
         AssignAttri("", false, "A173WWPNotificationDefinitionIsAut", A173WWPNotificationDefinitionIsAut);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z128WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z128WWPNotificationDefinitionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z164WWPNotificationDefinitionName", Z164WWPNotificationDefinitionName);
         GxWebStd.gx_hidden_field( context, "Z135WWPNotificationDefinitionAppli", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z135WWPNotificationDefinitionAppli), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z136WWPNotificationDefinitionAllow", StringUtil.BoolToStr( Z136WWPNotificationDefinitionAllow));
         GxWebStd.gx_hidden_field( context, "Z134WWPNotificationDefinitionDescr", Z134WWPNotificationDefinitionDescr);
         GxWebStd.gx_hidden_field( context, "Z167WWPNotificationDefinitionIcon", Z167WWPNotificationDefinitionIcon);
         GxWebStd.gx_hidden_field( context, "Z168WWPNotificationDefinitionTitle", Z168WWPNotificationDefinitionTitle);
         GxWebStd.gx_hidden_field( context, "Z169WWPNotificationDefinitionShort", Z169WWPNotificationDefinitionShort);
         GxWebStd.gx_hidden_field( context, "Z170WWPNotificationDefinitionLongD", Z170WWPNotificationDefinitionLongD);
         GxWebStd.gx_hidden_field( context, "Z171WWPNotificationDefinitionLink", Z171WWPNotificationDefinitionLink);
         GxWebStd.gx_hidden_field( context, "Z125WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z125WWPEntityId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z172WWPNotificationDefinitionSecFu", Z172WWPNotificationDefinitionSecFu);
         GxWebStd.gx_hidden_field( context, "Z126WWPEntityName", Z126WWPEntityName);
         GxWebStd.gx_hidden_field( context, "Z173WWPNotificationDefinitionIsAut", StringUtil.BoolToStr( Z173WWPNotificationDefinitionIsAut));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpentityid( )
      {
         /* Using cursor T000N14 */
         pr_default.execute(12, new Object[] {A125WWPEntityId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Entity", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
            GX_FocusControl = edtWWPEntityId_Internalname;
         }
         A126WWPEntityName = T000N14_A126WWPEntityName[0];
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A126WWPEntityName", A126WWPEntityName);
      }

      public void Valid_Wwpnotificationdefinitionsecfu( )
      {
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A172WWPNotificationDefinitionSecFu)) )
         {
            A173WWPNotificationDefinitionIsAut = true;
         }
         else
         {
            GXt_boolean1 = A173WWPNotificationDefinitionIsAut;
            new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  A172WWPNotificationDefinitionSecFu, out  GXt_boolean1) ;
            A173WWPNotificationDefinitionIsAut = GXt_boolean1;
         }
         dynload_actions( ) ;
         A173WWPNotificationDefinitionIsAut = StringUtil.StrToBool( StringUtil.BoolToStr( A173WWPNotificationDefinitionIsAut));
         /*  Sending validation outputs */
         AssignAttri("", false, "A173WWPNotificationDefinitionIsAut", A173WWPNotificationDefinitionIsAut);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A136WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A173WWPNotificationDefinitionIsAut","fld":"WWPNOTIFICATIONDEFINITIONISAUT"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A136WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A173WWPNotificationDefinitionIsAut","fld":"WWPNOTIFICATIONDEFINITIONISAUT"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A136WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A173WWPNotificationDefinitionIsAut","fld":"WWPNOTIFICATIONDEFINITIONISAUT"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A136WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A173WWPNotificationDefinitionIsAut","fld":"WWPNOTIFICATIONDEFINITIONISAUT"}]}""");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONID","""{"handler":"Valid_Wwpnotificationdefinitionid","iparms":[{"av":"cmbWWPNotificationDefinitionAppli"},{"av":"A135WWPNotificationDefinitionAppli","fld":"WWPNOTIFICATIONDEFINITIONAPPLI","pic":"9"},{"av":"A128WWPNotificationDefinitionId","fld":"WWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"A136WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A173WWPNotificationDefinitionIsAut","fld":"WWPNOTIFICATIONDEFINITIONISAUT"}]""");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONID",""","oparms":[{"av":"A164WWPNotificationDefinitionName","fld":"WWPNOTIFICATIONDEFINITIONNAME"},{"av":"cmbWWPNotificationDefinitionAppli"},{"av":"A135WWPNotificationDefinitionAppli","fld":"WWPNOTIFICATIONDEFINITIONAPPLI","pic":"9"},{"av":"A134WWPNotificationDefinitionDescr","fld":"WWPNOTIFICATIONDEFINITIONDESCR"},{"av":"A167WWPNotificationDefinitionIcon","fld":"WWPNOTIFICATIONDEFINITIONICON"},{"av":"A168WWPNotificationDefinitionTitle","fld":"WWPNOTIFICATIONDEFINITIONTITLE"},{"av":"A169WWPNotificationDefinitionShort","fld":"WWPNOTIFICATIONDEFINITIONSHORT"},{"av":"A170WWPNotificationDefinitionLongD","fld":"WWPNOTIFICATIONDEFINITIONLONGD"},{"av":"A171WWPNotificationDefinitionLink","fld":"WWPNOTIFICATIONDEFINITIONLINK"},{"av":"A125WWPEntityId","fld":"WWPENTITYID","pic":"ZZZZZZZZZ9"},{"av":"A172WWPNotificationDefinitionSecFu","fld":"WWPNOTIFICATIONDEFINITIONSECFU"},{"av":"A126WWPEntityName","fld":"WWPENTITYNAME"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z128WWPNotificationDefinitionId"},{"av":"Z164WWPNotificationDefinitionName"},{"av":"Z135WWPNotificationDefinitionAppli"},{"av":"Z136WWPNotificationDefinitionAllow"},{"av":"Z134WWPNotificationDefinitionDescr"},{"av":"Z167WWPNotificationDefinitionIcon"},{"av":"Z168WWPNotificationDefinitionTitle"},{"av":"Z169WWPNotificationDefinitionShort"},{"av":"Z170WWPNotificationDefinitionLongD"},{"av":"Z171WWPNotificationDefinitionLink"},{"av":"Z125WWPEntityId"},{"av":"Z172WWPNotificationDefinitionSecFu"},{"av":"Z126WWPEntityName"},{"av":"Z173WWPNotificationDefinitionIsAut"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A136WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A173WWPNotificationDefinitionIsAut","fld":"WWPNOTIFICATIONDEFINITIONISAUT"}]}""");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONAPPLI","""{"handler":"Valid_Wwpnotificationdefinitionappli","iparms":[{"av":"A136WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A173WWPNotificationDefinitionIsAut","fld":"WWPNOTIFICATIONDEFINITIONISAUT"}]""");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONAPPLI",""","oparms":[{"av":"A136WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A173WWPNotificationDefinitionIsAut","fld":"WWPNOTIFICATIONDEFINITIONISAUT"}]}""");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONLINK","""{"handler":"Valid_Wwpnotificationdefinitionlink","iparms":[{"av":"A136WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A173WWPNotificationDefinitionIsAut","fld":"WWPNOTIFICATIONDEFINITIONISAUT"}]""");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONLINK",""","oparms":[{"av":"A136WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A173WWPNotificationDefinitionIsAut","fld":"WWPNOTIFICATIONDEFINITIONISAUT"}]}""");
         setEventMetadata("VALID_WWPENTITYID","""{"handler":"Valid_Wwpentityid","iparms":[{"av":"A125WWPEntityId","fld":"WWPENTITYID","pic":"ZZZZZZZZZ9"},{"av":"A126WWPEntityName","fld":"WWPENTITYNAME"},{"av":"A136WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A173WWPNotificationDefinitionIsAut","fld":"WWPNOTIFICATIONDEFINITIONISAUT"}]""");
         setEventMetadata("VALID_WWPENTITYID",""","oparms":[{"av":"A126WWPEntityName","fld":"WWPENTITYNAME"},{"av":"A136WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A173WWPNotificationDefinitionIsAut","fld":"WWPNOTIFICATIONDEFINITIONISAUT"}]}""");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONSECFU","""{"handler":"Valid_Wwpnotificationdefinitionsecfu","iparms":[{"av":"A172WWPNotificationDefinitionSecFu","fld":"WWPNOTIFICATIONDEFINITIONSECFU"},{"av":"A136WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A173WWPNotificationDefinitionIsAut","fld":"WWPNOTIFICATIONDEFINITIONISAUT"}]""");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONSECFU",""","oparms":[{"av":"A136WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A173WWPNotificationDefinitionIsAut","fld":"WWPNOTIFICATIONDEFINITIONISAUT"}]}""");
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
         Z164WWPNotificationDefinitionName = "";
         Z134WWPNotificationDefinitionDescr = "";
         Z167WWPNotificationDefinitionIcon = "";
         Z168WWPNotificationDefinitionTitle = "";
         Z169WWPNotificationDefinitionShort = "";
         Z170WWPNotificationDefinitionLongD = "";
         Z171WWPNotificationDefinitionLink = "";
         Z172WWPNotificationDefinitionSecFu = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A172WWPNotificationDefinitionSecFu = "";
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
         A134WWPNotificationDefinitionDescr = "";
         A167WWPNotificationDefinitionIcon = "";
         A168WWPNotificationDefinitionTitle = "";
         A169WWPNotificationDefinitionShort = "";
         A170WWPNotificationDefinitionLongD = "";
         A171WWPNotificationDefinitionLink = "";
         A126WWPEntityName = "";
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
         Z126WWPEntityName = "";
         T000N5_A128WWPNotificationDefinitionId = new long[1] ;
         T000N5_A164WWPNotificationDefinitionName = new string[] {""} ;
         T000N5_A135WWPNotificationDefinitionAppli = new short[1] ;
         T000N5_A136WWPNotificationDefinitionAllow = new bool[] {false} ;
         T000N5_A134WWPNotificationDefinitionDescr = new string[] {""} ;
         T000N5_A167WWPNotificationDefinitionIcon = new string[] {""} ;
         T000N5_A168WWPNotificationDefinitionTitle = new string[] {""} ;
         T000N5_A169WWPNotificationDefinitionShort = new string[] {""} ;
         T000N5_A170WWPNotificationDefinitionLongD = new string[] {""} ;
         T000N5_A171WWPNotificationDefinitionLink = new string[] {""} ;
         T000N5_A126WWPEntityName = new string[] {""} ;
         T000N5_A172WWPNotificationDefinitionSecFu = new string[] {""} ;
         T000N5_A125WWPEntityId = new long[1] ;
         T000N4_A126WWPEntityName = new string[] {""} ;
         T000N6_A126WWPEntityName = new string[] {""} ;
         T000N7_A128WWPNotificationDefinitionId = new long[1] ;
         T000N3_A128WWPNotificationDefinitionId = new long[1] ;
         T000N3_A164WWPNotificationDefinitionName = new string[] {""} ;
         T000N3_A135WWPNotificationDefinitionAppli = new short[1] ;
         T000N3_A136WWPNotificationDefinitionAllow = new bool[] {false} ;
         T000N3_A134WWPNotificationDefinitionDescr = new string[] {""} ;
         T000N3_A167WWPNotificationDefinitionIcon = new string[] {""} ;
         T000N3_A168WWPNotificationDefinitionTitle = new string[] {""} ;
         T000N3_A169WWPNotificationDefinitionShort = new string[] {""} ;
         T000N3_A170WWPNotificationDefinitionLongD = new string[] {""} ;
         T000N3_A171WWPNotificationDefinitionLink = new string[] {""} ;
         T000N3_A172WWPNotificationDefinitionSecFu = new string[] {""} ;
         T000N3_A125WWPEntityId = new long[1] ;
         sMode33 = "";
         T000N8_A128WWPNotificationDefinitionId = new long[1] ;
         T000N9_A128WWPNotificationDefinitionId = new long[1] ;
         T000N2_A128WWPNotificationDefinitionId = new long[1] ;
         T000N2_A164WWPNotificationDefinitionName = new string[] {""} ;
         T000N2_A135WWPNotificationDefinitionAppli = new short[1] ;
         T000N2_A136WWPNotificationDefinitionAllow = new bool[] {false} ;
         T000N2_A134WWPNotificationDefinitionDescr = new string[] {""} ;
         T000N2_A167WWPNotificationDefinitionIcon = new string[] {""} ;
         T000N2_A168WWPNotificationDefinitionTitle = new string[] {""} ;
         T000N2_A169WWPNotificationDefinitionShort = new string[] {""} ;
         T000N2_A170WWPNotificationDefinitionLongD = new string[] {""} ;
         T000N2_A171WWPNotificationDefinitionLink = new string[] {""} ;
         T000N2_A172WWPNotificationDefinitionSecFu = new string[] {""} ;
         T000N2_A125WWPEntityId = new long[1] ;
         T000N11_A128WWPNotificationDefinitionId = new long[1] ;
         T000N14_A126WWPEntityName = new string[] {""} ;
         T000N15_A127WWPNotificationId = new long[1] ;
         T000N16_A130WWPSubscriptionId = new long[1] ;
         T000N17_A128WWPNotificationDefinitionId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ164WWPNotificationDefinitionName = "";
         ZZ134WWPNotificationDefinitionDescr = "";
         ZZ167WWPNotificationDefinitionIcon = "";
         ZZ168WWPNotificationDefinitionTitle = "";
         ZZ169WWPNotificationDefinitionShort = "";
         ZZ170WWPNotificationDefinitionLongD = "";
         ZZ171WWPNotificationDefinitionLink = "";
         ZZ172WWPNotificationDefinitionSecFu = "";
         ZZ126WWPEntityName = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notificationdefinition__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notificationdefinition__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notificationdefinition__default(),
            new Object[][] {
                new Object[] {
               T000N2_A128WWPNotificationDefinitionId, T000N2_A164WWPNotificationDefinitionName, T000N2_A135WWPNotificationDefinitionAppli, T000N2_A136WWPNotificationDefinitionAllow, T000N2_A134WWPNotificationDefinitionDescr, T000N2_A167WWPNotificationDefinitionIcon, T000N2_A168WWPNotificationDefinitionTitle, T000N2_A169WWPNotificationDefinitionShort, T000N2_A170WWPNotificationDefinitionLongD, T000N2_A171WWPNotificationDefinitionLink,
               T000N2_A172WWPNotificationDefinitionSecFu, T000N2_A125WWPEntityId
               }
               , new Object[] {
               T000N3_A128WWPNotificationDefinitionId, T000N3_A164WWPNotificationDefinitionName, T000N3_A135WWPNotificationDefinitionAppli, T000N3_A136WWPNotificationDefinitionAllow, T000N3_A134WWPNotificationDefinitionDescr, T000N3_A167WWPNotificationDefinitionIcon, T000N3_A168WWPNotificationDefinitionTitle, T000N3_A169WWPNotificationDefinitionShort, T000N3_A170WWPNotificationDefinitionLongD, T000N3_A171WWPNotificationDefinitionLink,
               T000N3_A172WWPNotificationDefinitionSecFu, T000N3_A125WWPEntityId
               }
               , new Object[] {
               T000N4_A126WWPEntityName
               }
               , new Object[] {
               T000N5_A128WWPNotificationDefinitionId, T000N5_A164WWPNotificationDefinitionName, T000N5_A135WWPNotificationDefinitionAppli, T000N5_A136WWPNotificationDefinitionAllow, T000N5_A134WWPNotificationDefinitionDescr, T000N5_A167WWPNotificationDefinitionIcon, T000N5_A168WWPNotificationDefinitionTitle, T000N5_A169WWPNotificationDefinitionShort, T000N5_A170WWPNotificationDefinitionLongD, T000N5_A171WWPNotificationDefinitionLink,
               T000N5_A126WWPEntityName, T000N5_A172WWPNotificationDefinitionSecFu, T000N5_A125WWPEntityId
               }
               , new Object[] {
               T000N6_A126WWPEntityName
               }
               , new Object[] {
               T000N7_A128WWPNotificationDefinitionId
               }
               , new Object[] {
               T000N8_A128WWPNotificationDefinitionId
               }
               , new Object[] {
               T000N9_A128WWPNotificationDefinitionId
               }
               , new Object[] {
               }
               , new Object[] {
               T000N11_A128WWPNotificationDefinitionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000N14_A126WWPEntityName
               }
               , new Object[] {
               T000N15_A127WWPNotificationId
               }
               , new Object[] {
               T000N16_A130WWPSubscriptionId
               }
               , new Object[] {
               T000N17_A128WWPNotificationDefinitionId
               }
            }
         );
      }

      private short Z135WWPNotificationDefinitionAppli ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A135WWPNotificationDefinitionAppli ;
      private short RcdFound33 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ135WWPNotificationDefinitionAppli ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPNotificationDefinitionId_Enabled ;
      private int edtWWPNotificationDefinitionName_Enabled ;
      private int edtWWPNotificationDefinitionDescr_Enabled ;
      private int edtWWPNotificationDefinitionIcon_Enabled ;
      private int edtWWPNotificationDefinitionTitle_Enabled ;
      private int edtWWPNotificationDefinitionShort_Enabled ;
      private int edtWWPNotificationDefinitionLongD_Enabled ;
      private int edtWWPNotificationDefinitionLink_Enabled ;
      private int edtWWPEntityId_Enabled ;
      private int edtWWPEntityName_Enabled ;
      private int edtWWPNotificationDefinitionSecFu_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z128WWPNotificationDefinitionId ;
      private long Z125WWPEntityId ;
      private long A125WWPEntityId ;
      private long A128WWPNotificationDefinitionId ;
      private long ZZ128WWPNotificationDefinitionId ;
      private long ZZ125WWPEntityId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPNotificationDefinitionId_Internalname ;
      private string cmbWWPNotificationDefinitionAppli_Internalname ;
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
      private string edtWWPNotificationDefinitionId_Jsonclick ;
      private string edtWWPNotificationDefinitionName_Internalname ;
      private string edtWWPNotificationDefinitionName_Jsonclick ;
      private string cmbWWPNotificationDefinitionAppli_Jsonclick ;
      private string chkWWPNotificationDefinitionAllow_Internalname ;
      private string edtWWPNotificationDefinitionDescr_Internalname ;
      private string edtWWPNotificationDefinitionIcon_Internalname ;
      private string edtWWPNotificationDefinitionIcon_Jsonclick ;
      private string edtWWPNotificationDefinitionTitle_Internalname ;
      private string edtWWPNotificationDefinitionShort_Internalname ;
      private string edtWWPNotificationDefinitionLongD_Internalname ;
      private string edtWWPNotificationDefinitionLink_Internalname ;
      private string edtWWPNotificationDefinitionLink_Jsonclick ;
      private string edtWWPEntityId_Internalname ;
      private string edtWWPEntityId_Jsonclick ;
      private string edtWWPEntityName_Internalname ;
      private string edtWWPEntityName_Jsonclick ;
      private string edtWWPNotificationDefinitionSecFu_Internalname ;
      private string chkWWPNotificationDefinitionIsAut_Internalname ;
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
      private string sMode33 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool Z136WWPNotificationDefinitionAllow ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A136WWPNotificationDefinitionAllow ;
      private bool A173WWPNotificationDefinitionIsAut ;
      private bool Gx_longc ;
      private bool Z173WWPNotificationDefinitionIsAut ;
      private bool ZZ136WWPNotificationDefinitionAllow ;
      private bool ZZ173WWPNotificationDefinitionIsAut ;
      private bool GXt_boolean1 ;
      private string Z164WWPNotificationDefinitionName ;
      private string Z134WWPNotificationDefinitionDescr ;
      private string Z167WWPNotificationDefinitionIcon ;
      private string Z168WWPNotificationDefinitionTitle ;
      private string Z169WWPNotificationDefinitionShort ;
      private string Z170WWPNotificationDefinitionLongD ;
      private string Z171WWPNotificationDefinitionLink ;
      private string Z172WWPNotificationDefinitionSecFu ;
      private string A172WWPNotificationDefinitionSecFu ;
      private string A164WWPNotificationDefinitionName ;
      private string A134WWPNotificationDefinitionDescr ;
      private string A167WWPNotificationDefinitionIcon ;
      private string A168WWPNotificationDefinitionTitle ;
      private string A169WWPNotificationDefinitionShort ;
      private string A170WWPNotificationDefinitionLongD ;
      private string A171WWPNotificationDefinitionLink ;
      private string A126WWPEntityName ;
      private string Z126WWPEntityName ;
      private string ZZ164WWPNotificationDefinitionName ;
      private string ZZ134WWPNotificationDefinitionDescr ;
      private string ZZ167WWPNotificationDefinitionIcon ;
      private string ZZ168WWPNotificationDefinitionTitle ;
      private string ZZ169WWPNotificationDefinitionShort ;
      private string ZZ170WWPNotificationDefinitionLongD ;
      private string ZZ171WWPNotificationDefinitionLink ;
      private string ZZ172WWPNotificationDefinitionSecFu ;
      private string ZZ126WWPEntityName ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbWWPNotificationDefinitionAppli ;
      private GXCheckbox chkWWPNotificationDefinitionAllow ;
      private GXCheckbox chkWWPNotificationDefinitionIsAut ;
      private IDataStoreProvider pr_default ;
      private long[] T000N5_A128WWPNotificationDefinitionId ;
      private string[] T000N5_A164WWPNotificationDefinitionName ;
      private short[] T000N5_A135WWPNotificationDefinitionAppli ;
      private bool[] T000N5_A136WWPNotificationDefinitionAllow ;
      private string[] T000N5_A134WWPNotificationDefinitionDescr ;
      private string[] T000N5_A167WWPNotificationDefinitionIcon ;
      private string[] T000N5_A168WWPNotificationDefinitionTitle ;
      private string[] T000N5_A169WWPNotificationDefinitionShort ;
      private string[] T000N5_A170WWPNotificationDefinitionLongD ;
      private string[] T000N5_A171WWPNotificationDefinitionLink ;
      private string[] T000N5_A126WWPEntityName ;
      private string[] T000N5_A172WWPNotificationDefinitionSecFu ;
      private long[] T000N5_A125WWPEntityId ;
      private string[] T000N4_A126WWPEntityName ;
      private string[] T000N6_A126WWPEntityName ;
      private long[] T000N7_A128WWPNotificationDefinitionId ;
      private long[] T000N3_A128WWPNotificationDefinitionId ;
      private string[] T000N3_A164WWPNotificationDefinitionName ;
      private short[] T000N3_A135WWPNotificationDefinitionAppli ;
      private bool[] T000N3_A136WWPNotificationDefinitionAllow ;
      private string[] T000N3_A134WWPNotificationDefinitionDescr ;
      private string[] T000N3_A167WWPNotificationDefinitionIcon ;
      private string[] T000N3_A168WWPNotificationDefinitionTitle ;
      private string[] T000N3_A169WWPNotificationDefinitionShort ;
      private string[] T000N3_A170WWPNotificationDefinitionLongD ;
      private string[] T000N3_A171WWPNotificationDefinitionLink ;
      private string[] T000N3_A172WWPNotificationDefinitionSecFu ;
      private long[] T000N3_A125WWPEntityId ;
      private long[] T000N8_A128WWPNotificationDefinitionId ;
      private long[] T000N9_A128WWPNotificationDefinitionId ;
      private long[] T000N2_A128WWPNotificationDefinitionId ;
      private string[] T000N2_A164WWPNotificationDefinitionName ;
      private short[] T000N2_A135WWPNotificationDefinitionAppli ;
      private bool[] T000N2_A136WWPNotificationDefinitionAllow ;
      private string[] T000N2_A134WWPNotificationDefinitionDescr ;
      private string[] T000N2_A167WWPNotificationDefinitionIcon ;
      private string[] T000N2_A168WWPNotificationDefinitionTitle ;
      private string[] T000N2_A169WWPNotificationDefinitionShort ;
      private string[] T000N2_A170WWPNotificationDefinitionLongD ;
      private string[] T000N2_A171WWPNotificationDefinitionLink ;
      private string[] T000N2_A172WWPNotificationDefinitionSecFu ;
      private long[] T000N2_A125WWPEntityId ;
      private long[] T000N11_A128WWPNotificationDefinitionId ;
      private string[] T000N14_A126WWPEntityName ;
      private long[] T000N15_A127WWPNotificationId ;
      private long[] T000N16_A130WWPSubscriptionId ;
      private long[] T000N17_A128WWPNotificationDefinitionId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_notificationdefinition__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_notificationdefinition__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_notificationdefinition__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[14])
      ,new ForEachCursor(def[15])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT000N2;
       prmT000N2 = new Object[] {
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       Object[] prmT000N3;
       prmT000N3 = new Object[] {
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       Object[] prmT000N4;
       prmT000N4 = new Object[] {
       new ParDef("WWPEntityId",GXType.Int64,10,0)
       };
       Object[] prmT000N5;
       prmT000N5 = new Object[] {
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       Object[] prmT000N6;
       prmT000N6 = new Object[] {
       new ParDef("WWPEntityId",GXType.Int64,10,0)
       };
       Object[] prmT000N7;
       prmT000N7 = new Object[] {
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       Object[] prmT000N8;
       prmT000N8 = new Object[] {
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       Object[] prmT000N9;
       prmT000N9 = new Object[] {
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       Object[] prmT000N10;
       prmT000N10 = new Object[] {
       new ParDef("WWPNotificationDefinitionName",GXType.VarChar,100,0) ,
       new ParDef("WWPNotificationDefinitionAppli",GXType.Int16,1,0) ,
       new ParDef("WWPNotificationDefinitionAllow",GXType.Boolean,4,0) ,
       new ParDef("WWPNotificationDefinitionDescr",GXType.VarChar,200,0) ,
       new ParDef("WWPNotificationDefinitionIcon",GXType.VarChar,40,0) ,
       new ParDef("WWPNotificationDefinitionTitle",GXType.VarChar,200,0) ,
       new ParDef("WWPNotificationDefinitionShort",GXType.VarChar,200,0) ,
       new ParDef("WWPNotificationDefinitionLongD",GXType.VarChar,1000,0) ,
       new ParDef("WWPNotificationDefinitionLink",GXType.VarChar,1000,0) ,
       new ParDef("WWPNotificationDefinitionSecFu",GXType.VarChar,200,0) ,
       new ParDef("WWPEntityId",GXType.Int64,10,0)
       };
       Object[] prmT000N11;
       prmT000N11 = new Object[] {
       };
       Object[] prmT000N12;
       prmT000N12 = new Object[] {
       new ParDef("WWPNotificationDefinitionName",GXType.VarChar,100,0) ,
       new ParDef("WWPNotificationDefinitionAppli",GXType.Int16,1,0) ,
       new ParDef("WWPNotificationDefinitionAllow",GXType.Boolean,4,0) ,
       new ParDef("WWPNotificationDefinitionDescr",GXType.VarChar,200,0) ,
       new ParDef("WWPNotificationDefinitionIcon",GXType.VarChar,40,0) ,
       new ParDef("WWPNotificationDefinitionTitle",GXType.VarChar,200,0) ,
       new ParDef("WWPNotificationDefinitionShort",GXType.VarChar,200,0) ,
       new ParDef("WWPNotificationDefinitionLongD",GXType.VarChar,1000,0) ,
       new ParDef("WWPNotificationDefinitionLink",GXType.VarChar,1000,0) ,
       new ParDef("WWPNotificationDefinitionSecFu",GXType.VarChar,200,0) ,
       new ParDef("WWPEntityId",GXType.Int64,10,0) ,
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       Object[] prmT000N13;
       prmT000N13 = new Object[] {
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       Object[] prmT000N14;
       prmT000N14 = new Object[] {
       new ParDef("WWPEntityId",GXType.Int64,10,0)
       };
       Object[] prmT000N15;
       prmT000N15 = new Object[] {
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       Object[] prmT000N16;
       prmT000N16 = new Object[] {
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       Object[] prmT000N17;
       prmT000N17 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T000N2", "SELECT WWPNotificationDefinitionId, WWPNotificationDefinitionName, WWPNotificationDefinitionAppli, WWPNotificationDefinitionAllow, WWPNotificationDefinitionDescr, WWPNotificationDefinitionIcon, WWPNotificationDefinitionTitle, WWPNotificationDefinitionShort, WWPNotificationDefinitionLongD, WWPNotificationDefinitionLink, WWPNotificationDefinitionSecFu, WWPEntityId FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId  FOR UPDATE OF WWP_NotificationDefinition NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000N2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000N3", "SELECT WWPNotificationDefinitionId, WWPNotificationDefinitionName, WWPNotificationDefinitionAppli, WWPNotificationDefinitionAllow, WWPNotificationDefinitionDescr, WWPNotificationDefinitionIcon, WWPNotificationDefinitionTitle, WWPNotificationDefinitionShort, WWPNotificationDefinitionLongD, WWPNotificationDefinitionLink, WWPNotificationDefinitionSecFu, WWPEntityId FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000N4", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000N5", "SELECT TM1.WWPNotificationDefinitionId, TM1.WWPNotificationDefinitionName, TM1.WWPNotificationDefinitionAppli, TM1.WWPNotificationDefinitionAllow, TM1.WWPNotificationDefinitionDescr, TM1.WWPNotificationDefinitionIcon, TM1.WWPNotificationDefinitionTitle, TM1.WWPNotificationDefinitionShort, TM1.WWPNotificationDefinitionLongD, TM1.WWPNotificationDefinitionLink, T2.WWPEntityName, TM1.WWPNotificationDefinitionSecFu, TM1.WWPEntityId FROM (WWP_NotificationDefinition TM1 INNER JOIN WWP_Entity T2 ON T2.WWPEntityId = TM1.WWPEntityId) WHERE TM1.WWPNotificationDefinitionId = :WWPNotificationDefinitionId ORDER BY TM1.WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N5,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000N6", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000N7", "SELECT WWPNotificationDefinitionId FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000N8", "SELECT WWPNotificationDefinitionId FROM WWP_NotificationDefinition WHERE ( WWPNotificationDefinitionId > :WWPNotificationDefinitionId) ORDER BY WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N8,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000N9", "SELECT WWPNotificationDefinitionId FROM WWP_NotificationDefinition WHERE ( WWPNotificationDefinitionId < :WWPNotificationDefinitionId) ORDER BY WWPNotificationDefinitionId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N9,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000N10", "SAVEPOINT gxupdate;INSERT INTO WWP_NotificationDefinition(WWPNotificationDefinitionName, WWPNotificationDefinitionAppli, WWPNotificationDefinitionAllow, WWPNotificationDefinitionDescr, WWPNotificationDefinitionIcon, WWPNotificationDefinitionTitle, WWPNotificationDefinitionShort, WWPNotificationDefinitionLongD, WWPNotificationDefinitionLink, WWPNotificationDefinitionSecFu, WWPEntityId) VALUES(:WWPNotificationDefinitionName, :WWPNotificationDefinitionAppli, :WWPNotificationDefinitionAllow, :WWPNotificationDefinitionDescr, :WWPNotificationDefinitionIcon, :WWPNotificationDefinitionTitle, :WWPNotificationDefinitionShort, :WWPNotificationDefinitionLongD, :WWPNotificationDefinitionLink, :WWPNotificationDefinitionSecFu, :WWPEntityId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000N10)
          ,new CursorDef("T000N11", "SELECT currval('WWPNotificationDefinitionId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N11,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000N12", "SAVEPOINT gxupdate;UPDATE WWP_NotificationDefinition SET WWPNotificationDefinitionName=:WWPNotificationDefinitionName, WWPNotificationDefinitionAppli=:WWPNotificationDefinitionAppli, WWPNotificationDefinitionAllow=:WWPNotificationDefinitionAllow, WWPNotificationDefinitionDescr=:WWPNotificationDefinitionDescr, WWPNotificationDefinitionIcon=:WWPNotificationDefinitionIcon, WWPNotificationDefinitionTitle=:WWPNotificationDefinitionTitle, WWPNotificationDefinitionShort=:WWPNotificationDefinitionShort, WWPNotificationDefinitionLongD=:WWPNotificationDefinitionLongD, WWPNotificationDefinitionLink=:WWPNotificationDefinitionLink, WWPNotificationDefinitionSecFu=:WWPNotificationDefinitionSecFu, WWPEntityId=:WWPEntityId  WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000N12)
          ,new CursorDef("T000N13", "SAVEPOINT gxupdate;DELETE FROM WWP_NotificationDefinition  WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000N13)
          ,new CursorDef("T000N14", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N14,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000N15", "SELECT WWPNotificationId FROM WWP_Notification WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N15,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000N16", "SELECT WWPSubscriptionId FROM WWP_Subscription WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N16,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000N17", "SELECT WWPNotificationDefinitionId FROM WWP_NotificationDefinition ORDER BY WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N17,100, GxCacheFrequency.OFF ,true,false )
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
             ((short[]) buf[2])[0] = rslt.getShort(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((long[]) buf[11])[0] = rslt.getLong(12);
             return;
          case 1 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((long[]) buf[11])[0] = rslt.getLong(12);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 3 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((long[]) buf[12])[0] = rslt.getLong(13);
             return;
          case 4 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 13 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 14 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 15 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
    }
 }

}

}
