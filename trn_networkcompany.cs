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
   public class trn_networkcompany : GXDataArea
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
         Form.Meta.addItem("description", context.GetMessage( "Trn_Network Company", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtNetworkCompanyId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_networkcompany( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_networkcompany( IGxContext context )
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
            return "trn_networkcompany_Execute" ;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Trn_Network Company", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Trn_NetworkCompany.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_NetworkCompany.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_NetworkCompany.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_NetworkCompany.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_NetworkCompany.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Trn_NetworkCompany.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNetworkCompanyId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNetworkCompanyId_Internalname, context.GetMessage( "Company Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNetworkCompanyId_Internalname, A82NetworkCompanyId.ToString(), A82NetworkCompanyId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNetworkCompanyId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNetworkCompanyId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_NetworkCompany.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNetworkCompanyKvkNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNetworkCompanyKvkNumber_Internalname, context.GetMessage( "Kvk Number", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNetworkCompanyKvkNumber_Internalname, A83NetworkCompanyKvkNumber, StringUtil.RTrim( context.localUtil.Format( A83NetworkCompanyKvkNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNetworkCompanyKvkNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNetworkCompanyKvkNumber_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, true, "KvkNumber", "start", true, "", "HLP_Trn_NetworkCompany.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNetworkCompanyName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNetworkCompanyName_Internalname, context.GetMessage( "Company Name", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNetworkCompanyName_Internalname, A84NetworkCompanyName, StringUtil.RTrim( context.localUtil.Format( A84NetworkCompanyName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNetworkCompanyName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNetworkCompanyName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_NetworkCompany.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNetworkCompanyContactName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNetworkCompanyContactName_Internalname, context.GetMessage( "Contact Name", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNetworkCompanyContactName_Internalname, A493NetworkCompanyContactName, StringUtil.RTrim( context.localUtil.Format( A493NetworkCompanyContactName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNetworkCompanyContactName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNetworkCompanyContactName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_NetworkCompany.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNetworkCompanyEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNetworkCompanyEmail_Internalname, context.GetMessage( "Company Email", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNetworkCompanyEmail_Internalname, A85NetworkCompanyEmail, StringUtil.RTrim( context.localUtil.Format( A85NetworkCompanyEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A85NetworkCompanyEmail, "", "", "", edtNetworkCompanyEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNetworkCompanyEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Trn_NetworkCompany.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNetworkCompanyPhone_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNetworkCompanyPhone_Internalname, context.GetMessage( "Company Phone", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A86NetworkCompanyPhone);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNetworkCompanyPhone_Internalname, StringUtil.RTrim( A86NetworkCompanyPhone), StringUtil.RTrim( context.localUtil.Format( A86NetworkCompanyPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtNetworkCompanyPhone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNetworkCompanyPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Trn_NetworkCompany.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNetworkCompanyPhoneCode_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNetworkCompanyPhoneCode_Internalname, context.GetMessage( "Phone Code", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNetworkCompanyPhoneCode_Internalname, A363NetworkCompanyPhoneCode, StringUtil.RTrim( context.localUtil.Format( A363NetworkCompanyPhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNetworkCompanyPhoneCode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNetworkCompanyPhoneCode_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_NetworkCompany.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNetworkCompanyPhoneNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNetworkCompanyPhoneNumber_Internalname, context.GetMessage( "Phone Number", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNetworkCompanyPhoneNumber_Internalname, A364NetworkCompanyPhoneNumber, StringUtil.RTrim( context.localUtil.Format( A364NetworkCompanyPhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNetworkCompanyPhoneNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNetworkCompanyPhoneNumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_NetworkCompany.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNetworkCompanyCountry_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNetworkCompanyCountry_Internalname, context.GetMessage( "Company Country", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNetworkCompanyCountry_Internalname, A317NetworkCompanyCountry, StringUtil.RTrim( context.localUtil.Format( A317NetworkCompanyCountry, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNetworkCompanyCountry_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNetworkCompanyCountry_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_NetworkCompany.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNetworkCompanyCity_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNetworkCompanyCity_Internalname, context.GetMessage( "Company City", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNetworkCompanyCity_Internalname, A318NetworkCompanyCity, StringUtil.RTrim( context.localUtil.Format( A318NetworkCompanyCity, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNetworkCompanyCity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNetworkCompanyCity_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_NetworkCompany.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNetworkCompanyZipCode_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNetworkCompanyZipCode_Internalname, context.GetMessage( "Zip Code", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNetworkCompanyZipCode_Internalname, A319NetworkCompanyZipCode, StringUtil.RTrim( context.localUtil.Format( A319NetworkCompanyZipCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNetworkCompanyZipCode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNetworkCompanyZipCode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_NetworkCompany.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNetworkCompanyAddressLine1_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNetworkCompanyAddressLine1_Internalname, context.GetMessage( "Address Line1", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNetworkCompanyAddressLine1_Internalname, A320NetworkCompanyAddressLine1, StringUtil.RTrim( context.localUtil.Format( A320NetworkCompanyAddressLine1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNetworkCompanyAddressLine1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNetworkCompanyAddressLine1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_NetworkCompany.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNetworkCompanyAddressLine2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNetworkCompanyAddressLine2_Internalname, context.GetMessage( "Address Line2", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNetworkCompanyAddressLine2_Internalname, A321NetworkCompanyAddressLine2, StringUtil.RTrim( context.localUtil.Format( A321NetworkCompanyAddressLine2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNetworkCompanyAddressLine2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNetworkCompanyAddressLine2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_NetworkCompany.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_NetworkCompany.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_NetworkCompany.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_NetworkCompany.htm");
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
            Z82NetworkCompanyId = StringUtil.StrToGuid( cgiGet( "Z82NetworkCompanyId"));
            Z83NetworkCompanyKvkNumber = cgiGet( "Z83NetworkCompanyKvkNumber");
            Z84NetworkCompanyName = cgiGet( "Z84NetworkCompanyName");
            Z493NetworkCompanyContactName = cgiGet( "Z493NetworkCompanyContactName");
            Z85NetworkCompanyEmail = cgiGet( "Z85NetworkCompanyEmail");
            Z86NetworkCompanyPhone = cgiGet( "Z86NetworkCompanyPhone");
            Z363NetworkCompanyPhoneCode = cgiGet( "Z363NetworkCompanyPhoneCode");
            Z364NetworkCompanyPhoneNumber = cgiGet( "Z364NetworkCompanyPhoneNumber");
            Z317NetworkCompanyCountry = cgiGet( "Z317NetworkCompanyCountry");
            Z318NetworkCompanyCity = cgiGet( "Z318NetworkCompanyCity");
            Z319NetworkCompanyZipCode = cgiGet( "Z319NetworkCompanyZipCode");
            Z320NetworkCompanyAddressLine1 = cgiGet( "Z320NetworkCompanyAddressLine1");
            Z321NetworkCompanyAddressLine2 = cgiGet( "Z321NetworkCompanyAddressLine2");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( StringUtil.StrCmp(cgiGet( edtNetworkCompanyId_Internalname), "") == 0 )
            {
               A82NetworkCompanyId = Guid.Empty;
               AssignAttri("", false, "A82NetworkCompanyId", A82NetworkCompanyId.ToString());
            }
            else
            {
               try
               {
                  A82NetworkCompanyId = StringUtil.StrToGuid( cgiGet( edtNetworkCompanyId_Internalname));
                  AssignAttri("", false, "A82NetworkCompanyId", A82NetworkCompanyId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "NETWORKCOMPANYID");
                  AnyError = 1;
                  GX_FocusControl = edtNetworkCompanyId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            A83NetworkCompanyKvkNumber = cgiGet( edtNetworkCompanyKvkNumber_Internalname);
            AssignAttri("", false, "A83NetworkCompanyKvkNumber", A83NetworkCompanyKvkNumber);
            A84NetworkCompanyName = cgiGet( edtNetworkCompanyName_Internalname);
            AssignAttri("", false, "A84NetworkCompanyName", A84NetworkCompanyName);
            A493NetworkCompanyContactName = cgiGet( edtNetworkCompanyContactName_Internalname);
            AssignAttri("", false, "A493NetworkCompanyContactName", A493NetworkCompanyContactName);
            A85NetworkCompanyEmail = cgiGet( edtNetworkCompanyEmail_Internalname);
            AssignAttri("", false, "A85NetworkCompanyEmail", A85NetworkCompanyEmail);
            A86NetworkCompanyPhone = cgiGet( edtNetworkCompanyPhone_Internalname);
            AssignAttri("", false, "A86NetworkCompanyPhone", A86NetworkCompanyPhone);
            A363NetworkCompanyPhoneCode = cgiGet( edtNetworkCompanyPhoneCode_Internalname);
            AssignAttri("", false, "A363NetworkCompanyPhoneCode", A363NetworkCompanyPhoneCode);
            A364NetworkCompanyPhoneNumber = cgiGet( edtNetworkCompanyPhoneNumber_Internalname);
            AssignAttri("", false, "A364NetworkCompanyPhoneNumber", A364NetworkCompanyPhoneNumber);
            A317NetworkCompanyCountry = cgiGet( edtNetworkCompanyCountry_Internalname);
            AssignAttri("", false, "A317NetworkCompanyCountry", A317NetworkCompanyCountry);
            A318NetworkCompanyCity = cgiGet( edtNetworkCompanyCity_Internalname);
            AssignAttri("", false, "A318NetworkCompanyCity", A318NetworkCompanyCity);
            A319NetworkCompanyZipCode = cgiGet( edtNetworkCompanyZipCode_Internalname);
            AssignAttri("", false, "A319NetworkCompanyZipCode", A319NetworkCompanyZipCode);
            A320NetworkCompanyAddressLine1 = cgiGet( edtNetworkCompanyAddressLine1_Internalname);
            AssignAttri("", false, "A320NetworkCompanyAddressLine1", A320NetworkCompanyAddressLine1);
            A321NetworkCompanyAddressLine2 = cgiGet( edtNetworkCompanyAddressLine2_Internalname);
            AssignAttri("", false, "A321NetworkCompanyAddressLine2", A321NetworkCompanyAddressLine2);
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
               A82NetworkCompanyId = StringUtil.StrToGuid( GetPar( "NetworkCompanyId"));
               AssignAttri("", false, "A82NetworkCompanyId", A82NetworkCompanyId.ToString());
               getEqualNoModal( ) ;
               if ( IsIns( )  && (Guid.Empty==A82NetworkCompanyId) && ( Gx_BScreen == 0 ) )
               {
                  A82NetworkCompanyId = Guid.NewGuid( );
                  AssignAttri("", false, "A82NetworkCompanyId", A82NetworkCompanyId.ToString());
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
               InitAll0B19( ) ;
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
         DisableAttributes0B19( ) ;
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

      protected void ResetCaption0B0( )
      {
      }

      protected void ZM0B19( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z83NetworkCompanyKvkNumber = T000B3_A83NetworkCompanyKvkNumber[0];
               Z84NetworkCompanyName = T000B3_A84NetworkCompanyName[0];
               Z493NetworkCompanyContactName = T000B3_A493NetworkCompanyContactName[0];
               Z85NetworkCompanyEmail = T000B3_A85NetworkCompanyEmail[0];
               Z86NetworkCompanyPhone = T000B3_A86NetworkCompanyPhone[0];
               Z363NetworkCompanyPhoneCode = T000B3_A363NetworkCompanyPhoneCode[0];
               Z364NetworkCompanyPhoneNumber = T000B3_A364NetworkCompanyPhoneNumber[0];
               Z317NetworkCompanyCountry = T000B3_A317NetworkCompanyCountry[0];
               Z318NetworkCompanyCity = T000B3_A318NetworkCompanyCity[0];
               Z319NetworkCompanyZipCode = T000B3_A319NetworkCompanyZipCode[0];
               Z320NetworkCompanyAddressLine1 = T000B3_A320NetworkCompanyAddressLine1[0];
               Z321NetworkCompanyAddressLine2 = T000B3_A321NetworkCompanyAddressLine2[0];
            }
            else
            {
               Z83NetworkCompanyKvkNumber = A83NetworkCompanyKvkNumber;
               Z84NetworkCompanyName = A84NetworkCompanyName;
               Z493NetworkCompanyContactName = A493NetworkCompanyContactName;
               Z85NetworkCompanyEmail = A85NetworkCompanyEmail;
               Z86NetworkCompanyPhone = A86NetworkCompanyPhone;
               Z363NetworkCompanyPhoneCode = A363NetworkCompanyPhoneCode;
               Z364NetworkCompanyPhoneNumber = A364NetworkCompanyPhoneNumber;
               Z317NetworkCompanyCountry = A317NetworkCompanyCountry;
               Z318NetworkCompanyCity = A318NetworkCompanyCity;
               Z319NetworkCompanyZipCode = A319NetworkCompanyZipCode;
               Z320NetworkCompanyAddressLine1 = A320NetworkCompanyAddressLine1;
               Z321NetworkCompanyAddressLine2 = A321NetworkCompanyAddressLine2;
            }
         }
         if ( GX_JID == -7 )
         {
            Z82NetworkCompanyId = A82NetworkCompanyId;
            Z83NetworkCompanyKvkNumber = A83NetworkCompanyKvkNumber;
            Z84NetworkCompanyName = A84NetworkCompanyName;
            Z493NetworkCompanyContactName = A493NetworkCompanyContactName;
            Z85NetworkCompanyEmail = A85NetworkCompanyEmail;
            Z86NetworkCompanyPhone = A86NetworkCompanyPhone;
            Z363NetworkCompanyPhoneCode = A363NetworkCompanyPhoneCode;
            Z364NetworkCompanyPhoneNumber = A364NetworkCompanyPhoneNumber;
            Z317NetworkCompanyCountry = A317NetworkCompanyCountry;
            Z318NetworkCompanyCity = A318NetworkCompanyCity;
            Z319NetworkCompanyZipCode = A319NetworkCompanyZipCode;
            Z320NetworkCompanyAddressLine1 = A320NetworkCompanyAddressLine1;
            Z321NetworkCompanyAddressLine2 = A321NetworkCompanyAddressLine2;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A82NetworkCompanyId) && ( Gx_BScreen == 0 ) )
         {
            A82NetworkCompanyId = Guid.NewGuid( );
            AssignAttri("", false, "A82NetworkCompanyId", A82NetworkCompanyId.ToString());
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

      protected void Load0B19( )
      {
         /* Using cursor T000B4 */
         pr_default.execute(2, new Object[] {A82NetworkCompanyId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound19 = 1;
            A83NetworkCompanyKvkNumber = T000B4_A83NetworkCompanyKvkNumber[0];
            AssignAttri("", false, "A83NetworkCompanyKvkNumber", A83NetworkCompanyKvkNumber);
            A84NetworkCompanyName = T000B4_A84NetworkCompanyName[0];
            AssignAttri("", false, "A84NetworkCompanyName", A84NetworkCompanyName);
            A493NetworkCompanyContactName = T000B4_A493NetworkCompanyContactName[0];
            AssignAttri("", false, "A493NetworkCompanyContactName", A493NetworkCompanyContactName);
            A85NetworkCompanyEmail = T000B4_A85NetworkCompanyEmail[0];
            AssignAttri("", false, "A85NetworkCompanyEmail", A85NetworkCompanyEmail);
            A86NetworkCompanyPhone = T000B4_A86NetworkCompanyPhone[0];
            AssignAttri("", false, "A86NetworkCompanyPhone", A86NetworkCompanyPhone);
            A363NetworkCompanyPhoneCode = T000B4_A363NetworkCompanyPhoneCode[0];
            AssignAttri("", false, "A363NetworkCompanyPhoneCode", A363NetworkCompanyPhoneCode);
            A364NetworkCompanyPhoneNumber = T000B4_A364NetworkCompanyPhoneNumber[0];
            AssignAttri("", false, "A364NetworkCompanyPhoneNumber", A364NetworkCompanyPhoneNumber);
            A317NetworkCompanyCountry = T000B4_A317NetworkCompanyCountry[0];
            AssignAttri("", false, "A317NetworkCompanyCountry", A317NetworkCompanyCountry);
            A318NetworkCompanyCity = T000B4_A318NetworkCompanyCity[0];
            AssignAttri("", false, "A318NetworkCompanyCity", A318NetworkCompanyCity);
            A319NetworkCompanyZipCode = T000B4_A319NetworkCompanyZipCode[0];
            AssignAttri("", false, "A319NetworkCompanyZipCode", A319NetworkCompanyZipCode);
            A320NetworkCompanyAddressLine1 = T000B4_A320NetworkCompanyAddressLine1[0];
            AssignAttri("", false, "A320NetworkCompanyAddressLine1", A320NetworkCompanyAddressLine1);
            A321NetworkCompanyAddressLine2 = T000B4_A321NetworkCompanyAddressLine2[0];
            AssignAttri("", false, "A321NetworkCompanyAddressLine2", A321NetworkCompanyAddressLine2);
            ZM0B19( -7) ;
         }
         pr_default.close(2);
         OnLoadActions0B19( ) ;
      }

      protected void OnLoadActions0B19( )
      {
      }

      protected void CheckExtendedTable0B19( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( StringUtil.Len( A83NetworkCompanyKvkNumber) != 8 )
         {
            GX_msglist.addItem(context.GetMessage( "KVK number contains 8 digits", ""), 1, "NETWORKCOMPANYKVKNUMBER");
            AnyError = 1;
            GX_FocusControl = edtNetworkCompanyKvkNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A85NetworkCompanyEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "Invalid email pattern", ""), context.GetMessage( "Network Company Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "NETWORKCOMPANYEMAIL");
            AnyError = 1;
            GX_FocusControl = edtNetworkCompanyEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A364NetworkCompanyPhoneNumber)) && ! GxRegex.IsMatch(A364NetworkCompanyPhoneNumber,context.GetMessage( "^\\d{9}$", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Phone contains 9 digits", ""), 1, "NETWORKCOMPANYPHONENUMBER");
            AnyError = 1;
            GX_FocusControl = edtNetworkCompanyPhoneNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! GxRegex.IsMatch(A319NetworkCompanyZipCode,context.GetMessage( "^\\d{4}\\s?[A-Z]{2}$", "")) && ! String.IsNullOrEmpty(StringUtil.RTrim( A319NetworkCompanyZipCode)) )
         {
            GX_msglist.addItem(context.GetMessage( "Zip Code is incorrect", ""), 1, "NETWORKCOMPANYZIPCODE");
            AnyError = 1;
            GX_FocusControl = edtNetworkCompanyZipCode_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0B19( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0B19( )
      {
         /* Using cursor T000B5 */
         pr_default.execute(3, new Object[] {A82NetworkCompanyId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound19 = 1;
         }
         else
         {
            RcdFound19 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000B3 */
         pr_default.execute(1, new Object[] {A82NetworkCompanyId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0B19( 7) ;
            RcdFound19 = 1;
            A82NetworkCompanyId = T000B3_A82NetworkCompanyId[0];
            AssignAttri("", false, "A82NetworkCompanyId", A82NetworkCompanyId.ToString());
            A83NetworkCompanyKvkNumber = T000B3_A83NetworkCompanyKvkNumber[0];
            AssignAttri("", false, "A83NetworkCompanyKvkNumber", A83NetworkCompanyKvkNumber);
            A84NetworkCompanyName = T000B3_A84NetworkCompanyName[0];
            AssignAttri("", false, "A84NetworkCompanyName", A84NetworkCompanyName);
            A493NetworkCompanyContactName = T000B3_A493NetworkCompanyContactName[0];
            AssignAttri("", false, "A493NetworkCompanyContactName", A493NetworkCompanyContactName);
            A85NetworkCompanyEmail = T000B3_A85NetworkCompanyEmail[0];
            AssignAttri("", false, "A85NetworkCompanyEmail", A85NetworkCompanyEmail);
            A86NetworkCompanyPhone = T000B3_A86NetworkCompanyPhone[0];
            AssignAttri("", false, "A86NetworkCompanyPhone", A86NetworkCompanyPhone);
            A363NetworkCompanyPhoneCode = T000B3_A363NetworkCompanyPhoneCode[0];
            AssignAttri("", false, "A363NetworkCompanyPhoneCode", A363NetworkCompanyPhoneCode);
            A364NetworkCompanyPhoneNumber = T000B3_A364NetworkCompanyPhoneNumber[0];
            AssignAttri("", false, "A364NetworkCompanyPhoneNumber", A364NetworkCompanyPhoneNumber);
            A317NetworkCompanyCountry = T000B3_A317NetworkCompanyCountry[0];
            AssignAttri("", false, "A317NetworkCompanyCountry", A317NetworkCompanyCountry);
            A318NetworkCompanyCity = T000B3_A318NetworkCompanyCity[0];
            AssignAttri("", false, "A318NetworkCompanyCity", A318NetworkCompanyCity);
            A319NetworkCompanyZipCode = T000B3_A319NetworkCompanyZipCode[0];
            AssignAttri("", false, "A319NetworkCompanyZipCode", A319NetworkCompanyZipCode);
            A320NetworkCompanyAddressLine1 = T000B3_A320NetworkCompanyAddressLine1[0];
            AssignAttri("", false, "A320NetworkCompanyAddressLine1", A320NetworkCompanyAddressLine1);
            A321NetworkCompanyAddressLine2 = T000B3_A321NetworkCompanyAddressLine2[0];
            AssignAttri("", false, "A321NetworkCompanyAddressLine2", A321NetworkCompanyAddressLine2);
            Z82NetworkCompanyId = A82NetworkCompanyId;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0B19( ) ;
            if ( AnyError == 1 )
            {
               RcdFound19 = 0;
               InitializeNonKey0B19( ) ;
            }
            Gx_mode = sMode19;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound19 = 0;
            InitializeNonKey0B19( ) ;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode19;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0B19( ) ;
         if ( RcdFound19 == 0 )
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
         RcdFound19 = 0;
         /* Using cursor T000B6 */
         pr_default.execute(4, new Object[] {A82NetworkCompanyId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( GuidUtil.Compare(T000B6_A82NetworkCompanyId[0], A82NetworkCompanyId, 0) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( GuidUtil.Compare(T000B6_A82NetworkCompanyId[0], A82NetworkCompanyId, 0) > 0 ) ) )
            {
               A82NetworkCompanyId = T000B6_A82NetworkCompanyId[0];
               AssignAttri("", false, "A82NetworkCompanyId", A82NetworkCompanyId.ToString());
               RcdFound19 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound19 = 0;
         /* Using cursor T000B7 */
         pr_default.execute(5, new Object[] {A82NetworkCompanyId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T000B7_A82NetworkCompanyId[0], A82NetworkCompanyId, 0) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T000B7_A82NetworkCompanyId[0], A82NetworkCompanyId, 0) < 0 ) ) )
            {
               A82NetworkCompanyId = T000B7_A82NetworkCompanyId[0];
               AssignAttri("", false, "A82NetworkCompanyId", A82NetworkCompanyId.ToString());
               RcdFound19 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0B19( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtNetworkCompanyId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0B19( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound19 == 1 )
            {
               if ( A82NetworkCompanyId != Z82NetworkCompanyId )
               {
                  A82NetworkCompanyId = Z82NetworkCompanyId;
                  AssignAttri("", false, "A82NetworkCompanyId", A82NetworkCompanyId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "NETWORKCOMPANYID");
                  AnyError = 1;
                  GX_FocusControl = edtNetworkCompanyId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtNetworkCompanyId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0B19( ) ;
                  GX_FocusControl = edtNetworkCompanyId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A82NetworkCompanyId != Z82NetworkCompanyId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtNetworkCompanyId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0B19( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "NETWORKCOMPANYID");
                     AnyError = 1;
                     GX_FocusControl = edtNetworkCompanyId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtNetworkCompanyId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0B19( ) ;
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
         if ( A82NetworkCompanyId != Z82NetworkCompanyId )
         {
            A82NetworkCompanyId = Z82NetworkCompanyId;
            AssignAttri("", false, "A82NetworkCompanyId", A82NetworkCompanyId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "NETWORKCOMPANYID");
            AnyError = 1;
            GX_FocusControl = edtNetworkCompanyId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtNetworkCompanyId_Internalname;
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
         if ( RcdFound19 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "NETWORKCOMPANYID");
            AnyError = 1;
            GX_FocusControl = edtNetworkCompanyId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtNetworkCompanyKvkNumber_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0B19( ) ;
         if ( RcdFound19 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtNetworkCompanyKvkNumber_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0B19( ) ;
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
         if ( RcdFound19 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtNetworkCompanyKvkNumber_Internalname;
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
         if ( RcdFound19 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtNetworkCompanyKvkNumber_Internalname;
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
         ScanStart0B19( ) ;
         if ( RcdFound19 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound19 != 0 )
            {
               ScanNext0B19( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtNetworkCompanyKvkNumber_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0B19( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0B19( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000B2 */
            pr_default.execute(0, new Object[] {A82NetworkCompanyId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_NetworkCompany"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z83NetworkCompanyKvkNumber, T000B2_A83NetworkCompanyKvkNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z84NetworkCompanyName, T000B2_A84NetworkCompanyName[0]) != 0 ) || ( StringUtil.StrCmp(Z493NetworkCompanyContactName, T000B2_A493NetworkCompanyContactName[0]) != 0 ) || ( StringUtil.StrCmp(Z85NetworkCompanyEmail, T000B2_A85NetworkCompanyEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z86NetworkCompanyPhone, T000B2_A86NetworkCompanyPhone[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z363NetworkCompanyPhoneCode, T000B2_A363NetworkCompanyPhoneCode[0]) != 0 ) || ( StringUtil.StrCmp(Z364NetworkCompanyPhoneNumber, T000B2_A364NetworkCompanyPhoneNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z317NetworkCompanyCountry, T000B2_A317NetworkCompanyCountry[0]) != 0 ) || ( StringUtil.StrCmp(Z318NetworkCompanyCity, T000B2_A318NetworkCompanyCity[0]) != 0 ) || ( StringUtil.StrCmp(Z319NetworkCompanyZipCode, T000B2_A319NetworkCompanyZipCode[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z320NetworkCompanyAddressLine1, T000B2_A320NetworkCompanyAddressLine1[0]) != 0 ) || ( StringUtil.StrCmp(Z321NetworkCompanyAddressLine2, T000B2_A321NetworkCompanyAddressLine2[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z83NetworkCompanyKvkNumber, T000B2_A83NetworkCompanyKvkNumber[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_networkcompany:[seudo value changed for attri]"+"NetworkCompanyKvkNumber");
                  GXUtil.WriteLogRaw("Old: ",Z83NetworkCompanyKvkNumber);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A83NetworkCompanyKvkNumber[0]);
               }
               if ( StringUtil.StrCmp(Z84NetworkCompanyName, T000B2_A84NetworkCompanyName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_networkcompany:[seudo value changed for attri]"+"NetworkCompanyName");
                  GXUtil.WriteLogRaw("Old: ",Z84NetworkCompanyName);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A84NetworkCompanyName[0]);
               }
               if ( StringUtil.StrCmp(Z493NetworkCompanyContactName, T000B2_A493NetworkCompanyContactName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_networkcompany:[seudo value changed for attri]"+"NetworkCompanyContactName");
                  GXUtil.WriteLogRaw("Old: ",Z493NetworkCompanyContactName);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A493NetworkCompanyContactName[0]);
               }
               if ( StringUtil.StrCmp(Z85NetworkCompanyEmail, T000B2_A85NetworkCompanyEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_networkcompany:[seudo value changed for attri]"+"NetworkCompanyEmail");
                  GXUtil.WriteLogRaw("Old: ",Z85NetworkCompanyEmail);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A85NetworkCompanyEmail[0]);
               }
               if ( StringUtil.StrCmp(Z86NetworkCompanyPhone, T000B2_A86NetworkCompanyPhone[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_networkcompany:[seudo value changed for attri]"+"NetworkCompanyPhone");
                  GXUtil.WriteLogRaw("Old: ",Z86NetworkCompanyPhone);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A86NetworkCompanyPhone[0]);
               }
               if ( StringUtil.StrCmp(Z363NetworkCompanyPhoneCode, T000B2_A363NetworkCompanyPhoneCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_networkcompany:[seudo value changed for attri]"+"NetworkCompanyPhoneCode");
                  GXUtil.WriteLogRaw("Old: ",Z363NetworkCompanyPhoneCode);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A363NetworkCompanyPhoneCode[0]);
               }
               if ( StringUtil.StrCmp(Z364NetworkCompanyPhoneNumber, T000B2_A364NetworkCompanyPhoneNumber[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_networkcompany:[seudo value changed for attri]"+"NetworkCompanyPhoneNumber");
                  GXUtil.WriteLogRaw("Old: ",Z364NetworkCompanyPhoneNumber);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A364NetworkCompanyPhoneNumber[0]);
               }
               if ( StringUtil.StrCmp(Z317NetworkCompanyCountry, T000B2_A317NetworkCompanyCountry[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_networkcompany:[seudo value changed for attri]"+"NetworkCompanyCountry");
                  GXUtil.WriteLogRaw("Old: ",Z317NetworkCompanyCountry);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A317NetworkCompanyCountry[0]);
               }
               if ( StringUtil.StrCmp(Z318NetworkCompanyCity, T000B2_A318NetworkCompanyCity[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_networkcompany:[seudo value changed for attri]"+"NetworkCompanyCity");
                  GXUtil.WriteLogRaw("Old: ",Z318NetworkCompanyCity);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A318NetworkCompanyCity[0]);
               }
               if ( StringUtil.StrCmp(Z319NetworkCompanyZipCode, T000B2_A319NetworkCompanyZipCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_networkcompany:[seudo value changed for attri]"+"NetworkCompanyZipCode");
                  GXUtil.WriteLogRaw("Old: ",Z319NetworkCompanyZipCode);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A319NetworkCompanyZipCode[0]);
               }
               if ( StringUtil.StrCmp(Z320NetworkCompanyAddressLine1, T000B2_A320NetworkCompanyAddressLine1[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_networkcompany:[seudo value changed for attri]"+"NetworkCompanyAddressLine1");
                  GXUtil.WriteLogRaw("Old: ",Z320NetworkCompanyAddressLine1);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A320NetworkCompanyAddressLine1[0]);
               }
               if ( StringUtil.StrCmp(Z321NetworkCompanyAddressLine2, T000B2_A321NetworkCompanyAddressLine2[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_networkcompany:[seudo value changed for attri]"+"NetworkCompanyAddressLine2");
                  GXUtil.WriteLogRaw("Old: ",Z321NetworkCompanyAddressLine2);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A321NetworkCompanyAddressLine2[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_NetworkCompany"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0B19( )
      {
         if ( ! IsAuthorized("trn_networkcompany_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0B19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B19( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0B19( 0) ;
            CheckOptimisticConcurrency0B19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0B19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000B8 */
                     pr_default.execute(6, new Object[] {A82NetworkCompanyId, A83NetworkCompanyKvkNumber, A84NetworkCompanyName, A493NetworkCompanyContactName, A85NetworkCompanyEmail, A86NetworkCompanyPhone, A363NetworkCompanyPhoneCode, A364NetworkCompanyPhoneNumber, A317NetworkCompanyCountry, A318NetworkCompanyCity, A319NetworkCompanyZipCode, A320NetworkCompanyAddressLine1, A321NetworkCompanyAddressLine2});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_NetworkCompany");
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
                           ResetCaption0B0( ) ;
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
               Load0B19( ) ;
            }
            EndLevel0B19( ) ;
         }
         CloseExtendedTableCursors0B19( ) ;
      }

      protected void Update0B19( )
      {
         if ( ! IsAuthorized("trn_networkcompany_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0B19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B19( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0B19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000B9 */
                     pr_default.execute(7, new Object[] {A83NetworkCompanyKvkNumber, A84NetworkCompanyName, A493NetworkCompanyContactName, A85NetworkCompanyEmail, A86NetworkCompanyPhone, A363NetworkCompanyPhoneCode, A364NetworkCompanyPhoneNumber, A317NetworkCompanyCountry, A318NetworkCompanyCity, A319NetworkCompanyZipCode, A320NetworkCompanyAddressLine1, A321NetworkCompanyAddressLine2, A82NetworkCompanyId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_NetworkCompany");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_NetworkCompany"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0B19( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0B0( ) ;
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
            EndLevel0B19( ) ;
         }
         CloseExtendedTableCursors0B19( ) ;
      }

      protected void DeferredUpdate0B19( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_networkcompany_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0B19( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B19( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0B19( ) ;
            AfterConfirm0B19( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0B19( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000B10 */
                  pr_default.execute(8, new Object[] {A82NetworkCompanyId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_NetworkCompany");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound19 == 0 )
                        {
                           InitAll0B19( ) ;
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
                        ResetCaption0B0( ) ;
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
         sMode19 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0B19( ) ;
         Gx_mode = sMode19;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0B19( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0B19( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0B19( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_networkcompany",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0B0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_networkcompany",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0B19( )
      {
         /* Using cursor T000B11 */
         pr_default.execute(9);
         RcdFound19 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound19 = 1;
            A82NetworkCompanyId = T000B11_A82NetworkCompanyId[0];
            AssignAttri("", false, "A82NetworkCompanyId", A82NetworkCompanyId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0B19( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound19 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound19 = 1;
            A82NetworkCompanyId = T000B11_A82NetworkCompanyId[0];
            AssignAttri("", false, "A82NetworkCompanyId", A82NetworkCompanyId.ToString());
         }
      }

      protected void ScanEnd0B19( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0B19( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0B19( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0B19( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0B19( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0B19( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0B19( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0B19( )
      {
         edtNetworkCompanyId_Enabled = 0;
         AssignProp("", false, edtNetworkCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyId_Enabled), 5, 0), true);
         edtNetworkCompanyKvkNumber_Enabled = 0;
         AssignProp("", false, edtNetworkCompanyKvkNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyKvkNumber_Enabled), 5, 0), true);
         edtNetworkCompanyName_Enabled = 0;
         AssignProp("", false, edtNetworkCompanyName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyName_Enabled), 5, 0), true);
         edtNetworkCompanyContactName_Enabled = 0;
         AssignProp("", false, edtNetworkCompanyContactName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyContactName_Enabled), 5, 0), true);
         edtNetworkCompanyEmail_Enabled = 0;
         AssignProp("", false, edtNetworkCompanyEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyEmail_Enabled), 5, 0), true);
         edtNetworkCompanyPhone_Enabled = 0;
         AssignProp("", false, edtNetworkCompanyPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyPhone_Enabled), 5, 0), true);
         edtNetworkCompanyPhoneCode_Enabled = 0;
         AssignProp("", false, edtNetworkCompanyPhoneCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyPhoneCode_Enabled), 5, 0), true);
         edtNetworkCompanyPhoneNumber_Enabled = 0;
         AssignProp("", false, edtNetworkCompanyPhoneNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyPhoneNumber_Enabled), 5, 0), true);
         edtNetworkCompanyCountry_Enabled = 0;
         AssignProp("", false, edtNetworkCompanyCountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyCountry_Enabled), 5, 0), true);
         edtNetworkCompanyCity_Enabled = 0;
         AssignProp("", false, edtNetworkCompanyCity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyCity_Enabled), 5, 0), true);
         edtNetworkCompanyZipCode_Enabled = 0;
         AssignProp("", false, edtNetworkCompanyZipCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyZipCode_Enabled), 5, 0), true);
         edtNetworkCompanyAddressLine1_Enabled = 0;
         AssignProp("", false, edtNetworkCompanyAddressLine1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyAddressLine1_Enabled), 5, 0), true);
         edtNetworkCompanyAddressLine2_Enabled = 0;
         AssignProp("", false, edtNetworkCompanyAddressLine2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyAddressLine2_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0B19( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0B0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_networkcompany.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z82NetworkCompanyId", Z82NetworkCompanyId.ToString());
         GxWebStd.gx_hidden_field( context, "Z83NetworkCompanyKvkNumber", Z83NetworkCompanyKvkNumber);
         GxWebStd.gx_hidden_field( context, "Z84NetworkCompanyName", Z84NetworkCompanyName);
         GxWebStd.gx_hidden_field( context, "Z493NetworkCompanyContactName", Z493NetworkCompanyContactName);
         GxWebStd.gx_hidden_field( context, "Z85NetworkCompanyEmail", Z85NetworkCompanyEmail);
         GxWebStd.gx_hidden_field( context, "Z86NetworkCompanyPhone", StringUtil.RTrim( Z86NetworkCompanyPhone));
         GxWebStd.gx_hidden_field( context, "Z363NetworkCompanyPhoneCode", Z363NetworkCompanyPhoneCode);
         GxWebStd.gx_hidden_field( context, "Z364NetworkCompanyPhoneNumber", Z364NetworkCompanyPhoneNumber);
         GxWebStd.gx_hidden_field( context, "Z317NetworkCompanyCountry", Z317NetworkCompanyCountry);
         GxWebStd.gx_hidden_field( context, "Z318NetworkCompanyCity", Z318NetworkCompanyCity);
         GxWebStd.gx_hidden_field( context, "Z319NetworkCompanyZipCode", Z319NetworkCompanyZipCode);
         GxWebStd.gx_hidden_field( context, "Z320NetworkCompanyAddressLine1", Z320NetworkCompanyAddressLine1);
         GxWebStd.gx_hidden_field( context, "Z321NetworkCompanyAddressLine2", Z321NetworkCompanyAddressLine2);
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
         return formatLink("trn_networkcompany.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_NetworkCompany" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Network Company", "") ;
      }

      protected void InitializeNonKey0B19( )
      {
         A83NetworkCompanyKvkNumber = "";
         AssignAttri("", false, "A83NetworkCompanyKvkNumber", A83NetworkCompanyKvkNumber);
         A84NetworkCompanyName = "";
         AssignAttri("", false, "A84NetworkCompanyName", A84NetworkCompanyName);
         A493NetworkCompanyContactName = "";
         AssignAttri("", false, "A493NetworkCompanyContactName", A493NetworkCompanyContactName);
         A85NetworkCompanyEmail = "";
         AssignAttri("", false, "A85NetworkCompanyEmail", A85NetworkCompanyEmail);
         A86NetworkCompanyPhone = "";
         AssignAttri("", false, "A86NetworkCompanyPhone", A86NetworkCompanyPhone);
         A363NetworkCompanyPhoneCode = "";
         AssignAttri("", false, "A363NetworkCompanyPhoneCode", A363NetworkCompanyPhoneCode);
         A364NetworkCompanyPhoneNumber = "";
         AssignAttri("", false, "A364NetworkCompanyPhoneNumber", A364NetworkCompanyPhoneNumber);
         A317NetworkCompanyCountry = "";
         AssignAttri("", false, "A317NetworkCompanyCountry", A317NetworkCompanyCountry);
         A318NetworkCompanyCity = "";
         AssignAttri("", false, "A318NetworkCompanyCity", A318NetworkCompanyCity);
         A319NetworkCompanyZipCode = "";
         AssignAttri("", false, "A319NetworkCompanyZipCode", A319NetworkCompanyZipCode);
         A320NetworkCompanyAddressLine1 = "";
         AssignAttri("", false, "A320NetworkCompanyAddressLine1", A320NetworkCompanyAddressLine1);
         A321NetworkCompanyAddressLine2 = "";
         AssignAttri("", false, "A321NetworkCompanyAddressLine2", A321NetworkCompanyAddressLine2);
         Z83NetworkCompanyKvkNumber = "";
         Z84NetworkCompanyName = "";
         Z493NetworkCompanyContactName = "";
         Z85NetworkCompanyEmail = "";
         Z86NetworkCompanyPhone = "";
         Z363NetworkCompanyPhoneCode = "";
         Z364NetworkCompanyPhoneNumber = "";
         Z317NetworkCompanyCountry = "";
         Z318NetworkCompanyCity = "";
         Z319NetworkCompanyZipCode = "";
         Z320NetworkCompanyAddressLine1 = "";
         Z321NetworkCompanyAddressLine2 = "";
      }

      protected void InitAll0B19( )
      {
         A82NetworkCompanyId = Guid.NewGuid( );
         AssignAttri("", false, "A82NetworkCompanyId", A82NetworkCompanyId.ToString());
         InitializeNonKey0B19( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256309381726", true, true);
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
         context.AddJavascriptSource("trn_networkcompany.js", "?20256309381726", false, true);
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
         edtNetworkCompanyId_Internalname = "NETWORKCOMPANYID";
         edtNetworkCompanyKvkNumber_Internalname = "NETWORKCOMPANYKVKNUMBER";
         edtNetworkCompanyName_Internalname = "NETWORKCOMPANYNAME";
         edtNetworkCompanyContactName_Internalname = "NETWORKCOMPANYCONTACTNAME";
         edtNetworkCompanyEmail_Internalname = "NETWORKCOMPANYEMAIL";
         edtNetworkCompanyPhone_Internalname = "NETWORKCOMPANYPHONE";
         edtNetworkCompanyPhoneCode_Internalname = "NETWORKCOMPANYPHONECODE";
         edtNetworkCompanyPhoneNumber_Internalname = "NETWORKCOMPANYPHONENUMBER";
         edtNetworkCompanyCountry_Internalname = "NETWORKCOMPANYCOUNTRY";
         edtNetworkCompanyCity_Internalname = "NETWORKCOMPANYCITY";
         edtNetworkCompanyZipCode_Internalname = "NETWORKCOMPANYZIPCODE";
         edtNetworkCompanyAddressLine1_Internalname = "NETWORKCOMPANYADDRESSLINE1";
         edtNetworkCompanyAddressLine2_Internalname = "NETWORKCOMPANYADDRESSLINE2";
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
         Form.Caption = context.GetMessage( "Trn_Network Company", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtNetworkCompanyAddressLine2_Jsonclick = "";
         edtNetworkCompanyAddressLine2_Enabled = 1;
         edtNetworkCompanyAddressLine1_Jsonclick = "";
         edtNetworkCompanyAddressLine1_Enabled = 1;
         edtNetworkCompanyZipCode_Jsonclick = "";
         edtNetworkCompanyZipCode_Enabled = 1;
         edtNetworkCompanyCity_Jsonclick = "";
         edtNetworkCompanyCity_Enabled = 1;
         edtNetworkCompanyCountry_Jsonclick = "";
         edtNetworkCompanyCountry_Enabled = 1;
         edtNetworkCompanyPhoneNumber_Jsonclick = "";
         edtNetworkCompanyPhoneNumber_Enabled = 1;
         edtNetworkCompanyPhoneCode_Jsonclick = "";
         edtNetworkCompanyPhoneCode_Enabled = 1;
         edtNetworkCompanyPhone_Jsonclick = "";
         edtNetworkCompanyPhone_Enabled = 1;
         edtNetworkCompanyEmail_Jsonclick = "";
         edtNetworkCompanyEmail_Enabled = 1;
         edtNetworkCompanyContactName_Jsonclick = "";
         edtNetworkCompanyContactName_Enabled = 1;
         edtNetworkCompanyName_Jsonclick = "";
         edtNetworkCompanyName_Enabled = 1;
         edtNetworkCompanyKvkNumber_Jsonclick = "";
         edtNetworkCompanyKvkNumber_Enabled = 1;
         edtNetworkCompanyId_Jsonclick = "";
         edtNetworkCompanyId_Enabled = 1;
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
         GX_FocusControl = edtNetworkCompanyKvkNumber_Internalname;
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

      public void Valid_Networkcompanyid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A83NetworkCompanyKvkNumber", A83NetworkCompanyKvkNumber);
         AssignAttri("", false, "A84NetworkCompanyName", A84NetworkCompanyName);
         AssignAttri("", false, "A493NetworkCompanyContactName", A493NetworkCompanyContactName);
         AssignAttri("", false, "A85NetworkCompanyEmail", A85NetworkCompanyEmail);
         AssignAttri("", false, "A86NetworkCompanyPhone", StringUtil.RTrim( A86NetworkCompanyPhone));
         AssignAttri("", false, "A363NetworkCompanyPhoneCode", A363NetworkCompanyPhoneCode);
         AssignAttri("", false, "A364NetworkCompanyPhoneNumber", A364NetworkCompanyPhoneNumber);
         AssignAttri("", false, "A317NetworkCompanyCountry", A317NetworkCompanyCountry);
         AssignAttri("", false, "A318NetworkCompanyCity", A318NetworkCompanyCity);
         AssignAttri("", false, "A319NetworkCompanyZipCode", A319NetworkCompanyZipCode);
         AssignAttri("", false, "A320NetworkCompanyAddressLine1", A320NetworkCompanyAddressLine1);
         AssignAttri("", false, "A321NetworkCompanyAddressLine2", A321NetworkCompanyAddressLine2);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z82NetworkCompanyId", Z82NetworkCompanyId.ToString());
         GxWebStd.gx_hidden_field( context, "Z83NetworkCompanyKvkNumber", Z83NetworkCompanyKvkNumber);
         GxWebStd.gx_hidden_field( context, "Z84NetworkCompanyName", Z84NetworkCompanyName);
         GxWebStd.gx_hidden_field( context, "Z493NetworkCompanyContactName", Z493NetworkCompanyContactName);
         GxWebStd.gx_hidden_field( context, "Z85NetworkCompanyEmail", Z85NetworkCompanyEmail);
         GxWebStd.gx_hidden_field( context, "Z86NetworkCompanyPhone", StringUtil.RTrim( Z86NetworkCompanyPhone));
         GxWebStd.gx_hidden_field( context, "Z363NetworkCompanyPhoneCode", Z363NetworkCompanyPhoneCode);
         GxWebStd.gx_hidden_field( context, "Z364NetworkCompanyPhoneNumber", Z364NetworkCompanyPhoneNumber);
         GxWebStd.gx_hidden_field( context, "Z317NetworkCompanyCountry", Z317NetworkCompanyCountry);
         GxWebStd.gx_hidden_field( context, "Z318NetworkCompanyCity", Z318NetworkCompanyCity);
         GxWebStd.gx_hidden_field( context, "Z319NetworkCompanyZipCode", Z319NetworkCompanyZipCode);
         GxWebStd.gx_hidden_field( context, "Z320NetworkCompanyAddressLine1", Z320NetworkCompanyAddressLine1);
         GxWebStd.gx_hidden_field( context, "Z321NetworkCompanyAddressLine2", Z321NetworkCompanyAddressLine2);
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
         setEventMetadata("VALID_NETWORKCOMPANYID","""{"handler":"Valid_Networkcompanyid","iparms":[{"av":"A82NetworkCompanyId","fld":"NETWORKCOMPANYID"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"}]""");
         setEventMetadata("VALID_NETWORKCOMPANYID",""","oparms":[{"av":"A83NetworkCompanyKvkNumber","fld":"NETWORKCOMPANYKVKNUMBER"},{"av":"A84NetworkCompanyName","fld":"NETWORKCOMPANYNAME"},{"av":"A493NetworkCompanyContactName","fld":"NETWORKCOMPANYCONTACTNAME"},{"av":"A85NetworkCompanyEmail","fld":"NETWORKCOMPANYEMAIL"},{"av":"A86NetworkCompanyPhone","fld":"NETWORKCOMPANYPHONE"},{"av":"A363NetworkCompanyPhoneCode","fld":"NETWORKCOMPANYPHONECODE"},{"av":"A364NetworkCompanyPhoneNumber","fld":"NETWORKCOMPANYPHONENUMBER"},{"av":"A317NetworkCompanyCountry","fld":"NETWORKCOMPANYCOUNTRY"},{"av":"A318NetworkCompanyCity","fld":"NETWORKCOMPANYCITY"},{"av":"A319NetworkCompanyZipCode","fld":"NETWORKCOMPANYZIPCODE"},{"av":"A320NetworkCompanyAddressLine1","fld":"NETWORKCOMPANYADDRESSLINE1"},{"av":"A321NetworkCompanyAddressLine2","fld":"NETWORKCOMPANYADDRESSLINE2"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z82NetworkCompanyId"},{"av":"Z83NetworkCompanyKvkNumber"},{"av":"Z84NetworkCompanyName"},{"av":"Z493NetworkCompanyContactName"},{"av":"Z85NetworkCompanyEmail"},{"av":"Z86NetworkCompanyPhone"},{"av":"Z363NetworkCompanyPhoneCode"},{"av":"Z364NetworkCompanyPhoneNumber"},{"av":"Z317NetworkCompanyCountry"},{"av":"Z318NetworkCompanyCity"},{"av":"Z319NetworkCompanyZipCode"},{"av":"Z320NetworkCompanyAddressLine1"},{"av":"Z321NetworkCompanyAddressLine2"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_NETWORKCOMPANYKVKNUMBER","""{"handler":"Valid_Networkcompanykvknumber","iparms":[]}""");
         setEventMetadata("VALID_NETWORKCOMPANYEMAIL","""{"handler":"Valid_Networkcompanyemail","iparms":[]}""");
         setEventMetadata("VALID_NETWORKCOMPANYPHONENUMBER","""{"handler":"Valid_Networkcompanyphonenumber","iparms":[]}""");
         setEventMetadata("VALID_NETWORKCOMPANYZIPCODE","""{"handler":"Valid_Networkcompanyzipcode","iparms":[]}""");
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
         Z82NetworkCompanyId = Guid.Empty;
         Z83NetworkCompanyKvkNumber = "";
         Z84NetworkCompanyName = "";
         Z493NetworkCompanyContactName = "";
         Z85NetworkCompanyEmail = "";
         Z86NetworkCompanyPhone = "";
         Z363NetworkCompanyPhoneCode = "";
         Z364NetworkCompanyPhoneNumber = "";
         Z317NetworkCompanyCountry = "";
         Z318NetworkCompanyCity = "";
         Z319NetworkCompanyZipCode = "";
         Z320NetworkCompanyAddressLine1 = "";
         Z321NetworkCompanyAddressLine2 = "";
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
         A82NetworkCompanyId = Guid.Empty;
         A83NetworkCompanyKvkNumber = "";
         A84NetworkCompanyName = "";
         A493NetworkCompanyContactName = "";
         A85NetworkCompanyEmail = "";
         gxphoneLink = "";
         A86NetworkCompanyPhone = "";
         A363NetworkCompanyPhoneCode = "";
         A364NetworkCompanyPhoneNumber = "";
         A317NetworkCompanyCountry = "";
         A318NetworkCompanyCity = "";
         A319NetworkCompanyZipCode = "";
         A320NetworkCompanyAddressLine1 = "";
         A321NetworkCompanyAddressLine2 = "";
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
         T000B4_A82NetworkCompanyId = new Guid[] {Guid.Empty} ;
         T000B4_A83NetworkCompanyKvkNumber = new string[] {""} ;
         T000B4_A84NetworkCompanyName = new string[] {""} ;
         T000B4_A493NetworkCompanyContactName = new string[] {""} ;
         T000B4_A85NetworkCompanyEmail = new string[] {""} ;
         T000B4_A86NetworkCompanyPhone = new string[] {""} ;
         T000B4_A363NetworkCompanyPhoneCode = new string[] {""} ;
         T000B4_A364NetworkCompanyPhoneNumber = new string[] {""} ;
         T000B4_A317NetworkCompanyCountry = new string[] {""} ;
         T000B4_A318NetworkCompanyCity = new string[] {""} ;
         T000B4_A319NetworkCompanyZipCode = new string[] {""} ;
         T000B4_A320NetworkCompanyAddressLine1 = new string[] {""} ;
         T000B4_A321NetworkCompanyAddressLine2 = new string[] {""} ;
         T000B5_A82NetworkCompanyId = new Guid[] {Guid.Empty} ;
         T000B3_A82NetworkCompanyId = new Guid[] {Guid.Empty} ;
         T000B3_A83NetworkCompanyKvkNumber = new string[] {""} ;
         T000B3_A84NetworkCompanyName = new string[] {""} ;
         T000B3_A493NetworkCompanyContactName = new string[] {""} ;
         T000B3_A85NetworkCompanyEmail = new string[] {""} ;
         T000B3_A86NetworkCompanyPhone = new string[] {""} ;
         T000B3_A363NetworkCompanyPhoneCode = new string[] {""} ;
         T000B3_A364NetworkCompanyPhoneNumber = new string[] {""} ;
         T000B3_A317NetworkCompanyCountry = new string[] {""} ;
         T000B3_A318NetworkCompanyCity = new string[] {""} ;
         T000B3_A319NetworkCompanyZipCode = new string[] {""} ;
         T000B3_A320NetworkCompanyAddressLine1 = new string[] {""} ;
         T000B3_A321NetworkCompanyAddressLine2 = new string[] {""} ;
         sMode19 = "";
         T000B6_A82NetworkCompanyId = new Guid[] {Guid.Empty} ;
         T000B7_A82NetworkCompanyId = new Guid[] {Guid.Empty} ;
         T000B2_A82NetworkCompanyId = new Guid[] {Guid.Empty} ;
         T000B2_A83NetworkCompanyKvkNumber = new string[] {""} ;
         T000B2_A84NetworkCompanyName = new string[] {""} ;
         T000B2_A493NetworkCompanyContactName = new string[] {""} ;
         T000B2_A85NetworkCompanyEmail = new string[] {""} ;
         T000B2_A86NetworkCompanyPhone = new string[] {""} ;
         T000B2_A363NetworkCompanyPhoneCode = new string[] {""} ;
         T000B2_A364NetworkCompanyPhoneNumber = new string[] {""} ;
         T000B2_A317NetworkCompanyCountry = new string[] {""} ;
         T000B2_A318NetworkCompanyCity = new string[] {""} ;
         T000B2_A319NetworkCompanyZipCode = new string[] {""} ;
         T000B2_A320NetworkCompanyAddressLine1 = new string[] {""} ;
         T000B2_A321NetworkCompanyAddressLine2 = new string[] {""} ;
         T000B11_A82NetworkCompanyId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ82NetworkCompanyId = Guid.Empty;
         ZZ83NetworkCompanyKvkNumber = "";
         ZZ84NetworkCompanyName = "";
         ZZ493NetworkCompanyContactName = "";
         ZZ85NetworkCompanyEmail = "";
         ZZ86NetworkCompanyPhone = "";
         ZZ363NetworkCompanyPhoneCode = "";
         ZZ364NetworkCompanyPhoneNumber = "";
         ZZ317NetworkCompanyCountry = "";
         ZZ318NetworkCompanyCity = "";
         ZZ319NetworkCompanyZipCode = "";
         ZZ320NetworkCompanyAddressLine1 = "";
         ZZ321NetworkCompanyAddressLine2 = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_networkcompany__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_networkcompany__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_networkcompany__default(),
            new Object[][] {
                new Object[] {
               T000B2_A82NetworkCompanyId, T000B2_A83NetworkCompanyKvkNumber, T000B2_A84NetworkCompanyName, T000B2_A493NetworkCompanyContactName, T000B2_A85NetworkCompanyEmail, T000B2_A86NetworkCompanyPhone, T000B2_A363NetworkCompanyPhoneCode, T000B2_A364NetworkCompanyPhoneNumber, T000B2_A317NetworkCompanyCountry, T000B2_A318NetworkCompanyCity,
               T000B2_A319NetworkCompanyZipCode, T000B2_A320NetworkCompanyAddressLine1, T000B2_A321NetworkCompanyAddressLine2
               }
               , new Object[] {
               T000B3_A82NetworkCompanyId, T000B3_A83NetworkCompanyKvkNumber, T000B3_A84NetworkCompanyName, T000B3_A493NetworkCompanyContactName, T000B3_A85NetworkCompanyEmail, T000B3_A86NetworkCompanyPhone, T000B3_A363NetworkCompanyPhoneCode, T000B3_A364NetworkCompanyPhoneNumber, T000B3_A317NetworkCompanyCountry, T000B3_A318NetworkCompanyCity,
               T000B3_A319NetworkCompanyZipCode, T000B3_A320NetworkCompanyAddressLine1, T000B3_A321NetworkCompanyAddressLine2
               }
               , new Object[] {
               T000B4_A82NetworkCompanyId, T000B4_A83NetworkCompanyKvkNumber, T000B4_A84NetworkCompanyName, T000B4_A493NetworkCompanyContactName, T000B4_A85NetworkCompanyEmail, T000B4_A86NetworkCompanyPhone, T000B4_A363NetworkCompanyPhoneCode, T000B4_A364NetworkCompanyPhoneNumber, T000B4_A317NetworkCompanyCountry, T000B4_A318NetworkCompanyCity,
               T000B4_A319NetworkCompanyZipCode, T000B4_A320NetworkCompanyAddressLine1, T000B4_A321NetworkCompanyAddressLine2
               }
               , new Object[] {
               T000B5_A82NetworkCompanyId
               }
               , new Object[] {
               T000B6_A82NetworkCompanyId
               }
               , new Object[] {
               T000B7_A82NetworkCompanyId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000B11_A82NetworkCompanyId
               }
            }
         );
         Z82NetworkCompanyId = Guid.NewGuid( );
         A82NetworkCompanyId = Guid.NewGuid( );
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound19 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtNetworkCompanyId_Enabled ;
      private int edtNetworkCompanyKvkNumber_Enabled ;
      private int edtNetworkCompanyName_Enabled ;
      private int edtNetworkCompanyContactName_Enabled ;
      private int edtNetworkCompanyEmail_Enabled ;
      private int edtNetworkCompanyPhone_Enabled ;
      private int edtNetworkCompanyPhoneCode_Enabled ;
      private int edtNetworkCompanyPhoneNumber_Enabled ;
      private int edtNetworkCompanyCountry_Enabled ;
      private int edtNetworkCompanyCity_Enabled ;
      private int edtNetworkCompanyZipCode_Enabled ;
      private int edtNetworkCompanyAddressLine1_Enabled ;
      private int edtNetworkCompanyAddressLine2_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string Z86NetworkCompanyPhone ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtNetworkCompanyId_Internalname ;
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
      private string edtNetworkCompanyId_Jsonclick ;
      private string edtNetworkCompanyKvkNumber_Internalname ;
      private string edtNetworkCompanyKvkNumber_Jsonclick ;
      private string edtNetworkCompanyName_Internalname ;
      private string edtNetworkCompanyName_Jsonclick ;
      private string edtNetworkCompanyContactName_Internalname ;
      private string edtNetworkCompanyContactName_Jsonclick ;
      private string edtNetworkCompanyEmail_Internalname ;
      private string edtNetworkCompanyEmail_Jsonclick ;
      private string edtNetworkCompanyPhone_Internalname ;
      private string gxphoneLink ;
      private string A86NetworkCompanyPhone ;
      private string edtNetworkCompanyPhone_Jsonclick ;
      private string edtNetworkCompanyPhoneCode_Internalname ;
      private string edtNetworkCompanyPhoneCode_Jsonclick ;
      private string edtNetworkCompanyPhoneNumber_Internalname ;
      private string edtNetworkCompanyPhoneNumber_Jsonclick ;
      private string edtNetworkCompanyCountry_Internalname ;
      private string edtNetworkCompanyCountry_Jsonclick ;
      private string edtNetworkCompanyCity_Internalname ;
      private string edtNetworkCompanyCity_Jsonclick ;
      private string edtNetworkCompanyZipCode_Internalname ;
      private string edtNetworkCompanyZipCode_Jsonclick ;
      private string edtNetworkCompanyAddressLine1_Internalname ;
      private string edtNetworkCompanyAddressLine1_Jsonclick ;
      private string edtNetworkCompanyAddressLine2_Internalname ;
      private string edtNetworkCompanyAddressLine2_Jsonclick ;
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
      private string sMode19 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ86NetworkCompanyPhone ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z83NetworkCompanyKvkNumber ;
      private string Z84NetworkCompanyName ;
      private string Z493NetworkCompanyContactName ;
      private string Z85NetworkCompanyEmail ;
      private string Z363NetworkCompanyPhoneCode ;
      private string Z364NetworkCompanyPhoneNumber ;
      private string Z317NetworkCompanyCountry ;
      private string Z318NetworkCompanyCity ;
      private string Z319NetworkCompanyZipCode ;
      private string Z320NetworkCompanyAddressLine1 ;
      private string Z321NetworkCompanyAddressLine2 ;
      private string A83NetworkCompanyKvkNumber ;
      private string A84NetworkCompanyName ;
      private string A493NetworkCompanyContactName ;
      private string A85NetworkCompanyEmail ;
      private string A363NetworkCompanyPhoneCode ;
      private string A364NetworkCompanyPhoneNumber ;
      private string A317NetworkCompanyCountry ;
      private string A318NetworkCompanyCity ;
      private string A319NetworkCompanyZipCode ;
      private string A320NetworkCompanyAddressLine1 ;
      private string A321NetworkCompanyAddressLine2 ;
      private string ZZ83NetworkCompanyKvkNumber ;
      private string ZZ84NetworkCompanyName ;
      private string ZZ493NetworkCompanyContactName ;
      private string ZZ85NetworkCompanyEmail ;
      private string ZZ363NetworkCompanyPhoneCode ;
      private string ZZ364NetworkCompanyPhoneNumber ;
      private string ZZ317NetworkCompanyCountry ;
      private string ZZ318NetworkCompanyCity ;
      private string ZZ319NetworkCompanyZipCode ;
      private string ZZ320NetworkCompanyAddressLine1 ;
      private string ZZ321NetworkCompanyAddressLine2 ;
      private Guid Z82NetworkCompanyId ;
      private Guid A82NetworkCompanyId ;
      private Guid ZZ82NetworkCompanyId ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] T000B4_A82NetworkCompanyId ;
      private string[] T000B4_A83NetworkCompanyKvkNumber ;
      private string[] T000B4_A84NetworkCompanyName ;
      private string[] T000B4_A493NetworkCompanyContactName ;
      private string[] T000B4_A85NetworkCompanyEmail ;
      private string[] T000B4_A86NetworkCompanyPhone ;
      private string[] T000B4_A363NetworkCompanyPhoneCode ;
      private string[] T000B4_A364NetworkCompanyPhoneNumber ;
      private string[] T000B4_A317NetworkCompanyCountry ;
      private string[] T000B4_A318NetworkCompanyCity ;
      private string[] T000B4_A319NetworkCompanyZipCode ;
      private string[] T000B4_A320NetworkCompanyAddressLine1 ;
      private string[] T000B4_A321NetworkCompanyAddressLine2 ;
      private Guid[] T000B5_A82NetworkCompanyId ;
      private Guid[] T000B3_A82NetworkCompanyId ;
      private string[] T000B3_A83NetworkCompanyKvkNumber ;
      private string[] T000B3_A84NetworkCompanyName ;
      private string[] T000B3_A493NetworkCompanyContactName ;
      private string[] T000B3_A85NetworkCompanyEmail ;
      private string[] T000B3_A86NetworkCompanyPhone ;
      private string[] T000B3_A363NetworkCompanyPhoneCode ;
      private string[] T000B3_A364NetworkCompanyPhoneNumber ;
      private string[] T000B3_A317NetworkCompanyCountry ;
      private string[] T000B3_A318NetworkCompanyCity ;
      private string[] T000B3_A319NetworkCompanyZipCode ;
      private string[] T000B3_A320NetworkCompanyAddressLine1 ;
      private string[] T000B3_A321NetworkCompanyAddressLine2 ;
      private Guid[] T000B6_A82NetworkCompanyId ;
      private Guid[] T000B7_A82NetworkCompanyId ;
      private Guid[] T000B2_A82NetworkCompanyId ;
      private string[] T000B2_A83NetworkCompanyKvkNumber ;
      private string[] T000B2_A84NetworkCompanyName ;
      private string[] T000B2_A493NetworkCompanyContactName ;
      private string[] T000B2_A85NetworkCompanyEmail ;
      private string[] T000B2_A86NetworkCompanyPhone ;
      private string[] T000B2_A363NetworkCompanyPhoneCode ;
      private string[] T000B2_A364NetworkCompanyPhoneNumber ;
      private string[] T000B2_A317NetworkCompanyCountry ;
      private string[] T000B2_A318NetworkCompanyCity ;
      private string[] T000B2_A319NetworkCompanyZipCode ;
      private string[] T000B2_A320NetworkCompanyAddressLine1 ;
      private string[] T000B2_A321NetworkCompanyAddressLine2 ;
      private Guid[] T000B11_A82NetworkCompanyId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_networkcompany__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_networkcompany__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_networkcompany__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmT000B2;
       prmT000B2 = new Object[] {
       new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000B3;
       prmT000B3 = new Object[] {
       new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000B4;
       prmT000B4 = new Object[] {
       new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000B5;
       prmT000B5 = new Object[] {
       new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000B6;
       prmT000B6 = new Object[] {
       new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000B7;
       prmT000B7 = new Object[] {
       new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000B8;
       prmT000B8 = new Object[] {
       new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("NetworkCompanyKvkNumber",GXType.VarChar,8,0) ,
       new ParDef("NetworkCompanyName",GXType.VarChar,100,0) ,
       new ParDef("NetworkCompanyContactName",GXType.VarChar,100,0) ,
       new ParDef("NetworkCompanyEmail",GXType.VarChar,100,0) ,
       new ParDef("NetworkCompanyPhone",GXType.Char,20,0) ,
       new ParDef("NetworkCompanyPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("NetworkCompanyPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("NetworkCompanyCountry",GXType.VarChar,100,0) ,
       new ParDef("NetworkCompanyCity",GXType.VarChar,100,0) ,
       new ParDef("NetworkCompanyZipCode",GXType.VarChar,100,0) ,
       new ParDef("NetworkCompanyAddressLine1",GXType.VarChar,100,0) ,
       new ParDef("NetworkCompanyAddressLine2",GXType.VarChar,100,0)
       };
       Object[] prmT000B9;
       prmT000B9 = new Object[] {
       new ParDef("NetworkCompanyKvkNumber",GXType.VarChar,8,0) ,
       new ParDef("NetworkCompanyName",GXType.VarChar,100,0) ,
       new ParDef("NetworkCompanyContactName",GXType.VarChar,100,0) ,
       new ParDef("NetworkCompanyEmail",GXType.VarChar,100,0) ,
       new ParDef("NetworkCompanyPhone",GXType.Char,20,0) ,
       new ParDef("NetworkCompanyPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("NetworkCompanyPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("NetworkCompanyCountry",GXType.VarChar,100,0) ,
       new ParDef("NetworkCompanyCity",GXType.VarChar,100,0) ,
       new ParDef("NetworkCompanyZipCode",GXType.VarChar,100,0) ,
       new ParDef("NetworkCompanyAddressLine1",GXType.VarChar,100,0) ,
       new ParDef("NetworkCompanyAddressLine2",GXType.VarChar,100,0) ,
       new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000B10;
       prmT000B10 = new Object[] {
       new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000B11;
       prmT000B11 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T000B2", "SELECT NetworkCompanyId, NetworkCompanyKvkNumber, NetworkCompanyName, NetworkCompanyContactName, NetworkCompanyEmail, NetworkCompanyPhone, NetworkCompanyPhoneCode, NetworkCompanyPhoneNumber, NetworkCompanyCountry, NetworkCompanyCity, NetworkCompanyZipCode, NetworkCompanyAddressLine1, NetworkCompanyAddressLine2 FROM Trn_NetworkCompany WHERE NetworkCompanyId = :NetworkCompanyId  FOR UPDATE OF Trn_NetworkCompany NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000B2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000B3", "SELECT NetworkCompanyId, NetworkCompanyKvkNumber, NetworkCompanyName, NetworkCompanyContactName, NetworkCompanyEmail, NetworkCompanyPhone, NetworkCompanyPhoneCode, NetworkCompanyPhoneNumber, NetworkCompanyCountry, NetworkCompanyCity, NetworkCompanyZipCode, NetworkCompanyAddressLine1, NetworkCompanyAddressLine2 FROM Trn_NetworkCompany WHERE NetworkCompanyId = :NetworkCompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000B4", "SELECT TM1.NetworkCompanyId, TM1.NetworkCompanyKvkNumber, TM1.NetworkCompanyName, TM1.NetworkCompanyContactName, TM1.NetworkCompanyEmail, TM1.NetworkCompanyPhone, TM1.NetworkCompanyPhoneCode, TM1.NetworkCompanyPhoneNumber, TM1.NetworkCompanyCountry, TM1.NetworkCompanyCity, TM1.NetworkCompanyZipCode, TM1.NetworkCompanyAddressLine1, TM1.NetworkCompanyAddressLine2 FROM Trn_NetworkCompany TM1 WHERE TM1.NetworkCompanyId = :NetworkCompanyId ORDER BY TM1.NetworkCompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000B5", "SELECT NetworkCompanyId FROM Trn_NetworkCompany WHERE NetworkCompanyId = :NetworkCompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000B6", "SELECT NetworkCompanyId FROM Trn_NetworkCompany WHERE ( NetworkCompanyId > :NetworkCompanyId) ORDER BY NetworkCompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B6,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000B7", "SELECT NetworkCompanyId FROM Trn_NetworkCompany WHERE ( NetworkCompanyId < :NetworkCompanyId) ORDER BY NetworkCompanyId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B7,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000B8", "SAVEPOINT gxupdate;INSERT INTO Trn_NetworkCompany(NetworkCompanyId, NetworkCompanyKvkNumber, NetworkCompanyName, NetworkCompanyContactName, NetworkCompanyEmail, NetworkCompanyPhone, NetworkCompanyPhoneCode, NetworkCompanyPhoneNumber, NetworkCompanyCountry, NetworkCompanyCity, NetworkCompanyZipCode, NetworkCompanyAddressLine1, NetworkCompanyAddressLine2) VALUES(:NetworkCompanyId, :NetworkCompanyKvkNumber, :NetworkCompanyName, :NetworkCompanyContactName, :NetworkCompanyEmail, :NetworkCompanyPhone, :NetworkCompanyPhoneCode, :NetworkCompanyPhoneNumber, :NetworkCompanyCountry, :NetworkCompanyCity, :NetworkCompanyZipCode, :NetworkCompanyAddressLine1, :NetworkCompanyAddressLine2);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000B8)
          ,new CursorDef("T000B9", "SAVEPOINT gxupdate;UPDATE Trn_NetworkCompany SET NetworkCompanyKvkNumber=:NetworkCompanyKvkNumber, NetworkCompanyName=:NetworkCompanyName, NetworkCompanyContactName=:NetworkCompanyContactName, NetworkCompanyEmail=:NetworkCompanyEmail, NetworkCompanyPhone=:NetworkCompanyPhone, NetworkCompanyPhoneCode=:NetworkCompanyPhoneCode, NetworkCompanyPhoneNumber=:NetworkCompanyPhoneNumber, NetworkCompanyCountry=:NetworkCompanyCountry, NetworkCompanyCity=:NetworkCompanyCity, NetworkCompanyZipCode=:NetworkCompanyZipCode, NetworkCompanyAddressLine1=:NetworkCompanyAddressLine1, NetworkCompanyAddressLine2=:NetworkCompanyAddressLine2  WHERE NetworkCompanyId = :NetworkCompanyId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000B9)
          ,new CursorDef("T000B10", "SAVEPOINT gxupdate;DELETE FROM Trn_NetworkCompany  WHERE NetworkCompanyId = :NetworkCompanyId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000B10)
          ,new CursorDef("T000B11", "SELECT NetworkCompanyId FROM Trn_NetworkCompany ORDER BY NetworkCompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B11,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getString(6, 20);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getString(6, 20);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getString(6, 20);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
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
    }
 }

}

}
