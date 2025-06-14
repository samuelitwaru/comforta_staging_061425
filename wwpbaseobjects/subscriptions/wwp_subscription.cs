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
namespace GeneXus.Programs.wwpbaseobjects.subscriptions {
   public class wwp_subscription : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A128WWPNotificationDefinitionId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPNotificationDefinitionId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A128WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A128WWPNotificationDefinitionId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A128WWPNotificationDefinitionId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
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
            gxLoad_4( A112WWPUserExtendedId) ;
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
         Form.Meta.addItem("description", context.GetMessage( "WWP_Subscription", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPSubscriptionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_subscription( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_subscription( IGxContext context )
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
         chkWWPSubscriptionSubscribed = new GXCheckbox();
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
            return "wwpsubscription_Execute" ;
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
         A132WWPSubscriptionSubscribed = StringUtil.StrToBool( StringUtil.BoolToStr( A132WWPSubscriptionSubscribed));
         AssignAttri("", false, "A132WWPSubscriptionSubscribed", A132WWPSubscriptionSubscribed);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "WWP_Subscription", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSubscriptionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSubscriptionId_Internalname, context.GetMessage( "Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPSubscriptionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A130WWPSubscriptionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPSubscriptionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A130WWPSubscriptionId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A130WWPSubscriptionId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPSubscriptionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPSubscriptionId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
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
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A128WWPNotificationDefinitionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPNotificationDefinitionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A128WWPNotificationDefinitionId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A128WWPNotificationDefinitionId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationDefinitionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
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
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionDescr_Internalname, context.GetMessage( "Notification Definition Description", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationDefinitionDescr_Internalname, A134WWPNotificationDefinitionDescr, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtWWPNotificationDefinitionDescr_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPEntityName_Internalname, A126WWPEntityName, StringUtil.RTrim( context.localUtil.Format( A126WWPEntityName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPEntityName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPEntityName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedId_Internalname, StringUtil.RTrim( A112WWPUserExtendedId), StringUtil.RTrim( context.localUtil.Format( A112WWPUserExtendedId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedId_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_GAMGUID", "start", true, "", "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedFullName_Internalname, A113WWPUserExtendedFullName, StringUtil.RTrim( context.localUtil.Format( A113WWPUserExtendedFullName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedFullName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedFullName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSubscriptionEntityRecordId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSubscriptionEntityRecordId_Internalname, context.GetMessage( "Record Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPSubscriptionEntityRecordId_Internalname, A131WWPSubscriptionEntityRecordId, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", 0, 1, edtWWPSubscriptionEntityRecordId_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSubscriptionEntityRecordDes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSubscriptionEntityRecordDes_Internalname, context.GetMessage( "Record Description", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPSubscriptionEntityRecordDes_Internalname, A133WWPSubscriptionEntityRecordDes, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", 0, 1, edtWWPSubscriptionEntityRecordDes_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSubscriptionRoleId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSubscriptionRoleId_Internalname, context.GetMessage( "Role Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPSubscriptionRoleId_Internalname, StringUtil.RTrim( A124WWPSubscriptionRoleId), StringUtil.RTrim( context.localUtil.Format( A124WWPSubscriptionRoleId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPSubscriptionRoleId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPSubscriptionRoleId_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_GAMGUID", "start", true, "", "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPSubscriptionSubscribed_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPSubscriptionSubscribed_Internalname, context.GetMessage( "Subscribed", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPSubscriptionSubscribed_Internalname, StringUtil.BoolToStr( A132WWPSubscriptionSubscribed), "", context.GetMessage( "Subscribed", ""), 1, chkWWPSubscriptionSubscribed.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(79, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,79);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
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
            Z130WWPSubscriptionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z130WWPSubscriptionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z131WWPSubscriptionEntityRecordId = cgiGet( "Z131WWPSubscriptionEntityRecordId");
            Z133WWPSubscriptionEntityRecordDes = cgiGet( "Z133WWPSubscriptionEntityRecordDes");
            Z124WWPSubscriptionRoleId = cgiGet( "Z124WWPSubscriptionRoleId");
            n124WWPSubscriptionRoleId = (String.IsNullOrEmpty(StringUtil.RTrim( A124WWPSubscriptionRoleId)) ? true : false);
            Z132WWPSubscriptionSubscribed = StringUtil.StrToBool( cgiGet( "Z132WWPSubscriptionSubscribed"));
            Z128WWPNotificationDefinitionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z128WWPNotificationDefinitionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z112WWPUserExtendedId = cgiGet( "Z112WWPUserExtendedId");
            n112WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A112WWPUserExtendedId)) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            A125WWPEntityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "WWPENTITYID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPSubscriptionId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPSubscriptionId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPSUBSCRIPTIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPSubscriptionId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A130WWPSubscriptionId = 0;
               AssignAttri("", false, "A130WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A130WWPSubscriptionId), 10, 0));
            }
            else
            {
               A130WWPSubscriptionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPSubscriptionId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A130WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A130WWPSubscriptionId), 10, 0));
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
            A134WWPNotificationDefinitionDescr = cgiGet( edtWWPNotificationDefinitionDescr_Internalname);
            AssignAttri("", false, "A134WWPNotificationDefinitionDescr", A134WWPNotificationDefinitionDescr);
            A126WWPEntityName = cgiGet( edtWWPEntityName_Internalname);
            AssignAttri("", false, "A126WWPEntityName", A126WWPEntityName);
            A112WWPUserExtendedId = cgiGet( edtWWPUserExtendedId_Internalname);
            n112WWPUserExtendedId = false;
            AssignAttri("", false, "A112WWPUserExtendedId", A112WWPUserExtendedId);
            n112WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A112WWPUserExtendedId)) ? true : false);
            A113WWPUserExtendedFullName = cgiGet( edtWWPUserExtendedFullName_Internalname);
            AssignAttri("", false, "A113WWPUserExtendedFullName", A113WWPUserExtendedFullName);
            A131WWPSubscriptionEntityRecordId = cgiGet( edtWWPSubscriptionEntityRecordId_Internalname);
            AssignAttri("", false, "A131WWPSubscriptionEntityRecordId", A131WWPSubscriptionEntityRecordId);
            A133WWPSubscriptionEntityRecordDes = cgiGet( edtWWPSubscriptionEntityRecordDes_Internalname);
            AssignAttri("", false, "A133WWPSubscriptionEntityRecordDes", A133WWPSubscriptionEntityRecordDes);
            A124WWPSubscriptionRoleId = cgiGet( edtWWPSubscriptionRoleId_Internalname);
            n124WWPSubscriptionRoleId = false;
            AssignAttri("", false, "A124WWPSubscriptionRoleId", A124WWPSubscriptionRoleId);
            n124WWPSubscriptionRoleId = (String.IsNullOrEmpty(StringUtil.RTrim( A124WWPSubscriptionRoleId)) ? true : false);
            A132WWPSubscriptionSubscribed = StringUtil.StrToBool( cgiGet( chkWWPSubscriptionSubscribed_Internalname));
            AssignAttri("", false, "A132WWPSubscriptionSubscribed", A132WWPSubscriptionSubscribed);
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
               A130WWPSubscriptionId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPSubscriptionId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A130WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A130WWPSubscriptionId), 10, 0));
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
               InitAll0J29( ) ;
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
         DisableAttributes0J29( ) ;
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

      protected void ResetCaption0J0( )
      {
      }

      protected void ZM0J29( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z131WWPSubscriptionEntityRecordId = T000J3_A131WWPSubscriptionEntityRecordId[0];
               Z133WWPSubscriptionEntityRecordDes = T000J3_A133WWPSubscriptionEntityRecordDes[0];
               Z124WWPSubscriptionRoleId = T000J3_A124WWPSubscriptionRoleId[0];
               Z132WWPSubscriptionSubscribed = T000J3_A132WWPSubscriptionSubscribed[0];
               Z128WWPNotificationDefinitionId = T000J3_A128WWPNotificationDefinitionId[0];
               Z112WWPUserExtendedId = T000J3_A112WWPUserExtendedId[0];
            }
            else
            {
               Z131WWPSubscriptionEntityRecordId = A131WWPSubscriptionEntityRecordId;
               Z133WWPSubscriptionEntityRecordDes = A133WWPSubscriptionEntityRecordDes;
               Z124WWPSubscriptionRoleId = A124WWPSubscriptionRoleId;
               Z132WWPSubscriptionSubscribed = A132WWPSubscriptionSubscribed;
               Z128WWPNotificationDefinitionId = A128WWPNotificationDefinitionId;
               Z112WWPUserExtendedId = A112WWPUserExtendedId;
            }
         }
         if ( GX_JID == -2 )
         {
            Z130WWPSubscriptionId = A130WWPSubscriptionId;
            Z131WWPSubscriptionEntityRecordId = A131WWPSubscriptionEntityRecordId;
            Z133WWPSubscriptionEntityRecordDes = A133WWPSubscriptionEntityRecordDes;
            Z124WWPSubscriptionRoleId = A124WWPSubscriptionRoleId;
            Z132WWPSubscriptionSubscribed = A132WWPSubscriptionSubscribed;
            Z128WWPNotificationDefinitionId = A128WWPNotificationDefinitionId;
            Z112WWPUserExtendedId = A112WWPUserExtendedId;
            Z125WWPEntityId = A125WWPEntityId;
            Z134WWPNotificationDefinitionDescr = A134WWPNotificationDefinitionDescr;
            Z126WWPEntityName = A126WWPEntityName;
            Z113WWPUserExtendedFullName = A113WWPUserExtendedFullName;
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

      protected void Load0J29( )
      {
         /* Using cursor T000J7 */
         pr_default.execute(5, new Object[] {A130WWPSubscriptionId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound29 = 1;
            A125WWPEntityId = T000J7_A125WWPEntityId[0];
            A134WWPNotificationDefinitionDescr = T000J7_A134WWPNotificationDefinitionDescr[0];
            AssignAttri("", false, "A134WWPNotificationDefinitionDescr", A134WWPNotificationDefinitionDescr);
            A126WWPEntityName = T000J7_A126WWPEntityName[0];
            AssignAttri("", false, "A126WWPEntityName", A126WWPEntityName);
            A113WWPUserExtendedFullName = T000J7_A113WWPUserExtendedFullName[0];
            AssignAttri("", false, "A113WWPUserExtendedFullName", A113WWPUserExtendedFullName);
            A131WWPSubscriptionEntityRecordId = T000J7_A131WWPSubscriptionEntityRecordId[0];
            AssignAttri("", false, "A131WWPSubscriptionEntityRecordId", A131WWPSubscriptionEntityRecordId);
            A133WWPSubscriptionEntityRecordDes = T000J7_A133WWPSubscriptionEntityRecordDes[0];
            AssignAttri("", false, "A133WWPSubscriptionEntityRecordDes", A133WWPSubscriptionEntityRecordDes);
            A124WWPSubscriptionRoleId = T000J7_A124WWPSubscriptionRoleId[0];
            n124WWPSubscriptionRoleId = T000J7_n124WWPSubscriptionRoleId[0];
            AssignAttri("", false, "A124WWPSubscriptionRoleId", A124WWPSubscriptionRoleId);
            A132WWPSubscriptionSubscribed = T000J7_A132WWPSubscriptionSubscribed[0];
            AssignAttri("", false, "A132WWPSubscriptionSubscribed", A132WWPSubscriptionSubscribed);
            A128WWPNotificationDefinitionId = T000J7_A128WWPNotificationDefinitionId[0];
            AssignAttri("", false, "A128WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A128WWPNotificationDefinitionId), 10, 0));
            A112WWPUserExtendedId = T000J7_A112WWPUserExtendedId[0];
            n112WWPUserExtendedId = T000J7_n112WWPUserExtendedId[0];
            AssignAttri("", false, "A112WWPUserExtendedId", A112WWPUserExtendedId);
            ZM0J29( -2) ;
         }
         pr_default.close(5);
         OnLoadActions0J29( ) ;
      }

      protected void OnLoadActions0J29( )
      {
      }

      protected void CheckExtendedTable0J29( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000J4 */
         pr_default.execute(2, new Object[] {A128WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_NotificationDefinition", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A125WWPEntityId = T000J4_A125WWPEntityId[0];
         A134WWPNotificationDefinitionDescr = T000J4_A134WWPNotificationDefinitionDescr[0];
         AssignAttri("", false, "A134WWPNotificationDefinitionDescr", A134WWPNotificationDefinitionDescr);
         pr_default.close(2);
         /* Using cursor T000J6 */
         pr_default.execute(4, new Object[] {A125WWPEntityId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Entity", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
         }
         A126WWPEntityName = T000J6_A126WWPEntityName[0];
         AssignAttri("", false, "A126WWPEntityName", A126WWPEntityName);
         pr_default.close(4);
         /* Using cursor T000J5 */
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
         A113WWPUserExtendedFullName = T000J5_A113WWPUserExtendedFullName[0];
         AssignAttri("", false, "A113WWPUserExtendedFullName", A113WWPUserExtendedFullName);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0J29( )
      {
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( long A128WWPNotificationDefinitionId )
      {
         /* Using cursor T000J8 */
         pr_default.execute(6, new Object[] {A128WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_NotificationDefinition", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A125WWPEntityId = T000J8_A125WWPEntityId[0];
         A134WWPNotificationDefinitionDescr = T000J8_A134WWPNotificationDefinitionDescr[0];
         AssignAttri("", false, "A134WWPNotificationDefinitionDescr", A134WWPNotificationDefinitionDescr);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A125WWPEntityId), 10, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A134WWPNotificationDefinitionDescr)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_5( long A125WWPEntityId )
      {
         /* Using cursor T000J9 */
         pr_default.execute(7, new Object[] {A125WWPEntityId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Entity", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
         }
         A126WWPEntityName = T000J9_A126WWPEntityName[0];
         AssignAttri("", false, "A126WWPEntityName", A126WWPEntityName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A126WWPEntityName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_4( string A112WWPUserExtendedId )
      {
         /* Using cursor T000J10 */
         pr_default.execute(8, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A112WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_UserExtended", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
               GX_FocusControl = edtWWPUserExtendedId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A113WWPUserExtendedFullName = T000J10_A113WWPUserExtendedFullName[0];
         AssignAttri("", false, "A113WWPUserExtendedFullName", A113WWPUserExtendedFullName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A113WWPUserExtendedFullName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey0J29( )
      {
         /* Using cursor T000J11 */
         pr_default.execute(9, new Object[] {A130WWPSubscriptionId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound29 = 1;
         }
         else
         {
            RcdFound29 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000J3 */
         pr_default.execute(1, new Object[] {A130WWPSubscriptionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0J29( 2) ;
            RcdFound29 = 1;
            A130WWPSubscriptionId = T000J3_A130WWPSubscriptionId[0];
            AssignAttri("", false, "A130WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A130WWPSubscriptionId), 10, 0));
            A131WWPSubscriptionEntityRecordId = T000J3_A131WWPSubscriptionEntityRecordId[0];
            AssignAttri("", false, "A131WWPSubscriptionEntityRecordId", A131WWPSubscriptionEntityRecordId);
            A133WWPSubscriptionEntityRecordDes = T000J3_A133WWPSubscriptionEntityRecordDes[0];
            AssignAttri("", false, "A133WWPSubscriptionEntityRecordDes", A133WWPSubscriptionEntityRecordDes);
            A124WWPSubscriptionRoleId = T000J3_A124WWPSubscriptionRoleId[0];
            n124WWPSubscriptionRoleId = T000J3_n124WWPSubscriptionRoleId[0];
            AssignAttri("", false, "A124WWPSubscriptionRoleId", A124WWPSubscriptionRoleId);
            A132WWPSubscriptionSubscribed = T000J3_A132WWPSubscriptionSubscribed[0];
            AssignAttri("", false, "A132WWPSubscriptionSubscribed", A132WWPSubscriptionSubscribed);
            A128WWPNotificationDefinitionId = T000J3_A128WWPNotificationDefinitionId[0];
            AssignAttri("", false, "A128WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A128WWPNotificationDefinitionId), 10, 0));
            A112WWPUserExtendedId = T000J3_A112WWPUserExtendedId[0];
            n112WWPUserExtendedId = T000J3_n112WWPUserExtendedId[0];
            AssignAttri("", false, "A112WWPUserExtendedId", A112WWPUserExtendedId);
            Z130WWPSubscriptionId = A130WWPSubscriptionId;
            sMode29 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0J29( ) ;
            if ( AnyError == 1 )
            {
               RcdFound29 = 0;
               InitializeNonKey0J29( ) ;
            }
            Gx_mode = sMode29;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound29 = 0;
            InitializeNonKey0J29( ) ;
            sMode29 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode29;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0J29( ) ;
         if ( RcdFound29 == 0 )
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
         RcdFound29 = 0;
         /* Using cursor T000J12 */
         pr_default.execute(10, new Object[] {A130WWPSubscriptionId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T000J12_A130WWPSubscriptionId[0] < A130WWPSubscriptionId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T000J12_A130WWPSubscriptionId[0] > A130WWPSubscriptionId ) ) )
            {
               A130WWPSubscriptionId = T000J12_A130WWPSubscriptionId[0];
               AssignAttri("", false, "A130WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A130WWPSubscriptionId), 10, 0));
               RcdFound29 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound29 = 0;
         /* Using cursor T000J13 */
         pr_default.execute(11, new Object[] {A130WWPSubscriptionId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000J13_A130WWPSubscriptionId[0] > A130WWPSubscriptionId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000J13_A130WWPSubscriptionId[0] < A130WWPSubscriptionId ) ) )
            {
               A130WWPSubscriptionId = T000J13_A130WWPSubscriptionId[0];
               AssignAttri("", false, "A130WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A130WWPSubscriptionId), 10, 0));
               RcdFound29 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0J29( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPSubscriptionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0J29( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound29 == 1 )
            {
               if ( A130WWPSubscriptionId != Z130WWPSubscriptionId )
               {
                  A130WWPSubscriptionId = Z130WWPSubscriptionId;
                  AssignAttri("", false, "A130WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A130WWPSubscriptionId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPSUBSCRIPTIONID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPSubscriptionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPSubscriptionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0J29( ) ;
                  GX_FocusControl = edtWWPSubscriptionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A130WWPSubscriptionId != Z130WWPSubscriptionId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPSubscriptionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0J29( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPSUBSCRIPTIONID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPSubscriptionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPSubscriptionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0J29( ) ;
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
         if ( A130WWPSubscriptionId != Z130WWPSubscriptionId )
         {
            A130WWPSubscriptionId = Z130WWPSubscriptionId;
            AssignAttri("", false, "A130WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A130WWPSubscriptionId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPSUBSCRIPTIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPSubscriptionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPSubscriptionId_Internalname;
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
         if ( RcdFound29 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPSUBSCRIPTIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPSubscriptionId_Internalname;
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
         ScanStart0J29( ) ;
         if ( RcdFound29 == 0 )
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
         ScanEnd0J29( ) ;
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
         if ( RcdFound29 == 0 )
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
         if ( RcdFound29 == 0 )
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
         ScanStart0J29( ) ;
         if ( RcdFound29 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound29 != 0 )
            {
               ScanNext0J29( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0J29( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0J29( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000J2 */
            pr_default.execute(0, new Object[] {A130WWPSubscriptionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Subscription"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z131WWPSubscriptionEntityRecordId, T000J2_A131WWPSubscriptionEntityRecordId[0]) != 0 ) || ( StringUtil.StrCmp(Z133WWPSubscriptionEntityRecordDes, T000J2_A133WWPSubscriptionEntityRecordDes[0]) != 0 ) || ( StringUtil.StrCmp(Z124WWPSubscriptionRoleId, T000J2_A124WWPSubscriptionRoleId[0]) != 0 ) || ( Z132WWPSubscriptionSubscribed != T000J2_A132WWPSubscriptionSubscribed[0] ) || ( Z128WWPNotificationDefinitionId != T000J2_A128WWPNotificationDefinitionId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z112WWPUserExtendedId, T000J2_A112WWPUserExtendedId[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z131WWPSubscriptionEntityRecordId, T000J2_A131WWPSubscriptionEntityRecordId[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.subscriptions.wwp_subscription:[seudo value changed for attri]"+"WWPSubscriptionEntityRecordId");
                  GXUtil.WriteLogRaw("Old: ",Z131WWPSubscriptionEntityRecordId);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A131WWPSubscriptionEntityRecordId[0]);
               }
               if ( StringUtil.StrCmp(Z133WWPSubscriptionEntityRecordDes, T000J2_A133WWPSubscriptionEntityRecordDes[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.subscriptions.wwp_subscription:[seudo value changed for attri]"+"WWPSubscriptionEntityRecordDes");
                  GXUtil.WriteLogRaw("Old: ",Z133WWPSubscriptionEntityRecordDes);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A133WWPSubscriptionEntityRecordDes[0]);
               }
               if ( StringUtil.StrCmp(Z124WWPSubscriptionRoleId, T000J2_A124WWPSubscriptionRoleId[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.subscriptions.wwp_subscription:[seudo value changed for attri]"+"WWPSubscriptionRoleId");
                  GXUtil.WriteLogRaw("Old: ",Z124WWPSubscriptionRoleId);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A124WWPSubscriptionRoleId[0]);
               }
               if ( Z132WWPSubscriptionSubscribed != T000J2_A132WWPSubscriptionSubscribed[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.subscriptions.wwp_subscription:[seudo value changed for attri]"+"WWPSubscriptionSubscribed");
                  GXUtil.WriteLogRaw("Old: ",Z132WWPSubscriptionSubscribed);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A132WWPSubscriptionSubscribed[0]);
               }
               if ( Z128WWPNotificationDefinitionId != T000J2_A128WWPNotificationDefinitionId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.subscriptions.wwp_subscription:[seudo value changed for attri]"+"WWPNotificationDefinitionId");
                  GXUtil.WriteLogRaw("Old: ",Z128WWPNotificationDefinitionId);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A128WWPNotificationDefinitionId[0]);
               }
               if ( StringUtil.StrCmp(Z112WWPUserExtendedId, T000J2_A112WWPUserExtendedId[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.subscriptions.wwp_subscription:[seudo value changed for attri]"+"WWPUserExtendedId");
                  GXUtil.WriteLogRaw("Old: ",Z112WWPUserExtendedId);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A112WWPUserExtendedId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Subscription"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0J29( )
      {
         if ( ! IsAuthorized("wwpsubscription_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0J29( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J29( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0J29( 0) ;
            CheckOptimisticConcurrency0J29( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J29( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0J29( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000J14 */
                     pr_default.execute(12, new Object[] {A131WWPSubscriptionEntityRecordId, A133WWPSubscriptionEntityRecordDes, n124WWPSubscriptionRoleId, A124WWPSubscriptionRoleId, A132WWPSubscriptionSubscribed, A128WWPNotificationDefinitionId, n112WWPUserExtendedId, A112WWPUserExtendedId});
                     pr_default.close(12);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000J15 */
                     pr_default.execute(13);
                     A130WWPSubscriptionId = T000J15_A130WWPSubscriptionId[0];
                     AssignAttri("", false, "A130WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A130WWPSubscriptionId), 10, 0));
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Subscription");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0J0( ) ;
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
               Load0J29( ) ;
            }
            EndLevel0J29( ) ;
         }
         CloseExtendedTableCursors0J29( ) ;
      }

      protected void Update0J29( )
      {
         if ( ! IsAuthorized("wwpsubscription_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0J29( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J29( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J29( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J29( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0J29( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000J16 */
                     pr_default.execute(14, new Object[] {A131WWPSubscriptionEntityRecordId, A133WWPSubscriptionEntityRecordDes, n124WWPSubscriptionRoleId, A124WWPSubscriptionRoleId, A132WWPSubscriptionSubscribed, A128WWPNotificationDefinitionId, n112WWPUserExtendedId, A112WWPUserExtendedId, A130WWPSubscriptionId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Subscription");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Subscription"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0J29( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0J0( ) ;
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
            EndLevel0J29( ) ;
         }
         CloseExtendedTableCursors0J29( ) ;
      }

      protected void DeferredUpdate0J29( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("wwpsubscription_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0J29( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J29( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0J29( ) ;
            AfterConfirm0J29( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0J29( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000J17 */
                  pr_default.execute(15, new Object[] {A130WWPSubscriptionId});
                  pr_default.close(15);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_Subscription");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound29 == 0 )
                        {
                           InitAll0J29( ) ;
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
                        ResetCaption0J0( ) ;
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
         sMode29 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0J29( ) ;
         Gx_mode = sMode29;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0J29( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000J18 */
            pr_default.execute(16, new Object[] {A128WWPNotificationDefinitionId});
            A125WWPEntityId = T000J18_A125WWPEntityId[0];
            A134WWPNotificationDefinitionDescr = T000J18_A134WWPNotificationDefinitionDescr[0];
            AssignAttri("", false, "A134WWPNotificationDefinitionDescr", A134WWPNotificationDefinitionDescr);
            pr_default.close(16);
            /* Using cursor T000J19 */
            pr_default.execute(17, new Object[] {A125WWPEntityId});
            A126WWPEntityName = T000J19_A126WWPEntityName[0];
            AssignAttri("", false, "A126WWPEntityName", A126WWPEntityName);
            pr_default.close(17);
            /* Using cursor T000J20 */
            pr_default.execute(18, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
            A113WWPUserExtendedFullName = T000J20_A113WWPUserExtendedFullName[0];
            AssignAttri("", false, "A113WWPUserExtendedFullName", A113WWPUserExtendedFullName);
            pr_default.close(18);
         }
      }

      protected void EndLevel0J29( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0J29( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("wwpbaseobjects.subscriptions.wwp_subscription",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0J0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("wwpbaseobjects.subscriptions.wwp_subscription",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0J29( )
      {
         /* Using cursor T000J21 */
         pr_default.execute(19);
         RcdFound29 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound29 = 1;
            A130WWPSubscriptionId = T000J21_A130WWPSubscriptionId[0];
            AssignAttri("", false, "A130WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A130WWPSubscriptionId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0J29( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound29 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound29 = 1;
            A130WWPSubscriptionId = T000J21_A130WWPSubscriptionId[0];
            AssignAttri("", false, "A130WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A130WWPSubscriptionId), 10, 0));
         }
      }

      protected void ScanEnd0J29( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm0J29( )
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

      protected void BeforeInsert0J29( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0J29( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0J29( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0J29( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0J29( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0J29( )
      {
         edtWWPSubscriptionId_Enabled = 0;
         AssignProp("", false, edtWWPSubscriptionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSubscriptionId_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionId_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionDescr_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionDescr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionDescr_Enabled), 5, 0), true);
         edtWWPEntityName_Enabled = 0;
         AssignProp("", false, edtWWPEntityName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPEntityName_Enabled), 5, 0), true);
         edtWWPUserExtendedId_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedId_Enabled), 5, 0), true);
         edtWWPUserExtendedFullName_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedFullName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedFullName_Enabled), 5, 0), true);
         edtWWPSubscriptionEntityRecordId_Enabled = 0;
         AssignProp("", false, edtWWPSubscriptionEntityRecordId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSubscriptionEntityRecordId_Enabled), 5, 0), true);
         edtWWPSubscriptionEntityRecordDes_Enabled = 0;
         AssignProp("", false, edtWWPSubscriptionEntityRecordDes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSubscriptionEntityRecordDes_Enabled), 5, 0), true);
         edtWWPSubscriptionRoleId_Enabled = 0;
         AssignProp("", false, edtWWPSubscriptionRoleId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSubscriptionRoleId_Enabled), 5, 0), true);
         chkWWPSubscriptionSubscribed.Enabled = 0;
         AssignProp("", false, chkWWPSubscriptionSubscribed_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPSubscriptionSubscribed.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0J29( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0J0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.subscriptions.wwp_subscription.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z130WWPSubscriptionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z130WWPSubscriptionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z131WWPSubscriptionEntityRecordId", Z131WWPSubscriptionEntityRecordId);
         GxWebStd.gx_hidden_field( context, "Z133WWPSubscriptionEntityRecordDes", Z133WWPSubscriptionEntityRecordDes);
         GxWebStd.gx_hidden_field( context, "Z124WWPSubscriptionRoleId", StringUtil.RTrim( Z124WWPSubscriptionRoleId));
         GxWebStd.gx_boolean_hidden_field( context, "Z132WWPSubscriptionSubscribed", Z132WWPSubscriptionSubscribed);
         GxWebStd.gx_hidden_field( context, "Z128WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z128WWPNotificationDefinitionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z112WWPUserExtendedId", StringUtil.RTrim( Z112WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "WWPENTITYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A125WWPEntityId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         return formatLink("wwpbaseobjects.subscriptions.wwp_subscription.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Subscriptions.WWP_Subscription" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WWP_Subscription", "") ;
      }

      protected void InitializeNonKey0J29( )
      {
         A125WWPEntityId = 0;
         AssignAttri("", false, "A125WWPEntityId", StringUtil.LTrimStr( (decimal)(A125WWPEntityId), 10, 0));
         A128WWPNotificationDefinitionId = 0;
         AssignAttri("", false, "A128WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A128WWPNotificationDefinitionId), 10, 0));
         A134WWPNotificationDefinitionDescr = "";
         AssignAttri("", false, "A134WWPNotificationDefinitionDescr", A134WWPNotificationDefinitionDescr);
         A126WWPEntityName = "";
         AssignAttri("", false, "A126WWPEntityName", A126WWPEntityName);
         A112WWPUserExtendedId = "";
         n112WWPUserExtendedId = false;
         AssignAttri("", false, "A112WWPUserExtendedId", A112WWPUserExtendedId);
         n112WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A112WWPUserExtendedId)) ? true : false);
         A113WWPUserExtendedFullName = "";
         AssignAttri("", false, "A113WWPUserExtendedFullName", A113WWPUserExtendedFullName);
         A131WWPSubscriptionEntityRecordId = "";
         AssignAttri("", false, "A131WWPSubscriptionEntityRecordId", A131WWPSubscriptionEntityRecordId);
         A133WWPSubscriptionEntityRecordDes = "";
         AssignAttri("", false, "A133WWPSubscriptionEntityRecordDes", A133WWPSubscriptionEntityRecordDes);
         A124WWPSubscriptionRoleId = "";
         n124WWPSubscriptionRoleId = false;
         AssignAttri("", false, "A124WWPSubscriptionRoleId", A124WWPSubscriptionRoleId);
         n124WWPSubscriptionRoleId = (String.IsNullOrEmpty(StringUtil.RTrim( A124WWPSubscriptionRoleId)) ? true : false);
         A132WWPSubscriptionSubscribed = false;
         AssignAttri("", false, "A132WWPSubscriptionSubscribed", A132WWPSubscriptionSubscribed);
         Z131WWPSubscriptionEntityRecordId = "";
         Z133WWPSubscriptionEntityRecordDes = "";
         Z124WWPSubscriptionRoleId = "";
         Z132WWPSubscriptionSubscribed = false;
         Z128WWPNotificationDefinitionId = 0;
         Z112WWPUserExtendedId = "";
      }

      protected void InitAll0J29( )
      {
         A130WWPSubscriptionId = 0;
         AssignAttri("", false, "A130WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A130WWPSubscriptionId), 10, 0));
         InitializeNonKey0J29( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256145325894", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/subscriptions/wwp_subscription.js", "?20256145325894", false, true);
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
         edtWWPSubscriptionId_Internalname = "WWPSUBSCRIPTIONID";
         edtWWPNotificationDefinitionId_Internalname = "WWPNOTIFICATIONDEFINITIONID";
         edtWWPNotificationDefinitionDescr_Internalname = "WWPNOTIFICATIONDEFINITIONDESCR";
         edtWWPEntityName_Internalname = "WWPENTITYNAME";
         edtWWPUserExtendedId_Internalname = "WWPUSEREXTENDEDID";
         edtWWPUserExtendedFullName_Internalname = "WWPUSEREXTENDEDFULLNAME";
         edtWWPSubscriptionEntityRecordId_Internalname = "WWPSUBSCRIPTIONENTITYRECORDID";
         edtWWPSubscriptionEntityRecordDes_Internalname = "WWPSUBSCRIPTIONENTITYRECORDDES";
         edtWWPSubscriptionRoleId_Internalname = "WWPSUBSCRIPTIONROLEID";
         chkWWPSubscriptionSubscribed_Internalname = "WWPSUBSCRIPTIONSUBSCRIBED";
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
         Form.Caption = context.GetMessage( "WWP_Subscription", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkWWPSubscriptionSubscribed.Enabled = 1;
         edtWWPSubscriptionRoleId_Jsonclick = "";
         edtWWPSubscriptionRoleId_Enabled = 1;
         edtWWPSubscriptionEntityRecordDes_Enabled = 1;
         edtWWPSubscriptionEntityRecordId_Enabled = 1;
         edtWWPUserExtendedFullName_Jsonclick = "";
         edtWWPUserExtendedFullName_Enabled = 0;
         edtWWPUserExtendedId_Jsonclick = "";
         edtWWPUserExtendedId_Enabled = 1;
         edtWWPEntityName_Jsonclick = "";
         edtWWPEntityName_Enabled = 0;
         edtWWPNotificationDefinitionDescr_Enabled = 0;
         edtWWPNotificationDefinitionId_Jsonclick = "";
         edtWWPNotificationDefinitionId_Enabled = 1;
         edtWWPSubscriptionId_Jsonclick = "";
         edtWWPSubscriptionId_Enabled = 1;
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
         chkWWPSubscriptionSubscribed.Name = "WWPSUBSCRIPTIONSUBSCRIBED";
         chkWWPSubscriptionSubscribed.WebTags = "";
         chkWWPSubscriptionSubscribed.Caption = context.GetMessage( "Subscribed", "");
         AssignProp("", false, chkWWPSubscriptionSubscribed_Internalname, "TitleCaption", chkWWPSubscriptionSubscribed.Caption, true);
         chkWWPSubscriptionSubscribed.CheckedValue = "false";
         A132WWPSubscriptionSubscribed = StringUtil.StrToBool( StringUtil.BoolToStr( A132WWPSubscriptionSubscribed));
         AssignAttri("", false, "A132WWPSubscriptionSubscribed", A132WWPSubscriptionSubscribed);
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

      public void Valid_Wwpsubscriptionid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A132WWPSubscriptionSubscribed = StringUtil.StrToBool( StringUtil.BoolToStr( A132WWPSubscriptionSubscribed));
         /*  Sending validation outputs */
         AssignAttri("", false, "A128WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A128WWPNotificationDefinitionId), 10, 0, ".", "")));
         AssignAttri("", false, "A112WWPUserExtendedId", StringUtil.RTrim( A112WWPUserExtendedId));
         AssignAttri("", false, "A131WWPSubscriptionEntityRecordId", A131WWPSubscriptionEntityRecordId);
         AssignAttri("", false, "A133WWPSubscriptionEntityRecordDes", A133WWPSubscriptionEntityRecordDes);
         AssignAttri("", false, "A124WWPSubscriptionRoleId", StringUtil.RTrim( A124WWPSubscriptionRoleId));
         AssignAttri("", false, "A132WWPSubscriptionSubscribed", A132WWPSubscriptionSubscribed);
         AssignAttri("", false, "A125WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A125WWPEntityId), 10, 0, ".", "")));
         AssignAttri("", false, "A134WWPNotificationDefinitionDescr", A134WWPNotificationDefinitionDescr);
         AssignAttri("", false, "A126WWPEntityName", A126WWPEntityName);
         AssignAttri("", false, "A113WWPUserExtendedFullName", A113WWPUserExtendedFullName);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z130WWPSubscriptionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z130WWPSubscriptionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z128WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z128WWPNotificationDefinitionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z112WWPUserExtendedId", StringUtil.RTrim( Z112WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "Z131WWPSubscriptionEntityRecordId", Z131WWPSubscriptionEntityRecordId);
         GxWebStd.gx_hidden_field( context, "Z133WWPSubscriptionEntityRecordDes", Z133WWPSubscriptionEntityRecordDes);
         GxWebStd.gx_hidden_field( context, "Z124WWPSubscriptionRoleId", StringUtil.RTrim( Z124WWPSubscriptionRoleId));
         GxWebStd.gx_hidden_field( context, "Z132WWPSubscriptionSubscribed", StringUtil.BoolToStr( Z132WWPSubscriptionSubscribed));
         GxWebStd.gx_hidden_field( context, "Z125WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z125WWPEntityId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z134WWPNotificationDefinitionDescr", Z134WWPNotificationDefinitionDescr);
         GxWebStd.gx_hidden_field( context, "Z126WWPEntityName", Z126WWPEntityName);
         GxWebStd.gx_hidden_field( context, "Z113WWPUserExtendedFullName", Z113WWPUserExtendedFullName);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpnotificationdefinitionid( )
      {
         /* Using cursor T000J18 */
         pr_default.execute(16, new Object[] {A128WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_NotificationDefinition", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
         }
         A125WWPEntityId = T000J18_A125WWPEntityId[0];
         A134WWPNotificationDefinitionDescr = T000J18_A134WWPNotificationDefinitionDescr[0];
         pr_default.close(16);
         /* Using cursor T000J19 */
         pr_default.execute(17, new Object[] {A125WWPEntityId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Entity", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
         }
         A126WWPEntityName = T000J19_A126WWPEntityName[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A125WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A125WWPEntityId), 10, 0, ".", "")));
         AssignAttri("", false, "A134WWPNotificationDefinitionDescr", A134WWPNotificationDefinitionDescr);
         AssignAttri("", false, "A126WWPEntityName", A126WWPEntityName);
      }

      public void Valid_Wwpuserextendedid( )
      {
         n112WWPUserExtendedId = false;
         /* Using cursor T000J20 */
         pr_default.execute(18, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A112WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_UserExtended", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
               GX_FocusControl = edtWWPUserExtendedId_Internalname;
            }
         }
         A113WWPUserExtendedFullName = T000J20_A113WWPUserExtendedFullName[0];
         pr_default.close(18);
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A132WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A132WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A132WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A132WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED"}]}""");
         setEventMetadata("VALID_WWPSUBSCRIPTIONID","""{"handler":"Valid_Wwpsubscriptionid","iparms":[{"av":"A130WWPSubscriptionId","fld":"WWPSUBSCRIPTIONID","pic":"ZZZZZZZZZ9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"A132WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED"}]""");
         setEventMetadata("VALID_WWPSUBSCRIPTIONID",""","oparms":[{"av":"A128WWPNotificationDefinitionId","fld":"WWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9"},{"av":"A112WWPUserExtendedId","fld":"WWPUSEREXTENDEDID"},{"av":"A131WWPSubscriptionEntityRecordId","fld":"WWPSUBSCRIPTIONENTITYRECORDID"},{"av":"A133WWPSubscriptionEntityRecordDes","fld":"WWPSUBSCRIPTIONENTITYRECORDDES"},{"av":"A124WWPSubscriptionRoleId","fld":"WWPSUBSCRIPTIONROLEID"},{"av":"A125WWPEntityId","fld":"WWPENTITYID","pic":"ZZZZZZZZZ9"},{"av":"A134WWPNotificationDefinitionDescr","fld":"WWPNOTIFICATIONDEFINITIONDESCR"},{"av":"A126WWPEntityName","fld":"WWPENTITYNAME"},{"av":"A113WWPUserExtendedFullName","fld":"WWPUSEREXTENDEDFULLNAME"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z130WWPSubscriptionId"},{"av":"Z128WWPNotificationDefinitionId"},{"av":"Z112WWPUserExtendedId"},{"av":"Z131WWPSubscriptionEntityRecordId"},{"av":"Z133WWPSubscriptionEntityRecordDes"},{"av":"Z124WWPSubscriptionRoleId"},{"av":"Z132WWPSubscriptionSubscribed"},{"av":"Z125WWPEntityId"},{"av":"Z134WWPNotificationDefinitionDescr"},{"av":"Z126WWPEntityName"},{"av":"Z113WWPUserExtendedFullName"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A132WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED"}]}""");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONID","""{"handler":"Valid_Wwpnotificationdefinitionid","iparms":[{"av":"A128WWPNotificationDefinitionId","fld":"WWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9"},{"av":"A125WWPEntityId","fld":"WWPENTITYID","pic":"ZZZZZZZZZ9"},{"av":"A134WWPNotificationDefinitionDescr","fld":"WWPNOTIFICATIONDEFINITIONDESCR"},{"av":"A126WWPEntityName","fld":"WWPENTITYNAME"},{"av":"A132WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED"}]""");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONID",""","oparms":[{"av":"A125WWPEntityId","fld":"WWPENTITYID","pic":"ZZZZZZZZZ9"},{"av":"A134WWPNotificationDefinitionDescr","fld":"WWPNOTIFICATIONDEFINITIONDESCR"},{"av":"A126WWPEntityName","fld":"WWPENTITYNAME"},{"av":"A132WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED"}]}""");
         setEventMetadata("VALID_WWPUSEREXTENDEDID","""{"handler":"Valid_Wwpuserextendedid","iparms":[{"av":"A112WWPUserExtendedId","fld":"WWPUSEREXTENDEDID"},{"av":"A113WWPUserExtendedFullName","fld":"WWPUSEREXTENDEDFULLNAME"},{"av":"A132WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED"}]""");
         setEventMetadata("VALID_WWPUSEREXTENDEDID",""","oparms":[{"av":"A113WWPUserExtendedFullName","fld":"WWPUSEREXTENDEDFULLNAME"},{"av":"A132WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED"}]}""");
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
         pr_default.close(16);
         pr_default.close(18);
         pr_default.close(17);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z131WWPSubscriptionEntityRecordId = "";
         Z133WWPSubscriptionEntityRecordDes = "";
         Z124WWPSubscriptionRoleId = "";
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
         A134WWPNotificationDefinitionDescr = "";
         A126WWPEntityName = "";
         A113WWPUserExtendedFullName = "";
         A131WWPSubscriptionEntityRecordId = "";
         A133WWPSubscriptionEntityRecordDes = "";
         A124WWPSubscriptionRoleId = "";
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
         Z134WWPNotificationDefinitionDescr = "";
         Z126WWPEntityName = "";
         Z113WWPUserExtendedFullName = "";
         T000J7_A125WWPEntityId = new long[1] ;
         T000J7_A130WWPSubscriptionId = new long[1] ;
         T000J7_A134WWPNotificationDefinitionDescr = new string[] {""} ;
         T000J7_A126WWPEntityName = new string[] {""} ;
         T000J7_A113WWPUserExtendedFullName = new string[] {""} ;
         T000J7_A131WWPSubscriptionEntityRecordId = new string[] {""} ;
         T000J7_A133WWPSubscriptionEntityRecordDes = new string[] {""} ;
         T000J7_A124WWPSubscriptionRoleId = new string[] {""} ;
         T000J7_n124WWPSubscriptionRoleId = new bool[] {false} ;
         T000J7_A132WWPSubscriptionSubscribed = new bool[] {false} ;
         T000J7_A128WWPNotificationDefinitionId = new long[1] ;
         T000J7_A112WWPUserExtendedId = new string[] {""} ;
         T000J7_n112WWPUserExtendedId = new bool[] {false} ;
         T000J4_A125WWPEntityId = new long[1] ;
         T000J4_A134WWPNotificationDefinitionDescr = new string[] {""} ;
         T000J6_A126WWPEntityName = new string[] {""} ;
         T000J5_A113WWPUserExtendedFullName = new string[] {""} ;
         T000J8_A125WWPEntityId = new long[1] ;
         T000J8_A134WWPNotificationDefinitionDescr = new string[] {""} ;
         T000J9_A126WWPEntityName = new string[] {""} ;
         T000J10_A113WWPUserExtendedFullName = new string[] {""} ;
         T000J11_A130WWPSubscriptionId = new long[1] ;
         T000J3_A130WWPSubscriptionId = new long[1] ;
         T000J3_A131WWPSubscriptionEntityRecordId = new string[] {""} ;
         T000J3_A133WWPSubscriptionEntityRecordDes = new string[] {""} ;
         T000J3_A124WWPSubscriptionRoleId = new string[] {""} ;
         T000J3_n124WWPSubscriptionRoleId = new bool[] {false} ;
         T000J3_A132WWPSubscriptionSubscribed = new bool[] {false} ;
         T000J3_A128WWPNotificationDefinitionId = new long[1] ;
         T000J3_A112WWPUserExtendedId = new string[] {""} ;
         T000J3_n112WWPUserExtendedId = new bool[] {false} ;
         sMode29 = "";
         T000J12_A130WWPSubscriptionId = new long[1] ;
         T000J13_A130WWPSubscriptionId = new long[1] ;
         T000J2_A130WWPSubscriptionId = new long[1] ;
         T000J2_A131WWPSubscriptionEntityRecordId = new string[] {""} ;
         T000J2_A133WWPSubscriptionEntityRecordDes = new string[] {""} ;
         T000J2_A124WWPSubscriptionRoleId = new string[] {""} ;
         T000J2_n124WWPSubscriptionRoleId = new bool[] {false} ;
         T000J2_A132WWPSubscriptionSubscribed = new bool[] {false} ;
         T000J2_A128WWPNotificationDefinitionId = new long[1] ;
         T000J2_A112WWPUserExtendedId = new string[] {""} ;
         T000J2_n112WWPUserExtendedId = new bool[] {false} ;
         T000J15_A130WWPSubscriptionId = new long[1] ;
         T000J18_A125WWPEntityId = new long[1] ;
         T000J18_A134WWPNotificationDefinitionDescr = new string[] {""} ;
         T000J19_A126WWPEntityName = new string[] {""} ;
         T000J20_A113WWPUserExtendedFullName = new string[] {""} ;
         T000J21_A130WWPSubscriptionId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ112WWPUserExtendedId = "";
         ZZ131WWPSubscriptionEntityRecordId = "";
         ZZ133WWPSubscriptionEntityRecordDes = "";
         ZZ124WWPSubscriptionRoleId = "";
         ZZ134WWPNotificationDefinitionDescr = "";
         ZZ126WWPEntityName = "";
         ZZ113WWPUserExtendedFullName = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_subscription__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_subscription__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_subscription__default(),
            new Object[][] {
                new Object[] {
               T000J2_A130WWPSubscriptionId, T000J2_A131WWPSubscriptionEntityRecordId, T000J2_A133WWPSubscriptionEntityRecordDes, T000J2_A124WWPSubscriptionRoleId, T000J2_n124WWPSubscriptionRoleId, T000J2_A132WWPSubscriptionSubscribed, T000J2_A128WWPNotificationDefinitionId, T000J2_A112WWPUserExtendedId, T000J2_n112WWPUserExtendedId
               }
               , new Object[] {
               T000J3_A130WWPSubscriptionId, T000J3_A131WWPSubscriptionEntityRecordId, T000J3_A133WWPSubscriptionEntityRecordDes, T000J3_A124WWPSubscriptionRoleId, T000J3_n124WWPSubscriptionRoleId, T000J3_A132WWPSubscriptionSubscribed, T000J3_A128WWPNotificationDefinitionId, T000J3_A112WWPUserExtendedId, T000J3_n112WWPUserExtendedId
               }
               , new Object[] {
               T000J4_A125WWPEntityId, T000J4_A134WWPNotificationDefinitionDescr
               }
               , new Object[] {
               T000J5_A113WWPUserExtendedFullName
               }
               , new Object[] {
               T000J6_A126WWPEntityName
               }
               , new Object[] {
               T000J7_A125WWPEntityId, T000J7_A130WWPSubscriptionId, T000J7_A134WWPNotificationDefinitionDescr, T000J7_A126WWPEntityName, T000J7_A113WWPUserExtendedFullName, T000J7_A131WWPSubscriptionEntityRecordId, T000J7_A133WWPSubscriptionEntityRecordDes, T000J7_A124WWPSubscriptionRoleId, T000J7_n124WWPSubscriptionRoleId, T000J7_A132WWPSubscriptionSubscribed,
               T000J7_A128WWPNotificationDefinitionId, T000J7_A112WWPUserExtendedId, T000J7_n112WWPUserExtendedId
               }
               , new Object[] {
               T000J8_A125WWPEntityId, T000J8_A134WWPNotificationDefinitionDescr
               }
               , new Object[] {
               T000J9_A126WWPEntityName
               }
               , new Object[] {
               T000J10_A113WWPUserExtendedFullName
               }
               , new Object[] {
               T000J11_A130WWPSubscriptionId
               }
               , new Object[] {
               T000J12_A130WWPSubscriptionId
               }
               , new Object[] {
               T000J13_A130WWPSubscriptionId
               }
               , new Object[] {
               }
               , new Object[] {
               T000J15_A130WWPSubscriptionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000J18_A125WWPEntityId, T000J18_A134WWPNotificationDefinitionDescr
               }
               , new Object[] {
               T000J19_A126WWPEntityName
               }
               , new Object[] {
               T000J20_A113WWPUserExtendedFullName
               }
               , new Object[] {
               T000J21_A130WWPSubscriptionId
               }
            }
         );
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound29 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPSubscriptionId_Enabled ;
      private int edtWWPNotificationDefinitionId_Enabled ;
      private int edtWWPNotificationDefinitionDescr_Enabled ;
      private int edtWWPEntityName_Enabled ;
      private int edtWWPUserExtendedId_Enabled ;
      private int edtWWPUserExtendedFullName_Enabled ;
      private int edtWWPSubscriptionEntityRecordId_Enabled ;
      private int edtWWPSubscriptionEntityRecordDes_Enabled ;
      private int edtWWPSubscriptionRoleId_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z130WWPSubscriptionId ;
      private long Z128WWPNotificationDefinitionId ;
      private long A128WWPNotificationDefinitionId ;
      private long A125WWPEntityId ;
      private long A130WWPSubscriptionId ;
      private long Z125WWPEntityId ;
      private long ZZ130WWPSubscriptionId ;
      private long ZZ128WWPNotificationDefinitionId ;
      private long ZZ125WWPEntityId ;
      private string sPrefix ;
      private string Z124WWPSubscriptionRoleId ;
      private string Z112WWPUserExtendedId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A112WWPUserExtendedId ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPSubscriptionId_Internalname ;
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
      private string edtWWPSubscriptionId_Jsonclick ;
      private string edtWWPNotificationDefinitionId_Internalname ;
      private string edtWWPNotificationDefinitionId_Jsonclick ;
      private string edtWWPNotificationDefinitionDescr_Internalname ;
      private string edtWWPEntityName_Internalname ;
      private string edtWWPEntityName_Jsonclick ;
      private string edtWWPUserExtendedId_Internalname ;
      private string edtWWPUserExtendedId_Jsonclick ;
      private string edtWWPUserExtendedFullName_Internalname ;
      private string edtWWPUserExtendedFullName_Jsonclick ;
      private string edtWWPSubscriptionEntityRecordId_Internalname ;
      private string edtWWPSubscriptionEntityRecordDes_Internalname ;
      private string edtWWPSubscriptionRoleId_Internalname ;
      private string A124WWPSubscriptionRoleId ;
      private string edtWWPSubscriptionRoleId_Jsonclick ;
      private string chkWWPSubscriptionSubscribed_Internalname ;
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
      private string sMode29 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ112WWPUserExtendedId ;
      private string ZZ124WWPSubscriptionRoleId ;
      private bool Z132WWPSubscriptionSubscribed ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n112WWPUserExtendedId ;
      private bool wbErr ;
      private bool A132WWPSubscriptionSubscribed ;
      private bool n124WWPSubscriptionRoleId ;
      private bool Gx_longc ;
      private bool ZZ132WWPSubscriptionSubscribed ;
      private string Z131WWPSubscriptionEntityRecordId ;
      private string Z133WWPSubscriptionEntityRecordDes ;
      private string A134WWPNotificationDefinitionDescr ;
      private string A126WWPEntityName ;
      private string A113WWPUserExtendedFullName ;
      private string A131WWPSubscriptionEntityRecordId ;
      private string A133WWPSubscriptionEntityRecordDes ;
      private string Z134WWPNotificationDefinitionDescr ;
      private string Z126WWPEntityName ;
      private string Z113WWPUserExtendedFullName ;
      private string ZZ131WWPSubscriptionEntityRecordId ;
      private string ZZ133WWPSubscriptionEntityRecordDes ;
      private string ZZ134WWPNotificationDefinitionDescr ;
      private string ZZ126WWPEntityName ;
      private string ZZ113WWPUserExtendedFullName ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkWWPSubscriptionSubscribed ;
      private IDataStoreProvider pr_default ;
      private long[] T000J7_A125WWPEntityId ;
      private long[] T000J7_A130WWPSubscriptionId ;
      private string[] T000J7_A134WWPNotificationDefinitionDescr ;
      private string[] T000J7_A126WWPEntityName ;
      private string[] T000J7_A113WWPUserExtendedFullName ;
      private string[] T000J7_A131WWPSubscriptionEntityRecordId ;
      private string[] T000J7_A133WWPSubscriptionEntityRecordDes ;
      private string[] T000J7_A124WWPSubscriptionRoleId ;
      private bool[] T000J7_n124WWPSubscriptionRoleId ;
      private bool[] T000J7_A132WWPSubscriptionSubscribed ;
      private long[] T000J7_A128WWPNotificationDefinitionId ;
      private string[] T000J7_A112WWPUserExtendedId ;
      private bool[] T000J7_n112WWPUserExtendedId ;
      private long[] T000J4_A125WWPEntityId ;
      private string[] T000J4_A134WWPNotificationDefinitionDescr ;
      private string[] T000J6_A126WWPEntityName ;
      private string[] T000J5_A113WWPUserExtendedFullName ;
      private long[] T000J8_A125WWPEntityId ;
      private string[] T000J8_A134WWPNotificationDefinitionDescr ;
      private string[] T000J9_A126WWPEntityName ;
      private string[] T000J10_A113WWPUserExtendedFullName ;
      private long[] T000J11_A130WWPSubscriptionId ;
      private long[] T000J3_A130WWPSubscriptionId ;
      private string[] T000J3_A131WWPSubscriptionEntityRecordId ;
      private string[] T000J3_A133WWPSubscriptionEntityRecordDes ;
      private string[] T000J3_A124WWPSubscriptionRoleId ;
      private bool[] T000J3_n124WWPSubscriptionRoleId ;
      private bool[] T000J3_A132WWPSubscriptionSubscribed ;
      private long[] T000J3_A128WWPNotificationDefinitionId ;
      private string[] T000J3_A112WWPUserExtendedId ;
      private bool[] T000J3_n112WWPUserExtendedId ;
      private long[] T000J12_A130WWPSubscriptionId ;
      private long[] T000J13_A130WWPSubscriptionId ;
      private long[] T000J2_A130WWPSubscriptionId ;
      private string[] T000J2_A131WWPSubscriptionEntityRecordId ;
      private string[] T000J2_A133WWPSubscriptionEntityRecordDes ;
      private string[] T000J2_A124WWPSubscriptionRoleId ;
      private bool[] T000J2_n124WWPSubscriptionRoleId ;
      private bool[] T000J2_A132WWPSubscriptionSubscribed ;
      private long[] T000J2_A128WWPNotificationDefinitionId ;
      private string[] T000J2_A112WWPUserExtendedId ;
      private bool[] T000J2_n112WWPUserExtendedId ;
      private long[] T000J15_A130WWPSubscriptionId ;
      private long[] T000J18_A125WWPEntityId ;
      private string[] T000J18_A134WWPNotificationDefinitionDescr ;
      private string[] T000J19_A126WWPEntityName ;
      private string[] T000J20_A113WWPUserExtendedFullName ;
      private long[] T000J21_A130WWPSubscriptionId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_subscription__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_subscription__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_subscription__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[12])
      ,new ForEachCursor(def[13])
      ,new UpdateCursor(def[14])
      ,new UpdateCursor(def[15])
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
       Object[] prmT000J2;
       prmT000J2 = new Object[] {
       new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
       };
       Object[] prmT000J3;
       prmT000J3 = new Object[] {
       new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
       };
       Object[] prmT000J4;
       prmT000J4 = new Object[] {
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       Object[] prmT000J5;
       prmT000J5 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmT000J6;
       prmT000J6 = new Object[] {
       new ParDef("WWPEntityId",GXType.Int64,10,0)
       };
       Object[] prmT000J7;
       prmT000J7 = new Object[] {
       new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
       };
       Object[] prmT000J8;
       prmT000J8 = new Object[] {
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       Object[] prmT000J9;
       prmT000J9 = new Object[] {
       new ParDef("WWPEntityId",GXType.Int64,10,0)
       };
       Object[] prmT000J10;
       prmT000J10 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmT000J11;
       prmT000J11 = new Object[] {
       new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
       };
       Object[] prmT000J12;
       prmT000J12 = new Object[] {
       new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
       };
       Object[] prmT000J13;
       prmT000J13 = new Object[] {
       new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
       };
       Object[] prmT000J14;
       prmT000J14 = new Object[] {
       new ParDef("WWPSubscriptionEntityRecordId",GXType.VarChar,2000,0) ,
       new ParDef("WWPSubscriptionEntityRecordDes",GXType.VarChar,200,0) ,
       new ParDef("WWPSubscriptionRoleId",GXType.Char,40,0){Nullable=true} ,
       new ParDef("WWPSubscriptionSubscribed",GXType.Boolean,4,0) ,
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0) ,
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmT000J15;
       prmT000J15 = new Object[] {
       };
       Object[] prmT000J16;
       prmT000J16 = new Object[] {
       new ParDef("WWPSubscriptionEntityRecordId",GXType.VarChar,2000,0) ,
       new ParDef("WWPSubscriptionEntityRecordDes",GXType.VarChar,200,0) ,
       new ParDef("WWPSubscriptionRoleId",GXType.Char,40,0){Nullable=true} ,
       new ParDef("WWPSubscriptionSubscribed",GXType.Boolean,4,0) ,
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0) ,
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true} ,
       new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
       };
       Object[] prmT000J17;
       prmT000J17 = new Object[] {
       new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
       };
       Object[] prmT000J18;
       prmT000J18 = new Object[] {
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       Object[] prmT000J19;
       prmT000J19 = new Object[] {
       new ParDef("WWPEntityId",GXType.Int64,10,0)
       };
       Object[] prmT000J20;
       prmT000J20 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmT000J21;
       prmT000J21 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T000J2", "SELECT WWPSubscriptionId, WWPSubscriptionEntityRecordId, WWPSubscriptionEntityRecordDes, WWPSubscriptionRoleId, WWPSubscriptionSubscribed, WWPNotificationDefinitionId, WWPUserExtendedId FROM WWP_Subscription WHERE WWPSubscriptionId = :WWPSubscriptionId  FOR UPDATE OF WWP_Subscription NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000J2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000J3", "SELECT WWPSubscriptionId, WWPSubscriptionEntityRecordId, WWPSubscriptionEntityRecordDes, WWPSubscriptionRoleId, WWPSubscriptionSubscribed, WWPNotificationDefinitionId, WWPUserExtendedId FROM WWP_Subscription WHERE WWPSubscriptionId = :WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000J4", "SELECT WWPEntityId, WWPNotificationDefinitionDescr FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000J5", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000J6", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000J7", "SELECT T2.WWPEntityId, TM1.WWPSubscriptionId, T2.WWPNotificationDefinitionDescr, T3.WWPEntityName, T4.WWPUserExtendedFullName, TM1.WWPSubscriptionEntityRecordId, TM1.WWPSubscriptionEntityRecordDes, TM1.WWPSubscriptionRoleId, TM1.WWPSubscriptionSubscribed, TM1.WWPNotificationDefinitionId, TM1.WWPUserExtendedId FROM (((WWP_Subscription TM1 INNER JOIN WWP_NotificationDefinition T2 ON T2.WWPNotificationDefinitionId = TM1.WWPNotificationDefinitionId) INNER JOIN WWP_Entity T3 ON T3.WWPEntityId = T2.WWPEntityId) LEFT JOIN WWP_UserExtended T4 ON T4.WWPUserExtendedId = TM1.WWPUserExtendedId) WHERE TM1.WWPSubscriptionId = :WWPSubscriptionId ORDER BY TM1.WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J7,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000J8", "SELECT WWPEntityId, WWPNotificationDefinitionDescr FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J8,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000J9", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J9,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000J10", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J10,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000J11", "SELECT WWPSubscriptionId FROM WWP_Subscription WHERE WWPSubscriptionId = :WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J11,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000J12", "SELECT WWPSubscriptionId FROM WWP_Subscription WHERE ( WWPSubscriptionId > :WWPSubscriptionId) ORDER BY WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J12,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000J13", "SELECT WWPSubscriptionId FROM WWP_Subscription WHERE ( WWPSubscriptionId < :WWPSubscriptionId) ORDER BY WWPSubscriptionId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J13,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000J14", "SAVEPOINT gxupdate;INSERT INTO WWP_Subscription(WWPSubscriptionEntityRecordId, WWPSubscriptionEntityRecordDes, WWPSubscriptionRoleId, WWPSubscriptionSubscribed, WWPNotificationDefinitionId, WWPUserExtendedId) VALUES(:WWPSubscriptionEntityRecordId, :WWPSubscriptionEntityRecordDes, :WWPSubscriptionRoleId, :WWPSubscriptionSubscribed, :WWPNotificationDefinitionId, :WWPUserExtendedId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000J14)
          ,new CursorDef("T000J15", "SELECT currval('WWPSubscriptionId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J15,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000J16", "SAVEPOINT gxupdate;UPDATE WWP_Subscription SET WWPSubscriptionEntityRecordId=:WWPSubscriptionEntityRecordId, WWPSubscriptionEntityRecordDes=:WWPSubscriptionEntityRecordDes, WWPSubscriptionRoleId=:WWPSubscriptionRoleId, WWPSubscriptionSubscribed=:WWPSubscriptionSubscribed, WWPNotificationDefinitionId=:WWPNotificationDefinitionId, WWPUserExtendedId=:WWPUserExtendedId  WHERE WWPSubscriptionId = :WWPSubscriptionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000J16)
          ,new CursorDef("T000J17", "SAVEPOINT gxupdate;DELETE FROM WWP_Subscription  WHERE WWPSubscriptionId = :WWPSubscriptionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000J17)
          ,new CursorDef("T000J18", "SELECT WWPEntityId, WWPNotificationDefinitionDescr FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J18,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000J19", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J19,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000J20", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J20,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000J21", "SELECT WWPSubscriptionId FROM WWP_Subscription ORDER BY WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J21,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[3])[0] = rslt.getString(4, 40);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((bool[]) buf[5])[0] = rslt.getBool(5);
             ((long[]) buf[6])[0] = rslt.getLong(6);
             ((string[]) buf[7])[0] = rslt.getString(7, 40);
             ((bool[]) buf[8])[0] = rslt.wasNull(7);
             return;
          case 1 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getString(4, 40);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((bool[]) buf[5])[0] = rslt.getBool(5);
             ((long[]) buf[6])[0] = rslt.getLong(6);
             ((string[]) buf[7])[0] = rslt.getString(7, 40);
             ((bool[]) buf[8])[0] = rslt.wasNull(7);
             return;
          case 2 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 4 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 5 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((long[]) buf[1])[0] = rslt.getLong(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getString(8, 40);
             ((bool[]) buf[8])[0] = rslt.wasNull(8);
             ((bool[]) buf[9])[0] = rslt.getBool(9);
             ((long[]) buf[10])[0] = rslt.getLong(10);
             ((string[]) buf[11])[0] = rslt.getString(11, 40);
             ((bool[]) buf[12])[0] = rslt.wasNull(11);
             return;
          case 6 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             return;
          case 7 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 8 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 9 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 10 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 11 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 13 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 16 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             return;
          case 17 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 18 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 19 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
    }
 }

}

}
