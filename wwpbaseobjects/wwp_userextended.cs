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
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_userextended : GXDataArea
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
         Form.Meta.addItem("description", context.GetMessage( "Extended User from GAMUser", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPUserExtendedId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_userextended( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_userextended( IGxContext context )
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
         chkWWPUserExtendedSMSNotif = new GXCheckbox();
         chkWWPUserExtendedMobileNotif = new GXCheckbox();
         chkWWPUserExtendedDesktopNotif = new GXCheckbox();
         chkWWPUserExtendedDeleted = new GXCheckbox();
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
            return "wwpuserextended_Execute" ;
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
         A117WWPUserExtendedSMSNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A117WWPUserExtendedSMSNotif));
         AssignAttri("", false, "A117WWPUserExtendedSMSNotif", A117WWPUserExtendedSMSNotif);
         A118WWPUserExtendedMobileNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A118WWPUserExtendedMobileNotif));
         AssignAttri("", false, "A118WWPUserExtendedMobileNotif", A118WWPUserExtendedMobileNotif);
         A119WWPUserExtendedDesktopNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A119WWPUserExtendedDesktopNotif));
         AssignAttri("", false, "A119WWPUserExtendedDesktopNotif", A119WWPUserExtendedDesktopNotif);
         A122WWPUserExtendedDeleted = StringUtil.StrToBool( StringUtil.BoolToStr( A122WWPUserExtendedDeleted));
         AssignAttri("", false, "A122WWPUserExtendedDeleted", A122WWPUserExtendedDeleted);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Extended User from GAMUser", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/WWP_UserExtended.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects/WWP_UserExtended.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPUserExtendedId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedId_Internalname, context.GetMessage( "Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedId_Internalname, StringUtil.RTrim( A112WWPUserExtendedId), StringUtil.RTrim( context.localUtil.Format( A112WWPUserExtendedId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedId_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_GAMGUID", "start", true, "", "HLP_WWPBaseObjects/WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgWWPUserExtendedPhoto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Photo", ""), "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A115WWPUserExtendedPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A115WWPUserExtendedPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000WWPUserExtendedPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A115WWPUserExtendedPhoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A115WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.PathToRelativeUrl( A115WWPUserExtendedPhoto));
         GxWebStd.gx_bitmap( context, imgWWPUserExtendedPhoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgWWPUserExtendedPhoto_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", "", "", 0, A115WWPUserExtendedPhoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_WWPBaseObjects/WWP_UserExtended.htm");
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A115WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.PathToRelativeUrl( A115WWPUserExtendedPhoto)), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "IsBlob", StringUtil.BoolToStr( A115WWPUserExtendedPhoto_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPUserExtendedName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedName_Internalname, context.GetMessage( "Extended Name", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedName_Internalname, A121WWPUserExtendedName, StringUtil.RTrim( context.localUtil.Format( A121WWPUserExtendedName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/WWP_UserExtended.htm");
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
         GxWebStd.gx_label_element( context, edtWWPUserExtendedFullName_Internalname, context.GetMessage( "Full Name", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedFullName_Internalname, A113WWPUserExtendedFullName, StringUtil.RTrim( context.localUtil.Format( A113WWPUserExtendedFullName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedFullName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedFullName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPUserExtendedPhone_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedPhone_Internalname, context.GetMessage( "Phone", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A120WWPUserExtendedPhone);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedPhone_Internalname, StringUtil.RTrim( A120WWPUserExtendedPhone), StringUtil.RTrim( context.localUtil.Format( A120WWPUserExtendedPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtWWPUserExtendedPhone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_WWPBaseObjects/WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPUserExtendedEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedEmail_Internalname, context.GetMessage( "Email", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedEmail_Internalname, A114WWPUserExtendedEmail, StringUtil.RTrim( context.localUtil.Format( A114WWPUserExtendedEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A114WWPUserExtendedEmail, "", "", "", edtWWPUserExtendedEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_WWPBaseObjects/WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPUserExtendedEmaiNotif_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedEmaiNotif_Internalname, context.GetMessage( "Email Notifications", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedEmaiNotif_Internalname, StringUtil.BoolToStr( A116WWPUserExtendedEmaiNotif), StringUtil.BoolToStr( A116WWPUserExtendedEmaiNotif), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedEmaiNotif_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedEmaiNotif_Enabled, 0, "text", "", 100, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPUserExtendedSMSNotif_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPUserExtendedSMSNotif_Internalname, context.GetMessage( "SMS Notifications", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPUserExtendedSMSNotif_Internalname, StringUtil.BoolToStr( A117WWPUserExtendedSMSNotif), "", context.GetMessage( "SMS Notifications", ""), 1, chkWWPUserExtendedSMSNotif.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(69, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,69);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPUserExtendedMobileNotif_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPUserExtendedMobileNotif_Internalname, context.GetMessage( "Mobile Notifications", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPUserExtendedMobileNotif_Internalname, StringUtil.BoolToStr( A118WWPUserExtendedMobileNotif), "", context.GetMessage( "Mobile Notifications", ""), 1, chkWWPUserExtendedMobileNotif.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(74, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,74);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPUserExtendedDesktopNotif_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPUserExtendedDesktopNotif_Internalname, context.GetMessage( "Destkop Notifications", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPUserExtendedDesktopNotif_Internalname, StringUtil.BoolToStr( A119WWPUserExtendedDesktopNotif), "", context.GetMessage( "Destkop Notifications", ""), 1, chkWWPUserExtendedDesktopNotif.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(79, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,79);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPUserExtendedDeleted_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPUserExtendedDeleted_Internalname, context.GetMessage( "Extended Deleted", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPUserExtendedDeleted_Internalname, StringUtil.BoolToStr( A122WWPUserExtendedDeleted), "", context.GetMessage( "Extended Deleted", ""), 1, chkWWPUserExtendedDeleted.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(84, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,84);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPUserExtendedDeletedIn_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedDeletedIn_Internalname, context.GetMessage( "Deleted In", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPUserExtendedDeletedIn_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedDeletedIn_Internalname, context.localUtil.TToC( A123WWPUserExtendedDeletedIn, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A123WWPUserExtendedDeletedIn, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedDeletedIn_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedDeletedIn_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/WWP_UserExtended.htm");
         GxWebStd.gx_bitmap( context, edtWWPUserExtendedDeletedIn_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPUserExtendedDeletedIn_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/WWP_UserExtended.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/WWP_UserExtended.htm");
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
            Z112WWPUserExtendedId = cgiGet( "Z112WWPUserExtendedId");
            Z121WWPUserExtendedName = cgiGet( "Z121WWPUserExtendedName");
            Z113WWPUserExtendedFullName = cgiGet( "Z113WWPUserExtendedFullName");
            Z120WWPUserExtendedPhone = cgiGet( "Z120WWPUserExtendedPhone");
            Z114WWPUserExtendedEmail = cgiGet( "Z114WWPUserExtendedEmail");
            Z116WWPUserExtendedEmaiNotif = StringUtil.StrToBool( cgiGet( "Z116WWPUserExtendedEmaiNotif"));
            Z117WWPUserExtendedSMSNotif = StringUtil.StrToBool( cgiGet( "Z117WWPUserExtendedSMSNotif"));
            Z118WWPUserExtendedMobileNotif = StringUtil.StrToBool( cgiGet( "Z118WWPUserExtendedMobileNotif"));
            Z119WWPUserExtendedDesktopNotif = StringUtil.StrToBool( cgiGet( "Z119WWPUserExtendedDesktopNotif"));
            Z122WWPUserExtendedDeleted = StringUtil.StrToBool( cgiGet( "Z122WWPUserExtendedDeleted"));
            Z123WWPUserExtendedDeletedIn = context.localUtil.CToT( cgiGet( "Z123WWPUserExtendedDeletedIn"), 0);
            n123WWPUserExtendedDeletedIn = ((DateTime.MinValue==A123WWPUserExtendedDeletedIn) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            A40000WWPUserExtendedPhoto_GXI = cgiGet( "WWPUSEREXTENDEDPHOTO_GXI");
            /* Read variables values. */
            A112WWPUserExtendedId = cgiGet( edtWWPUserExtendedId_Internalname);
            n112WWPUserExtendedId = false;
            AssignAttri("", false, "A112WWPUserExtendedId", A112WWPUserExtendedId);
            A115WWPUserExtendedPhoto = cgiGet( imgWWPUserExtendedPhoto_Internalname);
            AssignAttri("", false, "A115WWPUserExtendedPhoto", A115WWPUserExtendedPhoto);
            A121WWPUserExtendedName = cgiGet( edtWWPUserExtendedName_Internalname);
            AssignAttri("", false, "A121WWPUserExtendedName", A121WWPUserExtendedName);
            A113WWPUserExtendedFullName = cgiGet( edtWWPUserExtendedFullName_Internalname);
            AssignAttri("", false, "A113WWPUserExtendedFullName", A113WWPUserExtendedFullName);
            A120WWPUserExtendedPhone = cgiGet( edtWWPUserExtendedPhone_Internalname);
            AssignAttri("", false, "A120WWPUserExtendedPhone", A120WWPUserExtendedPhone);
            A114WWPUserExtendedEmail = cgiGet( edtWWPUserExtendedEmail_Internalname);
            AssignAttri("", false, "A114WWPUserExtendedEmail", A114WWPUserExtendedEmail);
            A116WWPUserExtendedEmaiNotif = StringUtil.StrToBool( cgiGet( edtWWPUserExtendedEmaiNotif_Internalname));
            AssignAttri("", false, "A116WWPUserExtendedEmaiNotif", A116WWPUserExtendedEmaiNotif);
            A117WWPUserExtendedSMSNotif = StringUtil.StrToBool( cgiGet( chkWWPUserExtendedSMSNotif_Internalname));
            AssignAttri("", false, "A117WWPUserExtendedSMSNotif", A117WWPUserExtendedSMSNotif);
            A118WWPUserExtendedMobileNotif = StringUtil.StrToBool( cgiGet( chkWWPUserExtendedMobileNotif_Internalname));
            AssignAttri("", false, "A118WWPUserExtendedMobileNotif", A118WWPUserExtendedMobileNotif);
            A119WWPUserExtendedDesktopNotif = StringUtil.StrToBool( cgiGet( chkWWPUserExtendedDesktopNotif_Internalname));
            AssignAttri("", false, "A119WWPUserExtendedDesktopNotif", A119WWPUserExtendedDesktopNotif);
            A122WWPUserExtendedDeleted = StringUtil.StrToBool( cgiGet( chkWWPUserExtendedDeleted_Internalname));
            AssignAttri("", false, "A122WWPUserExtendedDeleted", A122WWPUserExtendedDeleted);
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPUserExtendedDeletedIn_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "WWPUser Extended Deleted In", "")}), 1, "WWPUSEREXTENDEDDELETEDIN");
               AnyError = 1;
               GX_FocusControl = edtWWPUserExtendedDeletedIn_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A123WWPUserExtendedDeletedIn = (DateTime)(DateTime.MinValue);
               n123WWPUserExtendedDeletedIn = false;
               AssignAttri("", false, "A123WWPUserExtendedDeletedIn", context.localUtil.TToC( A123WWPUserExtendedDeletedIn, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A123WWPUserExtendedDeletedIn = context.localUtil.CToT( cgiGet( edtWWPUserExtendedDeletedIn_Internalname));
               n123WWPUserExtendedDeletedIn = false;
               AssignAttri("", false, "A123WWPUserExtendedDeletedIn", context.localUtil.TToC( A123WWPUserExtendedDeletedIn, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            n123WWPUserExtendedDeletedIn = ((DateTime.MinValue==A123WWPUserExtendedDeletedIn) ? true : false);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            getMultimediaValue(imgWWPUserExtendedPhoto_Internalname, ref  A115WWPUserExtendedPhoto, ref  A40000WWPUserExtendedPhoto_GXI);
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
               A112WWPUserExtendedId = GetPar( "WWPUserExtendedId");
               n112WWPUserExtendedId = false;
               AssignAttri("", false, "A112WWPUserExtendedId", A112WWPUserExtendedId);
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
               InitAll0G26( ) ;
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
         DisableAttributes0G26( ) ;
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

      protected void ResetCaption0G0( )
      {
      }

      protected void ZM0G26( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z121WWPUserExtendedName = T000G3_A121WWPUserExtendedName[0];
               Z113WWPUserExtendedFullName = T000G3_A113WWPUserExtendedFullName[0];
               Z120WWPUserExtendedPhone = T000G3_A120WWPUserExtendedPhone[0];
               Z114WWPUserExtendedEmail = T000G3_A114WWPUserExtendedEmail[0];
               Z116WWPUserExtendedEmaiNotif = T000G3_A116WWPUserExtendedEmaiNotif[0];
               Z117WWPUserExtendedSMSNotif = T000G3_A117WWPUserExtendedSMSNotif[0];
               Z118WWPUserExtendedMobileNotif = T000G3_A118WWPUserExtendedMobileNotif[0];
               Z119WWPUserExtendedDesktopNotif = T000G3_A119WWPUserExtendedDesktopNotif[0];
               Z122WWPUserExtendedDeleted = T000G3_A122WWPUserExtendedDeleted[0];
               Z123WWPUserExtendedDeletedIn = T000G3_A123WWPUserExtendedDeletedIn[0];
            }
            else
            {
               Z121WWPUserExtendedName = A121WWPUserExtendedName;
               Z113WWPUserExtendedFullName = A113WWPUserExtendedFullName;
               Z120WWPUserExtendedPhone = A120WWPUserExtendedPhone;
               Z114WWPUserExtendedEmail = A114WWPUserExtendedEmail;
               Z116WWPUserExtendedEmaiNotif = A116WWPUserExtendedEmaiNotif;
               Z117WWPUserExtendedSMSNotif = A117WWPUserExtendedSMSNotif;
               Z118WWPUserExtendedMobileNotif = A118WWPUserExtendedMobileNotif;
               Z119WWPUserExtendedDesktopNotif = A119WWPUserExtendedDesktopNotif;
               Z122WWPUserExtendedDeleted = A122WWPUserExtendedDeleted;
               Z123WWPUserExtendedDeletedIn = A123WWPUserExtendedDeletedIn;
            }
         }
         if ( GX_JID == -2 )
         {
            Z112WWPUserExtendedId = A112WWPUserExtendedId;
            Z115WWPUserExtendedPhoto = A115WWPUserExtendedPhoto;
            Z40000WWPUserExtendedPhoto_GXI = A40000WWPUserExtendedPhoto_GXI;
            Z121WWPUserExtendedName = A121WWPUserExtendedName;
            Z113WWPUserExtendedFullName = A113WWPUserExtendedFullName;
            Z120WWPUserExtendedPhone = A120WWPUserExtendedPhone;
            Z114WWPUserExtendedEmail = A114WWPUserExtendedEmail;
            Z116WWPUserExtendedEmaiNotif = A116WWPUserExtendedEmaiNotif;
            Z117WWPUserExtendedSMSNotif = A117WWPUserExtendedSMSNotif;
            Z118WWPUserExtendedMobileNotif = A118WWPUserExtendedMobileNotif;
            Z119WWPUserExtendedDesktopNotif = A119WWPUserExtendedDesktopNotif;
            Z122WWPUserExtendedDeleted = A122WWPUserExtendedDeleted;
            Z123WWPUserExtendedDeletedIn = A123WWPUserExtendedDeletedIn;
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

      protected void Load0G26( )
      {
         /* Using cursor T000G4 */
         pr_default.execute(2, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound26 = 1;
            A40000WWPUserExtendedPhoto_GXI = T000G4_A40000WWPUserExtendedPhoto_GXI[0];
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A115WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A115WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A115WWPUserExtendedPhoto), true);
            A121WWPUserExtendedName = T000G4_A121WWPUserExtendedName[0];
            AssignAttri("", false, "A121WWPUserExtendedName", A121WWPUserExtendedName);
            A113WWPUserExtendedFullName = T000G4_A113WWPUserExtendedFullName[0];
            AssignAttri("", false, "A113WWPUserExtendedFullName", A113WWPUserExtendedFullName);
            A120WWPUserExtendedPhone = T000G4_A120WWPUserExtendedPhone[0];
            AssignAttri("", false, "A120WWPUserExtendedPhone", A120WWPUserExtendedPhone);
            A114WWPUserExtendedEmail = T000G4_A114WWPUserExtendedEmail[0];
            AssignAttri("", false, "A114WWPUserExtendedEmail", A114WWPUserExtendedEmail);
            A116WWPUserExtendedEmaiNotif = T000G4_A116WWPUserExtendedEmaiNotif[0];
            AssignAttri("", false, "A116WWPUserExtendedEmaiNotif", A116WWPUserExtendedEmaiNotif);
            A117WWPUserExtendedSMSNotif = T000G4_A117WWPUserExtendedSMSNotif[0];
            AssignAttri("", false, "A117WWPUserExtendedSMSNotif", A117WWPUserExtendedSMSNotif);
            A118WWPUserExtendedMobileNotif = T000G4_A118WWPUserExtendedMobileNotif[0];
            AssignAttri("", false, "A118WWPUserExtendedMobileNotif", A118WWPUserExtendedMobileNotif);
            A119WWPUserExtendedDesktopNotif = T000G4_A119WWPUserExtendedDesktopNotif[0];
            AssignAttri("", false, "A119WWPUserExtendedDesktopNotif", A119WWPUserExtendedDesktopNotif);
            A122WWPUserExtendedDeleted = T000G4_A122WWPUserExtendedDeleted[0];
            AssignAttri("", false, "A122WWPUserExtendedDeleted", A122WWPUserExtendedDeleted);
            A123WWPUserExtendedDeletedIn = T000G4_A123WWPUserExtendedDeletedIn[0];
            n123WWPUserExtendedDeletedIn = T000G4_n123WWPUserExtendedDeletedIn[0];
            AssignAttri("", false, "A123WWPUserExtendedDeletedIn", context.localUtil.TToC( A123WWPUserExtendedDeletedIn, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A115WWPUserExtendedPhoto = T000G4_A115WWPUserExtendedPhoto[0];
            AssignAttri("", false, "A115WWPUserExtendedPhoto", A115WWPUserExtendedPhoto);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A115WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A115WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A115WWPUserExtendedPhoto), true);
            ZM0G26( -2) ;
         }
         pr_default.close(2);
         OnLoadActions0G26( ) ;
      }

      protected void OnLoadActions0G26( )
      {
      }

      protected void CheckExtendedTable0G26( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A114WWPUserExtendedEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "User Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "WWPUSEREXTENDEDEMAIL");
            AnyError = 1;
            GX_FocusControl = edtWWPUserExtendedEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0G26( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0G26( )
      {
         /* Using cursor T000G5 */
         pr_default.execute(3, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound26 = 1;
         }
         else
         {
            RcdFound26 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000G3 */
         pr_default.execute(1, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0G26( 2) ;
            RcdFound26 = 1;
            A112WWPUserExtendedId = T000G3_A112WWPUserExtendedId[0];
            n112WWPUserExtendedId = T000G3_n112WWPUserExtendedId[0];
            AssignAttri("", false, "A112WWPUserExtendedId", A112WWPUserExtendedId);
            A40000WWPUserExtendedPhoto_GXI = T000G3_A40000WWPUserExtendedPhoto_GXI[0];
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A115WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A115WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A115WWPUserExtendedPhoto), true);
            A121WWPUserExtendedName = T000G3_A121WWPUserExtendedName[0];
            AssignAttri("", false, "A121WWPUserExtendedName", A121WWPUserExtendedName);
            A113WWPUserExtendedFullName = T000G3_A113WWPUserExtendedFullName[0];
            AssignAttri("", false, "A113WWPUserExtendedFullName", A113WWPUserExtendedFullName);
            A120WWPUserExtendedPhone = T000G3_A120WWPUserExtendedPhone[0];
            AssignAttri("", false, "A120WWPUserExtendedPhone", A120WWPUserExtendedPhone);
            A114WWPUserExtendedEmail = T000G3_A114WWPUserExtendedEmail[0];
            AssignAttri("", false, "A114WWPUserExtendedEmail", A114WWPUserExtendedEmail);
            A116WWPUserExtendedEmaiNotif = T000G3_A116WWPUserExtendedEmaiNotif[0];
            AssignAttri("", false, "A116WWPUserExtendedEmaiNotif", A116WWPUserExtendedEmaiNotif);
            A117WWPUserExtendedSMSNotif = T000G3_A117WWPUserExtendedSMSNotif[0];
            AssignAttri("", false, "A117WWPUserExtendedSMSNotif", A117WWPUserExtendedSMSNotif);
            A118WWPUserExtendedMobileNotif = T000G3_A118WWPUserExtendedMobileNotif[0];
            AssignAttri("", false, "A118WWPUserExtendedMobileNotif", A118WWPUserExtendedMobileNotif);
            A119WWPUserExtendedDesktopNotif = T000G3_A119WWPUserExtendedDesktopNotif[0];
            AssignAttri("", false, "A119WWPUserExtendedDesktopNotif", A119WWPUserExtendedDesktopNotif);
            A122WWPUserExtendedDeleted = T000G3_A122WWPUserExtendedDeleted[0];
            AssignAttri("", false, "A122WWPUserExtendedDeleted", A122WWPUserExtendedDeleted);
            A123WWPUserExtendedDeletedIn = T000G3_A123WWPUserExtendedDeletedIn[0];
            n123WWPUserExtendedDeletedIn = T000G3_n123WWPUserExtendedDeletedIn[0];
            AssignAttri("", false, "A123WWPUserExtendedDeletedIn", context.localUtil.TToC( A123WWPUserExtendedDeletedIn, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A115WWPUserExtendedPhoto = T000G3_A115WWPUserExtendedPhoto[0];
            AssignAttri("", false, "A115WWPUserExtendedPhoto", A115WWPUserExtendedPhoto);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A115WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A115WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A115WWPUserExtendedPhoto), true);
            Z112WWPUserExtendedId = A112WWPUserExtendedId;
            sMode26 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0G26( ) ;
            if ( AnyError == 1 )
            {
               RcdFound26 = 0;
               InitializeNonKey0G26( ) ;
            }
            Gx_mode = sMode26;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound26 = 0;
            InitializeNonKey0G26( ) ;
            sMode26 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode26;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0G26( ) ;
         if ( RcdFound26 == 0 )
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
         RcdFound26 = 0;
         /* Using cursor T000G6 */
         pr_default.execute(4, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T000G6_A112WWPUserExtendedId[0], A112WWPUserExtendedId) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T000G6_A112WWPUserExtendedId[0], A112WWPUserExtendedId) > 0 ) ) )
            {
               A112WWPUserExtendedId = T000G6_A112WWPUserExtendedId[0];
               n112WWPUserExtendedId = T000G6_n112WWPUserExtendedId[0];
               AssignAttri("", false, "A112WWPUserExtendedId", A112WWPUserExtendedId);
               RcdFound26 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound26 = 0;
         /* Using cursor T000G7 */
         pr_default.execute(5, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T000G7_A112WWPUserExtendedId[0], A112WWPUserExtendedId) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T000G7_A112WWPUserExtendedId[0], A112WWPUserExtendedId) < 0 ) ) )
            {
               A112WWPUserExtendedId = T000G7_A112WWPUserExtendedId[0];
               n112WWPUserExtendedId = T000G7_n112WWPUserExtendedId[0];
               AssignAttri("", false, "A112WWPUserExtendedId", A112WWPUserExtendedId);
               RcdFound26 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0G26( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPUserExtendedId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0G26( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound26 == 1 )
            {
               if ( StringUtil.StrCmp(A112WWPUserExtendedId, Z112WWPUserExtendedId) != 0 )
               {
                  A112WWPUserExtendedId = Z112WWPUserExtendedId;
                  n112WWPUserExtendedId = false;
                  AssignAttri("", false, "A112WWPUserExtendedId", A112WWPUserExtendedId);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPUSEREXTENDEDID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPUserExtendedId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPUserExtendedId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0G26( ) ;
                  GX_FocusControl = edtWWPUserExtendedId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A112WWPUserExtendedId, Z112WWPUserExtendedId) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPUserExtendedId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0G26( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPUSEREXTENDEDID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPUserExtendedId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPUserExtendedId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0G26( ) ;
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
         if ( StringUtil.StrCmp(A112WWPUserExtendedId, Z112WWPUserExtendedId) != 0 )
         {
            A112WWPUserExtendedId = Z112WWPUserExtendedId;
            n112WWPUserExtendedId = false;
            AssignAttri("", false, "A112WWPUserExtendedId", A112WWPUserExtendedId);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPUSEREXTENDEDID");
            AnyError = 1;
            GX_FocusControl = edtWWPUserExtendedId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPUserExtendedId_Internalname;
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
         if ( RcdFound26 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPUSEREXTENDEDID");
            AnyError = 1;
            GX_FocusControl = edtWWPUserExtendedId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = imgWWPUserExtendedPhoto_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0G26( ) ;
         if ( RcdFound26 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = imgWWPUserExtendedPhoto_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0G26( ) ;
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
         if ( RcdFound26 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = imgWWPUserExtendedPhoto_Internalname;
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
         if ( RcdFound26 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = imgWWPUserExtendedPhoto_Internalname;
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
         ScanStart0G26( ) ;
         if ( RcdFound26 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound26 != 0 )
            {
               ScanNext0G26( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = imgWWPUserExtendedPhoto_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0G26( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0G26( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000G2 */
            pr_default.execute(0, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_UserExtended"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z121WWPUserExtendedName, T000G2_A121WWPUserExtendedName[0]) != 0 ) || ( StringUtil.StrCmp(Z113WWPUserExtendedFullName, T000G2_A113WWPUserExtendedFullName[0]) != 0 ) || ( StringUtil.StrCmp(Z120WWPUserExtendedPhone, T000G2_A120WWPUserExtendedPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z114WWPUserExtendedEmail, T000G2_A114WWPUserExtendedEmail[0]) != 0 ) || ( Z116WWPUserExtendedEmaiNotif != T000G2_A116WWPUserExtendedEmaiNotif[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z117WWPUserExtendedSMSNotif != T000G2_A117WWPUserExtendedSMSNotif[0] ) || ( Z118WWPUserExtendedMobileNotif != T000G2_A118WWPUserExtendedMobileNotif[0] ) || ( Z119WWPUserExtendedDesktopNotif != T000G2_A119WWPUserExtendedDesktopNotif[0] ) || ( Z122WWPUserExtendedDeleted != T000G2_A122WWPUserExtendedDeleted[0] ) || ( Z123WWPUserExtendedDeletedIn != T000G2_A123WWPUserExtendedDeletedIn[0] ) )
            {
               if ( StringUtil.StrCmp(Z121WWPUserExtendedName, T000G2_A121WWPUserExtendedName[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedName");
                  GXUtil.WriteLogRaw("Old: ",Z121WWPUserExtendedName);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A121WWPUserExtendedName[0]);
               }
               if ( StringUtil.StrCmp(Z113WWPUserExtendedFullName, T000G2_A113WWPUserExtendedFullName[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedFullName");
                  GXUtil.WriteLogRaw("Old: ",Z113WWPUserExtendedFullName);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A113WWPUserExtendedFullName[0]);
               }
               if ( StringUtil.StrCmp(Z120WWPUserExtendedPhone, T000G2_A120WWPUserExtendedPhone[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedPhone");
                  GXUtil.WriteLogRaw("Old: ",Z120WWPUserExtendedPhone);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A120WWPUserExtendedPhone[0]);
               }
               if ( StringUtil.StrCmp(Z114WWPUserExtendedEmail, T000G2_A114WWPUserExtendedEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedEmail");
                  GXUtil.WriteLogRaw("Old: ",Z114WWPUserExtendedEmail);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A114WWPUserExtendedEmail[0]);
               }
               if ( Z116WWPUserExtendedEmaiNotif != T000G2_A116WWPUserExtendedEmaiNotif[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedEmaiNotif");
                  GXUtil.WriteLogRaw("Old: ",Z116WWPUserExtendedEmaiNotif);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A116WWPUserExtendedEmaiNotif[0]);
               }
               if ( Z117WWPUserExtendedSMSNotif != T000G2_A117WWPUserExtendedSMSNotif[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedSMSNotif");
                  GXUtil.WriteLogRaw("Old: ",Z117WWPUserExtendedSMSNotif);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A117WWPUserExtendedSMSNotif[0]);
               }
               if ( Z118WWPUserExtendedMobileNotif != T000G2_A118WWPUserExtendedMobileNotif[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedMobileNotif");
                  GXUtil.WriteLogRaw("Old: ",Z118WWPUserExtendedMobileNotif);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A118WWPUserExtendedMobileNotif[0]);
               }
               if ( Z119WWPUserExtendedDesktopNotif != T000G2_A119WWPUserExtendedDesktopNotif[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedDesktopNotif");
                  GXUtil.WriteLogRaw("Old: ",Z119WWPUserExtendedDesktopNotif);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A119WWPUserExtendedDesktopNotif[0]);
               }
               if ( Z122WWPUserExtendedDeleted != T000G2_A122WWPUserExtendedDeleted[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedDeleted");
                  GXUtil.WriteLogRaw("Old: ",Z122WWPUserExtendedDeleted);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A122WWPUserExtendedDeleted[0]);
               }
               if ( Z123WWPUserExtendedDeletedIn != T000G2_A123WWPUserExtendedDeletedIn[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedDeletedIn");
                  GXUtil.WriteLogRaw("Old: ",Z123WWPUserExtendedDeletedIn);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A123WWPUserExtendedDeletedIn[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_UserExtended"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0G26( )
      {
         if ( ! IsAuthorized("wwpuserextended_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0G26( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G26( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0G26( 0) ;
            CheckOptimisticConcurrency0G26( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G26( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0G26( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000G8 */
                     pr_default.execute(6, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId, A115WWPUserExtendedPhoto, A40000WWPUserExtendedPhoto_GXI, A121WWPUserExtendedName, A113WWPUserExtendedFullName, A120WWPUserExtendedPhone, A114WWPUserExtendedEmail, A116WWPUserExtendedEmaiNotif, A117WWPUserExtendedSMSNotif, A118WWPUserExtendedMobileNotif, A119WWPUserExtendedDesktopNotif, A122WWPUserExtendedDeleted, n123WWPUserExtendedDeletedIn, A123WWPUserExtendedDeletedIn});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_UserExtended");
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
                           ResetCaption0G0( ) ;
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
               Load0G26( ) ;
            }
            EndLevel0G26( ) ;
         }
         CloseExtendedTableCursors0G26( ) ;
      }

      protected void Update0G26( )
      {
         if ( ! IsAuthorized("wwpuserextended_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0G26( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G26( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G26( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G26( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0G26( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000G9 */
                     pr_default.execute(7, new Object[] {A121WWPUserExtendedName, A113WWPUserExtendedFullName, A120WWPUserExtendedPhone, A114WWPUserExtendedEmail, A116WWPUserExtendedEmaiNotif, A117WWPUserExtendedSMSNotif, A118WWPUserExtendedMobileNotif, A119WWPUserExtendedDesktopNotif, A122WWPUserExtendedDeleted, n123WWPUserExtendedDeletedIn, A123WWPUserExtendedDeletedIn, n112WWPUserExtendedId, A112WWPUserExtendedId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_UserExtended");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_UserExtended"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0G26( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0G0( ) ;
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
            EndLevel0G26( ) ;
         }
         CloseExtendedTableCursors0G26( ) ;
      }

      protected void DeferredUpdate0G26( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000G10 */
            pr_default.execute(8, new Object[] {A115WWPUserExtendedPhoto, A40000WWPUserExtendedPhoto_GXI, n112WWPUserExtendedId, A112WWPUserExtendedId});
            pr_default.close(8);
            pr_default.SmartCacheProvider.SetUpdated("WWP_UserExtended");
         }
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("wwpuserextended_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0G26( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G26( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0G26( ) ;
            AfterConfirm0G26( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0G26( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000G11 */
                  pr_default.execute(9, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_UserExtended");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound26 == 0 )
                        {
                           InitAll0G26( ) ;
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
                        ResetCaption0G0( ) ;
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
         sMode26 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0G26( ) ;
         Gx_mode = sMode26;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0G26( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000G12 */
            pr_default.execute(10, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_DiscussionMessageMention", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T000G13 */
            pr_default.execute(11, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWPForm Instance", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T000G14 */
            pr_default.execute(12, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_DiscussionMessage", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T000G15 */
            pr_default.execute(13, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_Notification", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T000G16 */
            pr_default.execute(14, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_WebClient", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T000G17 */
            pr_default.execute(15, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_Subscription", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
         }
      }

      protected void EndLevel0G26( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0G26( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("wwpbaseobjects.wwp_userextended",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0G0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("wwpbaseobjects.wwp_userextended",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0G26( )
      {
         /* Using cursor T000G18 */
         pr_default.execute(16);
         RcdFound26 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound26 = 1;
            A112WWPUserExtendedId = T000G18_A112WWPUserExtendedId[0];
            n112WWPUserExtendedId = T000G18_n112WWPUserExtendedId[0];
            AssignAttri("", false, "A112WWPUserExtendedId", A112WWPUserExtendedId);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0G26( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound26 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound26 = 1;
            A112WWPUserExtendedId = T000G18_A112WWPUserExtendedId[0];
            n112WWPUserExtendedId = T000G18_n112WWPUserExtendedId[0];
            AssignAttri("", false, "A112WWPUserExtendedId", A112WWPUserExtendedId);
         }
      }

      protected void ScanEnd0G26( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm0G26( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0G26( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0G26( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0G26( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0G26( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0G26( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0G26( )
      {
         edtWWPUserExtendedId_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedId_Enabled), 5, 0), true);
         imgWWPUserExtendedPhoto_Enabled = 0;
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgWWPUserExtendedPhoto_Enabled), 5, 0), true);
         edtWWPUserExtendedName_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedName_Enabled), 5, 0), true);
         edtWWPUserExtendedFullName_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedFullName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedFullName_Enabled), 5, 0), true);
         edtWWPUserExtendedPhone_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedPhone_Enabled), 5, 0), true);
         edtWWPUserExtendedEmail_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedEmail_Enabled), 5, 0), true);
         edtWWPUserExtendedEmaiNotif_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedEmaiNotif_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedEmaiNotif_Enabled), 5, 0), true);
         chkWWPUserExtendedSMSNotif.Enabled = 0;
         AssignProp("", false, chkWWPUserExtendedSMSNotif_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPUserExtendedSMSNotif.Enabled), 5, 0), true);
         chkWWPUserExtendedMobileNotif.Enabled = 0;
         AssignProp("", false, chkWWPUserExtendedMobileNotif_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPUserExtendedMobileNotif.Enabled), 5, 0), true);
         chkWWPUserExtendedDesktopNotif.Enabled = 0;
         AssignProp("", false, chkWWPUserExtendedDesktopNotif_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPUserExtendedDesktopNotif.Enabled), 5, 0), true);
         chkWWPUserExtendedDeleted.Enabled = 0;
         AssignProp("", false, chkWWPUserExtendedDeleted_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPUserExtendedDeleted.Enabled), 5, 0), true);
         edtWWPUserExtendedDeletedIn_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedDeletedIn_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedDeletedIn_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0G26( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0G0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.wwp_userextended.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z112WWPUserExtendedId", StringUtil.RTrim( Z112WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "Z121WWPUserExtendedName", Z121WWPUserExtendedName);
         GxWebStd.gx_hidden_field( context, "Z113WWPUserExtendedFullName", Z113WWPUserExtendedFullName);
         GxWebStd.gx_hidden_field( context, "Z120WWPUserExtendedPhone", StringUtil.RTrim( Z120WWPUserExtendedPhone));
         GxWebStd.gx_hidden_field( context, "Z114WWPUserExtendedEmail", Z114WWPUserExtendedEmail);
         GxWebStd.gx_boolean_hidden_field( context, "Z116WWPUserExtendedEmaiNotif", Z116WWPUserExtendedEmaiNotif);
         GxWebStd.gx_boolean_hidden_field( context, "Z117WWPUserExtendedSMSNotif", Z117WWPUserExtendedSMSNotif);
         GxWebStd.gx_boolean_hidden_field( context, "Z118WWPUserExtendedMobileNotif", Z118WWPUserExtendedMobileNotif);
         GxWebStd.gx_boolean_hidden_field( context, "Z119WWPUserExtendedDesktopNotif", Z119WWPUserExtendedDesktopNotif);
         GxWebStd.gx_boolean_hidden_field( context, "Z122WWPUserExtendedDeleted", Z122WWPUserExtendedDeleted);
         GxWebStd.gx_hidden_field( context, "Z123WWPUserExtendedDeletedIn", context.localUtil.TToC( Z123WWPUserExtendedDeletedIn, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "WWPUSEREXTENDEDPHOTO_GXI", A40000WWPUserExtendedPhoto_GXI);
         GXCCtlgxBlob = "WWPUSEREXTENDEDPHOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A115WWPUserExtendedPhoto);
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
         return formatLink("wwpbaseobjects.wwp_userextended.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.WWP_UserExtended" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Extended User from GAMUser", "") ;
      }

      protected void InitializeNonKey0G26( )
      {
         A115WWPUserExtendedPhoto = "";
         AssignAttri("", false, "A115WWPUserExtendedPhoto", A115WWPUserExtendedPhoto);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A115WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A115WWPUserExtendedPhoto))), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A115WWPUserExtendedPhoto), true);
         A40000WWPUserExtendedPhoto_GXI = "";
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A115WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A115WWPUserExtendedPhoto))), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A115WWPUserExtendedPhoto), true);
         A121WWPUserExtendedName = "";
         AssignAttri("", false, "A121WWPUserExtendedName", A121WWPUserExtendedName);
         A113WWPUserExtendedFullName = "";
         AssignAttri("", false, "A113WWPUserExtendedFullName", A113WWPUserExtendedFullName);
         A120WWPUserExtendedPhone = "";
         AssignAttri("", false, "A120WWPUserExtendedPhone", A120WWPUserExtendedPhone);
         A114WWPUserExtendedEmail = "";
         AssignAttri("", false, "A114WWPUserExtendedEmail", A114WWPUserExtendedEmail);
         A116WWPUserExtendedEmaiNotif = false;
         AssignAttri("", false, "A116WWPUserExtendedEmaiNotif", A116WWPUserExtendedEmaiNotif);
         A117WWPUserExtendedSMSNotif = false;
         AssignAttri("", false, "A117WWPUserExtendedSMSNotif", A117WWPUserExtendedSMSNotif);
         A118WWPUserExtendedMobileNotif = false;
         AssignAttri("", false, "A118WWPUserExtendedMobileNotif", A118WWPUserExtendedMobileNotif);
         A119WWPUserExtendedDesktopNotif = false;
         AssignAttri("", false, "A119WWPUserExtendedDesktopNotif", A119WWPUserExtendedDesktopNotif);
         A122WWPUserExtendedDeleted = false;
         AssignAttri("", false, "A122WWPUserExtendedDeleted", A122WWPUserExtendedDeleted);
         A123WWPUserExtendedDeletedIn = (DateTime)(DateTime.MinValue);
         n123WWPUserExtendedDeletedIn = false;
         AssignAttri("", false, "A123WWPUserExtendedDeletedIn", context.localUtil.TToC( A123WWPUserExtendedDeletedIn, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         n123WWPUserExtendedDeletedIn = ((DateTime.MinValue==A123WWPUserExtendedDeletedIn) ? true : false);
         Z121WWPUserExtendedName = "";
         Z113WWPUserExtendedFullName = "";
         Z120WWPUserExtendedPhone = "";
         Z114WWPUserExtendedEmail = "";
         Z116WWPUserExtendedEmaiNotif = false;
         Z117WWPUserExtendedSMSNotif = false;
         Z118WWPUserExtendedMobileNotif = false;
         Z119WWPUserExtendedDesktopNotif = false;
         Z122WWPUserExtendedDeleted = false;
         Z123WWPUserExtendedDeletedIn = (DateTime)(DateTime.MinValue);
      }

      protected void InitAll0G26( )
      {
         A112WWPUserExtendedId = "";
         n112WWPUserExtendedId = false;
         AssignAttri("", false, "A112WWPUserExtendedId", A112WWPUserExtendedId);
         InitializeNonKey0G26( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20257212492066", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/wwp_userextended.js", "?20257212492067", false, true);
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
         edtWWPUserExtendedId_Internalname = "WWPUSEREXTENDEDID";
         imgWWPUserExtendedPhoto_Internalname = "WWPUSEREXTENDEDPHOTO";
         edtWWPUserExtendedName_Internalname = "WWPUSEREXTENDEDNAME";
         edtWWPUserExtendedFullName_Internalname = "WWPUSEREXTENDEDFULLNAME";
         edtWWPUserExtendedPhone_Internalname = "WWPUSEREXTENDEDPHONE";
         edtWWPUserExtendedEmail_Internalname = "WWPUSEREXTENDEDEMAIL";
         edtWWPUserExtendedEmaiNotif_Internalname = "WWPUSEREXTENDEDEMAINOTIF";
         chkWWPUserExtendedSMSNotif_Internalname = "WWPUSEREXTENDEDSMSNOTIF";
         chkWWPUserExtendedMobileNotif_Internalname = "WWPUSEREXTENDEDMOBILENOTIF";
         chkWWPUserExtendedDesktopNotif_Internalname = "WWPUSEREXTENDEDDESKTOPNOTIF";
         chkWWPUserExtendedDeleted_Internalname = "WWPUSEREXTENDEDDELETED";
         edtWWPUserExtendedDeletedIn_Internalname = "WWPUSEREXTENDEDDELETEDIN";
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
         Form.Caption = context.GetMessage( "Extended User from GAMUser", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtWWPUserExtendedDeletedIn_Jsonclick = "";
         edtWWPUserExtendedDeletedIn_Enabled = 1;
         chkWWPUserExtendedDeleted.Enabled = 1;
         chkWWPUserExtendedDesktopNotif.Enabled = 1;
         chkWWPUserExtendedMobileNotif.Enabled = 1;
         chkWWPUserExtendedSMSNotif.Enabled = 1;
         edtWWPUserExtendedEmaiNotif_Jsonclick = "";
         edtWWPUserExtendedEmaiNotif_Enabled = 1;
         edtWWPUserExtendedEmail_Jsonclick = "";
         edtWWPUserExtendedEmail_Enabled = 1;
         edtWWPUserExtendedPhone_Jsonclick = "";
         edtWWPUserExtendedPhone_Enabled = 1;
         edtWWPUserExtendedFullName_Jsonclick = "";
         edtWWPUserExtendedFullName_Enabled = 1;
         edtWWPUserExtendedName_Jsonclick = "";
         edtWWPUserExtendedName_Enabled = 1;
         imgWWPUserExtendedPhoto_Enabled = 1;
         edtWWPUserExtendedId_Jsonclick = "";
         edtWWPUserExtendedId_Enabled = 1;
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
         chkWWPUserExtendedSMSNotif.Name = "WWPUSEREXTENDEDSMSNOTIF";
         chkWWPUserExtendedSMSNotif.WebTags = "";
         chkWWPUserExtendedSMSNotif.Caption = context.GetMessage( "SMS Notifications", "");
         AssignProp("", false, chkWWPUserExtendedSMSNotif_Internalname, "TitleCaption", chkWWPUserExtendedSMSNotif.Caption, true);
         chkWWPUserExtendedSMSNotif.CheckedValue = "false";
         A117WWPUserExtendedSMSNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A117WWPUserExtendedSMSNotif));
         AssignAttri("", false, "A117WWPUserExtendedSMSNotif", A117WWPUserExtendedSMSNotif);
         chkWWPUserExtendedMobileNotif.Name = "WWPUSEREXTENDEDMOBILENOTIF";
         chkWWPUserExtendedMobileNotif.WebTags = "";
         chkWWPUserExtendedMobileNotif.Caption = context.GetMessage( "Mobile Notifications", "");
         AssignProp("", false, chkWWPUserExtendedMobileNotif_Internalname, "TitleCaption", chkWWPUserExtendedMobileNotif.Caption, true);
         chkWWPUserExtendedMobileNotif.CheckedValue = "false";
         A118WWPUserExtendedMobileNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A118WWPUserExtendedMobileNotif));
         AssignAttri("", false, "A118WWPUserExtendedMobileNotif", A118WWPUserExtendedMobileNotif);
         chkWWPUserExtendedDesktopNotif.Name = "WWPUSEREXTENDEDDESKTOPNOTIF";
         chkWWPUserExtendedDesktopNotif.WebTags = "";
         chkWWPUserExtendedDesktopNotif.Caption = context.GetMessage( "Destkop Notifications", "");
         AssignProp("", false, chkWWPUserExtendedDesktopNotif_Internalname, "TitleCaption", chkWWPUserExtendedDesktopNotif.Caption, true);
         chkWWPUserExtendedDesktopNotif.CheckedValue = "false";
         A119WWPUserExtendedDesktopNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A119WWPUserExtendedDesktopNotif));
         AssignAttri("", false, "A119WWPUserExtendedDesktopNotif", A119WWPUserExtendedDesktopNotif);
         chkWWPUserExtendedDeleted.Name = "WWPUSEREXTENDEDDELETED";
         chkWWPUserExtendedDeleted.WebTags = "";
         chkWWPUserExtendedDeleted.Caption = context.GetMessage( "Extended Deleted", "");
         AssignProp("", false, chkWWPUserExtendedDeleted_Internalname, "TitleCaption", chkWWPUserExtendedDeleted.Caption, true);
         chkWWPUserExtendedDeleted.CheckedValue = "false";
         A122WWPUserExtendedDeleted = StringUtil.StrToBool( StringUtil.BoolToStr( A122WWPUserExtendedDeleted));
         AssignAttri("", false, "A122WWPUserExtendedDeleted", A122WWPUserExtendedDeleted);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = imgWWPUserExtendedPhoto_Internalname;
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

      public void Valid_Wwpuserextendedid( )
      {
         n112WWPUserExtendedId = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A117WWPUserExtendedSMSNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A117WWPUserExtendedSMSNotif));
         A118WWPUserExtendedMobileNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A118WWPUserExtendedMobileNotif));
         A119WWPUserExtendedDesktopNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A119WWPUserExtendedDesktopNotif));
         A122WWPUserExtendedDeleted = StringUtil.StrToBool( StringUtil.BoolToStr( A122WWPUserExtendedDeleted));
         /*  Sending validation outputs */
         AssignAttri("", false, "A115WWPUserExtendedPhoto", context.PathToRelativeUrl( A115WWPUserExtendedPhoto));
         GXCCtlgxBlob = "WWPUSEREXTENDEDPHOTO" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A115WWPUserExtendedPhoto));
         AssignAttri("", false, "A40000WWPUserExtendedPhoto_GXI", A40000WWPUserExtendedPhoto_GXI);
         AssignAttri("", false, "A121WWPUserExtendedName", A121WWPUserExtendedName);
         AssignAttri("", false, "A113WWPUserExtendedFullName", A113WWPUserExtendedFullName);
         AssignAttri("", false, "A120WWPUserExtendedPhone", StringUtil.RTrim( A120WWPUserExtendedPhone));
         AssignAttri("", false, "A114WWPUserExtendedEmail", A114WWPUserExtendedEmail);
         AssignAttri("", false, "A116WWPUserExtendedEmaiNotif", A116WWPUserExtendedEmaiNotif);
         AssignAttri("", false, "A117WWPUserExtendedSMSNotif", A117WWPUserExtendedSMSNotif);
         AssignAttri("", false, "A118WWPUserExtendedMobileNotif", A118WWPUserExtendedMobileNotif);
         AssignAttri("", false, "A119WWPUserExtendedDesktopNotif", A119WWPUserExtendedDesktopNotif);
         AssignAttri("", false, "A122WWPUserExtendedDeleted", A122WWPUserExtendedDeleted);
         AssignAttri("", false, "A123WWPUserExtendedDeletedIn", context.localUtil.TToC( A123WWPUserExtendedDeletedIn, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z112WWPUserExtendedId", StringUtil.RTrim( Z112WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "Z115WWPUserExtendedPhoto", context.PathToRelativeUrl( Z115WWPUserExtendedPhoto));
         GxWebStd.gx_hidden_field( context, "Z40000WWPUserExtendedPhoto_GXI", Z40000WWPUserExtendedPhoto_GXI);
         GxWebStd.gx_hidden_field( context, "Z121WWPUserExtendedName", Z121WWPUserExtendedName);
         GxWebStd.gx_hidden_field( context, "Z113WWPUserExtendedFullName", Z113WWPUserExtendedFullName);
         GxWebStd.gx_hidden_field( context, "Z120WWPUserExtendedPhone", StringUtil.RTrim( Z120WWPUserExtendedPhone));
         GxWebStd.gx_hidden_field( context, "Z114WWPUserExtendedEmail", Z114WWPUserExtendedEmail);
         GxWebStd.gx_hidden_field( context, "Z116WWPUserExtendedEmaiNotif", StringUtil.BoolToStr( Z116WWPUserExtendedEmaiNotif));
         GxWebStd.gx_hidden_field( context, "Z117WWPUserExtendedSMSNotif", StringUtil.BoolToStr( Z117WWPUserExtendedSMSNotif));
         GxWebStd.gx_hidden_field( context, "Z118WWPUserExtendedMobileNotif", StringUtil.BoolToStr( Z118WWPUserExtendedMobileNotif));
         GxWebStd.gx_hidden_field( context, "Z119WWPUserExtendedDesktopNotif", StringUtil.BoolToStr( Z119WWPUserExtendedDesktopNotif));
         GxWebStd.gx_hidden_field( context, "Z122WWPUserExtendedDeleted", StringUtil.BoolToStr( Z122WWPUserExtendedDeleted));
         GxWebStd.gx_hidden_field( context, "Z123WWPUserExtendedDeletedIn", context.localUtil.TToC( Z123WWPUserExtendedDeletedIn, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A117WWPUserExtendedSMSNotif","fld":"WWPUSEREXTENDEDSMSNOTIF"},{"av":"A118WWPUserExtendedMobileNotif","fld":"WWPUSEREXTENDEDMOBILENOTIF"},{"av":"A119WWPUserExtendedDesktopNotif","fld":"WWPUSEREXTENDEDDESKTOPNOTIF"},{"av":"A122WWPUserExtendedDeleted","fld":"WWPUSEREXTENDEDDELETED"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A117WWPUserExtendedSMSNotif","fld":"WWPUSEREXTENDEDSMSNOTIF"},{"av":"A118WWPUserExtendedMobileNotif","fld":"WWPUSEREXTENDEDMOBILENOTIF"},{"av":"A119WWPUserExtendedDesktopNotif","fld":"WWPUSEREXTENDEDDESKTOPNOTIF"},{"av":"A122WWPUserExtendedDeleted","fld":"WWPUSEREXTENDEDDELETED"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A117WWPUserExtendedSMSNotif","fld":"WWPUSEREXTENDEDSMSNOTIF"},{"av":"A118WWPUserExtendedMobileNotif","fld":"WWPUSEREXTENDEDMOBILENOTIF"},{"av":"A119WWPUserExtendedDesktopNotif","fld":"WWPUSEREXTENDEDDESKTOPNOTIF"},{"av":"A122WWPUserExtendedDeleted","fld":"WWPUSEREXTENDEDDELETED"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A117WWPUserExtendedSMSNotif","fld":"WWPUSEREXTENDEDSMSNOTIF"},{"av":"A118WWPUserExtendedMobileNotif","fld":"WWPUSEREXTENDEDMOBILENOTIF"},{"av":"A119WWPUserExtendedDesktopNotif","fld":"WWPUSEREXTENDEDDESKTOPNOTIF"},{"av":"A122WWPUserExtendedDeleted","fld":"WWPUSEREXTENDEDDELETED"}]}""");
         setEventMetadata("VALID_WWPUSEREXTENDEDID","""{"handler":"Valid_Wwpuserextendedid","iparms":[{"av":"A112WWPUserExtendedId","fld":"WWPUSEREXTENDEDID"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"A117WWPUserExtendedSMSNotif","fld":"WWPUSEREXTENDEDSMSNOTIF"},{"av":"A118WWPUserExtendedMobileNotif","fld":"WWPUSEREXTENDEDMOBILENOTIF"},{"av":"A119WWPUserExtendedDesktopNotif","fld":"WWPUSEREXTENDEDDESKTOPNOTIF"},{"av":"A122WWPUserExtendedDeleted","fld":"WWPUSEREXTENDEDDELETED"}]""");
         setEventMetadata("VALID_WWPUSEREXTENDEDID",""","oparms":[{"av":"A115WWPUserExtendedPhoto","fld":"WWPUSEREXTENDEDPHOTO"},{"av":"A40000WWPUserExtendedPhoto_GXI","fld":"WWPUSEREXTENDEDPHOTO_GXI"},{"av":"A121WWPUserExtendedName","fld":"WWPUSEREXTENDEDNAME"},{"av":"A113WWPUserExtendedFullName","fld":"WWPUSEREXTENDEDFULLNAME"},{"av":"A120WWPUserExtendedPhone","fld":"WWPUSEREXTENDEDPHONE"},{"av":"A114WWPUserExtendedEmail","fld":"WWPUSEREXTENDEDEMAIL"},{"av":"A116WWPUserExtendedEmaiNotif","fld":"WWPUSEREXTENDEDEMAINOTIF"},{"av":"A123WWPUserExtendedDeletedIn","fld":"WWPUSEREXTENDEDDELETEDIN","pic":"99/99/99 99:99"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z112WWPUserExtendedId"},{"av":"Z115WWPUserExtendedPhoto"},{"av":"Z40000WWPUserExtendedPhoto_GXI"},{"av":"Z121WWPUserExtendedName"},{"av":"Z113WWPUserExtendedFullName"},{"av":"Z120WWPUserExtendedPhone"},{"av":"Z114WWPUserExtendedEmail"},{"av":"Z116WWPUserExtendedEmaiNotif"},{"av":"Z117WWPUserExtendedSMSNotif"},{"av":"Z118WWPUserExtendedMobileNotif"},{"av":"Z119WWPUserExtendedDesktopNotif"},{"av":"Z122WWPUserExtendedDeleted"},{"av":"Z123WWPUserExtendedDeletedIn"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A117WWPUserExtendedSMSNotif","fld":"WWPUSEREXTENDEDSMSNOTIF"},{"av":"A118WWPUserExtendedMobileNotif","fld":"WWPUSEREXTENDEDMOBILENOTIF"},{"av":"A119WWPUserExtendedDesktopNotif","fld":"WWPUSEREXTENDEDDESKTOPNOTIF"},{"av":"A122WWPUserExtendedDeleted","fld":"WWPUSEREXTENDEDDELETED"}]}""");
         setEventMetadata("VALID_WWPUSEREXTENDEDEMAIL","""{"handler":"Valid_Wwpuserextendedemail","iparms":[{"av":"A117WWPUserExtendedSMSNotif","fld":"WWPUSEREXTENDEDSMSNOTIF"},{"av":"A118WWPUserExtendedMobileNotif","fld":"WWPUSEREXTENDEDMOBILENOTIF"},{"av":"A119WWPUserExtendedDesktopNotif","fld":"WWPUSEREXTENDEDDESKTOPNOTIF"},{"av":"A122WWPUserExtendedDeleted","fld":"WWPUSEREXTENDEDDELETED"}]""");
         setEventMetadata("VALID_WWPUSEREXTENDEDEMAIL",""","oparms":[{"av":"A117WWPUserExtendedSMSNotif","fld":"WWPUSEREXTENDEDSMSNOTIF"},{"av":"A118WWPUserExtendedMobileNotif","fld":"WWPUSEREXTENDEDMOBILENOTIF"},{"av":"A119WWPUserExtendedDesktopNotif","fld":"WWPUSEREXTENDEDDESKTOPNOTIF"},{"av":"A122WWPUserExtendedDeleted","fld":"WWPUSEREXTENDEDDELETED"}]}""");
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
         Z112WWPUserExtendedId = "";
         Z121WWPUserExtendedName = "";
         Z113WWPUserExtendedFullName = "";
         Z120WWPUserExtendedPhone = "";
         Z114WWPUserExtendedEmail = "";
         Z123WWPUserExtendedDeletedIn = (DateTime)(DateTime.MinValue);
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
         A112WWPUserExtendedId = "";
         A115WWPUserExtendedPhoto = "";
         A40000WWPUserExtendedPhoto_GXI = "";
         sImgUrl = "";
         A121WWPUserExtendedName = "";
         A113WWPUserExtendedFullName = "";
         gxphoneLink = "";
         A120WWPUserExtendedPhone = "";
         A114WWPUserExtendedEmail = "";
         A123WWPUserExtendedDeletedIn = (DateTime)(DateTime.MinValue);
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
         Z115WWPUserExtendedPhoto = "";
         Z40000WWPUserExtendedPhoto_GXI = "";
         T000G4_A112WWPUserExtendedId = new string[] {""} ;
         T000G4_n112WWPUserExtendedId = new bool[] {false} ;
         T000G4_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         T000G4_A121WWPUserExtendedName = new string[] {""} ;
         T000G4_A113WWPUserExtendedFullName = new string[] {""} ;
         T000G4_A120WWPUserExtendedPhone = new string[] {""} ;
         T000G4_A114WWPUserExtendedEmail = new string[] {""} ;
         T000G4_A116WWPUserExtendedEmaiNotif = new bool[] {false} ;
         T000G4_A117WWPUserExtendedSMSNotif = new bool[] {false} ;
         T000G4_A118WWPUserExtendedMobileNotif = new bool[] {false} ;
         T000G4_A119WWPUserExtendedDesktopNotif = new bool[] {false} ;
         T000G4_A122WWPUserExtendedDeleted = new bool[] {false} ;
         T000G4_A123WWPUserExtendedDeletedIn = new DateTime[] {DateTime.MinValue} ;
         T000G4_n123WWPUserExtendedDeletedIn = new bool[] {false} ;
         T000G4_A115WWPUserExtendedPhoto = new string[] {""} ;
         T000G5_A112WWPUserExtendedId = new string[] {""} ;
         T000G5_n112WWPUserExtendedId = new bool[] {false} ;
         T000G3_A112WWPUserExtendedId = new string[] {""} ;
         T000G3_n112WWPUserExtendedId = new bool[] {false} ;
         T000G3_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         T000G3_A121WWPUserExtendedName = new string[] {""} ;
         T000G3_A113WWPUserExtendedFullName = new string[] {""} ;
         T000G3_A120WWPUserExtendedPhone = new string[] {""} ;
         T000G3_A114WWPUserExtendedEmail = new string[] {""} ;
         T000G3_A116WWPUserExtendedEmaiNotif = new bool[] {false} ;
         T000G3_A117WWPUserExtendedSMSNotif = new bool[] {false} ;
         T000G3_A118WWPUserExtendedMobileNotif = new bool[] {false} ;
         T000G3_A119WWPUserExtendedDesktopNotif = new bool[] {false} ;
         T000G3_A122WWPUserExtendedDeleted = new bool[] {false} ;
         T000G3_A123WWPUserExtendedDeletedIn = new DateTime[] {DateTime.MinValue} ;
         T000G3_n123WWPUserExtendedDeletedIn = new bool[] {false} ;
         T000G3_A115WWPUserExtendedPhoto = new string[] {""} ;
         sMode26 = "";
         T000G6_A112WWPUserExtendedId = new string[] {""} ;
         T000G6_n112WWPUserExtendedId = new bool[] {false} ;
         T000G7_A112WWPUserExtendedId = new string[] {""} ;
         T000G7_n112WWPUserExtendedId = new bool[] {false} ;
         T000G2_A112WWPUserExtendedId = new string[] {""} ;
         T000G2_n112WWPUserExtendedId = new bool[] {false} ;
         T000G2_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         T000G2_A121WWPUserExtendedName = new string[] {""} ;
         T000G2_A113WWPUserExtendedFullName = new string[] {""} ;
         T000G2_A120WWPUserExtendedPhone = new string[] {""} ;
         T000G2_A114WWPUserExtendedEmail = new string[] {""} ;
         T000G2_A116WWPUserExtendedEmaiNotif = new bool[] {false} ;
         T000G2_A117WWPUserExtendedSMSNotif = new bool[] {false} ;
         T000G2_A118WWPUserExtendedMobileNotif = new bool[] {false} ;
         T000G2_A119WWPUserExtendedDesktopNotif = new bool[] {false} ;
         T000G2_A122WWPUserExtendedDeleted = new bool[] {false} ;
         T000G2_A123WWPUserExtendedDeletedIn = new DateTime[] {DateTime.MinValue} ;
         T000G2_n123WWPUserExtendedDeletedIn = new bool[] {false} ;
         T000G2_A115WWPUserExtendedPhoto = new string[] {""} ;
         T000G12_A200WWPDiscussionMessageId = new long[1] ;
         T000G12_A201WWPDiscussionMentionUserId = new string[] {""} ;
         T000G13_A214WWPFormInstanceId = new int[1] ;
         T000G14_A200WWPDiscussionMessageId = new long[1] ;
         T000G15_A127WWPNotificationId = new long[1] ;
         T000G16_A153WWPWebClientId = new string[] {""} ;
         T000G17_A130WWPSubscriptionId = new long[1] ;
         T000G18_A112WWPUserExtendedId = new string[] {""} ;
         T000G18_n112WWPUserExtendedId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         ZZ112WWPUserExtendedId = "";
         ZZ115WWPUserExtendedPhoto = "";
         ZZ40000WWPUserExtendedPhoto_GXI = "";
         ZZ121WWPUserExtendedName = "";
         ZZ113WWPUserExtendedFullName = "";
         ZZ120WWPUserExtendedPhone = "";
         ZZ114WWPUserExtendedEmail = "";
         ZZ123WWPUserExtendedDeletedIn = (DateTime)(DateTime.MinValue);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_userextended__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_userextended__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_userextended__default(),
            new Object[][] {
                new Object[] {
               T000G2_A112WWPUserExtendedId, T000G2_A40000WWPUserExtendedPhoto_GXI, T000G2_A121WWPUserExtendedName, T000G2_A113WWPUserExtendedFullName, T000G2_A120WWPUserExtendedPhone, T000G2_A114WWPUserExtendedEmail, T000G2_A116WWPUserExtendedEmaiNotif, T000G2_A117WWPUserExtendedSMSNotif, T000G2_A118WWPUserExtendedMobileNotif, T000G2_A119WWPUserExtendedDesktopNotif,
               T000G2_A122WWPUserExtendedDeleted, T000G2_A123WWPUserExtendedDeletedIn, T000G2_n123WWPUserExtendedDeletedIn, T000G2_A115WWPUserExtendedPhoto
               }
               , new Object[] {
               T000G3_A112WWPUserExtendedId, T000G3_A40000WWPUserExtendedPhoto_GXI, T000G3_A121WWPUserExtendedName, T000G3_A113WWPUserExtendedFullName, T000G3_A120WWPUserExtendedPhone, T000G3_A114WWPUserExtendedEmail, T000G3_A116WWPUserExtendedEmaiNotif, T000G3_A117WWPUserExtendedSMSNotif, T000G3_A118WWPUserExtendedMobileNotif, T000G3_A119WWPUserExtendedDesktopNotif,
               T000G3_A122WWPUserExtendedDeleted, T000G3_A123WWPUserExtendedDeletedIn, T000G3_n123WWPUserExtendedDeletedIn, T000G3_A115WWPUserExtendedPhoto
               }
               , new Object[] {
               T000G4_A112WWPUserExtendedId, T000G4_A40000WWPUserExtendedPhoto_GXI, T000G4_A121WWPUserExtendedName, T000G4_A113WWPUserExtendedFullName, T000G4_A120WWPUserExtendedPhone, T000G4_A114WWPUserExtendedEmail, T000G4_A116WWPUserExtendedEmaiNotif, T000G4_A117WWPUserExtendedSMSNotif, T000G4_A118WWPUserExtendedMobileNotif, T000G4_A119WWPUserExtendedDesktopNotif,
               T000G4_A122WWPUserExtendedDeleted, T000G4_A123WWPUserExtendedDeletedIn, T000G4_n123WWPUserExtendedDeletedIn, T000G4_A115WWPUserExtendedPhoto
               }
               , new Object[] {
               T000G5_A112WWPUserExtendedId
               }
               , new Object[] {
               T000G6_A112WWPUserExtendedId
               }
               , new Object[] {
               T000G7_A112WWPUserExtendedId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000G12_A200WWPDiscussionMessageId, T000G12_A201WWPDiscussionMentionUserId
               }
               , new Object[] {
               T000G13_A214WWPFormInstanceId
               }
               , new Object[] {
               T000G14_A200WWPDiscussionMessageId
               }
               , new Object[] {
               T000G15_A127WWPNotificationId
               }
               , new Object[] {
               T000G16_A153WWPWebClientId
               }
               , new Object[] {
               T000G17_A130WWPSubscriptionId
               }
               , new Object[] {
               T000G18_A112WWPUserExtendedId
               }
            }
         );
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound26 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPUserExtendedId_Enabled ;
      private int imgWWPUserExtendedPhoto_Enabled ;
      private int edtWWPUserExtendedName_Enabled ;
      private int edtWWPUserExtendedFullName_Enabled ;
      private int edtWWPUserExtendedPhone_Enabled ;
      private int edtWWPUserExtendedEmail_Enabled ;
      private int edtWWPUserExtendedEmaiNotif_Enabled ;
      private int edtWWPUserExtendedDeletedIn_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string Z112WWPUserExtendedId ;
      private string Z120WWPUserExtendedPhone ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPUserExtendedId_Internalname ;
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
      private string A112WWPUserExtendedId ;
      private string edtWWPUserExtendedId_Jsonclick ;
      private string imgWWPUserExtendedPhoto_Internalname ;
      private string sImgUrl ;
      private string edtWWPUserExtendedName_Internalname ;
      private string edtWWPUserExtendedName_Jsonclick ;
      private string edtWWPUserExtendedFullName_Internalname ;
      private string edtWWPUserExtendedFullName_Jsonclick ;
      private string edtWWPUserExtendedPhone_Internalname ;
      private string gxphoneLink ;
      private string A120WWPUserExtendedPhone ;
      private string edtWWPUserExtendedPhone_Jsonclick ;
      private string edtWWPUserExtendedEmail_Internalname ;
      private string edtWWPUserExtendedEmail_Jsonclick ;
      private string edtWWPUserExtendedEmaiNotif_Internalname ;
      private string edtWWPUserExtendedEmaiNotif_Jsonclick ;
      private string chkWWPUserExtendedSMSNotif_Internalname ;
      private string chkWWPUserExtendedMobileNotif_Internalname ;
      private string chkWWPUserExtendedDesktopNotif_Internalname ;
      private string chkWWPUserExtendedDeleted_Internalname ;
      private string edtWWPUserExtendedDeletedIn_Internalname ;
      private string edtWWPUserExtendedDeletedIn_Jsonclick ;
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
      private string sMode26 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string ZZ112WWPUserExtendedId ;
      private string ZZ120WWPUserExtendedPhone ;
      private DateTime Z123WWPUserExtendedDeletedIn ;
      private DateTime A123WWPUserExtendedDeletedIn ;
      private DateTime ZZ123WWPUserExtendedDeletedIn ;
      private bool Z116WWPUserExtendedEmaiNotif ;
      private bool Z117WWPUserExtendedSMSNotif ;
      private bool Z118WWPUserExtendedMobileNotif ;
      private bool Z119WWPUserExtendedDesktopNotif ;
      private bool Z122WWPUserExtendedDeleted ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A117WWPUserExtendedSMSNotif ;
      private bool A118WWPUserExtendedMobileNotif ;
      private bool A119WWPUserExtendedDesktopNotif ;
      private bool A122WWPUserExtendedDeleted ;
      private bool A115WWPUserExtendedPhoto_IsBlob ;
      private bool A116WWPUserExtendedEmaiNotif ;
      private bool n123WWPUserExtendedDeletedIn ;
      private bool n112WWPUserExtendedId ;
      private bool Gx_longc ;
      private bool ZZ116WWPUserExtendedEmaiNotif ;
      private bool ZZ117WWPUserExtendedSMSNotif ;
      private bool ZZ118WWPUserExtendedMobileNotif ;
      private bool ZZ119WWPUserExtendedDesktopNotif ;
      private bool ZZ122WWPUserExtendedDeleted ;
      private string Z121WWPUserExtendedName ;
      private string Z113WWPUserExtendedFullName ;
      private string Z114WWPUserExtendedEmail ;
      private string A40000WWPUserExtendedPhoto_GXI ;
      private string A121WWPUserExtendedName ;
      private string A113WWPUserExtendedFullName ;
      private string A114WWPUserExtendedEmail ;
      private string Z40000WWPUserExtendedPhoto_GXI ;
      private string ZZ40000WWPUserExtendedPhoto_GXI ;
      private string ZZ121WWPUserExtendedName ;
      private string ZZ113WWPUserExtendedFullName ;
      private string ZZ114WWPUserExtendedEmail ;
      private string A115WWPUserExtendedPhoto ;
      private string Z115WWPUserExtendedPhoto ;
      private string ZZ115WWPUserExtendedPhoto ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkWWPUserExtendedSMSNotif ;
      private GXCheckbox chkWWPUserExtendedMobileNotif ;
      private GXCheckbox chkWWPUserExtendedDesktopNotif ;
      private GXCheckbox chkWWPUserExtendedDeleted ;
      private IDataStoreProvider pr_default ;
      private string[] T000G4_A112WWPUserExtendedId ;
      private bool[] T000G4_n112WWPUserExtendedId ;
      private string[] T000G4_A40000WWPUserExtendedPhoto_GXI ;
      private string[] T000G4_A121WWPUserExtendedName ;
      private string[] T000G4_A113WWPUserExtendedFullName ;
      private string[] T000G4_A120WWPUserExtendedPhone ;
      private string[] T000G4_A114WWPUserExtendedEmail ;
      private bool[] T000G4_A116WWPUserExtendedEmaiNotif ;
      private bool[] T000G4_A117WWPUserExtendedSMSNotif ;
      private bool[] T000G4_A118WWPUserExtendedMobileNotif ;
      private bool[] T000G4_A119WWPUserExtendedDesktopNotif ;
      private bool[] T000G4_A122WWPUserExtendedDeleted ;
      private DateTime[] T000G4_A123WWPUserExtendedDeletedIn ;
      private bool[] T000G4_n123WWPUserExtendedDeletedIn ;
      private string[] T000G4_A115WWPUserExtendedPhoto ;
      private string[] T000G5_A112WWPUserExtendedId ;
      private bool[] T000G5_n112WWPUserExtendedId ;
      private string[] T000G3_A112WWPUserExtendedId ;
      private bool[] T000G3_n112WWPUserExtendedId ;
      private string[] T000G3_A40000WWPUserExtendedPhoto_GXI ;
      private string[] T000G3_A121WWPUserExtendedName ;
      private string[] T000G3_A113WWPUserExtendedFullName ;
      private string[] T000G3_A120WWPUserExtendedPhone ;
      private string[] T000G3_A114WWPUserExtendedEmail ;
      private bool[] T000G3_A116WWPUserExtendedEmaiNotif ;
      private bool[] T000G3_A117WWPUserExtendedSMSNotif ;
      private bool[] T000G3_A118WWPUserExtendedMobileNotif ;
      private bool[] T000G3_A119WWPUserExtendedDesktopNotif ;
      private bool[] T000G3_A122WWPUserExtendedDeleted ;
      private DateTime[] T000G3_A123WWPUserExtendedDeletedIn ;
      private bool[] T000G3_n123WWPUserExtendedDeletedIn ;
      private string[] T000G3_A115WWPUserExtendedPhoto ;
      private string[] T000G6_A112WWPUserExtendedId ;
      private bool[] T000G6_n112WWPUserExtendedId ;
      private string[] T000G7_A112WWPUserExtendedId ;
      private bool[] T000G7_n112WWPUserExtendedId ;
      private string[] T000G2_A112WWPUserExtendedId ;
      private bool[] T000G2_n112WWPUserExtendedId ;
      private string[] T000G2_A40000WWPUserExtendedPhoto_GXI ;
      private string[] T000G2_A121WWPUserExtendedName ;
      private string[] T000G2_A113WWPUserExtendedFullName ;
      private string[] T000G2_A120WWPUserExtendedPhone ;
      private string[] T000G2_A114WWPUserExtendedEmail ;
      private bool[] T000G2_A116WWPUserExtendedEmaiNotif ;
      private bool[] T000G2_A117WWPUserExtendedSMSNotif ;
      private bool[] T000G2_A118WWPUserExtendedMobileNotif ;
      private bool[] T000G2_A119WWPUserExtendedDesktopNotif ;
      private bool[] T000G2_A122WWPUserExtendedDeleted ;
      private DateTime[] T000G2_A123WWPUserExtendedDeletedIn ;
      private bool[] T000G2_n123WWPUserExtendedDeletedIn ;
      private string[] T000G2_A115WWPUserExtendedPhoto ;
      private long[] T000G12_A200WWPDiscussionMessageId ;
      private string[] T000G12_A201WWPDiscussionMentionUserId ;
      private int[] T000G13_A214WWPFormInstanceId ;
      private long[] T000G14_A200WWPDiscussionMessageId ;
      private long[] T000G15_A127WWPNotificationId ;
      private string[] T000G16_A153WWPWebClientId ;
      private long[] T000G17_A130WWPSubscriptionId ;
      private string[] T000G18_A112WWPUserExtendedId ;
      private bool[] T000G18_n112WWPUserExtendedId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_userextended__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_userextended__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_userextended__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[9])
      ,new ForEachCursor(def[10])
      ,new ForEachCursor(def[11])
      ,new ForEachCursor(def[12])
      ,new ForEachCursor(def[13])
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
       Object[] prmT000G2;
       prmT000G2 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmT000G3;
       prmT000G3 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmT000G4;
       prmT000G4 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmT000G5;
       prmT000G5 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmT000G6;
       prmT000G6 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmT000G7;
       prmT000G7 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmT000G8;
       prmT000G8 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true} ,
       new ParDef("WWPUserExtendedPhoto",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("WWPUserExtendedPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=1, Tbl="WWP_UserExtended", Fld="WWPUserExtendedPhoto"} ,
       new ParDef("WWPUserExtendedName",GXType.VarChar,100,0) ,
       new ParDef("WWPUserExtendedFullName",GXType.VarChar,100,0) ,
       new ParDef("WWPUserExtendedPhone",GXType.Char,20,0) ,
       new ParDef("WWPUserExtendedEmail",GXType.VarChar,100,0) ,
       new ParDef("WWPUserExtendedEmaiNotif",GXType.Boolean,100,0) ,
       new ParDef("WWPUserExtendedSMSNotif",GXType.Boolean,4,0) ,
       new ParDef("WWPUserExtendedMobileNotif",GXType.Boolean,4,0) ,
       new ParDef("WWPUserExtendedDesktopNotif",GXType.Boolean,4,0) ,
       new ParDef("WWPUserExtendedDeleted",GXType.Boolean,4,0) ,
       new ParDef("WWPUserExtendedDeletedIn",GXType.DateTime,8,5){Nullable=true}
       };
       Object[] prmT000G9;
       prmT000G9 = new Object[] {
       new ParDef("WWPUserExtendedName",GXType.VarChar,100,0) ,
       new ParDef("WWPUserExtendedFullName",GXType.VarChar,100,0) ,
       new ParDef("WWPUserExtendedPhone",GXType.Char,20,0) ,
       new ParDef("WWPUserExtendedEmail",GXType.VarChar,100,0) ,
       new ParDef("WWPUserExtendedEmaiNotif",GXType.Boolean,100,0) ,
       new ParDef("WWPUserExtendedSMSNotif",GXType.Boolean,4,0) ,
       new ParDef("WWPUserExtendedMobileNotif",GXType.Boolean,4,0) ,
       new ParDef("WWPUserExtendedDesktopNotif",GXType.Boolean,4,0) ,
       new ParDef("WWPUserExtendedDeleted",GXType.Boolean,4,0) ,
       new ParDef("WWPUserExtendedDeletedIn",GXType.DateTime,8,5){Nullable=true} ,
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmT000G10;
       prmT000G10 = new Object[] {
       new ParDef("WWPUserExtendedPhoto",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("WWPUserExtendedPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="WWP_UserExtended", Fld="WWPUserExtendedPhoto"} ,
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmT000G11;
       prmT000G11 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmT000G12;
       prmT000G12 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmT000G13;
       prmT000G13 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmT000G14;
       prmT000G14 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmT000G15;
       prmT000G15 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmT000G16;
       prmT000G16 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmT000G17;
       prmT000G17 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmT000G18;
       prmT000G18 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T000G2", "SELECT WWPUserExtendedId, WWPUserExtendedPhoto_GXI, WWPUserExtendedName, WWPUserExtendedFullName, WWPUserExtendedPhone, WWPUserExtendedEmail, WWPUserExtendedEmaiNotif, WWPUserExtendedSMSNotif, WWPUserExtendedMobileNotif, WWPUserExtendedDesktopNotif, WWPUserExtendedDeleted, WWPUserExtendedDeletedIn, WWPUserExtendedPhoto FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId  FOR UPDATE OF WWP_UserExtended NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000G2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000G3", "SELECT WWPUserExtendedId, WWPUserExtendedPhoto_GXI, WWPUserExtendedName, WWPUserExtendedFullName, WWPUserExtendedPhone, WWPUserExtendedEmail, WWPUserExtendedEmaiNotif, WWPUserExtendedSMSNotif, WWPUserExtendedMobileNotif, WWPUserExtendedDesktopNotif, WWPUserExtendedDeleted, WWPUserExtendedDeletedIn, WWPUserExtendedPhoto FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000G4", "SELECT TM1.WWPUserExtendedId, TM1.WWPUserExtendedPhoto_GXI, TM1.WWPUserExtendedName, TM1.WWPUserExtendedFullName, TM1.WWPUserExtendedPhone, TM1.WWPUserExtendedEmail, TM1.WWPUserExtendedEmaiNotif, TM1.WWPUserExtendedSMSNotif, TM1.WWPUserExtendedMobileNotif, TM1.WWPUserExtendedDesktopNotif, TM1.WWPUserExtendedDeleted, TM1.WWPUserExtendedDeletedIn, TM1.WWPUserExtendedPhoto FROM WWP_UserExtended TM1 WHERE TM1.WWPUserExtendedId = ( :WWPUserExtendedId) ORDER BY TM1.WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000G5", "SELECT WWPUserExtendedId FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000G6", "SELECT WWPUserExtendedId FROM WWP_UserExtended WHERE ( WWPUserExtendedId > ( :WWPUserExtendedId)) ORDER BY WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G6,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000G7", "SELECT WWPUserExtendedId FROM WWP_UserExtended WHERE ( WWPUserExtendedId < ( :WWPUserExtendedId)) ORDER BY WWPUserExtendedId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G7,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000G8", "SAVEPOINT gxupdate;INSERT INTO WWP_UserExtended(WWPUserExtendedId, WWPUserExtendedPhoto, WWPUserExtendedPhoto_GXI, WWPUserExtendedName, WWPUserExtendedFullName, WWPUserExtendedPhone, WWPUserExtendedEmail, WWPUserExtendedEmaiNotif, WWPUserExtendedSMSNotif, WWPUserExtendedMobileNotif, WWPUserExtendedDesktopNotif, WWPUserExtendedDeleted, WWPUserExtendedDeletedIn) VALUES(:WWPUserExtendedId, :WWPUserExtendedPhoto, :WWPUserExtendedPhoto_GXI, :WWPUserExtendedName, :WWPUserExtendedFullName, :WWPUserExtendedPhone, :WWPUserExtendedEmail, :WWPUserExtendedEmaiNotif, :WWPUserExtendedSMSNotif, :WWPUserExtendedMobileNotif, :WWPUserExtendedDesktopNotif, :WWPUserExtendedDeleted, :WWPUserExtendedDeletedIn);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000G8)
          ,new CursorDef("T000G9", "SAVEPOINT gxupdate;UPDATE WWP_UserExtended SET WWPUserExtendedName=:WWPUserExtendedName, WWPUserExtendedFullName=:WWPUserExtendedFullName, WWPUserExtendedPhone=:WWPUserExtendedPhone, WWPUserExtendedEmail=:WWPUserExtendedEmail, WWPUserExtendedEmaiNotif=:WWPUserExtendedEmaiNotif, WWPUserExtendedSMSNotif=:WWPUserExtendedSMSNotif, WWPUserExtendedMobileNotif=:WWPUserExtendedMobileNotif, WWPUserExtendedDesktopNotif=:WWPUserExtendedDesktopNotif, WWPUserExtendedDeleted=:WWPUserExtendedDeleted, WWPUserExtendedDeletedIn=:WWPUserExtendedDeletedIn  WHERE WWPUserExtendedId = :WWPUserExtendedId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000G9)
          ,new CursorDef("T000G10", "SAVEPOINT gxupdate;UPDATE WWP_UserExtended SET WWPUserExtendedPhoto=:WWPUserExtendedPhoto, WWPUserExtendedPhoto_GXI=:WWPUserExtendedPhoto_GXI  WHERE WWPUserExtendedId = :WWPUserExtendedId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000G10)
          ,new CursorDef("T000G11", "SAVEPOINT gxupdate;DELETE FROM WWP_UserExtended  WHERE WWPUserExtendedId = :WWPUserExtendedId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000G11)
          ,new CursorDef("T000G12", "SELECT WWPDiscussionMessageId, WWPDiscussionMentionUserId FROM WWP_DiscussionMessageMention WHERE WWPDiscussionMentionUserId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G12,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000G13", "SELECT WWPFormInstanceId FROM WWP_FormInstance WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G13,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000G14", "SELECT WWPDiscussionMessageId FROM WWP_DiscussionMessage WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G14,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000G15", "SELECT WWPNotificationId FROM WWP_Notification WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G15,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000G16", "SELECT WWPWebClientId FROM WWP_WebClient WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G16,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000G17", "SELECT WWPSubscriptionId FROM WWP_Subscription WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G17,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000G18", "SELECT WWPUserExtendedId FROM WWP_UserExtended ORDER BY WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G18,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[0])[0] = rslt.getString(1, 40);
             ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((bool[]) buf[6])[0] = rslt.getBool(7);
             ((bool[]) buf[7])[0] = rslt.getBool(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((bool[]) buf[10])[0] = rslt.getBool(11);
             ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
             ((bool[]) buf[12])[0] = rslt.wasNull(12);
             ((string[]) buf[13])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(2));
             return;
          case 1 :
             ((string[]) buf[0])[0] = rslt.getString(1, 40);
             ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((bool[]) buf[6])[0] = rslt.getBool(7);
             ((bool[]) buf[7])[0] = rslt.getBool(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((bool[]) buf[10])[0] = rslt.getBool(11);
             ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
             ((bool[]) buf[12])[0] = rslt.wasNull(12);
             ((string[]) buf[13])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(2));
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getString(1, 40);
             ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((bool[]) buf[6])[0] = rslt.getBool(7);
             ((bool[]) buf[7])[0] = rslt.getBool(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((bool[]) buf[10])[0] = rslt.getBool(11);
             ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
             ((bool[]) buf[12])[0] = rslt.wasNull(12);
             ((string[]) buf[13])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(2));
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getString(1, 40);
             return;
          case 4 :
             ((string[]) buf[0])[0] = rslt.getString(1, 40);
             return;
          case 5 :
             ((string[]) buf[0])[0] = rslt.getString(1, 40);
             return;
          case 10 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 40);
             return;
          case 11 :
             ((int[]) buf[0])[0] = rslt.getInt(1);
             return;
          case 12 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 13 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 14 :
             ((string[]) buf[0])[0] = rslt.getString(1, 100);
             return;
          case 15 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 16 :
             ((string[]) buf[0])[0] = rslt.getString(1, 40);
             return;
    }
 }

}

}
