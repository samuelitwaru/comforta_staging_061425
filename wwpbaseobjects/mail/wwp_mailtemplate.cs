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
namespace GeneXus.Programs.wwpbaseobjects.mail {
   public class wwp_mailtemplate : GXDataArea
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
         Form.Meta.addItem("description", context.GetMessage( "Mail Template", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPMailTemplateName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_mailtemplate( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_mailtemplate( IGxContext context )
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
            return "wwpmailtemplate_Execute" ;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Mail Template", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/Mail/WWP_MailTemplate.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Mail/WWP_MailTemplate.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Mail/WWP_MailTemplate.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Mail/WWP_MailTemplate.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Mail/WWP_MailTemplate.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects/Mail/WWP_MailTemplate.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailTemplateName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailTemplateName_Internalname, context.GetMessage( "Name", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPMailTemplateName_Internalname, A193WWPMailTemplateName, StringUtil.RTrim( context.localUtil.Format( A193WWPMailTemplateName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPMailTemplateName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPMailTemplateName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/Mail/WWP_MailTemplate.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailTemplateDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailTemplateDescription_Internalname, context.GetMessage( "Description", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPMailTemplateDescription_Internalname, A194WWPMailTemplateDescription, StringUtil.RTrim( context.localUtil.Format( A194WWPMailTemplateDescription, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPMailTemplateDescription_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPMailTemplateDescription_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/Mail/WWP_MailTemplate.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailTemplateSubject_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailTemplateSubject_Internalname, context.GetMessage( "Subject", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPMailTemplateSubject_Internalname, A195WWPMailTemplateSubject, StringUtil.RTrim( context.localUtil.Format( A195WWPMailTemplateSubject, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPMailTemplateSubject_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPMailTemplateSubject_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/Mail/WWP_MailTemplate.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailTemplateBody_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailTemplateBody_Internalname, context.GetMessage( "Body", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailTemplateBody_Internalname, A178WWPMailTemplateBody, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 1, 1, edtWWPMailTemplateBody_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "GeneXus\\Html", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Mail/WWP_MailTemplate.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailTemplateSenderAddress_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailTemplateSenderAddress_Internalname, context.GetMessage( "Sender Address", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailTemplateSenderAddress_Internalname, A179WWPMailTemplateSenderAddress, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", 0, 1, edtWWPMailTemplateSenderAddress_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Mail/WWP_MailTemplate.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailTemplateSenderName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailTemplateSenderName_Internalname, context.GetMessage( "Sender Name", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailTemplateSenderName_Internalname, A180WWPMailTemplateSenderName, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", 0, 1, edtWWPMailTemplateSenderName_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Mail/WWP_MailTemplate.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Mail/WWP_MailTemplate.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Mail/WWP_MailTemplate.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Mail/WWP_MailTemplate.htm");
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
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110P2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z193WWPMailTemplateName = cgiGet( "Z193WWPMailTemplateName");
               Z194WWPMailTemplateDescription = cgiGet( "Z194WWPMailTemplateDescription");
               Z195WWPMailTemplateSubject = cgiGet( "Z195WWPMailTemplateSubject");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               /* Read variables values. */
               A193WWPMailTemplateName = cgiGet( edtWWPMailTemplateName_Internalname);
               AssignAttri("", false, "A193WWPMailTemplateName", A193WWPMailTemplateName);
               A194WWPMailTemplateDescription = cgiGet( edtWWPMailTemplateDescription_Internalname);
               AssignAttri("", false, "A194WWPMailTemplateDescription", A194WWPMailTemplateDescription);
               A195WWPMailTemplateSubject = cgiGet( edtWWPMailTemplateSubject_Internalname);
               AssignAttri("", false, "A195WWPMailTemplateSubject", A195WWPMailTemplateSubject);
               A178WWPMailTemplateBody = cgiGet( edtWWPMailTemplateBody_Internalname);
               AssignAttri("", false, "A178WWPMailTemplateBody", A178WWPMailTemplateBody);
               A179WWPMailTemplateSenderAddress = cgiGet( edtWWPMailTemplateSenderAddress_Internalname);
               AssignAttri("", false, "A179WWPMailTemplateSenderAddress", A179WWPMailTemplateSenderAddress);
               A180WWPMailTemplateSenderName = cgiGet( edtWWPMailTemplateSenderName_Internalname);
               AssignAttri("", false, "A180WWPMailTemplateSenderName", A180WWPMailTemplateSenderName);
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
                  A193WWPMailTemplateName = GetPar( "WWPMailTemplateName");
                  AssignAttri("", false, "A193WWPMailTemplateName", A193WWPMailTemplateName);
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E110P2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120P2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
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
            /* Execute user event: After Trn */
            E120P2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0P35( ) ;
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
         DisableAttributes0P35( ) ;
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

      protected void ResetCaption0P0( )
      {
      }

      protected void E110P2( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E120P2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0P35( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z194WWPMailTemplateDescription = T000P3_A194WWPMailTemplateDescription[0];
               Z195WWPMailTemplateSubject = T000P3_A195WWPMailTemplateSubject[0];
            }
            else
            {
               Z194WWPMailTemplateDescription = A194WWPMailTemplateDescription;
               Z195WWPMailTemplateSubject = A195WWPMailTemplateSubject;
            }
         }
         if ( GX_JID == -1 )
         {
            Z193WWPMailTemplateName = A193WWPMailTemplateName;
            Z194WWPMailTemplateDescription = A194WWPMailTemplateDescription;
            Z195WWPMailTemplateSubject = A195WWPMailTemplateSubject;
            Z178WWPMailTemplateBody = A178WWPMailTemplateBody;
            Z179WWPMailTemplateSenderAddress = A179WWPMailTemplateSenderAddress;
            Z180WWPMailTemplateSenderName = A180WWPMailTemplateSenderName;
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

      protected void Load0P35( )
      {
         /* Using cursor T000P4 */
         pr_default.execute(2, new Object[] {A193WWPMailTemplateName});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound35 = 1;
            A194WWPMailTemplateDescription = T000P4_A194WWPMailTemplateDescription[0];
            AssignAttri("", false, "A194WWPMailTemplateDescription", A194WWPMailTemplateDescription);
            A195WWPMailTemplateSubject = T000P4_A195WWPMailTemplateSubject[0];
            AssignAttri("", false, "A195WWPMailTemplateSubject", A195WWPMailTemplateSubject);
            A178WWPMailTemplateBody = T000P4_A178WWPMailTemplateBody[0];
            AssignAttri("", false, "A178WWPMailTemplateBody", A178WWPMailTemplateBody);
            A179WWPMailTemplateSenderAddress = T000P4_A179WWPMailTemplateSenderAddress[0];
            AssignAttri("", false, "A179WWPMailTemplateSenderAddress", A179WWPMailTemplateSenderAddress);
            A180WWPMailTemplateSenderName = T000P4_A180WWPMailTemplateSenderName[0];
            AssignAttri("", false, "A180WWPMailTemplateSenderName", A180WWPMailTemplateSenderName);
            ZM0P35( -1) ;
         }
         pr_default.close(2);
         OnLoadActions0P35( ) ;
      }

      protected void OnLoadActions0P35( )
      {
      }

      protected void CheckExtendedTable0P35( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0P35( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0P35( )
      {
         /* Using cursor T000P5 */
         pr_default.execute(3, new Object[] {A193WWPMailTemplateName});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound35 = 1;
         }
         else
         {
            RcdFound35 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000P3 */
         pr_default.execute(1, new Object[] {A193WWPMailTemplateName});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0P35( 1) ;
            RcdFound35 = 1;
            A193WWPMailTemplateName = T000P3_A193WWPMailTemplateName[0];
            AssignAttri("", false, "A193WWPMailTemplateName", A193WWPMailTemplateName);
            A194WWPMailTemplateDescription = T000P3_A194WWPMailTemplateDescription[0];
            AssignAttri("", false, "A194WWPMailTemplateDescription", A194WWPMailTemplateDescription);
            A195WWPMailTemplateSubject = T000P3_A195WWPMailTemplateSubject[0];
            AssignAttri("", false, "A195WWPMailTemplateSubject", A195WWPMailTemplateSubject);
            A178WWPMailTemplateBody = T000P3_A178WWPMailTemplateBody[0];
            AssignAttri("", false, "A178WWPMailTemplateBody", A178WWPMailTemplateBody);
            A179WWPMailTemplateSenderAddress = T000P3_A179WWPMailTemplateSenderAddress[0];
            AssignAttri("", false, "A179WWPMailTemplateSenderAddress", A179WWPMailTemplateSenderAddress);
            A180WWPMailTemplateSenderName = T000P3_A180WWPMailTemplateSenderName[0];
            AssignAttri("", false, "A180WWPMailTemplateSenderName", A180WWPMailTemplateSenderName);
            Z193WWPMailTemplateName = A193WWPMailTemplateName;
            sMode35 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0P35( ) ;
            if ( AnyError == 1 )
            {
               RcdFound35 = 0;
               InitializeNonKey0P35( ) ;
            }
            Gx_mode = sMode35;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound35 = 0;
            InitializeNonKey0P35( ) ;
            sMode35 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode35;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0P35( ) ;
         if ( RcdFound35 == 0 )
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
         RcdFound35 = 0;
         /* Using cursor T000P6 */
         pr_default.execute(4, new Object[] {A193WWPMailTemplateName});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T000P6_A193WWPMailTemplateName[0], A193WWPMailTemplateName) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T000P6_A193WWPMailTemplateName[0], A193WWPMailTemplateName) > 0 ) ) )
            {
               A193WWPMailTemplateName = T000P6_A193WWPMailTemplateName[0];
               AssignAttri("", false, "A193WWPMailTemplateName", A193WWPMailTemplateName);
               RcdFound35 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound35 = 0;
         /* Using cursor T000P7 */
         pr_default.execute(5, new Object[] {A193WWPMailTemplateName});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T000P7_A193WWPMailTemplateName[0], A193WWPMailTemplateName) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T000P7_A193WWPMailTemplateName[0], A193WWPMailTemplateName) < 0 ) ) )
            {
               A193WWPMailTemplateName = T000P7_A193WWPMailTemplateName[0];
               AssignAttri("", false, "A193WWPMailTemplateName", A193WWPMailTemplateName);
               RcdFound35 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0P35( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPMailTemplateName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0P35( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound35 == 1 )
            {
               if ( StringUtil.StrCmp(A193WWPMailTemplateName, Z193WWPMailTemplateName) != 0 )
               {
                  A193WWPMailTemplateName = Z193WWPMailTemplateName;
                  AssignAttri("", false, "A193WWPMailTemplateName", A193WWPMailTemplateName);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPMAILTEMPLATENAME");
                  AnyError = 1;
                  GX_FocusControl = edtWWPMailTemplateName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPMailTemplateName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0P35( ) ;
                  GX_FocusControl = edtWWPMailTemplateName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A193WWPMailTemplateName, Z193WWPMailTemplateName) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPMailTemplateName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0P35( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPMAILTEMPLATENAME");
                     AnyError = 1;
                     GX_FocusControl = edtWWPMailTemplateName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPMailTemplateName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0P35( ) ;
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
         if ( StringUtil.StrCmp(A193WWPMailTemplateName, Z193WWPMailTemplateName) != 0 )
         {
            A193WWPMailTemplateName = Z193WWPMailTemplateName;
            AssignAttri("", false, "A193WWPMailTemplateName", A193WWPMailTemplateName);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPMAILTEMPLATENAME");
            AnyError = 1;
            GX_FocusControl = edtWWPMailTemplateName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPMailTemplateName_Internalname;
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
         if ( RcdFound35 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPMAILTEMPLATENAME");
            AnyError = 1;
            GX_FocusControl = edtWWPMailTemplateName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtWWPMailTemplateDescription_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0P35( ) ;
         if ( RcdFound35 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPMailTemplateDescription_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0P35( ) ;
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
         if ( RcdFound35 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPMailTemplateDescription_Internalname;
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
         if ( RcdFound35 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPMailTemplateDescription_Internalname;
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
         ScanStart0P35( ) ;
         if ( RcdFound35 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound35 != 0 )
            {
               ScanNext0P35( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPMailTemplateDescription_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0P35( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0P35( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000P2 */
            pr_default.execute(0, new Object[] {A193WWPMailTemplateName});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailTemplate"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z194WWPMailTemplateDescription, T000P2_A194WWPMailTemplateDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z195WWPMailTemplateSubject, T000P2_A195WWPMailTemplateSubject[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z194WWPMailTemplateDescription, T000P2_A194WWPMailTemplateDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.mail.wwp_mailtemplate:[seudo value changed for attri]"+"WWPMailTemplateDescription");
                  GXUtil.WriteLogRaw("Old: ",Z194WWPMailTemplateDescription);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A194WWPMailTemplateDescription[0]);
               }
               if ( StringUtil.StrCmp(Z195WWPMailTemplateSubject, T000P2_A195WWPMailTemplateSubject[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.mail.wwp_mailtemplate:[seudo value changed for attri]"+"WWPMailTemplateSubject");
                  GXUtil.WriteLogRaw("Old: ",Z195WWPMailTemplateSubject);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A195WWPMailTemplateSubject[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_MailTemplate"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0P35( )
      {
         if ( ! IsAuthorized("wwpmailtemplate_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0P35( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0P35( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0P35( 0) ;
            CheckOptimisticConcurrency0P35( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0P35( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0P35( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000P8 */
                     pr_default.execute(6, new Object[] {A193WWPMailTemplateName, A194WWPMailTemplateDescription, A195WWPMailTemplateSubject, A178WWPMailTemplateBody, A179WWPMailTemplateSenderAddress, A180WWPMailTemplateSenderName});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_MailTemplate");
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
                           ResetCaption0P0( ) ;
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
               Load0P35( ) ;
            }
            EndLevel0P35( ) ;
         }
         CloseExtendedTableCursors0P35( ) ;
      }

      protected void Update0P35( )
      {
         if ( ! IsAuthorized("wwpmailtemplate_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0P35( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0P35( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0P35( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0P35( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0P35( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000P9 */
                     pr_default.execute(7, new Object[] {A194WWPMailTemplateDescription, A195WWPMailTemplateSubject, A178WWPMailTemplateBody, A179WWPMailTemplateSenderAddress, A180WWPMailTemplateSenderName, A193WWPMailTemplateName});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_MailTemplate");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailTemplate"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0P35( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0P0( ) ;
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
            EndLevel0P35( ) ;
         }
         CloseExtendedTableCursors0P35( ) ;
      }

      protected void DeferredUpdate0P35( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("wwpmailtemplate_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0P35( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0P35( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0P35( ) ;
            AfterConfirm0P35( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0P35( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000P10 */
                  pr_default.execute(8, new Object[] {A193WWPMailTemplateName});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_MailTemplate");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound35 == 0 )
                        {
                           InitAll0P35( ) ;
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
                        ResetCaption0P0( ) ;
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
         sMode35 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0P35( ) ;
         Gx_mode = sMode35;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0P35( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0P35( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0P35( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("wwpbaseobjects.mail.wwp_mailtemplate",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0P0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("wwpbaseobjects.mail.wwp_mailtemplate",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0P35( )
      {
         /* Using cursor T000P11 */
         pr_default.execute(9);
         RcdFound35 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound35 = 1;
            A193WWPMailTemplateName = T000P11_A193WWPMailTemplateName[0];
            AssignAttri("", false, "A193WWPMailTemplateName", A193WWPMailTemplateName);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0P35( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound35 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound35 = 1;
            A193WWPMailTemplateName = T000P11_A193WWPMailTemplateName[0];
            AssignAttri("", false, "A193WWPMailTemplateName", A193WWPMailTemplateName);
         }
      }

      protected void ScanEnd0P35( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0P35( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0P35( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0P35( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0P35( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0P35( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0P35( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0P35( )
      {
         edtWWPMailTemplateName_Enabled = 0;
         AssignProp("", false, edtWWPMailTemplateName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailTemplateName_Enabled), 5, 0), true);
         edtWWPMailTemplateDescription_Enabled = 0;
         AssignProp("", false, edtWWPMailTemplateDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailTemplateDescription_Enabled), 5, 0), true);
         edtWWPMailTemplateSubject_Enabled = 0;
         AssignProp("", false, edtWWPMailTemplateSubject_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailTemplateSubject_Enabled), 5, 0), true);
         edtWWPMailTemplateBody_Enabled = 0;
         AssignProp("", false, edtWWPMailTemplateBody_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailTemplateBody_Enabled), 5, 0), true);
         edtWWPMailTemplateSenderAddress_Enabled = 0;
         AssignProp("", false, edtWWPMailTemplateSenderAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailTemplateSenderAddress_Enabled), 5, 0), true);
         edtWWPMailTemplateSenderName_Enabled = 0;
         AssignProp("", false, edtWWPMailTemplateSenderName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailTemplateSenderName_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0P35( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0P0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.mail.wwp_mailtemplate.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z193WWPMailTemplateName", Z193WWPMailTemplateName);
         GxWebStd.gx_hidden_field( context, "Z194WWPMailTemplateDescription", Z194WWPMailTemplateDescription);
         GxWebStd.gx_hidden_field( context, "Z195WWPMailTemplateSubject", Z195WWPMailTemplateSubject);
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
         return formatLink("wwpbaseobjects.mail.wwp_mailtemplate.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Mail.WWP_MailTemplate" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Mail Template", "") ;
      }

      protected void InitializeNonKey0P35( )
      {
         A194WWPMailTemplateDescription = "";
         AssignAttri("", false, "A194WWPMailTemplateDescription", A194WWPMailTemplateDescription);
         A195WWPMailTemplateSubject = "";
         AssignAttri("", false, "A195WWPMailTemplateSubject", A195WWPMailTemplateSubject);
         A178WWPMailTemplateBody = "";
         AssignAttri("", false, "A178WWPMailTemplateBody", A178WWPMailTemplateBody);
         A179WWPMailTemplateSenderAddress = "";
         AssignAttri("", false, "A179WWPMailTemplateSenderAddress", A179WWPMailTemplateSenderAddress);
         A180WWPMailTemplateSenderName = "";
         AssignAttri("", false, "A180WWPMailTemplateSenderName", A180WWPMailTemplateSenderName);
         Z194WWPMailTemplateDescription = "";
         Z195WWPMailTemplateSubject = "";
      }

      protected void InitAll0P35( )
      {
         A193WWPMailTemplateName = "";
         AssignAttri("", false, "A193WWPMailTemplateName", A193WWPMailTemplateName);
         InitializeNonKey0P35( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256201731572", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/mail/wwp_mailtemplate.js", "?20256201731572", false, true);
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
         edtWWPMailTemplateName_Internalname = "WWPMAILTEMPLATENAME";
         edtWWPMailTemplateDescription_Internalname = "WWPMAILTEMPLATEDESCRIPTION";
         edtWWPMailTemplateSubject_Internalname = "WWPMAILTEMPLATESUBJECT";
         edtWWPMailTemplateBody_Internalname = "WWPMAILTEMPLATEBODY";
         edtWWPMailTemplateSenderAddress_Internalname = "WWPMAILTEMPLATESENDERADDRESS";
         edtWWPMailTemplateSenderName_Internalname = "WWPMAILTEMPLATESENDERNAME";
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
         Form.Caption = context.GetMessage( "Mail Template", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtWWPMailTemplateSenderName_Enabled = 1;
         edtWWPMailTemplateSenderAddress_Enabled = 1;
         edtWWPMailTemplateBody_Enabled = 1;
         edtWWPMailTemplateSubject_Jsonclick = "";
         edtWWPMailTemplateSubject_Enabled = 1;
         edtWWPMailTemplateDescription_Jsonclick = "";
         edtWWPMailTemplateDescription_Enabled = 1;
         edtWWPMailTemplateName_Jsonclick = "";
         edtWWPMailTemplateName_Enabled = 1;
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
         GX_FocusControl = edtWWPMailTemplateDescription_Internalname;
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

      public void Valid_Wwpmailtemplatename( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A194WWPMailTemplateDescription", A194WWPMailTemplateDescription);
         AssignAttri("", false, "A195WWPMailTemplateSubject", A195WWPMailTemplateSubject);
         AssignAttri("", false, "A178WWPMailTemplateBody", A178WWPMailTemplateBody);
         AssignAttri("", false, "A179WWPMailTemplateSenderAddress", A179WWPMailTemplateSenderAddress);
         AssignAttri("", false, "A180WWPMailTemplateSenderName", A180WWPMailTemplateSenderName);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z193WWPMailTemplateName", Z193WWPMailTemplateName);
         GxWebStd.gx_hidden_field( context, "Z194WWPMailTemplateDescription", Z194WWPMailTemplateDescription);
         GxWebStd.gx_hidden_field( context, "Z195WWPMailTemplateSubject", Z195WWPMailTemplateSubject);
         GxWebStd.gx_hidden_field( context, "Z178WWPMailTemplateBody", Z178WWPMailTemplateBody);
         GxWebStd.gx_hidden_field( context, "Z179WWPMailTemplateSenderAddress", Z179WWPMailTemplateSenderAddress);
         GxWebStd.gx_hidden_field( context, "Z180WWPMailTemplateSenderName", Z180WWPMailTemplateSenderName);
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
         setEventMetadata("AFTER TRN","""{"handler":"E120P2","iparms":[]}""");
         setEventMetadata("VALID_WWPMAILTEMPLATENAME","""{"handler":"Valid_Wwpmailtemplatename","iparms":[{"av":"A193WWPMailTemplateName","fld":"WWPMAILTEMPLATENAME"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"}]""");
         setEventMetadata("VALID_WWPMAILTEMPLATENAME",""","oparms":[{"av":"A194WWPMailTemplateDescription","fld":"WWPMAILTEMPLATEDESCRIPTION"},{"av":"A195WWPMailTemplateSubject","fld":"WWPMAILTEMPLATESUBJECT"},{"av":"A178WWPMailTemplateBody","fld":"WWPMAILTEMPLATEBODY"},{"av":"A179WWPMailTemplateSenderAddress","fld":"WWPMAILTEMPLATESENDERADDRESS"},{"av":"A180WWPMailTemplateSenderName","fld":"WWPMAILTEMPLATESENDERNAME"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z193WWPMailTemplateName"},{"av":"Z194WWPMailTemplateDescription"},{"av":"Z195WWPMailTemplateSubject"},{"av":"Z178WWPMailTemplateBody"},{"av":"Z179WWPMailTemplateSenderAddress"},{"av":"Z180WWPMailTemplateSenderName"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
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
         Z193WWPMailTemplateName = "";
         Z194WWPMailTemplateDescription = "";
         Z195WWPMailTemplateSubject = "";
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
         A193WWPMailTemplateName = "";
         A194WWPMailTemplateDescription = "";
         A195WWPMailTemplateSubject = "";
         A178WWPMailTemplateBody = "";
         A179WWPMailTemplateSenderAddress = "";
         A180WWPMailTemplateSenderName = "";
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
         Z178WWPMailTemplateBody = "";
         Z179WWPMailTemplateSenderAddress = "";
         Z180WWPMailTemplateSenderName = "";
         T000P4_A193WWPMailTemplateName = new string[] {""} ;
         T000P4_A194WWPMailTemplateDescription = new string[] {""} ;
         T000P4_A195WWPMailTemplateSubject = new string[] {""} ;
         T000P4_A178WWPMailTemplateBody = new string[] {""} ;
         T000P4_A179WWPMailTemplateSenderAddress = new string[] {""} ;
         T000P4_A180WWPMailTemplateSenderName = new string[] {""} ;
         T000P5_A193WWPMailTemplateName = new string[] {""} ;
         T000P3_A193WWPMailTemplateName = new string[] {""} ;
         T000P3_A194WWPMailTemplateDescription = new string[] {""} ;
         T000P3_A195WWPMailTemplateSubject = new string[] {""} ;
         T000P3_A178WWPMailTemplateBody = new string[] {""} ;
         T000P3_A179WWPMailTemplateSenderAddress = new string[] {""} ;
         T000P3_A180WWPMailTemplateSenderName = new string[] {""} ;
         sMode35 = "";
         T000P6_A193WWPMailTemplateName = new string[] {""} ;
         T000P7_A193WWPMailTemplateName = new string[] {""} ;
         T000P2_A193WWPMailTemplateName = new string[] {""} ;
         T000P2_A194WWPMailTemplateDescription = new string[] {""} ;
         T000P2_A195WWPMailTemplateSubject = new string[] {""} ;
         T000P2_A178WWPMailTemplateBody = new string[] {""} ;
         T000P2_A179WWPMailTemplateSenderAddress = new string[] {""} ;
         T000P2_A180WWPMailTemplateSenderName = new string[] {""} ;
         T000P11_A193WWPMailTemplateName = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ193WWPMailTemplateName = "";
         ZZ194WWPMailTemplateDescription = "";
         ZZ195WWPMailTemplateSubject = "";
         ZZ178WWPMailTemplateBody = "";
         ZZ179WWPMailTemplateSenderAddress = "";
         ZZ180WWPMailTemplateSenderName = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mailtemplate__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mailtemplate__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mailtemplate__default(),
            new Object[][] {
                new Object[] {
               T000P2_A193WWPMailTemplateName, T000P2_A194WWPMailTemplateDescription, T000P2_A195WWPMailTemplateSubject, T000P2_A178WWPMailTemplateBody, T000P2_A179WWPMailTemplateSenderAddress, T000P2_A180WWPMailTemplateSenderName
               }
               , new Object[] {
               T000P3_A193WWPMailTemplateName, T000P3_A194WWPMailTemplateDescription, T000P3_A195WWPMailTemplateSubject, T000P3_A178WWPMailTemplateBody, T000P3_A179WWPMailTemplateSenderAddress, T000P3_A180WWPMailTemplateSenderName
               }
               , new Object[] {
               T000P4_A193WWPMailTemplateName, T000P4_A194WWPMailTemplateDescription, T000P4_A195WWPMailTemplateSubject, T000P4_A178WWPMailTemplateBody, T000P4_A179WWPMailTemplateSenderAddress, T000P4_A180WWPMailTemplateSenderName
               }
               , new Object[] {
               T000P5_A193WWPMailTemplateName
               }
               , new Object[] {
               T000P6_A193WWPMailTemplateName
               }
               , new Object[] {
               T000P7_A193WWPMailTemplateName
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000P11_A193WWPMailTemplateName
               }
            }
         );
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound35 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPMailTemplateName_Enabled ;
      private int edtWWPMailTemplateDescription_Enabled ;
      private int edtWWPMailTemplateSubject_Enabled ;
      private int edtWWPMailTemplateBody_Enabled ;
      private int edtWWPMailTemplateSenderAddress_Enabled ;
      private int edtWWPMailTemplateSenderName_Enabled ;
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
      private string edtWWPMailTemplateName_Internalname ;
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
      private string edtWWPMailTemplateName_Jsonclick ;
      private string edtWWPMailTemplateDescription_Internalname ;
      private string edtWWPMailTemplateDescription_Jsonclick ;
      private string edtWWPMailTemplateSubject_Internalname ;
      private string edtWWPMailTemplateSubject_Jsonclick ;
      private string edtWWPMailTemplateBody_Internalname ;
      private string edtWWPMailTemplateSenderAddress_Internalname ;
      private string edtWWPMailTemplateSenderName_Internalname ;
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
      private string sMode35 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool returnInSub ;
      private string A178WWPMailTemplateBody ;
      private string A179WWPMailTemplateSenderAddress ;
      private string A180WWPMailTemplateSenderName ;
      private string Z178WWPMailTemplateBody ;
      private string Z179WWPMailTemplateSenderAddress ;
      private string Z180WWPMailTemplateSenderName ;
      private string ZZ178WWPMailTemplateBody ;
      private string ZZ179WWPMailTemplateSenderAddress ;
      private string ZZ180WWPMailTemplateSenderName ;
      private string Z193WWPMailTemplateName ;
      private string Z194WWPMailTemplateDescription ;
      private string Z195WWPMailTemplateSubject ;
      private string A193WWPMailTemplateName ;
      private string A194WWPMailTemplateDescription ;
      private string A195WWPMailTemplateSubject ;
      private string ZZ193WWPMailTemplateName ;
      private string ZZ194WWPMailTemplateDescription ;
      private string ZZ195WWPMailTemplateSubject ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T000P4_A193WWPMailTemplateName ;
      private string[] T000P4_A194WWPMailTemplateDescription ;
      private string[] T000P4_A195WWPMailTemplateSubject ;
      private string[] T000P4_A178WWPMailTemplateBody ;
      private string[] T000P4_A179WWPMailTemplateSenderAddress ;
      private string[] T000P4_A180WWPMailTemplateSenderName ;
      private string[] T000P5_A193WWPMailTemplateName ;
      private string[] T000P3_A193WWPMailTemplateName ;
      private string[] T000P3_A194WWPMailTemplateDescription ;
      private string[] T000P3_A195WWPMailTemplateSubject ;
      private string[] T000P3_A178WWPMailTemplateBody ;
      private string[] T000P3_A179WWPMailTemplateSenderAddress ;
      private string[] T000P3_A180WWPMailTemplateSenderName ;
      private string[] T000P6_A193WWPMailTemplateName ;
      private string[] T000P7_A193WWPMailTemplateName ;
      private string[] T000P2_A193WWPMailTemplateName ;
      private string[] T000P2_A194WWPMailTemplateDescription ;
      private string[] T000P2_A195WWPMailTemplateSubject ;
      private string[] T000P2_A178WWPMailTemplateBody ;
      private string[] T000P2_A179WWPMailTemplateSenderAddress ;
      private string[] T000P2_A180WWPMailTemplateSenderName ;
      private string[] T000P11_A193WWPMailTemplateName ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_mailtemplate__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_mailtemplate__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_mailtemplate__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmT000P2;
       prmT000P2 = new Object[] {
       new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
       };
       Object[] prmT000P3;
       prmT000P3 = new Object[] {
       new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
       };
       Object[] prmT000P4;
       prmT000P4 = new Object[] {
       new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
       };
       Object[] prmT000P5;
       prmT000P5 = new Object[] {
       new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
       };
       Object[] prmT000P6;
       prmT000P6 = new Object[] {
       new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
       };
       Object[] prmT000P7;
       prmT000P7 = new Object[] {
       new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
       };
       Object[] prmT000P8;
       prmT000P8 = new Object[] {
       new ParDef("WWPMailTemplateName",GXType.VarChar,40,0) ,
       new ParDef("WWPMailTemplateDescription",GXType.VarChar,100,0) ,
       new ParDef("WWPMailTemplateSubject",GXType.VarChar,80,0) ,
       new ParDef("WWPMailTemplateBody",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPMailTemplateSenderAddress",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPMailTemplateSenderName",GXType.LongVarChar,2097152,0)
       };
       Object[] prmT000P9;
       prmT000P9 = new Object[] {
       new ParDef("WWPMailTemplateDescription",GXType.VarChar,100,0) ,
       new ParDef("WWPMailTemplateSubject",GXType.VarChar,80,0) ,
       new ParDef("WWPMailTemplateBody",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPMailTemplateSenderAddress",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPMailTemplateSenderName",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
       };
       Object[] prmT000P10;
       prmT000P10 = new Object[] {
       new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
       };
       Object[] prmT000P11;
       prmT000P11 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T000P2", "SELECT WWPMailTemplateName, WWPMailTemplateDescription, WWPMailTemplateSubject, WWPMailTemplateBody, WWPMailTemplateSenderAddress, WWPMailTemplateSenderName FROM WWP_MailTemplate WHERE WWPMailTemplateName = :WWPMailTemplateName  FOR UPDATE OF WWP_MailTemplate NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000P2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000P3", "SELECT WWPMailTemplateName, WWPMailTemplateDescription, WWPMailTemplateSubject, WWPMailTemplateBody, WWPMailTemplateSenderAddress, WWPMailTemplateSenderName FROM WWP_MailTemplate WHERE WWPMailTemplateName = :WWPMailTemplateName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000P4", "SELECT TM1.WWPMailTemplateName, TM1.WWPMailTemplateDescription, TM1.WWPMailTemplateSubject, TM1.WWPMailTemplateBody, TM1.WWPMailTemplateSenderAddress, TM1.WWPMailTemplateSenderName FROM WWP_MailTemplate TM1 WHERE TM1.WWPMailTemplateName = ( :WWPMailTemplateName) ORDER BY TM1.WWPMailTemplateName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000P5", "SELECT WWPMailTemplateName FROM WWP_MailTemplate WHERE WWPMailTemplateName = :WWPMailTemplateName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000P6", "SELECT WWPMailTemplateName FROM WWP_MailTemplate WHERE ( WWPMailTemplateName > ( :WWPMailTemplateName)) ORDER BY WWPMailTemplateName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P6,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000P7", "SELECT WWPMailTemplateName FROM WWP_MailTemplate WHERE ( WWPMailTemplateName < ( :WWPMailTemplateName)) ORDER BY WWPMailTemplateName DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P7,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000P8", "SAVEPOINT gxupdate;INSERT INTO WWP_MailTemplate(WWPMailTemplateName, WWPMailTemplateDescription, WWPMailTemplateSubject, WWPMailTemplateBody, WWPMailTemplateSenderAddress, WWPMailTemplateSenderName) VALUES(:WWPMailTemplateName, :WWPMailTemplateDescription, :WWPMailTemplateSubject, :WWPMailTemplateBody, :WWPMailTemplateSenderAddress, :WWPMailTemplateSenderName);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000P8)
          ,new CursorDef("T000P9", "SAVEPOINT gxupdate;UPDATE WWP_MailTemplate SET WWPMailTemplateDescription=:WWPMailTemplateDescription, WWPMailTemplateSubject=:WWPMailTemplateSubject, WWPMailTemplateBody=:WWPMailTemplateBody, WWPMailTemplateSenderAddress=:WWPMailTemplateSenderAddress, WWPMailTemplateSenderName=:WWPMailTemplateSenderName  WHERE WWPMailTemplateName = :WWPMailTemplateName;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000P9)
          ,new CursorDef("T000P10", "SAVEPOINT gxupdate;DELETE FROM WWP_MailTemplate  WHERE WWPMailTemplateName = :WWPMailTemplateName;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000P10)
          ,new CursorDef("T000P11", "SELECT WWPMailTemplateName FROM WWP_MailTemplate ORDER BY WWPMailTemplateName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P11,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             return;
          case 1 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 4 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 5 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 9 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
    }
 }

}

}
